---
title: Aspose.Slides for Java 15.6.0'da Genel API ve Geriye Uyumsuz Değişiklikler
linktitle: Aspose.Slides for Java 15.6.0
type: docs
weight: 140
url: /tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
keywords:
- göç
- eski kod
- modern kod
- eski yaklaşım
- modern yaklaşım
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'daki genel API güncellemelerini ve kırılma değişikliklerini inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
{{% alert color="primary" %}} 

Bu sayfa, Aspose.Slides for Java 15.6.0 API'si ile tanıtılan yeni eklenen sınıfları, metotları, özellikleri vb., yeni kısıtlamaları ve diğer [değişiklikleri](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) listeler.

{{% /alert %}} 
## **Public API changes**
#### **com.aspose.slides.DataLabel yapıcı imzası değiştirildi**
Yapıcı imzası DataLabel(com.aspose.slides.IChartSeries) yerine DataLabel(com.aspose.slides.IChartDataPoint) olarak değiştirildi.
#### **Members com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index)., .remove(String name), .contains(String name) have been marked as Deprecated; substitutions have been introduced instead**
Üyeler com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index), .remove(String name), .contains(String name) Kullanımdan Kaldırıldı olarak işaretlendi; yerine yeni alternatifler getirildi.
#### **Method com.aspose.slides.INotesSlideManager.removeNotesSlide() has been added**
com.aspose.slides.INotesSlideManager.removeNotesSlide() metodu eklendi. Bu metod, bir slaydın not slaytını kaldırmak için eklenmiştir.
#### **Method com.aspose.slides.ISlide.getNotesSlideManager() has been added. Methods ISlide.getNotesSlide() and ISlide.addNotesSlide() have been marked as Deprecated**
com.aspose.slides.ISlide.getNotesSlideManager() metodu eklendi. ISlide.getNotesSlide() ve ISlide.addNotesSlide() metodları Kullanımdan Kaldırıldı olarak işaretlendi. Bunun yerine yeni ISlide.getNotesSlideManager() metodunu kullanın.

``` java

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.addNotesSlide(); - kullanımdan kaldırıldı

// notes = slide.getNotesSlide(); - kullanımdan kaldırıldı

notes = slide.getNotesSlideManager().getNotesSlide();

notes = slide.getNotesSlideManager().addNotesSlide();

slide.getNotesSlideManager().removeNotesSlide();

```
#### **Method getAppVersion() has been added to com.aspose.slides.IDocumentProperties**
com.aspose.slides.IDocumentProperties sınıfına getAppVersion() metodu eklendi. Bu metod, Microsoft PowerPoint tarafından kullanılan iç sürüm numaralarını temsil eden yerleşik belge özelliğini almak için eklenmiştir.
#### **Method remove() has been added to com.aspose.slides.IComment**
com.aspose.slides.IComment sınıfına remove() metodu eklendi. Bu metod, yorumları koleksiyondan kaldırmak için eklenmiştir.
#### **Method remove() has been added to com.aspose.slides.ICommentAuthor**
com.aspose.slides.ICommentAuthor sınıfına remove() metodu eklendi. Bu metod, yorum yazarlarını koleksiyondan kaldırmak için eklenmiştir.
#### **Methods clearCustomProperties() and clearBuiltInProperties() have been added to com.aspose.slides.IDocumentProperties**
com.aspose.slides.IDocumentProperties sınıfına clearCustomProperties() ve clearBuiltInProperties() metodları eklendi. clearCustomProperties() metodu, tüm özel belge özelliklerini kaldırmak için eklendi. clearBuiltInProperties() metodu, tüm yerleşik belge özelliklerini (Şirket, Konu, Yazar vb.) kaldırmak ve varsayılan değerlerine sıfırlamak için eklendi.
#### **Methods getBlackWhiteMode(), setBlackWhiteMode(byte) have been added to com.aspose.slides.IShape**
com.aspose.slides.IShape sınıfına getBlackWhiteMode() ve setBlackWhiteMode(byte) metodları eklendi. Bu metodlar, bir şeklin siyah‑beyaz görüntü modunda nasıl render edileceğini belirler. Olası değerler com.aspose.slides.BlackWhiteMode sınıfında tanımlanmıştır.

|**Değer** |**Anlam** |
| :- | :- |
|Color |Normal renkle döndürür |
|Automatic |Otomatik renkle döndürür |
|Gray |Gri renkle döndürür |
|LightGray |Açık gri renkle döndürür |
|InverseGray |Ters gri renkle döndürür |
|GrayWhite |Gri ve beyaz renkle döndürür |
|BlackGray |Siyah ve gri renkle döndürür |
|BlackWhite |Siyah ve beyaz renkle döndürür |
|Black |Sadece siyah renkle döndürür |
|White |Beyaz renkle döndürür |
|Hidden |Nesne render edilmez |
#### **Methods removeAt(int), remove(ICommentAuthor) and clear() have been added to com.aspose.slides.ICommentAuthorCollection**
com.aspose.slides.ICommentAuthorCollection sınıfına removeAt(int), remove(ICommentAuthor) ve clear() metodları eklendi. ICommentAuthorCollection.removeAt(int) metodu, belirtilen indeksdeki yazarı kaldırmak için eklendi. ICommentAuthorCollection.remove(ICommentAuthor) metodu, belirtilen yazarı koleksiyondan kaldırmak için eklendi. ICommentAuthorCollection.clear() metodu, koleksiyondaki tüm öğeleri kaldırmak için eklendi.