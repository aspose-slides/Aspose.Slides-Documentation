---
title: Python ile Sunumlarda Grafik Çalışma Sayfası Formüllerini Uygulama
linktitle: Çalışma Sayfası Formülleri
type: docs
weight: 70
url: /tr/python-net/chart-worksheet-formulas/
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
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET grafik çalışma sayfalarında Excel benzeri formülleri uygulayın, değerleri yeniden hesaplayın ve sonuçları PowerPoint grafiklerinde kullanın."
---
## **Genel Bakış**

PowerPoint grafiklerinin kaynak verileri genellikle gömülü bir çalışma sayfasında saklanır. Aspose.Slides for Python via .NET'te bu çalışma sayfasına grafik veri çalışma kitabı aracılığıyla erişebilir, giriş değerlerini yazabilir, hücrelere formüller atayabilir, desteklenen formülleri hesaplayabilir ve hesaplanmış hücreleri grafik verisi olarak kullanabilirsiniz.

Bu makale tam bir formül iş akışını açıklar: bir grafik oluşturma, çalışma sayfasını doldurma, A1‑stili veya R1C1‑stili formüller atama, yeniden hesaplatma, hesaplanmış değerleri okuma, bu hücreleri bir grafik serisine bağlama ve sunumu kaydetme. Ayrıca desteklenen formül sözdizimini, yerleşik işlev alt kümesini, önbelleğe alınmış değerleri, desteklenmeyen formülleri ve elektronik tabloya özgü hataları kapsar.

## **Grafik Çalışma Sayfaları ve Formüller**

Bir grafik çalışma sayfası, bir grafik tarafından kullanılan kategorileri, seri adlarını ve değerleri içerir. PowerPoint'te grafik veri düzenleyicisini açarak çalışma sayfasını inceleyebilirsiniz:

![PowerPoint grafik çalışma sayfası açık, kategori ve seri verileri gösteriliyor](chart-worksheet-formulas_1.png)

Aspose.Slides'te çalışma sayfası, [chart data workbook](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/ichartdataworkbook/) aracılığıyla sunulur. A1‑stili formüller için [formula](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/ichartdatacell/formula/) özelliğini, R1C1‑stili formüller için [r1c1_formula](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) özelliğini kullanın. Giriş hücrelerini veya formülleri değiştirdikten sonra, desteklenen formülleri yeniden hesaplatmak ve ilgili hücre değerlerini güncellemek için [calculate_formulas](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) metodunu çağırın.

Hesaplanmış bir hücre, sonucunu hâlâ [value](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/ichartdatacell/value/) özelliğiyle sunar. Bu, kod içinde bir formül sonucunu incelemeniz veya hücreyi bir grafik veri noktası olarak kullanmanız gerektiğinde önemlidir.

## **Bir Grafik Oluşturma ve Çalışma Sayfası Formüllerini Hesaplama**

Aşağıdaki örnek uçtan uca bir iş akışını gösterir. Kümeleme sütun grafiği oluşturur, örnek verileri temizler, çeyrek bazında gelir ve gider değerlerini yazar, formüllerle karı hesaplar, sonuçları okur, hesaplanmış hücreleri grafik değerleri olarak kullanır ve sunumu kaydeder.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 350)
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    workbook.clear(worksheet_index)

    category1 = workbook.get_cell(worksheet_index, "A2", "Q1")
    category2 = workbook.get_cell(worksheet_index, "A3", "Q2")
    category3 = workbook.get_cell(worksheet_index, "A4", "Q3")

    workbook.get_cell(worksheet_index, "B1", "Revenue")
    workbook.get_cell(worksheet_index, "C1", "Expenses")
    workbook.get_cell(worksheet_index, "D1", "Profit")

    workbook.get_cell(worksheet_index, "B2").value = 120.0
    workbook.get_cell(worksheet_index, "C2").value = 80.0
    workbook.get_cell(worksheet_index, "B3").value = 150.0
    workbook.get_cell(worksheet_index, "C3").value = 95.0
    workbook.get_cell(worksheet_index, "B4").value = 135.0
    workbook.get_cell(worksheet_index, "C4").value = 110.0

    profit1 = workbook.get_cell(worksheet_index, "D2")
    profit2 = workbook.get_cell(worksheet_index, "D3")
    profit3 = workbook.get_cell(worksheet_index, "D4")

    profit1.formula = "B2-C2"
    profit2.formula = "B3-C3"
    profit3.formula = "B4-C4"

    workbook.calculate_formulas()

    q1_profit = profit1.value  # 40
    q2_profit = profit2.value  # 55
    q3_profit = profit3.value  # 25

    print(f"Q1 profit: {q1_profit}")
    print(f"Q2 profit: {q2_profit}")
    print(f"Q3 profit: {q3_profit}")

    chart.chart_data.categories.add(category1)
    chart.chart_data.categories.add(category2)
    chart.chart_data.categories.add(category3)

    profit_series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, "D1"), chart.type)
    profit_series.data_points.add_data_point_for_bar_series(profit1)
    profit_series.data_points.add_data_point_for_bar_series(profit2)
    profit_series.data_points.add_data_point_for_bar_series(profit3)
    profit_series.labels.default_data_label_format.show_value = True

    presentation.save("chart-formulas.pptx", slides.export.SaveFormat.PPTX)
```

Grafik veri noktaları `D2:D4` aralığını referans alır, bu yüzden grafik hesaplanmış kar değerlerini kullanır. Bu iş akışında ayrı bir grafik‑yenileme çağrısı yoktur: önce çalışma kitabını yeniden hesaplatın, ardından hesaplanmış hücrelere işaret eden grafik verisini kullanın veya kaydedin.

## **A1‑Stili Formüller Kullanma**

A1 gösterimi sütunları harf, satırları sayı ile tanımlar. A1‑stili ifadeleri [IChartDataCell.formula](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/ichartdatacell/formula/) aracılığıyla atayın.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "C3").value = 10
    workbook.get_cell(0, "F2").value = 2
    workbook.get_cell(0, "G2").value = 3
    workbook.get_cell(0, "H2").value = 4

    cell = workbook.get_cell(0, "A2")
    cell.formula = "C3+SUM(F2:H2)"

    workbook.calculate_formulas()

    value = cell.value  # 19
```

Yaygın A1 referans biçimleri şunlardır:

| Referans | Göreli | Mutlak | Karışık |
|---|---|---|---|
| Hücre | `A2` | `$A$2` | `A$2`, `$A2` |
| Satır | `2:2` | `$2:$2` | — |
| Sütun | `A:A` | `$A:$A` | — |
| Aralık | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Göreli referanslar, bir formül bir elektronik tablo uygulamasıyla taşındığında veya kopyalandığında değişebilir. Mutlak referanslar her iki koordinatı da sabit tutar, karışık referanslar ise yalnızca satırı ya da sütunu sabitler.

## **R1C1‑Stili Formüller Kullanma**

R1C1 gösterimi hem satırları hem sütunları sayısal olarak tanımlar. Göreli referanslar köşeli parantez içindeki öteleme değerlerini kullanır. Bu sözdizimini [IChartDataCell.r1c1_formula](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) aracılığıyla atayın.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "B2").value = 12
    workbook.get_cell(0, "C2").value = 5

    cell = workbook.get_cell(0, "D2")
    cell.r1c1_formula = "RC[-2]-RC[-1]"

    workbook.calculate_formulas()

    value = cell.value  # 7
```

Yaygın R1C1 referans biçimleri şunlardır:

| Referans | Göreli | Mutlak | Karışık |
|---|---|---|---|
| Hücre | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Satır | `R[2]` | `R2` | — |
| Sütun | `C[3]` | `C3` | — |
| Aralık | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Örneğin, `D2` hücresinde `RC[-2]` aynı satırda iki sütun sola olan hücreyi (`B2`) ifade eder.

## **Formül Sabitleri ve Operatörleri**

Yerleşik formül değerlendirme motoru, mantıksal değerleri, sayısal sabitleri, metinleri, elektronik tablo hata değerlerini, aritmetik operatörleri ve karşılaştırma operatörlerini destekler.

### **Sabitler ve Değerler**

| Tür | Örnekler | Notlar |
|---|---|---|
| Mantıksal | `TRUE`, `FALSE` | `A2=TRUE` gibi mantıksal ifadelerde doğrudan kullanılabilir. |
| Sayısal | `1`, `0.5`, `.3`, `1E-2` | Kesirli ve bilimsel gösterimler desteklenir. |
| Metin | `"abc"`, `"2/3/2020 12:00"` | Metin sabitleri formül içinde çift tırnak içinde yazılır. |
| Hata sonucu | `#DIV/0!`, `#N/A`, `#REF!` | Geçerli bir formül, normal bir sonuç yerine elektronik tablo hata değeri döndürebilir. |

Bu örnek birkaç sabit türünü kullanır:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook

    workbook.get_cell(0, "A2").value = False
    workbook.get_cell(0, "B2").formula = "A2=TRUE"
    workbook.get_cell(0, "C2").formula = "1+0.5"
    workbook.get_cell(0, "D2").formula = ".3*1E-2"
    workbook.get_cell(0, "E2").formula = "\"abc\""
    workbook.get_cell(0, "F2").formula = "2/0"

    workbook.calculate_formulas()

    logical_value = workbook.get_cell(0, "B2").value  # Yanlış
    numeric_value = workbook.get_cell(0, "C2").value  # 1.5
    scientific_value = workbook.get_cell(0, "D2").value  # 0.003
    string_value = workbook.get_cell(0, "E2").value  # abc
    error_value = workbook.get_cell(0, "F2").value  # #DIV/0!
```

### **Aritmetik Operatörler**

| Operatör | Anlam | Örnek |
|---|---|---|
| `+` | Toplama veya tek artı | `2+3` |
| `-` | Çıkarma veya eksi | `2-3`, `-3` |
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

## **Desteklenen Ön Tanımlı Fonksiyonlar**

Aspose.Slides, grafik çalışma sayfaları için yerleşik bir formül değerlendirici içerir, ancak bu tam bir Excel hesaplama motoru değildir. Belgelendirilmiş fonksiyon kümesi aşağıdaki ile sınırlıdır. [calculate_formulas](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) ile rastgele bir Excel işlevinin yeniden hesaplanacağını varsaymayın.

| Fonksiyon | Amaç veya desteklenen biçim | Örnek |
|---|---|---|
| `ABS` | Mutlak değer | `ABS(A2)` |
| `AVERAGE` | Aritmetik ortalama | `AVERAGE(B2:B5)` |
| `CEILING` | Sayıyı bir katına yukarı yuvarla | `CEILING(A2,5)` |
| `CHOOSE` | İndekse göre değer seç | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Metin değerlerini birleştir | `CONCAT(A2,B2)` |
| `CONCATENATE` | Metin değerlerini birleştir | `CONCATENATE(A2," ",B2)` |
| `DATE` | 1900 tarih sistemini kullanarak tarih değeri oluştur | `DATE(2026,8,19)` |
| `DAYS` | İki tarih arasındaki gün sayısını döndür | `DAYS(B2,A2)` |
| `FIND` | Bir metin içinde başka bir metin bul | `FIND("-",A2)` |
| `FINDB` | Bayt‑temelli metin arama | `FINDB("a",A2)` |
| `IF` | Koşullu sonuç | `IF(A2>0,A2,0)` |
| `INDEX` | Referans biçimi | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektör biçimi | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektör biçimi | `MATCH(A2,B2:B5,0)` |
| `MAX` | Azami değer | `MAX(B2:B5)` |
| `SUM` | Toplam | `SUM(B2:B5)` |
| `VLOOKUP` | Dikey arama | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Tablodaki sınırlamalar önemlidir: `INDEX` referans biçiminde, `LOOKUP` ve `MATCH` vektör biçiminde belgelenmiştir. `DATE` 1900 tarih sistemini kullanır. Burada listelenmeyen özellik ve fonksiyonlar, Aspose.Slides formül değerlendiricisi tarafından desteklenmediği varsayılmalıdır.

## **Tercih Edilen Kültürle Formülleri Hesaplama**

Bazı grafik çalışma kitabı fonksiyonları metni kültüre özgü kurallara göre yorumlar. Bu, çift bayt karakter seti (DBCS) kullanan diller için özellikle önemlidir. Bu tür formülleri doğru şekilde hesaplamak için [LoadOptions](https://reference.aspose.com/slides/tr/python-net/aspose.slides/loadoptions/) oluşturun, [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/tr/python-net/aspose.slides/loadoptions/spreadsheet_options/) aracılığıyla [SpreadsheetOptions.preferred_culture](https://reference.aspose.com/slides/tr/python-net/aspose.slides/spreadsheetoptions/) ayarlayın ve ardından sunumu yükleyin.

Aşağıdaki örnek Japon kültürünü seçer, yapılandırılmış yükleme seçenekleriyle bir sunum açar ve her grafik çalışma kitabı için [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) metodunu çağırır:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

load_options = slides.LoadOptions()
load_options.spreadsheet_options.preferred_culture = "ja-JP"

with slides.Presentation("presentation.pptx", load_options) as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, charts.Chart):
                shape.chart_data.chart_data_workbook.calculate_formulas()
```

Tercih edilen kültür, sunum yükleme yapılandırmasının bir parçasıdır; bu yüzden [Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) örneğini oluşturmadan önce belirtilmelidir. Çalışma kitabı formüllerinin beklediği kültürü kullanın; örneğin Japon DBCS hesaplama kurallarına uyması gereken formüller için `ja-JP` kullanın.

## **Yeniden Hesaplama ve Önbelleğe Alınmış Değerler**

Elektronik tablo dosyaları genellikle bir formül ve onun son hesaplanmış değerini birlikte saklar. Aspose.Slides, bir sunum yüklendiğinde ve ilgili grafik verileri değiştirilmediğinde [IChartDataCell.value](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/ichartdatacell/value/) üzerinden önbelleğe alınmış bir değeri okuyabilir.

Giriş hücrelerini veya formülleri değiştirdikten sonra eski bir önbellek sonucuna güvenmeyin. Hesaplanmış değerleri okumadan veya onlara dayalı grafik verisini kaydetmeden önce [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) metodunu çağırın.

Desteklenen kümenin dışındaki formüller için Aspose.Slides formülü ayrıştıramayabilir veya bağımlılıklarını belirleyemeyebilir. Çalışma kitabı değiştirilmişse, önceki önbelleğe alınmış değer artık güvenilir kabul edilmez. Bu durumda, desteklenmeyen veri içeren bir hücrenin değerini okumak [CellUnsupportedDataException](https://reference.aspose.com/slides/tr/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/) hatasına yol açabilir.

Grafiğiniz Aspose.Slides tarafından değerlendirilmemiş Excel işlevlerine bağımlıysa, bu formülleri destekleyen bir elektronik tablo motoru ile hesaplayın ve ortaya çıkan değerleri grafik çalışma kitabına geri yazın. Desteklenmeyen formülleri tahmini değerlerle değiştirmeyin.

## **Formül Hatalarını İşleme**

İki farklı sorun türü vardır.

Bir formül geçerli olabilir ancak `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` veya `#VALUE!` gibi bir elektronik tablo hata sonucu üretebilir. Bu durumda hata belirteci bir hücre sonucu olup `value` aracılığıyla geri döndürülür.

Bir formül ayrıca ayrıştırma, referans, bağımlılık veya desteklenen veri düzeyinde başarısız olabilir. Aspose.Slides bu durumlar için elektronik tabloya özgü istisnalar sağlar: [CellInvalidFormulaException](https://reference.aspose.com/slides/tr/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/tr/python-net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/tr/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/) ve [CellUnsupportedDataException](https://reference.aspose.com/slides/tr/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Formüller şablonlardan veya kullanıcı girişlerinden geldiğinde, yeniden hesaplama ve değer erişimi etrafında bu istisnaları yakalayın:

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.slides.spreadsheet as spreadsheet

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    cell = workbook.get_cell(0, "A2")
    cell.formula = "SUM(B2:B5)"

    try:
        workbook.calculate_formulas()
        print(cell.value)
    except spreadsheet.CellInvalidFormulaException as ex:
        print(f"Invalid formula: {ex}")
    except spreadsheet.CellInvalidReferenceException as ex:
        print(f"Invalid cell reference: {ex}")
    except spreadsheet.CellCircularReferenceException as ex:
        print(f"Circular reference: {ex}")
    except spreadsheet.CellUnsupportedDataException as ex:
        print(f"Unsupported spreadsheet data: {ex}")
```

## **Pratik Sınırlamalar**

Grafik çalışma sayfalarındaki formül desteği, tam Excel uyumluluğu değil, tanımlı bir elektronik tablo hesaplama alt kümesi içindir. Raporlama iş akışı tasarlarken şu sınırlamaları aklınızda bulundurun:

- Aspose.Slides'ın formülleri yeniden hesaplamasını istediğinizde yalnızca belgelenen sabitleri, operatörleri, referansları ve işlevleri kullanın.
- Formül sonuçlarının bağımlı olduğu hücreleri değiştirdikten sonra yeniden hesaplayın.
- Yüklenen sunumlardan gelen önbelleğe alınmış değerleri anlık bir anlık görüntü olarak değerlendirin; düzenlemelerden sonra yeniden hesaplamanın yerini almaz.
- Mevcut şablonlardaki formülleri, belgelenen fonksiyon listesi dışındaki işlevler içeriyorsa, hesaplanmış değerlerine güvenmeden önce test edin.
- Tam bir elektronik tablo hesaplama motoru gerektiren formüller için dışarıda hesaplayın ve ardından grafik çalışma kitabını elde edilen değerlerle güncelleyin.

## **SSS**

**`formula` ve `r1c1_formula` arasındaki fark nedir?**

[formula](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/ichartdatacell/formula/) `B2-C2` gibi A1‑stili bir ifadeyi saklar. [r1c1_formula](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) `RC[-2]-RC[-1]` gibi R1C1‑stili bir ifadeyi saklar. Formülleri nasıl ürettiğinize veya kopyaladığınıza bağlı olarak uygun gösterimi kullanın.

**Hesaplamadan sonra hücreyi mi yoksa değerini mi okumam gerekir?**

[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) bir `IChartDataCell` döndürür. Hesaplanmış sonucu almak için yeniden hesaplamadan sonra o hücrenin [value](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/ichartdatacell/value/) özelliğini okuyun.

**`calculate_formulas` ne zaman çağrılmalı?**

Giriş değerlerini veya formülleri değiştirdikten ve hesaplanmış sonuçlara ihtiyaç duymadan önce [calculate_formulas](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) metodunu çağırın. Bu, yerleşik değerlendiricinin desteklediği formüllerin değerlerini günceller.

**Aspose.Slides her Excel işlevini destekliyor mu?**

Hayır. Yerleşik değerlendirici belgelenen bir işlev alt kümesini destekler. Bu alt kümenin dışındaki işlevlerin doğru şekilde yeniden hesaplanacağını varsaymayın. Tam Excel formül uyumluluğu gerekiyorsa, hesabı uygun bir elektronik tablo motoru ile yapın ve son değerleri grafik çalışma kitabına yazın.

**Yüklenen bir sunumda desteklenmeyen bir formül varsa ne olur?**

Grafik verisi değişmemişse, çalışma kitabı hâlâ daha önce hesaplanmış bir önbellek değerine sahip olabilir. İlgili veri değiştirildiğinde bu önbellek değeri geçersiz olabilir. Formülü işlenemeyen bir hücreye erişmek, [CellUnsupportedDataException](https://reference.aspose.com/slides/tr/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/) hatasına yol açabilir.

**Formül hata değerleri Python istisnalarıyla aynı mı?**

Hayır. `#DIV/0!` gibi bir sonuç, geçerli bir hesaplamanın ürettiği bir elektronik tablo değeridir. [CellInvalidFormulaException](https://reference.aspose.com/slides/tr/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/) veya [CellCircularReferenceException](https://reference.aspose.com/slides/tr/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/) gibi istisnalar ise formülün normal şekilde işlenemediğini gösterir.

**Bir formül hücresi değiştiğinde grafik otomatik olarak güncellenir mi?**

Bir grafik serisi çalışma kitabı hücrelerine referans verebilir. Önce çalışma kitabını yeniden hesaplayın, ardından sunumu kaydedin veya render edin. Grafik veri noktaları hesaplanmış hücrelere işaret ediyorsa, grafik bu güncellenmiş hücre değerlerini kullanır; bu iş akışı için ayrı bir grafik‑yenileme yöntemi gerekmez.

**Grafikler harici bir Excel çalışma kitabı kullanabilir mi?**

Evet, grafik verisi harici bir çalışma kitabı kullanacak şekilde yapılandırılabilir. Ancak bu makalede açıklanan formül hesaplama iş akışı, grafik veri çalışma kitabı ve Aspose.Slides tarafından değerlendirilen formül alt kümesiyle sınırlıdır. [calculate_formulas](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) metodunun dış XLSX dosyalarındaki rastgele formüllerin tam yeniden hesaplamasını sağladığını varsaymayın.

**Başka bir çalışma sayfasına veya çalışma kitabına referans veren formüller kullanabilir miyim?**

Excel‑stili referanslar grafik çalışma kitaplarında bulunabilir, ancak formül değerlendirme, desteklenen ayrıştırıcı ve işlev kümesiyle sınırlıdır. Çapraz‑sayfa veya dış referans kritikse, hedef Aspose.Slides sürümünüzle tam formülü doğrulayın. Geniş Excel referans uyumluluğu gerektiren iş akışları için çalışma kitabını dışarıda hesaplayın ve çözülen değerleri grafik verisine geri yazın.

**Formül dizeleri `=` ile başlamalı mı?**

Aspose.Slides API örnekleri, `B2-C2` veya `SUM(B2:B5)` gibi başında `=` olmadan ifadeler atar. Bu biçimi kullanmak, oluşturulan formüllerin belgelenen API örnekleriyle tutarlı olmasını sağlar.