---
title: Android'de Sunumlarda Grafik Çalışma Sayfası Formüllerini Uygulama
linktitle: Çalışma Sayfası Formülleri
type: docs
weight: 70
url: /tr/androidjava/chart-worksheet-formulas/
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
- öncedefinir fonksiyon
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Excel tarzı formülleri Android için Aspose.Slides'ta Java grafik çalışma sayfaları aracılığıyla uygulayın ve PPT ile PPTX dosyaları arasında raporları otomatikleştirin."
---
## **Genel Bakış**

Bir grafik çalışma sayfası, bir sunumdaki grafiğin arkasındaki veri kaynağıdır. Kategori ve seri adlarını, grafiğin gösterdiği sayısal değerlerle birlikte depolar. Aspose.Slides'ta bu çalışma sayfası, grafik veri çalışma kitabı aracılığıyla kullanılabilir ve grafik verileriyle programlı olarak çalışmanıza olanak tanır.

Bu makale, hücre değerlerinin manuel olarak girilmesi yerine otomatik olarak hesaplanıp güncellenebilmesi için grafik verilerinde çalışma sayfası formüllerinin nasıl kullanılacağını açıklar. Formüllerin nasıl atanacağını, A1‑stili ve R1C1‑stili referansların her ikisinin nasıl kullanılacağını, çalışma kitabı formüllerinin nasıl yeniden hesaplanacağını ve sunumlardaki grafik çalışma sayfalarında kullanılabilen desteklenen sabitler, operatörler, hücre referansları ve öncedefinir fonksiyonlarla nasıl çalışılacağını gösterir.

## **Grafik Çalışma Sayfası Formülleri Hakkında Sunumlarda**
**Grafik çalışma sayfası** (veya chart worksheet) sunumda grafiğin veri kaynağıdır. Grafik çalışma sayfası, grafikte grafiksel olarak temsil edilen verileri içerir. PowerPoint’te bir grafik oluşturduğunuzda bu grafikle ilişkili çalışma sayfası da otomatik olarak oluşturulur. Grafik çalışma sayfası, çizgi grafiği, çubuk grafiği, sunburst grafiği, pasta grafiği vb. tüm grafik türleri için oluşturulur. PowerPoint’te grafik çalışma sayfasını görmek için grafiğe çift‑tıklamalısınız:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


Grafik çalışma sayfası, grafik öğelerinin adlarını (Kategori Adı: *Category1*, Seri Adı) ve bu kategorilere ve serilere uygun sayısal verileri içeren bir tabloyu barındırır. Varsayılan olarak yeni bir grafik oluşturduğunuzda – grafik çalışma sayfası verileri varsayılan değerlerle ayarlanır. Ardından çalışma sayfası verilerini manuel olarak değiştirebilirsiniz.

Genellikle grafik, karmaşık verileri (ör. finansal analizler, bilimsel analizler) temsil eder; bu hücreler diğer hücrelerdeki değerlerden ya da başka dinamik verilerden hesaplanır. Hücrenin değeri manuel olarak hesaplanıp hücreye sabit kodlanırsa gelecekte değişiklik yapmak zorlaşır. Belirli bir hücrenin değerini değiştirirseniz, ona bağımlı tüm hücrelerin de güncellenmesi gerekir. Ayrıca tablo verileri diğer tablolardaki verilere dayanabilir, bu da kolay ve esnek bir şekilde güncellenmesi gereken karmaşık bir sunum veri şeması oluşturur.

**Grafik çalışma sayfası formülü** sunumda, grafik çalışma sayfası verilerini otomatik olarak hesaplamak ve güncellemek için bir ifadedir. Çalışma sayfası formülü, belirli bir hücre ya da hücre kümesi için veri hesaplama mantığını tanımlar. Çalışma sayfası formülü, hücre referansları, matematik fonksiyonları, mantıksal operatörler, aritmetik operatörler, dönüşüm fonksiyonları, dize sabitleri vb. kullanan bir matematik ya da mantıksal formüldür. Formül tanımı bir hücreye yazılır ve bu hücre basit bir değer içermez. Çalışma sayfası formülü değeri hesaplar ve geri döndürür, ardından bu değer hücreye atanır. Sunumlardaki grafik çalışma sayfası formülleri aslında Excel formülleriyle aynıdır ve aynı varsayılan fonksiyonlar, operatörler ve sabitler desteklenir.

[**Aspose.Slides**](https://products.aspose.com/slides/tr/androidjava/) grafik çalışma sayfası,
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChartData#getChartDataWorkbook--) yöntemiyle
[**IChartDataWorkbook**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChartDataWorkbook) tipi üzerinden temsil edilir.
Çalışma sayfası formülü, 
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) yöntemiyle atanabilir ve değiştirilebilir.
Aspose.Slides’ta formüller için aşağıdaki işlevsellik desteklenir:

- Mantıksal sabitler
- Sayısal sabitler
- Dize sabitleri
- Hata sabitleri
- Aritmetik operatörler
- Karşılaştırma operatörleri
- A1‑stili hücre referansları
- R1C1‑stili hücre referansları
- Öncedefinir fonksiyonlar


Genellikle çalışma sayfaları son hesaplanan formül değerlerini saklar. Sunum yüklendikten sonra grafik verileri değiştirilmemişse [**IChartDataCell.getValue**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChartDataCell#getValue--) yöntemi bu değerleri okuma sırasında döndürür. Ancak çalışma sayfası verileri değiştirilmişse, **ChartDataCell.Value** özelliği okuma sırasında desteklenmeyen formüller için [**CellUnsupportedDataException**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/CellUnsupportedDataException)’ı fırlatır. Bunun nedeni, formüller başarıyla ayrıştırıldığında hücre bağımlılıklarının belirlenmesi ve son değerlerin doğruluğunun teyit edilmesidir. Formül ayrıştırılamazsa hücre değerinin doğruluğu garanti edilemez.

## **Sunuma Bir Grafik Çalışma Sayfası Formülü Ekleme**
İlk slayta yeni bir sunumda bir grafik eklemek için 
[IShapeCollection.getShapes.addChart](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IShapeCollection#addChart-int-float-float-float-float-) yöntemini kullanın. 
Grafiğin çalışma sayfası otomatik olarak oluşturulur ve şu yöntemle erişilebilir:
[**Chart.getChartData.getChartDataWorkbook**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChartData#getChartDataWorkbook--) yöntemi:

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

Hücrelere bazı değerler yazmak için 
[**IChartDataCell.setValue**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChartDataCell#setValue-java.lang.Object-) özelliğini 
**Object** tipinde kullanabilirsiniz; bu, özelliğe herhangi bir değeri atayabileceğiniz anlamına gelir:

```java
workbook.getCell(0, "F2").setValue(-2.5);

workbook.getCell(0, "G3").setValue(6.3);

workbook.getCell(0, "H4").setValue(3);
```

Şimdi hücreye formül yazmak için 
[**IChartDataCell.setFormula**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) yöntemini kullanabilirsiniz:

*Not*: [**IChartDataCell.setFormula**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChartDataCell#setFormula-java.lang.String-) yöntemi A1‑stili hücre referanslarını ayarlamak için kullanılır. 

[R1C1Formula](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChartDataCell#getR1C1Formula--) hücre referansını ayarlamak için 
[**IChartDataCell.setR1C1Formula**](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/IChartDataCell#setR1C1Formula-java.lang.String-) yöntemini kullanabilirsiniz:

Ardından B2 ve C2 hücrelerinin değerlerini okursanız, bunlar hesaplanmış olur:

```java
Object value1 = cell1.getValue(); // 7.8

Object value2 = cell2.getValue(); // 2.1
```

## **Mantıksal Sabitler**
Hücre formüllerinde *FALSE* ve *TRUE* gibi mantıksal sabitleri kullanabilirsiniz:

```java
workbook.getCell(0, "A2").setValue(false);
IChartDataCell cell = workbook.getCell(0, "B2");
cell.setFormula("A2 = TRUE");
Object value = cell.getValue(); // değer boolean "false" içerir
```

## **Sayısal Sabitler**
Sayılar, ortak veya bilimsel gösterimlerde grafik çalışma sayfası formülü oluşturmak için kullanılabilir:

```java
workbook.getCell(0, "A2").setFormula("1 + 0.5");
workbook.getCell(0, "B2").setFormula(".3 * 1E-2");
```

## **Dize Sabitleri**
Dize (veya literal) sabiti, olduğu gibi kullanılan ve değişmeyen belirli bir değerdir. Dize sabitleri şunlar olabilir: tarih, metin, sayı vb.:

```java
workbook.getCell(0, "A2").setFormula("\"abc\"");
workbook.getCell(0, "B2").setFormula("\"2/3/2020 12:00\"");
```

## **Hata Sabitleri**
Bazen formül sonucu hesaplanamaz. Bu durumda hücrede değeri yerine hata kodu gösterilir. Her hata türünün belirli bir kodu vardır:

- #DIV/0! - formül sıfıra bölmeye çalışır.
- #GETTING_DATA - değeri hâlâ hesaplanırken bir hücrede görünebilir.
- #N/A - bilgi eksik ya da mevcut değil. Nedenler: formülde kullanılan hücreler boş, ekstra boşluk karakteri, yazım hatası vb.
- #NAME? - belirli bir hücre ya da diğer formül nesneleri adıyla bulunamıyor. 
- #NULL! - formülde hata olduğunda ortaya çıkabilir; örneğin  (,) ya da iki nokta üstüstü (:) yerine boşluk karakteri kullanılması.
- #NUM! - formüldeki sayı geçersiz, çok uzun ya da çok kısa vb.
- #REF! - geçersiz hücre referansı.
- #VALUE! - beklenmedik değer türü. Örneğin, sayı hücresine dize değeri atanması.

```java
IChartDataCell cell = workbook.getCell(0, "A2");
cell.setFormula("2 / 0");
Object value = cell.getValue(); // değer string "#DIV/0!" içerir
```

## **Aritmetik Operatörler**
Grafik çalışma sayfası formüllerinde tüm aritmetik operatörleri kullanabilirsiniz:

|**Operatör**|**Anlam**|**Örnek**|
| :- | :- | :- |
|+ (artı işareti)|Toplama veya tekli artı|2 + 3|
|- (eksi işareti)|Çıkarma veya negatif|2 - 3<br>-3|
|* (yıldız)|Çarpma|2 * 3|
|/ (bölü işareti)|Bölme|2 / 3|
|% (yüzde işareti)|Yüzde|30%|
|^ (caret)|Üs alma|2 ^ 3|

*Not*: Değerlendirme sırasını değiştirmek için, önce hesaplanması gereken formül kısmını parantez içine alın.

## **Karşılaştırma Operatörleri**
Hücre değerlerini karşılaştırma operatörleriyle karşılaştırabilirsiniz. Bu operatörlerle iki değer karşılaştırıldığında sonuç mantıksal bir değer, yani *TRUE* ya da FALSE olur:

|**Operatör**|**Anlam**|**Anlam**|
| :- | :- | :- |
|= (eşittir işareti)|Eşittir|A2 = 3|
|<> (eşit değildir işareti)|Eşit değildir|A2 <> 3|
|> (büyük işareti)|Büyüktür|A2 > 3|
|>= (büyük veya eşittir işareti)|Büyük veya eşittir|A2 >= 3|
|< (küçük işareti)|Küçüktür|A2 < 3|
|<= (küçük veya eşittir işareti)|Küçük veya eşittir|A2 <= 3|

## **A1‑stili Hücre Referansları**
**A1‑stili hücre referansları**, sütunun harf (ör. "*A*") ve satırın sayısal (ör. "*1*") tanımlayıcıya sahip olduğu çalışma sayfalarında kullanılır. A1‑stili hücre referansları aşağıdaki şekilde kullanılabilir:

|**Hücre referansı**|**Örnek**|||
| :- | :- | :- | :- |
||Mutlak|Göreceli|Karışık|
|Hücre|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Satır|$2:$2|2:2|-|
|Sütun|$A:$A|A:A|-|
|Aralık|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|


A1‑stili hücre referansının formülde nasıl kullanılacağına bir örnek:

```java
workbook.getCell(0, "A2").setFormula("C3 + SUM(F2:H5)");
```

## **R1C1‑stili Hücre Referansları**
**R1C1‑stili hücre referansları**, hem satır hem de sütunun sayısal kimlik taşıdığı çalışma sayfalarında kullanılır. R1C1‑stili hücre referansları aşağıdaki şekilde kullanılabilir:

|**Hücre referansı**|**Örnek**|||
| :- | :- | :- | :- |
||Mutlak|Göreceli|Karışık|
|Hücre|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Satır|R2|R[2]|-|
|Sütun|C3|C[3]|-|
|Aralık|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


R1C1‑stili hücre referansının formülde nasıl kullanılacağına bir örnek:

```java
workbook.getCell(0, "A2").setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");
```

## **Öncedefinir Fonksiyonlar**
Formüllerde uygulanmasını basitleştirmek için kullanılabilen öncedefinir fonksiyonlar vardır. Bu fonksiyonlar en sık kullanılan işlemleri kapsar, örneğin:

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

**Formüllü bir grafik için dış Excel dosyaları veri kaynağı olarak destekleniyor mu?**

Evet. Aspose.Slides, bir grafiğin veri kaynağı olarak dış çalışma kitaplarını [chart's data source](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/chartdatasourcetype/) destekler; böylece sunum dışındaki bir XLSX dosyasından formüller kullanılabilir.

**Grafik formülleri, aynı çalışma kitabındaki sayfalara sayfa adıyla başvurabilir mi?**

Evet. Formüller standart Excel referans modelini izler, bu yüzden aynı çalışma kitabındaki ya da dış bir çalışma kitabındaki diğer sayfalara başvurabilirsiniz. Dış başvurular için Excel sözdizimini kullanarak yolu ve çalışma kitabı adını ekleyin.