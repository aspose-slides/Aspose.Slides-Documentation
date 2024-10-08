---
title: تنسيق الأشكال
type: docs
weight: 20
url: /ar/net/shape-formatting/
keywords:
- تنسيق الشكل
- تنسيق الخطوط
- أنماط الانضمام للتنسيق
- تعبئة تدرج اللون
- تعبئة نمط
- تعبئة صورة
- تعبئة بلون ثابت
- تدوير الأشكال
- تأثيرات الحواف الثلاثية
- تأثير الدوران الثلاثي
- عرض PowerPoint
- C#
- Csharp
- Aspose.Slides لـ .NET
description: "تنسيق الشكل في عرض PowerPoint باستخدام C# أو .NET"
---

في PowerPoint، يمكنك إضافة أشكال إلى الشرائح. حيث أن الأشكال تتكون من خطوط، يمكنك تنسيق الأشكال عن طريق تعديل أو تطبيق تأثيرات معينة على خطوطها المكونة. بالإضافة إلى ذلك، يمكنك تنسيق الأشكال عن طريق تحديد إعدادات تحدد كيفية تعبئتها (المنطقة بداخلها).

![format-shape-powerpoint](format-shape-powerpoint.png)

**Aspose.Slides لـ .NET** يوفر واجهات وخصائص تتيح لك تنسيق الأشكال بناءً على الخيارات المعروفة في PowerPoint.

## **تنسيق الخطوط**

باستخدام Aspose.Slides، يمكنك تحديد نمط الخط المفضل لديك لشكل ما. توضح هذه الخطوات إجراءً مثل هذا:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) إلى الشريحة.
4. تعيين لون لخطوط الشكل.
5. تعيين عرض لخطوط الشكل.
6. تعيين [نمط الخط](https://reference.aspose.com/slides/net/aspose.slides/linestyle) لخط الشكل
7. تعيين [نمط الخط المكسور](http://aspose.com/api/net/slides/aspose.slides/linedashstyle) لخط الشكل.
8. كتابة العرض المعدل كملف PPTX.

هذا الكود C# يوضح عملية حيث قمنا بتنسيق مستطيل `AutoShape`:

```c#
// ينشئ مثيل لفئة العرض التي تمثل ملف العرض
using (Presentation pres = new Presentation())
{
    // يحصل على الشريحة الأولى
    ISlide sld = pres.Slides[0];

    // يضيف شكل تلقائي من نوع مستطيل
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // يحدد لون التعبئة لشكل المستطيل
    shp.FillFormat.FillType = FillType.Solid;
    shp.FillFormat.SolidFillColor.Color = Color.White;

    // يطبق بعض التنسيق على خطوط المستطيل
    shp.LineFormat.Style = LineStyle.ThickThin;
    shp.LineFormat.Width = 7;
    shp.LineFormat.DashStyle = LineDashStyle.Dash;

    // يحدد اللون لخط المستطيل
    shp.LineFormat.FillFormat.FillType = FillType.Solid;
    shp.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // يكتب ملف PPTX إلى القرص
    pres.Save("RectShpLn_out.pptx", SaveFormat.Pptx);
}
```

## **تنسيق أنماط الانضمام**
هذه هي خيارات نوع الانضمام الثلاثة:

* مستدير
* ملبس
* حواف مرتفعة

بشكل افتراضي، عندما ينضم PowerPoint إلى خطين بزاوية (أو زاوية شكل)، فإنه يستخدم إعداد **مستدير**. ومع ذلك، إذا كنت تبحث عن رسم شكل بزوايا حادة للغاية، قد ترغب في اختيار **ملبس**.

![join-style-powerpoint](join-style-powerpoint.png)

هذا الكود C# يوضح عملية حيث تم إنشاء 3 مستطيلات (الصورة أعلاه) مع إعدادات نوع الانضمام ملبس، حواف مرتفعة، ومستديرة:

```c#
// ينشئ مثيل لفئة العرض التي تمثل ملف العرض
using (Presentation pres = new Presentation())
{

	// يحصل على الشريحة الأولى
	ISlide sld = pres.Slides[0];

	// يضيف 3 أشكال تلقائية من نوع مستطيل
	IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 100, 150, 75);
	IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 300, 100, 150, 75);
	IShape shp3 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 250, 150, 75);

	// يحدد لون التعبئة لشكل المستطيل
	shp1.FillFormat.FillType = FillType.Solid;
	shp1.FillFormat.SolidFillColor.Color = Color.Black;
	shp2.FillFormat.FillType = FillType.Solid;
	shp2.FillFormat.SolidFillColor.Color = Color.Black;
	shp3.FillFormat.FillType = FillType.Solid;
	shp3.FillFormat.SolidFillColor.Color = Color.Black;

	// يحدد عرض الخط
	shp1.LineFormat.Width = 15;
	shp2.LineFormat.Width = 15;
	shp3.LineFormat.Width = 15;

	// يحدد اللون لخط المستطيل
	shp1.LineFormat.FillFormat.FillType = FillType.Solid;
	shp1.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
	shp2.LineFormat.FillFormat.FillType = FillType.Solid;
	shp2.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
	shp3.LineFormat.FillFormat.FillType = FillType.Solid;
	shp3.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

	// يحدد نمط الانضمام
	shp1.LineFormat.JoinStyle = LineJoinStyle.Miter;
	shp2.LineFormat.JoinStyle = LineJoinStyle.Bevel;
	shp3.LineFormat.JoinStyle = LineJoinStyle.Round;

	// يضيف نصًا إلى كل مستطيل
	((IAutoShape)shp1).TextFrame.Text = "نمط الانضمام ملبس";
	((IAutoShape)shp2).TextFrame.Text = "نمط الانضمام حواف مرتفعة";
	((IAutoShape)shp3).TextFrame.Text = "نمط الانضمام مستدير";

	// يكتب ملف PPTX إلى القرص
	pres.Save("RectShpLnJoin_out.pptx", SaveFormat.Pptx);
}
```

## **تعبئة تدرج اللون**
في PowerPoint، تعبئة تدرج اللون هي خيار تنسيق يتيح لك تطبيق مزيج مستمر من الألوان على شكل. على سبيل المثال، يمكنك تطبيق لونين أو أكثر في إعداد حيث يتلاشى لون واحد تدريجياً ويتحول إلى لون آخر.

هذه هي كيفية استخدام Aspose.Slides لتطبيق تعبئة تدرج اللون على شكل:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) إلى الشريحة.
4. تعيين [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype) للشكل إلى `تدرج`.
5. أضف لونين مفضلين لديك مع مواقع محددة باستخدام طرق `Add` المعروضة بواسطة مجموعة `GradientStops` المرتبطة بفئة `GradientFormat`.
6. كتابة العرض المعدل كملف PPTX.

هذا الكود C# يوضح عملية حيث استخدم تأثير تعبئة التدرج على شكل بيضاوي:

```c#
// ينشئ مثيل لفئة العرض التي تمثل ملف العرض
using (Presentation pres = new Presentation())
{
    // يحصل على الشريحة الأولى
    ISlide sld = pres.Slides[0];

    // يضيف شكل بيضاوي تلقائي
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 150, 75, 150);

    // يطبق التنسيق التدرجي على الشكل البيضاوي
    shp.FillFormat.FillType = FillType.Gradient;
    shp.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // يحدد اتجاه التدرج
    shp.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // أضف 2 نغمات التدرج
    shp.FillFormat.GradientFormat.GradientStops.Add((float)1.0, PresetColor.Purple);
    shp.FillFormat.GradientFormat.GradientStops.Add((float)0, PresetColor.Red);

    // يكتب ملف PPTX إلى القرص
    pres.Save("EllipseShpGrad_out.pptx", SaveFormat.Pptx);
}
```

## **تعبئة نمط**
في PowerPoint، تعبئة النمط هي خيار تنسيق يتيح لك تطبيق تصميم مكون من لونين يتضمن نقاط أو خطوط متقاطعة أو مربعات على شكل. بالإضافة إلى ذلك، يمكنك اختيار الألوان المفضلة لديك لواجهة النموذج وخلفيته.

يوفر Aspose.Slides أكثر من 45 نمطًا محددًا مسبقًا يمكن استخدامه لتنسيق الأشكال وتعزيز العروض. حتى بعد اختيار نمط محدد مسبقًا، لا يزال بإمكانك تحديد الألوان التي يجب أن يحتوي عليها النمط.

هذه هي كيفية استخدام Aspose.Slides لتطبيق تعبئة نمط على شكل:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) إلى الشريحة.
4. تعيين [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype) للشكل إلى `نمط`.
5. تعيين نمط النمط المفضل لديك للشكل.
6. تعيين [لون الخلفية](http://www.aspose.com/api/net/slides/aspose.slides/patternformat/properties/backcolor) لـ [PatternFormat](http://www.aspose.com/api/net/slides/aspose.slides/patternformat).
7. تعيين [لون الواجهة](http://www.aspose.com/api/net/slides/aspose.slides/patternformat/properties/forecolor) لـ [PatternFormat](http://www.aspose.com/api/net/slides/aspose.slides/patternformat).
8. كتابة العرض المعدل كملف PPTX.

هذا الكود C# يوضح عملية حيث تم استخدام تعبئة نمط لتجميل مستطيل:

```c#
// ينشئ مثيل لفئة العرض التي تمثل ملف العرض
using (Presentation pres = new Presentation())
{

    // يحصل على الشريحة الأولى
    ISlide sld = pres.Slides[0];

    // يضيف شكل مستطيل تلقائي
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // يحدد نوع التعبئة إلى نمط
    shp.FillFormat.FillType = FillType.Pattern;

    // يحدد نمط النمط
    shp.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // يحدد ألوان الخلفية والواجهة للنمط
    shp.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shp.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // يكتب ملف PPTX إلى القرص
    pres.Save("RectShpPatt_out.pptx", SaveFormat.Pptx);
}
```

## **تعبئة صورة**
في PowerPoint، تعبئة الصورة هي خيار تنسيق يتيح لك وضع صورة داخل شكل. بشكل أساسي، يمكنك استخدام صورة كخلفية لشكل.

هذه هي كيفية استخدام Aspose.Slides لتعبئة شكل بصورة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) إلى الشريحة.
4. تعيين [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype) للشكل إلى `صورة`.
5. تعيين وضع تعبئة الصورة إلى بلاط.
6. إنشاء كائن `IPPImage` باستخدام الصورة التي ستستخدم لتعبئة الشكل.
7. تعيين خاصية `Picture.Image` لكائن `PictureFillFormat` إلى `IPPImage` الذي تم إنشاؤه مؤخرًا.
8. كتابة العرض المعدل كملف PPTX.

هذا الكود C# يوضح لك كيفية تعبئة شكل بصورة:

```c#
// ينشئ مثيل من فئة العرض التي تمثل ملف العرض
using (Presentation presentation = new Presentation())
{
    // يحصل على الشريحة الأولى
    ISlide slide = presentation.Slides[0];

    // يضيف شكل مستطيل تلقائي
    IShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // يحدد نوع التعبئة إلى صورة
    shape.FillFormat.FillType = FillType.Picture;

    // يحدد وضع تعبئة الصورة
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // يحمل صورة ويضيفها إلى موارد العرض
    IImage image = Images.FromFile("Tulips.jpg");
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    // يحدد الصورة
    shape.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // يكتب ملف PPTX إلى القرص
    presentation.Save("RectShpPic_out.pptx", SaveFormat.Pptx);
}
```

## **تعبئة بلون ثابت**
في PowerPoint، تعبئة اللون الثابت هي خيار تنسيق يتيح لك تعبئة شكل بلون واحد. اللون المختار عادةً ما يكون لونًا عاديًا. يتم تطبيق اللون على خلفية الشكل مع أي تأثيرات أو تعديلات خاصة.

هذه هي كيفية استخدام Aspose.Slides لتطبيق تعبئة اللون الثابت على شكل:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) إلى الشريحة.
4. تعيين [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype) للشكل إلى `ثابت`.
5. تعيين اللون المفضل لديك للشكل.
6. كتابة العرض المعدل كملف PPTX.

هذا الكود C# يوضح لك كيفية تطبيق تعبئة اللون الثابت على مربع في PowerPoint:

```c#
// ينشئ مثيل من فئة العرض التي تمثل ملف العرض
using (Presentation presentation = new Presentation())
{

// يحصل على الشريحة الأولى
    ISlide slide = presentation.Slides[0];

// يضيف شكل مستطيل تلقائي
    IShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

// يحدد نوع التعبئة إلى ثابت
    shape.FillFormat.FillType = FillType.Solid;

// يحدد اللون للمستطيل
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

// يكتب ملف PPTX إلى القرص
    presentation.Save("RectShpSolid_out.pptx", SaveFormat.Pptx);
}
```

## **تعيين الشفافية**

في PowerPoint، عندما تقوم بتعبئة أشكال بالألوان الثابتة أو التدرجات أو الصور أو القوام، يمكنك تحديد مستوى الشفافية الذي يحدد درجة عتمة التعبئة. بهذه الطريقة، على سبيل المثال، إذا قمت بتعيين مستوى شفافية منخفض، فإن كائن الشريحة أو الخلفية خلف (الشكل) يظهر من خلاله.

تتيح لك Aspose.Slides تعيين مستوى الشفافية لشكل بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) إلى الشريحة.
4. استخدام `Color.FromArgb` مع ضبط مكون alpha.
5. حفظ الكائن كملف PowerPoint.

هذا الكود C# يوضح العملية:

```c#
// ينشئ مثيل من فئة العرض التي تمثل ملف العرض
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    
    // يضيف شكل ثابت
    IShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 75, 175, 75, 150);

    // يضيف شكلًا شفافًا فوق الشكل الثابت
    IShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.FromArgb(128, 204, 102, 0);
    
    // يكتب ملف PPTX إلى القرص
    presentation.Save("ShapeTransparentOverSolid_out.pptx", SaveFormat.Pptx);
}
```

## **تدوير الأشكال**
تتيح لك Aspose.Slides تدوير شكل تمت إضافته إلى شريحة بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) إلى الشريحة.
4. تدوير الشكل بالدرجات المطلوبة.
5. كتابة العرض المعدل كملف PPTX.

هذا الكود C# يوضح لك كيفية تدوير شكل بمقدار 90 درجة:

```c#
// ينشئ مثيل من فئة العرض التي تمثل ملف العرض
using (Presentation pres = new Presentation())
{
    // يحصل على الشريحة الأولى
    ISlide sld = pres.Slides[0];

    // يضيف شكل مستطيل تلقائي
    IShape shp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 75, 150);

    // يدور الشكل بمقدار 90 درجة
    shp.Rotation = 90;

    // يكتب ملف PPTX إلى القرص
    pres.Save("RectShpRot_out.pptx", SaveFormat.Pptx);
}
```

## **إضافة تأثيرات الحواف الثلاثية**
تتيح لك Aspose.Slides إضافة تأثيرات حواف ثلاثية إلى شكل عن طريق تعديل خصائص [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ThreeDFormat) بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) إلى الشريحة.
3. تعيين المعلمات المفضلة لديك لخصائص [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ThreeDFormat) للشكل.
4. كتابة العرض إلى القرص.

هذا الكود C# يوضح لك كيفية إضافة تأثيرات حواف ثلاثية إلى شكل:

```c#
// ينشئ مثيل من فئة العرض التي تمثل ملف العرض
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    
    // يضيف شكلاً إلى الشريحة
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 30, 30, 100, 100);
    shape.FillFormat.FillType = FillType.Solid;
    shape.FillFormat.SolidFillColor.Color = Color.Green;
    ILineFillFormat format = shape.LineFormat.FillFormat;
    format.FillType = FillType.Solid;
    format.SolidFillColor.Color = Color.Orange;
    shape.LineFormat.Width = 2.0;
    
    // يحدد خصائص الحواف الثلاثية للشكل
    shape.ThreeDFormat.Depth = 4;
    shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
    shape.ThreeDFormat.BevelTop.Height = 6;
    shape.ThreeDFormat.BevelTop.Width = 6;
    shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
    shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
    shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;
    
    // يكتب العرض كملف PPTX
    pres.Save("Bavel_out.pptx", SaveFormat.Pptx);
}
```

## **إضافة تأثير الدوران الثلاثي**
تتيح لك Aspose.Slides تطبيق تأثيرات الدوران الثلاثي على شكل عن طريق تعديل خصائص [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ThreeDFormat) بهذه الطريقة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. الحصول على مرجع الشريحة من خلال فهرسها.
3. إضافة [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) إلى الشريحة.
3. تحديد الأشكال المفضلة لديك لـ [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/properties/cameratype) و [LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/properties/lighttype).
4. كتابة العرض إلى القرص.

هذا الكود C# يوضح لك كيفية تطبيق تأثيرات دوران ثلاثي على شكل:

```c#
// ينشئ مثيل من فئة العرض التي تمثل ملف العرض
using (Presentation pres = new Presentation())
{
    IShape autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 200, 200);
    
    autoShape.ThreeDFormat.Depth = 6;
    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    
    autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Line, 30, 300, 200, 200);
    autoShape.ThreeDFormat.Depth = 6;
    autoShape.ThreeDFormat.Camera.SetRotation(0, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;
    
    // يكتب العرض كملف PPTX
    pres.Save("Rotation_out.pptx", SaveFormat.Pptx);
}
```

## **إعادة ضبط التنسيق**

هذا الكود C# يوضح لك كيفية إعادة ضبط التنسيق في شريحة وإرجاع الموضع والحجم والتنسيق لكل شكل يحتوي على عنصر نائب على [LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) إلى إعداداتهم الافتراضية:

```c#
using (Presentation pres = new Presentation())
{
    foreach (ISlide slide in pres.Slides)
    {
        // سيتم إرجاع كل شكل على الشريحة الذي يحتوي على عنصر نائب على التخطيط
        slide.Reset();
    }
}
```