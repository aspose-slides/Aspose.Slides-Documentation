---
title: C++ ile Sunumlarda Metin Kutularını Yönetme
linktitle: Metin Kutusunu Yönet
type: docs
weight: 20
url: /tr/cpp/manage-textbox/
keywords:
- metin kutusu
- metin çerçevesi
- metin ekle
- metni güncelle
- metin kutusu oluştur
- metin kutusunu kontrol et
- metin sütunu ekle
- bağlantı ekle
- PowerPoint
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ kullanarak PowerPoint ve OpenDocument sunumlarında metin kutularını oluşturma, tanımlama, biçimlendirme ve güncelleme."
---
## **Giriş**

Aspose.Slides for C++'de slayt metni, şekillere ait metin çerçevelerinde saklanır. [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) arabirimi en yaygın metin içeren şekli temsil eder ve metnine [IAutoShape::get_TextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/get_textframe/) yöntemi aracılığıyla erişim sağlar.

{{% alert color="info" title="Note" %}}
Her otomatik şekil [IShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/) uygular, ancak her şekil bir otomatik şekil değildir ve bir metin çerçevesi desteklemez. Mevcut bir sunumu işlerken, bir şeklin metnine erişmeden önce [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) uygulayıp uygulamadığını kontrol edin.
{{% /alert %}}

## **Slayta Metin Kutusu Oluşturma**

Bir metin kutusu oluşturmak için bir slayta otomatik bir şekil ekleyin, metin çerçevesine metin ekleyin ve sunumu kaydedin. Aşağıdaki örnek dikdörtgen bir metin kutusu oluşturur:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 300, 50);
textBox->AddTextFrame(u"Aspose TextBox");

presentation->Save(u"TextBox.pptx", SaveFormat::Pptx);
```

[IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishapecollection/addautoshape/) yöntemine geçirilen koordinat ve boyutlar puan (point) cinsindendir. [IAutoShape::AddTextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/addtextframe/) metin çerçevesini verilen metinle başlatır.

## **Metin Kutusu Şekli İçin Kontrol**

Bir otomatik şeklin metin kutusu olarak değerlendirilip değerlendirilmediğini belirlemek için [IAutoShape::get_IsTextBox](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/get_istextbox/) yöntemini kullanın. Bu, bir sunumun hem metin içeren hem de yalnızca grafiksel otomatik şekiller içerdiği durumlarda yararlıdır.

![Bir metin kutusu ve bir şekil](istextbox.png)

Aşağıdaki örnek bir sunumdaki tüm otomatik şekilleri inceler:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 120, 40);
textBox->AddTextFrame(u"Text box");
slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 150, 10, 40, 40);

for (const auto& currentSlide : IterateOver(presentation->get_Slides()))
{
    for (const auto& shape : IterateOver(currentSlide->get_Shapes()))
    {
        auto autoShape = AsCast<IAutoShape>(shape);
        if (autoShape != nullptr)
        {
            Console::WriteLine(autoShape->get_IsTextBox() ? u"The shape is a text box." : u"The shape is not a text box.");
        }
    }
}
```

Yeni eklenen bir otomatik şekil, boş olmayan metin içermediği sürece metin kutusu olarak kabul edilmez. Bu metni [IAutoShape::AddTextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/addtextframe/) veya [ITextFrame::set_Text](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/set_text/) aracılığıyla sağlayabilirsiniz. Boş bir dize eklemek veya atamak, [IAutoShape::get_IsTextBox](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/get_istextbox/) metodunun `false` döndürmesine neden olur:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
shape1->AddTextFrame(u"Shape 1");
Console::WriteLine(shape1->get_IsTextBox());

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 70, 100, 40);
shape2->get_TextFrame()->set_Text(u"Shape 2");
Console::WriteLine(shape2->get_IsTextBox());

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 130, 100, 40);
shape3->AddTextFrame(u"");
Console::WriteLine(shape3->get_IsTextBox());

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 190, 100, 40);
shape4->get_TextFrame()->set_Text(u"");
Console::WriteLine(shape4->get_IsTextBox());
```

İlk iki kontrol `true`, son iki kontrol `false` döndürür.

## **Bir Metin Çerçevesine Sahip Şekli Bulma**

Genel metin işleme kodu, hangi sunum nesnesinin bir [ITextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/) içerdiğini bilmeden bu çerçeveyi alabilir. Sahibi olan [IShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ishape/) üzerine geri dönmek için [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/get_parentshape/) metodunu kullanın.

Bir metin çerçevesi otomatik bir şekil ya da başka bir metin içeren şekil tarafından sahiplenildiğinde, [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/get_parentshape/) sahibi döndürür ve [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/get_parentcell/) `nullptr` döndürür. Her iki yöntem de yalnızca okunabilir gezinme sağlar. Erişmeden önce döndürülen değerin `nullptr` olup olmadığını kontrol edin. Şekil ve tablo hücresi sahiplerini, SmartArt düğümleriyle ilişkili şekilleri de dahil olmak üzere tanımlamak için [Search and Replace Text](/slides/tr/cpp/search-and-replace-text/) bölümüne bakın.

## **Metin Kutusuna Sütun Ekleme**

[ITextFrameFormat::set_ColumnCount](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframeformat/set_columncount/) yöntemi, metin çerçevesini sütunlara böler, [ITextFrameFormat::set_ColumnSpacing](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframeformat/set_columnspacing/) ise sütunlar arasındaki boşluğu puan cinsinden ayarlar. Her iki yöntem de [ITextFrameFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframeformat/) sınıfına aittir ve mevcut bir metin kutusunun metin çerçevesi üzerinden çağırılabilir. Metin, aynı şekil içinde sütunlar arasında yeniden akar; başka bir şekle geçmez.

Aşağıdaki örnek üç sütunlu bir metin kutusu oluşturur, sütunlar arası 10 puan boşluk bırakır, sunumu kaydeder ve ayarları çıktı dosyasından geri okur:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 200);
textBox->AddTextFrame(u"This text is distributed automatically across all columns in the text box.");

auto textFrameFormat = textBox->get_TextFrame()->get_TextFrameFormat();
textFrameFormat->set_ColumnCount(3);
textFrameFormat->set_ColumnSpacing(10);

presentation->Save(u"TextBoxColumns.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"TextBoxColumns.pptx");
auto savedTextBox = ExplicitCast<IAutoShape>(savedPresentation->get_Slide(0)->get_Shape(0));
auto savedFormat = savedTextBox->get_TextFrame()->get_TextFrameFormat();
Console::WriteLine(u"Columns: {0}; spacing: {1} points", savedFormat->get_ColumnCount(), savedFormat->get_ColumnSpacing());
```

## **Bireysel Sütunlardan Metin Çıkarma**

Mevcut bir metin çerçevesindeki her görsel sütuna atanmış metni almak için [ITextFrame::SplitTextByColumns](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/splittextbycolumns/) yöntemi kullanılabilir. Yöntem, sütun tabanlı okuma sırasına göre her sütun için bir dize döndürür. Tek sütunlu bir metin çerçevesi bir elemanlı bir dizi üretir ve boş bir sütun boş bir dizeyle temsil edilir. Dize yalnızca düz metin içerir; bölüm seviyesindeki biçimlendirme korunmaz.

Bu yöntem aşağıdaki durumlarda faydalıdır:

- Metni sütun tabanlı okuma sırasını koruyarak çıkarmak.
- Çok sütunlu slaytların içeriğini indekslemek veya karşılaştırmak.
- Her sütunu ayrı bir dosyaya, veritabanı alanına veya başka bir hedefe aktarmak.
- [ITextFrameFormat::set_ColumnCount](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframeformat/set_columncount/) veya [ITextFrameFormat::set_ColumnSpacing](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframeformat/set_columnspacing/) ayarları, yazı tipi ya da metin çerçevesi boyutu değiştirildiğinde metnin nasıl yeniden dağıtıldığını incelemek.

Yöntem, mevcut [ITextFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/) içinde dağıtılan metni raporlar; ayrı şekiller ya da metin kutuları arasında otomatik akış gerçekleşmez. Sütun dağılımı, kullanılabilir yazı tipleri ve diğer metin yerleşim ayarlarına bağlıdır; tutarlı sonuçlar gerektiğinde gerekli yazı tiplerinin mevcut olduğundan emin olun.

Aşağıdaki örnek bir sunumu yükler, ilk slayttaki çok sütunlu ilk otomatik şekli bulur, yapılandırılmış sütun sayısını okur ve her sütundan metni ayrı bir dosyaya yazar. Metin çerçevesi sağlamayan şekiller atlanır.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"MultiColumnText.pptx");

SharedPtr<IAutoShape> textBox = nullptr;
for (const auto& shape : IterateOver(presentation->get_Slide(0)->get_Shapes()))
{
    auto autoShape = AsCast<IAutoShape>(shape);
    if (autoShape != nullptr && autoShape->get_TextFrame() != nullptr)
    {
        auto columnCount = autoShape->get_TextFrame()->get_TextFrameFormat()->get_ColumnCount();
        if (columnCount > 1)
        {
            textBox = autoShape;
            break;
        }
    }
}

if (textBox == nullptr)
{
    Console::WriteLine(u"No multi-column text frame was found.");
}
else
{
    auto textFrame = textBox->get_TextFrame();
    auto configuredColumnCount = textFrame->get_TextFrameFormat()->get_ColumnCount();
    auto columnTexts = textFrame->SplitTextByColumns();

    Console::WriteLine(u"Configured columns: {0}", configuredColumnCount);

    for (auto columnIndex = 0; columnIndex < columnTexts->get_Length(); columnIndex++)
    {
        auto columnNumber = columnIndex + 1;
        auto columnText = columnTexts->idx_get(columnIndex);
        Console::WriteLine(u"Column {0}: {1}", columnNumber, columnText);
        auto fileName = String::Format(u"Column-{0}.txt", columnNumber);
        File::WriteAllText(fileName, columnText);
    }
}
```

## **Metni Güncelleme**

Bir sunumdaki metni güncellemek için slaytlar ve şekiller üzerinden döngü oluşturun, otomatik şekilleri seçin ve metin bölümlerini düzenleyin. Bölüm seviyesinde çalışmak, hem metni hem de karakter biçimlendirmesini değiştirme imkanı verir.

Aşağıdaki örnek, otomatik şekil metin bölümlerinde `years` ifadesinin her geçişini `months` ile değiştirir ve etkilenen her bölümü kalın yapar:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Text.pptx");

for (const auto& slide : IterateOver(presentation->get_Slides()))
{
    for (const auto& shape : IterateOver(slide->get_Shapes()))
    {
        auto autoShape = AsCast<IAutoShape>(shape);
        if (autoShape == nullptr || autoShape->get_TextFrame() == nullptr)
        {
            continue;
        }

        for (const auto& paragraph : IterateOver(autoShape->get_TextFrame()->get_Paragraphs()))
        {
            for (const auto& portion : IterateOver(paragraph->get_Portions()))
            {
                auto text = portion->get_Text();
                if (!String::IsNullOrEmpty(text) && text.Contains(u"years"))
                {
                    portion->set_Text(text.Replace(u"years", u"months"));
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

presentation->Save(u"TextChanged.pptx", SaveFormat::Pptx);
```

Bu gezinme yalnızca otomatik şekillerdeki metni günceller. Tablolarda, grafiklerde, SmartArt'ta veya gruplanmış şekillerde saklanan metin, ilgili nesnelerin kendi koleksiyonları üzerinden gezilerek güncellenmelidir.

## **Bağlantılı Bir Metin Kutusu Ekleme**

Bir hiperlink, belirli bir metin bölümüne atanabilir; böylece yalnızca o metin tıklanabilir bir bağlantı olur. Bölümü dış URL ile ilişkilendirmek için [IHyperlinkManager::SetExternalHyperlinkClick](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) kullanın.

Aşağıdaki örnek, bağlantılı metin oluşturur ve bir sunuma kaydeder:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 200, 50);
textBox->AddTextFrame(u"Aspose.Slides");

auto textPortion = textBox->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
textPortion->get_PortionFormat()->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://www.aspose.com/");

presentation->Save(u"Hyperlink.pptx", SaveFormat::Pptx);
```

## **SSS**

**Bir ana ya da yerleşim slaytındaki metin kutusu ile metin yer tutucusu arasındaki fark nedir?**

Bir [placeholder](/slides/tr/cpp/manage-placeholder/) konumunu ve biçimini bir [master slide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/masterslide/) ya da [layout slide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/layoutslide/) üzerinden devralabilir. Normal bir metin kutusu, oluşturulduğu slaytta bağımsız bir şekildir ve yerleşim değiştiğinde yer tutucu davranışı kazanmaz.

**Grafik, tablo veya SmartArt'taki metni değiştirmeden metni nasıl değiştirebilirim?**

Metni güncelleme örneğinde gösterildiği gibi, döngüyü yalnızca [IAutoShape](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iautoshape/) uygulayan şekillerle sınırlayın. Grafikler, tablolar ve SmartArt, kendi nesne modellerinde metin tutar; bu döngüyle değiştirilmezler.