---
title: OleObjectFrame Ekleme Sırasında Nesne Önizleme Sorunu
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
- nesne önizlemesi
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'da OleObjectFrame eklerken EMBEDDED OLE OBJECT neden göründüğünü ve PPT, PPTX ve ODP sunumlarındaki önizleme sorunlarını nasıl düzelteceğinizi öğrenin."
---
## **Giriş**

Aspose.Slides for Java kullanırken, bir slayta [OleObjectFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/oleobjectframe/) eklediğinizde, çıktı slaytında "EMBEDDED OLE OBJECT" mesajı gösterilir. Bu mesaj kasıtlıdır ve HATA değildir.

Daha fazla bilgi için OLE nesneleriyle çalışmak hakkında, [Manage OLE](/slides/tr/java/manage-ole/) sayfasına bakın. 

## **Açıklama ve Çözüm**

Aspose.Slides, OLE nesnesinin değiştiğini ve önizleme görüntüsünün güncellenmesi gerektiğini bildirmek için "EMBEDDED OLE OBJECT" mesajını gösterir. 

Örneğin, bir Microsoft Excel grafiğini bir [OleObjectFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/oleobjectframe/) olarak slayta eklerseniz (daha fazla ayrıntı için "Manage OLE" makalesine bakın) ve ardından sunumu Microsoft PowerPoint'te açarsanız, slaytta bu görüntüyü görürsünüz:

![OLE object message](OLE_object_message.png)

OLE nesnenizin slayta eklendiğini kontrol etmek ve doğrulamak istiyorsanız, "EMBEDDED OLE OBJECT" mesajına çift tıklamanız gerekir, ya da üzerine sağ tıklayıp **Object > Edit** seçeneğine gidebilirsiniz.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint daha sonra gömülü OLE nesnesini açar.

![OLE object data](OLE_object_data.png)

Slayt, "EMBEDDED OLE OBJECT" mesajını tutabilir. OLE nesnesine tıkladığınızda, slayt önizlemesi güncellenir ve "EMBEDDED OLE OBJECT" mesajı, OLE nesnesinin gerçek görüntüsüyle değiştirilir. 

![OLE object preview](OLE_object_preview.png)

Şimdi, OLE Nesnesi için görüntünün doğru şekilde güncellenmesini sağlamak amacıyla sunumunuzu kaydetmek isteyebilirsiniz. Böylece, sunumu kaydettikten sonra tekrar açtığınızda "EMBEDDED OLE OBJECT" mesajını GÖRMEYECEKSİNİZ. 

## **Diğer Çözüm**

Sunumu PowerPoint'te açıp kaydederek "EMBEDDED OLE OBJECT" mesajını kaldırmak istemiyorsanız, mesajı tercih ettiğiniz önizleme görüntüsüyle değiştirebilirsiniz. Aşağıdaki kod satırları bu süreci gösterir:

```java
import com.aspose.slides.*;

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

`OleObjectFrame` içeren slayt daha sonra şu şekilde değişir:

![New OLE object image](OLE_object_new_image.png)