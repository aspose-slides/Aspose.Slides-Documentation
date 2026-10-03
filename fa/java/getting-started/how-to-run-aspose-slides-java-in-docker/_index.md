---
title: اجرای Aspose.Slides برای Java در Docker
linktitle: داکر
type: docs
weight: 150
url: /fa/java/how-to-run-aspose-slides-in-docker/
keywords:
- داکر
- Dockerfile
- کانتینر Docker
- ساخت چند مرحله‌ای
- تصویر کانتینر
- Eclipse Temurin
- Maven
- لینوکس
- اوبونتو
- آلپاین
- دبیان
- fontconfig
- قلم‌ها
- تبدیل PDF
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "ساخت و اجرای یک برنامه Aspose.Slides برای Java در Docker: یک Dockerfile چند مرحله‌ای بر روی تصاویر رسمی Maven و Eclipse Temurin، کتابخانه‌ها و قلم‌های لینوکسی که Aspose.Slides به آن‌ها نیاز دارد، و نحوه کپی کردن فایل‌های تولید شده به ماشین شما."
---
## **نمای کلی**

این مقاله نشان می‌دهد چگونه Aspose.Slides for Java را در یک کانتینر Docker اجرا کنید. شما یک پروژه کوچک Maven می‌سازید که یک ارائه با یک جعبه متن ایجاد می‌کند و آن را به PDF تبدیل می‌کند، آن را با یک Dockerfile چندمرحله‌ای بر روی تصاویر رسمی Maven و Eclipse Temurin بسته‌بندی می‌کنید، اجرا می‌کنید و فایل‌های تولید شده را به ماشین خود کپی می‌کنید. مقاله همچنین توضیح می‌دهد Aspose.Slides به جز Java در یک تصویر لینوکس به چه چیزهایی نیاز دارد و با متغیرهایی برای Alpine Linux و برای تصاویری که Java را از بسته‌های توزیع نصب می‌کنند، پایان می‌یابد.

شما فقط به Docker بر روی ماشین خود نیاز دارید. JDK و Maven بخشی از تصویر ساخت هستند، بنابراین نیازی به نصب آن‌ها ندارید. برای نصب Docker، به [Get Docker](https://docs.docker.com/get-started/get-docker/) مراجعه کنید.

## **انتخاب تصاویر پایه**

Dockerfile در این مقاله از دو تصویر رسمی در Docker Hub استفاده می‌کند:

- [maven](https://hub.docker.com/_/maven) با برچسب `3.9-eclipse-temurin-21` برنامه را می‌سازد. این تصویر شامل Apache Maven 3.9 و Eclipse Temurin JDK 21 است.
- [eclipse-temurin](https://hub.docker.com/_/eclipse-temurin) با برچسب `21-jre` آن را اجرا می‌کند. این تصویر شامل زمان اجرای Eclipse Temurin Java 21 بر روی Ubuntu است، بدون JDK و Maven.

Aspose.Slides for Java متن را با پشتیبانی قلم‌های Java رسم می‌کند که در لینوکس به کتابخانه‌های fontconfig و FreeType و حداقل یک قلم نصب‌شده نیاز دارد. تصاویر Eclipse Temurin از پیش شامل fontconfig، FreeType و قلم‌های DejaVu هستند، بنابراین Dockerfile در این مقاله هیچ بسته‌ای نصب نمی‌کند. در تصویری بدون هیچ قلمی، ذخیره ارائه با خطای «Fontconfig head is null, check your fonts or fonts configuration» متوقف می‌شود. اگر بر پایه تصویر دیگری می‌سازید، به [Use Another Base Image](#use-another-base-image) مراجعه کنید.

## **ایجاد پروژه**

یک پوشه به نام *hello-slides-docker* ایجاد کنید و فایل‌های زیر را به آن اضافه کنید.

*pom.xml* مخزن Maven Aspose و وابستگی Aspose.Slides for Java را همان‌طور که در [Installation](/slides/fa/java/installation/) توضیح داده شده اعلام می‌کند؛ Aspose.Slides for Java در Maven Central منتشر نشده، بنابراین ورودی مخزن ضروری است. عنصر `finalName` نام فایل JAR برنامه را *hello-slides.jar* می‌گذارد و [maven-dependency-plugin](https://maven.apache.org/plugins/maven-dependency-plugin/) وابستگی‌های برنامه را به *target/lib* کپی می‌کند وقتی Maven آن را بسته‌بندی می‌کند. نسخه Aspose.Slides را به آخرین نسخه فهرست‌شده در [repository](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) تنظیم کنید.

```xml
<project xmlns="http://maven.apache.org/POM/4.0.0">
    <modelVersion>4.0.0</modelVersion>
    <groupId>com.example</groupId>
    <artifactId>hello-slides</artifactId>
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
        <finalName>hello-slides</finalName>
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

*src/main/java/HelloSlides.java* یک [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) می‌سازد، یک مستطیل با متن به اسلاید اول آن اضافه می‌کند و ارائه را دو بار با متد [save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#save-java.lang.String-int-) ذخیره می‌کند: به صورت PPTX و به صورت PDF. هر دو فایل در پوشه *output* زیر پوشه کاری قرار می‌گیرند. سپس برنامه قلم‌هایی که Aspose.Slides هنگام رندر ارائه جایگزین می‌کند، با استفاده از [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) فهرست می‌کند تا بتوانید ببینید آیا کانتینر قلم‌های مورد استفاده ارائه را دارد یا خیر.

```java
import com.aspose.slides.*;
import java.io.File;

public class HelloSlides {
    public static void main(String[] args) {
        File outputFolder = new File("output");
        outputFolder.mkdirs();

        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.getTextFrame().setText("Hello from a Docker container!");

            String pptxPath = new File(outputFolder, "hello.pptx").getPath();
            String pdfPath = new File(outputFolder, "hello.pdf").getPath();
            presentation.save(pptxPath, SaveFormat.Pptx);
            presentation.save(pdfPath, SaveFormat.Pdf);

            for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
                System.out.println("Font substitution: " + substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
            }

            System.out.println("Saved " + pptxPath + " and " + pdfPath);
        } finally {
            presentation.dispose();
        }
    }
}
```

*.dockerignore* پوشه *target* ساخت محلی و خروجی اجراهای قبلی را از زمینه ساخت Docker خارج می‌کند، بنابراین تصویر تنها از فایل‌های منبع ساخته می‌شود.

```text
target/
output/
```

## **نوشتن Dockerfile**

یک فایل به نام *Dockerfile* به پوشه *hello-slides-docker* اضافه کنید:

```dockerfile
FROM maven:3.9-eclipse-temurin-21 AS build
WORKDIR /src
COPY pom.xml .
RUN mvn -B dependency:go-offline
COPY src ./src
RUN mvn -B package

FROM eclipse-temurin:21-jre
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN mkdir output && chown ubuntu output
USER ubuntu
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

این فایل دو مرحله دارد:

- **مرحله ساخت** از تصویر Maven آغاز می‌شود. ابتدا *pom.xml* را کپی می‌کند و `mvn dependency:go-offline` را اجرا می‌کند، که Aspose.Slides for Java و افزونه‌های Maven را دانلود می‌کند، بنابراین Docker این لایه را تا زمانی که *pom.xml* تغییری نکند، دوباره استفاده می‌کند. سپس کد منبع را کپی می‌کند و `mvn package` را اجرا می‌کند، که برنامه را به *target/hello-slides.jar* کامپایل می‌کند و فایل JAR Aspose.Slides را به *target/lib* کپی می‌کند. گزینه `-B` Maven را در حالت غیر تعاملی (batch) اجرا می‌کند.
- **مرحله زمان اجرا** از تصویر زمان اجرای کوچکتر Java آغاز می‌شود و فقط فایل JAR برنامه و پوشه *lib* را کپی می‌کند. پوشه *output* را ایجاد می‌کند، آن را به کاربر `ubuntu` (کاربر غیر ریشه‌ای که تصویر مبتنی بر Ubuntu تعریف می‌کند) اختصاص می‌دهد و برنامه را به عنوان همان کاربر اجرا می‌کند. مسیر کلاس `hello-slides.jar:lib/*` شامل برنامه و هر فایل JAR در *lib* است؛ Java خود `*` را گسترش می‌دهد.

پروژه برای Java 11 کامپایل شده است (ویژگی `maven.compiler.release`)، بنابراین مرحله زمان اجرا می‌تواند از نسخه جدیدتر Java استفاده کند. برای مثال، برای اجرای برنامه روی Java 25، تصویر مرحله زمان اجرا را به `eclipse-temurin:25-jre` تغییر دهید.

## **ساخت و اجرای کانتینر**

در پوشه *hello-slides-docker* یک ترمینال باز کنید. تصویر را بسازید، سپس یک کانتینر از آن اجرا کنید:

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

ساخت اول پایه‌های تصویر، افزونه‌های Maven و Aspose.Slides for Java را دانلود می‌کند، لذا چند دقیقه طول می‌کشد؛ ساخت‌های بعدی آنها را دوباره استفاده می‌کنند. کانتینر برنامه را اجرا می‌کند و متوقف می‌شود. خروجی به شکل زیر است:

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

خط اول نشان می‌دهد متن از قلم Calibri (قلم پیش‌فرض یک ارائه جدید) استفاده می‌کند و Calibri در تصویر نصب نشده؛ بنابراین Aspose.Slides متن را با DejaVu Sans رسم کرده است. متن در PDF قلم واقعی قابل انتخاب است. بدون لایسنس، Aspose.Slides همچنین یک واترمارک ارزیابی به هر اسلاید اضافه می‌کند؛ به [Licensing](/slides/fa/java/licensing/) مراجعه کنید.

## **کپی خروجی به ماشین شما**

فایل‌ها در پوشه */app/output* کانتینر متوقف‌شده قرار دارند. آنها را به پوشه *output* روی ماشین خود کپی کنید، سپس کانتینر را حذف کنید:

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

این دو فرمان در Bash، PowerShell و Windows Command Prompt به همان شکل کار می‌کند.

در لینوکس می‌توانید به‌جای آن، یک پوشه از ماشین خود را به کانتینر سوار کنید تا برنامه مستقیماً فایل‌های خود را در آن بنویسد:

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

گزینه `--user` برنامه را با شناسه‌های کاربر و گروه شما اجرا می‌کند، بنابراین می‌تواند در پوشه‌ای که ایجاد کرده‌اید بنویسد و فایل‌ها متعلق به شما می‌شوند. `--rm` کانتینر را هنگام توقف حذف می‌کند.

## **اجرای روی Alpine Linux**

Eclipse Temurin به‌عنوان تصویر مبتنی بر Alpine Linux نیز موجود است که کوچکتر است. این تصویر نیز شامل fontconfig، FreeType و قلم‌های DejaVu است، بنابراین برنامه نیازی به بسته‌های اضافه ندارد. برای استفاده از آن، مرحله زمان اجرا در *Dockerfile* (همه موارد از خط دوم `FROM` به بعد) را با موارد زیر جایگزین کنید:

```dockerfile
FROM eclipse-temurin:21-jre-alpine
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN adduser -D app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

تصویر Alpine کاربر `ubuntu` را ندارد، بنابراین این مرحله یک کاربر به نام `app` با `adduser` ایجاد می‌کند و برنامه را به عنوان آن کاربر اجرا می‌نماید. همان دستورات ساخت، اجرا و کپی خروجی را همانند بالا استفاده کنید. برنامه همان دو خط را چاپ می‌کند.

## **استفاده از تصویر پایه دیگر**

اگر تصویر شما Java را از بسته‌های توزیع لینوکس نصب می‌کند، کتابخانه‌های قلم Java و یک قلم را همراه آن نصب کنید. در Debian و Ubuntu، بسته `openjdk-21-jre-headless` فقط کتابخانه‌های fontconfig، FreeType و HarfBuzz را به‌عنوان بسته‌های پیشنهادی لیست می‌کند، بنابراین `apt-get install --no-install-recommends` آنها را حذف می‌کند و برنامه با `UnsatisfiedLinkError` برای `libfontmanager.so` متوقف می‌شود. این مرحله زمان اجرا Java 21، کتابخانه‌ها و قلم‌های DejaVu را بر روی Debian 13 نصب می‌کند و یک کاربر غیر ریشه به نام `app` ایجاد می‌کند:

```dockerfile
FROM debian:trixie
RUN apt-get update \
    && apt-get install -y --no-install-recommends openjdk-21-jre-headless libfontconfig1 libfreetype6 libharfbuzz0b fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN useradd --create-home app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

همان مرحله روی Ubuntu 26.04 با `FROM ubuntu:26.04` کار می‌کند.

## **سوالات متداول**

**ذخیره ارائه با خطای "Fontconfig head is null, check your fonts or fonts configuration" متوقف می‌شود. چه چیزی غائب است؟**

یک قلم. پشتیبانی قلم Java هیچ قلم نصب‌شده‌ای در تصویر پیدا نکرد. یک بسته قلم نصب کنید، برای مثال `fonts-dejavu-core` روی Debian و Ubuntu، همان‌طور که در [Use Another Base Image](#use-another-base-image) آمده است. [Deploy Fonts](/slides/fa/java/deploy-fonts/) بسته‌های قلم دیگر را فهرست می‌کند.

**برنامه با UnsatisfiedLinkError برای libfontmanager.so متوقف می‌شود. چه چیزی غائب است؟**

یک کتابخانه بومی از پشتیبانی قلم Java؛ پیام نام فایلی که نمی‌تواند بارگذاری شود را نشان می‌دهد، برای مثال `libharfbuzz.so.0`. این اتفاق می‌افتد زمانی که Java از بسته‌های توزیع بدون بسته‌های پیشنهادی نصب می‌شود. کتابخانه‌های ذکرشده در [Use Another Base Image](#use-another-base-image) را نصب کنید.

**چرا متن در PDF با قلم متفاوتی نسبت به PowerPoint نمایش داده می‌شود؟**

قلم‌های مورد استفاده ارائه در تصویر نصب نیستند، بنابراین Aspose.Slides متن را با یک قلم جایگزین رسم می‌کند. خروجی برنامه هر قلم جایگزین‌شده را نام می‌برد. [Deploy Fonts](/slides/fa/java/deploy-fonts/) توضیح می‌دهد چگونه قلم‌ها را در تصویر نصب یا از پوشه برنامه بارگذاری کنید.

**حافظه‌ای که برنامه می‌تواند در کانتینر استفاده کند چقدر است؟**

به‌صورت پیش‌فرض، Java حافظه heap خود را به یک‌چهارم حافظه موجود برای کانتینر محدود می‌کند، به‌عنوان مثال حدود 250 MB وقتی کانتینر را با `docker run -m 1g` راه‌اندازی می‌کنید. برای پردازش ارائه‌های بزرگ، می‌توانید سهم را با گزینه `MaxRAMPercentage` افزایش دهید، به‌عنوان مثال `docker run --rm -m 1g -e JAVA_TOOL_OPTIONS=-XX:MaxRAMPercentage=75 hello-slides`. سپس Java خطی با متن «Picked up JAVA_TOOL_OPTIONS» قبل از خروجی برنامه چاپ می‌کند.

**آیا به JDK یا Maven روی ماشین خود نیاز دارم؟**

خیر. مرحله ساخت برنامه را داخل تصویر Maven کامپایل می‌کند. تنها زمانی به JDK و Maven نیاز دارید که بخواهید برنامه را خارج از Docker بسازید و اجرا کنید؛ به [Installation](/slides/fa/java/installation/) مراجعه کنید.