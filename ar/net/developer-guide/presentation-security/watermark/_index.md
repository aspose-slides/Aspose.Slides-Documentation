---
title: علامة مائية
type: docs
weight: 40
url: /net/watermark/
keywords:
- علامة مائية
- إضافة علامة مائية
- علامة مائية نصية
- علامة مائية بالصورة
- PowerPoint
- عرض تقديمي
- C#
- Csharp
- Aspose.Slides for .NET
description: "إضافة علامات مائية نصية وصورية إلى عروض PowerPoint في C# أو .NET"
---

## **حول العلامات المائية**

**العلامة المائية** في عرض تقديمي هي ختم نصي أو صورة مستخدمة على شريحة أو في جميع شرائح العرض التقديمي. عادةً ما تُستخدم العلامة المائية للإشارة إلى أن العرض التقديمي مسودة (مثل، علامة مائية "مسودة")، أو أنه يحتوي على معلومات سرية (مثل، علامة مائية "سري")، أو لتحديد الشركة التي ينتمي إليها (مثل، علامة مائية "اسم الشركة")، أو لتحديد مؤلف العرض التقديمي، إلخ. تساعد العلامة المائية في منع انتهاكات حقوق الطبع والنشر عن طريق الإشارة إلى أن العرض التقديمي لا يجب نسخه. تُستخدم العلامات المائية في كل من تنسيقات عروض PowerPoint وOpenOffice. في Aspose.Slides، يمكنك إضافة علامة مائية إلى تنسيقات ملفات PowerPoint PPT وPPTX وOpenOffice ODP.

في [**Aspose.Slides**](https://products.aspose.com/slides/net/)، هناك طرق متنوعة يمكنك من خلالها إنشاء علامات مائية في وثائق PowerPoint أو OpenOffice وتعديل تصميمها وسلوكها. الجانب المشترك هو أنه لإضافة علامات مائية نصية، يجب عليك استخدام واجهة [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/)، ولإضافة علامات مائية بالصورة، استخدم فئة [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) أو ملء شكل علامة مائية بصورة. `PictureFrame` تنفذ واجهة [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) مما يتيح لك استخدام جميع إعدادات شكل الكائن المرنة. نظرًا لأن `ITextFrame` ليس شكلًا وإعداداته محدودة، فقد تم تغليفه في كائن [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape).

هناك طريقتان يمكن تطبيق العلامة المائية فيهما: على شريحة واحدة أو على جميع شرائح العرض التقديمي. تُستخدم الشريحة الرئيسية لتطبيق علامة مائية على جميع شرائح العرض التقديمي — يتم إضافة العلامة المائية إلى الشريحة الرئيسية، وتصميمها بالكامل هناك، وتطبيقها على جميع الشرائح دون التأثير على الإذن بتعديل العلامة المائية على الشرائح الفردية.

عادة ما تعتبر العلامة المائية غير متاحة للتعديل من قبل مستخدمين آخرين. لمنع تعديل العلامة المائية (أو بالأحرى الشكل الأب للعلامة المائية)، توفر Aspose.Slides وظيفة قفل الشكل. يمكن قفل شكل معين على شريحة عادية أو على شريحة رئيسية. عندما يتم قفل شكل العلامة المائية على الشريحة الرئيسية، فسيتم قفله على جميع شرائح العرض التقديمي.

يمكنك تعيين اسم للعلامة المائية بحيث أنه في المستقبل، إذا كنت ترغب في حذفها، يمكنك العثور عليها في أشكال الشريحة حسب الاسم.

يمكنك تصميم العلامة المائية بأي طريقة؛ ومع ذلك، هناك عادة ميزات شائعة في العلامات المائية، مثل محاذاة مركزية، دوران، موضع أمامي، إلخ. سنعتبر كيف يمكن استخدام هذه الأمثلة أدناه.

## **علامة مائية نصية**

### **إضافة علامة مائية نصية إلى شريحة**

لإضافة علامة مائية نصية في PPT، PPTX، أو ODP، يمكنك أولاً إضافة شكل إلى الشريحة، ثم إضافة إطار نصي إلى هذا الشكل. يتم تمثيل إطار النص بواسطة واجهة [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe). هذا النوع ليس موروثًا من [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/)، الذي يمتلك مجموعة واسعة من الخصائص لتحديد موضع العلامة المائية بطريقة مرنة. لذلك، يتم تغليف كائن [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe) في كائن [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/). لإضافة نص علامة مائية إلى الشكل، استخدم طريقة [AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/methods/addtextframe) كما هو موضح أدناه.

```cs
string watermarkText = "سري";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="primary" title="انظر أيضًا" %}} 
- [كيفية استخدام فئة TextFrame](/slides/net/text-formatting/)
{{% /alert %}}

### **إضافة علامة مائية نصية إلى عرض تقديمي**

إذا كنت ترغب في إضافة علامة مائية نصية إلى العرض التقديمي بالكامل (أي جميع الشرائح دفعة واحدة)، أضفها إلى [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/). بقية المنطق هو نفسه كما عند إضافة علامة مائية إلى شريحة واحدة — إنشاء كائن [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) ثم إضافة العلامة المائية إليه باستخدام طريقة [AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/methods/addtextframe).

```cs
string watermarkText = "سري";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="primary" title="انظر أيضًا" %}} 
- [كيفية استخدام الشريحة الرئيسية](/slides/net/slide-master/)
{{% /alert %}}

### **تعيين شفافية شكل العلامة المائية**

بشكل افتراضي، يتم تنسيق شكل المستطيل بألوان التعبئة والخط. تجعل الأسطر التالية من التعليمات البرمجية الشكل شفافًا.

```cs
watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **تعيين الخط لعلامة مائية نصية**

يمكنك تغيير خط نص العلامة المائية كما هو موضح أدناه.

```cs
IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **تعيين لون نص العلامة المائية**

لتعيين لون نص العلامة المائية، استخدم هذا الكود:

```cs
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **توسيط علامة مائية نصية**

من الممكن توسيط العلامة المائية على شريحة، ولإجراء ذلك، يمكنك القيام بما يلي:

```cs
SizeF slideSize = presentation.SlideSize.Size;

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = (slideSize.Width - watermarkWidth) / 2;
float watermarkY = (slideSize.Height - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(
    ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

توضح الصورة أدناه النتيجة النهائية.

![العلامة المائية النصية](text_watermark.png)

## **علامة مائية بالصورة**

### **إضافة علامة مائية بالصورة إلى عرض تقديمي**

لإضافة علامة مائية بالصورة إلى شريحة عرض تقديمي، يمكنك القيام بما يلي:

```cs
using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **قفل علامة مائية من التحرير**

إذا كان من الضروري منع تحرير العلامة المائية، استخدم خاصية [IAutoShape.ShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/shapelock) على الشكل. مع هذه الخاصية، يمكنك حماية الشكل من أن يتم تحديده، تغيير حجمه، repositioned، تجميعه مع عناصر أخرى، قفل نصه من التحرير، والمزيد:

```cs
// قفل شكل العلامة المائية من التعديل
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

## **إحضار علامة مائية إلى المقدمة**

في Aspose.Slides، يمكن تعيين ترتيب Z للأشكال عبر طريقة [IShapeCollection.Reorder](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/reorder/#reorder). للقيام بذلك، تحتاج إلى استدعاء هذه الطريقة من قائمة شرائح العرض التقديمي وتمرير مرجع الشكل ورقم ترتيبه إلى الطريقة. بهذه الطريقة، من الممكن إحضار شكل إلى المقدمة أو إرساله إلى الجزء الخلفي من الشريحة. هذه الميزة مفيدة بشكل خاص إذا كنت بحاجة إلى وضع علامة مائية أمام العرض التقديمي:

```cs
int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```

## **تعيين دوران العلامة المائية**

إليك مثال على كود يوضح كيفية ضبط دوران العلامة المائية بحيث تكون موضوعة بزاوية عبر الشريحة:

```cs
double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **تعيين اسم لعلامة مائية**

تسمح لك Aspose.Slides بتعيين اسم لشكل. من خلال استخدام اسم الشكل، يمكنك الوصول إليه في المستقبل لتعديله أو حذفه. لتعيين اسم شكل العلامة المائية، قم بتعيينه إلى خاصية [IAutoShape.Name](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/name):

```cs
watermarkShape.Name = "علامة مائية";
```

## **إزالة علامة مائية**

لإزالة شكل العلامة المائية، استخدم خاصية [IAutoShape.Name](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/name) للعثور عليه في أشكال الشريحة. ثم، مرّر شكل العلامة المائية إلى طريقة [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) كما يلي:

```cs
List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "علامة مائية", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(watermarkShape);
    }
}
```

## **مثال حي**

قد ترغب في التحقق من أدوات **Aspose.Slides المجانية** [إضافة علامة مائية](https://products.aspose.app/slides/watermark) و[إزالة علامة مائية](https://products.aspose.app/slides/watermark/remove-watermark) عبر الإنترنت.

![أدوات عبر الإنترنت لإضافة وإزالة العلامات المائية](online_tools.png)