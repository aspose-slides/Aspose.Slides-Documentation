---
title: دریافت ویژگی‌های مؤثر شکل از ارائه‌ها در جاوا
linktitle: ویژگی‌های مؤثر
type: docs
weight: 50
url: /fa/java/shape-effective-properties/
keywords:
- ویژگی‌های شکل
- ویژگی‌های دوربین
- نورپردازی
- شکل با برجستگی
- قاب متن
- سبک متن
- ارتفاع قلم
- قالب پر
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "کشف کنید Aspose.Slides برای جاوا چگونه ویژگی‌های مؤثر شکل را محاسبه و اعمال می‌کند تا رندر دقیق PowerPoint فراهم شود."
---
## **بررسی کلی**

این موضوع تفاوت بین ویژگی‌های **محلی** و **موثر** را توضیح می‌دهد. مقادیر محلی مقادیرى هستند که مستقیماً در سطح خاصی از قالب‌بندی تنظیم می‌شوند، مانند:

1. ویژگی‌های بخش در یک اسلاید.
1. سبک‌های متن شکل نمونه در یک طرح‌بندی یا اسلاید اصلی، هنگامی که شکل قاب متن بخش دارای یک سبک باشد.
1. تنظیمات متنی سراسری در یک ارائه.

مقادیر محلی می‌توانند در هر سطحی تعریف یا حذف شوند. وقتی Aspose.Slides به قالب‌بندی نهایی «به‌صورت رندر شده» نیاز دارد، زنجیره ارث‌بری را حل می‌کند و مقادیر **موثر** را برمی‌گرداند. می‌توانید این مقادیر را با فراخوانی متد `getEffective` بر روی شیء قالب‌بندی محلی به دست آورید.

مثال زیر نشان می‌دهد چگونه مقادیر موثر را دریافت کنید. فرض می‌شود اولین شکل در اولین اسلاید یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IAutoShape) با یک قاب متن و حداقل یک بخش باشد.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormat localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = paragraph.getPortions().get_Item(0);
    IPortionFormat localPortionFormat = portion.getPortionFormat();
    IPortionFormatEffectiveData effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="info" %}}
داده‌های قالب‌بندی مؤثر نمایانگر قالب‌بندی محاسبه‌شده فعلی پس از اعمال ارث‌بری هستند. در پیاده‌سازی فعلی، برخی از اشیاء داده مؤثر، مانند [IPortionFormatEffectiveData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPortionFormatEffectiveData)، ممکن است به‌صورت داخلی کش شوند. فراخوانی دوباره `getEffective` پس از تغییر قالب‌بندی والد یا ارث‌بری می‌تواند کش را تازه‌سازی کند و شیء‌ای که قبلاً دریافت شده ممکن است دیگر وضعیت قبلی را نشان ندهد. اگر نیاز به حفظ مقادیر مؤثر برای استفاده مجدد در آینده دارید، خواص مورد نیاز مانند ارتفاع قلم، رنگ پر، سبک قلم یا تراز را به شیء داده خودتان کپی کنید.
{{% /alert %}}

## **دریافت ویژگی‌های مؤثر یک دوربین**

Aspose.Slides به شما امکان می‌دهد ویژگی‌های مؤثر یک دوربین را دریافت کنید. اینترفیس [ICameraEffectiveData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ICameraEffectiveData) یک شیء غیرقابل تغییر است که ویژگی‌های مؤثر دوربین را شامل می‌شود. یک نمونهٔ [ICameraEffectiveData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ICameraEffectiveData) از طریق [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IThreeDFormatEffectiveData) در دسترس است که مقادیر مؤثر برای [IThreeDFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IThreeDFormat) را فراهم می‌کند.

نمونه کد زیر نشان می‌دهد چگونه ویژگی‌های مؤثر دوربین را دریافت کنید. فرض می‌شود اولین شکل در اولین اسلاید دارای قالب‌بندی 3D باشد.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ICameraEffectiveData cameraEffectiveData = threeDEffectiveData.getCamera();
    int cameraType = cameraEffectiveData.getCameraType();
    double fieldOfViewAngle = cameraEffectiveData.getFieldOfViewAngle();
    double zoom = cameraEffectiveData.getZoom();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + cameraType);
    System.out.println("Field of view: " + fieldOfViewAngle);
    System.out.println("Zoom: " + zoom);
} finally {
    presentation.dispose();
}
```

## **دریافت ویژگی‌های مؤثر یک نورپردازی**

Aspose.Slides به شما امکان می‌دهد ویژگی‌های مؤثر یک نورپردازی را دریافت کنید. اینترفیس [ILightRigEffectiveData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ILightRigEffectiveData) یک شیء غیرقابل تغییر است که ویژگی‌های مؤثر نورپردازی را شامل می‌شود. یک نمونهٔ [ILightRigEffectiveData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ILightRigEffectiveData) از طریق [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IThreeDFormatEffectiveData) در دسترس است که مقادیر مؤثر برای [IThreeDFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IThreeDFormat) را فراهم می‌کند.

نمونه کد زیر نشان می‌دهد چگونه ویژگی‌های مؤثر نورپردازی را دریافت کنید. فرض می‌شود اولین شکل در اولین اسلاید دارای قالب‌بندی 3D باشد.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ILightRigEffectiveData lightRigEffectiveData = threeDEffectiveData.getLightRig();
    int lightType = lightRigEffectiveData.getLightType();
    int direction = lightRigEffectiveData.getDirection();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + lightType);
    System.out.println("Direction: " + direction);
} finally {
    presentation.dispose();
}
```

## **دریافت ویژگی‌های مؤثر یک کانتور شکل**

Aspose.Slides به شما امکان می‌دهد ویژگی‌های مؤثر یک کانتور شکل را دریافت کنید. اینترفیس [IShapeBevelEffectiveData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShapeBevelEffectiveData) یک شیء غیرقابل تغییر است که ویژگی‌های مؤثر برجستگی شکل را شامل می‌شود. یک نمونهٔ [IShapeBevelEffectiveData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShapeBevelEffectiveData) از طریق [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IThreeDFormatEffectiveData) در دسترس است که مقادیر مؤثر برای [IThreeDFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IThreeDFormat) را فراهم می‌کند.

نمونه کد زیر نشان می‌دهد چگونه ویژگی‌های مؤثر بالای کانتور یک شکل را دریافت کنید. فرض می‌شود اولین شکل در اولین اسلاید دارای قالب‌بندی 3D باشد.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    IShapeBevelEffectiveData bevelTop = threeDEffectiveData.getBevelTop();
    int bevelType = bevelTop.getBevelType();
    double bevelWidth = bevelTop.getWidth();
    double bevelHeight = bevelTop.getHeight();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + bevelType);
    System.out.println("Width: " + bevelWidth);
    System.out.println("Height: " + bevelHeight);
} finally {
    presentation.dispose();
}
```

## **دریافت ویژگی‌های مؤثر یک قاب متن**

با استفاده از Aspose.Slides می‌توانید ویژگی‌های مؤثر یک قاب متن را دریافت کنید. اینترفیس [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITextFrameFormatEffectiveData) شامل ویژگی‌های قالب‌بندی مؤثر قاب متن است.

نمونه کد زیر نشان می‌دهد چگونه ویژگی‌های مؤثر قالب‌بندی قاب متن را دریافت کنید. فرض می‌شود اولین شکل در اولین اسلاید یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IAutoShape) با یک قاب متن باشد.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrameFormat.getEffective();
    int anchoringType = effectiveTextFrameFormat.getAnchoringType();
    int autofitType = effectiveTextFrameFormat.getAutofitType();
    int textVerticalType = effectiveTextFrameFormat.getTextVerticalType();
    double marginLeft = effectiveTextFrameFormat.getMarginLeft();
    double marginTop = effectiveTextFrameFormat.getMarginTop();
    double marginRight = effectiveTextFrameFormat.getMarginRight();
    double marginBottom = effectiveTextFrameFormat.getMarginBottom();

    System.out.println("Anchoring type: " + anchoringType);
    System.out.println("Autofit type: " + autofitType);
    System.out.println("Text vertical type: " + textVerticalType);
    System.out.println("Margins");
    System.out.println("   Left: " + marginLeft);
    System.out.println("   Top: " + marginTop);
    System.out.println("   Right: " + marginRight);
    System.out.println("   Bottom: " + marginBottom);
} finally {
    presentation.dispose();
}
```

## **دریافت ویژگی‌های مؤثر یک سبک متن**

با استفاده از Aspose.Slides می‌توانید ویژگی‌های مؤثر یک سبک متن را دریافت کنید. اینترفیس [ITextStyleEffectiveData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITextStyleEffectiveData) شامل ویژگی‌های مؤثر سبک متن است.

نمونه کد زیر نشان می‌دهد چگونه ویژگی‌های مؤثر سبک متن را دریافت کنید. فرض می‌شود اولین شکل در اولین اسلاید یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IAutoShape) با یک قاب متن باشد.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);
    
    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    int levelCount = 9;

    for (int levelIndex = 0; levelIndex < levelCount; levelIndex++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);
        int depth = effectiveStyleLevel.getDepth();
        double indent = effectiveStyleLevel.getIndent();
        int alignment = effectiveStyleLevel.getAlignment();
        int fontAlignment = effectiveStyleLevel.getFontAlignment();
        System.out.println("= Effective paragraph formatting for style level #" + levelIndex + " =");

        System.out.println("Depth: " + depth);
        System.out.println("Indent: " + indent);
        System.out.println("Alignment: " + alignment);
        System.out.println("Font alignment: " + fontAlignment);
    }
} finally {
    presentation.dispose();
}
```

## **دریافت مقدار ارتفاع قلم مؤثر**

با استفاده از Aspose.Slides می‌توانید ارتفاع قلم مؤثر را دریافت کنید. کد زیر نشان می‌دهد چگونه ارتفاع قلم مؤثر یک بخش پس از تنظیم مقادیر محلی ارتفاع قلم در سطوح مختلف ساختار ارائه تغییر می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    autoShape.addTextFrame("");

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    IPortion firstPortion = new Portion("Sample text with first portion");
    IPortion secondPortion = new Portion(" and second portion.");

    paragraph.getPortions().add(firstPortion);
    paragraph.getPortions().add(secondPortion);

    IPortionFormatEffectiveData firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    IPortionFormatEffectiveData secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height just after creation:");
    double firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    double secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting the presentation default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting paragraph default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    firstPortion.getPortionFormat().setFontHeight(55);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting portion #0 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    secondPortion.getPortionFormat().setFontHeight(18);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height after setting portion #1 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **دریافت قالب‌بندی پر مؤثر برای جدول**

با استفاده از Aspose.Slides می‌توانید قالب‌بندی پر مؤثر برای بخش‌های مختلف جدول را دریافت کنید. اینترفیس [IFillFormatEffectiveData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IFillFormatEffectiveData) شامل ویژگی‌های قالب‌بندی پر مؤثر است. قالب‌بندی سلول نسبت به قالب‌بندی ردیف اولویت بالاتری دارد، قالب‌بندی ردیف نسبت به قالب‌بندی ستون اولویت بالاتری دارد و قالب‌بندی ستون نسبت به قالب‌بندی کل جدول اولویت بالاتری دارد.

در نتیجه، ویژگی‌های [ICellFormatEffectiveData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ICellFormatEffectiveData) برای رسم سلول جدول استفاده می‌شود. نمونه کد زیر نشان می‌دهد چگونه قالب‌بندی پر مؤثر برای بخش‌های مختلف جدول را دریافت کنید. فرض می‌شود اولین شکل در اولین اسلاید یک [ITable](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITable) باشد.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable)slide.getShapes().get_Item(0);
    
    ITableFormatEffectiveData tableFormatEffective = table.getTableFormat().getEffective();
    IRowFormatEffectiveData rowFormatEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    IColumnFormatEffectiveData columnFormatEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    ICellFormatEffectiveData cellFormatEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    IFillFormatEffectiveData tableFillFormatEffective = tableFormatEffective.getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = rowFormatEffective.getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = columnFormatEffective.getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    presentation.dispose();
}
```

## **پرسش‌های متداول**

### آیا `getEffective` یک تصویر لحظه‌ای برمی‌گرداند؟

همیشه نیست. داده‌های مؤثر نمایانگر قالب‌بندی محاسبه‌شده پس از اعمال ارث‌بری هستند، اما برخی از اشیاء داده مؤثر ممکن است به‌صورت داخلی کش شوند. فراخوانی بعدی `getEffective` ممکن است قالب‌بندی را دوباره محاسبه کرده و کش را تازه‌سازی کند، بنابراین شیء‌ای که قبلاً به دست آمده نباید به‌عنوان تصویری ثابت در نظر گرفته شود.

### چه زمانی باید دوباره ویژگی‌های مؤثر را بخوانم؟

پس از تغییر قالب‌بندی محلی، سبک‌های والد، قالب‌بندی طرح‌بندی، قالب‌بندی اصلی یا مقادیر پیش‌فرض در سطح ارائه، `getEffective` را دوباره فراخوانی کنید. فراخوانی بعدی سلسله مراتب قالب‌بندی را دوباره ارزیابی کرده و نتیجه مؤثر فعلی را برمی‌گرداند.

### آیا تغییر یا حذف یک اسلاید طرح‌بندی/اصلی بر ویژگی‌های مؤثری که پیش‌تر دریافت شده‌اند تأثیر می‌گذارد؟

بله، اما تغییرات در فراخوانی بعدی `getEffective` اعمال می‌شود. اگر منبع قالب‌بندی والد تغییر یا حذف شود، داده‌های مؤثری که قبلاً به دست آمده ممکن است منسوخ شوند. پس از فراخوانی مجدد `getEffective`، Aspose.Slides درخت قالب‌بندی را دوباره ارزیابی می‌کند و قلم‌ها، رنگ‌ها، اندازه‌ها یا مقادیر دیگر ممکن است تغییر کنند.

### آیا می‌توانم مقادیر را از طریق اشیاء داده مؤثر تغییر دهم؟

نه. اشیاء داده مؤثر فقط مقادیر محاسبه‌شده را نشان می‌دهند. تغییرات را در اشیاء قالب‌بندی محلی اعمال کنید و سپس مقادیر مؤثر را دوباره دریافت کنید.

### اگر یک ویژگی در سطح شکل، طرح‌بندی/اصلی یا تنظیمات سراسری تنظیم نشده باشد چه اتفاقی می‌افتد؟

مقدار مؤثر توسط مکانیزم پیش‌فرض، که شامل پیش‌فرض‌های PowerPoint و Aspose.Slides است، تعیین می‌شود. آن مقدار حل‌شده جزئی از داده‌های مؤثر فعلی می‌شود.

### آیا از مقدار فونت مؤثر می‌توانم بفهمم که کدام سطح اندازه یا نوع قلم را فراهم کرده است؟

به‌صورت مستقیم نمی‌شود. داده‌های مؤثر فقط مقدار نهایی را برمی‌گردانند. برای یافتن منبع، مقادیر محلی را در بخش، پاراگراف، قاب متن و سبک‌های متن در سطوح طرح‌بندی، اصلی و ارائه بررسی کنید تا اولین تعریف صریح را بیابید.

### چرا گاهی مقادیر مؤثر دقیقا مشابه مقادیر محلی به نظر می‌رسند؟

چون مقدار محلی در نهایت نهایی شده است (هیچ ارث‌بری سطح بالاتری لازم نبوده). در این موارد مقدار مؤثر با مقدار محلی یکسان است.

### چه موقع باید از ویژگی‌های مؤثر استفاده کنم و چه موقع فقط با ویژگی‌های محلی کار کنم؟

وقتی به نتیجه «به‌صورت رندر شده» پس از اعمال تمام ارث‌بری‌ها نیاز دارید (مانند هم‌راستاسازی رنگ‌ها، تورفتگی‌ها یا اندازه‌ها) از داده‌های مؤثر استفاده کنید. اگر نیاز دارید این مقادیر را صرف‌نظر از تغییرات بعدی قالب‌بندی حفظ کنید، خواص مورد نیاز را به شیء خودتان کپی کنید. اگر می‌خواهید قالب‌بندی را در سطح خاصی تغییر دهید، ویژگی‌های محلی را اصلاح کنید و سپس، در صورت نیاز، داده‌های مؤثر را دوباره بخوانید تا نتیجه را تأیید کنید.