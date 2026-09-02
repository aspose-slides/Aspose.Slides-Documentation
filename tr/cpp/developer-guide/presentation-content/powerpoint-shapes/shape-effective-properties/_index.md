---
title: C++'ta Sunumlardan Şekil Etkin Özelliklerini Al
linktitle: Etkin Özellikler
type: docs
weight: 50
url: /tr/cpp/shape-effective-properties/
keywords:
- şekil özellikleri
- kamera özellikleri
- ışık düzeni
- kavisli şekil
- metin çerçevesi
- metin stili
- yazı tipi yüksekliği
- dolgu biçimi
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "PowerPoint sunumlarında yerel, kalıtılmış ve etkin şekil biçimlendirmesini ayırt etmek için Aspose.Slides for C++'ı nasıl kullanacağınızı öğrenin."
---
## **Yerel, Kalıtılmış ve Etkin Özellikleri Anlamak**

PowerPoint biçimlendirmesi birkaç kaynaktan gelebilir. Bir nesneye doğrudan kaydedilen değer **yerel değerdir**. Bu değer ayarlanmamışsa, PowerPoint bir paragraf varsayılanı, metin stili, düzen veya ana slayt, tema veya sunum düzeyindeki varsayılanlar gibi üst format kaynaklarına bakar. Bu değerler **kalıtılmış değerler**dir. Tüm hiyerarşi çözüldükten sonra kalan değer **etkin değerdir**—nesneyi renderlamak için kullanılan değer.

Örneğin, bir metin bölümü kendi yazı tipi yüksekliğini tanımlamıyor olabilir. Yerel [yazı tipi yüksekliği](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibaseportionformat/) değeri `std::numeric_limits<float>::quiet_NaN()` olur, bu da "burada ayarlanmamış" anlamına gelir. Bölüm, yüksekliği paragrafından, sunumun varsayılan metin stilinden veya başka bir uygulanabilir kaynaktan kalıtabilir. Bölüm formatında [GetEffective](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iportionformat/) çağrısı, son çözülen yüksekliği döndürür.

Farklı amaçlar için iki tür formatlama verisini kullanın:

- Bir değerin nerede tanımlandığını kontrol etmeniz gerektiğinde, [IPortionFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iportionformat/) gibi yerel bir format nesnesini okuyun veya değiştirin.
- Son, renderlanmış sonucu gerektiğinde, [IPortionFormatEffectiveData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iportionformateffectivedata/) gibi bir etkin veri nesnesini okuyun. Etkin veri yalnızca okuma içindir.

## **Yerel, Kalıtılmış ve Etkin Değerleri Karşılaştırma**

Aşağıdaki tam örnek bir şekil oluşturur ve sunum, paragraf ve bölüm seviyelerinde yazı tipi yüksekliklerini uygular. Her adım, bu seviyelerde tanımlanan değerleri ve aynı metin bölümü için ortaya çıkan etkin değeri yazdırır. Ayrıca formatlama değişikliklerinden sonra etkin verinin yeniden okunması gerektiğini gösterir.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextStyle.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <cmath>
#include <limits>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 500.0f, 80.0f, false);
auto textFrame = shape->AddTextFrame(u"Effective formatting");
auto paragraph = textFrame->get_Paragraph(0);
auto portion = paragraph->get_Portion(0);

// İki farklı seviyede kalıtılmış değerleri tanımla.
presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->set_FontHeight(20.0f);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(28.0f);

auto formatLocalValue = [](float value) -> System::String
{
    return std::isnan(value) ? System::String(u"<not set>") : System::ObjectExt::ToString(value);
};

auto printFontHeights = [&](System::String caption)
{
    auto presentationValue = presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->get_FontHeight();
    auto paragraphValue = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FontHeight();
    auto localValue = portion->get_PortionFormat()->get_FontHeight();

    // Önceki değişikliklerden sonra etkin verileri oku.
    auto effectiveValue = portion->get_PortionFormat()->GetEffective()->get_FontHeight();

    System::Console::WriteLine(caption);
    System::Console::WriteLine(System::String(u"  Presentation default: ") + formatLocalValue(presentationValue));
    System::Console::WriteLine(System::String(u"  Paragraph default:    ") + formatLocalValue(paragraphValue));
    System::Console::WriteLine(System::String(u"  Portion local:        ") + formatLocalValue(localValue));
    System::Console::WriteLine(System::String(u"  Portion effective:    ") + effectiveValue);
};

printFontHeights(u"The portion inherits from the paragraph");

// Bölümdeki yerel değer, iki kalıtılmış değerin üzerine yazar.
portion->get_PortionFormat()->set_FontHeight(36.0f);
printFontHeights(u"A local value overrides inherited values");

// Kalıtılmış bir değeri değiştirmek, mevcut bir yerel değerin üzerine yazmaz.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(30.0f);
printFontHeights(u"The local value still has priority");

// Yerel değeri temizle. Bölüm şimdi tekrar paragraftan kalıtım alır.
portion->get_PortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The local value is cleared");

// Paragraf değerini temizle. Sunum varsayılanı artık sonucu sağlar.
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(std::numeric_limits<float>::quiet_NaN());
printFontHeights(u"The paragraph value is cleared");

presentation->Save(u"effective-properties.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Bu örnekte öncelik bölüm yerel formatlaması, ardından paragraf formatlaması ve son olarak sunum varsayılanıdır. Diğer nesneler farklı kalıtım zincirlerine sahip olabilir, ancak prensip aynıdır: daha belirgin açık bir değer kazanır ve [GetEffective](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iportionformat/) son sonucu döndürür.

## **Etkin Metin Özelliklerini Al**

Metin biçimlendirmesi birkaç nesne arasında bölünür:

- [ITextFrameFormat::GetEffective](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframeformat/) kenar boşlukları, yerleşim, otomatik sığdırma ve dikey metin yönü gibi metin çerçevesi özelliklerini çözer.
- [ITextStyle::GetEffective](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextstyle/) her metin stili seviyesindeki paragraf biçimlendirmesini çözer.
- [IParagraphFormat::GetEffective](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/) hizalama, girinti ve madde işaretleri gibi paragraf özelliklerini çözer.
- [IPortionFormat::GetEffective](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iportionformat/) yazı tipi yüksekliği, tipografi, renk, kalın ve italik gibi karakter özelliklerini çözer.

Sonraki örnek için `text-formatting.pptx` en az bir slayt ve boş olmayan bir metin çerçevesi içeren bir [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) içermelidir. IAutoShape, şekil koleksiyonunda herhangi bir konumda görünebilir; kod uygun bir nesne arar ve kullanmadan önce doğrular.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ITextStyle.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"text-formatting.pptx");

if (presentation->get_Slides()->get_Count() == 0)
    throw System::InvalidOperationException(u"The presentation contains no slides.");

auto slide = presentation->get_Slide(0);
System::SharedPtr<IAutoShape> shape;

for (int shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
{
    auto candidate = slide->get_Shapes()->idx_get(shapeIndex);

    if (!System::ObjectExt::Is<IAutoShape>(candidate))
        continue;

    auto autoShape = System::ExplicitCast<IAutoShape>(candidate);
    auto candidateTextFrame = autoShape->get_TextFrame();

    if (candidateTextFrame == nullptr || candidateTextFrame->get_Paragraphs()->get_Count() == 0)
        continue;

    if (candidateTextFrame->get_Paragraph(0)->get_Portions()->get_Count() == 0)
        continue;

    shape = autoShape;
    break;
}

if (shape == nullptr)
    throw System::InvalidOperationException(u"The first slide must contain an IAutoShape with non-empty text.");

auto textFrame = shape->get_TextFrame();
auto paragraph = textFrame->get_Paragraph(0);
auto portion = paragraph->get_Portion(0);

auto textFrameEffective = textFrame->get_TextFrameFormat()->GetEffective();
auto paragraphEffective = paragraph->get_ParagraphFormat()->GetEffective();
auto portionEffective = portion->get_PortionFormat()->GetEffective();

System::Console::WriteLine(u"Text frame margins:");
System::Console::WriteLine(System::String(u"  Left: ") + textFrameEffective->get_MarginLeft());
System::Console::WriteLine(System::String(u"  Top: ") + textFrameEffective->get_MarginTop());
System::Console::WriteLine(System::String(u"  Right: ") + textFrameEffective->get_MarginRight());
System::Console::WriteLine(System::String(u"  Bottom: ") + textFrameEffective->get_MarginBottom());
System::Console::WriteLine(System::String(u"Paragraph alignment: ") + System::ObjectExt::ToString(paragraphEffective->get_Alignment()));
System::Console::WriteLine(System::String(u"Font height: ") + portionEffective->get_FontHeight());
System::Console::WriteLine(System::String(u"Bold: ") + System::ObjectExt::ToString(portionEffective->get_FontBold()));

auto effectiveTextStyle = textFrame->get_TextFrameFormat()->get_TextStyle()->GetEffective();
for (int level = 0; level < 9; ++level)
{
    auto levelEffective = effectiveTextStyle->GetLevel(level);
    System::Console::WriteLine(System::String(u"Level ") + level + u" indent: " + levelEffective->get_Indent());
}

presentation->Dispose();
```

## **Etkin 3B Özellikleri Al**

[IThreeDFormat::GetEffective](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformat/) tüm çözülen 3B ayarları gruplayan bir [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ithreedformateffectivedata/) nesnesi döndürür. Bunun [camera](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icameraeffectivedata/), [light rig](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ilightrigeffectivedata/), [top bevel](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapebeveleffectivedata/) ve [bottom bevel](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapebeveleffectivedata/) verileri ilgili etkin ayarları gösterir. Bu ilişkili ayarları birlikte okumak, bir şeklin son 3B görünümünü anlamayı kolaylaştırır.

Bu örnek için `shape-3d.pptx` ilk slaytında en az bir şekil içermelidir. Çıktının varsayılanların dışında değerler içermesini istiyorsanız, o şekle 3B kamera, aydınlatma veya köşe ayarları uygulayın.

```cpp
#include <DOM/ICameraEffectiveData.h>
#include <DOM/ILightRigEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeBevelEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"shape-3d.pptx");

if (presentation->get_Slides()->get_Count() == 0 || presentation->get_Slide(0)->get_Shapes()->get_Count() == 0)
    throw System::InvalidOperationException(u"The first slide must contain a shape.");

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto threeDEffective = shape->get_ThreeDFormat()->GetEffective();

System::Console::WriteLine(u"Camera:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_Camera()->get_CameraType()));
System::Console::WriteLine(System::String(u"  Field of view: ") + threeDEffective->get_Camera()->get_FieldOfViewAngle());
System::Console::WriteLine(System::String(u"  Zoom: ") + threeDEffective->get_Camera()->get_Zoom());

System::Console::WriteLine(u"Light rig:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_LightRig()->get_LightType()));
System::Console::WriteLine(System::String(u"  Direction: ") + System::ObjectExt::ToString(threeDEffective->get_LightRig()->get_Direction()));

System::Console::WriteLine(u"Top bevel:");
System::Console::WriteLine(System::String(u"  Type: ") + System::ObjectExt::ToString(threeDEffective->get_BevelTop()->get_BevelType()));
System::Console::WriteLine(System::String(u"  Width: ") + threeDEffective->get_BevelTop()->get_Width());
System::Console::WriteLine(System::String(u"  Height: ") + threeDEffective->get_BevelTop()->get_Height());

presentation->Dispose();
```

## **Etkin Tablo Biçimlendirmesini Al**

Tablo biçimlendirmesi tablo stilinden ve tüm tablo, bir sütun, bir satır veya bireysel bir hücreye uygulanan formatlardan gelebilir. Açıkça tanımlanmış doldurmalar arasında çakışma varsa öncelik hücre, satır, sütun ve ardından tüm tablo şeklindedir. Bir hücrenin etkin formatı, o hücreyi çizerken kullanılan son formattır.

Bu örnek için `table-formatting.pptx` ilk slaytında en az bir tablo içermelidir. Tablo en az bir satır ve bir sütun içermelidir. Kod, ilk şeklin bir tablo olduğu varsayımı yerine bir [ITable](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itable/) arar.

```cpp
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/Table/IColumnFormat.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/IRowFormat.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ITableFormat.h>
#include <system/console.h>
#include <system/exceptions.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"table-formatting.pptx");

if (presentation->get_Slides()->get_Count() == 0)
    throw System::InvalidOperationException(u"The presentation contains no slides.");

auto slide = presentation->get_Slide(0);
System::SharedPtr<ITable> table;

for (int shapeIndex = 0; shapeIndex < slide->get_Shapes()->get_Count(); ++shapeIndex)
{
    auto candidate = slide->get_Shapes()->idx_get(shapeIndex);

    if (System::ObjectExt::Is<ITable>(candidate))
    {
        table = System::ExplicitCast<ITable>(candidate);
        break;
    }
}

if (table == nullptr)
    throw System::InvalidOperationException(u"The first slide must contain a table.");

if (table->get_Rows()->get_Count() == 0 || table->get_Columns()->get_Count() == 0)
    throw System::InvalidOperationException(u"The table must contain at least one cell.");

auto tableEffective = table->get_TableFormat()->GetEffective();
auto rowEffective = table->get_Row(0)->get_RowFormat()->GetEffective();
auto columnEffective = table->get_Column(0)->get_ColumnFormat()->GetEffective();
auto cellEffective = table->idx_get(0, 0)->get_CellFormat()->GetEffective();

System::Console::WriteLine(System::String(u"Table fill: ") + System::ObjectExt::ToString(tableEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Row fill: ") + System::ObjectExt::ToString(rowEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Column fill: ") + System::ObjectExt::ToString(columnEffective->get_FillFormat()->get_FillType()));
System::Console::WriteLine(System::String(u"Final cell fill: ") + System::ObjectExt::ToString(cellEffective->get_FillFormat()->get_FillType()));

presentation->Dispose();
```

Renk yalnızca doldurma türünden daha fazlaysa, önce etkin [FillType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifillformateffectivedata/) kontrol edin ve ardından o türe ait özelliği okuyun—örneğin katı bir doldurma için [SolidFillColor](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ifillformateffectivedata/).

## **Değişikliklerden Sonra Etkin Veriyi Yeniden Okuma**

Etkin veri, çözüldüğü zamandaki formatlama hiyerarşisini açıklar. Hiyerarşiye katılabilecek herhangi bir şeyi (nesnenin yerel formatlaması, paragraf veya metin‑çerçeve varsayılanları, bir tablo stili, tablo, sütun, satır veya hücre formatı, düzen veya ana slayt formatlaması, tema verileri veya sunum‑düzeyi varsayılanları, bir slayta atanan düzen veya ana) değiştirdikten sonra `GetEffective` çağrısını tekrar yapın.

Etkin veri nesnesini kalıcı bir anlık görüntü olarak tutmayın. Aspose.Slides bazı etkin verileri içsel olarak önbellekleyebilir ve daha sonraki bir `GetEffective` çağrısı bu verileri yenileyebilir. Bir değişiklik öncesi ve sonrası değerleri karşılaştırmanız gerekiyorsa, değişikliği yapmadan önce ihtiyaç duyduğunuz ölçekli değerleri—örneğin yazı tipi yüksekliği, renk, hizalama veya köşe genişliği—kendi değişkenlerinize kopyalayın.

Bir değeri değiştirmek için ilgili yerel format nesnesini güncelleyin ve ardından sonucu doğrulamak için `GetEffective` çağırın. Etkin veri nesneleri kendileri yalnızca okuma içindir.

## **FAQ**

**Bir etkin değeri hangi seviyenin sağladığını nasıl anlayabilirim?**  
Etkin veri, kaynağını değil son değeri içerir. En spesifik seviyeden dışa doğru uygulanabilir yerel nesneleri inceleyin. Metin için bu, bölüm, paragraf, metin çerçevesi, düzen, ana, tema ve sunum varsayılanlarını içerebilir. `std::numeric_limits<float>::quiet_NaN()` veya `nullptr` gibi tanımsız değerler, aramanın başka bir seviyeye devam ettiğini gösterir.

**Hiçbir seviye bir özelliği tanımlamadığında ne olur?**  
Aspose.Slides uygun PowerPoint veya kütüphane varsayılanını çözer. Bu çözülen değer, yerel bir nesne açıkça tanımlamasa bile etkin veride görünür.

**Neden bir etkin değer bazen yerel değerle aynı olur?**  
Yerel değer, kalıtım hesaplamasını kazanmıştır. Bu, özelliğin nesne üzerinde açıkça ayarlandığı ve daha spesifik bir kuralın onu geçersiz kılmadığı durumlarda beklenir.

**Yerel veriyi ne zaman etkin veri yerine kullanmalıyım?**  
Belirli bir formatlama seviyesini incelemek veya düzenlemek için yerel veriyi kullanın. Kalıtım, tema kuralları ve uygulanabilir stiller çözüldükten sonra son görünümü gerektiğinde etkin veriyi kullanın. [Tam karşılaştırma örneği](#compare-local-inherited-and-effective-values) her iki durumu da aynı iş akışında gösterir.