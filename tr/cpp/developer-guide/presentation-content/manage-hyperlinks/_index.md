---
title: C++'ta Sunum Köprülerini Yönetme
linktitle: Köprüleri Yönet
type: docs
weight: 20
url: /tr/cpp/manage-hyperlinks/
keywords:
- URL ekle
- köprü ekle
- köprü oluştur
- köprü biçimlendir
- köprü kaldır
- köprü güncelle
- metin köprüsü
- slayt köprüsü
- şekil köprüsü
- resim köprüsü
- video köprüsü
- değiştirilebilir köprü
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ kullanarak, PowerPoint ve OpenDocument sunumlarında köprüleri ekleyin, biçimlendirin, güncelleyin ve kaldırın; C++ örnekleriyle."
---
## **Giriş**

Bir köprü, sunum içeriğini bir web sitesine veya sunum içinde bir konuma bağlar. PowerPoint'te köprüler genellikle iki amaçla kullanılır:

* Metin, şekil veya bir medya çerçevesinden bir web sitesini açar.
* Bir içindekiler tablosu gibi bir yerden başka bir slayta geçiş yapar.

Aspose.Slides for C++ bu bağlantıları eklemenizi, görünüm ve seslerini kontrol etmenizi, ayarlarını güncellemenizi ve kaldırmanızı sağlar. Aşağıdaki örnekler, tekil öğeler üzerindeki köprülerle nasıl çalışılacağını ve köprülere sunum, slayt veya metin çerçevesi seviyesinde nasıl erişileceğini gösterir.

{{% alert color="info" title="Note" %}}
Sunumları ayrıca [ücretsiz çevrimiçi Aspose PowerPoint düzenleyicisi](https://products.aspose.app/slides/editor) ile düzenleyebilirsiniz.
{{% /alert %}} 

## **URL Köprüleri Ekleme**

Bir web sitesi URL'sini metne, şekle veya bir medya çerçevesine atayabilirsiniz. Köprüyü atadığınız öğe tıklanabilir alanı belirler: bir metin bölümü seçili metni bağlarken, bir şekil veya çerçeve slayt nesnesini bağlar.

Göreli köprüler içeren sunumlar için, belge‑seviyesi temeli okumak, değiştirmek veya temizlemek amacıyla [Köprü Temelini Yönet](/slides/tr/cpp/presentation-properties/#manage-the-hyperlink-base) bölümüne bakın.

### **Metne URL Köprüsü Ekleme**

Metni bir web sitesine bağlamak için bir [Hyperlink](https://reference.aspose.com/slides/cpp/aspose.slides/hyperlink/) oluşturun ve metin bölümünün [set_HyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/set_hyperlinkclick/) yöntemiyle atayın, aşağıda gösterildiği gibi. Yalnızca o metin bölümü tıklanabilir olur.

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

### **Şekillere ve Medya Çerçevelerine URL Köprüsü Ekleme**

Bir şekli veya çerçeveyi tıklanabilir hale getirmek için onun [set_HyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_hyperlinkclick/) yöntemini kullanın. Köprü, içinde metin bölümü bulunmasından ziyade nesnenin kendisine aittir.

Aynı yaklaşım resim, ses ve video çerçevelerine de uygulanır: köprüyü çerçeveye atayın ve gerekirse bir ipucu eklemek için [set_Tooltip](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_tooltip/) yöntemini kullanın.

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

## **İçindekiler Tablosu Oluşturmak İçin Köprüleri Kullanma**

İç köprüler, okuyucuların bir içindekiler tablosundan belirli bir slayta atlamasını sağlar. Aşağıdaki örnek, “Page 2” metnini ilk slayttan ikinci slayta bağlamak için [SetInternalHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) yöntemini kullanır.

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

## **Köprüleri Biçimlendirme**

### **Renk**

[IHyperlink](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/) arayüzünün [set_ColorSource](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_colorsource/) yöntemi, köprünün sunumun köprü rengine mi yoksa metin bölümünün biçimlendirmesine mi göre renklendirileceğini belirler. Özel bir metin rengi uygulamak için [HyperlinkColorSource::PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/hyperlinkcolorsource/) seçilerek bölümün doldurma rengi ayarlanır. Bu özellik PowerPoint 2019’da tanıtıldı; eski sürümler bu ayarı uygulamaz.

Aşağıdaki örnek aynı slayta iki metin köprüsü ekler. İlki kırmızı metin doldurması kullanırken, ikincisi varsayılan köprü rengini korur.

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

Bir köprü etkinleştirildiğinde bir ses çalabilir veya hâlihazırda çalan bir sesi durdurabilir. Bu davranışları yapılandırmak için aşağıdaki yöntemleri kullanın:

- [IHyperlink::set_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_sound/) köprüye ilişkin ses dosyasını belirtir.
- [IHyperlink::set_StopSoundOnClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_stopsoundonclick/) köprünün etkinleştirilmesinin önceki sesi durdurup durdurmayacağını kontrol eder.

#### **Köprüye Ses Ekleme**

Aşağıdaki örnek `sampleaudio.wav` dosyasını yükler ve ilk slayttaki bir düğmeye atar. Düğmeye tıklanması sesi çalar ve bir sonraki slayta geçiş yapar. Aynı slayttaki ikinci bir şekil, tıklandığında önceki sesi durdurur; ancak bir gezinme eylemi gerçekleştirmez.

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

#### **Köprü Sesini Çıkarma**

Aşağıdaki örnek yukarıda oluşturulan sunumu açar ve ilk şeklin köprü sesini [get_Sound](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_sound/) ve [get_BinaryData](https://reference.aspose.com/slides/cpp/aspose.slides/iaudio/get_binarydata/) aracılığıyla belleğe okur.

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

Bir köprüye metin kısmı veya şekil atandıktan sonra aşağıdaki [IHyperlink](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/) ayarlarını bu yöntemlerle güncelleyebilirsiniz:

- [set_Tooltip](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_tooltip/) izleyicinin bağlantı için bir ipucu olarak görüntüleyebileceği metni ayarlar.
- [set_TargetFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_targetframe/) uygulanabilir olduğunda, bir üst HTML çerçeve kümesi içinde hedef çerçeveyi belirtir.
- [set_History](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_history/) bağlantının etkinleştirilmesinin, görüntülenen köprüler listesine eklenip eklenmeyeceğini kontrol eder.
- [set_HighlightClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/set_highlightclick/) bağlantının tıklandığında vurgulanıp vurgulanmayacağını kontrol eder.

## **Sunumlardan Köprüleri Kaldırma**

[GetAnyHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) yöntemini kullanarak, değiştirmeden önce metin‑bölümü köprülerini de içeren köprü konteynerlerini toplayın. Aşağıdaki örnek ilk slayttan her iki etkinleştirme türünü de kaldırır. Yalnızca bir türü kaldırmak için yalnızca [RemoveHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) veya [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) yöntemini çağırın; bir tıklama eylemini kaldırmak, fare‑üzerinde eylemi kaldırmaz.

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

Koşulsuz kaldırma için, [RemoveAllHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) seçilen kapsamda her iki etkinleştirme türünü tek bir çağrıda siler. Seçici temizlik ve ana, yerleşim ve notlar kapsayıcılığını içerir; detaylar için [Köprüleri Raporlama, Temizleme ve Doğrulama](#report-sanitize-and-verify-hyperlinks) bölümüne bakın.

## **Tam Bir Köprü Envanteri Oluşturma**

Bir sunumu dağıtmadan önce, etkileşimli eylemlerini ve web bağlantılarını envantere alın. [GetAnyHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) [IHyperlinkContainer](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkcontainer/) nesnelerini döndürür, düz URL listesi değil. Her konteynerde hem [get_HyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkclick/) hem de [get_HyperlinkMouseOver](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmouseover/) incelenmelidir. Bunlar bağımsızdır: aynı konteyner iki eylemi de sunabilir; bu nedenle tam bir rapor, her konteyner için iki satır gerektirebilir.

Sadece şekil‑seviyesi köprüleri taramak, metin bölümü bağlantılarını kaçırabilir. Bunun yerine uygun kapsamı sorgulayın ve dönen konteynerleri saklayarak daha sonra eylemlerini güncelleyebilir veya kaldırabilirsiniz.

### **Sunum, Slayt ve Metin‑Çerçeve Kapsamlarını Sorgulama**

[IHyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/) arayüzüne [IPresentation::get_HyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_hyperlinkqueries/), [IBaseSlide::get_HyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_hyperlinkqueries/) ve [ITextFrame::get_HyperlinkQueries](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_hyperlinkqueries/) üzerinden erişilir. Her kapsam aynı sorguları destekler:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) tıklama eylemi olan kapsayıcıları döndürür.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) fare‑üzerinde eylemi olan kapsayıcıları döndürür.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) her iki eylemi de ya da birini içeren kapsayıcıları döndürür.

Aşağıdaki örnek, dış tıklama bağlantısı, dosya fare‑üzerinde bağlantısı, iç slayt geçişi, metin fare‑üzerinde bağlantısı ve bir makro eylemi içeren `hyperlink-audit-input.pptx` oluşturur. Bu eylemler çalıştırılmaz. Aynı üç sorgu her kapsamda aynı şekilde çalışır; sayılar konteyner sayısını gösterir, eylem toplamını değil. Metin‑çerçeve kapsamı, içinde bulunduğu şeklin kendi bağlantılarını dışarıda bırakır.

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

Bu örnek için, sunum ve slayt sorguları her biri üç tıklama konteyneri, iki fare‑üzerinde konteyneri ve üç birleşik konteyner rapor eder. Metin‑çerçeve sorgusu her kategori için bir konteyner raporlar.

### **Eylemleri ve Hedefleri Sınıflandırma**

[IHyperlink::get_ActionType](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_actiontype/) yöntemi, bir hedefi yorumlamadan önce eylemi yorumlamak için kullanılabilir. [HyperlinkActionType](https://reference.aspose.com/slides/cpp/aspose.slides/hyperlinkactiontype/) değerleri web gezinmesinden daha fazlasını kapsar:

| Değerler | Denetim için Anlamı |
| --- | --- |
| `Hyperlink` | Harici köprü; URL'yi ve şemasını inceleyin. |
| `JumpSpecificSlide` | Belirli bir slayta içsel gezinme. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Slayt gösterisi içinde yerleşik gezinme; slayt gösterisi bağlamında çözülür. |
| `JumpEndShow`, `StartCustomSlideShow` | Mevcut gösteriyi sonlandırır veya özel bir gösteri başlatır. |
| `StartMacro` | Bir makro çalıştırır. |
| `StartProgram` | Bir program başlatır. |
| `OpenFile`, `OpenPresentation` | Bir dosya veya başka bir sunum açar; web URL'lerinden ayrı olarak incelenmelidir. |
| `StartStopMedia` | Medya oynatımını başlatır veya durdurur. |
| `NoAction`, `Unknown` | Navigasyon eylemi yoktur veya incelenmesi gereken tanınmayan bir eylemdir. |

Harici hedefleri [get_ExternalUrl](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurl/) ile, belirli iç hedefleri ise [get_TargetSlide](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_targetslide/) ile okuyun. İç eylemler ve yerleşik komutlar harici bir URL içermeyebilir; boş bir URL, konteynerin eylemi olmadığı anlamına gelmez. Normalleştirilmiş URL'den farklıysa [get_ExternalUrlOriginal](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurloriginal/) değerini koruyun ve bir ipucu mevcutsa [get_Tooltip](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_tooltip/) tarafından dönen değeri ekleyin.

### **Köprüleri Raporlama, Temizleme ve Doğrulama**

Aşağıdaki C++ örneği var olan bir sunumu (yukarıda oluşturulan dosyayı) okur, `hyperlink-audit.json` yazar, bir politika uygular, `hyperlink-sanitized.pptx` kaydeder ve tekrar açarak iki etkinleştirme türünü tekrar kontrol eder. Değişiklik yapmadan önce konteynerleri toplar ve aynı konteyneri iki kez işlememek için işaretçi kimliğini kullanır. Sunum sorguları normal slaytları kapsar; paket‑geneli envanter için ayrıca ana, yerleşim, not ve not‑ve dağıtım anaları açıkça sorgulanır.

Rapor, bir‑tabanlı slayt indeksini ve varsa [get_SlideId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseslide/get_slideid/) değerini kaydeder. [ISlideComponent::get_Slide](https://reference.aspose.com/slides/cpp/aspose.slides/islidecomponent/get_slide/) desteklenen konteynerler için sahibi slaytı sağlar. Ana, yerleşim ve notlar normal slayt indeksine sahip değildir ve kapsamlarıyla tanımlanır. Şekil konteynerleri ve metin‑bölümü biçim konteynerleri ayrı ayrı etiketlenir; diğer konteyner tipleri çalışma zamanı tip adını korur. Her konteyner rapor‑yerel bir kimlik alır, böylece iki eylemi ilişkilendirilebilir.

Bu kısıtlayıcı politika yalnızca mutlak HTTPS URL'lerini ve geçerli iç slayt hedeflerini kabul eder. Makrolar, programlar, dosya eylemleri, diğer slayt‑gösterisi eylemleri, bilinmeyen eylemler ve diğer URL şemaları reddedilir. Bu reddetmeler politika kararlarıdır, Aspose.Slides güvenlik kararı değildir. HTTPS tek başına güvenlik sağlamaz: uygulamanız için host izin listeleri ve ek kontroller ekleyin. Hem orijinal hem de normalleştirilmiş dış URL'ler kontrol edilir. Örnek, bağlantıları takip etmeden veya eylemleri çalıştırmadan meta verileri denetler.

Düzeltme için, konteynerin [get_HyperlinkManager](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkcontainer/get_hyperlinkmanager/) aşağıdaki yöntemleri destekler: [SetExternalHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkclick/), ve [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). Burada, yasak dış tıklama bağlantıları sabit bir HTTPS iniş sayfasıyla değiştirilirken; diğer yasak tıklama ve yasak fare‑üzerinde eylemler bağımsız olarak kaldırılır. Tüm politika ihlallerini kaldırmak için `replaceExternalClicks` değerini `false` olarak ayarlayın. Dağıtıma kadar bir uygulama‑sahibi yedek sayfa seçin.

Raporun dışa aktarım işareti, temkinli bir PDF inceleme politikasını kullanır: fare‑üzerinde eylemleri ve dış link dışındaki tüm eylemleri potansiyel olarak desteklenmeyen olarak işaretler. Bu bir inceleme ipucu olup, yetenek testi ya da işaretlenmemiş bağlantıların dışa aktarımda kalacağı garantisi değildir. Desteklenen [PDF](/slides/tr/cpp/convert-powerpoint-to-pdf/) ve [HTML](/slides/tr/cpp/convert-powerpoint-to-html/) dışa aktarmaları, eyleme, dışa aktarım seçeneklerine ve görüntüleyiciye bağlı olarak köprüleri koruyabilir; raster [görüntüler](/slides/tr/cpp/convert-powerpoint-to-png/) ve [videolar](/slides/tr/cpp/convert-powerpoint-to-video/) etkileşimli köprüleri koruyamaz; bu çıktılar için denetim yaparken her eylemi işaretleyin.

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

Yukarıda oluşturulan girişle, rapor beş eylem satırı içerir. Dosya fare‑üzerinde bağlantısı ve makro tıklaması kaldırılırken, HTTPS bağlantıları ve iç slayt gezinmesi kalır. Doğrulama, sıfır yasak eylem yazdırır. Yasak bir dış tıklama URL'si içeren bir giriş, değiştirme dalını da gösterir. İzin verilen bir tıklama ve yasak bir fare‑üzerinde eylemi olan bir konteyner, tıklama eylemini korur.

Bu seçici temizlik, [RemoveAllHyperlinks](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) yönteminden farklıdır; bu yöntem politika fark etmeksizin seçilen kapsamda her iki etkinleştirme türünü de kaldırır. Buradaki doğrulama yalnızca köprü eylemlerini kontrol eder; gömülü VBA projelerini, OLE nesnelerini veya diğer aktif içeriği kaldırmaz ve dışa aktarılmış PDF veya HTML dosyasını doğrulamaz.

## **SSS**

**Bir bölüme veya onun ilk slaytına nasıl bağlanabilirim?**

PowerPoint'te bölümler slaytları gruplayarak düzenler, ancak bir iç köprü bireysel bir slayta yönelir. Bir bölüme gezinme oluşturmak için, o bölümün ilk slaytına bağlanın.

**Ana slayt öğelerine bir köprü ekleyebilir ve tüm slaytlarda çalışmasını sağlayabilir miyim?**

Evet. Ana slayt ve yerleşim öğeleri köprüleri destekler. Bu öğelerdeki bağlantılar, ilgili ana veya yerleşimi kullanan slayt gösterisi sırasında kullanılabilir.

**PDF, HTML, görüntüler veya video olarak dışa aktarırken köprüler korunur mu?**

Desteklenen PDF ve HTML dışa aktarmaları köprüleri koruyabilir; raster görüntüler ve video bunu yapamaz. Ayrıntılar için [Köprüleri Raporlama, Temizleme ve Doğrulama](#report-sanitize-and-verify-hyperlinks) bölümüne bakın.