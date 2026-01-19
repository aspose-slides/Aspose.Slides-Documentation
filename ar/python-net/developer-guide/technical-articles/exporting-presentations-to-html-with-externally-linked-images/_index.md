---
title: تصدير العروض التقديمية إلى HTML مع صور مرتبطة خارجيًا باستخدام بايثون
linktitle: تصدير العروض التقديمية إلى HTML مع صور مرتبطة خارجيًا
type: docs
weight: 100
url: /ar/python-net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- تصدير PowerPoint
- تصدير OpenDocument
- تصدير العرض التقديمي
- تصدير الشريحة
- تصدير PPT
- تصدير PPTX
- تصدير ODP
- PowerPoint إلى HTML
- OpenDocument إلى HTML
- العرض التقديمي إلى HTML
- الشريحة إلى HTML
- PPT إلى HTML
- PPTX إلى HTML
- ODP إلى HTML
- صورة مرتبطة
- صورة مرتبطة خارجيًا
- Python
- Aspose.Slides
description: "تعلم كيفية تصدير العروض التقديمية إلى HTML مع صور مرتبطة خارجيًا في Aspose.Slides للبايثون عبر .NET، بما يغطى صيغ PowerPoint و OpenDocument."
---

{{% alert color="primary" %}} 

تسمح لك عملية تصدير العرض التقديمي إلى HTML بتحديد:

1. أي الموارد يتم تضمينها في ملف HTML الناتج، و
1. أي الموارد يتم حفظها خارجيًا ويُشار إليها من ملف HTML.

{{% /alert %}} 

## **Background**

بشكل افتراضي، يدمج تصدير HTML جميع الموارد مباشرةً في ملف HTML باستخدام ترميز Base64. ينتج عن ذلك ملف HTML واحد مكتمل ذاتيًا وهو ملائم للعرض والتوزيع. ومع ذلك، فإن لهذا الأسلوب عيوبًا:

* يكون الملف الناتج أكبر بكثير من الموارد الأصلية بسبب عبء ترميز Base64.
* من الصعب تحديث أو استبدال الصور والملفات المضمَّنة.

## **Alternative Approach**

نهج بديل باستخدام [ILinkEmbedController](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/) يتجنب هذه القيود.

الفئة `LinkController` أدناه تنفذ [ILinkEmbedController](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/) ويتم تمريرها إلى مُنشئ [HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/__init__/#ilinkembedcontroller). تُظهر الفئة ثلاث طرق تتحكم في كيفية تضمين الموارد أو ربطها أثناء تصدير HTML:

[get_object_storing_location(id, entity_data, semantic_name, content_type, recommended_extension)](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/get_object_storing_location/#int-bytes-str-str-str): تُستدعى عندما يواجه المصدر المُصدِّر موردًا ويجب أن يقرر أين يخزنه. أهم المعلمات هي `id` (المعرّف الفريد للمورد في عملية التصدير هذه) و`content_type` (نوع MIME للمورد). إرجاع [LinkEmbedDecision.LINK](https://reference.aspose.com/slides/python-net/aspose.slides.export/linkembeddecision/) لربط المورد، أو [LinkEmbedDecision.EMBED](https://reference.aspose.com/slides/python-net/aspose.slides.export/linkembeddecision/) لتضمينه.

[get_url(id, referrer)](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/get_url/#int-int): تُعيد عنوان URL الذي سيظهر في ملف HTML الناتج للمورد المحدد بـ `id` (مع إمكانية الأخذ في الاعتبار كائن المرجع).

[save_external(id, entity_data)](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/save_external/#int-bytes): تُستدعى عندما يحتاج مورد مختار للربط إلى كتابة خارجية. نظرًا لتوفير المعرف والمحتوى (كمصفوفة بايت)، يمكنك حفظ المورد بأي طريقة تريدها.

تنفيذ Python للفئة `LinkController` التي تُنفّذ [ILinkEmbedController](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/) موضح أدناه.
```py
# [TODO[not_supported_yet]: تنفيذ python لواجهات .NET]
```


بعد تنفيذ الفئة `LinkController`، يمكنك استخدامها مع فئة [HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) لتصدير العرض التقديمي إلى HTML مع صور مرتبطة خارجيًا، كما هو موضح أدناه:
```py
# [TODO[not_supported_yet]: تنفيذ python لواجهات .NET]
```


قمنا بتعيين `SlideImageFormat.SVG` إلى خاصية `slide_image_format` بحيث يحتوي ملف HTML الناتج على بيانات SVG لعرض محتويات العرض التقديمي.

أنواع المحتوى: إذا كان العرض التقديمي يحتوي على صور نقطية raster، يجب أن يكون كود الفئة مستعدًا لمعالجة كل من نوعي المحتوى `image/jpeg` و`image/png`. قد لا يتطابق محتوى الصور المُصدَّرة مع ما تم تخزينه في العرض التقديمي. تقوم الخوارزميات الداخلية في Aspose.Slides بتحسين الحجم وتستخدم إما برنامج ترميز JPEG أو PNG (حسب ما ينتج ملفًا أصغر). تُشفَّر الصور التي تحتوي على قناة ألفا (شفافية) دائمًا كـ PNG.