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
- الخصائص المضمنة
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
description: "تحكم في خصائص العرض التقديمي في Aspose.Slides للغة C++ وسهّل البحث والعلامة التجارية وسير العمل في ملفات PowerPoint وOpenDocument الخاصة بك."
---
## **مقدمة**

Aspose.Slides for C++ يدعم **الخصائص المضمنة** و **الخصائص المخصصة** للمستند. استخدم هذه الخصائص لقراءة وتحديث بيانات تعريف العرض التقديمي، مثل الكاتب، العنوان، والقيم التي يحددها المستخدم.

Aspose.Slides يسمح لك بالعمل مع خصائص مستند العرض التقديمي عبر واجهة [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/). يتم إرجاع نسخة من هذه الواجهة بواسطة [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/). توضح الأمثلة التالية كيفية قراءة، تعديل، وإدارة هذه الخصائص.

{{% alert color="info" title="Note" %}}
Aspose.Slides يدير بيانات تعريف التطبيق والمنتج عند حفظ العروض التقديمية؛ هذه الحقول تحدد البرنامج الذي أنشأ الإخراج.
{{% /alert %}}

## **إدارة خصائص العرض التقديمي**

تخزن خصائص المستند معلومات وصفية بجانب محتوى العرض التقديمي. تنقسم إلى فئتين:

- **الخصائص المضمنة** تحتوي على بيانات تعريف معيارية، مثل العنوان، الكاتب، وإحصاءات المستند.
- **الخصائص المخصصة** تخزن أزواج اسم/قيمة يحددها المستخدم.

Aspose.Slides for C++ يتيح الوصول إلى كلا الفئتين. في PowerPoint، اختر **File → Info → Properties → Advanced Properties** لاستعراض بيانات تعريف المستند. يُقسم الحوار المعلومات إلى علامات تبويب مثل **Summary**, **Statistics**, **Contents**, و **Custom**. استخدم علامة تبويب **Custom** لإدارة الخصائص التي يحددها المستخدم.

## **قراءة الخصائص العامة من عرض تقديمي مشفر**

عادةً ما يحمي كلمة مرور الفتح كلًا من محتوى العرض التقديمي وخصائص المستند. عندما يتم تشفير عرض تقديمي بتمرير `false` إلى [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/)، تظل خصائص المستند عامة. يمكن للتطبيق بعد ذلك تمرير `true` إلى [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) وقراءة البيانات العامة دون تزويد كلمة مرور الفتح.

[LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) يتحكم فيما يقوم Aspose.Slides بتحميله؛ وهو لا يفك تشفير أي شيء. إذا تم تضمين الخصائص في التشفير، فإن تحميلها بدون كلمة المرور يفشل. إذا لم يكن العرض مشفرًا، يتم تجاهل الخيار وتُحمَّل نسخة العرض الكاملة.

يتطلب المثال عرضًا تقديميًا مشفرًا تُركت خصائصه العامة. يتحقق من وضع التحميل عبر [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) ثم يقرأ الخصائص المضمنة عبر [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/):

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <DOM/LoadOptions.h>
#include <DOM/IProtectionManager.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = System::MakeObject<Presentation>(u"public-properties-encrypted.pptx", loadOptions);

if (presentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    auto documentProperties = presentation->get_DocumentProperties();

    System::Console::WriteLine(u"Author: {0}", documentProperties->get_Author());
    System::Console::WriteLine(u"Title: {0}", documentProperties->get_Title());
    System::Console::WriteLine(u"Keywords: {0}", documentProperties->get_Keywords());
}
else
{
    System::Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}
```

في هذا الوضع، لا يتم تحميل محتوى الشرائح. الشرائح، القوالب الرئيسة، التخطيطات، الأشكال، الوسائط، وغيرها من كائنات العرض غير متاحة. يجب على التطبيقات دائمًا التحقق من [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) قبل تنفيذ عملية تتطلب نموذج كائن العرض الكامل.

{{% alert color="warning" title="Security" %}}
قد تكشف البيانات العامة عن أسماء المؤلفين، العناوين، المواضيع، الكلمات المفتاحية، معلومات الشركة، التعليقات، والقيم المخصصة. قم بتشفير الخصائص الحساسة مع العرض. اتركها عامة فقط عندما تتطلب أنظمة الفهرسة، التصنيف، البحث، أو إدارة المستندات إمكانية الوصول إليها دون كلمة مرور.
{{% /alert %}}

## **تحديث خصائص عرض تقديمي مشفر**

للملف PPTX المشفر، يُقصد بالعرض الذي يتم تحميله بتمرير `true` إلى [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) قراءة البيانات العامة فقط. لا يمكن لـ Aspose.Slides حفظ الخصائص المتغيّرة من كائن يحتوي على البيانات العامة فقط لأن الخصائص العامة يجب أن تظل متناسقة مع البيانات المقابلة داخل العرض المشفر. لذلك يتطلب التحديث كلمة مرور الفتح الصحيحة وتحميل كامل للعرض.

يتطلب المثال عرضًا تقديميًا PPTX مشفرًا بخصائص مستند عامة وكلمة مرور فتح معروفة. يفتح العرض الكامل باستخدام [LoadOptions::set_Password](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_password/)، يُحدّث الخصائص المضمنة العامة، ويحفظ النتيجة. ثم يستخدم [IPresentationInfo::get_IsEncrypted](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/get_isencrypted/) للتحقق من الحفاظ على التشفير ويعيد فتح البيانات العامة دون كلمة مرور للتحقق من القيم الجديدة:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <DOM/LoadOptions.h>
#include <DOM/IProtectionManager.h>
#include <DOM/PresentationFactory.h>
#include <DOM/IPresentationInfo.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const System::String inputPath = u"public-properties-encrypted.pptx";
const System::String outputPath = u"updated-public-properties-encrypted.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(inputPath, loadOptions);

auto documentProperties = presentation->get_DocumentProperties();
documentProperties->set_Title(u"Updated Product Roadmap");
documentProperties->set_Keywords(u"roadmap, planning, indexed");

presentation->Save(outputPath, SaveFormat::Pptx);

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(outputPath);
System::Console::WriteLine(u"The presentation is encrypted: {0}", presentationInfo->get_IsEncrypted());

auto metadataLoadOptions = System::MakeObject<LoadOptions>();
metadataLoadOptions->set_OnlyLoadDocumentProperties(true);

auto metadataPresentation = System::MakeObject<Presentation>(outputPath, metadataLoadOptions);

if (metadataPresentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    System::Console::WriteLine(u"Title: {0}", metadataPresentation->get_DocumentProperties()->get_Title());
    System::Console::WriteLine(u"Keywords: {0}", metadataPresentation->get_DocumentProperties()->get_Keywords());
}
else
{
    System::Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}
```

إذا لم يسمح التطبيق بفك تشفير أو تحميل محتوى العرض، يجب معاملة خصائص العرض المشفر كقراءة فقط.

## **الوصول إلى الخصائص المضمنة**

واجهة [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) تعرض البيانات المضمنة عبر getters مكتوبة بنوعها، بما في ذلك [get_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_author/)، [get_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_title/)، و [get_CreatedTime](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_createdtime/). يفتح هذا المثال عرضًا تقديميًا موجودًا ويطبع بياناته المخزنة إلى وحدة التحكم. القيم تعتمد على العرض المدخل؛ قد تكون بعض الحقول فارغة.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"AccessBuiltInProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

System::Console::WriteLine(u"Category: {0}", documentProperties->get_Category());
System::Console::WriteLine(u"Content status: {0}", documentProperties->get_ContentStatus());
System::Console::WriteLine(u"Creation date: {0}", documentProperties->get_CreatedTime());
System::Console::WriteLine(u"Author: {0}", documentProperties->get_Author());
System::Console::WriteLine(u"Comments: {0}", documentProperties->get_Comments());
System::Console::WriteLine(u"Keywords: {0}", documentProperties->get_Keywords());
System::Console::WriteLine(u"Last modified by: {0}", documentProperties->get_LastSavedBy());
System::Console::WriteLine(u"Manager: {0}", documentProperties->get_Manager());
System::Console::WriteLine(u"Modified date: {0}", documentProperties->get_LastSavedTime());
System::Console::WriteLine(u"Presentation format: {0}", documentProperties->get_PresentationFormat());
System::Console::WriteLine(u"Last print date: {0}", documentProperties->get_LastPrinted());
System::Console::WriteLine(u"Is shared between producers: {0}", documentProperties->get_SharedDoc());
System::Console::WriteLine(u"Subject: {0}", documentProperties->get_Subject());
System::Console::WriteLine(u"Title: {0}", documentProperties->get_Title());
```

## **تعديل الخصائص المضمنة**

لتحديث البيانات المضمنة، استخدم الـ setters على الكائن المرتجع من [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/). يفتح هذا المثال عرضًا تقديميًا موجودًا، يستدعي [set_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_author/)، [set_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_title/), [set_Subject](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_subject/), [set_Comments](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_comments/), و [set_Manager](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_manager/)، ثم يحفظ العرض المحدث باستخدام [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/). يحتوي ملف PPTX المحفوظ على البيانات التعريفية الجديدة.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"ModifyBuiltInProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

documentProperties->set_Author(u"Aspose.Slides for C++");
documentProperties->set_Title(u"Manage PowerPoint Presentation Properties");
documentProperties->set_Subject(u"Modify Built-in Properties");
documentProperties->set_Comments(u"Aspose description");
documentProperties->set_Manager(u"Aspose manager");

presentation->Save(u"DocumentProperties_output.pptx", SaveFormat::Pptx);
```

## **إدارة قاعدة الروابط التشعبية**

[IDocumentProperties::get_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_hyperlinkbase/) يقرأ القاعدة على مستوى المستند للروابط التشعبية النسبية. هذا مفيد عند نقل عرض تقديمي وملفاته المرتبطة إلى موقع آخر. إنها منفصلة عن [IHyperlink::get_ExternalUrl](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurl/): تغيير القاعدة لا يعيد كتابة عناوين الروابط المخزنة ولا يغيّر الوجهات المطلقة.

يتطلب المثال عرضًا يحتوي على كلٍ من رابط نسبي، مثل `target.html`، ورابط مطلق، مثل `https://example.org/absolute.html`. يقرأ القاعدة الحالية، يعيّن قاعدة جديدة باستخدام [IDocumentProperties::set_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_hyperlinkbase/)، ويحفظ العرض ثم يعيده للتحقق من القيمة. بعد ذلك يمسح القاعدة باستخدام `u""` ويتحقق من القيمة الفارغة في ملف محفوظ منفصل. استبدل عنوان القاعدة المثال بموقع ملفاتك المرتبطة.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"hyperlinks.pptx");

System::Console::WriteLine(u"Original base: {0}", presentation->get_DocumentProperties()->get_HyperlinkBase());

const System::String newBase = u"https://example.com/new/";
presentation->get_DocumentProperties()->set_HyperlinkBase(newBase);
presentation->Save(u"hyperlinks-updated.pptx", SaveFormat::Pptx);

auto updatedPresentation = System::MakeObject<Presentation>(u"hyperlinks-updated.pptx");
System::Console::WriteLine(u"Base preserved: {0}", (updatedPresentation->get_DocumentProperties()->get_HyperlinkBase() == newBase));

updatedPresentation->get_DocumentProperties()->set_HyperlinkBase(u"");
updatedPresentation->Save(u"hyperlinks-cleared.pptx", SaveFormat::Pptx);

auto clearedPresentation = System::MakeObject<Presentation>(u"hyperlinks-cleared.pptx");
System::Console::WriteLine(u"Base cleared: {0}", (clearedPresentation->get_DocumentProperties()->get_HyperlinkBase() == u""));
```

يجب أن تطبع رسائل التحقق الاثنين `True`. مسح القاعدة يترك عناوين الروابط الفردية دون تغيير.

رابط نسبي إلى `target.pptx` يفتح `old/target.pptx` عندما تكون القاعدة تشير إلى مجلد `old`. بعد تغيير القاعدة إلى مجلد `new`، وحفظ العرض وإعادة فتحه، يفتح الرابط نفسه `new/target.pptx`. الرابط المطلق يظل يفتح نفس الملف. اختبر روابطك النسبية في PowerPoint قبل وبعد نقل العرض أو تغيير قاعدته.

## **إضافة خصائص عرض تقديمي مخصصة**

الخصائص المخصصة تخزن بيانات تعريف ليس لها حقل مضمّن مكافئ. تسمح [IDocumentProperties::idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/) بتعيين قيمة باسم الخاصية. يخلق هذا المثال عرضًا تقديميًا، يضيف قيمتي نص وقيمة رقمية للإصدار، ويحفظ العرض باستخدام [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/). تعيين قيمة لاسم موجود يستبدل قيمة الخاصية الحالية.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto documentProperties = presentation->get_DocumentProperties();

documentProperties->idx_set(u"Reviewed by", System::ObjectExt::Box<System::String>(u"John Smith"));
documentProperties->idx_set(u"Confidentiality level", System::ObjectExt::Box<System::String>(u"Internal"));
documentProperties->idx_set(u"Document version", System::ObjectExt::Box(2));

presentation->Save(u"CustomDocumentProperties_output.pptx", SaveFormat::Pptx);
```

## **الوصول إلى الخصائص المخصصة وتعديلها**

يفتح هذا المثال عرضًا يحتوي على خصائص مخصصة ويستخدم [get_CountOfCustomProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_countofcustomproperties/) للتكرار عليها. [GetCustomPropertyName](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/getcustompropertyname/) تستقبل فهرسًا يبدأ من الصفر وتعيد الاسم المستخدم بواسطة [IDocumentProperties::idx_get](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_get/) و [idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/). يطبع المثال كل اسم وقيمة أصلية، يستبدل كل قيمة بسلسلة مرقمة بغض النظر عن نوعها الأصلي، ويحفظ التغييرات. إذا لم توجد خصائص مخصصة، لا يُجري الحلقة أي تغييرات.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"AccessAndModifyProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

for (auto i = 0; i < documentProperties->get_CountOfCustomProperties(); i++)
{
    auto propertyName = documentProperties->GetCustomPropertyName(i);
    auto propertyValue = documentProperties->idx_get(propertyName);

    System::Console::WriteLine(u"Custom property name: {0}", propertyName);
    System::Console::WriteLine(u"Custom property value: {0}", propertyValue);

    documentProperties->idx_set(propertyName, System::ObjectExt::Box(System::String::Format(u"New Value {0}", i + 1)));
}

presentation->Save(u"CustomProperties_output.pptx", SaveFormat::Pptx);
```

## **مثال حي**

جرّب التطبيق الإلكتروني [عرض وتعديل بيانات PowerPoint](https://products.aspose.app/slides/metadata) لتستكشف كيفية العمل مع خصائص المستند باستخدام واجهة Aspose.Slides API:

[![عرض وتعديل بيانات PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **الأسئلة المتكررة**

**كيف يمكنني إزالة خاصية مضمّنة من عرض تقديمي؟**

الخصائص المضمنة جزء أساسي من العرض ولا يمكن إزالتها بالكامل. ومع ذلك، يمكنك إما تغيير قيمتها أو تعيينها كفارغة إذا سمح ذلك للخاصية المحددة.

**ماذا يحدث إذا أضفت خاصية مخصصة موجودة بالفعل؟**

إذا أضفت خاصية مخصصة موجودة، سيتم استبدال قيمتها الحالية بالقيمة الجديدة. لا تحتاج إلى إزالة أو التحقق من الخاصية مسبقًا، حيث يقوم Aspose.Slides بتحديث قيمة الخاصية تلقائيًا.

**هل يمكنني الوصول إلى خصائص العرض التقديمي دون تحميل العرض بالكامل؟**

نعم. استخدم [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/presentationfactory/getpresentationinfo/) ثم [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) لقراءة بيانات المستند المخزنة دون إنشاء نسخة من كائن [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/). راجع [إنشاء جرد عرض تقديمي خفيف الوزن](/slides/ar/cpp/examine-presentation/) للحصول على مثال تقرير كامل والقيود الخاصة بكل تنسيق.

**هل يمكنني قراءة الخصائص العامة لعرض مشفر دون كلمة مرور الفتح؟**

نعم. يجب أن يكون العرض قد تم تشفيره بتمرير `false` إلى [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/)، ويجب تحميله بتمرير `true` إلى [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/).

**هل يمكنني تحديث ملف PPTX مشفر في وضعية تحميل الخصائص فقط؟**

لا. يجب أن تظل بيانات الخصائص العامة المشفرة متناسقة، لذا يتطلب تحديث ملف PPTX مشفر تحميل العرض بالكامل مع كلمة المرور الصحيحة.