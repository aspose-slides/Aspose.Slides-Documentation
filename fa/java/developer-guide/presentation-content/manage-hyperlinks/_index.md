---
title: مدیریت پیوندهای ابرمتن ارائه در جاوا
linktitle: مدیریت پیوندهای ابرمتن
type: docs
weight: 20
url: /fa/java/manage-hyperlinks/
keywords:
- افزودن URL
- افزودن پیوند ابرمتن
- ایجاد پیوند ابرمتن
- قالب‌بندی پیوند ابرمتن
- حذف پیوند ابرمتن
- به‌روزرسانی پیوند ابرمتن
- پیوند ابرمتن متن
- پیوند ابرمتن اسلاید
- پیوند ابرمتن شکل
- پیوند ابرمتن تصویر
- پیوند ابرمتن ویدئو
- پیوند ابرمتن قابل تغییر
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "افزودن، قالب‌بندی، به‌روزرسانی و حذف پیوندهای ابرمتن در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای Java، با استفاده از مثال‌های Java."
---
## **مقدمه**

یک پیوندهای ابرمتن محتواهای ارائه را به یک وب‌سایت یا موقعیتی درون ارائه متصل می‌کند. در PowerPoint، پیوندهای ابرمتن معمولاً دو هدف دارند:

* از متن، شکل یا قاب رسانه‌ای یک وب‌سایت را باز می‌کند.
* به اسلاید دیگری، برای مثال از فهرست مطالب، می‌رود.

Aspose.Slides for Java به شما امکان افزودن این پیوندها، کنترل ظاهر و صدا، به‌روزرسانی ویژگی‌ها و حذف آن‌ها را می‌دهد. مثال‌های زیر نشان می‌دهند چگونه با پیوندهای ابرمتن در عناصر جداگانه کار کنید و چگونه به پیوندهای ابرمتن در سطح ارائه، اسلاید یا قاب‑متن دسترسی پیدا کنید.

{{% alert color="info" title="Note" %}}

همچنین می‌توانید ارائه‌ها را با [ویرایشگر آنلاین رایگان Aspose PowerPoint](https://products.aspose.app/slides/editor) ویرایش کنید.

{{% /alert %}}

## **افزودن پیوندهای ابرمتن URL**

می‌توانید یک URL وب‌سایت را به متن، شکل یا قاب رسانه‌ای اختصاص دهید. عنصری که پیوند ابرمتن به آن اختصاص می‌دهید، ناحیه قابل کلیک را تعیین می‌کند: بخشی از متن فقط آن بخش انتخاب‌شده را لینک می‌کند، در حالی که یک شکل یا قاب کل شیء اسلاید را لینک می‌کند.

برای ارائه‌های حاوی پیوندهای ابرمتن نسبی، به بخش [Manage the Hyperlink Base](/slides/fa/java/presentation-properties/#manage-the-hyperlink-base) مراجعه کنید تا پایهٔ سند را بخوانید، تغییر دهید یا پاک کنید.

### **افزودن پیوندهای URL به متن**

برای لینک کردن متن به یک وب‌سایت، یک [Hyperlink](https://reference.aspose.com/slides/java/com.aspose.slides/hyperlink/) را به متد [setHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) قسمت متن پاس می‌دهید، همان‌طور که در زیر نشان داده شده است. فقط همان بخش متن قابل کلیک می‌شود.

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

### **افزودن پیوندهای URL به شکل‌ها و قاب‌های رسانه‌ای**

متد [setHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) را بر روی مستطیل صدا می‌زنید تا کل ناحیهٔ آن قابل کلیک شود. از [setTooltip](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) برای نشان دادن راهنمایی به خوانندگان درباره مقصد هنگام شناور کردن ماوس بر روی مستطیل استفاده کنید. هر دو متد برای قاب‌های عکس، صدا و ویدئو نیز اعمال می‌شوند.

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

## **استفاده از پیوندهای ابرمتن برای ایجاد فهرست مطالب**

پیوندهای ابرمتن داخلی به خوانندگان امکان می‌دهد از فهرست مطالب به اسلاید خاصی پرش کنند. مثال زیر از متد [setInternalHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) برای لینک کردن متن «Page 2» در اسلاید اول به اسلاید دوم استفاده می‌کند.

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

## **قالب‌بندی پیوندهای ابرمتن**

می‌توانید رنگ متن لینک‌دار را تغییر دهید، هنگام فعال‌سازی پیوند صدا پخش یا متوقف کنید، و ابزارک (tooltip) نمایش‌داده شده هنگام شناور کردن ماوس را تنظیم کنید.

### **رنگ**

متد [setColorSource](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setColorSource-int-) از [IHyperlink](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/) تعیین می‌کند که پیوند ابرمتن از رنگ پیوند ابرمتن ارائه یا قالب‌بندی بخش متن استفاده کند. برای اعمال رنگ متن سفارشی، [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/hyperlinkcolorsource/) را انتخاب کرده و رنگ پر شدن بخش را تنظیم کنید. این ویژگی در PowerPoint 2019 معرفی شد؛ نسخه‌های قدیمی‌تر این تنظیم را اعمال نمی‌کنند.

در این مثال، [setColorSource](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setColorSource-int-) اولین پیوند را طوری تنظیم می‌کند که از پر شدن قرمز بخش متن استفاده کند. دومین پیوند رنگ پیوند ابرمتن ارائه را حفظ می‌کند.

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

یک پیوند ابرمتن می‌تواند هنگام فعال شدن صدا پخش کند یا صدائی را که در حال پخش است متوقف نماید. برای تنظیم این رفتارها از متدهای زیر استفاده کنید:

- [IHyperlink.setSound](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) صدا مرتبط با پیوند ابرمتن را مشخص می‌کند.
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) کنترل می‌کند که آیا فعال‌سازی پیوند ابرمتن صدا را متوقف کند یا نه.

#### **افزودن صدا به پیوند ابرمتن**

دکمهٔ موجود در اسلاید اول از [IHyperlink.setSound](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) برای پخش صدا از `sampleaudio.wav` هنگام کلیک کاربر استفاده می‌کند. در اسلاید دوم، دکمهٔ جداگانه‌ای از [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) برای متوقف کردن پخش صدا و نگه داشتن کاربر روی همان اسلاید استفاده می‌کند.

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

#### **استخراج صدا از پیوند ابرمتن**

مثال زیر ارائه‌ای که در بالا ساخته شد را باز می‌کند و صداهای پیوند ابرمتن اولین شکل را از طریق [getSound](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getSound--) و [getBinaryData](https://reference.aspose.com/slides/java/com.aspose.slides/iaudio/#getBinaryData--) به حافظه می‌خواند.

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

### **Tooltip و تنظیمات تعاملی**

پس از اختصاص پیوند ابرمتن به متن یا شکل می‌توانید متدهای زیر از [IHyperlink](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/) را فراخوانی کنید:

- [setTooltip](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) متنی را که مشاهده‌کننده می‌تواند به عنوان راهنمایی برای لینک نمایش دهد، تنظیم می‌کند.
- [setTargetFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) چارچوب هدف را درون یک frameset HTML والد مشخص می‌کند، در صورت لزوم.
- [setHistory](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setHistory-boolean-) تعیین می‌کند که آیا فعال‌سازی لینک مقصد را به فهرست پیوندهای بازدیدشده اضافه کند یا نه.
- [setHighlightClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) کنترل می‌کند که آیا پیوند ابرمتن هنگام کلیک روشن می‌شود یا خیر.

## **حذف پیوندهای ابرمتن از ارائه‌ها**

از [getAnyHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) برای جمع‌آوری کانتینرهای پیوند ابرمتن، از جمله پیوندهای بخش‑متن، پیش از تغییر آن‌ها استفاده کنید. مثال زیر هر دو نوع فعال‌سازی را از اسلاید اول حذف می‌کند. برای حذف تنها یک نوع، فقط [removeHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) یا [removeHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) را فراخوانی کنید؛ حذف عمل کلیک، معادل حذف عمل شناور ماوس نیست.

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

برای حذف بدون قید، [removeAllHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) هر دو نوع فعال‌سازی را در محدودهٔ انتخاب‌شده در یک فراخوانی حذف می‌کند. برای پاک‌سازی انتخابی و پوشش مسترها، طرح‌بندی‌ها و یادداشت‌ها، به بخش [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) مراجعه کنید.

### **پاک‌سازی پیوندها پیش از جایگزینی متن SmartArt**

هنگام جایگزینی یک پاراگراف در گرهٔ SmartArt موجود، پاک‌سازی بخش‌های متنی می‌تواند پیوند ابرمتن قدیمی را باقی بگذارد. پاراگراف را از طریق [ISmartArtNode.getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#getTextFrame--) دریافت کنید. پیش از پاک‌سازی بخش‌ها، متد [getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getHyperlinkQueries--) را بر روی قاب‑متن شکل گره‌ای که پاراگراف را نمایش می‌دهد صدا بزنید، سپس [removeAllHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) را بر روی شیء بازگشتی فراخوانی کنید. این کار تمام پیوندهای موجود در آن قاب، از جمله پیوندهای پاراگراف‌های دیگر را حذف می‌کند.

این مثال فرض می‌کند که شکل سوم اسلاید اول فایل `SmartArtHyperlink.pptx` یک گرافیک SmartArt است. اولین پاراگراف گرهٔ چهارم را جایگزین می‌کند. در این ارائه، شکل اول گرهٔ مذکور آن پاراگراف را نمایش می‌دهد.

پس از افزودن هر دو بخش، مثال قالب‌بندی مؤثر آن‌ها را با [getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--) می‌خواند. روی آن قالب‌بندی، [getHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformateffectivedata/#getHyperlinkClick--) برای بخش اول پیوند جدید را بر می‌گرداند و برای بخش دوم `null` می‌گردد.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("SmartArtHyperlink.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = (ISmartArt) slide.getShapes().get_Item(2);
    ISmartArtNode node = smartArt.getAllNodes().get_Item(3);
    IParagraph paragraph = node.getTextFrame().getParagraphs().get_Item(0);

    node.getShapes().get_Item(0).getTextFrame().getHyperlinkQueries().removeAllHyperlinks();
    paragraph.getPortions().clear();

    IPortion link = new Portion("New reference");
    link.getPortionFormat().setHyperlinkClick(new Hyperlink("https://example.com/new"));
    paragraph.getPortions().add(link);
    IPortion text = new Portion(" (updated)");
    paragraph.getPortions().add(text);

    System.out.println(link.getPortionFormat().getEffective().getHyperlinkClick().getExternalUrl()); // https://example.com/new
    System.out.println(text.getPortionFormat().getEffective().getHyperlinkClick()); // null
} finally {
    presentation.dispose();
}
```

## **ساخت یک موجودی کامل از پیوندهای ابرمتن**

قبل از توزیع یک ارائه، اقدامات تعاملی و لینک‌های وب آن را موجودی کنید. [getAnyHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) شیءهای [IHyperlinkContainer](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/) را بر می‌گرداند، نه یک لیست صاف از رشته‌های URL. هم [getHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) و هم [getHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) را روی هر کانتینر بررسی کنید. آن‌ها مستقل‌اند: یک کانتینر می‌تواند هر دو عمل را فراهم کند، بنابراین یک گزارش کامل می‌تواند تا دو ردیف برای هر کانتینر نیاز داشته باشد.

فقط بررسی پیوندهای سطح شکل می‌تواند پیوندهای متصل به بخش‌های متن را از دست بدهد. به‌جای آن دامنهٔ مناسب را اعمال کنید و کانتینرهای بازگردانده‌شده را نگه دارید تا بعداً بتوانید عملکردهای آن‌ها را به‌روزرسانی یا حذف کنید.

### **پرس‌وجوی دامنه‌های ارائه، اسلاید و قاب‑متن**

رابط [IHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/) از طریق [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getHyperlinkQueries--)، [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) و [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getHyperlinkQueries--) در دسترس است. هر دامنه همان پرس‌وجوها را پشتیبانی می‌کند:

- [getHyperlinkClicks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) کانتینرهایی با عمل کلیک را بر می‌گرداند.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) کانتینرهایی با عمل شناور ماوس را بر می‌گرداند.
- [getAnyHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) کانتینرهایی که هر یک یا هر دو عمل را دارند، بر می‌گرداند.

این مثال عمل‌های کلیک و شناور ماوس را به یک شکل و متن آن اختصاص می‌دهد و یک عمل ماکرو را به دکمه‌ای جداگانه می‌افزاید. سپس تعداد کانتینرهای بازگردانده‌شده توسط [getAnyHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) را با شمارش هر نوع فعال‌سازی مقایسه می‌کند. یک پرس‌وجوی قاب‑متن فقط پیوندهای داخل متن را می‌شمارد. اعمال خود شکل در پرس‌وجوهای اسلاید و ارائه ظاهر می‌شود.

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

در این مثال، پرس‌وجوهای ارائه و اسلاید هر کدام سه کانتینر کلیک، دو کانتینر شناور و سه کانتینر با هر عمل را گزارش می‌کنند. پرس‌وجوی قاب‑متن هر دسته یک کانتینر گزارش می‌دهد.

### **دسته‌بندی اعمال و مقاصد**

از [IHyperlink.getActionType](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getActionType--) برای تفسیر یک عمل پیش از بررسی مقصد آن استفاده کنید. مقادیر [HyperlinkActionType](https://reference.aspose.com/slides/java/com.aspose.slides/hyperlinkactiontype/) بیش از ناوبری وب را پوشش می‌دهند:

| مقدار | معنی برای یک بررسی |
| --- | --- |
| `Hyperlink` | پیوند ابرمتن خارجی؛ URL و طرح آن را بررسی کنید. |
| `JumpSpecificSlide` | ناوبری داخلی به اسلاید خاصی. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | ناوبری داخلی اسلاید شو پیش‌ساخته، در زمینهٔ نمایش اسلاید تعیین می‌شود. |
| `JumpEndShow`, `StartCustomSlideShow` | پایان نمایش جاری یا شروع یک نمایش سفارشی. |
| `StartMacro` | اجرای ماکرو. |
| `StartProgram` | اجرای برنامه‌ای. |
| `OpenFile`, `OpenPresentation` | باز کردن فایل یا ارائهٔ دیگر؛ جداگانه از URLهای وب بررسی شوند. |
| `StartStopMedia` | شروع یا توقف پخش رسانه. |
| `NoAction`, `Unknown` | بدون عمل ناوبری یا عمل ناشناخته که نیاز به بررسی دارد. |

مقصدهای خارجی را از طریق [getExternalUrl](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrl--) و مقصدهای داخلی خاص را از [getTargetSlide](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getTargetSlide--) بخوانید. اعمال داخلی و دستورات پیش‌ساخته ممکن است URL خارجی نداشته باشند؛ یک URL خالی به این معنا نیست که کانتینر عمل ندارد. مقدار بازگردانده‌شده توسط [getExternalUrlOriginal](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) را هنگام تفاوت با URL نرمال‌شده حفظ کنید و tooltip برگردانده‌شده توسط [getTooltip](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlink/#getTooltip--) را در صورت موجود بودن شامل کنید.

### **گزارش، پاکسازی و تأیید پیوندهای ابرمتن**

این مثال ارائهٔ مثال قبلی را باز می‌کند و برای هر عمل یک رکورد JSON می‌نویسد. از [getAnyHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) برای جمع‌آوری کانتینرها در اسلایدهای معمولی، مسترها، طرح‌بندی‌ها و یادداشت‌ها (از جمله مسترهای یادداشت و توزیع) استفاده می‌کند. برای شمارش منحصر به‌فرد هر کانتینر از برابری ارجاع استفاده می‌کند، سیاست زیر را اعمال می‌نماید و سپس ارائهٔ ذخیره‌شده را مجدداً باز کرده تا هر دو عمل کلیک و شناور را بررسی کند.

گزارش، شاخص اسلاید (یک‌پایه) و [getSlideId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideId--) را در صورت موجود بودن ذخیره می‌کند. [ISlideComponent.getSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islidecomponent/#getSlide--) اسلاید مالک را برای کانتینرهای پشتیبانی‌شده فراهم می‌کند. مسترها، طرح‌بندی‌ها و یادداشت‌ها شاخص اسلاید معمولی ندارند و با دامنهٔ خودش‌ها شناخته می‌شوند. کانتینرهای شکل و قالب‌بندی بخش‑متن به طور جداگانه برچسب‌گذاری می‌شوند؛ سایر انواع کانتینر نام نوع زمان اجرا خود را حفظ می‌کنند. به هر کانتینر یک شناسهٔ محلی گزارش اختصاص داده می‌شود تا دو عمل آن قابل همبستگی باشد. نوع عمل به عنوان عدد ثابت تعریف‌شده در شمارش Java ذخیره می‌شود.

این سیاست کاربردی محدود‌کننده تنها URLهای HTTPS مطلق و هدف‌های اسلاید داخلی معتبر را می‌پذیرد. ماکروها، برنامه‌ها، اعمال فایلی، سایر اعمال اسلایدشو، اعمال ناشناخته و طرح‌های URL دیگر رد می‌شوند. این ردها تصمیمات سیاستی هستند، نه حکم امنیتی Aspose.Slides. فقط HTTPS به تنهایی اعتماد را تضمین نمی‌کند: فهرست‌های سفید میزبان و بررسی‌های دیگر را برای برنامهٔ خود اضافه کنید. هر دو URL خارجی اصلی و نرمال‌شده بررسی می‌شوند. مثال متادیتا را بدون دنبال کردن پیوندها یا اجرای اعمال ممیزی می‌کند.

برای اصلاح، [getHyperlinkManager](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) کانتینر، متدهای [setExternalHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-)، [removeHyperlinkClick](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) و [removeHyperlinkMouseOver](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) را پشتیبانی می‌کند. در اینجا، پیوندهای کلیک خارجی ممنوعه با یک صفحهٔ فرودی ثابت HTTPS جایگزین می‌شوند؛ سایر کلیک‌ها و اعمال ممنوعهٔ شناور به‌صورت مستقل حذف می‌شوند. مقدار `replaceExternalClicks` را به `false` تنظیم کنید تا تمام تخلفات سیاست حذف شوند. قبل از انتشار، صفحهٔ جایگزین متعلق به برنامهٔ شما را انتخاب کنید.

پرچم خروجی گزارش از یک سیاست بازبینی PDF محتاطانه استفاده می‌کند: اعمال شناور و هر چیزی غیر از یک پیوند خارجی یا پرش اسلاید خاص را به‌عنوان احتمالاً نامحوب علامت‌گذاری می‌کند. این یک نکتهٔ بررسی است، نه آزمون قابلیت یا ضمانتی که پیوندهای بدون پرچم در خروجی حفظ شوند. خروجی‌های PDF و HTML پشتیبانی‌شده ([PDF](/slides/fa/java/convert-powerpoint-to-pdf/) و [HTML](/slides/fa/java/convert-powerpoint-to-html/)) ممکن است پیوندها را بسته به عمل، گزینه‌های خروجی و نمایشگر حفظ کنند. تصاویر رستری ([images](/slides/fa/java/convert-powerpoint-to-png/)) و ویدئو ([video](/slides/fa/java/convert-powerpoint-to-video/)) نمی‌توانند پیوندهای تعاملی را حفظ کنند؛ هنگام ممیزی برای این خروجی‌ها هر عمل را پرچم بزنید.

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

    // این ردیف‌های صاف گزارش را بدون وابستگی JSON اضافی سریال‌سازی کنید.
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

با ورودی ایجاد‌شده در بالا، گزارش شامل پنج ردیف عمل است. لینک شناور فایل و کلیک ماکرو حذف می‌شوند، در حالی که لینک‌های HTTPS و ناوبری داخلی اسلاید باقی می‌مانند. تأیید صفر عمل ممنوعه چاپ می‌کند. ورودی حاوی URL کلیک خارجی ممنوعه نیز شاخهٔ جایگزینی را اجرا می‌کند. یک کانتینر با کلیک مجاز و شناور ممنوع عمل کلیک خود را حفظ می‌کند.

این پاک‌سازی انتخابی با [removeAllHyperlinks](https://reference.aspose.com/slides/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) که هر دو نوع فعال‌سازی را در کل دامنه منتخب صرف‌نظر از سیاست حذف می‌کند، متفاوت است. تأیید در اینجا تنها اعمال پیوندهای ابرمتن را بررسی می‌کند؛ محتویات VBA توکار، اشیای OLE یا سایر محتواهای فعال را حذف نمی‌کند و همچنین صحت فایل PDF یا HTML خروجی را ارزیابی نمی‌نماید.

## **سوالات متداول**

**چگونه می‌توانم به یک بخش یا اولین اسلاید آن لینک کنم؟**

بخش‌ها در PowerPoint اسلایدها را گروه‌بندی می‌کنند، اما یک پیوند ابرمتن داخلی به یک اسلاید فردی هدف می‌گیرد. برای ایجاد ناوبری به یک بخش، به اولین اسلاید آن بخش لینک کنید.

**آیا می‌توانم پیوند ابرمتن را به عناصر مستر اسلاید بچسبانم تا در تمام اسلایدها کار کند؟**

بله. عناصر مستر اسلاید و طرح‌بندی از پیوندهای ابرمتن پشتیبانی می‌کنند. لینک‌های این عناصر در حین نمایش اسلاید بر روی اسلایدهایی که از مستر یا طرح‌بندی مربوطه استفاده می‌کنند، در دسترس هستند.

**آیا پیوندهای ابرمتن هنگام خروجی به PDF، HTML، تصویر یا ویدئو حفظ می‌شوند؟**

خروجی‌های PDF و HTML پشتیبانی‌شده ممکن است پیوندها را حفظ کنند؛ تصاویر رستری و ویدئو نمی‌توانند پیوندهای تعاملی را نگه دارند. برای جزئیات بیشتر به بخش ملاحظات خروجی در [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) مراجعه کنید.