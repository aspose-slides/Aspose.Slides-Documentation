---
title: "بهبود ارائه‌های شما با AutoFit در JavaScript"
linktitle: "تنظیمات Autofit"
type: docs
weight: 30
url: /fa/nodejs-java/manage-autofit-settings/
keywords:
- "جعبه متن"
- "autofit"
- "عدم autofit"
- "متن متناسب"
- "کوچک کردن متن"
- "پیچیدن متن"
- "تغییر اندازه شکل"
- "PowerPoint"
- "OpenDocument"
- "ارائه"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "تنظیمات AutoFit را در Aspose.Slides برای Node.js مدیریت کنید تا نمایش متن در ارائه‌های PowerPoint و OpenDocument بهینه شود و خوانایی محتوا بهبود یابد."
---
## **مقدمه**

به‌طور پیش‌فرض، وقتی یک جعبه متن اضافه می‌کنید، Microsoft PowerPoint از تنظیم **Resize shape to fix text** برای جعبه متن استفاده می‌کند—به‌صورت خودکار اندازه جعبه متن را تغییر می‌دهد تا مطمئن شود متن آن همیشه درون جعبه جای می‌گیرد. 

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* هنگامی که متن داخل جعبه متن طولانی‌تر یا بزرگ‌تر شود، PowerPoint به‌صورت خودکار جعبه متن را بزرگ می‌کند—ارتفاع آن را افزایش می‌دهد—تا فضای بیشتری برای متن داشته باشد. 
* هنگامی که متن داخل جعبه متن کوتاه‌تر یا کوچک‌تر شود، PowerPoint به‌صورت خودکار جعبه متن را کوچک می‌کند—ارتفاع آن را کاهش می‌دهد—تا فضای اضافه حذف شود. 

در PowerPoint، این چهار پارامتر یا گزینه مهمی هستند که رفتار AutoFit برای جعبه متن را کنترل می‌کنند: 

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Node.js via Java گزینه‌های مشابهی ارائه می‌دهد—برخی از ویژگی‌ها در کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/TextFrameFormat) که به شما امکان می‌دهد رفتار AutoFit برای جعبه‌های متن در ارائه‌ها را کنترل کنید.

## **تغییر اندازه شکل برای متناسب شدن با متن**

اگر می‌خواهید متن داخل یک جعبه پس از هر تغییری دائم در همان جعبه جا بگیرد، باید از گزینه **Resize shape to fix text** استفاده کنید. برای تعیین این تنظیم، متد [setAutofitType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) را از کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/TextFrameFormat) با مقدار `Shape` فراخوانی کنید.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

این کد JavaScript نشان می‌دهد چگونه می‌توانید مشخص کنید که متن همیشه در جعبه خود در یک ارائه PowerPoint جا بگیرد:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.Shape);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

اگر متن طولانی‌تر یا بزرگ‌تر شود، جعبه متن به‌صورت خودکار (ارتفاعش افزایش می‌یابد) تغییر اندازه می‌دهد تا تمام متن درون آن جا بگیرد. اگر متن کوتاه‌تر شود، برعکس اتفاق می‌افتد. 

## **Do Not Autofit**

اگر می‌خواهید یک جعبه متن یا شکل ابعاد خود را صرف‌نظر از هر تغییری که در متن آن ایجاد می‌شود، حفظ کند، باید از گزینه **Do not Autofit** استفاده کنید. برای تعیین این تنظیم، متد [setAutofitType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) را از کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/TextFrameFormat) با مقدار `None` فراخوانی کنید.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

این کد JavaScript نشان می‌دهد چگونه می‌توانید مشخص کنید که یک جعبه متن ابعاد خود را در یک ارائه PowerPoint حفظ کند:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.None);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

زمانی که متن برای جعبه‌اش بیش از حد طولانی شود، بیرون می‌ریزد. 

## **Shrink Text on Overflow**

اگر متنی برای جعبه‌اش بیش از حد طولانی شود، از گزینه **Shrink text on overflow** می‌توانید استفاده کنید تا اندازه و فاصله‌های متن کاهش یابند و در جعبه جا شوند. برای تعیین این تنظیم، متد [setAutofitType](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType) را از کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/TextFrameFormat) با مقدار `Normal` فراخوانی کنید.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

این کد JavaScript نشان می‌دهد چگونه می‌توانید مشخص کنید که متن در صورت overflow کوچک شود در یک ارائه PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.Normal);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Info" color="info" %}}
وقتی از گزینه **Shrink text on overflow** استفاده شود، تنظیم فقط زمانی اعمال می‌شود که متن برای جعبه‌اش بیش از حد طولانی شود. 
{{% /alert %}}

## **Wrap Text**

اگر می‌خواهید متن داخل یک شکل وقتی از حاشیه عرض شکل عبور کرد، در همان شکل به‌صورت خودکار بسته شود، باید از پارامتر **Wrap text in shape** استفاده کنید. برای تعیین این تنظیم، باید متد [setWrapText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/TextFrameFormat#setWrapText) را از کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/TextFrameFormat) با مقدار `true` فراخوانی کنید.

این کد JavaScript نشان می‌دهد چگونه می‌توانید تنظیم Wrap Text را در یک ارائه PowerPoint به کار ببندید:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setWrapText(aspose.slides.NullableBool.True);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Note" color="warning" %}} 
اگر متد `setWrapText` را برای یک شکل با مقدار `False` فراخوانی کنید، وقتی متن داخل شکل از عرض شکل طولانی‌تر شود، متن در یک خط به بیرون شکل ادامه می‌یابد. 
{{% /alert %}}

## **FAQ**

**آیا حاشیه‌های داخلی فریم متن بر AutoFit تأثیر می‌گذارند؟**

بله. Padding (حاشیه‌های داخلی) مساحت قابل استفاده برای متن را کاهش می‌دهد، بنابراین AutoFit زودتر فعال می‌شود—اندازه فونت را کاهش یا شکل را زودتر تغییر اندازه می‌دهد. قبل از تنظیم AutoFit حاشیه‌ها را بررسی و تنظیم کنید.

**AutoFit چگونه با شکست خطوط دستی و نرم تعامل می‌کند؟**

شکست‌های اجباری در مکان خود باقی می‌مانند و AutoFit اندازه فونت و فاصله‌ها را اطراف آن‌ها تنظیم می‌کند. حذف شکست‌های غیرضروری معمولاً نیاز AutoFit برای کوچک‌سازی متن را کاهش می‌دهد.

**آیا تغییر فونت تم یا اعمال جایگزینی فونت نتایج AutoFit را تحت تأثیر قرار می‌دهد؟**

بله. جایگزینی به فونتی با معیارهای گلیف متفاوت عرض/ارتفاع متن را تغییر می‌دهد و می‌تواند اندازه نهایی فونت و بسته‌بندی خطوط را تحت تأثیر قرار دهد. پس از هر تغییر یا جایگزینی فونت، اسلایدها را دوباره بررسی کنید.