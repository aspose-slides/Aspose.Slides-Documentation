---
title: .NET'te Sunumlarda Grafik Çalışma Sayfası Formüllerini Uygula
linktitle: Çalışma Sayfası Formülleri
type: docs
weight: 70
url: /tr/net/chart-worksheet-formulas/
keywords:
- grafik çalışma sayfası
- grafik çalışma sayfası
- grafik formülü
- çalışma sayfası formülü
- elektronik tablo formülü
- veri kaynağı
- mantıksal sabit
- sayısal sabit
- dize sabiti
- hata sabiti
- aritmetik sabit
- karşılaştırma operatörü
- A1 stili
- R1C1 stili
- önceden tanımlı fonksiyon
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET grafik çalışma sayfalarında Excel tarzı formülleri uygulayın ve PPT ve PPTX dosyalarında raporları otomatikleştirin."
---
## **Genel Bakış**

Bir grafik çalışma sayfası, bir sunumdaki grafiğin veri kaynağıdır. Kategori ve seri adlarını, grafiğin gösterdiği sayısal değerlerle birlikte depolar. Aspose.Slides'te bu çalışma sayfası, grafik verileriyle programlı olarak çalışmanıza olanak tanıyan grafik veri çalışma kitabı aracılığıyla erişilebilir.

Bu makale, hücre değerlerinin manuel olarak girilmesi yerine otomatik olarak hesaplanıp güncellenebilmesi için grafik verilerindeki çalışma sayfası formüllerinin nasıl kullanılacağını açıklar. Formüllerin nasıl atanacağını, hem A1‑stil hem de R1C1‑stil referansların nasıl kullanılacağını, çalışma kitabı formüllerinin yeniden hesaplanmasını ve sunumlardaki grafik çalışma sayfalarında kullanılabilen sabitler, operatörler, hücre referansları ve önceden tanımlı fonksiyonlar ile nasıl çalışılacağını gösterir.

## **Sunumlardaki Grafik Çalışma Sayfası Formülleri Hakkında**
**Grafik çalışma sayfası** (veya grafik çalışma sayfası) bir sunumdaki grafiğin veri kaynağıdır. Grafik çalışma sayfası, grafikte grafiksel olarak gösterilen verileri içerir. PowerPoint'te bir grafik oluşturduğunuzda, bu grafiğe bağlı çalışma sayfası otomatik olarak da oluşturulur. Grafik çalışma sayfası, çizgi grafik, çubuk grafik, sunburst grafik, pasta grafik vb. tüm grafik türleri için oluşturulur. PowerPoint’te grafik çalışma sayfasını görmek için grafiğe çift tıklamalısınız:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

Grafik çalışma sayfası, grafik öğelerinin adlarını (Kategori Adı: *Category1*, Seri Adı) ve bu kategorilere ve serilere uygun sayısal verileri içeren bir tabloyu barındırır. Varsayılan olarak, yeni bir grafik oluşturduğunuzda - grafik çalışma sayfası verileri varsayılan verilerle ayarlanır. Ardından çalışma sayfası verilerini manuel olarak değiştirebilirsiniz.

Genellikle grafik, (ör. finansal analistler, bilimsel analistler) diğer hücrelerdeki değerlerden veya diğer dinamik verilerden hesaplanan hücreler içeren karmaşık verileri temsil eder. Hücrenin değerini manuel olarak hesaplayıp hücreye sabit olarak kaydetmek, gelecekte değişikliği zorlaştırır. Belirli bir hücrenin değerini değiştirirseniz, ona bağımlı tüm hücrelerin de güncellenmesi gerekir. Ayrıca tablo verileri diğer tablolardan gelen verilere bağımlı olabilir; bu da güncellenmesi kolay ve esnek bir sunum veri şeması ihtiyacını doğurur.

**Grafik çalışma sayfası formülü** bir ifadedir ve grafik çalışma sayfası verilerini otomatik olarak hesaplayıp günceller. Çalışma sayfası formülü, belirli bir hücre ya da hücre kümesi için veri hesaplama mantığını tanımlar. Çalışma sayfası formülü bir matematik ya da mantıksal formüldür; hücre referansları, matematik fonksiyonları, mantıksal operatörler, aritmetik operatörler, dönüşüm fonksiyonları, dize sabitleri vb. kullanır. Formül tanımı bir hücreye yazılır ve bu hücre basit bir değer içermez. Çalışma sayfası formülü değeri hesaplar ve geri döndürür; bu değer daha sonra hücreye atanır. Sunumlardaki grafik çalışma sayfası formülleri aslında Excel formülleriyle aynıdır ve uygulanmaları için aynı varsayılan fonksiyonlar, operatörler ve sabitler desteklenir.

[**Aspose.Slides**](https://products.aspose.com/slides/tr/net/) içinde grafik çalışma sayfası 
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook) özelliğiyle temsil edilir. 
Çalışma sayfası formülü, 
[**IChartDataCell.Formula**](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatacell/properties/formula) özelliğiyle atanabilir ve değiştirilebilir. 
Aspose.Slides'te formüller için aşağıdaki işlevsellik desteklenir:

- Mantıksal sabitler
- Sayısal sabitler
- Dize sabitleri
- Hata sabitleri
- Aritmetik operatörler
- Karşılaştırma operatörleri
- A1‑stil hücre referansları
- R1C1‑stil hücre referansları
- Önceden tanımlı fonksiyonlar

Genellikle, çalışma sayfaları son hesaplanan formül değerlerini saklar. Sunum yüklendikten sonra grafik verileri değiştirilmemişse, **IChartDataCell.Value** özelliği bu değerleri okuma sırasında döndürür. Ancak çalışma sayfası verileri değiştirilmişse, **ChartDataCell.Value** özelliği okunurken desteklenmeyen formüller için **CellUnsupportedDataException** hatası fırlatılır. Bunun nedeni, formüller başarılı bir şekilde ayrıştırıldığında hücre bağımlılıklarının belirlenmesi ve son değerlerin doğruluğunun teyit edilmesidir. Formül ayrıştırılamazsa, hücre değerinin doğruluğu garanti edilemez.

## **Bir Sunuma Grafik Çalışma Sayfası Formülü Ekleme**
İlk olarak, yeni bir sunumun ilk slaytına 
[IShapeCollection.Shapes.AddChart](https://reference.aspose.com/slides/tr/net/aspose.slides.ishapecollection/addchart/methods/1) 
metodu ile örnek veri içeren bir grafik ekleyin. Grafiğin çalışma sayfası otomatik olarak oluşturulur ve 
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdata/properties/chartdataworkbook) özelliğiyle erişilebilir:

``` csharp

using (var presentation = new Presentation())

{

    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 150, 150, 500, 300);

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // ...

}
```

Hücrelere, **Object** türündeki 
[**IChartDataCell.Value**](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatacell/properties/value) 
özelliğiyle herhangi bir değer atayabilirsiniz:

``` csharp

workbook.GetCell(0, "F2").Value = -2.5;

workbook.GetCell(0, "G3").Value = 6.3;

workbook.GetCell(0, "H4").Value = 3;

```

Şimdi hücreye formül yazmak için 
[**IChartDataCell.Formula**](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatacell/properties/formula) 
özelliğini kullanabilirsiniz:

``` csharp
workbook.GetCell(0, "B2").Formula = "F2+G3+H4+1";
```

*Not*: [**IChartDataCell.Formula**](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatacell/properties/formula) özelliği A1‑stil hücre referanslarını ayarlamak için kullanılır.

R1C1‑stil hücre referansı ayarlamak için 
[**IChartDataCell.R1C1Formula**](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatacell/properties/r1c1formula) 
özelliğini kullanabilirsiniz:

``` csharp
workbook.GetCell(0, "C2").R1C1Formula = "R[1]C[4]/R[2]C[5]";
```

Daha sonra çalışma kitabındaki tüm formülleri hesaplamak ve ilgili hücre değerlerini güncellemek için 
[**IChartDataWorkbook.CalculateFormulas**](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/chartdataworkbook/methods/calculateformulas) 
metodunu kullanın:

``` csharp
workbook.CalculateFormulas();

object value1 = workbook.GetCell(0, "B2"); // 7.8

object value2 = workbook.GetCell(0, "C2"); // 2.1

```

## **Mantıksal Sabitler**
Formüllerde *FALSE* ve *TRUE* gibi mantıksal sabitleri kullanabilirsiniz:

## **Sayısal Sabitler**
Grafik çalışma sayfası formülü oluşturmak için sayıları ortak ya da bilimsel gösterimde kullanabilirsiniz:

## **Dize Sabitleri**
Dize (veya literal) sabiti, olduğu gibi kullanılan ve değişmeyen belirli bir değerdir. Dize sabitleri tarih, metin, sayı vb. olabilir:

## **Hata Sabitleri**
Bazen formülle sonucu hesaplamak mümkün değildir. Bu durumda hücrede değeri yerine hata kodu gösterilir. Her hata tipinin kendine özgü bir kodu vardır:

- #DIV/0! - formül sıfıra bölmeye çalışıyor.
- #GETTING_DATA - değeri hâlâ hesaplanırken hücrede görünebilir.
- #N/A - bilgi eksik ya da mevcut değil. Nedenler: formülde kullanılan hücreler boş, ekstra boşluk karakteri, yazım hatası vb.
- #NAME? - belirli bir hücre ya da diğer formül nesnesi adıyla bulunamıyor.
- #NULL! - formülde hata var, örneğin (,) veya iki nokta üst üste (:) yerine boşluk karakteri kullanılmış.
- #NUM! - formüldeki sayısal değer geçersiz, çok uzun ya da çok küçük vb.
- #REF! - geçersiz hücre referansı.
- #VALUE! - beklenmeyen değer türü. Örneğin, sayısal hücreye dize değeri atandı.

## **Aritmetik Operatörler**
Grafik çalışma sayfası formüllerinde tüm aritmetik operatörleri kullanabilirsiniz:

|**Operatör**|**Anlam**|**Örnek**|
| :- | :- | :- |
|+ (artı)|Toplama ya da tekli artı|2 + 3|
|- (eksi)|Çıkarma ya da negatif|2 - 3<br>-3|
|* (yıldız)|Çarpma|2 * 3|
|/ (bölü)|Bölme|2 / 3|
|% (yüzde)|Yüzde|30%|
|^ (üssü)|Üs alma|2 ^ 3|

*Not*: Değerlendirme sırasını değiştirmek için formülün önce hesaplanması gereken kısmını parantez içine alın.

## **Karşılaştırma Operatörleri**
Hücre değerlerini karşılaştırma operatörleriyle kıyaslayabilirsiniz. Bu operatörler kullanılarak iki değer karşılaştırıldığında sonuç mantıksal bir değer, yani *TRUE* ya da FALSE olur:

|**Operatör**|**Anlam**|**Örnek**|
| :- | :- | :- |
|= (eşittir)|Eşit|A2 = 3|
|<> (eşit değildir)|Eşit değil|A2 <> 3|
|> (büyüktür)|Büyük|A2 > 3|
|>= (büyük veya eşittir)|Büyük veya eşit|A2 >= 3|
|< (küçüktür)|Küçük|A2 < 3|
|<= (küçük veya eşittir)|Küçük veya eşit|A2 <= 3|

## **A1‑stil Hücre Referansları**
**A1‑stil hücre referansları**, sütunun harf (ör. *A*) ve satırın sayı (ör. *1*) kimliği olduğu çalışma sayfalarında kullanılır. A1‑stil hücre referansları aşağıdaki şekilde kullanılabilir:

|**Hücre referansı**|**Örnek**| | |
| :- | :- | :- | :- |
| |Mutlak|Göreli|Karışık|
|Hücre|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Satır|$2:$2|2:2|-|
|Sütun|$A:$A|A:A|-|
|Aralık|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

A1‑stil hücre referansının formülde nasıl kullanılacağına bir örnek:

## **R1C1‑stil Hücre Referansları**
**R1C1‑stil hücre referansları**, satır ve sütunun her ikisinin de sayısal kimliği olduğu çalışma sayfalarında kullanılır. R1C1‑stil hücre referansları aşağıdaki şekilde kullanılabilir:

|**Hücre referansı**|**Örnek**| | |
| :- | :- | :- | :- |
| |Mutlak|Göreli|Karışık|
|Hücre|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Satır|R2|R[2]|-|
|Sütun|C3|C[3]|-|
|Aralık|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

R1C1‑stil hücre referansının formülde nasıl kullanılacağına bir örnek:

## **Önceden Tanımlı Fonksiyonlar**
Formüllerde kullanılabilecek ve uygulamayı basitleştiren önceden tanımlı fonksiyonlar vardır. Bu fonksiyonlar en yaygın kullanılan işlemleri kapsar, örneğin:

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (1900 tarih sistemi)
- DAYS
- FIND
- FINDB
- IF
- INDEX (referans formu)
- LOOKUP (vektör formu)
- MATCH (vektör formu)
- MAX
- SUM
- VLOOKUP

## **SSS**

**Formüllü bir grafik için harici Excel dosyaları veri kaynağı olarak destekleniyor mu?**

Evet. Aspose.Slides, bir grafiğin veri kaynağı olarak harici çalışma kitaplarını destekler; bu da sunum dışındaki bir XLSX dosyasından formüller kullanmanıza olanak tanır.

**Grafik formülleri aynı çalışma kitabındaki sayfa adlarıyla başka sayfalara başvurabilir mi?**

Evet. Formüller standart Excel referans modelini izler, bu nedenle aynı çalışma kitabındaki diğer sayfalara ya da harici bir çalışma kitabına başvurabilirsiniz. Harici başvurular için Excel sözdizimini kullanarak yol ve çalışma kitabı adını eklemelisiniz.