---
title: Aspose.Slides for .NET
second_title: Aspose.Slides for .NET
type: docs
weight: 10
url: /tr/net/
keywords:
- belgeleme
- sunum işleme
- sunum dönüştürme
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Buradan başlayın: Aspose.Slides for .NET'i kurun, ilk sunumunuzu oluşturun ve ortak görevler, API referansı ve destek için kılavuzları bulun."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for .NET, Microsoft PowerPoint veya Office Automation olmadan, .NET uygulamalarında PowerPoint ve OpenDocument sunumları oluşturmak, okumak, düzenlemek ve dönüştürmek için bir sınıf kitaplığıdır.

Macro etkin ve şablon varyantları da dahil olmak üzere PPT, PPTX, PPS, POT ve ODP dosyalarını yükler ve kaydeder, ayrıca PDF, XPS, HTML, SVG, TIFF, Markdown ve görüntüler olarak dışa aktarır.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Başlarken</b></p>
<hr>
<p>BAŞLANGIÇ</p>
<ul>
<li><a href="/slides/tr/net/installation/">Kurulum</a></li>
<li><a href="/slides/tr/net/create-presentation/">İlk sunumunuzu oluşturun</a></li>
<li><a href="/slides/tr/net/getting-started/">Başlangıç kılavuzu</a></li>
</ul>
<p>DEĞERLENDİR</p>
<ul>
<li><a href="/slides/tr/net/supported-file-formats/">Desteklenen dosya biçimleri</a></li>
<li><a href="/slides/tr/net/evaluate-aspose-slides/">Deneme sınırlamaları</a></li>
<li><a href="/slides/tr/net/licensing/">Lisanslama</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides ile Oluşturun</b></p>
<hr>
<p>ORTAK GÖREVLER</p>
<ul>
<li><a href="/slides/tr/net/open-presentation/">Sunum aç</a></li>
<li><a href="/slides/tr/net/save-presentation/">Sunumu kaydet</a></li>
<li><a href="/slides/tr/net/convert-powerpoint-to-pdf/">PDF'ye dönüştür</a></li>
<li><a href="/slides/tr/net/convert-slide/">Slaytları görüntü olarak oluştur</a></li>
<li><a href="/slides/tr/net/manage-text/">Metin ve şekilleri düzenle</a></li>
</ul>
<p>SLAYT İŞ AKIŞLARI</p>
<ul>
<li><a href="/slides/tr/net/powerpoint-charts/">Grafikler</a></li>
<li><a href="/slides/tr/net/powerpoint-animation/">Animasyonlar</a></li>
<li><a href="/slides/tr/net/manage-media-files/">Ses ve video</a></li>
<li><a href="/slides/tr/net/presentation-design/">Slayt tasarımı</a></li>
<li><a href="/slides/tr/net/merge-presentation/">Sunumları birleştir</a></li>
</ul>
<p>ÖRNEKLER</p>
<ul>
<li><a href="/slides/tr/net/examples/">Slayt öğesine göre örnekler</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-.NET">GitHub üzerindeki örnekler</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referans ve Destek</b></p>
<hr>
<p>REFERANS</p>
<ul>
<li><a href="https://reference.aspose.com/slides/tr/net/">API referansı</a></li>
<li><a href="https://releases.aspose.com/slides/tr/net/release-notes/">Sürüm notları</a></li>
<li><a href="/slides/tr/net/known-issues/">Bilinen sorunlar</a></li>
<li><a href="https://releases.aspose.com/slides/tr/net/">İndirme</a></li>
</ul>
<p>DESTEK</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/tr/11">Ücretsiz destek forumu</a></li>
<li><a href="https://helpdesk.aspose.com/">Ücretli destek hizmeti</a></li>
</ul>
</div>
</div>

------

## **İlk sunumunuz**

.NET SDK 6 veya üstü ile bir konsol uygulaması oluşturun:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

Ardından platformunuz için bir paket ekleyin:

- On Windows: `dotnet add package Aspose.Slides.NET`
- On Linux and macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform` — Linux ön koşulu ve Aspose.Slides.NET gerektiren sistemler hakkında bilgi için [Kurulum](/slides/tr/net/installation/) bölümüne bakın.

*Program.cs* içeriğini bu kodla değiştirin ve `dotnet run` komutunu çalıştırın:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

Program, bir metin kutusu içeren bir slayt ile *hello.pptx* dosyasını kaydeder. Lisans olmadan, kaydedilen dosya bir değerlendirme filigranı içerir — [Lisanslama](/slides/tr/net/licensing/) bölümüne bakın. Sunum oluşturmanın ve doldurmanın daha fazla yolu için [Sunum Oluşturma](/slides/tr/net/create-presentation/) bölümüne bakın.