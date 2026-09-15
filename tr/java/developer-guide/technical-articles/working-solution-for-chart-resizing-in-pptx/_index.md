---
title: PPTX'te Grafik Yeniden Boyutlandırma İçin Çalışan Çözüm
type: docs
weight: 40
url: /tr/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- grafik yeniden boyutlandırma
- Excel grafik
- OLE nesnesi
- grafik gömme
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile gömülü Excel OLE nesneleri kullanıldığında PPTX'te beklenmeyen grafik yeniden boyutlandırmayı düzeltin. Boyutların tutarlı kalmasını sağlamak için kodla iki yöntemi öğrenin."
---
## **Arka Plan**

Excel grafiklerinin Aspose bileşenleri aracılığıyla bir PowerPoint sunumunda OLE nesnesi olarak gömülmesi sonrasında, ilk etkinleştirilmelerinden sonra belirsiz bir ölçekte yeniden boyutlandırıldığı gözlemlenmiştir. Bu davranış, grafiğin etkinleştirilmeden önceki ve sonraki durumları arasında belirgin bir görsel fark yaratır. Aspose ekibi sorunu ayrıntılı olarak inceledi ve bir çözüm buldu. Bu makale sorunun nedenlerini ve ilgili düzeltmeyi açıklamaktadır.

[önceki makale](/slides/tr/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) adresinde, Aspose.Cells for Java ile bir Excel grafiği oluşturup Aspose.Slides for Java kullanarak bir PowerPoint sunumuna nasıl gömeceğinizi anlattık. [nesne önizleme sorunu](/slides/tr/java/object-preview-issue-when-adding-oleobjectframe/) (object preview issue) çözümü için grafiğin görüntüsünü OLE nesne çerçevesine atadık. Çıktı sunumunda, grafiğin görüntüsünü gösteren OLE nesne çerçevesine çift‑tıkladığınızda Excel grafiği etkinleştirilir. Son kullanıcılar, alttaki Excel çalışma kitabında istedikleri değişiklikleri yaptıktan sonra etkinleştirilen çalışma kitabının dışına tıklayarak ilgili slayta geri dönebilir. Kullanıcı slayta döndüğünde OLE nesne çerçevesinin boyutu değişir ve bu yeniden boyutlandırma faktörü, OLE nesne çerçevesinin ve gömülü Excel çalışma kitabının orijinal boyutlarına bağlı olarak değişir.

## **Yeniden Boyutlandırmanın Nedeni**

Excel çalışma kitabının kendi pencere boyutu olduğundan, ilk etkinleştirildiğinde orijinal boyutunu korumaya çalışır. OLE nesne çerçevesinin ise kendi boyutu vardır. Microsoft’a göre, Excel çalışma kitabı etkinleştirildiğinde, Excel ve PowerPoint boyutu müzakere eder ve gömme işleminin bir parçası olarak doğru oranları korur. Excel pencere boyutu ile OLE nesne çerçevesinin boyut veya konum farkına bağlı olarak yeniden boyutlandırma gerçekleşir.

## **Çözüm**

PowerPoint sunumlarını Aspose.Slides for Java ile oluştururken iki olası senaryo vardır.

**Senaryo 1:** Mevcut bir şablona dayanarak sunum oluşturma.

**Senaryo 2:** Sıfırdan yeni bir sunum oluşturma.

Burada sunduğumuz çözüm her iki senaryoya da uygulanabilir. Tüm çözüm yaklaşımlarının temeli aynıdır: **gömülü OLE nesnesinin pencere boyutu, PowerPoint slaydındaki OLE nesne çerçevesiyle aynı olmalıdır**. Şimdi bu çözümün iki yaklaşımını inceleyeceğiz.

## **İlk Yaklaşım**

Bu yaklaşımda, gömülü Excel çalışma kitabının pencere boyutunu, PowerPoint slaydındaki OLE nesne çerçevesinin boyutuna eşit olacak şekilde ayarlamayı öğreneceğiz.

**Senaryo 1**

Bir şablon tanımladığımızı ve bu şablona dayanarak sunumlar oluşturmak istediğimizi varsayalım. Şablonda indeks 2’de bir şekil var ve bu şeklin içine gömülü bir Excel çalışma kitabı içeren bir OLE çerçevesi yerleştirmek istiyoruz. Bu senaryoda OLE nesne çerçevesinin boyutu önceden tanımlıdır – indeks 2’deki şeklin boyutuyla aynıdır. Tek yapmamız gereken, çalışma kitabının pencere boyutunu bu şeklin boyutuna eşitlemektir. Aşağıdaki kod parçacığı bu amacı gerçekleştirir:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Çalışma kitabının pencere genişliğini inç cinsinden ayarlayın (PowerPoint 72 nokta/inç kullandığından 72'ye bölünür).
workbook.getSettings().setWindowWidthInch(slide.getShapes().get_Item(2).getWidth() / 72f);
 
// Çalışma kitabının pencere yüksekliğini inç cinsinden ayarlayın.
workbook.getSettings().setWindowHeightInch(slide.getShapes().get_Item(2).getHeight() / 72f);
 
// Çalışma kitabını bir bellek akışına kaydedin.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Gömülü Excel verileriyle bir OLE nesne çerçevesi oluşturun.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    dataInfo);
```

**Senaryo 2**

Sıfırdan bir sunum oluşturmak ve içinde herhangi bir boyutta, gömülü bir Excel çalışma kitabı bulunan bir OLE çerçevesi eklemek istediğimizi düşünelim. Aşağıdaki kodda, slaytta x = 0,5 inç ve y = 1 inç konumunda, yüksekliği 4 inç ve genişliği 9,5 inç olan bir OLE çerçevesi oluşturuyoruz. Ardından Excel çalışma kitabı penceresini aynı boyuta – yüksekliği 4 inç, genişliği 9,5 inç – ayarlıyoruz.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// İstediğimiz yükseklik.
int desiredHeight = 288; // 4 inç (4 * 72)
 
// İstediğimiz genişlik.
int desiredWidth = 684; // 9.5 inç (9.5 * 72)
 
// Pencere ile grafik boyutunu tanımla.
chart.setSizeWithWindow(true);
 
// Çalışma kitabının pencere genişliğini inç cinsinden ayarlayın (PowerPoint 72 nokta/inç kullandığından 72'ye bölünür).
workbook.getSettings().setWindowWidthInch(desiredWidth / 72f);
 
// Çalışma kitabının pencere yüksekliğini inç cinsinden ayarlayın.
workbook.getSettings().setWindowHeightInch(desiredHeight / 72f);
 
// Çalışma kitabını bir bellek akışına kaydedin.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Gömülü Excel verileriyle bir OLE nesne çerçevesi oluşturun.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    36,  // x = 0.5 inç (0.5 * 72)
    72,  // y = 1 inç (1 * 72)
    desiredWidth,
    desiredHeight,
    dataInfo);
```

## **İkinci Yaklaşım**

Bu yaklaşımda, gömülü Excel çalışma kitabındaki grafiğin boyutunu, PowerPoint slaydındaki OLE nesne çerçevesinin boyutuna eşit olacak şekilde ayarlamayı öğreneceğiz. Bu yaklaşım, grafik boyutu önceden biliniyor ve değişmeyecekse kullanışlıdır.

**Senaryo 1**

Bir şablon tanımladığımızı ve bu şablona dayanarak sunumlar oluşturmak istediğimizi varsayalım. Şablonda indeks 2’de bir şekil var ve bu şeklin içine gömülü bir Excel çalışma kitabı içeren bir OLE çerçevesi yerleştirmeyi planlıyoruz. Bu senaryoda OLE çerçevesinin boyutu önceden tanımlıdır – indeks 2’deki şeklin boyutuyla aynıdır. Tek yapmamız gereken, çalışma kitabındaki grafiğin boyutunu bu şeklin boyutuna eşitlemektir. Aşağıdaki kod parçacığı bu amacı gerçekleştirir:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Pencere olmadan grafik boyutunu tanımla.
chart.setSizeWithWindow(false);
 
// Grafiğin genişliğini piksel cinsinden ayarla (Excel'in inç başına 96 piksel kullandığını göz önünde bulundurarak 96 ile çarpın).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 72f) * 96f));
 
// Grafiğin yüksekliğini piksel cinsinden ayarla.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 72f) * 96f));
 
// Grafik baskı boyutunu tanımla.
chart.setPrintSize(com.aspose.cells.PrintSizeType.CUSTOM);
 
// Çalışma kitabını bir bellek akışına kaydedin.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Gömülü Excel verileriyle bir OLE nesne çerçevesi oluşturun.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    dataInfo);
```

**Senaryo 2**:

Sıfırdan bir sunum oluşturmak ve içinde herhangi bir boyutta, gömülü bir Excel çalışma kitabı bulunan bir OLE çerçevesi eklemek istediğimizi düşünelim. Aşağıdaki kodda, slaytta x = 0,5 inç ve y = 1 inç konumunda, yüksekliği 4 inç ve genişliği 9,5 inç olan bir OLE çerçevesi oluşturuyoruz. Aynı boyutları, yani yüksekliği 4 inç ve genişliği 9,5 inç, grafik boyutu olarak da ayarlıyoruz.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// İstediğimiz yükseklik.
int desiredHeight = 288; // 4 inç (4 * 72)
 
// İstediğimiz genişlik.
int desiredWidth = 684; // 9.5 inç (9.5 * 72)
 
// Pencere olmadan grafik boyutunu tanımla.
chart.setSizeWithWindow(false);
 
// Grafiğin genişliğini piksel cinsinden ayarla (inç elde etmek için 72'ye bölün, Excel'in inç başına 96 piksel kullandığını göz önünde bulundurarak 96 ile çarpın).
chart.getChartObject().setWidth((int)((desiredWidth / 72f) * 96f));
 
// Grafiğin yüksekliğini piksel cinsinden ayarla.
chart.getChartObject().setHeight((int)((desiredHeight / 72f) * 96f));
 
// Çalışma kitabını bir bellek akışına kaydedin.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Gömülü Excel verileriyle bir OLE nesne çerçevesi oluşturun.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    36,  // x = 0.5 inç (0.5 * 72)
    72,  // y = 1 inç (1 * 72)
    desiredWidth,
    desiredHeight,
    dataInfo);
```

## **Sonuç**

Grafik yeniden boyutlandırma sorununu çözmek için iki yaklaşım vardır. Hangi yaklaşımın seçileceği gereksinimlere ve kullanım senaryosuna bağlıdır. Her iki yaklaşım da şablondan oluşturulmuş ya da sıfırdan oluşturulmuş sunumlarda aynı şekilde çalışır. Ayrıca bu çözümde OLE nesne çerçevesinin boyutu için bir üst sınır yoktur.

## **SSS**

### Yerleşik Excel grafiğim PowerPoint'te etkinleştirildikten sonra neden boyut değiştiriyor?

Excel, ilk etkinleştirildiğinde orijinal pencere boyutunu geri yüklemeye çalışır; PowerPoint'teki OLE nesne çerçevesinin ise ayrı bir boyutu vardır. PowerPoint ve Excel, oranı korumak için boyutu müzakere eder ve bu da yeniden boyutlandırmaya yol açabilir.

### Bu yeniden boyutlandırma sorununu tamamen önlemek mümkün mü?

Evet. Excel çalışma kitabı pencere boyutunu veya grafik boyutunu OLE nesne çerçevesi boyutuna eşitleyerek gömmeden önce ayarlarsanız, grafik boyutları tutarlı kalır.

### Hangi yaklaşımı tercih etmeliyim, çalışma kitabı pencere boyutunu ayarlamak mı yoksa grafik boyutunu ayarlamak mı?

**Yaklaşım 1 (pencere boyutu)** kullanın; böylece çalışma kitabının oranı korunur ve gerektiğinde yeniden boyutlandırma yapılabilir.  
**Yaklaşım 2 (grafik boyutu)** kullanın; grafik boyutları sabit ve gömüldükten sonra değişmeyecekse bu yöntemi tercih edin.

### Bu yöntemler hem şablon‑tabanlı hem de yeni oluşturulan sunumlarda çalışır mı?

Evet. Her iki yaklaşım da şablonlardan oluşturulan ve sıfırdan oluşturulan sunumlar için aynı şekilde çalışır.

### OLE nesne çerçevesinin boyutu için bir sınırlama var mı?

Hayır. OLE çerçevesini, çalışma kitabı veya grafik boyutuna uygun şekilde ölçeklendirdiğiniz sürece istediğiniz herhangi bir boyuta ayarlayabilirsiniz.

### Bu yöntemleri diğer elektronik tablo programlarıyla oluşturulan grafiklerde kullanabilir miyim?

Örnekler, Aspose.Cells ile oluşturulan Excel grafikleri için hazırlanmıştır; ancak prensipler, benzer boyutlandırma seçeneklerini destekleyen diğer OLE‑uyumlu elektronik tablo programları için de geçerlidir.

## **İlgili Bölümler**

- [Excel Grafiklerini Oluşturma ve Sunumlarda OLE Nesnesi Olarak Gömme](/slides/tr/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)