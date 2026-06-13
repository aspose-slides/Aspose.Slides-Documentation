---
title: مدیریت اشکال ارائه در .NET
linktitle: دست‌کاری اشکال
type: docs
weight: 40
url: /fa/net/shape-manipulations/
keywords:
- شکل پاورپوینت
- شکل ارائه
- شکل در اسلاید
- پیدا کردن شکل
- کلون کردن شکل
- حذف شکل
- مخفی کردن شکل
- تغییر ترتیب شکل
- دریافت شناسه Interop شکل
- متن جایگزین شکل
- قالب‌های چیدمان شکل
- شکل به‌صورت SVG
- شکل به SVG
- هم‌راستایی شکل
- پاورپوینت
- ارائه
- .NET
- C#
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال را در Aspose.Slides برای .NET ایجاد، ویرایش و بهینه‌سازی کنید و ارائه‌های پاورپوینت با عملکرد بالا را ارائه دهید."
---
## **نمای کلی**

این مقاله توضیح می‌دهد چگونه در ارائه‌ها با Aspose.Slides با اشکال کار کنیم. نشان می‌دهد چگونه یک شکل را در یک اسلاید پیدا کنید، آن را کلون کنید، حذف کنید، مخفی کنید، ترتیب آن را تغییر دهید، شناسه Interop شکل را دریافت کنید و متن جایگزین برای شناسایی و پردازش‌های بعدی تنظیم کنید.

همچنین نحوه دسترسی به قالب‌های چیدمان برای اشکال، رندر کردن یک شکل به‌صورت SVG، هم‌راستایی اشکال در یک اسلاید و استفاده از ویژگی‌های چرخش برای آیینه‌سازی افقی و عمودی را پوشش می‌دهد. علاوه بر این، مقاله شامل سؤالات متداول کوتاهی درباره ترکیب اشکال، ترتیب لایه‌ها و قفل‌گذاری شکل‌ها است.

## **پیدا کردن یک شکل در اسلاید**
این موضوع تکنیک ساده‌ای را برای راحت‌تر کردن پیدا کردن یک شکل خاص در اسلاید بدون استفاده از شناسه داخلی آن توصیف می‌کند. مهم است بدانید فایل‌های ارائه PowerPoint هیچ راهی برای شناسایی اشکال در اسلاید به‌جز یک شناسه یکتا داخلی ندارند. پیدا کردن یک شکل بر پایه شناسه یکتا داخلی برای توسعه‌دهندگان می‌تواند دشوار باشد. تمام اشکالی که به اسلایدها اضافه می‌شوند دارای متن جایگزین (Alt Text) هستند. ما به توسعه‌دهندگان پیشنهاد می‌کنیم برای یافتن یک شکل خاص از متن جایگزین استفاده کنند. می‌توانید با استفاده از MS PowerPoint متن جایگزین برای اشیائی که قصد تغییر آن‌ها را در آینده دارید، تعریف کنید.

پس از تنظیم متن جایگزین برای هر شکل دلخواه، می‌توانید آن ارائه را با Aspose.Slides for .NET باز کنید و از طریق تمام اشکال اضافه‌شده به یک اسلاید پیمایش کنید. در هر بار پیمایش می‌توانید متن جایگزین شکل را بررسی کنید و شکلی که متن جایگزین آن تطابق داشته باشد، همان شکل موردنظر شما خواهد بود. برای نشان‌دادن این تکنیک به‌صورت بهتر، ما روشی به نام [FindShape](https://reference.aspose.com/slides/fa/net/aspose.slides.util/slideutil/findshape/#findshape_1) ایجاد کرده‌ایم که این کار را برای پیدا کردن یک شکل خاص در اسلاید انجام می‌دهد و سپس آن شکل را برمی‌گرداند.

```c#
public static void Run()
{
    // یک نمونه از کلاس Presentation که نمایانگر فایل ارائه است
    using (Presentation p = new Presentation("FindingShapeInSlide.pptx"))
    {

        ISlide slide = p.Slides[0];
        // متن جایگزین شکل موردجستجو
        IShape shape = FindShape(slide, "Shape1");
        if (shape != null)
        {
            Console.WriteLine("Shape Name: " + shape.Name);
        }
    }
}
        
// پیاده‌سازی متد برای پیدا کردن یک شکل در اسلاید با استفاده از متن جایگزین آن
public static IShape FindShape(ISlide slide, string alttext)
{
    // مرور تمام اشکال داخل اسلاید
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        // اگر متن جایگزین اسلاید با متن موردنظر مطابقت داشته باشد سپس
        // شکل را برگردان
        if (slide.Shapes[i].AlternativeText.CompareTo(alttext) == 0)
            return slide.Shapes[i];
    }
    return null;
}
```



## **کلون کردن یک شکل**
برای کلون کردن یک شکل به یک اسلاید با Aspose.Slides for .NET:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation) ایجاد کنید.
1. با استفاده از ایندکس، مرجع یک اسلاید را به‌دست آورید.
1. به مجموعه اشکال اسلاید مبدا دسترسی پیدا کنید.
1. اسلاید جدیدی به ارائه اضافه کنید.
1. اشکال را از مجموعه اشکال اسلاید مبدا به اسلاید جدید کلون کنید.
1. ارائه تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

مثال زیر یک شکل گروهی را به یک اسلاید اضافه می‌کند.

```c#
// ایجاد یک نمونه از کلاس Presentation
using (Presentation srcPres = new Presentation("Source Frame.pptx"))
{
	IShapeCollection sourceShapes = srcPres.Slides[0].Shapes;
	ILayoutSlide blankLayout = srcPres.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
	ISlide destSlide = srcPres.Slides.AddEmptySlide(blankLayout);
	IShapeCollection destShapes = destSlide.Shapes;
	destShapes.AddClone(sourceShapes[1], 50, 150 + sourceShapes[0].Height);
	destShapes.AddClone(sourceShapes[2]);                 
	destShapes.InsertClone(0, sourceShapes[0], 50, 150);

	// نوشتن فایل PPTX به دیسک
	srcPres.Save("CloneShape_out.pptx", SaveFormat.Pptx);
}
```



## **حذف یک شکل**
Aspose.Slides for .NET به توسعه‌دهندگان اجازه می‌دهد هر شکلی را حذف کنند. برای حذف شکل از هر اسلاید، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس `Presentation` ایجاد کنید.
1. به اولین اسلاید دسترسی پیدا کنید.
1. شکلی با متن جایگزین خاص پیدا کنید.
1. شکل را حذف کنید.
1. فایل را بر روی دیسک ذخیره کنید.

```c#
// ایجاد شیء Presentation
Presentation pres = new Presentation();

// دریافت اولین اسلاید
ISlide sld = pres.Slides[0];

// اضافه کردن AutoShape از نوع مستطیل
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "User Defined";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
    AutoShape ashp = (AutoShape)sld.Shapes[0];
    if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
    {
        sld.Shapes.Remove(ashp);
    }
}

// ذخیره ارائه در دیسک
pres.Save("RemoveShape_out.pptx", SaveFormat.Pptx);
```



## **مخفی کردن یک شکل**
Aspose.Slides for .NET به توسعه‌دهندگان اجازه می‌دهد هر شکلی را مخفی کنند. برای مخفی کردن شکل از هر اسلاید، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس `Presentation` ایجاد کنید.
1. به اولین اسلاید دسترسی پیدا کنید.
1. شکلی با متن جایگزین خاص پیدا کنید.
1. شکل را مخفی کنید.
1. فایل را بر روی دیسک ذخیره کنید.

```c#
 // ایجاد یک نمونه از کلاس Presentation که نمایانگر فایل PPTX است
 Presentation pres = new Presentation();

 // دریافت اولین اسلاید
 ISlide sld = pres.Slides[0];

 // اضافه کردن AutoShape از نوع مستطیل
 IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
 IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
 String alttext = "User Defined";
 int iCount = sld.Shapes.Count;
 for (int i = 0; i < iCount; i++)
 {
     AutoShape ashp = (AutoShape)sld.Shapes[i];
     if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
     {
         ashp.Hidden = true;
     }
 }

 // ذخیره ارائه در دیسک
 pres.Save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
```



## **تغییر ترتیب شکل**
Aspose.Slides for .NET به توسعه‌دهندگان اجازه می‌دهد ترتیب اشکال را تغییر دهند. تغییر ترتیب مشخص می‌کند کدام شکل در جلو قرار گیرد و کدام در پس‌زمینه. برای تغییر ترتیب شکل از هر اسلاید، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس `Presentation` ایجاد کنید.
1. به اولین اسلاید دسترسی پیدا کنید.
1. یک شکل اضافه کنید.
1. متنی را در فریم متن شکل اضافه کنید.
1. شکل دیگری با همان مختصات اضافه کنید.
1. اشکال را دوباره ترتیب دهید.
1. فایل را بر روی دیسک ذخیره کنید.

```c#
Presentation presentation1 = new Presentation("HelloWorld.pptx");
ISlide slide = presentation1.Slides[0];
IAutoShape shp3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
shp3.FillFormat.FillType = FillType.NoFill;
shp3.AddTextFrame(" ");

ITextFrame txtFrame = shp3.TextFrame;
IParagraph para = txtFrame.Paragraphs[0];
IPortion portion = para.Portions[0];
portion.Text="Watermark Text Watermark Text Watermark Text";
shp3 = slide.Shapes.AddAutoShape(ShapeType.Triangle, 200, 365, 400, 150);
slide.Shapes.Reorder(2, shp3);
presentation1.Save( "Reshape_out.pptx", SaveFormat.Pptx);
```


## **دریافت شناسه Interop Shape**
Aspose.Slides for .NET به توسعه‌دهندگان امکان دریافت یک شناسه یکتا برای شکل در محدوده اسلاید را می‌دهد، در مقابل ویژگی UniqueId که شناسه یکتا در سطح ارائه را فراهم می‌کند. ویژگی OfficeInteropShapeId به رابط IShape و کلاس Shape اضافه شده است. مقدار بازگردانده‌شده توسط ویژگی OfficeInteropShapeId معادل مقدار Id شیء Microsoft.Office.Interop.PowerPoint.Shape است. نمونه کد زیر ارائه شده است.

```c#
public static void Run()
{
	using (Presentation presentation = new Presentation("Presentation.pptx"))
	{
		// دریافت شناسه یکتا برای شکل در محدوده اسلاید
		long officeInteropShapeId = presentation.Slides[0].Shapes[0].OfficeInteropShapeId;
	}
}
```



## **تنظیم متن جایگزین برای یک شکل**
Aspose.Slides for .NET به توسعه‌دهندگان اجازه می‌دهد AlternateText هر شکل را تنظیم کنند. اشکال در یک ارائه می‌توانند با ویژگی AlternativeText یا نام Shape متمایز شوند. ویژگی AlternativeText می‌تواند توسط Aspose.Slides و همچنین Microsoft PowerPoint خوانده یا تنظیم شود. با استفاده از این ویژگی می‌توانید یک شکل را برچسب‌گذاری کنید و عملیات‌های مختلفی مانند حذف، مخفی‌سازی یا تغییر ترتیب اشکال در اسلاید را انجام دهید.
برای تنظیم AlternateText یک شکل، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس `Presentation` ایجاد کنید.
1. به اولین اسلاید دسترسی پیدا کنید.
1. هر شکلی را به اسلاید اضافه کنید.
1. کاری با شکل تازه اضافه‌شده انجام دهید.
1. از طریق اشکال پیمایش کنید تا شکل موردنظر را پیدا کنید.
1. مقدار AlternativeText را تنظیم کنید.
1. فایل را بر روی دیسک ذخیره کنید.

```c#
// ایجاد یک نمونه از کلاس Presentation که نمایانگر فایل PPTX است
Presentation pres = new Presentation();

// دریافت اولین اسلاید
ISlide sld = pres.Slides[0];

// اضافه کردن AutoShape از نوع مستطیل
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
shp2.FillFormat.FillType = FillType.Solid;
shp2.FillFormat.SolidFillColor.Color = Color.Gray;

for (int i = 0; i < sld.Shapes.Count; i++)
{
    var shape = sld.Shapes[i] as AutoShape;
    if (shape != null)
    {
        AutoShape ashp = shape;
        ashp.AlternativeText = "User Defined";
    }
}

// ذخیره ارائه در دیسک
pres.Save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
```




## **دسترسی به قالب‌های چیدمان برای یک شکل**
Aspose.Slides for .NET یک API ساده برای دسترسی به قالب‌های چیدمان یک شکل فراهم می‌کند. این مقاله نشان می‌دهد چگونه می‌توانید به قالب‌های چیدمان دسترسی پیدا کنید.

کد نمونه زیر ارائه شده است.

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
	foreach (ILayoutSlide layoutSlide in pres.LayoutSlides)
	{
		IFillFormat[] fillFormats = layoutSlide.Shapes.Select(shape => shape.FillFormat).ToArray();
		ILineFormat[] lineFormats = layoutSlide.Shapes.Select(shape => shape.LineFormat).ToArray();
	}
}
```

## **رندر یک شکل به‌صورت SVG**
اکنون Aspose.Slides for .NET از رندر کردن یک شکل به‌صورت SVG پشتیبانی می‌کند. متد WriteAsSvg (و overload آن) به کلاس Shape و رابط IShape اضافه شده است. این متد امکان ذخیره محتویات شکل به‌صورت یک فایل SVG را می‌دهد. اسنیپت کد زیر نشان می‌دهد چگونه شکل اسلاید را به یک فایل SVG صادر کنید.

```c#
public static void Run()
{
	string outSvgFileName = "SingleShape.svg";
	using (Presentation pres = new Presentation("TestExportShapeToSvg.pptx"))
	{
		using (Stream stream = new FileStream(outSvgFileName, FileMode.Create, FileAccess.Write))
		{
			pres.Slides[0].Shapes[0].WriteAsSvg(stream);
		}
	}
}
```

## **هم‌راستایی یک شکل**

از طریق متد [SlidesUtil.AlignShape()](https://reference.aspose.com/slides/fa/net/aspose.slides.util/slideutil/methods/alignshapes/index) می‌توانید

* اشکال را نسبت به حاشیه‌های اسلاید هم‌راستا کنید. مثال 1 را ببینید.
* اشکال را نسبت به یکدیگر هم‌راستا کنید. مثال 2 را ببینید.

enum [ShapesAlignmentType](https://reference.aspose.com/slides/fa/net/aspose.slides/shapesalignmenttype) گزینه‌های هم‌راستایی موجود را تعریف می‌کند.

**مثال 1**

این کد C# نشان می‌دهد چگونه اشکالی با ایندکس 1، 2 و 4 را در مرز بالایی اسلاید هم‌راستا کنید:
کد زیر اشکالی با ایندکس 1، 2 و 4 را در مرز بالایی اسلاید هم‌راستا می‌کند.

``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
     ISlide slide = pres.Slides[0];
     IShape shape1 = slide.Shapes[1];
     IShape shape2 = slide.Shapes[2];
     IShape shape3 = slide.Shapes[4];
     SlideUtil.AlignShapes(ShapesAlignmentType.AlignTop, true, pres.Slides[0], new int[]
     {
          slide.Shapes.IndexOf(shape1),
          slide.Shapes.IndexOf(shape2),
          slide.Shapes.IndexOf(shape3)
     });
}
```

**مثال 2**

این کد C# نشان می‌دهد چگونه یک مجموعه کامل از اشکال را نسبت به شکل پایین‌دست در مجموعه هم‌راستا کنید:

``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
    SlideUtil.AlignShapes(ShapesAlignmentType.AlignBottom, false, pres.Slides[0].Shapes);
}
```

## **ویژگی‌های Flip**

در Aspose.Slides، کلاس [ShapeFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/shapeframe/) کنترل آیینه‌سازی افقی و عمودی اشکال را از طریق ویژگی‌های `FlipH` و `FlipV` فراهم می‌کند. هر دو ویژگی از نوع [NullableBool](https://reference.aspose.com/slides/fa/net/aspose.slides/nullablebool/) هستند و می‌توانند مقادیر `True` برای چرخش، `False` برای عدم چرخش یا `NotDefined` برای رفتار پیش‌فرض را داشته باشند. این مقادیر از طریق [Frame](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/frame/) شکل در دسترس‌اند.

برای تغییر تنظیمات flip، یک نمونه جدید از [ShapeFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/shapeframe/) با موقعیت و اندازه فعلی شکل، مقادیر دلخواه برای `FlipH` و `FlipV` و زاویه چرخش ساخته می‌شود. اختصاص این نمونه به [Frame](https://reference.aspose.com/slides/fa/net/aspose.slides/ishape/frame/) شکل و ذخیره ارائه، تبدیل‌های آیینه را اعمال و در فایل خروجی ذخیره می‌کند.

فرض کنید فایلی به نام sample.pptx داریم که اسلاید اول آن حاوی یک شکل واحد با تنظیمات پیش‌فرض flip است، همان‌طور که در زیر نشان داده شده است.

![The shape to be flipped](shape_to_be_flipped.png)

کد زیر ویژگی‌های flip فعلی شکل را دریافت می‌کند و آن را به‌صورت افقی و عمودی معکوس می‌کند.

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];

    // دریافت ویژگی معکوس افقی شکل.
    NullableBool horizontalFlip = shape.Frame.FlipH;
    Console.WriteLine($"Horizontal flip: {horizontalFlip}");

    // دریافت ویژگی معکوس عمودی شکل.
    NullableBool verticalFlip = shape.Frame.FlipV;
    Console.WriteLine($"Vertical flip: {verticalFlip}");

    float x = shape.Frame.X;
    float y = shape.Frame.Y;
    float width = shape.Frame.Width;
    float height = shape.Frame.Height;
    NullableBool flipH = NullableBool.True; // معکوس افقی.
    NullableBool flipV = NullableBool.True; // معکوس عمودی.
    float rotation = shape.Frame.Rotation;

    shape.Frame = new ShapeFrame(x, y, width, height, flipH, flipV, rotation);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

نتیجه:

![The flipped shape](flipped_shape.png)

## **سوالات متداول**

**آیا می‌توانم اشکال (اتحاد/تقاطع/تفریق) را در اسلاید ترکیب کنم همانند یک ویرایشگر دسکتاپ؟**

API داخلی برای عملیات‌های بولی وجود ندارد. می‌توانید با ساخت نمودار دلخواه خود—مثلاً با استفاده از [GeometryPath](https://reference.aspose.com/slides/fa/net/aspose.slides/geometrypath/)—هندسهٔ نتیجه را محاسبه کنید و یک شکل جدید با آن کانتور بسازید و در صورت نیاز اشکال اصلی را حذف کنید.

**چگونه می‌توانم ترتیب لایه‌ها (z-order) را کنترل کنم تا یک شکل همیشه «در‑بالا» بماند؟**

ترتیب درج/جابه‌جایی را در مجموعه [shapes](https://reference.aspose.com/slides/fa/net/aspose.slides/baseslide/shapes/) اسلاید تغییر دهید. برای نتایج قابل پیش‌بینی، پس از تمام تغییرات اسلاید، ترتیب z را نهایی کنید.

**آیا می‌توانم یک شکل را «قفل» کنم تا کاربران در PowerPoint نتوانند آن را ویرایش کنند؟**

بله. پرچم‌های حفاظت سطح‑شکل را تنظیم کنید (مثلاً قفل انتخاب، حرکت، تغییر اندازه، ویرایش متن). در صورت نیاز، محدودیت‌ها را بر روی مستر یا لایه اعمال کنید. توجه داشته باشید این محافظت در سطح UI است و نه یک ویژگی امنیتی؛ برای حفاظت قوی‌تر می‌توانید آن را با محدودیت‌های سطح‑فایل مانند توصیه‌‏های فقط‑خواندنی یا رمز عبور ترکیب کنید.