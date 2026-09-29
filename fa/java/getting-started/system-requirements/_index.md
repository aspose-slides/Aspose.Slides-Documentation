---
title: نیازمندی‌های سیستم
type: docs
weight: 60
url: /fa/java/system-requirements/
keywords:
- نیازمندی‌های سیستم
- پلتفرم‌های پشتیبانی‌شده
- نسخه‌های Java
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
description: "بررسی کنید قبل از نصب Aspose.Slides for Java چه چیزهایی نیاز دارد: نسخه‌های Java پشتیبانی‌شده و سیستم‌عامل‌ها، و کتابخانه فونت و قلم‌هایی که Linux نیاز دارد."
---
## **مقدمه**

Aspose.Slides for Java یک کتابخانه مستقل است: به Microsoft PowerPoint یا Microsoft Office نیازی ندارد. این یک فایل JAR تک است که در مخزن Maven شرکت Aspose منتشر شده است. فایل JAR فقط شامل کلاس‌ها و منابع جاوا می‌باشد، بدون کتابخانه‌های بومی، و هیچ وابستگی به کتابخانه‌های دیگر اعلام نمی‌کند. بنابراین این فایل بر روی تمام سیستم‌عامل‌ها و پردازنده‌هایی که یک زمان اجرای جاوا پشتیبانی می‌شود، اجرا می‌شود.

این مقاله نسخه‌های جاوا و سیستم‌عامل‌های پشتیبانی‌شده، کتابخانه فونت و قلم‌هایی که لینوکس نیاز دارد را فهرست می‌کند و با یک برنامه کوتاه که تنظیمات شما را بررسی می‌کند، پایان می‌یابد. برای افزودن کتابخانه به یک پروژه، به [Installation](/slides/fa/java/installation/) مراجعه کنید.

## **نسخه‌های جاوا پشتیبانی‌شده**

Aspose.Slides for Java بر روی Java 8 یا بالاتر، با JDK یا JRE اجرا می‌شود. این شامل نسخه‌های پشتیبانی طولانی‌مدت Java 8، 11، 17، 21، و 25 و همچنین نسخه‌های بعدی مانند Java 26 و Java 27 می‌گردد. زمان اجرای جاوا می‌تواند از هر فروشنده‌ای باشد، برای مثال Eclipse Temurin، Amazon Corretto، Oracle یا بسته‌های OpenJDK یک توزیع لینوکس.

Aspose.Slides نیازی به گزینه‌های JVM مانند `--add-opens` در هیچ‌یک از این نسخه‌ها ندارد. در Java 11، JVM هشداری چاپ می‌کند که با «WARNING: An illegal reflective access operation has occurred» شروع می‌شود؛ این هشدار بر نتیجه تأثیری ندارد.

{{% alert color="warning" title="Warning" %}}
Java 6 و Java 7 منسوخ شده‌اند. Aspose.Slides for Java 26.9 هنوز بر روی آنها اجرا می‌شود اما هشدار منسوخ شدن را چاپ می‌کند. از نسخه 26.10 به بعد، حداقل نسخه Java 8 است و Java 6 و Java 7 دیگر پشتیبانی نمی‌شوند.
{{% /alert %}}

پروژه Maven و دستورات موجود در [Installation](/slides/fa/java/installation/) به JDK 11 یا بالاتر نیاز دارند. با Java 8، برنامه خود را همان‌طور که در [Check Your Setup](#check-your-setup) نشان داده شده است، کامپایل و اجرا کنید.

## **سیستم‌عامل‌های پشتیبانی‌شده**

از آنجا که فایل JAR شامل کد بومی نیست، Aspose.Slides for Java بر روی Windows، Linux و macOS، بر هر معماری پردازشگری که زمان اجرای جاوا از آن پشتیبانی می‌کند، مانند x64 و ARM64 اجرا می‌شود. زمان اجرای جاوا تنها نیازمندی در Windows است. در Linux، پشتیبانی فونت جاوا همچنین به کتابخانه فونت و قلم‌های توصیف‌شده در [Linux](#linux) نیاز دارد.

## **Linux**

Aspose.Slides for Java متن را با استفاده از پشتیبانی فونت زمان اجرای جاوا چیدمان و رسم می‌کند. در Linux، این پشتیبانی به کتابخانه fontconfig و حداقل یک قلم نصب شده نیاز دارد. تصاویر رسمی کانتینری توزیع‌های لینوکس اغلب هر دو را ندارند. بدون آنها، اولین مثال در [Create Presentations](/slides/fa/java/create-presentation/) هنگام ذخیره ارائه، شکست می‌خورد، فایلی خالی می‌گذارد و این خطا را گزارش می‌دهد:

```text
java.lang.RuntimeException: Fontconfig head is null, check your fonts or fonts configuration
```

تصاویر رسمی کانتینری `eclipse-temurin` برای Ubuntu و Alpine Linux هم‌اکنون شامل fontconfig و قلم‌های DejaVu هستند، بنابراین نیازی به نصب چیزی روی آنها نیست. در سیستم‌های دیگر، بسته‌های زیر را نصب کنید. دستورات Debian، Ubuntu و Red Hat از `sudo` استفاده می‌کنند؛ در یک Dockerfile، آن‌ها را در دستور `RUN` بدون `sudo` اجرا کنید. قلم‌های DejaVu برای اجرای Aspose.Slides کافی هستند؛ قلم‌هایی که ارائه‌های شما استفاده می‌کنند در بخش [Fonts](#fonts) پوشش داده شده‌اند.

### **Debian و Ubuntu**

اگر جاوا را از بسته‌های Debian یا Ubuntu با تنظیمات پیش‌فرض `apt-get` نصب کنید، همان‌طور که دستور در [Installation](/slides/fa/java/installation/#linux) نشان می‌دهد، بسته‌های جاوا همچنین کتابخانه fontconfig، قلم‌های DejaVu و کتابخانه HarfBuzz مورد نیاز این بسته‌های جاوا را نصب می‌کنند و چیز دیگری لازم نیست.

با یک زمان اجرای جاوا از منبع دیگر، مانند بایگانی Eclipse Temurin، fontconfig و قلم‌های DejaVu را نصب کنید:

```bash
sudo apt-get update && sudo apt-get install -y fontconfig fonts-dejavu-core
```

یک Dockerfile اغلب بسته‌های جاوا Debian یا Ubuntu را نصب می‌کند، مانند `openjdk-21-jdk-headless` یا `default-jdk-headless`، با گزینه `--no-install-recommends` که هر سه را رد می‌کند. با دستور بالا fontconfig و قلم‌های DejaVu را نصب کنید و همچنین HarfBuzz را نصب نمایید:

```bash
sudo apt-get install -y libharfbuzz0b
```

بدون HarfBuzz، این بسته‌های جاوا پیام `Please install the openjdk-*-jre package or recommended packages for openjdk-*-jre-headless` را چاپ می‌کنند و ذخیره‌سازی با یک `UnsatisfiedLinkError` که گزارش می‌دهد `libharfbuzz.so.0` نمی‌تواند باز شود، شکست می‌خورد.

### **Red Hat Enterprise Linux**

بسته‌های `java-<version>-openjdk-headless` در Red Hat Enterprise Linux کتابخانه fontconfig را نصب نمی‌کنند. آن را همراه با قلم‌های DejaVu نصب کنید:

```bash
sudo dnf install -y fontconfig dejavu-sans-fonts
```

بسته‌های کامل `java-<version>-openjdk` fontconfig و قلم‌ها را به عنوان وابستگی نصب می‌کنند و همین‌طور بسته‌های Amazon Corretto در Amazon Linux 2023، مانند `java-21-amazon-corretto-headless`.

### **Alpine Linux**

در یک Dockerfile مبتنی بر Alpine Linux، fontconfig و قلم‌های DejaVu را نصب کنید:

```dockerfile
RUN apk add --no-cache fontconfig ttf-dejavu
```

در نسخه‌های فعلی Alpine، `ttf-dejavu` بسته `font-dejavu` را نصب می‌کند. جاوا را با بسته `openjdk<version>-jre` یا `openjdk<version>-jdk`، مانند `openjdk25-jdk` نصب کنید. بسته‌های `openjdk<version>-jre-headless` در Alpine Linux شامل کتابخانه فونت جاوا نیستند، بنابراین برنامه با خطای `UnsatisfiedLinkError: no fontmanager in system library path` خراب می‌شود، حتی اگر قلم‌ها نصب شده باشند.

### **Fonts**

برای اینکه متن با قلم‌ها و متریک‌های صحیح رندر شود، قلم‌هایی که ارائه‌های شما استفاده می‌کنند یا جایگزین‌های مناسب، باید بر روی سیستم نصب شده یا توسط برنامه شما بارگذاری شوند. به [Deploy Fonts](/slides/fa/java/deploy-fonts/)، [Font Substitution](/slides/fa/java/font-substitution/) و [Custom Fonts](/slides/fa/java/custom-font/) مراجعه کنید.

## **بررسی تنظیمات**

برای اطمینان از اینکه کتابخانه و نیازمندی‌های آن موجود هستند، یک برنامه اجرا کنید که یک ارائه را ذخیره کرده و یک اسلاید را به تصویر تبدیل می‌کند. ذخیره و رندرینگ از پشتیبانی فونت زمان اجرای جاوا استفاده می‌کنند، که همان چیزی است که الزامات لینوکس بالا فراهم می‌کند.

کد زیر را به عنوان *CheckSetup.java* در پوشه‌ای که حاوی فایل JAR Aspose.Slides است ذخیره کنید. برای دانلود فایل JAR، به [Use the JAR File without Maven](/slides/fa/java/installation/#use-the-jar-file-without-maven) مراجعه کنید.

```java
import com.aspose.slides.*;

public class CheckSetup {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            // یک مستطیل با متن به اولین اسلاید اضافه کنید و ارائه را ذخیره کنید.
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.getTextFrame().setText("Hello, Aspose.Slides!");
            presentation.save("hello.pptx", SaveFormat.Pptx);

            // اسلاید را با یک پیکسل برای هر نقطه رندر کنید و تصویر را ذخیره کنید.
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

با JDK 11 یا بالاتر، برنامه را در همان پوشه با فرمان زیر اجرا کنید. اگر نام فایل JAR شما متفاوت است، نام را در دستورات تغییر دهید.

```bash
java -cp aspose-slides-26.9-jdk16.jar CheckSetup.java
```

با Java 8 یا در سیستمی که فقط JRE دارد، برنامه را با `javac` از یک JDK کامپایل کنید و سپس کلاس کامپایل‌شده را اجرا کنید. در Linux و macOS، اجرا کنید:

```bash
javac -cp aspose-slides-26.9-jdk16.jar CheckSetup.java
java -cp aspose-slides-26.9-jdk16.jar:. CheckSetup
```

در Windows، همان فرمان `javac` را اجرا کنید و سپس کلاس را با نقطه‌ویرگول به عنوان جداکننده مسیر کلاس اجرا کنید. نقل قول‌ها را حفظ کنید تا PowerShell نقطه‌ویرگول را به عنوان پایان فرمان در نظر نگیرد: `java -cp \"aspose-slides-26.9-jdk16.jar;.\" CheckSetup`.

این برنامه یک مستطیل با متن را به اولین اسلاید اضافه می‌کند و ارائه را به عنوان *hello.pptx* با متد [save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#save-java.lang.String-int-) ذخیره می‌نماید. سپس اسلاید را با [getImage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slide/#getImage-float-float-) رندر کرده و نتیجه را به عنوان *hello.png* با [IImage.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iimage/#save-java.lang.String-int-) در قالب [ImageFormat.Png](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imageformat/) ذخیره می‌کند. عوامل مقیاس 1 یک پیکسل برای هر نقطه رندر می‌کند، بنابراین اسلاید پیش‌فرض 720 × 540 نقطه‌ای به تصویر 720 × 540 پیکسلی تبدیل می‌شود و متن داخل مستطیل قابل مشاهده است. بدون لایسنس، هر دو فایل دارای واترمارک ارزیابی هستند؛ به [Licensing](/slides/fa/java/licensing/) مراجعه کنید. اگر یک نیازمندی ناقص باشد، برنامه با یکی از خطاهای توضیح داده‌شده در [Linux](#linux) متوقف می‌شود.

## **ابزارهای توسعه**

می‌توانید برنامه‌هایی بسازید که از Aspose.Slides استفاده می‌کنند با هر JDK از یک نسخه پشتیبانی‌شدهٔ جاوا. از Apache Maven همراه با مخزن Maven Aspose، همان‌طور که در [Installation](/slides/fa/java/installation/) توضیح داده شده، یا هر ابزار ساخت دیگری که می‌تواند از یک مخزن Maven استفاده کند، بهره ببرید. همچنین می‌توانید فایل JAR را به مسیر کلاس IDE یا ابزار ساخت خود اضافه کنید.

## **سؤال‌های متداول**

**آیا برای تبدیل‌ها و رندرینگ نیاز به نصب Microsoft PowerPoint دارم؟**

نه، PowerPoint نیازی نیست. Aspose.Slides یک موتور مستقل برای [ایجاد](/slides/fa/java/create-presentation/)، اصلاح، [تبدیل](/slides/fa/java/convert-presentation/) و [رندرینگ](/slides/fa/java/convert-powerpoint-to-png/) ارائه‌ها است.

**آیا Aspose.Slides for Java به نمایشگر یا محیط دسکتاپ روی سرور لینوکس نیاز دارد؟**

نه. Aspose.Slides به سرور X یا نمایشگر نیاز ندارد، بنابراین بر روی سرورها و در کانتینرها اجرا می‌شود. در Linux، فقط به کتابخانه فونت و قلم‌های توصیف‌شده در [Linux](#linux) نیاز دارد.

**کدام قلم‌ها برای رندر صحیح مورد نیازند؟**

قلم‌های مورد استفاده در ارائه، یا [جایگزین‌های](/slides/fa/java/font-substitution/) مناسب، باید در دسترس باشند. در Linux و macOS، بسته‌های قلمی که ارائه‌های شما نیاز دارند را نصب کنید تا رندرینگ سازگار باشد.

**چرا یک قلم سفارشی در Linux به‌عنوان جایگزین یا متن گمشده رندر می‌شود؟**

اگر فایل قلم دارای ورودی‌های جدول نام ناسازگار یا خراب باشد، پشته تطبیق قلم لینوکس (FreeType/fontconfig) ممکن است رکورد نامعتبر را انتخاب کند که باعث می‌شود قلم حل نشود. استفاده از نسخه‌ای از قلم با رکوردهای جدول نام اصلاح‌شده یا نصب یک جایگزین سازگار، این مشکل را برطرف می‌کند.