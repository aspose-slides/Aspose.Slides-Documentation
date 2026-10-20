---
title: .NET'te Şekil Kilitleri ile Sunum Düzenlemelerini Kısıtla
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
description: "Aspose.Slides for .NET ile PPTX sunumlarında şekilleri nasıl kilitleyeceğinizi ve kilidini kaldıracağınızı öğrenin; seçim, hareket, yeniden boyutlandırma ve gruplamayı kısıtlamak için."
---
## **Arka Plan**

Aspose.Slides for .NET'in yaygın bir kullanımı, otomatik bir iş akışının parçası olarak PowerPoint (PPTX) sunumları oluşturmak, güncellemek ve kaydetmektir. Kullanıcılar bu sunumları aldıklarında, şekillerdeki değişiklikleri kısıtlamak, istenen düzeni ve içeriği korumaya yardımcı olabilir.

Bu makale, şekillerin slaytlarda nasıl düzenlendiğini ve bir PPTX sunumunda şekil kilitlerinin nasıl uygulanıp kaldırılacağını açıklar. Bu kilitler, tek tek şekillerde belirli düzenleme işlemlerini kısıtlamanızı sağlar.

## **Bir Slaytın Bileşimi**

Bir sunum slaytı, otomatik şekiller, tablolar, OLE nesneleri, gruplanmış şekiller, resim çerçeveleri, video çerçeveleri, bağlayıcılar ve bir sunum oluşturmak için kullanılan diğer öğeler gibi bileşenlerden oluşur. Aspose.Slides for .NET'te, slayttaki her öğe, [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) arayüzünü uygulayan veya bu arayüzü miras alan bir nesneyle temsil edilir.

Farklı şekil türleri farklı kilitleme seçenekleri sunar. [IBaseShapeLock](https://reference.aspose.com/slides/net/aspose.slides/ibaseshapelock/) arayüzü, şekil kilitleri için temel arayüzdür. Aspose.Slides for .NET aşağıdaki kilit arayüzlerini sağlar:

- [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/) otomatik şekilleri kilitler.  
- [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) bağlayıcı şekilleri kilitler.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/) grafik nesneleri kilitler.  
- [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/) grup şekillerini kilitler.  
- [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) resim çerçevelerini kilitler.  

Bir [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) içinde kilitleri uygulamak için, slaytlarını dolaşın ve her desteklenen şekil üzerinde uygun kilitleri ayarlayın.

## **Koruma Uygulama ve Kaldırma**

Şekil kilitleri, şekilleri seçme, taşıma ve yeniden boyutlandırma gibi işlemleri kısıtlar. Tüm sunumu düzenlenemez hâle getirmez.

### **PPTX Şekillerine Koruma Uygulama**

Aspose.Slides for .NET, bir slayttaki şekillerle çalışmak için [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) arayüzünü sağlar.

Örnek, otomatik şekiller için [SelectLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/selectlocked/), [PositionLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/positionlocked/) ve [SizeLocked](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/sizelocked/) özelliklerini `true` olarak ayarlar; grup şekilleri, bağlayıcılar ve resim çerçeveleri için eşdeğer kilitler bulunur. Bağlayıcılar hareket için [PositionMove](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/positionmove/) kullanır; gruplar ayrıca gruplamayı sınırlamak için [GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) kullanır.

Örnek, mevcut bir PPTX sunumunu yükler, her slaydın şekil koleksiyonundaki şekilleri kontrol eder ve bu kısıtlamalar uygulanmış bir kopyasını kaydeder. Dört işlenen tür dışındaki şekiller değişmeden kalır. Döngü, bir grup içindeki alt şekilleri dolaşmaz.

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

Bir şekil kilidini kaldırmak için, değerini `false` olarak ayarlayın. Aşağıdaki örnek, şekil kilitleri olan bir sunumu yükler ve [IAutoShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/net/aspose.slides/iconnectorlock/) ve [IPictureFrameLock](https://reference.aspose.com/slides/net/aspose.slides/ipictureframelock/) aracılığıyla seçim, hareket ve yeniden boyutlandırma kısıtlamalarını temizler. Ayrıca [IGroupShapeLock.GroupingLocked](https://reference.aspose.com/slides/net/aspose.slides/igroupshapelock/groupinglocked/) özelliğini temizler ve sunumun bir kopyasını kaydeder. Diğer kilit ayarları değişmeden kalır.

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

### **Sonuç**

Aspose.Slides for .NET, tek tek şekillerde belirli düzenleme işlemlerini kısıtlamanıza veya aynı kısıtlamaları slaytlar arasında uygulamanıza olanak tanır. Her şekil türü tarafından desteklenen kilitleri seçin ve bu kısıtlamaları kaldırmanız gerektiğinde değerlerini `false` olarak ayarlayın.

## **SSS**

**Aynı sunumda şekil kilitlerini ve şifre korumasını birleştirebilir miyim?**

Evet. Şekil kilitleri belirli düzenleme işlemlerini kısıtlarken, [password protection](/slides/tr/net/password-protected-presentation/) sunumun açılmasını veya değiştirilmesini kısıtlayabilir. İkisini aynı dosyada kullanabilirsiniz.

**Diğer slaytları etkilemeden belirli slaytlarda düzenlemeyi kısıtlayabilir miyim?**

Evet. Kilitleri yalnızca seçilen slaytlardaki şekillere uygulayın. Bu, diğer slaytlardaki kilit ayarlarını değiştirmez.

**Bir grup içinde tek tek şekillere nasıl kilit uygulayabilirim?**

Grup'un [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) koleksiyonunda dolaşın ve her alt şekle uygun kilitleri uygulayın. İç içe gruplar için de bu işlemi tekrarlayın. Yukarıdaki örnekler yalnızca slaydın şekil koleksiyonunu işler, bu yüzden bireysel grup üyelerine kilit uygulamaz.