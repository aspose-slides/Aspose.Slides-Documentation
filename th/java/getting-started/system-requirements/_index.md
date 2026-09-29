---
title: ข้อกำหนดระบบ
type: docs
weight: 60
url: /th/java/system-requirements/
keywords:
- ข้อกำหนดระบบ
- แพลตฟอร์มที่รองรับ
- เวอร์ชัน Java
- JDK
- JRE
- fontconfig
- ฟอนต์
- Docker
- Alpine
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ตรวจสอบสิ่งที่ Aspose.Slides for Java ต้องการก่อนติดตั้ง: เวอร์ชัน Java และระบบปฏิบัติการที่รองรับ รวมถึงไลบรารีฟอนต์และฟอนต์ที่ Linux ต้องการ."
---
## **บทนำ**

Aspose.Slides for Java เป็นไลบรารีแบบสแตนด์อโลน: ไม่ต้องการ Microsoft PowerPoint หรือ Microsoft Office ไฟล์เป็น JAR ไฟล์เดียวที่เผยแพร่ใน Maven repository ของ Aspose ไฟล์ JAR นี้มีเพียงคลาสและทรัพยากรของ Java เท่านั้น ไม่มีไลบรารีเนทีฟ และไม่ประกาศการพึ่งพาไลบรารีอื่น ไฟล์เดียวกันจึงทำงานได้บนระบบปฏิบัติการและสถาปัตยกรรมโปรเซสเซอร์ทุกประเภทที่มี Java runtime ที่รองรับ

บทความนี้รายการเวอร์ชัน Java ที่รองรับและระบบปฏิบัติการ รวมถึงไลบรารีฟอนต์และฟอนต์ที่ Linux ต้องการ และสรุปด้วยโปรแกรมสั้นที่ตรวจสอบการตั้งค่าของคุณ เพื่อเพิ่มไลบรารีเข้าสู่โครงการ ดู [การติดตั้ง](/slides/th/java/installation/).

## **เวอร์ชัน Java ที่รองรับ**

Aspose.Slides for Java ทำงานบน Java 8 ขึ้นไป โดยใช้ JDK หรือ JRE ซึ่งรวมถึงรุ่นที่มีการสนับสนุนระยะยาว Java 8, 11, 17, 21, และ 25 รวมถึงรุ่นใหม่อย่าง Java 26 และ Java 27 runtime ของ Java สามารถมาจากผู้ผลิตใดก็ได้ เช่น Eclipse Temurin, Amazon Corretto, Oracle หรือแพคเกจ OpenJDK ของดิสทริบิวชัน Linux

Aspose.Slides ไม่ต้องการตัวเลือก JVM ใด ๆ เช่น `--add-opens` ในเวอร์ชันเหล่านี้ บน Java 11 JVM จะพิมพ์คำเตือนที่ขึ้นต้นด้วย “WARNING: An illegal reflective access operation has occurred”; คำเตือนนี้ไม่ส่งผลต่อผลลัพธ์

{{% alert color="warning" title="Warning" %}}
Java 6 และ Java 7 ถูกเลิกใช้ Aspose.Slides for Java 26.9 ยังทำงานบนรุ่นเหล่านี้แต่จะพิมพ์คำเตือนการเลิกใช้ ตั้งแต่เวอร์ชัน 26.10 เป็นต้นไป Java 8 เป็นขั้นต่ำ และ Java 6 และ Java 7 ไม่ได้รับการสนับสนุนอีกต่อไป
{{% /alert %}}

โปรเจกต์ Maven และคำสั่งใน [การติดตั้ง](/slides/th/java/installation/) ต้องการ JDK 11 ขึ้นไป หากใช้ Java 8 ให้คอมไพล์และรันโปรแกรมตามที่แสดงใน [ตรวจสอบการตั้งค่า](/slides/th/java/installation/#check-your-setup).

## **ระบบปฏิบัติการที่รองรับ**

เนื่องจากไฟล์ JAR ไม่มีโค้ดเนทีฟ Aspose.Slides for Java ทำงานได้บน Windows, Linux, และ macOS บนสถาปัตยกรรมโปรเซสเซอร์ใด ๆ ที่ Java runtime รองรับ เช่น x64 และ ARM64 runtime ของ Java เป็นความต้องการเดียวบน Windows บน Linux การสนับสนุนฟอนต์ของ Java ยังต้องการไลบรารีฟอนต์และฟอนต์ที่อธิบายไว้ใน [Linux](#linux).

## **Linux**

Aspose.Slides for Java จัดวางและวาดข้อความโดยอาศัยการสนับสนุนฟอนต์ของ Java runtime บน Linux การสนับสนุนนี้ต้องการไลบรารี fontconfig และอย่างน้อยหนึ่งฟอนต์ที่ติดตั้งไว้ ภาพคอนเทนเนอร์มาตรฐานของดิสทริบิวชัน Linux มักไม่มีเลย หากไม่มี ไอเท็มแรกใน [สร้างงานนำเสนอ](/slides/th/java/create-presentation/) จะล้มเหลวขณะบันทึกงานนำเสนอ ทิ้งไฟล์เปล่าและรายงานข้อผิดพลาดดังนี้

```text
java.lang.RuntimeException: Fontconfig head is null, check your fonts or fonts configuration
```

คอนเทนเนอร์ `eclipse-temurin` อย่างเป็นทางการสำหรับ Ubuntu และ Alpine Linux มี fontconfig และฟอนต์ DejaVu อยู่แล้ว จึงไม่ต้องติดตั้งอะไรเพิ่มเติมบนคอนเทนเนอร์เหล่านั้น ในระบบอื่นให้ติดตั้งแพคเกจตามด้านล่าง คำสั่งสำหรับ Debian, Ubuntu, และ Red Hat ใช้ `sudo`; ใน Dockerfile ให้เรียกใช้ในคำสั่ง `RUN` โดยไม่ใช้ `sudo` ฟอนต์ DejaVu เพียงพอสำหรับให้ Aspose.Slides ทำงาน; ฟอนต์ที่งานนำเสนอของคุณใช้นั้นอยู่ในหัวข้อ [ฟอนต์](#fonts).

### **Debian และ Ubuntu**

หากติดตั้ง Java จากแพคเกจ Debian หรือ Ubuntu ด้วยค่าเริ่มต้นของ `apt-get` ตามคำสั่งใน [การติดตั้ง](/slides/th/java/installation/#linux) แพคเกจ Java จะติดตั้งไลบรารี fontconfig, ฟอนต์ DejaVu, และไลบรารี HarfBuzz ที่จำเป็นโดยอัตโนมัติ ไม่มีสิ่งอื่นที่ต้องทำเพิ่มเติม

หากใช้ Java runtime จากแหล่งอื่น เช่น อาร์ไชฟ์ Eclipse Temurin ให้ติดตั้ง fontconfig และฟอนต์ DejaVu:

```bash
sudo apt-get update && sudo apt-get install -y fontconfig fonts-dejavu-core
```

Dockerfile ที่ติดตั้งแพคเกจ Java ของ Debian หรือ Ubuntu เช่น `openjdk-21-jdk-headless` หรือ `default-jdk-headless` พร้อมออปชัน `--no-install-recommends` จะข้ามการติดตั้งทั้งหมดสามอย่างนี้ ให้ติดตั้ง fontconfig และฟอนต์ DejaVu ด้วยคำสั่งข้างต้น แล้วติดตั้ง HarfBuzz ด้วย:

```bash
sudo apt-get install -y libharfbuzz0b
```

หากไม่มี HarfBuzz แพคเกจ Java จะพิมพ์ข้อความ `Please install the openjdk-*-jre package or recommended packages for openjdk-*-jre-headless` และการบันทึกจะล้มเหลวด้วย `UnsatisfiedLinkError` ที่รายงานว่าไม่สามารถเปิด `libharfbuzz.so.0` ได้

### **Red Hat Enterprise Linux**

แพคเกจ `java-<version>-openjdk-headless` ของ Red Hat Enterprise Linux ไม่ได้ติดตั้งไลบรารี fontconfig ให้ติดตั้งพร้อมกับฟอนต์ DejaVu:

```bash
sudo dnf install -y fontconfig dejavu-sans-fonts
```

แพคเกจ `java-<version>-openjdk` เต็มรูปแบบจะติดตั้ง fontconfig และฟอนต์เป็น dependency เช่นเดียวกับแพคเกจ Amazon Corretto ของ Amazon Linux 2023 เช่น `java-21-amazon-corretto-headless`.

### **Alpine Linux**

ใน Dockerfile ที่ใช้ฐาน Alpine Linux ให้ติดตั้ง fontconfig และฟอนต์ DejaVu:

```dockerfile
RUN apk add --no-cache fontconfig ttf-dejavu
```

บนรุ่น Alpine ปัจจุบัน `ttf-dejavu` จะติดตั้งแพคเกจ `font-dejavu` ให้ติดตั้ง Java ด้วยแพคเกจ `openjdk<version>-jre` หรือ `openjdk<version>-jdk` เช่น `openjdk25-jdk` แพคเกจ `openjdk<version>-jre-headless` ของ Alpine ไม่มีไลบรารีฟอนต์ของ Java ดังนั้นโปรแกรมจะล้มเหลวด้วย `UnsatisfiedLinkError: no fontmanager in system library path` แม้ว่าจะติดตั้งฟอนต์แล้วก็ตาม

### **ฟอนต์**

เพื่อให้ข้อความแสดงผลด้วยฟอนต์และเมตริกที่ถูกต้อง ฟอนต์ที่งานนำเสนอของคุณใช้ หรือฟอนต์ทดแทนที่เหมาะสม ต้องติดตั้งบนระบบหรือโหลดโดยแอปพลิเคชันของคุณ ดู [การปรับใช้ฟอนต์](/slides/th/java/deploy-fonts/), [การทดแทนฟอนต์](/slides/th/java/font-substitution/), และ [ฟอนต์กำหนดเอง](/slides/th/java/custom-font/).

## **ตรวจสอบการตั้งค่า**

เพื่อให้แน่ใจว่าไลบรารีและความต้องการทั้งหมดพร้อมทำงาน ให้รันโปรแกรมที่บันทึกงานนำเสนอและเรนเดอร์สไลด์เป็นภาพ การบันทึกและการเรนเดอร์ใช้การสนับสนุนฟอนต์ของ Java runtime ซึ่งเป็นสิ่งที่ข้อกำหนดของ Linux ข้างต้นจัดเตรียมไว้

บันทึกโค้ดด้านล่างเป็น *CheckSetup.java* ในโฟลเดอร์ที่เก็บไฟล์ JAR ของ Aspose.Slides การดาวน์โหลดไฟล์ JAR ดูได้จาก [ใช้ไฟล์ JAR โดยไม่ใช้ Maven](/slides/th/java/installation/#use-the-jar-file-without-maven).

```java
import com.aspose.slides.*;

public class CheckSetup {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            // เพิ่มสี่เหลี่ยมพร้อมข้อความบนสไลด์แรกและบันทึกงานนำเสนอ.
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.getTextFrame().setText("Hello, Aspose.Slides!");
            presentation.save("hello.pptx", SaveFormat.Pptx);

            // เรนเดอร์สไลด์ที่หนึ่งพิกเซลต่อจุดและบันทึกภาพ.
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

ด้วย JDK 11 ขึ้นไป รันโปรแกรมในโฟลเดอร์นั้นด้วยคำสั่งด้านล่าง หากไฟล์ JAR ของคุณมีชื่ออื่น ให้เปลี่ยนชื่อในคำสั่ง

```bash
java -cp aspose-slides-26.9-jdk16.jar CheckSetup.java
```

ด้วย Java 8 หรือระบบที่มีเพียง JRE ให้คอมไพล์โปรแกรมด้วย `javac` จาก JDK แล้วรันคลาสที่คอมไพล์แล้ว บน Linux และ macOS รัน:

```bash
javac -cp aspose-slides-26.9-jdk16.jar CheckSetup.java
java -cp aspose-slides-26.9-jdk16.jar:. CheckSetup
```

บน Windows ให้รันคำสั่ง `javac` เดียวกัน แล้วรันคลาสโดยใช้เซมิโคลอนเป็นตัวคั่นคลาสพาธ รักษาเครื่องหมายคำพูดเพื่อให้ PowerShell ไม่ตีความเซมิโคลอนเป็นจุดสิ้นสุดของคำสั่ง: `java -cp "aspose-slides-26.9-jdk16.jar;." CheckSetup`.

โปรแกรมจะเพิ่มสี่เหลี่ยมพร้อมข้อความลงบนสไลด์แรกและบันทึกงานนำเสนอเป็น *hello.pptx* ด้วยเมธอด [save](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#save-java.lang.String-int-) จากนั้นเรนเดอร์สไลด์ด้วย [getImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/slide/#getImage-float-float-) และบันทึกผลเป็น *hello.png* ด้วย [IImage.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimage/#save-java.lang.String-int-) ในรูปแบบ [ImageFormat.Png](https://reference.aspose.com/slides/th/java/com.aspose.slides/imageformat/) ตัวคูณสเกล 1 จะเรนเดอร์หนึ่งพิกเซลต่อจุด ดังนั้นสไลด์ขนาด 720 × 540 point จะกลายเป็นภาพ 720 × 540 pixel พร้อมข้อความที่มองเห็นภายในสี่เหลี่ยม หากไม่มีไลเซนส์ไฟล์ทั้งสองจะมีลายน้ำการประเมินผล; ดู [การให้สิทธิ์](/slides/th/java/licensing/). หากมีความต้องการใดขาดหาย โปรแกรมจะหยุดทำงานพร้อมข้อผิดพลาดที่อธิบายไว้ใน [Linux](#linux).

## **เครื่องมือพัฒนา**

คุณสามารถสร้างแอปพลิเคชันที่ใช้ Aspose.Slides ด้วย JDK ของเวอร์ชัน Java ที่รองรับ ใช้ Apache Maven กับ Maven repository ของ Aspose ตามที่อธิบายใน [การติดตั้ง](/slides/th/java/installation/) หรือเครื่องมือสร้างอื่นใดที่สามารถใช้ Maven repository ได้ คุณยังสามารถเพิ่มไฟล์ JAR เข้าไปในคลาสพาธของ IDE หรือเครื่องมือสร้างเองได้

## **FAQ**

**ฉันต้องติดตั้ง Microsoft PowerPoint เพื่อทำการแปลงและเรนเดอร์หรือไม่?**

ไม่ได้จำเป็น PowerPoint ไม่ต้องการ Aspose.Slides เป็นเอนจิ้นสแตนด์อโลนสำหรับ [การสร้าง](/slides/th/java/create-presentation/), การแก้ไข, [การแปลง](/slides/th/java/convert-presentation/), และ [การเรนเดอร์](/slides/th/java/convert-powerpoint-to-png/) งานนำเสนอ

**Aspose.Slides for Java ต้องการหน้าจอหรือสภาพแวดล้อมเดสก์ท็อปบนเซิร์ฟเวอร์ Linux หรือไม่?**

ไม่จำเป็น Aspose.Slides ไม่ต้องการ X server หรือหน้าจอ จึงทำงานได้บนเซิร์ฟเวอร์และคอนเทนเนอร์ บน Linux ต้องการแค่ไลบรารีฟอนต์และฟอนต์ที่อธิบายไว้ใน [Linux](#linux).

**ต้องใช้ฟอนต์อะไรสำหรับการเรนเดอร์ที่ถูกต้อง?**

ฟอนต์ที่ใช้ในงานนำเสนอ หรือฟอนต์ [ทดแทน](/slides/th/java/font-substitution/) ที่เหมาะสม จะต้องพร้อมใช้งาน บน Linux และ macOS ให้ติดตั้งแพคเกจฟอนต์ที่งานนำเสนอของคุณต้องการเพื่อให้ได้การเรนเดอร์ที่สอดคล้องกัน

**ทำไมฟอนต์กำหนดเองถึงแสดงเป็นฟอนต์สำรองหรือข้อความหายบน Linux?**

หากไฟล์ฟอนต์มีรายการชื่อ (name‑table) ที่ไม่สอดคล้องหรือเสียหาย แพลตการจับคู่ฟอนต์ของ Linux (FreeType/fontconfig) อาจเลือกบันทึกที่ไม่ถูกต้อง ทำให้ฟอนต์ไม่สามารถหาได้ การใช้เวอร์ชันฟอนต์ที่แก้ไข name‑table ให้ถูกต้อง หรือการติดตั้งฟอนต์ทดแทนที่สอดคล้อง จะช่วยแก้ปัญหาได้