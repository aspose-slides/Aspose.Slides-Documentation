---
title: إدارة العلامات والبيانات المخصصة في العروض باستخدام C++
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
description: "تعلم كيفية إضافة، قراءة، تحديث وإزالة العلامات والبيانات المخصصة في Aspose.Slides للغة C++، مع أمثلة لعروض PowerPoint وOpenDocument."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية عمل Aspose.Slides مع العلامات والبيانات المخصصة في عروض PowerPoint. توضح بإيجاز كيفية تخزين البيانات في ملفات PPTX، وتلاحظ أن البيانات الخاصة بالعرض يمكن أن توجد كعلامات وأجزاء XML مخصصة، وتصف العلامات كأزواج سلسلة‑قيمة.

كما تظهر كيفية قراءة قيم العلامات وكيفية إضافة العلامات إلى عرض تقديمي أو شريحة فردية أو شكل. بالإضافة إلى ذلك، تغطي المقالة مهام إدارة العلامات الشائعة مثل مسح جميع العلامات، إزالة علامة وفقًا للاسم، واسترجاع قائمة بأسماء العلامات.

## **تخزين البيانات في ملفات العرض**

ملفات PPTX—العناصر ذات امتداد .pptx—مخزنة بتنسيق PresentationML، وهو جزء من مواصفة Office Open XML. يُعرّف تنسيق Office Open XML بنية البيانات الموجودة في العروض التقديمية.

مع اعتبار *الشريحة* أحد عناصر العروض، يحتوي *جزء الشريحة* على محتوى شريحة واحدة. يُسمح لجزء الشريحة بوجود علاقات صريحة مع العديد من الأجزاء—مثل العلامات المعرّفة من قبل المستخدم—المحددة في ISO/IEC 29500.

يمكن للبيانات المخصصة (المحددة لعرض تقديمي) أو للمستخدم أن تكون كعلامات ([ITagCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/itagcollection/)) وCustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icustomxmlpartcollection/)).

{{% alert color="primary" %}} 
العلامات هي أساسًا أزواج قيمة‑مفتاح من السلاسل. 
{{% /alert %}} 

## **الحصول على قيم العلامات**

في الشرائح، تتطابق العلامة مع الخاصية IDocumentProperties.Keywords. يوضح هذا الشيفرة النموذجية كيفية الحصول على قيمة علامة باستخدام Aspose.Slides للغة C++ لـ [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/):

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
System::String keywords = pres->get_DocumentProperties()->get_Keywords();
```

## **إضافة العلامات إلى العروض التقديمية**

يتيح Aspose.Slides لك إضافة علامات إلى العروض التقديمية. تتكون العلامة عادةً من عنصرين:

- اسم الخاصية المخصصة - `MyTag` 
- قيمة الخاصية المخصصة - `My Tag Value`

إذا كنت بحاجة إلى تصنيف بعض العروض بناءً على قاعدة أو خاصية محددة، فقد تستفيد من إضافة علامات إلى تلك العروض. على سبيل المثال، إذا أردت تجميع جميع العروض من دول أمريكا الشمالية معًا، يمكنك إنشاء علامة "North American" ثم تعيين الدول ذات الصلة (الولايات المتحدة، المكسيك، وكندا) كقيم.

يوضح هذا الشيفرة النموذجية كيفية إضافة علامة إلى [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) باستخدام Aspose.Slides للغة C++:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ITagCollection> tags = pres->get_CustomData()->get_Tags();
pres->get_CustomData()->get_Tags()->idx_set(u"MyTag", u"My Tag Value");
```

يمكن أيضًا ضبط العلامات لـ [Slide](https://reference.aspose.com/slides/ar/cpp/aspose.slides/slide/):

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

أو لأي [Shape](https://reference.aspose.com/slides/ar/cpp/aspose.slides/shape/) فردي:

``` cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

### **القيود**

العلامات التي تُضاف عبر مجموعة العلامات للبيانات المخصصة باستخدام `get_CustomData()->get_Tags()` تُخزن فقط داخل ملف PowerPoint. إنها **غير** منقولة إلى بنية علامات PDF عندما يتم تصدير العرض إلى PDF. وبالتالي، لا يمكن استرجاع المعرّف المخصص المعين كعلامة من ملف PDF المعلم.

**Workaround**: يمكنك تخزين معرّف مخصص في **النص البديل** للكائن (على سبيل المثال، `shape->set_AlternativeText(u"MyId")`). بعد التصدير إلى PDF، قد يظهر النص البديل في بنية علامات PDF.

## **الأسئلة المتكررة**

**هل يمكنني إزالة جميع العلامات من عرض تقديمي أو شريحة أو شكل في عملية واحدة؟**

نعم. تدعم [tag collection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/tagcollection/) عملية [clear](https://reference.aspose.com/slides/ar/cpp/aspose.slides/tagcollection/clear/) التي تمسح جميع أزواج المفتاح‑القيمة مرة واحدة.

**كيف يمكنني حذف علامة واحدة بناءً على اسمها دون التنقل عبر المجموعة بأكملها؟**

استخدم عملية [Remove(name)](https://reference.aspose.com/slides/ar/cpp/aspose.slides/tagcollection/remove/) على [TagCollection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/tagcollection/) لحذف العلامة باستخدام مفتاحها.

**كيف يمكنني استرجاع القائمة الكاملة لأسماء العلامات للتحليل أو التصفية؟**

استخدم [GetNamesOfTags](https://reference.aspose.com/slides/ar/cpp/aspose.slides/tagcollection/getnamesoftags/) على [tag collection](https://reference.aspose.com/slides/ar/cpp/aspose.slides/tagcollection/)؛ تُعيد مصفوفة بجميع أسماء العلامات.