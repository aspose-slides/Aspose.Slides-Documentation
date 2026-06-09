---
title: OleObjectFrame Eklerken Nesne Ön İzleme Sorunu
linktitle: OLE Nesne Sorunu
type: docs
weight: 10
url: /tr/cpp/object-preview-issue-when-adding-oleobjectframe/
keywords:
- OLE
- ön izleme sorunu
- gömülü nesne
- gömülü dosya
- nesne değişti
- nesne ön izleme
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++'ta OleObjectFrame eklerken EMBEDDED OLE OBJECT neden göründüğünü ve PPT, PPTX ve ODP sunumlarındaki ön izleme sorunlarını nasıl düzelteceğinizi öğrenin."
---
## **Giriş**

Aspose.Slides for C++ kullanırken bir slayta [OleObjectFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/oleobjectframe/) eklediğinizde, çıktı slaytında "EMBEDDED OLE OBJECT" mesajı gösterilir. Bu mesaj kasıtlıdır ve bir hata DEĞİLDİR.

OLE nesneleriyle çalışmak hakkında daha fazla bilgi için [OLE'yi Yönet](/slides/tr/cpp/manage-ole/) sayfasına bakın. 

## **Açıklama ve Çözüm**

Aspose.Slides, OLE nesnesinin değiştirildiğini ve ön izleme görüntüsünün güncellenmesi gerektiğini bildirmek için "EMBEDDED OLE OBJECT" mesajını gösterir. 

Örneğin, bir Microsoft Excel grafiğini bir [OleObjectFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/oleobjectframe/) olarak slayta ekleyip (daha fazla detay için "OLE'yi Yönet" makalesine bakın) sunumu Microsoft PowerPoint ile açarsanız, slaytta şu görseli görürsünüz:

![OLE nesne mesajı](OLE_object_message.png)

OLE nesnenizin slayta eklendiğini kontrol etmek ve doğrulamak istiyorsanız, "EMBEDDED OLE OBJECT" mesajına çift tıklamanız gerekir; ya da üzerine sağ tıklayıp **Object > Edit** seçeneğini kullanabilirsiniz.

![OLE nesne > Düzenle](OLE_object_edit.png)

PowerPoint ardından gömülü OLE nesnesini açar.

![OLE nesne verileri](OLE_object_data.png)

Slayt "EMBEDDED OLE OBJECT" mesajını tutabilir. OLE nesnesine tıkladığınızda, slayt ön izlemesi güncellenir ve "EMBEDDED OLE OBJECT" mesajı OLE nesnesinin gerçek görüntüsü ile değiştirilir. 

![OLE nesne ön izlemesi](OLE_object_preview.png)

Şimdi, OLE Nesnesinin görüntüsünün doğru şekilde güncellenmesini sağlamak için sununuzu kaydetmek isteyebilirsiniz. Bu şekilde, sunuyu kaydettikten sonra tekrar açtığınızda "EMBEDDED OLE OBJECT" mesajını GÖRMEYECEKSİNİZ. 

## **Diğer Çözümler**

### **Çözüm 1: "Embedded OLE Object" Mesajını Bir Görüntüyle Değiştirmek**

Sunuyu PowerPoint'te açıp kaydederek "EMBEDDED OLE OBJECT" mesajını kaldırmak istemiyorsanız, mesajı tercih ettiğiniz ön izleme görüntüsüyle değiştirebilirsiniz. Aşağıdaki kod satırları bu işlemi gösterir:

```cpp
auto presentation = MakeObject<Presentation>(u"embeddedOLE.pptx");

auto slide = presentation->get_Slide(0);
auto oleFrame = ExplicitCast<IOleObjectFrame>(slide->get_Shape(0));

// Add an image to presentation resources.
auto imageStream = File::OpenRead(u"myImage.png");
auto oleImage = presentation->get_Images()->AddImage(imageStream);
imageStream->Dispose();

// Set a title and the image for the OLE object preview.
oleFrame->set_SubstitutePictureTitle(u"My title");
oleFrame->get_SubstitutePictureFormat()->get_Picture()->set_Image(oleImage);
oleFrame->set_IsObjectIcon(false);

presentation->Save(u"embeddedOLE-newImage.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

`OleObjectFrame` içeren slayt daha sonra şu şekilde değişir:

![Yeni OLE nesne görüntüsü](OLE_object_new_image.png)

### **Çözüm 2: PowerPoint için Bir Eklenti Oluşturmak**

Microsoft PowerPoint için, programda bir sunu açtığınızda tüm OLE nesnelerini güncelleyen bir eklenti de oluşturabilirsiniz.