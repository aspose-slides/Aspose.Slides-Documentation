---
title: C++ Kullanarak Sunumlarda Tablo Hücrelerini Yönetme
linktitle: Hücreleri Yönet
type: docs
weight: 30
url: /tr/cpp/manage-cells/
keywords:
- tablo hücresi
- hücre birleştirme
- kenarlık kaldırma
- hücre bölme
- hücrede resim
- arka plan rengi
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "C++ ile PowerPoint tablo hücrelerini yönetin: birleştirilmiş hücreleri tanımlayın, kenarlıkları kaldırın, hücreleri bölün ve Aspose.Slides for C++ ile arka plan renkleri ve resimler ayarlayın."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarındaki tablo hücrelerine erişmenizi ve bunları değiştirmenizi sağlar. Bu makale, birleştirilmiş tablo hücrelerini nasıl tanımlayacağınızı, hücre kenarlıklarını nasıl kaldıracağınızı, birleştirme veya bölme işleminden sonra hücre numaralandırmasıyla nasıl çalışılacağını, bir hücrenin arka plan rengini nasıl değiştireceğinizi ve bir tablo hücresine nasıl resim ekleyeceğinizi açıklar. Örnekler, bir sunumun nasıl oluşturulup açılacağını, bir slayttan nasıl tablo alınacağını, hücre özellikleri aracılığıyla hücre biçimlendirmesinin nasıl güncelleneceğini ve değiştirilmiş sunumun PPTX dosyası olarak nasıl kaydedileceğini gösterir.

Aspose.Slides, tablo hücrelerine sıfır‑tabanlı indeksler kullanarak `(sütun, satır)` sırasıyla erişir.

## **Birleştirilmiş Tablo Hücresini Tanımlama**

Örnek, mevcut bir sunumu açar ve ilk slayttaki ilk şekli tablo olarak alır. Slayt ve şeklin mevcut olduğu ve şeklin bir tablo olduğu varsayılır. Daha sonra tüm satır ve sütunlar üzerinden döner ve [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) metodunu kullanarak birleştirilmiş bölgelerdeki hücreleri tanımlar. Eşleşen her hücre için, hücre koordinatlarını `satır;sütun` sırasıyla, [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/), [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/) ve bölgenin başlangıç koordinatlarını, [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) ve [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) ile yazdırır.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation_with_table.pptx");
auto slide = presentation->get_Slide(0);
auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto rowCount = table->get_Rows()->get_Count();
for (auto rowIndex = 0; rowIndex < rowCount; rowIndex++)
{
    auto columnCount = table->get_Columns()->get_Count();
    for (auto columnIndex = 0; columnIndex < columnCount; columnIndex++)
    {
        auto cell = table->idx_get(columnIndex, rowIndex);
        if (cell->get_IsMergedCell())
        {
            Console::WriteLine(u"Cell {0};{1} belongs to a merged region with RowSpan={2} and ColSpan={3} starting at {4};{5}.", rowIndex, columnIndex, cell->get_RowSpan(), cell->get_ColSpan(), cell->get_FirstRowIndex(), cell->get_FirstColumnIndex());
        }
    }
}
```

## **Tablo Hücre Kenarlıklarını Kaldırma**

[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) oluşturun ve ilk slayta [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) ile bir tablo ekleyin. Sütun genişlikleri, satır yükseklikleri ve tablo konumu nokta cinsinden belirtilir. Örnek, dört hücre kenarlığını da [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) olarak ayarlayarak görünmez yapar.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <system/enumerator_adapter.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({50, 50, 50, 50});
auto rowHeights = MakeArray<double>({50, 30, 30, 30, 30});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

for (const auto& row : IterateOver(table->get_Rows()))
    for (const auto& cell : IterateOver(row))
    {
        cell->get_CellFormat()->get_BorderTop()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderBottom()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderLeft()->get_FillFormat()->set_FillType(FillType::NoFill);
        cell->get_CellFormat()->get_BorderRight()->get_FillFormat()->set_FillType(FillType::NoFill);
    }

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Köşegen Hücre Kenarlıkları Ekleme**

[ get_BorderDiagonalDown](https://reference.aspose.com/slides/cpp/aspose.slides/icellformat/get_borderdiagonaldown/) ile sol‑üst köşeden sağ‑alt köşeye bir çizgi çizebilir, [ get_BorderDiagonalUp](https://reference.aspose.com/slides/cpp/aspose.slides/icellformat/get_borderdiagonalup/) ile sol‑alt köşeden sağ‑üst köşeye bir çizgi çizebilirsiniz. Köşegen, köşe başlığını işaretlemek için kullanılabilir; her iki köşegen bir X şekli oluşturarak hücrenin geçerli olmadığını gösterebilir.

Her köşegen bir [ILineFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/) nesnesidir. Doldurmasına erişmek için [get_FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/get_fillformat/) kullanın, ardından [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ilinefillformat/set_filltype/) ile [FillType::Solid](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) seçin ve [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ilinefillformat/get_solidfillcolor/) ile bir renk belirleyin. Çizgi kalınlığı, nokta cinsinden [set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/ilineformat/set_width/) ile ayarlanır.

Örnek, bir satırda üç hücre oluşturur: kırmızı aşağı doğru köşegen, mavi yukarı doğru köşegen ve her iki köşegen. Üst, alt, sol ve sağ kenarlıklar değişmeden bırakılır.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <system/array.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({210, 210, 210});
auto rowHeights = MakeArray<double>({160});
auto table = slide->get_Shapes()->AddTable(45, 130, columnWidths, rowHeights);

auto downwardBorder = table->idx_get(0, 0)->get_CellFormat()->get_BorderDiagonalDown();
downwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
downwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
downwardBorder->set_Width(3);

auto upwardBorder = table->idx_get(1, 0)->get_CellFormat()->get_BorderDiagonalUp();
upwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
upwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
upwardBorder->set_Width(5);

auto crossDownwardBorder = table->idx_get(2, 0)->get_CellFormat()->get_BorderDiagonalDown();
crossDownwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
crossDownwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
crossDownwardBorder->set_Width(3);

auto crossUpwardBorder = table->idx_get(2, 0)->get_CellFormat()->get_BorderDiagonalUp();
crossUpwardBorder->get_FillFormat()->set_FillType(FillType::Solid);
crossUpwardBorder->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
crossUpwardBorder->set_Width(5);

presentation->Save(u"diagonal_cell_borders.pptx", SaveFormat::Pptx);
```

Köşegen bir biçimlendirme özelliğidir, hücre bölünmesi değildir. Her hücre, [get_TextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_textframe/) aracılığıyla erişilebilen tek bir metin çerçevesi tutar; köşegenin iki tarafındaki bölgeler bağımsız olarak düzenlenemez.

Microsoft PowerPoint’te renderlanmış kaydedilmiş tablo:

![Üç tablo hücresi, sol‑üstten sağ‑alta kırmızı bir köşegen, sol‑altten sağ‑üstte mavi bir köşegen ve her iki köşegeni bir X şeklinde gösteriyor.](diagonal-cell-borders.png)

*Soldan sağa: aşağı doğru köşegen (kırmızı, 3 pt), yukarı doğru köşegen (mavi, 5 pt) ve her iki köşegen.*

## **Tablo Hücrelerini Birleştirme**

[MergeCells](https://reference.aspose.com/slides/cpp/aspose.slides/itable/mergecells/) kullanarak dikdörtgen bir hücre aralığını tek bir hücreye birleştirebilirsiniz. Aralığın sol‑üst ve sağ‑alt köşe hücrelerini belirtin. Son argüman, birleştirmenin belirtilen aralık dışındaki hücreleri içerip içermeyeceğini kontrol eder; `false` değeri birleştirmenin sadece bu aralıkta kalmasını sağlar.

Örnek, 70 nokta genişliğinde sütun ve satırlara sahip 4 × 4 bir tablo oluşturur, ardından `(1, 1)` ile `(2, 2)` arasındaki dört merkez hücreyi birleştirir. Ortaya çıkan hücre iki sütun ve iki satır kapsar, ancak tablonun temel ızgarası hâlâ dört sütun ve dört satırdır. Birleştirilmiş hücrenin içeriğine veya biçimlendirmesine erişmek için, bu örnekte `table->idx_get(1, 1)` kullanarak sol‑üst konumunu kullanın. Birleştirilmiş aralıktaki diğer konumlar tablo ızgarasının bir parçası olmaya devam eder; aralık dışındaki hücre indeksleri değişmez.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({70, 70, 70, 70});
auto rowHeights = MakeArray<double>({70, 70, 70, 70});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->MergeCells(table->idx_get(1, 1), table->idx_get(2, 2), false);

presentation->Save(u"merged_cells.pptx", SaveFormat::Pptx);
```

## **Tablo Hücrelerini Bölme**

Önceki örnekte hücrelerin birleştirilmesi tablo ızgarasını korur. Bir hücreyi bölmek yeni bir ızgara sütunu oluşturabilir ve sağındaki hücrelerin sütun indekslerini değiştirebilir. Aspose.Slides, PowerPoint’in tablo ızgara modelini izler.

Bu örnek, 70 nokta genişliğinde sütun ve satırlara sahip 4 × 4 bir tablo oluşturur ve `(1, 1)` hücresinde [SplitByWidth](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbywidth/) metodunu çağırır. Hücrenin 70 nokta genişliğinin yarısı iki eşit genişlikte hücre oluşturmak için kullanılır.

Bu bölmeden sonra iki yarı `table->idx_get(1, 1)` ve `table->idx_get(2, 1)` olarak erişilir. Tablo ızgarası artık beş sütuna sahiptir: orijinal olarak 2 ve 3 numaralı sütunlardaki hücreler sırasıyla 3 ve 4 numaralı sütunlara kayar. Satır indeksleri değişmez. Bölmeden sonra hücrelere erişirken bu güncellenmiş sütun indekslerini kullanın.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({70, 70, 70, 70});
auto rowHeights = MakeArray<double>({70, 70, 70, 70});
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->idx_get(1, 1)->SplitByWidth(table->idx_get(1, 1)->get_Width() / 2);

presentation->Save(u"split_cells.pptx", SaveFormat::Pptx);
```


<!-- visual-explanation:manage-cells:start -->
[![Birleştirilmemiş 70‑nokta hücresi iki 35‑nokta hücreye bölünerek beşinci ızgara sütununu ekler ve sağındaki indeksleri kaydırır.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*Genişlik bölmesi (1, 1) hücresini etkiler, sıfır‑tabanlı (sütun, satır) indeksleri kullanır. Diğer satırlar, iki yeni sütun konumunu kapsayan bir hücreyi korur.*
<!-- visual-explanation:manage-cells:end -->

### **Birleştirilmiş Hücreleri Satır veya Sütun Boyunca Bölme**

Birleştirilmiş şablon hücrelerini veri doldurma için hazırlamak amacıyla, mevcut bir satır sınırına göre bölmek için [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/), bir sütun sınırına göre bölmek için ise [SplitByColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbycolspan/) kullanın.

`index` argümanı, bölmenin üst kısmındaki satırları veya sol kısmındaki sütunları sayar; birleştirilmiş bölgeye göre görecelidir:

- Satır bölmesi: `0 < index <` [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/).
- Sütun bölmesi: `0 < index <` [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/).

Örnek, bir sunumun ilk slaydındaki ilk şeklin bir tablo olduğunu varsayar; `(1, 2)` ve `(1, 3)` hücreleri dikey olarak birleştirilmiştir. Alt konumdan başlayarak [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) ve [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) ile başlangıç bulunur ve her iki kapsam da kontrol edilir. `SplitByRowSpan(1)` ardından satır 2 ve 3’ü ürün adları için ayırır. Yatay iki‑sütun birleştirme için ise `SplitByColSpan(1)` kullanılmalıdır.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/ITextFrame.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table_template.pptx");
auto slide = presentation->get_Slide(0);
auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto selectedCell = table->idx_get(1, 3);
auto firstColumnIndex = selectedCell->get_FirstColumnIndex();
auto firstRowIndex = selectedCell->get_FirstRowIndex();
auto mergedCell = table->idx_get(firstColumnIndex, firstRowIndex);

if (mergedCell->get_IsMergedCell() && mergedCell->get_RowSpan() == 2 && mergedCell->get_ColSpan() == 1)
{
    mergedCell->SplitByRowSpan(1);

    // Bölme işleminden sonra tablodan elde edilen hücreleri al.
    auto upperCell = table->idx_get(firstColumnIndex, firstRowIndex);
    auto lowerCell = table->idx_get(firstColumnIndex, firstRowIndex + 1);
    Console::WriteLine(u"Upper cell merged: {0}", upperCell->get_IsMergedCell());
    Console::WriteLine(u"Lower cell merged: {0}", lowerCell->get_IsMergedCell());

    upperCell->get_TextFrame()->set_Text(u"Product A");
    lowerCell->get_TextFrame()->set_Text(u"Product B");

    presentation->Save(u"split_template.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Select a merged region spanning exactly two rows and one column.");
}
```

Tablo ızgarası ve çevredeki hücre indeksleri değişmeden kalır. Oluşan hücreler koordinatlarıyla alınabilir; burada her iki hücrenin de kapsamı 1’dir ve [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) `False` döndürür. Bir bölmeden sonra daha büyük bölgeler kısmen birleştirilmiş kalabilir.

Orijinal metin ve biçimlendirmesi üst (veya sol) hücrede kalır; yeni hücre boş olur ancak doldurma, kenarlık ve kenar boşlukları gibi hücre biçimlendirmesini devralır. Bölmeden sonra hücreleri doldurun ve gerekirse metin biçimlendirmesini açıkça ayarlayın.

Kaydedilen sunum, şablonun hücre biçimlendirmesi korunmuş “Product A” ve “Product B” hücrelerini içerir. Ayrıntılar için [Cell API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) sayfasına bakın.

### **Bir Hücreyi Belirli Bir Yükseklikte Bölme**

[SplitByHeight](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyheight/) üst kısmın yüksekliğini nokta cinsinden alır. [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/) üst kısmın kaç mevcut ızgara satırı içerdiğini alır. Sağ sütunda 40‑nokta yüksekliğinde bir hücreyi ortalamak için hücrenin gerçek yüksekliğinden 40 çıkartın ve kalan boşluğu üstte ve altta eşit olarak bölün.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <DOM/ITextFrame.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({160, 160});
auto rowHeights = MakeArray<double>({140});

auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);
table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Left");

auto height = table->idx_get(1, 0)->get_Height();
auto margin = (height - 40) / 2;

table->idx_get(1, 0)->SplitByHeight(margin);
table->idx_get(1, 1)->SplitByHeight(40);
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"Middle");

presentation->Save(u"split_by_height.pptx", SaveFormat::Pptx);
```

İlk bölme bir ızgara satırı ekleyerek alt kısmı `(1, 1)` konumunda 90 nokta bırakır. İkinci bölme bu hücreyi hedef alır ve altına bir satır daha ekler. Sağ sütun artık `(1, 0)` konumunda 50 nokta (`margin`), `(1, 1)` konumunda 40 nokta ve `(1, 2)` konumunda 50 nokta (`margin`) içerir. Sol hücre, orijinal 140 nokta yüksekliğiyle üç satırı da kapsar.

![Sol hücre, ortadaki “Middle” metniyle üç hücrenin yanına tablonun tam yüksekliğini kaplar.](split-by-height.png)

## **Tablo Hücre Arka Plan Rengini Değiştirme**

Bu örnek, 150 nokta genişliğinde sütunlar ve 50 nokta yüksekliğinde satırlar içeren bir tablo oluşturur. [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) ile katı doldurma seçilir ve [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/) aracılığıyla doldurma rengi kırmızı olarak ayarlanır; bu, üçüncü sütun ve dördüncü satırdaki `(2, 3)` hücresine uygulanır.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/Table/ICellFormat.h>
#include <drawing/color.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace System::Drawing;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({150, 150, 150, 150});
auto rowHeights = MakeArray<double>({50, 50, 50, 50, 50});
auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);

auto cell = table->idx_get(2, 3);
cell->get_CellFormat()->get_FillFormat()->set_FillType(FillType::Solid);
cell->get_CellFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

presentation->Save(u"cell_background_color.pptx", SaveFormat::Pptx);
```

## **Bir Tablo Hücresine Resim Ekleme**

Bu örneği çalıştırmadan önce giriş resmini çalışma dizinine koyun. Resim, [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) ile yüklenir ve [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/) ile sunumun resim koleksiyonuna eklenir. Ardından resim, tablonun ilk hücresi `(0, 0)` için resim doldurmasına atanır.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) resmi hücreyi dolduracak şekilde uzatır, bu da en‑boy oranını değiştirebilir. Sütun genişlikleri ve satır yükseklikleri nokta cinsindendir. Yüklenen resim, sunuma eklendikten sonra serbest bırakılır.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ICell.h>
#include <system/smart_ptr.h>
#include <DOM/FillType.h>
#include <DOM/IImageCollection.h>
#include <IImage.h>
#include <DOM/IPPImage.h>
#include <DOM/IFillFormat.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Table/ICellFormat.h>
#include <Util/Images.h>
#include <Export/SaveFormat.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({150, 150, 150, 150});
auto rowHeights = MakeArray<double>({100, 100, 100, 100, 90});
auto table = slide->get_Shapes()->AddTable(50, 50, columnWidths, rowHeights);

auto image = Images::FromFile(u"aspose_logo.jpg");
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->set_FillType(FillType::Picture);
table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
table->idx_get(0, 0)->get_CellFormat()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

presentation->Save(u"table_cell_with_image.pptx", SaveFormat::Pptx);
```

## **SSS**

**Tek bir hücrenin farklı kenarları için farklı çizgi kalınlıkları ve stilleri ayarlayabilir miyim?**

Evet. [top](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_bordertop/), [bottom](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderbottom/), [left](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderleft/), [right](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderright/) kenarlarının ayrı özellikleri vardır; böylece her bir kenarın kalınlığı ve stili farklı olabilir.

**Bir resmi hücrenin arka planı olarak ayarladıktan sonra sütun/satır boyutunu değiştirirsem ne olur?**

Davranış, kullanılan [fill mode](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) (stretch/tile) ile ilgilidir. Stretch seçildiğinde resim yeni hücreye göre ayarlanır; tile seçildiğinde ise döşemeler yeniden hesaplanır.

**Bir hücrenin tüm içeriğine bir hiperlink atayabilir miyim?**

[Hyperlinks](/slides/tr/cpp/manage-hyperlinks/) hücrenin metin çerçevesindeki (portion) düzeyinde ya da tüm tablo/şekil seviyesinde ayarlanır. Pratikte bağlantıyı bir bölüm ya da hücredeki tüm metne atarsınız.

**Tek bir hücre içinde farklı yazı tipleri ayarlayabilir miyim?**

Evet. Hücrenin metin çerçevesi, bağımsız biçimlendirmeye sahip [portions](https://reference.aspose.com/slides/cpp/aspose.slides/portion/) (run) destekler; bu sayede yazı tipi ailesi, stili, boyutu ve rengi hücrenin içinde farklılaştırılabilir.