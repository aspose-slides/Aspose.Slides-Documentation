---
title: Java Kullanarak Sunumlarda OLE Yönetimi
linktitle: OLE Yönetimi
type: docs
weight: 40
url: /tr/java/manage-ole/
keywords:
- OLE nesnesi
- Nesne Bağlantısı & Gömme
- OLE ekle
- OLE göm
- nesne ekle
- nesne göm
- dosya ekle
- dosya göm
- bağlanmış nesne
- bağlanmış dosya
- OLE değiştir
- OLE simgesi
- OLE başlığı
- OLE çıkar
- nesne çıkar
- dosya çıkar
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint ve OpenDocument dosyalarında OLE nesne yönetimini optimize edin. OLE içeriğini sorunsuz bir şekilde gömün, güncelleyin ve dışa aktarın."
---
## **Giriş**

{{% alert color="info" %}} 

OLE (Object Linking & Embedding), bir Microsoft teknolojisidir ve bir uygulamada oluşturulan veri ve nesnelerin bağlantı veya gömme yoluyla başka bir uygulamaya yerleştirilmesini sağlar. 

{{% /alert %}} 

MS Excel'de oluşturulan bir grafiği düşünün. Bu grafik daha sonra bir PowerPoint slaytına yerleştirilir. Bu Excel grafiği bir OLE nesnesi olarak kabul edilir. 

- Bir OLE nesnesi bir simge olarak görünebilir. Bu durumda, simgeye çift tıkladığınızda grafik, ilişkili uygulamasında (Excel) açılır veya nesneyi açmak/düzenlemek için bir uygulama seçmeniz istenir. 
- Bir OLE nesnesi grafiğin içeriği gibi gerçek içeriğini gösterebilir. Bu durumda, grafik PowerPoint içinde etkinleşir, grafik arayüzü yüklenir ve grafik verilerini PowerPoint içinde değiştirebilirsiniz. 

[Aspose.Slides for Java](https://products.aspose.com/slides/tr/java/) slaytlara OLE nesnelerini OLE nesne çerçeveleri olarak ([OleObjectFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/OleObjectFrame)) eklemenize olanak tanır.

## **OLE Nesne Çerçevelerini Slaytlara Ekleme**

Microsoft Excel'de zaten bir grafik oluşturduğunuzu ve bunu Aspose.Slides for Java kullanarak bir OLE nesne çerçevesi olarak slayta gömmek istediğinizi varsayarsak, bunu şu şekilde yapabilirsiniz:

1. [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
1. Slaytın indeksini kullanarak bir referans alın.  
1. Excel dosyasını bayt dizisi olarak okuyun.  
1. Bayt dizisini ve OLE nesnesiyle ilgili diğer bilgileri içeren [OleObjectFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/OleObjectFrame)i slayta ekleyin.  
1. Değiştirilen sunumu PPTX dosyası olarak kaydedin.  

Aşağıdaki örnekte, bir Excel dosyasından alınan grafiği Aspose.Slides for Java kullanarak bir OLE nesne çerçevesi olarak slayta ekledik.  
**Not** ki [OleEmbeddedDataInfo](https://reference.aspose.com/slides/tr/java/com.aspose.slides/OleEmbeddedDataInfo) yapıcı, ikinci parametre olarak gömülebilir nesne uzantısını alır. Bu uzantı, PowerPoint'in dosya türünü doğru şekilde yorumlamasını ve bu OLE nesnesini açmak için uygun uygulamayı seçmesini sağlar.

``` java 
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Bağlantılı OLE Nesne Çerçeveleri Ekleme**

Aspose.Slides for Java, veri gömmeden yalnızca dosyaya bir bağlantı ile bir [OleObjectFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/OleObjectFrame) eklemenize olanak tanır.

Bu Java kodu, bir Excel dosyasına bağlantılı bir [OleObjectFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/OleObjectFrame) eklemenin yolunu gösterir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Bağlantılı bir Excel dosyasıyla OLE nesne çerçevesi ekle.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **OLE Nesne Çerçevelerine Erişim**

Bir OLE nesnesi zaten bir slayta gömülmüşse, ona şu şekilde kolayca erişebilir veya bulabilirsiniz:

1. Gömülü OLE nesnesi içeren bir sunumu, [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturarak yükleyin.  
2. Slaytın indeksini kullanarak referansını alın.  
3. [OleObjectFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/OleObjectFrame) şekline erişin. Örneğimizde, ilk slaytta yalnızca bir şekil bulunan daha önce oluşturulmuş PPTX dosyasını kullandık. Ardından bu nesneyi bir [IOleObjectFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IOleObjectFrame) olarak *cast* ettik. Bu, erişilmek istenen OLE nesne çerçevesiydi.  
4. OLE nesne çerçevesine erişildikten sonra, üzerinde istediğiniz herhangi bir işlemi gerçekleştirebilirsiniz.  

Aşağıdaki örnekte, bir OLE nesne çerçevesi (slayta gömülü bir Excel grafik nesnesi) ve dosya verileri erişilmektedir.

``` java 
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // Gömülü dosya verisini al.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Gömülü dosyanın uzantısını al.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Bağlantılı OLE Nesne Çerçevesi Özelliklerine Erişim**

Aspose.Slides, bağlantılı OLE nesne çerçevesi özelliklerine erişmenizi sağlar.

Bu Java kodu, bir OLE nesnesinin bağlantılı olup olmadığını kontrol edip bağlantılı dosyanın yolunu almanın yolunu gösterir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // OLE nesnesinin bağlantılı olup olmadığını kontrol et.
    if (oleFrame.isObjectLink()) {
        // Bağlantılı dosyanın tam yolunu yazdır.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // Bağlantılı dosyanın göreceli yolunu varsa yazdır.
        // Yalnızca PPT sunumları göreceli yolu içerebilir.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **OLE Nesne Verisini Değiştirme**

{{% alert color="info" %}} 

Bu bölümde, aşağıdaki kod örneği [Aspose.Cells for Java](/cells/java/) kullanmaktadır. 

{{% /alert %}}

Bir OLE nesnesi zaten bir slayta gömülmüşse, o nesneye kolayca erişip verisini şu şekilde değiştirebilirsiniz:

1. Gömülü OLE nesnesi içeren bir sunumu, [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturarak yükleyin.  
2. Slaytın indeksini kullanarak referansını alın.  
3. OLE nesne çerçevesi şekline erişin. Örneğimizde, ilk slaytta bir şekil bulunan daha önce oluşturulmuş PPTX dosyasını kullandık. Ardından bu nesneyi bir [IOleObjectFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/IOleObjectFrame) olarak *cast* ettik. Bu, erişilmek istenen OLE nesne çerçevesiydi.  
4. OLE nesne çerçevesine erişildikten sonra, üzerinde istediğiniz herhangi bir işlemi gerçekleştirebilirsiniz.  
5. Bir `Workbook` nesnesi oluşturun ve OLE verisine erişin.  
6. İstenen `Worksheet`i erişin ve veriyi düzenleyin.  
7. Güncellenen `Workbook`i bir akışa (stream) kaydedin.  
8. OLE nesne verisini akıştan değiştirin.  

Aşağıdaki örnekte, bir OLE nesne çerçevesi (slayta gömülü bir Excel grafik nesnesi) erişilmiş ve dosya verileri değiştirilerek grafik verileri güncellenmiştir.

``` java 
import com.aspose.slides.*;
import com.aspose.cells.Workbook;
import com.aspose.cells.OoxmlSaveOptions;
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // OLE nesne verisini Workbook nesnesi olarak oku.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Workbook verisini değiştir.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // OLE çerçeve nesnesi verisini değiştir.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Diğer Dosya Türlerini Slaytlara Gömme**

Excel grafiklerinin yanı sıra, Aspose.Slides for Java slaytlara başka dosya türlerini de gömmeyi sağlar. Örneğin, HTML, PDF ve ZIP dosyalarını nesne olarak ekleyebilirsiniz. Kullanıcı eklenen nesneye çift tıkladığında, ilgili program otomatik olarak açılır veya kullanıcıdan bu dosyayı açmak için uygun bir program seçmesi istenir.

Bu Java kodu, bir slayta HTML ve ZIP dosyalarını gömmenin yolunu gösterir:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

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

## **Gömülü Nesneler İçin Dosya Türlerini Ayarlama**

Sunumlarla çalışırken eski OLE nesnelerini yenileriyle değiştirmek veya desteklenmeyen bir OLE nesnesini desteklenen bir nesneyle değiştirmek isteyebilirsiniz. Aspose.Slides for Java, gömülü bir nesne için dosya türünü ayarlamanıza olanak tanır; bu sayede OLE çerçeve verisini veya uzantısını güncelleyebilirsiniz.

Bu Java kodu, gömülü bir OLE nesnesinin dosya türünü `zip` olarak ayarlamanın yolunu gösterir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// Dosya türünü ZIP olarak değiştir.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Gömülü Nesneler İçin Simge Görüntüleri ve Başlıklar Ayarlama**

Bir OLE nesnesi gömüldükten sonra, otomatik olarak bir simge görüntüsü önizlemesi eklenir. Bu önizleme, kullanıcıların OLE nesnesine erişmeden veya açmadan önce gördükleri şeydir. Önizlemede belirli bir görüntü ve metin kullanmak isterseniz, Aspose.Slides for Java ile simge görüntüsü ve başlığı ayarlayabilirsiniz.

Bu Java kodu, gömülü bir nesne için simge görüntüsü ve başlığı ayarlamanın yolunu gösterir:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Sunum kaynaklarına bir resim ekle.
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// OLE önizlemesi için bir başlık ve resmi ayarla.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **OLE Nesne Çerçevesinin Yeniden Boyutlandırılmasını ve Yeniden Konumlandırılmasını Önleme**

Bağlantılı bir OLE nesnesini bir sunum slaytına ekledikten sonra, PowerPoint'te sunumu açtığınızda bağlantıların güncellenmesini isteyen bir mesaj görebilirsiniz. "Bağlantıları Güncelle" düğmesine tıklamak, PowerPoint'in bağlantılı OLE nesnesinden verileri güncellemesi ve nesne önizlemesini yenilemesi nedeniyle OLE nesne çerçevesinin boyutunu ve konumunu değiştirebilir. PowerPoint'in nesnenin verilerini güncelleme istemesini önlemek için, [IOleObjectFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ioleobjectframe/) arayüzünün `setUpdateAutomatic` metodunu `false` olarak ayarlayın:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Gömülü Dosyaları Çıkarma**

Aspose.Slides for Java, slaytlara OLE nesneleri olarak gömülmüş dosyaları şu şekilde çıkarabilir:

1. Çıkarmak istediğiniz OLE nesnelerini içeren bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/Presentation) sınıfının örneğini oluşturun.  
2. Sunumdaki tüm şekilleri döngüye alarak [OLEObjectFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/oleobjectframe) şekillerine erişin.  
3. OLE nesne çerçevelerindeki gömülü dosya verilerine erişin ve diske yazın.  

Bu Java kodu, bir slayta OLE nesneleri olarak gömülmüş dosyaları çıkarmanın yolunu gösterir:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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

### Slaytları PDF/görsellere dışa aktarırken OLE içeriği render edilecek mi?

Slaytta görülen şey render edilir—ikon/ikame görüntüsü (önizleme). "Canlı" OLE içeriği render sırasında çalıştırılmaz. Gerekirse, dışa aktarılan PDF'de beklenen görünümü sağlamak için kendi önizleme görüntünüzü ayarlayın.

### Bir OLE nesnesini slaytta kilitleyerek kullanıcıların PowerPoint'te hareket ettirmesini/düzenlemesini nasıl engelleyebilirim?

Şekli kilitleyin: Aspose.Slides, [şekil düzeyi kilitlemeler](/slides/tr/java/applying-protection-to-presentation/) sağlar. Bu şifreleme değildir, ancak kazara düzenleme ve hareketi etkili bir şekilde önler.

### Bağlantılı bir Excel nesnesi sunumu açtığımda “atlıyor” ya da boyutu değişiyor, neden?

PowerPoint, bağlantılı OLE'nin önizlemesini yenileyebilir. Stabil bir görünüm için, [Çalışma Sayfası Yeniden Boyutlandırma için Çözüm](/slides/tr/java/working-solution-for-worksheet-resizing/) uygulamalarını izleyin—ya çerçeveyi aralığa göre ayarlayın ya da aralığı sabit bir çerçeveye ölçeklendirin ve uygun bir ikame görüntüsü belirleyin.

### Bağlantılı OLE nesneleri için göreceli yollar PPTX formatında korunur mu?

PPTX formatında “göreceli yol” bilgisi bulunmaz—yalnızca tam yol bulunur. Göreceli yollar eski PPT formatında mevcuttur. Taşınabilirlik için güvenilir mutlak yollar/erişilebilir URI’lar veya gömme tercih edin.