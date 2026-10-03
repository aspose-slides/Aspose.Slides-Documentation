---
title: Docker में Aspose.Slides for Java चलाएँ
linktitle: Docker
type: docs
weight: 150
url: /hi/java/how-to-run-aspose-slides-in-docker/
keywords:
- Docker
- Dockerfile
- Docker कंटेनर
- मल्टी‑स्टेज बिल्ड
- कंटेनर इमेज
- Eclipse Temurin
- Maven
- Linux
- Ubuntu
- Alpine
- Debian
- fontconfig
- फ़ॉन्ट्स
- PDF रूपांतरण
- PowerPoint
- प्रेज़ेंटेशन
- Java
- Aspose.Slides
description: "Docker में Aspose.Slides for Java एप्लिकेशन बनाएं और चलाएँ: आधिकारिक Maven और Eclipse Temurin इमेज़ पर मल्टी‑स्टेज Dockerfile, Aspose.Slides को आवश्यक Linux लाइब्रेरीज़ और फ़ॉन्ट्स, और उत्पन्न फ़ाइलों को आपके मशीन पर कॉपी करने का तरीका।"
---
## **अवलोकन**

यह लेख दिखाता है कि Aspose.Slides for Java को Docker कंटेनर में कैसे चलाया जाए। आप एक छोटा Maven प्रोजेक्ट बनाते हैं जो एक टेक्स्ट बॉक्स वाले प्रेज़ेंटेशन को बनाता है और उसे PDF में बदलता है, इसे आधिकारिक Maven और Eclipse Temurin इमेज़ पर मल्टी‑स्टेज Dockerfile के साथ पैकेज करता है, चलाता है, और उत्पन्न फ़ाइलों को अपने मशीन पर कॉपी करता है। लेख यह भी समझाता है कि Linux इमेज में Java के अलावा Aspose.Slides को क्या चाहिए, और Alpine Linux तथा उन इमेज़ के लिए वैरिएंट्स के साथ समाप्त होता है जो डिस्ट्रिब्यूशन के पैकेजों से Java स्थापित करते हैं।

आपको अपने मशीन पर केवल Docker चाहिए। JDK और Maven बिल्ड इमेज का हिस्सा हैं, इसलिए आपको उन्हें स्थापित करने की आवश्यकता नहीं है। Docker स्थापित करने के लिए, देखें [Docker प्राप्त करें](https://docs.docker.com/get-started/get-docker/)।

## **बेस इमेज चुनें**

इस लेख की Dockerfile Docker Hub से दो आधिकारिक इमेजेज़ उपयोग करती है:

- [maven](https://hub.docker.com/_/maven) टैग `3.9-eclipse-temurin-21` के साथ एप्लिकेशन बनाता है। इसमें Apache Maven 3.9 और Eclipse Temurin JDK 21 शामिल है।
- [eclipse-temurin](https://hub.docker.com/_/eclipse-temurin) टैग `21-jre` के साथ इसे चलाता है। इसमें Ubuntu पर Eclipse Temurin Java 21 रंटाइम शामिल है, लेकिन JDK और Maven नहीं है।

Aspose.Slides for Java टेक्स्ट को Java के फ़ॉन्ट समर्थन से ड्रॉ करता है, जो Linux पर fontconfig और FreeType लाइब्रेरी तथा कम से कम एक स्थापित फ़ॉन्ट की आवश्यकता रखता है। Eclipse Temurin इमेजेज़ पहले से ही fontconfig, FreeType, और DejaVu फ़ॉन्ट्स शामिल करती हैं, इसलिए इस लेख की Dockerfile कोई पैकेज स्थापित नहीं करती। अगर किसी इमेज में कोई फ़ॉन्ट नहीं है, तो प्रेज़ेंटेशन को सहेजना "Fontconfig head is null, check your fonts or fonts configuration" त्रुटि के साथ रुक जाता है। यदि आप किसी अन्य बेस इमेज पर बनाते हैं, तो देखें [एक अन्य बेस इमेज का उपयोग करें](#use-another-base-image)।

## **प्रोजेक्ट बनाएं**

एक फ़ोल्डर *hello-slides-docker* बनाएं और उसमें निम्नलिखित फ़ाइलें जोड़ें।

*pom.xml* Aspose के Maven रिपॉज़िटरी और Aspose.Slides for Java निर्भरता को घोषित करता है, जैसा कि [स्थापना](/slides/hi/java/installation/) में वर्णित है; Aspose.Slides for Java Maven Central में प्रकाशित नहीं है, इसलिए रिपॉज़िटरी प्रविष्टि आवश्यक है। `finalName` तत्व एप्लिकेशन JAR फ़ाइल *hello‑slides.jar* का नाम रखता है, और [maven-dependency-plugin](https://maven.apache.org/plugins/maven-dependency-plugin/) Maven जब पैकेज करता है तो एप्लिकेशन की निर्भरताओं को *target/lib* में कॉपी करता है। Aspose.Slides का संस्करण सबसे नवीनतम संस्करण पर सेट करें जो [रिपॉज़िटरी](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) में सूचीबद्ध है।

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

*src/main/java/HelloSlides.java* एक [प्रेज़ेंटेशन](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) बनाता है, पहली स्लाइड में टेक्स्ट के साथ एक आयत जोड़ता है, और प्रेज़ेंटेशन को दो बार [save](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#save-java.lang.String-int-) मेथड से सहेजता है: PPTX और PDF के रूप में। दोनों फ़ाइलें कार्य निर्देशिका के नीचे *output* फ़ोल्डर में जाती हैं। फिर प्रोग्राम उन फ़ॉन्ट्स की सूची देता है जिन्हें Aspose.Slides रेंडर करते समय बदलता है, [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) का उपयोग करके, ताकि आप देख सकें कि कंटेनर में प्रेज़ेंटेशन द्वारा उपयोग किए गए फ़ॉन्ट मौजूद हैं या नहीं।

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

*.dockerignore* स्थानीय बिल्ड के *target* फ़ोल्डर और पूर्व रन के आउटपुट को Docker बिल्ड कॉन्टेक्स्ट से बाहर रखता है, जिससे इमेज केवल स्रोत फ़ाइलों से निर्मित होती है।

```text
target/
output/
```

## **Dockerfile लिखें**

फ़ोल्डर *hello-slides-docker* में *Dockerfile* नाम की फ़ाइल जोड़ें:

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

फ़ाइल दो चरणों में विभाजित है:

- **बिल्ड चरण** Maven इमेज से शुरू होता है। यह पहले *pom.xml* को कॉपी करता है और `mvn dependency:go-offline` चलाता है, जो Aspose.Slides for Java और Maven प्लगइन्स को डाउनलोड करता है, इसलिए Docker उस लेयर को पुनः उपयोग करता है जब तक *pom.xml* नहीं बदलता। फिर यह स्रोत कोड कॉपी करता है और `mvn package` चलाता है, जो प्रोग्राम को *target/hello-slides.jar* में कम्पाइल करता है और Aspose.Slides JAR फ़ाइल को *target/lib* में कॉपी करता है। `-B` विकल्प Maven को नॉन‑इंटरैक्टिव (बैच) मोड में चलाता है।
- **रनटाइम चरण** छोटे Java रनटाइम इमेज से शुरू होता है और केवल एप्लिकेशन JAR फ़ाइल और *lib* फ़ोल्डर को कॉपी करता है। यह *output* फ़ोल्डर बनाता है, इसे `ubuntu` को देता है, जो Ubuntu‑आधारित इमेज द्वारा परिभाषित नॉन‑रूट उपयोगकर्ता है, और एप्लिकेशन को उसी उपयोगकर्ता के रूप में चलाता है। क्लास पाथ `hello-slides.jar:lib/*` में एप्लिकेशन और *lib* में सभी JAR फ़ाइलें शामिल हैं; Java स्वयं `*` का विस्तार करता है।

प्रोजेक्ट Java 11 के लिए कम्पाइल किया गया है (`maven.compiler.release` प्रॉपर्टी), इसलिए रनटाइम चरण एक नया Java संस्करण उपयोग कर सकता है। उदाहरण के लिए, एप्लिकेशन को Java 25 पर चलाने के लिए, रनटाइम चरण की इमेज को `eclipse-temurin:25-jre` में बदलें।

## **कंटेनर बनाएं और चलाएँ**

*hello-slides-docker* फ़ोल्डर में एक टर्मिनल खोलें। इमेज बनाएं, फिर उससे एक कंटेनर चलाएँ:

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

पहला बिल्ड बेस इमेजेज़, Maven प्लगइन्स, और Aspose.Slides for Java को डाउनलोड करता है, इसलिए इसमें कई मिनट लगते हैं; बाद के बिल्ड उन्हें पुनः उपयोग करते हैं। कंटेनर एप्लिकेशन चलाता है और रुक जाता है। यह प्रिंट करता है:

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

पहली पंक्ति दर्शाती है कि टेक्स्ट एक नई प्रेज़ेंटेशन के डिफ़ॉल्ट फ़ॉन्ट Calibri का उपयोग कर रहा है, और Calibri इमेज में स्थापित नहीं है, इसलिए Aspose.Slides ने टेक्स्ट को DejaVu Sans से ड्रॉ किया है। PDF में टेक्स्ट वास्तविक, चयन योग्य टेक्स्ट है उस फ़ॉन्ट में। बिना लाइसेंस के, Aspose.Slides प्रत्येक स्लाइड पर एक मूल्यांकन वॉटरमार्क भी जोड़ता है जिसे वह सहेजता है; देखें [लाइसेंसिंग](/slides/hi/java/licensing/)।

## **आउटपुट को अपने मशीन पर कॉपी करें**

फ़ाइलें बंद किए गए कंटेनर के */app/output* फ़ोल्डर में हैं। उन्हें अपने मशीन पर एक *output* फ़ोल्डर में कॉपी करें, फिर कंटेनर को हटा दें:

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

ये दो कमांड Bash, PowerShell, और Windows Command Prompt में समान रूप से काम करते हैं।

Linux पर, आप अपने मशीन के किसी फ़ोल्डर को कंटेनर में माउंट कर सकते हैं, ताकि एप्लिकेशन सीधे उस फ़ोल्डर में फ़ाइलें लिखे:

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

`--user` विकल्प एप्लिकेशन को आपके उपयोगकर्ता और समूह IDs के साथ चलाता है, इसलिए यह आपके द्वारा बनाए गए फ़ोल्डर में लिख सकता है और फ़ाइलें आपका स्वामित्व रखती हैं। `--rm` कंटेनर को जब वह रुकता है तो हटा देता है।

## **Alpine Linux पर चलाएँ**

Eclipse Temurin Alpine Linux पर आधारित इमेज के रूप में भी उपलब्ध है, जो छोटा है। इसमें fontconfig, FreeType, और DejaVu फ़ॉन्ट्स भी शामिल हैं, इसलिए एप्लिकेशन को यहाँ अतिरिक्त पैकेजों की आवश्यकता नहीं है। इसे उपयोग करने के लिए, *Dockerfile* में रनटाइम चरण (दूसरी `FROM` पंक्ति से लेकर अंत तक) को इससे बदलें:

```dockerfile
FROM eclipse-temurin:21-jre-alpine
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN adduser -D app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

Alpine इमेज में `ubuntu` उपयोगकर्ता नहीं है, इसलिए यह चरण `adduser` द्वारा `app` नाम का उपयोगकर्ता बनाता है और एप्लिकेशन को उसी उपयोगकर्ता के रूप में चलाता है। ऊपर दिए गए समान कमांड्स के साथ बनाएं, चलाएं, और आउटपुट कॉपी करें। एप्लिकेशन वही दो पंक्तियाँ प्रिंट करेगा।

## **एक अन्य बेस इमेज का उपयोग करें**

यदि आपका इमेज Linux वितरण के पैकेजों से Java स्थापित करता है, तो Java के फ़ॉन्ट लाइब्रेरी और एक फ़ॉन्ट भी स्थापित करें। Debian और Ubuntu पर, `openjdk-21-jre-headless` पैकेज केवल fontconfig, FreeType, और HarfBuzz को सिफ़ारिशी पैकेज के रूप में सूचीबद्ध करता है, इसलिए `apt-get install --no-install-recommends` उन्हें बाहर रख देता है, और एप्लिकेशन `libfontmanager.so` के लिए `UnsatisfiedLinkError` के साथ रुक जाता है। यह रनटाइम चरण Debian 13 पर Java 21, लाइब्रेरीज़, और DejaVu फ़ॉन्ट्स स्थापित करता है, और `app` नाम का नॉन‑रूट उपयोगकर्ता बनाता है:

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

इसी चरण को `FROM ubuntu:26.04` के साथ Ubuntu 26.04 पर भी उपयोग किया जा सकता है।

## **बार‑बार पूछे जाने वाले प्रश्न**

**प्रेज़ेंटेशन सहेजना "Fontconfig head is null, check your fonts or fonts configuration" त्रुटि के साथ रुक जाता है। क्या गायब है?**  
एक फ़ॉन्ट। Java का फ़ॉन्ट समर्थन इमेज में कोई स्थापित फ़ॉन्ट नहीं मिला। एक फ़ॉन्ट पैकेज स्थापित करें, उदाहरण के लिए Debian और Ubuntu पर `fonts-dejavu-core`, जैसा कि [एक अन्य बेस इमेज का उपयोग करें](#use-another-base-image) में दिखाया गया है। [फ़ॉन्ट्स तैनात करें](/slides/hi/java/deploy-fonts/) अन्य फ़ॉन्ट पैकेजों की सूची देता है।

**एप्लिकेशन libfontmanager.so के लिए UnsatisfiedLinkError के साथ रुक जाता है। क्या गायब है?**  
Java के फ़ॉन्ट समर्थन की एक नेटिव लाइब्रेरी; संदेश उस फ़ाइल का नाम बताता है जिसे लोड नहीं किया जा सका, उदाहरण के लिए `libharfbuzz.so.0`। यह तब होता है जब Java वितरण के पैकेजों से स्थापित किया जाता है लेकिन उनकी सिफ़ारिशी पैकेज नहीं स्थापित होते। [एक अन्य बेस इमेज का उपयोग करें](#use-another-base-image) में सूचीबद्ध लाइब्रेरीज़ स्थापित करें।

**PDF में टेक्स्ट PowerPoint की तुलना में अलग फ़ॉन्ट में क्यों है?**  
प्रेज़ेंटेशन में उपयोग किए गए फ़ॉन्ट इमेज में स्थापित नहीं हैं, इसलिए Aspose.Slides टेक्स्ट को एक प्रतिस्थापन फ़ॉन्ट से ड्रॉ करता है। एप्लिकेशन का आउटपुट प्रत्येक बदले हुए फ़ॉन्ट का नाम देता है। [फ़ॉन्ट्स तैनात करें](/slides/hi/java/deploy-fonts/) बताता है कि इमेज में फ़ॉन्ट कैसे स्थापित करें या उन्हें एप्लिकेशन फ़ोल्डर से कैसे लोड करें।

**कंटेनर में एप्लिकेशन कितनी मेमोरी उपयोग कर सकता है?**  
डिफ़ॉल्ट रूप से, Java अपनी हीप को कंटेनर की उपलब्ध मेमोरी के एक चौथाई तक सीमित करता है, उदाहरण के लिए जब आप कंटेनर को `docker run -m 1g` से शुरू करते हैं तो लगभग 250 MB। बड़े प्रेज़ेंटेशन प्रोसेस करने के लिए, `MaxRAMPercentage` विकल्प के साथ शेयर बढ़ाएँ, उदाहरण के लिए `docker run --rm -m 1g -e JAVA_TOOL_OPTIONS=-XX:MaxRAMPercentage=75 hello-slides`। Java तब एप्लिकेशन के आउटपुट से पहले एक "Picked up JAVA_TOOL_OPTIONS" पंक्ति प्रिंट करता है।

**क्या मुझे अपने मशीन पर JDK या Maven की आवश्यकता है?**  
नहीं। बिल्ड चरण Maven इमेज के भीतर एप्लिकेशन को कम्पाइल करता है। आपको JDK और Maven तभी चाहिए जब आप Docker के बाहर भी एप्लिकेशन बनाना और चलाना चाहते हों; देखें [स्थापना](/slides/hi/java/installation/)।