---
title: مدیریت برچسب‌ها و داده‌های سفارشی در ارائه‌ها با استفاده از جاوا
linktitle: برچسب‌ها و داده‌های سفارشی
type: docs
weight: 300
url: /fa/java/managing-tags-and-custom-data/
keywords:
- ویژگی‌های سند
- برچسب
- داده‌های سفارشی
- XML سفارشی
- قسمت XML سفارشی
- متادیتای XML
- شناسه آیتم
- افزودن برچسب
- مقادیر جفت
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه برچسب‌ها و داده‌های XML سفارشی را در ارائه‌های PowerPoint با Aspose.Slides برای Java مدیریت کنید، از جمله افزودن، خواندن، به‌روزرسانی، حسابرسی و حذف قسمت‌های XML سفارشی."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد که Aspose.Slides چگونه با برچسب‌ها و داده‌های سفارشی در ارائه‌های PowerPoint کار می‌کند. داده‌های مرتبط با ارائه می‌توانند به‌صورت برچسب یا قسمت‌های XML سفارشی ذخیره شوند. برچسب‌ها جفت‌های ساده کلید‑مقدار رشته‌ای هستند، در حالی که قسمت‌های XML سفارشی می‌توانند متادیتای ساختاری و payloadهای XML مخصوص برنامه را ذخیره کنند.

Aspose.Slides APIهایی برای افزودن، خواندن، به‌روزرسانی، حسابرسی و حذف قسمت‌های XML سفارشی در سطوح ارائه، اسلاید و شکل فراهم می‌کند. قسمت‌های XML سفارشی برای ادغام‌هایی که اطلاعاتی مانند شناسه‌های مدیریت سند، وضعیت جریان کار، متادیتای انطباق، داده‌های بایندینگ قالب یا سایر داده‌های ساختاری برنامه‌ای را داخل یک ارائه ذخیره می‌کنند، مفید هستند.

## **ذخیره‌سازی داده در فایل‌های ارائه**

فایل‌های PPTX—فایل‌هایی با پسوند `.pptx`—در قالب PresentationML که بخشی از مشخصات Office Open XML است، ذخیره می‌شوند. Office Open XML ساختار بسته و روابط مورد استفاده برای ذخیره محتوای ارائه و داده‌های مرتبط را تعریف می‌کند.

یک ارائه شامل چندین بخش متصل به‌وسیله روابط است. به‌عنوان مثال، یک بخش اسلاید محتوای یک اسلاید واحد را دربر می‌گیرد و می‌تواند روابط صریحی به بخش‌های دیگر داشته باشد که توسط ISO/IEC 29500 تعریف می‌شود.

داده‌های سفارشی می‌توانند به‌صورت برچسب ([ITagCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITagCollection)) یا قسمت‌های XML سفارشی ([ICustomXmlPartCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ICustomXmlPartCollection)) ذخیره شوند. هر دو از طریق رابط [`ICustomData`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ICustomData/) در دسترس هستند.

{{% alert color="info" %}}
برچسب‌ها جفت‌های ساده کلید‑مقدار رشته‌ای را ذخیره می‌کنند. قسمت‌های XML سفارشی داده‌های ساختاری XML را ذخیره می‌کنند و می‌توانند به یک ارائه، اسلاید یا شکل مرتبط شوند.
{{% /alert %}}

## **کار با قسمت‌های XML سفارشی**

متد [`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ICustomData#getCustomXmlParts--) مجموعهٔ قسمت‌های XML سفارشی مرتبط با یک شیء خاص ارائه را برمی‌گرداند. برای مثال:

- `presentation.getCustomData().getCustomXmlParts()` شامل قسمت‌های XML سفارشی مربوط به خود ارائه است.
- `slide.getCustomData().getCustomXmlParts()` شامل قسمت‌های XML سفارشی مربوط به یک اسلاید خاص است.
- `shape.getCustomData().getCustomXmlParts()` شامل قسمت‌های XML سفارشی مربوط به یک شکل خاص است.

از [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) زمانی که نیاز به بررسی تمام قسمت‌های XML سفارشی در ارائه بدون توجه به محل اتصال آن‌ها دارید، استفاده کنید.

### **افزودن یک قسمت XML سفارشی به یک ارائه**

از [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) برای افزودن داده XML به مجموعهٔ قسمت‌های XML سفارشی استفاده کنید. XML باید معتبر و غیرخالی باشد.

مثال زیر متادیتای ساختاری را به مجموعهٔ داده سفارشی سطح ارائه اضافه می‌کند:

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

    // add به‌صورت خودکار یک شناسه اختصاص می‌دهد. فقط در صورت نیاز یک UUID خاص تنظیم کنید.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

متد `add` می‌تواند XML را به‌صورت آرایهٔ بایت یا جریان ورودی نیز دریافت کند که زمانی مفید است که محتوا قبلاً به‌صورت باینری موجود باشد.

### **افزودن یک قسمت XML سفارشی به اسلاید یا شکل**

داده‌های XML سفارشی می‌توانند به یک اسلاید یا شکل خاص به‌جای کل ارائه وابسته شوند. این مورد زمانی مفید است که متادیتا فقط به یک شیء اشاره دارد، مانند کلید قالب، شناسهٔ رکورد خارجی یا اطلاعات بایندینگ.

مثال زیر یک قسمت XML سفارشی به یک اسلاید و یک قسمت دیگر به یک شکل اضافه می‌کند:

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

سطحی که قسمت در آن افزوده می‌شود تعیین می‌کند کدام مجموعهٔ `getCustomData().getCustomXmlParts()` شیء، رابطهٔ آن قطعه را دربردارد. داده‌های سطح ارائه برای متادیتای سراسری سند مناسب‌اند، داده‌های سطح اسلاید برای اطلاعات متعلق به یک اسلاید خاص، و داده‌های سطح شکل برای متادیتای مرتبط با یک شکل منفرد.

### **فهرست و حسابرسی تمام قسمت‌های XML سفارشی**

از [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) برای بازیابی تمام قسمت‌های XML سفارشی از یک ارائه استفاده کنید. هر [`ICustomXmlPart`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ICustomXmlPart/) شناسه، محتوای XML و قالب‌های فضاهای نام مرتبط را نشان می‌دهد.

مثال زیر تمام قسمت‌های XML سفارشی و قالب‌های فضاهای نام آن‌ها را فهرست می‌کند:

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

متد [`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) قالب‌های XML مرتبط با قسمت XML سفارشی را برمی‌گرداند. این اطلاعات می‌تواند هنگام حسابرسی ارائه‌هایی که XML تولید شده توسط سیستم‌های خارجی را شامل می‌شوند، مفید باشد.

### **خواندن و به‌روزرسانی محتوای XML و ItemId**

از [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ICustomXmlPart#getXmlAsString--) و [`setXmlAsString()`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) برای کار با XML به‌صورت رشتهٔ UTF‑8، یا از [`getXmlData()`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ICustomXmlPart#getXmlData--) و [`setXmlData()`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) برای کار با بایت‌های خام XML استفاده کنید.

متد [`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ICustomXmlPart#getItemId--) UUID ای را برمی‌گرداند که قسمت XML سفارشی را در سند Office Open XML شناسایی می‌کند. هنگامیکه یک ادغام به شناسهٔ جدیدی نیاز دارد، از [`setItemId()`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) استفاده کنید.

مثال زیر محتوای XML و شناسه را به‌روزرسانی می‌کند:

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.util.UUID;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ICustomXmlPart customXmlPart = presentation.getAllCustomXmlParts()[0];

    // XML فعلی را به‌عنوان متن بخوانید.
    String currentXmlContent = customXmlPart.getXmlAsString();
    System.out.println(currentXmlContent);

    // XML را به‌عنوان رشته UTF-8 به‌روز کنید.
    customXmlPart.setXmlAsString(
        "<metadata xmlns=\"urn:example:metadata\">" +
            "<documentId>DOC-1001</documentId>" +
            "<workflowState>Approved</workflowState>" +
        "</metadata>");

    // getXmlData همان محتوای XML را به‌صورت بایت‌های خام فراهم می‌کند.
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // شناسه را هنگام نیاز ادغام تغییر دهید.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

هنگام فراخوانی `setXmlAsString` یا `setXmlData`، XML معتبر و غیرخالی ارائه دهید. بسته به این‌که برنامه عمدتاً با رشته‌ها یا داده‌های بایتی کار می‌کند، از یکی از این دو نمایندگی استفاده کنید.

### **حذف یک قسمت XML سفارشی**

Aspose.Slides روش‌های متعددی برای حذف داده‌های XML سفارشی ارائه می‌دهد:

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ICustomXmlPart#remove--) قسمت XML سفارشی را از ارائه حذف می‌کند.
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) یک قسمت خاص را از مجموعهٔ قسمت‌های XML سفارشی حذف می‌کند.
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ICustomXmlPartCollection#removeAt-int-) قسمت را در اندیس مشخص شده حذف می‌کند.
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ICustomXmlPartCollection#clear--) تمام قسمت‌ها را از یک مجموعهٔ خاص حذف می‌کند.

مثال زیر یک قسمت XML سفارشی سطح ارائه را با ارجاع حذف می‌کند:

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

اگر قبلاً یک `ICustomXmlPart` دارید و می‌خواهید آن را از ارائه حذف کنید نه از یک مجموعهٔ خاص، `customXmlPart.remove()` را فراخوانی کنید.

همچنین می‌توانید یک مورد را با اندیس حذف کنید:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **پاک‌سازی تمام قسمت‌های XML سفارشی از یک مجموعه**

وقتی باید تمام قسمت‌های XML سفارشی مرتبط با یک شیء خاص ارائه حذف شوند، از `clear` استفاده کنید.

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

`clear` تنها بر مجموعهٔ انتخاب‌شده تأثیر می‌گذارد. به‌عنوان مثال، پاک‌سازی مجموعهٔ یک اسلاید، مجموعهٔ سطح ارائه یا سطح شکل را پاک نمی‌کند.

برای حذف همهٔ قسمت‌های XML سفارشی در ارائه، روی `getAllCustomXmlParts()` پیمایش کنید و هر قسمت را حذف کنید:

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

### **برخورد با قسمت‌های XML سفارشی لینک‌شده یا به‌اشتراک‌گذاری‌شده**

در یک ارائه Office Open XML، یک قسمت XML سفارشی می‌تواند از بیش از یک شیء ارائه ارجاع داده شود. برای مثال، یک فایل موجود می‌تواند روابطی از چندین اسلاید یا شکل به یک قسمت XML سفارشی زیرین داشته باشد.

یک قسمت به‌اشتراک‌گذاری‌شده باید به‌عنوان یک شیء داده با چندین ارجاع در نظر گرفته شود:

- به‌روزرسانی آن با `setXmlAsString`، `setXmlData` یا `setItemId` قسمت زیرین را تغییر می‌دهد، بنابراین تغییر در تمام مکان‌های ارجاع‌داده‌شده اعمال می‌شود.
- `getItemId()` می‌تواند برای شناسایی همان قسمت XML سفارشی هنگام حسابرسی مجموعه‌های سطح شیء استفاده شود.
- حذف یک قسمت از یک مجموعهٔ خاص `getCustomXmlParts()` آن را فقط از همان مجموعه حذف می‌کند. برای حذف کامل قسمت از ارائه از `ICustomXmlPart.remove()` استفاده کنید.
- قبل از حذف یا جایگزینی یک قسمت به‌اشتراک‌گذاری‌شده، مجموعه‌های سطح شیء را بررسی کنید تا تعیین کنید آیا اسلایدها یا اشکال دیگر هنوز به آن ارجاع دارند یا نه.

بارگذاری‌های `add` یک قسمت XML سفارشی جدید از محتوای XML ایجاد می‌کنند؛ آن‌ها یک `ICustomXmlPart` موجود را نمی‌پذیرند. بنابراین، روابط به‌اشتراک‌گذاری‌شده معمولاً هنگام بارگذاری ارائه‌هایی که از پیش شامل آن‌ها هستند، مشاهده می‌شوند.

مثال زیر مجموعه‌های سطح ارائه، اسلاید و شکل را بر پایه `ItemId` حسابرسی می‌کند و قسمت‌های ارجاع‌شده از بیش از یک مکان را گزارش می‌دهد:

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

این نوع حسابرسی قبل از تغییر یا حذف داده‌های XML سفارشی در ارائه‌های ساخته‌شده توسط سیستم‌های خارجی مفید است، زیرا یک قسمت متادیتا ممکن است در بیش از یک رابطه مشارکت داشته باشد.

## **دریافت مقادیر برچسب‌ها**

در اسلایدها، یک برچسب معادل متد `IDocumentProperties.getKeywords()` است. این کد نمونه نشان می‌دهد چگونه مقدار یک برچسب را با Aspose.Slides برای جاوا برای [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) دریافت کنیم:

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

Aspose.Slides به شما اجازه می‌دهد برچسب‌ها را به ارائه‌ها اضافه کنید. یک برچسب معمولاً شامل دو مورد است:

- نام یک ویژگی سفارشی، برای مثال `MyTag`؛
- مقدار ویژگی سفارشی، برای مثال `My Tag Value`.

اگر نیاز به طبقه‌بندی ارائه‌ها بر اساس قاعده یا ویژگی خاصی دارید، می‌توانید برای آن منظور برچسب اضافه کنید. به‌عنوان مثال، برای دسته‌بندی ارائه‌های کشورهای آمریکای شمالی می‌توانید یک برچسب «North American» ایجاد کنید و کشور مربوطه را به‌عنوان مقدار آن تعیین کنید.

این کد نمونه نشان می‌دهد چگونه یک برچسب را به یک [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) با Aspose.Slides برای جاوا اضافه کنیم:

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

برچسب‌های اضافه‌شده از طریق مجموعهٔ `getCustomData().getTags()` فقط در فایل PowerPoint ذخیره می‌شوند. آن‌ها **به** ساختار برچسب PDF هنگام خروجی‌گیری به PDF منتقل نمی‌شوند. بنابراین، یک شناسهٔ سفارشی اختصاص‌داده‌شده به‌عنوان برچسب را نمی‌توان از PDF برچسب‌دار استخراج کرد.

**راه‌حل**: می‌توانید یک شناسهٔ سفارشی را در **متن جایگزین** شیء (مثلاً `shape.setAlternativeText("MyId")`) ذخیره کنید. پس از خروجی‌گیری به PDF، متن جایگزین ممکن است در ساختار برچسب PDF ظاهر شود.

## **سؤالات متداول**

**آیا می‌توانم تمام برچسب‌ها را از یک ارائه، اسلاید یا شکل در یک عملیات حذف کنم؟**

بله. مجموعهٔ [tag collection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tagcollection/) از عملیات [clear](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tagcollection/#clear--) پشتیبانی می‌کند که تمام جفت‌های کلید‑مقدار را یک‌باره حذف می‌نماید.

**چگونه یک برچسب تکی را بر اساس نام آن بدون مرور کل مجموعه حذف کنم؟**

از متد [remove(name)](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) روی [tag collection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tagcollection/) برای حذف برچسب بر اساس کلید آن استفاده کنید.

**چگونه می‌توانم فهرست کامل نام‌های برچسب‌ها را برای آنالیز یا فیلترگیری دریافت کنم؟**

از متد [getNamesOfTags](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tagcollection/#getNamesOfTags--) روی [tag collection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/tagcollection/) استفاده کنید؛ این متد آرایه‌ای از تمام نام‌های برچسب را برمی‌گرداند.

**چگونه می‌توانم همهٔ قسمت‌های XML سفارشی را regardless از جایی که ذخیره شده‌اند پیدا کنم؟**

از [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation#getAllCustomXmlParts--) برای بازیابی همهٔ قسمت‌های XML سفارشی در ارائه استفاده کنید.

**آیا برای به‌روزرسانی یک قسمت XML سفارشی باید از `getXmlAsString`/`setXmlAsString` یا `getXmlData`/`setXmlData` استفاده کنم؟**

زمانی که برنامه با متن XML UTF‑8 کار می‌کند از `getXmlAsString` و `setXmlAsString` استفاده کنید. زمانی که XML قبلاً به‌صورت آرایهٔ بایت موجود است یا پردازش باینری راحت‌تر است، از `getXmlData` و `setXmlData` استفاده کنید. هر دو نمایندگی به محتوای XML همان قسمت XML سفارشی اشاره دارند.