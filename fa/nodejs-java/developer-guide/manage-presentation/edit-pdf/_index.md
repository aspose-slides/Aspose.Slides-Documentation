---
title: ویرایش اسناد PDF در JavaScript
linktitle: ویرایش PDF
type: docs
weight: 65
url: /fa/nodejs-java/edit-pdf/
keywords:
- ویرایش PDF
- جایگزینی متن PDF
- PDF به PPTX
- PPTX به PDF
- Node.js
- JavaScript
- Aspose.Slides
description: "اسناد PDF را در JavaScript با وارد کردن آنها به Aspose.Slides، جایگزینی متن، و ذخیره ارائه‌ی اصلاح‌شده به‌صورت PDF ویرایش کنید."
---
## **بررسی کلی**

Aspose.Slides for Node.js via Java به شما امکان ویرایش محتوای PDF را با وارد کردن صفحات آن به عنوان اسلایدها، اصلاح ارائه و خروجی گرفتن به فرمت PDF می‌دهد. این مقاله یک جایگزینی ساده متن را نشان می‌دهد. ارائه در حافظه باقی می‌ماند، بنابراین ذخیره یک فایل PPTX میانی اختیاری است.

## **جایگزینی متن در PDF**

از [addFromPdf](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/slidecollection/#addFromPdf) برای وارد کردن صفحات، [replaceText](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#replaceText) برای به‌روزرسانی متن، و [save](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#save) برای خروجی گرفتن استفاده کنید.

مثال زیر انتظار دارد که `input.pdf` پس از وارد کردن، شامل کلمه‌ی «Draft» به صورت متنی قابل ویرایش باشد. این کلمه با «Final» جایگزین می‌شود و `edited.pdf` نوشته می‌شود. حذف اسلاید اولیه قبل از وارد کردن، از ایجاد یک صفحه خالی اضافی در خروجی جلوگیری می‌کند. جستجو فقط کلمات کامل را با همان حروف بزرگ/کوچک مطابقت می‌دهد؛ `null` یعنی نیازی به فراخوانی نتیجه نیست.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlides().removeAt(0);

    presentation.getSlides().addFromPdf("input.pdf");

    const searchOptions = new slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);
    presentation.replaceText("Draft", "Final", searchOptions, null);

    presentation.save("edited.pdf", slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

برای گزینه‌های بیشتر، به [جستجو و جایگزینی متن](/slides/fa/nodejs-java/search-and-replace-text/) و [تبدیل PowerPoint به PDF](/slides/fa/nodejs-java/convert-powerpoint-to-pdf/) مراجعه کنید.

{{% alert color="info" title="Note" %}}
جایگزینی متن بر روی متن وارد شده اعمال می‌شود، نه متنی که در تصاویر اسکن‌شده باشد. تبدیل ممکن است برچیدمان و قالب‌بندی تاثیر بگذارد، بنابراین خروجی را بررسی کنید، به‌ویژه وقتی متن جایگزین طولانی‌تر از متن اصلی باشد.
{{% /alert %}}

## **سوالات متداول**

**آیا نیاز است قبل از خروجی گرفتن PDF، فایل PPTX را ذخیره کنم؟**

خیر. می‌توانید همان ارائه را در حافظه ویرایش و خروجی بگیرید. تنها در صورتی که بخواهید فایل PPTX را در PowerPoint ادامه ویرایش کنید، یک نسخه ذخیره کنید؛ به [ذخیره ارائه‌ها](/slides/fa/nodejs-java/save-presentation/) مراجعه کنید.

**چرا ممکن است برخی متن‌ها تغییر نکنند؟**

مثال کلمه کامل «Draft» را با حروف دقیق مطابقت می‌دهد. متنی که به عنوان تصویر وارد شده یا بین فریم‌های متنی جداگانه پخش شده است، لزوماً با جستجو مطابقت نخواهد کرد. محتوای وارد شده را بررسی کنید و جستجو را برای سند خود تنظیم کنید.