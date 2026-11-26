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
- اصلاح ActiveX
- پخش‌کنندهٔ رسانه‌ای
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "ویرایش جعبه‌های متن و دکمه‌های ActiveX، به‌روزرسانی پیش‌نمایش کنترل‌ها، و استفاده مجدد از کنترل Windows Media Player در ارائه‌های PowerPoint با Aspose.Slides برای Node.js از طریق Java."
---
## **مقدمه**

کنترل‌های ActiveX عناصر تعاملی مانند جعبه‌های متن، دکمه‌های فرمان و پخش‌کننده‌های رسانه‌ای را به اسلاید PowerPoint می‌دهند. Aspose.Slides برای Node.js از طریق Java کنترل‌های اسلاید را از طریق [BaseSlide.getControls](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getControls) در دسترس قرار می‌دهد. از این مجموعه برای ویرایش یک کنترل، جابه‌جایی آن در اسلاید یا حذف آن استفاده کنید.

## **فهرست کنترل‌های ActiveX و ویژگی‌های ذخیره‌شده آنها**

برای بررسی یک الگوی ناآشنا، آن را برای خواندن باز کنید و روی هر اسلاید کنترل‌ها را مرور کنید. مثال شماره اسلاید، نام کنترل، [getClassId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getClassId) و هر جفت کلید‑مقدار در [getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties) را گزارش می‌دهد. ارائه بدون فعال‌سازی کنترل‌ها، فراخوانی رویدادها یا ماکروها، تغییر مقادیر یا ذخیرهٔ فایل خوانده می‌شود.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("ActiveX.pptm");
try {
    const slideList = presentation.getSlides();
    for (let i = 0; i < slideList.size(); i++) {
        const controls = slideList.get_Item(i).getControls();
        for (let j = 0; j < controls.size(); j++) {
            const control = controls.get_Item(j);
            console.log(`Slide ${i + 1} | ${control.getName()} | ${control.getClassId()}`);
            const properties = control.getProperties();
            if (properties == null) {
                console.log("  Properties unavailable");
                continue;
            }
            if (properties.getCount() === 0) {
                console.log("  []");
            }
            const names = properties.getNamesOfProperties().iterator();
            while (names.hasNext()) {
                const name = names.next();
                console.log(`  ${name} = ${properties.get_Item(name)}`);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

خروجی انتخاب‌شده از `ActiveX.pptm` یک جعبه متن و یک دکمه فرمان را نشان می‌دهد.

```text
Slide 1 | TextBox1 | 8bd21d10-ec42-11ce-9e0d-00aa006002f3
  Value = Some text
  FontName = Arial
Slide 1 | CommandButton1 | d7053240-ce69-11cd-a777-00dd01143c57
  Caption = Show
  FontName = Arial
```

یک مجموعهٔ ویژگی خالی به صورت `[]` نمایش داده می‌شود. برای کنترل‌هایی که از ذخیره‌سازی باینری استفاده می‌کنند، [getProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getProperties) می‌تواند `null` برگرداند که به صورت `Properties unavailable` نشان داده می‌شود. اگر فقط به نام‌ها نیاز دارید، پس از بررسی `null` از [getNamesOfProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/#getNamesOfProperties) استفاده کنید. گزارش ویژگی‌های در دسترس از ارائه را فهرست می‌کند. یک کنترل ممکن است در زمان اجرا ویژگی‌های اضافه‌ای را پشتیبانی کند.

## **ویرایش کنترل‌های ActiveX**

این مثال یک ارائهٔ ماکرو‌پذیر با یک جعبه متن به نام `TextBox1` و یک دکمه فرمان به نام `CommandButton1` در اسلاید اول انتظار دارد. از [control properties collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) برای تغییر مقدار جعبه متن و عنوان دکمه استفاده می‌کند. هر کنترل همچنین پیش‌نمایش ایستایی دارد که PowerPoint می‌تواند قبل از فعال‌سازی نمایش دهد. برای هر کنترل یک PNG حاوی متن و ظاهر به‌روز شده فراهم کنید. مثال این تصاویر را از طریق [Control.getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#getSubstitutePictureFormat) اختصاص می‌دهد.

مثال هر کنترل در اسلاید اول را با تنظیم قاب آن با [Control.setFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/control/#setFrame) به میزان ۱۰۰ نقطه به سمت پایین جابه‌جا می‌کند. ارائه ویرایش‌شده را در فرمت PPTM ذخیره کرده، سپس با استفاده از [ControlCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlcollection/#clear) یک نسخهٔ دوم بدون همهٔ کنترل‌های ActiveX از آن اسلاید ذخیره می‌کند.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function addPreview(presentation, path) {
    const image = slides.Images.fromFile(path);
    try {
        return presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
}

function editControls() {
    const presentation = new slides.Presentation("ActiveX.pptm");
    try {
        const controls = presentation.getSlides().get_Item(0).getControls();
        let textBox;
        let button;
        for (let i = 0; i < controls.size(); i++) {
            const control = controls.get_Item(i);
            if (control.getName() === "TextBox1") {
                textBox = control;
            } else if (control.getName() === "CommandButton1") {
                button = control;
            }
        }
        if (!textBox || !button || textBox.getProperties() == null || button.getProperties() == null) {
            console.log("The first slide must contain both named controls with editable properties.");
            return;
        }

        const textBoxPreview = addPreview(presentation, "text-box-preview.png");
        const buttonPreview = addPreview(presentation, "button-preview.png");
        textBox.getProperties().set_Item("Value", "Changed text");
        button.getProperties().set_Item("Caption", "Show message");
        textBox.getSubstitutePictureFormat().getPicture().setImage(textBoxPreview);
        button.getSubstitutePictureFormat().getPicture().setImage(buttonPreview);

        for (let i = 0; i < controls.size(); i++) {
            const control = controls.get_Item(i);
            const frame = control.getFrame();
            const flipH = java.newByte(frame.getFlipH());
            const flipV = java.newByte(frame.getFlipV());
            const moved = new slides.ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), flipH, flipV, frame.getRotation());
            control.setFrame(moved);
        }
        presentation.save("edited-controls.pptm", slides.SaveFormat.Pptm);

        controls.clear();
        presentation.save("removed-controls.pptm", slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}

editControls();
```
## **افزودن کنترل پخش‌کنندهٔ رسانه‌ای ActiveX**

برای استفاده مجدد از یک کنترل Windows Media Player پیکربندی‌شده، با یک الگو که اسلاید اول آن شامل یک پخش‌کننده به نام `WindowsMediaPlayer1` است شروع کنید. [SlideCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addClone) کل اسلاید را به یک ارائهٔ جدید کپی می‌کند. مثال `URL` پخش‌کننده را در [properties collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/controlpropertiescollection/) تنظیم کرده و اسلاید کلون‌شده را به‌عنوان تنها اسلاید خروجی ذخیره می­کند. ویدئو به‌صورت خارجی می‌ماند، بنابراین مسیر قابل دسترسی برای پخش‌کننده را انتخاب کنید.

```javascript
const slides = require("aspose.slides.via.java");

function addMediaPlayer() {
    const template = new slides.Presentation("template.pptx");
    try {
        const presentation = new slides.Presentation();
        try {
            const templateSlide = template.getSlides().get_Item(0);
            const slide = presentation.getSlides().addClone(templateSlide);
            const controls = slide.getControls();
            let player;
            for (let i = 0; i < controls.size(); i++) {
                const control = controls.get_Item(i);
                if (control.getName() === "WindowsMediaPlayer1") {
                    player = control;
                    break;
                }
            }
            if (!player || player.getProperties() == null) {
                console.log("The template slide must contain a named media player with editable properties.");
                return;
            }
            player.getProperties().set_Item("URL", "Wildlife.mp4");
            
            presentation.getSlides().removeAt(0);
            presentation.save("linked-video.pptx", slides.SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    } finally {
        template.dispose();
    }
}

addMediaPlayer();
```
## **سوالات متداول**

**آیا Aspose.Slides می‌تواند کنترل‌های ActiveX را بدون اجرا حفظ کند؟**

بله. Aspose.Slides می‌تواند کنترل‌ها را بخواند و ذخیره کند، از جمله ویژگی‌ها و موقعیت‌های آن‌ها، بدون اینکه آن‌ها را فعال کند.

**چگونه کنترل‌های ActiveX با اشیای OLE متفاوت هستند؟**

کنترل‌های ActiveX به کاربران اجازه می‌دهند با اسلاید تعامل داشته باشند، برای مثال با وارد کردن متن یا کلیک کردن روی دکمه. یک [شیء OLE](/slides/fa/nodejs-java/manage-ole/) به اسلاید امکان می‌دهد محتوا را که توسط برنامهٔ دیگری مدیریت می‌شود، مانند یک برگهٔ Excel، شامل یا به آن لینک دهد.

**آیا رویدادهای ActiveX پس از ذخیرهٔ ارائه با Aspose.Slides همچنان ماکروهای VBA را فراخوانی می‌کنند؟**

ارائه را در فرمت ماکروپذیر مانند PPTM ذخیره کنید تا پروژهٔ VBA آن حفظ شود. PowerPoint برای ویندوز می‌تواند پردازنده‌های رویداد موجود را اجرا کند هنگامی که تنظیمات امنیتی اجازهٔ استفاده همزمان از کنترل‌های ActiveX و ماکروها را می‌دهد.