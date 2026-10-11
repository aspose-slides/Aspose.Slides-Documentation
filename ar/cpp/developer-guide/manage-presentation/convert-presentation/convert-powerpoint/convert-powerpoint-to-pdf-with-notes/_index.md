---
title: تحويل عروض PowerPoint إلى PDF مع الملاحظات في C++
linktitle: PowerPoint إلى PDF مع الملاحظات
type: docs
weight: 50
url: /ar/cpp/convert-powerpoint-to-pdf-with-notes/
keywords:
- تحويل PowerPoint
- تحويل عرض تقديمي
- تحويل شريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى PDF
- عرض تقديمي إلى PDF
- شريحة إلى PDF
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
description: "تحويل صيغ PPT و PPTX إلى PDF مع الملاحظات باستخدام Aspose.Slides لـ C++. الحفاظ على التخطيطات وملاحظات المتحدث لعروض تقديمية احترافية."
---
## **نظرة عامة**

في هذه المقالة، ستتعلم كيفية تحويل عروض PowerPoint إلى تنسيق PDF مع ملاحظات المتحدث باستخدام Aspose.Slides. سيغطي هذا الدليل الخطوات اللازمة ويقدم أمثلة على الشيفرة لمساعدتك في إنجاز هذه المهمة بكفاءة. في نهاية هذه المقالة، ستكون قادرًا على:

- تنفيذ عملية التحويل لتحويل شرائح PowerPoint إلى مستندات PDF مع الحفاظ على ملاحظات المتحدث.
- تخصيص ملف PDF الناتج لضمان تضمين ملاحظات المتحدث وتنسيقها وفقًا لمتطلباتك.

لتعيين أبعاد صفحة الملاحظات والاتجاه قبل التصدير، راجع [حجم صفحة الملاحظات](/slides/ar/cpp/notes-size/).

## **تحويل PowerPoint إلى PDF مع الملاحظات**

يمكن استخدام طريقة `Save` في الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) لتحويل عرض PPT أو PPTX إلى PDF مع ملاحظات المتحدث. باستخدام Aspose.Slides، تقوم ببساطة بتحميل العرض، وتكوين خيارات التخطيط باستخدام الفئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/notescommentslayoutingoptions/) لتضمين ملاحظات المتحدث، ثم حفظ الملف كـ PDF. يوضح مقطع الشيفرة التالي كيفية تحويل عرض نمطي إلى PDF في وضع ملاحظات الشريحة.

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

// تكوين خيارات PDF لعرض ملاحظات المتحدث.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // عرض ملاحظات المتحدث أسفل الشريحة.
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// حفظ العرض تقديمي كـ PDF مع ملاحظات المتحدث.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="info" %}} 
قد ترغب في تجربة أداة Aspose [محول PowerPoint إلى PDF عبر الإنترنت](https://products.aspose.app/slides/ar/conversion).
{{% /alert %}}