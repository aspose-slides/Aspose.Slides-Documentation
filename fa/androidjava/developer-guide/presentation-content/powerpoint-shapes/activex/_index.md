---
title: مدیریت کنترل‌های ActiveX در ارائه‌ها در Android
linktitle: ActiveX
type: docs
weight: 80
url: /fa/androidjava/activex/
keywords:
- ActiveX
- کنترل ActiveX
- مدیریت ActiveX
- افزودن ActiveX
- ویرایش ActiveX
- پخش‌کننده رسانه‌ای
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "ویرایش جعبه‌های متن و دکمه‌های ActiveX، به‌روزرسانی پیش‌نمایش کنترل‌ها، و استفاده مجدد از کنترل Windows Media Player در ارائه‌های PowerPoint با Aspose.Slides برای Android از طریق Java."
---
## **مقدمه**

کنترل‌های ActiveX عناصر تعاملی مانند جعبه‌های متن، دکمه‌های فرمان و پخش‌کننده‌های رسانه‌ای را به اسلایدهای PowerPoint می‌افزایند. Aspose.Slides for Android via Java کنترل‌های یک اسلاید را از طریق [IBaseSlide.getControls](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getControls--) در دسترس می‌گذارد. از این مجموعه برای ویرایش یک کنترل، جابجا کردن آن در اسلاید یا حذف آن استفاده کنید. در مثال‌های زیر، مسیرهای فایلی را که برنامهٔ Android شما می‌تواند بخواند انتخاب کنید و برای هر ارائهٔ خروجی مکان قابل نوشتن تعیین کنید.

## **فهرست کنترل‌های ActiveX و ویژگی‌های ذخیره‌شده‌شان**

برای بررسی یک قالب ناشناخته، آن را برای خواندن باز کنید و در هر اسلاید از طریق کنترل‌ها مرور کنید. مثال شمارهٔ اسلاید، نام کنترل، [getClassId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getClassId--) و هر جفت کلید‑مقدار در [getProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getProperties--) را گزارش می‌دهد. این کار ارائه را بدون فعال‌سازی کنترل‌ها، فراخوانی رویدادها یا ماکروها، تغییر مقادیر یا ذخیرهٔ فایل می‌خواند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ActiveX.pptm");
try {
    for (int i = 0; i < presentation.getSlides().size(); i++) {
        for (IControl control : presentation.getSlides().get_Item(i).getControls()) {
            System.out.printf("Slide %d | %s | %s%n", i + 1, control.getName(), control.getClassId());
            IControlPropertiesCollection properties = control.getProperties();
            if (properties == null) {
                System.out.println("  Properties unavailable");
                continue;
            }
            if (properties.getCount() == 0) {
                System.out.println("  []");
            }
            for (String name : properties.getNamesOfProperties()) {
                System.out.printf("  %s = %s%n", name, properties.get_Item(name));
            }
        }
    }
} finally {
    presentation.dispose();
}
```

خروجی منتخب از `ActiveX.pptm` یک جعبهٔ متن و یک دکمهٔ فرمان را نشان می‌دهد.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

یک مجموعهٔ ویژگی خالی به صورت `[]` نمایش داده می‌شود. برای کنترل‌هایی که از ذخیره‌سازی باینری استفاده می‌کنند، [getProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getProperties--) می‌تواند `null` برگرداند که به شکل `Properties unavailable` نشان داده می‌شود. اگر فقط به نام‌ها نیاز دارید، پس از بررسی مقدار null از [getNamesOfProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolpropertiescollection/#getNamesOfProperties--) استفاده کنید. گزارش ویژگی‌های موجود در ارائه را فهرست می‌کند. یک کنترل ممکن است در زمان اجرا ویژگی‌های اضافی داشته باشد.

## **تغییر کنترل‌های ActiveX**

این مثال یک ارائهٔ دارای ماکرو با یک جعبهٔ متن به نام `TextBox1` و یک دکمهٔ فرمان به نام `CommandButton1` در اسلاید اول انتظار دارد. از [control properties collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolpropertiescollection/) برای تغییر مقدار جعبهٔ متن و کپشن دکمه استفاده می‌کند. هر کنترل همچنین یک پیش‌نمایش ثابت دارد که PowerPoint می‌تواند قبل از فعال‌سازی نمایش دهد. برای هر کنترل یک تصویر PNG حاوی متن و ظاهر به‌روز شده عرضه کنید. مثال این تصاویر را از طریق [IControl.getSubstitutePictureFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#getSubstitutePictureFormat--) تعیین می‌کند.

مثال همهٔ کنترل‌های اسلاید اول را با تنظیم فریم آنها از طریق [IControl.setFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrol/#setFrame-com.aspose.slides.IShapeFrame-) به سمت پایین ۱۰۰ نقطه جابجا می‌کند. پس از ذخیرهٔ ارائه ویرایش‌شده در قالب PPTM، از [IControlCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolcollection/#clear--) برای ذخیرهٔ نسخهٔ دوم بدون هیچ‌یک از کنترل‌های ActiveX استفاده می‌کند.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.FileInputStream;

Presentation presentation = new Presentation("ActiveX.pptm");
try {
    IControlCollection controls = presentation.getSlides().get_Item(0).getControls();
    IControl textBox = null;
    IControl button = null;
    for (IControl control : controls) {
        if ("TextBox1".equals(control.getName())) {
            textBox = control;
        } else if ("CommandButton1".equals(control.getName())) {
            button = control;
        }
    }
    if (textBox == null || button == null || textBox.getProperties() == null || button.getProperties() == null) {
        System.out.println("The first slide must contain both named controls with editable properties.");
        return;
    }

    IPPImage textBoxPreview;
    IPPImage buttonPreview;
    try (FileInputStream textBoxStream = new FileInputStream("text-box-preview.png");
         FileInputStream buttonStream = new FileInputStream("button-preview.png")) {
        textBoxPreview = presentation.getImages().addImage(textBoxStream);
        buttonPreview = presentation.getImages().addImage(buttonStream);
    }
    textBox.getProperties().set_Item("Value", "Changed text");
    button.getProperties().set_Item("Caption", "Show message");
    textBox.getSubstitutePictureFormat().getPicture().setImage(textBoxPreview);
    button.getSubstitutePictureFormat().getPicture().setImage(buttonPreview);

    for (IControl control : controls) {
        IShapeFrame frame = control.getFrame();
        ShapeFrame moved = new ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation());
        control.setFrame(moved);
    }
    presentation.save("edited-controls.pptm", SaveFormat.Pptm);

    controls.clear();
    presentation.save("removed-controls.pptm", SaveFormat.Pptm);
} catch (IOException e) {
    System.out.println("Could not read a control preview: " + e.getMessage());
} finally {
    presentation.dispose();
}
```

## **افزودن کنترل پخش‌کننده رسانه‌ای ActiveX**

برای استفاده مجدد از کنترل Windows Media Player پیکربندی‌شده، از قالبی که اسلاید اول آن شامل یک پخش‌کننده به نام `WindowsMediaPlayer1` است آغاز کنید. [ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) کل اسلاید را به ارائهٔ جدید کپی می‌کند. مثال آدرس `URL` پخش‌کننده را در [properties collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icontrolpropertiescollection/) تنظیم می‌کند و اسلاید کپی‌شده را به‌عنوان تنها اسلاید در خروجی ذخیره می‌دارد. ویدئو به‌صورت خارجی باقی می‌ماند، بنابراین مسیر دسترسی پخش‌کننده در زمان پخش را انتخاب کنید.

```java
import com.aspose.slides.*;

Presentation template = new Presentation("template.pptx");
try {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().addClone(template.getSlides().get_Item(0));
        IControl player = null;
        for (IControl control : slide.getControls()) {
            if ("WindowsMediaPlayer1".equals(control.getName())) {
                player = control;
                break;
            }
        }
        if (player == null || player.getProperties() == null) {
            System.out.println("The template slide must contain a named media player with editable properties.");
            return;
        }
        player.getProperties().set_Item("URL", "Wildlife.mp4");

        presentation.getSlides().removeAt(0);
        presentation.save("linked-video.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    template.dispose();
}
```

## **پرسش‌های متداول**

**آیا Aspose.Slides می‌تواند کنترل‌های ActiveX را بدون اجرا کردن آنها حفظ کند؟**

بله. Aspose.Slides می‌تواند کنترل‌ها را به همراه ویژگی‌ها و موقعیت‌هایشان بخواند و ذخیره کند بدون اینکه آنها را فعال کند.

**کنترل‌های ActiveX چطور با اشیاء OLE متفاوت هستند؟**

کنترل‌های ActiveX به کاربران اجازه می‌دهند با اسلاید تعامل داشته باشند، برای مثال متن وارد کنند یا روی دکمه کلیک کنند. یک [شی OLE](/slides/fa/androidjava/manage-ole/) به اسلاید این امکان را می‌دهد که محتوای مدیریت‌شده توسط برنامهٔ دیگری مانند یک کاربرگ Excel را شامل یا به آن لینک کند.

**آیا پس از ذخیرهٔ ارائه با Aspose.Slides، رویدادهای ActiveX هنوز ماکروهای VBA را اجرا می‌کنند؟**

برای حفظ پروژهٔ VBA، ارائه را در قالبی با پشتیبانی از ماکروها مثل PPTM ذخیره کنید. PowerPoint برای Windows می‌تواند هندلرهای رویداد موجود را اجرا کند هنگامی که تنظیمات امنیتی اجازهٔ استفاده از هر دو کنترل ActiveX و ماکروها را می‌دهند.