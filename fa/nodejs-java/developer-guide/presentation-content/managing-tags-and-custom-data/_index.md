---
title: "مدیریت برچسب‌ها و داده‌های سفارشی در ارائه‌ها با استفاده از جاوااسکریپت"
linktitle: "برچسب‌ها و داده‌های سفارشی"
type: docs
weight: 300
url: /fa/nodejs-java/managing-tags-and-custom-data/
keywords:
- "ویژگی‌های سند"
- "برچسب"
- "داده سفارشی"
- "XML سفارشی"
- "بخش XML سفارشی"
- "متادیتای XML"
- ItemId
- "افزودن برچسب"
- "مقادیر جفت"
- PowerPoint
- "ارائه"
- Node.js
- JavaScript
- Aspose.Slides
description: "چگونه برچسب‌ها و داده‌های XML سفارشی را در ارائه‌های PowerPoint با Aspose.Slides برای Node.js از طریق Java مدیریت کنید، از جمله افزودن، خواندن، به‌روزرسانی، ممیزی و حذف بخش‌های XML سفارشی."
---
## **نمای کلی**

این مقاله توضیح می‌دهد که Aspose.Slides چگونه با برچسب‌ها و داده‌های سفارشی در ارائه‌های PowerPoint کار می‌کند. داده‌های خاص یک ارائه می‌توانند به صورت برچسب یا بخش‌های XML سفارشی ذخیره شوند. برچسب‌ها جفت‌های کلید‑مقدار رشته‌ای ساده‌اند، در حالی که بخش‌های XML سفارشی می‌توانند متادیتای ساختاری و payloadهای XML مخصوص برنامه را ذخیره کنند.

Aspose.Slides APIهایی برای افزودن، خواندن، به‑روز کردن، ممیزی و حذف بخش‌های XML سفارشی در سطوح ارائه، اسلاید و شکل فراهم می‌کند. بخش‌های XML سفارشی برای یکپارچه‌سازی‌هایی که اطلاعاتی مانند شناسه‌های مدیریت سند، وضعیت گردش کار، متادیتای انطباق، داده‌های اتصال به الگو یا سایر داده‌های ساختاری برنامه را داخل یک ارائه ذخیره می‌نمایند، مفید هستند.

## **ذخیره‌سازی داده در فایل‌های ارائه**

فایل‌های PPTX — فایل‌هایی با پسوند `.pptx` — در قالب PresentationML ذخیره می‌شوند که بخشی از مشخصات Office Open XML است. Office Open XML ساختار بسته و روابط مورد استفاده برای ذخیره محتوای ارائه و داده‌های مرتبط را تعریف می‌کند.

یک ارائه شامل چندین بخش است که با روابط به یکدیگر متصل می‌شوند. به عنوان مثال، یک بخش اسلاید شامل محتوای یک اسلاید واحد است و می‌تواند روابط صریحی به سایر بخش‌ها داشته باشد که توسط ISO/IEC 29500 تعریف شده‌اند.

داده‌های سفارشی می‌توانند به صورت برچسب ([TagCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tagcollection/)) یا بخش‌های XML سفارشی ([CustomXmlPartCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/customxmlpartcollection/)) ذخیره شوند. هر دو از طریق کلاس [`CustomData`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/customdata/) در دسترس هستند.

{{% alert color="primary" %}}
برچسب‌ها جفت‌های کلید‑مقدار رشته‌ای ساده را ذخیره می‌کنند. بخش‌های XML سفارشی داده‌های XML ساختاری را ذخیره می‌کنند و می‌توانند با یک ارائه، اسلاید یا شکل مرتبط شوند.
{{% /alert %}}

## **کار با بخش‌های XML سفارشی**

متد `getCustomXmlParts()` کلاس [`CustomData`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/customdata/) مجموعهٔ بخش‌های XML سفارشی مرتبط با یک شیء خاص ارائه را باز می‌گرداند. برای مثال:

- `presentation.getCustomData().getCustomXmlParts()` شامل بخش‌های XML سفارشی مرتبط با خود ارائه است.
- `slide.getCustomData().getCustomXmlParts()` شامل بخش‌های XML سفارشی مرتبط با یک اسلاید خاص است.
- `shape.getCustomData().getCustomXmlParts()` شامل بخش‌های XML سفارشی مرتبط با یک شکل خاص است.

زمانی که نیاز به بررسی تمام بخش‌های XML سفارشی موجود در ارائه دارید، از [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) استفاده کنید.

### **افزودن یک بخش XML سفارشی به یک ارائه**

از متد `add` کلاس [`CustomXmlPartCollection`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/customxmlpartcollection/) برای افزودن داده XML به مجموعهٔ بخش‌های XML سفارشی استفاده کنید. XML باید معتبر و غیر خالی باشد.

مثال زیر متادیتای ساختاری را به مجموعهٔ داده سفارشی سطح ارائه اضافه می‌کند:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const customXmlContent =
    '<?xml version="1.0" encoding="UTF-8"?>' +
    '<metadata xmlns="urn:example:metadata">' +
        '<documentId>DOC-1001</documentId>' +
        '<workflowState>Draft</workflowState>' +
    '</metadata>';

const presentation = new aspose.slides.Presentation();
try {
    const customXmlPart = presentation.getCustomData().getCustomXmlParts().add(customXmlContent);

    // add به‌صورت خودکار یک شناسه اختصاص می‌دهد. یک UUID مشخص فقط زمانی تنظیم کنید که نیاز باشد.
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("presentation_with_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

متد `add` می‌تواند XML را به صورت آرایهٔ بایت نیز بپذیرد که هنگامیکه محتوای XML قبلاً به شکل باینری موجود باشد مفید است.

### **افزودن یک بخش XML سفارشی به یک اسلاید یا شکل**

داده‌های XML سفارشی می‌توانند به یک اسلاید یا شکل خاص نسبت داده شوند نه کل ارائه. این کار زمانی مفید است که متادیتا تنها به یک شیء مرتبط باشد، مانند کلید الگو، شناسهٔ رکورد خارجی یا اطلاعات اتصال.

مثال زیر یک بخش XML سفارشی را به یک اسلاید و دیگری به یک شکل اضافه می‌کند:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getCustomData().getCustomXmlParts().add(
        '<slideMetadata xmlns="urn:example:slides">' +
            '<templateKey>TitleSlide</templateKey>' +
        '</slideMetadata>');

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 250, 80);

    shape.getTextFrame().setText("Customer data");
    shape.getCustomData().getCustomXmlParts().add(
        '<shapeMetadata xmlns="urn:example:shapes">' +
            '<recordId>CRM-4281</recordId>' +
        '</shapeMetadata>');

    presentation.save("object_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

سطحی که بخش در آن افزوده می‌شود تعیین می‌کند کدام مجموعهٔ `getCustomData().getCustomXmlParts()` شیء، رابطهٔ آن را شامل می‌شود. داده‌های سطح ارائه برای متادیتای سراسری سند مناسب‌اند، داده‌های سطح اسلاید برای اطلاعاتی که مخصوص یک اسلاید است و داده‌های سطح شکل برای متادیتای مرتبط با یک شکل منفرد.

### **فهرست و ممیزی تمام بخش‌های XML سفارشی**

از [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) برای بازیابی تمام بخش‌های XML سفارشی یک ارائه استفاده کنید. هر شیء [`CustomXmlPart`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/customxmlpart/) شناسه، محتوای XML و اسکیماهای فضای‌نام مرتبط را افشا می‌کند.

مثال زیر تمام بخش‌های XML سفارشی و اسکیماهای فضای‌نامشان را فهرست می‌کند:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getAllCustomXmlParts();

    for (let partIndex = 0; partIndex < customXmlParts.length; partIndex++) {
        const customXmlPart = customXmlParts[partIndex];

        console.log("ItemId: " + customXmlPart.getItemId());
        console.log("XML:");
        console.log(customXmlPart.getXmlAsString());

        const namespaceSchemas = customXmlPart.getNamespaceSchemas();
        for (let schemaIndex = 0; schemaIndex < namespaceSchemas.length; schemaIndex++) {
            console.log("Namespace schema: " + namespaceSchemas[schemaIndex]);
        }

        console.log();
    }
} finally {
    presentation.dispose();
}
```

متد [`CustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/customxmlpart/) اسکیماهای XML مرتبط با بخش XML سفارشی را برمی‌گرداند. این اطلاعات می‌تواند هنگام ممیزی ارائه‌هایی که XML تولید شده توسط سیستم‌های خارجی را دارند، مفید باشد.

### **خواندن و به‌روزرسانی محتوای XML و ItemId**

از `getXmlAsString()` و `setXmlAsString()` موجود در [`CustomXmlPart`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/customxmlpart/) برای کار با XML به صورت رشتهٔ UTF‑8 استفاده کنید، یا از `getXmlData()` و `setXmlData()` برای کار با بایت‌های خام XML.

متد `getItemId()` شناسهٔ UUID را که بخش XML سفارشی را در سند Office Open XML شناسایی می‌کند برمی‌گرداند. هنگامیکه یکپارچه‌سازی نیاز به شناسهٔ جدید دارد از `setItemId()` استفاده کنید.

مثال زیر محتوای XML و شناسه را به‌روزرسانی می‌کند:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlPart = presentation.getAllCustomXmlParts()[0];

    // XML فعلی را به‌عنوان متن می‌خواند.
    const currentXmlContent = customXmlPart.getXmlAsString();
    console.log(currentXmlContent);

    // XML را به‌عنوان رشته UTF-8 به‌روزرسانی می‌کند.
    customXmlPart.setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' +
            '<documentId>DOC-1001</documentId>' +
            '<workflowState>Approved</workflowState>' +
        '</metadata>');

    // getXmlData همان محتوای XML را به‌صورت بایت‌های خام ارائه می‌دهد.
    const customXmlData = customXmlPart.getXmlData();
    console.log(Buffer.from(customXmlData).toString("utf8"));

    // شناسه را زمانی که یکپارچه‌سازی نیاز داشته باشد جایگزین کنید.
    const itemId = java.callStaticMethodSync("java.util.UUID", "randomUUID");
    customXmlPart.setItemId(itemId);

    presentation.save("updated_custom_xml.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

هنگام فراخوانی `setXmlAsString` یا `setXmlData`، XML معتبر و غیر خالی فراهم کنید. بسته به اینکه برنامه عمدتاً با رشته‌ها یا داده‌های بایتی کار می‌کند، یکی از این دو روش را انتخاب کنید.

### **حذف یک بخش XML سفارشی**

Aspose.Slides روش‌های متعددی برای حذف داده‌های XML سفارشی ارائه می‌دهد:

- [`CustomXmlPart.remove`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/customxmlpart/) بخش XML سفارشی را از ارائه حذف می‌کند.
- [`CustomXmlPartCollection.remove`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/customxmlpartcollection/) یک بخش خاص را از مجموعهٔ بخش‌های XML سفارشی حذف می‌کند.
- [`CustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/customxmlpartcollection/) بخش را در شاخص مشخصی از مجموعه حذف می‌کند.
- [`CustomXmlPartCollection.clear`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/customxmlpartcollection/) تمام بخش‌ها را از یک مجموعه خاص حذف می‌کند.

مثال زیر یک بخش XML سفارشی سطح ارائه را بر اساس مرجع حذف می‌کند:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getCustomData().getCustomXmlParts();

    if (customXmlParts.size() > 0) {
        const customXmlPart = customXmlParts.get_Item(0);
        customXmlParts.remove(customXmlPart);
    }

    presentation.save("custom_xml_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

اگر قبلاً یک `CustomXmlPart` دارید و می‌خواهید آن بخش را مستقیماً از ارائه حذف کنید (نه از یک مجموعهٔ خاص)، `customXmlPart.remove()` را فراخوانی کنید.

همچنین می‌توانید یک آیتم را بر اساس شاخص حذف کنید:

```javascript
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **پاک‌سازی تمام بخش‌های XML سفارشی از یک مجموعه**

از `clear` زمانی استفاده کنید که تمام بخش‌های XML سفارشی مرتبط با یک شیءٔ خاص ارائه باید حذف شوند.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear();

    presentation.save("slide_custom_xml_cleared.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`clear` فقط بر روی مجموعهٔ انتخاب‌شده اثر می‌گذارد. برای مثال، پاک‌سازی مجموعهٔ یک اسلاید، مجموعهٔ سطح ارائه یا سطح شکل را پاک نمی‌کند.

برای حذف هر بخش XML سفارشی در ارائه، بر روی `getAllCustomXmlParts()` پیمایش کنید و هر بخش را حذف نمایید:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const customXmlParts = presentation.getAllCustomXmlParts();

    for (let partIndex = 0; partIndex < customXmlParts.length; partIndex++) {
        customXmlParts[partIndex].remove();
    }

    presentation.save("all_custom_xml_removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **مدیریت بخش‌های XML سفارشی پیوست‌شده یا مشترک**

در یک ارائه Office Open XML، یک بخش XML سفارشی می‌تواند از بیش از یک شیء ارائه ارجاع شود. به عنوان مثال، یک فایل موجود می‌تواند روابطی از چندین اسلاید یا شکل به یک بخش XML سفارشی زیرین داشته باشد.

یک بخش مشترک باید به عنوان یک شیء داده با چندین ارجاع در نظر گرفته شود:

- به‌روزرسانی آن با `setXmlAsString`، `setXmlData` یا `setItemId` بخش XML سفارشی زیرین را تغییر می‌دهد، بنابراین تغییر در همهٔ مکان‌هایی که آن بخش ارجاع شده اعمال می‌شود.
- `getItemId()` می‌تواند برای شناسایی همان بخش XML سفارشی هنگام ممیزی مجموعه‌های سطح شیء استفاده شود.
- حذف یک بخش از یک مجموعهٔ خاص `getCustomXmlParts()` فقط آن را از همان مجموعه حذف می‌کند. برای حذف بخش از کل ارائه از `CustomXmlPart.remove()` استفاده کنید.
- قبل از حذف یا جایگزین کردن یک بخش مشترک، مجموعه‌های سطح شیء را بررسی کنید تا تعیین کنید آیا اسلایدها یا اشکال دیگر هنوز به آن ارجاع دارند یا خیر.

بارگذاری‌های `add` یک بخش XML سفارشی جدید از محتوای XML می‌سازند؛ آن‌ها یک `CustomXmlPart` موجود را نمی‌پذیرند. بنابراین، روابط مشترک بیشتر در زمان بارگذاری ارائه‌هایی که از پیش این روابط را دارند مشاهده می‌شود.

مثال زیر مجموعه‌های سطح ارائه، اسلاید و شکل را بر اساس `ItemId` ممیزی می‌کند و بخش‌های ارجاع‌شده از بیش از یک مکان را گزارش می‌دهد:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const referencesByItemId = new Map();

    const registerCustomXmlParts = (ownerName, customXmlParts) => {
        for (let partIndex = 0; partIndex < customXmlParts.size(); partIndex++) {
            const customXmlPart = customXmlParts.get_Item(partIndex);
            const itemId = customXmlPart.getItemId().toString();

            if (!referencesByItemId.has(itemId)) {
                referencesByItemId.set(itemId, []);
            }

            referencesByItemId.get(itemId).push(ownerName);
        }
    };

    registerCustomXmlParts("Presentation", presentation.getCustomData().getCustomXmlParts());

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);

        registerCustomXmlParts("Slide " + (slideIndex + 1), slide.getCustomData().getCustomXmlParts());

        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);

            registerCustomXmlParts("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.getCustomData().getCustomXmlParts());
        }
    }

    for (const [itemId, owners] of referencesByItemId) {
        if (owners.length > 1) {
            console.log("Shared custom XML part: " + itemId);

            for (const ownerName of owners) {
                console.log("  Referenced by: " + ownerName);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

این نوع ممیزی پیش از تغییر یا حذف داده‌های XML سفارشی در ارائه‌های تولید شده توسط سیستم‌های خارجی مفید است، زیرا ممکن است همان بخش متادیتا در بیش از یک رابطه شرکت داشته باشد.

## **دریافت مقدار برچسب‌ها**

در اسلایدها، یک برچسب معادل متد `DocumentProperties.getKeywords()` است. این کد نمونه نشان می‌دهد چگونه مقدار یک برچسب را با Aspose.Slides برای Node.js via Java از [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) دریافت می‌کنید:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **افزودن برچسب به ارائه‌ها**

Aspose.Slides به شما امکان می‌دهد برچسب‌ها را به ارائه‌ها اضافه کنید. یک برچسب معمولاً شامل دو مورد است:

- نام یک ویژگی سفارشی، برای مثال `MyTag`؛
- مقدار ویژگی سفارشی، برای مثال `My Tag Value`.

اگر نیاز به طبقه‌بندی ارائه‌ها بر اساس یک قانون یا ویژگی خاص دارید، می‌توانید برای آن منظور برچسب اضافه کنید. به عنوان مثال، اگر می‌خواهید ارائه‌های کشورهای آمریکای شمالی را دسته‌بندی کنید، می‌توانید یک برچسب «NorthAmerican» ایجاد کنید و کشور مرتبط را به‌عنوان مقدار آن تنظیم کنید.

این کد نمونه نشان می‌دهد چگونه با Aspose.Slides برای Node.js via Java یک برچسب به یک [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) اضافه کنید:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const tags = presentation.getCustomData().getTags();
    tags.set_Item("MyTag", "My Tag Value");
} finally {
    presentation.dispose();
}
```

برچسب‌ها می‌توانند برای یک [Slide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slide/) نیز تنظیم شوند:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

یا برای یک [Shape](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/autoshape/) فردی:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 50);

    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

### **محدودیت‌ها**

برچسب‌های اضافه‌شده از طریق مجموعهٔ `getCustomData().getTags()` تنها در فایل PowerPoint ذخیره می‌شوند. آن‌ها **به** ساختار برچسب PDF هنگام صادرات ارائه به PDF منتقل نمی‌شوند. به همین دلیل، یک شناسهٔ سفارشی که به‌عنوان برچسب اختصاص داده شده است، نمی‌تواند از PDF برچسب‌دار بازیابی شود.

**راه‌حل**: می‌توانید یک شناسهٔ سفارشی را در **متن جایگزین** شیء (مثلاً `shape.setAlternativeText("MyId")`) ذخیره کنید. پس از صادرات به PDF، متن جایگزین ممکن است در ساختار برچسب PDF ظاهر شود.

## **سؤالات متداول**

**آیا می‌توانم تمام برچسب‌ها را از یک ارائه، اسلاید یا شکل در یک عملیات حذف کنم؟**

بله. [مجموعهٔ برچسب‌ها](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tagcollection/) از عملیات [clear](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tagcollection/) پشتیبانی می‌کند که تمام جفت‌های کلید‑مقدار را یک‌باره حذف می‌نماید.

**چگونه می‌توانم یک برچسب واحد را بر اساس نام آن بدون پیمایش تمام مجموعه حذف کنم؟**

از `remove(name)` بر روی [مجموعهٔ برچسب‌ها](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tagcollection/) استفاده کنید تا برچسب را بر اساس کلیدش حذف کنید.

**چگونه می‌توانم فهرست کامل نام‌های برچسب‌ها را برای تحلیل یا فیلتر کردن دریافت کنم؟**

از `getNamesOfTags()` بر روی [مجموعهٔ برچسب‌ها](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/tagcollection/) استفاده کنید؛ این متد آرایه‌ای از تمام نام‌های برچسب‌ها را برمی‌گرداند.

**چگونه می‌توانم تمام بخش‌های XML سفارشی را regardless از جایی که ذخیره شده‌اند پیدا کنم؟**

از [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) برای بازیابی تمام بخش‌های XML سفارشی در ارائه استفاده کنید.

**آیا باید برای به‌روزرسانی یک بخش XML سفارشی از `getXmlAsString`/`setXmlAsString` یا `getXmlData`/`setXmlData` استفاده کنم؟**

وقتی برنامه با متن XML UTF‑8 کار می‌کند، `getXmlAsString` و `setXmlAsString` را به‌کار ببرید. وقتی XML قبلاً به شکل آرایهٔ بایت موجود است یا پردازش باینری راحت‌تر است، از `getXmlData` و `setXmlData` استفاده کنید. هر دو نمایانگر محتوای XML یک بخش XML سفارشی یکسان هستند.