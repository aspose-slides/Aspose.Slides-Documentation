---
title: PowerPoint Sunumlarında .NET ile Grafik Eksenlerini Özelleştirme
linktitle: Grafik Ekseni
type: docs
url: /tr/net/chart-axis/
keywords:
- grafik ekseni
- dikey eksen
- yatay eksen
- eksen özelleştirme
- eksen manipülasyonu
- eksen yönetimi
- eksen özellikleri
- azami değer
- asgari değer
- eksen çizgisi
- tarih biçimi
- eksen başlığı
- eksen konumu
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Raporlar ve görselleştirmeler için PowerPoint sunumlarında grafik eksenlerini özelleştirmek amacıyla Aspose.Slides for .NET'in nasıl kullanılacağını keşfedin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'ta grafik eksenlerini nasıl özelleştireceğinizi açıklar. Gerçek eksen değerlerini nasıl elde edeceğinizi, eksenler arasında veriyi nasıl değiştireceğinizi, çizgi grafiklerde dikey veya yatay ekseni nasıl gizleyeceğinizi, kategori ekseni tipini nasıl değiştireceğinizi, kategori ekseni değerleri için tarih biçimini nasıl ayarlayacağınızı, bir eksen başlığını nasıl döndüreceğinizi, eksen konumunu nasıl ayarlayacağınızı ve değer ekseninde bir birim etiketi nasıl görüntüleneceğini gösterir.

## **Grafiklerde Dikey Eksenin Azami Değerlerini Alma**
Aspose.Slides for .NET, bir dikey eksende minimum ve maksimum değerleri almanıza olanak tanır. Bu adımları izleyin:

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
2. İlk slayta erişin.
3. Varsayılan verilerle bir grafik ekleyin.
4. Eksen üzerindeki gerçek maksimum değeri alın.
5. Eksen üzerindeki gerçek minimum değeri alın.
6. Eksenin gerçek büyük birimini alın.
7. Eksenin gerçek küçük birimini alın.
8. Eksenin gerçek büyük birim ölçeğini alın.
9. Eksenin gerçek küçük birim ölçeğini alın.

Bu örnek kod—yukarıdaki adımların bir uygulaması—gerekli değerleri C# ile nasıl alacağınızı gösterir:

```c#
using (Presentation pres = new Presentation())
{
	Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
	chart.ValidateChartLayout();

	double maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
	double minValue = chart.Axes.VerticalAxis.ActualMinValue;

	double majorUnit = chart.Axes.HorizontalAxis.ActualMajorUnit;
	double minorUnit = chart.Axes.HorizontalAxis.ActualMinorUnit;
	
	// Sunumu kaydeder
	presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```

## **Eksenler Arasındaki Veriyi Değiştir**
Aspose.Slides, eksenler arasındaki veriyi hızlı bir şekilde takas etmenizi sağlar—dikey eksende (y-eksen) temsil edilen veri yatay eksene (x-eksen) ve tersine taşır. 

Bu C# kodu, bir grafikte eksenler arasındaki veri takasını nasıl gerçekleştireceğinizi gösterir:

```c#
 // Boş sunum oluşturur
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	//Satır ve sütunları değiştirir
	chart.ChartData.SwitchRowColumn();
		   
	 // Sunumu kaydeder
	 pres.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
 }
```

## **Çizgi Grafiklerde Dikey Ekseni Devre Dışı Bırak**

Bu C# kodu, bir çizgi grafik için dikey ekseni nasıl gizleyeceğinizi gösterir:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.VerticalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **Çizgi Grafiklerde Yatay Ekseni Devre Dışı Bırak**

Bu kod, bir çizgi grafik için yatay ekseni nasıl gizleyeceğinizi gösterir:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.HorizontalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **Kategori Eksenini Değiştir**

**CategoryAxisType** özelliğini kullanarak, tercih ettiğiniz kategori ekseni tipini (**date** veya **text**) belirtebilirsiniz. Bu C# kodu işlemi gösterir: 

```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    IChart chart = presentation.Slides[0].Shapes[0] as IChart;
    chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
    chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.HorizontalAxis.MajorUnit = 1;
    chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;
    presentation.Save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
}
```

## **Kategori Eksen Değerleri için Tarih Biçimini Ayarla**
Aspose.Slides for .NET, bir kategori ekseni değeri için tarih biçimini ayarlamanıza olanak tanır. Bu işlem bu C# kodunda gösterilmiştir:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Area, 50, 50, 450, 300);

	IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

	wb.Clear(0);

	chart.ChartData.Categories.Clear();
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Add(wb.GetCell(0, "A2", new DateTime(2015, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A3", new DateTime(2016, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A4", new DateTime(2017, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A5", new DateTime(2018, 1, 1).ToOADate()));

	IChartSeries series = chart.ChartData.Series.Add(ChartType.Line);
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B2", 1));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B3", 2));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B4", 3));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B5", 4));
	chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
	chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
	chart.Axes.HorizontalAxis.NumberFormat = "yyyy";
	pres.Save("test.pptx", SaveFormat.Pptx);
}
```

## **Grafik Eksen Başlığı için Döndürme Açısını Ayarla**
Aspose.Slides for .NET, bir grafik eksen başlığı için döndürme açısını ayarlamanıza olanak tanır. Bu C# kodu işlemi gösterir:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.HasTitle = true;
             chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

	pres.Save("test.pptx", SaveFormat.Pptx);
}
```

## **Kategori veya Değer Ekseninde Eksen Konumunu Ayarla**
Aspose.Slides for .NET, bir kategori veya değer ekseninde eksen konumunu ayarlamanıza olanak tanır. Bu C# kodu görevi nasıl gerçekleştireceğinizi gösterir:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

	pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
}
```

## **Grafik Değer Ekseninde Birim Etiketini Görüntülemeyi Etkinleştir**
Aspose.Slides for .NET, bir grafik değer ekseninde bir birim etiketi gösterecek şekilde yapılandırmanıza olanak tanır. Bu C# kodu işlemi gösterir:

```c#
using (Presentation pres = new Presentation(dataDir+"Test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

## **SSS**

**Bir eksenin diğerini kestiği değeri (ekseni kesişim) nasıl ayarlarım?**

Eksenler, bir [kesişme ayarı](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/axis/crosstype/) sunar: sıfırda, maksimum kategori/değerde veya belirli bir sayısal değerde kesişmeyi seçebilirsiniz. Bu, X eksenini yukarı ya da aşağı kaydırmak veya bir temel çizgiyi vurgulamak için faydalıdır.

**Çizgi etiketlerini eksene göre (yanında, dışarıda, içinde) nasıl konumlandırabilirim?**

[label position](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/axis/majortickmark/) özelliğini "cross", "outside" veya "inside" olarak ayarlayın. Bu, okunabilirliği etkiler ve özellikle küçük grafiklerde alan tasarrufu sağlar.