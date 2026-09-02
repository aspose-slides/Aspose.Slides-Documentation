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
description: "Aspose.Slides for Python via .NET grafik çalışma sayfalarında Excel tarzı formülleri uygulayın, değerleri yeniden hesaplayın ve sonuçları PowerPoint grafiklerinde kullanın."
---
## **Genel Bakış**

PowerPoint grafikler genellikle kaynak verilerini gömülü bir çalışma sayfasında saklar. Aspose.Slides for Python via .NET içinde bu çalışma sayfasına grafik veri çalışma kitabı üzerinden erişebilir, giriş değerleri yazabilir, hücrelere formül atayabilir, desteklenen formülleri hesaplayabilir ve hesaplanan hücreleri grafik verisi olarak kullanabilirsiniz.

Bu makale tam formül iş akışını açıklar: bir grafik oluşturma, çalışma sayfasını doldurma, A1‑stili veya R1C1‑stili formüller atama, yeniden hesaplama, hesaplanan değerleri okuma, bu hücreleri bir grafik serisine bağlama ve sunumu kaydetme. Ayrıca desteklenen formül sözdizimi, yerleşik işlev alt kümesi, önbelleğe alınmış değerler, desteklenmeyen formüller ve elektronik tabloya özgü hatalar da açıklanmıştır.

## **Grafik Çalışma Sayfaları ve Formüller**

Bir grafik çalışma sayfası, bir grafik tarafından kullanılan kategorileri, seri adlarını ve değerleri içerir. PowerPoint'te çalışma sayfasını grafik veri düzenleyicisini açarak inceleyebilirsiniz:

![PowerPoint grafiği gömülü çalışma sayfası açık, kategori ve seri verilerini gösteriyor](chart-worksheet-formulas_1.png)

Aspose.Slides içinde çalışma sayfası, [chart data workbook](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/ichartdataworkbook/) aracılığıyla ortaya çıkar. A1‑stili formüller için [formula](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/ichartdatacell/formula/) özelliğini ve R1C1‑stili formüller için [r1c1_formula](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) özelliğini kullanın. Giriş hücrelerini veya formülleri değiştirdikten sonra, desteklenen formülleri yeniden hesaplamak ve ilgili hücre değerlerini güncellemek için [calculate_formulas](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) çağırın.

Hesaplanmış bir hücre, sonucunu hâlâ [value](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/ichartdatacell/value/) özelliği aracılığıyla sunar. Bu, kod içinde bir formül sonucunu denetlemeniz veya hücreyi bir grafik veri noktası olarak kullanmanız gerektiğinde önemlidir.

## **Bir Grafik Oluşturma ve Çalışma Sayfası Formüllerini Hesaplama**

Aşağıdaki örnek uçtan uca bir iş akışını gösterir. Bir kümeleşik sütun grafik oluşturur, örnek verileri temizler, çeyrek gelir ve gider değerlerini yazar, formüllerle karı hesaplar, sonuçları okur, hesaplanan hücreleri grafik değerleri olarak kullanır ve sunumu kaydeder.

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

Grafik veri noktaları `D2:D4` aralığını referans alır, bu nedenle grafik hesaplanan kar değerlerini kullanır. Bu iş akışında ayrı bir grafik‑yenileme çağrısı yoktur: önce çalışma kitabını yeniden hesaplayın, ardından hesaplanan hücrelere işaret eden grafik verisini kullanın veya kaydedin.

## **A1‑Stili Formüller Kullanma**

A1 gösterimi, sütunları harflerle, satırları sayılarla tanımlar. A1‑stili ifadeleri [IChartDataCell.formula](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/ichartdatacell/formula/) aracılığıyla atayın.

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

Göreli referanslar, bir formül bir elektronik tablo uygulaması tarafından taşındığında veya kopyalandığında değişebilir. Mutlak referanslar her iki koordinatı da sabit tutar, karışık referanslar ise yalnızca bir satırı veya bir sütunu sabitleştirir.

## **R1C1‑Stili Formüller Kullanma**

R1C1 gösterimi, hem satırları hem de sütunları sayısal olarak tanımlar. Göreli referanslar köşeli parantez içinde ofset kullanır. Bu sözdizimini [IChartDataCell.r1c1_formula](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) aracılığıyla atayın.

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

## **Formül Sabitleri ve Operatörler**

Yerleşik formül değerlendiricisi mantıksal değerleri, sayısal sabitleri, metinleri, elektronik tablo hata değerlerini, aritmetik operatörleri ve karşılaştırma operatörlerini destekler.

### **Sabitler ve Literaller**

| Tür | Örnekler | Notlar |
|---|---|---|
| Mantıksal | `TRUE`, `FALSE` | `A2=TRUE` gibi mantıksal ifadelerde doğrudan kullanılabilir. |
| Sayısal | `1`, `0.5`, `.3`, `1E-2` | Ondalık ve bilimsel gösterimler desteklenir. |
| Metin | `"abc"`, `"2/3/2020 12:00"` | Metin sabitleri formül içinde çift tırnak içinde yazılır. |
| Hata sonucu | `#DIV/0!`, `#N/A`, `#REF!` | Geçerli bir formül, normal bir sonuç yerine bir elektronik tablo hata değeri üretebilir. |

Bu örnek birkaç sabit türünü gösterir:

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

| Operatör | Anlamı | Örnek |
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

| Operatör | Anlamı | Örnek |
|---|---|---|
| `=` | Eşittir | `A2=3` |
| `<>` | Eşit değildir | `A2<>3` |
| `>` | Büyüktür | `A2>3` |
| `>=` | Büyük veya eşittir | `A2>=3` |
| `<` | Küçüktür | `A2<3` |
| `<=` | Küçük veya eşittir | `A2<=3` |

## **Desteklenen Önceden Tanımlı İşlevler**

Aspose.Slides, grafik çalışma sayfaları için yerleşik bir formül değerlendiricisi içerir, ancak bu tam bir Excel hesaplama motoru değildir. Belgelenen işlev kümesi aşağıdaki ile sınırlıdır. [calculate_formulas](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) tarafından rastgele bir Excel işlevinin yeniden hesaplanabileceğini varsamamalısınız.

| İşlev | Amaç veya desteklenen biçim | Örnek |
|---|---|---|
| `ABS` | Mutlak değer | `ABS(A2)` |
| `AVERAGE` | Aritmetik ortalama | `AVERAGE(B2:B5)` |
| `CEILING` | Sayıyı yukarı yönde bir katına yuvarla | `CEILING(A2,5)` |
| `CHOOSE` | İndekse göre bir değer seç | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Metin değerlerini birleştir | `CONCAT(A2,B2)` |
| `CONCATENATE` | Metin değerlerini birleştir | `CONCATENATE(A2," ",B2)` |
| `DATE` | 1900 tarih sistemini kullanarak tarih değeri oluştur | `DATE(2026,8,19)` |
| `DAYS` | Tarihler arasındaki gün sayısını döndür | `DAYS(B2,A2)` |
| `FIND` | Bir metin değerini başka bir metin içinde bul | `FIND("-",A2)` |
| `FINDB` | Bayt yönelimli metin araması | `FINDB("a",A2)` |
| `IF` | Koşullu sonuç | `IF(A2>0,A2,0)` |
| `INDEX` | Referans biçimi | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektör biçimi | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektör biçimi | `MATCH(A2,B2:B5,0)` |
| `MAX` | En büyük değer | `MAX(B2:B5)` |
| `SUM` | Değerleri toplar | `SUM(B2:B5)` |
| `VLOOKUP` | Dikey arama | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Tablodaki kısıtlamalar önemlidir: `INDEX` referans biçiminde, `LOOKUP` ve `MATCH` vektör biçiminde belgelenmiştir. `DATE` 1900 tarih sistemini kullanır. Burada listelenmeyen özellik ve işlevler, Aspose.Slides formül değerlendiricisi tarafından desteklenmiyormuş gibi ele alınmalıdır.

## **Yeniden Hesaplama ve Önbelleğe Alınmış Değerler**

Elektronik tablo dosyaları genellikle bir formülü ve onun en son hesaplanmış değerini saklar. Aspose.Slides, bir sunum yüklendiğinde ve ilgili grafik verisi değiştirilmediğinde, [IChartDataCell.value](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/ichartdatacell/value/) üzerinden önbelleğe alınmış bir değeri okuyabilir.

Giriş hücrelerini veya formülleri değiştirdikten sonra eski önbellek sonucuna güvenmeyin. Hesaplanmış değerleri okumadan veya bunlara dayanan grafik verisini kaydetmeden önce [ChartDataWorkbook.calculate_formulas](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) çağırın.

Desteklenen alt kümenin dışındaki formüller için Aspose.Slides formülü ayrıştıramayabilir veya bağımlılıklarını belirleyemeyebilir. Çalışma kitabı değiştirilmişse, önceki önbellek değeri artık güvenilir kabul edilemez. Bu durumda, desteklenmeyen veri içeren bir hücrenin değerini okumak [CellUnsupportedDataException](https://reference.aspose.com/slides/tr/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/) hatasına yol açabilir.

Grafiğiniz Aspose.Slides tarafından değerlendirilmeyen Excel işlevlerine dayanıyorsa, bu formülleri destekleyen bir elektronik tablo motoru ile hesaplayın ve ortaya çıkan değerleri grafik çalışma kitabına geri yazın. Desteklenmeyen formülleri tahmin edilen değerlerle değiştirmeyin.

## **Formül Hatalarını İşleme**

İki farklı problem türü vardır.

Bir formül geçerli olabilir ancak `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` veya `#VALUE!` gibi bir elektronik tablo hata sonucu üretebilir. Bu durumda, hata belirteci hücre sonucu olarak `value` üzerinden döndürülebilir.

Bir formül ayrıca ayrıştırma, referans, bağımlılık veya desteklenen veri seviyesinde başarısız olabilir. Aspose.Slides bu durumlar için [CellInvalidFormulaException](https://reference.aspose.com/slides/tr/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/tr/python-net/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/tr/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/) ve [CellUnsupportedDataException](https://reference.aspose.com/slides/tr/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/) gibi elektronik tablo‑özel istisnalar sağlar.

Formüller şablonlardan veya kullanıcı girişinden geliyorsa, yeniden hesaplama ve değer erişimi çevresinde bu istisnaları yakalayın:

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

Grafik çalışma sayfalarındaki formül desteği, tam Excel uyumluluğu yerine belirli bir elektronik tablo hesaplama alt kümesi için tasarlanmıştır. Raporlama iş akışınızı tasarlarken şu kısıtlamaları aklınızda bulundurun:

- Aspose.Slides'ın formülleri yeniden hesaplamasını istediğinizde yalnızca belgelenen sabitleri, operatörleri, referansları ve işlevleri kullanın.
- Formül sonuçlarının bağımlı olduğu hücreleri değiştirdikten sonra yeniden hesaplayın.
- Yüklenen sunumlardan gelen önbelleğe alınmış değerleri bir anlık görüntü olarak değerlendirin; düzenlemeler sonrasında yeniden hesaplamanın yerini almaz.
- Mevcut şablonlardan gelen formülleri, belgelenen listede olmayan işlevler içeriyorsa, hesaplanmış değerlerine güvenmeden önce test edin.
- Tam bir elektronik tablo hesaplama motoru gerektiren formüller için dışarıda hesaplayın ve ardından grafik çalışma kitabını sonuç değerleriyle güncelleyin.

## **SSS**

**`formula` ile `r1c1_formula` arasındaki fark nedir?**

[formula](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/ichartdatacell/formula/) `B2-C2` gibi A1‑stili bir ifadeyi saklar. [r1c1_formula](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/ichartdatacell/r1c1_formula/) ise `RC[-2]-RC[-1]` gibi R1C1‑stili bir ifadeyi saklar. Formülleri nasıl ürettiğinize veya kopyaladığınıza en uygun gösterimi kullanın.

**Hesaplamadan sonra hücreyi mi yoksa değerini mi okumalıyım?**

[ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) bir `IChartDataCell` döndürür. Hesaplanmış sonucu elde etmek için yeniden hesaplamadan sonra bu hücrenin [value](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/ichartdatacell/value/) özelliğini okuyun.

**`calculate_formulas` ne zaman çağrılmalı?**

Giriş değerlerini veya formülleri değiştirdikten ve hesaplanmış sonuçlara bağlı olmadan önce [calculate_formulas](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) çağırın. Bu, yerleşik değerlendiricinin desteklediği formüllerin değerlerini günceller.

**Aspose.Slides her Excel işlevini destekliyor mu?**

Hayır. Yerleşik değerlendirici belgelenen bir işlev alt kümesini destekler. Bu kümenin dışındaki işlevlerin doğru bir şekilde yeniden hesaplanacağını varsaymayın. Tam Excel formül uyumluluğu gerekiyorsa, hesaplamayı uygun bir elektronik tablo motoru ile yapın ve sonuç değerleri grafiğin çalışma kitabına yazın.

**Yüklenen bir sunumda desteklenmeyen bir formül bulunursa ne olur?**

Grafik verisi değişmemişse, çalışma kitabı hâlâ daha önce hesaplanmış bir önbellek değerine sahip olabilir. İlgili veri değiştirildiğinde bu önbellek değeri geçersiz hale gelebilir. Formülü işlenemeyen bir hücreye erişmek [CellUnsupportedDataException](https://reference.aspose.com/slides/tr/python-net/aspose.slides.spreadsheet/cellunsupporteddataexception/) hatasına neden olabilir.

**Formül hata değerleri Python istisnalarıyla aynı mı?**

Hayır. `#DIV/0!` gibi bir sonuç, geçerli bir hesaplamanın ürettiği bir elektronik tablo değeridir. [CellInvalidFormulaException](https://reference.aspose.com/slides/tr/python-net/aspose.slides.spreadsheet/cellinvalidformulaexception/) veya [CellCircularReferenceException](https://reference.aspose.com/slides/tr/python-net/aspose.slides.spreadsheet/cellcircularreferenceexception/) gibi istisnalar, formülün normal işlenemediğini gösterir.

**Bir formül hücresi değiştiğinde grafik otomatik olarak güncellenir mi?**

Bir grafik serisi çalışma kitabı hücrelerini referans alabilir. İlk olarak çalışma kitabını yeniden hesaplayın, ardından sunumu kaydedin veya render edin. Grafik veri noktaları hesaplanan hücrelere işaret ediyorsa, grafik bu güncellenmiş hücre değerlerini kullanır; bu iş akışı için ayrı bir grafik‑yenileme yöntemi gerekmez.

**Grafikler harici bir Excel çalışma kitabı kullanabilir mi?**

Evet, grafik verisi API aracılığıyla harici bir çalışma kitabı kullanacak şekilde yapılandırılabilir. Ancak bu makalede açıklanan formül hesaplama iş akışı, grafik veri çalışma kitabı ve Aspose.Slides tarafından değerlendirilen formül alt kümesiyle sınırlıdır. [calculate_formulas](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdataworkbook/calculate_formulas/) dış bir XLSX dosyasındaki rastgele formüllerin tam yeniden hesaplamasını sağlamaz.

**Başka bir çalışma sayfasına veya çalışma kitabına başvuran formüller kullanabilir miyim?**

Excel‑stili referanslar grafik çalışma kitaplarında bulunabilir, ancak formül değerlendirme desteklenen ayrıştırıcı ve işlev kümesiyle sınırlıdır. Çapraz‑sayfa veya dış referans kritikse, hedef Aspose.Slides sürümünüzle tam formülü doğrulayın. Geniş Excel referans uyumluluğu gerektiren iş akışları için çalışma kitabını dışarıda hesaplayın ve çözülmüş değerleri grafik verisine geri yazın.

**Formül dizgileri `=` ile başlamalı mı?**

Aspose.Slides API örnekleri, `B2-C2` veya `SUM(B2:B5)` gibi ön ek `=` olmadan ifadeler atar. Bu biçimi kullanmak, oluşturulan formüllerin belgelenen API örnekleriyle tutarlı olmasını sağlar.