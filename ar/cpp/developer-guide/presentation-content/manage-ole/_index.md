---
title: إدارة OLE في العروض التقديمية باستخدام C++
linktitle: إدارة OLE
type: docs
weight: 40
url: /ar/cpp/manage-ole/
keywords:
- كائن OLE
- ربط وتضمين الكائنات
- إضافة OLE
- تضمين OLE
- إضافة كائن
- تضمين كائن
- إضافة ملف
- تضمين ملف
- كائن مرتبط
- ملف مرتبط
- تغيير OLE
- أيقونة OLE
- عنوان OLE
- استخراج OLE
- استخراج كائن
- استخراج ملف
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تحسين إدارة كائنات OLE في ملفات PowerPoint وOpenDocument باستخدام Aspose.Slides for C++. قم بتضمين محتوى OLE وتحديثه وتصديره بسلاسة."
---
## **المقدمة**

{{% alert title="Info" color="info" %}}
OLE (Object Linking & Embedding) هي تقنية من مايكروسوفت تسمح بنقل البيانات والكائنات التي تم إنشاؤها في تطبيق واحد إلى تطبيق آخر عبر الربط أو التضمين. 
{{% /alert %}} 

تخيل مخططًا تم إنشاؤه في MS Excel. ثم يتم وضع المخطط داخل شريحة PowerPoint. يُعتبر ذلك المخطط في Excel كائن OLE. 

- قد يظهر كائن OLE كأيقونة. في هذه الحالة، عند النقر المزدوج على الأيقونة، يفتح المخطط في التطبيق المرتبط به (Excel)، أو يُطلب منك اختيار تطبيق لفتح أو تحرير الكائن. 
- قد يعرض كائن OLE محتواه الفعلي، مثل محتوى المخطط. في هذه الحالة، يتم تنشيط المخطط في PowerPoint، تُحمَّل واجهة المخطط، وتستطيع تعديل بيانات المخطط داخل PowerPoint.

[Aspose.Slides for C++](https://products.aspose.com/slides/ar/cpp/) يسمح لك بإدراج كائنات OLE في الشرائح كإطارات كائن OLE ([OleObjectFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/oleobjectframe/)).

## **إضافة إطارات كائن OLE إلى الشرائح**

افترض أنك قد أنشأت مخططًا في Microsoft Excel وتريد تضمينه في شريحة كإطار كائن OLE باستخدام Aspose.Slides for C++، يمكنك القيام بذلك بهذه الطريقة:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.presentation) .
2. الحصول على مرجع الشريحة عبر فهرسها.
3. قراءة ملف Excel كمصفوفة بايت.
4. إضافة الـ [OleObjectFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/oleobjectframe/) إلى الشريحة مع تضمين مصفوفة البايت ومعلومات أخرى عن كائن OLE.
5. كتابة العرض التقديمي المعدل كملف PPTX.

في المثال أدناه، أضفنا مخططًا من ملف Excel إلى شريحة كـ [OleObjectFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/oleobjectframe/) باستخدام Aspose.Slides for C++.
**ملاحظة** أن مُنشئ الـ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/ar/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) يأخذ امتداد الكائن القابل للتضمين كمعامل ثانٍ. يتيح هذا الامتداد لبرنامج PowerPoint تفسير نوع الملف بشكل صحيح واختيار التطبيق المناسب لفتح كائن OLE هذا.

``` cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <drawing/size_f.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);

// إعداد البيانات لكائن OLE.
auto fileData = File::ReadAllBytes(u"book.xlsx");
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(fileData, u"xlsx");

// إضافة إطار كائن OLE إلى الشريحة.
slide->get_Shapes()->AddOleObjectFrame(0, 0, slideSize.get_Width(), slideSize.get_Height(), dataInfo);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **إضافة إطارات OLE مرتبطة**

Aspose.Slides for C++ يسمح لك بإضافة [OleObjectFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/oleobjectframe/) دون تضمين البيانات وإنما باستخدام ارتباط فقط إلى الملف.

هذا الكود C++ يوضح لك كيفية إضافة [OleObjectFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/oleobjectframe/) مع ملف Excel مرتبط إلى شريحة:

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// إضافة إطار كائن OLE مع ملف Excel مرتبط.
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **الوصول إلى إطارات OLE**

إذا كان كائن OLE مضمّنًا بالفعل في شريحة، يمكنك العثور عليه أو الوصول إليه بسهولة بهذه الطريقة:

1. تحميل عرض تقديمي يحتوي على كائن OLE المضمّن بإنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.presentation) .
2. الحصول على مرجع الشريحة باستخدام فهرسها.
3. الوصول إلى شكل الـ [OleObjectFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/oleobjectframe/). في مثالنا، استخدمنا الـ PPTX الذي تم إنشاؤه مسبقًا والذي يحتوي على شكل واحد فقط في الشريحة الأولى. ثم *قمنا بتحويل* ذلك الكائن إلى [IOleObjectFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ioleobjectframe/). كان هذا هو إطار OLE المطلوب الوصول إليه.
4. بمجرد الوصول إلى إطار كائن OLE، يمكنك إجراء أي عملية عليه.

في المثال أدناه، يتم الوصول إلى إطار كائن OLE (كائن مخطط Excel مضمّن في شريحة) وبيانات ملفه.

``` cpp
#include <DOM/IOleEmbeddedDataInfo.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{ 
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // احصل على بيانات الملف المضمّن.
    auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

    // احصل على امتداد الملف المضمّن.
    auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

    // ...
}
```

### **الوصول إلى خصائص إطار OLE المرتبط**

Aspose.Slides يسمح لك بالوصول إلى خصائص إطار OLE المرتبط.

هذا الكود C++ يوضح لك كيفية التحقق مما إذا كان كائن OLE مرتبطًا ثم الحصول على مسار الملف المرتبط:

```cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.ppt");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // تحقق مما إذا كان كائن OLE مرتبطًا.
    if (oleFrame->get_IsObjectLink())
    {
        // طباعة المسار الكامل للملف المرتبط.
        std::wcout << L"OLE object frame is linked to: " << oleFrame->get_LinkPathLong() << std::endl;

        // طباعة المسار النسبي للملف المرتبط إذا كان موجودًا.
        // يمكن فقط لملفات PPT أن تحتوي على المسار النسبي.
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```

## **تغيير بيانات كائن OLE**

{{% alert color="info" %}} 
في هذا القسم، يستخدم المثال البرمجي أدناه [Aspose.Cells for C++](/cells/cpp/). 
{{% /alert %}}

إذا كان كائن OLE مضمّنًا بالفعل في شريحة، يمكنك بسهولة الوصول إلى ذلك الكائن وتعديل بياناته بهذه الطريقة:

1. تحميل عرض تقديمي يحتوي على كائن OLE المضمّن بإنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.presentation) .
2. الحصول على مرجع الشريحة عبر فهرسها. 
3. الوصول إلى شكل الـ [OLEObjectFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/oleobjectframe/). في مثالنا، استخدمنا الـ PPTX الذي تم إنشاؤه مسبقًا والذي يحتوي على شكل واحد على الشريحة الأولى. ثم *قمنا بتحويل* ذلك الكائن إلى [IOleObjectFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ioleobjectframe/). كان هذا هو إطار OLE المطلوب الوصول إليه.
4. بمجرد الوصول إلى إطار كائن OLE، يمكنك إجراء أي عملية عليه.
5. إنشاء كائن `Workbook` والوصول إلى بيانات OLE.
6. الوصول إلى الـ `Worksheet` المطلوب وتعديل البيانات.
7. حفظ الـ `Workbook` المحدث في تدفق.
8. تغيير بيانات كائن OLE من التدفق.

في المثال أدناه، تم الوصول إلى إطار كائن OLE (كائن مخطط Excel مضمّن في شريحة) وتم تعديل بيانات ملفه لتحديث بيانات المخطط.

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/Cell.h"
#include "Aspose.Cells/Cells.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/OoxmlSaveOptions.h"
#include "Aspose.Cells/SaveFormat.h"
#include "Aspose.Cells/U16String.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// يجب بدء Aspose.Cells for C++ قبل استخدام أي من أنواعه.
Aspose::Cells::Startup();

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// Get the first shape as an OLE object frame.
auto oleFrame = AsCast<IOleObjectFrame>(slide->get_Shape(0));

if (oleFrame != nullptr)
{
    auto oleStream = MakeObject<MemoryStream>(oleFrame->get_EmbeddedData()->get_EmbeddedFileData());

    // قراءة بيانات كائن OLE ككائن Workbook.
    auto oleArray = oleStream->ToArray();
    std::vector<uint8_t> workbookData(oleArray->data().begin(), oleArray->data().end());
    Aspose::Cells::Workbook workbook(Aspose::Cells::Vector<uint8_t>(workbookData.data(), workbookData.size()));

    // تعديل بيانات المصنف.
    auto worksheet = workbook.GetWorksheets().Get(0);
    worksheet.GetCells().Get(0, 4).PutValue(Aspose::Cells::U16String("E"));
    worksheet.GetCells().Get(1, 4).PutValue(12);
    worksheet.GetCells().Get(2, 4).PutValue(14);
    worksheet.GetCells().Get(3, 4).PutValue(15);

    Aspose::Cells::OoxmlSaveOptions fileOptions(Aspose::Cells::SaveFormat::Xlsx);
    auto newWorkbookData = workbook.Save(fileOptions);

    auto newOleStream = MakeObject<MemoryStream>();
    newOleStream->Write(
        MakeArray<uint8_t>(std::vector<uint8_t>(newWorkbookData.GetData(), newWorkbookData.GetData() + newWorkbookData.GetLength())),
        0, newWorkbookData.GetLength());

    // تغيير بيانات كائن إطار OLE.
    auto newData = MakeObject<OleEmbeddedDataInfo>(newOleStream->ToArray(), oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension());
    oleFrame->SetEmbeddedData(newData);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);

Aspose::Cells::Cleanup();
```

## **تضمين أنواع ملفات أخرى في الشرائح**

بالإضافة إلى مخططات Excel، Aspose.Slides for C++ يسمح لك بتضمين أنواع ملفات أخرى في الشرائح. على سبيل المثال، يمكنك إدراج ملفات HTML وPDF وZIP ككائنات. عند النقر المزدوج على الكائن المُدرج، يفتح تلقائيًا في البرنامج المناسب، أو يُطلب من المستخدم اختيار برنامج ملائم لفتحه.

هذا الكود C++ يوضح لك كيفية تضمين HTML وZIP في شريحة:

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto htmlData = File::ReadAllBytes(u"sample.html");
auto htmlDataInfo = MakeObject<OleEmbeddedDataInfo>(htmlData, u"html");
auto htmlOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame->set_IsObjectIcon(true);

auto zipData = File::ReadAllBytes(u"sample.zip");
auto zipDataInfo = MakeObject<OleEmbeddedDataInfo>(zipData, u"zip");
auto zipOleFrame = slide->get_Shapes()->AddOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **تحديد نوع الملف للكائنات المضمنة**

عند العمل مع العروض التقديمية، قد تحتاج إلى استبدال كائنات OLE القديمة بأخرى جديدة أو استبدال كائن OLE غير مدعوم بآخر مدعوم. Aspose.Slides for C++ يسمح لك بتحديد نوع الملف لكائن مضمّن، مما يتيح لك تحديث بيانات إطار OLE أو امتداده.

هذا الكود C++ يوضح لك كيفية تعيين نوع الملف لكائن OLE مضمّن إلى `zip`:

``` cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Ole/OleEmbeddedDataInfo.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::DOM::Ole;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();
auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

std::wcout << L"Current embedded file extension is: " << fileExtension << std::endl;

// غيّر نوع الملف إلى ZIP.
oleFrame->SetEmbeddedData(MakeObject<OleEmbeddedDataInfo>(fileData, u"zip"));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **تعيين صور الأيقونات والعناوين للكائنات المضمنة**

بعد تضمين كائن OLE، تُضاف معاينة تتكون من صورة أيقونة تلقائيًا. هذه المعاينة ما يراه المستخدمون قبل الوصول أو فتح كائن OLE. إذا رغبت في استخدام صورة ونص محددين كعناصر في المعاينة، يمكنك تعيين صورة الأيقونة والعنوان باستخدام Aspose.Slides for C++.

هذا الكود C++ يوضح لك كيفية تعيين صورة الأيقونة والعنوان لكائن مضمّن:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// Add an image to the presentation resources.
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **منع إطار كائن OLE من تغيير حجمه وإعادة وضعه**

بعد إضافة كائن OLE مرتبط إلى شريحة عرض تقديمي، قد تظهر رسالة في PowerPoint تطلب تحديث الروابط عند فتح العرض. النقر على زر "Update Links" قد يغيّر حجم وموقع إطار كائن OLE لأن PowerPoint يحدث البيانات من الكائن المرتبط ويُجِدِّد معاينة الكائن. لمنع PowerPoint من طلب تحديث بيانات الكائن، عيّن الخاصية `set_UpdateAutomatic` لواجهة [IOleObjectFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ioleobjectframe/) إلى `false`:

```cpp
#include <DOM/IOleObjectFrame.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

oleFrame->set_UpdateAutomatic(false);
```

## **استخراج الملفات المضمنة**

Aspose.Slides for C++ يسمح لك باستخراج الملفات المضمنة في الشرائح ككائنات OLE بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/ar/cpp/class/aspose.slides.presentation) التي تحتوي على كائنات OLE التي تريد استخراجها.
2. التمرُّر عبر جميع الأشكال في العرض التقديمي والوصول إلى أشكال [OLEObjectFrame](https://reference.aspose.com/slides/ar/cpp/aspose.slides/oleobjectframe/).
3. الوصول إلى بيانات الملفات المضمنة من إطارات OLE وكتابتها إلى القرص.

هذا الكود C++ يوضح لك كيفية استخراج الملفات المضمنة في شريحة ككائنات OLE:

``` cpp
#include <DOM/IOleEmbeddedDataInfo.h>
#include <DOM/IOleObjectFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (int index = 0; index < slide->get_Shapes()->get_Count(); index++)
{
    auto shape = slide->get_Shape(index);

    if (ObjectExt::Is<IOleObjectFrame>(shape))
    { 
        auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

        auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();
        auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();

        auto fileName = String::Format(u"OLE_object_{0}{1}", index, fileExtension);
        File::WriteAllBytes(fileName, fileData);
    }
}

presentation->Dispose();
```

## **الأسئلة الشائعة**

### هل سيتم عرض محتوى OLE عند تصدير الشرائح إلى PDF/صور؟

ما هو مرئي على الشريحة يُركّب—الأيقونة/صورة البديل (المعاينة). لا يتم تنفيذ محتوى OLE "الحي" أثناء التركيب. إذا لزم الأمر، عيّن صورة معاينة مخصصة لضمان المظهر المتوقع في ملف PDF المُصدَّر.

### كيف يمكنني قفل كائن OLE على شريحة بحيث لا يتمكن المستخدمون من تحريكه/تحريره في PowerPoint؟

قفل الشكل: Aspose.Slides يوفر [shape-level locks](/slides/ar/cpp/applying-protection-to-presentation/). هذا ليس تشفيرًا، لكنه يمنع فعليًا التعديلات غير المقصودة والتحريك.

### لماذا "يقفز" كائن Excel المرتبط أو يتغير حجمه عند فتح العرض؟

قد يقوم PowerPoint بتحديث معاينة OLE المرتبط. لتحقيق مظهر ثابت، اتبع ممارسات [Working Solution for Worksheet Resizing](/slides/ar/cpp/working-solution-for-worksheet-resizing/)—إما ضبط الإطار على النطاق، أو تكبير النطاق إلى إطار ثابت وتعيين صورة بديلة مناسبة.

### هل سيتم الحفاظ على المسارات النسبية لكائنات OLE المرتبطة في تنسيق PPTX؟

في PPTX لا تتوفر معلومات "المسار النسبي"—فقط المسار الكامل. تُوجد المسارات النسبية في تنسيق PPT الأقدم. للانتقالية، يُفضَّل استخدام مسارات مطلقة موثوقة/URIs قابلة للوصول أو التضمين.