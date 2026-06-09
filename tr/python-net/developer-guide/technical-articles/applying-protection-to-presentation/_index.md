---
title: Şekil Kilitleri ile Python'da Sunum Düzenlemelerini Önleme
linktitle: Sunum Düzenlemelerini Önleme
type: docs
weight: 70
url: /tr/python-net/applying-protection-to-presentation/
keywords:
- düzenlemeleri önleme
- düzenlemeden koruma
- şekli kilitle
- konumu kilitle
- seçimi kilitle
- boyutu kilitle
- gruplamayı kilitle
- PowerPoint
- OpenDocument
- sunum
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET'in PPT, PPTX ve ODP dosyalarındaki şekilleri nasıl kilitlediğini veya kilidini açtığını keşfedin; sunumları güvence altına alırken kontrollü düzenlemelere ve daha hızlı teslimata olanak tanır."
---
## **Background**

Aspose.Slides'ın yaygın bir kullanımı, otomatik bir iş akışının parçası olarak Microsoft PowerPoint (PPTX) sunumları oluşturmak, güncellemek ve kaydetmektir. Bu şekilde Aspose.Slides kullanan uygulamaların kullanıcıları oluşturulan sunumlara erişir, bu yüzden bunları düzenlemeden korumak yaygın bir endişedir. Otomatik olarak oluşturulan sunumların özgün biçimlendirmesini ve içeriğini koruması önemlidir.

Bu makale, sunumların ve slaytların nasıl yapılandırıldığını ve Aspose.Slides for Python'ın bir sunuma koruma uygulayıp daha sonra nasıl kaldırabileceğini açıklar. Geliştiricilere, uygulamalarının ürettiği sunumların nasıl kullanılacağını kontrol etme imkanı sağlar.

## **Composition of a Slide**

Bir sunum slaytı, otomatik şekiller, tablolar, OLE nesneleri, gruplanmış şekiller, resim çerçeveleri, video çerçeveleri, bağlayıcılar ve bir sunum oluşturmak için kullanılan diğer öğeler gibi bileşenlerden oluşur. Aspose.Slides for Python'da, bir slayttaki her öğe, [Shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/) sınıfından türeten bir nesneyle temsil edilir.

PPTX'in yapısı karmaşıktır, bu nedenle tüm şekil türleri için genel bir kilit kullanılabilen PPT'den farklı olarak, farklı şekil türleri farklı kilitler gerektirir. [BaseShapeLock](https://reference.aspose.com/slides/tr/python-net/aspose.slides/baseshapelock/) sınıfı, PPTX için genel kilitleme sınıfıdır. Aspose.Slides for Python'da PPTX için aşağıdaki kilit türleri desteklenir:

- [AutoShapeLock](https://reference.aspose.com/slides/tr/python-net/aspose.slides/autoshapelock/) otomatik şekilleri kilitler.  
- [ConnectorLock](https://reference.aspose.com/slides/tr/python-net/aspose.slides/connectorlock/) bağlayıcı şekilleri kilitler.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/tr/python-net/aspose.slides/graphicalobjectlock/) grafik nesneleri kilitler.  
- [GroupShapeLock](https://reference.aspose.com/slides/tr/python-net/aspose.slides/groupshapelock/) grup şekillerini kilitler.  
- [PictureFrameLock](https://reference.aspose.com/slides/tr/python-net/aspose.slides/pictureframelock/) resim çerçevelerini kilitler.  

[Presentation](https://reference.aspose.com/slides/tr/python-net/aspose.slides/presentation/) nesnesindeki tüm şekil nesnelerine yapılan herhangi bir işlem, bütün sunuma uygulanır.

## **Apply and Remove Protection**

Koruma uygulamak, bir sunumun düzenlenememesini sağlar. Sunum içeriğini korumak için faydalı bir tekniktir.

### **Apply Protection to PPTX Shapes**

Aspose.Slides for Python, bir slayttaki şekillerle çalışmak için [Shape](https://reference.aspose.com/slides/tr/python-net/aspose.slides/shape/) sınıfını sunar.

Daha önce belirtildiği gibi, her şekil sınıfının koruma için ilişkili bir shape‑lock sınıfı vardır. Bu makale NoSelect, NoMove ve NoResize kilitlerine odaklanmaktadır. Bu kilitler, şekillerin (fare tıklamaları veya diğer seçim yöntemleriyle) seçilememesini ve taşınamamasını veya yeniden boyutlandırılamamasını sağlar.

Aşağıdaki kod örneği, bir sunumdaki tüm şekil türlerine koruma uygular.

```py
import aspose.slides as slides

# Bir PPTX dosyasını temsil eden Presentation sınıfını örnekleyin.
with slides.Presentation("Sample.pptx") as presentation:
    # Sunumdaki tüm slaytları dolaşıyor.
    for slide in presentation.slides:
        # Slayttaki tüm şekilleri dolaşıyor.
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.GroupShape:
                shape.shape_lock.grouping_locked = True
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.Connector:
                shape.shape_lock.position_move = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.PictureFrame:
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
    # Sunum dosyasını kaydediyor.
    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Remove Protection**

Bir şeklin kilidini açmak için, uygulanan kilidin değerini `False` olarak ayarlayın. Aşağıdaki kod örneği, kilitli bir sunumdaki şekillerin kilidinin nasıl kaldırılacağını gösterir.

```py
import aspose.slides as slides

# PPTX dosyasını temsil eden Presentation sınıfını örnekleyin.
with slides.Presentation("ProtectedSample.pptx") as presentation:
    # Sunumdaki tüm slaytları dolaşıyor.
    for slide in presentation.slides:
        # Slayttaki tüm şekilleri dolaşıyor.
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.GroupShape:
                shape.shape_lock.grouping_locked = False
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.Connector:
                shape.shape_lock.position_move = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.PictureFrame:
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
    # Sunum dosyasını kaydediyor.
    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Conclusion**

Aspose.Slides, bir sunumdaki şekilleri korumak için çeşitli seçenekler sunar. Tek bir şekli kilitleyebilir veya bir sunumdaki tüm şekiller üzerinde döngü yaparak her birini kilitleyip dosyanın tamamını etkili bir şekilde güven altına alabilirsiniz. Kilit değerini `False` olarak ayarlayarak korumayı kaldırabilirsiniz.

## **FAQ**

**Can I combine shape locks and password protection in the same presentation?**

Evet. Kilitler, dosya içindeki nesnelerin düzenlenmesini sınırlandırırken, [password protection](/slides/tr/python-net/password-protected-presentation/) açma ve/veya değişiklikleri kaydetme erişimini kontrol eder. Bu mekanizmalar birbirini tamamlar ve birlikte çalışır.

**Can I restrict editing on specific slides without affecting others?**

Evet. Seçilen slaytlardaki şekillere kilitler uygulayın; kalan slaytlar düzenlenebilir kalır.

**Do shape locks apply to grouped objects and connectors?**

Evet. Gruplar, bağlayıcılar, grafik nesneler ve diğer şekil türleri için özel kilit türleri desteklenir.