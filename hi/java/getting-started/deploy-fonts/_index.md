---
title: Linux और Docker में Aspose.Slides for Java के लिए फ़ॉन्ट्स तैनात करें
linktitle: फ़ॉन्ट्स तैनात करें
type: docs
weight: 155
url: /hi/java/deploy-fonts/
keywords:
- फ़ॉन्ट्स तैनात करें
- फ़ॉन्ट्स इंस्टॉल करें
- Docker में फ़ॉन्ट्स
- Linux पर फ़ॉन्ट्स
- अनुपलब्ध फ़ॉन्ट्स
- फ़ॉन्ट प्रतिस्थापन
- Microsoft कोर फ़ॉन्ट्स
- ttf-mscorefonts-installer
- कस्टम फ़ॉन्ट्स
- डिफ़ॉल्ट फ़ॉन्ट
- सर्वर
- कंटेनर
- PDF रूपांतरण
- प्रस्तुति
- Java
- Aspose.Slides
description: "Linux सर्वरों और Docker कंटेनरों में Aspose.Slides for Java के लिए फ़ॉन्ट्स तैनात करें: देखें कौन से फ़ॉन्ट्स प्रतिस्थापित होते हैं, Debian, Ubuntu और Alpine पर फ़ॉन्ट पैकेज इंस्टॉल करें, अपने स्वयं के फ़ॉन्ट फ़ाइलें जोड़ें, और डिफ़ॉल्ट फ़ॉन्ट सेट करें।"
---
## **समीक्षा**

Aspose.Slides प्रस्तुति को रेंडर करते समय उपलब्ध फ़ॉन्ट्स के साथ टेक्स्ट ड्रॉ करता है, उदाहरण के लिए जब यह स्लाइड्स को PDF या छवियों में बदलता है। एक Windows डेस्कटॉप आमतौर पर उन फ़ॉन्ट्स को रखता है जो प्रस्तुतियों में उपयोग होते हैं। Linux सर्वर और कंटेनर में आमतौर पर फ़ॉन्ट्स कम होते हैं, इसलिए Aspose.Slides टेक्स्ट को एक प्रतिस्थापन फ़ॉन्ट से ड्रॉ करता है। एक प्रतिस्थापन फ़ॉन्ट में अक्षरों के आकार और चौड़ाई अलग होती है, इसलिए पंक्तियों का रैप अलग हो सकता है और टेक्स्ट अपने आकार से बाहर निकल सकता है, तथा उन अक्षरों को सही तरह से नहीं दिखाया जाता जो प्रतिस्थापन फ़ॉन्ट में नहीं होते। यदि बिल्कुल भी फ़ॉन्ट इंस्टॉल नहीं है, तो Java की फ़ॉन्ट सपोर्ट शुरू नहीं हो पाती, और Aspose.Slides त्रुटि के साथ रुक जाता है।

यह लेख दिखाता है कि कैसे जांचें कि Aspose.Slides कौन से फ़ॉन्ट्स को प्रतिस्थापित करता है, Debian, Ubuntu और Alpine Linux पर फ़ॉन्ट्स कैसे स्थापित करें, अपने स्वयं के फ़ॉन्ट फ़ाइलें कैसे जोड़ें, और फ़ॉन्ट अनुपलब्ध होने पर कौन सा फ़ॉन्ट उपयोग किया जाए। उदाहरण Docker पर आधिकारिक Eclipse Temurin इमेजेज़ पर चलते हैं, जैसे कि [Run Aspose.Slides for Java in Docker](/slides/hi/java/how-to-run-aspose-slides-in-docker/) में। पैकेज कमांड्स Dockerfile निर्देश हैं; Linux सर्वर पर, वही कमांड्स रूट के रूप में चलाएँ।

फ़ॉन्ट API के बारे में, जैसे कि प्रस्तुति में फ़ॉन्ट एम्बेड करना और फ़ॉलबैक व प्रतिस्थापन नियम, देखें [PowerPoint Fonts](/slides/hi/java/powerpoint-fonts/)।

## **जाँचें कौन से फ़ॉन्ट्स प्रतिस्थापित होते हैं**

निम्नलिखित Maven प्रोजेक्ट वर्तमान वातावरण में Aspose.Slides द्वारा प्रतिस्थापित फ़ॉन्ट्स की रिपोर्ट करता है। *font-check* नाम का फ़ोल्डर बनाएं और नीचे दी गई फ़ाइलें इसमें जोड़ें।

*pom.xml* वह है जो [Run Aspose.Slides for Java in Docker](/slides/hi/java/how-to-run-aspose-slides-in-docker/#create-the-project) से है, जिसमें artifact ID और JAR फ़ाइल नाम को *font-check* में बदल दिया गया है:

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

*src/main/java/FontCheck.java* प्रत्येक फ़ॉन्ट नाम के लिए एक टेक्स्ट बॉक्स स्लाइड में जोड़ता है और फ़ॉन्ट को [setLatinFont](https://reference.aspose.com/slides/hi/java/com.aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-) मेथड से असाइन करता है। फ़ॉन्ट नाम कमांड लाइन से आते हैं; बिना आर्ग्यूमेंट्स के, प्रोग्राम Calibri, Arial, और Times New Roman की जाँच करता है। यह उन फ़ोल्डरों को प्रिंट करता है जहाँ Aspose.Slides फ़ॉन्ट्स खोजता है ([FontsLoader.getFontFolders](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsloader/#getFontFolders--)), स्लाइड को *output/fonts.pdf* में रेंडर करता है, और [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) द्वारा रिपोर्ट किए गए प्रतिस्थापन प्रिंट करता है। प्रारंभ में दो वैकल्पिक चरण, एक *fonts* फ़ोल्डर लोड करना और `DEFAULT_FONT` वेरिएबल पढ़ना, इस लेख में बाद में समझाए गए हैं।

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
        // जाँचने के लिए फ़ॉन्ट्स: कमांड‑लाइन तर्क, या तीन सामान्य Office फ़ॉन्ट्स।
        String[] fontNames = args.length > 0 ? args : new String[] { "Calibri", "Arial", "Times New Roman" };

        // यदि मौजूद हो, तो कार्य निर्देशिका में स्थित fonts फ़ोल्डर से फ़ॉन्ट फ़ाइलें लोड करें।
        File appFontFolder = new File("fonts");
        if (appFontFolder.isDirectory()) {
            FontsLoader.loadExternalFonts(new String[] { appFontFolder.getAbsolutePath() });
        }

        // यदि सेट हो, तो DEFAULT_FONT पर्यावरण चर में निर्दिष्ट फ़ॉन्ट का उपयोग उन टेक्स्ट के लिए करें जिनका फ़ॉन्ट अनुपलब्ध है।
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

`getFontFolders` एक फ़ोल्डर को एक से अधिक बार लौटा सकता है, इसलिए प्रोग्राम प्रिंट करने से पहले फ़ोल्डरों को एक सेट में इकट्ठा करता है।

*.dockerignore* स्थानीय बिल्ड परिणामों को बिल्ड कॉन्टेक्स्ट से बाहर रखता है:

```text
target/
output/
```

*Dockerfile* Maven इमेज के साथ प्रोग्राम बनाता है और इसे Eclipse Temurin Java रनटाइम इमेज पर चलाता है, जिसमें पहले से ही fontconfig और DejaVu फ़ॉन्ट्स मौजूद हैं। [Run Aspose.Slides for Java in Docker](/slides/hi/java/how-to-run-aspose-slides-in-docker/) प्रत्येक निर्देश को समझाता है।

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

इमेज बनाकर जाँच चलाएँ:

```bash
docker build -t font-check .
docker run --rm font-check
```

इमेज में केवल DejaVu फ़ॉन्ट्स हैं, इसलिए सभी तीन फ़ॉन्ट्स DejaVu Sans से प्रतिस्थापित हो जाते हैं:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

अपने प्रस्तुतियों के फ़ॉन्ट्स की जाँच करने के लिए, उनके नाम आर्ग्यूमेंट्स के रूप में पास करें, उदाहरण के लिए `docker run --rm font-check "Segoe UI" Consolas`। कंटेनर से *output/fonts.pdf* को कॉपी करने के लिए, [Copy the Output to Your Machine](/slides/hi/java/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine) में दिए गए कमांड्स का उपयोग करें।

## **Debian और Ubuntu पर फ़ॉन्ट्स इंस्टॉल करें**

### **Microsoft कोर फ़ॉन्ट्स**

`ttf-mscorefonts-installer` पैकेज वेब के लिए Microsoft के कोर फ़ॉन्ट्स को डाउनलोड और इंस्टॉल करता है, जिनमें Arial, Times New Roman, Courier New, Verdana, Georgia, और Trebuchet MS शामिल हैं। फ़ॉन्ट्स Microsoft की एंड-यूज़र लाइसेंस एग्रीमेंट (EULA) के तहत लाइसेंसिड हैं, और पैकेज केवल EULA स्वीकृत होने के बाद ही उन्हें इंस्टॉल करता है। Docker बिल्ड प्रॉम्प्ट का उत्तर नहीं दे सकता, इसलिए इंस्टॉलर EULA को अस्वीकार करता है और कोई फ़ॉन्ट इंस्टॉल नहीं करता, जबकि `apt-get install` अभी भी सफलता रिपोर्ट करता है। `debconf-set-selections` के साथ EULA को पैकेज इंस्टॉल होने **से पहले** स्वीकार करें। बाद के निर्देश में इसे स्वीकार करना मदद नहीं करता: पैकेज तब पहले ही इंस्टॉल हो चुका होता है, और apt फिर से उसका इंस्टॉलर नहीं चलता।

इस निर्देश को *Dockerfile* के रनटाइम स्टेज में, उसके `FROM` लाइन के ठीक बाद जोड़ें, ताकि यह root के रूप में चले, `USER` निर्देश से पहले:

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

इमेज बनाकर दो कमांड्स के साथ फिर से जाँच चलाएँ। अब Arial और Times New Roman इंस्टॉल हो गए हैं:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

Calibri, वह डिफ़ॉल्ट फ़ॉन्ट जो Aspose.Slides बनाता है, कोर फ़ॉन्ट्स में नहीं है, इसलिए यह अभी भी प्रतिस्थापित रहता है। देखें [Set a Default Font for Missing Fonts](#set-a-default-font-for-missing-fonts)।

Ubuntu-आधारित Eclipse Temurin इमेजेज़ `multiverse` को सक्षम करती हैं, जो Ubuntu का वह घटक है जिसमें पैकेज है। Debian पर, पैकेज `contrib` घटक में है, जिसे Debian इमेजेज़ सक्षम नहीं करतीं। Debian-आधारित रनटाइम स्टेज में, जैसे कि [Use Another Base Image](/slides/hi/java/how-to-run-aspose-slides-in-docker/#use-another-base-image) में, उसी निर्देश में `contrib` को सक्षम करें:

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

### **अन्य फ़ॉन्ट पैकेज**

Debian और Ubuntu भी स्वतंत्र लाइसेंस वाले फ़ॉन्ट्स को पैकेज करते हैं, उदाहरण के लिए:

| पैकेज | फ़ॉन्ट्स |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans, DejaVu Serif, DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans, Serif, and Mono, with the same metrics as Arial, Times New Roman, and Courier New |
| `fonts-crosextra-carlito` | Carlito, with the same metrics as Calibri |
| `fonts-crosextra-caladea` | Caladea, with the same metrics as Cambria |

`apt-get install` के साथ उन्हें रनटाइम स्टेज की `RUN` निर्देश में इंस्टॉल करें, Microsoft कोर फ़ॉन्ट्स की तरह ही। Aspose.Slides for Java Linux फ़ॉन्ट कॉन्फ़िगरेशन के फ़ॉन्ट एलियास लागू नहीं करता: `fonts-liberation` इंस्टॉल होने पर भी, Arial में टेक्स्ट सामान्य प्रतिस्थापन फ़ॉन्ट से ड्रॉ होता है, Liberation Sans से नहीं। कोई अनुपलब्ध फ़ॉन्ट के स्थान पर मेट्रिक-समतुल्य फ़ॉन्ट उपयोग करने के लिए, उसे [default font](#set-a-default-font-for-missing-fonts) सेट करें या एक [font substitution rule](/slides/hi/java/font-substitution/) जोड़ें।

## **अपने स्वयं के फ़ॉन्ट फ़ाइलें जोड़ें**

वितरण द्वारा पैकेज न किए गए फ़ॉन्ट्स, जैसे कि आपके संगठन के फ़ॉन्ट्स या अन्य फ़ॉन्ट्स जिनके उपयोग का लाइसेंस आपके पास है, फ़ॉन्ट फ़ाइलों के रूप में जोड़े जा सकते हैं। फ़ॉन्ट फ़ाइलें, उदाहरण के लिए *.ttf* फ़ाइलें, *font-check* फ़ोल्डर के भीतर *fonts* नामक फ़ोल्डर में रखें। नीचे के उदाहरण Carlito फ़ाइलों का उपयोग करते हैं, जो Calibri के समान मेट्रिक्स वाला फ़ॉन्ट है, जिसे आप [Google Fonts](https://fonts.google.com/specimen/Carlito) से डाउनलोड कर सकते हैं।

### **सिस्टम फ़ॉन्ट फ़ोल्डर में फ़ॉन्ट्स इंस्टॉल करें**

Aspose.Slides `Font folders` लाइन में प्रिंट हुए फ़ोल्डरों से फ़ॉन्ट पढ़ता है। इमेज में प्रत्येक एप्लिकेशन के लिए अपने फ़ॉन्ट्स इंस्टॉल करने हेतु, उन्हें */usr/local/share/fonts* में कॉपी करें, जो स्थानीय रूप से इंस्टॉल किए गए फ़ॉन्ट्स का फ़ोल्डर है। इस निर्देश को *Dockerfile* के रनटाइम स्टेज में माइक्रोसॉफ्ट कोर फ़ॉन्ट्स इंस्टॉल करने वाले `RUN` निर्देश के बाद जोड़ें:

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

इमेज को पुनः बनाएँ, फिर Calibri और Carlito की जाँच करें:

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

Carlito अब प्रतिस्थापित नहीं है:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

### **एप्लिकेशन फ़ोल्डर से फ़ॉन्ट लोड करें**

सिस्टम फ़ोल्डर में फ़ॉन्ट्स इंस्टॉल करने के बजाय, आप उन्हें एप्लिकेशन के साथ शिप कर सकते हैं और [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) के द्वारा लोड कर सकते हैं। फ़ॉन्ट्स केवल Aspose.Slides के लिए उपलब्ध होते हैं, और वे एप्लिकेशन के साथ डिप्लॉय होते हैं। *FontCheck* यही करता है: जब कंटेनर में उसका वर्किंग डायरेक्टरी */app* में *fonts* फ़ोल्डर मौजूद होता है, प्रोग्राम प्रस्तुति बनाने से पहले उस फ़ोल्डर को `loadExternalFonts` को पास करता है। [Custom Font](/slides/hi/java/custom-font/) मेमोरी से लोड करने जैसे फ़ॉन्ट्स प्रदान करने के अन्य तरीकों को वर्णन करता है।

*Dockerfile* में, `COPY fonts/ /usr/local/share/fonts/` निर्देश को हटाएँ और *lib* फ़ोल्डर कॉपी करने वाले निर्देश के बाद यह नई निर्देश जोड़ें:

```dockerfile
COPY fonts/ ./fonts/
```

इमेज को पुनः बनाएँ और दो कमांड्स के साथ जाँच चलाएँ। एप्लिकेशन फ़ोल्डर अब फ़ॉन्ट फ़ोल्डरों में दिखता है, और Carlito अभी भी प्रतिस्थापित नहीं है:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

`loadExternalFonts` इंस्टॉल किए गए फ़ॉन्ट्स में फ़ॉन्ट्स जोड़ता है, लेकिन Java की फ़ॉन्ट सपोर्ट को अभी भी कम से कम एक इंस्टॉल फ़ॉन्ट की ज़रूरत होती है। यदि इमेज में कोई फ़ॉन्ट नहीं है, तो `loadExternalFonts` त्रुटि "Fontconfig head is null, check your fonts or fonts configuration" के साथ रुक जाता है।

## **ग़ायब फ़ॉन्ट्स के लिए डिफ़ॉल्ट फ़ॉन्ट सेट करें**

जब कोई फ़ॉन्ट गायब होता है, तो Aspose.Slides खुद एक प्रतिस्थापन फ़ॉन्ट चुनता है। इसे खुद चुनने के लिए, [LoadOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/) की [setDefaultRegularFont](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/#setDefaultRegularFont-java.lang.String-) मेथड को फ़ॉन्ट नाम पास करें और विकल्पों को [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) कन्स्ट्रक्टर को पास करें। *FontCheck* `DEFAULT_FONT` पर्यावरण वैरिएबल से फ़ॉन्ट नाम पढ़ता है। Carlito लोड होने पर, इसे ग़ायब फ़ॉन्ट्स के लिए उपयोग करें:

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

Calibri अब Carlito से ड्रॉ होता है, जिसकी अक्षर चौड़ाई Calibri के समान है, इसलिए टेक्स्ट अपनी पंक्ति विभाजन बरकरार रखता है:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Carlito
```

डिफ़ॉल्ट फ़ॉन्ट प्रत्येक गायब फ़ॉन्ट को प्रतिस्थापित करता है। व्यक्तिगत फ़ॉन्ट्स को मैप करने के लिए, उदाहरण के लिए Arial को Liberation Sans और Calibri को Carlito, [font substitution rules](/slides/hi/java/font-substitution/) का उपयोग करें। नियम रेंडर आउटपुट बदलते हैं, लेकिन `getSubstitutions` उन्हें प्रतिबिंबित नहीं करता, इसलिए फ़ॉन्ट्स को आउटपुट फ़ाइल में देखें। एशियाई टेक्स्ट के लिए, [setDefaultAsianFont](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/#setDefaultAsianFont-java.lang.String-) भी कॉल करें; देखें [Default Font](/slides/hi/java/default-font/)।

## **Alpine Linux पर फ़ॉन्ट्स इंस्टॉल करें**

Alpine-आधारित Eclipse Temurin इमेज में भी DejaVu फ़ॉन्ट्स होते हैं; [Run on Alpine Linux](/slides/hi/java/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) उसके रनटाइम स्टेज को वर्णन करता है। उस पर भी Microsoft कोर फ़ॉन्ट्स इंस्टॉल करने के लिए, *font-check* Dockerfile के रनटाइम स्टेज को इस से बदलें:

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

`update-ms-fonts` Debian और Ubuntu पैकेज की तरह वही Microsoft कोर फ़ॉन्ट्स डाउनलोड और इंस्टॉल करता है, और उनका EULA उसी तरह लागू होता है। `fc-cache` fontconfig की फ़ॉन्ट कैश को अपडेट करता है। इमेज बनाकर [Check Which Fonts Are Substituted](#check-which-fonts-are-substituted) से दो कमांड्स चलाएँ। यह प्रिंट करता है:

```text
Font folders: /usr/share/fonts, /home/app/.local/share/fonts, /home/app/.fonts
Font substitutions:
  Calibri -> Arial
```

इस पृष्ठ के अन्य चरण Alpine पर भी उसी तरह काम करते हैं: *fonts* फ़ोल्डर को */usr/local/share/fonts* या एप्लिकेशन फ़ोल्डर में कॉपी करें, और डिफ़ॉल्ट फ़ॉन्ट चुनने के लिए `DEFAULT_FONT` सेट करें। Alpine इमेज में */usr/local/share/fonts* फ़ोल्डर नहीं है, इसलिए वह फ़ोल्डर `Font folders` लाइन में केवल तब दिखाई देता है जब `COPY` निर्देश उसे बनाता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्यों सर्वर पर प्रस्तुति को परिवर्तित करने पर उसका रूप अलग दिखता है?**

सर्वर के पास वह फ़ॉन्ट नहीं है जो प्रस्तुति उपयोग करती है, इसलिए Aspose.Slides टेक्स्ट को ऐसे प्रतिस्थापन फ़ॉन्ट से ड्रॉ करता है जिसकी अक्षर चौड़ाई अलग होती है। कौन से फ़ॉन्ट्स प्रतिस्थापित हो रहे हैं यह देखने के लिए *FontCheck* को प्रस्तुति के फ़ॉन्ट नामों के साथ चलाएँ, फिर उन फ़ॉन्ट्स को इंस्टॉल करें या एप्लिकेशन फ़ोल्डर से लोड करें।

**बिल्ड ने ttf-mscorefonts-installer इंस्टॉल किया, लेकिन Arial अभी भी प्रतिस्थापित है। क्यों?**

पैकेज इंस्टॉल होने से पहले EULA स्वीकार नहीं किया गया, इसलिए इंस्टॉलर ने फ़ॉन्ट्स को छोड़ दिया। जैसा कि [Microsoft Core Fonts](#microsoft-core-fonts) में दिखाया गया है, `debconf-set-selections` कमांड को `apt-get install` से पहले उस निर्देश में रखें जो पैकेज इंस्टॉल करता है, और इमेज को पुनः बनाएँ।

**क्या PDF खोलने वाले कंप्यूटर को फ़ॉन्ट्स की आवश्यकता होती है?**

नहीं। इन उदाहरणों में PDF में वही फ़ॉन्ट्स होते हैं जो टेक्स्ट को ड्रॉ करने के लिए उपयोग किए गए थे, इसलिए यह किसी भी कंप्यूटर पर एक जैसा दिखता है। फ़ॉन्ट्स केवल उस जगह चाहिए जहाँ Aspose.Slides प्रस्तुति रेंडर करता है।