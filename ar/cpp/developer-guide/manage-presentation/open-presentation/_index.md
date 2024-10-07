---
title: فتح العرض التقديمي - واجهة برمجة تطبيقات PowerPoint C++
linktitle: فتح العرض التقديمي
type: docs
weight: 20
url: /cpp/open-presentation/
keywords: "فتح PowerPoint, PPTX, PPT, فتح العرض التقديمي, تحميل العرض التقديمي, C++, CPP"
description: "فتح أو تحميل عرض تقديمي PPT, PPTX, ODP في C++"
---

بجانب إنشاء عروض PowerPoint من الصفر، يتيح لك Aspose.Slides فتح العروض التقديمية الحالية. بعد تحميل عرض تقديمي، يمكنك الحصول على معلومات حول العرض التقديمي، تحرير العرض التقديمي (محتوى الشرائح)، إضافة شرائح جديدة أو إزالة الشرائح الموجودة، إلخ.

## فتح العرض التقديمي

لفتح عرض تقديمي موجود، عليك ببساطة إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) وتمرير مسار الملف (للعرض التقديمي الذي تريد فتحه) إلى مُنشئها.

يوضح هذا الكود C++ كيفية فتح عرض تقديمي وأيضًا معرفة عدد الشرائح التي يحتوي عليها:

```c++
// مسار دليل المستندات.
String dataDir = u"";

// إنشاء مثيل من فئة Presentation وتمرير مسار الملف إلى مُنشئها
auto pres = System::MakeObject<Presentation>(dataDir + u"OpenPresentation.pptx");

// طباعة العدد الإجمالي للشرائح الموجودة في العرض التقديمي
Console::WriteLine(Convert::ToString(pres->get_Slides()->get_Count()));
```

## **فتح عرض تقديمي محمي بكلمة مرور**

عندما تحتاج إلى فتح عرض تقديمي محمي بكلمة مرور، يمكنك تمرير كلمة مرور عبر خاصية [get_Password()](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/get_password/) (من فئة [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/)) لفك تشفير العرض التقديمي وتحميله. يوضح هذا الكود C++ العمل:

```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);
// قم ببعض العمل مع العرض التقديمي المفكوك تشفيره
```

## فتح عرض تقديمي كبير

يوفر Aspose.Slides خيارات (خصوصًا خاصية [BlobManagementOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/)) ضمن فئة [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) للسماح لك بتحميل العروض التقديمية الكبيرة.

يوضح هذا الكود C++ عملية يتم فيها تحميل عرض تقديمي كبير (مثلاً بحجم 2GB):

```c++
String pathToVeryLargePresentationFile = u"veryLargePresentation.pptx";

{
    SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
    // دعونا نختار سلوك KeepLocked - سيتم قفل "veryLargePresentation.pptx" لمدة حياة مثيل العرض التقديمي،
    // ولكننا لسنا بحاجة لتحميله في الذاكرة أو نسخه إلى ملف مؤقت
    loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

    auto pres = System::MakeObject<Presentation>(pathToVeryLargePresentationFile, loadOptions);

    // تم تحميل العرض التقديمي الكبير ويمكن استخدامه، لكن استهلاك الذاكرة لا يزال منخفضًا.

    // إجراء تغييرات على العرض التقديمي.
    pres->get_Slides()->idx_get(0)->set_Name(u"عرض تقديمي كبير جدًا");

    // سيتم حفظ العرض التقديمي في ملف آخر. يبقى استهلاك الذاكرة منخفضًا خلال العملية
    pres->Save(u"veryLargePresentation-copy.pptx", SaveFormat::Pptx);

    // لا يمكن القيام بذلك! سيتم إلقاء استثناء IO لأن الملف مقفل بينما لن يتم التخلص من كائنات pres
    File::Delete(pathToVeryLargePresentationFile);
}

// من الجيد القيام بذلك هنا. الملف المصدر ليس مقفلاً بواسطة كائن pres
File::Delete(pathToVeryLargePresentationFile);
```

{{% alert color="info" title="معلومات" %}}

لتجاوز بعض القيود عند التفاعل مع التدفقات، قد يقوم Aspose.Slides بنسخ محتوى التدفق. سيؤدي تحميل عرض تقديمي كبير عبر تدفقه إلى نسخ محتويات العرض التقديمي والتسبب في تحميل بطيء. لذلك، عندما تنوي تحميل عرض تقديمي كبير، نوصي بشدة باستخدام مسار ملف العرض التقديمي وليس تدفقه.

عندما تريد إنشاء عرض تقديمي يحتوي على كائنات كبيرة (فيديو، صوت، صور كبيرة، إلخ)، يمكنك استخدام [تسهيلات Blob](https://docs.aspose.com/slides/cpp/manage-blob/) لتقليل استهلاك الذاكرة.

{{%/alert %}} 

## تحميل العرض التقديمي

يوفر Aspose.Slides [IResourceLoadingCallback](https://reference.aspose.com/slides/cpp/aspose.slides/iresourceloadingcallback/) مع طريقة واحدة للسماح لك بإدارة الموارد الخارجية. يوضح هذا الكود C++ كيفية استخدام واجهة `IResourceLoadingCallback`:

```c++
// مسار دليل المستندات.
System::String dataDir = GetDataPath();

auto opts = System::MakeObject<LoadOptions>();
opts->set_ResourceLoadingCallback(System::MakeObject<ImageLoadingHandler>(dataDir));
auto presentation = System::MakeObject<Presentation>(dataDir + u"presentation.pptx", opts);
```

```c++
class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ImageLoadingHandler(String dataDir)
        : m_dataDir(dataDir)
    {
    }

    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        if (args->get_OriginalUri().EndsWith(u".jpg"))
        {
            try
            {
                System::ArrayPtr<uint8_t> imageBytes = File::ReadAllBytes(Path::Combine(m_dataDir, u"aspose-logo.jpg"));
                args->SetData(imageBytes);
                return ResourceLoadingAction::UserProvided;
            }
            catch (System::Exception&)
            {
                return ResourceLoadingAction::Skip;
            }
        }

        if (args->get_OriginalUri().EndsWith(u".png"))
        {
            // تعيين عنوان URL بديل
            args->set_Uri(u"http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }

        // تخطي جميع الصور الأخرى
        return ResourceLoadingAction::Skip;
    }
    
private:
    String m_dataDir;
};
```

<h2>فتح وحفظ العرض التقديمي</h2>

<a name="cplusplus-open-save-presentation"><strong>الخطوات: فتح وحفظ العرض التقديمي في C++</strong></a>

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) وتمرير الملف الذي تريد فتحه. 

2. حفظ العرض التقديمي. 

   ```c++
   	const String outPath = u"../out/SaveToFile_out.ppt";
   	
   	SharedPtr<Presentation> pres = MakeObject<Presentation>();
   
   	// pres->get_ProtectionManager()->Encrypt(u"pass");
   	// ...قم ببعض العمل هنا..
   
   	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
   ```