---
title: صادرات ارائه‌ها به XAML در اندروید
linktitle: ارائه به XAML
type: docs
weight: 30
url: /fa/androidjava/export-to-xaml/
keywords:
- صادر کردن PowerPoint
- صادر کردن OpenDocument
- صادر کردن ارائه
- تبدیل PowerPoint
- تبدیل OpenDocument
- تبدیل ارائه
- PowerPoint به XAML
- OpenDocument به XAML
- ارائه به XAML
- PPT به XAML
- PPTX به XAML
- ODP به XAML
- ذخیره PPT به عنوان XAML
- ذخیره PPTX به عنوان XAML
- ذخیره ODP به عنوان XAML
- صادر کردن PPT به XAML
- صادر کردن PPTX به XAML
- صادر کردن ODP به XAML
- Android
- Java
- Aspose.Slides
description: "اسلایدهای PowerPoint و OpenDocument را به XAML در جاوا با استفاده از Aspose.Slides برای اندروید تبدیل کنید — راه‌حل سریع بدون Office که طرح شما را دست نخورده نگه می‌دارد."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد چگونه ارائه‌های PowerPoint را به XAML صادر کنید با استفاده از Aspose.Slides برای Android از طریق Java. شامل مقدمه‌ای کوتاه درباره XAML است، نشان می‌دهد چگونه یک ارائه را با تنظیمات پیش‌فرض به XAML ذخیره کنید، و نحوه سفارشی‌سازی صادرات را از طریق [XamlOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/xamloptions/) نشان می‌دهد، از جمله صادرات اسلایدهای مخفی. مقاله همچنین به چند سؤال رایج مرتبط با فونت‌های جایگزین، سازگاری با پشته XAML، و رفتار صادرات اسلایدهای مخفی پاسخ می‌دهد.

## **درباره XAML**

XAML یک زبان نشانه‌گذاری مبتنی بر XML است که برای توصیف رابط‌های کاربری در چارچوب‌هایی مانند WPF (Windows Presentation Foundation)، UWP (Universal Windows Platform) و Xamarin.Forms استفاده می‌شود.

می‌توانید با فایل‌های XAML در یک دیزاینر بصری کار کنید یا نشانه‌گذاری را به‌صورت مستقیم بنویسید و ویرایش کنید.

## **صادرات ارائه‌ها به XAML با گزینه‌های پیش‌فرض**

مثال زیر در Java نشان می‌دهد چگونه یک ارائه را با تنظیمات پیش‌فرض به XAML صادر کنید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions xamlOptions = new XamlOptions();
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

به‌طور پیش‌فرض، اسلایدهای صادر شده در یک زیرپوشهٔ `pres` در مسیر کاری فعلی فرآیند ذخیره می‌شوند. این پوشه به‌صورت خودکار ایجاد می‌شود و هر تصویری که نیاز باشد نیز در همانجا ذخیره می‌شود.

نام پوشهٔ خروجی از نام فایل منبع بدون پسوند گرفته می‌شود. برای `pres.pptx`، فایل‌های خروجی به صورت `pres/Slide_1.xaml`، `pres/Slide_2.xaml` و به همین ترتیب نامگذاری می‌شوند. حتی اگر مسیر مطلقی برای ارائهٔ ورودی بدهید، پوشهٔ خروجی به‌صورت نسبی نسبت به مسیر کاری فعلی ایجاد می‌شود، نه در کنار فایل ورودی.

در Android، از فایلی استفاده کنید که برنامهٔ شما به آن دسترسی داشته باشد. مسیر کاری فعلی ممکن است قابل نوشتن نباشد؛ از یک ذخیره‌ساز خروجی سفارشی استفاده کنید تا صادرات را در حافظه نگه دارید یا به فضای ذخیره‌سازی برنامه بنویسید، همان‌طور که در ادامه نشان داده شده است. XAML تولید شده برای WPF برای مصرف‌کنندهٔ سازگار است و منبعی برای طرح‌بندی Android نیست.

## **صادرات ارائه‌ها به XAML با گزینه‌های سفارشی**

از رابط [IXamlOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ixamloptions/) برای کنترل نحوهٔ صادرات Aspose.Slides یک ارائه به XAML استفاده کنید.

برای ذخیرهٔ خروجی در مکان سفارشی، [IXamlOutputSaver](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ixamloutputsaver/) را پیاده‌سازی کنید و یک نمونهٔ از پیاده‌سازی خود را به متد [setOutputSaver](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) از [XamlOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/xamloptions/) پاس کنید.

برای شامل‌کردن اسلایدهای مخفی در خروجی XAML، با `true` متد [setExportHiddenSlides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) را فراخوانی کنید، همان‌طور که در مثال زیر Java نشان داده شده است:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions xamlOptions = new XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

## **دریافت تمام مصنوعات XAML تولید شده**

یک صادرات XAML می‌تواند یک سند XAML برای هر اسلاید صادر شده به‌همراه تصاویر جداگانه و منابع پشتیبان تولید کند. یک [IXamlOutputSaver](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ixamloutputsaver/) سفارشی به [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) اختصاص دهید تا به‌جای استفاده از ذخیره‌ساز پیش‌فرض فایل‌سیستم، این مصنوعات را دریافت کنید. صادرات را با استفاده از متد مخصوص XAML [Presentation.save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-) که گزینه‌های XAML را می‌پذیرد، آغاز کنید.

### **درک چرخه حیات Callback**

صادرکننده برای هر مصنوع تولید شده به‌صورت جداگانه متد [IXamlOutputSaver.save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) را فراخوانی می‌کند:

- `path` معرف مصنوع است و می‌تواند شامل دایرکتوری‌های نسبی باشد. این اطلاعات را حفظ کنید زیرا XAML ممکن است منابع را با مسیرهای نسبی ارجاع دهد.
- `data` حاوی بایت‌های مصنوع است. تصاویر و سایر منابع باینری نباید به‌عنوان متن رمزگشایی شوند.
- ذخیره‌ساز مسئول نگه‌داری یا ذخیره‌سازی داده‌ها قبل از بازگشت است. مثال‌ها هر آرایهٔ بایت را در حافظهٔ متعلق به برنامه کپی می‌کنند.
- صادرات را تنها زمانی موفق درنظر بگیرید که عملیات ذخیرهٔ ارائه بازگردد و هر Callback به‌طور موفقیت‌آمیزی تکمیل شود. خطاهای ذخیره‌سازی را نادیده نگیرید یا نوشتن پس‌زمینهٔ بدون نظارت را آغاز نکنید. اگر پس از آن پایدارسازی انجام شود، موفقیت کلی را فقط پس از موفقیت آن مرحله گزارش کنید.

متد [XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) نیز برای ذخیره‌ساز سفارشی اعمال می‌شود. تنظیم پیش‌فرض `false` اسناد XAML اسلایدهای مخفی را حذف می‌کند. پاس دادن `true` آنها و هر منبع مورد نیاز برای صادراتشان را شامل می‌شود. تعداد منابع به ارائه بستگی دارد؛ فرض نکنید یک Callback برای هر اسلاید یا ترتیب ثابت Callback وجود دارد.

### **صادرات به حافظه و بررسی مصنوعات**

این مثال کامل `pres.pptx` را بارگذاری می‌کند، هر مصنوع را در یک [Map<String, byte[]>](https://docs.oracle.com/javase/8/docs/api/java/util/Map.html) جمع‌آوری می‌کند و نام، نوع و تعداد بایت آن را چاپ می‌کند. نام‌های ارائه‌شده را دقیقاً همان‌طور حفظ می‌کند. نام‌های تکراری مجموعه را نامعتبر می‌سازند به‌جای رونویسی بی‌صدا. مثال قبل از استفاده از نتایج این وضعیت را بررسی می‌کند.

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.nio.charset.StandardCharsets;
import java.util.Locale;

class MemoryXamlSaver implements IXamlOutputSaver {
    final Map<String, byte[]> artifacts = new LinkedHashMap<>();
    boolean valid = true;

    @Override
    public void save(String path, byte[] data) {
        if (artifacts.containsKey(path)) {
            valid = false;
            System.err.println("Export rejected: duplicate artifact name: " + path);
            return;
        }
        byte[] retainedData = data.clone();
        artifacts.put(path, retainedData);
    }
}

MemoryXamlSaver saver = new MemoryXamlSaver();
Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions options = new XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(true);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!saver.valid) {
    System.err.println("Export rejected: the artifact collection is invalid.");
    return;
}

boolean inspectXamlText = false;
for (Map.Entry<String, byte[]> artifact : saver.artifacts.entrySet()) {
    String name = artifact.getKey().toLowerCase(Locale.ROOT);
    boolean isXaml = name.endsWith(".xaml");
    boolean isImage = name.matches(".*\\.(png|jpg|jpeg|gif|bmp|tif|tiff|svg)$");
    String kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
    System.out.println(artifact.getKey() + ": " + artifact.getValue().length + " bytes (" + kind + ")");

    // فقط XAML را رمزگشایی کنید و فقط زمانی که نیاز به بازرسی متنی باشد.
    if (isXaml && inspectXamlText) {
        String markup = new String(artifact.getValue(), StandardCharsets.UTF_8);
        System.out.println(markup);
    }
}
```

بررسی پسوندها برای بازرسی مفید است؛ تمام مصنوعات، از جمله انواع منابع ناشناخته را نگه دارید. هنگام ذخیره یا انتقال بایت‌ها، آنها را دست‌نخورده بگذارید. برای XAML که نیاز به پردازش متنی دارد، فقط از سازندهٔ [String](https://docs.oracle.com/javase/8/docs/api/java/lang/String.html#String-byte:A-java.nio.charset.Charset-) با UTF‑8 استفاده کنید.

### **بسته‌بندی مصنوعات جمع‌آوری شده در یک بایگانی ZIP**

این مثال مستقل صادرات را جمع‌آوری، نام‌ها را اعتبارسنجی و بایت‌های اصلی را در یک بایگانی ZIP می‌نویسد. مسیر `/path/to/app/files` را با مسیری که متد [getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir()) زمینهٔ Android شما برمی‌گرداند، جایگزین کنید. نام بایگانی منحصربه‌فرد، کارهای صادرات همزمان را جدا می‌کند. ورودی‌های ZIP از اسلش‌های جلو استفاده می‌کنند و دایرکتوری‌های نسبی را حفظ می‌کنند. نام‌های ناامن یا نام‌هایی که پس از نرمال‌سازی با هم تداخل دارند، تمام بسته را قبل از نوشتن رد می‌کند.

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.io.IOException;
import java.io.File;
import java.io.FileOutputStream;
import java.util.Set;
import java.util.TreeSet;
import java.util.zip.ZipEntry;
import java.util.zip.ZipOutputStream;

class MemoryXamlSaver implements IXamlOutputSaver {
    final Map<String, byte[]> artifacts = new LinkedHashMap<>();
    boolean valid = true;

    @Override
    public void save(String path, byte[] data) {
        if (artifacts.containsKey(path)) {
            valid = false;
            System.err.println("Export rejected: duplicate artifact name: " + path);
            return;
        }
        byte[] retainedData = data.clone();
        artifacts.put(path, retainedData);
    }
}

MemoryXamlSaver saver = new MemoryXamlSaver();
Presentation presentation = new Presentation("pres.pptx");
try {
    XamlOptions options = new XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(false);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!saver.valid) {
    System.err.println("Export rejected: the artifact collection is invalid.");
    return;
}

Map<String, byte[]> entries = new LinkedHashMap<>();
Set<String> entryNames = new TreeSet<>(String.CASE_INSENSITIVE_ORDER);
for (Map.Entry<String, byte[]> artifact : saver.artifacts.entrySet()) {
    String entryName = artifact.getKey().replace('\\', '/');
    String[] segments = entryName.split("/", -1);
    boolean unsafeName = entryName.startsWith("/") || entryName.contains(":");
    for (String segment : segments) {
        unsafeName |= segment.trim().isEmpty() || segment.equals(".") || segment.equals("..");
    }

    if (unsafeName || !entryNames.add(entryName)) {
        System.err.println("Export rejected: unsafe or duplicate artifact name: " + artifact.getKey());
        return;
    }
    entries.put(entryName, artifact.getValue());
}

File exportDirectory = new File("/path/to/app/files");
try {
    File archiveFile = File.createTempFile("xaml-", ".zip", exportDirectory);
    try (FileOutputStream archiveOutput = new FileOutputStream(archiveFile); ZipOutputStream archive = new ZipOutputStream(archiveOutput)) {
        for (Map.Entry<String, byte[]> artifact : entries.entrySet()) {
            ZipEntry entry = new ZipEntry(artifact.getKey());
            archive.putNextEntry(entry);
            archive.write(artifact.getValue());
            archive.closeEntry();
        }
    }

    // دایرکتوری ZIP با بسته شدن قبل از گزارش موفقیت نهایی شده است.
    System.out.println("Saved " + entries.size() + " artifacts to " + archiveFile);
} catch (IOException exception) {
    System.err.println("Archive persistence failed: " + exception.getMessage());
}
```

مثال از [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) برای نوشتن یک بایگانی محلی استفاده می‌کند؛ صادرکننده خود فایل‌های XAML یا تصویر جداگانه‌ای نمی‌نویسد. برای ذخیره‌سازی از راه دور، مرحله نوشتن بایگانی را با بارگذاری آرایه‌های بایتی جمع‌آوری‌شده جایگزین کنید. از یک شناسهٔ کار صادرات به‌همراه نام نسبی کامل مصنوع به‌عنوان کلید بلب استفاده کنید، یا شناسهٔ کار، نام نسبی و دادهٔ باینری را در یک ردیف دیتابیس ذخیره کنید. پس از تکمیل تمام بارگذاری‌ها یا تراکنش دیتابیس، کار را منتشر کنید. در صورت شکست پایدارسازی، خروجی جزئی را پاک کنید.

برای ارائه‌های بزرگ، یک ذخیره‌ساز سفارشی می‌تواند هر مصنوع را مستقیماً در فضای ذخیره‌سازی برنامه ذخیره کند تا از نگه‌داری یک نسخهٔ اضافی از کل صادرات در حافظه برنامه جلوگیری شود. هر Callback را از دید صادرکننده همگام نگه دارید: فقط پس از پذیرش بایت‌ها توسط مقصد برگردید و اجازه دهید خطاها به فراخوانده برسند.

### **حفظ نام منابع و تأیید مراجع**

- هنگام نیاز به مقصد، جداکننده‌های مسیر را نرمال کنید، اما دایرکتوری‌های نسبی را حفظ کنید. مگر اینکه مطمئن باشید هر نام تولید شده یکتا است و مراجع منابع معتبر می‌مانند، از [File.getName](https://developer.android.com/reference/java/io/File#getName()) استفاده نکنید.
- اعتبارسنجی نام خاص مقصد را اعمال کنید. هنگام نوشتن فایل‌های جداگانه، مسیرهای ریشه‌ای و بخش‌های Traversal را رد کنید، مقصد را با [File.getCanonicalPath](https://developer.android.com/reference/java/io/File#getCanonicalPath()) حل کنید و اطمینان حاصل کنید که در زیر دایرکتوری مورد نظر صادرات باقی می‌ماند، شامل جداکنندهٔ دایرکتوری در بررسی containment. از یک دایرکتوری تحت کنترل برنامه بدون لینک‌های نمادین که می‌توانند نوشتن را تغییر مسیر دهند، استفاده کنید.
- برای هر کار صادرات، یک ذخیره‌ساز و فضای نام ذخیره‌سازی جداگانه استفاده کنید. پس از نرمال‌سازی جداکننده‌ها و وفقاً با قوانین حساسیت به حروف مقصد، تداخل‌ها را شناسایی کنید.
- پیش از انتشار، هر سند XAML را به‌عنوان XML تجزیه کنید و مراجع منابع مبتنی بر فایل آن را بررسی کنید، مانند ویژگی‌های `Source` یا `ImageSource` تصویر. هر URI نسبی را نسبت به دایرکتوری مصنوع XAML حاوی‌کنندهٔ آن حل کنید، نام ذخیره‌سازی حاصل را نرمال کنید و تأیید کنید که کلید نقشهٔ مربوطه، ورودی ZIP یا شیء ذخیره‌شده وجود دارد. URIهای خارجی و عبارات نشانه‌گذاری XAML را از نام‌های فایل نسبی جدا کنید.

به‌عنوان مثال، اگر `pres/Slide_1.xaml` به `images/image1.png` ارجاع دهد، منبع ذخیره‌شده باید به‌صورت `pres/images/image1.png` در دسترس باشد. فقط نگه داشتن `image1.png` این رابطه را خراب می‌کند. برای ذخیره‌سازی شیء، همان ساختار زیر پیشوند کار را حفظ کنید و URLهای منابع را در دسترس مصرف‌کنندهٔ XAML قرار دهید. بایگانی ZIP کامل را باز کنید تا نام‌های ورودی و بایت‌های منابع را تأیید کنید و اسلایدهای نماینده را در محیط XAML هدف بارگذاری کنید تا تأیید شود تصاویر به‌درستی حل می‌شوند.

## **پرسش‌های متداول**

**چگونه می‌توانم اطمینان حاصل کنم که فونت‌ها پیش‌بینی‌پذیر هستند اگر فونت اصلی در دستگاه موجود نباشد؟**

در [XamlOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/xamloptions/) متد [setDefaultRegularFont](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) را فراخوانی کنید — این متد به‌عنوان فونت جایگزین در هنگام صادرات استفاده می‌شود وقتی فونت اصلی موجود نباشد. این تضمین نمی‌کند که XAML تولید شده به فونت جایگزین ارجاع دهد یا فونت در دستگاه هدف موجود باشد. مطمئن شوید فونت‌های ارجاع‌شده توسط XAML در محیطی که نمایش داده می‌شود، موجود باشند.

**آیا XAML صادر شده فقط برای WPF درنظر گرفته شده یا می‌تواند در سایر پشته‌های XAML نیز استفاده شود؟**

Aspose.Slides XAML مخصوص WPF را از طریق API عمومی خود صادر می‌کند. سازگاری با سایر پشته‌های XAML مانند UWP و Xamarin.Forms تضمین نشده است. markup تولید شده را در محیط هدف خود آزمایش کنید.

**آیا اسلایدهای مخفی پشتیبانی می‌شوند و چگونه می‌توانم از صادرات پیش‌فرض آنها جلوگیری کنم؟**

به‌صورت پیش‌فرض، اسلایدهای مخفی شامل نمی‌شوند. می‌توانید این رفتار را از طریق متد [setExportHiddenSlides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) در [XamlOptions](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/xamloptions/) کنترل کنید — اگر به صادرات آنها نیازی ندارید، این گزینه را غیرفعال بگذارید.