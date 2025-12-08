---
title: تحويل العروض التقديمية في وضع النشرة باستخدام Python
linktitle: وضع النشرة
type: docs
weight: 150
url: /ar/python-net/convert-powerpoint-in-Handout-mode/
keywords:
- تحويل PowerPoint
- تحويل عرض تقديمي
- وضع النشرة
- نشرة
- PowerPoint
- عرض تقديمي
- PPT
- PPTX
- Python
- Aspose.Slides
description: "تحويل العروض التقديمية إلى نشرات في Python. ضبط عدد الشرائح في الصفحة، الحفاظ على الملاحظات، التصدير إلى PDF أو صور باستخدام Aspose.Slides، مع كود مثال. جربه مجانًا."
---

## **تصدير وضع النشرات**

توفر Aspose.Slides القدرة على تحويل العروض التقديمية إلى صيغ مختلفة، بما في ذلك إنشاء نشرات للطباعة في وضع النشرة. يتيح لك هذا الوضع تكوين عدد الشرائح التي تظهر على صفحة واحدة، مما يجعله مفيدًا للمؤتمرات والندوات والفعاليات الأخرى. يمكنك تمكين هذا الوضع عن طريق ضبط خاصية `slides_layout_options` في فئات [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)، [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/)، [HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/)، و[TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/).

لتكوين وضع النشرة، استخدم كائن [HandoutLayoutingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/handoutlayoutingoptions/) الذي يحدد عدد الشرائح التي توضع على صفحة واحدة وغيرها من معايير العرض.

فيما يلي مثال على شفرة يوضح كيفية تحويل عرض تقديمي إلى PDF في وضع النشرة.
```py
# تحميل عرض تقديمي.
with slides.Presentation("sample.pptx") as presentation:

    # تعيين خيارات التصدير.
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # 4 شرائح على صفحة واحدة أفقياً
    slides_layout_options.print_slide_numbers = True                                 # طباعة أرقام الشرائح
    slides_layout_options.print_frame_slide = True                                   # طباعة إطار حول الشرائح
    slides_layout_options.print_comments = False                                     # لا تعليقات

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # تصدير العرض التقديمي إلى PDF باستخدام التخطيط المختار.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```


{{% alert color="warning" %}} 

ضع في اعتبارك أن خاصية `slides_layout_options` متاحة فقط لبعض صيغ الإخراج، مثل PDF وHTML وTIFF، وعند التصيير كصور.

{{% /alert %}} 

## **الأسئلة المتكررة**

**ما هو الحد الأقصى لعدد مصغرات الشرائح في الصفحة في وضع النشرة؟**

تدعم Aspose.Slides [presets](https://reference.aspose.com/slides/python-net/aspose.slides.export/handouttype/) تصل إلى 9 مصغرات لكل صفحة مع ترتيب أفقي أو عمودي: 1، 2، 3، 4 (أفقي/عمودي)، 6 (أفقي/عمودي)، و9 (أفقي/عمودي).

**هل يمكنني تحديد شبكة مخصصة، مثل 5 أو 8 شرائح لكل صفحة؟**

لا. يتم التحكم في عدد وترتيب المصغرات بشكل صارم بواسطة تعداد [HandoutType](https://reference.aspose.com/slides/python-net/aspose.slides.export/handouttype/)؛ لا تدعم التخطيطات العشوائية.

**هل يمكنني تضمين الشرائح المخفية في ناتج النشرة؟**

نعم. فعّل خيار `show_hidden_slides` في إعدادات التصدير للصيغة المستهدفة، مثل [PdfOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/)، [HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/)، أو [TiffOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/tiffoptions/).