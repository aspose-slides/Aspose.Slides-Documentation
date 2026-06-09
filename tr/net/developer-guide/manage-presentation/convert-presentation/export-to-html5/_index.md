---
title: Sunumları .NET'te HTML5'e Dönüştür
linktitle: Sunumu HTML5'e
type: docs
weight: 40
url: /tr/net/export-to-html5/
keywords:
- PowerPoint'tan HTML5'e
- OpenDocument'ten HTML5'e
- sunumdan HTML5'e
- slayttan HTML5'e
- PPT'den HTML5'e
- PPTX'den HTML5'e
- ODP'den HTML5'e
- PPT'yi HTML5 olarak kaydet
- PPTX'i HTML5 olarak kaydet
- ODP'yi HTML5 olarak kaydet
- PPT'yi HTML5'e dışa aktar
- PPTX'i HTML5'e dışa aktar
- ODP'yi HTML5'e dışa aktar
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ile PowerPoint ve OpenDocument sunumlarını duyarlı HTML5'e dışa aktarın. Biçimlendirme, animasyonlar ve etkileşimi koruyun."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarını HTML5'e dönüştürmeyi açıklar. Web uzantıları veya ek bağımlılıklar olmadan temel HTML5 dışa aktarmayı ve şekil animasyonları ile slayt geçişlerini kontrol etme seçeneklerini kapsar. Makale ayrıca standart PowerPoint‑to‑HTML dışa aktarım sürecini gösterir, slayt görünüm modunda HTML5 çıktısının nasıl oluşturulacağını açıklar ve dışa aktarılan belgede yorumları düzenleyerek nasıl ekleyeceğinizi gösterir.

## **PowerPoint'i HTML5'e Dışa Aktarma**

Bu C# kodu, web uzantıları ve bağımlılıklar olmadan bir sunumu HTML5'e nasıl dışa aktaracağınızı gösterir:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```

{{% alert color="primary" %}} 
Bu durumda, temiz HTML elde edersiniz. 
{{% /alert %}}

Şekil animasyonları ve slayt geçişleri için ayarları şu şekilde belirtebilirsiniz:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres5.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = false,
       AnimateTransitions = false
   });
}
```

## **PowerPoint'i HTML'e Dışa Aktarma**

Bu C# örneği, standart PowerPoint‑to‑HTML sürecini gösterir:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
```

Bu durumda, sunum içeriği aşağıdaki gibi bir SVG biçiminde işlenir:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Note" color="warning" %}} 
Bu yöntemi kullanarak PowerPoint'i HTML'e dışa aktardığınızda, SVG işleme nedeniyle belirli öğelere stil uygulama veya animasyon ekleme imkanı olmayacaktır. 
{{% /alert %}}

## **PowerPoint'i HTML5 Slayt Görünümüyle Dışa Aktarma**

**Aspose.Slides**, bir PowerPoint sunumunu slaytların slayt görünümü modunda sunulduğu bir HTML5 belgesine dönüştürmenize izin verir. Bu durumda, oluşturulan HTML5 dosyasını bir tarayıcıda açtığınızda sunumu bir web sayfasında slayt görünümü modunda görürsünüz. 

Bu C# kodu, PowerPoint'i HTML5 Slayt Görünümü dışa aktarım sürecini gösterir:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("HTML5-slide-view.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = true,
       AnimateTransitions = true
   });
}
```

## **Yorumlarla Bir HTML5 Belgesi Olarak Sunumu Dönüştürme**

PowerPoint'teki yorumlar, kullanıcıların sunum slaytlarına not veya geri bildirim bırakmalarını sağlayan bir araçtır. Özellikle birden fazla kişinin belirli slayt öğelerine öneri veya not ekleyebildiği ortak projelerde faydalıdır; ana içeriği değiştirmeden. Her yorum, yazarın adını gösterir, böylece yorumu kimin bıraktığını takip etmek kolaydır.

Örnek olarak, "sample.pptx" dosyasında aşağıdaki PowerPoint sunumunun bulunduğunu varsayalım.

![Sunum slaytındaki iki yorum](two_comments_pptx.png)

PowerPoint sunumunu bir HTML5 belgesine dönüştürdüğünüzde, çıktıda yorumların dahil edilip edilmemesini kolayca belirtebilirsiniz. Bunu yapmak için, yorumların görüntülenme parametrelerini `NotesCommentsLayouting` özelliği üzerinden [Html5Options](https://reference.aspose.com/slides/tr/net/aspose.slides.export/html5options/) sınıfında belirtmeniz gerekir.

Aşağıdaki kod örneği, bir sunumu slaytların sağ tarafına yorumlar yerleştirilmiş bir HTML5 belgesine dönüştürür.
```cs
var html5Options = new Html5Options
{
    NotesCommentsLayouting =
    {
        CommentsPosition = CommentsPositions.Right
    }
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

"output.html" belgesi aşağıdaki görselde gösterilmiştir.

![Çıktı HTML5 belgesindeki yorumlar](two_comments_html5.png)

## **SSS**

**HTML5'te nesne animasyonları ve slayt geçişlerinin oynatılıp oynatılmayacağını kontrol edebilir miyim?**

Evet, HTML5, [şekil animasyonlarını](https://reference.aspose.com/slides/tr/net/aspose.slides.export/html5options/animateshapes/) ve [slayt geçişlerini](https://reference.aspose.com/slides/tr/net/aspose.slides.export/html5options/animatetransitions/) etkinleştirme veya devre dışı bırakma seçenekleri sunar.

**Yorum çıktısı destekleniyor mu ve slayta göre nerede konumlandırılabilir?**

Evet, yorumlar HTML5'te eklenebilir ve notlar ve yorumlar için [düzen ayarları](https://reference.aspose.com/slides/tr/net/aspose.slides.export/html5options/notescommentslayouting/) aracılığıyla (örneğin slaytın sağına) konumlandırılabilir.

**Güvenlik veya CSP nedenleriyle JavaScript çağrısı yapan bağlantıları atlayabilir miyim?**

Evet, kaydetme sırasında JavaScript çağrısı içeren köprüleri atlamanızı sağlayan bir [ayar](https://reference.aspose.com/slides/tr/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) vardır. Bu, katı güvenlik politikalarına uyum sağlamanıza yardımcı olur.