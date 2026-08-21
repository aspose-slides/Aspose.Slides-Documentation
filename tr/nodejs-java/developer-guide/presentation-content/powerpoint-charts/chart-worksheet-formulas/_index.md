---
title: JavaScript ile Sunumlarda Grafik Çalışma Sayfası Formüllerini Uygulama
linktitle: Çalışma Sayfası Formülleri
type: docs
weight: 70
url: /tr/nodejs-java/chart-worksheet-formulas/
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
- önceden tanımlı fonksiyon
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java grafik çalışma sayfalarında Excel tarzı formülleri uygulayın, değerleri yeniden hesaplayın ve sonuçları PowerPoint grafiklerinde kullanın."
---
## **Genel Bakış**

PowerPoint grafiklerinin çoğu kaynak verilerini gömülü bir çalışma sayfasında saklar. Aspose.Slides for Node.js via Java ile bu çalışma sayfasına grafik veri çalışma kitabı aracılığıyla erişebilir, giriş değerlerini yazabilir, hücrelere formül atayabilir, desteklenen formülleri hesaplayabilir ve hesaplanan hücreleri grafik verisi olarak kullanabilirsiniz.

Bu makale tam formül iş akışını açıklar: bir grafik oluşturma, çalışma sayfasını doldurma, A1‑stili ya da R1C1‑stili formüller atama, bunları yeniden hesaplama, hesaplanan değerleri okuma, bu hücreleri bir grafik serisine bağlama ve sunumu kaydetme. Ayrıca desteklenen formül sözdizimini, yerleşik fonksiyon alt kümesini, önbelleğe alınmış değerleri, desteklenmeyen formülleri ve elektronik tabloya özgü hataları da açıklar.

## **Grafik Çalışma Sayfaları ve Formüller**

Bir grafik çalışma sayfası, bir grafik tarafından kullanılan kategorileri, seri adlarını ve değerleri içerir. PowerPoint'te grafik veri düzenleyicisini açarak çalışma sayfasını inceleyebilirsiniz:

![Kategori ve seri verilerini gösteren, gömülü çalışma sayfası açık PowerPoint grafiği](chart-worksheet-formulas_1.png)

Aspose.Slides'te çalışma sayfası, [ChartDataWorkbook](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdataworkbook/) sınıfı aracılığıyla sunulur. A1‑stili formüller için [ChartDataCell.setFormula](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) ve R1C1‑stili formüller için [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) kullanın. Giriş hücrelerini veya formülleri değiştirdikten sonra, desteklenen formülleri yeniden hesaplamak ve ilgili hücre değerlerini güncellemek için [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) metodunu çağırın.

Hesaplanan bir hücre hâlâ sonucunu [ChartDataCell.getValue](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatacell/#getValue--) ile sunar. Bu, kod içinde bir formül sonucunu incelemeniz ya da hücreyi bir grafik veri noktası olarak kullanmanız gerektiğinde önemlidir.

## **Bir Grafik Oluşturma ve Çalışma Sayfası Formüllerini Hesaplama**

Aşağıdaki örnek uçtan uca bir iş akışını gösterir. Küme sütun grafiği oluşturur, örnek verileri temizler, üç aylık gelir ve gider değerlerini yazar, formüllerle karı hesaplar, sonuçları okur, hesaplanan hücreleri grafik değerleri olarak kullanır ve sunumu kaydeder.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 350);
    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    workbook.clear(worksheetIndex);

    const category1 = workbook.getCell(worksheetIndex, "A2", "Q1");
    const category2 = workbook.getCell(worksheetIndex, "A3", "Q2");
    const category3 = workbook.getCell(worksheetIndex, "A4", "Q3");

    workbook.getCell(worksheetIndex, "B1", "Revenue");
    workbook.getCell(worksheetIndex, "C1", "Expenses");
    workbook.getCell(worksheetIndex, "D1", "Profit");

    workbook.getCell(worksheetIndex, "B2").setValue(120.0);
    workbook.getCell(worksheetIndex, "C2").setValue(80.0);
    workbook.getCell(worksheetIndex, "B3").setValue(150.0);
    workbook.getCell(worksheetIndex, "C3").setValue(95.0);
    workbook.getCell(worksheetIndex, "B4").setValue(135.0);
    workbook.getCell(worksheetIndex, "C4").setValue(110.0);

    const profit1 = workbook.getCell(worksheetIndex, "D2");
    const profit2 = workbook.getCell(worksheetIndex, "D3");
    const profit3 = workbook.getCell(worksheetIndex, "D4");

    profit1.setFormula("B2-C2");
    profit2.setFormula("B3-C3");
    profit3.setFormula("B4-C4");

    workbook.calculateFormulas();

    const q1Profit = profit1.getValue(); // 40
    const q2Profit = profit2.getValue(); // 55
    const q3Profit = profit3.getValue(); // 25

    console.log("Q1 profit: " + q1Profit);
    console.log("Q2 profit: " + q2Profit);
    console.log("Q3 profit: " + q3Profit);

    chart.getChartData().getCategories().add(category1);
    chart.getChartData().getCategories().add(category2);
    chart.getChartData().getCategories().add(category3);

    const profitSeries = chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, "D1"), chart.getType());
    profitSeries.getDataPoints().addDataPointForBarSeries(profit1);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit2);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit3);
    profitSeries.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("chart-formulas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Grafik veri noktaları `D2:D4` aralığını referans alır, böylece grafik hesaplanan kar değerlerini kullanır. Bu iş akışında ayrı bir grafik‑yenileme çağrısı yoktur: önce çalışma kitabını yeniden hesaplayın, ardından hesaplanan hücreleri referans alan grafiği kullanın ya da kaydedin.

## **A1‑Stili Formüller Kullanma**

A1 notasyonu sütunları harflerle, satırları rakamlarla tanımlar. A1‑stili ifadeleri [ChartDataCell.setFormula](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) ile atayın.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "C3").setValue(10);
    workbook.getCell(0, "F2").setValue(2);
    workbook.getCell(0, "G2").setValue(3);
    workbook.getCell(0, "H2").setValue(4);

    const cell = workbook.getCell(0, "A2");
    cell.setFormula("C3+SUM(F2:H2)");

    workbook.calculateFormulas();

    const value = cell.getValue(); // 19
} finally {
    presentation.dispose();
}
```

Yaygın A1 referans biçimleri:

| Referans | Göreceli | Mutlak | Karışık |
|---|---|---|---|
| Hücre | `A2` | `$A$2` | `A$2`, `$A2` |
| Satır | `2:2` | `$2:$2` | — |
| Sütun | `A:A` | `$A:$A` | — |
| Aralık | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Göreceli referanslar bir formül bir elektronik tablo uygulaması tarafından taşındığında ya da kopyalandığında değişebilir. Mutlak referanslar her iki koordinatı da sabit tutar, karışık referanslar ise yalnızca satırı ya da sütunu sabitler.

## **R1C1‑Stili Formüller Kullanma**

R1C1 notasyonu hem satırları hem de sütunları sayısal olarak tanımlar. Göreceli referanslar köşeli parantez içinde ofsetler kullanır. Bu sözdizimini [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) ile atayın.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "B2").setValue(12);
    workbook.getCell(0, "C2").setValue(5);

    const cell = workbook.getCell(0, "D2");
    cell.setR1C1Formula("RC[-2]-RC[-1]");

    workbook.calculateFormulas();

    const value = cell.getValue(); // 7
} finally {
    presentation.dispose();
}
```

Yaygın R1C1 referans biçimleri:

| Referans | Göreceli | Mutlak | Karışık |
|---|---|---|---|
| Hücre | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Satır | `R[2]` | `R2` | — |
| Sütun | `C[3]` | `C3` | — |
| Aralık | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Örneğin, `D2` hücresinde `RC[-2]` aynı satırda iki sütun sola olan hücreyi (`B2`) belirtir.

## **Formül Sabitleri ve Operatörler**

Yerleşik formül değerlendirme motoru mantıksal değerler, sayısal sabitler, metinler, elektronik tablo hata değerleri, aritmetik operatörler ve karşılaştırma operatörlerini destekler.

### **Sabitler ve Literaller**

| Tür | Örnekler | Notlar |
|---|---|---|
| Mantıksal | `TRUE`, `FALSE` | `A2=TRUE` gibi mantıksal ifadelerde doğrudan kullanılabilir. |
| Sayısal | `1`, `0.5`, `.3`, `1E-2` | Hem yaygın hem de bilimsel gösterimler desteklenir. |
| Metin | `"abc"`, `"2/3/2020 12:00"` | Metin sabitleri formül içinde çift tırnak içinde yazılır. |
| Hata sonucu | `#DIV/0!`, `#N/A`, `#REF!` | Geçerli bir formül normal bir sonuç yerine bir elektronik tablo hata değeri üretebilir. |

Bu örnek birkaç sabit türünü gösterir:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "A2").setValue(false);
    workbook.getCell(0, "B2").setFormula("A2=TRUE");
    workbook.getCell(0, "C2").setFormula("1+0.5");
    workbook.getCell(0, "D2").setFormula(".3*1E-2");
    workbook.getCell(0, "E2").setFormula("\"abc\"");
    workbook.getCell(0, "F2").setFormula("2/0");

    workbook.calculateFormulas();

    const logicalValue = workbook.getCell(0, "B2").getValue(); // false
    const numericValue = workbook.getCell(0, "C2").getValue(); // 1.5
    const scientificValue = workbook.getCell(0, "D2").getValue(); // 0.003
    const stringValue = workbook.getCell(0, "E2").getValue(); // abc
    const errorValue = workbook.getCell(0, "F2").getValue(); // #DIV/0!
} finally {
    presentation.dispose();
}
```

### **Aritmetik Operatörler**

| Operatör | Anlam | Örnek |
|---|---|---|
| `+` | Toplama ya da tek artı | `2+3` |
| `-` | Çıkarma ya da negatif | `2-3`, `-3` |
| `*` | Çarpma | `2*3` |
| `/` | Bölme | `2/3` |
| `%` | Yüzde | `30%` |
| `^` | Üs alma | `2^3` |

Değerlendirme sırasını açıkça belirtmek için parantez kullanın; örneğin `(A2+B2)*C2`.

### **Karşılaştırma Operatörleri**

Karşılaştırma ifadeleri mantıksal değer döndürür.

| Operatör | Anlam | Örnek |
|---|---|---|
| `=` | Eşittir | `A2=3` |
| `<>` | Eşit değildir | `A2<>3` |
| `>` | Büyüktür | `A2>3` |
| `>=` | Büyük veya eşittir | `A2>=3` |
| `<` | Küçüktür | `A2<3` |
| `<=` | Küçük veya eşittir | `A2<=3` |

## **Desteklenen Önceden Tanımlı Fonksiyonlar**

Aspose.Slides, grafik çalışma sayfaları için yerleşik bir formül değerlendirme motoru içerir, ancak bu tam bir Excel hesaplama motoru değildir. Belgelenen fonksiyon kümesi aşağıdaki ile sınırlıdır. [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) ile rastgele bir Excel fonksiyonunun yeniden hesaplanacağını varsaymayın.

| Fonksiyon | Amaç veya desteklenen biçim | Örnek |
|---|---|---|
| `ABS` | Mutlak değer | `ABS(A2)` |
| `AVERAGE` | Aritmetik ortalama | `AVERAGE(B2:B5)` |
| `CEILING` | Sayıyı bir katına yukarı yuvarla | `CEILING(A2,5)` |
| `CHOOSE` | İndeks ile değer seç | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Metin değerlerini birleştir | `CONCAT(A2,B2)` |
| `CONCATENATE` | Metin değerlerini birleştir | `CONCATENATE(A2," ",B2)` |
| `DATE` | 1900 tarih sistemiyle tarih oluştur | `DATE(2026,8,19)` |
| `DAYS` | İki tarih arasındaki gün sayısını döndür | `DAYS(B2,A2)` |
| `FIND` | Bir metni başka bir metin içinde bul | `FIND("-",A2)` |
| `FINDB` | Bayt bazlı metin araması | `FINDB("a",A2)` |
| `IF` | Koşullu sonuç | `IF(A2>0,A2,0)` |
| `INDEX` | Referans biçimi | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektör biçimi | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektör biçimi | `MATCH(A2,B2:B5,0)` |
| `MAX` | En büyük değer | `MAX(B2:B5)` |
| `SUM` | Toplam | `SUM(B2:B5)` |
| `VLOOKUP` | Dikey arama | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Tabloda gösterilen kısıtlamalar önemlidir: `INDEX` referans biçiminde belgelenirken, `LOOKUP` ve `MATCH` vektör biçiminde belgelenir. `DATE` 1900 tarih sistemini kullanır. Burada listelenmeyen özellik ve fonksiyonlar, ayrı belgelenmedikçe Aspose.Slides formül değerlendirme motoru tarafından desteklenmez.

## **Tercih Edilen Kültür ile Formülleri Hesaplama**

Bazı çalışma kitabı fonksiyonları metni kültüre özgü kurallara göre yorumlar. Bu, çift bayt karakter seti (DBCS) kullanan diller için özellikle önemlidir. Bu tür formülleri doğru hesaplamak için [LoadOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/) oluşturun, [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/spreadsheetoptions/#setPreferredCulture) ile tercih edilen kültürü ayarlayın, [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/loadoptions/#setSpreadsheetOptions) ile elektronik tablo seçeneklerini atayın ve ardından sunumu yükleyin.

Aşağıdaki örnek Japon kültürünü seçer, yapılandırılmış yükleme seçenekleriyle bir sunumu açar ve her grafik çalışma kitabı için [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) metodunu çağırır:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const japaneseCulture = java.newInstanceSync("java.util.Locale", "ja", "JP");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setPreferredCulture(japaneseCulture);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        const shapes = slides.get_Item(slideIndex).getShapes();
        for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
            const shape = shapes.get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                shape.getChartData().getChartDataWorkbook().calculateFormulas();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Tercih edilen kültür, sunum yükleme yapılandırmasının bir parçasıdır; bu nedenle [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation/) örneğini oluşturmadan önce belirtilmelidir. Çalışma kitabı formüllerinin beklendiği kültürü kullanın; örneğin Japon DBCS hesaplama kurallarına uyması gereken formüller için `ja-JP` kullanın.

## **Yeniden Hesaplama ve Önbellek Değerleri**

Elektronik tablo dosyaları genellikle bir formül ve onun son hesaplanmış değerini birlikte saklar. Aspose.Slides, bir sunum yüklendiğinde ve ilgili grafik verileri değişmediğinde, [ChartDataCell.getValue](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatacell/#getValue--) üzerinden önbelleğe alınmış bir değeri okuyabilir.

Giriş hücrelerini ya da formülleri değiştirdikten sonra eski bir önbellek sonucuna güvenmeyin. Hesaplanmış değerleri okumadan ya da bu değerlere dayalı grafik verisini kaydetmeden önce [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) metodunu çağırın.

Desteklenen alt kümeye dahil olmayan formüller için Aspose.Slides formülü ayrıştıramayabilir ya da bağımlılıklarını kuramayabilir. Çalışma kitabı değiştirilmişse, önceki önbellek değeri artık güvenilir kabul edilemez. Bu durumda, desteklenmeyen veri içeren bir hücrenin değerini okumak [CellUnsupportedDataException](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/cellunsupporteddataexception/) hatasına yol açabilir.

Grafiğiniz Aspose.Slides tarafından değerlendirilmemiş Excel fonksiyonlarına dayanıyorsa, bu formülleri destekleyen bir elektronik tablo motoru ile hesaplayıp sonuç değerlerini grafik çalışma kitabına geri yazın. Desteklenmeyen formülleri tahmini değerlerle değiştirmeyin.

## **Formül Hatalarını Ele Alma**

İki farklı sorun türü vardır.

Bir formül geçerli olabilir ancak `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` ya da `#VALUE!` gibi bir elektronik tablo hata sonucunu üretebilir. Bu durumda hata token’ı bir hücre sonucu olup [ChartDataCell.getValue](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatacell/#getValue--) üzerinden döndürülebilir.

Bir formül ayrıca ayrıştırma, başvuru, bağımlılık ya da desteklenen veri seviyesinde başarısız olabilir. Aspose.Slides bu durumlar için elektronik tabloya özgü istisnalar sunar: [CellInvalidFormulaException](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/cellcircularreferenceexception/) ve [CellUnsupportedDataException](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/cellunsupporteddataexception/).

Formüller şablonlar ya da kullanıcı girişi üzerinden geliyorsa, yeniden hesaplama ve değer erişimi etrafında hataları yakalayın. Hata ayrıntıları elektronik tablo problemi hakkında bilgi verir:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 300);
    const workbook = chart.getChartData().getChartDataWorkbook();
    const cell = workbook.getCell(0, "A2");
    cell.setFormula("SUM(B2:B5)");

    try {
        workbook.calculateFormulas();
        console.log(cell.getValue());
    } catch (error) {
        console.error("Formula processing error: " + error.message);
    }
} finally {
    presentation.dispose();
}
```

## **Pratik Sınırlamalar**

Grafik çalışma sayfalarında formül desteği, tam Excel uyumluluğu değil, tanımlı bir hesaplama alt kümesi için tasarlanmıştır. Raporlama iş akışınızı tasarlarken şu kısıtlamaları göz önünde bulundurun:

- Formüllerin yeniden hesaplanmasını istiyorsanız yalnızca belgelenen sabitleri, operatörleri, referansları ve fonksiyonları kullanın.
- Formül sonuçlarının bağımlı olduğu hücreleri değiştirdikten sonra yeniden hesaplayın.
- Yüklenmiş sunumlardan gelen önbellek değerlerini bir anlık görüntü olarak değerlendirin; düzenlemelerden sonra yeniden hesaplamanın yerini almamalıdır.
- Mevcut şablonlardaki formülleri, özellikle belgelenen listede olmayan fonksiyonlar kullanıyorsa, hesaplanmış değerlerine güvenmeden önce test edin.
- Tam bir elektronik tablo hesaplama motoruna ihtiyaç duyan formüller için dışarıda hesaplayın ve ardından grafik çalışma kitabını sonuç değerleriyle güncelleyin.

## **SSS**

**[ChartDataCell.setFormula](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) ile [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) arasındaki fark nedir?**

[ChartDataCell.setFormula](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) `B2-C2` gibi bir A1‑stili ifadeyi depolar. [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) ise `RC[-2]-RC[-1]` gibi bir R1C1‑stili ifadeyi depolar. Formülleri nasıl oluşturduğunuza ya da kopyaladığınıza en uygun notasyonu kullanın.

**Hesaplamadan sonra hücreyi mi yoksa hücrenin değerini mi okumalıyım?**

[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdataworkbook/#getCell-int-java.lang.String-) bir [ChartDataCell](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatacell/) döndürür. Hesaplanmış sonucu elde etmek için, yeniden hesaplamadan sonra o hücrenin [ChartDataCell.getValue](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatacell/#getValue--) metodunu çağırın.

**[ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) ne zaman çağırmalıyım?**

Giriş değerlerini ya da formülleri değiştirdikten ve hesaplanmış sonuçlara güvenmeden önce [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) metodunu çağırın. Bu, yerleşik değerlendiricinin desteklediği formüllerin değerlerini günceller.

**Aspose.Slides her Excel fonksiyonunu destekliyor mu?**

Hayır. Yerleşik değerlendirici belgelenen bir fonksiyon alt kümesini destekler. Bu alt kümenin dışındaki fonksiyonların doğru şekilde yeniden hesaplanacağını varsaymayın. Tam Excel formül uyumluluğu gerekiyorsa, hesaplamayı uygun bir elektronik tablo motoru ile yapın ve son değerleri grafik çalışma kitabına yazın.

**Yüklenmiş bir sunum desteklenmeyen bir formül içeriyorsa ne olur?**

Grafik verileri değişmemişse, çalışma kitabı hâlâ daha önce hesaplanmış bir önbellek değerine sahip olabilir. İlgili veri değiştirildiğinde bu önbellek değeri geçerli olmayabilir. Formülü işlenemeyen bir hücreye erişmek [CellUnsupportedDataException](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/cellunsupporteddataexception/) hatasına yol açabilir.

**Formül hata değerleri istisna ile aynı şey midir?**

Hayır. `#DIV/0!` gibi bir sonuç geçerli bir hesaplamanın ürettiği bir elektronik tablo değeridir. [CellInvalidFormulaException](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/cellinvalidformulaexception/) ya da [CellCircularReferenceException](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/cellcircularreferenceexception/) gibi istisnalar, formülün normal şekilde işlenemediğini gösterir.

**Bir formül hücresi değiştiğinde grafik otomatik olarak güncellenir mi?**

Bir grafik serisi çalışma kitabı hücrelerini referans alabilir. Önce çalışma kitabını yeniden hesaplayın, ardından sunumu kaydedin ya da oluşturun. Grafik veri noktaları hesaplanan hücreleri referans alıyorsa, grafik bu güncellenmiş hücre değerlerini kullanır; bu iş akışı için ayrı bir grafik‑yenileme metodu gerekmez.

**Grafikler harici bir Excel çalışma kitabı kullanabilir mi?**

Evet, grafik verileri harici bir çalışma kitabına bağlanacak şekilde yapılandırılabilir. Ancak bu makalede anlatılan formül hesaplama iş akışı, grafik veri çalışma kitabı ve Aspose.Slides tarafından değerlendirilen formül alt kümesi ile sınırlıdır. [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) metodunun harici bir XLSX dosyasındaki rastgele formüllerin tam yeniden hesaplamasını sağladığını varsaymayın.

**Başka bir çalışma sayfasına ya da çalışma kitabına referans veren formüller kullanabilir miyim?**

Excel‑stili başvurular grafik çalışma kitaplarında bulunabilir, ancak formül değerlendirme, desteklenen ayrıştırıcı ve fonksiyon setiyle sınırlıdır. Çapraz‑sayfa ya da harici bir başvuru kritikse, hedef Aspose.Slides sürümünüzde bu formülü doğrulayın. Geniş Excel referans uyumluluğu gerektiren iş akışları için çalışma kitabını dışarıda hesaplayıp sonuçları grafik verisine geri yazın.

**Formül dizeleri `=` ile başlamalı mı?**

Aspose.Slides API örnekleri `B2-C2` ya da `SUM(B2:B5)` gibi başında `=` olmadan ifadeler atar. Bu biçimi kullanmak, oluşturulan formüllerin belgelenen API örnekleriyle tutarlı olmasını sağlar.