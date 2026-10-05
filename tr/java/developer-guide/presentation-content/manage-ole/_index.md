---
title: Java ile Sunumlarda OLE Yönetimi
linktitle: OLE Yönetimi
type: docs
weight: 40
url: /tr/java/manage-ole/
keywords:
- OLE nesnesi
- Nesne Bağlama ve Gömme
- OLE ekle
- OLE göm
- nesne ekle
- nesne göm
- dosya ekle
- dosya göm
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PowerPoint ve OpenDocument dosyalarında OLE nesnesi yönetimini optimize edin. OLE içeriğini sorunsuz bir şekilde gömün, güncelleyin ve dışa aktarın."
---
## **Giriş**

{{% alert color="info" title="Note" %}}
OLE (Object Linking & Embedding), bir Microsoft teknolojisidir ve bir uygulamada oluşturulan veri ve nesnelerin, başka bir uygulamaya bağlama veya gömme yoluyla yerleştirilmesine olanak tanır. 
{{% /alert %}} 

MS Excel'de oluşturulan bir grafik düşünün. Grafik daha sonra bir PowerPoint slaytına yerleştirilir. Bu Excel grafiği bir OLE nesnesi olarak kabul edilir. 

- Bir OLE nesnesi bir simge olarak görünebilir. Bu durumda, simgeye çift tıkladığınızda grafik ilişkili uygulamasında (Excel) açılır veya nesneyi açmak/düzenlemek için bir uygulama seçmeniz istenir. 
- Bir OLE nesnesi, bir grafiğin içeriği gibi gerçek içeriğini gösterebilir. Bu durumda, grafik PowerPoint içinde etkinleştirilir, grafik arayüzü yüklenir ve PowerPoint içinde grafiğin verilerini değiştirebilirsiniz. 

[Aspose.Slides for Java](https://products.aspose.com/slides/java/) OLE Nesnelerini slaytlara OLE nesne çerçeveleri ([OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)) olarak eklemenizi sağlar. 

## **Slaytlara OLE Nesne Çerçeveleri Ekleme**

Microsoft Excel'de zaten bir grafik oluşturduğunuzu ve bunu Aspose.Slides for Java kullanarak bir slayta OLE nesne çerçevesi olarak gömmek istediğinizi varsayalım, bunu aşağıdaki şekilde yapabilirsiniz:

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun. 
1. İndeksini kullanarak bir slaydın referansını alın. 
1. Excel dosyasını bir bayt dizisi olarak okuyun. 
1. [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) nesnesini, bayt dizisini ve OLE nesnesiyle ilgili diğer bilgileri içerecek şekilde slayta ekleyin. 
1. Değiştirilmiş sunumu bir PPTX dosyası olarak yazın. 

Aşağıdaki örnekte, bir Excel dosyasından bir grafiği Aspose.Slides for Java kullanarak OLE nesne çerçevesi olarak bir slayta ekledik. **Not** [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/OleEmbeddedDataInfo) yapıcı metodunun ikinci parametre olarak gömülebilir nesne uzantısı aldığını unutmayın. Bu uzantı, PowerPoint'in dosya türünü doğru yorumlamasını ve bu OLE nesnesini açmak için doğru uygulamayı seçmesini sağlar. 

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

Aspose.Slides for Java, verileri gömmeden yalnızca dosyaya bir bağlantı ile bir [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) eklemenize olanak tanır. 

Bu Java kodu, bağlantılı bir Excel dosyası ile bir [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) ekleyerek slayta nasıl ekleyeceğinizi gösterir: 

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

Eğer bir OLE nesnesi zaten bir slayta gömülmüşse, onu aşağıdaki şekilde kolayca bulabilir veya erişebilirsiniz:

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturarak gömülü OLE nesnesine sahip bir sunumu yükleyin. 
2. İndeksini kullanarak slaydın referansını alın. 
3. [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) şekline erişin. Örneğimizde, ilk slaytta yalnızca bir şekil bulunan daha önce oluşturulmuş PPTX'i kullandık. Ardından bu nesneyi bir [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame) olarak *cast* ettik. Bu, erişilmek istenen OLE nesne çerçevesiydi. 
4. OLE nesne çerçevesine erişildikten sonra, üzerinde istediğiniz herhangi bir işlemi gerçekleştirebilirsiniz. 

Aşağıdaki örnekte, bir OLE nesne çerçevesine (bir slayta gömülmüş Excel grafik nesnesi) ve dosya verisine erişilir. 

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

Bu Java kodu, bir OLE nesnesinin bağlantılı olup olmadığını kontrol etmeyi ve ardından bağlantılı dosyanın yolunu almayı gösterir: 

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

        // Var ise, bağlantılı dosyanın göreli yolunu yazdır.
        // Yalnızca PPT sunumları göreli yolu içerebilir.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **OLE Nesne Verisini Değiştirme**

{{% alert color="info" title="Note" %}}
Bu bölümde, aşağıdaki kod örneği [Aspose.Cells for Java](https://docs.aspose.com/cells/java/) kullanmaktadır. 
{{% /alert %}}

Eğer bir OLE nesnesi zaten bir slayta gömülmüşse, onu aşağıdaki şekilde kolayca erişebilir ve verisini değiştirebilirsiniz:

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturarak gömülü OLE nesnesine sahip bir sunumu yükleyin. 
2. İndeksini kullanarak slaydın referansını alın. 
3. OLE nesne çerçevesi şekline erişin. Örneğimizde, ilk slaytta bir şekil bulunan daha önce oluşturulmuş PPTX'i kullandık. Ardından bu nesneyi bir [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame) olarak *cast* ettik. Bu, erişilmek istenen OLE nesne çerçevesiydi. 
4. OLE nesne çerçevesine erişildikten sonra, üzerinde istediğiniz herhangi bir işlemi gerçekleştirebilirsiniz. 
5. `Workbook` nesnesi oluşturun ve OLE verisine erişin. 
6. İstediğiniz `Worksheet`'a erişin ve veriyi düzenleyin. 
7. Güncellenmiş `Workbook`'ı bir akışta kaydedin. 
8. Akıştan OLE nesne verisini değiştirin. 

Aşağıdaki örnekte, bir OLE nesne çerçevesine (slayta gömülmüş bir Excel grafik nesnesi) erişilir ve dosya verileri grafik verilerini güncellemek için değiştirilir. 

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

    // OLE nesnesi verisini Workbook nesnesi olarak okuyun.
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

Excel grafiklerinin yanı sıra, Aspose.Slides for Java başka dosya türlerini de slaytlara gömebilir. Örneğin, HTML, PDF ve ZIP dosyalarını nesne olarak ekleyebilirsiniz. Kullanıcı eklenen nesneye çift tıkladığında, otomatik olarak ilgili programda açılır veya kullanıcı uygun bir program seçmesi için yönlendirilir. 

Bu Java kodu, HTML ve ZIP'i bir slayta nasıl gömeceğinizi gösterir: 

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

## **Gömülü Nesneler İçin Dosya Türlerini Belirleme**

Sunumlarla çalışırken eski OLE nesnelerini yenileriyle değiştirmek ya da desteklenmeyen bir OLE nesnesini desteklenen bir nesneyle değiştirmek isteyebilirsiniz. Aspose.Slides for Java, gömülü bir nesne için dosya türünü ayarlamanıza olanak tanır; bu sayede OLE çerçeve verisini veya uzantısını güncelleyebilirsiniz. 

Bu Java kodu, gömülü bir OLE nesnesinin dosya türünü `zip` olarak nasıl ayarlayacağınızı gösterir: 

```java
import com.aspose.slides.*;

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

## **Gömülü Nesneler İçin Simge Görüntüleri ve Başlıkları Ayarlama**

Bir OLE nesnesi gömüldükten sonra, simge görüntüsünden oluşan bir önizleme otomatik olarak eklenir. Bu önizleme, kullanıcıların OLE nesnesine erişmeden veya açmadan önce gördükleri şeydir. Önizlemede belirli bir görüntü ve metin kullanmak isterseniz, Aspose.Slides for Java kullanarak simge görüntüsünü ve başlığı ayarlayabilirsiniz. 

Bu Java kodu, gömülü bir nesne için simge görüntüsü ve başlığı nasıl ayarlayacağınızı gösterir: 

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Sunuma bir resim ekle.
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Bir OLE Nesne Çerçevesinin Yeniden Boyutlandırılmasını ve Yeniden Konumlandırılmasını Önleme**

Bağlantılı bir OLE nesnesini bir sunum slaytına ekledikten sonra, sunumu PowerPoint'te açtığınızda bağlantıları güncellemeniz istenen bir mesaj görebilirsiniz. "Update Links" düğmesini tıklamak, PowerPoint bağlantılı OLE nesnesinden verileri güncellediği ve nesne önizlemesini yenilediği için OLE nesne çerçevesinin boyutunu ve konumunu değiştirebilir. PowerPoint'in nesnenin verilerini güncelleme sorusunu sormasını önlemek için, [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/) arabiriminin [setUpdateAutomatic](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#setUpdateAutomatic-boolean-) metodunu `false` ile çağırın: 

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

Aspose.Slides for Java, slaytlara OLE nesnesi olarak gömülmüş dosyaları aşağıdaki şekilde çıkarabilmenizi sağlar: 

1. [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun; bu sınıf çıkaracağınız OLE nesnelerini içerir. 
2. Sunumdaki tüm şekillerde döngü yapın ve [OLEObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe) şekillerine erişin. 
3. OLE nesne çerçevelerindeki gömülü dosya verilerine erişin ve diske yazın. 

Bu Java kodu, bir slayta OLE nesnesi olarak gömülmüş dosyaları nasıl çıkaracağınızı gösterir: 

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

## **FAQ**

**Slaytlar PDF/görsellere dışa aktarılırken OLE içeriği işlenecek mi?**

Slaytta görünen şey render edilir—ikon/değiştirme resmi (önizleme). "Canlı" OLE içeriği render sırasında çalıştırılmaz. Gerekirse, dışa aktarılan PDF'de beklenen görünümü sağlamak için kendi önizleme resminizi ayarlayın.  

Gömülü dosyayı bir PDF eki olarak da korumak için, [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) metodunu `true` ile çağırın. Bu seçenek varsayılan olarak devre dışıdır. Bir örnek ve eki kontrol etme talimatları için, [Preserve Embedded OLE Files as PDF Attachments](/slides/tr/java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments) bölümüne bakın.  

**Bir OLE nesnesini bir slaytta nasıl kilitlerim ki kullanıcılar PowerPoint'te taşıyamaz veya düzenleyemez?**

Şekli kilitleyin: Aspose.Slides, [shape-level locks](/slides/tr/java/applying-protection-to-presentation/) sağlar. Bu şifreleme değildir, ancak yanlışlıkla düzenlemeleri ve hareketi etkili bir şekilde önler.  

**Bağlantılı bir Excel nesnesi, sunumu açtığımda neden "zıplıyor" ya da boyutu değişiyor?**

PowerPoint, bağlantılı OLE'nin önizlemesini yenileyebilir. Stabil bir görünüm için, [Working Solution for Worksheet Resizing](/slides/tr/java/working-solution-for-worksheet-resizing/) uygulamalarını izleyin—ya çerçeveyi aralığa uydurun, ya da aralığı sabit bir çerçeveye ölçekleyin ve uygun bir yerine koyma resmi ayarlayın.  

**Bağlantılı OLE nesneleri için göreli yollar PPTX formatında korunacak mı?**

PPTX formatında "göreli yol" bilgisi bulunmaz—yalnızca tam yol vardır. Göreli yollar eski PPT formatında bulunur. Taşınabilirlik için güvenilir tam yollar/erişilebilir URI'lar veya gömme tercih edin.