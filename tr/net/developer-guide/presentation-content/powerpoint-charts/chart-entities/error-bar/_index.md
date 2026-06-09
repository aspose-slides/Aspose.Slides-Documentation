---
title: Sunum Grafiklerinde Hata Çubuklarını .NET'te Özelleştirme
linktitle: Hata Çubuğu
type: docs
url: /tr/net/error-bar/
keywords:
- hata çubuğu
- özel değer
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile grafiklerde hata çubuklarını eklemeyi ve özelleştirmeyi öğrenin—PowerPoint sunumlarında veri görselleştirmesini optimize edin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak sunum grafiklerinde hata çubuklarıyla nasıl çalışılacağını açıklar. Bir grafik serisine hata çubukları eklemeyi, X ve Y hata çubuğu ayarlarını yapılandırmayı ve sabit, yüzde ve özel değerler gibi farklı değer türlerini uygulamayı gösterir.

Ayrıca, ilgili veri noktası koleksiyonunu kullanarak bir serideki bireysel veri noktalarına özel hata çubuğu değerleri atamanın nasıl yapılacağını gösterir. Ek olarak, makalede hata çubuklarının dışa aktarım sırasında nasıl davrandığı, işaretçiler ve veri etiketiyle uyumluluğu ve ilgili API referans sınıfları ve enumların nerede bulunacağına dair kısa notlar bulunur.

## **Hata Çubukları Ekle**

Aspose.Slides for .NET, hata çubuğu değerlerini yönetmek için basit bir API sağlar. Örnek kod, özel bir değer türü kullanıldığında uygulanır. Bir değer belirtmek için, serinin **DataPoints** koleksiyonundaki belirli bir veri noktasının **ErrorBarCustomValues** özelliğini kullanın:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. İstenen slayta bir balon grafik ekleyin.
1. İlk grafik serisine erişin ve hata çubuğu X biçimini ayarlayın.
1. İlk grafik serisine erişin ve hata çubuğu Y biçimini ayarlayın.
1. Çubuk değerlerini ve biçimini ayarlama.
1. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

```c#
 // Boş sunum oluşturma
 using (Presentation presentation = new Presentation())
 {
     // Balon grafik oluşturma
     IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);
 
     // Hata çubuklarını ekleme ve biçimini ayarlama
     IErrorBarsFormat errBarX = chart.ChartData.Series[0].ErrorBarsXFormat;
     IErrorBarsFormat errBarY = chart.ChartData.Series[0].ErrorBarsYFormat;
     errBarX.IsVisible = true;
     errBarY.IsVisible = true;
     errBarX.ValueType = ErrorBarValueType.Fixed;
     errBarX.Value = 0.1f;
     errBarY.ValueType = ErrorBarValueType.Percentage;
     errBarY.Value = 5;
     errBarX.Type = ErrorBarType.Plus;
     errBarY.Format.Line.Width = 2;
     errBarX.HasEndCap = true;
 
     // Sunumu kaydetme
     presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
 }
```

## **Özel Hata Çubuğu Değerleri Ekle**

Aspose.Slides for .NET, özel hata çubuğu değerlerini yönetmek için basit bir API sağlar. Örnek kod, **IErrorBarsFormat.ValueType** özelliği **Custom** olduğunda uygulanır. Bir değer belirtmek için, serinin **DataPoints** koleksiyonundaki belirli bir veri noktasının **ErrorBarCustomValues** özelliğini kullanın:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. İstenen slayta bir balon grafik ekleyin.
1. İlk grafik serisine erişin ve hata çubuğu X biçimini ayarlayın.
1. İlk grafik serisine erişin ve hata çubuğu Y biçimini ayarlayın.
1. Grafik serisinin bireysel veri noktalarına erişin ve her bir seri veri noktası için Hata Çubuğu değerlerini ayarlayın.
1. Çubuk değerlerini ve biçimini ayarlama.
1. Değiştirilmiş sunumu bir PPTX dosyasına yazın.

```c#
 // Boş sunum oluşturma
 using (Presentation presentation = new Presentation())
 {
     // Balon grafik oluşturma
     IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);
 
     // Özel hata çubukları ekleme ve biçimini ayarlama
     IChartSeries series = chart.ChartData.Series[0];
     IErrorBarsFormat errBarX = series.ErrorBarsXFormat;
     IErrorBarsFormat errBarY = series.ErrorBarsYFormat;
     errBarX.IsVisible = true;
     errBarY.IsVisible = true;
     errBarX.ValueType = ErrorBarValueType.Custom;
     errBarY.ValueType = ErrorBarValueType.Custom;
 
     // Grafik serisi veri noktasına erişme ve bireysel nokta için hata çubuğu değerlerini ayarlama
     IChartDataPointCollection points = series.DataPoints;
     points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;
     points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;
     points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;
     points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;
 
     // Grafik serisi noktaları için hata çubuklarını ayarlama
     for (int i = 0; i < points.Count; i++)
     {
         points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 1;
         points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1;
         points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 1;
         points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 1;
     }
 
     // Sunumu kaydetme
     presentation.Save("ErrorBarsCustomValues_out.pptx", SaveFormat.Pptx);
 }
```

## **SSS**

**Sunum PDF veya görüntülere dışa aktarılırken hata çubukları ne olur?**

Grafiğin bir parçası olarak renderlanır ve uyumlu bir sürüm veya renderlayıcı varsayıldığında, dönüşüm sırasında grafik biçimlendirmesinin geri kalanıyla birlikte korunur.

**Hata çubukları işaretçiler ve veri etiketleri ile birleştirilebilir mi?**

Evet. Hata çubukları ayrı bir öğedir ve işaretçiler ve veri etiketleriyle uyumludur; öğeler çakışırsa biçimlendirmeyi ayarlamanız gerekebilir.

**API'de hata çubuklarıyla çalışmak için özellikler ve enumların listesini nerede bulabilirim?**

API referansında: [ErrorBarsFormat](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/errorbarsformat/) sınıfı ve ilgili enumlar [ErrorBarType](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/errorbartype/) ve [ErrorBarValueType](https://reference.aspose.com/slides/tr/net/aspose.slides.charts/errorbarvaluetype/).