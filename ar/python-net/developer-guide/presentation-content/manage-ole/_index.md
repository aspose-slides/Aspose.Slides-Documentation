---
title: "إدارة OLE في العروض التقديمية باستخدام بايثون"
linktitle: "إدارة OLE"
type: docs
weight: 40
url: /ar/python-net/manage-ole/
keywords:
- "كائن OLE"
- "ربط وتضمين الكائنات"
- "إضافة OLE"
- "تضمين OLE"
- "إضافة كائن"
- "تضمين كائن"
- "إضافة ملف"
- "تضمين ملف"
- "كائن مرتبط"
- "ملف مرتبط"
- "تغيير OLE"
- "أيقونة OLE"
- "عنوان OLE"
- "استخراج OLE"
- "استخراج كائن"
- "استخراج ملف"
- "PowerPoint"
- "عرض تقديمي"
- "Python"
- "Aspose.Slides"
description: "تحسين إدارة كائنات OLE في ملفات PowerPoint وOpenDocument باستخدام Aspose.Slides للبايثون عبر .NET. تضمين، تحديث وتصدير محتوى OLE بسهولة."
---

## **نظرة عامة**

{{% alert title="معلومات" color="info" %}}

**OLE (Object Linking & Embedding)** هي تقنية من مايكروسوفت تسمح بربط أو تضمين البيانات والكائنات التي تم إنشاؤها في تطبيق واحد داخل تطبيق آخر.

{{% /alert %}}

على سبيل المثال، المخطط الذي تم إنشاؤه في Microsoft Excel ووضعه على شريحة PowerPoint هو كائن OLE.

- قد يظهر كائن OLE كأيقونة. النقر المزدوج على الأيقونة يفتح الكائن في التطبيق المرتبط به (مثل Excel) أو يطلب منك اختيار تطبيق لفتحه أو تعديله.
- قد يعرض كائن OLE محتوياته (مثل المخطط). في هذه الحالة، يقوم PowerPoint بتنشيط الكائن المضمّن، ويحمل واجهة المخطط، ويسمح لك بتحرير بيانات المخطط داخل PowerPoint.

يسمح Aspose.Slides للبايثون بإدراج كائنات OLE في الشرائح كإطارات كائن OLE ([OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)).

## **إضافة كائنات OLE إلى الشرائح**

إذا كنت قد أنشأت مخططًا في Microsoft Excel وتريد تضمينه في شريحة كإطار كائن OLE باستخدام Aspose.Slides للبايثون، اتبع الخطوات التالية:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على مرجع إلى الشريحة بواسطة فهرسها.
1. قراءة ملف Excel إلى مصفوفة بايت.
1. إضافة [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) إلى الشريحة، مع توفير مصفوفة البايت وتفاصيل كائن OLE الأخرى.
1. حفظ العرض التقديمي المعدل كملف PPTX.

في المثال أدناه، يتم تضمين مخطط من ملف Excel في شريحة كـ[OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).

**ملاحظة:** يأخذ المُنشئ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) امتداد ملف الكائن القابل للتضمين كمعامله الثاني. يستخدم PowerPoint هذا الامتداد لتحديد نوع الملف وتحديد التطبيق المناسب لفتح كائن OLE.

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

يسمح Aspose.Slides للبايثون بإضافة [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) يربط بملف بدلاً من تضمين بياناته.

المثال التالي في بايثون يوضح كيفية إضافة [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) مرتبط بملف Excel على شريحة:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # إضافة إطار كائن OLE مع ملف Excel مرتبط.
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **الوصول إلى كائنات OLE**

إذا كان كائن OLE مضمّنًا بالفعل في شريحة، يمكنك الوصول إليه كما يلي:

1. تحميل العرض التقديمي الذي يحتوي على كائن OLE المضمّن بإنشاء نسخة من فئة Presentation.
1. الحصول على مرجع إلى الشريحة بواسطة فهرسها.
1. الوصول إلى شكل OleObjectFrame.
1. بمجرد حصولك على إطار كائن OLE، نفّذ أي عمليات مطلوبة عليه.

المثال أدناه يصل إلى إطار كائن OLE — مخطط Excel مضمّن — ويسترجع بيانات ملفه. في هذا المثال نستخدم PPTX يحتوي على شكل واحد فقط في الشريحة الأولى.

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

يسمح Aspose.Slides بالوصول إلى خصائص إطار كائن OLE المرتبط.

المثال التالي في بايثون يتحقق مما إذا كان كائن OLE مرتبطًا، وإذا كان كذلك، يسترجع مسار الملف المرتبط:

```py
with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # التحقق مما إذا كان كائن OLE مرتبطاً.
        if ole_frame.is_object_link:
            # طباعة المسار الكامل للملف المرتبط.
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # طباعة المسار النسبي للملف المرتبط إذا كان موجوداً.
            # يمكن فقط لعروض .ppt أن تحتوي على مسار نسبي.
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```

## **تغيير بيانات كائن OLE**

{{% alert color="primary" %}}

في هذا القسم، يستخدم المثال أدناه [Aspose.Cells للبايثون عبر .NET](/cells/python-net/).

{{% /alert %}}

إذا كان كائن OLE مضمّنًا بالفعل في شريحة، يمكنك الوصول إليه وتعديل بياناته كما يلي:

1. تحميل العرض التقديمي بإنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. الحصول على الشريحة المستهدفة بواسطة فهرسها.
1. الوصول إلى شكل [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).
1. بمجرد حصولك على إطار كائن OLE، نفّذ العمليات المطلوبة.
1. إنشاء كائن `Workbook` وقراءة بيانات OLE.
1. فتح `Worksheet` المطلوب وتعديل البيانات.
1. حفظ `Workbook` المحدث إلى تدفق.
1. استبدال بيانات كائن OLE باستخدام ذلك التدفق.

في المثال أدناه، يتم الوصول إلى إطار كائن OLE (مخطط Excel مضمّن) وتعديل بيانات ملفه لتحديث المخطط. يستخدم العينة PPTX تم إنشاؤها مسبقًا وتحتوي على شكل واحد في الشريحة الأولى.

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

            # تغيير بيانات إطار كائن OLE.
            new_data = slides.dom.ole.OleEmbeddedDataInfo(new_ole_stream.getvalue(), ole_frame.embedded_data.embedded_file_extension)
            ole_frame.set_embedded_data(new_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **تضمين ملفات في الشرائح**

بالإضافة إلى مخططات Excel، يتيح Aspose.Slides للبايثون تضمين أنواع ملفات أخرى في الشرائح. على سبيل المثال، يمكنك إدراج ملفات HTML وPDF وZIP ككائنات. عندما ينقر المستخدم مرتين على كائن مُدرج، يفتح تلقائيًا في التطبيق المرتبط، أو يُطلب منه اختيار برنامج مناسب.

يوضح الكود التالي كيفية تضمين ملفات HTML وZIP في شريحة:

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

## **تعيين نوع الملف للكائنات المضمّنة**

عند العمل مع العروض التقديمية، قد تحتاج إلى استبدال كائنات OLE القديمة بأخرى جديدة أو استبدال كائن OLE غير مدعوم بآخر مدعوم. يسمح Aspose.Slides للبايثون بتعيين نوع ملف كائن مضمّن، مما يتيح لك تحديث بيانات إطار OLE أو امتداد ملفه.

يوضح الكود التالي كيفية تعيين نوع ملف كائن OLE المضمّن إلى `zip`:

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

بعد أن تضمن كائن OLE، يتم إضافة معاينة مبنية على أيقونة تلقائيًا. هذه المعاينة ما يراه المستخدمون قبل الوصول أو فتح كائن OLE. إذا رغبت في استخدام صورة ونص معينين في المعاينة، يمكنك تعيين صورة الأيقونة والعنوان باستخدام Aspose.Slides للبايثون.

يوضح الكود التالي كيفية تعيين صورة الأيقونة والعنوان لكائن مضمّن:

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # إضافة صورة إلى موارد العرض التقديمي.
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # تعيين عنوان وصورة المعاينة لـ OLE.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **الإيقاف عن تغيير حجم وإعادة تموضع إطارات OLE**

بعد إضافة كائن OLE مرتبط إلى شريحة، قد يطلب PowerPoint تحديث الروابط عند فتح العرض. تحديد "تحديث الروابط" يمكن أن يغير حجم وإمكان إطار كائن OLE لأن PowerPoint يجدد المعاينة ببيانات الكائن المرتبط. لمنع PowerPoint من طلب تحديث بيانات الكائن، عيّن الخاصية `update_automatic` للفئة [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) إلى `False`:

```py
ole_frame.update_automatic = False
```

## **استخراج الملفات المضمّنة**

يسمح Aspose.Slides للبايثون باستخراج الملفات المضمّنة في الشرائح ككائنات OLE كما يلي:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) التي تحتوي على كائنات OLE التي تريد استخراجها.
1. التكرار عبر جميع الأشكال في العرض وتحديد أشكال OLEObjectFrame.
1. استرجاع بيانات الملف المضمّن من كل [OLEObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) وكتابتها إلى القرص.

الكود التالي في بايثون يوضح كيفية استخراج الملفات المضمّنة في شريحة ككائنات OLE:

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

**هل يتم عرض محتوى OLE عند تصدير الشرائح إلى PDF/صور؟**

ما يُرى على الشريحة هو ما يتم تصييره — الأيقونة/صورة المعاينة. لا يُنفّذ محتوى OLE "الحي" أثناء التصيير. إذا لزم الأمر، عيّن صورة معاينة خاصة لضمان المظهر المتوقع في ملف PDF المُصدّر.

**كيف يمكن قفل كائن OLE على شريحة بحيث لا يتمكن المستخدمون من تحريكه/تحريره في PowerPoint؟**

قفل الشكل: يوفر Aspose.Slides [قفل على مستوى الشكل](/slides/ar/python-net/applying-protection-to-presentation/). هذا ليس تشفيرًا، لكنه يمنع التعديلات غير المقصودة والتحريك.

**لماذا "ينقُط" كائن Excel المرتبط أو يتغير حجمه عند فتح العرض؟**

قد يقوم PowerPoint بتجديد معاينة OLE المرتبط. للحصول على مظهر مستقر، اتبع ممارسات [الحل العملي لتغيير حجم ورقة العمل](/slides/ar/python-net/working-solution-for-worksheet-resizing/) — إما ضبط الإطار ليناسب النطاق، أو تحجيم النطاق إلى إطار ثابت وتعيين صورة معاينة مناسبة.

**هل يتم الحفاظ على المسارات النسبية لكائنات OLE المرتبطة في تنسيق PPTX؟**

في PPTX، لا تتوفر معلومات "المسار النسبي" — فقط المسار الكامل. تُوجد المسارات النسبية في تنسيق PPT الأقدم. لضمان قابلية النقل، يفضَّل استخدام مسارات مطلقة موثوقة/عناوين URI قابلة للوصول أو التضمين.