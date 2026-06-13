---
title: مدیریت اشکال ارائه در جاوا
linktitle: دست‌کاری اشکال
type: docs
weight: 40
url: /fa/java/shape-manipulations/
keywords:
- شکل پاورپوینت
- شکل ارائه
- شکل روی اسلاید
- یافتن شکل
- کلون کردن شکل
- حذف شکل
- مخفی کردن شکل
- تغییر ترتیب شکل
- دریافت شناسه Interop شکل
- متن جایگزین شکل
- فرمت‌های چیدمان شکل
- شکل به صورت SVG
- شکل به SVG
- هم‌ترازی شکل
- پاورپوینت
- ارائه
- جاوا
- Aspose.Slides
description: "یادگیری ایجاد، ویرایش و بهینه‌سازی اشکال در Aspose.Slides برای جاوا و ارائه پرزنتیشن‌های پاورپوینت با عملکرد بالا."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد چگونه با استفاده از Aspose.Slides با اشکال در ارائه‌ها کار کنید. نشان می‌دهد چگونه یک شکل را در اسلاید پیدا کنید، آن را کلون کنید، حذف کنید، مخفی کنید، ترتیب آن را تغییر دهید، شناسه Interop شکل را دریافت کنید و متن جایگزین برای شناسایی و پردازش‌های بعدی تنظیم کنید.

همچنین نحوه دسترسی به فرمت‌های چیدمان برای اشکال، رندر کردن یک شکل به‌صورت SVG، هم‌ترازی اشکال در یک اسلاید و استفاده از ویژگی‌های flip برای آیینه‌گذاری افقی و عمودی را پوشش می‌دهد. علاوه بر این، مقاله شامل یک بخش FAQ کوتاه درباره ترکیب اشکال، ترتیب انباشتن و قفل‌گذاری شکل است.

## **یافتن یک شکل در اسلاید**
این موضوع یک تکنیک ساده را برای آسان‌تر کردن یافتن شکل خاصی در اسلاید بدون استفاده از شناسه داخلی‌اش توصیف می‌کند. مهم است بدانید فایل‌های ارائه PowerPoint هیچ راهی برای شناسایی اشکال در یک اسلاید به جز یک شناسه‌ی داخلی یکتا ندارند. برای توسعه‌دهندگان پیدا کردن شکل با استفاده از این شناسه داخلی دشوار است. تمام اشکالی که به اسلایدها اضافه می‌شوند دارای متنی جایگزین (Alt Text) هستند. ما به توسعه‌دهندگان پیشنهاد می‌کنیم برای یافتن شکل خاص، از متن جایگزین استفاده کنند. می‌توانید از MS PowerPoint برای تعریف متن جایگزین برای اشیائی که قصد تغییرشان را در آینده دارید، استفاده کنید.

پس از تنظیم متن جایگزین برای هر شکل دلخواه، می‌توانید همان ارائه را با Aspose.Slides for Java باز کنید و از طریق تمام اشکالی که به اسلاید اضافه شده‌اند، پیمایش کنید. در هر تکرار می‌توانید متن جایگزین شکل را بررسی کنید و شکلی که متن جایگزین آن مطابقت داشته باشد، همان شکلی است که نیاز دارید. برای نشان دادن این تکنیک به شکل بهتر، روشی به نام [findShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) ایجاد کرده‌ایم که این کار را انجام می‌دهد و سپس شکل مورد نظر را باز می‌گرداند.

```java
// یک نمونه از کلاس Presentation که نمایانگر فایل ارائه است را نمونه‌سازی کنید
Presentation pres = new Presentation("FindingShapeInSlide.pptx");
try {

    ISlide slide = pres.getSlides().get_Item(0);
    // متن جایگزین شکلی که باید پیدا شود
    IShape shape = findShape(slide, "Shape1");
    if (shape != null)
    {
        System.out.println("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) pres.dispose();
}
```
```java
// پیاده‌سازی متد برای یافتن یک شکل در اسلاید با استفاده از متن جایگزین آن
public static IShape findShape(ISlide slide, String alttext)
{
    // پیمایش تمام اشکال داخل اسلاید
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // اگر متن جایگزین اسلاید با متن مورد نیاز مطابقت داشته باشد سپس
        // شکل را برگردانید
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```

## **کلون کردن یک شکل**
برای کلون کردن یک شکل به اسلاید با استفاده از Aspose.Slides for Java:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
1. مرجع اسلاید را با استفاده از ایندکس آن بدست آورید.
1. به مجموعه اشکال اسلاید منبع دسترسی پیدا کنید.
1. اسلاید جدیدی به ارائه اضافه کنید.
1. اشکال را از مجموعه اشکال اسلاید منبع به اسلاید جدید کلون کنید.
1. ارائهٔ تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

کد زیر یک شکل گروهی را به اسلاید اضافه می‌کند.

```java
// یک نمونه از کلاس Presentation ایجاد کنید
Presentation pres = new Presentation("Source Frame.pptx");
try {
    IShapeCollection sourceShapes = pres.getSlides().get_Item(0).getShapes();
    ILayoutSlide blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destSlide = pres.getSlides().addEmptySlide(blankLayout);
    IShapeCollection destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);

    // فایل PPTX را روی دیسک ذخیره کنید
    pres.save("CloneShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **حذف یک شکل**
Aspose.Slides for Java به توسعه‌دهندگان امکان حذف هر شکلی را می‌دهد. برای حذف شکل از هر اسلاید، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
1. به اولین اسلاید دسترسی پیدا کنید.
1. شکلی با متن جایگزین خاص را پیدا کنید.
1. شکل را حذف کنید.
1. فایل را روی دیسک ذخیره کنید.

```java
// شیء Presentation را ایجاد کنید
Presentation pres = new Presentation();
try {
    // اولین اسلاید را دریافت کنید
    ISlide sld = pres.getSlides().get_Item(0);

    // افزودن AutoShape از نوع مستطیل
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String altText = "User Defined";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(0);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            sld.getShapes().remove(ashp);
        }
    }

    // ارائه را روی دیسک ذخیره کنید
    pres.save("RemoveShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **مخفی کردن یک شکل**
Aspose.Slides for Java به توسعه‌دهندگان امکان مخفی کردن هر شکلی را می‌دهد. برای مخفی کردن شکل از هر اسلاید، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
1. به اولین اسلاید دسترسی پیدا کنید.
1. شکلی با متن جایگزین خاص را پیدا کنید.
1. شکل را مخفی کنید.
1. فایل را روی دیسک ذخیره کنید.

```java
// یک نمونه از کلاس Presentation که نمایانگر فایل PPTX است ایجاد کنید
Presentation pres = new Presentation();
try {
    // اولین اسلاید را دریافت کنید
    ISlide sld = pres.getSlides().get_Item(0);

    // افزودن AutoShape از نوع مستطیل
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String alttext = "User Defined";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(i);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            ashp.setHidden(true);
        }
    }

    // ارائه را روی دیسک ذخیره کنید
    pres.save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تغییر ترتیب شکل**
Aspose.Slides for Java به توسعه‌دهندگان امکان تغییر ترتیب اشکال را می‌دهد. تغییر ترتیب تعیین می‌کند که کدام شکل در جلو و کدام شکل در پس‌زمینه قرار گیرد. برای تغییر ترتیب شکل در هر اسلاید، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
1. به اولین اسلاید دسترسی پیدا کنید.
1. یک شکل اضافه کنید.
1. متنی در فریم متن شکل اضافه کنید.
1. شکل دیگری با همان مختصات اضافه کنید.
1. ترتیب اشکال را تغییر دهید.
1. فایل را روی دیسک ذخیره کنید.

```java
Presentation pres = new Presentation("ChangeShapeOrder.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shp3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(FillType.NoFill);
    shp3.addTextFrame(" ");

    IParagraph para = shp3.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");

    shp3 = slide.getShapes().addAutoShape(ShapeType.Triangle, 200, 365, 400, 150);

    slide.getShapes().reorder(2, shp3);

    pres.save("Reshape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **دریافت شناسه Interop شکل**
Aspose.Slides for Java به توسعه‌دهندگان اجازه می‌دهد شناسهٔ یکتای شکل را در محدودهٔ اسلاید دریافت کنند، در مقایسه با روش [getUniqueId](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShape#getUniqueId--) که شناسهٔ یکتا را در محدودهٔ ارائه برمی‌گرداند. متد [getOfficeInteropShapeId](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShape#getOfficeInteropShapeId--) به اینترفیس‌های [IShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShape) و کلاس [Shape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Shape) اضافه شده است. مقدار برگردانده شده توسط متد [getOfficeInteropShapeId](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShape#getOfficeInteropShapeId--) معادل مقدار Id شیء Microsoft.Office.Interop.PowerPoint.Shape است. نمونهٔ کد زیر ارائه شده است.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // دریافت شناسهٔ یکتا شکل در دامنهٔ اسلاید
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```

## **تنظیم متن جایگزین برای یک شکل**
Aspose.Slides for Java به توسعه‌دهندگان امکان تنظیم AlternateText برای هر شکلی را می‌دهد.
اشکال در یک ارائه می‌توانند توسط متدهای [AlternativeText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) یا [Shape Name](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShape#setName-java.lang.String-) متفاوت شناسایی شوند.
متدهای [setAlternativeText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) و [getAlternativeText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShape#getAlternativeText--) می‌توانند توسط Aspose.Slides و همچنین Microsoft PowerPoint خوانده یا تنظیم شوند.
با استفاده از این متد می‌توانید یک شکل را برچسب‌گذاری کنید و عملیات‌های مختلفی مانند حذف، مخفی‌سازی یا تغییر ترتیب اشکال در اسلاید را انجام دهید.
برای تنظیم AlternateText یک شکل، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
1. به اولین اسلاید دسترسی پیدا کنید.
1. هر شکلی را به اسلاید اضافه کنید.
1. کاری با شکل جدید اضافه‌شده انجام دهید.
1. از میان اشکال عبور کنید تا شکل مورد نظر را پیدا کنید.
1. AlternativeText را تنظیم کنید.
1. فایل را روی دیسک ذخیره کنید.

```java
// یک نمونه از کلاس Presentation که نمایانگر فایل PPTX است ایجاد کنید
Presentation pres = new Presentation();
try {
    // اولین اسلاید را دریافت کنید
    ISlide sld = pres.getSlides().get_Item(0);

    // افزودن AutoShape از نوع مستطیل
    IShape shp1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    IShape shp2 = sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(FillType.Solid);
    shp2.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        AutoShape shape = (AutoShape) sld.getShapes().get_Item(i);
        if (shape != null)
        {
            shape.setAlternativeText("User Defined");
        }
    }

    // ارائه را روی دیسک ذخیره کنید
    pres.save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **دسترسی به فرمت‌های چیدمان برای یک شکل**
Aspose.Slides for Java یک API ساده برای دسترسی به فرمت‌های چیدمان یک شکل فراهم می‌کند. این مقاله نشان می‌دهد چگونه می‌توانید به فرمت‌های چیدمان دسترسی پیدا کنید.

کد نمونه زیر ارائه شده است.

```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (ILayoutSlide layoutSlide : pres.getLayoutSlides())
    {
        for (IShape shape : layoutSlide.getShapes())
        {
            IFillFormat fillFormats = shape.getFillFormat();
            ILineFormat lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **رندر کردن یک شکل به‌صورت SVG**
اکنون Aspose.Slides for Java قابلیت رندر کردن یک شکل به‌صورت SVG را دارد. متد [writeAsSvg](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (و overload آن) به کلاس [Shape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Shape) و اینترفیس [IShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShape) اضافه شده است. این متد امکان ذخیره محتوای شکل به‌صورت فایل SVG را فراهم می‌کند. قطعه کد زیر نشان می‌دهد چگونه شکل اسلاید را به فایل SVG صادر کنید.

```java
Presentation pres = new Presentation("TestExportShapeToSvg.pptx");
try {
    FileOutputStream stream = new FileOutputStream("SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) stream.close();
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **هم‌ترازی یک شکل**
Aspose.Slides امکان هم‌ترازی اشکال را نسبت به حاشیه‌های اسلاید یا نسبت به یکدیگر فراهم می‌کند. برای این منظور، متد overload شده‌ی [SlidesUtil.alignShape()](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) اضافه شده است. شمارشی [ShapesAlignmentType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ShapesAlignmentType) گزینه‌های هم‌ترازی ممکن را تعریف می‌کند.

**مثال 1**

کد منبع زیر اشکال با ایندکس‌های 1، 2 و 4 را در امتداد حاشیهٔ بالای اسلاید هم‌تراز می‌کند.

```java
Presentation pres = new Presentation("example.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IShape shape1 = slide.getShapes().get_Item(1);
    IShape shape2 = slide.getShapes().get_Item(2);
    IShape shape3 = slide.getShapes().get_Item(4);
    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), new int[]
    {
        slide.getShapes().indexOf(shape1),
        slide.getShapes().indexOf(shape2),
        slide.getShapes().indexOf(shape3)
    });
} finally {
    if (pres != null) pres.dispose();
}
}
```

**مثال 2**

مثال زیر نشان می‌دهد چگونه کل مجموعهٔ اشکال را نسبت به شکل پایین‌ترین در مجموعه هم‌تراز کنیم.

```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```

## **ویژگی‌های Flip**

در Aspose.Slides، کلاس [ShapeFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shapeframe/) کنترل آیینه‌گذاری افقی و عمودی اشکال را از طریق ویژگی‌های `flipH` و `flipV` فراهم می‌کند. هر دو ویژگی از نوع `byte` هستند و می‌توانند مقدار `1` برای چرخش، `0` برای عدم چرخش یا `-1` برای استفاده از رفتار پیش‌فرض را بپذیرند. این مقادیر از طریق [Frame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#getFrame--) شکل قابل دسترسی هستند.

برای تغییر تنظیمات flip، یک نمونهٔ جدید از [ShapeFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shapeframe/) با موقعیت و اندازهٔ فعلی شکل، مقادیر دلخواه برای `flipH` و `flipV` و زاویهٔ چرخش ساخته می‌شود. اختصاص این نمونه به [Frame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#getFrame--) شکل و ذخیرهٔ ارائه، تبدیل‌های آیینه‌ای را اعمال و در فایل خروجی ذخیره می‌کند.

فرض کنید فایلی به نام sample.pptx داریم که اسلاید اول آن شامل یک شکل واحد با تنظیمات پیش‌فرض flip است، همان‌طور که در زیر نشان داده شده است.

![شکل برای چرخش](shape_to_be_flipped.png)

کد زیر ویژگی‌های flip فعلی شکل را دریافت کرده و آن را به‌صورت افقی و عمودی چرخانده می‌کند.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    // دریافت ویژگی چرخش افقی شکل.
    byte horizontalFlip = shape.getFrame().getFlipH();
    System.out.println("Horizontal flip: " + horizontalFlip);

    // دریافت ویژگی چرخش عمودی شکل.
    byte verticalFlip = shape.getFrame().getFlipV();
    System.out.println("Vertical flip: " + verticalFlip);

    float x = shape.getFrame().getX();
    float y = shape.getFrame().getY();
    float width = shape.getFrame().getWidth();
    float height = shape.getFrame().getHeight();
    byte flipH = NullableBool.True; // Flip horizontally.
    byte flipV = NullableBool.True; // Flip horizontally.
    float rotation = shape.getFrame().getRotation();

    shape.setFrame(new ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![شکل چرخانده‌شده](flipped_shape.png)

## **سوالات متداول**

**آیا می‌توانم اشکال (اتحاد/اشتراک/تفریق) را در اسلاید مانند یک ویرایشگر دسکتاپ ترکیب کنم؟**

API داخلی برای عملیات بولی موجود نیست. می‌توانید با ساختن دستی outline مورد نظر — به عنوان مثال محاسبهٔ هندسهٔ نتیجه از طریق [GeometryPath](https://reference.aspose.com/slides/fa/java/com.aspose.slides/geometrypath/) و ایجاد یک شکل جدید با آن کانتور — و به‌صورت اختیاری حذف اشکال اصلی، به‌صورت تقریباً مشابه عمل کنید.

**چگونه می‌توانم ترتیب انباشتن (z-order) را کنترل کنم تا یک شکل همیشه «بالا» بماند؟**

ترتیب درج/انتقال را در مجموعهٔ [shapes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/baseslide/#getShapes--) اسلاید تغییر دهید. برای نتایج پیش‌بینی‌پذیر، پس از تمام تغییرات اسلاید، ترتیب z را نهایی کنید.

**آیا می‌توانم یک شکل را «قفل» کنم تا کاربران در PowerPoint نتوانند آن را ویرایش کنند؟**

بله. پرچم‌های حفاظت سطح‑شکل را تنظیم کنید (مانند قفل انتخاب، حرکت، تغییر اندازه، ویرایش متن). در صورت نیاز، این محدودیت‌ها را بر روی مستر یا چیدمان نیز اعمال کنید. توجه داشته باشید که این حفاظت در سطح رابط کاربری است و ویژگی امنیتی محسوب نمی‌شود؛ برای حفاظت قوی‌تر می‌توانید آن را با محدودیت‌های سطح فایل مثل توصیه‌های فقط‑خواندنی یا رمزعبور ترکیب کنید (/slides/fa/java/password-protected-presentation/).