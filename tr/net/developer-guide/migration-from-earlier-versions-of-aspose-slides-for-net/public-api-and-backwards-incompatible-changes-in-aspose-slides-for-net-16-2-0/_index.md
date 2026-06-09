---
title: Aspose.Slides for .NET 16.2.0'de Genel API ve Geriye Dönük Uyumsuz Değişiklikler
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
{{% alert color="primary" %}} 

Bu sayfa, Aspose.Slides for .NET 16.2.0 API'si ile tanıtılan [eklenmiş](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) veya [kaldırılmış](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) sınıfları, yöntemleri, özellikleri vb. ve diğer değişiklikleri listeler.

{{% /alert %}} 
## **Public API Değişiklikleri**
#### **UpdateDateTimeFields ve UpdateSlideNumberFields Özellikleri Kaldırıldı**
UpdateDateTimeFields ve UpdateSlideNumberFields özellikleri Aspose.Slides.Presentation sınıfından ve Aspose.Slides.IPresentation arayüzünden kaldırıldı.  
Aspose.Slides.TextFrame, Paragraph, Portion sınıflarının ve Aspose.Slides.ITextFrame, IParagraph, IPortion arayüzlerinin Text özelliği, güncellenmiş "datetime" alanlarıyla metin döndürür.  
Ayrıca Presentation.DocumentProperties.CreatedTime, LastSavedTime ve LastPrinted özellikleri yalnızca okunabilir hâle geldi.  

#### **Slides.Charts.CategoryAxisType Enum'ı Genel Hale Getirildi**
IAxis.CategoryAxisType ve Axis.CategoryAxisType özelliklerinde kategori eksen tipini belirlemek için kullanılır.  
CategoryAxisType.Auto - kategori eksen tipi serileştirme sırasında otomatik olarak belirlenecek (bu davranış şu anda uygulanmamaktadır)  
CategoryAxisType.Text - kategori eksen tipi Text  
CategoryAxisType.Date - kategori eksen tipi DateTime  

#### **Hızlı Metin Çıkarımı**
Presentation sınıfına yeni bir statik GetPresentationText yöntemi eklendi. Bu yöntem için iki aşırı yükleme bulunmaktadır:  

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

ExtractionMode enum argümanı, metin sonucunun çıktısını düzenleme modunu gösterir ve aşağıdaki değerlerden birine ayarlanabilir:  
Unarranged - slayt üzerindeki konuma bakılmadan ham metin  
Arranged - metin, slayttaki konumla aynı sırada yer alır  

Hızın kritik olduğu durumlarda Unarranged modu kullanılabilir; bu mod, Arranged modundan daha hızlıdır.  

PresentationText, sunumdan çıkarılan ham metni temsil eder. Aspose.Slides.Util ad alanındaki SlidesText özelliğini içerir ve bu özellik ISlideText nesnelerinden oluşan bir dizi döndürür. Her nesne, ilgili slayttaki metni temsil eder. ISlideText nesnesinin aşağıdaki özellikleri vardır:  
ISlideText.Text - slayt şekillerindeki metin  
ISlideText.MasterText - bu slayt için master sayfa şekillerindeki metin  
ISlideText.LayoutText - bu slayt için düzen sayfası şekillerindeki metin  
ISlideText.NotesText - bu slayt için not sayfası şekillerindeki metin  

Ayrıca ISlideText arayüzünü uygulayan bir SlideText sınıfı da vardır.  

Yeni API şu şekilde kullanılabilir:  

``` csharp

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged)

``` 

#### **ILegacyDiagram Arayüzü ve LegacyDiagram Sınıfı Eklendi**
Aspose.Slides.ILegacyDiagram arayüzü ve Aspose.Slides.LegacyDiagram sınıfı, eski diyagram nesnesini temsil etmek için eklendi. Legacy diagram nesnesi, PowerPoint 97-2003 formatındaki eski diyagramlardır.  
Yeni sınıf, legacy diyagramı modern düzenlenebilir SmartArt nesnesine veya düzenlenebilir GroupShape nesnesine dönüştürme yöntemleri sunar.  

#### **Yeni Aspose.Slides.TextAlignment Enum Üyesi Eklendi (JustifyLow)**
TextAlignment enum'una yeni bir üye eklendi:  
JustifyLow - Kashida düşük hizalama.  

#### **Aspose.Slides.IOleObjectFrame ve OleObjectFrame İçin Yeni Özellikler**
IOleObjectFrame arayüzüne ve bu arayüzü uygulayan OleObjectFrame sınıfına yeni özellikler eklendi. Bu özellikler, sunuma gömülmüş bir nesne hakkında bilgi sağlamak için kullanılır:  
EmbeddedFileExtension - mevcut gömülü nesnenin dosya uzantısını döndürür; nesne bir bağlantı değilse boş dize döner  
EmbeddedFileLabel - gömülü OLE nesnesinin dosya adını döndürür  
EmbeddedFileName - gömülü OLE nesnesinin yolunu döndürür  

#### **IAxis ve Axis Sınıflarına Yeni CategoryAxisType Özelliği Eklendi**
CategoryAxisType özelliği, kategori eksen tipini belirtir.  

``` csharp

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

#### **DataLabelFormat Sınıfına ve IDataLabelFormat Arayüzüne Yeni ShowLabelAsDataCallout Özelliği Eklendi**
ShowLabelAsDataCallout özelliği, belirtilen grafiğin veri etiketinin veri çağrısı olarak mı yoksa veri etiketi olarak mı gösterileceğini belirler.  

``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);

   chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

   chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

   chart.ChartData.Series[0].Labels[2].DataLabelFormat.ShowLabelAsDataCallout = false;

   pres.Save(pptxFileName, SaveFormat.Pptx);

}

``` 

#### **PdfOptions ve XpsOptions'a DrawSlidesFrame Özelliği Eklendi**
Boolean DrawSlidesFrame özelliği, Aspose.Slides.Export.IPdfOptions ve Aspose.Slides.Export.IXpsOptions arayüzlerine ve ilgili Aspose.Slides.Export.PdfOptions, Aspose.Slides.Export.XpsOptions sınıflarına eklendi.  
Bu özellik 'true' olarak ayarlandığında, her slaytın etrafında siyah bir çerçeve çizilecektir.  

``` csharp

 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}

```