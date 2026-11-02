---
title: مدیریت لینک‌های ابر ارائه در Android
linktitle: مدیریت لینک‌های ابر
type: docs
weight: 20
url: /fa/androidjava/manage-hyperlinks/
keywords:
- افزون URL
- افزودن لینک‌ابری
- ایجاد لینک‌ابری
- قالب‌بندی لینک‌ابری
- حذف لینک‌ابری
- به‌روزرسانی لینک‌ابری
- لینک‌ابری متن
- لینک‌ابری اسلاید
- لینک‌ابری شکل
- لینک‌ابری تصویر
- لینک‌ابری ویدئو
- لینک‌ابری قابل تغییر
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "افزودن، قالب‌بندی، به‌روزرسانی و حذف لینک‌های ابر در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای Android از طریق Java، با استفاده از مثال‌های Java."
---
## **معرفی**

یک لینک‌ابری محتویات ارائه را به یک وب‌سایت یا یک مکان درون ارائه متصل می‌کند. در PowerPoint، لینک‌های ابر معمولاً دو هدف دارند:

* باز کردن یک وب‌سایت از متن، یک شکل یا یک قاب رسانه‌ای.
* رفتن به اسلاید دیگری، برای مثال از فهرست مطالب.

Aspose.Slides for Android via Java به شما امکان می‌دهد این لینک‌ها را اضافه کنید، ظاهر و صدا را کنترل کنید، خصوصیات آن‌ها را به‌روزرسانی کنید و حذف کنید. مثال‌های زیر نشان می‌دهند چگونه با لینک‌های ابر روی عناصر منفرد کار کنید و چگونه به لینک‌های ابر در سطح ارائه، اسلاید یا فریم متن دسترسی پیدا کنید.

{{% alert color="info" title="Note" %}}
شما همچنین می‌توانید ارائه‌ها را با [ویرایشگر رایگان آنلاین Aspose PowerPoint](https://products.aspose.app/slides/editor) ویرایش کنید.
{{% /alert %}} 

## **افزودن لینک‌های URL**

شما می‌توانید یک URL وب‌سایت را به متن، یک شکل یا یک قاب رسانه‌ای اختصاص دهید. عنصری که به آن لینک‌ابری اختصاص می‌دهید ناحیه کلیک‑پذیر را تعیین می‌کند: بخشی از متن فقط متن انتخاب‌شده را لینک می‌کند، در حالی که یک شکل یا قاب شیء اسلاید را لینک می‌کند.

برای ارائه‌هایی که شامل لینک‌های ابر نسبی هستند، به [Manage the Hyperlink Base](/slides/fa/androidjava/presentation-properties/#manage-the-hyperlink-base) مراجعه کنید تا پایهٔ سطح سند را بخوانید، تغییر دهید یا پاک کنید.

### **افزودن لینک‌های URL به متن**

برای لینک کردن متن به یک وب‌سایت، یک [Hyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/hyperlink/) را به متد [setHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) بخش متن پاس کنید، همان‌طور که در زیر نشان داده شده است. فقط آن بخش از متن کلیک‑پذیر می‌شود.

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

### **افزودن لینک‌های URL به اشکال و قاب‌های رسانه‌ای**

برای قابل کلیک کردن کردن یک شکل یا قاب، متد [setHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) آن را فراخوانی کنید. لینک‌ابری به خود شیء تعلق دارد نه به بخشی از متن داخل آن.

همین رویکرد برای قاب‌های تصویر، صوت و ویدئو اعمال می‌شود: لینک‌ابری را به قاب اختصاص دهید و در صورت نیاز متد [setTooltip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) را صدا بزنید.

مثال زیر یک rectangle را کلیک‑پذیر می‌سازد:

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

## **استفاده از لینک‌های ابر برای ایجاد فهرست مطالب**

لینک‌های ابر داخلی به خوانندگان امکان می‌دهد از فهرست مطالب به اسلاید خاصی پرش کنند. مثال زیر از متد [setInternalHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) برای لینک کردن متن «Page 2» در اسلاید اول به اسلاید دوم استفاده می‌کند.

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

## **قالب‌بندی لینک‌های ابر**

### **رنگ**

متد [setColorSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setColorSource-int-) از [IHyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/) تعیین می‌کند آیا یک لینک‌ابری از رنگ لینک‌ابری ارائه یا قالب‌بندی بخش متن استفاده کند. برای اعمال رنگ متن سفارشی، [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/hyperlinkcolorsource/) را انتخاب کنید و رنگ پر شدن بخش را تنظیم کنید. این ویژگی در PowerPoint 2019 معرفی شد؛ نسخه‌های قدیمی‌تر این تنظیم را اعمال نمی‌کنند.

مثال زیر دو لینک متنی را به همان اسلاید اضافه می‌کند. اولین لینک از پر رنگ قرمز استفاده می‌کند، در حالی که دومین لینک رنگ پیش‌فرض لینک‌ابری را حفظ می‌کند.

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

یک لینک‌ابری می‌تواند هنگام فعال شدن صدایی پخش کند یا صدای در حال پخش را متوقف کند. از متدهای زیر برای پیکربندی این رفتارها استفاده کنید:

- [IHyperlink.setSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) صدای مرتبط با لینک‌ابری را مشخص می‌کند.
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) کنترل می‌کند آیا فعال‌سازی لینک‌ابری صدای قبلی را متوقف می‌کند.

#### **افزودن صدای لینک‌ابری**

مثال زیر فایل `sampleaudio.wav` را بارگذاری کرده و آن را به یک دکمه در اسلاید اول اختصاص می‌دهد. کلیک بر دکمه صدا را پخش می‌کند و به اسلاید بعدی می‌روید. یک شکل دوم در همان اسلاید هنگام کلیک صدای قبلی را متوقف می‌کند، بدون انجام عملیات ناوبری.

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

#### **استخراج صدای لینک‌ابری**

مثال زیر ارائه‌ای را که در بالا ایجاد شد باز می‌کند و صدای لینک‌ابری اولین شکل را از طریق متدهای [getSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getSound--) و [getBinaryData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudio/#getBinaryData--) به حافظه می‌خواند.

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

### **Tooltip و تنظیمات تعامل**

پس از اختصاص یک لینک‌ابری به متن یا یک شکل می‌توانید متدهای زیر از [IHyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/) را فراخوانی کنید:

- [setTooltip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) متنی را تنظیم می‌کند که بیننده می‌تواند به‌عنوان راهنمای لینک نمایش دهد.
- [setTargetFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) فریم هدف را درون یک مجموعه فریم HTML والد (در صورت کاربرد) مشخص می‌کند.
- [setHistory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setHistory-boolean-) کنترل می‌کند آیا فعال‌سازی لینک مقصد را به فهرست لینک‌های مشاهده‌شده اضافه می‌کند یا نه.
- [setHighlightClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) تعیین می‌کند آیا هنگام کلیک لینک‌ابری برجسته می‌شود یا خیر.

## **حذف لینک‌های ابر از ارائه‌ها**

از [getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) برای جمع‌آوری مخازن لینک‌ابری، شامل لینک‌های بخش متن، قبل از تغییر آن‌ها استفاده کنید. مثال زیر هر دو نوع فعال‌سازی را از اسلاید اول حذف می‌کند. برای حذف تنها یک نوع، فقط [removeHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) یا [removeHyperlinkMouseOver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) را صدا بزنید؛ حذفعمل کلیک، معادل حذف عمل mouse‑over نیست.

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

برای حذف بدون قید، [removeAllHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) هر دو نوع فعال‌سازی را در بازهٔ انتخابی در یک فراخوانی حذف می‌کند. برای پاک‌سازی گزینشی و پوشش مسترها، چیدمان‌ها و یادداشت‌ها، به [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) مراجعه کنید.

## **ساخت یک موجودی کامل از لینک‌های ابر**

قبل از توزیع یک ارائه، اقدام‌های تعاملی و وب‌لینک‌های آن را فهرست کنید. [getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) اشیاء [IHyperlinkContainer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/) را برمی‌گرداند، نه یک فهرست صاف از رشته‌های URL. روی هر مخزن هم [getHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) و هم [getHyperlinkMouseOver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) را بررسی کنید. این دو مستقل هستند: یک مخزن می‌تواند هر دو عمل را اکسپوز کند، بنابراین یک گزارش کامل ممکن است تا دو ردیف برای هر مخزن نیاز داشته باشد.

اسکن کردن فقط لینک‌های سطح شکل ممکن است لینک‌های الصاق‌شده به بخش‌های متن را از دست بدهد. به جای آن محدودهٔ مناسب را پرس و جو کنید و مخازن بازگردانده‌شده را نگه دارید تا بعداً بتوانید عمل‌هایشان را به‌روزرسانی یا حذف کنید.

### **پرس و جو بازه‌های ارائه، اسلاید و فریم‑متن**

رابط [IHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/) از طریق [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getHyperlinkQueries--)، [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getHyperlinkQueries--) و [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getHyperlinkQueries--) در دسترس است. هر بازه همان پرس‌و‑جوها را پشتیبانی می‌کند:

- [getHyperlinkClicks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) مخازنی را برمی‌گرداند که عمل کلیک دارند.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) مخازنی را برمی‌گرداند که عمل mouse‑over دارند.
- [getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) مخازنی را برمی‌گرداند که یکی یا هر دو عمل را دارند.

مثال زیر فایلی به نام `hyperlink-audit-input.pptx` می‌سازد که شامل یک لینک کلیک خارجی، یک لینک mouse‑over فایل، ناوبری اسلاید داخلی، یک لینک mouse‑over متن و یک عمل ماکرو است. این مثال هیچ‌یک از این اعمال را اجرا نمی‌کند. هر سه پرس‌و‑جو در هر بازه کار می‌کند؛ شمارش‌ها مربوط به مخازن، نه مجموع اعمال، هستند. بازهٔ فریم‑متن لینک‌های شکل مجموعهٔ خود را شامل نمی‌شود.

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

در این مثال، پرس‌و‑جوهای ارائه و اسلاید هر کدام سه مخزن کلیک، دو مخزن mouse‑over و سه مخزن با هر یک از این اعمال را گزارش می‌دهند. پرس‌و‑جوی فریم‑متن یک مخزن در هر دسته گزارش می‌کند.

### **دسته‌بندی اعمال و مقصدها**

از [IHyperlink.getActionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getActionType--) برای تفسیر یک عمل قبل از تفسیر مقصد آن استفاده کنید. مقادیر [HyperlinkActionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/hyperlinkactiontype/) بیش از ناوبری وب را پوشش می‌دهند:

| Values | Meaning for an audit |
| --- | --- |
| `Hyperlink` | لینک‌ابری خارجی؛ URL و طرح آن را بررسی کنید. |
| `JumpSpecificSlide` | ناوبری داخلی به اسلاید خاص. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | ناوبری داخلی اسلایدشو پیش‌فرض، در زمینهٔ اسلایدشو حل می‌شود. |
| `JumpEndShow`, `StartCustomSlideShow` | پایان نمایش جاری یا شروع نمایش سفارشی. |
| `StartMacro` | اجرای ماکرو. |
| `StartProgram` | راه‌اندازی برنامه. |
| `OpenFile`, `OpenPresentation` | باز کردن فایل یا ارائه دیگر؛ جداگانه از URLهای وب بررسی شود. |
| `StartStopMedia` | شروع یا توقف پخش رسانه. |
| `NoAction`, `Unknown` | بدون عمل ناوبری، یا عمل ناشناخته که نیاز به بررسی دارد. |

مقاصد خارجی را از طریق [getExternalUrl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) و مقاصد داخلی خاص را از طریق [getTargetSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getTargetSlide--) بخوانید. اعمال داخلی و دستورات توکار ممکن است URL خارجی نداشته باشند؛ یک URL خالی به این معنا نیست که مخزن عمل ندارد. مقدار بازگردانده‌شده توسط [getExternalUrlOriginal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) را زمانی که متفاوت از URL نرمال‌شده است، حفظ کنید و tooltip بازگردانده‌شده توسط [getTooltip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getTooltip--) را در صورت موجود بودن شامل کنید.

### **گزارش، پاک‌سازی و تأیید لینک‌های ابر**

مثال زیر به زبان Java یک ارائه موجود (فایل ایجادشده در بالا) می‌خواند، `hyperlink-audit.json` می‌نویسد، سیاستی را اعمال می‌کند، `hyperlink-sanitized.pptx` را ذخیره می‌نماید و دوباره باز می‌کند تا هر دو نوع فعال‌سازی را دوباره بررسی کند. قبل از تغییر مخازن آن‌ها را جمع‌آوری می‌کند و برای جلوگیری از پردازش دوباره یک مخزن از برابری ارجاع استفاده می‌کند. پرس‌و‑جوهای ارائه اسلایدهای معمولی را پوشش می‌دهند؛ برای یک فهرست بستهٔ کلی، به صراحت مسترها، چیدمان‌ها، یادداشت‌ها و مسترهای یادداشت و توزیع‌کننده را نیز پرس‌و‑جو می‌کند.

گزارش، اندیس اسلاید (یک‌پایه) و [getSlideId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideId--) را در صورت موجود بودن ذخیره می‌کند. [ISlideComponent.getSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecomponent/#getSlide--) اسلاید مالک را برای مخازن پشتیبانی‌شده فراهم می‌کند. مسترها، چیدمان‌ها و یادداشت‌ها اندیس اسلاید معمولی ندارند و با بازهٔ خود شناسایی می‌شوند. مخازن شکل و مخازن قالب‌بندی بخش متن به‌صورت مجزا برچسب‌گذاری می‌شوند؛ سایر انواع مخازن نام نوع زمان اجرا را حفظ می‌کنند. هر مخزن یک شناسهٔ گزارش‑محلی می‌گیرد تا دو عمل آن همبسته شوند. گزارش نوع عمل‌ها را به‌صورت ثابت‌های عددی تعریف‌شده توسط enum جاوا ذخیره می‌کند.

این سیاست برنامه‌نویسی به‌صورت عمدی محدود کننده، تنها URLهای HTTPS قطعی و هدف‌های داخلی اسلاید معتبر را می‌پذیرد. ماکروها، برنامه‌ها، عمل‌های فایلی، سایر اعمال اسلایدشو، اعمال ناشناخته و سایر طرح‌های URL رد می‌شوند. این ردها تصمیمات سیاستی هستند، نه قضاوت امنیتی Aspose.Slides. تنها HTTPS اعتماد ایجاد نمی‌کند: لیست سفید میزبان‌ها و چک‌های دیگر برای برنامهٔ شما اضافه کنید. هر دو URL خارجی اصلی و نرمال‌شده بررسی می‌شوند. مثال متادیتا را بدون دنبال کردن لینک‌ها یا اجرای اعمال بررسی می‌کند.

برای رفع مشکل، [getHyperlinkManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) مخزن، متدهای [setExternalHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-)، [removeHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) و [removeHyperlinkMouseOver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--) را پشتیبانی می‌کند. در اینجا، لینک‌های کلیک خارجی ممنوع به یک صفحهٔ لندینگ HTTPS ثابت جایگزین می‌شوند؛ کلیک‌ها و mouse‑overهای ممنوع دیگر به‌صورت مستقل حذف می‌شوند. برای حذف تمام تخلفات سیاست، `replaceExternalClicks` را روی `false` تنظیم کنید. قبل از استقرار، یک صفحهٔ جایگزین متعلق به برنامهٔ خود انتخاب کنید.

پرچم خروجی گزارش از سیاست بازبینی PDF محتاطانه استفاده می‌کند: عمل‌های mouse‑over و هر چیز غیر از لینک خارجی یا پرش اسلاید خاص را به‌عنوان احتمالاً غیرقابل‌حمایت علامت‌گذاری می‌کند. این یک نکتهٔ بازبینی است، نه تست قابلیت یا تضمینی که لینک‌های بدون پرچم در خروجی بقا خواهند یافت. خروجی‌های PDF [PDF](/slides/fa/androidjava/convert-powerpoint-to-pdf/) و HTML [HTML](/slides/fa/androidjava/convert-powerpoint-to-html/) ممکن است بسته به عمل، گزینه‌های خروجی و نمایش‌گر لینک‌ها را حفظ کنند. تصاویر رستر [images](/slides/fa/androidjava/convert-powerpoint-to-png/) و ویدیو [video](/slides/fa/androidjava/convert-powerpoint-to-video/) نمی‌توانند لینک‌های تعاملی را حفظ کنند؛ برای این خروجی‌ها هنگام بازرسی هر عمل را پرچم بزنید.

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

    // سریال‌سازی سطرهای مسطح این گزارش بدون وابستگی اضافه به JSON.
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

با ورودی ایجادشده در بالا، گزارش شامل پنج ردیف عمل می‌شود. لینک mouse‑over فایل و کلیک ماکرو حذف می‌شوند، در حالی که لینک‌های HTTPS و ناوبری اسلاید داخلی باقی می‌مانند. تأیید صفر عمل ممنوع چاپ می‌کند. ورودی شامل یک URL کلیک خارجی ممنوع نیز شاخهٔ جایگزینی را اجرا می‌کند. مخزنی با کلیک مجاز و mouse‑over ممنوع، عمل کلیک خود را حفظ می‌کند.

این پاک‌سازی گزینشی با [removeAllHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) متفاوت است؛ که هر دو نوع فعال‌سازی را در تمام بازهٔ انتخابی صرف‌نظر از سیاست حذف می‌کند. تأیید در اینجا فقط اعمال لینک‌ابری را بررسی می‌کند؛ پروژه‌های VBA جاسازی‌شده، اشیای OLE یا سایر محتواهای فعال را حذف نمی‌کند و فایل‌های PDF یا HTML خروجی را اعتبارسنجی نمی‌کند.

## **سوالات متداول**

**چگونه می‌توانم به یک بخش یا اولین اسلاید آن لینک کنم؟**

بخش‌ها در PowerPoint اسلایدها را گروهبندی می‌کنند، اما یک لینک‌ابری داخلی به یک اسلاید منفرد هدف می‌گیرد. برای ایجاد ناوبری به یک بخش، به اولین اسلاید آن بخش لینک کنید.

**آیا می‌توانم یک لینک‌ابری را به عناصر اسلاید مستر پیوست کنم تا در تمام اسلایدها کار کند؟**

بله. عناصر اسلاید مستر و چیدمان از لینک‌ابری پشتیبانی می‌کنند. لینک‌های این عناصر در حین نمایش اسلایدها بر روی اسلایدهایی که از مستر یا چیدمان مربوطه استفاده می‌کنند، در دسترس هستند.

**آیا لینک‌ابرها هنگام خروجی به PDF، HTML، تصاویر یا ویدئو حفظ می‌شوند؟**

خروجی‌های PDF و HTML پشتیبانی‌شده ممکن است لینک‌ابرها را حفظ کنند؛ تصاویر رستر و ویدئو این امکان را ندارند. برای جزئیات به ملاحظات خروجی در [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) مراجعه کنید.