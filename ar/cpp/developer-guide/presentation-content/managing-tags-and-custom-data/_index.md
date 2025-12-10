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
- قيم ثنائية
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تعلم كيفية إضافة وقراءة وتحديث وإزالة العلامات والبيانات المخصصة في Aspose.Slides للغة C++، مع أمثلة لعروض PowerPoint وعروض OpenDocument."
---

## **تخزين البيانات في ملفات العروض التقديمية**

تُخزن ملفات PPTX—العناصر ذات الامتداد .pptx—في تنسيق PresentationML، وهو جزء من مواصفة Office Open XML. يحدد تنسيق Office Open XML بنية البيانات الموجودة في العروض التقديمية. 

مع اعتبار *الشرائح* أحد عناصر العروض التقديمية، يحتوي *جزء الشريحة* على محتوى شريحة واحدة. يُسمح لجزء الشريحة بوجود علاقات صريحة مع العديد من الأجزاء—مثل العلامات المعرفة من قبل المستخدم—المحددة بواسطة ISO/IEC 29500. 

يمكن أن توجد البيانات المخصصة (المحددة لعرض تقديمي) أو المستخدم على شكل علامات ([ITagCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_tag_collection)) وCustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_custom_xml_part_collection)). 

{{% alert color="primary" %}} 
العلامات هي في الأساس قيم زوجية من السلسلة والمفتاح. 
{{% /alert %}} 

## **الحصول على قيم العلامات**

في الشرائح، تتطابق العلامة مع الخاصية IDocumentProperties.Keywords. يوضح لك هذا المثال البرمجي كيفية الحصول على قيمة العلامة باستخدام Aspose.Slides للغة C++ لفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation):
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
System::String keywords = pres->get_DocumentProperties()->get_Keywords();
```


## **إضافة علامات إلى العروض التقديمية**

يتيح لك Aspose.Slides إضافة علامات إلى العروض التقديمية. تتألف العلامة عادةً من عنصرين: 

- اسم الخاصية المخصصة - `MyTag` 
- قيمة الخاصية المخصصة - `My Tag Value`

إذا كنت بحاجة إلى تصنيف بعض العروض التقديمية بناءً على قاعدة أو خاصية معينة، فقد تستفيد من إضافة علامات إلى تلك العروض. على سبيل المثال، إذا أردت تصنيف أو جمع جميع العروض التقديمية من دول أمريكا الشمالية معًا، يمكنك إنشاء علامة أمريكا الشمالية ثم تعيين الدول ذات الصلة (الولايات المتحدة، المكسيك، وكندا) كقيم. 

يوضح لك هذا المثال البرمجي كيفية إضافة علامة إلى فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) باستخدام Aspose.Slides للغة C++:
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ITagCollection> tags = pres->get_CustomData()->get_Tags();
pres->get_CustomData()->get_Tags()->idx_set(u"MyTag", u"My Tag Value");
```


يمكن أيضًا تعيين العلامات لـ [Slide](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide):
``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```


أو أي [Shape](https://reference.aspose.com/slides/cpp/class/aspose.slides.shape) فردي:
``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```


## **الأسئلة المتكررة**

**هل يمكنني إزالة جميع العلامات من عرض تقديمي أو شريحة أو شكل في عملية واحدة؟**

نعم. تدعم [مجموعة العلامات](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/) عملية [clear](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/clear/) التي تحذف جميع أزواج المفتاح‑القيمة مرة واحدة.

**كيف أحذف علامة واحدة بالاسم دون التنقل عبر المجموعة بالكامل؟**

استخدم عملية [Remove(name)](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/remove/) على [TagCollection](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/) لحذف العلامة بمفتاحها.

**كيف يمكنني استرجاع القائمة الكاملة لأسماء العلامات للتحليلات أو التصفية؟**

استخدم [GetNamesOfTags](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/getnamesoftags/) على [مجموعة العلامات](https://reference.aspose.com/slides/cpp/aspose.slides/tagcollection/); تُرجع مصفوفةً تحتوي على جميع أسماء العلامات.