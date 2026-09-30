---
title: PowerPoint Sunum Tablolarını .NET'te Yönet
linktitle: Tabloyu Yönet
type: docs
weight: 10
url: /tr/net/manage-table/
keywords:
- tablo ekle
- tablo oluştur
- tabloya eriş
- en boy oranı
- metni hizala
- metin biçimlendirme
- tablo stili
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PowerPoint slaytlarında tablolar oluşturun ve düzenleyin. Tablo iş akışlarınızı basitleştirecek sade C# kod örneklerini keşfedin."
---
## **Giriş**

PowerPoint'teki tablolar, bilgiyi satır ve sütunlar halinde düzenler, böylece değerleri okumak ve karşılaştırmak daha kolay olur.

Aspose.Slides, sunumlarda tablo oluşturmanıza, güncellemenize ve yönetmenize olanak tanıyan [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) sınıfını, [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) arayüzünü, [Cell](https://reference.aspose.com/slides/net/aspose.slides/cell/) sınıfını, [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) arayüzünü ve diğer türleri sağlar.

## **Baştan Bir Tablo Oluşturma**

Bir tabloyu konumunu, sütun genişliklerini ve satır yüksekliklerini belirterek oluşturun. Slayta ekledikten sonra hücre kenarlıklarını biçimlendirebilir, hücreleri birleştirebilir ve metin ekleyebilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Diziniyle slayta bir referans alın.  
3. Punto cinsinden sütun genişlikleri dizisi tanımlayın.  
4. Punto cinsinden satır yükseklikleri dizisi tanımlayın.  
5. [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) yöntemiyle slayta bir [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) nesnesi ekleyin.  
6. Her bir [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) üzerinde dolaşarak üst, alt, sağ ve sol kenarlara biçimlendirme uygulayın.  
7. Tablonun ilk satırındaki ilk iki hücreyi birleştirin.  
8. Birleştirilmiş hücreye, [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) özelliğiyle erişin.  
9. Birleştirilmiş hücreye metni ayarlayın.  
10. Değiştirilen sunumu kaydedin.

Aşağıdaki örnek, (100, 50) punto konumunda üç sütun ve beş satırdan oluşan bir tablo oluşturur. 5 punto genişliğinde kırmızı kenarlıklar uygular, ilk satırdaki ilk iki hücreyi birleştirir ve sonucu `table.pptx` olarak kaydeder.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 50, 50, 50 };
var rowHeights = new double[] { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
{
    foreach (var cell in row)
    {
        var cellFormat = cell.CellFormat;
        cellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderTop.Width = 5;

        cellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderBottom.Width = 5;

        cellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderLeft.Width = 5;

        cellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderRight.Width = 5;
    }
}

table.MergeCells(table[0, 0], table[1, 0], false);
table[0, 0].TextFrame.Text = "Merged Cells";

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **Standart Bir Tablo İçinde Numaralandırma**

Standart bir tabloda hücre indeksleri sıfırdan başlar ve (sütun, satır) sırasını kullanır. İlk hücre (0, 0) olarak indekslenir.

Örneğin, 4 sütun ve 4 satır içeren bir tablodaki hücreler şu şekilde numaralandırılır:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Bu örnek, yukarıda gösterilen 4 × 4 tabloyu, sütun genişlikleri ve satır yükseklikleri 70 punto ve 5 punto genişliğinde kırmızı hücre kenarlıklarıyla oluşturur. Koordinatlar hücre indekslerini gösterir; örnek hücreleri boş bırakır ve tabloyu `StandardTables_out.pptx` olarak kaydeder.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 70, 70, 70, 70 };
var rowHeights = new double[] { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
{
    foreach (var cell in row)
    {
        var cellFormat = cell.CellFormat;
        cellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderTop.Width = 5;

        cellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderBottom.Width = 5;

        cellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderLeft.Width = 5;

        cellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderRight.Width = 5;
    }
}

presentation.Save("StandardTables_out.pptx", SaveFormat.Pptx);
```

## **Var Olan Bir Tabloya Erişme**

Tablolar, bir slaydın şekil koleksiyonunda depolanır. Şekiller arasında dolaşarak bir tablo bulun, ardından [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) arayüzünü kullanarak hücrelerini okuyabilir veya güncelleyebilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) sınıfını kullanarak sunumu yükleyin.  
2. İndisiyle tabloyu içeren slayta bir referans alın.  
3. [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) nesneleri arasında dolaşın ve bir tablo bulunduğunda durun. Slayt birden çok tablo içeriyorsa, ihtiyacınız olanı belirlemek için [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/ishape/alternativetext/) kullanın.  
4. Hedef hücredeki metni güncelleyin.  
5. Değiştirilen sunumu kaydedin.

Aşağıdaki örnek `UpdateExistingTable.pptx` dosyasını açar ve ilk slayttaki ilk tabloyu bulur. Hücreyi sütun 0, satır 1 konumunda `New` olarak ayarlar ve sonucu `table1_out.pptx` olarak kaydeder. Girişte en az bir slayt bulunmalı ve o slayttaki ilk tablo en az bir sütun ve iki satır içermelidir.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("UpdateExistingTable.pptx");
var slide = presentation.Slides[0];
ITable? table = null;

foreach (var shape in slide.Shapes)
{
    if (shape is ITable candidateTable)
    {
        table = candidateTable;
        break;
    }
}

table![0, 1].TextFrame.Text = "New";

presentation.Save("table1_out.pptx", SaveFormat.Pptx);
```

Var olan bir tabloda bir satırı yeniden boyutlandırmak ve gerçek yüksekliğinin istenen minimumu aşmasının nedenini anlamak için [Control Row Height](/slides/tr/net/manage-rows-and-columns/#control-row-height) bölümüne bakın.

## **Bir Metin Çerçevesine Sahip Hücreyi Bulma**

Genel bir metin işleme kodu bir tablodan [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) aldığında, sahibi olan [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) nesnesini elde etmek için [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) özelliğini kullanın. Bir tablo hücresi metin çerçevesi için [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) ayarlanmıştır ve [ITextFrame.ParentShape](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentshape/) `null` değerindedir, tablo kendisi bir şekil olsa bile.

Hücre koordinatları, yalnızca okunabilir [ICell.FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) ve [ICell.FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) özellikleri aracılığıyla elde edilebilir. [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) de yalnızca okunabilir: sahibine yönlendirme sağlar ancak sahipliği değiştirmez. Kullanımdan önce her zaman döndürülen hücrenin `null` olup olmadığını kontrol edin.

Tablo hücresi ve şekil sahiplerini, SmartArt düğümleriyle ilişkili şekilleri de içeren tam bir örnek için [Search and Replace Text](/slides/tr/net/search-and-replace-text/) bölümüne bakın.

## **Bir Tablo İçinde Metni Hizalama**

Bireysel tablo hücrelerinin dikey sabitlemesini ve metin yönünü kontrol edebilirsiniz. Bu bölümdeki örnek, ilk hücredeki metni ortalar ve 270 derece döndürür.

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. İndisiyle slayta bir referans alın.  
3. Slayta bir [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) nesnesi ekleyin.  
4. Tablodan bir [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) nesnesine erişin.  
5. İlk [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) nesnesine erişin ve onun metnini ve rengini ayarlayın.  
6. Hücrenin [TextAnchorType](https://reference.aspose.com/slides/net/aspose.slides/icell/textanchortype/) ve [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/icell/textverticaltype/) özelliklerini ayarlayın.  
7. Değiştirilen sunumu kaydedin.

Bu örnek, sütun genişlikleri 120 punto ve satır yükseklikleri 100 punto olan 4 × 4 bir tablo oluşturur. (0, 0) hücresindeki metni biçimlendirir, ilk satırdaki kalan hücrelere değerler ekler ve sonucu `Vertical_Align_Text_out.pptx` olarak kaydeder.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 120, 120, 120, 120 };
var rowHeights = new double[] { 100, 100, 100, 100 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);
table[1, 0].TextFrame.Text = "10";
table[2, 0].TextFrame.Text = "20";
table[3, 0].TextFrame.Text = "30";

var cell = table[0, 0];
var paragraph = cell.TextFrame.Paragraphs[0];
var portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **Tablo Düzeyinde Metin Biçimlendirmesini Ayarlama**

[SetTextFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulktextformattable/settextformat/) kullanarak bir tablodaki tüm hücrelere metin biçimlendirmesi uygulayabilirsiniz. Aşırı yüklemeleri, bölüm, paragraf ve metin çerçevesi biçimlendirmesini kabul eder, böylece tek tek hücrelerde dolaşmadan bu özellikleri ayarlayabilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) sınıfını kullanarak sunumu yükleyin.  
2. İndisiyle slayta bir referans alın.  
3. Slayttan bir [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) nesnesine erişin.  
4. Metin için [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) ayarlayın.  
5. [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) ve [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) ayarlarını yapın.  
6. [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) ayarlayın.  
7. Değiştirilen sunumu kaydedin.

Aşağıdaki örnek, ilk şekli tablo olan en az bir slayt içeren `table.pptx` dosyasını açar. Yazı tipini 25 punto olarak ayarlar, paragrafları 20 punto sağ kenar boşluğu ile sağa hizalar ve metni dikey yapar. Biçimlendirilmiş sunum `result.pptx` olarak kaydedilir.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
table.SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
table.SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
table.SetTextFormat(textFrameFormat);

presentation.Save("result.pptx", SaveFormat.Pptx);
```

## **Tablo Stil Özelliklerini Almak**

[StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/) kullanarak bir tablonun önceden tanımlı stilini okuyabilir veya atayabilirsiniz. Bu örnek, bir tabloya [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/) uygular, önceden tanımlı adını yazdırır ve aynı stili ikinci tabloya atar. Her iki tablo da `table-style.pptx` içinde kaydedilir.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 150 };
var rowHeights = new double[] { 5, 5, 5 };
var table = slide.Shapes.AddTable(10, 10, columnWidths, rowHeights);
table.StylePreset = TableStylePreset.DarkStyle1;

var stylePreset = table.StylePreset;
Console.WriteLine($"Table style preset: {stylePreset}");

var anotherTable = slide.Shapes.AddTable(10, 100, columnWidths, rowHeights);
anotherTable.StylePreset = stylePreset;

presentation.Save("table-style.pptx", SaveFormat.Pptx);
```

## **Bir Tablonun En Boy Oranını Kilitleme**

Bir tablonun en boy oranı, genişliğinin yüksekliğine oranıdır. Bu oranı tablo için kilitlemek üzere [AspectRatioLocked](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/aspectratiolocked/) kullanın.

Aşağıdaki örnek, ilk şekli tablo olan en az bir slayt içeren `pres.pptx` dosyasını açar. Mevcut kilit durumunu yazdırır, en boy oranı kilidini etkinleştirir, güncellenen durumu (`True`) yazar ve sonucu `pres-out.pptx` olarak kaydeder.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

table.ShapeLock.AspectRatioLocked = true;
Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

presentation.Save("pres-out.pptx", SaveFormat.Pptx);
```

## **SSS**

**Bir tablo ve hücrelerindeki metin için sağdan sola (RTL) okuma yönünü etkinleştirebilir miyim?**  
Evet. Tablo, bir [RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/table/righttoleft/) özelliği sunar ve paragraflar [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/righttoleft/) özelliğine sahiptir. İkisini birlikte kullanmak, hücre içindeki doğru RTL sırasını ve renderlamayı sağlar.

**Kullanıcıların son dosyada bir tabloyu taşımasını veya yeniden boyutlandırmasını nasıl engelleyebilirim?**  
[shape locks](/slides/tr/net/applying-protection-to-presentation/) kullanarak taşıma, yeniden boyutlandırma, seçim vb. işlemleri devre dışı bırakabilirsiniz. Bu kilitler tablolara da uygulanır.

**Bir hücrenin içinde görüntüyü arka plan olarak eklemek destekleniyor mu?**  
Evet. Hücre için bir [picture fill](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) ayarlayabilirsiniz; seçilen moda (germe veya döşeme) göre görüntü hücre alanını kaplar.