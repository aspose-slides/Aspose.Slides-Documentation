---
title: PPT, PPTX, PDF ve HTML Dışa Aktarma
type: docs
weight: 20
url: /tr/jasperreports/ppt-pptx-pdf-and-html-export/
description: "PPT, PPTX, PDF veya HTML çıktısı için Aspose.Slides for JasperReports dışa aktarıcısını seçin, doldurulmuş bir raporu bununla dışa aktarın ve rapor yazı tiplerini sunum yazı tiplerine eşleştirin."
---
## **Dışa Aktarıcılar**

Aspose.Slides for JasperReports, JasperReports'a dört dışa aktarıcı ekler. Her biri doldurulmuş bir raporu (`JasperPrint`) alır ve her rapor sayfasını dışa aktarır: PPT ve PPTX'te bir slayt olarak, PDF'te bir sayfa olarak ve tek bir HTML dosyasında SVG görüntüsü olarak.

| Çıktı formatı | Dışa aktarıcı sınıfı |
| :- | :- |
| PPT (PowerPoint 97–2003) | `ASPptExporter` |
| PPTX | `ASPptxExporter` |
| PDF | `ASPdfExporter` |
| HTML | `ASHtmlExporter` |

Sınıflar, kütüphane jar'ının `com.aspose.slides.jasperreports` paketinde bulunur ve Microsoft PowerPoint kullanmazlar. Raporu ve çıktı dosyasını bir dışa aktarıcıya `setParameter` ve `JRExporterParameter` ile iletin; JasperReports bu parametreleri artık kullanılmadı olarak işaretler: dışa aktarıcılar yeni `setExporterInput` ve `setExporterOutput` yapılandırmasını kabul etmez.

## **Bir raporu dört formatta da dışa aktar**

Aşağıdaki program, [İlk dışa aktarımınız](/slides/tr/jasperreports/#your-first-export) projesi üzerine inşa edilmiştir. *hello.jrxml* dosyasını bir kez derler ve doldurur, ardından doldurulmuş raporu sırayla her dışa aktarıcıya iletir. Bu projede *src/main/java/ExportAllFormats.java* olarak kaydedin:

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
        // Raporu bir kez derleyin ve doldurun.
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // Aynı doldurulmuş raporu her dışa aktarıcı ile dışa aktar.
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

Projeyi klasöründen çalıştırın:

```bash
mvn compile exec:java "-Dexec.mainClass=ExportAllFormats"
```

Program, proje klasöründe *hello.ppt*, *hello.pptx*, *hello.pdf* ve *hello.html* dosyalarını kaydeder. Yardımcı metot `ASAbstractExporter` alır; bu, dört dışa aktarıcının temel sınıfıdır. Lisans olmadan, her çıktı dosyası değerlendirme filigranını içerir — [Aspose.Slides'i Değerlendirin](/slides/tr/jasperreports/evaluate-aspose-slides/).

![Lisans olmadan bir sunuma dışa aktarılmış rapor](ppt-pptx-pdf-and-html-export_1.png)

## **Yazı tiplerini eşleştir**

PPT ve PPTX dışa aktarıcıları, rapor tasarımının yazı tipi adlarını sunuma aynı şekilde yazar. Bir metin öğesi hiçbir yazı tipi belirtmezse, JasperReports varsayılan yazı tipi olan `SansSerif`'i kullanır; bu, yüklü bir yazı tipi değil, Java mantıksal bir yazı tipi adıdır. Bu adları değiştirmek için, rapor yazı tipi adlarından sunumda kullanılmasını istediğiniz yazı tipi adlarına bir harita geçirin; bu harita `ASExporterParameters.PPT_FONT_MAP` parametresinde verilir. Anahtarlar, rapordaki yazı tipi adlarıyla tam olarak eşleşmelidir, büyük/küçük harf duyarlılığı dahil. Her değer, dışa aktarmayı gerçekleştiren makinede Java tarafından bulunabilen bir yazı tipi olmalıdır; dışa aktarıcılar Java'nın bulamadığı bir yazı tipine sahip girdiyi yok sayar.

Bu programı aynı projede *src/main/java/MapFonts.java* olarak kaydedin. *hello.jrxml* dosyasını `SansSerif` yerine Arial kullanarak PPTX'e dışa aktarır:

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

        // Rapor yazı tipi adını, sunuma yazılacak yazı tipi adıyla eşleştirin.
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

Projeyi klasöründen çalıştırın:

```bash
mvn compile exec:java "-Dexec.mainClass=MapFonts"
```

Kaydedilen *hello-arial.pptx* dosyasında raporun metni `SansSerif` yerine Arial kullanır. Java'nın Arial bulamadığı bir makinede, örneğin Arial'ı yüklenmemiş bir Linux sisteminde, metin `SansSerif` olarak kalır. JasperReports Server'da aynı haritayı, dışa aktarma parametreleri bean'inin `fontMap` özelliği aracılığıyla ayarlayın — [JasperServer ile Entegrasyon](/slides/tr/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license).