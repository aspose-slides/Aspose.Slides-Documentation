---
title: Sectie
type: docs
weight: 90
url: /nl/cpp/examples/elements/section/
keywords:
- codevoorbeeld
- sectie
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Beheer dia-secties in Aspose.Slides for C++: maak, hernoem, hersorteer en groepeer dia's met C++-voorbeelden voor PPT, PPTX en ODP."
---
Voorbeelden voor het beheren van presentatiesecties—toevoegen, openen, verwijderen en hernoemen via code met **Aspose.Slides for C++**.

## **Sectie toevoegen**

Maak een sectie aan die begint op een specifieke dia.

```cpp
static void AddSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Specificeer de dia die het begin van de sectie aangeeft.
    presentation->get_Sections()->AddSection(u"New Section", slide);

    presentation->Dispose();
}
```

## **Sectie openen**

Lees sectie-informatie uit een presentatie.

```cpp
static void AccessSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    presentation->get_Sections()->AddSection(u"My Section", slide);

    // Toegang tot een sectie op index.
    auto section = presentation->get_Section(0);
    auto sectionName = section->get_Name();

    presentation->Dispose();
}
```

## **Sectie verwijderen**

Verwijder een eerder toegevoegde sectie.

```cpp
static void RemoveSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto section = presentation->get_Sections()->AddSection(u"Temporary Section", slide);

    // Verwijder de eerste sectie.
    presentation->get_Sections()->RemoveSection(section);

    presentation->Dispose();
}
```

## **Sectie hernoemen**

Wijzig de naam van een bestaande sectie.

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