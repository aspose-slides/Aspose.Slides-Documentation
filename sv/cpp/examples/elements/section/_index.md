---
title: Avsnitt
type: docs
weight: 90
url: /sv/cpp/examples/elements/section/
keywords:
- kodexempel
- avsnitt
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Hantera bildavsnitt i Aspose.Slides för C++: skapa, byta namn, ändra ordning och gruppera bilder med C++-exempel för PPT, PPTX och ODP."
---
Exempel på att hantera presentationsavsnitt—lägga till, komma åt, ta bort och byta namn på dem programatiskt med **Aspose.Slides for C++**.

## **Lägg till ett avsnitt**

Skapa ett avsnitt som börjar på en specifik bild.

```cpp
static void AddSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Ange bilden som markerar början av avsnittet.
    presentation->get_Sections()->AddSection(u"New Section", slide);

    presentation->Dispose();
}
```

## **Kom åt ett avsnitt**

Läs avsnittsinformation från en presentation.

```cpp
static void AccessSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    presentation->get_Sections()->AddSection(u"My Section", slide);

    // Åtkomst till ett avsnitt via index.
    auto section = presentation->get_Section(0);
    auto sectionName = section->get_Name();

    presentation->Dispose();
}
```

## **Ta bort ett avsnitt**

Ta bort ett tidigare tillagt avsnitt.

```cpp
static void RemoveSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto section = presentation->get_Sections()->AddSection(u"Temporary Section", slide);

    // Ta bort det första avsnittet.
    presentation->get_Sections()->RemoveSection(section);

    presentation->Dispose();
}
```

## **Byt namn på ett avsnitt**

Ändra namnet på ett befintligt avsnitt.

```cpp
static void RenameSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    presentation->get_Sections()->AddSection(u"Old Name", slide);

    auto section = presentation->get_Section(0);
    section->set_Name(u"New Name");

    presentation->Dispose();
}
```