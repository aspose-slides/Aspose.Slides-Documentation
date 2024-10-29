---
title: إدارة OLE
type: docs
weight: 40
url: /ar/python-net/manage-ole/
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
- Python
- Aspose.Slides لـ Python عبر .NET
description: إضافة كائنات OLE إلى عروض PowerPoint التقديمية في Python
---

{{% alert title="معلومات" color="info" %}}

OLE (ربط الكائنات وتضمينها) هي تقنية من مايكروسوفت تسمح بتضمين البيانات والكائنات التي تم إنشاؤها في تطبيق واحد داخل تطبيق آخر من خلال الربط أو التضمين.

{{% /alert %}}

اعتبر رسمًا بيانيًا تم إنشاؤه في MS Excel. يتم وضع الرسم البياني بعد ذلك داخل شريحة PowerPoint. يُعتبر هذا الرسم البياني في Excel كائن OLE.

- قد يظهر كائن OLE كرمز. في هذه الحالة، عندما تقوم بالنقر المزدوج على الرمز، يتم فتح الرسم البياني في التطبيق المرتبط به (Excel)، أو يُطلب منك اختيار تطبيق لفتح أو تعديل الكائن.
- قد يعرض كائن OLE المحتويات الفعلية - على سبيل المثال، محتويات الرسم البياني. في هذه الحالة، يتم تنشيط الرسم البياني في PowerPoint، وتحميل واجهة الرسم البياني، وتتمكن من تعديل بيانات الرسم البياني داخل تطبيق PowerPoint.

[Aspose.Slides لـ Python عبر .NET](https://products.aspose.com/slides/python-net) يتيح لك إدراج كائنات OLE في الشرائح كإطارات كائن OLE ([OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)).

## **إضافة إطارات كائن OLE إلى الشرائح**
بافتراض أنك قد أنشأت بالفعل رسمًا بيانيًا في Microsoft Excel وتريد تضمين هذا الرسم البياني في شريحة كإطار كائن OLE باستخدام Aspose.Slides لـ Python عبر .NET، يمكنك القيام بذلك بهذه الطريقة:

1. إنشاء نسخة من [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.
1. الحصول على مرجع الشريحة من خلال فهرسها.
1. فتح ملف Excel الذي يحتوي على كائن الرسم البياني في Excel وحفظه في `MemoryStream`.
1. إضافة إطار كائن OLE إلى الشريحة مع مصفوفة بايت ومعلومات أخرى حول كائن OLE.
1. كتابة العرض التقديمي المعدل كملف PPTX.

في المثال أدناه، أضفنا رسمًا بيانيًا من ملف Excel إلى شريحة كإطار [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) باستخدام Aspose.Slides لـ Python عبر .NET.  
**ملاحظة** أن المُنشئ [IOleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides/ioleembeddeddatainfo/) يأخذ امتداد الكائن القابل للتضمين كمعامل ثانٍ. هذا الامتداد يسمح لـ PowerPoint بتفسير نوع الملف بشكل صحيح واختيار التطبيق المناسب لفتح هذا الكائن OLE.

```py 
import aspose.slides as slides

# ينشئ عرض تقديمي يمثل PPTX
with slides.Presentation() as pres:
    # وصول إلى الشريحة الأولى
    sld = pres.slides[0]

    # تحميل ملف Excel إلى التدفق
    with open(path + "book1.xlsx", "rb") as fs:
        bytes = fs.read()
    
        # إنشاء كائن بيانات للتضمين
        dataInfo = slides.dom.ole.OleEmbeddedDataInfo(bytes, "xlsx")

        # إضافة شكل إطار كائن Ole
        oleObjectFrame = sld.shapes.add_ole_object_frame(0, 0, pres.slide_size.size.width, pres.slide_size.size.height, dataInfo)

        # كتابة ملف PPTX إلى القرص
        pres.save("OleEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```
## **الوصول إلى إطارات كائن OLE**
إذا كان كائن OLE مضمنًا بالفعل في شريحة، يمكنك العثور على ذلك الكائن أو الوصول إليه بهذه الطريقة بسهولة:

1. إنشاء نسخة من [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.

1. الحصول على مرجع الشريحة باستخدام فهرسها.

1. الوصول إلى شكل [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).

   في مثالنا، استخدمنا PPTX الذي تم إنشاؤه مسبقًا والذي يحتوي على شكل واحد فقط على الشريحة الأولى. ثم *قمنا بتحويل* ذلك الكائن إلى [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/). كانت هذه هي إطار كائن OLE المرغوب للوصول إليه.

1. بمجرد الوصول إلى إطار كائن OLE، يمكنك إجراء أي عملية عليه.

في المثال أدناه، يتم الوصول إلى إطار كائن OLE (كائن رسم بياني Excel مضمن في شريحة) - ثم يتم كتابة بيانات ملفه إلى ملف Excel:

```py 
import aspose.slides as slides

# تحميل PPTX إلى كائن عرض تقديمي
with slides.Presentation(path + "AccessingOLEObjectFrame.pptx") as pres:
    # الوصول إلى الشريحة الأولى
    sld = pres.slides[0]

    # تحويل الشكل إلى OleObjectFrame
    oleObjectFrame = sld.shapes[0]

    # قراءة كائن OLE وكتابته إلى القرص
    if type(oleObjectFrame) is slides.OleObjectFrame:
        # الحصول على بيانات الملف المضمنة
        data = oleObjectFrame.embedded_data.embedded_file_data

        # الحصول على امتداد الملف المضمن
        fileExtention = oleObjectFrame.embedded_data.embedded_file_extension

        # إنشاء مسار لحفظ الملف المستخرج
        extractedPath = "excelFromOLE_out" + fileExtention

        # حفظ البيانات المستخرجة
        with open("out.xlsx", "wb") as fs:
            fs.write(data)
```

## **تغيير بيانات كائن OLE**

إذا كان كائن OLE مضمنًا بالفعل في شريحة، يمكنك الوصول بسهولة إلى ذلك الكائن مع Aspose.Slides لـ Python عبر .NET وتعديل بياناته بهذه الطريقة:

1. فتح العرض التقديمي المطلوب مع كائن OLE المضمن عن طريق إنشاء نسخة من [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) class.

1. الحصول على مرجع الشريحة من خلال فهرسها.

1. الوصول إلى شكل [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).

   في مثالنا، استخدمنا PPTX الذي تم إنشاؤه مسبقًا، والذي يحتوي على شكل واحد فقط على الشريحة الأولى. ثم *قمنا بتحويل* هذا الكائن إلى [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/). كانت هذه هي إطار كائن OLE المرغوب للوصول إليه.

1. بمجرد الوصول إلى إطار كائن OLE، يمكنك إجراء أي عملية عليه.

1. إنشاء كائن Workbook والوصول إلى بيانات OLE.

1. الوصول إلى ورقة العمل المطلوبة وتعديل البيانات.

1. حفظ Workbook المحدث في التدفقات.

1. تغيير بيانات كائن OLE من بيانات التدفق.

في المثال أدناه، يتم الوصول إلى إطار كائن OLE (كائن رسم بياني Excel مضمن في شريحة) - ثم يتم تعديل بيانات الملف الخاصة به لتغيير بيانات الرسم البياني.

```py 
# [TODO:require Aspose.Cells for Python via .NET]
```

## تضمين أنواع ملفات أخرى في الشرائح

بالإضافة إلى الرسوم البيانية في Excel، يتيح لك Aspose.Slides لـ Python عبر .NET تضمين أنواع أخرى من الملفات في الشرائح. على سبيل المثال، يمكنك إدخال ملفات HTML وPDF وZIP ككائنات في الشريحة. عندما يقوم المستخدم بالنقر المزدوج على الكائن المدخل، يتم تلقائيًا تشغيل الكائن في البرنامج المناسب، أو يتم توجيه المستخدم لاختيار برنامج مناسب لفتح الكائن.

توضح لك هذه الشفرة البرمجية Python كيفية تضمين HTML وZIP في شريحة:

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    with open(path + "index.html", "rb") as fs1:
        htmlBytes = fs1.read()
        dataInfoHtml = slides.dom.ole.OleEmbeddedDataInfo(htmlBytes, "html")
        oleFrameHtml = slide.shapes.add_ole_object_frame(150, 120, 50, 50, dataInfoHtml)
        oleFrameHtml.is_object_icon = True

    with open(path + "archive.zip", "rb") as fs2:
        zipBytes = fs2.read()
        dataInfoZip = slides.dom.ole.OleEmbeddedDataInfo(zipBytes, "zip")
        oleFrameZip = slide.shapes.add_ole_object_frame(150, 220, 50, 50, dataInfoZip)
        oleFrameZip.is_object_icon = True

    pres.save("embeddedOle.pptx", slides.export.SaveFormat.PPTX)
```

## تعيين أنواع الملفات لكائنات مضمنة

عند العمل على العروض التقديمية، قد تحتاج إلى استبدال كائنات OLE القديمة بكائنات جديدة. أو قد تحتاج إلى استبدال كائن OLE غير المدعوم بكائن مدعوم.

يتيح لك Aspose.Slides لـ Python عبر .NET تعيين نوع الملف لكائن مضمن. بهذه الطريقة، يمكنك تغيير بيانات إطار OLE أو امتداده.

توضح لك هذه الشفرة البرمجية Python كيفية تعيين نوع الملف لكائن OLE مضمن:

```py
import aspose.slides as slides

with slides.Presentation("embeddedOle.pptx") as pres:
    slide = pres.slides[0]
    oleObjectFrame = slide.shapes[0]
    print("امتداد البيانات المضمنة الحالي هو:" + oleObjectFrame.embedded_data.embedded_file_extension)
   
    with open(path + "1.zip", "rb") as fs2:
        zipBytes = fs2.read()

    oleObjectFrame.set_embedded_data(slides.dom.ole.OleEmbeddedDataInfo(zipBytes, "zip"))
   
    pres.save("embeddedChanged.pptx", slides.export.SaveFormat.PPTX)
```

## تعيين صور الأيقونات والعناوين لكائنات مضمنة

بعد أن تقوم بتضمين كائن OLE، يتم تلقائيًا إضافة معاينة تتكون من صورة أيقونة وعنوان. هذه المعاينة هي ما يراه المستخدمون قبل الوصول إلى الكائن OLE أو فتحه.

إذا كنت ترغب في استخدام صورة ونص معينين كعناصر في المعاينة، يمكنك تعيين صورة الأيقونة والعنوان باستخدام Aspose.Slides لـ Python عبر .NET.

توضح لك هذه الشفرة البرمجية Python كيفية تعيين صورة الأيقونة والعنوان لكائن مضمن:

```py
import aspose.slides as slides

with slides.Presentation("embeddedOle.pptx") as pres:
    slide = pres.slides[0]
    oleObjectFrame = slide.shapes[0]
    
    with open("img.jpeg", "rb") as in_file:
        oleImage = pres.images.add_image(in_file)

    oleObjectFrame.substitute_picture_title = "عنواني"
    oleObjectFrame.substitute_picture_format.picture.image = oleImage
    oleObjectFrame.is_object_icon = False

    pres.save("embeddedOle-newImage.pptx", slides.export.SaveFormat.PPTX)
```

## **منع إطار كائن OLE من تغيير حجمه وموقعة**

بعد إضافة كائن OLE مرتبط إلى شريحة عرض تقديمي، عندما تفتح العرض التقديمي في PowerPoint، قد ترى رسالة تطلب منك تحديث الروابط. قد يؤدي النقر على زر "تحديث الروابط" إلى تغيير حجم وموقع إطار كائن OLE لأن PowerPoint يحدث البيانات من كائن OLE المرتبط ويقوم بتحديث معاينة الكائن. لمنع PowerPoint من المطالبة بتحديث بيانات الكائن، قم بتعيين خاصية `update_automatic` من [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) إلى `False`:

```py
oleObjectFrame.update_automatic = False
```

## استخراج الملفات المضمنة

يتيح لك Aspose.Slides لـ Python عبر .NET استخراج الملفات المضمنة في الشرائح ككائنات OLE بهذه الطريقة:

1. إنشاء نسخة من [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) التي تحتوي على كائن OLE الذي تنوي استخراجه.
2. التمرير خلال جميع الأشكال في العرض التقديمي والوصول إلى شكل [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).
3. الوصول إلى بيانات الملف المضمن من إطار كائن OLE وكتابته إلى القرص.

توضح لك هذه الشفرة البرمجية Python كيفية استخراج ملف مضمن في شريحة ككائن OLE:

```py
import aspose.slides as slides

with slides.Presentation("embeddedOle.pptx") as pres:
    slide = pres.slides[0]
    index = 0
    for shape in slide.shapes:

        if type(shape) is slides.OleObjectFrame:
            data = shape.embedded_data.embedded_file_data
            extension = shape.embedded_data.embedded_file_extension
            
            with open("oleFrame{idx}{ex}".format(idx = str(index), ex = extension), "wb") as fs:
                fs.write(data)
        index += 1
``` 