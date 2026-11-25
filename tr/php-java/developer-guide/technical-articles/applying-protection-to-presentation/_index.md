---
title: PHP'de Şekil Kilitleriyle Sunum Düzenlemelerini Kısıtlama
linktitle: Sunum Düzenlemelerini Kısıtlama
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
description: "Aspose.Slides for PHP via Java ile PPTX sunumlarındaki şekilleri kilitleyip kilidini açmayı, seçim, hareket, yeniden boyutlandırma ve gruplamayı kısıtlamayı öğrenin."
---
## **Genel Bakış**

Aspose.Slides for PHP via Java için yaygın bir kullanım, otomatik bir iş akışının parçası olarak PowerPoint (PPTX) sunumlarını oluşturmak, güncellemek ve kaydetmektir. Kullanıcılar bu sunumları aldıklarında, şekillerdeki değişiklikleri kısıtlamak, amaçlanan düzeni ve içeriği korumaya yardımcı olabilir.

Bu makale, şekillerin slaytlarda nasıl düzenlendiğini ve bir PPTX sunumunda şekil kilitlerinin nasıl uygulanıp kaldırılacağını açıklar. Bu kilitler, bireysel şekillerde belirli düzenleme işlemlerini kısıtlamanızı sağlar.

## **Bir Slaytın Bileşimi**

Bir sunum slaytı, otomatik şekiller, tablolar, OLE nesneleri, gruplandırılmış şekiller, resim çerçeveleri, video çerçeveleri, bağlayıcılar ve bir sunum oluşturmak için kullanılan diğer öğeler gibi bileşenlerden oluşur. Aspose.Slides for PHP via Java'da, bir slayttaki her öğe, [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) sınıfından türeten bir nesneyle temsil edilir.

Farklı şekil türleri farklı kilitleme seçenekleri sunar. [BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) sınıfı, şekil kilitleri için temel sınıftır. Aspose.Slides for PHP via Java aşağıdaki kilit sınıflarını sağlar:

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) otomatik şekilleri kilitler.  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) bağlayıcı şekilleri kilitler.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) grafik nesneleri kilitler.  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) grup şekillerini kilitler.  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) resim çerçevelerini kilitler.  

Bir [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) içinde kilitleri uygulamak için, slaytlarını döngüyle gezerek her desteklenen şekil üzerinde uygun kilitleri ayarlayın.

## **Koruma Uygulama ve Kaldırma**

Uyumlu sunum editörleri, bireysel düzenleme işlemlerini kısıtlamak için şekil kilitlerini kullanır. Dosya şifreleme ve belge düzeyinde yazma koruması ayrı [sunum koruma ayarları](/slides/tr/php-java/password-protected-presentation/) dir.

### **PPTX Şekillerine Koruma Uygulama**

Aspose.Slides for PHP via Java, bir slayttaki şekillerle çalışmak için [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) sınıfını sağlar.

Örnek, otoshapes için `true` ile [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked) ve [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) metodlarını çağırır; grup şekilleri, bağlayıcılar ve resim çerçeveleri için eşdeğer kilitler kullanılır. Bağlayıcılar hareket için [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) metodunu kullanır; gruplar ayrıca gruplamayı kısıtlamak için [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) metodunu kullanır.

Örnek, mevcut bir PPTX sunumunu yükler, her slaydın şekil koleksiyonundaki şekilleri kontrol eder ve bu kısıtlamalar uygulanmış bir kopyasını kaydeder. Dört işlenen tip dışındaki şekiller değişmeden bırakılır. Döngü, bir grup içindeki alt şekilleri dolaşmaz.

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

Bir şekil kilidini kaldırmak için değerini `false` olarak ayarlayın. Aşağıdaki örnek, şekil kilitleri içeren bir sunumu yükler ve [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) ve [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) aracılığıyla seçim, hareket ve yeniden boyutlandırma kısıtlamalarını temizler. Ayrıca, [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) metoduna `false` geçirerek gruplama kısıtlamasını kaldırır ve sunumun bir kopyasını kaydeder. Diğer kilit ayarları değişmeden bırakılır.

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

### **Resim Kırpmasını Korumak**

Çalışma dizinine `photo.jpg` adlı bir fotoğraf yerleştirin. Örnek, soldan %12 ve sağdan %8 kırpar, ardından resim çerçevesinin kilidi üzerinde [setCropLocked](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/#setCropLocked) metodunu çağırır. `true` geçirilmesi, daha fazla kırpmayı kısıtlar ve mevcut kırpmayı korur.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $image = Images::fromFile("photo.jpg");
    try {
        $photo = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $pictureFrame = $shapes->addPictureFrame(ShapeType::Rectangle, 20, 30, 270, 160, $photo);
    $pictureFrame->getPictureFormat()->setCropLeft(12);
    $pictureFrame->getPictureFormat()->setCropRight(8);

    $pictureFrameLock = $pictureFrame->getPictureFrameLock();
    $pictureFrameLock->setAspectRatioLocked(false);
    $pictureFrameLock->setCropLocked(true);

    $presentation->save("PictureLocked.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`PictureLocked.pptx` kırpma kilidini `true` olarak depolar. PowerPoint'te fotoğraf seçildiğinde **Crop** komutu devre dışı bırakılır.

### **Bir Diyagramı Gruplu Tutmak**

Örnek, bir dikdörtgen ve bir ok gruplar ve ardından grubun kilidi üzerinde [setUngroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setUngroupingLocked) metodunu çağırarak diyagram bileşenlerinin bir arada kalmasını sağlar. Grubu taşımak veya bir bileşenin doldurmasını değiştirmek gibi diğer düzenlemeler kullanılabilir durumda kalır.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    
    $groupShape = $shapes->addGroupShape();
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 70, 90, 50);
    $groupShape->getShapes()->addAutoShape(ShapeType::RightArrow, 190, 80, 60, 30);
    $groupShape->getGroupShapeLock()->setUngroupingLocked(true);

    $presentation->save("DiagramLocked.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`DiagramLocked.pptx` gruplamadan çıkma kilidini `true` olarak depolar. PowerPoint'te tüm diyagram seçildiğinde **Ungroup** komutu devre dışı bırakılır.

### **Mevcut Şekil Kilitlerini Raporlama**

Bir şablonu incelemek için açın ve her şekil için kilit nesnesini okuyun. [getNoLocks](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/#getNoLocks) yöntemi, nesnedeki tüm bayraklar devre dışı olduğunda `true`, en az biri etkin olduğunda `false` döndürür. Bir grup ve alt öğeleri ayrı kilit nesnelerine sahiptir; bu nedenle grup kilidi olmasa bile alt öğeleri inceleyin.

Bu örnek, otoshapes, resim çerçeveleri ve gruplar için hareketi kontrol eder. Ayrıca resimler için kırpmayı ve gruplar için gruptan çıkmayı kontrol eder. Rapor, tanıdığı etkin bayrakları listeler ve incelemediği şekil türlerini işaretler.

```php
use aspose\slides\Presentation;

function reportShapeLocks($shapes, $slideNumber, $prefix = "") {
    foreach ($shapes->toArray() as $shape) {
        $path = $prefix . java_values($shape->getName());
        $type = java_values($shape->getClass()->getSimpleName());
        $label = "Slide $slideNumber | $path | $type";
        $flags = [];
        $isGroup = java_instanceof($shape, java("com.aspose.slides.IGroupShape"));

        if ($isGroup) {
            $lock = $shape->getGroupShapeLock();
            if (java_values($lock->getUngroupingLocked())) {
                $flags[] = "UngroupingLocked";
            }
        } elseif (java_instanceof($shape, java("com.aspose.slides.IPictureFrame"))) {
            $lock = $shape->getPictureFrameLock();
            if (java_values($lock->getCropLocked())) {
                $flags[] = "CropLocked";
            }
        } elseif (java_instanceof($shape, java("com.aspose.slides.IAutoShape"))) {
            $lock = $shape->getAutoShapeLock();
        } else {
            echo "$label | Uninspected", PHP_EOL;
            continue;
        }

        if (java_values($lock->getPositionLocked())) {
            $flags[] = "PositionLocked";
        }
        if (!java_values($lock->getNoLocks())) {
            $restrictions = $flags ? implode(", ", $flags) : "Active flag not identified";
            echo "$label | $restrictions", PHP_EOL;
        }

        if ($isGroup) {
            reportShapeLocks($shape->getShapes(), $slideNumber, $path . "/");
        }
    }
}

$presentation = new Presentation("Sample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        reportShapeLocks($slide->getShapes(), java_values($slide->getSlideNumber()));
    }
} finally {
    $presentation->dispose();
}
```

`Sample.pptx` dosyasının 1. slaytında, `Layout` adlı bir grup, gruptan çıkma kilitli, içinde `Photo` adlı bir resim kırpma kilitli ve `Free` adlı kilitsiz bir dikdörtgen olduğunu varsayalım. Rapor, `Free` öğesini atlar ve şu iki satırı yazar:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Rapor, depolanmış şekil seviyesi düzenleme bayraklarını değiştirilmeksizin veya sunum kaydedilmeden okur. Belge düzeyinde yazma koruması ayrı bir ayardır ve her bayrağın uygulanması editöre bağlıdır.

### **Sonuç**

Aspose.Slides for PHP via Java, bireysel şekillerde belirli düzenleme işlemlerini kısıtlamanızı veya aynı kısıtlamaları tüm slaytlara uygulamanızı sağlar. Her şekil türü tarafından desteklenen kilitleri seçin ve bu kısıtlamaları kaldırmanız gerektiğinde değerlerini `false` olarak ayarlayın.

## **SSS**

**Aynı sunumda şekil kilitlerini ve parola korumasını birleştirebilir miyim?**

Evet. Şekil kilitleri belirli düzenleme işlemlerini kısıtlarken, [parola koruması](/slides/tr/php-java/password-protected-presentation/) sunumun açılmasını veya değiştirilmesini kısıtlayabilir. İkisini aynı dosyada kullanabilirsiniz.

**Belirli slaytlarda düzenlemeyi etkilenmeyen diğer slaytlara dokunmadan kısıtlayabilir miyim?**

Evet. Kilitleri sadece seçili slaytlardaki şekillere uygulayın. Bu, diğer slaytlardaki kilit ayarlarını değiştirmez.

**Bir grup içindeki bireysel şekillere kilitleri nasıl uygulayabilirim?**

Grubun [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) metodunun döndürdüğü koleksiyonu döngüyle gezerek her alt şekle uygun kilitleri uygulayın. İç içe gruplar için bu işlemi yineleyin; raporlama örneğindeki yürütmeyi izleyin.