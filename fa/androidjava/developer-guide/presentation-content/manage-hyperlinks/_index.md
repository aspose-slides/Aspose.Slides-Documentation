---
title: مدیریت پیوندهای ارائه در Android
linktitle: مدیریت پیوندها
type: docs
weight: 20
url: /fa/androidjava/manage-hyperlinks/
keywords:
- افزودن URL
- افزودن پیوند
- ایجاد پیوند
- قالب‌بندی پیوند
- حذف پیوند
- بروزرسانی پیوند
- پیوند متن
- پیوند اسلاید
- پیوند شکل
- پیوند تصویر
- پیوند ویدیو
- پیوند قابل تغییر
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "افزودن، قالب‌بندی، بروزرسانی و حذف پیوندها در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای Android از طریق Java، با استفاده از مثال‌های Java."
---
## **مقدمه**

یک پیوند فرایکی محتویات ارائه را به یک وب‌سایت یا مکان داخلی درون ارائه متصل می‌کند. در PowerPoint، پیوندهای فرایکی معمولاً دو هدف دارند:

* باز کردن یک وب‌سایت از متن، شکل یا قاب رسانه‌ای.
* ناوبری به اسلاید دیگری، برای مثال از فهرست مطالب.

Aspose.Slides for Android via Java به شما امکان می‌دهد این پیوندها را اضافه کنید، ظاهر و صدای آن‌ها را کنترل کنید، ویژگی‌هایشان را بروزرسانی کنید و حذفشان کنید. نمونه‌های زیر نشان می‌دهند چگونه با پیوندهای فرایکی بر روی عناصر منفرد کار کنید و چگونه به پیوندها در سطح ارائه، اسلاید یا چارچوب متن دسترسی پیدا کنید.

{{% alert color="info" title="Note" %}}
می‌توانید ارائه‌ها را با [free online Aspose PowerPoint editor](https://products.aspose.app/slides/fa/editor) ویرایش کنید.
{{% /alert %}} 

## **اضافه کردن پیوندهای URL**

می‌توانید یک URL وب‌سایت را به متن، شکل یا قاب رسانه‌ای اختصاص دهید. عنصری که به آن پیوند فرایکی اختصاص می‌دهید، ناحیه کلیک‌پذیر را تعیین می‌کند: بخشی از متن فقط متن انتخاب شده را لینک می‌کند، در حالی که شکل یا قاب کل شیء اسلاید را لینک می‌کند.

### **اضافه کردن پیوندهای URL به متن**

برای لینک کردن متن به یک وب‌سایت، یک [Hyperlink](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/hyperlink/) را به متد [setHyperlinkClick](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) قسمت متن پاس می‌کنید، همان‌طور که در زیر نشان داده شده است. فقط همان بخش متن قابل کلیک می‌شود.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape textShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
    textShape.addTextFrame("Aspose: File Format APIs");
    IPortionFormat portionFormat = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");
    portionFormat.setFontHeight(32);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **اضافه کردن پیوندهای URL به اشکال و قاب‌های رسانه‌ای**

برای قابل کلیک کردن کردن یک شکل یا قاب، متد [setHyperlinkClick](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) آن را فراخوانی کنید. پیوند به خود شیء تعلق دارد نه به بخش متنی داخل آن.

همین روش برای قاب‌های تصویر، صدا و ویدیو اعمال می‌شود: پیوند را به قاب اختصاص دهید و در صورت نیاز متد [setTooltip](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) را فراخوانی کنید.

مثال زیر یک مستطیل را قابل کلیک می‌کند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

    shape.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **استفاده از پیوندهای فرایکی برای ایجاد فهرست مطالب**

پیوندهای داخلی به خوانندگان امکان می‌دهند از فهرست مطالب به اسلاید خاصی پرش کنند. مثال زیر از متد [setInternalHyperlinkClick](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) برای لینک کردن متن «Page 2» در اسلاید اول به اسلاید دوم استفاده می‌کند.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ISlide secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    IAutoShape tableOfContents = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
    tableOfContents.getFillFormat().setFillType(FillType.NoFill);
    tableOfContents.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    tableOfContents.getTextFrame().getParagraphs().clear();

    Paragraph paragraph = new Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    paragraph.setText("Title of slide 2 .......... ");

    Portion linkPortion = new Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

    paragraph.getPortions().add(linkPortion);
    tableOfContents.getTextFrame().getParagraphs().add(paragraph);

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **قالب‌بندی پیوندهای فرایکی**

### **رنگ**

متد [setColorSource](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ihyperlink/#setColorSource-int-) از [IHyperlink](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ihyperlink/) تعیین می‌کند که آیا پیوند فرایکی از رنگ پیوندهای ارائه یا قالب‌بندی بخش متن استفاده کند. برای اعمال یک رنگ متن سفارشی، [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/hyperlinkcolorsource/) را انتخاب کنید و رنگ پر کردن بخش را تنظیم کنید. این ویژگی در PowerPoint 2019 معرفی شد؛ نسخه‌های قدیمی‌تر این تنظیم را اعمال نمی‌کنند.

مثال زیر دو پیوند متن را به همان اسلاید اضافه می‌کند. اولین پیوند با پر کردن قرمز متن نمایش داده می‌شود، در حالی که دومین پیوند رنگ پیش‌فرض پیوند را حفظ می‌کند.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IAutoShape coloredShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
    coloredShape.addTextFrame("This hyperlink uses a custom color.");
    IPortionFormat coloredPortionFormat = coloredShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    coloredPortionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    coloredPortionFormat.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat);
    coloredPortionFormat.getFillFormat().setFillType(FillType.Solid);
    coloredPortionFormat.getFillFormat().getSolidFillColor().setColor(Color.RED);

    IAutoShape defaultShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
    defaultShape.addTextFrame("This hyperlink uses the default color.");
    defaultShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **صدا**

یک پیوند فرایکی می‌تواند هنگام فعال شدن صدا پخش کند یا صدایی که هم‌اکنون در حال پخش است متوقف سازد. از متدهای زیر برای پیکربندی این رفتارها استفاده کنید:

- [IHyperlink.setSound](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) صدای مرتبط با پیوند را تعیین می‌کند.
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) کنترل می‌کند که آیا فعال‌سازی پیوند صدای قبلی را متوقف می‌کند یا نه.

#### **اضافه کردن صدای پیوند فرایکی**

مثال زیر فایل `sampleaudio.wav` را بارگذاری کرده و آن را به یک دکمه در اسلاید اول وابسته می‌کند. کلیک روی دکمه صدا را پخش می‌کند و به اسلاید بعدی می‌رود. یک شکل دوم در همان اسلاید صدای قبلی را هنگام کلیک متوقف می‌کند، بدون اینکه عمل ناوبری انجام دهد.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    IAudio hyperlinkSound;
    try (FileInputStream audioStream = new FileInputStream("sampleaudio.wav")) {
        hyperlinkSound = presentation.getAudios().addAudio(audioStream);
    }

    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IAutoShape playButton = firstSlide.getShapes().addAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
    playButton.setHyperlinkClick(Hyperlink.getNextSlide());

    if (!playButton.getHyperlinkClick().getStopSoundOnClick() && playButton.getHyperlinkClick().getSound() == null)
    {
        playButton.getHyperlinkClick().setSound(hyperlinkSound);
    }

    ISlide secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    IAutoShape stopButton = secondSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
    stopButton.setHyperlinkClick(Hyperlink.getNoAction());

    stopButton.getHyperlinkClick().setStopSoundOnClick(true);

    presentation.save("hyperlink-sound.pptx", SaveFormat.Pptx);
} catch (IOException exception) {
    System.out.println("Unable to read the audio file: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

#### **استخراج صدای پیوند فرایکی**

مثال زیر ارائه ایجاد شده در بالا را باز می‌کند و صدای پیوند فرایکی شکل اول را از طریق متدهای [getSound](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ihyperlink/#getSound--) و [getBinaryData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iaudio/#getBinaryData--) به حافظه می‌خواند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hyperlink-sound.pptx");
try {
    if (presentation.getSlides().size() > 0 && presentation.getSlides().get_Item(0).getShapes().size() > 0) {
        IHyperlink hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick();
        IAudio sound = hyperlink == null ? null : hyperlink.getSound();
        if (sound != null) {
            byte[] audioData = sound.getBinaryData();
            System.out.println("Extracted " + audioData.length + " bytes of hyperlink audio.");
        } else {
            System.out.println("The first shape has no hyperlink sound.");
        }
    } else {
        System.out.println("The presentation has no first slide or shape to inspect.");
    }
} finally {
    presentation.dispose();
}
```

### **راهنما (Tooltip) و تنظیمات تعامل**

پس از اختصاص پیوند به متن یا شکل می‌توانید متدهای زیر [IHyperlink](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ihyperlink/) را فراخوانی کنید:

- [setTooltip](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) متنی که نمایشگر می‌تواند به‌عنوان راهنمای لینک نشان دهد، تنظیم می‌کند.
- [setTargetFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) فریم هدف درون یک مجموعه فریم HTML والد را (در صورت موجود بودن) تعیین می‌کند.
- [setHistory](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ihyperlink/#setHistory-boolean-) کنترل می‌کند که آیا فعال‌سازی لینک مقصد را به فهرست پیوندهای مشاهده‌شده اضافه می‌کند یا نه.
- [setHighlightClick](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) تعیین می‌کند که آیا پیوند هنگام کلیک برجسته شود یا نه.

## **حذف پیوندهای فرایکی از ارائه‌ها**

از متد [getAnyHyperlinks](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) برای جمع‌آوری کانتینرهای پیوند، شامل پیوندهای بخش متن، پیش از تغییر آن‌ها استفاده کنید. مثال زیر هر دو نوع فعال‌سازی را از اسلاید اول حذف می‌کند. برای حذف تنها یک نوع، فقط [removeHyperlinkClick](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) یا [removeHyperlinkMouseOver](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) را فراخوانی کنید؛ حذف عمل کلیک، همتاهای موس‑اور آن را حذف نمی‌کند.

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

Presentation presentation = new Presentation("pres.pptx");
try {
    if (presentation.getSlides().size() > 0) {
        List<IHyperlinkContainer> containers = new ArrayList<>();
        for (IHyperlinkContainer container : presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks()) {
            containers.add(container);
        }
        for (IHyperlinkContainer container : containers) {
            container.getHyperlinkManager().removeHyperlinkClick();
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
        presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The presentation has no slides to process.");
    }
} finally {
    presentation.dispose();
}
```

برای حذف بدون شرط، متد [removeAllHyperlinks](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) هر دو نوع فعال‌سازی را در محدوده انتخاب‌شده در یک فراخوانی حذف می‌کند. برای پاکسازی انتخابی و پوشش مسترها، طرح‌بندی‌ها و یادداشت‌ها، به بخش [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) مراجعه کنید.

## **ساخت یک فهرست کامل از پیوندهای فرایکی**

قبل از توزیع یک ارائه، اقدامات تعاملی و لینک‌های وب آن را فهرست کنید. متد [getAnyHyperlinks](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) اشیاء [IHyperlinkContainer](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ihyperlinkcontainer/) را بر می‌گرداند، نه فهرست صاف رشته‌های URL. بر هر کانتینر هم متدهای [getHyperlinkClick](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) و [getHyperlinkMouseOver](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) را بررسی کنید. این دو مستقل هستند: یک کانتینر می‌تواند هر دو عمل را در خود داشته باشد، بنابراین گزارش کامل ممکن است تا دو ردیف برای هر کانتینر نیاز داشته باشد.

اسکن فقط پیوندهای سطح شکل می‌تواند لینک‌های پیوست‌شده به بخش‌های متن را از دست بدهد. به جای آن، حوزه مناسب را کوئری کنید و کانتینرهای بازگشتی را نگه دارید تا سپس بتوانید اعمال آن‌ها را بروزرسانی یا حذف کنید.

### **کوئری حوزه‌های ارائه، اسلاید و چارچوب متن**

رابط [IHyperlinkQueries](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ihyperlinkqueries/) از طریق [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ipresentation/#getHyperlinkQueries--)، [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) و [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/#getHyperlinkQueries--) در دسترس است. هر حوزه همین کوئری‌ها را پشتیبانی می‌کند:

- [getHyperlinkClicks](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) کانتینرهای دارای عمل کلیک را بر می‌گرداند.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) کانتینرهای دارای عمل موس‑اور را بر می‌گرداند.
- [getAnyHyperlinks](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) کانتینرهایی که هر یک یا هر دو عمل را دارند بر می‌گرداند.

مثال زیر فایلی به نام `hyperlink-audit-input.pptx` ایجاد می‌کند که شامل یک لینک کلیک خارجی، یک لینک موس‑اور فایل، ناوبری داخلی اسلاید، یک لینک موس‑اور متن و یک عمل ماکرو است. این مثال هیچ‌یک از این اعمال را اجرا نمی‌کند. همان سه کوئری در هر حوزه کار می‌کند؛ شمارش‌ها نشان‌دهنده تعداد کانتینرها، نه مجموع اعمال هستند. حوزه چارچوب متن لینک‌های خود شکل enclosing را شامل نمی‌شود.

```java
import com.aspose.slides.*;

class QueryCounts {
    void print(String scope, IHyperlinkQueries queries) {
        int clickCount = queries.getHyperlinkClicks().size();
        int mouseOverCount = queries.getHyperlinkMouseOvers().size();
        int anyCount = queries.getAnyHyperlinks().size();
        System.out.println(scope + ": click=" + clickCount + ", mouse-over=" + mouseOverCount + ", any=" + anyCount);
    }
}

QueryCounts counts = new QueryCounts();
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ISlide destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide());
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Click the text to go to slide 2");
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/");
    shape.getHyperlinkClick().setTooltip("Public website");
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    IPortionFormat portionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.getHyperlinkManager().setInternalHyperlinkClick(destination);
    portionFormat.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help");
    IAutoShape macroButton = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 120, 200, 60);
    macroButton.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation");

    counts.print("Presentation", presentation.getHyperlinkQueries());
    counts.print("Slide 1", slide.getHyperlinkQueries());
    counts.print("Text frame", shape.getTextFrame().getHyperlinkQueries());
    presentation.save("hyperlink-audit-input.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

در این مثال، کوئری‌های ارائه و اسلاید هر کدام سه کانتینر کلیک، دو کانتینر موس‑اور و سه کانتینر با هر یک از این دو عمل را گزارش می‌دهند. کوئری چارچوب متن یک کانتینر در هر دسته گزارش می‌کند.

### **دسته‌بندی اعمال و مقصدها**

از متد [IHyperlink.getActionType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ihyperlink/#getActionType--) برای تفسیر یک عمل قبل از تفسیر مقصد آن استفاده کنید. مقادیر [HyperlinkActionType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/hyperlinkactiontype/) موارد بیش از ناوبری وب را شامل می‌شوند:

| مقدارها | معنی برای یک بازرسی |
| --- | --- |
| `Hyperlink` | پیوند خارجی؛ URL و طرح آن را بررسی کنید. |
| `JumpSpecificSlide` | ناوبری داخلی به اسلاید خاصی. |
| `JumpFirstSlide` | پرش به اولین اسلاید. |
| `JumpPreviousSlide` | پرش به اسلاید قبلی. |
| `JumpNextSlide` | پرش به اسلاید بعدی. |
| `JumpLastSlide` | پرش به آخرین اسلاید. |
| `JumpLastViewedSlide` | پرش به آخرین اسلاید مشاهده‌شده. |
| `JumpEndShow` | پایان نمایش جاری. |
| `StartCustomSlideShow` | شروع یک نمایش سفارشی. |
| `StartMacro` | اجرای یک ماکرو. |
| `StartProgram` | اجرای یک برنامه. |
| `OpenFile` | باز کردن یک فایل؛ به صورت جداگانه بررسی شود. |
| `OpenPresentation` | باز کردن یک ارائه دیگر؛ به صورت جداگانه بررسی شود. |
| `StartStopMedia` | شروع یا توقف پخش رسانه. |
| `NoAction` | هیچ عمل ناوبری‌ای ندارد. |
| `Unknown` | عمل ناشناخته؛ نیاز به بررسی دارد. |

مقاصد خارجی را از طریق [getExternalUrl](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) و مقاصد داخلی خاص را از طریق [getTargetSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ihyperlink/#getTargetSlide--) بخوانید. اعمال داخلی و دستورات داخلی ممکن است URL خارجی نداشته باشند؛ URL خالی به این معنی نیست که کانتینر بدون عمل باشد. هنگامی که مقدار بازگشتی [getExternalUrlOriginal](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) متفاوت از URL نرمال‌شده باشد، آن را حفظ کنید و راهنمایی (tooltip) بازگشتی توسط [getTooltip](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ihyperlink/#getTooltip--) را در صورت موجود بودن شامل کنید.

### **گزارش، پاکسازی و اعتبارسنجی پیوندهای فرایکی**

مثال Java زیر یک ارائه موجود (از فایلی که در بالا ایجاد شد) می‌خواند، `hyperlink-audit.json` می‌نویسد، سیاستی اعمال می‌کند، `hyperlink-sanitized.pptx` را ذخیره می‌کند و دوباره باز می‌کند تا هر دو نوع فعال‌سازی را دوباره بررسی کند. قبل از تغییر، کانتینرها را جمع‌آوری می‌کند و برای جلوگیری از پردازش دوبار یکسان، از برابری ارجاعی استفاده می‌کند. کوئری‌های ارائه اسلایدهای عادی را پوشش می‌دهد؛ برای فهرست‌گیری در سطوح بسته، مسترها، طرح‌بندی‌ها، یادداشت‌ها و مسترهای یادداشت و توزیع‌کننده نیز به صورت صریح کوئری می‌شوند.

گزارش شامل شماره اسلاید مبتنی بر یک و [getSlideId](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibaseslide/#getSlideId--) (در صورت موجود بودن) است. [ISlideComponent.getSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/islidecomponent/#getSlide--) اسلاید مالک را برای کانتینرهای پشتیبانی‌شده فراهم می‌کند. مسترها، طرح‌بندی‌ها و یادداشت‌ها شناسه اسلاید عادی ندارند و بر حسب حوزه‌شان شناسایی می‌شوند. کانتینرهای شکل و قالب‌بندی بخش متن به‌صورت جداگانه برچسب‌گذاری می‌شوند؛ سایر انواع کانتینر نام نوع زمان اجرا خود را حفظ می‌کنند. هر کانتینر یک شناسه گزارش‑محلی دریافت می‌کند تا دو عمل آن بتوانند مرتبط شوند. نوع عمل‌ها به عنوان ثابت‌های عددی تعریف‌شده توسط شمارش Java ذخیره می‌شود.

این سیاست کاربردی به‌صورت عمدی فقط URLهای مطلق HTTPS و اهداف اسلاید داخلی معتبر را می‌پذیرد. ماکروها، برنامه‌ها، اعمال فایل، سایر اعمال اسلایدشو، اعمال ناشناخته و طرح‌های URL دیگر رد می‌شوند. این ردها تصمیمات سیاستی هستند، نه قضاوت ایمنی Aspose.Slides. تنها HTTPS به تنهایی اعتماد را تضمین نمی‌کند: لیست‌های سفید میزبان و سایر بررسی‌ها را برای برنامه خود اضافه کنید. هر دو URL خارجی اصلی و نرمال‌شده بررسی می‌شوند. مثال متادیتاها را بدون دنبال کردن لینک‌ها یا اجرای اعمال بازرسی می‌کند.

برای رفع نقص، [getHyperlinkManager](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) کانتینر از متدهای [setExternalHyperlinkClick](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-)، [removeHyperlinkClick](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) و [removeHyperlinkMouseOver](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) پشتیبانی می‌کند. در اینجا، لینک‌های کلیک خارجی منع‌شده با یک صفحه لندینگ ثابت HTTPS جایگزین می‌شوند؛ کلیک‌ها و موس‑اورهای منع‌شده دیگر به‌صورت مستقل حذف می‌شوند. مقدار `replaceExternalClicks` را روی `false` بگذارید تا تمام تخلفات سیاست حذف شوند. قبل از استقرار، یک صفحه جایگزین متعلق به برنامه خود انتخاب کنید.

پرچم خروجی گزارش از یک سیاست بررسی PDF محتاطانه استفاده می‌کند: اعمال موس‑اور و هر چیزی غیر از لینک خارجی یا پرش اسلاید خاص را به‌عنوان احتمال عدم پشتیبانی علامت‌گذاری می‌کند. این یک نکته بررسی است، نه تست قابلیت یا تضمین این که لینک‌های بدون پرچم در خروجی بقا داشته باشند. خروجی‌های PDF و HTML پشتیبانی‌شده ممکن است پیوندها را حفظ کنند، بسته به عمل، گزینه‌های خروجی و نمایشگر. تصاویر رستر و ویدیو نمی‌توانند پیوندهای تعاملی را حفظ کنند؛ هنگام بازرسی برای این خروجی‌ها هر عمل را پرچم بزنید.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;
import java.nio.charset.StandardCharsets;
import java.io.FileOutputStream;
import android.text.TextUtils;
import java.util.ArrayList;
import java.util.Collections;
import java.util.IdentityHashMap;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Objects;
import java.util.Set;

class HyperlinkAudit {
    Integer slideIndex(IPresentation presentation, IBaseSlide slide) {
        for (int index = 0; index < presentation.getSlides().size(); index++) {
            if (presentation.getSlides().get_Item(index) == slide) return index + 1;
        }
        return null;
    }

    boolean isHttps(String value) {
        if (value == null || value.isEmpty()) return false;
        try {
            URI uri = new URI(value);
            return uri.isAbsolute() && "https".equalsIgnoreCase(uri.getScheme()) && uri.getHost() != null;
        } catch (URISyntaxException exception) {
            return false;
        }
    }

    String policyViolation(IHyperlink link) {
        if (link == null) return null;
        if (link.getActionType() == HyperlinkActionType.JumpSpecificSlide) {
            return link.getTargetSlide() == null ? "Missing target slide" : null;
        }
        if (link.getActionType() != HyperlinkActionType.Hyperlink) return "Action is not allowed";
        if (!isHttps(link.getExternalUrl())) return "Normalized URL is not absolute HTTPS";
        String original = link.getExternalUrlOriginal();
        if (original != null && !original.isEmpty() && !isHttps(original)) return "Original URL is not absolute HTTPS";
        return null;
    }

    void addScope(List<IHyperlinkContainer> found, IBaseSlide slide) {
        if (slide != null) {
            for (IHyperlinkContainer container : slide.getHyperlinkQueries().getAnyHyperlinks()) {
                found.add(container);
            }
        }
    }

    List<IHyperlinkContainer> collectContainers(IPresentation presentation) {
        List<IHyperlinkContainer> found = new ArrayList<>();
        for (IHyperlinkContainer container : presentation.getHyperlinkQueries().getAnyHyperlinks()) {
            found.add(container);
        }
        for (IMasterSlide master : presentation.getMasters()) addScope(found, master);
        for (ILayoutSlide layout : presentation.getLayoutSlides()) addScope(found, layout);
        for (ISlide slide : presentation.getSlides()) addScope(found, slide.getNotesSlideManager().getNotesSlide());
        addScope(found, presentation.getMasterNotesSlideManager().getMasterNotesSlide());
        addScope(found, presentation.getMasterHandoutSlideManager().getMasterHandoutSlide());
        Set<IHyperlinkContainer> seen = Collections.newSetFromMap(new IdentityHashMap<IHyperlinkContainer, Boolean>());
        List<IHyperlinkContainer> unique = new ArrayList<>();
        for (IHyperlinkContainer container : found) {
            if (seen.add(container)) unique.add(container);
        }
        return unique;
    }

    void addRow(List<Map<String, Object>> rows, IPresentation presentation, IHyperlink link, String activation, IHyperlinkContainer container, int containerId) {
        if (link == null) return;
        IBaseSlide ownerSlide = container instanceof ISlideComponent ? ((ISlideComponent) container).getSlide() : null;
        ISlide targetSlide = link.getTargetSlide();
        String violation = policyViolation(link);
        String ownerType = container instanceof IShape ? "Shape" : container instanceof IPortionFormat ? "Text portion" : container.getClass().getSimpleName();
        boolean ordinaryAction = link.getActionType() == HyperlinkActionType.Hyperlink || link.getActionType() == HyperlinkActionType.JumpSpecificSlide;
        Map<String, Object> row = new LinkedHashMap<>();
        row.put("ContainerId", containerId);
        row.put("SlideIndex", slideIndex(presentation, ownerSlide));
        row.put("SlideId", ownerSlide == null ? null : ownerSlide.getSlideId());
        row.put("Scope", ownerSlide == null ? null : ownerSlide.getClass().getSimpleName());
        row.put("OwnerType", ownerType);
        row.put("Activation", activation);
        row.put("ActionType", link.getActionType());
        row.put("ExternalUrl", link.getExternalUrl());
        row.put("TargetSlideIndex", slideIndex(presentation, targetSlide));
        row.put("TargetSlideId", targetSlide == null ? null : targetSlide.getSlideId());
        row.put("Tooltip", link.getTooltip());
        row.put("OriginalExternalUrl", Objects.equals(link.getExternalUrlOriginal(), link.getExternalUrl()) ? null : link.getExternalUrlOriginal());
        row.put("PotentiallyUnsafe", violation != null);
        row.put("PolicyViolation", violation);
        row.put("TargetExport", "PDF");
        row.put("PotentiallyUnsupportedByExport", "mouse-over".equals(activation) || !ordinaryAction);
        rows.add(row);
    }

    // سریال‌سازی ردیف‌های صاف این گزارش بدون وابستگی اضافی به JSON.
    String jsonValue(Object value) {
        if (value == null) return "null";
        if (value instanceof Number || value instanceof Boolean) return value.toString();
        StringBuilder escaped = new StringBuilder("\"");
        for (char character : value.toString().toCharArray()) {
            if (character == '"' || character == '\\') {
                escaped.append('\\').append(character);
            } else if (character < 0x20 || Character.isSurrogate(character)) {
                escaped.append(String.format("\\u%04x", (int) character));
            } else {
                escaped.append(character);
            }
        }
        return escaped.append('"').toString();
    }

    String toJson(List<Map<String, Object>> rows) {
        List<String> objects = new ArrayList<>();
        for (Map<String, Object> row : rows) {
            List<String> fields = new ArrayList<>();
            for (Map.Entry<String, Object> field : row.entrySet()) {
                fields.add("    " + jsonValue(field.getKey()) + ": " + jsonValue(field.getValue()));
            }
            objects.add("  {\n" + TextUtils.join(",\n", fields) + "\n  }");
        }
        return "[\n" + TextUtils.join(",\n", objects) + "\n]\n";
    }
}

boolean replaceExternalClicks = true;
String replacementUrl = "https://example.com/blocked-link";
HyperlinkAudit audit = new HyperlinkAudit();
Presentation presentation = new Presentation("hyperlink-audit-input.pptx");
try {
    List<IHyperlinkContainer> containers = audit.collectContainers(presentation);
    List<Map<String, Object>> rows = new ArrayList<>();
    for (int index = 0; index < containers.size(); index++) {
        IHyperlinkContainer container = containers.get(index);
        audit.addRow(rows, presentation, container.getHyperlinkClick(), "click", container, index + 1);
        audit.addRow(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, index + 1);
    }
    String json = audit.toJson(rows);
    byte[] jsonData = json.getBytes(StandardCharsets.UTF_8);
    try (FileOutputStream reportStream = new FileOutputStream("hyperlink-audit.json")) {
        reportStream.write(jsonData);
    }

    for (IHyperlinkContainer container : containers) {
        IHyperlink click = container.getHyperlinkClick();
        if (audit.policyViolation(click) != null) {
            if (replaceExternalClicks && click.getActionType() == HyperlinkActionType.Hyperlink) {
                container.getHyperlinkManager().setExternalHyperlinkClick(replacementUrl);
            } else {
                container.getHyperlinkManager().removeHyperlinkClick();
            }
        }
        if (audit.policyViolation(container.getHyperlinkMouseOver()) != null) {
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
    }
    presentation.save("hyperlink-sanitized.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("hyperlink-sanitized.pptx");
    try {
        List<IHyperlinkContainer> remainingContainers = audit.collectContainers(reopened);
        int violations = 0;
        for (IHyperlinkContainer container : remainingContainers) {
            if (audit.policyViolation(container.getHyperlinkClick()) != null) violations++;
            if (audit.policyViolation(container.getHyperlinkMouseOver()) != null) violations++;
        }
        System.out.println("Audit rows: " + rows.size() + "; prohibited actions after reopening: " + violations);
        if (violations != 0) {
            System.out.println("Verification failed: do not distribute the saved presentation.");
        }
    } finally {
        reopened.dispose();
    }
} catch (IOException exception) {
    System.out.println("Unable to write the audit report: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

با ورودی ساخته‌شده در بالا، گزارش شامل پنج ردیف عمل است. لینک موس‑اور فایل و کلیک ماکرو حذف می‌شوند، در حالی که لینک‌های HTTPS و ناوبری داخلی اسلاید باقی می‌مانند. اعتبارسنجی صفر عمل ممنوع چاپ می‌کند. یک ورودی با URL کلیک خارجی ممنوع نیز شاخه جایگزینی را اجرا می‌کند. یک کانتینر با کلیک مجاز و موس‑اور ممنوع، عمل کلیک خود را حفظ می‌کند.

این پاکسازی انتخابی متفاوت از [removeAllHyperlinks](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) است که هر دو نوع فعال‌سازی را در سراسر حوزه انتخابی بدون توجه به سیاست حذف می‌کند. اعتبارسنجی در اینجا تنها اعمال پیوندها را بررسی می‌کند؛ پروژه‌های VBA نهفته، اشیاء OLE یا سایر محتوای فعال را حذف نمی‌کند و همچنین فایل PDF یا HTML خروجی را اعتبارسنجی نمی‌کند.

## **سوالات متداول**

**چگونه می‌توانم به یک بخش یا اسلاید اول آن لینک کنم؟**

بخش‌ها در PowerPoint اسلایدها را گروه‌بندی می‌کنند، اما یک پیوند داخلی به یک اسلاید منفرد هدف می‌گیرد. برای ایجاد ناوبری به یک بخش، به اولین اسلاید آن بخش لینک کنید.

**آیا می‌توانم پیوندی را به عناصر اسلاید مستر الصاق کنم تا در تمام اسلایدها کار کند؟**

بله. عناصر مستر اسلاید و طرح‌بندی از پیوندها پشتیبانی می‌کنند. لینک‌های این عناصر در زمان نمایش اسلایدها که از مستر یا طرح‌بندی مربوطه استفاده می‌کنند، در دسترس هستند.

**آیا پیوندها هنگام خروجی به PDF، HTML، تصاویر یا ویدیو حفظ می‌شوند؟**

خروجی‌های PDF و HTML پشتیبانی‌شده ممکن است پیوندها را حفظ کنند؛ تصاویر رستر و ویدیو نمی‌توانند پیوندهای تعاملی را حفظ کنند. برای جزئیات بیشتر به بخش [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) مراجعه کنید.