---
title: Sunumlarda С++ Kullanarak 3D Grafikleri Özelleştirme
linktitle: 3D Grafik
type: docs
url: /tr/cpp/3d-chart/
keywords:
- 3D grafik
- döndürme
- derinlik
- PowerPoint
- sunum
- С++
- Aspose.Slides
description: "Aspose.Slides for С++ ile PPT ve PPTX dosyalarını destekleyen 3-D grafikler oluşturmayı ve özelleştirmeyi öğrenin—sunumlarınızı bugün güçlendirin."
---
## **Genel Bakış**

Bu makale, `RotationX`, `RotationY`, `DepthPercents` ve `RightAngleAxes` gibi `Rotation3D` ayarlarını yapılandırarak Aspose.Slides'te 3D bir grafiği nasıl özelleştireceğinizi açıklar. Sunum oluşturma, varsayılan veriyle bir 3D grafik ekleme, gerekli 3D görünüm ayarlarını uygulama ve değiştirilmiş sunumu PPTX dosyası olarak kaydetme adımlarını gösterir.

## **3D Grafik İçin RotationX, RotationY ve DepthPercents Özelliklerini Ayarlama**
Aspose.Slides for C++ bu özellikleri ayarlamak için basit bir API sağlar. Aşağıdaki örnek, X, Y dönüşü ve **DepthPercents** gibi farklı özelliklerin nasıl ayarlanacağını gösterir. Örnek kod, yukarıda belirtilen özellikleri uygular.

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İlk slayta erişin.  
1. Varsayılan veriyle bir grafik ekleyin.  
1. Rotation3D özelliklerini ayarlayın.  
1. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ManagePropertiesCharts-ManagePropertiesCharts.cpp" >}}

## **SSS**

**Aspose.Slides'te hangi grafik türleri 3D modunu destekler?**

Aspose.Slides, Column 3D, Clustered Column 3D, Stacked Column 3D ve %100 Stacked Column 3D gibi sütun grafiklerinin 3D varyantlarını ve [ChartType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/charttype/) enumı aracılığıyla sunulan ilgili 3D türlerini destekler. En güncel ve kesin liste için yüklü sürümünüzün API referansındaki [ChartType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/charttype/) üyelerine bakın.

**Bir rapor veya web için 3D grafiğin raster görüntüsünü alabilir miyim?**

Evet. Grafiği, [chart API](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shape/getimage/) üzerinden bir görsele dışa aktarabilir veya tüm slaytı [/slides/tr/cpp/convert-powerpoint-to-png/](/slides/tr/cpp/convert-powerpoint-to-png/) gibi bir yolla PNG ya da JPEG formatına render edebilirsiniz. Bu, pikselle tam uyumlu bir ön izleme gerektiğinde ya da grafiği belgeler, gösterge panoları veya web sayfalarına PowerPoint gerektirmeden yerleştirmek istediğinizde faydalıdır.

**Büyük 3D grafiklerin oluşturulması ve render edilmesi ne kadar performanslıdır?**

Performans, veri hacmi ve görsel karmaşıklığa bağlıdır. En iyi sonuçlar için 3D efektlerini minimumda tutun, duvar ve çizim alanlarında ağır dokulardan kaçının, mümkün olduğunca seri başına veri nokta sayısını sınırlayın ve hedef ekran veya baskı ihtiyaçlarına uygun çözünürlük ve boyutlarda bir çıktı render edin.