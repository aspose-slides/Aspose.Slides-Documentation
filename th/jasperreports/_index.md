---
title: Aspose.Slides for JasperReports
second_title: Aspose.Slides for JasperReports
type: docs
weight: 70
url: /th/jasperreports/
keywords:
- เอกสารประกอบ
- JasperReports
- JasperReports Server
- การส่งออกรายงาน
- PowerPoint
- PPT
- PPTX
- Java
- Aspose.Slides
description: "เริ่มต้นที่นี่: ติดตั้ง Aspose.Slides for JasperReports, ส่งออกรายงานแรกเป็น PowerPoint, และหาคู่มือสำหรับการส่งออก, การบูรณาการ JasperReports Server และการสนับสนุน."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for JasperReports" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for JasperReports เพิ่มตัวส่งออก PowerPoint ให้กับ JasperReports Library และ JasperReports Server ทำให้แอปพลิเคชัน Java และเซิร์ฟเวอร์รายงานสามารถบันทึกรายงานที่เติมข้อมูลแล้วเป็นงานพรีเซนเทชันโดยไม่ต้องใช้ Microsoft PowerPoint.

มันส่งออกรายงานที่เติมข้อมูลแล้วเป็น PPT และ PPTX หนึ่งสไลด์ต่อหนึ่งหน้าในรายงาน รวมถึง PDF และ HTML ด้วย.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>เริ่มต้น</b></p>
<hr>
<p>เริ่มต้นใช้งาน</p>
<ul>
<li><a href="/slides/th/jasperreports/installing-aspose-slides-for-jasperreports/">การติดตั้ง</a></li>
<li><a href="/slides/th/jasperreports/product-overview/">ภาพรวมของผลิตภัณฑ์</a></li>
<li><a href="/slides/th/jasperreports/system-requirements/">ข้อกำหนดของระบบ</a></li>
<li><a href="/slides/th/jasperreports/getting-started/">คู่มือเริ่มต้น</a></li>
</ul>
<p>ประเมินผล</p>
<ul>
<li><a href="/slides/th/jasperreports/supported-file-formats/">รูปแบบไฟล์ที่รองรับ</a></li>
<li><a href="/slides/th/jasperreports/evaluate-aspose-slides/">ข้อจำกัดของเวอร์ชันทดลอง</a></li>
<li><a href="/slides/th/jasperreports/licensing/">ไลเซนส์</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>สร้างด้วย Slides</b></p>
<hr>
<p>ส่งออก</p>
<ul>
<li><a href="/slides/th/jasperreports/ppt-pptx-pdf-and-html-export/">ส่งออกเป็น PPT, PPTX, PDF และ HTML</a></li>
<li><a href="/slides/th/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts">แมปฟอนต์</a></li>
<li><a href="/slides/th/jasperreports/integration-with-jasperserver/">การรวมกับ JasperReports Server</a></li>
</ul>
<p>ตัวอย่าง</p>
<ul>
<li><a href="/slides/th/jasperreports/demos-setup/">โครงการสาธิต</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>อ้างอิงและสนับสนุน</b></p>
<hr>
<p>อ้างอิง</p>
<ul>
<li><a href="https://releases.aspose.com/slides/th/jasperreport/release-notes/">บันทึกเวอร์ชัน</a></li>
<li><a href="https://releases.aspose.com/slides/th/jasperreport/">ดาวน์โหลด</a></li>
</ul>
<p>สนับสนุน</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/th/11">ฟอรั่มสนับสนุนฟรี</a></li>
<li><a href="https://helpdesk.aspose.com/">ศูนย์ช่วยเหลือสนับสนุนแบบชำระเงิน</a></li>
</ul>
</div>
</div>

------

## **การส่งออกครั้งแรกของคุณ**

These steps compile a one-line report, fill it, and export it to PPTX with JasperReports 6.16.0 from Maven Central. You need JDK 11 or later and Apache Maven.

1. ดาวน์โหลดไฟล์ ZIP จาก [download page](https://releases.aspose.com/slides/th/jasperreport/) แล้วแตกไฟล์ โฟลเดอร์ *lib* มีโฟลเดอร์ย่อยหนึ่งโฟลเดอร์ต่อช่วงเวอร์ชันของ JasperReports และแต่ละโฟลเดอร์เก็บไฟล์ jar สำหรับช่วงนั้น สำหรับ JasperReports 6.16.0 ให้คัดลอก *lib/JasperReports 6.5.0 - 6.16.0 (JDK 1.6)/aspose.slides.jasperreports.library-26.6.jar* ไปยังโฟลเดอร์โครงการที่ว่างเปล่า.

2. ไฟล์ jar อยู่ใน ZIP แทนที่จะมาจากที่เก็บ Maven ดังนั้นให้ติดตั้งลงในที่เก็บ Maven ท้องถิ่นของคุณ รันคำสั่งต่อไปนี้ในโฟลเดอร์โครงการ:

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

3. บันทึก *pom.xml* นี้ในโฟลเดอร์โครงการ มันจะเพิ่ม JasperReports 6.16.0 และไฟล์ jar ที่คุณติดตั้งไว้ พร้อมระบุคลาสที่จะเรียกใช้ JasperReports 6.16.0 กำหนดการสร้าง iText ที่แก้ไขแล้วซึ่งไม่มีใน Maven Central ดังนั้นไฟล์จึงไม่รวมไว้; ตัวส่งออกของ Aspose ไม่จำเป็นต้องใช้.

```xml
<project xmlns="http://maven.apache.org/POM/4.0.0">
    <modelVersion>4.0.0</modelVersion>
    <groupId>com.example</groupId>
    <artifactId>hello-jasper-export</artifactId>
    <version>1.0</version>

    <properties>
        <maven.compiler.release>11</maven.compiler.release>
        <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
        <exec.mainClass>HelloExport</exec.mainClass>
    </properties>

    <dependencies>
        <dependency>
            <groupId>net.sf.jasperreports</groupId>
            <artifactId>jasperreports</artifactId>
            <version>6.16.0</version>
            <exclusions>
                <exclusion>
                    <groupId>com.lowagie</groupId>
                    <artifactId>itext</artifactId>
                </exclusion>
            </exclusions>
        </dependency>
        <dependency>
            <groupId>com.aspose</groupId>
            <artifactId>aspose-slides-jasperreports</artifactId>
            <version>26.6</version>
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

4. บันทึกการออกแบบรายงานนี้เป็น *hello.jrxml* ในโฟลเดอร์โครงการ มันจะแสดงข้อความหนึ่งบรรทัดในแถบหัวเรื่อง:

```xml
<?xml version="1.0" encoding="UTF-8"?>
<jasperReport xmlns="http://jasperreports.sourceforge.net/jasperreports"
        xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
        xsi:schemaLocation="http://jasperreports.sourceforge.net/jasperreports http://jasperreports.sourceforge.net/xsd/jasperreport.xsd"
        name="Hello" pageWidth="595" pageHeight="842" columnWidth="555"
        leftMargin="20" rightMargin="20" topMargin="20" bottomMargin="20">
    <title>
        <band height="50">
            <staticText>
                <reportElement x="0" y="0" width="555" height="40"/>
                <textElement>
                    <font size="24"/>
                </textElement>
                <text><![CDATA[Hello from JasperReports!]]></text>
            </staticText>
        </band>
    </title>
</jasperReport>
```

5. บันทึกโค้ดนี้เป็น *src/main/java/HelloExport.java* โค้ดจะคอมไพล์การออกแบบ เติมข้อมูลด้วยเรคคอร์ดว่างหนึ่งรายการ และส่งออกรายการผลลัพธ์ด้วย `ASPptxExporter`:

```java
import java.util.HashMap;

import com.aspose.slides.jasperreports.ASPptxExporter;
import net.sf.jasperreports.engine.JREmptyDataSource;
import net.sf.jasperreports.engine.JRExporterParameter;
import net.sf.jasperreports.engine.JasperCompileManager;
import net.sf.jasperreports.engine.JasperFillManager;
import net.sf.jasperreports.engine.JasperPrint;
import net.sf.jasperreports.engine.JasperReport;

public class HelloExport {
    public static void main(String[] args) throws Exception {
        // คอมไพล์การออกแบบรายงานและเติมด้วยระเบียนว่างหนึ่งรายการ.
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // ส่งออกรายงานที่เติมแล้วเป็น PPTX.
        ASPptxExporter exporter = new ASPptxExporter();
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "hello.pptx");
        exporter.exportReport();
    }
}
```

6. รันคำสั่งนี้ในโฟลเดอร์โครงการ:

```bash
mvn compile exec:java
```

โปรแกรมจะบันทึก *hello.pptx* ในโฟลเดอร์โครงการ พร้อมสไลด์หนึ่งสไลด์ที่บรรจุตข้อความของรายงาน คอมไพล์เดอร์ระบุว่าโค้ดใช้ API ที่เลิกใช้แล้ว: ตัวส่งออกรับอินพุตและเอาต์พุตผ่าน `JRExporterParameter` และไม่รองรับการกำหนดค่า `setExporterInput` และ `setExporterOutput` รุ่นใหม่ บน Linux ต้องติดตั้ง fontconfig และอย่างน้อยหนึ่งฟอนต์ มิฉะนั้นการเติมข้อมูลรายงานจะล้มเหลว หากไม่มีไลเซนส์ แต่ละสไลด์จะมีลายน้ำการประเมินผลอยู่ที่ศูนย์กลาง — ดูที่ [Licensing](/slides/th/jasperreports/licensing/). เพื่อส่งออกเป็น PPT, PDF หรือ HTML ดูที่ [PPT, PPTX, PDF and HTML Export](/slides/th/jasperreports/ppt-pptx-pdf-and-html-export/).