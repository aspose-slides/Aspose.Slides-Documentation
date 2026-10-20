---
title: Excel Grafiklerini Oluşturun ve Sunumlarda OLE Nesneleri Olarak Gömün
type: docs
weight: 50
url: /tr/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel grafiği
- grafik gömme
- OLE nesnesi
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Cells for .NET ile bir Excel grafiği oluşturun ve Aspose.Slides ile bir PowerPoint sunumuna çalışma kitabını gömün, grafik ön izlemesi dahil."
---
## **Genel Bakış**

Bu makale, Aspose.Cells for .NET ile bir Excel sütun grafiği oluşturmayı ve bu çalışma kitabını Aspose.Slides for .NET ile bir PowerPoint sunumuna yerleştirmeyi gösterir. Gömülü çalışma kitabı hem kaynak verileri hem de grafiği içerir. Ayrı bir PNG ön izleme, OLE nesnesi etkinleştirilmeden önce slaytta grafiği gösterir.

Sonuç bir yerleştirilmiş Excel nesnesi olur, yerel bir PowerPoint grafiği değil. OLE aracılığıyla çalışma kitabını düzenlemek, OLE etkinleştirmesini destekleyen bir masaüstü uygulaması ve uyumlu bir Excel kurulumunu gerektirir.

## **Ön Koşullar**

C# projenize Aspose.Cells for .NET ve Aspose.Slides for .NET referanslarını ekleyin. Örnek, üst düzey ifadeler kullanır ve C# 9 veya daha yeni bir sürüm gerektirir. Bu kütüphanelerle sunumu oluşturmak için Microsoft Office gerekli değildir.

Hiçbir girdi dosyasına ihtiyaç yoktur: örnek, veriyi ve grafiği bellek içinde oluşturur, ardından `OutputChart.pptx` dosyasını geçerli çalışma dizinine yazar. Değerlendirme modunun dışındayken her iki ürün için de lisansları uygulayın.

## **Yerleştirmenin Nasıl Çalıştığı**

1. Veri çalışma sayfası ve grafik sayfası içeren bir çalışma kitabı oluşturun.  
2. Grafik sayfasını aktif hale getirerek çalışma kitabının grafikte açılmasını sağlayın.  
3. Çalışma kitabının OLE görüntüleme aralığını ayarlayın ve grafiği PNG olarak render edin.  
4. Çalışma kitabını bellek içinde XLSX olarak kaydedin ve bu baytları bir slayta yerleştirin.  
5. PNG'yi OLE nesnesinin ön izlemesi olarak atayın ve sunumu PPTX olarak kaydedin.

Çalışma kitabı görüntüleme aralığı ile slayttaki çerçeve farklı görevler üstlenir. [SetOleSize](https://reference.aspose.com/cells/net/aspose.cells/worksheetcollection/setolesize/) sıfır tabanlı başlangıç/bitiriş satır ve sütun indekslerini alır. [ChartCollection.Add](https://reference.aspose.com/cells/net/aspose.cells.charts/chartcollection/add/) ise üst satır, sol sütun, alt satır ve sağ sütunu alır. Örnek, alt sağ sınırlar olarak satır indeksi 55 ve sütun indeksi 25 kullanır; bu değerler düzen tercihidir, veri satırları veya sütun sayısı değildir.

Slayt çerçevesi puan (point) birimini kullanır. Örnek, çerçeveyi slayt içinde sığdırır ve PNG'nin en‑boy oranını koruyarak ortalar; ön izlemeyi slaytı dolduracak şekilde uzatmaz.

## **Grafiği Oluşturma ve Yerleştirme**

Aşağıdaki tam örnek, `DataSheet`'i dört satır ve beş sütun değerle doldurur. Her satır bir grafik serisi olur. Çalışma kitabı kaydedilmeden önce `ChartSheet` aktif sayfa olarak seçilir.

Çalışma kitabı, [OleEmbeddedDataInfo](https://reference.aspose.com/slides/net/aspose.slides.dom.ole/oleembeddeddatainfo/)’ye geçirilen `xlsx` uzantısı ile eşleşecek şekilde açıkça XLSX olarak kaydedilir. PNG, ara bir bitmap dönüşümü olmadan doğrudan akışından yüklenir. [SubstitutePictureFormat](https://reference.aspose.com/slides/net/aspose.slides/ioleobjectframe/substitutepictureformat/) aracılığıyla atama, varsayılan OLE yer tutucusunu değiştirir.

```cs
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var workbook = new Aspose.Cells.Workbook();
var dataSheet = workbook.Worksheets[0];
dataSheet.Name = "DataSheet";

int[,] values =
{
    { 67, 44, 46, 43, 24 },
    { 86, 64, 97, 29, 40 },
    { 68, 89, 78, 69, 38 },
    { 91, 48, 60, 26, 25 }
};

for (var row = 0; row < values.GetLength(0); row++)
{
    for (var column = 0; column < values.GetLength(1); column++)
    {
        dataSheet.Cells[row, column].PutValue(values[row, column]);
    }
}

var chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
var chartSheet = workbook.Worksheets[chartSheetIndex];
chartSheet.Name = "ChartSheet";

var lastChartRow = 55;
var lastChartColumn = 25;
var chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 0, lastChartRow, lastChartColumn);
var chart = chartSheet.Charts[chartIndex];
for (var row = 1; row <= values.GetLength(0); row++)
{
    chart.NSeries.Add($"DataSheet!A{row}:E{row}", false);
}

workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;
workbook.Worksheets.SetOleSize(0, lastChartRow, 0, lastChartColumn);

// Grafik ön izlemesini oluştur ve düzenlenebilir çalışma kitabını ayrı olarak seri hale getir.
using var chartImageStream = new MemoryStream();
chart.ToImage(chartImageStream, Aspose.Cells.Drawing.ImageType.Png);
chartImageStream.Position = 0;
using var chartImage = Images.FromStream(chartImageStream);

using var workbookStream = new MemoryStream();
workbook.Save(workbookStream, Aspose.Cells.SaveFormat.Xlsx);
var workbookBytes = workbookStream.ToArray();

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var slideSize = presentation.SlideSize.Size;

// Fit the preview within the slide without changing its aspect ratio.
var scale = Math.Min(slideSize.Width / chartImage.Width, slideSize.Height / chartImage.Height);
var frameWidth = chartImage.Width * scale;
var frameHeight = chartImage.Height * scale;
var frameX = (slideSize.Width - frameWidth) / 2;
var frameY = (slideSize.Height - frameHeight) / 2;

var embeddedData = new OleEmbeddedDataInfo(workbookBytes, "xlsx");
var oleFrame = slide.Shapes.AddOleObjectFrame(frameX, frameY, frameWidth, frameHeight, embeddedData);
var previewImage = presentation.Images.AddImage(chartImage);
oleFrame.SubstitutePictureFormat.Picture.Image = previewImage;

presentation.Save("OutputChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Beklenen Sonuç**

`OutputChart.pptx`, yerleştirilmiş bir Excel çalışma kitabı ve bir grafik ön izlemesi içeren bir slayt barındırır. Çalışma kitabı orijinal veriyi ve dört serili bir sütun grafiğini içerir. Ön izleme slaytın ortasında yer alır ve oranlarını korur.

![Excel sütun grafiği, yerleştirilmiş bir çalışma kitabının ön izlemesi olarak gösterilir](excel-chart-ole-preview.png)

Excel'in mevcut olduğu uyumlu bir masaüstü PowerPoint ortamında, nesneyi çift tıklayarak yerleştirilmiş çalışma kitabını etkinleştirebilir ve düzenleyebilirsiniz. Aktivasyon ve düzenleme, ana uygulamanın OLE desteği ve güvenlik ayarlarına bağlıdır.

## **SSS**

**Neden bir ön izleme görüntüsü gerekir?**

Gömülü çalışma kitabı ve slayt ön izlemesi ayrı içeriklerdir. Slaytın varsayılan "EMBEDDED OLE OBJECT" yer tutucusu yerine grafiği göstermesi için bir grafik resmi sağlayın. Bakınız [OleObjectFrame Eklerken Nesne Ön İzleme Sorunu](/slides/tr/net/object-preview-issue-when-adding-oleobjectframe/).

**Kodda çalışma kitabını değiştirdiğimde ön izleme otomatik olarak güncellenir mi?**

Ön izlemeyi bir anlık görüntü olarak düşünün. Çalışma kitabı verileri programlı olarak güncellendiğinde, grafik resmini yeniden oluşturun ve ön izlemeyi ve yerleştirilmiş çalışma kitabı verilerini değiştirin.

**XLSX yerine XLS kullanabilir miyim?**

Evet. Çalışma kitabını XLS formatında kaydedin ve yerleştirilmiş veri uzantısı olarak `xls` kullanın. Uzantı, gerçek çalışma kitabı formatıyla eşleşmelidir; sadece uzantıyı değiştirmek veriyi dönüştürmez.

**Aktivasyondan sonra nesne neden boyut değiştirir?**

Ana uygulama, çalışma kitabını etkinleştirdiğinde OLE nesnesinin sunumunu güncelleyebilir. Çalışma kitabının OLE görüntüleme aralığı ve slayt çerçevesi boyutları her ikisi de önemlidir. Bakınız [PPTX'te Grafik Yeniden Boyutlandırma için Çözüm](/slides/tr/net/working-solution-for-chart-resizing-in-pptx/).

## **İlgili Bölümler**

- [PPTX'te Grafik Yeniden Boyutlandırma için Çözüm](/slides/tr/net/working-solution-for-chart-resizing-in-pptx/)
- [OleObjectFrame Eklerken Nesne Ön İzleme Sorunu](/slides/tr/net/object-preview-issue-when-adding-oleobjectframe/)
- [PowerPoint Eklentisi Kullanarak OLE Nesnelerini Otomatik Güncelleme](/slides/tr/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)