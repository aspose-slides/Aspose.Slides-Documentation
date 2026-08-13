---
title: تحويل عروض PowerPoint إلى PDF مع الملاحظات في C++
linktitle: PowerPoint إلى PDF مع الملاحظات
type: docs
weight: 50
url: /ar/cpp/convert-powerpoint-to-pdf-with-notes/
keywords:
- تحويل PowerPoint
- تحويل العرض
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى PDF
- العرض إلى PDF
- الشريحة إلى PDF
- PPT إلى PDF
- PPTX إلى PDF
- حفظ العرض كـ PDF
- حفظ PPT كـ PDF
- حفظ PPTX كـ PDF
- تصدير PPT إلى PDF
- تصدير PPTX إلى PDF
- ملاحظات المتحدث
- PDF مع ملاحظات
- C++
- Aspose.Slides
description: "تحويل صيغ PPT و PPTX إلى PDF مع الملاحظات باستخدام Aspose.Slides للغة C++. الحفاظ على التخطيطات وملاحظات المتحدث لعروض تقديمية احترافية."
---
## **نظرة عامة**

في هذه المقالة، ستتعلم كيفية تحويل عروض PowerPoint إلى تنسيق PDF مع ملاحظات المتحدث باستخدام Aspose.Slides. سيغطي هذا الدليل الخطوات الضرورية ويقدم أمثلة على الشيفرة لمساعدتك في إتمام هذه المهمة بكفاءة. بنهاية هذه المقالة، ستكون قادرًا على:

- تنفيذ عملية التحويل لتحويل شرائح PowerPoint إلى مستندات PDF مع الحفاظ على ملاحظات المتحدث.
- تخصيص ملف PDF الناتج لضمان تضمين ملاحظات المتحدث وتنسيقها وفقًا لاحتياجاتك.

## **تحويل PowerPoint إلى PDF مع الملاحظات**

يمكن استخدام طريقة `Save` في فئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) لتحويل عرض PPT أو PPTX إلى PDF مع ملاحظات المتحدث. مع Aspose.Slides، تقوم ببساطة بتحميل العرض، وتكوين خيارات التخطيط باستخدام فئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/notescommentslayoutingoptions/) لتضمين ملاحظات المتحدث، ثم حفظ الملف كملف PDF. يوضح المقتطف التالي كيفية تحويل عرض توضيحي عينة إلى PDF في طريقة عرض شريحة الملاحظات.

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Configure PDF options for rendering speaker notes.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // عرض ملاحظات المتحدث أسفل الشريحة.
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Save the presentation to PDF with speaker notes.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="info" %}} 
قد ترغب في التحقق من أداة Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/ar/conversion). 
{{% /alert %}}