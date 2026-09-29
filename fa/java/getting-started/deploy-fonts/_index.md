---
title: استقرار قلم‌ها برای Aspose.Slides برای Java در لینوکس و Docker
linktitle: استقرار قلم‌ها
type: docs
weight: 155
url: /fa/java/deploy-fonts/
keywords:
- استقرار قلم‌ها
- نصب قلم‌ها
- قلم‌ها در Docker
- قلم‌ها در لینوکس
- قلم‌های گمشده
- جایگزینی قلم
- قلم‌های اصلی مایکروسافت
- ttf-mscorefonts-installer
- قلم‌های سفارشی
- قلم پیش‌فرض
- سرور
- کانتینر
- تبدیل PDF
- ارائه
- Java
- Aspose.Slides
description: "قلم‌ها را برای Aspose.Slides برای Java بر روی سرورهای لینوکس و در کانتینرهای Docker استقرار دهید: بررسی کنید کدام قلم‌ها جایگزین می‌شوند، بسته‌های قلم را بر روی Debian، Ubuntu و Alpine نصب کنید، فایل‌های قلم خود را اضافه کنید، و یک قلم پیش‌فرض تنظیم کنید."
---
## **مروری**

Aspose.Slides متن را با قلم‌هایی که در دسترس دارد هنگام رندر یک ارائه می‌کشد، برای مثال وقتی اسلایدها را به PDF یا تصویر تبدیل می‌کند. یک دسکتاپ ویندوز معمولاً قلم‌های مورد استفاده ارائه‌ها را دارد. سرورهای لینوکس و کانتینرها معمولاً قلم‌های کمی دارند، بنابراین Aspose.Slides متن را با یک قلم جایگزین می‌کشد. یک قلم جایگزین شکل‌ها و عرض‌های حروف متفاوتی دارد، بنابراین خطوط ممکن است به‌طور متفاوتی بسته شوند و متن ممکن است از شکل خود تجاوز کند، و کاراکترهایی که قلم جایگزین ندارند به‌درستی رسم نمی‌شوند. اگر هیچ قلمی نصب نشده باشد، پشتیبانی قلم‌های جاوا نمی‌تواند شروع شود و Aspose.Slides با خطایی متوقف می‌شود.

این مقاله نشان می‌دهد چگونه می‌توانید بررسی کنید کدام قلم‌ها توسط Aspose.Slides جایگزین می‌شوند، چگونه قلم‌ها را در Debian، Ubuntu و Alpine Linux نصب کنید، چگونه فایل‌های قلم خود را اضافه کنید، و چگونه قلم مورد استفاده هنگام عدم وجود یک قلم را تنظیم کنید. مثال‌ها در Docker بر روی تصویرهای رسمی Eclipse Temurin اجرا می‌شوند، همان‌طور که در [اجرای Aspose.Slides برای Java در Docker](/slides/fa/java/how-to-run-aspose-slides-in-docker/) آمده است. دستورات بسته‌ها دستورات Dockerfile هستند؛ در یک سرور لینوکس، همان دستورات را به‌عنوان روت اجرا کنید.

برای خود API قلم، مانند جاسازی قلم‌ها در یک ارائه و قوانین fallback و جایگزینی، به [قلم‌های PowerPoint](/slides/fa/java/powerpoint-fonts/) مراجعه کنید.

## **بررسی اینکه کدام قلم‌ها جایگزین می‌شوند**

پروژه Maven زیر قلم‌هایی را که Aspose.Slides در محیط فعلی جایگزین می‌کند گزارش می‌دهد. یک پوشه به نام *font-check* ایجاد کنید و فایل‌های زیر را به آن اضافه کنید.

*pom.xml* همان فایل از [اجرای Aspose.Slides برای Java در Docker](/slides/fa/java/how-to-run-aspose-slides-in-docker/#create-the-project) است، با تغییر شناسهٔ artifact و نام فایل JAR به *font-check*:

```xml
<project xmlns="http://maven.apache.org/POM/4.0.0">
    <modelVersion>4.0.0</modelVersion>
    <groupId>com.example</groupId>
    <artifactId>font-check</artifactId>
    <version>1.0</version>

    <properties>
        <maven.compiler.release>11</maven.compiler.release>
        <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
    </properties>

    <repositories>
        <repository>
            <id>AsposeJavaAPI</id>
            <name>Aspose Java API</name>
            <url>https://releases.aspose.com/java/repo/</url>
        </repository>
    </repositories>

    <dependencies>
        <dependency>
            <groupId>com.aspose</groupId>
            <artifactId>aspose-slides</artifactId>
            <version>26.9</version>
            <classifier>jdk16</classifier>
        </dependency>
    </dependencies>

    <build>
        <finalName>font-check</finalName>
        <plugins>
            <plugin>
                <groupId>org.apache.maven.plugins</groupId>
                <artifactId>maven-compiler-plugin</artifactId>
                <version>3.15.0</version>
            </plugin>
            <plugin>
                <groupId>org.apache.maven.plugins</groupId>
                <artifactId>maven-dependency-plugin</artifactId>
                <version>3.11.0</version>
                <executions>
                    <execution>
                        <phase>package</phase>
                        <goals>
                            <goal>copy-dependencies</goal>
                        </goals>
                        <configuration>
                            <outputDirectory>${project.build.directory}/lib</outputDirectory>
                        </configuration>
                    </execution>
                </executions>
            </plugin>
        </plugins>
    </build>
</project>
```

*src/main/java/FontCheck.java* برای هر نام قلم یک جعبه متن به اسلاید اضافه می‌کند و قلم را با متد [setLatinFont](https://reference.aspose.com/slides/fa/java/com.aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-) اختصاص می‌دهد. نام‌های قلم‌ها از خط فرمان می‌آیند؛ بدون آرگومان برنامه Calibri، Arial و Times New Roman را بررسی می‌کند. پوشه‌هایی که Aspose.Slides برای قلم‌ها جستجو می‌کند را چاپ می‌کند ([FontsLoader.getFontFolders](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsloader/#getFontFolders--))، اسلاید را به *output/fonts.pdf* رندر می‌کند، و جایگزینی‌های گزارش‌شده توسط [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) را چاپ می‌کند. دو گام اختیاری در ابتدا، بارگذاری پوشهٔ *fonts* و خواندن متغیر `DEFAULT_FONT`، در ادامه این مقاله توضیح داده می‌شوند.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.LinkedHashSet;
import java.util.List;
import java.util.Set;

public class FontCheck {
    public static void main(String[] args) {
        // قلم‌های مورد بررسی: آرگومان‌های خط فرمان، یا سه قلم رایج Office.
        String[] fontNames = args.length > 0 ? args : new String[] { "Calibri", "Arial", "Times New Roman" };

        // بارگذاری فایل‌های قلم از پوشهٔ fonts در دایرکتوری کاری، در صورتی که وجود داشته باشد.
        File appFontFolder = new File("fonts");
        if (appFontFolder.isDirectory()) {
            FontsLoader.loadExternalFonts(new String[] { appFontFolder.getAbsolutePath() });
        }

        // از قلم‌نامی که در متغیر محیطی DEFAULT_FONT تعریف شده استفاده کنید، در صورتی که تنظیم شده باشد، برای متنی که قلم آن گم شده است.
        LoadOptions loadOptions = new LoadOptions();
        String defaultFont = System.getenv("DEFAULT_FONT");
        if (defaultFont != null && !defaultFont.isEmpty()) {
            loadOptions.setDefaultRegularFont(defaultFont);
        }

        Set<String> fontFolders = new LinkedHashSet<>(Arrays.asList(FontsLoader.getFontFolders()));
        System.out.println("Font folders: " + String.join(", ", fontFolders));

        Presentation presentation = new Presentation(loadOptions);
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            for (int i = 0; i < fontNames.length; i++) {
                IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50 + i * 80, 600, 60);
                shape.getTextFrame().setText("This text is set in " + fontNames[i] + ".");
                shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData(fontNames[i]));
            }

            File outputFolder = new File("output");
            outputFolder.mkdirs();
            presentation.save(new File(outputFolder, "fonts.pdf").getPath(), SaveFormat.Pdf);

            List<FontSubstitutionInfo> substitutions = new ArrayList<>();
            for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
                substitutions.add(substitution);
            }

            if (substitutions.isEmpty()) {
                System.out.println("No font substitutions.");
            } else {
                System.out.println("Font substitutions:");
                for (FontSubstitutionInfo substitution : substitutions) {
                    System.out.println("  " + substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
                }
            }
        } finally {
            presentation.dispose();
        }
    }
}
```

`getFontFolders` ممکن است یک پوشه را بیش از یک بار برگرداند، بنابراین برنامه قبل از چاپ، پوشه‌ها را در یک مجموعه جمع‌آوری می‌کند.

*.dockerignore* نتایج ساخت محلی را از زمینهٔ ساخت خارج می‌Keeping local build results out of the build context:

```text
target/
output/
```

*Dockerfile* برنامه را با تصویر Maven می‌سازد و آن را بر روی تصویر زمان‌اجرای Java Eclipse Temurin اجرا می‌کند، که از پیش fontconfig و قلم‌های DejaVu را دارد. [اجرای Aspose.Slides برای Java در Docker](/slides/fa/java/how-to-run-aspose-slides-in-docker/) هر دستور را توضیح می‌دهد.

```dockerfile
FROM maven:3.9-eclipse-temurin-21 AS build
WORKDIR /src
COPY pom.xml .
RUN mvn -B dependency:go-offline
COPY src ./src
RUN mvn -B package

FROM eclipse-temurin:21-jre
WORKDIR /app
COPY --from=build /src/target/font-check.jar .
COPY --from=build /src/target/lib ./lib
RUN mkdir output && chown ubuntu output
USER ubuntu
ENTRYPOINT ["java", "-cp", "font-check.jar:lib/*", "FontCheck"]
```

ساخت تصویر و اجرای بررسی:

```bash
docker build -t font-check .
docker run --rm font-check
```

این تصویر تنها قلم‌های DejaVu را دارد، بنابراین هر سه قلم با DejaVu Sans جایگزین می‌شوند:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

برای بررسی قلم‌های ارائه‌های خود، نام‌های آن‌ها را به‌عنوان آرگومان پاس کنید، برای مثال `docker run --rm font-check "Segoe UI" Consolas`. برای کپی کردن *output/fonts.pdf* خارج از کانتینر، از دستورات موجود در [کپی خروجی به ماشین شما](/slides/fa/java/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine) استفاده کنید.

## **نصب قلم‌ها در Debian و Ubuntu**

### **Microsoft Core Fonts**

بستهٔ `ttf-mscorefonts-installer` قلم‌های اصلی مایکروسافت برای وب را دانلود و نصب می‌کند، از جمله Arial، Times New Roman، Courier New، Verdana، Georgia و Trebuchet MS. این قلم‌ها تحت مجوز کاربر نهایی مایکروسافت (EULA) هستند و بسته تنها پس از پذیرش EULA آن‌ها را نصب می‌کند. یک ساخت Docker نمی‌تواند به سؤال پاسخ دهد، بنابراین نصب‌کننده EULA را رد می‌کند و هیچ قلمی نصب نمی‌شود، در حالی که `apt-get install` هنوز موفقیت را گزارش می‌دهد. قبل از نصب بسته، با `debconf-set-selections` EULA را بپذیرید **قبل از** نصب. پذیرفتن آن در دستور بعدی کمک نمی‌کند: بسته قبلاً نصب شده و apt نصب‌کنندهٔ آن را دوباره اجرا نمی‌کند.

این دستور را به مرحلهٔ زمان‌اجرای *Dockerfile*، درست بعد از خط `FROM` آن اضافه کنید، تا به‌عنوان روت اجرا شود، قبل از دستور `USER`:

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

تصویر را بسازید و بررسی را دوباره با همان دو دستور اجرا کنید. اکنون Arial و Times New Roman نصب شده‌اند:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

Calibri، قلم پیش‌فرض ارائه‌ای که Aspose.Slides ایجاد می‌کند، یکی از قلم‌های اصلی نیست، لذا همچنان جایگزین می‌شود. به [تنظیم یک قلم پیش‌فرض برای قلم‌های گمشده]#set-a-default-font-for-missing-fonts مراجعه کنید.

تصاویر Eclipse Temurin مبتنی بر Ubuntu `multiverse` را فعال می‌کنند، مؤلفهٔ Ubuntu که بسته را در بر دارد. در Debian، بسته در مؤلفهٔ `contrib` است که تصاویر Debian آن را فعال نکرده‌اند. در یک مرحلهٔ زمان‌اجرای مبتنی بر Debian، مانند آنچه در [استفاده از تصویر پایهٔ دیگر](/slides/fa/java/how-to-run-aspose-slides-in-docker/#use-another-base-image) نشان داده شده، `contrib` را در همان دستور فعال کنید:

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

### **Other Font Packages**

Debian و Ubuntu همچنین قلم‌های آزاد را در بسته‌ها ارائه می‌دهند، برای مثال:

| بسته | قلم‌ها |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans، DejaVu Serif، DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans، Serif و Mono، با همان متریک‌ها مثل Arial، Times New Roman و Courier New |
| `fonts-crosextra-carlito` | Carlito، با همان متریک‌ها مثل Calibri |
| `fonts-crosextra-caladea` | Caladea، با همان متریک‌ها مثل Cambria |

آن‌ها را با `apt-get install` در دستور `RUN` مرحلهٔ زمان‌اجرای همانند قلم‌های اصلی مایکروسافت نصب کنید. Aspose.Slides برای Java الفا‌نام‌های پیکربندی قلم لینوکس را اعمال نمی‌کند: حتی با نصب `fonts-liberation`، متن در Arial هنوز با قلم جایگزین عمومی رندر می‌شود، نه با Liberation Sans. برای استفاده از قلمی که متریک سازگار دارد به جای قلم گمشده، آن را به‌عنوان [قلم پیش‌فرض]#set-a-default-font-for-missing-fonts تنظیم کنید یا یک [قاعدهٔ جایگزینی قلم](/slides/fa/java/font-substitution/) اضافه کنید.

## **افزودن فایل‌های قلم خود**

قلم‌هایی که توزیع‌ها بسته‌بندی نکرده‌اند، مانند قلم‌های سازمان شما یا سایر قلم‌هایی که مجاز به استفاده بر روی سرور هستید، می‌توانند به عنوان فایل‌های قلم اضافه شوند. فایل‌های قلم، برای مثال فایل‌های *.ttf*، را در پوشه‌ای به نام *fonts* داخل پوشهٔ *font-check* قرار دهید. مثال‌های زیر از فایل‌های Carlito استفاده می‌کنند، قلمی که متریک‌های مشابه Calibri دارد و می‌توانید آن را از [Google Fonts](https://fonts.google.com/specimen/Carlito) دانلود کنید.

### **نصب قلم‌ها در پوشه قلم سیستم**

Aspose.Slides قلم‌های موجود در خطوط چاپ‌شدهٔ `Font folders` را می‌خواند. برای نصب قلم‌های خود برای همهٔ برنامه‌ها در تصویر، آن‌ها را به */usr/local/share/fonts*، پوشهٔ قلم‌های نصب‌شده محلی، کپی کنید. این دستور را به مرحلهٔ زمان‌اجرای *Dockerfile*، پس از دستور `RUN` که قلم‌های اصلی مایکروسافت را نصب می‌کند، اضافه کنید:

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

تصویر را دوباره بسازید، سپس Calibri و Carlito را بررسی کنید:

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

Carlito دیگر جایگزین نمی‌شود:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

### **بارگذاری قلم‌ها از پوشه برنامه**

به جای نصب قلم‌ها در پوشهٔ سیستم، می‌توانید آن‌ها را همراه برنامه تحویل دهید و با متد [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/fa/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) بارگذاری کنید. سپس این قلم‌ها فقط برای Aspose.Slides در دسترس هستند و همراه برنامه توزیع می‌شوند. *FontCheck* این کار را انجام می‌دهد: وقتی دایرکتوری کاری آن، */app* در کانتینر، شامل پوشهٔ *fonts* باشد، برنامه آن پوشه را به `loadExternalFonts` می‌دهد قبل از ایجاد ارائه. [قلم سفارشی](/slides/fa/java/custom-font/) روش‌های دیگر افزودن قلم، مانند بارگذاری از حافظه، را توصیف می‌کند.

در *Dockerfile*، دستور `COPY fonts/ /usr/local/share/fonts/` را حذف کنید و این دستور را پس از دستوری که پوشهٔ *lib* را کپی می‌کند اضافه کنید:

```dockerfile
COPY fonts/ ./fonts/
```

تصویر را دوباره بسازید و بررسی را با همان دو دستور اجرا کنید. پوشهٔ برنامه اکنون در میان پوشه‌های قلم ظاهر می‌شود و Carlito همچنان جایگزین نمی‌شود:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

`loadExternalFonts` قلم‌ها را به قلم‌های نصب‌شده اضافه می‌کند، اما پشتیبانی قلم‌های جاوا همچنان به حداقل یک قلم نصب‌شده نیاز دارد. در یک تصویر بدون هیچ قلمی، `loadExternalFonts` با خطای «Fontconfig head is null, check your fonts or fonts configuration» متوقف می‌شود.

## **تنظیم یک قلم پیش‌فرض برای قلم‌های گمشده**

وقتی قلمی گم می‌شود، Aspose.Slides یک جایگزین خودکار انتخاب می‌کند. برای انتخاب خودتان، نام قلم را به متد [setDefaultRegularFont](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/#setDefaultRegularFont-java.lang.String-) از [LoadOptions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/) بدهید و گزینه‌ها را به سازندهٔ [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) پاس کنید. *FontCheck* نام قلم را از متغیر محیطی `DEFAULT_FONT` می‌خواند. با بارگذاری Carlito، آن را برای قلم‌های گمشده استفاده کنید:

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

اکنون Calibri با Carlito رندر می‌شود؛ کاراکترهای آن عرض‌های مشابه Calibri دارند، بنابراین متن خطوط خود را حفظ می‌کند:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Carlito
```

قلم پیش‌فرض هر قلم گمشده‌ای را جایگزین می‌کند. برای نگاشت قلم‌های جداگانه، برای مثال Arial به Liberation Sans و Calibri به Carlito، از [قواعد جایگزینی قلم](/slides/fa/java/font-substitution/) استفاده کنید. قوانین خروجی رندر شده را تغییر می‌دهند، اما `getSubstitutions` آن‌ها را نشان نمی‌دهد، بنابراین قلم‌ها را در فایل خروجی بررسی کنید. برای متون آسیایی، همچنین متد [setDefaultAsianFont](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/#setDefaultAsianFont-java.lang.String-) را فراخوانی کنید؛ رجوع به [قلم پیش‌فرض](/slides/fa/java/default-font/).

## **نصب قلم‌ها بر روی Alpine Linux**

تصویر Eclipse Temurin مبتنی بر Alpine نیز قلم‌های DejaVu را دارد؛ [اجرا بر روی Alpine Linux](/slides/fa/java/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) مرحلهٔ زمان‌اجرای آن را توصیف می‌کند. برای نصب قلم‌های اصلی مایکروسافت بر روی آن نیز، مرحلهٔ زمان‌اجرای Dockerfile *font-check* را با این یکی جایگزین کنید:

```dockerfile
FROM eclipse-temurin:21-jre-alpine
RUN apk add --no-cache msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -f
WORKDIR /app
COPY --from=build /src/target/font-check.jar .
COPY --from=build /src/target/lib ./lib
RUN adduser -D app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "font-check.jar:lib/*", "FontCheck"]
```

`update-ms-fonts` همان قلم‌های اصلی مایکروسافت را همانند بستهٔ Debian و Ubuntu دانلود و نصب می‌کند و EULA آن به همان شکل اعمال می‌شود. `fc-cache` کش قلم‌های fontconfig را به‌روز می‌کند. تصویر را بسازید و بررسی را با دو فرمان از بخش [بررسی اینکه کدام قلم‌ها جایگزین می‌شوند]#check-which-fonts-are-substituted اجرا کنید. خروجی به صورت زیر خواهد بود:

```text
Font folders: /usr/share/fonts, /home/app/.local/share/fonts, /home/app/.fonts
Font substitutions:
  Calibri -> Arial
```

سایر گام‌های این صفحه در Alpine به همان شکل کار می‌کنند: پوشهٔ *fonts* را به */usr/local/share/fonts* یا به پوشهٔ برنامه کپی کنید و `DEFAULT_FONT` را برای انتخاب قلم پیش‌فرض تنظیم کنید. تصویر Alpine هیچ پوشهٔ */usr/local/share/fonts* ندارد، بنابراین این پوشه تنها پس از اجرای دستور `COPY` ظاهر می‌شود.

## **سوالات متداول**

**چرا یک ارائه هنگام تبدیل در سرور متفاوت به نظر می‌رسد؟**

سرور قلم‌های مورد استفاده ارائه را ندارد، بنابراین Aspose.Slides متن را با قلم جایگزینی که عرض حروف متفاوت دارد می‌کشد. با اجرای *FontCheck* و پاس دادن نام‌های قلم‌های ارائه، بتوانید ببینید کدام قلم‌ها جایگزین می‌شوند، سپس آن قلم‌ها را نصب کنید یا از پوشهٔ برنامه بارگذاری کنید.

**بسته ttf-mscorefonts-installer نصب شد، اما هنوز Arial جایگزین می‌شود. چرا؟**

قبل از نصب بسته، EULA پذیرفته نشده بود، بنابراین نصب‌کننده قلم‌ها را رد کرد. دستور `debconf-set-selections` را قبل از `apt-get install` در همان مرحله‌ای که بسته را نصب می‌کند، قرار دهید، همان‌طور که در [Microsoft Core Fonts]#microsoft-core-fonts نشان داده شد، و تصویر را دوباره بسازید.

**آیا کامپیوتری که PDF را باز می‌کند به قلم‌ها نیاز دارد؟**

خیر. در این مثال‌ها، PDF شامل قلم‌هایی است که برای رسم متن استفاده شده‌اند، بنابراین روی هر کامپیوتری یکسان ظاهر می‌شود. قلم‌ها فقط در جایی که Aspose.Slides ارائه را رندر می‌کند، نیاز هستند.