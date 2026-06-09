---
title: OleObjectFrame Ekleme Sırasında Nesne Önizleme Sorunu
linktitle: OLE Nesne Sorunu
type: docs
weight: 10
url: /tr/php-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- önizleme sorunu
- gömülü nesne
- gömülü dosya
- nesne değişti
- nesne önizleme
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP'de OleObjectFrame eklerken EMBEDDED OLE OBJECT neden göründüğünü ve PPT, PPTX ve ODP sunumlarında önizleme sorunlarını nasıl düzelteceğinizi öğrenin."
---
## **Giriş**

Java üzerinden PHP için Aspose.Slides'ı kullanarak bir slayta [OleObjectFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/oleobjectframe/) eklediğinizde, çıktıda bir "EMBEDDED OLE OBJECT" mesajı görüntülenir. Bu mesaj bilinçli olarak gösterilir ve bir hata **DEĞİLDİR**.

Daha fazla bilgi için [Manage OLE](/slides/tr/php-java/manage-ole/) bölümüne bakın. 

## **Açıklama ve Çözüm**

Aspose.Slides, OLE nesnesinin değiştiğini ve önizleme görüntüsünün güncellenmesi gerektiğini bildirmek için "EMBEDDED OLE OBJECT" mesajını gösterir. 

Örneğin, bir Microsoft Excel grafiğini [OleObjectFrame](https://reference.aspose.com/slides/tr/php-java/aspose.slides/oleobjectframe/) olarak bir slayta eklerseniz (daha fazla ayrıntı için "Manage OLE" makalesine bakın) ve ardından sunumu Microsoft PowerPoint'te açarsanız, slaytta aşağıdaki görüntüyü görürsünüz:

![OLE object message](OLE_object_message.png)

OLE nesnenizin slayta eklendiğini kontrol etmek ve onaylamak istiyorsanız, "EMBEDDED OLE OBJECT" mesajına çift tıklamanız gerekir veya üzerine sağ tıklayıp **Object > Edit** (Nesne > Düzenle) seçeneğini kullanabilirsiniz.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint ardından gömülü OLE nesnesini açar.

![OLE object data](OLE_object_data.png)

Slayt, "EMBEDDED OLE OBJECT" mesajını tutabilir. OLE nesnesine tıkladığınızda, slayt önizlemesi güncellenir ve "EMBEDDED OLE OBJECT" mesajı OLE nesnesinin gerçek görüntüsüyle değiştirilir. 

![OLE object preview](OLE_object_preview.png)

Şimdi, OLE Nesnesi için görüntünün doğru bir şekilde güncellenmesini sağlamak amacıyla sunumunuzu kaydetmek isteyebilirsiniz. Bu şekilde, sunumu kaydettikten sonra tekrar açtığınızda "EMBEDDED OLE OBJECT" mesajını **görmezsiniz**. 

## **Diğer Çözümler**

### **Çözüm 1: "Embedded OLE Object" Mesajını Bir Görüntüyle Değiştir**

Sunumu PowerPoint'te açıp kaydederek "EMBEDDED OLE OBJECT" mesajını kaldırmak istemiyorsanız, mesajı tercih ettiğiniz önizleme görüntüsüyle değiştirebilirsiniz. Aşağıdaki kod satırları bu süreci göstermektedir:

```php
$presentation = new Presentation("embeddedOLE.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $oleFrame = $slide->getShapes()->get_Item(0);

    // Sunuma bir görüntü ekle.
    $image = Images::fromFile("myImage.png");
    $oleImage = $presentation->getImages()->addImage($image);
    $image->dispose();

    // OLE nesne önizlemesi için bir başlık ve görüntü ayarla.
    $oleFrame->setSubstitutePictureTitle("My title");
    $oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
    $oleFrame->setObjectIcon(false);

    $presentation->save("embeddedOLE-newImage.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

`OleObjectFrame` içeren slayt aşağıdaki şekilde değişir:

![Yeni OLE nesnesi görüntüsü](OLE_object_new_image.png)

### **Çözüm 2: PowerPoint İçin Bir Eklenti Oluşturun**

Ayrıca, sunumları programda açtığınızda tüm OLE nesnelerini güncelleyen bir Microsoft PowerPoint eklentisi oluşturabilirsiniz.