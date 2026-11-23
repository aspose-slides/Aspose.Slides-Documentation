---
title: Şekil Kilitleriyle Python'da Sunum Düzenlemelerini Kısıtlama
linktitle: Sunum Düzenlemelerini Kısıtlama
type: docs
weight: 70
url: /tr/python-net/applying-protection-to-presentation/
keywords:
- düzenlemeleri önle
- düzenlemeden koru
- şekli kilitle
- konumu kilitle
- seçimi kilitle
- yeniden boyutlandırmayı kilitle
- gruplamayı kilitle
- PowerPoint
- PPTX
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET ile PPTX sunumlarındaki şekilleri kilitlemeyi ve kilidini açmayı öğrenin; seçim, hareket, yeniden boyutlandırma ve gruplayıcıyı kısıtlayın."
---
## **Arka Plan**

Aspose.Slides for Python via .NET için yaygın bir kullanım, otomatik bir iş akışının parçası olarak PowerPoint (PPTX) sunumları oluşturmak, güncellemek ve kaydetmektir. Kullanıcılar bu sunumları aldıklarında, şekillerdeki değişiklikleri kısıtlamak, amaçlanan düzeni ve içeriği korumaya yardımcı olabilir.

Bu makale, şekillerin slaytlarda nasıl düzenlendiğini ve bir PPTX sunumunda şekil kilitlerinin nasıl uygulanıp kaldırılacağını açıklar. Bu kilitler, tek tek şekiller üzerinde belirli düzenleme işlemlerini kısıtlamanızı sağlar.

## **Bir Slaytın Bileşimi**

Bir sunum slaytı, otomatik şekiller, tablolar, OLE nesneleri, gruplanmış şekiller, resim çerçeveleri, video çerçeveleri, bağlayıcılar ve bir sunum oluşturmak için kullanılan diğer öğeler gibi bileşenlerden oluşur. Aspose.Slides for Python via .NET'de, bir slayttaki her öğe, [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) sınıfından türetilen bir nesneyle temsil edilir.

Farklı şekil tipleri farklı kilitleme seçenekleri sunar. [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) sınıfı, şekil kilitlerinin temel sınıfıdır. Aspose.Slides for Python via .NET aşağıdaki kilit sınıflarını sağlar:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) otomatik şekilleri kilitler.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) bağlayıcı şekilleri kilitler.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) grafik nesneleri kilitler.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) grup şekillerini kilitler.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) resim çerçevelerini kilitler.  

Bir [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) içinde kilitleri uygulamak için, slaytları üzerinden döngü yapın ve desteklenen her şekil üzerinde uygun kilitleri ayarlayın.

## **Koruma Uygulama ve Kaldırma**

Uyumlu sunum editörleri, tek tek düzenleme işlemlerini kısıtlamak için şekil kilitlerini kullanır. Dosya şifrelemesi ve belge seviyesindeki yazma koruması ayrı [sunum koruma ayarları](/slides/tr/python-net/password-protected-presentation/) olarak bulunur.

### **PPTX Şekillerine Koruma Uygulama**

Aspose.Slides for Python via .NET, bir slayttaki şekillerle çalışmak için [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) sınıfını sağlar.

Örnek, otomatik şekiller için [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/) ve [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) değerlerini `True` olarak ayarlar; grup şekilleri, bağlayıcılar ve resim çerçeveleri için eşdeğer kilitler bulunur. Bağlayıcılar hareket için [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) kullanır; gruplar ayrıca gruplayıcıyı kısıtlamak için [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) kullanır.

Örnek, mevcut bir PPTX sunumunu yükler, her slaytın şekil koleksiyonundaki şekilleri kontrol eder ve bu kısıtlamalar uygulanmış bir kopyasını kaydeder. Dört işlenen tip dışındaki şekiller değişmeden bırakılır. Döngü, bir grup içindeki alt şekilleri dolaşmaz.

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = True
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True

    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Koruma Kaldırma**

Bir şekil kilidini kaldırmak için, değerini `False` olarak ayarlayın. Aşağıdaki örnek, şekil kilitli bir sunumu yükler ve seçim, hareket ve yeniden boyutlandırma kısıtlamalarını [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) ve [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) üzerinden temizler. Ayrıca [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) öğesini temizler ve sunumun bir kopyasını kaydeder. Diğer kilit ayarları değişmeden bırakılır.

```python
import aspose.slides as slides

with slides.Presentation("ProtectedSample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = False
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False

    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Resim Kırpmasını Korumak**

Çalışma dizinine `photo.jpg` adlı bir fotoğraf yerleştirin. Örnek, soldan %12 ve sağdan %8 kırpar, ardından kırpmayı korumak için resim çerçevesine [crop_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/crop_locked/) uygular.

```python
from pathlib import Path

import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes

    photo_bytes = Path("photo.jpg").read_bytes()
    photo = presentation.images.add_image(photo_bytes)

    picture_frame = shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 30, 270, 160, photo)
    picture_frame.picture_format.crop_left = 12
    picture_frame.picture_format.crop_right = 8
    picture_frame.shape_lock.aspect_ratio_locked = False
    picture_frame.shape_lock.crop_locked = True

    presentation.save("PictureLocked.pptx", slides.export.SaveFormat.PPTX)
```

`PictureLocked.pptx` dosyası kırpma kilidini `True` olarak saklar. PowerPoint'te, fotoğraf seçildiğinde **Crop** komutu devre dışı bırakılır.

### **Bir Diyagramı Gruplu Tutmak**

Örnek, bir dikdörtgen ve bir ok'u gruplayıp ardından grup üzerinde [ungrouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/ungrouping_locked/) ayarlayarak diyagram bileşenlerinin bir arada kalmasını sağlar. Grubu taşıma veya bir bileşenin doldurmasını değiştirme gibi diğer düzenlemeler kullanılabilir durumda kalır.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes
    
    group_shape = shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 70, 90, 50)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RIGHT_ARROW, 190, 80, 60, 30)
    group_shape.shape_lock.ungrouping_locked = True

    presentation.save("DiagramLocked.pptx", slides.export.SaveFormat.PPTX)
```

`DiagramLocked.pptx` dosyası gruplamayı kaldırma kilidini `True` olarak saklar. PowerPoint'te, bütün diyagram seçildiğinde **Ungroup** komutu devre dışı bırakılır.

### **Sonuç**

Aspose.Slides for Python via .NET, tek tek şekillerde belirli düzenleme işlemlerini kısıtlamanıza veya aynı kısıtlamaları slaytlar boyunca uygulamanıza olanak tanır. Her şekil tipi tarafından desteklenen kilitleri seçin ve bu kısıtlamaları kaldırmanız gerektiğinde değerlerini `False` olarak ayarlayın.

## **SSS**

**Şekil kilitlerini ve şifre korumasını aynı sunumda birleştirebilir miyim?**

Evet. Şekil kilitleri belirli düzenleme işlemlerini kısıtlarken, [şifre koruması](/slides/tr/python-net/password-protected-presentation/) sunumun açılmasını veya değiştirilmesini kısıtlayabilir. Aynı dosyada ikisini de kullanabilirsiniz.

**Belirli slaytlarda düzenlemeyi, diğerlerini etkilemeden kısıtlayabilir miyim?**

Evet. Kilitleri yalnızca seçili slaytlardaki şekillere uygulayın. Bu, diğer slaytlardaki kilit ayarlarını değiştirmez.

**Bir grup içindeki tek tek şekillere nasıl kilit uygulayabilirim?**

Grubun [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) koleksiyonunda döngü yaparak her alt şekle uygun kilitleri uygulayın. Bu işlemi iç içe gruplar için de tekrarlayın. Yukarıdaki örnekler yalnızca slaytın şekil koleksiyonunu işler, bu yüzden bireysel grup üyelerine kilit uygulamaz.