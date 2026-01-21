---
title: إدارة العلامات والبيانات المخصصة في العروض التقديمية باستخدام C++
linktitle: العلامات والبيانات المخصصة
type: docs
weight: 300
url: /ar/cpp/managing-tags-and-custom-data/
keywords:
- خصائص المستند
- علامة
- بيانات مخصصة
- إضافة علامة
- قيم أزواج
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعلم كيفية إضافة وقراءة وتحديث وإزالة العلامات والبيانات المخصصة في Aspose.Slides لـ C++، مع أمثلة لعروض PowerPoint وعروض OpenDocument."
---

## **تخزين البيانات في ملفات العرض**

ملفات PPTX—العناصر ذات الامتداد .pptx—تُخزن بتنسيق PresentationML، وهو جزء من مواصفة Office Open XML. يحدد تنسيق Office Open XML بنية البيانات الموجودة في العروض.

مع اعتبار *الشريحة* أحد عناصر العروض، يحتوي *جزء الشريحة* على محتوى شريحة واحدة. يُسمح لجزء الشريحة بوجود علاقات صريحة مع أجزاء متعددة—مثل العلامات المعرفة من قبل المستخدم—وفقًا لمعيار ISO/IEC 29500.

يمكن أن توجد البيانات المخصصة (المحددة لعرض تقديمي) أو المستخدم على شكل علامات ([ITagCollection](https://reference.aspose.com/slides/cpp/aspose.slides/itagcollection/)) وأجزاء XML مخصصة ([ICustomXmlPartCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icustomxmlpartcollection/)).
{{% alert color="primary" %}} 
العلامات هي أساسًا قيم أزواج سلسلة-مفتاح. 
{{% /alert %}} 

## **الحصول على قيم العلامات**

في الشرائح، تتطابق العلامة مع الخاصية IDocumentProperties.Keywords. يوضح هذا المثال البرمجي كيفية الحصول على قيمة علامة باستخدام Aspose.Slides لـ C++ لـ [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/):
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
System::String keywords = pres->get_DocumentProperties()->get_Keywords();
```


## **إضافة علامات إلى العروض التقديمية**

تتيح لك Aspose.Slides إضافة علامات إلى العروض التقديمية. عادةً ما تتكون العلامة من عنصرين:
- اسم الخاصية المخصصة - `MyTag` 
- قيمة الخاصية المخصصة - `My Tag Value`

إذا كنت بحاجة إلى تصنيف بعض العروض بناءً على قاعدة أو خاصية محددة، فقد تستفيد من إضافة علامات إلى تلك العروض. على سبيل المثال، إذا رغبت في تصنيف أو تجميع كل العروض من دول أمريكا الشمالية معًا، يمكنك إنشاء علامة "North American" ثم تعيين الدول ذات الصلة (الولايات المتحدة، المكسيك، وكندا) كقيم.

يعرض هذا المثال البرمجي كيفية إضافة علامة إلى [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) باستخدام Aspose.Slides لـ C++:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ITagCollection> tags = pres->get_CustomData()->get_Tags();
pres->get_CustomData()->get_Tags()->idx_set(u"MyTag", u"My Tag Value");
```


يمكن أيضًا تعيين علامات لـ [Slide](https://reference.aspose.com/slides/cpp/aspose.slides/slide/):
``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```


أو لأي شكل فردي [Shape](https://reference.aspose.com/slides/cpp/aspose.slides/shape/):
``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```


## **الأسئلة الشائعة**

**هل يمكنني إزالة جميع العلامات من عرض تقديمي أو شريحة أو شكل في عملية واحدة؟**

نعم. يدعم [tag collection](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/) عملية [clear](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/clear/) التي تحذف جميع أزواج المفتاح‑القيمة دفعة واحدة.

**كيف يمكن حذف علامة واحدة باسمها دون التكرار عبر المجموعة بأكملها؟**

استخدم عملية [Remove(name)](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/remove/) على [TagCollection](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/) لحذف العلامة باستخدام مفتاحها.

**كيف يمكنني استرجاع القائمة الكاملة لأسماء العلامات للتحليل أو الفلترة؟**

استخدم [GetNamesOfTags](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/getnamesoftags/) على [tag collection](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/); تُعيد مصفوفة بجميع أسماء العلامات.