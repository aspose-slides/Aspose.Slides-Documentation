---
title: Aspose.Slides for .NET'te Sunumlarda Grafik Çalışma Sayfası Formüllerini Uygulama
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
- tercih edilen kültür
- kültüre özgü formül
- DBCS
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET grafik çalışma sayfalarında Excel tarzı formülleri uygulayın, değerleri yeniden hesaplayın ve sonuçları PowerPoint grafiklerinde kullanın."
---
## **Genel Bakış**

PowerPoint grafikler genellikle kaynak verilerini gömülü bir çalışma sayfasında saklar. Aspose.Slides for .NET'te bu çalışma sayfasına chart data workbook aracılığıyla erişebilir, girdi değerleri yazabilir, hücrelere formüller atayabilir, desteklenen formülleri hesaplayabilir ve hesaplanmış hücreleri grafik verisi olarak kullanabilirsiniz.

Bu makale tam formül iş akışını açıklar: bir grafik oluşturma, çalışma sayfasını doldurma, A1 tarzı veya R1C1 tarzı formüller atama, yeniden hesaplama, hesaplanmış değerleri okuma, bu hücreleri bir grafik serisine bağlama ve sunumu kaydetme. Ayrıca desteklenen formül sözdizimini, yerleşik fonksiyon alt kümesini, önbellekteki değerleri, desteklenmeyen formülleri ve elektronik tabloya özgü hataları tanımlar.

## **Grafik Çalışma Sayfaları ve Formüller**

Bir grafik çalışma sayfası, bir grafik tarafından kullanılan kategorileri, seri adlarını ve değerleri içerir. PowerPoint'te, chart data editor açarak çalışma sayfasını inceleyebilirsiniz:

![Gömülü çalışma sayfası açık olan PowerPoint grafiği, kategori ve seri verilerini gösteriyor](chart-worksheet-formulas_1.png)

Aspose.Slides'te çalışma sayfası, [chart data workbook](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdataworkbook/) aracılığıyla sunulur. A1 tarzı formüller için [Formula](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatacell/formula/) özelliğini ve R1C1 tarzı formüller için [R1C1Formula](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatacell/r1c1formula/) özelliğini kullanın. Girdi hücrelerini veya formülleri değiştirdikten sonra, desteklenen formülleri yeniden hesaplamak ve ilgili hücre değerlerini güncellemek için [CalculateFormulas](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) çağırın.

Hesaplanmış bir hücre, sonucunu hâlâ [Value](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatacell/value/) özelliğiyle sunar. Bu, kod içinde bir formül sonucunu incelemeniz veya hücreyi bir grafik veri noktası olarak kullanmanız gerektiğinde önemlidir.

## **Bir Grafik Oluşturma ve Çalışma Sayfası Formüllerini Hesaplama**

Aşağıdaki örnek uçtan uca bir iş akışını gösterir. Küme sütun grafiği oluşturur, örnek verileri temizler, çeyrek bazında gelir ve gider değerlerini yazar, formüllerle karı hesaplar, sonuçları okur, hesaplanmış hücreleri grafik değerleri olarak kullanır ve sunumu kaydeder.

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

Grafik veri noktaları `D2:D4` aralığını referans alır, böylece grafik hesaplanmış kar değerlerini kullanır. Bu iş akışında ayrı bir grafik yenileme çağrısı yoktur: önce çalışma kitabını yeniden hesaplayın, ardından hesaplanmış hücrelere işaret eden grafik verilerini kullanın veya kaydedin.

## **A1-Style Formüllerini Kullanma**

A1 gösterimi, sütunları harflerle ve satırları sayılarla tanımlar. A1 tarzı ifadeleri [IChartDataCell.Formula](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatacell/formula/) aracılığıyla atayın.

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

| Referans | Göreceli | Mutlak | Karışık |
|---|---|---|---|
| Hücre | `A2` | `$A$2` | `A$2`, `$A2` |
| Satır | `2:2` | `$2:$2` | — |
| Sütun | `A:A` | `$A:$A` | — |
| Aralık | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Göreceli referanslar, bir formül bir elektronik tablo uygulamasıyla taşındığında veya kopyalandığında değişebilir. Mutlak referanslar her iki koordinatı da sabit tutar, karışık referanslar ise yalnızca bir satırı veya bir sütunu sabitler.

## **R1C1-Style Formüllerini Kullanma**

R1C1 gösterimi, hem satırları hem sütunları sayısal olarak tanımlar. Göreceli referanslar köşeli parantezlerdeki öteleme değerlerini kullanır. Bu sözdizimini [IChartDataCell.R1C1Formula](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatacell/r1c1formula/) aracılığıyla atayın.

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

| Referans | Göreceli | Mutlak | Karışık |
|---|---|---|---|
| Hücre | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Satır | `R[2]` | `R2` | — |
| Sütun | `C[3]` | `C3` | — |
| Aralık | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Örneğin, `D2` hücresinde `RC[-2]`, aynı satırda iki sütun sola (`B2`) olan hücreyi ifade eder.

## **Formül Sabitleri ve Operatörler**

Yerleşik formül değerlendiricisi mantıksal değerleri, sayısal sabitleri, dizeleri, elektronik tablo hata değerlerini, aritmetik operatörleri ve karşılaştırma operatörlerini destekler.

### **Sabitler ve Literaller**

| Tür | Örnekler | Notlar |
|---|---|---|
| Mantıksal | `TRUE`, `FALSE` | `A2=TRUE` gibi mantıksal ifadelerde doğrudan kullanılabilir. |
| Sayısal | `1`, `0.5`, `.3`, `1E-2` | Yaygın ve bilimsel gösterimler desteklenir. |
| Dize | `"abc"`, `"2/3/2020 12:00"` | Metin sabitleri formül içinde çift tırnak içinde yer alır. |
| Hata sonucu | `#DIV/0!`, `#N/A`, `#REF!` | Geçerli bir formül, normal bir sonuç yerine bir elektronik tablo hata değeri olarak değerlendirilebilir. |

Bu örnek çeşitli sabit türlerini kullanır:

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

var logicalValue = workbook.GetCell(0, "B2").Value; // Yanlış
var numericValue = workbook.GetCell(0, "C2").Value; // 1.5
var scientificValue = workbook.GetCell(0, "D2").Value; // 0.003
var stringValue = workbook.GetCell(0, "E2").Value; // abc
var errorValue = workbook.GetCell(0, "F2").Value; // #DIV/0!
```

### **Aritmetik Operatörler**

| Operatör | Anlam | Örnek |
|---|---|---|
| `+` | Toplama veya tekli artı | `2+3` |
| `-` | Çıkarma veya negatifleme | `2-3`, `-3` |
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
| `>=` | Büyük ya da eşittir | `A2>=3` |
| `<` | Küçük | `A2<3` |
| `<=` | Küçük ya da eşittir | `A2<=3` |

## **Desteklenen Ön Tanımlı Fonksiyonlar**

Aspose.Slides, grafik çalışma sayfaları için yerleşik bir formül değerlendiricisi içerir, ancak bu tam bir Excel hesaplama motoru değildir. Belgelenen fonksiyon kümesi aşağıdaki fonksiyonlarla sınırlıdır. Rastgele bir Excel fonksiyonunun [CalculateFormulas](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) ile yeniden hesaplanabileceğini varsamamalısınız.

| Fonksiyon | Amaç ya da desteklenen form | Örnek |
|---|---|---|
| `ABS` | Mutlak değer | `ABS(A2)` |
| `AVERAGE` | Aritmetik ortalama | `AVERAGE(B2:B5)` |
| `CEILING` | Bir sayıyı yukarı doğru bir katına yuvarlar | `CEILING(A2,5)` |
| `CHOOSE` | İndexe göre bir değer seçer | `CHOOSE(A2,"Low","High")` |
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

## **Tercih Edilen Kültürle Formülleri Hesaplama**

Bazı grafik çalışma kitabı fonksiyonları metni kültüre özgü kurallara göre yorumlar. Bu, çift bayt karakter seti (DBCS) kullanılan diller için tasarlanmış fonksiyonlar söz konusu olduğunda özellikle önemlidir. Bu tür formülleri doğru hesaplamak için [LoadOptions](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/) oluşturun, [ISpreadsheetOptions.PreferredCulture](https://reference.aspose.com/slides/tr/net/aspose.slides/ispreadsheetoptions/preferredculture/)’ı [LoadOptions.SpreadsheetOptions](https://reference.aspose.com/slides/tr/net/aspose.slides/loadoptions/spreadsheetoptions/) aracılığıyla ayarlayın ve ardından sunumu yükleyin.

Aşağıdaki örnek Japon kültürünü seçer, yapılandırılmış yükleme seçenekleriyle bir sunumu açar ve her grafik çalışma kitabı için [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) metodunu çağırır:

```csharp
using System.Globalization;
using Aspose.Slides;
using Aspose.Slides.Charts;

var loadOptions = new LoadOptions
{
    SpreadsheetOptions = new SpreadsheetOptions
    {
        PreferredCulture = CultureInfo.GetCultureInfo("ja-JP")
    }
};

using var presentation = new Presentation("presentation.pptx", loadOptions);

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IChart chart)
        {
            chart.ChartData.ChartDataWorkbook.CalculateFormulas();
        }
    }
}
```

Tercih edilen kültür, sunum yükleme yapılandırmasının bir parçasıdır; bu nedenle [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) örneğini oluşturmadan önce belirtin. Çalışma kitabı formüllerinin beklediği kültürü kullanın; örneğin, Japon DBCS hesaplama kurallarına uyması gereken formüller için `ja-JP` kullanın.

## **Yeniden Hesaplama ve Önbellekteki Değerler**

Elektronik tablo dosyaları genellikle bir formül ve onun son hesaplanmış değerini saklar. Bu nedenle Aspose.Slides, bir sunum yüklendiğinde ve ilgili grafik verileri değişmediğinde [IChartDataCell.Value](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatacell/value/) üzerinden önbellekteki bir değeri okuyabilir.

Girdi hücrelerini veya formülleri değiştirdikten sonra eski önbellekteki sonuca güvenmeyin. Hesaplanmış değerleri okumadan veya bunlara bağlı grafik verilerini kaydetmeden önce [IChartDataWorkbook.CalculateFormulas](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) çağırın.

Desteklenen alt kümenin dışındaki formüller için Aspose.Slides formülü ayrıştıramayabilir veya bağımlılıklarını belirleyemeyebilir. Çalışma kitabı değiştirilmişse, önceki önbellekteki değer artık güvenilir kabul edilemez. Bu durumda, desteklenmeyen veri içeren bir hücrenin değerini okumak [CellUnsupportedDataException](https://reference.aspose.com/slides/tr/net/aspose.slides.spreadsheet/cellunsupporteddataexception/) hatasına yol açabilir.

Grafiğiniz Aspose.Slides'in değerlendirmediği Excel fonksiyonlarına bağımlıysa, bu formülleri destekleyen bir elektronik tablo motoruyla hesaplayın ve ortaya çıkan değerleri grafik çalışma kitabına geri yazın. Desteklenmeyen formülleri tahmini değerlerle değiştirmeyin.

## **Formül Hatalarını Ele Alma**

Ayırt edilmesi gereken iki farklı sorun türü vardır.

Bir formül geçerli olabilir ancak `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` veya `#VALUE!` gibi bir elektronik tablo hata sonucu üretebilir. Bu durumda, hata belirteci bir hücre sonucudur ve `Value` aracılığıyla döndürülebilir.

Bir formül ayrıca ayrıştırma, referans, bağımlılık veya desteklenen veri düzeyinde başarısız olabilir. Aspose.Slides bu durumlar için elektronik tabloya özgü istisnalar sağlar: [CellInvalidFormulaException](https://reference.aspose.com/slides/tr/net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/tr/net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/tr/net/aspose.slides.spreadsheet/cellcircularreferenceexception/), ve [CellUnsupportedDataException](https://reference.aspose.com/slides/tr/net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Formüller şablonlardan veya kullanıcı girdisinden geldiğinde, bu istisnaları yeniden hesaplama ve değer erişimi etrafında yakalayın:

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

Grafik çalışma sayfalarındaki formül desteği, tam Excel uyumluluğu değil, tanımlı bir elektronik tablo hesaplama alt kümesi için tasarlanmıştır. Raporlama iş akışı tasarlarken bu kısıtlamaları aklınızda tutun:

- Aspose.Slides'in formülleri yeniden hesaplamasını istediğinizde yalnızca belgelenen sabitleri, operatörleri, referansları ve fonksiyonları kullanın.  
- Formül sonuçlarının bağlı olduğu hücreleri değiştirdikten sonra yeniden hesaplayın.  
- Yüklenmiş sunumlardan gelen önbellekteki değerleri anlık görüntü olarak değerlendirin, düzenlemeler sonrası yeniden hesaplamanın yerine geçmemelidir.  
- Mevcut şablonlardan gelen formülleri, özellikle belgelenen liste dışı fonksiyonlar içeriyorsa, hesaplanan değerlerine güvenmeden önce test edin.  
- Tam bir elektronik tablo hesaplama motoru gerektiren formüller için, bunları dışarıda hesaplayın ve ardından ortaya çıkan değerlerle grafik çalışma kitabını güncelleyin.

## **SSS**

**`Formula` ile `R1C1Formula` arasındaki fark nedir?**

[Formula](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatacell/formula/) A1 tarzı bir ifade (örneğin `B2-C2`) saklar. [R1C1Formula](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatacell/r1c1formula/) R1C1 tarzı bir ifade (örneğin `RC[-2]-RC[-1]`) saklar. Formülleri nasıl ürettiğinize veya kopyaladığınıza en uygun gösterimi kullanın.

**Hesaplama sonrası hücreyi mi yoksa değerini mi okumam gerekir?**

[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdataworkbook/getcell/) bir `IChartDataCell` döndürür. Hesaplanmış sonucu elde etmek için, yeniden hesaplamadan sonra o hücrenin [Value](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdatacell/value/) özelliğini okuyun.

**`CalculateFormulas` ne zaman çağrılmalı?**

Girdi değerlerini veya formülleri değiştirdikten ve hesaplanan sonuçlara bağımlı olmadan önce [CalculateFormulas](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/) çağırın. Bu, yerleşik değerlendiricinin desteklediği formüllerin değerlerini günceller.

**Aspose.Slides tüm Excel fonksiyonlarını destekliyor mu?**

Hayır. Yerleşik değerlendirici, belgelenen bir fonksiyon alt kümesini destekler. Bu alt kümenin dışındaki fonksiyonların doğru şekilde yeniden hesaplanacağını varsamamalısınız. Tam Excel formül uyumluluğu gerekiyorsa, uygun bir elektronik tablo motoruyla hesaplama yapın ve son değerleri grafik çalışma kitabına yazın.

**Yüklenmiş bir sunum desteklenmeyen bir formül içeriyorsa ne olur?**

Grafik verileri değişmemişse, çalışma kitabı hâlâ önceden hesaplanmış bir önbellek değeri içerebilir. İlgili veri değiştirildiğinde bu önbellek değeri artık geçerli olmayabilir. Formülü işlenemeyen bir hücreye erişmek [CellUnsupportedDataException](https://reference.aspose.com/slides/tr/net/aspose.slides.spreadsheet/cellunsupporteddataexception/) hatasına yol açabilir.

**Formül hata değerleri .NET istisnalarıyla aynı mı?**

Hayır. `#DIV/0!` gibi bir sonuç, geçerli bir hesaplamanın ürettiği bir elektronik tablo değeridir. [CellInvalidFormulaException](https://reference.aspose.com/slides/tr/net/aspose.slides.spreadsheet/cellinvalidformulaexception/) gibi istisnalar, formülün normal olarak işlenemediğini gösterir.

**Bir formül hücresi değiştiğinde grafik otomatik olarak güncellenir mi?**

Bir grafik serisi, çalışma kitabı hücrelerine referans verebilir. Önce çalışma kitabını yeniden hesaplayın, ardından sunumu kaydedin veya oluşturun. Grafik veri noktaları hesaplanmış hücrelere referans veriyorsa, grafik bu güncellenmiş hücre değerlerini kullanır; bu iş akışı için ayrı bir grafik yenileme yöntemi gerekmez.

**Grafikler harici bir Excel çalışma kitabını kullanabilir mi?**

Evet, grafik verileri, grafik veri API'si aracılığıyla harici bir çalışma kitabını kullanacak şekilde yapılandırılabilir. Ancak bu makalede açıklanan formül hesaplama iş akışı, grafik veri çalışma kitabı ve Aspose.Slides tarafından değerlendirilen formül alt kümesiyle ilgilidir. [CalculateFormulas](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartdataworkbook/calculateformulas/)'un harici bir XLSX dosyasındaki rastgele formüllerin tam yeniden hesaplamasını sağladığını varsamamalısınız.

**Başka bir çalışma sayfasına veya çalışma kitabına referans veren formüller kullanabilir miyim?**

Excel tarzı referanslar grafik çalışma kitaplarında bulunabilir, ancak formül değerlendirmesi desteklenen ayrıştırıcı ve fonksiyon setiyle sınırlıdır. Çapraz sayfa veya dış referans kritikse, hedef Aspose.Slides sürümünüzle bu formülü doğrulayın. Geniş Excel referans uyumluluğu gerektiren iş akışları için, çalışma kitabını dışarıda hesaplayın ve çözülen değerleri grafik verisine geri yazın.

**Formül dizgileri `=` ile başlamalı mı?**

Aspose.Slides API örnekleri, `B2-C2` veya `SUM(B2:B5)` gibi ifadeleri başında `=` olmadan atar. Bu biçimi kullanmak, oluşturulan formüllerin belgelenen API örnekleriyle tutarlı olmasını sağlar.