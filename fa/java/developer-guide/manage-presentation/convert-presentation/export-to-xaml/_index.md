---
title: "صادرات ارائه‌ها به XAML در جاوا"
linktitle: "ارائه به XAML"
type: docs
weight: 30
url: /fa/java/export-to-xaml/
keywords:
- "صادرات PowerPoint"
- "صادرات OpenDocument"
- "صادرات ارائه"
- "تبدیل PowerPoint"
- "تبدیل OpenDocument"
- "تبدیل ارائه"
- "PowerPoint به XAML"
- "OpenDocument به XAML"
- "ارائه به XAML"
- "PPT به XAML"
- "PPTX به XAML"
- "ODP به XAML"
- "ذخیره PPT به عنوان XAML"
- "ذخیره PPTX به عنوان XAML"
- "ذخیره ODP به عنوان XAML"
- "صادرات PPT به XAML"
- "صادرات PPTX به XAML"
- "صادرات ODP به XAML"
- Java
- Aspose.Slides
description: "تبدیل اسلایدهای PowerPoint و OpenDocument به XAML در جاوا با استفاده از Aspose.Slides — راه‌حل سریع و بدون نیاز به Office که چیدمان شما را همان‌گونه حفظ می‌کند."
---
## **بررسی کلی**

این مقاله توضیح می‌دهد چگونه ارائه‌های PowerPoint را به XAML با استفاده از Aspose.Slides صادر کنید. شامل معرفی کوتاهی از XAML است، نشان می‌دهد چگونه یک ارائه را با تنظیمات پیش‌فرض به XAML ذخیره کنید و چگونگی سفارشی‌سازی خروجی از طریق [XamlOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides.xamloptions/)، از جمله صادر کردن اسلایدهای مخفی. مقاله همچنین به چند سؤال رایج دربارهٔ فونت‌های جایگزین، سازگاری استک XAML و رفتار صادرات اسلایدهای مخفی پاسخ می‌دهد.

## **درباره XAML**

XAML یک زبان علامت‌گذاری مبتنی بر XML است که برای توصیف رابط‌های کاربری در چارچوب‌هایی مانند WPF (Windows Presentation Foundation)، UWP (Universal Windows Platform) و Xamarin.Forms استفاده می‌شود.

می‌توانید با یک طراح بصری با فایل‌های XAML کار کنید یا مستقیماً علامت‌گذاری را بنویسید و ویرایش کنید.

## **صادر کردن ارائه‌ها به XAML با گزینه‌های پیش‌فرض**

مثال زیر به زبان Java نشان می‌دهد چگونه یک ارائه را با تنظیمات پیش‌فرض به XAML صادر کنید:

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

به‌طور پیش‌فرض، اسلایدهای صادر شده در یک زیرپوشهٔ `pres` از پوشهٔ کاری جاری فرآیند ذخیره می‌شوند، که از مسیر خالی با استفاده از [Paths.get](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Paths.html#get-java.lang.String-java.lang.String...-) حل می‌شود. این پوشه به‌صورت خودکار ایجاد می‌شود و هر تصویر لازم نیز در همانجا ذخیره می‌شود.

نام پوشهٔ خروجی از نام فایل منبع بدون پسوند آن گرفته می‌شود. برای `pres.pptx`، فایل‌های خروجی به شکل `pres/Slide_1.xaml`، `pres/Slide_2.xaml` و به همین ترتیب نام‌گذاری می‌شوند. حتی اگر مسیری مطلق به ارائه ورودی بدهید، پوشهٔ خروجی نسبت به پوشهٔ کاری جاری ایجاد می‌شود، نه در کنار فایل ورودی.

## **صادر کردن ارائه‌ها به XAML با گزینه‌های سفارشی**

از رابط [IXamlOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ixamloptions/) برای کنترل نحوهٔ صادرات یک ارائه به XAML توسط Aspose.Slides استفاده کنید.

برای ذخیرهٔ خروجی در مکان سفارشی، پیاده‌سازی [IXamlOutputSaver](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ixamloutputsaver/) را انجام دهید و یک نمونه از پیاده‌سازی خود را به متد [setOutputSaver](https://reference.aspose.com/slides/fa/java/com.aspose.slides.xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) در [XamlOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides.xamloptions/) پاس بدهید.

برای گنجاندن اسلایدهای مخفی در خروجی XAML، متد [setExportHiddenSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides.xamloptions/#setExportHiddenSlides-boolean-) را با مقدار `true` فراخوانی کنید، همان‌طور که در مثال زیر به زبان Java نشان داده شده است:

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

## **جمع‌آوری تمام artefactsهای تولید شدهٔ XAML**

یک صادرات XAML می‌تواند برای هر اسلاید صادر شده یک سند XAML به‌علاوهٔ تصاویر و منابع پشتیبان جداگانه تولید کند. برای دریافت این artefacts به‌جای استفاده از ذخیره‌کنندهٔ پیش‌فرض سیستم فایل، یک [IXamlOutputSaver](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ixamloutputsaver/) سفارشی به [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/fa/java/com.aspose.slides.xamloptions/#setOutputSaver-com.aspose.slides.IXamlOutputSaver-) اختصاص دهید. صادرات را با بارگذاری مخصوص XAML از طریق متد overload [Presentation.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides.presentation/#save-com.aspose.slides.IXamlOptions-) که گزینه‌های XAML را می‌پذیرد، آغاز کنید.

### **درک چرخه‌حیات Callback**

صادرکننده برای هر artefact تولید شده متد [IXamlOutputSaver.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides.ixamloutputsaver/#save-java.lang.String-byte:A-) را به‌صورت جداگانه فراخوانی می‌کند:

- `path` شناسهٔ artefact است و می‌تواند شامل دایرکتوری‌های نسبی باشد. این اطلاعات را نگه دارید زیرا XAML ممکن است منابع را با مسیرهای نسبی ارجاع دهد.
- `data` شامل بایت‌های artefact است. تصاویر و سایر منابع باینری نباید به‌عنوان متن دیکود شوند.
- ذخیره‌کننده مسئول حفظ یا ماندگار کردن داده‌ها پیش از بازگشت است. مثال‌ها هر آرایهٔ بایت را در حافظهٔ متعلق به برنامه کپی می‌کنند.
- صادرات را تنها زمانی موفق بنظر می‌آید که عملیات ذخیرهٔ ارائه بازگردد و همهٔ callbacks با موفقیت تکمیل شوند. خطاهای ذخیره‌سازی را گریز ندهید یا نوشتن‌های پس‌زمینهٔ بدون نظارت را آغاز نکنید. اگر ماندگاری بعداً انجام شد، موفقیت کلی را فقط پس از موفقیت آن مرحله گزارش کنید.

متد [XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides.xamloptions/#setExportHiddenSlides-boolean-) نیز برای ذخیره‌کنندهٔ سفارشی اعمال می‌شود. مقدار پیش‌فرض `false` اسناد XAML اسلایدهای مخفی را حذف می‌کند. عبور مقدار `true` آنها و هر منبع موردنیاز برای صادرات را گنجانده و تعداد منابع بسته به ارائه متفاوت است؛ فرض نشود که یک callback برای هر اسلاید یا ترتیب ثابت وجود دارد.

### **صادرات به حافظه و بررسی artefacts**

این مثال کامل `pres.pptx` را بارگذاری می‌کند، هر artefact را در یک [Map<String, byte[]>](https://docs.oracle.com/javase/8/docs/api/java/util/Map.html) جمع‌آوری می‌کند و نام، نوع و تعداد بایت آن را چاپ می‌نماید. نام‌های تأمین‌شده دقیقاً حفظ می‌شوند. نام‌های تکراری مجموعه را نامعتبر می‌سازند به‌جای اینکه به‌صورت ساکن یک artefact را بازنویسی کنند. مثال این موضوع را پیش از استفاده از نتایج بررسی می‌کند.

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

بررسی پسوندها برای بازرسی مفید است؛ تمام artefacts، از جمله انواع منبع ناآشنا را نگه دارید. هنگام ذخیره یا انتقال بایت‌ها، آنها را دست‌نخورده نگه دارید. برای پردازش متنی XAML فقط از سازندهٔ [String](https://docs.oracle.com/javase/8/docs/api/java/lang/String.html#String-byte:A-java.nio.charset.Charset-) با UTF-8 استفاده کنید.

### **بسته‌بندی artefacts جمع‌آوری‌شده در یک آرشیو ZIP**

این مثال مستقل، صادرات را جمع‌آوری می‌کند، نام‌های آن را اعتبارسنجی می‌نماید و بایت‌های اصلی را در یک آرشیو ZIP می‌نویسد. یک نام آرشیو یکتا، کارهای صادراتی همزمان را جدا می‌کند. ورودی‌های ZIP از اسلش‌های مستقیم استفاده می‌کنند و دایرکتوری‌های نسبی را حفظ می‌نمایند. نام‌های ناامن یا نام‌هایی که پس از نرمال‌سازی با هم تداخل پیدا کنند، قبل از نوشتن بستهٔ کامل را رد می‌کنند.

```java
import com.aspose.slides.*;
import java.util.LinkedHashMap;
import java.util.Map;
import java.io.IOException;
import java.io.OutputStream;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardOpenOption;
import java.util.Set;
import java.util.TreeSet;
import java.util.UUID;
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

Path archivePath = Paths.get("xaml-" + UUID.randomUUID() + ".zip");
try {
    OutputStream output = Files.newOutputStream(archivePath, StandardOpenOption.CREATE_NEW, StandardOpenOption.WRITE);
    try (OutputStream archiveOutput = output; ZipOutputStream archive = new ZipOutputStream(archiveOutput)) {
        for (Map.Entry<String, byte[]> artifact : entries.entrySet()) {
            ZipEntry entry = new ZipEntry(artifact.getKey());
            archive.putNextEntry(entry);
            archive.write(artifact.getValue());
            archive.closeEntry();
        }
    }

    // دایرکتوری ZIP با بستن قبل از گزارش موفقیت تکمیل شده است.
    System.out.println("Saved " + entries.size() + " artifacts to " + archivePath);
} catch (IOException exception) {
    System.err.println("Archive persistence failed: " + exception.getMessage());
}
```

مثال از [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) برای نوشتن یک آرشیو محلی استفاده می‌کند؛ خود صادرکننده فایل‌های XAML یا تصویر جداگانه‌ای نمی‌نویسد. برای ذخیره‌سازی از راه دور، مرحلهٔ نوشتن آرشیو را با آپلود آرایه‌های بایتی جمع‌آوری‌شده عوض کنید. از شناسهٔ کار صادرات به‌همراه نام نسبی کامل artefact به‌عنوان کلید blob استفاده کنید یا شناسهٔ کار، نام نسبی و دادهٔ باینری را در یک ردیف پایگاه‌داده ذخیره کنید. پس از تکمیل همهٔ آپلودها یا کمیت‌گذاری تراکنش پایگاه‌داده، کار را منتشر کنید. در صورت شکست ماندگاری، خروجی جزئی را پاک کنید.

برای ارائه‌های بزرگ، یک ذخیره‌کنندهٔ سفارشی می‌تواند هر artefact را مستقیماً در ذخیره‌سازی برنامه بنویسد تا نیازی به نگهداری یک کپی اضافی از کل صادرات در حافظه برنامه نباشد. از نظر صادرکننده، هر callback را همزمان نگه دارید: تنها پس از اینکه مقصد بایت‌ها را پذیرفت بازگردید و اجازه دهید خطاها به فراخوانده برسند.

### **حفظ نام منابع و تأیید ارجاعات**

- هنگام نیاز به جداکنندهٔ مسیر مقصد، آنها را نرمال کنید ولی دایرکتوری‌های نسبی را حفظ کنید. مگر اینکه مطمئن باشید هر نام تولید‌شده یکتا است و ارجاعات منبع معتبر می‌مانند، از [Path.getFileName](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Path.html#getFileName--) استفاده نکنید.
- اعتبارسنجی نام خاص مقصد را اعمال کنید. هنگام نوشتن فایل‌های منفرد، مسیرهای ریشه‌ای و بخش‌های Traversal را رد کنید، مقصد را با [Path.toAbsolutePath](https://docs.oracle.com/javase/8/docs/api/java/nio/file/Path.html#toAbsolutePath--) حل کنید و اطمینان حاصل کنید که زیر مسیری که هدف صادرات است باقی می‌ماند؛ بررسی شامل جداکنندهٔ دایرکتوری در بررسی containment باشد. از یک دایرکتوری تحت کنترل برنامه استفاده کنید که لینک‌های نمادی ندارند که ممکن است نوشتار را هدایت کنند.
- برای هر کار صادرات، یک ذخیره‌کننده و فضای نام جداگانه استفاده کنید. پس از نرمال‌سازی جداکننده، تصادفی‌ها را بر اساس حساسیت به حروف کوچک/بزرگ مقصد شناسایی کنید.
- پیش از انتشار، هر سند XAML را به‌عنوان XML تجزیه کنید و ارجاعات منابع مبتنی بر فایل آن را بررسی کنید، مانند ویژگی‌های `Source` یا `ImageSource` تصویر. هر URI نسبی را نسبت به دایرکتوری artefact XAML حاوی آن حل کنید، نام ذخیره‌سازی حاصل را نرمال کنید و تأیید کنید که کلید نقشهٔ مربوطه، ورودی ZIP یا شیء ذخیره‌شده وجود دارد. URIهای خارجی و عبارات علامت‌گذاری XAML را جدا از نام‌های فایل نسبی بررسی کنید.

به‌عنوان مثال، اگر `pres/Slide_1.xaml` به `images/image1.png` ارجاع دهد، منبع ذخیره‌شده باید به‌صورت `pres/images/image1.png` موجود باشد. فقط داشتن `image1.png` این رابطه را می‌شکند. برای ذخیره‌سازی شیء، همان ساختار زیر پیشوند کار را حفظ کنید و URLهای منبع را برای مصرف‌کنندهٔ XAML قابل دسترس سازید. ZIP کامل را مجدداً باز کنید تا نام ورودی‌ها و بایت‌های منبع را تأیید کنید و اسلایدهای نمایان را در محیط هدف XAML بارگذاری کنید تا اطمینان حاصل شود تصاویر به‌درستی حل می‌شوند.

## **پرسش‌های متداول**

**چگونه می‌توانم فونت‌های قابل پیش‌بینی داشته باشم اگر فونت اصلی در ماشین موجود نباشد؟**

در [XamlOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides.xamloptions/) متد [setDefaultRegularFont](https://reference.aspose.com/slides/fa/java/com.aspose.slides.saveoptions/#setDefaultRegularFont-java.lang.String-) را فراخوانی کنید — این فونت به‌عنوان فونت جایگزین در زمان صادرات استفاده می‌شود وقتی فونت اصلی موجود نباشد. این تضمین نمی‌کند که XAML تولید شده به فونت جایگزین ارجاع دهد یا اینکه فونت در ماشین مقصد موجود باشد. اطمینان حاصل کنید فونت‌های ارجاع‌شده توسط XAML در محیطی که نمایش داده می‌شود در دسترس باشند.

**آیا XAML صادر شده فقط برای WPF است یا می‌تواند در سایر استک‌های XAML نیز مورد استفاده قرار گیرد؟**

Aspose.Slides XAML مربوط به WPF را از طریق API عمومی خود صادر می‌کند. سازگاری با سایر استک‌های XAML مانند UWP و Xamarin.Forms تضمین نمی‌شود. علامت‌گذاری تولیدشده را در محیط هدف خود آزمایش کنید.

**آیا اسلایدهای مخفی پشتیبانی می‌شوند و چگونه می‌توانم از صادرات پیش‌فرض آنها جلوگیری کنم؟**

به‌طور پیش‌فرض، اسلایدهای مخفی گنجانده نمی‌شوند. می‌توانید این رفتار را با استفاده از [setExportHiddenSlides](https://reference.aspose.com/slides/fa/java/com.aspose.slides.xamloptions/#setExportHiddenSlides-boolean-) در [XamlOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides.xamloptions/) کنترل کنید — اگر نیازی به صادرات آنها ندارید این گزینه را غیرفعال بگذارید.