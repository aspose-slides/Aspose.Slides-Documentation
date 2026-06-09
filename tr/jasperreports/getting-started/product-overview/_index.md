---
title: Ürün Genel Bakış
type: docs
weight: 10
url: /tr/jasperreports/product-overview/
---
![Aspose.Slides for JasperReports](product-overview_1.png)

## **Aspose.Slides for JasperReports'e Hoş Geldiniz!**

Aspose.Slides for JasperReports, Java uygulamalarında JasperReports'dan Microsoft PowerPoint Sunumu (PPT) ve Microsoft PowerPoint Gösterimi (PPS) biçimlerine raporları kolayca dışa aktarmak isteyen geliştiriciler için özel olarak tasarlanmış ve geliştirilmiş bir kütüphanedir. Tüm rapor özellikleri, Microsoft PowerPoint sunumlarına en yüksek doğrulukla dönüştürülür. Aspose.Slides for JasperReports, JasperReports 5+ desteği içerir.

## **Ürün Açıklaması**
JasperReports ve JasperServer, raporları Microsoft PowerPoint sunumları olarak dışa aktarmak için yerleşik yeteneklere sahip değildir, ancak Aspose.Slides for JasperReports size iki ek dışa aktarma formatı sunar:

- PPT – Aspose.Slides aracılığıyla PowerPoint Sunumu
- PPS – Aspose.Slides aracılığıyla PowerPoint Gösterimi
- PPTX – Aspose.Slides aracılığıyla PowerPoint Sunumu
- PPSX – Aspose.Slides aracılığıyla PowerPoint Gösterimi

Aspose.Slides for JasperReports, %100 saf Java kütüphanelerimiz olan Aspose.Slides for Java ve Aspose.Metafiles for Java'ı dahili olarak kullanır; bu kütüphaneler sunucu tarafı sunumları ve metafile işleme konusunda dünya sınıfıdır.

Aspose.Slides for JasperReports, herhangi bir raporu PPT veya PPS formatında dışa aktarmayı mümkün kılar.

### **Çıktı Örneği**
ASPptExporter sınıfı, ASAbstractExporter sınıfını genişletir, böylece diğer standart dışa aktarıcılar gibi kullanılabilir. Bu kısa örnek, tipik kodu ve MS PowerPoint'te görüntülenen bir raporun ekran görüntüsünü gösterir. Ayrıntılı örnekler sağlanan demo raporlarında bulunabilir.

``` java
File sourceFile = new File(fileName); 
JasperPrint jasperPrint = (JasperPrint)JRLoader.loadObject(sourceFile);
File destFile = new File(sourceFile.getParent(), jasperPrint.getName() + ".ppt");
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, destFile.toString());
exporter.exportReport();
```

**JasperReports xmldatasource demosu ile oluşturulan sunum** 

![JasperReports ile oluşturulan sunum](product-overview_2.png)