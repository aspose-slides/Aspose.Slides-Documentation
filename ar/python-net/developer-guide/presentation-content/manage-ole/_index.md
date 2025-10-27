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
description: "تحسين إدارة كائنات OLE في ملفات PowerPoint وOpenDocument باستخدام Aspose.Slides للـ Python عبر .NET. تضمين، تحديث، وتصدير محتوى OLE بسلاسة."
---

## **نظرة عامة**

{{% alert title="معلومات" color="info" %}}

**OLE (ربط وتضمين الكائنات)** هي تقنية من مايكروسوفت تتيح ربط أو تضمين البيانات والكائنات التي تم إنشاؤها في تطبيق ما داخل تطبيق آخر.

{{% /alert %}}

على سبيل المثال، المخطط الذي تم إنشاؤه في Microsoft Excel وتم وضعه على شريحة PowerPoint هو كائن OLE.

- قد يظهر كائن OLE كأيقونة. النقر المزدوج على الأيقونة يفتح الكائن في التطبيق المرتبط به (مثل Excel) أو يطلب منك اختيار تطبيق لفتح أو تحريره.
- قد يعرض كائن OLE محتوياته (مثال: مخطط). في هذه الحالة، يقوم PowerPoint بتنشيط الكائن المضمّن، ويحمل واجهة المخطط، ويسمح لك بتحرير بيانات المخطط داخل PowerPoint.

تتيح لك Aspose.Slides للـ Python إدراج كائنات OLE في الشرائح كإطارات كائنات OLE ([OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)).

## **إضافة كائنات OLE إلى الشرائح**

إذا كنت قد أنشأت مخططًا في Microsoft Excel وتريد تضمينه في شريحة كإطار كائن OLE باستخدام Aspose.Slides للـ Python، فاتبع الخطوات التالية:

1. أنشئ مثيلًا من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. احصل على مرجع إلى الشريحة حسب فهرسها.
1. اقرأ ملف Excel إلى مصفوفة بايت.
1. أضف [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) إلى الشريحة، مع تمرير مصفوفة البايت وتفاصيل كائن OLE الأخرى.
1. احفظ العرض المعدل كملف PPTX.

في المثال أدناه، يتم تضمين مخطط من ملف Excel في شريحة كـ [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).

**ملاحظة:** يأخذ المُنشئ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) امتداد ملف الكائن القابل للتضمين كمعامل ثانٍ. يستخدم PowerPoint هذا الامتداد لتحديد نوع الملف واختيار التطبيق المناسب لفتح كائن OLE.

```py
with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]

    # إعداد البيانات لكائن OLE.
    with open("book.xlsx", "rb") as file_stream:
        file_data = file_stream.read()
        data_info = slides.dom.ole.OleEmbeddedDataInfo(file_data, "xlsx")

    # إضافة إطار كائن OLE إلى الشريحة.
    ole_frame = slide.shapes.add_ole_object_frame(0, 0, slide_size.width, slide_size.height, data_info)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **إضافة كائنات OLE مرتبطة**

تتيح لك Aspose.Slides للـ Python إضافة [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) يرتبط بملف بدلاً من تضمين بياناته.

يعرض المثال التالي بلغة Python كيفية إضافة [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) مرتبط بملف Excel على شريحة:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # إضافة إطار كائن OLE بملف Excel مرتبط.
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **الوصول إلى كائنات OLE**

إذا كان كائن OLE مضمّنًا بالفعل في شريحة، يمكنك الوصول إليه كما يلي:

1. تحميل العرض الذي يحتوي على كائن OLE المضمّن بإنشاء مثيل من فئة Presentation.
1. الحصول على مرجع إلى الشريحة حسب فهرسها.
1. الوصول إلى شكل OleObjectFrame.
1. بمجرد حصولك على إطار كائن OLE، قم بتنفيذ أي عمليات مطلوبة عليه.

الوضع التالي يصل إلى إطار كائن OLE—مخطط Excel مضمّن—ويستخرج بيانات ملفه. في هذا المثال، نستخدم ملف PPTX يحتوي على شكل واحد في الشريحة الأولى.

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # الحصول على بيانات الملف المضمّن.
        file_data = ole_frame.embedded_data.embedded_file_data

        # الحصول على امتداد الملف المضمّن.
        file_extension = ole_frame.embedded_data.embedded_file_extension

        # ...
```

### **الوصول إلى خصائص كائن OLE المرتبط**

تتيح لك Aspose.Slides الوصول إلى خصائص إطار كائن OLE المرتبط.

البرنامج التالي بلغة Python يتحقق مما إذا كان كائن OLE مرتبطًا، وإذا كان كذلك، يستخرج مسار الملف المرتبط:

```py
with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # التحقق مما إذا كان كائن OLE مرتبطًا.
        if ole_frame.is_object_link:
            # طباعة المسار الكامل للملف المرتبط.
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # طباعة المسار النسبي للملف المرتبط، إذا كان موجودًا.
            # يمكن فقط لعروض PPT أن تحتوي على مسار نسبي.
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```

## **تغيير بيانات كائن OLE**

{{% alert color="primary" %}}

في هذا القسم، يستخدم المثال البرمجي [Aspose.Cells للـ Python عبر .NET](/cells/python-net/).

{{% /alert %}}

إذا كان كائن OLE مضمّنًا بالفعل في شريحة، يمكنك الوصول إليه وتعديل بياناته كما يلي:

1. تحميل العرض بإنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على الشريحة المستهدفة حسب فهرسها.
1. الوصول إلى شكل [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).
1. بمجرد حصولك على إطار كائن OLE، نفّذ العمليات المطلوبة عليه.
1. إنشاء كائن `Workbook` وقراءة بيانات OLE.
1. فتح ورقة `Worksheet` المطلوبة وتحرير البيانات.
1. حفظ `Workbook` المحدث إلى تدفق.
1. استبدال بيانات كائن OLE باستخدام ذلك التدفق.

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
            # قراءة بيانات كائن OLE ككائن Workbook.
            workbook = cells.Workbook(ole_stream)

        with io.BytesIO() as new_ole_stream:
            # تعديل بيانات المصنف.
            workbook.worksheets.get(0).cells.get(0, 4).put_value("E")
            workbook.worksheets.get(0).cells.get(1, 4).put_value(12)
            workbook.worksheets.get(0).cells.get(2, 4).put_value(14)
            workbook.worksheets.get(0).cells.get(3, 4).put_value(15)

            file_options = cells.OoxmlSaveOptions(cells.SaveFormat.XLSX)
            workbook.save(new_ole_stream, file_options)

            # تغيير بيانات إطار OLE.
            new_data = slides.dom.ole.OleEmbeddedDataInfo(new_ole_stream.getvalue(), ole_frame.embedded_data.embedded_file_extension)
            ole_frame.set_embedded_data(new_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **تضمين ملفات في الشرائح**

بالإضافة إلى مخططات Excel، تتيح لك Aspose.Slides للـ Python تضمين أنواع ملفات أخرى في الشرائح. على سبيل المثال، يمكنك إدراج ملفات HTML وPDF وZIP ككائنات. عندما ينقر المستخدم مزدوجًا على الكائن المدخل، يفتح تلقائيًا في التطبيق المرتبط، أو يُطلب منه اختيار برنامج مناسب.

يعرض هذا الكود بلغة Python كيفية تضمين ملفات HTML وZIP في شريحة:

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

## **تحديد نوع الملف للكائنات المضمّنة**

عند العمل مع العروض التقديمية، قد تحتاج إلى استبدال كائنات OLE القديمة بأخرى جديدة أو استبدال كائن OLE غير مدعوم بآخر مدعوم. تتيح لك Aspose.Slides للـ Python تحديد نوع ملف الكائن المضمّن، مما يسمح لك بتحديث بيانات إطار OLE أو امتداد ملفه.

يعرض الكود التالي بلغة Python كيفية تعيين نوع ملف كائن OLE المضمّن إلى `zip`:

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    file_extension = ole_frame.embedded_data.embedded_file_extension
    file_data = ole_frame.embedded_data.embedded_file_data

    print(f"Current embedded file extension is: {file_extension}")

    # تغيير نوع الملف إلى ZIP.
    ole_frame.set_embedded_data(slides.dom.ole.OleEmbeddedDataInfo(file_data, "zip"))

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **تعيين صور الأيقونة والعناوين للكائنات المضمّنة**

بعد أن تقوم بتضمين كائن OLE، تُضاف معاينة مبنية على الأيقونة تلقائيًا. هذه المعاينة هي ما يراه المستخدمون قبل الوصول إلى الكائن أو فتحه. إذا رغبت في استخدام صورة ونص محددين في المعاينة، يمكنك تعيين صورة الأيقونة والعنوان باستخدام Aspose.Slides للـ Python.

الكود التالي بلغة Python يوضح كيفية تعيين صورة الأيقونة والعنوان لكائن مضمّن:

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # إضافة صورة إلى موارد العرض.
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # تعيين عنوان وصورة للمعاينة.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **منع تغيير حجم وإعادة تموضع إطارات كائن OLE**

بعد إضافة كائن OLE مرتبط إلى شريحة، قد يطلب PowerPoint تحديث الروابط عند فتح العرض. اختيار "Update Links" قد يغيّر حجم وإحداثيات إطار كائن OLE لأن PowerPoint يجدد المعاينة باستخدام بيانات الكائن المرتبط. لمنع PowerPoint من طلب تحديث بيانات الكائن، اضبط الخاصية `update_automatic` للفئة [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) إلى `False`:

```py
ole_frame.update_automatic = False
```

## **استخراج الملفات المضمّنة**

تتيح لك Aspose.Slides للـ Python استخراج الملفات المضمّنة في الشرائح ككائنات OLE كما يلي:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) التي تحتوي على كائنات OLE التي تريد استخراجها.
1. استعرض جميع الأشكال في العرض وحدد أشكال OLEObjectFrame.
1. استخرج بيانات الملف المضمّن من كل [OLEObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) واكتبها إلى القرص.

يعرض الكود التالي بلغة Python كيفية استخراج الملفات المضمّنة في شريحة ككائنات OLE:

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

## **الأسئلة المتكررة**

**هل سيتم عرض محتوى OLE عند تصدير الشرائح إلى PDF/صور؟**

ما يُرى على الشريحة هو ما يتم تصييره — أي الأيقونة/الصورة البديلة (المعاينة). لا يتم تنفيذ محتوى OLE "المباشر" أثناء التصيير. إذا لزم الأمر، عيّن صورة معاينة خاصة لضمان المظهر المتوقع في ملف PDF المصدر.

**كيف يمكنني قفل كائن OLE على الشريحة بحيث لا يتمكن المستخدمون من تحريكه/تحريره في PowerPoint؟**

قفل الشكل: توفر Aspose.Slides [قوانين القفل على مستوى الشكل](/slides/ar/python-net/applying-protection-to-presentation/). هذا ليس تشفيرًا، لكنه يمنع التحرير والحركة غير المقصودة فعليًا.

**لماذا "يقفز" كائن Excel المرتبط أو يتغيّر حجمه عند فتح العرض؟**

قد يقوم PowerPoint بتحديث معاينة OLE المرتبط. للحصول على مظهر ثابت، اتبع ممارسات [الحل العملي لتغيير حجم ورقة العمل](/slides/ar/python-net/working-solution-for-worksheet-resizing/) — إما ملاءمة الإطار للنطاق، أو تعديل النطاق ليناسب إطار ثابت وتعيين صورة بديلة ملائمة.

**هل ستحافظ صيغ PPTX على المسارات النسبية للكائنات OLE المرتبطة؟**

في PPTX لا تتوفر معلومات "المسار النسبي" — فقط المسار الكامل. تظهر المسارات النسبية في صيغة PPT القديمة. لضمان قابلية النقل، يفضَّل استخدام مسارات مطلقة موثوقة/عناوين URI قابلة للوصول أو التضمين.