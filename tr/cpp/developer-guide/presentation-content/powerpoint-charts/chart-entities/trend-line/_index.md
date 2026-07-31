---
title: C++ Sunum Grafiklerine Trend Çizgileri Ekle
linktitle: Trend Çizgisi
type: docs
url: /tr/cpp/trend-line/
keywords:
- grafik
- trend çizgisi
- üstel trend çizgisi
- doğrusal trend çizgisi
- logaritmik trend çizgisi
- hareketli ortalama trend çizgisi
- polinom trend çizgisi
- güç trend çizgisi
- özel trend çizgisi
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint grafiklerine trend çizgilerini hızlıca ekleyin ve özelleştirin — izleyicilerinizi etkilemek için pratik bir rehber."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak sunum grafiklerine trend çizgileri eklemeyi açıklar. Bir grafik oluşturmayı, grafik serilerine trend çizgileri eklemeyi ve üstel, doğrusal, logaritmik, hareketli ortalama, polinom ve güç gibi çeşitli trend çizgisi türleriyle çalışmayı gösterir.

Ayrıca bir çizgi şekli ekleyerek grafiğe özel bir çizgi eklemeyi açıklar ve ileri ve geri trend çizgisi projeksiyon değerleri, trend çizgilerinin PDF veya SVG'ye dışa aktarılırken veya grafikler görüntü olarak render edildiğinde korunup korunmadığı hakkında kısa bir SSS içerir.

## **Trend Çizgisi Ekle**
Aspose.Slides for C++ farklı grafik Trend Çizgilerini yönetmek için basit bir API sağlar:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
1. Bir slaytın referansını indeksine göre alın.
1. İstenilen türden (bu örnek ChartType.ClusteredColumn kullanır) varsayılan veri ile bir grafik ekleyin.
1. Grafik serisi 1 için üstel trend çizgisi ekleme.
1. Grafik serisi 1 için doğrusal trend çizgisi ekleme.
1. Grafik serisi 2 için logaritmik trend çizgisi ekleme.
1. Grafik serisi 2 için hareketli ortalama trend çizgisi ekleme.
1. Grafik serisi 3 için polinom trend çizgisi ekleme.
1. Grafik serisi 3 için güç trend çizgisi ekleme.
1. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

Trend Çizgileriyle bir grafik oluşturmak için aşağıdaki kod kullanılır.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartTrendLines-ChartTrendLines.cpp" >}}

## **Özel Çizgi Ekle**
Aspose.Slides for C++ bir grafik içinde özel çizgiler eklemek için basit bir API sağlar. Sunumun seçili slaytına basit bir düz çizgi eklemek için aşağıdaki adımları izleyin:

- Presentation sınıfının bir örneğini oluşturun
- Index'ini kullanarak bir slaytın referansını alın
- Shapes nesnesi tarafından sunulan AddChart yöntemiyle yeni bir grafik oluşturun
- Shapes nesnesi tarafından sunulan AddAutoShape yöntemiyle Çizgi tipinde bir AutoShape ekleyin
- Şekil çizgilerinin Rengini ayarlayın.
- Değiştirilmiş sunumu bir PPTX dosyası olarak yazın

Özel Çizgilerle bir grafik oluşturmak için aşağıdaki kod kullanılır.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingCustomLines-AddingCustomLines.cpp" >}}

## **SSS**

**Bir trend çizgi için 'ileri' ve 'geri' ne anlama gelir?**

Bunlar trend çizgisinin ileri/geri projeksiyon uzunluklarıdır: dağılım (XY) grafiklerinde — eksen birimlerinde; dağılım olmayan grafiklerde — kategori sayısı olarak. Yalnızca negatif olmayan değerler kabul edilir.

**Sunumu PDF veya SVG'ye dışa aktarırken veya bir slaytı görüntüye render ederken trend çizgi korunur mu?**

Evet. Aspose.Slides sunumları [PDF](/slides/tr/cpp/convert-powerpoint-to-pdf/)/[SVG](/slides/tr/cpp/render-a-slide-as-an-svg-image/) formatına dönüştürür ve grafikleri görüntülere render eder; trend çizgileri, grafik parçası olarak, bu işlemler sırasında korunur. Ayrıca grafiğin kendisinin bir görüntüsünü [dışa aktarmak](/slides/tr/cpp/create-shape-thumbnails/) için bir yöntem de mevcuttur.