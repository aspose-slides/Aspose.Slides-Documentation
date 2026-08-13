---
title: PowerPoint Sunumlarındaki Köprüleri .NET ile Yönet
linktitle: Köprüyü Yönet
type: docs
weight: 20
url: /tr/net/manage-hyperlinks/
keywords:
- URL ekle
- köprü ekle
- köprü oluştur
- köprü biçimlendir
- köprüyü kaldır
- köprüyü güncelle
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
description: "Aspose.Slides for .NET ile PowerPoint ve OpenDocument sunumlarında köprüleri zahmetsizce yönetin—etkileşimi ve iş akışını dakikalar içinde artırın."
---
## **Giriş**

Bir köprü, bir nesneye, veriye veya bir şeydeki bir konuma referanstır. Bunlar PowerPoint Sunumlarında yaygın köprülerdir:

* Metin, şekil veya medya içindeki web sitesine bağlantılar
* Slaytlara bağlantılar

Aspose.Slides for .NET, sunumlarda köprülerle ilgili birçok görevi gerçekleştirmenizi sağlar.

{{% alert color="info" %}} 
Aspose basit, [ücretsiz çevrimiçi PowerPoint düzenleyicisini](https://products.aspose.app/slides/tr/editor) incelemek isteyebilirsiniz.
{{% /alert %}} 

## **URL Köprüleri Ekle**

### **Metne URL Köprüleri Ekle**

Bu C# kodu, bir metne web sitesi köprüsü eklemenin nasıl yapılacağını gösterir:
```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
	IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.AddTextFrame("Aspose: File Format APIs");
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 32;

	presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

### **Şekillere veya Çerçevelere URL Köprüleri Ekle**

Bu C# örnek kodu, bir şekle web sitesi köprüsü eklemenin nasıl yapılacağını gösterir:
```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);
    
    shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

### **Medyaya URL Köprüleri Ekle**

Aspose.Slides, görüntülere, ses ve video dosyalarına köprü eklemenize olanak tanır. 

Bu örnek kod, bir **görüntüye** köprü eklemenin nasıl yapılacağını gösterir:
```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    // Sunuma görüntü ekler
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    // Daha önce eklenen görüntüyü temel alarak slayt 1'de resim çerçevesi oluşturur
    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);

    pictureFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    pictureFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

Bu örnek kod, bir **ses dosyasına** köprü eklemenin nasıl yapılacağını gösterir:
```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IAudio audio = pres.Audios.AddAudio(File.ReadAllBytes("audio.mp3"));
    IAudioFrame audioFrame = pres.Slides[0].Shapes.AddAudioFrameEmbedded(10, 10, 100, 100, audio);

    audioFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    audioFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

Bu örnek kod, bir **video**'ya köprü eklemenin nasıl yapılacağını gösterir:
``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    IVideo video = pres.Videos.AddVideo(File.ReadAllBytes("video.avi"));
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 100, 100, video);

    videoFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    videoFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

{{%  alert  title="Tip"  color="info"  %}} 
* [OLE Yönetimini](https://docs.aspose.com/slides/tr/net/manage-ole/)* görmek isteyebilirsiniz.
{{% /alert %}}


## **Köprüleri Kullanarak İçindekiler Tablosu Oluşturma**

Köprüler, nesnelere veya konumlara referans eklemenizi sağladığından, bunları bir içindekiler tablosu oluşturmak için kullanabilirsiniz. 

Bu örnek kod, köprülerle bir içindekiler tablosu oluşturmanın nasıl yapılacağını gösterir:
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation())
{
    var firstSlide = presentation.Slides[0];
    var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

    var contentTable = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
    contentTable.FillFormat.FillType = FillType.NoFill;
    contentTable.LineFormat.FillFormat.FillType = FillType.NoFill;
    contentTable.TextFrame.Paragraphs.Clear();

    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    paragraph.Text = "Title of slide 2 .......... ";

    var linkPortion = new Portion();
    linkPortion.Text = "Page 2";
    linkPortion.PortionFormat.HyperlinkManager.SetInternalHyperlinkClick(secondSlide);

    paragraph.Portions.Add(linkPortion);
    contentTable.TextFrame.Paragraphs.Add(paragraph);

    presentation.Save("link_to_slide.pptx", SaveFormat.Pptx);
}
```

## **Köprüleri Biçimlendirme**

### **Renk**

[IHyperlink](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlink) arayüzündeki [ColorSource](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlink/properties/colorsource) özelliği sayesinde, köprülerin rengini ayarlayabilir ve köprülerden renk bilgisi alabilirsiniz. Bu özellik PowerPoint 2019'da ilk kez tanıtıldı, bu nedenle özelliği etkileyen değişiklikler eski PowerPoint sürümlerine uygulanmaz.

Bu örnek kod, farklı renklerdeki köprülerin aynı slayta eklendiği bir işlemi gösterir:
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
    shape1.AddTextFrame("This is a sample of colored hyperlink.");
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.ColorSource = HyperlinkColorSource.PortionFormat;
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;

    IAutoShape shape2 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
    shape2.AddTextFrame("This is a sample of usual hyperlink.");
    shape2.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");

    presentation.Save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
}
```
### **Ses**

Aspose.Slides, bir köprüyü sesle vurgulamanızı sağlayan şu özellikleri sunar:
- [IHyperlink.Sound](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlink/properties/sound) 
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlink/properties/stopsoundonclick)

#### **Köprüye Ses Ekle**

Bu C# kodu, ses çalan bir köprüyü ayarlamayı ve başka bir köprüyle durdurmayı nasıl yapacağınızı gösterir:
```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
	// Sunumun ses koleksiyonuna yeni ses ekler
	IAudio playSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Bir sonraki slayta köprü içeren yeni şekil ekler
	IShape firstShape = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
	firstShape.HyperlinkClick = Hyperlink.NextSlide;

	// Köprüyü "Ses Yok" için denetler
	if (!firstShape.HyperlinkClick.StopSoundOnClick && firstShape.HyperlinkClick.Sound == null)
	{
		// Ses çalan köprüyü ayarlar
		firstShape.HyperlinkClick.Sound = playSound;
	}

	// Boş slaytı ekler 
	ISlide secondSlide = pres.Slides.AddEmptySlide(firstSlide.LayoutSlide);

	// NoAction köprüsü olan yeni şekil ekler
	IShape secondShape = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
	secondShape.HyperlinkClick = Hyperlink.NoAction;

	// Köprü "Önceki sesi durdur" bayrağını ayarlar
	secondShape.HyperlinkClick.StopSoundOnClick = true;

	pres.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
}
```

#### **Köprü Sesini Çıkar**

Bu C# kodu, bir köprüde kullanılan sesi nasıl çıkaracağınızı gösterir:
```c#
using Aspose.Slides;

using (Presentation pres = new Presentation("hyperlink-sound.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// İlk şeklin köprüsünü alır
	IHyperlink link = firstSlide.Shapes[0].HyperlinkClick;

	if (link.Sound != null)
	{
		// Köprü sesini bayt dizisine çıkarır
		byte[] audioData = link.Sound.BinaryData;
	}
}
```

## **Sunumlardan Köprüleri Kaldırma**

### **Metinden Köprüleri Kaldırma**

Bu C# kodu, bir sunum slaydındaki metinden köprüyü nasıl kaldıracağınızı gösterir:
```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        IAutoShape autoShape = shape as IAutoShape;
        if (autoShape != null)
        {
            foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
            {
                foreach (IPortion portion in paragraph.Portions)
                {
                    portion.PortionFormat.HyperlinkManager.RemoveHyperlinkClick();
                }
            }
        }
    }
    
    pres.Save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
}
```

### **Şekillerden veya Çerçevelerden Köprüleri Kaldırma**

Bu C# kodu, bir sunum slaydındaki bir şekilden köprüyü nasıl kaldıracağınızı gösterir: 
``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("demo.pptx")) 
{ 
   ISlide slide = pres.Slides[0]; 
   foreach (IShape shape in slide.Shapes) 
     { 
       shape.HyperlinkManager.RemoveHyperlinkClick(); 
     } 
   pres.Save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx); 
}
```

## **Değiştirilebilir Köprü**

[Hyperlink](https://reference.aspose.com/slides/tr/net/aspose.slides/hyperlink) sınıfı değiştirilebilirdir. Bu sınıfı kullanarak aşağıdaki özelliklerin değerlerini değiştirebilirsiniz:

- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlink/properties/highlightclick)

Kod parçacığı, bir slayta köprü eklemeyi ve daha sonra araç ipucunu düzenlemeyi nasıl yapacağınızı gösterir:
```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{   
   IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);    
    
   shape1.AddTextFrame("Aspose: File Format APIs");
    
   shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";
    
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 32;
    
 presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **IHyperlinkQueries'te Desteklenen Özellikler**

Köprünün tanımlı olduğu bir sunum, slayt veya metinden IHyperlinkQueries'e erişebilirsiniz. 

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/tr/net/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/tr/net/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/tr/net/aspose.slides/itextframe/properties/hyperlinkqueries)

IHyperlinkQueries sınıfı şu yöntem ve özellikleri destekler: 

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/tr/net/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)

## **SSS**

### Sadece bir slayta değil, bir "bölüm"e ya da bir bölümün ilk slaytına yönelik iç gezinme nasıl oluşturabilirim?
PowerPoint'teki bölümler, slayt gruplarıdır; gezinme teknik olarak belirli bir slaytı hedefler. Bir “bölüme gezinmek” için genellikle bölümün ilk slaytına bağlanırsınız.

### Ana slayt öğelerine bir köprü ekleyebilir miyim, böylece tüm slaytlarda çalışır?
Evet. Ana slayt ve düzen öğeleri köprüleri destekler. Bu tür bağlantılar alt slaytlarda görünür ve slayt gösterisi sırasında tıklanabilir.

### Köprüler PDF, HTML, görüntüler veya video olarak dışa aktarılırken korunur mu?
[PDF](/slides/tr/net/convert-powerpoint-to-pdf/) ve [HTML](/slides/tr/net/convert-powerpoint-to-html/) formatlarında evet—bağlantılar genellikle korunur. [Görüntüler](/slides/tr/net/convert-powerpoint-to-png/) ve [video](/slides/tr/net/convert-powerpoint-to-video/) formatlarına dışa aktarırken, bu formatların doğası gereği (raster çerçeveler/video yönlendirmeleri desteklemez) tıklanabilirlik taşınmaz.