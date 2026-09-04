---
title: "أتمتة إنشاء عروض PowerPoint في Python: إنشاء عروض تقديمية ديناميكية بسهولة"
linktitle: أتمتة إنشاء PowerPoint
type: docs
weight: 20
url: /ar/python-java/automating-powerpoint-generation-on-cloud-platforms/
keywords:
- منصات سحابية
- تكامل سحابي
- أتمتة إنشاء PowerPoint
- إنشاء عروض تقديمية برمجيًا
- أتمتة PowerPoint
- إنشاء شرائح ديناميكية
- تقارير أعمال مؤتمتة
- أتمتة PPT
- عرض بايثون
- بايثون
- Aspose.Slides
description: "أتمتة إنشاء PowerPoint باستخدام Aspose.Slides لـ Python عبر Java: إنشاء عرض تقديمي تجاري يحتوي على مخططات وجداول ونقاط تعداد في التطبيقات السحابية."
---
## **المقدمة**

إنشاء العروض التقديمية يدويًا يصبح روتينيًا عندما يتغير المحتوى بشكل متكرر. غالبًا ما تشترك التقارير الأسبوعية ومواد التدريب وعروض العملاء في بنية مشتركة ولكنها تحتاج إلى بيانات جديدة لكل مرة.

يتيح لك Aspose.Slides for Python via Java إنشاء هذه العروض التقديمية من تطبيقات Python. يمكنك دمج إنشاء الشرائح في بوابات الويب والوظائف المجدولة وعمال السحابة، باستخدام البيانات من قواعد البيانات أو واجهات برمجة التطبيقات أو الملفات التي تم تحميلها.

## **حالات الاستخدام الشائعة لأتمتة PowerPoint في Python**

- **تقارير الأعمال ولوحات التحكم:** تحويل أرقام المبيعات ومقاييس الأداء إلى مخططات وجداول.
- **عروض مبيعات مخصصة:** ملء الشرائح ببيانات خاصة بالعميل مع الحفاظ على تصميم موحد.
- **محتوى تعليمي:** تجميع الدروس والاختبارات وملخصات الدورات من مواد منظمة.
- **رؤى مدعومة بالبيانات والذكاء الاصطناعي:** استخدام نتائج التحليل أو خدمات المعالجة اللغوية كمحتوى للعرض.
- **شرائح تعتمد على الوسائط:** دمج الصور أو لقطات الشاشة المرفوعة مع نص توضيحي.
- **سير عمل المستندات:** تحويل المحتوى المستخرج من أدوات أخرى إلى تخطيطات العرض.
- **أدوات المطورين:** إنشاء ملخصات الإصدارات أو نظرات تقنية أو عروض توضيحية من بيانات المشروع.

## **المتطلبات المسبقة**

اتبع [Installation](/slides/ar/python-java/installation/) لإعداد Python وJava وJPype وAspose.Slides. للنشر على السحابة، راجع أيضًا [Slides on Cloud Platforms](/slides/ar/python-java/slides-on-cloud-platforms/).

يستخدم المثال بيانات عمل ثابتة بحيث يمكن تشغيله دون قاعدة بيانات أو خدمة خارجية. استبدل هذه القيم بالبيانات من تطبيقك عند دمجه في سير عمل التقرير.

{{% alert color="info" title="ملاحظة" %}}
يمكنك تجربة المثال بدون ترخيص، لكن مخرجات التقييم تشمل علامة مائية وتخضع لقيود التقييم. راجع [Evaluate Aspose.Slides](/slides/ar/python-java/evaluate-aspose-slides/) للحصول على التفاصيل ومعلومات الترخيص المؤقت.
{{% /alert %}}

## **إنشاء العرض التقديمي**

البرنامج الكامل أدناه ينشئ عرضًا تقديميًا واحدًا يحتوي على أربع شرائح. كل خطوة تستخدم نفس العرض، وتقوم الخطوة الأخيرة بحفظه باسم `presentation.pptx`.

### **إنشاء شريحة عنوان**

استخدم الشريحة الأولية في [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/) جديدًا وطبق تخطيط العنوان. املأ عناصر العنواوين والعناوين الفرعية بالعنوان الرئيسي للتقرير والجمهور.

![شريحة العنوان](slide_0.png)

### **إضافة شريحة مع مخطط عمودي**

أضف شريحة فارغة وأنشئ مخططًا باستخدام [ShapeCollection.addChart](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#addChart). املأ دفتر العمل المدمج بخمس مناطق وسلسلة مبيعات واحدة. تظل القيم قابلة للتعديل في PowerPoint.

![الشريحة مع المخطط](slide_1.png)

### **إضافة شريحة مع جدول**

أنشئ جدولًا باستخدام [ShapeCollection.addTable](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#addTable) واملأ عمودين بأسماء المقاييس والقيم. يمرر المثال مصفوفات Java صريحة من نوع double لأبعاد الأعمدة وارتفاعات الصفوف عبر JPype.

![الشريحة مع الجدول](slide_2.png)

### **إضافة شريحة ملخص بنقاط تعداد**

أنشئ شكل نصي وأضف [Paragraph](https://reference.aspose.com/slides/ar/python-java/aspose.slides/paragraph/) لكل عنصر عمل. طبّق تعداد رمزي ونصًا أسودًا لكل فقرة، وأزل تعبئة الشكل وحدوده.

![الشريحة مع الملخص](slide_3.png)

### **حفظ العرض التقديمي**

استخدم [Presentation.save](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#save) لكتابة ملف PowerPoint. حرّر العرض باستخدام [Presentation.dispose](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#dispose) داخل كتلة `finally`.

### **مثال Python كامل**

احفظ هذا البرنامج النصي في دليل قابل للكتابة وشغّله ببيئة Python التي تم تكوينها أعلاه. يبدأ JVM فقط إذا كان ضروريًا ويتركه متاحًا حتى انتهاء العملية. للاستخدام في الدفاتر والخدمات، راجع [JVM lifecycle guidance](/slides/ar/python-java/limitations-and-api-differences/#import-the-library).

```python
import jpype
import asposeslides
from jpype.types import JArray, JDouble

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, ChartType, FillType, LegendPositionType, Paragraph, Presentation, SaveFormat, ShapeType, SlideLayoutType
from java.awt import Color


def create_bullet_paragraph(text):
    paragraph = Paragraph()
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    paragraph.getParagraphFormat().setIndent(15)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText(text)
    return paragraph


presentation = Presentation()
try:
    # إنشاء شريحة العنوان.
    title_slide = presentation.getSlides().get_Item(0)
    title_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Title)
    title_slide.setLayoutSlide(title_layout)
    title_shape = title_slide.getShapes().get_Item(0)
    subtitle_shape = title_slide.getShapes().get_Item(1)
    title_shape.getTextFrame().setText("Quarterly Business Review – Q1 2025")
    subtitle_shape.getTextFrame().setText("Prepared for Executive Team")

    # إضافة شريحة مخطط.
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    chart_slide = presentation.getSlides().addEmptySlide(blank_layout)
    chart = chart_slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350, False)
    chart.getLegend().setPosition(LegendPositionType.Bottom)
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("Data from January – March 2025")
    chart.getChartTitle().setOverlay(False)

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    sales = [("North America", 480), ("Europe", 365), ("Asia Pacific", 290), ("Latin America", 150), ("Middle East", 120)]
    for row_index, (region, amount) in enumerate(sales, start=1):
        category_cell = workbook.getCell(worksheet_index, row_index, 0, region)
        chart.getChartData().getCategories().add(category_cell)

    series_cell = workbook.getCell(worksheet_index, 0, 1, "Sales ($K)")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())
    for row_index, (region, amount) in enumerate(sales, start=1):
        value_cell = workbook.getCell(worksheet_index, row_index, 1, JDouble(amount))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    # إضافة شريحة جدول.
    table_slide = presentation.getSlides().addEmptySlide(blank_layout)
    column_widths = JArray(JDouble)([200, 100])
    row_heights = JArray(JDouble)([40, 40, 40, 40, 40])
    table = table_slide.getShapes().addTable(200, 200, column_widths, row_heights)
    metrics = [("Metric", "Value"), ("Total Revenue", "$1.4M"), ("Gross Margin", "54%"), ("New Customers", "340"), ("Customer Retention", "87%")]
    for row_index, (metric, value) in enumerate(metrics):
        table.getColumns().get_Item(0).get_Item(row_index).getTextFrame().setText(metric)
        table.getColumns().get_Item(1).get_Item(row_index).getTextFrame().setText(value)

    # إضافة شريحة ملخص.
    summary_slide = presentation.getSlides().addEmptySlide(blank_layout)
    bullet_list = summary_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 50, 600, 200)
    bullet_list.getFillFormat().setFillType(FillType.NoFill)
    bullet_list.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    paragraphs = bullet_list.getTextFrame().getParagraphs()
    paragraphs.clear()
    action_items = ["Strong performance in North America; growth opportunity in Asia Pacific", "Improve marketing outreach in underperforming regions", "Prepare new campaign strategy for Q2", "Schedule follow-up review in early July"]
    for text in action_items:
        paragraph = create_bullet_paragraph(text)
        paragraphs.add(paragraph)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

تُظهر الرسومات الشرائح المقابلة من مثال Java. قد يختلف المظهر بناءً على الخطوط المثبتة ووضع التقييم.

## **استخدام المثال في تطبيق سحابي**

اجلب بيانات التقرير قبل بناء العرض، ثم مرّرها إلى خطوات المخطط والجدول وتوليد النص. استخدم مسار إخراج منفصل لكل وظيفة. بعد الحفظ، يمكن لتطبيقك تحميل الملف إلى تخزين كائنات أو إرجاعه كتحميل.

احرص على بقاء JVM يعمل عبر الوظائف داخل عملية العامل نفسها وحرّر كل عرض عند انتهاء مهمته. قم بتضمين الخطوط المطلوبة لتصميم تقريرك مع النشر لتقليل الاختلافات بين البيئات.

## **الخاتمة**

يولد هذا المثال عرضًا تجاريًا كاملاً من Python باستخدام مخططات وجداول ونصوص قابلة للتعديل. استبدال البيانات النموذجية ببيانات التطبيق يجعل هذا النهج مفيدًا للتقارير المتكررة وعروض العملاء والمواد التعليمية.

## **الأسئلة الشائعة**

**هل يتطلب البرنامج النصي Microsoft PowerPoint أو Excel؟**

لا. يقوم Aspose.Slides بإنشاء الشرائح ودفتر العمل المدمج للمخطط دون أيٍ من التطبيقين.

**لماذا يستخدم مثال الجدول مصفوفات Java؟**

الطريقة الأساسية تقبل مصفوفات من نوع Java double. تجعل المصفوفات الصريحة أنواع الأرقام الممررة عبر JPype واضحة.

**هل يمكنني حفظ نفس العرض كملف PDF أو ODP؟**

نعم. قبل تحريره، احفظه باسم ملف إخراج آخر باستخدام القيمة المقابلة لـ [SaveFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/saveformat/). راجع [Supported File Formats](/slides/ar/python-java/supported-file-formats/) للقدرات الخاصة بكل تنسيق.

**هل يمكنني استخدام قالب يحمل العلامة التجارية؟**

نعم. حمّل القالب الخاص بك بدلاً من إنشاء عرض تقديمي فارغ، ثم عدّل التخطيط واختيار عناصر العنواوين لتتناسب مع ذلك القالب. يفترض المثال أن تخطيطات وترتيب عناصر العنواوين هي لتقديم افتراضي جديد.