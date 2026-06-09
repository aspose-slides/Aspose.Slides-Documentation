---
title: Android'de Sunumlarda OLE Yönetimi
linktitle: OLE Yönetimi
type: docs
weight: 40
url: /tr/androidjava/manage-ole/
keywords:
- OLE nesnesi
- Nesne Bağlama ve Gömme
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
- OLE çıkar
- nesne çıkar
- dosya çıkar
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile PowerPoint ve OpenDocument dosyalarında OLE nesne yönetimini optimize edin. OLE içeriğini sorunsuz bir şekilde gömün, güncelleyin ve dışa aktarın."
---
## **Giriş**

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding), bir Microsoft teknolojisidir ve bir uygulamada oluşturulan veri ve nesnelerin başka bir uygulamaya bağlanarak ya da gömülerek yerleştirilmesine olanak tanır. 

{{% /alert %}} 

MS Excel’de oluşturulan bir grafiği düşünün. Grafik daha sonra bir PowerPoint slaytına yerleştirilir. Bu Excel grafiği bir OLE nesnesi olarak kabul edilir. 

- Bir OLE nesnesi bir simge olarak görünebilir. Bu durumda, simgeye çift tıkladığınızda grafik ilişkili uygulamasında (Excel) açılır veya nesneyi açmak/düzenlemek için bir uygulama seçmeniz istenir. 
- Bir OLE nesnesi gerçek içeriğini, örneğin bir grafiğin içeriğini gösterebilir. Bu durumda, grafik PowerPoint içinde etkinleştirilir, grafik arayüzü yüklenir ve grafiğin verilerini PowerPoint içinde değiştirebilirsiniz. 

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/tr/androidjava/) OLE nesnelerini slaytlara OLE nesne çerçeveleri olarak eklemenizi sağlar ([OleObjectFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/OleObjectFrame)).

## **Slaytlara OLE Nesne Çerçeveleri Ekleme**

Microsoft Excel'de zaten bir grafik oluşturduğunuzu ve Aspose.Slides for Android via Java kullanarak bunu bir slayta OLE nesne çerçevesi olarak gömmek istediğinizi varsayarsak, bunu şu şekilde yapabilirsiniz:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
1. İndeksini kullanarak bir slaytın referansını alın.  
1. Excel dosyasını bir bayt dizisi olarak okuyun.  
1. Bayt dizisini ve OLE nesnesiyle ilgili diğer bilgileri içeren [OleObjectFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/OleObjectFrame) öğesini slayta ekleyin.  
1. Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.  

Aşağıdaki örnekte, bir Excel dosyasından bir grafiği Aspose.Slides for Android via Java kullanarak bir slayta OLE nesne çerçevesi olarak ekledik.  
**Not**: [OleEmbeddedDataInfo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/OleEmbeddedDataInfo) yapıcısı ikinci parametre olarak gömülebilir nesne uzantısını alır. Bu uzantı, PowerPoint'in dosya türünü doğru yorumlamasını ve bu OLE nesnesini açmak için doğru uygulamayı seçmesini sağlar.

```java 
Presentation presentation = new Presentation();
SizeF slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// OLE nesnesi için verileri hazırlayın.
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Bağlantılı OLE Nesne Çerçeveleri Ekleme**

Aspose.Slides for Android via Java, veri gömmeden yalnızca dosya bağlantısı ile bir [OleObjectFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/OleObjectFrame) eklemenize olanak tanır.

Bu Java kodu, bir slayta bağlantılı bir Excel dosyasıyla [OleObjectFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/OleObjectFrame) eklemenin nasıl yapılacağını gösterir:

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Bağlantılı bir Excel dosyasıyla OLE nesne çerçevesi ekle.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **OLE Nesne Çerçevelerine Erişim**

Bir OLE nesnesi zaten bir slayta gömülmüşse, onu şu şekilde kolayca bulabilir ya da erişebilirsiniz:

1. Gömülü OLE nesnesi içeren bir sunumu, bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturarak yükleyin.  
2. İndeksini kullanarak slaytın referansını alın.  
3. [OleObjectFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/OleObjectFrame) şekline erişin. Örneğimizde, ilk slaytta yalnızca bir şekil bulunan daha önce oluşturulan PPTX'i kullandık. Ardından bu nesneyi bir [IOleObjectFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ioleobjectframe/) olarak *cast* ettik. Bu, erişilmek istenen OLE nesne çerçevesiydi.  
4. OLE nesne çerçevesine erişildikten sonra, üzerinde herhangi bir işlem yapabilirsiniz.  

Aşağıdaki örnekte, bir OLE nesne çerçevesine (bir slayta gömülmüş Excel grafik nesnesi) ve dosya verilerine erişilir.

```java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // Gömülü dosya verilerini alın.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Gömülü dosyanın uzantısını alın.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Bağlantılı OLE Nesne Çerçevesi Özelliklerine Erişim**

Aspose.Slides, bağlantılı OLE nesne çerçevesi özelliklerine erişmenizi sağlar.

Bu Java kodu, bir OLE nesnesinin bağlı olup olmadığını kontrol etmeyi ve ardından bağlı dosyanın yolunu almayı gösterir:

```java
Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // OLE nesnesinin bağlı olup olmadığını kontrol edin.
    if (oleFrame.isObjectLink()) {
        // Bağlı dosyanın tam yolunu yazdır.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // Bağlı dosyanın mevcutsa göreceli yolunu yazdır.
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

Bu bölümde, aşağıdaki kod örneği [Aspose.Cells for Android via Java](/cells/androidjava/) kullanmaktadır.

{{% /alert %}}

Bir OLE nesnesi zaten bir slayta gömülmüşse, o nesneye kolayca erişebilir ve verilerini şu şekilde değiştirebilirsiniz:

1. Gömülü OLE nesnesi içeren bir sunumu, bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturarak yükleyin.  
2. İndeksini kullanarak slaytın referansını alın.  
3. OLE nesne çerçevesi şekline erişin. Örneğimizde, ilk slaytta bir şekil bulunan daha önce oluşturulan PPTX'i kullandık. Ardından bu nesneyi bir [IOleObjectFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ioleobjectframe/) olarak *cast* ettik. Bu, erişilmek istenen OLE nesne çerçevesiydi.  
4. OLE nesne çerçevesine erişildikten sonra, üzerinde herhangi bir işlem yapabilirsiniz.  
5. Bir `Workbook` nesnesi oluşturun ve OLE verilerine erişin.  
6. İstediğiniz `Worksheet`'e erişin ve verileri değiştirin.  
7. Güncellenmiş `Workbook`'u bir akışta kaydedin.  
8. Akıştan OLE nesne verilerini değiştirin.  

Aşağıdaki örnekte, bir OLE nesne çerçevesine (bir slayta gömülmüş Excel grafik nesnesi) erişilir ve dosya verileri, grafik verilerini güncellemek için değiştirilir.

```java 
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // OLE nesne verilerini bir Workbook nesnesi olarak okuyun.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Workbook verilerini değiştirin.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // OLE çerçeve nesnesinin verilerini değiştirin.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Slaytlara Diğer Dosya Türlerini Gömme**

Excel grafiklerine ek olarak, Aspose.Slides for Android via Java slaytlara başka dosya türlerini de gömmenize olanak tanır. Örneğin, HTML, PDF ve ZIP dosyalarını nesne olarak ekleyebilirsiniz. Kullanıcı eklenen nesneye çift tıkladığında, otomatik olarak ilgili programda açılır veya kullanıcı uygun bir program seçmesi için yönlendirilir.

Bu Java kodu, bir slayta HTML ve ZIP dosyalarını nasıl gömeceğinizi gösterir:

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

File fileHtml = new File("sample.html");
byte htmlData[] = new byte[(int) fileHtml.length()];
BufferedInputStream bisHtml = new BufferedInputStream(new FileInputStream(fileHtml));
DataInputStream disHtml = new DataInputStream(bisHtml);
disHtml.readFully(htmlData);
IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
IOleObjectFrame htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

File fileZip = new File("sample.zip");
byte zipData[] = new byte[(int) fileZip.length()];
BufferedInputStream bisZip = new BufferedInputStream(new FileInputStream(fileZip));
DataInputStream disZip = new DataInputStream(bisZip);
disZip.readFully(zipData);
IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
IOleObjectFrame zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Gömülü Nesneler İçin Dosya Türlerini Belirleme**

Sunumlarla çalışırken, eski OLE nesnelerini yenileriyle değiştirmek veya desteklenmeyen bir OLE nesnesini desteklenen bir nesneyle değiştirmek isteyebilirsiniz. Aspose.Slides for Android via Java, bir gömülü nesne için dosya türünü ayarlamanıza izin verir; bu sayede OLE çerçeve verilerini veya uzantısını güncelleyebilirsiniz.

Bu Java kodu, gömülü bir OLE nesnesi için dosya türünü `zip` olarak nasıl ayarlayacağınızı gösterir:

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

## **Gömülü Nesneler İçin Simge Görüntülerini ve Başlıkları Ayarlama**

Bir OLE nesnesi gömüldükten sonra, otomatik olarak bir simge görüntüsünden oluşan bir önizleme eklenir. Bu önizleme, kullanıcıların OLE nesnesine erişmeden veya açmadan önce gördükleri şeydir. Önizlemede belirli bir görüntü ve metin kullanmak isterseniz, Aspose.Slides for Android via Java kullanarak simge görüntüsünü ve başlığı ayarlayabilirsiniz.

Bu Java kodu, gömülü bir nesne için simge görüntüsünü ve başlığı nasıl ayarlayacağınızı gösterir:

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Sunum kaynaklarına bir görüntü ekleyin.
File file = new File("image.png");
byte imageData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(imageData);
IPPImage oleImage = presentation.getImages().addImage(imageData);

// OLE önizleme için bir başlık ve görüntü ayarlayın.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **OLE Nesne Çerçevesinin Yeniden Boyutlandırılmasını ve Yeniden Konumlandırılmasını Önleme**

Bağlantılı bir OLE nesnesini bir sunum slaytına ekledikten sonra, PowerPoint'te sunumu açtığınızda bağlantıların güncellenmesi istenebilir. "Update Links" (Bağlantıları Güncelle) düğmesine tıklamak, PowerPoint bağlantılı OLE nesnesinden verileri güncellediği ve nesne önizlemesini yenilediği için OLE nesne çerçevesinin boyut ve konumunu değiştirebilir. PowerPoint'in nesnenin verilerini güncelleme istemini önlemek için, [IOleObjectFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ioleobjectframe/) arabiriminin `setUpdateAutomatic` yöntemini `false` olarak ayarlayın:

```java
oleFrame.setUpdateAutomatic(false);
```

## **Gömülü Dosyaları Çıkarma**

Aspose.Slides for Android via Java, slaytlara OLE nesneleri olarak gömülmüş dosyaları şu şekilde çıkarmanıza olanak tanır:

1. Çıkarmak istediğiniz OLE nesnelerini içeren bir [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Sunumdaki tüm şekillerde döngü yapın ve [OLEObjectFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/oleobjectframe) şekillerine erişin.  
3. OLE nesne çerçevelerinden gömülü dosyaların verilerine erişin ve bunları diske yazın.  

Bu Java kodu, bir slayta OLE nesneleri olarak gömülmüş dosyaların nasıl çıkarılacağını gösterir:

```java
Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);

for (int index = 0; index < slide.getShapes().size(); index++) {
    IShape shape = slide.getShapes().get_Item(index);

    if (shape instanceof IOleObjectFrame) {
        IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

        byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        FileOutputStream fos = new FileOutputStream(new File("OLE_object_" + index + fileExtension));
        fos.write(fileData);
        fos.close();
    }
}

presentation.dispose();
```

## **FAQ**

**OLE içeriği, slaytlar PDF/görüntülere dışa aktarılırken render edilir mi?**

Slaytta görülen şey render edilir—ikon/yerine geçen görüntü (önizleme). "Canlı" OLE içeriği render sırasında çalıştırılmaz. Gerekirse, dışa aktarılan PDF'de beklendiği gibi görünmesi için kendi önizleme görüntünüzü ayarlayın.

**Bir OLE nesnesini slaytta kilitlemek ve kullanıcıların PowerPoint'te nesneyi taşımasını/düzenlemesini engellemek nasıl yapılır?**

Şekli kilitleyin: Aspose.Slides, şekil düzeyinde kilitler sağlar. Bu şifreleme değildir, ancak kazara düzenlemeleri ve hareketleri etkili bir şekilde önler.

**Bağlantılı bir Excel nesnesi, sunumu açtığımda neden "atlıyor" veya boyutu değişiyor?**

PowerPoint, bağlantılı OLE'nin önizlemesini yenileyebilir. Stabil bir görünüm için, [Worksheet Resizing için Çalışan Çözüm](/slides/tr/androidjava/working-solution-for-worksheet-resizing/) uygulamalarını izleyin—çerçeveyi aralığa sığdırın ya da aralığı sabit bir çerçeveye ölçekleyin ve uygun bir yer tutucu görüntü ayarlayın.

**Bağlantılı OLE nesneleri için göreceli yollar PPTX formatında korunur mu?**

PPTX formatında "göreceli yol" bilgisi bulunmaz—yalnızca tam yol mevcuttur. Göreceli yollar, eski PPT formatında bulunur. Taşınabilirlik için güvenilir mutlak yollar/erişilebilir URI'lar veya gömme tercih edin.