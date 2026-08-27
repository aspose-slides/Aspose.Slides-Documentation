---
title: C++'ta Sunum Tablolarını Yönetme
linktitle: Tablo Yönetimi
type: docs
weight: 10
url: /tr/cpp/manage-table/
keywords:
- tablo ekle
- tablo oluştur
- tabloya eriş
- en-boy oranı
- metni hizala
- metin biçimlendirme
- tablo stili
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint slaytlarında tablo oluşturun ve düzenleyin. Tablo iş akışlarınızı basitleştirecek basit kod örneklerini keşfedin."
---
## **Giriş**

PowerPoint'te bir tablo, bilgiyi göstermenin ve aktarmanın etkili bir yoludur. Satır ve sütunlara düzenlenmiş hücrelerden oluşan ızgara içindeki bilgi basittir ve anlaşılması kolaydır.

Aspose.Slides, [Table](https://reference.aspose.com/slides/tr/cpp/aspose.slides/table/) sınıfını, [ITable](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itable/) arayüzünü, [Cell](https://reference.aspose.com/slides/tr/cpp/aspose.slides/cell/) sınıfını, [ICell](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icell/) arayüzünü ve tabloları her türlü sunumda oluşturmanıza, güncellemenize ve yönetmenize olanak tanıyan diğer türleri sağlar. 

## **Sıfırdan Tablo Oluşturma**

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Kaydırmanın (slide) indeksine göre bir referans alın.  
3. `columnWidth` adlı bir dizi tanımlayın.  
4. `rowHeight` adlı bir dizi tanımlayın.  
5. [AddTable()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/addtable/) yöntemiyle slayta bir [ITable](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itable/) nesnesi ekleyin.  
6. Her bir [ICell](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icell/) üzerinden geçerek üst, alt, sağ ve sol kenarlara biçimlendirme uygulayın.  
7. Tablonun ilk satırındaki ilk iki hücreyi birleştirin.  
8. Bir [ICell](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icell/)'in [TextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/textframe/) öğesine erişin.  
9. [TextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/textframe/)'e bir metin ekleyin.  
10. Değiştirilen sunumu kaydedin.

Bu C++ kodu bir sunumda tablo oluşturmanın yolunu gösterir:

```c++
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

// Bir PPTX dosyasını temsil eden Presentation sınıfını örnekler
auto pres = System::MakeObject<Presentation>();

// İlk slayta erişir
auto sld = pres->get_Slides()->idx_get(0);

// Sütunları genişlikleri ve satırları yükseklikleriyle tanımlar
auto dblCols = System::MakeArray<double>({ 50, 50, 50 });
auto dblRows = System::MakeArray<double>({ 50, 30, 30, 30, 30 });

// Adds a table shape to the slide
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Her hücre için kenarlık biçimini ayarlar
for (int32_t row = 0; row < tbl->get_Rows()->get_Count(); row++)
{
    for (int32_t cell = 0; cell < tbl->get_Rows()->idx_get(row)->get_Count(); cell++)
    {
        auto cellFormat = tbl->get_Rows()->idx_get(row)->idx_get(cell)->get_CellFormat();

        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType((FillType::Solid));
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}
// 1. satırın 1 ve 2. hücrelerini birleştirir
tbl->MergeCells(tbl->get_Rows()->idx_get(0)->idx_get(0), tbl->get_Rows()->idx_get(1)->idx_get(1), false);

// Birleştirilmiş hücreye metin ekler
tbl->get_Rows()->idx_get(0)->idx_get(0)->get_TextFrame()->set_Text(u"Merged Cells");

// Sunumu diske kaydeder
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Standart Tablo Numaralandırması**

Standart bir tabloda hücrelerin numaralandırması basittir ve sıfır temellidir. Bir tablodaki ilk hücre 0,0 (sütun 0, satır 0) olarak indekslenir. 

Örneğin, 4 sütun ve 4 satırdan oluşan bir tablo aşağıdaki şekilde numaralandırılır:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Bu C++ kodu bir tabloda hücrelerin numaralandırmasını nasıl belirleyeceğinizi gösterir:

```c++
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

// PPTX dosyasını temsil eden Presentation sınıfının bir örneğini oluşturur
auto pres = System::MakeObject<Presentation>();

// İlk slayta erişir
auto sld = pres->get_Slides()->idx_get(0);

// Sütunları genişlikleri ve satırları yükseklikleriyle tanımlar
auto dblCols = System::MakeArray<double>({ 70, 70, 70, 70 });
auto dblRows = System::MakeArray<double>({ 70, 70, 70, 70 });

// Slayta bir tablo şekli ekler
auto tbl = sld->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);

// Her hücre için kenarlık biçimini ayarlar
for (const auto& row : tbl->get_Rows())
{
    for (const auto& cell : row)
    {
        auto cellFormat = cell->get_CellFormat();
        cellFormat->get_BorderTop()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderTop()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderTop()->set_Width(5);

        cellFormat->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderBottom()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderBottom()->set_Width(5);

        cellFormat->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderLeft()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderLeft()->set_Width(5);

        cellFormat->get_BorderRight()->get_FillFormat()->set_FillType(FillType::Solid);
        cellFormat->get_BorderRight()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
        cellFormat->get_BorderRight()->set_Width(5);
    }
}

// Sunumu diske kaydeder
pres->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **Mevcut Bir Tabloya Erişim**

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  

2. Tabloyu içeren slayta indeks aracılığıyla bir referans alın.  

3. Bir [ITable](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itable/) nesnesi oluşturun ve bunu null olarak ayarlayın.  

4. Tablo bulunana kadar tüm [IShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/) nesneleri arasında dolaşın.  

   Tek bir tablo içerdiğini düşünüyorsanız, içinde bulunduğu tüm şekilleri kontrol edebilirsiniz. Bir şekil tablo olarak tanımlanırsa, onu bir [Table](https://reference.aspose.com/slides/tr/cpp/aspose.slides/table/) nesnesine tip dönüştürebilirsiniz. Ancak slayt birden fazla tablo içeriyorsa, ihtiyacınız olan tabloyu [set_AlternativeText()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/set_alternativetext/) yöntemiyle aramanız daha uygundur.  

5. [ITable](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itable/) nesnesini tabloyla çalışmak için kullanın. Aşağıdaki örnekte tabloya yeni bir satır ekledik.  

6. Değiştirilen sunumu kaydedin.  

Bu C++ kodu mevcut bir tabloya nasıl erişileceğini ve onunla nasıl çalışılacağını gösterir:

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// PPTX dosyasını temsil eden Presentation sınıfının bir örneğini oluşturur
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// İlk slayta erişir
auto sld = pres->get_Slides()->idx_get(0);

// Null tabloyu başlatır
System::SharedPtr<ITable> tbl;

// Şekiller üzerinde döner ve bulunan tabloya bir referans ayarlar
for (const auto& shp : System::IterateOver(sld->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// İkinci satırın ilk sütunu için metni ayarlar
tbl->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");

// Değiştirilen sunumu diske kaydeder
pres->Save(u"table1_out.pptx", SaveFormat::Pptx);
```

## **Metin Çerçevesine Sahip Hücreyi Bulma**

Genel metin işleme kodu bir tablodan bir [ITextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/) aldığında, sahip [ICell](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icell/)'i elde etmek için [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/get_parentcell/) kullanın. Bir tablo hücresi metin çerçevesi için, [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/get_parentcell/) sahibi döndürür ve [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/get_parentshape/) `nullptr` verir; çünkü tablo kendisi bir şekildir.  

Hücre koordinatları, sadece okunabilen [ICell::get_FirstColumnIndex](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icell/get_firstcolumnindex/) ve [ICell::get_FirstRowIndex](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icell/get_firstrowindex/) yöntemleriyle elde edilir. [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/get_parentcell/) ayrıca sadece okunabilen bir gezinme sağlar: sahibi döndürür ancak sahipliği değiştirmez. Kullanımdan önce döndürülen hücrenin `nullptr` olup olmadığını her zaman kontrol edin.  

Tablo hücresi ve şekil sahiplerini, SmartArt düğümleriyle ilişkili şekilleri de kapsayan tam bir örnek için, [Search and Replace Text](/slides/tr/cpp/search-and-replace-text/) bölümüne bakın.

## **Tablodaki Metni Hizalama**

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Kaydırmanın indeksine göre bir referans alın.  
3. Slayta bir [ITable](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itable/) nesnesi ekleyin.  
4. Tablodan bir [ITextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/) nesnesine erişin.  
5. [ITextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/)'in [IParagraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraph/) öğesine erişin.  
6. Metni dikey olarak hizalayın.  
7. Değiştirilen sunumu kaydedin.  

Bu C++ kodu bir tabloda metni nasıl hizalayacağınızı gösterir:

```c++
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <DOM/TextAnchorType.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

// Presentation sınıfının bir örneğini oluşturur
auto presentation = System::MakeObject<Presentation>();

// İlk slaytı alır
auto slide = presentation->get_Slides()->idx_get(0);

// Sütunları genişlikleri ve satırları yükseklikleriyle tanımlar
auto dblCols = System::MakeArray<double>({ 120, 120, 120, 120 });
auto dblRows = System::MakeArray<double>({ 100, 100, 100, 100 });

// Slayta tablo şekli ekler
auto tbl = slide->get_Shapes()->AddTable(100.0f, 50.0f, dblCols, dblRows);
tbl->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
tbl->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
tbl->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

// Metin çerçevesine erişir
auto txtFrame = tbl->idx_get(0, 0)->get_TextFrame();

// Metin çerçevesi için Paragraph nesnesi oluşturur
auto paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Paragraf için Portion nesnesi oluşturur
auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

// Metni dikey olarak hizalar
auto cell = tbl->idx_get(0, 0);
cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

// Sunumu diske kaydeder
presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **Tablo Düzeyinde Metin Biçimlendirmesini Ayarlama**

1. [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Kaydırmanın indeksine göre bir referans alın.  
3. Slayttan bir [ITable](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itable/) nesnesine erişin.  
4. Metin için [set_FontHeight()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/baseportionformat/set_fontheight/) yöntemini ayarlayın.  
5. [set_Alignment()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/set_alignment/) ve [set_MarginRight()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/set_marginright/) yöntemlerini ayarlayın.  
6. [set_TextVerticalType()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/textframeformat/set_textverticaltype/) yöntemini ayarlayın.  
7. Değiştirilen sunumu kaydedin.  

Bu C++ kodu bir tabloda metne tercih ettiğiniz biçimlendirme seçeneklerini nasıl uygulayacağınızı gösterir:

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/PortionFormat.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Presentation sınıfının bir örneğini oluşturur
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slides()->idx_get(0);

// İlk slayttaki ilk şeklin bir tablo olduğunu varsayalım
auto someTable = System::AsCast<ITable>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

// Tablo hücrelerinin yazı tipi yüksekliğini ayarlar
auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
someTable->SetTextFormat(portionFormat);

// Tablo hücrelerinin metin hizalamasını ve sağ kenar boşluğunu tek bir çağrıda ayarlar
auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
someTable->SetTextFormat(paragraphFormat);

// Tablo hücrelerinin metin dikey tipini ayarlar
auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
someTable->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Tablo Stil Özelliklerini Alma**

Aspose.Slides, bir tablonun stil özelliklerini almanızı sağlar; böylece bu ayrıntıları başka bir tablo veya başka bir yerde kullanabilirsiniz. Bu C++ kodu bir tablo ön ayar stilinden stil özelliklerini nasıl alacağınızı gösterir:

```c++
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TableStylePreset.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Tablonun En Boy Oranını Kilitleme**

Geometrik bir şeklin en‑boy oranı, farklı boyutlardaki ölçülerin oranıdır. Aspose.Slides, tablolar ve diğer şekiller için en‑boy oranı kilitleme ayarını sağlayan `AspectRatioLocked()` özelliğini sunar. 

Bu C++ kodu bir tablonun en‑boy oranını nasıl kilitleyeceğinizi gösterir:

```c++
#include <DOM/IGraphicalObjectLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());


table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **SSS**

**Bir tablonun ve hücrelerindeki metnin sağ‑sol (RTL) okuma yönünü etkinleştirebilir miyim?**  

Evet. Tablo, [set_RightToLeft](https://reference.aspose.com/slides/tr/cpp/aspose.slides/table/set_righttoleft/) yöntemini sunar ve paragraflar [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/tr/cpp/aspose.slides/paragraphformat/set_righttoleft/) yöntemine sahiptir. Her ikisinin de kullanılması, hücre içindeki doğru RTL sırasını ve renderlamayı garantiler.  

**Kullanıcıların final dosyasında tabloyu hareket ettirmesini veya yeniden boyutlandırmasını nasıl engelleyebilirim?**  

[shape locks](/slides/tr/cpp/applying-protection-to-presentation/) özelliğini kullanarak hareket etmeyi, yeniden boyutlandırmayı, seçimi vb. devre dışı bırakın. Bu kilitlemeler tablolar için de geçerlidir.  

**Bir hücrenin arka planına resim eklemek destekleniyor mu?**  

Evet. Bir hücre için [picture fill](https://reference.aspose.com/slides/tr/cpp/aspose.slides/picturefillformat/) ayarlayabilirsiniz; resim, seçilen moda (germe veya döşeme) göre hücre alanını kaplar.