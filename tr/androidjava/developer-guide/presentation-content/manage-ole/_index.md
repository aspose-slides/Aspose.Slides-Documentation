---
title: Android'de Sunumlarda OLE'yi Yönetme
linktitle: OLE'yi Yönet
type: docs
weight: 40
url: /tr/androidjava/manage-ole/
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
- nesneyi çıkar
- dosyayı çıkar
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile PowerPoint ve OpenDocument dosyalarında OLE nesne yönetimini optimize edin. OLE içeriğini sorunsuz bir şekilde gömün, güncelleyin ve dışa aktarın."
---
## **Giriş**

{{% alert color="info" %}} 
OLE (Object Linking & Embedding), bir Microsoft teknolojisi olup, bir uygulamada oluşturulan veri ve nesnelerin bağlantı veya gömme yoluyla başka bir uygulamaya yerleştirilmesini sağlar. 
{{% /alert %}} 

MS Excel'de oluşturulan bir grafiği düşünün. Bu grafik daha sonra bir PowerPoint slaytına yerleştirilir. Bu Excel grafiği bir OLE nesnesi olarak kabul edilir. 

- Bir OLE nesnesi bir simge olarak görünebilir. Bu durumda, simgeye çift tıkladığınızda grafik ilişkili uygulamasında (Excel) açılır veya nesneyi açmak veya düzenlemek için bir uygulama seçmeniz istenir. 
- Bir OLE nesnesi, bir grafiğin içeriği gibi gerçek içeriğini gösterebilir. Bu durumda, grafik PowerPoint'te etkinleşir, grafik arayüzü yüklenir ve grafik verilerini PowerPoint içinde değiştirirsiniz. 

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/tr/androidjava/) kaydırılara OLE Nesnelerini OLE nesne çerçeveleri ([OleObjectFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/OleObjectFrame)) olarak eklemenizi sağlar. 

## **Kaydırılara OLE Nesne Çerçeveleri Ekleme**

Microsoft Excel'de zaten bir grafik oluşturduğunuzu ve bunu Aspose.Slides for Android via Java kullanarak bir kaydıraya OLE nesne çerçevesi olarak gömmek istediğinizi varsayalım, bunu şu şekilde yapabilirsiniz:

1. [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfından bir örnek oluşturun.
1. Slaytın referansını indeksine göre alın.
1. Excel dosyasını bir byte dizisi olarak okuyun.
1. [OleObjectFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/OleObjectFrame) nesnesini, byte dizisini ve OLE nesnesiyle ilgili diğer bilgileri içerecek şekilde slayta ekleyin.
1. Değiştirilmiş sunumu PPTX dosyası olarak kaydedin.

Aşağıdaki örnekte, bir Excel dosyasından bir grafiği Aspose.Slides for Android via Java kullanarak bir kaydıraya OLE nesne çerçevesi olarak ekledik. **Not**: [OleEmbeddedDataInfo](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/OleEmbeddedDataInfo) yapıcı, ikinci parametre olarak gömülebilir nesne uzantısını alır. Bu uzantı, PowerPoint'in dosya türünü doğru şekilde yorumlamasını ve bu OLE nesnesini açmak için doğru uygulamayı seçmesini sağlar.

```java 
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// OLE nesnesi için veriyi hazırlayın.
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Bağlantılı OLE Nesne Çerçeveleri Ekleme**

Aspose.Slides for Android via Java, veri gömmeden yalnızca dosyaya bir bağlantı ile bir [OleObjectFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/OleObjectFrame) eklemenizi sağlar.

Bu Java kodu, bir bağlantılı Excel dosyasıyla bir [OleObjectFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/OleObjectFrame) kaydıraya nasıl ekleyeceğinizi gösterir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Bağlantılı bir Excel dosyasıyla OLE nesne çerçevesi ekleyin.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **OLE Nesne Çerçevelerine Erişim**

Bir OLE nesnesi zaten bir kaydıraya gömülmüşse, onu bu şekilde kolayca bulabilir veya erişebilirsiniz:

1. Gömülü OLE nesnesine sahip bir sunumu, [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfından bir örnek oluşturarak yükleyin.
2. Slaytın referansını indeksini kullanarak alın.
3. [OleObjectFrame] şekline erişin. Örnekte, yalnızca bir şekli olan ilk slayttaki önceden oluşturulmuş PPTX'i kullandık. Daha sonra bu nesneyi bir [IOleObjectFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ioleobjectframe/) olarak *cast* ettik. Bu, erişilmek istenen OLE nesne çerçevesiydi.
4. OLE nesne çerçevesine erişildikten sonra, üzerinde istediğiniz herhangi bir işlemi gerçekleştirebilirsiniz.

Aşağıdaki örnekte, bir OLE nesne çerçevesi (kaydıraya gömülmüş bir Excel grafik nesnesi) ve dosya verileri erişilmektedir.

```java 
import com.aspose.slides.*;

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

Bu Java kodu, bir OLE nesnesinin bağlantılı olup olmadığını kontrol etmeyi ve ardından bağlantılı dosyanın yolunu elde etmeyi gösterir:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // OLE nesnesinin bağlantılı olup olmadığını kontrol edin.
    if (oleFrame.isObjectLink()) {
        // Bağlantılı dosyanın tam yolunu yazdır.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // Mevcutsa bağlantılı dosyanın göreli yolunu yazdır.
        // Yalnızca PPT sunumları göreli yolu içerebilir.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **OLE Nesne Verisini Değiştirme**

{{% alert color="info" %}} 
Bu bölümde, aşağıdaki kod örneği [Aspose.Cells for Android via Java](/cells/androidjava/) kullanır. 
{{% /alert %}}

Bir OLE nesnesi zaten bir kaydıraya gömülmüşse, bu nesneye kolayca erişebilir ve verisini şu şekilde değiştirebilirsiniz:

1. Gömülü OLE nesnesine sahip bir sunumu, [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfından bir örnek oluşturarak yükleyin.
2. Slaytın referansını indeksini kullanarak alın.
3. OLE nesne çerçevesi şekline erişin. Örnekte, ilk slaytta bir şekli olan önceden oluşturulmuş PPTX'i kullandık. Daha sonra bu nesneyi bir [IOleObjectFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ioleobjectframe/) olarak *cast* ettik. Bu, erişilmek istenen OLE nesne çerçevesiydi.
4. OLE nesne çerçevesine erişildikten sonra, üzerinde istediğiniz herhangi bir işlemi gerçekleştirebilirsiniz.
5. Bir `Workbook` nesnesi oluşturun ve OLE verisine erişin.
6. İstenen `Worksheet` nesnesine erişin ve veriyi değiştirin.
7. Güncellenmiş `Workbook`'u bir akışta kaydedin.
8. Akıştan OLE nesne verisini değiştirin.

Aşağıdaki örnekte, bir OLE nesne çerçevesine (kaydıraya gömülmüş bir Excel grafik nesnesi) erişilir ve dosya verileri grafik verilerini güncellemek için değiştirilir.

```java 
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

    // OLE çerçeve nesnesinin verisini değiştirin.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Kaydırılara Diğer Dosya Türlerini Gömme**

Excel grafiklerinin yanı sıra, Aspose.Slides for Android via Java, kaydırılara HTML, PDF ve ZIP dosyaları gibi diğer dosya türlerini nesne olarak gömmenizi sağlar. Kullanıcı eklenmiş nesneye çift tıkladığında, ilgili program otomatik olarak açılır veya kullanıcı nesneyi açmak için uygun bir program seçmesi istenir.

Bu Java kodu, HTML ve ZIP dosyalarını bir kaydıraya nasıl gömeceğinizi gösterir:

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

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

## **Gömülü Nesneler İçin Dosya Türlerini Ayarlama**

Sunumlarla çalışırken, eski OLE nesnelerini yeniyle değiştirmek veya desteklenmeyen bir OLE nesnesini desteklenen bir nesneyle değiştirmek isteyebilirsiniz. Aspose.Slides for Android via Java, gömülü bir nesnenin dosya türünü ayarlamanıza olanak tanır; böylece OLE çerçeve verilerini veya uzantısını güncelleyebilirsiniz.

Bu Java kodu, gömülü bir OLE nesnesi için dosya türünü `zip` olarak ayarlamayı gösterir:

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

## **Gömülü Nesneler İçin Simge Görüntüleri ve Başlıkları Ayarlama**

Bir OLE nesnesi gömüldükten sonra, otomatik olarak bir simge görüntüsü içeren bir önizleme eklenir. Bu önizleme, kullanıcıların OLE nesnesine erişmeden veya açmadan önce gördükleri şeydir. Belirli bir görüntü ve metni önizleme öğeleri olarak kullanmak isterseniz, Aspose.Slides for Android via Java kullanarak simge görüntüsü ve başlığı ayarlayabilirsiniz.

Bu Java kodu, gömülü bir nesne için simge görüntüsü ve başlığı nasıl ayarlayacağınızı gösterir:

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Sunum kaynaklarına bir resim ekleyin.
File file = new File("image.png");
byte imageData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(imageData);
IPPImage oleImage = presentation.getImages().addImage(imageData);

// OLE önizlemesi için başlık ve resmi ayarlayın.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **OLE Nesne Çerçevesinin Yeniden Boyutlandırılmasını ve Yeniden Konumlandırılmasını Önleme**

Bağlantılı bir OLE nesnesini bir sunum slaytına ekledikten sonra, PowerPoint'te sunumu açtığınızda, bağlantıları güncellemenizi isteyen bir mesaj görebilirsiniz. "Update Links" düğmesine tıklamak, PowerPoint'in bağlantılı OLE nesnesinden verileri güncellemesi ve nesne önizlemesini yenilemesi nedeniyle OLE nesne çerçevesinin boyut ve konumunu değiştirebilir. PowerPoint'in nesne verilerini güncelleme istemesini önlemek için, [IOleObjectFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/ioleobjectframe/) arayüzünün `setUpdateAutomatic` metodunu `false` olarak ayarlayın:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    oleFrame.setUpdateAutomatic(false);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Gömülü Dosyaları Çıkarma**

Aspose.Slides for Android via Java, bir kaydırada OLE nesneleri olarak gömülmüş dosyaları şu şekilde çıkarmanıza olanak tanır:

1. Çıkaracağınız OLE nesnelerini içeren [Presentation](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/Presentation) sınıfından bir örnek oluşturun.
2. Sunumdaki tüm şekiller arasında döngü yaparak [OLEObjectFrame] şekillerine erişin.
3. OLE nesne çerçevelerinden gömülü dosyaların verilerine erişin ve diske yazın.

Bu Java kodu, bir kaydırada OLE nesneleri olarak gömülü dosyaları nasıl çıkaracağınızı gösterir:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileOutputStream;

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

## **SSS**

### Kaydırılar PDF/görsellere dışa aktarılırken OLE içeriği işlenecek mi?

Kaydırıda görülen şey işlenir—simge/yer tutucu görüntüsü (önizleme). "Canlı" OLE içeriği render sırasında çalıştırılmaz. Gerekirse, dışa aktarılan PDF'de beklenen görünümü sağlamak için kendi önizleme görüntünüzü ayarlayın.

### Bir OLE nesnesini bir slaytta kilitleyerek kullanıcıların PowerPoint'te nesneyi hareket ettirmesini/düzenlemesini nasıl engelleyebilirim?

Şekli kilitleyin: Aspose.Slides şekil düzeyinde kilitler sağlar. Bu bir şifreleme değildir, ancak kazara düzenleme ve hareketi etkili bir şekilde önler.

### Bağlantılı bir Excel nesnesi, sunumu açtığımda neden "zıplıyor" ya da boyutu değişiyor?

PowerPoint, bağlantılı OLE'nin önizlemesini yenileyebilir. Stabil bir görünüm için, [Worksheet Resizing için Çözüm](/slides/tr/androidjava/working-solution-for-worksheet-resizing/) yönergelerini izleyin—ya çerçeveyi aralığa göre ayarlayın ya da aralığı sabit bir çerçeveye ölçekleyin ve uygun bir yer tutucu görsel ayarlayın.

### Bağlantılı OLE nesneleri için göreli yollar PPTX formatında korunacak mı?

PPTX'te "göreli yol" bilgisi bulunmaz—sadece tam yol vardır. Göreli yollar eski PPT formatında bulunur. Taşınabilirlik için güvenilir tam yollar/erişilebilir URI'ler veya gömmeyi tercih edin.