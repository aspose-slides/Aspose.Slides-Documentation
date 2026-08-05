---
title: تحويل عروض PowerPoint إلى وضع النشرة باستخدام C++
linktitle: وضع النشرة
type: docs
weight: 150
url: /ar/cpp/convert-powerpoint-in-handout-mode/
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
description: "تحويل العروض التقديمية إلى نشرات في C++. ضبط عدد الشرائح في كل صفحة، الاحتفاظ بالملاحظات، التصدير إلى PDF أو صور باستخدام Aspose.Slides، مع كود مثال. جرّبه مجانًا."
---
## **المقدمة**

توفر Aspose.Slides القدرة على تحويل العروض التقديمية إلى صيغ مختلفة، بما في ذلك إنشاء منشورات للطباعة في وضع النشرة. يتيح لك هذا الوضع تكوين كيفية ظهور عدة شرائح على صفحة واحدة، مما يجعله مفيدًا للمؤتمرات والندوات والفعاليات الأخرى. يمكنك تمكين هذا الوضع عن طريق تعيين طريقة `set_SlidesLayoutOptions` في واجهات [IPdfOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/ihtmloptions/), و[ITiffOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/itiffoptions/) .

## **تصدير وضع النشرة**

لتكوين وضع النشرة، استخدم كائن [HandoutLayoutingOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/handoutlayoutingoptions/) الذي يحدد عدد الشرائح الموضوعة على صفحة واحدة وغيرها من معلمات العرض.

فيما يلي مثال على الشيفرة يوضح كيفية تحويل عرض تقديمي إلى PDF في وضع النشرة.

```cpp
// تحميل عرض تقديمي.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Set the export options.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 4 شرائح على صفحة واحدة أفقياً
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // طباعة أرقام الشرائح
slidesLayoutOptions->set_PrintFrameSlide(true);                      // طباعة إطار حول الشرائح
slidesLayoutOptions->set_PrintComments(false);                       // لا تعليقات

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="warning" %}} 
ضع في اعتبارك أن طريقة `set_SlidesLayoutOptions` متاحة فقط لبعض صيغ الإخراج، مثل PDF وHTML وTIFF، وعند التصيير كصور.
{{% /alert %}} 

## **الأسئلة الشائعة**

**ما هو الحد الأقصى لعدد صور الشرائح المصغرة لكل صفحة في وضع النشرة؟**

يدعم Aspose.Slides [الإعدادات المسبقة](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/handouttype/) حتى 9 صور مصغرة لكل صفحة مع ترتيب أفقي أو عمودي: 1، 2، 3، 4 (أفقي/عمودي)، 6 (أفقي/عمودي)، و9 (أفقي/عمودي).

**هل يمكنني تحديد شبكة مخصصة، مثل 5 أو 8 شرائح لكل صفحة؟**

لا. يتم التحكم في عدد وترتيب الصور المصغرة بدقة بواسطة تعداد [HandoutType](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/handouttype/) ، ولا يتم دعم التخطيطات العشوائية.

**هل يمكنني تضمين الشرائح المخفية في مخرجات النشرة؟**

نعم. استخدم طريقة `set_ShowHiddenSlides` في إعدادات التصدير للصيغة المستهدفة، مثل [PdfOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/htmloptions/), أو [TiffOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/tiffoptions/).