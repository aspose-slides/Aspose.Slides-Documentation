---
title: مدیریت کنترل‌های ActiveX در ارائه‌ها روی Android
linktitle: ActiveX
type: docs
weight: 80
url: /fa/androidjava/activex/
keywords:
- ActiveX
- کنترل ActiveX
- مدیریت ActiveX
- افزودن ActiveX
- اصلاح ActiveX
- پخش‌کننده رسانه
- پاورپوینت
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه Aspose.Slides برای Android از طریق Java از ActiveX برای خودکارسازی و بهبود ارائه‌های پاورپوینت استفاده می‌کند و به توسعه‌دهندگان کنترل قدرتمندی بر اسلایدها می‌دهد."
---
## **معرفی**

کنترل‌های ActiveX در ارائه‌ها استفاده می‌شوند. Aspose.Slides برای Android از طریق Java به شما امکان افزودن و مدیریت کنترل‌های ActiveX را می‌دهد، اما نسبت به اشکال معمول ارائه، مدیریت آن‌ها کمی دشوارتر است. ما پشتیبانی از افزودن کنترل فعال Media Player را در Aspose.Slides پیاده‌سازی کردیم. توجه داشته باشید که کنترل‌های ActiveX اشکال نیستند؛ آن‌ها بخشی از [IShapeCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapecollection/) نیستند. بلکه بخشی از [IControlCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icontrolcollection/) جداگانه هستند. در این موضوع، نحوه کار با آن‌ها را نشان می‌دهیم.

## **افزودن یک کنترل ActiveX Media Player به یک اسلاید**
برای افزودن یک کنترل ActiveX Media Player، این کارها را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید و یک ارائه خالی تولید کنید.
2. به اسلاید هدف در [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) دسترسی پیدا کنید.
3. کنترل ActiveX Media Player را با استفاده از متد [addControl](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) که توسط [IControlCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icontrolcollection/) ارائه شده است، اضافه کنید.
4. به کنترل ActiveX Media Player دسترسی پیدا کنید و مسیر ویدیو را با استفاده از خصوصیات آن تنظیم کنید.
5. ارائه را به عنوان فایل PPTX ذخیره کنید.

این کد نمونه، بر اساس مراحل بالا، نشان می‌دهد چگونه یک کنترل ActiveX Media Player را به اسلاید اضافه کنید:

```java
import com.aspose.slides.*;

// یک نمونه خالی از ارائه ایجاد کنید
Presentation pres = new Presentation();
try {
    // افزودن کنترل ActiveX پخش‌کننده رسانه
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // دسترسی به کنترل ActiveX پخش‌کننده رسانه و تنظیم مسیر ویدیو
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // ذخیرهٔ ارائه
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تغییر یک کنترل ActiveX**
{{% alert color="info" %}} 
Aspose.Slides برای Android از طریق Java نسخه 7.1.0 و نسخه‌های جدیدتر مجهز به اجزایی برای مدیریت کنترل‌های ActiveX هستند. شما می‌توانید به کنترل ActiveX که قبلاً به ارائه‌تان اضافه شده دسترسی پیدا کنید و از طریق خصوصیات آن آن را اصلاح یا حذف کنید.
{{% /alert %}} 

برای مدیریت یک کنترل ساده ActiveX مانند یک جعبه متن و دکمه فرمان ساده در یک اسلاید، این مراحل را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید و ارائه حاوی کنترل‌های ActiveX را بارگذاری کنید.
2. یک مرجع اسلاید را بر اساس شاخص آن بدست آورید.
3. با دسترسی به [IControlCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icontrolcollection/) کنترل‌های ActiveX موجود در اسلاید را دسترسی پیدا کنید.
4. کنترل ActiveX TextBox1 را با استفاده از شیء [IControl](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icontrol/) دسترسی پیدا کنید.
5. خصوصیات کنترل ActiveX TextBox1 که شامل متن، قلم، ارتفاع قلم و موقعیت فریم است را تغییر دهید.
6. به کنترل دوم با نام CommandButton1 دسترسی پیدا کنید.
7. متن عنوان دکمه، قلم و موقعیت آن را تغییر دهید.
8. موقعیت فریم‌های کنترل‌های ActiveX را جابجا کنید.
9. ارائه اصلاح شده را به یک فایل PPTX بنویسید.

این کد نمونه، بر اساس مراحل بالا، نشان می‌دهد چگونه یک کنترل ساده ActiveX را مدیریت کنید:

```java
import com.aspose.slides.*;
import java.awt.FontMetrics;
import java.awt.SystemColor;
import java.awt.image.BufferedImage;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import javax.imageio.ImageIO;

// دسترسی به ارائه با کنترل‌های ActiveX
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // دسترسی به اولین اسلاید در ارائه
    ISlide slide = pres.getSlides().get_Item(0);

    // تغییر متن TextBox
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // تغییر تصویر جایگزین. PowerPoint این تصویر را هنگام فعال‌سازی ActiveX جایگزین می‌کند،
        // بنابراین گاهی اوقات امکان دارد تصویر بدون تغییر باقی بماند.
        BufferedImage image = new BufferedImage((int) control.getFrame().getWidth(), (int) control.getFrame().getHeight(),
                BufferedImage.TYPE_INT_ARGB);

        java.awt.Graphics graphics = image.getGraphics();
        graphics.setColor(SystemColor.window);
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());

        java.awt.Font font = new java.awt.Font(control.getProperties().get_Item("FontName"), java.awt.Font.PLAIN, 16);
        graphics.setColor(SystemColor.windowText);
        graphics.setFont(font);
        graphics.drawString(newText, 10, 20);

        graphics.setColor(SystemColor.controlShadow);
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);

        graphics.setColor(SystemColor.controlDkShadow);
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);

        graphics.setColor(SystemColor.controlHighlight);
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);

        graphics.setColor(SystemColor.controlLtHighlight);
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);

        graphics.dispose();

        ByteArrayOutputStream baos = new ByteArrayOutputStream();
        ImageIO.write(image, "PNG", baos);

        control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(baos.toByteArray()));
    }

    // تغییر عنوان دکمه
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);

    if (control.getName().equalsIgnoreCase("CommandButton1") && control.getProperties() != null) {
        String newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);

        // تغییر جایگزین
        BufferedImage image = new BufferedImage((int) control.getFrame().getWidth(), (int) control.getFrame().getHeight(),
                BufferedImage.TYPE_INT_ARGB);

        java.awt.Graphics graphics = image.getGraphics();
        graphics.setColor(SystemColor.control);
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());

        java.awt.Font font = new java.awt.Font(control.getProperties().get_Item("FontName"), java.awt.Font.PLAIN, 16);
        graphics.setColor(SystemColor.windowText);
        graphics.setFont(font);
        FontMetrics metrics = graphics.getFontMetrics(font);
        graphics.drawString(newCaption, (image.getWidth() - metrics.stringWidth(newCaption)) / 2, 20);

        graphics.setColor(SystemColor.controlLtHighlight);
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);

        graphics.setColor(SystemColor.controlHighlight);
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);

        graphics.setColor(SystemColor.controlShadow);
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);

        graphics.setColor(SystemColor.controlDkShadow);
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);

        graphics.dispose();

        ByteArrayOutputStream baos = new ByteArrayOutputStream();
        ImageIO.write(image, "PNG", baos);

        control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(baos.toByteArray()));
    }

    // جابجایی 100 نقطه به پایین
    for (IControl ctl : pres.getSlides().get_Item(0).getControls()) {
        IShapeFrame frame = ctl.getFrame();
        ctl.setFrame(new ShapeFrame(frame.getX(), frame.getY() + 100,
                frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation()));
    }
    pres.save("withActiveX-edited_java.pptm", SaveFormat.Pptm);

    // حذف کنترل‌ها
    pres.getSlides().get_Item(0).getControls().clear();
    pres.save("withActiveX-cleared_java.pptm", SaveFormat.Pptm);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **سؤالات متداول**

### آیا Aspose.Slides کنترل‌های ActiveX را هنگام خواندن و دوبار ذخیره‌سازی حفظ می‌کند اگر نتوانند در زمان اجرا Java اجرا شوند؟

بله. Aspose.Slides آن‌ها را به عنوان بخشی از ارائه در نظر می‌گیرد و می‌تواند خصوصیات و فریم‌های آن‌ها را بخواند/تغییر دهد؛ اجرای خود کنترل‌ها برای حفظ آن‌ها لازم نیست.

### ActiveX کنترل‌ها چگونه با اشیاء OLE در یک ارائه متفاوت هستند؟

کنترل‌های ActiveX کنترل‌های مدیریت‌شده‌ای تعاملی هستند (دکمه‌ها، جعبه‌های متن، Media Player)، در حالی که [OLE](/slides/fa/androidjava/manage-ole/) به اشیاء برنامه‌ای جاسازی‌شده (به عنوان مثال یک برگه‌کار Excel) اشاره دارد. آن‌ها به‌صورت متفاوتی ذخیره و مدیریت می‌شوند و مدل‌های خصوصیتی متفاوتی دارند.

### آیا رویدادهای ActiveX و ماکروهای VBA کار می‌کنند اگر فایل توسط Aspose.Slides اصلاح شده باشد؟

Aspose.Slides نشانه‌گذاری و متادیتای موجود را حفظ می‌کند؛ با این حال، رویدادها و ماکروها فقط در داخل PowerPoint بر روی ویندوز اجرا می‌شوند هنگامی که امنیت اجازه دهد. کتابخانه VBA را اجرا نمی‌کند.