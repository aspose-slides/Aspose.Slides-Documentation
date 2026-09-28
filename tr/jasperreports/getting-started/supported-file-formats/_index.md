---
title: Desteklenen Dosya Biçimleri
type: docs
weight: 20
url: /tr/jasperreports/supported-file-formats/
description: "Aspose.Slides for JasperReports'un girdi olarak neyi kabul ettiğini ve raporları hangi dosya biçimlerine dışa aktardığını görün."
---
## **Giriş**

Aspose.Slides for JasperReports raporları dışa aktarır; mevcut sunumları dönüştürmez. Dışa aktarıcıları, doldurulmuş bir JasperReports raporu (`JasperPrint`) alır; bu, `JasperFillManager` sonucudur veya *.jrprint* dosyasından yüklenmiş bir doldurulmuş rapordur.

## **Çıktı Biçimleri**

Aşağıdaki tablo, Aspose.Slides for JasperReports'un bir raporu dışa aktardığı biçimleri ve her birini yazan dışa aktarıcı sınıfını listeler.

|**Biçim**|**Açıklama**|**Dışa Aktarıcı**|
| :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint 97–2003 sunumu; rapor sayfası başına bir slayt|`ASPptExporter`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint sunumu (Office Open XML); rapor sayfası başına bir slayt|`ASPptxExporter`|
|[PDF](https://docs.fileformat.com/pdf/)|Taşınabilir Belge Biçimi; rapor sayfası başına bir PDF sayfası|`ASPdfExporter`|
|[HTML](https://docs.fileformat.com/web/html/)|Her rapor sayfası için bir SVG görüntüsü içeren tek bir HTML dosyası|`ASHtmlExporter`|

PPS ve PPSX slayt gösterisi biçimleri için bir dışa aktarıcı yoktur. PPTX dışa aktarımına *.ppsx* dosya adı vermek hâlâ bir PPTX sunumu üretir, slayt gösterisi değil. Her dışa aktarıcının nasıl kullanıldığını görmek için, [PPT, PPTX, PDF ve HTML Dışa Aktarma](/slides/tr/jasperreports/ppt-pptx-pdf-and-html-export/) sayfasına bakın.