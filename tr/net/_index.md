---
title: Aspose.Slides for .NET
second_title: Aspose.Slides for .NET
type: docs
weight: 10
url: /tr/net/
keywords:
- dokümantasyon
- sunum işleme
- sunum dönüştürme
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Buradan başlayın: Aspose.Slides for .NET'i kurun, ilk sunumunuzu oluşturun ve ortak görevler, dağıtım ve API referansı için kılavuzları bulun."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for .NET, Microsoft PowerPoint veya Office Otomasyonu olmadan .NET uygulamalarında PowerPoint ve OpenDocument sunumları oluşturmak, okumak, düzenlemek ve dönüştürmek için bir sınıf kitaplığıdır.

Makro destekli ve şablon çeşitleri dahil olmak üzere PPT, PPTX, PPS, POT ve ODP dosyalarını yükler ve kaydeder; ayrıca PDF, XPS, HTML, SVG, TIFF, Markdown ve görüntüler olarak dışa aktarır.

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
<li><a href="/slides/tr/net/system-requirements/">Sistem gereksinimleri</a></li>
<li><a href="/slides/tr/net/getting-started/">Başlangıç kılavuzu</a></li>
</ul>
<p>DEĞERLENDİR</p>
<ul>
<li><a href="/slides/tr/net/supported-file-formats/">Desteklenen dosya formatları</a></li>
<li><a href="/slides/tr/net/features-overview/">Özellikler özeti</a></li>
<li><a href="/slides/tr/net/evaluate-aspose-slides/">Deneme sınırlamaları</a></li>
<li><a href="/slides/tr/net/licensing/">Lisanslama</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides ile Oluştur</b></p>
<hr>
<p>ORTAK GÖREVLER</p>
<ul>
<li><a href="/slides/tr/net/open-presentation/">Sunumu aç</a></li>
<li><a href="/slides/tr/net/save-presentation/">Sunumu kaydet</a></li>
<li><a href="/slides/tr/net/convert-powerpoint-to-pdf/">PDF'ye dönüştür</a></li>
<li><a href="/slides/tr/net/convert-slide/">Slaytları görüntü olarak işley</a></li>
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
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-.NET">GitHub'da örnekler</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Yayınlama &amp; Destek</b></p>
<hr>
<p>YAYINLA</p>
<ul>
<li><a href="/slides/tr/net/net6/">Çapraz platform (.NET 6+)</a></li>
<li><a href="/slides/tr/net/how-to-run-aspose-slides-in-docker/">Docker'da çalıştır</a></li>
<li><a href="/slides/tr/net/deploy-fonts/">Yazı tipleri</a></li>
<li><a href="/slides/tr/net/security/">Güvenlik</a></li>
</ul>
<p>REFERANSLAR</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">API referansı</a></li>
<li><a href="https://releases.aspose.com/slides/net/release-notes/">Sürüm notları</a></li>
<li><a href="/slides/tr/net/known-issues/">Bilinen sorunlar</a></li>
<li><a href="/slides/tr/net/api-limitations/">Çıktı meta verisi sınırlamaları</a></li>
<li><a href="https://products.aspose.com/slides/net/">Ürün sayfası</a></li>
<li><a href="https://releases.aspose.com/slides/net/">İndirme</a></li>
</ul>
<p>DESTEK</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Ücretsiz destek forumu</a></li>
<li><a href="https://helpdesk.aspose.com/">Ödemeli destek hizmet masası</a></li>
</ul>
</div>
</div>

------

<a name="your-first-presentation"></a>

## **İlk sunumunuz**

.NET SDK 6 veya daha yeni bir sürümle bir konsol uygulaması oluşturun:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

Ardından platformunuz için bir paket ekleyin:

- Windows'ta: `dotnet add package Aspose.Slides.NET`
- Linux ve macOS'ta: `dotnet add package Aspose.Slides.NET6.CrossPlatform` — Linux ön koşulu ve Aspose.Slides.NET gerektiren sistemler için [Kurulum](/slides/tr/net/installation/) sayfasına bakın.

Program.cs* içeriğini bu kodla değiştirin ve `dotnet run` komutunu çalıştırın:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

Program, bir metin kutusu içeren bir slayt ile *hello.pptx* dosyasını kaydeder. Lisans olmadan, kaydedilen dosya bir değerlendirme filigranı içerir — [Lisanslama](/slides/tr/net/licensing/) sayfasına bakın. Sunum oluşturma ve doldurma konusunda daha fazla yöntem için [Sunum Oluşturma](/slides/tr/net/create-presentation/) sayfasına bakın.