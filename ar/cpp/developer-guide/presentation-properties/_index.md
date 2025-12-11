---
title: إدارة خصائص العرض التقديمي في C++
linktitle: خصائص العرض التقديمي
type: docs
weight: 70
url: /ar/cpp/presentation-properties/
keywords:
- خصائص PowerPoint
- خصائص العرض التقديمي
- خصائص المستند
- خصائص مدمجة
- خصائص مخصصة
- خصائص متقدمة
- إدارة الخصائص
- تعديل الخصائص
- بيانات تعريف المستند
- تحرير بيانات التعريف
- لغة التدقيق
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "تحكم في خصائص العرض التقديمي في Aspose.Slides للغة C++ وقم بتبسيط البحث والعلامة التجارية وتدفق العمل في ملفات PowerPoint وOpenDocument الخاصة بك."
---

## **الوصول إلى خصائص العرض التقديمي**

كما وصفنا سابقًا أن Aspose.Slides for C++ يدعم نوعين من خصائص المستند، وهما **Built-in** و **Custom**. لذلك يمكن للمطورين الوصول إلى كلا النوعين من الخصائص باستخدام API الخاص بـ Aspose.Slides for C++. يوفر Aspose.Slides for C++ فئة [IDocumentProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_document_properties) التي تمثل خصائص المستند المرتبطة بملف العرض التقديمي عبر طريقة [Presentation::get_DocumentProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a40a03eb17a9904ff80063f6df714c402). يمكن للمطورين استخدام طريقة [get_DocumentProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a40a03eb17a9904ff80063f6df714c402) التي ي exposeها كائن **Presentation** للوصول إلى خصائص المستند لملفات العرض التقديمي كما هو موضح أدناه:

{{% alert color="primary" %}} 
يرجى ملاحظة أنه لا يمكنك تعيين قيم للحقول **Application** و **Producer**، لأن Aspose Ltd. و Aspose.Slides for C++ x.x.x سيتم عرضهما في هذه الحقول.
{{% /alert %}} 

يقدم Microsoft PowerPoint ميزة لإضافة بعض الخصائص إلى ملفات العرض التقديمي. تسمح هذه الخصائص الوثائقية بتخزين بعض المعلومات المفيدة جنبًا إلى جنب مع المستندات (ملفات العرض التقديمي). هناك نوعان من الخصائص الوثائقية كما يلي

- خصائص معرفة بالنظام (Built-in)
- خصائص معرفة من قبل المستخدم (Custom)

**Built-in** تحتوي الخصائص على معلومات عامة حول المستند مثل عنوان المستند، اسم المؤلف، إحصائيات المستند وما إلى ذلك. الخصائص **Custom** هي تلك التي يحددها المستخدمون كأزواج **Name/Value**، حيث يتم تعريف كل من الاسم والقيمة من قبل المستخدم. باستخدام Aspose.Slides for C++، يمكن للمطورين الوصول إلى قيم الخصائص المدمجة وكذلك الخصائص المخصصة وتعديلها. يتيح Microsoft PowerPoint 2007 إدارة خصائص المستند لملفات العرض التقديمي. كل ما عليك فعله هو النقر على أيقونة Office ثم اختيار **Prepare | Properties | Advanced Properties** في قائمة Microsoft PowerPoint 2007. بعد تحديد عنصر القائمة **Advanced Properties**، سيظهر حوار يتيح لك إدارة خصائص المستند لملف PowerPoint. في **Properties Dialog**، يمكنك رؤية العديد من صفحات التبويب مثل **General, Summary, Statistics, Contents and Custom**. تتيح جميع صفحات التبويب هذه تكوين أنواع مختلفة من المعلومات المتعلقة بملفات PowerPoint. تُستخدم علامة التبويب **Custom** لإدارة الخصائص المخصصة لملفات PowerPoint.

## **الوصول إلى الخصائص المدمجة**

تشمل هذه الخصائص التي يُظهرها كائن **IDocumentProperties**: **Creator(Author)**، **Description**، **KeyWords**، **Created** (تاريخ الإنشاء)، **Modified** (تاريخ التعديل)، **Printed** (تاريخ آخر طباعة)، **LastModifiedBy**، **Keywords**، **SharedDoc** (هل هي مشتركة بين منتجين مختلفين؟)، **PresentationFormat**، **Subject** و **Title**.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **تعديل الخصائص المدمجة**

تعديل الخصائص المدمجة لملفات العرض التقديمي سهل مثل الوصول إليها. يمكنك ببساطة تعيين قيمة نصية لأي خاصية تريدها وسيتم تعديل قيمة الخاصية. في المثال أدناه، أوضحنا كيف يمكننا تعديل خصائص المستند المدمجة لملف العرض التقديمي.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **إضافة خصائص عرض تقديمي مخصصة**

كما يتيح Aspose.Slides for C++ للمطورين إضافة القيم المخصصة لخصائص مستند العرض التقديمي. يُظهر المثال أدناه كيفية تعيين الخصائص المخصصة لعرض تقديمي.
``` cpp
// إنشاء كائن من فئة Presentation
auto presentation = System::MakeObject<Presentation>();

// الحصول على خصائص المستند
auto documentProperties = presentation->get_DocumentProperties();

// إضافة خصائص مخصصة
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// الحصول على اسم الخاصية عند فهرس معين
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// إزالة الخاصية المحددة
documentProperties->RemoveCustomProperty(getPropertyName);

// حفظ العرض التقديمي
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```


## **الوصول إلى الخصائص المخصصة وتعديلها**

كما يتيح Aspose.Slides for C++ للمطورين الوصول إلى قيم الخصائص المخصصة. يُظهر المثال أدناه كيف يمكنك الوصول إلى جميع هذه الخصائص المخصصة وتعديلها لعرض تقديمي.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **تعيين لغة التدقيق**

توفر Aspose.Slides الخاصية [LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) (المُعرَّضة بواسطة الفئة [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/) ) للسماح لك بتعيين لغة التدقيق لمستند PowerPoint. لغة التدقيق هي اللغة التي يتم فيها فحص الإملاء والقواعد في PowerPoint.

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
// set the Id of a proofing language

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```


## **تعيين اللغة الافتراضية**

يُظهر هذا الكود C++ كيفية تعيين اللغة الافتراضية لكامل عرض PowerPoint.

```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// إضافة شكل مستطيل جديد مع نص
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// فحص لغة الجزء الأول
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```


## **مثال حي**

جرّب تطبيق الويب [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata) لمعرفة كيفية التعامل مع خصائص المستند عبر Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## ***الأسئلة الشائعة**

**كيف يمكنني إزالة خاصية مدمجة من عرض تقديمي؟**

الخصائص المدمجة جزء أساسي من العرض التقديمي ولا يمكن إزالتها بالكامل. ومع ذلك، يمكنك إما تغيير قيمها أو تعيينها كقيمة فارغة إذا سمحت الخاصية بذلك.

**ماذا يحدث إذا أضفت خاصية مخصصة موجودة مسبقًا؟**

إذا قمت بإضافة خاصية مخصصة موجودة مسبقًا، سيتم استبدال قيمتها الحالية بالقيمة الجديدة. لا تحتاج إلى إزالة الخاصية أو التحقق منها مسبقًا، حيث يقوم Aspose.Slides بتحديث قيمة الخاصية تلقائيًا.

**هل يمكنني الوصول إلى خصائص العرض التقديمي دون تحميل العرض بالكامل؟**

نعم، يمكنك الوصول إلى خصائص العرض التقديمي دون تحميله بالكامل باستخدام طريقة `GetPresentationInfo` من الفئة [PresentationFactory](https://reference.aspose.com/slides/cpp/aspose.slides/presentationfactory/). ثم استخدم طريقة `ReadDocumentProperties` المتوفرة في الواجهة [IPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/) لقراءة الخصائص بكفاءة، مما يوفر الذاكرة ويحسن الأداء.