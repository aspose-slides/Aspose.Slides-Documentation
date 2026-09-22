---
title: فتح العروض في C++
linktitle: فتح عرض
type: docs
weight: 20
url: /ar/cpp/open-presentation/
keywords:
- فتح PowerPoint
- فتح OpenDocument
- فتح عرض
- فتح PPTX
- فتح PPT
- فتح ODP
- تحميل عرض
- تحميل PPTX
- تحميل PPT
- تحميل ODP
- عرض محمي
- عرض كبير
- مورد خارجي
- كائن ثنائي
- C++
- Aspose.Slides
description: "تعلم كيفية فتح عروض PowerPoint و OpenDocument في C++، وتوفير كلمات مرور الفتح، والتحكم في تحميل الموارد، وتقليل استخدام الذاكرة باستخدام Aspose.Slides لـ C++."
---
## **المقدمة**

[Aspose.Slides for C++](https://products.aspose.com/slides/ar/cpp/) يمكنه تحميل عروض PowerPoint وOpenDocument من الملفات والتدفقات. بعد تحميل العرض، يمكنك فحص هيكله، تعديل الشرائح، إدارة الموارد، وحفظه بالتنسيق الأصلي أو أي تنسيق مدعوم آخر.

يمكن تخصيص سلوك التحميل من خلال فئة [LoadOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides/loadoptions/). على سبيل المثال، يمكنك تزويده بكلمة مرور الفتح، إبقاء الكائنات الثنائية الكبيرة خارج الذاكرة، التحكم في الموارد الخارجية، أو حذف البيانات الثنائية المضمنة.

## **فتح العروض**

بعد تحميل ملف أو تدفق، يمكنك [تحديد تنسيق العرض الأصلي](/slides/ar/cpp/detect-presentation-source-format/) لاختيار طريقة معالجة التطبيق له.

لفتح عرض موجود، مرّر مسار ملفه إلى مُنشئ [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/). قم بتحرير العرض بعد الاستخدام حتى يتم تحرير مقبض الملف والبيانات المؤقتة وغيرها من الموارد بسرعة.

يوضح المثال التالي بلغة C++ كيفية فتح عرض والحصول على عدد الشرائح فيه:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **فتح العروض المحمية بكلمة مرور**

كلمة مرور الفتح تشفر محتوى العرض. لتحميل العرض بالكامل، مرّر كلمة المرور الصحيحة إلى [LoadOptions::set_Password](https://reference.aspose.com/slides/ar/cpp/aspose.slides/loadoptions/set_password/) ومرّر الخيارات إلى مُنشئ [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/). سيفشل التحميل إذا كانت كلمة المرور مفقودة أو غير صحيحة.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = MakeObject<Presentation>(u"encrypted-presentation.pptx", loadOptions);

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

للتعرف على كلمة المرور، التحقق، وسير عمل التشفير، راجع [Password-Protect Presentations](/slides/ar/cpp/password-protected-presentation/). إذا تم حفظ عرض مشفر مع خصائص مستند عامة عمدًا، يمكن قراءة تلك الخصائص بدون كلمة مرور؛ انظر [Manage Presentation Properties](/slides/ar/cpp/presentation-properties/).

## **فتح العروض الكبيرة**

[LoadOptions::get_BlobManagementOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) يتحكم في طريقة معالجة Aspose.Slides للكائنات الثنائية الكبيرة مثل الصور والصوت والفيديو. يمكنك إبقاء ملف المصدر مقفولًا، السماح بإنشاء ملفات مؤقتة، وتقييد كمية بيانات BLOB المحتفظ بها في الذاكرة.

يوضح الكود التالي بلغة C++ طريقة تحميل عرض كبير (على سبيل المثال، 2 جيجابايت):

```cpp
#include <DOM/ISlide.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IBlobManagementOptions.h>
#include <PresentationLockingBehavior.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

const String filePath = u"large-presentation.pptx";

auto loadOptions = MakeObject<LoadOptions>();
auto blobOptions = loadOptions->get_BlobManagementOptions();
blobOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobOptions->set_IsTemporaryFilesAllowed(true);
blobOptions->set_MaxBlobsBytesInMemory(10 * 1024 * 1024);

auto presentation = MakeObject<Presentation>(filePath, loadOptions);

presentation->get_Slide(0)->set_Name(u"Large presentation");
presentation->Save(u"large-presentation-copy.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
مع `PresentationLockingBehavior::KeepLocked` يبقى ملف المصدر مقفولًا حتى يتم تحرير كائن `Presentation`. لا تقم بنقل أو استبدال أو حذف ملف المصدر أثناء بقاء هذا الكائن حيًا.

قد تقوم Aspose.Slides بنسخ محتويات تدفق الإدخال أثناء تحميله. بالنسبة للعروض الكبيرة، يكون مسار الملف عادة أكثر كفاءة من التدفق. راجع [Manage BLOBs](/slides/ar/cpp/manage-blob/) للحصول على خيارات إضافية لتخزين وإدارة الذاكرة.
{{% /alert %}}

## **التحكم في الموارد الخارجية**

[LoadOptions::set_ResourceLoadingCallback](https://reference.aspose.com/slides/ar/cpp/aspose.slides/loadoptions/set_resourceloadingcallback/) يقبل تنفيذًا لـ [IResourceLoadingCallback](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iresourceloadingcallback/). يمكن للنداء العكسي تزويد بيانات بديلة، إعادة توجيه مورد، استخدام المحمل الافتراضي، أو تخطي المورد. هذا مفيد عندما تحتوي العروض على صور خارجية يجب حلها وفقًا لقواعد الأمان أو التخزين المحددة من قبل التطبيق.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IResourceLoadingArgs.h>
#include <IResourceLoadingCallback.h>
#include <ResourceLoadingAction.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        auto isJpeg = args->get_OriginalUri().EndsWith(u".jpg", StringComparison::OrdinalIgnoreCase);
        if (!isJpeg || !File::Exists(u"approved-image.jpg"))
        {
            return ResourceLoadingAction::Skip;
        }

        auto imageData = File::ReadAllBytes(u"approved-image.jpg");
        args->SetData(imageData);
        return ResourceLoadingAction::UserProvided;
    }
};

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_ResourceLoadingCallback(MakeObject<ImageLoadingHandler>());

auto presentation = MakeObject<Presentation>(u"presentation-with-external-images.pptx", loadOptions);
Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **تحميل العروض دون الكائنات الثنائية المضمنة**

قد يحتوي العرض على بيانات ثنائية مدمجة لا يحتاجها التطبيق أو لا يرغب في الاحتفاظ بها. من الأمثلة:

- مشروعات VBA، متاحة عبر [IPresentation::get_VbaProject](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/get_vbaproject/)؛
- بيانات OLE المدمجة، متاحة عبر [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/)؛
- بيانات عناصر التحكم ActiveX، متاحة عبر [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icontrol/get_activexcontrolbinary/)؛

مرّر `true` إلى [LoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ar/cpp/aspose.slides/loadoptions/set_deleteembeddedbinaryobjects/) لإزالة هذه البيانات الثنائية أثناء التحميل. احفظ العرض المحمل لتثبيت النتيجة المنقاة.

هذا الخيار يقلل من التعرض للحمولات المدمجة غير المرغوب فيها، لكنه ليس نظامًا كاملاً لاكتشاف البرمجيات الخبيثة أو تنقية المحتوى.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_DeleteEmbeddedBinaryObjects(true);

auto presentation = MakeObject<Presentation>(u"presentation-with-embedded-data.pptx", loadOptions);

presentation->Save(u"presentation-without-embedded-data.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **الأسئلة المتكررة**

**كيف يمكنني معرفة أن الملف تالف ولا يمكن فتحه؟**

تطرح Aspose.Slides استثناءً يتعلق بالتحليل أو التنسيق أثناء التحميل. عالج هذا الفشل منفصلًا عن خطأ كلمة المرور الخاطئة حتى يتمكن التطبيق من الإبلاغ عن السبب بدقة.

**ماذا يحدث إذا كانت الخطوط المطلوبة مفقودة؟**

لا يزال بالإمكان تحميل العرض، لكن قد يتم استبدال الخطوط أثناء العرض والتصدير. يمكنك [تكوين استبدال الخطوط](/slides/ar/cpp/font-substitution/) أو [توفير خطوط مخصصة](/slides/ar/cpp/custom-font/) لجعل الإخراج أكثر توقعًا.

**هل تحميل العرض يحمل أيضًا وسائطه المدمجة؟**

تصبح ملفات الصوت والفيديو المدمجة متاحة عبر نموذج كائن العرض. تُحل الموارد الخارجية وفقًا لسلوك تحميل الموارد المُكوَّن وقد تكون غير متاحة إذا تعذّر الوصول إلى مواقعها.