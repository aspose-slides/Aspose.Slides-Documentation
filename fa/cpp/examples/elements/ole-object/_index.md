---
title: شی OLE
type: docs
weight: 210
url: /fa/cpp/examples/elements/ole-object/
keywords:
- مثال کد
- شی OLE
- پاورپوینت
- سند باز
- ارائه
- C++
- Aspose.Slides
description: "شیوهٔ کار با اشیاء OLE در Aspose.Slides برای C++: درج، پیوند، به‌روزرسانی، و استخراج محتوای جاسازی‌شده با C++ در ارائه‌های PPT، PPTX و ODP."
---
این مقاله نشان می‌دهد که چگونه یک فایل را به عنوان شی OLE جاسازی کرده و داده‌های آن را با استفاده از **Aspose.Slides for C++** به‌روزرسانی کنید.

## **افزودن یک شی OLE**

یک فایل PDF را به ارائه جاسازی کنید.

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

## **دسترسی به یک شی OLE**

قاب اولین شی OLE را در یک اسلاید بازیابی کنید.

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

## **حذف یک شی OLE**

یک شی OLE جاسازی شده را از اسلاید حذف کنید.

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

## **به‌روزرسانی داده‌های شی OLE**

داده‌های جاسازی‌شده در یک شی OLE موجود را جایگزین کنید.

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