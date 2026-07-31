---
title: Aspose.Slides for Java 15.6.0'de Genel API ve Geriye Uyumsuz Değişiklikler
linktitle: Aspose.Slides for Java 15.6.0
type: docs
weight: 140
url: /tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
aliases:
  - /java/aspose-slides-for-java-15-6-0-release-notes/
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
description: "Aspose.Slides for Java'da genel API güncellemelerini ve kırıcı değişiklikleri inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizin sorunsuz bir şekilde taşınmasını sağlayın."
---
{{% alert color="primary" %}} 

Bu sayfa, Aspose.Slides for Java 15.6.0 API'siyle tanıtılan tüm eklenen [eklenen](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) sınıfları, yöntemleri, özellikleri vb., yeni kısıtlamaları ve diğer [değişiklikler](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) listeler.

{{% /alert %}} 
## **Genel API değişiklikleri**
#### **com.aspose.slides.DataLabel yapıcı imzası değiştirildi**
Yapıcı imzası DataLabel(com.aspose.slides.IChartSeries) yerine DataLabel(com.aspose.slides.IChartDataPoint) olarak değiştirildi.
#### **Üyeler com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index)., .remove(String name), .contains(String name) Kullanım Dışı (Deprecated) olarak işaretlendi; yerine yeni yöntemler getirildi**
IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index)., .remove(string name), .contains(string name) yöntemleri Kullanım Dışı (Deprecated) olarak işaretlendi. Bunun yerine IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index)., .removeCustomProperty(String name), .containsCustomProperty(string name) yöntemleri getirildi.
#### **Metod com.aspose.slides.INotesSlideManager.removeNotesSlide() eklendi**
com.aspose.slides.INotesSlideManager.RemoveNotesSlide() metodu, bir slaytın not slaytını kaldırmak için eklendi.
#### **Metod com.aspose.slides.ISlide.getNotesSlideManager() eklendi. ISlide.getNotesSlide() ve ISlide.addNotesSlide() yöntemleri Kullanım Dışı (Deprecated) olarak işaretlendi**
ISlide.getNotesSlide() ve ISlide.addNotesSlide() yöntemleri Kullanım Dışı (Deprecated) olarak işaretlendi. Bunun yerine yeni ISlide.getNotesSlideManager() yöntemi kullanın.

``` java

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.addNotesSlide(); - kullanım dışı

// notes = slide.getNotesSlide(); - kullanım dışı

notes = slide.getNotesSlideManager().getNotesSlide();

notes = slide.getNotesSlideManager().addNotesSlide();

slide.getNotesSlideManager().removeNotesSlide();

```
#### **Metod getAppVersion() com.aspose.slides.IDocumentProperties'e eklendi**
com.aspose.slides.IDocumentProperties.getAppVersion() metodu, Microsoft PowerPoint tarafından kullanılan dahili sürüm numaralarını temsil eden yerleşik belge özelliğini almak için eklendi.
#### **Metod remove() com.aspose.slides.IComment'e eklendi**
com.aspose.slides.IComment.remove() metodu, koleksiyondan yorum kaldırmak için eklendi.
#### **Metod remove() com.aspose.slides.ICommentAuthor'e eklendi**
ICommentAuthor.Remove metodu, koleksiyondan yorum yazarını kaldırmak için eklendi.
#### **Metodlar clearCustomProperties() ve clearBuiltInProperties() com.aspose.slides.IDocumentProperties'e eklendi**
com.aspose.slides.IDocumentProperties.clearCustomProperties() metodu, tüm özel belge özelliklerini kaldırmak için eklendi.
com.aspose.slides.IDocumentProperties.clearBuiltInProperties() metodu, tüm yerleşik belge özelliklerini (Company, Subject, Author vb.) kaldırmak ve varsayılan değerlerini ayarlamak için eklendi.
#### **Metodlar getBlackWhiteMode() ve setBlackWhiteMode(byte) com.aspose.slides.IShape'e eklendi**
com.aspose.slides.IShape sınıfına getBlackWhiteMode() ve setBlackWhiteMode(byte) metodları eklendi.
Bu metodlar, bir şeklin siyah-beyaz görüntü modunda nasıl render edileceğini belirler. Olası değerler com.aspose.slides.BlackWhiteMode sınıfında tanımlanmıştır.

|**Değer** |**Anlam** |
| :- | :- |
|Color |Normal renklendirme ile döndür |
|Automatic |Otomatik renklendirme ile döndür |
|Gray |Gri renklendirme ile döndür |
|LightGray |Açık gri renklendirme ile döndür |
|InverseGray |Ters gri renklendirme ile döndür |
|GrayWhite |Gri ve beyaz renklendirme ile döndür |
|BlackGray |Siyah ve gri renklendirme ile döndür |
|BlackWhite |Siyah ve beyaz renklendirme ile döndür |
|Black |Sadece siyah renklendirme ile döndür |
|White |Beyaz renklendirme ile döndür |
|Hidden |Nesne render edilmez |
#### **Metodlar removeAt(int), remove(ICommentAuthor) ve clear() com.aspose.slides.ICommentAuthorCollection'e eklendi**
ICommentAuthorCollection.removeAt(int) metodu, belirtilen indeks ile yazarı kaldırmak için eklendi. ICommentAuthorCollection.remove(ICommentAuthor) metodu, koleksiyondan belirtilen yazarı kaldırmak için eklendi. ICommentAuthorCollection.clear() metodu, koleksiyondaki tüm öğeleri kaldırmak için eklendi.