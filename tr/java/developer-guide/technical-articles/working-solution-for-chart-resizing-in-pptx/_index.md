---
title: PPTX'te Çizelge Yeniden Boyutlandırma için Çözüm
type: docs
weight: 40
url: /tr/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- çizelge yeniden boyutlandırma
- Excel çizelgesi
- OLE nesnesi
- çizelge gömme
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile gömülü Excel OLE nesneleri kullanıldığında PPTX'te beklenmeyen çizelge yeniden boyutlandırmasını düzeltin. Boyutların tutarlı kalması için iki yöntem ve kod örnekleri öğrenin."
---
## **Arka Plan**

Aspose bileşenleri aracılığıyla bir PowerPoint sunumuna OLE nesnesi olarak gömülen Excel çizelgelerinin ilk etkinleştirilmelerinden sonra belirlenmemiş bir ölçeğe yeniden boyutlandırıldığı gözlemlenmiştir. Bu davranış, çizelgenin etkinleştirme öncesi ve sonrası durumları arasında sunumda belirgin bir görsel fark oluşturur. Aspose ekibi sorunu ayrıntılı olarak araştırmış ve bir çözüm bulmuştur. Bu makale sorunun nedenlerini ve ilgili düzeltmeyi açıklamaktadır.

[Önceki makalede](/slides/tr/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) Aspose.Cells for Java ile bir Excel çizelgesi oluşturup, Aspose.Slides for Java kullanarak bunu bir PowerPoint sunumuna nasıl gömeceğimizi açıklamıştık. [Nesne önizleme sorunu](/slides/tr/java/object-preview-issue-when-adding-oleobjectframe/) ile başa çıkmak için çizelge resmini çizelgenin OLE nesne çerçevesine atadık. Çıktı sunumunda, çizelge resmini gösteren OLE nesne çerçevesine çift tıkladığınızda Excel çizelgesi etkinleştirilir. Son kullanıcılar, temel Excel çalışma kitabında istedikleri değişiklikleri yaptıktan sonra etkinleştirilen çalışma kitabının dışına tıklayarak ilgili slayta geri dönebilir. Kullanıcı slayta döndüğünde OLE nesne çerçevesinin boyutu değişir ve yeniden boyutlandırma faktörü, OLE nesne çerçevesi ile gömülü Excel çalışma kitabının orijinal boyutlarına bağlı olarak farklılık gösterir.

## **Yeniden Boyutlandırmanın Nedeni**

Excel çalışma kitabının kendi pencere boyutu olduğu için ilk etkinleştirildiğinde orijinal boyutunu korumaya çalışır. OLE nesne çerçevesinin ise ayrı bir boyutu vardır. Microsoft'a göre, Excel çalışma kitabı etkinleştirildiğinde Excel ve PowerPoint boyutu müzakere eder ve gömme sürecinin bir parçası olarak doğru oranları korur. Excel pencere boyutu ile OLE nesne çerçevesinin boyut veya konum farklarına bağlı olarak yeniden boyutlandırma gerçekleşir.

## **Çözüm**

Java için Aspose.Slides kullanarak PowerPoint sunumları oluşturmanın iki olası senaryosu vardır.

**Senaryo 1:** Mevcut bir şablona dayalı bir sunum oluşturmak.

**Senaryo 2:** Sıfırdan bir sunum oluşturmak.

Burada sunduğumuz çözüm her iki senaryoya da uygulanabilir. Tüm çözüm yaklaşımlarının temeli aynıdır: **gömülü OLE nesnesinin pencere boyutu, PowerPoint slaytındaki OLE nesne çerçevesiyle aynı olmalıdır**. Şimdi bu çözüme yönelik iki yaklaşımı tartışacağız.

## **Birinci Yaklaşım**

Bu yaklaşımda, gömülü Excel çalışma kitabının pencere boyutunu PowerPoint slaytındaki OLE nesne çerçevesiyle aynı olacak şekilde nasıl ayarlayacağımızı öğreneceğiz.

**Senaryo 1**

Bir şablon tanımladığımızı ve buna dayalı sunumlar oluşturmak istediğimizi varsayalım. Şablonda, indeks 2'de bir şekil olduğunu ve bu şekle gömülü bir Excel çalışma kitabı içeren bir OLE çerçevesi yerleştirmek istediğimizi düşünelim. Bu senaryoda OLE nesne çerçevesinin boyutu önceden tanımlanmıştır — şablondaki indeks 2'deki şeklin boyutuyla eşleşir. Tek yapmamız gereken, çalışma kitabının pencere boyutunu o şeklin boyutuna eşitlemektir. Aşağıdaki kod parçacığı bu amacı gerçekleştirir:

```java
// Çalışma kitabının pencere genişliğini inç cinsinden ayarlayın (PowerPoint inç başına 576 piksel kullandığı için 576'ya bölünür).
workbook.getSettings().setWindowWidthInch(slide.getShapes().get_Item(2).getWidth() / 72f);
 
// Çalışma kitabının pencere yüksekliğini inç cinsinden ayarlayın.
workbook.getSettings().setWindowHeightInch(slide.getShapes().get_Item(2).getHeight() / 72f);
 
// Çalışma kitabını bir bellek akışına kaydedin.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Gömülü Excel verileriyle bir OLE nesne çerçevesi oluşturun.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

**Senaryo 2**

Sıfırdan bir sunum oluşturmak ve gömülü bir Excel çalışma kitabı içeren istediğiniz boyutta bir OLE nesne çerçevesi eklemek istediğinizi varsayalım. Aşağıdaki kod parçacığında, slayt üzerinde x = 0,5 inç ve y = 1 inç konumunda yüksekliği 4 inç, genişliği 9,5 inç olan bir OLE nesne çerçevesi oluşturuyoruz. Ardından Excel çalışma kitabı penceresini aynı boyuta — yüksekliği 4 inç, genişliği 9,5 inç — ayarlıyoruz.

```java
// İstediğimiz yükseklik.
int desiredHeight = 288; // 4 inç (4 * 72)
 
// İstediğimiz genişlik.
int desiredWidth = 684; // 9.5 inç (9.5 * 72)
 
// Çizelge boyutunu bir pencere ile tanımla.
chart.setSizeWithWindow(true);
 
// Çalışma kitabının pencere genişliğini inç cinsinden ayarla (PowerPoint inç başına 576 piksel kullandığı için 576'ya bölünür).
workbook.getSettings().setWindowWidthInch(desiredHeight / 72f);
 
// Çalışma kitabının pencere yüksekliğini inç cinsinden ayarla.
workbook.getSettings().setWindowHeightInch(desiredWidth / 72f);
 
// Çalışma kitabını bir bellek akışına kaydet.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Gömülü Excel verileriyle bir OLE nesne çerçevesi oluştur.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    288,
    576,
    desiredWidth,
    desiredHeight,
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

## **İkinci Yaklaşım**

Bu yaklaşımda, gömülü Excel çalışma kitabındaki çizelgenin boyutunu PowerPoint slaytındaki OLE nesne çerçevesiyle aynı olacak şekilde nasıl ayarlayacağımızı öğreneceğiz. Bu yaklaşım, çizelge boyutunun önceden bilindiği ve değişmeyeceği durumlarda kullanışlıdır.

**Senaryo 1**

Bir şablon tanımladığımızı ve buna dayalı sunumlar oluşturmak istediğimizi varsayalım. Şablonda, indeks 2'de bir şekil olduğunu ve bu şekle gömülü bir Excel çalışma kitabı içeren bir OLE çerçevesi yerleştirmek istediğimizi düşünelim. Bu senaryoda OLE çerçevesinin boyutu önceden tanımlanmıştır — şablondaki indeks 2'deki şeklin boyutuyla eşleşir. Tek yapmamız gereken, çalışma kitabındaki çizelge boyutunu o şeklin boyutuna eşitlemektir. Aşağıdaki kod parçacığı bu amacı gerçekleştirir:

```java
// Pencere olmadan çizelge boyutunu tanımla.
chart.setSizeWithWindow(false);
 
// Çizelge genişliğini piksel cinsinden ayarla (Excel inç başına 96 piksel kullandığı için 96 ile çarp).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 72f) * 96f));
 
// Çizelge yüksekliğini piksel cinsinden ayarla.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 72f) * 96f));
 
// Çizelge baskı boyutunu tanımla.
chart.setPrintSize(PrintSizeType.CUSTOM);
 
// Çalışma kitabını bir bellek akışına kaydet.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Gömülü Excel verileriyle bir OLE nesne çerçevesi oluştur.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

**Senaryo 2**:

Sıfırdan bir sunum oluşturmak ve gömülü bir Excel çalışma kitabı içeren istediğiniz boyutta bir OLE nesne çerçevesi eklemek istediğinizi varsayalım. Aşağıdaki kod parçacığında, slayt üzerinde x = 0,5 inç ve y = 1 inç konumunda yüksekliği 4 inç, genişliği 9,5 inç olan bir OLE nesne çerçevesi oluşturuyoruz. Aynı ölçüleri çizelgeye de uyguluyoruz: yüksekliği 4 inç ve genişliği 9,5 inç.

```java
// İstediğimiz yükseklik.
int desiredHeight = 288; // 4 inç (4 * 72)
 
// İstediğimiz genişlik.
int desiredWidth = 684; // 9.5 inç (9.5 * 72)
 
// Pencere olmadan çizelge boyutunu tanımla.
chart.setSizeWithWindow(false);
 
// Çizelge genişliğini piksel cinsinden ayarla (Excel inç başına 96 piksel kullandığı için 96 ile çarp).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 576f) * 96f));
 
// Çizelge yüksekliğini piksel cinsinden ayarla.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 576f) * 96f));
 
// Çalışma kitabını bir bellek akışına kaydet.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Gömülü Excel verileriyle bir OLE nesne çerçevesi oluştur.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    288,
    576,
    desiredWidth,
    desiredHeight,
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

## **Sonuç**

Çizelge yeniden boyutlandırma sorununu çözmek için iki yaklaşım bulunmaktadır. Yaklaşım seçimi gereksinimlere ve kullanım senaryosuna bağlıdır. Her iki yaklaşım da şablondan oluşturulan ya da sıfırdan oluşturulan sunumlarda aynı şekilde çalışır. Ayrıca bu çözümde OLE nesne çerçevesinin boyutu için bir sınırlama yoktur.

## **SSS**

**Gömülü Excel çizelgem PowerPoint’te etkinleştirildikten sonra neden boyut değiştiriyor?**

Excel, ilk etkinleştirildiğinde orijinal pencere boyutunu geri yüklemeye çalışırken, PowerPoint’teki OLE nesne çerçevesinin kendi boyutları vardır. PowerPoint ve Excel, en boy oranını korumak için boyutu müzakere eder ve bu durum yeniden boyutlandırmaya neden olabilir.

**Bu yeniden boyutlandırma sorununu tamamen önlemek mümkün mü?**

Evet. Excel çalışma kitabı penceresinin veya çizelge boyutunun OLE nesne çerçevesi boyutuyla eşleşecek şekilde gömülmeden önce ayarlanması, çizelge boyutlarının tutarlı kalmasını sağlar.

**Hangi yaklaşımı seçmeliyim, pencere boyutunu mu yoksa çizelge boyutunu mu ayarlamalıyım?**

Çalışma kitabının en boy oranını korumak ve gerektiğinde yeniden boyutlandırmaya izin vermek istiyorsanız **Yaklaşım 1’i (pencere boyutu)** kullanın. Çizelge boyutları sabit ve gömülmeden sonra değişmeyecekse **Yaklaşım 2’yi (çizelge boyutu)** tercih edin.

**Bu yöntemler şablona dayalı sunumlar ve yeni oluşturulan sunumlar için de geçerli mi?**

Evet. Her iki yaklaşım da şablondan oluşturulan ve sıfırdan oluşturulan sunumlarda aynı şekilde çalışır.

**OLE nesne çerçevesinin boyutu için bir sınırlama var mı?**

Hayır. OLE çerçevesini, çalışma kitabı veya çizelge boyutuna uygun şekilde ölçeklenebildiği sürece istediğiniz boyuta ayarlayabilirsiniz.

**Bu yöntemleri diğer tablo programlarında oluşturulan çizelgelerle kullanabilir miyim?**

Örnekler Excel çizelgeleri için Aspose.Cells kullanılarak hazırlanmıştır, ancak prensipler benzer boyutlandırma seçeneklerine sahip diğer OLE uyumlu tablo programları için de geçerlidir.

## **İlgili Bölümler**

- [Excel Çizelgeleri Oluşturma ve Sunumlarda OLE Nesnesi Olarak Gömme](/slides/tr/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [OLE Nesnelerini PowerPoint Eklentisiyle Otomatik Güncelleme](/slides/tr/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)