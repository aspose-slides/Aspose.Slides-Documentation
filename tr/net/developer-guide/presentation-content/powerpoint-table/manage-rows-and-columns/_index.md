---
title: PowerPoint Tablolarında .NET ile Satır ve Sütunları Yönetme
linktitle: Satır ve Sütunlar
type: docs
weight: 20
url: /tr/net/manage-rows-and-columns/
keywords:
- tablo satırı
- tablo sütunu
- ilk satır
- tablo başlığı
- satır klonla
- sütun klonla
- satır kopyala
- sütun kopyala
- satır kaldır
- sütun kaldır
- satır metin biçimlendirme
- sütun metin biçimlendirme
- tablo stili
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PowerPoint'te tablo satır ve sütunlarını yönetin ve sunum düzenleme ve veri güncellemelerini hızlandırın."
---
## **Giriş**

Aspose.Slides for .NET, PowerPoint sunumlarında tablo yapısını ve biçimlendirmesini [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) sınıfı ve [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) arayüzü aracılığıyla yönetmenizi sağlar. Başlık satırı belirleyebilir, satır ve sütunları kopyalayabilir veya kaldırabilir ve bir satır veya sütunun tamamına metin biçimlendirmesi uygulayabilirsiniz.

Bu makale, bu işlemleri C# örnekleriyle açıklar. Ayrıca bir tablonun stil ön ayarını nasıl alabileceğinizi ve yeniden kullanabileceğinizi gösterir. Tablo satır ve sütun indeksleri sıfır tabanlıdır.

## **Satır Yüksekliğini Kontrol Et**

Bir satırın minimum yüksekliğini puan cinsinden ayarlamak için [IRow.MinimalHeight](https://reference.aspose.com/slides/net/aspose.slides/irow/minimalheight/) kullanın. Bu bir alt sınırdır, sabit bir yükseklik değildir. [IRow.Height](https://reference.aspose.com/slides/net/aspose.slides/irow/height/) gerçek yüksekliği döndürür ve yalnızca okunur. Satıra [ITable.Rows](https://reference.aspose.com/slides/net/aspose.slides/itable/rows/) üzerinden erişin.

Örnek, ilk slayttaki ilk şekil olarak bir tablo içeren [row-height-input.pptx](row-height-input.pptx) dosyasını yükler. İlk satırı 70 puandan başlar. Hücreler 18 puan Arial metin, kaydırma ve 6 puan üst ve alt kenar boşluğu kullanır; ikinci sütundaki daha uzun metin birden çok satıra kayar. Örnek, minimum değeri 100 puana yükseltir, ardından 20 puana düşürür, her değişiklikten sonra gerçek yüksekliği yazdırır ve her iki sonucu da kaydeder.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("row-height-input.pptx");
var table = (ITable)presentation.Slides[0].Shapes[0];
var row = table.Rows[0];

row.MinimalHeight = 100;
Console.WriteLine($"Increased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-increased.pptx", SaveFormat.Pptx);

row.MinimalHeight = 20;
Console.WriteLine($"Decreased: minimum = {row.MinimalHeight:F1}, actual = {row.Height:F1} pt");
presentation.Save("row-height-decreased.pptx", SaveFormat.Pptx);
```

Sağlanan sunumla, minimum değeri artırmak satıra boşluk ekler. Azaltmak bu ek boşluğu kaldırır, ancak gerçek yükseklik 20 puandan büyük kalır çünkü metin ve hücre kenar boşlukları daha fazla alana ihtiyaç duyar. Minimum değeri yalnızca azaltmak, satırı içeriğin gerektirdiği boşluğun altına zorlayamaz.

Gerçek yüksekliği etkileyen birkaç faktör:
- **Metin ve yazı tipi boyutu:** daha uzun metin, açık satır sonları veya daha büyük bir yazı tipi daha fazla dikey alan gerektirebilir.
- **Kaydırma ve sütun genişliği:** kaydırma etkinleştirildiğinde, daha dar bir [IColumn.Width](https://reference.aspose.com/slides/net/aspose.slides/icolumn/width/) daha fazla satır üretebilir. Daha geniş bir sütun dikey olarak gereken alanı azaltabilir.
- **Hücre kenar boşlukları:** [ICell.MarginTop](https://reference.aspose.com/slides/net/aspose.slides/icell/margintop/) ve [ICell.MarginBottom](https://reference.aspose.com/slides/net/aspose.slides/icell/marginbottom/) dikey boşluk ekler. [ICell.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/icell/marginleft/) ve [ICell.MarginRight](https://reference.aspose.com/slides/net/aspose.slides/icell/marginright/) metin için kullanılabilir genişliği azaltır ve ek kaydırmalara neden olabilir.

Birleştirilmiş hücreleri olmayan bu tabloda, en çok dikey alana ihtiyaç duyan hücre, tüm satır için içeriğe dayalı alt sınırı belirler. Satırı kısaltmak için metni kısaltmanız, yazı tipi boyutunu veya kenar boşluklarını azaltmanız veya bir sütunu genişletmeniz gerekebilir.

Aşağıdaki görseller aynı tabloyu aynı ölçekte gösterir. Bu çalışmada gerçek yükseklikler 70, 100 ve 55,2 puan oldu: son satır 20 puanlık minimumdan daha yüksek kaldı. Metin ölçüleri, ortamınızdaki mevcut yazı tiplerine bağlı olarak değişebilir. Kaydedilmiş sonuçları indirin: [increased minimum](row-height-increased.pptx) ve [decreased minimum](row-height-decreased.pptx).

| Orijinal: minimum 70 pt, gerçek 70 pt | Artırılmış: minimum 100 pt, gerçek 100 pt | Azaltılmış: minimum 20 pt, gerçek 55.2 pt |
| --- | --- | --- |
| ![Orijinal tablo, 70 puanlık ilk satırla.](row-height-before.png) | ![Tablo, ilk satır minimumu 100 puana artırıldıktan sonra.](row-height-increased.png) | ![Tablo, ilk satır minimumu 20 puana düşürüldükten sonra; kaydırılan metin satırı minimumdan daha yüksek tutar.](row-height-decreased.png) |

## **İlk Satırı Başlık Olarak Ayarla**

[FirstRow](https://reference.aspose.com/slides/net/aspose.slides/itable/firstrow/) özelliğini kullanarak ilk satırı başlık biçimlendirmesi için işaretleyin. Görünümü, tabloya uygulanan tablo stiline bağlıdır.

1. Sunumu [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) sınıfı ile yükleyin.
2. İlk slayta erişin.
3. Slayttaki ilk şekil olarak depolanan tabloya erişin.
4. İlk satır için başlık biçimlendirmesini etkinleştirin.
5. Değiştirilmiş sunumu kaydedin.

Örnek, ilk slayttaki ilk şekil olarak bir tablo içeren `table.pptx` dosyasını gerektirir. İlk satır için başlık biçimlendirmesini etkinleştirir ve `First_row_header.pptx` dosyasını kaydeder.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];
table.FirstRow = true;

presentation.Save("First_row_header.pptx", SaveFormat.Pptx);
```

## **Bir Tablo Satırını veya Sütununu Kopyala**

Satırları veya sütunları kopyalayarak içerik ve biçimlendirmelerini yeniden kullanın. Kopyayı tablonun sonuna ekleyebilir veya belirli bir konuma yerleştirebilirsiniz.

1. Sunumu [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) sınıfı ile yükleyin.
2. İlk slayta erişin.
3. Sütun genişliklerini ve satır yüksekliklerini tanımlayın.
4. Tabloyu [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) yöntemiyle ekleyin.
5. Gerekli satırları kopyalayın.
6. Gerekli sütunları kopyalayın.
7. Değiştirilmiş sunumu kaydedin.

Örnek, en az bir slayt içeren `Test.pptx` dosyasını gerektirir. Üç sütun ve beş satırdan oluşan bir tablo oluşturur; boyutlar puan cinsindendir. İlk satır ve sütunun kopyalarını sona ekler, ardından ikinci satır ve sütunun kopyalarını indeks 3'te (dördüncü konum) ekler. Ortaya çıkan tablo yedi satır ve beş sütun içerir. `false` argümanı, bitişik birleştirilmiş satır veya sütunlara kopyalamayı devre dışı bırakır; bu tabloda birleştirilmiş hücre yoktur.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];

var columnWidths = new double[] { 50, 50, 50 };
var rowHeights = new double[] { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[0, 0].TextFrame.Text = "Row 1 Cell 1";
table[1, 0].TextFrame.Text = "Row 1 Cell 2";
table.Rows.AddClone(table.Rows[0], false);

table[0, 1].TextFrame.Text = "Row 2 Cell 1";
table[1, 1].TextFrame.Text = "Row 2 Cell 2";
table.Rows.InsertClone(3, table.Rows[1], false);

table.Columns.AddClone(table.Columns[0], false);
table.Columns.InsertClone(3, table.Columns[1], false);

presentation.Save("table_out.pptx", SaveFormat.Pptx);
```

## **Bir Tablodan Satır veya Sütun Kaldır**

Tabloda artık ihtiyaç duyulmayan satırları veya sütunları kaldırın. Bir öğeyi kaldırmak, ardından gelen satır veya sütun indekslerini kaydırır.

1. Sunumu [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) sınıfı ile oluşturun.
2. İlk slayta erişin.
3. Sütun genişliklerini ve satır yüksekliklerini tanımlayın.
4. Tabloyu [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) yöntemiyle ekleyin.
5. İkinci satırı ve ikinci sütunu kaldırın.
6. Değiştirilmiş sunumu kaydedin.

Bu örnek, üçer üçer bir tablo oluşturur ve indeks 1'deki satır ve sütunu kaldırarak `TestTable_out.pptx` içinde ikiye iki bir tablo bırakır. Boyutlar puan cinsindendir. `false` argümanı, bitişik birleştirilmiş satır veya sütunların kaldırılmasını devre dışı bırakır; bu tabloda birleştirilmiş hücre yoktur.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 50, 30 };
var rowHeights = new double[] { 30, 50, 30 };
var table = slide.Shapes.AddTable(100, 100, columnWidths, rowHeights);

table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);

presentation.Save("TestTable_out.pptx", SaveFormat.Pptx);
```

## **Tablo Satır Düzeyinde Metin Biçimlendirmesi Ayarla**

Bir satırın tüm hücrelerinde tutarlı kalması için metin biçimlendirmesi uygulayın. Her hücreyi ayrı ayrı biçimlendirmeden yazı tipi özellikleri, paragraf biçimlendirmesi ve metin yönünü ayarlayabilirsiniz.

1. Sunumu [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) sınıfı ile yükleyin.
2. İlk slayttaki tabloya erişin.
3. [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) özelliğini ilk satır için ayarlayın.
4. [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) ve [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) özelliklerini ilk satır için ayarlayın.
5. [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) özelliğini ikinci satır için ayarlayın.
6. Değiştirilmiş sunumu kaydedin.

Örnek, ilk slayttaki ilk şekil olarak bir tablo ve en az iki satır içeren `table.pptx` dosyasını gerektirir. İlk satıra 25 puanlık metin, sağ hizalama ve 20 puanlık sağ paragraf kenar boşluğu uygular, ardından ikinci satıra dikey metin ayarlar.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Rows[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Rows[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Rows[1].SetTextFormat(textFrameFormat);

presentation.Save("row_formatting.pptx", SaveFormat.Pptx);
```

## **Tablo Sütun Düzeyinde Metin Biçimlendirmesi Ayarla**

Bir sütunun tüm hücrelerinde tutarlı kalması için metin biçimlendirmesi uygulayın. Her hücreyi ayrı ayrı biçimlendirmeden yazı tipi özellikleri, paragraf biçimlendirmesi ve metin yönünü ayarlayabilirsiniz.

1. Sunumu [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) sınıfı ile yükleyin.
2. İlk slayttaki tabloya erişin.
3. [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) özelliğini ilk sütun için ayarlayın.
4. [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) ve [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) özelliklerini ilk sütun için ayarlayın.
5. [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) özelliğini ikinci sütun için ayarlayın.
6. Değiştirilmiş sunumu kaydedin.

Örnek, ilk slayttaki ilk şekil olarak bir tablo ve en az iki sütun içeren `table.pptx` dosyasını gerektirir. İlk sütuna 25 puanlık metin, sağ hizalama ve 20 puanlık sağ paragraf kenar boşluğu uygular, ardından ikinci sütuna dikey metin ayarlar.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat { FontHeight = 25 };
table.Columns[0].SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat { Alignment = TextAlignment.Right, MarginRight = 20 };
table.Columns[0].SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat { TextVerticalType = TextVerticalType.Vertical };
table.Columns[1].SetTextFormat(textFrameFormat);

presentation.Save("column_formatting.pptx", SaveFormat.Pptx);
```

## **Tablo Stil Özelliklerini Al**

[StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/) özelliğini kullanarak bir tabloya uygulanan ön ayarı alın ve başka bir tabloda yeniden kullanın. Bu, bireysel hücre biçimlendirme geçersiz kılmalarından ziyade ön ayarı belirler.

Örnek bir tablo oluşturur, [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/) uygular ve ön ayarı geri okur. `DarkStyle1` değerini yazdırır ve tabloyu `table.pptx` dosyasına kaydeder.

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

Console.WriteLine(table.StylePreset);

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **SSS**

**Bir tabloya zaten oluşturulduktan sonra PowerPoint temalarını/stillerini uygulayabilir miyim?**

Evet. Tablo, slayt/düzen/ana tema mirasını alır ve bu temanın üzerinde dolgu, kenarlık ve metin renklerini hâlâ geçersiz kılabilirsiniz.

**Excel'deki gibi tablo satırlarını sıralayabilir miyim?**

Hayır, Aspose.Slides tabloları yerleşik sıralama veya filtreleme özelliğine sahip değildir. Verilerinizi önce bellekte sıralayın, ardından tablo satırlarını bu sırayla yeniden doldurun.

**Belirli hücrelerde özelleşmiş renkleri korurken şeritli (banded) sütunlar olabilir mi?**

Evet. Şeritli sütunları etkinleştirin, ardından belirli hücrelerde yerel biçimlendirme ile geçersiz kılın; hücre düzeyindeki biçimlendirme tablo stiline göre önceliklidir.