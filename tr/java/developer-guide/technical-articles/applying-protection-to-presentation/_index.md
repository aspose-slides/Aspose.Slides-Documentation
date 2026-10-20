---
title: Java'da Şekil Kilitleri ile Sunum Düzenlemelerini Kısıtla
linktitle: Sunum Düzenlemelerini Kısıtla
type: docs
weight: 60
url: /tr/java/applying-protection-to-presentation/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile PPTX sunumlarındaki şekilleri kilitlemeyi ve kilidini kaldırmayı, seçim, hareket, yeniden boyutlandırma ve gruplamayı kısıtlamayı öğrenin."
---
## **Arka Plan**

Ortak bir kullanım, Aspose.Slides for Java’nın otomatik bir iş akışı içinde PowerPoint (PPTX) sunumlarını oluşturmak, güncellemek ve kaydetmektir. Kullanıcılar bu sunumları aldığında, şekillerdeki değişiklikleri kısıtlamak amaçlanan düzeni ve içeriği korumaya yardımcı olabilir.

Bu makale, şekillerin slaytlarda nasıl düzenlendiğini ve bir PPTX sunumunda şekil kilitlerinin nasıl uygulanıp kaldırıldığını açıklar. Bu kilitler, tek tek şekillerde belirli düzenleme işlemlerini kısıtlamanızı sağlar.

## **Slayt Bileşimi**

Bir sunum slaytı, otomatik şekiller, tablolar, OLE nesneleri, gruplanmış şekiller, resim çerçeveleri, video çerçeveleri, bağlayıcılar ve bir sunum oluşturmak için kullanılan diğer öğeler gibi bileşenlerden oluşur. Aspose.Slides for Java’da bir slayttaki her öğe, [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) arayüzünü uygulayan veya bu arayüzü miras alan bir nesneyle temsil edilir.

Farklı şekil türleri farklı kilitleme seçenekleri sunar. [IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/) arayüzü şekil kilitleri için temel arayüzdür. Aspose.Slides for Java aşağıdaki kilit arayüzlerini sağlar:

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) otomatik şekilleri kilitler.  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) bağlayıcı şekilleri kilitler.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) grafik nesneleri kilitler.  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) grup şekillerini kilitler.  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) resim çerçevelerini kilitler.  

Kilitleri bir [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) (sunum) üzerinde uygulamak için slaytlarını dolaşın ve her desteklenen şekilde uygun kilitleri ayarlayın.

## **Koruma Uygulama ve Kaldırma**

Şekil kilitleri, şekilleri seçme, taşıma ve yeniden boyutlandırma gibi işlemleri kısıtlar. Tüm sunumu düzenlenemez hâle getirmezler.

### **PPTX Şekillerine Koruma Uygulama**

Aspose.Slides for Java, bir slayttaki şekillerle çalışmak için [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) arayüzünü sağlar.

Örnek, otomatik şekiller için `true` ile [setSelectLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-) ve [setSizeLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) metodlarını çağırır, grup şekilleri, bağlayıcılar ve resim çerçeveleri için eşdeğer kilitleri kullanır. Bağlayıcılar hareket için [setPositionMove](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) kullanır; gruplar da gruplayıcıyı kısıtlamak için [setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) kullanır.

Örnek, mevcut bir PPTX sunumunu yükler, her slaydın şekil koleksiyonundaki şekilleri kontrol eder ve bu kısıtlamalar uygulanmış bir kopyasını kaydeder. Dört işlenen tür dışındaki şekiller değiştirilmeden bırakılır. Döngü, bir grup içindeki alt şekilleri dolaşmaz.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Koruma Kaldırma**

Bir şekil kilidini kaldırmak için değerini `false` olarak ayarlayın. Aşağıdaki örnek, şekil kilitleri olan bir sunumu yükler ve seçme, taşıma ve yeniden boyutlandırma kısıtlamalarını [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) ve [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) aracılığıyla temizler. Ayrıca, [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) metoduna `false` göndererek grup kısıtlamasını kaldırır ve sunumun bir kopyasını kaydeder. Diğer kilit ayarları değişmeden bırakılır.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ProtectedSample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Sonuç**

Aspose.Slides for Java, tek tek şekillerde belirli düzenleme işlemlerini kısıtlamanıza veya aynı kısıtlamaları slaytlar arasında uygulamanıza olanak tanır. Her şekil türü tarafından desteklenen kilitleri seçin ve bu kısıtlamaları kaldırmanız gerektiğinde değerlerini `false` olarak ayarlayın.

## **SSS**

**Şekil kilitlerini ve parola korumasını aynı sunumda birleştirebilir miyim?**  
Evet. Şekil kilitleri belirli düzenleme işlemlerini kısıtlarken, [parola koruması](/slides/tr/java/password-protected-presentation/) sunumun açılmasını veya değiştirilmesini kısıtlayabilir. İkisini aynı dosyada kullanabilirsiniz.

**Belirli slaytların düzenlemesini diğerlerini etkilemeden kısıtlayabilir miyim?**  
Evet. Kilitleri yalnızca seçilen slaytlardaki şekillere uygulayın. Bu, diğer slaytlardaki kilit ayarlarını değiştirmez.

**Bir grup içindeki tek tek şekillere nasıl kilit uygulayabilirim?**  
Grubun [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) metodunun döndürdüğü koleksiyonu dolaşın ve her alt şekle uygun kilitleri uygulayın. İç içe gruplar için de aynı işlemi tekrarlayın. Yukarıdaki örnekler yalnızca slaydın şekil koleksiyonunu işler, bu yüzden tek tek grup üyelerine kilit koymaz.