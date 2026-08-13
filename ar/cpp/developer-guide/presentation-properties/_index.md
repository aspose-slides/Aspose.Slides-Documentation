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
- البيانات التعريفية للمستند
- تحرير البيانات التعريفية
- لغة التدقيق
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "تحكم في خصائص العرض التقديمي في Aspose.Slides للـ C++ وقم بتبسيط البحث والعلامة التجارية وسير العمل في ملفات PowerPoint و OpenDocument الخاصة بك."
---
## **المقدمة**

Aspose.Slides يدعم نوعين من خصائص المستند: **مدمجة** و **مخصصة**. يمكن الوصول إلى كل من هذين النوعين من الخصائص وإدارتها بسهولة باستخدام واجهة برمجة تطبيقات Aspose.Slides.

Aspose.Slides يتيح لك العمل مع خصائص مستند العرض التقديمي عبر واجهة [IDocumentProperties](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.i_document_properties). يتم إرجاع مثال من هذه الواجهة بواسطة الطريقة [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_documentproperties/). تُظهر الأمثلة التالية كيفية قراءة وتعديل وإدارة هذه الخصائص.

{{% alert color="info" %}} 
يرجى ملاحظة أنك لا تستطيع تعيين قيم لحقلي **Application** و **Producer**، لأن Aspose Ltd. و Aspose.Slides for C++ x.x.x سيتم عرضهما في هذين الحقلين.
{{% /alert %}} 

## **إدارة خصائص العرض التقديمي**

يوفر Microsoft PowerPoint ميزة إضافة بعض الخصائص إلى ملفات العروض التقديمية. تسمح هذه الخصائص الوثائقية بتخزين معلومات مفيدة مع المستندات (ملفات العروض). هناك نوعان من خصائص المستند كما يلي

- خصائص معرفة بالنظام (مدمجة)
- خصائص معرفة من قبل المستخدم (مخصصة)

الخصائص **المدمجة** تحتوي على معلومات عامة حول المستند مثل عنوان المستند، اسم المؤلف، إحصائيات المستند وما إلى ذلك. الخصائص **المخصصة** هي تلك التي يحددها المستخدم كأزواج **اسم/قيمة**، حيث يتم تعريف كل من الاسم والقيمة من قبل المستخدم. باستخدام Aspose.Slides for C++، يمكن للمطورين الوصول إلى قيم الخصائص المدمجة وتعديلها وكذلك الخصائص المخصصة. يسمح Microsoft PowerPoint 2007 بإدارة خصائص المستند لملفات العروض. كل ما عليك فعله هو النقر على أيقونة Office ثم اختيار **Prepare | Properties | Advanced Properties** في Microsoft PowerPoint 2007. بعد اختيار **Advanced Properties**، سيظهر حوار يتيح لك إدارة خصائص مستند ملف PowerPoint. في **Properties Dialog**، يمكنك رؤية عدة تبويبات مثل **General, Summary, Statistics, Contents and Custom**. تسمح جميع هذه التبويبات بتكوين أنواع مختلفة من المعلومات المتعلقة بملفات PowerPoint. يتم استخدام تبويب **Custom** لإدارة الخصائص المخصصة لملفات PowerPoint.

## **الوصول إلى الخصائص المدمجة**

تشمل الخصائص التي يعرضها كائن **IDocumentProperties** ما يلي: **Creator(Author)**، **Description**، **KeyWords**، **Created** (تاريخ الإنشاء)، **Modified** (تاريخ التعديل)، **Printed** (تاريخ الطباعة الأخير)، **LastModifiedBy**، **Keywords**، **SharedDoc** (هل تم مشاركة المستند بين منتجين مختلفين؟)، **PresentationFormat**، **Subject** و **Title**.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **تعديل الخصائص المدمجة**

تعديل الخصائص المدمجة لملفات العرض التقديمي سهل كما هو الوصول إليها. يمكنك ببساطة تعيين قيمة نصية لأي خاصية مرغوبة وستتم تعديل قيمة الخاصية. في المثال الموضح أدناه، أوضحنا كيفية تعديل خصائص المستند المدمجة لملف العرض التقديمي.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **إضافة خصائص عرض تقديمي مخصصة**

Aspose.Slides for C++ يتيح أيضًا للمطورين إضافة قيم مخصصة لخصائص مستند العرض التقديمي. المثال أدناه يوضح كيفية تعيين الخصائص المخصصة لعرض تقديمي.

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// إنشاء كائن من فئة Presentation
auto presentation = System::MakeObject<Presentation>();

// الحصول على خصائص المستند
auto documentProperties = presentation->get_DocumentProperties();

// إضافة خصائص مخصصة
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// الحصول على اسم الخاصية عند الفهرس المحدد
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// إزالة الخاصية المحددة
documentProperties->RemoveCustomProperty(getPropertyName);

// حفظ العرض التقديمي
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **الوصول إلى الخصائص المخصصة وتعديلها**

Aspose.Slides for C++ يتيح أيضًا للمطورين الوصول إلى قيم الخصائص المخصصة. المثال أدناه يوضح كيف يمكنك الوصول إلى جميع هذه الخصائص المخصصة لعرض تقديمي وتعديلها.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **تعيين لغة التدقيق**

Aspose.Slides يوفر الخاصية [LanguageId](https://reference.aspose.com/slides/ar/cpp/aspose.slides.baseportionformat/set_languageid/) (المعرّفة في فئة [PortionFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/portionformat/)) لتسمح لك بتعيين لغة التدقيق لوثيقة PowerPoint. لغة التدقيق هي اللغة التي يتم فيها فحص الإملاء والقواعد في PowerPoint.

يظهر هذا الكود C++ كيفية تعيين لغة التدقيق لوثيقة PowerPoint:

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
// تعيين معرف لغة التدقيق

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **تعيين اللغة الافتراضية**

يظهر هذا الكود C++ كيفية تعيين اللغة الافتراضية لكامل عرض تقديمي PowerPoint:

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

// يضيف شكل مستطيل جديد مع نص
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// يتحقق من لغة الجزء الأول
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **مثال حي**

جرّب التطبيق الإلكتروني [**Aspose.Slides Metadata**](https://products.aspose.app/slides/ar/metadata) لرؤية كيفية العمل مع خصائص المستند عبر Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ar/metadata)

## ***الأسئلة الشائعة**

### كيف يمكنني إزالة خاصية مدمجة من عرض تقديمي؟

الخصائص المدمجة جزء لا يتجزأ من العرض التقديمي ولا يمكن إزالتها بالكامل. ومع ذلك، يمكنك إما تغيير قيمها أو تعيينها فارغة إذا سمحت الخاصية بذلك.

### ماذا يحدث إذا أضفت خاصية مخصصة موجودة مسبقًا؟

إذا أضفت خاصية مخصصة موجودة مسبقًا، سيتم استبدال قيمتها الحالية بالقيمة الجديدة. لا تحتاج إلى إزالة الخاصية أو التحقق منها مسبقًا، حيث يقوم Aspose.Slides بتحديث قيمة الخاصية تلقائيًا.

### هل يمكنني الوصول إلى خصائص العرض التقديمي دون تحميل العرض بالكامل؟

نعم، يمكنك الوصول إلى خصائص العرض التقديمي دون تحميله بالكامل باستخدام الطريقة `GetPresentationInfo` من فئة [PresentationFactory](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentationfactory/). بعد ذلك، استخدم الطريقة `ReadDocumentProperties` المتوفرة في واجهة [IPresentationInfo](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentationinfo/) لقراءة الخصائص بكفاءة، مما يوفر الذاكرة ويحسن الأداء.