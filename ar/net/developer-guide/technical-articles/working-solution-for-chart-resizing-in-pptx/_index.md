---
title: حل عملي لإعادة تحجيم المخطط في PPTX
type: docs
weight: 60
url: /ar/net/working-solution-for-chart-resizing-in-pptx/
keywords:
- إعادة تحجيم المخطط
- مخطط Excel
- كائن OLE
- تضمين المخطط
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إصلاح إعادة تحجيم المخطط غير المتوقعة في PPTX عند استخدام كائنات Excel OLE المدمجة مع Aspose.Slides لـ .NET. تعلم طريقتين مع الشيفرة للحفاظ على حجم المخطط ثابتًا."
---

## **الخلفية**

تم ملاحظة أن الرسوم البيانية في Excel المدمجة ككائنات OLE في عرض تقديمي PowerPoint عبر مكوّنات Aspose يتم تغيير حجمها إلى مقياس غير محدد بعد أول تفعيل لها. يتسبب هذا السلوك في اختلاف بصري ملحوظ في العرض بين حالتي ما قبل التفعيل وما بعده للرسوم البيانية. قامت فريق Aspose بالتحقيق في المشكلة بالتفصيل ووجد حلًا. يصف هذا المقال أسباب المشكلة والإصلاح المقابل.

في [المقال السابق](/slides/ar/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) شرحنا كيفية إنشاء رسم بياني في Excel باستخدام Aspose.Cells for .NET وتضمينه في عرض PowerPoint باستخدام Aspose.Slides for .NET. لمعالجة [مشكلة معاينة الكائن](/slides/ar/net/object-preview-issue-when-adding-oleobjectframe/) قمنا بإسناد صورة الرسم البياني إلى إطار كائن OLE للرسوم البيانية. في العرض الناتج، عندما تنقر مزدوجًا على إطار كائن OLE الذي يعرض صورة الرسم البياني، يتم تفعيل رسم Excel. يمكن للمستخدمين إجراء أي تغييرات مرغوبة في دفتر عمل Excel الأساسي ثم العودة إلى الشريحة المقابلة بالنقر خارج دفتر العمل المفعل. يتغير حجم إطار كائن OLE عندما يعود المستخدم إلى الشريحة، وتختلف نسبة إعادة الحجم اعتمادًا على الأحجام الأصلية لكل من إطار كائن OLE ودفتر عمل Excel المدمج.

## **سبب تغيير الحجم**

نظرًا لأن دفتر عمل Excel له حجم نافذة خاص به، فإنه يحاول الحفاظ على حجمه الأصلي عند التفعيل الأول. ومع ذلك، يمتلك إطار كائن OLE حجمه الخاص. وفقًا لمايكروسوفت، عندما يُفعَّل دفتر عمل Excel، تتفاوض Excel وPowerPoint على الحجم وتحتفظان بالنسب الصحيحة كجزء من عملية التضمين. بناءً على الفروقات بين حجم نافذة Excel وحجم أو موضع إطار كائن OLE، يحدث تغيير في الحجم.

## **الحل العملي**

هناك سيناريوهين محتملين لإنشاء عروض PowerPoint باستخدام Aspose.Slides for .NET.

**السيناريو 1:** إنشاء عرض بناءً على قالب موجود.

**السيناريو 2:** إنشاء عرض من الصفر.

الحل الذي نقدمه هنا ينطبق على كلا السيناريوهين. أساس جميع نهج الحل هو نفسه: **يجب أن يتطابق حجم نافذة كائن OLE المدمج مع إطار كائن OLE في شريحة PowerPoint**. سنناقش الآن النهجين لهذا الحل.

## **النهج الأول**

في هذا النهج، سنتعلم كيفية ضبط حجم نافذة دفتر عمل Excel المدمج ليطابق حجم إطار كائن OLE في شريحة PowerPoint.

**السيناريو 1**

افترض أننا عرّفنا قالبًا ونريد إنشاء عروض بناءً عليه. لنفترض وجود شكل في الفهرس 2 في القالب نريد وضع إطار OLE يحتوي على دفتر عمل Excel مدمج فيه. في هذا السيناريو، حجم إطار كائن OLE محدد مسبقًا—يتطابق مع حجم الشكل في الفهرس 2 في القالب. كل ما نحتاجه هو ضبط حجم نافذة دفتر العمل ليكون مساويًا لحجم ذلك الشكل. القطعة البرمجية التالية تحقق ذلك:
```cs
// تحديد حجم المخطط مع النافذة. 
// تحديد عرض نافذة دفتر العمل بالبوصة (مقسومًا على 72 لأن PowerPoint يستخدم 72 بكسل لكل بوصة).
// تحديد ارتفاع نافذة دفتر العمل بالبوصة.
// حفظ دفتر العمل إلى تدفق ذاكرة.
MemoryStream workbookStream = workbook.SaveToStream();

// Create an OLE object frame with the embedded Excel data.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```


**السيناريو 2**

لنفترض أننا نريد إنشاء عرض من الصفر وإدراج إطار OLE بأي حجم مع دفتر عمل Excel مدمج. في القطعة البرمجية التالية، ننشئ إطار OLE بارتفاع 4 بوصات وعرض 9.5 بوصة عند x = 0.5 بوصة و y = 1 بوصة على الشريحة. ثم نضبط نافذة دفتر عمل Excel ليكون لها نفس الحجم—ارتفاع 4 بوصات وعرض 9.5 بوصة.
```cs
// الارتفاع المطلوب.
int desiredHeight = 288; // 4 بوصة (4 * 72)

// العرض المطلوب.
int desiredWidth = 684; // 9.5 بوصة (9.5 * 72)

// تحديد حجم المخطط مع النافذة.
chart.SizeWithWindow = true;

// تعيين عرض نافذة دفتر العمل بالبوصة.
workbook.Worksheets.WindowWidthInch = desiredWidth / 72f;

// تعيين ارتفاع نافذة دفتر العمل بالبوصة.
workbook.Worksheets.WindowHeightInch = desiredHeight / 72f;

// حفظ دفتر العمل إلى تدفق الذاكرة.
MemoryStream workbookStream = workbook.SaveToStream();

// إنشاء إطار كائن OLE بالبيانات المدمجة من Excel.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
    "Excel.Sheet.8",
    workbookStream.ToArray());
```


## **النهج الثاني**

في هذا النهج، سنتعلم كيفية ضبط حجم الرسم البياني في دفتر عمل Excel المدمج ليطابق حجم إطار كائن OLE في شريحة PowerPoint. هذا النهج مفيد عندما يكون حجم الرسم البياني معروفًا مسبقًا ولن يتغير.

**السيناريو 1**

افترض أننا عرّفنا قالبًا ونريد إنشاء عروض بناءً عليه. لنفترض وجود شكل في الفهرس 2 في القالب نعتزم وضع إطار OLE يحتوي على دفتر عمل Excel مدمج فيه. في هذا السيناريو، حجم إطار OLE محدد مسبقًا—يتطابق مع حجم الشكل في الفهرس 2 في القالب. كل ما نحتاجه هو ضبط حجم الرسم البياني في دفتر العمل ليكون مساويًا لحجم الشكل. القطعة البرمجية التالية تحقق ذلك:
```cs
// تحديد حجم المخطط بدون نافذة. 
// تعيين عرض المخطط بوحدات البكسل (ضرب في 96 لأن Excel يستخدم 96 بكسل لكل بوصة).    
// تعيين ارتفاع المخطط بوحدات البكسل.
// تحديد حجم طباعة المخطط.
chart.SizeWithWindow = false;

// Set the chart width in pixels (multiply by 96 as Excel uses 96 pixels per inch).    
chart.ChartObject.Width = (int)((slide.Shapes[2].Width / 72f) * 96f);

// Set the chart height in pixels.
chart.ChartObject.Height = (int)((slide.Shapes[2].Height / 72f) * 96f);

// Define the chart print size.
chart.PrintSize = PrintSizeType.Custom;

// Save the workbook to a memory stream.
MemoryStream workbookStream = workbook.SaveToStream();

// Create an OLE object frame with the embedded Excel data.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```


**السيناريو 2**

لنفترض أننا نريد إنشاء عرض من الصفر وإدراج إطار OLE بأي حجم مع دفتر عمل Excel مدمج. في القطعة البرمجية التالية، ننشئ إطار OLE بارتفاع 4 بوصات وعرض 9.5 بوصة على الشريحة عند x = 0.5 بوصة و y = 1 بوصة. كما نضبط حجم الرسم البياني المقابل لنفس الأبعاد: ارتفاع 4 بوصات وعرض 9.5 بوصة.
```cs
 // الارتفاع المطلوب.
int desiredHeight = 288; // 4 بوصة (4 * 576)

// العرض المطلوب.
int desiredWidth = 684; // 9.5 بوصة (9.5 * 576)

// تحديد حجم المخطط بدون نافذة. 
chart.SizeWithWindow = false;

// تعيين عرض المخطط بوحدات البكسل.   
chart.ChartObject.Width = (int)((desiredWidth / 72f) * 96f);

// تعيين ارتفاع المخطط بوحدات البكسل.    
chart.ChartObject.Height = (int)((desiredHeight / 72f) * 96f);

// حفظ دفتر العمل إلى تدفق الذاكرة.
MemoryStream workbookStream = workbook.SaveToStream();

// Create an OLE object frame with the embedded Excel data.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```


## **الخاتمة**

هناك نهجان لحل مشكلة تغيير حجم الرسم البياني. يعتمد اختيار النهج على المتطلبات وحالة الاستخدام. كلا النهجين يعملان بنفس الطريقة سواء تم إنشاء العروض من قالب أو من الصفر. أيضًا، لا يوجد حد لحجم إطار كائن OLE في هذا الحل.

## الأسئلة المتداولة

**س: لماذا يتغير حجم الرسم البياني المدمج في Excel بعد تفعيله في PowerPoint؟**  
يحدث ذلك لأن Excel يحاول استعادة حجم النافذة الأصلي عند التفعيل الأول، بينما يمتلك إطار كائن OLE في PowerPoint أبعاده الخاصة. يتفاوض PowerPoint وExcel على الحجم للحفاظ على نسبة العرض إلى الارتفاع، مما قد يتسبب في تغيير الحجم.

**س: هل يمكن منع مشكلة تغيير الحجم تمامًا؟**  
نعم. من خلال مطابقة حجم نافذة دفتر عمل Excel أو حجم الرسم البياني مع حجم إطار كائن OLE قبل التضمين، يمكنك الحفاظ على أحجام الرسوم البيانية ثابتة.

**س: أي نهج يجب أن أختار، ضبط حجم نافذة دفتر العمل أم ضبط حجم الرسم البياني؟**  
استخدم **النهج 1 (حجم النافذة)** إذا رغبت في الحفاظ على نسبة أبعاد دفتر العمل وربما السماح بإعادة التحجيم لاحقًا.  
استخدم **النهج 2 (حجم الرسم البياني)** إذا كانت أبعاد الرسم البياني ثابتة ولن تتغير بعد التضمين.

**س: هل ستعمل هذه الطرق مع العروض القائمة على القوالب والعروض الجديدة؟**  
نعم. كلا النهجين يعملان بنفس الطريقة للعروض التي تم إنشاؤها من القوالب أو من الصفر.

**س: هل هناك حد لحجم إطار كائن OLE؟**  
لا. يمكنك ضبط إطار OLE إلى أي حجم طالما أنه يتناسب بشكل مناسب مع حجم دفتر العمل أو الرسم البياني.

**س: هل يمكنني استخدام هذه الطرق مع الرسوم البيانية التي تم إنشاؤها في برامج جداول أخرى؟**  
الأمثلة مصممة لرسوم Excel التي تم إنشاؤها باستخدام Aspose.Cells، لكن المبادئ تنطبق على برامج الجداول المتوافقة مع OLE طالما أنها تدعم خيارات حجم مماثلة.

## **الأقسام ذات الصلة**

- [إنشاء رسومات Excel وتضمينها ككائنات OLE في العروض](/slides/ar/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [تحديث كائنات OLE تلقائيًا باستخدام إضافة PowerPoint](/slides/ar/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)