---
title: Android'de Sunumlarda OLE Yönetimi
linktitle: OLE Yönetimi
type: docs
weight: 40
url: /tr/androidjava/manage-ole/
keywords:
- OLE nesnesi
- Nesne Bağlantısı ve Gömme
- OLE ekle
- OLE göm
- nesne ekle
- nesne göm
- dosya ekle
- dosya göm
- bağlı nesne
- bağlı dosya
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

{{% alert color="info" title="Not" %}}

OLE (Object Linking & Embedding), bir Microsoft teknolojisidir ve bir uygulamada oluşturulan veri ve nesnelerin başka bir uygulamaya bağlama veya gömme yoluyla yerleştirilmesini sağlar. 

{{% /alert %}} 

MS Excel'de oluşturulan bir grafiği düşünün. Bu grafik daha sonra bir PowerPoint slaytına yerleştirilir. O Excel grafiği bir OLE nesnesi olarak kabul edilir. 

- Bir OLE nesnesi simge olarak görünebilir. Bu durumda, simgeye çift tıkladığınızda grafik ilişkili uygulamasında (Excel) açılır veya nesneyi açmak/düzenlemek için bir uygulama seçmeniz istenir.
- Bir OLE nesnesi gerçek içeriğini, örneğin bir grafiğin içeriğini, görüntüleyebilir. Bu durumda grafik PowerPoint içinde etkinleşir, grafik arayüzü yüklenir ve grafiğin verilerini PowerPoint içinde değiştirebilirsiniz.

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/androidjava/) allows you to insert OLE Objects into slides as OLE object frames ([OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame)).

## **Slaytlara OLE Nesne Çerçeveleri Ekle**

Microsoft Excel'de zaten bir grafik oluşturduğunuzu ve bunu Aspose.Slides for Android via Java kullanarak bir slayta OLE nesne çerçevesi olarak gömmek istediğinizi varsayalım, bunu şu şekilde yapabilirsiniz:

1. Bir [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
1. Bir slaydın referansını dizini aracılığıyla alın.  
1. Excel dosyasını bayt dizisi olarak okuyun.  
1. Bayt dizisini ve OLE nesnesiyle ilgili diğer bilgileri içerecek şekilde slayta [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) öğesini ekleyin.  
1. Değiştirilmiş sunumu PPTX dosyası olarak yazın.  

Aşağıdaki örnekte, bir Excel dosyasından bir grafiği Aspose.Slides for Android via Java kullanarak OLE nesne çerçevesi olarak bir slayta ekledik.  
**Not** that the [OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleEmbeddedDataInfo) constructor takes an embeddable object extension as a second parameter. This extension allows PowerPoint to correctly interpret the file type and choose the right application to open this OLE object.

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

// OLE nesnesi için verileri hazırlayın.
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// OLE nesne çerçevesini slayta ekleyin.
slide.getShapes().addOleObjectFrame(0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Bağlantılı OLE Nesne Çerçeveleri Ekle**

Aspose.Slides for Android via Java, verileri gömmeden sadece dosyaya bir bağlantı ile bir [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) eklemenize olanak tanır.

Bu Java kodu, bir slayta bağlantılı bir Excel dosyasıyla bir [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) eklemenizi gösterir:

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

Bir OLE nesnesi zaten bir slayta gömülmüşse, bunu aşağıdaki şekilde kolayca bulabilir veya erişebilirsiniz:

1. Gömülü OLE nesnesi içeren bir sunumu, bir [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturarak yükleyin.  
2. Dizini kullanarak slaydın referansını alın.  
3. [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) şekline erişin.  
   Örneğimizde, yalnızca ilk slaytta bir şekli olan önceden oluşturulmuş PPTX dosyasını kullandık. Ardından bu nesneyi bir [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) olarak *cast* ettik. Bu, erişilmek istenen OLE nesne çerçevesiydi.  
4. OLE nesne çerçevesine erişildikten sonra, üzerinde istediğiniz herhangi bir işlemi gerçekleştirebilirsiniz.  

Aşağıdaki örnekte, bir OLE nesne çerçevesi (bir slayta gömülmüş Excel grafik nesnesi) ve dosya verileri erişilmektedir.

```java 
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

Bu Java kodu, bir OLE nesnesinin bağlantılı olup olmadığını kontrol etmenizi ve ardından bağlantılı dosyanın yolunu almanızı gösterir:

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

        // Bağlantılı dosyanın göreceli yolunu varsa yazdır.
        // Yalnızca PPT sunumları göreceli yolu içerebilir.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **OLE Nesne Verisini Değiştir**

{{% alert color="info" title="Not" %}}

Bu bölümde, aşağıdaki kod örneği [Aspose.Cells for Android via Java](https://docs.aspose.com/cells/androidjava/) kullanmaktadır.

{{% /alert %}}

Bir OLE nesnesi zaten bir slayta gömülmüşse, bu nesneye kolayca erişebilir ve verisini aşağıdaki şekilde değiştirebilirsiniz:

1. Gömülü OLE nesnesi içeren bir sunumu, bir [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturarak yükleyin.  
2. Dizini kullanarak slaydın referansını alın.  
3. OLE nesne çerçevesi şekline erişin.  
   Örneğimizde, ilk slaytta bir şekli olan önceden oluşturulmuş PPTX dosyasını kullandık. Ardından bu nesneyi bir [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) olarak *cast* ettik. Bu, erişilmek istenen OLE nesne çerçevesiydi.  
4. OLE nesne çerçevesine erişildikten sonra, üzerinde istediğiniz herhangi bir işlemi gerçekleştirebilirsiniz.  
5. Bir `Workbook` nesnesi oluşturun ve OLE verisine erişin.  
6. İstenen `Worksheet` nesnesine erişin ve verileri düzenleyin.  
7. Güncellenmiş `Workbook` nesnesini bir akışa kaydedin.  
8. OLE nesne verisini akıştan değiştirin.  

Aşağıdaki örnekte, bir OLE nesne çerçevesi (bir slayta gömülmüş Excel grafik nesnesi) erişilir ve dosya verileri grafiğin verilerini güncellemek için değiştirilir.

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

    // OLE nesne verilerini Workbook nesnesi olarak okuyun.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Çalışma kitabı verilerini değiştir.
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

## **Slaytlara Diğer Dosya Türlerini Göm**

Excel grafiklerinin yanı sıra, Aspose.Slides for Android via Java, slaytlara HTML, PDF ve ZIP dosyaları gibi diğer dosya türlerini nesne olarak eklemenize olanak tanır. Kullanıcı eklenen nesneye çift tıkladığında, ilgili programda otomatik olarak açılır veya kullanıcı uygun bir program seçmek üzere uyarılır.

Bu Java kodu, bir slayta HTML ve ZIP dosyalarını nasıl gömeceğinizi gösterir:

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

## **Gömülü Nesneler İçin Dosya Türlerini Ayarla**

Sunumlarla çalışırken eski OLE nesnelerini yenileriyle değiştirmek veya desteklenmeyen bir OLE nesnesini desteklenen bir nesneyle değiştirmek isteyebilirsiniz. Aspose.Slides for Android via Java, gömülü bir nesne için dosya türünü ayarlamanıza izin verir; bu sayede OLE çerçeve verisini veya uzantısını güncelleyebilirsiniz.

Bu Java kodu, gömülü bir OLE nesnesi için dosya türünü `zip` olarak nasıl ayarlayacağınızı gösterir:

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

## **Gömülü Nesneler İçin Simge Görüntüleri ve Başlıkları Ayarla**

Bir OLE nesnesi gömüldükten sonra, otomatik olarak bir simge görüntüsü içeren bir ön izleme eklenir. Bu ön izleme, kullanıcıların OLE nesnesine erişmeden veya açmadan önce gördükleri şeydir. Ön izlemede belirli bir görüntü ve metin kullanmak istiyorsanız, Aspose.Slides for Android via Java ile simge görüntüsünü ve başlığı ayarlayabilirsiniz.

Bu Java kodu, gömülü bir nesne için simge görüntüsü ve başlığın nasıl ayarlanacağını gösterir:

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

// OLE ön izlemesi için bir başlık ve resim ayarlayın.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **OLE Nesne Çerçevesinin Yeniden Boyutlandırılmasını ve Yeniden Konumlandırılmasını Önle**

Bağlantılı bir OLE nesnesini bir sunum slaytına ekledikten sonra, PowerPoint'te sunumu açtığınızda bağlantıları güncellemeniz istenebilir. "Update Links" düğmesine tıklamak, PowerPoint bağlantılı OLE nesnesinden verileri güncellediği ve nesne ön izlemesini yenilediği için OLE nesne çerçevesinin boyutunu ve konumunu değiştirebilir. PowerPoint'in nesne verisini güncelleme istemini önlemek için, `false` ile [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) arayüzünün [setUpdateAutomatic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#setUpdateAutomatic-boolean-) metodunu çağırın:

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

## **Gömülü Dosyaları Çıkar**

Aspose.Slides for Android via Java, slaytlara OLE nesnesi olarak gömülmüş dosyaları aşağıdaki şekilde çıkarabilir:

1. Çıkarmak istediğiniz OLE nesnelerini içeren bir [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) sınıfının bir örneğini oluşturun.  
2. Sunumdaki tüm şekilleri döngüyle gezerek [OLEObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleobjectframe) şekillerine erişin.  
3. OLE nesne çerçevelerinden gömülü dosya verilerine erişin ve diske yazın.  

Bu Java kodu, bir slayta OLE nesnesi olarak gömülmüş dosyaları nasıl çıkaracağınızı gösterir:

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

**OLE içeriği PDF/görüntülere dışa aktarılırken işlenir mi?**

Slaytta görülen şey işlenir—ikon/yer tutucu resmi (ön izleme). "Canlı" OLE içeriği render sırasında çalıştırılmaz. Gerekirse, dışa aktarılan PDF'de istenen görünümü sağlamak için kendi ön izleme resminizi ayarlayın.

Gömülü dosyanın bir PDF eki olarak da korunmasını sağlamak için, `true` ile [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) metodunu çağırın. Bu seçenek varsayılan olarak devre dışıdır. Bir örnek ve ekin kontrol edilmesiyle ilgili talimatlar için [Gömülü OLE Dosyalarını PDF Ekleri Olarak Koru](/slides/tr/androidjava/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments) bölümüne bakın.

**Bir OLE nesnesini slaytta kilitleyerek kullanıcıların PowerPoint'te nesneyi taşımasını/düzenlemesini nasıl engelleyebilirim?**

Şekli kilitleyin: Aspose.Slides şekil seviyesinde kilitleme sağlar. Bu şifreleme değildir, ancak yanlışlıkla düzenleme ve taşıma işlemlerini etkili bir şekilde önler.

**Bağlantılı bir Excel nesnesi sunumu açtığımda neden "atlıyor" ya da boyutu değişiyor?**

PowerPoint, bağlantılı OLE'nin ön izlemesini yenileyebilir. Stabil bir görünüm için, [Çalışma Sayfası Yeniden Boyutlandırma İçin Çözüm](/slides/tr/androidjava/working-solution-for-worksheet-resizing/) önerilerini izleyin—ya çerçeveyi aralığa göre ayarlayın ya da aralığı sabit bir çerçeveye ölçeklendirin ve uygun bir yer tutucu resim belirleyin.

**Bağlantılı OLE nesneleri için göreceli yollar PPTX formatında korunur mu?**

PPTX'te "göreceli yol" bilgisi yoktur—sadece tam yol bulunur. Göreceli yollar eski PPT formatında bulunur. Taşınabilirlik için güvenilir mutlak yollar/erişilebilir URI'lar veya gömmeyi tercih edin.