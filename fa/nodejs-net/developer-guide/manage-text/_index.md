---
title: مدیریت متن ارائه در Node.js از طریق .NET
linktitle: مدیریت متن
type: docs
weight: 50
url: /fa/nodejs-net/manage-text/
keywords:
- متن
- جعبه متن
- افزودن متن
- تغییر متن
- قالب‌بندی متن
- اندازه فونت
- متن بولد
- فریم متن
- پاراگراف
- بخش
- پاورپوینت
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "یک جعبه متن را به یک اسلاید اضافه کنید، سپس متن، اندازهٔ فونت و وضعیت بولد آن را در JavaScript با Aspose.Slides برای Node.js از طریق .NET تغییر دهید."
---
## **نمای کلی**

در Aspose.Slides، متن روی اسلاید به یک شکل تعلق دارد. یک AutoShape، مانند یک مستطیل، یک TextFrame دارد؛ TextFrame حاوی پاراگراف‌ها است و هر پاراگراف شامل Portion‌هایی است که ران‌های متنی با فرمت یکسان هستند. شما متن را از طریق TextFrame و فونت را از طریق فرمت Portion تغییر می‌دهید.

این مقاله یک TextBox به اسلاید اضافه می‌کند و ارائه را ذخیره می‌نماید. سپس فایل ذخیره شده را باز کرده و متن، اندازهٔ فونت و حالت Bold TextBox را تغییر می‌دهد.

مثالات نیاز به پروژه‌ای دارند که همان‌طور که در [نصب](/slides/fa/nodejs-net/installation/) توضیح داده شده است تنظیم شده باشد. هر مثال را به صورت یک فایل `.js` در پوشهٔ پروژه ذخیره کنید و از همان پوشه با `node` اجرا کنید.

{{% alert color="info" title="Note" %}}
Aspose.Slides برای Node.js از طریق .NET مرجع API خاص خود را ندارد. این کتابخانه API Aspose.Slides برای .NET را با نام‌های camelCase بازتاب می‌دهد، بنابراین پیوندهای API در این مقاله به کلاس‌ها و اعضای متناظر در [مستندات API Aspose.Slides برای .NET](https://reference.aspose.com/slides/fa/net/) ارجاع می‌دهند.
{{% /alert %}}

## **اضافه کردن جعبه متن**

برای اضافه کردن یک TextBox، یک AutoShape را به اسلاید با روش [addAutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/shapecollection/addautoshape/) اضافه کنید و با روش [addTextFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/autoshape/addtextframe/) متن موردنظر را به آن بدهید. مثال زیر یک مستطیل را به اولین اسلاید یک ارائهٔ جدید اضافه می‌کند و ارائه را به عنوان `text-box.pptx` ذخیره می‌نماید:

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // موقعیت (x, y) و اندازه (عرض، ارتفاع) بر حسب نقطه هستند.
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80);
    textBox.addTextFrame("Quarterly report");

    presentation.save("text-box.pptx", SaveFormat.Pptx);
    console.log("Saved text-box.pptx");
} finally {
    presentation.dispose();
}
```

اسلاید موجود در `text-box.pptx` شامل یک مستطیل به عرض 500 نقطه و ارتفاع 80 نقطه است که متن «Quarterly report» را با فونت و اندازهٔ پیش‌فرض نشان می‌دهد. مثال بعدی این TextBox را تغییر می‌دهد.

## **تغییر متن و قالب‌بندی آن**

مثال زیر `text-box.pptx` را که مثال قبلی ایجاد کرده بود باز می‌کند و اولین Shape را در اولین اسلاید دریافت می‌نماید. Shapeهایی مانند تصویر و جدول TextFrame ندارند، بنابراین مثال قبل از استفاده از [textFrame](https://reference.aspose.com/slides/fa/net/aspose.slides/autoshape/textframe/) بررسی می‌کند که Shape موردنظر یک [AutoShape](https://reference.aspose.com/slides/fa/net/aspose.slides/autoshape/) است یا نه. سپس کارهای زیر را انجام می‌دهد:

1. متن را از طریق ویژگی [text](https://reference.aspose.com/slides/fa/net/aspose.slides/textframe/text/) در TextFrame جایگزین می‌کند. پس از این، TextFrame شامل یک پاراگراف با یک Portion می‌شود.
2. آن Portion را از مجموعه‌های [paragraphs](https://reference.aspose.com/slides/fa/net/aspose.slides/textframe/paragraphs/) و [portions](https://reference.aspose.com/slides/fa/net/aspose.slides/paragraph/portions/) می‌گیرد و [portionFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/portion/portionformat/) آن را می‌خواند.
3. مقدار [fontHeight](https://reference.aspose.com/slides/fa/net/aspose.slides/baseportionformat/fontheight/) (اندازهٔ فونت به نقطه) و [fontBold](https://reference.aspose.com/slides/fa/net/aspose.slides/baseportionformat/fontbold/) (که مقدار یک [NullableBool](https://reference.aspose.com/slides/fa/net/aspose.slides/nullablebool/) می‌گیرد) را تنظیم می‌کند.

```javascript
const { Presentation, AutoShape, NullableBool, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("text-box.pptx");
try {
    const shape = presentation.slides.get(0).shapes.get(0);
    if (shape instanceof AutoShape) {
        const textFrame = shape.textFrame;
        textFrame.text = "Quarterly report: third quarter";

        const portionFormat = textFrame.paragraphs.get(0).portions.get(0).portionFormat;
        portionFormat.fontHeight = 32;
        portionFormat.fontBold = NullableBool.True;

        presentation.save("text-box-updated.pptx", SaveFormat.Pptx);
        console.log("Saved text-box-updated.pptx");
    } else {
        console.log("The first shape on the first slide is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

در `text-box-updated.pptx`، TextBox متن «Quarterly report: third quarter» را با وزن Bold و اندازه 32 نقطه نمایش می‌دهد. از آنجا که متن جدید یک Portion واحد است، دو ویژگی قالب‌بندی بر تمام آن اعمال می‌شود. بدون لایسنس، هر ذخیره‌سازی یک watermark ارزیابی اضافه می‌کند. از آنجا که `text-box.pptx` هم در حالت ارزیابی ذخیره شده بود، `text-box-updated.pptx` دو watermark دارد؛ برای جزئیات بیشتر به [Evaluate Aspose.Slides](/slides/fa/nodejs-net/evaluate-aspose-slides/) مراجعه کنید.

## **سوالات متداول**

**چرا `fontBold` یک مقدار `NullableBool` می‌گیرد به‌جای `true` یا `false`؟**

یک Portion می‌تواند یک ویژگی را تعریف نشده بگذارد و آن را از پاراگراف، Shape یا طرح بندی و مستر اسلاید به ارث ببرد. `NullableBool.NotDefined` به معنی «ارث‌بری» است، در حالی که `NullableBool.True` و `NullableBool.False` مقدار ارث‌برده را بازنویسی می‌کنند. اختصاص `true` یا `false` باعث خطا می‌شود. به همین دلیل، `fontHeight` وقتی Portion اندازهٔ فونت خود را به ارث می‌برد، مقدار `NaN` برمی‌گرداند.

**چگونه رنگ متن را تغییر دهم؟**

پر کردن PortionFormat را تنظیم کنید: `FillType.Solid` را به `portionFormat.fillFormat.fillType` اختصاص دهید، سپس یک رنگ مانند `"#FF0000"` را به `portionFormat.fillFormat.solidFillColor.color` اختصاص دهید. `FillType` را به اسامی‌ای که از بسته وارد می‌کنید اضافه کنید.

**چگونه فقط بخشی از متن را قالب‌بندی کنم؟**

قالب‌بندی به Portionها تعلق دارد، بنابراین آن بخش از متن را در یک Portion جداگانه قرار دهید. Portion را با `Portion.CreatePortionFromText` ایجاد کنید، آن را با متد `add` در مجموعهٔ `portions` پاراگراف اضافه کنید و سپس `portionFormat` جدید را تنظیم کنید. `Portion` را به اسامی‌ای که از بسته وارد می‌کنید اضافه کنید.

**چرا خواندن متن پیغام «... text has been truncated due to evaluation version limitation» را برمی‌گرداند؟**

بدون لایسنس، Aspose.Slides فقط پنج کاراکتر اول هر متن طولانی را که می‌خوانید (مانند `textFrame.text`) برمی‌گرداند و پس از آن این اعلان را می‌چسباند. متنی که می‌نویسید به صورت کامل ذخیره می‌شود. برای خواندن متن کامل، همان‌طور که در [Licensing](/slides/fa/nodejs-net/licensing/) توضیح داده شده است، یک لایسنس اعمال کنید.