---
title: Aspose.Slides for .NET 15.6.0'da Genel API ve Geriye Uyumsuz Değişiklikler
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
description: "Aspose.Slides for .NET'teki genel API güncellemelerini ve kırılma noktası değişikliklerini inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyabilirsiniz."
---
{{% alert color="primary" %}} 
Bu sayfa, Aspose.Slides for .NET 15.6.0 API'siyle tanıtılan eklenen [added](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) veya kaldırılan [removed](/slides/tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) sınıfları, yöntemleri, özellikleri vb. ve diğer değişiklikleri listeler.
{{% /alert %}} 
## **Public API Changes**
#### **DataLabel Constructor Signature Has Been Changed**
DataLabel yapıcı imzası değiştirildi:
eski: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
yeni: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **Members IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) Have Been Marked as Obsolete and Its Substitutions Have Been Introduced Instead.**
IDocumentProperties.Count özelliği ve IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name) yöntemleri kullanımdan kaldırıldı. Bunun yerine IDocumentProperties.CountOfCustomProperties özelliği ve IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name) yöntemleri eklendi.
#### **Method INotesSlideManager.RemoveNotesSlide() Has Been Added**
INotesSlideManager.RemoveNotesSlide() yöntemi eklendi.
INotesSlideManager.RemoveNotesSlide() yöntemi, bir slaytın not slaydını kaldırmak için eklendi.
#### **Method Remove Has Been Added to IComment**
IComment.Remove yöntemi, yorumun koleksiyondan kaldırılması için eklendi.
#### **Method Remove Has Been Added to ICommentAuthor**
ICommentAuthor.Remove yöntemi, yorum yazarının koleksiyondan kaldırılması için eklendi.
#### **Methods ClearCustomProperties and ClearBuiltInProperties Have Been Added to IDocumentProperties**
IDocumentProperties.ClearCustomProperties yöntemi, tüm özel belge özelliklerini kaldırmak için eklendi.
IDocumentProperties.ClearBuiltInProperties yöntemi, tüm yerleşik belge özelliklerini (Company, Subject, Author vb.) kaldırmak ve varsayılan değerlerine döndürmek için eklendi.
#### **Methods RemoveAt, Remove and Clear Have Been Added to ICommentAuthorCollection**
ICommentAuthorCollection.RemoveAt yöntemi, belirtilen indeksteki yazarın kaldırılması için eklendi.
ICommentAuthorCollection.Remove yöntemi, belirtilen yazarın koleksiyondan kaldırılması için eklendi.
ICommentAuthorCollection.Clear yöntemi, koleksiyondaki tüm öğelerin kaldırılması için eklendi.
#### **Property AppVersion Has Been Added to IDocumentProperties**
IDocumentProperties.AppVersion özelliği, Microsoft'un geliştirme sırasında kullandığı iç sürüm numaralarını temsil eden yerleşik belge özelliğini almak için eklendi.
#### **Property BlackWhiteMode Has Been Added to IShape and to Shape**
BlackWhiteMode özelliği IShape ve Shape nesnelerine eklendi.

Bu özellik, bir şeklin siyah‑beyaz görüntü modunda nasıl render edileceğini belirler.

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
|Hidden |Render edilmez |
|NotDefined|özelliğin ayarlanmadığını gösterir|
#### **Рroperty ISlide.NotesSlideManager Has Been Added. Property ISlide.NotesSlide and Method ISlide.AddNotesSlide() Have Been Marked as Obsolete.**
ISlide.NotesSlideManager özelliği eklendi. ISlide.NotesSlide özelliği ve ISlide.AddNotesSlide() yöntemi kullanımdan kaldırıldı.
ISlide.NotesSlide ve ISlide.AddNotesSlide() üyeleri kullanımdan kaldırıldı. Bunun yerine yeni ISlide.NotesSlideManager özelliği kullanılmalıdır.

``` csharp

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.AddNotesSlide(); - kullanımdan kaldırılmış

// notes = slide.NotesSlide; - kullanımdan kaldırılmış

notes = slide.NotesSlideManager.NotesSlide;

notes = slide.NotesSlideManager.AddNotesSlide();

slide.NotesSlideManager.RemoveNotesSlide();

```