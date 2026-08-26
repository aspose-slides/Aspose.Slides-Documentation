---
title: محافظت نوشتاری ارائه‌ها در جاوا اسکریپت
linktitle: محافظت نوشتاری
type: docs
weight: 25
url: /fa/nodejs-java/write-protected-presentation/
keywords:
- محافظت نوشتاری
- محافظت نوشتاری پاورپوینت
- رمز عبور برای اصلاح
- محدود کردن ویرایش ارائه
- حذف محافظت نوشتاری
- اعتبارسنجی رمز عبور اصلاح
- پاورپوینت
- ارائه
- Node.js
- جاوا اسکریپت
- Aspose.Slides
description: "تنظیم، تشخیص، اعتبارسنجی و حذف رمزهای عبور محافظت نوشتاری در ارائه‌های PowerPoint PPT و PPTX با استفاده از Aspose.Slides برای Node.js از طریق Java."
---
## **مقدمه**

یک رمز عبور حفاظت نوشتاری اصلاح یک ارائه را محدود می‌کند اما محتوای آن را رمزنگاری نمی‌کند. کاربران می‌توانند یک ارائه محافظت‌شده در برابر نوشتار را بدون رمز عبور بارگذاری و مشاهده کنند. بسته به برنامه، ممکن است بتوانند محتوا را ویرایش کرده و تحت نام دیگری ذخیره کنند، بنابراین حفاظت نوشتاری نباید به عنوان مکانیزم محرمانگی در نظر گرفته شود.

یک رمز عبور باز کردن هدف متفاوتی دارد: ارائه را رمزنگاری می‌کند و برای بارگذاری محتوای آن لازم است. برای رمزنگاری یک ارائه یا اعتبارسنجی رمز عبور باز کردن، به [محافظت از ارائه با رمز عبور](/slides/fa/nodejs-java/password-protected-presentation/) مراجعه کنید.

روال‌های کاری در این مقاله برای ارائه‌های PPT و PPTX هر دو اعمال می‌شوند. مثال‌ها از فایل‌های PPTX استفاده می‌کنند؛ هنگام ذخیره به PPT، از پسوند `.ppt` و قالب ذخیره‌سازی PPT مربوطه استفاده کنید.

## **تنظیم حفاظت نوشتاری بر روی یک ارائه**

برای اختصاص رمز عبور جهت اصلاح یک ارائه، از [ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/protectionmanager/#setWriteProtection) استفاده کنید. ذخیرهٔ ارائه تنظیمات حفاظت را حفظ می‌کند.

مثال زیر حفاظت نوشتاری را بر روی یک ارائه PPTX تنظیم می‌کند:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("modify_password");
    presentation.save("write-protected-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **بارگذاری یک ارائه محافظت‌شده در برابر نوشتار**

از آنجا که حفاظت نوشتاری محتوای ارائه را رمزنگاری نمی‌کند، برای بارگذاری ارائه نیازی به رمز عبور نیست. رمز عبور فقط در هنگام اعتبارسنجی مجوز اصلاح ارائهٔ محافظت‌شده مربوط می‌شود.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("write-protected-pres.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

رمز عبور حفاظت نوشتاری را به [LoadOptions.setPassword](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/#setPassword) پاس ندهید. این متد یک رمز عبور باز کردن را برای محتوای رمزنگاری‌شده می‌پذیرد. اگر یک ارائه هر دو نوع حفاظت را داشته باشد، برای بارگذاری، رمز عبور باز کردن را ارائه دهید و رمز عبور حفاظت نوشتاری را به صورت جداگانه مدیریت کنید.

## **حذف حفاظت نوشتاری از یک ارائه**

برای حذف محدودیت اصلاح، از [ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/protectionmanager/#removeWriteProtection) استفاده کنید و سپس ارائه را ذخیره کنید.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("write-protected-pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **بررسی اینکه آیا یک ارائه محافظت نوشتاری دارد یا نه**

برای بررسی یک فایل بدون ایجاد یک نمونهٔ کامل از [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/)، متد [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) را صدا بزنید و سپس [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationinfo/#isWriteProtected) را بررسی کنید. این متد از [NullableBool](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/nullablebool/) استفاده می‌کند و هنگام شناسایی حفاظت نوشتاری، `NullableBool.True` را برمی‌گرداند.

```javascript
const slides = require("aspose.slides.via.java");

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() === slides.NullableBool.True) {
    console.log("The presentation is write protected.");
} else {
    console.log("Write protection was not detected.");
}
```

متد مبتنی بر جریان [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) همان اطلاعات را برای ارائه‌ای که به صورت جریان قابل خواندن Node.js ارائه می‌شود، فراهم می‌کند.

## **اعتبارسنجی رمز عبور حفاظت نوشتاری**

برای اعتبارسنجی رمز عبور اصلاح بدون بارگذاری کل ارائه، از [PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationinfo/#checkWriteProtection) استفاده کنید. ابتدا [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationinfo/#isWriteProtected) را بررسی کنید تا برنامه فقط در زمانی که حفاظت نوشتاری وجود دارد، رمز عبور را درخواست یا اعتبارسنجی کند.

```javascript
const slides = require("aspose.slides.via.java");

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() !== slides.NullableBool.True) {
    console.log("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    console.log("The write-protection password is correct.");
} else {
    console.log("The write-protection password is incorrect.");
}
```

[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationinfo/#checkWriteProtection) تنها رمز عبور حفاظت نوشتاری را اعتبارسنجی می‌کند. این متد رمز عبور باز کردن یا تعیین امکان بارگذاری محتوای رمزنگاری‌شده را اعتبارسنجی نمی‌کند. برعکس، [PresentationInfo.checkPassword](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentationinfo/#checkPassword) فقط یک رمز عبور باز کردن را اعتبارسنجی می‌کند. اگر یک ارائهٔ کامل قبلاً بارگذاری شده باشد، [ProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/protectionmanager/#checkWriteProtection) بررسی حفاظت نوشتاری معادل را از طریق مدیر حفاظت خود فراهم می‌آورد.

در برنامه‌های تولیدی، رمزهای عبور را لاگ نکنید و در پیام‌های تشخیصی گنجانده نشوند. از تلاش‌های تکراری غیرضروری برای اعتبارسنجی جلوگیری کنید و رمزهای عبور را در حافظه فقط به مدت زمان لازم نگه دارید.

{{% alert color="info" title="موارد مرتبط" %}}
- [محافظت از ارائه با رمز عبور](/slides/fa/nodejs-java/password-protected-presentation/)
- [ارائه‌های فقط-خواندنی](/slides/fa/nodejs-java/read-only-presentation/)
- [امضای دیجیتال در PowerPoint](/slides/fa/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **سوالات متداول**

**آیا حفاظت نوشتاری یک ارائه را رمزنگاری می‌کند؟**

خیر. این ویژگی اصلاح را محدود می‌کند اما محتوای ارائه برای بارگذاری و مشاهده در دسترس می‌ماند.

**آیا رمز عبور حفاظت نوشتاری برای باز کردن یک ارائه لازم است؟**

خیر. تنها یک رمز عبور باز کردن برای بارگذاری محتوای ارائهٔ رمزنگاری‌شده لازم است.

**آیا یک ارائه می‌تواند همزمان یک رمز عبور باز کردن و یک رمز عبور حفاظت نوشتاری داشته باشد؟**

بله. رمز عبور باز کردن را از طریق گزینه‌های بارگذاری برای باز کردن ارائهٔ رمزنگاری‌شده ارائه دهید و هنگام نیاز به مجوز اصلاح، رمز عبور حفاظت نوشتاری را به طور جداگانه اعتبارسنجی کنید.