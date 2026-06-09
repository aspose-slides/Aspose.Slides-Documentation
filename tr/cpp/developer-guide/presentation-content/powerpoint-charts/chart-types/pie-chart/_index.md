---
title: C++ kullanarak Sunumlarda Pasta Grafiklerini Özelleştirme
linktitle: Pasta Grafik
type: docs
url: /tr/cpp/pie-chart/
keywords:
- pasta grafik
- grafiği yönet
- grafiği özelleştir
- grafik seçenekleri
- grafik ayarları
- çizim seçenekleri
- dilim rengi
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides ile C++'ta pasta grafiklerini oluşturmayı ve özelleştirmeyi öğrenin, PowerPoint'e aktarılabilir, verilerinizi saniyeler içinde anlatmanızı sağlar."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'ta pasta grafikleriyle nasıl çalışılacağını açıklar. Pie of Pie ve Bar of Pie grafikleri için ikincil çizim seçeneklerinin nasıl yapılandırılacağını ve standart bir pasta grafiği için otomatik dilim renklendirmesinin nasıl etkinleştirileceğini gösterir.

Örnekler, bir slayta grafik ekleme, seri ve etiket ayarlarını düzenleme, varsayılan grafik verilerini özel kategoriler ve değerlerle değiştirme ve güncellenmiş sunumu kaydetme gibi pratik grafik özelleştirme adımlarına odaklanır.

## **Pasta içinde Pasta ve Bar of Pie Grafikleri için İkinci Çizim Seçenekleri**

Aspose.Slides for C++ artık Pie of Pie veya Bar of Pie grafiği için ikinci çizim seçeneklerini destekliyor. Bu konuda, Aspose.Slides kullanarak bu seçeneklerin nasıl belirtileceğini bir örnekle göreceğiz. Özellikleri belirtmek için lütfen aşağıdaki adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıf nesnesini örnekleyin.
1. Slayta bir grafik ekleyin.
1. Grafiğin ikinci çizim seçeneklerini belirtin.
1. Sunumu diske yazın.

Aşağıda verilen örnekte, Pie of Pie grafiğinin çeşitli özelliklerini ayarladık.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SecondPlotOptionsforCharts-SecondPlotOptionsforCharts.cpp" >}}

## **Otomatik Pasta Grafiği Dilim Renklerini Ayarlama**

Aspose.Slides for C++ otomatik pasta grafik dilim renklerini ayarlamak için basit bir API sağlar. Örnek kod, yukarıda belirtilen özelliklerin ayarlanmasını uygular.

1. Presentation sınıfının bir örneğini oluşturun.
1. İlk slayta erişin.
1. Varsayılan verilerle bir grafik ekleyin.
1. Grafik başlığını ayarlayın.
1. İlk seriyi Değerleri Göster olarak ayarlayın.
1. Grafik veri sayfasının indeksini ayarlayın.
1. Grafik veri çalışma sayfasını alın.
1. Varsayılan oluşturulan serileri ve kategorileri silin.
1. Yeni kategoriler ekleyin.
1. Yeni bir seri ekleyin.

Değiştirilmiş sunumu bir PPTX dosyasına yazın.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingAutomicPieChartSliceColors-SettingAutomicPieChartSliceColors.cpp" >}}

## **SSS**

**'Pie of Pie' ve 'Bar of Pie' varyasyonları destekleniyor mu?**

Evet, kütüphane pasta grafikler için ikincil bir çizimi, 'Pie of Pie' ve 'Bar of Pie' türleri dahil olmak üzere destekler.

**Sadece grafiği bir görüntü olarak (örneğin PNG) dışa aktarabilir miyim?**

Evet, tüm sunumu dışarı almadan sadece grafiği bir görüntü (örneğin PNG) olarak dışa aktarabilirsiniz.