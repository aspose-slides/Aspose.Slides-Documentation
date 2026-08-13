---
title: إضافة علامات مائية إلى العروض التقديمية في .NET
linktitle: علامة مائية
type: docs
weight: 40
url: /ar/net/watermark/
keywords:
- علامة مائية
- علامة مائية نصية
- علامة مائية صورة
- إضافة علامة مائية
- تغيير علامة مائية
- إزالة علامة مائية
- حذف علامة مائية
- إضافة علامة مائية إلى PPT
- إضافة علامة مائية إلى PPTX
- إضافة علامة مائية إلى ODP
- إزالة علامة مائية من PPT
- إزالة علامة مائية من PPTX
- إزالة علامة مائية من ODP
- حذف علامة مائية من PPT
- حذف علامة مائية من PPTX
- حذف علامة مائية من ODP
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إدارة العلامات المائية النصية والصورية في عروض PowerPoint وOpenDocument في .NET لتحديد مسودة أو معلومات سرية أو حقوق طبع ونشر وغيرها."
---
## **المقدمة**

**علامة مائية** في العرض التقديمي هي طابع نصي أو صورة يُستخدم على شريحة أو عبر جميع شرائح العرض. عادةً ما تُستخدم العلامة المائية للإشارة إلى أن العرض مجرد مسودة (مثلاً، علامة مائية "مسودة")، أو أنه يحتوي على معلومات سرية (مثلاً، علامة مائية "سري")، لتحديد الشركة التي ينتمي إليها (مثلاً، علامة مائية "اسم الشركة")، لتحديد مؤلف العرض، إلخ. تساعد العلامة المائية في منع انتهاكات حقوق النشر عن طريق الإشارة إلى أنه لا يجب نسخ العرض. تُستخدم العلامات المائية في صيغتي PowerPoint وOpenDocument للعرض. في Aspose.Slides، يمكنك إضافة علامة مائية إلى صيغ ملفات PowerPoint PPT وPPTX وOpenDocument ODP.

في [**Aspose.Slides**](https://products.aspose.com/slides/ar/net/)، توجد طرق متعددة لإنشاء علامات مائية في مستندات PowerPoint أو OpenDocument وتعديل تصميمها وسلوكها. الجانب المشترك هو أنه لإضافة علامات مائية نصية، يجب عليك استخدام واجهة [ITextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/)، ولإضافة علامات مائية صورة، استخدم الفئة [PictureFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/pictureframe/) أو امتلئ شكل العلامة المائية بصورة. `PictureFrame` يُطبق واجهة [IShape](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape) مما يتيح لك استخدام جميع الإعدادات المرنة لكائن الشكل. بما أن `ITextFrame` ليس شكلاً وإعداداته محدودة، يتم تغليفه داخل كائن [IShape](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape).

هناك طريقتان لتطبيق العلامة المائية: على شريحة واحدة أو على جميع شرائح العرض. يُستخدم الـ Slide Master لتطبيق العلامة المائية على جميع شرائح العرض — تُضاف العلامة المائية إلى الـ Slide Master، تُصمم بالكامل هناك، وتُطبق على جميع الشرائح دون التأثير على إمكانية تعديل العلامة المائية على الشرائح الفردية.

عادةً ما تُعتبر العلامة المائية غير قابلة للتحرير من قبل المستخدمين الآخرين. لمنع تحرير العلامة المائية (أو بالأحرى الشكل الأصلي للعلامة المائية)، توفر Aspose.Slides وظيفة قفل الشكل. يمكن قفل شكل معين على شريحة عادية أو على Slide Master. عندما يكون شكل العلامة المائية مقفلاً على الـ Slide Master، سيُقفل على جميع شرائح العرض.

يمكنك تعيين اسم للعلامة المائية بحيث يمكنك، في المستقبل، إذا أردت حذفها، العثور عليها ضمن أشكال الشريحة حسب الاسم.

يمكنك تصميم العلامة المائية بأي طريقة؛ ومع ذلك، توجد عادةً ميزات شائعة في العلامات المائية، مثل المحاذاة إلى الوسط، التدوير، الوضعية الأمامية، إلخ. سنستعرض كيفية استخدام هذه الخصائص في الأمثلة أدناه.

## **علامة مائية نصية**

### **إضافة علامة مائية نصية إلى شريحة**

لإضافة علامة مائية نصية في PPT أو PPTX أو ODP، يمكنك أولاً إضافة شكل إلى الشريحة، ثم إضافة إطار نص إلى هذا الشكل. يُمثَّل إطار النص بالواجهة [ITextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe). هذا النوع غير مُشتق من [IShape](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/)، التي تحتوي على مجموعة واسعة من الخصائص لتحديد موضع العلامة المائية بشكل مرن. لذلك، يتم تغليف كائن [ITextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe) داخل كائن [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) . لإضافة نص العلامة المائية إلى الشكل، استخدم طريقة [AddTextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/methods/addtextframe) كما هو موضح أدناه.

```cs
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// أضف العلامة المائية إلى الشريحة.
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="info" title="انظر أيضًا" %}} 
- [How to Use the TextFrame Class?](/slides/ar/net/text-formatting/)
{{% /alert %}}

### **إضافة علامة مائية نصية إلى عرض تقديمي**

إذا كنت تريد إضافة علامة مائية نصية إلى العرض بالكامل (أي جميع الشرائح دفعة واحدة)، أضفها إلى الـ [MasterSlide](https://reference.aspose.com/slides/ar/net/aspose.slides/masterslide/). باقي المنطق هو نفسه عند إضافة علامة مائية إلى شريحة واحدة — أنشئ كائنًا من نوع [IAutoShape](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/) ثم أضف العلامة المائية إليه باستخدام طريقة [AddTextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/methods/addtextframe).

```cs
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

// أضف العلامة المائية إلى شريحة الماستر.
IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="info" title="انظر أيضًا" %}} 
- [How to Use the Slide Master?](/slides/ar/net/slide-master/)
{{% /alert %}}

### **تعيين شفافية شكل العلامة المائية**

بشكل افتراضي، يُصمم شكل المستطيل بألوان ملء وخط. هذا يعني أنه عند إضافة العلامة المائية قد تظهر بخلفية صلبة أو حدود قد تشتت الانتباه عن محتوى الشريحة. لضمان بقاء العلامة المائية خفيفة ولا تتداخل مع التصميم البصري للعرض، يمكنك جعل الشكل شفافًا تمامًا.

السطران التاليان من الشيفرة يجعلان الشكل شفافًا عن طريق إزالة كلٍ من لون التعبئة ولون الحدود:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **تعيين الخط للعلامة المائية النصية**

قبل تطبيق العلامة المائية النصية على شريحتك، من المهم تخصيص مظهرها لتتناغم مع التصميم العام. يمكنك تغيير نوع الخط وحجمه لضمان أن تكون العلامة المائية مقروءة وجذابة بصريًا. تعديل الخط يساعد أيضًا في تعزيز هوية العلامة التجارية أو ببساطة مطابقة أسلوب العرض.

المقتطف التالي يُظهر كيفية ضبط إعدادات خط العلامة المائية باختيار خط لاتيني محدد وتعيين ارتفاع خط مناسب:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame("CONFIDENTIAL");

IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **تعيين لون نص العلامة المائية**

قبل تطبيق علامتك المائية، من الضروري التأكد من ضبط لون النص بشكل مناسب بحيث يندمج مع محتوى الشريحة دون أن يطغى عليه. تعديل شفافية اللون (alpha) إلى جانب مكونات الأحمر والأخضر والأزرق يتيح لك إنشاء علامة مائية نصف شفافة تُظهر لكن لا تُزعج. هذا النهج يساعد على الحفاظ على التركيز على محتوى العرض مع حماية المحتوى في آنٍ واحد.

لتعيين لون نص العلامة المائية، استخدم الشيفرة التالية:

```cs
using System.Drawing;
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame("CONFIDENTIAL");

int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **محاذاة العلامة المائية النصية إلى الوسط**

محاذاة العلامة المائية النصية إلى الوسط بشكل صحيح يمكن أن يُحسّن بشكل ملحوظ من جمالية العرض من خلال ضمان تموضع العلامة متماثلًا بغض النظر عن أبعاد الشريحة. هذا النهج لا يمنح الشرائح مظهرًا احترافيًا فحسب، بل يضمن أيضًا أن العلامة المائية لا تتداخل مع المحتوى الرئيسي.

المقتطف التالي يوضح كيفية حساب موضع الوسط للشريحة ووضع العلامة المائية النصية بناءً عليه:

```cs
using System.Drawing;
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

SizeF slideSize = presentation.SlideSize.Size;

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = (slideSize.Width - watermarkWidth) / 2;
float watermarkY = (slideSize.Height - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(
    ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

الصورة أدناه تُظهر النتيجة النهائية.

![The text watermark](text_watermark.png)

## **علامة مائية صورة**

### **إضافة علامة مائية صورة إلى عرض تقديمي**

في كثير من الحالات، يمكن للعلامة المائية صورة أن تُقدّم عنصرًا فريدًا للعلامة التجارية أو بديلاً بصريًا أكثر جاذبية للعلامة المائية النصية. قبل إضافة العلامة المائية، تأكد من توفر ملف الصورة (مثل PNG للشفافية). يوضح المثال التالي كيفية تحميل صورة من نظام الملفات، إضافتها إلى العرض، ثم تطبيقها كعلامة مائية عبر خصائص تعبئة الشكل.

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **قفل العلامة المائية من التحرير**

إذا كان من الضروري منع تحرير العلامة المائية، استخدم خاصية [IAutoShape.ShapeLock](https://reference.aspose.com/slides/ar/net/aspose.slides/iautoshape/properties/shapelock) على الشكل. بهذه الخاصية يمكنك حماية الشكل من الاختيار، وإعادة التحجيم، وإعادة التموقع، وتجميعه مع عناصر أخرى، وقفل نصه من التحرير، وغير ذلك الكثير:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

// قفل شكل العلامة المائية من التعديل.
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

## **إحضار العلامة المائية إلى الأمام**

في Aspose.Slides، يمكن تعيين ترتيب Z للأشكال عبر طريقة [IShapeCollection.Reorder](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapecollection/reorder/#reorder). للقيام بذلك، تحتاج إلى استدعاء هذه الطريقة من قائمة شرائح العرض وتمرير مرجع الشكل ورقمه التسلسلي إلى الطريقة. بهذه الطريقة، يمكنك إحضار الشكل إلى الأمام أو إرساله إلى الخلف في الشريحة. هذه الميزة مفيدة بشكل خاص إذا كنت بحاجة إلى وضع العلامة المائية أمام محتوى العرض:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```

## **تعيين تدوير العلامة المائية**

ضبط تدوير العلامة المائية يمكن أن يُعزز بشكل كبير من التأثير البصري والخفيف للعرض. على سبيل المثال، يمكن للعلامة المائية المائلة أن تكون أقل إزعاجًا بينما لا تزال توفر حماية قوية ضد الاستخدام غير المصرح به. يحسب المثال التالي الزاوية المناسبة بناءً على أبعاد الشريحة بحيث تُوضع العلامة المائية مائلة عبر الشريحة. يضمن هذا الحساب الديناميكي بقاء العلامة فعّالة بغض النظر عن اختلاف أحجام الشرائح.

```cs
using System.Drawing;
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

SizeF slideSize = presentation.SlideSize.Size;

double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **تعيين اسم للعلامة المائية**

تسمح Aspose.Slides لك بتعيين اسم للشكل. باستخدام اسم الشكل، يمكنك الوصول إليه في المستقبل لتعديله أو حذفه. لتعيين اسم شكل العلامة المائية، عينه إلى خاصية [IAutoShape.Name](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/properties/name):

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.Name = "watermark";
```

## **إزالة علامة مائية**

لإزالة شكل العلامة المائية، استخدم خاصية [IAutoShape.Name](https://reference.aspose.com/slides/ar/net/aspose.slides/ishape/properties/name) للعثور عليه في أشكال الشريحة. ثم مرّر شكل العلامة المائية إلى طريقة [IShapeCollection.Remove](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapecollection/remove/) :

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(shape);
    }
}
```

## **مثال حي**

قد ترغب في تجربة أدوات **Aspose.Slides free** [Add Watermark](https://products.aspose.app/slides/ar/watermark) و[Remove Watermark](https://products.aspose.app/slides/ar/watermark/remove-watermark) على الإنترنت.

![Online tools to add and remove watermarks](online_tools.png)

## **الأسئلة المتكررة**

### ما هي العلامة المائية ولماذا يجب أن أستخدمها؟

العلامة المائية هي طبقة نصية أو صورية تُطبق على الشرائح وتساعد على حماية الملكية الفكرية، وتعزيز التعرف على العلامة التجارية، أو منع الاستخدام غير المصرح به للعرض.

### هل يمكنني إضافة علامة مائية إلى جميع الشرائح في العرض؟

نعم، تسمح Aspose.Slides لك بإضافة علامة مائية برمجيًا إلى كل شريحة في العرض. يمكنك تكرار جميع الشرائح وتطبيق إعدادات العلامة المائية على كل واحدة على حدة.

### كيف يمكنني تعديل شفافية العلامة المائية؟

يمكنك تعديل شفافية العلامة المائية عن طريق تعديل إعدادات التعبئة ([FillFormat](https://reference.aspose.com/slides/ar/net/aspose.slides/shape/fillformat/)) للشكل. هذا يضمن أن تكون العلامة المائية خفيفة ولا تشتت انتباه المشاهد عن محتوى الشريحة.

### ما هي صيغ الصور المدعومة للعلامات المائية؟

تدعم Aspose.Slides صيغ صور متعددة مثل PNG وJPEG وGIF وBMP وSVG وغيرها.

### هل يمكنني تخصيص الخط ونمط العلامة المائية النصية؟

نعم، يمكنك اختيار أي خط وحجم ونمط لتتناسب مع تصميم العرض وتحافظ على اتساق العلامة التجارية.

### كيف أغير موضع أو اتجاه العلامة المائية؟

يمكنك تعديل موضع واتجاه العلامة المائية برمجيًا عن طريق تعديل إحداثيات الشكل وحجمه وخصائص التدوير.