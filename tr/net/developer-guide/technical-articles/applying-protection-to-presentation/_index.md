---
title: Şekil Kilitleri ile .NET’te Sunum Düzenlemelerini Kısıtla
linktitle: Sunum Düzenlemelerini Kısıtla
type: docs
weight: 70
url: /tr/net/applying-protection-to-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PPTX sunumlarında şekilleri nasıl kilitleyeceğinizi ve kilidini açacağınızı öğrenerek seçim, hareket, yeniden boyutlandırma ve gruplamayı kısıtlayın."
---
## **Arka Plan**

Aspose.Slides for .NET için yaygın bir kullanım, otomatik bir iş akışının parçası olarak PowerPoint (PPTX) sunumlarını oluşturmak, güncellemek ve kaydetmektir. Kullanıcılar bu sunumları aldıklarında, şekillerdeki değişiklikleri kısıtlamak amaçlanan düzen ve içeriğin korunmasına yardımcı olabilir.

Bu makale, şekillerin slaytlarda nasıl düzenlendiğini ve bir PPTX sunumunda şekil kilitlerinin nasıl uygulanıp kaldırılacağını açıklar. Bu kilitler, tek tek şekillerde belirli düzenleme işlemlerini kısıtlamanızı sağlar.

## **Bir Slaytın Bileşimi**

Bir sunum slaytı, otomatik şekiller, tablolar, OLE nesneleri, gruplanmış şekiller, resim çerçeveleri, video çerçeveleri, bağlayıcılar ve sunum oluşturmak için kullanılan diğer öğeler gibi bileşenlerden oluşur. Aspose.Slides for .NET’te bir slayttaki her öğe, [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) arayüzünü uygulayan bir nesneyle temsil edilir veya bu arayüzü miras alan bir sınıftan türetilir.

Farklı şekil türleri farklı kilitleme seçenekleri sunar. [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) arayüzü, şekil kilitlerinin temel arayüzüdür. Aspose.Slides for .NET aşağıdaki kilit arayüzlerini sağlar:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) otomatik şekilleri kilitler.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) bağlayıcı şekilleri kilitler.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) grafik nesneleri kilitler.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) grup şekillerini kilitler.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) resim çerçevelerini kilitler.  

[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) içinde kilit uygulamak için slaytları dolaşın ve desteklenen her şekil için uygun kilitleri ayarlayın.

## **Koruma Uygulama ve Kaldırma**

Uyumlu sunum editörleri, tek tek düzenleme işlemlerini kısıtlamak için şekil kilitlerini kullanır. Dosya şifreleme ve belge‑seviyesinde yazma koruması ayrı [presentation protection settings](/slides/tr/net/password-protected-presentation/) olarak bulunur.

### **PPTX Şekillerine Koruma Uygulama**

Aspose.Slides for .NET, bir slayttaki şekillerle çalışmak için [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) arayüzünü sağlar.

Örnek, otomatik şekiller için [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/), [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/) ve [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) özelliklerini `true` olarak ayarlar; grup şekilleri, bağlayıcılar ve resim çerçeveleri için eşdeğer kilitler uygulanır. Bağlayıcılar hareket için [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) kullanır; gruplar ayrıca gruplamayı kısıtlamak için [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) kullanır.

Örnek, mevcut bir PPTX sunumunu yükler, her slaydın şekil koleksiyonundaki şekilleri kontrol eder ve bu kısıtlamalar uygulanmış bir kopyayı kaydeder. Dört işlenen tür dışındaki şekiller değiştirilmeden bırakılır. Döngü, bir grup içindeki alt şekilleri dolaşmaz.

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

Bir şekil kilidini kaldırmak için değerini `false` olarak ayarlayın. Aşağıdaki örnek, şekil kilitleri olan bir sunumu yükler ve seçim, hareket ve yeniden boyutlandırma kısıtlamalarını [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) ve [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) aracılığıyla temizler. Ayrıca [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) özelliğini temizler ve sunumun bir kopyasını kaydeder. Diğer kilit ayarları değiştirilmeden bırakılır.

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

### **Resim Kırpmasını Koruma**

Çalışma dizinine `photo.jpg` adlı bir fotoğraf yerleştirin. Örnek, soldan %12 ve sağdan %8 kırpar, ardından resim çerçevesinde [CropLocked](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/croplocked/) özelliğini ayarlar. Bu bayrak, sonraki kırpmaları kısıtlar ve mevcut kırpmayı korur.

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

`PictureLocked.pptx` kırpma kilidini `true` olarak depolar. PowerPoint’te fotoğraf seçili olduğunda **Crop** komutu devre dışı bırakılır.

### **Bir Diyagramı Gruplu Tutma**

Örnek bir dikdörtgen ve bir ok gruplar, ardından grupta [UngroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/ungroupinglocked/) özelliğini ayarlar; bu sayede diyagramın bileşenleri bir arada tutulur. Grubu hareket ettirme veya bir bileşenin dolgusunu değiştirme gibi diğer düzenlemeler kullanılabilir.

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

`DiagramLocked.pptx` gruplamayı kaldırma kilidini `true` olarak depolar. PowerPoint’te tüm diyagram seçili olduğunda **Ungroup** komutu devre dışı bırakılır.

### **Mevcut Şekil Kilitlerini Raporlama**

Bir şablonu incelemek için açın ve her şekil için kilit nesnesini okuyun. [NoLocks](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/nolocks/) nesnesi, o nesnedeki tüm bayraklar devre dışı olduğunda `true`, en az bir bayrak etkin olduğunda `false` döndürür. Bir grup ve onun alt elemanları ayrı kilit nesnelerine sahiptir; bu yüzden grup kilidi olmasa bile alt elemanları inceleyin.

Bu örnek, otomatik şekiller, resim çerçeveleri ve gruplar için hareketi, resimler için kırpmayı ve gruplar için gruplamayı kaldırmayı kontrol eder. Tanıdığı bayrakları raporlar ve incelemediği şekil türlerini işaretler.

```cs
using System;
using System.Collections.Generic;
using Aspose.Slides;

using var presentation = new Presentation("Sample.pptx");
foreach (var slide in presentation.Slides)
{
    Inspect(slide.Shapes, slide.SlideNumber, "");
}

static void Inspect(IShapeCollection shapes, int slideNumber, string prefix)
{
    foreach (var shape in shapes)
    {
        var path = prefix + shape.Name;
        var label = $"Slide {slideNumber} | {path} | {shape.GetType().Name}";
        var flags = new List<string>();
        IBaseShapeLock shapeLock;

        switch (shape)
        {
            case IGroupShape group:
                shapeLock = group.ShapeLock;
                if (group.ShapeLock.UngroupingLocked) flags.Add("UngroupingLocked");
                if (group.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            case IPictureFrame picture:
                shapeLock = picture.ShapeLock;
                if (picture.ShapeLock.CropLocked) flags.Add("CropLocked");
                if (picture.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            case IAutoShape autoShape:
                shapeLock = autoShape.ShapeLock;
                if (autoShape.ShapeLock.PositionLocked) flags.Add("PositionLocked");
                break;
            default:
                Console.WriteLine($"{label} | Uninspected");
                continue;
        }

        if (!shapeLock.NoLocks)
        {
            var restrictions = flags.Count > 0 ? string.Join(", ", flags) : "Active flag not identified";
            Console.WriteLine($"{label} | {restrictions}");
        }

        if (shape is IGroupShape parent)
            Inspect(parent.Shapes, slideNumber, path + "/");
    }
}
```

Örneğin, `Sample.pptx` dosyasının 1. slaytında `Layout` adlı bir grup, gruplamayı kaldırma kilidi etkin, içinde `Photo` adlı bir resim kırpma kilidi etkin ve `Free` adlı kilidi kaldırılmış bir dikdörtgen bulunuyor. Rapor, `Free` öğesini atlar ve şu iki satırı yazar:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Rapor, şekil‑seviyesi düzenleme bayraklarını değişiklik yapmadan ve sunumu kaydetmeden okur. Belge‑seviyesindeki yazma koruması ayrı bir ayardır ve her bayrağın uygulanması editöre bağlıdır.

### **Sonuç**

Aspose.Slides for .NET, tek tek şekillerde belirli düzenleme işlemlerini kısıtlamanıza veya aynı kısıtlamaları slaytlar boyunca uygulamanıza olanak tanır. Her şekil türü tarafından desteklenen kilitleri seçin ve bu kısıtlamaları kaldırmanız gerektiğinde değerlerini `false` olarak ayarlayın.

## **SSS**

**Şekil kilitlerini ve parola korumasını aynı sunumda birleştirebilir miyim?**

Evet. Şekil kilitleri belirli düzenleme işlemlerini kısıtlarken, [password protection](/slides/tr/net/password-protected-presentation/) sunumun açılmasını veya değiştirilmesini kısıtlayabilir. Her ikisini de aynı dosyada kullanabilirsiniz.

**Belirli slaytlarda düzenlemeyi kısıtlayıp diğerlerini etkilemeden nasıl yapabilirim?**

Evet. Kilitleri yalnızca seçili slaytlardaki şekillere uygulayın. Bu, diğer slaytlardaki kilit ayarlarını değiştirmez.

**Grup içindeki tek tek şekillere kilit uygulamak nasıl mümkün?**

Grubun [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) koleksiyonunu dolaşın ve her alt şekle uygun kilitleri uygulayın. İç içe gruplar için bu işlemi tekrarlayın; raporlama örneğindeki dolaşım mantığını izleyin.