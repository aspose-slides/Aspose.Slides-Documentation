---
title: C++ Kullanarak Sunumlarda Balon Grafiklerini Özelleştirin
linktitle: Balon Grafiği
type: docs
url: /tr/cpp/bubble-chart/
keywords:
- balon grafik
- balon boyutu
- boyut ölçeklendirme
- boyut temsili
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "PowerPoint'te Aspose.Slides for C++ ile güçlü balon grafikler oluşturun ve özelleştirerek veri görselleştirmenizi kolayca geliştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'te balon grafiklerle nasıl çalışılacağını gösterir. `set_BubbleSizeScale` yöntemiyle balon boyutlarını ölçeklendirme ve `set_BubbleSizeRepresentation` yöntemiyle balon boyutu değerlerinin nasıl temsil edileceğini kontrol etme olmak üzere iki özel özelleştirme seçeneğini kapsar.

Örnekler, bir balon grafik oluşturmayı, boyut ölçeklendirmesini ayarlamayı ve balon boyutu temsilini genişlik olarak değiştirmeyi gösterir. Makale ayrıca “Bubble with 3-D” grafik türünün desteğini açıklayan, pratik grafik sınırlarının performans ve hedef PowerPoint sürümüne bağlı olduğunu belirten ve dışa aktarmanın grafiğin görünümünü Aspose.Slides render motoru aracılığıyla koruduğunu açıklayan kısa bir SSS bölümü içerir.

## **Balon Grafik Boyut Ölçeklendirme**
Aspose.Slides for C++ balon grafik boyut ölçeklendirme desteği sağlar. Aspose.Slides for **C++ IChartSeries.BubbleSizeScale** ve **IChartSeriesGroup.BubbleSizeScale** özellikleri eklendi. Aşağıda örnek bir örnek verilmiştir.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}

## **Verileri Balon Grafik Boyutları Olarak Temsil Et**
Yeni **get_BubbleSizeRepresentation()** yöntemi **IChartSeries** ve **ChartSeries** sınıflarına eklendi. **BubbleSizeRepresentation**, balon grafik içinde balon boyutu değerlerinin nasıl temsil edileceğini belirler. Olası değerler: **BubbleSizeRepresentationType.Area** ve **BubbleSizeRepresentationType.Width**. Buna göre, verileri balon grafik boyutları olarak temsil etmenin olası yollarını belirten **BubbleSizeRepresentationType** enumu eklendi. Aşağıda örnek kod verilmiştir.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}

## **SSS**

**“3-D etkili balon grafik” destekleniyor mu ve normal bir grafikten nasıl farklıdır?**

Evet. "Bubble with 3-D" adlı ayrı bir grafik türü vardır. Bu, balonlara 3-D stil uygular ancak ek bir eksen eklemez; veriler X-Y-S (boyut) olarak kalır. Bu tür, [chart type](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/charttype/) enumunda bulunur.

**Balon grafiğinde seri ve nokta sayısı için bir sınırlama var mı?**

API düzeyinde kesin bir sınırlama yoktur; kısıtlamalar performans ve hedef PowerPoint sürümüne göre belirlenir. Okunabilirlik ve render hızını korumak için nokta sayısının makul seviyede tutulması önerilir.

**Dışa aktarma, balon grafiğinin (PDF, görüntüler) görünümünü nasıl etkiler?**

Desteklenen biçimlere dışa aktarma, grafiğin görünümünü korur; renderleme Aspose.Slides motoru tarafından yapılır. Raster/vektör biçimler için genel grafik render kuralları geçerlidir (çözünürlük, anti-aliasing), bu yüzden baskı için yeterli DPI seçilmelidir.