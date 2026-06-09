---
title: C++ Kullanarak Sunumlarda Grafik Çalışma Sayfası Formüllerini Uygula
linktitle: Çalışma Sayfası Formülleri
type: docs
weight: 70
url: /tr/cpp/chart-worksheet-formulas/
keywords:
- grafik çalışma sayfası
- grafik çalışma sayfası
- grafik formülü
- çalışma sayfası formülü
- elektronik tablo formülü
- veri kaynağı
- mantıksal sabit
- sayısal sabit
- dize sabiti
- hata sabiti
- aritmetik sabit
- karşılaştırma operatörü
- A1 stili
- R1C1 stili
- önceden tanımlı işlev
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides için C++ grafik çalışma sayfalarında Excel tarzı formülleri uygulayın ve PPT ve PPTX dosyalarındaki raporları otomatikleştirin."
---
## **Genel Bakış**

Bir grafik çalışma sayfası, bir sunumdaki grafiğin arkasındaki veri kaynağıdır. Kategori ve seri adlarını, grafiğin gösterdiği sayısal değerlerle birlikte depolar. Aspose.Slides içinde bu çalışma sayfasına grafik veri çalışma kitabı aracılığıyla erişilir ve böylece grafik verileri programlı olarak işlenebilir.

Bu makale, hücre değerlerinin manuel olarak girilmesi yerine otomatik olarak hesaplanıp güncellenebilmesi için grafik verilerinde çalışma sayfası formüllerinin nasıl kullanılacağını açıklar. Formüllerin nasıl atanacağını, hem A1 hem de R1C1 stilindeki referansların nasıl kullanılacağını, çalışma kitabı formüllerinin nasıl yeniden hesaplanacağını ve sunumlardaki grafik çalışma sayfalarında mevcut olan sabitler, operatörler, hücre referansları ve önceden tanımlı işlevler ile nasıl çalışılacağını gösterir.

## **Sunumlardaki Grafik Çalışma Sayfası Formülleri Hakkında**
**Grafik çalışma sayfası** (veya grafik çalışma sayfası) bir sunumdaki grafiğin veri kaynağıdır. Grafik çalışma sayfası, grafikte grafiksel olarak gösterilen verileri içerir. PowerPoint'te bir grafik oluşturduğunuzda bu grafiğe bağlı çalışma sayfası otomatik olarak oluşturulur. Grafik çalışma sayfası tüm grafik türleri için oluşturulur: çizgi grafik, çubuk grafik, sunburst grafik, pasta grafik vb. PowerPoint'te grafik çalışma sayfasını görmek için grafiğe çift tıklamalısınız:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

Grafik çalışma sayfası, grafik öğelerinin adlarını (Kategori Adı: *Category1*, Seri Adı) ve bu kategorilere ve serilere uygun sayısal verileri içeren bir tabloyu barındırır. Varsayılan olarak yeni bir grafik oluşturduğunuzda - grafik çalışma sayfası verileri varsayılan verilerle ayarlanır. Ardından çalışma sayfası verilerini manuel olarak değiştirebilirsiniz.

Genellikle grafik, (ör. finansal analistler, bilimsel analistler) diğer hücrelerdeki değerlerden veya dinamik verilerden hesaplanan hücrelere sahip karmaşık verileri temsil eder. Hücrenin değerini manuel olarak hesaplayıp hücreye sabit kodlamak, gelecekte değişiklik yapmayı zorlaştırır. Belirli bir hücrenin değerini değiştirirseniz, ona bağımlı tüm hücrelerin de güncellenmesi gerekir. Ayrıca tablo verileri diğer tablolardan gelen verilere bağımlı olabilir; bu da sunum veri şemasını karmaşıklaştırır ve kolay ve esnek bir şekilde güncellenmesi gerekir.

Sunumdaki **grafik çalışma sayfası formülü**, grafik çalışma sayfası verilerini otomatik olarak hesaplamak ve güncellemek için kullanılan bir ifadedir. Çalışma sayfası formülü, belirli bir hücre veya hücre kümesi için veri hesaplama mantığını tanımlar. Çalışma sayfası formülü, hücre referansları, matematik işlevleri, mantıksal operatörler, aritmetik operatörler, dönüşüm işlevleri, dize sabitleri vb. kullanan bir matematik ya da mantık formülüdür. Formül tanımı bir hücreye yazılır ve bu hücre basit bir değer içermez. Çalışma sayfası formülü değeri hesaplar ve geri döndürür; ardından bu değer hücreye atanır. Sunumlardaki grafik çalışma sayfası formülleri aslında Excel formülleriyle aynıdır ve uygulanmaları için aynı varsayılan işlevler, operatörler ve sabitler desteklenir.

[**Aspose.Slides**](https://products.aspose.com/slides/tr/cpp/) içinde grafik çalışma sayfası,
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) yöntemiyle
[**IChartDataWorkbook**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.charts.i_chart_data_workbook) türü üzerinden temsil edilir. 
Çalışma sayfası formülü, 
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) yöntemiyle atanabilir ve değiştirilebilir. 
Aspose.Slides içinde formüller için aşağıdaki işlevsellik desteklenir:

- Mantıksal sabitler
- Sayısal sabitler
- Dize sabitleri
- Hata sabitleri
- Aritmetik operatörler
- Karşılaştırma operatörleri
- A1-stili hücre referansları
- R1C1-stili hücre referansları
- Önceden tanımlı işlevler

Genellikle çalışma sayfaları son hesaplanan formül değerlerini saklar. Sunum yüklendikten sonra grafik verileri değiştirilmemişse, **IChartDataCell.get_Value()** yöntemi bu değerleri okurken döndürür. Ancak çalışma sayfası verileri değiştirilmişse, **ChartDataCell.get_Value()** yöntemi desteklenmeyen formüller için **CellUnsupportedDataException** hatası fırlatır. Bunun nedeni, formüller başarıyla ayrıştırıldığında hücre bağımlılıklarının belirlenmesi ve son değerlerin doğruluğunun teyit edilmesidir. Formül ayrıştırılamazsa hücre değerinin doğruluğu garanti edilemez.

## **Sunuma Bir Grafik Çalışma Sayfası Formülü Ekleme**
İlk slayda yeni bir sunumda bir grafik eklemek için 
[IShapeCollection::AddChart()](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_shape_collection#a2cd4d47fc5c536012ee15b3a69486374) 
kullanılır. Grafiğin çalışma sayfası otomatik olarak oluşturulur ve 
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) 
yöntemi ile erişilebilir:

``` cpp
auto presentation = System::MakeObject<Presentation>();
    
auto chart = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 150.0f, 150.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// ...
```

Hücrelere değer yazmak için **Object** türündeki 
[**IChartDataCell.set_Value()**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.charts.i_chart_data_cell#ad85809f520195e09225abae9002635ec) 
yöntemi kullanılabilir; bu, metoda herhangi bir değer geçirebileceğiniz anlamına gelir:

``` cpp
workbook->GetCell(0, u"F2")->set_Value(System::ObjectExt::Box<double>(-2.5));
workbook->GetCell(0, u"G3")->set_Value(System::ObjectExt::Box<double>(6.3));
workbook->GetCell(0, u"H4")->set_Value(System::ObjectExt::Box<int32_t>(3));
```

Şimdi hücreye formül yazmak için 
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) 
yöntemini kullanabilirsiniz:

*Not*: [**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) yöntemi A1-stili hücre referanslarını ayarlamak için kullanılır. 

R1C1Formula hücre referansını ayarlamak için 
[**IChartDataCell::set_R1C1Formula()**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.charts.i_chart_data_cell#a47f5825dd38d0dddb11ecc3a43d388c7) 
yöntemini kullanabilirsiniz:

``` cpp
auto value1 = cell1->get_Value(); // 7.8
auto value2 = cell2->get_Value(); // 2.1
```

## **Mantıksal Sabitler**
Formüllerde *FALSE* ve *TRUE* gibi mantıksal sabitler kullanılabilir:

## **Sayısal Sabitler**
Sayılar, grafik çalışma sayfası formülü oluşturmak için ortak ya da bilimsel gösterimde kullanılabilir:

## **Dize Sabitleri**
Dize (veya literal) sabiti, olduğu gibi kullanılan ve değişmeyen bir değerdir. Dize sabitleri şunlar olabilir: tarihler, metinler, sayılar vb.:

## **Hata Sabitleri**
Bazen formül sonucu hesaplanamaz. Bu durumda hücrede değer yerine bir hata kodu gösterilir. Her hata türünün belirli bir kodu vardır:

- #DIV/0! – formül sıfıra bölmeye çalışıyor.
- #GETTING_DATA – hücrenin değeri hâlâ hesaplanırken gösterilebilir.
- #N/A – bilgi eksik veya mevcut değil. Nedenler: formülde kullanılan hücreler boş, ekstra boşluk karakteri, yazım hatası vb.
- #NAME? – belirli bir hücre ya da diğer formül nesneleri adıyla bulunamıyor.
- #NULL! – formülde (, ) gibi bir hata oluştuğunda ya da iki nokta üst üste (:) yerine boşluk karakteri kullanıldığında ortaya çıkabilir.
- #NUM! – formüldeki sayısal değer geçersiz, çok uzun veya çok kısa olabilir.
- #REF! – geçersiz hücre referansı.
- #VALUE! – beklenmeyen değer türü. Örneğin, sayısal bir hücreye dize değeri atanmışsa.

## **Aritmetik Operatörler**
Grafik çalışma sayfası formüllerinde tüm aritmetik operatörler kullanılabilir:

|**Operatör**|**Anlamı**|**Örnek**|
| :- | :- | :- |
|+ (artı işareti)|Toplama veya tekli artı|2 + 3|
|- (eksi işareti)|Çıkarma veya eksi|2 - 3<br>-3|
|* (asterisk)|Çarpma|2 * 3|
|/ (bölü işareti)|Bölme|2 / 3|
|% (yüzde işareti)|Yüzde|30%|
|^ (caret)|Üs alma|2 ^ 3|

*Not*: Değerlendirme sırasını değiştirmek için, önce hesaplanacak formül kısmını parantez içine koyun.

## **Karşılaştırma Operatörleri**
Hücre değerlerini karşılaştırma operatörleriyle karşılaştırabilirsiniz. Bu operatörler kullanıldığında sonuç mantıksal bir değer (*TRUE* ya da *FALSE*) olur:

|**Operatör**|**Anlamı**|**Örnek**|
| :- | :- | :- |
|= (eşittir)|Eşit|A2 = 3|
|<> (eşit değildir)|Eşit değildir|A2 <> 3|
|> (büyüktür)|Büyük|A2 > 3|
|>= (büyük veya eşittir)|Büyük veya eşit|A2 >= 3|
|< (küçüktür)|Küçük|A2 < 3|
|<= (küçük veya eşittir)|Küçük veya eşit|A2 <= 3|

## **A1-Stili Hücre Referansları**
**A1-stili hücre referansları**, sütunun harf kimliği (ör. "*A*") ve satırın sayısal kimliği (ör. "*1*") olduğu çalışma sayfalarında kullanılır. A1-stili hücre referansları aşağıdaki şekilde kullanılabilir:

|**Hücre referansı**|**Mutlak**|**Göreceli**|**Karışık**|
| :- | :- | :- | :- |
|Hücre|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Satır|$2:$2|2:2|-|
|Sütun|$A:$A|A:A|-|
|Aralık|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Aşağıda A1-stili hücre referansının formülde nasıl kullanılacağına bir örnek verilmiştir:

## **R1C1-Stili Hücre Referansları**
**R1C1-stili hücre referansları**, hem satır hem de sütunun sayısal kimliği olduğu çalışma sayfalarında kullanılır. R1C1-stili hücre referansları aşağıdaki şekilde kullanılabilir:

|**Hücre referansı**|**Mutlak**|**Göreceli**|**Karışık**|
| :- | :- | :- | :- |
|Hücre|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Satır|R2|R[2]|-|
|Sütun|C3|C[3]|-|
|Aralık|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Aşağıda A1-stili hücre referansının formülde nasıl kullanılacağına bir örnek verilmiştir:

## **Önceden Tanımlı İşlevler**
Formüllerde kullanılabilecek, uygulanmalarını basitleştiren önceden tanımlı işlevler vardır. Bu işlevler en yaygın kullanılan işlemleri kapsar, örneğin:

- ABS
- AVERAGE
- CEILING
- CHOOSE
- CONCAT
- CONCATENATE
- DATE (1900 tarih sistemi)
- DAYS
- FIND
- FINDB
- IF
- INDEX (referans formu)
- LOOKUP (vektör formu)
- MATCH (vektör formu)
- MAX
- SUM
- VLOOKUP

## **SSS**

**Formüllü bir grafik için dış Excel dosyaları veri kaynağı olarak destekleniyor mu?**

Evet. Aspose.Slides, bir grafiğin veri kaynağı olarak dış çalışma kitaplarını destekler([chart's data source](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/chartdatasourcetype/)), bu da sunum dışındaki bir XLSX dosyasındaki formüllerin kullanılmasını sağlar.

**Grafik formülleri aynı çalışma kitabındaki sayfa adlarıyla referans verebilir mi?**

Evet. Formüller standart Excel referans modelini izler, bu yüzden aynı çalışma kitabındaki ya da dış bir çalışma kitabındaki diğer sayfalara referans verebilirsiniz. Dış referanslar için Excel sözdizimini kullanarak yol ve çalışma kitabı adını ekleyin.