---
title: Python'da Şekil Kilitleriyle Sunum Düzenlemelerini Kısıtlayın
linktitle: Sunum Düzenlemelerini Kısıtla
type: docs
weight: 60
url: /tr/python-java/applying-protection-to-presentation/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java ile PPTX sunumlarında şekilleri kilitleyip kilidini açarak seçim, hareket, yeniden boyutlandırma ve gruplamayı nasıl kısıtlayacağınızı öğrenin."
---
## **Arka Plan**

Aspose.Slides for Python via Java için yaygın bir kullanım, otomatik bir iş akışının parçası olarak PowerPoint (PPTX) sunumları oluşturmak, güncellemek ve kaydetmektir. Kullanıcılar bu sunumları aldığında, şekillerdeki değişiklikleri kısıtlamak, amaçlanan düzeni ve içeriği korumaya yardımcı olabilir.

Bu makale, şekillerin slaytlarda nasıl düzenlendiğini ve bir PPTX sunumunda şekil kilitlerinin nasıl uygulanıp kaldırılacağını açıklar. Bu kilitler, bireysel şekiller üzerindeki belirli düzenleme işlemlerini kısıtlamanızı sağlar.

## **Bir Slaytın Bileşimi**

Bir sunum slaytı, otomatik şekiller, tablolar, OLE nesneleri, gruplandırılmış şekiller, resim çerçeveleri, video çerçeveleri, bağlayıcılar ve bir sunum oluşturmak için kullanılan diğer öğeler gibi bileşenlerden oluşur. Aspose.Slides for Python via Java'da, bir slayttaki her öğe, [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) sınıfından türeten bir nesneyle temsil edilir.

Farklı şekil türleri farklı kilitleme seçenekleri sunar. [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) sınıfı şekil kilitlerinin temel sınıfıdır. Aspose.Slides for Python via Java aşağıdaki kilit sınıflarını sağlar:

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) otomatik şekilleri kilitler.  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) bağlayıcı şekilleri kilitler.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) grafik nesneleri kilitler.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) grup şekilleri kilitler.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) resim çerçevelerini kilitler.  

Bir [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) üzerinde kilitleri uygulamak için, slaytlarını döngüyle gezerek her desteklenen şekil üzerinde uygun kilitleri ayarlayın.

## **Koruma Uygulama ve Kaldırma**

Uyumlu sunum editörleri, bireysel düzenleme işlemlerini kısıtlamak için şekil kilitlerini kullanır. Dosya şifrelemesi ve belge düzeyinde yazma koruması ayrı [sunum koruma ayarları](/slides/tr/python-java/password-protected-presentation/) olarak bulunur.

### **PPTX Şekillerine Koruma Uygulama**

Aspose.Slides for Python via Java, bir slayttaki şekillerle çalışmak için [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) sınıfını sağlar.

Örnek, otomatik şekiller için `True` değeriyle [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked) ve [setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) metodlarını, grup şekilleri, bağlayıcılar ve resim çerçeveleri için eşdeğer kilitleri çağırır. Bağlayıcılar hareket için [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) metodunu kullanır; gruplar ayrıca gruplamayı kısıtlamak için [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) metodunu kullanır.

Örnek, mevcut bir PPTX sunumunu yükler, her slaydın şekil koleksiyonundaki şekilleri kontrol eder ve bu kısıtlamalar uygulanmış bir kopya kaydeder. Dört işlenen tür dışındaki şekiller değişmeden kalır. Döngü, bir grup içindeki alt şekilleri dolaşmaz.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(True)
                auto_shape_lock.setSelectLocked(True)
                auto_shape_lock.setSizeLocked(True)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(True)
                group_shape_lock.setPositionLocked(True)
                group_shape_lock.setSelectLocked(True)
                group_shape_lock.setSizeLocked(True)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(True)
                connector_shape_lock.setSelectLocked(True)
                connector_shape_lock.setSizeLocked(True)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(True)
                picture_frame_lock.setSelectLocked(True)
                picture_frame_lock.setSizeLocked(True)

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Koruma Kaldırma**

Bir şekil kilidini kaldırmak için değerini `False` olarak ayarlayın. Aşağıdaki örnek, şekil kilitleriyle bir sunum yükler ve seçim, hareket ve yeniden boyutlandırma kısıtlamalarını [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) ve [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) aracılığıyla temizler. Ayrıca, [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) metoduna `False` geçirerek gruplama kısıtlamasını kaldırır ve sunumun bir kopyasını kaydeder. Diğer kilit ayarları değişmeden kalır.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("ProtectedSample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(False)
                auto_shape_lock.setSelectLocked(False)
                auto_shape_lock.setSizeLocked(False)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(False)
                group_shape_lock.setPositionLocked(False)
                group_shape_lock.setSelectLocked(False)
                group_shape_lock.setSizeLocked(False)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(False)
                connector_shape_lock.setSelectLocked(False)
                connector_shape_lock.setSizeLocked(False)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(False)
                picture_frame_lock.setSelectLocked(False)
                picture_frame_lock.setSizeLocked(False)

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Resim Kırpmasını Koru**

Çalışma dizinine `photo.jpg` adlı bir fotoğraf yerleştirin. Örnek, soldan %12, sağdan %8 kırpar ve ardından kırpmayı korumak için `True` değeriyle [setCropLocked](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/#setCropLocked) metodunu çağırır.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()

    photo_bytes = Path("photo.jpg").read_bytes()
    photo = presentation.getImages().addImage(photo_bytes)
    
    picture_frame = shapes.addPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo)
    picture_frame.getPictureFormat().setCropLeft(12)
    picture_frame.getPictureFormat().setCropRight(8)

    picture_lock = picture_frame.getPictureFrameLock()
    picture_lock.setAspectRatioLocked(False)
    picture_lock.setCropLocked(True)

    presentation.save("PictureLocked.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`PictureLocked.pptx` içinde, PowerPoint fotoğrafı seçtiğinizde **Crop** komutunu devre dışı bırakır.

### **Bir Diyagramı Gruplu Tut**

Örnek, bir dikdörtgen ve bir ok gruplar ve ardından iki şekli bir arada tutmak için `True` değeriyle [setUngroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setUngroupingLocked) metodunu çağırır. Grubu hâlâ hareket ettirebilir veya bir bileşenin dolgusunu değiştirebilirsiniz.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()

    group = shapes.addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 100, 70, 90, 50)
    group.getShapes().addAutoShape(ShapeType.RightArrow, 190, 80, 60, 30)
    group.getGroupShapeLock().setUngroupingLocked(True)

    presentation.save("DiagramLocked.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`DiagramLocked.pptx` içinde, PowerPoint tüm diyagramı seçtiğinizde **Ungroup** komutunu devre dışı bırakır.

### **Mevcut Şekil Kilitlerini Raporla**

Bir şablonu incelemek için açın ve her şekil için kilit nesnesini okuyun. [getNoLocks](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/#getNoLocks) yöntemi, o nesnedeki tüm bayraklar devre dışı bırakıldığında `True`, en az biri etkin olduğunda `False` döndürür. Bir grup ve onun alt öğeleri ayrı kilit nesnelerine sahiptir; bu nedenle grup kilidi olmasa bile alt öğeleri denetleyin.

Bu örnek, otomatik şekiller, resim çerçeveleri ve gruplar için hareketi, resimler için kırpmayı ve gruplar için gruptan çıkmayı kontrol eder. Rapor, tanıdığı etkin bayrakları listeler ve incelemediği şekil türlerini işaretler.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, GroupShape, PictureFrame, Presentation


def inspect_shapes(shapes, slide_number, prefix=""):
    for shape in shapes:
        path = f"{prefix}{shape.getName()}"
        label = f"Slide {slide_number} | {path} | {shape.getClass().getSimpleName()}"
        flags = []

        if isinstance(shape, GroupShape):
            shape_lock = shape.getGroupShapeLock()
            if shape_lock.getUngroupingLocked():
                flags.append("UngroupingLocked")
        elif isinstance(shape, PictureFrame):
            shape_lock = shape.getPictureFrameLock()
            if shape_lock.getCropLocked():
                flags.append("CropLocked")
        elif isinstance(shape, AutoShape):
            shape_lock = shape.getAutoShapeLock()
        else:
            print(f"{label} | Uninspected")
            continue

        if shape_lock.getPositionLocked():
            flags.append("PositionLocked")
        if not shape_lock.getNoLocks():
            restrictions = ", ".join(flags) if flags else "Active flag not identified"
            print(f"{label} | {restrictions}")

        if isinstance(shape, GroupShape):
            inspect_shapes(shape.getShapes(), slide_number, f"{path}/")


presentation = Presentation("Sample.pptx")
try:
    for slide in presentation.getSlides():
        inspect_shapes(slide.getShapes(), slide.getSlideNumber())
finally:
    presentation.dispose()
```

Örneğin, `Sample.pptx` dosyasının 1. slaydı, gruplama kilidi açılmış bir `Free` adlı dikdörtgen, kırpma kilidi olan `Photo` adlı bir resim ve gruptan çıkma kilidi olan `Layout` adlı bir grup içerdiğini varsayalım. Rapor `Free` öğesini atlar ve şu iki satırı yazdırır:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Rapor, saklanan şekil‑seviyesi düzenleme bayraklarını değiştirmeden veya sunumu kaydetmeden okur. Belge‑düzeyinde yazma koruması ayrı bir ayardır ve her bayrağın uygulanması editöre bağlıdır.

## **Sonuç**

Aspose.Slides for Python via Java, bireysel şekiller üzerinde belirli düzenleme işlemlerini kısıtlamanıza veya aynı kısıtlamaları slaytlar arasında uygulamanıza olanak tanır. Her şekil türü tarafından desteklenen kilitleri seçin ve bu kısıtlamaları kaldırmanız gerektiğinde değerlerini `False` olarak ayarlayın.

## **FAQ**

**Şekil kilitlerini ve parola korumasını aynı sunumda birleştirebilir miyim?**

Evet. Şekil kilitleri belirli düzenleme işlemlerini kısıtlarken, [parola koruması](/slides/tr/python-java/password-protected-presentation/) sunumun açılmasını veya değiştirilmesini kısıtlayabilir. İkisini aynı dosyada birlikte kullanabilirsiniz.

**Belirli slaytlarda düzenlemeyi kısıtlayıp diğerlerini etkilemeden yapabilir miyim?**

Evet. Kilitleri yalnızca seçilen slaytlardaki şekillere uygulayın. Bu, diğer slaytlardaki kilit ayarlarını değiştirmez.

**Bir grup içindeki bireysel şekillere kilitleri nasıl uygularım?**

Grubun [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) yöntemiyle döndürülen koleksiyonu dolaşarak her alt şekle uygun kilitleri uygulayın. İç içe gruplar için de aynı yöntemi, raporlama örneğinde olduğu gibi tekrarlayın.