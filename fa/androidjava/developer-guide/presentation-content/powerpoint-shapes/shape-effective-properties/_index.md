---
title: "دریافت ویژگی‌های مؤثر شکل از ارائه‌ها در Android"
linktitle: "ویژگی‌های مؤثر"
type: docs
weight: 50
url: /fa/androidjava/shape-effective-properties/
keywords:
- "ویژگی‌های شکل"
- "ویژگی‌های دوربین"
- "سیستم نور"
- "شکل لبه‌دار"
- "قاب متن"
- "سبک متن"
- "ارتفاع قلم"
- "قالب پرکردن"
- "PowerPoint"
- "ارائه"
- "Android"
- "Java"
- "Aspose.Slides"
description: "کشف کنید که Aspose.Slides برای Android از طریق Java چگونه ویژگی‌های مؤثر شکل را برای رندر دقیق PowerPoint محاسبه و اعمال می‌کند."
---
## **مرور کلی**

این مطلب تفاوت بین ویژگی‌های **محلی** و **موثر** را توضیح می‌دهد. مقادیر محلی مقادیری هستند که به‌طور مستقیم در یک سطح قالب‌بندی خاص تنظیم می‌شوند، مانند:

1. ویژگی‌های بخش در یک اسلاید.
2. سبک‌های متن شکل نمونه در یک طرح‌بندی یا اسلاید اصلی، وقتی شکل قاب متن بخش آن را دارد.
3. تنظیمات متن سراسری در یک ارائه.

مقادیر محلی می‌توانند در هر سطحی تعریف یا حذف شوند. هنگامی که Aspose.Slides به قالب‌بندی نهایی «به‌عنوان رندر شده» نیاز دارد، زنجیره ارث‌بری را حل می‌کند و مقادیر **موثر** را برمی‌گرداند. می‌توانید با فراخوانی متد `getEffective()` بر روی شیء قالب‌بندی محلی، این مقادیر را دریافت کنید.

مثال زیر نشان می‌دهد چگونه مقادیر موثر را دریافت کنیم. فرض می‌شود که اولین شکل در اولین اسلاید یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) با یک قاب متن و حداقل یک بخش است.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrame textFrame = shape.getTextFrame();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrame.getTextFrameFormat().getEffective();

    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormatEffectiveData effectivePortionFormat = portion.getPortionFormat().getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
داده‌های قالب‌بندی مؤثر نشان‌دهنده قالب‌بندی محاسبه‌شده فعلی پس از اعمال ارث‌بری هستند. در پیاده‌سازی کنونی، برخی از اشیاء داده‌های مؤثر، مانند [IPortionFormatEffectiveData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iportionformateffectivedata/)، ممکن است به‌صورت داخلی کش شوند. فراخوانی دوباره `getEffective()` پس از تغییر قالب‌بندی والد یا ارث‌بری می‌تواند داده‌های کش‌شده را تازه‌سازی کند و شیء قبلاً دریافت‌شده ممکن است دیگر حالت قبلی را نشان ندهد. اگر نیاز دارید مقادیر مؤثر را برای استفاده مجدد بعدی حفظ کنید، خصوصیات مورد نیاز مانند ارتفاع قلم، رنگ پرکردن، سبک قلم یا تراز را به شیء دادهٔ خودتان کپی کنید.
{{% /alert %}}

## **دریافت ویژگی‌های مؤثر دوربین**

Aspose.Slides به شما اجازه می‌دهد ویژگی‌های مؤثر یک دوربین را دریافت کنید. رابط [ICameraEffectiveData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icameraeffectivedata/) یک شیء غیرقابل تغییر را نمایندگی می‌کند که شامل ویژگی‌های مؤثر دوربین است. یک نمونهٔ [ICameraEffectiveData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icameraeffectivedata/) از طریق [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformateffectivedata/) در دسترس قرار می‌گیرد که مقادیر مؤثر برای [IThreeDFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/) را فراهم می‌کند.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ICameraEffectiveData cameraEffectiveData = threeDEffectiveData.getCamera();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + cameraEffectiveData.getCameraType());
    System.out.println("Field of view: " + cameraEffectiveData.getFieldOfViewAngle());
    System.out.println("Zoom: " + cameraEffectiveData.getZoom());
} finally {
    presentation.dispose();
}
```

## **دریافت ویژگی‌های مؤثر نور**

Aspose.Slides به شما اجازه می‌دهد ویژگی‌های مؤثر نور را دریافت کنید. رابط [ILightRigEffectiveData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilightrigeffectivedata/) یک شیء غیرقابل تغییر را نمایندگی می‌کند که شامل ویژگی‌های مؤثر نور است. یک نمونهٔ [ILightRigEffectiveData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilightrigeffectivedata/) از طریق [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformateffectivedata/) در دسترس قرار می‌گیرد که مقادیر مؤثر برای [IThreeDFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/) را فراهم می‌کند.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ILightRigEffectiveData lightRigEffectiveData = threeDEffectiveData.getLightRig();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + lightRigEffectiveData.getLightType());
    System.out.println("Direction: " + lightRigEffectiveData.getDirection());
} finally {
    presentation.dispose();
}
```

## **دریافت ویژگی‌های مؤثر شکل لبه**

Aspose.Slides به شما اجازه می‌دهد ویژگی‌های مؤثر لبهٔ یک شکل را دریافت کنید. رابط [IShapeBevelEffectiveData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapebeveleffectivedata/) یک شیء غیرقابل تغییر را نمایندگی می‌کند که شامل خصوصیات مؤثر برجستگی برای یک شکل است. یک نمونهٔ [IShapeBevelEffectiveData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapebeveleffectivedata/) از طریق [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformateffectivedata/) در دسترس قرار می‌گیرد که مقادیر مؤثر برای [IThreeDFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/) را فراهم می‌کند.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    IShapeBevelEffectiveData bevelTopEffectiveData = threeDEffectiveData.getBevelTop();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + bevelTopEffectiveData.getBevelType());
    System.out.println("Width: " + bevelTopEffectiveData.getWidth());
    System.out.println("Height: " + bevelTopEffectiveData.getHeight());
} finally {
    presentation.dispose();
}
```

## **دریافت ویژگی‌های مؤثر فریم متنی**

با Aspose.Slides می‌توانید ویژگی‌های مؤثر یک فریم متنی را دریافت کنید. رابط [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframeformateffectivedata/) شامل خصوصیات مؤثر قالب‌بندی فریم متنی است.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormatEffectiveData effectiveTextFrameFormat = shape.getTextFrame().getTextFrameFormat().getEffective();

    System.out.println("Anchoring type: " + effectiveTextFrameFormat.getAnchoringType());
    System.out.println("Autofit type: " + effectiveTextFrameFormat.getAutofitType());
    System.out.println("Text vertical type: " + effectiveTextFrameFormat.getTextVerticalType());
    System.out.println("Margins");
    System.out.println("   Left: " + effectiveTextFrameFormat.getMarginLeft());
    System.out.println("   Top: " + effectiveTextFrameFormat.getMarginTop());
    System.out.println("   Right: " + effectiveTextFrameFormat.getMarginRight());
    System.out.println("   Bottom: " + effectiveTextFrameFormat.getMarginBottom());
} finally {
    presentation.dispose();
}
```

## **دریافت ویژگی‌های مؤثر سبک متن**

با Aspose.Slides می‌توانید ویژگی‌های مؤثر یک سبک متن را دریافت کنید. رابط [ITextStyleEffectiveData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextstyleeffectivedata/) شامل خصوصیات مؤثر سبک متن است.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    int levelCount = 9;

    for (int levelIndex = 0; levelIndex < levelCount; levelIndex++) {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);

        System.out.println("= Effective paragraph formatting for style level #" + levelIndex + " =");

        System.out.println("Depth: " + effectiveStyleLevel.getDepth());
        System.out.println("Indent: " + effectiveStyleLevel.getIndent());
        System.out.println("Alignment: " + effectiveStyleLevel.getAlignment());
        System.out.println("Font alignment: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    presentation.dispose();
}
```

## **دریافت مقدار ارتفاع فونت مؤثر**

با Aspose.Slides می‌توانید ارتفاع فونت مؤثر را دریافت کنید. مثال زیر نشان می‌دهد چگونه ارتفاع فونت مؤثر یک بخش پس از تنظیم مقادیر ارتفاع فونت محلی در سطوح مختلف ساختار ارائه تغییر می‌کند.

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

## **دریافت قالب پرکردن مؤثر برای جدول**

با Aspose.Slides می‌توانید قالب پرکردن مؤثر برای قسمت‌های مختلف جدول را دریافت کنید. رابط [IFillFormatEffectiveData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifillformateffectivedata/) شامل خصوصیات مؤثر قالب‌بندی پرکردن است. قالب‌بندی سلول نسبت به قالب‌بندی سطر اولویت بالاتری دارد، قالب‌بندی سطر نسبت به قالب‌بندی ستون اولویت بالاتری دارد و قالب‌بندی ستون نسبت به قالب‌بندی کل جدول اولویت بالاتری دارد.

در نتیجه، خصوصیات [ICellFormatEffectiveData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icellformateffectivedata/) برای رسم سلول جدول استفاده می‌شوند. مثال زیر نشان می‌دهد چگونه قالب پرکردن مؤثر برای قسمت‌های مختلف جدول را دریافت کنید. فرض می‌شود که اولین شکل در اولین اسلاید یک [ITable](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itable/) است.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable)slide.getShapes().get_Item(0);

    IRow row = table.getRows().get_Item(0);
    IColumn column = table.getColumns().get_Item(0);
    ICell cell = table.get_Item(0, 0);

    IFillFormatEffectiveData tableFillFormatEffective = table.getTableFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = row.getRowFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = column.getColumnFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cell.getCellFormat().getEffective().getFillFormat();
} finally {
    presentation.dispose();
}
```

## **سوالات متداول**

**آیا `getEffective()` یک اسنپ‌شات برمی‌گرداند؟**

همیشه نیست. داده‌های مؤثر نمایانگر قالب‌بندی محاسبه‌شده پس از اعمال ارث‌بری هستند، اما برخی از اشیاء داده مؤثر ممکن است به‌صورت داخلی کش شوند. یک فراخوانی بعدی `getEffective()` ممکن است قالب‌بندی را دوباره محاسبه کند و داده‌های کش‌شده را تازه‌سازی نماید، بنابراین نباید شیء دریافت‌شده قبلی را به‌عنوان یک اسنپ‌شات ثابت در نظر گرفت.

**چه زمانی باید مجدداً ویژگی‌های مؤثر را بخوانم؟**

پس از تغییر قالب‌بندی محلی، سبک‌های والد، قالب‌بندی طرح‌بندی، قالب‌بندی اصلی یا پیش‌فرض‌های سطح ارائه، `getEffective()` را دوباره فراخوانی کنید. فراخوانی بعدی سلسله مراتب قالب‌بندی را دوباره ارزیابی می‌کند و نتیجهٔ مؤثر جاری را برمی‌گرداند.

**آیا تغییر یا حذف اسلاید طرح‌بندی/اصلی روی ویژگی‌های مؤثری که قبلاً دریافت شده‌اند تاثیر می‌گذارد؟**

بله، اما این تغییر در فراخوانی بعدی `getEffective()` اعمال می‌شود. اگر منبع قالب‌بندی والد تغییر یا حذف شود، داده‌های مؤثری که قبلاً دریافت شده‌اند ممکن است منسوخ شوند. پس از فراخوانی مجدد `getEffective()`، Aspose.Slides درخت قالب‌بندی را دوباره ارزیابی می‌کند و فونت‌ها، رنگ‌ها، اندازه‌ها یا سایر مقادیر ممکن است تغییر کنند.

**آیا می‌توانم مقادیر را از طریق اشیاء داده مؤثر تغییر دهم؟**

خیر. اشیاء داده مؤثر تنها مقادیر محاسبه‌شده را نشان می‌دهند. تغییرات را در اشیاء قالب‌بندی محلی اعمال کنید و سپس مقادیر مؤثر را دوباره دریافت کنید.

**اگر یک ویژگی در سطح شکل، طرح‌بندی/اصلی یا تنظیمات سراسری تنظیم نشده باشد چه اتفاقی می‌افتد؟**

مقدار مؤثر توسط سازوکار پیش‌فرض تعیین می‌شود که شامل پیش‌فرض‌های PowerPoint و Aspose.Slides است. آن مقدار حل‌شده بخشی از داده‌های مؤثر جاری می‌شود.

**از مقدار فونت مؤثر، می‌توانم تشخیص دهم که کدام سطح اندازه یا نوع قلم را ارائه داده است؟**

به‌طور مستقیم نیست. داده‌های مؤثر فقط مقدار نهایی را برمی‌گردانند. برای یافتن منبع، مقادیر محلی را در بخش، پاراگراف، قاب متن و سبک‌های متنی در سطوح طرح‌بندی، اصلی و ارائه بررسی کنید تا اولین تعریف صریح را پیدا کنید.

**چرا گاهی مقادیر مؤثر شبیه مقادیر محلی به نظر می‌رسند؟**

چون مقدار محلی به‌عنوان نهایی باقی می‌ماند (نیازی به ارث‌بری از سطوح بالاتر نیست). در این موارد، مقدار مؤثر با مقدار محلی برابر است.

**چه زمانی باید از ویژگی‌های مؤثر استفاده کنم و چه زمانی فقط با ویژگی‌های محلی کار کنم؟**

از داده‌های مؤثر وقتی استفاده کنید که به نتیجهٔ «به‌عنوان رندر شده» پس از اعمال تمام ارث‌بری نیاز دارید، مانند تطبیق رنگ‌ها، تورفتگی‌ها یا اندازه‌ها. اگر می‌خواهید این مقادیر را صرف‌نظر از تغییرات قالب‌بندی بعدی حفظ کنید، خصوصیات مورد نیاز را در شیء خود کپی کنید. اگر می‌خواهید قالب‌بندی را در سطح خاصی تغییر دهید، ویژگی‌های محلی را اصلاح کنید و سپس، در صورت نیاز، داده‌های مؤثر را دوباره بخوانید تا نتیجه را تأیید کنید.