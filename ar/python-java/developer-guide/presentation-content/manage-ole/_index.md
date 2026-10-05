---
title: "إدارة OLE في العروض التقديمية باستخدام بايثون"
linktitle: "إدارة OLE"
type: docs
weight: 40
url: /ar/python-java/manage-ole/
keywords:
- "كائن OLE"
- "ربط وتضمين الكائنات"
- "إضافة OLE"
- "دمج OLE"
- "إضافة كائن"
- "دمج كائن"
- "إضافة ملف"
- "دمج ملف"
- "كائن مرتبط"
- "ملف مرتبط"
- "تغيير OLE"
- "أيقونة OLE"
- "عنوان OLE"
- "استخراج OLE"
- "استخراج كائن"
- "استخراج ملف"
- PowerPoint
- "عرض تقديمي"
- Python
- Java
- Aspose.Slides
description: "تحسين إدارة كائنات OLE في ملفات PowerPoint وOpenDocument باستخدام Aspose.Slides للبايثون عبر جافا. دمج، تحديث، وتصدير محتوى OLE بسلاسة."
---
## **المقدمة**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) هي تقنية من مايكروسوفت تسمح بنقل البيانات والكائنات التي تم إنشاؤها في تطبيق واحد إلى تطبيق آخر من خلال الربط أو الدمج.

{{% /alert %}}

اعتبر وجود مخطط تم إنشاؤه في MS Excel. ثم يتم وضع المخطط داخل شريحة PowerPoint. يُعامل هذا المخطط في Excel على أنه كائن OLE.

- قد يظهر كائن OLE كأيقونة. في هذه الحالة، عند النقر المزدوج على الأيقونة، يُفتح المخطط في التطبيق المرتبط به (Excel)، أو يُطلب منك اختيار تطبيق لفتح أو تعديل الكائن.
- قد يعرض كائن OLE محتواه الفعلي، مثل محتوى المخطط. في هذه الحالة، يتم تنشيط المخطط في PowerPoint، يُحمل واجهة المخطط، وتستطيع تعديل بيانات المخطط داخل PowerPoint.

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/python-java/) يسمح لك بإدراج كائنات OLE في الشرائح كإطارات كائن OLE ([OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/)).

## **إضافة إطارات كائن OLE إلى الشرائح**

باستخدام افتراض أنك قد أنشأت مخططًا في Microsoft Excel وتريد دمجه في شريحة كإطار كائن OLE باستخدام Aspose.Slides for Python via Java، يمكنك فعل ذلك بهذه الطريقة:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
1. الحصول على مرجع إلى شريحة بواسطة فهرسها.
1. قراءة ملف Excel كمصفوفة بايت.
1. إضافة الـ [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) إلى الشريحة مع مصفوفة البايت ومعلومات أخرى عن كائن OLE.
1. كتابة العرض المعدل كملف PPTX.

في المثال أدناه، أضفنا مخططًا من ملف Excel إلى شريحة كإطار كائن OLE باستخدام Aspose.Slides for Python via Java. **ملاحظة** أن مُنشئ الـ [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-java/aspose.slides/oleembeddeddatainfo/) يأخذ امتداد الكائن القابل للدمج كمعامل ثاني. يتيح هذا الامتداد لـ PowerPoint تفسير نوع الملف بشكل صحيح واختيار التطبيق المناسب لفتح هذا الكائن OLE.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(0)

    # إعداد البيانات لكائن OLE.
    file_data = Path("book.xlsx").read_bytes()
    file_data = jpype.JArray(jpype.JByte)(file_data)
    data_info = OleEmbeddedDataInfo(file_data, "xlsx")

    # إضافة إطار كائن OLE إلى الشريحة.
    frame_width = jpype.JFloat(slide_size.getWidth())
    frame_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addOleObjectFrame(0, 0, frame_width, frame_height, data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **إضافة إطارات OLE المرتبطة**

Aspose.Slides for Python via Java يسمح لك بإضافة [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) مرتبط بملف بدلاً من البيانات المدمجة.

هذا الكود بلغة Python يوضح لك كيفية إضافة [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) مع ملف Excel مرتبط إلى شريحة:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # أضف إطار كائن OLE مع ملف Excel مرتبط.
    slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **الوصول إلى إطارات كائن OLE**

إذا كان كائن OLE مدمجًا بالفعل في شريحة، يمكنك بسهولة العثور عليه أو الوصول إليه بهذه الطريقة:

1. تحميل عرض يحتوي على كائن OLE المدمج بإنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى الشريحة بواسطة فهرسها.
3. الوصول إلى شكل [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/). في مثالنا، استخدمنا ملف PPTX الذي تم إنشاؤه مسبقًا والذي يحتوي على شكل واحد فقط في الشريحة الأولى. ثم تحققنا من أن الكائن هو [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/). كان هذا هو إطار كائن OLE المطلوب الوصول إليه.
4. بمجرد الوصول إلى إطار كائن OLE، يمكنك تنفيذ أي عملية عليه.

في المثال أدناه، يتم الوصول إلى إطار كائن OLE (كائن مخطط Excel مدمج في شريحة) وبيانات ملفه.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # احصل على بيانات الملف المدمج.
        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

        # احصل على امتداد الملف المدمج.
        file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

        # ...
finally:
    presentation.dispose()
```

### **الوصول إلى خصائص إطار كائن OLE المرتبط**

Aspose.Slides يسمح لك بالوصول إلى خصائص إطار كائن OLE المرتبط.

هذا الكود بلغة Python يوضح لك كيفية التحقق مما إذا كان كائن OLE مرتبطًا ثم الحصول على مسار الملف المرتبط:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.ppt")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # التحقق مما إذا كان كائن OLE مرتبطًا.
        if ole_frame.isObjectLink():
            # طباعة المسار الكامل للملف المرتبط.
            print("OLE object frame is linked to: " + str(ole_frame.getLinkPathLong()))

            # طباعة المسار النسبي للملف المرتبط إذا كان موجودًا.
            # يمكن فقط لعروض PPT أن تحتوي على المسار النسبي.
            relative_path = ole_frame.getLinkPathRelative()
            if relative_path is not None and not relative_path.isEmpty():
                print("OLE object frame relative path: " + str(relative_path))
finally:
    presentation.dispose()
```

## **تغيير بيانات كائن OLE**

{{% alert color="info" title="Note" %}}

في هذا القسم، يستخدم المثال البرمجي أدناه [Aspose.Cells for Python via Java](https://products.aspose.com/cells/python-java/).

{{% /alert %}}

إذا كان كائن OLE مدمجًا بالفعل في شريحة، يمكنك بسهولة الوصول إلى ذلك الكائن وتعديل بياناته بهذه الطريقة:

1. تحميل عرض يحتوي على كائن OLE المدمج بإنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
2. الحصول على مرجع إلى الشريحة بواسطة فهرسها.
3. الوصول إلى شكل إطار كائن OLE. في مثالنا، استخدمنا ملف PPTX الذي تم إنشاؤه مسبقًا والذي يحتوي على شكل واحد في الشريحة الأولى. ثم تحققنا من أن الكائن هو [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/). كان هذا هو إطار كائن OLE المطلوب الوصول إليه.
4. بمجرد الوصول إلى إطار كائن OLE، يمكنك تنفيذ أي عملية عليه.
5. إنشاء كائن [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) والوصول إلى بيانات OLE.
6. الوصول إلى [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) المطلوب وتعديل البيانات.
7. حفظ الـ [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) المحدث في تدفق.
8. تغيير بيانات كائن OLE من التدفق.

في المثال أدناه، يتم الوصول إلى إطار كائن OLE (كائن مخطط Excel مدمج في شريحة) وتعديل بيانات ملفه لتحديث بيانات المخطط.

```python
import jpype
import asposeslides
import asposecells

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, OleObjectFrame, Presentation, SaveFormat
from asposecells.api import Workbook, OoxmlSaveOptions
from asposecells.api import SaveFormat as CellsSaveFormat
from java.io import ByteArrayInputStream, ByteArrayOutputStream

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
        ole_stream = ByteArrayInputStream(file_data)

        # قراءة بيانات كائن OLE ككائن Workbook.
        workbook = Workbook(ole_stream)

        new_ole_stream = ByteArrayOutputStream()

        # تعديل بيانات الـ workbook.
        cells = workbook.getWorksheets().get(0).getCells()
        cells.get(0, 4).putValue("E")
        cells.get(1, 4).putValue(jpype.JInt(12))
        cells.get(2, 4).putValue(jpype.JInt(14))
        cells.get(3, 4).putValue(jpype.JInt(15))

        file_options = OoxmlSaveOptions(CellsSaveFormat.XLSX)
        workbook.save(new_ole_stream, file_options)

        # تغيير بيانات إطار كائن OLE.
        new_file_data = new_ole_stream.toByteArray()
        new_data = OleEmbeddedDataInfo(new_file_data, ole_frame.getEmbeddedData().getEmbeddedFileExtension())
        ole_frame.setEmbeddedData(new_data)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **دمج أنواع ملفات أخرى في الشرائح**

إلى جانب مخططات Excel، Aspose.Slides for Python via Java يتيح لك دمج أنواع أخرى من الملفات في الشرائح. على سبيل المثال، يمكنك إدراج ملفات HTML وPDF وZIP ككائنات. عند النقر المزدوج للمستخدم على الكائن المدخل، يُفتح تلقائيًا في البرنامج المناسب، أو يُطلب من المستخدم اختيار برنامج مناسب لفتحه.

هذا الكود بلغة Python يوضح لك كيفية دمج HTML وZIP في شريحة:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    html_data = Path("sample.html").read_bytes()
    html_data = jpype.JArray(jpype.JByte)(html_data)
    html_data_info = OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, html_data_info)
    html_ole_frame.setObjectIcon(True)

    zip_data = Path("sample.zip").read_bytes()
    zip_data = jpype.JArray(jpype.JByte)(zip_data)
    zip_data_info = OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تعيين أنواع الملفات للكائنات المدمجة**

عند العمل على العروض التقديمية، قد تحتاج إلى استبدال كائنات OLE القديمة بأخرى جديدة أو استبدال كائن OLE غير المدعوم بآخر مدعوم. Aspose.Slides for Python via Java يتيح لك تعيين نوع الملف للكائن المدمج، مما يسمح لك بتحديث بيانات إطار OLE أو امتداده.

هذا الكود بلغة Python يوضح لك كيفية تعيين نوع الملف لكائن OLE مدمج إلى `zip`:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()
    file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

    print("Current embedded file extension is: " + str(file_extension))

    # تغيير نوع الملف إلى ZIP.
    data_info = OleEmbeddedDataInfo(file_data, "zip")
    ole_frame.setEmbeddedData(data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تعيين صور الأيقونات والعناوين للكائنات المدمجة**

بعد دمج كائن OLE، تُضاف معاينة تتكون من صورة أيقونة تلقائيًا. هذه المعاينة هي ما يراه المستخدمون قبل الوصول إلى كائن OLE أو فتحه. إذا رغبت في استخدام صورة ونص محددين كعناصر في المعاينة، يمكنك تعيين صورة الأيقونة والعنوان باستخدام Aspose.Slides for Python via Java.

هذا الكود بلغة Python يوضح لك كيفية تعيين صورة الأيقونة والعنوان لكائن مدمج:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # إضافة صورة إلى موارد العرض التقديمي.
    image_data = Path("image.png").read_bytes()
    image_data = jpype.JArray(jpype.JByte)(image_data)
    ole_image = presentation.getImages().addImage(image_data)

    # تعيين عنوان والصورة لمعاينة OLE.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **منع تغيير حجم وإعادة وضع إطار كائن OLE**

بعد إضافة كائن OLE مرتبط إلى شريحة عرض، قد ترى عند فتح العرض في PowerPoint رسالة تطلب تحديث الروابط. النقر على زر "Update Links" قد يغيّر حجم وإحداثيات إطار كائن OLE لأن PowerPoint يحدث البيانات من كائن OLE المرتبط ويُعيد تحميل معاينة الكائن. لمنع PowerPoint من طلب تحديث بيانات الكائن، استدعِ طريقة [setUpdateAutomatic](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) للفئة [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/) مع `False`:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    ole_frame.setUpdateAutomatic(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **استخراج الملفات المدمجة**

Aspose.Slides for Python via Java يتيح لك استخراج الملفات المدمجة في الشرائح ككائنات OLE بهذه الطريقة:

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) التي تحتوي على كائنات OLE التي ترغب في استخراجها.
2. التمرّ عبر جميع الأشكال في العرض والوصول إلى أشكال [OleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/).
3. الوصول إلى بيانات الملفات المدمجة من إطارات OLE وكتابتها إلى القرص.

هذا الكود بلغة Python يوضح لك كيفية استخراج الملفات المدمجة في شريحة ككائنات OLE:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)

        if isinstance(shape, OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
            file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

            file_path = Path(f"OLE_object_{index}.{str(file_extension).lstrip('.')}")
            file_path.write_bytes(bytes(file_data))
finally:
    presentation.dispose()
```

## **الأسئلة الشائعة**

**هل سيتم عرض محتوى OLE عند تصدير الشرائح إلى PDF/صور؟**

ما يظهر على الشريحة هو ما يُعرض—الأيقونة/صورة البديل (المعاينة). محتوى OLE "الحي" لا يُنفّذ أثناء العرض. إذا لزم الأمر، قم بتعيين صورة معاينة خاصة لضمان المظهر المتوقع في PDF المُصدّر.

للحفاظ أيضًا على الملف المدمج كمرفق PDF، استدعِ [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) مع `True`. هذا الخيار مُعطَّل افتراضيًا. للحصول على مثال وتعليمات للتحقق من المرفق، راجع [Preserve Embedded OLE Files as PDF Attachments](/slides/ar/python-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**كيف يمكنني قفل كائن OLE على شريحة حتى لا يتمكن المستخدمون من تحريكه/تحريره في PowerPoint؟**

قفل الشكل: Aspose.Slides يوفر [shape-level locks](/slides/ar/python-java/applying-protection-to-presentation/). هذا ليس تشفيرًا، لكنه يمنع التعديلات والحركية غير المقصودة.

**لماذا "يقفز" كائن Excel المرتبط أو يتغير حجمه عندما أفتح العرض؟**

قد يقوم PowerPoint بتحديث معاينة OLE المرتبط. للحصول على مظهر ثابت، اتبع ممارسات [Working Solution for Worksheet Resizing](/slides/ar/python-java/working-solution-for-worksheet-resizing/)—إما ملاءمة الإطار للمدى، أو تكبير المدى إلى إطار ثابت وتعيين صورة بديلة مناسبة.

**هل سيتم الحفاظ على المسارات النسبية لكائنات OLE المرتبطة في تنسيق PPTX؟**

في PPTX، لا تتوفر معلومات "المسار النسبي"—فقط المسار الكامل. تُوجد المسارات النسبية في تنسيق PPT القديم. للانتقالية، يفضَّل استخدام مسارات مطلقة موثوقة/عناوين URI قابلة للوصول أو الدمج.