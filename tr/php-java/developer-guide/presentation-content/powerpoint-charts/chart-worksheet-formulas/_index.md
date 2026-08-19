---
title: PHP ile Sunumlarda Grafik Çalışma Sayfası Formüllerini Uygulama
linktitle: Çalışma Sayfası Formülleri
type: docs
weight: 70
url: /tr/php-java/chart-worksheet-formulas/
keywords:
- grafik elektronik tablo
- grafik çalışma sayfası
- grafik formülü
- çalışma sayfası formülü
- elektronik tablo formülü
- grafik veri çalışma kitabı
- formül hesaplama
- mantıksal sabit
- sayısal sabit
- dize sabiti
- hata sabiti
- aritmetik operatör
- karşılaştırma operatörü
- A1 stili
- R1C1 stili
- önceden tanımlı işlev
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Java üzerinden PHP için Aspose.Slides'ta grafik çalışma sayfalarında Excel-stili formülleri uygula, değerleri yeniden hesapla ve sonuçları PowerPoint grafiklerinde kullan."
---
## **Genel Bakış**

PowerPoint grafikler genellikle kaynak verilerini gömülü bir çalışma sayfasında saklar. PHP üzerinden Java için Aspose.Slides ile bu çalışma sayfasına grafik veri çalışma kitabı aracılığıyla erişebilir, giriş değerlerini yazabilir, hücrelere formüller atayabilir, desteklenen formülleri hesaplayabilir ve hesaplanan hücreleri grafik verisi olarak kullanabilirsiniz.

Bu makale tam formül iş akışını açıklar: bir grafik oluşturma, çalışma sayfasını doldurma, A1‑stili veya R1C1‑stili formüller atama, bunları yeniden hesaplama, hesaplanan değerleri okuma, bu hücreleri bir grafik serisine bağlama ve sunumu kaydetme. Ayrıca desteklenen formül sözdizimini, yerleşik fonksiyon alt kümesini, önbelleklenmiş değerleri, desteklenmeyen formülleri ve çalışma sayfasına özgü hataları açıklar.

## **Grafik Çalışma Sayfaları ve Formüller**

Bir grafik çalışma sayfası, bir grafik tarafından kullanılan kategorileri, seri adlarını ve değerleri içerir. PowerPoint'te, grafik veri düzenleyiciyi açarak çalışma sayfasını inceleyebilirsiniz:

![Gömülü çalışma sayfası açık olan PowerPoint grafiği, kategori ve seri verilerini gösteriyor](chart-worksheet-formulas_1.png)

Aspose.Slides'te, çalışma sayfası [ChartDataWorkbook](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdataworkbook/) sınıfı aracılığıyla sunulur. A1‑stili formüller için [ChartDataCell::setFormula](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatacell/#setFormula), R1C1‑stili formüller için ise [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatacell/#setR1C1Formula) kullanın. Giriş hücrelerini veya formülleri değiştirdikten sonra, desteklenen formülleri yeniden hesaplamak ve ilgili hücre değerlerini güncellemek için [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) metodunu çağırın.

Hesaplanan bir hücre yine de sonucunu [ChartDataCell::getValue](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatacell/#getValue) aracılığıyla sunar. Bu, kod içinde bir formül sonucunu incelemeniz gerektiğinde veya hücreyi bir grafik veri noktası olarak kullandığınızda önemlidir.

## **Grafik Oluşturma ve Çalışma Sayfası Formüllerini Hesaplama**

Aşağıdaki örnek uçtan uca bir iş akışını gösterir. Bir kümelenmiş sütun grafiği oluşturur, örnek verileri temizler, çeyrek gelir ve gider değerlerini yazar, formüllerle karı hesaplar, sonuçları okur, hesaplanan hücreleri grafik değerleri olarak kullanır ve sunumu kaydeder.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 350);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $worksheetIndex = 0;

    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    $workbook->clear($worksheetIndex);

    $category1 = $workbook->getCell($worksheetIndex, "A2", "Q1");
    $category2 = $workbook->getCell($worksheetIndex, "A3", "Q2");
    $category3 = $workbook->getCell($worksheetIndex, "A4", "Q3");

    $workbook->getCell($worksheetIndex, "B1", "Revenue");
    $workbook->getCell($worksheetIndex, "C1", "Expenses");
    $workbook->getCell($worksheetIndex, "D1", "Profit");

    $workbook->getCell($worksheetIndex, "B2")->setValue(120.0);
    $workbook->getCell($worksheetIndex, "C2")->setValue(80.0);
    $workbook->getCell($worksheetIndex, "B3")->setValue(150.0);
    $workbook->getCell($worksheetIndex, "C3")->setValue(95.0);
    $workbook->getCell($worksheetIndex, "B4")->setValue(135.0);
    $workbook->getCell($worksheetIndex, "C4")->setValue(110.0);

    $profit1 = $workbook->getCell($worksheetIndex, "D2");
    $profit2 = $workbook->getCell($worksheetIndex, "D3");
    $profit3 = $workbook->getCell($worksheetIndex, "D4");

    $profit1->setFormula("B2-C2");
    $profit2->setFormula("B3-C3");
    $profit3->setFormula("B4-C4");

    $workbook->calculateFormulas();

    $q1Profit = java_values($profit1->getValue()); // 40
    $q2Profit = java_values($profit2->getValue()); // 55
    $q3Profit = java_values($profit3->getValue()); // 25

    echo "Q1 profit: " . $q1Profit . PHP_EOL;
    echo "Q2 profit: " . $q2Profit . PHP_EOL;
    echo "Q3 profit: " . $q3Profit . PHP_EOL;

    $chart->getChartData()->getCategories()->add($category1);
    $chart->getChartData()->getCategories()->add($category2);
    $chart->getChartData()->getCategories()->add($category3);

    $profitSeries = $chart->getChartData()->getSeries()->add($workbook->getCell($worksheetIndex, "D1"), $chart->getType());
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit1);
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit2);
    $profitSeries->getDataPoints()->addDataPointForBarSeries($profit3);
    $profitSeries->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);

    $presentation->save("chart-formulas.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Grafik veri noktaları `D2:D4` aralığını referans alır, dolayısıyla grafik hesaplanan kar değerlerini kullanır. Bu iş akışında ayrı bir grafik‑yenileme çağrısı yoktur: önce çalışma kitabını yeniden hesaplayın, ardından hesaplanan hücrelere referans veren grafik verisini kullanın veya kaydedin.

## **A1‑Stil Formüllerini Kullanma**

A1 gösterimi sütunları harflerle, satırları ise sayılarla tanımlar. A1‑stili ifadeleri [ChartDataCell::setFormula](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatacell/#setFormula) aracılığıyla atayın.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "C3")->setValue(10);
    $workbook->getCell(0, "F2")->setValue(2);
    $workbook->getCell(0, "G2")->setValue(3);
    $workbook->getCell(0, "H2")->setValue(4);

    $cell = $workbook->getCell(0, "A2");
    $cell->setFormula("C3+SUM(F2:H2)");

    $workbook->calculateFormulas();

    $value = java_values($cell->getValue()); // 19
} finally {
    $presentation->dispose();
}
```

Ortak A1 referans biçimleri şunlardır:

| Referans | Göreli | Mutlak | Karışık |
|---|---|---|---|
| Hücre | `A2` | `$A$2` | `A$2`, `$A2` |
| Satır | `2:2` | `$2:$2` | — |
| Sütun | `A:A` | `$A:$A` | — |
| Aralık | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Göreli referanslar, bir formül bir çalışma sayfası uygulaması tarafından taşındığında veya kopyalandığında değişebilir. Mutlak referanslar her iki koordinatı da sabit tutar, karışık referanslar ise yalnızca bir satırı veya bir sütunu sabitler.

## **R1C1‑Stil Formüllerini Kullanma**

R1C1 gösterimi satır ve sütunları sayısal olarak tanımlar. Göreli referanslar köşeli parantez içinde öteleme değerleri kullanır. Bu sözdizimini [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatacell/#setR1C1Formula) aracılığıyla atayın.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "B2")->setValue(12);
    $workbook->getCell(0, "C2")->setValue(5);

    $cell = $workbook->getCell(0, "D2");
    $cell->setR1C1Formula("RC[-2]-RC[-1]");

    $workbook->calculateFormulas();

    $value = java_values($cell->getValue()); // 7
} finally {
    $presentation->dispose();
}
```

Ortak R1C1 referans biçimleri şunlardır:

| Referans | Göreli | Mutlak | Karışık |
|---|---|---|---|
| Hücre | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Satır | `R[2]` | `R2` | — |
| Sütun | `C[3]` | `C3` | — |
| Aralık | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Örneğin, `D2` hücresinde `RC[-2]` aynı satırda iki sütun sola (`B2`) olan hücreyi ifade eder.

## **Formül Sabitleri ve Operatörler**

Yerleşik formül değerlendiricisi mantıksal değerleri, sayısal literalleri, dize değerlerini, çalışma sayfası hata değerlerini, aritmetik operatörleri ve karşılaştırma operatörlerini destekler.

### **Sabitler ve Literaller**

| Tür | Örnekler | Notlar |
|---|---|---|
| Mantıksal | `TRUE`, `FALSE` | `A2=TRUE` gibi mantıksal ifadelerde doğrudan kullanılabilir. |
| Sayısal | `1`, `0.5`, `.3`, `1E-2` | Yaygın ve bilimsel gösterimler desteklenir. |
| Dize | `"abc"`, `"2/3/2020 12:00"` | Metin literalleri formül içinde çift tırnak içinde yazılır. |
| Hata sonucu | `#DIV/0!`, `#N/A`, `#REF!` | Geçerli bir formül normal bir sonuç yerine bir hücre hata değeri döndürebilir. |

Bu örnek çeşitli sabit türlerini kullanır:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();

    $workbook->getCell(0, "A2")->setValue(false);
    $workbook->getCell(0, "B2")->setFormula("A2=TRUE");
    $workbook->getCell(0, "C2")->setFormula("1+0.5");
    $workbook->getCell(0, "D2")->setFormula(".3*1E-2");
    $workbook->getCell(0, "E2")->setFormula("\"abc\"");
    $workbook->getCell(0, "F2")->setFormula("2/0");

    $workbook->calculateFormulas();

    $logicalValue = java_values($workbook->getCell(0, "B2")->getValue()); // yanlış
    $numericValue = java_values($workbook->getCell(0, "C2")->getValue()); // 1.5
    $scientificValue = java_values($workbook->getCell(0, "D2")->getValue()); // 0.003
    $stringValue = java_values($workbook->getCell(0, "E2")->getValue()); // abc
    $errorValue = java_values($workbook->getCell(0, "F2")->getValue()); // #DIV/0!
} finally {
    $presentation->dispose();
}
```

### **Aritmetik Operatörler**

| Operatör | Anlam | Örnek |
|---|---|---|
| `+` | Toplama veya tekli artı | `2+3` |
| `-` | Çıkarma veya tersine çevirme | `2-3`, `-3` |
| `*` | Çarpma | `2*3` |
| `/` | Bölme | `2/3` |
| `%` | Yüzde | `30%` |
| `^` | Üs alma | `2^3` |

Değerlendirme sırasını açıkça belirtmek için parantez kullanın, örneğin `(A2+B2)*C2`.

### **Karşılaştırma Operatörleri**

Karşılaştırma ifadeleri mantıksal değer döndürür.

| Operatör | Anlam | Örnek |
|---|---|---|
| `=` | Eşittir | `A2=3` |
| `<>` | Eşit değildir | `A2<>3` |
| `>` | Büyük | `A2>3` |
| `>=` | Büyük veya eşit | `A2>=3` |
| `<` | Küçük | `A2<3` |
| `<=` | Küçük veya eşit | `A2<=3` |

## **Desteklenen Önceden Tanımlı Fonksiyonlar**

Aspose.Slides, grafik çalışma sayfaları için yerleşik bir formül değerlendiricisi içerir, ancak bu tam bir Excel hesaplama motoru değildir. Belgelenen fonksiyon kümesi aşağıdaki ile sınırlıdır. [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) ile rastgele bir Excel fonksiyonunun yeniden hesaplanabileceğini varsaymayın.

| Fonksiyon | Amaç veya desteklenen form | Örnek |
|---|---|---|
| `ABS` | Mutlak değer | `ABS(A2)` |
| `AVERAGE` | Aritmetik ortalama | `AVERAGE(B2:B5)` |
| `CEILING` | Sayıyı bir katına yukarı yuvarla | `CEILING(A2,5)` |
| `CHOOSE` | İndexe göre bir değer seç | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Metin değerlerini birleştir | `CONCAT(A2,B2)` |
| `CONCATENATE` | Metin değerlerini birleştir | `CONCATENATE(A2," ",B2)` |
| `DATE` | 1900 tarih sistemi kullanarak tarih değeri oluştur | `DATE(2026,8,19)` |
| `DAYS` | Tarihler arasındaki gün sayısını döndür | `DAYS(B2,A2)` |
| `FIND` | Bir metin değerini başka bir içinde bul | `FIND("-",A2)` |
| `FINDB` | Bayt tabanlı metin araması | `FINDB("a",A2)` |
| `IF` | Koşullu sonuç | `IF(A2>0,A2,0)` |
| `INDEX` | Referans formu | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektör formu | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektör formu | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maksimum değer | `MAX(B2:B5)` |
| `SUM` | Değerleri toplar | `SUM(B2:B5)` |
| `VLOOKUP` | Dikey arama | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Tablodaki kısıtlamalar önemlidir: `INDEX` referans formunda belgelenirken, `LOOKUP` ve `MATCH` vektör formlarında belgelenir. `DATE` 1900 tarih sistemini kullanır. Burada listelenmeyen özellikler ve fonksiyonlar, ayrı ayrı belgelenmedikleri sürece Aspose.Slides formül değerlendiricisi tarafından desteklenmez.

## **Yeniden Hesaplama ve Önbelleklenmiş Değerler**

Çalışma sayfası dosyaları genellikle bir formül ve onun son hesaplanmış değerini birlikte saklar. Bu nedenle Aspose.Slides, bir sunum yüklendiğinde ve ilgili grafik verileri değiştirilmediğinde [ChartDataCell::getValue](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatacell/#getValue) üzerinden önbelleklenmiş bir değeri okuyabilir.

Giriş hücrelerini veya formülleri değiştirdikten sonra eski önbelleklenmiş sonuca güvenmeyin. Hesaplanan değerleri okumadan veya onlara bağımlı grafik verisini kaydetmeden önce [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) çağırın.

Desteklenen alt kümenin dışındaki formüller için Aspose.Slides formülü ayrıştıramayabilir veya bağımlılıklarını kuramayabilir. Çalışma kitabı değiştirildiyse, önceki önbelleklenmiş değer artık güvenilir sayılmaz. Bu durumda, desteklenmeyen veri içeren bir hücrenin değeri okunmaya çalışıldığında [CellUnsupportedDataException](https://reference.aspose.com/slides/tr/php-java/aspose.slides/cellunsupporteddataexception/) ortaya çıkabilir.

Grafiğiniz Aspose.Slides'ın değerlendirmediği Excel fonksiyonlarına dayanıyorsa, bu formülleri bu fonksiyonları destekleyen bir çalışma sayfası motoru ile hesaplayıp sonuçları grafik çalışma kitabına yazın. Desteklenmeyen formülleri tahmini değerlerle değiştirmeyin.

## **Formül Hatalarını Ele Alma**

Ayırmanız gereken iki farklı sorun türü vardır.

Bir formül geçerli olabilir ancak `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` veya `#VALUE!` gibi bir çalışma sayfası hata sonucu üretebilir. Bu durumda hata belirteci bir hücre sonucudur ve [ChartDataCell::getValue](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatacell/#getValue) aracılığıyla döndürülebilir.

Bir formül ayrıca ayrıştırma, referans, bağımlılık veya desteklenmeyen‑veri düzeyinde başarısız olabilir. Aspose.Slides bu durumlar için [CellInvalidFormulaException](https://reference.aspose.com/slides/tr/php-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/tr/php-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/tr/php-java/aspose.slides/cellcircularreferenceexception/) ve [CellUnsupportedDataException](https://reference.aspose.com/slides/tr/php-java/aspose.slides/cellunsupporteddataexception/) gibi çalışma sayfasına özgü istisnalar sağlar.

PHP üzerinden Java'da, Java istisnaları `JavaException` aracılığıyla ortaya çıkar. Formüller şablonlardan veya kullanıcı girdisinden geldiğinde, yeniden hesaplama ve değer erişimi etrafında bu istisnaları ele alın. Yığın izinde rapor edilen Java istisnası, belirli çalışma sayfası hatasını tanımlar:

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 300);
    $workbook = $chart->getChartData()->getChartDataWorkbook();
    $cell = $workbook->getCell(0, "A2");
    $cell->setFormula("SUM(B2:B5)");

    try {
        $workbook->calculateFormulas();
        echo java_values($cell->getValue()) . PHP_EOL;
    } catch (JavaException $ex) {
        $ex->printStackTrace();
    }
} finally {
    $presentation->dispose();
}
```

## **Pratik Sınırlamalar**

Grafik çalışma sayfalarındaki formül desteği, tam Excel uyumluluğu yerine tanımlı bir alt küme hesaplamalar için tasarlanmıştır. Raporlama iş akışınızı tasarlarken şu kısıtlamaları göz önünde bulundurun:

- Aspose.Slides'ın formülleri yeniden hesaplamasını istediğinizde yalnızca belgelenen sabitleri, operatörleri, referansları ve fonksiyonları kullanın.
- Formül sonuçlarının bağımlı olduğu hücreleri değiştirdikten sonra yeniden hesaplayın.
- Yüklenmiş sunumlardaki önbelleklenmiş değerleri anlık anlık bir görüntü olarak değerlendirin; düzenleme sonrasında yeniden hesaplama yerine bunları kullanmayın.
- Mevcut şablonlardan gelen formülleri, belgelenen liste dışındaki fonksiyonları içeriyorsa, hesaplanmış değerlerine güvenmeden önce test edin.
- Tam bir çalışma sayfası hesaplama motoru gerektiren formüller için, bunları harici olarak hesaplayıp ardından grafik çalışma kitabını sonuçlarla güncelleyin.

## **SSS**

**[ChartDataCell::setFormula](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatacell/#setFormula) ile [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatacell/#setR1C1Formula) arasındaki fark nedir?**

[ChartDataCell::setFormula](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatacell/#setFormula) `B2-C2` gibi bir A1‑stili ifadesi saklar. [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatacell/#setR1C1Formula) ise `RC[-2]-RC[-1]` gibi bir R1C1‑stili ifadesi saklar. Formülleri nasıl oluşturup kopyaladığınıza en uygun notasyonu kullanın.

**Hesaplamadan sonra hücreyi kendisini mi yoksa değerini mi okumam gerekir?**

[ChartDataWorkbook::getCell](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdataworkbook/#getCell) bir [ChartDataCell](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatacell/) döndürür. Hesaplanmış sonucu elde etmek için, yeniden hesaplamadan sonra o hücrenin [ChartDataCell::getValue](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatacell/#getValue) metodunu çağırın.

**[ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) metodunu ne zaman çağırmalıyım?**

Giriş değerlerini veya formülleri değiştirdikten ve hesaplanmış sonuçlara bağımlı olmadan önce [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) metodunu çağırın. Bu, yerleşik değerlendiricinin desteklediği formüllerin değerlerini günceller.

**Aspose.Slides her Excel fonksiyonunu destekliyor mu?**

Hayır. Yerleşik değerlendirici, belgelenen bir fonksiyon alt kümesini destekler. Bu alt kümenin dışındaki fonksiyonların doğru şekilde yeniden hesaplanacağını varsaymayın. Tam Excel formül uyumluluğu gerekiyorsa, hesaplamayı uygun bir çalışma sayfası motoru ile yapın ve sonuçları grafik çalışma kitabına yazın.

**Yüklenmiş bir sunum desteklenmeyen bir formül içerirse ne olur?**

Grafik verileri değişmemişse, çalışma kitabı hâlâ daha önce hesaplanmış bir önbelleklenmiş değer içerebilir. İlgili veri değiştirildiğinde bu önbelleklenmiş değer geçersiz olabilir. Formülü işlenemeyen bir hücreye erişmek, [CellUnsupportedDataException](https://reference.aspose.com/slides/tr/php-java/aspose.slides/cellunsupporteddataexception/) ortaya çıkarabilir.

**Formül hata değerleri PHP istisnalarıyla aynı şey mi?**

Hayır. `#DIV/0!` gibi bir sonuç, geçerli bir hesaplamanın ürettiği bir çalışma sayfası değeridir. [CellInvalidFormulaException](https://reference.aspose.com/slides/tr/php-java/aspose.slides/cellinvalidformulaexception/) veya [CellCircularReferenceException](https://reference.aspose.com/slides/tr/php-java/aspose.slides/cellcircularreferenceexception/) gibi çalışma sayfası işleme hataları, `JavaException` aracılığıyla PHP'ye yansıtılan Java istisnalarıdır.

**Bir formül hücresi değiştiğinde grafik otomatik olarak güncellenir mi?**

Bir grafik serisi çalışma kitabı hücrelerine başvurabilir. Önce çalışma kitabını yeniden hesaplayın, ardından sunumu kaydedin veya render edin. Grafik veri noktaları hesaplanan hücrelere başvuruyorsa, grafik bu güncellenmiş hücre değerlerini kullanır; bu iş akışı için ayrı bir grafik‑yenileme yöntemi gerekmez.

**Grafikler harici bir Excel çalışma kitabını kullanabilir mi?**

Evet, grafik verileri API aracılığıyla harici bir çalışma kitabına ayarlanabilir. Ancak bu makalede açıklanan formül hesaplama iş akışı, grafik veri çalışma kitabını ve Aspose.Slides tarafından değerlendirilen formül alt kümesini kapsar. [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) metodunun dış bir XLSX dosyasındaki rastgele formüllerin tam yeniden hesaplamasını sağlayacağını varsaymayın.

**Başka bir çalışma sayfasına veya çalışma kitabına başvuran formüller kullanabilir miyim?**

Excel‑stili referanslar grafik çalışma kitaplarında bulunabilir, ancak formül değerlendirmesi desteklenen ayrıştırıcı ve fonksiyon kümesiyle sınırlıdır. Çapraz‑sayfa veya harici bir referans zorunluysa, hedef Aspose.Slides sürümünüzle bu formülü doğrulayın. Geniş Excel referans uyumluluğu gerektiren iş akışları için, çalışma kitabını harici olarak hesaplayıp çözülen değerleri grafik verisine geri yazın.

**Formül dizelemeleri `=` ile başlamalı mı?**

Aspose.Slides API örnekleri, `B2-C2` veya `SUM(B2:B5)` gibi ifadeleri baştaki `=` işareti olmadan atar. Bu biçimi kullanmak, oluşturulan formüllerin belgelenen API örnekleriyle tutarlı olmasını sağlar.