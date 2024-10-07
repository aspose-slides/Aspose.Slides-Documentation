---
title: تحويل PowerPoint إلى TIFF مع الملاحظات
type: docs
weight: 100
url: /python-net/convert-powerpoint-to-tiff-with-notes/
keywords: "تحويل PowerPoint إلى TIFF مع الملاحظات"
description: "تحويل PowerPoint إلى TIFF مع الملاحظات في Aspose.Slides."
---

{{% alert title="نصيحة" color="primary" %}}

قد ترغب في الاطلاع على محول Aspose [المجاني لتحويل PowerPoint إلى ملصق](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

TIFF هو أحد عدة تنسيقات صور مستخدمة على نطاق واسع والتي تدعمها Aspose.Slides لـ Python عبر .NET لتحويل عروض PowerPoint PPT وPPTX مع الملاحظات إلى صور. يمكنك أيضًا توليد صور مصغرة للشرائح في عرض شريحة الملاحظات. يمكن استخدام طريقة [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) التي تظهرها فئة Presentation لتحويل العرض التقديمي بالكامل في عرض شريحة الملاحظات إلى TIFF. يعد حفظ عرض PowerPoint من Microsoft إلى ملاحظات TIFF باستخدام Aspose.Slides لـ Python عبر .NET عملية تتكون من سطرين. كل ما عليك القيام به هو فتح العرض التقديمي وحفظه إلى ملاحظات TIFF. يمكنك أيضًا توليد صورة مصغرة لشريحة في عرض شريحة الملاحظات للشرائح الفردية. يتم تحديث مقتطفات الشيفرة أدناه لإنتاج العرض التقديمي كصور TIFF في عرض شريحة الملاحظات، كما هو موضح أدناه:

```py
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف عرض تقديمي
presentation = slides.Presentation("pres.pptx")

# حفظ العرض التقديمي إلى ملاحظات TIFF
presentation.save("Notes_In_Tiff_out.tiff", slides.export.SaveFormat.TIFF)
```