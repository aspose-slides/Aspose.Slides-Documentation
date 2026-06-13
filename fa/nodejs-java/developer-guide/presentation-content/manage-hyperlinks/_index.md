---
title: مدیریت ابرلینک‌های ارائه در JavaScript
linktitle: مدیریت ابرلینک
type: docs
weight: 20
url: /fa/nodejs-java/manage-hyperlinks/
keywords:
- افزودن URL
- افزودن ابرلینک
- ایجاد ابرلینک
- قالب‌بندی ابرلینک
- حذف ابرلینک
- به‌روزرسانی ابرلینک
- ابرلینک متن
- ابرلینک اسلاید
- ابرلینک شکل
- ابرلینک تصویر
- ابرلینک ویدیو
- ابرلینک قابل تغییر
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "به‌راحتی ابرلینک‌ها را در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای Node.js مدیریت کنید—تعامل و جریان کار را در دقیقه‌ها بهبود دهید."
---
## **مقدمه**

یک ابرلینک مرجعی به یک شیء یا داده یا مکانی در یک چیز است. اینها ابرلینک‌های رایج در ارائه‌های PowerPoint هستند:

* لینک‌ها به وب‌سایت‌ها داخل متن‌ها، شکل‌ها یا رسانه‌ها
* لینک‌ها به اسلایدها

Aspose.Slides برای Node.js از طریق Java به شما امکان انجام بسیاری از وظایف مرتبط با ابرلینک‌ها در ارائه‌ها را می‌دهد.

{{% alert color="primary" %}} 
ممکن است بخواهید Aspose ساده، [ویرایشگر آنلاین رایگان PowerPoint.](https://products.aspose.app/slides/fa/editor) را بررسی کنید.
{{% /alert %}} 

## **افزودن ابرلینک‌های URL**

### **افزودن ابرلینک‌های URL به متن‌ها**

این کد JavaScript نشان می‌دهد که چگونه یک ابرلینک وب‌سایت را به یک متن اضافه کنید:
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape1 = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    shape1.addTextFrame("Aspose: File Format APIs");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    portionFormat.setFontHeight(32);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

### **افزودن ابرلینک‌های URL به شکل‌ها یا فریم‌ها**

این کد نمونه در JavaScript نشان می‌دهد که چگونه یک ابرلینک وب‌سایت را به یک شکل اضافه کنید:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50);
    shape.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **افزودن ابرلینک‌های URL به رسانه‌ها**

Aspose.Slides به شما امکان افزودن ابرلینک به تصاویر، فایل‌های صوتی و ویدئویی را می‌دهد.

این کد نمونه نشان می‌دهد که چگونه یک ابرلینک به یک **تصویر** اضافه کنید:
```javascript
var pres = new aspose.slides.Presentation();
try {
    // تصویر را به ارائه اضافه می‌کند
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(picture);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // قاب تصویر را در اسلاید 1 بر اساس تصویر اضافه‌شده پیشین ایجاد می‌کند
    var pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pictureFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

این کد نمونه نشان می‌دهد که چگونه یک ابرلینک به یک **فایل صوتی** اضافه کنید:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var audio = pres.getAudios().addAudio(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "audio.mp3")));
    var audioFrame = pres.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio);
    audioFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    audioFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

این کد نمونه نشان می‌دهد که چگونه یک ابرلینک به یک **ویدئو** اضافه کنید:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var video = pres.getVideos().addVideo(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "video.avi")));
    var videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);
    videoFrame.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    videoFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert  title="Tip"  color="primary"  %}} 
ممکن است بخواهید *[مدیریت OLE](/slides/fa/nodejs-java/manage-ole/)* را ببینید.
{{% /alert %}}

## **استفاده از ابرلینک‌ها برای ایجاد فهرست مطالب**

از آنجا که ابرلینک‌ها به شما امکان افزودن ارجاع به اشیا یا مکان‌ها را می‌دهند، می‌توانید از آنها برای ایجاد فهرست مطالب استفاده کنید.

این کد نمونه نشان می‌دهد که چگونه یک فهرست مطالب با ابرلینک‌ها ایجاد کنید:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var firstSlide = pres.getSlides().get_Item(0);
    var secondSlide = pres.getSlides().addEmptySlide(firstSlide.getLayoutSlide());
    var contentTable = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 100);
    contentTable.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    contentTable.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    contentTable.getTextFrame().getParagraphs().clear();
    var paragraph = new aspose.slides.Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    paragraph.setText("Title of slide 2 .......... ");
    var linkPortion = new aspose.slides.Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);
    paragraph.getPortions().add(linkPortion);
    contentTable.getTextFrame().getParagraphs().add(paragraph);
    pres.save("link_to_slide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **قالب‌بندی ابرلینک‌ها**

### **رنگ**

با استفاده از متد [setColorSource](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Hyperlink#setColorSource-int-) در کلاس [Hyperlink](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Hyperlink)، می‌توانید رنگ ابرلینک‌ها را تنظیم کنید و همچنین اطلاعات رنگ را از ابرلینک‌ها دریافت کنید. این قابلیت اولین بار در PowerPoint 2019 معرفی شد، بنابراین تغییرات مربوط به این ویژگی در نسخه‌های قدیمی‌تر PowerPoint اعمال نمی‌شود.

این کد نمونه عملی را نشان می‌دهد که در آن ابرلینک‌های با رنگ‌های مختلف به همان اسلاید اضافه شده‌اند:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 450, 50, false);
    shape1.addTextFrame("This is a sample of colored hyperlink.");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setColorSource(aspose.slides.HyperlinkColorSource.PortionFormat);
    portionFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portionFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    var shape2 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 450, 50, false);
    shape2.addTextFrame("This is a sample of usual hyperlink.");
    shape2.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    pres.save("presentation-out-hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **حذف ابرلینک‌ها در ارائه‌ها**

### **حذف ابرلینک‌ها از متن‌ها**

این کد JavaScript نشان می‌دهد که چگونه ابرلینک را از یک متن در اسلاید ارائه حذف کنید:
```javascript
var pres = new aspose.slides.Presentation("text.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let slide = pres.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            // بررسی می‌کند که شکل از فریم متن (IAutoShape) پشتیبانی می‌کند.
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                var autoShape = shape;
                // از پاراگراف‌های فریم متن عبور می‌کند
                for (let i1 = 0; i1 < autoShape.getTextFrame().getParagraphs().getCount(); i1++) {
                    let paragraph = autoShape.getTextFrame().getParagraphs().get_Item(i1);
                    // از هر بخش در پاراگراف عبور می‌کند
                    for (let j1 = 0; j1 < paragraph.getPortions().getCount(); j1++) {
                        let portion = paragraph.getPortions().get_Item(j1)
                        portion.setText(portion.getText().replace("years", "months"));// متن را تغییر می‌دهد
                        portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));// قالب‌بندی را تغییر می‌دهد
                    }
                }
            }
        }
    }
    // ارائهٔ تغییر یافته را ذخیره می‌کند
    pres.save("text-changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **حذف ابرلینک‌ها از شکل‌ها یا فریم‌ها**

این کد JavaScript نشان می‌دهد که چگونه ابرلینک را از یک شکل در اسلاید ارائه حذف کنید:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        shape.getHyperlinkManager().removeHyperlinkClick();
    }
    pres.save("pres-removed-hyperlinks.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ابرلینک قابل تغییر**

کلاس [Hyperlink](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Hyperlink) قابل تغییر است. با استفاده از این کلاس می‌توانید مقادیر این ویژگی‌ها را تغییر دهید:

- [Hyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Hyperlink#setTargetFrame-java.lang.String-)
- [Hyperlink.setTooltip(String value)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Hyperlink#setTooltip-java.lang.String-)
- [Hyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Hyperlink#setHistory-boolean-)
- [Hyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Hyperlink#setHighlightClick-boolean-)
- [Hyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick-boolean-)

این بخش کد نشان می‌دهد که چگونه یک ابرلینک به یک اسلاید اضافه کنید و سپس tooltip آن را ویرایش کنید:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    shape1.addTextFrame("Aspose: File Format APIs");
    var portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
    portionFormat.setFontHeight(32);
    pres.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ویژگی‌های پشتیبانی‌شده در IHyperlinkQueries**

می‌توانید به [HyperlinkQueries](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/HyperlinkQueries) از یک ارائه، اسلاید یا متنی که ابرلینک برای آن تعریف شده است، دسترسی پیدا کنید.

- [Presentation.getHyperlinkQueries()](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries--)
- [BaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries--)
- [TextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries--)

کلاس [HyperlinkQueries](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/HyperlinkQueries) این متدها و ویژگی‌ها را پشتیبانی می‌کند:

- [HyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks--)
- [HyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers--)
- [HyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks--)
- [HyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks--)

## **سوالات متداول**

**چگونه می‌توانم ناوبری داخلی نه فقط به یک اسلاید، بلکه به یک «بخش» یا اولین اسلاید یک بخش ایجاد کنم؟**

بخش‌ها در PowerPoint گروهی از اسلایدها هستند؛ ناوبری به‌طور فنی به یک اسلاید خاص ارجاع می‌دهد. برای «ناوبری به یک بخش»، معمولاً به اولین اسلاید آن بخش لینک می‌کنید.

**آیا می‌توانم یک ابرلینک را به عناصر اسلاید اصلی (master) وصل کنم تا در تمام اسلایدها کار کند؟**

بله. عناصر اسلاید اصلی و طرح‌بندی از ابرلینک پشتیبانی می‌کنند. این لینک‌ها در اسلایدهای فرعی ظاهر می‌شوند و در حین نمایش اسلاید قابل کلیک هستند.

**آیا ابرلینک‌ها هنگام خروجی به PDF، HTML، تصاویر یا ویدئو حفظ می‌شوند؟**

در [PDF](/slides/fa/nodejs-java/convert-powerpoint-to-pdf/) و [HTML](/slides/fa/nodejs-java/convert-powerpoint-to-html/) بله — لینک‌ها عموماً حفظ می‌شوند. هنگام خروجی به [تصاویر](/slides/fa/nodejs-java/convert-powerpoint-to-png/) و [ویدئو](/slides/fa/nodejs-java/convert-powerpoint-to-video/)، قابلیت کلیک کردن منتقل نخواهد شد زیرا این فرمت‌ها (فریم‌های رستری/ویدئو) از ابرلینک پشتیبانی نمی‌کنند.