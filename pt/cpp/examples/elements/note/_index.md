---
title: Nota
type: docs
weight: 240
url: /pt/cpp/examples/elements/note/
keywords:
- exemplo de código
- nota
- PowerPoint
- OpenDocument
- apresentação
- C++
- Aspose.Slides
description: "Trabalhe com notas de slides no Aspose.Slides para C++: adicione, leia, edite e exporte notas do apresentador em PPT, PPTX e ODP usando exemplos claros em C++."
---
Este artigo demonstra como adicionar, ler, remover e atualizar slides de notas usando **Aspose.Slides for C++**.

## **Adicionar um slide de notas**

Crie um slide de notas e atribua texto a ele.

```cpp
static void AddNote()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();
    slide->get_NotesSlideManager()->get_NotesSlide()->get_NotesTextFrame()->set_Text(u"My note");

    presentation->Dispose();
}
```

## **Acessar um slide de notas**

Leia o texto de um slide de notas existente.

```cpp
static void AccessNote()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();

    auto notes = notesSlide->get_NotesTextFrame()->get_Text();

    presentation->Dispose();
}
```

## **Remover um slide de notas**

Remova o slide de notas associado a um slide.

```cpp
static void RemoveNote()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();

    slide->get_NotesSlideManager()->RemoveNotesSlide();

    presentation->Dispose();
}
```

## **Atualizar texto da nota**

Altere o texto de um slide de notas.

```cpp
static void UpdateNoteText()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();

    slide->get_NotesSlideManager()->get_NotesSlide()->get_NotesTextFrame()->set_Text(u"Old");
    slide->get_NotesSlideManager()->get_NotesSlide()->get_NotesTextFrame()->set_Text(u"Updated");

    presentation->Dispose();
}
```