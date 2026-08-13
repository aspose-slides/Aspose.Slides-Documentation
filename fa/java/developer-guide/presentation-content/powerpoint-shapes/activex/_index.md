---
title: مدیریت کنترل‌های ActiveX در ارائه‌ها با استفاده از Java
linktitle: ActiveX
type: docs
weight: 80
url: /fa/java/activex/
keywords:
- ActiveX
- کنترل ActiveX
- مدیریت ActiveX
- افزودن ActiveX
- تغییر ActiveX
- پخش‌کننده رسانه
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه Aspose.Slides برای Java از ActiveX برای خودکارسازی و بهبود ارائه‌های PowerPoint استفاده می‌کند و به توسعه‌دهندگان کنترل قدرتمندی بر روی اسلایدها می‌دهد."
---
## **مقدمه**

کنترل‌های ActiveX در ارائه‌ها استفاده می‌شوند. Aspose.Slides for Java به شما امکان اضافه‌کردن و مدیریت این کنترل‌ها را می‌دهد، اما نسبت به اشکال معمولی ارائه کمی سخت‌تر هستند. ما پشتیبانی از افزودن کنترل Active Media Player را در Aspose.Slides پیاده‌سازی کرده‌ایم. توجه داشته باشید که کنترل‌های ActiveX اشکال نیستند؛ آن‌ها بخشی از [IShapeCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapecollection/) ارائه نیستند. در عوض بخشی از [IControlCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icontrolcollection/) جداگانه هستند. در این موضوع نحوه کار با آن‌ها را به شما نشان می‌دهیم.

## **افزودن یک کنترل ActiveX Media Player به اسلاید**
برای افزودن کنترل Media Player ActiveX، مراحل زیر را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید و یک ارائه خالی تولید کنید.  
2. اسلاید هدف را در [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) بازیابی کنید.  
3. کنترل Media Player ActiveX را با استفاده از متد [addControl](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) که توسط [IControlCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icontrolcollection/) ارائه می‌شود، اضافه کنید.  
4. به کنترل Media Player ActiveX دسترسی پیدا کنید و مسیر ویدئو را با استفاده از ویژگی‌های آن تنظیم کنید.  
5. ارائه را به صورت فایل PPTX ذخیره کنید.

این کد نمونه، بر پایهٔ مراحل بالا، نشان می‌دهد که چگونه یک کنترل Media Player ActiveX به یک اسلاید افزوده شود:

```java
import com.aspose.slides.*;

// ایجاد نمونه ارائهٔ خالی
Presentation pres = new Presentation();
try {
    // افزودن کنترل Media Player ActiveX
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // دسترسی به کنترل Media Player ActiveX و تنظیم مسیر ویدئو
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // ذخیرهٔ ارائه
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تغییر یک کنترل ActiveX**
{{% alert color="info" %}} 
Aspose.Slides for Java 7.1.0 و نسخه‌های جدیدتر دارای اجزایی برای مدیریت کنترل‌های ActiveX هستند. می‌توانید به کنترل ActiveX که قبلاً به ارائه‌تان اضافه شده دسترسی یافته و آن را از طریق ویژگی‌هایش تغییر یا حذف کنید. 
{{% /alert %}} 

برای مدیریت یک کنترل ساده ActiveX مانند یک TextBox و یک CommandButton ساده بر روی اسلاید، این کارها را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید و ارائه‌ای که حاوی کنترل‌های ActiveX است بارگذاری کنید.  
2. با استفاده از ایندکس، مرجع اسلاید را به دست آورید.  
3. با دسترسی به [IControlCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icontrolcollection/)، به کنترل‌های ActiveX موجود در اسلاید دسترسی پیدا کنید.  
4. کنترل TextBox1 ActiveX را با استفاده از شیء [IControl](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icontrol/) دریافت کنید.  
5. ویژگی‌های کنترل TextBox1 ActiveX را که شامل متن، قلم، ارتفاع قلم و موقعیت قاب هستند، تغییر دهید.  
6. به کنترل دوم به نام CommandButton1 دسترسی پیدا کنید.  
7. عنوان دکمه، قلم و موقعیت آن را تغییر دهید.  
8. موقعیت قاب‌های کنترل‌های ActiveX را جابه‌جا کنید.  
9. ارائهٔ اصلاح‌شده را به فایل PPTX بنویسید.

این کد نمونه، بر پایهٔ مراحل بالا، نشان می‌دهد که چگونه یک کنترل ساده ActiveX را مدیریت کنید:

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

        // تغییر تصویر جایگزین. PowerPoint این تصویر را هنگام فعال‌سازی ActiveX جایگزین خواهد کرد،
        // بنابراین گاهی می‌توان تصویر را دست‌نخورده باقی گذاشت.
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

            // انتقال 100 نقطه به پایین
            for (IControl ctl : pres.getSlides().get_Item(0).getControls()) {
                IShapeFrame frame = ctl.getFrame();
                ctl.setFrame(new ShapeFrame(frame.getX(), frame.getY() + 100,
                        frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation()));
            }
            pres.save("withActiveX-edited_java.pptm", SaveFormat.Pptm);

            // حذف کنترل‌ها
            pres.getSlides().get_Item(0).getControls().clear();
            pres.save("withActiveX-cleared_java.pptm", SaveFormat.Pptm);
        } catch(IOException e) {
        } finally {
            if (pres != null) pres.dispose();
        }
```

## **سوالات متداول**

### آیا Aspose.Slides کنترل‌های ActiveX را هنگام خواندن و ذخیرهٔ مجدد حفظ می‌کند حتی اگر در زمان اجرای Java قابل اجرا نباشند؟

بله. Aspose.Slides آن‌ها را به عنوان بخشی از ارائه در نظر می‌گیرد و می‌تواند ویژگی‌ها و قاب‌های آن‌ها را بخواند/تغییر دهد؛ اجرای خود کنترل‌ها برای حفظ آن‌ها لازم نیست.

### کنترل‌های ActiveX چگونه با اشیای OLE در یک ارائه تفاوت دارند؟

کنترل‌های ActiveX کنترل‌های تعاملی مدیریت‌شده (دکمه‌ها، TextBoxها، Media Player) هستند، در حالی که [OLE](/slides/fa/java/manage-ole/) به اشیای برنامه‌نویسی جاسازی‌شده (مانند یک کاربرگ Excel) اشاره دارد. آن‌ها به شکل متفاوتی ذخیره و مدیریت می‌شوند و مدل‌های ویژگی متفاوتی دارند.

### آیا رویدادهای ActiveX و ماکروهای VBA در صورتی که فایل توسط Aspose.Slides اصلاح شده باشد کار می‌کنند؟

Aspose.Slides نشانه‌گذاری و متادیتای موجود را حفظ می‌کند؛ اما رویدادها و ماکروها فقط در PowerPoint روی ویندوز و زمانی که امنیت اجازه دهد اجرا می‌شوند. کتابخانه VBA را اجرا نمی‌کند.