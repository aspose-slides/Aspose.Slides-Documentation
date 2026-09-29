---
title: OleObjectFrame Ekleme Sırasında Nesne Önizleme Yer Tutucu
linktitle: OLE Önizleme Yer Tutucu
type: docs
weight: 10
url: /tr/java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- önizleme sorunu
- önizleme yer tutucu
- tasarım gereği
- gömülü nesne
- gömülü dosya
- nesne değişti
- nesne önizlemesi
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile eklenen bir OLE nesnesinin önizlemesi güncellenene kadar EMBEDDED OLE OBJECT yer tutucusunu göstermesinin nedeni ve kendi önizleme görüntünüzü nasıl ayarlayacağınız."
---
## **Giriş**

Aspose.Slides for Java kullanarak bir slayta [OleObjectFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/oleobjectframe/) eklediğinizde, çıktı slaytında "EMBEDDED OLE OBJECT" mesajı görüntülenir. Bu mesaj kasıtlıdır ve HATA DEĞİLDİR.

OLE nesneleriyle çalışmak hakkında daha fazla bilgi için, [Manage OLE](/slides/tr/java/manage-ole/) sayfasına bakın.

## **Açıklama ve Çözüm**

Aspose.Slides, OLE nesnesinin değiştirildiğini ve önizleme görüntüsünün güncellenmesi gerektiğini bildirmek için "EMBEDDED OLE OBJECT" mesajını gösterir.

Örneğin, bir Microsoft Excel grafiğini bir [OleObjectFrame](https://reference.aspose.com/slides/tr/java/com.aspose.slides/oleobjectframe/) olarak bir slayta eklediğinizde (daha fazla ayrıntı için "Manage OLE" makalesine bakın) ve ardından sunumu Microsoft PowerPoint'te açtığınızda, slaytta şu görüntüyü görürsünüz:

![OLE object message](OLE_object_message.png)

OLE nesnenizin slayta eklendiğini kontrol etmek ve doğrulamak istiyorsanız, "EMBEDDED OLE OBJECT" mesajına çift tıklamanız gerekir veya üzerine sağ tıklayıp **Object > Edit** seçeneğini izleyebilirsiniz.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint daha sonra gömülü OLE nesnesini açar.

![OLE object data](OLE_object_data.png)

Slayt, "EMBEDDED OLE OBJECT" mesajını tutabilir. OLE nesnesine tıkladığınızda slayt önizlemesi güncellenir ve "EMBEDDED OLE OBJECT" mesajı OLE nesnesinin gerçek görüntüsüyle değiştirilir.

![OLE object preview](OLE_object_preview.png)

Şimdi, OLE Nesnesi için görüntünün doğru şekilde güncellenmesini sağlamak amacıyla sunumunuzu kaydetmek isteyebilirsiniz. Böylece, sunumu kaydettikten sonra tekrar açtığınızda "EMBEDDED OLE OBJECT" mesajını GÖRMEYECEKSİNİZ.

## **Diğer Çözüm**

Sunumu PowerPoint'te açıp kaydederek "EMBEDDED OLE OBJECT" mesajını kaldırmak istemiyorsanız, mesajı tercih ettiğiniz önizleme görüntüsüyle değiştirebilirsiniz. Aşağıdaki kod satırları bu süreci göstermektedir. *embeddedOLE.pptx* dosyasının ilk slaydındaki ilk şeklin OLE nesne çerçevesi olduğunu ve *myImage.png*'nin gösterilecek görüntüyü içerdiğini varsayarlar ve sonucu *embeddedOLE-newImage.pptx* olarak kaydederler:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("embeddedOLE.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    // Sunuma bir resim ekle.
    IImage image = Images.fromFile("myImage.png");
    IPPImage oleImage = presentation.getImages().addImage(image);
    image.dispose();

    // OLE nesnesi önizlemesi için resmi ayarla.
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`OleObjectFrame` içeren slayt daha sonra şöyle değişir:

![New OLE object image](OLE_object_new_image.png)