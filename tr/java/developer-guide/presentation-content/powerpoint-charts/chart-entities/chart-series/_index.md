---
title: Java kullanarak Sunumlarda Grafik Veri Serilerini Yönetme
linktitle: Veri Serileri
type: docs
url: /tr/java/chart-series/
keywords:
- grafik serileri
- seri çakışması
- seri rengi
- kategori rengi
- seri adı
- veri noktası
- seri boşluğu
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "PowerPoint (PPT/PPTX) için Java’da grafik serilerini nasıl yöneteceğinizi, pratik kod örnekleri ve en iyi uygulamalarla veri sunumlarınızı geliştirmek üzere öğrenin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides içinde [ChartSeries](https://reference.aspose.com/slides/tr/java/com.aspose.slides/chartseries/) rolünü, verilerin sunumlar içinde nasıl yapılandırıldığını ve görselleştirildiğini odaklanarak açıklar. Bu nesneler, bir grafikte bireysel veri noktası setlerini, kategorileri ve görünüm parametrelerini tanımlayan temel bileşenleri sağlar. [ChartSeries](https://reference.aspose.com/slides/tr/java/com.aspose.slides/chartseries/) ile çalışarak, geliştiriciler temel veri kaynaklarını sorunsuz bir şekilde entegre edebilir ve bilginin nasıl gösterileceği üzerinde tam kontrol sağlayabilir; bu da içgörü ve analizi açıkça ileten dinamik, veri odaklı sunumlar ortaya çıkarır.

Seri, bir grafikte çizilen bir satır veya sütun sayılardır.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Grafik Serisi Çakışmasını Ayarlama**

[IChartSeriesOverlap](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/ichartseries/properties/overlap) özelliği ile, 2B bir grafikte çubukların ve sütunların ne kadar çakışacağını belirtebilirsiniz (aralık: -100 ila 100). Bu özellik, üst seri grubunun tüm serilerine uygulanır: bu, ilgili grup özelliğinin bir yansımasıdır. Bu nedenle, bu özellik salt okunurdur.  

`ParentSeriesGroup.Overlap` okuma/yazma özelliğini kullanarak `Overlap` için tercih ettiğiniz değeri ayarlayabilirsiniz.  

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
1. Bir slayta kümeleme sütun grafiği ekleyin.  
1. İlk grafik serisine erişin.  
1. Grafik serisinin `ParentSeriesGroup` özelliğine erişin ve seri için tercih ettiğiniz çakışma değerini ayarlayın.  
1. Değiştirilmiş sunumu bir PPTX dosyasına yazın.  

Bu Java kodu, bir grafik serisinin çakışmasını nasıl ayarlayacağınızı gösterir:

```java
Presentation pres = new Presentation();
try {
    // Grafik ekler
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0)
    {
        // Seri çakışmasını ayarlar
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);
    }

    // Sunum dosyasını diske yazar
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Seri Rengini Değiştirme**

Aspose.Slides for Java, bir serinin rengini şu şekilde değiştirmenize olanak tanır:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
1. Slayta bir grafik ekleyin.  
1. Rengini değiştirmek istediğiniz seriye erişin.  
1. Tercih ettiğiniz doldurma türünü ve doldurma rengini ayarlayın.  
1. Değiştirilmiş sunumu kaydedin.  

Bu Java kodu, bir serinin rengini nasıl değiştireceğinizi gösterir:

```java
Presentation pres = new Presentation("test.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(1);

    point.setExplosion(30);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Seri Kategori Rengini Değiştirme**

Aspose.Slides for Java, bir seri kategorisinin rengini şu şekilde değiştirmenize olanak tanır:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
1. Slayta bir grafik ekleyin.  
1. Rengini değiştirmek istediğiniz seri kategorisine erişin.  
1. Tercih ettiğiniz doldurma türünü ve doldurma rengini ayarlayın.  
1. Değiştirilmiş sunumu kaydedin.  

Bu Java kodu, bir seri kategorisinin rengini nasıl değiştireceğinizi gösterir:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(0);

    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Seri Adını Değiştirme**

Varsayılan olarak, bir grafiğin lejand adları, her sütun veya satırın üzerindeki hücrelerin içeriğidir.  

Örnekimizde (örnek resim),

* sütunlar *Series 1, Series 2,* ve *Series 3*;  
* satırlar *Category 1, Category 2, Category 3,* ve *Category 4.*  

Aspose.Slides for Java, bir serinin adını grafik verisinde ve lejandında güncellemenize veya değiştirmenize olanak tanır.  

Bu Java kodu, `ChartDataWorkbook` içinde bir serinin adını nasıl değiştireceğinizi gösterir:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);

    IChartDataCell seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("New name");

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Bu Java kodu, `Series` aracılığıyla lejanddaki bir serinin adını nasıl değiştireceğinizi gösterir:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    IStringChartValue name = series.getName();
    name.getAsCells().get_Item(0).setValue("New name");
} finally {
    if (pres != null) pres.dispose();
}
```

## **Grafik Serisi Doldurma Rengini Ayarlama**

Aspose.Slides for Java, bir çizim alanı içindeki grafik serileri için otomatik doldurma rengini şu şekilde ayarlamanıza izin verir:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
1. Bir slaydın referansını indeksine göre alın.  
1. Tercih ettiğiniz türe göre (aşağıdaki örnekte `ChartType.ClusteredColumn` kullandık) varsayılan verilerle bir grafik ekleyin.  
1. Grafik serisine erişin ve doldurma rengini Automatic (Otomatik) olarak ayarlayın.  
1. Sunumu bir PPTX dosyasına kaydedin.  

Bu Java kodu, bir grafik serisi için otomatik doldurma rengini nasıl ayarlayacağınızı gösterir:

```java
Presentation pres = new Presentation();
try {
    // Kümeleme sütun grafiği oluşturur
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // Seri dolgu biçimini otomatik olarak ayarlar
    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }

    // Sunum dosyasını diske yazar
    pres.save("AutoFillSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Grafik Serisi için Ters Doldurma Rengini Ayarlama**

Aspose.Slides, bir çizim alanı içindeki grafik serileri için ters doldurma rengini şu şekilde ayarlamanıza izin verir:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
1. Bir slaydın referansını indeksine göre alın.  
1. Tercih ettiğiniz türe göre (aşağıdaki örnekte `ChartType.ClusteredColumn` kullandık) varsayılan verilerle bir grafik ekleyin.  
1. Grafik serisine erişin ve doldurma rengini invert (ters) olarak ayarlayın.  
1. Sunumu bir PPTX dosyasına kaydedin.  

Bu Java kodu işlemi gösterir:

```java
Color inverColor = Color.RED;
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Yeni serileri ve kategorileri ekler
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));

    // İlk grafik serisini alır ve seri verilerini doldurur.
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    Color seriesColor = series.getAutomaticSeriesColor();
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(inverColor);
    
    pres.save("SetInvertFillColorChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Değer Negatif Olduğunda Seri için Ters Ayarlama**

Aspose.Slides, `IChartDataPoint.InvertIfNegative` ve `ChartDataPoint.InvertIfNegative` özellikleri aracılığıyla ters ayarlamalar yapmanıza olanak tanır. Bu özellikler kullanılarak bir ters ayar yapıldığında, veri noktası negatif bir değer aldığında renklerini tersine çevirir.  

Bu Java kodu işlemi gösterir:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();

    IChartSeries chartSeries = series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2", -5));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3", 3));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4", -2));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5", 1));

    chartSeries.setInvertIfNegative(false);

    chartSeries.getDataPoints().get_Item(2).setInvertIfNegative(true);

    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Belirli Nokta Verilerini Temizleme**

Aspose.Slides for Java, belirli bir grafik serisi için `DataPoints` verilerini şu şekilde temizlemenize olanak tanır:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Bir slaydın referansını indeks üzerinden alın.  
3. Bir grafiğin referansını indeks üzerinden alın.  
4. Tüm grafik `DataPoints` değerlerini döngüye alarak `XValue` ve `YValue` değerlerini null olarak ayarlayın.  
5. Belirli grafik serisi için tüm `DataPoints` değerlerini temizleyin.  
6. Değiştirilmiş sunumu bir PPTX dosyasına yazın.  

Bu Java kodu işlemi gösterir:

```java
Presentation pres = new Presentation("TestChart.pptx");
try {
    ISlide sl = pres.getSlides().get_Item(0);

    IChart chart = (IChart)sl.getShapes().get_Item(0);

    for (IChartDataPoint dataPoint : chart.getChartData().getSeries().get_Item(0).getDataPoints())
    {
        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }

    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();

    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Seri Boşluk Genişliğini Ayarlama**

Aspose.Slides for Java, bir serinin **`GapWidth`** özelliği aracılığıyla Boşluk Genişliğini şu şekilde ayarlamanıza imkan tanır:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
1. İlk slayta erişin.  
1. Varsayılan verilerle bir grafik ekleyin.  
1. Herhangi bir grafik serisine erişin.  
1. `GapWidth` özelliğini ayarlayın.  
1. Değiştirilmiş sunumu bir PPTX dosyasına yazın.  

Bu Java kodu, bir serinin Boşluk Genişliğini nasıl ayarlayacağınızı gösterir:

```java
// Boş sunum oluşturur 
Presentation pres = new Presentation();
try {
    // Sunumun ilk slaytına erişir
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Varsayılan verilerle bir grafik ekler
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 0, 0, 500, 500);
    
    // Grafik veri sayfasının indeksini ayarlar
    int defaultWorksheetIndex = 0;
    
    // Grafik veri çalışma sayfasını alır
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Serileri ekler
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // Kategorileri ekler
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // İkinci grafik serisini alır
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // Seri verilerini doldurur
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // GapWidth değerini ayarlar
    series.getParentSeriesGroup().setGapWidth(50);
    
    // Sunumu diske kaydeder
    pres.save("GapWidth_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Bir tek grafiğin içerebileceği seri sayısında bir limit var mı?**

Aspose.Slides, eklediğiniz seri sayısı için sabit bir üst sınır koymaz. Pratikteki üst limit, grafiğin okunabilirliği ve uygulamanızın mevcut belleği ile belirlenir.

**Küme içindeki sütunlar çok yakın ya da çok uzak olduğunda ne yapılır?**

`GapWidth` ayarını ilgili seri (veya üst seri grubu) için ayarlayın. Değeri artırmak sütunlar arasındaki boşluğu genişletirken, azaltmak onları birbirine daha yakın hâle getirir.