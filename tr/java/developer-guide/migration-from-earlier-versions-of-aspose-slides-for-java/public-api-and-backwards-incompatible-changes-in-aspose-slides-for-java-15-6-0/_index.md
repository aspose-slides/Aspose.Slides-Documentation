---
title: Aspose.Slides for Java 15.6.0'da Genel API ve Geriye Uyumsuz Değişiklikler
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
description: "Aspose.Slides for Java'daki genel API güncellemelerini ve kırıcı değişiklikleri inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
{{% alert color="info" %}} 

Bu sayfa, Aspose.Slides for Java 15.6.0 API'sı ile tanıtılan tüm [eklenen](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) sınıfları, yöntemleri, özellikleri vb., yeni kısıtlamaları ve diğer [değişiklikleri](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) listeler.

{{% /alert %}} 
## **Public API değişiklikleri**
#### **com.aspose.slides.DataLabel yapıcı imzası değiştirildi**
İmza, DataLabel(com.aspose.slides.IChartSeries) yerine DataLabel(com.aspose.slides.IChartDataPoint) olarak değiştirildi.
#### **Üyeler com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index)., .remove(String name), .contains(String name) Kullanımdan kaldırıldı; bunun yerine yeni yöntemler tanıtıldı**
Metotlar IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index)., .remove(string name), .contains(string name) Kullanımdan kaldırıldı. Bunun yerine IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index)., .removeCustomProperty(String name), .containsCustomProperty(string name) tanıtıldı.
#### **Metot com.aspose.slides.INotesSlideManager.removeNotesSlide() eklendi**
Metot com.aspose.slides.INotesSlideManager.RemoveNotesSlide() bazı slaytların not slaytını kaldırmak için eklendi.
#### **Metot com.aspose.slides.ISlide.getNotesSlideManager() eklendi. Metotlar ISlide.getNotesSlide() ve ISlide.addNotesSlide() Kullanımdan kaldırıldı**
Metot com.aspose.slides.ISlide.getNotesSlideManager() eklendi. Metotlar ISlide.getNotesSlide() ve ISlide.addNotesSlide() Kullanımdan kaldırıldı. Yeni metot ISlide.getNotesSlideManager() kullanın.

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);

    INotesSlide notes;

    // notes = slide.addNotesSlide(); - kullanımdan kaldırıldı

    // notes = slide.getNotesSlide(); - kullanımdan kaldırıldı

    notes = slide.getNotesSlideManager().getNotesSlide();

    notes = slide.getNotesSlideManager().addNotesSlide();

    slide.getNotesSlideManager().removeNotesSlide();
} finally {
    if (pres != null) pres.dispose();
}
```
#### **Metot getAppVersion() com.aspose.slides.IDocumentProperties'e eklendi**
Metot com.aspose.slides.IDocumentProperties.getAppVersion() Microsoft PowerPoint tarafından kullanılan dahili sürüm numaralarını temsil eden yerleşik belge özelliğini almak için eklendi.
#### **Metot remove() com.aspose.slides.IComment'e eklendi**
Metot com.aspose.slides.IComment.remove() yorumun koleksiyondan kaldırılması için eklendi.
#### **Metot remove() com.aspose.slides.ICommentAuthor'e eklendi**
Metot ICommentAuthor.Remove yorum yazarının koleksiyondan kaldırılması için eklendi.
#### **Metotlar clearCustomProperties() ve clearBuiltInProperties() com.aspose.slides.IDocumentProperties'e eklendi**
Metot com.aspose.slides.IDocumentProperties.clearCustomProperties() tüm özel belge özelliklerini kaldırmak için eklendi.  
Metot com.aspose.slides.IDocumentProperties.clearBuiltInProperties() tüm yerleşik belge özelliklerini (Company, Subject, Author vb.) kaldırmak ve varsayılan değerlerine ayarlamak için eklendi.
#### **Metotlar getBlackWhiteMode(), setBlackWhiteMode(byte) com.aspose.slides.IShape'e eklendi**
Metotlar getBlackWhiteMode(), setBlackWhiteMode(byte) com.aspose.slides.IShape'e eklendi.  
Bu metotlar, bir şeklin siyah‑beyaz görüntü modunda nasıl render edileceğini belirler. Olası değerler com.aspose.slides.BlackWhiteMode sınıfında belirtilmiştir.

|**Değer** |**Anlam** |
| :- | :- |
|Color |Normal renkli |
|Automatic |Otomatik renkli |
|Gray |Gri |
|LightGray |Açık gri |
|InverseGray |Ters gri |
|GrayWhite |Gri ve beyaz |
|BlackGray |Siyah ve gri |
|BlackWhite |Siyah ve beyaz |
|Black |Sadece siyah |
|White |Beyaz |
|Hidden |Gizli |
#### **Metotlar removeAt(int), remove(ICommentAuthor) ve clear() com.aspose.slides.ICommentAuthorCollection'a eklendi**
Metot ICommentAuthorCollection.removeAt(int) belirtilen indeksle yazar kaldırmak için eklendi.  
Metot ICommentAuthorCollection.remove(ICommentAuthor) belirtilen yazarı koleksiyondan kaldırmak için eklendi.  
Metot ICommentAuthorCollection.clear() tüm öğeleri koleksiyondan kaldırmak için eklendi.