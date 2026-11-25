---
title: Java'da Şekil Kilitleriyle Sunum Düzenlemelerini Kısıtla
linktitle: Sunum Düzenlemelerini Kısıtla
type: docs
weight: 60
url: /tr/java/applying-protection-to-presentation/
keywords:
- düzenlemeleri önle
- düzenlemelerden koru
- şekli kilitle
- konumu kilitle
- seçimi kilitle
- yeniden boyutlandırmayı kilitle
- gruplandırmayı kilitle
- PowerPoint
- PPTX
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java kullanarak PPTX sunumlarındaki şekilleri kilitleme ve kilidini açma, seçim, hareket, yeniden boyutlandırma ve gruplandırmayı kısıtlama yöntemlerini öğrenin."
---
## **Arka Plan**

Aspose.Slides for Java'nin yaygın bir kullanımı, otomatik bir iş akışının parçası olarak PowerPoint (PPTX) sunumlarını oluşturmak, güncellemek ve kaydetmektir. Kullanıcılar bu sunumları aldıklarında, şekillerdeki değişiklikleri kısıtlamak, amaçlanan düzeni ve içeriği korumaya yardımcı olur.

Bu makale, slaytlardaki şekillerin nasıl düzenlendiğini ve bir PPTX sunumunda şekil kilitlerinin nasıl uygulanıp kaldırılacağını açıklar. Bu kilitler, bireysel şekiller üzerindeki belirli düzenleme işlemlerini kısıtlamanızı sağlar.

## **Slayt Bileşimi**

Bir sunum slaytı, otomatik şekiller, tablolar, OLE nesneleri, gruplanmış şekiller, resim çerçeveleri, video çerçeveleri, bağlayıcılar ve sunum oluşturmak için kullanılan diğer öğeler gibi bileşenlerden oluşur. Aspose.Slides for Java'de, bir slayttaki her öğe, [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) arayüzünü uygulayan veya bu arayüzden türeyen bir nesneyle temsil edilir.

Farklı şekil türleri, farklı kilitleme seçenekleri sunar. [IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/) arayüzü, şekil kilitleri için temel arayüzdür. Aspose.Slides for Java aşağıdaki kilit arayüzlerini sağlar:

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) otomatik şekilleri kilitler.  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) bağlayıcı şekilleri kilitler.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) grafik nesneleri kilitler.  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) grup şekillerini kilitler.  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) resim çerçevelerini kilitler.  

Bir [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) içinde kilitleri uygulamak için slaytları dolaşın ve desteklenen her şekil üzerinde uygun kilitleri ayarlayın.

## **Koruma Uygulama ve Kaldırma**

Uyumlu sunum editörleri, bireysel düzenleme işlemlerini kısıtlamak için şekil kilitlerini kullanır. Dosya şifrelemesi ve belge‑seviyesi yazma koruması ayrı [sunum koruma ayarları](/slides/tr/java/password-protected-presentation/) olarak bulunur.

### **PPTX Şekillerine Koruma Uygulama**

Aspose.Slides for Java, bir slayttaki şekillerle çalışmak için [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) arayüzünü sağlar.

Örnek, otomatik şekiller için `true` ile [setSelectLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-) ve [setSizeLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) metodlarını çağırır; grup şekilleri, bağlayıcılar ve resim çerçeveleri için eşdeğer kilitler kullanılır. Bağlayıcılar hareket için [setPositionMove](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) metodunu, gruplar ise gruplayıcı kilitlemeyi sınırlamak için [setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) metodunu kullanır.

Örnek, mevcut bir PPTX sunumu yükler, her slaydın şekil koleksiyonundaki şekilleri kontrol eder ve bu kısıtlamalar uygulanmış bir kopya kaydeder. Dört ele alınan tip dışındaki şekiller değişmeden kalır. Döngü, bir grup içindeki alt şekilleri dolaşmaz.

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

Bir şekil kilidini kaldırmak için değerini `false` yapın. Aşağıdaki örnek, şekil kilitli bir sunumu yükler ve [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) ve [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) aracılığıyla seçim, hareket ve yeniden boyutlandırma kısıtlamalarını temizler. Ayrıca, [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) metoduna `false` geçerek grup oluşturma kısıtlamasını da kaldırır ve sunumun bir kopyasını kaydeder. Diğer kilit ayarları değişmeden kalır.

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

### **Resim Kırpmasını Koru**

Çalışma dizinine `photo.jpg` adlı bir fotoğraf koyun. Örnek, soldan %12, sağdan %8 kırpar ve ardından resim çerçevesinin kilidine [setCropLocked](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/#setCropLocked-boolean-) metodunu `true` ile çağırır. `true` geçilmesi, sonraki kırpmaları kısıtlar ve mevcut kırpmayı korur.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    byte[] photoBytes = Files.readAllBytes(Paths.get("photo.jpg"));
    IPPImage photo = presentation.getImages().addImage(photoBytes);

    IPictureFrame pictureFrame = shapes.addPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo);
    pictureFrame.getPictureFormat().setCropLeft(12);
    pictureFrame.getPictureFormat().setCropRight(8);
    
    IPictureFrameLock pictureFrameLock = pictureFrame.getPictureFrameLock();
    pictureFrameLock.setAspectRatioLocked(false);
    pictureFrameLock.setCropLocked(true);

    presentation.save("PictureLocked.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`PictureLocked.pptx` kırpma kilidini `true` olarak depolar. PowerPoint'te fotoğraf seçildiğinde **Crop** komutu devre dışı kalır.

### **Diyagramı Gruplu Tut**

Örnek bir dikdörtgen ve bir ok gruplar, ardından grubun kilidine [setUngroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setUngroupingLocked-boolean-) metodunu çağırarak diyagram bileşenlerinin birlikte kalmasını sağlar. Grubu taşıma veya bir bileşenin dolgu rengini değiştirme gibi diğer düzenlemeler hâlâ kullanılabilir.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IGroupShape groupShape = shapes.addGroupShape();
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 100, 70, 90, 50);
    groupShape.getShapes().addAutoShape(ShapeType.RightArrow, 190, 80, 60, 30);
    groupShape.getGroupShapeLock().setUngroupingLocked(true);

    presentation.save("DiagramLocked.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`DiagramLocked.pptx` gruplayıcı kaldırma kilidini `true` olarak depolar. PowerPoint'te tüm diyagram seçildiğinde **Ungroup** komutu devre dışı kalır.

### **Mevcut Şekil Kilitlerini Raporla**

Bir şablonu incelemek için açın ve her şekil için kilit nesnesini okuyun. [getNoLocks](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/#getNoLocks--) yöntemi, nesnedeki tüm bayraklar devre dışıysa `true`, en az biri etkinse `false` döndürür. Bir grup ve alt öğeleri ayrı kilit nesnelerine sahiptir, bu nedenle grup kilidi olmasa bile alt öğeleri inceleyin.

Bu örnek, otomatik şekiller, resim çerçeveleri ve gruplar için hareketi kontrol eder. Ayrıca resimler için kırpmayı ve gruplar için gruplayıcı kaldırmayı kontrol eder. Rapor, tanıdığı etkin bayrakları listeler ve incelemediği şekil tiplerini işaretler.

```java
import com.aspose.slides.*;
import java.util.StringJoiner;

class ShapeLockReport {
    void inspect(IShapeCollection shapes, int slideNumber, String prefix) {
        for (IShape shape : shapes) {
            String path = prefix + shape.getName();
            String label = "Slide " + slideNumber + " | " + path + " | " + shape.getClass().getSimpleName();
            StringJoiner flags = new StringJoiner(", ");
            IBaseShapeLock shapeLock;

            if (shape instanceof IGroupShape) {
                IGroupShapeLock groupLock = ((IGroupShape) shape).getGroupShapeLock();
                shapeLock = groupLock;
                if (groupLock.getUngroupingLocked()) flags.add("UngroupingLocked");
                if (groupLock.getPositionLocked()) flags.add("PositionLocked");
            } else if (shape instanceof IPictureFrame) {
                IPictureFrameLock pictureLock = ((IPictureFrame) shape).getPictureFrameLock();
                shapeLock = pictureLock;
                if (pictureLock.getCropLocked()) flags.add("CropLocked");
                if (pictureLock.getPositionLocked()) flags.add("PositionLocked");
            } else if (shape instanceof IAutoShape) {
                IAutoShapeLock autoShapeLock = ((IAutoShape) shape).getAutoShapeLock();
                shapeLock = autoShapeLock;
                if (autoShapeLock.getPositionLocked()) flags.add("PositionLocked");
            } else {
                System.out.println(label + " | Uninspected");
                continue;
            }

            if (!shapeLock.getNoLocks()) {
                String restrictions = flags.length() > 0 ? flags.toString() : "Active flag not identified";
                System.out.println(label + " | " + restrictions);
            }

            if (shape instanceof IGroupShape) {
                inspect(((IGroupShape) shape).getShapes(), slideNumber, path + "/");
            }
        }
    }
}

ShapeLockReport report = new ShapeLockReport();
Presentation presentation = new Presentation("Sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        report.inspect(slide.getShapes(), slide.getSlideNumber(), "");
    }
} finally {
    presentation.dispose();
}
```

Örneğin, `Sample.pptx` dosyasının 1. slaytı, gruplayıcı kaldırma kilidi olan `Layout` adında bir grup, içinde kırpma kilidi olan `Photo` adlı bir resim ve kilitsiz `Free` adlı bir dikdörtgen içeriyorsa, rapor `Free` öğesini atlar ve şu iki satırı yazdırır:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Rapor, sunumu değiştirmeden veya kaydetmeden saklanan şekil‑seviyesi düzenleme bayraklarını okur. Belge‑seviyesi yazma koruması ayrı bir ayardır ve her bayrağın uygulanması editöre bağlıdır.

### **Sonuç**

Aspose.Slides for Java, bireysel şekiller üzerinde belirli düzenleme işlemlerini kısıtlamanıza veya aynı kısıtlamaları birden çok slayta uygulamanıza olanak tanır. Her şekil türünün desteklediği kilitleri seçin ve bu kısıtlamaları kaldırmanız gerektiğinde değerlerini `false` olarak ayarlayın.

## **SSS**

**Aynı sunumda şekil kilitlerini ve parola korumasını birleştirebilir miyim?**

Evet. Şekil kilitleri belirli düzenleme işlemlerini kısıtlarken, [parola koruması](/slides/tr/java/password-protected-presentation/) sunumun açılmasını veya değiştirilmesini engelleyebilir. İkisini aynı dosyada birlikte kullanabilirsiniz.

**Belirli slaytlarda düzenlemeyi kısıtlayıp diğerlerini etkilemeden yapabilir miyim?**

Evet. Kilitleri yalnızca seçili slaytlardaki şekillere uygulayın. Bu, diğer slaytlardaki kilit ayarlarını değiştirmez.

**Bir grup içindeki bireysel şekillere nasıl kilit uygulayabilirim?**

Grubun [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) metodunun döndürdüğü koleksiyonu dolaşın ve her alt şekle uygun kilitleri uygulayın. İç içe gruplar için aynı işlemi tekrar edin; raporlama örneğindeki gezinme mantığını izleyin.