---
title: تحويل عروض PowerPoint إلى وضع النشرة باستخدام C++
linktitle: وضع النشرة
type: docs
weight: 150
url: /ar/cpp/convert-powerpoint-in-Handout-mode/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- وضع النشرة
- نشرة
- PPT
- PPTX
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تحويل العروض إلى نشرات باستخدام C++. ضبط عدد الشرائح في الصفحة، الاحتفاظ بالملاحظات، تصدير إلى PDF أو صور مع Aspose.Slides، مع مثال على الشيفرة. جرّبه مجانًا."
---

## **تصدير وضع النشرة**

توفر Aspose.Slides القدرة على تحويل العروض التقديمية إلى تنسيقات مختلفة، بما في ذلك إنشاء نشرات للطباعة في وضع النشرة. يتيح لك هذا الوضع تكوين كيفية ظهور عدة شرائح على صفحة واحدة، مما يجعله مفيدًا للمؤتمرات والندوات وغيرها من الفعاليات. يمكنك تمكين هذا الوضع عن طريق تعيين طريقة `set_SlidesLayoutOptions` في واجهات [IPdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/ihtmloptions/), و[ITiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/itiffoptions/) .

لتكوين وضع النشرة، استخدم كائن [HandoutLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/handoutlayoutingoptions/) ، الذي يحدد عدد الشرائح التي توضع على صفحة واحدة ومعلمات العرض الأخرى.

فيما يلي مثال على الشيفرة يوضح كيفية تحويل عرض تقديمي إلى PDF في وضع النشرة.
```cpp
// تحميل عرض تقديمي.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// تعيين خيارات التصدير.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 4 شرائح في صفحة واحدة أفقياً
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // طباعة أرقام الشرائح
slidesLayoutOptions->set_PrintFrameSlide(true);                      // طباعة إطار حول الشرائح
slidesLayoutOptions->set_PrintComments(false);                       // لا تعليقات

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// تصدير العرض التقديمي إلى PDF باستخدام التخطيط المختار.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```


{{% alert color="warning" %}} 
ضع في اعتبارك أن طريقة `set_SlidesLayoutOptions` متاحة فقط لبعض تنسيقات الإخراج، مثل PDF وHTML وTIFF، وعند التصيير كصور.
{{% /alert %}} 

## **الأسئلة الشائعة**

**ما هو الحد الأقصى لعدد مصغرات الشرائح في كل صفحة في وضع النشرة؟**

يدعم Aspose.Slides [presets](https://reference.aspose.com/slides/cpp/aspose.slides.export/handouttype/) حتى 9 مصغرات لكل صفحة مع ترتيب أفقي أو عمودي: 1، 2، 3، 4 (أفقي/عمودي)، 6 (أفقي/عمودي)، و9 (أفقي/عمودي).

**هل يمكنني تعريف شبكة مخصصة، مثل 5 أو 8 شرائح لكل صفحة؟**

لا. يتم التحكم في عدد وترتيب المصغرات بدقة بواسطة تعداد [HandoutType](https://reference.aspose.com/slides/cpp/aspose.slides.export/handouttype/)؛ ولا يتم دعم التخطيطات العشوائية.

**هل يمكنني تضمين الشرائح المخفية في ناتج النشرة؟**

نعم. استخدم طريقة `set_ShowHiddenSlides` في إعدادات التصدير للتنسيق المستهدف، مثل [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/htmloptions/), أو [TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/).