---
title: C++ Kullanarak Sunumlarda Pasta Grafiklerini Özelleştirme
linktitle: Pasta Grafik
type: docs
url: /tr/cpp/pie-chart/
keywords:
- pasta grafik
- grafik yönetimi
- grafik özelleştirme
- grafik seçenekleri
- grafik ayarları
- çizim seçenekleri
- dilim rengi
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides ile C++'ta pasta grafikler oluşturmayı ve özelleştirmeyi öğrenin, PowerPoint'e aktarılabilir, veri hikâye anlatımınızı saniyeler içinde artırır."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'te pasta grafiklerle nasıl çalışılacağını açıklar. Pie of Pie ve Bar of Pie grafikleri için ikincil çizim seçeneklerini nasıl yapılandıracağınızı ve standart bir pasta grafik için otomatik dilim renklemeyi nasıl etkinleştireceğinizi gösterir.

Örnekler, slayta bir grafik ekleme, seri ve etiket ayarlarını ayarlama, varsayılan grafik verilerini özel kategoriler ve değerlerle değiştirme ve güncellenen sunumu kaydetme gibi pratik grafik özelleştirme adımlarına odaklanır.

## **Pie of Pie ve Bar of Pie Grafikleri için İkinci Çizim Seçenekleri**

Aspose.Slides for C++ artık Pie of Pie veya Bar of Pie grafikleri için ikinci çizim seçeneklerini destekliyor. Bu konuda, Aspose.Slides kullanarak bu seçenekleri nasıl belirteceğimizi bir örnekle göreceğiz. Özellikleri belirtmek için lütfen aşağıdaki adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıf nesnesi oluşturun.  
2. Slayta bir grafik ekleyin.  
3. Grafiğin ikinci çizim seçeneklerini belirleyin.  
4. Sunumu diske yazın.  

Aşağıda verilen örnekte, Pie of Pie grafiğinin farklı özelliklerini ayarladık.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SecondPlotOptionsforCharts-SecondPlotOptionsforCharts.cpp" >}}

## **Otomatik Pasta Grafik Dilim Renklerini Ayarlama**

Aspose.Slides for C++ otomatik pasta grafik dilim renklerini ayarlamak için basit bir API sunar. Örnek kod, yukarıda sözü geçen özelliklerin ayarlanmasını uygular.

1. Presentation sınıfının bir örneğini oluşturun.  
2. İlk slayta erişin.  
3. Varsayılan verilerle bir grafik ekleyin.  
4. Grafik başlığını ayarlayın.  
5. İlk seriyi Değerleri Göster olarak ayarlayın.  
6. Grafik veri sayfasının dizinini ayarlayın.  
7. Grafik veri çalışma sayfasını alın.  
8. Varsayılan oluşturulan serileri ve kategorileri silin.  
9. Yeni kategoriler ekleyin.  
10. Yeni seriler ekleyin.  

Değiştirilmiş sunumu bir PPTX dosyasına yazın.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SettingAutomicPieChartSliceColors-SettingAutomicPieChartSliceColors.cpp" >}}

## **SSS**

**'Pie of Pie' ve 'Bar of Pie' varyasyonları destekleniyor mu?**

Evet, kütüphane [destekliyor](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/charttype/) pasta grafikler için ikincil bir çizimi, 'Pie of Pie' ve 'Bar of Pie' tipleri dahil.

**Sadece grafiği bir görüntü olarak (örneğin PNG) dışa aktarabilir miyim?**

Evet, [grafiği doğrudan bir görüntü olarak dışa aktarabilirsiniz](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shape/getimage/) (örneğin PNG), tüm sunumu dışarı almadan.