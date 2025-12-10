---
title: فتح العروض التقديمية في C++
linktitle: فتح عرض تقديمي
type: docs
weight: 20
url: /ar/cpp/open-presentation/
keywords:
- فتح PowerPoint
- فتح OpenDocument
- فتح عرض تقديمي
- فتح PPTX
- فتح PPT
- فتح ODP
- تحميل عرض تقديمي
- تحميل PPTX
- تحميل PPT
- تحميل ODP
- عرض تقديمي محمي
- عرض تقديمي كبير
- مورد خارجي
- كائن ثنائي
- C++
- Aspose.Slides
description: "افتح عروض PowerPoint (.pptx, .ppt) وعروض OpenDocument (.odp) بسهولة باستخدام Aspose.Slides للـ C++ — سريع، موثوق، ومزود بجميع الميزات."
---

## **نظرة عامة**

بجانب إنشاء عروض PowerPoint من الصفر، تتيح لك Aspose.Slides أيضًا فتح العروض التقديمية الموجودة. بعد تحميل عرض تقديمي، يمكنك استرجاع معلومات عنه، تعديل محتوى الشريحة، إضافة شرائح جديدة، إزالة الشرائح الحالية، والمزيد.

## **فتح العروض التقديمية**

لفتح عرض تقديمي موجود، قم بإنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) ومرّر مسار الملف إلى مُنشئها.

المثال التالي بلغة C++ يوضح كيفية فتح عرض تقديمي والحصول على عدد الشرائح فيه:
```cpp
// إنشاء كائن من الفئة Presentation وتمرير مسار ملف إلى المُنشئ الخاص بها.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// اطبع العدد الإجمالي للشرائح في العرض التقديمي.
Console::WriteLine(presentation->get_Slides()->get_Count());

presentation->Dispose();
```


## **فتح العروض التقديمية المحمية بكلمة مرور**

عند الحاجة إلى فتح عرض تقديمي محمي بكلمة مرور، مرّر كلمة المرور عبر الطريقة [set_Password](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_password/) في الفئة [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) لفك التشفير وتحميله. يوضح الكود التالي بلغة C++ هذه العملية:
```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
    
// تنفيذ عمليات على العرض التقديمي المفكوك.

presentation->Dispose();
```


## **فتح العروض التقديمية الكبيرة**

توفر Aspose.Slides خيارات—وخاصة الطريقة [get_BlobManagementOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) في الفئة [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/)—لمساعدتك على تحميل عروض تقديمية كبيرة.

يُظهر الكود التالي بلغة C++ كيفية تحميل عرض تقديمي كبير (على سبيل المثال، 2 جيجابايت):
```cpp
auto filePath = u"LargePresentation.pptx";

auto loadOptions = MakeObject<LoadOptions>();
// اختر سلوك KeepLocked — سيبقى ملف العرض مقفلًا طوال عمر
// كائن Presentation، ولكن لا يلزم تحميله إلى الذاكرة أو نسخه إلى ملف مؤقت.
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
loadOptions->get_BlobManagementOptions()->set_IsTemporaryFilesAllowed(true);
loadOptions->get_BlobManagementOptions()->set_MaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 ميغابايت

auto presentation = MakeObject<Presentation>(filePath, loadOptions);

// تم تحميل العرض التقديمي الكبير ويمكن استخدامه، مع بقاء استهلاك الذاكرة منخفضًا.

// قم بإجراء تغييرات على العرض التقديمي.
presentation->get_Slide(0)->set_Name(u"Large presentation");

// احفظ العرض التقديمي إلى ملف آخر. يظل استهلاك الذاكرة منخفضًا أثناء هذه العملية.
presentation->Save(u"LargePresentation-copy.pptx", SaveFormat::Pptx);

// لا تفعل ذلك! سيُطرح استثناء I/O لأن الملف مقفل حتى يتم تحرير كائن العرض التقديمي.
File::Delete(filePath);

presentation->Dispose();

// يمكن القيام بذلك هنا. لم يعد ملف المصدر مقفلًا بواسطة كائن العرض التقديمي.
File::Delete(filePath);
```


{{% alert color="info" title="Info" %}}
لتجاوز بعض القيود عند العمل مع التدفقات، قد تقوم Aspose.Slides بنسخ محتويات التدفق. تحميل عرض تقديمي كبير من تدفق يؤدي إلى نسخ العرض وبالتالي قد يبطئ عملية التحميل. لذلك، عند الحاجة إلى تحميل عرض تقديمي كبير، نوصي بشدة باستخدام مسار ملف العرض بدلاً من التدفق.

عند إنشاء عرض تقديمي يحتوي على كائنات كبيرة (فيديو، صوت، صور عالية الدقة، إلخ)، يمكنك استخدام [BLOB management](/slides/ar/cpp/manage-blob/) لتقليل استهلاك الذاكرة.
{{%/alert %}}

## **التحكم في الموارد الخارجية**

توفر Aspose.Slides الواجهة [IResourceLoadingCallback](https://reference.aspose.com/slides/cpp/aspose.slides/iresourceloadingcallback/) التي تتيح لك إدارة الموارد الخارجية. يوضح الكود التالي بلغة C++ كيفية استخدام واجهة `IResourceLoadingCallback`:
```cpp
class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        if (args->get_OriginalUri().EndsWith(u".jpg"))
        {
            try
            {
                // تحميل صورة بديلة.
                auto imageData = File::ReadAllBytes(u"aspose-logo.jpg");
                args->SetData(imageData);
                return ResourceLoadingAction::UserProvided;
            }
            catch (Exception&)
            {
                return ResourceLoadingAction::Skip;
            }
        }
        else if (args->get_OriginalUri().EndsWith(u".png"))
        {
            // تعيين عنوان URL بديل.
            args->set_Uri(u"http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }

        // تخطي جميع الصور الأخرى.
        return ResourceLoadingAction::Skip;
    }
};
```

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_ResourceLoadingCallback(MakeObject<ImageLoadingHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
```


## **تحميل العروض التقديمية دون كائنات ثنائية مدمجة**

يمكن أن يحتوي عرض PowerPoint على الأنواع التالية من الكائنات الثنائية المدمجة:

- مشروع VBA (يمكن الوصول إليه عبر [IPresentation::get_VbaProject](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_vbaproject/));
- بيانات كائن OLE المدمجة (يمكن الوصول إليها عبر [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/));
- بيانات ثنائية للتحكم ActiveX (يمكن الوصول إليها عبر [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/cpp/aspose.slides/icontrol/get_activexcontrolbinary/)).

باستخدام الطريقة [ILoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/cpp/aspose.slides/iloadoptions/set_deleteembeddedbinaryobjects/) يمكنك تحميل عرض تقديمي دون أي كائنات ثنائية مدمجة.

هذه الطريقة مفيدة لإزالة المحتويات الثنائية التي قد تكون ضارة. يوضح الكود التالي بلغة C++ كيفية تحميل عرض تقديمي دون أي محتوى ثنائي مدمج:
```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_DeleteEmbeddedBinaryObjects(true);

auto presentation = MakeObject<Presentation>(u"malware.ppt", loadOptions);

// تنفيذ عمليات على العرض التقديمي.

presentation->Dispose();
```


## **الأسئلة المتكررة**

**كيف يمكنني معرفة أن الملف معطوب ولا يمكن فتحه؟**

ستحصل على استثناء أثناء التحميل يشير إلى فشل تحليل أو تحقق من تنسيق الملف. غالبًا ما تتضمن هذه الأخطاء ذكر بنية ZIP غير صالحة أو سجلات PowerPoint مكسورة.

**ماذا يحدث إذا كانت الخطوط المطلوبة مفقودة عند الفتح؟**

سيتم فتح الملف، لكن عملية [التصوير/التصدير](/slides/ar/cpp/convert-presentation/) قد تستبدل الخطوط. يمكنك [تكوين استبدالات الخطوط](/slides/ar/cpp/font-substitution/) أو [إضافة الخطوط المطلوبة](/slides/ar/cpp/custom-font/) إلى بيئة التشغيل.

**ماذا عن الوسائط المدمجة (فيديو/صوت) عند الفتح؟**

تصبح الوسائط متاحة كموارد للعرض. إذا كانت الوسائط مشيرة إلى مسارات خارجية، تأكد من أن تلك المسارات متاحة في بيئتك؛ وإلا قد تقوم عملية [التصوير/التصدير](/slides/ar/cpp/convert-presentation/) بإهمال الوسائط.