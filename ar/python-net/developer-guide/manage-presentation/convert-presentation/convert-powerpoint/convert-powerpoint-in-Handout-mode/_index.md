---
title: تحويل العروض التقديمية إلى وضع الكتيب باستخدام بايثون
linktitle: وضع الكتيب
type: docs
weight: 150
url: /ar/python-net/convert-powerpoint-in-handout-mode/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- وضع الكتيب
- كتيب
- PowerPoint
- عرض تقديمي
- PPT
- PPTX
- بايثون
- Aspose.Slides
description: "تحويل العروض التقديمية إلى كتيبات باستخدام بايثون. ضبط عدد الشرائح في كل صفحة، الحفاظ على الملاحظات، التصدير إلى PDF أو صور باستخدام Aspose.Slides، مع كود مثال. جربها مجانًا."
---
## **المقدمة**

توفر Aspose.Slides القدرة على تحويل العروض التقديمية إلى صيغ مختلفة، بما في ذلك إنشاء كتيبات للطباعة في وضع Handout. يتيح لك هذا الوضع تكوين كيفية ظهور عدة شرائح على صفحة واحدة، مما يجعله مفيدًا للمؤتمرات والندوات وغيرها من الفعاليات. يمكنك تمكين هذا الوضع عن طريق ضبط الخاصية `slides_layout_options` في الفئات [PdfOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/htmloptions/), و[TiffOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/tiffoptions/) .

لتحديد أبعاد صفحة الكتيب واتجاهها قبل التصدير، انظر إلى [Notes Page Size](/slides/ar/python-net/notes-size/).

## **تصدير وضع Handout**

لتكوين وضع Handout، استخدم كائن [HandoutLayoutingOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/handoutlayoutingoptions/)، الذي يحدد عدد الشرائح التي تُوضع على صفحة واحدة وغيرها من معلمات العرض.

فيما يلي مثال على شفرة يُظهر كيفية تحويل عرض تقديمي إلى PDF في وضع Handout.

```py
import aspose.slides as slides

# تحميل عرض تقديمي.
with slides.Presentation("sample.pptx") as presentation:

    # تعيين خيارات التصدير.
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # 4 شرائح على صفحة واحدة أفقياً
    slides_layout_options.print_slide_numbers = True                                 # طباعة أرقام الشرائح
    slides_layout_options.print_frame_slide = True                                   # طباعة إطار حول الشرائح
    slides_layout_options.print_comments = False                                     # لا توجد تعليقات

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # تصدير العرض التقديمي إلى PDF باستخدام التخطيط المختار.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="warning" title="Warning" %}}
تذكّر أن الخاصية `slides_layout_options` متوفرة فقط لبعض صيغ الإخراج، مثل PDF وHTML وTIFF، وعند التجسيد كصور.
{{% /alert %}} 

## **الأسئلة المتكررة**

**ما هو الحد الأقصى لعدد مصغرات الشرائح في كل صفحة في وضع Handout؟**

يدعم Aspose.Slides [الإعدادات المسبقة](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/handouttype/) حتى 9 مصغرات لكل صفحة بترتيب أفقي أو عمودي: 1، 2، 3، 4 (أفقي/عمودي)، 6 (أفقي/عمودي)، و9 (أفقي/عمودي).

**هل يمكنني تعريف شبكة مخصصة، مثل 5 أو 8 شرائح لكل صفحة؟**

لا. يتم التحكم في عدد وترتيب المصغرات بدقة من خلال تعداد [HandoutType](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/handouttype/)، ولا يتم دعم تخطيطات عشوائية.

**هل يمكنني تضمين الشرائح المخفية في ناتج الكتيب؟**

نعم. فعل خيار `show_hidden_slides` في إعدادات التصدير للصيغة المستهدفة، مثل [PdfOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/htmloptions/), أو [TiffOptions](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/tiffoptions/).