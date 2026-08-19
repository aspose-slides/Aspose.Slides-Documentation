---
title: JavaScript Kullanarak Sunumlarda Grafik Çalışma Sayfası Formüllerini Uygulama
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js için Java grafik çalışma sayfalarında Excel‑stilinde formüller uygulayın, değerleri yeniden hesaplayın ve sonuçları PowerPoint grafiklerinde kullanın."
---
## **Genel Bakış**

PowerPoint grafikler genellikle kaynak verilerini gömülü bir çalışma sayfasında depolar. Aspose.Slides for Node.js via Java’da bu çalışma sayfasına grafik veri çalışma kitabı aracılığıyla erişebilir, girdi değerleri yazabilir, hücrelere formül atayabilir, desteklenen formülleri hesaplayabilir ve hesaplanan hücreleri grafik verisi olarak kullanabilirsiniz.

Bu makale, tam formül iş akışını açıklamaktadır: bir grafik oluşturma, çalışma sayfasını doldurma, A1 tarzı veya R1C1 tarzı formüller atama, yeniden hesaplama, hesaplanan değerleri okuma, bu hücreleri bir grafik serisine bağlama ve sunumu kaydetme. Ayrıca desteklenen formül sözdizimini, yerleşik işlev alt kümesini, önbelleğe alınmış değerleri, desteklenmeyen formülleri ve elektronik tabloya özgü hataları da tanımlar.

## **Grafik Çalışma Sayfaları ve Formüller**

Bir grafik çalışma sayfası, bir grafik tarafından kullanılan kategorileri, seri adlarını ve değerleri içerir. PowerPoint'te, grafik veri düzenleyicisini açarak çalışma sayfasını inceleyebilirsiniz:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

Aspose.Slides'te, çalışma sayfası [ChartDataWorkbook](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdataworkbook/) sınıfı aracılığıyla sunulur. A1 tarzı formüller için [ChartDataCell.setFormula](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-)’ı ve R1C1 tarzı formüller için [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-)’ı kullanın. Girdi hücrelerini veya formülleri değiştirdikten sonra, desteklenen formülleri yeniden hesaplamak ve ilgili hücre değerlerini güncellemek için [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--)’ı çağırın.

Hesaplanmış bir hücre, sonucu hâlâ [ChartDataCell.getValue](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatacell/#getValue--) aracılığıyla sunar. Bu, kod içinde bir formül sonucunu incelemeniz veya hücreyi bir grafik veri noktası olarak kullanmanız gerektiğinde önemlidir.

## **Bir Grafik Oluşturma ve Çalışma Sayfası Formüllerini Hesaplama**

Aşağıdaki örnek uçtan uca bir iş akışını gösterir. Bir kümeleme sütun grafiği oluşturur, örnek verileri temizler, çeyrek dönem gelir ve gider değerlerini yazar, formüllerle karı hesaplar, sonuçları okur, hesaplanan hücreleri grafik değerleri olarak kullanır ve sunumu kaydeder.

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

Grafik veri noktaları `D2:D4` aralığını referans alır, bu yüzden grafik hesaplanan kar değerlerini kullanır. Bu iş akışında ayrı bir grafik yenileme çağrısı yoktur: önce çalışma kitabını yeniden hesaplayın, ardından hesaplanan hücrelere işaret eden grafik verilerini kullanın veya kaydedin.

## **A1-Stil Formüllerini Kullanma**

A1 notasyonu, sütunları harflerle ve satırları sayılarla tanımlar. A1 stil ifadelerini [ChartDataCell.setFormula](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatacell/#setFormula-java.lang.String-) aracılığıyla atayın.

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

Yaygın A1 referans biçimleri şunlardır:

| Referans | Göreceli | Mutlak | Karışık |
|---|---|---|---|
| Hücre | `A2` | `$A$2` | `A$2`, `$A2` |
| Satır | `2:2` | `$2:$2` | — |
| Sütun | `A:A` | `$A:$A` | — |
| Aralık | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Göreceli referanslar, bir formül bir elektronik tablo uygulaması tarafından taşındığında veya kopyalandığında değişebilir. Mutlak referanslar her iki koordinatı da sabit tutar, karışık referanslar ise sadece bir satırı ya da bir sütunu sabitler.

## **R1C1-Stil Formüllerini Kullanma**

R1C1 notasyonu, hem satırları hem de sütunları sayısal olarak tanımlar. Göreceli referanslar köşeli parantez içinde ofsetler kullanır. Bu sözdizimini [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatacell/#setR1C1Formula-java.lang.String-) aracılığıyla atayın.

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

Yaygın R1C1 referans biçimleri şunlardır:

| Referans | Göreceli | Mutlak | Karışık |
|---|---|---|---|
| Hücre | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Satır | `R[2]` | `R2` | — |
| Sütun | `C[3]` | `C3` | — |
| Aralık | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Örneğin, `D2` hücresinde `RC[-2]`, aynı satırda iki sütun sola (`B2`) olan hücreyi ifade eder.

## **Formül Sabitleri ve Operatörleri**

Yerleşik formül değerlendiricisi, mantıksal değerleri, sayısal sabitleri, metinleri, elektronik tablo hata değerlerini, aritmetik operatörleri ve karşılaştırma operatörlerini destekler.

### **Sabitler ve Literaller**

| Tür | Örnekler | Notlar |
|---|---|---|
| Mantıksal | `TRUE`, `FALSE` | Mantıksal ifadelerde doğrudan `A2=TRUE` gibi kullanılabilir. |
| Sayısal | `1`, `0.5`, `.3`, `1E-2` | Genel ve bilimsel gösterimler desteklenir. |
| Metin | `"abc"`, `"2/3/2020 12:00"` | Metin sabitleri formül içinde çift tırnak içinde bulunur. |
| Hata sonucu | `#DIV/0!`, `#N/A`, `#REF!` | Geçerli bir formül, normal bir sonuç yerine bir elektronik tablo hata değeri döndürebilir. |

Bu örnek çeşitli sabit türlerini kullanır:

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

    const logicalValue = workbook.getCell(0, "B2").getValue(); // yanlış
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
| `+` | Toplama veya tek artı | `2+3` |
| `-` | Çıkarma veya negatif | `2-3`, `-3` |
| `*` | Çarpma | `2*3` |
| `/` | Bölme | `2/3` |
| `%` | Yüzde | `30%` |
| `^` | Üs alma | `2^3` |

Değerlendirme sırasını açıkça belirtmek için parantez kullanın, örneğin `(A2+B2)*C2`.

### **Karşılaştırma Operatörleri**

Karşılaştırma ifadeleri mantıksal değerler döndürür.

| Operatör | Anlam | Örnek |
|---|---|---|
| `=` | Eşittir | `A2=3` |
| `<>` | Eşit değildir | `A2<>3` |
| `>` | Büyük | `A2>3` |
| `>=` | Büyük veya eşittir | `A2>=3` |
| `<` | Küçük | `A2<3` |
| `<=` | Küçük veya eşittir | `A2<=3` |

## **Desteklenen Önceden Tanımlı İşlevler**

Aspose.Slides, grafik çalışma sayfaları için yerleşik bir formül değerlendiricisi içerir, ancak tam bir Excel hesaplama motoru değildir. Belgelenen işlev kümesi aşağıdaki işlevlerle sınırlıdır. Rastgele bir Excel işlevinin [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--) ile yeniden hesaplanabileceğini varsımayın.

| İşlev | Amaç veya desteklenen biçim | Örnek |
|---|---|---|
| `ABS` | Mutlak değer | `ABS(A2)` |
| `AVERAGE` | Aritmetik ortalama | `AVERAGE(B2:B5)` |
| `CEILING` | Sayıyı yukarı doğru bir katına yuvarla | `CEILING(A2,5)` |
| `CHOOSE` | İndekse göre değer seç | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Metin değerlerini birleştir | `CONCAT(A2,B2)` |
| `CONCATENATE` | Metin değerlerini birleştir | `CONCATENATE(A2," ",B2)` |
| `DATE` | 1900 tarih sistemi kullanarak tarih değeri oluştur | `DATE(2026,8,19)` |
| `DAYS` | Tarihler arasındaki gün sayısını döndür | `DAYS(B2,A2)` |
| `FIND` | Bir metin içinde başka bir metin bul | `FIND("-",A2)` |
| `FINDB` | Bayt‑temelli metin arama | `FINDB("a",A2)` |
| `IF` | Koşullu sonuç | `IF(A2>0,A2,0)` |
| `INDEX` | Referans biçimi | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektör biçimi | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektör biçimi | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maksimum değer | `MAX(B2:B5)` |
| `SUM` | Değerleri toplar | `SUM(B2:B5)` |
| `VLOOKUP` | Dikey arama | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Tabloda gösterilen kısıtlamalar önemlidir: `INDEX` referans biçiminde belgelenirken, `LOOKUP` ve `MATCH` vektör biçimlerinde belgelenir. `DATE` 1900 tarih sistemini kullanır. Burada listelenmeyen özellik ve işlevler, ayrı dokümantasyon olmadıkça Aspose.Slides formül değerlendiricisi tarafından desteklenmez olarak kabul edilmelidir.

## **Yeniden Hesaplama ve Önbellekli Değerler**

Elektronik tablo dosyaları genellikle bir formül ve onun son hesaplanmış değerini birlikte saklar. Aspose.Slides, bir sunum yüklendiğinde ve ilgili grafik verileri değiştirilmediğinde [ChartDataCell.getValue](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatacell/#getValue--) üzerinden önbelleğe alınmış bir değeri okuyabilir.

Girdi hücrelerini veya formülleri değiştirdikten sonra eski bir önbellek sonucuna güvenmeyin. Hesaplanan değerleri okumadan ya da onlara bağımlı grafik verilerini kaydetmeden önce [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--)’ı çağırın.

Desteklenen alt kümenin dışındaki formüller için Aspose.Slides formülü ayrıştırmakta ya da bağımlılıklarını belirlemekte başarısız olabilir. Çalışma kitabı değiştirilmişse, önceki önbellek değeri artık güvenilir kabul edilemez. Bu durumda, desteklenmeyen veri içeren bir hücrenin değerini okumak [CellUnsupportedDataException](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/cellunsupporteddataexception/) yükseltebilir.

Grafiğiniz Aspose.Slides’in işlemeyeceği Excel işlevlerine dayanıyorsa, bu formülleri destekleyen bir elektronik tablo motoru ile hesaplayın ve ortaya çıkan değerleri grafik çalışma kitabına geri yazın. Desteklenmeyen formülleri tahmini değerlerle değiştirmeyin.

## **Formül Hatalarını Ele Alma**

İki farklı sorun türü vardır.

Bir formül geçerli olabilir ancak `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` veya `#VALUE!` gibi bir elektronik tablo hata sonucu üretebilir. Bu durumda hata belirteci bir hücre sonucudur ve [ChartDataCell.getValue](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatacell/#getValue--) üzerinden döndürülebilir.

Bir formül ayrıca ayrıştırma, referans, bağımlılık veya desteklenen veri düzeyinde başarısız olabilir. Aspose.Slides bu durumlar için [CellInvalidFormulaException](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/cellcircularreferenceexception/) ve [CellUnsupportedDataException](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/cellunsupporteddataexception/) gibi elektronik tabloya özgü istisnalar sağlar.

Şablonlardan veya kullanıcı girişinden gelen formüllerle çalışırken, yeniden hesaplama ve değer erişimi etrafında hataları yakalayın. Hata detayları, temel elektronik tablo sorununu belirtir:

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

Grafik çalışma sayfalarındaki formül desteği, tam bir Excel uyumluluğu değil, tanımlı bir alt küme elektronik tablo hesaplamaları için tasarlanmıştır. Raporlama iş akışı tasarlarken bu kısıtlamaları akılda tutun:

- Aspose.Slides'in formülleri yeniden hesaplaması gerektiğinde yalnızca belgelenmiş sabitleri, operatörleri, referansları ve işlevleri kullanın.
- Formül sonuçlarının bağımlı olduğu hücreleri değiştirdikten sonra yeniden hesaplayın.
- Yüklenmiş sunumlardan alınan önbelleğe alınmış değerleri anlık görüntüler olarak değerlendirin, düzenlemeler sonrası yeniden hesaplamanın yerine geçmeyecek şekilde.
- Mevcut şablonlardan gelen formülleri, özellikle belgelenmiş liste dışı işlevler kullandıklarında, hesaplanan değerlerine güvenmeden önce test edin.
- Tam bir elektronik tablo hesaplama motoru gerektiren formüller için, bunları dışarıda hesaplayın ve ardından çıkan değerlerle grafik çalışma kitabını güncelleyin.

## **SSS**

**[ChartDataCell.setFormula] ile [ChartDataCell.setR1C1Formula] arasındaki fark nedir?**

[ChartDataCell.setFormula] `B2-C2` gibi bir A1‑stil ifadesi saklar. [ChartDataCell.setR1C1Formula] `RC[-2]-RC[-1]` gibi bir R1C1‑stil ifadesi saklar. Formülleri nasıl ürettiğinize veya kopyaladığınıza en uygun notasyonu kullanın.

**Hesaplamadan sonra hücreyi mi yoksa değerini mi okumam gerekir?**

[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdataworkbook/#getCell-int-java.lang.String-) bir [ChartDataCell](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatacell/) döndürür. Hesaplanmış sonucu elde etmek için yeniden hesaplamadan sonra o hücrenin [ChartDataCell.getValue](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdatacell/#getValue--) yöntemini çağırın.

**[ChartDataWorkbook.calculateFormulas] ne zaman çağrılmalıdır?**

Girdi değerlerini veya formülleri değiştirdikten ve hesaplanmış sonuçlara bağımlı olmadan önce [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--)’ı çağırın. Bu, yerleşik değerlendiricinin desteklediği formüllerin değerlerini günceller.

**Aspose.Slides tüm Excel işlevlerini destekliyor mu?**

Hayır. Yerleşik değerlendirici belgelenmiş bir işlev alt kümesini destekler. Bu alt kümenin dışındaki işlevlerin doğru şekilde yeniden hesaplanacağı varsayılmamalıdır. Tam Excel formül uyumluluğu gerekiyorsa, hesabı uygun bir elektronik tablo motoruyla yapın ve son değerleri grafik çalışma kitabına yazın.

**Yüklenmiş bir sunumda desteklenmeyen bir formül bulunursa ne olur?**

Grafik verileri değiştirilmemişse, çalışma kitabı hâlâ daha önce hesaplanmış bir önbellek değerine sahip olabilir. İlgili veriler değiştirildikten sonra bu önbellek değeri artık geçerli olmayabilir. Formülü işlenemeyen bir hücreye erişmek [CellUnsupportedDataException](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/cellunsupporteddataexception/) oluşturabilir.

**Formül hata değerleri istisnalarla aynı mı?**

Hayır. `#DIV/0!` gibi bir sonuç, geçerli bir hesaplamanın ürettiği bir elektronik tablo değeridir. [CellInvalidFormulaException](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/cellinvalidformulaexception/) veya [CellCircularReferenceException](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/cellcircularreferenceexception/) gibi istisnalar, formülün normal şekilde işlenemediğini gösterir.

**Bir formül hücresi değiştiğinde grafik otomatik güncellenir mi?**

Grafik serileri çalışma kitabı hücrelerine referans verebilir. Önce çalışma kitabını yeniden hesaplayın, ardından sunumu kaydedin veya oluşturun. Veri noktaları hesaplanan hücreleri referans alıyorsa, grafik bu güncellenmiş hücre değerlerini kullanır; bu iş akışı için ayrı bir grafik‑yenileme yöntemi gerekmez.

**Grafikler harici bir Excel çalışma kitabı kullanabilir mi?**

Evet, grafik verileri API aracılığıyla harici bir çalışma kitabına bağlanacak şekilde yapılandırılabilir. Ancak bu makalede açıklanan formül hesaplama iş akışı, grafik veri çalışma kitabı ve Aspose.Slides tarafından değerlendiren formül alt kümesiyle sınırlıdır. [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chartdataworkbook/#calculateFormulas--)’ın harici bir XLSX dosyasındaki rastgele formülleri tam olarak yeniden hesaplayacağını varsımayın.

**Başka bir çalışma sayfasına veya çalışma kitabına referans veren formüller kullanabilir miyim?**

Grafik çalışma kitaplarında Excel‑stil referanslar bulunabilir, ancak formül değerlendirmesi desteklenen ayrıştırıcı ve işlev kümesiyle sınırlıdır. Çapraz‑sayfa veya harici bir referans kritikse, tam hedef Aspose.Slides sürümünüzde formülü doğrulayın. Geniş Excel referans uyumluluğu gerektiren iş akışları için, çalışma kitabını dışarıda hesaplayın ve çözülen değerleri grafik verisine geri yazın.

**Formül dizgileri `=` ile başlamalı mı?**

Aspose.Slides API örnekleri `B2-C2` veya `SUM(B2:B5)` gibi başında `=` olmayan ifadeler atar. Bu biçimi kullanmak, oluşturulan formüllerin belgelenmiş API örnekleriyle tutarlı olmasını sağlar.