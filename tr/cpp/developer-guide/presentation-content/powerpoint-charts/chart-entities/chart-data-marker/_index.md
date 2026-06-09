---
title: Sunumlarda С++ Kullanarak Grafik Veri İşaretçilerini Yönetme
linktitle: Veri İşaretçisi
type: docs
url: /tr/cpp/chart-data-marker/
keywords:
- grafik
- veri noktası
- işaretçi
- işaretçi seçenekleri
- işaretçi boyutu
- dolgu türü
- PowerPoint
- sunum
- С++
- Aspose.Slides
description: "Aspose.Slides for С++ içinde grafik veri işaretçilerini nasıl özelleştireceğinizi öğrenin, PPT ve PPTX formatlarında sunum etkisini açık С++ kod örnekleriyle artırın."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'te grafik veri işaretçileriyle nasıl çalışılacağını açıklar. Bir grafik oluşturmayı, bir seriye ve onun veri noktalarına erişmeyi, veri noktası düzeyinde işaretçilere resim doldurulması uygulamayı, işaretçi boyutunu ayarlamayı ve güncellenmiş sunumu kaydetmeyi gösterir. Ayrıca, standart işaretçi şekillerinin `MarkerStyleType` enum'ı aracılığıyla mevcut olduğu ve işaretçi görünümünün grafikler raster formatlara veya SVG'ye dışa aktarılırken korunduğu belirtilir.

## **Grafik İşaretçilerini Ayarla**
Aspose.Slides for C++ otomatik olarak grafik serisi işaretçisini ayarlamak için basit bir API sağlar. Aşağıdaki özellikte, her grafik serisi otomatik olarak farklı bir varsayılan işaretçi sembolü alacaktır.

Aşağıdaki kod örneği, grafik serisi işaretçisinin otomatik olarak nasıl ayarlandığını gösterir.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-DefaultMarkersInChart-DefaultMarkersInChart.cpp" >}}

## **Grafik İşaretçi Seçeneklerini Ayarla**
İşaretçiler, belirli bir serinin içindeki grafik veri noktalarına ayarlanabilir. Grafik işaretçi seçeneklerini ayarlamak için lütfen aşağıdaki adımları izleyin:

- Presentation sınıfının bir örneğini oluşturun.
- Varsayılan grafiği oluşturun.
- Resmi ayarlayın.
- İlk grafik serisini alın.
- Yeni bir veri noktası ekleyin.
- Sunumu diske yazın.

Aşağıda verilen örnekte, grafik işaretçi seçeneklerini veri noktası düzeyinde ayarladık.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetMarkerOptions-SetMarkerOptions.cpp" >}}

## **Seri Veri Noktası Düzeyinde Grafik İşaretçilerini Ayarla**
Şimdi, işaretçiler belirli bir serinin içindeki grafik veri noktalarına ayarlanabilir. Grafik işaretçi seçeneklerini ayarlamak için lütfen aşağıdaki adımları izleyin:

- Presentation sınıfının bir örneğini oluşturun.
- Varsayılan grafiği oluşturun.
- Resmi ayarlayın.
- İlk grafik serisini alın.
- Yeni bir veri noktası ekleyin.
- Sunumu diske yazın.

Aşağıda verilen örnekte, grafik işaretçi seçeneklerini veri noktası düzeyinde ayarladık.

```cpp
const String outPath = u"../out/SetMarkerOptionsonSeries_out.pptx";
const String ImagePath = u"../templates/Tulips.jpg";
const String ImagePath2 = u"../templates/aspose - logo.jpg";

//Instantiate Presentation class that represents PPTX file
//PPTX dosyasını temsil eden Presentation sınıfını örnekleyin
SharedPtr<Presentation> pres = MakeObject<Presentation>();

//Access first slide
//İlk slayta erişin
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Add chart with default data
// Varsayılan veri ile grafik ekle
SharedPtr<IChart> chart = slide->get_Shapes()->AddChart(Aspose::Slides::Charts::ChartType::LineWithMarkers, 0, 0, 500, 500);

// Setting the index of chart data sheet
// Grafik veri sayfasının indeksini ayarlama
int defaultWorksheetIndex = 0;

// Getting the chart data worksheet
// Grafik veri çalışma sayfasını alıyor
SharedPtr<IChartDataWorkbook> fact = chart->get_ChartData()->get_ChartDataWorkbook();

// Delete default generated series and categories
// Varsayılan oluşturulan serileri ve kategorileri sil
chart->get_ChartData()->get_Series()->Clear();

// Now, Adding a new series
// Şimdi yeni bir seri ekleniyor
SharedPtr<IChartSeries> series = chart->get_ChartData()->get_Series()->Add(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<System::String>(u"Series 1")), chart->get_Type());

// Get the picture
// Resmi al
SharedPtr<IImage> image = Images::FromFile(ImagePath);
SharedPtr<IImage> image2 = Images::FromFile(ImagePath2);

// Add image to presentation's images collection
// Görüntüyü sunumun resim koleksiyonuna ekle
SharedPtr<IPPImage> imgx1 = pres->get_Images()->AddImage(image);
SharedPtr<IPPImage> imgx2 = pres->get_Images()->AddImage(image2);

image->Dispose();
image2->Dispose();

// Add new point (1:3) there.
 // Orada yeni nokta (1:3) ekle.
SharedPtr<IChartDataPoint> point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 1, 1, ObjectExt::Box<double>(4.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx1);

point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 2, 1, ObjectExt::Box<double>(2.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx2);

point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 3, 1, ObjectExt::Box<double>(3.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx1);

point = series->get_DataPoints()->AddDataPointForLineSeries(fact->GetCell(defaultWorksheetIndex, 4, 1, ObjectExt::Box<double>(4.5)));
point->get_Marker()->get_Format()->get_Fill()->set_FillType(FillType::Picture);
point->get_Marker()->get_Format()->get_Fill()->get_PictureFillFormat()->get_Picture()->set_Image(imgx2);

// Changing the chart series marker
series->get_Marker()->set_Size(15);

// Write the presentation file to disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
pres->Dispose();
```

## **Veri Noktalarına Renk Uygula**
Aspose.Slides for C++ kullanarak grafikteki veri noktalarına renk uygulayabilirsiniz. [**IChartDataPointLevelsManager**](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatapointlevelsmanager/) ve **[IChartDataPointLevel](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/ichartdatapointlevel/)** sınıfları, veri noktası düzeylerinin özelliklerine erişim sağlamak için eklenmiştir. Bu makale, bir grafikteki veri noktalarına nasıl erişileceğini ve renklendirileceğini gösterir.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddColorToDataPoints-AddColorToDataPoints.cpp" >}}

## **SSS**

**Hangi işaretçi şekilleri kutudan çıktığı gibi mevcuttur?**

Standart şekiller (daire, kare, elmas, üçgen vb.) mevcuttur; liste [MarkerStyleType](https://reference.aspose.com/slides/tr/cpp/aspose.slides.charts/markerstyletype/) enum'ı tarafından tanımlanır. Standart dışı bir şekle ihtiyacınız varsa, özel görselleri taklit etmek için resim doldurmalı bir işaretçi kullanın.

**Grafiği bir görüntüye veya SVG'ye dışa aktarırken işaretçiler korunur mu?**

Evet. Grafikler [raster formatlarda](/slides/tr/cpp/convert-powerpoint-to-png/) işlenirken veya [şekiller SVG olarak kaydedilirken](/slides/tr/cpp/render-a-slide-as-an-svg-image/), işaretçiler boyut, dolgu ve kontur dahil olmak üzere görünüm ve ayarlarını korur.