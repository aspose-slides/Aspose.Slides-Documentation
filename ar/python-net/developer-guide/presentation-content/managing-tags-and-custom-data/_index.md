---
title: إدارة العلامات والبيانات المخصصة في العروض باستخدام بايثون
linktitle: العلامات والبيانات المخصصة
type: docs
weight: 300
url: /ar/python-net/managing-tags-and-custom-data/
keywords:
- خصائص المستند
- علامة
- بيانات مخصصة
- XML مخصص
- جزء XML مخصص
- بيانات تعريف XML
- معرف العنصر
- إضافة علامة
- قيم زوجية
- PowerPoint
- عرض
- Python
- Aspose.Slides
description: "تعلم كيفية إدارة العلامات وبيانات XML المخصصة في عروض PowerPoint باستخدام Aspose.Slides للغة بايثون عبر .NET، بما في ذلك إضافة وقراءة وتحديث وتدقيق وإزالة أجزاء XML المخصصة."
---
## **نظرة عامة**

توضح هذه المقالة كيفية عمل Aspose.Slides مع العلامات والبيانات المخصصة في عروض PowerPoint. يمكن تخزين البيانات الخاصة بالعرض كعلامات أو كأجزاء XML مخصصة. العلامات هي أزواج بسيطة من السلاسل المفتاحية والقيمة، بينما يمكن لأجزاء XML المخصصة تخزين بيانات تعريفية منظمة وحمولات XML خاصة بالتطبيق.

Aspose.Slides توفر واجهات برمجة تطبيقات لإضافة وقراءة وتحديث وتدقيق وإزالة أجزاء XML المخصصة على مستوى العرض، الشريحة، والشكل. تعتبر أجزاء XML المخصصة مفيدة للتكاملات التي تخزن معلومات مثل معرفات إدارة المستندات، حالة سير العمل، بيانات التعريف للامتثال، بيانات ربط القالب، أو أي بيانات تطبيقية منظمة أخرى داخل العرض.

## **تخزين البيانات في ملفات العرض**

ملفات PPTX—الملفات ذات امتداد `.pptx`—تُخزن بتنسيق PresentationML، وهو جزء من مواصفة Office Open XML. تُعرّف Office Open XML بنية الحزمة والعلاقات المستخدمة لتخزين محتوى العرض والبيانات المرتبطة به.

يتكوّن العرض من عدة أجزاء مرتبطة بعلاقات. على سبيل المثال، يحتوي جزء الشريحة على محتوى شريحة واحدة ويمكن أن يكون له علاقات صريحة مع أجزاء أخرى معرفة وفقًا لـ ISO/IEC 29500.

يمكن تخزين البيانات المخصصة كعلامات ([TagCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/tagcollection/)) أو كأجزاء XML مخصصة ([CustomXmlPartCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/customxmlpartcollection/)). كلاهما متاح عبر فئة [`CustomData`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/customdata/).

{{% alert color="primary" %}}
العلامات تخزن أزواج سلسلة مفتاح‑قيمة بسيطة. أجزاء XML المخصصة تخزن بيانات XML منظمة ويمكن ربطها بعرض أو شريحة أو شكل.
{{% /alert %}}

## **العمل مع أجزاء XML المخصصة**

خاصية [`CustomData.custom_xml_parts`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/customdata/custom_xml_parts/) تُعيد مجموعة أجزاء XML المخصصة المرتبطة بكائن عرض معين. على سبيل المثال:

- `presentation.custom_data.custom_xml_parts` يحتوي على أجزاء XML المخصصة المرتبطة بالعرض نفسه.
- `slide.custom_data.custom_xml_parts` يحتوي على أجزاء XML المخصصة المرتبطة بشريحة معينة.
- `shape.custom_data.custom_xml_parts` يحتوي على أجزاء XML المخصصة المرتبطة بشكل معين.

استخدم [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/all_custom_xml_parts/) عندما تحتاج إلى فحص جميع أجزاء XML المخصصة في العرض بغض النظر عن موقع ارتباطها.

### **إضافة جزء XML مخصص إلى عرض**

استخدم [`CustomXmlPartCollection.add`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/customxmlpartcollection/add/) لإضافة بيانات XML إلى مجموعة أجزاء XML المخصصة. يجب أن يكون XML صالحًا وغير فارغ.

المثال التالي يضيف بيانات تعريفية منظمة إلى مجموعة البيانات المخصصة على مستوى العرض:

```py
import uuid
import aspose.slides as slides

custom_xml_content = (
    '<?xml version="1.0" encoding="UTF-8"?>'
    '<metadata xmlns="urn:example:metadata">'
    '<documentId>DOC-1001</documentId>'
    '<workflowState>Draft</workflowState>'
    '</metadata>'
)

with slides.Presentation() as presentation:
    custom_xml_part = presentation.custom_data.custom_xml_parts.add(custom_xml_content)

    # add يعيّن معرفًا تلقائيًا. عيّن GUID محددًا فقط عند الحاجة.
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("presentation_with_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

يمكن أيضًا للطريقة `add` أن تقبل XML كمصفوفة بايت أو تدفق، وهو مفيد عندما يكون محتوى XML متاحًا بالفعل بصيغة ثنائية.

### **إضافة جزء XML مخصص إلى شريحة أو شكل**

يمكن ربط بيانات XML مخصصة بشريحة أو شكل محدد بدلاً من كامل العرض. يكون ذلك مفيدًا عندما تصف البيانات التعريفية كائنًا واحدًا فقط، مثل مفتاح قالب، معرف سجل خارجي، أو معلومات ربط.

المثال التالي يضيف جزء XML مخصص إلى شريحة وآخر إلى شكل:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.custom_data.custom_xml_parts.add(
        '<slideMetadata xmlns="urn:example:slides">'
        '<templateKey>TitleSlide</templateKey>'
        '</slideMetadata>'
    )

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 250, 80)

    shape.text_frame.text = "Customer data"
    shape.custom_data.custom_xml_parts.add(
        '<shapeMetadata xmlns="urn:example:shapes">'
        '<recordId>CRM-4281</recordId>'
        '</shapeMetadata>'
    )

    presentation.save("object_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

المستوى الذي يُضاف فيه الجزء يحدِّد أي مجموعة `custom_data.custom_xml_parts` يحتوي على علاقة ذلك الجزء. البيانات على مستوى العرض مناسبة للبيانات التعريفية على مستوى المستند بالكامل، والبيانات على مستوى الشريحة للمعلومات التي تخص شريحة معينة، والبيانات على مستوى الشكل للبيانات المرتبطة بشكل فردي.

### **قائمة وتدقيق جميع أجزاء XML المخصصة**

استخدم [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/all_custom_xml_parts/) لاسترجاع جميع أجزاء XML المخصصة من العرض. كل كائن [`CustomXmlPart`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/customxmlpart/) يعرض معرّفه ومحتوى XML ومخططات الفضاءات الاسمية المرتبطة به.

المثال التالي يدرج جميع أجزاء XML المخصصة ومخططات الفضاءات الاسمية الخاصة بها:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        print("ItemId: " + str(custom_xml_part.item_id))
        print("XML:")
        print(custom_xml_part.xml_as_string)

        for namespace_schema in custom_xml_part.namespace_schemas:
            print("Namespace schema: " + namespace_schema)

        print()
```

تُعيد الخاصية [`CustomXmlPart.namespace_schemas`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/customxmlpart/namespace_schemas/) مخططات XML المرتبطة بالجزء المخصص. يمكن أن تكون هذه المعلومات مفيدة عند تدقيق عروض تحتوي على XML تم إنشاؤه بواسطة أنظمة خارجية.

### **قراءة وتحديث محتوى XML ومعرّف العنصر (ItemId)**

استخدم [`CustomXmlPart.xml_as_string`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/customxmlpart/xml_as_string/) للعمل مع XML كسلسلة UTF‑8، أو [`CustomXmlPart.xml_data`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/customxmlpart/xml_data/) للعمل مع بايتات XML الخام. يمكن قراءة وتحديث كلا الخاصيتين.

خاصية [`CustomXmlPart.item_id`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/customxmlpart/item_id/) تحتوي على GUID الذي يُعرّف جزء XML المخصص في مستند Office Open XML. يمكن أيضًا تغييره عندما تتطلب التكاملية معرفًا جديدًا.

المثال التالي يحدث محتوى XML والمعرّف:

```py
import uuid
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_part = presentation.all_custom_xml_parts[0]

    # قراءة XML الحالي كنص.
    current_xml_content = custom_xml_part.xml_as_string
    print(current_xml_content)

    # تحديث XML كسلسلة UTF-8.
    custom_xml_part.xml_as_string = (
        '<metadata xmlns="urn:example:metadata">'
        '<documentId>DOC-1001</documentId>'
        '<workflowState>Approved</workflowState>'
        '</metadata>'
    )

    # xml_data توفر نفس محتوى XML كبايتات خام.
    custom_xml_data = custom_xml_part.xml_data
    print(custom_xml_data.decode("utf-8"))

    # استبدال المعرف عندما يتطلب ذلك التكامل.
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("updated_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

عند تعيين `xml_as_string` أو `xml_data`، قدم XML صالحًا وغير فارغ. استخدم تمثيلًا أو الآخر بناءً على ما إذا كان التطبيق يعمل أساسًا مع سلاسل نصية أو بيانات بايت.

### **إزالة جزء XML مخصص**

توفر Aspose.Slides عدة طرق لإزالة بيانات XML المخصصة:

- [`CustomXmlPart.remove`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/customxmlpart/remove/) يزيل جزء XML المخصص من العرض.
- [`CustomXmlPartCollection.remove`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/customxmlpartcollection/remove/) يزيل جزءًا معينًا من مجموعة أجزاء XML المخصصة.
- [`CustomXmlPartCollection.remove_at`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/customxmlpartcollection/remove_at/) يزيل الجزء عند فهرس مجموعة محدد.
- [`CustomXmlPartCollection.clear`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/customxmlpartcollection/clear/) يزيل جميع الأجزاء من مجموعة معينة.

المثال التالي يزيل جزء XML مخصص على مستوى العرض باستخدام المرجع:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_parts = presentation.custom_data.custom_xml_parts

    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

إذا كان لديك كائن `CustomXmlPart` وتريد إزالة ذلك الجزء من العرض بدلاً من التعامل مع مجموعة معينة، استدعِ `custom_xml_part.remove()`.

يمكنك أيضًا إزالة عنصر حسب الفهرس:

```py
presentation.custom_data.custom_xml_parts.remove_at(0)
```

### **مسح جميع أجزاء XML المخصصة من مجموعة**

استخدم `clear` عندما يجب إزالة جميع أجزاء XML المخصصة المرتبطة بكائن عرض معين.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.slides[0].custom_data.custom_xml_parts.clear()

    presentation.save("slide_custom_xml_cleared.pptx", slides.export.SaveFormat.PPTX)
```

تؤثر `clear` فقط على المجموعة المحددة. على سبيل المثال، مسح مجموعة شريحة لا يمسح مجموعات المستوى العرض أو المستوى الشكل.

لإزالة كل جزء XML مخصص في العرض، تكرّر عبر `all_custom_xml_parts` وأزل كل جزء:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

### **معالجة أجزاء XML المخصصة المرتبطة أو المشتركة**

في عرض Office Open XML، يمكن الإشارة إلى نفس جزء XML المخصص من أكثر من كائن عرض. على سبيل المثال، قد يحتوي ملف موجود على علاقات من عدة شرائح أو أشكال إلى نفس جزء XML المخصص الأساسي.

يجب اعتبار الجزء المشترك ككائن بيانات واحد مع مراجع متعددة:

- تحديث `xml_as_string` أو `xml_data` أو `item_id` يغيّر الجزء الأساسي، وبالتالي ينعكس التغيير في جميع المواقع التي تُشير إليه.
- يمكن استخدام `item_id` لتحديد نفس الجزء أثناء تدقيق مجموعات مستوى الكائن.
- إزالة جزء من مجموعة `custom_xml_parts` معينة يزيله فقط من تلك المجموعة. استخدم `CustomXmlPart.remove()` عندما يجب حذف الجزء نفسه من العرض.
- قبل حذف أو استبدال جزء مشترك، راجع مجموعات مستوى الكائن لتحديد ما إذا كانت شرائح أو أشكال أخرى لا تزال تشير إليه.

إنشاء أجزاء جديدة عبر التحميل الزائد للـ `add` ينتج جزء XML مخصص جديد من محتوى XML؛ ولا يقبل جزءًا `CustomXmlPart` موجودًا. لذلك، تُظهر العلاقات المشتركة غالبًا عند تحميل عروض تحتوي عليها مسبقًا.

المثال التالي يدقق مجموعات العرض، الشريحة، والشكل حسب `item_id` ويبلغ عن الأجزاء التي تُشير إليها أكثر من موقع:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    references_by_item_id = {}

    def register_custom_xml_parts(owner_name, custom_xml_parts):
        for custom_xml_part in custom_xml_parts:
            references_by_item_id.setdefault(custom_xml_part.item_id, []).append(owner_name)

    register_custom_xml_parts("Presentation", presentation.custom_data.custom_xml_parts)

    for slide_index, slide in enumerate(presentation.slides):
        register_custom_xml_parts(
            "Slide " + str(slide_index + 1),
            slide.custom_data.custom_xml_parts
        )

        for shape_index, shape in enumerate(slide.shapes):
            register_custom_xml_parts(
                "Slide " + str(slide_index + 1) + ", shape " + str(shape_index),
                shape.custom_data.custom_xml_parts
            )

    for item_id, owner_names in references_by_item_id.items():
        if len(owner_names) > 1:
            print("Shared custom XML part: " + str(item_id))

            for owner_name in owner_names:
                print("  Referenced by: " + owner_name)
```

هذا النوع من التدقيق مفيد قبل تعديل أو حذف بيانات XML المخصصة في عروض تم إنشاؤها بواسطة أنظمة خارجية، لأن نفس جزء البيانات قد يشارك في أكثر من علاقة.

## **الحصول على قيم العلامات**

في الشرائح، تتطابق العلامة مع خاصية `DocumentProperties.keywords`. يوضح هذا المثال كيفية الحصول على قيمة علامة باستخدام Aspose.Slides للغة Python عبر .NET لـ [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/):

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    keywords = presentation.document_properties.keywords
```

## **إضافة علامات إلى العروض**

يسمح Aspose.Slides لك بإضافة علامات إلى العروض. عادةً ما تتكوّن العلامة من عنصرين:

- اسم الخاصية المخصصة، على سبيل المثال `MyTag`;
- قيمة الخاصية المخصصة، على سبيل المثال `My Tag Value`.

إذا كنت بحاجة إلى تصنيف العروض وفق قاعدة أو خاصية معينة، يمكنك إضافة علامات لهذا الغرض. على سبيل المثال، إذا رغبت في تصنيف العروض من دول أمريكا الشمالية، يمكنك إنشاء علامة “North American” وتعيين الدولة ذات الصلة كقيمتها.

يوضح المثال التالي كيفية إضافة علامة إلى [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) باستخدام Aspose.Slides للغة Python عبر .NET:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    tags = presentation.custom_data.tags
    tags.add("MyTag", "My Tag Value")
```

يمكن أيضًا ضبط العلامات لـ [Slide](https://reference.aspose.com/slides/ar/python-net/aspose.slides/slide/):

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.custom_data.tags.add("tag", "value")
```

أو لكائن [Shape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/) فردي:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **القيود**

العلامات التي تُضاف عبر مجموعة `custom_data.tags` تُخزن فقط في ملف PowerPoint. **لا** تُنقل إلى بنية العلامات في ملف PDF عند تصدير العرض إلى PDF. وبالتالي، لا يمكن استرداد معرف مخصص تم تعيينه كعلامة من PDF المعلَّم.

**حل بديل**: يمكنك تخزين معرف مخصص في **النص البديل** للكائن (مثلاً، `shape.alternative_text = "MyId"`). بعد التصدير إلى PDF، قد يظهر النص البديل في بنية علامات PDF.

## **الأسئلة المتكررة**

**هل يمكنني إزالة جميع العلامات من عرض أو شريحة أو شكل بعملية واحدة؟**

نعم. تدعم [مجموعة العلامات](https://reference.aspose.com/slides/ar/python-net/aspose.slides/tagcollection/) عملية [clear](https://reference.aspose.com/slides/ar/python-net/aspose.slides/tagcollection/clear/) التي تحذف جميع أزواج المفتاح‑القيمة مرةً واحدة.

**كيف أحذف علامة واحدة باسمها دون iterating عبر المجموعة بالكامل؟**

استخدم [remove(name)](https://reference.aspose.com/slides/ar/python-net/aspose.slides/tagcollection/remove/) على [TagCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/tagcollection/) لحذف العلامة بمفتاحها.

**كيف يمكنني استرجاع القائمة الكاملة لأسماء العلامات للتحليل أو التصفية؟**

استخدم [get_names_of_tags](https://reference.aspose.com/slides/ar/python-net/aspose.slides/tagcollection/get_names_of_tags/) على [مجموعة العلامات](https://reference.aspose.com/slides/ar/python-net/aspose.slides/tagcollection/)؛ تُعيد مصفوفة تحتوي على جميع أسماء العلامات.

**كيف يمكنني العثور على جميع أجزاء XML المخصصة بغض النظر عن موقع تخزينها؟**

استخدم [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/all_custom_xml_parts/) لاسترجاع جميع أجزاء XML المخصصة في العرض.

**هل يجب أن أستخدم `xml_as_string` أم `xml_data` لتحديث جزء XML مخصص؟**

استخدم `xml_as_string` عندما يعمل التطبيق مع نص XML بترميز UTF‑8. استخدم `xml_data` عندما يكون XML متاحًا بالفعل كمصفوفة بايت أو عندما تكون المعالجة الثنائية أكثر ملاءمة. تمثّل الخاصيتان محتوى XML لنفس الجزء المخصص.