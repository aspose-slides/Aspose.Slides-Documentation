---
title: OleObjectFrame Ekleme Sırasında Nesne Önizleme Sorunu
linktitle: OLE Nesne Sorunu
type: docs
weight: 10
url: /tr/python-net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- önizleme sorunu
- gömülü nesne
- gömülü dosya
- nesne değişti
- nesne önizlemesi
- sunum
- PowerPoint
- Python
- Aspose.Slides
description: "Aspose.Slides for Python'ta OleObjectFrame eklerken EMBEDDED OLE OBJECT'in neden göründüğünü ve PPT, PPTX ve ODP sunumlarındaki önizleme sorunlarını nasıl düzelteceğinizi öğrenin."
---
## **Giriş**

Aspose.Slides for Python via .NET kullanarak bir slayta [OleObjectFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/oleobjectframe/) eklediğinizde, çıktı slaydında “EMBEDDED OLE OBJECT” mesajı gösterilir. Bu mesaj bilerek gösterilir ve HATA değildir.

Daha fazla bilgi için OLE nesneleriyle çalışmak hakkında [Manage OLE](/slides/tr/python-net/manage-ole/) adresine bakın. 

## **Açıklama ve Çözüm**

Aspose.Slides, OLE nesnesinin değiştirildiğini ve önizleme görüntüsünün güncellenmesi gerektiğini bildirmek için “EMBEDDED OLE OBJECT” mesajını gösterir. 

Örneğin, bir Microsoft Excel çizelgesini bir [OleObjectFrame](https://reference.aspose.com/slides/tr/python-net/aspose.slides/oleobjectframe/) olarak bir slayta eklerseniz (daha fazla ayrıntı için “Manage OLE” makalesine bakın) ve ardından sunumu Microsoft PowerPoint’te açarsanız, slaytta şu görüntüyü görürsünüz:

![OLE nesne mesajı](OLE_object_message.png)

OLE nesnenizin slayta eklendiğini kontrol edip onaylamak istiyorsanız, “EMBEDDED OLE OBJECT” mesajına çift tıklamanız gerekir veya üzerine sağ tıklayıp **Object > Edit** seçeneğini izleyebilirsiniz.

![OLE nesne > Düzenle](OLE_object_edit.png)

PowerPoint ardından gömülü OLE nesnesini açar.

![OLE nesne verileri](OLE_object_data.png)

Slayt “EMBEDDED OLE OBJECT” mesajını tutabilir. OLE nesnesine tıkladığınızda, slayt önizlemesi güncellenir ve “EMBEDDED OLE OBJECT” mesajı OLE nesnesinin gerçek görüntüsüyle değiştirilir. 

![OLE nesne önizlemesi](OLE_object_preview.png)

Şimdi, OLE Nesnesi için görüntünün doğru şekilde güncellenmesini sağlamak amacıyla sunumunuzu kaydetmek isteyebilirsiniz. Böylece, sunumu kaydettikten sonra tekrar açtığınızda “EMBEDDED OLE OBJECT” mesajını GÖRMEYECEKSİNİZ. 

## **Diğer Çözümler**

### **Çözüm 1: “Embedded OLE Object” Mesajını Bir Görüntü ile Değiştirme**

PowerPoint’te sunumu açıp kaydederek “EMBEDDED OLE OBJECT” mesajını kaldırmak istemiyorsanız, mesajı tercih ettiğiniz önizleme görüntüsüyle değiştirebilirsiniz. Bu kod satırları süreci gösterir:

```py
with Presentation("embeddedOLE.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Sunuma bir resim ekle.
    with Images.from_file("myImage.png") as image:
        ole_image = presentation.images.add_image(image)

    # OLE nesnesi önizlemesi için bir başlık ve resmi ayarla.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = False

    presentation.save("embeddedOLE-newImage.pptx", SaveFormat.PPTX)
```

`OleObjectFrame` içeren slayt daha sonra şöyle değişir:

![Yeni OLE nesne görüntüsü](OLE_object_new_image.png)

### **Çözüm 2: PowerPoint İçin Bir Eklenti Oluşturma**

Microsoft PowerPoint için, programda sunumları açtığınızda tüm OLE nesnelerini güncelleyen bir eklenti de oluşturabilirsiniz.