---
title: "C++'de Sunum Tablolarını Yönetme"
linktitle: "Tabloyu Yönet"
type: docs
weight: 10
url: /tr/cpp/manage-table/
keywords:
- "tablo ekle"
- "tablo oluştur"
- "tabloya eriş"
- "en-boy oranı"
- "metni hizala"
- "metin biçimlendirme"
- "tablo stili"
- "PowerPoint"
- "sunum"
- "C++"
- "Aspose.Slides"
description: "Aspose.Slides for C++ ile PowerPoint slaytlarında tablo oluşturun ve düzenleyin. Tablo iş akışlarınızı hızlandırmak için basit kod örneklerini keşfedin."
---
## **Giriş**

PowerPoint'teki tablolar, bilgileri satır ve sütunlara düzenler, değerleri okumayı ve karşılaştırmayı kolaylaştırır.

Aspose.Slides, sunularda tablolar oluşturmanıza, güncellemenize ve yönetmenize olanak tanıyan [Table](https://reference.aspose.com/slides/cpp/aspose.slides/table/) sınıfını, [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) arayüzünü, [Cell](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) sınıfını, [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) arayüzünü ve diğer türleri sağlar.

## **Sıfırdan Bir Tablo Oluşturma**

Konum, sütun genişlikleri ve satır yükseklikleri belirterek bir tablo oluşturun. Slayta ekledikten sonra hücre kenarlıklarını biçimlendirebilir, hücreleri birleştirebilir ve metin ekleyebilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. İndeksine göre slayta bir referans alın.  
3. Sütun genişliklerini puan cinsinden bir dizi olarak tanımlayın.  
4. Satır yüksekliklerini puan cinsinden bir dizi olarak tanımlayın.  
5. Slayta, [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) yöntemiyle bir [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) nesnesi ekleyin.  
6. Her bir [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) üzerinden geçerek üst, alt, sağ ve sol kenarlara biçimlendirme uygulayın.  
7. Tablonun ilk satırındaki ilk iki hücreyi birleştirin.  
8. Birleştirilmiş hücreye, [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/) metoduyla erişin.  
9. Birleştirilmiş hücreye metin ayarlayın.  
10. Değiştirilmiş sunumu kaydedin.

Aşağıdaki örnek, (100, 50) puanda üç sütun ve beş satırdan oluşan bir tablo oluşturur. 5 puan genişliğinde kırmızı kenarlıklar uygular, ilk satırdaki ilk iki hücreyi birleştirir ve sonucu `table.pptx` olarak kaydeder.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
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

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 50, 50, 50 });
auto rowHeights = System::MakeArray<double>({ 50, 30, 30, 30, 30 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

for (const auto& row : table->get_Rows())
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

table->MergeCells(table->idx_get(0, 0), table->idx_get(1, 0), false);
table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Merged Cells");

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Standart Bir Tablo İçindeki Numaralandırma**

Standart bir tabloda hücre indeksleri sıfır tabanlıdır ve (sütun, satır) sırasını kullanır. İlk hücre (0, 0) olarak indekslenir.

Örneğin, 4 sütun ve 4 satırdan oluşan bir tablodaki hücreler aşağıdaki gibi numaralandırılır:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Bu örnek, yukarıda gösterilen 4 × 4 tabloyu, sütun genişlikleri ve satır yükseklikleri 70 puan ve 5 puan genişliğinde kırmızı hücre kenarlıklarıyla oluşturur. Koordinatlar hücre indekslerini gösterir; örnek hücreleri boş bırakır ve tabloyu `StandardTables_out.pptx` olarak kaydeder.

```cpp
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
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

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 70, 70, 70, 70 });
auto rowHeights = System::MakeArray<double>({ 70, 70, 70, 70 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

for (const auto& row : table->get_Rows())
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

presentation->Save(u"StandardTables_out.pptx", SaveFormat::Pptx);
```

## **Var Olmuş Bir Tabloya Erişim**

Tablolar, bir slaytın şekil koleksiyonunda saklanır. Şekiller arasında dolaşarak bir tablo bulun, ardından hücrelerini okumak veya güncellemek için [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) arayüzünü kullanın.

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) sınıfını kullanarak sunumu yükleyin.  
2. İndeksine göre tabloyu içeren slayta bir referans alın.  
3. [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) nesneleri arasında dolaşın ve bir tablo bulunduğunda durun. Slayt birden fazla tablo içeriyorsa, ihtiyacınız olanı belirlemek için [get_AlternativeText](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/get_alternativetext/) kullanın.  
4. Hedef hücredeki metni güncelleyin.  
5. Değiştirilmiş sunumu kaydedin.

Aşağıdaki örnek `UpdateExistingTable.pptx` dosyasını açar ve ilk slayttaki ilk tabloyu bulur. Hücreyi sütun 0, satır 1 olarak `New` değerine ayarlar ve sonucu `table1_out.pptx` olarak kaydeder. Girdi en az bir slayt içermeli ve o slayttaki ilk tablo en az bir sütun ve iki satır içermelidir.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");
auto slide = presentation->get_Slide(0);
System::SharedPtr<ITable> table;

for (const auto& shape : System::IterateOver(slide->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shape))
    {
        table = System::ExplicitCast<ITable>(shape);
        break;
    }
}

if (table != nullptr)
{
    table->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");
    presentation->Save(u"table1_out.pptx", SaveFormat::Pptx);
}
```

Var olan bir tabloda bir satırı yeniden boyutlandırmak ve gerçek yüksekliğinin istenen minimumu neden aşabileceğini anlamak için [Control Row Height](/slides/tr/cpp/manage-rows-and-columns/#control-row-height) bölümüne bakın.

## **Bir Metin Çerçevesine Sahip Hücreyi Bulma**

Genel metin işleme kodu bir tablodan bir [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) aldığında, sahip [ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/) nesnesini almak için [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) kullanın. Bir tablo hücresi metin çerçevesi için, [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) sahibi döndürür ve [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentshape/) `nullptr` döndürür, tablo kendisi bir şekil olsa bile.

Hücre koordinatları, sadece okunabilir [ICell::get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) ve [ICell::get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) yöntemleriyle alınabilir. [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_parentcell/) ayrıca sadece okunabilir bir gezinme sağlar: sahibi döndürür ancak sahipliği değiştirmez. Kullanımdan önce döndürülen hücrenin `nullptr` olup olmadığını her zaman kontrol edin.

SmartArt düğümleriyle ilişkili şekiller de dahil olmak üzere tablo hücresi ve şekil sahiplerini tanımlayan tam bir örnek için [Search and Replace Text](/slides/tr/cpp/search-and-replace-text/) bölümüne bakın.

## **Tabloda Metni Hizalama**

Tek tek tablo hücrelerinin dikey sabitlemesini ve metin yönünü kontrol edebilirsiniz. Bu bölümdeki örnek, ilk hücredeki metni ortalar ve 270 derece döndürür.

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. İndeksine göre slayta bir referans alın.  
3. Slayta bir [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) nesnesi ekleyin.  
4. Tablodan bir [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) nesnesine erişin.  
5. İlk [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) nesnesine erişin ve metnini ve rengini ayarlayın.  
6. Hücrenin dikey sabitlemesini ve metin yönünü [set_TextAnchorType](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_textanchortype/) ve [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_textverticaltype/) kullanarak ayarlayın.  
7. Değiştirilmiş sunumu kaydedin.

Bu örnek, sütun genişlikleri 120 puan ve satır yükseklikleri 100 puan olan 4 × 4 bir tablo oluşturur. (0, 0) hücresindeki metni biçimlendirir, ilk satırdaki kalan hücrelere değer ekler ve sonucu `Vertical_Align_Text_out.pptx` olarak kaydeder.

```cpp
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

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 120, 120, 120, 120 });
auto rowHeights = System::MakeArray<double>({ 100, 100, 100, 100 });
auto table = slide->get_Shapes()->AddTable(100.0f, 50.0f, columnWidths, rowHeights);

table->idx_get(1, 0)->get_TextFrame()->set_Text(u"10");
table->idx_get(2, 0)->get_TextFrame()->set_Text(u"20");
table->idx_get(3, 0)->get_TextFrame()->set_Text(u"30");

auto cell = table->idx_get(0, 0);
auto paragraph = cell->get_TextFrame()->get_Paragraphs()->idx_get(0);

auto portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Text here");
portion->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
portion->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

cell->set_TextAnchorType(TextAnchorType::Center);
cell->set_TextVerticalType(TextVerticalType::Vertical270);

presentation->Save(u"Vertical_Align_Text_out.pptx", SaveFormat::Pptx);
```

## **Tablo Düzeyinde Metin Biçimlendirmesini Ayarlama**

[SetTextFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulktextformattable/settextformat/) kullanarak bir tablodaki tüm hücrelere metin biçimlendirmesi uygulayabilirsiniz. Aşırı yüklemeleri, parça, paragraf ve metin çerçevesi biçimlendirmesini kabul eder, böylece tek tek hücreleri dolaşmadan bu özellikleri ayarlayabilirsiniz.

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) sınıfını kullanarak sunumu yükleyin.  
2. İndeksine göre slayta bir referans alın.  
3. Slayttan bir [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) nesnesine erişin.  
4. Metin için [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) kullanarak yazı punto büyüklüğünü ayarlayın.  
5. [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) ve [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) kullanarak paragraf hizalamasını ve sağ kenar boşluğunu ayarlayın.  
6. [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) kullanarak metin yönünü ayarlayın.  
7. Değiştirilmiş sunumu kaydedin.

Aşağıdaki örnek, ilk şekli tablo olan en az bir slayt içeren `table.pptx` dosyasını açar. Yazı boyutunu 25 puana, paragrafları 20 puan sağ kenar boşluğu ile sağa hizalar ve metni dikey yapar. Biçimlendirilmiş sunum `result.pptx` olarak kaydedilir.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
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

auto presentation = System::MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = System::MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25.0f);
table->SetTextFormat(portionFormat);

auto paragraphFormat = System::MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20.0f);
table->SetTextFormat(paragraphFormat);

auto textFrameFormat = System::MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->SetTextFormat(textFrameFormat);

presentation->Save(u"result.pptx", SaveFormat::Pptx);
```

## **Tablo Stil Özelliklerini Almak**

[get_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_stylepreset/) kullanarak bir tablonun önceden ayarlanmış stilini okuyun ve [set_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/set_stylepreset/) ile atayın. Bu örnek, bir tabloya [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/cpp/aspose.slides/tablestylepreset/) uygular, ön ayar adını yazdırır ve aynı ön ayarı ikinci tabloya atar. Her iki tablo da `table-style.pptx` içinde kaydedilir.

```cpp
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <DOM/TableStylePreset.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = System::MakeArray<double>({ 100, 150 });
auto rowHeights = System::MakeArray<double>({ 5, 5, 5 });
auto table = slide->get_Shapes()->AddTable(10, 10, columnWidths, rowHeights);
table->set_StylePreset(TableStylePreset::DarkStyle1);

auto stylePreset = table->get_StylePreset();
System::Console::WriteLine(u"Table style preset: {0}", stylePreset);

auto anotherTable = slide->get_Shapes()->AddTable(10, 100, columnWidths, rowHeights);
anotherTable->set_StylePreset(stylePreset);

presentation->Save(u"table-style.pptx", SaveFormat::Pptx);
```

## **Bir Tablonun En Boy Oranını Kilitleme**

Bir tablonun en boy oranı, genişliğinin yüksekliğine oranıdır. Bu oranı bir tablo için kilitlemek üzere [set_AspectRatioLocked](https://reference.aspose.com/slides/cpp/aspose.slides/igraphicalobjectlock/set_aspectratiolocked/) kullanın.

Aşağıdaki örnek, ilk şekli tablo olan en az bir slayt içeren `pres.pptx` dosyasını açar. Mevcut kilit durumunu yazdırır, en boy oranı kilidini etkinleştirir, güncellenmiş durumu (`True`) yazar ve sonucu `pres-out.pptx` olarak kaydeder.

```cpp
#include <DOM/IGraphicalObjectLock.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto slide = presentation->get_Slide(0);

auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

table->get_GraphicalObjectLock()->set_AspectRatioLocked(true);
Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

presentation->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Bir bütün tablo ve hücrelerindeki metin için sağdan sola (RTL) okuma yönünü etkinleştirebilir miyim?**

Evet. Tablo, bir [set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/table/set_righttoleft/) yöntemi sunar ve paragraflar da [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphformat/set_righttoleft/) yöntemine sahiptir. Her ikisini de kullanmak, hücre içindeki doğru RTL sırasını ve renderlamasını sağlar.

**Kullanıcıların final dosyada bir tabloyu taşımasını veya yeniden boyutlandırmasını nasıl önleyebilirim?**

[shape locks](/slides/tr/cpp/applying-protection-to-presentation/) kullanarak taşıma, yeniden boyutlandırma, seçim vb. işlemleri devre dışı bırakabilirsiniz. Bu kilitler tablolara da uygulanır.

**Bir hücrenin içinde arka plan olarak bir resim eklemek destekleniyor mu?**

Evet. Bir hücre için [picture fill](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillformat/) ayarlayabilirsiniz; resim, seçilen moda (esnetme veya döşeme) göre hücre alanını kaplayacaktır.