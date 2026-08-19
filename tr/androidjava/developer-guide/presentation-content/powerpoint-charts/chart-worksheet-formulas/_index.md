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
- mantıksal sabit
- sayısal sabit
- dize sabiti
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
description: "Aspose.Slides for Android via Java grafik çalışma sayfalarında Excel tarzı formülleri uygulayın, değerleri yeniden hesaplayın ve sonuçları PowerPoint grafiklerinde kullanın."
---
## **Genel Bakış**

PowerPoint grafikleri genellikle kaynak verilerini gömülü bir çalışma sayfasında saklar. Aspose.Slides for Android via Java’da bu çalışma sayfasına grafik veri çalışma kitabı aracılığıyla erişebilir, giriş değerleri yazabilir, hücrelere formül atayabilir, desteklenen formülleri hesaplayabilir ve hesaplanan hücreleri grafik verisi olarak kullanabilirsiniz.

Bu makale tam formül iş akışını açıklar: bir grafik oluşturma, çalışma sayfasını doldurma, A1‑stilinde veya R1C1‑stilinde formüller atama, bunları yeniden hesaplama, hesaplanan değerleri okuma, bu hücreleri bir grafik serisine bağlama ve sunumu kaydetme. Ayrıca desteklenen formül sözdizimini, yerleşik fonksiyon alt kümesini, önbelleğe alınmış değerleri, desteklenmeyen formülleri ve elektronik tabloya özgü hataları tanımlar.

## **Grafik Çalışma Sayfaları ve Formüller**

Bir grafik çalışma sayfası, bir grafik tarafından kullanılan kategori, seri adları ve değerleri içerir. PowerPoint’te, grafik veri düzenleyicisini açarak çalışma sayfasını inceleyebilirsiniz:

![Gömülü çalışma sayfası açık PowerPoint grafiği, kategori ve seri verilerini gösterir](chart-worksheet-formulas_1.png)

Aspose.Slides’ta, çalışma sayfası [IChartDataWorkbook](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdataworkbook/) arayüzü aracılığıyla ortaya çıkar. A1 tarzı formüller için [IChartDataCell.setFormula](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) , R1C1 tarzı formüller için [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) kullanın. Giriş hücrelerini veya formülleri değiştirdikten sonra, desteklenen formülleri yeniden hesaplamak ve ilgili hücre değerlerini güncellemek için [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) çağırın.

Hesaplanmış bir hücre, sonucunu hâlâ [IChartDataCell.getValue](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatacell/#getValue--) yoluyla sunar. Bu, kod içinde bir formül sonucunu incelemeniz veya hücreyi bir grafik veri noktası olarak kullanmanız gerektiğinde önemlidir.

## **Grafik Oluşturma ve Çalışma Sayfası Formüllerini Hesaplama**

Aşağıdaki örnek uçtan uca bir iş akışını gösterir. Küme sütun grafiği oluşturur, örnek veriyi temizler, çeyrek bazında gelir ve gider değerlerini yazar, formüllerle karı hesaplar, sonuçları okur, hesaplanan hücreleri grafik değerleri olarak kullanır ve sunumu kaydeder.

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

Grafik veri noktaları `D2:D4` aralığını referans alır, bu nedenle grafik hesaplanan kar değerlerini kullanır. Bu iş akışında ayrı bir grafik‑yenileme çağrısı yoktur: önce çalışma kitabını yeniden hesaplayın, ardından hesaplanan hücrelere işaret eden grafik verisini kullanın veya kaydedin.

## **A1‑ Stilinde Formüller Kullanma**

A1 notasyonu sütunları harflerle, satırları sayılarla tanımlar. A1‑stilindeki ifadeleri [IChartDataCell.setFormula](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) aracılığıyla atayın.

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

Yaygın A1 referans formları şunlardır:

| Referans | Göreceli | Mutlak | Karışık |
|---|---|---|---|
| Hücre | `A2` | `$A$2` | `A$2`, `$A2` |
| Satır | `2:2` | `$2:$2` | — |
| Sütun | `A:A` | `$A:$A` | — |
| Aralık | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Göreceli referanslar, bir formül bir elektronik tablo uygulaması tarafından taşındığında veya kopyalandığında değişebilir. Mutlak referanslar her iki koordinatı da sabit tutar, karışık referanslar ise yalnızca bir satırı ya da bir sütunu sabitler.

## **R1C1‑Stilinde Formüller Kullanma**

R1C1 notasyonu hem satırları hem sütunları sayısal olarak tanımlar. Göreceli referanslar köşeli parantez içinde ofsetler kullanır. Bu sözdizimini [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) aracılığıyla atayın.

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

Yaygın R1C1 referans formları şunlardır:

| Referans | Göreceli | Mutlak | Karışık |
|---|---|---|---|
| Hücre | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Satır | `R[2]` | `R2` | — |
| Sütun | `C[3]` | `C3` | — |
| Aralık | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Örneğin, `D2` hücresinde `RC[-2]` aynı satırda iki sütun sola (`B2`) olan hücreyi ifade eder.

## **Formül Sabitleri ve Operatörleri**

Yerleşik formül değerlendiricisi mantıksal değerleri, sayısal sabitleri, dizeleri, elektronik tablo hata değerlerini, aritmetik operatörleri ve karşılaştırma operatörlerini destekler.

### **Sabitler ve Literaller**

| Tür | Örnekler | Notlar |
|---|---|---|
| Mantıksal | `TRUE`, `FALSE` | `A2=TRUE` gibi mantıksal ifadelerde doğrudan kullanılabilir. |
| Sayısal | `1`, `0.5`, `.3`, `1E-2` | Yaygın ve bilimsel gösterimler desteklenir. |
| Dize | `"abc"`, `"2/3/2020 12:00"` | Metin sabitleri formül içinde çift tırnak içinde yer alır. |
| Hata sonucu | `#DIV/0!`, `#N/A`, `#REF!` | Geçerli bir formül, normal bir sonuç yerine bir elektronik tablo hata değeri döndürebilir. |

Bu örnek birkaç sabit türünü gösterir:

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

| Operatör | Anlamı | Örnek |
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

| Operatör | Anlamı | Örnek |
|---|---|---|
| `=` | Eşittir | `A2=3` |
| `<>` | Eşit değildir | `A2<>3` |
| `>` | Büyüktür | `A2>3` |
| `>=` | Büyük veya eşittir | `A2>=3` |
| `<` | Küçüktür | `A2<3` |
| `<=` | Küçük veya eşittir | `A2<=3` |

## **Desteklenen Önceden Tanımlı Fonksiyonlar**

Aspose.Slides, grafik çalışma sayfaları için yerleşik bir formül değerlendiricisi içerir, ancak bu tam bir Excel hesaplama motoru değildir. Belgelendirilen fonksiyon seti aşağıdaki fonksiyonlarla sınırlıdır. [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) aracılığıyla rastgele bir Excel fonksiyonunun yeniden hesaplanabileceğini varsaymayın.

| Fonksiyon | Amacı ya da desteklenen form | Örnek |
|---|---|---|
| `ABS` | Mutlak değer | `ABS(A2)` |
| `AVERAGE` | Aritmetik ortalama | `AVERAGE(B2:B5)` |
| `CEILING` | Bir sayıyı yukarı doğru bir katına yuvarla | `CEILING(A2,5)` |
| `CHOOSE` | İndexe göre bir değer seç | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Metin değerlerini birleştir | `CONCAT(A2,B2)` |
| `CONCATENATE` | Metin değerlerini birleştir | `CONCATENATE(A2," ",B2)` |
| `DATE` | 1900 tarih sistemini kullanarak bir tarih değeri oluştur | `DATE(2026,8,19)` |
| `DAYS` | Tarihler arasındaki gün sayısını döndür | `DAYS(B2,A2)` |
| `FIND` | Bir metin değerini diğerinin içinde bul | `FIND("-",A2)` |
| `FINDB` | Bayt yönelimli metin araması | `FINDB("a",A2)` |
| `IF` | Koşullu sonuç | `IF(A2>0,A2,0)` |
| `INDEX` | Referans biçimi | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektör biçimi | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektör biçimi | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maksimum değer | `MAX(B2:B5)` |
| `SUM` | Değerleri toplar | `SUM(B2:B5)` |
| `VLOOKUP` | Dikey arama | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Tabloda gösterilen kısıtlamalar önemlidir: `INDEX` referans biçiminde belgelenirken, `LOOKUP` ve `MATCH` vektör biçimlerinde belgelenir. `DATE` 1900 tarih sistemini kullanır. Burada listelenmeyen özellikler ve fonksiyonlar, Aspose.Slides formül değerlendiricisi tarafından desteklenmiyormuş gibi ele alınmalıdır.

## **Yeniden Hesaplama ve Önbellek Değerleri**

Elektronik tablo dosyaları genellikle bir formül ile onun son hesaplanmış değerini birlikte depolar. Aspose.Slides, bir sunum yüklendiğinde ve ilgili grafik verisi değiştirilmediğinde, [IChartDataCell.getValue](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatacell/#getValue--) aracılığıyla önbelleğe alınmış bir değeri okuyabilir.

Giriş hücrelerini veya formülleri değiştirdikten sonra eski bir önbellek sonucuna güvenmeyin. Hesaplanan değerleri okumadan veya onlara bağlı grafik verisini kaydetmeden önce [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) çağırın.

Desteklenen alt kümenin dışındaki formüller için Aspose.Slides formülü ayrıştıramayabilir veya bağımlılıklarını belirleyemeyebilir. Çalışma kitabı değiştirilmişse, önceki önbellek değeri artık güvenilir sayılmaz. Bu durumda, desteklenmeyen veriye sahip bir hücrenin değerini okumak [CellUnsupportedDataException](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/cellunsupporteddataexception/) hatasına yol açabilir.

Grafiğiniz Aspose.Slides’ın değerlendirmediği Excel fonksiyonlarına dayanıyorsa, bu formülleri bu fonksiyonları destekleyen bir elektronik tablo motoruyla hesaplayın ve elde edilen değerleri grafik çalışma kitabına geri yazın. Desteklenmeyen formülleri tahmini değerlerle değiştirmeyin.

## **Formül Hatalarını Ele Alma**

Ayırt edilmesi gereken iki farklı problem türü vardır.

Bir formül geçerli olabilir ancak `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` veya `#VALUE!` gibi bir elektronik tablo hata sonucu üretebilir. Bu durumda hata belirteci bir hücre sonucudur ve [IChartDataCell.getValue](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatacell/#getValue--) aracılığıyla döndürülebilir.

Bir formül ayrıca ayrıştırma, referans, bağımlılık veya desteklenen‑veri seviyesinde başarısız olabilir. Aspose.Slides bu durumlar için elektronik tablo‑özel istisnalar sağlar: [CellInvalidFormulaException](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/cellcircularreferenceexception/) ve [CellUnsupportedDataException](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/cellunsupporteddataexception/).

Şablonlardan veya kullanıcı girişlerinden gelen formüllerle çalışırken, yeniden hesaplama ve değer erişimi etrafında bu istisnaları yakalayın:

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

Grafik çalışma sayfalarındaki formül desteği, tam Excel uyumluluğu değil, tanımlı bir elektronik tablo hesaplama alt kümesi için tasarlanmıştır. Raporlama iş akışınızı tasarlarken şu kısıtlamaları aklınızda tutun:

- Aspose.Slides’ın formülleri yeniden hesaplamasını istediğinizde yalnızca belgelenen sabitleri, operatörleri, referansları ve fonksiyonları kullanın.
- Formül sonuçlarının bağımlı olduğu hücreleri değiştirdikten sonra yeniden hesaplayın.
- Yüklenmiş sunumlardan gelen önbellek değerlerini bir anlık görüntü olarak değerlendirin; düzenlemelerden sonra yeniden hesaplamanın yerini tutmaz.
- Mevcut şablonlardaki formülleri, belgelenen listenin dışındaki fonksiyonları kullandıklarında, hesaplanan değerlerine güvenmeden önce test edin.
- Tam bir elektronik tablo hesaplama motoru gerektiren formüller için bunları dışarıda hesaplayın ve ardından elde edilen değerlerle grafik çalışma kitabını güncelleyin.

## **SSS**

**[IChartDataCell.setFormula](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) ile [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) arasındaki fark nedir?**

[IChartDataCell.setFormula](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatacell/#setFormula-java.lang.String-) `B2-C2` gibi bir A1‑stil ifadesi depolar. [IChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatacell/#setR1C1Formula-java.lang.String-) ise `RC[-2]-RC[-1]` gibi bir R1C1‑stil ifadesi depolar. Formülleri oluşturma veya kopyalama yönteminizle en iyi eşleşen notasyonu kullanın.

**Hesaplamadan sonra hücrenin kendisini mi yoksa değerini mi okumam gerekir?**

[IChartDataWorkbook.getCell](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-java.lang.String-) bir [IChartDataCell](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatacell/) döndürür. Hesaplanmış sonucu elde etmek için, yeniden hesaplamadan sonra o hücrenin [IChartDataCell.getValue](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdatacell/#getValue--) metodunu çağırın.

**[IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) ne zaman çağrılmalı?**

Giriş değerlerini veya formülleri değiştirdikten sonra ve hesaplanan sonuçlara bağlı olmadan önce [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) çağırın. Bu, yerleşik değerlendiricinin desteklediği formüllerin değerlerini günceller.

**Aspose.Slides her Excel fonksiyonunu destekliyor mu?**

Hayır. Yerleşik değerlendirici belgelenen bir fonksiyon alt kümesini destekler. Bu alt kümenin dışındaki fonksiyonların doğru bir şekilde yeniden hesaplanacağını varsaymayın. Tam Excel formül uyumluluğu gerekiyorsa, hesaplamayı uygun bir elektronik tablo motoruyla yapın ve nihai değerleri grafik çalışma kitabına yazın.

**Yüklenmiş bir sunum desteklenmeyen bir formül içeriyorsa ne olur?**

Grafik verisi değişmemişse, çalışma kitabı hâlâ daha önce hesaplanmış bir önbellek değeri içerebilir. İlgili veri değiştirildiğinde, bu önbellek değeri artık geçerli olmayabilir. Formülü işlenemeyen bir hücreye erişmek [CellUnsupportedDataException](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/cellunsupporteddataexception/) hatasına yol açabilir.

**Formül hata değerleri Java istisnalarıyla aynı mı?**

Hayır. `#DIV/0!` gibi bir sonuç, geçerli bir hesaplamanın ürettiği bir elektronik tablo değeridir. [CellInvalidFormulaException](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/cellinvalidformulaexception/) veya [CellCircularReferenceException](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/cellcircularreferenceexception/) gibi istisnalar, formülün normal şekilde işlenemediğini gösterir.

**Bir formül hücresi değiştiğinde grafik otomatik olarak güncellenir mi?**

Bir grafik serisi, çalışma kitabı hücrelerine referans verebilir. Önce çalışma kitabını yeniden hesaplayın, ardından sunumu kaydedin veya oluşturun. Grafik veri noktaları hesaplanan hücrelere referans veriyorsa, grafik bu güncellenmiş hücre değerlerini kullanır; bu iş akışı için ayrı bir grafik‑yenileme yöntemi gerekmez.

**Grafikler harici bir Excel çalışma kitabı kullanabilir mi?**

Evet, grafik verisi dış bir çalışma kitabını grafik veri API’si aracılığıyla yapılandırılabilir. Ancak bu makalede açıklanan formül hesaplama iş akışı, grafik veri çalışma kitabı ve Aspose.Slides tarafından değerlendirilen formül alt kümesiyle ilgilidir. [IChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ichartdataworkbook/#calculateFormulas--) dış bir XLSX dosyasındaki rastgele formüllerin tam yeniden hesaplamasını sağlayacağını varsaymayın.

**Başka bir çalışma sayfasına veya çalışma kitabına referans veren formüller kullanabilir miyim?**

Excel‑stil referanslar grafik çalışma kitaplarında bulunabilir, ancak formül değerlendirmesi desteklenen ayrıştırıcı ve fonksiyon setiyle sınırlıdır. Çapraz‑sayfa veya dış referans kritikse, hedef Aspose.Slides sürümünüzle tam formülü doğrulayın. Geniş Excel referans uyumluluğu gerektiren iş akışları için, çalışma kitabını dışarıda hesaplayın ve çözülen değerleri grafik verisine geri yazın.

**Formül dizeleri `=` ile başlamalı mı?**

Aspose.Slides API örnekleri `B2-C2` veya `SUM(B2:B5)` gibi başında `=` olmadan ifadeler atar. Bu biçimi kullanmak, oluşturulan formüllerin belgelenen API örnekleriyle tutarlı kalmasını sağlar.