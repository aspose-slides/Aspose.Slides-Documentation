---
title: نشر الخطوط لـ Aspose.Slides لـ Java على Linux وفي Docker
linktitle: نشر الخطوط
type: docs
weight: 155
url: /ar/java/deploy-fonts/
keywords:
- نشر الخطوط
- تثبيت الخطوط
- خطوط في Docker
- خطوط على Linux
- خطوط مفقودة
- استبدال الخطوط
- خطوط Microsoft الأساسية
- ttf-mscorefonts-installer
- خطوط مخصصة
- خط افتراضي
- خادم
- حاوية
- تحويل PDF
- عرض تقديمي
- Java
- Aspose.Slides
description: "نشر الخطوط لـ Aspose.Slides لـ Java على خوادم Linux وفي حاويات Docker: تحقق من الخطوط التي تم استبدالها، ثبّت حزم الخطوط على Debian وUbuntu وAlpine، أضف ملفات الخطوط الخاصة بك، وحدد خطًا افتراضيًا."
---
## **نظرة عامة**

Aspose.Slides يرسم النص باستخدام الخطوط المتاحة له عند عرض العرض التقديمي، على سبيل المثال عند تحويل الشرائح إلى PDF أو إلى صور. عادةً ما يحتوي سطح مكتب Windows على الخطوط التي يستخدمها العروض التقديمية. خوادم Linux والحاويات عادةً ما تحتوي على عدد قليل من الخطوط، لذا تقوم Aspose.Slides برسم النص بخط بديل. الخط البديل له أشكال عرض وأحرف مختلفة، لذلك قد يلتف السطر بشكل مختلف ويتجاوز النص الشكل المحدد، ولا تُرسم الأحرف التي لا يتضمنها الخط البديل بشكل صحيح. إذا لم يتم تثبيت أي خط على الإطلاق، لا يمكن لدعم الخطوط في Java أن يبدأ، وتوقف Aspose.Slides مع خطأ.

هذه المقالة توضح كيفية فحص الخطوط التي تستبدلها Aspose.Slides، وكيفية تثبيت الخطوط على Debian وUbuntu وAlpine Linux، وكيفية إضافة ملفات خطوطك الخاصة، وكيفية تحديد الخط الذي يستخدم عندما يكون الخط مفقودًا. تُشغل الأمثلة داخل Docker باستخدام صور Eclipse Temurin الرسمية، كما هو موضح في [تشغيل Aspose.Slides لـ Java في Docker](/slides/ar/java/how-to-run-aspose-slides-in-docker/). أوامر الحزمة هي تعليمات Dockerfile؛ على خادم Linux، شغِّل نفس الأوامر كجذر.

لواجهة برمجة التطبيقات الخاصة بالخطوط نفسها، مثل تضمين الخطوط في عرض تقديمي وقواعد السقوط والبدائل، راجع [خطوط PowerPoint](/slides/ar/java/powerpoint-fonts/).

## **التحقق من الخطوط المستبدلة**

المشروع التالي باستخدام Maven يُظهر الخطوط التي تستبدلها Aspose.Slides في البيئة الحالية. أنشئ مجلدًا اسمه *font-check* وأضف الملفات أدناه إليه.

*pom.xml* هو نفسه الموجود في [تشغيل Aspose.Slides لـ Java في Docker](/slides/ar/java/how-to-run-aspose-slides-in-docker/#create-the-project)، مع تغيير معرف الـ artifact واسم ملف JAR إلى *font-check*:

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

*src/main/java/FontCheck.java* يضيف صندوق نص واحد لكل اسم خط إلى شريحة ويعيّن الخط باستخدام طريقة [setLatinFont](https://reference.aspose.com/slides/ar/java/com.aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-). تأتي أسماء الخطوط من سطر الأوامر؛ بدون وسائط، يتحقق البرنامج من Calibri وArial وTimes New Roman. يطبع المجلدات التي يبحث فيها Aspose.Slides عن الخطوط ([FontsLoader.getFontFolders](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fontsloader/#getFontFolders--))، يرسم الشريحة إلى *output/fonts.pdf*، ويطبع البدائل التي أبلغ عنها [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ifontsmanager/#getSubstitutions--). الخطوتان الاختياريتان في البداية، تحميل مجلد *fonts* وقراءة المتغيّر `DEFAULT_FONT`، موضحان لاحقًا في هذه المقالة.

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
        // الخطوط التي يجب فحصها: وسيطات سطر الأوامر، أو ثلاثة خطوط شائعة في Office.
        String[] fontNames = args.length > 0 ? args : new String[] { "Calibri", "Arial", "Times New Roman" };

        // حمّل ملفات الخطوط من مجلد الخطوط في دليل العمل، إذا كان موجودًا.
        File appFontFolder = new File("fonts");
        if (appFontFolder.isDirectory()) {
            FontsLoader.loadExternalFonts(new String[] { appFontFolder.getAbsolutePath() });
        }

        // استخدم الخط المذكور في المتغيّر البيئي DEFAULT_FONT، إذا كان مُعَيَّنًا، للنص الذي يفتقد الخط.
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

`getFontFolders` يمكن أن يعيد مجلدًا أكثر من مرة، لذا يجمع البرنامج المجلدات في مجموعة قبل طباعتها.

*.dockerignore* يبقي نتائج البناء المحلية خارج سياق البناء:

```text
target/
output/
```

*Dockerfile* يبني البرنامج باستخدام صورة Maven ويشغّله على صورة تشغيل Java من Eclipse Temurin، التي تحتوي بالفعل على fontconfig وخطوط DejaVu. يشرح [تشغيل Aspose.Slides لـ Java في Docker](/slides/ar/java/how-to-run-aspose-slides-in-docker/) كل تعليمة.

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

بناء الصورة وتشغيل الفحص:

```bash
docker build -t font-check .
docker run --rm font-check
```

الصورة تحتوي فقط على خطوط DejaVu، لذلك تم استبدال جميع الخطوط الثلاثة بـ DejaVu Sans:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

للتحقق من خطوط عروضك التقديمية الخاصة، مرّر أسمائها كوسائط، على سبيل المثال `docker run --rm font-check "Segoe UI" Consolas`. لنسخ *output/fonts.pdf* خارج الحاوية، استخدم الأوامر في [نسخ الإخراج إلى جهازك](/slides/ar/java/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine).

## **تثبيت الخطوط على Debian وUbuntu**

### **Microsoft Core Fonts**

حزمة `ttf-mscorefonts-installer` تقوم بتحميل وتثبيت خطوط Microsoft الأساسية للويب، من بينها Arial وTimes New Roman وCourier New وVerdana وGeorgia وTrebuchet MS. الخطوط مرخصة بموجب اتفاقية ترخيص المستخدم النهائي لـ Microsoft (EULA)، وتثبت الحزمة الخطوط فقط بعد قبول الـ EULA. لا يمكن لبناء Docker الإجابة على المطالبة، لذا يرفض المثبت الـ EULA ولا يثبت أي خطوط، بينما لا يزال `apt-get install` يُظهر نجاحًا. قم بقبول الـ EULA باستخدام `debconf-set-selections` **قبل** تثبيت الحزمة. القبول في تعليمة لاحقة لا يُفيد: تكون الحزمة قد شُغّلت بالفعل، ولا يعيد apt تشغيل المثبت مرة أخرى.

أضف هذا السطر إلى مرحلة runtime من *Dockerfile*، مباشرةً بعد سطر `FROM`، لتشغيله كجذر، قبل تعليمة `USER`:

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

بناء الصورة وتشغيل الفحص مرة أخرى باستخدام الأمرين نفسه. الآن تم تثبيت Arial وTimes New Roman:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

Calibri، الخط الافتراضي للعرض التقديمي الذي تنشئه Aspose.Slides، ليس من الخطوط الأساسية، لذا لا يزال يُستبدل. انظر [تحديد خط افتراضي للخطوط المفقودة](#set-a-default-font-for-missing-fonts).

تُمكّن صور Eclipse Temurin المستندة إلى Ubuntu مكوّن `multiverse`، وهو المكوّن الذي يحتوي على الحزمة. في Debian، الحزمة موجودة في المكوّن `contrib`، الذي لا يتم تمكينه في صور Debian. في مرحلة runtime تعتمد على Debian، مثل تلك الموجودة في [استخدام صورة أساسية أخرى](/slides/ar/java/how-to-run-aspose-slides-in-docker/#use-another-base-image)، فعّل `contrib` في نفس التعليمة:

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

### **حزم خطوط أخرى**

Debian وUbuntu تُوزّع أيضًا خطوطًا مرخصة بحرية، على سبيل المثال:

| Package | Fonts |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans, DejaVu Serif, DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans, Serif, and Mono, with the same metrics as Arial, Times New Roman, and Courier New |
| `fonts-crosextra-carlito` | Carlito, with the same metrics as Calibri |
| `fonts-crosextra-caladea` | Caladea, with the same metrics as Cambria |

ثبتها باستخدام `apt-get install` في تعليمة `RUN` لمرحلة runtime، بنفس طريقة خطوط Microsoft الأساسية. لا تُطبق Aspose.Slides for Java ألقاب الخطوط من تكوين خطوط Linux: حتى مع تثبيت `fonts-liberation`، لا يزال النص بـ Arial يُرسم بخط بديل عام، وليس بـ Liberation Sans. لاستخدام خط متوافق من حيث المقاييس بدلًا من الخط المفقود، عيّنّه كـ [خط افتراضي](/slides/ar/java/default-font/) أو أضف [قواعد استبدال الخطوط](/slides/ar/java/font-substitution/).

## **إضافة ملفات خطوطك الخاصة**

الخطوط التي لا تُوزّعها التوزيعات، مثل خطوط مؤسستك أو خطوط أخرى مرخص لك استخدامها على الخادم، يمكن إضافتها كملفات خطوط. ضع ملفات الخطوط، على سبيل المثال ملفات *.ttf*، في مجلد اسمه *fonts* داخل مجلد *font-check*. الأمثلة أدناه تستخدم ملفات Carlito، وهو خط له نفس مقاييس Calibri، ويمكنك تنزيله من [Google Fonts](https://fonts.google.com/specimen/Carlito).

### **تثبيت الخطوط في مجلد نظام الخطوط**

Aspose.Slides يقرأ الخطوط في المجلدات التي تُطبع في سطر `Font folders`. لتثبيت خطوطك لكل التطبيقات في الصورة، انسخها إلى */usr/local/share/fonts*، المجلد المخصص للخطوط المثبتة محليًا. أضف هذا السطر إلى مرحلة runtime من *Dockerfile*، بعد تعليمة `RUN` التي تثبت خطوط Microsoft الأساسية:

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

أعد بناء الصورة، ثم تحقق من Calibri وCarlito:

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

لم يعد Carlito يُستبدل:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

### **تحميل الخطوط من مجلد التطبيق**

بدلاً من تثبيت الخطوط في مجلد نظام، يمكنك شحنتها مع التطبيق وتحميلها باستخدام [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ar/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---). تصبح الخطوط متاحةً لـ Aspose.Slides فقط، وتُنشر مع التطبيق. يقوم *FontCheck* بذلك: عندما يكون دليل عمله، */app* داخل الحاوية، يحتوي على مجلد *fonts*، يمرّر البرنامج هذا المجلد إلى `loadExternalFonts` قبل إنشاء العرض التقديمي. يصف [الخط المخصص](/slides/ar/java/custom-font/) الطرق الأخرى لتوفير الخطوط، مثل تحميلها من الذاكرة.

في *Dockerfile*، أزل تعليمة `COPY fonts/ /usr/local/share/fonts/` وأضف هذه التعليمة بعد تعليمة النسخ التي تنقل مجلد *lib*:

```dockerfile
COPY fonts/ ./fonts/
```

أعد بناء الصورة وشغّل الفحص باستخدام الأمرين نفسه. سيظهر الآن مجلد التطبيق ضمن مجلدات الخطوط، ولا يزال Carlito غير مستبدل:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

`loadExternalFonts` يضيف الخطوط إلى الخطوط المثبتة، لكن دعم الخطوط في Java لا يزال بحاجة إلى خط واحد مثبت على الأقل. في صورة لا تحتوي على أي خط، يتوقف `loadExternalFonts` مع الخطأ "Fontconfig head is null, check your fonts or fonts configuration".

## **تحديد خط افتراضي للخطوط المفقودة**

عند فقدان خط ما، تستخدم Aspose.Slides بديلًا تختاره بنفسها. لاختيارك الخاص، مرّر اسم الخط إلى طريقة [setDefaultRegularFont](https://reference.aspose.com/slides/ar/java/com.aspose.slides/loadoptions/#setDefaultRegularFont-java.lang.String-) من فئة [LoadOptions](https://reference.aspose.com/slides/ar/java/com.aspose.slides/loadoptions/) ومرّر الخيارات إلى مُنشئ [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/). يقرأ *FontCheck* اسم الخط من متغيّر البيئة `DEFAULT_FONT`. مع تحميل Carlito، استخدمه للخطوط المفقودة:

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

الآن يُرسم Calibri باستخدام Carlito، الذي تمتلك حروفه نفس عرض حروف Calibri، لذا يحافظ النص على فواصل الأسطر:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Carlito
```

الخط الافتراضي يحل كل خط مفقود. لتعيين خطوط فردية، على سبيل المثال Arial إلى Liberation Sans وCalibri إلى Carlito، استخدم [قواعد استبدال الخطوط](/slides/ar/java/font-substitution/). القواعد تغيّر المخرجات المرسومة، لكن `getSubstitutions` لا يعكسها، لذا تحقق من الخطوط في ملف الإخراج نفسه. بالنسبة للنص الآسيوي، استدعِ أيضًا [setDefaultAsianFont](https://reference.aspose.com/slides/ar/java/com.aspose.slides/loadoptions/#setDefaultAsianFont-java.lang.String-); راجع [الخط الافتراضي](/slides/ar/java/default-font/).

## **تثبيت الخطوط على Alpine Linux**

الصورة المستندة إلى Alpine من Eclipse Temurin تحتوي أيضًا على خطوط DejaVu؛ يصف [التشغيل على Alpine Linux](/slides/ar/java/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) مرحلة runtime الخاصة بها. لتثبيت خطوط Microsoft الأساسية عليها كذلك، استبدل مرحلة runtime من Dockerfile الخاص بـ *font-check* بهذه:

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

`update-ms-fonts` يقوم بتحميل وتثبيت نفس خطوط Microsoft الأساسية كما في حزمة Debian وUbuntu، وتطبق عليها الـ EULA بنفس الطريقة. `fc-cache` يُحدّث ذاكرة الخطوط الخاصة بـ fontconfig. ابنِ الصورة وشغّل الفحص باستخدام الأمرين من [التحقق من الخطوط المستبدلة](#check-which-fonts-are-substituted). ستظهر النتيجة:

```text
Font folders: /usr/share/fonts, /home/app/.local/share/fonts, /home/app/.fonts
Font substitutions:
  Calibri -> Arial
```

الخطوات الأخرى في هذه الصفحة تعمل بنفس الطريقة على Alpine: انسخ مجلد *fonts* إلى */usr/local/share/fonts* أو إلى مجلد التطبيق، وحدد `DEFAULT_FONT` لاختيار الخط الافتراضي. لا تملك صورة Alpine مجلد */usr/local/share/fonts*، لذا يظهر هذا المجلد في سطر `Font folders` فقط بعد أن تُنشئه تعليمة `COPY`.

## **الأسئلة المتكررة**

**لماذا يبدو العرض التقديمي مختلفًا عند تحويله على الخادم؟**

الخادم لا يحتوي على الخطوط التي يستخدمها العرض التقديمي، لذلك ترسم Aspose.Slides النص بخط بديل يختلف عرض حروفه. شغّل *FontCheck* مع أسماء خطوط العرض لتعرف أي الخطوط تم استبدالها، ثم ثبّت تلك الخطوط أو حمّلها من مجلد التطبيق.

**قمت بتثبيت ttf-mscorefonts-installer، لكن لا يزال Arial يُستبدل. لماذا؟**

لم يتم قبول الـ EULA قبل تثبيت الحزمة، لذا تخطى المثبت الخطوط. ضع أمر `debconf-set-selections` قبل `apt-get install` في التعليمة التي تثبت الحزمة، كما هو موضح في [خطوط Microsoft الأساسية](#microsoft-core-fonts)، ثم أعد بناء الصورة.

**هل يحتاج الكمبيوتر الذي يفتح ملف PDF إلى الخطوط؟**

لا. في هذه الأمثلة، يحتوي ملف PDF على الخطوط التي استُخدمت لرسم النص، لذا يظهر بنفس الشكل على أي جهاز. الخطوط مطلوبة فقط في المكان الذي تقوم فيه Aspose.Slides برسم العرض التقديمي.