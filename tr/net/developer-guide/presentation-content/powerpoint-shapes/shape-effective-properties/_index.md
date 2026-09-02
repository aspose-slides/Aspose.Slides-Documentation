---
title: Şekil Etkin Özelliklerini .NET'te Sunumlardan Alın
linktitle: Etkin Özellikler
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
description: "Aspose.Slides for .NET'i kullanarak PowerPoint sunumlarında yerel, kalıtılmış ve etkin şekil biçimlendirmesini nasıl ayıracağınızı öğrenin."
---
## **Yerel, Kalıtılmış ve Etkin Özellikleri Anlayın**

PowerPoint biçimlendirmesi birkaç yerden gelebilir. Bir nesne üzerinde doğrudan depolanan değer **yerel değerdir**. Bu değer ayarlanmamışsa, PowerPoint bir paragraf varsayılanı, bir metin stili, bir yerleşim ya da ana slayt, bir tema veya sunum düzeyinde varsayılanlar gibi üst biçimlendirme kaynaklarına bakar. Bu değerler **kalıtılmış değerler** olarak adlandırılır. Tüm hiyerarşi çözüldükten sonra kalan değer **etkin değerdir** — nesneyi renderlamak için kullanılan değer.

Örneğin, bir metin bölümü kendi yazı tipi yüksekliğini tanımlamıyor olabilir. Yerel [FontHeight](https://reference.aspose.com/slides/tr/net/aspose.slides/ibaseportionformat/fontheight/) değeri `float.NaN` olur, bu "burada ayarlanmamış" anlamına gelir. Bölüm, paragrafından, sunumun varsayılan metin stilinden veya başka bir geçerli kaynaktan bir yükseklik kalıtabilir. Bölüm formatı üzerinde [GetEffective](https://reference.aspose.com/slides/tr/net/aspose.slides/iportionformat/geteffective/) çağrısı, son çözülen yüksekliği döndürür.

Farklı amaçlar için iki türlü biçimlendirme verisini kullanın:

- Bir değerin nerede tanımlandığını kontrol etmeniz gerektiğinde, [IPortionFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/iportionformat/) gibi bir yerel format nesnesini okuyun veya değiştirin.
- Son, renderlanmış sonucu gerektiğinde, [IPortionFormatEffectiveData](https://reference.aspose.com/slides/tr/net/aspose.slides/iportionformateffectivedata/) gibi bir etkin veri nesnesini okuyun. Etkin veri yalnızca okunur.

## **Yerel, Kalıtılmış ve Etkin Değerleri Karşılaştırın**

Aşağıdaki tam örnek bir şekil oluşturur ve yazı tipi yüksekliğini sunum, paragraf ve bölüm düzeylerinde uygular. Her adım, bu seviyelerde tanımlanan değerleri ve aynı metin bölümü için ortaya çıkan etkin değeri yazdırır. Ayrıca, biçimlendirme değişikliklerinden sonra etkin verinin neden yeniden okunması gerektiğini gösterir.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, false);
var textFrame = shape.AddTextFrame("Effective formatting");
var paragraph = textFrame.Paragraphs[0];
var portion = paragraph.Portions[0];

// Define inherited values at two different levels.
presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 20;
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 28;

PrintFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

// A local value on the portion overrides both inherited values.
portion.PortionFormat.FontHeight = 36;
PrintFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

// Changing an inherited value does not override an existing local value.
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 30;
PrintFontHeights("The local value still has priority", presentation, paragraph, portion);

// Clear the local value. The portion now inherits from the paragraph again.
portion.PortionFormat.FontHeight = float.NaN;
PrintFontHeights("The local value is cleared", presentation, paragraph, portion);

// Clear the paragraph value. The presentation default now supplies the result.
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = float.NaN;
PrintFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

presentation.Save("effective-properties.pptx", SaveFormat.Pptx);

static void PrintFontHeights(string caption, Presentation presentation, IParagraph paragraph, IPortion portion)
{
    var presentationValue = presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight;
    var paragraphValue = paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight;
    var localValue = portion.PortionFormat.FontHeight;

    // Read effective data after the preceding changes.
    var effectiveValue = portion.PortionFormat.GetEffective().FontHeight;

    Console.WriteLine(caption);
    Console.WriteLine($"  Presentation default: {FormatLocalValue(presentationValue)}");
    Console.WriteLine($"  Paragraph default:    {FormatLocalValue(paragraphValue)}");
    Console.WriteLine($"  Portion local:        {FormatLocalValue(localValue)}");
    Console.WriteLine($"  Portion effective:    {effectiveValue}");
}

static string FormatLocalValue(float value) => float.IsNaN(value) ? "<not set>" : value.ToString();
```

Bu örnekte öncelik, önce bölüm yerel biçimlendirmesi, ardından paragraf biçimlendirmesi ve son olarak sunum varsayılanıdır. Diğer nesnelerin farklı kalıtım zincirleri olabilir, ancak ilke aynı kalır: daha spesifik açık bir değer kazanır ve [GetEffective](https://reference.aspose.com/slides/tr/net/aspose.slides/iportionformat/geteffective/) son sonucu döndürür.

## **Etkin Metin Özelliklerini Alın**

Metin biçimlendirmesi birkaç nesne arasında bölünmüştür:

- [ITextFrameFormat.GetEffective()](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframeformat/geteffective/) kenar boşlukları, yerleştirme, otomatik sığdırma ve dikey metin yönü gibi metin çerçevesi özelliklerini çözer.
- [ITextStyle.GetEffective()](https://reference.aspose.com/slides/tr/net/aspose.slides/itextstyle/geteffective/) her metin stili seviyesinin paragraf biçimlendirmesini çözer.
- [IParagraphFormat.GetEffective()](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/geteffective/) hizalama, girinti ve madde işaretleri gibi paragraf özelliklerini çözer.
- [IPortionFormat.GetEffective()](https://reference.aspose.com/slides/tr/net/aspose.slides/iportionformat/geteffective/) yazı tipi yüksekliği, tipografi, renk, kalın ve italik gibi karakter özelliklerini çözer.

Sonraki örnek için `text-formatting.pptx` en az bir slayt ve boş olmayan bir metin çerçevesine sahip bir [AutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/autoshape/) içermelidir. AutoShape, şekil koleksiyonunda herhangi bir konumda bulunabilir; kod uygun bir nesneyi arar ve kullanmadan önce doğrular.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("text-formatting.pptx");

if (presentation.Slides.Count == 0)
    throw new InvalidOperationException("The presentation contains no slides.");

var autoShapes = presentation.Slides[0].Shapes.OfType<IAutoShape>();
var shape = autoShapes.FirstOrDefault(candidate => HasNonEmptyText(candidate));

if (shape == null)
{
    throw new InvalidOperationException("The first slide must contain an AutoShape with non-empty text.");
}

var textFrame = shape.TextFrame;
var paragraph = textFrame.Paragraphs[0];
var portion = paragraph.Portions[0];

var textFrameEffective = textFrame.TextFrameFormat.GetEffective();
var paragraphEffective = paragraph.ParagraphFormat.GetEffective();
var portionEffective = portion.PortionFormat.GetEffective();

Console.WriteLine("Text frame margins:");
Console.WriteLine($"  Left: {textFrameEffective.MarginLeft}");
Console.WriteLine($"  Top: {textFrameEffective.MarginTop}");
Console.WriteLine($"  Right: {textFrameEffective.MarginRight}");
Console.WriteLine($"  Bottom: {textFrameEffective.MarginBottom}");
Console.WriteLine($"Paragraph alignment: {paragraphEffective.Alignment}");
Console.WriteLine($"Font height: {portionEffective.FontHeight}");
Console.WriteLine($"Bold: {portionEffective.FontBold}");

var effectiveTextStyle = textFrame.TextFrameFormat.TextStyle.GetEffective();
for (var level = 0; level < 9; level++)
{
    var levelEffective = effectiveTextStyle.GetLevel(level);
    Console.WriteLine($"Level {level} indent: {levelEffective.Indent}");
}

static bool HasNonEmptyText(IAutoShape shape)
{
    if (shape.TextFrame == null)
        return false;

    if (shape.TextFrame.Paragraphs.Count == 0)
        return false;

    return shape.TextFrame.Paragraphs[0].Portions.Count > 0;
}
```

## **Etkin 3B Özelliklerini Alın**

[IThreeDFormat.GetEffective()](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformat/geteffective/) tüm çözülen 3B ayarları gruplayan bir [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformateffectivedata/) nesnesi döndürür. Bu nesnenin [Camera](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformateffectivedata/camera/), [LightRig](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformateffectivedata/lightrig/), [BevelTop](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformateffectivedata/beveltop/) ve [BevelBottom](https://reference.aspose.com/slides/tr/net/aspose.slides/ithreedformateffectivedata/bevelbottom/) özellikleri ilgili etkin verileri ortaya çıkarır. Bu ilgili ayarları birlikte okumak, bir şeklin son 3B görünümünü anlamayı kolaylaştırır.

Bu örnek için `shape-3d.pptx` ilk slaytında en az bir şekil içermelidir. Çıkışın varsayılanların dışındaki değerleri içermesini istiyorsanız, o şekle 3B kamera, aydınlatma veya köşe ayarları uygulayın.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("shape-3d.pptx");

if (presentation.Slides.Count == 0 || presentation.Slides[0].Shapes.Count == 0)
{
    throw new InvalidOperationException("The first slide must contain a shape.");
}

var shape = presentation.Slides[0].Shapes[0];
var threeDEffective = shape.ThreeDFormat.GetEffective();

Console.WriteLine("Camera:");
Console.WriteLine($"  Type: {threeDEffective.Camera.CameraType}");
Console.WriteLine($"  Field of view: {threeDEffective.Camera.FieldOfViewAngle}");
Console.WriteLine($"  Zoom: {threeDEffective.Camera.Zoom}");

Console.WriteLine("Light rig:");
Console.WriteLine($"  Type: {threeDEffective.LightRig.LightType}");
Console.WriteLine($"  Direction: {threeDEffective.LightRig.Direction}");

Console.WriteLine("Top bevel:");
Console.WriteLine($"  Type: {threeDEffective.BevelTop.BevelType}");
Console.WriteLine($"  Width: {threeDEffective.BevelTop.Width}");
Console.WriteLine($"  Height: {threeDEffective.BevelTop.Height}");
```

## **Etkin Tablo Biçimlendirmesini Alın**

Tablo biçimlendirmesi tablo stilinden ve tüm tabloya, bir sütuna, bir satıra veya tek bir hücreye uygulanan biçimlerden gelebilir. Açıkça tanımlanan doldurmalar arasındaki çakışmalarda öncelik hücre, satır, sütun ve ardından tüm tablo şeklindedir. Bir hücrenin etkin biçimi, o hücreyi çizmeye kullanılan son biçimdir.

Bu örnek için `table-formatting.pptx` ilk slaytında en az bir tablo içermelidir. Tablo en az bir satır ve bir sütun içermelidir. Kod, `Shapes[0]`'ın bir tablo olduğunu varsaymak yerine bir [ITable](https://reference.aspose.com/slides/tr/net/aspose.slides/itable/) arar.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("table-formatting.pptx");

if (presentation.Slides.Count == 0)
    throw new InvalidOperationException("The presentation contains no slides.");

var table = presentation.Slides[0].Shapes.OfType<ITable>().FirstOrDefault();

if (table == null)
    throw new InvalidOperationException("The first slide must contain a table.");

if (table.Rows.Count == 0 || table.Columns.Count == 0)
    throw new InvalidOperationException("The table must contain at least one cell.");

var tableEffective = table.TableFormat.GetEffective();
var rowEffective = table.Rows[0].RowFormat.GetEffective();
var columnEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellEffective = table[0, 0].CellFormat.GetEffective();

Console.WriteLine($"Table fill: {tableEffective.FillFormat.FillType}");
Console.WriteLine($"Row fill: {rowEffective.FillFormat.FillType}");
Console.WriteLine($"Column fill: {columnEffective.FillFormat.FillType}");
Console.WriteLine($"Final cell fill: {cellEffective.FillFormat.FillType}");
```

Dolgu türünün sadece değil, rengini de ihtiyacınız varsa, önce etkin [FillType](https://reference.aspose.com/slides/tr/net/aspose.slides/ifillformateffectivedata/filltype/) kontrol edin ve ardından o tipe uygulanan özelliği okuyun — örneğin, katı dolgu için [SolidFillColor](https://reference.aspose.com/slides/tr/net/aspose.slides/ifillformateffectivedata/solidfillcolor/).

## **Değişikliklerden Sonra Etkin Veriyi Yeniden Okuyun**

Etkin veri, çözüldüğü zamandaki biçimlendirme hiyerarşisini tanımlar. Bu hiyerarşiye katılabilecek herhangi bir şeyi değiştirdikten sonra `GetEffective` metodunu tekrar çağırın; şunlar dahil:

- nesnenin yerel biçimlendirmesi;
- paragraf ya da metin çerçevesi varsayılanları;
- bir tablo stili, tablo, sütun, satır veya hücre biçimi;
- yerleşim ya da ana slayt biçimlendirmesi;
- tema verileri ya da sunum düzeyinde varsayılanlar;
- bir slayta atanmış yerleşim ya da ana.

Etkin veri nesnesini kalıcı bir anlık görüntü olarak tutmayın. Aspose.Slides bazı etkin verileri dahili olarak önbelleğe alabilir ve daha sonraki bir `GetEffective` çağrısı bu verileri yenileyebilir. Bir değişiklik öncesi ve sonrası değerleri karşılaştırmanız gerekiyorsa, değişikliği yapmadan önce ihtiyacınız olan skaler değerleri — örneğin yazı tipi yüksekliği, renk, hizalama veya köşe genişliği — kendi değişkenlerinize kopyalayın.

Bir değeri değiştirmek için uygun yerel format nesnesini güncelleyin ve ardından sonucu doğrulamak için `GetEffective` çağırın. Etkin veri nesneleri kendileri yalnızca okuma amaçlıdır.

## **SSS**

**Etkin bir değeri hangi seviye sağladığini nasıl anlayabilirim?**

Etkin veri, kaynağını değil nihai değeri içerir. Uygulanabilir yerel nesneleri en spesifik seviyeden dışa doğru inceleyin. Metin için bu, bölüm, paragraf, metin çerçevesi, yerleşim, ana, tema ve sunum varsayılanlarını içerebilir. `float.NaN` veya `null` gibi tanımsız değerler, aramanın başka bir seviyeye devam ettiğini gösterir.

**Hiçbir seviye bir özelliği tanımlamazsa ne olur?**

Aspose.Slides uygun PowerPoint veya kütüphane varsayılanını çözer. Bu çözülen değer, hiçbir yerel nesne açıkça tanımlamasa da etkin veride görünür.

**Neden bir etkin değer bazen yerel değerle aynı olur?**

Yerel değer, kalıtım hesaplamasını kazandı. Bu, özelliğin nesne üzerinde açıkça ayarlandığı ve daha spesifik bir kuralın onu geçersiz kılmadığı durumlarda beklenen bir durumdur.

**Ne zaman yerel veriyi, etkin veri yerine kullanmalıyım?**

Belirli bir biçimlendirme seviyesini incelemek veya düzenlemek için yerel veriyi kullanın. Kalıtım, tema kuralları ve uygulanabilir stiller çözüldükten sonra son görünümü ihtiyaç duyduğunuzda etkin veriyi kullanın. [tam karşılaştırma örneği](#compare-local-inherited-and-effective-values) aynı iş akışında her ikisini de gösterir.