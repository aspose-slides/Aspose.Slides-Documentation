---
title: C++ Kullanarak Sunumlarda Grafik Çalışma Sayfası Formüllerini Uygulama
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
description: "Aspose.Slides for C++ grafik çalışma sayfalarında Excel benzeri formülleri uygulayın ve PPT ve PPTX dosyaları arasında raporları otomatikleştirin."
---
## **Genel Bakış**

Bir grafik çalışma sayfası, bir sunumdaki grafiğin veri kaynağıdır. Kategori ve seri adlarını, grafiğin gösterdiği sayısal değerlerle birlikte depolar. Aspose.Slides içinde bu çalışma sayfasına grafik veri çalışma kitabı aracılığıyla erişilir; bu sayede grafik verileri programlı olarak işlenebilir.

Bu makale, hücre değerlerinin manuel olarak girilmesi yerine otomatik olarak hesaplanıp güncellenebilmesi için grafik verilerinde çalışma sayfası formüllerinin nasıl kullanılacağını açıklar. Formüllerin nasıl atanacağını, A1‑stili ve R1C1‑stili başvuruların nasıl kullanılacağını, çalışma kitabı formüllerinin nasıl yeniden hesaplanacağını ve sunumlardaki grafik çalışma sayfalarında kullanılan desteklenen sabitler, operatörler, hücre başvuruları ve önceden tanımlı işlevler hakkında bilgi verir.

## **Sunumlardaki Grafik Çalışma Sayfası Formülleri Hakkında**
**Grafik çalışma sayfası** (veya grafik çalışma sayfası) bir sunumdaki grafiğin veri kaynağıdır. Grafik çalışma sayfası, grafiğin grafiksel olarak temsil edildiği verileri içerir. PowerPoint’te bir grafik oluşturduğunuzda, bu grafikle ilişkili çalışma sayfası da otomatik olarak oluşturulur. Grafik çalışma sayfası, çizgi grafik, çubuk grafik, sunburst grafik, pasta grafik vb. tüm grafik türleri için oluşturulur. PowerPoint’te grafik çalışma sayfasını görmek için grafiğe çift tıklamalısınız:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

Grafik çalışma sayfası, grafik öğelerinin adlarını (Kategori Adı: *Category1*, Seri Adı) ve bu kategorilere ve serilere uygun sayısal veri tablosunu içerir. Varsayılan olarak, yeni bir grafik oluşturduğunuzda – grafik çalışma sayfası verileri varsayılan verilerle ayarlanır. Ardından çalışma sayfasındaki verileri manuel olarak değiştirebilirsiniz.

Genellikle grafik, karmaşık verileri (ör. finansal analizler, bilimsel analizler) temsil eder; bu veriler diğer hücrelerdeki değerlerden veya diğer dinamik verilerden hesaplanır. Hücrenin değerini manuel olarak hesaplayıp sabit kodlamak, gelecekte değiştirildiğinde zorluk yaratır. Belirli bir hücrenin değeri değiştirildiğinde, ona bağımlı tüm hücrelerin de güncellenmesi gerekir. Ayrıca tablo verileri diğer tablolardan gelen verilere bağımlı olabilir; bu da güncellenmesi kolay ve esnek bir sunum veri şeması gerektirir.

**Grafik çalışma sayfası formülü**, grafik çalışma sayfası verilerini otomatik olarak hesaplamak ve güncellemek için bir ifadedir. Çalışma sayfası formülü, belirli bir hücre veya hücre kümesi için veri hesaplama mantığını tanımlar. Çalışma sayfası formülü, hücre başvuruları, matematik işlevleri, mantıksal operatörler, aritmetik operatörler, dönüşüm işlevleri, dize sabitleri vb. kullanan bir matematik veya mantıksal formüldür. Formül tanımı bir hücreye yazılır ve bu hücre basit bir değer içermez. Çalışma sayfası formülü değeri hesaplar ve geri döner; ardından bu değer hücreye atanır. Sunumlardaki grafik çalışma sayfası formülleri, Excel formülleri ile aynıdır ve aynı varsayılan işlevler, operatörler ve sabitler desteklenir.

[**Aspose.Slides**](https://products.aspose.com/slides/tr/cpp/) içinde grafik çalışma sayfası,
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea) yöntemiyle temsil edilir. 
Çalışma sayfası formülü, 
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) yöntemiyle atanabilir ve değiştirilebilir. 
Aspose.Slides’te formüller için aşağıdaki işlevsellik desteklenir:

- Mantıksal sabitler
- Sayısal sabitler
- Dize sabitleri
- Hata sabitleri
- Aritmetik operatörler
- Karşılaştırma operatörleri
- A1‑stili hücre başvuruları
- R1C1‑stili hücre başvuruları
- Önceden tanımlı işlevler



Genellikle çalışma sayfaları son hesaplanan formül değerlerini saklar. Sunum yüklendikten sonra grafik verileri değiştirilmemişse – **IChartDataCell.get_Value()** yöntemi bu değerleri okuma sırasında döndürür. Ancak çalışma sayfası verileri değiştirilmişse, **ChartDataCell.get_Value()** yöntemi desteklenmeyen formüller için **CellUnsupportedDataException** hatası fırlatır. Bunun nedeni, formüller başarıyla ayrıştırıldığında hücre bağımlılıklarının belirlendiği ve son değerlerin doğruluğunun kontrol edildiğidir. Formül ayrıştırılamazsa, hücre değerinin doğruluğu garanti edilemez.


## **Sunuma Bir Grafik Çalışma Sayfası Formülü Ekleme**
İlk olarak, yeni bir sunumun ilk slaytına bir grafik ekleyin:
[IShapeCollection::AddChart()](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.i_shape_collection#a2cd4d47fc5c536012ee15b3a69486374). 
Grafiğin çalışma sayfası otomatik olarak oluşturulur ve şu yöntemle erişilebilir:
[**ChartData::get_ChartDataWorkbook()**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.charts.chart_data#a32097093561723a10df0a57dc91acaea):

``` cpp
auto presentation = System::MakeObject<Presentation>();
    
auto chart = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 150.0f, 150.0f, 500.0f, 300.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// ...
```

Bazı hücrelere değer yazmak için **Object** türündeki 
[**IChartDataCell.set_Value()**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.charts.i_chart_data_cell#ad85809f520195e09225abae9002635ec) yöntemini kullanabilirsiniz; bu, metoda herhangi bir değer geçirebileceğiniz anlamına gelir:

``` cpp
workbook->GetCell(0, u"F2")->set_Value(System::ObjectExt::Box<double>(-2.5));
workbook->GetCell(0, u"G3")->set_Value(System::ObjectExt::Box<double>(6.3));
workbook->GetCell(0, u"H4")->set_Value(System::ObjectExt::Box<int32_t>(3));
```

Şimdi hücreye formül yazmak için 
[**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) yöntemini kullanabilirsiniz:

*Not*: [**IChartDataCell::set_Formula()**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.charts.i_chart_data_cell#a6806c6a40e025e6834c4c5f3af3cf692) yöntemi A1‑stili hücre başvurularını ayarlamak için kullanılır.

R1C1Formula hücre başvurusunu ayarlamak için 
[**IChartDataCell::set_R1C1Formula()**](https://reference.aspose.com/slides/tr/cpp/class/aspose.slides.charts.i_chart_data_cell#a47f5825dd38d0dddb11ecc3a43d388c7) yöntemini kullanabilirsiniz:

Bu işlemden sonra B2 ve C2 hücrelerinin değerlerini okursanız, değerler hesaplanmış olur:

``` cpp
auto value1 = cell1->get_Value(); // 7.8
auto value2 = cell2->get_Value(); // 2.1
```


## **Mantıksal Sabitler**
Hücre formüllerinde *FALSE* ve *TRUE* gibi mantıksal sabitler kullanılabilir:


## **Sayısal Sabitler**
Sayılar, ortak veya bilimsel gösterimlerle grafik çalışma sayfası formülü oluşturmak için kullanılabilir:


## **Dize Sabitleri**
Dize (ya da literal) sabiti, olduğu gibi kullanılan ve değişmeyen bir değerdir. Dize sabitleri şunlar olabilir: tarih, metin, sayı vb.:

## **Hata Sabitleri**
Bazen formülle sonucun hesaplanması mümkün olmayabilir. Bu durumda hücrede değeri yerine hata kodu gösterilir. Her hata türünün özgü bir kodu vardır:

- #DIV/0! – formül sıfıra bölmeye çalışır.
- #GETTING_DATA – değer hâlâ hesaplanırken hücrede görünebilir.
- #N/A – bilgi eksik veya mevcut değil. Nedenler: formülde kullanılan hücre boş, fazladan boşluk karakteri, yazım hatası vb.
- #NAME? – belirli bir hücre ya da diğer formül nesnesi adıyla bulunamıyor.
- #NULL! – formülde (, ) gibi yanlış bir karakter ya da iki nokta (:) yerine boşluk kullanılması.
- #NUM! – formüldeki sayısal değer geçersiz, çok uzun veya çok küçük vb.
- #REF! – geçersiz hücre başvurusu.
- #VALUE! – beklenmedik değer türü. Örneğin, metin değeri sayısal bir hücreye atanmış.



## **Aritmetik Operatörler**
Grafik çalışma sayfası formüllerinde tüm aritmetik operatörler kullanılabilir:

|**Operatör**|**Anlam**|**Örnek**|
| :- | :- | :- |
|+ (artı işareti)|Toplama veya tekli artı|2 + 3|
|- (eksi işareti)|Çıkarma veya negatif|2 - 3<br>-3|
|* (yıldız)|Çarpma|2 * 3|
|/ (bölü işareti)|Bölme|2 / 3|
|% (yüzde işareti)|Yüzde|30%|
|^ (üst işareti)|Üs alma|2 ^ 3|

*Not*: Değerlendirme sırasını değiştirmek için formülün önce hesaplanması gereken kısmını parantez içine alın.


## **Karşılaştırma Operatörleri**
Hücre değerlerini karşılaştırma operatörleriyle kıyaslayabilirsiniz. Bu operatörler kullanıldığında sonuç *TRUE* ya da *FALSE* mantıksal bir değer olur:

|**Operatör**|**Anlam**|**Örnek**|
| :- | :- | :- |
|= (eşittir)|Eşit|A2 = 3|
|<> (eşit değil)|Eşit değil|A2 <> 3|
|> (büyük)|Büyük|A2 > 3|
|>= (büyük veya eşit)|Büyük veya eşit|A2 >= 3|
|< (küçük)|Küçük|A2 < 3|
|<= (küçük veya eşit)|Küçük veya eşit|A2 <= 3|

## **A1‑Stili Hücre Başvuruları**
**A1‑stili hücre başvuruları**, sütunun harf (ör. "*A*") ve satırın sayı (ör. "*1*") ile tanımlandığı çalışma sayfalarında kullanılır. A1‑stili başvurular aşağıdaki şekilde kullanılabilir:

|**Hücre başvurusu**|**Örnek**| | |
| :- | :- | :- | :- |
| |Mutlak|Göreli|Karışık|
|Hücre|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Satır|$2:$2|2:2|-|
|Sütun|$A:$A|A:A|-|
|Aralık|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

Aşağıda A1‑stili hücre başvurusunun formül içinde nasıl kullanılacağına bir örnek verilmiştir:

## **R1C1‑Stili Hücre Başvuruları**
**R1C1‑stili hücre başvuruları**, hem satır hem de sütunun sayısal kimliği olduğu çalışma sayfalarında kullanılır. R1C1‑stili başvurular aşağıdaki şekilde kullanılabilir:

|**Hücre başvurusu**|**Örnek**| | |
| :- | :- | :- | :- |
| |Mutlak|Göreli|Karışık|
|Hücre|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Satır|R2|R[2]|-|
|Sütun|C3|C[3]|-|
|Aralık|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

Aşağıda formül içinde A1‑stili hücre başvurusunun nasıl kullanılacağına bir örnek verilmiştir:

## **Önceden Tanımlı İşlevler**
Formüllerde kullanımını kolaylaştırmak için önceden tanımlı işlevler bulunur. Bu işlevler en yaygın kullanılan işlemleri kapsar, örneğin:

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

**Formüllü bir grafik için harici Excel dosyaları veri kaynağı olarak destekleniyor mu?**

Evet. Aspose.Slides, bir [grafiğin veri kaynağı](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/chartdatasourcetype/) olarak harici çalışma kitaplarını destekler; bu sayede sunum dışındaki bir XLSX dosyasından formüller kullanılabilir.

**Grafik formülleri, aynı çalışma kitabındaki sayfalara sayfa adıyla başvurabilir mi?**

Evet. Formüller standart Excel referans modelini izler, bu yüzden aynı çalışma kitabındaki diğer sayfalara ya da harici bir çalışma kitabına başvurabilirsiniz. Harici başvurular için Excel sözdizimini kullanarak yol ve çalışma kitabı adını eklemelisiniz.