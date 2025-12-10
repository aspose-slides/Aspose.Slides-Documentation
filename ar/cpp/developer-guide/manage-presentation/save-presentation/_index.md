---
title: حفظ العروض التقديمية في C++
linktitle: حفظ العرض التقديمي
type: docs
weight: 80
url: /ar/cpp/save-presentation/
keywords:
- حفظ PowerPoint
- حفظ OpenDocument
- حفظ العرض التقديمي
- حفظ الشريحة
- حفظ PPT
- حفظ PPTX
- حفظ ODP
- العرض التقديمي إلى ملف
- العرض التقديمي إلى تدفق
- نوع العرض المحدد مسبقًا
- تنسيق Office Open XML الصارم
- وضع Zip64
- تحديث الصورة المصغرة
- تقدم الحفظ
- C++
- Aspose.Slides
description: "اكتشف كيفية حفظ العروض التقديمية في C++ باستخدام Aspose.Slides—التصدير إلى PowerPoint أو OpenDocument مع الحفاظ على التخطيطات والخطوط والتأثيرات."
---

## **نظرة عامة**

[فتح العروض التقديمية في C++](/slides/ar/cpp/open-presentation/) يوضح كيفية استخدام فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) لفتح عرض تقديمي. يشرح هذا المقال كيفية إنشاء وحفظ العروض التقديمية. فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) تحتوي على محتويات العرض التقديمي. سواء كنت تقوم بإنشاء عرض تقديمي من الصفر أو تعديل عرض موجود، ستحتاج إلى حفظه عند الانتهاء. باستخدام Aspose.Slides for C++، يمكنك الحفظ إلى **ملف** أو **تيار**. يشرح هذا المقال طرق الحفظ المختلفة للعرض التقديمي.

## **حفظ العروض التقديمية إلى ملفات**

احفظ عرضًا تقديميًا إلى ملف عن طريق استدعاء طريقة `Save` لفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/). مرّر اسم الملف وتنسيق الحفظ إلى الطريقة. المثال التالي يوضح كيفية حفظ عرض تقديمي باستخدام Aspose.Slides.
```cpp
// إنشاء كائن فئة Presentation التي تمثل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>();

// قم ببعض العمل هنا...

// حفظ العرض التقديمي إلى ملف.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```


## **حفظ العروض التقديمية إلى التيارات**

يمكنك حفظ عرض تقديمي إلى تدفق عن طريق تمرير تدفق إخراج إلى طريقة `Save` لفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/). يمكن كتابة العرض التقديمي إلى أنواع متعددة من التيارات. في المثال أدناه، نقوم بإنشاء عرض تقديمي جديد وحفظه إلى تدفق ملف.
```cpp
// إنشاء كائن فئة Presentation التي تمثل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// حفظ العرض التقديمي إلى الدفق.
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```


## **حفظ العروض التقديمية بنمط عرض محدد مسبقًا**

يتيح لك Aspose.Slides ضبط طريقة العرض الأولية التي يستخدمها PowerPoint عند فتح العرض التقديمي المُنشأ عبر فئة [ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/). استخدم طريقة [set_LastView](https://reference.aspose.com/slides/cpp/aspose.slides/viewproperties/set_lastview/) مع قيمة من تعداد [ViewType](https://reference.aspose.com/slides/cpp/aspose.slides/viewtype/).
```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);

presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **حفظ العروض التقديمية بتنسيق Office Open XML الصارم**

يتيح لك Aspose.Slides حفظ عرض تقديمي بتنسيق Office Open XML الصارم. استخدم فئة [PptxOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pptxoptions/) واضبط خاصية الامتثال عند الحفظ. إذا قمت بتعيين `Conformance.Iso29500_2008_Strict`، يتم حفظ ملف الإخراج بتنسيق Office Open XML الصارم.

المثال أدناه ينشئ عرضًا تقديميًا ويحفظه بتنسيق Office Open XML الصارم.
```cpp
auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

// إنشاء كائن فئة Presentation التي تمثل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>();

// حفظ العرض التقديمي بتنسيق Office Open XML الصارم.
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```


## **حفظ العروض التقديمية بتنسيق Office Open XML في وضع Zip64**

ملف Office Open XML هو أرشيف ZIP يفرض حدودًا بحجم 4 جيجابايت (2^32 بايت) على الحجم غير المضغوط لأي ملف، وحجم الضغط لأي ملف، وإجمالي حجم الأرشيف، ويقيد الأرشيف أيضًا بحد 65,535 (2^16‑1) ملف. تمدادات تنسيق ZIP64 ترفع هذه الحدود إلى 2^64.

تتيح لك طريقة [IPptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/cpp/aspose.slides.export/ipptxoptions/set_zip64mode/) اختيار متى تستخدم امتدادات تنسيق ZIP64 عند حفظ ملف Office Open XML.

يمكن استخدام هذه الطريقة مع الأوضاع التالية:

- `IfNecessary` يستخدم امتدادات تنسيق ZIP64 فقط إذا تجاوز العرض التقديمي الحدود المذكورة أعلاه. هذا هو الوضع الافتراضي.
- `Never` لا يستخدم أبدًا امتدادات تنسيق ZIP64.
- `Always` دائمًا يستخدم امتدادات تنسيق ZIP64.

الكود التالي يوضح كيفية حفظ عرض تقديمي كملف PPTX مع تمكين امتدادات تنسيق ZIP64:
```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```


{{% alert title="NOTE" color="warning" %}}
عند الحفظ باستخدام `Zip64Mode.Never`، يتم إلقاء استثناء [PptxException](https://reference.aspose.com/slides/cpp/aspose.slides/pptxexception/) إذا تعذر حفظ العرض التقديمي بتنسيق ZIP32.
{{% /alert %}}

## **حفظ العروض التقديمية دون تحديث الصورة المصغرة**

تتحكم طريقة [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) في إنشاء الصورة المصغرة عند حفظ العرض التقديمي إلى PPTX:

- إذا تم تعيينها إلى `true`، يتم تحديث الصورة المصغرة أثناء الحفظ. هذا هو الوضع الافتراضي.
- إذا تم تعيينها إلى `false`، يتم الحفاظ على الصورة المصغرة الحالية. إذا لم يكن للعرض التقديمي صورة مصغرة، فلن تُنشأ أي صورة.

في الكود أدناه، يتم حفظ العرض التقديمي إلى PPTX دون تحديث صورته المصغرة.
```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```


{{% alert title="Info" color="info" %}}
هذا الخيار يساعد على تقليل الوقت المستغرق لحفظ عرض تقديمي بتنسيق PPTX.
{{% /alert %}}

## **تحديثات تقدم الحفظ بالنسبة المئوية**

يتم استخدام واجهة [IProgressCallback](https://reference.aspose.com/slides/cpp/aspose.slides/iprogresscallback/) عبر طريقة `set_ProgressCallback` التي يُظهرها واجهة [ISaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/isaveoptions/) وفئة [SaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/) المجردة. عيّن تنفيذًا لـ [IProgressCallback](https://reference.aspose.com/slides/cpp/aspose.slides/iprogresscallback/) باستخدام `set_ProgressCallback` لتلقي تحديثات تقدم الحفظ كنسبة مئوية.

الكود التالي يوضح كيفية استخدام `IProgressCallback`.
```cpp
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue)
    {
        // استخدم قيمة النسبة المئوية للتقدم هنا.
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};
```

```cpp
auto saveOptions = MakeObject<PdfOptions>();
saveOptions->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, saveOptions);
presentation->Dispose();
```


{{% alert title="Info" color="info" %}}
قامت Aspose بتطوير تطبيق [مقسم PowerPoint مجاني](https://products.aspose.app/slides/splitter) باستخدام واجهتها البرمجية. يسمح لك التطبيق بتقسيم عرض تقديمي إلى ملفات متعددة عن طريق حفظ الشرائح المختارة كملفات PPTX أو PPT جديدة.
{{% /alert %}}

## **الأسئلة الشائعة**

**هل يتم دعم "الحفظ السريع" (الحفظ المتدرج) بحيث تُكتب التغييرات فقط؟**

لا. كل عملية حفظ تُنشيء الملف الهدف بالكامل في كل مرة؛ لا يُدعم الحفظ المتدرج "السريع".

**هل من الآمن من الناحية المتوازية حفظ نفس كائن Presentation من عدة خيوط؟**

لا. كائن [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) ليس [آمنًا للموضوعات المتعددة](/slides/ar/cpp/multithreading/); احفظه من خيط واحد.

**ماذا يحدث للروابط التشعبية والملفات المرتبطة خارجيًا عند الحفظ؟**

[الروابط التشعبية](/slides/ar/cpp/manage-hyperlinks/) تُحفظ. الملفات المرتبطة خارجيًا (مثل الفيديوهات عبر مسارات نسبية) لا تُنسخ تلقائيًا — تأكد من بقاء المسارات المشار إليها قابلة للوصول.

**هل يمكنني تعيين/حفظ بيانات تعريف المستند (المؤلف، العنوان، الشركة، التاريخ)؟**

نعم. يتم دعم [خصائص المستند](/slides/ar/cpp/presentation-properties/) القياسية وسيتم كتابتها إلى الملف عند الحفظ.