---
title: نیازمندی‌های سیستم
type: docs
weight: 60
url: /fa/java/system-requirements/
keywords:
- نیازمندی‌های سیستم
- پلتفرم‌های پشتیبانی‌شده
- نسخه‌های جاوا
- JDK
- JRE
- fontconfig
- قلم‌ها
- Docker
- Alpine
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "قبل از نصب Aspose.Slides for Java بررسی کنید که چه چیزهایی نیاز دارد: نسخه‌های پشتیبانی‌شدهٔ جاوا و سیستم‌عامل‌ها، و کتابخانهٔ قلم و قلم‌هایی که Linux نیاز دارد."
---
## **معرفی**

Aspose.Slides for Java یک کتابخانه مستقل است: نیازی به Microsoft PowerPoint یا Microsoft Office ندارد. این کتابخانه یک فایل JAR تک است که در مخزن Maven شرکت Aspose منتشر شده است. فایل JAR فقط شامل کلاس‌ها و منابع جاوا است، هیچ کتابخانه‌ی بومی ندارد و هیچ وابستگی‌ای به کتابخانه‌های دیگر اعلام نمی‌کند. بنابراین این فایل بر روی تمام سیستم‌عامل‌ها و پردازندگانی که یک Java Runtime پشتیبانی‌شده برای آن‌ها موجود است، اجرا می‌شود.

این مقاله نسخه‌های پشتیبانی‌شده‌ی جاوا و سیستم‌عامل‌ها و کتابخانه‌ی قلم و قلم‌هایی که لینوکس به آن‌ها نیاز دارد را فهرست می‌کند و با یک برنامهٔ کوتاه که تنظیمات شما را بررسی می‌کند، خاتمه می‌یابد. برای افزودن کتابخانه به یک پروژه، به بخش [Installation](/slides/fa/java/installation/) مراجعه کنید.

## **نسخه‌های پشتیبانی‌شده‌ی جاوا**

Aspose.Slides for Java بر روی Java 8 یا بالاتر، با JDK یا JRE اجرا می‌شود. این شامل نسخه‌های پشتیبانی بلندمدت Java 8، 11، 17، 21 و 25 و همچنین نسخه‌های بعدی مانند Java 26 و Java 27 می‌شود. Java Runtime می‌تواند از هر فروشنده‌ای باشد، برای مثال Eclipse Temurin، Amazon Corretto، Oracle یا بسته‌های OpenJDK توزیع‌های لینوکس.

Aspose.Slides به هیچ گزینه‌ای از JVM مانند `--add-opens` در هیچ‌یک از این نسخه‌ها نیاز ندارد. در Java 11، JVM هشداری با متن «WARNING: An illegal reflective access operation has occurred» چاپ می‌کند؛ این هشدار نتیجهٔ نهایی را تحت تأثیر قرار نمی‌دهد.

{{% alert color="warning" title="Warning" %}}
Java 6 و Java 7 منسوخ شده‌اند. Aspose.Slides for Java 26.9 هنوز بر روی آن‌ها اجرا می‌شود اما هشدار منسوخیت چاپ می‌کند. از نسخهٔ 26.10 به بعد، حداقل نسخهٔ مورد نیاز Java 8 است و Java 6 و Java 7 دیگر پشتیبانی نمی‌شوند.
{{% /alert %}}

پروژهٔ Maven و دستورات موجود در [Installation](/slides/fa/java/installation/) به JDK 11 یا بالاتر نیاز دارند. با Java 8، برنامهٔ خود را همان‌طور که در بخش [Check Your Setup](#check-your-setup) نشان داده شده است، کامپایل و اجرا کنید.

## **سیستم‌عامل‌های پشتیبانی‌شده**

به دلیل اینکه فایل JAR هیچ کد بومی ندارد، Aspose.Slides for Java بر روی Windows، Linux و macOS و بر روی هر معماری پردازنده‌ای که Java Runtime از آن پشتیبانی می‌کند (مانند x64 و ARM64) اجرا می‌شود. در Windows، تنها نیاز به Java Runtime است. در Linux، پشتیبانی از قلم‌ها همچنین به کتابخانهٔ قلم و قلم‌های توصیف‌شده در بخش [Linux](#linux) نیاز دارد.

## **لینوکس**

Aspose.Slides for Java متن را با استفاده از پشتیبانی قلم Java Runtime می‌چید و رسم می‌کند. در Linux، این پشتیبانی به کتابخانهٔ fontconfig و حداقل یک قلم نصب‌شده نیاز دارد. اکثر تصاویر رسمی توزیع‌های لینوکس هیچ‌یک از این‌ها را ندارند. بدون آن‌ها، اولین مثال در بخش [Create Presentations](/slides/fa/java/create-presentation/) هنگام ذخیرهٔ ارائه، شکست می‌خورد، فایلی خالی می‌گذارند و خطای زیر را گزارش می‌دهد:

```text
java.lang.RuntimeException: Fontconfig head is null, check your fonts or fonts configuration
```

تصاویر رسمی `eclipse-temurin` برای Ubuntu و Alpine Linux از پیش شامل fontconfig و قلم‌های DejaVu هستند، بنابراین نیازی به نصب چیزی روی آن‌ها نیست. در سایر سیستم‌ها، بسته‌های زیر را نصب کنید. دستورات Debian، Ubuntu و Red Hat از `sudo` استفاده می‌کنند؛ در یک Dockerfile، این دستورات را در یک دستور `RUN` بدون `sudo` اجرا کنید. قلم‌های DejaVu برای اجرای Aspose.Slides کافی هستند؛ قلم‌هایی که ارائه‌های شما استفاده می‌کنند در بخش [Fonts](#fonts) پوشش داده شده‌اند.

### **دبیان و اوبونتو**

اگر جاوا را از بسته‌های Debian یا Ubuntu با تنظیمات پیش‌فرض `apt-get` نصب کنید، همان‌طور که دستور در بخش [Installation](/slides/fa/java/installation/#linux) نشان می‌دهد، بسته‌های جاوا همچنین کتابخانهٔ fontconfig، قلم‌های DejaVu و کتابخانهٔ HarfBuzz را که این بسته‌های جاوا به آن نیاز دارند، نصب می‌کنند و چیز دیگری لازم نیست.

با یک Java Runtime از منبع دیگر، مانند آرشیو Eclipse Temurin، fontconfig و قلم‌های DejaVu را نصب کنید:

```bash
sudo apt-get update && sudo apt-get install -y fontconfig fonts-dejavu-core
```

یک Dockerfile اغلب بسته‌های Java Debian یا Ubuntu را نصب می‌کند، مانند `openjdk-21-jdk-headless` یا `default-jdk-headless`، با گزینهٔ `--no-install-recommends` که هر سه را نادیده می‌گیرد. با دستور بالا fontconfig و قلم‌های DejaVu را نصب کنید و HarfBuzz را نیز نصب نمایید:

```bash
sudo apt-get install -y libharfbuzz0b
```

بدون HarfBuzz، این بسته‌های جاوا پیام زیر را چاپ می‌کنند: `Please install the openjdk-*-jre package or recommended packages for openjdk-*-jre-headless` و ذخیره‌سازی با خطای `UnsatisfiedLinkError` که گزارش می‌دهد `libharfbuzz.so.0` قابل باز شدن نیست، مواجه می‌شود.

### **Red Hat Enterprise Linux**

بسته‌های `java-<version>-openjdk-headless` در Red Hat Enterprise Linux کتابخانهٔ fontconfig را نصب نمی‌کنند. آن را همراه با قلم‌های DejaVu نصب کنید:

```bash
sudo dnf install -y fontconfig dejavu-sans-fonts
```

بسته‌های کامل `java-<version>-openjdk` fontconfig و قلم‌ها را به عنوان وابستگی نصب می‌کنند و همین‌طور بسته‌های Amazon Corretto برای Amazon Linux 2023، مانند `java-21-amazon-corretto-headless`.

### **Alpine Linux**

در یک Dockerfile مبتنی بر Alpine Linux، fontconfig و قلم‌های DejaVu را نصب کنید:

```dockerfile
RUN apk add --no-cache fontconfig ttf-dejavu
```

در نسخه‌های فعلی Alpine، `ttf-dejavu` بستهٔ `font-dejavu` را نصب می‌کند. جاوا را با بستهٔ `openjdk<version>-jre` یا `openjdk<version>-jdk` نصب کنید، برای مثال `openjdk25-jdk`. بسته‌های `openjdk<version>-jre-headless` در Alpine Linux شامل کتابخانهٔ قلم جاوا نیستند، بنابراین برنامه با خطای `UnsatisfiedLinkError: no fontmanager in system library path` even when fonts are installed.

### **قلم‌ها**

برای اینکه متن با قلم‌ها و متریک‌های صحیح رندر شود، قلم‌هایی که ارائه‌های شما استفاده می‌کنند یا جایگزین‌های مناسب، باید بر روی سیستم نصب شوند یا توسط برنامه شما بارگذاری شوند. به بخش‌های [Deploy Fonts](/slides/fa/java/deploy-fonts/)، [Font Substitution](/slides/fa/java/font-substitution/) و [Custom Fonts](/slides/fa/java/custom-font/) مراجعه کنید.

## **بررسی تنظیمات شما**

برای اطمینان از اینکه کتابخانه و الزاماتش در جای خود قرار دارند، برنامه‌ای که یک ارائه را ذخیره کرده و اسلایدی را به تصویر تبدیل می‌کند، اجرا کنید. ذخیره‌سازی و رندر کردن از پشتیبانی قلم Java Runtime استفاده می‌کنند، همان‌گونه که الزامات لینوکس بالا فراهم می‌کند.

کد زیر را به اسم *CheckSetup.java* در پوشه‌ای که فایل JAR Aspose.Slides در آن قرار دارد، ذخیره کنید. برای دانلود فایل JAR، به بخش [Use the JAR File without Maven](/slides/fa/java/installation/#use-the-jar-file-without-maven) مراجعه کنید.

```java
import com.aspose.slides.*;

public class CheckSetup {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            // یک مستطیل با متن به اسلاید اول اضافه کرده و ارائه را ذخیره کنید.
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.getTextFrame().setText("Hello, Aspose.Slides!");
            presentation.save("hello.pptx", SaveFormat.Pptx);

            // اسلاید را با یک پیکسل برای هر پوینت رندر کنید و تصویر را ذخیره کنید.
            IImage image = slide.getImage(1f, 1f);
            try {
                image.save("hello.png", ImageFormat.Png);
            } finally {
                image.dispose();
            }
        } finally {
            presentation.dispose();
        }
    }
}
```

با JDK 11 یا بالاتر، برنامه را در همان پوشه با دستور زیر اجرا کنید. اگر نام فایل JAR شما متفاوت است، نام را در دستورات تغییر دهید.

```bash
java -cp aspose-slides-26.10-jdk8.jar CheckSetup.java
```

با Java 8 یا در سیستمی که فقط JRE دارد، برنامه را با `javac` از یک JDK کامپایل کنید و سپس کلاس کامپایل‌شده را اجرا کنید. در Linux و macOS، اجرا کنید:

```bash
javac -cp aspose-slides-26.10-jdk8.jar CheckSetup.java
java -cp aspose-slides-26.10-jdk8.jar:. CheckSetup
```

در Windows، همان دستور `javac` را اجرا کنید و سپس کلاس را با نقطه‌ویرگول به عنوان جداکنندهٔ مسیر کلاس اجرا نمایید. نقل‌قول‌ها را نگه دارید تا PowerShell نقطه‌ویرگول را به عنوان پایان دستور در نظر نگیرد: `java -cp "aspose-slides-26.10-jdk8.jar;." CheckSetup`.

برنامه یک مستطیل با متن به اسلاید اول اضافه می‌کند و ارائه را به نام *hello.pptx* با متد [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) ذخیره می‌سازد. سپس اسلاید را با متد [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#getImage-float-float-) رندر کرده و نتیجه را به نام *hello.png* با متد [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) در قالب [ImageFormat.Png](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/) ذخیره می‌کند. مقیاس 1 یک پیکسل به ازای هر پوینت رندر می‌شود، بنابراین اسلاید پیش‌فرض 720 × 540 پوینت تبدیل به تصویر 720 × 540 پیکسل می‌شود و متن داخل مستطیل قابل مشاهده است. بدون لایسنس، هر دو فایل دارای واترمارک ارزیابی هستند؛ به بخش [Licensing](/slides/fa/java/licensing/) مراجعه کنید. اگر یک پیش‌نیاز موجود نباشد، برنامه با یکی از خطاهای توضیح داده‌شده در بخش [Linux](#linux) متوقف می‌شود.

## **ابزارهای توسعه**

می‌توانید برنامه‌هایی بسازید که از Aspose.Slides استفاده می‌کنند با هر JDKی که نسخهٔ پشتیبانی‌شده‌ای از جاوا دارد. از Apache Maven همراه با مخزن Maven Aspose همان‌طور که در [Installation](/slides/fa/java/installation/) شرح داده شده، یا هر ابزار ساخت دیگری که می‌تواند از مخزن Maven استفاده کند، بهره ببرید. همچنین می‌توانید فایل JAR را به مسیر کلاس IDE یا ابزار ساخت خود اضافه کنید.

## **سوالات متداول**

**آیا برای تبدیل و رندر کردن نیاز به نصب Microsoft PowerPoint دارم؟**

خیر، PowerPoint لازم نیست. Aspose.Slides یک موتور مستقل برای [creating](/slides/fa/java/create-presentation/)، modifying، [converting](/slides/fa/java/convert-presentation/) و [rendering](/slides/fa/java/convert-powerpoint-to-png/) ارائه‌ها است.

**آیا Aspose.Slides for Java برای اجرا بر روی سرور لینوکس نیاز به نمایشگر یا محیط دسکتاپ دارد؟**

خیر. Aspose.Slides نیازی به X server یا نمایشگر ندارد، بنابراین بر روی سرورها و در کانتینرها اجرا می‌شود. در لینوکس فقط به کتابخانهٔ قلم و قلم‌های توصیف‌شده در بخش [Linux](#linux) احتیاج دارد.

**کدام قلم‌ها برای رندر صحیح لازم هستند؟**

قلم‌هایی که در ارائه استفاده می‌شوند یا [substitutes](/slides/fa/java/font-substitution/) مناسب، باید در دسترس باشند. در لینوکس و macOS، بسته‌های قلمی که ارائه‌های شما به آن‌ها نیاز دارند نصب کنید تا رندرینگ سازگار باشد.

**چرا یک قلم سفارشی در لینوکس به عنوان جایگزین یا متن گمشده رندر می‌شود؟**

اگر فایل قلم دارای ورودی‌های نادرست یا خراب در جدول نام‌ها باشد، پشتهٔ مطابقت قلم لینوکس (FreeType/fontconfig) ممکن است رکورد نامعتبر را انتخاب کند که منجر به عدم شناسایی قلم می‌شود. استفاده از نسخهٔ قلمی با رکوردهای جدول نام اصلاح‌شده یا نصب یک جایگزین سازگار این مشکل را رفع می‌کند.