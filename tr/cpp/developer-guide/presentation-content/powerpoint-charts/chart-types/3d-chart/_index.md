---
title: C++ Kullanarak Sunumlarda 3D Grafikleri Özelleştirme
linktitle: 3D Grafik
type: docs
url: /tr/cpp/3d-chart/
keywords:
- 3D grafik
- döndürme
- derinlik
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++'da 3‑D grafikler oluşturmayı ve özelleştirmeyi öğrenin; PPT ve PPTX dosyalarını destekler—sunumlarınızı bugün geliştirin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'te `Rotation3D` ayarları gibi `RotationX`, `RotationY`, `DepthPercents` ve `RightAngleAxes` yapılandırılarak 3D grafik nasıl özelleştirileceğini açıklar. Bir sunum oluşturma, varsayılan verilerle 3D grafik ekleme, gerekli 3D görünüm ayarlarını uygulama ve değiştirilmiş sunumu PPTX dosyası olarak kaydetme adımlarını gösterir.

## **3D Grafiğin RotationX, RotationY ve DepthPercents Özelliklerini Ayarlama**
Aspose.Slides for C++, bu özellikleri ayarlamak için basit bir API sağlar. Aşağıdaki makale, X, Y Rotation ve **DepthPercents** gibi farklı özellikleri nasıl ayarlayacağınızı gösterir. Örnek kod, yukarıda belirtilen özelliklerin ayarlanmasını uygular.

1. ​[Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. İlk slayta erişin.
1. Varsayılan verilerle bir grafik ekleyin.
1. Rotation3D özelliklerini ayarlayın.
1. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagePropertiesCharts-ManagePropertiesCharts.cpp" >}}

## **FAQ**

**Aspose.Slides'te hangi grafik türleri 3D modunu destekler?**

Aspose.Slides, Column 3D, Clustered Column 3D, Stacked Column 3D ve %100 Stacked Column 3D gibi sütun grafiklerinin 3D varyantlarını, ayrıca [ChartType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/charttype/) enum'unda yer alan ilgili 3D türlerini destekler. Tam ve güncel liste için, yüklü sürümünüzün API referansındaki [ChartType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/charttype/) üyelerine bakın.

**Bir rapor veya web için 3D grafiğin raster görüntüsünü alabilir miyim?**

Evet. Grafiği, [chart API](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shape/getimage/) aracılığıyla bir görüntüye dışa aktarabilir veya tüm slaytı [/slides/tr/cpp/convert-powerpoint-to-png/]( /slides/tr/cpp/convert-powerpoint-to-png/) adresindeki adımla PNG veya JPEG gibi formatlara render edebilirsiniz. Bu, pikselle tam uyumlu bir önizleme gerektiğinde veya grafiği belge, gösterge paneli veya web sayfasına PowerPoint gerektirmeden yerleştirmek istediğinizde kullanışlıdır.

**Büyük 3D grafiklerin oluşturulması ve render edilmesi ne kadar performanslıdır?**

Performans veri miktarı ve görsel karmaşıklığa bağlıdır. En iyi sonuçlar için 3D efektlerini minimumda tutun, duvar ve grafik alanlarında ağır doku kullanımından kaçının, mümkün olduğunca seri başına veri noktası sayısını sınırlayın ve hedef ekran ya da baskı ihtiyaçlarına uygun çözünürlük ve boyutlarda bir çıktı render edin.