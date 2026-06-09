---
title: "Aspose.Slides for .NET 14.3.0'da Genel API ve Geriye Uyumsuz Değişiklikler"
linktitle: "Aspose.Slides .NET için 14.3.0"
type: docs
weight: 50
url: /tr/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-3-0/
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
## **Genel API ve Geriye Uyumsuz Değişiklikler**
### **Aspose.Slides.ShapeThumbnailBounds Sıralaması ve Aspose.Slides.IShape.GetThumbnail() Yöntemleri Eklendi**
GetThumbnail() ve GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) yöntemleri ayrı bir şekil küçük resmi oluşturmak için kullanılır. ShapeThumbnailBounds sıralaması olası şekil küçük resmi sınırlama türlerini tanımlar.
### **Aspose.Slides.IShape'e UniqueId Özelliği Eklendi**
Aspose.Slides.IShape.UniqueId özelliği sunum kapsamındaki benzersiz bir şekil tanımlayıcısını alır. Bu benzersiz tanımlayıcılar şekil özel etiketlerinde depolanır.
### **IChartCategoryLevelsManager'da SetGroupingItem Yönteminin İmzası Değiştirildi**
Signature of the IChartCategoryLevelsManager method

``` csharp

 void SetGroupingItem(int level, IChartDataCell value);

``` 

artık kullanılmıyor ve şu imza ile değiştirildi

``` csharp

 void SetGroupingItem(int level, object value);

``` 

Artık şu çağrılar gibi

``` csharp

 .SetGroupingItem(1, workbook.GetCell(0, "A2", "Group 1"));

``` 

şu şekildeki çağrılara değiştirilmelidir

``` csharp

 .SetGroupingItem(1, "Group 1");

``` 

SetGroupingItem içine "Group 1" gibi bir değer geçin, ancak IChartDataCell türünde bir değer geçmeyin. Kategori seviyeleri için tanımlı bir çalışma sayfası, satır ve sütunla IChartDataCell oluşturmak belli gereksinimleri karşılamalıdır ve SetGroupingItem(int, object) yönteminde kapsüllenmiştir.
### **Aspose.Slides.IBaseSlide Arayüzüne SlideId Özelliği Eklendi**
SlideId özelliği benzersiz bir slayt tanımlayıcısını alır.
### **ISlideShowTransition'a SoundName Özelliği Eklendi**
Okunup‑yazılabilen dize. Geçiş sesinin insan tarafından okunabilir adını belirler. Ses adını almak veya ayarlamak için Sound özelliği atanmalıdır. Bu isim, geçiş sesini manuel olarak yapılandırırken PowerPoint kullanıcı arabiriminde görünür. Sound özelliği atanmadığında PptxException fırlatabilir.
### **ChartSeriesGroup.Type Özelliğinin Türü Değiştirildi**
ChartSeriesGroup.Type özelliği ChartType sıralamasından yeni CombinableSeriesTypesGroup sıralamasına değiştirildi. CombinableSeriesTypesGroup sıralaması, birleştirilebilir seri türlerinin gruplarını temsil eder.
### **Bireysel Şekil Küçük Resimleri Oluşturma Desteği Eklendi**
Aspose.Slides.ShapeThumbnailBounds

Aspose.Slides.IShape ve Aspose.Slides.Shape içinde yeni üyeler:
public Bitmap GetThumbnail()
public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)