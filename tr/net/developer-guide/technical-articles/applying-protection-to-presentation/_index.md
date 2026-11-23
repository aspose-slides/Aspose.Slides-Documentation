---
title: Şekil Kilitleri ile .NET'te Sunum Düzenlemelerini Kısıtlama
linktitle: Sunum Düzenlemelerini Kısıtlama
type: docs
weight: 70
url: /tr/net/applying-protection-to-presentation/
keywords:
- düzenlemeleri engelleme
- düzenlemeden koruma
- şekil kilitleme
- konum kilitleme
- seçimi kilitleme
- yeniden boyutlandırmayı kilitleme
- gruplamayı kilitleme
- PowerPoint
- PPTX
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PPTX sunumlarındaki şekilleri kilitleme ve kilidini açma, seçim, hareket, yeniden boyutlandırma ve gruplamayı kısıtlama yollarını öğrenin."
---
## **Arka Plan**

Aspose.Slides for .NET'in yaygın bir kullanımı, otomatik bir iş akışının parçası olarak PowerPoint (PPTX) sunumlarını oluşturmak, güncellemek ve kaydetmektir. Kullanıcılar bu sunumları aldıklarında, şekillerdeki değişiklikleri kısıtlamak, istenen düzeni ve içeriği korumaya yardımcı olur.

Bu makale, şekillerin slaytlarda nasıl düzenlendiğini ve bir PPTX sunumunda şekil kilitlerinin nasıl uygulanıp kaldırılacağını açıklar. Bu kilitler, tek tek şekillerde belirli düzenleme işlemlerini kısıtlamanızı sağlar.

## **Bir Slaytın Bileşimi**

Bir sunum slaytı, otomatik şekiller, tablolar, OLE nesneleri, gruplanmış şekiller, resim çerçeveleri, video çerçeveleri, bağlayıcılar ve bir sunum oluşturmak için kullanılan diğer öğeler gibi bileşenlerden oluşur. Aspose.Slides for .NET'te, bir slayttaki her öğe, [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) arabirimini uygulayan veya bu arabirimden türeyen bir nesneyle temsil edilir.

Farklı şekil türleri farklı kilitleme seçenekleri sunar. [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) arabirimi, şekil kilitleri için temel arabirimdir. Aspose.Slides for .NET aşağıdaki kilit arabirimlerini sağlar:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) otomatik şekilleri kilitler.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) bağlayıcı şekilleri kilitler.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) grafik nesneleri kilitler.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) grup şekillerini kilitler.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) resim çerçevelerini kilitler.  

Bir [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) içinde kilitleri uygulamak için slaytları döngüyle gezip her desteklenen şekle uygun kilitleri ayarlayın.

## **Koruma Uygulama ve Kaldırma**

Uyumlu sunum editörleri, bireysel düzenleme işlemlerini kısıtlamak için şekil kilitlerini kullanır. Dosya şifreleme ve belge‑seviyesi yazma koruması ayrı [presentation protection settings](/slides/tr/net/password-protected-presentation/) olarak bulunur.

### **PPTX Şekillerine Koruma Uygulama**

Aspose.Slides for .NET, bir slayttaki şekillerle çalışmak için [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) arabirimini sunar.

Örnek, otomatik şekiller için [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/), [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/) ve [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) özelliklerini `true` olarak ayarlar; grup şekilleri, bağlayıcılar ve resim çerçeveleri için eşdeğer kilitleri uygular. Bağlayıcılar hareket için [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) kullanır; gruplar ayrıca gruplamayı kısıtlamak için [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) kullanır.

Örnek, mevcut bir PPTX sunumunu yükler, her slaytın şekil koleksiyonundaki şekilleri denetler ve bu kısıtlamalar uygulanmış bir kopya kaydeder. Dört ele alınan tür dışındaki şekiller değiştirilmeden bırakılır. Döngü, bir grup içindeki alt şekilleri gezmez.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = true;
            autoShape.ShapeLock.SelectLocked = true;
            autoShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = true;
            groupShape.ShapeLock.PositionLocked = true;
            groupShape.ShapeLock.SelectLocked = true;
            groupShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = true;
            connectorShape.ShapeLock.SelectLocked = true;
            connectorShape.ShapeLock.SizeLocked = true;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = true;
            pictureFrame.ShapeLock.SelectLocked = true;
            pictureFrame.ShapeLock.SizeLocked = true;
        }
    }
}

presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```

### **Koruma Kaldırma**

Bir şekil kilidini kaldırmak için değerini `false` olarak ayarlayın. Aşağıdaki örnek, şekil kilitli bir sunumu yükler ve [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) ve [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) aracılığıyla seçim, hareket ve yeniden boyutlandırma kısıtlamalarını temizler. Aynı zamanda [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) özelliğini temizler ve sunumun bir kopyasını kaydeder. Diğer kilit ayarları değişmeden kalır.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ProtectedSample.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            autoShape.ShapeLock.PositionLocked = false;
            autoShape.ShapeLock.SelectLocked = false;
            autoShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IGroupShape groupShape)
        {
            groupShape.ShapeLock.GroupingLocked = false;
            groupShape.ShapeLock.PositionLocked = false;
            groupShape.ShapeLock.SelectLocked = false;
            groupShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IConnector connectorShape)
        {
            connectorShape.ShapeLock.PositionMove = false;
            connectorShape.ShapeLock.SelectLocked = false;
            connectorShape.ShapeLock.SizeLocked = false;
        }
        else if (shape is IPictureFrame pictureFrame)
        {
            pictureFrame.ShapeLock.PositionLocked = false;
            pictureFrame.ShapeLock.SelectLocked = false;
            pictureFrame.ShapeLock.SizeLocked = false;
        }
    }
}

presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```

### **Resim Kırpmasını Korumak**

Çalışma klasörüne `photo.jpg` adlı bir fotoğraf yerleştirin. Örnek, soldan %12, sağdan %8 kırpar ve ardından resim çerçevesine [CropLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/croplocked/) özelliğini ayarlar. Bu bayrak, sonraki kırpma işlemlerini engeller ve mevcut kırpmayı korur.

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var photoBytes = File.ReadAllBytes("photo.jpg");
var photo = presentation.Images.AddImage(photoBytes);

var pictureFrame = shapes.AddPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo);
pictureFrame.PictureFormat.CropLeft = 12;
pictureFrame.PictureFormat.CropRight = 8;
pictureFrame.PictureFrameLock.AspectRatioLocked = false;
pictureFrame.PictureFrameLock.CropLocked = true;

presentation.Save("PictureLocked.pptx", SaveFormat.Pptx);
```

`PictureLocked.pptx` kırpma kilidini `true` olarak saklar. PowerPoint'te fotoğraf seçili olduğunda **Crop** (Kırp) komutu devre dışı bırakılır.

### **Bir Diyagramı Gruplı Tutmak**

Örnek bir dikdörtgen ve bir ok gruplar, ardından grup üzerinde [UngroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/ungroupinglocked/) özelliğini ayarlayarak diyagram bileşenlerinin bir arada kalmasını sağlar. Grubu hareket ettirme veya bir bileşenin dolgusunu değiştirme gibi diğer düzenlemeler kullanılabilir olmaya devam eder.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var groupShape = shapes.AddGroupShape();
groupShape.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 70, 90, 50);
groupShape.Shapes.AddAutoShape(ShapeType.RightArrow, 190, 80, 60, 30);
groupShape.GroupShapeLock.UngroupingLocked = true;

presentation.Save("DiagramLocked.pptx", SaveFormat.Pptx);
```

`DiagramLocked.pptx` gruplama kaldırma kilidini `true` olarak saklar. PowerPoint'te tüm diyagram seçili olduğunda **Ungroup** (Gruplamayı Kaldır) komutu devre dışı bırakılır.

### **Sonuç**

Aspose.Slides for .NET, bireysel şekillerde belirli düzenleme işlemlerini kısıtlamanıza veya aynı kısıtlamaları birden çok slaytta uygulamanıza olanak tanır. Her şekil türünün desteklediği kilitleri seçin ve bu kısıtlamaları kaldırmanız gerektiğinde değerlerini `false` olarak ayarlayın.

## **SSS**

**Şekil kilitlerini şifre korumasıyla aynı sunumda birleştirebilir miyim?**

Evet. Şekil kilitleri belirli düzenleme işlemlerini kısıtlarken, [password protection](/slides/tr/net/password-protected-presentation/) sunumun açılmasını veya değiştirilmesini kısıtlayabilir. Her ikisini de aynı dosyada kullanabilirsiniz.

**Diğer slaytları etkilemeden belirli slaytlar üzerinde düzenlemeyi kısıtlayabilir miyim?**

Evet. Kilitleri yalnızca seçili slaytlardaki şekillere uygulayın. Bu, diğer slaytlardaki kilit ayarlarını değiştirmez.

**Bir grup içindeki bireysel şekillere kilit uygulayabilir miyim?**

Grubun [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) koleksiyonunu döngüyle gezerek her alt şekle uygun kilitleri uygulayın. Bu işlemi iç içe gruplar için de tekrarlayın. Yukarıdaki örnekler yalnızca slaytın şekil koleksiyonunu işler, bu nedenle grup üyeleri üzerinde kilit ayarlamaz.