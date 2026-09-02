---
title: تحويل عروض PowerPoint إلى XML في C++
linktitle: PowerPoint إلى XML
type: docs
weight: 145
url: /ar/cpp/convert-powerpoint-to-xml/
keywords:
- تحويل PowerPoint إلى XML
- تحويل العرض التقديمي إلى XML
- PPT إلى XML
- PPTX إلى XML
- ODP إلى XML
- عرض PowerPoint XML
- SaveFormat::Xml
- حفظ العرض التقديمي كـ XML
- تصدير العرض التقديمي إلى XML
- تدفق XML
- C++
- Aspose.Slides
description: "تحويل عروض PowerPoint وOpenDocument إلى ملفات أو تدفقات PowerPoint XML في C++ باستخدام Aspose.Slides for C++."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides for C++ تحويل العروض التقديمية PowerPoint إلى تنسيق PowerPoint XML Presentation. يكون ناتج XML مفيدًا عندما تحتاج إلى تمثيل نصي لفحص بنية العرض، أو استكشاف المشكلات في المستندات المولدة، أو مقارنة النواتج في الاختبارات التلقائية، أو الاندماج مع سير عمل يستهلك XML بدلاً من حزمة عرض.

استخدم طريقة [Presentation::Save](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/save/) مع القيمة `Xml` من تعداد [SaveFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/saveformat/). يمكنك كتابة النتيجة مباشرة إلى ملف أو إلى تدفق.

{{% alert color="info" title="Note" %}}
`SaveFormat::Xml` ينشئ PowerPoint XML Presentation. لا يستخرج أجزاء Office Open XML الفردية المخزنة داخل حزمة PPTX. إذا كنت تحتاج إلى أجزاء حزمة PPTX الدقيقة، مثل `ppt/presentation.xml` أو ملفات XML للشرائح الفردية، فافحص حزمة PPTX نفسها.
{{% /alert %}}

## **تحويل عرض تقديمي إلى ملف XML**

حمّل عرضًا تقديميًا مصدرًا باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/)، ثم مرّر مسار الإخراج و`SaveFormat::Xml` إلى طريقة [Presentation::Save](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/save/). يمكن أن يكون المصدر بأي تنسيق عرض مدعوم للتحميل، مثل PPT أو PPTX أو ODP.

المثال التالي يحول عرض PPTX إلى ملف XML:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.xml", SaveFormat::Xml);
presentation->Dispose();
```

## **كتابة ناتج XML إلى تدفق**

استخدم النسخة المت overloaded من [Presentation::Save](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/save/) عندما يجب بقاء XML في الذاكرة أو تمريره إلى مكوّن آخر، مثل خدمة ويب أو موفر تخزين أو خط أنابيب معالجة XML. المثال التالي يكتب النتيجة إلى [MemoryStream](https://reference.aspose.com/slides/ar/cpp/system.io/memorystream/) ويعيد تشغيله للقراءة اللاحقة:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto xmlStream = System::MakeObject<MemoryStream>();

presentation->Save(xmlStream, SaveFormat::Xml);
xmlStream->set_Position(0);
presentation->Dispose();

// تمرير xmlStream إلى المكوّن التالي في سير العمل.
```

## **مقارنة XML مع تنسيقات العرض والتصدير**

اختر تنسيق الإخراج حسب كيفية استخدام النتيجة:

| التنسيق | الناتج | الاستخدام النموذجي |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | عرض PowerPoint XML | فحص البنية، استكشاف الأخطاء، مقارنة النواتج المولدة، والتكامل القائم على XML |
| PPT (`.ppt`) | ملف عرض ثنائي قديم | التوافق مع سير عمل PowerPoint الأقدم |
| PPTX (`.pptx`) | حزمة Office Open XML تحتوي على عدة أجزاء | تحرير PowerPoint العادي وتبادل العروض |
| PDF أو TIFF | صفحات ثابتة أو صورة متعددة الصفحات | العرض، الطباعة، والأرشفة |
| PNG، JPEG أو SVG | تمثيل مرسوم لشريحة فردية | الصور المصغرة، المعاينات، وأصول الصورة |
| HTML أو HTML5 | ناتج عرض موجه للويب | عرض المتصفح والنشر على الويب |

على عكس PPT و PPTX، يهدف ناتج XML أساسًا إلى الفحص وسير العمل القائم على البيانات. وعلى عكس PDF و TIFF و HTML وتنسيقات صورة الشريحة، فهو يمثل بيانات العرض بدلاً من رسم الشرائح كصفحات أو أصول بصرية. جدول [التنسيقات الملف المدعومة](/slides/ar/cpp/supported-file-formats/) يسرد PowerPoint XML Presentation كتنسيق حفظ فقط، لذا لا تستخدمه عندما يتطلب سير العمل تحميل الملف المصدر مرة أخرى إلى Aspose.Slides للتحرير المستمر.

## **الأسئلة المتكررة**

**هل `SaveFormat::Xml` هو نفسه حفظ ملف PPTX؟**

لا. PPTX هو حزمة تحتوي على عدة أجزاء Office Open XML، بينما `SaveFormat::Xml` ينشئ ملف PowerPoint XML Presentation.

**هل يمكنني حفظ ناتج XML دون إنشاء ملف على القرص؟**

نعم. مرّر تدفقًا قابلًا للكتابة إلى [Presentation::Save](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/save/). على سبيل المثال، استخدم [MemoryStream](https://reference.aspose.com/slides/ar/cpp/system.io/memorystream/) للمعالجة في الذاكرة.

**هل يمكن لـ Aspose.Slides تحميل ملف XML المُصدّر مرة أخرى؟**

لا. يُدعم PowerPoint XML Presentation حاليًا للحفظ فقط وليس للتحميل. استخدم PPTX أو تنسيق عرض مدعوم آخر عندما يكون التحرير ذهابًا وإيابًا مطلوبًا.

**هل تحويل XML يرسم كل شريحة كصفحة أو صورة؟**

لا. تحويل XML يكتب بيانات عرض منظمة. استخدم PDF أو TIFF للناتج القائم على الصفحات، أو PNG و JPEG و SVG لصور الشرائح الفردية.