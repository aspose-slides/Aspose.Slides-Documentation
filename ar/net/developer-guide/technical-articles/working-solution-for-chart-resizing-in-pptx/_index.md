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
description: "إصلاح إعادة تحجيم المخطط غير المتوقعة في ملفات PPTX عند استخدام كائنات OLE المضمنة من Excel مع Aspose.Slides for .NET. تعلم طريقتين مع الكود للحفاظ على تناسق الأحجام."
---

## **الخلفية**

تم ملاحظة أن المخططات في Excel المضمنة ككائنات OLE في عرض PowerPoint من خلال مكوّنات Aspose يتم تعديل حجمها إلى مقياس غير محدد بعد تنشيطها لأول مرة. يسبب هذا السلوك اختلافًا بصريًا واضحًا في العرض بين حالتي المخطط قبل وبعد التنشيط. قامت فريق Aspose بالتحقيق في المسألة بالتفصيل ووجد حلاً. تصف هذه المقالة أسباب المشكلة والحل المقابل.

في [المقال السابق](/slides/ar/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)، شرحنا كيفية إنشاء مخطط Excel باستخدام Aspose.Cells for .NET وتضمينه في عرض PowerPoint باستخدام Aspose.Slides for .NET. لمعالجة [مشكلة معاينة الكائن](/slides/ar/net/object-preview-issue-when-adding-oleobjectframe/)، قمنا بتعيين صورة المخطط إلى إطار كائن OLE الخاص بالمخطط. في العرض الناتج، عندما تنقر مزدوجًا على إطار كائن OLE الذي يعرض صورة المخطط، يتم تنشيط مخطط Excel. يمكن للمستخدمين النهائيين إجراء أي تغييرات يرغبون بها في مصنف Excel الأساسي ثم العودة إلى الشريحة المقابلة بالنقر خارج المصنف المنشط. يتغير حجم إطار كائن OLE عندما يعود المستخدم إلى الشريحة، وتختلف نسبة إعادة التحجيم بناءً على الأحجام الأصلية لكل من إطار كائن OLE ومصنف Excel المضمن.

## **سبب تغيير الحجم**

نظرًا لأن مصنف Excel له حجم نافذة خاص به، يحاول الحفاظ على حجمه الأصلي عند تنشيطه لأول مرة. ومع ذلك، فإن إطار كائن OLE له حجمه الخاص. وفقًا لمايكروسوفت، عندما يتم تنشيط مصنف Excel، تتفاوض Excel وPowerPoint على الحجم وتحافظ على النسب الصحيحة كجزء من عملية التضمين. بناءً على الاختلافات بين حجم نافذة Excel وحجم أو موضع إطار كائن OLE، يحدث تغيير في الحجم.

## **الحل العملي**

هناك سيناريوهان محتملان لإنشاء عروض PowerPoint باستخدام Aspose.Slides for .NET.

**السيناريو 1:** إنشاء عرض بناءً على قالب موجود.

**السيناريو 2:** إنشاء عرض من الصفر.

الحل الذي نقدمه هنا ينطبق على كلا السيناريوهين. أساس جميع نهج الحل هو نفسه: **يجب أن يتطابق حجم نافذة كائن OLE المضمّن مع إطار كائن OLE في شريحة PowerPoint**. سنناقش الآن النهجين لهذا الحل.

## **النهج الأول**

في هذا النهج، سنتعلم كيفية ضبط حجم نافذة مصنف Excel المضمّن بحيث يتطابق مع حجم إطار كائن OLE في شريحة PowerPoint.

**السيناريو 1**

نفترض أننا عرّفنا قالبًا ونريد إنشاء عروض بناءً عليه. افترض وجود شكل في الفهرس 2 بالقالب نرغب في وضع إطار OLE يحتوي على مصنف Excel مضمّن فيه. في هذا السيناريو، يكون حجم إطار كائن OLE مُعرّفًا مسبقًا—يتطابق مع حجم الشكل في الفهرس 2 بالقالب. كل ما علينا فعله هو تعيين حجم نافذة المصنف ليكون مساويًا لحجم ذلك الشكل. المقتطف البرمجي التالي يحقق ذلك:
```cs
// تعريف حجم المخطط مع النافذة. 
chart.SizeWithWindow = true;

// تعيين عرض نافذة المصنف بالبوصة (مقسوم على 72 لأن PowerPoint يستخدم 72 بكسل لكل بوصة).
workbook.Worksheets.WindowWidthInch = slide.Shapes[2].Width / 72f;

// تعيين ارتفاع نافذة المصنف بالبوصة.
workbook.Worksheets.WindowHeightInIn = slide.Shapes[2].Height / 72f;

// حفظ المصنف إلى تدفق الذاكرة.
MemoryStream workbookStream = workbook.SaveToStream();

// إنشاء إطار كائن OLE مع بيانات Excel المضمنة.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```


**السيناريو 2**

لنفترض أننا نريد إنشاء عرض من الصفر وإدراج إطار كائن OLE بأي حجم مع مصنف Excel مضمّن. في المقتطف البرمجي التالي، ننشئ إطار OLE بارتفاع 4 بوصات وعرض 9.5 بوصة عند x = 0.5 بوصة وy = 1 بوصة على الشريحة. ثم نضبط نافذة مصنف Excel لتكون بنفس الحجم—ارتفاع 4 بوصات وعرض 9.5 بوصة.
```cs
// الارتفاع المرغوب فيه.
int desiredHeight = 288; // 4 بوصة (4 * 72)

// العرض المرغوب فيه.
int desiredWidth = 684;//9.5 بوصة (9.5 * 72)

// تعريف حجم المخطط مع النافذة.
chart.SizeWithWindow = true;

// تعيين عرض نافذة المصنف بالبوصة.
workbook.Worksheets.WindowWidthInch = desiredWidth / 72f;

// تعيين ارتفاع نافذة المصنف بالبوصة.
workbook.Worksheets.WindowHeightInch = desiredHeight / 72f;

// حفظ المصنف إلى تدفق الذاكرة.
MemoryStream workbookStream = workbook.SaveToStream();

// إنشاء إطار كائن OLE مع بيانات Excel المضمنة.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```


## **النهج الثاني**

في هذا النهج، سنتعلم كيفية ضبط حجم المخطط في مصنف Excel المضمّن ليتطابق مع حجم إطار كائن OLE في شريحة PowerPoint. هذا النهج مفيد عندما يكون حجم المخطط معروفًا مسبقًا ولن يتغير.

**السيناريو 1**

نفترض أننا عرّفنا قالبًا ونريد إنشاء عروض بناءً عليه. افترض وجود شكل في الفهرس 2 بالقالب نعتزم وضع إطار OLE يحتوي على مصنف Excel مضمّن فيه. في هذا السيناريو، يكون حجم إطار OLE مُعرّفًا مسبقًا—متطابقًا مع حجم الشكل في الفهرس 2 بالقالب. كل ما علينا فعله هو تعيين حجم المخطط في المصنف ليكون مساويًا لحجم الشكل. المقتطف البرمجي التالي يحقق ذلك:
```cs
// تعريف حجم المخطط بدون نافذة.
chart.SizeWithWindow = false;

// تعيين عرض المخطط بالبكسل (ضرب في 96 لأن Excel يستخدم 96 بكسل لكل بوصة).    
chart.ChartObject.Width = (int)((slide.Shapes[2].Width / 72f) * 96f);

// تعيين ارتفاع المخطط بالبكسل.
chart.ChartObject.Height = (int)((slide.Shapes[2].Height / 72f) * 96f);

// تعريف حجم طباعة المخطط.
chart.PrintSize = PrintSizeType.Custom;

// حفظ المصنف إلى تدفق الذاكرة.
MemoryStream workbookStream = workbook.SaveToStream();

// إنشاء إطار كائن OLE مع بيانات Excel المضمنة.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```


**السيناريو 2**

نفترض أننا نريد إنشاء عرض من الصفر وإدراج إطار كائن OLE بأي حجم مع مصنف Excel مضمّن. في المقتطف البرمجي التالي، ننشئ إطار OLE بارتفاع 4 بوصات وعرض 9.5 بوصة على الشريحة عند x = 0.5 بوصة وy = 1 بوصة. كما نضبط حجم المخطط المقابل لنفس الأبعاد: ارتفاع 4 بوصات وعرض 9.5 بوصة.
```cs
 // الارتفاع المطلوب.
int desiredHeight = 288; // 4 بوصة (4 * 576)

 // العرض المطلوب.
int desiredWidth = 684; // 9.5 بوصة (9.5 * 576)

 // تعريف حجم المخطط بدون نافذة. 
chart.SizeWithWindow = false;

 // تعيين عرض المخطط بالبكسل.   
chart.ChartObject.Width = (int)((desiredWidth / 72f) * 96f);

 // تعيين ارتفاع المخطط بالبكسل.    
chart.ChartObject.Height = (int)((desiredHeight / 72f) * 96f);

 // حفظ المصنف إلى تدفق الذاكرة.
MemoryStream workbookStream = workbook.SaveToStream();

 // إنشاء إطار كائن OLE مع بيانات Excel المضمنة.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```


## **الخلاصة**

هناك نهجين لإصلاح مشكلة تغيير حجم المخطط. يعتمد اختيار النهج على المتطلبات وحالة الاستخدام. يعمل كلا النهجين بنفس الطريقة سواء تم إنشاء العروض من قالب أو من الصفر. أيضًا، لا توجد أي حدود لحجم إطار كائن OLE في هذا الحل.

## **الأسئلة الشائعة**

**لماذا يتغيّر حجم مخطط Excel المضمّن بعد تنشيطه في PowerPoint؟**  
يحدث ذلك لأن Excel يحاول استعادة حجم النافذة الأصلي عند التنشيط الأول، بينما يمتلك إطار كائن OLE في PowerPoint أبعادًا خاصة به. تتفاوض PowerPoint وExcel على الحجم للحفاظ على نسبة الأبعاد، مما قد يؤدي إلى تغيير الحجم.

**هل يمكن منع هذه المشكلة تمامًا؟**  
نعم. من خلال مطابقة حجم نافذة مصنف Excel أو حجم المخطط مع حجم إطار كائن OLE قبل التضمين، يمكنك الحفاظ على أحجام المخطط ثابتة.

**أي نهج يجب أن أختار، ضبط حجم نافذة المصنف أم ضبط حجم المخطط؟**  
استخدم **النهج 1 (حجم النافذة)** إذا كنت ترغب في الحفاظ على نسبة أبعاد المصنف وربما السماح بإعادة التحجيم لاحقًا.  
استخدم **النهج 2 (حجم المخطط)** إذا كانت أبعاد المخطط ثابتة ولن تتغير بعد التضمين.

**هل تعمل هذه الطرق مع العروض القائمة على القوالب والعروض الجديدة على حد سواء؟**  
نعم. كلا النهجين يعملان بنفس الطريقة للعروض التي تم إنشاؤها من القوالب أو من الصفر.

**هل هناك حد لحجم إطار كائن OLE؟**  
لا. يمكنك تعيين إطار OLE إلى أي حجم طالما أنه يتناسب مع حجم المصنف أو المخطط.

**هل يمكنني استخدام هذه الطرق مع المخططات التي تم إنشاؤها في برامج جداول بيانات أخرى؟**  
الأمثلة مصممة لمخططات Excel التي تم إنشاؤها باستخدام Aspose.Cells، لكن المبادئ تنطبق على برامج جداول البيانات المتوافقة مع OLE طالما تدعم خيارات التحجيم المماثلة.

## **الأقسام ذات الصلة**

- [Create Excel Charts and Embed Them as OLE Objects in Presentations](/slides/ar/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Update OLE Objects Automatically Using a PowerPoint Add-In](/slides/ar/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)