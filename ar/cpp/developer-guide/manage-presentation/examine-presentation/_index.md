---
title: استرجاع وتحديث معلومات العرض التقديمي في C++
linktitle: معلومات العرض التقديمي
type: docs
weight: 30
url: /ar/cpp/examine-presentation/
keywords:
- صيغة العرض التقديمي
- خصائص العرض التقديمي
- خصائص المستند
- الحصول على الخصائص
- قراءة الخصائص
- تغيير الخصائص
- تعديل الخصائص
- تحديث الخصائص
- فحص PPTX
- فحص PPT
- فحص ODP
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "استكشف الشرائح والهيكل والبيانات التعريفية في عروض PowerPoint وOpenDocument التقديمية باستخدام C++ للحصول على رؤى أسرع وتدقيق محتوى أكثر ذكاءً."
---
## **نظرة عامة**

توضح هذه المقالة كيفية فحص معلومات العرض التقديمي في Aspose.Slides. تشرح كيفية تحديد الصيغة الحالية للعرض دون تحميل الملف بالكامل، قراءة خصائص المستند الخاصة به، وتحديث تلك الخصائص عند الحاجة.

تستند الأمثلة إلى واجهات برمجة التطبيقات [PresentationInfo](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentationinfo/) و[DocumentProperties](https://reference.aspose.com/slides/ar/cpp/aspose.slides/documentproperties/) وتظهر عمليات نمطية للعمل مع بيانات التعريف للعرض التقديمي.

## **التحقق من صيغة العرض التقديمي**

قبل العمل على عرض تقديمي، قد ترغب في معرفة الصيغة (PPT، PPTX، ODP، وغيرها) التي يوجد بها العرض في الوقت الحالي.

يمكنك التحقق من صيغة العرض دون تحميله. راجع هذا الكود C++:

``` cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
// PPTX
Console::WriteLine(ObjectExt::ToString(info->get_LoadFormat()));

auto info2 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.ppt");
// PPT
Console::WriteLine(ObjectExt::ToString(info2->get_LoadFormat()));

auto info3 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.odp");
// ODP
Console::WriteLine(ObjectExt::ToString(info3->get_LoadFormat()));
```

## **الحصول على خصائص العرض التقديمي**

يظهر هذا الكود C++ كيفية الحصول على خصائص العرض (معلومات حول العرض التقديمي):

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// .. 
```

## **تحديث خصائص العرض التقديمي**

توفر Aspose.Slides طريقة [PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentationinfo/updatedocumentproperties/) التي تسمح بإجراء تغييرات على خصائص العرض.

لنفترض أن لدينا عرض PowerPoint يحتوي على خصائص المستند الموضحة أدناه.

![خصائص المستند الأصلية لعرض PowerPoint](input_properties.png)

يظهر مثال الكود هذا كيفية تعديل بعض خصائص العرض:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/date_time.h>
using namespace Aspose::Slides;
using namespace System;

auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"My title");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```

تظهر نتائج تغيير خصائص المستند أدناه.

![خصائص المستند المعدلة لعرض PowerPoint](output_properties.png)

## **روابط مفيدة**

للحصول على مزيد من المعلومات حول العرض التقديمي وسماته الأمنية، قد تجد هذه الروابط مفيدة:

- [Password-Protect Presentations](/slides/ar/cpp/password-protected-presentation/)
- [Write-Protect Presentations](/slides/ar/cpp/write-protected-presentation/)

## **الأسئلة الشائعة**

**كيف يمكنني التحقق مما إذا كانت الخطوط مدمجة وما هي تلك الخطوط؟**

ابحث عن معلومات [embedded-font](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsmanager/getembeddedfonts/) على مستوى العرض، ثم قارن تلك الإدخالات مع مجموعة [الخطوط المستخدمة فعليًا عبر المحتوى](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsmanager/getfonts/) لتحديد الخطوط الحرجة للعرض.

**كيف أستطيع بسرعة معرفة ما إذا كان الملف يحتوي على شرائح مخفية وعددها؟**

قم بالتكرار عبر [slide collection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/slidecollection/) وتفحص علامة [visibility flag](https://reference.aspose.com/slides/ar/cpp/aspose.slides/slide/get_hidden/) لكل شريحة.

**هل يمكنني اكتشاف ما إذا كان يتم استخدام حجم وشكل شريحة مخصصين، وما إذا كانا يختلفان عن القيم الافتراضية؟**

نعم. قارن [slide size and orientation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_slidesize/) الحالي مع الإعدادات المسبقة القياسية؛ يساعد ذلك في توقع سلوك الطباعة والتصدير.

**هل هناك طريقة سريعة لرؤية ما إذا كانت المخططات تشير إلى مصادر بيانات خارجية؟**

نعم. استعرض جميع [charts](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/chart/)، وتحقق من [data source](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) الخاص بها، ولاحظ ما إذا كانت البيانات داخلية أو مرتبطة بروابط، بما في ذلك أي روابط مكسورة.

**كيف يمكنني تقييم الشرائح "الثقيلة" التي قد تبطئ عملية العرض أو تصدير PDF؟**

لكل شريحة، احصِ عدد الكائنات وابحث عن صور كبيرة، شفافية، ظلال، حركات، ووسائط متعددة؛ امنحها درجة تعقيد تقريبية لتحديد نقاط الأداء المحتملة.