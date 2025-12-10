---
title: إدارة OLE في العروض التقديمية باستخدام C++
linktitle: إدارة OLE
type: docs
weight: 40
url: /ar/cpp/manage-ole/
keywords:
- عنصر OLE
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
description: "تحسين إدارة كائنات OLE في ملفات PowerPoint و OpenDocument باستخدام Aspose.Slides للغة C++. تضمين، تحديث، وتصدير محتوى OLE بسلاسة."
---

{{% alert title="Info" color="info" %}}

OLE (الربط والتضمين للكائنات) هو تكنولوجيا من Microsoft تسمح للبيانات والكائنات التي تم إنشاؤها في تطبيق واحد بأن تُوضع في تطبيق آخر عبر الربط أو التضمين. 

{{% /alert %}} 

تُعتبر المخطط الذي تم إنشاؤه في MS Excel مثالًا. يتم وضع المخطط داخل شريحة PowerPoint. يُعد ذلك المخطط في Excel كائن OLE. 

- قد يظهر كائن OLE كأيقونة. في هذه الحالة، عند النقر المزدوج على الأيقونة، يُفتح المخطط في التطبيق المرتبط به (Excel)، أو يُطلب منك اختيار تطبيق لفتح أو تحرير الكائن. 
- قد يعرض كائن OLE محتوياته الفعلية، مثل محتويات المخطط. في هذه الحالة، يُفعَّل المخطط في PowerPoint، يتم تحميل واجهة المخطط، وتستطيع تعديل بيانات المخطط داخل PowerPoint.

يتيح لك [Aspose.Slides for C++](https://products.aspose.com/slides/cpp/) إدراج كائنات OLE في الشرائح كإطارات كائن OLE ([OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/)).

## **إضافة إطارات كائن OLE إلى الشرائح**

بافتراض أنك قد أنشأت مخططًا في Microsoft Excel وتريد تضمينه في شريحة كإطار كائن OLE باستخدام Aspose.Slides for C++، يمكنك القيام بذلك بهذه الطريقة:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).  
2. احصل على مرجع الشريحة عبر فهرسها.  
3. قراءة ملف Excel كمصفوفة بايت.  
4. إضافة الـ [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) إلى الشريحة مع تضمين مصفوفة البايت وغيرها من المعلومات حول كائن OLE.  
5. حفظ العرض المُعدَّل كملف PPTX.  

في المثال أدناه، أضفنا مخططًا من ملف Excel إلى شريحة كـ [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) باستخدام Aspose.Slides for C++. **ملاحظة** أن منشئ الـ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/cpp/aspose.slides.dom.ole/oleembeddeddatainfo/) يقبل امتداد الكائن القابل للتضمين كوسيطة ثانية. يتيح هذا الامتداد لـ PowerPoint تفسير نوع الملف بشكل صحيح واختيار التطبيق المناسب لفتح كائن OLE هذا.
``` cpp
auto presentation = MakeObject<Presentation>();
auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slide(0);

// Prepare data for the OLE object.
auto fileData = File::ReadAllBytes(u"book.xlsx");
auto dataInfo = MakeObject<OleEmbeddedDataInfo>(fileData, u"xlsx");

// Add the OLE object frame to the slide.
slide->get_Shapes()->AddOleObjectFrame(0, 0, slideSize.get_Width(), slideSize.get_Height(), dataInfo);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


### **إضافة إطارات OLE مرتبطة**

يتيح لك Aspose.Slides for C++ إضافة [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) دون تضمين البيانات، بل فقط عبر رابط إلى الملف.

يظهر لك هذا الكود في C++ كيفية إضافة [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/) مع ملف Excel مرتبط إلى شريحة:
```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

// إضافة إطار كائن OLE مع ملف Excel مرتبط.
slide->get_Shapes()->AddOleObjectFrame(20, 20, 200, 150, u"Excel.Sheet.12", u"book.xlsx");

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **الوصول إلى إطارات OLE**

إذا كان كائن OLE مضمّنًا بالفعل في شريحة، يمكنك بسهولة العثور عليه أو الوصول إليه بهذه الطريقة:

1. تحميل عرض يحتوي على كائن OLE مضمّن بإنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).  
2. احصل على مرجع الشريحة باستخدام فهرستها.  
3. الوصول إلى شكل [OleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/). في مثالنا، استخدمنا ملف PPTX الذي أنشأناه مسبقًا والذي يحتوي على شكل واحد فقط في الشريحة الأولى. ثم قمنا *بتحويل* ذلك الكائن إلى [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/). كان هذا هو إطار كائن OLE المطلوب الوصول إليه.  
4. بمجرد الوصول إلى إطار كائن OLE، يمكنك تنفيذ أي عملية عليه.  

في المثال أدناه، تم الوصول إلى إطار كائن OLE (كائن مخطط Excel مضمّن في شريحة) وبيانات ملفه.
``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{ 
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // الحصول على بيانات الملف المضمن.
    // الحصول على امتداد الملف المضمن.
    // ...
}
```


### **الوصول إلى خصائص إطار OLE المرتبط**

يسمح لك Aspose.Slides بالوصول إلى خصائص إطار كائن OLE المرتبط.

يظهر لك هذا الكود في C++ كيفية التحقق مما إذا كان كائن OLE مرتبطًا ثم الحصول على مسار الملف المرتبط:
```cpp
auto presentation = MakeObject<Presentation>(u"sample.ppt");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (ObjectExt::Is<IOleObjectFrame>(shape))
{
    auto oleFrame = ExplicitCast<IOleObjectFrame>(shape);

    // تحقق مما إذا كان كائن OLE مرتبطًا.
    if (oleFrame->get_IsObjectLink())
    {
        // اطبع المسار الكامل للملف المرتبط.
        std::wcout << L"OLE object frame is linked to: " << oleFrame->get_LinkPathLong() << std::endl;

        // اطبع المسار النسبي للملف المرتبط إذا كان موجودًا.
        // يمكن فقط لعروض PPT أن تحتوي على المسار النسبي.
        if (!String::IsNullOrEmpty(oleFrame->get_LinkPathRelative()))
        {
            std::wcout << L"OLE object frame relative path: " << oleFrame->get_LinkPathRelative() << std::endl;
        }
    }
}
```


## **تغيير بيانات كائن OLE**

{{% alert color="primary" %}} 

في هذا القسم، يستخدم مثال الكود أدناه [Aspose.Cells for C++](/cells/cpp/).

{{% /alert %}}

إذا كان كائن OLE مضمّنًا بالفعل في شريحة، يمكنك بسهولة الوصول إلى هذا الكائن وتعديل بياناته بهذه الطريقة:

1. تحميل عرض يحتوي على كائن OLE مضمّن بإنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).  
2. احصل على مرجع الشريحة عبر فهرستها.  
3. الوصول إلى شكل [OLEObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/). في مثالنا، استخدمنا ملف PPTX الذي أنشأناه مسبقًا والذي يحتوي على شكل واحد في الشريحة الأولى. ثم قمنا *بتحويل* ذلك الكائن إلى [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/). كان هذا هو إطار كائن OLE المطلوب الوصول إليه.  
4. بمجرد الوصول إلى إطار كائن OLE، يمكنك تنفيذ أي عملية عليه.  
5. إنشاء كائن `Workbook` والوصول إلى بيانات OLE.  
6. الوصول إلى `Worksheet` المطلوب وتعديل البيانات.  
7. حفظ `Workbook` المحدث في تدفق.  
8. تغيير بيانات كائن OLE من التدفق.  

في المثال أدناه، تم الوصول إلى إطار كائن OLE (كائن مخطط Excel مضمّن في شريحة) وتم تعديل بيانات ملفه لتحديث بيانات المخطط.
``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

// احصل على الشكل الأول كإطار كائن OLE.
auto oleFrame = AsCast<IOleObjectFrame>(slide->get_Shape(0));

if (oleFrame != nullptr)
{
    auto oleStream = MakeObject<MemoryStream>(oleFrame->get_EmbeddedData()->get_EmbeddedFileData());

    // قراءة بيانات كائن OLE ككائن دفتر عمل.
    auto oleArray = oleStream->ToArray();
    std::vector<uint8_t> workbookData(oleArray->data().begin(), oleArray->data().end());
    Aspose::Cells::Workbook workbook(Aspose::Cells::Vector<uint8_t>(workbookData.data(), workbookData.size()));

    // تعديل بيانات دفتر العمل.
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
```


## **تضمين أنواع ملفات أخرى في الشرائح**

بالإضافة إلى مخططات Excel، يتيح لك Aspose.Slides for C++ تضمين أنواع أخرى من الملفات في الشرائح. على سبيل المثال، يمكنك إدراج ملفات HTML وPDF وZIP ككائنات. عند النقر المزدوج على الكائن المدرج، يفتح تلقائيًا في البرنامج المناسب، أو يُطلب من المستخدم اختيار برنامج مناسب لفتحه.

يظهر لك هذا الكود في C++ كيفية تضمين HTML وZIP في شريحة:
``` cpp
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


## **تحديد أنواع الملفات للكائنات المضمّنة**

عند العمل على العروض التقديمية، قد تحتاج إلى استبدال كائنات OLE القديمة بأخرى جديدة أو استبدال كائن OLE غير مدعوم بآخر مدعوم. يتيح لك Aspose.Slides for C++ تحديد نوع الملف للكائن المضمّن، مما يمكنك من تحديث بيانات إطار OLE أو امتداده.

يظهر لك هذا الكود في C++ كيفية تعيين نوع الملف لكائن OLE مضمّن إلى `zip`:
``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

auto fileExtension = oleFrame->get_EmbeddedData()->get_EmbeddedFileExtension();
auto fileData = oleFrame->get_EmbeddedData()->get_EmbeddedFileData();

std::wcout << L"Current embedded file extension is: " << fileExtension << std::endl;

// تغيير نوع الملف إلى ZIP.
oleFrame->SetEmbeddedData(MakeObject<OleEmbeddedDataInfo>(fileData, u"zip"));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **تعيين صور الأيقونات والعناوين للكائنات المضمّنة**

بعد تضمين كائن OLE، يتم إضافة معاينة تتكون من صورة أيقونة تلقائيًا. هذه المعاينة هي ما يراه المستخدمون قبل الوصول إلى كائن OLE أو فتحه. إذا رغبت في استخدام صورة ونص محددين كعناصر في المعاينة، يمكنك تعيين صورة الأيقونة والعنوان باستخدام Aspose.Slides for C++.

يظهر لك هذا الكود في C++ كيفية تعيين صورة الأيقونة والعنوان لكائن مضمّن:
``` cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// إضافة صورة إلى موارد العرض التقديمي.
auto imageData = File::ReadAllBytes(u"image.png");
auto oleImage = presentation->get_Images()->AddImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(true);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **منع تعديل حجم وإعادة تموضع إطار كائن OLE**

بعد إضافة كائن OLE مرتبط إلى شريحة عرض تقديمي، عند فتح العرض في PowerPoint قد تظهر لك رسالة تطلب تحديث الروابط. قد يؤدي النقر على زر "Update Links" إلى تغيير حجم وتموضع إطار كائن OLE لأن PowerPoint يحدث البيانات من كائن OLE المرتبط ويُحدّث معاينة الكائن. لمنع PowerPoint من طلب تحديث بيانات الكائن، قم بتعيين طريقة `set_UpdateAutomatic` لواجهة [IOleObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ioleobjectframe/) إلى `false`:
```cpp
oleFrame->set_UpdateAutomatic(false);
```


## **استخراج الملفات المضمّنة**

يتيح لك Aspose.Slides for C++ استخراج الملفات المضمّنة في الشرائح ككائنات OLE بهذه الطريقة:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation) التي تحتوي على كائنات OLE التي ترغب في استخراجها.  
2. التجول عبر جميع الأشكال في العرض والوصول إلى أشكال [OLEObjectFrame](https://reference.aspose.com/slides/cpp/aspose.slides/oleobjectframe/).  
3. الوصول إلى بيانات الملفات المضمّنة من إطارات OLE وكتابتها إلى القرص.  

يظهر لك هذا الكود في C++ كيفية استخراج الملفات المضمّنة في شريحة ككائنات OLE:
``` cpp
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


## **FAQ**

**هل سيتم عرض محتوى OLE عند تصدير الشرائح إلى PDF/صور؟**

ما يُعرض على الشريحة هو ما يتم تصييره — أي الأيقونة/صورة البديل (المعاينة). لا يتم تنفيذ محتوى OLE "الحي" أثناء التصيير. إذا لزم الأمر، قم بتعيين صورة المعاينة الخاصة بك لضمان الشكل المتوقع في ملف PDF المصدَّر.

**كيف يمكنني قفل كائن OLE على شريحة بحيث لا يتمكن المستخدمون من تحريكه/تحريره في PowerPoint؟**

قم بقفل الشكل: تقدم Aspose.Slides [قفل على مستوى الشكل](/slides/ar/cpp/applying-protection-to-presentation/). هذا ليس تشفيرًا، لكنه يمنع عمليًا التعديلات والتحركات العارضة.

**لماذا يقفز كائن Excel المرتبط أو يتغير حجمه عند فتح العرض التقديمي؟**

قد يقوم PowerPoint بتحديث معاينة كائن OLE المرتبط. للحصول على مظهر ثابت، اتبع ممارسات [الحل العملي لإعادة تحجيم ورقة العمل](/slides/ar/cpp/working-solution-for-worksheet-resizing/) — إما ضبط الإطار ليتناسب مع النطاق، أو تحجيم النطاق لإطار ثابت وتعيين صورة بديلة مناسبة.

**هل سيتم الحفاظ على المسارات النسبية لكائنات OLE المرتبطة في صيغة PPTX؟**

في صيغة PPTX، لا تتوفر معلومات "المسار النسبي" — فقط المسار الكامل. تُستخدم المسارات النسبية في الصيغة القديمة PPT. للحصول على قابلية نقل، يُفضَّل الاعتماد على مسارات مطلقة موثوقة/عناوين URI يمكن الوصول إليها أو التضمين.