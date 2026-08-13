---
title: Aspose.Slides for .NET 15.6.0'de Genel API ve Geriye Uyumsuz Değişiklikler
linktitle: Aspose.Slides for .NET 15.6.0
type: docs
weight: 170
url: /tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
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
description: "Aspose.Slides for .NET'te genel API güncellemelerini ve kırıcı değişiklikleri inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
{{% alert color="info" %}} 

Bu sayfa, Aspose.Slides for .NET 15.6.0 API'sı ile tanıtılan eklenen [eklenen](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) veya kaldırılan [kaldırılan](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) sınıfları, metodları, özellikleri vb. ve diğer değişiklikleri listeler.

{{% /alert %}} 
## **Genel API Değişiklikleri**
#### **DataLabel Yapıcı İmzası Değiştirildi**
DataLabel yapıcı imzası değiştirildi: önceki: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries); artık: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **Üyeler IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) Kullanımdan Kaldırıldı ve Yerine Değiştirmeleri Tanıtıldı.**
IDocumentProperties.Count özelliği ve IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name) metodları Kullanımdan Kaldırıldı. Yerine IDocumentProperties.CountOfCustomProperties özelliği ve IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name) metodları eklendi.
#### **INotesSlideManager.RemoveNotesSlide() Metodu Eklendi**
INotesSlideManager.RemoveNotesSlide() metodu, bir slaydın not slaydını kaldırmak için eklendi.
#### **IComment İçin Remove Metodu Eklendi**
IComment.Remove metodu, koleksiyondan yorumu kaldırmak için eklendi.
#### **ICommentAuthor İçin Remove Metodu Eklendi**
ICommentAuthor.Remove metodu, yorum yazarını koleksiyondan kaldırmak için eklendi.
#### **IDocumentProperties İçin ClearCustomProperties ve ClearBuiltInProperties Metodları Eklendi**
IDocumentProperties.ClearCustomProperties metodu, tüm özel belge özelliklerini kaldırmak için eklendi. IDocumentProperties.ClearBuiltInProperties metodu, tüm yerleşik belge özelliklerini (Company, Subject, Author vb.) kaldırmak ve varsayılan değerlere ayarlamak için eklendi.
#### **ICommentAuthorCollection İçin RemoveAt, Remove ve Clear Metodları Eklendi**
ICommentAuthorCollection.RemoveAt metodu, belirtilen indeks ile yazarı kaldırmak için eklendi. ICommentAuthorCollection.Remove metodu, belirtilen yazarı koleksiyondan kaldırmak için eklendi. ICommentAuthorCollection.Clear metodu, koleksiyondaki tüm öğeleri kaldırmak için eklendi.
#### **IDocumentProperties İçin AppVersion Özelliği Eklendi**
IDocumentProperties.AppVersion özelliği, Microsoft'un geliştirme sırasında kullandığı dahili sürüm numaralarını temsil eden yerleşik belge özelliğini almak için eklendi.
#### **IShape ve Shape İçin BlackWhiteMode Özelliği Eklendi**
BlackWhiteMode özelliği IShape ve Shape'e eklendi.

Bu özellik, bir şeklin siyah-beyaz görüntü modunda nasıl render edileceğini belirtir.

|**Değer** |**Anlam** |
| :- | :- |
|Color |Normal renkle render eder |
|Automatic |Otomatik renkle render eder |
|Gray |Gri renkle render eder |
|LightGray |Açık gri renkle render eder |
|InverseGray |Ters gri renkle render eder |
|GrayWhite |Gri ve beyaz renkle render eder |
|BlackGray |Siyah ve gri renkle render eder |
|BlackWhite |Siyah ve beyaz renkle render eder |
|Black |Sadece siyah renkle render eder |
|White |Beyaz renkle render eder |
|Hidden |Render etmez |
|NotDefined|özelliğin ayarlanmadığını gösterir |
#### **ISlide.NotesSlideManager Özelliği Eklendi. ISlide.NotesSlide ve ISlide.AddNotesSlide() Metodu Kullanımdan Kaldırıldı.**
ISlide.NotesSlide ve ISlide.AddNotesSlide() üyeleri Kullanımdan Kaldırıldı. Yeni ISlide.NotesSlideManager özelliğini kullanın.

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("sample.pptx"))
{
    ISlide slide = pres.Slides[0];

    INotesSlide notes;

    // notes = slide.AddNotesSlide(); - kullanımdan kaldırıldı
    // notes = slide.NotesSlide; - kullanımdan kaldırıldı

    notes = slide.NotesSlideManager.NotesSlide;
    notes = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```