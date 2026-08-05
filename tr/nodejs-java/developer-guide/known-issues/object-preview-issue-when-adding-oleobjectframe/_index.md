---
title: OleObjectFrame Ekleme Sırasında Nesne Ön İzleme Sorunu
linktitle: OLE Nesne Sorunu
type: docs
weight: 10
url: /tr/nodejs-java/object-preview-issue-when-adding-oleobjectframe/
aliases:
  - /nodejs-java/object-changed-issue-when-adding-oleobjectframe/
keywords:
- OLE
- ön izleme sorunu
- gömülü nesne
- gömülü dosya
- nesne değişti
- nesne ön izlemesi
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js'te OleObjectFrame eklerken EMBEDDED OLE OBJECT mesajının neden göründüğünü ve PPT, PPTX ve ODP sunumlarındaki ön izleme sorunlarını nasıl düzelteceğinizi öğrenin."
---
## **Giriş**

Aspose.Slides for Java kullanarak bir slayta [OleObjectFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/oleobjectframe/) eklediğinizde, çıktı slaytında "EMBEDDED OLE OBJECT" mesajı gösterilir. Bu mesaj kasıtlıdır ve HATA DEĞİLDİR.

OLE nesneleriyle çalışmak hakkında daha fazla bilgi için [OLE Nesnelerini Yönet](/slides/tr/nodejs-java/manage-ole/). 

## **Açıklama ve Çözüm**

Aspose.Slides, OLE nesnesinin değiştirildiğini ve ön izleme görüntüsünün güncellenmesi gerektiğini bildirmek için "EMBEDDED OLE OBJECT" mesajını gösterir. 

Örneğin, bir Microsoft Excel grafiğini bir [OleObjectFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/oleobjectframe/) olarak (daha fazla detay için "OLE'yi Yönet" makalesine bakın) slayta eklediğinizde ve ardından sunumu Microsoft PowerPoint'te açtığınızda, slaytta aşağıdaki görüntüyü görürsünüz:

![OLE nesne mesajı](OLE_object_message.png)

"E​M​B​E​D​D​E​D OLE OBJECT" mesajının eklendiğini doğrulamak istiyorsanız, mesaja çift tıklamanız veya sağ tıklayıp **Object > Edit** seçeneğini seçmeniz gerekir.

![OLE nesne > Düzenle](OLE_object_edit.png)

PowerPoint daha sonra gömülü OLE nesnesini açar.

![OLE nesne verisi](OLE_object_data.png)

Slayt "EMBEDDED OLE OBJECT" mesajını tutabilir. OLE nesnesine tıkladığınızda slaytın ön izlemesi güncellenir ve "EMBEDDED OLE OBJECT" mesajı OLE nesnesinin gerçek görüntüsüyle değiştirilir. 

![OLE nesne ön izlemesi](OLE_object_preview.png)

Şimdi, OLE Nesnesi görüntüsünün doğru şekilde güncellenmesini sağlamak için sunumunuzu kaydetmek isteyebilirsiniz. Bu şekilde, sunumu kaydettikten sonra tekrar açtığınızda "EMBEDDED OLE OBJECT" mesajını görmeyeceksiniz. 

## **Diğer Çözümler**

### **Çözüm 1: "Embedded OLE Object" Mesajını Bir Görüntüyle Değiştirin**

PowerPoint'te sunumu açıp kaydederek "EMBEDDED OLE OBJECT" mesajını kaldırmak istemiyorsanız, mesajı tercih ettiğiniz ön izleme görüntüsüyle değiştirebilirsiniz. Aşağıdaki kod satırları bu işlemi gösterir:

```javascript
const presentation = new aspose.slides.Presentation("embeddedOLE.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const oleFrame = slide.getShapes().get_Item(0);

    // Sunuma bir görüntü ekle.
    const image = aspose.slides.Images.fromFile("myImage.png");
    const oleImage = presentation.getImages().addImage(image);

    // OLE nesnesi ön izlemesi için bir başlık ve görüntü ayarla.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

`OleObjectFrame` içeren slayt daha sonra şu şekilde olur:

![Yeni OLE nesne görüntüsü](OLE_object_new_image.png)

### **Çözüm 2: PowerPoint İçin Bir Eklenti Oluşturun**

Microsoft PowerPoint için, sunumları programda açtığınızda tüm OLE nesnelerini güncelleyen bir eklenti de oluşturabilirsiniz.