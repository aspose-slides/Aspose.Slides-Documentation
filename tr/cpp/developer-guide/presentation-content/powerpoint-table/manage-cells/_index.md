---
title: C++ ile Sunumlarda Tablo Hücrelerini Yönetme
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
description: "C++ ile PowerPoint tablo hücrelerini yönetin: birleştirilmiş hücreleri belirleyin, kenarlıkları kaldırın, hücreleri bölün ve Aspose.Slides for C++ ile arka plan renkleri ve resimler ayarlayın."
---
## **Genel Bakış**

Aspose.Slides, PowerPoint sunumlarındaki tablo hücrelerine erişmenizi ve bu hücreleri değiştirmenizi sağlar. Bu makale, birleştirilmiş tablo hücrelerini nasıl tanımlayacağınızı, hücre kenarlıklarını nasıl kaldıracağınızı, hücreleri birleştirip bölerek hücre numaralandırmasını nasıl yöneteceğinizi, bir hücrenin arka plan rengini nasıl değiştireceğinizi ve bir tablo hücresine nasıl resim ekleyeceğinizi açıklar. Örnekler, bir sunumun nasıl oluşturulup açılacağını, bir slayttan tablonun nasıl alınacağını, hücre özellikleri üzerinden hücre biçimlendirmesinin nasıl güncelleneceğini ve değiştirilmiş sunumun PPTX dosyası olarak nasıl kaydedileceğini gösterir.

Aspose.Slides, tablo hücrelerine `(column, row)` sırasıyla erişmek için sıfır tabanlı dizinler kullanır.

## **Birleştirilmiş Tablo Hücresini Tanımlama**

Örnek, mevcut bir sunumu açar ve ilk slayttaki ilk şekle tablo olarak erişir. Kaydırının ve şeklin mevcut olduğu ve şeklin bir tablo olduğu varsayılır. Ardından tüm satır ve sütunlar üzerinde döner ve birleştirilmiş bölgelerdeki hücreleri tanımlamak için [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) kullanır. Her eşleşme için hücre koordinatlarını `row;column` sırasıyla, [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/), [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/) ve bölgenin başlangıç koordinatlarını [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) ve [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) yazar.

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

[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) oluşturun ve ilk slaytına [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) ile bir tablo ekleyin. Sütun genişlikleri, satır yükseklikleri ve tablo konumu puan cinsinden belirtilir. Örnek, dört hücre kenarlığını da [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) yaparak görünmez kılar.

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

## **Tablo Hücrelerini Birleştirme**

[MergeCells](https://reference.aspose.com/slides/cpp/aspose.slides/itable/mergecells/) kullanarak dikdörtgen bir hücre aralığını tek bir hücreye birleştirin. Aralığın sol üst ve sağ alt köşesindeki hücreleri belirtin. Son argüman, birleştirmenin belirtilen aralığın dışındaki hücreleri içerebilir olup olmadığını kontrol eder; `false` birleştirmenin bu aralık içinde kalmasını sağlar.

Örnek, 70 puanlık sütun ve satırlara sahip 4 × 4 bir tablo oluşturur, ardından `(1, 1)` ile `(2, 2)` arasındaki dört merkezi hücreyi birleştirir. Ortaya çıkan hücre iki sütun ve iki satır kapsar, ancak tablonun temel ızgarası dört sütun ve dört satır olarak kalır. Birleştirilmiş hücrenin içeriğine veya biçimlendirmesine erişmek için bu örnekte `table->idx_get(1, 1)` kullanılır. Birleştirilmiş aralıktaki diğer konumlar tablo ızgarasının bir parçası olmaya devam eder, bu yüzden aralıktaki olmayan hücrelerin dizinleri değişmez.

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

Önceki örnekte hücreleri birleştirmek tablo ızgarasını korur. Bir hücreyi bölmek yeni bir ızgara sütunu oluşturabilir ve sağındaki hücrelerin sütun dizinlerini değiştirebilir. Aspose.Slides, PowerPoint’in tablo ızgara modelini izler.

Bu örnek, 70 puanlık sütun ve satırlara sahip 4 × 4 bir tablo oluşturur ve `(1, 1)` hücresinde [SplitByWidth](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbywidth/) metodunu çağırır. Hücrenin 70 puanlık genişliğinin yarısı iki eşit genişlikte hücre oluşturmak için geçirilir.

Bu bölmeden sonra iki yarı `table->idx_get(1, 1)` ve `table->idx_get(2, 1)` olarak erişilir. Tablo ızgarası artık beş sütuna sahiptir: orijinal olarak 2 ve 3 numaralı sütunlardaki hücreler sırasıyla 3 ve 4 numaralı sütunlara kayar. Satır dizinleri değişmez. Bölmeden sonra hücrelere erişirken güncellenmiş sütun dizinlerini kullanın.

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

### **Satır veya Sütun Boyutu ile Birleştirilmiş Hücreleri Bölme**

Veri doldurma için birleştirilmiş şablon hücrelerini hazırlamak amacıyla, mevcut bir satır sınırı boyunca bölmek için [SplitByRowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbyrowspan/), bir sütun sınırı boyunca bölmek için ise [SplitByColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/splitbycolspan/) kullanın.

`index` argümanı, bölmenin üst kısmındaki satırları veya sol kısmındaki sütunları sayar; birleştirilmiş bölgeye göre görecelidir:

- Satır bölme: `0 < index <` [get_RowSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_rowspan/).
- Sütun bölme: `0 < index <` [get_ColSpan](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_colspan/).

Örnek, sunumun ilk slaytındaki ilk şeklin bir tablo olduğunu ve `(1, 2)` ile `(1, 3)` hücrelerinin dikey olarak birleştirildiğini varsayar. Alt konumdan başlayarak [get_FirstColumnIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstcolumnindex/) ve [get_FirstRowIndex](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_firstrowindex/) kullanarak başlangıcı bulur ve her iki yayılımı da kontrol eder. `SplitByRowSpan(1)` ardından satır 2 ve 3’ü ürün adları için ayırır. Yatay iki sütun birleştirmesi için bunun yerine `SplitByColSpan(1)` kullanın.

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

    // Bölme işleminden sonra tablodan elde edilen hücreleri alın.
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

Tablo ızgarası ve çevresindeki hücre dizinleri değişmeden kalır. Sonuçta elde edilen hücreleri koordinatlarıyla alın; burada her ikisinin de yayılımı 1 ve [get_IsMergedCell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/get_ismergedcell/) `False` yazdırır. Daha büyük bölgeler tek bir bölmeden sonra kısmen birleştirilmiş kalabilir.

Orijinal metin ve biçimlendirmesi üst (veya sol) hücrede kalır; yeni hücre boş olur ancak dolgu, kenarlık ve kenar boşlukları gibi hücre biçimlendirmesini devralır. Hücreleri bölme işleminden sonra doldurun ve gerektiğinde metin biçimlendirmesini açıkça ayarlayın.

Kaydedilen sunum, şablonun hücre biçimlendirmesini koruyan ayrı “Product A” ve “Product B” hücreleri içerir. Ayrıntılar için [Cell API Reference](https://reference.aspose.com/slides/cpp/aspose.slides/cell/) bakın.

## **Tablo Hücresinin Arka Plan Rengini Değiştirme**

Bu örnek, 150 puanlık sütun ve 50 puanlık satırlara sahip bir tablo oluşturur. Hücre `(2, 3)` için kırmızı renk ayarlamak amacıyla [set_FillType](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) ile katı dolgu seçilir ve [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/get_solidfillcolor/) ile doldurma rengi alınarak kırmızıya ayarlanır.

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

## **Tablo Hücresi İçine Resim Ekleme**

Bu örneği çalıştırmadan önce giriş resmini çalışma dizinine koyun. Resim, [Images::FromFile](https://reference.aspose.com/slides/cpp/aspose.slides/images/fromfile/) ile yüklenir ve [AddImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimagecollection/addimage/) ile sunumun görüntü koleksiyonuna eklenir. Ardından resim, tablonun ilk hücresi olan `(0, 0)` hücresinin resim dolgusuna atanır.

[PictureFillMode::Stretch](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) resmi hücreyi dolduracak şekilde gerer; bu, en-boy oranını değiştirebilir. Sütun genişlikleri ve satır yükseklikleri puan cinsindendir. Yüklenen resim, sunuma eklendikten sonra iptal edilir.

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

**Bir hücrenin farklı kenarları için farklı çizgi kalınlıkları ve stilleri ayarlayabilir miyim?**

Evet. [top](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_bordertop/)/[bottom](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderbottom/)/[left](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderleft/)/[right](https://reference.aspose.com/slides/cpp/aspose.slides/cellformat/get_borderright/) kenarlıklarının ayrı özellikleri vardır, bu nedenle her bir kenarın kalınlığı ve stili farklı olabilir.

**Hücrenin arka planı olarak bir resim ayarladıktan sonra sütun/satıra boyut değiştirirsem resim ne olur?**

Davranış, [fill mode](https://reference.aspose.com/slides/cpp/aspose.slides/picturefillmode/) (stretch/tile) değerine bağlıdır. Stretch seçilirse resim yeni hücreye göre ayarlanır; tile seçilirse döşemeler yeniden hesaplanır.

**Bir hücrenin tüm içeriğine bir hiperlink atayabilir miyim?**

[Hyperlinks](/slides/tr/cpp/manage-hyperlinks/) hücre metin çerçevesi içindeki metin (portion) düzeyinde veya tüm tablo/şekil düzeyinde ayarlanır. Pratikte, bağlantıyı bir parçaya ya da hücredeki tüm metne atarsınız.

**Bir hücre içinde farklı yazı tipleri ayarlayabilir miyim?**

Evet. Hücrenin metin çerçevesi, bağımsız biçimlendirmeye sahip [portions](https://reference.aspose.com/slides/cpp/aspose.slides/portion/) (run) destekler; bunların yazı tipi ailesi, stili, boyutu ve rengi ayrı ayrı ayarlanabilir.