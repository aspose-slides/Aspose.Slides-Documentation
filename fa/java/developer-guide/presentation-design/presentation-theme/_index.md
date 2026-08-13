---
title: مدیریت تم‌های ارائه در جاوا
linktitle: تم ارائه
type: docs
weight: 10
url: /fa/java/presentation-theme/
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
- سبک تم
- افکت تم
- پاورپوینت
- OpenDocument
- ارائه
- جاوا
- Aspose.Slides
description: "تم‌های اصلی ارائه در Aspose.Slides برای جاوا را برای ایجاد، سفارشی‌سازی و تبدیل فایل‌های پاورپوینت با برندسازی یکپارچه مدیریت کنید."
---
## **مقدمه**

یک تم ارائه ویژگی‌های عناصر طراحی را تعریف می‌کند. هنگامی که یک تم ارائه را انتخاب می‌کنید، در واقع مجموعه‌ای خاص از عناصر بصری و ویژگی‌های آن‌ها را برمی‌گزینید.

در پاورپوینت، یک تم شامل رنگ‌ها، [فونت‌ها](/slides/fa/java/powerpoint-fonts/)، [سبک‌های پس‌زمینه](/slides/fa/java/presentation-background/) و افکت‌ها است.

![اجزای تم](theme-constituents.png)

## **تغییر رنگ تم**

یک تم پاورپوینت برای عناصر مختلف در یک اسلاید مجموعه خاصی از رنگ‌ها را استفاده می‌کند. اگر رنگ‌ها را دوست ندارید، می‌توانید با اعمال رنگ‌های جدید برای تم، آنها را تغییر دهید. برای انتخاب رنگ تم جدید، Aspose.Slides مقادیر زیر مجموعه [SchemeColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SchemeColor) را فراهم می‌کند.

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

می‌توانید مقدار مؤثر رنگ حاصل را به این روش تعیین کنید:

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

برای نشان دادن بیشتر عملیات تغییر رنگ، یک عنصر دیگر ایجاد می‌کنیم و رنگ تاکید (از عملیات اولیه) را به آن اختصاص می‌دهیم. سپس رنگ را در تم تغییر می‌دهیم:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

    otherShape.getFillFormat().setFillType(FillType.Solid);

    otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```

رنگ جدید به‌صورت خودکار بر روی هر دو عنصر اعمال می‌شود.

### **تنظیم رنگ تم از پالت اضافی**

وقتی تبدیلات روشنایی را بر روی رنگ اصلی تم (1) اعمال می‌کنید، رنگ‌هایی از پالت اضافی (2) شکل می‌گیرند. پس می‌توانید آن رنگ‌های تم را تنظیم و دریافت کنید.

![رنگ‌های پالت اضافی](additional-palette-colors.png)

**1** - رنگ‌های اصلی تم  
**2** - رنگ‌های پالت اضافی.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Accent 4: تأکید 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // Accent 4, Lighter 80%: تأکید 4، روشن‌تر 80٪
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // Accent 4, Lighter 60%: تأکید 4، روشن‌تر 60٪
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // Accent 4, Lighter 40%: تأکید 4، روشن‌تر 40٪
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // Accent 4, Darker 25%: تأکید 4، تیره‌تر 25٪
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // Accent 4, Darker 50%: تأکید 4، تیره‌تر 50٪
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

هنگامی که با [SchemeColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/schemecolor/) کار می‌کنید، ممکن است متوجه شوید که شامل مقادیر رنگ تم زیر است:

`Background1`, `Background2`, `Text1`, and `Text2`.

اما `Presentation.getMasterTheme().getColorScheme()` [IColorScheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icolorscheme/) را برمی‌گرداند که رنگ‌های مربوطه را به صورت زیر نشان می‌دهد:

`Dark1`, `Dark2`, `Light1`, and `Light2`.

این تفاوت تنها در نام‌گذاری است. این مقادیر به همان اسلات‌های رنگ تم اشاره دارند و نگاشت ثابت است:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

هیچ تبدیل دینامیکی بین `Text`/`Background` و `Dark`/`Light` وجود ندارد. آن‌ها صرفاً نام‌های جایگزین برای یکسان‌ترین رنگ‌های تم هستند.

این تفاوت نام‌گذاری از اصطلاحات Microsoft Office ناشی می‌شود. نسخه‌های قدیمی Office از `Dark 1`، `Light 1`، `Dark 2` و `Light 2` استفاده می‌کردند، در حالی که نسخه‌های جدید UI همان اسلات‌ها را به صورت `Text 1`، `Background 1`، `Text 2` و `Background 2` نمایش می‌دهند.

## **تغییر فونت تم**

برای امکان انتخاب فونت‌ها برای تم‌ها و مقاصد دیگر، Aspose.Slides از این شناسه‌های ویژه (مانند آنچه در پاورپوینت استفاده می‌شود) استفاده می‌کند:

* **+mn-lt** - فونت بدنه لاتین (فونت لاتین خرد)
* **+mj-lt** - فونت سرعنوان لاتین (فونت لاتین اصلی)
* **+mn-ea** - فونت بدنه آسیای شرقی (فونت آسیای شرقی خرد)
* **+mj-ea** - فونت بدنه آسیای شرقی (فونت آسیای شرقی اصلی)

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

این کد Java نشان می‌دهد که چگونه فونت لاتین را به یک عنصر تم اختصاص دهید:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
} finally {
    if (pres != null) pres.dispose();
}
```

فونت در تمام جعبه‌های متن به‌روز می‌شود.

{{% alert color="info" title="TIP" %}} 
ممکن است بخواهید [فونت‌های پاورپوینت](/slides/fa/java/powerpoint-fonts/) را مشاهده کنید.
{{% /alert %}}

## **تغییر سبک پس‌زمینه تم**

به‌طور پیش‌فرض، برنامه پاورپوینت ۱۲ پس‌زمینه پیش‌تعریف‌شده ارائه می‌دهد اما فقط ۳ تا از این ۱۲ پس‌زمینه در یک ارائه معمولی ذخیره می‌شوند.

![todo:image_alt_text](presentation-design_8.png)

برای مثال، پس از ذخیره یک ارائه در برنامه پاورپوینت، می‌توانید این کد Java را اجرا کنید تا تعداد پس‌زمینه‌های پیش‌تعریف‌شده در ارائه را بیابید:

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
با استفاده از [BackgroundFillStyles](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) می‌توانید سبک پس‌زمینه را در یک تم پاورپوینت افزودن یا دسترسی داشته باشید. 
{{% /alert %}} 

این کد Java نشان می‌دهد که چگونه پس‌زمینه‌ای برای یک ارائه تنظیم کنید:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
} finally {
    if (pres != null) pres.dispose();
}
```

**راهنمای اندیس**: 0 برای بدون پرکردن استفاده می‌شود. اندیس از ۱ شروع می‌شود.

{{% alert color="info" title="TIP" %}} 
ممکن است بخواهید [پس‌زمینه پاورپوینت](/slides/fa/java/presentation-background/) را مشاهده کنید.
{{% /alert %}}

## **تغییر افکت تم**

یک تم پاورپوینت معمولاً برای هر آرایه سبک ۳ مقدار دارد. این آرایه‌ها ترکیب شده و به این ۳ افکت: ظریف، متوسط و شدید تبدیل می‌شوند. برای مثال، این نتایج است زمانی که افکت‌ها بر روی یک شکل خاص اعمال می‌شوند:

![todo:image_alt_text](presentation-design_10.png)

با استفاده از ۳ ویژگی ([FillStyles](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FormatScheme#getEffectStyles--)) از کلاس [FormatScheme](https://reference.aspose.com/slides/fa/java/com.aspose.slides/FormatScheme) می‌توانید عناصر یک تم را تغییر دهید (حتی انعطاف‌پذیرتر از گزینه‌های موجود در پاورپوینت).

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

تغییرات حاصل در رنگ پرکننده، نوع پرکننده، افکت سایه و غیره:

![todo:image_alt_text](presentation-design_11.png)

## **پرسش‌های متداول**

### آیا می‌توانم تمی را بر روی یک اسلاید اعمال کنم بدون اینکه مستر را تغییر دهم؟

بله. Aspose.Slides از پوشش تم در سطح اسلاید پشتیبانی می‌کند، بنابراین می‌توانید تم محلی را فقط بر روی آن اسلاید اعمال کنید در حالی که تم مستر دست‌نخورده می‌ماند (از طریق [SlideThemeManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slidethememanager/)).

### ایمن‌ترین روش برای انتقال تم از یک ارائه به ارائه دیگر چیست؟

[کلون اسلایدها](/slides/fa/java/clone-slides/) همراه با مستر آنها را به ارائه هدف منتقل کنید. این کار مستر اصلی، طرح‌ها و تم مرتبط را حفظ می‌کند تا ظاهر یکسان باقی بماند.

### چگونه می‌توانم مقادیر «موثر» را پس از تمام وراثت و پوشش‌ها ببینم؟

از «نمایش‌های مؤثر» API (/slides/fa/java/shape-effective-properties/) برای تم/رنگ/فونت/افکت استفاده کنید. این‌ها خصوصیات نهایی حل‌شده پس از اعمال مستر به‌اضافه هر گونه پوشش محلی را باز می‌گردانند.