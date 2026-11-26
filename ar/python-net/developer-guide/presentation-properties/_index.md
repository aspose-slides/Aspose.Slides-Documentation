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
- خصائص مدمجة
- خصائص مخصصة
- خصائص متقدمة
- إدارة الخصائص
- تعديل الخصائص
- بيانات تعريف المستند
- تحرير البيانات التعريفية
- لغة التدقيق
- اللغة الافتراضية
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "إتقان خصائص العرض التقديمي في Aspose.Slides for Python عبر .NET وتبسيط البحث والعلامة التجارية وسير العمل في ملفات PowerPoint الخاصة بك."
---
## **المقدمة**

Aspose.Slides for Python via .NET يدعم **المدمجة** و **المخصصة**. استخدم هذه الخصائص لقراءة وتحديث بيانات تعريف العرض التقديمي، مثل المؤلف والعنوان والقيم المعرفة من قبل المستخدم.

يتيح لك Aspose.Slides العمل مع خصائص مستند العرض التقديمي عبر الفئة [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) . يتم إرجاع مثال من هذه الفئة بواسطة [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/). توضح الأمثلة التالية كيفية قراءة هذه الخصائص وتعديلها وإدارتها.

{{% alert color="info" title="Note" %}}
يدير Aspose.Slides بيانات التعريف الخاصة بالتطبيق والمنتج عند حفظ العروض التقديمية؛ تُعرِّف هذه الحقول البرنامج الذي أنشأ المخرجات.
{{% /alert %}}

## **إدارة خصائص العرض التقديمي**

تخزن خصائص المستند معلومات وصفية إلى جانب محتوى العرض التقديمي. وتنقسم إلى فئتين:

- **الخصائص المدمجة** تحتوي على بيانات تعريف معيارية، مثل العنوان والمؤلف وإحصائيات المستند.
- **الخصائص المخصصة** تخزن أزواج اسم/قيمة يحددها المستخدم.

Aspose.Slides for Python via .NET يوفر الوصول إلى كلتا الفئتين. في PowerPoint، اختر **File → Info → Properties → Advanced Properties** لتفحص بيانات تعريف المستند. يجمع الحوار المعلومات في علامات تبويب مثل **Summary**, **Statistics**, **Contents**, و **Custom**. استخدم تبويب **Custom** لإدارة الخصائص المعرفة من قبل المستخدم.

## **قراءة الخصائص العامة من عرض تقديمي مشفر**

عادةً ما يحمي كلمة مرور الفتح كلًا من محتوى العرض التقديمي وخصائص المستند. عندما يتم تشفير العرض باستخدام [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) مضبوطًا على `False`، تظل خصائص المستند عامة. يمكن للتطبيق بعد ذلك ضبط [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) إلى `True` وقراءة البيانات التعريفية العامة دون توفير كلمة مرور الفتح.

[LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) يتحكم في ما يقوم Aspose.Slides بتحميله؛ فهو لا يقوم بفك تشفير أي شيء. إذا تم تضمين الخصائص في عملية التشفير، فإن تحميلها بدون كلمة المرور سيفشل. إذا لم يكن العرض مشفرًا، يتم تجاهل الخيار وتتم تحميل العرض بالكامل.

يتطلب المثال عرضًا تقديميًا مشفرًا تُركت فيه خصائص المستند عامة. يتحقق من وضع التحميل عبر [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) ثم يقرأ الخصائص المدمجة عبر [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/):

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

في هذا الوضع، لا يتم تحميل محتوى الشرائح. الشرائح، القوالب الرئيسية، التخطيطات، الأشكال، الوسائط، وغيرها من كائنات العرض غير متاحة. يجب على التطبيقات دائمًا التحقق من [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) قبل تنفيذ عملية تتطلب نموذج كائنات العرض الكامل.

{{% alert color="warning" title="Security" %}}
قد يكشف البيانات التعريفية العامة عن أسماء المؤلفين والعناوين والمواضيع والكلمات المفتاحية ومعلومات الشركة والتعليقات والقيم المخصصة. قم بتشفير الخصائص الحساسة مع العرض التقديمي. اتركها عامة فقط عندما يتطلب الفهرسة أو التصنيف أو البحث أو أنظمة إدارة المستندات وصولًا إليها بدون كلمة مرور.
{{% /alert %}}

## **تحديث خصائص عرض تقديمي مشفر**

بالنسبة لملف PPTX مشفر، يُقصد بالعرض المحمَّل باستخدام [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) قراءة البيانات التعريفية العامة. لا يمكن لـ Aspose.Slides حفظ الخصائص المتغيّرة من ذلك الكائن الذي يحتوي على البيانات فقط لأن الخصائص العامة يجب أن تظل متسقة مع البيانات المقابلة داخل العرض المشفر. وبالتالي يتطلب تحديثها كلمة مرور الفتح الصحيحة وتحميلًا كاملاً.

يتطلب المثال عرض PPTX مشفر يحتوي على خصائص مستند عامة وكلمة مرور فتح معروفة. يفتح العرض بالكامل باستخدام [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/), يحدّث الخصائص العامة المدمجة، ثم يحفظ النتيجة. بعد ذلك يستخدم [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/is_encrypted/) للتحقق من الحفاظ على التشفير ويعيد فتح البيانات العامة بدون كلمة مرور للتحقق من القيم الجديدة:

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

إذا لم يُسمح للتطبيق بفك تشفير أو تحميل محتوى العرض، يجب أن يتعامل مع الخصائص العامة لملف PPTX المشفر كقابلة للقراءة فقط.

## **الوصول إلى الخصائص المدمجة**

تُظهر فئة [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) البيانات التعريفية المدمجة من خلال خصائص مكتوبة النوع، بما في ذلك [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/), و[DocumentProperties.created_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/created_time/). يفتح هذا المثال عرضًا موجودًا ويطبع البيانات التعريفية المخزنة في وحدة التحكم. القيم تعتمد على العرض المُدخل؛ قد تكون بعض الحقول فارغة.

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

### **الإبلاغ عن رقم المراجعة ووقت التعديل**

للإبلاغ عن رقم المراجعة وإجمالي وقت التعديل لكل ملف PPTX في مجلد `presentations`، استخدم [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) لاسترداد [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) دون تحميل الشرائح للتعديل. تعرض Python المدة كـ `timedelta`، بما في ذلك عدد الأيام عندما يصل الوقت المسجل إلى 24 ساعة.

```python
from pathlib import Path

import aspose.slides as slides

print("File | RevisionNumber | TotalEditingTime")
for path in Path("presentations").glob("*.pptx"):
    if path.is_file():
        info = slides.PresentationFactory.instance.get_presentation_info(str(path))
        properties = info.read_document_properties()
        print(f"{path.name} | {properties.revision_number} | {properties.total_editing_time}")
```

لعرض يحتوي على مدة تعديل مسجلة مقدارها 1 يوم و2 ساعة و5 دقائق، يحتوي التقرير على الصف التالي.

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1 day, 2:05:00
```

[DocumentProperties.revision_number](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/revision_number/) هو بيانات تعريف قابلة للكتابة. قيمته وحدها لا يمكن أن تحدد عدد مرات حفظ العرض أو تعيد بناء تاريخ إصداراته.

[DocumentProperties.total_editing_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/total_editing_time/) يُظهر مدة التعديل المخزنة في الملف. قيمة `0:00:00` تعني أن المدة المسجلة صفر، حتى لو قام شخص ما بتعديل العرض.

## **تعديل الخصائص المدمجة**

لتحديث البيانات التعريفية المدمجة، عيّن قيمًا للخصائص القابلة للكتابة التي تُظهرها [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/). يفتح هذا المثال عرضًا موجودًا، يضبط [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/), [DocumentProperties.subject](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/subject/), [DocumentProperties.comments](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/comments/), و[DocumentProperties.manager](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/manager/)، ثم يحفظ العرض المُحدّث باستخدام [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). يحتوي ملف PPTX المحفوظ على البيانات التعريفية الجديدة.

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

## **إدارة قاعدة الروابط التشعبية**

[DocumentProperties.hyperlink_base](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/hyperlink_base/) يخزن القاعدة على مستوى المستند للروابط التشعبية النسبية. هذا مفيد عند نقل عرض تقديمي وملفاته المرتبطة إلى موقع آخر. وهو منفصل عن [Hyperlink.external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/): تغيير القاعدة لا يُعيد كتابة عناوين الروابط المخزنة ولا يغيّر الوجهات المطلقة.

يتطلب المثال عرضًا يحتوي على رابط نسبي، مثل `target.html`، ورابط مطلق إلى ملف أو موقع ويب. يقرأ القاعدة الحالية، يُعين عنوان قاعدة جديد، ثم يحفظ ويعيد فتح العرض للتحقق من القيمة. بعد ذلك يُفرغ القاعدة باستخدام `""` ويتحقق من القيمة الفارغة في ملف محفوظ منفصل. استبدل عنوان القاعدة في المثال بموقع ملفاتك المرتبطة.

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

يجب أن تطبع رسائل التحقق الاثنين القيمة `True`. إفراغ القاعدة يترك عناوين الروابط التشعبية الفردية سليمة.

رابط نسبي إلى `target.pptx` فتح `old/target.pptx` عندما كانت القاعدة تشير إلى المجلد `old`. بعد تغيير القاعدة إلى المجلد `new`، وحفظ وإعادة فتح العرض، فتح الرابط نفسه `new/target.pptx`. استمر الرابط المطلق في فتح الملف نفسه. اختبر روابطك النسبية في PowerPoint قبل وبعد نقل العرض أو تغيير قاعدته.

## **إضافة خصائص عرض تقديمي مخصصة**

تخزن الخصائص المخصصة بيانات تعريف لا توجد لها حقل مدمج مماثل. تسمح لك طريقة [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) بتعيين قيمة حسب اسم الخاصية. ينشئ هذا المثال عرضًا، يضيف قيمتين نصيتين وقيمة إصدار عددية، ويحفظ العرض باستخدام [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). تعيين قيمة لاسم موجود يستبدل قيمة الخاصية.

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

يفتح هذا المثال عرضًا يحتوي على خصائص مخصصة ويستخدم [DocumentProperties.count_of_custom_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/count_of_custom_properties/) للتنقل بينها. تستقبل [DocumentProperties.get_custom_property_name](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_name/) فهرسًا يبدأ من الصفر وتُعيد الاسم المستخدم في [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/). يتطلب المثال عرضًا تكون فيه جميع الخصائص المخصصة سلاسل نصية. يطبع كل اسم وقيمة أصلية، يستبدل كل قيمة بسلسلة مرقمة، ويحفظ التغييرات. إذا لم توجد خصائص مخصصة، فلا يُجري الحلقة أي تغييرات.

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

[DocumentProperties.get_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_value/) يُعيد القيمة عبر القائمة ذات العنصر الواحد التي تُمرَّر كوسيطه الثاني. يجب أن يتطابق العنصر النائب مع نوع الخاصية المخزنة: استخدم `[""]` لسلسلة نصية أو `[0]` لعدد صحيح. يُسبب عدم تطابق النوع رفع استثناء `InvalidCastException`؛ اختر العنصر النائب وفقًا لمخطط الخاصية المخصصة لديك.

## **مثال حي**

جرّب التطبيق عبر الإنترنت [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) لترى كيفية العمل مع خصائص المستند باستخدام Aspose.Slides API:

[![عرض وتعديل بيانات تعريف PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **الأسئلة الشائعة**

**كيف يمكنني إزالة خاصية مدمجة من عرض تقديمي؟**

الخصائص المدمجة جزء لا يتجزأ من العرض ولا يمكن إزالتها بالكامل. ومع ذلك، يمكنك إما تغيير قيمها أو تعيينها كقيمة فارغة إذا سمحت الخاصية المحددة بذلك.

**ماذا يحدث إذا أضفت خاصية مخصصة موجودة بالفعل؟**

إذا أضفت خاصية مخصصة موجودة بالفعل، سيتم استبدال قيمتها الحالية بالقيمة الجديدة. لا تحتاج إلى إزالة أو فحص الخاصية مسبقًا، حيث يقوم Aspose.Slides بتحديث قيمة الخاصية تلقائيًا.

**هل يمكنني الوصول إلى خصائص العرض دون تحميل العرض بالكامل؟**

نعم. استخدم [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) ثم [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) لقراءة بيانات تعريف المستند المخزنة دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). راجع [Build a Lightweight Presentation Inventory](/slides/ar/python-net/examine-presentation/) للحصول على مثال شامل للتقارير والقيود الخاصة بالتنسيق.

**هل يمكنني قراءة الخصائص العامة لعرض مشفر بدون كلمة مرور الفتح الخاصة به؟**

نعم. يجب أن يكون العرض قد تم تشفيره باستخدام [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) مضبوطًا على `False`، ويجب تحميله باستخدام [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) مضبوطًا على `True`.

**هل يمكنني تحديث ملف PPTX مشفر في وضع خصائص المستند فقط؟**

لا. يجب أن تبقى بيانات الخصائص العامة والمشفرة متسقة، لذا يتطلب تحديث ملف PPTX مشفر تحميل العرض بالكامل باستخدام كلمة مرور الفتح الصحيحة.