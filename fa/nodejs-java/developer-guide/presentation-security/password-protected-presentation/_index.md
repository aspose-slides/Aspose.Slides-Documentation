---
title: محافظت با رمز عبور از ارائه‌ها در JavaScript
linktitle: محافظت با رمز عبور
type: docs
weight: 20
url: /fa/nodejs-java/password-protected-presentation/
keywords:
- ارائه محافظت‌شده با رمز عبور
- رمز عبور باز کردن
- رمزنگاری PowerPoint
- رمزگشایی PowerPoint
- اعتبارسنجی رمز عبور ارائه
- بررسی رمز عبور ارائه
- باز کردن ارائه رمزنگاری‌شده
- حذف رمزنگاری
- PowerPoint
- PPT
- PPTX
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "رمزنگاری، شناسایی، اعتبارسنجی، باز کردن و رمزگشایی ارائه‌های PowerPoint PPT و PPTX محافظت‌شده با رمز عبور را در JavaScript با Aspose.Slides انجام دهید."
---
## **بررسی کلی**

یک رمز عبور باز کردن یک ارائه را رمزنگاری می‌کند. برای بارگذاری و مشاهده محتوای ارائه، رمز عبور صحیح لازم است، بنابراین این حفاظت محرمانگی را فراهم می‌کند.

یک رمز عبور باز کردن با رمز عبور محافظت نوشتاری متفاوت است. محافظت نوشتاری تغییرات را محدود می‌کند اما محتوا را رمزنگاری نمی‌کند و مانع بارگذاری ارائه نمی‌شود. برای مدیریت رمزهای عبور جهت تغییر ارائه‌ها، به [Write-Protect Presentations](/slides/fa/nodejs-java/write-protected-presentation/) مراجعه کنید.

روال‌های زیر برای هر دو نوع ارائه PPT و PPTX قابل استفاده هستند. مثال‌ها از هر دو قالب استفاده می‌کنند که رفتار مبتنی بر فایل و مبتنی بر جریان برایشان مهم است.

## **رمزنگاری یک ارائه با رمز عبور باز کردن**

از [ProtectionManager.encrypt](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/protectionmanager/#encrypt) برای اختصاص یک رمز عبور باز کردن استفاده کنید. سپس از [Presentation.save](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#save) برای ذخیرهٔ ارائهٔ رمزنگاری‌شده استفاده کنید.

مثال زیر یک ارائه PPTX را رمزنگاری می‌کند:

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

## **بارگذاری یک ارائهٔ رمزنگاری‌شده**

[LoadOptions.setPassword](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/#setPassword) را به رمز عبور باز کردن تنظیم کنید و هنگام بارگذاری فایل، گزینه‌ها را به [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) پاس بدهید. در صورتی که رمز عبور باز کردن لازم باشد اما رمز فراهم‌شده غیرفعال یا نادرست باشد، بارگذاری ناموفق می‌شود.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    // کار با ارائهٔ رمزگشایی‌شده.
} finally {
    presentation.dispose();
}
```

## **حذف رمزنگاری از یک ارائه**

ارائه را با رمز عبور باز کردن آن بارگذاری کنید، [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/protectionmanager/#removeEncryption) را فراخوانی کنید و نتیجه را ذخیره کنید. پس از ذخیره، می‌توان ارائه را بدون رمز عبور بارگذاری کرد.

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

## **اعتبارسنجی رمز عبور باز کردن قبل از بارگذاری**

از [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) برای دریافت [PresentationInfo](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationinfo/) بدون ساختن یک نمونهٔ کامل از ارائه استفاده کنید. قبل از درخواست یا اعتبارسنجی رمز عبور، [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) را بررسی کنید. هنگامی که حفاظت وجود دارد، مقدار فراهم‌شده را با [PresentationInfo.checkPassword](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationinfo/#checkPassword) اعتبارسنجی کنید.

### **روال مسیر‑فایل**

مثال زیر یک رمز عبور باز کردن برای فایل PPTX را اعتبارسنجی می‌کند، مقدار اعتبارسنجی‌شده را به [LoadOptions.setPassword](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/#setPassword) پاس می‌دهد و سپس ارائهٔ کامل را بارگذاری می‌کند:

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

### **روال جریان**

از [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) برای بررسی یک جریان قابل خواندن Node.js استفاده کنید. پس از مصرف شدن جریان بررسی، قبل از بارگذاری ارائهٔ کامل، یک جریان جدید بسازید و با [Presentation.createPresentationFromStream](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#createPresentationFromStream) بارگذاری کنید.

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

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationinfo/#checkPassword) فقط زمانی که ارائه دارای رمز عبور باز کردن باشد و رمز ارائه‌شده صحیح باشد، `true` برمی‌گرداند. در هر یک از موارد زیر `false` برمی‌گرداند:

- رمز عبور نادرست است.
- ارائه رمز عبور باز کردن ندارد.
- رمز عبور فراهم‌شده `null` یا خالی است.

رفتار برای ارائه‌های PPT و PPTX یکسان است.

## **بررسی اینکه آیا یک ارائه بارگذاری‌شده رمزنگاری شده است**

پس از بارگذاری یک ارائه با رمز صحیح، [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/protectionmanager/#isEncrypted) را بررسی کنید تا تأیید شود که ارائهٔ منبع رمزنگاری شده بود. برای شناسایی حفاظت با رمز عبور باز کردن قبل از بارگذاری، همان‌طور که در بالا نشان داده شد، از [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected) استفاده کنید.

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

## **پیشنهادات امنیتی**

{{% alert color="warning" title="Security" %}}
رمزهای عبور باز کردن را در لاگ‌ها ثبت نکنید و در پیام‌های تشخیصی گنجانده نشوند. از تکرارهای غیرضروری تلاش برای اعتبارسنجی جلوگیری کنید، رمزها را در حافظه فقط به مدت لازم نگه دارید و هنگام بارگذاری فوری ارائه، از نتایج اعتبارسنجی موفق استفاده مجدد کنید.
{{% /alert %}}

## **محافظت از یک ارائه با رمز عبور به‌صورت آنلاین**

1. برنامه [Aspose.Slides Lock](https://products.aspose.app/slides/fa/lock) را باز کنید.
1. ارائه را انتخاب یا بارگذاری کنید.
1. رمز عبوری برای حفاظت از مشاهده وارد کنید.
1. در صورت نیاز رمز عبور جداگانه‌ای برای حفاظت از ویرایش وارد کنید.
1. حفاظت را اعمال کنید و فایل حاصل را دانلود کنید.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/fa/nodejs-java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/fa/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **سوالات متداول**

**تفاوت بین رمز عبور باز کردن و رمز عبور محافظت نوشتاری چیست؟**

یک رمز عبور باز کردن ارائه را رمزنگاری می‌کند و برای بارگذاری محتوا لازم است. یک رمز عبور محافظت نوشتاری تغییرات را محدود می‌کند بدون اینکه محتوا را رمزنگاری کند.

**آیا می‌توانم رمز عبور باز کردن را بدون بارگذاری تمام اسلایدها اعتبارسنجی کنم؟**

بله. اطلاعات ارائه را به‌دست آورید، بررسی کنید که آیا حفاظت با رمز عبور باز کردن وجود دارد یا نه، و قبل از ساختن یک نمونهٔ کامل از ارائه، رمز عبور را اعتبارسنجی کنید.

**آیا روال‌های بررسی رمز عبور برای هر دو قالب PPT و PPTX پشتیبانی می‌شوند؟**

بله. تشخیص و اعتبارسنجی رمز عبور بر مبنای مسیر فایل و بر مبنای جریان برای ارائه‌های PPT و PPTX به‌طور یکسان رفتار می‌کند.