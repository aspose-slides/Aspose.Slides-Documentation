---
title: Sunumlarda Java Kullanarak Grafik Çalışma Sayfası Formüllerini Uygula
linktitle: Çalışma Sayfası Formülleri
type: docs
weight: 70
url: /tr/java/chart-worksheet-formulas/
keywords:
- grafik elektronik tablo
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'da Excel benzeri formülleri grafik çalışma sayfalarına uygulayın ve PPT ve PPTX dosyalarında raporları otomatikleştirin."
---
## **Genel Bakış**

Bir grafik çalışma sayfası, bir sunumdaki grafiğin arkasındaki veri kaynağıdır. Kategori ve seri adlarını, grafiğin gösterdiği sayısal değerlerle birlikte depolar. Aspose.Slides içinde bu çalışma sayfası, grafik veri çalışma kitabı aracılığıyla kullanılabilir ve bu sayede grafik verileriyle programlı olarak çalışabilirsiniz.

Bu makale, hücre değerlerinin elle girilmesi yerine otomatik olarak hesaplanıp güncellenebilmesi için grafik verilerinde çalışma sayfası formüllerinin nasıl kullanılacağını açıklar. Formüllerin nasıl atanacağını, hem A1 hem de R1C1 stilindeki referansların nasıl kullanılacağını, çalışma kitabı formüllerinin nasıl yeniden hesaplanacağını ve sunumlardaki grafik çalışma sayfalarında kullanılabilen desteklenen sabitler, operatörler, hücre referansları ve önceden tanımlı işlevlerle nasıl çalışılacağını gösterir.

## **Sunumlardaki Grafik Çalışma Sayfası Formülleri Hakkında**
**Grafik çalışma sayfası** (veya grafik çalışma sayfası) bir sunumda grafiğin veri kaynağıdır. Grafik çalışma sayfası, grafikte grafiksel olarak temsil edilen verileri içerir. PowerPoint'te bir grafik oluşturduğunuzda, bu grafikle ilişkili çalışma sayfası da otomatik olarak oluşturulur. Grafik çalışma sayfası, çizgi grafik, çubuk grafik, güneş patlaması grafiği, pasta grafiği vb. tüm grafik türleri için oluşturulur. PowerPoint'te grafik çalışma sayfasını görmek için grafiğe çift tıklamalısınız:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


Grafik çalışma sayfası, grafik öğelerinin adlarını (Kategori Adı: *Category1*, Seri Adı) ve bu kategorilere ve serilere uygun sayısal verileri içeren bir tabloyu içerir. Varsayılan olarak, yeni bir grafik oluşturduğunuzda - grafik çalışma sayfası verileri varsayılan verilerle ayarlanır. Ardından çalışma sayfasındaki elektronik tablo verilerini manuel olarak değiştirebilirsiniz.

Genellikle, grafik karmaşık verileri (ör. finansal analistler, bilimsel analistler) temsil eder ve diğer hücrelerdeki değerlerden ya da diğer dinamik verilerden hesaplanan hücrelere sahiptir. Hücrenin değerini manuel olarak hesaplayıp hücreye sabit kodlamak, gelecekte değiştirildiğinde zorlaştırır. Belirli bir hücrenin değerini değiştirirseniz, ona bağımlı tüm hücrelerin de güncellenmesi gerekir. Ayrıca tablo verileri, diğer tablolardan gelen verilerle ilişkili olabilir ve bu, kolay ve esnek bir şekilde güncellenmesi gereken karmaşık bir sunum veri şeması oluşturur.

**Grafik çalışma sayfası formülü** bir sunumda, grafik çalışma sayfası verilerini otomatik olarak hesaplamak ve güncellemek için bir ifadedir. Çalışma sayfası formülü, belirli bir hücre ya da hücre kümesi için veri hesaplama mantığını tanımlar. Çalışma sayfası formülü, hücre referansları, matematik işlevleri, mantıksal operatörler, aritmetik operatörler, dönüşüm işlevleri, dize sabitleri vb. kullanan bir matematik ya da mantıksal formüldür. Formül tanımı bir hücreye yazılır ve bu hücre basit bir değer içermez. Çalışma sayfası formülü değeri hesaplar ve geri döner, ardından bu değer hücreye atanır. Sunumlardaki grafik çalışma sayfası formülleri aslında Excel formülleriyle aynı olup, uygulanmaları için aynı varsayılan işlevler, operatörler ve sabitler desteklenir.

In [**Aspose.Slides**](https://products.aspose.com/slides/tr/java/) grafik çalışma sayfası, [**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChartData#getChartDataWorkbook--) yöntemiyle, [**IChartDataWorkbook**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChartDataWorkbook) türünün temsil edilir. Çalışma sayfası formülü, [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) yöntemiyle atanabilir ve değiştirilebilir. Aspose.Slides içinde formüller için aşağıdaki işlevsellik desteklenir:
- Mantıksal sabitler
- Sayısal sabitler
- Dize sabitleri
- Hata sabitleri
- Aritmetik operatörler
- Karşılaştırma operatörleri
- A1 stilindeki hücre referansları
- R1C1 stilindeki hücre referansları
- Önceden tanımlı işlevler

Genellikle, elektronik tablolar son hesaplanan formül değerlerini saklar. Sunum yüklendikten sonra grafik verileri değiştirilmemişse, [**IChartDataCell.getValue**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChartDataCell#getValue--) yöntemi bu değerleri okurken döndürür. Ancak, elektronik tablo verileri değiştirildiyse, **ChartDataCell.Value** özelliğini okurken desteklenmeyen formüller için [**CellUnsupportedDataException**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/CellUnsupportedDataException) hatası fırlatılır. Bunun nedeni, formüller başarıyla ayrıştırıldığında hücre bağımlılıklarının belirlenmesi ve son değerlerin doğruluğunun kontrol edilmesidir. Ancak formül ayrıştırılamazsa, hücre değerinin doğruluğu garanti edilemez.

## **Bir Sunuma Grafik Çalışma Sayfası Formülü Ekleme**
Öncelikle, yeni bir sunumun ilk slaytına bir grafik eklemek için [IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IShapeCollection#addChart-int-float-float-float-float-) yöntemini kullanın. Grafiğin çalışma sayfası otomatik olarak oluşturulur ve [**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChartData#getChartDataWorkbook--) yöntemiyle erişilebilir:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 150, 150, 500, 300);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    // ...
} finally {
    if (pres != null) pres.dispose();
}
```

Hücrelere bazı değerler yazmak için **Object** türünün [**IChartDataCell.setValue**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChartDataCell#setValue-java.lang.Object-) özelliğini kullanabilirsiniz; bu, özelliğe herhangi bir değer atayabileceğiniz anlamına gelir:

```java
workbook.getCell(0, "F2").setValue(-2.5);

workbook.getCell(0, "G3").setValue(6.3);

workbook.getCell(0, "H4").setValue(3);
```

Şimdi hücreye formül yazmak için [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) yöntemini kullanabilirsiniz:

*Not*: [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) yöntemi A1 stilindeki hücre referanslarını ayarlamak için kullanılır.

[R1C1Formula](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChartDataCell#getR1C1Formula--) hücre referansını ayarlamak için [**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-) yöntemini kullanabilirsiniz:

Then if you try to read the values from the cells B2 and C2, they will be calculated:

```java
Object value1 = cell1.getValue(); // 7.8

Object value2 = cell2.getValue(); // 2.1
```

## **Mantıksal Sabitler**
Hücre formüllerinde *FALSE* ve *TRUE* gibi mantıksal sabitler kullanılabilir:

```java
workbook.getCell(0, "A2").setValue(false);
IChartDataCell cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
Object value = cell.getValue(); // değer boolean "false" içerir
```

## **Sayısal Sabitler**
Sayısal sabitler, ortak veya bilimsel gösterimlerde kullanılabilir ve grafik çalışma sayfası formülü oluşturur:

```java
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```

## **Dize Sabitleri**
Dize (veya literal) sabiti, olduğu gibi kullanılan ve değişmeyen bir değerdir. Dize sabitleri tarih, metin, sayı vb. olabilir:

```java
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```

## **Hata Sabitleri**
Bazen formül sonucu hesaplamak mümkün değildir. Bu durumda, hücrede değeri yerine bir hata kodu gösterilir. Her hata türünün belirli bir kodu vardır:
- #DIV/0! - formül sıfıra bölmeye çalışır.
- #GETTING_DATA - değer hâlâ hesaplanırken hücrede görünebilir.
- #N/A - bilgi eksik veya mevcut değil. Bunun sebepleri: formülde kullanılan hücreler boş, ekstra boşluk karakteri, yazım hatası vb.
- #NAME? - belirli bir hücre ya da diğer formül nesneleri adlarıyla bulunamıyor.
- #NULL! - formülde hata olduğunda ortaya çıkabilir; örneğin: (,) gibi biçim hatası ya da iki nokta üst üste (:) yerine boşluk kullanılması.
- #NUM! - formüldeki sayısal değer geçersiz, çok uzun ya da çok küçük olabilir.
- #REF! - geçersiz hücre referansı.
- #VALUE! - beklenmeyen değer türü. Örneğin, bir dize değeri sayısal hücreye atanması.

```java
IChartDataCell cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
Object value = cell.getValue(); // değer string "#DIV/0!" içerir
```

## **Aritmetik Operatörler**
Grafik çalışma sayfası formüllerinde tüm aritmetik operatörleri kullanabilirsiniz:

|**Operatör** |**Anlam** |**Örnek**|
| :- | :- | :- |
|+ (artı işareti) |Toplama veya tekli artı|2 + 3|
|- (eksi işareti) |Çıkarma veya negatif|2 - 3<br>-3|
|* (yıldız işareti)|Çarpma |2 * 3|
|/ (bölme işareti)|Bölme |2 / 3|
|% (yüzde işareti) |Yüzde |30%|
|^ (karet) |Üs alma |2 ^ 3|

*Not*: Değerlendirme sırasını değiştirmek için, önce hesaplanacak formül kısmını parantez içine alın.

## **Karşılaştırma Operatörleri**
Hücre değerlerini karşılaştırma operatörleriyle karşılaştırabilirsiniz. Bu operatörler kullanılarak iki değer karşılaştırıldığında sonuç, *TRUE* ya da FALSE değerlerinden biri olan bir mantıksal değerdir:

|**Operatör** |**Anlam** |**Örnek**|
| :- | :- | :- |
|= (eşittir işareti) |Eşittir|A2 = 3|
|<> (eşit değil işareti) |Eşit değildir|A2 <> 3|
|> (büyüktür işareti) |Büyüktür|A2 > 3|
|>= (büyük veya eşit işareti)|Büyük veya eşittir|A2 >= 3|
|< (küçüktür işareti)|Küçüktür|A2 < 3|
|<= (küçük veya eşit işareti)|Küçük veya eşittir|A2 <= 3|

## **A1-Stil Hücre Referansları**
**A1-stil hücre referansları**, sütunun harf kimliği (ör. "*A*") ve satırın sayısal kimliği (ör. "*1*") olduğu çalışma sayfalarında kullanılır. A1-stil hücre referansları aşağıdaki şekilde kullanılabilir:

|**Hücre referansı**|**Örnek**|||
| :- | :- | :- | :- |
||Mutlak |Göreceli |Karışık|
|Hücre |$A$2 |A2|<p>A$2</p><p>$A2</p>|
|Satır |$2:$2 |2:2 |-|
|Sütun |$A:$A |A:A |-|
|Aralık |$A$2:$C$4 |A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Here is an example how to use A1-style cell reference in formula:

```java
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```

## **R1C1-Stil Hücre Referansları**
**R1C1-stil hücre referansları**, hem satır hem de sütunun sayısal kimliğe sahip olduğu çalışma sayfalarında kullanılır. R1C1-stil hücre referansları aşağıdaki şekilde kullanılabilir:

|**Hücre referansı**|**Örnek**|||
| :- | :- | :- | :- |
||Mutlak |Göreceli |Karışık|
|Hücre |R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Satır |R2|R[2]|-|
|Sütun |C3|C[3]|-|
|Aralık |R2C3:R5C7|R[2]C[3]:R[5]C[7] |R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Here is an example how to use A1-style cell reference in formula:

```java
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```

## **Önceden Tanımlı İşlevler**
Formüllerde kullanılabilecek, uygulamalarını basitleştiren önceden tanımlı işlevler vardır. Bu işlevler en yaygın kullanılan işlemleri kapsar, örneğin:
- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (1900 date system)
- DAYS
- FIND
- FINDB
- IF
- INDEX (reference form)
- LOOKUP (vector form)
- MATCH (vector form)
- MAX
- SUM
- VLOOKUP

## **SSS**

**Formüllü bir grafik için dış Excel dosyaları veri kaynağı olarak destekleniyor mu?**

Evet. Aspose.Slides, bir [chart's data source](https://reference.aspose.com/slides/tr/java/com.aspose.slides/chartdatasourcetype/) olarak dış çalışma kitaplarını destekler; bu sayede sunum dışındaki bir XLSX dosyasındaki formülleri kullanabilirsiniz.

**Grafik formülleri aynı çalışma kitabındaki sayfalara sayfa adıyla başvurabilir mi?**

Evet. Formüller standart Excel referans modelini izler, bu yüzden aynı çalışma kitabındaki veya dış bir çalışma kitabındaki diğer sayfalara başvurabilirsiniz. Dış başvurular için Excel sözdizimini kullanarak yol ve çalışma kitabı adını ekleyin.