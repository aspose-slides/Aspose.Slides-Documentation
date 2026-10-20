---
title: Python'da Şekil Kilitleriyle Sunum Düzenlemelerini Kısıtla
linktitle: Sunum Düzenlemelerini Kısıtla
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
description: "Aspose.Slides for Python via .NET ile PPTX sunumlarında şekilleri kilitleme ve kilidini açma, seçme, taşıma, yeniden boyutlandırma ve gruplamayı kısıtlama konularını öğrenin."
---
## **Arka Plan**

Aspose.Slides for Python via .NET'in yaygın bir kullanımı, otomatik bir iş akışının parçası olarak PowerPoint (PPTX) sunumları oluşturmak, güncellemek ve kaydetmektir. Kullanıcılar bu sunumları aldıklarında, şekillerdeki değişiklikleri kısıtlamak, amaçlanan düzeni ve içeriği korumaya yardımcı olur.

Bu makale, şekillerin slaytlarda nasıl düzenlendiğini ve bir PPTX sunumunda şekil kilitlerinin nasıl uygulanıp kaldırılacağını açıklar. Bu kilitler, tek tek şekiller üzerinde belirli düzenleme işlemlerini kısıtlamanızı sağlar.

## **Slayt Bileşimi**

Bir sunum slaytı, otomatik şekiller, tablolar, OLE nesneleri, gruplanmış şekiller, resim çerçeveleri, video çerçeveleri, bağlayıcılar ve bir sunum oluşturmak için kullanılan diğer öğeler gibi bileşenlerden oluşur. Aspose.Slides for Python via .NET'te, bir slayttaki her öğe, [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) sınıfından türeyen bir nesne ile temsil edilir.

Farklı şekil türleri farklı kilitleme seçenekleri sunar. [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) sınıfı, şekil kilitleri için temel sınıftır. Aspose.Slides for Python via .NET aşağıdaki kilit sınıflarını sağlar:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) otomatik şekilleri kilitler.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) bağlayıcı şekilleri kilitler.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) grafik nesneleri kilitler.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) grup şekillerini kilitler.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) resim çerçevelerini kilitler.  

Bir [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) üzerindeki kilitleri uygulamak için, slaytlarını dolaşın ve desteklenen her şekil üzerinde uygun kilitleri ayarlayın.

## **Koruma Uygulama ve Kaldırma**

Şekil kilitleri, şekilleri seçme, taşıma ve yeniden boyutlandırma gibi işlemleri kısıtlar. Tüm sunumu düzenlenemez hâle getirmezler.

### **PPTX Şekillerine Koruma Uygulama**

Aspose.Slides for Python via .NET, bir slayttaki şekillerle çalışmak için [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) sınıfını sağlar.

Örnek, otomatik şekiller için [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/) ve [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) değerlerini `True` olarak ayarlar; grup şekilleri, bağlayıcılar ve resim çerçeveleri için eşdeğer kilitler kullanılır. Bağlayıcılar hareket için [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) kullanır; gruplar da gruplayı kısıtlamak için [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) kullanır.

Örnek, mevcut bir PPTX sunumunu yükler, her slaytın şekil koleksiyonundaki şekilleri kontrol eder ve bu kısıtlamalar uygulanmış bir kopya olarak kaydeder. Dört işlenen tipin dışındaki şekiller değişmeden kalır. Döngü, bir grup içindeki alt şekilleri dolaşmaz.

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

Bir şekil kilidini kaldırmak için, değerini `False` olarak ayarlayın. Aşağıdaki örnek, şekil kilitleri bulunan bir sunumu yükler ve seçim, taşıma ve yeniden boyutlandırma kısıtlamalarını [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) ve [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) aracılığıyla temizler. Ayrıca [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) değerini temizler ve sunumun bir kopyasını kaydeder. Diğer kilit ayarları değişmeden kalır.

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

### **Sonuç**

Aspose.Slides for Python via .NET, tek tek şekiller üzerinde belirli düzenleme işlemlerini kısıtlamanıza veya aynı kısıtlamaları slaytlar arasında uygulamanıza olanak tanır. Her şekil türü tarafından desteklenen kilitleri seçin ve bu kısıtlamaları kaldırmanız gerektiğinde değerlerini `False` olarak ayarlayın.

## **SSS**

**Şekil kilitleri ile şifre korumasını aynı sunumda birleştirebilir miyim?**

Evet. Şekil kilitleri belirli düzenleme işlemlerini kısıtlarken, [şifre koruması](/slides/tr/python-net/password-protected-presentation/) sunumun açılmasını veya değiştirilmesini kısıtlayabilir. İkisini aynı dosyada kullanabilirsiniz.

**Belirli slaytlarda düzenlemeyi diğerlerini etkilemeden kısıtlayabilir miyim?**

Evet. Kilitleri yalnızca seçilen slaytlardaki şekillere uygularsınız. Bu, diğer slaytlardaki kilit ayarlarını değiştirmez.

**Bir grup içindeki tek tek şekillere nasıl kilit uygulayabilirim?**

Grubun [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) koleksiyonunda dolaşarak her alt şekle uygun kilitleri uygulayın. İç içe gruplar için de aynı işlemi tekrarlayın. Yukarıdaki örnekler yalnızca slaytın şekil koleksiyonunu işler, bu yüzden grup üyelerine kilit uygulamaz.