---
title: Aspose.Slides for Java
second_title: Aspose.Slides for Java
type: docs
weight: 20
url: /th/java/
keywords:
- เอกสาร
- การประมวลผลงานนำเสนอ
- การแปลงงานนำเสนอ
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "เริ่มต้นที่นี่: ติดตั้ง Aspose.Slides for Java, สร้างการนำเสนอแรก, และค้นหาคู่มือสำหรับงานทั่วไป, เอกสารอ้างอิง API และการสนับสนุน."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Java เป็นไลบรารีคลาสสำหรับสร้าง, อ่าน, แก้ไข และแปลงงานนำเสนอ PowerPoint และ OpenDocument ในแอปพลิเคชัน Java โดยไม่ต้องใช้ Microsoft PowerPoint.

ไลบรารีนี้สามารถโหลดและบันทึกไฟล์ PPT, PPTX, PPS, POT และ ODP รวมถึงเวอร์ชันที่มีมาโครและเทมเพลต และส่งออกเป็น PDF, XPS, HTML, SVG, TIFF, Markdown และรูปภาพ.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>เริ่มต้น</b></p>
<hr>
<p>เริ่มต้นใช้งาน</p>
<ul>
<li><a href="/slides/th/java/installation/">การติดตั้ง</a></li>
<li><a href="/slides/th/java/create-presentation/">สร้างการนำเสนอแรกของคุณ</a></li>
<li><a href="/slides/th/java/getting-started/">คู่มือเริ่มต้นใช้งาน</a></li>
</ul>
<p>ประเมิน</p>
<ul>
<li><a href="/slides/th/java/supported-file-formats/">รูปแบบไฟล์ที่รองรับ</a></li>
<li><a href="/slides/th/java/evaluate-aspose-slides/">ข้อจำกัดของรุ่นทดลอง</a></li>
<li><a href="/slides/th/java/licensing/">การให้สิทธิ์ใช้งาน</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>สร้างด้วย Slides</b></p>
<hr>
<p>งานทั่วไป</p>
<ul>
<li><a href="/slides/th/java/open-presentation/">เปิดการนำเสนอ</a></li>
<li><a href="/slides/th/java/save-presentation/">บันทึกการนำเสนอ</a></li>
<li><a href="/slides/th/java/convert-powerpoint-to-pdf/">แปลงเป็น PDF</a></li>
<li><a href="/slides/th/java/convert-slide/">แปลงสไลด์เป็นภาพ</a></li>
<li><a href="/slides/th/java/manage-text/">แก้ไขข้อความและรูปร่าง</a></li>
</ul>
<p>กระบวนการทำงานกับ Slides</p>
<ul>
<li><a href="/slides/th/java/powerpoint-charts/">แผนภูมิ</a></li>
<li><a href="/slides/th/java/powerpoint-animation/">การเคลื่อนไหว</a></li>
<li><a href="/slides/th/java/manage-media-files/">เสียงและวิดีโอ</a></li>
<li><a href="/slides/th/java/presentation-design/">ออกแบบสไลด์</a></li>
<li><a href="/slides/th/java/merge-presentation/">ผสานการนำเสนอ</a></li>
</ul>
<p>ตัวอย่าง</p>
<ul>
<li><a href="/slides/th/java/examples/">ตัวอย่างตามองค์ประกอบสไลด์</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Java">ตัวอย่างบน GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>อ้างอิงและการสนับสนุน</b></p>
<hr>
<p>อ้างอิง</p>
<ul>
<li><a href="https://reference.aspose.com/slides/th/java/">อ้างอิง API</a></li>
<li><a href="https://releases.aspose.com/slides/th/java/release-notes/">บันทึกการอัปเดต</a></li>
<li><a href="/slides/th/java/known-issues/">ปัญหาที่ทราบ</a></li>
<li><a href="https://releases.aspose.com/slides/th/java/">ดาวน์โหลด</a></li>
</ul>
<p>การสนับสนุน</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/th/11">ฟอรั่มสนับสนุนฟรี</a></li>
<li><a href="https://helpdesk.aspose.com/">ศูนย์ช่วยเหลือแบบชำระค่าใช้จ่าย</a></li>
</ul>
</div>
</div>

------

## **การนำเสนอแรกของคุณ**

Aspose.Slides for Java มีการเผยแพร่ใน Maven repository ของ Aspose เอง ไม่ได้อยู่ใน Maven Central. สร้างโฟลเดอร์สำหรับโครงการ Maven และบันทึก *pom.xml* นี้ลงในนั้น. ไฟล์นี้ประกาศรีโพซิทอรี, เพิ่มไลบรารี, และระบุคลาสที่จะรัน:

```xml
<project xmlns="http://maven.apache.org/POM/4.0.0">
    <modelVersion>4.0.0</modelVersion>
    <groupId>com.example</groupId>
    <artifactId>hello-slides</artifactId>
    <version>1.0</version>

    <properties>
        <maven.compiler.release>11</maven.compiler.release>
        <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
        <exec.mainClass>HelloSlides</exec.mainClass>
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
        <plugins>
            <plugin>
                <groupId>org.apache.maven.plugins</groupId>
                <artifactId>maven-compiler-plugin</artifactId>
                <version>3.15.0</version>
            </plugin>
        </plugins>
    </build>
</project>
```

บันทึกโค้ดนี้เป็น *src/main/java/HelloSlides.java*:

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // สร้างการนำเสนอ. มันมีสไลด์ว่างหนึ่งสไลด์แล้ว.
        Presentation presentation = new Presentation();
        try {
            // ดึงสไลด์แรก.
            ISlide slide = presentation.getSlides().get_Item(0);

            // เพิ่มรูปแบบเมฆและใส่ข้อความลงในนั้น.
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // บันทึกการนำเสนอเป็นไฟล์ PPTX.
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

จากนั้น, เมื่อติดตั้ง JDK 11 หรือรุ่นหลังจากนั้นและ Apache Maven, ให้รันคำสั่งนี้ในโฟลเดอร์ของโครงการ:

```bash
mvn compile exec:java
```

โปรแกรมจะบันทึก *new_presentation.pptx* ในโฟลเดอร์ของโครงการ, โดยมีสไลด์หนึ่งที่มีรูปเมฆพร้อมข้อความ. บน Linux จำเป็นต้องติดตั้ง fontconfig และอย่างน้อยหนึ่งแบบอักษร; ดูที่ [การติดตั้ง](/slides/th/java/installation/#linux). หากไม่มีใบอนุญาต, ไฟล์ที่บันทึกจะมีลายน้ำการประเมิน — ดูที่ [การให้สิทธิ์](/slides/th/java/licensing/). สำหรับวิธีเพิ่มเติมในการสร้างและเติมข้อมูลในการนำเสนอ, ดูที่ [สร้างการนำเสนอ](/slides/th/java/create-presentation/).