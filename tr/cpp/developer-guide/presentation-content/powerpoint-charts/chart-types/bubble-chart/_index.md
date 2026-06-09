---
title: Sunumlarda С++ Kullanarak Balon Grafiklerini Özelleştirme
linktitle: Balon Grafiği
type: docs
url: /tr/cpp/bubble-chart/
keywords:
- balon grafiği
- balon boyutu
- boyut ölçeklendirme
- boyut temsili
- PowerPoint
- sunum
- С++
- Aspose.Slides
description: "Aspose.Slides for С++ kullanarak PowerPoint'te güçlü balon grafikler oluşturun ve özelleştirin, veri görselleştirmenizi kolayca geliştirin."
---
## **Genel Bakış**

Bu makale Aspose.Slides'te balon grafiklerle nasıl çalışılacağını gösterir. `set_BubbleSizeScale` yöntemiyle balon boyutlarını ölçeklendirme ve `set_BubbleSizeRepresentation` yöntemiyle balon boyutu değerlerinin nasıl temsil edileceğini kontrol etme olmak üzere iki özel özelleştirme seçeneğini kapsar.

Örnekler, bir balon grafiği oluşturmayı, boyut ölçeklendirmesini ayarlamayı ve balon boyutu temsilini genişlik kullanacak şekilde değiştirmeyi gösterir. Makale ayrıca “3‑B Boyutlu Balon” grafik türünün desteklenip desteklenmediğini açıklayan kısa bir SSS bölümü, pratik grafik limitlerinin performansa ve hedef PowerPoint sürümüne bağlı olduğunu belirten notlar ve dışa aktarmanın grafiğin görünümünü Aspose.Slides render motoru aracılığıyla koruduğunu açıklar.

## **Balon Grafik Boyutu Ölçeklendirme**
Aspose.Slides for C++ balon grafik boyutu ölçeklendirmesini destekler. Aspose.Slides for **C++ IChartSeries.BubbleSizeScale** ve **IChartSeriesGroup.BubbleSizeScale** özellikleri eklenmiştir. Aşağıdaki örnek verilmiştir. 

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingBubbleChartScaling-SettingBubbleChartScaling.cpp" >}}


## **Verileri Balon Grafik Boyutları Olarak Temsil Et**
**IChartSeries** ve **ChartSeries** sınıflarına yeni **get_BubbleSizeRepresentation()** yöntemi eklenmiştir. **BubbleSizeRepresentation**, balon boyutu değerlerinin balon grafiğinde nasıl temsil edileceğini belirler. Olası değerler: **BubbleSizeRepresentationType.Area** ve **BubbleSizeRepresentationType.Width**. Buna göre, verileri balon grafik boyutları olarak temsil etmenin olası yollarını belirten **BubbleSizeRepresentationType** enumı eklenmiştir. Aşağıdaki örnek kod gösterilmiştir.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SupportOfBubbleSizeRepresentation-SupportOfBubbleSizeRepresentation.cpp" >}}

## **SSS**

**“3‑B Boyutlu balon grafiği” destekleniyor mu ve normal bir grafikten nasıl farklıdır?**

Evet. “Bubble with 3-D” adlı ayrı bir grafik türü vardır. Balonlara 3‑B stil uygular ancak ek bir eksen eklemez; veriler X‑Y‑S (boyut) olarak kalır. Bu tür, [chart type](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/charttype/) enumunda bulunur.

**Balon grafiğinde seri ve nokta sayısı için bir limit var mı?**

API düzeyinde kesin bir limit yoktur; sınırlamalar performans ve hedef PowerPoint sürümüne göre belirlenir. Okunabilirlik ve render hızı açısından nokta sayısının makul tutulması önerilir.

**Dışa aktarma balon grafiğinin (PDF, görüntüler) görünümünü nasıl etkiler?**

Desteklenen formatlara yapılan dışa aktarma grafiğin görünümünü korur; render işlemi Aspose.Slides motoru tarafından gerçekleştirilir. Raster/vektör formatları için genel grafik render kuralları geçerlidir (çözünürlük, anti‑aliasing), bu nedenle baskı için yeterli DPI seçilmelidir.