---
title: Python üzerinden Java ile Sunumlarda Grafik Çalışma Sayfası Formüllerini Uygulama
linktitle: Çalışma Sayfası Formülleri
type: docs
weight: 70
url: /tr/python-java/chart-worksheet-formulas/
keywords:
- grafik elektronik tablo
- grafik çalışma sayfası
- grafik formülü
- çalışma sayfası formülü
- elektronik tablo formülü
- grafik veri çalışma kitabı
- formül hesaplama
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
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java grafik çalışma sayfalarında Excel tarzı formülleri uygulayın, değerleri yeniden hesaplayın ve sonuçları PowerPoint grafiklerinde kullanın."
---
## **Genel Bakış**

PowerPoint grafikler genellikle kaynak verilerini gömülü bir çalışma sayfasında saklar. Aspose.Slides for Python via Java'da, bu çalışma sayfasına grafik veri çalışma kitabı aracılığıyla erişebilir, giriş değerleri yazabilir, hücrelere formüller atayabilir, desteklenen formülleri hesaplayabilir ve hesaplanan hücreleri grafik verisi olarak kullanabilirsiniz.

Bu makale tam formül iş akışını açıklar: bir grafik oluşturma, onun çalışma sayfasını doldurma, A1 tarzı veya R1C1 tarzı formüller atama, bunları yeniden hesaplama, hesaplanan değerleri okuma, bu hücreleri bir grafik serisine bağlama ve sunumu kaydetme. Ayrıca desteklenen formül sözdizimini, yerleşik fonksiyon alt kümesini, önbelleğe alınmış değerleri, desteklenmeyen formülleri ve elektronik tabloya özgü hataları tanımlar.

## **Grafik Çalışma Sayfaları ve Formüller**

Bir grafik çalışma sayfası, bir grafik tarafından kullanılan kategorileri, seri adlarını ve değerleri içerir. PowerPoint'te, grafik veri editörünü açarak çalışma sayfasını inceleyebilirsiniz:

![Gömülü çalışma sayfası açık olan PowerPoint grafiği, kategori ve seri verilerini gösteriyor](chart-worksheet-formulas_1.png)

Aspose.Slides'te, çalışma sayfası [ChartDataWorkbook](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdataworkbook/) sınıfı aracılığıyla sunulur. A1 tarzı formüller için [ChartDataCell.setFormula](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdatacell/#setFormula), R1C1 tarzı formüller için [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdatacell/#setR1C1Formula) kullanın. Giriş hücrelerini veya formülleri değiştirdikten sonra, desteklenen formülleri yeniden hesaplamak ve ilgili hücre değerlerini güncellemek için [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) çağırın.

Hesaplanmış bir hücre hâlâ sonucunu [ChartDataCell.getValue](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdatacell/#getValue) aracılığıyla sunar. Bu, kod içinde bir formül sonucunu incelemeniz veya hücreyi bir grafik veri noktası olarak kullanmanız gerektiğinde önemlidir.

## **Grafik Oluşturma ve Çalışma Sayfası Formüllerini Hesaplama**

Aşağıdaki örnek uçtan uca bir iş akışını gösterir. Küme sütun grafiği oluşturur, örnek verileri temizler, çeyrek gelir ve gider değerlerini yazar, formüllerle karı hesaplar, sonuçları okur, hesaplanan hücreleri grafik değerleri olarak kullanır ve sunumu kaydeder.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 350)
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    workbook.clear(worksheet_index)

    category1 = workbook.getCell(worksheet_index, "A2", "Q1")
    category2 = workbook.getCell(worksheet_index, "A3", "Q2")
    category3 = workbook.getCell(worksheet_index, "A4", "Q3")

    workbook.getCell(worksheet_index, "B1", "Revenue")
    workbook.getCell(worksheet_index, "C1", "Expenses")
    workbook.getCell(worksheet_index, "D1", "Profit")

    workbook.getCell(worksheet_index, "B2").setValue(120.0)
    workbook.getCell(worksheet_index, "C2").setValue(80.0)
    workbook.getCell(worksheet_index, "B3").setValue(150.0)
    workbook.getCell(worksheet_index, "C3").setValue(95.0)
    workbook.getCell(worksheet_index, "B4").setValue(135.0)
    workbook.getCell(worksheet_index, "C4").setValue(110.0)

    profit1 = workbook.getCell(worksheet_index, "D2")
    profit2 = workbook.getCell(worksheet_index, "D3")
    profit3 = workbook.getCell(worksheet_index, "D4")

    profit1.setFormula("B2-C2")
    profit2.setFormula("B3-C3")
    profit3.setFormula("B4-C4")

    workbook.calculateFormulas()

    q1_profit = float(profit1.getValue()) # 40
    q2_profit = float(profit2.getValue()) # 55
    q3_profit = float(profit3.getValue()) # 25

    print("Q1 profit: ", q1_profit)
    print("Q2 profit: ", q2_profit)
    print("Q3 profit: ", q3_profit)

    chart.getChartData().getCategories().add(category1)
    chart.getChartData().getCategories().add(category2)
    chart.getChartData().getCategories().add(category3)

    profit_series = chart.getChartData().getSeries().add(workbook.getCell(worksheet_index, "D1"), chart.getType())
    profit_series.getDataPoints().addDataPointForBarSeries(profit1)
    profit_series.getDataPoints().addDataPointForBarSeries(profit2)
    profit_series.getDataPoints().addDataPointForBarSeries(profit3)
    profit_series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("chart-formulas.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Grafik veri noktaları `D2:D4` aralığını referans alır, bu nedenle grafik hesaplanan kar değerlerini kullanır. Bu iş akışında ayrı bir grafik‑yenileme çağrısı yoktur: önce çalışma kitabını yeniden hesaplayın, ardından hesaplanan hücrelere işaret eden grafik verisini kullanın ya da kaydedin.

## **A1-Stil Formüllerini Kullanma**

A1 gösterimi sütunları harflerle, satırları sayılarla tanımlar. A1‑stil ifadeleri [ChartDataCell.setFormula](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdatacell/#setFormula) aracılığıyla atayın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "C3").setValue(10)
    workbook.getCell(0, "F2").setValue(2)
    workbook.getCell(0, "G2").setValue(3)
    workbook.getCell(0, "H2").setValue(4)

    cell = workbook.getCell(0, "A2")
    cell.setFormula("C3+SUM(F2:H2)")

    workbook.calculateFormulas()

    value = cell.getValue() # 19
finally:
    presentation.dispose()
```

Yaygın A1 referans biçimleri şunlardır:

| Referans | Göreli | Mutlak | Karışık |
|---|---|---|---|
| Hücre | `A2` | `$A$2` | `A$2`, `$A2` |
| Satır | `2:2` | `$2:$2` | — |
| Sütun | `A:A` | `$A:$A` | — |
| Aralık | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Göreli referanslar bir formül bir elektronik tablo uygulaması tarafından taşındığında veya kopyalandığında değişebilir. Mutlak referanslar her iki koordinatı da sabit tutar, karışık referanslar ise yalnızca bir satırı ya da bir sütunu sabitler.

## **R1C1-Stil Formüllerini Kullanma**

R1C1 gösterimi satır ve sütunları sayısal olarak tanımlar. Göreli referanslar köşeli parantezlerdeki offset’leri kullanır. Bu sözdizimini [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdatacell/#setR1C1Formula) aracılığıyla atayın.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "B2").setValue(12)
    workbook.getCell(0, "C2").setValue(5)

    cell = workbook.getCell(0, "D2")
    cell.setR1C1Formula("RC[-2]-RC[-1]")

    workbook.calculateFormulas()

    value = cell.getValue() # 7
finally:
    presentation.dispose()
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

Yerleşik formül değerlendiricisi mantıksal değerleri, sayısal sabitleri, dizeleri, elektronik tablo hata değerlerini, aritmetik operatörleri ve karşılaştırma operatörlerini destekler.

### **Sabitler ve Literaller**

| Tür | Örnekler | Notlar |
|---|---|---|
| Mantıksal | `TRUE`, `FALSE` | `A2=TRUE` gibi mantıksal ifadelerde doğrudan kullanılabilir. |
| Sayısal | `1`, `0.5`, `.3`, `1E-2` | Yaygın ve bilimsel gösterimler desteklenir. |
| Dize | `"abc"`, `"2/3/2020 12:00"` | Metin sabitleri formül içinde çift tırnak içinde yazılır. |
| Hata sonucu | `#DIV/0!`, `#N/A`, `#REF!` | Geçerli bir formül, normal bir sonuç yerine bir elektronik tablo hata değeri üretebilir. |

Bu örnek çeşitli sabit türlerini kullanır:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpify.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.getCell(0, "A2").setValue(False)
    workbook.getCell(0, "B2").setFormula("A2=TRUE")
    workbook.getCell(0, "C2").setFormula("1+0.5")
    workbook.getCell(0, "D2").setFormula(".3*1E-2")
    workbook.getCell(0, "E2").setFormula("\"abc\"")
    workbook.getCell(0, "F2").setFormula("2/0")

    workbook.calculateFormulas()

    logical_value = workbook.getCell(0, "B2").getValue() # Yanlış
    numeric_value = workbook.getCell(0, "C2").getValue() # 1.5
    scientific_value = workbook.getCell(0, "D2").getValue() # 0.003
    string_value = workbook.getCell(0, "E2").getValue() # abc
    error_value = workbook.getCell(0, "F2").getValue() # #DIV/0!
finally:
    presentation.dispose()
```

### **Aritmetik Operatörler**

| Operatör | Anlamı | Örnek |
|---|---|---|
| `+` | Toplama veya tekli artı | `2+3` |
| `-` | Çıkarma veya eksi | `2-3`, `-3` |
| `*` | Çarpma | `2*3` |
| `/` | Bölme | `2/3` |
| `%` | Yüzde | `30%` |
| `^` | Üs | `2^3` |

Değerlendirme sırasını açıkça belirtmek için parantez kullanın; örneğin `(A2+B2)*C2`.

### **Karşılaştırma Operatörleri**

Karşılaştırma ifadeleri mantıksal değer döndürür.

| Operatör | Anlamı | Örnek |
|---|---|---|
| `=` | Eşit | `A2=3` |
| `<>` | Eşit değil | `A2<>3` |
| `>` | Büyük | `A2>3` |
| `>=` | Büyük veya eşit | `A2>=3` |
| `<` | Küçük | `A2<3` |
| `<=` | Küçük veya eşit | `A2<=3` |

## **Desteklenen Önceden Tanımlı Fonksiyonlar**

Aspose.Slides, grafik çalışma sayfaları için yerleşik bir formül değerlendiricisi içerir, ancak tam bir Excel hesaplama motoru değildir. Belgelenen fonksiyon kümesi aşağıdaki ile sınırlıdır. [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) tarafından yeniden hesaplanabileceği varsayılan rastgele bir Excel fonksiyonunu varsaymayın.

| Fonksiyon | Amacı veya desteklenen biçim | Örnek |
|---|---|---|
| `ABS` | Mutlak değer | `ABS(A2)` |
| `AVERAGE` | Aritmetik ortalama | `AVERAGE(B2:B5)` |
| `CEILING` | Bir sayıyı üstteki bir kat sayıya yuvarla | `CEILING(A2,5)` |
| `CHOOSE` | İndekse göre bir değer seç | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Metin değerlerini birleştir | `CONCAT(A2,B2)` |
| `CONCATENATE` | Metin değerlerini birleştir | `CONCATENATE(A2," ",B2)` |
| `DATE` | 1900 tarih sistemi kullanarak bir tarih değeri oluştur | `DATE(2026,8,19)` |
| `DAYS` | Tarihler arasındaki gün sayısını döndür | `DAYS(B2,A2)` |
| `FIND` | Bir metin değerini diğerinin içinde bul | `FIND("-",A2)` |
| `FINDB` | Bayt temelli metin araması | `FINDB("a",A2)` |
| `IF` | Koşullu sonuç | `IF(A2>0,A2,0)` |
| `INDEX` | Referans biçimi | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektör biçimi | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektör biçimi | `MATCH(A2,B2:B5,0)` |
| `MAX` | Maksimum değer | `MAX(B2:B5)` |
| `SUM` | Değerleri toplar | `SUM(B2:B5)` |
| `VLOOKUP` | Dikey arama | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Tabloda gösterilen kısıtlamalar önemlidir: `INDEX` referans biçiminde belgelenirken, `LOOKUP` ve `MATCH` vektör biçiminde belgelenmiştir. `DATE` 1900 tarih sistemini kullanır. Burada listelenmeyen özellik ve fonksiyonlar, Aspose.Slides formül değerlendiricisi tarafından desteklenmiyormuş gibi ele alınmalıdır.

## **Formülleri Tercih Edilen Kültürle Hesaplama**

Bazı grafik çalışma kitabı fonksiyonları metni kültüre özgü kurallara göre yorumlar. Bu, çift bayt karakter seti (DBCS) kullanan diller için tasarlanmış fonksiyonlar için özellikle önemlidir. Bu tür formülleri doğru hesaplamak için [LoadOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/) oluşturun, tercih edilen kültürü [SpreadsheetOptions.setPreferredCulture](https://reference.aspose.com/slides/tr/python-java/aspose.slides/spreadsheetoptions/#setPreferredCulture) ile ayarlayın, elektronik tablo seçeneklerini [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/tr/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) aracılığıyla atayın ve ardından sunumu yükleyin.

Aşağıdaki örnek Japon kültürünü seçer, yapılandırılmış yükleme seçenekleriyle bir sunumu açar ve her grafik çalışma kitabı için [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) çağrısını yapar:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, LoadOptions, Presentation, SpreadsheetOptions
from java.util import Locale

japanese_culture = Locale.forLanguageTag("ja-JP")

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setPreferredCulture(japanese_culture)

load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, Chart):
                shape.getChartData().getChartDataWorkbook().calculateFormulas()
finally:
    presentation.dispose()
```

Tercih edilen kültür, sunum yükleme yapılandırmasının bir parçasıdır; bu nedenle, [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) örneğini oluşturmadan önce belirtin. Çalışma kitabı formüllerinin beklediği kültürü kullanın; örneğin, Japon DBCS hesaplama kurallarına uyması gereken formüller için `ja-JP` kullanın.

## **Yeniden Hesaplama ve Önbelleğe Alınan Değerler**

Elektronik tablo dosyaları genellikle bir formül ve onun son hesaplanmış değerini birlikte saklar. Aspose.Slides bu yüzden bir sunum yüklendiğinde ve ilgili grafik verisi değiştirilmediğinde, [ChartDataCell.getValue](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdatacell/#getValue) üzerinden önbelleğe alınmış bir değeri okuyabilir.

Giriş hücrelerini veya formülleri değiştirdikten sonra eski önbellek sonucuna güvenmeyin. Hesaplanan değerleri okumadan ya da onlara bağlı grafik verisini kaydetmeden önce [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) çağırın.

Desteklenen alt kümenin dışındaki formüller için, Aspose.Slides formülü ayrıştıramayabilir veya bağımlılıklarını belirleyemeyebilir. Çalışma kitabı değiştirilmişse, önceki önbellek değeri artık güvenilir kabul edilemez. Bu durumda, desteklenmeyen veri içeren bir hücrenin değerini okumak [CellUnsupportedDataException](https://reference.aspose.com/slides/tr/python-java/aspose.slides/cellunsupporteddataexception/) tetikleyebilir.

Grafiğiniz, Aspose.Slides'in değerlendirmediği Excel fonksiyonlarına bağlıysa, bu formülleri bu fonksiyonları destekleyen bir elektronik tablo motoru ile hesaplayın ve elde edilen değerleri grafik çalışma kitabına yazın. Desteklenmeyen formülleri tahmini değerlerle değiştirmeyin.

## **Formül Hatalarını Ele Alma**

Ayırmanız gereken iki farklı problem tipi vardır.

Bir formül geçerli olabilir ancak `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` veya `#VALUE!` gibi bir elektronik tablo hata sonucu üretir. Bu durumda hata belirteci bir hücre sonucu olup [ChartDataCell.getValue](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdatacell/#getValue) üzerinden döndürülebilir.

Bir formül ayrıca ayrıştırma, referans, bağımlılık ya da desteklenen veri seviyesinde başarısız olabilir. Aspose.Slides bu durumlar için [CellInvalidFormulaException](https://reference.aspose.com/slides/tr/python-java/aspose.slides/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/tr/python-java/aspose.slides/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/tr/python-java/aspose.slides/cellcircularreferenceexception/) ve [CellUnsupportedDataException](https://reference.aspose.com/slides/tr/python-java/aspose.slides/cellunsupporteddataexception/) gibi elektronik tablo‑özel istisnalar sağlar.

Formüller şablonlardan veya kullanıcı girdilerinden geldiğinde, yeniden hesaplama ve değer erişimi etrafında bu istisnaları yakalayın:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CellCircularReferenceException, CellInvalidFormulaException, CellInvalidReferenceException, CellUnsupportedDataException, ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 300)
    workbook = chart.getChartData().getChartDataWorkbook()
    cell = workbook.getCell(0, "A2")
    cell.setFormula("SUM(B2:B5)")

    try:
        workbook.calculateFormulas()
        print(cell.getValue())
    except CellInvalidFormulaException as ex:
        print("Invalid formula: " + str(ex.getMessage()))
    except CellInvalidReferenceException as ex:
        print("Invalid cell reference: " + str(ex.getMessage()))
    except CellCircularReferenceException as ex:
        print("Circular reference: " + str(ex.getMessage()))
    except CellUnsupportedDataException as ex:
        print("Unsupported spreadsheet data: " + str(ex.getMessage()))
finally:
    presentation.dispose()
```

## **Pratik Sınırlamalar**

Grafik çalışma sayfalarındaki formül desteği, tam Excel uyumluluğu olmayan, tanımlı bir elektronik tablo hesaplama alt kümesi için tasarlanmıştır. Raporlama iş akışınızı tasarlarken şu sınırlamaları aklınızda bulundurun:

- Aspose.Slides'in formülleri yeniden hesaplamasını istediğinizde yalnızca belgelenen sabitleri, operatörleri, referansları ve fonksiyonları kullanın.
- Formül sonuçlarının bağımlı olduğu hücreleri değiştirdikten sonra yeniden hesaplayın.
- Yüklenmiş sunumlardan gelen önbelleğe alınmış değerleri bir anlık görüntü olarak değerlendirin; düzenlemelerden sonra yeniden hesaplamanın yerine kullanmayın.
- Mevcut şablonlardaki formülleri, belgelenen listenin dışındaki fonksiyonları içeriyorsa, hesaplanan değerlerine güvenmeden önce test edin.
- Tam bir elektronik tablo hesaplama motoru gerektiren formüller için bunları harici olarak hesaplayın ve ardından grafik çalışma kitabını elde edilen değerlerle güncelleyin.

## **SSS**

**ChartDataCell.setFormula ile ChartDataCell.setR1C1Formula arasındaki fark nedir?**

[ChartDataCell.setFormula](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdatacell/#setFormula) `B2-C2` gibi bir A1‑stil ifadesi saklar. [ChartDataCell.setR1C1Formula](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdatacell/#setR1C1Formula) `RC[-2]-RC[-1]` gibi bir R1C1‑stil ifadesi saklar. Formülleri nasıl ürettiğinize veya kopyaladığınıza en uygun gösterimi kullanın.

**Hesaplamadan sonra hücreyi mi yoksa değerini mi okumam gerekir?**

[ChartDataWorkbook.getCell](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdataworkbook/#getCell) bir [ChartDataCell](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdatacell/) döndürür. Hesaplamadan sonra hesaplanan sonucu almak için o hücrenin [ChartDataCell.getValue](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdatacell/#getValue) metodunu çağırın.

**[ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) ne zaman çağrılmalı?**

Giriş değerlerini veya formülleri değiştirdikten ve hesaplanan sonuçlara bağımlı olmadan önce [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) çağırın. Bu, yerleşik değerlendiricinin desteklediği formüllerin değerlerini günceller.

**Aspose.Slides her Excel fonksiyonunu destekliyor mu?**

Hayır. Yerleşik değerlendirici belgelenen bir fonksiyon alt kümesini destekler. Bu alt kümenin dışındaki fonksiyonların doğru şekilde yeniden hesaplanacağı varsayılmamalıdır. Tam Excel formül uyumluluğu gerekiyorsa, hesaplamayı uygun bir elektronik tablo motoruyla gerçekleştirin ve son değerleri grafik çalışma kitabına yazın.

**Yüklenmiş bir sunum desteklenmeyen bir formül içerirse ne olur?**

Grafik verisi değişmemişse, çalışma kitabı hâlâ önceki hesaplanmış önbellek değerini içerebilir. İlgili veri değiştirildiğinde bu önbellek değeri geçersiz olabilir. Formülü işlenemeyen bir hücreye erişmek [CellUnsupportedDataException](https://reference.aspose.com/slides/tr/python-java/aspose.slides/cellunsupporteddataexception/) tetikleyebilir.

**Formül hata değerleri istisna mı?**

Hayır. `#DIV/0!` gibi bir sonuç, geçerli bir hesaplamanın ürettiği bir elektronik tablo değeridir. [CellInvalidFormulaException](https://reference.aspose.com/slides/tr/python-java/aspose.slides/cellinvalidformulaexception/) veya [CellCircularReferenceException](https://reference.aspose.com/slides/tr/python-java/aspose.slides/cellcircularreferenceexception/) gibi istisnalar, formülün normal olarak işlenemediğini gösterir.

**Bir formül hücresi değiştiğinde grafik otomatik olarak güncellenir mi?**

Bir grafik serisi çalışma kitabı hücrelerine başvurabilir. Önce çalışma kitabını yeniden hesaplayın, ardından sunumu kaydedin veya render edin. Grafik veri noktaları hesaplanan hücrelere referans veriyorsa, grafik bu güncellenmiş hücre değerlerini kullanır; bu iş akışında ayrı bir grafik‑yenileme yöntemi gerekmez.

**Grafikler harici bir Excel çalışma kitabı kullanabilir mi?**

Evet, grafik verisi harici bir çalışma kitabı kullanacak şekilde grafik veri API'si aracılığıyla yapılandırılabilir. Bununla birlikte, bu makalede açıklanan formül hesaplama iş akışı grafik veri çalışma kitabı ve Aspose.Slides tarafından değerlendirilen formül alt kümesiyle sınırlıdır. [ChartDataWorkbook.calculateFormulas](https://reference.aspose.com/slides/tr/python-java/aspose.slides/chartdataworkbook/#calculateFormulas) dış bir XLSX dosyasındaki rastgele formüllerin tam yeniden hesaplamasını sağlayacağını varsaymayın.

**Başka bir çalışma sayfasına veya çalışma kitabına başvuran formüller kullanabilir miyim?**

Excel‑stil başvurular grafik çalışma kitaplarında bulunabilir, ancak formül değerlendirmesi desteklenen ayrıştırıcı ve fonksiyon kümesiyle sınırlıdır. Çapraz‑sayfa veya harici bir referans kritikse, hedef Aspose.Slides sürümünüzde tam olarak test edin. Geniş Excel referans uyumluluğu gerektiren iş akışları için, çalışma kitabını harici olarak hesaplayın ve çözülen değerleri grafik verisine geri yazın.

**Formül dizgileri `=` ile başlamalı mı?**

Aspose.Slides API örnekleri `B2-C2` veya `SUM(B2:B5)` gibi ifadeleri baştaki `=` olmadan atar. Bu biçimi kullanmak, oluşturulan formüllerin belgelenen API örnekleriyle tutarlı kalmasını sağlar.