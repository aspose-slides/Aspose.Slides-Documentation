---
title: مدیریت هایپرلینک‌های ارائه در جاوا
linktitle: مدیریت هایپرلینک‌ها
type: docs
weight: 20
url: /fa/java/manage-hyperlinks/
keywords:
- افزودن URL
- افزودن هایپرلینک
- ایجاد هایپرلینک
- قالب‌بندی هایپرلینک
- حذف هایپرلینک
- به‌روزرسانی هایپرلینک
- هایپرلینک متن
- هایپرلینک اسلاید
- هایپرلینک شکل
- هایپرلینک تصویر
- هایپرلینک ویدئو
- هایپرلینک قابل تغییر
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "افزودن، قالب‌بندی، به‌روزرسانی و حذف هایپرلینک‌ها در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای جاوا، با استفاده از مثال‌های جاوا."
---
## **معرفی**

یک پیوند اینترنتی محتویات ارائه را به یک وب‌سایت یا موقعیتی درون ارائه متصل می‌کند. در پاورپوینت، هایپرلینک‌ها معمولاً دو هدف دارند:

* باز کردن یک وب‌سایت از متن، یک شکل یا یک قاب رسانه‌ای.
* جابجایی به اسلاید دیگری، برای مثال از فهرست مطالب.

Aspose.Slides for Java به شما امکان می‌دهد این پیوندها را اضافه کنید، ظاهر و صدای آنها را کنترل کنید، ویژگی‌هایشان را به‌روز کنید و حذف کنید. مثال‌های زیر نشان می‌دهند چگونه با هایپرلینک‌ها روی عناصر جداگانه کار کنید و چگونه به هایپرلینک‌ها در سطح ارائه، اسلاید یا قاب متن دسترسی پیدا کنید.

{{% alert color="info" title="Note" %}}
شما می‌توانید ارائه‌ها را با [free online Aspose PowerPoint editor](https://products.aspose.app/slides/fa/editor) ویرایش کنید.
{{% /alert %}} 

## **افزودن پیوندهای URL**

می‌توانید یک URL وب‌سایت را به متن، یک شکل یا یک قاب رسانه‌ای اختصاص دهید. عنصری که پیوند را به آن اختصاص می‌دهید، ناحیه قابل کلیک را تعیین می‌کند: بخشی از متن تنها متن انتخاب‌شده را لینک می‌کند، در حالی که یک شکل یا قاب کل شی اسلاید را لینک می‌کند.

### **افزودن پیوندهای URL به متن**

برای اتصال متن به یک وب‌سایت، یک [Hyperlink](https://reference.aspose.com/slides/fa/java/com.aspose.slides/hyperlink/) را به متد [setHyperlinkClick](https://reference.aspose.com/slides/fa/java/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) بخشی از متن پاس دهید، همان‌طور که در زیر نشان داده شده است. تنها همان بخش متن قابل کلیک می‌شود.

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

### **افزودن پیوندهای URL به اشکال و قاب‌های رسانه‌ای**

برای قابل کلیک کردن یک شکل یا قاب، متد [setHyperlinkClick](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) آن را فراخوانی کنید. پیوند به خود شی تعلق دارد نه به بخشی از متن داخل آن.

همین روش برای قاب‌های تصویر، صدا و ویدیو اعمال می‌شود: پیوند را به قاب اختصاص دهید و در صورت نیاز متد [setTooltip](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) را فراخوانی کنید.

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

## **استفاده از هایپرلینک‌ها برای ایجاد فهرست مطالب**

هایپرلینک‌های داخلی به خوانندگان امکان می‌دهند از فهرست مطالب به اسلاید خاصی بپرند. مثال زیر از متد [setInternalHyperlinkClick](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) برای لینک کردن متن «Page 2» در اسلاید اول به اسلاید دوم استفاده می‌کند.

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

## **قالب‌بندی هایپرلینک‌ها**

### **رنگ**

متد [setColorSource](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihyperlink/#setColorSource-int-) از رابط [IHyperlink](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihyperlink/) تعیین می‌کند که آیا یک هایپرلینک از رنگ هایپرلینک ارائه یا از قالب‌بندی بخش متن استفاده کند. برای اعمال رنگ متن سفارشی، [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/hyperlinkcolorsource/) را انتخاب کرده و رنگ پر شدن بخش را تنظیم کنید. این ویژگی در PowerPoint 2019 معرفی شد؛ نسخه‌های قدیمی‌تر این تنظیم را اعمال نمی‌کنند.

مثال زیر دو هایپرلینک متنی را به همان اسلاید اضافه می‌کند. اولین آن با پر شدن متن قرمز است، در حالی که دومین از رنگ پیش‌فرض هایپرلینک استفاده می‌کند.

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

یک هایپرلینک می‌تواند هنگام فعال شدن صدا پخش کند یا صدایی که قبلاً پخش می‌شود متوقف کند. از متدهای زیر برای پیکربندی این رفتارها استفاده کنید:

- [IHyperlink.setSound](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) صدای مرتبط با هایپرلینک را مشخص می‌کند.
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) کنترل می‌کند که آیا فعال‌سازی هایپرلینک صدا را متوقف می‌کند یا نه.

#### **افزودن صدای هایپرلینک**

مثال زیر فایل `sampleaudio.wav` را بارگذاری کرده و به دکمه‌ای در اسلاید اول پیوند می‌دهد. کلیک بر دکمه صدا را پخش می‌کند و به اسلاید بعدی می‌برد. یک شکل دوم در همان اسلاید هنگام کلیک صدای قبلی را متوقف می‌کند، بدون انجام هیچ عمل ناوبری.

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

#### **استخراج صدای هایپرلینک**

مثال زیر ارائه‌ای که در بالا ایجاد شد را باز می‌کند و صداى هایپرلینک اولین شکل را از طریق متدهای [getSound](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihyperlink/#getSound--) و [getBinaryData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iaudio/#getBinaryData--) به حافظه می‌خواند.

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

### **نکته‌ابری و تنظیمات تعامل**

پس از اختصاص یک هایپرلینک به متن یا شکل می‌توانید متدهای زیر از رابط [IHyperlink](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihyperlink/) را فراخوانی کنید:

- [setTooltip](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) متنی را تنظیم می‌کند که نمایشگر می‌تواند به‌عنوان راهنمای پیوند نشان دهد.
- [setTargetFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) قاب هدف را درون یک فریم‌ست HTML والد، در صورت امکان، مشخص می‌کند.
- [setHistory](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihyperlink/#setHistory-boolean-) کنترل می‌کند که آیا فعال‌سازی پیوند مقصد آن را به فهرست پیوندهای بازدید شده اضافه می‌کند یا نه.
- [setHighlightClick](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) تعیین می‌کند که آیا هایپرلینک هنگام کلیک برجسته شود یا خیر.

## **حذف هایپرلینک‌ها از ارائه‌ها**

از متد [getAnyHyperlinks](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) برای جمع‌آوری مخازن هایپرلینک، از جمله پیوندهای بخش متن، قبل از تغییر آنها استفاده کنید. مثال زیر هر دو نوع فعال‌سازی را از اسلاید اول حذف می‌کند. برای حذف تنها یک نوع، فقط [removeHyperlinkClick](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) یا [removeHyperlinkMouseOver](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) را فراخوانی کنید؛ حذف عمل کلیک هم‌زمان عمل ماوس‌اور را حذف نمی‌کند.

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

برای حذف بدون شرط، متد [removeAllHyperlinks](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) هر دو نوع فعال‌سازی را در محدودهٔ انتخاب‌شده در یک فراخوانی حذف می‌کند. برای پاک‌سازی انتخابی و پوشش مسترها، لایه‌ها و یادداشت‌ها، به بخش [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) مراجعه کنید.

## **ساخت یک موجودی کامل از هایپرلینک‌ها**

قبل از توزیع یک ارائه، اقدامات تعاملی و لینک‌های وب آن را فهرست کنید. متد [getAnyHyperlinks](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) اشیای [IHyperlinkContainer](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihyperlinkcontainer/) را برمی‌گرداند، نه یک لیست ساده از رشته‌های URL. هر مخزن را با [getHyperlinkClick](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) و [getHyperlinkMouseOver](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) بررسی کنید. آنها مستقل هستند: یک مخزن می‌تواند هر دو عمل را دربرگیرد، بنابراین یک گزارش کامل ممکن است تا دو ردیف برای هر مخزن نیاز داشته باشد.

فقط جستجو در سطح شکل می‌تواند پیوندهای متصل به بخش‌های متن را از دست بدهد. به‌جای آن دامنهٔ مناسب را جستجو کنید و مخازن بازگردانده‌شده را نگه دارید تا بعدها بتوانید اعمال آنها را به‑روز یا حذف کنید.

### **پرس‌و‌جوی دامنه‌های ارائه، اسلاید و قاب متن**

رابط [IHyperlinkQueries](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihyperlinkqueries/) از طریق متدهای [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ipresentation/#getHyperlinkQueries--)، [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) و [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#getHyperlinkQueries--) در دسترس است. هر دامنه همان پرس‌و‌جوها را پشتیبانی می‌کند:

- [getHyperlinkClicks](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) مخازن حاوی عمل کلیک را برمی‌گرداند.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) مخازن حاوی عمل ماوس‌اور را برمی‌گرداند.
- [getAnyHyperlinks](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) مخازن حاوی یکی یا هر دو عمل را برمی‌گرداند.

مثال زیر فایلی به نام `hyperlink-audit-input.pptx` ایجاد می‌کند که شامل یک لینک کلیک خارجی، یک لینک ماوس‌اور فایل، ناوبری اسلاید داخلی، یک لینک ماوس‌اور متن و یک عمل ماکرو است. این مثال هیچ‌یک از این اعمال را اجرا نمی‌کند. همان سه پرس‌و‌جو در هر دامنه کار می‌کند؛ شمارش‌ها نشان‌دهندهٔ تعداد مخازن هستند، نه مجموع اعمال. دامنهٔ قاب متن لینک‌های خود شکل محاط‌کننده را شامل نمی‌شود.

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

در این مثال، پرس‌و‌جوهای ارائه و اسلاید هر کدام سه مخزن کلیک، دو مخزن ماوس‌اور و سه مخزن حاوی هر یک از این اعمال را گزارش می‌دهند. پرس‌و‌جوی قاب متن یک مخزن در هر دسته‌بندی گزارش می‌کند.

### **طبقه‌بندی اعمال و مقاصد**

از متد [IHyperlink.getActionType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihyperlink/#getActionType--) برای تفسیر یک عمل قبل از تفسیر مقصد آن استفاده کنید. مقدارهای [HyperlinkActionType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/hyperlinkactiontype/) بیش از ناوبری وب را پوشش می‌دهند:

| مقادیر | معنی برای یک ممیزی |
| --- | --- |
| `Hyperlink` | هایپرلینک خارجی؛ URL و طرح‌ esquema آن را بررسی کنید. |
| `JumpSpecificSlide` | ناوبری داخلی به اسلاید خاصی. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | ناوبری پیش‌فرض اسلایدشو، که در زمینهٔ اسلایدشو حل می‌شود. |
| `JumpEndShow`, `StartCustomSlideShow` | پایان نمایش جاری یا شروع یک نمایش سفارشی. |
| `StartMacro` | اجرای یک ماکرو. |
| `StartProgram` | راه‌اندازی یک برنامه. |
| `OpenFile`, `OpenPresentation` | باز کردن یک فایل یا ارائهٔ دیگر؛ جدا از URLهای وب بررسی کنید. |
| `StartStopMedia` | شروع یا توقف پخش رسانه. |
| `NoAction`, `Unknown` | بدون عمل ناوبری، یا عمل نامشخص که نیاز به بررسی دارد. |

مقاصد خارجی را از متد [getExternalUrl](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihyperlink/#getExternalUrl--) و مقاصد داخلی خاص را از متد [getTargetSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihyperlink/#getTargetSlide--) بخوانید. اعمال داخلی و دستورات داخلی ممکن است URL خارجی نداشته باشند؛ URL خالی به این معنا نیست که مخزن عمل ندارد. مقدار بازگردانده‌شده توسط [getExternalUrlOriginal](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) را زمانی که با URL نرمال‌شده متفاوت باشد، حفظ کنید و نکته‌ابری بازگردانده‌شده توسط [getTooltip](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihyperlink/#getTooltip--) را در صورت موجود بودن شامل کنید.

### **گزارش، پاک‌سازی و تأیید هایپرلینک‌ها**

مثال زیر به زبان Java یک ارائه موجود (فایل ایجادشده در بالا) را می‌خواند، `hyperlink-audit.json` می‌نویسد، یک سیاست را اعمال می‌کند، `hyperlink-sanitized.pptx` را ذخیره می‌کند و دوباره آن را باز می‌کند تا هر دو نوع فعال‌سازی را بررسی کند. قبل از تغییر، مخازن را جمع‌آوری می‌کند و برای جلوگیری از پردازش دوبارهٔ همان مخزن از برابری مراجع استفاده می‌کند. پرس‌و‌جوهای ارائه اسلایدهای معمولی را پوشش می‌دهند؛ برای یک موجودی سراسری بسته، به طور صریح مسترها، لایه‌ها، یادداشت‌ها و مسترهای یادداشت و توزیع را نیز پرس‌و‌جو می‌کند.

گزارش، اندیس اسلاید بر پایهٔ یک‌برگی و [getSlideId](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibaseslide/#getSlideId--) را (در صورت موجود بودن) ثبت می‌کند. [ISlideComponent.getSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/islidecomponent/#getSlide--) مخزن متعلق به اسلاید را برای مخازن پشتیبانی‌شده فراهم می‌آورد. مسترها، لایه‌ها و یادداشت‌ها اندیس اسلاید معمولی ندارند و بر پایهٔ دامنهٔ خود شناخته می‌شوند. مخازن شکل و مخازن قالب‌بندی بخش متن به‌صورت جداگانه برچسب‌گذاری می‌شوند؛ انواع دیگر مخازن نام نوع زمان اجرا خود را حفظ می‌کنند. هر مخزن یک شناسهٔ محلی در گزارش دریافت می‌کند تا دو عمل آن مرتبط شوند. گزارش انواع عمل را به عنوان ثابت‌های عددی تعریف‌شده توسط شمارش‌گر Java ذخیره می‌کند.

این سیاست کاربردی به‌صورت عمدی فقط URLهای HTTPS مطلق و هدف‌های اسلاید داخلی معتبر را می‌پذیرد. ماکروها، برنامه‌ها، اعمال فایل، سایر اعمال اسلایدشو، اعمال ناشناخته و سایر طرح‌های URL رد می‌شوند. این ردها تصمیمات سیاستی هستند، نه یک قضاوت امنیتی Aspose.Slides. فقط HTTPS اعتماد را تأمین نمی‌کند: لیست‌های سفید میزبان و سایر بررسی‌ها را برای برنامهٔ خود اضافه کنید. هر دو URL خارجی اصلی و نرمال‌شده بررسی می‌شود. مثال متادیتا را بدون دنبال‌کردن لینک‌ها یا اجرای اعمال ممیزی می‌کند.

برای رفع، مخزن با استفاده از [getHyperlinkManager](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) متدهای [setExternalHyperlinkClick](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-)، [removeHyperlinkClick](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) و [removeHyperlinkMouseOver](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) را پشتیبانی می‌کند. در اینجا، لینک‌های کلیک خارجی ممنوع با یک صفحهٔ فرود ثابت HTTPS جایگزین می‌شوند؛ سایر کلیک‌ها و اعمال ماوس‌اور ممنوع به‌صورت مستقل حذف می‌شوند. مقدار `replaceExternalClicks` را به `false` تنظیم کنید تا تمام نقض‌های سیاست حذف شوند. قبل از استقرار یک صفحهٔ جایگزین متعلق به برنامه انتخاب کنید.

پرچم خروجی گزارش از یک سیاست محافظه‌کارانهٔ بازبینی PDF استفاده می‌کند: اعمال ماوس‌اور و هر چیزی به‌جز لینک خارجی یا پرش اسلاید خاص به‌عنوان ممکناً پشتیبانی‌نشده پرچم‌گذاری می‌شود. این یک راهنمای بازبینی است، نه آزمون قابلیت یا ضمانت اینکه لینک‌های بدون پرچم در خروجی بقا خواهند یافت. خروجی‌های PDF و HTML پشتیبانی‌شده ممکن است بسته به عمل، گزینه‌های خروجی و نمایشگر، هایپرلینک‌ها را حفظ کنند. تصاویر رستر و ویدیو نمی‌توانند هایپرلینک‌های تعاملی را حفظ کنند؛ هنگام ممیزی برای این خروجی‌ها هر عمل را پرچم کنید.

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

    // سریال‌سازی ردیف‌های صاف این گزارش بدون وابستگی JSON اضافه.
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

با ورودی ایجادشده در بالا، گزارش شامل پنج ردیف عمل است. لینک ماوس‌اور فایل و کلیک ماکرو حذف می‌شوند، در حالی که لینک‌های HTTPS و ناوبری اسلاید داخلی باقی می‌مانند. تأیید صفر عمل ممنوع چاپ می‌کند. ورودی حاوی URL کلیک خارجی ممنوع نیز مسیر جایگزینی را اجرا می‌کند. یک مخزن با کلیک مجاز و ماوس‌اور ممنوع کلیک خود را حفظ می‌کند.

این پاک‌سازی انتخابی متفاوت از [removeAllHyperlinks](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) است که هر دو نوع فعال‌سازی را در تمام دامنهٔ انتخاب‌شده صرف‌نظر از سیاست حذف می‌کند. تأیید در اینجا تنها اعمال هایپرلینک را بررسی می‌کند؛ پروژه‌های VBA توکار، اشیای OLE یا سایر محتوای فعال را حذف نمی‌کند و فایل PDF یا HTML خروجی را اعتبارسنجی نمی‌کند.

## **سوالات متداول**

**چگونه می‌توانم به یک بخش یا اولین اسلاید آن لینک کنم؟**

بخش‌ها در پاورپوینت اسلایدها را گروه‌بندی می‌کنند، اما یک هایپرلینک داخلی به یک اسلاید منفرد هدف می‌گیرد. برای ایجاد ناوبری به یک بخش، به اولین اسلاید آن بخش لینک کنید.

**آیا می‌توانم یک هایپرلینک را به عناصر مستر اسلاید پیوست کنم تا در تمام اسلایدها کار کند؟**

بله. عناصر مستر اسلاید و لایه‌ها از هایپرلینک پشتیبانی می‌کنند. این لینک‌ها در حین پخش اسلاید در اسلایدهایی که از مستر یا لایه مربوطه استفاده می‌کنند، در دسترس هستند.

**آیا هایپرلینک‌ها هنگام خروجی به PDF، HTML، تصاویر یا ویدیو حفظ می‌شوند؟**

خروجی‌های PDF و HTML پشتیبانی‌شده ممکن است هایپرلینک‌ها را حفظ کنند؛ تصاویر رستر و ویدیو نمی‌توانند. برای جزئیات بیشتر به ملاحظات خروجی در بخش [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) مراجعه کنید.