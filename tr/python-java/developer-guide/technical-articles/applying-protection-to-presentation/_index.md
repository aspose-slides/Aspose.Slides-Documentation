---
title: Şekil Kilitleriyle Sunum Düzenlemelerini Önleyin
linktitle: Sunum Düzenlemelerini Önleme
type: docs
weight: 60
url: /tr/python-java/applying-protection-to-presentation/
keywords:
- düzenlemeleri önle
- düzenlemeden koru
- şekli kilitle
- konumu kilitle
- seçimi kilitle
- boyutu kilitle
- gruplamayı kilitle
- PowerPoint
- OpenDocument
- sunum
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java'un PPT, PPTX ve ODP dosyalarındaki şekilleri nasıl kilitlediğini veya kilidini açtığını keşfedin; sunumları güvence altına alırken kontrollü düzenlemelere ve daha hızlı teslimata olanak tanır."
---
## **Arka Plan**

Aspose.Slides'in yaygın bir kullanımı, otomatik bir iş akışının parçası olarak Microsoft PowerPoint (PPTX) sunumlarını oluşturmak, güncellemek ve kaydetmektir. Bu şekilde Aspose.Slides kullanan uygulamaların kullanıcıları oluşturulan sunumlara erişir, bu yüzden bunları düzenlemeden korumak yaygın bir endişedir. Otomatik olarak oluşturulan sunumların orijinal biçimlendirme ve içeriklerini koruması önemlidir.

Bu makale, sunumların ve slaytların nasıl yapılandırıldığını ve Aspose.Slides for Python via Java'nın bir sunuma nasıl koruma uygulayabileceğini ve daha sonra bunu nasıl kaldırabileceğini açıklar. Geliştiricilere, uygulamaları tarafından oluşturulan sunumların nasıl kullanılacağını kontrol etme yolu sağlar.

## **Bir Slaytın Bileşimi**

Bir sunum slaytı, otomatik şekiller, tablolar, OLE nesneleri, gruplanmış şekiller, resim çerçeveleri, video çerçeveleri, bağlayıcılar ve sunum oluşturmak için kullanılan diğer öğeler gibi bileşenlerden oluşur. Aspose.Slides for Python via Java'da, bir slayttaki her öğe, [Shape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/) sınıfından türetilen bir nesneyle temsil edilir.

PPTX'in yapısı karmaşıktır, bu yüzden tüm şekil türleri için genel bir kilit kullanılabilen PPT'den farklı olarak, farklı şekil türleri farklı kilitler gerektirir. [BaseShapeLock](https://reference.aspose.com/slides/tr/python-java/aspose.slides/baseshapelock/) sınıfı, PPTX için genel kilitleme sınıfıdır. Aspose.Slides for Python via Java'da PPTX için aşağıdaki kilit tipleri desteklenir:

- [AutoShapeLock](https://reference.aspose.com/slides/tr/python-java/aspose.slides/autoshapelock/) otomatik şekilleri kilitler.  
- [ConnectorLock](https://reference.aspose.com/slides/tr/python-java/aspose.slides/connectorlock/) bağlayıcı şekilleri kilitler.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/tr/python-java/aspose.slides/graphicalobjectlock/) grafik nesneleri kilitler.  
- [GroupShapeLock](https://reference.aspose.com/slides/tr/python-java/aspose.slides/groupshapelock/) grup şekillerini kilitler.  
- [PictureFrameLock](https://reference.aspose.com/slides/tr/python-java/aspose.slides/pictureframelock/) resim çerçevelerini kilitler.  

Bir [Presentation](https://reference.aspose.com/slides/tr/python-java/aspose.slides/presentation/) nesnesindeki tüm şekil nesneleri üzerinde gerçekleştirilen herhangi bir eylem, tüm sunuma uygulanır.

## **Koruma Uygulama ve Kaldırma**

Koruma uygulamak, bir sunumun düzenlenememesini sağlar. Sunum içeriğini korumak için faydalı bir tekniktir.

### **PPTX Şekillerine Koruma Uygulama**

Aspose.Slides for Python via Java, bir slayttaki şekillerle çalışmak için [Shape](https://reference.aspose.com/slides/tr/python-java/aspose.slides/shape/) sınıfını sağlar.

Daha önce belirtildiği gibi, her şekil sınıfının koruma için ilişkili bir şekil kilidi sınıfı vardır. Bu makale NoSelect, NoMove ve NoResize kilitlerine odaklanmaktadır. Bu kilitler, şekillerin (fare tıklamaları veya diğer seçim yöntemleriyle) seçilememesini ve taşınamamasını veya yeniden boyutlandırılamamasını sağlar.

Aşağıdaki kod örneği, bir sunumdaki tüm şekil türlerine koruma uygular.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

# Bir PPTX dosyasını temsil eden Presentation sınıfını örnekleyin.
presentation = Presentation("Sample.pptx")
try:
    # Sunumdaki tüm slaytları dolaşın.
    for slide in presentation.getSlides():
        # Slayttaki tüm şekilleri dolaşın.
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

    # Sunum dosyasını kaydedin.
    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Koruma Kaldırma**

Bir şeklin kilidini kaldırmak için, uygulanan kilidin değerini `False` olarak ayarlayın. Aşağıdaki kod örneği, kilitli bir sunumdaki şekillerin nasıl kilidinin açılacağını gösterir.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

# PPTX dosyasını temsil eden Presentation sınıfını örnekleyin.
presentation = Presentation("ProtectedSample.pptx")
try:
    # Sunumdaki tüm slaytları dolaşın.
    for slide in presentation.getSlides():
        # Slayttaki tüm şekilleri dolaşın.
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

    # Sunum dosyasını kaydedin.
    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Sonuç**

Aspose.Slides, bir sunumdaki şekilleri korumak için çeşitli seçenekler sunar. Tek bir şekli kilitleyebilir veya bir sunumdaki tüm şekiller üzerinde döngü yaparak her birini kilitleyebilir ve böylece tüm dosyayı etkili bir şekilde güvence altına alabilirsiniz. Kilitin değerini `False` olarak ayarlayarak korumayı kaldırabilirsiniz.

## **SSS**

**Aynı sunumda şekil kilitlerini ve şifre korumasını birleştirebilir miyim?**

Evet. Kilitler dosya içindeki nesnelerin düzenlenmesini sınırlar, [password protection](/slides/tr/python-java/password-protected-presentation/) ise açma ve/veya değişiklikleri kaydetme erişimini kontrol eder. Bu mekanizmalar birbirini tamamlar ve birlikte çalışır.

**Diğer slaytları etkilemeden belirli slaytlarda düzenlemeyi kısıtlayabilir miyim?**

Evet. Seçilen slaytlardaki şekillere kilitler uygulayın; kalan slaytlar düzenlenebilir kalır.

**Şekil kilitleri grup nesneleri ve bağlayıcılara uygulanır mı?**

Evet. Gruplar, bağlayıcılar, grafik nesneler ve diğer şekil türleri için özel kilit tipleri desteklenir.