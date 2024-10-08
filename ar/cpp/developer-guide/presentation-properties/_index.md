---
title: خصائص العرض
type: docs
weight: 70
url: /ar/cpp/presentation-properties/
---

## **الوصول إلى خصائص العرض**
كما ذكرنا سابقًا أن Aspose.Slides لـ C++ يدعم نوعين من خصائص الوثائق، وهما **مضمنة** و **مخصصة**. لذلك، يمكن للمطورين الوصول إلى كلا النوعين من الخصائص باستخدام واجهة برمجة التطبيقات Aspose.Slides لـ C++. يوفر Aspose.Slides لـ C++ فئة [IDocumentProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_document_properties) التي تمثل خصائص الوثيقة المرتبطة بملف العرض من خلال طريقة [Presentation::get_DocumentProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a40a03eb17a9904ff80063f6df714c402). يمكن للمطورين استخدام طريقة [get_DocumentProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a40a03eb17a9904ff80063f6df714c402) المعروضة بواسطة كائن **Presentation** للوصول إلى خصائص الوثيقة لملفات العرض كما هو موضح أدناه:

{{% alert color="primary" %}} 

يرجى ملاحظة أنه لا يمكنك تعيين قيم ضد الحقول **Application** و **Producer**، لأن Aspose Ltd. و Aspose.Slides لـ C++ x.x.x ستظهر ضد هذه الحقول.

{{% /alert %}} 

يقدم Microsoft PowerPoint ميزة إضافة بعض الخصائص إلى ملفات العرض. تسمح هذه الخصائص الوثائق بتخزين بعض المعلومات المفيدة مع الوثائق (ملفات العرض). هناك نوعان من خصائص الوثائق كما يلي

- خصائص معرفة من النظام (مضمنة)
- خصائص معرفة من قبل المستخدم (مخصصة)

تحتوي الخصائص **المضمنة** على معلومات عامة حول الوثيقة مثل عنوان الوثيقة، اسم المؤلف، إحصائيات الوثيقة، وما إلى ذلك. الخصائص **المخصصة** هي تلك التي يتم تحديدها من قبل المستخدمين كأزواج **اسم/قيمة**، حيث يتم تعريف كل من الاسم والقيمة بواسطة المستخدم. باستخدام Aspose.Slides لـ C++، يمكن للمطورين الوصول إلى وتعديل قيم الخصائص المضمنة بالإضافة إلى الخصائص المخصصة. يسمح Microsoft PowerPoint 2007 بإدارة خصائص الوثيقة لملفات العرض. كل ما عليك فعله هو النقر على رمز Office ثم اختيار عنصر القائمة **إعداد | خصائص | خصائص متقدمة** في Microsoft PowerPoint 2007. بعد اختيار عنصر القائمة **خصائص متقدمة**، ستظهر مربع حوار يتيح لك إدارة خصائص الوثيقة لملف PowerPoint. في **مربع الحوار الخاص بالخصائص**، يمكنك رؤية العديد من صفحات التبويب مثل **عام، ملخص، إحصائيات، محتوى ومخصص**. تسمح جميع هذه الصفحات بتكوين أنواع مختلفة من المعلومات المتعلقة بملفات PowerPoint. تُستخدم علامة التبويب **مخصص** لإدارة الخصائص المخصصة لملفات PowerPoint.

## **الوصول إلى الخصائص المضمنة**
تشمل هذه الخصائص كما هو موضح بواسطة كائن **IDocumentProperties**: **Creator(Author)**، **Description**، **KeyWords**، **Created** (تاريخ الإنشاء)، **Modified** (تاريخ التعديل)، **Printed** (تاريخ الطباعة الأخير)، **LastModifiedBy**، **Keywords**، **SharedDoc** (هل يتم مشاركتها بين منتجين مختلفين؟)، **PresentationFormat**، **Subject** و **Title**

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}
## **تعديل الخصائص المضمنة**
تعديل الخصائص المضمنة لملفات العرض سهل كما هو الوصول إليها. يمكنك ببساطة تعيين قيمة نصية لأي خاصية مرغوبة وستتغير قيمة الخاصية. في المثال الموضح أدناه، قمنا بعرض كيفية تعديل الخصائص المضمنة لملف العرض.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **إضافة خصائص عرض مخصصة**
تسمح Aspose.Slides لـ C++ أيضًا للمطورين بإضافة قيم مخصصة لخصائص وثيقة العروض. تم إعطاء مثال أدناه يوضح كيفية تعيين الخصائص المخصصة لعرض ما.

```cpp
// إنشاء كائن من فئة Presentation
auto presentation = System::MakeObject<Presentation>();

// الحصول على خصائص الوثيقة
auto documentProperties = presentation->get_DocumentProperties();

// إضافة الخصائص المخصصة
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// الحصول على اسم الخاصية في فهرس معين
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// إزالة الخاصية المحددة
documentProperties->RemoveCustomProperty(getPropertyName);

// حفظ العرض
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **الوصول إلى وتعديل خصائص العرض المخصصة**
تتيح Aspose.Slides لـ C++ أيضًا للمطورين الوصول إلى قيم الخصائص المخصصة. يوجد مثال أدناه يوضح كيفية الوصول إلى وتعديل جميع هذه الخصائص المخصصة لعرض ما.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **التحقق مما إذا كان تم تعديل العرض أو إنشاؤه**
تقدم Aspose.Slides لـ C++ ميزة للتحقق مما إذا كان قد تم تعديل العرض أو إنشاؤه. يوجد مثال أدناه يوضح كيفية التحقق مما إذا كان العرض قد تم إنشاؤه أو تعديله.

```cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"props.pptx");

auto props = info->ReadDocumentProperties();

String app = props->get_NameOfApplication();
String ver = props->get_AppVersion();
```

## **تعيين لغة التدقيق**

تقدم Aspose.Slides خاصية [LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) (المعروضة بواسطة فئة [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/)) لتسمح لك بتعيين لغة التدقيق لوثيقة PowerPoint. لغة التدقيق هي اللغة التي يتم التحقق من تهجئتها وقواعدها في PowerPoint.

يوضح هذا الكود C++ كيفية تعيين لغة التدقيق لوثيقة PowerPoint:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(pptxFileName);
System::SharedPtr<AutoShape> autoShape = System::ExplicitCast<AutoShape>(pres->get_Slide(0)->get_Shape(0));

System::SharedPtr<IParagraph> paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
System::SharedPtr<IPortionCollection> portions = paragraph->get_Portions();
portions->Clear();

System::SharedPtr<Portion> newPortion = System::MakeObject<Portion>();

System::SharedPtr<IFontData> font = System::MakeObject<FontData>(u"SimSun");
System::SharedPtr<IPortionFormat> portionFormat = newPortion->get_PortionFormat();
portionFormat->set_ComplexScriptFont(font);
portionFormat->set_EastAsianFont(font);
portionFormat->set_LatinFont(font);

portionFormat->set_LanguageId(u"zh-CN");
// تعيين Id للغة التدقيق

newPortion->set_Text(u"1۔");
portions->Add(newPortion);
```

## **تعيين اللغة الافتراضية**

يوضح هذا الكود C++ كيفية تعيين اللغة الافتراضية لعرض PowerPoint بالكامل:

```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// إضافة شكل مستطيل جديد مع نص
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"نص جديد");

// التحقق من لغة الجزء الأول
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```