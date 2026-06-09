---
title: Sunum Düzenlemelerini .NET'te Şekil Kilitleriyle Önleme
linktitle: Sunum Düzenlemelerini Önleme
type: docs
weight: 70
url: /tr/net/applying-protection-to-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'in PPT, PPTX ve ODP dosyalarında şekilleri nasıl kilitlediğini veya kilidini kaldırdığını keşfedin; sunumları güvenli hale getirirken kontrollü düzenlemelere izin verir."
---
## **Arka Plan**

Aspose.Slides'in yaygın bir kullanımı, otomatik bir iş akışının parçası olarak Microsoft PowerPoint (PPTX) sunumları oluşturmak, güncellemek ve kaydetmektir. Aspose.Slides'i bu şekilde kullanan uygulamaların kullanıcıları oluşturulan sunumlara erişir, bu nedenle bunları düzenlemeden korumak yaygın bir endişedir. Otomatik olarak oluşturulan sunumların özgün biçimlendirmesini ve içeriğini koruması önemlidir.

Bu makale, sunumların ve slaytların nasıl yapılandırıldığını ve Aspose.Slides for .NET'in bir sunuma koruma nasıl uygulayabileceğini ve daha sonra nasıl kaldırabileceğini açıklar. Geliştiricilere, uygulamalarının ürettiği sunumların nasıl kullanılacağını kontrol etme imkanı sağlar.

## **Slayt Bileşimi**

Bir sunum slaytı, otomatik şekiller, tablolar, OLE nesneleri, grup şekilleri, resim çerçeveleri, video çerçeveleri, bağlayıcılar ve bir sunum oluşturmak için kullanılan diğer öğeler gibi bileşenlerden oluşur. Aspose.Slides for .NET'te, bir slayttaki her öğe, [IShape](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/) arayüzünü uygulayan veya bu arayüzü uygulayan bir sınıftan türeyen bir nesneyle temsil edilir.

PPTX yapısı karmaşıktır, bu yüzden tüm şekil türleri için genel bir kilit kullanılabilen PPT'den farklı olarak, farklı şekil tipleri farklı kilitler gerektirir. [IBaseShapeLock](https://reference.aspose.com/slides/tr/net/aspose.slides/ibaseshapelock/) arayüzü, PPTX için genel kilitleme sınıfıdır. Aspose.Slides for .NET, PPTX için aşağıdaki kilit türlerini destekler:

- [IAutoShapeLock](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshapelock/) otomatik şekilleri kilitler.  
- [IConnectorLock](https://reference.aspose.com/slides/tr/net/aspose.slides/iconnectorlock/) bağlayıcı şekilleri kilitler.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/tr/net/aspose.slides/igraphicalobjectlock/) grafik nesneleri kilitler.  
- [IGroupShapeLock](https://reference.aspose.com/slides/tr/net/aspose.slides/igroupshapelock/) grup şekilleri kilitler.  
- [IPictureFrameLock](https://reference.aspose.com/slides/tr/net/aspose.slides/ipictureframelock/) resim çerçevelerini kilitler.  

Bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) nesnesindeki tüm şekil nesnelerine yapılan herhangi bir işlem, tüm sunuma uygulanır.

## **Koruma Uygulama ve Kaldırma**

Koruma uygulamak, bir sunumun düzenlenememesini sağlar. Sunum içeriğini korumak için yararlı bir tekniktir.

### **PPTX Şekillerine Koruma Uygulama**

Aspose.Slides for .NET, bir slayttaki şekillerle çalışmak için [IShape](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/) arayüzünü sunar.

Daha önce belirtildiği gibi, her şekil sınıfının koruma için ilişkili bir shape-lock sınıfı vardır. Bu makale NoSelect, NoMove ve NoResize kilitlerine odaklanır. Bu kilitler, şekillerin (fare tıklamaları veya diğer seçim yöntemleriyle) seçilememesini ve taşınamamasını veya yeniden boyutlandırılamamasını sağlar.

Aşağıdaki kod örneği, bir sunumdaki tüm şekil türlerine koruma uygular.

```cs
// PPTX dosyasını temsil eden Presentation sınıfını örnekleyin.
using Presentation presentation = new Presentation("Sample.pptx");

// Sunumdaki tüm slaytları dolaşıyor.
foreach (ISlide slide in presentation.Slides)
{
    // Slayttaki tüm şekilleri dolaşıyor.
    foreach (IShape shape in slide.Shapes)
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

// Sunum dosyasını kaydediyor.
presentation.Save("ProtectedSample.pptx", SaveFormat.Pptx);
```

### **Koruma Kaldırma**

Bir şeklin kilidini açmak için, uygulanan kilidin değerini `false` olarak ayarlayın. Aşağıdaki kod örneği, kilitli bir sunumda şekillerin kilidini nasıl açacağınızı gösterir.

```cs
// PPTX dosyasını temsil eden Presentation sınıfını örnekleyin.
using Presentation presentation = new Presentation("ProtectedSample.pptx");

// Sunumdaki tüm slaytları dolaşıyor.
foreach (ISlide slide in presentation.Slides)
{
    // Slayttaki tüm şekilleri dolaşıyor.
    foreach (IShape shape in slide.Shapes)
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

// Sunum dosyasını kaydediyor.
presentation.Save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
```

### **Sonuç**

Aspose.Slides, bir sunumdaki şekilleri korumak için çeşitli seçenekler sunar. Tek bir şekli kilitleyebilir veya bir sunumdaki tüm şekiller üzerinde döngü yaparak her birini kilitleyebilir ve böylece tüm dosyayı etkili bir şekilde güvene alabilirsiniz. Kilit değerini `false` olarak ayarlayarak korumayı kaldırabilirsiniz.

## **SSS**

**Aynı sunumda şekil kilitlerini ve şifre korumasını birleştirebilir miyim?**

Evet. Kilitler, dosya içindeki nesnelerin düzenlenmesini sınırlar, [password protection](/slides/tr/net/password-protected-presentation/) ise açma ve/veya değişiklikleri kaydetme erişimini kontrol eder. Bu mekanizmalar birbirini tamamlar ve birlikte çalışır.

**Belirli slaytlarda düzenlemeyi kısıtlayabilir, diğerlerini etkilemeden bırakabilir miyim?**

Evet. Seçili slaytlardaki şekillere kilitler uygulayın; kalan slaytlar düzenlenebilir kalır.

**Şekil kilitleri grup nesneleri ve bağlayıcılar için geçerli mi?**

Evet. Gruplar, bağlayıcılar, grafik nesneler ve diğer şekil türleri için özel kilit tipleri desteklenir.