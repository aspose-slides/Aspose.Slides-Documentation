---
title: تصدير العروض التقديمية إلى HTML مع صور مرتبطة خارجيًا في بايثون
linktitle: تصدير العروض التقديمية إلى HTML مع صور مرتبطة
type: docs
weight: 100
url: /ar/python-net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- تصدير PowerPoint
- تصدير OpenDocument
- تصدير عرض تقديمي
- تصدير شريحة
- تصدير PPT
- تصدير PPTX
- تصدير ODP
- PowerPoint إلى HTML
- OpenDocument إلى HTML
- عرض تقديمي إلى HTML
- شريحة إلى HTML
- PPT إلى HTML
- PPTX إلى HTML
- ODP إلى HTML
- صورة مرتبطة
- صورة مرتبطة خارجيًا
- Python
- Aspose.Slides
description: "تعرف على كيفية تصدير العروض التقديمية إلى HTML مع صور مرتبطة خارجيًا في Aspose.Slides للبايثون عبر .NET، مع تغطية صيغ PowerPoint وOpenDocument."
---

{{% alert color="primary" %}} 
تتيح لك عملية تصدير العرض التقديمي إلى HTML تحديد:
1. الموارد التي يتم تضمينها في ملف HTML الناتج، و
1. الموارد التي يتم حفظها خارجيًا ويتم الإشارة إليها من ملف HTML.
{{% /alert %}} 

## **الخلفية**
بشكل افتراضي، يقوم تصدير HTML بتضمين جميع الموارد مباشرةً في ملف HTML باستخدام الترميز Base64. هذا ينتج ملف HTML واحد مستقل يُسهّل عرضه وتوزيعه. مع ذلك، لهذا النهج عيوب:
* حجم الملف الناتج أكبر بكثير من الموارد الأصلية بسبب الحمل الزائد لـ Base64.
* من الصعب تحديث أو استبدال الصور المضمنة وغيرها من الأصول.

## **نهج بديل**
نهج بديل يستخدم [ILinkEmbedController](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/) يتجنب هذه القيود.

الفئة `LinkController` أدناه تنفّذ [ILinkEmbedController](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/) ويتم تمريرها إلى مُنشئ [HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/__init__/#ilinkembedcontroller). تُظهر الفئة ثلاث طرق تتحكم في كيفية تضمين الموارد أو ربطها أثناء تصدير HTML:
[get_object_storing_location(id, entity_data, semantic_name, content_type, recommended_extension)](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/get_object_storing_location/#int-bytes-str-str-str): يتم استدعاؤه عندما يواجه المصدّر موردًا ويجب عليه تحديد مكان تخزينه. أهم المعلمات هي `id` (المعرّف الفريد للمورد في عملية التصدير هذه) و `content_type` (نوع MIME للمورد). إرجع [LinkEmbedDecision.LINK](https://reference.aspose.com/slides/python-net/aspose.slides.export/linkembeddecision/) لربط المورد، أو [LinkEmbedDecision.EMBED](https://reference.aspose.com/slides/python-net/aspose.slides.export/linkembeddecision/) لتضمينه.

[get_url(id, referrer)](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/get_url/#int-int): يُرجع عنوان URL الذي سيظهر في ملف HTML الناتج للمورد المحدد بـ `id` (مع مراعاة كائن المرجع إذا لزم الأمر).

[save_external(id, entity_data)](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/save_external/#int-bytes): يتم استدعاؤه عندما يحتاج مورد مختار للربط إلى أن يُكتب خارجيًا. لأن المعرف والمحتوى مُقدَّمان (كمصفوفة بايت)، يمكنك حفظ المورد بأي طريقة تريد.

الطبقة التنفيذية في Python لـ `LinkController` لـ [ILinkEmbedController](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/) موضحة أدناه.
```py
# [TODO[not_supported_yet]: تنفيذ python لواجهات .NET]
```


بعد تنفيذ الفئة `LinkController`، يمكنك استخدامها مع الفئة [HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/htmloptions/) لتصدير العرض التقديمي إلى HTML مع صور مرتبطة خارجيًا، كما هو موضح أدناه:
```py
# [TODO[not_supported_yet]: تنفيذ python لواجهات .NET]
```


قُمنا بتعيين `SlideImageFormat.SVG` إلى الخاصية `slide_image_format` بحيث يحتوي ملف HTML الناتج على بيانات SVG لعرض محتويات العرض التقديمي.

أنواع المحتوى: إذا كان العرض التقديمي يحتوي على صور نقطية (bitmap)، يجب أن يكون كود الفئة جاهزًا لمعالجة كل من نوعي المحتوى `image/jpeg` و `image/png`. قد لا يتطابق محتوى الصور المصدرة مع ما تم تخزينه في العرض التقديمي. تقوم خوارزميات Aspose.Slides الداخلية بتحسين الحجم وتستخدم إما ترميز JPEG أو PNG (حسب أيهما ينتج ملفًا أصغر). الصور التي تحتوي على قناة ألفا (شفافية) يتم دائمًا ترميزها كـ PNG.