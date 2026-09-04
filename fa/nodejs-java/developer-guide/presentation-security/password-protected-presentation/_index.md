---
title: محافظت با رمز عبور از ارائه‌ها در جاوااسکریپت
linktitle: حفاظت با رمز عبور
type: docs
weight: 20
url: /fa/nodejs-java/password-protected-presentation/
keywords:
- ارائهٔ محافظت‌شده با رمز عبور
- رمز عبور باز کردن
- رمزنگاری پاورپوینت
- رمزگشایی پاورپوینت
- اعتبارسنجی رمز عبور ارائه
- بررسی رمز عبور ارائه
- بازکردن ارائهٔ رمزنگاری‌شده
- حذف رمزنگاری
- پاورپوینت
- PPT
- PPTX
- ارائه
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "رمزنگاری، شناسایی، اعتبارسنجی، باز کردن و رمزگشایی ارائه‌های پاورپوینت PPT و PPTX محافظت‌شده با رمز عبور در جاوااسکریپت با Aspose.Slides."
---
## **نمای کلی**

یک رمز عبور باز کردن یک ارائه را رمزنگاری می‌کند. برای بارگذاری و مشاهده محتوای ارائه، رمز عبور صحیح لازم است، بنابراین این حفاظت حفظ محرمانگی را فراهم می‌کند.

رمز عبور باز کردن با رمز عبور جلوگیری از نوشتن متفاوت است. جلوگیری از نوشتن فقط اصلاح را محدود می‌کند ولی محتوا را رمزنگاری نمی‌کند و مانع بارگذاری ارائه نمی‌شود. برای مدیریت رمزهای عبور جهت اصلاح ارائه‌ها، به [Write-Protect Presentations](/slides/fa/nodejs-java/write-protected-presentation/) مراجعه کنید.

جریان‌های کاری زیر برای هر دو نوع ارائه PPT و PPTX اعمال می‌شوند. مثال‌ها از هر دو قالب استفاده می‌کنند که رفتار مبتنی بر فایل و جریان برای آنها مهم است.

## **رمزنگاری یک ارائه با رمز عبور باز کردن**

از [ProtectionManager.encrypt](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/protectionmanager/#encrypt) برای اختصاص یک رمز عبور باز کردن استفاده کنید. سپس از [Presentation.save](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#save) برای ذخیرهٔ ارائهٔ رمزنگاری‌شده استفاده کنید.

مثال زیر یک ارائهٔ PPTX را رمزنگاری می‌کند:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **خصوصیات سند را عمومی نگه دارید**

به‌صورت پیش‌فرض، Aspose.Slides خصوصیات سند را در رمزنگاری ارائه گنجانده است. متد [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) این رفتار را به‌صورت مستقل از رمزنگاری محتوای اسلایدها کنترل می‌کند. قبل از فراخوانی [ProtectionManager.encrypt](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/protectionmanager/#encrypt) مقدار `false` را پاس کنید، زمانی که سیستم‌های نمایه‌سازی، طبقه‌بندی، جستجو یا مدیریت سند باید متادیتا را بدون رمز عبور باز کردن بخوانند.

مثال زیر یک ارائهٔ PPTX رمزنگاری‌شده ایجاد می‌کند در حالی که خصوصیات داخلی سند آن به‌صورت عمومی باقی می‌مانند:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const properties = presentation.getDocumentProperties();
    properties.setAuthor("Contoso Knowledge Management");
    properties.setTitle("Quarterly Product Roadmap");
    properties.setKeywords("roadmap, planning, internal");

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content");
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("public-properties-encrypted.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ارسال مقدار `false` به [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) اسلایدها، مسترها، چینش‌ها، شکل‌ها، رسانه‌ها یا سایر محتوای ارائه را عمومی نمی‌کند. این فقط بر خصوصیات سند تأثیر می‌گذارد. برای خواندن آن خصوصیات بدون بارگذاری محتوای رمزنگاری‌شده، به [Manage Presentation Properties](/slides/fa/nodejs-java/presentation-properties/) مراجعه کنید.

## **بارگذاری یک ارائهٔ رمزنگاری‌شده**

متد [LoadOptions.setPassword](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/#setPassword) را بر روی رمز عبور باز کردن تنظیم کنید و گزینه‌ها را هنگام بارگذاری فایل به [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) پاس دهید. اگر رمز عبور باز کردن مورد نیاز باشد اما رمز ارائه شده موجود نباشد یا نادرست باشد، بارگذاری شکست می‌خورد.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    // با ارائهٔ رمزگشایی‌شده کار کنید.
} finally {
    presentation.dispose();
}
```

## **حذف رمزنگاری از یک ارائه**

ارائه را با رمز عبور باز کردن آن بارگذاری کنید، متد [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/protectionmanager/#removeEncryption) را فراخوانی کنید و نتیجه را ذخیره کنید. سپس می‌توان ارائهٔ ذخیره‌شده را بدون نیاز به رمز عبور بارگذاری کرد.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **اعتبارسنجی یک رمز عبور باز کردن قبل از بارگذاری**

از [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) برای دریافت [PresentationInfo](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationinfo/) بدون ایجاد یک نمونه کامل از ارائه استفاده کنید. قبل از درخواست یا اعتبارسنجی رمز عبور، [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) را بررسی کنید. وقتی محافظت موجود باشد، مقدار ارائه‌شده را با [PresentationInfo.checkPassword](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationinfo/#checkPassword) اعتبارسنجی کنید.

### **جریان کاری مسیر فایل**

مثال زیر رمز عبور باز کردن را برای یک فایل PPTX اعتبارسنجی می‌کند، مقدار اعتبارسنجی‌شده را به [LoadOptions.setPassword](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/#setPassword) پاس می‌دهد و سپس ارائهٔ کامل را بارگذاری می‌کند:

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "protected-presentation.pptx";
const password = "open_password";
const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    console.log("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    console.log("The opening password is incorrect.");
} else {
    const loadOptions = new slides.LoadOptions();
    loadOptions.setPassword(password);

    const presentation = new slides.Presentation(filePath, loadOptions);
    try {
        console.log("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **جریان کاری جریان**

از [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) برای بررسی یک جریان قابل خواندن Node.js استفاده کنید. پس از مصرف شدن جریان بازرسی، پیش از بارگذاری ارائهٔ کامل با [Presentation.createPresentationFromStream](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#createPresentationFromStream) یک جریان جدید ایجاد کنید.

مثال زیر از یک فایل PPT استفاده می‌کند:

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");

const filePath = "protected-presentation.ppt";
const password = "open_password";
const presentationFactory = slides.PresentationFactory.getInstance();
const infoStream = fs.createReadStream(filePath);

slides.PresentationFactory.getPresentationInfoFromStream(presentationFactory, infoStream, function(infoError, presentationInfo) {
    if (infoError) {
        console.log("The presentation information could not be read: " + infoError.message);
    } else if (!presentationInfo.isPasswordProtected()) {
        console.log("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        console.log("The opening password is incorrect.");
    } else {
        const loadOptions = new slides.LoadOptions();
        loadOptions.setPassword(password);
        const presentationStream = fs.createReadStream(filePath);

        slides.Presentation.createPresentationFromStream(presentationStream, loadOptions, function(loadError, presentation) {
            if (loadError) {
                console.log("The presentation could not be loaded: " + loadError.message);
            } else {
                try {
                    console.log("The presentation was validated and loaded successfully.");
                } finally {
                    presentation.dispose();
                }
            }
        });
    }
});
```

### **مقادیر بازگشتی checkPassword**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationinfo/#checkPassword) فقط زمانی که ارائه دارای رمز عبور باز کردن باشد و رمز ارائه‌شده صحیح باشد مقدار `true` را برمی‌گرداند. در هر یک از موارد زیر مقدار `false` باز می‌گردد:

- رمز عبور نادرست است.
- ارائه رمز عبور باز کردن ندارد.
- رمز عبور ارائه‌شده `null` یا خالی است.

رفتار برای ارائه‌های PPT و PPTX یکسان است.

## **بررسی اینکه آیا یک ارائهٔ بارگذاری‌شده رمزنگاری شده است یا نه**

پس از بارگذاری یک ارائه با رمز عبور صحیح، [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/protectionmanager/#isEncrypted) را بررسی کنید تا تأیید کنید که ارائهٔ منبع رمزنگاری شده است. برای کشف محافظت با رمز عبور باز کردن قبل از بارگذاری، همان‌طور که در بالا نشان دادیم، از [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) استفاده کنید.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    const isEncrypted = presentation.getProtectionManager().isEncrypted();
    console.log("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **توصیه‌های امنیتی**

{{% alert color="warning" title="Security" %}}
رمزهای عبور باز کردن را لاگ نکنید و در پیام‌های تشخیص خطا وارد نکنید. از تلاش‌های تکراری و غیرضروری برای اعتبارسنجی جلوگیری کنید، رمزها را در حافظه فقط تا زمانی که نیاز است نگه دارید، و پس از اعتبارسنجی موفق، نتیجهٔ آن را هنگام بارگذاری فوری ارائه دوباره استفاده کنید.

خصوصیات عمومی سند ممکن است نام مؤلفان، عناوین، موضوعات، کلیدواژه‌ها، اطلاعات شرکت، نظرات و مقادیر سفارشی را حتی با وجود رمزنگاری محتوای ارائه، فاش کند. متادیتای حساس را همراه با ارائه رمزنگاری کنید. نگه داشتن خصوصیات به‌صورت عمومی باید تصمیم صریحی باشد که فقط زمانی اتخاذ می‌شود که سامانه‌ها برای فهرست‌گذاری، طبقه‌بندی، جستجو یا مدیریت فایل بدون نیاز به رمز عبور باز کردن ضرورت داشته باشند.
{{% /alert %}}

## **حفاظت با رمز عبور از یک ارائه به‌صورت آنلاین**

1. برنامهٔ [Aspose.Slides Lock](https://products.aspose.app/slides/fa/lock) را باز کنید.
2. ارائه را انتخاب یا بارگذاری کنید.
3. رمز عبوری برای محافظت از نمایش وارد کنید.
4. به‌صورت اختیاری رمز عبور جداگانه‌ای برای محافظت از ویرایش وارد کنید.
5. محافظت را اعمال کنید و فایل حاصل را دانلود کنید.

{{% alert color="info" title="See also" %}}
- [جلوگیری از نوشتن در ارائه‌ها](/slides/fa/nodejs-java/write-protected-presentation/)
- [امضای دیجیتال در پاورپوینت](/slides/fa/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **سوالات متداول**

**What is the difference between an opening password and a write-protection password?**

یک رمز عبور باز کردن ارائه را رمزنگاری می‌کند و برای بارگذاری محتوای آن لازم است. یک رمز عبور جلوگیری از نوشتن فقط اصلاح را محدود می‌کند بدون اینکه محتوا را رمزنگاری کند.

**Can I validate an opening password without loading all slides?**

بله. اطلاعات ارائه را دریافت کنید، بررسی کنید آیا حفاظت با رمز عبور باز کردن وجود دارد یا نه، و قبل از ایجاد یک نمونه کامل از ارائه، رمز را اعتبارسنجی کنید.

**Can an application read metadata without the opening password?**

بله، اما فقط زمانی که ارائه با رمزنگاری خصوصیات سند غیرفعال شده باشد. سپس برنامه باید از حالت بارگذاری فقط‑خصوصیات‑سند توصیف شده در [Manage Presentation Properties](/slides/fa/nodejs-java/presentation-properties/) استفاده کند.

**Do the password-checking workflows support both PPT and PPTX?**

بله. شناسایی و اعتبارسنجی رمز عبور به‌صورت مسیر‑فایل و جریان برای هر دو نوع PPT و PPTX به‌یک شکل رفتار می‌کند.