---
title: مدیریت ابرپیوندهای ارائه در جاوا
linktitle: مدیریت ابرپیوندها
type: docs
weight: 20
url: /fa/java/manage-hyperlinks/
keywords:
- افزودن URL
- افزودن ابرپیوند
- ایجاد ابرپیوند
- قالب‌بندی ابرپیوند
- حذف ابرپیوند
- به‌روزرسانی ابرپیوند
- ابرپیوند متن
- ابرپیوند اسلاید
- ابرپیوند شکل
- ابرپیوند تصویر
- ابرپیوند ویدئو
- ابرپیوند قابل تغییر
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "اضافه‌کردن، قالب‌بندی، به‌روزرسانی و حذف ابرپیوندها در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای جاوا، با استفاده از نمونه‌های جاوا."
---
## **معرفی**

یک ابرپیوند محتویات ارائه را به یک وب‌سایت یا به موقعیتی داخل ارائه متصل می‌کند. در PowerPoint، ابرپیوندها معمولاً دو هدف را دنبال می‌کنند:

* باز کردن یک وب‌سایت از متن، یک شکل یا یک قاب رسانه‌ای.
* رفتن به اسلاید دیگری، برای مثال، از فهرست مطالب.

Aspose.Slides for Java به شما امکان می‌دهد این پیوندها را اضافه کنید، ظاهر و صدای آن‌ها را کنترل کنید، ویژگی‌هایشان را به‌روزرسانی کنید و حذف کنید. مثال‌های زیر نشان می‌دهند چگونه با ابرپیوندها بر روی عناصر منفرد کار کنید و چگونه به ابرپیوندها در سطح ارائه، اسلاید یا قاب متن دسترسی داشته باشید.

{{% alert color="info" title="Note" %}}

شما همچنین می‌توانید ارائه‌ها را با [ویرایشگر رایگان آنلاین Aspose PowerPoint](https://products.aspose.app/slides/editor) ویرایش کنید.

{{% /alert %}} 

## **افزودن ابرپیوندهای URL**

شما می‌توانید URL یک وب‌سایت را به متن، یک شکل یا یک قاب رسانه‌ای اختصاص دهید. عنصری که به آن ابرپیوند اختصاص می‌دهید، ناحیه قابل‌کلیک را تعیین می‌کند: یک بخش متن لینک متن انتخاب‌شده را می‌سازد، در حالی که یک شکل یا قاب، شی اسلاید را لینک می‌کند.

برای ارائه‌های حاوی ابرپیوندهای نسبی، به [مدیریت پایه ابرپیوند](/slides/fa/java/presentation-properties/#manage-the-hyperlink-base) مراجعه کنید تا پایه سطح سند را بخوانید، تغییر دهید یا پاک کنید.

### **افزودن ابرپیوندهای URL به متن**

برای لینک کردن متن به یک وب‌سایت، یک [Hyperlink](https://reference.aspose.com/slides/java/com.aspose.slides/hyperlink/) را به متد [setHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) بخش متن پاس کنید، همان‌طور که در زیر نشان داده شده است. تنها آن بخش از متن قابل کلیک می‌شود.

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

### **افزودن ابرپیوندهای URL به شکل‌ها و قاب‌های رسانه‌ای**

برای قابل کلیک کردن یک شکل یا قاب، متد [setHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) آن را صدا بزنید. ابرپیوند به خود شی مربوط است نه به بخش متنی داخل آن.

رویکرد مشابه برای قاب‌های تصویر، صدا و ویدئو اعمال می‌شود: ابرپیوند را به قاب اختصاص دهید و در صورت نیاز متد [setTooltip](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) را فراخوانی کنید.

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

## **استفاده از ابرپیوندها برای ایجاد فهرست مطالب**

ابرفیوندهای داخلی به خوانندگان اجازه می‌دهند از فهرست مطالب به اسلاید خاصی پرش کنند. مثال زیر از متد [setInternalHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) برای لینک کردن متن «صفحه ۲» در اسلاید اول به اسلاید دوم استفاده می‌کند.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **قالب‌بندی ابرپیوندها**

### **رنگ**

متد [setColorSource](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setColorSource-int-) از [IHyperlink](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/) تعیین می‌کند که آیا یک ابرپیوند از رنگ ابرپیوند ارائه یا قالب‌بندی بخش متن استفاده کند. برای اعمال رنگ متن سفارشی، گزینه [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/hyperlinkcolorsource/) را انتخاب کنید و رنگ پر کردن بخش را تنظیم کنید. این ویژگی در PowerPoint 2019 معرفی شد؛ نسخه‌های قدیمی‌تر این تنظیم را اعمال نمی‌کنند.

مثال زیر دو ابرپیوند متنی به همان اسلاید اضافه می‌کند. اولین ابرپیوند از پر رنگ قرمز متن استفاده می‌کند، در حالی که دومین ابرپیوند رنگ پیش‌فرض ابرپیوند را حفظ می‌کند.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

یک ابرپیوند می‌تواند هنگام فعال‌شدن صدا پخش کند یا صدایی که در حال پخش است متوقف کند. از روش‌های زیر برای پیکربندی این رفتارها استفاده کنید:

- متد [IHyperlink.setSound](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) صدای مرتبط با ابرپیوند را تعیین می‌کند.
- متد [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) کنترل می‌کند که آیا فعال‌سازی ابرپیوند صدای قبلی را متوقف می‌کند یا نه.

#### **افزودن صدای ابرپیوند**

مثال زیر فایل `sampleaudio.wav` را بارگذاری کرده و آن را به یک دکمه در اسلاید اول نسبت می‌دهد. کلیک بر روی دکمه صدا را پخش می‌کند و به اسلاید بعدی می‌رود. یک شکل دوم در همان اسلاید با کلیک، صدای قبلی را متوقف می‌کند، بدون اینکه عمل ناوبری انجام دهد.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("sampleaudio.wav"));
    IAudio hyperlinkSound = presentation.getAudios().addAudio(audioData);

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

#### **استخراج صدای ابرپیوند**

مثال زیر ارائه‌ای که در بالا ایجاد شد را باز می‌کند و صدای ابرپیوند اولین شکل را از طریق متدهای [getSound](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getSound--) و [getBinaryData](https://reference.aspose.com/slides/java/com.aspose.slides/iaudio/#getBinaryData--) به حافظه می‌خواند.

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

### **راهنما و تنظیمات تعامل**

پس از اختصاص ابرپیوند به متن یا شکل، می‌توانید متدهای زیر از [IHyperlink](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/) را فراخوانی کنید:

- متد [setTooltip](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) متنی را تنظیم می‌کند که بیننده می‌تواند به عنوان راهنمایی برای لینک نمایش دهد.
- متد [setTargetFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) فریم هدف را در داخل یک فریم‌ست HTML والد، در صورت امکان، مشخص می‌کند.
- متد [setHistory](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setHistory-boolean-) کنترل می‌کند که آیا فعال‌سازی لینک مقصد آن را به فهرست ابرپیوندهای مشاهده‌شده اضافه می‌کند یا نه.
- متد [setHighlightClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) کنترل می‌کند که آیا ابرپیوند هنگام کلیک برجسته شود یا نه.

## **حذف ابرپیوندها از ارائه‌ها**

از متد [getAnyHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) برای جمع‌آوری کانتینرهای ابرپیوند، از جمله لینک‌های بخش متن، پیش از تغییر آن‌ها استفاده کنید. مثال زیر هر دو نوع فعال‌سازی را از اسلاید اول حذف می‌کند. برای حذف فقط یک نوع، فقط متد [removeHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) یا [removeHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) را صدا بزنید؛ حذف عمل کلیک، معادل بازدارنده ماوس را حذف نمی‌کند.

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

برای حذف بدون شرط، متد [removeAllHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) هر دو نوع فعال‌سازی را در محدوده انتخاب‌شده در یک فراخوانی حذف می‌کند. برای پاک‌سازی انتخابی و پوشش مسترها، طرح‌ها و یادداشت‌ها، به [گزارش، تصفیه و تأیید ابرپیوندها](#report-sanitize-and-verify-hyperlinks) مراجعه کنید.

## **ساخت موجودی کامل ابرپیوندها**

قبل از توزیع یک ارائه، موجودی اقدامات تعاملی و وب‌لینک‌های آن را تهیه کنید. متد [getAnyHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) اشیاء [IHyperlinkContainer](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/) را بر می‌گرداند، نه فهرست ساده‌ای از رشته‌های URL. هر دو متد [getHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) و [getHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) را برای هر کانتینر بررسی کنید. این‌ها مستقل هستند: همان کانتینر می‌تواند هر دو عمل را نشان دهد، بنابراین یک گزارش کامل ممکن است تا دو ردیف برای هر کانتینر نیاز داشته باشد.

اسکن فقط ابرپیوندهای سطح شکل می‌تواند لینک‌های متصل به بخش‌های متنی را از دست بدهد. به‌جای آن، محدوده مناسب را پرس و جو کنید و کانتینرهای برگردانده‌شده را حفظ کنید تا بعدها بتوانید اقدامات آن‌ها را به‌روزرسانی یا حذف کنید.

### **پرس و جو محدوده‌های ارائه، اسلاید و قاب‑متن**

رابطه [IHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/) از طریق متدهای [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getHyperlinkQueries--), [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--), و [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getHyperlinkQueries--) در دسترس است. هر محدوده همان پرس‌وجوها را پشتیبانی می‌کند:

- متد [getHyperlinkClicks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) کانتینرهای دارای عمل کلیک را بر می‌گرداند.
- متد [getHyperlinkMouseOvers](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) کانتینرهای دارای عمل ماوس‑اور را بر می‌گرداند.
- متد [getAnyHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) کانتینرهایی که یکی یا هر دو عمل را دارند بر می‌گرداند.

مثال زیر فایلی به نام `hyperlink-audit-input.pptx` ایجاد می‌کند که شامل یک لینک کلیک خارجی، یک لینک ماوس‑اور بر روی فایل، ناوبری داخلی اسلاید، یک لینک ماوس‑اور متنی و یک عمل ماکرو است. این مثال هیچ‌یک از این اعمال را اجرا نمی‌کند. همان سه پرس‌وجو در هر محدوده کار می‌کند؛ شمارش‌ها نشان‌دهنده تعداد کانتینرها هستند، نه مجموع اعمال. محدودهٔ قاب‑متن لینک‌های خود شکل حاکم را نادیده می‌گیرد.

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

در این مثال، پرس‌وجوهای ارائه و اسلاید هر کدام سه کانتینر کلیک، دو کانتینر ماوس‑اور و سه کانتینر با هر یک از این اعمال را گزارش می‌دهند. پرس‌وجوی قاب‑متن یک کانتینر در هر دسته را گزارش می‌کند.

### **دسته‌بندی اعمال و مقصدها**

از متد [IHyperlink.getActionType](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getActionType--) برای تفسیر یک عمل قبل از تفسیر مقصد آن استفاده کنید. مقادیر [HyperlinkActionType](https://reference.aspose.com/slides/java/com.aspose.slides/hyperlinkactiontype/) بیش از ناوبری وب را شامل می‌شوند:

| مقادیر | معنی برای بررسی |
| --- | --- |
| `Hyperlink` | ابرپیوند خارجی؛ URL و طرح‌گر آن را بررسی کنید. |
| `JumpSpecificSlide` | ناوبری داخلی به اسلاید خاصی. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | ناوبری پیش‌ساخته اسلایدشو، در زمینه اسلایدشو حل می‌شود. |
| `JumpEndShow`, `StartCustomSlideShow` | پایان نمایش جاری یا شروع یک نمایش سفارشی. |
| `StartMacro` | اجرای یک ماکرو. |
| `StartProgram` | راه‌اندازی یک برنامه. |
| `OpenFile`, `OpenPresentation` | باز کردن یک فایل یا ارائه دیگر؛ به‌صورت جداگانه از URLهای وب بررسی شود. |
| `StartStopMedia` | شروع یا توقف پخش رسانه. |
| `NoAction`, `Unknown` | بدون عمل ناوبری، یا عملی ناشناخته که نیاز به بررسی دارد. |

مقاصد خارجی را از طریق متد [getExternalUrl](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrl--) و مقاصد داخلی خاص را از طریق متد [getTargetSlide](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getTargetSlide--) بخوانید. اعمال داخلی و دستورات پیش‌ساخته ممکن است URL خارجی نداشته باشند؛ یک URL خالی به این معنا نیست که کانتینر عمل ندارد. مقدار بازگردانده‌شده توسط [getExternalUrlOriginal](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) را در صورتی که با URL نرمال شده متفاوت باشد حفظ کنید و راهنمای (tooltip) بازگردانده‌شده توسط [getTooltip](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getTooltip--) را در صورت موجود بودن شامل کنید.

### **گزارش، تصفیه و تأیید ابرپیوندها**

مثال زیر جاوا یک ارائه موجود را می‌خواند (از فایلی که در بالا ایجاد شد استفاده کنید)، `hyperlink-audit.json` را می‌نویسد، سیاستی را اعمال می‌کند، `hyperlink-sanitized.pptx` را ذخیره می‌نماید و دوباره باز می‌کند تا هر دو نوع فعال‌سازی را مجدداً بررسی کند. قبل از تغییر، کانتینرها را جمع‌آوری کرده و با استفاده از برابری مراجع از پردازش دو بار همان کانتینر جلوگیری می‌کند. پرس‌وجوهای ارائه اسلایدهای عادی را پوشش می‌دهند؛ برای موجودی در سطح بسته، مسترها، طرح‌ها، یادداشت‌ها و مسترهای یادداشت و برگه‌اطلاعات را نیز به‌صورت صریح پرس و جو می‌کند.

گزارش یک ایندکس اسلاید مبتنی بر یک (یک‌مبتنی) و [getSlideId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideId--) را در صورت موجود بودن ثبت می‌کند. متد [ISlideComponent.getSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islidecomponent/#getSlide--) اسلاید مالک را برای کانتینرهای پشتیبانی‌شده فراهم می‌کند. مسترها، طرح‌ها و یادداشت‌ها ایندکس اسلاید عادی ندارند و با محدودهٔ خود شناسایی می‌شوند. کانتینرهای شکل و کانتینرهای قالب‌بندی بخش متن به‌طور جداگانه برچسب‌گذاری می‌شوند؛ سایر انواع کانتینر نام نوع زمان اجرا را حفظ می‌کنند. هر کانتینر یک شناسه محلی در گزارش دریافت می‌کند تا دو عمل آن مرتبط شوند. گزارش انواع اعمال را به‌عنوان ثابت‌های عددی تعریف‌شده توسط شمارندهٔ جاوا ذخیره می‌کند.

این سیاست کاربردی عمدتاً محدود، فقط URLهای HTTPS مطلق و اهداف داخلی اسلاید معتبر را می‌پذیرد. ماکروها، برنامه‌ها، اعمال فایل، سایر اعمال اسلایدشو، اعمال ناشناخته و سایر طرح‌بندهای URL را رد می‌کند. این ردها تصمیمات سیاستی هستند، نه حکم ایمنی Aspose.Slides. HTTPS به تنهایی اعتماد را تضمین نمی‌کند: لیست‌های سفید میزبان و سایر بررسی‌ها را برای برنامه خود اضافه کنید. هم URLهای خارجی اصلی و هم نرمال‌شده بررسی می‌شوند. مثال متادیتا را بدون دنبال کردن لینک‌ها یا اجرای اعمال بررسی می‌کند.

برای اصلاح، [getHyperlinkManager](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) کانتینر از متدهای [setExternalHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) و [removeHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) پشتیبانی می‌کند. در اینجا، لینک‌های کلیک خارجی ممنوع با یک صفحه فرود ثابت HTTPS جایگزین می‌شوند؛ کلیک‌ها و اقدامات ماوس‑اور ممنوع دیگر به‌صورت مستقل حذف می‌شوند. برای حذف تمام تخلفات سیاست، مقدار `replaceExternalClicks` را به `false` تنظیم کنید. یک صفحه جایگزین متعلق به برنامه را پیش از استقرار انتخاب کنید.

پرچم صادرات گزارش از یک سیاست بازبینی PDF محتاطانه استفاده می‌کند: اقدامات ماوس‑اور و هر چیزی به‌جز لینک خارجی یا پرش اسلاید خاص به‌عنوان احتمالی عدم پشتیبانی علامت‌گذاری می‌شود. این یک نکته بازبینی است، نه آزمون قابلیت یا تضمین این‌که لینک‌های بدون پرچم پس از صادرات باقی می‌مانند. صادرات‌های پشتیبانی‌شدهٔ [PDF](/slides/fa/java/convert-powerpoint-to-pdf/) و [HTML](/slides/fa/java/convert-powerpoint-to-html/) ممکن است ابرپیوندها را حفظ کنند، بسته به عمل، گزینه‌های صادرات و نمایشگر. [تصاویر](/slides/fa/java/convert-powerpoint-to-png/) و [ویدئو](/slides/fa/java/convert-powerpoint-to-video/) رستری نمی‌توانند ابرپیوندهای تعاملی را حفظ کنند؛ هنگام حسابرسی برای این خروجی‌ها هر عمل را علامت‌گذاری کنید.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;
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

    // سریال‌سازی ردیف‌های مسطح این گزارش بدون وابستگی JSON اضافی.
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
            objects.add("  {\n" + String.join(",\n", fields) + "\n  }");
        }
        return "[\n" + String.join(",\n", objects) + "\n]\n";
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
    Files.write(Paths.get("hyperlink-audit.json"), jsonData);

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

با ورودی ایجاد‌شده در بالا، گزارش حاوی پنج ردیف عمل است. لینک ماوس‑اور فایل و کلیک ماکرو حذف می‌شوند، در حالی که لینک‌های HTTPS و ناوبری داخلی اسلاید باقی می‌مانند. تأیید صفر عمل ممنوع چاپ می‌کند. ورودی حاوی یک URL کلیک خارجی ممنوع نیز شاخهٔ جایگزینی را اجرا می‌کند. یک کانتینر با کلیک مجاز و ماوس‑اور ممنوع عمل کلیک خود را حفظ می‌کند.

این پاک‌سازی انتخابی با [removeAllHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) تفاوت دارد، که هر دو نوع فعال‌سازی را در تمام محدودهٔ انتخاب‌شده بدون توجه به سیاست حذف می‌کند. تأیید در اینجا فقط اعمال ابرپیوندها را بررسی می‌کند؛ پروژه‌های VBA جاسازی‌شده، اشیای OLE یا سایر محتویات فعال را حذف نمی‌کند و فایل PDF یا HTML صادرشده را اعتبارسنجی نمی‌کند.

## **سؤالات متداول**

**چگونه می‌توانم به یک بخش یا اولین اسلاید آن لینک کنم؟**

بخش‌ها در PowerPoint اسلایدها را گروه‌بندی می‌کنند، اما یک ابرپیوند داخلی هدفش یک اسلاید منفرد است. برای ایجاد ناوبری به یک بخش، به اولین اسلاید آن بخش لینک کنید.

**آیا می‌توانم ابرپیوندی را به عناصر اسلاید مستر الصاق کنم تا در تمام اسلایدها کار کند؟**

بله. عناصر اسلاید مستر و طرح از ابرپیوندها پشتیبانی می‌کنند. لینک‌های روی این عناصر در حین نمایش اسلاید در اسلایدهایی که از مستر یا طرح مربوطه استفاده می‌کنند، در دسترس هستند.

**آیا ابرپیوندها هنگام صادرات به PDF، HTML، تصاویر یا ویدئو حفظ می‌شوند؟**

صادرات‌های PDF و HTML پشتیبانی‌شده ممکن است ابرپیوندها را حفظ کنند؛ تصاویر رستری و ویدئو نمی‌توانند. به ملاحظات صادرات در [گزارش، تصفیه و تأیید ابرپیوندها](#report-sanitize-and-verify-hyperlinks) مراجعه کنید.