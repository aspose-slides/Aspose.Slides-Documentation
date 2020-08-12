---
title: Aspose.Slides for CPP 19.1 Release Notes
type: docs
weight: 120
url: /cpp/aspose-slides-for-cpp-19-1-release-notes/
---

|**Key**|**Summary**|**Category**|
| :- | :- | :- |
|SLIDESCPP-1647|Improve thumbnails rendering quality (v19.1)|Feature|
|SLIDESCPP-1669|[Use Aspose.Slides for .NET 19.1 features](https://docs.asposeptyltd.com/display/slidesnet/Aspose.Slides+for+.NET+19.1+Release+Notes)|Feature|
## **Public API Changes**

#### **get_AlternativeTextTitle() and set_AlternativeTextTitle() methods have been added to IShape class**
New get_AlternativeTextTitle() and set_AlternativeTextTitle() methods have been added to IShape and Shape classes.

These methods allow to get or set the title of alternative text associated with a shape.

Sample code demonstrating setting alternative text title:

```

 System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

System::SharedPtr<IAutoShape> shape = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 100, 50, 300, 150);

shape->set_AlternativeTextTitle(u"Alt text title");

```




