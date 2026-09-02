---
title: "مدیریت برچسب‌ها و داده‌های سفارشی در ارائه‌ها با استفاده از جاوا"
linktitle: "برچسب‌ها و داده‌های سفارشی"
type: docs
weight: 300
url: /fa/java/managing-tags-and-custom-data/
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
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه با Aspose.Slides برای جاوا برچسب‌ها و داده‌های XML سفارسی را در ارائه‌های PowerPoint مدیریت کنید، از جمله افزودن، خواندن، به‌روزرسانی، بازرسی و حذف بخش‌های XML سفارشی."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که Aspose.Slides چگونه با برچسب‌ها و داده‌های سفارشی در ارائه‌های PowerPoint کار می‌کند. داده‌های خاص ارائه می‌توانند به‌صورت برچسب یا بخش‌های XML سفارشی ذخیره شوند. برچسب‌ها جفت‌های کلید‑مقدار رشته‌ای ساده هستند، در حالی که بخش‌های XML سفارشی می‌توانند متادیتای ساختاری و بارهای XML مختص برنامه را ذخیره کنند.

Aspose.Slides APIهایی برای افزودن، خواندن، به‌روزرسانی، بازرسی و حذف بخش‌های XML سفارشی در سطوح ارائه، اسلاید و شکل فراهم می‌کند. بخش‌های XML سفارشی برای ادغامات قابل استفاده هستند که اطلاعاتی مانند شناسه‌های مدیریت سند، وضعیت گردش کار، متادیتای انطباق، داده‌های پیوند قالب یا سایر داده‌های ساختاری برنامه‌ای را داخل یک ارائه نگهداری می‌کنند.

## **ذخیره‌سازی داده‌ها در فایل‌های ارائه**

فایل‌های PPTX — فایل‌هایی با پسوند `.pptx` — در قالب PresentationML ذخیره می‌شوند که بخشی از مشخصات Office Open XML است. Office Open XML ساختار بسته و روابط مورد استفاده برای ذخیره محتوای ارائه و داده‌های مرتبط را تعریف می‌کند.

یک ارائه شامل چندین بخش متصل به‌وسیله روابط است. به‌عنوان مثال، یک بخش اسلاید شامل محتوای یک اسلاید واحد است و می‌تواند روابط صریحی به بخش‌های دیگر داشته باشد که توسط ISO/IEC 29500 تعریف می‌شوند.

داده‌های سفارشی می‌توانند به‌صورت برچسب‌ها ([ITagCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITagCollection)) یا بخش‌های XML سفارشی ([ICustomXmlPartCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ICustomXmlPartCollection)) ذخیره شوند. هر دو از طریق اینترفیس [`ICustomData`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ICustomData/) در دسترس هستند.

{{% alert color="primary" %}}
برچسب‌ها جفت‌های کلید‑مقدار رشته‌ای ساده را ذخیره می‌کنند. بخش‌های XML سفارشی داده‌های XML ساختاری را ذخیره می‌کنند و می‌توانند به یک ارائه، اسلاید یا شکل مرتبط شوند.
{{% /alert %}}

## **کار با بخش‌های XML سفارشی**

متد [`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ICustomData#getCustomXmlParts--) مجموعهٔ بخش‌های XML سفارشی مرتبط با یک شیء خاص ارائه را برمی‌گرداند. به‌عنوان مثال:

- `presentation.getCustomData().getCustomXmlParts()` شامل بخش‌های XML سفارشی مرتبط با خود ارائه است.
- `slide.getCustomData().getCustomXmlParts()` شامل بخش‌های XML سفارشی مرتبط با یک اسلاید خاص است.
- `shape.getCustomData().getCustomXmlParts()` شامل بخش‌های XML سفارشی مرتبط با یک شکل خاص است.

از [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) زمانی استفاده کنید که نیاز به بررسی تمام بخش‌های XML سفارشی در ارائه دارید، بدون در نظر گرفتن محل ارتباط آن‌ها.

### **افزودن یک بخش XML سفارشی به یک ارائه**

از [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) برای افزودن داده‌های XML به مجموعهٔ بخش‌های XML سفارشی استفاده کنید. XML باید معتبر و غیر خالی باشد.

مثال زیر متادیتای ساختاری را به مجموعهٔ داده‌های سفارشی سطح ارائه اضافه می‌کند:

```java
import com.aspose.slides.*;
import java.util.UUID;

String customXmlContent =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
    "<metadata xmlns=\"urn:example:metadata\">" +
        "<documentId>DOC-1001</documentId>" +
        "<workflowState>Draft</workflowState>" +
    "</metadata>";

Presentation presentation = new Presentation();
try {
    ICustomXmlPart customXmlPart = presentation.getCustomData().getCustomXmlParts().add(customXmlContent);

    // متد add به‌صورت خودکار شناسه‌ای اختصاص می‌دهد. فقط در صورت نیاز یک UUID خاص تعیین کنید.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

متد `add` می‌تواند XML را به‌صورت آرایهٔ بایت یا جریان ورودی نیز بپذیرد، که وقتی محتویات XML از پیش به‌صورت باینری موجود باشد مفید است.

### **افزودن یک بخش XML سفارشی به یک اسلاید یا شکل**

داده‌های XML سفارشی می‌توانند به جای کل ارائه، به یک اسلاید یا شکل خاص مرتبط شوند. این کار وقتی مفید است که متادیتا فقط یک شیء را توصیف کند، مانند یک کلید قالب، شناسهٔ رکورد خارجی یا اطلاعات پیوند.

مثال زیر یک بخش XML سفارشی به یک اسلاید و دیگری به یک شکل اضافه می‌کند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getCustomData().getCustomXmlParts().add(
        "<slideMetadata xmlns=\"urn:example:slides\">" +
            "<templateKey>TitleSlide</templateKey>" +
        "</slideMetadata>");

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 250, 80);

    shape.getTextFrame().setText("Customer data");
    shape.getCustomData().getCustomXmlParts().add(
        "<shapeMetadata xmlns=\"urn:example:shapes\">" +
            "<recordId>CRM-4281</recordId>" +
        "</shapeMetadata>");

    presentation.save("object_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

سطحی که بخش در آن افزوده می‌شود تعیین می‌کند کدام مجموعهٔ `getCustomData().getCustomXmlParts()` آن رابطه را دارد. داده‌های سطح ارائه برای متادیتای سراسری سند مناسب هستند، داده‌های سطح اسلاید برای اطلاعات مربوط به یک اسلاید خاص، و داده‌های سطح شکل برای متادیتای مرتبط با یک شکل فردی.

### **فهرست و بازرسی تمام بخش‌های XML سفارشی**

از [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) برای بازیابی تمام بخش‌های XML سفارشی از یک ارائه استفاده کنید. هر [`ICustomXmlPart`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ICustomXmlPart/) شناسه، محتوای XML و فضای‌نام‌های مرتبط را برمی‌گرداند.

مثال زیر تمام بخش‌های XML سفارشی و فضای‌نام‌های آن‌ها را فهرست می‌کند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ICustomXmlPart customXmlPart : presentation.getAllCustomXmlParts()) {
        System.out.println("ItemId: " + customXmlPart.getItemId());
        System.out.println("XML:");
        System.out.println(customXmlPart.getXmlAsString());

        for (String namespaceSchema : customXmlPart.getNamespaceSchemas()) {
            System.out.println("Namespace schema: " + namespaceSchema);
        }

        System.out.println();
    }
} finally {
    presentation.dispose();
}
```

متد [`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) فضای‌نام‌های XML مرتبط با بخش XML سفارشی را برمی‌گرداند. این اطلاعات می‌تواند هنگام بازرسی ارائه‌های حاوی XML تولید شده توسط سیستم‌های خارجی مفید باشد.

### **خواندن و به‌روزرسانی محتوای XML و ItemId**

از [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ICustomXmlPart#getXmlAsString--) و [`setXmlAsString()`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) برای کار با XML به‌صورت رشتهٔ UTF‑8 استفاده کنید، یا از [`getXmlData()`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ICustomXmlPart#getXmlData--) و [`setXmlData()`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) برای کار با بایت‌های خام XML بهره ببرید.

متد [`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ICustomXmlPart#getItemId--) UUID شناسایی‌کنندهٔ بخش XML سفارشی را در سند Office Open XML برمی‌گرداند. هنگام نیاز به یک شناسهٔ جدید، از [`setItemId()`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) استفاده کنید.

مثال زیر محتوای XML و شناسه را به‌روز می‌کند:

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPart customXmlPart = presentation.getAllCustomXmlParts()[0];

    // خواندن XML فعلی به‌صورت متن.
    String currentXmlContent = customXmlPart.getXmlAsString();
    System.out.println(currentXmlContent);

    // به‌روزرسانی XML به‌صورت رشتهٔ UTF-8.
    customXmlPart.setXmlAsString(
        "<metadata xmlns=\"urn:example:metadata\">" +
            "<documentId>DOC-1001</documentId>" +
            "<workflowState>Approved</workflowState>" +
        "</metadata>");

    // متد getXmlData محتوای XML یکسان را به‌صورت بایت‌های خام فراهم می‌کند.
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // جایگزینی شناسه هنگام نیاز توسط ادغام.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

زمانی که `setXmlAsString` یا `setXmlData` را فراخوانی می‌کنید، XML معتبر و غیر خالی فراهم کنید. بسته به اینکه برنامه بیشتر با رشته یا بایت کار می‌کند، یکی از این دو روش را انتخاب کنید.

### **حذف یک بخش XML سفارشی**

Aspose.Slides چندین روش برای حذف داده‌های XML سفارشی ارائه می‌دهد:

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ICustomXmlPart#remove--) بخش XML سفارشی را از ارائه حذف می‌کند.
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) بخش خاصی را از یک مجموعهٔ بخش‌های XML سفارشی حذف می‌کند.
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ICustomXmlPartCollection#removeAt-int--) بخش را در شاخص مشخصی از مجموعه حذف می‌کند.
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ICustomXmlPartCollection#clear--) تمام بخش‌ها را از یک مجموعه خاص حذف می‌کند.

مثال زیر یک بخش XML سفارشی سطح ارائه را با ارجاع حذف می‌کند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPartCollection customXmlParts = presentation.getCustomData().getCustomXmlParts();

    if (customXmlParts.size() > 0) {
        ICustomXmlPart customXmlPart = customXmlParts.get_Item(0);
        customXmlParts.remove(customXmlPart);
    }

    presentation.save("custom_xml_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

اگر قبلاً یک `ICustomXmlPart` داشته باشید و بخواهید آن را از ارائه حذف کنید (به‌جای حذف از یک مجموعهٔ خاص)، کافی است `customXmlPart.remove()` را صدا بزنید.

می‌توانید یک مورد را نیز بر اساس شاخص حذف کنید:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **پاک‌سازی تمام بخش‌های XML سفارشی از یک مجموعه**

از `clear` زمانی استفاده کنید که تمام بخش‌های XML سفارشی مرتبط با یک شیء خاص ارائه باید حذف شوند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear();

    presentation.save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`clear` فقط بر روی مجموعهٔ منتخب تأثیر می‌گذارد. برای مثال، پاک‌سازی مجموعهٔ یک اسلاید، مجموعهٔ سطح ارائه یا سطح شکل را پاک نمی‌کند.

برای حذف هر بخش XML سفارشی در ارائه، می‌توانید روی `getAllCustomXmlParts()` حلقه بزنید و هر بخش را حذف کنید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ICustomXmlPart customXmlPart : presentation.getAllCustomXmlParts()) {
        customXmlPart.remove();
    }

    presentation.save("all_custom_xml_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **کنترل بخش‌های XML سفارشی پیوند یا اشتراکی**

در یک ارائه Office Open XML، همان بخش XML سفارشی می‌تواند از چندین شیء ارائه ارجاع داده شود. برای مثال، یک فایل موجود می‌تواند روابطی از اسلایدها یا شکل‌های مختلف به همان بخش XML سفارشی داشته باشد.

یک بخش اشتراکی باید به‌عنوان یک شیء داده با ارجاعات متعدد در نظر گرفته شود:

- به‌روزرسانی آن با `setXmlAsString`، `setXmlData` یا `setItemId` بخش زیرین را تغییر می‌دهد، بنابراین تغییر در هر جایی که آن ارجاع داده شده است اعمال می‌شود.
- `getItemId()` می‌تواند برای شناسایی همان بخش XML سفارشی هنگام بازرسی مجموعه‌های سطح شیء استفاده شود.
- حذف یک بخش از یک مجموعهٔ `getCustomXmlParts()` مشخص، آن را تنها از همان مجموعه حذف می‌کند. برای حذف کلی بخش از ارائه، از `ICustomXmlPart.remove()` استفاده کنید.
- قبل از حذف یا جایگزینی یک بخش اشتراکی، مجموعه‌های سطح شیء را بررسی کنید تا ببینید آیا اسلایدها یا شکل‌های دیگر هنوز به آن ارجاع دارند یا خیر.

بارگذاری‌های `add` یک بخش XML سفارشی جدید از محتویات XML ایجاد می‌کنند؛ آنها یک `ICustomXmlPart` موجود را نمی‌پذیرند. بنابراین، روابط اشتراکی بیشتر در زمان بارگذاری ارائه‌هایی که از پیش این روابط را دارند، رخ می‌دهند.

مثال زیر مجموعه‌های سطح ارائه، اسلاید و شکل را بر اساس `ItemId` بازرسی می‌کند و بخش‌های ارجاع‌داده‑شده از بیش از یک مکان را گزارش می‌دهد:

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.UUID;
import java.util.function.BiConsumer;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Map<UUID, List<String>> referencesByItemId = new HashMap<>();

    BiConsumer<String, ICustomXmlPartCollection> registerCustomXmlParts =
        (ownerName, customXmlParts) -> {
            for (int i = 0; i < customXmlParts.size(); i++) {
                ICustomXmlPart customXmlPart = customXmlParts.get_Item(i);
                UUID itemId = customXmlPart.getItemId();

                if (!referencesByItemId.containsKey(itemId)) {
                    referencesByItemId.put(itemId, new ArrayList<>());
                }

                referencesByItemId.get(itemId).add(ownerName);
            }
        };

    registerCustomXmlParts.accept("Presentation", presentation.getCustomData().getCustomXmlParts());

    for (int slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        registerCustomXmlParts.accept("Slide " + (slideIndex + 1), slide.getCustomData().getCustomXmlParts());

        for (int shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            IShape shape = slide.getShapes().get_Item(shapeIndex);
            registerCustomXmlParts.accept("Slide " + (slideIndex + 1) + ", shape " + shapeIndex, shape.getCustomData().getCustomXmlParts());
        }
    }

    for (Map.Entry<UUID, List<String>> referenceEntry : referencesByItemId.entrySet()) {
        if (referenceEntry.getValue().size() > 1) {
            System.out.println("Shared custom XML part: " + referenceEntry.getKey());

            for (String ownerName : referenceEntry.getValue()) {
                System.out.println("  Referenced by: " + ownerName);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

این نوع بازرسی قبل از تغییر یا حذف داده‌های XML سفارشی در ارائه‌های تولید شده توسط سیستم‌های خارجی مفید است، زیرا همان بخش متادیتا ممکن است در بیش از یک رابطه شرکت داشته باشد.

## **دریافت مقادیر برچسب‌ها**

در Slides، یک برچسب معادل متد `IDocumentProperties.getKeywords()` است. این کد نمونه نشان می‌دهد چگونه با Aspose.Slides برای Java مقدار یک برچسب را از یک [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) دریافت کنیم:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    String keywords = presentation.getDocumentProperties().getKeywords();
} finally {
    presentation.dispose();
}
```

## **افزودن برچسب‌ها به ارائه‌ها**

Aspose.Slides به شما اجازه می‌دهد برچسب‌ها را به ارائه‌ها اضافه کنید. یک برچسب معمولاً شامل دو مقدار است:

- نام یک ویژگی سفارشی، برای مثال `MyTag`؛
- مقدار ویژگی سفارشی، برای مثال `My Tag Value`.

اگر نیاز به دسته‌بندی ارائه‌ها بر اساس یک قانون یا ویژگی خاص دارید، می‌توانید برای آن هدف برچسب اضافه کنید. برای مثال، اگر می‌خواهید ارائه‌های کشورهای آمریکای شمالی را دسته‌بندی کنید، می‌توانید یک برچسب «North American» ایجاد کرده و کشور مربوطه را به عنوان مقدار آن تنظیم کنید.

این کد نمونه نشان می‌دهد چگونه با Aspose.Slides برای Java یک برچسب به یک [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) اضافه کنیم:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ITagCollection tags = presentation.getCustomData().getTags();
    tags.set_Item("MyTag", "My Tag Value");
} finally {
    presentation.dispose();
}
```

برچسب‌ها می‌توانند برای یک [Slide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISlide) نیز تنظیم شوند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

یا برای یک [Shape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IAutoShape) منفرد:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    presentation.dispose();
}
```

### **محدودیت‌ها**

برچسب‌هایی که از طریق مجموعه `getCustomData().getTags()` اضافه می‌شوند فقط در فایل PowerPoint ذخیره می‌شوند. آنها **به** ساختار برچسب‌های PDF هنگام صادرات ارائه به PDF منتقل نمی‌شوند. بنابراین، یک شناسهٔ سفارشی که به‌عنوان برچسب اختصاص داده شده است نمی‌تواند از PDF برچسب‌گذاری شده بازیابی شود.

**راه‌حل:** می‌توانید یک شناسهٔ سفارشی را در **متن جایگزین** شیء (مثلاً `shape.setAlternativeText("MyId")`) ذخیره کنید. پس از صادرات به PDF، متن جایگزین ممکن است در ساختار برچسب‌های PDF ظاهر شود.

## **سؤالات متداول**

**آیا می‌توانم تمام برچسب‌ها را از یک ارائه، اسلاید یا شکل در یک عملیات حذف کنم؟**

بله. مجموعهٔ [tag collection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tagcollection/) از عملیات [clear](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tagcollection/#clear--) پشتیبانی می‌کند که تمام جفت‌های کلید‑مقدار را یک‌باره حذف می‌‫​‌‬د.

**چگونه می‌توان یک برچسب را تنها با نام آن بدون پیمایش تمام مجموعه حذف کرد؟**

از [remove(name)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) روی [tag collection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tagcollection/) استفاده کنید تا برچسب را بر اساس کلیدش حذف کنید.

**چگونه می‌توان لیست کامل نام‌های برچسب‌ها را برای تحلیل یا فیلترینگ دریافت کرد؟**

از [getNamesOfTags](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tagcollection/#getNamesOfTags--) روی [tag collection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tagcollection/) استفاده کنید؛ این متد یک آرایه از تمام نام‌های برچسب را برمی‌گرداند.

**چگونه می‌توان تمام بخش‌های XML سفارشی را بدون توجه به محل ذخیره‌شان پیدا کرد؟**

از [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) برای بازیابی تمام بخش‌های XML سفارشی در ارائه استفاده کنید.

**آیا باید از `getXmlAsString`/`setXmlAsString` یا `getXmlData`/`setXmlData` برای به‌روزرسانی یک بخش XML سفارشی استفاده کنم؟**

وقتی برنامه با متن XML UTF‑8 کار می‌کند، از `getXmlAsString` و `setXmlAsString` استفاده کنید. وقتی XML از پیش به‌صورت آرایهٔ بایت موجود است یا پردازش باینری راحت‌تر است، از `getXmlData` و `setXmlData` استفاده کنید. هر دو نمایانگر محتوای XML همان بخش XML سفارشی هستند.