---
title: Sunum Köprülerini .NET'te Yönet
linktitle: Köprüleri Yönet
type: docs
weight: 20
url: /tr/net/manage-hyperlinks/
keywords:
- URL ekle
- Köprü ekle
- Köprü oluştur
- Köprüyü biçimlendir
- Köprü kaldır
- Köprüyü güncelle
- Metin köprüsü
- Slayt köprüsü
- Şekil köprüsü
- Resim köprüsü
- Video köprüsü
- Değiştirilebilir köprü
- PowerPoint
- OpenDocument
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET kullanarak C# örnekleriyle PowerPoint ve OpenDocument sunumlarında köprüleri ekleyin, biçimlendirin, güncelleyin ve kaldırın."
---
## **Giriş**

Bir köprü, sunum içeriğini bir web sitesine veya sunum içindeki bir konuma bağlar. PowerPoint'te köprüler genellikle iki amaca hizmet eder:

* Metinden, bir şekilden veya bir medya çerçevesinden bir web sitesi açın.
* Örneğin içindekiler tablosundan başka bir slayta gidin.

Aspose.Slides for .NET, bu bağlantıları eklemenize, görünüm ve seslerini kontrol etmenize, özelliklerini güncellemenize ve kaldırmanıza olanak tanır. Aşağıdaki örnekler, tek tek öğelerde köprülerle nasıl çalışılacağını ve sunum, slayt veya metin‑çerçevesi seviyesinde köprülere nasıl erişileceğini gösterir.

{{% alert color="info" title="Note" %}}
Sunumları ayrıca [ücretsiz çevrimiçi Aspose PowerPoint editörü](https://products.aspose.app/slides/tr/editor) ile düzenleyebilirsiniz.
{{% /alert %}} 

## **URL Köprüleri Ekleme**

Metne, bir şekle veya bir medya çerçevesine bir web sitesi URL'si atayabilirsiniz. Köprünün atanacağı öğe, tıklanabilir alanı belirler: bir metin bölümü seçili metni bağlarken, bir şekil veya çerçeve slayt nesnesini bağlar.

### **Metne URL Köprüsü Ekleme**

Metni bir web sitesine bağlamak için, aşağıda gösterildiği gibi metin bölümünün [HyperlinkClick](https://reference.aspose.com/slides/tr/net/aspose.slides/portionformat/hyperlinkclick/) özelliğine bir [Hyperlink](https://reference.aspose.com/slides/tr/net/aspose.slides/hyperlink/) atayın. Yalnızca o metin bölümü tıklanabilir hâle gelir.

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

### **Şekillere ve Medya Çerçevelerine URL Köprüsü Ekleme**

Bir şekli veya çerçeveyi tıklanabilir yapmak için [HyperlinkClick](https://reference.aspose.com/slides/tr/net/aspose.slides/shape/hyperlinkclick/) özelliğini ayarlayın. Köprü, içinde bir metin bölümü bulunan nesneye değil, nesnenin kendisine aittir.

Aynı yaklaşım resim, ses ve video çerçeveleri için de geçerlidir: köprüyü çerçeveye atayın ve gerekirse bağlantının [Tooltip](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlink/tooltip/) özelliğini belirleyin.

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

## **İçindekiler Tablosu Oluşturmak için Köprü Kullanma**

Dahili köprüler, okuyucuların içindekiler tablosundan belirli bir slayta atlamasını sağlar. Aşağıdaki örnek, ilk slaydın “Page 2” metnini ikinci slayta bağlamak için [SetInternalHyperlinkClick](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) metodunu kullanır.

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

[IHyperlink](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlink/) nesnesinin [ColorSource](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlink/colorsource/) özelliği, köprünün sunumun köprü rengi mi yoksa metin bölümünün biçimlendirmesi mi kullanacağını belirler. Özel bir metin rengi uygulamak için [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/hyperlinkcolorsource/) seçin ve bölümün dolgu rengini ayarlayın. Bu özellik PowerPoint 2019’da tanıtıldı; daha eski sürümler bu ayarı uygulamaz.

Aşağıdaki örnek aynı slayta iki metin köprüsü ekler. İlkinde kırmızı metin dolgusu kullanılırken, ikincisi varsayılan köprü rengini korur.

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

Bir köprü etkinleştirildiğinde ses çalabilir veya hâlihazırda çalan bir sesi durdurabilir. Bu davranışları yapılandırmak için aşağıdaki özellikleri kullanın:

- [IHyperlink.Sound](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlink/sound/) köprüye atanmış sesi belirler.
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlink/stopsoundonclick/) köprünün tıklanmasıyla önceki sesin durdurulup durdurulmayacağını kontrol eder.

#### **Köprüye Ses Ekleme**

Aşağıdaki örnek `sampleaudio.wav` dosyasını yükler ve ilk slaydın bir düğmesine ilişkilendirir. Düğmeye tıklandığında ses çalar ve bir sonraki slayta geçilir. Aynı slayttaki ikinci bir şekil, tıklandığında sesi durdurur; ancak bir geçiş eylemi gerçekleştirmez.

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

Aşağıdaki örnek, yukarıda oluşturulan sunumu açar ve ilk şeklin köprü sesini [Sound](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlink/sound/) ve [BinaryData](https://reference.aspose.com/slides/tr/net/aspose.slides/iaudio/binarydata/) aracılığıyla belleğe okur.

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

Bir köprüyü metne veya şekle atadıktan sonra aşağıdaki [IHyperlink](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlink/) özelliklerini güncelleyebilirsiniz:

- [Tooltip](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlink/tooltip/) izleyicinin bağlantı için bir ipucu olarak görüntüleyebileceği metni ayarlar.
- [TargetFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlink/targetframe/) uygulanabilir olduğunda, üst HTML çerçeve kümesindeki hedef çerçeveyi belirtir.
- [History](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlink/history/) bağlantının etkinleştirilmesinin hedefinin görüntülenen köprüler listesine eklenip eklenmeyeceğini denetler.
- [HighlightClick](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlink/highlightclick/) tıklanma sırasında köprünün vurgulanıp vurgulanmayacağını kontrol eder.

## **Sunumlardan Köprüleri Kaldırma**

Köprü konteynerlerini (metin‑bölümü bağlantıları dahil) toplamak için [GetAnyHyperlinks](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) metodunu kullanın. Aşağıdaki örnek, ilk slayttaki her iki etkinleştirme türünü de kaldırır. Yalnızca bir türü kaldırmak isterseniz, sadece [RemoveHyperlinkClick](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) veya [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) metodunu çağırın; bir tıklama eylemini kaldırmak, fare‑üzerinde eylemi kaldırmaz.

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

Koşulsuz kaldırma için, [RemoveAllHyperlinks](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) seçilen kapsamda her iki etkinleştirme türünü tek bir çağrıyla siler. Ustalık, yerleşim ve notların da kapsandığı seçici temizlik için **[Raporla, Temizle ve Köprüleri Doğrula](#report-sanitize-and-verify-hyperlinks)** bölümüne bakın.

## **Tam Bir Köprü Envanteri Oluşturma**

Sunumu dağıtmadan önce, interaktif eylemlerini ve web bağlantılarını envantere alın. [GetAnyHyperlinks](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) yöntemi, düz bir URL listesi yerine [IHyperlinkContainer](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlinkcontainer/) nesneleri döndürür. Her konteynerde hem [HyperlinkClick](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/) hem de [HyperlinkMouseOver](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/) incelenmelidir. Bağımsızdırlar: aynı konteyner her iki eylemi de içerebilir; bu nedenle tam bir rapor, konteyner başına iki satır gerektirebilir.

Yalnızca şekil‑seviyesi köprüleri taramak, metin bölümlerine eklenmiş bağlantıları kaçırabilir. Bunun yerine uygun kapsamı sorgulayın ve döndürülen konteynerleri saklayın; böylece daha sonra eylemlerini güncelleyebilir veya kaldırabilirsiniz.

### **Sunum, Slayt ve Metin‑Çerçevesi Kapsamlarını Sorgulama**

[IHyperlinkQueries](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlinkqueries/) arabirimi, [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentation/hyperlinkqueries/), [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/tr/net/aspose.slides/ibaseslide/hyperlinkqueries/) ve [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/hyperlinkqueries/) aracılığıyla kullanılabilir. Her kapsam aynı sorguları destekler:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) tıklama eylemi içeren konteynerleri döndürür.
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) fare‑üzerinde eylemi içeren konteynerleri döndürür.
- [GetAnyHyperlinks](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) bir ya da iki eylemi içeren konteynerleri döndürür.

Aşağıdaki örnek, dış tıklama bağlantısı, dosya fare‑üzerinde bağlantısı, dahili slayt gezinmesi, metin fare‑üzerinde bağlantısı ve bir makro eylemi içeren `hyperlink-audit-input.pptx` dosyasını oluşturur. Hiçbir eylem yürütülmez. Üç sorgu her kapsamda aynı şekilde çalışır; sayımlar eylem toplamı değil, konteyner sayısını gösterir. Metin‑çerçevesi kapsamı, içinde bulunduğu şeklin kendi bağlantılarını dışlar.

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

Bu örnek için, sunum ve slayt sorguları her biri üç tıklama konteyneri, iki fare‑üzerinde konteyner ve bir ya da iki eylemi olan üç konteyner raporlar. Metin‑çerçevesi sorgusu her kategori için bir konteyner raporlar.

### **Eylemleri ve Hedefleri Sınıflandırma**

Bir hedefi yorumlamadan önce eylemi yorumlamak için [IHyperlink.ActionType](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlink/actiontype/) kullanın. [HyperlinkActionType](https://reference.aspose.com/slides/tr/net/aspose.slides/hyperlinkactiontype/) değerleri, yalnızca web gezinmesinden daha fazlasını kapsar:

| Values | Meaning for an audit |
| --- | --- |
| `Hyperlink` | Dış köprü; URL ve şemasını inceleyin. |
| `JumpSpecificSlide` | Belirli bir slayta dahili gezinme. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Slayt gösterisi içinde kullanılan yerleşik gezinme komutları. |
| `JumpEndShow`, `StartCustomSlideShow` | Mevcut gösteriyi sonlandırma veya özel gösteri başlatma. |
| `StartMacro` | Bir makroyu çalıştırma. |
| `StartProgram` | Bir programı başlatma. |
| `OpenFile`, `OpenPresentation` | Bir dosya veya başka bir sunumu açma; web URL'lerinden ayrı olarak incelenmelidir. |
| `StartStopMedia` | Medya oynatımını başlatma veya durdurma. |
| `NoAction`, `Unknown` | Gezinti eylemi yok veya tanımlanamayan eylem; gözden geçirilmelidir. |

Dış hedefleri [ExternalUrl](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlink/externalurl/) üzerinden, belirli dahili hedefleri ise [TargetSlide](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlink/targetslide/) üzerinden okuyun. Dahili eylemler ve yerleşik komutlar dış URL içermeyebilir; boş bir URL, konteynerin eylemi olmadığı anlamına gelmez. Normalleştirilmiş URL'den farklıysa [ExternalUrlOriginal](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlink/externalurloriginal/) değerini koruyun ve mevcutsa [Tooltip](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlink/tooltip/) ekleyin.

### **Köprüleri Raporlama, Temizleme ve Doğrulama**

Aşağıdaki .NET 6+ örneği, mevcut bir sunumu (yukarıda oluşturulan dosyayı) okur, `hyperlink-audit.json` yazar, bir politika uygular, `hyperlink-sanitized.pptx` kaydeder ve ardından iki etkinleştirme türünü tekrar denetlemek için dosyayı yeniden açar. Değiştirmeden önce konteynerleri toplar ve aynı konteynerin iki kez işlenmesini önlemek için referans eşitliğini kullanır. Sunum sorguları sıradan slaytları kapsar; paket‑geneli envanter için ayrıca ustalar, yerleşimler, notlar ve varsa not ve el ilanı ustaları açıkça sorgulanır.

Rapor, 1‑tabanlı bir slayt indeksi ve mevcutsa [SlideId](https://reference.aspose.com/slides/tr/net/aspose.slides/ibaseslide/slideid/) içerir. [ISlideComponent.Slide](https://reference.aspose.com/slides/tr/net/aspose.slides/islidecomponent/slide/) desteklenen konteynerler için sahibi slaytı sağlar. Ustalar, yerleşimler ve notlar sıradan slayt indeksi almaz; kapsamlarıyla tanımlanır. Şekil konteynerleri ve metin‑bölümü biçimlendirme konteynerleri ayrı ayrı etiketlenir; diğer konteyner tipleri çalışma zamanı tür adını korur. Her konteyner, iki eylemin ilişkilendirilebilmesi için rapor‑yerel bir kimlik alır.

Bu kısıtlayıcı uygulama politikası, yalnızca mutlak HTTPS URL'lerini ve geçerli dahili slayt hedeflerini kabul eder. Makrolar, programlar, dosya eylemleri, diğer slayt gösterisi eylemleri, bilinmeyen eylemler ve diğer URL şemaları reddedilir. Bu reddetmeler politika kararlarıdır; Aspose.Slides güvenlik kararı değildir. HTTPS tek başına güvenilirlik sağlamaz: uygulamanız için host beyaz listeleri ve ek kontroller ekleyin. Hem orijinal hem de normalleştirilmiş dış URL'ler kontrol edilir. Örnek, bağlantıları takip etmeden veya eylemleri çalıştırmadan meta verileri denetler.

Düzeltme için, konteynerin [HyperlinkManager](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/) **[SetExternalHyperlinkClick](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/)**, **[RemoveHyperlinkClick](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/)** ve **[RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/)** metodlarını destekler. Burada, yasak dış tıklama bağlantıları sabit bir HTTPS açılış sayfasıyla değiştirilir; diğer yasak tıklama ve yasak fare‑üzerinde eylemler bağımsız olarak kaldırılır. Tüm politika ihlallerini kaldırmak için `replaceExternalClicks` değerini `false` yapın. Dağıtıma önce uygulama‑sahibi bir yedekleme sayfası seçin.

Raporun dışa aktarma işareti, temkinli bir PDF inceleme politikasını kullanır: fare‑üzerinde eylemler ve dış link olmayan ya da belirli bir slayt atlaması olmayan her şey potansiyel olarak desteklenmez olarak işaretlenir. Bu bir inceleme ipucu olup, bir yetenek testi veya işaretlenmemiş bağlantıların dışa aktarımda korunacağı garantisi değildir. Desteklenen [PDF](/slides/tr/net/convert-powerpoint-to-pdf/) ve [HTML](/slides/tr/net/convert-powerpoint-to-html/) dışa aktarmaları, eyleme, dışa aktarma seçeneklerine ve görüntüleyiciye bağlı olarak köprüleri koruyabilir. Raster [images](/slides/tr/net/convert-powerpoint-to-png/) ve [video](/slides/tr/net/convert-powerpoint-to-video/) interaktif köprüleri koruyamaz; bu çıktılar için denetimde her eylemi işaretleyin.

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

Yukarıdaki girişle oluşturulan rapor beş eylem satırı içerir. Dosya fare‑üzerinde bağlantısı ve makro tıklaması kaldırılırken, HTTPS bağlantıları ve dahili slayt gezinmesi kalır. Doğrulama, sıfır yasak eylem çıktılar. Yasak bir dış tıklama URL'si içeren bir giriş, değiştirme dalını da çalıştırır. İzin verilen bir tıklama ve yasak bir fare‑üzerinde eylemi olan bir konteyner, tıklama eylemini korur.

Bu seçici temizlik, **[RemoveAllHyperlinks](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/)** metodundan farklıdır; bu metod, politika gözetmeksizin seçilen kapsamda her iki etkinleştirme türünü de kaldırır. Buradaki doğrulama yalnızca köprü eylemlerini denetler; gömülü VBA projelerini, OLE nesnelerini veya diğer aktif içerikleri kaldırmaz ve dışa aktarılmış bir PDF veya HTML dosyasını doğrulamaz.

## **SSS**

**Bir bölüme veya onun ilk slaytına nasıl bağlanabilirim?**

PowerPoint bölümleri slaytları gruplar, ancak dahili bir köprü bireysel bir slaytı hedefler. Bir bölüme gezinme oluşturmak için, o bölümün ilk slaytına bağlayın.

**Usta slayt öğelerine köprü ekleyebilir miyim, böylece tüm slaytlarda çalışır?**

Evet. Üst (master) slayt ve yerleşim öğeleri köprüleri destekler. Bu öğelere eklenen bağlantılar, ilgili ustayı veya yerleşimi kullanan slayt gösterisi sırasında kullanılabilir.

**Köprüler PDF, HTML, görüntüler veya video olarak dışa aktarıldığında korunur mu?**

Desteklenen PDF ve HTML dışa aktarmaları köprüleri koruyabilir; raster görüntüler ve videolar koruyamaz. Ayrıntılar için **[Raporla, Temizle ve Köprüleri Doğrula](#report-sanitize-and-verify-hyperlinks)** bölümündeki dışa aktarma hususlarına bakın.