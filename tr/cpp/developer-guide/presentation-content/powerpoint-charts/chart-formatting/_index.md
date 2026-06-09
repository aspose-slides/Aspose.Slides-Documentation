---
title: C++'ta Sunum Grafiklerini Biçimlendirme
linktitle: Grafik Biçimlendirme
type: docs
weight: 60
url: /tr/cpp/chart-formatting/
keywords:
- grafik biçimlendirme
- grafik biçimlendirme
- grafik varlığı
- grafik özellikleri
- grafik ayarları
- grafik seçenekleri
- yazı tipi özellikleri
- yuvarlatılmış kenar
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++'ta grafik biçimlendirmeyi öğrenin ve profesyonel, göz alıcı stil ile PowerPoint sunumunuzu yükseltin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarındaki grafiklerin nasıl biçimlendirileceğini açıklar. Eksenler, ızgara çizgileri, başlıklar, lejandlar, çizim alanı ve duvar dolgu renkleri gibi ana grafik öğelerini özelleştirerek grafik verilerinin görünümünü ve okunabilirliğini artırmayı gösterir.

Ayrıca, grafik metni için yazı tipi özelliklerinin nasıl ayarlanacağını, grafik verilerine hazır ve özel sayı biçimlerinin nasıl uygulanacağını ve grafik alanı için yuvarlak köşelerin nasıl etkinleştirileceğini gösterir. Bu örnekler, bir sunumdaki grafiklerin hem görsel stilini hem de veri sunumunu nasıl kontrol edebileceğinizi ortaya koyar.

## **Grafik Nesnelerini Biçimlendirme**
Aspose.Slides for C++ geliştiricilerin sıfırdan özel grafikler eklemesini sağlar. Bu makale, grafik kategori ve değer ekseni dahil olmak üzere farklı grafik nesnelerinin nasıl biçimlendirileceğini açıklar.

Aspose.Slides for C++ farklı grafik nesnelerini yönetmek ve bunları özel değerlerle biçimlendirmek için basit bir API sunar:

1. **Presentation** sınıfının bir örneğini oluşturun.  
1. İndeksiyle bir slaytın referansını alın.  
1. İstediğiniz türde (bu örnekte **ChartType.LineWithMarkers** kullanılacaktır) varsayılan veri ile bir grafik ekleyin.  
1. Grafiğin **Değer Ekseni**ne erişin ve aşağıdaki özellikleri ayarlayın:  
   1. **Değer Ekseni** Büyük Izgara Çizgileri için **Çizgi Biçimi** ayarlama  
   1. **Değer Ekseni** Küçük Izgara Çizgileri için **Çizgi Biçimi** ayarlama  
   1. **Değer Ekseni** için **Sayı Biçimi** ayarlama  
   1. **Değer Ekseni** için **Min, Max, Büyük ve Küçük birimler** ayarlama  
   1. **Değer Ekseni** verileri için **Metin Özellikleri** ayarlama  
   1. **Değer Ekseni** için **Başlık** ayarlama  
   1. **Değer Ekseni** için **Çizgi Biçimi** ayarlama  
1. Grafiğin **Kategori Ekseni**ne erişin ve aşağıdaki özellikleri ayarlayın:  
   1. **Kategori Ekseni** Büyük Izgara Çizgileri için **Çizgi Biçimi** ayarlama  
   1. **Kategori Ekseni** Küçük Izgara Çizgileri için **Çizgi Biçimi** ayarlama  
   1. **Kategori Ekseni** verileri için **Metin Özellikleri** ayarlama  
   1. **Kategori Ekseni** için **Başlık** ayarlama  
   1. **Kategori Ekseni** için **Etiket Konumlandırması** ayarlama  
   1. **Kategori Ekseni** etiketleri için **Dönüş Açısı** ayarlama  
1. Grafiğin **Lejand**ına erişin ve **Metin Özellikleri**ni ayarlayın.  
1. Grafik lejandlarının grafik üzerine çakışmadan gösterilmesini ayarlayın.  
1. Grafiğin **İkincil Değer Ekseni**ne erişin ve aşağıdaki özellikleri ayarlayın:  
   1. **İkincil Değer Ekseni**ni etkinleştirin.  
   1. **İkincil Değer Ekseni** için **Çizgi Biçimi** ayarlama  
   1. **İkincil Değer Ekseni** için **Sayı Biçimi** ayarlama  
   1. **İkincil Değer Ekseni** için **Min, Max, Büyük ve Küçük birimler** ayarlama  
1. İlk grafik serisini **İkincil Değer Ekseni**ne çizin.  
1. Grafiğin arka duvarını dolgu rengine ayarlayın.  
1. Grafiğin çizim alanının dolgu rengini ayarlayın.  
1. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartEntities-ChartEntities.cpp" >}}

## **Bir Grafik İçin Yazı Tipi Özelliklerini Ayarlama**
Aspose.Slides for C++ grafikler için yazı tipiyle ilgili özelliklerin ayarlanmasını destekler. Aşağıdaki adımları izleyerek grafik için yazı tipi özelliklerini ayarlayın.

- **Presentation** sınıfı nesnesini oluşturun.  
- Slayta bir grafik ekleyin.  
- Yazı tipi yüksekliğini ayarlayın.  
- Değiştirilmiş sunumu kaydedin.

Aşağıda örnek bir örnek verilmiştir.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-FontPropertiesForChart-FontPropertiesForChart.cpp" >}}

## **Bir Grafik Veri Tablosu İçin Yazı Tipi Özelliklerini Ayarlama**
Aspose.Slides for C++ bir serideki kategorilerin renklerinin değiştirilmesini destekler.

1. **Presentation** sınıfı nesnesini oluşturun.  
1. Slayta bir grafik ekleyin.  
1. Grafik tablosunu ayarlayın.  
1. Yazı tipi yüksekliğini ayarlayın.  
1. Değiştirilmiş sunumu kaydedin.

Aşağıda örnek bir örnek verilmiştir.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingFontPropertiesForChartDataTable-SettingFontPropertiesForChartDataTable.cpp" >}}

## **Grafik Alanı Yuvarlak Kenarlıklarını Ayarlama**
Aspose.Slides for C++ grafik alanı ayarlamayı destekler. **IChart.HasRoundedCorners** ve **Chart.HasRoundedCorners** özellikleri Aspose.Slides’e eklenmiştir.

1. **Presentation** sınıfı nesnesini oluşturun.  
1. Slayta bir grafik ekleyin.  
1. Grafiğin doldurma türünü ve dolgu rengini ayarlayın.  
1. Yuvarlak köşe özelliğini **True** olarak ayarlayın.  
1. Değiştirilmiş sunumu kaydedin.

Aşağıda örnek bir örnek verilmiştir.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingChartAreaRoundedBorders-SettingChartAreaRoundedBorders.cpp" >}}

## **Sayısal Biçimi Ayarlama**
Aspose.Slides for C++ grafik veri biçimini yönetmek için basit bir API sağlar:

1. **[Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/)** sınıfının bir örneğini oluşturun.  
1. İndeksiyle bir slaytın referansını alın.  
1. İstediğiniz türde (bu örnek **ChartType.ClusteredColumn** kullanır) varsayılan veri ile bir grafik ekleyin.  
1. Olası hazır değerlerden birini seçerek hazır sayı biçimini ayarlayın.  
1. Her grafik serisindeki grafik veri hücresini dolaşarak grafik veri sayı biçimini ayarlayın.  
1. Sunumu kaydedin.  
1. Özel sayı biçimini ayarlayın.  
1. Her grafik serisindeki veri hücresini dolaşarak farklı bir sayı biçimi ayarlayın.  
1. Sunumu kaydedin.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-NumberFormat-NumberFormat.cpp" >}}

| |**Kullanılabilecek olası önceden tanımlı sayı biçimi değerleri ve bunların indeksleri aşağıda verilmiştir:**|
| :- | :- |
|**0**|Genel|
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

## **SSS**

**Sütunlar/alanlar için yarı saydam doldurulmalar ayarlayıp kenarlığı opak tutabilir miyim?**

Evet. Doldurma şeffaflığı ve kenarlık ayrı ayrı yapılandırılır. Bu, yoğun görselleştirmelerde ızgara ve verilerin okunabilirliğini artırmak için faydalıdır.

**Veri etiketleri üst üste geldiğinde nasıl başa çıkabilirim?**

Yazı tipi boyutunu küçültün, gereksiz etiket bileşenlerini devre dışı bırakın (örneğin kategorileri), etiket kaydırma/konumunu ayarlayın, gerekirse yalnızca seçili noktalar için etiket gösterin veya formatı “değer + lejand” olarak değiştirin.

**Serilere degrade veya desen doldurulması uygulayabilir miyim?**

Evet. Hem katı hem de degrade/desen doldurmaları genellikle mevcuttur. Gerçekte, degradeleri ölçülü kullanın ve ızgara ile metin arasındaki kontrastı azaltabilecek kombinasyonlardan kaçının.