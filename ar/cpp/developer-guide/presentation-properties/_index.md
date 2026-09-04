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
- تحرير البيانات التعريفية
- لغة التدقيق
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- C++
- Aspose.Slides
description: "تحكم في خصائص العرض التقديمي في Aspose.Slides لـ C++ وحسّن عملية البحث والعلامة التجارية وسير العمل في ملفات PowerPoint وOpenDocument الخاصة بك."
---
## **مقدمة**

يدعم Aspose.Slides نوعين من خصائص المستند: **Built-in** و **Custom**. يمكن الوصول إلى كلا نوعي الخصائص وإدارتهما بسهولة باستخدام واجهة برمجة تطبيقات Aspose.Slides.

يتيح Aspose.Slides لك العمل مع خصائص مستندات العرض التقديمي عبر الواجهة [IDocumentProperties](https://reference.aspose.com/slides/ar/cpp/aspose.slides/idocumentproperties/) . يتم إرجاع مثال من هذه الواجهة بواسطة [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/get_documentproperties/). تُظهر الأمثلة التالية كيفية قراءة هذه الخصائص وتعديلها وإدارتها.

{{% alert color="info" title="Note" %}}
يرجى ملاحظة أنه لا يمكنك تعيين قيم لحقل **Application** وحقل **Producer**، لأن Aspose Ltd. و Aspose.Slides for C++ x.x.x سيظهران في هذين الحقلين.
{{% /alert %}} 

## **إدارة خصائص العرض التقديمي**

يوفر Microsoft PowerPoint ميزة لإضافة بعض الخصائص إلى ملفات العرض التقديمي. تسمح هذه الخصائص بتخزين معلومات مفيدة إلى جانب المستندات (ملفات العرض). هناك نوعان من خصائص المستند كما يلي

- خصائص معرفة نظاميًا (**Built-in**)
- خصائص معرفة من قبل المستخدم (**Custom**)

**Built-in** تحتوي على معلومات عامة حول المستند مثل عنوان المستند، اسم المؤلف، إحصائيات المستند وما إلى ذلك. **Custom** هي تلك التي يحددها المستخدمون كأزواج **Name/Value**، حيث يتم تعريف كل من الاسم والقيمة من قبل المستخدم. باستخدام Aspose.Slides for C++، يمكن للمطورين الوصول إلى قيم الخصائص المضمنة وكذلك الخصائص المخصصة وتعديلها. يسمح Microsoft PowerPoint 2007 بإدارة خصائص مستندات ملفات العرض. كل ما عليك فعله هو النقر على أيقونة Office ثم العنصر **Prepare | Properties | Advanced Properties** في قائمة Microsoft PowerPoint 2007. بعد اختيار العنصر **Advanced Properties**، سيظهر مربع حوار يتيح لك إدارة خصائص المستند لملف PowerPoint. في **Properties Dialog**، يمكنك رؤية العديد من علامات التبويب مثل **General, Summary, Statistics, Contents and Custom**. جميع هذه العلامات تسمح بتكوين أنواع مختلفة من المعلومات المتعلقة بملفات PowerPoint. تُستخدم علامة التبويب **Custom** لإدارة الخصائص المخصصة لملفات PowerPoint.

## **قراءة الخصائص العامة من عرض تقديمي مشفر**

عادةً ما تحمي كلمة مرور الفتح كلًا من محتوى العرض التقديمي وخصائص المستند. عندما يتم تشفير عرض تقديمي عن طريق تمرير `false` إلى [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/)، تبقى خصائص المستند عامة. يمكن للتطبيق بعد ذلك تمرير `true` إلى [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/ar/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) وقراءة البيانات الوصفية العامة دون توفير كلمة مرور الفتح.

`set_OnlyLoadDocumentProperties` يتحكم فيما يقوم Aspose.Slides بتحميله؛ فهو لا يقوم بفك تشفير أي شيء. إذا تم تضمين الخصائص في التشفير، فإن تحميلها دون كلمة المرور سيفشل. إذا لم يكن العرض مشفرًا، يتم تجاهل الخيار ويتم تحميل العرض بالكامل.

تتحقق المثال التالي من وضع التحميل عبر [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/)، ثم يقرأ الخصائص المضمنة عبر [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/get_documentproperties/):

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = MakeObject<Presentation>(u"public-properties-encrypted.pptx", loadOptions);

if (presentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    auto properties = presentation->get_DocumentProperties();

    Console::WriteLine(u"Author: " + properties->get_Author());
    Console::WriteLine(u"Title: " + properties->get_Title());
    Console::WriteLine(u"Keywords: " + properties->get_Keywords());
}
else
{
    Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}

presentation->Dispose();
```

في هذا الوضع، لا يتم تحميل محتوى الشرائح. الشرائح، القوالب، التخطيطات، الأشكال، الوسائط، وغيرها من كائنات العرض غير متاحة. يجب على التطبيقات دائمًا فحص `get_IsOnlyDocumentPropertiesLoaded` قبل تنفيذ عملية تتطلب نموذج كائن العرض الكامل.

{{% alert color="warning" title="Warning" %}}
قد تكشف البيانات الوصفية العامة عن أسماء المؤلفين، العناوين، الموضوعات، الكلمات المفتاحية، معلومات الشركة، التعليقات، والقيم المخصصة. قم بتشفير الخصائص الحساسة مع العرض التقديمي. اتركها عامة فقط عندما تتطلب أنظمة الفهرسة أو التصنيف أو البحث أو إدارة المستندات الوصول إليها بدون كلمة مرور.
{{% /alert %}}

## **تحديث خصائص عرض تقديمي مشفر**

بالنسبة لملف PPTX مشفر، فإن العرض الذي يتم تحميله بعد استدعاء `set_OnlyLoadDocumentProperties(true)` يُقصد به قراءة البيانات الوصفية العامة. لا يمكن لـ Aspose.Slides حفظ الخصائص المعدلة من كائن البيانات الوصفية فقط لأن الخصائص العامة يجب أن تظل متسقة مع البيانات المقابلة داخل العرض المشفر. لذلك يتطلب تحديثها كلمة مرور الفتح الصحيحة وتحميلًا كاملاً.

يفتح المثال التالي العرض باستخدام [LoadOptions::set_Password](https://reference.aspose.com/slides/ar/cpp/aspose.slides/loadoptions/set_password/)، ويحدّث الخصائص العامة المضمنة، ثم يحفظ النتيجة. بعد ذلك يستخدم [IPresentationInfo::get_IsEncrypted](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentationinfo/get_isencrypted/) للتحقق من الحفاظ على التشفير ويعيد فتح البيانات الوصفية العامة بدون كلمة مرور للتحقق من القيم الجديدة:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

const String inputPath = u"public-properties-encrypted.pptx";
const String outputPath = u"updated-public-properties-encrypted.pptx";

{
    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(u"open_password");

    auto presentation = MakeObject<Presentation>(inputPath, loadOptions);
    presentation->get_DocumentProperties()->set_Title(u"Updated Product Roadmap");
    presentation->get_DocumentProperties()->set_Keywords(u"roadmap, planning, indexed");
    presentation->Save(outputPath, SaveFormat::Pptx);
    presentation->Dispose();
}

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(outputPath);
Console::WriteLine(presentationInfo->get_IsEncrypted() ? u"The presentation is encrypted." : u"The presentation is not encrypted.");

auto metadataLoadOptions = MakeObject<LoadOptions>();
metadataLoadOptions->set_OnlyLoadDocumentProperties(true);

auto metadataPresentation = MakeObject<Presentation>(outputPath, metadataLoadOptions);

if (metadataPresentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    Console::WriteLine(u"Title: " + metadataPresentation->get_DocumentProperties()->get_Title());
    Console::WriteLine(u"Keywords: " + metadataPresentation->get_DocumentProperties()->get_Keywords());
}
else
{
    Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}

metadataPresentation->Dispose();
```

إذا لم يسمح للتطبيق بفك تشفير أو تحميل محتوى العرض، يجب أن يتعامل مع الخصائص العامة لملف PPTX المشفر كقابلة للقراءة فقط.

## **الوصول إلى الخصائص المضمنة**

هذه الخصائص التي يعرّفها كائن **IDocumentProperties** تشمل: **Creator(Author)**، **Description**، **KeyWords**، **Created** (تاريخ الإنشاء)، **Modified** (تاريخ التعديل)، **Printed** (تاريخ آخر طباعة)، **LastModifiedBy**، **Keywords**، **SharedDoc** (هل هو مشترك بين منتجين مختلفين؟)، **PresentationFormat**، **Subject** و **Title**

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **تعديل الخصائص المضمنة**

تعديل الخصائص المضمنة لملفات العرض سهل كما هو الحال في الوصول إليها. يمكنك ببساطة تعيين قيمة نصية لأي خاصية تريدها وسيتغيّر قيمة الخاصية. في المثال أدناه، قمنا بإظهار كيفية تعديل الخصائص المضمنة للمستند في ملف العرض.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **إضافة خصائص عرض مخصصة**

يتيح Aspose.Slides for C++ للمطورين أيضًا إضافة القيم المخصصة لخصائص مستند العرض التقديمي. يُظهر المثال أدناه كيفية تعيين الخصائص المخصصة لعرض تقديمي.

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// إنشاء كائن فئة Presentation
auto presentation = System::MakeObject<Presentation>();

// جلب خصائص المستند
auto documentProperties = presentation->get_DocumentProperties();

// إضافة خصائص مخصصة
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// جلب اسم الخاصية في الفهرس المحدد
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// إزالة الخاصية المحددة
documentProperties->RemoveCustomProperty(getPropertyName);

// حفظ العرض التقديمي
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **الوصول إلى الخصائص المخصصة وتعديلها**

يتيح Aspose.Slides for C++ للمطورين أيضًا الوصول إلى قيم الخصائص المخصصة. يُظهر المثال أدناه كيف يمكنك الوصول إلى جميع هذه الخصائص المخصصة وتعديلها لعرض تقديمي.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **تحديد لغة التدقيق**

يوفر Aspose.Slides الخاصية [LanguageId](https://reference.aspose.com/slides/ar/cpp/aspose.slides/baseportionformat/set_languageid/) (المُعرّفة بواسطة الفئة [PortionFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/portionformat/) ) لتتمكن من تحديد لغة التدقيق لمستند PowerPoint. لغة التدقيق هي اللغة التي يتم فحص الإملاء والقواعد النحوية بها في PowerPoint.

يظهر هذا الكود C++ طريقة تعيين لغة التدقيق لملف PowerPoint:

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
// set the Id of a proofing language

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **تحديد اللغة الافتراضية**

يظهر هذا الكود C++ طريقة تعيين اللغة الافتراضية لكامل عرض PowerPoint:

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

// التحقق من لغة الجزء الأول
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **مثال حي**

جرّب التطبيق الإلكتروني [**Aspose.Slides Metadata**](https://products.aspose.app/slides/ar/metadata) لتلقّي كيفية العمل مع خصائص المستند عبر Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ar/metadata)

## **الأسئلة المتكررة**

**كيف يمكنني إزالة خاصية مدمجة من عرض تقديمي؟**

الخصائص المدمجة جزء أساسي من العرض ولا يمكن إزالتها بالكامل. ومع ذلك، يمكنك إما تغيير قيمها أو تعيينها كفارغ إذا سمحت الخاصية بذلك.

**ماذا يحدث إذا أضفت خاصية مخصصة موجودة بالفعل؟**

إذا أضفت خاصية مخصصة موجودة بالفعل، ستُستبدل قيمتها الحالية بالقيمة الجديدة. لا يلزم حذف أو فحص الخاصية مسبقًا، حيث يقوم Aspose.Slides بتحديث قيمة الخاصية تلقائيًا.

**هل يمكنني الوصول إلى خصائص العرض دون تحميل العرض بالكامل؟**

نعم. استخدم [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) ثم [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) لقراءة البيانات الوصفية المخزنة للمستند دون إنشاء مثيل [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/). راجع [Build a Lightweight Presentation Inventory](/slides/ar/cpp/examine-presentation/) للحصول على مثال تقرير كامل وقيود خاصة بالتنسيق.

**هل يمكنني قراءة الخصائص العامة لعرض مشفر دون كلمة مرور الفتح الخاصة به؟**

نعم. يجب أن يكون العرض قد تم تشفيره بتمرير `false` إلى `set_EncryptDocumentProperties`، ويجب تحميله بتمرير `true` إلى `set_OnlyLoadDocumentProperties`.

**هل يمكنني تحديث ملف PPTX مشفر في وضع خصائص المستند فقط؟**

لا. يجب أن تظل البيانات العامة والبيانات المشفرة للخصائص متسقة، لذا يتطلب تحديث ملف PPTX مشفر تحميل العرض الكامل مع كلمة مرور الفتح الصحيحة.