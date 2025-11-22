---
title: إدارة OLE في العروض التقديمية باستخدام Python
linktitle: إدارة OLE
type: docs
weight: 40
url: /ar/python-net/manage-ole/
keywords:
- كائن OLE
- ربط الكائنات وتضمينها
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
description: "تحسين إدارة كائنات OLE في ملفات PowerPoint وOpenDocument باستخدام Aspose.Slides for Python عبر .NET. قم بتضمين محتوى OLE وتحديثه وتصديره بسلاسة."
---

## **نظرة عامة**

{{% alert title="Info" color="info" %}}
**OLE (ربط الكائنات وتضمينها)** هي تقنية من مايكروسوفت تسمح للبيانات والكائنات التي تم إنشاؤها في تطبيق واحد أن تكون مرتبطة أو مدمجة في تطبيق آخر.
{{% /alert %}}

على سبيل المثال، المخطط الذي تم إنشاؤه في Microsoft Excel وتم وضعه على شريحة PowerPoint هو كائن OLE.

- قد يظهر كائن OLE كأيقونة. النقر المزدوج على الأيقونة يفتح الكائن في التطبيق المرتبط به (مثلاً Excel) أو يطلب منك اختيار تطبيق لفتحه أو تحريره.
- قد يعرض كائن OLE محتوياته (مثلاً مخطط). في هذه الحالة، يقوم PowerPoint بتنشيط الكائن المدمج، يحمل واجهة المخطط، ويسمح لك بتحرير بيانات المخطط داخل PowerPoint.

Aspose.Slides for Python يتيح لك إدراج كائنات OLE في الشرائح كإطارات كائن OLE ([OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)).

## **إضافة كائنات OLE إلى الشرائح**

إذا كنت قد أنشأت مخططًا في Microsoft Excel وتريد تضمينه في شريحة كإطار كائن OLE باستخدام Aspose.Slides for Python، فاتبع الخطوات التالية:

1. أنشئ مثيلاً من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. احصل على مرجع إلى الشريحة بواسطة فهرستها.
3. اقرأ ملف Excel إلى مصفوفة بايت.
4. أضف [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) إلى الشريحة، مع توفير مصفوفة البايت وتفاصيل كائن OLE الأخرى.
5. احفظ العرض المعدل كملف PPTX.

في المثال أدناه، يتم تضمين مخطط من ملف Excel في شريحة كـ [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).

**ملاحظة:** يُحدّد مُنشئ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) امتداد ملف الكائن القابل للتضمين كمعلمه الثاني. يستخدم PowerPoint هذا الامتداد لتحديد نوع الملف واختيار التطبيق المناسب لفتح كائن OLE.
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


### **إضافة كائنات OLE المرتبطة**

Aspose.Slides for Python يتيح لك إضافة [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) يربط إلى ملف بدلاً من تضمين بياناته.

المثال التالي بلغة Python يوضح كيفية إضافة [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) مرتبط بملف Excel على شريحة:
```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # إضافة إطار كائن OLE مع ملف Excel مرتبط.
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **الوصول إلى كائنات OLE**

1. حمّل العرض الذي يحتوي على كائن OLE المدمج بإنشاء مثيل من فئة Presentation.
2. احصل على مرجع إلى الشريحة بواسطة فهرستها.
3. وصول إلى شكل OleObjectFrame.
4. بمجرد حصولك على إطار كائن OLE، قم بأي عمليات مطلوبة عليه.

المثال أدناه يصل إلى إطار كائن OLE — مخطط Excel مدمج — ويسترجع بيانات ملفه. في هذا المثال، نستخدم PPTX يحتوي على شكل واحد في الشريحة الأولى.
```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # احصل على بيانات الملف المضمّن.
        file_data = ole_frame.embedded_data.embedded_file_data

        # احصل على امتداد الملف المضمّن.
        file_extension = ole_frame.embedded_data.embedded_file_extension

        # ...
```


### **الوصول إلى خصائص كائن OLE المرتبط**

Aspose.Slides يتيح لك الوصول إلى خصائص إطار كائن OLE المرتبط.

المثال التالي بلغة Python يتحقق ما إذا كان كائن OLE مرتبطًا، وإذا كان كذلك، يسترجع مسار الملف المرتبط:
```py
with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # تحقق مما إذا كان كائن OLE مرتبطًا.
        if ole_frame.is_object_link:
            # اطبع المسار الكامل للملف المرتبط.
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # اطبع المسار النسبي للملف المرتبط إذا كان موجودًا.
            # يمكن لعروض .ppt فقط أن تحتوي على مسار نسبي.
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```


## **تغيير بيانات كائن OLE**

{{% alert color="primary" %}}
في هذا القسم، يستخدم المثال البرمجي أدناه [Aspose.Cells for Python via .NET](/cells/python-net/).
{{% /alert %}}

إذا كان كائن OLE مدمجًا بالفعل في شريحة، يمكنك الوصول إليه وتعديل بياناته كما يلي:

1. حمّل العرض بإنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. احصل على الشريحة المستهدفة بواسطة فهرستها.
3. وصول إلى شكل [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).
4. بمجرد حصولك على إطار كائن OLE، نفّذ العمليات المطلوبة عليه.
5. أنشئ كائن `Workbook` واقرأ بيانات OLE.
6. افتح `Worksheet` المطلوب وعدّل البيانات.
7. احفظ الـ `Workbook` المحدث إلى تدفق.
8. استبدل بيانات كائن OLE باستخدام ذلك التدفق.

في المثال أدناه، يتم الوصول إلى إطار كائن OLE (مخطط Excel مدمج) ويتم تعديل بيانات ملفه لتحديث المخطط. العينة تستخدم PPTX تم إنشاؤه مسبقًا يحتوي على شكل واحد في الشريحة الأولى.
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

بالإضافة إلى مخططات Excel، يتيح لك Aspose.Slides for Python تضمين أنواع ملفات أخرى في الشرائح. على سبيل المثال، يمكنك إدراج ملفات HTML وPDF وZIP ككائنات. عندما ينقر المستخدم مزدوجًا على كائن مُدرج، يفتح تلقائيًا في التطبيق المرتبط به، أو يُطلب من المستخدم اختيار برنامج مناسب.

يُظهر هذا الكود بلغة Python كيفية تضمين ملفات HTML وZIP في شريحة:
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


## **تحديد أنواع الملفات للكائنات المدمجة**

عند العمل على العروض التقديمية، قد تحتاج إلى استبدال كائنات OLE القديمة بأخرى جديدة أو استبدال كائن OLE غير مدعوم بآخر مدعوم. يتيح لك Aspose.Slides for Python تحديد نوع ملف الكائن المدمج، مما يسمح لك بتحديث بيانات إطار OLE أو امتداد ملفه.

يُظهر هذا الكود بلغة Python كيفية تعيين نوع ملف كائن OLE المدمج إلى `zip`:
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


## **تعيين صور الأيقونات والعناوين للكائنات المدمجة**

بعد تضمين كائن OLE، يتم إضافة معاينة قائمة على الأيقونة تلقائيًا. هذه المعاينة هي ما يراه المستخدمون قبل الوصول إلى كائن OLE أو فتحه. إذا أردت استخدام صورة ونص محددين في المعاينة، يمكنك تعيين صورة الأيقونة والعنوان باستخدام Aspose.Slides for Python.

يُظهر هذا الكود بلغة Python كيفية تعيين صورة الأيقونة والعنوان لكائن مدمج:
```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # إضافة صورة إلى موارد العرض التقديمي.
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # تعيين عنوان وصورة لعرض OLE المسبق.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **منع تغيير حجم وإعادة تموضع إطارات OLE**

بعد إضافة كائن OLE مرتبط إلى شريحة، قد يطلب منك PowerPoint تحديث الروابط عند فتح العرض. اختيار "تحديث الروابط" قد يغير حجم وإيجاز إطار كائن OLE لأن PowerPoint يُعيد تحديث المعاينة ببيانات الكائن المرتبط. لمنع PowerPoint من طلب تحديث بيانات الكائن، عيّن خاصية `update_automatic` للفئة [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) إلى `False`:
```py
ole_frame.update_automatic = False
```


## **استخراج الملفات المدمجة**

1. أنشئ مثيلاً من الفئة [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) التي تحتوي على كائنات OLE التي تريد استخراجها.
2. تكرّر عبر جميع الأشكال في العرض وحدد أشكال OLEObjectFrame.
3. استخرج بيانات الملف المدمج من كل [OLEObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) واكتبها إلى القرص.

يُظهر الكود التالي بلغة Python كيفية استخراج الملفات المدمجة في شريحة ككائنات OLE:
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


## **FAQ**

**هل سيتم عرض محتوى OLE عند تصدير الشرائح إلى PDF/صور؟**

ما هو مرئي على الشريحة هو ما يتم تصييره — الأيقونة/الصورة البديلة (المعاينة). لا يتم تنفيذ محتوى OLE "الحي" أثناء التصيير. إذا لزم الأمر، عيّن صورة معاينة خاصة بك لضمان المظهر المتوقع في ملف PDF المُصدر.

**كيف يمكنني قفل كائن OLE على شريحة بحيث لا يتمكن المستخدمون من تحريكه/تحريره في PowerPoint؟**

قم بقفل الشكل: Aspose.Slides يوفر [قفل على مستوى الشكل](/slides/ar/python-net/applying-protection-to-presentation/). ليس هذا تشفيرًا، لكنه يمنع فعليًا التعديلات غير المقصودة والتحريك.

**لماذا "يقفز" كائن Excel المرتبط أو يتغير حجمه عند فتح العرض؟**

قد يقوم PowerPoint بتحديث معاينة OLE المرتبط. للحصول على مظهر ثابت، اتبع ممارسات [الحل العملي لإعادة تحجيم ورقة العمل](/slides/ar/python-net/working-solution-for-worksheet-resizing/) — إما ضبط الإطار على النطاق، أو تحجيم النطاق إلى إطار ثابت وتعيين صورة بديلة مناسبة.

**هل ستُحافظ صيغ المسارات النسبية لكائنات OLE المرتبطة في تنسيق PPTX؟**

في PPTX، لا تتوفر معلومات "المسار النسبي" — فقط المسار الكامل. المسارات النسبية موجودة في تنسيق PPT القديم. من أجل القابلية للنقل، يفضَّل استخدام مسارات مطلقة موثوقة/URI قابلة للوصول أو التضمين.