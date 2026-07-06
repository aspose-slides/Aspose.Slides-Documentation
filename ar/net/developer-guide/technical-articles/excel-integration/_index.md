---
title: دمج بيانات Excel في عروض PowerPoint التقديمية
linktitle: دمج Excel
type: docs
weight: 330
url: /ar/net/excel-integration/
keywords:
- Excel
- دفتر عمل
- قراءة Excel
- دمج Excel
- مصدر بيانات
- دمج البريد
- استيراد جدول
- Excel إلى PowerPoint
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "قراءة البيانات من دفاتر عمل Excel في Aspose.Slides باستخدام واجهة برمجة التطبيقات ExcelDataWorkbook. تحميل الأوراق والخلايا واستخدام القيم لإنشاء عروض PowerPoint التقديمية المدفوعة بالبيانات."
---
## **المقدمة**

تُعد عروض PowerPoint وسيلة قوية لعرض المعلومات والتواصل بها. غالبًا ما يتم استخدامها جنبًا إلى جنب مع دفاتر Excel، حيث يُعد Excel مصدرًا ممتازًا للبيانات المهيكلة ويتفوق PowerPoint في تصور تلك البيانات للجمهور.

هناك العديد من السيناريوهات العملية حيث يكون دمج Excel وPowerPoint ضروريًا: دمج البريد، تعبئة جداول البيانات، إنشاء شريحة واحدة لكل سجل بيانات (إنشاء شرائح دفعي)، إعداد مواد تدريبية، وتوحيد تقارير Excel متعددة في عرض تقديمي واحد، من بين أمور أخرى.

حتى الآن، كان تنفيذ مثل هذه الميزات باستخدام Aspose.Slides API يتطلب الاعتماد على حلول طرف ثالث مثل Aspose.Cells. بينما هذه الأدوات قوية، إلا أنها قد تكون معقدة ومكلفة للمستخدمين الذين يحتاجون فقط إلى وظيفة دمج بيانات أساسية.

## **كيف يعمل**

لتسهيل العمل مع بيانات Excel وجعله أكثر سلاسة، قدمت Aspose.Slides فئات جديدة لقراءة البيانات من دفاتر Excel واستيراد المحتوى إلى عرض تقديمي. تفتح هذه الميزة إمكانات قوية جديدة لمستخدمي API الذين يرغبون في الاستفادة من Excel كمصدر للبيانات ضمن سير عمل العروض التقديمية.

تم تصميم الوظيفة الجديدة للوصول إلى البيانات لأغراض عامة ولا يتم دمجها في نموذج كائن مستند العرض (DOM). وهذا يعني *أنها لا تسمح بتحرير أو حفظ ملفات Excel* — هدفها الوحيد هو فتح دفاتر العمل والتنقل داخل محتواها لاسترداد بيانات الخلايا.

في صلب هذه الميزة توجد الفئة الجديدة [ExcelDataWorkbook](https://reference.aspose.com/slides/ar/net/aspose.slides.excel/exceldataworkbook/). تسمح لك هذه الفئة بتحميل دفتر Excel من ملف محلي أو من تدفق. بمجرد التحميل، توفر عدة إصدارات للوظيفة [GetCell](https://reference.aspose.com/slides/ar/net/aspose.slides.excel/exceldataworkbook/getcell/) التي يمكنك استخدامها لاسترداد خلايا محددة وفقًا لموقعها (مثل مؤشرات الصف والعمود أو النطاقات المسماة).

كل استدعاء للوظيفة [GetCell](https://reference.aspose.com/slides/ar/net/aspose.slides.excel/exceldataworkbook/getcell/) يُرجع كائنًا من الفئة [ExcelDataCell](https://reference.aspose.com/slides/ar/net/aspose.slides.excel/exceldatacell/). يمثل هذا الكائن خلية واحدة في دفتر Excel ويمنحك الوصول إلى قيمتها بطريقة بسيطة وبديهية.

#### **استيراد مخطط Excel**

الخطوة التالية لتوسيع الوظيفة هي الفئة [ExcelWorkbookImporter](https://reference.aspose.com/slides/ar/net/aspose.slides.import/excelworkbookimporter/). توفر هذه الفئة المساعدة وظائف لاستيراد المحتوى من دفتر Excel إلى عرض تقديمي. تحتوي على عدة إصدارات للوظيفة [AddChartFromWorkbook](https://reference.aspose.com/slides/ar/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/) التي تساعدك على استخراج المخطط المحدد من دفتر Excel المحدد وإضافته إلى نهاية مجموعة الأشكال المحددة عند الإحداثيات المحددة.

#### **استيراد جدول Excel**

تحتوي الفئة [ExcelWorkbookImporter](https://reference.aspose.com/slides/ar/net/aspose.slides.import/excelworkbookimporter/) أيضًا على عدة إصدارات للوظيفة [AddTableFromWorkbook](https://reference.aspose.com/slides/ar/net/aspose.slides.import/excelworkbookimporter/addtablefromworkbook/) التي تسمح لك باستيراد نطاق خلايا محدد من ورقة عمل محددة وإضافته كجدول إلى نهاية مجموعة الأشكال المحددة عند الإحداثيات المحددة.

باختصار، هي واجهة برمجة تطبيقات خفيفة ومباشرة لقراءة بيانات Excel — بالضبط ما يحتاجه العديد من المطورين دون عبء مكتبة معالجة جداول البيانات الكاملة.

## **لنكتب الكود**

### **مثال سيناريو دمج البريد**

في المثال التالي، سنقوم بتنفيذ سيناريو دمج بريد بسيط عن طريق إنشاء عروض تقديمية متعددة استنادًا إلى البيانات المخزنة في دفتر Excel.

لبدء العمل، نحتاج إلى أمرين:
1. دفتر Excel يحتوي على البيانات

![مثال بيانات Excel](example1_image0.png)

2. قالب عرض PowerPoint

![مثال قالب PowerPoint](example1_image1.png)

```csharp
// تحميل دفتر عمل Excel ببيانات الموظفين.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// تحميل قالب العرض التقديمي.
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// التكرار عبر صفوف Excel (مع استثناء الرأس في الصف 0).
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // إنشاء عرض تقديمي جديد لكل سجل موظف.
    using Presentation employeePresentation = new Presentation();

    // إزالة الشريحة الفارغة الافتراضية.
    employeePresentation.Slides.RemoveAt(0);

    // استنساخ شريحة القالب إلى العرض التقديمي الجديد.
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // الحصول على الفقرات من الشكل المستهدف (يفترض استخدام الفهرس 1 للشكل).
    IParagraphCollection paragraphs = (slide.Shapes[1] as IAutoShape).TextFrame.Paragraphs;

    // استبدال الحاجز النصي بالبيانات من Excel.
    string employeeName = workbook.GetCell(worksheetIndex, rowIndex, 0).Value.ToString();
    IPortion namePortion = paragraphs[0].Portions[0];
    namePortion.Text = namePortion.Text.Replace("{{EmployeeName}}", employeeName);

    string department = workbook.GetCell(worksheetIndex, rowIndex, 1).Value.ToString();
    IPortion departmentPortion = paragraphs[1].Portions[0];
    departmentPortion.Text = departmentPortion.Text.Replace("{{Department}}", department);

    string yearsOfService = workbook.GetCell(worksheetIndex, rowIndex, 2).Value.ToString();
    IPortion yearsPortion = paragraphs[2].Portions[0];
    yearsPortion.Text = yearsPortion.Text.Replace("{{YearsOfService}}", yearsOfService);

    // حفظ العرض التقديمي المخصص إلى ملف منفصل.
    employeePresentation.Save($"{employeeName} Report.pptx", SaveFormat.Pptx);
}
```

![النتيجة](example1_image2.png)

### **مثال جدول Excel**

في المثال الثاني، نقوم ببساطة بنسخ البيانات من جدول Excel وعرضها على شريحة PowerPoint بتنسيق أكثر جاذبية بصريًا.

في هذا المثال، نعيد استخدام نفس دفتر Excel من المثال الأول، والذي يحتوي على جدول موظفين بسيط.

```csharp
// تحميل دفتر عمل Excel الذي يحتوي على بيانات الموظف.
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

// ملء جدول PowerPoint بالبيانات من دفتر عمل Excel.
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

في هذا المثال، نستورد مخططًا من الورقة الأولى لدفتر Excel المستخدم في المثال السابق. سيُربط المخطط بالدفتر الخارجي في العرض التقديمي الناتج.

أولًا، نضيف مخططًا دائريًا إلى دفتر Excel استنادًا إلى جدول الموظفين.

![مثال مخطط Excel](example3_image0.png)

```csharp
// إنشاء عرض PowerPoint جديد.
using Presentation presentation = new Presentation();

// الحصول على مجموعة الأشكال للشريحة الأولى.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// استيراد المخطط المسمى "Chart 1" من الورقة الأولى في دفتر العمل وإضافته إلى مجموعة الأشكال.
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// حفظ العرض الناتج إلى ملف.
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![النتيجة](example3_image1.png)

### **مثال استيراد جميع مخططات Excel**

تخيل أن لديك دفتر Excel مليئًا بالمخططات وتحتاج إلى استيرادها جميعًا إلى عرض تقديمي. يجب وضع كل مخطط في شريحة جديدة.

الكود التالي يتنقل عبر جميع أوراق العمل في ملف Excel المصدر، يستخرج المخططات من كل ورقة، ويضيف كل مخطط إلى شريحة منفصلة باستخدام تخطيط شريحة فارغة. في العرض التقديمي الناتج، سيتم تضمين بيانات المخطط فقط، وليس دفتر Excel بالكامل.

```csharp
// تحميل دفتر عمل Excel الذي يحتوي على بيانات الموظف.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// إنشاء عرض PowerPoint جديد.
using Presentation presentation = new Presentation();

// استرجاع تخطيط الشريحة الفارغة.
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// الحصول على أسماء جميع أوراق العمل الموجودة في دفتر Excel.
IList<string> worksheetNames = workbook.GetWorksheetNames();

foreach (var name in worksheetNames)
{
    // استرجاع قاموس يربط فهارس المخططات بأسمائها لورقة العمل.
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // إضافة شريحة جديدة باستخدام تخطيط فارغ.
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // استيراد المخطط المحدد من دفتر Excel إلى مجموعة أشكال الشريحة.
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// حفظ العرض الناتج إلى ملف.
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

### **مثال استيراد جدول Excel**

في هذا المثال، نستورد جدولًا منسقًا من ورقة عمل Excel مباشرةً إلى عرض PowerPoint.

ورقة عمل Excel المصدر تحتوي على جدول منسق ببيانات الموظفين:

![مثال جدول Excel](example4_image0.png)

```csharp
// إنشاء عرض PowerPoint جديد.
using Presentation presentation = new Presentation();

// الحصول على مجموعة الأشكال للشريحة الأولى.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// استيراد الجدول من الورقة الأولى في دفتر العمل وإضافته إلى مجموعة الأشكال.
ExcelWorkbookImporter.AddTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5");

// حفظ العرض الناتج إلى ملف.
presentation.Save("FormattedTable.pptx", SaveFormat.Pptx);
```

![النتيجة](example4_image1.png)

## **الملخص**

هذه الآلية، المتاحة مباشرةً في Aspose.Slides، تجمع بين العمل ببيانات Excel والعروض التقديمية في مكان واحد. تسمح لك بإنشاء شرائح تحتوي على مخططات بصرية وبيانات مُقدمة كجداول Excel — دون الحاجة إلى مكتبات إضافية أو عمليات تكامل معقدة.