---
title: Ana Slayt
type: docs
weight: 30
url: /tr/net/examples/elements/master-slide/
keywords:
- ana slayt
- ana slayt ekle
- ana slayta eriş
- ana slaytı kaldır
- kullanılmayan ana slayt
- kod örneği
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ana slayt örneklerini keşfedin: PPT, PPTX ve ODP'de ana slaytları, yer tutucuları ve temaları oluşturun, düzenleyin ve biçimlendirin, net C# kodu ile."
---
Ana slaytlar, PowerPoint'te slayt kalıtım hiyerarşisinin en üst seviyesini oluşturur. **Ana slayt**, arka planlar, logolar ve metin biçimlendirmesi gibi ortak tasarım öğelerini tanımlar. **Düzen slaytları**, ana slaytlardan ve **normal slaytlar**, düzen slaytlarından kalıtım alır.

Bu makale, Aspose.Slides for .NET kullanarak ana slaytların nasıl oluşturulacağını, değiştirileceğini ve yönetileceğini gösterir.

## **Ana Slayt Ekle**

Bu örnek, varsayılan ana slaytı kopyalayarak yeni bir ana slayt oluşturmanın nasıl yapıldığını gösterir. Ardından, düzen kalıtımı yoluyla tüm slaytlara şirket adı şeridi ekler.

```csharp
static void AddMasterSlide()
{
    using var presentation = new Presentation();

    // Varsayılan ana slaytı kopyala.
    var defaultMasterSlide = presentation.Masters[0];
    var newMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

    // Ana slaytın üst kısmına şirket adı içeren bir şerit ekle.
    var textBox = newMasterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 0, y: 0, width: 720, height: 25);
    textBox.TextFrame.Text = "Company Name";
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    textBox.TextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    textBox.FillFormat.FillType = FillType.NoFill;

    // Yeni ana slaytı bir düzen slaytına ata.
    var layoutSlide = presentation.LayoutSlides[0];
    layoutSlide.MasterSlide = newMasterSlide;

    // Düzen slaytını sunumdaki ilk slayta ata.
    presentation.Slides[0].LayoutSlide = layoutSlide;
}
```

> 💡 **Not 1:** Ana slaytlar, tüm slaytlarda tutarlı marka kimliği veya ortak tasarım öğeleri uygulamak için bir yol sağlar. Ana slaytta yapılan herhangi bir değişiklik, bağımlı düzen ve normal slaytlara otomatik olarak yansır.

> 💡 **Not 2:** Bir ana slayta eklenen tüm şekiller veya biçimlendirmeler, düzen slaytları tarafından ve ardından bu düzenleri kullanan tüm normal slaytlara kalıtım yoluyla aktarılır.  
> Aşağıdaki görüntü, bir ana slayta eklenen metin kutusunun son slaytta otomatik olarak nasıl render edildiğini gösterir.

![Ana Kalıtım Örneği](master-slide-banner.png)

## **Ana Slayta Erişim**

Ana slaytlara, `Presentation.Masters` koleksiyonunu kullanarak erişebilirsiniz. İşte bunları nasıl alıp çalıştırabileceğiniz:

```csharp
static void AccessMasterSlide()
{
    using var presentation = new Presentation();

    // İlk ana slayta eriş.
    var firstMasterSlide = presentation.Masters[0];

    // Arka plan tipini değiştir.
    firstMasterSlide.Background.Type = BackgroundType.OwnBackground;
}
```

## **Ana Slaytı Kaldır**

Ana slaytlar, indeks veya referans kullanılarak kaldırılabilir.

```csharp
static void RemoveMasterSlide()
{
    using var presentation = new Presentation("sample.pptx");

    // Dizine göre bir ana slaytı kaldır.
    presentation.Masters.RemoveAt(0);

    // Referans ile bir ana slaytı kaldır.
    var firstMasterSlide = presentation.Masters[0];
    presentation.Masters.Remove(firstMasterSlide);
}
```

## **Kullanılmayan Ana Slaytları Kaldır**

Bazı sunumlar, kullanılmayan ana slaytlar içerir. Bu slaytları kaldırmak dosya boyutunun azaltılmasına yardımcı olabilir.

```csharp
static void RemoveUnusedMasterSlide()
{
    using var presentation = new Presentation();

    // Kullanılmayan tüm ana slaytları kaldır (Koruma olarak işaretlenmiş olanlar dahil).
    presentation.Masters.RemoveUnused(ignorePreserveField: true);
}
```