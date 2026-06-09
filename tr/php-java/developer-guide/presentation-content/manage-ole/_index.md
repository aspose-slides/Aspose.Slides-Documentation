---
title: PHP Kullanarak Sunumlarda OLE Yönetimi
linktitle: OLE Yönetimi
type: docs
weight: 40
url: /tr/php-java/manage-ole/
keywords:
- OLE nesnesi
- Nesne Bağlantısı ve Gömme
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak PowerPoint ve OpenDocument dosyalarında OLE nesne yönetimini optimize edin. OLE içeriğini sorunsuz bir şekilde gömün, güncelleyin ve dışa aktarın."
---
## **Giriş**

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding), bir uygulamada oluşturulan veri ve nesnelerin, bağlantı veya gömme yoluyla başka bir uygulamaya yerleştirilmesini sağlayan bir Microsoft teknolojisidir. 

{{% /alert %}} 

MS Excel'de oluşturulan bir grafik düşündüğünüzde, bu grafik bir PowerPoint slaytına yerleştirilir. Bu Excel grafiği bir OLE nesnesi olarak kabul edilir. 

- Bir OLE nesnesi bir simge olarak görünebilir. Bu durumda, simgeye çift tıkladığınızda grafik ilişkili uygulamasında (Excel) açılır veya nesneyi açmak ya da düzenlemek için bir uygulama seçmeniz istenir. 
- Bir OLE nesnesi gerçek içeriğini, örneğin bir grafiğin içeriğini gösterebilir. Bu durumda grafik PowerPoint içinde etkinleşir, grafik arayüzü yüklenir ve grafiğin verilerini PowerPoint içinde değiştirebilirsiniz. 

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/tr/php-java/) OLE Nesnelerini slaytlara OLE nesne çerçeveleri ([OleObjectFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/oleobjectframe/)) olarak eklemenizi sağlar. 

## **OLE Nesne Çerçevelerini Slaytlara Ekleme**

Microsoft Excel'de zaten bir grafik oluşturduğunuzu ve bunu Aspose.Slides for PHP via Java kullanarak bir OLE nesne çerçevesi olarak bir slayta gömmek istediğinizi varsayarsak, bunu şu şekilde yapabilirsiniz:

1. Aspose.Slides'in [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
1. İndeksine göre bir slaytın referansını alın.  
1. Excel dosyasını bir bayt dizisi olarak okuyun.  
1. OLE nesnesi hakkında bayt dizisi ve diğer bilgileri içeren [OleObjectFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/oleobjectframe/) çerçevesini slayta ekleyin.  
1. Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.  

Aşağıdaki örnekte, bir Excel dosyasından bir grafiği Aspose.Slides for PHP via Java kullanarak bir OLE nesne çerçevesi olarak bir slayta ekledik.  
**Not**: [OleEmbeddedDataInfo](https://reference.aspose.com/slides/tr/php-java/aspose.slides/oleembeddeddatainfo/) yapıcısı ikinci parametre olarak gömülebilir nesne uzantısı alır. Bu uzantı, PowerPoint'in dosya türünü doğru şekilde yorumlamasını ve bu OLE nesnesini açmak için doğru uygulamayı seçmesini sağlar.  

```php
$presentation = new Presentation();
$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item(0);

// OLE nesnesi için veriyi hazırlayın.
$fileData = file_get_contents("book.xlsx");
$dataInfo = new OleEmbeddedDataInfo($fileData, "xlsx");

// Add the OLE object frame to the slide.
$slide->getShapes()->addOleObjectFrame(0, 0, $slideSize->getWidth(), $slideSize->getHeight(), $dataInfo);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

### **Bağlantılı OLE Nesne Çerçeveleri Ekleme**

Aspose.Slides for PHP via Java, veriyi gömmeden yalnızca dosyaya bir bağlantı ile bir [OleObjectFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/oleobjectframe/) eklemenizi sağlar.  

Bu PHP kodu, bir slayta bağlantılı bir Excel dosyasıyla bir [OleObjectFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/oleobjectframe/) nasıl ekleyeceğinizi gösterir:  

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// Bağlantılı bir Excel dosyasıyla OLE nesne çerçevesi ekle.
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **OLE Nesne Çerçevelerine Erişim**

Eğer bir OLE nesnesi zaten bir slayta gömülmüşse, onu kolayca bulabilir veya erişebilirsiniz:  

1. Gömülü OLE nesnesine sahip bir sunumu, [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturarak yükleyin.  
2. İndeksini kullanarak slaytın referansını alın.  
3. [OleObjectFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/oleobjectframe/) şekline erişin. Örneğimizde, ilk slaytta yalnızca bir şekil bulunan önceden oluşturulmuş PPTX'i kullandık.  
4. OLE nesne çerçevesine erişildiğinde, üzerinde istediğiniz herhangi bir işlemi yapabilirsiniz.  

Aşağıdaki örnekte, bir OLE nesne çerçevesine (bir slayta gömülmüş Excel grafik nesnesi) ve dosya verilerine erişilir.  

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;
    
    // Gömülü dosya verisini al.
    $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

    // Gömülü dosyanın uzantısını al.
    $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

    // ...
}
```

### **Bağlantılı OLE Nesne Çerçevesi Özelliklerine Erişim**

Aspose.Slides, bağlantılı OLE nesne çerçevesi özelliklerine erişmenizi sağlar.  

Bu PHP kodu, bir OLE nesnesinin bağlantılı olup olmadığını kontrol etmeyi ve ardından bağlantılı dosyanın yolunu almayı gösterir:  

```php
$presentation = new Presentation("sample.ppt");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    // OLE nesnesinin bağlantılı olup olmadığını kontrol edin.
    if (java_values($oleFrame->isObjectLink()) != 0) {
        // Bağlantılı dosyanın tam yolunu yazdır.
        echo "OLE object frame is linked to: " . $oleFrame->getLinkPathLong() . PHP_EOL;

        // Varsa bağlantılı dosyanın göreceli yolunu yazdır.
        // Yalnızca PPT sunumları göreceli yolu içerebilir.
        $relativePath = java_values($oleFrame->getLinkPathRelative());
        if (!is_null($relativePath) && $relativePath !== "") {
            echo "OLE object frame relative path: " . $oleFrame->getLinkPathRelative() . PHP_EOL;
        }
    }
}

$presentation->dispose();
```

## **OLE Nesne Verilerini Değiştirme**

{{% alert color="primary" %}} 

Bu bölümde, aşağıdaki kod örneği [Aspose.Cells for PHP via Java](/cells/php-java/) kullanmaktadır.  

{{% /alert %}} 

Eğer bir OLE nesnesi zaten bir slayta gömülmüşse, o nesneye kolayca erişebilir ve verilerini şu şekilde değiştirebilirsiniz:  

1. Gömülü OLE nesnesine sahip bir sunumu, [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturarak yükleyin.  
2. İndeksini kullanarak slaytın referansını alın.  
3. [OleObjectFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/oleobjectframe/) şekline erişin. Örneğimizde, ilk slaytta bir şekil bulunan önceden oluşturulmuş PPTX'i kullandık.  
4. OLE nesne çerçevesine erişildiğinde, üzerinde istediğiniz herhangi bir işlemi yapabilirsiniz.  
5. `Workbook` nesnesi oluşturun ve OLE verisine erişin.  
6. İstediğiniz `Worksheet`'e erişin ve veriyi düzenleyin.  
7. Güncellenen `Workbook`'ı bir akışta (stream) kaydedin.  
8. Akıştan OLE nesne verisini değiştirin.  

Aşağıdaki örnekte, bir OLE nesne çerçevesine (bir slayta gömülmüş Excel grafik nesnesi) erişilir ve dosya verisi, grafik verilerini güncellemek için değiştirilir.  

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    $oleStream = new ByteArrayInputStream($oleFrame->getEmbeddedData()->getEmbeddedFileData());

    // OLE nesnesi verisini Workbook nesnesi olarak okuyun.
    $workbook = new Workbook($oleStream);

    $newOleStream = new Java("java.io.ByteArrayOutputStream");

    // Workbook verisini değiştirin.
    $workbook->getWorksheets()->get(0)->getCells()->get(0, 4)->putValue("E");
    $workbook->getWorksheets()->get(0)->getCells()->get(1, 4)->putValue(12);
    $workbook->getWorksheets()->get(0)->getCells()->get(2, 4)->putValue(14);
    $workbook->getWorksheets()->get(0)->getCells()->get(3, 4)->putValue(15);

    $fileOptions = new OoxmlSaveOptions(SaveFormat::XLSX);
    $workbook->save($newOleStream, $fileOptions);

    // OLE çerçeve nesnesinin verisini değiştirin.
    $newData = new OleEmbeddedDataInfo($newOleStream->toByteArray(), $oleFrame->getEmbeddedData()->getEmbeddedFileExtension());
    $oleFrame->setEmbeddedData($newData);

    $newOleStream->close();
    $oleStream->close();
}

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Diğer Dosya Türlerini Slaytlara Gömme**

Excel grafiklerinin yanı sıra, Aspose.Slides for PHP via Java, slaytlara diğer dosya türlerini de gömmeyi sağlar. Örneğin, HTML, PDF ve ZIP dosyalarını nesne olarak ekleyebilirsiniz. Kullanıcı eklenen nesneye çift tıkladığında, otomatik olarak ilgili programda açılır veya kullanıcı dosyayı açmak için uygun bir program seçmesi istenir.  

Bu PHP kodu, bir slayta HTML ve ZIP dosyalarının nasıl gömüleceğini gösterir:  

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$htmlData = file_get_contents("sample.html");
$htmlDataInfo = new OleEmbeddedDataInfo($htmlData, "html");
$htmlOleFrame = $slide->getShapes()->addOleObjectFrame(150, 120, 50, 50, $htmlDataInfo);
$htmlOleFrame->setObjectIcon(true);

$zipData = file_get_contents("sample.zip");
$zipDataInfo = new OleEmbeddedDataInfo($zipData, "zip");
$zipOleFrame = $slide->getShapes()->addOleObjectFrame(150, 220, 50, 50, $zipDataInfo);
$zipOleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Gömülü Nesneler İçin Dosya Türlerini Ayarlama**

Sunumlarla çalışırken, eski OLE nesnelerini yenileriyle değiştirmek veya desteklenmeyen bir OLE nesnesini desteklenen bir nesneyle değiştirmek isteyebilirsiniz. Aspose.Slides for PHP via Java, gömülü bir nesnenin dosya türünü ayarlamanıza olanak tanır; bu sayede OLE çerçeve verilerini veya uzantısını güncelleyebilirsiniz.  

Bu PHP kodu, gömülü bir OLE nesnesinin dosya türünü `zip` olarak nasıl ayarlayacağınızı gösterir:  

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
$fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

echo "Current embedded file extension is: " . $fileExtension . PHP_EOL;

// Dosya türünü ZIP olarak değiştir.
$oleFrame->setEmbeddedData(new OleEmbeddedDataInfo($fileData, "zip"));

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Gömülü Nesneler İçin Simge Görselleri ve Başlıkları Ayarlama**

Bir OLE nesnesi gömüldükten sonra, otomatik olarak bir simge görüntüsünden oluşan bir ön izleme eklenir. Bu ön izleme, kullanıcıların OLE nesnesine erişmeden veya açmadan önce gördükleri şeydir. Ön izlemede belirli bir görüntü ve metin kullanmak isterseniz, Aspose.Slides for PHP via Java kullanarak simge görüntüsünü ve başlığı ayarlayabilirsiniz.  

Bu PHP kodu, gömülü bir nesne için simge görüntüsü ve başlık ayarlamanızı gösterir:  

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// Sunum kaynaklarına bir görüntü ekle.
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);

// OLE ön izlemesi için bir başlık ve görüntü ayarla.
$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Bir OLE Nesne Çerçevesinin Yeniden Boyutlandırılmasını ve Yeniden Konumlandırılmasını Önleme**

Bağlantılı bir OLE nesnesini bir sunum slaytına ekledikten sonra, sunumu PowerPoint'te açtığınızda, bağlantıları güncellemek isteyip istemediğinizi soran bir mesaj görebilirsiniz. "Update Links" (Bağlantıları Güncelle) düğmesine tıkladığınızda, PowerPoint bağlantılı OLE nesnesinden verileri güncelleyip nesne ön izlemesini yenilediği için OLE nesne çerçevesinin boyutu ve konumu değişebilir. PowerPoint'in nesnenin verilerini güncelleme isteğini önlemek için, [OleObjectFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/oleobjectframe/) sınıfının `setUpdateAutomatic` metodunu `false` olarak ayarlayın:  

```php
$oleFrame->setUpdateAutomatic(false);
```

## **Gömülü Dosyaları Çıkarma**

Aspose.Slides for PHP via Java, slaytlara OLE nesneleri olarak gömülü dosyaları şu şekilde çıkarabilir:  

1. Çıkarmak istediğiniz OLE nesnelerini içeren [Presentation](https://reference.aspose.com/slides/tr/php-java/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Sunumdaki tüm şekillerin üzerinden döngü yapın ve [OLEObjectFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/oleobjectframe/) şekillerine erişin.  
3. OLE nesne çerçevelerindeki gömülü dosya verilerine erişin ve bunları diske yazın.  

Bu PHP kodu, bir slayta OLE nesneleri olarak gömülü dosyaları nasıl çıkaracağınızı gösterir:  

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$shapeCount = java_values($slide->getShapes()->size());
for ($index = 0; $index < $shapeCount; $index++) {
    $shape = $slide->getShapes()->get_Item($index);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
        $oleFrame = $shape;

        $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();
        $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

        $filePath = "OLE_object_" . $index . $fileExtension;
        file_put_contents($filePath, $fileData);
    }
}

$presentation->dispose();
```

## **SSS**

**Slaytlar PDF/resimlere dışa aktarılırken OLE içeriği işlenecek mi?**  
Slaytta görünen şey işlenir—ikon/değiştirici görüntü (ön izleme). "Canlı" OLE içeriği renderleme sırasında yürütülmez. Gerekirse, dışa aktarılan PDF'de beklenen görünümü sağlamak için kendi ön izleme görüntünüzü ayarlayın.  

**Bir OLE nesnesini bir slaytta kilitleyerek kullanıcıların PowerPoint'te hareket ettirmesini/düzenlemesini nasıl engelleyebilirim?**  
Şekli kilitleyin: Aspose.Slides, şekil düzeyinde kilitler sunar. Bu bir şifreleme değildir, ancak yanlışlıkla yapılan düzenlemeleri ve hareketleri etkili bir şekilde engeller.  

**Bağlantılı OLE nesneleri için göreceli yollar PPTX formatında korunacak mı?**  
PPTX içinde "göreceli yol" bilgisi bulunmaz—yalnızca tam yol vardır. Göreceli yollar, eski PPT formatında bulunur. Taşınabilirlik için güvenilir mutlak yolları / erişilebilir URI'ları veya gömmeyi tercih edin.