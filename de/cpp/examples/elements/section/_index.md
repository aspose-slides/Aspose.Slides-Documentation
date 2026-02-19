---
title: Abschnitt
type: docs
weight: 90
url: /de/cpp/examples/elements/section/
keywords:
- Codebeispiel
- Abschnitt
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Verwalten Sie Folienabschnitte in Aspose.Slides für C++: Erstellen, Umbenennen, Neuordnen und Gruppieren von Folien mit C++-Beispielen für PPT, PPTX und ODP."
---
Beispiele für die Verwaltung von Präsentationsabschnitten — Hinzufügen, Zugreifen, Entfernen und Umbenennen programmatisch mit **Aspose.Slides for C++**.

## **Abschnitt hinzufügen**

Erstellen Sie einen Abschnitt, der an einer bestimmten Folie beginnt.

```cpp
static void AddSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Geben Sie die Folie an, die den Beginn des Abschnitts markiert.
    presentation->get_Sections()->AddSection(u"New Section", slide);

    presentation->Dispose();
}
```

## **Zugriff auf einen Abschnitt**

Lesen Sie Abschnittsinformationen aus einer Präsentation.

```cpp
static void AccessSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    presentation->get_Sections()->AddSection(u"My Section", slide);

    // Greifen Sie auf einen Abschnitt über den Index zu.
    auto section = presentation->get_Section(0);
    auto sectionName = section->get_Name();

    presentation->Dispose();
}
```

## **Abschnitt entfernen**

Löschen Sie einen zuvor hinzugefügten Abschnitt.

```cpp
static void RemoveSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto section = presentation->get_Sections()->AddSection(u"Temporary Section", slide);

    // Entfernen Sie den ersten Abschnitt.
    presentation->get_Sections()->RemoveSection(section);

    presentation->Dispose();
}
```

## **Abschnitt umbenennen**

Ändern Sie den Namen eines bestehenden Abschnitts.

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