---
title: Python ile Sunumlarda Grafik Çalışma Sayfası Formüllerini Uygulayın
linktitle: Çalışma Sayfası Formülleri
type: docs
weight: 70
url: /tr/python-net/chart-worksheet-formulas/
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
- ön tanımlı işlev
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python’da .NET grafik çalışma sayfaları aracılığıyla Excel tarzı formülleri uygulayın ve PPT, PPTX ve ODP dosyaları arasında raporları otomatikleştirin."
---
## **Genel Bakış**

Bir grafik çalışma sayfası, bir sunumdaki grafiğin veri kaynağıdır. Kategori ve seri adlarını, grafiğin görüntülediği sayısal değerlerle birlikte depolar. Aspose.Slides'te bu çalışma sayfasına grafik veri çalışma kitabı üzerinden erişilir; bu sayede grafik verileri programlı olarak işlenebilir.

Bu makale, hücre değerlerinin manuel olarak girilmesi yerine otomatik olarak hesaplanıp güncellenebilmesi için grafik verilerinde çalışma sayfası formüllerinin nasıl kullanılacağını açıklar. Formül atamayı, hem A1‑stil hem de R1C1‑stil referansları kullanımını, çalışma kitabı formüllerinin yeniden hesaplanmasını ve sunumlardaki grafik çalışma sayfalarında desteklenen sabitler, operatörler, hücre referansları ve ön tanımlı işlevlerle nasıl çalışılacağını gösterir.

## **Sunumdaki Grafik Çalışma Sayfası Formülü Hakkında**
**Grafik çalışma sayfası** (veya grafik çalışma kitabı) sunumda grafiğin veri kaynağıdır. Grafik çalışma sayfası, grafikte grafiksel olarak temsil edilen verileri içerir. PowerPoint’te bir grafik oluşturduğunuzda, bu grafikle ilişkili çalışma sayfası da otomatik olarak oluşturulur. Grafik çalışma sayfası tüm grafik türleri için oluşturulur: çizgi grafik, çubuk grafik, güneş patlaması grafiği, pasta grafiği vb. PowerPoint’te grafik çalışma sayfasını görmek için grafiğe çift tıklamalısınız:

![todo:image_alt_text](chart-worksheet-formulas_1.png)

Grafik çalışma sayfası, grafik öğelerinin adlarını (Kategori Adı: *Category1*, Seri Adı) ve bu kategoriler ile serilere uygun sayısal veri tablosunu içerir. Varsayılan olarak yeni bir grafik oluşturduğunuzda – grafik çalışma sayfası verileri varsayılan veri ile ayarlanır. Daha sonra tablo verilerini çalışma sayfasında manuel olarak değiştirebilirsiniz.

Genellikle grafik, karmaşık verileri (ör. finansal analistler, bilimsel analistler) temsil eder; hücreler diğer hücrelerin değerlerinden ya da dinamik verilerden hesaplanır. Hücre değerini manuel olarak hesaplayıp hücreye sabit bir şekilde yazmak, gelecekte değişiklik yapmayı zorlaştırır. Belirli bir hücrenin değeri değiştirildiğinde, ona bağımlı tüm hücrelerin de güncellenmesi gerekir. Ayrıca tablo verileri başka tablolardan gelen verilere bağlı olabilir; bu durum, güncellenmesi kolay ve esnek bir sunum veri şemasının oluşturulmasını gerektirir.

**Sunumdaki grafik çalışma sayfası formülü**, grafik çalışma sayfası verilerini otomatik olarak hesaplayan ve güncelleyen bir ifadedir. Çalışma sayfası formülü, belirli bir hücre ya da hücre kümesi için veri hesaplama mantığını tanımlar. Çalışma sayfası formülü bir matematik ya da mantıksal formüldür; hücre referansları, matematik fonksiyonları, mantıksal operatörler, aritmetik operatörler, dönüşüm fonksiyonları, dize sabitleri vb. kullanır. Formül tanımı bir hücreye yazılır ve bu hücre basit bir değer içermez. Çalışma sayfası formülü değeri hesaplar ve hücreye geri döndürür. Sunumlardaki grafik çalışma sayfası formülleri aslında Excel formülleriyle aynıdır ve aynı varsayılan işlevler, operatörler ve sabitler desteklenir.

[**Aspose.Slides**](https://products.aspose.com/slides/tr/python-net/) içinde grafik çalışma sayfası, 
[**Chart.ChartData.ChartDataWorkbook**](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/ichartdata/) özelliğiyle temsil edilir. 
Çalışma sayfası formülü, 
[**formula**](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/ichartdatacell/) özelliğiyle atanabilir ve değiştirilebilir. 
Aspose.Slides’ta formüller için aşağıdaki işlevsellik desteklenir:

- Mantıksal sabitler
- Sayısal sabitler
- Dize sabitleri
- Hata sabitleri
- Aritmetik operatörler
- Karşılaştırma operatörleri
- A1‑stil hücre referansları
- R1C1‑stil hücre referansları
- Ön tanımlı işlevler

Genellikle çalışma sayfaları son hesaplanan formül değerlerini depolar. Sunum yüklendikten sonra grafik verileri değiştirilmemişse – **IChartDataCell.Value** özelliği bu değerleri okurken döndürür. Ancak çalışma sayfası verileri değiştirilmişse, **ChartDataCell.Value** özelliği okunurken desteklenmeyen formüller için **CellUnsupportedDataException** hatası fırlatır. Bunun nedeni, formüller başarıyla ayrıştırıldığında hücre bağımlılıklarının belirlenmesi ve son değerlerin doğruluğunun teyit edilmesidir. Formül ayrıştırılamazsa hücre değerinin doğruluğu garanti edilemez.

## **Sunuma Grafik Çalışma Sayfası Formülü Ekleme**
İlk olarak, 
[add_chart](https://reference.aspose.com/slides/tr/python-net/aspose.slides/ishapecollection/) 
kullanarak yeni bir sunumun ilk slaytına örnek veriler içeren bir grafik ekleyin. 
Grafiğin çalışma sayfası otomatik olarak oluşturulur ve 
[**chart_data_workbook**](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/ichartdata/) 
özelliğiyle erişilebilir:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 150, 150, 500, 300)
    workbook = chart.chart_data.chart_data_workbook
    # ...
```


Bazı hücrelere değer yazmak için 
[**value**](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/ichartdatacell/) 
özelliğini **Object** tipinde kullanabilirsiniz; bu sayede özelliğe herhangi bir değer atayabilirsiniz:

```py
    workbook.get_cell(0, "F2").value = -2.5
    workbook.get_cell(0, "G3").value = 6.3
    workbook.get_cell(0, "H4").value = 3
```

Şimdi hücreye formül yazmak için 
[**formula**](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/ichartdatacell/) 
özelliğini kullanabilirsiniz:

```py
    workbook.get_cell(0, "B2").formula = "F2+G3+H4+1"
```

*Not*: [**IChartDataCell.Formula**](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/ichartdatacell/) özelliği A1‑stil hücre referanslarını ayarlamak için kullanılır.  

R1C1‑stil hücre referansını ayarlamak için 
[**r1c1_formula**](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/ichartdatacell/) 
özelliğini kullanabilirsiniz:

```py
    workbook.get_cell(0, "C2").r1c1_formula = "R[1]C[4]/R[2]C[5]"
```

Ardından, çalışma kitabındaki tüm formülleri hesaplamak ve ilgili hücre değerlerini güncellemek için 
[**calculate_formulas**](https://reference.aspose.com/slides/tr/python-net/aspose.slides.charts/chartdataworkbook/) 
metodunu kullanın:

```py
    workbook.calculate_formulas()
    print(workbook.get_cell(0, "B2").value) # 7.8
    print(workbook.get_cell(0, "C2").value) # 2.1
```

## **Mantıksal Sabitler**
Hücre formüllerinde *FALSE* ve *TRUE* gibi mantıksal sabitleri kullanabilirsiniz:

## **Sayısal Sabitler**
Sayısal sabitler, ortak veya bilimsel gösterimle grafik çalışma sayfası formülü oluşturmak için kullanılabilir:

## **Dize Sabitleri**
Dize (veya literal) sabit, olduğu gibi kullanılan ve değişmeyen bir değerdir. Dize sabitleri tarih, metin, sayı vb. olabilir:

## **Hata Sabitleri**
Bazen formülle sonucu hesaplamak mümkün olmayabilir. Bu durumda hücrede değeri yerine bir hata kodu gösterilir. Her hata türünün ayrı bir kodu vardır:

- #DIV/0! – formül sıfıra bölmeye çalışır.
- #GETTING_DATA – değeri hâlâ hesaplanırken hücrede gösterilebilir.
- #N/A – bilgi eksik ya da mevcut değildir. Nedenler: formülde kullanılan hücre boş, ekstra boşluk karakteri, yazım hatası vb.
- #NAME? – belirli bir hücre ya da diğer formül nesneleri adıyla bulunamıyor.
- #NULL! – formülde (, ) gibi bir hata ya da iki nokta üst üste (:) yerine boşluk karakteri kullanıldığında ortaya çıkar.
- #NUM! – formüldeki sayı geçersiz, çok uzun ya da çok kısa vb.
- #REF! – geçersiz hücre referansı.
- #VALUE! – beklenmeyen değer türü. Örneğin, sayı hücresine dize değeri atanması.

## **Aritmetik Operatörler**
Grafik çalışma sayfası formüllerinde tüm aritmetik operatörleri kullanabilirsiniz:

|**Operatör**|**Anlam**|**Örnek**|
| :- | :- | :- |
|+ (artı işareti)|Toplama veya tekli artı|2 + 3|
|- (eksi işareti)|Çıkarma veya negatif|2 - 3<br>-3|
|* (yıldız)|Çarpma|2 * 3|
|/ (bölü işareti)|Bölme|2 / 3|
|% (yüzde işareti)|Yüzde|30%|
|^ (caret)|Üs alma|2 ^ 3|

*Not*: Değerlendirme sırasını değiştirmek için formülün öncelikle hesaplanması gereken kısmını parantez içine alın.

## **Karşılaştırma Operatörleri**
Hücre değerlerini karşılaştırma operatörleriyle karşılaştırabilirsiniz. Bu operatörler kullanılarak iki değer karşılaştırıldığında sonuç mantıksal bir değer (*TRUE* ya da *FALSE*) olur:

|**Operatör**|**Anlam**|**Örnek**|
| :- | :- | :- |
|= (eşittir)|Eşit|A2 = 3|
|<> (eşit değildir)|Eşit değil|A2 <> 3|
|> (büyüktür)|Büyük|A2 > 3|
|>= (büyük veya eşittir)|Büyük veya eşit|A2 >= 3|
|< (küçüktür)|Küçük|A2 < 3|
|<= (küçük veya eşittir)|Küçük veya eşit|A2 <= 3|

## **A1‑stil Hücre Referansları**
**A1‑stil hücre referansları**, sütunun harf, satırın ise sayısal kimlik taşıdığı çalışma sayfalarında kullanılır (ör. "*A*" ve "*1*"). A1‑stil hücre referansları aşağıdaki şekilde kullanılabilir:

|**Hücre referansı**|**Örnek**|**Mutlak**|**Göreli**|**Karışık**|
| :- | :- | :- | :- | :- |
|Hücre|$A$2|A2|<p>A$2</p><p>$A2</p>|
|Satır|$2:$2|2:2|-|
|Sütun|$A:$A|A:A|-|
|Aralık|$A$2:$C$4|A2:C4|<p>$A$2:C4</p><p>A$2:$C4</p>|

A1‑stil hücre referansının formülde kullanımına bir örnek:

## **R1C1‑stil Hücre Referansları**
**R1C1‑stil hücre referansları**, hem satır hem de sütunun sayısal kimlik taşıdığı çalışma sayfalarında kullanılır. R1C1‑stil hücre referansları aşağıdaki şekilde kullanılabilir:

|**Hücre referansı**|**Örnek**|**Mutlak**|**Göreli**|**Karışık**|
| :- | :- | :- | :- | :- |
|Hücre|R2C3|R[2]C[3]|R2C[3]<br>R[2]C3|
|Satır|R2|R[2]|-|
|Sütun|C3|C[3]|-|
|Aralık|R2C3:R5C7|R[2]C[3]:R[5]C[7]|R2C3:R[5]C[7]<br>R[2]C3:R5C[7]|

R1C1‑stil hücre referansının formülde kullanımına bir örnek:

## **Ön Tanımlı İşlevler**
Formüllerde uygulanması kolaylaştırmak için kullanılabilen ön tanımlı işlevler vardır. Bu işlevler en yaygın kullanılan işlemleri kapsar, örneğin:

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
- INDEX (başvuru formu)
- LOOKUP (vektör formu)
- MATCH (vektör formu)
- MAX
- SUM
- VLOOKUP

## **SSS**

**Formüllü bir grafik için harici Excel dosyaları veri kaynağı olarak destekleniyor mu?**

Evet. Aspose.Slides, bir grafiğin veri kaynağı olarak harici çalışma kitaplarını destekler; bu sayede sunum dışındaki bir XLSX dosyasından formüller kullanılabilir.

**Grafik formülleri, aynı çalışma kitabındaki sayfalara sayfa adıyla başvurabilir mi?**

Evet. Formüller, standart Excel referans modelini izler; bu sayede aynı çalışma kitabındaki diğer sayfalara ya da harici bir çalışma kitabına başvurabilirsiniz. Harici referanslar için Excel sözdizimini kullanarak yol ve çalışma kitabı adını ekleyin.