---
title: إدارة حقول النص في عروض PowerPoint التقديمية بلغة Python
linktitle: حقول النص
type: docs
weight: 52
url: /ar/python-net/text-fields/
keywords:
- حقل نص
- نص تلقائي
- رقم الشريحة
- التاريخ والوقت
- رأس
- تذييل
- جزء نص
- PowerPoint
- PPT
- PPTX
- Python
- Aspose.Slides
description: "إنشاء، فحص، تعديل وإزالة حقول النص في عروض PowerPoint التقديمية باستخدام Aspose.Slides للغة Python عبر .NET. الحفاظ على التنسيق والتحقق من ملفات PPTX و PPT المحفوظة."
---
## **نظرة عامة**

يتكون فقرة نصية من أجزاء. يحتوي Portion عادي على نص حرفي؛ بينما يحتوي الجزء الحقل على Field يحدد نوعه قيمة تُحدّث تلقائيًا، مثل رقم الشريحة أو التاريخ. يمكن لجزئين عرض نفس الأحرف بينما يحتوي أحدهما فقط على حقل.

استخدم [Portion.field](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portion/field/) للتمييز بينهما: تكون القيمة `None` للنص العادي. [Portion.add_field](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portion/add_field/) يحوّل جزءًا موجودًا إلى حقل. احتفظ بالعلامة وقيمتها الديناميكية في أجزاء منفصلة حتى لا يؤدي تحويل القيمة إلى استبدال العلامة.

يغطي هذا الدليل الحقول داخل النص، تنسيقها، وحفظها في PPTX و PPT. بالنسبة لإطارات النص والفقرات، راجع [إدارة النص](/slides/ar/python-net/manage-text/).

## **إنشاء حقل رقم شريحة**

المثال الكامل التالي ينشئ مربع نص يحتوي على العلامة الحرفية `Slide ` متبوعًا برقم يُحدّث تلقائيًا. يضبط حجم الرقم ووزنه ولونه قبل إضافة الحقل، ثم يعيد فتح العرض المحفوظ ويفحص نوع الحقل والنص والتنسيق. لا يلزم ملف إدخال.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 240, 50)
    shape.add_text_frame("Slide ")
    paragraph = shape.text_frame.paragraphs[0]

    number_portion = slides.Portion()
    number_portion.portion_format.font_height = 24
    number_portion.portion_format.font_bold = slides.NullableBool.TRUE
    number_portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    number_portion.portion_format.fill_format.solid_fill_color.color = draw.Color.dark_blue
    paragraph.portions.add(number_portion)
    number_portion.add_field(slides.FieldType.slide_number)

    presentation.save("slide_number.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("slide_number.pptx") as reopened:
    saved_shape = reopened.slides[0].shapes[0]
    saved_number = saved_shape.text_frame.paragraphs[0].portions[1]
    has_number_field = saved_number.field is not None and saved_number.field.type.internal_string == slides.FieldType.slide_number.internal_string
    portion_format = saved_number.portion_format
    formatting_preserved = portion_format.font_height == 24 and portion_format.font_bold == slides.NullableBool.TRUE
    formatting_preserved &= portion_format.fill_format.solid_fill_color.color.to_argb() == draw.Color.dark_blue.to_argb()

    print(f"Text: {saved_shape.text_frame.text}")
    print(f"Slide number field: {has_number_field}")
    print(f"Formatting preserved: {formatting_preserved}")
```

يبدأ العرض الجديد برقم الشريحة 1، لذا يكون النص `Slide 1`، وتطبع كلتا الفحصين `True`. يظل الرقم حقلًا بعد إعادة الفتح؛ فهو ليس حرفيًا `1`. تشير المؤشرات في التحقق إلى الشكل والأجزاء التي أنشأها هذا المثال.

## **اختيار نوع الحقل**

[FieldType](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fieldtype/) يوفّر القيم المعرفة مسبقًا التالية. مرّر القيمة المناسبة إلى [add_field](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portion/add_field/).

| القيمة | الغرض |
|---|---|
| [slide_number](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fieldtype/slide_number/) | رقم الشريحة الحالي. |
| [date_time](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fieldtype/date_time/) | التاريخ/الوقت بتنسيق التطبيق الافتراضي. |
| [date_time1](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fieldtype/date_time1/)–[date_time9](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fieldtype/date_time9/) | تنسيقات تاريخ أو تاريخ/وقت محددة مسبقًا. |
| [date_time10](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fieldtype/date_time10/)–[date_time13](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fieldtype/date_time13/) | تنسيقات وقت محددة مسبقًا، مع خيارات للثواني وساعة 12. |
| [header](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fieldtype/header/) | حقل رأس؛ راجع قيود العنصر النائب والتنسيق أدناه. |
| [footer](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fieldtype/footer/) | حقل تذييل. |

على سبيل المثال، يُمثل [date_time3](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fieldtype/date_time3/) اليوم، اسم الشهر كاملًا، والسنة بالإنجليزية. هذه تنسيقات حقل معرفة مسبقًا، وليست سلاسل تنسيق تاريخ Python عشوائية. يمكن أن يؤثر [language_id](https://reference.aspose.com/slides/ar/python-net/aspose.slides/baseportionformat/language_id/) للجزء وتطبيق معالجة العرض على النتيجة المعروضة.

## **إنشاء حقل من سلسلة داخلية**

تقبل overload السلسلة لـ [add_field](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portion/add_field/) معرف حقل داخلي. استخدمها عندما تريد الحفاظ على معرف قدمه تطبيق آخر لا يملك قيمة معرفة مسبقًا. يمكنك أيضًا إنشاء [FieldType](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fieldtype/__init__/) من المعرف. [FieldType.internal_string](https://reference.aspose.com/slides/ar/python-net/aspose.slides/fieldtype/internal_string/) يُظهر ذلك المعرف للفحص.

هذا المثال يخزن حقل `custom-report-id` خاص بالتطبيق مع نص بديل `Report-042`. المعرف لا يسجّل حسابًا: Aspose.Slides لا يولّد معرّفات تقارير لأنواع غير معروفة. يجب على التطبيق الذي يفهم هذا المعرف توفير معناه وتحديث قيمته.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 50)
    shape.add_text_frame("Report-042")
    portion = shape.text_frame.paragraphs[0].portions[0]
    portion.add_field("custom-report-id")

    presentation.save("custom_field.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("custom_field.pptx") as reopened:
    saved_shape = reopened.slides[0].shapes[0]
    saved_portion = saved_shape.text_frame.paragraphs[0].portions[0]
    type_name = saved_portion.field.type.internal_string if saved_portion.field is not None else "ordinary text"
    print(f"Type: {type_name}")
    print(f"Text: {saved_portion.text}")
```

بعد جولة حفظ وإعادة فتح PPTX، يكون النوع `custom-report-id` والنص `Report-042`. تمرير سلسلة مثل `%Y-%m-%d` سيحدد نوع حقل؛ لن يُكوّن تنسيق تاريخ مخصص. لتاريخ ثابت بتنسيق عشوائي، استخدم نصًا عاديًا.

## **فحص وتعديل وإزالة حقول التاريخ/الوقت**

اقرأ وغير حقلًا موجودًا عبر [Field.type](https://reference.aspose.com/slides/ar/python-net/aspose.slides/field/type/). تحقق من وجود الحقل قبل الوصول إلى نوعه. لإيقاف التحديثات التلقائية، استدعِ [Portion.remove_field](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portion/remove_field/). يبقي هذا الجزء ونصه الحالي مع إزالة ارتباط الحقل. إذا احتجت إلى قيمة ثابتة معينة، عيّن ذلك النص بعد إزالة الحقل.

لإعداد API المتعلق بمعالجة حقول التاريخ/الوقت، راجع [Presentation.current_date_time](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/current_date_time/). يستخدم المثال أدناه تاريخ موافقة صريح عند تحويل حقل إلى نص عادي. تُبقي مجموعة أسماء الشهور الإنجليزية التاريخ ثابتًا بغض النظر عن إعدادات اللغة على النظام.

حمِّل [sample.pptx](sample.pptx) وضعه في دليل العمل. يحتوي على شكلين نصيين مسميين، `UpdatedAt` و `ApprovedDate`، كلٌ منهما يحمل حقل تاريخ/وقت، بالإضافة إلى تسميات نصية عادية. المثال التالي يتجول عبر أشكال النص العليا في الشرائح العادية. يغيّر حقول التاريخ/الوقت إلى تنسيق تاريخ طويل ويجعلها مائلة، مع الحفاظ على تنسيقاتها الأخرى. فقط الحقول في `ApprovedDate` تتحول إلى نص ثابت.

يتعرف العينة على المعرفات الداخلية المدمجة `datetime` و `datetime1` حتى `datetime13`. المجموعات والجداول والملاحظات والتنسيقات الرئيسية تتطلب تجوالًا في حاويات النص الخاصة بها ولا تشملها هذه العينة.

```python
from datetime import date

import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    approval_date = date(2030, 4, 5)
    english_months = ("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December")
    approval_text = f"{approval_date.day:02d} {english_months[approval_date.month - 1]} {approval_date.year}"
    date_time_types = {"datetime"} | {f"datetime{index}" for index in range(1, 14)}

    for slide in presentation.slides:
        for shape in slide.shapes:
            if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
                continue

            for paragraph in shape.text_frame.paragraphs:
                for portion in paragraph.portions:
                    field = portion.field
                    if field is None:
                        continue

                    if field.type.internal_string not in date_time_types:
                        continue

                    field.type = slides.FieldType.date_time3
                    portion.portion_format.language_id = "en-US"
                    portion.portion_format.font_italic = slides.NullableBool.TRUE

                    if shape.name == "ApprovedDate":
                        portion.remove_field()
                        portion.text = approval_text

    presentation.save("updated_dates.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("updated_dates.pptx") as reopened:
    for shape in reopened.slides[0].shapes:
        if not isinstance(shape, slides.AutoShape) or shape.text_frame is None:
            continue
        if shape.name not in {"UpdatedAt", "ApprovedDate"}:
            continue

        portion = shape.text_frame.paragraphs[0].portions[0]
        type_name = portion.field.type.internal_string if portion.field is not None else "ordinary text"
        print(f"{shape.name}: {type_name}; {portion.text}")
        print(f"Italic: {portion.portion_format.font_italic == slides.NullableBool.TRUE}")
```

بعد إعادة الفتح، يكون لـ `UpdatedAt` النوع `datetime3` ويظل ديناميكيًا. لا يحتوي `ApprovedDate` على حقل ويظهر النص `05 April 2030`. كلا الجزئين المتعلقين بالتاريخ مائلان، وتظل حجم الخط الأصلي وإعداد السُمك واللون كما هو. لا تُغيَّر تسميات النص العادية. يقرأ التحقق الجزء الأول من الشكلين المعروفين في العينة المرفقة.

## **الحفاظ على تنسيق النص**

اعمل مع الجزء الموجود عند إضافة حقل، تغيير نوعه، أو إزالته. تُبقي هذه العمليات تنسيق ذلك الجزء. استخدم [Portion.portion_format](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portion/portion_format/) لتغيير الخصائص المطلوبة فقط، كما تفعل الأمثلة للون أو المائل.

تجنّب إعادة بناء إطار نص كامل لتحديث حقل واحد: قد يفقد ذلك حدود الأجزاء الأصلية وتنسيقها الفردي. كذلك افصل بين التنسيق المعين صراحةً والتنسيق الموروث من الفقرة أو التنسيق أو السمة. راجع [تنسيق النص](/slides/ar/python-net/text-formatting/) لمزيد من خيارات التنسيق الشاملة.

## **الحقول وعناصر النص النائبة للرأس/التذييل**

الحقل هو جزء من جزء نصي. العنصر النائب هو شكل له دور في العرض، مثل تذييل أو رقم شريحة. إضافة حقل إلى مربع نص عادي لا يحوّله إلى عنصر نائب.

تتحكم مدراء الرأس/التذييل في نص العنصر النائب ورؤيته على الشرائح، التنسيقات، والماستر، بما في ذلك انتشارها إلى الشرائح التابعة. لذا يمكن أن يكون حقل رقم في مربع نص مخصص مفيدًا حتى وإن لم تستخدم العنصر النائب لرقم الشريحة. بالمقابل، تغيير رؤية العنصر النائب لا يزيل الحقل من مربع نص غير مرتبط.

أنواع الرأس والتذييل المعرفة مسبقًا لا تُنشئ العناصر النائبة المقابلة ولا تُوفر محتواها. على وجه الخصوص، لا تحتوي الشريحة العادية في PowerPoint على عنصر نائب للرأس؛ الرؤوس تخص صفحات الملاحظات والنشرات. لا تفترض أن حقل رأس أو تذييل في شكل عشوائي سيحصل تلقائيًا على النص المكوّن عبر مدير العنصر النائب. لهذا السِياق، راجع [رؤوس وتذييلات العرض](/slides/ar/python-net/presentation-header-and-footer/).

## **قيود PPTX و PPT**

تحقق من كل من نوع الحقل والنص الناتج بعد الحفظ وإعادة الفتح. عدم فقدان المعرف لا يعني أن التطبيق قادر على حساب أو عرض قيمته.

| الصيغة | سلوك الحقل والقيود |
|---|---|
| PPTX | يخزن معرفات الحقول الداخلية إلى جانب نص الحقل. في فحوصات الجولة، نجت الأنواع المعرفة مسبقًا والمعرف المخصص المستخدم أعلاه من الحفظ وإعادة الفتح. احتفظ النوع المخصص بنصه البديل؛ لم يحصل على منطق حساب تلقائي. قد يعالج تطبيق آخر المعرفات غير المدعومة بطرق مختلفة. |
| PPT | يستخدم تمثيلات حقول قديمة ويتسم بتوافقية أقل. في فحوصات الجولة، نجت حقول رقم الشريحة والوقت/التاريخ المعرفة مسبقًا من الحفظ وإعادة الفتح. حقل مخصص في مربع نص شريحة عادي أعيد فتحه بمعرفه لكن بنص `*`؛ حقل رأس في نفس السياق أيضًا أظهر `*`. لا تعتمد على بقاء النص المرئي للحقول المخصصة أو غير المدعومة. |

للإنتاج الثابت والقابل للنقل، حوّل الحقول غير المدعومة إلى نص عادي وعين القيمة التي تريدها صراحةً قبل الحفظ. يضمن ذلك الحفاظ على النص المختار لكنه يوقف التحديثات التلقائية عمدًا. اختبر التطبيق الهدف أيضًا عندما تكون إعادة حساب الحقول جزءًا من سير عملك.

## **الأسئلة الشائعة**

**كيف أتحقق مما إذا كان الرقم أو التاريخ المعروض حقلًا؟**  
تحقق من [Portion.field](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portion/field/). قيمة غير `None` تشير إلى حقل؛ لا يمكن للنص المعروض وحده أن يحدده.

**هل يزيل حذف الحقل نصه أو تنسيقه؟**  
لا. [remove_field](https://reference.aspose.com/slides/ar/python-net/aspose.slides/portion/remove_field/) يحول الجزء الحالي إلى نص عادي. عيّن قيمة صريحة بعد ذلك إذا كنت بحاجة إلى تاريخ ثابت أو نص بديل.

**هل يمكن لسلسلة داخلية أن تُعرّف تنسيق تاريخ جديد أو صيغة؟**  
لا. هي مجرد معرف لنوع حقل. المعرف غير المعروف لا يوفر مُقَيِّمًا ولا نمط تنسيق تاريخ Python. استخدم نوعًا معرفًا مسبقًا أو صيّغ القيمة كالنص العادي.

**لماذا أُعيد فحص العرض بعد حفظه؟**  
معرفات الحقول والنص المحسوب والتنسيق أشياء منفصلة تحتاج للتحقق. قد تُغيّر عملية تحويل الصيغة النتيجة المرئية حتى لو ظل معرف الحقل موجودًا.