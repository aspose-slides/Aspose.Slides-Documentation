---
title: Java'da Sunumlarda Grafik Çalışma Sayfası Formüllerini Uygulama
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
- grafik veri çalışma kitabı
- formül hesaplaması
- tercih edilen kültür
- kültüre özgü formül
- çift baytlı karakter seti
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java grafik çalışma sayfalarında Excel‑stili formülleri uygulayın, değerleri yeniden hesaplayın ve sonuçları PowerPoint grafiklerinde kullanın."
---
## **Genel Bakış**

PowerPoint grafiklerinin veri kaynağı genellikle gömülü bir çalışma sayfasında saklanır. Aspose.Slides for Java'da bu çalışma sayfasına grafik veri çalışma kitabı aracılığıyla erişebilir, giriş değerlerini yazabilir, hücrelere formül atayabilir, desteklenen formülleri hesaplayabilir ve hesaplanan hücreleri grafik verisi olarak kullanabilirsiniz.

Bu makale tam formül iş akışını açıklar: bir grafik oluşturma, çalışma sayfasını doldurma, A1‑stili veya R1C1‑stili formüller atama, yeniden hesaplatma, hesaplanan değerleri okuma, bu hücreleri bir grafik serisine bağlama ve sunumu kaydetme. Ayrıca desteklenen formül sözdizimi, yerleşik işlev alt kümesi, önbelleğe alınmış değerler, desteklenmeyen formüller ve elektronik tabloya özgü hatalar da açıklanır.

## **Grafik Çalışma Sayfaları ve Formüller**

Bir grafik çalışma sayfası, bir grafik tarafından kullanılan kategorileri, seri adlarını ve değerleri içerir. PowerPoint'te grafik veri düzenleyicisini açarak çalışma sayfasını inceleyebilirsiniz:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

Aspose.Slides'de çalışma sayfası [IChartDataWorkbook](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdataworkbook/) arayüzü aracılığıyla sunulur. A1‑stili formüller için [IChartDataCell.setFormula](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) ve R1C1‑stili formüller için [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) kullanın. Giriş hücreleri veya formüller değiştirildikten sonra, desteklenen formülleri yeniden hesaplamak ve ilgili hücre değerlerini güncellemek için [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) çağırın.

Hesaplanmış bir hücre yine sonucunu [IChartDataCell.getValue](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatacell/#getValue--) ile sunar. Bu, kod içinde bir formül sonucunu incelemeniz veya hücreyi bir grafik veri noktasına kullanmanız gerektiğinde önemlidir.

## **Bir Grafik Oluşturma ve Çalışma Sayfası Formüllerini Hesaplama**

Aşağıdaki örnek uçtan uca bir iş akışını gösterir. Küme sütun grafiği oluşturur, örnek verileri temizler, çeyrek gelir ve gider değerlerini yazar, formüllerle karı hesaplar, sonuçları okur, hesaplanan hücreleri grafik değerleri olarak kullanır ve sunumu kaydeder.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    workbook.clear(worksheetIndex);

    IChartDataCell category1 = workbook.getCell(worksheetIndex, "A2", "Q1");
    IChartDataCell category2 = workbook.getCell(worksheetIndex, "A3", "Q2");
    IChartDataCell category3 = workbook.getCell(worksheetIndex, "A4", "Q3");

    workbook.getCell(worksheetIndex, "B1", "Revenue");
    workbook.getCell(worksheetIndex, "C1", "Expenses");
    workbook.getCell(worksheetIndex, "D1", "Profit");

    workbook.getCell(worksheetIndex, "B2").setValue(120.0);
    workbook.getCell(worksheetIndex, "C2").setValue(80.0);
    workbook.getCell(worksheetIndex, "B3").setValue(150.0);
    workbook.getCell(worksheetIndex, "C3").setValue(95.0);
    workbook.getCell(worksheetIndex, "B4").setValue(135.0);
    workbook.getCell(worksheetIndex, "C4").setValue(110.0);

    IChartDataCell profit1 = workbook.getCell(worksheetIndex, "D2");
    IChartDataCell profit2 = workbook.getCell(worksheetIndex, "D3");
    IChartDataCell profit3 = workbook.getCell(worksheetIndex, "D4");

    profit1.setFormula("B2-C2");
    profit2.setFormula("B3-C3");
    profit3.setFormula("B4-C4");

    workbook.calculateFormulas();

    double q1Profit = ((Number) profit1.getValue()).doubleValue(); // 40
    double q2Profit = ((Number) profit2.getValue()).doubleValue(); // 55
    double q3Profit = ((Number) profit3.getValue()).doubleValue(); // 25

    System.out.println("Q1 profit: " + q1Profit);
    System.out.println("Q2 profit: " + q2Profit);
    System.out.println("Q3 profit: " + q3Profit);

    chart.getChartData().getCategories().add(category1);
    chart.getChartData().getCategories().add(category2);
    chart.getChartData().getCategories().add(category3);

    IChartSeries profitSeries = chart.getChartData().getSeries().add(workbook.getCell(worksheetIndex, "D1"), chart.getType());
    profitSeries.getDataPoints().addDataPointForBarSeries(profit1);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit2);
    profitSeries.getDataPoints().addDataPointForBarSeries(profit3);
    profitSeries.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("chart-formulas.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Grafik veri noktaları `D2:D4` aralığını referans alır, bu yüzden grafik hesaplanan kar değerlerini kullanır. Bu iş akışında ayrı bir grafik‑yenileme çağrısı yoktur: önce çalışma kitabını yeniden hesaplatın, ardından hesaplanan hücrelere işaret eden grafik verisini kullanın veya kaydedin.

## **A1‑Stili Formüller Kullanma**

A1 notasyonu sütunları harflerle, satırları sayılarla tanımlar. A1‑stili ifadeleri [IChartDataCell.setFormula](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) aracılığıyla atayın.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "C3").setValue(10);
    workbook.getCell(0, "F2").setValue(2);
    workbook.getCell(0, "G2").setValue(3);
    workbook.getCell(0, "H2").setValue(4);

    IChartDataCell cell = workbook.getCell(0, "A2");
    cell.setFormula("C3+SUM(F2:H2)");

    workbook.calculateFormulas();

    Object value = cell.getValue(); // 19
} finally {
    presentation.dispose();
}
```

Yaygın A1 referans biçimleri şunlardır:

| Referans | Göreli | Mutlak | Karışık |
|---|---|---|---|
| Hücre | `A2` | `$A$2` | `A$2`, `$A2` |
| Satır | `2:2` | `$2:$2` | — |
| Sütun | `A:A` | `$A:$A` | — |
| Aralık | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Göreli referanslar bir formül bir elektronik tablo uygulaması ile taşındığında veya kopyalandığında değişebilir. Mutlak referanslar her iki koordinatı da sabit tutar, karışık referanslar ise yalnızca bir satır ya da bir sütunu sabitler.

## **R1C1‑Stili Formüller Kullanma**

R1C1 notasyonu hem satırları hem de sütunları sayısal olarak tanımlar. Göreli referanslar köşeli parantez içinde ofsetler kullanır. Bu sözdizimini [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) ile atayın.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "B2").setValue(12);
    workbook.getCell(0, "C2").setValue(5);

    IChartDataCell cell = workbook.getCell(0, "D2");
    cell.setR1C1Formula("RC[-2]-RC[-1]");

    workbook.calculateFormulas();

    Object value = cell.getValue(); // 7
} finally {
    presentation.dispose();
}
```

Yaygın R1C1 referans biçimleri şunlardır:

| Referans | Göreli | Mutlak | Karışık |
|---|---|---|---|
| Hücre | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Satır | `R[2]` | `R2` | — |
| Sütun | `C[3]` | `C3` | — |
| Aralık | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Örneğin, `D2` hücresinde `RC[-2]` aynı satırda iki sütun sola olan hücreyi (`B2`) ifade eder.

## **Formül Sabitleri ve Operatörler**

Yerleşik formül çözücüsü mantıksal değerler, sayısal sabitler, dizeler, elektronik tablo hata değerleri, aritmetik operatörler ve karşılaştırma operatörlerini destekler.

### **Sabitler ve Literaller**

| Tür | Örnekler | Notlar |
|---|---|---|
| Mantıksal | `TRUE`, `FALSE` | `A2=TRUE` gibi mantıksal ifadelerde doğrudan kullanılabilir. |
| Sayısal | `1`, `0.5`, `.3`, `1E-2` | Ondalık ve bilimsel gösterimler desteklenir. |
| Dize | `"abc"`, `"2/3/2020 12:00"` | Formül içinde çift tırnak içinde yer alır. |
| Hata sonucu | `#DIV/0!`, `#N/A`, `#REF!` | Geçerli bir formül normal bir sonuç yerine bir elektronik tablo hata değeri üretebilir. |

Bu örnek birkaç sabit türünü kullanır:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    workbook.getCell(0, "A2").setValue(false);
    workbook.getCell(0, "B2").setFormula("A2=TRUE");
    workbook.getCell(0, "C2").setFormula("1+0.5");
    workbook.getCell(0, "D2").setFormula(".3*1E-2");
    workbook.getCell(0, "E2").setFormula("\"abc\"");
    workbook.getCell(0, "F2").setFormula("2/0");

    workbook.calculateFormulas();

    Object logicalValue = workbook.getCell(0, "B2").getValue(); // yanlış
    Object numericValue = workbook.getCell(0, "C2").getValue(); // 1.5
    Object scientificValue = workbook.getCell(0, "D2").getValue(); // 0.003
    Object stringValue = workbook.getCell(0, "E2").getValue(); // abc
    Object errorValue = workbook.getCell(0, "F2").getValue(); // #DIV/0!
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

Karşılaştırma ifadeleri mantıksal değer döndürür.

| Operatör | Anlam | Örnek |
|---|---|---|
| `=` | Eşittir | `A2=3` |
| `<>` | Eşit değildir | `A2<>3` |
| `>` | Büyüktür | `A2>3` |
| `>=` | Büyük veya eşittir | `A2>=3` |
| `<` | Küçüktür | `A2<3` |
| `<=` | Küçük veya eşittir | `A2<=3` |

## **Desteklenen Önceden Tanımlı İşlevler**

Aspose.Slides grafik çalışma sayfaları için yerleşik bir formül çözücüsü içerir, ancak bu tam bir Excel hesaplama motoru değildir. Belgelendirilmiş işlev seti aşağıdaki ile sınırlıdır. [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) aracılığıyla rastgele bir Excel işlevinin yeniden hesaplanabileceğini varsaymayın.

| İşlev | Amaç ya da desteklenen biçim | Örnek |
|---|---|---|
| `ABS` | Mutlak değer | `ABS(A2)` |
| `AVERAGE` | Aritmetik ortalama | `AVERAGE(B2:B5)` |
| `CEILING` | Sayıyı yukarı doğru bir katına yuvarla | `CEILING(A2,5)` |
| `CHOOSE` | İndexe göre değer seç | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Metin değerlerini birleştir | `CONCAT(A2,B2)` |
| `CONCATENATE` | Metin değerlerini birleştir | `CONCATENATE(A2," ",B2)` |
| `DATE` | 1900 tarih sistemiyle bir tarih değeri oluştur | `DATE(2026,8,19)` |
| `DAYS` | Tarihler arasındaki gün sayısını döndür | `DAYS(B2,A2)` |
| `FIND` | Bir metin değerini başka birinin içinde bul | `FIND("-",A2)` |
| `FINDB` | Bayt‑odaklı metin arama | `FINDB("a",A2)` |
| `IF` | Koşullu sonuç | `IF(A2>0,A2,0)` |
| `INDEX` | Referans biçimi | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektör biçimi | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektör biçimi | `MATCH(A2,B2:B5,0)` |
| `MAX` | En büyük değer | `MAX(B2:B5)` |
| `SUM` | Değerleri toplar | `SUM(B2:B5)` |
| `VLOOKUP` | Dikey arama | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Tablodaki kısıtlamalar önemlidir: `INDEX` referans biçiminde belgelenmiştir, `LOOKUP` ve `MATCH` ise vektör biçiminde belgelenir. `DATE` 1900 tarih sistemini kullanır. Burada listelenmeyen özellik ve işlevler, Aspose.Slides formül çözücüsü tarafından desteklenmiyor olarak kabul edilmelidir.

## **Tercih Edilen Kültürle Formülleri Hesaplama**

Bazı grafik çalışma kitabı işlevleri metni kültüre özgü kurallara göre yorumlar. Bu, çift baytlı karakter setleri (DBCS) kullanan diller için özellikle önemlidir. Bu tür formülleri doğru hesaplamak için [LoadOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/) oluşturun, [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/tr/java/com.aspose.slides/spreadsheetoptions/#setPreferredCulture-java.util.Locale-) ile tercih edilen kültürü ayarlayın, [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/tr/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) ile elektronik tablo seçeneklerini atayın ve ardından sunumu yükleyin.

Aşağıdaki örnek Japon kültürünü seçer, yapılandırılmış yükleme seçenekleriyle bir sunumu açar ve her grafik çalışma kitabı için [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) çağırır:

```java
import com.aspose.slides.*;
import java.util.Locale;

Locale japaneseCulture = Locale.forLanguageTag("ja-JP");

ISpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setPreferredCulture(japaneseCulture);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                IChart chart = (IChart) shape;
                chart.getChartData().getChartDataWorkbook().calculateFormulas();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Tercih edilen kültür, sunum yükleme yapılandırmasının bir parçasıdır; bu yüzden [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) örneği oluşturulmadan önce belirtilmelidir. Çalışma kitabı formüllerinin beklediği kültürü kullanın; örneğin Japon DBCS hesaplama kurallarını takip etmesi gereken formüller için `ja-JP` kullanın.

## **Yeniden Hesaplama ve Önbelleğe Alınmış Değerler**

Elektronik tablo dosyaları genellikle bir formül ve son hesaplanmış değerini birlikte saklar. Aspose.Slides, bir sunum yüklendiğinde ve ilgili grafik verileri değiştirilmediğinde, [IChartDataCell.getValue](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatacell/#getValue--) üzerinden önbelleğe alınmış bir değeri okuyabilir.

Giriş hücreleri veya formüller değiştirildikten sonra eski önbellek sonucuna güvenmeyin. Hesaplanmış değerleri okumadan veya onlara dayalı grafik verisini kaydetmeden önce [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) çağırın.

Desteklenen alt kümenin dışındaki formüller için Aspose.Slides formülü ayrıştıramayabilir veya bağımlılıklarını belirleyemeyebilir. Çalışma kitabı değiştirilmişse, önceki önbellek değeri artık güvenilir kabul edilemez. Bu durumda, desteklenmeyen veri içeren bir hücrenin değeri okunurken [CellUnsupportedDataException](https://reference.aspose.com/slides/tr/java/com.aspose.slides/cellunsupporteddataexception/) tetiklenebilir.

Grafiğiniz Aspose.Slides tarafından değerlendirilmeyen Excel işlevlerine bağımlıysa, bu formülleri destekleyen bir elektronik tablo motoru ile hesaplayıp elde edilen değerleri grafik çalışma kitabına yazın. Desteklenmeyen formülleri tahmini değerlerle değiştirmeyin.

## **Formül Hatalarını Ele Alma**

İki farklı problem türü vardır.

Bir formül geçerli olabilir ancak `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` veya `#VALUE!` gibi bir elektronik tablo hata sonucu üretebilir. Bu durumda hata belirteci bir hücre sonucu olup [IChartDataCell.getValue](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatacell/#getValue--) üzerinden döndürülebilir.

Bir formül ayrıca ayrıştırma, referans, bağımlılık veya desteklenen veri seviyesinde başarısız olabilir. Aspose.Slides bu durumlar için elektronik tabloya özgü istisnalar sağlar: [CellInvalidFormulaException](https://reference.aspose.com/slides/tr/java/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/tr/java/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/tr/java/com.aspose.slides/cellcircularreferenceexception/) ve [CellUnsupportedDataException](https://reference.aspose.com/slides/tr/java/com.aspose.slides/cellunsupporteddataexception/).

Formüller şablonlardan veya kullanıcı girdisinden geliyorsa, bu istisnaları yeniden hesaplama ve değer erişimi etrafında yakalayın:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell cell = workbook.getCell(0, "A2");
    cell.setFormula("SUM(B2:B5)");

    try {
        workbook.calculateFormulas();
        System.out.println(cell.getValue());
    } catch (CellInvalidFormulaException ex) {
        System.err.println("Invalid formula: " + ex.getMessage());
    } catch (CellInvalidReferenceException ex) {
        System.err.println("Invalid cell reference: " + ex.getMessage());
    } catch (CellCircularReferenceException ex) {
        System.err.println("Circular reference: " + ex.getMessage());
    } catch (CellUnsupportedDataException ex) {
        System.err.println("Unsupported spreadsheet data: " + ex.getMessage());
    }
} finally {
    presentation.dispose();
}
```

## **Pratik Sınırlamalar**

Grafik çalışma sayfalarındaki formül desteği, tam Excel uyumluluğu yerine tanımlı bir elektronik tablo hesaplama alt kümesi için tasarlanmıştır. Raporlama iş akışınızı tasarlarken bu kısıtlamaları aklınızda bulundurun:

- Aspose.Slides'ın formülleri yeniden hesaplamasını istediğinizde yalnızca belgelenen sabitleri, operatörleri, referansları ve işlevleri kullanın.
- Formül sonuçlarının bağımlı olduğu hücreler değiştirildikten sonra yeniden hesaplayın.
- Yüklenen sunumlardan gelen önbelleğe alınmış değerleri anlık bir kesit olarak değerlendirin; düzenlemeler sonrası yeniden hesaplamanın yerini tutmaz.
- Mevcut şablonlardaki formülleri, özellikle belgelenen listesinin dışındaki işlevler kullanıyorsa, hesaplanan değerlerine güvenmeden önce test edin.
- Tam bir elektronik tablo hesaplama motoru gerektiren formüller için bunları dışarıda hesaplayın ve ardından grafik çalışma kitabını elde edilen değerlerle güncelleyin.

## **SSS**

**[IChartDataCell.setFormula](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) ve [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) arasındaki fark nedir?**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) `B2-C2` gibi bir A1‑stili ifadeyi depolar. [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) `RC[-2]-RC[-1]` gibi bir R1C1‑stili ifadeyi depolar. Formülleri oluşturma veya kopyalama şeklinize en uygun notasyonu kullanın.

**Hesaplamadan sonra hücreyi mi yoksa değerini mi okumam gerekir?**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) bir [IChartDataCell](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatacell/) döndürür. Hesaplanmış sonucu elde etmek için yeniden hesaplamadan sonra o hücrenin [IChartDataCell.getValue](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatacell/#getValue--) yöntemini çağırın.

**[IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) ne zaman çağırmalıyım?**

Giriş değerleri veya formüller değiştirildikten sonra ve hesaplanmış sonuçlara ihtiyaç duymadan önce [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) çağırın. Bu, yerleşik çözücünün desteklediği formüllerin değerlerini günceller.

**Aspose.Slides her Excel işlevini destekliyor mu?**

Hayır. Yerleşik çözücü belgelenen bir işlev alt kümesini destekler. Bu alt kümenin dışındaki işlevlerin doğru şekilde yeniden hesaplanacağını varsaymayın. Tam Excel formül uyumluluğu gerekiyorsa, uygun bir elektronik tablo motoru ile hesaplayıp sonuçları grafik çalışma kitabına yazın.

**Yüklenmiş bir sunum desteklenmeyen bir formül içeriyorsa ne olur?**

Grafik verileri değiştirilmemişse, çalışma kitabı hâlâ önceden hesaplanmış bir önbellek değerine sahip olabilir. İlgili veri değiştirildikten sonra bu önbellek değeri geçersiz olabilir. Formülü işlenemeyen bir hücreye erişmek [CellUnsupportedDataException](https://reference.aspose.com/slides/tr/java/com.aspose.slides/cellunsupporteddataexception/) hatasına yol açabilir.

**Formül hata değerleri Java istisnalarıyla aynı mı?**

Hayır. `#DIV/0!` gibi bir sonuç, geçerli bir hesaplamanın ürettiği bir elektronik tablo değeridir. [CellInvalidFormulaException](https://reference.aspose.com/slides/tr/java/com.aspose.slides/cellinvalidformulaexception/) veya [CellCircularReferenceException](https://reference.aspose.com/slides/tr/java/com.aspose.slides/cellcircularreferenceexception/) gibi istisnalar, formülün normal şekilde işlenemediğini gösterir.

**Bir formül hücresi değiştiğinde grafik otomatik olarak güncellenir mi?**

Bir grafik serisi çalışma kitabı hücrelerine referans verebilir. Önce çalışma kitabını yeniden hesaplatın, ardından sunumu kaydedin veya render edin. Grafik veri noktaları hesaplanan hücrelere işaret ediyorsa, grafik bu güncel hücre değerlerini kullanır; bu iş akışı için ayrı bir grafik‑yenileme yöntemi gerekmez.

**Grafikler harici bir Excel çalışma kitabı kullanabilir mi?**

Evet, grafik verileri API aracılığıyla harici bir çalışma kitabı kullanacak şekilde yapılandırılabilir. Ancak bu makalede anlatılan formül hesaplama iş akışı, grafik veri çalışma kitabı ve Aspose.Slides tarafından değerlendirilen formül alt kümesiyle ilgilidir. [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) metodunun harici bir XLSX dosyasındaki rastgele formüllerin tam yeniden hesaplamasını sağladığını varsaymayın.

**Başka bir çalışma sayfasına veya çalışma kitabına referans veren formüller kullanabilir miyim?**

Excel‑stili referanslar grafik çalışma kitaplarında bulunabilir, ancak formül değerlendirme desteklenen ayrıştırıcı ve işlev setiyle sınırlıdır. Çapraz‑sayfa veya harici bir referans kritik ise, tam formülünüzü hedef Aspose.Slides sürümünüzde doğrulayın. Geniş Excel referans uyumluluğu gerektiren iş akışları için çalışma kitabını dışarıda hesaplayıp elde edilen değerleri grafik verisine geri yazın.

**Formül dizeleri `=` ile başlamalı mı?**

Aspose.Slides API örnekleri `B2-C2` veya `SUM(B2:B5)` gibi bir baştaki `=` olmadan ifadeler atar. Bu biçim, belgelenen API örnekleriyle tutarlılığı korur.