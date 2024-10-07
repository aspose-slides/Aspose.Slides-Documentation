---
title: فحص العرض التقديمي - واجهة برمجة تطبيقات PowerPoint C++
linktitle: فحص العرض التقديمي
type: docs
weight: 30
url: /cpp/examine-presentation/
keywords:
- PowerPoint
- العرض التقديمي
- تنسيق العرض التقديمي
- خصائص العرض التقديمي
- خصائص الوثيقة
- الحصول على الخصائص
- قراءة الخصائص
- تغيير الخصائص
- تعديل الخصائص
- PPTX
- PPT
- C++
description: "قراءة وتعديل خصائص العرض التقديمي في PowerPoint باستخدام C++"
---

تتيح لك Aspose.Slides لـ C++ فحص عرض تقديمي لمعرفة خصائصه وفهم سلوكه. 

{{% alert title="معلومات" color="info" %}}

تحتوي 🥃 [PresentationInfo](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation_info) و [DocumentProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.document_properties/) على الخصائص والأساليب المستخدمة في العمليات هنا.

{{% /alert %}} 

## **تحقق من تنسيق العرض التقديمي**

قبل العمل على عرض تقديمي، قد ترغب في معرفة التنسيق (PPT أو PPTX أو ODP أو غيرها) الذي يوجد به العرض التقديمي حاليًا.

يمكنك التحقق من تنسيق العرض التقديمي دون تحميل العرض التقديمي. راجع هذا الرمز C++:

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

يعرض لك هذا الرمز C++ كيفية الحصول على خصائص العرض التقديمي (معلومات حول العرض التقديمي):

``` cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// .. 
```

## **تحديث خصائص العرض التقديمي**

تقدم Aspose.Slides الطريقة [PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentationinfo/updatedocumentproperties/) التي تتيح لك إجراء تغييرات على خصائص العرض التقديمي.

لنقل لدينا عرض تقديمي في PowerPoint مع خصائص الوثيقة الموضحة أدناه.

![خصائص الوثيقة الأصلية للعرض التقديمي في PowerPoint](input_properties.png)

يوضح لك هذا المثال من الشيفرة كيفية تحرير بعض خصائص العرض التقديمي:

```cpp
auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"My title");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```

تظهر نتائج تغيير خصائص الوثيقة أدناه.

![خصائص الوثيقة المعدلة للعرض التقديمي في PowerPoint](output_properties.png)

## **روابط مفيدة**

للحصول على مزيد من المعلومات حول عرض تقديمي وخصائصه الأمنية، قد تجد هذه الروابط مفيدة:

- [التحقق من ما إذا كان العرض التقديمي مشفرًا](https://docs.aspose.com/slides/cpp/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [التحقق من ما إذا كان العرض التقديمي محميًا من الكتابة (للقراءة فقط)](https://docs.aspose.com/slides/cpp/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [التحقق من ما إذا كان العرض التقديمي محميًا بكلمة مرور قبل تحميله](https://docs.aspose.com/slides/cpp/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [تأكيد كلمة المرور المستخدمة لحماية العرض التقديمي](https://docs.aspose.com/slides/cpp/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).