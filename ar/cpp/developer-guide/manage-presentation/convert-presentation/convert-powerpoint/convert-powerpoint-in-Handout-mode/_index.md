---
title: تحويل عروض PowerPoint إلى وضع Handout باستخدام C++
linktitle: وضع Handout
type: docs
weight: 150
url: /ar/cpp/convert-powerpoint-in-handout-mode/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- وضع Handout
- نسخة توزيع
- PPT
- PPTX
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تحويل العروض إلى نسخ توزيع في C++. ضبط عدد الشرائح لكل صفحة، الاحتفاظ بالملاحظات، التصدير إلى PDF أو صور باستخدام Aspose.Slides، مع مثال على الشيفرة. جرّبه مجانًا."
---
## **المقدمة**

توفر Aspose.Slides القدرة على تحويل العروض التقديمية إلى صيغ مختلفة، بما في ذلك إنشاء النسخ الورقية للطباعة في وضع Handout. يتيح لك هذا الوضع تكوين كيفية ظهور عدة شرائح على صفحة واحدة، مما يجعله مفيدًا للمؤتمرات والندوات وغيرها من الفعاليات. يمكنك تمكين هذا الوضع عن طريق استدعاء طريقة `set_SlidesLayoutOptions` في واجهات [IPdfOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/ipdfoptions/),[IRenderingOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/irenderingoptions/),[IHtmlOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/ihtmloptions/),و[ITiffOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/itiffoptions/) .

لتعيين أبعاد صفحة النسخة واتجاهها قبل التصدير، راجع [حجم صفحة الملاحظات](/slides/ar/cpp/notes-size/).

## **تصدير وضع Handout**

لتكوين وضع Handout، استخدم كائن [HandoutLayoutingOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/handoutlayoutingoptions/) الذي يحدد عدد الشرائح التي توضع على صفحة واحدة وغيرها من معلمات العرض.

فيما يلي مثال على الشيفرة يُظهر كيفية تحويل عرض تقديمي إلى PDF في وضع Handout.

```cpp
#include <DOM/Presentation.h>
#include <Export/HandoutLayoutingOptions.h>
#include <Export/HandoutType.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Load a presentation.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Set the export options.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 4 شرائح على صفحة واحدة أفقيًا
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // طباعة أرقام الشرائح
slidesLayoutOptions->set_PrintFrameSlide(true);                      // طباعة إطار حول الشرائح
slidesLayoutOptions->set_PrintComments(false);                       // بدون تعليقات

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="warning" %}} 
ضع في اعتبارك أن طريقة `set_SlidesLayoutOptions` متاحة فقط لبعض صيغ الإخراج، مثل PDF وHTML وTIFF، وعند التصيير كصور.
{{% /alert %}} 

## **الأسئلة المتكررة**

### ما هو الحد الأقصى لعدد صور الشرائح المصغرة لكل صفحة في وضع Handout؟

يدعم Aspose.Slides [الاستعدادات المسبقة](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/handouttype/) حتى 9 صور مصغرة لكل صفحة مع ترتيب أفقي أو عمودي: 1، 2، 3، 4 (أفقي/عمودي)، 6 (أفقي/عمودي)، و9 (أفقي/عمودي).

### هل يمكنني تحديد شبكة مخصصة، مثل 5 أو 8 شرائح لكل صفحة؟

لا. يتم التحكم في عدد وترتيب الصور المصغرة بدقة بواسطة تعداد [HandoutType](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/handouttype/); ولا تُدعم التخطيطات العشوائية.

### هل يمكنني تضمين الشرائح المخفية في مخرجات Handout؟

نعم. استخدم طريقة `set_ShowHiddenSlides` في إعدادات التصدير للصيغة المستهدفة، مثل [PdfOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/pdfoptions/),[HtmlOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/htmloptions/),أو [TiffOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/tiffoptions/).