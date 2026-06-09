---
title: .NET'te Sunumlardan Şekil Etkili Özelliklerini Al
linktitle: Etkili Özellikler
type: docs
weight: 50
url: /tr/net/shape-effective-properties/
keywords:
- şekil özellikleri
- kamera özellikleri
- ışık düzeni
- köşe şekli
- metin çerçevesi
- metin stili
- yazı tipi yüksekliği
- dolgu biçimi
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET'in hassas PowerPoint render'ı için etkili şekil özelliklerini nasıl hesapladığını ve uyguladığını keşfedin."
---
## **Genel Bakış**

Bu konu, **yerel** ve **etkili** özellikler arasındaki farkı açıklar. Yerel değerler, belirli bir biçimlendirme düzeyinde doğrudan ayarlanan değerlerdir, örneğin:

1. Bir slayttaki bölüm özellikleri.  
1. Bir düzen veya ana slaytta prototip şekil metin stilleri, bölümün metin çerçevesi şekli bir tane içeriyorsa.  
1. Bir sunumdaki küresel metin ayarları.  

Yerel değerler herhangi bir düzeyde tanımlanabilir veya atlanabilir. Aspose.Slides, nihai “görünmüş” biçimlendirmeye ihtiyaç duyduğunda, kalıtım zincirini çözer ve **etkili** değerleri döndürür. Bu değerlere, yerel format nesnesi üzerindeki `GetEffective` yöntemini çağırarak ulaşabilirsiniz.

Aşağıdaki örnek, etkili değerlerin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) olduğunu ve bir metin çerçevesi ile en az bir bölüm içerdiğini varsayar.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var localTextFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = localTextFrameFormat.GetEffective();

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
var localPortionFormat = portion.PortionFormat;
var effectivePortionFormat = localPortionFormat.GetEffective();
```

{{% alert color="primary" %}}
Etkili biçimlendirme verileri, kalıtım uygulandıktan sonra hesaplanan mevcut biçimlendirmeyi temsil eder. Mevcut uygulamada, [IPortionFormatEffectiveData](https://reference.aspose.com/slides/tr/net/aspose.slides/iportionformateffectivedata/) gibi bazı etkili veri nesneleri dahili olarak önbelleğe alınabilir. Üst veya kalıtılan biçimlendirme değiştirildikten sonra `GetEffective` metodunu tekrar çağırmak önbellekteki verileri yenileyebilir ve daha önce elde edilen nesne artık önceki durumu temsil etmeyebilir. Daha sonraki kullanım için etkili değerleri korumanız gerekiyorsa, yazı tipi yüksekliği, dolgu rengi, yazı tipi stili veya hizalama gibi gerekli özellikleri kendi veri nesnenize kopyalayın.
{{% /alert %}}

## **Bir Kamera için Etkili Özellikleri Al**

Aspose.Slides, bir kameranın etkili özelliklerini almanıza olanak tanır. [ICameraEffectiveData](https://reference.aspose.com/slides/tr/net/aspose.slides/icameraeffectivedata/) arayüzü, etkili kamera özelliklerini içeren değiştirilemez bir nesneyi temsil eder. Bir [ICameraEffectiveData](https://reference.aspose.com/slides/tr/net/aspose.slides/icameraeffectivedata/) örneği, [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformateffectivedata/) aracılığıyla sunulur ve [IThreeDFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/) için etkili değerler sağlar.

Aşağıdaki kod örneği, kamera için etkili özelliklerin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin 3D biçimlendirmeye sahip olduğunu varsayar.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective camera properties =");
Console.WriteLine("Type: " + threeDEffectiveData.Camera.CameraType);
Console.WriteLine("Field of view: " + threeDEffectiveData.Camera.FieldOfViewAngle);
Console.WriteLine("Zoom: " + threeDEffectiveData.Camera.Zoom);
```

## **Bir Işık Düzeni için Etkili Özellikleri Al**

Aspose.Slides, bir ışık düzeninin etkili özelliklerini almanıza olanak tanır. [ILightRigEffectiveData](https://reference.aspose.com/slides/tr/net/aspose.slides/ilightrigeffectivedata/) arayüzü, etkili ışık düzeni özelliklerini içeren değiştirilemez bir nesneyi temsil eder. Bir [ILightRigEffectiveData](https://reference.aspose.com/slides/tr/net/aspose.slides/ilightrigeffectivedata/) örneği, [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformateffectivedata/) aracılığıyla sunulur ve [IThreeDFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/) için etkili değerler sağlar.

Aşağıdaki kod örneği, ışık düzeni için etkili özelliklerin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin 3D biçimlendirmeye sahip olduğunu varsayar.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective light rig properties =");
Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
```

## **Bir Kesim Şekli için Etkili Özellikleri Al**

Aspose.Slides, bir şekil kesiminin etkili özelliklerini almanıza olanak tanır. [IShapeBevelEffectiveData](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapebeveleffectivedata/) arayüzü, bir şeklin etkili yüzey kabartma özelliklerini içeren değiştirilemez bir nesneyi temsil eder. Bir [IShapeBevelEffectiveData](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapebeveleffectivedata/) örneği, [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformateffectivedata/) aracılığıyla sunulur ve [IThreeDFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/) için etkili değerler sağlar.

Aşağıdaki kod örneği, bir şeklin üst kesimi için etkili özelliklerin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin 3D biçimlendirmeye sahip olduğunu varsayar.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective shape's top face relief properties =");
Console.WriteLine("Type: " + threeDEffectiveData.BevelTop.BevelType);
Console.WriteLine("Width: " + threeDEffectiveData.BevelTop.Width);
Console.WriteLine("Height: " + threeDEffectiveData.BevelTop.Height);
```

## **Bir Metin Çerçevesi için Etkili Özellikleri Al**

Aspose.Slides kullanarak bir metin çerçevesinin etkili özelliklerini alabilirsiniz. [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframeformateffectivedata/) arayüzü, etkili metin çerçevesi biçimlendirme özelliklerini içerir.

Aşağıdaki kod örneği, etkili metin çerçevesi biçimlendirme özelliklerinin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) olduğunu ve bir metin çerçevesi içerdiğini varsayar.

```csharp
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

## **Bir Metin Stili için Etkili Özellikleri Al**

Aspose.Slides kullanarak bir metin stilinin etkili özelliklerini alabilirsiniz. [ITextStyleEffectiveData](https://reference.aspose.com/slides/tr/net/aspose.slides/itextstyleeffectivedata/) arayüzü, etkili metin stili özelliklerini içerir.

Aşağıdaki kod örneği, etkili metin stili özelliklerinin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin bir [IAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/iautoshape/) olduğunu ve bir metin çerçevesi içerdiğini varsayar.

```csharp
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

## **Etkili Yazı Tipi Yüksekliği Değerini Al**

Aspose.Slides kullanarak etkili yazı tipi yüksekliğini alabilirsiniz. Aşağıdaki kod, bir bölümün etkili yazı tipi yüksekliğinin, farklı sunum yapı düzeylerinde yerel yazı tipi yüksekliği değerleri ayarlandığında nasıl değiştiğini gösterir.

```csharp
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

## **Bir Tablo için Etkili Doldurma Biçimini Al**

Aspose.Slides kullanarak farklı tablo bölümleri için etkili doldurma biçimlendirmesini alabilirsiniz. [IFillFormatEffectiveData](https://reference.aspose.com/slides/tr/net/aspose.slides/ifillformateffectivedata/) arayüzü, etkili doldurma biçimlendirme özelliklerini içerir. Hücre biçimlendirmesi, satır biçimlendirmesinden, satır biçimlendirmesi sütun biçimlendirmesinden ve sütun biçimlendirmesi bütün tablo biçimlendirmesinden daha yüksek önceliğe sahiptir.

Sonuç olarak, tablo hücresini çizerken [ICellFormatEffectiveData](https://reference.aspose.com/slides/tr/net/aspose.slides/icellformateffectivedata/) özellikleri kullanılır. Aşağıdaki kod örneği, farklı tablo bölümleri için etkili doldurma biçimlendirmesinin nasıl alınacağını gösterir. İlk slayttaki ilk şeklin bir [ITable](https://reference.aspose.com/slides/tr/net/aspose.slides/itable/) olduğunu varsayar.

```csharp
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

**`GetEffective` bir anlık görüntü döndürür mü?**

Her zaman değil. Etkili veri, kalıtım uygulandıktan sonra hesaplanan biçimlendirmeyi temsil eder, ancak bazı etkili veri nesneleri dahili olarak önbelleğe alınabilir. Ardından gelen bir `GetEffective` çağrısı biçimlendirmeyi yeniden hesaplayabilir ve önbellekteki verileri yenileyebilir, bu nedenle daha önce elde edilen nesne dayanıklı bir anlık görüntü olarak değerlendirilmemelidir.

**Etkili özellikleri ne zaman yeniden okumalıyım?**

Yerel biçimlendirme, üst stiller, düzen biçimlendirmesi, ana biçimlendirme veya sunum düzeyindeki varsayılanlar değiştirildikten sonra `GetEffective` metodunu tekrar çağırın. Sonraki çağrı, biçimlendirme hiyerarşisini yeniden değerlendirir ve mevcut etkili sonucu döndürür.

**Bir düzen/ana slaytın değiştirilmesi veya kaldırılması, zaten alınmış etkili özellikleri etkiler mi?**

Evet, ancak değişiklik bir sonraki `GetEffective` çağrısında yansır. Bir üst biçimlendirme kaynağı değiştirildiğinde veya kaldırıldığında, daha önce elde edilen etkili veri eski olabilir. `GetEffective` tekrar çağrıldığında, Aspose.Slides biçimlendirme ağacını yeniden değerlendirir ve ortaya çıkan yazı tipleri, renkler, boyutlar veya diğer değerler değişebilir.

**Etkili veri nesneleri üzerinden değerleri değiştirebilir miyim?**

Hayır. Etkili veri nesneleri hesaplanmış değerleri sunar. Değişiklikleri yerel biçimlendirme nesnelerinde yapın ve ardından etkili değerleri tekrar elde edin.

**Bir özellik şekil seviyesinde, düzen/ana slaytta ve küresel ayarlarda hiç ayarlanmamışsa ne olur?**

Etkili değer, PowerPoint ve Aspose.Slides varsayılanlarını içeren varsayılan mekanizma tarafından belirlenir. Bu çözülen değer, mevcut etkili verinin bir parçası haline gelir.

**Etkili bir yazı tipi değerinden, hangi seviyenin boyutu veya tipini sağladığını anlayabilir miyim?**

Doğrudan değil. Etkili veri nihai değeri döndürür. Kaynağı bulmak için bölüm, paragraf, metin çerçevesi ve düzen, ana ve sunum seviyelerindeki metin stillerindeki yerel değerleri kontrol edin; ilk açık tanımın hangi seviyede olduğunu görebilirsiniz.

**Neden etkili değerler bazen yerel değerlerle aynı görünüyor?**

Çünkü yerel değer nihai oldu (daha yüksek bir seviyeden kalıtım gerekmedi). Bu durumlarda etkili değer yerel değerle eşleşir.

**Etkili özellikleri ne zaman, yerel özelliklerle ne zaman kullanmalıyım?**

Tüm kalıtım uygulandıktan sonra “görünmüş” sonucu almanız gerektiğinde, örneğin renkleri, girintileri veya boyutları hizalamak istediğinizde etkili veriyi kullanın. Bu değerleri ilerideki biçimlendirme değişikliklerinden bağımsız olarak korumanız gerekiyorsa, gerekli özellikleri kendi nesnenize kopyalayın. Belirli bir seviyede biçimlendirme değiştirmeniz gerekiyorsa, yerel özellikleri değiştirin ve ardından gerekirse etkili veriyi tekrar okuyarak sonucu doğrulayın.