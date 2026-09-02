---
title: "تبدیل ارائه‌های پاورپوینت به Markdown در اندروید"
linktitle: "پاورپوینت به Markdown"
type: docs
weight: 140
url: /fa/androidjava/convert-powerpoint-to-markdown/
keywords:
- تبدیل پاورپوینت
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- پاورپوینت به MD
- ارائه به MD
- اسلاید به MD
- PPT به MD
- PPTX به MD
- ذخیره‌سازی پاورپوینت به عنوان Markdown
- ذخیره‌سازی ارائه به عنوان Markdown
- ذخیره‌سازی اسلاید به عنوان Markdown
- ذخیره‌سازی PPT به عنوان MD
- ذخیره‌سازی PPTX به عنوان MD
- استخراج PPT به MD
- استخراج PPTX به MD
- صادرات تصویر Markdown
- لینک‌های تصویر CDN
- PowerPoint
- ارائه
- Markdown
- Android
- Java
- Aspose.Slides
description: "تبدیل ارائه‌های PPT و PPTX به Markdown در اندروید از طریق Java و کنترل مکان ذخیره‌سازی و ارجاع تصاویر bitmap، metafile و SVG استخراج‌شده."
---
## **بررسی کلی**

Aspose.Slides for Android via Java می‌تواند ارائه‌های PPT و PPTX را به Markdown برای مستندسازی، سایت‌های استاتیک، مهاجرت محتوا و گردش‌کارهای کنترل نسخه تبدیل کند. می‌توانید یک طعم Markdown را انتخاب کنید، نحوه رندر محتویات اسلاید را کنترل کنید و تصمیم بگیرید تصاویر صادر شده در کجا ذخیره شوند و نحوه ارجاع آن‌ها در Markdown تولید شده چگونه باشد.

به‌طور پیش‌فرض، صادرات Markdown خروجی متنی‑فقط دارد. برای صادر کردن محتویات بصری، نوع صادرات را با متد [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/markdownsaveoptions/) به مقدار `Sequential` یا `Visual` از شمارش‌گر [MarkdownExportType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/markdownexporttype/) تنظیم کنید. `Sequential` موارد اسلاید را به‌صورت جداگانه و به ترتیب رندر می‌کند، در حالی که `Visual` آیتم‌های گروه‌بندی‌شده را کنار هم نگه می‌دارد تا رابطه بصری آن‌ها حفظ شود. مقدار `TextOnly` هیچ منبع تصویری تولید نمی‌کند، بنابراین فراخوانی‌های ذخیره‌سازی تصویر در آن حالت اجرا نمی‌شوند.

## **تبدیل ارائه به Markdown**

فایل منبع را با کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) بارگذاری کنید و سپس متد [Presentation.save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) را با مقدار `Md` از شمارش‌گر [SaveFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/saveformat/) فراخوانی کنید.

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

## **انتخاب طعم Markdown**

متد [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/markdownsaveoptions/) مشخص می‌کند که کدام مشخصات Markdown برای خروجی استفاده شود. شمارش‌گر [Flavor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/flavor/) شامل CommonMark، GitHub Flavored Markdown و دیگر واریانت‌های پشتیبانی‌شده است.

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

## **صادرات تصاویر با رفتار پیش‌فرض ذخیره‌سازی محلی**

کلاس [MarkdownSaveOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/markdownsaveoptions/) دو متد برای پیکربندی ذخیره‌سازی محلی تصاویر فراهم می‌آورد:

- [setBasePath](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/markdownsaveoptions/) مسیر پایه برای سند Markdown و منابع آن را تعیین می‌کند.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/markdownsaveoptions/) زیرپوشه تصویر را مشخص می‌سازد. مقدار پیش‌فرض آن `Images` است.

مثال زیر محتویات بصری را رندر می‌کند، تصاویر را در `output/assets` می‌نویسد و ارجاع‌های تصویر نسبی را در سند Markdown ایجاد می‌کند:

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

این رفتار همچنین به‌عنوان بازگشت‌گاه عمل می‌کند وقتی یک هندلر ذخیره‌سازی تصویر سفارشی مقدار `false` برمی‌گرداند.

## **سفارشی‌سازی ذخیره‌سازی تصویر و پیوندهای Markdown**

از متد [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/markdownsaveoptions/) برای ثبت یک callback برای منابع bitmap و metafile غیر‑SVG که در طول صادرات Markdown تولید می‌شوند، استفاده کنید. callback `MarkdownImageSavingHandler` آن شیء [IImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimage/)، مقدار [ImageFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imageformat/) و پیوند Markdown تولید شده را به‌صورت یک آرایه یک‌المانی `String[]` دریافت می‌کند. تصویر را با فرمت ارائه‌شده ذخیره یا بارگذاری کنید و `link[0]` را با ارجاعی که باید در خروجی Markdown ظاهر شود، جایگزین کنید.

منابع تولیدشده به فرمت SVG به‌طور جداگانه پردازش می‌شوند. یک callback با متد [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/markdownsaveoptions/) ثبت کنید. callback `MarkdownSvgImageSavingHandler` یک شیء [ISvgImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isvgimage/) و پارامتر یک‌المانی `String[] link` دریافت می‌کند. برای یک SVG هیچ آرگومان `ImageFormat` وجود ندارد؛ به‌جای آن داده‌های XML آن را از متد [ISvgImage.getSvgData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isvgimage/) بنویسید یا بارگذاری کنید. بسته به حالت صادرات و گروه‌بندی بصری، یک SVG در ارائه منبع می‌تواند رستر یا با محتویات دیگر ترکیب شود؛ منبع غیر‑SVG حاصل سپس به callback ذخیره‌سازی تصویر ارسال می‌شود. هنگامیکه هر منبع بصری صادرشده نیاز به پردازش سفارشی دارد، هر دو callback را ثبت کنید.

مقدار بازگشتی هندلر تعیین می‌کند چه کسی تصویر را پردازش می‌کند:

- اگر پس از ذخیره، بارگذاری، تبدیل یا پردازش دیگر تصویر و اختصاص مقدار معتبر به `link[0]`، `true` برگردانید. Aspose.Slides آن مقدار را به سند Markdown می‌نویسد و ذخیره‌سازی محلی پیش‌فرض را انجام نمی‌دهد.
- اگر `false` برگردانید، Aspose.Slides تصویر را به‌صورت محلی ذخیره کرده و پیوند آن را بر اساس مقادیری که با [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/markdownsaveoptions/) و [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/markdownsaveoptions/) تنظیم کرده‌اید، تولید می‌کند.

{{% alert color="warning" title="Important" %}}
یک هندلر که `true` برمی‌گرداند، مسئولیت تصویر را بر عهده می‌گیرد. اگر بدون اختصاص یک پیوند معتبر و غیرخالی `true` برگرداند، صادرات با `InvalidOperationException` شکست می‌خورد.
{{% /alert %}}

### **ذخیره‌سازی تصاویر در یک پوشه مبدا CDN و استفاده از URLهای خارجی**

مثال زیر `cdn-origin/presentations/quarterly-report` را به‌عنوان یک پوشه مبسر CDN سوار یا همگام‌سازی‌شده در نظر می‌گیرد. هر هندلر نام فایل تولیدشده را استخراج می‌کند، تصویر را در آن پوشه سفارشی ذخیره می‌کند و ارجاع محلی تولیدشده را با یک URL عمومی CDN جایگزین می‌نماید. خود مثال هیچ بارگذاری شبکه‌ای انجام نمی‌دهد: URL تنها پس از سوار شدن پوشه به عنوان مبسر CDN یا انتشار فایل‌ها در CDN معتبر می‌شود. برای ذخیره‌سازی شیئی، نوشتن به سیستم فایل را با عملیات بارگذاری SDK ذخیره‌سازی جایگزین کنید و `link[0]` را تنها پس از موفقیت‌آمیز شدن بارگذاری اختصاص دهید.

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

هندلر bitmap به‌طور عمدی برای تصاویری که کوچکتر از 128 × 128 پیکسل هستند `false` برمی‌گرداند، بنابراین Aspose.Slides آن تصاویر را به `output/fallback-images` ذخیره می‌کند با رفتار پیش‌فرض. منابع bitmap و metafile بزرگتر، همراه با منابع SVG، توسط کد سفارشی پردازش می‌شوند. برای مثال، یک ارجاع محلی تولیدشده مانند `fallback-images/image1.png` به `https://cdn.example.com/presentations/quarterly-report/image1.png` تبدیل می‌شود. هندلرها فقط هنگام نوشتن فایل‌ها از مسیرهای سیستم‌عامل استفاده می‌کنند؛ پیوندهای نوشته‌شده در Markdown از اسلش جلو (`/`) و نام‌های فایل URL‑escaped استفاده می‌کند. هنگام ساخت پیوندهای نسبی همین قاعده را اعمال کنید: از `/` استفاده کنید، نه جداکننده مسیر بومی سیستم.

## **سوالات متداول**

**آیا می‌توان یک هندلر هم تصاویر رستر و هم تصاویر SVG را پردازش کرد؟**

نه. برای منابع bitmap و metafile تولیدشده از [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/markdownsaveoptions/) استفاده کنید و برای منابع تولیدشده به‌صورت SVG از [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/markdownsaveoptions/) استفاده کنید. اولی شیء [IImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iimage/) و مقدار [ImageFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imageformat/) را فراهم می‌کند؛ دومی شیء [ISvgImage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isvgimage/) را ارائه می‌دهد که داده‌های SVG آن می‌تواند با [ISvgImage.getSvgData](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/isvgimage/) خوانده شود. یک SVG منبع که در طول صادرات رستر می‌شود، به‌جای SVG توسط callback ذخیره‌سازی تصویر پردازش می‌شود.

**چه اتفاقی می‌افتد وقتی یک هندلر ذخیره‌سازی تصویر `false` برمی‌گرداند؟**

Aspose.Slides از رفتار پیش‌فرض ذخیره‌سازی محلی استفاده می‌کند. مکان تصویر و ارجاع تولیدشده توسط مقادیری که با [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/markdownsaveoptions/) و [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/markdownsaveoptions/) تنظیم شده‌اند، کنترل می‌شود.

**آیا یک هندلر می‌تواند بدون ذخیره محلی تصویر، تنها یک URL ارائه دهد؟**

بله. هندلر می‌تواند تصویر را به ذخیره‌سازی شیئی بارگذاری یا به سرویس دیگری منتقل کند، URL حاصل را به `link[0]` اختصاص دهد و `true` برگرداند. هندلر باید پردازش را به‌صورت کامل انجام دهد؛ بازگشت `true` مانع ذخیره‌سازی محلی پیش‌فرض می‌شود.

**چرا صادرات Markdown یک `InvalidOperationException` از سمت هندلر می‌اندازد؟**

این استثنا زمانی رخ می‌دهد که هندلر `true` برگرداند اما پیوند معتبری ارائه ندهد. پیش از بازگشت `true` مسیر نسبی یا URL خارجی که باید در Markdown نوشته شود را به `link[0]` اختصاص دهید.

**کدام جداکننده مسیر باید در پیوندهای تصویر استفاده شود؟**

در پیوندهای Markdown و URLها از اسلش جلو (`/`) استفاده کنید. برای مسیرهای سیستم‌فایل از `Path.resolve` استفاده کنید و سپس مرجع Markdown را جداگانه ساخت یا نرمال کنید.

**آیا پیوندهای متنی هنگام صادرات به Markdown حفظ می‌شوند؟**

بله. پیوندهای متنی [hyperlinks](/slides/fa/androidjava/manage-hyperlinks/) به‌صورت پیوندهای استاندارد Markdown حفظ می‌شوند. [transitions](/slides/fa/androidjava/slide-transition/) و [animations](/slides/fa/androidjava/powerpoint-animation/) اسلاید تبدیل نمی‌شوند.

**آیا می‌توان ارائه‌ها را به‌صورت همزمان به Markdown تبدیل کرد؟**

می‌توانید فایل‌های ارائه مختلف را به‌صورت همزمان پردازش کنید، اما نباید همان نمونهٔ [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) را بین رشته‌ها به اشتراک بگذارید. راهنمایی‌های [multithreading](/slides/fa/androidjava/multithreading/) را دنبال کنید و برای هر فایل یک نمونهٔ جداگانه استفاده کنید.