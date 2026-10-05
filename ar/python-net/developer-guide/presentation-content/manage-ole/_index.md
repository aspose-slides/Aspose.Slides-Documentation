---
title: "إدارة OLE في العروض التقديمية باستخدام Python"
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
description: "تحسين إدارة كائنات OLE في ملفات PowerPoint و OpenDocument باستخدام Aspose.Slides للـ Python عبر .NET. قم بتضمين المحتوى وتحديثه وتصديره بسلاسة."
---
## **المقدمة**

{{% alert color="info" title="Note" %}}

**OLE (Object Linking & Embedding)** هي تقنية من مايكروسوفت تتيح ربط أو تضمين البيانات والكائنات التي تم إنشاؤها في تطبيق واحد داخل تطبيق آخر.

{{% /alert %}}

على سبيل المثال، المخطط الذي تم إنشاؤه في Microsoft Excel وتم وضعه في شريحة PowerPoint هو كائن OLE.

- قد يظهر كائن OLE على شكل أيقونة. يؤدي النقر المزدوج على الأيقونة إلى فتح الكائن في التطبيق المرتبط به (مثال، Excel) أو يطلب منك اختيار تطبيق لفتح الكائن أو تحريره.
- قد يعرض كائن OLE محتواه (مثال، مخطط). في هذه الحالة، يقوم PowerPoint بتنشيط الكائن المضمن، يحمل واجهة المخطط، ويتيح لك تحرير بيانات المخطط داخل PowerPoint.

تتيح لك Aspose.Slides للـ Python إدراج كائنات OLE في الشرائح كإطارات كائن OLE ([OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)).

## **إضافة كائنات OLE إلى الشرائح**

إذا قمت بإنشاء مخطط في Microsoft Excel وتريد تضمينه في شريحة كإطار كائن OLE باستخدام Aspose.Slides للـ Python، فاتبع الخطوات التالية:

1. أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. احصل على مرجع إلى الشريحة عن طريق فهرستها.
3. اقرأ ملف Excel إلى مصفوفة بايت.
4. أضف [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) إلى الشريحة، مع توفير مصفوفة البايت وتفاصيل أخرى لكائن OLE.
5. احفظ العرض المعدل كملف PPTX.

في المثال أدناه، يتم تضمين مخطط من ملف Excel في شريحة كـ [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).

**ملاحظة:** يأخذ المُنشئ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) امتداد ملف الكائن القابل للتضمين كمعامل ثاني. يستخدم PowerPoint هذا الامتداد لتحديد نوع الملف واختيار التطبيق المناسب لفتح كائن OLE.

```py
import aspose.slides as slides

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

### **إضافة كائنات OLE المرتبطة**

تتيح لك Aspose.Slides للـ Python إضافة [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) يرتبط بملف بدلاً من تضمين بياناته.

يوضح المثال التالي بلغة Python كيفية إضافة [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) مرتبط بملف Excel على شريحة:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # إضافة إطار كائن OLE مع ملف Excel مرتبط.
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **الوصول إلى كائنات OLE**

إذا كان كائن OLE مضمّنًا بالفعل في شريحة، يمكنك الوصول إليه كما يلي:

1. حمّل العرض الذي يحتوي على كائن OLE المضمّن عن طريق إنشاء كائن من الفئة Presentation .
2. احصل على مرجع إلى الشريحة عبر فهرستها.
3. الوصول إلى الشكل OleObjectFrame .
4. بمجرد حصولك على إطار كائن OLE، نفّذ أي عمليات مطلوبة عليه.

النوع التالي يصل إلى إطار كائن OLE — مخطط Excel مضمّن — ويسترجع بيانات ملفه. في هذا المثال، نستخدم ملف PPTX يحتوي على شكل واحد فقط في الشريحة الأولى.

```py
import aspose.slides as slides

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

يُظهر المثال التالي بلغة Python كيفية التحقق مما إذا كان كائن OLE مرتبطًا، وإذا كان كذلك، استرجاع مسار الملف المرتبط:

```py
import aspose.slides as slides

with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # تحقق مما إذا كان كائن OLE مرتبطًا.
        if ole_frame.is_object_link:
            # طباعة المسار الكامل للملف المرتبط.
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # طباعة المسار النسبي للملف المرتبط، إذا كان موجودًا.
            # يمكن فقط لعروض .ppt أن تحتوي على مسار نسبي.
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```

## **تغيير بيانات كائن OLE**

{{% alert color="info" title="Note" %}}

في هذا القسم، يستخدم المثال البرمجي أدناه [Aspose.Cells for Python via .NET](https://docs.aspose.com/cells/python-net/).

{{% /alert %}}

إذا كان كائن OLE مضمّنًا بالفعل في شريحة، يمكنك الوصول إليه وتعديل بياناته كما يلي:

1. حمّل العرض بإنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. احصل على الشريحة المستهدفة عبر فهرستها.
3. الوصول إلى الشكل [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) .
4. بمجرد حصولك على إطار OLE، نفّذ العمليات المطلوبة عليه.
5. أنشئ كائن `Workbook` واقرأ بيانات OLE.
6. افتح الـ `Worksheet` المطلوب وقم بتحرير البيانات.
7. احفظ الـ `Workbook` المحدث إلى تدفق.
8. استبدل بيانات كائن OLE باستخدام ذلك التدفق.

في المثال أدناه، يتم الوصول إلى إطار كائن OLE (مخطط Excel مضمّن) وتعديل بيانات ملفه لتحديث المخطط. يستخدم العينة ملف PPTX تم إنشاؤه مسبقًا يحتوي على شكل واحد فقط في الشريحة الأولى.

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

            # تغيير بيانات كائن إطار OLE.
            new_data = slides.dom.ole.OleEmbeddedDataInfo(new_ole_stream.getvalue(), ole_frame.embedded_data.embedded_file_extension)
            ole_frame.set_embedded_data(new_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **تضمين ملفات في الشرائح**

بالإضافة إلى مخططات Excel، تتيح لك Aspose.Slides للـ Python تضمين أنواع ملفات أخرى في الشرائح. على سبيل المثال، يمكنك إدراج ملفات HTML و PDF و ZIP ككائنات. عندما ينقر المستخدم مزدوجًا على كائن مُدرج، يفتح تلقائيًا في التطبيق المرتبط، أو يُطلب من المستخدم اختيار برنامج مناسب.

يظهر هذا الكود بلغة Python كيفية تضمين ملفات HTML و ZIP في شريحة:

```py
import aspose.slides as slides

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

## **تعيين نوع الملف للكائنات المضمنة**

عند العمل على العروض التقديمية، قد تحتاج إلى استبدال كائنات OLE القديمة بأخرى جديدة أو استبدال كائن OLE غير المدعوم بواحد مدعوم. تتيح لك Aspose.Slides للـ Python ضبط نوع ملف الكائن المضمن، مما يسمح لك بتحديث بيانات إطار OLE أو امتداد ملفه.

يُظهر هذا الكود بلغة Python كيفية تعيين نوع ملف الكائن OLE المضمن إلى `zip`:

```py
import aspose.slides as slides

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

## **تعيين صور الأيقونات والعناوين للكائنات المضمنة**

بعد تضمين كائن OLE، تُضاف معاينة مبنية على أيقونة تلقائيًا. هذه المعاينة هي ما يراه المستخدمون قبل الوصول إلى كائن OLE أو فتحه. إذا رغبت في استخدام صورة ونص معينين في المعاينة، يمكنك تعيين صورة الأيقونة والعنوان باستخدام Aspose.Slides للـ Python.

يُظهر هذا الكود بلغة Python كيفية تعيين صورة الأيقونة والعنوان لكائن مضمّن:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # إضافة صورة إلى موارد العرض التقديمي.
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # تحديد عنوان وصورة معاينة OLE.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **منع تغيير حجم وإعادة تموضع إطارات كائن OLE**

بعد إضافة كائن OLE مرتبط إلى شريحة، قد يطلب منك PowerPoint تحديث الروابط عند فتح العرض. اختيار تحديث الروابط يمكن أن يغيّر حجم وإسناد إطار كائن OLE لأن PowerPoint يُحدّث المعاينة ببيانات الكائن المرتبط. لمنع PowerPoint من طلب تحديث بيانات الكائن، اضبط الخاصية `update_automatic` للفئة [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) إلى `False`:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    ole_frame.update_automatic = False

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **استخراج الملفات المضمنة**

تتيح لك Aspose.Slides للـ Python استخراج الملفات المضمنة في الشرائح ككائنات OLE كما يلي:

1. أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) التي تحتوي على كائنات OLE التي تريد استخراجها.
2. تجول في جميع الأشكال في العرض وحدد أشكال OLEObjectFrame.
3. استخرج بيانات الملف المضمن من كل [OLEObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) واكتبها إلى القرص.

يعرض الكود التالي بلغة Python كيفية استخراج الملفات المضمنة في شريحة ككائنات OLE:

```py
import aspose.slides as slides

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

## **FAQ**

**هل سيتم عرض محتوى OLE عند تصدير الشرائح إلى PDF/صور؟**

ما هو مرئي على الشريحة هو ما يُرسم — الأيقونة/الصورة البديلة (المعاينة). لا يتم تنفيذ محتوى OLE "الحي" أثناء التصيير. إذا لزم الأمر، قم بتعيين صورة معاينة خاصة لضمان المظهر المتوقع في PDF المصدّر.  
للحفاظ أيضًا على الملف المضمن كمرفق PDF، اضبط [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) إلى `True`. هذا الخيار غير مفعل افتراضيًا. للحصول على مثال وتعليمات للتحقق من المرفق، راجع [حفظ ملفات OLE المضمنة كمرفقات PDF](/slides/ar/python-net/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**كيف يمكنني قفل كائن OLE على شريحة بحيث لا يستطيع المستخدمون تحريكه/تحريره في PowerPoint؟**

قفل الشكل: توفر Aspose.Slides [قفل على مستوى الشكل](/slides/ar/python-net/applying-protection-to-presentation/). هذا ليس تشفيرًا، لكنه يمنع فعليًا التعديلات أو التحركات غير المقصودة.

**لماذا يتحرك كائن Excel المرتبط "ينقُز" أو يتغير حجمه عند فتح العرض؟**

قد يقوم PowerPoint بتحديث معاينة OLE المرتبط. للحصول على مظهر ثابت، اتبع ممارسات [الحل العملي لتغيير حجم ورقة العمل](/slides/ar/python-net/working-solution-for-worksheet-resizing/) — إما ضبط الإطار ليتناسب مع النطاق، أو تعديل مقياس النطاق إلى إطار ثابت وتعيين صورة بديلة مناسبة.

**هل ستُحافظ صيغ المسارات النسبية لكائنات OLE المرتبطة في تنسيق PPTX؟**

في PPTX، لا تتوفر معلومات "المسار النسبي" — فقط المسار الكامل. تُستخدم المسارات النسبية في تنسيق PPT القديم. لضمان القابلية للنقل، يُنصح باستخدام مسارات مطلقة موثوقة/عناوين URI قابلة للوصول أو التضمين.