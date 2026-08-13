---
title: .NET'te Sunumlardan Şekil Etkin Özelliklerini Al
linktitle: Etkin Özellikler
type: docs
weight: 50
url: /tr/net/shape-effective-properties/
keywords:
- şekil özellikleri
- kamera özellikleri
- ışık kiti
- eğim şekli
- metin çerçevesi
- metin stili
- yazı tipi yüksekliği
- doldurma biçimi
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'in doğru PowerPoint renderlaması için şekil etkin özelliklerini nasıl hesapladığını ve uyguladığını keşfedin."
---
## **Genel Bakış**

Bu konu **yerel** ve **etkin** özellikler arasındaki farkı açıklar. Yerel değerler, belirli bir biçimlendirme seviyesinde doğrudan ayarlanan değerlerdir, örneğin:

1. Bir slayttaki bölüm özellikleri.
1. Bölümün metin çerçevesi şekli bir stil içerdiğinde, bir yerleşim veya ana slaytta prototip şekil metin stilleri.
1. Bir sunumdaki global metin ayarları.

Yerel değerler herhangi bir seviyede tanımlanabilir veya atlanabilir. Aspose.Slides nihai "görünüm" biçimlendirmesine ihtiyaç duyduğunda, kalıtım zincirini çözer ve **etkin** değerleri döndürür. Bunları, yerel biçim nesnesi üzerinde `GetEffective` metodunu çağırarak alabilirsiniz.

Aşağıdaki örnek, etkin değerlerin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin bir metin çerçevesi ve en az bir bölüm içeren bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) olduğunu varsayar.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var localTextFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = localTextFrameFormat.GetEffective();

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
var localPortionFormat = portion.PortionFormat;
var effectivePortionFormat = localPortionFormat.GetEffective();
```

{{% alert color="info" %}}
Etkin biçimlendirme verileri, kalıtım uygulandıktan sonra mevcut hesaplanmış biçimlendirmeyi temsil eder. Mevcut uygulamada, [IPortionFormatEffectiveData](https://reference.aspose.com/slides/tr/net/aspose.slides/iportionformateffectivedata/) gibi bazı etkin veri nesneleri dahili olarak önbelleğe alınabilir. Üst veya kalıtılan biçimlendirme değiştirildikten sonra `GetEffective` metodunu tekrar çağırmak önbellek verilerini yenileyebilir ve daha önce alınan nesne artık önceki durumu temsil etmeyebilir. Etkin değerleri daha sonra tekrar kullanmak istiyorsanız, yazı tipi yüksekliği, doldurma rengi, yazı tipi stili veya hizalama gibi gerekli özellikleri kendi veri nesnenize kopyalayın.
{{% /alert %}}

## **Kamera İçin Etkin Özellikleri Al**

Aspose.Slides, bir kameranın etkin özelliklerini almanıza olanak tanır. [ICameraEffectiveData](https://reference.aspose.com/slides/tr/net/aspose.slides/icameraeffectivedata/) arabirimi, etkin kamera özelliklerini içeren değiştirilemez bir nesneyi temsil eder. Bir [ICameraEffectiveData](https://reference.aspose.com/slides/tr/net/aspose.slides/icameraeffectivedata/) örneği, [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformateffectivedata/) aracılığıyla ortaya çıkar ve [IThreeDFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/) için etkin değerler sağlar.

Aşağıdaki kod örneği, kamera için etkin özelliklerin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin 3D biçimlendirmesine sahip olduğunu varsayar.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective camera properties =");
Console.WriteLine("Type: " + threeDEffectiveData.Camera.CameraType);
Console.WriteLine("Field of view: " + threeDEffectiveData.Camera.FieldOfViewAngle);
Console.WriteLine("Zoom: " + threeDEffectiveData.Camera.Zoom);
```

## **Işık Kiti İçin Etkin Özellikleri Al**

Aspose.Slides, bir ışık kitinin etkin özelliklerini almanıza olanak tanır. [ILightRigEffectiveData](https://reference.aspose.com/slides/tr/net/aspose.slides/ilightrigeffectivedata/) arabirimi, etkin ışık kiti özelliklerini içeren değiştirilemez bir nesneyi temsil eder. Bir [ILightRigEffectiveData](https://reference.aspose.com/slides/tr/net/aspose.slides/ilightrigeffectivedata/) örneği, [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformateffectivedata/) aracılığıyla ortaya çıkar ve [IThreeDFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/) için etkin değerler sağlar.

Aşağıdaki kod örneği, ışık kiti için etkin özelliklerin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin 3D biçimlendirmesine sahip olduğunu varsayar.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective light rig properties =");
Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
```

## **Eğim Şeklinin Etkin Özelliklerini Al**

Aspose.Slides, bir şekil eğiminin etkin özelliklerini almanıza olanak tanır. [IShapeBevelEffectiveData](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapebeveleffectivedata/) arabirimi, bir şeklin etkin yüz-gösterim özelliklerini içeren değiştirilemez bir nesneyi temsil eder. Bir [IShapeBevelEffectiveData](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapebeveleffectivedata/) örneği, [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformateffectivedata/) aracılığıyla ortaya çıkar ve [IThreeDFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/) için etkin değerler sağlar.

Aşağıdaki kod örneği, bir şeklin üst eğimi için etkin özelliklerin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin 3D biçimlendirmesine sahip olduğunu varsayar.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective shape's top face relief properties =");
Console.WriteLine("Type: " + threeDEffectiveData.BevelTop.BevelType);
Console.WriteLine("Width: " + threeDEffectiveData.BevelTop.Width);
Console.WriteLine("Height: " + threeDEffectiveData.BevelTop.Height);
```

## **Metin Çerçevesinin Etkin Özelliklerini Al**

Aspose.Slides kullanarak bir metin çerçevesinin etkin özelliklerini alabilirsiniz. [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframeformateffectivedata/) arabirimi, etkin metin çerçevesi biçimlendirme özelliklerini içerir.

Aşağıdaki kod örneği, etkin metin çerçevesi biçimlendirme özelliklerinin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin bir metin çerçevesi içeren bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) olduğunu varsayar.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var textFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = textFrameFormat.GetEffective();

Console.WriteLine("Anchoring type: " + effectiveTextFrameFormat.AnchoringType);
Console.WriteLine("Autofit type: " + effectiveTextFrameFormat.AutofitType);
Console.WriteLine("Text vertical type: " + effectiveTextFrameFormat.TextVerticalType);
Console.WriteLine("Margins");
Console.WriteLine("   Left: " + effectiveTextFrameFormat.MarginLeft);
Console.WriteLine("   Top: " + effectiveTextFrameFormat.MarginTop);
Console.WriteLine("   Right: " + effectiveTextFrameFormat.MarginRight);
Console.WriteLine("   Bottom: " + effectiveTextFrameFormat.MarginBottom);
```

## **Metin Stilinin Etkin Özelliklerini Al**

Aspose.Slides kullanarak bir metin stilinin etkin özelliklerini alabilirsiniz. [ITextStyleEffectiveData](https://reference.aspose.com/slides/tr/net/aspose.slides/itextstyleeffectivedata/) arabirimi, etkin metin stil özelliklerini içerir.

Aşağıdaki kod örneği, etkin metin stil özelliklerinin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin bir metin çerçevesi içeren bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) olduğunu varsayar.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var effectiveTextStyle = shape.TextFrame.TextFrameFormat.TextStyle.GetEffective();
var levelCount = 9;

for (var levelIndex = 0; levelIndex < levelCount; levelIndex++)
{
    var effectiveStyleLevel = effectiveTextStyle.GetLevel(levelIndex);
    Console.WriteLine("= Effective paragraph formatting for style level #" + levelIndex + " =");

    Console.WriteLine("Depth: " + effectiveStyleLevel.Depth);
    Console.WriteLine("Indent: " + effectiveStyleLevel.Indent);
    Console.WriteLine("Alignment: " + effectiveStyleLevel.Alignment);
    Console.WriteLine("Font alignment: " + effectiveStyleLevel.FontAlignment);
}
```

## **Etkin Yazı Tipi Yüksekliği Değerini Al**

Aspose.Slides kullanarak etkin yazı tipi yüksekliğini alabilirsiniz. Aşağıdaki kod, bir bölümün etkin yazı tipi yüksekliğinin, yerel yazı tipi yüksekliği değerleri farklı sunum yapısı seviyelerinde ayarlandıktan sonra nasıl değiştiğini gösterir.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
autoShape.AddTextFrame("");

var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var firstPortion = new Portion("Sample text with first portion");
var secondPortion = new Portion(" and second portion.");

paragraph.Portions.Add(firstPortion);
paragraph.Portions.Add(secondPortion);

var firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
var secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height just after creation:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 24;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting the presentation default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 40;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting paragraph default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

firstPortion.PortionFormat.FontHeight = 55;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #0 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

secondPortion.PortionFormat.FontHeight = 18;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #1 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.Save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
```

## **Tablo İçin Etkin Doldurma Biçimini Al**

Aspose.Slides kullanarak farklı tablo bölümleri için etkin doldurma biçimini alabilirsiniz. [IFillFormatEffectiveData](https://reference.aspose.com/slides/tr/net/aspose.slides/ifillformateffectivedata/) arabirimi, etkin doldurma biçimlendirme özelliklerini içerir. Hücre biçimlendirmesi, satır biçimlendirmesinden, satır biçimlendirmesi sütun biçimlendirmesinden ve sütun biçimlendirmesi bütün tablo biçimlendirmesinden daha yüksek önceliğe sahiptir.

Sonuç olarak, tablo hücresini çizerken [ICellFormatEffectiveData](https://reference.aspose.com/slides/tr/net/aspose.slides/icellformateffectivedata/) özellikleri kullanılır. Aşağıdaki kod örneği, farklı tablo bölümleri için etkin doldurma biçiminin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin bir [ITable](https://reference.aspose.com/slides/tr/net/aspose.slides/itable/) olduğunu varsayar.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var table = (ITable)presentation.Slides[0].Shapes[0];

var tableFormatEffective = table.TableFormat.GetEffective();
var rowFormatEffective = table.Rows[0].RowFormat.GetEffective();
var columnFormatEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellFormatEffective = table[0, 0].CellFormat.GetEffective();

var tableFillFormatEffective = tableFormatEffective.FillFormat;
var rowFillFormatEffective = rowFormatEffective.FillFormat;
var columnFillFormatEffective = columnFormatEffective.FillFormat;
var cellFillFormatEffective = cellFormatEffective.FillFormat;
```

## **SSS**

### `GetEffective` bir anlık görüntü döndürür mü?

Her zaman değil. Etkin veri, kalıtım uygulandıktan sonra hesaplanan biçimlendirmeyi temsil eder, ancak bazı etkin veri nesneleri dahili olarak önbelleğe alınabilir. Sonraki bir `GetEffective` çağrısı biçimlendirmeyi yeniden hesaplayabilir ve önbellek verilerini yenileyebilir, bu nedenle daha önce elde edilen nesne kalıcı bir anlık görüntü olarak ele alınmamalıdır.

### Etkin özellikleri ne zaman tekrar okumalıyım?

Yerel biçimlendirme, üst stiller, yerleşim biçimlendirmesi, ana biçimlendirme veya sunum düzeyindeki varsayılanlar değiştirildikten sonra `GetEffective` metodunu tekrar çağırın. Sonraki çağrı, biçimlendirme hiyerarşisini yeniden değerlendirir ve mevcut etkin sonucu döndürür.

### Bir yerleşim/ana slaytı değiştirmek veya kaldırmak, zaten alınmış etkin özellikleri etkiler mi?

Evet, ancak değişiklik bir sonraki `GetEffective` çağrısında yansıtılır. Bir üst biçimlendirme kaynağı değiştirildiğinde veya kaldırıldığında, daha önce elde edilen etkin veri eski olabilir. `GetEffective` tekrar çağrıldığında, Aspose.Slides biçimlendirme ağacını yeniden değerlendirir ve ortaya çıkan yazı tipleri, renkler, boyutlar veya diğer değerler değişebilir.

### Etkin veri nesneleri üzerinden değerleri değiştirebilir miyim?

Hayır. Etkin veri nesneleri hesaplanmış değerleri gösterir. Değişiklikleri yerel biçimlendirme nesnelerinde yapın ve ardından etkin değerleri tekrar alın.

### Bir özellik şekil düzeyinde, yerleşimde/ana slaytta ya da global ayarlarda ayarlanmamışsa ne olur?

Etkin değer, PowerPoint ve Aspose.Slides varsayılanlarını içeren varsayılan mekanizma tarafından belirlenir. Bu çözülen değer, mevcut etkin verinin bir parçası haline gelir.

### Etkin bir yazı tipi değerinden, boyutu ya da yazı tipini hangi seviyenin sağladığını anlayabilir miyim?

Doğrudan değil. Etkin veri son değeri döndürür. Kaynağı bulmak için, bölüm, paragraf, metin çerçevesi ve yerleşim, ana ve sunum düzeylerindeki metin stillerindeki yerel değerleri kontrol edin; böylece ilk açık tanımın hangi seviyede olduğunu görebilirsiniz.

### Neden bazı durumlarda etkin değerler yerel değerlerle aynı görünüyor?

Çünkü yerel değer son değer haline gelmiştir (daha yüksek seviyeden bir kalıtım gerekmez). Bu gibi durumlarda etkin değer, yerel değerle aynı olur.

### Etkin özellikleri ne zaman kullanmalı, ne zaman sadece yerel olanlarla çalışmalıyım?

Tüm kalıtım uygulandıktan sonra "görünüm" sonucuna ihtiyaç duyduğunuzda, renkleri, girintileri veya boyutları hizalamak gibi durumlarda etkin veriyi kullanın. Bu değerleri daha sonraki biçimlendirme değişikliklerinden bağımsız olarak korumanız gerekiyorsa, gerekli özellikleri kendi nesnenize kopyalayın. Belirli bir seviyede biçimlendirme değiştirmek istiyorsanız, yerel özellikleri değiştirin ve gerekirse sonucu doğrulamak için etkin veriyi tekrar okuyun.