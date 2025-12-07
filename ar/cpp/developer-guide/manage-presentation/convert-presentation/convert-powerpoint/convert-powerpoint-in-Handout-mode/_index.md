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
  - العرض التقديمي
  - C++
  - Aspose.Slides
description: "تحويل العروض إلى نشرات في C++. تعيين عدد الشرائح لكل صفحة، الحفاظ على الملاحظات، التصدير إلى PDF أو صور باستخدام Aspose.Slides، مع كود مثال. جرّبه مجانًا."
---

## **تصدير وضع النشرات**

توفر Aspose.Slides القدرة على تحويل العروض التقديمية إلى صيغ متعددة، بما في ذلك إنشاء نشرات للطباعة في وضع النشرة. يتيح لك هذا الوضع تكوين طريقة ظهور عدة شرائح على صفحة واحدة، مما يجعله مفيدًا للمؤتمرات والندوات وغيرها من الفعاليات. يمكنك تمكين هذا الوضع عن طريق تعيين الطريقة `set_SlidesLayoutOptions` في الواجهات [IPdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/ihtmloptions/), و[ITiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/itiffoptions/).

لتكوين وضع النشرة، استخدم الكائن [HandoutLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/handoutlayoutingoptions/) الذي يحدد عدد الشرائح الموضوعة على صفحة واحدة وغيرها من معلمات العرض.

في الأسفل مثال على الشيفرة يوضح كيفية تحويل عرض تقديمي إلى PDF في وضع النشرة.
```cpp
// تحميل عرض تقديمي.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// تعيين خيارات التصدير.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 4 شرائح على صفحة واحدة أفقياً
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
ضع في اعتبارك أن الطريقة `set_SlidesLayoutOptions` متاحة فقط لبعض صيغ الإخراج، مثل PDF، HTML، TIFF، وعند التصميم كصور.
{{% /alert %}} 

## **الأسئلة الشائعة**

**ما هو الحد الأقصى لعدد صور المصغرات للشرائح في الصفحة عند وضع النشرة؟**

يدعم Aspose.Slides [الإعدادات المسبقة](https://reference.aspose.com/slides/cpp/aspose.slides.export/handouttype/) حتى 9 صور مصغرة لكل صفحة مع ترتيب أفقي أو عمودي: 1، 2، 3، 4 (أفقي/عمودي)، 6 (أفقي/عمودي)، و9 (أفقي/عمودي).

**هل يمكنني تعريف شبكة مخصصة، مثل 5 أو 8 شرائح في الصفحة؟**

لا. يتم التحكم في عدد وترتيب الصور المصغرة بشكل صارم بواسطة تعداد [HandoutType](https://reference.aspose.com/slides/cpp/aspose.slides.export/handouttype/)؛ ولا تدعم التخطيطات العشوائية.

**هل يمكنني تضمين الشرائح المخفية في مخرج النشرة؟**

نعم. استخدم الطريقة `set_ShowHiddenSlides` في إعدادات التصدير للصيغة المستهدفة، مثل [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/htmloptions/), أو [TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/).