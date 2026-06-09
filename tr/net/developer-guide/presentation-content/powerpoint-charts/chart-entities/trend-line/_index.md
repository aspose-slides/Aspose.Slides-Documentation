---
title: .NET'te Sunum Grafiklerine Trend Çizgileri Ekle
linktitle: Trend Çizgisi
type: docs
url: /tr/net/trend-line/
keywords:
- grafik
- trend çizgisi
- üstel trend çizgisi
- doğrusal trend çizgisi
- logaritmik trend çizgisi
- hareketli ortalama trend çizgisi
- polinomsal trend çizgisi
- güç trend çizgisi
- özel trend çizgisi
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "PowerPoint grafiklerine Aspose.Slides for .NET ile trend çizgilerini hızlıca ekleyin ve özelleştirin — izleyicilerinizi etkilemek için pratik bir rehber."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak sunum grafiklerine trend çizgileri eklemeyi açıklar. Bir grafik oluşturmayı, grafik serilerine trend çizgileri eklemeyi ve üstel, doğrusal, logaritmik, hareketli ortalama, polinomsal ve güç gibi çeşitli trend çizgisi türleriyle çalışmayı gösterir.

Ayrıca bir çizgi şekli ekleyerek grafiğe özel bir çizgi nasıl eklenir açıklanır ve trend çizgisi ileri ve geri projeksiyon değerleri ile PDF veya SVG'ye ve grafiklerin görüntülere aktarılırken trend çizgilerinin korunup korunmadığı hakkında kısa bir SSS içerir.

## **Trend Çizgisi Ekle**
Aspose.Slides for .NET, farklı grafik Trend Çizgilerini yönetmek için basit bir API sağlar:

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. Bir slaydın referansını indeksine göre alın.
1. İstenilen türde (bu örnek ChartType.ClusteredColumn kullanır) varsayılan veri ile bir grafik ekleyin.
1. Grafik serisi 1 için üstel trend çizgisi ekleyin.
1. Grafik serisi 1 için doğrusal trend çizgisi ekleyin.
1. Grafik serisi 2 için logaritmik trend çizgisi ekleyin.
1. Grafik serisi 2 için hareketli ortalama trend çizgisi ekleyin.
1. Grafik serisi 3 için polinomsal trend çizgisi ekleyin.
1. Grafik serisi 3 için güç trend çizgisi ekleyin.
1. Değiştirilen sunumu bir PPTX dosyasına yazın.

Aşağıdaki kod, Trend Çizgileri ile bir grafik oluşturmak için kullanılır.

```c#
// Boş bir sunum oluşturma
Presentation pres = new Presentation();

// Bir küme sütun grafiği oluşturma
IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 400);

// Grafik serisi 1 için üstel trend çizgisi ekleme
ITrendline tredLinep = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Exponential);
tredLinep.DisplayEquation = false;
tredLinep.DisplayRSquaredValue = false;

// Grafik serisi 1 için doğrusal trend çizgisi ekleme
ITrendline tredLineLin = chart.ChartData.Series[0].TrendLines.Add(TrendlineType.Linear);
tredLineLin.TrendlineType = TrendlineType.Linear;
tredLineLin.Format.Line.FillFormat.FillType = FillType.Solid;
tredLineLin.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;


// Grafik serisi 2 için logaritmik trend çizgisi ekleme
ITrendline tredLineLog = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Logarithmic);
tredLineLog.TrendlineType = TrendlineType.Logarithmic;
tredLineLog.AddTextFrameForOverriding("New log trend line");

// Grafik serisi 2 için hareketli ortalama trend çizgisi ekleme
ITrendline tredLineMovAvg = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.MovingAverage);
tredLineMovAvg.TrendlineType = TrendlineType.MovingAverage;
tredLineMovAvg.Period = 3;
tredLineMovAvg.TrendlineName = "New TrendLine Name";

// Grafik serisi 3 için polinomsal trend çizgisi ekleme
ITrendline tredLinePol = chart.ChartData.Series[2].TrendLines.Add(TrendlineType.Polynomial);
tredLinePol.TrendlineType = TrendlineType.Polynomial;
tredLinePol.Forward = 1;
tredLinePol.Order = 3;

// Grafik serisi 3 için güç trend çizgisi ekleme
ITrendline tredLinePower = chart.ChartData.Series[1].TrendLines.Add(TrendlineType.Power);
tredLinePower.TrendlineType = TrendlineType.Power;
tredLinePower.Backward = 1;

// Sunumu kaydetme
pres.Save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
```



## **Özel Çizgi Ekle**
Aspose.Slides for .NET, bir grafiğe özel çizgiler eklemek için basit bir API sağlar. Sunumun seçili slaydına basit bir düz çizgi eklemek için aşağıdaki adımları izleyin:

- Presentation sınıfının bir örneğini oluşturun
- Index özelliğini kullanarak bir slaydın referansını alın
- Shapes nesnesi tarafından sunulan AddChart yöntemiyle yeni bir grafik oluşturun
- Shapes nesnesi tarafından sunulan AddAutoShape yöntemiyle Çizgi tipinde bir AutoShape ekleyin
- Şekil çizgilerinin Rengini ayarlayın.
- Değiştirilen sunumu bir PPTX dosyası olarak yazın

Aşağıdaki kod, Özel Çizgiler ile bir grafik oluşturmak için kullanılır.

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.UserShapes.Shapes.AddAutoShape(ShapeType.Line, 0, chart.Height / 2, chart.Width, 0);
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
    pres.Save("AddCustomLines.pptx", SaveFormat.Pptx);
}
```

## **SSS**

**Trend çizgisi için 'ileri' ve 'geri' ne anlama geliyor?**

Trend çizgisinin ileri/geri projekte edilen uzunluklarıdır: dağılım (XY) grafiklerinde eksen birimlerinde; dağılım olmayan grafiklerde kategori sayısında. Yalnızca negatif olmayan değerler kullanılabilir.

**Trend çizgisi, sunumu PDF veya SVG'ye dışa aktarırken ya da bir slaytı görüntü olarak işlediğinizde korunur mu?**

Evet. Aspose.Slides, sunumları [PDF](/slides/tr/net/convert-powerpoint-to-pdf/)/[SVG](/slides/tr/net/render-a-slide-as-an-svg-image/) formatına dönüştürür ve grafikleri görüntülere işler; trend çizgileri, grafiğin bir parçası olarak bu işlemler sırasında korunur. Ayrıca grafiğin kendisinin bir görüntüsünü [dışa aktarmak](/slides/tr/net/create-shape-thumbnails/) için bir yöntem de mevcuttur.