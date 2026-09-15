---
title: OleObjectFrame Eklerken Nesne Önizleme Sorunu
linktitle: OLE Nesne Sorunu
type: docs
weight: 10
url: /tr/python-java/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- önizleme sorunu
- gömülü nesne
- gömülü dosya
- nesne değişti
- nesne önizlemesi
- PowerPoint
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java'da OleObjectFrame eklerken EMBEDDED OLE OBJECT mesajının neden göründüğünü ve PPT, PPTX ve ODP sunumlarındaki önizleme sorunlarını nasıl düzelteceğinizi öğrenin."
---
## **Giriş**

Aspose.Slides for Python via Java'ı kullanarak bir slayta [OleObjectFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/oleobjectframe/) eklediğinizde, çıktıda bir "EMBEDDED OLE OBJECT" mesajı görüntülenir. Bu mesaj kasıtlıdır ve bir hata değildir.

Daha fazla bilgi için [OLE Yönetimi](/slides/tr/python-java/manage-ole/) adresine bakın.

## **Açıklama ve Çözüm**

Aspose.Slides, OLE nesnesinin değiştiğini ve önizleme görüntüsünün güncellenmesi gerektiğini bildirmek için "EMBEDDED OLE OBJECT" mesajını gösterir.

Örneğin, bir Microsoft Excel grafiğini [OleObjectFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/oleobjectframe/) olarak bir slayta eklerseniz (daha fazla ayrıntı için "OLE Yönetimi" makalesine bakın) ve ardından sunumu Microsoft PowerPoint'te açarsanız, slaytta şu görüntüyü görürsünüz:

![OLE nesne mesajı](OLE_object_message.png)

OLE nesnenizin slayta eklendiğini doğrulamak için "EMBEDDED OLE OBJECT" mesajına çift tıklayın veya sağ tıklayıp **Object > Edit** seçeneğini seçin.

![OLE nesne > Düzenle](OLE_object_edit.png)

PowerPoint daha sonra gömülü OLE nesnesini açar.

![OLE nesne verileri](OLE_object_data.png)

Slayt, "EMBEDDED OLE OBJECT" mesajını koruyabilir. OLE nesnesine tıkladığınızda, slayt önizlemesi güncellenir ve "EMBEDDED OLE OBJECT" mesajı OLE nesnesinin gerçek görüntüsüyle değiştirilir.

![OLE nesne önizlemesi](OLE_object_preview.png)

Güncellenmiş OLE nesnesi önizleme görüntüsünü korumak için sunumunuzu kaydedin. Sunumu tekrar açtığınızda "EMBEDDED OLE OBJECT" mesajını artık görmeyeceksiniz.

## **Diğer Çözüm**

Sunumu PowerPoint'te açıp kaydederek "EMBEDDED OLE OBJECT" mesajını kaldırmak istemiyorsanız, mesajı tercih ettiğiniz önizleme görüntüsüyle değiştirebilirsiniz. Aşağıdaki kod süreci gösterir:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat

presentation = Presentation("embeddedOLE.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # Sunuma bir resim ekle.
    image = Images.fromFile("myImage.png")
    try:
        ole_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # OLE nesne önizlemesi için bir başlık ve resmi ayarla.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(False)

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Bu durumda [OleObjectFrame](https://reference.aspose.com/slides/tr/python-java/aspose.slides/oleobjectframe/) içeren slayt şu şekilde değişir:

![Yeni OLE nesne resmi](OLE_object_new_image.png)

## **SSS**

**“EMBEDDED OLE OBJECT” mesajı neden ortaya çıkıyor?**

Mesaj, OLE nesnesinin değiştiğini ve önizleme görüntüsünün güncellenmesi gerektiğini gösterir. Bu davranış kasıtlıdır.

**Önizlemeyi PowerPoint'te nasıl güncellerim?**

Mesaja çift tıklayın veya **Object > Edit** seçeneğini seçerek gömülü OLE nesnesini açın. OLE nesnesine tıklayarak önizlemeyi güncelleyin, ardından sunumu kaydedin.

**Sunumu PowerPoint'te açmadan mesajı değiştirebilir miyim?**

Evet. Yukarıdaki kod örneğinde gösterildiği gibi OLE nesnesine tercih ettiğiniz bir önizleme görüntüsü atayabilirsiniz.