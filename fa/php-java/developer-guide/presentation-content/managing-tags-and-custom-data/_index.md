---
title: مدیریت برچسب‌ها و داده‌های سفارشی در ارائه‌ها با استفاده از PHP
linktitle: برچسب‌ها و داده‌های سفارشی
type: docs
weight: 300
url: /fa/php-java/managing-tags-and-custom-data/
keywords:
- خواص سند
- برچسب
- داده سفارشی
- XML سفارشی
- بخش XML سفارشی
- متادیتای XML
- ItemId
- افزودن برچسب
- مقادیر جفت
- PowerPoint
- ارائه
- PHP
- Aspose.Slides
description: "یاد بگیرید چگونه برچسب‌ها و داده‌های XML سفارشی را در ارائه‌های PowerPoint با Aspose.Slides برای PHP از طریق Java مدیریت کنید، شامل افزودن، خواندن، به‌روزرسانی، بررسی و حذف بخش‌های XML سفارشی."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که Aspose.Slides چگونه با برچسب‌ها و داده‌های سفارشی در ارائه‌های PowerPoint کار می‌کند. داده‌های مخصوص یک ارائه می‌تواند به‌صورت برچسب یا بخش‌های XML سفارشی ذخیره شود. برچسب‌ها جفت‌های کلید‑مقدار رشته‌ای ساده هستند، در حالی که بخش‌های XML سفارشی می‌توانند متادیتای ساختاری و محموله‌های XML مخصوص برنامه را نگهداری کنند.

Aspose.Slides APIهایی برای افزودن، خواندن، به‌روزرسانی، بررسی و حذف بخش‌های XML سفارشی در سطوح ارائه، اسلاید و شکل فراهم می‌کند. بخش‌های XML سفارشی برای ادغام‌هایی که اطلاعاتی مانند شناسه‌های مدیریت سند، وضعیت جریان کار، متادیتای انطباق، داده‌های بایندینگ قالب یا سایر داده‌های ساختاری برنامه‌ای را داخل یک ارائه ذخیره می‌کنند، مفید هستند.

## **ذخیره‌سازی داده در فایل‌های ارائه**

فایل‌های PPTX—فایل‌هایی با پسوند `.pptx`—در قالب PresentationML ذخیره می‌شوند که بخشی از مشخصات Office Open XML است. Office Open XML ساختار بسته و روابط استفاده شده برای ذخیره محتوای ارائه و داده‌های مرتبط را تعریف می‌کند.

یک ارائه شامل چندین بخش متصل به‌وسیله روابط است. برای مثال، یک بخش اسلاید شامل محتوای یک اسلاید واحد است و می‌تواند روابط صریحی به بخش‌های دیگر داشته باشد که توسط ISO/IEC 29500 تعریف می‌شود.

داده‌های سفارشی می‌توانند به‌صورت برچسب‌ها ([TagCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tagcollection/)) یا بخش‌های XML سفارشی ([CustomXmlPartCollection](https://reference.aspose.com/slides/fa/php-java/aspose.slides/customxmlpartcollection/)) ذخیره شوند. هر دو از طریق کلاس [`CustomData`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/customdata/) در دسترس هستند.

{{% alert color="primary" %}}
برچسب‌ها جفت‌های کلید‑مقدار رشته‌ای ساده را ذخیره می‌کنند. بخش‌های XML سفارشی داده‌های XML ساختاری را ذخیره می‌کنند و می‌توانند به یک ارائه، اسلاید یا شکل مرتبط شوند.
{{% /alert %}}

## **کار با بخش‌های XML سفارشی**

متد [`CustomData::getCustomXmlParts()`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/customdata/#getCustomXmlParts) مجموعهٔ بخش‌های XML سفارشی مرتبط با یک شیء ارائه خاص را برمی‌گرداند. برای مثال:

- `$presentation->getCustomData()->getCustomXmlParts()` شامل بخش‌های XML سفارشی مرتبط با خود ارائه است.
- `$slide->getCustomData()->getCustomXmlParts()` شامل بخش‌های XML سفارشی مرتبط با یک اسلاید مشخص است.
- `$shape->getCustomData()->getCustomXmlParts()` شامل بخش‌های XML سفارشی مرتبط با یک شکل خاص است.

از [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getAllCustomXmlParts) زمانی که نیاز به بررسی تمام بخش‌های XML سفارشی در ارائه دارید، صرف‌نظر از مکان ارتباط آن‌ها، استفاده کنید.

### **افزودن یک بخش XML سفارشی به ارائه**

از [`CustomXmlPartCollection::add`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/customxmlpartcollection/#add) برای افزودن داده XML به یک مجموعهٔ بخش XML سفارشی استفاده کنید. XML باید معتبر و غیرخالی باشد.

مثال زیر متادیتای ساختاری را به مجموعهٔ داده سفارشی سطح ارائه اضافه می‌کند:

```php
$customXmlContent =
    '<?xml version="1.0" encoding="UTF-8"?>' .
    '<metadata xmlns="urn:example:metadata">' .
        '<documentId>DOC-1001</documentId>' .
        '<workflowState>Draft</workflowState>' .
    '</metadata>';

$presentation = new Presentation();
try {
    $customXmlPart = $presentation->getCustomData()->getCustomXmlParts()->add($customXmlContent);

    // add به‌صورت خودکار یک شناسه اختصاص می‌دهد. فقط هنگام نیاز یک UUID مشخص تنظیم کنید.
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("presentation_with_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

متد `add` می‌تواند XML را به‌صورت آرایه بایت یا جریان ورودی نیز بگیرد، که زمانی مفید است که محتوای XML از پیش به‌صورت باینری در دسترس باشد.

### **افزودن یک بخش XML سفارشی به اسلاید یا شکل**

داده‌های XML سفارشی می‌توانند به یک اسلاید یا شکل خاص به‌جای کل ارائه مرتبط شوند. این در زمانی مفید است که متادیتا توصیف‌کنندهٔ فقط یک شیء باشد، مانند کلید قالب، شناسهٔ رکورد خارجی یا اطلاعات بایندینگ.

مثال زیر یک بخش XML سفارشی را به اسلایدی اضافه می‌کند و بخش دیگری را به شکل:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $slide->getCustomData()->getCustomXmlParts()->add(
        '<slideMetadata xmlns="urn:example:slides">' .
            '<templateKey>TitleSlide</templateKey>' .
        '</slideMetadata>'
    );

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 250, 80);

    $shape->getTextFrame()->setText("Customer data");
    $shape->getCustomData()->getCustomXmlParts()->add(
        '<shapeMetadata xmlns="urn:example:shapes">' .
            '<recordId>CRM-4281</recordId>' .
        '</shapeMetadata>'
    );

    $presentation->save("object_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

سطحی که بخش در آن افزوده می‌شود تعیین می‌کند کدام مجموعهٔ `getCustomData()->getCustomXmlParts()` شیء شامل رابطهٔ آن به بخش باشد. دادهٔ سطح ارائه برای متادیتای سراسری سند مناسب است، دادهٔ سطح اسلاید برای اطلاعاتی که به اسلاید خاصی تعلق دارد، و دادهٔ سطح شکل برای متادیتای مربوط به یک شکل منفرد.

### **فهرست و بررسی تمام بخش‌های XML سفارشی**

از [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getAllCustomXmlParts) برای بازیابی تمام بخش‌های XML سفارشی از یک ارائه استفاده کنید. هر [`CustomXmlPart`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/customxmlpart/) شناسه، محتوای XML و طرح‌نامه‌های فضای نام مرتبط با خود را نمایش می‌دهد.

مثال زیر تمام بخش‌های XML سفارشی و طرح‌نامه‌های فضای نام آن‌ها را فهرست می‌کند:

```php
$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getAllCustomXmlParts() as $customXmlPart) {
        echo "ItemId: " . $customXmlPart->getItemId() . PHP_EOL;
        echo "XML:" . PHP_EOL;
        echo $customXmlPart->getXmlAsString() . PHP_EOL;

        foreach ($customXmlPart->getNamespaceSchemas() as $namespaceSchema) {
            echo "Namespace schema: " . $namespaceSchema . PHP_EOL;
        }

        echo PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

متد [`CustomXmlPart::getNamespaceSchemas()`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/customxmlpart/#getNamespaceSchemas) طرح‌نامه‌های XML مرتبط با بخش XML سفارشی را برمی‌گرداند. این اطلاعات می‌تواند هنگام بررسی ارائه‌هایی که XML تولید شده توسط سیستم‌های خارجی را شامل می‌شوند، مفید باشد.

### **خواندن و به‌روزرسانی محتوای XML و ItemId**

از [`CustomXmlPart::getXmlAsString()`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/customxmlpart/#getXmlAsString) و[`setXmlAsString()`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/customxmlpart/#setXmlAsString) برای کار با XML به‌عنوان رشتهٔ UTF‑8، یا از[`getXmlData()`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/customxmlpart/#getXmlData) و[`setXmlData()`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/customxmlpart/#setXmlData) برای کار با بایت‌های خام XML استفاده کنید.

متد [`CustomXmlPart::getItemId()`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/customxmlpart/#getItemId) UUID شناسایی‌کنندهٔ بخش XML سفارشی را در سند Office Open XML برمی‌گرداند. هنگامیکه یک ادغام نیاز به شناسهٔ جدیدی دارد، از[`setItemId()`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/customxmlpart/#setItemId) استفاده کنید.

مثال زیر محتوای XML و شناسه را به‌روزرسانی می‌کند:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $customXmlPart = $presentation->getAllCustomXmlParts()[0];

    // XML فعلی را به‌عنوان متن بخوانید.
    $currentXmlContent = $customXmlPart->getXmlAsString();
    echo $currentXmlContent . PHP_EOL;

    // XML را به‌عنوان رشته UTF-8 به‌روزرسانی کنید.
    $customXmlPart->setXmlAsString(
        '<metadata xmlns="urn:example:metadata">' .
            '<documentId>DOC-1001</documentId>' .
            '<workflowState>Approved</workflowState>' .
        '</metadata>'
    );

    // متد getXmlData همان محتوای XML را به‌صورت بایت‌های خام ارائه می‌دهد.
    $customXmlData = $customXmlPart->getXmlData();

    // در صورت نیاز ادغام، شناسه را جایگزین کنید.
    $UUID = new JavaClass("java.util.UUID");
    $customXmlPart->setItemId($UUID->randomUUID());

    $presentation->save("updated_custom_xml.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

هنگام فراخوانی `setXmlAsString` یا `setXmlData`، XML معتبر و غیرخالی ارائه دهید. بسته به این‌که برنامه اصلیاً با رشته‌ها یا داده‌های بایتی کار می‌کند، از یکی از این دو روش استفاده کنید.

### **حذف یک بخش XML سفارشی**

Aspose.Slides چندین روش برای حذف دادهٔ XML سفارشی فراهم می‌آورد:

- [`CustomXmlPart::remove`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/customxmlpart/#remove) بخش XML سفارشی را از ارائه حذف می‌کند.
- [`CustomXmlPartCollection::remove`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/customxmlpartcollection/#remove) بخش خاصی را از یک مجموعهٔ بخش XML سفارشی حذف می‌کند.
- [`CustomXmlPartCollection::removeAt`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/customxmlpartcollection/#removeAt) بخش را در اندیس مشخص مجموعه حذف می‌کند.
- [`CustomXmlPartCollection::clear`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/customxmlpartcollection/#clear) تمام بخش‌ها را از یک مجموعه خاص حذف می‌کند.

مثال زیر یک بخش XML سفارشی سطح ارائه را با ارجاع حذف می‌کند:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $customXmlParts = $presentation->getCustomData()->getCustomXmlParts();

    if (java_values($customXmlParts->size()) > 0) {
        $customXmlPart = $customXmlParts->get_Item(0);
        $customXmlParts->remove($customXmlPart);
    }

    $presentation->save("custom_xml_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

اگر قبلاً یک `CustomXmlPart` دارید و می‌خواهید آن را از ارائه حذف کنید نه اینکه به مجموعه‌ای خاص ارجاع دهید، `$customXmlPart->remove()` را فراخوانی کنید.

همچنین می‌توانید آیتم را بر اساس اندیس حذف کنید:

```php
$presentation->getCustomData()->getCustomXmlParts()->removeAt(0);
```

### **تخلیه تمام بخش‌های XML سفارشی از یک مجموعه**

از `clear` زمانی استفاده کنید که تمام بخش‌های XML سفارشی مرتبط با یک شیء ارائهٔ مشخص باید حذف شوند.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->getSlides()->get_Item(0)->getCustomData()->getCustomXmlParts()->clear();

    $presentation->save("slide_custom_xml_cleared.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`clear` تنها بر مجموعهٔ انتخاب شده تأثیر می‌گذارد. به‌عنوان مثال، پاک‌سازی مجموعهٔ یک اسلاید، مجموعهٔ سطح ارائه یا سطح شکل را پاک نمی‌کند.

برای حذف هر بخش XML سفارشی در ارائه، با `getAllCustomXmlParts()` پیمایش کنید و هر بخش را حذف کنید:

```php
$presentation = new Presentation("presentation.pptx");
try {
    foreach ($presentation->getAllCustomXmlParts() as $customXmlPart) {
        $customXmlPart->remove();
    }

    $presentation->save("all_custom_xml_removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **مدیریت بخش‌های XML سفارشی پیوند‌دار یا مشترک**

در یک ارائهٔ Office Open XML، همان بخش XML سفارشی می‌تواند از بیش از یک شیء ارائه ارجاع شود. به‌عنوان مثال، یک فایل موجود می‌تواند روابطی از چندین اسلاید یا شکل به همان بخش XML سفارشی زیرساختی داشته باشد.

یک بخش مشترک باید به‌عنوان یک شیء دادهٔ واحد با چندین ارجاع درنظر گرفته شود:

- به‌روزرسانی آن با `setXmlAsString`، `setXmlData` یا `setItemId` بخش زیرساختی را تغییر می‌دهد، بنابراین تغییر در همهٔ مکان‌هایی که آن بخش ارجاع شده اعمال می‌شود.
- `getItemId()` می‌تواند برای شناسایی همان بخش XML سفارشی هنگام بررسی مجموعه‌های سطح شیء استفاده شود.
- حذف یک بخش از یک مجموعهٔ خاص `getCustomXmlParts()` آن را فقط از آن مجموعه حذف می‌کند. برای حذف خود بخش از ارائه از `CustomXmlPart::remove()` استفاده کنید.
- قبل از حذف یا جایگزینی یک بخش مشترک، مجموعه‌های سطح شیء را بررسی کنید تا مطمئن شوید اسلاید یا شکل دیگری هنوز به آن ارجاع دارد.

بارگذاری‌های `add` یک بخش XML سفارشی جدید از محتوای XML ایجاد می‌کنند؛ آن‌ها یک `CustomXmlPart` موجود را نمی‌پذیرند. بنابراین، روابط مشترک عمدتاً هنگام بارگذاری ارائه‌هایی که قبلاً این روابط را دارند، مشاهده می‌شوند.

مثال زیر مجموعه‌های سطح ارائه، اسلاید و شکل را بر اساس `ItemId` بررسی می‌کند و بخش‌های ارجاع شده از بیش از یک مکان را گزارش می‌دهد:

```php
function registerCustomXmlParts($ownerName, $customXmlParts, &$referencesByItemId) {
    $partCount = java_values($customXmlParts->size());

    for ($i = 0; $i < $partCount; $i++) {
        $customXmlPart = $customXmlParts->get_Item($i);
        $itemId = java_values($customXmlPart->getItemId()->toString());

        if (!isset($referencesByItemId[$itemId])) {
            $referencesByItemId[$itemId] = [];
        }

        $referencesByItemId[$itemId][] = $ownerName;
    }
}

$presentation = new Presentation("presentation.pptx");
try {
    $referencesByItemId = [];

    registerCustomXmlParts(
        "Presentation",
        $presentation->getCustomData()->getCustomXmlParts(),
        $referencesByItemId
    );

    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        registerCustomXmlParts(
            "Slide " . ($slideIndex + 1),
            $slide->getCustomData()->getCustomXmlParts(),
            $referencesByItemId
        );

        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            registerCustomXmlParts(
                "Slide " . ($slideIndex + 1) . ", shape " . $shapeIndex,
                $shape->getCustomData()->getCustomXmlParts(),
                $referencesByItemId
            );
        }
    }

    foreach ($referencesByItemId as $itemId => $owners) {
        if (count($owners) > 1) {
            echo "Shared custom XML part: " . $itemId . PHP_EOL;

            foreach ($owners as $ownerName) {
                echo "  Referenced by: " . $ownerName . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

این نوع بررسی پیش از تغییر یا حذف دادهٔ XML سفارشی در ارائه‌های تولید شده توسط سیستم‌های خارجی مفید است، زیرا همان بخش متادیتا ممکن است در بیش از یک رابطه شرکت داشته باشد.

## **دریافت مقادیر برچسب‌ها**

در اسلایدها، یک برچسب معادل متد `DocumentProperties::getKeywords()` است. این کد نمونه نشان می‌دهد که چگونه مقدار یک برچسب را با Aspose.Slides برای PHP via Java برای [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) دریافت کنید:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $keywords = $presentation->getDocumentProperties()->getKeywords();
} finally {
    $presentation->dispose();
}
```

## **افزودن برچسب‌ها به ارائه‌ها**

Aspose.Slides به شما امکان می‌دهد برچسب‌ها را به ارائه‌ها اضافه کنید. یک برچسب معمولاً شامل دو مورد است:

- نام یک ویژگی سفارشی، برای مثال `MyTag`؛
- مقدار ویژگی سفارشی، برای مثال `My Tag Value`.

اگر نیاز به طبقه‌بندی ارائه‌ها بر اساس یک قانون یا ویژگی خاص دارید، می‌توانید برای آن منظور برچسب‌ها را اضافه کنید. برای مثال، اگر می‌خواهید ارائه‌های کشورهای آمریکای شمالی را دسته‌بندی کنید، می‌توانید یک برچسب «North American» ایجاد کنید و کشور مربوطه را به عنوان مقدار آن تنظیم کنید.

این کد نمونه نشان می‌دهد که چگونه یک برچسب به یک [Presentation](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/) با Aspose.Slides برای PHP via Java اضافه کنید:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $tags = $presentation->getCustomData()->getTags();
    $tags->set_Item("MyTag", "My Tag Value");
} finally {
    $presentation->dispose();
}
```

برچسب‌ها می‌توانند برای یک [Slide](https://reference.aspose.com/slides/fa/php-java/aspose.slides/slide/) نیز تنظیم شوند:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
} finally {
    $presentation->dispose();
}
```

یا برای یک [Shape](https://reference.aspose.com/slides/fa/php-java/aspose.slides/autoshape/) منفرد:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
} finally {
    $presentation->dispose();
}
```

### **محدودیت‌ها**

برچسب‌های اضافه‌شده از طریق مجموعه `getCustomData()->getTags()` تنها در فایل PowerPoint ذخیره می‌شوند. آن‌ها **به** ساختار برچسب‌های PDF هنگام خروجی گرفتن به PDF انتقال پیدا نمی‌کنند. بنابراین، یک شناسهٔ سفارشی که به‌عنوان برچسب اختصاص داده شده است، نمی‌تواند از PDF برچسب‌دار استخراج شود.

**راه‌حل**: می‌توانید یک شناسهٔ سفارشی را در **Alt Text** شیء ذخیره کنید (مثلاً `$shape->setAlternativeText("MyId")`). پس از خروجی به PDF، Alt Text ممکن است در ساختار برچسب‌های PDF ظاهر شود.

## **پرسش‌های متداول**

**آیا می‌توانم تمام برچسب‌ها را از یک ارائه، اسلاید یا شکل در یک عملیات حذف کنم؟**

بله. [مجموعه برچسب‌ها](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tagcollection/) عملیات [clear](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tagcollection/#clear) را پشتیبانی می‌کند که تمام جفت‌های کلید‑مقدار را یک‌باره حذف می‌کند.

**چگونه می‌توانم یک برچسب واحد را بر اساس نام آن بدون پیمایش کل مجموعه حذف کنم؟**

از [remove(name)](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tagcollection/#remove) در [مجموعه برچسب‌ها](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tagcollection/) استفاده کنید تا برچسب را بر‑اساس کلید خود حذف کنید.

**چگونه می‌توانم لیست کامل نام‌های برچسب را برای تجزیه و تحلیل یا فیلتر کردن دریافت کنم؟**

از [getNamesOfTags](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tagcollection/#getNamesOfTags) در [مجموعه برچسب‌ها](https://reference.aspose.com/slides/fa/php-java/aspose.slides/tagcollection/) استفاده کنید؛ این متد آرایه‌ای از تمام نام‌های برچسب را برمی‌گرداند.

**چگونه می‌توانم تمام بخش‌های XML سفارشی را بدون توجه به محل ذخیره‌شان پیدا کنم؟**

از [`Presentation::getAllCustomXmlParts()`](https://reference.aspose.com/slides/fa/php-java/aspose.slides/presentation/#getAllCustomXmlParts) برای بازیابی تمام بخش‌های XML سفارشی در ارائه استفاده کنید.

**آیا باید از `getXmlAsString`/`setXmlAsString` یا `getXmlData`/`setXmlData` برای به‌روزرسانی یک بخش XML سفارشی استفاده کنم؟**

هنگامی که برنامه با متن XML UTF‑8 کار می‌کند، از `getXmlAsString` و `setXmlAsString` استفاده کنید. اگر XML از قبل به‌صورت آرایه بایت موجود است یا پردازش باینری برای شما راحت‌تر است، از `getXmlData` و `setXmlData` استفاده کنید. هر دو نمایانگر محتوای XML همان بخش XML سفارشی هستند.