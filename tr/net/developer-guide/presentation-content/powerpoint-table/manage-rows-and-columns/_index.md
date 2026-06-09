---
title: .NET'te PowerPoint Tablolarında Satır ve Sütunları Yönetme
linktitle: Satır ve Sütunlar
type: docs
weight: 20
url: /tr/net/manage-rows-and-columns/
keywords:
- tablo satırı
- tablo sütunu
- ilk satır
- tablo başlığı
- satırı klonla
- sütunu klonla
- satırı kopyala
- sütunu kopyala
- satırı kaldır
- sütunu kaldır
- satır metin biçimlendirme
- sütun metin biçimlendirme
- tablo stili
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "PowerPoint'te tablo satır ve sütunlarını Aspose.Slides for .NET ile yönetin ve sunum düzenlemesini ve veri güncellemelerini hızlandırın."
---
## **Giriş**

PowerPoint sunumunda bir tablonun satır ve sütunlarını yönetmenizi sağlamak için Aspose.Slides, [Table](https://reference.aspose.com/slides/tr/net/aspose.slides/table/) sınıfı, [ITable](https://reference.aspose.com/slides/tr/net/aspose.slides/itable/) arayüzü ve birçok başka tür sağlar. 

## **İlk Satırı Başlık Olarak Ayarlama**

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun ve sunumu yükleyin. 
2. Bir slaytın referansını indeksine göre alın. 
3. Bir [ITable](https://reference.aspose.com/slides/tr/net/aspose.slides/itable/) nesnesi oluşturun ve null olarak ayarlayın. 
4. İlgili tabloyu bulmak için tüm [IShape](https://reference.aspose.com/slides/tr/net/aspose.slides/ishape/) nesnelerini döngüyle gezinin. 
5. Tablonun ilk satırını başlık olarak ayarlayın. 

Bu C# kodu, bir tablonun ilk satırını başlık olarak nasıl ayarlayacağınızı gösterir:

```c#
// Presentation sınıfını örnekler
Presentation pres = new Presentation("table.pptx");

// İlk slayta erişir
ISlide sld = pres.Slides[0];

// null TableEx'i başlatır
ITable tbl = null;

// Şekiller üzerinden döner ve tabloya bir referans ayarlar
foreach (IShape shp in sld.Shapes)
{
    if (shp is ITable)
    {
        tbl = (ITable)shp;
    }
}

// Tablonun ilk satırını başlık olarak ayarlar
tbl.FirstRow = true;

// Sunumu diske kaydeder
pres.Save("First_row_header.pptx", SaveFormat.Pptx);
```

## **Bir Tablo Satırını veya Sütununu Kopyalama**

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun ve sunumu yükleyin, 
2. Bir slaytın referansını indeksine göre alın. 
3. `columnWidth` dizisini tanımlayın. 
4. `rowHeight` dizisini tanımlayın. 
5. [AddTable](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/addtable/) yöntemiyle slayta bir [ITable](https://reference.aspose.com/slides/tr/net/aspose.slides/itable/) nesnesi ekleyin. 
6. Tablo satırını kopyalayın. 
7. Tablo sütununu kopyalayın. 
8. Değiştirilmiş sunumu kaydedin. 

Bu C# kodu, bir PowerPoint tablosunun satırını veya sütununu nasıl kopyalayacağınızı gösterir:

```c#
 // Presentation sınıfını örnekler
using (Presentation presentation = new Presentation("Test.pptx"))
{
    // İlk slayta erişir
    ISlide sld = presentation.Slides[0];

    // Sütunları genişliklerle ve satırları yüksekliklerle tanımlar
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Slayta bir tablo şekli ekler
    ITable table = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // 1. satır 1. hücresine bazı metin ekler
    table[0, 0].TextFrame.Text = "Row 1 Cell 1";

    // 1. satır 2. hücresine bazı metin ekler
    table[1, 0].TextFrame.Text = "Row 1 Cell 2";

    // Satır 1'i tablonun sonuna kopyalar
    table.Rows.AddClone(table.Rows[0], false);

    // 2. satır 1. hücresine bazı metin ekler
    table[0, 1].TextFrame.Text = "Row 2 Cell 1";

    // 2. satır 2. hücresine bazı metin ekler
    table[1, 1].TextFrame.Text = "Row 2 Cell 2";

    // Satır 2'yi tablonun 4. satırı olarak kopyalar
    table.Rows.InsertClone(3,table.Rows[1], false);

    // İlk sütunu sonuna kopyalar
    table.Columns.AddClone(table.Columns[0], false);

    // 2. sütunu 4. sütun indeksine kopyalar
    table.Columns.InsertClone(3,table.Columns[1], false);
    
    // Sunumu diske kaydeder 
    presentation.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Bir Tablodan Satır veya Sütun Kaldırma**

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun ve sunumu yükleyin, 
2. Bir slaytın referansını indeksine göre alın. 
3. `columnWidth` dizisini tanımlayın. 
4. `rowHeight` dizisini tanımlayın. 
5. [AddTable](https://reference.aspose.com/slides/tr/net/aspose.slides/ishapecollection/addtable/) yöntemiyle slayta bir [ITable](https://reference.aspose.com/slides/tr/net/aspose.slides/itable/) nesnesi ekleyin. 
6. Tablo satırını kaldırın. 
7. Tablo sütununu kaldırın. 
8. Değiştirilmiş sunumu kaydedin. 

Bu C# kodu, bir tablodan satır veya sütun nasıl kaldırılır gösterir:

```c#
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];
double[] colWidth = { 100, 50, 30 };
double[] rowHeight = { 30, 50, 30 };

ITable table = slide.Shapes.AddTable(100, 100, colWidth, rowHeight);
table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);
pres.Save("TestTable_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Tablo Satır Düzeyinde Metin Biçimlendirmesini Ayarlama**

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun ve sunumu yükleyin, 
2. Bir slaytın referansını indeksine göre alın. 
3. Slayttan ilgili [ITable](https://reference.aspose.com/slides/tr/net/aspose.slides/itable/) nesnesine erişin. 
4. İlk satır hücrelerinin [FontHeight](https://reference.aspose.com/slides/tr/net/aspose.slides/baseportionformat/fontheight/) değerini ayarlayın. 
5. İlk satır hücrelerinin [Alignment](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/alignment/) ve [MarginRight](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/marginright/) değerlerini ayarlayın. 
6. İkinci satır hücrelerinin [TextVerticalType](https://reference.aspose.com/slides/tr/net/aspose.slides/textframeformat/textverticaltype/) değerini ayarlayın. 
7. Değiştirilmiş sunumu kaydedin. 

Bu C# kodu işlemi gösterir.

```c#
// Presentation sınıfının bir örneğini oluşturur
Presentation presentation = new Presentation();
           
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // İlk slayttaki ilk şeklin bir tablo olduğunu varsayalım

// İlk satır hücrelerinin yazı tipi yüksekliğini ayarlar
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Rows[0].SetTextFormat(portionFormat);

// İlk satır hücrelerinin metin hizalamasını ve sağ kenar boşluğunu ayarlar
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Rows[0].SetTextFormat(paragraphFormat);

// İkinci satır hücrelerinin dikey metin tipini ayarlar
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Rows[1].SetTextFormat(textFrameFormat);

// Sunumu diske kaydeder
presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Tablo Sütun Düzeyinde Metin Biçimlendirmesini Ayarlama**

1. [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation) sınıfının bir örneğini oluşturun ve sunumu yükleyin, 
2. Bir slaytın referansını indeksine göre alın. 
3. Slayttan ilgili [ITable](https://reference.aspose.com/slides/tr/net/aspose.slides/itable/) nesnesine erişin. 
4. İlk sütun hücrelerinin [FontHeight](https://reference.aspose.com/slides/tr/net/aspose.slides/baseportionformat/fontheight/) değerini ayarlayın. 
5. İlk sütun hücrelerinin [Alignment](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/alignment/) ve [MarginRight](https://reference.aspose.com/slides/tr/net/aspose.slides/iparagraphformat/marginright/) değerlerini ayarlayın. 
6. İkinci sütun hücrelerinin [TextVerticalType](https://reference.aspose.com/slides/tr/net/aspose.slides/textframeformat/textverticaltype/) değerini ayarlayın. 
7. Değiştirilmiş sunumu kaydedin. 

Bu C# kodu işlemi gösterir: 

```c#
// Presentation sınıfının bir örneğini oluşturur
Presentation pres = new Presentation();
           
ISlide slide = pres.Slides[0];

ITable someTable = pres.Slides[0].Shapes[0] as ITable; // İlk slayttaki ilk şeklin bir tablo olduğunu varsayalım

// İlk sütun hücrelerinin yazı tipi yüksekliğini ayarlar
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Columns[0].SetTextFormat(portionFormat);

// İlk sütun hücrelerinin metin hizalamasını ve sağ kenar boşluğunu tek çağrıda ayarlar
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Columns[0].SetTextFormat(paragraphFormat);

// İkinci sütun hücrelerinin dikey metin tipini ayarlar
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Columns[1].SetTextFormat(textFrameFormat);

// Sunumu diske kaydeder
pres.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Tablo Stil Özelliklerini Al**

Aspose.Slides, bir tablo için stil özelliklerini almanıza olanak tanır; böylece bu detayları başka bir tablo ya da başka bir yerde kullanabilirsiniz. Bu C# kodu, bir tablo ön ayar stilinden stil özelliklerini nasıl alacağınızı gösterir: 

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // varsayılan stil ön ayar temasını değiştir
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **SSS**

**PowerPoint temalarını/stillerini zaten oluşturulmuş bir tabloya uygulayabilir miyim?**

Evet. Tablo, slayt/düzen/ana tema’yı devralır ve bu temanın üzerine dolgu, kenarlık ve metin renklerini hâlâ geçersiz kılabilirsiniz.

**Tablo satırlarını Excel’deki gibi sıralayabilir miyim?**

Hayır, Aspose.Slides tablolarında yerleşik sıralama veya filtreleme bulunmaz. Verilerinizi önce bellekte sıralayın, ardından tablo satırlarını o sırayla yeniden doldurun.

**Özel renklere sahip belirli hücreleri korurken şeritli (banded) sütunlar kullanabilir miyim?**

Evet. Şeritli sütunları etkinleştirin, ardından belirli hücreleri yerel biçimlendirme ile geçersiz kılın; hücre‑seviyesi biçimlendirme tablo stiline üstünlük tanır.