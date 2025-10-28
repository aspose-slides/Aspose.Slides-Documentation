---
title: إدارة OLE في العروض التقديمية باستخدام Python
linktitle: إدارة OLE
type: docs
weight: 40
url: /ar/python-net/manage-ole/
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
- Python
- Aspose.Slides
description: تحسين إدارة كائنات OLE في ملفات PowerPoint وOpenDocument باستخدام Aspose.Slides للـ Python عبر .NET. قم بتضمين وتحديث وتصريح محتوى OLE بسهولة.
---

## **نظرة عامة**

{{% alert title="Info" color="info" %}}

**OLE (ربط وتضمين الكائنات)** هي تقنية من Microsoft تسمح للبيانات والكائنات التي تم إنشاؤها في تطبيق واحد أن تُربط أو تُضمّن في آخر.

{{% /alert %}}

على سبيل المثال، المخطط الذي تم إنشاؤه في Microsoft Excel وتم وضعه على شريحة PowerPoint هو كائن OLE.

- قد يظهر كائن OLE كأيقونة. النقر المزدوج على الأيقونة يفتح الكائن في التطبيق المرتبط به (مثل Excel) أو يطلب منك اختيار تطبيق لفتح أو تعديل الكائن.
- قد يعرض كائن OLE محتوياته (على سبيل المثال، مخطط). في هذه الحالة، يقوم PowerPoint بتنشيط الكائن المضمن، ويحمّل واجهة المخطط، ويسمح لك بتحرير بيانات المخطط داخل PowerPoint.

تتيح لك Aspose.Slides للـ Python إدراج كائنات OLE في الشرائح كإطارات كائن OLE ([OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)).

## **إضافة كائنات OLE إلى الشرائح**

إذا كنت قد أنشأت مخططًا في Microsoft Excel وتريد تضمينه في شريحة كإطار كائن OLE باستخدام Aspose.Slides للـ Python، فاتبع الخطوات التالية:

1. أنشئ نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. احصل على مرجع إلى الشريحة بواسطة فهرسها.
1. اقرأ ملف Excel إلى مصفوفة بايت.
1. أضف [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) إلى الشريحة، مع تزويده بمصفوفة البايت وتفاصيل كائن OLE الأخرى.
1. احفظ العرض المعدل كملف PPTX.

في المثال أدناه، يتم تضمين مخطط من ملف Excel في شريحة كـ [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).

**ملاحظة:** يأخذ مُنشئ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) امتداد ملف الكائن القابل للتضمين كمعامل ثانٍ. يستخدم PowerPoint هذا الامتداد لتحديد نوع الملف واختيار التطبيق المناسب لفتح كائن OLE.

```py
with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]

    # Prepare the data for the OLE object.
    with open("book.xlsx", "rb") as file_stream:
        file_data = file_stream.read()
        data_info = slides.dom.ole.OleEmbeddedDataInfo(file_data, "xlsx")

    # Add an OLE object frame to the slide.
    ole_frame = slide.shapes.add_ole_object_frame(0, 0, slide_size.width, slide_size.height, data_info)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **إضافة كائنات OLE مرتبطة**

تتيح لك Aspose.Slides للـ Python إضافة [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) يرتبط بملف بدلاً من تضمين بياناته.

يعرض المثال التالي في Python كيفية إضافة [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) مرتبط بملف Excel على الشريحة:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Add an OLE object frame with a linked Excel file.
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **الوصول إلى كائنات OLE**

إذا كان كائن OLE مُضمّنًا بالفعل في شريحة، يمكنك الوصول إليه كما يلي:

1. حمّل العرض الذي يحتوي على كائن OLE المضمن بإنشاء نسخة من فئة Presentation.
1. احصل على مرجع إلى الشريحة بواسطة فهرسها.
1. وصول إلى شكل OleObjectFrame.
1. بمجرد حصولك على إطار كائن OLE، قم بتنفيذ أي عمليات مطلوبة عليه.

البرنامج التالي يصل إلى إطار كائن OLE — مخطط Excel مضمّن — ويسترجع بيانات ملفه. في هذا المثال، نستخدم PPTX يحتوي على شكل واحد في الشريحة الأولى.

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Get the embedded file data.
        file_data = ole_frame.embedded_data.embedded_file_data

        # Get the extension of the embedded file.
        file_extension = ole_frame.embedded_data.embedded_file_extension

        # ...
```

### **الوصول إلى خصائص كائن OLE المرتبط**

تتيح لك Aspose.Slides الوصول إلى خصائص إطار كائن OLE المرتبط.

يتحقق المثال التالي في Python مما إذا كان كائن OLE مرتبطًا، وإذا كان كذلك، يسترجع مسار الملف المرتبط:

```py
with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Check whether the OLE object is linked.
        if ole_frame.is_object_link:
            # Print the full path to the linked file.
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # Print the relative path to the linked file, if present.
            # Only .ppt presentations can contain a relative path.
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```

## **تغيير بيانات كائن OLE**

{{% alert color="primary" %}}

في هذا القسم، يستخدم مثال الشيفرة أدناه [Aspose.Cells للـ Python عبر .NET](/cells/python-net/).

{{% /alert %}}

إذا كان كائن OLE مُضمّنًا بالفعل في شريحة، يمكنك الوصول إليه وتعديل بياناته كما يلي:

1. حمّل العرض بإنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. احصل على الشريحة المستهدفة بواسطة فهرسها.
1. وصول إلى شكل [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).
1. بمجرد حصولك على إطار كائن OLE، نفّذ العمليات المطلوبة عليه.
1. أنشئ كائن `Workbook` واقرأ بيانات OLE.
1. افتح ورقة العمل المطلوبة وحرّر البيانات.
1. احفظ `Workbook` المحدث إلى تدفق.
1. استبدل بيانات كائن OLE باستخدام ذلك التدفق.

في المثال أدناه، يتم الوصول إلى إطار كائن OLE (مخطط Excel مضمّن) وتعديل بيانات ملفه لتحديث المخطط. يستخدم العينة PPTX تم إنشاؤه مسبقًا يحتوي على شكل واحد في الشريحة الأولى.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        with io.BytesIO(ole_frame.embedded_data.embedded_file_data) as ole_stream:
            # Read the OLE object data as a Workbook object.
            workbook = cells.Workbook(ole_stream)

        with io.BytesIO() as new_ole_stream:
            # Modify the workbook data.
            workbook.worksheets.get(0).cells.get(0, 4).put_value("E")
            workbook.worksheets.get(0).cells.get(1, 4).put_value(12)
            workbook.worksheets.get(0).cells.get(2, 4).put_value(14)
            workbook.worksheets.get(0).cells.get(3, 4).put_value(15)

            file_options = cells.OoxmlSaveOptions(cells.SaveFormat.XLSX)
            workbook.save(new_ole_stream, file_options)

            # Change the OLE frame object data.
            new_data = slides.dom.ole.OleEmbeddedDataInfo(new_ole_stream.getvalue(), ole_frame.embedded_data.embedded_file_extension)
            ole_frame.set_embedded_data(new_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **تضمين ملفات في الشرائح**

بالإضافة إلى مخططات Excel، تتيح لك Aspose.Slides للـ Python تضمين أنواع ملفات أخرى في الشرائح. على سبيل المثال، يمكنك إدراج ملفات HTML وPDF وZIP ككائنات. عند النقر المزدوج للمستخدم على كائن مُدرج، يفتح تلقائيًا في التطبيق المرتبط، أو يُطلب من المستخدم اختيار برنامج مناسب.

يعرض هذا الكود في Python كيفية تضمين ملفات HTML وZIP في شريحة:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("sample.html", "rb") as html_stream:
        html_data = html_stream.read()

    html_data_info = slides.dom.ole.OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.shapes.add_ole_object_frame(150, 120, 50, 50, html_data_info)
    html_ole_frame.is_object_icon = True

    with open("sample.zip", "rb") as zip_stream:
        zip_data = zip_stream.read()

    zip_data_info = slides.dom.ole.OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.shapes.add_ole_object_frame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين أنواع الملفات للكائنات المضمنة**

عند العمل مع العروض التقديمية، قد تحتاج إلى استبدال كائنات OLE القديمة بأخرى جديدة أو استبدال كائن OLE غير مدعوم بآخر مدعوم. تتيح لك Aspose.Slides للـ Python تعيين نوع ملف الكائن المضمن، مما يسمح لك بتحديث بيانات إطار OLE أو امتداد الملف الخاص به.

يعرض هذا الكود في Python كيفية تعيين نوع ملف كائن OLE المضمن إلى `zip`:

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    file_extension = ole_frame.embedded_data.embedded_file_extension
    file_data = ole_frame.embedded_data.embedded_file_data

    print(f"Current embedded file extension is: {file_extension}")

    # Change the file type to ZIP.
    ole_frame.set_embedded_data(slides.dom.ole.OleEmbeddedDataInfo(file_data, "zip"))

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين صور الأيقونة والعناوين للكائنات المضمنة**

بعد أن تقوم بتضمين كائن OLE، يتم إضافة معاينة قائمة على الأيقونة تلقائيًا. هذه المعاينة هي ما يراه المستخدمون قبل الوصول أو فتح كائن OLE. إذا رغبت في استخدام صورة ونص معينين في المعاينة، يمكنك تعيين صورة الأيقونة والعنوان باستخدام Aspose.Slides للـ Python.

يعرض هذا الكود في Python كيفية تعيين صورة الأيقونة والعنوان لكائن مضمّن:

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Add an image to the presentation resources.
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # Set a title and the image for the OLE preview.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **منع تغيير حجم وإعادة موضع إطارات OLE**

بعد إضافة كائن OLE مرتبط إلى شريحة، قد يطالب PowerPoint بتحديث الروابط عند فتح العرض. اختيار "تحديث الروابط" يمكن أن يغيّر حجم وإموضع إطار كائن OLE لأن PowerPoint يجدد المعاينة بالبيانات من الكائن المرتبط. لمنع PowerPoint من طلب تحديث بيانات الكائن، عيّن خاصية `update_automatic` في فئة [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) إلى `False`:

```py
ole_frame.update_automatic = False
```

## **استخراج الملفات المضمنة**

تتيح لك Aspose.Slides للـ Python استخراج الملفات المضمنة في الشرائح ككائنات OLE كما يلي:

1. أنشئ نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) التي تحتوي على كائنات OLE التي تريد استخراجها.
1. استعرض جميع الأشكال في العرض وحدد أشكال OLEObjectFrame.
1. استرجع بيانات الملف المضمن من كل [OLEObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) واكتبها إلى القرص.

يعرض الكود التالي في Python كيفية استخراج الملفات المضمنة في شريحة ككائنات OLE:

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for index, shape in enumerate(slide.shapes):
        if isinstance(shape, slides.OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.embedded_data.embedded_file_data
            file_extension = ole_frame.embedded_data.embedded_file_extension

            file_path = f"OLE_object_{index}{file_extension}"
            with open(file_path, 'wb') as file_stream:
                file_stream.write(file_data)
```

## **الأسئلة الشائعة**

**هل سيتم عرض محتوى OLE عند تصدير الشرائح إلى PDF/صور؟**

ما هو مرئي على الشريحة هو ما يتم تصييره — أي الأيقونة/صورة البديل (المعاينة). لا يتم تنفيذ محتوى OLE "الحي" أثناء التصيير. إذا لزم الأمر، عيّن صورة معاينة خاصة لضمان المظهر المتوقع في PDF المُصدّر.

**كيف يمكنني قفل كائن OLE على شريحة بحيث لا يتمكن المستخدمون من تحريكه/تحريره في PowerPoint؟**

قفل الشكل: توفر Aspose.Slides [قفل على مستوى الشكل](/slides/ar/python-net/applying-protection-to-presentation/). هذا ليس تشفيرًا، لكنه يمنع التعديلات والحركات غير المقصودة بفعالية.

**لماذا "يقفز" كائن Excel المرتبط أو يتغير حجمه عندما أفتح العرض؟**

قد يقوم PowerPoint بتحديث معاينة OLE المرتبط. للحصول على مظهر ثابت، اتبع ممارسات [حل العمل لإعادة تحجيم ورقة العمل](/slides/ar/python-net/working-solution-for-worksheet-resizing/) — إما ملاءمة الإطار للنطاق، أو تحجيم النطاق إلى إطار ثابت وتعيين صورة بديلة مناسبة.

**هل سيتم الحفاظ على المسارات النسبية لكائنات OLE المرتبطة في صيغة PPTX؟**

في PPTX، لا تتوفر معلومات "المسار النسبي" — فقط المسار الكامل. تُوجد المسارات النسبية في صيغة PPT القديمة. للانتشار، يفضل الاعتماد على مسارات مطلقة موثوقة/روابط URI قابلة للوصول أو التضمين.