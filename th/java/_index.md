---
title: Aspose.Slides สำหรับ Java
second_title: Aspose.Slides สำหรับ Java
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
description: "เริ่มต้นที่นี่: ติดตั้ง Aspose.Slides for Java, สร้างงานนำเสนอแรก, และค้นหาคู่มือสำหรับงานทั่วไป, การปรับใช้และอ้างอิง API."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Java คือไลบรารีคลาสสำหรับสร้าง, อ่าน, แก้ไขและแปลงงานนำเสนอ PowerPoint และ OpenDocument ในแอปพลิเคชัน Java โดยไม่ต้องใช้ Microsoft PowerPoint.

ไลบรารีนี้สามารถโหลดและบันทึกไฟล์ PPT, PPTX, PPS, POT และ ODP รวมถึงรูปแบบที่มีมาโครและแม่แบบได้ และส่งออกเป็น PDF, XPS, HTML, SVG, TIFF, Markdown และรูปภาพ.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>เริ่มต้น</b></p>
<hr>
<p>เริ่มต้นการใช้งาน</p>
<ul>
<li><a href="/slides/th/java/installation/">Installation</a></li>
<li><a href="/slides/th/java/create-presentation/">Create your first presentation</a></li>
<li><a href="/slides/th/java/system-requirements/">System requirements</a></li>
<li><a href="/slides/th/java/getting-started/">Getting started guide</a></li>
</ul>
<p>ประเมิน</p>
<ul>
<li><a href="/slides/th/java/supported-file-formats/">Supported file formats</a></li>
<li><a href="/slides/th/java/features-overview/">Features overview</a></li>
<li><a href="/slides/th/java/evaluate-aspose-slides/">Trial limitations</a></li>
<li><a href="/slides/th/java/licensing/">Licensing</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>สร้างด้วย Slides</b></p>
<hr>
<p>งานทั่วไป</p>
<ul>
<li><a href="/slides/th/java/open-presentation/">Open a presentation</a></li>
<li><a href="/slides/th/java/save-presentation/">Save a presentation</a></li>
<li><a href="/slides/th/java/convert-powerpoint-to-pdf/">Convert to PDF</a></li>
<li><a href="/slides/th/java/convert-slide/">Render slides as images</a></li>
<li><a href="/slides/th/java/manage-text/">Edit text and shapes</a></li>
</ul>
<p>เวิร์กฟลอว์ของ Slides</p>
<ul>
<li><a href="/slides/th/java/powerpoint-charts/">Charts</a></li>
<li><a href="/slides/th/java/powerpoint-animation/">Animations</a></li>
<li><a href="/slides/th/java/manage-media-files/">Audio and video</a></li>
<li><a href="/slides/th/java/presentation-design/">Slide design</a></li>
<li><a href="/slides/th/java/merge-presentation/">Merge presentations</a></li>
</ul>
<p>ตัวอย่าง</p>
<ul>
<li><a href="/slides/th/java/examples/">Examples by slide element</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Java">Examples on GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>ปรับใช้และสนับสนุน</b></p>
<hr>
<p>ปรับใช้</p>
<ul>
<li><a href="/slides/th/java/system-requirements/#linux">Linux prerequisites</a></li>
<li><a href="/slides/th/java/how-to-run-aspose-slides-in-docker/">Run in Docker</a></li>
<li><a href="/slides/th/java/deploy-fonts/">Fonts</a></li>
<li><a href="/slides/th/java/security/">Security</a></li>
</ul>
<p>อ้างอิง</p>
<ul>
<li><a href="https://reference.aspose.com/slides/th/java/">API reference</a></li>
<li><a href="https://releases.aspose.com/slides/th/java/release-notes/">Release notes</a></li>
<li><a href="/slides/th/java/known-issues/">Known issues</a></li>
<li><a href="/slides/th/java/api-limitations/">Output metadata limitations</a></li>
<li><a href="https://releases.aspose.com/slides/th/java/">Download</a></li>
</ul>
<p>สนับสนุน</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/th/11">Free support forum</a></li>
<li><a href="https://helpdesk.aspose.com/">Paid support helpdesk</a></li>
</ul>
</div>
</div>

------

<a name="your-first-presentation"></a>

## **งานนำเสนอแรกของคุณ**

Aspose.Slides for Java ถูกเผยแพร่ใน Maven repository ของ Aspose เอง ไม่ได้อยู่ใน Maven Central. สร้างโฟลเดอร์สำหรับโครงการ Maven แล้วบันทึก *pom.xml* นี้ไว้ในนั้น. ไฟล์นี้ประกาศที่เก็บ, เพิ่มไลบรารี, และระบุคลาสที่จะเรียกใช้:

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
        // สร้างงานนำเสนอ. มีสไลด์เปล่าหนึ่งสไลด์อยู่แล้ว.
        Presentation presentation = new Presentation();
        try {
            // ดึงสไลด์แรก.
            ISlide slide = presentation.getSlides().get_Item(0);

            // เพิ่มรูปร่างเมฆและใส่ข้อความลงไป.
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // บันทึกงานนำเสนอเป็นไฟล์ PPTX.
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

จากนั้น, เมื่อมี JDK 11 หรือรุ่นใหม่กว่าและ Apache Maven ติดตั้งแล้ว, ให้รันคำสั่งนี้ในโฟลเดอร์โครงการ:

```bash
mvn compile exec:java
```

โปรแกรมจะบันทึก *new_presentation.pptx* ไว้ในโฟลเดอร์โครงการ, โดยมีสไลด์หนึ่งที่มีรูปเมฆพร้อมข้อความ. ใน Linux จำเป็นต้องติดตั้ง fontconfig และอย่างน้อยหนึ่งแบบอักษร; ดูที่ [Installation](/slides/th/java/installation/#linux). หากไม่มีลิขสิทธิ์ไฟล์ที่บันทึกจะมีลายน้ำการประเมินค่า — ดูที่ [Licensing](/slides/th/java/licensing/). สำหรับวิธีเพิ่มเติมในการสร้างและเติมเนื้อหาในงานนำเสนอ, ดูที่ [Create Presentations](/slides/th/java/create-presentation/).