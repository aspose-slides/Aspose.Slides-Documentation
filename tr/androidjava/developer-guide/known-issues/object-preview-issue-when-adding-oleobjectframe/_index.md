---
title: OleObjectFrame Eklerken Nesne Önizleme Sorunu
linktitle: OLE Nesne Sorunu
type: docs
weight: 10
url: /tr/androidjava/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- önizleme sorunu
- gömülü nesne
- gömülü dosya
- nesne değişti
- nesne önizlemesi
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java kullanarak OleObjectFrame eklediğinizde EMBEDDED OLE OBJECT neden göründüğünü ve PPT, PPTX ve ODP sunumlarında önizleme sorunlarını nasıl düzelteceğinizi öğrenin."
---
## **Giriş**

Aspose.Slides for Android for Java kullanarak bir slayta [OleObjectFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/oleobjectframe/) eklediğinizde, çıktı slaytında "EMBEDDED OLE OBJECT" mesajı görüntülenir. Bu mesaj kasıtlıdır ve bir hata değildir.

OLE nesneleriyle çalışma hakkında daha fazla bilgi için [Manage OLE](/slides/tr/androidjava/manage-ole/) bölümüne bakın. 

## **Açıklama ve Çözüm**

Aspose.Slides, OLE nesnesinin değiştirildiğini ve önizleme görüntüsünün güncellenmesi gerektiğini bildirmek için "EMBEDDED OLE OBJECT" mesajını gösterir. 

Örneğin, bir Microsoft Excel grafiğini bir [OleObjectFrame](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/oleobjectframe/) olarak bir slayta eklediğinizde (daha fazla ayrıntı için "Manage OLE" makalesine bakın) ve ardından sunumu Microsoft PowerPoint'te açtığınızda, slaytta aşağıdaki görüntüyü görürsünüz:

![OLE object message](OLE_object_message.png)

OLE nesnesinin slayta eklendiğini kontrol edip onaylamak istiyorsanız, "EMBEDDED OLE OBJECT" mesajına çift tıklamanız gerekir veya üzerine sağ tıklayıp **Object > Edit** seçeneğini izleyebilirsiniz.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint daha sonra gömülü OLE nesnesini açar.

![OLE object data](OLE_object_data.png)

Slayt "EMBEDDED OLE OBJECT" mesajını tutabilir. OLE nesnesine tıkladığınızda, slayt önizlemesi güncellenir ve "EMBEDDED OLE OBJECT" mesajı OLE nesnesinin gerçek görüntüsüyle değiştirilir. 

![OLE object preview](OLE_object_preview.png)

Şimdi, OLE Nesnesi için görüntünün doğru şekilde güncellenmesini sağlamak amacıyla sunumunuzu kaydetmek isteyebilirsiniz. Bu şekilde, sunumu kaydettikten sonra tekrar açtığınızda "EMBEDDED OLE OBJECT" mesajını GÖRMEYECEKSİNİZ. 

## **Diğer Çözümler**

### **Çözüm 1: "Embedded OLE Object" Mesajını Bir Görüntüyle Değiştirin**

PowerPoint’te sunumu açıp kaydederek "EMBEDDED OLE OBJECT" mesajını kaldırmak istemiyorsanız, mesajı tercih ettiğiniz önizleme görüntüsüyle değiştirebilirsiniz. Aşağıdaki kod satırları bu süreci gösterir:

```java
Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // Sunum kaynaklarına bir görüntü ekleyin.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);

    // OLE nesnesi önizlemesi için bir başlık ve görüntü ayarlayın.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

`OleObjectFrame` içeren slayt daha sonra şu şekilde görünür:

![New OLE object image](OLE_object_new_image.png)

### **Çözüm 2: PowerPoint İçin Bir Eklenti Oluşturun**

Microsoft PowerPoint’te sunumları açtığınızda tüm OLE nesnelerini güncelleyen bir eklenti de oluşturabilirsiniz.