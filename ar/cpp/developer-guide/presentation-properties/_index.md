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
- البيانات الوصفية للمستند
- تحرير البيانات الوصفية
- لغة التدقيق
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "تحكم في خصائص العرض التقديمي في Aspose.Slides for C++ وسهّل البحث والعلامة التجارية وسير العمل في ملفات PowerPoint و OpenDocument الخاصة بك."
---
## **مقدمة**

Aspose.Slides يدعم نوعين من خصائص المستند: **Built-in** و **Custom**. يمكن الوصول إلى كلا النوعين من الخصائص وإدارتهما بسهولة باستخدام Aspose.Slides API.

Aspose.Slides يسمح لك بالعمل مع خصائص مستند العرض التقديمي عبر واجهة [IDocumentProperties](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_document_properties). يتم إرجاع مثال لهذه الواجهة بواسطة الطريقة [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_documentproperties/). تُظهر الأمثلة التالية كيفية قراءة وتعديل وإدارة هذه الخصائص.

{{% alert color="info" title="Note" %}}

Please note that you cannot set values against the **Application** and **Producer** fields, because Aspose Ltd. and Aspose.Slides for C++ x.x.x will be displayed against these fields.

{{% /alert %}} 

## **إدارة خصائص العرض التقديمي**

Microsoft PowerPoint يوفر ميزة لإضافة بعض الخصائص إلى ملفات العرض التقديمي. تسمح هذه الخصائص بتخزين معلومات مفيدة junto مع المستندات (ملفات العرض). هناك نوعان من خصائص المستند كما يلي

- System Defined (Built-in) Properties
- User Defined (Custom) Properties

**Built-in** الخصائص تحتوي على معلومات عامة عن المستند مثل عنوان المستند، اسم المؤلف، إحصاءات المستند وما إلى ذلك. **Custom** الخصائص هي تلك التي يحددها المستخدمون كأزواج **Name/Value**، حيث يتم تعريف كل من الاسم والقيمة من قبل المستخدم. باستخدام Aspose.Slides for C++ يمكن للمطورين الوصول إلى قيم الخصائص المدمجة وكذلك الخصائص المخصصة وتعديلها. Microsoft PowerPoint 2007 يسمح بإدارة خصائص مستندات ملفات العرض. كل ما عليك هو النقر على أيقونة Office ثم اختيار **Prepare | Properties | Advanced Properties** في Microsoft PowerPoint 2007. بعد اختيار **Advanced Properties** سيظهر حوار يتيح لك إدارة خصائص مستند PowerPoint. في **Properties Dialog** يمكنك رؤية العديد من صفحات التبويب مثل **General, Summary, Statistics, Contents and Custom**. جميع هذه الصفحات تسمح بتكوين أنواع مختلفة من المعلومات المتعلقة بملفات PowerPoint. تبويب **Custom** يُستخدم لإدارة الخصائص المخصصة لملفات PowerPoint.

## **الوصول إلى الخصائص المدمجة**

هذه الخصائص التي يكشف عنها كائن **IDocumentProperties** تشمل: **Creator(Author)**، **Description**، **KeyWords** **Created** (Creation Date)، **Modified** Modification Date، **Printed** Last Print Date، **LastModifiedBy**، **Keywords**، **SharedDoc** (Is shared between different producers?)، **PresentationFormat**، **Subject** و **Title**

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **تعديل الخصائص المدمجة**

تعديل الخصائص المدمجة لملفات العرض سهل كالوصول إليها. يمكنك ببساطة تعيين قيمة نصية لأي خاصية تريدها وسيتم تعديل قيمة الخاصية. في المثال أدناه، أظهرنا كيفية تعديل خصائص المستند المدمجة لملف العرض.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **إضافة خصائص عرض تقديمي مخصصة**

Aspose.Slides for C++ يسمح أيضاً للمطورين بإضافة القيم المخصصة لخصائص مستند العرض. المثال أدناه يوضح كيفية تعيين الخصائص المخصصة لعرض تقديمي.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// إنشاء فئة Presentation
// الحصول على خصائص المستند
// إضافة خصائص مخصصة
// الحصول على اسم الخاصية في فهرس معين
// إزالة الخاصية المحددة
// حفظ العرض التقديمي
auto presentation = System::MakeObject<Presentation>();

// Getting Document Properties
auto documentProperties = presentation->get_DocumentProperties();

// Adding Custom properties
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// Getting property name at particular index
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// Removing selected property
documentProperties->RemoveCustomProperty(getPropertyName);

// Saving presentation
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **الوصول إلى وتعديل الخصائص المخصصة**

Aspose.Slides for C++ يسمح أيضاً للمطورين بالوصول إلى قيم الخصائص المخصصة. المثال أدناه يوضح كيف يمكنك الوصول إلى جميع هذه الخصائص المخصصة وتعديلها لعرض تقديمي.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **تعيين لغة التدقيق**

Aspose.Slides يوفر خاصية [LanguageId](https://reference.aspose.com/slides/ar/cpp/aspose.slides/baseportionformat/set_languageid/) (المكشوفة عبر فئة [PortionFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/portionformat/)) لتسمح لك بتعيين لغة التدقيق لمستند PowerPoint. لغة التدقيق هي اللغة التي يتم فيها فحص الإملاء والقواعد في PowerPoint.

هذا الشيفرة C++ توضح لك كيفية تعيين لغة التدقيق لملف PowerPoint:

```c++
#include <DOM/AutoShape.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IFontData.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"sample.pptx");
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
// تحديد معرف لغة التدقيق

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **تعيين اللغة الافتراضية**

هذا الشيفرة C++ توضح لك كيفية تعيين اللغة الافتراضية لجميع شرائح PowerPoint:

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
using namespace Aspose::Slides;

System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// إضافة شكل مستطيل جديد مع نص
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// يفحص لغة الجزء الأول
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **مثال حي**

جرّب تطبيق [**Aspose.Slides Metadata**](https://products.aspose.app/slides/ar/metadata) على الإنترنت لترى كيفية العمل مع خصائص المستند عبر Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ar/metadata)

## **FAQ**

**How can I remove a built-in property from a presentation?**

الخصائص المدمجة جزء لا يتجزأ من العرض ولا يمكن إزالتها بالكامل. ومع ذلك، يمكنك إما تغيير قيمها أو تعيينها إلى فارغ إذا سمحت الخاصية بذلك.

**What happens if I add a custom property that already exists?**

إذا أضفت خاصية مخصصة موجودة بالفعل، سيتم استبدال قيمتها الحالية بالقيمة الجديدة. لا تحتاج إلى إزالة أو فحص الخاصية مسبقًا، حيث يقوم Aspose.Slides تلقائيًا بتحديث قيمة الخاصية.

**Can I access presentation properties without fully loading the presentation?**

نعم. استخدم [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) ثم [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) لقراءة بيانات المستند المخزنة دون إنشاء مثال [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/). راجع [Build a Lightweight Presentation Inventory](/slides/ar/cpp/examine-presentation/) للحصول على مثال تقارير كامل والقيود الخاصة بكل تنسيق.