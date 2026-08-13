---
title: مدیریت برچسب‌ها و داده‌های سفارشی در ارائه‌ها روی Android
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
- متادیتای XML
- ItemId
- افزودن برچسب
- مقدارهای جفت
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه برچسب‌ها و داده‌های XML سفارشی را در ارائه‌های PowerPoint با Aspose.Slides برای Android از طریق Java مدیریت کنید، شامل افزودن، خواندن، بروزرسانی، بررسی و حذف بخش‌های XML سفارشی."
---
## **مرور کلی**

این مقاله توضیح می‌دهد که Aspose.Slides چگونه با برچسب‌ها و داده‌های سفارشی در ارائه‌های PowerPoint کار می‌کند. داده‌های خاص ارائه می‌تواند به صورت برچسب یا بخش‌های XML سفارشی ذخیره شود. برچسب‌ها جفت‌های کلید‑مقدار رشته‌ای ساده هستند، در حالی که بخش‌های XML سفارشی می‌توانند متادیتای ساختاریافته و بارهای XML خاص برنامه را ذخیره کنند.

Aspose.Slides APIهایی برای افزودن، خواندن، بروزرسانی، بررسی و حذف بخش‌های XML سفارشی در سطوح ارائه، اسلاید و شکل فراهم می‌کند. بخش‌های XML سفارشی برای ادغام‌هایی که اطلاعاتی مانند شناسه‌های مدیریت سند، وضعیت گردش کار، متادیتای انطباق، داده‌های قالب‑بندی یا سایر داده‌های ساختاریافته برنامه‌ای را داخل یک ارائه ذخیره می‌کنند، مفید هستند.

## **ذخیره‌سازی داده در فایل‌های ارائه**

فایل‌های PPTX—فایل‌هایی با پسوند `.pptx`—در فرمت PresentationML ذخیره می‌شوند که بخشی از مشخصات Office Open XML است. Office Open XML ساختار بسته و روابطی را که برای ذخیره محتوای ارائه و داده‌های مرتبط استفاده می‌شود، تعریف می‌کند.

یک ارائه شامل بخش‌های متعددی است که توسط روابط به هم متصل می‌شوند. برای مثال، یک بخش اسلاید شامل محتوای یک اسلاید است و می‌تواند روابط صریحی به بخش‌های دیگر داشته باشد که توسط ISO/IEC 29500 تعریف شده‌اند.

داده‌های سفارشی می‌توانند به صورت برچسب‌ها ([ITagCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ITagCollection)) یا بخش‌های XML سفارشی ([ICustomXmlPartCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ICustomXmlPartCollection)) ذخیره شوند. هر دو از طریق اینترفیس [`ICustomData`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ICustomData/) در دسترس هستند.

{{% alert color="info" %}}
برچسب‌ها جفت‌های کلید‑مقدار رشته‌ای ساده را ذخیره می‌کند. بخش‌های XML سفارشی داده‌های XML ساختاریافته را ذخیره می‌کند و می‌توانند به یک ارائه، اسلاید یا شکل مرتبط شوند.
{{% /alert %}}

## **کار با بخش‌های XML سفارشی**

متد [`ICustomData.getCustomXmlParts()`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ICustomData#getCustomXmlParts--) مجموعهٔ بخش‌های XML سفارشی مرتبط با یک شیء خاص ارائه را برمی‌گرداند. برای مثال:

- `presentation.getCustomData().getCustomXmlParts()` بخش‌های XML سفارشی مرتبط با خود ارائه را شامل می‌شود.
- `slide.getCustomData().getCustomXmlParts()` بخش‌های XML سفارشی مرتبط با یک اسلاید خاص را شامل می‌شود.
- `shape.getCustomData().getCustomXmlParts()` بخش‌های XML سفارشی مرتبط با یک شکل خاص را شامل می‌شود.

از [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) زمانی که نیاز به بررسی تمام بخش‌های XML سفارشی در ارائه دارید، صرف‌نظر از اینکه در کجا مرتبط شده‌اند، استفاده کنید.

### **افزودن یک بخش XML سفارشی به یک ارائه**

از [`ICustomXmlPartCollection.add`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ICustomXmlPartCollection#add-java.lang.String-) برای افزودن داده XML به مجموعهٔ بخش‌های XML سفارشی استفاده کنید. XML باید معتبر و غیر خالی باشد.

مثال زیر متادیتای ساختاریافته را به مجموعهٔ داده سفارشی سطح ارائه اضافه می‌کند:

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

    // add به‌طور خودکار یک شناسه اختصاص می‌دهد. فقط در صورت نیاز یک UUID خاص تنظیم کنید.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

متد `add` همچنین می‌تواند XML را به صورت آرایهٔ بایت یا جریان ورودی بپذیرد که زمانی مفید است که محتوای XML قبلاً به شکل باینری موجود باشد.

### **افزودن یک بخش XML سفارشی به اسلاید یا شکل**

دادهٔ XML سفارشی می‌تواند به یک اسلاید یا شکل خاص به جای کل ارائه مرتبط شود. این برای مواردی مفید است که متادیتا فقط یک شیء را توصیف می‌کند، مانند کلید قالب، شناسهٔ رکورد خارجی یا اطلاعات بایندینگ.

مثال زیر یک بخش XML سفارشی به یک اسلاید و یک بخش دیگر به یک شکل اضافه می‌کند:

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

سطحی که یک بخش در آن اضافه می‌شود تعیین می‌کند کدام مجموعهٔ `getCustomData().getCustomXmlParts()` متعلق به کدام شیء شامل رابطه به آن بخش است. داده‌های سطح ارائه برای متادیتای سراسری سند مناسب هستند، داده‌های سطح اسلاید برای اطلاعاتی که به اسلاید خاصی تعلق دارند، و داده‌های سطح شکل برای متادیتایی که به یک شکل فردی پیوند دارد.

### **فهرست و بررسی تمام بخش‌های XML سفارشی**

از [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) برای بازیابی تمام بخش‌های XML سفارشی از یک ارائه استفاده کنید. هر [`ICustomXmlPart`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ICustomXmlPart/) شناسه، محتوای XML و طرح‌نامه‌های فضای نام مرتبط را ارائه می‌دهد.

مثال زیر تمام بخش‌های XML سفارشی و طرح‌نامه‌های فضای نام آن‌ها را فهرست می‌کند:

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

[`ICustomXmlPart.getNamespaceSchemas()`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ICustomXmlPart#getNamespaceSchemas--) طرح‌نامه‌های XML مرتبط با بخش XML سفارشی را برمی‌گرداند. این اطلاعات می‌تواند هنگام بررسی ارائه‌هایی که XML تولید شده توسط سیستم‌های خارجی را شامل می‌شوند، مفید باشد.

### **خواندن و بروزرسانی محتوای XML و ItemId**

از [`ICustomXmlPart.getXmlAsString()`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ICustomXmlPart#getXmlAsString--) و [`setXmlAsString()`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ICustomXmlPart#setXmlAsString-java.lang.String-) برای کار با XML به صورت رشتهٔ UTF‑8، یا از [`getXmlData()`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ICustomXmlPart#getXmlData--) و [`setXmlData()`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ICustomXmlPart#setXmlData-byte:A-) برای کار با بایت‌های خام XML استفاده کنید.

متد [`ICustomXmlPart.getItemId()`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ICustomXmlPart#getItemId--) UUID شناسائی‌کنندهٔ بخش XML سفارشی را در سند Office Open XML بر می‌گرداند. هنگامیکه یک ادغام به شناسه جدیدی نیاز دارد، از [`setItemId()`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ICustomXmlPart#setItemId-java.util.UUID-) استفاده کنید.

مثال زیر محتوای XML و شناسه را به‌روز می‌کند:

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

    // XML را به‌عنوان رشته UTF-8 به‌روزرسانی کنید.
    customXmlPart.setXmlAsString(
        "<metadata xmlns=\"urn:example:metadata\">" +
            "<documentId>DOC-1001</documentId>" +
            "<workflowState>Approved</workflowState>" +
        "</metadata>");

    // متد getXmlData همان محتوای XML را به‌صورت بایت‌های خام ارائه می‌دهد.
    byte[] customXmlData = customXmlPart.getXmlData();
    System.out.println(new String(customXmlData, StandardCharsets.UTF_8));

    // شناسه را زمانی که ادغام نیاز دارد، جایگزین کنید.
    customXmlPart.setItemId(UUID.randomUUID());

    presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

هنگام فراخوانی `setXmlAsString` یا `setXmlData`، XML معتبر و غیر خالی ارائه دهید. بسته به این‌که برنامه عمدتاً با رشته‌ها یا داده‌های بایتی کار می‌کند، یکی از این دو نمایه را استفاده کنید.

### **حذف یک بخش XML سفارشی**

Aspose.Slides چندین روش برای حذف دادهٔ XML سفارشی ارائه می‌دهد:

- [`ICustomXmlPart.remove`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ICustomXmlPart#remove--) بخش XML سفارشی را از ارائه حذف می‌کند.
- [`ICustomXmlPartCollection.remove`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ICustomXmlPartCollection#remove-com.aspose.slides.ICustomXmlPart-) یک بخش خاص را از مجموعهٔ بخش‌های XML سفارشی حذف می‌کند.
- [`ICustomXmlPartCollection.removeAt`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ICustomXmlPartCollection#removeAt-int-) بخش را در ایندکس مشخصی از مجموعه حذف می‌کند.
- [`ICustomXmlPartCollection.clear`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ICustomXmlPartCollection#clear--) تمام بخش‌ها را از یک مجموعه خاص حذف می‌کند.

مثال زیر یک بخش XML سفارشی سطح ارائه را از طریق ارجاع حذف می‌کند:

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

اگر قبلاً یک `ICustomXmlPart` داشته باشید و بخواهید آن را از ارائه حذف کنید نه اینکه به مجموعهٔ خاصی مراجعه کنید، `customXmlPart.remove()` را فراخوانی کنید.

همچنین می‌توانید یک مورد را بر اساس ایندکس حذف کنید:

```java
presentation.getCustomData().getCustomXmlParts().removeAt(0);
```

### **خالی کردن تمام بخش‌های XML سفارشی از یک مجموعه**

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

`clear` فقط بر مجموعهٔ انتخاب‌شده اثر می‌گذارد. برای مثال، خالی‌سازی مجموعهٔ یک اسلاید، مجموعهٔ سطح ارائه یا سطح شکل را پاک نمی‌کند.

برای حذف همهٔ بخش‌های XML سفارشی در ارائه، روی `getAllCustomXmlParts()` پیمایش کنید و هر بخش را حذف کنید:

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

### **مدیریت بخش‌های XML سفارشی پیوند شده یا مشترک**

در یک ارائه Office Open XML، همان بخش XML سفارشی می‌تواند از بیش از یک شیء ارائه ارجاع شود. برای مثال، یک فایل موجود می‌تواند روابطی از چندین اسلاید یا شکل به همان بخش XML سفارشی زیرساختی داشته باشد.

یک بخش مشترک باید به عنوان یک شیء داده با چندین ارجاع رفتار شود:

- به‌روزرسانی آن با `setXmlAsString`، `setXmlData` یا `setItemId` بخش XML زیرساختی را تغییر می‌دهد، بنابراین تغییر در هر جایی که این بخش ارجاع شود اعمال می‌شود.
- `getItemId()` می‌تواند برای شناسایی همان بخش XML سفارشی هنگام ارزیابی مجموعه‌های سطح شیء استفاده شود.
- حذف یک بخش از یک مجموعهٔ خاص `getCustomXmlParts()` آن را فقط از آن مجموعه حذف می‌کند. برای حذف خود بخش از ارائه، `ICustomXmlPart.remove()` را به‌کار ببرید.
- پیش از حذف یا جایگزینی یک بخش مشترک، مجموعه‌های سطح شیء را بررسی کنید تا ببینید آیا اسلایدها یا شکل‌های دیگر هنوز به آن ارجاع می‌دهند یا نه.

بارگذاری‌های `add` یک بخش XML سفارشی جدید از محتوای XML می‌سازند؛ آن‌ها یک `ICustomXmlPart` موجود را نمی‌پذیرند. بنابراین، روابط مشترک بیشتر در زمان بارگذاری ارائه‌هایی که قبلاً شامل آن‌ها هستند، مشاهده می‌شوند.

مثال زیر مجموعه‌های سطح ارائه، اسلاید و شکل را بر اساس `ItemId` ارزیابی می‌کند و بخش‌های ارجاع داده‌شده از بیش از یک مکان را گزارش می‌دهد:

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

این نوع ارزیابی پیش از اصلاح یا حذف دادهٔ XML سفارشی در ارائه‌های تولید شده توسط سیستم‌های خارجی مفید است، زیرا همان بخش متادیتا ممکن است در بیش از یک رابطه شرکت داشته باشد.

## **دریافت مقادیر برچسب‌ها**

در Slides، یک برچسب معادل متد `IDocumentProperties.getKeywords()` است. این نمونه کد نشان می‌دهد چگونه مقدار یک برچسب را با Aspose.Slides برای Android از طریق Java برای [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) دریافت کنید:

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

Aspose.Slides به شما امکان می‌دهد برچسب‌ها را به ارائه‌ها اضافه کنید. یک برچسب معمولاً از دو مورد تشکیل می‌شود:

- نام یک ویژگی سفارشی، برای مثال `MyTag`؛
- مقدار ویژگی سفارشی، برای مثال `My Tag Value`.

اگر نیاز دارید ارائه‌ها را بر اساس قانون یا ویژگی خاصی طبقه‌بندی کنید، می‌توانید برای آن منظور برچسب اضافه کنید. برای مثال، اگر بخواهید ارائه‌های کشورهای آمریکای شمالی را دسته‌بندی کنید، می‌توانید یک برچسب «North American» ایجاد کرده و کشور مربوطه را به‌عنوان مقدار آن تعیین کنید.

این نمونه کد نشان می‌دهد چگونه یک برچسب را به یک [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) با استفاده از Aspose.Slides برای Android از طریق Java اضافه کنید:

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

برچسب‌های اضافه‌شده از طریق مجموعه `getCustomData().getTags()` فقط در فایل PowerPoint ذخیره می‌شوند. آن‌ها **به** ساختار برچسب PDF هنگام صادرات ارائه به PDF منتقل نمی‌شوند. بنابراین، یک شناسهٔ سفارشی که به‌عنوان برچسب اختصاص داده شده است، نمی‌تواند از PDF برچسب‌خورده بازیابی شود.

**راه‌حل**: می‌توانید یک شناسهٔ سفارشی را در **متن جایگزین** شیء (به عنوان مثال `shape.setAlternativeText("MyId")`) ذخیره کنید. پس از صادرات به PDF، متن جایگزین ممکن است در ساختار برچسب PDF ظاهر شود.

## **سؤالات متداول**

**آیا می‌توانم تمام برچسب‌ها را از یک ارائه، اسلاید یا شکل در یک عملیات حذف کنم؟**

بله. مجموعهٔ [tag collection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tagcollection/) از عمل‌گر [clear](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tagcollection/#clear--) پشتیبانی می‌کند که تمام جفت‌های کلید‑مقدار را یک‌بار حذف می‌سازد.

**چگونه می‌توانم یک برچسب واحد را بر اساس نام آن بدون پیمایش کل مجموعه حذف کنم؟**

از `remove(name)` (https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) روی [tag collection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tagcollection/) استفاده کنید تا برچسب را بر اساس کلیدش حذف کنید.

**چگونه می‌توانم فهرست کامل نام‌های برچسب‌ها را برای تجزیه و تحلیل یا فیلتر کردن دریافت کنم؟**

از `getNamesOfTags` (https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) روی [tag collection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/tagcollection/) استفاده کنید؛ این متد آرایه‌ای از تمام نام‌های برچسب را برمی‌گرداند.

**چگونه می‌توانم تمام بخش‌های XML سفارشی را صرف‌نظر از محل ذخیره‌شدنشان پیدا کنم؟**

از [`Presentation.getAllCustomXmlParts()`](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation#getAllCustomXmlParts--) برای بازیابی تمام بخش‌های XML سفارشی در ارائه استفاده کنید.

**آیا باید از `getXmlAsString`/`setXmlAsString` یا `getXmlData`/`setXmlData` برای بروزرسانی یک بخش XML سفارشی استفاده کنم؟**

از `getXmlAsString` و `setXmlAsString` زمانی استفاده کنید که برنامه با متن XML UTF‑8 کار می‌کند. از `getXmlData` و `setXmlData` زمانی استفاده کنید که XML قبلاً به صورت آرایهٔ بایت موجود است یا پردازش باینری راحت‌تر است. هر دو نمایه به محتوای XML همان بخش XML سفارشی اشاره دارند.