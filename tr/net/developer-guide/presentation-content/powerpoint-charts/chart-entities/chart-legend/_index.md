---
title: .NET'te Sunumlarda Grafik Açıklama Satırlarını Özelleştirme
linktitle: Grafik Açıklama Satırı
type: docs
url: /tr/net/chart-legend/
keywords:
- grafik açıklama satırı
- açıklama satırı konumu
- yazı tipi boyutu
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile grafik açıklama satırlarını özelleştirerek, PowerPoint sunumlarını özel açıklama satırı biçimlendirmesiyle optimize edin."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarında grafik açıklama satırlarını özelleştirme seçenekleri sunar. Bu makale, bir açıklama satırının konumlandırılması ve boyutlandırılması, tüm açıklama satırı için yazı tipi boyutunun ayarlanması ve tek bir açıklama satırı girişine biçimlendirme uygulanmasını gösterir.

Ayrıca SSS bölümünde, çizim alanının açıklama satırına yer açması için örtüşme dışı modun kullanılması, uzun açıklama satırı etiketlerinin otomatik olarak satır sonuna kaydırılması veya satır sonu karakterleriyle kullanılabilmesi ve açıklama satırı biçimlendirmesinin, açık metin ve doldurma ayarları uygulanmadığında sunum temasından miras alınması gibi ilgili davranışları ele alır.

## **Açıklama Satırı Konumlandırması**
Açıklama satırı özelliklerini ayarlamak için aşağıdaki adımları izleyin:

- Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
- Slayt referansını alın.
- Slayta bir grafik ekleyin.
- Açıklama satırı özelliklerini ayarlayın.
- Sunumu bir PPTX dosyası olarak kaydedin.

Aşağıdaki örnekte, Grafik açıklama satırı için konum ve boyut ayarladık.

```c#
 // Create an instance of Presentation class
 // Get reference of the slide
 // Add a clustered column chart on the slide
 // Set Legend Properties
 // Write presentation to disk
 Presentation presentation = new Presentation();

 // Get reference of the slide
 ISlide slide = presentation.Slides[0];

 // Add a clustered column chart on the slide
 IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

 // Set Legend Properties
 chart.Legend.X = 50 / chart.Width;
 chart.Legend.Y = 50 / chart.Height;
 chart.Legend.Width = 100 / chart.Width;
 chart.Legend.Height = 100 / chart.Height;

 // Write presentation to disk
 presentation.Save("Legend_out.pptx", SaveFormat.Pptx);
```

## **Açıklama Satırının Yazı Tipi Boyutunu Ayarlama**
Aspose.Slides for .NET, geliştiricilerin açıklama satırının yazı tipi boyutunu ayarlamasına olanak tanır. Lütfen aşağıdaki adımları izleyin:

- `Presentation` sınıfının bir örneğini oluşturun.
- Varsayılan grafiği oluşturun.
- Yazı tipi boyutunu ayarlayın.
- Minimum eksen değerini ayarlayın.
- Maksimum eksen değerini ayarlayın.
- Sunumu diske kaydedin.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 600, 400);

	chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
	chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
	chart.Axes.VerticalAxis.MinValue = -5;
	chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
	chart.Axes.VerticalAxis.MaxValue = 10;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Bireysel Açıklama Satırının Yazı Tipi Boyutunu Ayarlama**
Aspose.Slides for .NET, geliştiricilerin bireysel açıklama satırı girişlerinin yazı tipi boyutunu ayarlamasına olanak tanır. Lütfen aşağıdaki adımları izleyin:

- `Presentation` sınıfının bir örneğini oluşturun.
- Varsayılan grafiği oluşturun.
- Açıklama satırı girişine erişin.
- Yazı tipi boyutunu ayarlayın.
- Minimum eksen değerini ayarlayın.
- Maksimum eksen değerini ayarlayın.
- Sunumu diske kaydedin.

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
	IChartTextFormat tf = chart.Legend.Entries[1].TextFormat;

	tf.PortionFormat.FontBold = NullableBool.True;
	tf.PortionFormat.FontHeight = 20;
	tf.PortionFormat.FontItalic = NullableBool.True;
	tf.PortionFormat.FillFormat.FillType = FillType.Solid; ;
	tf.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

	pres.Save("output.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Grafiğin açıklama satırını etkinleştirerek, otomatik olarak yer ayırmasını ve üst üste bindirilmemesini sağlayabilir miyim?**

Evet. Örtüşme dışı modu kullanın ([Overlay](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/legend/overlay/) = `false`); bu durumda, çizim alanı açıklama satırına yer açmak için küçülür.

**Çok satırlı açıklama satırı etiketleri oluşturabilir miyim?**

Evet. Uzun etiketler, alan yetersiz olduğunda otomatik olarak satır sonuna kaydırılır; zorunlu satır sonları, seri adındaki yeni satır karakterleriyle desteklenir.

**Açıklama satırının sunum temasının renk şemasını izlemesini nasıl sağlarsınız?**

Açıklama satırı veya metni için açık renkler/doldurmalar/yazı tipleri ayarlamayın. Böylece tema tarafından devralınır ve tasarım değiştiğinde doğru şekilde güncellenir.