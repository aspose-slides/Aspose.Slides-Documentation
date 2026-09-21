---
title: ویرایش اسناد PDF در جاوا
linktitle: ویرایش PDF
type: docs
weight: 65
url: /fa/java/edit-pdf/
keywords:
- ویرایش PDF
- جایگزینی متن PDF
- PDF به PPTX
- PPTX به PDF
- جاوا
- Aspose.Slides
description: "اسناد PDF را در جاوا با وارد کردن آنها به Aspose.Slides، جایگزینی متن و ذخیرهٔ ارائهٔ اصلاح‌شده به PDF ویرایش کنید."
---
## **بررسی کلی**

Aspose.Slides for Java به شما امکان می‌دهد محتوای PDF را با وارد کردن صفحات آن به‌ عنوان اسلاید، ویرایش ارائه و سپس برگرداندن آن به PDF، ویرایش کنید. این مقاله نمونه‌ای ساده از جایگزینی متن را نشان می‌دهد. ارائه در حافظه باقی می‌ماند، بنابراین ذخیره فایل PPTX میانی اختیاری است.

## **جایگزینی متن در PDF**

از [addFromPdf](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) برای وارد کردن صفحات، [replaceText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) برای به‌روزرسانی متن و [save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#save-java.lang.String-int-) برای استخراج نتیجه استفاده کنید.

مثال زیر انتظار دارد که فایل `input.pdf` پس از وارد کردن، واژه «Draft» را به‌صورت متن قابل ویرایش داشته باشد. این واژه را با «Final» جایگزین می‌کند و در `edited.pdf` می‌نویسد. پاک‌سازی اسلاید اولیه قبل از وارد کردن، از اضافه شدن صفحه خالی اضافی در خروجی جلوگیری می‌کند. جستجو تنها کلمات کامل با همان حروف کوچک و بزرگ را مطابقت می‌دهد؛ مقدار `null` به این معنی است که نیازی به فراخوانی نتیجه جستجو نیست.

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

برای گزینه‌های بیشتر، به [جستجو و جایگزینی متن](/slides/fa/java/search-and-replace-text/) و [تبدیل پاورپوینت به PDF](/slides/fa/java/convert-powerpoint-to-pdf/) مراجعه کنید.

{{% alert color="info" title="توجه" %}}
جایگزینی متن بر روی متنی که وارد شده است اعمال می‌شود، نه متنی که درون تصاویر اسکن‌شده قرار دارد. تبدیل ممکن است بر چیدمان و قالب‌بندی تأثیر بگذارد، بنابراین خروجی را بررسی کنید، به‌ویژه وقتی متن جایگزین طولانی‌تر از متن اصلی باشد.
{{% /alert %}}

## **سوالات متداول**

**آیا قبل از استخراج PDF نیاز به ذخیره فایل PPTX دارم؟**

نه. می‌توانید همان ارائه را در حافظه ویرایش و استخراج کنید. تنها در صورتی که بخواهید ادامه ویرایش را در PowerPoint انجام دهید، یک نسخه PPTX ذخیره کنید؛ به [ذخیره ارائه‌ها](/slides/fa/java/save-presentation/) نگاه کنید.

**چرا ممکن است برخی متن‌ها بدون تغییر بمانند؟**

این مثال کل واژه «Draft» را با همان حروف دقیق مطابقت می‌دهد. متنی که به‌عنوان تصویر وارد شده یا در فریم‌های متنی جداگانه تقسیم شده است، لزوماً با جستجو مطابقت نخواهد داشت. محتوای وارد شده را بررسی کنید و جستجو را بر حسب سند خود تنظیم کنید.