---
title: Android'de Şekil Kilitleri ile Sunum Düzenlemelerini Kısıtlama
linktitle: Sunum Düzenlemelerini Kısıtlama
type: docs
weight: 60
url: /tr/androidjava/applying-protection-to-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java ile PPTX sunumlarındaki şekilleri nasıl kilitleyip kilidini açacağınızı, seçim, taşıma, yeniden boyutlandırma ve gruplamayı nasıl kısıtlayacağınızı öğrenin."
---
## **Genel Bakış**

Aspose.Slides for Android via Java için yaygın bir kullanım, otomatik bir iş akışının parçası olarak PowerPoint (PPTX) sunumları oluşturmak, güncellemek ve kaydetmektir. Kullanıcılar bu sunumları aldıklarında, şekillerdeki değişiklikleri kısıtlamak, amaçlanan düzeni ve içeriği korumaya yardımcı olabilir.

Bu makale, şekillerin slaytlarda nasıl düzenlendiğini ve bir PPTX sunumunda şekil kilitlerinin nasıl uygulanıp kaldırılacağını açıklar. Bu kilitler, tek tek şekiller üzerinde belirli düzenleme işlemlerini kısıtlamanızı sağlar.

## **Bir Slaytın Bileşimi**

Bir sunum slaytı, otomatik şekiller, tablolar, OLE nesneleri, gruplandırılmış şekiller, resim çerçeveleri, video çerçeveleri, bağlayıcılar ve bir sunum oluşturmak için kullanılan diğer öğeler gibi bileşenlerden oluşur. Aspose.Slides for Android via Java'da, bir slayttaki her öğe, [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) arayüzünü uygulayan veya bu arayüzü miras alan bir nesne ile temsil edilir.

Farklı şekil türleri farklı kilitleme seçeneklerini sunar. [IBaseShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/) arayüzü, şekil kilitleri için temel arayüzdür. Aspose.Slides for Android via Java aşağıdaki kilit arayüzlerini sağlar:

- [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/) otomatik şekilleri kilitler.  
- [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) bağlayıcı şekilleri kilitler.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) grafik nesneleri kilitler.  
- [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/) grup şekilleri kilitler.  
- [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) resim çerçevelerini kilitler.  

Kilitleri bir [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) boyunca uygulamak için, slaytlarını yineleyin ve her desteklenen şekle uygun kilitleri ayarlayın.

## **Koruma Uygulama ve Kaldırma**

Şekil kilitleri, şekilleri seçme, taşıma ve yeniden boyutlandırma gibi işlemleri kısıtlar. Tüm sunumu düzenlenemez hale getirmezler.

### **PPTX Şekillerine Koruma Uygulama**

Aspose.Slides for Android via Java, bir slayttaki şekillerle çalışmak için [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) arayüzünü sağlar.

Örnek, otomatik şekiller için `true` ile [setSelectLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-) , [setPositionLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-) ve [setSizeLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) yöntemlerini çağırır; grup şekilleri, bağlayıcılar ve resim çerçeveleri için eşdeğer kilitler kullanılır. Bağlayıcılar hareket için [setPositionMove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) yöntemini; gruplar ise gruplamayı kısıtlamak için [setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) yöntemini kullanır.

Örnek, mevcut bir PPTX sunumunu yükler, her slaydın şekil koleksiyonundaki şekilleri kontrol eder ve bu kısıtlamalar uygulanmış bir kopya kaydeder. Dört işlenen tip dışındaki şekiller değişmeden bırakılır. Döngü, bir grup içindeki alt şekilleri dolaşmaz.

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

Bir şekil kilidini kaldırmak için, değerini `false` olarak ayarlayın. Aşağıdaki örnek, şekil kilitleriyle bir sunumu yükler ve seçim, taşıma ve yeniden boyutlandırma kısıtlamalarını [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/) , [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/) , [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) ve [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) aracılığıyla temizler. Ayrıca, gruplama kısıtlamasını, [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) yöntemine `false` geçirerek kaldırır ve sunumun bir kopyasını kaydeder. Diğer kilit ayarları değişmeden bırakılır.

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

Aspose.Slides for Android via Java, tek tek şekiller üzerinde belirli düzenleme işlemlerini kısıtlamanıza veya aynı kısıtlamaları slaytlar arasında uygulamanıza olanak tanır. Her şekil türü tarafından desteklenen kilitleri seçin ve bu kısıtlamaları kaldırmanız gerektiğinde değerlerini `false` olarak ayarlayın.

## **SSS**

**Aynı sunumda şekil kilitlerini ve parola korumasını birleştirebilir miyim?**

Evet. Şekil kilitleri belirli düzenleme işlemlerini kısıtlar, [parola koruması](/slides/tr/androidjava/password-protected-presentation/) ise sunumun açılmasını veya değiştirilmesini kısıtlayabilir. İkisini de aynı dosyada kullanabilirsiniz.

**Diğer slaytları etkilemeden belirli slaytlarda düzenlemeyi kısıtlayabilir miyim?**

Evet. Kilitleri yalnızca seçili slaytlardaki şekillere uygulayın. Bu, diğer slaytlardaki kilit ayarlarını değiştirmez.

**Bir grup içindeki tek tek şekillere nasıl kilit uygulayabilirim?**

Grubun [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) metodunun döndürdüğü koleksiyonu yineleyin ve her alt şekle uygun kilitleri uygulayın. İç içe gruplar için bunu tekrarlayın. Yukarıdaki örnekler yalnızca slaydın şekil koleksiyonunu işler, bu nedenle bireysel grup üyelerine kilit uygulamaz.