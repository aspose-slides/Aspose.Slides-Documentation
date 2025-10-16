---
title: Header Footer
type: docs
weight: 220
url: /cpp/examples/elements/elements/headerfooter/
keywords:
- code example
- header
- footer
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Control slide headers and footers with Aspose.Slides for C++: add dates, slide numbers, and custom text in PPT, PPTX, and ODP with C++ examples."
---

This article demonstrates how to add footers and update date and time placeholders using **Aspose.Slides for C++**.

## **Add a Footer**

Add text to the footer area of a slide and make it visible.

```cpp
static void AddHeaderFooter()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_HeaderFooterManager()->SetFooterText(u"My footer");
    slide->get_HeaderFooterManager()->SetFooterVisibility(true);

    presentation->Dispose();
}
```

## **Update Date and Time**

Modify the date and time placeholder on a slide.

```cpp
static void UpdateDateTime()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_HeaderFooterManager()->SetDateTimeText(u"01/01/2024");
    slide->get_HeaderFooterManager()->SetDateTimeVisibility(true);

    presentation->Dispose();
}
```
