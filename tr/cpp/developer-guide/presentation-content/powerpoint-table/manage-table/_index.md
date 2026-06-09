---
title: C++ ile Sunum Tablolarını Yönetme
linktitle: Tabloyu Yönet
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
description: "Aspose.Slides for C++ ile PowerPoint slaytlarında tablolar oluşturun ve düzenleyin. Tablo iş akışlarınızı basitleştirecek basit kod örneklerini keşfedin."
---
## **Giriş**

PowerPoint'teki bir tablo, bilgiyi görüntülemenin ve sunmanın verimli bir yoludur. Hücrelerden oluşan bir ızgara (satır ve sütunlara düzenlenmiş) içindeki bilgi açıktır ve anlaşılması kolaydır.

Aspose.Slides, [Table](https://reference.aspose.com/slides/tr/cpp/aspose.slides/table/) sınıfını, [ITable](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itable/) arayüzünü, [Cell](https://reference.aspose.com/slides/tr/cpp/aspose.slides/cell/) sınıfını, [ICell](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icell/) arayüzünü ve diğer tipleri sağlar; böylece her türlü sunumda tablolar oluşturabilir, güncelleyebilir ve yönetebilirsiniz.

## **Baştan Bir Tablo Oluşturma**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Slaytın referansını indeksine göre alın.  
3. `columnWidth` dizisini tanımlayın.  
4. `rowHeight` dizisini tanımlayın.  
5. Slayta, [AddTable()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/addtable/) yöntemiyle bir [ITable](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itable/) nesnesi ekleyin.  
6. Her bir [ICell](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icell/) üzerinde dolaşarak üst, alt, sağ ve sol kenarlara biçimlendirme uygulayın.  
7. Tablonun ilk satırındaki ilk iki hücreyi birleştirin.  
8. Bir [ICell](https://reference.aspose.com/slides/tr/cpp/aspose.slides/icell/)'in [TextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/textframe/) öğesine erişin.  
9. [TextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/textframe/)'e bazı metinler ekleyin.  
10. Değiştirilen sunumu kaydedin.

Bu C++ kodu, bir sunumda tablo oluşturmanın nasıl yapılacağını gösterir:

```c++
// PPTX dosyasını temsil eden Presentation sınıfının bir örneğini oluşturur
auto pres = System::MakeObject<Presentation>();

// İlk slayta erişir
auto sld = pres->get_Slides()->idx_get(0);

// Genişlikleri olan sütunları ve yükseklikleri olan satırları tanımlar
auto dblCols = System::MakeArray<double>({ 50, 50, 50 });
auto dblRows = System::MakeArray<double>({ 50, 30, 30, 30, 30 });

// Slayta bir tablo şekli ekler
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

// Birleştirilmiş hücreye bazı metinler ekler
tbl->get_Rows()->idx_get(0)->idx_get(0)->get_TextFrame()->set_Text(u"Merged Cells");

// Sunumu diske kaydeder
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Standart Bir Tablo’da Numaralandırma**

Standart bir tabloda hücrelerin numaralandırması basit ve sıfır tabanlıdır. Bir tablodaki ilk hücre 0,0 (sütun 0, satır 0) olarak indekslenir.

Örneğin, 4 sütun ve 4 satır içeren bir tablodaki hücreler şu şekilde numaralandırılır:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Bu C++ kodu, bir tabloda hücrelerin numaralandırmasını nasıl belirleyeceğinizi gösterir:

```c++
// PPTX dosyasını temsil eden Presentation sınıfının bir örneğini oluşturur
auto pres = System::MakeObject<Presentation>();

// İlk slayta erişir
auto sld = pres->get_Slides()->idx_get(0);

// Genişlikleri olan sütunları ve yükseklikleri olan satırları tanımlar
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

## **Mevcut Bir Tabloya Erişme**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Tabloyu içeren slayta, indeksine göre bir referans alın.  
3. Bir [ITable](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itable/) nesnesi oluşturun ve null olarak ayarlayın.  
4. Tablo bulunana kadar tüm [IShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/) nesneleri üzerinde dolaşın.  

   Eğer üzerinde çalıştığınız slaydın tek bir tablo içerdiğini düşünüyorsanız, içinde bulunan tüm şekilleri kontrol edebilirsiniz. Bir şekil tablo olarak tanımlandığında, onu bir [Table](https://reference.aspose.com/slides/tr/cpp/aspose.slides/table/) nesnesine tip dönüştürebilirsiniz. Ancak slayt birden fazla tablo içeriyorsa, ihtiyaç duyduğunuz tabloyu [set_AlternativeText()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/set_alternativetext/) yöntemiyle aramanız daha iyi olur.  
5. [ITable](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itable/) nesnesini tabloyla çalışmak için kullanın. Aşağıdaki örnekte tabloya yeni bir satır ekledik.  
6. Değiştirilen sunumu kaydedin.

Bu C++ kodu, mevcut bir tabloya nasıl erişileceğini ve onunla nasıl çalışılacağını gösterir:

```c++
// PPTX dosyasını temsil eden Presentation sınıfının bir örneğini oluşturur
auto pres = System::MakeObject<Presentation>(u"UpdateExistingTable.pptx");

// İlk slayta erişir
auto sld = pres->get_Slides()->idx_get(0);

// null Tabloyu başlatır
System::SharedPtr<ITable> tbl;

// Şekiller üzerinde dolaşır ve bulunan tabloya bir referans ayarlar
for (const auto& shp : System::IterateOver(sld->get_Shapes()))
{
    if (System::ObjectExt::Is<ITable>(shp))
    {
        tbl = System::ExplicitCast<ITable>(shp);
    }
}

// İkinci satırın birinci sütunu için metni ayarlar
tbl->idx_get(0, 1)->get_TextFrame()->set_Text(u"New");

// Değiştirilen sunumu diske kaydeder
pres->Save(u"table1_out.pptx", SaveFormat::Pptx);
```

## **Bir Tablo İçinde Metni Hizalama**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Slaytın referansını indeksine göre alın.  
3. Slayta bir [ITable](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itable/) nesnesi ekleyin.  
4. Tablodan bir [ITextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/) nesnesine erişin.  
5. [ITextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/) içindeki [IParagraph](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraph/) öğesine erişin.  
6. Metni dikey olarak hizalayın.  
7. Değiştirilen sunumu kaydedin.

Bu C++ kodu, bir tablo içinde metni nasıl hizalayacağınızı gösterir:

```c++
// Presentation sınıfının bir örneğini oluşturur
auto presentation = System::MakeObject<Presentation>();

// İlk slaytı alır
auto slide = presentation->get_Slides()->idx_get(0);

// Genişlikleri olan sütunları ve yükseklikleri olan satırları tanımlar
auto dblCols = System::MakeArray<double>({ 120, 120, 120, 120 });
auto dblRows = System::MakeArray<double>({ 100, 100, 100, 100 });

// Tablo şeklini slayta ekler
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

## **Tablo Düzeyinde Metin Biçimlendirme Ayarlama**

1. Bir [Presentation](https://reference.aspose.com/slides/tr/cpp/aspose.slides/presentation/) sınıfının bir örneğini oluşturun.  
2. Slaytın referansını indeksine göre alın.  
3. Slayttan bir [ITable](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itable/) nesnesine erişin.  
4. Metin için [set_FontHeight()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/baseportionformat/set_fontheight/) değerini ayarlayın.  
5. [set_Alignment()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/set_alignment/) ve [set_MarginRight()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iparagraphformat/set_marginright/) değerlerini ayarlayın.  
6. [set_TextVerticalType()](https://reference.aspose.com/slides/tr/cpp/aspose.slides/textframeformat/set_textverticaltype/) değerini ayarlayın.  
7. Değiştirilen sunumu kaydedin.

Bu C++ kodu, bir tablodaki metne tercih ettiğiniz biçimlendirme seçeneklerini nasıl uygulayacağınızı gösterir:

```c++
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

## **Tablo Stil Özelliklerini Almak**

Aspose.Slides, bir tablonun stil özelliklerini almanıza olanak tanır, böylece bu ayrıntıları başka bir tablo ya da başka bir yerde kullanabilirsiniz. Bu C++ kodu, bir tablo önceden ayarlanmış stilinden stil özelliklerini nasıl alacağınızı gösterir:

```c++
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slide(0)->get_Shapes();
auto table = System::ExplicitCast<ITable>(shapes->AddTable(10, 10, System::MakeArray<double>({100, 150}), System::MakeArray<double>({5, 5, 5})));

table->set_StylePreset(TableStylePreset::DarkStyle1);
pres->Save(u"table.pptx", SaveFormat::Pptx);
```

## **Bir Tablonun En-Boy Oranını Kilitleme**

Geometrik bir şeklin en‑boy oranı, farklı boyutlardaki ölçülerinin oranıdır. Aspose.Slides, tablolar ve diğer şekiller için en‑boy oranı ayarını kilitlemenizi sağlayan `AspectRatioLocked()` özelliğini sunar.

Bu C++ kodu, bir tablo için en‑boy oranını nasıl kilitleyeceğinizi gösterir:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto table = System::ExplicitCast<ITable>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());


table->get_GraphicalObjectLock()->set_AspectRatioLocked(!table->get_GraphicalObjectLock()->get_AspectRatioLocked());

Console::WriteLine(u"Lock aspect ratio set: {0}", table->get_GraphicalObjectLock()->get_AspectRatioLocked());

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **SSS**

**Bir tablonun tamamı ve hücrelerindeki metin için sağdan sola (RTL) okuma yönünü etkinleştirebilir miyim?**

Evet. Tablo, bir [set_RightToLeft](https://reference.aspose.com/slides/tr/cpp/aspose.slides/table/set_righttoleft/) yöntemi sunar ve paragraflar [ParagraphFormat::set_RightToLeft](https://reference.aspose.com/slides/tr/cpp/aspose.slides/paragraphformat/set_righttoleft/) yöntemine sahiptir. Her ikisinin birlikte kullanılması, hücre içindeki doğru RTL sırasını ve renderlamayı sağlar.

**Kullanıcıların final dosyasında bir tabloyu taşımalarını veya yeniden boyutlandırmalarını nasıl engelleyebilirim?**

[shape locks](/slides/tr/cpp/applying-protection-to-presentation/) kullanarak taşıma, yeniden boyutlandırma, seçim vb. işlevleri devre dışı bırakabilirsiniz. Bu kilitler tabloya da uygulanır.

**Bir hücrenin içinde arka plan olarak bir resim eklemek destekleniyor mu?**

Evet. Bir hücre için [picture fill](https://reference.aspose.com/slides/tr/cpp/aspose.slides/picturefillformat/) ayarlayabilirsiniz; seçilen moda (germe veya döşeme) göre resim hücre alanını kaplar.