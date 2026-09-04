---
title: فتح العروض في C++
linktitle: فتح عرض
type: docs
weight: 20
url: /ar/cpp/open-presentation/
keywords:
- فتح PowerPoint
- فتح OpenDocument
- فتح العرض
- فتح PPTX
- فتح PPT
- فتح ODP
- تحميل العرض
- تحميل PPTX
- تحميل PPT
- تحميل ODP
- عرض محمي
- عرض كبير
- مورد خارجي
- كائن ثنائي
- C++
- Aspose.Slides
description: "تعلم كيفية فتح عروض PowerPoint و OpenDocument في C++، توفير كلمات مرور للفتح، التحكم في تحميل الموارد، وتقليل استخدام الذاكرة باستخدام Aspose.Slides for C++."
---
## **المقدمة**

[Aspose.Slides for C++](https://products.aspose.com/slides/ar/cpp/) يمكنه تحميل عروض PowerPoint و OpenDocument من الملفات وتدفقات البيانات. بعد تحميل العرض، يمكنك فحص هيكله، تعديل الشرائح، إدارة الموارد، وحفظه بالتنسيق الأصلي أو بأي تنسيق مدعوم آخر.

يمكن تخصيص سلوك التحميل عبر صنف [LoadOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides/loadoptions/). على سبيل المثال، يمكنك توفير كلمة مرور للفتح، إبقاء الكائنات الثنائية الكبيرة خارج الذاكرة، التحكم في الموارد الخارجية، أو حذف البيانات الثنائية المدمجة.

## **فتح العروض**

لفتح عرض موجود، مرّر مسار الملف إلى مُنشئ [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/). حرّر (Dispose) العرض بعد الاستخدام لكي يتم تحرير مؤشرات الملفات والبيانات المؤقتة وغيرها من الموارد بسرعة.

يعرض المثال التالي بلغة C++ كيفية فتح عرض والحصول على عدد الشرائح:

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

كلمة المرور عند الفتح تقوم بتشفير محتوى العرض. لتحميل العرض بالكامل، مرّر كلمة المرور الصحيحة إلى [LoadOptions::set_Password](https://reference.aspose.com/slides/ar/cpp/aspose.slides/loadoptions/set_password/) ومرّر الخيارات إلى مُنشئ [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/). سيفشل التحميل إذا كانت كلمة المرور مفقودة أو غير صحيحة.

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

لقواعد اكتشاف كلمة المرور، والتحقق منها، وسير عمل التشفير، راجع [Password-Protect Presentations](/slides/ar/cpp/password-protected-presentation/). إذا تم حفظ عرض مشفر مع خصائص المستند العامة عن قصد، يمكن قراءة تلك الخصائص بدون كلمة مرور؛ راجع [Manage Presentation Properties](/slides/ar/cpp/presentation-properties/).

## **فتح العروض الكبيرة**

[LoadOptions::get_BlobManagementOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) يتحكم في كيفية تعامل Aspose.Slides مع الكائنات الثنائية الكبيرة مثل الصور، الصوت، والفيديو. يمكنك إبقاء ملف المصدر مقفلًا، السماح بالملفات المؤقتة، وتحديد كمية بيانات BLOB التي تُحتفظ في الذاكرة.

يعرض الكود التالي بلغة C++ كيفية تحميل عرض كبير (مثلاً 2 جيجابايت):

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

مع `PresentationLockingBehavior::KeepLocked`، يظل ملف المصدر مقفلًا حتى يتم تحرير كائن `Presentation`. لا تقم بنقل أو استبدال أو حذف ملف المصدر أثناء بقاء هذا الكائن حيًا.

قد يقوم Aspose.Slides بنسخ محتويات تدفق الإدخال أثناء تحميله. بالنسبة للعروض الكبيرة، يكون مسار الملف أكثر كفاءة عادةً من التدفق. راجع [Manage BLOBs](/slides/ar/cpp/manage-blob/) للحصول على خيارات إضافية للتخزين وإدارة الذاكرة.

{{% /alert %}}

## **التحكم في الموارد الخارجية**

[LoadOptions::set_ResourceLoadingCallback](https://reference.aspose.com/slides/ar/cpp/aspose.slides/loadoptions/set_resourceloadingcallback/) يقبل تنفيذًا لـ [IResourceLoadingCallback](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iresourceloadingcallback/). يمكن للرد المنادى (callback) توفير بيانات بديلة، إعادة توجيه مورد، استخدام أداة التحميل الافتراضية، أو تخطي المورد. هذا مفيد عندما تحتوي العروض على صور خارجية يجب حلها وفقًا لقواعد الأمان أو التخزين الخاصة بالتطبيق.

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

## **تحميل العروض دون كائنات ثنائية مدمجة**

قد يحتوي العرض على بيانات ثنائية مدمجة لا يحتاجها التطبيق أو لا يرغب في الاحتفاظ بها. تشمل الأمثلة:

- مشاريع VBA، المتاحة عبر [IPresentation::get_VbaProject](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ipresentation/get_vbaproject/);
- بيانات OLE مدمجة، المتاحة عبر [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/);
- بيانات تحكم ActiveX، المتاحة عبر [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/ar/cpp/aspose.slides/icontrol/get_activexcontrolbinary/).

مرّر `true` إلى [LoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ar/cpp/aspose.slides/loadoptions/set_deleteembeddedbinaryobjects/) لإزالة هذه البيانات الثنائية أثناء التحميل. احفظ العرض المحمل لتثبيت النتيجة المنقاة.

يقلل هذا الخيار من التعرض للحمولات المدمجة غير المرغوب فيها، لكنه ليس نظامًا كاملاً لاكتشاف البرامج الضارة أو تنقية المحتوى.

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

## **الأسئلة الشائعة**

**كيف يمكنني معرفة أن الملف تالف ولا يمكن فتحه؟**

يقوم Aspose.Slides برمي استثناء تحليل أو تنسيق أثناء التحميل. تعامل مع هذا الفشل بشكل منفصل عن خطأ كلمة المرور غير الصحيحة حتى يتمكن التطبيق من الإبلاغ عن السبب بدقة.

**ماذا يحدث إذا كانت الخطوط المطلوبة مفقودة؟**

لا يزال بإمكان العرض التحميل، لكن قد يتم استبدال الخطوط أثناء العرض والتصدير. يمكنك تكوين استبدال الخطوط أو توفير خطوط مخصصة لجعل الناتج أكثر توقعًا.

**هل يقوم تحميل العرض أيضًا بتحميل الوسائط المدمجة؟**

تصبح ملفات الصوت والفيديو المدمجة متاحة عبر نموذج كائن العرض. يتم حل الموارد الخارجية وفقًا لسلوك تحميل الموارد المُكوَّن وقد تكون غير متاحة إذا لم يمكن الوصول إلى مواقعها.