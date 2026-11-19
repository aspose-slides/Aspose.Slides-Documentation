---
title: Sunum Bağlantılarını .NET'te Yönetme
linktitle: Bağlantıları Yönet
type: docs
weight: 20
url: /tr/net/manage-hyperlinks/
keywords:
- URL ekle
- bağlantı ekle
- bağlantı oluştur
- bağlantıyı biçimlendir
- bağlantıyı kaldır
- bağlantıyı güncelle
- metin bağlantısı
- slayt bağlantısı
- şekil bağlantısı
- görsel bağlantısı
- video bağlantısı
- değiştirilebilir bağlantı
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET kullanarak C# örnekleriyle PowerPoint ve OpenDocument sunumlarındaki bağlantıları ekleyin, biçimlendirin, güncelleyin ve kaldırın."
---
## **Giriş**

Bir köprü, sunum içeriğini bir web sitesine veya sunum içindeki bir konuma bağlar. PowerPoint'te köprüler genellikle iki amaç için kullanılır:

* Metin, şekil veya medya çerçevesinden bir web sitesini açmak.
* Örneğin bir içindekiler tablosundan başka bir slayta gitmek.

Aspose.Slides for .NET, bu bağlantıları eklemenize, görünüm ve seslerini kontrol etmenize, özelliklerini güncellemenize ve kaldırmanıza olanak tanır. Aşağıdaki örnekler, bireysel öğelerde köprülerle nasıl çalışılacağını ve sunum, slayt veya metin‑çerçeve düzeyinde köprülerin nasıl erişileceğini gösterir.

{{% alert color="info" title="Not" %}}
Ayrıca sunumları [ücretsiz çevrimiçi Aspose PowerPoint düzenleyicisi](https://products.aspose.app/slides/editor) ile düzenleyebilirsiniz.
{{% /alert %}}

## **URL Bağlantıları Ekle**

Metne, şekle veya medya çerçevesine bir web sitesi URL'si atayabilirsiniz. Köprüyü atadığınız öğe tıklanabilir alanı belirler: bir metin bölümü seçilen metni, bir şekil veya çerçeve ise slayt nesnesini bağlar.

Göreceli köprüler içeren sunumlar için, belge‑düzeyinde temeli okumak, değiştirmek veya temizlemek amacıyla [Bağlantı Temelini Yönet](/slides/tr/net/presentation-properties/#manage-the-hyperlink-base) bölümüne bakın.

### **Metne URL Bağlantıları Ekle**

Metni bir web sitesine bağlamak için, aşağıdaki gibi metin bölümünün [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/portionformat/hyperlinkclick/) özelliğine bir [Hyperlink](https://reference.aspose.com/slides/net/aspose.slides/hyperlink/) atayın. Yalnızca o metin bölümü tıklanabilir olur.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var textShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
textShape.AddTextFrame("Aspose: File Format APIs");
var portionFormat = textShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
portionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
portionFormat.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";
portionFormat.FontHeight = 32;

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

### **Şekillere ve Medya Çerçevelerine URL Bağlantıları Ekle**

Dikdörtgenin [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/hyperlinkclick/) özelliğine bir URL atayarak tüm alanının tıklanabilir olmasını sağlayın. [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) özelliği, kullanıcı dikdörtgenin üzerine geldiğinde hedef hakkında bir ipucu verir. Aynı özellikler resim, ses ve video çerçevelerine de uygulanır.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
shape.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

## **Bağlantıları Kullanarak İçindekiler Tablosu Oluşturma**

İç köprüler, okuyucuların bir içindekiler tablosundan belirli bir slayta atlamasını sağlar. Aşağıdaki örnek, ilk slayttaki “Page 2” metnini ikinci slayta bağlamak için [SetInternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) yöntemini kullanır.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var firstSlide = presentation.Slides[0];
var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

var tableOfContents = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
tableOfContents.FillFormat.FillType = FillType.NoFill;
tableOfContents.LineFormat.FillFormat.FillType = FillType.NoFill;
tableOfContents.TextFrame.Paragraphs.Clear();

var paragraph = new Paragraph();
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
paragraph.Text = "Title of slide 2 .......... ";

var linkPortion = new Portion();
linkPortion.Text = "Page 2";
linkPortion.PortionFormat.HyperlinkManager.SetInternalHyperlinkClick(secondSlide);

paragraph.Portions.Add(linkPortion);
tableOfContents.TextFrame.Paragraphs.Add(paragraph);

presentation.Save("link_to_slide.pptx", SaveFormat.Pptx);
```

## **Bağlantıları Biçimlendirme**

Bağlantılı metnin rengini değiştirebilir, bir okuyucu köprüyü etkinleştirdiğinde ses çalabilir veya durdurabilir ve fareyle üzerine gelindiğinde görünen ipucu metnini ayarlayabilirsiniz.

### **Renk**

[IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) üzerindeki [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/colorsource/) özelliği, köprünün sunumun köprü rengini mi yoksa metin bölümünün biçimlendirmesini mi kullandığını belirler. Özel bir metin rengi uygulamak için [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkcolorsource/) seçin ve bölümün dolgu rengini ayarlayın. Bu özellik PowerPoint 2019’da tanıtıldı; eski sürümler bu ayarı uygulamaz.

Bu örnekte, ilk bağlantıda [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/colorsource/) ayarı metnin kırmızı görünmesini sağlar. İkinci bağlantı ise sunumun köprü rengini korur.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var coloredShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
coloredShape.AddTextFrame("This hyperlink uses a custom color.");
var coloredPortionFormat = coloredShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
coloredPortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
coloredPortionFormat.HyperlinkClick.ColorSource = HyperlinkColorSource.PortionFormat;
coloredPortionFormat.FillFormat.FillType = FillType.Solid;
coloredPortionFormat.FillFormat.SolidFillColor.Color = Color.Red;

var defaultShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
defaultShape.AddTextFrame("This hyperlink uses the default color.");
defaultShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");

presentation.Save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
```

### **Ses**

Bir köprü, etkinleştirildiğinde bir ses çalabilir veya hâlihazırda çalan bir sesi durdurabilir. Bu davranışları yapılandırmak için aşağıdaki özellikleri kullanın:

- [IHyperlink.Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) köprüyle ilişkilendirilen ses dosyasını belirtir.
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/stopsoundonclick/) köprünün etkinleştirilmesiyle önceki sesin durdurulup durdurulmayacağını kontrol eder.

#### **Bir Bağlantı Sesi Ekle**

İlk slayttaki düğme, okuyucu ilerlemek için tıkladığında bir WAV dosyasından ses çalmak üzere [Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) kullanır. İkinci slaytta ayrı bir düğme, oynatmayı durdurmak ve okuyucuyu o slaytta tutmak için [StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/stopsoundonclick/) kullanır.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var audioData = File.ReadAllBytes("sampleaudio.wav");
var hyperlinkSound = presentation.Audios.AddAudio(audioData);

var firstSlide = presentation.Slides[0];

var playButton = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
playButton.HyperlinkClick = Hyperlink.NextSlide;

if (!playButton.HyperlinkClick.StopSoundOnClick && playButton.HyperlinkClick.Sound == null)
{
    playButton.HyperlinkClick.Sound = hyperlinkSound;
}

var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

var stopButton = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
stopButton.HyperlinkClick = Hyperlink.NoAction;

stopButton.HyperlinkClick.StopSoundOnClick = true;

presentation.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
```

#### **Bir Bağlantı Sesini Çıkar**

Aşağıdaki örnek, yukarıda oluşturulan sunumu açar ve ilk şeklin köprü sesini [Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) ve [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/) aracılığıyla belleğe okur.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("hyperlink-sound.pptx");

if (presentation.Slides.Count > 0 && presentation.Slides[0].Shapes.Count > 0)
{
    var hyperlink = presentation.Slides[0].Shapes[0].HyperlinkClick;
    var sound = hyperlink?.Sound;
    if (sound != null)
    {
        var audioData = sound.BinaryData;
        Console.WriteLine($"Extracted {audioData.Length} bytes of hyperlink audio.");
    }
    else
    {
        Console.WriteLine("The first shape has no hyperlink sound.");
    }
}
else
{
    Console.WriteLine("The presentation has no first slide or shape to inspect.");
}
```

### **İpucu ve Etkileşim Ayarları**

Bir köprüyü metne veya şekle atadıktan sonra aşağıdaki [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) özelliklerini güncelleyebilirsiniz:

- [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) izleyicinin bağlantı için ipucu olarak görüntüleyebileceği metni ayarlar.
- [TargetFrame](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetframe/) gerektiğinde üst HTML çerçeve seti içinde hedef çerçeveyi belirtir.
- [History](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/history/) bağlantının etkinleştirilmesinin hedefi izlenen köprüler listesine eklenip eklenmeyeceğini kontrol eder.
- [HighlightClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/highlightclick/) tıklandığında köprünün vurgulanıp vurgulanmayacağını belirler.

## **Sunumlardan Bağlantıları Kaldırma**

Bir slaytta yer alan bağlantı kapsayıcılarını (metin‑bölümü bağlantıları dahil) toplamak için [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) kullanın. Aşağıdaki örnek, ilk slayttan her iki etkinleştirme türünü de kaldırır. Yalnızca bir türü kaldırmak isterseniz sadece [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) veya [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) metodunu çağırın; bir tıklama eylemini kaldırmak, fare‑üstü eylemini kaldırmaz.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

if (presentation.Slides.Count > 0)
{
    var containers = presentation.Slides[0].HyperlinkQueries.GetAnyHyperlinks().ToList();
    foreach (var container in containers)
    {
        container.HyperlinkManager.RemoveHyperlinkClick();
        container.HyperlinkManager.RemoveHyperlinkMouseOver();
    }
    presentation.Save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The presentation has no slides to process.");
}
```

Koşulsuz kaldırma için, [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) seçili kapsamda her iki etkinleştirme türünü tek bir çağrıyla kaldırır. Master, düzen ve notlar dahil seçici temizlik ve kapsama için [Bağlantıları Raporla, Temizle ve Doğrula](#report-sanitize-and-verify-hyperlinks) bölümüne bakın.

### **SmartArt Metnini Değiştirmeden Önce Bağlantıları Temizleme**

Mevcut bir SmartArt düğümündeki bir paragrafı değiştirdiğinizde, bölümlerini temizlemek eski bir köprünün etkili kalmasına neden olabilir. Paragrafı [ISmartArtNode.TextFrame](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/textframe/) aracılığıyla alın. Bölümlerini temizlemeden önce, düğüm şeklinin metin çerçevesindeki [HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/hyperlinkqueries/) üzerinden [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) metodunu çağırın. Bu, çerçevedeki tüm köprüleri, diğer paragraflardaki linkler dahil, kaldırır.

Örnek, ilk slayttaki üçüncü şeklin bir SmartArt grafiği olduğunu varsayar. Dördüncü düğümün ilk paragrafını değiştirir. Bu sunumda, düğümün ilk şekli o paragrafı gösterir.

Her iki bölümü ekledikten sonra örnek, [GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) yöntemiyle etkili biçimlendirmelerini okur. Etkili [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/iportionformateffectivedata/hyperlinkclick/) özelliği, ilk bölüm için yeni köprüyü ve ikinci bölüm için `null` değerini döndürür.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation("SmartArtHyperlink.pptx");
var slide = presentation.Slides[0];

var smartArt = (ISmartArt)slide.Shapes[2];
var node = smartArt.AllNodes[3];
var paragraph = node.TextFrame.Paragraphs[0];

node.Shapes[0].TextFrame.HyperlinkQueries.RemoveAllHyperlinks();
paragraph.Portions.Clear();

var link = new Portion("New reference");
link.PortionFormat.HyperlinkClick = new Hyperlink("https://example.com/new");
paragraph.Portions.Add(link);
var text = new Portion(" (updated)");
paragraph.Portions.Add(text);

Console.WriteLine(link.PortionFormat.GetEffective().HyperlinkClick.ExternalUrl); // https://example.com/new
Console.WriteLine(text.PortionFormat.GetEffective().HyperlinkClick?.ToString() ?? "null"); // null
```

## **Tam Bir Bağlantı Envanteri Oluşturma**

Bir sunumu dağıtmadan önce etkileşimli eylemlerini ve web linklerini envantere kaydedin. [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) URL dizesi listesi yerine [IHyperlinkContainer](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/) nesneleri döndürür. Her kapsayıcıdaki [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/) ve [HyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/) özelliklerini inceleyin. Bunlar bağımsızdır: aynı kapsayıcı her iki eylemi de barındırabilir, bu yüzden tam bir rapor kapsayıcı başına iki satır gerektirebilir.

Yalnızca şekil‑düzeyindeki köprüleri taramak, metin bölümlerine eklenmiş linkleri kaçırabilir. Bunun yerine uygun kapsamı sorgulayın ve dönen kapsayıcıları saklayarak ileride eylemlerini güncelleyebilir veya kaldırabilirsiniz.

### **Sunum, Slayt ve Metin‑Çerçeve Kapsamlarını Sorgula**

[IHyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/) arayüzü, [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/hyperlinkqueries/), [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/hyperlinkqueries/) ve [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/hyperlinkqueries/) üzerinden kullanılabilir. Her kapsam aynı sorguları destekler:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) tıklama eylemi olan kapsayıcıları döndürür.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) fare‑üstü eylemi olan kapsayıcıları döndürür.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) bir veya her iki eylemi de içeren kapsayıcıları döndürür.

Bu örnek, bir şekil ve metnine tıklama ve fare‑üstü eylemleri, ayrıca ayrı bir düğmeye makro eylemi atar. [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) tarafından döndürülen kapsayıcıları, her etkinleştirme türünün sayısıyla karşılaştırır. Metin‑çerçeve sorgusu yalnızca metindeki linkleri sayar. İçeren şeklin kendi eylemleri slayt ve sunum sorgularında görünür.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var destination = presentation.Slides.AddEmptySlide(slide.LayoutSlide);
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
shape.TextFrame.Text = "Click the text to go to slide 2";
shape.HyperlinkManager.SetExternalHyperlinkClick("https://example.com/");
shape.HyperlinkClick.Tooltip = "Public website";
shape.HyperlinkManager.SetExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

var portionFormat = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
portionFormat.HyperlinkManager.SetInternalHyperlinkClick(destination);
portionFormat.HyperlinkManager.SetExternalHyperlinkMouseOver("https://example.com/help");
var macroButton = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 120, 200, 60);
macroButton.HyperlinkManager.SetMacroHyperlinkClick("ReviewPresentation");

PrintCounts("Presentation", presentation.HyperlinkQueries);
PrintCounts("Slide 1", slide.HyperlinkQueries);
PrintCounts("Text frame", shape.TextFrame.HyperlinkQueries);
presentation.Save("hyperlink-audit-input.pptx", SaveFormat.Pptx);

static void PrintCounts(string scope, IHyperlinkQueries queries)
{
    var clickContainers = queries.GetHyperlinkClicks();
    var mouseOverContainers = queries.GetHyperlinkMouseOvers();
    var allContainers = queries.GetAnyHyperlinks();
    Console.WriteLine($"{scope}: click={clickContainers.Count}, mouse-over={mouseOverContainers.Count}, any={allContainers.Count}");
}
```

Bu örnek için sunum ve slayt sorguları üç tıklama kapsayıcısı, iki fare‑üstü kapsayıcısı ve üç birleşik kapsayıcı rapor eder. Metin‑çerçeve sorgusu her kategoride bir kapsayıcı rapor eder.

### **Eylemleri ve Hedefleri Sınıflandır**

[IHyperlink.ActionType](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/actiontype/) kullanarak bir eylemi yorumlamadan önce hedefini yorumlayın. [HyperlinkActionType](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkactiontype/) değerleri web gezinmesinin ötesinde kapsamlar sunar:

| Değerler | Denetim için Anlamı |
| --- | --- |
| `Hyperlink` | Harici köprü; URL ve şemasını inceleyin. |
| `JumpSpecificSlide` | Belirli bir slayta iç yönlendirme. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Slayt gösterisi bağlamında çözülen yerleşik navigasyon. |
| `JumpEndShow`, `StartCustomSlideShow` | Mevcut gösteriyi sonlandır veya özel bir gösteri başlat. |
| `StartMacro` | Bir makroyu çalıştır. |
| `StartProgram` | Bir program başlat. |
| `OpenFile`, `OpenPresentation` | Bir dosya veya başka bir sunum aç; web URL'lerinden ayrı değerlendirin. |
| `StartStopMedia` | Medya oynatımını başlat veya durdur. |
| `NoAction`, `Unknown` | Navigasyon eylemi yok veya gözden geçirilmesi gereken tanınmayan eylem. |

Harici hedefleri [ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) üzerinden, belirli iç hedefleri ise [TargetSlide](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetslide/) üzerinden okuyun. İç eylemler ve yerleşik komutlar harici URL içermeyebilir; boş bir URL, kapsayıcının eylemi olmadığı anlamına gelmez. Normalleştirilmiş URL'den farklıysa [ExternalUrlOriginal](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurloriginal/) koruyun ve mevcutsa [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) ekleyin.

### **Bağlantıları Raporla, Temizle ve Doğrula**

Bu .NET 6+ örneği, önceki örnekten sunumu açar ve eylem başına bir JSON kaydı yazar. Normal slaytlar, master'lar, düzenler ve notlar dahil, varsa not ve el ilanı master'larını da kapsayan kapsayıcıları toplamak için [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) kullanır. Referans eşitliğiyle her kapsayıcı bir kez sayılır, aşağıda açıklanan politika uygulanır ve kaydedilen sunum yeniden açılarak hem tıklama hem fare‑üstü eylemleri kontrol edilir.

Rapor, mevcutsa bir‑bazlı slayt indeksini ve [SlideId](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideid/) bilgisini içerir. [ISlideComponent.Slide](https://reference.aspose.com/slides/net/aspose.slides/islidecomponent/slide/) desteklenen kapsayıcılar için sahip slaytı sağlar. Master, düzen ve notlar normal bir slayt indeksine sahip değildir; kapsamlarıyla tanımlanırlar. Şekil kapsayıcıları ve metin‑bölümü biçimlendirme kapsayıcıları ayrı etiketlenir; diğer kapsayıcı tipleri çalışma zamanı sınıf adını korur. Her kapsayıcıya, iki eylemin ilişkilendirilebilmesi için rapor‑yerel bir kimlik verilir.

Bu kısıtlayıcı uygulama politikası yalnızca mutlak HTTPS URL'lerini ve geçerli iç slayt hedeflerini kabul eder. Makrolar, programlar, dosya eylemleri, diğer slayt gösterisi eylemleri, bilinmeyen eylemler ve diğer URL şemaları reddedilir. Bu reddetmeler politika kararlarıdır, Aspose.Slides güvenlik kararı değildir. HTTPS tek başına güven oluşturmaz: uygulamanız için host beyaz listeleri ve ek kontroller ekleyin. Hem orijinal hem de normalleştirilmiş harici URL'ler kontrol edilir. Örnek, bağlantıları takip etmeden veya eylemleri çalıştırmadan meta verileri denetler.

Düzeltme için, kapsayıcının [HyperlinkManager](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/) aşağıdaki yöntemleri destekler: [SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/), ve [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). Burada, yasaklanmış harici tıklama linkleri sabit bir HTTPS iniş sayfasıyla değiştirilirken, diğer yasak tıklama ve fare‑üstü eylemleri ayrı ayrı kaldırılır. `replaceExternalClicks` değerini `false` yaparak tüm politika ihlallerini kaldırabilirsiniz. Dağıtıma geçmeden önce uygulama sahipli bir değiştirme sayfası seçin.

Raporun dışa aktarma bayrağı, korumasız olabilecek eylemleri işaretlemek için temkinli bir PDF gözden geçirme politikası kullanır: fare‑üstü eylemler ve harici bağlantı dışındaki ya da belirli slayt atlaması olmayan tüm eylemler potansiyel olarak desteklenmez olarak işaretlenir. Bu bir inceleme ipucu olup, işaretlenmemiş linklerin dışa aktarmada korunacağı garantisi değildir. Desteklenen [PDF](/slides/tr/net/convert-powerpoint-to-pdf/) ve [HTML](/slides/tr/net/convert-powerpoint-to-html/) dışa aktarımları, eyleme, dışa aktarma seçeneklerine ve görüntüleyiciye bağlı olarak köprüleri koruyabilir. Raster [görseller](/slides/tr/net/convert-powerpoint-to-png/) ve [videolar](/slides/tr/net/convert-powerpoint-to-video/) etkileşimli köprüleri koruyamaz; bu çıktılar için denetim yaparken her eylemi işaretleyin.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

const bool replaceExternalClicks = true;
const string replacementUrl = "https://example.com/blocked-link";
using var presentation = new Presentation("hyperlink-audit-input.pptx");
var containers = CollectContainers(presentation);
var rows = new List<object>();

for (var index = 0; index < containers.Count; index++)
{
    var container = containers[index];
    AddRow(container.HyperlinkClick, "click", container, index + 1);
    AddRow(container.HyperlinkMouseOver, "mouse-over", container, index + 1);
}

var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
var json = JsonSerializer.Serialize(rows, jsonOptions);
File.WriteAllText("hyperlink-audit.json", json);

foreach (var container in containers)
{
    var click = container.HyperlinkClick;
    if (PolicyViolation(click) != null)
    {
        if (replaceExternalClicks && click.ActionType == HyperlinkActionType.Hyperlink)
        {
            container.HyperlinkManager.SetExternalHyperlinkClick(replacementUrl);
        }
        else
        {
            container.HyperlinkManager.RemoveHyperlinkClick();
        }
    }
    if (PolicyViolation(container.HyperlinkMouseOver) != null)
    {
        container.HyperlinkManager.RemoveHyperlinkMouseOver();
    }
}

presentation.Save("hyperlink-sanitized.pptx", SaveFormat.Pptx);
using var reopened = new Presentation("hyperlink-sanitized.pptx");
var remainingContainers = CollectContainers(reopened);
var violations = 0;
foreach (var container in remainingContainers)
{
    if (PolicyViolation(container.HyperlinkClick) != null) violations++;
    if (PolicyViolation(container.HyperlinkMouseOver) != null) violations++;
}
Console.WriteLine($"Audit rows: {rows.Count}; prohibited actions after reopening: {violations}");
if (violations != 0)
{
    Console.WriteLine("Verification failed: do not distribute the saved presentation.");
    Environment.ExitCode = 1;
}

void AddRow(IHyperlink? link, string activation, IHyperlinkContainer container, int containerId)
{
    if (link == null) return;
    var ownerSlide = (container as ISlideComponent)?.Slide;
    var targetSlide = link.TargetSlide;
    var violation = PolicyViolation(link);
    var ownerType = container is IShape ? "Shape" : container is IPortionFormat ? "Text portion" : container.GetType().Name;
    var ordinaryAction = link.ActionType == HyperlinkActionType.Hyperlink || link.ActionType == HyperlinkActionType.JumpSpecificSlide;
    rows.Add(new
    {
        ContainerId = containerId,
        SlideIndex = SlideIndex(presentation, ownerSlide),
        SlideId = ownerSlide?.SlideId,
        Scope = ownerSlide?.GetType().Name,
        OwnerType = ownerType,
        Activation = activation,
        ActionType = link.ActionType.ToString(),
        ExternalUrl = link.ExternalUrl,
        TargetSlideIndex = SlideIndex(presentation, targetSlide),
        TargetSlideId = targetSlide?.SlideId,
        Tooltip = link.Tooltip,
        OriginalExternalUrl = link.ExternalUrlOriginal != link.ExternalUrl ? link.ExternalUrlOriginal : null,
        PotentiallyUnsafe = violation != null,
        PolicyViolation = violation,
        TargetExport = "PDF",
        PotentiallyUnsupportedByExport = activation == "mouse-over" || !ordinaryAction
    });
}

static int? SlideIndex(IPresentation presentation, IBaseSlide? slide)
{
    for (var index = 0; index < presentation.Slides.Count; index++)
    {
        if (ReferenceEquals(presentation.Slides[index], slide)) return index + 1;
    }
    return null;
}

static string? PolicyViolation(IHyperlink? link)
{
    if (link == null) return null;
    if (link.ActionType == HyperlinkActionType.JumpSpecificSlide)
    {
        return link.TargetSlide == null ? "Missing target slide" : null;
    }
    if (link.ActionType != HyperlinkActionType.Hyperlink) return "Action is not allowed";
    if (!IsHttps(link.ExternalUrl)) return "Normalized URL is not absolute HTTPS";
    var original = link.ExternalUrlOriginal;
    if (!string.IsNullOrEmpty(original) && !IsHttps(original)) return "Original URL is not absolute HTTPS";
    return null;
}

static bool IsHttps(string? value)
{
    return Uri.TryCreate(value, UriKind.Absolute, out var uri) && uri.Scheme == Uri.UriSchemeHttps;
}

static List<IHyperlinkContainer> CollectContainers(IPresentation presentation)
{
    var found = new List<IHyperlinkContainer>();
    found.AddRange(presentation.HyperlinkQueries.GetAnyHyperlinks());
    foreach (var master in presentation.Masters) AddScope(master);
    foreach (var layout in presentation.LayoutSlides) AddScope(layout);
    foreach (var slide in presentation.Slides) AddScope(slide.NotesSlideManager.NotesSlide);
    AddScope(presentation.MasterNotesSlideManager.MasterNotesSlide);
    AddScope(presentation.MasterHandoutSlideManager.MasterHandoutSlide);
    return found.Distinct<IHyperlinkContainer>(ReferenceEqualityComparer.Instance).ToList();

    void AddScope(IBaseSlide? slide)
    {
        if (slide != null) found.AddRange(slide.HyperlinkQueries.GetAnyHyperlinks());
    }
}
```

Yukarıdaki girişle rapor, beş eylem satırı içerir. Dosya fare‑üstü linki ve makro tıklaması kaldırılırken, HTTPS linkleri ve iç slayt navigasyonu kalır. Doğrulama, sıfır yasaklı eylem çıktılar. Yasak bir harici tıklama URL'si içeren bir giriş, değiştirme dalını da çalıştırır. İzin verilen bir tıklama ve yasak bir fare‑üstü eylemi içeren bir kapsayıcı, tıklama eylemini korur.

Bu seçici temizlik, [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) ile farklıdır; bu yöntem, politika göz önünde bulundurulmadan seçili kapsam içinde her iki etkinleştirme türünü de kaldırır. Buradaki doğrulama yalnızca köprü eylemlerini denetler; gömülü VBA projeleri, OLE nesneleri veya diğer aktif içerikleri kaldırmaz ve dışa aktarılan PDF veya HTML dosyasını doğrulamaz.

## **SSS**

**Bir bölüme ya da onun ilk slaytına nasıl bağlanabilirim?**

PowerPoint'te bölümler slaytları gruplar, ancak bir iç köprü bireysel bir slaytı hedef alır. Bir bölüme yönlendirme oluşturmak için o bölümün ilk slaytına bağlanın.

**Master slayt öğelerine köprü ekleyebilir miyim, böylece tüm slaytlarda çalışır?**

Evet. Master slayt ve düzen öğeleri köprüleri destekler. Bu öğelere eklenen köprüler, ilgili master ya da düzeni kullanan slayt gösterisi sırasında erişilebilir olur.

**PDF, HTML, görseller veya video olarak dışa aktarırken köprüler korunur mu?**

Desteklenen PDF ve HTML dışa aktarımları köprüleri koruyabilir; raster görseller ve video koruyamaz. Ayrıntılar için [Bağlantıları Raporla, Temizle ve Doğrula](#report-sanitize-and-verify-hyperlinks) bölümü incelenebilir.