---
title: Android'de Şekil Kilitleriyle Sunum Düzenlemelerini Kısıtlama
linktitle: Sunum Düzenlemelerini Kısıtlama
type: docs
weight: 60
url: /tr/androidjava/applying-protection-to-presentation/
keywords:
- düzenlemeleri önleme
- düzenlemeden koruma
- şekil kilitleme
- konum kilitleme
- seçimi kilitleme
- yeniden boyutlandırmayı kilitleme
- gruplamayı kilitleme
- PowerPoint
- PPTX
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java kullanarak PPTX sunumlarında şekilleri kilitlemeyi ve kilidini kaldırmayı, seçim, hareket, yeniden boyutlandırma ve gruplamayı kısıtlamayı öğrenin."
---
## **Genel Bakış**

Aspose.Slides for Android via Java için yaygın bir kullanım, otomatik bir iş akışının parçası olarak PowerPoint (PPTX) sunumları oluşturmak, güncellemek ve kaydetmektir. Kullanıcılar bu sunumları aldıklarında, şekillerdeki değişiklikleri kısıtlamak, amaçlanan düzeni ve içeriği korumaya yardımcı olabilir.

Bu makale, şekillerin slaytlarda nasıl düzenlendiğini ve bir PPTX sunumunda şekil kilitlerinin nasıl uygulanıp kaldırılacağını açıklar. Bu kilitler, bireysel şekillerde belirli düzenleme işlemlerini kısıtlamanızı sağlar.

## **Bir Slaydın Bileşimi**

Bir sunum slaydı, otomatik şekiller, tablolar, OLE nesneleri, gruplandırılmış şekiller, resim çerçeveleri, video çerçeveleri, bağlayıcılar ve bir sunumu oluşturmak için kullanılan diğer öğeler gibi bileşenlerden oluşur. Aspose.Slides for Android via Java'da, bir slayttaki her öğe, [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) arayüzünü uygulayan veya bu arayüzü miras alan bir nesneyle temsil edilir.

Farklı şekil türleri farklı kilitleme seçenekleri sunar. [IBaseShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/) arayüzü, şekil kilitleri için temel arayüzdür. Aspose.Slides for Android via Java aşağıdaki kilit arayüzlerini sağlar:

- [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/) otomatik şekilleri kilitler.  
- [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) bağlayıcı şekilleri kilitler.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) grafik nesneleri kilitler.  
- [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/) grup şekillerini kilitler.  
- [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) resim çerçevelerini kilitler.  

Bir [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) üzerindeki kilitleri uygulamak için, slaytlarını yineleyin ve desteklenen her şekil üzerinde uygun kilitleri ayarlayın.

## **Koruma Uygulama ve Kaldırma**

Uyumlu sunum editörleri, bireysel düzenleme işlemlerini kısıtlamak için şekil kilitlerini kullanır. Dosya şifrelemesi ve belge düzeyinde yazma koruması ayrı [parola koruması](/slides/tr/androidjava/password-protected-presentation/) olarak bulunur.

### **PPTX Şekillerine Koruma Uygulama**

Aspose.Slides for Android via Java, slayttaki şekillerle çalışmak için [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) arayüzünü sağlar.

Örnek, otomatik şekiller için `true` değeriyle [setSelectLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-), ve [setSizeLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) çağırır; grup şekilleri, bağlayıcılar ve resim çerçeveleri için eşdeğer kilitler kullanılır. Bağlayıcılar hareket için [setPositionMove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) kullanır; gruplar da gruplamayı kısıtlamak için [setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) kullanır.

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

Bir şekil kilidini kaldırmak için değerini `false` yapın. Aşağıdaki örnek, şekil kilitli bir sunumu yükler ve seçim, hareket ve yeniden boyutlandırma kısıtlamalarını [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/), ve [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) aracılığıyla temizler. Ayrıca, `false` geçirerek [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) üzerinden grup sınırlamasını da kaldırır ve sunumun bir kopyasını kaydeder. Diğer kilit ayarları değişmeden bırakılır.

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

### **Resim Kırpmasını Korumak**

`photo.jpg` adlı bir fotoğrafı çalışma dizinine yerleştirin. Örnek, soldan %12 ve sağdan %8 kırpar, ardından resim çerçevesinin kilidi üzerinde [setCropLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/#setCropLocked-boolean-) çağırır. `true` geçirmek, daha fazla kırpmayı kısıtlar ve mevcut kırpmayı korur.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IPPImage photo;
    try (FileInputStream input = new FileInputStream("photo.jpg")) {
        photo = presentation.getImages().addImage(input);
    }

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

`PictureLocked.pptx` kırpma kilidini `true` olarak depolar. PowerPoint'te fotoğraf seçildiğinde **Crop** komutu devre dışı bırakılır.

### **Bir Diyagramı Gruplu Tutma**

Örnek, bir dikdörtgen ve bir ok gruplar, ardından grup kilidi üzerinde [setUngroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setUngroupingLocked-boolean-) çağırarak diyagram bileşenlerinin bir arada kalmasını sağlar. Grubu hareket ettirmek veya bir bileşenin dolgusunu değiştirmek gibi diğer düzenlemeler kullanılabilir durumda kalır.

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

`DiagramLocked.pptx` grup çözme kilidini `true` olarak depolar. PowerPoint'te tüm diyagram seçildiğinde **Ungroup** komutu devre dışı bırakılır.

### **Mevcut Şekil Kilitlerini Raporlama**

Bir şablonu incelemek için, onu açın ve her şekil için kilit nesnesini okuyun. [getNoLocks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/#getNoLocks--) metodu, nesnedeki tüm bayraklar devre dışı olduğunda `true`, en az bir bayrak etkin olduğunda `false` döndürür. Bir grup ve onun alt öğeleri ayrı kilit nesnelerine sahiptir; bu nedenle grup kilidi olmasa bile alt öğeleri inceleyin.

Bu örnek, otomatik şekiller, resim çerçeveleri ve gruplar için hareketi kontrol eder. Ayrıca resimler için kırpmayı ve gruplar için grup çözmeyi kontrol eder. Rapor, tanıdığı etkin bayrakları listeler ve incelemediği şekil türlerini işaretler.

```java
import com.aspose.slides.*;
import android.text.TextUtils;
import java.util.ArrayList;
import java.util.List;

class ShapeLockReport {
    void inspect(IShapeCollection shapes, int slideNumber, String prefix) {
        for (IShape shape : shapes) {
            String path = prefix + shape.getName();
            String label = "Slide " + slideNumber + " | " + path + " | " + shape.getClass().getSimpleName();
            List<String> flags = new ArrayList<>();
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
                String restrictions = !flags.isEmpty() ? TextUtils.join(", ", flags) : "Active flag not identified";
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

`Sample.pptx` dosyasının 1. slaytının, grup çözme kilitli `Layout` adlı bir grup, içinde kırpma kilitli `Photo` adlı bir resim ve kilidi olmayan `Free` adlı bir dikdörtgen içerdiğini varsayalım. Rapor, `Free` öğesini atlar ve şu iki satırı yazdırır:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Rapor, saklanan şekil düzeyindeki düzenleme bayraklarını değiştirmeden veya sunumu kaydetmeden okur. Belge düzeyinde yazma koruması ayrı bir ayardır ve her bayrağın uygulanması editöre bağlıdır.

## **Sonuç**

Aspose.Slides for Android via Java, bireysel şekillerde belirli düzenleme işlemlerini kısıtlamanıza veya aynı kısıtlamaları slaytlar arasında uygulamanıza olanak tanır. Her şekil türünün desteklediği kilitleri seçin ve bu kısıtlamaları kaldırmanız gerektiğinde değerlerini `false` olarak ayarlayın.

## **SSS**

**Bir sunumda şekil kilitlerini ve parola korumasını birleştirebilir miyim?**

Evet. Şekil kilitleri belirli düzenleme işlemlerini kısıtlarken, [parola koruması](/slides/tr/androidjava/password-protected-presentation/) sunumun açılmasını veya değiştirilmesini kısıtlayabilir. İkisini aynı dosyada kullanabilirsiniz.

**Belirli slaytlarda düzenlemeyi diğerlerini etkilemeden kısıtlayabilir miyim?**

Evet. Kilitleri yalnızca seçilen slaytlardaki şekillere uygulayın. Bu, diğer slaytlardaki kilit ayarlarını değiştirmez.

**Bir grup içindeki bireysel şekillere nasıl kilit uygulayabilirim?**

Grubun [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) metodunun döndürdüğü koleksiyonu yineleyin ve her alt şekle uygun kilitleri uygulayın. Raporlama örneğindeki geçişi izleyerek, iç içe gruplar için de aynı işlemi tekrarlayın.