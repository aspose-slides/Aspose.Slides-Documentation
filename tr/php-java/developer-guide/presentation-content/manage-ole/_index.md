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
- nesne çıkar
- dosya çıkar
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile PowerPoint ve OpenDocument dosyalarında OLE nesnesi yönetimini optimize edin. OLE içeriğini sorunsuz bir şekilde gömün, güncelleyin ve dışa aktarın."
---
## **Giriş**

{{% alert color="info" title="Not" %}}

OLE (Object Linking & Embedding), bir uygulamada oluşturulan veri ve nesnelerin, başka bir uygulamaya bağlama veya gömme yoluyla yerleştirilmesini sağlayan bir Microsoft teknolojisidir. 

{{% /alert %}} 

Microsoft Excel'de oluşturulmuş bir grafik düşünün. Bu grafik daha sonra bir PowerPoint slaytına yerleştirilir. Bu Excel grafiği bir OLE nesnesi olarak kabul edilir. 

- Bir OLE nesnesi bir simge olarak görünebilir. Bu durumda, simgeye çift tıkladığınızda grafik, ilişkili uygulamasında (Excel) açılır veya nesneyi açmak/​düzenlemek için bir uygulama seçmeniz istenir.
- Bir OLE nesnesi gerçek içeriğini, örneğin bir grafiğin içeriğini, gösterebilir. Bu durumda, grafik PowerPoint içinde etkinleşir, grafik arabirimi yüklenir ve grafik verilerini PowerPoint içinde değiştirebilirsiniz.

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/php-java/) OLE nesnelerini kaydırlara OLE nesne çerçeveleri ([OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)) olarak eklemenizi sağlar.

## **OLE Nesne Çerçevelerini Slaytlara Ekle**

Microsoft Excel'de zaten bir grafik oluşturduğunuzu ve Aspose.Slides for PHP via Java kullanarak bu grafiği bir OLE nesne çerçevesi olarak bir slayda gömmek istediğinizi varsayalım; bunu şu şekilde yapabilirsiniz:

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) sınıfından bir örnek oluşturun.  
1. İndeksi aracılığıyla bir slaytın referansını alın.  
1. Excel dosyasını bayt dizisi olarak okuyun.  
1. Bayt dizisini ve OLE nesnesiyle ilgili diğer bilgileri içeren [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)'i slayta ekleyin.  
1. Değiştirilmiş sunumu bir PPTX dosyası olarak yazın.  

Aşağıdaki örnekte, bir Excel dosyasından bir grafiği Aspose.Slides for PHP via Java kullanarak bir OLE nesne çerçevesi olarak bir slayda ekledik.  
**Not** ki [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/) yapıcı, ikinci parametre olarak gömülebilir nesne uzantısını alır. Bu uzantı, PowerPoint'in dosya tipini doğru şekilde yorumlamasını ve OLE nesnesini açmak için doğru uygulamayı seçmesini sağlar.

```php
$presentation = new Presentation();
$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item(0);

// OLE nesnesi için verileri hazırlayın.
$fileData = file_get_contents("book.xlsx");
$dataInfo = new OleEmbeddedDataInfo($fileData, "xlsx");

// OLE nesne çerçevesini slayta ekleyin.
$slide->getShapes()->addOleObjectFrame(0, 0, $slideSize->getWidth(), $slideSize->getHeight(), $dataInfo);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

### **Bağlantılı OLE Nesne Çerçevelerini Ekle**

Aspose.Slides for PHP via Java, veri gömmeden yalnızca dosyaya bir bağlantı ile bir [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) eklemenizi sağlar.

Bu PHP kodu, bir slayda bağlı bir Excel dosyasıyla bir [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) eklemenizi gösterir:

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// Bağlantılı bir Excel dosyasıyla OLE nesne çerçevesi ekleyin.
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **OLE Nesne Çerçevelerine Erişim**

Bir OLE nesnesi zaten bir slayta gömülmüşse, bu nesneyi şu şekilde kolayca bulabilir veya erişebilirsiniz:

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) sınıfından bir örnek oluşturarak gömülü OLE nesnesi içeren bir sunum yükleyin.  
2. İndeksi kullanarak slaytın referansını alın.  
3. [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) şekline erişin. Örneğimizde, ilk slaytta yalnızca bir şekil bulunan önceden oluşturulmuş PPTX dosyasını kullandık.  
4. OLE nesne çerçevesine erişildiğinde, üzerinde istediğiniz herhangi bir işlemi gerçekleştirebilirsiniz.  

Aşağıdaki örnekte, bir OLE nesne çerçevesi (bir slayta gömülmüş bir Excel grafik nesnesi) ve dosya verileri erişilmektedir.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;
    
    // Gömülü dosya verisini alın.
    // Gömülü dosyanın uzantısını alın.
    // ...
}
```

### **Bağlantılı OLE Nesne Çerçevesi Özelliklerine Erişim**

Aspose.Slides, bağlantılı OLE nesne çerçevesi özelliklerine erişmenizi sağlar.

Bu PHP kodu, bir OLE nesnesinin bağlantılı olup olmadığını kontrol etmenizi ve ardından bağlantılı dosyanın yolunu almanızı gösterir:

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

        // Varsa bağlantılı dosyanın göreli yolunu yazdır.
        // Yalnızca PPT sunumları göreli yolu içerebilir.
        $relativePath = java_values($oleFrame->getLinkPathRelative());
        if (!is_null($relativePath) && $relativePath !== "") {
            echo "OLE object frame relative path: " . $oleFrame->getLinkPathRelative() . PHP_EOL;
        }
    }
}

$presentation->dispose();
```

## **OLE Nesne Verilerini Değiştir**

{{% alert color="info" title="Not" %}}

Bu bölümde, aşağıdaki kod örneği [Aspose.Cells for PHP via Java](https://docs.aspose.com/cells/php-java/) kullanmaktadır.

{{% /alert %}}

Bir OLE nesnesi zaten bir slayta gömülmüşse, bu nesneye kolayca erişebilir ve verilerini şu şekilde değiştirebilirsiniz:

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) sınıfından bir örnek oluşturarak gömülü OLE nesnesi içeren bir sunum yükleyin.  
2. İndeksi aracılığıyla slaytın referansını alın.  
3. [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) şekline erişin. Örneğimizde, ilk slaytta bir şekil bulunan önceden oluşturulmuş PPTX dosyasını kullandık.  
4. OLE nesne çerçevesine erişildiğinde, üzerinde istediğiniz herhangi bir işlemi gerçekleştirebilirsiniz.  
5. `Workbook` nesnesi oluşturun ve OLE verisine erişin.  
6. İstenen `Worksheet`e erişin ve verileri düzenleyin.  
7. Güncellenmiş `Workbook`u bir akışta (stream) kaydedin.  
8. OLE nesne verilerini akıştan değiştirin.  

Aşağıdaki örnekte, bir OLE nesne çerçevesi (bir slayta gömülmüş bir Excel grafik nesnesi) erişilir ve dosya verileri, grafik verilerini güncellemek üzere değiştirilir.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    $oleStream = new Java("java.io.ByteArrayInputStream", $oleFrame->getEmbeddedData()->getEmbeddedFileData());

    // OLE nesne verisini Workbook nesnesi olarak okuyun.
    $workbook = new Workbook($oleStream);

    $newOleStream = new Java("java.io.ByteArrayOutputStream");

    // Çalışma kitabı verisini değiştirin.
    $workbook->getWorksheets()->get(0)->getCells()->get(0, 4)->putValue("E");
    $workbook->getWorksheets()->get(0)->getCells()->get(1, 4)->putValue(12);
    $workbook->getWorksheets()->get(0)->getCells()->get(2, 4)->putValue(14);
    $workbook->getWorksheets()->get(0)->getCells()->get(3, 4)->putValue(15);

    $fileOptions = new OoxmlSaveOptions(SaveFormat::XLSX);
    $workbook->save($newOleStream, $fileOptions);

    // OLE çerçeve nesnesi verisini değiştirin.
    $newData = new OleEmbeddedDataInfo($newOleStream->toByteArray(), $oleFrame->getEmbeddedData()->getEmbeddedFileExtension());
    $oleFrame->setEmbeddedData($newData);

    $newOleStream->close();
    $oleStream->close();
}

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Diğer Dosya Türlerini Slaytlara Göm**

Excel grafiklerinin yanı sıra, Aspose.Slides for PHP via Java, slaytlara HTML, PDF ve ZIP dosyaları gibi diğer dosya türlerini de nesne olarak eklemenizi sağlar. Kullanıcı eklenen nesneye çift tıkladığında, ilgili program otomatik olarak açılır veya kullanıcı, dosyayı açmak için uygun bir program seçmesi istenir.

Bu PHP kodu, bir slayta HTML ve ZIP dosyalarını nasıl gömeceğinizi gösterir:

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

## **Gömülü Nesneler İçin Dosya Türlerini Ayarla**

Sunumlarla çalışırken, eski OLE nesnelerini yenileriyle değiştirmek veya desteklenmeyen bir OLE nesnesini desteklenen bir nesneyle değiştirmek isteyebilirsiniz. Aspose.Slides for PHP via Java, gömülü bir nesnenin dosya türünü ayarlamanıza izin verir; bu sayede OLE çerçeve verisini veya uzantısını güncelleyebilirsiniz.

Bu PHP kodu, gömülü bir OLE nesnesi için dosya türünü `zip` olarak ayarlamayı gösterir:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
$fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

echo "Current embedded file extension is: " . $fileExtension . PHP_EOL;

// Dosya tipini ZIP olarak değiştir.
$oleFrame->setEmbeddedData(new OleEmbeddedDataInfo($fileData, "zip"));

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Gömülü Nesneler İçin Simge Görselleri ve Başlıkları Ayarla**

Bir OLE nesnesi gömüldükten sonra, otomatik olarak bir simge görseli içeren bir ön izleme eklenir. Bu ön izleme, kullanıcıların OLE nesnesine erişmeden/​açmadan önce gördükleri şeydir. Ön izlemede belirli bir görsel ve metni öğe olarak kullanmak istiyorsanız, Aspose.Slides for PHP via Java ile simge görselini ve başlığı ayarlayabilirsiniz.

Bu PHP kodu, gömülü bir nesne için simge görseli ve başlığı nasıl ayarlayacağınızı gösterir:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// Sunum kaynaklarına bir görüntü ekleyin.
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);

// Set a title and the image for the OLE preview.
$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **OLE Nesne Çerçevesinin Boyutunun ve Konumunun Değiştirilmesini ve Yeniden Konumlandırılmasını Önle**

Bağlantılı bir OLE nesnesini bir sunum slaytına ekledikten sonra, PowerPoint'te sunumu açtığınızda, bağlantıları güncellemeniz istenebilir. “Bağlantıları Güncelle” düğmesine tıklamak, PowerPoint bağlantılı OLE nesnesinden verileri güncellediği ve nesne ön izlemesini yenilediği için OLE nesne çerçevesinin boyutunu ve konumunu değiştirebilir. PowerPoint'in nesnenin verilerini güncelleme istemini önlemek için, [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) sınıfının [setUpdateAutomatic](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) yöntemini `false` ile çağırın:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$oleFrame->setUpdateAutomatic(false);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Gömülü Dosyaları Çıkar**

Aspose.Slides for PHP via Java, slaytlara OLE nesnesi olarak gömülmüş dosyaları şu şekilde çıkarabilir:

1. Gömülü OLE nesnelerini içeren bir [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) örneği oluşturun.  
2. Sunumdaki tüm şekilleri döngüye alarak [OLEObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) şekillerine erişin.  
3. OLE nesne çerçevelerindeki gömülü dosya verilerine erişin ve diske yazın.  

Bu PHP kodu, bir slayttaki dosyaları OLE nesnesi olarak nasıl çıkaracağınızı gösterir:

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

**Slaytları PDF/görsellere dışa aktarırken OLE içeriği işlenecek mi?**

Slaytta görülen şey işlenir—simge/yer tutucu görüntüsü (ön izleme). “Canlı” OLE içeriği işleme sırasında yürütülmez. Gerekirse, dışa aktarılan PDF'de beklenen görünümü sağlamak için kendi ön izleme görselinizi ayarlayın.

Gömülü dosyayı PDF eki olarak da korumak için, [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setIncludeOleData) yöntemini `true` olarak çağırın. Bu seçenek varsayılan olarak devre dışıdır. Bir örnek ve ek kontrol talimatları için [Preserve Embedded OLE Files as PDF Attachments](/slides/tr/php-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments) bölümüne bakın.

**Bir OLE nesnesini bir slaytta kilitleyerek kullanıcıların PowerPoint'te nesneyi taşımasını/düzenlemesini nasıl engelleyebilirim?**

Şekli kilitleyin: Aspose.Slides şekil‑seviyesi kilitler sağlar. Bu şifreleme değildir, ancak istem dışı düzenlemeleri ve hareketi etkili şekilde önler.

**Bağlantılı OLE nesnelerinin göreli yolları PPTX formatında korunacak mı?**

PPTX içinde “göreli yol” bilgisi bulunmaz—yalnızca tam yol bulunur. Göreli yollar eski PPT formatında mevcuttur. Taşınabilirlik için güvenilir mutlak yollar/erişilebilir URI'lar veya gömme tercih edilmelidir.