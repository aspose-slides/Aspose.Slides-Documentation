---
title: كائن OLE
type: docs
weight: 210
url: /ar/cpp/examples/elements/ole-object/
keywords:
- مثال برمجي
- كائن OLE
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "معالجة كائنات OLE في Aspose.Slides for C++: إدراج، ربط، تحديث، واستخراج المحتوى المضمن باستخدام C++ في عروض PPT وPPTX وODP."
---
توضح هذه المقالة كيفية تضمين ملف ككائن OLE وتحديث بياناته باستخدام **Aspose.Slides for C++**.

## **إضافة كائن OLE**

تضمين ملف PDF في العرض التقديمي.

```cpp
static void AddOleObject()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto pdfData = File::ReadAllBytes(u"doc.pdf");
    auto dataInfo = MakeObject<OleEmbeddedDataInfo>(pdfData, u"pdf");
    auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    presentation->Dispose();
}
```

## **الوصول إلى كائن OLE**

استرداد إطار كائن OLE الأول في الشريحة.

```cpp
static void AccessOleObject()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto pdfData = File::ReadAllBytes(u"doc.pdf");
    auto dataInfo = MakeObject<OleEmbeddedDataInfo>(pdfData, u"pdf");
    auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    auto firstOleFrame = SharedPtr<IOleObjectFrame>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IOleObjectFrame>(shape))
        {
            firstOleFrame = ExplicitCast<IOleObjectFrame>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **إزالة كائن OLE**

حذف كائن OLE المضمن من الشريحة.

```cpp
static void RemoveOleObject()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto pdfData = File::ReadAllBytes(u"doc.pdf");
    auto dataInfo = MakeObject<OleEmbeddedDataInfo>(pdfData, u"pdf");
    auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    slide->get_Shapes()->Remove(oleFrame);

    presentation->Dispose();
}
```

## **تحديث بيانات كائن OLE**

استبدال البيانات المضمنة في كائن OLE موجود.

```cpp
static void UpdateOleObjectData()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto pdfData = File::ReadAllBytes(u"doc.pdf");
    auto dataInfo = MakeObject<OleEmbeddedDataInfo>(pdfData, u"pdf");
    auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    auto newData = File::ReadAllBytes(u"Picture.png");
    auto newDataInfo = MakeObject<OleEmbeddedDataInfo>(newData, u"png");
    oleFrame->SetEmbeddedData(newDataInfo);

    presentation->Dispose();
}
```