---
title: C++ Kullanarak Sunum Grafiklerinde Balonları Yönetme
linktitle: Balon
type: docs
url: /tr/cpp/callout/
keywords:
- grafik balonu
- balon kullanımı
- veri etiketi
- etiket formatı
- PowerPoint
- sunum
- С++
- Aspose.Slides
description: "Aspose.Slides for С++ içinde balonları oluşturun ve biçimlendirin, PPT ve PPTX ile uyumlu kısa kod örnekleriyle sunum iş akışlarını otomatikleştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'te grafik veri etiketleri için balonlarla nasıl çalışılacağını açıklar. `set_ShowLabelAsDataCallout` yönteminin etiketleri balon olarak göstermek için nasıl kullanılacağını, bir donut grafiği için balonla ilgili etiket ayarlarının nasıl yapılandırılacağını ve balonların ve görünümlerinin sunum PDF, HTML5, SVG ve raster görüntü formatlarına dışa aktarılırken korunduğunu gösterir.

## **Balonları Kullanma**
Yeni **ShowLabelAsDataCallout** özelliği **DataLabelFormat** sınıfına ve **IDataLabelFormat** arayüzüne eklenmiştir; bu özellik, belirtilen grafiğin veri etiketinin veri balonu olarak mı yoksa veri etiketi olarak mı gösterileceğini belirler. Aşağıdaki örnekte Balonları ayarladık.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DisplayChartLabels-DisplayChartLabels.cpp" >}}

## **Donut Grafiği için Bir Balon Ayarlama**
Aspose.Slides for C++, Donut grafiği için seri veri etiketi balonu şeklini ayarlama desteği sunar. Aşağıda örnek bir kod bulunmaktadır.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddDoughnutCallout-AddDoughnutCallout.cpp" >}}

## **SSS**

**Sunumu PDF, HTML5, SVG veya görüntülere dönüştürürken balonlar korunur mu?**

Evet. Balonlar grafik oluşturmanın bir parçasıdır; bu nedenle [PDF](/slides/tr/cpp/convert-powerpoint-to-pdf/), [HTML5](/slides/tr/cpp/export-to-html5/), [SVG](/slides/tr/cpp/render-a-slide-as-an-svg-image/) veya [raster görüntüler](/slides/tr/cpp/convert-powerpoint-to-png/) olarak dışa aktardığınızda, slaytın biçimlendirmesiyle birlikte korunur.

**Balonlarda özel yazı tipleri çalışır mı ve görünümleri dışa aktarımda korunabilir mi?**

Evet. Aspose.Slides, sunuma [yazı tiplerini gömmeyi](/slides/tr/cpp/embedded-font/) destekler ve [PDF](/slides/tr/cpp/convert-powerpoint-to-pdf/) gibi dışa aktarımlar sırasında yazı tipi gömme kontrolü yapar, böylece balonlar farklı sistemlerde aynı şekilde görünür.