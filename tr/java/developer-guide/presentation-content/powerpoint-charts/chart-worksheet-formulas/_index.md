---
title: Java'da Sunumlarda Grafik Çalışma Sayfası Formüllerini Uygula
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java grafik çalışma sayfalarında Excel benzeri formülleri uygulayın, değerleri yeniden hesaplayın ve sonuçları PowerPoint grafiklerinde kullanın."
---
## **Genel Bakış**

PowerPoint grafikler genellikle kaynak verilerini gömülü bir çalışma sayfasında saklar. Aspose.Slides for Java’da bu çalışma sayfasına grafik veri çalışma kitabı aracılığıyla erişebilir, giriş değerlerini yazabilir, hücrelere formüller atayabilir, desteklenen formülleri hesaplayabilir ve hesaplanan hücreleri grafik verisi olarak kullanabilirsiniz.

Bu makale tam formül iş akışını açıklar: bir grafik oluşturma, çalışma sayfasını doldurma, A1‑stil veya R1C1‑stil formüller atama, bunları yeniden hesaplama, hesaplanan değerleri okuma, bu hücreleri bir grafik serisine bağlama ve sunumu kaydetme. Ayrıca desteklenen formül sözdizimi, yerleşik işlev alt kümesi, önbelleklenmiş değerler, desteklenmeyen formüller ve elektronik tabloya özgü hatalar da anlatılmaktadır.

## **Grafik Çalışma Sayfaları ve Formüller**

Bir grafik çalışma sayfası, bir grafik tarafından kullanılan kategori, seri adları ve değerleri içerir. PowerPoint’te grafik veri düzenleyicisini açarak çalışma sayfasını inceleyebilirsiniz:

![Gömülü çalışma sayfası açık olan PowerPoint grafiği, kategori ve seri verilerini gösteriyor](chart-worksheet-formulas_1.png)

Aspose.Slides’ta çalışma sayfası, [IChartDataWorkbook](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdataworkbook/) arabirimi aracılığıyla sunulur. A1‑stil formüller için [IChartDataCell.setFormula](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) ve R1C1‑stil formüller için [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) kullanın. Giriş hücrelerini veya formüllerini değiştirdikten sonra, desteklenen formülleri yeniden hesaplamak ve ilgili hücre değerlerini güncellemek için [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) çağırın.

Hesaplanan bir hücre, sonucunu hâlâ [IChartDataCell.getValue](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatacell/#getValue--) üzerinden gösterir. Bu, bir formül sonucunu kod içinde incelemeniz veya hücreyi bir grafik veri noktası olarak kullanmanız gerektiğinde önemlidir.

## **Bir Grafik Oluşturma ve Çalışma Sayfası Formüllerini Hesaplama**

Aşağıdaki örnek uçtan uca bir iş akışını gösterir. Küme sütun grafiği oluşturur, örnek verileri temizler, çeyrek bazında gelir ve gider değerlerini yazar, formüllerle karı hesaplar, sonuçları okur, hesaplanan hücreleri grafik değerleri olarak kullanır ve sunumu kaydeder.

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

Grafik veri noktaları `D2:D4` aralığını referans alır, dolayısıyla grafik hesaplanan kar değerlerini kullanır. Bu iş akışında ayrı bir grafik‑yenileme çağrısı yoktur: önce çalışma kitabını yeniden hesaplayın, ardından hesaplanan hücrelere işaret eden grafik verisini kullanın veya kaydedin.

## **A1- Stil Formüllerini Kullanma**

A1 notasyonu, sütunları harflerle ve satırları sayılarla tanımlar. A1‑stil ifadeleri [IChartDataCell.setFormula](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) aracılığıyla atayın.

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

Göreli referanslar bir formül bir elektronik tablo uygulaması tarafından taşındığında veya kopyalandığında değişebilir. Mutlak referanslar her iki koordinatı da sabit tutar, karışık referanslar ise yalnızca bir satırı veya bir sütunu sabitler.

## **R1C1- Stil Formüllerini Kullanma**

R1C1 notasyonu, satırları ve sütunları sayısal olarak tanımlar. Göreli referanslar köşeli parantez içinde ofsetler kullanır. Bu sözdizimini [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) aracılığıyla atayın.

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

Örneğin, `D2` hücresinde `RC[-2]`, aynı satırda iki sütun sola (`B2`) olan hücreyi ifade eder.

## **Formül Sabitleri ve Operatörler**

Yerleşik formül değerlendirme motoru mantıksal değerleri, sayısal sabitleri, metinleri, elektronik tablo hata değerlerini, aritmetik operatörleri ve karşılaştırma operatörlerini destekler.

### **Sabitler ve Literaller**

| Tür | Örnekler | Notlar |
|---|---|---|
| Mantıksal | `TRUE`, `FALSE` | `A2=TRUE` gibi mantıksal ifadelerde doğrudan kullanılabilir. |
| Sayısal | `1`, `0.5`, `.3`, `1E-2` | Yaygın ve bilimsel gösterimler desteklenir. |
| Metin | `"abc"`, `"2/3/2020 12:00"` | Metin sabitleri formül içinde çift tırnak içinde yazılır. |
| Hata sonucu | `#DIV/0!`, `#N/A`, `#REF!` | Geçerli bir formül, normal sonuç yerine bir elektronik tablo hata değeri üretebilir. |

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

    Object logicalValue = workbook.getCell(0, "B2").getValue(); // false
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

Aspose.Slides, grafik çalışma sayfaları için yerleşik bir formül değerlendiricisi içerir, ancak bu tam bir Excel hesaplama motoru değildir. Belgelendirilmiş fonksiyon kümesi aşağıdaki fonksiyonlarla sınırlıdır. [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) ile rastgele bir Excel fonksiyonunun yeniden hesaplanabileceğini varsaymayın.

| Fonksiyon | Amaç veya desteklenen biçim | Örnek |
|---|---|---|
| `ABS` | Mutlak değer | `ABS(A2)` |
| `AVERAGE` | Aritmetik ortalama | `AVERAGE(B2:B5)` |
| `CEILING` | Sayıyı bir katına yukarı yuvarla | `CEILING(A2,5)` |
| `CHOOSE` | İndexe göre değer seç | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Metin değerlerini birleştir | `CONCAT(A2,B2)` |
| `CONCATENATE` | Metin değerlerini birleştir | `CONCATENATE(A2," ",B2)` |
| `DATE` | 1900 tarih sistemini kullanarak tarih değeri oluştur | `DATE(2026,8,19)` |
| `DAYS` | Tarihler arasındaki gün sayısını döndür | `DAYS(B2,A2)` |
| `FIND` | Bir metin içinde başka bir metni bul | `FIND("-",A2)` |
| `FINDB` | Bayt‑temelli metin araması | `FINDB("a",A2)` |
| `IF` | Koşullu sonuç | `IF(A2>0,A2,0)` |
| `INDEX` | Referans biçimi | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektör biçimi | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektör biçimi | `MATCH(A2,B2:B5,0)` |
| `MAX` | En büyük değer | `MAX(B2:B5)` |
| `SUM` | Toplam | `SUM(B2:B5)` |
| `VLOOKUP` | Düşey arama | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Tabloda gösterilen kısıtlamalar önemlidir: `INDEX` referans biçiminde, `LOOKUP` ve `MATCH` vektör biçiminde belgelenmiştir. `DATE` 1900 tarih sistemini kullanır. Burada listelenmeyen özellik ve fonksiyonlar, Aspose.Slides formül değerlendirme motoru tarafından desteklenmiyormuş gibi ele alınmalıdır.

## **Yeniden Hesaplama ve Önbelleklenmiş Değerler**

Elektronik tablo dosyaları genellikle bir formül ve onun son hesaplanmış değerini birlikte saklar. Bu nedenle Aspose.Slides, bir sunum yüklendiğinde ve ilgili grafik verisi değişmemişse, [IChartDataCell.getValue](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatacell/#getValue--) aracılığıyla önbelleklenmiş bir değeri okuyabilir.

Giriş hücrelerini veya formüllerini değiştirdikten sonra eski bir önbellek sonucu üzerine güvenmeyin. Hesaplanmış değerlere erişmeden veya bunlara bağlı grafik verisini kaydetmeden önce [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) çağırın.

Desteklenen alt kümenin dışındaki formüller için Aspose.Slides formülü ayrıştıramayabilir veya bağımlılıklarını tespit edemeyebilir. Çalışma kitabı değiştirilmişse, önceki önbelleklenmiş değer artık güvenilir kabul edilemez. Bu durumda, desteklenmeyen veri içeren bir hücrenin değerini okumak [CellUnsupportedDataException](https://reference.aspose.com/slides/tr/java/com.aspose.slides/cellunsupporteddataexception/) hatasına yol açabilir.

Grafiğiniz Aspose.Slides’ın değerlendirmediği Excel fonksiyonlarına bağımlıysa, bu formülleri destekleyen bir elektronik tablo motoru ile hesaplayıp ortaya çıkan değerleri grafik çalışma kitabına geri yazın. Desteklenmeyen formülleri tahmini değerlerle değiştirmeyin.

## **Formül Hatalarını Ele Alma**

Ayırt edilmesi gereken iki farklı sorun türü vardır.

Bir formül geçerli olabilir ancak `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` veya `#VALUE!` gibi bir elektronik tablo hata sonucu üretebilir. Bu durumda hata belirteci bir hücre sonucudur ve [IChartDataCell.getValue](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatacell/#getValue--) aracılığıyla döndürülebilir.

Bir formül aynı zamanda ayrıştırma, referans, bağımlılık veya desteklenen veri seviyesinde başarısız olabilir. Aspose.Slides bu durumlar için elektronik tablo‑özgü istisnalar sağlar: [CellInvalidFormulaException](https://reference.aspose.com/slides/tr/java/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/tr/java/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/tr/java/com.aspose.slides/cellcircularreferenceexception/) ve [CellUnsupportedDataException](https://reference.aspose.com/slides/tr/java/com.aspose.slides/cellunsupporteddataexception/).

Formüller şablonlardan veya kullanıcı girdisinden geldiğinde, bu istisnaları yeniden hesaplama ve değer erişimi çevresinde yakalayın:

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

Grafik çalışma sayfalarındaki formül desteği, tam Excel uyumluluğu yerine tanımlı bir elektronik tablo hesaplama alt kümesi için tasarlanmıştır. Raporlama iş akışınızı tasarlarken şu kısıtlamaları aklınızda bulundurun:

- Aspose.Slides'ın formülleri yeniden hesaplamasını istediğinizde yalnızca belgelenmiş sabitleri, operatörleri, referansları ve fonksiyonları kullanın.
- Formül sonuçlarına bağımlı hücreleri değiştirdikten sonra yeniden hesaplayın.
- Yüklenmiş sunumlardan alınan önbelleklenmiş değerleri bir anlık görüntü olarak değerlendirin, düzenlemelerden sonra yeniden hesaplamanın yerine geçmemelidir.
- Varolan şablonlardan gelen formülleri, özellikle belgelenmiş listenin dışındaki fonksiyonları kullanıyorsa, hesaplanan değerlerine güvenmeden önce test edin.
- Tam bir elektronik tablo hesaplama motoru gerektiren formüller için, bunları dışarıda hesaplayın ve ardından ortaya çıkan değerlerle grafik çalışma kitabını güncelleyin.

## **SSS**

**[IChartDataCell.setFormula](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) ile [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) arasındaki fark nedir?**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) `B2-C2` gibi bir A1‑stil ifadesi depolar. [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) ise `RC[-2]-RC[-1]` gibi bir R1C1‑stil ifadesi depolar. Formülleri nasıl oluşturup kopyaladığınıza en uygun notasyonu kullanın.

**Hesaplamadan sonra hücreyi mi yoksa değerini mi okumam gerekir?**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) bir [IChartDataCell](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatacell/) döndürür. Hesaplanmış sonucu elde etmek için yeniden hesaplamadan sonra o hücrenin [IChartDataCell.getValue](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdatacell/#getValue--) yöntemini çağırın.

**[IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) ne zaman çağrılmalı?**

Giriş değerlerini veya formüllerini değiştirdikten ve hesaplanmış sonuçlara ihtiyaç duymadan önce [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) çağırın. Bu, yerleşik değerlendiricinin desteklediği formüllerin değerlerini günceller.

**Aspose.Slides her Excel fonksiyonunu destekliyor mu?**

Hayır. Yerleşik değerlendirici, belgelenmiş bir fonksiyon alt kümesini destekler. Bu alt kümenin dışındaki fonksiyonların doğru şekilde yeniden hesaplanacağı varsayılmamalıdır. Tam Excel formül uyumluluğu gerekiyorsa, hesabı uygun bir elektronik tablo motoru ile yapın ve nihai değerleri grafik çalışma kitabına yazın.

**Yüklenmiş bir sunum desteklenmeyen bir formül içeriyorsa ne olur?**

Grafik verisi değişmemişse, çalışma kitabı önceki hesaplanmış önbellek değerini tutabilir. İlgili veri değiştirildiğinde bu önbellek değeri artık geçerli olmayabilir. Formülü işlenemeyen bir hücreye erişmek [CellUnsupportedDataException](https://reference.aspose.com/slides/tr/java/com.aspose.slides/cellunsupporteddataexception/) hatasına yol açabilir.

**Formül hata değerleri Java istisnalarıyla aynı mı?**

Hayır. `#DIV/0!` gibi bir sonuç, geçerli bir hesaplamanın ürettiği bir elektronik tablo değeridir. [CellInvalidFormulaException](https://reference.aspose.com/slides/tr/java/com.aspose.slides/cellinvalidformulaexception/) veya [CellCircularReferenceException](https://reference.aspose.com/slides/tr/java/com.aspose.slides/cellcircularreferenceexception/) gibi istisnalar, formülün normal şekilde işlenemediğini gösterir.

**Bir formül hücresi değiştiğinde grafik otomatik olarak güncellenir mi?**

Bir grafik serisi, çalışma kitabı hücrelerine referans verebilir. Önce çalışma kitabını yeniden hesaplayın, ardından sunumu kaydedin veya render edin. Grafik veri noktaları hesaplanan hücreleri referans alıyorsa, grafik bu güncel hücre değerlerini kullanır; bu iş akışı için ayrı bir grafik‑yenileme yöntemi gerekmez.

**Grafikler harici bir Excel çalışma kitabı kullanabilir mi?**

Evet, grafik verisi API’si aracılığıyla harici bir çalışma kitabı kullanılabilir. Ancak bu makalede açıklanan formül hesaplama iş akışı, sadece grafik veri çalışma kitabını ve Aspose.Slides tarafından değerlendirilen formül alt kümesini kapsar. [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ichartdataworkbook/#calculateFormulas--)‘in dış bir XLSX dosyasındaki rastgele formüllerin tam yeniden hesaplamasını sağladığını varsaymayın.

**Başka bir çalışma sayfasına veya çalışma kitabına referans veren formüller kullanabilir miyim?**

Excel‑stil referanslar grafik çalışma kitaplarında bulunabilir, ancak formül değerlendirme, desteklenen ayrıştırıcı ve fonksiyon setiyle sınırlıdır. Çapraz‑sayfa veya harici bir referans kritikse, tam olarak kullandığınız Aspose.Slides sürümüyle formülü doğrulayın. Geniş Excel referans uyumluluğu gerektiren iş akışları için, çalışma kitabını dışarıda hesaplayıp sonuçları grafik verisine geri yazın.

**Formül metinleri `=` ile başlamalı mı?**

Aspose.Slides API örnekleri, `B2-C2` veya `SUM(B2:B5)` gibi ifadeleri baştaki `=` olmadan atar. Bu biçimi kullanmak, oluşturulan formüllerin API belgelerindeki örneklerle tutarlı olmasını sağlar.