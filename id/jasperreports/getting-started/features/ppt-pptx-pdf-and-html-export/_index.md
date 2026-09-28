---
title: "Ekspor PPT, PPTX, PDF, dan HTML"
type: docs
weight: 20
url: /id/jasperreports/ppt-pptx-pdf-and-html-export/
description: "Pilih exporter Aspose.Slides for JasperReports untuk output PPT, PPTX, PDF, atau HTML, ekspor laporan yang sudah terisi dengan exporter tersebut, dan petakan font laporan ke font presentasi."
---
## **Exporter**

Aspose.Slides for JasperReports menambahkan empat exporter ke JasperReports. Masing‑masing mengambil laporan yang sudah terisi (`JasperPrint`) dan mengekspor setiap halaman laporan: sebagai slide dalam PPT dan PPTX, sebagai halaman dalam PDF, dan sebagai gambar SVG dalam satu file HTML.

| Output format | Exporter class |
| :- | :- |
| PPT (PowerPoint 97–2003) | `ASPptExporter` |
| PPTX | `ASPptxExporter` |
| PDF | `ASPdfExporter` |
| HTML | `ASHtmlExporter` |

Kelas‑kelas tersebut berada di paket `com.aspose.slides.jasperreports` dalam file JAR perpustakaan, dan mereka tidak menggunakan Microsoft PowerPoint. Berikan laporan dan file output ke exporter dengan `setParameter` dan `JRExporterParameter`, yang ditandai JasperReports sebagai usang: exporter tidak menerima konfigurasi baru `setExporterInput` dan `setExporterOutput`.

## **Ekspor laporan ke semua empat format**

Program di bawah ini dibangun berdasarkan proyek dari [Your first export](/slides/id/jasperreports/#your-first-export). Program ini mengompilasi dan mengisi *hello.jrxml* satu kali, lalu mengirimkan laporan yang telah terisi ke setiap exporter secara berurutan. Simpan sebagai *src/main/java/ExportAllFormats.java* dalam proyek tersebut:

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
        // Kompilasi dan isi laporan sekali.
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // Ekspor laporan yang sama yang telah diisi dengan masing‑masing exporter.
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

Jalankan dari folder proyek:

```bash
mvn compile exec:java "-Dexec.mainClass=ExportAllFormats"
```

Program ini menyimpan *hello.ppt*, *hello.pptx*, *hello.pdf*, dan *hello.html* di folder proyek. Metode bantuan mengambil `ASAbstractExporter`, kelas dasar dari keempat exporter. Tanpa lisensi, setiap file output menampilkan watermark evaluasi — lihat [Evaluate Aspose.Slides](/slides/id/jasperreports/evaluate-aspose-slides/).

![Laporan yang diekspor ke presentasi tanpa lisensi](ppt-pptx-pdf-and-html-export_1.png)

## **Pemetaan font**

Exporter PPT dan PPTX menuliskan nama font dari desain laporan ke dalam presentasi tanpa perubahan. Ketika suatu elemen teks tidak menyebutkan font, JasperReports menggunakan font bawaan, `SansSerif`, yang merupakan nama font logis Java bukan font yang terpasang. Untuk mengganti nama tersebut, berikan peta dari nama font laporan ke nama font yang Anda inginkan dalam presentasi melalui parameter `ASExporterParameters.PPT_FONT_MAP`. Kunci harus persis cocok dengan nama font dalam laporan, termasuk huruf kapital. Setiap nilai harus berupa font yang dapat ditemukan Java pada mesin yang menjalankan proses ekspor; exporter mengabaikan entri yang fontnya tidak dapat ditemukan oleh Java.

Simpan program ini sebagai *src/main/java/MapFonts.java* dalam proyek yang sama. Program ini mengekspor *hello.jrxml* ke PPTX dengan `SansSerif` diganti menjadi Arial:

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

        // Petakan nama font laporan ke nama font yang akan ditulis ke presentasi.
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

Jalankan dari folder proyek:

```bash
mvn compile exec:java "-Dexec.mainClass=MapFonts"
```

Dalam *hello-arial.pptx* yang disimpan, teks laporan menggunakan Arial alih‑alih `SansSerif`. Pada mesin di mana Java tidak menemukan Arial, seperti sistem Linux yang tidak memilikinya, teks tetap menggunakan `SansSerif`. Pada JasperReports Server, atur peta yang sama melalui properti `fontMap` pada bean parameter ekspor — lihat [Integration with JasperServer](/slides/id/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license).