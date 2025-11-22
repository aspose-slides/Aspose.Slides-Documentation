---
title: إضافة علامة مائية إلى عرض تقديمي في C#
linktitle: علامة مائية
type: docs
weight: 40
url: /ar/net/watermark/
keywords:
- علامة مائية
- علامة مائية نصية
- علامة مائية صورية
- إضافة علامة مائية
- تعديل علامة مائية
- إزالة علامة مائية
- حذف علامة مائية
- إضافة علامة مائية إلى عرض تقديمي
- إضافة علامة مائية إلى PPT
- إضافة علامة مائية إلى PPTX
- إضافة علامة مائية إلى ODP
- إزالة علامة مائية من عرض تقديمي
- إزالة علامة مائية من PPT
- إزالة علامة مائية من PPTX
- إزالة علامة مائية من ODP
- حذف علامة مائية من عرض تقديمي
- حذف علامة مائية من PPT
- حذف علامة مائية من PPTX
- حذف علامة مائية من ODP
- PowerPoint
- OpenDocument
- عرض تقديمي
- C#
- Csharp
- Aspose.Slides for .NET
description: "تعلم كيفية إدارة العلامات المائية النصية والصورية في عروض PowerPoint وOpenDocument باستخدام C# لتحديد مسودة أو معلومات سرية أو حقوق طبع ونشر وغيرها."
---

## **نظرة عامة**

**العلامة المائية** في عرض تقديمي هي ختم نصي أو صوري يُستخدم على شريحة أو على جميع شرائح العرض. عادةً ما تُستخدم العلامة المائية للإشارة إلى أن العرض مسودة (مثال: علامة مائية "مسودة")، أو أنه يحتوي على معلومات سرية (مثال: علامة مائية "سري")، أو لتحديد الشركة المالكة (مثال: علامة مائية "اسم الشركة")، أو لتحديد مؤلف العرض، إلخ. تساعد العلامة المائية في منع انتهاكات حقوق النشر من خلال الإشارة إلى أن العرض لا ينبغي نسخه. تُستخدم العلامات المائية في صيغتي PowerPoint وOpenDocument. في Aspose.Slides، يمكنك إضافة علامة مائية إلى صيغ ملفات PowerPoint PPT، PPTX، وصيغة OpenDocument ODP.

في [**Aspose.Slides**](https://products.aspose.com/slides/net/)، هناك طرق متعددة لإنشاء علامات مائية في مستندات PowerPoint أو OpenDocument وتعديل تصميمها وسلوكها. الجانب المشترك هو أنه لإضافة علامات مائية نصية، يجب استخدام واجهة [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/)، ولإضافة علامات مائية صورية، استخدم الفئة [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) أو املأ شكل العلامة المائية بصورة. `PictureFrame` تُنفّذ واجهة [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) مما يتيح لك استخدام جميع إعدادات الشكل المرنة. بما أن `ITextFrame` ليس شكلاً وإعداداته محدودة، يتم تغليفه داخل كائن [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape).

هناك طريقتان لتطبيق العلامة المائية: على شريحة واحدة أو على جميع شرائح العرض. يُستخدم Slide Master لتطبيق العلامة المائية على جميع الشرائح — تُضاف العلامة المائية إلى Slide Master، تُصمم هناك بالكامل، وتُطبّق على جميع الشرائح دون التأثير على إمكانية تعديل العلامة المائية على الشرائح الفردية.

عادةً ما تُعتبر العلامة المائية غير قابلة للتحرير من قبل المستخدمين الآخرين. لمنع تحرير العلامة المائية (أو الشكل الأب للعلامة المائية) يُوفر Aspose.Slides وظيفة قفل الشكل. يمكن قفل شكل محدد على شريحة عادية أو على Slide Master. عندما يتم قفل شكل العلامة المائية على Slide Master، سيُقفل على جميع الشرائح.

يمكنك تعيين اسم للعلامة المائية بحيث في المستقبل، إذا أردت حذفها، يمكنك العثور عليها في أشكال الشريحة عن طريق الاسم.

يمكنك تصميم العلامة المائية بأي طريقة؛ ومع ذلك، هناك سمات شائعة عادةً في العلامات المائية، مثل المحاذاة المركزية، الدوران، الموضع الأمامي، إلخ. سنستعرض كيفية استخدام هذه الخصائص في الأمثلة أدناه.

## **العلامة المائية النصية**

### **إضافة علامة مائية نصية إلى شريحة**

لإضافة علامة مائية نصية في PPT أو PPTX أو ODP، يمكنك أولاً إضافة شكل إلى الشريحة، ثم إضافة إطار نص إلى هذا الشكل. يُمثّل إطار النص الواجهة [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe). هذا النوع غير مُشتق من [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/)، الذي يحتوي على مجموعة واسعة من الخصائص لتحديد موقع العلامة المائية بطريقة مرنة. لذلك، يتم تغليف كائن [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe) داخل كائن [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) . لإضافة نص العلامة المائية إلى الشكل، استخدم طريقة [AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/methods/addtextframe) كما هو موضح أدناه.
```cs
string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// إضافة العلامة المائية إلى الشريحة.
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```


{{% alert color="primary" title="انظر أيضًا" %}} 
- [كيفية استخدام فئة TextFrame؟](/slides/ar/net/text-formatting/)
{{% /alert %}}

### **إضافة علامة مائية نصية إلى عرض تقديمي**

إذا كنت تريد إضافة علامة مائية نصية إلى العرض بأكمله (أي جميع الشرائح دفعة واحدة)، أضفها إلى [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/). باقي المنطق هو نفسه كما عند إضافة علامة مائية إلى شريحة واحدة — أنشئ كائن [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) ثم أضف العلامة المائية إليه باستخدام طريقة [AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/methods/addtextframe).
```cs
string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

// إضافة العلامة المائية إلى شريحة القالب.
IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```


{{% alert color="primary" title="انظر أيضًا" %}} 
- [كيفية استخدام Slide Master؟](/slides/ar/net/slide-master/)
{{% /alert %}}

### **ضبط شفافية شكل العلامة المائية**

بشكل افتراضي، يُنَسَّق الشكل المستطيل بألوان تعبئة وخط. وهذا يعني أنه عند إضافة العلامة المائية، قد تظهر بخلفية صلبة أو حد قد يشتت الانتباه عن محتوى الشريحة. لضمان أن تكون العلامة المائية خفيفة ولا تتداخل مع التصميم البصري للعرض، يمكنك جعل الشكل شفافًا تمامًا.

السطران التاليان يجعلان الشكل شفافًا عبر إزالة كل من لون التعبئة والحد:
```cs
watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```


### **ضبط الخط للعلامة المائية النصية**

قبل تطبيق العلامة المائية النصية على شريحتك، من المهم تخصيص مظهرها لتتناسب مع التصميم الكلي. يمكنك تغيير نوع الخط وحجمه لضمان أن تكون العلامة المائية مقروءة وجذابة بصريًا. تعديل الخط يساعد أيضًا في تعزيز هوية العلامة التجارية أو مجرد مطابقة أسلوب العرض.

المقتطف البرمجي أدناه يُظهر كيفيّة ضبط إعدادات خط العلامة المائية باختيار خط لاتيني محدد وتحديد ارتفاع خط مناسب:
```cs
IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```


### **ضبط لون نص العلامة المائية**

قبل تطبيق العلامة المائية، من الضروري ضبط لون النص بشكل مناسب بحيث يندمج مع محتوى الشريحة دون أن يطغى عليه. تعديل شفافية اللون (alpha) بالإضافة إلى مكونات الأحمر، الأخضر، الأزرق يُتيح لك إنشاء علامة مائية شبه شفافة تكون ظاهرة ولكن غير مُزعجة. هذا النهج يساعد على الحفاظ على تركيز المشاهدين على المحتوى الرئيسي للعرض مع حماية المحتوى.

لضبط لون نص العلامة المائية، استخدم الشفرة التالية:
```cs
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```


### **تمركز العلامة المائية النصية**

تمركز العلامة المائية النصية بشكل صحيح يمكن أن يعزز بشكل كبير من جمالية العرض من خلال ضمان وضع العلامة المائية بشكل متماثل، بغض النظر عن أبعاد الشريحة. هذا يمنح الشرائح مظهرًا احترافيًا ويضمن أن العلامة المائية لا تتداخل مع المحتوى الرئيسي.

المقتطف البرمجي أدناه يُظهر كيفية حساب موضع المركز للشريحة ووضع العلامة المائية النصية بناءً على ذلك:
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


الصورة أدناه تُظهر النتيجة النهائية.

![العلامة المائية النصية](text_watermark.png)

## **العلامة المائية الصورية**

### **إضافة علامة مائية صورية إلى عرض تقديمي**

في كثير من الحالات، يمكن للعلامة المائية الصورية أن توفر عنصرًا فريدًا للعلامة التجارية أو بديلاً بصريًا أكثر جاذبية للعلامة المائية النصية. قبل إضافة العلامة المائية، تأكد من أن ملف الصورة متاح (مثال: PNG للشفافية). المثال التالي يُظهر كيفية تحميل صورة من نظام الملفات، إضافتها إلى العرض، ثم تطبيقها كعلامة مائية باستخدام خصائص تعبئة الشكل.
```cs
using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```


## **قفل العلامة المائية من التحرير**

إذا كان من الضروري منع تحرير العلامة المائية، استخدم خاصية [IAutoShape.ShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/shapelock) على الشكل. باستخدام هذه الخاصية، يمكنك حماية الشكل من الاختيار، إعادة التحجيم، إعادة الوضع، التجميع مع عناصر أخرى، قفل نصه من التحرير، وأكثر من ذلك:
```cs
// قفل شكل العلامة المائية من التعديل.
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```


## **إحضار العلامة المائية إلى المقدمة**

في Aspose.Slides، يمكن ضبط ترتيب Z للأشكال عبر طريقة [IShapeCollection.Reorder](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/reorder/#reorder). للقيام بذلك، استدعِ هذه الطريقة من قائمة شرائح العرض مرّر مرجع الشكل ورقمه إلى الطريقة. بهذه الطريقة يمكن إحضار الشكل إلى المقدمة أو إرساله إلى الخلف. هذه الميزة مفيدة خاصةً إذا كنت بحاجة إلى وضع العلامة المائية أمام محتوى العرض:
```cs
int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```


## **ضبط دوران العلامة المائية**

تعديل دوران العلامة المائية يمكن أن يعزز بشكل كبير من التأثير البصري والدقة في عرضك. على سبيل المثال، يمكن للعلامة المائية المائلة أن تكون أقل إزعاجًا مع استمرارها في توفير حماية قوية ضد الاستخدام غير المصرّح به. المثال التالي يحسب الزاوية المناسبة بناءً على أبعاد الشريحة بحيث تُوضع العلامة المائية مائلة عبر الشريحة. هذا الحساب الديناميكي يضمن بقاء العلامة المائية فعّالة بغض النظر عن اختلاف أحجام الشرائح.
```cs
double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```


## **ضبط اسم للعلامة المائية**

يتيح Aspose.Slides تعيين اسم للشكل. باستخدام اسم الشكل، يمكنك الوصول إليه لاحقًا لتعديله أو حذفه. لتعيين اسم لشكل العلامة المائية، قم بتعيينه إلى خاصية [IAutoShape.Name](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/name):
```cs
watermarkShape.Name = "watermark";
```


## **إزالة العلامة المائية**

لإزالة شكل العلامة المائية، استخدم خاصية [IAutoShape.Name](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/name) للعثور عليه في أشكال الشريحة. ثم مرّر شكل العلامة المائية إلى طريقة [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) :
```cs
List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(watermarkShape);
    }
}
```


## **مثال حي**

قد ترغب في تجربة **Aspose.Slides free** [Add Watermark](https://products.aspose.app/slides/watermark) و [Remove Watermark](https://products.aspose.app/slides/watermark/remove-watermark) الأداتين عبر الإنترنت.

![الأدوات عبر الإنترنت لإضافة وإزالة العلامات المائية](online_tools.png)

## **الأسئلة الشائعة**

**ما هي العلامة المائية ولماذا يجب علي استخدامها؟**

العلامة المائية هي طبقة نصية أو صورية تُطبق على الشرائح لتساعد في حماية الملكية الفكرية، تعزيز التعرف على العلامة التجارية، أو منع الاستخدام غير المصرّح به للعروض.

**هل يمكنني إضافة علامة مائية إلى جميع الشرائح في عرض تقديمي؟**

نعم، يتيح Aspose.Slides إضافة علامة مائية برمجيًا إلى كل شريحة في العرض. يمكنك التنقل عبر جميع الشرائح وتطبيق إعدادات العلامة المائية على كل منها بشكل منفصل.

**كيف يمكنني تعديل شفافية العلامة المائية؟**

يمكنك تعديل شفافية العلامة المائية عبر تعديل إعدادات التعبئة ([FillFormat](https://reference.aspose.com/slides/net/aspose.slides/shape/fillformat/)) للشكل. هذا يضمن أن تكون العلامة المائية خفيفة ولا تشوش محتوى الشريحة.

**ما صيغ الصور المدعومة للعلامات المائية؟**

يدعم Aspose.Slides صيغ صور متعددة مثل PNG، JPEG، GIF، BMP، SVG، والمزيد.

**هل يمكنني تخصيص الخط ونمط العلامة المائية النصية؟**

نعم، يمكنك اختيار أي خط، حجم، ونمط ليتناسب مع تصميم العرض ويحافظ على تناسق العلامة التجارية.

**كيف أغيّر موضع أو اتجاه العلامة المائية؟**

يمكنك تعديل موضع واتجاه العلامة المائية برمجيًا عبر تعديل إحداثيات الشكل، حجمه، وخصائص الدوران.