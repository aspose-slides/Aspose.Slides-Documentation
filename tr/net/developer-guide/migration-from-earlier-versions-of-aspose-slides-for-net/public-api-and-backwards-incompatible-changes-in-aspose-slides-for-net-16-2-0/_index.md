---
title: Aspose.Slides for .NET 16.2.0'deki Genel API ve Geriye Uyumsuz Değişiklikler
linktitle: Aspose.Slides for .NET 16.2.0
type: docs
weight: 230
url: /tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
keywords:
- göç
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
description: "Aspose.Slides for .NET'teki genel API güncellemelerini ve kırıcı değişiklikleri inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
{{% alert color="info" %}} 

Bu sayfa, Aspose.Slides for .NET 16.2.0 API'si ile tanıtılan [added](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) veya [removed](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) sınıfları, yöntemleri, özellikleri vb. ve diğer değişiklikleri listeler.

{{% /alert %}} 
## **Public API Changes**
#### **Properties UpdateDateTimeFields and UpdateSlideNumberFields Have Been Removed**
UpdateDateTimeFields ve UpdateSlideNumberFields özellikleri Aspose.Slides.Presentation sınıfı ve Aspose.Slides.IPresentation arayüzünden kaldırıldı.
Aspose.Slides.TextFrame, Paragraph, Portion sınıfları ile Aspose.Slides.ITextFrame, IParagraph, IPortion arayüzlerinin Text özelliği, güncellenmiş "datetime" alanlarıyla metin döndürür.
Ayrıca Presentation.DocumentProperties.CreatedTime, LastSavedTime ve LastPrinted özellikleri yalnızca okunabilir hâle geldi.
#### **Enum Slides.Charts.CategoryAxisType Has Been Switched to Public**
IAxis.CategoryAxisType ve Axis.CategoryAxisType özelliklerinde kategori eksen tipini belirlemek için kullanılır.
CategoryAxisType.Auto - kategori eksen tipi serileştirme sırasında otomatik olarak belirlenir (bu davranış şu anda uygulanmamıştır)
CategoryAxisType.Text - kategori eksen tipi Text'tir
CategoryAxisType.Date - kategori eksen tipi DateTime'dır
#### **Fast Text Extraction**
Yeni statik GetPresentationText yöntemi Presentation sınıfına eklendi. Bu yöntem için iki aşırı yükleme vardır:

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

ExtractionMode enum argümanı, metin sonucunun çıktısını düzenleme modunu gösterir ve aşağıdaki değerlerden birine ayarlanabilir:
Unarranged - slayt üzerindeki konuma bakılmaksızın ham metin
Arranged - metin slayt üzerindeki sırayla konumlandırılır

Hızın kritik olduğu durumlarda Unarranged modu kullanılabilir, bu mod Arranged modundan daha hızlıdır.

PresentationText, sunumdan çıkarılan ham metni temsil eder. Aspose.Slides.Util ad alanındaki SlidesText özelliğini içerir ve bu özellik ISlideText nesnelerinden oluşan bir dizi döndürür. Her nesne ilgili slayttaki metni temsil eder. ISlideText nesnesinin aşağıdaki özellikleri vardır:

ISlideText.Text - slayt şekillerindeki metin
ISlideText.MasterText - bu slayt için ana sayfa (master) şekillerindeki metin
ISlideText.LayoutText - bu slayt için düzen (layout) sayfası şekillerindeki metin
ISlideText.NotesText - bu slayt için not sayfası şekillerindeki metin

Ayrıca ISlideText arayüzünü uygulayan bir SlideText sınıfı da vardır.

Yeni API şu şekilde kullanılabilir:

``` csharp
using System;
using Aspose.Slides;

// Metni slayttaki konumuna bakılmaksızın çıkar (en hızlı mod).
IPresentationText text1 = PresentationFactory.Instance.GetPresentationText(
    "presentation.ppt", TextExtractionArrangingMode.Unarranged);

Console.WriteLine(text1.SlidesText[0].Text);
Console.WriteLine(text1.SlidesText[0].LayoutText);
Console.WriteLine(text1.SlidesText[0].MasterText);
Console.WriteLine(text1.SlidesText[0].NotesText);

// Metni slayttaki aynı sırada konumlandırarak çıkar.
IPresentationText text2 = PresentationFactory.Instance.GetPresentationText(
    "presentation.pptx", TextExtractionArrangingMode.Arranged);

Console.WriteLine(text2.SlidesText[0].Text);
``` 
#### **ILegacyDiagram Interface and LegacyDiagram Class Have Been Added**
Aspose.Slides.ILegacyDiagram arayüzü ve Aspose.Slides.LegacyDiagram sınıfı, legacy diagram nesnesini temsil etmek için eklendi. Legacy diagram nesnesi, PowerPoint 97-2003'ten gelen eski bir diyagram formatıdır.
Yeni sınıf, legacy diagramı modern düzenlenebilir SmartArt nesnesine veya düzenlenebilir GroupShape nesnesine dönüştürme yöntemleri sağlar.
#### **New Aspose.Slides.TextAlignment Enum Member Added (JustifyLow)**
TextAlignment enum'una yeni bir üye eklendi:
JustifyLow - Kashida düşük hizalama.
#### **New Properties for Aspose.Slides.IOleObjectFrame and OleObjectFrame**
IOleObjectFrame arayüzüne ve bu arayüzü uygulayan OleObjectFrame sınıfına yeni özellikler eklendi. Bu özellikler, sunuma gömülmüş bir nesne hakkında bilgi sağlamak için kullanılır:
EmbeddedFileExtension - mevcut gömülü nesnenin dosya uzantısını döndürür; nesne bir bağlantı değilse boş string döner
EmbeddedFileLabel - gömülü OLE nesnesinin dosya adını döndürür
EmbeddedFileName - gömülü OLE nesnesinin yolunu döndürür
#### **New Property CategoryAxisType Has Been Added to IAxis and Axis Classes**
CategoryAxisType özelliği, kategori ekseninin tipini belirtir.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

string sourcePptxFileName = "chart.pptx";
string pptxOutPath = "chart_out.pptx";

using (Presentation pres = new Presentation(sourcePptxFileName))
{
    IChart chart = pres.Slides[0].Shapes[0] as IChart;

    chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
    chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.HorizontalAxis.MajorUnit = 1;
    chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;

    pres.Save(pptxOutPath, SaveFormat.Pptx);
}
``` 
#### **New Property ShowLabelAsDataCallout Has Been Added to DataLabelFormat Class and IDataLabelFormat Interface**
ShowLabelAsDataCallout özelliği, belirtilen grafiğin veri etiketinin veri çağrısı (callout) olarak mı yoksa veri etiketi olarak mı gösterileceğini belirler.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

string pptxFileName = "callout_labels.pptx";

using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);

    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;
    chart.ChartData.Series[0].Labels[2].DataLabelFormat.ShowLabelAsDataCallout = false;

    pres.Save(pptxFileName, SaveFormat.Pptx);
}
``` 
#### **Property DrawSlidesFrame Has Been Added to PdfOptions and XpsOptions**
Boolean DrawSlidesFrame özelliği, Aspose.Slides.Export.IPdfOptions, Aspose.Slides.Export.IXpsOptions arayüzlerine ve ilgili Aspose.Slides.Export.PdfOptions, Aspose.Slides.Export.XpsOptions sınıflarına eklendi. Bu özellik 'true' olarak ayarlanırsa her slaytın etrafına siyah bir çerçeve çizilir.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;


 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}
```