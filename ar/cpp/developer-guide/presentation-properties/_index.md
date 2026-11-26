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
- خصائص مضمّنة
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
description: "إدارة خصائص العرض التقديمي في Aspose.Slides لـ C++ وتبسيط البحث والعلامة التجارية وسير العمل في ملفات PowerPoint و OpenDocument الخاصة بك."
---
## **مقدمة**

Aspose.Slides for C++ يدعم خصائص المستند **المضمنة** و**المخصصة**. استخدم هذه الخصائص لقراءة وتحديث بيانات تعريف العرض التقديمي، مثل المؤلف، العنوان، والقيم المعرّفة من قبل المستخدم.

يسمح لك Aspose.Slides بالعمل مع خصائص مستند العرض التقديمي من خلال واجهة [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) . تُرجَع نسخة من هذه الواجهة بواسطة [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/). تُظهر الأمثلة التالية كيفية قراءة وتعديل وإدارة هذه الخصائص.

{{% alert color="info" title="Note" %}}
يدير Aspose.Slides بيانات التعريف الخاصة بالتطبيق والمنتج عند حفظ العروض التقديمية؛ تُحدد هذه الحقول البرنامج الذي أنشأ الناتج.
{{% /alert %}}

## **إدارة خصائص العرض التقديمي**

تخزن خصائص المستند معلومات وصفية إلى جانب محتوى العرض التقديمي. وتنقسم إلى فئتين:

- **الخصائص المضمنة** تحتوي على بيانات تعريف قياسية، مثل العنوان، المؤلف، وإحصاءات المستند.
- **الخصائص المخصصة** تخزن أزواج الاسم/القيمة التي يحددها المستخدم.

يوفر Aspose.Slides for C++ إمكانية الوصول إلى كلتا الفئتين. في PowerPoint، اختر **File → Info → Properties → Advanced Properties** لتفحص بيانات تعريف المستند. يجمع الحوار المعلومات في علامات تبويب مثل **Summary**، **Statistics**، **Contents**، و**Custom**. استخدم علامة التبويب **Custom** لإدارة الخصائص التي يحددها المستخدم.

## **قراءة الخصائص العامة من عرض تقديمي مشفر**

عادةً ما تحمّي كلمة المرور عند الفتح كلًا من محتوى العرض التقديمي وخصائص المستند. عندما يتم تشفير عرض تقديمي بتمرير `false` إلى [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/)، تظل خصائص المستند عامة. ثم يمكن لتطبيق تمرير `true` إلى [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) وقراءة البيانات العامة دون توفير كلمة المرور عند الفتح.

يتحكم [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) فيما يقوم Aspose.Slides بتحميله؛ ولا يقوم بفك التشفير. إذا كانت الخصائص مشمولة في التشفير، فإن تحميلها بدون كلمة المرور سيفشل. إذا لم يكن العرض التقديمي مشفرًا، تُتجاهل هذه الخاصية وتُحمَّل كامل العرض التقديمي.

يتطلّب المثال عرضًا تقديميًا مشفرًا تُترك خصائص المستند فيه عامة. يتحقق من وضع التحميل عبر [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/)، ثم يقرأ الخصائص المضمنة عبر [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/):

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

في هذا الوضع، لا يتم تحميل محتوى الشرائح. الشرائح، القوالب، التخطيطات، الأشكال، الوسائط، وغيرها من كائنات العرض غير متاحة. يجب على التطبيقات دائمًا التحقق من [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) قبل تنفيذ عملية تتطلب نموذج كائن العرض الكامل.

{{% alert color="warning" title="Security" %}}
قد تكشف البيانات العامة عن أسماء المؤلفين، العناوين، الموضوعات، الكلمات المفتاحية، معلومات الشركة، التعليقات، والقيم المخصصة. قم بتشفير الخصائص الحساسة مع العرض التقديمي. اتركها عامة فقط عندما يتطلب الفهرسة أو التصنيف أو البحث أو أنظمة إدارة المستندات الوصول إليها دون كلمة مرور.
{{% /alert %}}

## **تحديث خصائص عرض تقديمي مشفر**

بالنسبة إلى ملف PPTX مشفر، يهدف العرض المحمَّل بتمرير `true` إلى [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) إلى قراءة البيانات العامة. لا يمكن لبرنامج Aspose.Slides حفظ الخصائص المعدلة من كائن يحتوي على البيانات العامة فقط لأن الخصائص العامة يجب أن تظل متسقة مع البيانات المقابلة داخل العرض المشفر. وبالتالي يتطلب تحديثها كلمة المرور الصحيحة عند الفتح وتحميلًا كاملاً.

يتطلّب المثال عرض PPTX مشفرًا يحتوي على خصائص مستند عامة وكلمة مرور معرفة عند الفتح. يفتح العرض الكامل باستخدام [LoadOptions::set_Password](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_password/)، يُحدّث الخصائص المضمنة العامة، ويحفظ النتيجة. ثم يستخدم [IPresentationInfo::get_IsEncrypted](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/get_isencrypted/) للتحقق من حفظ التشفير ويعيد فتح البيانات العامة بدون كلمة مرور للتحقق من القيم الجديدة:

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

إذا لم يسمح لتطبيق بفك تشفير أو تحميل محتوى العرض التقديمي، يجب أن يتعامل مع الخصائص العامة لملف PPTX مشفر كقابلة للقراءة فقط.

## **الوصول إلى الخصائص المضمنة**

تُظهر واجهة [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) بيانات التعريف المضمنة عبر getters ذات نوع محدد، بما في ذلك [get_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_author/)، [get_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_title/)، و[get_CreatedTime](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_createdtime/). يفتح هذا المثال عرضًا تقديميًا موجودًا ويطبع البيانات المخزنة إلى وحدة التحكم. القيم تعتمد على العرض المُدخل؛ قد تكون بعض الحقول فارغة.

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

### **تقرير رقم المراجعة ووقت التحرير**

استخدم [GetPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/presentationfactory/getpresentationinfo/) و[ReadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) لقراءة [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) لكل ملف دون تحميل شرائحه للتحرير. يطبع هذا المثال صفًا واحدًا لكل ملف PPTX في مجلد `presentations`. يشتمل التنسيق القياسي `c` على عدد الأيام عندما يصل وقت التحرير المسجَّل إلى 24 ساعة.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/timespan.h>

using namespace Aspose::Slides;
using namespace System::IO;

System::Console::WriteLine(u"File | RevisionNumber | TotalEditingTime");
auto paths = Directory::GetFiles(u"presentations", u"*.pptx");
for (const auto& path : paths)
{
    auto info = PresentationFactory::get_Instance()->GetPresentationInfo(path);
    auto properties = info->ReadDocumentProperties();
    auto fileName = Path::GetFileName(path);
    auto editingTime = properties->get_TotalEditingTime().ToString(u"c");
    System::Console::WriteLine(u"{0} | {1} | {2}", fileName, properties->get_RevisionNumber(), editingTime);
}
```

لعرض تقديمي يحتوي على 1 يوم، 2 ساعة، و5 دقائق من وقت التحرير المسجَّل، يكون التقرير كالتالي:

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[get_RevisionNumber](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_revisionnumber/) يقرأ قيمة بيانات التعريف التي يمكن للتطبيقات تعديلها باستخدام [set_RevisionNumber](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_revisionnumber/). لا يمكن لتلك القيمة بمفردها تحديد عدد مرات حفظ العرض التقديمي أو إعادة بناء تاريخ إصداراته.

[get_TotalEditingTime](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_totaleditingtime/) يُرجِع مدة التحرير المسجلة في الملف. قيمة `00:00:00` تعني أن المدة المخزنة صفر. قد يكون العرض التقديمي لا يزال قد تم تحريره.

## **تعديل الخصائص المضمنة**

لتحديث البيانات المضمنة، استخدم الدوال setter على الكائن المُرجع من [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/). يفتح هذا المثال عرضًا تقديميًا موجودًا، يستدعي [set_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_author/)، [set_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_title/), [set_Subject](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_subject/), [set_Comments](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_comments/), و[set_Manager](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_manager/), ثم يحفظ العرض المحدث باستخدام [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/). يحتوي ملف PPTX المحفوظ على البيانات الجديدة.

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

## **إدارة أساس الروابط التشعبية**

[IDocumentProperties::get_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_hyperlinkbase/) يقرأ الأساس على مستوى المستند للروابط التشعبية النسبية. هذا مفيد عند نقل عرض تقديمي وملفاته المرتبطة إلى موقع آخر. وهو منفصل عن [IHyperlink::get_ExternalUrl](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurl/): تغيير الأساس لا يعيد كتابة عناوين الروابط المخزنة ولا يغيّر الوجهات المطلقة.

يتطلّب المثال عرضًا يحتوي على كل من رابط نسبي، مثل `target.html`، ورابط مطلق، مثل `https://example.org/absolute.html`. يقرأ الأساس الحالي، يعيّن عنوان أساس جديد باستخدام [IDocumentProperties::set_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_hyperlinkbase/), ثم يحفظ العرض ويعيد فتحه للتحقق من القيمة. بعد ذلك يُمسح الأساس باستخدام `u""` ويُتحقق من القيمة الفارغة في ملف محفوظ منفصل. استبدل عنوان الأساس في المثال بموقع ملفاتك المرتبطة.

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

يجب أن تطبع رسالتي التحقق `True`. مسح الأساس يترك عناوين الروابط الفردية دون تغيير.

رابط نسبي إلى `target.pptx` كان يفتح `old/target.pptx` عندما كان الأساس يشير إلى مجلد `old`. بعد تغيير الأساس إلى مجلد `new`, وحفظ وإعادة فتح العرض، يفتح نفس الرابط `new/target.pptx`. الرابط المطلق استمر في فتح نفس الملف. اختبر روابطك النسبية في PowerPoint قبل وبعد نقل العرض أو تغيير أسسه.

## **إضافة خصائص عرض تقديمي مخصصة**

تخزن الخصائص المخصصة بيانات تعريف لا يوجد لها حقل مضمّن مماثل. يتيح لك [IDocumentProperties::idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/) تعيين قيمة بحسب اسم الخاصية. ينشئ هذا المثال عرضًا تقديميًا، يضيف قيمتي نص وإصدار عدد صحيح، ويحفظ العرض باستخدام [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/). تعيين قيمة لاسم موجود يستبدل قيمة الخاصية.

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

## **الوصول إلى وتعديل الخصائص المخصصة**

يفتح هذا المثال عرضًا يحتوي على خصائص مخصصة ويستخدم [get_CountOfCustomProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_countofcustomproperties/) للتنقل بينها. تستقبل [GetCustomPropertyName](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/getcustompropertyname/) فهرسًا يبدأ من الصفر وتُرجع الاسم المستخدم بواسطة [IDocumentProperties::idx_get](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_get/) و[idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/). يطبع المثال كل اسم وقيمة أصلية، يستبدل كل قيمة بسلسلة مرقمة بغض النظر عن نوعها الأصلي، ويحفظ التغييرات. إذا لم توجد خصائص مخصصة، فإن الحلقة لا تُجري أي تغييرات.

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

جرّب التطبيق عبر الإنترنت [**عرض وتعديل بيانات تعريف PowerPoint**](https://products.aspose.app/slides/metadata) لتستعرض كيفية العمل مع خصائص المستند باستخدام Aspose.Slides API:

[![عرض وتعديل بيانات تعريف PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **الأسئلة المتكررة**

**كيف يمكنني إزالة خاصية مضمّنة من عرض تقديمي؟**

الخصائص المضمنة جزء لا يتجزأ من العرض التقديمي ولا يمكن إزالتها تمامًا. ومع ذلك، يمكنك إما تغيير قيمها أو تعيينها كفارغة إذا سمحت الخاصية المحددة بذلك.

**ماذا يحدث إذا أضفت خاصية مخصصة موجودة بالفعل؟**

إذا أضفت خاصية مخصصة موجودة بالفعل، فستُستبدل قيمتها الحالية بالقيمة الجديدة. لا تحتاج إلى إزالة الخاصية أو التحقق منها مسبقًا، حيث يقوم Aspose.Slides بتحديث قيمة الخاصية تلقائيًا.

**هل يمكنني الوصول إلى خصائص العرض التقديمي دون تحميله بالكامل؟**

نعم. استخدم [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/presentationfactory/getpresentationinfo/) ثم [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) لقراءة بيانات تعريف المستند المخزنة دون إنشاء نسخة من [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/). راجع [إنشاء جرد عرض تقديمي خفيف](/slides/ar/cpp/examine-presentation/) للحصول على مثال شامل للتقارير والقيود الخاصة بالتنسيق.

**هل يمكنني قراءة الخصائص العامة لعرض تقديمي مشفر دون كلمة مرور الفتح؟**

نعم. يجب أن يكون العرض التقديمي قد تم تشفيره بتمرير `false` إلى [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/), ويجب تحميله بتمرير `true` إلى [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/).

**هل يمكنني تحديث ملف PPTX مشفر في وضع تحميل خصائص المستند فقط؟**

لا. يجب أن تظل بيانات الخصائص العامة والمشفرة متسقة، لذا يتطلب تحديث ملف PPTX مشفر تحميل العرض التقديمي كاملاً باستخدام كلمة المرور الصحيحة عند الفتح.