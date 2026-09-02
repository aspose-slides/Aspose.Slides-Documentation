---
title: تبدیل ارائه‌های PowerPoint به Markdown در Java
linktitle: PowerPoint به Markdown
type: docs
weight: 140
url: /fa/java/convert-powerpoint-to-markdown/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به MD
- ارائه به MD
- اسلاید به MD
- PPT به MD
- PPTX به MD
- ذخیره PowerPoint به عنوان Markdown
- ذخیره ارائه به عنوان Markdown
- ذخیره اسلاید به عنوان Markdown
- ذخیره PPT به عنوان MD
- ذخیره PPTX به عنوان MD
- صادرات PPT به MD
- صادرات PPTX به MD
- صادرات تصویر Markdown
- پیوندهای تصویر CDN
- PowerPoint
- ارائه
- Markdown
- Java
- Aspose.Slides
description: "تبدیل ارائه‌های PPT و PPTX به Markdown در Java و کنترل مکان ذخیره‌سازی و ارجاع تصاویر بیت‌مپ، متافایل و SVG صادرشده."
---
## **بررسی کلی**

Aspose.Slides for Java می‌تواند ارائه‌های PPT و PPTX را به Markdown برای مستندات، وب‌سایت‌های ایستا، مهاجرت محتوا و جریان‌های کاری کنترل نسخه تبدیل کند. می‌توانید یک نوع Markdown را انتخاب کنید، نحوه رندر محتوی اسلایدها را کنترل کنید و تصمیم بگیرید که تصاویر صادر شده در کجا ذخیره شوند و Markdown تولید شده چگونه به آن‌ها ارجاع دهد.

به‌صورت پیش‌فرض، خروجی صادرات Markdown فقط متن است. برای صادر کردن محتوای تصویری، نوع خروجی را با متد [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/markdownsaveoptions/) به مقدار `Sequential` یا `Visual` از شمارش [MarkdownExportType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/markdownexporttype/) تنظیم کنید. مقدار `Sequential` موارد اسلاید را به‌صورت جداگانه و به ترتیب رندر می‌کند، در حالی که `Visual` موارد گروه‌بندی‌شده را کنار هم نگه می‌دارد تا رابطه بصری آن‌ها حفظ شود. مقدار `TextOnly` هیچ منبع تصویری تولید نمی‌کند، بنابراین فراخوانی‌های ذخیره‌سازی تصویر در این حالت اجرا نمی‌شوند.

## **تبدیل یک ارائه به Markdown**

فایل منبع را با کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) بارگذاری کنید و سپس متد [Presentation.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) را با مقدار `Md` از شمارش [SaveFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/saveformat/) فراخوانی نمایید.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **انتخاب یک نوع Markdown**

متد [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/markdownsaveoptions/) مشخص می‌کند که کدام مشخصات Markdown برای خروجی استفاده شود. شمارش [Flavor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/flavor/) شامل CommonMark، GitHub Flavored Markdown و سایر واریانت‌های پشتیبانی‌شده است.

مثال زیر یک ارائه را به صورت CommonMark صادر می‌کند:

```java
import com.aspose.slides.Flavor;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setFlavor(Flavor.CommonMark);

    presentation.save("presentation.md", SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **صادر کردن تصاویر با رفتار پیش‌فرض ذخیره‌سازی محلی**

کلاس [MarkdownSaveOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/markdownsaveoptions/) دو متد برای پیکربندی ذخیره‌سازی محلی تصاویر فراهم می‌کند:

- [setBasePath](https://reference.aspose.com/slides/fa/java/com.aspose.slides/markdownsaveoptions/) مسیر پایه برای سند Markdown و منابع آن را مشخص می‌کند.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/fa/java/com.aspose.slides/markdownsaveoptions/) زیرپوشه تصویر را مشخص می‌کند. مقدار پیش‌فرض آن `Images` است.

مثال زیر محتوای تصویری را رندر می‌کند، تصویرها را در `output/assets` می‌نویسد و ارجاع‌های تصویری نسبی را در سند Markdown ایجاد می‌کند:

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path outputDirectory = Paths.get("output");
Files.createDirectories(outputDirectory);

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("assets");

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

این رفتار همچنین به‌عنوان بازگشت‌پذیری عمل می‌کند زمانی که یک هندلر سفارشی ذخیره‌سازی تصویر `false` برگرداند.

## **سفارشی‌سازی ذخیره‌سازی تصویر و پیوندهای Markdown**

از متد [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/fa/java/com.aspose.slides/markdownsaveoptions/) برای ثبت یک callback برای منابع bitmap و metafile غیر‑SVG که در هنگام صادرات Markdown تولید می‌شوند، استفاده کنید. Callback `MarkdownImageSavingHandler` یک شیء [IImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimage/)، مقدار [ImageFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imageformat/) و پیوند Markdown تولیدشده را به صورت یک آرایه تک‌عنصری `String[]` دریافت می‌کند. تصویر را با فرمت ارائه‌شده ذخیره یا بارگذاری کنید و `link[0]` را با ارجاعی که باید در خروجی Markdown ظاهر شود جایگزین کنید.

منابع صادرشده در قالب SVG جداگانه پردازش می‌شوند. یک callback با متد [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/fa/java/com.aspose.slides/markdownsaveoptions/) ثبت کنید. Callback `MarkdownSvgImageSavingHandler` یک شیء [ISvgImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isvgimage/) و پارامتر یک‌عنصری `String[] link` دریافت می‌کند. برای SVG نیازی به آرگومان `ImageFormat` نیست؛ به‌جای آن داده‌های XML آن را با متد [ISvgImage.getSvgData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isvgimage/) بنویسید یا بارگذاری کنید. بسته به حالت خروجی و گروه‌بندی بصری، یک SVG در ارائه منبع می‌تواند رستر شود یا با محتوای دیگر ترکیب شود؛ منبع غیر‑SVG حاصل سپس به callback ذخیره‌سازی تصویر ارسال می‌شود. هر دو callback را زمانی که هر منبع بصری صادرشده نیاز به پردازش سفارشی دارد، ثبت کنید.

مقدار بازگشتی هندلر تعیین می‌کند که چه کسی تصویر را پردازش می‌کند:

- `true` برگردانید پس از این که هندلر تصویر را ذخیره، بارگذاری، تبدیل یا به‌هر شکل دیگر پردازش کرده و مقدار معتبر به `link[0]` اختصاص داده باشد. Aspose.Slides آن مقدار را در سند Markdown می‌نویسد و ذخیره‌سازی محلی پیش‌فرض را انجام نمی‌دهد.
- `false` برگردانید تا Aspose.Slides تصویر را به‌صورت محلی ذخیره کند و پیوند آن را بر اساس مقادیری که با [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/fa/java/com.aspose.slides/markdownsaveoptions/) و [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/fa/java/com.aspose.slides/markdownsaveoptions/) تنظیم شده‌اند، تولید نماید.

{{% alert color="warning" title="Important" %}}
یک هندلر که `true` برمی‌گرداند مسئولیت تصویر را بر عهده می‌گیرد. اگر بدون اختصاص یک پیوند معتبر و غیر خالی `true` برگرداند، صادرات با یک `InvalidOperationException` شکست می‌خورد.
{{% /alert %}}

### **ذخیره تصاویر در یک دایرکتوری مبدأ CDN و استفاده از URLهای خارجی**

مثال زیر مسیر `cdn-origin/presentations/quarterly-report` را به‌عنوان یک دایرکتوری مبدأ CDN سوار یا همگام‌شده در نظر می‌گیرد. هر هندلر نام فایل تولیدشده را استخراج می‌کند، تصویر را در آن دایرکتوری سفارشی ذخیره می‌کند و ارجاع محلی تولیدشده را با یک URL عمومی CDN جایگزین می‌کند. خود نمونه هیچ بارگذاری شبکه‌ای انجام نمی‌دهد: URL فقط پس از سوار شدن دایرکتوری به‌عنوان مبدأ CDN یا انتشار فایل‌ها در CDN معتبر می‌شود. برای ذخیره‌سازی شیء، نوشتن در سیستم‌فایل را با عملیات بارگذاری SDK ذخیره‌سازی جایگزین کنید و تنها پس از موفقیت بارگذاری `link[0]` را اختصاص دهید.

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.net.URLEncoder;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.function.Function;

Path outputDirectory = Paths.get("output");
String publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
Path storageDirectory = Paths.get("cdn-origin", "presentations", "quarterly-report");
Files.createDirectories(outputDirectory);
Files.createDirectories(storageDirectory);

Function<String, String> getFileNameFromLink = generatedLink -> {
    String urlCompatibleLink = generatedLink.replace('\\', '/');
    return urlCompatibleLink.substring(urlCompatibleLink.lastIndexOf('/') + 1);
};
Function<String, String> buildPublicUrl = fileName -> {
    try {
        String encodedFileName = URLEncoder.encode(fileName, "UTF-8").replace("+", "%20");
        return publicBaseUrl + "/" + encodedFileName;
    } catch (UnsupportedEncodingException exception) {
        System.err.println("Could not encode the image file name: " + exception.getMessage());
        return null;
    }
};

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("fallback-images");

    options.setImageSaving((image, format, link) -> {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        image.save(storagePath.toString(), format);
        link[0] = publicUrl;
        return true;
    });

    options.setSvgImageSaving((svgImage, link) -> {
        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        try {
            Files.write(storagePath, svgImage.getSvgData());
        } catch (IOException exception) {
            System.err.println("Could not save the SVG image: " + exception.getMessage());
            return false;
        }
        link[0] = publicUrl;
        return true;
    });

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

هندلر bitmap عمداً برای تصاویر کوچکتر از ۱۲۸ × ۱۲۸ پیکسل `false` برمی‌گرداند، بنابراین Aspose.Slides آن تصاویر را به‌صورت پیش‌فرض در `output/fallback-images` ذخیره می‌کند. منابع bitmap و metafile بزرگ‌تر، همانند منابع SVG، توسط کد سفارشی پردازش می‌شوند. برای مثال، یک ارجاع محلی تولیدشده مانند `fallback-images/image1.png` به `https://cdn.example.com/presentations/quarterly-report/image1.png` تبدیل می‌شود. هندلرها فقط هنگام نوشتن فایل‌ها از مسیرهای سیستم‌عامل استفاده می‌کنند؛ پیوندهای نوشته‌شده در Markdown از اسلش‌های پیش‌رو (`/`) و نام‌های فایل URL‑escaped استفاده می‌کنند. همین قانون را هنگام ساخت پیوندهای نسبی اعمال کنید: از `/` استفاده کنید، نه جداکننده مسیر مخصوص پلتفرم.

## **سوالات متداول**

**آیا یک هندلر می‌تواند هم تصاویر رستر و هم تصاویر SVG را پردازش کند؟**

خیر. برای منابع bitmap و metafile منتشرشده از [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/fa/java/com.aspose.slides/markdownsaveoptions/) استفاده کنید و برای منابع SVG منتشرشده از [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/fa/java/com.aspose.slides/markdownsaveoptions/) استفاده کنید. اولین مورد یک شیء [IImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimage/) و مقدار [ImageFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imageformat/) می‌دهد؛ مورد دوم یک شیء [ISvgImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isvgimage/) که داده‌های SVG آن می‌تواند با [ISvgImage.getSvgData](https://reference.aspose.com/slides/fa/java/com.aspose.slides/isvgimage/) خوانده شود. یک SVG منبع که در هنگام صادرات رستر می‌شود، توسط callback ذخیره‌سازی تصویر پردازش می‌شود.

**وقتی یک هندلر ذخیره‌سازی تصویر `false` برمی‌گرداند چه اتفاقی می‌افتد؟**

Aspose.Slides از رفتار پیش‌فرض ذخیره‌سازی محلی خود استفاده می‌کند. مکان تصویر و ارجاع تولیدشده توسط مقادیری که با [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/fa/java/com.aspose.slides/markdownsaveoptions/) و [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/fa/java/com.aspose.slides/markdownsaveoptions/) تنظیم شده‌اند، کنترل می‌شود.

**آیا یک هندلر می‌تواند بدون ذخیره محلی تصویر، فقط یک URL ارائه دهد؟**

بله. هندلر می‌تواند تصویر را به ذخیره‌سازی شیء بارگذاری کند یا به سرویس دیگری تحویل دهد، URL حاصل را به `link[0]` اختصاص دهد و `true` برگرداند. هندلر باید تمام پردازش را خودش انجام دهد؛ بازگرداندن `true` از ذخیره‌سازی محلی پیش‌فرض جلوگیری می‌کند.

**چرا صادرات Markdown یک `InvalidOperationException` از طرف یک هندلر پرتاب می‌کند؟**

این استثنا زمانی رخ می‌دهد که هندلر `true` برگرداند ولی پیوند معتبری ارائه ندهد. قبل از برگرداندن `true` مسیر نسبی یا URL خارجی معتبر که باید در Markdown نوشته شود را به `link[0]` اختصاص دهید.

**پیوندهای تصویری باید از چه جداکننده‌ای استفاده کنند؟**

در پیوندهای Markdown و URLها از اسلش‌های پیش‌رو (`/`) استفاده کنید. برای مسیرهای سیستم‌فایل از `Path.resolve` استفاده کنید و سپس مرجع Markdown را جداگانه ساخته یا نرمال کنید.

**آیا پیوندهای فراخوانی در هنگام صادرات Markdown حفظ می‌شوند؟**

بله. متن [hyperlinks](/slides/fa/java/manage-hyperlinks/) به‌صورت پیوندهای استاندارد Markdown حفظ می‌شود. [transitions](/slides/fa/java/slide-transition/) و [animations](/slides/fa/java/powerpoint-animation/) اسلاید تبدیل نمی‌شوند.

**آیا می‌توان ارائه‌ها را به‌صورت موازی به Markdown تبدیل کرد؟**

می‌توانید فایل‌های ارائه مختلف را به‌صورت موازی پردازش کنید، اما نباید همان نمونه [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) را بین رشته‌ها به اشتراک بگذارید. راهنمایی‌های [multithreading](/slides/fa/java/multithreading/) را دنبال کنید و برای هر فایل یک نمونه جداگانه استفاده کنید.