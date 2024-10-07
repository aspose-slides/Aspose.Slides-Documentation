---
title: فحص العرض التقديمي
type: docs
weight: 30
url: /python-net/examine-presentation/
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
- Python
description: "قراءة وتعديل خصائص العرض التقديمي لبرنامج PowerPoint باستخدام Python"
---

تسمح لك Aspose.Slides لبايثون عبر .NET بفحص عرض تقديمي لمعرفة خصائصه وفهم سلوكهم.

{{% alert title="معلومات" color="info" %}} 

تحتوي فئات [PresentationInfo](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/) و [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) على الخصائص والأساليب المستخدمة في العمليات هنا.

{{% /alert %}} 

## **تحقق من تنسيق العرض التقديمي**

قبل العمل على عرض تقديمي، قد ترغب في معرفة التنسيق (PPT، PPTX، ODP، وغيرها) الذي يتواجد فيه العرض التقديمي في الوقت الحالي.

يمكنك التحقق من تنسيق العرض التقديمي دون تحميله. راجع هذا الرمز بلغة بايثون:

```py
import aspose.slides as slides

info1 = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print(info1.load_format, info1.load_format == slides.LoadFormat.PPTX)

info2 = slides.PresentationFactory.instance.get_presentation_info("pres.odp")
print(info2.load_format, info2.load_format == slides.LoadFormat.ODP)

info3 = slides.PresentationFactory.instance.get_presentation_info("pres.ppt")
print(info3.load_format, info3.load_format == slides.LoadFormat.PPT)
```

## **الحصول على خصائص العرض التقديمي**

يوضح لك هذا الرمز بلغة بايثون كيفية الحصول على خصائص العرض التقديمي (معلومات حول العرض التقديمي):

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

قد ترغب في رؤية [الخصائص تحت فئة DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/#properties).

## **تحديث خصائص العرض التقديمي**

تقدم Aspose.Slides طريقة [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) التي تتيح لك إجراء تغييرات على خصائص العرض التقديمي.

دعنا نقول أن لدينا عرض تقديمي لبرنامج PowerPoint مع الخصائص الموضحة أدناه.

![الخصائص الأصلية لوثيقة العرض التقديمي لبرنامج PowerPoint](input_properties.png)

يوضح لك هذا المثال البرمجي كيفية تحرير بعض خصائص العرض التقديمي:

```py
file_name = "sample.pptx"

info = PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "عنواني"
properties.last_saved_time = datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

تظهر نتائج تغيير خصائص الوثيقة أدناه.

![خصائص الوثيقة المعدلة للعرض التقديمي لبرنامج PowerPoint](output_properties.png)

## **روابط مفيدة**

للحصول على مزيد من المعلومات حول العرض التقديمي وخصائصه الأمنية، قد تجد هذه الروابط مفيدة:

- [التحقق مما إذا كان العرض التقديمي مشفراً](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [التحقق مما إذا كان العرض التقديمي محميًا ضد الكتابة (للقراءة فقط)](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [التحقق مما إذا كان العرض التقديمي محميًا بكلمة مرور قبل تحميله](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [تأكيد كلمة المرور المستخدمة لحماية العرض التقديمي](https://docs.aspose.com/slides/python-net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).