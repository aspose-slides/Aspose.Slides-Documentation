---
title: تبدیل ارائه‌های PowerPoint به XML در Android
linktitle: PowerPoint به XML
type: docs
weight: 145
url: /fa/androidjava/convert-powerpoint-to-xml/
keywords:
- تبدیل PowerPoint به XML
- تبدیل ارائه به XML
- PPT به XML
- PPTX به XML
- ODP به XML
- PowerPoint XML Presentation
- SaveFormat.Xml
- ذخیره ارائه به صورت XML
- صادر کردن ارائه به XML
- جریان XML
- Android
- Java
- Aspose.Slides
description: "تبدیل ارائه‌های PowerPoint و OpenDocument به فایل‌ها یا جریان‌های PowerPoint XML در Android با Aspose.Slides."
---
## **بررسی کلی**

Aspose.Slides برای Android از طریق Java می‌تواند ارائه‌های PowerPoint را به فرمت PowerPoint XML Presentation تبدیل کند. خروجی XML زمانی مفید است که به نمایه‌متنی برای بررسی ساختار ارائه، عیب‌یابی اسناد تولید شده، مقایسه خروجی در تست‌های خودکار، یا یکپارچه‌سازی با گردش کاری که به جای یک بسته ارائه از XML استفاده می‌کند، نیاز داشته باشید.

Use the [Presentation.save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) method with [SaveFormat.Xml](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/saveformat/#Xml). You can write the result directly to a file or to a stream.

{{% alert color="info" title="نکته" %}}
`SaveFormat.Xml` یک PowerPoint XML Presentation ایجاد می‌کند. این متد بخش‌های جداگانه Office Open XML ذخیره‌شده در بسته PPTX را استخراج نمی‌کند. اگر به بخش‌های دقیق بسته PPTX مانند `ppt/presentation.xml` یا فایل‌های XML اسلایدهای تک‌تک نیاز دارید، بسته PPTX را مستقیماً بررسی کنید.
{{% /alert %}}

## **تبدیل یک ارائه به فایل XML**

Load a source presentation with the [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) class, and then pass the output path and [SaveFormat.Xml](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/saveformat/#Xml) to [Presentation.save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-). The source can be any presentation format supported for loading, such as PPT, PPTX, or ODP.

The following example converts a PPTX presentation to an XML file:

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

Use the stream overload of [Presentation.save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-) when the XML must remain in memory or be passed to another component, such as a web service, storage provider, or XML processing pipeline. The following example writes the result to a [ByteArrayOutputStream](https://developer.android.com/reference/java/io/ByteArrayOutputStream) and obtains the generated XML as a byte array:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ByteArrayOutputStream xmlStream = new ByteArrayOutputStream();
    try {
        presentation.save(xmlStream, SaveFormat.Xml);
        byte[] xmlData = xmlStream.toByteArray();

        // xmlData را به مؤلفه بعدی در جریان کار پاس دهید.
    } finally {
        xmlStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **مقایسه XML با فرمت‌های ارائه و خروجی**

Choose the output format according to how the result will be used:

| فرمت | خروجی | استفاده معمول |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | یک PowerPoint XML Presentation | بررسی ساختار، عیب‌یابی، مقایسه خروجی تولید شده و یکپارچه‌سازی مبتنی بر XML |
| PPT (`.ppt`) | یک فایل ارائه باینری قدیمی | سازگاری با گردش‌های کاری قدیمی PowerPoint |
| PPTX (`.pptx`) | یک بسته Office Open XML شامل چندین بخش | ویرایش عادی PowerPoint و تبادل ارائه |
| PDF یا TIFF | صفحات با چیدمان ثابت یا یک تصویر چندصفحه‌ای | مشاهده، چاپ و بایگانی |
| PNG، JPEG یا SVG | نمایش رندر شده یک اسلاید تک‌تک | تصاویر کوچک، پیش‌نمایش‌ها و دارایی‌های تصویری |
| HTML یا HTML5 | خروجی ارائه جهت وب | مشاهده در مرورگر و انتشار وب |

Unlike PPT and PPTX, XML output is primarily intended for inspection and data-oriented workflows. Unlike PDF, TIFF, HTML, and slide image formats, it represents presentation data rather than rendering slides as pages or visual assets. The [supported file formats](/slides/fa/androidjava/supported-file-formats/) table lists PowerPoint XML Presentation as a save-only format, so do not use it when a workflow must load the exported file back into Aspose.Slides for continued editing.

## **سوالات پرتکرار**

**آیا `SaveFormat.Xml` همانند ذخیره یک فایل PPTX است؟**

No. PPTX is a package containing multiple Office Open XML parts, whereas `SaveFormat.Xml` creates a PowerPoint XML Presentation file.

**آیا می‌توانم خروجی XML را بدون ایجاد فایل در دیسک ذخیره کنم؟**

Yes. Pass a writable stream to [Presentation.save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#save-java.io.OutputStream-int-). For example, use a [ByteArrayOutputStream](https://developer.android.com/reference/java/io/ByteArrayOutputStream) for in-memory processing.

**آیا Aspose.Slides می‌تواند فایل XML صادر شده را دوباره بارگذاری کند؟**

No. PowerPoint XML Presentation is currently supported for saving but not for loading. Use PPTX or another supported presentation format when round-trip editing is required.

**آیا تبدیل XML هر اسلاید را به عنوان صفحه یا تصویر رندر می‌کند؟**

No. XML conversion writes structured presentation data. Use PDF or TIFF for page-oriented output, or PNG, JPEG, and SVG for individual slide images.