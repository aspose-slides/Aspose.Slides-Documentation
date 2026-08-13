---
title: Sunumları .NET'te HTML5'e Dönüştür
linktitle: HTML5'e Sunum
type: docs
weight: 40
url: /tr/net/export-to-html5/
keywords:
- PowerPoint'ten HTML5'e
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
description: "PowerPoint ve OpenDocument sunumlarını Aspose.Slides for .NET ile duyarlı HTML5 olarak dışa aktarın. Biçimlendirme, animasyonlar ve etkileşimi koruyun."
---
## **Genel Bakış**

Bu makale, PowerPoint sunumlarını Aspose.Slides kullanarak HTML5'e dönüştürmeyi açıklar. Temel HTML5 dışa aktarmayı ve şekil animasyonları ile slayt geçişlerini kontrol etme seçeneklerini kapsar. Makale ayrıca standart PowerPoint‑to‑HTML dışa aktarma sürecini gösterir, slayt görünüm modunda HTML5 çıktısı oluşturma yöntemini açıklar ve dışa aktarılan belgede yorumları düzenlerini yapılandırarak eklemeyi gösterir.

## **PowerPoint'i HTML5'e Dışa Aktarma**

Bu C# kodu, bir sunumu HTML5'e dışa aktarmayı gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html5);
}
```

{{% alert color="info" %}} 
HTML belgesine ek olarak, dışa aktarım başvurduğu destek dosyalarını yazar: `pres.css`, `master.css`, `animation.js`, `effects.js` ve `navigation.js`. Oluşturulan sayfa ayrıca jQuery ve Anime.js'i ortak CDN'lerden yükler; bunlar olmadan slayt gezinmesi ve animasyonlar çalışmaz. 
{{% /alert %}}

Şekil animasyonları ve slayt geçişleri için ayarları şu şekilde belirtebilirsiniz:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Bu C# kodu, standart PowerPoint‑to‑HTML sürecini gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("pres.html", SaveFormat.Html);
}
```

Bu durumda, sunum içeriği SVG aracılığıyla aşağıdaki biçimde render edilir:

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
Bu yöntemi PowerPoint'i HTML'e dışa aktarmak için kullandığınızda, SVG render'ı nedeniyle belirli öğelere stil uygulayamaz veya animasyon ekleyemezsiniz. 
{{% /alert %}}

## **PowerPoint'i HTML5 Slayt Görünümü Olarak Dışa Aktarma**

**Aspose.Slides**, slaytların slayt görünüm modunda sunulduğu bir HTML5 belgesine PowerPoint sunumunu dönüştürmenizi sağlar. Bu durumda, ortaya çıkan HTML5 dosyasını bir tarayıcıda açtığınızda, sunumu bir web sayfasında slayt görünüm modunda görürsünüz. 

Bu C# kodu, PowerPoint'ten HTML5 Slayt Görünümü dışa aktarma sürecini gösterir:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save("HTML5-slide-view.html", SaveFormat.Html5, new Html5Options
   {
       AnimateShapes = true,
       AnimateTransitions = true
   });
}
```

## **Yorumlu Bir HTML5 Belgesine Sunum Dönüştürme**

PowerPoint'teki yorumlar, kullanıcıların sunum slaytları üzerinde notlar veya geri bildirim bırakmalarını sağlayan bir araçtır. Özellikle ortak projelerde, birden fazla kişinin belirli slayt öğelerine öneri veya açıklama eklemesine olanak tanır ve ana içeriği değiştirmez. Her yorum, yazarın adını gösterir, böylece kimin yorumu bıraktığını kolayca izleyebilirsiniz.

Örneğin, aşağıdaki PowerPoint sunumunun "sample.pptx" dosyasında kaydedildiğini varsayalım.

![Sunum slaytındaki iki yorum](two_comments_pptx.png)

PowerPoint sunumunu HTML5 belgesine dönüştürdüğünüzde, çıktıda yorumların dahil edilip edilmeyeceğini kolayca belirtebilirsiniz. Bunu yapmak için, [Html5Options](https://reference.aspose.com/slides/tr/net/aspose.slides.export/html5options/) sınıfının `NotesCommentsLayouting` özelliğinde yorumların görüntüleme parametrelerini belirtmeniz gerekir.

Aşağıdaki kod örneği, slaytların sağ tarafına yorumlar gösterilerek bir sunumu HTML5 belgesine dönüştürür.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

var html5Options = new Html5Options
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        CommentsPosition = CommentsPositions.Right
    }
};

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.html", SaveFormat.Html5, html5Options);
```

"output.html" belgesi aşağıdaki görüntüde gösterilmiştir.

![HTML5 çıktısındaki yorumlar](two_comments_html5.png)

## **SSS**

### HTML5'te nesne animasyonları ve slayt geçişlerinin oynatılıp oynatılmayacağını kontrol edebilir miyim?

Evet, HTML5, [shape animations](https://reference.aspose.com/slides/tr/net/aspose.slides.export/html5options/animateshapes/) ve [slide transitions](https://reference.aspose.com/slides/tr/net/aspose.slides.export/html5options/animatetransitions/) ayrı ayrı etkinleştirme veya devre dışı bırakma seçenekleri sunar.

### Yorumların çıktısı destekleniyor mu ve slayta göre nerede konumlandırılabilir?

Evet, yorumlar HTML5'te eklenebilir ve notlar ve yorumlar için [layout settings](https://reference.aspose.com/slides/tr/net/aspose.slides.export/html5options/notescommentslayouting/) aracılığıyla (örneğin, slaytın sağına) konumlandırılabilir.

### Güvenlik veya CSP nedenleriyle JavaScript çağıran bağlantıları atlayabilir miyim?

Evet, kaydetme sırasında JavaScript çağrısı içeren hiperlinkleri atlamanızı sağlayan bir [setting](https://reference.aspose.com/slides/tr/net/aspose.slides.export/saveoptions/skipjavascriptlinks/) vardır. Bu, katı güvenlik politikalarına uyum sağlamaya yardımcı olur.