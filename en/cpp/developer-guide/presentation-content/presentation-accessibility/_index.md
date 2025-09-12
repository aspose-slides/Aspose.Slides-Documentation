---
title: Manage Presentation Accessibility in C++
linktitle: Presentation Accessibility
type: docs
weight: 30
url: /cpp/presentation-accessibility/
keywords:
- presentation accessibility
- mark as decorative
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Discover how Aspose.Slides for C++ helps automate presentation accessibility checks in PPT, PPTX and ODP files—enhance screen reader experience and boost compliance."
---

## **Overview**

Presentation accessibility ensures that people using assistive technologies—such as screen readers, braille displays, or keyboard-only navigation—can understand and navigate your slides as effectively as sighted, mouse-using audiences. Good practice focuses on clear reading order, meaningful alternative text for informative visuals, sufficient color contrast, readable typography, descriptive link text, and avoiding conveying meaning by color or position alone. When accessibility is planned from the start, the result is a cleaner structure, more consistent visuals, and content that reaches every viewer without workarounds.

## **Mark as Decorative**

Mark as decorative flags purely ornamental visuals so screen readers skip them, reducing noise and keeping focus on meaningful content. Apply it to backgrounds, flourishes, and spacers—never to charts, icons, or images that convey information. Aspose.Slides exposes this flag for detection and validation, enabling automated accessibility checks and cleanup.

![Mark as Decorative](mark_as_decorative.png)

The following code sample shows how to determine whether a shape is marked as decorative.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
Console::WriteLine(u"Is shape decorative: {0}", shape->get_IsDecorative());

presentation->Dispose();
```
