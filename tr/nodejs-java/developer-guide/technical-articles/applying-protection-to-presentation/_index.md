---
title: "Node.js'te Şekil Kilitleri ile Sunum Düzenlemelerini Kısıtlama"
linktitle: "Sunum Düzenlemelerini Kısıtlama"
type: docs
weight: 60
url: /tr/nodejs-java/applying-protection-to-presentation/
keywords:
- "düzenlemeleri önle"
- "düzenlemeden koru"
- "şekli kilitle"
- "konumu kilitle"
- "seçimi kilitle"
- "yeniden boyutlandırmayı kilitle"
- "gruplamayı kilitle"
- "PowerPoint"
- "PPTX"
- "sunum"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Aspose.Slides for Node.js via Java ile PPTX sunumlarındaki şekilleri nasıl kilitleneceğini ve kilidi kaldırılacağını öğrenin; seçim, hareket, yeniden boyutlandırma ve gruplamayı kısıtlayın."
---
## **Genel Bakış**

Aspose.Slides for Node.js via Java’ın yaygın bir kullanım amacı, otomatik bir iş akışının parçası olarak PowerPoint (PPTX) sunumları oluşturmak, güncellemek ve kaydetmektir. Kullanıcılar bu sunumları aldıklarında, şekillerdeki değişiklikleri kısıtlamak, istenen düzenin ve içeriğin korunmasına yardımcı olur.

Bu makale, şekillerin slaytlarda nasıl düzenlendiğini ve bir PPTX sunumunda şekil kilitlerinin nasıl uygulanıp kaldırılacağını açıklar. Bu kilitler, tek tek şekiller üzerindeki belirli düzenleme işlemlerini kısıtlamanızı sağlar.

## **Bir Slaytın Bileşimi**

Bir sunum slaytı, otomatik şekiller, tablolar, OLE nesneleri, gruplanmış şekiller, resim çerçeveleri, video çerçeveleri, bağlayıcılar ve sunum oluşturmak için kullanılan diğer öğeler gibi bileşenlerden oluşur. Aspose.Slides for Node.js via Java’da bir slayttaki her öğe, [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) sınıfından türeyen bir nesneyle temsil edilir.

Farklı şekil türleri farklı kilitleme seçenekleri sunar. [BaseShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/) sınıfı, şekil kilitlerinin temel sınıfıdır. Aspose.Slides for Node.js via Java aşağıdaki kilit sınıflarını sağlar:

- [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) otomatik şekilleri kilitler.  
- [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) bağlayıcı şekilleri kilitler.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) grafik nesneleri kilitler.  
- [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) grup şekillerini kilitler.  
- [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) resim çerçevelerini kilitler.  

[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) içinde kilitleri uygulamak için slaytları döngüyle gezip her desteklenen şekle uygun kilitleri ayarlayın.

## **Koruma Uygulama ve Kaldırma**

Şekil kilitleri, şekilleri seçme, taşıma ve yeniden boyutlandırma gibi işlemleri kısıtlar. Tüm sunumun düzenlenemez hâle gelmesini sağlamazlar.

### **PPTX Şekillerine Koruma Uygulama**

Aspose.Slides for Node.js via Java, bir slayttaki şekillerle çalışmak için [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) sınıfını sunar.

Örnek, otomatik şekiller için `true` değeriyle [setSelectLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setPositionLocked) ve [setSizeLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSizeLocked) metodlarını çağırır; grup şekilleri, bağlayıcılar ve resim çerçeveleri için eşdeğer kilitler kullanılır. Bağlayıcılar hareket için [setPositionMove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/#setPositionMove) metodunu, gruplar ise grup oluşturmayı kısıtlamak için [setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) metodunu kullanır.

Örnek, mevcut bir PPTX sunumunu yükler, her slaytın şekil koleksiyonundaki şekilleri kontrol eder ve bu kısıtlamalar uygulanmış bir kopya olarak kaydeder. Dört işlenen tür dışındaki şekiller değişmeden bırakılır. Döngü, bir grup içindeki alt şekilleri dolaşmaz.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const autoShapeLock = shape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                const groupShapeLock = shape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                const connectorShapeLock = shape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                const pictureFrameLock = shape.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Koruma Kaldırma**

Bir şekil kilidini kaldırmak için değerini `false` olarak ayarlayın. Aşağıdaki örnek, şekil kilitleri içeren bir sunumu yükler ve [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) ve [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) aracılığıyla seçim, hareket ve yeniden boyutlandırma kısıtlamalarını temizler. Ayrıca, [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) metoduna `false` geçirerek grup oluşturma kısıtlamasını da kaldırır ve sunumun bir kopyasını kaydeder. Diğer kilit ayarları değiştirilmeden bırakılır.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("ProtectedSample.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const autoShapeLock = shape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                const groupShapeLock = shape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                const connectorShapeLock = shape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                const pictureFrameLock = shape.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Sonuç**

Aspose.Slides for Node.js via Java, tek tek şekiller üzerindeki belirli düzenleme işlemlerini kısıtlamanıza veya aynı kısıtlamaları slaytlar arasında uygulamanıza olanak tanır. Her şekil türü tarafından desteklenen kilitleri seçin ve bu kısıtlamaları kaldırmanız gerektiğinde değerlerini `false` olarak ayarlayın.

## **SSS**

**Şekil kilitlerini ve parola korumasını aynı sunumda birleştirebilir miyim?**

Evet. Şekil kilitleri belirli düzenleme işlemlerini kısıtlarken, [password protection](/slides/tr/nodejs-java/password-protected-presentation/) sunumun açılmasını veya değiştirilmesini kısıtlayabilir. İkisini aynı dosyada kullanabilirsiniz.

**Belirli slaytlarda düzenlemeyi kısıtlayıp diğerlerini etkilemeden bırakabilir miyim?**

Evet. Kilitleri yalnızca seçilen slaytlardaki şekillere uygulayın. Bu, diğer slaytlardaki kilit ayarlarını değiştirmez.

**Bir grup içindeki tek tek şekillere kilit nasıl uygulanır?**

Grubun [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) metodundan dönen koleksiyonu döngüyle gezerek her alt şekle uygun kilitleri uygulayın. İç içe gruplar için de aynı işlemi tekrarlayın. Yukarıdaki örnekler yalnızca slaytın şekil koleksiyonunu işler, bu yüzden bireysel grup üyelerine kilit koymaz.