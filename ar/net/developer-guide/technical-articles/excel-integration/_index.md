---
title: دمج بيانات Excel في عروض PowerPoint التقديمية
linktitle: تكامل Excel
type: docs
weight: 330
url: /ar/net/excel-integration/
aliases:
  - /net/developer-guide/technical-articles/excel-integration/
keywords:
- Excel
- مصنف
- قراءة Excel
- دمج Excel
- مصدر البيانات
- دمج بريد
- استيراد جدول
- Excel إلى PowerPoint
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "قراءة البيانات من مصنفات Excel في Aspose.Slides باستخدام واجهة برمجة التطبيقات ExcelDataWorkbook. تحميل الأوراق والخلايا واستخدام القيم لإنشاء عروض PowerPoint التقديمية المستندة إلى البيانات."
---
## **المقدمة**

عرض PowerPoint طريقة قوية لعرض وتواصل المعلومات. يُستخدم غالبًا مع ملفات Excel حيث يُعد Excel مصدرًا ممتازًا للبيانات المهيكلة ويبرع PowerPoint في تصور هذه البيانات للجمهور.

هناك العديد من السيناريوهات العملية التي يكون فيها الجمع بين Excel وPowerPoint ضروريًا: دمج البريد، تعبئة جداول البيانات، إنشاء شريحة واحدة لكل سجل بيانات (إنشاء شرائح دفعي)، إعداد مواد تدريبية، وتوحيد تقارير Excel المتعددة في عرض تقديمي واحد، وغيرها.

حتى الآن، كان تنفيذ مثل هذه الميزات باستخدام Aspose.Slides API يتطلب الاعتماد على حلول من طرف ثالث مثل Aspose.Cells. رغم أن هذه الأدوات قوية، إلا أنها قد تكون معقدة ومكلفة للمستخدمين الذين يحتاجون فقط إلى وظائف أساسية لدمج البيانات.

## **كيفية العمل**

لتسهيل العمل مع بيانات Excel وجعله أكثر سلاسة، أضاف Aspose.Slides فئات جديدة لقراءة البيانات من ملفات Excel واستيراد المحتوى إلى عرض تقديمي. تفتح هذه الميزة إمكانيات جديدة قوية لمستخدمي الـ API الذين يرغبون في استخدام Excel كمصدر للبيانات ضمن سير عمل العروض التقديمية.

تم تصميم الوظيفة الجديدة للوصول العام إلى البيانات ولا تُدمج في نموذج كائن عرض المستند (DOM). وهذا يعني *أنها لا تسمح بتعديل أو حفظ ملفات Excel* — هدفها الوحيد هو فتح الملفات والتنقل بين محتواها لاسترجاع بيانات الخلايا.

في جوهر هذه الميزة توجد الفئة الجديدة [ExcelDataWorkbook](https://reference.aspose.com/slides/ar/net/aspose.slides.excel/exceldataworkbook/) . تتيح لك هذه الفئة تحميل ملف Workbook من ملف محلي أو تدفق. بعد التحميل، توفر عدة إصدارات من الطريقة [GetCell](https://reference.aspose.com/slides/ar/net/aspose.slides.excel/exceldataworkbook/getcell/) التي يمكنك استخدامها لاسترجاع خلايا محددة حسب موقعها (مثل فهرس الصف والعمود أو النطاقات المسماة).

كل استدعاء للطريقة [GetCell](https://reference.aspose.com/slides/ar/net/aspose.slides.excel/exceldataworkbook/getcell/) يُعيد مثالًا من الفئة [ExcelDataCell](https://reference.aspose.com/slides/ar/net/aspose.slides.excel/exceldatacell/) . يمثل هذا الكائن خلية واحدة في ملف Excel ويمنحك الوصول إلى قيمتها بطريقة بسيطة وبديهية.

#### **استيراد مخطط Excel**

الخطوة التالية لتوسيع الوظيفة هي الفئة [ExcelWorkbookImporter](https://reference.aspose.com/slides/ar/net/aspose.slides.import/excelworkbookimporter/) . توفر هذه الفئة المساعدة وظيفة استيراد المحتوى من ملف Excel إلى عرض تقديمي. تحتوي على عدة إصدارات من الطريقة [AddChartFromWorkbook](https://reference.aspose.com/slides/ar/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/) التي تساعدك على استرجاع المخطط المحدد من ملف Excel المحدد وإضافته إلى نهاية مجموعة الأشكال المحددة عند الإحداثيات المطلوبة.

#### **استيراد جدول Excel**

الفئة [ExcelWorkbookImporter](https://reference.aspose.com/slides/ar/net/aspose.slides.import/excelworkbookimporter/) تحتوي أيضًا على عدة إصدارات من الطريقة [AddTableFromWorkbook](https://reference.aspose.com/slides/ar/net/aspose.slides.import/excelworkbookimporter/addtablefromworkbook/) . تُتيح لك هذه الطريقة استيراد نطاق خلايا محدد من ورقة عمل معينة وإضافته كجدول إلى نهاية مجموعة الأشكال المحددة عند الإحداثيات المطلوبة.

باختصار، إنها واجهة برمجة تطبيقات خفيفة وبسيطة لقراءة بيانات Excel — بالضبط ما يحتاجه الكثير من المطورين دون عبء مكتبة معالجة جداول البيانات الكاملة.

## **لنبرمج**

### **مثال سيناريو دمج البريد**

في المثال التالي، سنُنفّذ سيناريو دمج بريد بسيط عن طريق إنشاء عروض تقديمية متعددة استنادًا إلى البيانات المخزنة في ملف Excel.

لبدء العمل، نحتاج إلى أمرين:
1. ملف Excel يحتوي على البيانات

![مثال على بيانات Excel](example1_image0.png)

2. قالب عرض PowerPoint

![مثال على قالب PowerPoint](example1_image1.png)

```csharp
// تحميل ملف Excel مع بيانات الموظفين.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// تحميل قالب العرض التقديمي.
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// التكرار عبر صفوف Excel (باستثناء العنوان في الصف 0).
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // إنشاء عرض تقديمي جديد لكل سجل موظف.
    using Presentation employeePresentation = new Presentation();

    // إزالة الشريحة الفارغة الافتراضية.
    employeePresentation.Slides.RemoveAt(0);

    // نسخ الشريحة القالب إلى العرض التقديمي الجديد.
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // الحصول على الفقرات من الشكل المستهدف (يفترض أن الفهرس 1 للشكل مستخدم).
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

    // حفظ العرض التقديمي المخصص إلى ملف منفصل.
    employeePresentation.Save($"{employeeName} Report.pptx", SaveFormat.Pptx);
}
```

![النتيجة](example1_image2.png)

### **مثال جدول Excel**

في المثال الثاني، نقوم ببساطة بنسخ بيانات من جدول Excel وعرضها على شريحة PowerPoint بصورة أكثر جاذبية بصريًا.

نستخدم في هذا المثال نفس ملف Excel من المثال الأول، والذي يحتوي على جدول موظفين بسيط.

```csharp
// تحميل ملف Excel الذي يحتوي على بيانات الموظفين.
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

// ملء جدول PowerPoint بالبيانات من ملف Excel.
for (int rowIndex = 0; rowIndex < 5; rowIndex++)
{
    for (int columnIndex = 0; columnIndex < 3; columnIndex++)
    {
        string cellValue = workbook.GetCell(worksheetIndex, rowIndex, columnIndex).Value.ToString();
        table[columnIndex, rowIndex].TextFrame.Text = cellValue;
    }
}

// حفظ العرض النهائي إلى ملف.
presentation.Save("Table.pptx", SaveFormat.Pptx);
```

![النتيجة](example2_image0.png)

### **مثال استيراد مخطط Excel**

في هذا المثال، نستورد مخططًا من الورقة الأولى لملف Excel المستخدم في المثال السابق. سيتصل المخطط بملف Excel الخارجي في العرض الناتج.

أولاً، نضيف مخططًا دائريًا إلى ملف Excel بناءً على جدول الموظفين.

![مثال على مخطط Excel](example3_image0.png)

```csharp
// إنشاء عرض PowerPoint جديد.
using Presentation presentation = new Presentation();

// الحصول على مجموعة الأشكال من الشريحة الأولى.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// استيراد المخطط المسمى "Chart 1" من الورقة الأولى في ملف المصنف وإضافته إلى مجموعة الأشكال.
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// حفظ العرض الناتج إلى ملف.
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![النتيجة](example3_image1.png)

### **مثال استيراد جميع مخططات Excel**

تخيل أن لديك ملف Excel مليئًا بالمخططات وتحتاج إلى استيرادها جميعًا إلى عرض تقديمي. يجب وضع كل مخطط على شريحة جديدة.

الكود التالي يمر على جميع أوراق العمل في ملف Excel المصدر، يستخرج المخططات من كل ورقة، ويضيف كل مخطط إلى شريحة منفصلة باستخدام تخطيط شريحة فارغة. في العرض الناتج، سيتم تضمين بيانات المخطط فقط، وليس ملف Excel بالكامل.

```csharp
// تحميل ملف Excel الذي يحتوي على بيانات الموظف.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// إنشاء عرض PowerPoint جديد.
using Presentation presentation = new Presentation();

// استرجاع تخطيط الشريحة الفارغة.
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// الحصول على أسماء جميع أوراق العمل الموجودة في ملف Excel.
IList<string> worksheetNames = workbook.GetWorksheetNames();

foreach (var name in worksheetNames)
{
    // استرجاع القاموس الذي يربط مؤشرات المخططات بأسمائها للورقة.
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // إضافة شريحة جديدة باستخدام التخطيط الفارغ.
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // استيراد المخطط المحدد من ملف Excel إلى مجموعة الأشكال في الشريحة.
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// حفظ العرض الناتج إلى ملف.
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

### **مثال استيراد جدول Excel**

في هذا المثال، نستورد جدولًا منسقًا من ورقة عمل Excel مباشرةً إلى عرض PowerPoint.

تحتوي ورقة Excel المصدر على جدول منسق ببيانات الموظفين:

![مثال على جدول Excel](example4_image0.png)

```csharp
// إنشاء عرض PowerPoint جديد.
using Presentation presentation = new Presentation();

// الحصول على مجموعة الأشكال من الشريحة الأولى.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// استيراد الجدول من الورقة الأولى في ملف المصنف وإضافته إلى مجموعة الأشكال.
ExcelWorkbookImporter.AddTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5");

// حفظ العرض الناتج إلى ملف.
presentation.Save("FormattedTable.pptx", SaveFormat.Pptx);
```

![النتيجة](example4_image1.png)


## **الملخص**

هذه الآلية، المتوفرة مباشرة في Aspose.Slides، تجمع بين العمل ببيانات Excel والعروض التقديمية في مكان واحد. تسمح لك بإنشاء شرائح تحتوي على مخططات بصرية وبيانات مقدمة كجداول Excel — دون الحاجة إلى مكتبات إضافية أو تكاملات معقدة.