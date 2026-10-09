---
title: ความต้องการของระบบ
type: docs
weight: 60
url: /th/java/system-requirements/
keywords:
- ความต้องการของระบบ
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
- การนำเสนอ
- Java
- Aspose.Slides
description: "ตรวจสอบสิ่งที่ Aspose.Slides for Java ต้องการก่อนการติดตั้ง: เวอร์ชัน Java ที่รองรับและระบบปฏิบัติการ, รวมถึงไลบรารีฟอนต์และฟอนต์ที่ Linux ต้องการ."
---
## **บทนำ**

Aspose.Slides for Java เป็นไลบรารีแบบสแตนด์อโลน: ไม่ต้องพึ่ง Microsoft PowerPoint หรือ Microsoft Office. เป็นไฟล์ JAR เพียงไฟล์เดียวที่เผยแพร่ใน Maven repository ของ Aspose. ไฟล์ JAR จะมีเฉพาะคลาสและทรัพยากรของ Java โดยไม่มีไลบรารีเนทีฟและไม่ได้ระบุการพึ่งพาไลบรารีอื่นใด. ดังนั้นไฟล์เดียวกันจึงสามารถทำงานได้บนทุกระบบปฏิบัติการและโปรเซสเซอร์ที่มี Java runtime ที่รองรับ.

บทความนี้แสดงรายการเวอร์ชัน Java และระบบปฏิบัติการที่รองรับ รวมถึงไลบรารีฟอนต์และฟอนต์ที่ Linux ต้องการ และจบด้วยโปรแกรมสั้นที่ตรวจสอบการตั้งค่าของคุณ. เพื่อเพิ่มไลบรารีเข้ากับโครงการ โปรดดูที่ [การติดตั้ง](/slides/th/java/installation/).

## **เวอร์ชัน Java ที่รองรับ**

Aspose.Slides for Java ทำงานบน Java 8 หรือรุ่นต่อไป ด้วย JDK หรือ JRE. รวมถึงเวอร์ชันสนับสนุนระยะยาว Java 8, 11, 17, 21, และ 25, รวมถึงเวอร์ชันต่อๆ ไปเช่น Java 26 และ Java 27. Java runtime สามารถมาจากผู้จำหน่ายใดก็ได้ เช่น Eclipse Temurin, Amazon Corretto, Oracle หรือแพ็กเกจ OpenJDK ของดิสทริบิวชั่น Linux.

Aspose.Slides ไม่ต้องการตัวเลือก JVM ใดๆ เช่น `--add-opens` ในทุกเวอร์ชันเหล่านี้. บน Java 11, JVM จะพิมพ์คำเตือนที่เริ่มด้วย "WARNING: An illegal reflective access operation has occurred"; คำเตือนนี้ไม่ส่งผลต่อผลลัพธ์.

{{% alert color="warning" title="Warning" %}}
Java 6 และ Java 7 ถูกยกเลิกการใช้งาน. Aspose.Slides for Java 26.9 ยังทำงานบนเวอร์ชันเหล่านี้ได้แต่จะพิมพ์คำเตือนการยกเลิก. ตั้งแต่เวอร์ชัน 26.10, Java 8 จะเป็นขั้นต่ำ, และ Java 6 กับ Java 7 จะไม่รองรับอีกต่อไป.
{{% /alert %}}

โครงการ Maven และคำสั่งใน [การติดตั้ง](/slides/th/java/installation/) ต้องการ JDK 11 หรือสูงกว่า. ด้วย Java 8, ให้คอมไพล์และรันโปรแกรมของคุณตามที่แสดงใน [ตรวจสอบการตั้งค่า](#check-your-setup).

## **ระบบปฏิบัติการที่รองรับ**

เนื่องจากไฟล์ JAR ไม่มีโค้ดเนทีฟ Aspose.Slides for Java จึงทำงานบน Windows, Linux, และ macOS บนสถาปัตยกรรมโปรเซสเซอร์ใดๆ ที่ Java runtime รองรับ เช่น x64 และ ARM64. Java runtime เป็นข้อกำหนดเดียวที่จำเป็นบน Windows. บน Linux, การสนับสนุนฟอนต์ของ Java ยังต้องการไลบรารีฟอนต์และฟอนต์ตามที่อธิบายใน [Linux](#linux).

## **Linux**

Aspose.Slides for Java จัดเรียงและวาดข้อความโดยใช้การสนับสนุนฟอนต์ของ Java runtime. บน Linux, การสนับสนุนนี้ต้องการไลบรารี fontconfig และอย่างน้อยหนึ่งฟอนต์ที่ติดตั้งไว้. ภาพคอนเทนเนอร์อย่างเป็นทางการของดิสทริบิวชั่น Linux มักไม่มีสิ่งเหล่านี้. หากไม่มี จะทำให้ตัวอย่างแรกใน [สร้างการนำเสนอ](/slides/th/java/create-presentation/) ล้มเหลวเมื่อบันทึกการนำเสนอ, ทำให้ไฟล์ว่างเปล่า, และรายงานข้อผิดพลาดนี้:

```text
java.lang.RuntimeException: Fontconfig head is null, check your fonts or fonts configuration
```

ภาพคอนเทนเนอร์ `eclipse-temurin` อย่างเป็นทางการสำหรับ Ubuntu และ Alpine Linux มี fontconfig และฟอนต์ DejaVu อยู่แล้ว, ดังนั้นไม่ต้องติดตั้งอะไรเพิ่มเติม. ในระบบอื่น, ให้ติดตั้งแพ็กเกจด้านล่าง. คำสั่งสำหรับ Debian, Ubuntu, และ Red Hat ใช้ `sudo`; ใน Dockerfile ให้รันคำสั่งเหล่านี้ในคำสั่ง `RUN` โดยไม่ต้องใช้ `sudo`. ฟอนต์ DejaVu เพียงพอสำหรับให้ Aspose.Slides ทำงาน; ฟอนต์ที่การนำเสนอของคุณใช้จะอธิบายไว้ใน [ฟอนต์](#fonts).

### **Debian และ Ubuntu**

หากคุณติดตั้ง Java จากแพ็กเกจ Debian หรือ Ubuntu ด้วยการตั้งค่า `apt-get` เริ่มต้น, ตามคำสั่งใน [การติดตั้ง](/slides/th/java/installation/#linux) จะทำให้แพ็กเกจ Java ยังติดตั้งไลบรารี fontconfig, ฟอนต์ DejaVu, และไลบรารี HarfBuzz ที่จำเป็น, และไม่มีสิ่งอื่นที่ต้องการเพิ่มเติม.

หากใช้ Java runtime จากแหล่งอื่น, เช่นไฟล์เก็บของ Eclipse Temurin, ให้ติดตั้ง fontconfig และฟอนต์ DejaVu:

```bash
sudo apt-get update && sudo apt-get install -y fontconfig fonts-dejavu-core
```

Dockerfile มักติดตั้งแพ็กเกจ Java ของ Debian หรือ Ubuntu เช่น `openjdk-21-jdk-headless` หรือ `default-jdk-headless` พร้อมตัวเลือก `--no-install-recommends` ซึ่งจะข้ามทั้งสาม. ให้ติดตั้ง fontconfig และฟอนต์ DejaVu ด้วยคำสั่งข้างต้น, และติดตั้ง HarfBuzz ด้วย:

```bash
sudo apt-get install -y libharfbuzz0b
```

หากไม่มี HarfBuzz, แพ็กเกจ Java เหล่านี้จะพิมพ์ข้อความ `Please install the openjdk-*-jre package or recommended packages for openjdk-*-jre-headless` และการบันทึกจะล้มเหลวด้วย `UnsatisfiedLinkError` ที่บ่งชี้ว่าไม่สามารถเปิด `libharfbuzz.so.0` ได้.

### **Red Hat Enterprise Linux**

แพ็กเกจ `java-<version>-openjdk-headless` ของ Red Hat Enterprise Linux ไม่ติดตั้งไลบรารี fontconfig. ให้ติดตั้งพร้อมกับฟอนต์ DejaVu:

```bash
sudo dnf install -y fontconfig dejavu-sans-fonts
```

แพ็กเกจเต็ม `java-<version>-openjdk` จะติดตั้ง fontconfig และฟอนต์เป็นการพึ่งพา, และเช่นเดียวกับแพ็กเกจ Amazon Corretto ของ Amazon Linux 2023, เช่น `java-21-amazon-corretto-headless`.

### **Alpine Linux**

ใน Dockerfile ที่ใช้ฐาน Alpine Linux, ให้ติดตั้ง fontconfig และฟอนต์ DejaVu:

```dockerfile
RUN apk add --no-cache fontconfig ttf-dejavu
```

บนรุ่น Alpine ปัจจุบัน, `ttf-dejavu` จะติดตั้งแพ็กเกจ `font-dejavu`. ให้ติดตั้ง Java ด้วยแพ็กเกจ `openjdk<version>-jre` หรือ `openjdk<version>-jdk`, เช่น `openjdk25-jdk`. แพ็กเกจ `openjdk<version>-jre-headless` ของ Alpine Linux ไม่มีไลบรารีฟอนต์ของ Java, ดังนั้นโปรแกรมจะล้มเหลวด้วย `UnsatisfiedLinkError: no fontmanager in system library path` แม้ว่าจะติดตั้งฟอนต์แล้วก็ตาม.

### **ฟอนต์**

เพื่อให้ข้อความแสดงผลด้วยฟอนต์และเมตริกที่ถูกต้อง, ฟอนต์ที่การนำเสนอของคุณใช้หรือฟอนต์ทดแทนที่เหมาะสมต้องถูกติดตั้งบนระบบหรือโหลดโดยแอปพลิเคชันของคุณ. ดูที่ [ปรับใช้ฟอนต์](/slides/th/java/deploy-fonts/), [การแทนที่ฟอนต์](/slides/th/java/font-substitution/), และ [ฟอนต์ที่กำหนดเอง](/slides/th/java/custom-font/).

## **ตรวจสอบการตั้งค่า**

เพื่อเช็คว่าไลบรารีและข้อกำหนดของมันพร้อมใช้งาน, ให้รันโปรแกรมที่บันทึกการนำเสนอและเรนเดอร์สไลด์เป็นภาพ. การบันทึกและการเรนเดอร์ใช้การสนับสนุนฟอนต์ของ Java runtime ซึ่งเป็นสิ่งที่ข้อกำหนดของ Linux ข้างต้นจัดหา.

บันทึกรหัสด้านล่างเป็น *CheckSetup.java* ในโฟลเดอร์ที่มีไฟล์ JAR ของ Aspose.Slides. เพื่อดาวน์โหลดไฟล์ JAR, ดูที่ [ใช้ไฟล์ JAR โดยไม่ต้องใช้ Maven](/slides/th/java/installation/#use-the-jar-file-without-maven).

```java
import com.aspose.slides.*;

public class CheckSetup {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            // เพิ่มสี่เหลี่ยมผืนผ้าพร้อมข้อความลงในสไลด์แรกและบันทึกการนำเสนอ.
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.getTextFrame().setText("Hello, Aspose.Slides!");
            presentation.save("hello.pptx", SaveFormat.Pptx);

            // เรนเดอร์สไลด์ที่หนึ่งพิกเซลต่อจุดและบันทึกรูปภาพ.
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

ด้วย JDK 11 หรือใหม่กว่า, ให้รันโปรแกรมในโฟลเดอร์นั้นด้วยคำสั่งด้านล่าง. หากไฟล์ JAR ของคุณมีชื่ออื่น, ให้เปลี่ยนชื่อในคำสั่ง.

```bash
java -cp aspose-slides-26.10-jdk8.jar CheckSetup.java
```

ด้วย Java 8, หรือบนระบบที่มีเฉพาะ JRE, ให้คอมไพล์โปรแกรมด้วย `javac` จาก JDK แล้วรันคลาสที่คอมไพล์แล้ว. บน Linux และ macOS, รัน:

```bash
javac -cp aspose-slides-26.10-jdk8.jar CheckSetup.java
java -cp aspose-slides-26.10-jdk8.jar:. CheckSetup
```

บน Windows, รันคำสั่ง `javac` เดียวกัน, แล้วรันคลาสโดยใช้เครื่องหมายเซมิโคลอนเป็นตัวคั่น class path. เก็บเครื่องหมายคำพูดไว้เพื่อให้ PowerShell ไม่ตีความเซมิโคลอนเป็นจุดสิ้นสุดของคำสั่ง: `java -cp \"aspose-slides-26.10-jdk8.jar;.\" CheckSetup`.

โปรแกรมจะเพิ่มสี่เหลี่ยมผืนผ้าพร้อมข้อความในสไลด์แรกและบันทึกการนำเสนอเป็น *hello.pptx* ด้วยเมธอด [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-). จากนั้นจะเรนเดอร์สไลด์ด้วย [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#getImage-float-float-) และบันทึกผลเป็น *hello.png* ด้วย [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) ในรูปแบบ [ImageFormat.Png](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/). ตัวคูณสเกล 1 จะทำให้หนึ่งพิกเซลต่อจุด, ดังนั้นสไลด์เริ่มต้นที่ 720 × 540 จุดจะกลายเป็นภาพ 720 × 540 พิกเซล, โดยข้อความจะมองเห็นได้ภายในสี่เหลี่ยม. หากไม่มีไลเซนส์, ทั้งสองไฟล์จะมีลายน้ำการประเมินผล; ดูที่ [การออกใบอนุญาต](/slides/th/java/licensing/). หากขาดข้อกำหนดใด, โปรแกรมจะหยุดด้วยหนึ่งในข้อผิดพลาดที่อธิบายใน [Linux](#linux).

## **เครื่องมือพัฒนา**

คุณสามารถสร้างแอปพลิเคชันที่ใช้ Aspose.Slides ด้วย JDK ใดก็ได้ของเวอร์ชัน Java ที่รองรับ. ใช้ Apache Maven กับ Maven repository ของ Aspose ตามที่อธิบายใน [การติดตั้ง](/slides/th/java/installation/), หรือเครื่องมือสร้างอื่นใดที่สามารถใช้ Maven repository ได้. คุณยังสามารถเพิ่มไฟล์ JAR ไปยัง class path ของ IDE หรือเครื่องมือสร้างของคุณเองได้.

## **คำถามที่พบบ่อย**

**ฉันจำเป็นต้องติดตั้ง Microsoft PowerPoint เพื่อทำการแปลงและเรนเดอร์หรือไม่?**

ไม่, ไม่จำเป็นต้องมี PowerPoint. Aspose.Slides เป็นเอนจินแบบสแตนด์อโลนสำหรับ [การสร้าง](/slides/th/java/create-presentation/), การแก้ไข, [การแปลง](/slides/th/java/convert-presentation/), และ [การเรนเดอร์](/slides/th/java/convert-powerpoint-to-png/) การนำเสนอ.

**Aspose.Slides for Java จำเป็นต้องมีหน้าจอหรือสภาพแวดล้อมเดสก์ท็อปบนเซิร์ฟเวอร์ Linux หรือไม่?**

ไม่. Aspose.Slides ไม่ต้องการ X server หรือหน้าจอ, ดังนั้นมันทำงานบนเซิร์ฟเวอร์และในคอนเทนเนอร์. บน Linux, จะต้องการเพียงไลบรารีฟอนต์และฟอนต์ที่อธิบายไว้ใน [Linux](#linux).

**ฟอนต์ใดที่จำเป็นสำหรับการเรนเดอร์ที่ถูกต้อง?**

ฟอนต์ที่ใช้ในการนำเสนอ หรือ [ฟอนต์ทดแทน](/slides/th/java/font-substitution/) ที่เหมาะสม ต้องพร้อมใช้งาน. บน Linux และ macOS, ให้ติดตั้งแพ็กเกจฟอนต์ที่การนำเสนอของคุณต้องการเพื่อให้การเรนเดอร์สอดคล้อง.

**ทำไมฟอนต์ที่กำหนดเองจึงแสดงเป็นฟอนต์สำรองหรือข้อความหายบน Linux?**

หากไฟล์ฟอนต์มีรายการ name-table ที่ไม่สอดคล้องหรือเสียหาย, stack การจับคู่ฟอนต์ของ Linux (FreeType/fontconfig) อาจเลือกบันทึกที่ไม่ถูกต้อง, ทำให้ฟอนต์ไม่ถูกระบุ. การใช้เวอร์ชันฟอนต์ที่มีการแก้ไข name-table หรือการติดตั้งฟอนต์ทดแทนที่สอดคล้องกันจะช่วยแก้ปัญหา.