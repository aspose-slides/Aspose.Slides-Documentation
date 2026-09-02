---
title: استرجاع وتحديث معلومات العرض في C++
linktitle: معلومات العرض
type: docs
weight: 30
url: /ar/cpp/examine-presentation/
keywords:
- صيغة العرض
- خصائص العرض
- خصائص المستند
- الحصول على الخصائص
- قراءة الخصائص
- تغيير الخصائص
- تعديل الخصائص
- تحديث الخصائص
- فحص PPTX
- فحص PPT
- فحص ODP
- PowerPoint
- OpenDocument
- عرض
- C++
- Aspose.Slides
description: "استكشف الشرائح والبنية والبيانات الوصفية في عروض PowerPoint وOpenDocument باستخدام C++ للحصول على رؤى أسرع وتدقيق محتوى أذكى."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides تحديد صيغة العرض وقراءة بياناته الوصفية دون إنشاء نموذج كائن عرض كامل. يكون هذا مفيدًا عندما تحتاج إلى تصنيف الملفات، بناء جرد، أو فحص الخصائص قبل اتخاذ قرار بتحميل ومعالجة محتوى العرض.

يُظهر هذا المقال كيفية الفحص الخفيف عبر [PresentationFactory](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentationfactory/) و[IPresentationInfo](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentationinfo/)، وكذلك التحديثات المستهدفة عبر [IDocumentProperties](https://reference.aspose.com/slides/ar/cpp/aspose.slides/idocumentproperties/).

## **التحقق من صيغة العرض**

استخدم [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) لفحص ملف دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/). تُعيد طريقة [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentationinfo/get_loadformat/) الصيغة المكتشفة، مثل PPTX أو PPT أو ODP.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto fileNames = MakeArray<String>({u"pres.pptx", u"pres.ppt", u"pres.odp"});

for (const auto& fileName : fileNames)
{
    auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);
    Console::WriteLine(String::Format(u"{0}: {1}", fileName, ObjectExt::ToString(presentationInfo->get_LoadFormat())));
}
```

## **بناء جرد عرض خفيف**

عند معالجة العديد من ملفات العروض، قد تحتاج إلى جرد مدمج للتحقق أو الفهرسة أو نظام إدارة المستندات. في هذا السيناريو، استخدم [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) للحصول على كائن [IPresentationInfo](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentationinfo/)، ثم استدعِ طريقة [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) لقراءة بيانات المستند الوصفية. لا ينشئ هذا النهج كائن [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) ولا يتطلب استعراض نموذج كائن العرض بالكامل.

الخصائص الموسعة التي يوفرها [IDocumentProperties](https://reference.aspose.com/slides/ar/cpp/aspose.slides/idocumentproperties/) تُعطي القيم التالية للجرد:

| الطريقة | قيمة الجرد |
| --- | --- |
| [get_Slides](https://reference.aspose.com/slides/ar/cpp/aspose.slides/idocumentproperties/get_slides/) | إجمالي عدد الشرائح. |
| [get_HiddenSlides](https://reference.aspose.com/slides/ar/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) | عدد الشرائح المخفية. |
| [get_Notes](https://reference.aspose.com/slides/ar/cpp/aspose.slides/idocumentproperties/get_notes/) | عدد الشرائح التي تحتوي على ملاحظات. |
| [get_Paragraphs](https://reference.aspose.com/slides/ar/cpp/aspose.slides/idocumentproperties/get_paragraphs/) | إجمالي عدد الفقرات، إذا توفرت. |
| [get_Words](https://reference.aspose.com/slides/ar/cpp/aspose.slides/idocumentproperties/get_words/) | إجمالي عدد الكلمات. |
| [get_MultimediaClips](https://reference.aspose.com/slides/ar/cpp/aspose.slides/idocumentproperties/get_multimediaclips/) | إجمالي عدد مقاطع الصوت والفيديو. |

المثال التالي يقرأ هذه القيم دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) ويطبع جردًا مدمجًا. كما يجمع بين [IDocumentProperties::get_HeadingPairs](https://reference.aspose.com/slides/ar/cpp/aspose.slides/idocumentproperties/get_headingpairs/) و[IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/ar/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) لعرض مجموعات المحتوى مثل الخطوط، السمات، وعناوين الشرائح.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IHeadingPair.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/console.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto filePath = String(u"sample.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(filePath);
auto documentProperties = presentationInfo->ReadDocumentProperties();

Console::WriteLine(String::Format(u"File: {0}", Path::GetFileName(filePath)));
Console::WriteLine(String::Format(u"Format: {0}", ObjectExt::ToString(presentationInfo->get_LoadFormat())));
Console::WriteLine(String::Format(u"Title: {0}", documentProperties->get_Title()));
Console::WriteLine(String::Format(u"Author: {0}", documentProperties->get_Author()));
Console::WriteLine(u"Statistics:");
Console::WriteLine(String::Format(u"  Slides: {0}", documentProperties->get_Slides()));
Console::WriteLine(String::Format(u"  Hidden slides: {0}", documentProperties->get_HiddenSlides()));
Console::WriteLine(String::Format(u"  Slides with notes: {0}", documentProperties->get_Notes()));
Console::WriteLine(String::Format(u"  Paragraphs: {0}", documentProperties->get_Paragraphs()));
Console::WriteLine(String::Format(u"  Words: {0}", documentProperties->get_Words()));
Console::WriteLine(String::Format(u"  Multimedia clips: {0}", documentProperties->get_MultimediaClips()));

auto headingPairs = documentProperties->get_HeadingPairs();
auto titlesOfParts = documentProperties->get_TitlesOfParts();
auto partIndex = 0;

if (headingPairs == nullptr || titlesOfParts == nullptr || headingPairs->get_Length() == 0 || titlesOfParts->get_Length() == 0)
{
    Console::WriteLine(u"Content groups: not available");
}
else
{
    Console::WriteLine(u"Content groups:");

    for (const auto& headingPair : headingPairs)
    {
        auto partCount = headingPair->get_Count();
        Console::WriteLine(String::Format(u"  {0} ({1})", headingPair->get_Name(), partCount));

        for (auto partOffset = 0; partOffset < partCount && partIndex < titlesOfParts->get_Length(); partOffset++)
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts->get_Length())
    {
        Console::WriteLine(u"  Other parts:");

        while (partIndex < titlesOfParts->get_Length())
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }
}
```

كل [IHeadingPair](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iheadingpair/) يُوفر اسم المجموعة عبر [IHeadingPair::get_Name](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iheadingpair/get_name/) وعدد العناصر في تلك المجموعة عبر [IHeadingPair::get_Count](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iheadingpair/get_count/). تُعيد [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/ar/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) مصفوفة مسطحة مرتبة، لذا استهلك عدد العناوين المتتالية المحدد لكل زوج عناوين.

### **البيانات الوصفية المخزنة والقيود على الصيغة**

الخصائص التي تُعيدها [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) تعكس البيانات الوصفية المتوفرة في المستند الأصلي. لا يقوم Aspose.Slides بتحميل واستعراض نموذج كائن العرض لإعادة حساب هذه القيم لهذه العملية. تمثّل الخصائص المفقودة قيمًا افتراضية، وقد تكون القيم المخزنة قديمة إذا لم يُحدّث التطبيق الذي حفظ الملف آخر مرة خصائص المستند.

- **PPTX:** توفر الصيغة خصائص مستند موسعة لعدد الشرائح، الملاحظات، الشرائح المخفية، الفقرات، الكلمات، والوسائط المتعددة، بالإضافة إلى أزواج العناوين وعناوين الأجزاء. تعتمد التوافرية على الخصائص التي كتبها منتج المستند.
- **PPT:** يمكن للصيغة الثنائية تخزين خصائص ملخص المستند المقابلة. إذا كانت خاصية غير موجودة أو لم يتم تحديثها من قبل المنتج، تُعيد Aspose.Slides قيمتها المخزنة أو الافتراضية بدلاً من حسابها من الشرائح.
- **ODP:** تُوفر بيانات ODF العامة إحصاءات عامة للمستند مثل عدد الصفحات، الفقرات، والكلمات، لكن هذه القيم لا تُطابق كل خاصية موسعة خاصة بـ PowerPoint. قد تكون بيانات الشرائح المخفية، ملاحظات الشرائح، الوسائط المتعددة، أزواج العناوين، وعناوين الأجزاء غير متوفرة، وقد تُعيد خصائص الجرد قيمًا افتراضية. لا تُعامل القيمة الصفرية أو المصفوفة الفارغة كدليل قاطع على غياب المحتوى المقابل.

استخدم نهج البيانات الوصفية الخفيف للجرد والفحوصات الأولية. حمّل العرض واستعرض نموذج كائنه الحي عندما يجب أن يعكس النتيجة تغييرات الذاكرة أو عندما تحتاج إلى التحقق من المحتوى الفعلي للعرض.

## **تحديث خصائص العرض**

يمكن أيضًا تغيير الخصائص التي تُعيدها [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/)؛ طبّق التغييرات باستخدام [IPresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentationinfo/updatedocumentproperties/)، ثم اكتب العرض المرتبط باستخدام [IPresentationInfo::WriteBindedPresentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentationinfo/writebindedpresentation/).

الصورة التالية تُظهر خصائص المستند الأصلية.

![خصائص المستند الأصلية للعرض PowerPoint](input_properties.png)

المثال التالي يغيّر العنوان ووقت الحفظ الأخير ويكتب النتيجة إلى ملف جديد:

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/date_time.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto sourceFile = String(u"sample.pptx");
auto outputFile = String(u"sample_with_updated_properties.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(sourceFile);
auto documentProperties = presentationInfo->ReadDocumentProperties();

documentProperties->set_Title(u"Quarterly sales report");
documentProperties->set_LastSavedTime(DateTime::get_UtcNow());

presentationInfo->UpdateDocumentProperties(documentProperties);
presentationInfo->WriteBindedPresentation(outputFile);
```

الصورة التالية تُظهر خصائص المستند المحدثة.

![خصائص المستند التي تم تعديلها للعرض PowerPoint](output_properties.png)

## **روابط مفيدة**

للفحوصات الأمنية ذات الصلة وإعدادات الحماية، راجع المقالات التالية:

- [Password-Protect Presentations](/slides/ar/cpp/password-protected-presentation/)
- [Write-Protect Presentations](/slides/ar/cpp/write-protected-presentation/)

## **الأسئلة المتكررة**

**كيف يمكنني التحقق مما إذا كانت الخطوط مضمنة وما هي؟**

حمل العرض واستخدم [Presentation::get_FontsManager](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_fontsmanager/). استدعِ [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsmanager/getembeddedfonts/) للحصول على الخطوط المضمنة و[FontsManager::GetFonts](https://reference.aspose.com/slides/ar/cpp/aspose.slides/fontsmanager/getfonts/) للحصول على الخطوط المستخدمة في العرض. قارن النتيجتين لتحديد الخطوط المطلوبة للعرض ولكن غير المضمنة.

**كيف يمكنني بسرعة معرفة ما إذا كان الملف يحتوي على شرائح مخفية وعددها؟**

عند كون البيانات الوصفية المخزنة كافية، اقرأ [IDocumentProperties::get_HiddenSlides](https://reference.aspose.com/slides/ar/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) عبر [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) و[IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/). هذا مناسب لجرد خفيف. إذا تم تعديل العرض في الذاكرة، قد تكون البيانات الوصفية المخزنة مفقودة أو قديمة، أو إذا أردت التحقق من القيم الحية، استعرض [Presentation::get_Slides](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_slides/) وتفحص طريقة [Slide::get_Hidden](https://reference.aspose.com/slides/ar/cpp/aspose.slides/slide/get_hidden/) لكل شريحة بدلاً من ذلك.

**هل يمكنني اكتشاف ما إذا كان حجم الشريحة المخصص والاتجاه مستخدمان، وما إذا كانا يختلفان عن الإعدادات الافتراضية؟**

نعم. حمّل العرض واقرأ [Presentation::get_SlideSize](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_slidesize/). افحص [ISlideSize::get_Type](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidesize/get_type/)، [ISlideSize::get_Size](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidesize/get_size/)، و[ISlideSize::get_Orientation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/islidesize/get_orientation/) لمقارنة الإعدادات الحالية مع القالب والأبعاد المتوقعة.

**هل هناك طريقة سريعة لمعرفة ما إذا كانت المخططات تشير إلى مصادر بيانات خارجية؟**

نعم. ابحث عن كل [Chart](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/chart/) وتفحص [ChartData::get_DataSourceType](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/chartdata/get_datasourcetype/). للمصادر الخارجية، اقرأ [ChartData::get_ExternalWorkbookPath](https://reference.aspose.com/slides/ar/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/). نوع مصدر البيانات والمسار يحددان الإشارة الخارجية، لكن التحقق من توفر الهدف يتطلب فحص موارد منفصل.

**كيف يمكنني تقييم "الشرائح الثقيلة" التي قد تبطئ العرض أو تصدير PDF؟**

لا توجد خاصية تعقيد واحدة. استعرض [Presentation::get_Slides](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/get_slides/) ومجموعة [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ibaseslide/get_shapes/) لكل شريحة. استخدم عدد الأشكال ووجود صور كبيرة، تأثيرات، رسوم متحركة، أو وسائط متعددة كإشارات تصنيف، وقم بقياس عرض تمثيلي أو تصدير قبل اعتبار الشريحة عنق زجاجة أداء مؤكد.