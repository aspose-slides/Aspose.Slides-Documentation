---
title: تحرير مستندات PDF في C++
linktitle: تحرير PDF
type: docs
weight: 65
url: /ar/cpp/edit-pdf/
keywords:
- تحرير PDF
- استبدال نص PDF
- PDF إلى PPTX
- PPTX إلى PDF
- C++
- Aspose.Slides
description: "تحرير مستندات PDF في C++ عن طريق استيرادها إلى Aspose.Slides، استبدال النص، وحفظ العرض التقديمي المعدل مرة أخرى إلى PDF."
---
## **نظرة عامة**

Aspose.Slides for C++ تتيح لك تعديل محتوى PDF عن طريق استيراد صفحاته كشرائح، تعديل العرض التقديمي، ثم تصديره مرة أخرى إلى PDF. يوضح هذا المقال استبدال نص بسيط. يظل العرض التقديمي في الذاكرة، لذا فإن حفظ ملف PPTX وسيط أمر اختياري.

## **استبدال النص في ملف PDF**

استخدم [SlideCollection::AddFromPdf](https://reference.aspose.com/slides/ar/cpp/aspose.slides/slidecollection/addfrompdf/) لاستيراد الصفحات، [Presentation::ReplaceText](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/replacetext/) لتحديث النص، و[Presentation::Save](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/save/) لتصدير النتيجة.

يتوقع المثال التالي أن يحتوي `input.pdf` على الكلمة "`Draft`" كنص قابل للتحرير بعد الاستيراد. يستبدل هذه الكلمة بـ "`Final`" ويكتب الملف `edited.pdf`. مسح الشريحة الأولية قبل الاستيراد يمنع ظهور صفحة فارغة إضافية في الناتج. البحث يطابق الكلمات الكاملة بحالة الأحرف نفسها؛ `nullptr` يعني عدم الحاجة إلى استدعاء نتيجة.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

presentation->get_Slides()->AddFromPdf(u"input.pdf");

auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(true);
presentation->ReplaceText(u"Draft", u"Final", searchOptions, nullptr);

presentation->Save(u"edited.pdf", SaveFormat::Pdf);
presentation->Dispose();
```

لمزيد من الخيارات، انظر إلى [Search and Replace Text](/slides/ar/cpp/search-and-replace-text/) و[Convert PowerPoint to PDF](/slides/ar/cpp/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
يعمل استبدال النص على النص المستورد، وليس النص داخل الصور الممسوحة ضوئيًا. قد تؤثر عملية التحويل على التخطيط والتنسيق، لذا راجع الناتج خاصةً عندما يكون النص المستبدل أطول من الأصلي.
{{% /alert %}}

## **الأسئلة الشائعة**

**هل أحتاج إلى حفظ ملف PPTX قبل تصدير PDF؟**

لا. يمكنك تعديل وتصدير نفس العرض التقديمي في الذاكرة. احفظ نسخة PPTX فقط إذا كنت ترغب أيضًا في الاستمرار في تحريره في PowerPoint؛ راجع [Save Presentations](/slides/ar/cpp/save-presentation/).

**لماذا قد يبقى بعض النص غير متغير؟**

المثال يطابق الكلمة الكاملة "`Draft`" بالحروف الدقيقة. النص المستورد كصورة أو المقسم عبر إطارات نصية منفصلة قد لا يطابق البحث. تحقق من المحتوى المستورد واضبط البحث وفقًا لمستندك.