---
title: OleObjectFrame Eklenirken Nesne Önizleme Sorunu
linktitle: OLE Nesne Sorunu
type: docs
weight: 10
url: /tr/nodejs-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- önizleme sorunu
- gömülü nesne
- gömülü dosya
- nesne değişti
- nesne önizleme
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js'te OleObjectFrame eklerken EMBEDDED OLE OBJECT neden göründüğünü ve PPT, PPTX ve ODP sunumlarındaki önizleme sorunlarını nasıl düzelteceğinizi öğrenin."
---
## **Giriş**

Aspose.Slides for Java kullanarak bir slayta [OleObjectFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/oleobjectframe/) eklediğinizde, çıktı slaytında "EMBEDDED OLE OBJECT" mesajı gösterilir. Bu mesaj kasıtlıdır ve bir hata DEĞİLDİR.

OLE nesneleriyle çalışmak hakkında daha fazla bilgi için [Manage OLE](/slides/tr/nodejs-java/manage-ole/) bölümüne bakın. 

## **Açıklama ve Çözüm**

Aspose.Slides, OLE nesnesinin değiştirildiğini ve önizleme görüntüsünün güncellenmesi gerektiğini size bildirmek için "EMBEDDED OLE OBJECT" mesajını gösterir. 

Örneğin, bir Microsoft Excel grafiğini bir [OleObjectFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/oleobjectframe/) olarak bir slayta eklerseniz (daha fazla detay için "Manage OLE" makalesine bakın) ve ardından sunumu Microsoft PowerPoint ile açarsanız, slaytta şu görüntüyü görürsünüz:

![OLE nesne mesajı](OLE_object_message.png)

OLE nesnesinin slayta eklendiğini kontrol etmek ve doğrulamak istiyorsanız, "EMBEDDED OLE OBJECT" mesajına çift tıklamanız gerekir veya üzerine sağ tıklayıp **Object > Edit** seçeneğini izleyebilirsiniz.

![OLE nesne > Düzenle](OLE_object_edit.png)

PowerPoint daha sonra gömülü OLE nesnesini açar.

![OLE nesne verileri](OLE_object_data.png)

Slayt, "EMBEDDED OLE OBJECT" mesajını koruyabilir. OLE nesnesine tıkladığınızda, slayt önizlemesi güncellenir ve "EMBEDDED OLE OBJECT" mesajı OLE nesnesinin gerçek görüntüsüyle değiştirilir. 

![OLE nesne önizlemesi](OLE_object_preview.png)

Şimdi, OLE Nesnesi için görüntünün doğru şekilde güncellenmesini sağlamak amacıyla sunumunuzu kaydetmek isteyebilirsiniz. Bu şekilde, sunumu kaydettikten sonra tekrar açtığınızda "EMBEDDED OLE OBJECT" mesajını görmeyeceksiniz. 

## **Diğer Çözümler**

### **Çözüm 1: "Embedded OLE Object" Mesajını Bir Görüntüyle Değiştirme**

PowerPoint'te sunumu açıp kaydederek "EMBEDDED OLE OBJECT" mesajını kaldırmak istemiyorsanız, mesajı tercih ettiğiniz önizleme görüntüsüyle değiştirebilirsiniz. Aşağıdaki kod satırları bu süreci gösterir:

```javascript
const presentation = new aspose.slides.Presentation("embeddedOLE.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const oleFrame = slide.getShapes().get_Item(0);

    // Sunum kaynaklarına bir resim ekleyin.
    const image = aspose.slides.Images.fromFile("myImage.png");
    const oleImage = presentation.getImages().addImage(image);

    // OLE nesnesi önizlemesi için bir başlık ve resmi ayarlayın.
    oleFrame.setSubstitutePictureTitle("My title");
    oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
    oleFrame.setObjectIcon(false);

    presentation.save("embeddedOLE-newImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

`OleObjectFrame` içeren slayt şu şekilde değişir:

![Yeni OLE nesne görüntüsü](OLE_object_new_image.png)

### **Çözüm 2: PowerPoint İçin Bir Eklenti Oluşturma**

Microsoft PowerPoint için bir eklenti oluşturarak, programda sunumları açtığınızda tüm OLE nesnelerinin güncellenmesini sağlayabilirsiniz.