---
title: "أتمتة إنشاء عروض PowerPoint في C++: إنشاء عروض تقديمية ديناميكية بسهولة"
linktitle: أتمتة إنشاء عروض PowerPoint
type: docs
weight: 20
url: /ar/cpp/automating-powerpoint-generation-on-cloud-platforms/
keywords:
- منصات سحابية
- أتمتة إنشاء PowerPoint
- إنشاء عروض تقديمية برمجياً
- أتمتة PowerPoint
- إنشاء شرائح ديناميكية
- تقارير أعمال آلية
- أتمتة PPT
- عرض تقديمي C++
- C++
- Aspose.Slides
description: "أتمتة إنشاء الشرائح على منصات السحابة باستخدام Aspose.Slides لـ C++ — إنشاء، تحرير، وتحويل ملفات PowerPoint وOpenDocument بسرعة وموثوقية."
---

## **المقدمة**

إنشاء عروض PowerPoint يدويًا يمكن أن يكون مهمة تستغرق وقتًا طويلاً ومكرَّرة — خاصة عندما يكون المحتوى مبنيًا على بيانات ديناميكية تتغير باستمرار. سواء كان ذلك في توليد تقارير الأعمال الأسبوعية، أو تجميع المواد التعليمية، أو إنتاج عروض مبيعات جاهزة للعميل، يمكن للأتمتة أن توفر ساعات لا حصر لها وتضمن الاتساق عبر الفرق.

بالنسبة لمطوري C++، يفتح أتمتة إنشاء عروض PowerPoint إمكانيات قوية. يمكنك دمج توليد الشرائح في بوابات الويب، أدوات سطح المكتب، خدمات الخلفية، أو منصات السحابة لتحويل البيانات ديناميكيًا إلى عروض مهنية تحمل العلامة التجارية — حسب الطلب.

في هذه المقالة، سنستكشف الحالات الشائعة لإنشاء عروض PowerPoint تلقائيًا في تطبيقات C++ (بما في ذلك النشر على منصات السحابة) ولماذا يصبح هذا ميزة أساسية في الحلول الحديثة. من سحب بيانات الأعمال في الوقت الفعلي إلى تحويل النص أو الصور إلى شرائح، الهدف هو تحويل المحتوى الخام إلى صيغ مرئية منظمة يمكن لجمهورك فهمها فورًا.

## **الحالات الشائعة لاستخدام أتمتة PowerPoint في C++**

- **تقارير الأعمال ولوحات التحكم**  
  توليد ملخصات المبيعات، مؤشرات الأداء الرئيسية (KPIs)، أو تقارير الأداء المالي عن طريق سحب البيانات الحية من قواعد البيانات أو الواجهات البرمجية (APIs).

- **عروض مبيعات وتسويق مخصصة**  
  إنشاء عروض تقديمية مخصصة للعميل تلقائيًا باستخدام بيانات CRM أو نماذج الإدخال، مما يضمن سرعة الإنجاز واتساق العلامة التجارية.

- **المحتوى التعليمي**  
  تحويل المواد التعليمية، الاختبارات، أو ملخصات الدورات إلى مجموعات شرائح منظمة لمنصات التعلم الإلكتروني.

- **تحليلات مدعومة بالبيانات والذكاء الاصطناعي**  
  استخدام معالجة اللغة الطبيعية أو محركات التحليل لتحويل البيانات الخام أو النصوص الطويلة إلى عروض تقديمية مختصرة.

- **شرائح مستندة إلى الوسائط**  
  تجميع عروض من صور مرفوعة، لقطات شاشة مشروحة، أو إطارات مفتاحية من الفيديو مع أوصاف داعمة.

- **تحويل المستندات**  
  تحويل مستندات Word أو PDFs أو إدخالات النماذج إلى عروض مرئية تلقائيًا مع قليل من الجهد اليدوي.

- **أدوات المطورين والتقنية**  
  إنشاء عروض تجريبية تقنية، نظرات عامة على الوثائق، أو سجلات تغييرات بصيغة شرائح مباشرة من الكود أو محتوى markdown.

من خلال أتمتة هذه سير العمل، يمكن للمنظمات توسيع نطاق إنشاء المحتوى، الحفاظ على الاتساق، وتوفير الوقت للأنشطة الاستراتيجية.

## **لنكتب الشيفرة**

لهذا المثال، اخترنا **[Aspose.Slides for C++](https://products.aspose.com/slides/cpp/)** لعرض أتمتة PowerPoint بفضل مجموعة ميزاته الشاملة وسهولة الاستخدام عند التعامل مع العروض برمجيًا.

على عكس المكتبات منخفضة المستوى التي تتطلب من المطورين العمل مباشرةً مع بنية Open XML (مما ينتج عنه كود مطول وأقل قراءة)، توفر Aspose.Slides واجهة برمجة تطبيقات عالية المستوى. إنها تج abstracts away التعقيد، مما يسمح للمطورين بالتركيز على منطق العرض — مثل التخطيط، التنسيق، وربط البيانات — دون الحاجة لفهم تفاصيل تنسيق ملف PowerPoint.

على الرغم من أن Aspose.Slides مكتبة تجارية، إلا أنها تقدم نسخة [تجريبية مجانية](https://releases.aspose.com/slides/cpp/) يمكنها تشغيل الأمثلة الواردة في هذه المقالة بصورة كاملة. لأغراض عرض الأفكار، اختبار الميزات، أو بناء نموذج إثبات مفهوم كما نفعل هنا، تكون النسخة التجريبية كافية تمامًا. هذا يجعلها خيارًا مريحًا لتجربة أتمتة إنشاء عروض PowerPoint دون الحاجة إلى ترخيص مسبق.

حسنًا، لنستعرض بناء عرض تقديمي تجريبي باستخدام محتوى واقعي.

### **إنشاء شريحة عنوان**

سنبدأ بإنشاء عرض تقديمي جديد وإضافة شريحة عنوان تحتوي على عنوان رئيسي وعنوان فرعي.
```cpp
auto presentation = MakeObject<Presentation>();

auto slide0 = presentation->get_Slide(0);

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Title);
slide0->set_LayoutSlide(layoutSlide);

auto titleShape = ExplicitCast<IAutoShape>(slide0->get_Shape(0));
auto subtitleShape = ExplicitCast<IAutoShape>(slide0->get_Shape(1));

titleShape->get_TextFrame()->set_Text(u"Quarterly Business Review – Q1 2025");
subtitleShape->get_TextFrame()->set_Text(u"Prepared for Executive Team");
```


![شريحة العنوان](slide_0.png)

### **إضافة شريحة مع مخطط عمودي**

بعد ذلك، سننشئ شريحة تُظهر أداء المبيعات الإقليمي كمخطط عمودي.
```cpp
auto layoutSlide1 = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto slide1 = presentation->get_Slides()->AddEmptySlide(layoutSlide1);

auto chart = slide1->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100, 100, 500, 350, false);
chart->get_Legend()->set_Position(LegendPositionType::Bottom);
chart->set_HasTitle(true);
chart->get_ChartTitle()->AddTextFrameForOverriding(u"Data from January – March 2025");
chart->get_ChartTitle()->set_Overlay(false);

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheetIndex = 0;

chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"North America")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Europe")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Asia Pacific")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 4, 0, ObjectExt::Box<String>(u"Latin America")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 5, 0, ObjectExt::Box<String>(u"Middle East")));

auto series = chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Sales ($K)")), chart->get_Type());
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<int32_t>(480)));
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<int32_t>(365)));
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<int32_t>(290)));
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 4, 1, ObjectExt::Box<int32_t>(150)));
series->get_DataPoints()->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 5, 1, ObjectExt::Box<int32_t>(120)));
```


![الشريحة مع المخطط العمودي](slide_1.png)

### **إضافة شريحة مع جدول**

سنضيف الآن شريحة تعرض مؤشرات الأداء الرئيسية بصيغة جدول.
```cpp
auto layoutSlide2 = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto slide2 = presentation->get_Slides()->AddEmptySlide(layoutSlide2);

auto columnWidths = MakeArray<double>({ 200, 100 });
auto rowHeights = MakeArray<double>({ 40, 40, 40, 40, 40 });

auto table = slide2->get_Shapes()->AddTable(200, 200, columnWidths, rowHeights);
table->get_Column(0)->idx_get(0)->get_TextFrame()->set_Text(u"Metric");
table->get_Column(1)->idx_get(0)->get_TextFrame()->set_Text(u"Value");
table->get_Column(0)->idx_get(1)->get_TextFrame()->set_Text(u"Total Revenue");
table->get_Column(1)->idx_get(1)->get_TextFrame()->set_Text(u"$1.4M");
table->get_Column(0)->idx_get(2)->get_TextFrame()->set_Text(u"Gross Margin");
table->get_Column(1)->idx_get(2)->get_TextFrame()->set_Text(u"54%");
table->get_Column(0)->idx_get(3)->get_TextFrame()->set_Text(u"New Customers");
table->get_Column(1)->idx_get(3)->get_TextFrame()->set_Text(u"340");
table->get_Column(0)->idx_get(4)->get_TextFrame()->set_Text(u"Customer Retention");
table->get_Column(1)->idx_get(4)->get_TextFrame()->set_Text(u"87%");
```


![الشريحة مع الجدول](slide_2.png)

### **إضافة شريحة ملخص بنقاط تعداد**

أخيرًا، سندرج ملخصًا وخطة عمل باستخدام قائمة تعداد بسيطة.
```cpp
static SharedPtr<IParagraph> CreateBulletParagraph(String text) {
    auto paragraph = MakeObject<Paragraph>();
    paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
    paragraph->get_ParagraphFormat()->set_Indent(15);
    paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
    paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
    paragraph->set_Text(text);
    return paragraph;
}
```

```cpp
auto layoutSlide3 = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
auto slide3 = presentation->get_Slides()->AddEmptySlide(layoutSlide3);

auto bulletList = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 50, 600, 200);
bulletList->get_FillFormat()->set_FillType(FillType::NoFill);
bulletList->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

bulletList->get_TextFrame()->get_Paragraphs()->Clear();
bulletList->get_TextFrame()->get_Paragraphs()->Add(CreateBulletParagraph(u"Strong performance in North America; growth opportunity in Asia Pacific"));
bulletList->get_TextFrame()->get_Paragraphs()->Add(CreateBulletParagraph(u"Improve marketing outreach in underperforming regions"));
bulletList->get_TextFrame()->get_Paragraphs()->Add(CreateBulletParagraph(u"Prepare new campaign strategy for Q2"));
bulletList->get_TextFrame()->get_Paragraphs()->Add(CreateBulletParagraph(u"Schedule follow-up review in early July"));
```


![الشريحة مع النص](slide_3.png)

### **حفظ العرض التقديمي**

أخيرًا، نقوم بحفظ العرض التقديمي على القرص:
```java
presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
```


## **الخاتمة**

توفر أتمتة إنشاء عروض PowerPoint في تطبيقات C++ فوائد واضحة في توفير الوقت وتقليل الجهد اليدوي. من خلال دمج محتوى ديناميكي مثل المخططات، الجداول، والنصوص، يمكن للمطورين إنتاج عروض تقديمية متسقة ومهنية بسرعة — مثالية لتقارير الأعمال، اجتماعات العملاء، أو المحتوى التعليمي.

في هذه المقالة، عرضنا كيفية أتمتة إنشاء عرض تقديمي من الصفر، بما في ذلك إضافة شريحة عنوان، مخططات، وجداول. يمكن تطبيق هذه الطريقة على مختلف الحالات التي تتطلب عروضًا تقديمية مدفوعة بالبيانات.

باستخدام الأدوات المناسبة، يمكن لمطوري C++ أتمتة إنشاء عروض PowerPoint بفعالية، مما يعزز الإنتاجية ويضمن الاتساق عبر جميع العروض.