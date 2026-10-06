---
title: "เรียกใช้ Aspose.Slides for Java ใน Docker"
linktitle: Docker
type: docs
weight: 150
url: /th/java/how-to-run-aspose-slides-in-docker/
keywords:
- Docker
- Dockerfile
- คอนเทนเนอร์ Docker
- การสร้างแบบหลายขั้นตอน
- อิมเมจคอนเทนเนอร์
- Eclipse Temurin
- Maven
- Linux
- Ubuntu
- Alpine
- Debian
- fontconfig
- ฟอนต์
- การแปลงเป็น PDF
- PowerPoint
- พรีเซนเทชัน
- Java
- Aspose.Slides
description: "สร้างและรันแอปพลิเคชัน Aspose.Slides for Java ใน Docker: Dockerfile แบบหลายขั้นตอนบนอิมเมจ Maven และ Eclipse Temurin อย่างเป็นทางการ, ไลบรารีและฟอนต์ของ Linux ที่ Aspose.Slides ต้องการ, และวิธีคัดลอกไฟล์ที่สร้างขึ้นไปยังเครื่องของคุณ."
---
## **ภาพรวม**

บทความนี้แสดงวิธีการเรียกใช้ Aspose.Slides for Java ในคอนเทนเนอร์ Docker คุณจะสร้างโปรเจกต์ Maven ขนาดเล็กที่สร้างงานพรีเซนเทชันพร้อมกล่องข้อความและแปลงเป็น PDF แพ็กเกจด้วย Dockerfile แบบหลายขั้นตอนบนอิมเมจ Maven และ Eclipse Temurin อย่างเป็นทางการ จากนั้นรันและคัดลอกไฟล์ที่สร้างขึ้นไปยังเครื่องของคุณ บทความยังอธิบายว่า Aspose.Slides ต้องการอะไรในอิมเมจ Linux นอกเหนือจาก Java และสรุปด้วยตัวแปรสำหรับ Alpine Linux และอิมเมจที่ติดตั้ง Java จากแพ็กเกจของดิสทริบิวชัน

คุณต้องมี Docker เพียงอย่างเดียวบนเครื่องของคุณ JDK และ Maven อยู่ในอิมเมจการสร้างแล้วจึงไม่จำเป็นต้องติดตั้งเพิ่มเติม เพื่อทำการติดตั้ง Docker ดูที่ [Get Docker](https://docs.docker.com/get-started/get-docker/)

## **เลือกอิมเมจฐาน**

Dockerfile ในบทความนี้ใช้สองอิมเมจอย่างเป็นทางการจาก Docker Hub:

- [maven](https://hub.docker.com/_/maven) ที่แท็ก `3.9-eclipse-temurin-21` ใช้สำหรับสร้างแอปพลิเคชัน มี Apache Maven 3.9 และ Eclipse Temurin JDK 21
- [eclipse-temurin](https://hub.docker.com/_/eclipse-temurin) ที่แท็ก `21-jre` ใช้สำหรับรันแอปพลิเคชัน มี Eclipse Temurin Java 21 runtime บน Ubuntu โดยไม่มี JDK และ Maven

Aspose.Slides for Java วาดข้อความด้วยการสนับสนุนฟอนต์ของ Java ซึ่งบน Linux ต้องการไลบรารี fontconfig และ FreeType และต้องมีฟอนต์ติดตั้งอย่างน้อยหนึ่งรูปแบบ ภาพ Eclipse Temurin มี fontconfig, FreeType และฟอนต์ DejaVu อยู่แล้ว ดังนั้น Dockerfile ในบทความนี้จึงไม่ติดตั้งแพ็กเกจเพิ่มเติม หากอิมเมจไม่มีฟอนต์ใด ๆ การบันทึกพรีเซนเทชันจะหยุดด้วยข้อผิดพลาด “Fontconfig head is null, check your fonts or fonts configuration” หากคุณใช้ฐานอิมเมจอื่น ให้ดูที่ [Use Another Base Image](#use-another-base-image)

## **สร้างโปรเจกต์**

สร้างโฟลเดอร์ชื่อ *hello-slides-docker* แล้วเพิ่มไฟล์ต่อไปนี้ลงไป

*pom.xml* กำหนดรีโพสทอรี Maven ของ Aspose และการอ้างอิง Aspose.Slides for Java ตามที่อธิบายใน [Installation](/slides/th/java/installation/) ; Aspose.Slides for Java ไม่ได้เผยแพร่ใน Maven Central จึงต้องระบุรีโพสทอรีนี้ `finalName` กำหนดชื่อไฟล์ JAR ของแอปพลิเคชันเป็น *hello-slides.jar* และ [maven-dependency-plugin](https://maven.apache.org/plugins/maven-dependency-plugin/) จะคัดลอก dependencies ไปยัง *target/lib* เมื่อ Maven ทำแพ็คเกจ ตั้งค่าเวอร์ชันของ Aspose.Slides ให้เป็นเวอร์ชันล่าสุดที่อยู่ใน [repository](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/)

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

*src/main/java/HelloSlides.java* สร้าง [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) เพิ่มสี่เหลี่ยมผืนผ้าพร้อมข้อความในสไลด์แรก และบันทึกพรีเซนเทชันสองครั้งด้วยเมธอด [save](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#save-java.lang.String-int-) : เป็น PPTX และ PDF ทั้งสองไฟล์จะถูกบันทึกลงในโฟลเดอร์ *output* ภายในไดเรกทอรีทำงาน โปรแกรมยังจะแสดงรายการฟอนต์ที่ Aspose.Slides แทนที่เมื่อเรนเดอร์พรีเซนเทชันโดยใช้ [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/th/java/com.aspose.slides/ifontsmanager/#getSubstitutions--) เพื่อให้คุณเห็นว่าคอนเทนเนอร์มีฟอนต์ที่พรีเซนเทชันใช้หรือไม่

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

*.dockerignore* จะทำให้โฟลเดอร์ *target* ของการสร้างในเครื่องและผลลัพธ์จากการรันก่อนหน้าไม่ถูกนำเข้ามาในบริบทการสร้าง Docker ทำให้อิมเมจถูกสร้างจากไฟล์ซอร์สเท่านั้น

```text
target/
output/
```

## **เขียน Dockerfile**

เพิ่มไฟล์ชื่อ *Dockerfile* ลงในโฟลเดอร์ *hello-slides-docker*:

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

ไฟล์นี้มีสองขั้นตอน:

- **ขั้นตอนการสร้าง** เริ่มจากอิมเมจ Maven คัดลอก *pom.xml* ก่อนและรัน `mvn dependency:go-offline` เพื่อดาวน์โหลด Aspose.Slides for Java และปลั๊กอิน Maven ทำให้ Docker ใช้เลเยอร์นี้ต่อไปตราบใดที่ *pom.xml* ไม่เปลี่ยน จากนั้นคัดลอกซอร์สโค้ดและรัน `mvn package` ซึ่งจะคอมไพล์โปรแกรมเป็น *target/hello-slides.jar* และคัดลอกไฟล์ JAR ของ Aspose.Slides ไปยัง *target/lib* ตัวเลือก `-B` ทำให้ Maven ทำงานในโหมดไม่โต้ตอบ (batch)

- **ขั้นตอน runtime** เริ่มจากอิมเมจ Java runtime ขนาดเล็กกว่าและคัดลอกเฉพาะไฟล์ JAR ของแอปพลิเคชันและโฟลเดอร์ *lib* สร้างโฟลเดอร์ *output* ให้กับผู้ใช้ `ubuntu` (ผู้ใช้ที่ไม่ใช่ root ที่กำหนดในอิมเมจบน Ubuntu) แล้วรันแอปพลิเคชันด้วยผู้ใช้นั้น เส้นทางคลาส `hello-slides.jar:lib/*` จะรวมแอปพลิเคชันและทุกไฟล์ JAR ใน *lib*; Java จะขยาย `*` เอง

โปรเจกต์นี้คอมไพล์สำหรับ Java 11 (คุณสมบัติ `maven.compiler.release`) ดังนั้นขั้นตอน runtime สามารถใช้เวอร์ชัน Java ที่ใหม่กว่าได้ ตัวอย่างเช่น หากต้องการรันบน Java 25 ให้เปลี่ยนอิมเมจของขั้นตอน runtime เป็น `eclipse-temurin:25-jre`

## **สร้างและรันคอนเทนเนอร์**

เปิดเทอร์มินัลในโฟลเดอร์ *hello-slides-docker* แล้วสร้างอิมเมจ จากนั้นรันคอนเทนเนอร์:

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

การสร้างครั้งแรกจะดาวน์โหลดอิมเมจฐาน, ปลั๊กอิน Maven, และ Aspose.Slides for Java จึงใช้เวลาหลายนาที; การสร้างครั้งต่อมาจะใช้เลเยอร์ที่มีอยู่แล้ว คอนเทนเนอร์รันแอปพลิเคชันแล้วหยุด ทำให้พิมพ์ข้อความ:

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

บรรทัดแรกแสดงว่าข้อความใช้ฟอนต์ Calibri ซึ่งเป็นฟอนต์เริ่มต้นของพรีเซนเทชันใหม่ แต่ Calibri ไม่มีในอิมเมจ จึงทำให้ Aspose.Slides วาดข้อความด้วย DejaVu Sans ข้อความใน PDF เป็นข้อความจริงที่สามารถเลือกได้ในฟอนต์นั้น หากไม่มีลิขสิทธิ์ Aspose.Slides จะเพิ่มลายน้ำการประเมินผลไปทุกสไลด์ ดูที่ [Licensing](/slides/th/java/licensing/)

## **คัดลอกผลลัพธ์ไปยังเครื่องของคุณ**

ไฟล์อยู่ในโฟลเดอร์ */app/output* ของคอนเทนเนอร์ที่หยุดทำงาน คัดลอกไปยังโฟลเดอร์ *output* บนเครื่องของคุณแล้วลบคอนเทนเนอร์:

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

คำสั่งทั้งสองทำงานแบบเดียวกันใน Bash, PowerShell และ Windows Command Prompt

บน Linux คุณสามารถเมานท์โฟลเดอร์บนเครื่องของคุณเข้าสู่คอนเทนเนอร์แทน เพื่อให้แอปพลิเคชันเขียนไฟล์ตรงที่นั่น:

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

ตัวเลือก `--user` ทำให้แอปพลิเคชันทำงานด้วย UID/GID ของคุณ จึงสามารถเขียนไปยังโฟลเดอร์ที่สร้างและไฟล์จะเป็นของคุณ `--rm` จะลบคอนเทนเนอร์เมื่อหยุดทำงาน

## **รันบน Alpine Linux**

Eclipse Temurin มีอิมเมจที่อิงบน Alpine Linux ซึ่งมีขนาดเล็กกว่า มี fontconfig, FreeType, และฟอนต์ DejaVu เช่นกัน ดังนั้นแอปพลิเคชันจึงไม่ต้องติดตั้งแพ็กเกจเพิ่มเติมอีก เพื่อใช้ ให้แทนที่ขั้นตอน runtime ใน *Dockerfile* (ตั้งแต่บรรทัด `FROM` ที่สอง) ด้วย:

```dockerfile
FROM eclipse-temurin:21-jre-alpine
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN adduser -D app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

อิมเมจ Alpine ไม่มีผู้ใช้ `ubuntu` จึงต้องสร้างผู้ใช้ชื่อ `app` ด้วย `adduser` แล้วรันแอปพลิเคชันด้วยผู้ใช้นั้น สร้างอิมเมจ รัน และคัดลอกผลลัพธ์ด้วยคำสั่งเดียวกับข้างต้น แอปพลิเคชันจะพิมพ์สองบรรทัดเดียวกัน

## **ใช้ฐานอิมเมจอื่น**

หากอิมเมจของคุณติดตั้ง Java ผ่านแพ็กเกจของดิสทริบิวชัน ให้ติดตั้งไลบรารีฟอนต์ของ Java พร้อมฟอนต์ด้วย ใน Debian และ Ubuntu แพ็กเกจ `openjdk-21-jre-headless` จะระบุ fontconfig, FreeType, และ HarfBuzz เฉพาะเป็นแพ็กเกจแนะนำ ดังนั้น `apt-get install --no-install-recommends` จะไม่ติดตั้งพวกมัน และแอปพลิเคชันจะหยุดด้วย `UnsatisfiedLinkError` สำหรับ `libfontmanager.so` ขั้นตอน runtime นี้ติดตั้ง Java 21, ไลบรารี, และฟอนต์ DejaVu บน Debian 13 แล้วสร้างผู้ใช้ที่ไม่เป็น root ชื่อ `app`:

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

ขั้นตอนเดียวกันทำงานบน Ubuntu 26.04 ด้วย `FROM ubuntu:26.04`

## **FAQ**

**การบันทึกพรีเซนเทชันหยุดด้วยข้อความ “Fontconfig head is null, check your fonts or fonts configuration”. สิ่งที่ขาดคืออะไร?**

ฟอนต์ Java ไม่พบฟอนต์ใดติดตั้งในอิมเมจ ติดตั้งแพ็กเกจฟอนต์ เช่น `fonts-dejavu-core` บน Debian และ Ubuntu ตามที่อธิบายใน [Use Another Base Image](#use-another-base-image) รายการฟอนต์อื่น ๆ สามารถดูได้ใน [Deploy Fonts](/slides/th/java/deploy-fonts/)

**แอปพลิเคชันหยุดด้วย UnsatisfiedLinkError สำหรับ libfontmanager.so. สิ่งที่ขาดคืออะไร?**

ไลบรารีพื้นฐานของการสนับสนุนฟอนต์ของ Java; ข้อความระบุไฟล์ที่โหลดไม่ได้ เช่น `libharfbuzz.so.0` เหตุนี้เกิดเมื่อ Java ติดตั้งจากแพ็กจ์ของดิสทริบิวชันโดยไม่มีแพ็กเกจที่แนะนำ ให้ติดตั้งไลบรารีตามที่ระบุใน [Use Another Base Image](#use-another-base-image)

**ทำไมข้อความใน PDF ถึงมีฟอนต์ต่างจากใน PowerPoint?**

ฟอนต์ที่พรีเซนเทชันใช้ไม่ได้ติดตั้งในอิมเมจ จึงทำให้ Aspose.Slides ใช้ฟอนต์ทดแทน แอปพลิเคชันจะแสดงฟอนต์ที่ถูกแทนที่ รายละเอียดการติดตั้งฟอนต์ดูได้ที่ [Deploy Fonts](/slides/th/java/deploy-fonts/)

**แอปพลิเคชันสามารถใช้หน่วยความจำเท่าไหร่ในคอนเทนเนอร์?**

โดยค่าเริ่มต้น Java จำกัด heap ที่หนึ่งในสี่ของหน่วยความจำที่คอนเทนเนอร์มี เช่น ประมาณ 250 MB เมื่อรันคอนเทนเนอร์ด้วย `docker run -m 1g` หากต้องประมวลผลพรีเซนเทชันขนาดใหญ่ให้เพิ่มค่า `MaxRAMPercentage` เช่น `docker run --rm -m 1g -e JAVA_TOOL_OPTIONS=-XX:MaxRAMPercentage=75 hello-slides` Java จะพิมพ์บรรทัด “Picked up JAVA_TOOL_OPTIONS” ก่อนผลลัพธ์ของแอปพลิเคชัน

**ฉันต้องการ JDK หรือ Maven บนเครื่องของฉันหรือไม่?**

ไม่จำเป็น ขั้นตอน build คอมไพล์แอปพลิเคชันภายในอิมเมจ Maven คุณต้องมี JDK และ Maven เท่านั้นหากต้องการสร้างและรันแอปพลิเคชันนอก Docker; ดูที่ [Installation](/slides/th/java/installation/)