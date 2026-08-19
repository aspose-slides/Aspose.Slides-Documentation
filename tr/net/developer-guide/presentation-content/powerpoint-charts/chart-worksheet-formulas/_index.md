---
title: .NET'te Sunumlarda Grafik Çalışma Sayfası Formüllerini Uygula
linktitle: Çalışma Sayfası Formülleri
type: docs
weight: 70
url: /tr/net/chart-worksheet-formulas/
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
- A1 tarzı
- R1C1 tarzı
- önceden tanımlı işlev
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET grafik çalışma sayfalarında Excel benzeri formülleri uygulayın, değerleri yeniden hesaplayın ve sonuçları PowerPoint grafiklerinde kullanın."
---
## **Genel Bakış**

PowerPoint grafikler genellikle veri kaynaklarını gömülü bir çalışma sayfasında saklar. Aspose.Slides for .NET içinde bu çalışma sayfasına grafik veri çalışma kitabı aracılığıyla erişebilir, giriş değerleri yazabilir, hücrelere formüller atayabilir, desteklenen formülleri hesaplayabilir ve hesaplanan hücreleri grafik verisi olarak kullanabilirsiniz.

Bu makale, tam formül iş akışını açıklar: bir grafik oluşturma, çalışma sayfasını doldurma, A1‑stil veya R1C1‑stil formüller atama, bunları yeniden hesaplama, hesaplanan değerleri okuma, bu hücreleri bir grafik serisine bağlama ve sunumu kaydetme. Ayrıca desteklenen formül sözdizimini, yerleşik işlev alt kümesini, önbelleğe alınmış değerleri, desteklenmeyen formülleri ve elektronik tabloya özgü hataları da açıklar.

## **Grafik Çalışma Sayfaları ve Formüller**

Bir grafik çalışma sayfası, grafik tarafından kullanılan kategorileri, seri adlarını ve değerleri içerir. PowerPoint'te, grafik veri düzenleyicisini açarak çalışma sayfasını inceleyebilirsiniz:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

Aspose.Slides'te, çalışma sayfası [chart data workbook](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdataworkbook/) aracılığıyla sunulur. A1‑stil formüller için [Formula](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatacell/formula/) özelliğini, R1C1‑stil formüller için ise [R1C1Formula](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatacell/r1c1formula/) özelliğini kullanın. Giriş hücrelerini veya formüllerini değiştirdikten sonra, desteklenen formülleri yeniden hesaplamak ve ilgili hücre değerlerini güncellemek için [CalculateFormulas](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) çağrısını yapın.

Hesaplanan bir hücre, sonucunu hâlâ [Value](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatacell/value/) özelliği aracılığıyla gösterir. Bu, kod içinde bir formül sonucunu incelemeniz gerektiğinde veya hücreyi bir grafik veri noktası olarak kullanmanız gerektiğinde önemlidir.

## **Bir Grafik Oluşturma ve Çalışma Sayfası Formüllerini Hesaplama**

Aşağıdaki örnek, uçtan uca bir iş akışını gösterir. Küme sütun grafiği oluşturur, örnek verileri temizler, çeyrek bazında gelir ve gider değerlerini yazar, karı formüllerle hesaplar, sonuçları okur, hesaplanan hücreleri grafik değerleri olarak kullanır ve sunumu kaydeder.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
workbook.Clear(worksheetIndex);

var category1 = workbook.GetCell(worksheetIndex, "A2", "Q1");
var category2 = workbook.GetCell(worksheetIndex, "A3", "Q2");
var category3 = workbook.GetCell(worksheetIndex, "A4", "Q3");

workbook.GetCell(worksheetIndex, "B1", "Revenue");
workbook.GetCell(worksheetIndex, "C1", "Expenses");
workbook.GetCell(worksheetIndex, "D1", "Profit");

workbook.GetCell(worksheetIndex, "B2").Value = 120.0;
workbook.GetCell(worksheetIndex, "C2").Value = 80.0;
workbook.GetCell(worksheetIndex, "B3").Value = 150.0;
workbook.GetCell(worksheetIndex, "C3").Value = 95.0;
workbook.GetCell(worksheetIndex, "B4").Value = 135.0;
workbook.GetCell(worksheetIndex, "C4").Value = 110.0;

var profit1 = workbook.GetCell(worksheetIndex, "D2");
var profit2 = workbook.GetCell(worksheetIndex, "D3");
var profit3 = workbook.GetCell(worksheetIndex, "D4");

profit1.Formula = "B2-C2";
profit2.Formula = "B3-C3";
profit3.Formula = "B4-C4";

workbook.CalculateFormulas();

var q1Profit = Convert.ToDouble(profit1.Value); // 40
var q2Profit = Convert.ToDouble(profit2.Value); // 55
var q3Profit = Convert.ToDouble(profit3.Value); // 25

Console.WriteLine($"Q1 profit: {q1Profit}");
Console.WriteLine($"Q2 profit: {q2Profit}");
Console.WriteLine($"Q3 profit: {q3Profit}");

chart.ChartData.Categories.Add(category1);
chart.ChartData.Categories.Add(category2);
chart.ChartData.Categories.Add(category3);

var profitSeries = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, "D1"), chart.Type);
profitSeries.DataPoints.AddDataPointForBarSeries(profit1);
profitSeries.DataPoints.AddDataPointForBarSeries(profit2);
profitSeries.DataPoints.AddDataPointForBarSeries(profit3);
profitSeries.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("chart-formulas.pptx", SaveFormat.Pptx);
```

Grafik veri noktaları `D2:D4` aralığını referans alır, bu yüzden grafik hesaplanan kar değerlerini kullanır. Bu iş akışında ayrı bir grafik yenileme çağrısı yoktur: önce çalışma kitabını yeniden hesaplayın, ardından hesaplanan hücrelere işaret eden grafik verilerini kullanın veya kaydedin.

## **A1‑Stil Formüller Kullanma**

A1 gösterimi, sütunları harflerle ve satırları sayılarla tanımlar. A1‑stil ifadeleri [IChartDataCell.Formula](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatacell/formula/) aracılığıyla atayın.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "C3").Value = 10;
workbook.GetCell(0, "F2").Value = 2;
workbook.GetCell(0, "G2").Value = 3;
workbook.GetCell(0, "H2").Value = 4;

var cell = workbook.GetCell(0, "A2");
cell.Formula = "C3+SUM(F2:H2)";

workbook.CalculateFormulas();

var value = cell.Value; // 19
```

Yaygın A1 referans biçimleri şunlardır:

| Referans | Göreli | Mutlak | Karma |
|---|---|---|---|
| Hücre | `A2` | `$A$2` | `A$2`, `$A2` |
| Satır | `2:2` | `$2:$2` | — |
| Sütun | `A:A` | `$A:$A` | — |
| Aralık | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Göreli referanslar, bir formül bir elektronik tablo uygulaması tarafından taşındığında veya kopyalandığında değişebilir. Mutlak referanslar hem satır hem sütun koordinatlarını sabit tutar, karma referanslar ise sadece bir satırı ya da bir sütunu sabitler.

## **R1C1‑Stil Formüller Kullanma**

R1C1 gösterimi, hem satırları hem sütunları sayısal olarak tanımlar. Göreli referanslar köşeli parantez içindeki kaydırımları kullanır. Bu sözdizimini [IChartDataCell.R1C1Formula](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatacell/r1c1formula/) aracılığıyla atayın.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "B2").Value = 12;
workbook.GetCell(0, "C2").Value = 5;

var cell = workbook.GetCell(0, "D2");
cell.R1C1Formula = "RC[-2]-RC[-1]";

workbook.CalculateFormulas();

var value = cell.Value; // 7
```

Yaygın R1C1 referans biçimleri şunlardır:

| Referans | Göreli | Mutlak | Karma |
|---|---|---|---|
| Hücre | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Satır | `R[2]` | `R2` | — |
| Sütun | `C[3]` | `C3` | — |
| Aralık | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Örneğin, `D2` hücresinde `RC[-2]`, aynı satırda iki sütun sola (`B2`) olan hücreyi ifade eder.

## **Formül Sabitleri ve Operatörler**

Yerleşik formül değerlendirme motoru, mantıksal değerleri, sayısal sabitleri, dizeleri, elektronik tablo hata değerlerini, aritmetik operatörleri ve karşılaştırma operatörlerini destekler.

### **Sabitler ve Sabit Değerler**

| Tür | Örnekler | Notlar |
|---|---|---|
| Mantıksal | `TRUE`, `FALSE` | `A2=TRUE` gibi mantıksal ifadelerde doğrudan kullanılabilir. |
| Sayısal | `1`, `0.5`, `.3`, `1E-2` | Yaygın ve bilimsel gösterimler desteklenir. |
| Dize | `"abc"`, `"2/3/2020 12:00"` | Metin sabitleri formül içinde çift tırnak işaretleriyle çevrelenir. |
| Hata sonucu | `#DIV/0!`, `#N/A`, `#REF!` | Geçerli bir formül, normal bir sonuç yerine bir elektronik tablo hata değeri üretebilir. |

Bu örnek, çeşitli sabit türlerini kullanır:

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;

workbook.GetCell(0, "A2").Value = false;
workbook.GetCell(0, "B2").Formula = "A2=TRUE";
workbook.GetCell(0, "C2").Formula = "1+0.5";
workbook.GetCell(0, "D2").Formula = ".3*1E-2";
workbook.GetCell(0, "E2").Formula = "\"abc\"";
workbook.GetCell(0, "F2").Formula = "2/0";

workbook.CalculateFormulas();

var logicalValue = workbook.GetCell(0, "B2").Value; // False
var numericValue = workbook.GetCell(0, "C2").Value; // 1.5
var scientificValue = workbook.GetCell(0, "D2").Value; // 0.003
var stringValue = workbook.GetCell(0, "E2").Value; // abc
var errorValue = workbook.GetCell(0, "F2").Value; // #DIV/0!
```

### **Aritmetik Operatörler**

| Operatör | Anlam | Örnek |
|---|---|---|
| `+` | Toplama veya tekli artı | `2+3` |
| `-` | Çıkarma veya negatif | `2-3`, `-3` |
| `*` | Çarpma | `2*3` |
| `/` | Bölme | `2/3` |
| `%` | Yüzde | `30%` |
| `^` | Üs | `2^3` |

Değerlendirme sırasını açıkça göstermek için parantez kullanın, örneğin `(A2+B2)*C2`.

### **Karşılaştırma Operatörleri**

Karşılaştırma ifadeleri mantıksal değerler döndürür.

| Operatör | Anlam | Örnek |
|---|---|---|
| `=` | Eşittir | `A2=3` |
| `<>` | Eşit değildir | `A2<>3` |
| `>` | Büyük | `A2>3` |
| `>=` | Büyük veya eşit | `A2>=3` |
| `<` | Küçük | `A2<3` |
| `<=` | Küçük veya eşit | `A2<=3` |

## **Desteklenen Önceden Tanımlı İşlevler**

Aspose.Slides, grafik çalışma sayfaları için yerleşik bir formül değerlendirme motoru içerir, ancak bu tam bir Excel hesaplama motoru değildir. Belgelendirilmiş işlev kümesi aşağıdaki işlevlerle sınırlıdır. Rasgele bir Excel işlevinin [CalculateFormulas](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) ile yeniden hesaplanabileceğini varsaymayın.

| İşlev | Amaç veya desteklenen form | Örnek |
|---|---|---|
| `ABS` | Mutlak değer | `ABS(A2)` |
| `AVERAGE` | Aritmetik ortalama | `AVERAGE(B2:B5)` |
| `CEILING` | Bir sayıyı yukarı doğru bir katına yuvarlar | `CEILING(A2,5)` |
| `CHOOSE` | İndekse göre bir değer seçer | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Metin değerlerini birleştirir | `CONCAT(A2,B2)` |
| `CONCATENATE` | Metin değerlerini birleştirir | `CONCATENATE(A2," ",B2)` |
| `DATE` | 1900 tarih sistemini kullanarak bir tarih değeri oluşturur | `DATE(2026,8,19)` |
| `DAYS` | Tarihler arasındaki gün sayısını döndürür | `DAYS(B2,A2)` |
| `FIND` | Bir metin değerini diğerinin içinde bulur | `FIND("-",A2)` |
| `FINDB` | Bayt temelli metin araması | `FINDB("a",A2)` |
| `IF` | Koşullu sonuç | `IF(A2>0,A2,0)` |
| `INDEX` | Referans formu | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektör formu | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektör formu | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maksimum değer | `MAX(B2:B5)` |
| `SUM` | Değerleri toplar | `SUM(B2:B5)` |
| `VLOOKUP` | Dikey arama | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Tabloda gösterilen kısıtlamalar önemlidir: `INDEX` referans formunda belgelenmiştir, `LOOKUP` ve `MATCH` ise vektör formlarında belgelenmiştir. `DATE` 1900 tarih sistemini kullanır. Burada listelenmeyen özellik ve işlevler, ayrı olarak belgelenmedikçe Aspose.Slides formül değerlendirme motoru tarafından desteklenmemiş olarak kabul edilmelidir.

## **Yeniden Hesaplama ve Önbelleklenmiş Değerler**

Elektronik tablo dosyaları genellikle bir formül ve onun son hesaplanmış değerini birlikte saklar. Bu nedenle, bir sunum yüklendiğinde ve ilgili grafik verisi değiştirilmediğinde Aspose.Slides, [IChartDataCell.Value](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatacell/value/) aracılığıyla önbelleklenmiş bir değeri okuyabilir.

Giriş hücrelerini veya formüllerini değiştirdikten sonra eski önbelleklenmiş sonuca güvenmeyin. Hesaplanan değerleri okumadan veya bunlara bağlı grafik verilerini kaydetmeden önce [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) çağrısını yapın.

Desteklenen alt kümenin dışındaki formüller için Aspose.Slides, formülü ayrıştırmakta veya bağımlılıklarını belirlemekte başarısız olabilir. Çalışma kitabı değiştirilmişse, önceki önbelleklenmiş değer artık güvenilir kabul edilemez. Bu durumda, desteklenmeyen veri içeren bir hücrenin değerini okumak [CellUnsupportedDataException](https://reference.aspose.com/slides/tr/net/aspose.slides.spreadsheet/cellunsupporteddataexception/) hatasına yol açabilir.

Grafikiniz, Aspose.Slides'ın değerlendirmediği Excel işlevlerine bağımlıysa, bu formülleri destekleyen bir elektronik tablo motoru ile hesaplayıp ortaya çıkan değerleri grafik çalışma kitabına geri yazın. Desteklenmeyen formülleri tahmini değerlerle değiştirmeyin.

## **Formül Hatalarını İşleme**

Ayırmanız gereken iki farklı sorun türü vardır.

Bir formül geçerli olabilir ancak `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` veya `#VALUE!` gibi bir elektronik tablo hata sonucu üretebilir. Bu durumda, hata belirteci bir hücre sonucu olarak `Value` aracılığıyla döndürülebilir.

Bir formül ayrıca ayrıştırma, referans, bağımlılık ya da desteklenen veri seviyesinde başarısız olabilir. Aspose.Slides bu durumlar için elektronik tabloya özgü istisnalar sağlar: [CellInvalidFormulaException](https://reference.aspose.com/slides/tr/net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/tr/net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/tr/net/aspose.slides.spreadsheet/cellcircularreferenceexception/), ve [CellUnsupportedDataException](https://reference.aspose.com/slides/tr/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Formüller şablonlardan veya kullanıcı girişinden geldiğinde, yeniden hesaplama ve değer erişimi etrafında bu istisnaları yakalayın:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Spreadsheet;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);
var workbook = chart.ChartData.ChartDataWorkbook;
var cell = workbook.GetCell(0, "A2");
cell.Formula = "SUM(B2:B5)";

try
{
    workbook.CalculateFormulas();
    Console.WriteLine(cell.Value);
}
catch (CellInvalidFormulaException ex)
{
    Console.Error.WriteLine($"Invalid formula: {ex.Message}");
}
catch (CellInvalidReferenceException ex)
{
    Console.Error.WriteLine($"Invalid cell reference: {ex.Message}");
}
catch (CellCircularReferenceException ex)
{
    Console.Error.WriteLine($"Circular reference: {ex.Message}");
}
catch (CellUnsupportedDataException ex)
{
    Console.Error.WriteLine($"Unsupported spreadsheet data: {ex.Message}");
}
```

## **Pratik Sınırlamalar**

Grafik çalışma sayfalarındaki formül desteği, tam Excel uyumluluğu için değil, tanımlı bir elektronik tablo hesaplama alt kümesi için tasarlanmıştır. Raporlama iş akışı tasarlarken bu kısıtlamaları aklınızda tutun:

- Aspose.Slides'ın formülleri yeniden hesaplaması gerektiğinde yalnızca belgelenmiş sabitleri, operatörleri, referansları ve işlevleri kullanın.
- Formül sonuçlarının bağımlı olduğu hücreleri değiştirdikten sonra yeniden hesaplayın.
- Yüklenmiş sunumlardan gelen önbelleklenmiş değerleri, düzenlemeler sonrasında yeniden hesaplamanın yerini almayan anlık görüntüler olarak değerlendirin.
- Mevcut şablonlardan gelen formülleri, özellikle belgelenmiş listenin dışındaki işlevleri kullandıklarında, hesaplanan değerlerine güvenmeden önce test edin.
- Tam bir elektronik tablo hesaplama motoru gerektiren formüller için, bunları harici olarak hesaplayın ve ardından ortaya çıkan değerlerle grafik çalışma kitabını güncelleyin.

## **SSS**

**`Formula` ile `R1C1Formula` arasındaki fark nedir?**

[Formula](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatacell/formula/) `B2-C2` gibi bir A1‑stil ifadesi depolar. [R1C1Formula](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatacell/r1c1formula/) `RC[-2]-RC[-1]` gibi bir R1C1‑stil ifadesi depolar. Formülleri nasıl oluşturduğunuza ya da kopyaladığınıza en uygun gösterimi kullanın.

**Hesaplamadan sonra hücreyi mi yoksa değerini mi okumam gerekir?**

[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdataworkbook/getcell/) bir `IChartDataCell` döndürür. Hesaplanan sonucu elde etmek için, yeniden hesaplamadan sonra o hücrenin [Value](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatacell/value/) özelliğini okuyun.

**`CalculateFormulas` ne zaman çağrılmalıdır?**

Giriş değerlerini veya formüllerini değiştirdikten ve hesaplanan sonuçlara ihtiyaç duymadan önce [CalculateFormulas](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) çağrısını yapın. Bu, yerleşik değerlendiricinin desteklediği formüllerin değerlerini günceller.

**Aspose.Slides tüm Excel işlevlerini destekliyor mu?**

Hayır. Yerleşik değerlendirici, belgelenmiş bir işlev alt kümesini destekler. Bu alt kümenin dışındaki işlevlerin doğru şekilde yeniden hesaplanacağını varsaymayın. Tam Excel formül uyumluluğu gerekiyorsa, uygun bir elektronik tablo motoru ile hesaplama yapın ve nihai değerleri grafik çalışma kitabına yazın.

**Yüklenmiş bir sunum desteklenmeyen bir formül içeriyorsa ne olur?**

Grafik verisi değişmemişse, çalışma kitabı önceden hesaplanmış bir önbellek değeri içerebilir. İlgili veri değiştirildikten sonra bu önbellek değeri geçerli olmayabilir. Formülü işlenemeyen bir hücreye erişmek [CellUnsupportedDataException](https://reference.aspose.com/slides/tr/net/aspose.slides.spreadsheet/cellunsupporteddataexception/) hatasına yol açabilir.

**Formül hata değerleri .NET istisnalarıyla aynı mı?**

Hayır. `#DIV/0!` gibi bir sonuç, geçerli bir hesaplama tarafından üretilen bir elektronik tablo değeridir. [CellInvalidFormulaException](https://reference.aspose.com/slides/tr/net/aspose.slides.spreadsheet/cellinvalidformulaexception/) gibi istisnalar, formülün normal şekilde işlenemediğini gösterir.

**Bir formül hücresi değiştiğinde grafik otomatik olarak güncellenir mi?**

Bir grafik serisi, çalışma kitabı hücrelerine referans verebilir. Önce çalışma kitabını yeniden hesaplayın, ardından sunumu kaydedin veya render edin. Grafik veri noktaları hesaplanan hücrelere referans veriyorsa, grafik bu güncellenmiş hücre değerlerini kullanır; bu iş akışı için ayrı bir grafik‑yenileme yöntemi gerekli değildir.

**Grafikler harici bir Excel çalışma kitabı kullanabilir mi?**

Evet, grafik verileri, grafik veri API'si aracılığıyla harici bir çalışma kitabı kullanacak şekilde yapılandırılabilir. Ancak bu makalede açıklanan formül hesaplama iş akışı, grafik veri çalışma kitabı ve Aspose.Slides tarafından değerlendirilen formül alt kümesiyle ilgilidir. [CalculateFormulas](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/)'ın harici bir XLSX dosyasındaki rastgele formüllerin tam yeniden hesaplamasını sağlayacağını varsaymayın.

**Başka bir çalışma sayfasına veya çalışma kitabına referans veren formüller kullanabilir miyim?**

Excel‑stil referanslar grafik çalışma kitaplarında bulunabilir, ancak formül değerlendirmesi desteklenen ayrıştırıcı ve işlev kümesiyle sınırlıdır. Çapraz‑sayfa veya harici bir referans kritikse, bu kesin formülü hedef Aspose.Slides sürümünüzde doğrulayın. Geniş Excel referans uyumluluğu gerektiren iş akışları için, çalışma kitabını harici olarak hesaplayın ve çözülen değerleri grafik verisine geri yazın.

**Formül dizeleri `=` ile başlamalı mı?**

Aspose.Slides API örnekleri, `B2-C2` veya `SUM(B2:B5)` gibi ifadeleri başında `=` olmadan atar. Bu biçimi kullanmak, oluşturulan formüllerin belgelenmiş API örnekleriyle tutarlı kalmasını sağlar.