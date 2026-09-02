---
title: Android'de Sunumlarda Grafik Çalışma Sayfası Formüllerini Uygulama
linktitle: Çalışma Sayfası Formülleri
type: docs
weight: 70
url: /tr/androidjava/chart-worksheet-formulas/
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
- Android
- Java
- Aspose.Slides
description: "Android için Aspose.Slides'te Java grafik çalışma sayfaları aracılığıyla Excel tarzı formülleri uygulayın, değerleri yeniden hesaplayın ve sonuçları PowerPoint grafiklerinde kullanın."
---
## **Genel Bakış**

PowerPoint grafiklerinin kaynak verileri genellikle gömülü bir çalışma sayfasında depolanır. Aspose.Slides for Android via Java'da, bu çalışma sayfasına grafik veri çalışma kitabı aracılığıyla erişebilir, giriş değerlerini yazabilir, hücrelere formüller atayabilir, desteklenen formülleri hesaplayabilir ve hesaplanan hücreleri grafik verisi olarak kullanabilirsiniz.

Bu makale tam formül iş akışını açıklar: bir grafik oluşturma, çalışma sayfasını doldurma, A1 biçimli veya R1C1 biçimli formüller atama, bunları yeniden hesaplama, hesaplanan değerleri okuma, bu hücreleri bir grafik serisine bağlama ve sunumu kaydetme. Ayrıca desteklenen formül sözdizimini, yerleşik fonksiyon alt kümesini, önbelleğe alınmış değerleri, desteklenmeyen formülleri ve elektronik tabloya özgü hataları açıklar.

## **Grafik Çalışma Sayfaları ve Formüller**

Bir grafik çalışma sayfası, bir grafik tarafından kullanılan kategorileri, seri adlarını ve değerleri içerir. PowerPoint'te, grafik veri düzenleyicisini açarak çalışma sayfasını inceleyebilirsiniz:

![Açık gömülü çalışma sayfasına sahip PowerPoint grafiği, kategori ve seri verilerini gösteriyor](chart-worksheet-formulas_1.png)

Aspose.Slides'de, çalışma sayfası [IChartDataWorkbook](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdataworkbook/) arabirimi aracılığıyla sunulur. A1 biçimli formüller için [IChartDataCell.setFormula](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) , R1C1 biçimli formüller için [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) kullanın. Girdi hücrelerini veya formülleri değiştirdikten sonra, desteklenen formülleri yeniden hesaplamak ve ilgili hücre değerlerini güncellemek için [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) çağırın.

Hesaplanmış bir hücre hâlâ sonucunu [IChartDataCell.getValue](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatacell/#getValue--) aracılığıyla sunar. Bu, kod içinde bir formül sonucunu incelemeniz veya hücreyi bir grafik veri noktası olarak kullanmanız gerektiğinde önemlidir.

## **Bir Grafik Oluşturma ve Çalışma Sayfası Formüllerini Hesaplama**

Aşağıdaki örnek uçtan uca bir iş akışını gösterir. Bir kümelenmiş sütun grafiği oluşturur, örnek verileri temizler, çeyrek bazında gelir ve gider değerlerini yazar, formüllerle karı hesaplar, sonuçları okur, hesaplanan hücreleri grafik değerleri olarak kullanır ve sunumu kaydeder.

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

Grafik veri noktaları `D2:D4` aralığını referans alır, bu yüzden grafik hesaplanan kar değerlerini kullanır. Bu iş akışında ayrı bir grafik yenileme çağrısı yoktur: önce çalışma kitabını yeniden hesaplayın, ardından hesaplanan hücrelere işaret eden grafik verilerini kullanın veya kaydedin.

## **A1 Biçimli Formüller Kullanma**

A1 gösterimi sütunları harflerle, satırları ise sayılarla tanımlar. A1 biçimli ifadeleri [IChartDataCell.setFormula](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) aracılığıyla atayın.

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

| Referans | Göreceli | Mutlak | Karma |
|---|---|---|---|
| Hücre | `A2` | `$A$2` | `A$2`, `$A2` |
| Satır | `2:2` | `$2:$2` | — |
| Sütun | `A:A` | `$A:$A` | — |
| Aralık | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Göreceli referanslar, bir formül bir elektronik tablo uygulaması tarafından taşındığında veya kopyalandığında değişebilir. Mutlak referanslar her iki koordinatı da sabit tutar, karma referanslar ise yalnızca satırı ya da sütunu sabitler.

## **R1C1 Biçimli Formüller Kullanma**

R1C1 gösterimi satırları ve sütunları sayısal olarak tanımlar. Göreceli referanslar köşeli parantez içindeki kaydırımları kullanır. Bu sözdizimini [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) aracılığıyla atayın.

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

| Referans | Göreceli | Mutlak | Karma |
|---|---|---|---|
| Hücre | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Satır | `R[2]` | `R2` | — |
| Sütun | `C[3]` | `C3` | — |
| Aralık | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Örneğin, `D2` hücresinde `RC[-2]` aynı satırda iki sütun sola olan hücreyi (`B2`) ifade eder.

## **Formül Sabitleri ve Operatörler**

Yerleşik formül değerlendirme motoru mantıksal değerleri, sayısal sabitleri, metinleri, elektronik tablo hata değerlerini, aritmetik operatörleri ve karşılaştırma operatörlerini destekler.

### **Sabitler ve Literaller**

| Tür | Örnekler | Notlar |
|---|---|---|
| Mantıksal | `TRUE`, `FALSE` | Mantıksal ifadelerde doğrudan kullanılabilir, ör. `A2=TRUE`. |
| Sayısal | `1`, `0.5`, `.3`, `1E-2` | Yaygın ve bilimsel gösterimler desteklenir. |
| Metin | `"abc"`, `"2/3/2020 12:00"` | Metin sabitleri formül içinde çift tırnak içinde yazılır. |
| Hata sonucu | `#DIV/0!`, `#N/A`, `#REF!` | Geçerli bir formül, normal bir sonuç yerine bir elektronik tablo hata değeri döndürebilir. |

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
| `+` | Toplama veya tekli artı | `2+3` |
| `-` | Çıkarma veya negatif | `2-3`, `-3` |
| `*` | Çarpma | `2*3` |
| `/` | Bölme | `2/3` |
| `%` | Yüzde | `30%` |
| `^` | Üs alma | `2^3` |

Değerlendirme sırasını açıkça belirtmek için parantez kullanın, örneğin `(A2+B2)*C2`.

### **Karşılaştırma Operatörleri**

| Operatör | Anlam | Örnek |
|---|---|---|
| `=` | Eşittir | `A2=3` |
| `<>` | Eşit değildir | `A2<>3` |
| `>` | Büyüktür | `A2>3` |
| `>=` | Büyük veya eşittir | `A2>=3` |
| `<` | Küçüktür | `A2<3` |
| `<=` | Küçük veya eşittir | `A2<=3` |

## **Desteklenen Ön Tanımlı Fonksiyonlar**

Aspose.Slides, grafik çalışma sayfaları için yerleşik bir formül değerlendirme motoru içerir, ancak bu tam bir Excel hesaplama motoru değildir. Belgelenen fonksiyon kümesi aşağıdaki fonksiyonlarla sınırlıdır. Rasgele bir Excel fonksiyonunun [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) ile yeniden hesaplanabileceğini varsaymayın.

| Fonksiyon | Amaç veya desteklenen form | Örnek |
|---|---|---|
| `ABS` | Mutlak değer | `ABS(A2)` |
| `AVERAGE` | Aritmetik ortalama | `AVERAGE(B2:B5)` |
| `CEILING` | Bir sayıyı yukarı doğru bir katına yuvarlar | `CEILING(A2,5)` |
| `CHOOSE` | İndexe göre bir değer seçer | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Metin değerlerini birleştirir | `CONCAT(A2,B2)` |
| `CONCATENATE` | Metin değerlerini birleştirir | `CONCATENATE(A2," ",B2)` |
| `DATE` | 1900 tarih sistemini kullanarak bir tarih değeri oluşturur | `DATE(2026,8,19)` |
| `DAYS` | Tarihler arasındaki gün sayısını döndürür | `DAYS(B2,A2)` |
| `FIND` | Bir metin içinde başka bir metni bulur | `FIND("-",A2)` |
| `FINDB` | Bayt yönelimli metin araması | `FINDB("a",A2)` |
| `IF` | Koşullu sonuç | `IF(A2>0,A2,0)` |
| `INDEX` | Referans biçimi | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektör biçimi | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektör biçimi | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maksimum değer | `MAX(B2:B5)` |
| `SUM` | Değerleri toplar | `SUM(B2:B5)` |
| `VLOOKUP` | Dikey arama | `VLOOKUP(A2,B2:D10,3,FALSE)` |

## **Formülleri Tercih Edilen Kültür ile Hesaplama**

Bazı grafik çalışma kitabı fonksiyonları metni kültüre özgü kurallara göre yorumlar. Bu, çift bayt karakter seti (DBCS) kullanan diller için tasarlanmış fonksiyonlar için özellikle önemlidir. Bu tür formülleri doğru şekilde hesaplamak için [LoadOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/loadoptions/) oluşturun, tercih edilen kültürü [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/spreadsheetoptions/#setPreferredCulture-java.util.Locale-) ile ayarlayın, elektronik tablo seçeneklerini [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) aracılığıyla atayın ve ardından sunumu yükleyin.

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

Tercih edilen kültür, sunum yükleme yapılandırmasının bir parçasıdır, bu yüzden [Presentation] örneğini oluşturmadan önce belirtin. Çalışma kitabı formüllerinin beklediği kültürü kullanın; örneğin, Japon DBCS hesaplama kurallarını takip etmesi gereken formüller için `ja-JP` kullanın.

## **Yeniden Hesaplama ve Önbelleğe Alınmış Değerler**

Elektronik tablo dosyaları genellikle bir formülü ve onun son hesaplanmış değerini birlikte saklar. Aspose.Slides, bir sunum yüklendiğinde ve ilgili grafik verileri değişmemişse, [IChartDataCell.getValue](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatacell/#getValue--) aracılığıyla önbelleğe alınmış bir değeri okuyabilir.

Girdi hücrelerini veya formülleri değiştirdikten sonra eski önbellek sonucuna güvenmeyin. Hesaplanmış değerleri okumadan veya onlara bağlı grafik verilerini kaydetmeden önce [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) çağırın.

Desteklenen alt kümenin dışındaki formüller için Aspose.Slides formülü ayrıştıramama veya bağımlılıklarını belirleyememe durumuyla karşılaşabilir. Çalışma kitabı değiştirildiyse, önceki önbelleğe alınmış değer artık güvenilir kabul edilemez. Bu durumda, desteklenmeyen veri içeren bir hücrenin değerini okumak [CellUnsupportedDataException](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/cellunsupporteddataexception/) hatasını tetikleyebilir.

Grafiğiniz Aspose.Slides'in değerlendirmediği Excel fonksiyonlarına bağlıysa, bu formülleri destekleyen bir elektronik tablo motoru ile hesaplayın ve elde edilen değerleri grafik çalışma kitabına geri yazın. Desteklenmeyen formülleri tahmini değerlerle değiştirmeyin.

## **Formül Hatalarını İşleme**

Ayırt edilmesi gereken iki farklı sorun türü vardır.

Bir formül geçerli olabilir ancak `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` veya `#VALUE!` gibi bir elektronik tablo hata sonucu üretebilir. Bu durumda, hata belirteci bir hücre sonucu olup [IChartDataCell.getValue](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatacell/#getValue--) aracılığıyla döndürülebilir.

Bir formül ayrıca ayrıştırma, referans, bağımlılık veya desteklenen veri seviyesinde başarısız olabilir. Aspose.Slides bu durumlar için elektronik tabloya özgü istisnalar sağlar: [CellInvalidFormulaException](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/cellcircularreferenceexception/), ve [CellUnsupportedDataException](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/cellunsupporteddataexception/).

Formüller şablonlardan veya kullanıcı girdisinden geldiğinde, yeniden hesaplama ve değer erişimi sırasında bu istisnaları ele alın:

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

Grafik çalışma sayfalarındaki formül desteği, tam Excel uyumluluğu değil, tanımlı bir elektronik tablo hesaplama alt kümesi için tasarlanmıştır. Raporlama iş akışı tasarlarken bu kısıtlamaları akılda tutun:

- Aspose.Slides'in formülleri yeniden hesaplamasını istediğinizde sadece belgelenen sabitleri, operatörleri, referansları ve fonksiyonları kullanın.
- Formül sonuçlarının bağlı olduğu hücreleri değiştirdikten sonra yeniden hesaplayın.
- Yüklenmiş sunumlardan alınan önbelleğe alınmış değerleri anlık görüntü olarak değerlendirin, düzenlemeler sonrası yeniden hesaplamanın yerini almaz.
- Mevcut şablonlardan gelen formülleri, özellikle belgelenen listenin dışındaki fonksiyonları kullandıklarında, hesaplanan değerlere güvenmeden önce test edin.
- Tam bir elektronik tablo hesaplama motoru gerektiren formüller için, dışarıda hesaplayın ve ardından ortaya çıkan değerlerle grafik çalışma kitabını güncelleyin.

## **SSS**

**Aşağıdaki iki metod arasındaki fark nedir: [IChartDataCell.setFormula](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) ve [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-)?**

[IChartDataCell.setFormula] `B2-C2` gibi bir A1 biçimli ifade depolar. [IChartDataCell.setR1C1Formula] `RC[-2]-RC[-1]` gibi bir R1C1 biçimli ifade depolar. Formülleri nasıl oluşturduğunuza veya kopyaladığınıza en uygun gösterimi kullanın.

**Hesaplamadan sonra hücreyi mi yoksa değerini mi okumam gerekir?**

[IChartDataWorkbook.getCell] bir [IChartDataCell] döndürür. Hesaplanmış sonucu elde etmek için yeniden hesaplamadan sonra o hücrenin [IChartDataCell.getValue] metodunu çağırın.

**[IChartDataWorkbook.calculateFormulas] ne zaman çağrılmalı?**

Girdi değerlerini veya formülleri değiştirdikten ve hesaplanan sonuçlara bağlı olmadan önce [IChartDataWorkbook.calculateFormulas] çağırın. Bu, yerleşik değerlendirme motorunun desteklediği formüllerin değerlerini günceller.

**Aspose.Slides her Excel fonksiyonunu destekliyor mu?**

Hayır. Yerleşik değerlendirme motoru belgelenen bir fonksiyon alt kümesini destekler. Bu alt kümenin dışındaki fonksiyonların doğru şekilde yeniden hesaplanacağını varsaymayın. Tam Excel formül uyumluluğu gerekiyorsa, uygun bir elektronik tablo motoru ile hesabı yapın ve son değerleri grafik çalışma kitabına yazın.

**Yüklenmiş bir sunum desteklenmeyen bir formül içeriyorsa ne olur?**

Grafik verileri değişmemişse, çalışma kitabı daha önce hesaplanmış bir önbellek değerini içerebilir. İlgili veri değiştirildiğinde bu önbellek değeri geçerli olmayabilir. Formülü işlenemeyen bir hücreye erişmek [CellUnsupportedDataException] hatasını tetikleyebilir.

**Formül hata değerleri Java istisnalarıyla aynı mı?**

Hayır. `#DIV/0!` gibi bir sonuç, geçerli bir hesaplamanın ürettiği bir elektronik tablo değeridir. [CellInvalidFormulaException] veya [CellCircularReferenceException] gibi istisnalar, formülün normal şekilde işlenemediğini gösterir.

**Bir formül hücresi değiştiğinde grafik otomatik olarak güncellenir mi?**

Bir grafik serisi, çalışma kitabı hücrelerine referans verebilir. Önce çalışma kitabını yeniden hesaplayın, ardından sunumu kaydedin veya işleyin. Grafik veri noktaları hesaplanan hücrelere referans veriyorsa, grafik bu güncellenmiş hücre değerlerini kullanır; bu iş akışı için ayrı bir grafik yenileme yöntemi gerekmez.

**Grafikler harici bir Excel çalışma kitabı kullanabilir mi?**

Evet, grafik verileri, grafik veri API'si aracılığıyla harici bir çalışma kitabı kullanacak şekilde yapılandırılabilir. Ancak bu makalede açıklanan formül hesaplama iş akışı, grafik veri çalışma kitabı ve Aspose.Slides tarafından değerlendirilen formül alt kümesiyle ilgilidir. [IChartDataWorkbook.calculateFormulas]'nin harici bir XLSX dosyasındaki rastgele formüllerin tam yeniden hesaplamasını sağladığını varsaymayın.

**Başka bir çalışma sayfasına veya çalışma kitabına referans veren formüller kullanabilir miyim?**

Grafik çalışma kitaplarında Excel tarzı referanslar bulunabilir, ancak formül değerlendirmesi desteklenen ayrıştırıcı ve fonksiyon kümesiyle sınırlıdır. Çapraz sayfa veya harici bir referans kritikse, tam formülü hedef Aspose.Slides sürümünüzde doğrulayın. Geniş Excel referans uyumluluğu gerektiren iş akışları için, çalışma kitabını dışarıda hesaplayın ve çözülen değerleri grafik verisine geri yazın.

**Formül dizeleri `=` ile başlamalı mı?**

Aspose.Slides API örnekleri, `B2-C2` veya `SUM(B2:B5)` gibi ifadeleri başında `=` olmadan atar. Bu biçimi kullanmak, oluşturulan formüllerin belgelenen API örnekleriyle tutarlı olmasını sağlar.