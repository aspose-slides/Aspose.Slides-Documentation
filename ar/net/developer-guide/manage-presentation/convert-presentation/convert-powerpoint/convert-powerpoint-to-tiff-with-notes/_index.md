---
title: تحويل PowerPoint إلى TIFF مع الملاحظات
type: docs
weight: 100
url: /ar/net/convert-powerpoint-to-tiff-with-notes/
keywords: "تحويل PowerPoint إلى TIFF مع الملاحظات"
description: "تحويل PowerPoint إلى TIFF مع الملاحظات في Aspose.Slides."
---

{{% alert title="نصيحة" color="primary" %}}

قد ترغب في الاطلاع على Aspose [محول PowerPoint إلى ملصق المجاني](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

TIFF هو واحد من عدة تنسيقات الصور المستخدمة على نطاق واسع التي تدعمها Aspose.Slides لـ .NET لتحويل عرض PowerPoint PPT و PPTX مع الملاحظات إلى صور. يمكنك أيضًا إنشاء صور مصغرة للشريحة في عرض الشريحة الملاحظات. يمكن استخدام الطريقة [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) المتاحة من قبل فئة Presentation لتحويل العرض الكامل في عرض الشريحة الملاحظات إلى TIFF. حفظ عرض Microsoft PowerPoint إلى ملاحظات TIFF باستخدام Aspose.Slides لـ .NET هو عملية تتكون من سطرين. كل ما عليك فعله هو فتح العرض وحفظه إلى ملاحظات TIFF. يمكنك أيضًا إنشاء صورة مصغرة لشريحة في عرض الشريحة الملاحظات للشرائح الفردية. تقوم مقتطفات الكود أدناه بتحديث العرض التقديمي النموذجي إلى صور TIFF في عرض الشريحة الملاحظات، كما هو موضح أدناه:

```c#
// إنشاء كائن Presentation يمثل ملف عرض تقديمي
using (Presentation presentation = new Presentation("NotesFile.pptx"))
{
    // حفظ العرض إلى ملاحظات TIFF
    presentation.Save("Notes_In_Tiff_out.tiff", SaveFormat.Tiff);
}
```