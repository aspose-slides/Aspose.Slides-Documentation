---
title: Section
type: docs
weight: 90
url: /cpp/examples/elements/section/
keywords:
- code example
- section
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Manage slide sections in Aspose.Slides for C++: create, rename, reorder, and group slides with C++ examples for PPT, PPTX, and ODP."
---

Examples for managing presentation sections—add, access, remove, and rename them programmatically using **Aspose.Slides for C++**.

## **Add a Section**

Create a section that starts at a specific slide.

```cpp
static void AddSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Specify the slide that marks the beginning of the section.
    presentation->get_Sections()->AddSection(u"New Section", slide);

    presentation->Dispose();
}
```

## **Access a Section**

Read section information from a presentation.

```cpp
static void AccessSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    presentation->get_Sections()->AddSection(u"My Section", slide);

    // Access a section by index.
    auto section = presentation->get_Section(0);
    auto sectionName = section->get_Name();

    presentation->Dispose();
}
```

## **Remove a Section**

Delete a previously added section.

```cpp
static void RemoveSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto section = presentation->get_Sections()->AddSection(u"Temporary Section", slide);

    // Remove the first section.
    presentation->get_Sections()->RemoveSection(section);

    presentation->Dispose();
}
```

## **Rename a Section**

Change the name of an existing section.

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
