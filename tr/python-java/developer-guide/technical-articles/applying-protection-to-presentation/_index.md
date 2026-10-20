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
description: "Aspose.Slides for Python via Java ile PPTX sunumlarındaki şekilleri nasıl kilitleyeceğinizi ve kilidini açacağınızı öğrenin; seçim, taşıma, yeniden boyutlandırma ve gruplamayı kısıtlayın."
---
## **Arka Plan**

Aspose.Slides for Python via Java için sık kullanılan bir amaç, otomatik bir iş akışının parçası olarak PowerPoint (PPTX) sunumları oluşturmak, güncellemek ve kaydetmektir. Kullanıcılar bu sunumları aldığında, şekillerdeki değişiklikleri kısıtlamak, amaçlanan düzen ve içeriğin korunmasına yardımcı olabilir.

Bu makale, şekillerin slaytlarda nasıl düzenlendiğini ve bir PPTX sunumunda şekil kilitlerinin nasıl uygulanıp kaldırılacağını açıklar. Bu kilitler, tek tek şekiller üzerindeki belirli düzenleme işlemlerini kısıtlamanıza olanak tanır.

## **Bir Slaytın Bileşimi**

Bir sunum slaytı, otomatik şekiller, tablolar, OLE nesneleri, gruplanmış şekiller, resim çerçeveleri, video çerçeveleri, bağlayıcılar ve bir sunum oluşturmak için kullanılan diğer öğeler gibi bileşenlerden oluşur. Aspose.Slides for Python via Java'da bir slayttaki her öğe, [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) sınıfından türetilen bir nesne ile temsil edilir.

Farklı şekil türleri farklı kilitleme seçenekleri sunar. [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) sınıfı, şekil kilitlerinin temel sınıfıdır. Aspose.Slides for Python via Java aşağıdaki kilit sınıflarını sağlar:

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) autoshape'ları kilitler.  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) bağlayıcı şekilleri kilitler.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) grafik nesneleri kilitler.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) grup şekilleri kilitler.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) resim çerçevelerini kilitler.  

Kilitleri bir [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) boyunca uygulamak için slaytları üzerinde döngü yapın ve her desteklenen şekil üzerinde uygun kilitleri ayarlayın.

## **Uygula ve Kaldır Koruma**

Şekil kilitleri, şekilleri seçme, taşıma ve yeniden boyutlandırma gibi işlemleri kısıtlar. Tüm sunumu düzenlenemez hale getirmezler.

### **PPTX Şekillerine Koruma Uygulama**

Aspose.Slides for Python via Java, bir slayttaki şekillerle çalışmak için [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) sınıfını sağlar.

Örnek, otomatik şekiller için `True` ile [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked) ve [setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) metodlarını çağırır; grup şekilleri, bağlayıcılar ve resim çerçeveleri için eşdeğer kilitleri uygular. Bağlayıcılar hareket için [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) metodunu kullanır; gruplar da grup oluşturmayı kısıtlamak için [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) metodunu kullanır.

Örnek, mevcut bir PPTX sunumunu yükler, her slaydın şekil koleksiyonundaki şekilleri kontrol eder ve bu kısıtlamalar uygulanmış bir kopyasını kaydeder. Dört işlenen tür dışındaki şekiller değişmeden bırakılır. Döngü bir grup içindeki alt şekilleri dolaşmaz.

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

Bir şekil kilidini kaldırmak için değerini `False` olarak ayarlayın. Aşağıdaki örnek, şekil kilitleri olan bir sunumu yükler ve seçim, taşıma ve yeniden boyutlandırma kısıtlamalarını [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) ve [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) aracılığıyla temizler. Ayrıca, grup oluşturma kısıtlamasını [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) metoduna `False` geçirerek kaldırır ve sunumun bir kopyasını kaydeder. Diğer kilit ayarları değişmeden bırakılır.

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

### **Sonuç**

Aspose.Slides for Python via Java, tek tek şekiller üzerindeki belirli düzenleme işlemlerini kısıtlamanıza veya aynı kısıtlamaları slaytlar arasına uygulamanıza olanak tanır. Her şekil türü tarafından desteklenen kilitleri seçin ve bu kısıtlamaları kaldırmanız gerektiğinde değerlerini `False` olarak ayarlayın.

## **SSS**

**Aynı sunumda şekil kilitlerini ve şifre korumasını birleştirebilir miyim?**

Evet. Şekil kilitleri belirli düzenleme işlemlerini kısıtlarken, [şifre koruması](/slides/tr/python-java/password-protected-presentation/) sunumun açılmasını veya değiştirilmesini kısıtlayabilir. İkisini aynı dosyada kullanabilirsiniz.

**Belirli slaytlarda düzenlemeyi, diğerlerini etkilemeden kısıtlayabilir miyim?**

Evet. Kilitleri yalnızca seçilen slaytlardaki şekillere uygulayın. Bu, diğer slaytlardaki kilit ayarlarını değiştirmez.

**Bir grup içindeki tek tek şekillere kilit nasıl uygulayabilirim?**

Grubun [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) yöntemiyle dönen koleksiyon üzerinde yineleme yaparak her alt şekle uygun kilitleri uygulayın. Bunu iç içe gruplar için de tekrarlayın. Yukarıdaki örnekler yalnızca slaydın şekil koleksiyonunu işler, bu yüzden tek tek grup üyelerine kilit uygulamaz.