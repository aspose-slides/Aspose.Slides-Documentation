---
title: تشغيل Aspose.Slides for Java في Docker
linktitle: Docker
type: docs
weight: 150
url: /ar/java/how-to-run-aspose-slides-in-docker/
keywords:
- Docker
- Dockerfile
- حاوية Docker
- بناء متعدد المراحل
- صورة الحاوية
- Eclipse Temurin
- Maven
- Linux
- Ubuntu
- Alpine
- Debian
- fontconfig
- خطوط
- تحويل PDF
- PowerPoint
- عرض تقديمي
- Java
- Aspose.Slides
description: "بناء وتشغيل تطبيق Aspose.Slides for Java في Docker: Dockerfile متعدد المراحل على الصور الرسمية لـ Maven وEclipse Temurin، ومكتبات Linux والخطوط التي تحتاجها Aspose.Slides، وكيفية نسخ الملفات الناتجة إلى جهازك."
---
## **نظرة عامة**

تُظهر هذه المقالة كيفية تشغيل Aspose.Slides for Java داخل حاوية Docker. تقوم بإنشاء مشروع Maven صغير يُنشئ عرضًا تقديميًا يحتوي على صندوق نص ويحولّه إلى PDF، وتعبئته باستخدام Dockerfile متعدد المراحل على صور Maven وEclipse Temurin الرسمية، ثم تشغيله ونسخ الملفات التي تم إنشاؤها إلى جهازك. توضح المقالة أيضًا ما تحتاجه Aspose.Slides في صورة Linux إلى جانب Java، وتختتم بنسخ لِـ Alpine Linux وللصور التي تُثبت Java من حزم التوزيعة.

كل ما تحتاجه هو Docker على جهازك. الـ JDK وMaven جزء من صورة البناء، لذا لا تحتاج إلى تثبيتهما. لتثبيت Docker، راجع [احصل على Docker](https://docs.docker.com/get-started/get-docker/).

## **اختيار صور الأساس**

يستخدم Dockerfile في هذه المقالة صورتين رسميتين من Docker Hub:

- [maven](https://hub.docker.com/_/maven) مع الوسم `3.9-eclipse-temurin-21` يبني التطبيق. يحتوي على Apache Maven 3.9 وEclipse Temurin JDK 21.
- [eclipse-temurin](https://hub.docker.com/_/eclipse-temurin) مع الوسم `21-jre` يشغّله. يحتوي على بيئة تشغيل Eclipse Temurin Java 21 على Ubuntu، دون JDK وMaven.

Aspose.Slides for Java يرسم النص باستخدام دعم الخطوط في Java، والذي على Linux يحتاج إلى مكتبات fontconfig وFreeType وعلى الأقل خط واحد مُثبت. صور Eclipse Temurin تتضمن بالفعل fontconfig وFreeType وخطوط DejaVu، لذا لا يقوم Dockerfile في هذه المقالة بتثبيت أي حزم. في صورة لا تحتوي على أي خط، يتوقف حفظ العرض التقديمي مع الخطأ "Fontconfig head is null, check your fonts or fonts configuration". إذا بنيت على صورة أساس أخرى، راجع [استخدام صورة أساسية أخرى](#use-another-base-image).

## **إنشاء المشروع**

أنشئ مجلدًا باسم *hello-slides-docker* وأضف إليه الملفات التالية.

*pom.xml* يعلن عن مستودع Maven الخاص بـ Aspose واعتماد Aspose.Slides for Java، كما هو موضح في [التثبيت](/slides/ar/java/installation/); Aspose.Slides for Java غير منشور في Maven Central، لذا يُعد إدخال المستودع ضروريًا. عنصر `finalName` يُسمي ملف JAR للتطبيق *hello-slides.jar*، و[maven-dependency-plugin](https://maven.apache.org/plugins/maven-dependency-plugin/) ينسخ تبعيات التطبيق إلى *target/lib* عندما يُعبّئ Maven المشروع. حدّث نسخة Aspose.Slides إلى أحدث نسخة مُدرجة في [المستودع](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/).

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

*src/main/java/HelloSlides.java* يُنشئ كائن [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/)، يُضيف مستطيلًا بنص إلى الشريحة الأولى، ويحفظ العرض التقديمي مرتين باستخدام طريقة [save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#save-java.lang.String-int-): كملف PPTX وكملف PDF. تُحفظ كلا الملفين في مجلد *output* داخل دليل العمل. بعد ذلك يُظهر البرنامج الخطوط التي تستبدلها Aspose.Slides عند عرض العرض التقديمي، باستخدام [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifontsmanager/#getSubstitutions--)، لتتمكن من معرفة ما إذا كانت الحاوية تحتوي على الخطوط المستخدمة في العرض.

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

*.dockerignore* يُبقي مجلد *target* من بناء محلي، ومخرجات تشغيلات سابقة، خارج سياق بناء Docker، بحيث تُبنى الصورة من ملفات المصدر فقط.

```text
target/
output/
```

## **كتابة Dockerfile**

أضف ملفًا باسم *Dockerfile* إلى مجلد *hello-slides-docker*:

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

يتألف الملف من مرحلتين:

- **مرحلة البناء** تبدأ من صورة Maven. تنسخ *pom.xml* أولاً وتُشغل `mvn dependency:go-offline`، والذي يُنزّل Aspose.Slides for Java ومُلحقات Maven، بحيث يعيد Docker استخدام هذه الطبقة طالما لم يتغيّر *pom.xml*. ثم تُنسخ شفرة المصدر وتُشغل `mvn package`، مما يُصبّح البرنامج إلى *target/hello-slides.jar* وينسخ ملف JAR الخاص بـ Aspose.Slides إلى *target/lib*. خيار `-B` يُشغّل Maven في وضع غير تفاعلي (batch).
- **مرحلة التشغيل** تبدأ من صورة تشغيل Java أصغر وتنسخ فقط ملف JAR للتطبيق ومجلد *lib*. تُنشئ مجلد *output*، وتُعيد ملكيته إلى `ubuntu`، وهو المستخدم غير الجذر الذي تُعرّفه الصورة المبنية على Ubuntu، ثم تُشغّل التطبيق بهذا المستخدم. يحتوي مسار الفئة `hello-slides.jar:lib/*` على التطبيق وكل ملف JAR في *lib*؛ Java يوسّع الـ `*` بنفسه.

يُصرّف المشروع لـ Java 11 (خاصية `maven.compiler.release`)، لذا يمكن لمرحلة التشغيل استخدام نسخة Java أحدث. على سبيل المثال، لتشغيل التطبيق على Java 25، غيّر صورة مرحلة التشغيل إلى `eclipse-temurin:25-jre`.

## **بناء وتشغيل الحاوية**

افتح نافذة طرفية في مجلد *hello-slides-docker*. ابنِ الصورة، ثم شغّل حاوية منها:

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

البناء الأول يُنزّل صور الأساس، ومُلحقات Maven، وAspose.Slides for Java، لذا قد يستغرق عدة دقائق؛ البنايات اللاحقة تُعيد استخدامها. تُشغّل الحاوية التطبيق وتتوقف. تُطبع الرسالة التالية:

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

السطر الأول يُظهر أن النص يستخدم Calibri، الخط الافتراضي للعرض التقديمي الجديد، وأن Calibri غير مُثبّت في الصورة، لذا استخدمت Aspose.Slides خط DejaVu Sans. النص في ملف PDF هو نص فعلي قابل للتحديد بهذا الخط. بدون ترخيص، تُضيف Aspose.Slides علامة مائية تقييمية إلى كل شريحة تُحفظ؛ راجع [الترخيص](/slides/ar/java/licensing/).

## **نسخ المخرجات إلى جهازك**

الملفات موجودة في مجلد */app/output* داخل الحاوية المتوقّفة. انسخها إلى مجلد *output* على جهازك، ثم احذف الحاوية:

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

هذان الأمران يعملان بنفس الطريقة في Bash وPowerShell وموجه أوامر Windows.

على Linux، يمكنك بدلًا من ذلك ربط مجلد من جهازك إلى الحاوية، بحيث يكتب التطبيق ملفاته هناك مباشرةً:

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

خيار `--user` يُشغّل التطبيق بمعرفات المستخدم والمجموعة الخاصة بك، لذا يمكنه الكتابة إلى المجلد الذي أنشأته وتعود الملفات لك. `--rm` يزيل الحاوية عند توقفها.

## **التشغيل على Alpine Linux**

Eclipse Temurin متوفر أيضًا كصورة مبنية على Alpine Linux، وهي أصغر حجمًا. تحتوي أيضًا على fontconfig وFreeType وخطوط DejaVu، لذا لا يحتاج التطبيق إلى حزم إضافية هناك أيضًا. لاستخدامها، استبدل مرحلة التشغيل في *Dockerfile* (كل ما بعد سطر `FROM` الثاني) بـ:

```dockerfile
FROM eclipse-temurin:21-jre-alpine
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN adduser -D app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

صورة Alpine لا تحتوي على مستخدم `ubuntu`، لذا تُنشئ هذه المرحلة مستخدمًا باسم `app` باستخدام `adduser` وتُشغّل التطبيق بهذا المستخدم. ابنِ، وشغّل، وانسخ المخرجات بنفس الأوامر السابقة. التطبيق يُطبع السطرين نفسه.

## **استخدام صورة أساسية أخرى**

إذا كانت صورتك تثبّت Java من حزم توزيع Linux، فثبّت مكتبات خطوط Java وخطًا معها. على Debian وUbuntu، تُدرج حزمة `openjdk-21-jre-headless` fontconfig وFreeType وHarfBuzz فقط كحزم مُوصى بها، لذا يؤدي `apt-get install --no-install-recommends` إلى تركها، ويتوقف التطبيق مع `UnsatisfiedLinkError` لـ `libfontmanager.so`. تُثبت هذه المرحلة وقت التشغيل Java 21، والمكتبات، وخطوط DejaVu على Debian 13، وتُنشئ مستخدمًا غير جذري باسم `app`:

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

تعمل نفس المرحلة على Ubuntu 26.04 باستخدام `FROM ubuntu:26.04`.

## **الأسئلة الشائعة**

**يتوقف حفظ العرض التقديمي مع الخطأ "Fontconfig head is null, check your fonts or fonts configuration". ما الذي ينقص؟**

خط. لم يجد دعم الخطوط في Java أي خط مُثبت في الصورة. ثبّت حزمة خطوط، على سبيل المثال `fonts-dejavu-core` على Debian وUbuntu، كما في [استخدام صورة أساسية أخرى](#use-another-base-image). تُدرج [نشر الخطوط](/slides/ar/java/deploy-fonts/) حزم خطوط أخرى.

**يتوقف التطبيق مع UnsatisfiedLinkError لـ libfontmanager.so. ما الذي ينقص؟**

مكتبة أصلية لدعم خطوط Java؛ الرسالة تُظهر الملف الذي لم يُحمّل، مثل `libharfbuzz.so.0`. يحدث هذا عندما تُثبّت Java من حزم التوزيعة دون الحزم المُوصى بها. ثبّت المكتبات المذكورة في [استخدام صورة أساسية أخرى](#use-another-base-image).

**لماذا يكون النص في PDF بخط مختلف عن PowerPoint؟**

الخطوط التي يستخدمها العرض غير مُثبتة في الصورة، لذا تُستبدل Aspose.Slides الخطوط بخط بديل. يُظهر مخرجات التطبيق كل خط تم استبداله. توضح [نشر الخطوط](/slides/ar/java/deploy-fonts/) كيفية تثبيت الخطوط في الصورة أو تحميلها من مجلد التطبيق.

**كم مقدار الذاكرة التي يمكن للتطبيق استخدامها في الحاوية؟**

بشكل افتراضي، يحدّ Java حجم الـ heap إلى ربع الذاكرة المتاحة للحاوية، مثلاً تقريبًا 250 MB عند تشغيل الحاوية بـ `docker run -m 1g`. لمعالجة عروض تقديمية كبيرة، زد النسبة باستخدام خيار `MaxRAMPercentage`، مثل `docker run --rm -m 1g -e JAVA_TOOL_OPTIONS=-XX:MaxRAMPercentage=75 hello-slides`. بعد ذلك تُطبع Java سطر "Picked up JAVA_TOOL_OPTIONS" قبل مخرجات التطبيق.

**هل أحتاج إلى JDK أو Maven على جهازي؟**

لا. تُصنّف مرحلة البناء التطبيق داخل صورة Maven. تحتاج إلى JDK وMaven فقط إذا أردت بناء وتشغيل التطبيق خارج Docker؛ راجع [التثبيت](/slides/ar/java/installation/).