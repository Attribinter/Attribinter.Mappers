﻿namespace SharpAttributeParser.Mappers;

/// <summary>Handles creation of <see cref="ISyntacticRecorder"/> using <see cref="ISyntacticMapper"/>.</summary>
public interface ISyntacticRecorderFactory
{
    /// <summary>Creates a recorder which records syntactic information about the arguments of attributes to the provided record.</summary>
    /// <param name="mapper">Maps parameters of the attribute to recorders, responsible for recording syntactic information about arguments of that parameter.</param>
    /// <returns>The created recorder.</returns>
    public abstract ISyntacticRecorder Create(ISyntacticMapper mapper);
}
