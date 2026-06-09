---
title: OleObjectFrame Eklerken Nesne Önizleme Sorunu
linktitle: OLE Nesne Sorunu
type: docs
weight: 10
url: /tr/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- önizleme sorunu
- gömülü nesne
- gömülü dosya
- nesne değişti
- nesne önizleme
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'da OleObjectFrame eklediğinizde EMBEDDED OLE OBJECT ifadesinin neden göründüğünü ve PPT, PPTX ve ODP sunumlarında önizleme sorunlarını nasıl düzelteceğinizi öğrenin."
---
## **Giriş**

Aspose.Slides for Java kullanarak bir slayta [OleObjectFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/oleobjectframe/) eklediğinizde, çıktı slaydında "EMBEDDED OLE OBJECT" mesajı gösterilir. Bu mesaj kasıtlıdır ve bir hata DEĞİLDİR.

Daha fazla bilgi için, OLE nesneleriyle çalışma hakkında [Manage OLE](/slides/tr/java/manage-ole/) bölümüne bakın. 

## **Açıklama ve Çözüm**

Aspose.Slides, OLE nesnesinin değiştiğini ve önizleme görüntüsünün güncellenmesi gerektiğini bildirmek için "EMBEDDED OLE OBJECT" mesajını gösterir. 

Örneğin, bir slayta [OleObjectFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/oleobjectframe/) olarak bir Microsoft Excel grafik eklediğinizde (daha fazla ayrıntı için "Manage OLE" makalesine bakın) ve ardından sunumu Microsoft PowerPoint'te açtığınızda, slaytta şu görüntüyü görürsünüz:

![OLE object message](OLE_object_message.png)

OLE nesnenizin slayta eklendiğini kontrol edip doğrulamak istiyorsanız, "EMBEDDED OLE OBJECT" mesajına çift tıklamanız gerekir ya da ona sağ tıklayıp **Object > Edit** seçeneğini kullanabilirsiniz.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint ardından gömülü OLE nesnesini açar.

![OLE object data](OLE_object_data.png)

Slayt "EMBEDDED OLE OBJECT" mesajını tutabilir. OLE nesnesine tıkladığınızda, slayt önizlemesi güncellenir ve "EMBEDDED OLE OBJECT" mesajı OLE nesnesinin gerçek resmiyle değiştirilir. 

![OLE object preview](OLE_object_preview.png)

Şimdi, OLE Nesnesi için görüntünün doğru şekilde güncellenmesini sağlamak amacıyla sunumunuzu kaydetmek isteyebilirsiniz. Böylece, sunumu kaydettikten sonra tekrar açtığınızda "EMBEDDED OLE OBJECT" mesajını GÖRMEMEZSİNİZ. 

## **Diğer Çözümler**

### **Çözüm 1: "Embedded OLE Object" Mesajını Bir Görüntüyle Değiştir**

PowerPoint'te sunumu açıp kaydederek "EMBEDDED OLE OBJECT" mesajını kaldırmak istemiyorsanız, mesajı tercih ettiğiniz önizleme görüntüsüyle değiştirebilirsiniz. Bu kod satırları süreci gösterir:

```java
Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // Sunum kaynaklarına bir resim ekle.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);

    // OLE nesnesi önizlemesi için bir başlık ve resmi ayarla.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();    
}
```

`OleObjectFrame` içeren slayt daha sonra şu şekilde değişir:

![New OLE object image](OLE_object_new_image.png)

### **Çözüm 2: PowerPoint İçin Bir Eklenti Oluştur**

Programda sunumları açtığınızda tüm OLE nesnelerini güncelleyen bir Microsoft PowerPoint eklentisi de oluşturabilirsiniz.