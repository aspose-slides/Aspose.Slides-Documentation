---
title: OleObjectFrame Ekleme Sırasında Nesne Önizleme Sorunu
linktitle: OLE Nesne Sorunu
type: docs
weight: 10
url: /tr/net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- önizleme sorunu
- gömülü nesne
- gömülü dosya
- nesne değişti
- nesne önizleme
- sunum
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'te OleObjectFrame eklerken EMBEDDED OLE OBJECT neden göründüğünü ve PPT, PPTX ve ODP sunumlarındaki önizleme sorunlarını nasıl düzelteceğinizi öğrenin."
---
## **Giriş**

Aspose.Slides for .NET kullanarak bir slayta [OleObjectFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/oleobjectframe) eklediğinizde, çıktı slaytında "EMBEDDED OLE OBJECT" mesajı gösterilir. Bu mesaj kasıtlıdır ve bir hata değildir.

OLE nesneleriyle çalışmak hakkında daha fazla bilgi için [OLE'yi Yönet](/slides/tr/net/manage-ole/) sayfasına bakın. 

## **Açıklama ve Çözüm**

Aspose.Slides, OLE nesnesinin değiştirildiğini ve önizleme görüntüsünün güncellenmesi gerektiğini bildirmek için "EMBEDDED OLE OBJECT" mesajını gösterir. 

Örneğin, bir Microsoft Excel grafiğini [OleObjectFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/oleobjectframe) olarak bir slayta eklediğinizde (daha fazla ayrıntı için "OLE'yi Yönet" makalesine bakın) ve ardından sunumu Microsoft PowerPoint'te açtığınızda, slaytta aşağıdaki görüntüyü görürsünüz:

![OLE nesnesi mesajı](OLE_object_message.png)

OLE nesnesinin slayta eklendiğini kontrol edip onaylamak isterseniz, "EMBEDDED OLE OBJECT" mesajına çift tıklamanız gerekir veya üzerine sağ tıklayıp **Object > Edit** seçeneğini kullanabilirsiniz.

![OLE nesnesi > Düzenle](OLE_object_edit.png)

PowerPoint, gömülü OLE nesnesini açar.

![OLE nesnesi verileri](OLE_object_data.png)

Slayt "EMBEDDED OLE OBJECT" mesajını tutabilir. OLE nesnesine tıkladığınızda, slayt önizlemesi güncellenir ve "EMBEDDED OLE OBJECT" mesajı OLE nesnesinin gerçek görüntüsüyle değiştirilir. 

![OLE nesnesi önizlemesi](OLE_object_preview.png)

Şimdi, OLE Nesnesi görüntüsünün doğru şekilde güncellenmesini sağlamak için sunumunuzu kaydetmek isteyebilirsiniz. Bu şekilde, sunumu kaydettikten ve tekrar açtıktan sonra "EMBEDDED OLE OBJECT" mesajını görmezsiniz. 

## **Diğer Çözümler**

### **Çözüm 1: "Embedded OLE Object" Mesajını Bir Görüntüyle Değiştirme**

"EMBEDDED OLE OBJECT" mesajını PowerPoint'te sunumu açıp kaydederek kaldırmak istemiyorsanız, mesajı tercih ettiğiniz önizleme görüntüsüyle değiştirebilirsiniz. Aşağıdaki kod satırları bu süreci gösterir:

```cs
using var presentation = new Presentation("embeddedOLE.pptx");

var slide = presentation.Slides[0];
var oleFrame = (IOleObjectFrame)slide.Shapes[0];

// Add an image to presentation resources.
using var imageStream = File.OpenRead("myImage.png");
var oleImage = presentation.Images.AddImage(imageStream);

// Set a title and the image for the OLE object preview.
oleFrame.SubstitutePictureTitle = "My title";
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
```

`OleObjectFrame` içeren slayt daha sonra şu şekilde değişir:

![Yeni OLE nesnesi görüntüsü](OLE_object_new_image.png)

### **Çözüm 2: PowerPoint İçin Bir Eklenti Oluşturma**

Microsoft PowerPoint için, programda sunumları açtığınızda tüm OLE nesnelerini güncelleyen bir eklenti de oluşturabilirsiniz.