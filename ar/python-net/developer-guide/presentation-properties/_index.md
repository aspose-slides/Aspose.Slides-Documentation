---
title: إدارة خصائص العرض التقديمي باستخدام بايثون
linktitle: خصائص العرض التقديمي
type: docs
weight: 70
url: /ar/python-net/presentation-properties/
keywords:
- خصائص PowerPoint
- خصائص العرض التقديمي
- خصائص المستند
- الخصائص المضمنة
- الخصائص المخصصة
- الخصائص المتقدمة
- إدارة الخصائص
- تعديل الخصائص
- بيانات تعريف المستند
- تحرير بيانات التعريف
- لغة التدقيق
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "إتقان خصائص العرض التقديمي في Aspose.Slides for Python عبر .NET وتبسيط البحث والعلامة التجارية وسير العمل في ملفات PowerPoint الخاصة بك."
---
## **مقدمة**

Aspose.Slides for Python via .NET يدعم الخصائص **المضمنة** و**المخصصة** للمستند. استخدم هذه الخصائص لقراءة وتحديث بيانات تعريف العرض التقديمي، مثل المؤلف والعنوان والقيم المعرفة من قبل المستخدم.

يسمح لك Aspose.Slides بالعمل مع خصائص مستند العرض التقديمي من خلال الفئة [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) . يتم إرجاع مثيل من هذه الفئة بواسطة [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/). توضح الأمثلة التالية كيفية قراءة هذه الخصائص وتعديلها وإدارتها.

{{% alert color="info" title="Note" %}}
يتعامل Aspose.Slides مع بيانات التعريف الخاصة بالتطبيق والمنتج عند حفظ العروض التقديمية؛ تحدد هذه الحقول البرنامج الذي أنشأ الناتج.
{{% /alert %}}

## **إدارة خصائص العرض التقديمي**

تخزن خصائص المستند معلومات وصفية بجانب محتوى العرض التقديمي. وتنقسم إلى فئتين:

- **الخصائص المضمنة** تحتوي على بيانات تعريف قياسية، مثل العنوان، المؤلف، وإحصاءات المستند.
- **الخصائص المخصصة** تخزن أزواج اسم/قيمة معرفة من قبل المستخدم.

يوفر Aspose.Slides for Python via .NET إمكانية الوصول إلى كلتا الفئتين. في PowerPoint، اختر **File → Info → Properties → Advanced Properties** لتفقد بيانات تعريف المستند. يجمع الحوار المعلومات في علامات تبويب مثل **ملخص**، **إحصاءات**، **المحتويات**، و **مخصص**. استخدم علامة تبويب **مخصص** لإدارة الخصائص المعرفة من قبل المستخدم.

## **قراءة الخصائص العامة من عرض تقديمي مشفر**

عادةً ما يحمي كلمة مرور الفتح كلًا من محتوى العرض التقديمي وخصائص المستند. عندما يُشفّر العرض التقديمي باستخدام [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) وتكون القيمة `False`، تبقى خصائص المستند عامة. يمكن للتطبيق حينها ضبط [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) إلى `True` وقراءة البيانات التعريفية العامة دون تقديم كلمة مرور الفتح.

[LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) يتحكم فيما يحمله Aspose.Slides؛ فهو لا يقوم بفك تشفير أي شيء. إذا كانت الخصائص مشمولة في التشفير، فسيؤدي تحميلها دون كلمة المرور إلى فشل. إذا لم يكن العرض التقديمي مشفرًا، يتم تجاهل الخيار ويُحمَّل العرض بالكامل.

يتطلب المثال عرضًا تقديميًا مشفرًا تُركت خصائص مستنده عامة. يتحقق من وضع التحميل عبر [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) ثم يقرأ الخصائص المضمنة عبر [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("public-properties-encrypted.pptx", load_options) as presentation:
    if presentation.protection_manager.is_only_document_properties_loaded:
        document_properties = presentation.document_properties

        print("Author: " + document_properties.author)
        print("Title: " + document_properties.title)
        print("Keywords: " + document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

في هذا الوضع، لا يتم تحميل محتوى الشرائح. الشرائح، القوالب الرئيسة، التخطيطات، الأشكال، الوسائط، وغيرها من كائنات العرض غير متوفرة. يجب على التطبيقات دائمًا فحص [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) قبل تنفيذ أي عملية تتطلب نموذج كائن العرض الكامل.

{{% alert color="warning" title="Security" %}}
قد تكشف البيانات التعريفية العامة عن أسماء المؤلفين، العناوين، المواضيع، الكلمات المفتاحية، معلومات الشركة، التعليقات، والقيم المخصصة. قم بتشفير الخصائص الحساسة مع العرض التقديمي. اتركها عامة فقط عندما يتطلب الفهرسة أو التصنيف أو البحث أو أنظمة إدارة المستندات إمكانية الوصول إليها دون كلمة مرور.
{{% /alert %}}

## **تحديث خصائص عرض تقديمي مشفر**

بالنسبة لملف PPTX مشفر، يُقصد من العرض الذي يُحمَّل باستخدام [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) قراءة البيانات التعريفية العامة. لا يمكن لـ Aspose.Slides حفظ الخصائص التي تم تعديلها من كائن يقتصر على البيانات التعريفية لأن الخصائص العامة يجب أن تظل متسقة مع البيانات المقابلة داخل العرض المشفر. لذلك يتطلب تحديثها كلمة مرور الفتح الصحيحة وتحميلًا كاملاً.

يتطلب المثال عرض PPTX مشفر يحتوي على خصائص مستند عامة وكلمة مرور فتح معروفة. يفتح العرض بالكامل باستخدام [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/)، يحدّث الخصائص المضمنة العامة، ويحفظ النتيجة. ثم يستخدم [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/is_encrypted/) للتحقق من الحفاظ على التشفير ويعيد فتح البيانات العامة دون كلمة مرور للتحقق من القيم الجديدة:

```python
import aspose.slides as slides

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation(input_path, load_options) as presentation:
    document_properties = presentation.document_properties
    document_properties.title = "Updated Product Roadmap"
    document_properties.keywords = "roadmap, planning, indexed"
    
    presentation.save(output_path, slides.export.SaveFormat.PPTX)

presentation_info = slides.PresentationFactory.instance.get_presentation_info(output_path)
print("The presentation is encrypted: " + str(presentation_info.is_encrypted))

metadata_load_options = slides.LoadOptions()
metadata_load_options.only_load_document_properties = True

with slides.Presentation(output_path, metadata_load_options) as metadata_presentation:
    if metadata_presentation.protection_manager.is_only_document_properties_loaded:
        print("Title: " + metadata_presentation.document_properties.title)
        print("Keywords: " + metadata_presentation.document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

إذا لم يُسمح للتطبيق بفك تشفير أو تحميل محتوى العرض، يجب أن يتعامل مع الخصائص العامة لملف PPTX المشفر كقواعد للقراءة فقط.

## **الوصول إلى الخصائص المضمنة**

تُظهر الفئة [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) البيانات التعريفية المضمنة من خلال خصائص ذات نوع محدد، بما في ذلك [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/)、[DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/)، و [DocumentProperties.created_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/created_time/). يفتح هذا المثال عرضًا تقديميًا موجودًا ويطبع بياناته التعريفية المخزنة إلى وحدة التحكم. تعتمد القيم على العرض المدخل؛ قد تكون بعض الحقول فارغة.

```python
import aspose.slides as slides

with slides.Presentation("AccessBuiltInProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    print("Category:", document_properties.category)
    print("Content status:", document_properties.content_status)
    print("Creation date:", document_properties.created_time)
    print("Author:", document_properties.author)
    print("Comments:", document_properties.comments)
    print("Keywords:", document_properties.keywords)
    print("Last modified by:", document_properties.last_saved_by)
    print("Manager:", document_properties.manager)
    print("Modified date:", document_properties.last_saved_time)
    print("Presentation format:", document_properties.presentation_format)
    print("Last print date:", document_properties.last_printed)
    print("Is shared between producers:", document_properties.shared_doc)
    print("Subject:", document_properties.subject)
    print("Title:", document_properties.title)
```

## **تعديل الخصائص المضمنة**

لتحديث البيانات التعريفية المضمنة، عيّن قيمًا للخصائص القابلة للكتابة التي تُظهرها [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/). يفتح هذا المثال عرضًا تقديميًا موجودًا، يضبط [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/)、[DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/)、[DocumentProperties.subject](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/subject/)、[DocumentProperties.comments](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/comments/)、و [DocumentProperties.manager](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/manager/)، ثم يحفظ العرض المحدث باستخدام [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). يحتوي ملف PPTX المحفوظ على البيانات التعريفية الجديدة.

```python
import aspose.slides as slides

with slides.Presentation("ModifyBuiltInProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    document_properties.author = "Aspose.Slides for Python via .NET"
    document_properties.title = "Manage PowerPoint Presentation Properties"
    document_properties.subject = "Modify Built-in Properties"
    document_properties.comments = "Aspose description"
    document_properties.manager = "Aspose manager"

    presentation.save("DocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **إدارة قاعدة الرابط التشعبي**

يخزن [DocumentProperties.hyperlink_base](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/hyperlink_base/) القاعدة على مستوى المستند للروابط التشعبية النسبية. هذا مفيد عند نقل عرض تقديمي وملفاته المرتبطة إلى موقع آخر. وهو منفصل عن [Hyperlink.external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/) للربط الفردي: تغيير القاعدة لا يعيد كتابة عناوين الروابط المخزنة ولا يغيّر الوجهات المطلقة.

يتطلب المثال عرضًا يحتوي على رابط نسبي، مثل `target.html`، ورابط مطلق إلى ملف أو موقع ويب. يقرأ القاعدة الحالية، يعيّن عنوان قاعدة جديد، ويحفظ ويعيد فتح العرض للتحقق من القيمة. ثم يمسح القاعدة باستخدام `""` ويتحقق من القيمة الفارغة في ملف محفوظ منفصل. استبدل عنوان القاعدة المثال بموقع ملفاتك المرتبطة.

```python
import aspose.slides as slides

with slides.Presentation("hyperlinks.pptx") as presentation:
    print("Original base:", presentation.document_properties.hyperlink_base)

    new_base = "https://example.com/new/"
    presentation.document_properties.hyperlink_base = new_base
    presentation.save("hyperlinks-updated.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlinks-updated.pptx") as updated_presentation:
    print("Base preserved:", updated_presentation.document_properties.hyperlink_base == new_base)

    updated_presentation.document_properties.hyperlink_base = ""
    updated_presentation.save("hyperlinks-cleared.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlinks-cleared.pptx") as cleared_presentation:
    print("Base cleared:", cleared_presentation.document_properties.hyperlink_base == "")
```

يجب أن تطبع رسائل التحقق الاثنين القيمة `True`. مسح القاعدة يترك عناوين الروابط التشعبية الفردية دون تغيير.

رابط نسبي إلى `target.pptx` كان يفتح `old/target.pptx` عندما كانت القاعدة تشير إلى مجلد `old`. بعد تغيير القاعدة إلى مجلد `new`، وحفظ وإعادة فتح العرض، فتح نفس الرابط `new/target.pptx`. استمر الرابط المطلق في فتح نفس الملف. اختبر روابطك النسبية في PowerPoint قبل وبعد نقل العرض أو تغيير قاعدته.

## **إضافة خصائص عرض مخصصة**

تخزن الخصائص المخصصة البيانات التعريفية التي لا يوجد لها حقل مدمج مقابل. تتيح لك طريقة [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) تعيين قيمة وفقًا لاسم الخاصية. ينشئ هذا المثال عرضًا تقديميًا، يضيف قيمتي نص ونسخة عددية صحيحة، ويحفظ العرض باستخدام [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). تعيين قيمة لاسم موجود يستبدل قيمة الخاصية.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    document_properties = presentation.document_properties

    document_properties.set_custom_property_value("Reviewed by", "John Smith")
    document_properties.set_custom_property_value("Confidentiality level", "Internal")
    document_properties.set_custom_property_value("Document version", 2)

    presentation.save("CustomDocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **الوصول إلى الخصائص المخصصة وتعديلها**

يفتح هذا المثال عرضًا يحتوي على خصائص مخصصة ويستخدم [DocumentProperties.count_of_custom_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/count_of_custom_properties/) للتجول فيها. تستقبل [DocumentProperties.get_custom_property_name](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_name/) فهرسًا يبدأ من الصفر وتعيد الاسم المستخدم في [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/). يتطلب المثال عرضًا تكون جميع خصائصه المخصصة سلاسل نصية. يطبع كل اسم وقيمة أصلية، يستبدل كل قيمة بسلسلة مرقمة، ويحفظ التغييرات. إذا لم تكن هناك خصائص مخصصة، فإن الحلقة لا تُجري أي تغييرات.

```python
import aspose.slides as slides

with slides.Presentation("AccessAndModifyProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    for i in range(document_properties.count_of_custom_properties):
        property_name = document_properties.get_custom_property_name(i)
        property_value = [""]
        document_properties.get_custom_property_value(property_name, property_value)

        print("Custom property name:", property_name)
        print("Custom property value:", property_value[0])

        document_properties.set_custom_property_value(property_name, "New Value " + str(i + 1))

    presentation.save("CustomProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

[DocumentProperties.get_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_value/) يُعيد القيمة عبر القائمة ذات العنصر الواحد التي تُمرَّر كالحجة الثانية. يجب أن يتطابق العنصر النائب مع نوع الخاصية المخزنة: استخدم `[""]` لسلسلة نصية أو `[0]` لعدد صحيح. يؤدي عدم التطابق إلى رفع استثناء `InvalidCastException`؛ اختر العنصر النائب وفقًا لمخطط الخاصية المخصصة.

## **مثال حي**

جرّب تطبيق الويب [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) لرؤية كيفية العمل مع خصائص المستند باستخدام واجهة برمجة تطبيقات Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **الأسئلة الشائعة**

**كيف يمكنني إزالة خاصية مدمجة من عرض تقديمي؟**

الخصائص المدمجة جزء أساسي من العرض ولا يمكن إزالتها بالكامل. ومع ذلك، يمكنك إما تغيير قيمها أو تعيينها كفارغة إذا سمحت الخاصية المحددة بذلك.

**ماذا يحدث إذا أضفت خاصية مخصصة موجودة مسبقًا؟**

إذا أضفت خاصية مخصصة موجودة بالفعل، سيتم استبدال قيمتها الحالية بالقيمة الجديدة. لا تحتاج إلى إزالة أو فحص الخاصية مسبقًا، حيث يقوم Aspose.Slides تلقائيًا بتحديث قيمة الخاصية.

**هل يمكنني الوصول إلى خصائص العرض دون تحميل العرض بالكامل؟**

نعم. استخدم [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) ثم [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) لقراءة البيانات التعريفية المخزنة للمستند دون إنشاء نسخة من [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). راجع [Build a Lightweight Presentation Inventory](/slides/ar/python-net/examine-presentation/) للحصول على مثال تقارير كامل والقيود الخاصة بالصيغ.

**هل يمكنني قراءة الخصائص العامة لعرض مشفر دون كلمة مرور الفتح؟**

نعم. يجب أن يكون العرض قد تم تشفيره باستخدام [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) مع تعيين القيمة `False`، ويجب تحميله باستخدام [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) مع تعيين القيمة `True`.

**هل يمكنني تحديث ملف PPTX مشفر في وضع تحميل خصائص المستند فقط؟**

لا. يجب أن تظل بيانات الخصائص العامة والمشفرة متسقة، لذا يتطلب تحديث ملف PPTX مشفر تحميل العرض بالكامل مع كلمة مرور الفتح الصحيحة.