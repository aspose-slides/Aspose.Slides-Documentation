---
title: Nota
type: docs
weight: 240
url: /pt/net/examples/elements/note/
keywords:
- nota
- adicionar slide de notas
- acessar slide de notas
- remover slide de notas
- atualizar texto das notas
- exemplo de código
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Trabalhe com notas de slide no Aspose.Slides for .NET: adicione, leia, edite e exporte notas do apresentador em PPT, PPTX e ODP usando exemplos claros em C#."
---
Este artigo demonstra como adicionar, ler, remover e atualizar slides de notas usando **Aspose.Slides for .NET**.

## **Adicionar um Slide de Notas**

Crie um slide de notas e atribua texto a ele.

```csharp
static void AddNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "My note";
}
```

## **Acessar um Slide de Notas**

Leia o texto de um slide de notas existente.

```csharp
static void AccessNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    var notes = notesSlide.NotesTextFrame.Text;
}
```

## **Remover um Slide de Notas**

Remova o slide de notas associado a um slide.

```csharp
static void RemoveNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```

## **Atualizar Texto das Notas**

Altere o texto de um slide de notas.

```csharp
static void UpdateNoteText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "Old";
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "Updated";
}
```