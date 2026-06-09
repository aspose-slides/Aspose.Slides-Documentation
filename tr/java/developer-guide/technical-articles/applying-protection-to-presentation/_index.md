---
title: Şekil Kilitleriyle Sunum Düzenlemelerini Önleme
linktitle: Sunum Düzenlemelerini Önleme
type: docs
weight: 60
url: /tr/java/applying-protection-to-presentation/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'nin PPT, PPTX ve ODP dosyalarında şekilleri nasıl kilitlediğini veya kilidini açtığını keşfedin; sunumları güvence altına alırken kontrollü düzenlemelere ve daha hızlı teslimata olanak tanır."
---
## **Arka Plan**

Aspose.Slides'in yaygın bir kullanımı, otomatik bir iş akışının parçası olarak Microsoft PowerPoint (PPTX) sunumlarını oluşturmak, güncellemek ve kaydetmektir. Aspose.Slides'i bu şekilde kullanan uygulamaların kullanıcıları oluşturulan sunumlara erişir, bu nedenle bunları düzenlemeye karşı korumak yaygın bir endişedir. Otomatik olarak oluşturulan sunumların orijinal biçimlendirmesini ve içeriğini koruması önemlidir.

Bu makale, sunumların ve slaytların nasıl yapılandırıldığını ve Aspose.Slides for Java'nın bir sunuma koruma nasıl uygulayabileceğini ve daha sonra nasıl kaldırabileceğini açıklar. Geliştiricilere, uygulamalarının ürettiği sunumların nasıl kullanılacağını kontrol etme imkanı sağlar.

## **Bir Slaytın Bileşimi**

Bir sunum slaydı, otomatik şekiller, tablolar, OLE nesneleri, gruplanmış şekiller, resim çerçeveleri, video çerçeveleri, bağlayıcılar ve bir sunumu oluşturmak için kullanılan diğer öğeler gibi bileşenlerden oluşur. Aspose.Slides for Java’da bir slayttaki her öğe, [IShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/) arayüzünü uygulayan veya bu arayüzden türeyen bir nesneyle temsil edilir.

PPTX'in yapısı karmaşıktır, bu yüzden PPT'de tüm şekil türleri için tek bir genel kilit kullanılabilirken, farklı şekil türleri farklı kilitler gerektirir. [IBaseShapeLock](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ibaseshapelock/) arayüzü PPTX için genel kilitleme sınıfıdır. Aspose.Slides for Java, PPTX için aşağıdaki kilit türlerini destekler:

- [IAutoShapeLock](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iautoshapelock/) otomatik şekilleri kilitler.  
- [IConnectorLock](https://reference.aspose.com/slides/tr/java/com.aspose.slides/iconnectorlock/) bağlayıcı şekilleri kilitler.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/tr/java/com.aspose.slides/igraphicalobjectlock/) grafik nesneleri kilitler.  
- [IGroupShapeLock](https://reference.aspose.com/slides/tr/java/com.aspose.slides/igroupshapelock/) grup şekillerini kilitler.  
- [IPictureFrameLock](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ipictureframelock/) resim çerçevelerini kilitler.  

Bir [Presentation](https://reference.aspose.com/slides/tr/java/com.aspose.slides/presentation/) nesnesindeki tüm şekil nesneleri üzerinde gerçekleştirilen herhangi bir eylem, tüm sunuma uygulanır.

## **Koruma Uygulama ve Kaldırma**

Koruma uygulamak, bir sunumun düzenlenememesini sağlar. Sunum içeriğini korumak için faydalı bir tekniktir.

### **PPTX Şekillerine Koruma Uygulama**

Aspose.Slides for Java, bir slayttaki şekillerle çalışmak için [IShape](https://reference.aspose.com/slides/tr/java/com.aspose.slides/ishape/) arayüzünü sunar.

Daha önce belirtildiği gibi, her şekil sınıfının koruma için ilişkili bir şekil‑kilit sınıfı vardır. Bu makale NoSelect, NoMove ve NoResize kilitlerine odaklanır. Bu kilitler, şekillerin (fare tıklamaları veya diğer seçim yöntemleriyle) seçilememesini ve taşınamamasını ya da yeniden boyutlandırılamamasını sağlar.

Aşağıdaki kod örneği, bir sunumdaki tüm şekil türlerine koruma uygular.

```java
// PPTX dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation("Sample.pptx");

// Sunumdaki tüm slaytları dolaşıyor.
for (ISlide slide : presentation.getSlides()) {

    // Slayttaki tüm şekilleri dolaşıyor.
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAutoShape) {
            // Şekli bir AutoShape’e tip dönüştürerek şekil kilidini elde ediyor.
            IAutoShape autoShape = (IAutoShape) shape;
            IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();

            autoShapeLock.setPositionLocked(true);
            autoShapeLock.setSelectLocked(true);
            autoShapeLock.setSizeLocked(true);
        } else if (shape instanceof IGroupShape) {
            // Şekli bir grup şekle tip dönüştürerek şekil kilidini elde ediyor.
            IGroupShape groupShape = (IGroupShape) shape;
            IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();

            groupShapeLock.setGroupingLocked(true);
            groupShapeLock.setPositionLocked(true);
            groupShapeLock.setSelectLocked(true);
            groupShapeLock.setSizeLocked(true);
        } else if (shape instanceof IConnector) {
            // Şekli bir bağlayıcı şekle tip dönüştürerek şekil kilidini elde ediyor.
            IConnector connectorShape = (IConnector) shape;
            IConnectorLock connectorShapeLock = connectorShape.getShapeLock();

            connectorShapeLock.setPositionMove(true);
            connectorShapeLock.setSelectLocked(true);
            connectorShapeLock.setSizeLocked(true);
        } else if (shape instanceof IPictureFrame) {
            // Şekli bir resim çerçevesine tip dönüştürerek şekil kilidini elde ediyor.
            IPictureFrame pictureFrame = (IPictureFrame) shape;
            IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();

            pictureFrameLock.setPositionLocked(true);
            pictureFrameLock.setSelectLocked(true);
            pictureFrameLock.setSizeLocked(true);
        }
    }
}

// Sunum dosyasını kaydediyor.
presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Koruma Kaldırma**

Bir şeklin kilidini açmak için, uygulanan kilidin değerini `false` olarak ayarlayın. Aşağıdaki kod örneği, kilitli bir sunumdaki şekillerin kilidini nasıl açacağınızı gösterir.

```java
// PPTX dosyasını temsil eden Presentation sınıfını örnekleyin.
Presentation presentation = new Presentation("ProtectedSample.pptx");

// Sunumdaki tüm slaytları dolaşıyor.
for (ISlide slide : presentation.getSlides()) {

    // Slayttaki tüm şekilleri dolaşıyor.
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAutoShape) {
            // Şekli bir autoshape’e tip dönüştürerek şekil kilidini elde ediyor.
            IAutoShape autoShape = (IAutoShape) shape;
            IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();

            autoShapeLock.setPositionLocked(false);
            autoShapeLock.setSelectLocked(false);
            autoShapeLock.setSizeLocked(false);
        } else if (shape instanceof IGroupShape) {
            // Şekli bir grup şekle tip dönüştürerek şekil kilidini elde ediyor.
            IGroupShape groupShape = (IGroupShape) shape;
            IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();

            groupShapeLock.setGroupingLocked(false);
            groupShapeLock.setPositionLocked(false);
            groupShapeLock.setSelectLocked(false);
            groupShapeLock.setSizeLocked(false);
        } else if (shape instanceof IConnector) {
            // Şekli bir bağlayıcı şekle tip dönüştürerek şekil kilidini elde ediyor.
            IConnector connectorShape = (IConnector) shape;
            IConnectorLock connectorShapeLock = connectorShape.getShapeLock();

            connectorShapeLock.setPositionMove(false);
            connectorShapeLock.setSelectLocked(false);
            connectorShapeLock.setSizeLocked(false);
        } else if (shape instanceof IPictureFrame) {
            // Şekli bir resim çerçevesine tip dönüştürerek şekil kilidini elde ediyor.
            IPictureFrame pictureFrame = (IPictureFrame) shape;
            IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();

            pictureFrameLock.setPositionLocked(false);
            pictureFrameLock.setSelectLocked(false);
            pictureFrameLock.setSizeLocked(false);
        }
    }
}

// Sunum dosyasını kaydediyor.
presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Sonuç**

Aspose.Slides, bir sunumdaki şekilleri korumak için çeşitli seçenekler sunar. Tek bir şekli kilitleyebilir veya bir sunumdaki tüm şekiller üzerinde dolaşıp her birini kilitleyerek dosyanın tamamını etkili bir şekilde güvence altına alabilirsiniz. Kilit değerini `false` yaparak korumayı kaldırabilirsiniz.

## **SSS**

**Şekil kilitlerini ve parola korumasını aynı sunumda birleştirebilir miyim?**

Evet. Kilitler dosya içindeki nesnelerin düzenlenmesini sınırlar, [parola koruması](/slides/tr/java/password-protected-presentation/) ise açma ve/veya değişiklikleri kaydetme erişimini kontrol eder. Bu mekanizmalar birbirini tamamlar ve birlikte çalışır.

**Belirli slaytlarda düzenlemeyi kısıtlayıp diğerlerini etkilemez miyim?**

Evet. Seçili slaytlardaki şekillere kilitler uygulayın; kalan slaytlar düzenlenebilir kalır.

**Şekil kilitleri gruplanmış nesnelere ve bağlayıcılara uygulanıyor mu?**

Evet. Gruplar, bağlayıcılar, grafik nesneler ve diğer şekil türleri için özel kilit tipleri desteklenir.