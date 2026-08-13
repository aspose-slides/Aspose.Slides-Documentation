---
title: دریافت خصوصیات مؤثر شکل از ارائه‌ها در اندروید
linktitle: خصوصیات مؤثر
type: docs
weight: 50
url: /fa/androidjava/shape-effective-properties/
keywords:
- خصوصیات شکل
- خصوصیات دوربین
- نورپردازی
- شکل برجسته
- قاب متن
- سبک متن
- ارتفاع قلم
- قالب پر شدن
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "کشف کنید که Aspose.Slides برای Android از طریق Java چگونه خصوصیات مؤثر شکل را محاسبه و اعمال می‌کند تا رندر دقیق PowerPoint فراهم شود."
---
## **بررسی کلی**

این مقاله تفاوت بین خصوصیات **محلی** و **موثر** را توضیح می‌دهد. مقادیر محلی مقادیری هستند که به طور مستقیم در سطح خاصی از فرمت‌گذاری تنظیم می‌شوند، مانند:

1. خصوصیات بخش در یک اسلاید.
1. سبک‌های متن شکل Prototype در یک layout یا master slide، هنگامی که شکل قاب متن بخش یک سبک دارد.
1. تنظیمات متن سراسری در یک ارائه.

مقادیر محلی می‌توانند در هر سطحی تعریف یا حذف شوند. وقتی Aspose.Slides به فرمت نهایی «به‌صورت‌رندرشده» نیاز دارد، زنجیره وراثت را حل می‌کند و مقادیر **موثر** را برمی‌گرداند. می‌توانید آنها را با فراخوانی متد `getEffective()` بر روی شیء فرمت محلی دریافت کنید.

مثال زیر نشان می‌دهد چگونه مقادیر موثر را به‌دست آورید. فرض می‌شود که اولین شکل در اولین اسلاید یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) با یک قاب متن و حداقل یک بخش باشد.

```java
import com.aspose.slides.*;

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

{{% alert color="info" %}}
داده‌های فرمت موثر نمایانگر فرمت محاسبه‌شدهٔ جاری پس از اعمال وراثت است. در پیاده‌سازی فعلی، برخی از اشیای دادهٔ موثر، مانند [IPortionFormatEffectiveData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iportionformateffectivedata/)، ممکن است به‌صورت داخلی کش شوند. فراخوانی دوباره `getEffective()` پس از تغییر فرمت والد یا وراثت‌شده می‌تواند کش را تازه کند و شیء قبلاً به‌دست آمده ممکن است دیگر وضعیت قبلی را نشان ندهد. اگر نیاز به حفظ مقادیر موثر برای استفادهٔ بعدی دارید، ویژگی‌های مورد نیاز مانند ارتفاع قلم، رنگ پر، سبک قلم یا تراز را در شیء دادهٔ خود کپی کنید.
{{% /alert %}}

## **دریافت خصوصیات موثر دوربین**

Aspose.Slides به شما امکان می‌دهد خصوصیات موثر یک دوربین را دریافت کنید. رابط [ICameraEffectiveData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icameraeffectivedata/) شیء‌ای غیرقابل تغییر را نمایش می‌دهد که شامل خصوصیات موثر دوربین است. یک نمونهٔ [ICameraEffectiveData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icameraeffectivedata/) از طریق [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformateffectivedata/) قابل دسترسی است که مقادیر موثر برای [IThreeDFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/) را فراهم می‌کند.

مثال زیر نشان می‌دهد چگونه خصوصیات موثر دوربین را دریافت کنید. فرض می‌شود که اولین شکل در اولین اسلاید فرمت 3 بعدی داشته باشد.

```java
import com.aspose.slides.*;

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

## **دریافت خصوصیات موثر نورپردازی**

Aspose.Slides به شما امکان می‌دهد خصوصیات موثر یک نورپردازی را دریافت کنید. رابط [ILightRigEffectiveData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilightrigeffectivedata/) شیء‌ای غیرقابل تغییر را نمایش می‌دهد که شامل خصوصیات موثر نورپردازی است. یک نمونهٔ [ILightRigEffectiveData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilightrigeffectivedata/) از طریق [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformateffectivedata/) قابل دسترسی است که مقادیر موثر برای [IThreeDFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/) را فراهم می‌کند.

مثال زیر نشان می‌دهد چگونه خصوصیات موثر نورپردازی را دریافت کنید. فرض می‌شود که اولین شکل در اولین اسلاید فرمت 3 بعدی داشته باشد.

```java
import com.aspose.slides.*;

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

## **دریافت خصوصیات موثر شکل برجسته**

Aspose.Slides به شما امکان می‌دهد خصوصیات موثر یک برجستهٔ شکل را دریافت کنید. رابط [IShapeBevelEffectiveData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapebeveleffectivedata/) شیء‌ای غیرقابل تغییر را نمایش می‌دهد که شامل خصوصیات موثر برجستهٔ شکل است. یک نمونهٔ [IShapeBevelEffectiveData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapebeveleffectivedata/) از طریق [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformateffectivedata/) قابل دسترسی است که مقادیر موثر برای [IThreeDFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ithreedformat/) را فراهم می‌کند.

مثال زیر نشان می‌دهد چگونه خصوصیات موثر برجستهٔ بالایی یک شکل را دریافت کنید. فرض می‌شود که اولین شکل در اولین اسלاید فرمت 3 بعدی داشته باشد.

```java
import com.aspose.slides.*;

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

## **دریافت خصوصیات موثر قاب متن**

با استفاده از Aspose.Slides می‌توانید خصوصیات موثر یک قاب متن را دریافت کنید. رابط [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframeformateffectivedata/) شامل خصوصیات فرمت مؤثر قاب متن است.

مثال زیر نشان می‌دهد چگونه خصوصیات فرمت مؤثر قاب متن را دریافت کنید. فرض می‌شود که اولین شکل در اولین اسلاید یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) با یک قاب متن باشد.

```java
import com.aspose.slides.*;

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

## **دریافت خصوصیات موثر سبک متن**

با استفاده از Aspose.Slides می‌توانید خصوصیات موثر یک سبک متن را دریافت کنید. رابط [ITextStyleEffectiveData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextstyleeffectivedata/) شامل خصوصیات موثر سبک متن است.

مثال زیر نشان می‌دهد چگونه خصوصیات موثر سبک متن را دریافت کنید. فرض می‌شود که اولین شکل در اولین اسلاید یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) با یک قاب متن باشد.

```java
import com.aspose.slides.*;

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

## **دریافت مقدار ارتفاع قلم موثر**

با استفاده از Aspose.Slides می‌توانید ارتفاع قلم موثر را دریافت کنید. مثال زیر نشان می‌دهد چگونه ارتفاع قلم موثر یک بخش پس از تنظیم مقادیر ارتفاع قلم محلی در سطوح مختلف ساختار ارائه تغییر می‌کند.

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

## **دریافت قالب پر شدن مؤثر برای جدول**

با استفاده از Aspose.Slides می‌توانید فرمت پر شدن مؤثر برای قسمت‌های مختلف جدول را دریافت کنید. رابط [IFillFormatEffectiveData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ifillformateffectivedata/) شامل خصوصیات فرمت پر شدن مؤثر است. فرمت سلول نسبت به فرمت سطر اولویت بالاتر دارد، فرمت سطر نسبت به فرمت ستون اولویت بالاتر دارد و فرمت ستون نسبت به فرمت کل جدول اولویت بالاتر دارد.

در نتیجه، خصوصیات [ICellFormatEffectiveData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icellformateffectivedata/) برای رسم سلول جدول استفاده می‌شوند. مثال زیر نشان می‌دهد چگونه فرمت پر شدن مؤثر برای قسمت‌های مختلف جدول را دریافت کنید. فرض می‌شود که اولین شکل در اولین اسلاید یک [ITable](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itable/) باشد.

```java
import com.aspose.slides.*;

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

### آیا `getEffective()` یک تصویر لحظه‌ای برمی‌گرداند؟

همیشه نیست. داده‌های موثر نمایانگر فرمت محاسبه‌شده پس از اعمال وراثت هستند، اما برخی از اشیای دادهٔ موثر می‌توانند به‌صورت داخلی کش شوند. فراخوانی بعدی `getEffective()` ممکن است فرمت را مجدداً محاسبه کند و کش را تازه‌سازی نماید، بنابراین شیء قبلاً به‌دست آمده نباید به‌عنوان یک تصویر ثابت در نظر گرفته شود.

### کی باید دوباره خصوصیات موثر را بخوانم؟

پس از تغییر فرمت محلی، سبک‌های والد، فرمت layout، فرمت master یا مقدارهای پیش‌فرض سطح ارائه، `getEffective()` را دوباره فراخوانی کنید. فراخوانی بعدی سلسله‌مراتب فرمت را دوباره ارزیابی کرده و نتیجهٔ مؤثر فعلی را برمی‌گرداند.

### آیا تغییر یا حذف یک اسلاید layout/master بر خصوصیات موثری که قبلاً دریافت شده‌اند تأثیر می‌گذارد؟

بله، اما این تغییر در فراخوانی بعدی `getEffective()` منعکس می‌شود. اگر منبع فرمت والد تغییر یا حذف شود، دادهٔ موثر قبلاً به‌دست آمده ممکن است منسوخ شود. پس از فراخوانی دوباره `getEffective()`، Aspose.Slides درخت فرمت را دوباره ارزیابی می‌کند و قلم‌ها، رنگ‌ها، اندازه‌ها یا مقادیر دیگر ممکن است تغییر کنند.

### آیا می‌توانم مقادیر را از طریق اشیای دادهٔ موثر تغییر دهم؟

نه. اشیای دادهٔ موثر فقط مقادیر محاسبه‌شده را نشان می‌دهند. تغییرات را در اشیای فرمت محلی انجام دهید و سپس مقادیر موثر را دوباره دریافت کنید.

### اگر یک ویژگی در سطح شکل، layout/master یا تنظیمات سراسری تنظیم نشود چه می‌شود؟

مقدار موثر توسط مکانیزم پیش‌فرض تعیین می‌شود که شامل پیش‌فرض‌های PowerPoint و Aspose.Slides است. آن مقدار حل‌شده بخشی از دادهٔ مؤثر جاری می‌شود.

### از یک مقدار قلم موثر، آیا می‌توانم بفهمم کدام سطح اندازه یا فونت را فراهم کرده است؟

به‌صورت مستقیم نیست. دادهٔ موثر مقدار نهایی را برمی‌گرداند. برای یافتن منبع، مقادیر محلی را در بخش، پاراگراف، قاب متن و سبک‌های متن در سطوح layout، master و presentation بررسی کنید تا ببینید اولین تعریف صریح در کجا ظاهر می‌شود.

### چرا گاهی مقادیر موثر شبیه مقادیر محلی به نظر می‌رسند؟

زیرا مقدار محلی در نهایت نهایی شد (نیاز به وراثت در سطوح بالاتر نبود). در این موارد مقدار موثر با مقدار محلی مطابقت دارد.

### کی باید از خصوصیات موثر استفاده کنم و کی باید فقط با خصوصیات محلی کار کنم؟

وقتی به نتیجهٔ «به‌صورت‌رندرشده» پس از اعمال تمام وراثت‌ها نیاز دارید—مثلاً برای هم‌تراز کردن رنگ‌ها، تورفتگی‌ها یا اندازه‌ها—از دادهٔ موثر استفاده کنید. اگر می‌خواهید این مقادیر را صرف‌نظر از تغییرات بعدی فرمت حفظ کنید، ویژگی‌های مورد نیاز را در شیء خود کپی کنید. اگر می‌خواهید فرمت را در سطح خاصی تغییر دهید، ابتدا خصوصیات محلی را اصلاح کنید و سپس در صورت نیاز، دادهٔ موثر را دوباره بخوانید تا نتیجه را تأیید کنید.