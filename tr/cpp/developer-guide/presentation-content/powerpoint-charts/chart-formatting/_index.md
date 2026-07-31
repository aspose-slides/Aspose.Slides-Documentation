---
title: C++ Sunum Grafiklerini Biçimlendirme
linktitle: Grafik Biçimlendirme
type: docs
weight: 60
url: /tr/cpp/chart-formatting/
keywords:
- grafik formatı
- grafik biçimlendirme
- grafik varlığı
- grafik özellikleri
- grafik ayarları
- grafik seçenekleri
- yazı tipi özellikleri
- yuvarlak kenar
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ içinde grafik biçimlendirmeyi öğrenin ve PowerPoint sunumunuzu profesyonel, göz alıcı bir stil ile yükseltin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarındaki grafikleri nasıl biçimlendireceğinizi açıklar. Ekseler, ızgara çizgileri, başlıklar, gösterge alanları, çizim alanı ve duvar dolguları gibi temel grafik öğelerini özelleştirerek grafik verilerinin görünümünü ve okunabilirliğini artırmayı gösterir.

Ayrıca, grafik metni için yazı tipi özelliklerini ayarlamayı, grafik verilerine önceden tanımlı ve özel sayı formatları uygulamayı ve grafik alanı için yuvarlak köşeleri etkinleştirmeyi açıklar. Bu örnekler, bir sunumdaki grafiklerin görsel stilini ve veri sunumunu birlikte nasıl kontrol edebileceğinizi gösterir.

## **Grafik Öğelerini Biçimlendirme**
Aspose.Slides for C++ geliştiricilerin sıfırdan özel grafikler eklemesine olanak tanır. Bu makale, grafik kategori ve değer ekseni dahil farklı grafik öğelerini nasıl biçimlendireceğinizi açıklar.

Aspose.Slides for C++ farklı grafik öğelerini yönetmek ve özelleştirilmiş değerlerle biçimlendirmek için basit bir API sunar:

1. **Presentation** sınıfının bir örneğini oluşturun.
1. İndeksiyle bir slaytın referansını alın.
1. İstediğiniz tipte (bu örnekte ChartType.LineWithMarkers kullanacağız) varsayılan veriyle bir grafik ekleyin.
1. Grafiğin Değer Ekseni'ne erişin ve aşağıdaki özellikleri ayarlayın:
   1. Değer Ekseni Anaızık Çizgileri için **Line format**'ı ayarlayın
   1. Değer Ekseni Altızık Çizgileri için **Line format**'ı ayarlayın
   1. Değer Ekseni için **Number Format**'ı ayarlayın
   1. Değer Ekseni için **Min, Max, Major and Minor units**'ı ayarlayın
   1. Değer Ekseni verileri için **Text Properties**'i ayarlayın
   1. Değer Ekseni için **Title**'ı ayarlayın
   1. Değer Ekseni için **Line Format**'ı ayarlayın
1. Grafiğin Kategori Ekseni'ne erişin ve aşağıdaki özellikleri ayarlayın:
   1. Kategori Ekseni Anaızık Çizgileri için **Line format**'ı ayarlayın
   1. Kategori Ekseni Altızık Çizgileri için **Line format**'ı ayarlayın
   1. Kategori Ekseni verileri için **Text Properties**'i ayarlayın
   1. Kategori Ekseni için **Title**'ı ayarlayın
   1. Kategori Ekseni için **Label Positioning**'i ayarlayın
   1. Kategori Ekseni etiketleri için **Rotation Angle**'ı ayarlayın
1. Grafiğin Gösterge alanına erişin ve **Text Properties**'i ayarlayın
1. Grafiğin gösterge alanının çakışmadan görünmesini ayarlayın
1. Grafiğin **Secondary Value Axis**'ine erişin ve aşağıdaki özellikleri ayarlayın:
   1. İkincil **Value Axis**'i etkinleştirin
   1. İkincil Değer Ekseni için **Line Format**'ı ayarlayın
   1. İkincil Değer Ekseni için **Number Format**'ı ayarlayın
   1. İkincil Değer Ekseni için **Min, Max, Major and Minor units**'ı ayarlayın
1. Şimdi ilk grafik serisini İkincil Değer Ekseni üzerine çizin
1. Grafiğin arka duvarını dolgu rengine ayarlayın
1. Grafiğin çizim alanının dolgu rengini ayarlayın
1. Değiştirilmiş sunumu bir PPTX dosyasına yazın

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartEntities-ChartEntities.cpp" >}}

## **Bir Grafik İçin Yazı Tipi Özelliklerini Ayarlama**
Aspose.Slides for C++ grafikler için yazı tipiyle ilgili özellikleri ayarlamayı destekler. Grafik için yazı tipi özelliklerini ayarlamak için aşağıdaki adımları izleyin.

- Presentation sınıfı nesnesini örnekleyin.
- Slayta bir grafik ekleyin.
- Yazı tipi yüksekliğini ayarlayın.
- Değiştirilmiş sunumu kaydedin.

Aşağıda örnek kod verilmiştir.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontPropertiesForChart-FontPropertiesForChart.cpp" >}}

## **Grafik Veri Tablosu İçin Yazı Tipi Özelliklerini Ayarlama**
Aspose.Slides for C++ bir serideki kategorilerin rengini değiştirmeyi destekler.

1. Presentation sınıfı nesnesini örnekleyin.
1. Slayta bir grafik ekleyin.
1. Grafik tablosunu ayarlayın.
1. Yazı tipi yüksekliğini ayarlayın.
1. Değiştirilmiş sunumu kaydedin.

Aşağıda örnek kod verilmiştir. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontPropertiesForChartDataTable-SettingFontPropertiesForChartDataTable.cpp" >}}

## **Grafik Alanı Yuvarlak Köşelerle Ayarlama**
Aspose.Slides for C++ grafik alanını ayarlamayı destekler. **IChart.HasRoundedCorners** ve **Chart.HasRoundedCorners** özellikleri Aspose.Slides içinde eklenmiştir.

1. Presentation sınıfı nesnesini örnekleyin.
1. Slayta bir grafik ekleyin.
1. Grafiğin doldurma tipini ve doldurma rengini ayarlayın
1. Yuvarlak köşe özelliğini True olarak ayarlayın.
1. Değiştirilmiş sunumu kaydedin. 

Aşağıda örnek kod verilmiştir. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingChartAreaRoundedBorders-SettingChartAreaRoundedBorders.cpp" >}}

## **Sayısal Formatı Ayarlama**
Aspose.Slides for C++ grafik veri formatını yönetmek için basit bir API sunar:

1. [Sunum](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İndeksiyle bir slaytın referansını alın.
1. Varsayılan veriyle birlikte istediğiniz tipte bir grafik ekleyin (bu örnek **ChartType.ClusteredColumn** kullanır).
1. Olası önceden tanımlı değerlerden birini seçerek ön tanımlı sayı formatını ayarlayın.
1. Her grafik serisindeki grafik veri hücrelerini dolaşarak grafik veri sayı formatını ayarlayın.
1. Sunumu kaydedin.
1. Özel sayı formatını ayarlayın.
1. Her grafik serisi içindeki veri hücrelerini dolaşarak farklı bir grafik veri sayı formatı ayarlayın.
1. Sunumu kaydedin.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-NumberFormat-NumberFormat.cpp" >}}

| |**Kullanılabilecek olası önceden tanımlı sayı formatı değerleri ve bunların indeksleri aşağıda verilmiştir:**|
| :- | :- |
|**0**|General|
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

|||
| :- | :- |

## **FAQ**

**Sütunlar/alanlar için yarı saydam dolgu ayarlayıp kenarlığı opak tutabilir miyim?**

Evet. Dolgu saydamlığı ve kenarlık ayrı ayrı yapılandırılır. Bu, yoğun görselleştirmelerde ızgara ve verinin okunabilirliğini artırmak için faydalıdır.

**Etiketler çakıştığında ne yapmalıyım?**

Yazı tipi boyutunu küçültün, gereksiz etiket bileşenlerini devre dışı bırakın (örneğin, kategorileri), etiket ofset/konumunu ayarlayın, gerekirse yalnızca seçili noktalar için etiketleri gösterin veya formatı “değer + gösterge” olarak değiştirin.

**Serilere degrade veya desen dolguları uygulayabilir miyim?**

Evet. Katı ve degrade/desen dolguları genellikle mevcuttur. Pratikte, degradeleri ölçülü kullanın ve ızgara ve metinle olan kontrastı azaltan kombinasyonlardan kaçının.