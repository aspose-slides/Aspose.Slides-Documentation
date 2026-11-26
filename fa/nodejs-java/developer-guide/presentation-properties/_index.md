---
title: مدیریت ویژگی‌های ارائه در جاوااسکریپت
linktitle: ویژگی‌های ارائه
type: docs
weight: 70
url: /fa/nodejs-java/presentation-properties/
keywords:
- ویژگی‌های پاورپوینت
- ویژگی‌های ارائه
- ویژگی‌های سند
- ویژگی‌های درونی
- ویژگی‌های سفارشی
- ویژگی‌های پیشرفته
- مدیریت ویژگی‌ها
- تغییر ویژگی‌ها
- فرادادهٔ سند
- ویرایش فراداده
- زبان تصحیح
- زبان پیش‌فرض
- پاورپوینت
- OpenDocument
- ارائه
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "ویژگی‌های ارائه را در Aspose.Slides برای Node.js از طریق جاوا به‌طور کامل کنترل کنید و جستجو، برندسازی و جریان کار را در فایل‌های پاورپوینت و OpenDocument خود بهینه‌سازی کنید."
---
## **مقدمه**

Aspose.Slides for Node.js via Java از **درونی** و **سفارشی** ویژگی‌های سند پشتیبانی می‌کند. از این ویژگی‌ها برای خواندن و به‌روزرسانی فراداده ارائه، مانند نویسنده، عنوان و مقادیر تعریف‌شده توسط کاربر استفاده کنید.

Aspose.Slides به شما امکان کار با ویژگی‌های سند ارائه را از طریق کلاس [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) می‌دهد. یک نمونه از این کلاس توسط [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties) برگردانده می‌شود. مثال‌های زیر نشان می‌دهند چگونه این ویژگی‌ها را بخوانید، تغییر دهید و مدیریت کنید.

{{% alert color="info" title="Note" %}}
Aspose.Slides هنگام ذخیره‌سازی ارائه‌ها، متاداده برنامه و تولیدکننده را مدیریت می‌کند؛ این فیلدها نرم‌افزاری را که خروجی را ایجاد کرده شناسایی می‌کنند.
{{% /alert %}}

## **مدیریت ویژگی‌های ارائه**

ویژگی‌های سند اطلاعات توصیفی را در کنار محتوای ارائه ذخیره می‌کنند. آن‌ها به دو دسته تقسیم می‌شوند:

- **ویژگی‌های درونی** شامل فراداده‌های استانداردی مانند عنوان، نویسنده و آمار سند هستند.
- **ویژگی‌های سفارشی** جفت‌های نام/مقدار تعریف‌شده توسط کاربر را ذخیره می‌کنند.

Aspose.Slides for Node.js via Java دسترسی به هر دو دسته را فراهم می‌کند. در PowerPoint، برای بررسی متاداده سند **File → Info → Properties → Advanced Properties** را انتخاب کنید. این گفت‌وگو اطلاعات را در زبانه‌هایی مانند **Summary**, **Statistics**, **Contents**, و **Custom** گروه‌بندی می‌کند. برای مدیریت ویژگی‌های تعریف‌شده توسط کاربر از زبانه **Custom** استفاده کنید.

## **خواندن ویژگی‌های عمومی از یک ارائه رمزگذاری‌شده**

یک رمز عبور باز کردن معمولاً هم محتوای ارائه و هم ویژگی‌های سند را محافظت می‌کند. وقتی یک ارائه پس از فراخوانی [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) با `false` رمزگذاری می‌شود، ویژگی‌های سند آن عمومی می‌مانند. سپس یک برنامه می‌تواند با فراخوانی [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) با `true` متاداده عمومی را بدون وارد کردن رمز عبور باز کردن بخواند.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) تعیین می‌کند که Aspose.Slides چه چیزی را بارگذاری می‌کند؛ این عمل هیچ چیزی را رمزگشایی نمی‌کند. اگر ویژگی‌ها در رمزگذاری گنجانده شوند، بارگذاری آن‌ها بدون رمز عبور شکست می‌خورد. اگر ارائه رمزگذاری نشده باشد، این گزینه نادیده گرفته می‌شود و ارائه کامل بارگذاری می‌شود.

این مثال نیاز به یک ارائه رمزگذاری‌شده دارد که ویژگی‌های سند آن عمومی باقی مانده‌اند. حالت بارگذاری را از طریق [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) بررسی می‌کند و سپس ویژگی‌های درونی را از طریق [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties) می‌خواند:

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

در این حالت، محتوای اسلاید بارگذاری نمی‌شود. اسلایدها، مسترها، طرح‌بندی‌ها، شکل‌ها، رسانه‌ها و سایر اشیای ارائه در دسترس نیستند. برنامه‌ها باید همیشه قبل از انجام عملی که نیاز به مدل شیء کامل ارائه دارد، [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#isOnlyDocumentPropertiesLoaded) را بررسی کنند.

{{% alert color="warning" title="Warning" %}}
متاداده عمومی ممکن است نام‌های نویسنده، عناوین، موضوعات، کلیدواژه‌ها، اطلاعات شرکت، نظرات و مقادیر سفارشی را فاش کند. ویژگی‌های حساس را همراه با ارائه رمزگذاری کنید. تنها زمانی که سامانه‌های فهرست‌گذاری، طبقه‌بندی، جستجو یا مدیریت سند نیاز خاصی به دسترسی بدون رمز عبور داشته باشند، آن‌ها را عمومی نگه دارید.
{{% /alert %}}

## **به‌روزرسانی ویژگی‌های یک ارائه رمزگذاری‌شده**

برای یک فایل PPTX رمزگذاری‌شده، ارائه‌ای که پس از فراخوانی [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) با `true` بارگذاری می‌شود، برای خواندن متاداده عمومی هدف دارد. Aspose.Slides نمی‌تواند ویژگی‌های تغییر یافته را از آن شیء فقط‑متاداده ذخیره کند زیرا ویژگی‌های عمومی باید با داده‌های مربوطه داخل ارائه رمزگذاری‌شده سازگار بمانند. بنابراین به‌روزرسانی آن‌ها نیاز به رمز عبور صحیح باز کردن و بارگذاری کامل دارد.

این مثال نیاز به یک ارائه PPTX رمزگذاری‌شده با ویژگی‌های سند عمومی و یک رمز عبور باز کردن شناخته‌شده دارد. با استفاده از [LoadOptions.setPassword](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setPassword) ارائه کامل را باز می‌کند، ویژگی‌های درونی عمومی را به‌روزرسانی کرده و نتیجه را ذخیره می‌کند. سپس با [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#isEncrypted) بررسی می‌کند که رمزگذاری حفظ شده و متاداده عمومی را بدون رمز عبور مجدداً باز می‌کند تا مقادیر جدید را تأیید کند:

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

اگر برنامه‌ای اجازهٔ رمزگشایی یا بارگذاری محتوای ارائه را نداشته باشد، باید ویژگی‌های عمومی یک فایل PPTX رمزگذاری‌شده را به‌عنوان فقط‑خواندنی در نظر بگیرد.

## **دسترسی به ویژگی‌های درونی**

کلاس [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) فراداده‌های درونی را از طریق متدهای getter افشا می‌کند، از جمله [getAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getAuthor)، [getTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getTitle) و [getCreatedTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCreatedTime). این مثال یک ارائه موجود را باز می‌کند و فراداده‌های ذخیره‌شده آن را در کنسول چاپ می‌کند. مقادیر بسته به ارائه ورودی متفاوت است؛ برخی فیلدها ممکن است خالی باشند.

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

### **گزارش شماره بازبینی و زمان ویرایش**

برای گزارش شماره بازبینی و زمان کل ویرایش هر فایل PPTX در پوشهٔ `presentations`، از [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties) استفاده کنید. این متد [DocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties) فایل را بدون بارگذاری اسلایدها برای ویرایش برمی‌گرداند. مثال مدت زمان ثبت‌شده را از میلی‌ثانیه به ساعت، دقیقه و ثانیه تبدیل می‌کند. برای مدت‌های ۲۴ ساعت یا بیشتر، زمان را با تعداد روزهای کامل پیشوند می‌دهد.

```javascript
const fs = require("fs");
const path = require("path");
const slides = require("aspose.slides.via.java");

const folder = "presentations";
const files = fs.readdirSync(folder, { withFileTypes: true });
const factory = slides.PresentationFactory.getInstance();

console.log("File | RevisionNumber | TotalEditingTime");
for (const file of files) {
    if (!file.isFile() || path.extname(file.name).toLowerCase() !== ".pptx") {
        continue;
    }
    const filePath = path.join(folder, file.name);
    const info = factory.getPresentationInfo(filePath);
    const properties = info.readDocumentProperties();
    const totalSeconds = Math.floor(properties.getTotalEditingTime() / 1000);
    const days = Math.floor(totalSeconds / 86400);
    const hours = Math.floor(totalSeconds / 3600) % 24;
    const minutes = Math.floor(totalSeconds / 60) % 60;
    const seconds = totalSeconds % 60;
    const time = [hours, minutes, seconds].map(value => String(value).padStart(2, "0")).join(":");
    const editingTime = days > 0 ? `${days}.${time}` : time;
    console.log(`${file.name} | ${properties.getRevisionNumber()} | ${editingTime}`);
}
```

برای یک ارائه با زمان ویرایش ثبت‌شده ۱ روز، ۲ ساعت و ۵ دقیقه، گزارش خروجی زیر را نشان می‌دهد.

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[getRevisionNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getRevisionNumber) مقداری را می‌خواند که برنامه‌ها می‌توانند با [setRevisionNumber](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setRevisionNumber) تغییر دهند. تنها داشتن شماره بازبینی نمی‌تواند تعداد دفعات ذخیره‌سازی ارائه یا تاریخچه نسخهٔ آن را بازسازی کند.

[getTotalEditingTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getTotalEditingTime) مدت زمان ویرایشی ثبت‌شده در فایل را می‌خواند. مقدار `00:00:00` به این معنی است که مدت زمان ذخیره‌شده صفر است، حتی اگر کسی ارائه را ویرایش کرده باشد.

## **تغییر ویژگی‌های درونی**

برای به‌روزرسانی فراداده‌های درونی، از متدهای setter بر روی شیء برگردانده‌شده توسط [Presentation.getDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDocumentProperties) استفاده کنید. این مثال یک ارائه موجود را باز می‌کند، [setAuthor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setAuthor)، [setTitle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setTitle)، [setSubject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setSubject)، [setComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setComments) و [setManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setManager) را فراخوانی می‌کند، سپس ارائه به‌روز شده را با [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save) ذخیره می‌کند. فایل PPTX ذخیره‌شده شامل فرادادهٔ جدید خواهد بود.

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

## **مدیریت پایهٔ پیوندهای فرامتن (Hyperlink Base)**

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getHyperlinkBase) پایهٔ سطح سند برای پیوندهای نسبی را برمی‌گرداند. برای تغییر یا پاک‌کردن آن از [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setHyperlinkBase) استفاده کنید. این کار زمانی مفید است که یک ارائه و فایل‌های پیوندی‌اش را به مکان دیگری منتقل می‌کنید. این ویژگی جدا از [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) یک پیوند فردی است: تغییر پایه آدرس‌های ذخیره‌شدهٔ پیوند را بازنویسی نمی‌کند و مقصدهای مطلق را تغییر نمی‌دهد.

این مثال نیاز به یک ارائه دارد که هم یک پیوند نسبی مانند `target.html` و هم یک پیوند مطلق مانند `https://example.org/absolute.html` داشته باشد. پایهٔ موجود را می‌خواند، پایهٔ جدیدی انتساب می‌دهد و ارائه را ذخیره و دوباره باز می‌کند تا مقدار را بررسی کند. سپس پایه را با رشتهٔ خالی پاک می‌کند و مقدار خالی را در یک فایل ذخیره‌شدهٔ جداگانه تأیید می‌کند. پایهٔ مثال را با مسیر فایل‌های پیوندی خود جایگزین کنید.

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

دو پیام تأیید باید `true` چاپ کنند. پاک‌کردن پایه آدرس‌های پیوندهای فردی را دست نخورده می‌گذارد.

یک پیوند نسبی به `target.pptx` زمانی که پایه به پوشهٔ `old` اشاره می‌کرد، `old/target.pptx` را باز می‌کرد. پس از تغییر پایه به پوشهٔ `new`، ذخیره و باز کردن مجدد ارائه، همان پیوند `new/target.pptx` را باز می‌کرد. یک پیوند مطلق همان فایل را باز نگه می‌داشت. پیوندهای نسبی خود را در PowerPoint قبل و بعد از جابجایی ارائه یا تغییر پایه تست کنید.

## **افزودن ویژگی‌های سفارشی به ارائه**

ویژگی‌های سفارشی فراداده‌ای را ذخیره می‌کنند که فیلد درونی متناظری ندارند. متد [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item) به شما اجازه می‌دهد مقدار را بر اساس نام ویژگی اختصاص دهید. این مثال یک ارائه ایجاد می‌کند، دو مقدار متنی و یک مقدار نسخه عددی اضافه می‌کند و ارائه را با [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save) ذخیره می‌کند. اختصاص مقدار به یک نام موجود، مقدار آن ویژگی را بازنویسی می‌کند.

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

## **دسترسی و تغییر ویژگی‌های سفارشی**

این مثال یک ارائه حاوی ویژگی‌های سفارشی را باز می‌کند و با استفاده از [getCountOfCustomProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCountOfCustomProperties) بر روی آن‌ها تکرار می‌نماید. [getCustomPropertyName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getCustomPropertyName) یک شاخص صفر‑پایه می‌گیرد و نامی را برمی‌گرداند که توسط [DocumentProperties.set_Item](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#set_Item) استفاده می‌شود. مثال هر نام و مقدار اصلی را چاپ می‌کند، هر مقدار را با یک رشتهٔ شماره‌دار صرف‌نظر از نوع اصلی آن جایگزین می‌کند و تغییرات را ذخیره می‌کند. اگر ویژگی سفارشی‌ای وجود نداشته باشد، حلقه هیچ تغییری اعمال نمی‌کند.

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

برنامهٔ آنلاین [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) را امتحان کنید تا ببینید چگونه با استفاده از API Aspose.Slides می‌توانید با ویژگی‌های سند کار کنید:

[![مشاهده و ویرایش فراداده پاورپوینت](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **سوالات متداول**

**چگونه می‌توانم یک ویژگی درونی را از یک ارائه حذف کنم؟**

ویژگی‌های درونی جزئی جدایی‌ناپذیر از ارائه هستند و نمی‌توانند به‌طور کامل حذف شوند. با این حال، می‌توانید مقادیر آن‌ها را تغییر دهید یا در صورت اجازهٔ ویژگی خاص، آن را خالی کنید.

**اگر یک ویژگی سفارشی که از قبل وجود دارد را اضافه کنم چه می‌شود؟**

اگر یک ویژگی سفارشی که از قبل وجود دارد را اضافه کنید، مقدار موجود آن با مقدار جدید بازنویسی می‌شود. نیازی به حذف یا بررسی پیش‌از‌این ویژگی ندارید، زیرا Aspose.Slides به‌صورت خودکار مقدار ویژگی را به‌روز می‌کند.

**آیا می‌توانم ویژگی‌های ارائه را بدون بارگذاری کامل ارائه دسترسی پیدا کنم؟**

بله. از [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationFactory#getPresentationInfo) استفاده کنید و سپس [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties) را برای خواندن متادادهٔ ذخیره‌شدهٔ سند بدون ایجاد نمونهٔ [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) فراخوانی کنید. برای مثال کامل گزارش‌گیری و محدودیت‌های خاص فرمت به مقالهٔ [Build a Lightweight Presentation Inventory](/slides/fa/nodejs-java/examine-presentation/) مراجعه کنید.

**آیا می‌توانم ویژگی‌های عمومی یک ارائه رمزگذاری‌شده را بدون رمز عبور باز کردن آن بخوانم؟**

بله. ارائه باید پس از فراخوانی [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ProtectionManager#setEncryptDocumentProperties) با `false` رمزگذاری شده باشد و پس از فراخوانی [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/LoadOptions#setOnlyLoadDocumentProperties) با `true` بارگذاری شود.

**آیا می‌توانم یک فایل PPTX رمزگذاری‌شده را در حالت فقط‑بارگذاری‑ویژگی‑سند به‌روزرسانی کنم؟**

خیر. داده‌های عمومی و رمزگذاری‌شده باید سازگار بمانند، بنابراین به‌روزرسانی یک فایل PPTX رمزگذاری‌شده نیازمند بارگذاری کامل ارائه با رمز عبور صحیح باز کردن است.