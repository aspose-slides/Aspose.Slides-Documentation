---
title: مدیریت تم‌های ارائه در اندروید
linktitle: تم ارائه
type: docs
weight: 10
url: /fa/androidjava/presentation-theme/
keywords:
- تم پاورپوینت
- تم ارائه
- تم اسلاید
- تنظیم تم
- تغییر تم
- مدیریت تم
- رنگ تم
- پالت اضافی
- فونت تم
- استایل تم
- افکت تم
- پاورپوینت
- OpenDocument
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "تم‌های ارائه اصلی را در Aspose.Slides برای اندروید از طریق جاوا مدیریت کنید تا فایل‌های پاورپوینت را با برندینگ یکسان ایجاد، سفارشی و تبدیل کنید."
---
## **مقدمه**

یک تم ارائه خصوصیات عناصر طراحی را تعریف می‌کند. وقتی تم ارائه‌ای را انتخاب می‌کنید، در اصل مجموعه‌ای خاص از عناصر بصری و خصوصیات آن‌ها را برمی‌گزینید.

در PowerPoint، یک تم شامل رنگ‌ها، [قلم‌ها](/slides/fa/androidjava/powerpoint-fonts/)، [سبک‌های پس‌زمینه](/slides/fa/androidjava/presentation-background/)، و افکت‌ها است.

![theme-constituents](theme-constituents.png)

## **تغییر رنگ تم**

یک تم PowerPoint برای عناصر مختلف روی اسلاید از یک مجموعه خاص رنگ‌ها استفاده می‌کند. اگر رنگ‌ها را دوست ندارید، می‌توانید با اعمال رنگ‌های جدید به تم، رنگ‌ها را تغییر دهید. برای انتخاب رنگ جدید تم، Aspose.Slides مقادیر زیر را در شمارش‌گر [SchemeColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SchemeColor) ارائه می‌دهد.

این کد Java نشان می‌دهد چگونه رنگ تأکید تم را تغییر دهید:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
} finally {
    if (pres != null) pres.dispose();
}
```

می‌توانید مقدار مؤثر رنگ حاصل را به این شکل تعیین کنید:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

    Color effectiveColor = fillEffective.getSolidFillColor();

    System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]",
            effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
} finally {
    if (pres != null) pres.dispose();
}
```

برای نشان دادن بیشتر عملیات تغییر رنگ، یک عنصر دیگر ایجاد می‌کنیم و رنگ تأکید (از عملیات اولیه) را به آن اختصاص می‌دهیم. سپس رنگ تم را تغییر می‌دهیم:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

    otherShape.getFillFormat().setFillType(FillType.Solid);

    otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```

رنگ جدید به‌صورت خودکار روی هر دو عنصر اعمال می‌شود.

### **تنظیم رنگ تم از یک پالت اضافی**

زمانی که تبدیل‌های روشنایی را روی رنگ اصلی تم (1) اعمال می‌کنید، رنگ‌هایی از پالت اضافی (2) شکل می‌گیرد. سپس می‌توانید آن رنگ‌های تم را تنظیم و بازیابی کنید.

![additional-palette-colors](additional-palette-colors.png)

**1** - رنگ‌های اصلی تم

**2** - رنگ‌های پالت اضافی.

این کد Java عملیاتی را نشان می‌دهد که در آن رنگ‌های پالت اضافی از رنگ اصلی تم به دست می‌آیند و سپس در اشکال استفاده می‌شوند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Accent 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // Accent 4، روشن‌تر 80٪
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // Accent 4، روشن‌تر 60٪
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // Accent 4، روشن‌تر 40٪
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // Accent 4، تاریک‌تر 25٪
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Accent 4، تاریک‌تر 50٪
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save("example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **نقشه‌برداری `SchemeColor` به رنگ‌های `IColorScheme`**

وقتی با [SchemeColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/schemecolor/) کار می‌کنید، ممکن است متوجه شوید که شامل مقادیر رنگ تم زیر است:

`Background1`، `Background2`، `Text1` و `Text2`.

اما `Presentation.getMasterTheme().getColorScheme()` یک شیء [IColorScheme](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icolorscheme/) بازمی‌گرداند که رنگ‌های متناظر را به صورت زیر ارائه می‌دهد:

`Dark1`، `Dark2`، `Light1` و `Light2`.

این اختلاف فقط در نام‌گذاری است. این مقادیر به همان اسلات‌های رنگ تم اشاره دارند و نگاشت ثابت است:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

هیچ تبدیل پویا بین `Text`/`Background` و `Dark`/`Light` وجود ندارد. آن‌ها تنها نام‌های جایگزین برای همان رنگ‌های تم هستند.

این تفاوت نام‌گذاری از اصطلاحات Microsoft Office می‌آید. نسخه‌های قدیمی Office از `Dark 1`، `Light 1`، `Dark 2` و `Light 2` استفاده می‌کردند، در حالی که نسخه‌های جدید UI همان اسلات‌ها را به صورت `Text 1`، `Background 1`، `Text 2` و `Background 2` نمایش می‌دهند.

## **تغییر فونت تم**

برای انتخاب فونت‌ها برای تم‌ها و مقاصد دیگر، Aspose.Slides از این شناسه‌های ویژه (مشابه آنچه در PowerPoint استفاده می‌شود) بهره می‌گیرد:

* **+mn-lt** - فونت بدنه لاتین (Minor Latin Font)
* **+mj-lt** - فونت عنوان لاتین (Major Latin Font)
* **+mn-ea** - فونت بدنه آسیای شرقی (Minor East Asian Font)
* **+mj-ea** - فونت عنوان آسیای شرقی (Major East Asian Font)

این کد Java نشان می‌دهد چگونه فونت لاتین را به یک عنصر تم اختصاص دهید:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    Paragraph paragraph = new Paragraph();

    Portion portion = new Portion("Theme text format");

    paragraph.getPortions().add(portion);

    shape.getTextFrame().getParagraphs().add(paragraph);

    portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
} finally {
    if (pres != null) pres.dispose();
}
```

این کد Java نشان می‌دهد چگونه فونت تم ارائه را تغییر دهید:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
} finally {
    if (pres != null) pres.dispose();
}
```

فونت در تمام جعبه‌های متنی به‌روز می‌شود.

{{% alert color="info" title="نکته" %}} 
ممکن است بخواهید به [قلم‌های PowerPoint](/slides/fa/androidjava/powerpoint-fonts/) نگاه کنید.
{{% /alert %}}

## **تغییر سبک پس‌زمینه تم**

به‌صورت پیش‌فرض، برنامه PowerPoint ۱۲ پس‌زمینه از پیش تعریف‌شده ارائه می‌دهد اما فقط ۳ تا از این ۱۲ پس‌زمینه در یک ارائه معمولی ذخیره می‌شوند.

![todo:image_alt_text](presentation-design_8.png)

به‌عنوان مثال، پس از ذخیره یک ارائه در برنامه PowerPoint، می‌توانید این کد Java را اجرا کنید تا تعداد پس‌زمینه‌های از پیش تعریف‌شده در ارائه را بیابید:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 
با استفاده از ویژگی [BackgroundFillStyles](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) از کلاس [FormatScheme](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FormatScheme)، می‌توانید سبک پس‌زمینه را در یک تم PowerPoint اضافه یا دسترسی پیدا کنید.
{{% /alert %}} 

این کد Java نشان می‌دهد چگونه پس‌زمینه یک ارائه را تنظیم کنید:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
} finally {
    if (pres != null) pres.dispose();
}
```

**راهنمای اندیس**: ۰ برای بدون پر کردن استفاده می‌شود. اندیس از ۱ شروع می‌شود.

{{% alert color="info" title="نکته" %}} 
ممکن است بخواهید به [پس‌زمینه PowerPoint](/slides/fa/androidjava/presentation-background/) نگاه کنید.
{{% /alert %}}

## **تغییر افکت تم**

یک تم PowerPoint معمولاً شامل ۳ مقدار برای هر آرایه سبک است. این آرایه‌ها به ۳ افکت زیر ترکیب می‌شوند: لطیف، متوسط و شدید. به عنوان مثال، این نتیجه است زمانی که افکت‌ها روی یک شکل خاص اعمال می‌شوند:

![todo:image_alt_text](presentation-design_10.png)

با استفاده از ۳ ویژگی ([FillStyles](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FormatScheme#getFillStyles--)، [LineStyles](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FormatScheme#getLineStyles--)، [EffectStyles](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FormatScheme#getEffectStyles--)) از کلاس [FormatScheme](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/FormatScheme) می‌توانید عناصر یک تم را (حتی با انعطاف‌پذیری بیشتر نسبت به گزینه‌های PowerPoint) تغییر دهید.

این کد Java نشان می‌دهد چگونه یک افکت تم را با تغییر قسمت‌های مختلف عناصر تغییر دهید:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(FillType.Solid);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.GREEN);

    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10f);

    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

تغییرات حاصل در رنگ پر، نوع پر، افکت سایه و غیره:

![todo:image_alt_text](presentation-design_11.png)

## **سوالات متداول**

### آیا می‌توانم تم را فقط بر روی یک اسلاید بدون تغییر مستر اعمال کنم؟

بله. Aspose.Slides از ارث‌بری سطح اسلاید برای تم‌ها پشتیبانی می‌کند، بنابراین می‌توانید یک تم محلی را فقط برای آن اسلاید اعمال کنید در حالی که تم مستر دست‌نخورده می‌ماند (از طریق [SlideThemeManager](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slidethememanager/)).

### امن‌ترین راه برای انتقال تم از یک ارائه به ارائه دیگر چیست؟

[کپی اسلایدها](/slides/fa/androidjava/clone-slides/) به همراه مستر آن‌ها به ارائه هدف. این کار مستر، طرح‌ها و تم مرتبط را حفظ می‌کند تا ظاهر یکسان بماند.

### چگونه می‌توانم مقادیر «موثر» پس از تمام ارث‌بری و بازنویسی‌ها را ببینم؟

از نماهای ["مؤثر"](/slides/fa/androidjava/shape-effective-properties/) API برای تم/رنگ/فونت/افکت استفاده کنید. این نماها ویژگی‌های نهایی حل‌ شده پس از اعمال مستر و هر بازنویسی محلی را برمی‌گردانند.