---
title: Metin Kutusu
type: docs
weight: 40
url: /tr/net/examples/elements/text-box/
keywords:
- metin kutusu
- metin kutusu ekle
- metin kutusuna eriş
- metin kutusunu kaldır
- kod örneği
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'te metin kutularıyla çalışın: C# kullanarak PPT, PPTX ve ODP sunumları için metin ekleyin, biçimlendirin, hizalayın, kaydırın, otomatik sığdırın ve stil verin."
---
Aspose.Slides'te bir **metin kutusu**, bir `AutoShape` ile temsil edilir. Neredeyse her şekil metin içerebilir, ancak tipik bir metin kutusunun dolgu veya kenarı yoktur ve yalnızca metni gösterir.

Bu kılavuz, metin kutularını programlı olarak nasıl ekleyeceğinizi, erişeceğinizi ve kaldıracağınızı açıklar.

## **Metin Kutusu Ekle**

Bir metin kutusu, sadece dolgu ve kenarı olmayan ve biçimlendirilmiş metin içeren bir `AutoShape`'dır. İşte bir tane nasıl oluşturulur:

```csharp
public static void AddTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Bir dikdörtgen şekil oluştur (varsayılan olarak kenarlıklı ve dolgu ile, metin yok).
    var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x: 50, y: 75, width: 150, height: 100);

    // Dolgu ve kenarlığı kaldırarak tipik bir metin kutusu gibi görünmesini sağla.
    textBox.FillFormat.FillType = FillType.NoFill;
    textBox.LineFormat.FillFormat.FillType = FillType.NoFill;

    // Metin biçimlendirmesini ayarla.
    var paragraph = textBox.TextFrame.Paragraphs[0];
    var textFormat = paragraph.ParagraphFormat.DefaultPortionFormat;
    textFormat.FillFormat.FillType = FillType.Solid;
    textFormat.FillFormat.SolidFillColor.Color = Color.Black;

    // Gerçek metin içeriğini ata.
    textBox.TextFrame.Text = "Some text...";
}
```

> 💡 **Not:** Boş olmayan bir `TextFrame` içeren herhangi bir `AutoShape`, bir metin kutusu olarak işlev görebilir.

## **İçeriğe Göre Metin Kutularına Erişim**

Belirli bir anahtar kelimeyi (ör. "Slide") içeren tüm metin kutularını bulmak için şekiller arasında döngü yapın ve metinlerini kontrol edin:

```csharp
public static void AccessTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    foreach (var shape in slide.Shapes)
    {
        // Yalnızca AutoShape'ler düzenlenebilir metin içerebilir.
        if (shape is AutoShape autoShape)
        {
            if (autoShape.TextFrame.Text.Contains("Slide"))
            {
                // Eşleşen metin kutusuyla bir şey yap.
            }
        }
    }
}
```

## **İçeriğe Göre Metin Kutularını Kaldır**

Bu örnek, belirli bir anahtar kelimeyi içeren ilk slayttaki tüm metin kutularını bulur ve siler:

```csharp
public static void RemoveTextBox()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shapesToRemove = slide.Shapes
        .Where(s => s is AutoShape autoShape && autoShape.TextFrame.Text.Contains("Slide"))
        .ToList();

    shapesToRemove.ForEach(shape => slide.Shapes.Remove(shape));
}
```

> 💡 **İpucu:** Döngü sırasında koleksiyonu değiştirmeden önce her zaman şekil koleksiyonunun bir kopyasını oluşturun; böylece koleksiyon değiştirme hatalarından kaçınmış olursunuz.