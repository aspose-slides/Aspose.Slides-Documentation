---
title: مدیریت کنترل‌های ActiveX در ارائه‌ها با Java
linktitle: ActiveX
type: docs
weight: 80
url: /fa/java/activex/
keywords:
- ActiveX
- کنترل ActiveX
- مدیریت ActiveX
- افزودن ActiveX
- ویرایش ActiveX
- پخش‌کننده رسانه
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "ویرایش جعبه‌های متن و دکمه‌های ActiveX، به‌روزرسانی پیش‌نمایش کنترل‌ها، و استفاده مجدد از کنترل Windows Media Player در ارائه‌های PowerPoint با Aspose.Slides برای Java."
---
## **مقدمه**

ActiveX controls به اسلاید PowerPoint عناصر تعاملی مانند جعبه‌های متن، دکمه‌های فرمانی و پخش‌کننده‌های رسانه‌ای می‌دهند. Aspose.Slides for Java کنترل‌های یک اسلاید را از طریق [IBaseSlide.getControls](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getControls--) در دسترس قرار می‌دهد. از این مجموعه برای ویرایش یک کنترل، جابجا کردن آن در اسلاید یا حذف آن استفاده کنید.

## **فهرست کنترل‌های ActiveX و ویژگی‌های ذخیره‌شده آنها**

برای بررسی یک قالب ناآشنا، آن را برای خواندن باز کنید و در هر اسلاید بر روی کنترل‌ها پیمایش کنید. مثال شماره اسلاید، نام کنترل، [getClassId](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getClassId--)، و هر جفت کلید‑مقدار در [getProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getProperties--) را گزارش می‌دهد. این کار ارائه را بدون فعال‌سازی کنترل‌ها، فراخوانی رویدادها یا ماکروها، تغییر مقادیر یا ذخیره‌سازی فایل می‌خواند.

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

خروجی انتخابی از `ActiveX.pptm` یک جعبه متن و یک دکمه فرمانی را نشان می‌دهد.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

یک مجموعه ویژگی خالی به صورت `[]` نمایش داده می‌شود. برای کنترل‌هایی که از ذخیره‌سازی باینری استفاده می‌کنند، [getProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getProperties--) می‌تواند `null` برگرداند که به صورت `Properties unavailable` نشان داده می‌شود. اگر فقط نام‌ها را نیاز دارید، پس از بررسی `null` از [getNamesOfProperties](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/#getNamesOfProperties--) استفاده کنید. گزارش ویژگی‌های موجود در ارائه را فهرست می‌کند. یک کنترل ممکن است در زمان اجرا ویژگی‌های اضافی داشته باشد.

## **ویرایش کنترل‌های ActiveX**

مثال انتظار دارد ارائه‌ای با ماکرو فعال داشته باشد که در اسلاید اول یک جعبه متن به نام `TextBox1` و یک دکمه فرمانی به نام `CommandButton1` داشته باشد. از [control properties collection](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/) برای تغییر مقدار جعبه متن و عنوان دکمه استفاده می‌کند. هر کنترل همچنین یک پیش‌نمایش ثابت دارد که PowerPoint قبل از فعال‌سازی می‌تواند نمایش دهد. برای هر کنترل یک PNG که متن و ظاهر به‌روز‌شده آن را نشان می‌دهد فراهم کنید. مثال این تصاویر را از طریق [IControl.getSubstitutePictureFormat](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getSubstitutePictureFormat--) اختصاص می‌دهد.

مثال هر کنترل را در اسلاید اول به اندازه ۱۰۰ نقطه به سمت پایین حرکت می‌دهد با تنظیم قاب آن با [IControl.setFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#setFrame-com.aspose.slides.IShapeFrame-). ارائه ویرایش‌شده را در قالب PPTM ذخیره می‌کند، سپس از [IControlCollection.clear](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolcollection/#clear--) برای ذخیره یک نسخه دوم با حذف تمامی کنترل‌های ActiveX از آن اسلاید استفاده می‌کند.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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

    Path textBoxPath = Paths.get("text-box-preview.png");
    Path buttonPath = Paths.get("button-preview.png");
    byte[] textBoxBytes = Files.readAllBytes(textBoxPath);
    byte[] buttonBytes = Files.readAllBytes(buttonPath);
    IPPImage textBoxPreview = presentation.getImages().addImage(textBoxBytes);
    IPPImage buttonPreview = presentation.getImages().addImage(buttonBytes);
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

## **افزودن کنترل Media Player ActiveX**

برای استفاده مجدد از یک کنترل Windows Media Player پیکربندی‌شده، با یک قالبی شروع کنید که اسلاید اول آن حاوی یک پخش‌کننده به نام `WindowsMediaPlayer1` باشد. [ISlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) کل اسلاید را به یک ارائه جدید کپی می‌کند. مثال `URL` پخش‌کننده را در [properties collection](https://reference.aspose.com/slides/java/com.aspose.slides/icontrolpropertiescollection/) تنظیم می‌کند و اسلاید کلون‌شده را به عنوان تنها اسلاید در خروجی ذخیره می‌نماید. ویدئو به صورت خارجی باقی می‌ماند، بنابراین مسیری را انتخاب کنید که پخش‌کننده بتواند در زمان پخش به آن دسترسی داشته باشد.

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

## **سوالات متداول**

**آیا Aspose.Slides می‌تواند کنترل‌های ActiveX را بدون اجرا کردن آنها حفظ کند؟**

بله. Aspose.Slides می‌تواند کنترل‌ها را بخواند و ذخیره کند، از جمله ویژگی‌ها و موقعیت‌های آن‌ها، بدون اینکه آن‌ها را فعال کند.

**کترل‌های ActiveX چگونه با اشیاء OLE تفاوت دارند؟**

کنترل‌های ActiveX به کاربران اجازه می‌دهند با اسلاید تعامل داشته باشند، برای مثال با وارد کردن متن یا کلیک روی دکمه. یک [شی OLE](/slides/fa/java/manage-ole/) به اسلاید امکان می‌دهد محتوا را که توسط برنامه دیگری مدیریت می‌شود، مانند یک ورک‌شیت Excel، شامل یا لینک کند.

**آیا رویدادهای ActiveX پس از ذخیره ارائه با Aspose.Slides همچنان ماکروهای VBA را فعال می‌کنند؟**

ارائه را در قالبی فعال برای ماکرو مانند PPTM ذخیره کنید تا پروژه VBA آن حفظ شود. PowerPoint برای Windows می‌تواند هندلرهای رویداد موجود را اجرا کند وقتی تنظیمات امنیتی آن اجازه استفاده همزمان از کنترل‌های ActiveX و ماکروها را می‌دهند.