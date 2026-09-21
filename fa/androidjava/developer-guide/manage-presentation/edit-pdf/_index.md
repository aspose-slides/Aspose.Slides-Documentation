---
title: ویرایش اسناد PDF در اندروید
linktitle: ویرایش PDF
type: docs
weight: 65
url: /fa/androidjava/edit-pdf/
keywords:
- ویرایش PDF
- جایگزینی متن PDF
- PDF به PPTX
- PPTX به PDF
- اندروید
- جاوا
- Aspose.Slides
description: "اسناد PDF را در اندروید با جاوا و با وارد کردن آن‌ها به Aspose.Slides، جایگزینی متن و ذخیره ارائهٔ اصلاح‌شده به‌صورت PDF ویرایش کنید."
---
## **بررسی اجمالی**

Aspose.Slides for Android via Java به شما امکان ویرایش محتوای PDF را با وارد کردن صفحات به عنوان اسلایدها، تغییر ارائه و برگرداندن آن به PDF می‌دهد. این مقاله جایگزینی ساده‌ای از متن را نشان می‌دهد. ارائه در حافظه باقی می‌ماند، بنابراین ذخیره یک فایل PPTX میانی اختیاری است.

## **جایگزینی متن در PDF**

از [addFromPdf](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) برای وارد کردن صفحات، [replaceText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) برای به‌روزرسانی متن و [save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) برای خروجی گرفتن نتیجه استفاده کنید.

مثال زیر انتظار دارد `input.pdf` شامل کلمه «Draft» به صورت متن قابل ویرایش پس از وارد کردن باشد. این کلمه به «Final» تبدیل می‌شود و `edited.pdf` نوشته می‌شود. پاک‌سازی اسلاید اولیه قبل از وارد کردن، از ایجاد صفحهٔ خالی اضافی در خروجی جلوگیری می‌کند. جستجو تنها کلمات کامل با همان حروف بزرگ/کوچک را پیدا می‌کند؛ `null` به این معنی است که نیازی به فراخوانی نتیجه نیست.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.TextSearchOptions;

Presentation presentation = new Presentation();
try {
    presentation.getSlides().removeAt(0);

    presentation.getSlides().addFromPdf("input.pdf");

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);
    presentation.replaceText("Draft", "Final", searchOptions, null);

    presentation.save("edited.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

برای گزینه‌های بیشتر، به [جستجو و جایگزینی متن](/slides/fa/androidjava/search-and-replace-text/) و [تبدیل پاورپوینت به PDF](/slides/fa/androidjava/convert-powerpoint-to-pdf/) مراجعه کنید.

{{% alert color="info" title="Note" %}}
جایگزینی متن بر روی متن‌های وارد شده انجام می‌شود و بر روی متنی که در داخل تصاویر اسکن‌شده باشد اعمال نمی‌شود. تبدیل ممکن است به چیدمان و قالب‌بندی اثر بگذارد، بنابراین خروجی را به‌دقت بررسی کنید، به‌ویژه وقتی متن جایگزین طولانی‌تر از متن اصلی باشد.
{{% /alert %}}

## **سوالات متداول**

**آیا قبل از خروجی گرفتن به PDF نیاز به ذخیرهٔ یک فایل PPTX دارم؟**

نه. می‌توانید همان ارائه را در حافظه ویرایش و خروجی بگیرید. فقط در صورتی که بخواهید ادامهٔ ویرایش را در PowerPoint داشته باشید، یک نسخهٔ PPTX ذخیره کنید؛ برای جزئیات به [ذخیره ارائه‌ها](/slides/fa/androidjava/save-presentation/) نگاه کنید.

**چرا ممکن است برخی متن‌ها تغییر نکنند؟**

مثال فقط کلمهٔ کامل «Draft» را با حروف دقیق مطابقت می‌دهد. متنی که به‌عنوان تصویر وارد شده یا در فریم‌های متنی جداگانه تقسیم شده باشد، لزوماً با جستجو مطابقت نخواهد داشت. محتوای وارد شده را بررسی کرده و جستجو را بر حسب نیاز سند خود تنظیم کنید.