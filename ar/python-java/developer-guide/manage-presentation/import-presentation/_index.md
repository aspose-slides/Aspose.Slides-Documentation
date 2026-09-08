---
title: استيراد العروض التقديمية من PDF أو HTML في Python عبر Java
linktitle: استيراد عرض تقديمي
type: docs
weight: 60
url: /ar/python-java/import-presentation/
keywords:
- استيراد عرض تقديمي
- استيراد شريحة
- استيراد PDF
- استيراد HTML
- PDF إلى عرض تقديمي
- PDF إلى PPT
- PDF إلى PPTX
- PDF إلى ODP
- HTML إلى عرض تقديمي
- HTML إلى PPT
- HTML إلى PPTX
- HTML إلى ODP
- PowerPoint
- OpenDocument
- Python
- Java
- Aspose.Slides
description: "تعرف على كيفية استيراد محتوى PDF وHTML إلى عروض PowerPoint في Python عبر Java باستخدام Aspose.Slides وحفظ النتائج كملفات PPTX."
---
## **المقدمة**

يمكن لـ Aspose.Slides for Python via Java تحويل صفحات PDF أو محتوى HTML إلى شرائح PowerPoint دون الحاجة إلى Microsoft PowerPoint. توفر فئة SlideCollection الطريقة addFromPdf والطريقة addFromHtml لإلحاق المحتوى المستورد بعرض تقديمي.

للحصول على مزيد من التحكم في وضع HTML، يمكن لـ SlideCollection.insertFromHtml إدراج الشرائح المُنشأة عند فهرس في المجموعة أو بدء ملء المساحة المتاحة على شريحة موجودة. يتم تقسيم HTML الطويل عبر شرائح إضافية تلقائيًا، ويمكن تزويد المصدر كسلسلة نصية أو تدفق، ويمكن تحميل الموارد الخارجية عبر ExternalResourceResolver باستخدام عنوان URI أساسي. تُعرّف المصفوفة Slide المرتجعة الشرائح المتأثرة والتي تم إنشاؤها حديثًا.

## **استيراد من PDF**

لتحويل مستند PDF إلى عرض تقديمي PowerPoint، استورد محتواه إلى مجموعة الشرائح واحفظ النتيجة كملف PPTX.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. إنشاء كائن Presentation جديد.
2. استدعاء addFromPdf مع مسار ملف PDF.
3. استدعاء save مع SaveFormat.Pptx لكتابة العرض التقديمي كملف PPTX.

المثال التالي بلغة Python يستورد مستند PDF ويحفظ الشرائح المُنشأة كعرض PowerPoint:

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

تظل الشريحة الفارغة الافتراضية في العرض التقديمي لأن الاستيراد يضيف شرائح. للاحتفاظ بالصفحات المستوردة فقط، امسح مجموعة الشرائح باستخدام SlideCollection.clear قبل الاستيراد.

طريقة addFromPdf تُعيد الشرائح التي تُضيفها، وهو مفيد عندما تحتاج إلى معالجة الشرائح المستوردة فقط.

{{% alert title="نصيحة" color="success" %}}
جرّب تطبيق الويب المجاني PDF to PowerPoint لترى سير عمل التحويل هذا عمليًا.
{{% /alert %}}

## **استيراد من HTML**

يمكن لـ Aspose.Slides أيضًا إنشاء شرائح من مستند HTML. يمكن توفير المصدر كنص HTML أو كتدفق. تستخدم الخطوات التالية تدفق ملف:

1. إنشاء كائن Presentation جديد.
2. فتح ملف HTML للقراءة وتمرير التدفق إلى addFromHtml.
3. استدعاء save مع SaveFormat.Pptx لكتابة النتيجة إلى ملف PPTX.

المثال التالي بلغة Python يستورد مستند HTML ويحفظ الشرائح المُنشأة كعرض PowerPoint:

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

استخدم SlideCollection.insertFromHtml عندما يجب وضع الشرائح المُنشأة من HTML في موضع محدد بدلاً من إلحاقها. الفهرس يبدأ من الصفر ويحدد الموضع الذي يبدأ منه الاستيراد.

المعطى `useSlideWithIndexAsStart` يتحكم في طريقة استخدام المستورد لهذا الموضع:

- عندما يكون `False`، يقوم المستورد بإنشاء شرائح جديدة عند الفهرس المحدد ويُحرك الشرائح التي تليه.
- عندما يكون `True`، يبدأ المستورد بوضع المحتوى في المساحة المتاحة على الشريحة الموجودة عند هذا الفهرس. إذا لم يتناسب HTML، يقوم Aspose.Slides بتقسيمه تلقائيًا ويُدرج شرائح إضافية مباشرةً بعد الشريحة البداية.

تُعيد SlideCollection.insertFromHtml مصفوفة من كائنات Slide. عندما يبدأ الإدراج على شرائح جديدة، يكون كل عنصر مُرجَع جديدًا. عندما تُستخدم شريحة موجودة كنقطة بداية، تشمل المصفوفة تلك الشريحة المتأثرة تليها أي شرائح إضافية زائدة. يمكنك فحص هذه المصفوفة بدلاً من حساب النطاق المتأثر من عدد شرائح العرض التقديمي.

### **إدراج HTML كشرائح جديدة**

المثال التالي يزود HTML كسلسلة نصية ويدرج الشرائح المُنشأة عند فهرس المجموعة `1`. تمرير `False` يترك الشرائح الموجودة دون تغيير باستثناء إزاحتها لإفساح المجال.

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

المثال التالي يزود HTML عبر تدفق. يحتفظ بشكل رأسية على شريحة القالب الموجودة، يبدأ الاستيراد أسفل المنطقة المشغولة، ويسمح للجسم الطويل بالمتابعة على شرائح جديدة.

يحتوي HTML أيضًا على عنوان URL لصورة نسبية. يقوم ExternalResourceResolver بالحصول على المورد، بينما يوضح URI الأساسي للمستورد كيفية حل `images/logo.png`. في هذا المثال، يُتوقع وجود هذا الملف في `html-assets/images/logo.png`.

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

{{% alert title="تحذير" color="warning" %}}
يمكن لمُحَلِّ الموارد الخارجية غير المقيد قراءة الموارد المحليّة أو الشبكية التي يُشار إليها في HTML. بالنسبة للمدخلات غير الموثوقة، يجب التحقق من صحة عناوين URL للموارد وتنظيفها مقابل قائمة مسموح بها من المخططات، الدلائل، والمضيفين قبل استيراد HTML.
{{% /alert %}}

## **الأسئلة الشائعة**

**هل يمكن لـ Aspose.Slides اكتشاف الجداول عند استيراد PDF؟**

نعم. أنشئ كائن PdfImportOptions، استدعِ setDetectTables مع `True`، ومرّر الخيارات إلى addFromPdf. تتوقف جودة تعرف الجداول على بنية وتعقيد ملف PDF المصدر.

{{% alert title="ملاحظة" color="info" %}}
بعد استيراد HTML، يمكنك أيضًا تصدير الشرائح إلى [images](/slides/ar/python-java/convert-powerpoint-to-png/)، [TIFF](/slides/ar/python-java/convert-powerpoint-to-tiff/)، أو [SVG](/slides/ar/python-java/render-slide-as-svg/).
{{% /alert %}}