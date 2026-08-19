---
title: C++ Kullanarak Sunumlarda Grafik Çalışma Sayfası Formüllerini Uygulama
linktitle: Çalışma Sayfası Formülleri
type: docs
weight: 70
url: /tr/cpp/chart-worksheet-formulas/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ grafik çalışma sayfalarında Excel tarzı formülleri uygulayın, değerleri yeniden hesaplayın ve sonuçları PowerPoint grafiklerinde kullanın."
---
## **Genel Bakış**

PowerPoint grafiklerinin kaynak verileri genellikle gömülü bir çalışma sayfasında saklanır. Aspose.Slides for C++ içinde bu çalışma sayfasına grafik veri çalışma kitabı aracılığıyla erişebilir, giriş değerlerini yazabilir, hücrelere formüller atayabilir, desteklenen formülleri hesaplayabilir ve hesaplanan hücreleri grafik verisi olarak kullanabilirsiniz.

Bu makale, tam formül iş akışını açıklar: bir grafik oluşturma, çalışma sayfasını doldurma, A1 stilinde veya R1C1 stilinde formüller atama, bunları yeniden hesaplama, hesaplanan değerleri okuma, bu hücreleri bir grafik serisine bağlama ve sunumu kaydetme. Ayrıca desteklenen formül sözdizimi, yerleşik işlev alt kümesi, önbelleklenmiş değerler, desteklenmeyen formüller ve elektronik tabloya özgü hatalar da açıklanır.

## **Grafik Çalışma Sayfaları ve Formüller**

Bir grafik çalışma sayfası, bir grafik tarafından kullanılan kategorileri, seri adlarını ve değerleri içerir. PowerPoint’te grafik veri düzenleyiciyi açarak çalışma sayfasını inceleyebilirsiniz:

![PowerPoint chart with its embedded worksheet open, showing category and series data](chart-worksheet-formulas_1.png)

Aspose.Slides’te çalışma sayfası, [IChartDataWorkbook](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdataworkbook/) arayüzü aracılığıyla sunulur. A1‑stili formüller için [IChartDataCell::set_Formula](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatacell/set_formula/), R1C1‑stili formüller için [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) kullanın. Giriş hücrelerini veya formülleri değiştirdikten sonra, desteklenen formülleri yeniden hesaplamak ve ilgili hücre değerlerini güncellemek için [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) metodunu çağırın.

Hesaplanan bir hücre, sonuç değerini hâlâ [IChartDataCell::get_Value](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatacell/get_value/) üzerinden açığa çıkarır. Bu, kod içinde bir formül sonucunu incelemeniz veya hücreyi bir grafik veri noktası olarak kullanmanız gerektiğinde önemlidir.

## **Grafik Oluşturma ve Çalışma Sayfası Formüllerini Hesaplama**

Aşağıdaki örnek, uçtan uca bir iş akışını gösterir. Küme sütun grafiği oluşturur, örnek verileri temizler, çeyrek dönem gelir ve gider değerlerini yazar, formüllerle karı hesaplar, sonuçları okur, hesaplanan hücreleri grafik değerleri olarak kullanır ve sunumu kaydeder.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 350.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();
const int32_t worksheetIndex = 0;

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();
workbook->Clear(worksheetIndex);

auto category1 = workbook->GetCell(worksheetIndex, u"A2", ObjectExt::Box<String>(u"Q1"));
auto category2 = workbook->GetCell(worksheetIndex, u"A3", ObjectExt::Box<String>(u"Q2"));
auto category3 = workbook->GetCell(worksheetIndex, u"A4", ObjectExt::Box<String>(u"Q3"));

workbook->GetCell(worksheetIndex, u"B1", ObjectExt::Box<String>(u"Revenue"));
workbook->GetCell(worksheetIndex, u"C1", ObjectExt::Box<String>(u"Expenses"));
workbook->GetCell(worksheetIndex, u"D1", ObjectExt::Box<String>(u"Profit"));

workbook->GetCell(worksheetIndex, u"B2")->set_Value(ObjectExt::Box<double>(120.0));
workbook->GetCell(worksheetIndex, u"C2")->set_Value(ObjectExt::Box<double>(80.0));
workbook->GetCell(worksheetIndex, u"B3")->set_Value(ObjectExt::Box<double>(150.0));
workbook->GetCell(worksheetIndex, u"C3")->set_Value(ObjectExt::Box<double>(95.0));
workbook->GetCell(worksheetIndex, u"B4")->set_Value(ObjectExt::Box<double>(135.0));
workbook->GetCell(worksheetIndex, u"C4")->set_Value(ObjectExt::Box<double>(110.0));

auto profit1 = workbook->GetCell(worksheetIndex, u"D2");
auto profit2 = workbook->GetCell(worksheetIndex, u"D3");
auto profit3 = workbook->GetCell(worksheetIndex, u"D4");

profit1->set_Formula(u"B2-C2");
profit2->set_Formula(u"B3-C3");
profit3->set_Formula(u"B4-C4");

workbook->CalculateFormulas();

auto q1Profit = profit1->get_Value(); // 40
auto q2Profit = profit2->get_Value(); // 55
auto q3Profit = profit3->get_Value(); // 25

chartData->get_Categories()->Add(category1);
chartData->get_Categories()->Add(category2);
chartData->get_Categories()->Add(category3);

auto profitSeries = chartData->get_Series()->Add(workbook->GetCell(worksheetIndex, u"D1"), chart->get_Type());
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit1);
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit2);
profitSeries->get_DataPoints()->AddDataPointForBarSeries(profit3);
profitSeries->get_Labels()->get_DefaultDataLabelFormat()->set_ShowValue(true);

presentation->Save(u"chart-formulas.pptx", SaveFormat::Pptx);
```

Grafik veri noktaları `D2:D4` aralığını referans alır; dolayısıyla grafik, hesaplanan kar değerlerini kullanır. Bu iş akışında ayrı bir grafik‑yenileme çağrısı yoktur: önce çalışma kitabını yeniden hesaplayın, ardından hesaplanan hücreleri referans alan grafiği kullanın veya kaydedin.

## **A1 Stilindeki Formülleri Kullanma**

A1 gösterimi, sütunları harflerle, satırları ise sayılarla tanımlar. A1‑stili ifadeleri [IChartDataCell::set_Formula](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatacell/set_formula/) aracılığıyla atayın.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"C3")->set_Value(ObjectExt::Box<int32_t>(10));
workbook->GetCell(0, u"F2")->set_Value(ObjectExt::Box<int32_t>(2));
workbook->GetCell(0, u"G2")->set_Value(ObjectExt::Box<int32_t>(3));
workbook->GetCell(0, u"H2")->set_Value(ObjectExt::Box<int32_t>(4));

auto cell = workbook->GetCell(0, u"A2");
cell->set_Formula(u"C3+SUM(F2:H2)");

workbook->CalculateFormulas();

auto value = cell->get_Value(); // 19
```

Yaygın A1 referans biçimleri şunlardır:

| Referans | Göreli | Mutlak | Karışık |
|---|---|---|---|
| Hücre | `A2` | `$A$2` | `A$2`, `$A2` |
| Satır | `2:2` | `$2:$2` | — |
| Sütun | `A:A` | `$A:$A` | — |
| Aralık | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Göreli referanslar, bir formül bir elektronik tablo uygulaması tarafından taşındığında veya kopyalandığında değişebilir. Mutlak referanslar her iki koordinatı da sabit tutar, karışık referanslar ise yalnızca bir satırı ya da bir sütunu sabitler.

## **R1C1 Stilindeki Formülleri Kullanma**

R1C1 gösterimi, satır ve sütunları sayısal olarak tanımlar. Göreli referanslar köşeli parantez içinde ofsetler kullanır. Bu sözdizimini [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) aracılığıyla atayın.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"B2")->set_Value(ObjectExt::Box<int32_t>(12));
workbook->GetCell(0, u"C2")->set_Value(ObjectExt::Box<int32_t>(5));

auto cell = workbook->GetCell(0, u"D2");
cell->set_R1C1Formula(u"RC[-2]-RC[-1]");

workbook->CalculateFormulas();

auto value = cell->get_Value(); // 7
```

Yaygın R1C1 referans biçimleri şunlardır:

| Referans | Göreli | Mutlak | Karışık |
|---|---|---|---|
| Hücre | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Satır | `R[2]` | `R2` | — |
| Sütun | `C[3]` | `C3` | — |
| Aralık | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Örneğin, `D2` hücresinde `RC[-2]` ifadesi aynı satırda iki sütun sola olan hücreyi (`B2`) gösterir.

## **Formül Sabitleri ve Operatörler**

Yerleşik formül değerlendiricisi mantıksal değerleri, sayısal sabitleri, dizeleri, elektronik tablo hata değerlerini, aritmetik operatörleri ve karşılaştırma operatörlerini destekler.

### **Sabitler ve Literaller**

| Tür | Örnekler | Notlar |
|---|---|---|
| Mantıksal | `TRUE`, `FALSE` | `A2=TRUE` gibi mantıksal ifadelerde doğrudan kullanılabilir. |
| Sayısal | `1`, `0.5`, `.3`, `1E-2` | Yaygın ve bilimsel gösterimler desteklenir. |
| Dize | `"abc"`, `"2/3/2020 12:00"` | Metin sabitleri formül içinde çift tırnak içinde yazılır. |
| Hata sonucu | `#DIV/0!`, `#N/A`, `#REF!` | Geçerli bir formül, normal bir sonuç yerine bir elektronik tablo hata değeri üretebilir. |

Bu örnek, çeşitli sabit türlerini gösterir:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

workbook->GetCell(0, u"A2")->set_Value(ObjectExt::Box<bool>(false));
workbook->GetCell(0, u"B2")->set_Formula(u"A2=TRUE");
workbook->GetCell(0, u"C2")->set_Formula(u"1+0.5");
workbook->GetCell(0, u"D2")->set_Formula(u".3*1E-2");
workbook->GetCell(0, u"E2")->set_Formula(u"\"abc\"");
workbook->GetCell(0, u"F2")->set_Formula(u"2/0");

workbook->CalculateFormulas();

auto logicalValue = workbook->GetCell(0, u"B2")->get_Value(); // Yanlış
auto numericValue = workbook->GetCell(0, u"C2")->get_Value(); // 1.5
auto scientificValue = workbook->GetCell(0, u"D2")->get_Value(); // 0.003
auto stringValue = workbook->GetCell(0, u"E2")->get_Value(); // abc
auto errorValue = workbook->GetCell(0, u"F2")->get_Value(); // #DIV/0!
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

Değerlendirme sırasını açıkça belirlemek için parantez kullanın; örneğin `(A2+B2)*C2`.

### **Karşılaştırma Operatörleri**

Karşılaştırma ifadeleri mantıksal değerler döndürür.

| Operatör | Anlam | Örnek |
|---|---|---|
| `=` | Eşittir | `A2=3` |
| `<>` | Eşit değildir | `A2<>3` |
| `>` | Büyüktür | `A2>3` |
| `>=` | Büyük veya eşittir | `A2>=3` |
| `<` | Küçüktür | `A2<3` |
| `<=` | Küçük veya eşittir | `A2<=3` |

## **Desteklenen Önceden Tanımlı Fonksiyonlar**

Aspose.Slides, grafik çalışma sayfaları için yerleşik bir formül değerlendiricisi sunar, ancak tam bir Excel hesaplama motoru değildir. Belgelenen işlev kümesi aşağıdaki fonksiyonlarla sınırlıdır. [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) metodunun rastgele bir Excel fonksiyonunu yeniden hesaplayacağını varsaymayın.

| Fonksiyon | Amaç veya desteklenen form | Örnek |
|---|---|---|
| `ABS` | Mutlak değer | `ABS(A2)` |
| `AVERAGE` | Aritmetik ortalama | `AVERAGE(B2:B5)` |
| `CEILING` | Bir sayıyı yukarı doğru bir katına yuvarlar | `CEILING(A2,5)` |
| `CHOOSE` | İndekse göre bir değer seçer | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Metin değerlerini birleştirir | `CONCAT(A2,B2)` |
| `CONCATENATE` | Metin değerlerini birleştirir | `CONCATENATE(A2," ",B2)` |
| `DATE` | 1900 tarih sistemini kullanarak tarih değeri oluşturur | `DATE(2026,8,19)` |
| `DAYS` | Tarihler arasındaki gün sayısını döndürür | `DAYS(B2,A2)` |
| `FIND` | Bir metin değerini başka bir metin içinde bulur | `FIND("-",A2)` |
| `FINDB` | Bayt‑temelli metin araması | `FINDB("a",A2)` |
| `IF` | Koşullu sonuç | `IF(A2>0,A2,0)` |
| `INDEX` | Referans formu | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektör formu | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektör formu | `MATCH(A2,B2:B5,0)` |
| `MAX` | Azami değer | `MAX(B2:B5)` |
| `SUM` | Değerleri toplar | `SUM(B2:B5)` |
| `VLOOKUP` | Dikey arama | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Tabloda gösterilen kısıtlamalar önemlidir: `INDEX` referans formunda belgelenirken, `LOOKUP` ve `MATCH` vektör formlarında belgelenir. `DATE` 1900 tarih sistemini kullanır. Burada listelenmeyen özellik ve fonksiyonlar, Aspose.Slides formül değerlendiricisi tarafından desteklenmiyor olarak kabul edilmelidir.

## **Yeniden Hesaplama ve Önbelleklenmiş Değerler**

Elektronik tablo dosyaları genellikle bir formül ve onun son hesaplanmış değerini birlikte saklar. Aspose.Slides, bir sunum yüklendiğinde ve ilgili grafik verileri değiştirilmediğinde, [IChartDataCell::get_Value](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatacell/get_value/) üzerinden önbelleklenmiş bir değeri okuyabilir.

Giriş hücrelerini veya formülleri değiştirdikten sonra, eski önbelleklenmiş sonuca güvenmeyin. Hesaplanmış değerleri okumadan veya onlara dayalı grafik verisini kaydetmeden önce [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) metodunu çağırın.

Desteklenen alt kümenin dışındaki formüller için, Aspose.Slides formülü ayrıştıramayabilir veya bağımlılıklarını belirleyemeyebilir. Çalışma kitabı değiştirilmişse, önceki önbellek değeri artık güvenilir olmayabilir. Bu durumda, desteklenmeyen veri içeren bir hücrenin değerini okumak [CellUnsupportedDataException](https://reference.aspose.com/slides/tr/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/) hatasına yol açabilir.

Grafiğiniz Aspose.Slides’ın değerlendirmediği Excel fonksiyonlarına bağlıysa, bu formülleri destekleyen bir elektronik tablo motoruyla hesaplayıp sonuçları grafik çalışma kitabına yazın. Desteklenmeyen formülleri tahmini değerlerle değiştirmeyin.

## **Formül Hatalarını İşleme**

Ayırt edilmesi gereken iki farklı sorun türü vardır.

Bir formül geçerli olabilir ancak `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` veya `#VALUE!` gibi bir elektronik tablo hata sonucu üretebilir. Bu durumda hata belirteci bir hücre sonucudur ve [IChartDataCell::get_Value](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatacell/get_value/) üzerinden döndürülebilir.

Bir formül ayrıca ayrıştırma, referans, bağımlılık veya desteklenen veri seviyesinde başarısız olabilir. Aspose.Slides bu durumlar için elektronik tabloya özgü istisnalar sunar: [CellInvalidFormulaException](https://reference.aspose.com/slides/tr/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/tr/cpp/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/tr/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/), ve [CellUnsupportedDataException](https://reference.aspose.com/slides/tr/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

Formüller şablonlardan veya kullanıcı girişinden geldiğinde, yeniden hesaplama ve değer erişimi etrafında bu istisnaları yakalayın:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Spreadsheet/CellCircularReferenceException.h>
#include <Spreadsheet/CellInvalidFormulaException.h>
#include <Spreadsheet/CellInvalidReferenceException.h>
#include <Spreadsheet/CellUnsupportedDataException.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Spreadsheet;
using namespace System;

auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto cell = workbook->GetCell(0, u"A2");
cell->set_Formula(u"SUM(B2:B5)");

try
{
    workbook->CalculateFormulas();
    auto value = cell->get_Value();
}
catch (CellInvalidFormulaException&)
{
    // Geçersiz bir formülü ele al.
}
catch (CellInvalidReferenceException&)
{
    // Geçersiz bir hücre referansını ele al.
}
catch (CellCircularReferenceException&)
{
    // Döngüsel bir referansı ele al.
}
catch (CellUnsupportedDataException&)
{
    // Desteklenmeyen elektronik tablo verisini ele al.
}
```

## **Pratik Sınırlamalar**

Grafik çalışma sayfalarındaki formül desteği, tam bir Excel uyumluluğu yerine tanımlanmış bir elektronik tablo hesaplama alt kümesi için tasarlanmıştır. Raporlama iş akışı tasarlarken şu kısıtlamaları aklınızda tutun:

- Aspose.Slides’ın formülleri yeniden hesaplamasını istediğinizde sadece belgelenen sabitleri, operatörleri, referansları ve fonksiyonları kullanın.
- Formül sonuçlarının bağımlı olduğu hücreleri değiştirdikten sonra yeniden hesaplayın.
- Yüklenmiş sunumlardan gelen önbelleklenmiş değerleri anlık fotoğraf olarak değerlendirin; düzenlemeler sonrası yeniden hesaplamanın yerini tutmaz.
- Özellikle belgelenen listenin dışındaki fonksiyonları kullanan mevcut şablonlardaki formülleri, hesaplanmış değerlerine güvenmeden önce test edin.
- Tam bir elektronik tablo hesaplama motoru gerektiren formüller için, bu formülleri harici olarak hesaplayın ve ardından elde edilen değerleri grafik çalışma kitabına geri yazın.

## **SSS**

**`set_Formula` ve `set_R1C1Formula` arasındaki fark nedir?**

[IChartDataCell::set_Formula](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatacell/set_formula/) `B2-C2` gibi A1‑stili bir ifadeyi saklar. [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) `RC[-2]-RC[-1]` gibi R1C1‑stili bir ifadeyi saklar. Formülleri oluşturma veya kopyalama yönteminizle en iyi uyuşan gösterimi kullanın.

**Hesaplamadan sonra hücreyi mi yoksa değerini mi okumam gerekir?**

[IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) bir `IChartDataCell` döndürür. Hesaplanmış sonucu elde etmek için, yeniden hesaplamadan sonra o hücrenin [IChartDataCell::get_Value](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatacell/get_value/) değerini okuyun.

**`CalculateFormulas` metodunu ne zaman çağırmalıyım?**

Giriş değerlerini veya formülleri değiştirdikten sonra ve hesaplanan sonuçlara bağımlı olmadan önce [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) metodunu çağırın. Bu, yerleşik değerlendiricinin desteklediği formüllerin değerlerini günceller.

**Aspose.Slides her Excel fonksiyonunu destekliyor mu?**

Hayır. Yerleşik değerlendirici, belgelenen bir fonksiyon alt kümesini destekler. Bu alt kümenin dışındaki fonksiyonların doğru şekilde yeniden hesaplanacağını varsaymayın. Tam Excel formül uyumluluğu gerekiyorsa, hesabı uygun bir elektronik tablo motoru ile yapın ve son değerleri grafik çalışma kitabına yazın.

**Yüklenmiş bir sunumda desteklenmeyen bir formül varsa ne olur?**

Grafik verileri değiştirilmemişse, çalışma kitabı hâlâ daha önce hesaplanmış bir önbellek değeri içerebilir. İlgili veri değiştirildiğinde bu önbellek değeri geçersiz olabilir. Formülü işlenemeyen bir hücrenin değerine erişmek, [CellUnsupportedDataException](https://reference.aspose.com/slides/tr/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/) hatasına yol açabilir.

**Formül hata değerleri C++ istisnaları ile aynı mı?**

Hayır. `#DIV/0!` gibi bir sonuç, geçerli bir hesabın ürettiği bir elektronik tablo değeridir. [CellInvalidFormulaException](https://reference.aspose.com/slides/tr/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/) veya [CellCircularReferenceException](https://reference.aspose.com/slides/tr/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) gibi istisnalar, formülün normal bir şekilde işlenemediğini gösterir.

**Bir formül hücresi değiştiğinde grafik otomatik olarak güncellenir mi?**

Bir grafik serisi çalışma kitabı hücrelerini referans alabilir. Önce çalışma kitabını yeniden hesaplayın, ardından sunumu kaydedin veya render edin. Grafik veri noktaları hesaplanan hücreleri referans alıyorsa, grafik bu güncellenmiş hücre değerlerini kullanır; bu iş akışı için ayrı bir grafik‑yenileme yöntemi gerekmeyebilir.

**Grafikler harici bir Excel çalışma kitabı kullanabilir mi?**

Evet, grafik verileri API aracılığıyla harici bir çalışma kitabı kullanılacak şekilde yapılandırılabilir. Ancak bu makalede açıklanan formül hesaplama iş akışı, grafik veri çalışma kitabı ve Aspose.Slides tarafından değerlendirilen formül alt kümesi ile ilgilidir. [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) metodunun harici bir XLSX dosyasındaki rastgele formüllerin tam bir yeniden hesaplamasını sağlayacağını varsaymayın.

**Başka bir çalışma sayfasına veya çalışma kitabına referans veren formüller kullanabilir miyim?**

Excel‑stili referanslar grafik çalışma kitaplarında bulunabilir, ancak formül değerlendirme desteklenen ayrıştırıcı ve fonksiyon seti ile sınırlıdır. Çapraz‑sayfa veya harici bir referans kritikse, tam olarak kullandığınız Aspose.Slides sürümüyle formülü doğrulayın. Geniş Excel referans uyumluluğu gerektiren iş akışları için, çalışma kitabını harici olarak hesaplayıp çözülen değerleri grafik verisine geri yazın.

**Formül dizgileri `=` ile başlamalı mı?**

Aspose.Slides API örnekleri, `B2-C2` veya `SUM(B2:B5)` gibi başında `=` olmayan ifadeler atar. Bu biçimi kullanmak, oluşturulan formüllerin belgelenen API örnekleriyle uyumlu olmasını sağlar.