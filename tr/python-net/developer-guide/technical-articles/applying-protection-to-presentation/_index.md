---
title: Python'da Şekil Kilitleri ile Sunum Düzenlemelerini Kısıtla
linktitle: Sunum Düzenlemelerini Kısıtla
type: docs
weight: 70
url: /tr/python-net/applying-protection-to-presentation/
keywords:
- düzenlemeleri engelle
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
description: "Aspose.Slides for Python via .NET ile PPTX sunumlarındaki şekilleri kilitlemeyi ve kilidini açmayı, seçim, hareket, yeniden boyutlandırma ve gruplamayı kısıtlama konusunda öğrenin."
---
## **Arka Plan**

Bir yaygın kullanım, Aspose.Slides for Python via .NET'in otomatik bir iş akışının parçası olarak PowerPoint (PPTX) sunumlarını oluşturmak, güncellemek ve kaydetmektir. Kullanıcılar bu sunumları aldıklarında, şekillerdeki değişiklikleri kısıtlamak, amaçlanan düzeni ve içeriği korumaya yardımcı olabilir.

Bu makale, şekillerin slaytlarda nasıl düzenlendiğini ve bir PPTX sunumunda şekil kilitlerinin nasıl uygulanıp kaldırılacağını açıklar. Bu kilitler, tek tek şekillerde belirli düzenleme işlemlerini kısıtlamanızı sağlar.

## **Bir Slaytın Bileşimi**

Bir sunum slaytı, otomatik şekiller, tablolar, OLE nesneleri, grup şekilleri, resim çerçeveleri, video çerçeveleri, bağlayıcılar ve bir sunum oluşturmak için kullanılan diğer öğeler gibi bileşenlerden oluşur. Aspose.Slides for Python via .NET'te, slayttaki her öğe, [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) sınıfından türetilen bir nesneyle temsil edilir.

Farklı şekil türleri farklı kilitleme seçenekleri sunar. [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) sınıfı, şekil kilitleri için temel sınıftır. Aspose.Slides for Python via .NET aşağıdaki kilit sınıflarını sağlar:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) otomatik şekilleri kilitler.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) bağlayıcı şekilleri kilitler.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) grafik nesneleri kilitler.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) grup şekilleri kilitler.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) resim çerçevelerini kilitler.  

Bir [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) üzerinde kilitleri uygulamak için, slaytlarını dolaşın ve her desteklenen şekil üzerinde uygun kilitleri ayarlayın.

## **Koruma Uygulama ve Kaldırma**

Uyumlu sunum düzenleyicileri, tek tek düzenleme işlemlerini kısıtlamak için şekil kilitlerini kullanır. Dosya şifrelemesi ve belge düzeyinde yazma koruması ayrı [sunum koruma ayarları](/slides/tr/python-net/password-protected-presentation/) olarak bulunur.

### **PPTX Şekillerine Koruma Uygulama**

Aspose.Slides for Python via .NET, bir slayttaki şekillerle çalışmak için [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) sınıfını sağlar.

Örnek, otomatik şekiller için [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/), ve [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) özelliklerini `True` olarak ayarlar; grup şekilleri, bağlayıcılar ve resim çerçeveleri için eşdeğer kilitler de uygulanır. Bağlayıcılar hareket için [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) kullanır; gruplar ayrıca gruplamayı kısıtlamak için [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) kullanır.

Örnek, mevcut bir PPTX sunumunu yükler, her slaydın şekil koleksiyonundaki şekilleri kontrol eder ve bu kısıtlamalar uygulanmış bir kopyayı kaydeder. Dört işlenen tip dışındaki şekiller değişmeden bırakılır. Döngü, bir grup içindeki alt şekilleri dolaşmaz.

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

Bir şekil kilidini kaldırmak için, değerini `False` olarak ayarlayın. Aşağıdaki örnek, şekil kilitleri bulunan bir sunumu yükler ve seçim, hareket ve yeniden boyutlandırma kısıtlamalarını [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/), ve [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) aracılığıyla temizler. Ayrıca [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) temizlenir ve sunumun bir kopyası kaydedilir. Diğer kilit ayarları değişmeden bırakılır.

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

### **Resim Kırpmasını Koru**

Çalışma dizinine `photo.jpg` adlı bir fotoğraf yerleştirin. Örnek, soldan %12 ve sağdan %8 kırpar, ardından resim çerçevesinde [crop_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/crop_locked/) ayarlar. Bu bayrak, daha fazla kırpmayı kısıtlar ve mevcut kırpmayı korur.

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

`PictureLocked.pptx` kırpma kilidini `True` olarak depolar. PowerPoint'te fotoğraf seçildiğinde **Crop** komutu devre dışı bırakılır.

### **Bir Diyagramı Gruplu Tut**

Örnek, bir dikdörtgen ve bir ok'u gruplar, ardından grup üzerinde [ungrouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/ungrouping_locked/) ayarını yaparak diyagram bileşenlerinin birlikte kalmasını sağlar. Grubu hareket ettirme veya bir bileşenin doldurulmasını değiştirme gibi diğer düzenlemeler kullanılabilir durumda kalır.

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

`DiagramLocked.pptx` gruplamayı kaldırma kilidini `True` olarak depolar. PowerPoint'te tüm diyagram seçildiğinde **Ungroup** komutu devre dışı bırakılır.

### **Mevcut Şekil Kilitlerini Raporla**

Bir şablonu incelemek için, şablonu açın ve her şekil için kilit nesnesini okuyun. [no_locks](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/no_locks/) tüm bayraklar devre dışı olduğunda `True`, en az bir bayrak etkin olduğunda `False` değerindedir. Bir grup ve onun çocukları ayrı kilit nesnelerine sahiptir, bu yüzden grup kilidi olmasa bile çocukları inceleyin.

Bu örnek, otomatik şekiller, resim çerçeveleri ve gruplar için hareketi, resimler için kırpmayı ve gruplar için gruplamayı kaldırmayı kontrol eder. Tanıdığı bayrakları raporlar ve incelemediği şekil türlerini işaretler.

```python
import aspose.slides as slides


def inspect_shapes(shapes, slide_number, prefix=""):
    for shape in shapes:
        path = prefix + shape.name
        label = f"Slide {slide_number} | {path} | {type(shape).__name__}"
        if not isinstance(shape, (slides.GroupShape, slides.PictureFrame, slides.AutoShape)):
            print(f"{label} | Uninspected")
            continue

        shape_lock = shape.shape_lock
        if not shape_lock.no_locks:
            flags = []
            if isinstance(shape, slides.GroupShape) and shape_lock.ungrouping_locked:
                flags.append("ungrouping_locked")
            if isinstance(shape, slides.PictureFrame) and shape_lock.crop_locked:
                flags.append("crop_locked")
            if shape_lock.position_locked:
                flags.append("position_locked")
            restrictions = ", ".join(flags) if flags else "Active flag not identified"
            print(f"{label} | {restrictions}")

        if isinstance(shape, slides.GroupShape):
            inspect_shapes(shape.shapes, slide_number, path + "/")


with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        inspect_shapes(slide.shapes, slide.slide_number)
```

`Sample.pptx` dosyasının 1. slaytının `Layout` adlı, gruplamayı kaldırma kilidi olan bir grup, içinde kırpma kilidi olan `Photo` adlı bir fotoğraf ve kilidi olmayan `Free` adlı bir dikdörtgen içerdiğini varsayalım. Rapor, `Free` öğesini atlar ve şu iki satırı yazdırır:

```text
Slide 1 | Layout | GroupShape | ungrouping_locked
Slide 1 | Layout/Photo | PictureFrame | crop_locked
```

Rapor, saklanan şekil düzeyindeki düzenleme bayraklarını değiştirmeden veya sunumu kaydetmeden okur. Belge düzeyinde yazma koruması ayrı bir ayardır ve her bayrağın uygulanması editöre bağlıdır.

### **Sonuç**

Aspose.Slides for Python via .NET, tek tek şekillerde belirli düzenleme işlemlerini kısıtlamanıza veya aynı kısıtlamaları slaytlar arasında uygulamanıza olanak tanır. Her şekil türü tarafından desteklenen kilitleri seçin ve bu kısıtlamaları kaldırmanız gerektiğinde değerlerini `False` olarak ayarlayın.

## **SSS**

**Şekil kilitlerini ve parola korumasını aynı sunumda birleştirebilir miyim?**

Evet. Şekil kilitleri belirli düzenleme işlemlerini kısıtlarken, [parola koruması](/slides/tr/python-net/password-protected-presentation/) sunumun açılmasını veya değiştirilmesini kısıtlayabilir. İkisini de aynı dosyada kullanabilirsiniz.

**Belirli slaytlarda düzenlemeyi, diğerlerini etkilemeden kısıtlayabilir miyim?**

Evet. Kilitleri yalnızca seçili slaytlardaki şekillere uygulayın. Bu, diğer slaytlardaki kilit ayarlarını değiştirmez.

**Bir grup içindeki tek tek şekillere nasıl kilit uygulayabilirim?**

Grubun [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) koleksiyonunda dolaşın ve her alt şekle uygun kilitleri uygulayın. Raporlama örneğindeki dolaşımı izleyerek, iç içe gruplar için de bu işlemi tekrarlayın.