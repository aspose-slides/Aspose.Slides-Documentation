---
title: Sunum Grafiklerine Trend Çizgileri Ekle C++'da
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
- С++
- Aspose.Slides
description: "Aspose.Slides for С++ ile PowerPoint grafiklerine trend çizgileri hızlıca ekleyin ve özelleştirin — izleyicilerinizi etkilemek için pratik bir rehber."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak sunum grafiklerine trend çizgileri eklemenin nasıl yapılacağını açıklar. Bir grafik oluşturmayı, grafik serilerine trend çizgileri eklemeyi ve üssel, doğrusal, logaritmik, hareketli ortalama, polinom ve güç gibi çeşitli trend çizgi türleriyle çalışmayı gösterir.

Ayrıca, bir çizgi şekli ekleyerek grafiğe özel bir çizgi nasıl eklenir açıklanır ve ileri ve geri trend çizgisi projeksiyon değerleri ile trend çizgilerinin PDF veya SVG'ye dışa aktarılırken ve grafikler görüntü olarak işlenirken korunup korunmadığına dair kısa bir SSS içerir.

## **Trend Çizgisi Ekle**
Aspose.Slides for C++ farklı grafik Trend Çizgilerini yönetmek için basit bir API sağlar:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.
2. Bir slaytın referansını indeksine göre alın.
3. İstediğiniz tipte bir grafik ekleyin (bu örnek ChartType.ClusteredColumn kullanır) ve varsayılan verileri ekleyin.
4. Grafik serisi 1 için üssel trend çizgisi ekleniyor.
5. Grafik serisi 1 için doğrusal trend çizgisi ekleniyor.
6. Grafik serisi 2 için logaritmik trend çizgisi ekleniyor.
7. Grafik serisi 2 için hareketli ortalama trend çizgisi ekleniyor.
8. Grafik serisi 3 için polinom trend çizgisi ekleniyor.
9. Grafik serisi 3 için güç trend çizgisi ekleniyor.
10. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

Aşağıdaki kod, Trend Çizgileriyle bir grafik oluşturmak için kullanılır.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChartTrendLines-ChartTrendLines.cpp" >}}

## **Özel Çizgi Ekle**
Aspose.Slides for C++ bir grafiğe özel çizgiler eklemek için basit bir API sağlar. Sunumun seçilen bir slaydına basit bir düz çizgi eklemek için lütfen aşağıdaki adımları izleyin:

- Presentation sınıfının bir örneğini oluşturun
- Bir slaydın referansını indeksini kullanarak alın
- Shapes nesnesi tarafından sunulan AddChart yöntemiyle yeni bir grafik oluşturun
- Shapes nesnesi tarafından sunulan AddAutoShape yöntemiyle Çizgi tipinde bir AutoShape ekleyin
- Şekil çizgilerinin rengini ayarlayın.
- Değiştirilmiş sunumu PPTX dosyası olarak yazın

Aşağıdaki kod, Özel Çizgilerle bir grafik oluşturmak için kullanılır.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingCustomLines-AddingCustomLines.cpp" >}}

## **SSS**

**Trend çizgisi için 'ileri' ve 'geri' ne anlama gelir?**

Bunlar, trend çizgisinin ileri/geri yönünde projekte edilen uzunluklarıdır: dağılım (XY) grafiklerinde — eksen birimleri cinsinden; dağılım olmayan grafiklerde — kategori sayısı olarak. Yalnızca negatif olmayan değerler kabul edilir.

**Sunumu PDF veya SVG olarak dışa aktarırken veya bir slaytı görüntüye renderlarken trend çizgisi korunur mu?**

Evet. Aspose.Slides sunumları [PDF](/slides/tr/cpp/convert-powerpoint-to-pdf/)/[SVG](/slides/tr/cpp/render-a-slide-as-an-svg-image/) formatına dönüştürür ve grafiklerini görüntülere renderlar; trend çizgileri, grafiğin bir parçası olarak, bu işlemler sırasında korunur. Ayrıca grafiğin kendisinin bir görüntüsünü [dışa aktarmak](/slides/tr/cpp/create-shape-thumbnails/) için bir yöntem de mevcuttur.