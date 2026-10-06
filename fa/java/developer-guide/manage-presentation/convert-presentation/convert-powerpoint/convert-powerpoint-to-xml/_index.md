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
- ذخیره ارائه به صورت XML
- صادرات ارائه به XML
- جریان XML
- جاوا
- Aspose.Slides
description: "تبدیل ارائه‌های PowerPoint و OpenDocument به فایل‌ها یا جریان‌های PowerPoint XML در Java با Aspose.Slides برای Java."
---
## **بررسی کلی**

Aspose.Slides for Java می‌تواند ارائه‌های PowerPoint را به فرمت PowerPoint XML Presentation تبدیل کند. خروجی XML وقتی که به نمای متنی برای بررسی ساختار ارائه، عیب‌یابی اسناد تولید شده، مقایسه خروجی در تست‌های خودکار، یا یکپارچه‌سازی با گردش کاری که XML را به‌جای بسته ارائه مصرف می‌کند، مفید است.

از متد [Presentation.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#save-java.lang.String-int-) با مقدار `Xml` از کلاس [SaveFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/saveformat/) استفاده کنید. می‌توانید نتیجه را مستقیم به یک فایل یا به یک جریان بنویسید.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` یک PowerPoint XML Presentation ایجاد می‌کند. این متد قسمت‌های منفرد Office Open XML که داخل بسته PPTX ذخیره شده‌اند را استخراج نمی‌کند. اگر به قسمت‌های دقیق بسته PPTX نیاز دارید، مانند `ppt/presentation.xml` یا فایل‌های XML اسلایدهای جداگانه، باید بسته PPTX را بررسی کنید.
{{% /alert %}}

## **تبدیل یک ارائه به فایل XML**

یک ارائه منبع را با کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) بارگذاری کنید و سپس مسیر خروجی و `SaveFormat.Xml` را به متد [Presentation.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#save-java.lang.String-int-) پاس دهید. منبع می‌تواند هر فرمت ارائه‌ای باشد که برای بارگذاری پشتیبانی می‌شود، مانند PPT، PPTX یا ODP.

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

از overload جریان‌دار متد [Presentation.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) استفاده کنید زمانی که XML باید در حافظه بماند یا به مؤلفه‌ای دیگر مثل سرویس وب، فراهم‌کنندهٔ ذخیره‌سازی یا خط لولهٔ پردازش XML منتقل شود. مثال زیر نتیجه را در یک [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) می‌نویسد و XML نهایی را به شکل آرایه بایت دریافت می‌کند:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (ByteArrayOutputStream xmlStream = new ByteArrayOutputStream()) {
    presentation.save(xmlStream, SaveFormat.Xml);
    byte[] xmlData = xmlStream.toByteArray();

    // xmlData را به مؤلفه بعدی در جریان کار پاس دهید.
} finally {
    presentation.dispose();
}
```

## **مقایسه XML با فرمت‌های ارائه و خروجی**

فرمت خروجی را بسته به نحوهٔ استفادهٔ نهایی انتخاب کنید:

| فرمت | خروجی | کاربرد معمول |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | یک PowerPoint XML Presentation | بررسی ساختار، عیب‌یابی، مقایسه خروجی تولید شده و یکپارچه‌سازی مبتنی بر XML |
| PPT (`.ppt`) | یک فایل ارائهٔ باینری قدیمی | سازگاری با گردش‌کارهای قدیمی PowerPoint |
| PPTX (`.pptx`) | یک بسته Office Open XML شامل چندین بخش | ویرایش معمولی PowerPoint و تبادل ارائه |
| PDF یا TIFF | صفحات با طرح ثابت یا تصویر چندصفحه‌ای | مشاهده، چاپ و بایگانی |
| PNG، JPEG یا SVG | نمای رندر شدهٔ یک اسلاید جداگانه | تصاویر کوچک، پیش‌نمایش‌ها و دارایی‌های تصویری |
| HTML یا HTML5 | خروجی ارائهٔ وب‌محور | مشاهده در مرورگر و انتشار وب |

برخلاف PPT و PPTX، خروجی XML عمدتاً برای بازرسی و گردش‌های کاری داده‌محور در نظر گرفته شده است. برخلاف PDF، TIFF، HTML و فرمت‌های تصویر اسلاید، XML داده‌های ارائه را نشان می‌دهد نه رندر اسلایدها به‌عنوان صفحات یا دارایی‌های بصری. جدول [فرمت‌های فایل پشتیبانی‌شده](/slides/fa/java/supported-file-formats/) همهٔ فرمت‌هایی را که Aspose.Slides می‌تواند بارگذاری، وارد، ذخیره یا رندر کند، فهرست می‌کند.

## **سوالات متداول**

**آیا `SaveFormat.Xml` همانند ذخیرهٔ یک فایل PPTX است؟**

نه. PPTX یک بسته شامل چندین بخش Office Open XML است، در حالی که `SaveFormat.Xml` یک فایل PowerPoint XML Presentation ایجاد می‌کند.

**آیا می‌توان خروجی XML را بدون ایجاد فایل روی دیسک ذخیره کرد؟**

بله. یک جریان قابل نوشتن را به متد [Presentation.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) پاس دهید. برای مثال، می‌توانید از یک [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) برای پردازش در حافظه استفاده کنید.

**آیا Aspose.Slides می‌تواند فایل XML صادر شده را دوباره بارگذاری کند؟**

بله. فایل XML یا یک جریان را به سازندهٔ [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) پاس دهید. سپس متد [Presentation.getSourceFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#getSourceFormat--) مقدار `SourceFormat.Xml` را برمی‌گرداند. متد [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) برای این فرمت `LoadFormat.Unknown` گزارش می‌کند، بنابراین برای تصمیم‌گیری در مورد امکان باز شدن فایل XML از آن استفاده نکنید.

**آیا تبدیل XML هر اسلاید را به عنوان صفحه یا تصویر رندر می‌کند؟**

نه. تبدیل XML داده‌های ساختاری ارائه را می‌نویسد. برای خروجی صفحه‌محور از PDF یا TIFF استفاده کنید، یا برای تصاویر اسلایدهای جداگانه از PNG، JPEG و SVG بهره ببرید.