---
title: Sunum Köprülerini .NET'te Yönet
linktitle: Köprüleri Yönet
type: docs
weight: 20
url: /tr/net/manage-hyperlinks/
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
- görsel köprüsü
- video köprüsü
- değiştirilebilir köprü
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PowerPoint ve OpenDocument sunumlarında köprüleri ekleyin, biçimlendirin, güncelleyin ve kaldırın, C# örnekleri kullanarak."
---
## **Giriş**

Bir köprü, sunum içeriğini bir web sitesine veya sunum içindeki bir konuma bağlar. PowerPoint’te köprüler genellikle iki amaç için kullanılır:

* Metin, şekil veya medya çerçevesinden bir web sitesini açmak.
* İçindekiler tablosu gibi bir yerden başka bir slayta gitmek.

Aspose.Slides for .NET, bu bağlantıları eklemenize, görünüm ve seslerini kontrol etmenize, özelliklerini güncellemenize ve kaldırmanıza olanak tanır. Aşağıdaki örnekler, bireysel öğelerde köprülerle nasıl çalışılacağını ve sunum, slayt veya metin‑çerçevesi düzeyinde köprülere nasıl erişileceğini gösterir.

{{% alert color="info" title="Not" %}}
Ayrıca sunumları [ücretsiz çevrimiçi Aspose PowerPoint düzenleyicisi](https://products.aspose.app/slides/editor) ile düzenleyebilirsiniz.
{{% /alert %}} 

## **URL Bağlantılarını Ekleme**

Bir web sitesi URL'sini metne, şekle veya bir medya çerçevesine atayabilirsiniz. Köprüyü atadığınız öğe, tıklanabilir alanı belirler: bir metin bölümü seçilen metni bağlarken, bir şekil veya çerçeve slayt nesnesini bağlar.

Göreli köprüler içeren sunumlar için, belge‑düzeyindeki temel URL'yi okumak, değiştirmek veya temizlemek amacıyla [Manage the Hyperlink Base](/slides/tr/net/presentation-properties/#manage-the-hyperlink-base) bölümüne bakın.

### **Metne URL Bağlantısı Ekleme**

Metni bir web sitesine bağlamak için, metin bölümünün [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/portionformat/hyperlinkclick/) özelliğine bir [Hyperlink](https://reference.aspose.com/slides/net/aspose.slides/hyperlink/) atayın; aşağıda gösterildiği gibi. Yalnızca bu metin bölümü tıklanabilir olur.

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

### **Şekillere ve Medya Çerçevelerine URL Bağlantısı Ekleme**

Bir şekil veya çerçeveyi tıklanabilir hâle getirmek için, onun [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/hyperlinkclick/) özelliğini ayarlayın. Köprü, içinde metin bölümü bulunmasından bağımsız olarak nesneye aittir.

Aynı yaklaşım resim, ses ve video çerçevelerine de uygulanır: köprüyü çerçeveye atayın ve gerekirse köprünün [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) özelliğini belirleyin.

Aşağıdaki örnek bir dikdörtgeni tıklanabilir hâle getirir:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
shape.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

## **İçindekiler Tablosu Oluşturmak İçin Köprüleri Kullanma**

Dahili köprüler, okuyucuların içindekiler tablosundan belirli bir slayta atlamasını sağlar. Aşağıdaki örnek, ilk slayttaki “Page 2” metnini ikinci slayta bağlamak için [SetInternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) yöntemini kullanır.

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

## **Köprüleri Biçimlendirme**

### **Renk**

[IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/)’in [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/colorsource/) özelliği, köprünün sunumun köprü rengi mi yoksa metin bölümünün biçimlendirmesi mi kullanacağını belirler. Özel bir metin rengi uygulamak için [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkcolorsource/) seçin ve bölümün dolgu rengini ayarlayın. Bu özellik PowerPoint 2019’da tanıtıldı; eski sürümler bu ayarı uygulamaz.

Aşağıdaki örnek aynı slayta iki metin köprüsü ekler. İlki kırmızı metin dolgusuyla, ikincisi ise varsayılan köprü rengiyle kalır.

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

Bir köprü etkinleştirildiğinde ses çalabilir veya halihazırda çalan bir sesi durdurabilir. Bu davranışları yapılandırmak için aşağıdaki özellikleri kullanın:

- [IHyperlink.Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) köprüyle ilişkili ses dosyasını belirler.
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/stopsoundonclick/) köprünün etkinleştirilmesiyle önceki sesin durdurulup durdurulmayacağını kontrol eder.

#### **Köprü Sesini Ekleme**

Aşağıdaki örnek `sampleaudio.wav` dosyasını yükler ve ilk slayttaki bir düğmeye ilişkilendirir. Düğmeye tıklandığında ses çalınır ve bir sonraki slayta geçilir. Aynı slayttaki ikinci bir şekil, tıklandığında önceki sesi durdurur, ancak bir geçiş eylemi gerçekleştirmez.

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

#### **Köprü Sesini Çıkarma**

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

### **Araç İpucu ve Etkileşim Ayarları**

Bir köprüye metin, şekil vb. atadıktan sonra aşağıdaki [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) özelliklerini güncelleyebilirsiniz:

- [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) izleyicinin bağlantı için ipucu olarak gösterebileceği metni ayarlar.
- [TargetFrame](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetframe/) uygulanabilir olduğunda, ana HTML çerçeve setindeki hedef çerçeveyi belirtir.
- [History](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/history/) köprünün etkinleştirilmesinin hedefini görüntülenen köprüler listesine ekleyip eklemeyeceğini kontrol eder.
- [HighlightClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/highlightclick/) tıklandığında köprünün vurgulanıp vurgulanmayacağını belirler.

## **Sunumlardan Köprüleri Kaldırma**

[GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) yöntemini kullanarak, değiştirmeden önce metin‑bölümü bağlantıları dahil tüm köprü konteynerlerini toplayın. Aşağıdaki örnek ilk slayttaki iki etkinleştirme türünü kaldırır. Tek bir türü kaldırmak isterseniz yalnızca [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) veya [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) metodunu çağırın; tıklama eylemini kaldırmak, fare‑üzerinde eylemi kaldırmaz.

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

Koşulsuz kaldırma için, [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) seçili kapsamdaki her iki etkinleştirme türünü tek bir çağrıda siler. Master, düzen ve notlar dahil olmak üzere seçici temizlik ve kapsama için [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) bölümüne bakın.

## **Tam Bir Köprü Envanteri Oluşturma**

Bir sunumu dağıtmadan önce, etkileşimli eylemlerini ve web bağlantılarını envantere alın. [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) [IHyperlinkContainer](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/) nesnelerini döndürür, düz bir URL listesi değil. Her konteynerdeki [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/) ve [HyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/) öğelerini inceleyin. Bunlar bağımsızdır: aynı konteyner iki eylemi de içerebilir; bu nedenle tam bir rapor, bir konteyner başına iki satır gerektirebilir.

Yalnızca şekil‑düzeyindeki köprüleri taramak, metin bölümlerine eklenmiş bağlantıları kaçırabilir. Bunun yerine uygun kapsamı sorgulayın ve döndürülen konteynerleri saklayarak daha sonra eylemlerini güncelleyebilir veya kaldırabilirsiniz.

### **Sunum, Slayt ve Metin‑Çerçeve Kapsamlarını Sorgulama**

[IHyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/) arayüzü, [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/hyperlinkqueries/), [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/hyperlinkqueries/) ve [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/hyperlinkqueries/) üzerinden erişilebilir. Her kapsam aynı sorguları destekler:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) tıklama eylemi olan konteynerleri döndürür.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) fare‑üzerinde eylemi olan konteynerleri döndürür.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) her iki eylemden birini veya ikisini de içeren konteynerleri döndürür.

Aşağıdaki örnek, bir dış tıklama bağlantısı, bir dosya fare‑üzerinde bağlantısı, dahili slayt navigasyonu, bir metin fare‑üzerinde bağlantısı ve bir makro eylemi içeren `hyperlink-audit-input.pptx` dosyasını oluşturur. Bu eylemler çalıştırılmaz. Aynı üç sorgu her kapsamda aynı şekilde çalışır; sayımlar konteyner sayısını, eylem toplamını değil, gösterir. Metin‑çerçeve kapsamı, içinde bulunduğu şeklin kendi bağlantılarını dışarıda bırakır.

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

Bu örnek için, sunum ve slayt sorguları her birinde üç tıklama konteyneri, iki fare‑üzerinde konteyner ve üç “herhangi bir” konteyner raporlar. Metin‑çerçeve sorgusu her kategoride bir konteyner raporlar.

### **Eylemleri ve Hedefleri Sınıflandırma**

Bir eylemi yorumlamadan önce, hedefini yorumlamak için [IHyperlink.ActionType](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/actiontype/) kullanın. [HyperlinkActionType](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkactiontype/) değerleri yalnızca web navigasyonundan daha fazlasını kapsar:

| Değer | Denetim İçin Anlamı |
| --- | --- |
| `Hyperlink` | Dış köprü; URL ve şemasını inceleyin. |
| `JumpSpecificSlide` | Belirli bir slayta dahili navigasyon. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Slayt gösterisi içinde yerleşik gezinme, slayt gösterisi bağlamında çözülür. |
| `JumpEndShow`, `StartCustomSlideShow` | Mevcut gösteriyi sonlandır veya özel bir gösteri başlat. |
| `StartMacro` | Bir makro çalıştır. |
| `StartProgram` | Bir program başlat. |
| `OpenFile`, `OpenPresentation` | Bir dosya veya başka bir sunum aç; web URL’lerinden ayrı olarak incelenir. |
| `StartStopMedia` | Medya oynatmayı başlat veya durdur. |
| `NoAction`, `Unknown` | Navigasyon eylemi yok veya tanınmayan bir eylem; inceleme gerekir. |

Dış hedefleri [ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) üzerinden, belirli dahili hedefleri ise [TargetSlide](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetslide/) üzerinden okuyun. Dahili eylemler ve yerleşik komutlar dış URL içermeyebilir; boş bir URL, konteynerin eylemi olmadığı anlamına gelmez. Normalleştirilmiş URL’den farklıysa [ExternalUrlOriginal](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurloriginal/) değerini koruyun ve mevcutsa [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) ekleyin.

### **Köprüleri Raporlama, Temizleme ve Doğrulama**

Aşağıdaki .NET 6+ örneği, var olan bir sunumu (yukarıda oluşturulan dosyayı) okur, `hyperlink-audit.json` yazar, bir politika uygular, `hyperlink-sanitized.pptx` kaydeder ve ardından her iki etkinleştirme türünü tekrar kontrol etmek için yeniden açar. Değiştirmeden önce konteynerleri toplar ve aynı konteynerin iki kez işlenmesini önlemek için başvuru eşitliğini kullanır. Sunum sorguları normal slaytları kapsar; paket‑genel envanter için ayrıca master, düzen, not ve gerektiğinde not ve el ilanı master’ları da sorgular.

Rapor, bir‑bazlı slayt indeksini ve mevcutsa [SlideId](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideid/) değerini kaydeder. [ISlideComponent.Slide](https://reference.aspose.com/slides/net/aspose.slides/islidecomponent/slide/) desteklenen konteynerler için sahibi slaytı sağlar. Master, düzen ve notlar normal slayt indeksine sahip değildir ve kapsamlarıyla tanımlanır. Şekil konteynerleri ve metin‑bölümü biçimlendirme konteynerleri ayrı ayrı etiketlenir; diğer konteyner tipleri çalışma zamanındaki tür adını korur. Her konteyner, iki eylemini ilişkilendirmek için rapor‑yerel bir kimlik alır.

Bu kasıtlı olarak kısıtlayıcı politika, yalnızca mutlak HTTPS URL’lerini ve geçerli dahili slayt hedeflerini kabul eder. Makrolar, programlar, dosya eylemleri, diğer slayt gösterisi eylemleri, bilinmeyen eylemler ve diğer URL şemaları reddedilir. Bu reddetmeler politika kararlarıdır, Aspose.Slides güvenlik kararı değildir. HTTPS tek başına güven oluşturmaz: uygulamanız için host beyaz listeleri ve ek kontroller ekleyin. Hem orijinal hem de normalleştirilmiş dış URL’ler kontrol edilir. Örnek, bağlantıları takip etmeden veya eylemleri çalıştırmadan meta verileri denetler.

Düzeltme için, konteynerin [HyperlinkManager](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/) aşağıdaki metotları destekler: [SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) ve [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/). Burada, yasak dış tıklama bağlantıları sabit bir HTTPS açılış sayfasıyla değiştirilir; diğer yasak tıklama ve yasak fare‑üzerinde eylemler bağımsız olarak kaldırılır. Tüm politika ihlallerini kaldırmak için `replaceExternalClicks` parametresini `false` yapın. Dağıtıma almadan önce uygulamaya ait bir yedekleme sayfası belirleyin.

Raporun dışa aktarım bayrağı, temkinli bir PDF inceleme politikasını yansıtır: fare‑üzerinde eylemleri ve dış bağlantı ya da belirli slayt atlaması dışındaki her şeyi potansiyel olarak desteklenmeyen olarak işaretler. Bu bir inceleme ipucu olup, desteklenmediği anlamına gelmez. Desteklenen [PDF](/slides/tr/net/convert-powerpoint-to-pdf/) ve [HTML](/slides/tr/net/convert-powerpoint-to-html/) dışa aktarımları, eyleme, dışa aktarım seçeneklerine ve görüntüleyiciye bağlı olarak köprüleri koruyabilir. Raster [images](/slides/tr/net/convert-powerpoint-to-png/) ve [video](/slides/tr/net/convert-powerpoint-to-video/) interaktif köprüleri koruyamaz; bu çıktılar için denetleme sırasında her eylemi işaretleyin.

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

Yukarıdaki girdiyi oluşturduktan sonra rapor beş eylem satırı içerir. Dosya fare‑üzerinde bağlantısı ve makro tıklaması kaldırılır, HTTPS bağlantıları ve dahili slayt navigasyonu kalır. Doğrulama, sıfır yasak eylem çıktılar. Yasak bir dış tıklama URL’si içeren bir girdi, değiştirme dalını da çalıştırır. İzin verilen bir tıklama ve yasak bir fare‑üzerinde eylemi olan bir konteyner, tıklama eylemini korur.

Bu seçici temizlik, [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) metodundan farklıdır; bu metod, politika gözetmeksizin seçili kapsamda her iki etkinleştirme türünü de kaldırır. Buradaki doğrulama yalnızca köprü eylemlerini denetler; gömülü VBA projelerini, OLE nesnelerini veya diğer aktif içerikleri kaldırmaz ve dışa aktarılan PDF veya HTML dosyasını doğrulamaz.

## **SSS**

**Bir bölüme ya da onun ilk slaytına nasıl bağlanabilirim?**

PowerPoint’te bölümler slaytları gruplar, ancak dahili bir köprü tek bir slaytı hedefler. Bir bölüme yönlendirme oluşturmak için, o bölümün ilk slaytına bağlayın.

**Master slayt öğelerine köprü ekleyebilir miyim, böylece tüm slaytlarda çalışır?**

Evet. Master slayt ve düzen öğeleri köprüleri destekler. Bu öğelere eklenen bağlantılar, ilgili master veya düzeni kullanan slayt gösterisi sırasında erişilebilir olur.

**Köprüler PDF, HTML, görüntüler veya video olarak dışa aktarıldığında korunur mu?**

Desteklenen PDF ve HTML dışa aktarımları köprüleri koruyabilir; raster görüntüler ve video koruyamaz. Ayrıntılar için [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) bölümündeki dışa aktarım hususlarına bakın.