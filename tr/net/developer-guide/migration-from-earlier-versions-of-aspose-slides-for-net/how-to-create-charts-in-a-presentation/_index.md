---
title: .NET'te Sunumlarda Grafik Oluşturma
linktitle: Grafik Oluştur
type: docs
weight: 30
url: /tr/net/how-to-create-charts-in-a-presentation/
keywords:
- göç
- grafik oluştur
- eski kod
- modern kod
- eski yaklaşım
- modern yaklaşım
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides ile .NET'te PowerPoint PPT, PPTX ve ODP sunumlarında hem eski hem de modern grafik API'lerini kullanarak grafik oluşturmayı öğrenin."
---
{{% alert color="info" %}} 
Yeni bir [Aspose.Slides for .NET API](/slides/tr/net/) yayınlandı ve artık bu tek ürün, PowerPoint belgelerini sıfırdan oluşturma ve mevcut belgeleri düzenleme yeteneğini destekliyor.
{{% /alert %}} 
## **Eski Kod Desteği**
13.x öncesi Aspose.Slides for .NET sürümleriyle geliştirilen eski kodu kullanmak için kodunuzda bazı küçük değişiklikler yapmanız gerekir ve kod önceki gibi çalışacaktır. Eski Aspose.Slides for .NET içinde Aspose.Slide ve Aspose.Slides.Pptx ad alanlarında bulunan tüm sınıflar artık tek bir Aspose.Slides ad alanında birleştirildi. Aşağıdaki basit kod örneğine göz atın; bu örnek, eski Aspose.Slides API'si kullanılarak sunum içinde sıfırdan normal bir grafik oluşturmayı gösterir ve yeni birleştirilmiş API'ye nasıl geçileceğini anlatan adımları izleyin.
## **Eski Aspose.Slides for .NET Yaklaşımı**
```c#
using System.Drawing;

//	PPTX dosyasını temsil eden PresentationEx sınıfını örnekleyin
using (PresentationEx pres = new PresentationEx())
{
	//	İlk slayta erişin
	SlideEx sld = pres.Slides[0];

	//	 Varsayılan verilerle grafik ekleyin
	ChartEx chart = sld.Shapes.AddChart(ChartTypeEx.ClusteredColumn, 0, 0, 500, 500);

	//	Grafik başlığını ayarlama
	chart.ChartTitle.Text.Text = "Sample Title";
	chart.ChartTitle.Text.CenterText = true;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	//	İlk seriyi Değerleri Göster olarak ayarlayın
	chart.ChartData.Series[0].Labels.ShowValue = true;

	//	Grafik veri sayfasının indeksini ayarlama 
	int defaultWorksheetIndex = 0;

	//	Grafik veri çalışma sayfasını alıyor
	ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

	//	Varsayılan oluşturulan serileri ve kategorileri sil
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();
	int s = chart.ChartData.Series.Count;
	s = chart.ChartData.Categories.Count;

	//	Yeni seri ekleme
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

	//	Yeni kategoriler ekleme
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

	//	İlk grafik serisini al
	ChartSeriesEx series = chart.ChartData.Series[0];

	//	Şimdi seri verilerini dolduruyoruz
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	//	Seri için doldurma rengini ayarlama
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Red;


	//	İkinci grafik serisini al
	series = chart.ChartData.Series[1];

	//	Şimdi seri verilerini dolduruyoruz
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

	//	Seri için doldurma rengini ayarlama
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Green;


	//	Yeni seri için her kategoriye özel etiketler oluştur

	//	İlk etiket Kategori adını gösterecek
	DataLabelEx lbl = new DataLabelEx(series);
	lbl.ShowCategoryName = true;
	lbl.Id = 0;
	series.Labels.Add(lbl);

	//	İkinci etiket için seri adını göster
	lbl = new DataLabelEx(series);
	lbl.ShowSeriesName = true;
	lbl.Id = 1;
	series.Labels.Add(lbl);

	//	Üçüncü etiket için değeri göster
	lbl = new DataLabelEx(series);
	lbl.ShowValue = true;
	lbl.ShowSeriesName = true;
	lbl.Separator = "/";
	lbl.Id = 2;
	series.Labels.Add(lbl);

	//	Değeri ve özel metni göster
	lbl = new DataLabelEx(series);
	lbl.TextFrame.Text = "My text";
	lbl.Id = 3;
	series.Labels.Add(lbl);

	//	Grafikli sunumu kaydet
	pres.Write(@"D:\AsposeChart.pptx");
}
```

## **Yeni Aspose.Slides for .NET 13.x Yaklaşımı**
``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

//PPTX dosyasını temsil eden Presentation sınıfını örnekleyin//PPTX dosyasını temsil eden Presentation sınıfını örnekleyin
Presentation pres = new Presentation();

//İlk slayta erişin
ISlide sld = pres.Slides[0];

// Varsayılan verilerle grafik ekle
IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

//Grafik başlığını ayarlama
//chart.ChartTitle.TextFrameForOverriding.Text = "Sample Title";
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

//Grafik veri sayfasının indeksini ayarlama
int defaultWorksheetIndex = 0;

//Grafik veri çalışma sayfasını alıyor
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Varsayılan oluşturulan serileri ve kategorileri sil
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

//Yeni seri ekleme
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

//İlk seriyi Değerleri Göster olarak ayarla
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

//Yeni kategoriler ekleme
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

//İlk grafik serisini al
IChartSeries series = chart.ChartData.Series[0];

//Şimdi seri verilerini dolduruyoruz

series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

//Seri için doldurma rengini ayarla
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;


//İkinci grafik serisini al
series = chart.ChartData.Series[1];

//Şimdi seri verilerini dolduruyoruz
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

//Seri için doldurma rengini ayarla
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;


//Yeni seri için her kategoriye özel etiketler oluştur

//İlk etiket Kategori adını gösterecek
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

//Üçüncü etiket için değeri göster
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";

//Grafikli sunumu kaydet
pres.Save("AsposeChart.pptx", SaveFormat.Pptx);
```


Aşağıdaki basit kod örneğine göz atın; bu örnek, eski Aspose.Slides API'si kullanılarak sunum içinde sıfırdan dağılımlı bir grafik oluşturmayı ve yeni birleştirilmiş API ile nasıl gerçekleştirileceğini gösterir.
## **Eski Aspose.Slides for .NET Yaklaşımı**
```c#
using (PresentationEx pres = new PresentationEx())
{
    SlideEx slide = pres.Slides[0];

    //Varsayılan grafiği oluşturma
    ChartEx chart = slide.Shapes.AddChart(ChartTypeEx.ScatterWithSmoothLines, 0, 0, 400, 400);

    //Varsayılan grafik veri çalışma sayfası indeksini alıyor
    int defaultWorksheetIndex = 0;

    //Grafik veri çalışma sayfasına erişiliyor
    ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

    //Demo serileri sil
    chart.ChartData.Series.Clear();

    //Yeni seri ekle
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

    //İlk grafik serisini al
    ChartSeriesEx series = chart.ChartData.Series[0];

    //Oraya yeni nokta (1:3) ekle.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 1));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

    //Yeni nokta (2:10) ekle.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

    //Serinin tipini düzenle
    series.Type = ChartTypeEx.ScatterWithStraightLinesAndMarkers;

    //Grafik serisi işaretleyicisini değiştir
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Star;

    //İkinci grafik serisini al
    series = chart.ChartData.Series[1];

    //Oraya yeni nokta (5:2) ekle.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

    //Yeni nokta (3:1) ekle.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 3, 3));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

    //Yeni nokta (2:2) ekle.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 3, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

    //Yeni nokta (5:1) ekle.
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

    //Grafik serisi işaretleyicisini değiştir
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Circle;

    pres.Write("D:\\AsposeSeriesChart.pptx");
}
```

## **Yeni Aspose.Slides for .NET 13.x Yaklaşımı**
``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

//Varsayılan grafiği oluşturma
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

//Varsayılan grafik veri çalışma sayfası indeksini alıyor
int defaultWorksheetIndex = 0;

//Grafik veri çalışma sayfasına erişiliyor
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//Demo serileri sil
chart.ChartData.Series.Clear();

//Yeni seri ekle
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

//İlk grafik serisini al
IChartSeries series = chart.ChartData.Series[0];

//Oraya yeni nokta (1:3) ekle.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

//Yeni nokta (2:10) ekle.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

//Serinin tipini düzenle
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

//Grafik serisi işaretleyicisini değiştir
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

//İkinci grafik serisini al
series = chart.ChartData.Series[1];

//Oraya yeni nokta (5:2) ekle.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

//Yeni nokta (3:1) ekle.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

//Yeni nokta (2:2) ekle.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

//Yeni nokta (5:1) ekle.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

//Grafik serisi işaretleyicisini değiştir
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
```