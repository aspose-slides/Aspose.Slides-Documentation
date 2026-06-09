---
title: Seção
type: docs
weight: 90
url: /pt/net/examples/elements/section/
keywords:
- seção
- seção de slide
- adicionar seção
- acessar seção
- remover seção
- renomear seção
- exemplo de código
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Gerencie seções de slides no Aspose.Slides for .NET: crie, renomeie, reordene e agrupe slides com exemplos em C# para PPT, PPTX e ODP."
---
Exemplos de gerenciamento de seções de apresentação — adicionar, acessar, remover e renomear programaticamente usando **Aspose.Slides for .NET**.

## **Adicionar uma Seção**

Crie uma seção que começa em um slide específico.

```csharp
static void AddSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Especifique o slide que marca o início da seção.
    presentation.Sections.AddSection("New Section", slide);
}
```

## **Acessar uma Seção**

Leia as informações da seção de uma apresentação.

```csharp
static void AccessSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    presentation.Sections.AddSection("My Section", slide);

    // Acesse uma seção por índice.
    var section = presentation.Sections[0];
    var sectionName = section.Name;
}
```

## **Remover uma Seção**

Exclua uma seção adicionada anteriormente.

```csharp
static void RemoveSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var section = presentation.Sections.AddSection("Temporary Section", slide);

    // Remova a primeira seção.
    presentation.Sections.RemoveSection(section);
}
```

## **Renomear uma Seção**

Altere o nome de uma seção existente.

```csharp
static void RenameSection()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    presentation.Sections.AddSection("Old Name", slide);

    var section = presentation.Sections[0];
    section.Name = "New Name";
}
```