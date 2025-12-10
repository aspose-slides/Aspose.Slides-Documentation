---
title: استرجاع وتحديث معلومات العرض التقديمي في C++
linktitle: معلومات العرض التقديمي
type: docs
weight: 30
url: /ar/cpp/examine-presentation/
keywords:
- تنسيق العرض التقديمي
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
description: "استكشف الشرائح والبنية والبيانات الوصفية في عروض PowerPoint وOpenDocument باستخدام C++ للحصول على رؤى أسرع وتدقيق محتوى أذكى."
---

تسمح لك مكتبة Aspose.Slides للغة C++ بفحص عرض تقديمي لمعرفة خصائصه وفهم سلوكه. 

{{% alert title="Info" color="info" %}}
تحتوي الفئات PresentationInfo و DocumentProperties على الخصائص والطرق المستخدمة في العمليات هنا.
{{% /alert %}} 

## **تحقق من تنسيق العرض التقديمي**

قبل الشروع في العمل على عرض تقديمي، قد ترغب في معرفة ما هو التنسيق (PPT، PPTX، ODP، وغيرها) الذي يقع فيه العرض في الوقت الحالي.

يمكنك التحقق من تنسيق العرض التقديمي دون تحميله. انظر هذا الكود C++:
``` cpp
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

يعرض لك هذا الكود C++ كيفية الحصول على خصائص العرض التقديمي (معلومات حول العرض):
``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// ..
```


## **تحديث خصائص العرض التقديمي**

توفر Aspose.Slides طريقة PresentationInfo::UpdateDocumentProperties التي تسمح لك بإجراء تغييرات على خصائص العرض التقديمي.

لنفترض أن لدينا عرض PowerPoint يحتوي على خصائص المستند الموضحة أدناه.

![Original document properties of the PowerPoint presentation](input_properties.png)

يعرض لك مثال الكود هذا كيفية تحرير بعض خصائص العرض التقديمي:
```cpp
auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"My title");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```


تظهر نتائج تغيير خصائص المستند أدناه.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **روابط مفيدة**

للحصول على مزيد من المعلومات حول عرض تقديمي وسمات الأمان الخاصة به، قد تجد هذه الروابط مفيدة:

- [التحقق مما إذا كان العرض التقديمي مشفرًا](https://docs.aspose.com/slides/cpp/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [التحقق مما إذا كان العرض التقديمي محميًا ضد الكتابة (للقراءة فقط)](https://docs.aspose.com/slides/cpp/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [التحقق مما إذا كان العرض التقديمي محميًا بكلمة مرور قبل تحميله](https://docs.aspose.com/slides/cpp/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [تأكيد كلمة المرور المستخدمة لحماية العرض التقديمي](https://docs.aspose.com/slides/cpp/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **الأسئلة المتكررة**

**كيف يمكنني التحقق مما إذا كانت الخطوط مضمَّنة وأيها؟**

ابحث عن معلومات الخطوط المضمَّنة على مستوى العرض التقديمي، ثم قارن تلك الإدخالات مع مجموعة الخطوط المستخدمة فعليًا عبر المحتوى لتحديد أي الخطوط ضرورية للعرض.

**كيف يمكنني بسرعة معرفة إذا كان الملف يحتوي على شرائح مخفية وكم عددها؟**

تجول عبر مجموعة الشرائح وتفحص علامة الرؤية لكل شريحة.

**هل يمكنني اكتشاف ما إذا تم استخدام حجم واتجاه شريحة مخصصين، وما إذا كانا يختلفان عن الإعدادات الافتراضية؟**

نعم. قارن حجم واتجاه الشريحة الحاليين مع الإعدادات المعيارية؛ يساعد ذلك في توقع السلوك عند الطباعة والتصدير.

**هل هناك طريقة سريعة لمعرفة ما إذا كانت المخططات تشير إلى مصادر بيانات خارجية؟**

نعم. استعرض جميع المخططات، تحقق من مصدر البيانات الخاص بهم، ودوّن ما إذا كانت البيانات داخلية أو مرتبطة بروابط، بما في ذلك أي روابط مكسورة.

**كيف يمكنني تقييم الشرائح "الثقيلة" التي قد تبطئ عملية العرض أو تصدير PDF؟**

لكل شريحة، احسب عدد الكائنات وابحث عن الصور الكبيرة، والشفافية، والظلال، والرسوم المتحركة، والوسائط المتعددة؛ ثم اعطِ درجة تعقيد تقريبية لتحديد النقاط المحتملة التي قد تؤثر على الأداء.