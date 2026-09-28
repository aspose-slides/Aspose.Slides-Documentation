---
title: การส่งออก PPT, PPTX, PDF และ HTML
type: docs
weight: 20
url: /th/jasperreports/ppt-pptx-pdf-and-html-export/
description: "เลือกตัวส่งออก Aspose.Slides for JasperReports สำหรับการส่งออกเป็น PPT, PPTX, PDF หรือ HTML, ส่งออกรายงานที่เติมข้อมูลแล้วด้วยมัน, และแมปฟอนต์ของรายงานไปยังฟอนต์ของการนำเสนอ."
---
## **ตัวส่งออก**

Aspose.Slides for JasperReports เพิ่มตัวส่งออกสี่ตัวให้กับ JasperReports แต่ละตัวรับรายงานที่เติมข้อมูลแล้ว (`JasperPrint`) และส่งออกทุกหน้าของรายงาน: เป็นสไลด์ใน PPT และ PPTX, เป็นหน้าใน PDF, และเป็นภาพ SVG ในไฟล์ HTML เดียว

| รูปแบบการส่งออก | คลาสตัวส่งออก |
| :- | :- |
| PPT (PowerPoint 97–2003) | `ASPptExporter` |
| PPTX | `ASPptxExporter` |
| PDF | `ASPdfExporter` |
| HTML | `ASHtmlExporter` |

คลาสเหล่านี้อยู่ในแพ็กเกจ `com.aspose.slides.jasperreports` ของไฟล์ jar ไลบรารี และไม่ได้ใช้ Microsoft PowerPoint ส่งรายงานและไฟล์ผลลัพธ์ไปยังตัวส่งออกด้วย `setParameter` และ `JRExporterParameter` ซึ่ง JasperReports ระบุว่าเลิกใช้แล้ว: ตัวส่งออกไม่รับการกำหนดค่าใหม่ `setExporterInput` และ `setExporterOutput`

## **ส่งออกรายงานเป็นสี่รูปแบบทั้งหมด**

โปรแกรมต่อไปนี้สร้างบนพื้นฐานของโครงการจาก [Your first export](/slides/th/jasperreports/#your-first-export) มันคอมไพล์และเติม *hello.jrxml* ครั้งเดียว แล้วจึงส่งรายงานที่เติมแล้วไปยังแต่ละตัวส่งออกตามลำดับ บันทึกเป็น *src/main/java/ExportAllFormats.java* ในโครงการนั้น:

```java
import java.util.HashMap;

import com.aspose.slides.jasperreports.ASAbstractExporter;
import com.aspose.slides.jasperreports.ASHtmlExporter;
import com.aspose.slides.jasperreports.ASPdfExporter;
import com.aspose.slides.jasperreports.ASPptExporter;
import com.aspose.slides.jasperreports.ASPptxExporter;
import net.sf.jasperreports.engine.JREmptyDataSource;
import net.sf.jasperreports.engine.JRException;
import net.sf.jasperreports.engine.JRExporterParameter;
import net.sf.jasperreports.engine.JasperCompileManager;
import net.sf.jasperreports.engine.JasperFillManager;
import net.sf.jasperreports.engine.JasperPrint;
import net.sf.jasperreports.engine.JasperReport;

public class ExportAllFormats {
    public static void main(String[] args) throws Exception {
        // คอมไพล์และเติมข้อมูลรายงานหนึ่งครั้ง.
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // ส่งออกรายงานที่เติมข้อมูลแล้วเดียวกันด้วยตัวส่งออกแต่ละตัว.
        export(new ASPptExporter(), jasperPrint, "hello.ppt");
        export(new ASPptxExporter(), jasperPrint, "hello.pptx");
        export(new ASPdfExporter(), jasperPrint, "hello.pdf");
        export(new ASHtmlExporter(), jasperPrint, "hello.html");
    }

    private static void export(ASAbstractExporter exporter, JasperPrint jasperPrint, String outputFileName) throws JRException {
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, outputFileName);
        exporter.exportReport();
    }
}
```

เรียกใช้จากโฟลเดอร์โครงการ:

```bash
mvn compile exec:java "-Dexec.mainClass=ExportAllFormats"
```

โปรแกรมบันทึก *hello.ppt*, *hello.pptx*, *hello.pdf* และ *hello.html* ในโฟลเดอร์โครงการ วิธีการช่วยเหลือรับ `ASAbstractExporter` ซึ่งเป็นคลาสพื้นฐานของตัวส่งออกสี่ตัวทั้งหมด หากไม่มีใบอนุญาต ไฟล์ผลลัพธ์ทุกไฟล์จะมีลายน้ำการประเมิน — ดูที่ [Evaluate Aspose.Slides](/slides/th/jasperreports/evaluate-aspose-slides/)

![รายงานที่ส่งออกเป็นการนำเสนอโดยไม่มีใบอนุญาต](ppt-pptx-pdf-and-html-export_1.png)

## **แมปฟอนต์**

PPT และ PPTX exporters จะเขียนชื่อฟอนต์ของการออกแบบรายงานลงในงานนำเสนอโดยไม่เปลี่ยนแปลง เมื่อองค์ประกอบข้อความไม่มีการระบุฟอนต์ JasperReports จะใช้ฟอนต์เริ่มต้นของมันคือ `SansSerif` ซึ่งเป็นชื่อฟอนต์เชิงตรรกะของ Java ไม่ใช่ฟอนต์ที่ติดตั้งไว้ เพื่อเปลี่ยนชื่อเหล่านี้ ให้ส่งแผนที่จากชื่อฟอนต์ของรายงานไปยังชื่อฟอนต์ที่คุณต้องการในงานนำเสนอผ่านพารามิเตอร์ `ASExporterParameters.PPT_FONT_MAP` คีย์ต้องตรงกับชื่อฟอนต์ในรายงานอย่างแม่นยำ รวมถึงตัวพิมพ์ใหญ่และเล็ก แต่ละค่าต้องเป็นฟอนต์ที่ Java พบบนเครื่องที่ทำการส่งออก; ตัวส่งออกจะละเว้นรายการที่ Java ไม่พบฟอนต์

บันทึกโปรแกรมนี้เป็น *src/main/java/MapFonts.java* ในโครงการเดียวกัน มันส่งออก *hello.jrxml* ไปยัง PPTX โดยแทนที่ `SansSerif` ด้วย Arial:

```java
import java.util.HashMap;
import java.util.Map;

import com.aspose.slides.jasperreports.ASExporterParameters;
import com.aspose.slides.jasperreports.ASPptxExporter;
import net.sf.jasperreports.engine.JREmptyDataSource;
import net.sf.jasperreports.engine.JRExporterParameter;
import net.sf.jasperreports.engine.JasperCompileManager;
import net.sf.jasperreports.engine.JasperFillManager;
import net.sf.jasperreports.engine.JasperPrint;
import net.sf.jasperreports.engine.JasperReport;

public class MapFonts {
    public static void main(String[] args) throws Exception {
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // แมปชื่อฟอนต์ของรายงานไปยังชื่อฟอนต์ที่จะเขียนลงในงานนำเสนอ.
        Map<String, String> fontMap = new HashMap<String, String>();
        fontMap.put("SansSerif", "Arial");

        ASPptxExporter exporter = new ASPptxExporter();
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "hello-arial.pptx");
        exporter.setParameter(ASExporterParameters.PPT_FONT_MAP, fontMap);
        exporter.exportReport();
    }
}
```

เรียกใช้จากโฟลเดอร์โครงการ:

```bash
mvn compile exec:java "-Dexec.mainClass=MapFonts"
```

ในไฟล์ *hello-arial.pptx* ที่บันทึกไว้ ข้อความของรายงานใช้ Arial แทน `SansSerif` บนเครื่องที่ Java ไม่พบ Arial เช่น ระบบ Linux ที่ไม่มีฟอนต์นี้ ข้อความจะคงไว้เป็น `SansSerif` บน JasperReports Server ให้ตั้งค่าแผนที่เดียวกันผ่านคุณสมบัติ `fontMap` ของ bean พารามิเตอร์การส่งออก — ดูที่ [Integration with JasperServer](/slides/th/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license).