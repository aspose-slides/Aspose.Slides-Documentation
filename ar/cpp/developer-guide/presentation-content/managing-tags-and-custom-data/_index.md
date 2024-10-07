---
title: إدارة العلامات والبيانات المخصصة
type: docs
weight: 300
url: /cpp/managing-tags-and-custom-data

---

## تخزين البيانات في ملفات العرض التقديمي

تُخزن ملفات PPTX - وهي العناصر ذات امتداد .pptx - في تنسيق PresentationML، الذي هو جزء من مواصفة Office Open XML. يحدد تنسيق Office Open XML الهيكل الخاص بالبيانات الموجودة في العروض التقديمية.

مع كون *الشريحة* واحدة من العناصر في العروض التقديمية، تحتوي *جزء الشريحة* على محتوى شريحة واحدة. يُسمح لجزء الشريحة بأن يكون له علاقات صريحة مع العديد من الأجزاء - مثل العلامات المعرفة من قبل المستخدم - التي تم تعريفها بموجب ISO/IEC 29500.

يمكن أن توجد البيانات المخصصة (الخاصة بعرض تقديمي) أو المستخدم كعلامات ([ITagCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_tag_collection)) وCustomXmlParts ([ICustomXmlPartCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_custom_xml_part_collection)).

{{% alert color="primary" %}}

تعتبر العلامات بشكل أساسي قيم أزواج من مفتاح نصي.

{{% /alert %}}

## الحصول على قيم العلامات

في الشرائح، تتوافق علامة مع خاصية IDocumentProperties.Keywords. يوضح هذا الرمز التجريبي كيفية الحصول على قيمة علامة باستخدام Aspose.Slides لـ C++ ل[عرض تقديمي](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation):

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
System::String keywords = pres->get_DocumentProperties()->get_Keywords();
```

## إضافة علامات إلى العروض التقديمية

تسمح لك Aspose.Slides بإضافة علامات إلى العروض التقديمية. تتكون العلامة عادةً من عنصرين:

- اسم خاصية مخصصة - `MyTag`
- قيمة الخاصية المخصصة - `My Tag Value`

إذا كنت بحاجة إلى تصنيف بعض العروض التقديمية بناءً على قاعدة أو خاصية معينة، فمن الممكن أن تستفيد من إضافة علامات إلى تلك العروض التقديمية. على سبيل المثال، إذا كنت ترغب في تصنيف أو تجميع جميع العروض التقديمية من دول أمريكا الشمالية، يمكنك إنشاء علامة أمريكا الشمالية ثم تعيين الدول ذات الصلة (الولايات المتحدة، المكسيك، وكندا) كقيم.

يوضح هذا الرمز التجريبي كيفية إضافة علامة إلى [عرض تقديمي](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) باستخدام Aspose.Slides لـ C++:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

System::SharedPtr<ITagCollection> tags = pres->get_CustomData()->get_Tags();
pres->get_CustomData()->get_Tags()->idx_set(u"MyTag", u"My Tag Value");
```

يمكن أيضًا تعيين العلامات لـ [شريحة](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide):

```cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
slide->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```

أو لأي [شكل](https://reference.aspose.com/slides/cpp/class/aspose.slides.shape) فردي:

```cpp
auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 50.0f);
shape->get_TextFrame()->set_Text(u"My text");
shape->get_CustomData()->get_Tags()->idx_set(u"tag", u"value");
```