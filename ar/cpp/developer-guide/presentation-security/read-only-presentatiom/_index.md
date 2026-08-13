---
title: حفظ العروض التقديمية في وضع القراءة فقط باستخدام C++
linktitle: عرض تقديمي للقراءة فقط
type: docs
weight: 30
url: /ar/cpp/read-only-presentation/
keywords:
- قراءة فقط
- حماية العرض التقديمي
- منع التعديل
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "تحميل وحفظ ملفات PowerPoint (PPT, PPTX) في وضع القراءة فقط باستخدام Aspose.Slides للـ C++، مما يتيح معاينات دقيقة للشرائح دون تعديل عروضك التقديمية."
---
## **المقدمة**

في PowerPoint 2019، قامت مايكروسوفت بتقديم إعداد **Always Open Read-Only** كأحد الخيارات التي يمكن للمستخدمين استخدامها لحماية عروضهم التقديمية. قد ترغب في استخدام هذا الإعداد للقراءة فقط لحماية عرض تقديمي عندما

- تريد منع التعديلات العرضية والحفاظ على محتوى العرض التقديمي آمنًا.
- تريد تنبيه الأشخاص إلى أن العرض التقديمي الذي قدمته هو النسخة النهائية.

بعد اختيارك لخيار **Always Open Read-Only** لعرض تقديمي، عندما يفتح المستخدمون العرض، يرون توصية **Read-Only** وقد يرون رسالة بهذا الشكل: *لمنع التغييرات العرضية، قام المؤلف بتعيين هذا الملف للفتح كقراءة فقط.*

توصية **Read-Only** هي وسيلة بسيطة لكنها فعالة لتثبيط التحرير لأن المستخدمين يجب أن يقوموا بإجراء لإزالتها قبل أن يُسمح لهم بتحرير العرض التقديمي. إذا كنت لا تريد أن يقوم المستخدمون بإجراء تغييرات على العرض وتريد إبلاغهم بذلك بطريقة مهذبة، فإن توصية **Read-Only** قد تكون خيارًا جيدًا لك.

> إذا تم فتح عرض تقديمي مع حماية **Read-Only** في نسخة أقدم من Microsoft PowerPoint—التي لا تدعم الوظيفة التي تم تقديمها مؤخرًا—تُتجاهل توصية **Read-Only** (يُفتح العرض بطريقة طبيعية).

## **تطبيق وضع القراءة فقط**

Aspose.Slides for C++ يتيح لك تعيين عرض تقديمي إلى **Read-Only**، مما يعني أن المستخدمين (بعد فتحهم للعرض) يرون توصية **Read-Only**. يُظهر لك هذا المثال البرمجي كيفية تعيين عرض تقديمي إلى **Read-Only** في C++ باستخدام Aspose.Slides:

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
pres->get_ProtectionManager()->set_ReadOnlyRecommended(true);
pres->Save(u"ReadOnlyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert color="info" %}} 

**ملاحظة**: توصية **Read-Only** تهدف ببساطة إلى تثبيط التحرير أو إيقاف المستخدمين عن إجراء تغييرات عرضية على عرض PowerPoint. إذا قرر شخص مُتحمس—يعرف ما يفعله—تحرير عرضك، يمكنه بسهولة إزالة إعداد القراءة فقط. إذا كنت بحاجة ماسة لمنع التحرير غير المصرح به، فستكون أفضلية استخدام [حمايات أكثر صرامة تشمل التشفير وكلمات المرور](https://docs.aspose.com/slides/ar/cpp/password-protected-presentation/). 

{{% /alert %}} 

## **الأسئلة المتكررة**

### كيف يختلف 'Read-Only recommended' عن الحماية بكلمة مرور كاملة؟

'Read-Only recommended' يعرض فقط اقتراحًا لفتح الملف في وضع القراءة فقط ويسهل تجاوزه. [حماية كلمة المرور](/slides/ar/cpp/password-protected-presentation/) يقيّد فعليًا الفتح أو التحرير وهو مناسب عندما تحتاج إلى ضوابط أمان حقيقية.

### هل يمكن دمج 'Read-Only recommended' مع العلامات المائية لتثبيط التعديلات أكثر؟

نعم. يمكن إقران التوصية مع [العلامات المائية](/slides/ar/cpp/watermark/) كوسيلة بصرية لتثبيط التحرير؛ فهي آليات منفصلة وتعمل جيدًا معًا.

### هل يمكن للماكرو أو أداة خارجية تعديل الملف حتى عندما تكون التوصية مفعلة؟

نعم. التوصية لا تمنع التغييرات البرمجية. لمنع التعديلات الآلية، استخدم [كلمات المرور والتشفير](/slides/ar/cpp/password-protected-presentation/).

### كيف يرتبط 'Read-Only recommended' بالعلامات 'is encrypted' و 'is write protected'؟

إنها إشارات مختلفة. 'Read-Only recommended' هي مطالبة ناعمة واختيارية؛ [get_IsWriteProtected](https://reference.aspose.com/slides/ar/cpp/aspose.slides/protectionmanager/get_iswriteprotected/) و [get_IsEncrypted](https://reference.aspose.com/slides/ar/cpp/aspose.slides/protectionmanager/get_isencrypted/) تشير إلى قيود فعلية على الكتابة أو القراءة تعتمد على كلمات المرور أو التشفير.