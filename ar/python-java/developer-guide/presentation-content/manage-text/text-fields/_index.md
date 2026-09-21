---
title: إدارة حقول النص في عروض PowerPoint التقديمية باستخدام Python عبر Java
linktitle: حقول النص
type: docs
weight: 52
url: /ar/python-java/text-fields/
keywords:
- حقل نصي
- نص تلقائي
- رقم الشريحة
- التاريخ والوقت
- رأس الصفحة
- تذييل الصفحة
- جزء نص
- PowerPoint
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "إنشاء، فحص، تعديل، وإزالة حقول النص في عروض PowerPoint التقديمية باستخدام Aspose.Slides لـ Python عبر Java. الحفاظ على التنسيق والتحقق من ملفات PPTX و PPT المحفوظة."
---
## **نظرة عامة**

يتكون فقرة النص من أجزاء. يحتوي الجزء العادي [Portion](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portion/) على نص حرفي؛ يحتوي جزء الحقل أيضًا على [Field](https://reference.aspose.com/slides/ar/python-java/aspose.slides/field/) الذي يحدد النوع قيمة محدثة تلقائيًا، مثل رقم الشريحة أو التاريخ. يمكن لجزءين عرض نفس الأحرف بينما يحتوي أحدهما فقط على حقل.

استخدم [Portion.getField](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portion/#getField) للتمييز بينهما: يكون `None` للنص العادي. يقوم [Portion.addField](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portion/#addField) بتحويل الجزء الموجود إلى حقل. احتفظ بالتسمية والقيمة الديناميكية في أجزاء منفصلة بحيث لا يؤدي تحويل القيمة إلى استبدال التسمية.

يغطي هذا الدليل الحقول داخل النص، تنسيقها، وحفظها في PPTX و PPT. لإطارات النص والفقرات، راجع [إدارة النص](/slides/ar/python-java/manage-text/).

## **إنشاء حقل رقم الشريحة**

المثال الكامل التالي ينشئ مربع نص يحتوي على تسمية حرفية `Slide ` تليها رقم يتم تحديثه تلقائيًا. يحدد حجم الرقم ووزنه ولونه قبل إضافة الحقل، ثم يعيد فتح العرض التقديمي المحفوظ ويفحص نوع الحقل والنص والتنسيق. لا يلزم ملف إدخال.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Portion, ShapeType, NullableBool, FillType, FieldType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50)
    shape.addTextFrame("Slide ")
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)

    number_portion = Portion()
    number_color = Color(0, 0, 139)
    number_portion.getPortionFormat().setFontHeight(24)
    number_portion.getPortionFormat().setFontBold(NullableBool.True_)
    number_portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    number_portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(number_color)
    paragraph.getPortions().add(number_portion)
    number_portion.addField(FieldType.getSlideNumber())

    presentation.save("slide_number.pptx", SaveFormat.Pptx)

    reopened = Presentation("slide_number.pptx")
    try:
        saved_shape = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_number = saved_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1)
        saved_field = saved_number.getField()
        has_number_field = saved_field is not None and saved_field.getType().getInternalString() == FieldType.getSlideNumber().getInternalString()
        portion_format = saved_number.getPortionFormat()
        formatting_preserved = portion_format.getFontHeight() == 24 and portion_format.getFontBold() == NullableBool.True_
        formatting_preserved = formatting_preserved and portion_format.getFillFormat().getSolidFillColor().getColor().getRGB() == number_color.getRGB()

        print(f"Text: {saved_shape.getTextFrame().getText()}")
        print(f"Slide number field: {has_number_field}")
        print(f"Formatting preserved: {formatting_preserved}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

يبدأ العرض التقديمي الجديد برقم الشريحة 1، لذا يكون النص `Slide 1`، وتطبع كلا الفحصين `True`. يظل الرقم حقلًا بعد إعادة الفتح؛ فهو ليس حرفيًا `1`. المؤشرات في التحقق تشير إلى الشكل والأجزاء التي أنشأها هذا المثال.

## **اختيار نوع الحقل**

[FieldType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fieldtype/) يوفر الطرق التالية للحصول على القيم المعرفة مسبقًا. مرّر القيمة المناسبة إلى [addField](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portion/#addField).

| الطريقة | الهدف |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fieldtype/#getSlideNumber) | رقم الشريحة الحالي. |
| [getDateTime](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fieldtype/#getDateTime) | التاريخ/الوقت بصيغة التطبيق الافتراضية. |
| [getDateTime1](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fieldtype/#getDateTime9) | صيغ تاريخ أو تاريخ/وقت معرفة مسبقًا. |
| [getDateTime10](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fieldtype/#getDateTime13) | صيغ وقت معرفة مسبقًا، مع خيارات للثواني وساعة 12. |
| [getHeader](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fieldtype/#getHeader) | حقل رأس؛ انظر قيود العناصر النائبة والصيغة أدناه. |
| [getFooter](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fieldtype/#getFooter) | حقل تذييل. |

على سبيل المثال، يمثل [getDateTime3](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fieldtype/#getDateTime3) يوماً واسم الشهر الكامل والسنة بالإنجليزية. هذه صيغ حقول معرفة مسبقًا، ليست سلاسل تنسيق تاريخ بايثون عشوائية. اللغة المحددة بـ [setLanguageId](https://reference.aspose.com/slides/ar/python-java/aspose.slides/baseportionformat/#setLanguageId) والتطبيق المعالج للعرض التقديمي قد يؤثران على النتيجة المعروضة.

## **إنشاء حقل من سلسلة داخلية**

تحمل النسخة النصية من [addField](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portion/#addField) معرف حقل داخلي. استخدمها عندما تريد الحفاظ على معرف قدمه تطبيق آخر لا يمتلك قيمة معرفة مسبقًا. يمكنك أيضًا إنشاء [FieldType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fieldtype/#FieldType) من المعرف. يوضح [FieldType.getInternalString](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fieldtype/#getInternalString) هذا المعرف للتفحص.

هذا المثال يخزن حقلًا خاصًا بالتطبيق `custom‑report‑id` مع النص الاحتياطي `Report‑042`. المعرف لا يسجل حسابًا: Aspose.Slides لا يولد معرفات تقارير لأنواع غير معروفة. يجب على التطبيق الذي يفهم هذا المعرف توفير معناه وتحديث قيمته.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SaveFormat

presentation = Presentation()
try:
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 50)
    shape.addTextFrame("Report-042")
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    portion.addField("custom-report-id")

    presentation.save("custom_field.pptx", SaveFormat.Pptx)

    reopened = Presentation("custom_field.pptx")
    try:
        saved_shape = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
        saved_portion = saved_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        saved_field = saved_portion.getField()
        type_name = "ordinary text" if saved_field is None else saved_field.getType().getInternalString()
        print(f"Type: {type_name}")
        print(f"Text: {saved_portion.getText()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

بعد جولة حفظ وإعادة فتح PPTX، يكون النوع `custom‑report‑id` والنص `Report‑042`. تمرير سلسلة مثل `yyyy‑MM‑dd` سيُسمّي نوع حقل؛ لن يكوّن تنسيق تاريخ مخصص. لتاريخ ثابت بصيغة عشوائية استخدم نصًا عاديًا.

## **فحص وتعديل وإزالة حقول التاريخ/الوقت**

غيّر حقلًا موجودًا عبر [Field.setType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/field/#setType). تأكد من وجود الحقل قبل الوصول إلى نوعه. لإيقاف التحديثات التلقائية، استدعِ [Portion.removeField](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portion/#removeField). هذا يحافظ على الجزء والنص الحالي مع إزالة ارتباط الحقل. إذا احتجت قيمة ثابتة محددة، عيّن ذلك النص بعد إزالة الحقل.

لإعداد API المتعلق بمعالجة حقول التاريخ/الوقت، راجع [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#setCurrentDateTime). يستخدم المثال أدناه تاريخ موافقة صريح عند تحويل حقل إلى نص عادي.

حمّل [sample.pptx](sample.pptx) وضعه في دليل العمل. يحتوي على شكلين نصيين مسمين، `UpdatedAt` و `ApprovedDate`، كل منهما حقل تاريخ/وقت، بالإضافة إلى تسميات نصية عادية. المثال التالي يمشي عبر أشكال النص العليا في الشرائح العادية. يغيّر حقول التاريخ/الوقت إلى صيغة تاريخ طويل ويجعلها مائلة، مع الحفاظ على تنسيقاتها الأخرى. فقط الحقول في `ApprovedDate` تتحول إلى نص ثابت.

الأمثلة تتعرف على المعرفات الداخلية المدمجة `datetime` و `datetime1` حتى `datetime13`. المجموعات والجداول والملاحظات والتخطيطات والرؤوس تتطلب استعراض حاويات النص الخاصة بها وتخضع لنطاق هذا المثال.

```python
import re
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, FieldType, NullableBool, SaveFormat

presentation = Presentation("sample.pptx")
try:
    approval_date = date(2030, 4, 5)
    # استخدم أسماء الشهور الإنجليزية بشكل مستقل عن إعداد لغة النظام.
    month_names = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December")
    fixed_date = f"{approval_date.day:02d} {month_names[approval_date.month - 1]} {approval_date.year}"

    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue
            if shape.getTextFrame() is None:
                continue

            for paragraph in shape.getTextFrame().getParagraphs():
                for portion in paragraph.getPortions():
                    field = portion.getField()
                    if field is None:
                        continue

                    type_name = field.getType().getInternalString()
                    is_date_time = type_name is not None and re.fullmatch(r"datetime([1-9]|1[0-3])?", str(type_name)) is not None
                    if not is_date_time:
                        continue

                    field.setType(FieldType.getDateTime3())
                    portion.getPortionFormat().setLanguageId("en-US")
                    portion.getPortionFormat().setFontItalic(NullableBool.True_)

                    if shape.getName() == "ApprovedDate":
                        portion.removeField()
                        portion.setText(fixed_date)

    presentation.save("updated_dates.pptx", SaveFormat.Pptx)

    reopened = Presentation("updated_dates.pptx")
    try:
        for shape in reopened.getSlides().get_Item(0).getShapes():
            if not isinstance(shape, AutoShape):
                continue
            if shape.getTextFrame() is None:
                continue
            if shape.getName() not in ("UpdatedAt", "ApprovedDate"):
                continue

            portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
            field = portion.getField()
            type_name = "ordinary text" if field is None else field.getType().getInternalString()
            print(f"{shape.getName()}: {type_name}; {portion.getText()}")
            print(f"Italic: {portion.getPortionFormat().getFontItalic()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

بعد إعادة الفتح، يكون لـ `UpdatedAt` النوع `datetime3` ويبقى ديناميكيًا. لا يحتوي `ApprovedDate` على حقل ويتضمن `05 April 2030`. كلا جزئي التاريخ مائلان، وحجم الخط الأصلي، والإعداد الغامق، واللون يبقى كما هو. التسميات النصية العادية لم تتغير. يقرأ التحقق الجزء الأول من الشكلين المعروفين في العينة المقدمة.

## **الحفاظ على تنسيق النص**

اعمل مع الجزء الحالي عند إضافة حقل أو تغيير نوعه أو إزالته. هذه العمليات تحتفظ بتنسيق ذلك الجزء. استخدم [Portion.getPortionFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portion/#getPortionFormat) لتغيير الخصائص المطلوبة فقط، كما تفعل الأمثلة للون أو المائل.

تجنب إعادة بناء إطار نص كامل فقط لتحديث حقل واحد: ذلك قد يفقد حدود الأجزاء الأصلية وتنسيقها الفردي. كذلك ضع في اعتبارك التمييز بين التنسيق المحدد صراحةً والتنسيق الموروث من الفقرة أو التخطيط أو السمة. انظر [تنسيق النص](/slides/ar/python-java/text-formatting/) لمزيد من الخيارات.

## **الحقول وعناصر النائب رأس/تذييل الصفحة**

الحقل هو جزء من جزء النص. العنصر النائب هو شكل له دور في العرض التقديمي، مثل تذييل أو رقم شريحة. إضافة حقل إلى صندوق نص عادي لا يحول ذلك الشكل إلى عنصر نائب.

مديرو الرأس/التذييل يتحكمون في نص العنصر النائب ورؤيته على الشرائح، والتخطيطات، والرؤوس، بما في ذلك انتشارها إلى الشرائح التابعة. يمكن أن يكون حقل الرقم في صندوق نص مخصص مفيدًا حتى عندما لا تستخدم عنصر نائب رقم الشريحة. وعلى العكس، تغيير رؤية العنصر النائب لا يزيل حقلًا من صندوق نص غير مرتبط.

أنواع الرأس والتذييل المعرفة مسبقًا لا تُنشئ العناصر النائبة المقابلة ولا تزود محتواها. على وجه الخصوص، لا يحتوي الشريحة العادية في PowerPoint على عنصر نائب رأس؛ الرؤوس تخص صفحات الملاحظات والنشرات. لا تفترض أن حقل رأس أو تذييل في شكل عشوائي سيحصل تلقائيًا على النص المكوّن عبر مدير العنصر النائب. لهذا السيناريو، راجع [رؤوس وتذييلات العرض التقديمي](/slides/ar/python-java/presentation-header-and-footer/).

## **قيود PPTX و PPT**

تحقق من نوع الحقل والنص الناتج بعد الحفظ وإعادة الفتح. الحفاظ على معرف لا يثبت أن التطبيق يستطيع حساب أو عرض قيمته.

| الصيغة | سلوك الحقل والقيود |
|---|---|
| PPTX | يخزن معرفات الحقول الداخلية جنبًا إلى جنب مع نص الحقل. في تحقق جولة الحفظ، بقت الأنواع المعرفة مسبقًا والمعرف المخصص المستخدم أعلاه بعد الحفظ وإعادة الفتح. احتفظ المعرف المخصص بنصه الاحتياطي؛ لم يكتسب منطق حساب تلقائي. قد يتعامل تطبيق آخر مع المعرفات غير المدعومة بشكل مختلف. |
| PPT | يستخدم تمثيلات حقول قديمة ويحتوي على توافقية محدودة. في تحقق جولة الحفظ، نجت حقول رقم الشريحة والحقول التاريخ/الوقت المعرفة مسبقًا. حقل مخصص في صندوق نص شريحة عادي أعيد فتحه بمعرفه لكن نصه كان `*`؛ حقل رأس في نفس السياق أيضًا نتج عنه `*`. لا تعتمد على أن الحقول المخصصة أو السياقات غير المدعومة ستحافظ على نصها الظاهر. |

لإنتاج ثابت ومحمول، حوّل الحقول غير المدعومة إلى نص عادي وعين القيمة المطلوبة صراحةً قبل الحفظ. هذا يحافظ على النص المختار لكنه يوقف التحديثات التلقائية مقصودًا. اختبر التطبيق الهدف أيضًا عندما يكون إعادة حساب الحقول جزءًا من سير عملك.

## **الأسئلة الشائعة**

**كيف يمكنني معرفة ما إذا كان الرقم أو التاريخ المعروض حقلًا؟**  
افحص [Portion.getField](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portion/#getField). قيمة غير `None` تحدد وجود حقل؛ لا يمكن للنص المعروض وحده إخبارك بذلك.

**هل إزالة الحقل يزيل نصه أو تنسيقه؟**  
لا. [removeField](https://reference.aspose.com/slides/ar/python-java/aspose.slides/portion/#removeField) يحول الجزء الحالي إلى نص عادي. عيّن قيمة صريحة بعد ذلك إذا احتجت تاريخًا ثابتًا أو نصًا احتياطيًا.

**هل يمكن لسلسلة داخلية تعريف صيغة تاريخ جديدة أو معادلة؟**  
لا. هي مجرد معرف لنوع الحقل. المعرف غير المعروف لا يوفر مقيمًا ولا نمط تنسيق تاريخ بايثون. استخدم نوعًا معروفًا أو صغ القيمة كنص عادي.

**لماذا أتحقق من العرض التقديمي مرة أخرى بعد حفظه؟**  
معرفات الحقول، النص المحسوب، والتنسيق أشياء منفصلة تحتاج للتحقق. قد يغيّر تحويل الصيغة النتيجة الظاهرة حتى عندما يبقى معرف الحقل موجودًا.