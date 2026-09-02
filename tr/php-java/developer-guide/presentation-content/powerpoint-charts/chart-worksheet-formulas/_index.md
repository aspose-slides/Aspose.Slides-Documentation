---
title: PowerPoint sunumlarında PHP ile Grafik Çalışma Sayfası Formüllerini Uygulama
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
- formül hesaplaması
- tercih edilen kültür
- kültüre özgü formül
- DBCS
- mantıksal sabit
- sayısal sabit
- metin sabiti
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
description: "Aspose.Slides for PHP via Java grafik çalışma sayfalarında Excel tarzı formüller uygulayın, değerleri yeniden hesaplayın ve sonuçları PowerPoint grafiklerinde kullanın."
---
## **Genel Bakış**

PowerPoint grafiklerinin veri kaynağı genellikle gömülü bir çalışma sayfasında saklanır. Aspose.Slides for PHP via Java’da bu çalışma sayfasına grafik veri çalışma kitabı aracılığıyla erişebilir, giriş değerlerini yazabilir, hücrelere formüller atayabilir, desteklenen formülleri hesaplayabilir ve hesaplanmış hücreleri grafik verisi olarak kullanabilirsiniz.

Bu makale tam formül iş akışını açıklar: bir grafik oluşturma, çalışma sayfasını doldurma, A1‑stili veya R1C1‑stili formüller atama, yeniden hesaplama, hesaplanmış değerleri okuma, bu hücreleri bir grafik serisine bağlama ve sunumu kaydetme. Ayrıca desteklenen formül sözdizimi, yerleşik işlev alt kümesi, önbelleğe alınmış değerler, desteklenmeyen formüller ve elektronik tabloya özgü hatalar da açıklanır.

## **Grafik Çalışma Sayfaları ve Formüller**

Bir grafik çalışma sayfası, bir grafik tarafından kullanılan kategorileri, seri adlarını ve değerleri içerir. PowerPoint’te grafik veri düzenleyicisini açarak çalışma sayfasını inceleyebilirsiniz:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

Aspose.Slides’ta çalışma sayfası, [ChartDataWorkbook](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdataworkbook/) sınıfı aracılığıyla sunulur. A1‑stili formüller için [ChartDataCell::setFormula](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatacell/#setFormula), R1C1‑stili formüller için ise [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatacell/#setR1C1Formula) kullanın. Giriş hücrelerini veya formülleri değiştirdikten sonra, desteklenen formülleri yeniden hesaplamak ve ilgili hücre değerlerini güncellemek için [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) yöntemini çağırın.

Hesaplanmış bir hücre, sonucunu hâlâ [ChartDataCell::getValue](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatacell/#getValue) aracılığıyla ortaya çıkarır. Bu, kod içinde bir formül sonucunu incelemeniz gerektiğinde veya hücreyi bir grafik veri noktası olarak kullanmanız gerektiğinde önemlidir.

## **Bir Grafik Oluşturma ve Çalışma Sayfası Formüllerini Hesaplama**

Aşağıdaki örnek uçtan uca bir iş akışını gösterir. Küme sütun grafiği oluşturur, örnek verileri temizler, çeyrek gelir ve gider değerlerini yazar, formüllerle karı hesaplar, sonuçları okur, hesaplanmış hücreleri grafik değerleri olarak kullanır ve sunumu kaydeder.

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

Grafik veri noktaları `D2:D4` aralığını referans alır, böylece grafik hesaplanmış kar değerlerini kullanır. Bu iş akışında ayrı bir grafik‑yenileme çağrısı yoktur: önce çalışma kitabını yeniden hesaplayın, ardından hesaplanan hücrelere işaret eden grafik verisini kullanın veya kaydedin.

## **A1‑Stili Formüller Kullanma**

A1 gösterimi sütunları harflerle, satırları sayılarla tanımlar. A1‑stili ifadeleri [ChartDataCell::setFormula](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatacell/#setFormula) aracılığıyla atayın.

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

Yaygın A1 referans biçimleri:

| Referans | Göreceli | Mutlak | Karma |
|---|---|---|---|
| Hücre | `A2` | `$A$2` | `A$2`, `$A2` |
| Satır | `2:2` | `$2:$2` | — |
| Sütun | `A:A` | `$A:$A` | — |
| Aralık | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Göreceli referanslar, bir formül bir elektronik tablo uygulaması tarafından taşındığında veya kopyalandığında değişebilir. Mutlak referanslar her iki koordinatı da sabit tutar, karma referanslar ise yalnızca bir satırı veya bir sütunu sabitler.

## **R1C1‑Stili Formüller Kullanma**

R1C1 gösterimi hem satırları hem de sütunları sayısal olarak tanımlar. Göreceli referanslar köşeli parantez içinde offset kullanır. Bu sözdizimini [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatacell/#setR1C1Formula) aracılığıyla atayın.

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

Yaygın R1C1 referans biçimleri:

| Referans | Göreceli | Mutlak | Karma |
|---|---|---|---|
| Hücre | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Satır | `R[2]` | `R2` | — |
| Sütun | `C[3]` | `C3` | — |
| Aralık | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Örneğin, `D2` hücresinde `RC[-2]` aynı satırda iki sütun sola olan hücreyi (`B2`) ifade eder.

## **Formül Sabitleri ve Operatörler**

Yerleşik formül değerlendirme motoru mantıksal değerler, sayısal sabitler, metinler, elektronik tablo hata değerleri, aritmetik operatörler ve karşılaştırma operatörlerini destekler.

### **Sabitler ve Sabit Değerler**

| Tür | Örnekler | Notlar |
|---|---|---|
| Mantıksal | `TRUE`, `FALSE` | `A2=TRUE` gibi mantıksal ifadelerde doğrudan kullanılabilir. |
| Sayısal | `1`, `0.5`, `.3`, `1E-2` | Kesirli ve bilimsel gösterimler desteklenir. |
| Metin | `"abc"`, `"2/3/2020 12:00"` | Metin sabitleri formül içinde çift tırnak içinde yazılır. |
| Hata sonucu | `#DIV/0!`, `#N/A`, `#REF!` | Geçerli bir formül, normal bir sonuç yerine bir elektronik tablo hata değeri döndürebilir. |

Bu örnek birkaç sabit türü kullanır:

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

    $logicalValue = java_values($workbook->getCell(0, "B2")->getValue()); // false
    $numericValue = java_values($workbook->getCell(0, "C2")->getValue()); // 1.5
    $scientificValue = java_values($workbook->getCell(0, "D2")->getValue()); // 0.003
    $stringValue = java_values($workbook->getCell(0, "E2")->getValue()); // abc
    $errorValue = java_values($workbook->getCell(0, "F2")->getValue()); // #DIV/0!
} finally {
    $presentation->dispose();
}
```

### **Aritmetik Operatörler**

| Operatör | Anlamı | Örnek |
|---|---|---|
| `+` | Toplama veya tek artı | `2+3` |
| `-` | Çıkarma veya eksi | `2-3`, `-3` |
| `*` | Çarpma | `2*3` |
| `/` | Bölme | `2/3` |
| `%` | Yüzde | `30%` |
| `^` | Üs alma | `2^3` |

Değerlendirme sırasını açıkça belirtmek için parantez kullanın, örneğin `(A2+B2)*C2`.

### **Karşılaştırma Operatörleri**

Karşılaştırma ifadeleri mantıksal değer döndürür.

| Operatör | Anlamı | Örnek |
|---|---|---|
| `=` | Eşittir | `A2=3` |
| `<>` | Eşit değildir | `A2<>3` |
| `>` | Büyüktür | `A2>3` |
| `>=` | Büyük veya eşittir | `A2>=3` |
| `<` | Küçüktür | `A2<3` |
| `<=` | Küçük veya eşittir | `A2<=3` |

## **Desteklenen Önceden Tanımlı İşlevler**

Aspose.Slides, grafik çalışma sayfaları için yerleşik bir formül değerlendirme motoru içerir, ancak bu bir tam Excel hesaplama motoru değildir. Belgelenen işlev kümesi aşağıdaki ile sınırlıdır. [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) tarafından rastgele bir Excel işlevinin yeniden hesaplanabileceğini varsaymayın.

| İşlev | Açıklama veya desteklenen biçim | Örnek |
|---|---|---|
| `ABS` | Mutlak değer | `ABS(A2)` |
| `AVERAGE` | Aritmetik ortalama | `AVERAGE(B2:B5)` |
| `CEILING` | Sayıyı yukarı doğru bir katına yuvarla | `CEILING(A2,5)` |
| `CHOOSE` | İndekse göre değer seç | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Metin değerlerini birleştir | `CONCAT(A2,B2)` |
| `CONCATENATE` | Metin değerlerini birleştir | `CONCATENATE(A2," ",B2)` |
| `DATE` | 1900 tarih sistemini kullanarak tarih değeri oluştur | `DATE(2026,8,19)` |
| `DAYS` | İki tarih arasındaki gün sayısını döndür | `DAYS(B2,A2)` |
| `FIND` | Bir metin içinde başka bir metni bul | `FIND("-",A2)` |
| `FINDB` | Bayt‑temelli metin arama | `FINDB("a",A2)` |
| `IF` | Koşullu sonuç | `IF(A2>0,A2,0)` |
| `INDEX` | Referans biçimi | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektör biçimi | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektör biçimi | `MATCH(A2,B2:B5,0)` |
| `MAX` | En büyük değer | `MAX(B2:B5)` |
| `SUM` | Değerleri topla | `SUM(B2:B5)` |
| `VLOOKUP` | Dikey arama | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Tablodaki kısıtlamalar önemlidir: `INDEX` referans biçiminde, `LOOKUP` ve `MATCH` vektör biçiminde belgelenir. `DATE` 1900 tarih sistemini kullanır. Burada listelenmeyen işlevler, Aspose.Slides formül değerlendirme motoru tarafından desteklenmiyor olarak kabul edilmelidir.

## **Tercih Edilen Kültürle Formülleri Hesaplama**

Bazı grafik çalışma kitabı işlevleri metni kültüre özgü kurallara göre yorumlar. Bu, çift‑bayt karakter seti (DBCS) kullanan diller için özellikle önemlidir. Bu formülleri doğru şekilde hesaplamak için bir [LoadOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/) oluşturun, tercih edilen kültürü [SpreadsheetOptions::setPreferredCulture](https://reference.aspose.com/slides/tr/php-java/aspose.slides/spreadsheetoptions/#setPreferredCulture) ile ayarlayın, elektronik tablo seçeneklerini [LoadOptions::setSpreadsheetOptions](https://reference.aspose.com/slides/tr/php-java/aspose.slides/loadoptions/#setSpreadsheetOptions) ile atayın ve ardından sunumu yükleyin.

Aşağıdaki örnek Japon kültürünü seçer, yapılandırılmış yükleme seçenekleriyle bir sunum açar ve her grafik çalışma kitabı için [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) yöntemini çağırır:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SpreadsheetOptions;

$japaneseCulture = new Java("java.util.Locale", "ja", "JP");

$spreadsheetOptions = new SpreadsheetOptions();
$spreadsheetOptions->setPreferredCulture($japaneseCulture);

$loadOptions = new LoadOptions();
$loadOptions->setSpreadsheetOptions($spreadsheetOptions);

$chartClass = new JavaClass("com.aspose.slides.IChart");
$presentation = new Presentation("presentation.pptx", $loadOptions);
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (java_instanceof($shape, $chartClass)) {
                $shape->getChartData()->getChartDataWorkbook()->calculateFormulas();
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Tercih edilen kültür, sunum yükleme yapılandırmasının bir parçasıdır; bu yüzden [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) örneğini oluşturmadan önce ayarlayın. Çalışma kitabı formüllerinin beklediği kültürü kullanın; örneğin Japon DBCS hesaplama kurallarına uyması gereken formüller için `ja-JP` kullanın.

## **Yeniden Hesaplama ve Önbelleğe Alınmış Değerler**

Elektronik tablo dosyaları genellikle bir formül ve onun son hesaplanmış değerini saklar. Aspose.Slides, bir sunum yüklendiğinde ve ilgili grafik verisi değiştirilmediğinde, [ChartDataCell::getValue](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatacell/#getValue) üzerinden önbelleğe alınmış bir değeri okuyabilir.

Giriş hücrelerini veya formülleri değiştirdikten sonra eski bir önbellek sonucuna güvenmeyin. Hesaplanmış değerleri okumadan veya bunlara bağımlı grafik verisini kaydetmeden önce [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) yöntemini çağırın.

Desteklenen alt kümenin dışındaki formüller için, Aspose.Slides formülü ayrıştıramayabilir veya bağımlılıklarını belirleyemeyebilir. Çalışma kitabı değiştirilmişse, önceki önbellek değeri artık güvenilir olmayabilir. Bu durumda, desteklenmeyen veri içeren bir hücreyi okumak [CellUnsupportedDataException](https://reference.aspose.com/slides/tr/php-java/aspose.slides/cellunsupporteddataexception/) hatasına yol açabilir.

Grafiğiniz Aspose.Slides’ın değerlendirmediği Excel işlevlerine dayanıyorsa, bu formülleri destekleyen bir elektronik tablo motoru ile hesaplayın ve oluşan değerleri grafik çalışma kitabına geri yazın. Desteklenmeyen formülleri tahmini değerlerle değiştirmeyin.

## **Formül Hatalarını Ele Alma**

İki farklı sorun türü vardır.

Bir formül geçerli olabilir ancak `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` veya `#VALUE!` gibi bir elektronik tablo hata sonucu üretebilir. Bu durumda hata belirteci bir hücre sonucu olup [ChartDataCell::getValue](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatacell/#getValue) üzerinden döndürülebilir.

Bir formül ayrıca ayrıştırma, referans, bağımlılık veya desteklenen veri düzeyinde başarısız olabilir. Aspose.Slides bu durumlar için elektronik tabloya özgü istisnalar sağlar: [CellInvalidFormulaException](https://reference.aspose.com/slides/tr/php-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/tr/php-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/tr/php-java/aspose.slides/cellcircularreferenceexception/), ve [CellUnsupportedDataException](https://reference.aspose.com/slides/tr/php-java/aspose.slides/cellunsupporteddataexception/).

PHP via Java’da, Java istisnaları `JavaException` aracılığıyla ortaya çıkar. Formüller şablonlardan veya kullanıcı girişinden geldiğinde, yeniden hesaplama ve değer erişimi etrafında bu istisnaları yakalayın. Yığın izinde bildirilen Java istisnası, belirli elektronik tablo hatasını tanımlar:

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

Grafik çalışma sayfalarındaki formül desteği, tam Excel uyumluluğu olmayan tanımlı bir elektronik tablo hesaplama alt kümesi içindir. Raporlama iş akışınızı tasarlarken şu kısıtlamaları aklınızda bulundurun:

- Aspose.Slides’ın formülleri yeniden hesaplamasını istediğinizde yalnızca belgelenen sabitleri, operatörleri, referansları ve işlevleri kullanın.
- Formül sonuçlarının bağlı olduğu hücreleri değiştirdikten sonra yeniden hesaplayın.
- Yüklenen sunumlardan gelen önbelleğe alınmış değerleri anlık bir fotoğraf olarak düşünün; düzenlemeler sonrası yeniden hesaplamanın yerine geçmesin.
- Mevcut şablonlardaki formülleri, belgelenen işlev listesi dışındaki işlevleri içeriyorsa, hesaplanmış değerlerine güvenmeden önce test edin.
- Tam bir elektronik tablo hesaplama motoru gerektiren formüller için, bunları dışarıda hesaplayın ve ardından grafik çalışma kitabını elde edilen değerlerle güncelleyin.

## **SSS**

**[ChartDataCell::setFormula](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatacell/#setFormula) ve [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatacell/#setR1C1Formula) arasındaki fark nedir?**

[ChartDataCell::setFormula](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatacell/#setFormula) `B2-C2` gibi bir A1‑stili ifade saklar. [ChartDataCell::setR1C1Formula](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatacell/#setR1C1Formula) ise `RC[-2]-RC[-1]` gibi bir R1C1‑stili ifade saklar. Formülleri nasıl oluşturduğunuza veya kopyaladığınıza en uygun gösterimi kullanın.

**Hesaplamadan sonra hücreyi mi yoksa değerini mi okumalıyım?**

[ChartDataWorkbook::getCell](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdataworkbook/#getCell) bir [ChartDataCell](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatacell/) döndürür. Hesaplanmış sonucu elde etmek için, yeniden hesaplamadan sonra bu hücrenin [ChartDataCell::getValue](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdatacell/#getValue) yöntemini çağırın.

**[ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) ne zaman çağırılmalı?**

Giriş değerlerini veya formülleri değiştirdikten ve hesaplanmış sonuçlara ihtiyaç duymadan önce [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) yöntemini çağırın. Bu, yerleşik değerlendiricinin desteklediği formüllerin değerlerini günceller.

**Aspose.Slides her Excel işlevini destekliyor mu?**

Hayır. Yerleşik değerlendirici belgelenen bir işlev alt kümesini destekler. Bu alt kümenin dışındaki işlevlerin doğru şekilde yeniden hesaplanacağını varsaymayın. Tam Excel formül uyumluluğu gerekiyorsa, hesaplamayı uygun bir elektronik tablo motoru ile yapın ve son değerleri grafik çalışma kitabına yazın.

**Yüklenmiş bir sunumda desteklenmeyen bir formül varsa ne olur?**

Grafik verisi değişmemişse, çalışma kitabı hâlâ önceki hesaplanmış önbellek değerini içerebilir. İlgili veri değiştirildiğinde bu önbellek değeri geçerli olmayabilir. Formülü işlenemeyen bir hücreye erişmek [CellUnsupportedDataException](https://reference.aspose.com/slides/tr/php-java/aspose.slides/cellunsupporteddataexception/) hatasına yol açabilir.

**Formül hata değerleri PHP istisnalarıyla aynı şey midir?**

Hayır. `#DIV/0!` gibi bir sonuç, geçerli bir hesaplamanın ürettiği bir elektronik tablo değeridir. [CellInvalidFormulaException](https://reference.aspose.com/slides/tr/php-java/aspose.slides/cellinvalidformulaexception/) veya [CellCircularReferenceException](https://reference.aspose.com/slides/tr/php-java/aspose.slides/cellcircularreferenceexception/) gibi spreadsheet‑işleme hataları Java istisnalarıdır ve `JavaException` aracılığıyla PHP’ye yansıtılır.

**Bir formül hücresi değiştiğinde grafik otomatik olarak güncellenir mi?**

Bir grafik serisi çalışma kitabı hücrelerine referans verebilir. Önce çalışma kitabını yeniden hesaplayın, ardından sunumu kaydedin veya render edin. Grafik veri noktaları hesaplanmış hücrelere işaret ediyorsa, grafik bu güncellenmiş hücre değerlerini kullanır; bu iş akışı için ayrı bir grafik‑yenileme yöntemi gerekmez.

**Grafikler harici bir Excel çalışma kitabı kullanabilir mi?**

Evet, grafik verisi harici bir çalışma kitabı kullanacak şekilde yapılandırılabilir. Ancak bu makalede açıklanan formül hesaplama iş akışı, grafik veri çalışma kitabı ve Aspose.Slides tarafından değerlendirilen formül alt kümesiyle sınırlıdır. [ChartDataWorkbook::calculateFormulas](https://reference.aspose.com/slides/tr/php-java/aspose.slides/chartdataworkbook/#calculateFormulas) yönteminin harici bir XLSX dosyasındaki rastgele formülleri tam olarak yeniden hesaplayacağını varsaymayın.

**Başka bir çalışma sayfası veya çalışma kitabına referans veren formüller kullanabilir miyim?**

Excel‑stili referanslar grafik çalışma kitaplarında bulunabilir, ancak formül değerlendirmesi desteklenen ayrıştırıcı ve işlev kümesiyle sınırlıdır. Çapraz‑sayfa veya harici bir referans kritikse, hedef Aspose.Slides sürümünüzde tam formülü doğrulayın. Geniş Excel referans uyumluluğu gerektiren iş akışları için çalışma kitabını dışarıda hesaplayın ve çözülen değerleri grafik verisine geri yazın.

**Formül dizeleri `=` ile başlamalı mı?**

Aspose.Slides API örnekleri, `B2-C2` veya `SUM(B2:B5)` gibi ön ek `=` olmadan ifadeler atar. Bu biçimi kullanmak, oluşturulan formüllerin belgelenen API örnekleriyle tutarlı olmasını sağlar.