---
title: PHP'de Şekil Kilitleri ile Sunum Düzenlemelerini Kısıtlayın
linktitle: Sunum Düzenlemelerini Kısıtla
type: docs
weight: 60
url: /tr/php-java/applying-protection-to-presentation/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile PPTX sunumlarında şekilleri nasıl kilitleyip kilidini kaldıracağınızı, seçim, hareket, yeniden boyutlandırma ve gruplamayı nasıl kısıtlayacağınızı öğrenin."
---
## **Genel Bakış**

Aspose.Slides for PHP via Java'nin yaygın bir kullanımı, otomatik bir iş akışının parçası olarak PowerPoint (PPTX) sunumları oluşturmak, güncellemek ve kaydetmektir. Kullanıcılar bu sunumları aldıklarında, şekillerdeki değişiklikleri kısıtlamak, planlanan düzeni ve içeriği korumaya yardımcı olabilir.

Bu makale, şekillerin slaytlarda nasıl düzenlendiğini ve bir PPTX sunumunda şekil kilitlerinin nasıl uygulanıp kaldırılacağını açıklar. Bu kilitler, tek tek şekiller üzerinde belirli düzenleme işlemlerini kısıtlamanızı sağlar.

## **Bir Slaydın Bileşimi**

Bir sunum slaydı, otomatik şekiller, tablolar, OLE nesneleri, gruplanmış şekiller, resim çerçeveleri, video çerçeveleri, bağlayıcılar ve bir sunum oluşturmak için kullanılan diğer bileşenlerden oluşur. Aspose.Slides for PHP via Java'de, bir slayttaki her öğe, [Şekil](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) sınıfından türeyen bir nesneyle temsil edilir.

Farklı şekil tipleri farklı kilitleme seçenekleri sunar. [BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) sınıfı, şekil kilitlerinin temel sınıfıdır. Aspose.Slides for PHP via Java aşağıdaki kilit sınıflarını sağlar:

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) otomatik şekilleri kilitler.  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) bağlayıcı şekilleri kilitler.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) grafik nesneleri kilitler.  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) grup şekilleri kilitler.  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) resim çerçevelerini kilitler.  

Bir [Sunum](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) içinde kilitleri uygulamak için, slaytları üzerinden döngü yaparak her desteklenen şekle uygun kilitleri ayarlayın.

## **Koruma Uygulama ve Kaldırma**

Şekil kilitleri, şekilleri seçme, taşıma ve yeniden boyutlandırma gibi işlemleri kısıtlar. Tüm sunumu düzenlenemez hâle getirmezler.

### **PPTX Şekillerine Koruma Uygulama**

Aspose.Slides for PHP via Java, bir slayttaki şekillerle çalışmak için [Şekil](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) sınıfını sağlar.

Örnek, otomatik şekiller için `true` ile [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked) ve [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) metodlarını çağırır; grup şekilleri, bağlayıcılar ve resim çerçeveleri için eşdeğer kilitleri kullanır. Bağlayıcılar hareket için [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) metodunu; gruplar ise gruplamayı kısıtlamak için [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) metodunu kullanır.

Örnek, mevcut bir PPTX sunumunu yükler, her slaydın şekil koleksiyonundaki şekilleri kontrol eder ve bu kısıtlamalar uygulanmış bir kopyasını kaydeder. Dört işlenen tip dışındaki şekiller değişmeden kalır. Döngü, bir grup içindeki alt şekilleri dolaşmaz.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        foreach ($slide->getShapes()->toArray() as $shape) {
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setGroupingLocked(true);
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionMove(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            }
        }
    }

    $presentation->save("ProtectedSample.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Koruma Kaldırma**

Bir şekil kilidini kaldırmak için, değerini `false` olarak ayarlayın. Aşağıdaki örnek, şekil kilitleri olan bir sunumu yükler ve seçim, hareket ve yeniden boyutlandırma kısıtlamalarını [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) ve [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) aracılığıyla temizler. Ayrıca, gruplama kısıtlamasını [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) metoduna `false` geçirerek kaldırır ve sunumun bir kopyasını kaydeder. Diğer kilit ayarları değişmeden kalır.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("ProtectedSample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        foreach ($slide->getShapes()->toArray() as $shape) {
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setGroupingLocked(false);
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionMove(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            }
        }
    }

    $presentation->save("RemovedProtectionSample.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Sonuç**

Aspose.Slides for PHP via Java, tek tek şekiller üzerinde belirli düzenleme işlemlerini kısıtlamanıza veya aynı kısıtlamaları slaytlar arasında uygulamanıza olanak tanır. Her şekil tipi tarafından desteklenen kilitleri seçin ve bu kısıtlamaları kaldırmanız gerektiğinde değerlerini `false` olarak ayarlayın.

## **SSS**

**Bir sunumda şekil kilitlerini ve şifre korumasını birleştirebilir miyim?**

Evet. Şekil kilitleri belirli düzenleme işlemlerini kısıtlarken, [parola koruması](/slides/tr/php-java/password-protected-presentation/) sunumun açılmasını veya değiştirilmesini kısıtlayabilir. İkisini aynı dosyada kullanabilirsiniz.

**Belirli slaytlarda düzenlemeyi, diğerlerini etkilemeden kısıtlayabilir miyim?**

Evet. Kilitleri yalnızca seçili slaytlardaki şekillere uygulayın. Bu, diğer slaytlardaki kilit ayarlarını değiştirmez.

**Bir grup içindeki tek tek şekillere kilitleri nasıl uygularım?**

Grubun [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) metodunun döndürdüğü koleksiyon üzerinden döngü yapın ve her alt şekle uygun kilitleri uygulayın. Bu işlemi iç içe gruplar için de tekrarlayın. Yukarıdaki örnekler yalnızca slaydın şekil koleksiyonunu işlediği için, bireysel grup üyelerine kilit uygulamaz.