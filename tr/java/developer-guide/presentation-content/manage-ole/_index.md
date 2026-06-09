---
title: Java Kullanarak Sunumlarda OLE Yönetimi
linktitle: OLE Yönetimi
type: docs
weight: 40
url: /tr/java/manage-ole/
keywords:
- OLE nesnesi
- Nesne Bağlantısı ve Gömme
- OLE ekle
- OLE gömme
- nesne ekle
- nesne gömme
- dosya ekle
- dosya gömme
- bağlantılı nesne
- bağlantılı dosya
- OLE değiştir
- OLE simgesi
- OLE başlığı
- OLE çıkarma
- nesneyi çıkar
- dosyayı çıkar
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint ve OpenDocument dosyalarında OLE nesne yönetimini optimize edin. OLE içeriğini sorunsuz bir şekilde gömün, güncelleyin ve dışa aktarın."
---
## **Giriş**

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding), bir uygulamada oluşturulan veri ve nesnelerin başka bir uygulamaya bağlantı ya da gömme yoluyla yerleştirilebilmesini sağlayan bir Microsoft teknolojisidir. 

{{% /alert %}} 

MS Excel’de oluşturulmuş bir grafiği düşünün. Bu grafik daha sonra bir PowerPoint slaytına yerleştirilir. Excel grafiği bir OLE nesnesi olarak kabul edilir. 

- Bir OLE nesnesi bir simge olarak görünebilir. Bu durumda simgeye çift‑tıkladığınızda grafik ilişkili uygulamasında (Excel) açılır veya nesneyi açmak/ düzenlemek için bir uygulama seçmeniz istenir. 
- Bir OLE nesnesi, grafiğin içeriği gibi gerçek içeriğini gösterebilir. Bu durumda grafik PowerPoint içinde etkinleşir, grafik arayüzü yüklenir ve grafiğin verilerini PowerPoint içinde değiştirebilirsiniz. 

[Aspose.Slides for Java](https://products.aspose.com/slides/tr/java/) OLE Nesnelerini slaytlara OLE nesne çerçeveleri ([OleObjectFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/OleObjectFrame)) olarak eklemenizi sağlar. 

## **Slaytlara OLE Nesne Çerçeveleri Ekleme**

Microsoft Excel’de zaten bir grafik oluşturduğunuzu ve bunu Aspose.Slides for Java kullanarak bir OLE nesne çerçevesi olarak bir slayta gömmek istediğinizi varsayalım; bunu şu şekilde yapabilirsiniz:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun. 
1. Slaytın referansını indeksine göre alın. 
1. Excel dosyasını bir bayt dizisi olarak okuyun. 
1. OLE nesnesiyle ilgili bayt dizisini ve diğer bilgileri içeren [OleObjectFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/OleObjectFrame) çerçevesini slayta ekleyin. 
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin. 

Aşağıdaki örnekte, bir Excel dosyasındaki grafiği Aspose.Slides for Java kullanarak bir OLE nesne çerçevesi olarak bir slayta ekledik.  
**Not**: [OleEmbeddedDataInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/OleEmbeddedDataInfo) yapıcısı ikinci parametre olarak gömülebilir bir nesne uzantısı alır. Bu uzantı, PowerPoint’in dosya türünü doğru bir şekilde yorumlamasını ve bu OLE nesnesini açmak için doğru uygulamayı seçmesini sağlar. 

``` java 
Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// OLE nesnesi için veriyi hazırlayın.
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// OLE nesne çerçevesini slayta ekleyin.
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Bağlantılı OLE Nesne Çerçeveleri Ekleme**

Aspose.Slides for Java, veriyi gömmeden yalnızca dosyaya bir bağlantı ile bir [OleObjectFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/OleObjectFrame) eklemenize olanak tanır. 

Bu Java kodu, bir slayta bağlantılı bir Excel dosyasıyla bir [OleObjectFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/OleObjectFrame) eklemenin yolunu gösterir: 

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Bağlantılı bir Excel dosyasıyla OLE nesne çerçevesi ekleyin.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **OLE Nesne Çerçevelerine Erişim**

Bir OLE nesnesi zaten bir slayta gömülmüşse, onu aşağıdaki şekilde kolayca bulabilir veya erişebilirsiniz: 

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturarak gömülü OLE nesnesi içeren bir sunumu yükleyin. 
2. İndeksini kullanarak slaytın referansını alın. 
3. [OleObjectFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/OleObjectFrame) şekline erişin.  
   Örneğimizde, ilk slaytta yalnızca bir şekil bulunan daha önce oluşturulmuş PPTX’i kullandık. Ardından bu nesneyi bir [IOleObjectFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IOleObjectFrame) olarak *cast* ettik. Bu, erişilmek istenen OLE nesne çerçevesiydi. 
4. OLE nesne çerçevesine erişildiğinde, üzerinde istediğiniz herhangi bir işlemi gerçekleştirebilirsiniz. 

Aşağıdaki örnekte, bir OLE nesne çerçevesi (slayta gömülmüş bir Excel grafik nesnesi) ve dosya verileri erişilmektedir. 

``` java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // Gömülü dosya verisini alın.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Gömülü dosyanın uzantısını alın.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Bağlantılı OLE Nesne Çerçevesi Özelliklerine Erişim**

Aspose.Slides, bağlantılı OLE nesne çerçevesi özelliklerine erişmenizi sağlar. 

Bu Java kodu, bir OLE nesnesinin bağlantılı olup olmadığını kontrol etmenizi ve ardından bağlantılı dosyanın yolunu elde etmenizi gösterir: 

```java
Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // OLE nesnesinin bağlantılı olup olmadığını kontrol edin.
    if (oleFrame.isObjectLink()) {
        // Bağlantılı dosyanın tam yolunu yazdır.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // Bağlantılı dosyanın göreceli yolunu, mevcutsa, yazdır.
        // Yalnızca PPT sunumları göreceli yolu içerebilir.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **OLE Nesne Verilerini Değiştirme**

{{% alert color="primary" %}} 

Bu bölümde, aşağıdaki kod örneği [Aspose.Cells for Java](/cells/java/) kullanmaktadır. 

{{% /alert %}} 

Bir OLE nesnesi zaten bir slayta gömülmüşse, bu nesneye erişip verilerini şu şekilde değiştirebilirsiniz: 

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturarak gömülü OLE nesnesi içeren bir sunumu yükleyin. 
2. İndeksini kullanarak slayt referansını alın. 
3. OLE nesne çerçevesi şekline erişin.  
   Örneğimizde, ilk slaytta bir şekil bulunan daha önce oluşturulmuş PPTX’i kullandık. Ardından bu nesneyi bir [IOleObjectFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IOleObjectFrame) olarak *cast* ettik. Bu, erişilmek istenen OLE nesne çerçevesiydi. 
4. OLE nesne çerçevesine erişildiğinde, üzerinde istediğiniz herhangi bir işlemi gerçekleştirebilirsiniz. 
5. Bir `Workbook` nesnesi oluşturup OLE verisine erişin. 
6. İstenen `Worksheet`’i alıp verileri değiştirin. 
7. Güncellenmiş `Workbook`’ı bir akışa (stream) kaydedin. 
8. OLE nesne verisini akıştan değiştirin. 

Aşağıdaki örnekte, bir OLE nesne çerçevesi (slayta gömülmüş bir Excel grafik nesnesi) erişilip dosya verileri değiştirilerek grafik verileri güncellenmektedir. 

``` java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // OLE nesne verisini Workbook nesnesi olarak okuyun.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Workbook verisini değiştirin.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // OLE çerçeve nesnesi verisini değiştirin.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Diğer Dosya Türlerini Slaytlara Gömme**

Excel grafiklerinin yanı sıra, Aspose.Slides for Java slaytlara HTML, PDF ve ZIP gibi farklı dosya türlerini nesne olarak gömmeyi sağlar. Kullanıcı eklenen nesneye çift‑tıkladığında, ilgili program otomatik olarak açılır veya kullanıcıdan dosyayı açmak için uygun bir program seçmesi istenir. 

Bu Java kodu, bir slayta HTML ve ZIP dosyalarını nasıl gömeceğinizi gösterir: 

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

byte[] htmlData = Files.readAllBytes(Paths.get("sample.html"));
IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
IOleObjectFrame htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

byte[] zipData = Files.readAllBytes(Paths.get("sample.zip"));
IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
IOleObjectFrame zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Gömülü Nesneler İçin Dosya Türlerini Belirleme**

Sunumlarla çalışırken eski OLE nesnelerini yeniyle değiştirmek veya desteklenmeyen bir OLE nesnesini desteklenen bir nesneyle değiştirmek isteyebilirsiniz. Aspose.Slides for Java, gömülü bir nesnenin dosya türünü ayarlamanıza izin verir; bu sayede OLE çerçevesi verisini veya uzantısını güncelleyebilirsiniz. 

Bu Java kodu, gömülü bir OLE nesnesinin dosya türünü `zip` olarak ayarlamayı gösterir: 

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// Change the file type to ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Gömülü Nesneler İçin Simge Görüntüsü ve Başlık Ayarlama**

Bir OLE nesnesi gömüldükten sonra, otomatik olarak bir simge görüntüsü içeren bir önizleme eklenir. Bu önizleme, kullanıcıların OLE nesnesine erişmeden veya açmadan önce gördükleri şeydir. Önizlemede belirli bir resim ve metin kullanmak istiyorsanız, Aspose.Slides for Java ile simge görüntüsü ve başlığı ayarlayabilirsiniz. 

Bu Java kodu, gömülü bir nesne için simge görüntüsü ve başlığı nasıl ayarlayacağınızı gösterir: 

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Sunum kaynaklarına bir resim ekleyin.
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **OLE Nesne Çerçevesinin Yeniden Boyutlandırılmasını ve Yeniden Konumlandırılmasını Önleme**

Bağlantılı bir OLE nesnesini bir sunum slaytına eklediğinizde, PowerPoint’te sunumu açtığınızda bağlantıları güncellemek için bir ileti görebilirsiniz. “Update Links” (Bağlantıları Güncelle) düğmesine tıkladığınızda PowerPoint, bağlantılı OLE nesnesinden verileri günceller ve nesne önizlemesini yenilediği için OLE nesne çerçevesinin boyutu ve konumu değişebilir. PowerPoint’in nesnenin verilerini güncelleme istemesini önlemek için [IOleObjectFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ioleobjectframe/) arayüzünün `setUpdateAutomatic` metodunu `false` olarak ayarlayın: 

```java
oleFrame.setUpdateAutomatic(false);
```

## **Gömülü Dosyaları Çıkarma**

Aspose.Slides for Java, slaytlara OLE nesnesi olarak gömülmüş dosyaları şu şekilde çıkarabilir: 

1. Çıkarmak istediğiniz OLE nesnelerini içeren bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının örneğini oluşturun. 
2. Sunumdaki tüm şekilleri döngüye alarak [OLEObjectFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/oleobjectframe) şekillerine erişin. 
3. Gömülü dosya verilerine OLE nesne çerçevelerinden erişin ve diske yazın. 

Bu Java kodu, bir slayttan OLE nesnesi olarak gömülmüş dosyaları nasıl çıkaracağınızı gösterir: 

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);

for (int index = 0; index < slide.getShapes().size(); index++) {
    IShape shape = slide.getShapes().get_Item(index);

    if (shape instanceof IOleObjectFrame) {
        IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

        byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        Path filePath = Paths.get("OLE_object_" + index + fileExtension);
        Files.write(filePath, fileData);
    }
}

presentation.dispose();
```

## **SSS**

**OLE içeriği PDF/görsellere dışa aktarılırken işlenecek mi?**  

Slaytta görülen şey işlenir—simge/yer tutucu görüntüsü (önizleme). “Canlı” OLE içeriği render sırasında yürütülmez. Gerekirse, dışa aktarılan PDF’de beklenen görünümü sağlamak için kendi önizleme resminizi ayarlayın.  

**Bir OLE nesnesini slaytta kilitleyerek kullanıcıların PowerPoint’te taşımasını/düzenlemesini nasıl engelleyebilirim?**  

Şekli kilitleyin: Aspose.Slides, [şekil‑seviyesi kilitler](/slides/tr/java/applying-protection-to-presentation/) sunar. Bu bir şifreleme değildir, ancak kazara düzenlemeleri ve hareketi etkili bir şekilde önler.  

**Bağlantılı bir Excel nesnesi sunumu açtığımda “zıplıyor” ya da boyutu değişiyor, neden?**  

PowerPoint, bağlantılı OLE’nin önizlemesini yenileyebilir. Stabil bir görünüm için [Çalışma Sayfası Yeniden Boyutlandırma için Çözüm](/slides/tr/java/working-solution-for-worksheet-resizing/) önerilerine bakın—çerçeveyi aralığa uydurun veya aralığı sabit bir çerçeveye ölçeklendirin ve uygun bir yer tutucu resim ayarlayın.  

**Bağlantılı OLE nesneleri için göreceli yollar PPTX formatında korunur mu?**  

PPTX’te “göreceli yol” bilgisi yoktur—yalnızca tam yol bulunur. Göreceli yollar, eski PPT formatında bulunur. Taşınabilirlik için güvenilir mutlak yollar/erişilebilir URI’lar veya gömme yöntemini tercih edin.  