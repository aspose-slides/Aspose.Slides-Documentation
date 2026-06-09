---
title: Sunumlarda PHP Kullanarak Grafik Çalışma Sayfası Formüllerini Uygulama
linktitle: Çalışma Sayfası Formülleri
type: docs
weight: 70
url: /tr/php-java/chart-worksheet-formulas/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP'de Java grafik çalışma sayfaları aracılığıyla Excel tarzı formülleri uygulayın ve PPT ve PPTX dosyalarında raporları otomatikleştirin."
---
## **Genel Bakış**

Bir grafik çalışma sayfası, bir sunumdaki grafiğin ardındaki veri kaynağıdır. Kategori ve seri adlarını, grafiğin görüntülediği sayısal değerlerle birlikte depolar. Aspose.Slides içinde bu çalışma sayfası, grafik veri çalışma kitabı aracılığıyla kullanılabilir ve bu sayede grafik verileri programlı olarak işlenebilir.

Bu makale, hücre değerlerinin manuel olarak girilmesi yerine otomatik olarak hesaplanıp güncellenebilmesi için grafik verilerinde çalışma sayfası formüllerinin nasıl kullanılacağını açıklar. Formüllerin nasıl atanacağını, A1-stili ve R1C1-stili referansların nasıl kullanılacağını, çalışma kitabı formüllerinin nasıl yeniden hesaplanacağını ve sunumlardaki grafik çalışma sayfaları için mevcut sabitler, operatörler, hücre referansları ve önceden tanımlı işlevlerle nasıl çalışılacağını gösterir.

## **Sunumlardaki Grafik Çalışma Sayfası Formülleri Hakkında**
**Chart spreadsheet** (veya chart worksheet) bir sunumdaki grafiğin veri kaynağıdır. Grafik çalışma sayfası, grafikte görsel olarak temsil edilen verileri içerir. PowerPoint’te bir grafik oluşturduğunuzda, bu grafiğe ilişkin çalışma sayfası da otomatik olarak oluşturulur. Grafik çalışma sayfası tüm grafik türleri için oluşturulur: çizgi grafik, çubuk grafik, sunburst grafik, pasta grafik vb. PowerPoint’te grafik çalışma sayfasını görmek için grafiğe çift tıklamanız gerekir:

![todo:image_alt_text](chart-worksheet-formulas_1.png)


Grafik çalışma sayfası, grafik öğelerinin adlarını (Kategori Adı: *Category1*, Seri Adı) ve bu kategorilere ve serilere uygun sayısal verileri içeren bir tabloyu barındırır. Varsayılan olarak yeni bir grafik oluşturduğunuzda grafik çalışma sayfası verileri varsayılan verilerle ayarlanır. Ardından çalışma sayfasındaki verileri manuel olarak değiştirebilirsiniz.

Genellikle grafik, değerleri diğer hücrelerdeki değerlerden veya diğer dinamik verilerden hesaplanan karmaşık verileri (ör. finansal analistler, bilimsel analistler) temsil eder. Hücrenin değerini manuel olarak hesaplayıp hücreye sabit bir şekilde girerseniz, gelecekte değeri değiştirmek zorlaşır. Belirli bir hücrenin değeri değiştirildiğinde, ona bağımlı olan tüm hücrelerin de güncellenmesi gerekir. Ayrıca tablo verileri diğer tablolardan gelen verilere dayanabilir; bu da kolay ve esnek bir şekilde güncellenmesi gereken karmaşık bir sunum veri şeması oluşturur.

**Chart spreadsheet formula** bir sunumda grafik çalışma sayfası verilerini otomatik olarak hesaplayıp güncellemek için kullanılan bir ifadedir. Çalışma sayfası formülü belirli bir hücre ya da hücre kümesi için veri hesaplama mantığını tanımlar. Çalışma sayfası formülü, hücre referansları, matematik işlevleri, mantıksal operatörler, aritmetik operatörler, dönüşüm işlevleri, dize sabitleri vb. kullanan bir matematik ya da mantıksal formüldür. Formül tanımı bir hücreye yazılır ve bu hücre basit bir değer içermez. Çalışma sayfası formülü değeri hesaplar ve geri döndürür; ardından bu değer hücreye atanır. Sunumlardaki grafik çalışma sayfası formülleri aslında Excel formülleri ile aynıdır ve uygulanmaları için aynı varsayılan işlevler, operatörler ve sabitler desteklenir.

[**Aspose.Slides**](https://products.aspose.com/slides/tr/php-java/) içinde grafik çalışma sayfası, **ChartData::getChartDataWorkbook** metoduyla temsil edilen **ChartDataWorkbook** türü aracılığıyla sağlanır. Çalışma sayfası formülü **ChartDataCell::setFormula** metodu ile atanabilir ve değiştirilebilir. Aspose.Slides’te formüller için aşağıdaki işlevsellik desteklenir:

- Mantıksal sabitler
- Sayısal sabitler
- Dize sabitler
- Hata sabitleri
- Aritmetik operatörler
- Karşılaştırma operatörleri
- A1 stili hücre referansları
- R1C1 stili hücre referansları
- Önceden tanımlı işlevler

Genellikle elektronik tablolar son hesaplanmış formül değerlerini depolar. Sunum yüklendikten sonra grafik verileri değişmemişse, **ChartDataCell::getValue** metodu bu değerleri okurken döndürür. Ancak elektronik tablo verileri değiştirilmişse, değeri okurken desteklenmeyen formüller için **CellUnsupportedDataException** istisnası atılır. Bunun nedeni, formüller başarıyla ayrıştırıldığında hücre bağımlılıklarının belirlenmesi ve son değerlerin doğruluğunun teyit edilmesidir. Formül ayrıştırılamazsa hücre değerinin doğruluğu garanti edilemez.

## **Sunuma Grafik Çalışma Sayfası Formülü Ekleme**
İlk olarak, yeni bir sunumun ilk slaytına **ShapeCollection::addChart** yöntemiyle bir grafik ekleyin. Grafiğin çalışma sayfası otomatik olarak oluşturulur ve **ChartData::getChartDataWorkbook** metodu ile erişilebilir:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 150, 150, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    # ...
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

**Object** türünün **ChartDataCell::setValue** yöntemiyle hücrelere bazı değerler yazalım; bu, herhangi bir değeri ayarlayabileceğiniz anlamına gelir:

```php
  $workbook->getCell(0, "F2")->setValue(-2.5);
  $workbook->getCell(0, "G3")->setValue(6.3);
  $workbook->getCell(0, "H4")->setValue(3);

```

Şimdi hücreye formül yazmak için **ChartDataCell::setFormula** metodunu kullanabilirsiniz.

*Not*: **ChartDataCell::setFormula** yöntemi A1‑stili hücre referanslarını ayarlamak için kullanılır. 

R1C1 stili bir formül ayarlamak için **ChartDataCell::setR1C1Formula** metodunu kullanabilirsiniz.

Ardından B2 ve C2 hücrelerinin değerlerini okumaya çalışırsanız, değerler hesaplanacaktır:

```php
  $value1 = $cell1->getValue();// 7.8

  $value2 = $cell2->getValue();// 2.1


```

## **Mantıksal Sabitler**
Hücre formüllerinde *FALSE* ve *TRUE* gibi mantıksal sabitleri kullanabilirsiniz:

```php
  $workbook->getCell(0, "A2")->setValue(false);
  $cell = $workbook->getCell(0, "B2");
  $cell->setFormula("A2 = TRUE");
  $value = $cell->getValue();// değer boolean "false" içerir
```

## **Sayısal Sabitler**
Sayısal sabitler, ortak veya bilimsel gösterimlerde grafik çalışma sayfası formülü oluşturmak için kullanılabilir:

```php
  $workbook->getCell(0, "A2")->setFormula("1 + 0.5");
  $workbook->getCell(0, "B2")->setFormula(".3 * 1E-2");

```

## **Dize Sabitler**
Dize (veya literal) sabiti, olduğu gibi kullanılan ve değişmeyen özel bir değerdir. Dize sabitleri tarih, metin, sayı vb. olabilir:

```php
  $workbook->getCell(0, "A2")->setFormula("\"abc\"");
  $workbook->getCell(0, "B2")->setFormula("\"2/3/2020 12:00\"");

```

## **Hata Sabitleri**
Bazen formül sonucunu hesaplamak mümkün olmayabilir. Bu durumda hücrede değeri yerine hata kodu gösterilir. Her hata tipi belirli bir kodla temsil edilir:

- #DIV/0! - formül sıfıra bölmeye çalışır.
- #GETTING_DATA - hücrede değer hâlâ hesaplanırken gösterilebilir.
- #N/A - bilgi eksik ya da mevcut değildir. Bunun sebepleri; hücrelerin boş olması, fazladan boşluk karakteri, yazım hatası vb.
- #NAME? - belirli bir hücre ya da diğer formül nesneleri adlarıyla bulunamıyor.
- #NULL! - formülde (,) gibi bir hata ya da iki nokta üst üste (:) yerine boşluk karakteri kullanıldığında ortaya çıkabilir.
- #NUM! - formüldeki sayısal değer geçersiz, çok uzun ya da çok küçük olabilir.
- #REF! - geçersiz hücre referansı.
- #VALUE! - beklenmeyen değer türü. Örneğin, metin değeri sayısal bir hücreye ayarlanmışsa.

```php
  $cell = $workbook->getCell(0, "A2");
  $cell->setFormula("2 / 0");
  $value = $cell->getValue();// değer string "#DIV/0!" içerir
```

## **Aritmetik Operatörler**
Grafik çalışma sayfası formüllerinde tüm aritmetik operatörleri kullanabilirsiniz:

|**Operatör**|**Anlam**|**Örnek**|
| :- | :- | :- |
|+ (plus sign)|Toplama veya tekli artı|2 + 3|
|- (minus sign)|Çıkarma veya negatif|2 - 3<br>-3|
|* (asterisk)|Çarpma|2 * 3|
|/ (forward slash)|Bölme|2 / 3|
|% (percent sign)|Yüzde|30%|
|^ (caret)|Üs|2 ^ 3|

*Not*: Değerlendirme sırasını değiştirmek için, önce hesaplanması gereken formül kısmını parantez içine alın.

## **Karşılaştırma Operatörleri**
Hücre değerlerini karşılaştırma operatörleriyle karşılaştırabilirsiniz. Bu operatörler kullanılarak iki değer karşılaştırıldığında sonuç mantıksal bir değer *TRUE* ya da *FALSE* olur:

|**Operatör**|**Anlam**|**Örnek**|
| :- | :- | :- |
|= (equal sign)|Eşittir|A2 = 3|
|<> (not equal sign)|Eşit değildir|A2 <> 3|
|> (greater than sign)|Büyüktür|A2 > 3|
|>= (greater than or equal to sign)|Büyük veya eşit|A2 >= 3|
|< (less than sign)|Küçüktür|A2 < 3|
|<= (less than or equal to sign)|Küçük veya eşit|A2 <= 3|

## **A1-Stili Hücre Referansları**
**A1-stili hücre referansları**, sütunun harf tanımlayıcısı (ör. "*A*") ve satırın sayısal tanımlayıcısı (ör. "*1*") olduğu çalışma sayfalarında kullanılır. A1‑stili hücre referansları aşağıdaki şekilde kullanılabilir:

|**Hücre referansı**|**Örnek**|**Mutlak**|**Göreli**|**Karışık**|
| :- | :- | :- | :- | :- |
|Hücre|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Satır|$2:$2|2:2|-|
|Sütun|$A:$A|A:A|-|
|Aralık|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Aşağıda bir formülde A1‑stili hücre referansının nasıl kullanılacağına bir örnek verilmiştir:

```php
  $workbook->getCell(0, "A2")->setFormula("C3 + SUM(F2:H5)");
```

## **R1C1-Stili Hücre Referansları**
**R1C1-stili hücre referansları**, hem satır hem de sütunun sayısal tanımlayıcısının olduğu çalışma sayfalarında kullanılır. R1C1‑stili hücre referansları aşağıdaki şekilde kullanılabilir:

|**Hücre referansı**|**Örnek**|**Mutlak**|**Göreli**|**Karışık**|
| :- | :- | :- | :- | :- |
|Hücre|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Satır|R2|R[2]|-|
|Sütun|C3|C[3]|-|
|Aralık|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|


Aşağıda bir formülde R1C1‑stili hücre referansının nasıl kullanılacağına bir örnek verilmiştir:

```php
  $workbook->getCell(0, "A2")->setR1C1Formula("R2C4 + SUM(R5C6:R7C9)");

```

## **Önceden Tanımlı Fonksiyonlar**
Formüllerde uygulanmalarını basitleştirmek için kullanılabilen önceden tanımlı fonksiyonlar vardır. Bu fonksiyonlar en yaygın kullanılan işlemleri kapsar, örneğin:

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

**Dış Excel dosyaları, formüllü bir grafik için veri kaynağı olarak destekleniyor mu?**

Evet. Aspose.Slides, bir grafiğin veri kaynağı olarak dış çalışma kitaplarını [chart's data source](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatasourcetype/) destekler; bu sayede sunumun dışındaki bir XLSX dosyasından formüller kullanılabilir.

**Grafik formülleri aynı çalışma kitabındaki sayfalara sayfa adıyla başvurabilir mi?**

Evet. Formüller standart Excel referans modelini izler, bu yüzden aynı çalışma kitabı içindeki diğer sayfalara ya da dış bir çalışma kitabına başvurabilirsiniz. Dış referanslarda, Excel sözdizimini kullanarak yol ve çalışma kitabı adını eklemelisiniz.