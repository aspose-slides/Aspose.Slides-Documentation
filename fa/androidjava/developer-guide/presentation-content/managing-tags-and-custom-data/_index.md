---
title: مدیریت برچسب‌ها و داده‌های سفارشی در ارائه‌ها در Android
linktitle: برچسب‌ها و داده‌های سفارشی
type: docs
weight: 300
url: /fa/androidjava/managing-tags-and-custom-data
keywords:
- ویژگی‌های سند
- برچسب
- داده‌های سفارشی
- XML سفارشی
- بخش XML سفارشی
- فراداده XML
- شناسه
- افزودن برچسب
- مقادیر جفت
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه برچسب‌ها و داده‌های XML سفارشی را در ارائه‌های PowerPoint با Aspose.Slides برای Android از طریق Java مدیریت کنید، از جمله افزودن، خواندن، به‌روزرسانی، بررسی و حذف بخش‌های XML سفارشی."
---
## **بررسی کلی**

این مقاله نحوهٔ کار Aspose.Slides با برچسب‌ها و داده‌های سفارشی در ارائه‌های PowerPoint را توضیح می‌دهد. داده‌های مختص یک ارائه می‌تواند به صورت برچسب یا بخش‌های XML سفارشی ذخیره شود. برچسب‌ها جفت‌های سادهٔ کلید‑مقدار رشته‌ای هستند، در حالی که بخش‌های XML سفارشی می‌توانند فراداده‌های ساختاری و بارهای XML مخصوص برنامه را ذخیره کنند.

Aspose.Slides APIهایی برای افزودن، خواندن، به‌روزرسانی، بررسی و حذف بخش‌های XML سفارشی در سطوح ارائه، اسلاید و شکل فراهم می‌کند. بخش‌های XML سفارشی برای یکپارچه‌سازی‌هایی که اطلاعاتی نظیر شناسه‌های مدیریت سند، وضعیت گردش کار، فراداده‌های تطبیق، داده‌های بایندینگ قالب یا سایر داده‌های ساختاری برنامه را داخل یک ارائه ذخیره می‌کنند، مفید هستند.

## **ذخیره‌سازی داده‌ها در فایل‌های ارائه**

فایل‌های PPTX—فایل‌هایی با پسوند `.pptx`—در قالب PresentationML ذخیره می‌شوند که بخشی از مشخصات Office Open XML است. Office Open XML ساختار بسته و روابط مورد استفاده برای ذخیره محتوای ارائه و داده‌های مرتبط را تعریف می‌کند.

یک ارائه شامل چندین بخش متصل به هم از طریق روابط است. به عنوان مثال، بخش اسلاید شامل محتوای یک اسلاید واحد است و می‌تواند روابط صریحی به بخش‌های دیگر داشته باشد که توسط ISO/IEC 29500 تعریف می‌شود.

داده‌های سفارشی می‌توانند به صورت برچسب ([ITagCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ITagCollection)) یا بخش‌های XML سفارشی ([ICustomXmlPartCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ICustomXmlPartCollection)) ذخیره شوند. هر دو از طریق رابط [`ICustomData`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ICustomData/) در دسترس هستند.

{{% alert color="primary" %}}
برچسب‌ها جفت‌های سادهٔ کلید‑مقدار رشته‌ای را ذخیره می‌کنند. بخش‌های XML سفارشی داده‌های ساختاری XML را ذخیره می‌کنند و می‌توانند به یک ارائه، اسلاید یا شکل مرتبط شوند.
{{% /alert %}}

## **کار با بخش‌های XML سفارشی**

متد [`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ICustomData#getCustomXmlParts--) مجموعهٔ بخش‌های XML سفارشی مرتبط با یک شیء خاص ارائه را برمی‌گرداند. به عنوان مثال:

- `presentation.getCustomData().getCustomXmlParts()` شامل بخش‌های XML سفارشی مرتبط با خود ارائه است.
- `slide.getCustomData().getCustomXmlParts()` شامل بخش‌های XML سفارشی مرتبط با اسلاید خاصی است.
- `shape.getCustomData().getCustomXmlParts()` شامل بخش‌های XML سفارشی مرتبط با شکل خاصی است.

از [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) زمانی که نیاز به بررسی تمام بخش‌های XML سفارشی در ارائه داشته باشید، استفاده کنید، بدون توجه به اینکه در کجا مرتبط شده‌اند.

### **افزودن یک بخش XML سفارشی به یک ارائه**

از [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) برای افزودن دادهٔ XML به مجموعهٔ بخش‌های XML سفارشی استفاده کنید. XML باید معتبر و غیرخالی باشد.

مثال زیر فرادادهٔ ساختاری را به مجموعهٔ داده‌های سفارشی سطح ارائه اضافه می‌کند:

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

    // add به‌صورت خودکار شناسه‌ای اختصاص می‌دهد. فقط در صورت نیاز یک UUID خاص تنظیم کنید.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

متد `add` می‌تواند XML را به صورت آرایهٔ بایت یا جریان ورودی نیز بپذیرد که زمانی مفید است که محتوای XML از پیش به شکل باینری در دسترس باشد.

### **افزودن یک بخش XML سفارشی به اسلاید یا شکل**

دادهٔ XML سفارشی می‌تواند به جای کل ارائه، به یک اسلاید یا شکل خاص مرتبط شود. این زمانی مفید است که فراداده فقط یک شیء را توصیف می‌کند، مانند کلید قالب، شناسهٔ رکورد خارجی یا اطلاعات بایندینگ.

مثال زیر یک بخش XML سفارشی را به یک اسلاید و بخش دیگر را به یک شکل اضافه می‌کند:

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

سطحی که بخش در آن اضافه می‌شود تعیین می‌کند که کدام مجموعهٔ `getCustomData().getCustomXmlParts()` شامل رابطه به آن بخش است. داده‌های سطح ارائه برای فرادادهٔ سراسری سند مناسب است، داده‌های سطح اسلاید برای اطلاعاتی که به اسلاید خاصی تعلق دارد، و داده‌های سطح شکل برای فرادادهٔ مرتبط با یک شکل فردی.

### **فهرست و بررسی تمام بخش‌های XML سفارشی**

از [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) برای دریافت تمام بخش‌های XML سفارشی از یک ارائه استفاده کنید. هر [`ICustomXmlPart`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ICustomXmlPart/) شناسه، محتوای XML و نام‌فضای اسکیماهای مرتبط را ارائه می‌دهد.

مثال زیر تمام بخش‌های XML سفارشی و اسکیماهای نام‌فضای آنها را فهرست می‌کند:

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

متد [`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) اسکیماهای XML مرتبط با بخش XML سفارشی را برمی‌گرداند. این اطلاعات می‌تواند هنگام بررسی ارائه‌هایی که حاوی XML تولید شده توسط سیستم‌های خارجی هستند مفید باشد.

### **خواندن و به‌روزرسانی محتوای XML و ItemId**

از [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ICustomXmlPart#getXmlAsString--) و [`setXmlAsString()`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) برای کار با XML به صورت رشتهٔ UTF‑8، یا از [`getXmlData()`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ICustomXmlPart#getXmlData--) و [`setXmlData()`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) برای کار با بایت‌های خام XML استفاده کنید.

متد [`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ICustomXmlPart#getItemId--) UUID‌ای را برمی‌گرداند که بخش XML سفارشی را در سند Office Open XML شناسایی می‌کند. هنگامیکه یک یکپارچه‌سازی به شناسهٔ جدیدی نیاز دارد، از [`setItemId()`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) استفاده کنید.

مثال زیر محتوای XML و شناسه را به‌روزرسانی می‌کند:

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

    // به‌روزرسانی XML به‌صورت رشته UTF-8.
    customXmlPart.setXmlAsString(
        "<metadata xmlns=\"urn:example:metadata\">" +
            "<documentId>DOC-1001</documentId>" +
            "<workflowState>Approved</workflowState>" +
        "</metadata>");

    // getXmlData محتوای XML یکسان را به‌صورت بایت‌های خام ارائه می‌دهد.
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // جایگزینی شناسه زمانی که یکپارچه‌سازی نیاز دارد.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

هنگام فراخوانی `setXmlAsString` یا `setXmlData`، XML معتبر و غیرخالی فراهم کنید. بسته به این‌که برنامه عمدتاً با رشته‌ها یا داده‌های بایتی کار می‌کند، از یکی از نمایه‌ها استفاده کنید.

### **حذف یک بخش XML سفارشی**

Aspose.Slides چندین روش برای حذف دادهٔ XML سفارشی ارائه می‌دهد:

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ICustomXmlPart#remove--) بخش XML سفارشی را از ارائه حذف می‌کند.
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) بخش خاصی را از مجموعهٔ بخش‌های XML سفارشی حذف می‌کند.
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ICustomXmlPartCollection#removeAt-int-) بخش را در اندیس مشخصی از مجموعه حذف می‌کند.
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ICustomXmlPartCollection#clear--) تمام بخش‌ها را از یک مجموعه خاص حذف می‌کند.

مثال زیر یک بخش XML سفارشی سطح ارائه را بر اساس مرجع حذف می‌کند:

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

اگر قبلاً یک `ICustomXmlPart` دارید و می‌خواهید آن را از ارائه حذف کنید نه از یک مجموعه خاص، `customXmlPart.remove()` را فراخوانی کنید.

همچنین می‌توانید یک مورد را بر اساس اندیس حذف کنید:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **پاک‌سازی تمام بخش‌های XML سفارشی از یک مجموعه**

زمانی که تمام بخش‌های XML سفارشی مرتبط با یک شیء خاص ارائه باید حذف شوند، از `clear` استفاده کنید.

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

`clear` تنها بر روی مجموعهٔ انتخاب شده تأثیر می‌گذارد. برای مثال، پاک‌سازی مجموعهٔ اسلاید، مجموعهٔ سطح ارائه یا مجموعهٔ سطح شکل را پاک نمی‌کند.

برای حذف تمام بخش‌های XML سفارشی در ارائه، می‌توانید از `getAllCustomXmlParts()` عبور کنید و هر بخش را حذف کنید:

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

### **پردازش بخش‌های XML سفارشی پیوندی یا مشترک**

در یک ارائه Office Open XML، همان بخش XML سفارشی می‌تواند از بیش از یک شیء ارائه ارجاع شود. به عنوان مثال، یک فایل موجود می‌تواند روابطی از چندین اسلاید یا شکل به همان بخش XML سفارشی زیرین داشته باشد.

یک بخش مشترک باید به عنوان یک شیء داده‌ای با ارجاعات متعدد در نظر گرفته شود:

- به‌روزرسانی آن با `setXmlAsString`، `setXmlData` یا `setItemId` بخش XML زیرین را تغییر می‌دهد، بنابراین تغییر در هر جایی که آن بخش ارجاع شده باشد اعمال می‌شود.
- `getItemId()` می‌تواند برای شناسایی همان بخش XML سفارشی هنگام بررسی مجموعه‌های سطح شیء استفاده شود.
- حذف یک بخش از یک مجموعهٔ خاص `getCustomXmlParts()` آن را فقط از همان مجموعه حذف می‌کند. برای حذف کامل بخش از ارائه از `ICustomXmlPart.remove()` استفاده کنید.
- قبل از حذف یا جایگزینی یک بخش مشترک، مجموعه‌های سطح شیء را بررسی کنید تا ببینید آیا اسلایدها یا شکل‌های دیگر هنوز به آن ارجاع دارند یا خیر.

بارگذاری‌های `add` یک بخش XML سفارشی جدید از محتویات XML ایجاد می‌کنند؛ آنها یک `ICustomXmlPart` موجود را نمی‌پذیرند. بنابراین، روابط مشترک بیشتر در زمان بارگذاری ارائه‌های قبلاً حاوی این روابط مشاهده می‌شود.

مثال زیر مجموعه‌های سطح ارائه، اسلاید و شکل را بر اساس `ItemId` بررسی می‌کند و بخش‌های ارجاع شده از بیش از یک مکان را گزارش می‌دهد:

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

این نوع بررسی قبل از تغییر یا حذف دادهٔ XML سفارشی در ارائه‌های ایجاد شده توسط سیستم‌های خارجی مفید است، زیرا همان بخش فراداده ممکن است در بیش از یک رابطه شرکت داشته باشد.

## **دریافت مقادیر برچسب‌ها**

در اسلایدها، یک برچسب متناظر با متد `IDocumentProperties.getKeywords()` است. این نمونه کد نشان می‌دهد چگونه مقدار یک برچسب را با Aspose.Slides برای Android از طریق Java برای [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) دریافت کنید:

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

Aspose.Slides به شما امکان می‌دهد برچسب‌ها را به ارائه‌ها اضافه کنید. یک برچسب معمولاً شامل دو مورد است:

- نام یک ویژگی سفارشی، به عنوان مثال `MyTag`؛
- مقدار ویژگی سفارشی، به عنوان مثال `My Tag Value`.

اگر نیاز به طبقه‌بندی ارائه‌ها بر اساس قانون یا ویژگی خاصی دارید، می‌توانید برای این منظور برچسب اضافه کنید. به عنوان مثال، اگر می‌خواهید ارائه‌های کشورهای آمریکای شمالی را دسته‌بندی کنید، می‌توانید یک برچسب «North American» ایجاد کرده و کشور مربوطه را به عنوان مقدار آن اختصاص دهید.

این نمونه کد نشان می‌دهد چگونه یک برچسب به یک [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) با Aspose.Slides برای Android از طریق Java اضافه شود:

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

برچسب‌ها می‌توانند برای یک [Slide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISlide) نیز تنظیم شوند:

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

یا برای یک [Shape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IAutoShape) فردی:

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

برچسب‌هایی که از طریق مجموعه `getCustomData().getTags()` اضافه می‌شوند فقط در فایل PowerPoint ذخیره می‌شوند. آنها **به** ساختار برچسب PDF هنگام صادرات ارائه به PDF منتقل نمی‌شوند. در نتیجه، یک شناسهٔ سفارشی که به عنوان برچسب اختصاص داده شده است، نمی‌تواند از PDF برچسب‌دار بازیابی شود.

**راه حل**: می‌توانید یک شناسهٔ سفارشی را در **متن Alt** شیء (به عنوان مثال، `shape.setAlternativeText("MyId")`) ذخیره کنید. پس از صادرات به PDF، متن Alt ممکن است در ساختار برچسب PDF ظاهر شود.

## **پرسش‌های متداول**

**آیا می‌توانم تمام برچسب‌ها را از یک ارائه، اسلاید یا شکل در یک عملیات حذف کنم؟**

بله. مجموعهٔ برچسب‌ها ([tag collection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tagcollection/)) از عملیات [clear](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tagcollection/#clear--) پشتیبانی می‌کند که تمام جفت‌های کلید‑مقدار را یک‌بار حذف می‌نماید.

**چگونه می‌توانم یک برچسب تک را بر اساس نام آن بدون پیمایش کل مجموعه حذف کنم؟**

از [remove(name)](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) روی [مجموعه برچسب‌ها](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tagcollection/) استفاده کنید تا برچسب بر اساس کلید خود حذف شود.

**چگونه می‌توانم فهرست کاملی از نام‌های برچسب‌ها را برای تحلیل یا فیلترگیری بدست آورم؟**

از [getNamesOfTags](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) روی [مجموعه برچسب‌ها](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tagcollection/) استفاده کنید؛ این متد آرایه‌ای شامل تمام نام‌های برچسب‌ها را برمی‌گرداند.

**چگونه می‌توانم تمام بخش‌های XML سفارشی را بدون در نظر گرفتن محل ذخیره‌شان پیدا کنم؟**

از [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) برای دریافت تمام بخش‌های XML سفارشی در ارائه استفاده کنید.

**آیا باید از `getXmlAsString`/`setXmlAsString` یا `getXmlData`/`setXmlData` برای به‌روزرسانی یک بخش XML سفارشی استفاده کنم؟**

زمانی که برنامه با متن XML UTF‑8 کار می‌کند، از `getXmlAsString` و `setXmlAsString` استفاده کنید. وقتی XML از پیش به صورت آرایهٔ بایت موجود است یا پردازش باینری راحت‌تر است، از `getXmlData` و `setXmlData` استفاده کنید. هر دو نمایانگر محتوای XML همان بخش XML سفارشی هستند.