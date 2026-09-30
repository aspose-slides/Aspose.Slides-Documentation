---
title: C++ Kullanarak PowerPoint Tablolarında Satır ve Sütunları Yönetme
linktitle: Satır ve Sütunlar
type: docs
weight: 20
url: /tr/cpp/manage-rows-and-columns/
keywords:
- tablo satırı
- tablo sütunu
- ilk satır
- tablo başlığı
- satırı çoğalt
- sütunu çoğalt
- satır kopyala
- sütun kopyala
- satırı kaldır
- sütunu kaldır
- satır metin biçimlendirmesi
- sütun metin biçimlendirmesi
- tablo stili
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint'te tablo satırlarını ve sütunlarını yönetin ve sunum düzenleme ve veri güncellemelerini hızlandırın."
---
## **Giriş**

Aspose.Slides for C++ size, PowerPoint sunumlarında tablo yapısını ve biçimlendirmesini [Tablo](https://reference.aspose.com/slides/cpp/aspose.slides/table/) sınıfı ve [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) arabirimi üzerinden yönetmenizi sağlar. Başlık satırı belirleyebilir, satır ve sütunları kopyalayabilir veya kaldırabilir ve tüm bir satır veya sütun için metin biçimlendirmesi uygulayabilirsiniz.

Bu makale bu işlemleri C++ örnekleriyle açıklar. Ayrıca bir tablonun stil ön ayarını nasıl alabileceğinizi ve yeniden kullanabileceğinizi gösterir. Tablo satır ve sütun indeksleri sıfır tabanlıdır.

## **Satır Yüksekliğini Kontrol Et**

Satırın minimum yüksekliğini puan cinsinden ayarlamak için [IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/) kullanın. Bu bir alt sınırdır, sabit bir yükseklik değildir. [IRow::get_Height](https://reference.aspose.com/slides/cpp/aspose.slides/irow/get_height/) gerçek yüksekliği döndürür; bu değer doğrudan ayarlanamaz. Satıra [ITable::get_Rows](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_rows/) aracılığıyla erişin.

Örnek, ilk slayttaki ilk şekil olarak bir tablo içeren [row-height-input.pptx](row-height-input.pptx) dosyasını yükler. İlk satırı 70 puanda başlar. Hücreler 18 puan Arial metin, satır sonu sarmalama ve 6 puan üst ve alt kenar boşlukları kullanır; ikinci sütundaki daha uzun metin birden fazla satıra sarılır. Örnek minimumu 100 puana artırır, ardından 20 puana düşürür, her değişiklikten sonra gerçek yüksekliği yazdırır ve her iki sonucu kaydeder.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IRow.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"row-height-input.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));
auto row = table->get_Rows()->idx_get(0);

row->set_MinimalHeight(100);
Console::WriteLine(u"Increased: minimum = {0:F1}, actual = {1:F1} pt", row->get_MinimalHeight(), row->get_Height());
presentation->Save(u"row-height-increased.pptx", SaveFormat::Pptx);

row->set_MinimalHeight(20);
Console::WriteLine(u"Decreased: minimum = {0:F1}, actual = {1:F1} pt", row->get_MinimalHeight(), row->get_Height());
presentation->Save(u"row-height-decreased.pptx", SaveFormat::Pptx);
```

Sağlanan sunumda, minimumu artırmak satıra boşluk ekler. Azaltmak ise bu ekstra boşluğu kaldırır, ancak metin ve hücre kenar boşlukları daha fazla alan gerektirdiği için gerçek yükseklik 20 puandan büyük kalır. Minimumu yalnızca azaltmak, satırı içeriğinin gerektirdiği boşluğun altına zorlayamaz.

Gerçek yüksekliği etkileyen birkaç faktör vardır:
- **Metin ve yazı tipi boyutu:** daha uzun metin, açık satır sonları veya daha büyük bir yazı tipi daha fazla düşey alan gerektirebilir.
- **Sarma ve sütun genişliği:** sarma etkinleştirildiğinde, [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) ile sütun genişliğini azaltmak daha çok satır oluşturabilir. Daha geniş bir sütun ise düşey alana ihtiyaç duyulan boşluğu azaltabilir.
- **Hücre kenar boşlukları:** [ICell::set_MarginTop](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_margintop/) ve [ICell::set_MarginBottom](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginbottom/) dikey boşluk ekleyen kenar boşluklarını kontrol eder. [ICell::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginleft/) ve [ICell::set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/icell/set_marginright/) metin için kullanılabilir genişliği azaltan kenar boşluklarını kontrol eder ve ek sarma oluşturabilir.

Birleştirilmiş hücreleri olmayan bu tabloda, en fazla düşey alan gerektiren hücre, tüm satır için içeriğe dayalı alt sınırı belirler. Satırı kısaltmak için metni kısaltmanız, yazı tipi boyutunu veya kenar boşluklarını azaltmanız veya bir sütunu genişletmeniz gerekebilir.

Aşağıdaki görseller aynı tabloyu aynı ölçekte gösterir. Burada gösterilen referans .NET çalıştırmasında, gerçek yükseklikler 70, 100 ve 55,2 puandı: son satır 20 puanlık minimumundan daha yüksek kaldı. Metin ölçümleri, ortamınızdaki mevcut yazı tiplerine bağlı olarak değişebilir. Kaydedilen sonuçları indirin: [artırılmış minimum](row-height-increased.pptx) ve [azaltılmış minimum](row-height-decreased.pptx).

| Orijinal: minimum 70 pt, gerçek 70 pt | Artırılmış: minimum 100 pt, gerçek 100 pt | Azaltılmış: minimum 20 pt, gerçek 55.2 pt |
| --- | --- | --- |
| ![70 puanlık ilk satıra sahip orijinal tablo.](row-height-before.png) | ![İlk satır minimumu 100 puana artırıldıktan sonraki tablo.](row-height-increased.png) | ![İlk satır minimumu 20 puana düşürüldükten sonraki tablo; sarılmış metin satırı minimumtan daha yüksek tutar.](row-height-decreased.png) |

## **İlk Satırı Başlık Olarak Ayarla**

[set_FirstRow](https://reference.aspose.com/slides/cpp/aspose.slides/itable/set_firstrow/) metodunu kullanarak ilk satırı başlık biçimlendirmesi için işaretleyin. Görünümü, tabloya uygulanan tablo stiline bağlıdır.

1. Sunumu [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) sınıfı ile yükleyin.
2. İlk slayta erişin.
3. Slayttaki ilk şekil olarak kaydedilmiş tabloya erişin.
4. İlk satır için başlık biçimlendirmesini etkinleştirin.
5. Değiştirilen sunumu kaydedin.

Örnek, ilk slayttaki ilk şekil olarak bir tablo içeren `table.pptx` dosyasını gerektirir. İlk satır için başlık biçimlendirmesini etkinleştirir ve `First_row_header.pptx` dosyasını kaydeder.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));
table->set_FirstRow(true);

presentation->Save(u"First_row_header.pptx", SaveFormat::Pptx);
```

## **Bir Tablo Satırını veya Sütununu Kopyala**

Satırları veya sütunları kopyalayarak içeriklerini ve biçimlendirmelerini yeniden kullanın. Kopyayı tablonun sonuna ekleyebilir veya belirli bir konuma ekleyebilirsiniz.

1. Sunumu [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) sınıfı ile yükleyin.
2. İlk slayta erişin.
3. Sütun genişliklerini ve satır yüksekliklerini tanımlayın.
4. [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) metodunu kullanarak bir tablo ekleyin.
5. Gerekli satırları kopyalayın.
6. Gerekli sütunları kopyalayın.
7. Değiştirilen sunumu kaydedin.

Örnek, en az bir slaytı olan `Test.pptx` dosyasını gerektirir. Üç sütun ve beş satırdan oluşan, boyutları puan cinsinden belirtilen bir tablo oluşturur. İlk satır ve sütunun kopyalarını sonuna ekler, ardından ikinci satır ve sütunun kopyalarını indeks 3'te (dördüncü konum) ekler. Ortaya çıkan tablo yedi satır ve beş sütuna sahiptir. `false` argümanı, bitişik birleştirilmiş satır veya sütunlara kopyalamayı devre dışı bırakır; bu tabloda birleştirilmiş hücre yoktur.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Table/ICell.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Test.pptx");
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 50, 50, 50 });
auto rowHeights = MakeArray<double>({ 50, 30, 30, 30, 30 });
auto table = slide->get_Shapes()->AddTable(100, 50, columnWidths, rowHeights);

table->idx_get(0, 0)->get_TextFrame()->set_Text(u"Row 1 Cell 1");
table->idx_get(1, 0)->get_TextFrame()->set_Text(u"Row 1 Cell 2");
table->get_Rows()->AddClone(table->get_Rows()->idx_get(0), false);

table->idx_get(0, 1)->get_TextFrame()->set_Text(u"Row 2 Cell 1");
table->idx_get(1, 1)->get_TextFrame()->set_Text(u"Row 2 Cell 2");
table->get_Rows()->InsertClone(3, table->get_Rows()->idx_get(1), false);

table->get_Columns()->AddClone(table->get_Columns()->idx_get(0), false);
table->get_Columns()->InsertClone(3, table->get_Columns()->idx_get(1), false);

presentation->Save(u"table_out.pptx", SaveFormat::Pptx);
```

## **Bir Tablo Satırını veya Sütununu Kaldır**

Tabloda artık ihtiyaç duyulmayan satırları veya sütunları kaldırın. Bir öğeyi kaldırmak, ardından gelen satır ve sütunların indekslerini kaydırır.

1. [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) sınıfı ile bir sunum oluşturun.
2. İlk slayta erişin.
3. Sütun genişliklerini ve satır yüksekliklerini tanımlayın.
4. [AddTable](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addtable/) metodunu kullanarak bir tablo ekleyin.
5. İkinci satırı ve ikinci sütunu kaldırın.
6. Değiştirilen sunumu kaydedin.

Bu örnek, üç satır üç sütunluk bir tablo oluşturur ve indeks 1'deki satır ve sütunu kaldırarak `TestTable_out.pptx` içinde iki satır iki sütunluk bir tablo bırakır. Boyutlar puan cinsindendir. `false` argümanı, bitişik birleştirilmiş satır veya sütunların kaldırılmasını devre dışı bırakır; bu tabloda birleştirilmiş hücre yoktur.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IColumnCollection.h>
#include <system/array.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 100, 50, 30 });
auto rowHeights = MakeArray<double>({ 30, 50, 30 });
auto table = slide->get_Shapes()->AddTable(100, 100, columnWidths, rowHeights);

table->get_Rows()->RemoveAt(1, false);
table->get_Columns()->RemoveAt(1, false);

presentation->Save(u"TestTable_out.pptx", SaveFormat::Pptx);
```

## **Tablo Satırı Düzeyinde Metin Biçimlendirmesi Ayarla**

Tüm bir satıra metin biçimlendirmesi uygulayarak hücrelerinin tutarlı olmasını sağlayın. Her hücreyi ayrı ayrı biçimlendirmeden, yazı tipi özelliklerini, paragraf biçimlendirmesini ve metin yönünü ayarlayabilirsiniz.

1. Sunumu [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) sınıfı ile yükleyin.
2. İlk slayttaki tabloya erişin.
3. İlk satır için [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) ile yazı tipi yüksekliğini ayarlayın.
4. İlk satır için [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) ve [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) ile hizalamayı ve sağ paragraf kenar boşluğunu ayarlayın.
5. İkinci satır için [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) ile metin yönünü ayarlayın.
6. Değiştirilen sunumu kaydedin.

Örnek, ilk slayttaki ilk şekil olarak bir tablo içeren ve en az iki satır bulunan `table.pptx` dosyasını gerektirir. İlk satıra 25 puanlık metin, sağ hizalama ve 20 puanlık sağ paragraf kenar boşluğu uygular, ardından ikinci satıra dikey metin ayarlar.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/PortionFormat.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <DOM/Table/IRow.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25);
table->get_Rows()->idx_get(0)->SetTextFormat(portionFormat);

auto paragraphFormat = MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20);
table->get_Rows()->idx_get(0)->SetTextFormat(paragraphFormat);

auto textFrameFormat = MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->get_Rows()->idx_get(1)->SetTextFormat(textFrameFormat);

presentation->Save(u"row_formatting.pptx", SaveFormat::Pptx);
```

## **Tablo Sütun Düzeyinde Metin Biçimlendirmesi Ayarla**

Tüm bir sütuna metin biçimlendirmesi uygulayarak hücrelerinin tutarlı olmasını sağlayın. Her hücreyi ayrı ayrı biçimlendirmeden, yazı tipi özelliklerini, paragraf biçimlendirmesini ve metin yönünü ayarlayabilirsiniz.

1. Sunumu [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) sınıfı ile yükleyin.
2. İlk slayttaki tabloya erişin.
3. İlk sütun için [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) ile yazı tipi yüksekliğini ayarlayın.
4. İlk sütun için [set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) ve [set_MarginRight](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginright/) ile hizalamayı ve sağ paragraf kenar boşluğunu ayarlayın.
5. İkinci sütun için [set_TextVerticalType](https://reference.aspose.com/slides/cpp/aspose.slides/textframeformat/set_textverticaltype/) ile metin yönünü ayarlayın.
6. Değiştirilen sunumu kaydedin.

Örnek, ilk slayttaki ilk şekil olarak bir tablo içeren ve en az iki sütun bulunan `table.pptx` dosyasını gerektirir. İlk sütuna 25 puanlık metin, sağ hizalama ve 20 puanlık sağ paragraf kenar boşluğu uygular, ardından ikinci sütuna dikey metin ayarlar.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/PortionFormat.h>
#include <DOM/ParagraphFormat.h>
#include <DOM/TextAlignment.h>
#include <DOM/TextFrameFormat.h>
#include <DOM/TextVerticalType.h>
#include <DOM/Table/IColumn.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"table.pptx");
auto slide = presentation->get_Slide(0);

auto table = ExplicitCast<ITable>(slide->get_Shape(0));

auto portionFormat = MakeObject<PortionFormat>();
portionFormat->set_FontHeight(25);
table->get_Columns()->idx_get(0)->SetTextFormat(portionFormat);

auto paragraphFormat = MakeObject<ParagraphFormat>();
paragraphFormat->set_Alignment(TextAlignment::Right);
paragraphFormat->set_MarginRight(20);
table->get_Columns()->idx_get(0)->SetTextFormat(paragraphFormat);

auto textFrameFormat = MakeObject<TextFrameFormat>();
textFrameFormat->set_TextVerticalType(TextVerticalType::Vertical);
table->get_Columns()->idx_get(1)->SetTextFormat(textFrameFormat);

presentation->Save(u"column_formatting.pptx", SaveFormat::Pptx);
```

## **Tablo Stil Özelliklerini Al**

[get_StylePreset](https://reference.aspose.com/slides/cpp/aspose.slides/itable/get_stylepreset/) metodunu kullanarak bir tabloya uygulanan ön ayarı alıp başka bir tabloda yeniden kullanın. Bu, bireysel hücre biçimlendirme geçersiz kılmalarından ziyade ön ayarı tanımlar.

Örnek bir tablo oluşturur, [TableStylePreset::DarkStyle1](https://reference.aspose.com/slides/cpp/aspose.slides/tablestylepreset/) uygular ve ön ayarı geri okur. `DarkStyle1` değerini yazdırır ve tabloyu `table.pptx` içinde kaydeder.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <DOM/TableStylePreset.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto columnWidths = MakeArray<double>({ 100, 150 });
auto rowHeights = MakeArray<double>({ 5, 5, 5 });
auto table = slide->get_Shapes()->AddTable(10, 10, columnWidths, rowHeights);
table->set_StylePreset(TableStylePreset::DarkStyle1);

Console::WriteLine(u"{0}", table->get_StylePreset());

presentation->Save(u"table.pptx", SaveFormat::Pptx);
```

## **SSS**

**Bir tabloya zaten oluşturulmuşken PowerPoint temalarını/ stillerini uygulayabilir miyim?**

Evet. Tablo, slayt/yerleşim/ana tema (master) teması miras alır ve yine de dolgu, kenarlık ve metin renklerini bu temanın üzerine geçersiz kılabilirsiniz.

**Tablo satırlarını Excel'deki gibi sıralayabilir miyim?**

Hayır, Aspose.Slides tabloları yerleşik sıralama veya filtreleme özelliğine sahip değildir. Verilerinizi önce bellekte sıralayın, ardından tablo satırlarını bu sırayla yeniden doldurun.

**Özel renkleri belirli hücrelerde tutarken bantlı (çizgili) sütunlar kullanabilir miyim?**

Evet. Bantlı sütunları etkinleştirin, ardından belirli hücreleri yerel biçimlendirme ile geçersiz kılın; hücre düzeyindeki biçimlendirme tablo stiline göre önceliklidir.