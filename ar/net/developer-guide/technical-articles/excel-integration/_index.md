---
title: دمج بيانات إكسل في عروض PowerPoint التقديمية
linktitle: تكامل إكسل
type: docs
weight: 330
url: /ar/net/excel-integration/
keywords:
- إكسل
- مصنف
- قراءة إكسل
- دمج إكسل
- مصدر بيانات
- دمج بريد
- استيراد جدول
- إكسل إلى PowerPoint
- باوربوينت
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "قراءة البيانات من مصنفات إكسل في Aspose.Slides باستخدام واجهة برمجة التطبيقات ExcelDataWorkbook. تحميل الأوراق والخلايا واستخدام القيم لتوليد عروض PowerPoint التقديمية المدفوعة بالبيانات."
---

## **المقدمة**

تُعد عروض PowerPoint وسيلة قوية لعرض وتوصيل المعلومات. غالبًا ما تُستخدم بالترافق مع مصنفات Excel، حيث يُعتبر Excel مصدرًا ممتازًا للبيانات المهيكلة، وتتفوق PowerPoint في تصور تلك البيانات للجمهور.

هناك العديد من السيناريوهات العملية التي يكون فيها دمج Excel وPowerPoint ضروريًا: دمج البريد، ملء جداول البيانات، إنشاء شريحة واحدة لكل سجل بيانات (إنشاء شرائح دفعي)، إعداد مواد تدريبية، وتجميع تقارير Excel متعددة في عرض تقديمي واحد، من بين أمور أخرى.

حتى الآن، كان تنفيذ مثل هذه الميزات باستخدام Aspose.Slides API يتطلب الاعتماد على حلول طرف ثالث مثل Aspose.Cells. بالرغم من قوة هذه الأدوات، إلا أنها قد تكون معقدة ومكلفة للمستخدمين الذين يحتاجون فقط إلى وظائف تكامل بيانات أساسية.

## **كيفية العمل**

لتسهيل التعامل مع بيانات Excel وجعل العملية أكثر سلاسة، قدمت Aspose.Slides فئات جديدة لقراءة البيانات من مصنفات Excel واستيراد المحتوى إلى عرض تقديمي. تفتح هذه الميزة إمكانيات جديدة قوية لمستخدمي API الذين يرغبون في استغلال Excel كمصدر بيانات داخل سير عمل العروض التقديمية.

تم تصميم الوظيفة الجديدة للوصول العام إلى البيانات ولا تُدمج في نموذج كائن مستند العرض (DOM). وهذا يعني *أنها لا تسمح بتحرير أو حفظ ملفات Excel* — الهدف الوحيد هو فتح المصنفات والتنقل عبر محتواها لاسترجاع بيانات الخلايا.

في قلب هذه الميزة توجد الفئة الجديدة [ExcelDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.excel/exceldataworkbook/) . تسمح لك هذه الفئة بتحميل مصنف Excel من ملف محلي أو من تدفق. بمجرد التحميل، توفر عدة تراكمات لطريقة [GetCell](https://reference.aspose.com/slides/net/aspose.slides.excel/exceldataworkbook/getcell/) التي يمكنك استخدامها لاسترجاع خلايا محددة بناءً على موقعها (مثل فهارس الصف والعمود أو النطاقات المسماة).

كل استدعاء للطريقة [GetCell](https://reference.aspose.com/slides/net/aspose.slides.excel/exceldataworkbook/getcell/) يُعيد نسخة من فئة [ExcelDataCell](https://reference.aspose.com/slides/net/aspose.slides.excel/exceldatacell/) . يمثل هذا الكائن خلية واحدة في مصنف Excel ويمنحك وصولًا إلى قيمتها بطريقة بسيطة وبديهية.

#### **استيراد مخطط Excel**

الخطوة التالية لتوسيع الوظيفة هي الفئة [ExcelWorkbookImporter](https://reference.aspose.com/slides/net/aspose.slides.import/excelworkbookimporter/) . توفر هذه الفئة المساعدة وظائف لاستيراد المحتوى من مصنف Excel إلى عرض تقديمي. تحتوي على عدة تراكمات للطريقة [AddChartFromWorkbook](https://reference.aspose.com/slides/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/) التي تساعدك على استرجاع المخطط المحدد من مصنف Excel المحدد وإضافته إلى نهاية مجموعة الأشكال المحددة عند الإحداثيات المطلوبة.

باختصار، هي واجهة API خفيفة الوزن ومباشرة لقراءة بيانات Excel — بالضبط ما يحتاجه الكثير من المطورين دون عبء مكتبة معالجة جداول البيانات الكاملة.

## **لنكتب الشيفرة**

### **مثال سيناريو دمج البريد**

في المثال التالي، سنُنفّذ سيناريو دمج بريد بسيط عن طريق إنشاء عروض تقديمية متعددة بناءً على البيانات المخزنة في مصنف Excel.

لبدء العمل، نحتاج إلى شيئين:
1. مصنف Excel يحتوي على البيانات

![مثال بيانات Excel](example1_image0.png)

2. قالب عرض PowerPoint

![مثال قالب PowerPoint](example1_image1.png)
```csharp
// تحميل مصنف Excel ببيانات الموظفين.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// تحميل قالب العرض التقديمي.
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// تكرار صفوف Excel (باستثناء الرأس في الصف 0).
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // إنشاء عرض تقديمي جديد لكل سجل موظف.
    using Presentation employeePresentation = new Presentation();

    // إزالة الشريحة الفارغة الافتراضية.
    employeePresentation.Slides.RemoveAt(0);

    // استنساخ شريحة القالب إلى العرض التقديمي الجديد.
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // الحصول على الفقرات من الشكل المستهدف (يفترض أن مؤشر الشكل 1 مستخدم).
    IParagraphCollection paragraphs = (slide.Shapes[1] as IAutoShape).TextFrame.Paragraphs;

    // استبدال العناصر النائبة بالبيانات من Excel.
    string employeeName = workbook.GetCell(worksheetIndex, rowIndex, 0).Value.ToString();
    IPortion namePortion = paragraphs[0].Portions[0];
    namePortion.Text = namePortion.Text.Replace("{{EmployeeName}}", employeeName);

    string department = workbook.GetCell(worksheetIndex, rowIndex, 1).Value.ToString();
    IPortion departmentPortion = paragraphs[1].Portions[0];
    departmentPortion.Text = departmentPortion.Text.Replace("{{Department}}", department);

    string yearsOfService = workbook.GetCell(worksheetIndex, rowIndex, 2).Value.ToString();
    IPortion yearsPortion = paragraphs[2].Portions[0];
    yearsPortion.Text = yearsPortion.Text.Replace("{{YearsOfService}}", yearsOfService);

    // حفظ العرض التقديمي المخصص في ملف منفصل.
    employeePresentation.Save($"{employeeName} Report.pptx", SaveFormat.Pptx);
}
```


![النتيجة](example1_image2.png)

### **مثال جدول Excel**

في المثال الثاني، نقوم ببساطة بنسخ البيانات من جدول Excel وعرضها على شريحة PowerPoint بشكل أكثر جاذبية بصريًا.

في هذا المثال، نعيد استخدام نفس مصنف Excel من المثال الأول، الذي يحتوي على جدول موظفين بسيط.
```csharp
// تحميل مصنف Excel الذي يحتوي على بيانات الموظف.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// إنشاء عرض PowerPoint جديد.
using Presentation presentation = new Presentation();

// إضافة شكل جدول إلى الشريحة الأولى.
ITable table = presentation.Slides[0].Shapes.AddTable(
    50, 200,
    new double[] { 200, 200, 200 },
    new double[] { 30, 30, 30, 30, 30 }
);

// ملء جدول PowerPoint بالبيانات من مصنف Excel.
for (int rowIndex = 0; rowIndex < 5; rowIndex++)
{
    for (int columnIndex = 0; columnIndex < 3; columnIndex++)
    {
        string cellValue = workbook.GetCell(worksheetIndex, rowIndex, columnIndex).Value.ToString();
        table[columnIndex, rowIndex].TextFrame.Text = cellValue;
    }
}

// حفظ العرض الناتج إلى ملف.
presentation.Save("Table.pptx", SaveFormat.Pptx);
```


![النتيجة](example2_image0.png)

### **مثال استيراد مخطط Excel**

في هذا المثال، نستورد مخططًا من الورقة الأولى لمصنف Excel المستخدم في المثال السابق. سيرتبط المخطط بالمصنف الخارجي في العرض النهائي.

أولاً، نضيف مخطط فطيرة إلى مصنف Excel استنادًا إلى جدول الموظفين.

![مثال مخطط Excel](example3_image0.png)
```csharp
// إنشاء عرض PowerPoint جديد.
using Presentation presentation = new Presentation();

// الحصول على مجموعة الأشكال في الشريحة الأولى.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// استيراد المخطط المسمى "Chart 1" من الورقة الأولى للمصنف وإضافته إلى مجموعة الأشكال.
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// حفظ العرض التقديمي الناتج إلى ملف.
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```

![النتيجة](example3_image1.png)

### **مثال استيراد جميع مخططات Excel**

لنتخيل أن لديك مصنف Excel مليء بالمخططات وتحتاج إلى استيرادها جميعًا إلى عرض تقديمي. يجب وضع كل مخطط على شريحة جديدة.

يقوم الكود التالي بالتكرار عبر جميع الأوراق في ملف Excel المصدر، استخراج المخططات من كل ورقة، وإضافة كل مخطط إلى شريحة منفصلة باستخدام تخطيط شريحة فارغ. في العرض الناتج، سيتم تضمين بيانات المخطط فقط، دون تضمين المصنف بالكامل.
```csharp
// تحميل مصنف Excel الذي يحتوي على بيانات الموظف.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// إنشاء عرض PowerPoint جديد.
using Presentation presentation = new Presentation();

// استرجاع تخطيط الشريحة الفارغ.
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// الحصول على أسماء جميع أوراق العمل الموجودة في مصنف Excel.
IList<string> worksheetNames = workbook.GetWorksheetNames();
foreach (var name in worksheetNames)
{
    // استرجاع القاموس الذي يربط فهارس المخططات بأسمائها لورقة العمل.
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // إضافة شريحة جديدة باستخدام تخطيط فارغ.
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // استيراد المخطط المحدد من مصنف Excel إلى مجموعة أشكال الشريحة.
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// حفظ العرض الناتج إلى ملف.
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```


## **الملخص**

هذه الآلية، المتوفرة مباشرة في Aspose.Slides، تجمع بين العمل مع بيانات Excel والعروض التقديمية في مكان واحد. فهي تسمح لك بإنشاء شرائح بمخططات بصرية وبيانات تُعرض كجداول Excel — دون أي مكتبات إضافية أو تكاملات معقدة.