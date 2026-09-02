---
title: تبدیل ارائه‌های PowerPoint به XML در JavaScript
linktitle: PowerPoint به XML
type: docs
weight: 145
url: /fa/nodejs-java/convert-powerpoint-to-xml/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "تبدیل ارائه‌های PowerPoint و OpenDocument به فایل‌ها یا جریان‌های PowerPoint XML در JavaScript با Aspose.Slides برای Node.js از طریق Java."
---
## **مرور**

Aspose.Slides for Node.js via Java می‌تواند ارائه‌های PowerPoint را به فرمت PowerPoint XML Presentation تبدیل کند. خروجی XML زمانی مفید است که به نمایشی متنی برای بررسی ساختار ارائه، عیب‌یابی اسناد تولید شده، مقایسه خروجی در تست‌های خودکار یا یکپارچه‌سازی با گردش کاری که XML را به جای بسته ارائه مصرف می‌کند، نیاز داشته باشید.

از متد [Presentation.save](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#save) همراه با مقدار `Xml` از شمارش [SaveFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/saveformat/) استفاده کنید. می‌توانید نتیجه را مستقیماً در یک فایل یا یک جریان بنویسید.

{{% alert color="info" title="Note" %}}
`SaveFormat.Xml` یک PowerPoint XML Presentation ایجاد می‌کند. این مقدار بخش‌های جداگانه Office Open XML که در داخل بسته PPTX ذخیره شده‌اند را استخراج نمی‌کند. اگر به بخش‌های دقیق بسته PPTX نیاز دارید، مانند `ppt/presentation.xml` یا فایل‌های XML اسلایدهای فردی، باید بسته PPTX را به‌صورت مستقیم بررسی کنید.
{{% /alert %}}

## **تبدیل یک ارائه به فایل XML**

یک ارائه منبع را با کلاس [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) بارگذاری کنید و سپس مسیر خروجی و `SaveFormat.Xml` را به متد [Presentation.save](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#save) پاس بدهید. منبع می‌تواند هر فرمت ارائه‌ای باشد که برای بارگذاری پشتیبانی می‌شود، مانند PPT، PPTX یا ODP.

مثال زیر یک ارائه PPTX را به فایل XML تبدیل می‌کند:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    presentation.save("presentation.xml", aspose.slides.SaveFormat.Xml);
} finally {
    presentation.dispose();
}
```

## **نوشتن خروجی XML به یک جریان**

وقتی XML باید در حافظه باقی بماند یا به مؤلفه دیگری مانند سرویس وب، ارائه‌دهنده ذخیره‌سازی یا خط لوله پردازش XML منتقل شود، از نسخهٔ جریان‌دار متد [Presentation.save](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#save) استفاده کنید. مثال زیر نتیجه را در یک `ByteArrayOutputStream` جاوا می‌نویسد و داده‌های تولید شده را به یک `Buffer` Node.js کپی می‌کند:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xmlStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    try {
        presentation.save(xmlStream, aspose.slides.SaveFormat.Xml);

        const xmlBuffer = Buffer.from(xmlStream.toByteArray());
        console.log(`XML size: ${xmlBuffer.length} bytes`);

        // xmlBuffer را به مؤلفهٔ بعدی در گردش کاری منتقل کنید.
    } finally {
        xmlStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **مقایسه XML با فرمت‌های ارائه و خروجی**

فرمت خروجی را بر اساس نحوه استفاده از نتیجه انتخاب کنید:

| فرمت | خروجی | کاربرد معمول |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | یک PowerPoint XML Presentation | بررسی ساختار، عیب‌یابی، مقایسه خروجی تولید شده و یکپارچه‌سازی مبتنی بر XML |
| PPT (`.ppt`) | یک فایل ارائه باینری قدیمی | سازگاری با گردش‌های کاری PowerPoint قدیمی |
| PPTX (`.pptx`) | یک بسته Office Open XML شامل چندین بخش | ویرایش عادی PowerPoint و تبادل ارائه‌ها |
| PDF یا TIFF | صفحات با چیدمان ثابت یا یک تصویر چندصفحه‌ای | مشاهده، چاپ و آرشیوبندی |
| PNG، JPEG یا SVG | نمای رندر شدهٔ یک اسلاید منفرد | تصویرهای کوچک، پیش‌نمایش و دارایی‌های تصویری |
| HTML یا HTML5 | خروجی ارائه‌محور وب | مشاهده در مرورگر و انتشار وب |

بر خلاف PPT و PPTX، خروجی XML عمدتاً برای بازرسی و گردش‌های کاری داده‑محور در نظر گرفته شده است. بر خلاف PDF، TIFF، HTML و فرمت‌های تصویر اسلاید، XML داده‌های ارائه را نمایش می‌دهد نه اینکه اسلایدها را به عنوان صفحات یا دارایی‌های بصری رندر کند. جدول [فرمت‌های فایل پشتیبانی‌شده](/slides/fa/nodejs-java/supported-file-formats/) فقط PowerPoint XML Presentation را به عنوان فرمت صرفاً ذخیره‑کردن فهرست می‌کند، بنابراین هنگامیکه یک گردش کاری نیاز به بارگذاری مجدد فایل خروجی برای ویرایش ادامه دارد، از آن استفاده نکنید.

## **سوالات متداول**

**آیا `SaveFormat.Xml` همانند ذخیره‌سازی یک فایل PPTX است؟**

خیر. PPTX یک بسته شامل چندین بخش Office Open XML است، در حالی که `SaveFormat.Xml` یک فایل PowerPoint XML Presentation ایجاد می‌کند.

**آیا می‌توان خروجی XML را بدون ایجاد فایل روی دیسک ذخیره کرد؟**

بله. یک جریان قابل نوشتن را به متد [Presentation.save](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#save) پاس دهید. برای مثال، از یک `ByteArrayOutputStream` جاوا استفاده کنید و داده‌های آن را به یک `Buffer` Node.js برای پردازش در حافظه کپی کنید.

**آیا Aspose.Slides می‌تواند فایل XML صادر شده را دوباره بارگذاری کند؟**

خیر. PowerPoint XML Presentation در حال حاضر فقط برای ذخیره‌سازی پشتیبانی می‌شود و برای بارگذاری در دسترس نیست. هنگام نیاز به ویرایش دور‌به‑دور، از PPTX یا یک فرمت ارائهٔ پشتیبانی‌شده دیگر استفاده کنید.

**آیا تبدیل به XML هر اسلاید را به صورت صفحه یا تصویر رندر می‌کند؟**

خیر. تبدیل به XML داده‌های ساختار یافتهٔ ارائه را می‌نویسد. برای خروجی صفحه‑محور از PDF یا TIFF استفاده کنید یا برای تصاویر اسلایدهای منفرد از PNG، JPEG و SVG بهره ببرید.