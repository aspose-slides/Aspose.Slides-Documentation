---
title: PPTX'te Grafik Yeniden Boyutlandırma İçin Çözüm
type: docs
weight: 60
url: /tr/net/working-solution-for-chart-resizing-in-pptx/
keywords:
- grafik yeniden boyutlandırma
- Excel grafiği
- OLE nesnesi
- grafik gömme
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile gömülü Excel OLE nesneleri kullanırken PPTX'te beklenmeyen grafik yeniden boyutlandırmayı düzeltin. Grafik ve OLE çerçeve boyutlarının tutarlı kalması için sabit grafik boyutları ayarlayın."
---
## **Arka Plan**

Aspose bileşenlerini kullanarak PowerPoint sunumlarına OLE nesnesi olarak gömülen Excel grafikler, ilk etkinleştirmelerinden sonra boyutlarını değiştirebilir. Bu, grafiğin etkinleştirmeden önce ve sonra görünümünde fark edilebilir bir değişikliğe neden olabilir. Bu makale, yeniden boyutlandırmanın neden gerçekleştiğini açıklar ve sabit grafik boyutlarını OLE çerçevesiyle eşleştirerek nasıl önlenebileceğini gösterir.

In [Excel Grafiklerini Oluşturun ve Sunumlarda OLE Nesneleri Olarak Gömün](/slides/tr/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), we explained how to create an Excel chart with Aspose.Cells for .NET and embed it in a PowerPoint presentation using Aspose.Slides for .NET. To address the [nesne önizleme sorunu](/slides/tr/net/object-preview-issue-when-adding-oleobjectframe/), we assigned the chart image to the chart’s OLE object frame. In the output presentation, when you double-click the OLE object frame displaying the chart image, the Excel chart is activated. Users can edit the embedded Excel workbook and then return to the slide by clicking outside the activated workbook. The size of the OLE object frame changes when the user returns to the slide, and the resizing factor varies depending on the original sizes of both the OLE object frame and the embedded Excel workbook.

## **Yeniden Boyutlandırmanın Nedeni**

Gömülü Excel çalışma kitabının kendi pencere boyutları vardır ve Excel nesne ilk etkinleştirildiğinde bunları korumaya çalışır. Slayttaki OLE çerçevesinin ise bağımsız tanımlanmış boyutları vardır. Excel çalışma kitabı etkinleştirildiğinde, Excel ve PowerPoint nesnenin boyutunu gömme işleminin bir parçası olarak oranlarını koruyacak şekilde müzakere eder. Çalışma kitabı penceresi ile OLE çerçevesi arasındaki farklılıklar bu nedenle nesnenin yeniden boyutlandırılmasına neden olabilir.

## **Çözüm**

Grafik boyutunu slayttaki OLE çerçevesiyle eşleştirin ve grafik boyutlarını çalışma kitabı penceresinden bağımsız tutun. Bu çözüm yeni bir sunumla veya mevcut bir şablonla çalışır.

Örnek, Aspose.Cells for .NET ve Aspose.Slides for .NET gerektirir. Aktif bir grafik sayfasında basit bir sütun grafik oluşturur ve çalışma kitabını XLS formatında gömer. Grafik önizleme görüntüsü atanmaz; grafik, OLE nesnesi PowerPoint'te etkinleştirildiğinde görünür hâle gelir.

Örnek, sol kenardan 0.5 inç ve üstten 1 inç olarak konumlandırılmış 9.5 × 4 inçlik bir OLE çerçevesiyle yeni bir sunum oluşturur. Slayt koordinatları ve boyutları nokta birimindedir (inç başına 72 nokta). Mevcut bir sunum için, [Şablon Kullan](#use-a-template) bölümüne bakın.

## **Sabit Bir Grafik Boyutu Ayarla**

Grafik boyutlarının çalışma kitabı penceresinden bağımsız olması için [SizeWithWindow](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/sizewithwindow/) değerini false olarak ayarlayın. [ChartObject](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/chartobject/) boyutlarını [Width](https://reference.aspose.com/cells/net/aspose.cells.drawing/shape/width/) ve [Height](https://reference.aspose.com/cells/net/aspose.cells.drawing/shape/height/) aracılığıyla ayarlayın; noktaları inç başına 96 piksel kullanarak piksellere dönüştürün: 684 × 288 nokta ölçen bir çerçeve, 912 × 384 piksel ölçen bir grafikle eşdeğerdir. [PrintSize](https://reference.aspose.com/cells/net/aspose.cells.charts/chart/printsize/) değerini [PrintSizeType](https://reference.aspose.com/cells/net/aspose.cells/printsizetype/) öğesinin Custom değeri olarak ayarlayın. Örnek, çalışma kitabını [AddOleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addoleobjectframe/) ile gömer ve 9.5 × 4 inçlik bir OLE çerçeveyle bir sunumu kaydeder.

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.DOM.Ole;

using var workbook = new Aspose.Cells.Workbook();
var dataSheet = workbook.Worksheets[0];
dataSheet.Name = "Data";
dataSheet.Cells["A1"].PutValue(10);
dataSheet.Cells["A2"].PutValue(20);

var chartSheetIndex = workbook.Worksheets.Add(Aspose.Cells.SheetType.Chart);
var chartSheet = workbook.Worksheets[chartSheetIndex];
var chartIndex = chartSheet.Charts.Add(Aspose.Cells.Charts.ChartType.Column, 0, 0, 20, 10);
var chart = chartSheet.Charts[chartIndex];
chart.NSeries.Add("Data!A1:A2", true);
workbook.Worksheets.ActiveSheetIndex = chartSheetIndex;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// Slayt koordinatları ve boyutları nokta birimindedir (inç başına 72 nokta).
var width = 684f; // 9.5 inç.
var height = 288f; // 4 inç.

chart.SizeWithWindow = false;
// Nokta birimini, inç başına 96 piksel kullanarak grafik piksellerine dönüştür.
chart.ChartObject.Width = (int)(width / 72f * 96f);
chart.ChartObject.Height = (int)(height / 72f * 96f);
chart.PrintSize = Aspose.Cells.PrintSizeType.Custom;

using var workbookStream = new MemoryStream();
workbook.Save(workbookStream, Aspose.Cells.SaveFormat.Excel97To2003);
var dataInfo = new OleEmbeddedDataInfo(workbookStream.ToArray(), "xls");
slide.Shapes.AddOleObjectFrame(36, 72, width, height, dataInfo);

presentation.Save("chart-fixed-size.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Şablon Kullan**

The sizing logic is the same for an existing presentation. To adapt the example:

1. Boş bir sunum oluşturmak yerine şablon sunumu yükleyin.
1. İlk slaytın en az üç şekil içerdiğini doğrulayın ve ardından 2. indeksteki şekli yer tutucu olarak kullanın.
1. Çerçevenin genişlik ve yüksekliğini, sabit değerler 684 ve 288 yerine bu şekilden alın. Boyutlandırma hesaplamalarını değiştirmeyin.
1. Sabit koordinatlar 36 ve 72 yerine yer tutucunun konumunda OLE çerçevesi ekleyin.
1. Sunumu kaydetmeden önce yer tutucuyu kaldırın.

## **SSS**

**Gömülü Excel grafiğim PowerPoint'te etkinleştirildikten sonra neden boyut değiştiriyor?**

Bu, Excel'in ilk etkinleştirildiğinde orijinal pencere boyutunu geri yüklemeye çalışması, PowerPoint'teki OLE nesne çerçevesinin ise kendi boyutlarına sahip olması nedeniyle olur. PowerPoint ve Excel, en boy oranını korumak için boyutu müzakere eder; bu da yeniden boyutlandırmaya yol açabilir.

**Grafik ve OLE çerçevesi boyutlarını tutarlı nasıl tutabilirim?**

OLE çerçevesiyle eşleşen sabit grafik boyutları ayarlayın ve çalışma kitabını gömmeden önce özel bir grafik baskı boyutu kullanın. Yukarıdaki örnek gerekli ayarları ve birim dönüşümlerini gösterir.

**Çalışma kitabı pencere boyutunu eşleştirmek yeterli mi?**

Sadece çalışma kitabı pencere boyutunu eşleştirmek, OLE çerçevesinin etkinleştirildikten sonra boyutunun değişmesini güvenilir şekilde engellemez. Örnekte gösterildiği gibi sabit grafik boyutları kullanın.

**Bu çözüm şablon tabanlı sunumlar ve yeni sunumlar için çalışıyor mu?**

Evet. Bir şablon için, yer tutucunun boyutlarını ve konumunu kullanın. Yeni bir sunum için ise çerçeve boyutlarını ve konumunu doğrudan belirtin.

**Bu örneği diğer hesap tabloları programlarında oluşturulan grafiklerle kullanabilir miyim?**

Örnek, Aspose.Cells ile oluşturulan bir Excel çalışma kitabını kullanır. Diğer hesap tablo programları için etkinleştirme davranışını göstermez.

## **İlgili Bölümler**

- [Excel Grafiklerini Oluşturun ve Sunumlarda OLE Nesneleri Olarak Gömün](/slides/tr/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [PowerPoint Eklentisi Kullanarak OLE Nesnelerini Otomatik Güncelle](/slides/tr/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)