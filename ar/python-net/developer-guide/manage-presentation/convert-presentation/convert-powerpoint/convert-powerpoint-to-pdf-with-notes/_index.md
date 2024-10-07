---
title: تحويل PowerPoint إلى PDF مع الملاحظات
type: docs
weight: 50
url: /python-net/convert-powerpoint-to-pdf-with-notes/
keywords: "تحويل PowerPoint، عرض تقديمي، PowerPoint إلى PDF، ملاحظات، Python، Aspose.Slides"
description: "تحويل PowerPoint إلى PDF مع الملاحظات باستخدام Python"
---

يمكن استخدام طريقة [Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) التي تعرضها فئة Presentation لتحويل عرض PowerPoint PPT أو PPTX إلى PDF مع الملاحظات. يعد حفظ عرض تقديمي من Microsoft PowerPoint إلى PDF مع الملاحظات باستخدام Aspose.Slides لـ Python عبر .NET عملية من سطرين. ما عليك سوى فتح العرض التقديمي وحفظه كملف PDF مع الملاحظات. تقوم مقاطع التعليمات البرمجية أدناه بتحديث العرض التقديمي النموذجي إلى PDF في عرض شريحة الملاحظات:

```py
import aspose.slides as slides

# إنشاء كائن Presentation يمثل ملف عرض تقديمي 
presentation = slides.Presentation("SelectedSlides.pptx")
auxPresentation = slides.Presentation()

slide = presentation.slides[0]

auxPresentation.slides.insert_clone(0, slide)

# تعيين نوع وحجم الشريحة 
auxPresentation.slide_size.set_size(612, 792, slides.SlideSizeScaleType.ENSURE_FIT)

pdfOptions = slides.export.PdfOptions()
pdfOptions.notes_comments_layouting.notes_position = slides.export.NotesPositions.BOTTOM_FULL

auxPresentation.save("PDFnotes_out.pdf", slides.export.SaveFormat.PDF, pdfOptions)
```

{{% alert color="primary" %}} 

قد ترغب في الاطلاع على Aspose [PowerPoint إلى PDF](https://products.aspose.app/slides/conversion) أو [PPT إلى PDF](https://products.aspose.app/slides/conversion/ppt-to-pdf) محول. 

{{% /alert %}}