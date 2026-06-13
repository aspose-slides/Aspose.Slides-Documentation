---
title: مدیریت اشکال ارائه در اندروید
linktitle: دست‌کاری اشکال
type: docs
weight: 40
url: /fa/androidjava/shape-manipulations/
keywords:
- شکل پاورپوینت
- شکل ارائه
- شکل در اسلاید
- یافتن شکل
- کلون کردن شکل
- حذف شکل
- پنهان کردن شکل
- تغییر ترتیب شکل
- دریافت شناسه Interop شکل
- متن جایگزین شکل
- فرمت‌های طرح‌بندی شکل
- شکل به‌صورت SVG
- شکل به SVG
- تراز کردن شکل
- پاورپوینت
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال را در Aspose.Slides برای اندروید از طریق جاوا ایجاد، ویرایش و بهینه کنید و ارائه‌های پاورپوینت با عملکرد بالا تحویل دهید."
---
## **بررسی کلی**

این مقاله نحوه کار با اشکال در ارائه‌ها با استفاده از Aspose.Slides را شرح می‌دهد. نشان می‌دهد چگونه می‌توان یک شکل را در اسلاید یافت، کلون کرد، حذف کرد، مخفی کرد، ترتیب آن را تغییر داد، شناسه Interop شکل را به‌دست آورد و متن جایگزین را برای شناسایی و پردازش‌های بعدی تنظیم کرد.

همچنین نحوه دسترسی به فرمت‌های طرح‌بندی برای اشکال، رندر یک شکل به‌صورت SVG، تراز کردن اشکال در اسلاید و استفاده از ویژگی‌های وارونه‌سازی برای آینه‌برداری افقی و عمودی را پوشش می‌دهد. علاوه بر این، مقاله شامل یک بخش کوتاه پرسش و پاسخ درباره ترکیب اشکال، ترتیب لایه‌ها و قفل کردن شکل‌ها است.

## **پیدا کردن یک شکل در اسلاید**
این موضوع یک تکنیک ساده را برای راحت‌تر کردن پیدا کردن شکل خاصی در اسلاید بدون استفاده از شناسه داخلی آن توصیف می‌کند. مهم است بدانید فایل‌های ارائه PowerPoint هیچ راهی برای شناسایی اشکال در یک اسلاید به‌جز یک شناسه یکتای داخلی ندارند. برای توسعه‌دهندگان یافتن شکل با استفاده از این شناسه یکتا می‌تواند دشوار باشد. تمام اشکالی که به اسلایدها اضافه می‌شوند دارای متن Alt هستند. ما به توسعه‌دهندگان پیشنهاد می‌کنیم برای یافتن شکل خاص، از متن جایگزین استفاده کنند. می‌توانید با استفاده از MS PowerPoint متن جایگزین برای اشیائی که قصد تغییرشان را در آینده دارید تعریف کنید.

پس از تنظیم متن جایگزین برای هر شکل دلخواه، می‌توانید آن ارائه را با Aspose.Slides برای Android از طریق Java باز کنید و در تمام اشکال اضافه‌شده به یک اسلاید تکرار کنید. در هر بار تکرار می‌توانید متن جایگزین شکل را بررسی کنید و شکلی که متن جایگزین آن مطابقت داشت، همان شکلی است که نیاز دارید. برای نشان دادن این تکنیک به‌صورت بهتر، ما روشی به نام [findShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) ایجاد کرده‌ایم که کار پیدا کردن یک شکل خاص در اسلاید را انجام می‌دهد و سادهاً آن شکل را برمی‌گرداند.

```java
// یک کلاس Presentation را که نشان‌دهنده فایل ارائه است، ایجاد کنید
Presentation pres = new Presentation("FindingShapeInSlide.pptx");
try {

    ISlide slide = pres.getSlides().get_Item(0);
    // متن جایگزین شکلی که باید یافت شود
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
// پیاده سازی متد برای یافتن یک شکل در اسلاید با استفاده از متن جایگزین آن
public static IShape findShape(ISlide slide, String alttext)
{
    // در حال مرور تمام اشکال داخل اسلاید
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // اگر متن جایگزین اسلاید با متن مورد نیاز مطابقت داشته باشد سپس
        // شکل را بازگردانید
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```

## **کلون‌کردن یک شکل**
برای کلون کردن یک شکل به اسلاید با Aspose.Slides برای Android از طریق Java:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
1. مرجع یک اسلاید را با استفاده از ایندکس آن به‌دست آورید.
1. به مجموعه شکل‌های اسلاید منبع دسترسی پیدا کنید.
1. یک اسلاید جدید به ارائه اضافه کنید.
1. شکل‌ها را از مجموعه شکل‌های اسلاید منبع به اسلاید جدید کلون کنید.
1. ارائه اصلاح‌شده را به‌عنوان فایل PPTX ذخیره کنید.

مثال زیر یک شکل گروهی را به اسلاید اضافه می‌کند.

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
Aspose.Slides برای Android از طریق Java به توسعه‌دهندگان اجازه می‌دهد هر شکلی را حذف کنند. برای حذف شکل از هر اسلاید، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
1. به اسلاید اول دسترسی پیدا کنید.
1. شکل با متن جایگزین خاص را پیدا کنید.
1. شکل را حذف کنید.
1. فایل را روی دیسک ذخیره کنید.

```java
// شی Presentation را ایجاد کنید
Presentation pres = new Presentation();
try {
    // اولین اسلاید را دریافت کنید
    ISlide sld = pres.getSlides().get_Item(0);

    // افزودن شکل خودکار از نوع مستطیل
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

## **پنهان کردن یک شکل**
Aspose.Slides برای Android از طریق Java به توسعه‌دهندگان اجازه می‌دهد هر شکلی را مخفی کنند. برای مخفی کردن شکل از هر اسلاید، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
1. به اسلاید اول دسترسی پیدا کنید.
1. شکل با متن جایگزین خاص را پیدا کنید.
1. شکل را مخفی کنید.
1. فایل را روی دیسک ذخیره کنید.

```java
// یک نمونه از کلاس Presentation که نمایانگر فایل PPTX است، ایجاد کنید
Presentation pres = new Presentation();
try {
    // اولین اسلاید را دریافت کنید
    ISlide sld = pres.getSlides().get_Item(0);

    // افزودن شکل خودکار از نوع مستطیل
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
Aspose.Slides برای Android از طریق Java به توسعه‌دهندگان اجازه می‌دهد ترتیب اشکال را تغییر دهند. تغییر ترتیب مشخص می‌کند کدام شکل در جلو و کدام در پس‌زمینه قرار می‌گیرد. برای تغییر ترتیب شکل از هر اسلاید، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
1. به اسلاید اول دسترسی پیدا کنید.
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
Aspose.Slides برای Android از طریق Java به توسعه‌دهندگان امکان دریافت یک شناسه یکتا برای شکل در سطح اسلاید را می‌دهد که با متد [getUniqueId](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShape#getUniqueId--) که شناسه یکتا در سطح ارائه را برمی‌گرداند، متفاوت است. متد [getOfficeInteropShapeId](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) به اینترفیس [IShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShape) و کلاس [Shape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Shape) اضافه شده است. مقداری که توسط متد [getOfficeInteropShapeId](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) برگردانده می‌شود، معادل مقدار Id شیء Microsoft.Office.Interop.PowerPoint.Shape است. نمونه کد زیر آورده شده است.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // دریافت شناسه یکتای شکل در محدوده اسلاید
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```

## **تنظیم متن جایگزین برای یک شکل**
Aspose.Slides برای Android از طریق Java به توسعه‌دهندگان اجازه می‌دهد متن جایگزین (AlternateText) هر شکل را تنظیم کنند.
اشکال در یک ارائه می‌توانند با استفاده از متد [AlternativeText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) یا [Shape Name](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShape#setName-java.lang.String-) متمایز شوند.
متدهای [setAlternativeText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) و [getAlternativeText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShape#getAlternativeText--) می‌توانند هم با Aspose.Slides و هم با Microsoft PowerPoint خوانده یا تنظیم شوند.
با استفاده از این روش می‌توانید یک شکل را برچسب‌گذاری کنید و عملیات مختلفی مانند حذف، مخفی‌سازی یا تغییر ترتیب اشکال روی اسلاید را انجام دهید.
برای تنظیم AlternateText یک شکل، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
1. به اسلاید اول دسترسی پیدا کنید.
1. هر شکلی را به اسلاید اضافه کنید.
1. برخی کارها را با شکل تازه اضافه‌شده انجام دهید.
1. از میان اشکال عبور کنید تا شکلی را پیدا کنید.
1. متن جایگزین را تنظیم کنید.
1. فایل را روی دیسک ذخیره کنید.

```java
// یک نمونه از کلاس Presentation که نمایانگر فایل PPTX است، ایجاد کنید
Presentation pres = new Presentation();
try {
    // اولین اسلاید را دریافت کنید
    ISlide sld = pres.getSlides().get_Item(0);

    // افزودن شکل خودکار از نوع مستطیل
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

## **دسترسی به فرمت‌های طرح‌بندی برای یک شکل**
Aspose.Slides برای Android از طریق Java یک API ساده برای دسترسی به فرمت‌های طرح‌بندی یک شکل فراهم می‌کند. این مقاله نشان می‌دهد چگونه می‌توانید به فرمت‌های طرح‌بندی دسترسی پیدا کنید.

نمونه کد زیر آورده شده است.

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

## **رندر یک شکل به‌صورت SVG**
اکنون Aspose.Slides برای Android از طریق Java از رندر یک شکل به‌صورت SVG پشتیبانی می‌کند. متد [writeAsSvg](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) (و overload آن) به کلاس [Shape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Shape) و اینترفیس [IShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShape) اضافه شده است. این متد امکان ذخیره محتوای شکل به‌عنوان فایل SVG را فراهم می‌کند. قطعه کد زیر نشان می‌دهد چگونه شکل اسلاید را به فایل SVG صادر کنید.

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

## **تراز کردن یک شکل**
Aspose.Slides امکان تراز کردن اشکال را نسبت به حاشیه‌های اسلاید یا نسبت به یکدیگر فراهم می‌کند. برای این منظور، متد overload شده [SlidesUtil.alignShape()](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) اضافه شده است. شمارش [ShapesAlignmentType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ShapesAlignmentType) گزینه‌های ممکن تراز را تعریف می‌کند.

**مثال 1**

کد منبع زیر اشکال با ایندکس‌های 1، 2 و 4 را در بالای حاشیه اسلاید تراز می‌کند.

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

مثال زیر نشان می‌دهد چگونه تمام مجموعه اشکال را نسبت به شکل پایین‌ترین در مجموعه تراز کنید.

```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```

## **ویژگی‌های چرخش**
در Aspose.Slides، کلاس [ShapeFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shapeframe/) کنترل آینه‌برداری افقی و عمودی اشکال را از طریق ویژگی‌های `flipH` و `flipV` فراهم می‌کند. هر دو ویژگی از نوع `byte` هستند و مقادیر `1` برای وارونه‌سازی، `0` برای بدون وارونه‌سازی یا `-1` برای استفاده از رفتار پیش‌فرض را می‌پذیرند. این مقادیر از طریق [Frame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#getFrame--) شکل قابل دسترس هستند.

برای تغییر تنظیمات واروره‌سازی، یک نمونه جدید از [ShapeFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shapeframe/) با موقعیت و اندازه فعلی شکل، مقادیر دلخواه برای `flipH` و `flipV` و زاویه چرخش ساخته می‌شود. انتساب این نمونه به [Frame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#getFrame--) شکل و سپس ذخیره ارائه، تبدیل‌های آینه‌ای را اعمال و در فایل خروجی ذخیره می‌کند.

فرض کنید فایلی به نام sample.pptx داریم که اسلاید اول آن شامل یک شکل تک با تنظیمات وارونه‌سازی پیش‌فرض است، همان‌طور که در زیر نشان داده شده است.

![The shape to be flipped](shape_to_be_flipped.png)

کد زیر ویژگی‌های وارونه‌سازی فعلی شکل را دریافت کرده و آن را به‌صورت افقی و عمودی وارونه می‌کند.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    // دریافت ویژگی وارونه‌سازی افقی شکل.
    byte horizontalFlip = shape.getFrame().getFlipH();
    System.out.println("Horizontal flip: " + horizontalFlip);

    // دریافت ویژگی وارونه‌سازی عمودی شکل.
    byte verticalFlip = shape.getFrame().getFlipV();
    System.out.println("Vertical flip: " + verticalFlip);

    float x = shape.getFrame().getX();
    float y = shape.getFrame().getY();
    float width = shape.getFrame().getWidth();
    float height = shape.getFrame().getHeight();
    byte flipH = NullableBool.True; // وارونه‌سازی افقی.
    byte flipV = NullableBool.True; // وارونه‌سازی افقی.
    float rotation = shape.getFrame().getRotation();

    shape.setFrame(new ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

نتیجه:

![The flipped shape](flipped_shape.png)

## **FAQ**

**آیا می‌توانم اشکال (اتحاد/تقاطع/تفریق) را در اسلاید همانند یک ویرایشگر دسکتاپ ترکیب کنم؟**

یک API عملیات Boolean داخلی وجود ندارد. می‌توانید با ساختن شکل جدیدی که مسیر دلخواه را دارد (مثلاً با استفاده از [GeometryPath](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/geometrypath/)) و حذف اشکال اصلی، به‌صورت تقریبی این کار را انجام دهید.

**چگونه می‌توانم ترتیب لایه‌ها (z-order) را کنترل کنم تا یک شکل همیشه «در بالا» بماند؟**

ترتیب وارد/جابه‌جایی در مجموعه [shapes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/baseslide/#getShapes--) اسلاید را تغییر دهید. برای نتایج پیش‌بینی‌پذیر، پس از تمام تغییرات دیگر اسلاید، ترتیب z را نهایی کنید.

**آیا می‌توانم شکلی را «قفل» کنم تا کاربران در PowerPoint نتوانند آن را ویرایش کنند؟**

بله. پرچم‌های محافظت سطح شکل (مانند قفل انتخاب، حرکت، تغییر اندازه، ویرایش متن) را تنظیم کنید. در صورت نیاز می‌توانید محدودیت‌ها را روی مستر یا لayout اعمال کنید. توجه داشته باشید این حفاظت سطح UI است و ویژگی امنیتی نیست؛ برای حفاظت قوی‌تر می‌توانید آن را با محدودیت‌های سطح فایل مانند [پیشنهادات فقط‌خواندنی یا رمز عبور](/slides/fa/androidjava/password-protected-presentation/) ترکیب کنید.