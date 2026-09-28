---
title: Ürün Genel Bakışı
type: docs
weight: 10
url: /tr/jasperreports/product-overview/
description: "Aspose.Slides for JasperReports'ın ne yaptığını, hangi JasperReports sürümlerini ve çıktı formatlarını desteklediğini ve iki jar'ının ne amaçla kullanıldığını öğrenin."
---
![Aspose.Slides for JasperReports](product-overview_1.png)

## **Ürün Açıklaması**

Aspose.Slides for JasperReports, Microsoft PowerPoint olmadan, JasperReports'tan PowerPoint sunumlarına raporları dışa aktarır; Java uygulamalarında ve JasperReports Server'da çalışır. JasperReports 3.7.2'den 6.16.0'e kadar destekler; her sürüm aralığı için ayrı bir jar bulunur — bakınız [Installing Aspose.Slides for JasperReports](/slides/tr/jasperreports/installing-aspose-slides-for-jasperreports/).

Doldurulmuş bir raporu dört formata dışa aktarır, rapor sayfası başına bir slayt veya sayfa:

- PPT – PowerPoint 97–2003 sunumu
- PPTX – PowerPoint sunumu (Office Open XML)
- PDF
- HTML

Ürünün iki bölümü vardır:

- Kütüphane jar'ı, JasperReports Library'ye `ASPptExporter`, `ASPptxExporter`, `ASPdfExporter` ve `ASHtmlExporter` dışa aktarıcılarını ekler.
- Sunucu jar'ı aynı dört format için dışa aktarma eylemleri sağlar; bunları JasperReports Server'da kaydolursunuz — bakınız [Integration with JasperServer](/slides/tr/jasperreports/integration-with-jasperserver/).

### **Çıktı Örneği**

Dışa aktarıcılar, JasperReports'ın kendi dışa aktarıcı sınıflarını genişletir ve aynı şekilde kullanılır: doldurulmuş raporu ve çıktı dosyasını onlara verin, ardından `exportReport` metodunu çağırın. Raporu dolduran ve PPTX olarak dışa aktaran tam bir program için bakınız [Your first export](/slides/tr/jasperreports/#your-first-export); dört formatın tamamı için bakınız [PPT, PPTX, PDF and HTML Export](/slides/tr/jasperreports/ppt-pptx-pdf-and-html-export/).

![Lisans olmadan bir sunuma dışa aktarılmış rapor, slaytın ortasında değerlendirme filigranı ile](product-overview_2.png)