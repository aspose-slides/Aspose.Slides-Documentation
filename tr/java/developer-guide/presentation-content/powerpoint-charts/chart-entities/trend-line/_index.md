---
title: Java'da Sunum Grafiklerine Trend Çizgileri Ekle
linktitle: Trend Çizgisi
type: docs
url: /tr/java/trend-line/
keywords:
- grafik
- trend çizgisi
- üstel trend çizgisi
- lineer trend çizgisi
- logaritmik trend çizgisi
- hareketli ortalama trend çizgisi
- polinom trend çizgisi
- güç trend çizgisi
- özel trend çizgisi
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint grafiklerine trend çizgilerini hızlıca ekleyin ve özelleştirin — izleyicilerinizi etkilemek için pratik bir rehber."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak sunum grafiklerine trend çizgileri eklemeyi açıklar. Bir grafik oluşturmayı, grafik serilerine trend çizgileri eklemeyi ve üstel, lineer, logaritmik, hareketli ortalama, polinom ve güç gibi çeşitli trend çizgi türleriyle çalışmayı gösterir.

Ayrıca, bir çizgi şekli ekleyerek grafiğe özel bir çizgi eklemenin nasıl yapılacağını açıklar ve ileri ve geri trend çizgi projeksiyon değerleri ile trend çizgilerinin PDF veya SVG olarak dışa aktarılırken ve grafikler görüntülere render edilirken korunup korunmadığına dair kısa bir SSS içerir.

## **Trend Çizgisi Ekle**
Aspose.Slides for Java, farklı grafik Trend Çizgilerini yönetmek için basit bir API sağlar:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.
2. Kaydırmanın referansını indeksiyle elde edin.
3. İstenilen türde (bu örnek ChartType.ClusteredColumn kullanır) bir grafik ekleyin ve varsayılan verileri ekleyin.
4. Grafik serisi 1 için üstel trend çizgisi ekleme.
5. Grafik serisi 1 için lineer trend çizgisi ekleme.
6. Grafik serisi 2 için logaritmik trend çizgisi ekleme.
7. Grafik serisi 2 için hareketli ortalama trend çizgisi ekleme.
8. Grafik serisi 3 için polinom trend çizgisi ekleme.
9. Grafik serisi 3 için güç trend çizgisi ekleme.
10. Değiştirilen sunumu bir PPTX dosyasına yazın.

Aşağıdaki kod, Trend Çizgileri ile bir grafik oluşturmak için kullanılır.

```java
// Presentation sınıfının bir örneğini oluştur
Presentation pres = new Presentation();
try {
    // Kümeleme sütun grafiği oluşturma
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 400);
    
    // Grafik serisi 1 için üstel trend çizgisi ekleme
    ITrendline tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    
    // Grafik serisi 1 için lineer trend çizgisi ekleme
    ITrendline tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(TrendlineType.Linear);
    tredLineLin.setTrendlineType(TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    
    
    // Grafik serisi 2 için logaritmik trend çizgisi ekleme
    ITrendline tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    
    // Grafik serisi 2 için hareketli ortalama trend çizgisi ekleme
    ITrendline tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod((byte)3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    
    // Grafik serisi 3 için polinom trend çizgisi ekleme
    ITrendline tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder((byte)3);
    
    // Grafik serisi 3 için güç trend çizgisi ekleme
    ITrendline tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(TrendlineType.Power);
    tredLinePower.setTrendlineType(TrendlineType.Power);
    tredLinePower.setBackward(1);
    
    // Sunumu kaydetme
    pres.save("ChartTrendLines_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Özel Çizgi Ekle**
Aspose.Slides for Java, bir grafiğe özel çizgiler eklemek için basit bir API sağlar. Sunumun seçilen bir slaytına basit bir düz çizgi eklemek için aşağıdaki adımları izleyin:

- [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun
- Kaydırmanın referansını indeksini kullanarak alın
- Shapes nesnesi tarafından sunulan AddChart yöntemiyle yeni bir grafik oluşturun
- Shapes nesnesi tarafından sunulan AddAutoShape yöntemiyle Çizgi tipinde bir AutoShape ekleyin
- Şekil çizgilerinin rengini ayarlayın.
- Değiştirilen sunumu bir PPTX dosyası olarak yazın

Aşağıdaki kod, Özel Çizgilerle bir grafik oluşturmak için kullanılır.

```java
// Presentation sınıfının bir örneğini oluştur
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    IAutoShape shape = chart.getUserShapes().getShapes().addAutoShape(ShapeType.Line, 0, chart.getHeight()/2, chart.getWidth(), 0);
    
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.awt.Color.RED);
    
    pres.save("Presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**Trend çizgi için 'ileri' ve 'geri' ne anlama gelir?**

Bunlar, trend çizgisinin ileri/geri yönüne projekte edilen uzunluklarıdır: dağılım (XY) grafiklerinde — eksen birimlerinde; dağılım olmayan grafiklerde — kategori sayısı olarak. Yalnızca negatif olmayan değerler izinlidir.

**Sunumu PDF veya SVG olarak dışa aktarırken ya da bir slaytı görüntüye render ederken trend çizgi korunur mu?**

Evet. Aspose.Slides, sunumları [PDF](/slides/tr/java/convert-powerpoint-to-pdf/)/[SVG](/slides/tr/java/render-a-slide-as-an-svg-image/) formatlarına dönüştürür ve grafikleri görüntülere render eder; trend çizgileri, grafiğin bir parçası olarak, bu işlemler sırasında korunur. Ayrıca grafiğin kendisinin bir görüntüsünü [dışa aktarmak](/slides/tr/java/create-shape-thumbnails/) için bir yöntem de mevcuttur.