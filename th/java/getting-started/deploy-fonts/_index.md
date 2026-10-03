---
title: ปรับใช้แบบอักษรสำหรับ Aspose.Slides for Java บน Linux และใน Docker
linktitle: ปรับใช้แบบอักษร
type: docs
weight: 155
url: /th/java/deploy-fonts/
keywords:
- ปรับใช้แบบอักษร
- ติดตั้งแบบอักษร
- แบบอักษรใน Docker
- แบบอักษรบน Linux
- แบบอักษรที่ขาดหาย
- การแทนที่แบบอักษร
- แบบอักษรหลักของ Microsoft
- ttf-mscorefonts-installer
- แบบอักษรกำหนดเอง
- แบบอักษรเริ่มต้น
- เซิร์ฟเวอร์
- คอนเทนเนอร์
- การแปลง PDF
- พรีเซนเทชัน
- Java
- Aspose.Slides
description: "ปรับใช้แบบอักษรสำหรับ Aspose.Slides for Java บนเซิร์ฟเวอร์ Linux และในคอนเทนเนอร์ Docker: ตรวจสอบว่าแบบอักษรใดถูกแทนที่, ติดตั้งแพ็คเกจแบบอักษรบน Debian, Ubuntu, และ Alpine, เพิ่มไฟล์แบบอักษรของคุณเอง, และตั้งค่าแบบอักษรเริ่มต้น."
---
## **ภาพรวม**

Aspose.Slides วาดข้อความด้วยแบบอักษรที่มีให้เมื่อมันเรนเดอร์พรีเซนเทชัน เช่นเมื่อแปลงสไลด์เป็น PDF หรือเป็นภาพ Windows desktop โดยปกติจะมีแบบอักษรที่พรีเซนเทชันใช้ แต่ Linux server และ container มักมีแบบอักษรน้อย ดังนั้น Aspose.Slides จะวาดข้อความด้วยแบบอักษรสำรอง (substitute) แบบอักษรสำรองมีรูปร่างและความกว้างของอักขระที่แตกต่างกัน ทำให้บรรทัดอาจแตกบรรทัดใหม่ต่างกัน ข้อความอาจล้นออกจากรูปทรงของมัน และอักขระที่แบบอักษรสำรองไม่มีจะไม่ถูกวาดอย่างถูกต้อง หากไม่มีแบบอักษรติดตั้งเลย การสนับสนุนแบบอักษรของ Java จะไม่สามารถเริ่มทำงานได้ และ Aspose.Slides จะหยุดทำงานพร้อมข้อผิดพลาด

บทความนี้จะแสดงวิธีตรวจสอบว่า Aspose.Slides แทนที่แบบอักษรใดบ้าง วิธีติดตั้งแบบอักษรบน Debian, Ubuntu และ Alpine Linux วิธีเพิ่มไฟล์แบบอักษรของคุณเอง และวิธีกำหนดแบบอักษรที่จะใช้เมื่อไม่มีแบบอักษร ตัวอย่างทำงานใน Docker บนภาพ Eclipse Temurin อย่างเป็นทางการ ตามที่อธิบายใน [Run Aspose.Slides for Java in Docker](/slides/th/java/how-to-run-aspose-slides-in-docker/). คำสั่งแพ็คเกจเป็นคำสั่งของ Dockerfile; บน Linux server ให้รันคำสั่งเดียวกันด้วยสิทธิ์ root

สำหรับ API ของแบบอักษรเอง เช่น การฝังแบบอักษรในพรีเซนเทชันและกฎการสำรองและการแทนที่ ดูที่ [PowerPoint Fonts](/slides/th/java/powerpoint-fonts/)

## **ตรวจสอบว่าแบบอักษรใดถูกแทนที่**

โครงการ Maven ด้านล่างรายงานแบบอักษรที่ Aspose.Slides แทนที่ในสภาพแวดล้อมปัจจุบัน สร้างโฟลเดอร์ชื่อ *font-check* แล้วเพิ่มไฟล์ต่อไปนี้ลงไปในนั้น

*​pom.xml* เป็นไฟล์จาก [Run Aspose.Slides for Java in Docker](/slides/th/java/how-to-run-aspose-slides-in-docker/#create-the-project) โดยเปลี่ยน artifact ID และชื่อไฟล์ JAR เป็น *font-check*:

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

*src/main/java/FontCheck.java* เพิ่มกล่องข้อความหนึ่งอันต่อชื่อแบบอักษรลงในสไลด์และกำหนดแบบอักษรด้วยเมธอด [setLatinFont](https://reference.aspose.com/slides/th/java/com.aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-) ชื่อแบบอักษรมาจากบรรทัดคำสั่ง; หากไม่มีอากิวเมนต์ โปรแกรมจะตรวจสอบ Calibri, Arial และ Times New Roman มันพิมพ์โฟลเดอร์ที่ Aspose.Slides มองหาแบบอักษร ([FontsLoader.getFontFolders](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsloader/#getFontFolders--)) เรนเดอร์สไลด์เป็น *output/fonts.pdf* และพิมพ์การแทนที่ที่รายงานโดย [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifontsmanager/#getSubstitutions--). ขั้นตอนสองอย่างที่เป็นตัวเลือกที่จุดเริ่มต้น คือ การโหลดโฟลเดอร์ *fonts* และอ่านตัวแปร `DEFAULT_FONT` ซึ่งอธิบายในบทความนี้ต่อไป

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
        // แบบอักษรที่จะตรวจสอบ: อากิวเมนต์จากบรรทัดคำสั่ง หรือแบบอักษร Office ที่นิยมสามตัว
        String[] fontNames = args.length > 0 ? args : new String[] { "Calibri", "Arial", "Times New Roman" };

        // โหลดไฟล์แบบอักษรจากโฟลเดอร์ fonts ในไดเรกทอรีทำงาน หากมี
        File appFontFolder = new File("fonts");
        if (appFontFolder.isDirectory()) {
            FontsLoader.loadExternalFonts(new String[] { appFontFolder.getAbsolutePath() });
        }

        // ใช้แบบอักษรที่ระบุในตัวแปรสภาพแวดล้อม DEFAULT_FONT หากตั้งค่าไว้ สำหรับข้อความที่แบบอักษรหายไป
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

`getFontFolders` อาจคืนค่าโฟลเดอร์ซ้ำหลายครั้ง ดังนั้นโปรแกรมจะเก็บโฟลเดอร์ไว้ในชุดก่อนพิมพ์ออก

*.dockerignore* ป้องกันผลลัพธ์การสร้างที่อยู่ในเครื่องออกจาก build context:

```text
target/
output/
```

*Dockerfile* สร้างโปรแกรมด้วยภาพ Maven แล้วรันบนภาพ Eclipse Temurin Java runtime ซึ่งมี fontconfig และแบบอักษร DejaVu อยู่แล้ว [Run Aspose.Slides for Java in Docker](/slides/th/java/how-to-run-aspose-slides-in-docker/) อธิบายแต่ละคำสั่ง

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

สร้างภาพและรันการตรวจสอบ:

```bash
docker build -t font-check .
docker run --rm font-check
```

ภาพนี้มีแบบอักษร DejaVu เท่านั้น ดังนั้นแบบอักษรสามแบบจะถูกแทนที่ด้วย DejaVu Sans:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

เพื่อตรวจสอบแบบอักษรของพรีเซนเทชันของคุณเอง ให้ส่งชื่อของมันเป็นอากิวเมนต์ เช่น `docker run --rm font-check "Segoe UI" Consolas` เพื่อคัดลอก *output/fonts.pdf* จากคอนเทนเนอร์ ให้ใช้คำสั่งใน [Copy the Output to Your Machine](/slides/th/java/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine)

## **ติดตั้งแบบอักษรบน Debian และ Ubuntu**

### **Microsoft Core Fonts**

แพ็คเกจ `ttf-mscorefonts-installer` ดาวน์โหลดและติดตั้ง Microsoft core fonts สำหรับเว็บ รวมถึง Arial, Times New Roman, Courier New, Verdana, Georgia และ Trebuchet MS แบบอักษรเหล่านี้อยู่ภายใต้ข้อตกลงการอนุญาตใช้ของ Microsoft (EULA) และแพ็คเกจจะติดตั้งหลังจากที่ยอมรับ EULA ตัวติดตั้งจะปฏิเสธ EULA หากไม่ยอมรับและจะไม่ติดตั้งแบบอักษรใด ๆ แม้ `apt-get install` จะรายงานว่าติดตั้งสำเร็จ ให้ยอมรับ EULA ด้วย `debconf-set-selections` **ก่อน** ติดตั้งแพ็คเกจ การยอมรับในคำสั่งถัดไปจะไม่ช่วยอะไร เพราะแพ็คเกจจะถูกติดตั้งแล้วและ apt จะไม่เรียกตัวติดตั้งอีกครั้ง

เพิ่มคำสั่งนี้ไปยังขั้นตอน runtime ของ *Dockerfile* ทันทีหลังจากบรรทัด `FROM` เพื่อรันด้วยสิทธิ์ root ก่อนคำสั่ง `USER`:

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

สร้างภาพและรันการตรวจสอบอีกครั้งด้วยสองคำสั่งเดียวกัน 이제 Arial และ Times New Roman ถูกติดตั้งแล้ว:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

Calibri ซึ่งเป็นแบบอักษรเริ่มต้นของพรีเซนเทชันที่ Aspose.Slides สร้าง ไม่ใช่หนึ่งใน core fonts ดังนั้นมันยังคงถูกแทนที่อยู่ ดูที่ [Set a Default Font for Missing Fonts](#set-a-default-font-for-missing-fonts)

ภาพ Eclipse Temurin ที่สร้างจาก Ubuntu เปิดใช้งาน `multiverse` ซึ่งเป็นคอมโพเนนต์ของ Ubuntu ที่มีแพ็คเกจนี้ ส่วนบน Debian แพ็คเกจอยู่ในคอมโพเนนท์ `contrib` ซึ่งภาพ Debian ไม่ได้เปิดใช้งาน ในขั้นตอน runtime ที่อิง Debian เช่นใน [Use Another Base Image](/slides/th/java/how-to-run-aspose-slides-in-docker/#use-another-base-image) ให้เปิดใช้งาน `contrib` ในคำสั่งเดียวกัน:

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

### **แพ็คเกจแบบอักษรอื่น ๆ**

Debian และ Ubuntu ยังมีแพ็คเกจแบบอักษรที่ให้ใบอนุญาตฟรี ตัวอย่างเช่น

| แพคเกจ | แบบอักษร |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans, DejaVu Serif, DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans, Serif, และ Mono, มีเมตริกเดียวกับ Arial, Times New Roman, และ Courier New |
| `fonts-crosextra-carlito` | Carlito, มีเมตริกเดียวกับ Calibri |
| `fonts-crosextra-caladea` | Caladea, มีเมตริกเดียวกับ Cambria |

ติดตั้งโดยใช้ `apt-get install` ในคำสั่ง `RUN` ของขั้นตอน runtime เหมือนกับ Microsoft core fonts Aspose.Slides for Java ไม่ใช้ alias ของการกำหนดค่าแบบอักษร Linux: แม้จะติดตั้ง `fonts-liberation` แล้ว ข้อความใน Arial ยังถูกวาดด้วยแบบอักษรสำรองทั่วไป ไม่ได้เป็น Liberation Sans เพื่อใช้แบบอักษรที่มีเมตริกเข้ากันแทนที่แบบอักษรที่ขาดหาย ให้ตั้งเป็น [แบบอักษรเริ่มต้น](#set-a-default-font-for-missing-fonts) หรือเพิ่ม [กฎการแทนที่แบบอักษร](/slides/th/java/font-substitution/)

## **เพิ่มไฟล์แบบอักษรของคุณเอง**

แบบอักษรที่การแจกจ่ายไม่ได้จัดหา เช่น แบบอักษรขององค์กรหรือแบบอักษรอื่น ๆ ที่คุณมีลิขสิทธิ์ใช้บนเซิร์ฟเวอร์ สามารถเพิ่มเป็นไฟล์แบบอักษรได้ ให้วางไฟล์แบบอักษร เช่นไฟล์ *.ttf* ลงในโฟลเดอร์ชื่อ *fonts* ภายในโฟลเดอร์ *font-check* ตัวอย่างด้านล่างใช้ไฟล์ของ Carlito ซึ่งมีเมตริกเดียวกับ Calibri ซึ่งคุณสามารถดาวน์โหลดจาก [Google Fonts](https://fonts.google.com/specimen/Carlito)

### **ติดตั้งแบบอักษรในโฟลเดอร์แบบอักษรของระบบ**

Aspose.Slides อ่านแบบอักษรจากโฟลเดอร์ที่พิมพ์บนบรรทัด `Font folders` เพื่อทำให้แบบอักษรของคุณพร้อมใช้สำหรับทุกแอปพลิเคชันในภาพ ให้คัดลอกไฟล์เหล่านั้นไปยัง */usr/local/share/fonts* ซึ่งเป็นโฟลเดอร์สำหรับแบบอักษรติดตั้งในเครื่อง เพิ่มคำสั่งนี้ไปยังขั้นตอน runtime ของ *Dockerfile* หลังจากคำสั่ง `RUN` ที่ติดตั้ง Microsoft core fonts:

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

สร้างภาพใหม่ แล้วตรวจสอบ Calibri กับ Carlito:

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

Carlito จะไม่ถูกแทนที่อีกต่อไป:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

### **โหลดแบบอักษรจากโฟลเดอร์แอปพลิเคชัน**

แทนที่จะติดตั้งแบบอักษรในโฟลเดอร์ระบบ คุณสามารถส่งมาพร้อมแอปพลิเคชันและโหลดด้วย [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/th/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) แบบอักษรเหล่านี้จะใช้ได้เฉพาะกับ Aspose.Slides และจะถูกจัดจำหน่ายพร้อมแอปพลิเคชัน *FontCheck* ทำเช่นนี้: เมื่อไดเรกทอรีทำงานของมันคือ */app* ในคอนเทนเนอร์มีโฟลเดอร์ *fonts* โปรแกรมจะส่งโฟลเดอร์นั้นไปยัง `loadExternalFonts` ก่อนสร้างพรีเซนเทชัน [Custom Font](/slides/th/java/custom-font/) อธิบายวิธีอื่น ๆ เช่นการโหลดจากหน่วยความจำ

ใน *Dockerfile* ให้ลบคำสั่ง `COPY fonts/ /usr/local/share/fonts/` แล้วเพิ่มคำสั่งนี้หลังจากคำสั่งที่คัดลอกโฟลเดอร์ *lib*:

```dockerfile
COPY fonts/ ./fonts/
```

สร้างภาพใหม่และรันการตรวจสอบด้วยสองคำสั่งเดียวกัน โฟลเดอร์แอปพลิเคชันจะปรากฏในรายการโฟลเดอร์แบบอักษรและ Carlito ยังไม่ถูกแทนที่:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

`loadExternalFonts` เพิ่มแบบอักษรเข้ากับแบบอักษรที่ติดตั้งแล้ว แต่การสนับสนุนแบบอักษรของ Java ยังต้องการอย่างน้อยหนึ่งแบบอักษรที่ติดตั้งอยู่ หากภาพไม่มีแบบอักษรใดเลย `loadExternalFonts` จะหยุดด้วยข้อผิดพลาด "Fontconfig head is null, check your fonts or fonts configuration"

## **ตั้งค่าแบบอักษรเริ่มต้นสำหรับแบบอักษรที่หายไป**

เมื่อแบบอักษรหายไป Aspose.Slides จะเลือกแบบอักษรสำรองโดยอัตโนมัติ หากต้องการกำหนดเอง ให้ส่งชื่อแบบอักษรไปยังเมธอด [setDefaultRegularFont](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadoptions/#setDefaultRegularFont-java.lang.String-) ของ [LoadOptions](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadoptions/) แล้วส่ง options ไปยังคอนสตรัคเตอร์ของ [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) *FontCheck* อ่านชื่อแบบอักษรจากตัวแปรสภาพแวดล้อม `DEFAULT_FONT` เมื่อติดตั้ง Carlito แล้ว ให้ใช้มันเป็นแบบอักษรเริ่มต้นสำหรับแบบอักษรที่หายไป:

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

ตอนนี้ Calibri จะถูกวาดด้วย Carlito ซึ่งอักขระของมันมีความกว้างเท่ากับ Calibri ทำให้ข้อความคงบรรทัดเดิม:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Carlito
```

แบบอักษรเริ่มต้นจะทดแทนทุกแบบอักษรที่หายไป เพื่อแมปแบบอักษรแต่ละตัว เช่น Arial ไปที่ Liberation Sans และ Calibri ไปที่ Carlito ให้ใช้ [กฎการแทนที่แบบอักษร](/slides/th/java/font-substitution/) กฎเหล่านี้จะเปลี่ยนผลลัพธ์การเรนเดอร์ แต่ `getSubstitutions` จะไม่แสดงผลดังนั้นให้ตรวจสอบแบบอักษรในไฟล์ผลลัพธ์แทน สำหรับข้อความภาษาเอเชีย ให้เรียกใช้ [setDefaultAsianFont](https://reference.aspose.com/slides/th/java/com.aspose.slides/loadoptions/#setDefaultAsianFont-java.lang.String-) ด้วย; ดูที่ [Default Font](/slides/th/java/default-font/)

## **ติดตั้งแบบอักษรบน Alpine Linux**

ภาพ Eclipse Temurin ที่อิง Alpine ยังมีแบบอักษร DejaVu อยู่; [Run on Alpine Linux](/slides/th/java/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) อธิบายขั้นตอน runtime เพื่อให้ติดตั้ง Microsoft core fonts ด้วย ให้แทนที่ขั้นตอน runtime ของ Dockerfile *font-check* ด้วยนี้:

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

`update-ms-fonts` ดาวน์โหลดและติดตั้ง Microsoft core fonts เดียวกับแพ็คเกจใน Debian/Ubuntu และ EULA ทำงานในลักษณะเดียวกัน `fc-cache` จะอัปเดตแคชของ fontconfig สร้างภาพและรันการตรวจสอบด้วยสองคำสั่งจาก [Check Which Fonts Are Substituted](#check-which-fonts-are-substituted) จะได้ผลลัพธ์:

```text
Font folders: /usr/share/fonts, /home/app/.local/share/fonts, /home/app/.fonts
Font substitutions:
  Calibri -> Arial
```

ขั้นตอนอื่น ๆ บนหน้านี้ทำงานเช่นเดียวกันบน Alpine: คัดลอกโฟลเดอร์ *fonts* ไปยัง */usr/local/share/fonts* หรือโฟลเดอร์แอปพลิเคชัน และตั้งค่า `DEFAULT_FONT` เพื่อเลือกแบบอักษรเริ่มต้น ภาพ Alpine ไม่มีโฟลเดอร์ */usr/local/share/fonts* จึงโฟลเดอร์นี้จะปรากฏในบรรทัด `Font folders` เท่าที่มีคำสั่ง `COPY` สร้างมันขึ้นมา

## **คำถามที่พบบ่อย**

**เหตุใดพรีเซนเทชันจึงดูแตกต่างเมื่อแปลงบนเซิร์ฟเวอร์?**

เซิร์ฟเวอร์ไม่มีแบบอักษรที่พรีเซนเทชันใช้ ดังนั้น Aspose.Slides จะวาดข้อความด้วยแบบอักษรสำรองที่อักขระมีความกว้างต่างกัน ให้รัน *FontCheck* กับชื่อแบบอักษรของพรีเซนเทชันเพื่อดูว่าแบบอักษรใดถูกแทนที่ แล้วติดตั้งแบบอักษรเหล่านั้นหรือโหลดจากโฟลเดอร์แอปพลิเคชัน

**การสร้างได้ติดตั้ง ttf-mscorefonts-installer แล้ว แต่ Arial ยังถูกแทนที่ ทำไม?**

EULA ไม่ได้ถูกยอมรับก่อนติดตั้งแพ็คเกจ ดังนั้นตัวติดตั้งจึงข้ามแบบอักษรไว้ ให้วางคำสั่ง `debconf-set-selections` ก่อน `apt-get install` ในขั้นตอนที่ติดตั้งแพ็คเกจ ตามที่แสดงใน [Microsoft Core Fonts](#microsoft-core-fonts) แล้วสร้างภาพใหม่

**คอมพิวเตอร์ที่เปิด PDF ต้องมีแบบอักษรหรือไม่?**

ไม่จำเป็น ในตัวอย่างนี้ PDF จะมีแบบอักษรที่ใช้วาดข้อความอยู่แล้ว ทำให้ดูเหมือนกันบนทุกคอมพิวเตอร์ แบบอักษรจำเป็นต้องมีเฉพาะที่ Aspose.Slides เรนเดอร์พรีเซนเทชันเท่านั้น