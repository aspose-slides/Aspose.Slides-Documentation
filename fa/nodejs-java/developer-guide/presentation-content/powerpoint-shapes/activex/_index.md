---
title: مدیریت کنترل‌های ActiveX در ارائه‌ها با استفاده از JavaScript
linktitle: ActiveX
type: docs
weight: 80
url: /fa/nodejs-java/activex/
keywords:
- ActiveX
- کنترل ActiveX
- مدیریت ActiveX
- افزودن ActiveX
- تغییر ActiveX
- پخش‌کننده رسانه
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "بیاموزید چگونه Aspose.Slides برای Node.js از طریق Java از ActiveX برای خودکارسازی و بهبود ارائه‌های PowerPoint استفاده می‌کند و به توسعه‌دهندگان کنترل قدرتمندی بر اسلایدها می‌دهد."
---
## **مقدمه**

کنترل‌های ActiveX در ارائه‌ها استفاده می‌شوند. Aspose.Slides برای Node.js از طریق Java به شما امکان افزودن و مدیریت کنترل‌های ActiveX را می‌دهد، اما نسبت به اشکال معمول ارائه کمی مدیریت دشوارتر هستند. ما پشتیبانی از افزودن کنترل فعال Media Player را در Aspose.Slides پیاده‌سازی کرده‌ایم. توجه داشته باشید که کنترل‌های ActiveX اشکال نیستند؛ آن‌ها بخشی از [ShapeCollection] ارائه نیستند. آن‌ها بخشی از [ControlCollection] جداگانه هستند. در این مقاله نحوه کار با آنها را به شما نشان می‌دهیم.

## **افزودن کنترل ActiveX Media Player به اسلاید**
برای افزودن کنترل ActiveX Media Player، این مراحل را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) ایجاد کنید و یک ارائه خالی تولید کنید.
2. به اسلاید هدف در [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) دسترسی پیدا کنید.
3. کنترل Media Player ActiveX را با استفاده از متد [addControl](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/ControlCollection#addControl-int-float-float-float-float-) که توسط [ControlCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/controlcollection/) ارائه شده است، اضافه کنید.
4. به کنترل Media Player ActiveX دسترسی پیدا کنید و مسیر ویدیو را با استفاده از ویژگی‌های آن تنظیم کنید.
5. ارائه را به عنوان فایل PPTX ذخیره کنید.

این کد نمونه، بر پایه مراحل فوق، نشان می‌دهد چگونه کنترل Media Player ActiveX را به یک اسلاید اضافه کنید:

```javascript
// ایجاد نمونه ارائهٔ خالی
var pres = new aspose.slides.Presentation();
try {
    // افزودن کنترل ActiveX Media Player
    pres.getSlides().get_Item(0).getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 100, 100, 400, 400);
    // دسترسی به کنترل ActiveX Media Player و تنظیم مسیر ویدیو
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("java.net.URL", "Wildlife.wmv");
    // ذخیرهٔ ارائه
    pres.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تغییر کنترل ActiveX**
برای مدیریت یک کنترل ساده ActiveX مانند یک جعبه متن و دکمه فرمان ساده در یک اسلاید، این مراحل را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation) ایجاد کنید و ارائه‌ای که شامل کنترل‌های ActiveX است را بارگذاری کنید.
2. یک مرجع اسلاید را بر اساس شاخص آن به دست آورید.
3. با دسترسی به [ControlCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/controlcollection/)، به کنترل‌های ActiveX در اسلاید دسترسی پیدا کنید.
4. با استفاده از شیء [Control](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/control/) به کنترل ActiveX TextBox1 دسترسی پیدا کنید.
5. ویژگی‌های کنترل ActiveX TextBox1 را که شامل متن، قلم، ارتفاع قلم و موقعیت فریم می‌شود، تغییر دهید.
6. کنترل دوم به نام CommandButton1 را دسترسی پیدا کنید.
7. عنوان دکمه، قلم و موقعیت آن را تغییر دهید.
8. موقعیت فریم‌های کنترل‌های ActiveX را جابه‌جا کنید.
9. ارائه‌ی تغییر یافته را به یک فایل PPTX بنویسید.

این کد نمونه، بر پایه مراحل فوق، نشان می‌دهد چگونه یک کنترل ساده ActiveX را مدیریت کنید:

```javascript
const imageio = java.import("javax.imageio.ImageIO");
// دسترسی به ارائه با کنترل‌های ActiveX
var pres = new aspose.slides.Presentation("ActiveX.pptm");
try {
    // دسترسی به اولین اسلاید در ارائه
    var slide = pres.getSlides().get_Item(0);
    // تغییر متن TextBox
    var control = slide.getControls().get_Item(0);
    if (control.getName().toUpperCase() === "TextBox1".toUpperCase() && (control.getProperties() != null)) {
        var newText = "Changed text";
        control.getProperties().set_Item("Value", newText);
        // تغییر تصویر جایگزین. PowerPoint این تصویر را هنگام فعال‌سازی ActiveX جایگزین خواهد کرد،
        // بنابراین گاهی امکان دارد تصویر بدون تغییر باقی بماند.
        var image = java.newInstanceSync("java.awt.image.BufferedImage", control.getFrame().getWidth(), control.getFrame().getHeight(), java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
        var graphics = image.getGraphics();
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "window"));
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());
        var font = java.newInstanceSync("java.awt.Font", control.getProperties().get_Item("FontName"), java.getStaticFieldValue("java.awt.Font", "PLAIN"), 16);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "windowText"));
        graphics.setFont(font);
        graphics.drawString(newText, 10, 20);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlShadow"));
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlDkShadow"));
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlHighlight"));
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlLtHighlight"));
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);
        graphics.dispose();
        var baos = java.newInstanceSync("java.io.ByteArrayOutputStream");
        imageio.write(image, "PNG", baos);
        var byteStream = Readable.from([Buffer.from(baos.toByteArray())]);
        aspose.slides.readBytesFromStream(byteStream, (imgData) => {
            control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(imgData));
        });
    }
    // تغییر عنوان دکمه
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);
    if (control.getName().toUpperCase() === "CommandButton1".toUpperCase() && (control.getProperties() != null)) {
        var newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // تغییر جایگزین
        var image = java.newInstanceSync("java.awt.image.BufferedImage", control.getFrame().getWidth(), control.getFrame().getHeight(), java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
        var graphics = image.getGraphics();
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "control"));
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());
        var font = java.newInstanceSync("java.awt.Font", control.getProperties().get_Item("FontName"), java.getStaticFieldValue("java.awt.Font", "PLAIN"), 16);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "windowText"));
        graphics.setFont(font);
        var metrics = graphics.getFontMetrics(font);
        graphics.drawString(newCaption, java.newFloat((image.getWidth() - metrics.stringWidth(newCaption)) / 2), 20);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlLtHighlight"));
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlHighlight"));
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlShadow"));
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlDkShadow"));
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);
        graphics.dispose();
        
        var baos = java.newInstanceSync("java.io.ByteArrayOutputStream");
        imageio.write(image, "PNG", baos);
        var byteStream = Readable.from([Buffer.from(baos.toByteArray())]);
        aspose.slides.readBytesFromStream(byteStream, (imgData) => {
            control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(imgData));
        });
    }
    // جابه‌جایی 100 نقطه به سمت پایین
    for (let i = 0; i < pres.getSlides().get_Item(0).getControls().size(); i++) {
        let ctl = pres.getSlides().get_Item(0).getControls().get_Item(i);
        var frame = ctl.getFrame();
        ctl.setFrame(new aspose.slides.ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), java.newByte(frame.getFlipH()), java.newByte(frame.getFlipV()), frame.getRotation()));
    }
    pres.save("withActiveX-edited_java.pptm", aspose.slides.SaveFormat.Pptm);
    // حذف کنترل‌ها
    pres.getSlides().get_Item(0).getControls().clear();
    pres.save("withActiveX-cleared_java.pptm", aspose.slides.SaveFormat.Pptm);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **سؤال و جواب**

**آیا Aspose.Slides کنترل‌های ActiveX را هنگام خواندن و ذخیره مجدد حفظ می‌کند حتی اگر در محیط اجرای Python قابل اجرا نباشند؟**  
بله. Aspose.Slides آن‌ها را به عنوان بخشی از ارائه در نظر می‌گیرد و می‌تواند ویژگی‌ها و فریم‌های آن‌ها را بخواند/تغییر دهد؛ اجرای خود کنترل‌ها برای حفظ آن‌ها لازم نیست.

**کنترل‌های ActiveX چگونه با اشیاء OLE در یک ارائه متفاوت هستند؟**  
کنترل‌های ActiveX کنترل‌های مدیریتی تعاملی هستند (دکمه‌ها، جعبه‌های متن، Media Player)، در حالی که [OLE](/slides/fa/nodejs-java/manage-ole/) به اشیاء برنامه‌ای جاسازی‌شده (مثلاً یک برگه Excel) اشاره دارد. آن‌ها به‌صورت متفاوتی ذخیره و مدیریت می‌شوند و مدل ویژگی‌های متفاوتی دارند.

**آیا رویدادهای ActiveX و ماکروهای VBA در صورتی که فایل توسط Aspose.Slides اصلاح شده باشد کار می‌کنند؟**  
Aspose.Slides علامت‌گذاری و متادیتای موجود را حفظ می‌کند؛ اما رویدادها و ماکروها تنها در داخل PowerPoint روی ویندوز و هنگامی که امنیت اجازه می‌دهد اجرا می‌شوند. کتابخانه VBA را اجرا نمی‌کند.