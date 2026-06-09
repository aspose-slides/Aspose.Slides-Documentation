---
title: JavaScript Kullanarak Sunumlarda OLE Yönetimi
linktitle: OLE Yönetimi
type: docs
weight: 40
url: /tr/nodejs-java/manage-ole/
keywords:
- OLE nesnesi
- Nesne Bağlantısı ve Gömülmesi
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java kullanarak PowerPoint ve OpenDocument dosyalarında OLE nesnesi yönetimini optimize edin. OLE içeriğini sorunsuz bir şekilde gömün, güncelleyin ve dışa aktarın."
---
## **Giriş**

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding), bir uygulamada oluşturulan veri ve nesnelerin başka bir uygulamaya bağlanma veya gömme yoluyla yerleştirilebilmesini sağlayan bir Microsoft teknolojisidir. 

{{% /alert %}} 

Microsoft Excel'de oluşturulan bir grafiği düşünün. Bu grafik daha sonra bir PowerPoint slaytına yerleştirilir. Bu Excel grafiği bir OLE nesnesi olarak kabul edilir. 

- Bir OLE nesnesi bir simge olarak görünebilir. Bu durumda, simgeye çift tıkladığınızda grafik, ilişkili uygulamasında (Excel) açılır veya nesneyi açmak/düzenlemek için bir uygulama seçmeniz istenir. 
- Bir OLE nesnesi gerçek içeriğini, örneğin bir grafiğin içeriğini gösterebilir. Bu durumda, grafik PowerPoint içinde etkinleştirilir, grafik arayüzü yüklenir ve grafiğin verilerini PowerPoint içinde değiştirebilirsiniz.

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/tr/nodejs-java/) OLE nesnelerini slaytlara OLE nesne çerçeveleri ([OleObjectFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/OleObjectFrame)) olarak eklemenizi sağlar.

## **Slaytlara OLE Nesne Çerçeveleri Ekleme**

Microsoft Excel'de zaten bir grafik oluşturduğunuzu ve bu grafiği Aspose.Slides for Node.js via Java kullanarak bir OLE nesne çerçevesi olarak slayta gömmek istediğinizi varsayalım; bunu şu şekilde yapabilirsiniz:

1. [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun. 
1. Slaytın referansını indeksine göre alın. 
1. Excel dosyasını bir bayt dizisi olarak okuyun. 
1. Bayt dizisini ve OLE nesnesiyle ilgili diğer bilgileri içeren [OleObjectFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/OleObjectFrame) öğesini slayta ekleyin. 
1. Değiştirilmiş sunumu bir PPTX dosyası olarak yazın. 

Aşağıdaki örnekte, bir Excel dosyasındaki grafiği Aspose.Slides for Node.js via Java kullanarak bir OLE nesne çerçevesi olarak slayta ekledik.  
**Not** ki [OleEmbeddedDataInfo](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/OleEmbeddedDataInfo) yapıcı, ikinci parametre olarak gömülebilir nesne uzantısını alır. Bu uzantı, PowerPoint’in dosya türünü doğru şekilde yorumlamasını ve bu OLE nesnesini açmak için doğru uygulamayı seçmesini sağlar.

```javascript
var presentation = new asposeSlides.Presentation();
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(0);

// OLE nesnesi için veriyi hazırlayın.
var oleStream = fs.readFileSync("book.xlsx");
var fileData = Array.from(oleStream);
var dataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", fileData), "xlsx");

// OLE nesne çerçevesini slayta ekleyin.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

### **Bağlantılı OLE Nesne Çerçeveleri Ekleme**

Aspose.Slides for Node.js via Java, veri gömmeden yalnızca dosyaya bir bağlantı ile bir [OleObjectFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/OleObjectFrame) eklemenize izin verir.

Bu JavaScript kodu, bir Excel dosyasına bağlantılı bir [OleObjectFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/OleObjectFrame) eklemenin nasıl yapılacağını gösterir:

```javascript
var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

// Bağlantılı bir Excel dosyasıyla bir OLE nesne çerçevesi ekleyin.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **OLE Nesne Çerçevelerine Erişim**

Eğer bir OLE nesnesi zaten bir slayta gömülmüşse, ona şu şekilde kolayca ulaşabilir veya bulabilirsiniz:

1. Gömülü OLE nesnesi içeren bir sunumu, [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturarak yükleyin. 
2. Slaytın referansını indeksini kullanarak alın. 
3. [OleObjectFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/OleObjectFrame) şekline erişin. Örneğimizde, yalnızca bir şekli olan ilk slaytın önceden oluşturulmuş PPTX dosyasını kullandık. 
4. OLE nesne çerçevesine eriştikten sonra, üzerinde istediğiniz işlemi yapabilirsiniz. 

Aşağıdaki örnekte, bir OLE nesne çerçevesi (slayta gömülmüş bir Excel grafik nesnesi) ve dosya verileri erişilir.

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;
    
    // Gömülü dosya verisini alın.
    var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Gömülü dosyanın uzantısını alın.
    var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Bağlantılı OLE Nesne Çerçevesi Özelliklerine Erişim**

Aspose.Slides, bağlantılı OLE nesne çerçevesi özelliklerine erişmenizi sağlar.

Bu JavaScript kodu, bir OLE nesnesinin bağlantılı olup olmadığını kontrol etmenizi ve ardından bağlantılı dosyanın yolunu almanızı gösterir:

```javascript
var presentation = new asposeSlides.Presentation("sample.ppt");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    // OLE nesnesinin bağlantılı olup olmadığını kontrol edin.
    if (oleFrame.isObjectLink()) {
        // Bağlantılı dosyanın tam yolunu yazdır.
        console.log("OLE object frame is linked to:", oleFrame.getLinkPathLong());

        // Varsa bağlantılı dosyanın göreli yolunu yazdır.
        // Yalnızca PPT sunumları göreli yolu içerebilir.
        if (oleFrame.getLinkPathRelative() != null && oleFrame.getLinkPathRelative() != "") {
            console.log("OLE object frame relative path:", oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **OLE Nesne Verilerini Değiştirme**

{{% alert color="primary" %}} 

Bu bölümde aşağıdaki kod örneği [Aspose.Cells for Java](/cells/java/) kullanmaktadır.

{{% /alert %}}

Eğer bir OLE nesnesi zaten bir slayta gömülmüşse, o nesneye kolayca erişebilir ve verilerini şu şekilde değiştirebilirsiniz:

1. Gömülü OLE nesnesi içeren bir sunumu, [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturarak yükleyin. 
2. Slaytın referansını indeks üzerinden alın. 
3. OLE nesne çerçevesi şekline erişin. Örneğimizde, ilk slaytta bir şekli olan önceden oluşturulmuş PPTX dosyasını kullandık. 
4. OLE nesne çerçevesine eriştikten sonra, üzerinde istediğiniz işlemi yapabilirsiniz. 
5. Bir `Workbook` nesnesi oluşturun ve OLE verilerine erişin. 
6. İlgili `Worksheet` i alın ve verileri düzenleyin. 
7. Güncellenmiş `Workbook` u bir akışa kaydedin. 
8. OLE nesne verisini akıştan değiştirin. 

Aşağıdaki örnekte, bir OLE nesne çerçevesi (slayta gömülmüş bir Excel grafik nesnesi) erişilir ve dosya verileri grafiğin verilerini güncellemek için değiştirilir.

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    var oleStream = java.newInstanceSync("java.io.ByteArrayInputStream", oleFrame.getEmbeddedData().getEmbeddedFileData());

    // OLE nesne verisini bir Workbook nesnesi olarak okuyun.
    var workbook = java.newInstanceSync("Workbook", oleStream);

    var newOleStream = java.newInstanceSync("java.io.ByteArrayOutputStream");

    // Workbook verisini değiştirin.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    var fileOptions = java.newInstanceSync("OoxmlSaveOptions", java.getStaticFieldValue("com.aspose.cells.SaveFormat", "XLSX"));
    workbook.save(newOleStream, fileOptions);

    // OLE çerçeve nesnesi verisini değiştirin.
    var newData = new asposeSlides.OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);

    newOleStream.close();
    oleStream.close();
}

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Diğer Dosya Türlerini Slaytlara Gömme**

Excel grafikleri dışında, Aspose.Slides for Node.js via Java, slaytlara HTML, PDF ve ZIP gibi diğer dosya türlerini nesne olarak gömmeyi de sağlar. Kullanıcı eklenen nesneye çift tıkladığında, ilgili programda otomatik olarak açılır veya kullanıcıdan uygun bir program seçmesi istenir.

Bu JavaScript kodu, bir slayta HTML ve ZIP dosyalarını nasıl gömeceğinizi gösterir:

```javascript
var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var htmlBuffer = fs.readFileSync("sample.html");
var htmlData = Array.from(htmlBuffer);
var htmlDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", htmlData), "html");
var htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

var zipBuffer = fs.readFileSync("sample.zip");
var zipData = Array.from(zipBuffer);
var zipDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", zipData), "zip");
var zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Gömülü Nesneler İçin Dosya Türlerini Ayarlama**

Sunumlarla çalışırken, eski OLE nesnelerini yenileriyle değiştirmek veya desteklenmeyen bir OLE nesnesini desteklenen bir nesneyle değiştirmek isteyebilirsiniz. Aspose.Slides for Node.js via Java, gömülü bir nesnenin dosya türünü ayarlamanıza olanak tanır; bu sayede OLE çerçeve verilerini veya uzantısını güncelleyebilirsiniz.

Bu JavaScript kodu, gömülü bir OLE nesnesinin dosya türünü `zip` olarak ayarlamanın nasıl yapılacağını gösterir:

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
var oleFileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

console.log("Current embedded file extension is:", fileExtension);

// Change the file type to ZIP.
var fileData = java.newArray("byte", Array.from(oleFileData));
oleFrame.setEmbeddedData(new asposeSlides.OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Gömülü Nesneler İçin Simge Görüntüsü ve Başlık Ayarlama**

Bir OLE nesnesi gömüldükten sonra, otomatik olarak bir simge resmi içeren bir ön izleme eklenir. Bu ön izleme, kullanıcıların OLE nesnesine erişmeden veya açmadan önce gördükleri şeydir. Eğer ön izlemede belirli bir görüntü ve metin kullanmak istiyorsanız, Aspose.Slides for Node.js via Java ile simge görüntüsü ve başlığı ayarlayabilirsiniz.

Bu JavaScript kodu, gömülü bir nesne için simge görüntüsü ve başlık ayarlamanın nasıl yapılacağını gösterir:

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

// Sunum kaynaklarına bir resim ekleyin.
var image = asposeSlides.Images.fromFile("image.png");
var oleImage = presentation.getImages().addImage(image);
image.dispose();

// OLE ön izlemesi için bir başlık ve resmi ayarlayın.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **OLE Nesne Çerçevesinin Yeniden Boyutlandırılmasını ve Yeniden Konumlandırılmasını Önleme**

Bir bağlantılı OLE nesnesini bir sunum slaytına ekledikten sonra, PowerPoint’te sunumu açtığınızda bağlantıları güncellemek isteyip istemediğinizi soran bir mesaj görebilirsiniz. “Update Links” (Bağlantıları Güncelle) düğmesine tıkladığınızda, PowerPoint bağlantılı OLE nesnesinin verilerini güncellediği ve nesne ön izlemesini yenilediği için OLE nesne çerçevesinin boyutu ve konumu değişebilir. PowerPoint’in nesne verilerini güncelleme istemesini önlemek için, [OleObjectFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/oleobjectframe/) sınıfının `setUpdateAutomatic` yöntemini `false` değeriyle kullanın:

```javascript
oleFrame.setUpdateAutomatic(false);
```

## **Gömülü Dosyaları Çıkarma**

Aspose.Slides for Node.js via Java, slaytlara OLE nesneleri olarak gömülmüş dosyaları şu şekilde çıkarabilir:

1. Çıkarmak istediğiniz OLE nesnelerini içeren bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation) sınıfının bir örneğini oluşturun. 
2. Sunumdaki tüm şekiller üzerinden döngüye girin ve [OLEObjectFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/oleobjectframe) şekillerine erişin. 
3. Gömülü dosyaların verilerine OLE nesne çerçevelerinden erişin ve diske yazın. 

Bu JavaScript kodu, bir slayta OLE nesneleri olarak gömülmüş dosyaları nasıl çıkaracağınızı gösterir:

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);

for (var index = 0; index < slide.getShapes().size(); index++) {
    var shape = slide.getShapes().get_Item(index);

    if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
        var oleFrame = shape;

        var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        var filePath = "OLE_object_" + index + fileExtension;
        fs.writeFileSync(filePath, Buffer.from(fileData));
    }
}

presentation.dispose();
```

## **SSS**

**OLE içeriği PDF/görüntü olarak dışa aktarıldığında render edilecek mi?**

Slaytta görülen şey render edilir – simge/yer tutucu görüntü (ön izleme). “Canlı” OLE içeriği render sırasında çalıştırılmaz. Gerekirse, dışa aktarılan PDF’de beklenen görünümü sağlamak için kendi ön izleme görüntünüzü ayarlayın.

**OLE nesnesini bir slaytta kilitleyerek kullanıcıların PowerPoint’te hareket ettirmesini/düzenlemesini nasıl engelleyebilirim?**

Şekli kilitleyin: Aspose.Slides şekil düzeyinde kilitlemeler sağlar. Bu bir şifreleme değildir, ancak tesadüfi düzenleme ve hareketi etkili bir şekilde önler.

**Bağlantılı OLE nesneleri için göreli yollar PPTX formatında korunacak mı?**

PPTX içinde “göreli yol” bilgisi bulunmaz – yalnızca tam yol vardır. Göreli yollar eski PPT formatında bulunur. Taşınabilirlik için güvenilir mutlak yollar/erişilebilir URI’ler veya gömme tercih edin.