---
title: C++ kullanarak Sunumlarda Grafik Çalışma Sayfası Formüllerini Uygulama
linktitle: Çalışma Sayfası Formülleri
type: docs
weight: 70
url: /tr/cpp/chart-worksheet-formulas/
keywords:
- grafik elektronik tablosu
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ grafik çalışma sayfalarında Excel tarzı formülleri uygulayın, değerleri yeniden hesaplayın ve sonuçları PowerPoint grafiklerinde kullanın."
---
## **Genel Bakış**

PowerPoint grafikler genellikle kaynak verilerini gömülü bir çalışma sayfasında saklar. Aspose.Slides for C++'ta bu çalışma sayfasına grafik veri çalışma kitabı aracılığıyla erişebilir, giriş değerleri yazabilir, hücrelere formüller atayabilir, desteklenen formülleri hesaplayabilir ve hesaplanmış hücreleri grafik verisi olarak kullanabilirsiniz.

Bu makale tam formül iş akışını açıklar: bir grafik oluşturma, çalışma sayfasını doldurma, A1‑stili veya R1C1‑stili formüller atama, bunları yeniden hesaplama, hesaplanmış değerleri okuma, bu hücreleri bir grafik serisine bağlama ve sunumu kaydetme. Ayrıca desteklenen formül sözdizimini, yerleşik işlev alt kümesini, önbelleğe alınmış değerleri, desteklenmeyen formülleri ve elektronik tabloya özgü hataları tanımlar.

## **Grafik Çalışma Sayfaları ve Formüller**

Bir grafik çalışma sayfası, bir grafik tarafından kullanılan kategorileri, seri adlarını ve değerleri içerir. PowerPoint'te grafik veri düzenleyicisini açarak çalışma sayfasını inceleyebilirsiniz:

![PowerPoint grafiği gömülü çalışma sayfası açık, kategori ve seri verilerini gösteriyor](chart-worksheet-formulas_1.png)

Aspose.Slides'te çalışma sayfası, [IChartDataWorkbook](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdataworkbook/) arabirimi üzerinden sunulur. A1‑stili formüller için [IChartDataCell::set_Formula](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatacell/set_formula/) ve R1C1‑stili formüller için [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) kullanın. Giriş hücrelerini veya formülleri değiştirdikten sonra, desteklenen formülleri yeniden hesaplamak ve ilgili hücre değerlerini güncellemek için [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) çağırın.

Hesaplanmış bir hücre, sonucunu hâlâ [IChartDataCell::get_Value](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatacell/get_value/) aracılığıyla sunar. Bu, kod içinde bir formül sonucunu incelemeniz veya hücreyi bir grafik veri noktası olarak kullanmanız gerektiğinde önemlidir.

## **Bir Grafik Oluşturma ve Çalışma Sayfası Formüllerini Hesaplama**

Aşağıdaki örnek uçtan uca bir iş akışını gösterir. Bir kümelenmiş sütun grafiği oluşturur, örnek verileri temizler, çeyrek bazında gelir ve gider değerleri yazar, formüllerle karı hesaplar, sonuçları okur, hesaplanmış hücreleri grafik değerleri olarak kullanır ve sunumu kaydeder.

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

Grafik veri noktaları `D2:D4` aralığını referans alır, dolayısıyla grafik hesaplanmış kar değerlerini kullanır. Bu iş akışında ayrı bir grafik‑yenileme çağrısı yoktur: önce çalışma kitabını yeniden hesaplayın, ardından hesaplanmış hücrelere işaret eden grafik verisini kullanın veya kaydedin.

## **A1‑Stili Formüller Kullanma**

A1 gösterimi sütunları harf, satırları sayı ile tanımlar. A1‑stili ifadeleri [IChartDataCell::set_Formula](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatacell/set_formula/) aracılığıyla atayın.

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

Yaygın A1 referans biçimleri:

| Referans | Göreceli | Mutlak | Karışık |
|---|---|---|---|
| Hücre | `A2` | `$A$2` | `A$2`, `$A2` |
| Satır | `2:2` | `$2:$2` | — |
| Sütun | `A:A` | `$A:$A` | — |
| Aralık | `A2:C4` | `$A$2:$C$4` | `A$2:$C4`, `$A2:C$4` |

Göreceli referanslar, bir formül bir elektronik tablo uygulaması tarafından taşındığında veya kopyalandığında değişebilir. Mutlak referanslar her iki koordinatı da sabit tutar, karışık referanslar ise yalnızca satırı ya da sütunu sabitler.

## **R1C1‑Stili Formüller Kullanma**

R1C1 gösterimi hem satırları hem sütunları sayısal olarak tanımlar. Göreceli referanslar köşeli parantez içinde offset kullanır. Bu sözdizimini [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) aracılığıyla atayın.

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

Yaygın R1C1 referans biçimleri:

| Referans | Göreceli | Mutlak | Karışık |
|---|---|---|---|
| Hücre | `R[2]C[3]` | `R2C3` | `R2C[3]`, `R[2]C3` |
| Satır | `R[2]` | `R2` | — |
| Sütun | `C[3]` | `C3` | — |
| Aralık | `R[2]C[3]:R[5]C[7]` | `R2C3:R5C7` | `R2C3:R[5]C[7]`, `R[2]C3:R5C[7]` |

Örneğin, `D2` hücresinde `RC[-2]` aynı satırda iki sütun sola (`B2`) olan hücreyi ifade eder.

## **Formül Sabitleri ve Operatörleri**

Yerleşik formül değerlendiricisi mantıksal değerleri, sayısal sabitleri, metinleri, elektronik tablo hata değerlerini, aritmetik operatörleri ve karşılaştırma operatörlerini destekler.

### **Sabitler ve Sabit Değerler**

| Tür | Örnekler | Notlar |
|---|---|---|
| Mantıksal | `TRUE`, `FALSE` | `A2=TRUE` gibi mantıksal ifadelerde doğrudan kullanılabilir. |
| Sayısal | `1`, `0.5`, `.3`, `1E-2` | Kesirli ve bilimsel gösterimler desteklenir. |
| Metin | `"abc"`, `"2/3/2020 12:00"` | Metin sabitleri formül içinde çift tırnak içinde yer alır. |
| Hata sonucu | `#DIV/0!`, `#N/A`, `#REF!` | Geçerli bir formül, normal bir sonuç yerine bir elektronik tablo hata değeri döndürebilir. |

Bu örnek birkaç sabit türünü gösterir:

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

Aspose.Slides, grafik çalışma sayfaları için yerleşik bir formül değerlendiricisi sunar, ancak bu tam bir Excel hesaplama motoru değildir. Belgelendirilmiş işlev kümesi aşağıdaki ile sınırlıdır. [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) aracılığıyla rastgele bir Excel işlevinin yeniden hesaplanabileceğini varsaymayın.

| İşlev | Amaç veya desteklenen biçim | Örnek |
|---|---|---|
| `ABS` | Mutlak değer | `ABS(A2)` |
| `AVERAGE` | Aritmetik ortalama | `AVERAGE(B2:B5)` |
| `CEILING` | Sayıyı yukarı doğru bir katına yuvarla | `CEILING(A2,5)` |
| `CHOOSE` | İndeksle değer seç | `CHOOSE(A2,"Low","High")` |
| `CONCAT` | Metin değerlerini birleştir | `CONCAT(A2,B2)` |
| `CONCATENATE` | Metin değerlerini birleştir | `CONCATENATE(A2," ",B2)` |
| `DATE` | 1900 tarih sistemini kullanarak tarih değeri oluştur | `DATE(2026,8,19)` |
| `DAYS` | İki tarih arasındaki gün sayısını döndür | `DAYS(B2,A2)` |
| `FIND` | Bir metin içinde başka bir metin bul | `FIND("-",A2)` |
| `FINDB` | Bayt‑bazlı metin arama | `FINDB("a",A2)` |
| `IF` | Koşullu sonuç | `IF(A2>0,A2,0)` |
| `INDEX` | Referans biçimi | `INDEX(A2:C4,2,3)` |
| `LOOKUP` | Vektör biçimi | `LOOKUP(A2,B2:B5,C2:C5)` |
| `MATCH` | Vektör biçimi | `MATCH(A2,B2:B5,0)` |
| `MAX` | En büyük değer | `MAX(B2:B5)` |
| `SUM` | Toplam | `SUM(B2:B5)` |
| `VLOOKUP` | Dikey arama | `VLOOKUP(A2,B2:D10,3,FALSE)` |

Tabloda gösterilen kısıtlamalar önemlidir: `INDEX` referans biçiminde, `LOOKUP` ve `MATCH` ise vektör biçimindedir. `DATE` 1900 tarih sistemini kullanır. Burada listelenmeyen özellik ve işlevler, ayrı olarak belgelenmedikçe Aspose.Slides formül değerlendiricisi tarafından desteklenmez.

## **Tercih Edilen Kültürle Formülleri Hesaplama**

Bazı grafik çalışma kitabı işlevleri, metni kültüre özgü kurallara göre yorumlar. Bu, çift bayt karakter seti (DBCS) kullanan diller için özellikle önemlidir. Bu tür formülleri doğru hesaplamak için [LoadOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/) oluşturun, [LoadOptions::set_SpreadsheetOptions](https://reference.aspose.com/slides/tr/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/) üzerinden [ISpreadsheetOptions::set_PreferredCulture](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ispreadsheetoptions/set_preferredculture/) yapılandırın ve ardından sunumu yükleyin.

Aşağıdaki örnek Japon kültürünü seçer, yapılandırılmış yükleme seçenekleriyle bir sunumu açar ve her grafik çalışma kitabı için [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) çağırır:

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/SpreadsheetOptions.h>
#include <system/globalization/culture_info.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;
using namespace System::Globalization;

auto japaneseCulture = CultureInfo::GetCultureInfo(u"ja-JP");

auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_PreferredCulture(japaneseCulture);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);

for (int32_t slideIndex = 0; slideIndex < presentation->get_Slides()->get_Count(); slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);

    for (int32_t shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); shapeIndex++)
    {
        auto shape = slide->get_Shape(shapeIndex);
        if (ObjectExt::Is<IChart>(shape))
        {
            auto chart = ExplicitCast<IChart>(shape);
            chart->get_ChartData()->get_ChartDataWorkbook()->CalculateFormulas();
        }
    }
}
```

Tercih edilen kültür, sunum yükleme yapılandırmasının bir parçasıdır; bu yüzden [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) örneğini oluşturmadan önce belirtin. İşlevlerin beklediği kültürü kullanın; örneğin Japon DBCS hesaplama kurallarını izleyen formüller için `ja-JP` kullanın.

## **Yeniden Hesaplama ve Önbelleğe Alınmış Değerler**

Elektronik tablo dosyaları genellikle bir formül ve onun son hesaplanmış değerini birlikte depolar. Aspose.Slides, bir sunum yüklendiğinde ve ilgili grafik verileri değişmemişse, [IChartDataCell::get_Value](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatacell/get_value/) üzerinden önbelleğe alınmış bir değeri okuyabilir.

Giriş hücrelerini veya formülleri değiştirdikten sonra eski önbellek sonucuna güvenmeyin. Hesaplanmış değerleri okumadan veya onlara bağımlı grafik verisini kaydetmeden önce [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) çağırın.

Desteklenen alt kümenin dışındaki formüller için Aspose.Slides formülü ayrıştırmakta veya bağımlılıklarını belirlemekte zorlanabilir. Çalışma kitabı değiştirilmişse, önceki önbellek değeri artık güvenilir kabul edilemez. Bu durumda, desteklenmeyen veri içeren bir hücrenin değerini okumak [CellUnsupportedDataException](https://reference.aspose.com/slides/tr/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/) hatasına neden olabilir.

Grafiğiniz Aspose.Slides tarafından değerlendirilmemiş Excel işlevlerine dayanıyorsa, bu formülleri destekleyen bir elektronik tablo motoru ile hesaplayıp sonuçları grafik çalışma kitabına geri yazın. Desteklenmeyen formülleri tahmini değerlerle değiştirmeyin.

## **Formül Hatalarını İşleme**

İki farklı sorun türü vardır.

Bir formül geçerli olabilir ancak `#DIV/0!`, `#N/A`, `#NAME?`, `#NULL!`, `#NUM!`, `#REF!` veya `#VALUE!` gibi bir elektronik tablo hata sonucu üretebilir. Bu durumda hata simgesi bir hücre sonucu olarak kabul edilir ve [IChartDataCell::get_Value](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatacell/get_value/) üzerinden döndürülebilir.

Bir formül aynı zamanda ayrıştırma, referans, bağımlılık veya desteklenen veri düzeyinde başarısız olabilir. Aspose.Slides bu durumlar için elektronik tablo‑özel istisnalar sağlar: [CellInvalidFormulaException](https://reference.aspose.com/slides/tr/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/), [CellInvalidReferenceException](https://reference.aspose.com/slides/tr/cpp/aspose.slides.spreadsheet/cellinvalidreferenceexception/), [CellCircularReferenceException](https://reference.aspose.com/slides/tr/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) ve [CellUnsupportedDataException](https://reference.aspose.com/slides/tr/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/).

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
    // Geçersiz bir formülü işleyin.
}
catch (CellInvalidReferenceException&)
{
    // Geçersiz bir hücre referansını işleyin.
}
catch (CellCircularReferenceException&)
{
    // Dairesel referansı işleyin.
}
catch (CellUnsupportedDataException&)
{
    // Desteklenmeyen elektronik tablo verisini işleyin.
}
```

## **Pratik Sınırlamalar**

Grafik çalışma sayfalarındaki formül desteği, tam Excel uyumluluğu yerine tanımlı bir elektronik tablo hesaplama alt kümesi için tasarlanmıştır. Raporlama iş akışınızı tasarlarken şu kısıtlamaları göz önünde bulundurun:

- Aspose.Slides'ın formülleri yeniden hesaplamasını istediğinizde yalnızca belgelenmiş sabitleri, operatörleri, referansları ve işlevleri kullanın.
- Formül sonuçlarının bağımlı olduğu hücreleri değiştirdikten sonra yeniden hesaplayın.
- Yüklenen sunumlardan gelen önbelleğe alınmış değerleri anlık görüntü olarak değerlendirin; düzenlemelerden sonra yeniden hesaplamayı ihmal etmeyin.
- Mevcut şablonlardaki formülleri, belgelenmiş listedeki işlevler dışındakileri kullanmadan önce test edin.
- Tam bir elektronik tablo hesaplama motoru gerektiren formüller için dışarıda hesaplayıp ardından grafik çalışma kitabını güncelleyin.

## **SSS**

**`set_Formula` ile `set_R1C1Formula` arasındaki fark nedir?**

[IChartDataCell::set_Formula](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatacell/set_formula/) `B2-C2` gibi bir A1‑stili ifadeyi saklar. [IChartDataCell::set_R1C1Formula](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatacell/set_r1c1formula/) ise `RC[-2]-RC[-1]` gibi bir R1C1‑stili ifadeyi saklar. Formülleri nasıl ürettiğinize veya kopyaladığınıza bağlı olarak uygun gösterimi kullanın.

**Hesaplamadan sonra hücreyi mi yoksa değerini mi okumam gerekir?**

[IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) bir `IChartDataCell` döndürür. Hesaplamadan sonra, o hücrenin [IChartDataCell::get_Value](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatacell/get_value/) değerini okuyarak hesaplanmış sonucu elde edebilirsiniz.

**`CalculateFormulas` ne zaman çağrılmalı?**

Giriş değerlerini veya formülleri değiştirdikten sonra ve hesaplanmış sonuçlara bağımlı olmadan önce [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) çağırın. Bu, yerleşik değerlendiricinin desteklediği formüllerin değerlerini günceller.

**Aspose.Slides her Excel işlevini destekliyor mu?**

Hayır. Yerleşik değerlendirici belgelenmiş bir işlev alt kümesini destekler. Bu alt kümenin dışındaki işlevlerin doğru şekilde yeniden hesaplanacağını varsaymayın. Tam Excel formül uyumluluğu gerekiyorsa, hesaplamayı uygun bir elektronik tablo motoruyla yapıp sonuçları grafik çalışma kitabına yazın.

**Yüklenmiş bir sunumda desteklenmeyen bir formül varsa ne olur?**

Grafik verileri değişmemişse, çalışma kitabı hâlâ daha önce hesaplanmış bir önbellek değerine sahip olabilir. İlgili veri değiştirildiğinde bu önbellek değeri geçersiz kalabilir. Formülü işleyemeyen bir hücreye erişim, [CellUnsupportedDataException](https://reference.aspose.com/slides/tr/cpp/aspose.slides.spreadsheet/cellunsupporteddataexception/) hatasına yol açabilir.

**Formül hata değerleri C++ istisnalarıyla aynı şey mi?**

Hayır. `#DIV/0!` gibi bir sonuç, geçerli bir hesaplamanın ürettiği bir elektronik tablo değeridir. [CellInvalidFormulaException](https://reference.aspose.com/slides/tr/cpp/aspose.slides.spreadsheet/cellinvalidformulaexception/) veya [CellCircularReferenceException](https://reference.aspose.com/slides/tr/cpp/aspose.slides.spreadsheet/cellcircularreferenceexception/) gibi istisnalar ise formülün normal olarak işlenemediğini gösterir.

**Bir formül hücresi değiştiğinde grafik otomatik olarak güncellenir mi?**

Bir grafik serisi çalışma kitabı hücrelerine referans verebilir. Önce çalışma kitabını yeniden hesaplayın, ardından sunumu kaydedin veya render edin. Grafik veri noktaları hesaplanmış hücrelere işaret ediyorsa, grafik bu güncel hücre değerlerini kullanır; bu iş akışı için ayrı bir grafik‑yenileme yöntemi gerekmez.

**Grafikler harici bir Excel çalışma kitabı kullanabilir mi?**

Evet, grafik verileri harici bir çalışma kitabı kullanacak şekilde yapılandırılabilir. Ancak bu makalede anlatılan formül hesaplama iş akışı, yalnızca grafik veri çalışma kitabı ve Aspose.Slides tarafından değerlendirilen formül alt kümesiyle ilgilidir. [IChartDataWorkbook::CalculateFormulas](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdataworkbook/calculateformulas/) metodunun harici bir XLSX dosyasındaki rastgele formülleri tam olarak yeniden hesaplayacağını varsaymayın.

**Başka bir çalışma sayfasına veya çalışma kitabına referans veren formüller kullanabilir miyim?**

Excel‑stili referanslar grafik çalışma kitaplarında bulunabilir, ancak formül değerlendirmesi desteklenen ayrıştırıcı ve işlev seti ile sınırlıdır. Çapraz‑sayfa veya harici referans zorunluysa, hedef Aspose.Slides sürümünüzde tam olarak doğrulayın. Geniş Excel referans uyumluluğu gerektiren iş akışları için, çalışma kitabını dışarıda hesaplayıp çözülen değerleri grafik verisine geri yazın.

**Formül dizeleri `=` ile mi başlamalı?**

Aspose.Slides API örnekleri, `B2-C2` veya `SUM(B2:B5)` gibi başında `=` olmayan ifadeler atar. Bu biçimi kullanmak, oluşturulan formüllerin API örnekleriyle tutarlı olmasını sağlar.