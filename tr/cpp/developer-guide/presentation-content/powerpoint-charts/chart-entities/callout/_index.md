---
title: C++ Kullanarak Sunum Grafiklerinde Çağrı Balonlarını Yönetme
linktitle: Çağrı Balonu
type: docs
url: /tr/cpp/callout/
keywords:
- grafik çağrı balonu
- çağrı balonu kullanımı
- veri etiketi
- etiket biçimi
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ içinde çağrı balonlarını oluşturun ve biçimlendirin, kısa kod örnekleriyle PPT ve PPTX ile uyumlu, sunum iş akışlarını otomatikleştirin."
---
## **Genel Bakış**

Bu makale Aspose.Slides içinde grafik veri etiketleri için çağrı balonlarıyla nasıl çalışılacağını açıklar. `set_ShowLabelAsDataCallout` metodunu kullanarak etiketleri çağrı balonu olarak nasıl gösterileceğini, bir halka grafik için çağrı balonu ile ilgili etiket ayarlarının nasıl yapılandırılacağını ve çağrı balonları ile görünümlerinin sunumlar PDF, HTML5, SVG ve raster görüntü formatlarına dışa aktarıldığında korunduğunu gösterir.

## **Çağrı Balonları Kullanma**
Yeni **ShowLabelAsDataCallout** özelliği **DataLabelFormat** sınıfına ve **IDataLabelFormat** arayüzüne eklenmiştir; bu özellik belirtilen grafik veri etiketinin veri çağrı balonu olarak mı yoksa veri etiketi olarak mı görüntüleneceğini belirler. Aşağıdaki örnekte Çağrı Balonları ayarlanmıştır.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DisplayChartLabels-DisplayChartLabels.cpp" >}}

## **Halka Grafik için Çağrı Balonu Ayarlama**
Aspose.Slides for C++ bir Halka grafik için seri veri etiketi çağrı balonu şeklini ayarlamayı destekler. Aşağıdaki örnek verilmiştir.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddDoughnutCallout-AddDoughnutCallout.cpp" >}}

## **SSS**

**Sunumu PDF, HTML5, SVG veya görüntülere dönüştürürken çağrı balonları korunur mu?**

Evet. Çağrı balonları grafik oluşturmanın bir parçasıdır; bu nedenle [PDF](/slides/tr/cpp/convert-powerpoint-to-pdf/), [HTML5](/slides/tr/cpp/export-to-html5/), [SVG](/slides/tr/cpp/render-a-slide-as-an-svg-image/), veya [RasterGörüntüler](/slides/tr/cpp/convert-powerpoint-to-png/) olarak dışa aktardığınızda slayt biçimlendirmesiyle birlikte korunur.

**Özel yazı tipleri çağrı balonlarında çalışır mı ve dışa aktarımda görünümleri korunur mu?**

Evet. Aspose.Slides, sunuma [Yazı tipi gömme](/slides/tr/cpp/embedded-font/) özelliğini destekler ve [PDF](/slides/tr/cpp/convert-powerpoint-to-pdf/) gibi dışa aktarımlarda yazı tipi gömme kontrolü yapar; böylece çağrı balonları farklı sistemlerde aynı görünüme sahip olur.