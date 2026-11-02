---
title: مدیریت خواص ارائه در JavaScript
linktitle: خواص ارائه
type: docs
weight: 70
url: /fa/nodejs-java/presentation-properties/
keywords:
- خواص PowerPoint
- خواص ارائه
- خواص سند
- خواص داخلی
- خواص سفارشی
- خواص پیشرفته
- مدیریت خواص
- تغییر خواص
- فراداده سند
- ویرایش فراداده
- زبان تصحیح
- زبان پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "بهینه‌سازی خواص ارائه در Aspose.Slides برای Node.js از طریق Java و ساده‌سازی جستجو، برندینگ و گردش کار در فایل‌های PowerPoint و OpenDocument شما."
---
## **معرفی**

Aspose.Slides برای Node.js از طریق Java از **درون‌ساز** و **سفارشی** خواص اسناد پشتیبانی می‌کند. از این خواص برای خواندن و به‌روزرسانی فرادادهٔ ارائه‌نامه، مانند نویسنده، عنوان و مقادیر تعریف‌شده توسط کاربر استفاده کنید.

Aspose.Slides به شما امکان کار با خواص اسناد ارائه را از طریق کلاس [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) فراهم می‌کند. یک نمونه از این کلاس توسط [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties) برگردانده می‌شود. مثال‌های زیر نشان می‌دهند چگونه این خواص را بخوانید، تغییر دهید و مدیریت کنید.

{{% alert color="info" title="Note" %}}
Aspose.Slides هنگام ذخیرهٔ ارائه‌ها، فرادادهٔ برنامه و تولیدکننده را مدیریت می‌کند؛ این فیلدها نرم‌افزاری که خروجی را ایجاد کرده است شناسایی می‌کنند.
{{% /alert %}}

## **مدیریت خواص ارائه**

خواص اسناد اطلاعات توصیفی را همراه با محتوای ارائه ذخیره می‌کنند. آنها به دو دسته تقسیم می‌شوند:

- **خواص داخلی** شامل فرادادهٔ استاندارد هستند، مانند عنوان، نویسنده و آمار سند.
- **خواص سفارشی** جفت‌های نام/مقدار تعریف‌شده توسط کاربر را ذخیره می‌کنند.

Aspose.Slides برای Node.js از طریق Java دسترسی به هر دو دسته را فراهم می‌کند. در PowerPoint، برای بررسی فرادادهٔ سند، **File → Info → Properties → Advanced Properties** را انتخاب کنید. این گفت‌وگو اطلاعات را در برگه‌هایی مانند **Summary**، **Statistics**، **Contents** و **Custom** دسته‌بندی می‌کند. برای مدیریت خواص تعریف‌شده توسط کاربر، از برگهٔ **Custom** استفاده کنید.

## **خواندن خواص عمومی از یک ارائهٔ رمزگذاری‌شده**

رمز عبور باز کردن به‌طور معمول محتوای ارائه و خواص اسناد را محافظت می‌کند. وقتی ارائه پس از فراخوانی [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) با مقدار `false` رمزگذاری شود، خواص اسناد آن به‌صورت عمومی باقی می‌مانند. سپس یک برنامه می‌تواند [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) را با مقدار `true` فراخوانی کند و فرادادهٔ عمومی را بدون ارائهٔ رمز عبور باز کردن بخواند.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) کنترل می‌کند Aspose.Slides چه چیزی را بارگذاری می‌کند؛ هیچ چیزی را رمزگشایی نمی‌کند. اگر خواص در رمزگذاری گنجانده شوند، بارگذاری آنها بدون رمز عبور شکست می‌خورد. اگر ارائه رمزگذاری نشده باشد، گزینه نادیده گرفته می‌شود و ارائهٔ کامل بارگذاری می‌شود.

این مثال به ارائهٔ رمزگذاری‌شده‌ای نیاز دارد که خواص اسناد آن عمومی باقی مانده باشد. حالت بارگذاری را از طریق [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) تأیید می‌کند و سپس خواص داخلی را از طریق [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties) می‌خواند:

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new slides.Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        const documentProperties = presentation.getDocumentProperties();

        console.log("Author: " + documentProperties.getAuthor());
        console.log("Title: " + documentProperties.getTitle());
        console.log("Keywords: " + documentProperties.getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

در این حالت، محتوای اسلاید بارگذاری نمی‌شود. اسلایدها، استادان (masters)، طرح‌ها (layouts)، اشکال، رسانه و سایر اشیاء ارائه در دسترس نیستند. برنامه‌ها باید همیشه قبل از انجام عملی که به مدل شیء کامل ارائه نیاز دارد، [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) را بررسی کنند.

{{% alert color="warning" title="Warning" %}}
فرادادهٔ عمومی ممکن است نام نویسندگان، عناوین، موضوعات، کلمات کلیدی، اطلاعات شرکت، نظرات و مقادیر سفارشی را فاش کند. خواص حساس را همراه با ارائه رمزگذاری کنید. آنها را عمومی بگذارید فقط زمانی که سیستم‌های ایندکس‌گذاری، طبقه‌بندی، جستجو یا مدیریت سند نیاز خاصی به دسترسی بدون رمز عبور داشته باشند.
{{% /alert %}}

## **به‌روزرسانی خواص یک ارائهٔ رمزگذاری‌شده**

برای فایل PPTX رمزگذاری‌شده، ارائه‌ای که پس از فراخوانی [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) با `true` بارگذاری می‌شود، برای خواندن فرادادهٔ عمومی در نظر گرفته شده است. Aspose.Slides نمی‌تواند خواص تغییر یافته را از آن شیء تنها‑متادیتا ذخیره کند، زیرا خواص عمومی باید با داده‌های مربوطه داخل ارائهٔ رمزگذاری‌شده هم‌خوانی داشته باشند. به‌روزرسانی آنها بنابراین به رمز عبور صحیح باز کردن و بارگذاری کامل نیاز دارد.

این مثال به ارائهٔ PPTX رمزگذاری‌شده‌ای نیاز دارد که خواص اسناد عمومی داشته باشد و رمز عبور باز کردن شناخته‌شده‌ای داشته باشد. ابتدا ارائهٔ کامل را با استفاده از [LoadOptions.setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setPassword) باز می‌کند، خواص داخلی عمومی را به‌روزرسانی می‌کند و نتیجه را ذخیره می‌کند. سپس با استفاده از [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#isEncrypted) تأیید می‌کند که رمزگذاری حفظ شده و فرادادهٔ عمومی را بدون رمز عبور باز می‌کند تا مقادیر جدید را بررسی کند:

```javascript
const slides = require("aspose.slides.via.java");

const inputPath = "public-properties-encrypted.pptx";
const outputPath = "updated-public-properties-encrypted.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation(inputPath, loadOptions);
try {
    const documentProperties = presentation.getDocumentProperties();
    documentProperties.setTitle("Updated Product Roadmap");
    documentProperties.setKeywords("roadmap, planning, indexed");
    
    presentation.save(outputPath, slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(outputPath);
console.log("The presentation is encrypted: " + presentationInfo.isEncrypted());

const metadataLoadOptions = new slides.LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

const metadataPresentation = new slides.Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        console.log("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        console.log("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        console.log("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

اگر برنامه اجازهٔ رمزگشایی یا بارگذاری محتوای ارائه را نداشته باشد، باید خواص عمومی یک فایل PPTX رمزگذاری‌شده را به‌عنوان فقط‑خواندنی در نظر بگیرد.

## **دسترسی به خواص داخلی**

کلاس [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) فرادادهٔ داخلی را از طریق متدهای getter مانند [getAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getAuthor)، [getTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getTitle) و [getCreatedTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCreatedTime) در اختیار می‌گذارد. این مثال یک ارائهٔ موجود را باز می‌کند و فرادادهٔ ذخیره‌شدهٔ آن را در کنسول چاپ می‌کند. مقادیر بسته به ارائهٔ ورودی متفاوت هستند؛ برخی فیلدها ممکن است خالی باشند.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AccessBuiltInProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    console.log("Category: " + documentProperties.getCategory());
    console.log("Content status: " + documentProperties.getContentStatus());
    console.log("Creation date: " + documentProperties.getCreatedTime());
    console.log("Author: " + documentProperties.getAuthor());
    console.log("Comments: " + documentProperties.getComments());
    console.log("Keywords: " + documentProperties.getKeywords());
    console.log("Last modified by: " + documentProperties.getLastSavedBy());
    console.log("Manager: " + documentProperties.getManager());
    console.log("Modified date: " + documentProperties.getLastSavedTime());
    console.log("Presentation format: " + documentProperties.getPresentationFormat());
    console.log("Last print date: " + documentProperties.getLastPrinted());
    console.log("Is shared between producers: " + documentProperties.getSharedDoc());
    console.log("Subject: " + documentProperties.getSubject());
    console.log("Title: " + documentProperties.getTitle());
} finally {
    presentation.dispose();
}
```

## **تغییر خواص داخلی**

برای به‌روزرسانی فرادادهٔ داخلی، از متدهای setter روی شیء بازگردانده‌شده توسط [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties) استفاده کنید. این مثال یک ارائهٔ موجود را باز می‌کند، [setAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setAuthor)، [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setTitle), [setSubject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setSubject), [setComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setComments) و [setManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setManager) را فراخوانی می‌کند، سپس ارائهٔ به‌روزرسانی‌شده را با [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save) ذخیره می‌کند. فایل PPTX ذخیره‌شده حاوی متادیتای جدید خواهد بود.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("ModifyBuiltInProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    documentProperties.setAuthor("Aspose.Slides for Node.js via Java");
    documentProperties.setTitle("Manage PowerPoint Presentation Properties");
    documentProperties.setSubject("Modify Built-in Properties");
    documentProperties.setComments("Aspose description");
    documentProperties.setManager("Aspose manager");

    presentation.save("DocumentProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **مدیریت مبنای پیوند (Hyperlink Base)**

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getHyperlinkBase) مبنای سطری سند برای پیوندهای نسبی را برمی‌گرداند. برای تغییر یا پاک کردن آن از [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setHyperlinkBase) استفاده کنید. این ویژگی هنگام جابجایی ارائه و فایل‌های مرتبط به مکان دیگری مفید است. این مورد متفاوت از [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) یک پیوند تک‌تک است: تغییر مبنا آدرس‌های ذخیره‌شدهٔ پیوندها را بازنویسی نمی‌کند و مقصدهای مطلق را تغییر نمی‌دهد.

این مثال به ارائه‌ای نیاز دارد که هم پیوند نسبی مانند `target.html` و هم پیوند مطلق مانند `https://example.org/absolute.html` داشته باشد. مبنای موجود را می‌خواند، مبنای جدیدی اختصاص می‌دهد و برای بررسی مقدار، ارائه را ذخیره و دوباره باز می‌کند. سپس مبنا را با رشتهٔ خالی پاک می‌کند و مقدار خالی را در فایل ذخیره‌شدهٔ جداگانه تأیید می‌کند. آدرس مبنای مثال را با موقعیت فایل‌های پیوندی خود جایگزین کنید.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("hyperlinks.pptx");
try {
    console.log("Original base: " + presentation.getDocumentProperties().getHyperlinkBase());

    const newBase = "https://example.com/new/";
    presentation.getDocumentProperties().setHyperlinkBase(newBase);
    presentation.save("hyperlinks-updated.pptx", slides.SaveFormat.Pptx);

    const updatedPresentation = new slides.Presentation("hyperlinks-updated.pptx");
    try {
        console.log("Base preserved: " + (newBase === updatedPresentation.getDocumentProperties().getHyperlinkBase()));

        updatedPresentation.getDocumentProperties().setHyperlinkBase("");
        updatedPresentation.save("hyperlinks-cleared.pptx", slides.SaveFormat.Pptx);

        const clearedPresentation = new slides.Presentation("hyperlinks-cleared.pptx");
        try {
            console.log("Base cleared: " + ("" === clearedPresentation.getDocumentProperties().getHyperlinkBase()));
        } finally {
            clearedPresentation.dispose();
        }
    } finally {
        updatedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

دو پیام تأیید باید `true` چاپ کنند. پاک کردن مبنا آدرس‌های پیوندهای تک‌تک را دست‌نخورده می‌گذارد.

یک پیوند نسبی به `target.pptx` زمانی که مبنا به پوشهٔ `old` اشاره می‌کرد، `old/target.pptx` را باز می‌کرد. پس از تغییر مبنا به پوشهٔ `new`، ذخیره و باز کردن مجدد ارائه، همان پیوند `new/target.pptx` را باز می‌کرد. یک پیوند مطلق همچنان همان فایل را باز می‌کرد. پیوندهای نسبی خود را در PowerPoint قبل و بعد از جابجایی ارائه یا تغییر مبنا تست کنید.

## **افزودن خواص سفارشی به ارائه**

خواص سفارشی فراداده‌ای را ذخیره می‌کنند که فیلد داخلی متناظر ندارند. متد [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item) به شما امکان می‌دهد مقدار را بر اساس نام خاصیت اختصاص دهید. این مثال یک ارائه ایجاد می‌کند، دو مقدار متنی و یک مقدار عددی نسخه را اضافه می‌کند و ارائه را با [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save) ذخیره می‌کند. اختصاص مقدار به یک نام موجود، مقدار آن خاصیت را جایگزین می‌کند.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const documentProperties = presentation.getDocumentProperties();

    documentProperties.set_Item("Reviewed by", "John Smith");
    documentProperties.set_Item("Confidentiality level", "Internal");
    documentProperties.set_Item("Document version", 2);

    presentation.save("CustomDocumentProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **دسترسی و تغییر خواص سفارشی**

این مثال یک ارائه حاوی خواص سفارشی را باز می‌کند و از [getCountOfCustomProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCountOfCustomProperties) برای پیمایش آن‌ها استفاده می‌نماید. [getCustomPropertyName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCustomPropertyName) یک ایندکس صفر‑مبنا می‌گیرد و نامی را برمی‌گرداند که توسط [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item) استفاده می‌شود. مثال هر نام و مقدار اصلی را چاپ می‌کند، هر مقدار را با رشته‌ای شماره‌دار جایگزین می‌کند، صرف‌نظر از نوع اصلی آن، و تغییرات را ذخیره می‌کند. اگر هیچ خاصیت سفارشی‌ای وجود نداشته باشد، حلقه هیچ تغییری اعمال نمی‌کند.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("AccessAndModifyProperties.pptx");
try {
    const documentProperties = presentation.getDocumentProperties();

    for (let i = 0; i < documentProperties.getCountOfCustomProperties(); i++) {
        const propertyName = documentProperties.getCustomPropertyName(i);
        const propertyValue = documentProperties.get_Item(propertyName);

        console.log("Custom property name: " + propertyName);
        console.log("Custom property value: " + propertyValue);

        documentProperties.set_Item(propertyName, "New Value " + (i + 1));
    }

    presentation.save("CustomProperties_output.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **مثال زنده**

اپلیکیشن آنلاین [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) را امتحان کنید تا ببینید چگونه با استفاده از API Aspose.Slides با خواص اسناد کار می‌کنید:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **سوالات متداول**

**چگونه می‌توان یک خاصیت داخلی را از یک ارائه حذف کرد؟**

خواص داخلی جزئی جدایی‌ناپذیر از ارائه هستند و نمی‌توان آنها را کاملاً حذف کرد. اما می‌توانید مقدارشان را تغییر دهید یا در صورت امکان به مقدار خالی تنظیم کنید.

**اگر یک خاصیت سفارشی که از قبل وجود دارد را اضافه کنم چه می‌شود؟**

اگر خاصیتی را اضافه کنید که از قبل وجود داشته باشد، مقدار موجود آن با مقدار جدید جایگزین می‌شود. نیازی به حذف یا بررسی پیش‌از پیش خاصیت ندارید، زیرا Aspose.Slides به‑صورت خودکار مقدار خاصیت را به‌روز می‌کند.

**آیا می‌توان خواص ارائه را بدون بارگذاری کامل ارائه دسترسی یافت؟**

بله. می‌توانید از [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationFactory#getPresentationInfo) سپس [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties) استفاده کنید تا فرادادهٔ ذخیره‌شدهٔ سند را بدون ایجاد یک نمونهٔ [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) بخوانید. برای مثال کامل گزارش‌گیری به بخش [Build a Lightweight Presentation Inventory](/slides/fa/nodejs-java/examine-presentation/) مراجعه کنید و محدودیت‌های فرمت‑خاص را بررسی کنید.

**آیا می‌توان خواص عمومی یک ارائهٔ رمزگذاری‌شده را بدون رمز عبور باز کردن خواند؟**

بله. ارائه باید پس از فراخوانی [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) با `false` رمزگذاری شده باشد و سپس پس از فراخوانی [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) با `true` بارگذاری شود.

**آیا می‌توان یک فایل PPTX رمزگذاری‌شده را در حالت فقط‑خواندن‑خواص‑سند به‌روزرسانی کرد؟**

خیر. داده‌های عمومی و رمزگذاری‌شده باید سازگار باقی بمانند، بنابراین به‌روزرسانی یک فایل PPTX رمزگذاری‌شده نیازمند بارگذاری کامل ارائه با رمز عبور صحیح باز کردن است.