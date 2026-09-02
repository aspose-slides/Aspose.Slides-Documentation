---
title: تبدیل ارائه‌های PowerPoint به XML در Java
linktitle: PowerPoint به XML
type: docs
weight: 145
url: /fa/java/convert-powerpoint-to-xml/
keywords:
- تبدیل PowerPoint به XML
- تبدیل ارائه به XML
- PPT به XML
- PPTX به XML
- ODP به XML
- ارائه PowerPoint XML
- SaveFormat.Xml
- ذخیره ارائه به عنوان XML
- استخراج ارائه به XML
- جریان XML
- Java
- Aspose.Slides
description: "تبدیل ارائه‌های PowerPoint و OpenDocument به فایل‌های PowerPoint XML یا جریان‌ها در Java با Aspose.Slides for Java."
---
## **بررسی کلی**

Aspose.Slides برای Java می‌تواند ارائه‌های PowerPoint را به فرمت PowerPoint XML Presentation تبدیل کند. خروجی XML زمانی مفید است که نیاز به نمایشی متنی برای بررسی ساختار ارائه، عیب‌یابی اسناد تولید شده، مقایسه خروجی در تست‌های خودکار، یا یکپارچه‌سازی با گردش کاری که به جای بسته ارائه از XML استفاده می‌کند، داشته باشید.

از متد [Presentation.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#save-java.lang.String-int-) با مقدار `Xml` از کلاس [SaveFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/saveformat/) استفاده کنید. می‌توانید نتیجه را مستقیم به یک فایل یا به یک جریان (stream) بنویسید.

{{% alert color="info" title="Note" %}}

`SaveFormat.Xml` یک PowerPoint XML Presentation ایجاد می‌کند. این متد بخش‌های منفرد Office Open XML که در بسته PPTX ذخیره شده‌اند را استخراج نمی‌کند. اگر به بخش‌های دقیق بسته PPTX، مانند `ppt/presentation.xml` یا فایل‌های XML اسلایدهای منفرد، نیاز دارید، بسته PPTX را به‌صورت مستقیم بررسی کنید.

{{% /alert %}}

## **تبدیل یک ارائه به فایل XML**

یک ارائه منبع را با کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) بارگذاری کنید و سپس مسیر خروجی و `SaveFormat.Xml` را به متد [Presentation.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#save-java.lang.String-int-) بدهید. منبع می‌تواند هر فرمتی از ارائه که برای بارگذاری پشتیبانی می‌شود، مانند PPT، PPTX یا ODP باشد.

مثال زیر یک ارائه PPTX را به فایل XML تبدیل می‌کند:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.xml", SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **نوشتن خروجی XML به یک جریان**

از overload مبتنی بر جریان متد [Presentation.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) استفاده کنید وقتی که XML باید در حافظه بماند یا به مؤلفه دیگری مانند سرویس وب، ارائه‌دهنده ذخیره‌سازی یا خط لوله پردازش XML منتقل شود. مثال زیر نتیجه را در یک [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) می‌نویسد و XML حاصل را به‌صورت آرایه بایت دریافت می‌کند:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (ByteArrayOutputStream xmlStream = new ByteArrayOutputStream()) {
    presentation.save(xmlStream, SaveFormat.Xml);
    byte[] xmlData = xmlStream.toByteArray();

    // xmlData را به مؤلفه بعدی در گردش کار منتقل کنید.
} finally {
    presentation.dispose();
}
```

## **مقایسه XML با فرمت‌های ارائه و خروجی**

فرمت خروجی را بر اساس نحوه استفاده از نتیجه انتخاب کنید:

| فرمت | خروجی | استفاده معمول |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | یک PowerPoint XML Presentation | بررسی ساختار، عیب‌یابی، مقایسه خروجی تولید شده و یکپارچه‌سازی مبتنی بر XML |
| PPT (`.ppt`) | یک فایل ارائه باینری قدیمی | سازگاری با گردش‌های کاری PowerPoint قدیم |
| PPTX (`.pptx`) | یک بسته Office Open XML شامل چندین بخش | ویرایش عادی PowerPoint و تبادل ارائه‌ها |
| PDF یا TIFF | صفحات ثابت‌چیدمان یا تصویر چندصفحه‌ای | مشاهده، چاپ و بایگانی |
| PNG، JPEG یا SVG | نمای رندر شده یک اسلاید منفرد | تصویرهای کوچک، پیش‌نمایش‌ها و دارایی‌های تصویری |
| HTML یا HTML5 | خروجی ارائه جهت‌دار به وب | مشاهده در مرورگر و انتشار وب |

بر خلاف PPT و PPTX، خروجی XML عمدتاً برای بازرسی و گردش‌کاری‌های مبتنی بر داده در نظر گرفته شده است. بر خلاف PDF، TIFF، HTML و فرمت‌های تصویر اسلاید، این خروجی داده‌های ارائه را نشان می‌دهد نه اینکه اسلایدها را به‌صورت صفحات یا دارایی‌های بصری رندر کند. جدول [فرمت‌های فایل پشتیبانی شده](/slides/fa/java/supported-file-formats/) PowerPoint XML Presentation را به‌عنوان یک فرمت فقط‌ذخیره (save‑only) لیست می‌کند، بنابراین وقتی گردش کاری نیاز به بارگذاری فایل صادر شده برای ویرایش ادامه‌دار دارد، از آن استفاده نکنید.

## **سوالات متداول**

**آیا `SaveFormat.Xml` همانند ذخیره‌سازی یک فایل PPTX است؟**

خیر. PPTX یک بسته حاوی چندین بخش Office Open XML است، در حالی که `SaveFormat.Xml` یک فایل PowerPoint XML Presentation ایجاد می‌کند.

**آیا می‌توانم خروجی XML را بدون ایجاد فایل روی دیسک ذخیره کنم؟**

بله. یک جریان قابل نوشتن را به متد [Presentation.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) بدهید. به‌عنوان مثال، برای پردازش در حافظه از یک [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) استفاده کنید.

**آیا Aspose.Slides می‌تواند فایل XML صادر شده را دوباره بارگذاری کند؟**

خیر. PowerPoint XML Presentation در حال حاضر فقط برای ذخیره‌سازی پشتیبانی می‌شود و برای بارگذاری قابل استفاده نیست. وقتی نیاز به ویرایش دورانی دارید، از PPTX یا قالب ارائه دیگری که پشتیبانی می‌شود، استفاده کنید.

**آیا تبدیل XML هر اسلاید را به‌صورت صفحه یا تصویر رندر می‌کند؟**

خیر. تبدیل XML داده‌های ساختاریافته ارائه را می‌نویسد. برای خروجی صفحه‌محور از PDF یا TIFF استفاده کنید، یا برای تصاویر اسلایدهای منفرد از PNG، JPEG و SVG بهره ببرید.