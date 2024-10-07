---
title: تحويل PowerPoint إلى TIFF مع الملاحظات
type: docs
weight: 100
url: /cpp/convert-powerpoint-to-tiff-with-notes/
keywords: "تحويل PowerPoint إلى TIFF مع الملاحظات"
description: "تحويل PowerPoint إلى TIFF مع الملاحظات في Aspose.Slides."
---

TIFF هو واحد من عدة تنسيقات صور مستخدمة على نطاق واسع التي تدعمها Aspose.Slides لـ C++ لتحويل عرض PowerPoint PPT و PPTX مع الملاحظات إلى صور. يمكنك أيضًا إنشاء مصغرات الشرائح في عرض شريحة الملاحظات. يمكن استخدام метод [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) المعروض بواسطة فئة Presentation لتحويل العرض الكامل في عرض شريحة الملاحظات إلى TIFF. حفظ عرض PowerPoint من مايكروسوفت إلى TIFF مع Aspose.Slides لـ C++ هو عملية من سطرين. ما عليك سوى فتح العرض وحفظه إلى TIFF مع الملاحظات. يمكنك أيضًا إنشاء مصغرات الشرائح في عرض شريحة الملاحظات للشرائح الفردية. تقوم مقاطع الكود أدناه بتحديث العرض النموذجي إلى صور TIFF في عرض شريحة الملاحظات، كما هو موضح أدناه:

```cpp
// المسار إلى دليل المستندات.
System::String dataDir = GetDataPath();

// إنشاء كائن Presentation يمثل ملف عرض
auto presentation = System::MakeObject<Presentation>(dataDir + u"NotesFile.pptx");

// حفظ العرض إلى TIFF مع الملاحظات
presentation->Save(dataDir + u"Notes_In_Tiff_out.tiff", SaveFormat::Tiff);
```

{{% alert title="نصيحة" color="primary" %}}

قد ترغب في التحقق من Aspose [محول PowerPoint إلى ملصق المجاني](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).

{{% /alert %}}