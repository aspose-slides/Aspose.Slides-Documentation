---
title: حل عملي لتغيير حجم المخططات في PPTX
type: docs
weight: 60
url: /net/working-solution-for-chart-resizing-in-pptx/
---

{{% alert color="primary" %}} 

لقد لوحظ أن المخططات المضمنة في Excel كأمانة OLE في عرض تقديمي للـ PowerPoint من خلال مكونات Aspose تُعاد تشكيلها إلى مقياس غير محدد بعد تفعيلها لأول مرة. هذه السلوكيات تخلق فرقًا مرئيًا كبيرًا في العرض التقديمي بين حالات تفعيل المخطط وما قبلها. قامت فريق Aspose بمساعدة فريق Microsoft بالتحقيق في هذه القضية بالتفصيل ووجدت حلاً لهذه المشكلة. تتناول هذه المقالة الأسباب والحل لهذه القضية. 

{{% /alert %}} 
## **الخلفية**
في [المقالة السابقة](/slides/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) ، قمنا بشرح كيفية إنشاء مخطط Excel باستخدام Aspose.Cells لـ .NET ومن ثم تضمين هذا المخطط في عرض PowerPoint باستخدام Aspose.Slides لـ .NET. من أجل استيعاب [مشكلة تغيير الكائن](/slides/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/) ، قمنا بتعيين صورة المخطط إلى إطار كائن OLE. في العرض التقديمي الناتج، عندما نضغط مرتين على إطار الكائن OLE الذي يظهر صورة المخطط، يتم تفعيل مخطط Excel. يمكن للمستخدمين النهائيين إجراء أي تغييرات يريدونها في دفتر العمل الفعلي لـ Excel ثم العودة إلى الشريحة المعنية من خلال النقر خارج دفتر العمل المفعّل. سيتغير حجم إطار الكائن OLE عندما يعود المستخدم إلى الشريحة. ستكون نسبة التغيير مختلفة لأحجام مختلفة من إطار الكائن OLE ودفتر عمل Excel المضمن. 
## **سبب تغيير الحجم**
بما أن دفتر عمل Excel له حجمه الخاص، فإنه يحاول الاحتفاظ بحجمه الأصلي عند التفعيل لأول مرة. من ناحية أخرى، سيكون لإطار الكائن OLE حجمه الخاص. وفقًا لمايكروسوفت، عند تفعيل دفتر عمل Excel، تتفاوض Excel وPowerPoint على الحجم وتضمن أنه في النسب الصحيحة كجزء من عملية الإدماج. استنادًا إلى الفروقات في حجم Windows Excel وحجم / موضع إطار الكائن OLE، يحدث تغيير الحجم. 
## **الحل العملي**
هناك سيناريوهين ممكنين لإنشاء عروض PowerPoint باستخدام Aspose.Slides لـ .NET. 

**السيناريو 1:** إنشاء العرض التقديمي استنادًا إلى قالب موجود 

**السيناريو 2:** إنشاء العرض التقديمي من الصفر. 

الحل الذي سنقدمه هنا سيكون صالحًا لكلا السيناريوهين. ستكون قاعدة جميع أساليب الحل هي نفسها. أي: **يجب أن يكون حجم نافذة كائن OLE المضمن هو نفسه حجم إطار كائن OLE** **في شريحة PowerPoint**. الآن، سنناقش المنهجين لحل المشكلة. 
## **النهج الأول**
في هذا النهج، سنتعلم كيفية ضبط حجم نافذة دفتر عمل Excel المضمن بحيث يتساوى مع حجم إطار كائن OLE في شريحة PowerPoint. 

**السيناريو 1** 

لنفترض أننا قد عرّفنا قالبًا ونرغب في إنشاء العروض التقديمية استنادًا إلى هذا القالب. لنفترض أن هناك شكلًا ما في الفهرس 2 في القالب حيث نريد وضع إطار OLE يحمل دفتر عمل Excel المضمن. في هذا السيناريو، سيُعتبر حجم إطار الكائن OLE موحدًا مسبقًا (وهو حجم الشكل في الفهرس 2 في القالب). كل ما علينا فعله هو ضبط حجم نافذة دفتر العمل ليكون مساوياً لحجم الشكل. ستخدم كود المعالجة التالي هذا الغرض: 

```c#
//تحديد حجم المخطط مع النافذة 
chart.SizeWithWindow = true;

//ضبط عرض نافذة دفتر العمل بالبوصات (مقسمًا على 72 حيث تستخدم PowerPoint 
//72 بكسل / بوصة)
wb.Worksheets.WindowWidthInch = slide.Shapes[2].Width / 72f;

//ضبط ارتفاع نافذة دفتر العمل بالبوصات
wb.Worksheets.WindowHeightInch = slide.Shapes[2].Height / 72f;

//إنشاء MemoryStream
MemoryStream ms = wb.SaveToStream();

//إنشاء إطار كائن OLE مع Excel المضمن
Aspose.Slides.OleObjectFrame objFrame = slide.Shapes.AddOleObjectFrame(
				slide.Shapes[2].X,
				slide.Shapes[2].Y,
				slide.Shapes[2].Width,
				slide.Shapes[2].Height, "Excel.Sheet.8", ms.ToArray());
```

**السيناريو 2** 

لنقل أننا نريد إنشاء عرض تقديمي من الصفر ونتمنى أن يكون لدينا إطار كائن OLE بأي حجم مع دفتر عمل Excel المضمن. في كود المعالجة التالي، قمنا بإنشاء إطار كائن OLE بارتفاع 4 بوصة وعرض 9.5 بوصة في الشريحة عند المحور x=0.5 بوصة والمحور y=1 بوصة. علاوة على ذلك، قمنا بضبط حجم نافذة دفتر عمل Excel المقابل، أي: الارتفاع 4 بوصة والعرض 9.5 بوصة. 

```c#
 //ارتفاعنا المرغوب
int desiredHeight = 288;//4 بوصة (4 * 72)

//عرضنا المرغوب
int desiredWidth = 684;//9.5 بوصة (9.5 * 72)

//تحديد حجم المخطط مع النافذة
chart.SizeWithWindow = true;

//ضبط عرض نافذة دفتر العمل بالبوصات
wb.Worksheets.WindowWidthInch = desiredWidth / 72f;

//ضبط ارتفاع نافذة دفتر العمل بالبوصات
wb.Worksheets.WindowHeightInch = desiredHeight / 72f;

//إنشاء MemoryStream
MemoryStream ms = wb.SaveToStream();

//إنشاء إطار كائن OLE مع Excel المضمن
Aspose.Slides.OleObjectFrame objFrame = slide.Shapes.AddOleObjectFrame(
							36,
							72,
							desiredWidth,
							desiredHeight, "Excel.Sheet.8", ms.ToArray());
```



## **النهج الثاني**
في هذا النهج، سنتعلم كيفية ضبط حجم المخطط الموجود في دفتر عمل Excel المضمن بحيث يتساوى مع حجم إطار كائن OLE في شريحة PowerPoint. يُعتبر هذا النهج مفيدًا عندما يكون حجم المخطط معروفًا مسبقًا ولن يتغير أبدًا. 

**السيناريو 1** 

لنفترض أننا قد عرّفنا قالبًا ونرغب في إنشاء العروض التقديمية استنادًا إلى هذا القالب. لنفترض أن هناك شكلًا ما في الفهرس 2 في القالب حيث نريد وضع إطار OLE يحمل دفتر عمل Excel المضمن. في هذا السيناريو، سيُعتبر حجم إطار OLE موحدًا مسبقًا (وهو حجم الشكل في الفهرس 2 في القالب). كل ما علينا فعله هو ضبط حجم المخطط في دفتر العمل ليكون مساوياً لحجم الشكل. ستخدم كود المعالجة التالي هذا الغرض: 

```c#
//تحديد حجم المخطط بدون نافذة 
chart.SizeWithWindow = false;

//ضبط عرض المخطط بالبكسل (ضرب بـ 96 حيث تستخدم Excel 96 بكسل لكل بوصة)    
chart.ChartObject.Width = (int)((slide.Shapes[2].Width / 72f) * 96f);

//ضبط ارتفاع المخطط بالبكسل
chart.ChartObject.Height = (int)((slide.Shapes[2].Height / 72f) * 96f);

//تحديد حجم طباعة المخطط
chart.PrintSize = PrintSizeType.Custom;

//إنشاء MemoryStream
MemoryStream ms = wb.SaveToStream();

//إنشاء إطار كائن OLE مع Excel المضمن
Aspose.Slides.OleObjectFrame objFrame = slide.Shapes.AddOleObjectFrame(
				slide.Shapes[2].X,
				slide.Shapes[2].Y,
				slide.Shapes[2].Width,
				slide.Shapes[2].Height, "Excel.Sheet.8", ms.ToArray());

```




**السيناريو 2** 

لنقل أننا نريد إنشاء عرض تقديمي من الصفر ونتمنى أن يكون لدينا إطار كائن OLE بأي حجم مع دفتر عمل Excel المضمن. في كود المعالجة التالي، قمنا بإنشاء إطار كائن OLE بارتفاع 4 بوصة وعرض 9.5 بوصة في الشريحة عند المحور x=0.5 بوصة والمحور y=1 بوصة. علاوة على ذلك، قمنا بضبط حجم المخطط المقابل، أي: الارتفاع 4 بوصة والعرض 9.5 بوصة. 

```c#
 //ارتفاعنا المرغوب
int desiredHeight = 288;//4 بوصة (4 * 576)

//عرضنا المرغوب
int desiredWidth = 684;//9.5 بوصة (9.5 * 576)

//تحديد حجم المخطط بدون نافذة 
chart.SizeWithWindow = false;

//ضبط عرض المخطط بالبكسل    
chart.ChartObject.Width = (int)((desiredWidth / 72f) * 96f);

//ضبط ارتفاع المخطط بالبكسل    
chart.ChartObject.Height = (int)((desiredHeight / 72f) * 96f);

//إنشاء MemoryStream
MemoryStream ms = wb.SaveToStream();

//إنشاء إطار كائن OLE مع Excel المضمن
Aspose.Slides.OleObjectFrame objFrame = slide.Shapes.AddOleObjectFrame(
							36,
							72,
							desiredWidth,
							desiredHeight, "Excel.Sheet.8", ms.ToArray());
```


## **الخاتمة**
{{% alert color="primary" %}} 

هناك نهجان لحل مشكلة تغيير حجم المخطط. تعتمد اختيار النهج المناسب على المتطلبات والحالة الاستخدامية. كلا النهجين يعملان بنفس الطريقة سواء كانت العروض التقديمية تم إنشاؤها من قالب أو تم إنشاؤها من الصفر. أيضًا، لا يوجد حد لحجم إطار الكائن OLE في الحل. 

{{% /alert %}} 
## **الأقسام ذات الصلة**
[إنشاء وتضمين مخطط Excel ككائن OLE في العرض التقديمي](/slides/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[تحديث كائنات OLE تلقائيًا](/slides/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)