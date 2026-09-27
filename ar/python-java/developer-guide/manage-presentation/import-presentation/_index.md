---
title: "استيراد عروض تقديمية من PDF أو HTML في Python عبر Java"
linktitle: "استيراد عرض تقديمي"
type: docs
weight: 60
url: /ar/python-java/import-presentation/
keywords:
- "استيراد عرض تقديمي"
- "استيراد شريحة"
- "استيراد PDF"
- "استيراد HTML"
- "PDF إلى عرض تقديمي"
- "PDF إلى PPT"
- "PDF إلى PPTX"
- "PDF إلى ODP"
- "HTML إلى عرض تقديمي"
- "HTML إلى PPT"
- "HTML إلى PPTX"
- "HTML إلى ODP"
- "PowerPoint"
- "OpenDocument"
- "Python"
- "Java"
- "Aspose.Slides"
description: "تعلم كيفية استيراد محتوى PDF وHTML إلى عروض PowerPoint في Python عبر Java باستخدام Aspose.Slides وحفظ النتائج كملفات PPTX."
---
## **مقدمة**

يمكن لـ Aspose.Slides للـ Python عبر Java تحويل صفحات PDF أو محتوى HTML إلى شرائح PowerPoint بدون الحاجة إلى Microsoft PowerPoint. توفر الفئة [SlideCollection](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/) الطريقة [addFromPdf](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addFromPdf) و[addFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addFromHtml) لإضافة المحتوى المستورد إلى عرض تقديمي.

للحصول على مزيد من التحكم في وضعية HTML، يمكن لـ [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#insertFromHtml) إدراج الشرائح المُولدة عند فهرس في المجموعة أو البدء بملء المساحة المتاحة على شريحة موجودة. يتم تقسيم HTML الطويل تلقائيًا عبر شرائح إضافية، ويمكن توفير المصدر كسلسلة نصية أو تدفق، كما يمكن تحميل الأصول الخارجية عبر [ExternalResourceResolver](https://reference.aspose.com/slides/python-java/aspose.slides/externalresourceresolver/) باستخدام URI أساسي. تُعرّف المصفوفة المُرجعة من [Slide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/) الشرائح المتأثرة والجديدة.

## **استيراد من PDF**

لتحويل مستند PDF إلى عرض تقديمي PowerPoint، استورد محتواه إلى مجموعة الشرائح واحفظ النتيجة كملف PPTX.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. أنشئ كائنًا جديدًا من الفئة [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. استدعِ [addFromPdf](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addFromPdf) مع مسار ملف PDF.
3. استدعِ [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) مع [SaveFormat.Pptx](https://reference.aspose.com/slides/python-java/aspose.slides/saveformat/#Pptx) لكتابة العرض التقديمي إلى ملف PPTX.

المثال التالي بلغة Python يستورد مستند PDF ويحفظ الشرائح المُولدة كعرض PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlides().addFromPdf("document.pdf")
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

تظل الشريحة الفارغة الافتراضية موجودة في العرض لأن عملية الاستيراد تُضيف شرائح. لإبقاء الصفحات المستوردة فقط، قم بمسح مجموعة الشرائح باستخدام [SlideCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#clear) قبل الاستيراد.

طريقة [addFromPdf](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addFromPdf) تُعيد الشرائح التي تُضيفها، وهذا مفيد عندما تحتاج إلى معالجة الشرائح المستوردة فقط.

{{% alert title="Tip" color="success" %}}جرّب تطبيق الويب المجاني [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) لتشاهد سير عمل التحويل عمليًا.{{% /alert %}}

## **استيراد من HTML**

يمكن لـ Aspose.Slides أيضًا إنشاء شرائح من مستند HTML. يمكن توفير المصدر كنص HTML أو تدفق. الخطوات التالية تستخدم تدفق ملف:

1. أنشئ كائنًا جديدًا من الفئة [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/).
2. افتح ملف HTML للقراءة ومرّر التدفق إلى [addFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addFromHtml).
3. استدعِ [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) مع [SaveFormat.Pptx](https://reference.aspose.com/slides/python-java/aspose.slides/saveformat/#Pptx) لكتابة النتيجة إلى ملف PPTX.

المثال التالي بلغة Python يستورد مستند HTML ويحفظ الشرائح المُولدة كعرض PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.io import FileInputStream

presentation = Presentation()
try:
    html_stream = FileInputStream("page.html")
    try:
        presentation.getSlides().addFromHtml(html_stream)
    finally:
        html_stream.close()
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **إدراج محتوى HTML**

استخدم [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#insertFromHtml) عندما يجب وضع الشرائح التي تم توليدها من HTML في موضع محدد بدلاً من إضافتها في النهاية. الفهرس يبدأ من الصفر ويحدد الموضع الذي يبدأ فيه الاستيراد.

المعامل `useSlideWithIndexAsStart` يتحكم في كيفية استخدام المستورد لهذا الموضع:

- عندما يكون `False`، ينشئ المستورد شرائح جديدة عند الفهرس المحدد ويُزاح الشرائح التي تليه.
- عندما يكون `True`، يبدأ المستورد بوضع المحتوى في المساحة المتاحة على الشريحة الموجودة عند ذلك الفهرس. إذا لم يتسع HTML، يقوم Aspose.Slides بتقسيمه تلقائيًا ويُدرج شرائح إضافية مباشرة بعد الشريحة الابتدائية.

طريقة [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#insertFromHtml) تُعيد مصفوفة من كائنات [Slide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/). عندما يبدأ الإدراج على شرائح جديدة، كل عنصر مُرجع يُنشأ حديثًا. عندما تُستخدم شريحة موجودة كنقطة بدء، تشمل المصفوفة تلك الشريحة المتأثرة متبوعة بأي شرائح تجاوز جديدة. يمكنك فحص هذه المصفوفة بدلاً من حساب النطاق المتأثر من عدد شرائح العرض.

### **إدراج HTML كشرائح جديدة**

المثال التالي يُزوّد HTML كسلسلة نصية ويُدرج الشرائح المُولدة عند فهرس المجموعة `1`. تمرير `False` يترك الشرائح الحالية دون تغيير باستثناء إزاحتها لإتاحة المساحة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    insert_index = 1
    html = "<html><body><h1>Quarterly update</h1><p>This content is inserted before the slide that was at index 1.</p></body></html>"
    inserted_slides = presentation.getSlides().insertFromHtml(insert_index, html, False)

    for slide in inserted_slides:
        print("Inserted slide index:", presentation.getSlides().indexOf(slide))

    presentation.save("presentation-with-inserted-html.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **البدء على شريحة موجودة**

المثال التالي يُزوّد HTML عبر تدفق. يحتفظ بشكل عنوان على الشريحة النموذجية الموجودة، يبدأ الاستيراد أسفل المنطقة المشغولة، ويسمح للجسم الطويل بالمتابعة إلى شرائح جديدة.

يتضمن HTML أيضًا عنوان صورة نسبي. يحصل [ExternalResourceResolver](https://reference.aspose.com/slides/python-java/aspose.slides/externalresourceresolver/) على المورد، بينما يُخبر الـ URI الأساسي المستورد كيفية حل `images/logo.png`. في هذا المثال، يُتوقع وجود الملف في `html-assets/images/logo.png`.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExternalResourceResolver, Presentation, SaveFormat, ShapeType
from java.io import ByteArrayInputStream

presentation = Presentation()
try:
    template_slide = presentation.getSlides().get_Item(0)
    header = template_slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 680, 60)
    header.getTextFrame().setText("Product roadmap")

    html_parts = ["<html><body><img src='images/logo.png' width='120' height='60'><h2>Roadmap details</h2>"]
    for item_index in range(1, 61):
        html_parts.append(f"<p style='font-size:24pt'>Roadmap item {item_index}: detailed implementation notes.</p>")
    html_parts.append("</body></html>")

    html = "".join(html_parts)
    html_data = html.encode("utf-8")
    resolver = ExternalResourceResolver()
    base_directory = Path("html-assets").resolve()
    base_uri = base_directory.as_uri() + "/"

    html_stream = ByteArrayInputStream(html_data)
    try:
        affected_slides = presentation.getSlides().insertFromHtml(0, html_stream, resolver, base_uri, True)
        for slide in affected_slides:
            print("Affected slide index:", presentation.getSlides().indexOf(slide))
    finally:
        html_stream.close()

    presentation.save("presentation-with-html-overflow.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}}يمكن لمحلل الموارد الخارجية غير المقيد قراءة موارد محلية أو شبكية مشار إليها من قبل HTML. بالنسبة للمدخلات غير الموثوقة، قُم بالتحقق وتنظيف عناوين URL للموارد وفقًا لقائمة السماح التي تُحدِّد المخططات، الأدلة، والمضيفين المسموح بها قبل استيراد HTML.{{% /alert %}}

## **الأسئلة الشائعة**

**هل يمكن لـ Aspose.Slides اكتشاف الجداول عند استيراد PDF؟**

نعم. أنشئ كائنًا من الفئة [PdfImportOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfimportoptions/)، استدعِ [setDetectTables](https://reference.aspose.com/slides/python-java/aspose.slides/pdfimportoptions/#setDetectTables) مع `True`، ومرّر الخيارات إلى [addFromPdf](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addFromPdf). تعتمد جودة التعرف على الجداول على بنية وتعقيد PDF المصدر.

{{% alert title="Note" color="info" %}}بعد استيراد HTML، يمكنك أيضًا تصدير الشرائح إلى [images](/slides/ar/python-java/convert-powerpoint-to-png/)، [TIFF](/slides/ar/python-java/convert-powerpoint-to-tiff/)، أو [SVG](/slides/ar/python-java/render-a-slide-as-an-svg-image/).{{% /alert %}}