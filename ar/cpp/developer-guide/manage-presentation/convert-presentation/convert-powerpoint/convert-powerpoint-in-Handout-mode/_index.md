---
title: تحويل عروض PowerPoint في وضع النشرة باستخدام C++
linktitle: وضع النشرة
type: docs
weight: 150
url: /ar/cpp/convert-powerpoint-in-Handout-mode/
keywords:
- تحويل PowerPoint
- تحويل العرض
- وضع النشرة
- نشرة
- PPT
- PPTX
- PowerPoint
- عرض
- C++
- Aspose.Slides
description: "تحويل العروض إلى نشرات باستخدام C++. تعيين عدد الشرائح لكل صفحة، الحفاظ على الملاحظات، التصدير إلى PDF أو صور باستخدام Aspose.Slides، مع الشيفرة النموذجية. جربه مجاناً."
---

## **تصدير وضع النشرات**

توفر Aspose.Slides القدرة على تحويل العروض التقديمية إلى صيغ مختلفة، بما في ذلك إنشاء نشرة للطباعة في وضع النشرة. يتيح لك هذا الوضع تكوين عدد الشرائح التي تظهر على صفحة واحدة، مما يجعله مفيداً للمؤتمرات والندوات وغيرها من الفعاليات. يمكنك تمكين هذا الوضع عن طريق تعيين الطريقة `set_SlidesLayoutOptions` في واجهات [IPdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/ipdfoptions/)، [IRenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/irenderingoptions/)، [IHtmlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/ihtmloptions/)، و[ITiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/itiffoptions/).

لتكوين وضع النشرة، استخدم كائن [HandoutLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/handoutlayoutingoptions/)، الذي يحدد عدد الشرائح التي توضع على صفحة واحدة والمعلمات الأخرى للعرض.

فيما يلي مثال شفري يوضح كيفية تحويل عرض تقديمي إلى PDF في وضع النشرة.
```cpp
// تحميل عرض تقديمي.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// ضبط خيارات التصدير.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 4 شرائح على صفحة واحدة أفقياً
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // طباعة أرقام الشرائح
slidesLayoutOptions->set_PrintFrameSlide(true);                      // طباعة إطار حول الشرائح
slidesLayoutOptions->set_PrintComments(false);                       // لا تعليقات

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// تصدير العرض إلى PDF باستخدام التخطيط المختار.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```


{{% alert color="warning" %}} 
تذكر أن طريقة `set_SlidesLayoutOptions` متاحة فقط لبعض صيغ الإخراج، مثل PDF وHTML وTIFF، وعند التصيير كصور.
{{% /alert %}} 

## **FAQ**

**ما هو الحد الأقصى لعدد صور الشرائح المصغرة في الصفحة في وضع النشرة؟**

تدعم Aspose.Slides [الإعدادات المسبقة](https://reference.aspose.com/slides/cpp/aspose.slides.export/handouttype/) التي تصل إلى 9 صور مصغرة في الصفحة مع ترتيب أفقي أو عمودي: 1، 2، 3، 4 (أفقي/عمودي)، 6 (أفقي/عمودي)، و9 (أفقي/عمودي).

**هل يمكنني تعريف شبكة مخصصة، مثل 5 أو 8 شرائح في الصفحة؟**

لا. عدد وترتيب الصور المصغرة يتحكم فيه تماماً تعداد [HandoutType](https://reference.aspose.com/slides/cpp/aspose.slides.export/handouttype/)، ولا تدعم التخطيطات العشوائية.

**هل يمكن تضمين الشرائح المخفية في ناتج النشرة؟**

نعم. استخدم الطريقة `set_ShowHiddenSlides` في إعدادات التصدير للصيغة المستهدفة، مثل [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/)، [HtmlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/htmloptions/)، أو [TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/).