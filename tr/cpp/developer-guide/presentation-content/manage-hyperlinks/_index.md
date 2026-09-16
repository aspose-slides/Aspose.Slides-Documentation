---
title: C++'ta Sunum Hiperlinklerini Yönet
linktitle: Hiperlinkleri Yönet
type: docs
weight: 20
url: /tr/cpp/manage-hyperlinks/
keywords:
- URL ekle
- hiperlink ekle
- hiperlink oluştur
- hiperlink biçimlendir
- hiperlink kaldır
- hiperlink güncelle
- metin hiperlinki
- slayt hiperlinki
- şekil hiperlinki
- görsel hiperlinki
- video hiperlinki
- değiştirilebilir hiperlink
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ kullanarak C++ örnekleriyle PowerPoint ve OpenDocument sunumlarında hiperlinkleri ekleyin, biçimlendirin, güncelleyin ve kaldırın."
---
## **Giriş**

Bir hiperlink, sunum içeriğini bir web sitesine veya sunum içindeki bir konuma bağlar. PowerPoint'te hiperlinkler genellikle iki amaçla kullanılır:

* Metin, şekil veya medya çerçevesinden bir web sitesi açmak.
* Örneğin bir içindekiler tablosundan başka bir slayta gitmek.

Aspose.Slides for C++ size bu bağlantıları ekleme, görünüm ve seslerini kontrol etme, ayarlarını güncelleme ve kaldırma imkanı verir. Aşağıdaki örnekler, hiperlinklerle tekil öğelerde nasıl çalışılacağını ve sunum, slayt veya metin çerçevesi seviyesinde hiperlinklere nasıl erişileceğini gösterir.

{{% alert color="info" title="Note" %}}
Sunumları ayrıca [ücretsiz çevrimiçi Aspose PowerPoint düzenleyicisi](https://products.aspose.app/slides/tr/editor) ile düzenleyebilirsiniz.
{{% /alert %}} 

## **URL Hiperlinkleri Ekle**

Bir web sitesi URL'sini metne, şekle veya medya çerçevesine atayabilirsiniz. Hiperlinki atadığınız öğe, tıklanabilir alanı belirler: bir metin bölümü seçili metni bağlarken, bir şekil veya çerçeve slayt nesnesini bağlar.

### **Metne URL Hiperlinkleri Ekle**

Metni bir web sitesine bağlamak için bir [Hyperlink](https://reference.aspose.com/slides/tr/cpp/aspose.slides/hyperlink/) oluşturun ve metin bölümünün [set_HyperlinkClick](https://reference.aspose.com/slides/tr/cpp/aspose.slides/portionformat/set_hyperlinkclick/) yöntemiyle atayın, aşağıda gösterildiği gibi. Yalnızca o metin bölümü tıklanabilir olur.

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto textShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 600, 50, false);
textShape->AddTextFrame(u"Aspose: File Format APIs");
auto portionFormat = textShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
portionFormat->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
portionFormat->get_HyperlinkClick()->set_Tooltip(u"Explore Aspose file format APIs");
portionFormat->set_FontHeight(32);

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

### **Şekillere ve Medya Çerçevelerine URL Hiperlinkleri Ekle**

Bir şekli veya çerçeveyi tıklanabilir hâle getirmek için onun [set_HyperlinkClick](https://reference.aspose.com/slides/tr/cpp/aspose.slides/shape/set_hyperlinkclick/) yöntemini kullanın. Hiperlink, içindeki metin bölümüne değil, nesnenin kendisine aittir.

Aynı yaklaşım resim, ses ve video çerçevelerine de uygulanır: hiperlinki çerçeveye atayın ve gerekirse bir ipucu eklemek için [set_Tooltip](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ihyperlink/set_tooltip/) metodunu kullanın.

Aşağıdaki örnek bir dikdörtgeni tıklanabilir hâle getirir:

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 600, 50);

shape->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
shape->get_HyperlinkClick()->set_Tooltip(u"Explore Aspose file format APIs");

presentation->Save(u"presentation-out.pptx", SaveFormat::Pptx);
```

## **İçindekiler Tablosu Oluşturmak İçin Hiperlinkleri Kullanma**

İç bağlantılar, okuyucuların içindekiler tablosundan belirli bir slayta atlamasını sağlar. Aşağıdaki örnek, birinci slaydın “Page 2” metnini ikinci slayta bağlamak için [SetInternalHyperlinkClick](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) yöntemini kullanır.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);
auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto tableOfContents = firstSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40, 40, 300, 100);
tableOfContents->get_FillFormat()->set_FillType(FillType::NoFill);
tableOfContents->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
tableOfContents->get_TextFrame()->get_Paragraphs()->Clear();

auto paragraph = System::MakeObject<Paragraph>();
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
paragraph->set_Text(u"Title of slide 2 .......... ");

auto linkPortion = System::MakeObject<Portion>();
linkPortion->set_Text(u"Page 2");
linkPortion->get_PortionFormat()->get_HyperlinkManager()->SetInternalHyperlinkClick(secondSlide);

paragraph->get_Portions()->Add(linkPortion);
tableOfContents->get_TextFrame()->get_Paragraphs()->Add(paragraph);

presentation->Save(u"link_to_slide.pptx", SaveFormat::Pptx);
```

## **Hiperlinkleri Biçimlendirme**

### **Renk**

[IHyperlink](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ihyperlink/) üzerindeki [set_ColorSource](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ihyperlink/set_colorsource/) yöntemi, bir hiperlinkin sunumun hiperlink rengini mi yoksa metin bölümünün biçimini mi kullandığını belirler. Özel bir metin rengi uygulamak için [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/hyperlinkcolorsource/) seçin ve bölümün dolgu rengini ayarlayın. Bu özellik PowerPoint 2019'da tanıtıldı; eski sürümler bu ayarı uygulamaz.

Aşağıdaki örnek aynı slayta iki metin hiperlinki ekler. İlki kırmızı metin dolgu rengine sahiptir, ikincisi ise varsayılan hiperlink rengini korur.

```cpp
#include <DOM/FillType.h>
#include <DOM/Hyperlink.h>
#include <DOM/HyperlinkColorSource.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IHyperlink.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto coloredShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 450, 50, false);
coloredShape->AddTextFrame(u"This hyperlink uses a custom color.");
auto coloredPortionFormat = coloredShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
coloredPortionFormat->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));
coloredPortionFormat->get_HyperlinkClick()->set_ColorSource(HyperlinkColorSource::PortionFormat);
coloredPortionFormat->get_FillFormat()->set_FillType(FillType::Solid);
coloredPortionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Red());

auto defaultShape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 200, 450, 50, false);
defaultShape->AddTextFrame(u"This hyperlink uses the default color.");
defaultShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_HyperlinkClick(System::MakeObject<Hyperlink>(u"https://www.aspose.com/"));

presentation->Save(u"presentation-out-hyperlink.pptx", SaveFormat::Pptx);
```

### **Ses**

Bir hiperlink etkinleştirildiğinde ses oynatabilir veya zaten çalan bir sesi durdurabilir. Bu davranışları yapılandırmak için aşağıdaki yöntemleri kullanın:

* [IHyperlink::set_Sound](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ihyperlink/set_sound/) hiperlinke ilişkili ses dosyasını belirtir.
* [IHyperlink::set_StopSoundOnClick](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ihyperlink/set_stopsoundonclick/) hiperlink etkinleştirildiğinde önceki sesin durup durmayacağını kontrol eder.

#### **Bir Hiperlink Sesi Ekle**

Aşağıdaki örnek `sampleaudio.wav` dosyasını yükler ve birinci slayttaki bir düğmeye ilişkilendirir. Düğmeye tıklamak sesi çalar ve sonraki slayta gider. Aynı slayttaki ikinci bir şekil, tıklandığında önceki sesi durdurur; bu işlem bir gezinme eylemi yapmaz.

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/IAudio.h>
#include <DOM/IAudioCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto audioData = System::IO::File::ReadAllBytes(u"sampleaudio.wav");
auto hyperlinkSound = presentation->get_Audios()->AddAudio(audioData);

auto firstSlide = presentation->get_Slide(0);

auto playButton = firstSlide->get_Shapes()->AddAutoShape(ShapeType::SoundButton, 100, 100, 100, 50);
playButton->set_HyperlinkClick(Hyperlink::get_NextSlide());

if (!playButton->get_HyperlinkClick()->get_StopSoundOnClick() && playButton->get_HyperlinkClick()->get_Sound() == nullptr)
{
    playButton->get_HyperlinkClick()->set_Sound(hyperlinkSound);
}

auto secondSlide = presentation->get_Slides()->AddEmptySlide(firstSlide->get_LayoutSlide());

auto stopButton = secondSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 100, 50);
stopButton->set_HyperlinkClick(Hyperlink::get_NoAction());

stopButton->get_HyperlinkClick()->set_StopSoundOnClick(true);

presentation->Save(u"hyperlink-sound.pptx", SaveFormat::Pptx);
```

#### **Bir Hiperlink Sesini Çıkar**

Aşağıdaki örnek, yukarıda oluşturulan sunumu açar ve birinci şeklin hiperlink sesini [get_Sound](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ihyperlink/get_sound/) ve [get_BinaryData](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iaudio/get_binarydata/) yöntemleriyle belleğe okur.

```cpp
#include <DOM/IAudio.h>
#include <DOM/IHyperlink.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"hyperlink-sound.pptx");

if (presentation->get_Slides()->get_Count() > 0 && presentation->get_Slide(0)->get_Shapes()->get_Count() > 0)
{
    auto hyperlink = presentation->get_Slide(0)->get_Shape(0)->get_HyperlinkClick();
    auto sound = hyperlink != nullptr ? hyperlink->get_Sound() : nullptr;
    if (sound != nullptr)
    {
        auto audioData = sound->get_BinaryData();
        System::Console::WriteLine(u"Extracted {0} bytes of hyperlink audio.", audioData->get_Length());
    }
    else
    {
        System::Console::WriteLine(u"The first shape has no hyperlink sound.");
    }
}
else
{
    System::Console::WriteLine(u"The presentation has no first slide or shape to inspect.");
}
```

### **Araç İpucu ve Etkileşim Ayarları**

Metne veya şekle bir hiperlink atadıktan sonra aşağıdaki [IHyperlink](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ihyperlink/) ayarlarını bu yöntemlerle güncelleyebilirsiniz:

* [set_Tooltip](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ihyperlink/set_tooltip/) bağlantı için izleyicinin gösterebileceği ipucu metnini ayarlar.
* [set_TargetFrame](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ihyperlink/set_targetframe/) gerektiğinde bir üst HTML çerçeve kümesindeki hedef çerçeveyi belirtir.
* [set_History](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ihyperlink/set_history/) bağlantıyı etkinleştirirken hedefinin izlenen hiperlinkler listesine eklenip eklenmeyeceğini kontrol eder.
* [set_HighlightClick](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ihyperlink/set_highlightclick/) tıklandığında hiperlinkin vurgulanıp vurgulanmayacağını belirler.

## **Sunumlardan Hiperlinkleri Kaldırma**

[GetAnyHyperlinks](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) yöntemini kullanarak, değiştirmeden önce metin bölümü linkleri dahil hiperlink konteynerlerini toplayın. Aşağıdaki örnek ilk slayttan hem tıklama hem fare üzeri eylemlerini kaldırır. Yalnızca bir türü kaldırmak için sadece [RemoveHyperlinkClick](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) veya [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) çağırın; bir tıklama eylemini kaldırmak, fare üzeri eylemini kaldırmaz.

```cpp
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

if (presentation->get_Slides()->get_Count() > 0)
{
    auto containers = presentation->get_Slide(0)->get_HyperlinkQueries()->GetAnyHyperlinks();
    for (const auto& container : containers)
    {
        container->get_HyperlinkManager()->RemoveHyperlinkClick();
        container->get_HyperlinkManager()->RemoveHyperlinkMouseOver();
    }
    presentation->Save(u"pres-removed-hyperlinks.pptx", SaveFormat::Pptx);
}
else
{
    System::Console::WriteLine(u"The presentation has no slides to process.");
}
```

Koşulsuz kaldırma için, [RemoveAllHyperlinks](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) seçilen kapsamda iki eylemi de tek bir çağrıyla kaldırır. Seçimli temizlik ve ana şablonlar, yerleşimler ve notlar için bkz. [Raporla, Temizle ve Hiperlinkleri Doğrula](#report-sanitize-and-verify-hyperlinks).

## **Tam Bir Hiperlink Envanteri Oluşturma**

Bir sunumu dağıtmadan önce, etkileşimli eylemlerini ve web linklerini envantere alın. [GetAnyHyperlinks](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) [IHyperlinkContainer](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ihyperlinkcontainer/) nesnelerini döndürür; URL dizelerinin düz bir listesini değil. Her konteynerde hem [get_HyperlinkClick](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkclick/) hem de [get_HyperlinkMouseOver](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmouseover/) yöntemlerini inceleyin. Bunlar bağımsızdır: aynı konteyner her iki eylemi de gösterebilir, bu yüzden tam bir rapor konteyner başına iki satır gerektirebilir.

Sadece şekil seviyesindeki hiperlinkleri taramak, metin bölümlerine eklenmiş linkleri kaçırabilir. Bunun yerine uygun kapsamı sorgulayın ve döndürülen konteynerleri saklayın; böylece daha sonra eylemlerini güncelleyebilir veya kaldırabilirsiniz.

### **Sunum, Slayt ve Metin Çerçevesi Kapsamlarını Sorgulama**

[IHyperlinkQueries](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ihyperlinkqueries/) arabirimi, [IPresentation::get_HyperlinkQueries](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ipresentation/get_hyperlinkqueries/), [IBaseSlide::get_HyperlinkQueries](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibaseslide/get_hyperlinkqueries/) ve [ITextFrame::get_HyperlinkQueries](https://reference.aspose.com/slides/tr/cpp/aspose.slides/itextframe/get_hyperlinkqueries/) aracılığıyla kullanılabilir. Her kapsam aynı sorguları destekler:

* [GetHyperlinkClicks](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) tıklama eylemi olan konteynerleri döndürür.
* [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) fare üzeri eylemi olan konteynerleri döndürür.
* [GetAnyHyperlinks](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) bir veya iki eylemi olan konteynerleri döndürür.

Aşağıdaki örnek, dış bir tıklama linki, dosya fare üzeri linki, iç slayt navigasyonu, metin fare üzeri linki ve makro eylemi içeren `hyperlink-audit-input.pptx` dosyasını oluşturur. Bu eylemlerden hiçbiri çalıştırılmaz. Aynı üç sorgu her kapsamda çalışır; sayılar konteyner sayısını, eylem toplamını değil, gösterir. Metin çerçevesi kapsamı, içinde bulunduğu şeklin kendi linklerini dışarı tutar.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlink.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
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
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto printCounts = [](System::String scope, System::SharedPtr<IHyperlinkQueries> queries)
{
    auto clickContainers = queries->GetHyperlinkClicks();
    auto mouseOverContainers = queries->GetHyperlinkMouseOvers();
    auto allContainers = queries->GetAnyHyperlinks();
    System::Console::WriteLine(u"{0}: click={1}, mouse-over={2}, any={3}", scope, clickContainers->get_Count(), mouseOverContainers->get_Count(), allContainers->get_Count());
};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto destination = presentation->get_Slides()->AddEmptySlide(slide->get_LayoutSlide());
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
shape->get_TextFrame()->set_Text(u"Click the text to go to slide 2");
shape->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://example.com/");
shape->get_HyperlinkClick()->set_Tooltip(u"Public website");
shape->get_HyperlinkManager()->SetExternalHyperlinkMouseOver(u"file:///C:/private/report.xlsx");

auto portionFormat = shape->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat();
portionFormat->get_HyperlinkManager()->SetInternalHyperlinkClick(destination);
portionFormat->get_HyperlinkManager()->SetExternalHyperlinkMouseOver(u"https://example.com/help");
auto macroButton = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20, 120, 200, 60);
macroButton->get_HyperlinkManager()->SetMacroHyperlinkClick(u"ReviewPresentation");

printCounts(u"Presentation", presentation->get_HyperlinkQueries());
printCounts(u"Slide 1", slide->get_HyperlinkQueries());
printCounts(u"Text frame", shape->get_TextFrame()->get_HyperlinkQueries());
presentation->Save(u"hyperlink-audit-input.pptx", SaveFormat::Pptx);
```

Bu örnek için, sunum ve slayt sorguları her biri üç tıklama konteyneri, iki fare üzeri konteyneri ve bir eylemi olan üç konteyner raporlar. Metin çerçevesi sorgusu ise her kategoride bir konteyner rapor eder.

### **Eylemleri ve Hedefleri Sınıflandırma**

[IHyperlink::get_ActionType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ihyperlink/get_actiontype/) yöntemini kullanarak bir eylemi yorumlamadan önce hedefini yorumlayın. [HyperlinkActionType](https://reference.aspose.com/slides/tr/cpp/aspose.slides/hyperlinkactiontype/) değerleri web navigasyonunun ötesini kapsar:

| Değerler | Denetim için Anlamı |
| --- | --- |
| `Hyperlink` | Harici hiperlink; URL ve şemasını inceleyin. |
| `JumpSpecificSlide` | Belirli bir slayta iç navigasyon. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Dahili slayt gösterisi navigasyonu, slayt gösterisi bağlamında çözülür. |
| `JumpEndShow`, `StartCustomSlideShow` | Mevcut gösteriyi sonlandırır veya özel bir gösteri başlatır. |
| `StartMacro` | Bir makroyu çalıştırır. |
| `StartProgram` | Bir program başlatır. |
| `OpenFile`, `OpenPresentation` | Bir dosya veya başka bir sunumu açar; web URL'lerinden ayrı incelenir. |
| `StartStopMedia` | Medya oynatımını başlatır veya durdurur. |
| `NoAction`, `Unknown` | Navigasyon eylemi yoktur veya gözden geçirme gerektiren tanınmayan bir eylem. |

Harici hedefleri [get_ExternalUrl](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ihyperlink/get_externalurl/) yöntemiyle, belirli iç hedefleri ise [get_TargetSlide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ihyperlink/get_targetslide/) ile okuyun. İç eylemler ve yerleşik komutlar harici URL içermeyebilir; boş bir URL konteynerin eylemi olmadığı anlamına gelmez. Normalleştirilmiş URL'den farklı olduğunda [get_ExternalUrlOriginal](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ihyperlink/get_externalurloriginal/) koruyun ve mevcut olduğunda [get_Tooltip](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ihyperlink/get_tooltip/) tarafından döndürülen araç ipucunu ekleyin.

### **Raporla, Temizle ve Hiperlinkleri Doğrula**

Aşağıdaki C++ örneği mevcut bir sunumu okur (yukarıda oluşturulan dosyayı kullanın), `hyperlink-audit.json` yazar, bir politika uygular, `hyperlink-sanitized.pptx` dosyasını kaydeder ve her iki etkinleştirme türünü tekrar kontrol etmek için yeniden açar. Değiştirmeden önce konteynerleri toplar ve aynı konteyneri iki kez işlememek için işaretçi kimliğini kullanır. Sunum sorguları normal slaytları kapsar; paket çapında bir envanter için, ayrıca ana şablonlar, yerleşimler, notlar ve mevcut olduğunda not ve el ilanı ana şablonlarını açıkça sorgular.

Rapor, mevcut olduğunda bir‑bazlı slayt indeksini ve [get_SlideId](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ibaseslide/get_slideid/) değerini kaydeder. [ISlideComponent::get_Slide](https://reference.aspose.com/slides/tr/cpp/aspose.slides/islidecomponent/get_slide/) desteklenen konteynerler için sahip slaytı sağlar. Ana şablonlar, yerleşimler ve notların normal bir slayt indeksi yoktur ve kapsamlarıyla tanımlanırlar. Şekil konteynerleri ve metin‑bölüm biçimlendirme konteynerleri ayrı ayrı etiketlenir; diğer konteyner tipleri çalışma zamanı tip adlarını korur. Her konteyner rapor‑yerel bir kimlik alır, böylece iki eylemi ilişkilendirilebilir.

Bu kasıtlı olarak kısıtlayıcı uygulama politikası yalnızca mutlak HTTPS URL'lerini ve geçerli iç slayt hedeflerini kabul eder. Makroları, programları, dosya eylemlerini, diğer slayt gösterisi eylemlerini, bilinmeyen eylemleri ve diğer URL şemalarını reddeder. Bu reddetmeler politika kararlarıdır, Aspose.Slides güvenlik kararları değildir. HTTPS tek başına güven sağlamaz: uygulamanız için ana bilgisayar izin listeleri ve diğer kontroller ekleyin. Hem orijinal hem de normalleştirilmiş harici URL'ler kontrol edilir. Örnek, bağlantıları takip etmeden veya eylemleri çalıştırmadan meta verileri denetler.

İyileştirme için, konteynerin [get_HyperlinkManager](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmanager/) [SetExternalHyperlinkClick](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) ve [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) yöntemlerini destekler. Burada, yasaklanmış harici tıklama linkleri sabit bir HTTPS açılış sayfası ile değiştirilir; diğer yasak tıklamalar ve yasak fare üzeri eylemler bağımsız olarak kaldırılır. Tüm politika ihlallerini kaldırmak için `replaceExternalClicks` değerini `false` olarak ayarlayın. Dağıtımdan önce uygulamaya ait bir değiştirme sayfası seçin.

Raporun dışa aktarma bayrağı, temkinli bir PDF inceleme politikası kullanır: fare üzeri eylemleri ve harici link veya belirli slayt atlaması dışındaki her şeyi potansiyel olarak desteklenmeyen olarak işaretler. Bu bir inceleme ipucu olup, yetenek testi ya da işaretlenmemiş linklerin dışa aktarımda kalacağı garantisi değildir. Desteklenen [PDF](/slides/tr/cpp/convert-powerpoint-to-pdf/) ve [HTML](/slides/tr/cpp/convert-powerpoint-to-html/) dışa aktarmaları, eyleme, dışa aktarma seçeneklerine ve görüntüleyiciye bağlı olarak hiperlinkleri koruyabilir. Raster [görseller](/slides/tr/cpp/convert-powerpoint-to-png/) ve [video](/slides/tr/cpp/convert-powerpoint-to-video/) interaktif hiperlinkleri koruyamaz; bu çıktılar için denetleme yaparken her eylemi işaretleyin.

```cpp
#include <DOM/Hyperlink.h>
#include <DOM/HyperlinkActionType.h>
#include <DOM/IBaseSlide.h>
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IHyperlink.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IHyperlinkQueries.h>
#include <DOM/IHyperlinkContainer.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterHandoutSlide.h>
#include <DOM/IMasterHandoutSlideManager.h>
#include <DOM/IMasterNotesSlide.h>
#include <DOM/IMasterNotesSlideManager.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/INotesSlide.h>
#include <DOM/INotesSlideManager.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPresentation.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideComponent.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/uri.h>
#include <system/environment.h>
#include <fstream>
#include <sstream>
#include <iomanip>
#include <vector>
#include <unordered_set>
#include <system/collections/ilist.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const auto replaceExternalClicks = true;
const System::String replacementUrl = u"https://example.com/blocked-link";
auto presentation = System::MakeObject<Presentation>(u"hyperlink-audit-input.pptx");

auto collectContainers = [](System::SharedPtr<IPresentation> source)
{
    std::vector<System::SharedPtr<IHyperlinkContainer>> found;
    std::unordered_set<IHyperlinkContainer*> seen;
    auto addQueries = [&](System::SharedPtr<IHyperlinkQueries> queries)
    {
        auto containers = queries->GetAnyHyperlinks();
        for (const auto& container : containers)
        {
            if (seen.insert(container.get()).second) found.push_back(container);
        }
    };
    auto addScope = [&](System::SharedPtr<IBaseSlide> slide)
    {
        if (slide != nullptr) addQueries(slide->get_HyperlinkQueries());
    };
    addQueries(source->get_HyperlinkQueries());
    for (const auto& master : source->get_Masters()) addScope(master);
    for (const auto& layout : source->get_LayoutSlides()) addScope(layout);
    for (const auto& slide : source->get_Slides()) addScope(slide->get_NotesSlideManager()->get_NotesSlide());
    addScope(source->get_MasterNotesSlideManager()->get_MasterNotesSlide());
    addScope(source->get_MasterHandoutSlideManager()->get_MasterHandoutSlide());
    return found;
};

auto isHttps = [](System::String value)
{
    System::SharedPtr<System::Uri> uri;
    return System::Uri::TryCreate(value, System::UriKind::Absolute, uri) && uri->get_Scheme() == System::Uri::UriSchemeHttps;
};
auto policyViolation = [&](System::SharedPtr<IHyperlink> link) -> System::String
{
    if (link == nullptr) return u"";
    if (link->get_ActionType() == HyperlinkActionType::JumpSpecificSlide)
    {
        return link->get_TargetSlide() == nullptr ? u"Missing target slide" : u"";
    }
    if (link->get_ActionType() != HyperlinkActionType::Hyperlink) return u"Action is not allowed";
    if (!isHttps(link->get_ExternalUrl())) return u"Normalized URL is not absolute HTTPS";
    auto original = link->get_ExternalUrlOriginal();
    if (!original.IsNullOrEmpty() && !isHttps(original)) return u"Original URL is not absolute HTTPS";
    return u"";
};
auto slideIndex = [&](System::SharedPtr<IBaseSlide> slide)
{
    for (auto index = 0; index < presentation->get_Slides()->get_Count(); index++)
    {
        if (presentation->get_Slide(index) == slide) return index + 1;
    }
    return 0;
};
auto jsonString = [](System::String value)
{
    std::ostringstream escaped;
    escaped << '"';
    for (unsigned char character : value.ToUtf8String())
    {
        if (character == '"' || character == '\\') escaped << '\\' << character;
        else if (character < 0x20) escaped << "\\u" << std::hex << std::setw(4) << std::setfill('0') << static_cast<int>(character);
        else escaped << character;
    }
    escaped << '"';
    return escaped.str();
};
auto containers = collectContainers(presentation);
std::ofstream report("hyperlink-audit.json", std::ios::binary);
if (!report)
{
    System::Console::WriteLine(u"Cannot open the audit report for writing.");
    System::Environment::set_ExitCode(1);
    return;
}
auto rowCount = 0;
report << "[\n";
auto addRow = [&](System::SharedPtr<IHyperlink> link, System::String activation, System::SharedPtr<IHyperlinkContainer> container, size_t containerId)
{
    if (link == nullptr) return;
    auto component = System::AsCast<ISlideComponent>(container);
    auto ownerSlide = component != nullptr ? component->get_Slide() : nullptr;
    auto targetSlide = link->get_TargetSlide();
    auto violation = policyViolation(link);
    auto shape = System::AsCast<IShape>(container);
    auto portionFormat = System::AsCast<IPortionFormat>(container);
    auto ownerType = shape != nullptr ? System::String(u"Shape") : portionFormat != nullptr ? System::String(u"Text portion") : container->GetType().get_Name();
    auto ordinaryAction = link->get_ActionType() == HyperlinkActionType::Hyperlink || link->get_ActionType() == HyperlinkActionType::JumpSpecificSlide;
    auto ownerIndex = slideIndex(ownerSlide);
    auto targetIndex = slideIndex(targetSlide);
    if (rowCount++ != 0) report << ",\n";
    report << "  {\"ContainerId\":" << containerId;
    report << ",\"SlideIndex\":" << (ownerIndex != 0 ? std::to_string(ownerIndex) : "null");
    report << ",\"SlideId\":" << (ownerSlide != nullptr ? std::to_string(ownerSlide->get_SlideId()) : "null");
    report << ",\"Scope\":" << (ownerSlide != nullptr ? jsonString(ownerSlide->GetType().get_Name()) : "null");
    report << ",\"OwnerType\":" << jsonString(ownerType);
    report << ",\"Activation\":" << jsonString(activation);
    report << ",\"ActionType\":" << jsonString(System::ObjectExt::ToString(link->get_ActionType()));
    report << ",\"ExternalUrl\":" << jsonString(link->get_ExternalUrl());
    report << ",\"TargetSlideIndex\":" << (targetIndex != 0 ? std::to_string(targetIndex) : "null");
    report << ",\"TargetSlideId\":" << (targetSlide != nullptr ? std::to_string(targetSlide->get_SlideId()) : "null");
    report << ",\"Tooltip\":" << jsonString(link->get_Tooltip());
    report << ",\"OriginalExternalUrl\":" << (link->get_ExternalUrlOriginal() != link->get_ExternalUrl() ? jsonString(link->get_ExternalUrlOriginal()) : "null");
    report << ",\"PotentiallyUnsafe\":" << (!violation.IsNullOrEmpty() ? "true" : "false");
    report << ",\"PolicyViolation\":" << (!violation.IsNullOrEmpty() ? jsonString(violation) : "null");
    report << ",\"TargetExport\":\"PDF\",\"PotentiallyUnsupportedByExport\":" << (activation == u"mouse-over" || !ordinaryAction ? "true" : "false") << "}";
};
for (auto index = size_t{0}; index < containers.size(); index++)
{
    auto container = containers[index];
    addRow(container->get_HyperlinkClick(), u"click", container, index + 1);
    addRow(container->get_HyperlinkMouseOver(), u"mouse-over", container, index + 1);
}
report << "\n]\n";
report.close();
if (!report)
{
    System::Console::WriteLine(u"The audit report could not be written completely.");
    System::Environment::set_ExitCode(1);
    return;
}

for (const auto& container : containers)
{
    auto click = container->get_HyperlinkClick();
    if (!policyViolation(click).IsNullOrEmpty())
    {
        if (replaceExternalClicks && click->get_ActionType() == HyperlinkActionType::Hyperlink)
        {
            container->get_HyperlinkManager()->SetExternalHyperlinkClick(replacementUrl);
        }
        else
        {
            container->get_HyperlinkManager()->RemoveHyperlinkClick();
        }
    }
    if (!policyViolation(container->get_HyperlinkMouseOver()).IsNullOrEmpty())
    {
        container->get_HyperlinkManager()->RemoveHyperlinkMouseOver();
    }
}
presentation->Save(u"hyperlink-sanitized.pptx", SaveFormat::Pptx);
auto reopened = System::MakeObject<Presentation>(u"hyperlink-sanitized.pptx");
auto remainingContainers = collectContainers(reopened);
auto violations = 0;
for (const auto& container : remainingContainers)
{
    if (!policyViolation(container->get_HyperlinkClick()).IsNullOrEmpty()) violations++;
    if (!policyViolation(container->get_HyperlinkMouseOver()).IsNullOrEmpty()) violations++;
}
System::Console::WriteLine(u"Audit rows: {0}; prohibited actions after reopening: {1}", rowCount, violations);
if (violations != 0)
{
    System::Console::WriteLine(u"Verification failed: do not distribute the saved presentation.");
    System::Environment::set_ExitCode(1);
}
```

Yukarıda oluşturulan girdi ile rapor beş eylem satırı içerir. Dosya fare üzeri linki ve makro tıklaması kaldırılır, HTTPS linkleri ve iç slayt navigasyonu kalır. Doğrulama, sıfır yasak eylem yazdırır. Yasak bir harici tıklama URL'si içeren bir girdi, değiştirme dalını da çalıştırır. İzin verilen bir tıklama ve yasak bir fare üzeri içeren bir konteyner tıklama eylemini korur.

Bu seçmeli temizlik, politika göz önünde bulundurulmadan seçilen kapsamda iki etkinleştirme türünü de kaldıran [RemoveAllHyperlinks](https://reference.aspose.com/slides/tr/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) yönteminden farklıdır. Buradaki doğrulama yalnızca hiperlink eylemlerini kontrol eder; gömülü VBA projelerini, OLE nesnelerini veya diğer aktif içeriği kaldırmaz ve dışa aktarılan bir PDF veya HTML dosyasını doğrulamaz.

## **SSS**

**Bir bölüme veya onun ilk slaytına nasıl bağlanabilirim?**

PowerPoint'te bölümler slaytları gruplar, ancak iç hiperlink tek bir slaytı hedef alır. Bir bölüme navigasyon oluşturmak için, o bölümün ilk slaytına bağlayın.

**Tüm slaytlarda çalışması için ana slayt öğelerine bir hiperlink ekleyebilir miyim?**

Evet. Ana slayt ve yerleşim öğeleri hiperlinkleri destekler. Bu öğeler üzerindeki linkler, ilgili ana slaytı veya yerleşimi kullanan slayt gösterisi sırasında kullanılabilir.

**PDF, HTML, görseller veya video olarak dışa aktarırken hiperlinkler korunur mu?**

Desteklenen PDF ve HTML dışa aktarmaları hiperlinkleri koruyabilir; raster görseller ve video bunu yapamaz. Dışa aktarma hususları için [Raporla, Temizle ve Hiperlinkleri Doğrula](#report-sanitize-and-verify-hyperlinks) bölümüne bakın.