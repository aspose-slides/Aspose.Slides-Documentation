---
title: إدارة OLE
type: docs
weight: 40
url: /cpp/manage-ole/
keywords:
- إضافة OLE
- تضمين OLE
- إضافة كائن
- تضمين كائن
- تضمين ملف
- كائن مرتبط
- ربط الكائنات وتضمينها
- كائن OLE
- PowerPoint 
- عرض تقديمي
- C++
- Aspose.Slides لـ C++
description: إضافة كائنات OLE إلى عروض PowerPoint في C++
---

{{% alert title="معلومات" color="info" %}}

OLE (ربط الكائنات وتضمينها) هي تقنية من مايكروسوفت تسمح بدمج البيانات والكائنات التي تم إنشاؤها في تطبيق واحد داخل تطبيق آخر من خلال الربط أو التضمين.

{{% /alert %}} 

اعتبر رسمًا بيانيًا تم إنشاؤه في MS Excel. يتم بعد ذلك وضع الرسم البياني داخل شريحة PowerPoint. يتم اعتبار هذا الرسم البياني من Excel ككائن OLE.

- قد يظهر كائن OLE كأيقونة. في هذه الحالة، عند النقر المزدوج على الأيقونة، يتم فتح الرسم البياني في تطبيقه المرتبط (Excel)، أو يُطلب منك اختيار تطبيق لفتح الكائن أو تحريره.
- قد يعرض كائن OLE المحتويات الفعلية—على سبيل المثال، محتويات الرسم البياني. في هذه الحالة، يتم تفعيل الرسم البياني في PowerPoint، ويُحمّل واجهة الرسم البياني، وتتمكن من تعديل بيانات الرسم البياني داخل تطبيق PowerPoint.

[Aspose.Slides لـ C++](https://products.aspose.com/slides/cpp/) يتيح لك إدراج كائنات OLE في الشرائح كإطارات كائن OLE ([OleObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame)).


## **إضافة إطارات كائن OLE إلى الشرائح**

افترض أنك قد أنشأت بالفعل رسمًا بيانيًا في Microsoft Excel وترغب في تضمين ذلك الرسم البياني في شريحة كإطار كائن OLE باستخدام Aspose.Slides لـ C++، يمكنك القيام بذلك بهذه الطريقة:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) .
2. احصل على مرجع الشريحة من خلال فهرسها.
3. افتح ملف Excel الذي يحتوي على كائن الرسم البياني من Excel واحفظه إلى `MemoryStream`.
4. أضف [OleObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame) إلى الشريحة التي تحتوي على مصفوفة البايت ومعلومات أخرى عن كائن OLE.
5. اكتب العرض المعدل كملف PPTX.

في المثال أدناه، أضفنا رسمًا بيانيًا من ملف Excel إلى شريحة كإطار [OleObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame) باستخدام Aspose.Slides لـ C++.  
**ملاحظة** أن منشئ [IOleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_ole_embedded_data_info) يأخذ ملحق كائن قابلة للتضمين كمعامل ثانٍ. يسمح هذا الملحق لـ PowerPoint بتفسير نوع الملف بشكل صحيح واختيار التطبيق المناسب لفتح كائن OLE هذا.

``` cpp
// مسار دليل الوثائق.
String dataDir = u"";
// ينشئ مثيل فئة Presentation التي تمثل PPTX
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// الوصول إلى الشريحة الأولى
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);
// تحميل ملف Excel إلى تدفق
SharedPtr<MemoryStream> mstream = System::MakeObject<MemoryStream>();

SharedPtr<FileStream> fs = System::MakeObject<FileStream>(dataDir + u"book1.xlsx", FileMode::Open, FileAccess::Read);

ArrayPtr<uint8_t> buf = System::MakeArray<uint8_t>(4096, 0);
while (true)
{
    int32_t bytesRead = fs->Read(buf, 0, buf->get_Length());
    if (bytesRead <= 0)
    {
        break;
    }
    mstream->Write(buf, 0, bytesRead);
}

// إنشاء كائن بيانات للتضمين
SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(mstream->ToArray(), u"xlsx");
// إضافة شكل إطار كائن Ole
SharedPtr<IOleObjectFrame> oleObjectFrame = sld->get_Shapes()->AddOleObjectFrame(0.0f, 0.0f, pres->get_SlideSize()->get_Size().get_Width(), pres->get_SlideSize()->get_Size().get_Height(), dataInfo);
// كتابة ملف PPTX إلى القرص
pres->Save(dataDir + u"OleEmbed_out.pptx", SaveFormat::Pptx);
```

## **الوصول إلى إطارات كائن OLE**
إذا كان كائن OLE مضمنًا بالفعل في شريحة، يمكنك العثور على ذلك الكائن أو الوصول إليه بسهولة بهذه الطريقة:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) .

2. احصل على مرجع الشريحة باستخدام فهرسها.

3. الوصول إلى شكل [OleObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame) .

   في مثالنا، استخدمنا PPTX المسبق الإنشاء الذي يحتوي فقط على شكل واحد في الشريحة الأولى. ثم قمنا بـ *cast* ذلك الكائن كإطار [OleObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame). كان هذا هو إطار كائن OLE المراد الوصول إليه.

4. بمجرد الوصول إلى إطار كائن OLE، يمكنك إجراء أي عملية عليه.

في المثال أدناه، يتم الوصول إلى إطار كائن OLE (كائن رسم بياني من Excel مضمن في شريحة)---ثم تتم كتابة بيانات ملفه إلى ملف Excel:

``` cpp
// مسار دليل الوثائق.
const String templatePath = u"../templates/AccessingOLEObjectFrame.pptx";

// تحميل العرض التقديمي المطلوب
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// الوصول إلى الشريحة الأولى
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// تحويل الشكل إلى OleObjectFrame
SharedPtr<OleObjectFrame> oleObjectFrame = System::AsCast<OleObjectFrame>(sld->get_Shapes()->idx_get(0));

// قراءة كائن OLE وكتابته إلى القرص
if (oleObjectFrame != nullptr)
{
    // الحصول على بيانات الملف المضمن
    ArrayPtr<uint8_t> data = oleObjectFrame->get_EmbeddedFileData();

    // الحصول على ملحق الملف المضمن
    String fileExtention = oleObjectFrame->get_EmbeddedFileExtension();

    // إنشاء مسار لحفظ الملف المستخرج
    String extractedPath = Path::Combine(GetOutPath(), u"excelFromOLE_out" + fileExtention);

    // حفظ البيانات المستخرجة
    SharedPtr<FileStream> fstr = System::MakeObject<FileStream>(extractedPath, FileMode::Create, FileAccess::Write);
    fstr->Write(data, 0, data->get_Length());
}
```

## **تغيير بيانات كائن OLE**
إذا كان كائن OLE مضمنًا بالفعل في شريحة، يمكنك بسهولة الوصول إلى ذلك الكائن وتعديل بياناته بهذه الطريقة:

1. افتح العرض التقديمي المطلوب مع كائن OLE المضمن عن طريق إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) .

2. احصل على مرجع الشريحة من خلال فهرسها. 

3. الوصول إلى شكل [OLEObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame) .

   في مثالنا، استخدمنا PPTX المسبق الإنشاء الذي يحتوي على شكل واحد في الشريحة الأولى. ثم قمنا بـ *cast* ذلك الكائن كإطار [OLEObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame). كان هذا هو إطار كائن OLE المراد الوصول إليه.

4. بمجرد الوصول إلى إطار كائن OLE، يمكنك إجراء أي عملية عليه.

5. إنشاء كائن Workbook والوصول إلى بيانات OLE.

6. الوصول إلى ورقة العمل المطلوبة وتعديل البيانات.

7. حفظ Workbook المحدث في التدفقات.

8. تغيير بيانات كائن OLE من بيانات التدفق.

في المثال أدناه، يتم الوصول إلى إطار كائن OLE (كائن رسم بياني من Excel مضمن في شريحة)---ثم يتم تعديل بيانات ملفه لتغيير بيانات الرسم البياني:

``` cpp
intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> ToCellsMemoryStream(System::ArrayPtr<uint8_t> buffer)
{
    intrusive_ptr<BString> array = new BString(buffer->data_ptr(), buffer->Count());
    auto stream = new Aspose::Cells::Systems::IO::MemoryStream(array);

    return stream;
}

System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    System::ArrayPtr<uint8_t> outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}

void ChangeOLEObjectData()
{
    System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(GetDataPath() + u"ChangeOLEObjectData.pptx");
    System::SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

    System::SharedPtr<OleObjectFrame> ole;

    // يمر عبر جميع الأشكال للبحث عن إطار Ole
    for (auto shape : IterateOver(slide->get_Shapes()))
    {
        if (System::ObjectExt::Is<OleObjectFrame>(shape))
        {
            ole = System::ExplicitCast<OleObjectFrame>(shape);
        }
    }
    
    if (ole != nullptr)
    {
        // قراءة بيانات الكائن في Workbook
        intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> cellsInputStream = ToCellsMemoryStream(ole->get_ObjectData());
        intrusive_ptr<Aspose::Cells::IWorkbook> Wb = Aspose::Cells::Factory::CreateIWorkbook(cellsInputStream);

        // تعديل بيانات Workbook
        Wb->GetIWorksheets()->GetObjectByIndex(0)->GetICells()->GetObjectByIndex(0,4)->PutValue(u"E");
        Wb->GetIWorksheets()->GetObjectByIndex(0)->GetICells()->GetObjectByIndex(1, 4)->PutValue(12);
        Wb->GetIWorksheets()->GetObjectByIndex(0)->GetICells()->GetObjectByIndex(2, 4)->PutValue(14);
        Wb->GetIWorksheets()->GetObjectByIndex(0)->GetICells()->GetObjectByIndex(3, 4)->PutValue(15);

        intrusive_ptr<MemoryStream> cellsOutputStream = new Aspose::Cells::Systems::IO::MemoryStream();
        Wb->Save(cellsOutputStream, Aspose::Cells::SaveFormat_Xlsx);
        
        // تغيير بيانات كائن إطار Ole
        cellsOutputStream->SetPosition(0);
        System::SharedPtr<System::IO::MemoryStream> msout = ToSlidesMemoryStream(cellsOutputStream);
        ole->set_ObjectData(msout->ToArray());
        
        pres->Save(GetOutPath() + u"OleEdit_out.pptx", Export::SaveFormat::Pptx);
    }
}
```

## تضمين أنواع ملفات أخرى في الشرائح

بخلاف الرسوم البيانية من Excel، يسمح Aspose.Slides لـ C++ بتضمين أنواع ملفات أخرى في الشرائح. على سبيل المثال، يمكنك إدراج ملفات HTML وPDF وZIP ككائنات في الشريحة. عندما ينقر المستخدم مرتين على الكائن المضمن، يتم إطلاق الكائن تلقائيًا في البرنامج المرتبط، أو يُوجه المستخدم لاختيار برنامج مناسب لفتح الكائن.

يوضح لك هذا الرمز C++ كيفية تضمين HTML وZIP في شريحة:

``` cpp

using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;
    
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);

auto htmlBytes = System::IO::File::ReadAllBytes(u"embedOle.html");

auto dataInfoHtml = System::MakeObject<OleEmbeddedDataInfo>(htmlBytes, u"html");
auto oleFrameHtml = slide->get_Shapes()->AddOleObjectFrame(150.0f, 120.0f, 50.0f, 50.0f, dataInfoHtml);
oleFrameHtml->set_IsObjectIcon(true);
        
auto zipBytes = System::IO::File::ReadAllBytes(u"embedOle.zip");
auto dataInfoZip = System::MakeObject<OleEmbeddedDataInfo>(zipBytes, u"zip");
auto oleFrameZip = slide->get_Shapes()->AddOleObjectFrame(150.0f, 220.0f, 50.0f, 50.0f, dataInfoZip);
oleFrameZip->set_IsObjectIcon(true);
        
pres->Save(u"embeddedOle.pptx", SaveFormat::Pptx);

```

## تعيين أنواع الملفات للكائنات المضمنة

عند العمل على العروض التقديمية، قد تحتاج إلى استبدال كائنات OLE القديمة بأخرى جديدة. أو قد تحتاج إلى استبدال كائن OLE غير المدعوم بآخر مدعوم.

يسمح Aspose.Slides لـ C++ بتعيين نوع الملف لكائن مضمن. بهذه الطريقة، يمكنك تغيير بيانات إطار OLE أو ملحقه.

يوضح لك هذا الرمز C++ كيفية تعيين نوع الملف لكائن OLE مضمن:

``` cpp
auto pres = System::MakeObject<Presentation>(u"embeddedOle.pptx");
auto slide = pres->get_Slides()->idx_get(0);
auto oleObjectFrame = System::ExplicitCast<IOleObjectFrame>(slide->get_Shapes()->idx_get(0));
Console::WriteLine(u"الملحق البيانات المضمنة الحالي هو: {0}", oleObjectFrame->get_EmbeddedData()->get_EmbeddedFileExtension());

oleObjectFrame->SetEmbeddedData(System::MakeObject<OleEmbeddedDataInfo>(File::ReadAllBytes(u"embedOle.zip"), u"zip"));

pres->Save(u"embeddedChanged.pptx", SaveFormat::Pptx);
```

## تعيين صور الأيقونات والعناوين للكائنات المضمنة

بعد تضمين كائن OLE، يتم إضافة عرض يتكون من صورة أيقونة وعنوان تلقائيًا. العرض هو ما يراه المستخدمون قبل أن يصلوا إلى الكائن OLE أو يفتحوه.

إذا كنت ترغب في استخدام صورة ونص محددين كعناصر في العرض، يمكنك تعيين صورة الأيقونة والعنوان باستخدام Aspose.Slides لـ C++.

يوضح لك هذا الرمز C++ كيفية تعيين صورة الأيقونة والعنوان لكائن مضمن:

``` cpp
auto pres = System::MakeObject<Presentation>(u"embeddedOle.pptx");
auto slide = pres->get_Slide(0);
auto oleObjectFrame = System::ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

auto oleImage = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
oleObjectFrame->set_SubstitutePictureTitle(u"عنواني");
oleObjectFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleObjectFrame->set_IsObjectIcon(false);

pres->Save(u"embeddedOle-newImage.pptx", SaveFormat::Pptx);
```

## **منع إطار كائن OLE من تغيير الحجم وإعادة الوضع**

بعد إضافة كائن OLE المرتبط إلى شريحة العرض التقديمي، عندما تفتح العرض في PowerPoint، قد ترى رسالة تطلب منك تحديث الروابط. قد يؤدي النقر على زر "تحديث الروابط" إلى تغيير حجم وإعادة وضع إطار كائن OLE لأن PowerPoint يقوم بتحديث البيانات من كائن OLE المرتبط ويحدث عرض الكائن. لمنع PowerPoint من المطالبة بتحديث بيانات الكائن، قم بتعيين طريقة `set_UpdateAutomatic` من واجهة [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/) على `false`:

```cpp
oleObjectFrame->set_UpdateAutomatic(false);
```

## استخراج الملفات المضمنة

يسمح Aspose.Slides لـ C++ باستخراج الملفات المضمنة في الشرائح ككائنات OLE بهذه الطريقة:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) التي تحتوي على كائن OLE الذي تنوي استخراجها.
2. تمر عبر جميع الأشكال في العرض التقديمي والوصول إلى شكل [OLEObjectFrame](https://reference.aspose.com/slides/cpp/class/aspose.slides.ole_object_frame) .
3. الوصول إلى بيانات الملف المضمن من إطار كائن OLE وكتابته إلى القرص.

يوضح لك هذا الرمز C++ كيفية استخراج ملف مضمن في شريحة ككائن OLE:

``` cpp
auto pres = System::MakeObject<Presentation>(u"embeddedOle.pptx");
auto slide = pres->get_Slides()->idx_get(0);

for (int32_t index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto shape = slide->get_Shapes()->idx_get(index);

    auto oleFrame = System::AsCast<IOleObjectFrame>(shape);

    if (oleFrame != nullptr)
    {
        auto data = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();
        String extension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

        File::WriteAllBytes(String::Format(u"oleFrame{0}{1}", index, extension), data);
    }
}
```