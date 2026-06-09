---
title: JavaScript Kullanarak Sunumlarda Grafik Çalışma Sayfası Formüllerini Uygulama
linktitle: Çalışma Sayfası Formülleri
type: docs
weight: 70
url: /tr/nodejs-java/chart-worksheet-formulas/
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
- önceden tanımlı işlev
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript kullanarak PPT ve PPTX dosyalarında raporları otomatikleştirerek, Node.js için Aspose.Slides'te Java grafik çalışma sayfaları aracılığıyla Excel tarzı formülleri uygulayın."
---
## **Genel Bakış**

Bir grafik çalışma sayfası, bir sunumdaki grafiğin veri kaynağıdır. Kategori ve seri adlarını, grafiğin gösterdiği sayısal değerlerle birlikte depolar. Aspose.Slides'te bu çalışma sayfasına grafik veri çalışma kitabı aracılığıyla erişilir; bu sayede grafik verileri programlı olarak işlenebilir.

Bu makale, hücre değerlerinin manuel olarak girilmesi yerine otomatik olarak hesaplanıp güncellenebilmesi için grafik verilerinde çalışma sayfası formüllerinin nasıl kullanılacağını açıklar. Formüllerin nasıl atanacağını, hem A1 hem de R1C1 stilleriyle referansların nasıl kullanılacağını, çalışma kitabı formüllerinin nasıl yeniden hesaplanacağını ve sunumlardaki grafik çalışma sayfalarında kullanılabilen sabitler, operatörler, hücre referansları ve önceden tanımlı işlevler hakkında bilgi verir.

## **Sunumda Grafik Çalışma Sayfası Formülü Hakkında**
**Grafik çalışma sayfası** (veya grafik çalışma sayfası), sunumdaki grafiğin veri kaynağıdır. Grafik çalışma sayfası, grafik üzerinde grafiksel olarak temsil edilen verileri içerir. PowerPoint'te bir grafik oluşturduğunuzda, bu grafikle ilişkili çalışma sayfası otomatik olarak oluşturulur. Grafik çalışma sayfası, çizgi grafik, çubuk grafik, güneş patlaması grafik, pasta grafik vb. tüm grafik tipleri için oluşturulur. PowerPoint'te grafik çalışma sayfasını görmek için grafiğe çift tıklamanız yeterlidir:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

Grafik çalışma sayfası, grafik öğelerinin adlarını (Kategori Adı: *Category1*, Seri Adı) ve bu kategorilere ve serilere uygun sayısal veri tablosunu içerir. Varsayılan olarak yeni bir grafik oluşturduğunuzda – grafik çalışma sayfası verileri varsayılan verilerle ayarlanır. Ardından çalışma sayfası verilerini manuel olarak değiştirebilirsiniz.

Genellikle grafik, karmaşık verileri (ör. finansal analizler, bilimsel analizler) temsil eder; bu veriler diğer hücrelerin değerlerinden veya dinamik verilerden hesaplanır. Hücre değerini manuel olarak hesaplayıp hücreye sabit olarak yazmak, gelecekte değişiklik yapmayı zorlaştırır. Belirli bir hücrenin değerini değiştirirseniz, ona bağımlı tüm hücrelerin de güncellenmesi gerekir. Ayrıca tablo verileri diğer tablolardan gelen verilere bağlanabilir; bu da kolay ve esnek bir şekilde güncellenmesi gereken karmaşık bir sunum veri şeması oluşturur.

**Grafik çalışma sayfası formülü**, grafik çalışma sayfası verilerini otomatik olarak hesaplamak ve güncellemek için bir ifadedir. Formül, belirli bir hücre ya da hücre kümesi için veri hesaplama mantığını tanımlar. Grafik çalışma sayfası formülü, hücre referansları, matematik işlevleri, mantıksal operatörler, aritmetik operatörler, dönüşüm işlevleri, dize sabitleri vb. kullanan bir matematik ya da mantıksal formüldür. Formül tanımı bir hücreye yazılır ve bu hücre basit bir değer içermez. Formül değeri hesaplar ve geri döndürür; ardından bu değer hücreye atanır. Sunumlardaki grafik çalışma sayfası formülleri aslında Excel formülleriyle aynıdır ve aynı varsayılan işlevler, operatörler ve sabitler desteklenir.

[**Aspose.Slides**](https://products.aspose.com/slides/tr/nodejs-java/) içinde grafik çalışma sayfası,
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartData#getChartDataWorkbook--) yöntemiyle
[**ChartDataWorkbook**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartDataWorkbook) türü aracılığıyla temsil edilir.
Formül, [**ChartDataCell.setFormula**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-) yöntemiyle atanabilir ve değiştirilebilir.
Aspose.Slides'te formüller için aşağıdaki işlevsellik desteklenir:

- Mantıksal sabitler
- Sayısal sabitler
- Dize sabitleri
- Hata sabitleri
- Aritmetik operatörler
- Karşılaştırma operatörleri
- A1-stili hücre referansları
- R1C1-stili hücre referansları
- Önceden tanımlı işlevler

Genellikle, çalışma sayfaları son hesaplanmış formül değerlerini saklar. Sunum yüklendikten sonra grafik verileri değiştirilmemişse – [**ChartDataCell.getValue**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartDataCell#getValue--) yöntemi bu değerleri okuma sırasında döndürür. Ancak çalışma sayfası verileri değiştirilmişse, **ChartDataCell.Value** özelliği okunurken desteklenmeyen formüller için [**CellUnsupportedDataException**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/CellUnsupportedDataException) fırlatır. Bunun nedeni, formüller başarıyla ayrıştırıldığında hücre bağımlılıklarının belirlenmesi ve son değerlerin doğruluğunun teyit edilmesidir. Formül ayrıştırılamazsa, hücre değerinin doğruluğu garanti edilemez.

## **Sunuma Grafik Çalışma Sayfası Formülü Ekleme**
Öncelikle, yeni bir sunumun ilk slaytına bir grafik ekleyin:
[ShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ShapeCollection#addChart-int-float-float-float-float-).
Grafiğin çalışma sayfası otomatik olarak oluşturulur ve aşağıdaki yöntemle erişilebilir:
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartData#getChartDataWorkbook--) yöntemi:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 150, 150, 500, 300);
    var workbook = chart.getChartData().getChartDataWorkbook();
    // ...
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Hücrelere bazı değerler yazmak için [**ChartDataCell.setValue**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartDataCell#setValue-java.lang.Object-) özelliğini kullanın; bu özellik **Object** türündedir, yani herhangi bir değeri ayarlayabilirsiniz:

```javascript
workbook.getCell(0, "F2").setValue(-2.5);
workbook.getCell(0, "G3").setValue(6.3);
workbook.getCell(0, "H4").setValue(3);
```

Şimdi hücreye formül yazmak için [**ChartDataCell.setFormula**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-) yöntemini kullanabilirsiniz:

*Not*: [**ChartDataCell.setFormula**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartDataCell#setFormula-java.lang.String-) yöntemi A1-stili hücre referanslarını ayarlamak için kullanılır. 

[R1C1Formula](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartDataCell#getR1C1Formula--) hücre referansını ayarlamak için [**ChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ChartDataCell#setR1C1Formula-java.lang.String-) yöntemini kullanabilirsiniz:

Ardından B2 ve C2 hücrelerinin değerlerini okursanız, bu değerler hesaplanacaktır:

```javascript
var value1 = cell1.getValue();// 7.8
var value2 = cell2.getValue();// 2.1
```

## **Mantıksal Sabitler**
Hücre formüllerinde *FALSE* ve *TRUE* gibi mantıksal sabitleri kullanabilirsiniz:

```javascript
workbook.getCell(0, "A2").setValue(false);
var cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
var value = cell.getValue();// değer boolean "false" içeriyor
```

## **Sayısal Sabitler**
Sayısal sabitler, yaygın veya bilimsel gösterimlerde grafik çalışma sayfası formülü oluşturmak için kullanılabilir:

```javascript
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```

## **Dize Sabitleri**
Dize (veya literal) sabiti, olduğu gibi kullanılan ve değişmeyen belirli bir değerdir. Dize sabitleri tarih, metin, sayı vb. olabilir:

```javascript
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```

## **Hata Sabitleri**
Bazen formül sonucunı hesaplayamaz. Bu durumda hücrede değeri yerine bir hata kodu gösterilir. Her hata türünün özel bir kodu vardır:

- #DIV/0! - formül sıfıra bölmeye çalışıyor.
- #GETTING_DATA - hücrenin değeri hâlâ hesaplanırken gösterilebilir.
- #N/A - bilgi eksik veya mevcut değil. Nedenler: formülde kullanılan hücrelerin boş olması, ekstra boşluk karakteri, yazım hatası vb.
- #NAME? - belirli bir hücre ya da başka bir formül nesnesi adına göre bulunamıyor. 
- #NULL! - formülde (, ) gibi bir hata olduğunda ya da iki nokta üst üste (:) yerine boşluk karakteri kullanıldığında ortaya çıkabilir.
- #NUM! - formüldeki sayısal değer geçersiz, çok uzun veya çok küçük olabilir.
- #REF! - geçersiz hücre referansı.
- #VALUE! - beklenmeyen değer türü. Örneğin, sayısal hücreye dize değeri atanması.

```javascript
var cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
var value = cell.getValue();// değer string "#DIV/0!" içeriyor
```

## **Aritmetik Operatörler**
Grafik çalışma sayfası formüllerinde tüm aritmetik operatörleri kullanabilirsiniz:

|**Operatör**|**Anlam**|**Örnek**|
| :- | :- | :- |
|+ (artı işareti)|Toplama ya da tek pozitif|2 + 3|
|- (eksi işareti)|Çıkarma ya da negatif|2 - 3<br>-3|
|* (yıldız)|Çarpma|2 * 3|
|/ (bölü işareti)|Bölme|2 / 3|
|% (yüzde işareti)|Yüzde|30%|
|^ (caret)|Üs alma|2 ^ 3|

*Not*: Değerlendirme sırasını değiştirmek için formülün ilk hesaplanması gereken kısmını parantez içine alın.

## **Karşılaştırma Operatörleri**
Hücre değerlerini karşılaştırma operatörleriyle karşılaştırabilirsiniz. Bu operatörler kullanılarak iki değer karşılaştırıldığında sonuç mantıksal bir değer (*TRUE* ya da FALSE) olur:

|**Operatör**|**Anlam**|**Anlam**|
| :- | :- | :- |
|= (eşittir)|Eşit|A2 = 3|
|<> (eşit değildir)|Eşit değildir|A2 <> 3|
|> (büyüktür)|Büyük|A2 > 3|
|>= (büyük eşittir)|Büyük veya eşit|A2 >= 3|
|< (küçüktür)|Küçük|A2 < 3|
|<= (küçük eşittir)|Küçük veya eşit|A2 <= 3|

## **A1-Stili Hücre Referansları**
**A1-stili hücre referansları**, sütunun harf (ör. "*A*") ve satırın sayı (ör. "*1*") kimliği olduğu çalışma sayfalarında kullanılır. A1-stili hücre referansları aşağıdaki şekilde kullanılabilir:

|**Hücre referansı**|**Örnek**| | |
| :- | :- | :- | :- |
| |Mutlak|Göreli|Karışık|
|Hücre|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Satır|$2:$2|2:2|-|
|Sütun|$A:$A|A:A|-|
|Aralık|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

A1-stili hücre referansının formülde nasıl kullanılacağına bir örnek:

```javascript
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```

## **R1C1-Stili Hücre Referansları**
**R1C1-stili hücre referansları**, hem satır hem de sütunun sayısal kimliğe sahip olduğu çalışma sayfalarında kullanılır. R1C1-stili hücre referansları aşağıdaki şekilde kullanılabilir:

|**Hücre referansı**|**Örnek**| | |
| :- | :- | :- | :- |
| |Mutlak|Göreli|Karışık|
|Hücre|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Satır|R2|R[2]|-|
|Sütun|C3|C[3]|-|
|Aralık|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

R1C1-stili hücre referansının formülde nasıl kullanılacağına bir örnek:

```javascript
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```

## **Önceden Tanımlı İşlevler**
Formüllerde uygulanmasını kolaylaştırmak için kullanılabilecek önceden tanımlı işlevler vardır. Bu işlevler en yaygın kullanılan işlemleri kapsar, örneğin:

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

Evet. Aspose.Slides, bir [grafiğin veri kaynağı](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatasourcetype/) olarak harici çalışma kitaplarını destekler; bu sayede sunum dışındaki bir XLSX dosyasındaki formüller kullanılabilir.

**Grafik formülleri, aynı çalışma kitabındaki sayfaları sayfa adıyla referans gösterebilir mi?**

Evet. Formüller standart Excel referans modelini izler, bu nedenle aynı çalışma kitabındaki diğer sayfaları veya harici bir çalışma kitabını referans gösterebilirsiniz. Harici referanslar için Excel sözdizimini kullanarak yol ve çalışma kitabı adını ekleyin.