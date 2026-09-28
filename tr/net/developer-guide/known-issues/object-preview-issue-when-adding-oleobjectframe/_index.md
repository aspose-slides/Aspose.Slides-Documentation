---
title: OleObjectFrame eklerken Nesne Önizleme Yer Tutucu
linktitle: OLE Önizleme Yer Tutucu
type: docs
weight: 10
url: /tr/net/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- önizleme sorunu
- önizleme yer tutucu
- tasarım gereği
- gömülü nesne
- gömülü dosya
- nesne değişti
- nesne önizlemesi
- sunum
- PowerPoint
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile eklenen bir OLE nesnesinin önizlemesi güncellenene kadar EMBEDDED OLE OBJECT yer tutucusunu göstermesinin nedeni ve kendi önizleme görüntünüzü nasıl ayarlayacağınız."
---
## **Giriş**

Aspose.Slides for .NET'i kullanarak bir slayta [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/) eklediğinizde, çıktı slaytında "EMBEDDED OLE OBJECT" mesajı gösterilir. Bu mesaj kasıtlıdır ve HATA DEĞİLDİR.

Daha fazla bilgi için OLE nesneleriyle çalışmak hakkında [Manage OLE](/slides/tr/net/manage-ole/) sayfasına bakın.

## **Açıklama ve Çözüm**

Aspose.Slides, OLE nesnesinin değiştirildiğini ve ön izleme görüntüsünün güncellenmesi gerektiğini bildirmek için "EMBEDDED OLE OBJECT" mesajını gösterir.

Örneğin, bir Microsoft Excel grafiğini bir [OleObjectFrame](https://reference.aspose.com/slides/net/aspose.slides/oleobjectframe/) olarak bir slayta eklerseniz (daha fazla ayrıntı için "Manage OLE" makalesine bakın) ve ardından sunuyu Microsoft PowerPoint'te açarsanız, slaytta aşağıdaki görüntüyü görürsünüz:

![OLE object message](OLE_object_message.png)

OLE nesnenizin slayta eklendiğini kontrol etmek ve doğrulamak istiyorsanız, "EMBEDDED OLE OBJECT" mesajına çift tıklamanız gerekir veya ona sağ tıklayıp **Object > Edit** seçeneğine gidebilirsiniz.

![OLE object > Edit](OLE_object_edit.png)

PowerPoint daha sonra gömülü OLE nesnesini açar.

![OLE object data](OLE_object_data.png)

Slayt, "EMBEDDED OLE OBJECT" mesajını koruyabilir. OLE nesnesine tıkladığınızda, slayt ön izlemesi güncellenir ve "EMBEDDED OLE OBJECT" mesajı OLE nesnesinin gerçek görüntüsüyle değiştirilir.

![OLE object preview](OLE_object_preview.png)

Şimdi, OLE Nesnesinin görüntüsünün doğru şekilde güncellendiğinden emin olmak için sununuzu kaydetmek isteyebilirsiniz. Böylece, sunuyu kaydettikten sonra tekrar açtığınızda "EMBEDDED OLE OBJECT" mesajını GÖRMEYECEKSİNİZ.

## **Diğer Çözümler**

### **Çözüm 1: "Embedded OLE Object" Mesajını Bir Görüntüyle Değiştirme**

Sunuyu PowerPoint'te açıp kaydederek "EMBEDDED OLE OBJECT" mesajını kaldırmak istemiyorsanız, mesajı tercih ettiğiniz ön izleme görüntüsüyle değiştirebilirsiniz. Aşağıdaki kod satırları bu süreci göstermektedir:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("embeddedOLE.pptx");

var slide = presentation.Slides[0];
var oleFrame = (IOleObjectFrame)slide.Shapes[0];

// Sunum kaynaklarına bir resim ekle.
using var imageStream = File.OpenRead("myImage.png");
var oleImage = presentation.Images.AddImage(imageStream);

// OLE nesnesi önizlemesi için resmi ayarla.
oleFrame.SubstitutePictureFormat.Picture.Image = oleImage;
oleFrame.IsObjectIcon = false;

presentation.Save("embeddedOLE-newImage.pptx", SaveFormat.Pptx);
```

`OleObjectFrame` içeren slayt daha sonra şöyle değişir:

![New OLE object image](OLE_object_new_image.png)

### **Çözüm 2: PowerPoint İçin Bir Eklenti Oluşturma**

Programda sunuları açtığınızda tüm OLE nesnelerini güncelleyen bir Microsoft PowerPoint eklentisi de oluşturabilirsiniz.