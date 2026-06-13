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
- شکل برش
- قاب متن
- سبک متن
- ارتفاع قلم
- قالب پرکردن
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "کشف کنید چگونه Aspose.Slides برای Java ویژگی‌های مؤثر شکل را محاسبه و اعمال می‌کند تا رندر دقیق PowerPoint فراهم شود."
---
## **نمای کلی**

این موضوع تفاوت بین ویژگی‌های **محلی** و **موثر** را توضیح می‌دهد. مقادیر محلی، مقادیری هستند که مستقیماً در یک سطح خاص قالب‌بندی تنظیم می‌شوند، مانند:

1. ویژگی‌های Portion در یک اسلاید.
1. سبک‌های متن شکل prototype در یک layout یا master slide، وقتی شکل فریم متن portion دارای آن باشد.
1. تنظیمات متن سراسری در یک ارائه.

مقادیر محلی می‌توانند در هر سطحی تعریف یا حذف شوند. هنگامی که Aspose.Slides به قالب‌بندی نهایی «به صورت رندر شده» نیاز دارد، زنجیرهٔ وراثت را حل می‌کند و مقادیر **موثر** را بازمی‌گرداند. می‌توانید این مقادیر را با فراخوانی متد `getEffective` روی شیء قالب‌بندی محلی به دست آورید.

مثال زیر نشان می‌دهد چگونه مقادیر مؤثر را به دست آورید. فرض می‌شود که اولین شکل در اولین اسلاید یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IAutoShape) با یک فریم متن و حداقل یک portion باشد.

```java
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

{{% alert color="primary" %}}
داده‌های قالب‌بندی مؤثر نشان‌دهنده قالب‌بندی محاسبه‌شدهٔ فعلی پس از اعمال وراثت هستند. در پیاده‌سازی فعلی، برخی از اشیای داده مؤثر، مانند [IPortionFormatEffectiveData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IPortionFormatEffectiveData)، ممکن است به‌صورت داخلی کش شوند. فراخوانی مجدد `getEffective` پس از تغییر قالب‌بندی والد یا وراثت می‌تواند داده‌های کش شده را تازه‌سازی کند و شیء قبلاً به‌دست آمده ممکن است دیگر وضعیت قبلی را نشان ندهد. اگر نیاز دارید مقادیر مؤثر را برای استفادهٔ بعدی حفظ کنید، ویژگی‌های مورد نیاز مانند ارتفاع قلم، رنگ پرش، سبک قلم یا تراز را در شیء دادهٔ خود کپی کنید.
{{% /alert %}}

## **دریافت ویژگی‌های مؤثر دوربین**

Aspose.Slides به شما امکان دریافت ویژگی‌های مؤثر یک دوربین را می‌دهد. رابط [ICameraEffectiveData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ICameraEffectiveData) نشان‌دهندهٔ یک شیء غیرقابل تغییر است که شامل ویژگی‌های مؤثر دوربین می‌باشد. یک نمونهٔ [ICameraEffectiveData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ICameraEffectiveData) از طریق [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IThreeDFormatEffectiveData) در دسترس قرار می‌گیرد که مقادیر مؤثر برای [IThreeDFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IThreeDFormat) را فراهم می‌کند.

نمونهٔ کد زیر نشان می‌دهد چگونه ویژگی‌های مؤثر دوربین را به دست آورید. فرض می‌شود که اولین شکل در اولین اسلاید دارای قالب‌بندی 3D باشد.

```java
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

## **دریافت ویژگی‌های مؤثر نورپردازی (Light Rig)**

Aspose.Slides به شما امکان دریافت ویژگی‌های مؤثر یک نورپردازی را می‌دهد. رابط [ILightRigEffectiveData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ILightRigEffectiveData) نشان‌دهندهٔ یک شیء غیرقابل تغییر است که شامل ویژگی‌های مؤثر نورپردازی می‌باشد. یک نمونهٔ [ILightRigEffectiveData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ILightRigEffectiveData) از طریق [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IThreeDFormatEffectiveData) در دسترس قرار می‌گیرد که مقادیر مؤثر برای [IThreeDFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IThreeDFormat) را فراهم می‌کند.

نمونهٔ کد زیر نشان می‌دهد چگونه ویژگی‌های مؤثر نورپردازی را به دست آورید. فرض می‌شود که اولین شکل در اولین اسلاید دارای قالب‌بندی 3D باشد.

```java
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

## **دریافت ویژگی‌های مؤثر برش (Bevel) یک شکل**

Aspose.Slides به شما امکان دریافت ویژگی‌های مؤثر برش یک شکل را می‌دهد. رابط [IShapeBevelEffectiveData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShapeBevelEffectiveData) نشان‌دهندهٔ یک شیء غیرقابل تغییر است که شامل ویژگی‌های مؤثر Relief برای یک شکل می‌باشد. یک نمونهٔ [IShapeBevelEffectiveData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShapeBevelEffectiveData) از طریق [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IThreeDFormatEffectiveData) در دسترس قرار می‌گیرد که مقادیر مؤثر برای [IThreeDFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IThreeDFormat) را فراهم می‌کند.

نمونهٔ کد زیر نشان می‌دهد چگونه ویژگی‌های مؤثر برش بالایی یک شکل را به دست آورید. فرض می‌شود که اولین شکل در اولین اسلاید دارای قالب‌بندی 3D باشد.

```java
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

## **دریافت ویژگی‌های مؤثر فریم متن**

با استفاده از Aspose.Slides می‌توانید ویژگی‌های مؤثر یک فریم متن را دریافت کنید. رابط [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITextFrameFormatEffectiveData) شامل ویژگی‌های مؤثر قالب‌بندی فریم متن است.

نمونهٔ کد زیر نشان می‌دهد چگونه ویژگی‌های مؤثر قالب‌بندی فریم متن را به دست آورید. فرض می‌شود که اولین شکل در اولین اسلاید یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IAutoShape) با یک فریم متن باشد.

```java
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

## **دریافت ویژگی‌های مؤثر سبک متن**

با استفاده از Aspose.Slides می‌توانید ویژگی‌های مؤثر یک سبک متن را دریافت کنید. رابط [ITextStyleEffectiveData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITextStyleEffectiveData) شامل ویژگی‌های مؤثر سبک متن است.

نمونهٔ کد زیر نشان می‌دهد چگونه ویژگی‌های مؤثر سبک متن را به دست آورید. فرض می‌شود که اولین شکل در اولین اسلاید یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IAutoShape) با یک فریم متن باشد.

```java
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

## **دریافت مقدار مؤثر ارتفاع قلم**

با استفاده از Aspose.Slides می‌توانید ارتفاع قلم مؤثر را دریافت کنید. کد زیر نشان می‌دهد چگونه ارتفاع قلم مؤثر یک portion پس از تنظیم مقادیر محلی ارتفاع قلم در سطوح مختلف ساختار ارائه تغییر می‌کند.

```java
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

## **دریافت قالب‌بندی پرش مؤثر برای جدول**

با استفاده از Aspose.Slides می‌توانید قالب‌بندی پرش مؤثر برای بخش‌های مختلف جدول را دریافت کنید. رابط [IFillFormatEffectiveData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IFillFormatEffectiveData) شامل ویژگی‌های مؤثر قالب‌بندی پرش است. قالب‌بندی سلول نسبت به قالب‌بندی ردیف اولویت بالاتری دارد، قالب‌بندی ردیف نسبت به قالب‌بندی ستون اولویت بالاتری دارد و قالب‌بندی ستون نسبت به قالب‌بندی کل جدول اولویت بالاتری دارد.

در نتیجه، ویژگی‌های [ICellFormatEffectiveData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ICellFormatEffectiveData) برای رسم سلول جدول استفاده می‌شود. نمونهٔ کد زیر نشان می‌دهد چگونه قالب‌بندی پرش مؤثر برای بخش‌های مختلف جدول را به دست آورید. فرض می‌شود که اولین شکل در اولین اسلاید یک [ITable](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITable) باشد.

```java
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

**آیا `getEffective` یک snapshot برمی‌گرداند؟**

همیشه نیست. داده‌های مؤثر نشان‌دهنده قالب‌بندی محاسبه‌شده پس از اعمال وراثت هستند، اما برخی از اشیای داده مؤثر ممکن است به‌صورت داخلی کش شوند. فراخوانی بعدی `getEffective` ممکن است قالب‌بندی را دوباره محاسبه کند و داده‌های کش‌شده را تازه‌سازی کند، بنابراین شیء قبلاً به‌دست آمده نباید به‌عنوان یک snapshot پایدار محسوب شود.

**چه زمانی باید دوباره ویژگی‌های مؤثر را بخوانم؟**

بعد از تغییر قالب‌بندی محلی، سبک‌های والد، قالب‌بندی لایه، قالب‌بندی مستر یا مقادیر پیش‌فرض سطح ارائه، `getEffective` را دوباره فراخوانی کنید. فراخوانی بعدی سلسله مراتب قالب‌بندی را دوباره ارزیابی می‌کند و نتیجهٔ مؤثر کنونی را بازمی‌گرداند.

**آیا تغییر یا حذف یک اسلاید layout/master بر ویژگی‌های مؤثری که قبلاً دریافت شده‌اند تأثیر می‌گذارد؟**

بله، اما این تغییر در فراخوانی بعدی `getEffective` منعکس می‌شود. اگر منبع قالب‌بندی والد تغییر یا حذف شود، داده‌های مؤثر قبلاً به‌دست آمده ممکن است قدیمی شوند. پس از فراخوانی دوباره `getEffective`، Aspose.Slides سلسله‌مراتبی قالب‌بندی را دوباره ارزیابی می‌کند و قلم‌ها، رنگ‌ها، اندازه‌ها یا مقادیر دیگر ممکن است تغییر کنند.

**آیا می‌توانم مقادیر را از طریق اشیای داده مؤثر تغییر دهم؟**

خیر. اشیای داده مؤثر فقط مقادیر محاسبه‌شده را نشان می‌دهند. تغییرات را در اشیای قالب‌بندی محلی اعمال کنید و سپس مقادیر مؤثر را دوباره دریافت کنید.

**اگر یک ویژگی در سطح شکل، layout/master یا تنظیمات سراسری تنظیم نشده باشد، چه می‌شود؟**

مقدار مؤثر توسط مکانیزم پیش‌فرض تعیین می‌شود که شامل مقادیر پیش‌فرض PowerPoint و Aspose.Slides است. این مقدار حل‌شده به عنوان بخشی از داده‌های مؤثر جاری در نظر گرفته می‌شود.

**از مقدار فونت مؤثر، آیا می‌توانم تشخیص دهم که کدام سطح اندازه یا نوع قلم را فراهم کرده است؟**

به‌طور مستقیم نمی‌توان. داده‌های مؤثر فقط مقدار نهایی را برمی‌گردانند. برای یافتن منبع، مقادیر محلی را در سطح portion، paragraph، text frame و سبک‌های متن در layout، master و سطح ارائه بررسی کنید تا اولین تعریف صریح را بیابید.

**چرا گاهی مقادیر مؤثر شبیه مقادیر محلی به نظر می‌رسند؟**

چون مقدار محلی در نهایت نهایی شده است (عدم نیاز به وراثت از سطوح بالاتر). در این موارد، مقدار مؤثر با مقدار محلی برابر است.

**چه زمانی باید از ویژگی‌های مؤثر استفاده کنم و چه زمانی فقط با ویژگی‌های محلی کار کنم؟**

زمانی که به نتیجهٔ «به صورت رندر شده» پس از اعمال تمام وراثت‌ها نیاز دارید، از داده‌های مؤثر استفاده کنید، مانند برای هم‌راستای کردن رنگ‌ها، تورفتگی‌ها یا اندازه‌ها. اگر نیاز دارید این مقادیر را صرفنظر از تغییرات قالب‌بندی بعدی حفظ کنید، ویژگی‌های مورد نیاز را در شیء خود کپی کنید. اگر می‌خواهید قالب‌بندی را در سطح خاصی تغییر دهید، ویژگی‌های محلی را اصلاح کنید و سپس در صورت نیاز، داده‌های مؤثر را دوباره بخوانید تا نتیجه را تأیید کنید.