---
title: Sunumları C++ ile HTML5'e Dönüştürme
linktitle: Sunumu HTML5'e
type: docs
weight: 40
url: /tr/cpp/export-to-html5/
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
- C++
- Aspose.Slides
description: "PowerPoint ve OpenDocument sunumlarını C++ için Aspose.Slides ile duyarlı HTML5'e dışa aktarın. Biçimlendirme, animasyonlar ve etkileşimleri koruyun."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarını HTML5'e dönüştürmeyi açıklar. Web uzantıları veya ek bağımlılıklar olmadan temel HTML5 dışa aktarmayı ve şekil animasyonları ile slayt geçişlerini kontrol etme seçeneklerini kapsar. Makale ayrıca standart PowerPoint‑to‑HTML dışa aktarma sürecini gösterir, slayt görünüm modunda HTML5 çıktısı oluşturmayı açıklar ve dışa aktarılan belgede yorumları, düzenlerini yapılandırarak nasıl dahil edeceğinizi gösterir.

## **PowerPoint'i HTML5'e Dışa Aktarma**

Bu C++ kodu, bir sunumu HTML5'e dışa aktarmayı gösterir.

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```

{{% alert color="primary" %}} 
Bu durumda, temiz HTML elde edersiniz. 
{{% /alert %}}

Şekil animasyonları ve slayt geçişleri için ayarları bu şekilde belirtebilirsiniz:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```

## **PowerPoint'i HTML'e Dışa Aktarma**

Bu C++ kodu, standart PowerPoint'ten HTML'e dönüşüm sürecini gösterir:

```cpp
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
        
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
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
PowerPoint'i HTML'e dışa aktarmak için bu yöntemi kullandığınızda, SVG işleme nedeniyle stilleri uygulayamaz veya belirli öğeleri animasyonla hareket ettiremezsiniz. 
{{% /alert %}}

## **PowerPoint'i HTML5 Slayt Görünümüne Dışa Aktarma**

**Aspose.Slides**, bir PowerPoint sunumunu slaytların slayt görünüm modunda gösterildiği bir HTML5 belgesine dönüştürmenizi sağlar. Bu durumda, ortaya çıkan HTML5 dosyasını bir tarayıcıda açtığınızda, sunumu web sayfasında slayt görünüm modunda görürsünüz. 

Bu C++ kodu, PowerPoint'ten HTML5 Slayt Görünümüne dışa aktarma sürecini gösterir:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```

## **Yorumlarla Birlikte Sunumu HTML5 Belgesine Dönüştürme**

PowerPoint'teki yorumlar, kullanıcıların sunum slaytlarına not veya geri bildirim bırakmalarını sağlayan bir araçtır. Özellikle birden çok kişinin belirli slayt öğelerine öneri veya açıklama ekleyebildiği işbirlikli projelerde kullanışlıdır; ana içeriği değiştirmeden. Her yorum, yazarın adını gösterir, böylece yorumu kimin bıraktığını kolayca izleyebilirsiniz.

Diyelim ki aşağıdaki PowerPoint sunumu "sample.pptx" dosyasında kaydedilmiş.

![Sunum slaytında iki yorum](two_comments_pptx.png)

PowerPoint sunumunu HTML5 belgesine dönüştürdüğünüzde, çıktıda sunumun yorumlarını dahil edip etmeyeceğinizi kolayca belirtebilirsiniz. Bunu yapmak için, yorumların görüntüleme parametrelerini `get_NotesCommentsLayouting` metodunda [Html5Options](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/html5options/) sınıfı içinde belirtmeniz gerekir.

Aşağıdaki kod örneği, bir sunumu slaytların sağ tarafında yorumlar gösterilecek şekilde HTML5 belgesine dönüştürür.
```cpp
auto html5Options = MakeObject<Html5Options>();
html5Options->get_NotesCommentsLayouting()->set_CommentsPosition(CommentsPositions::Right);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

"output.html" belgesi aşağıdaki görselde gösterilmiştir.

![Çıktı HTML5 belgesindeki yorumlar](two_comments_html5.png)

## **FAQ**

**HTML5'te nesne animasyonlarının ve slayt geçişlerinin oynatılıp oynatılmayacağını kontrol edebilir miyim?**

Evet, HTML5, [şekil animasyonlarını](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/html5options/set_animateshapes/) ve [slayt geçişlerini](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/html5options/set_animatetransitions/) etkinleştirmek veya devre dışı bırakmak için ayrı seçenekler sunar.

**Yorumların çıktısı destekleniyor mu ve slayta göre nerede konumlandırılabilir?**

Evet, yorumlar HTML5'te eklenebilir ve notlar ile yorumlar için düzen ayarları üzerinden (örneğin, slaytın sağ tarafına) konumlandırılabilir.

**Güvenlik veya CSP nedenleriyle JavaScript çağrısı yapan bağlantıları atlayabilir miyim?**

Evet, kaydetme sırasında JavaScript çağrısı içeren hiperlinkleri atlamanızı sağlayan bir [ayar](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) bulunmaktadır. Bu, katı güvenlik politikalarına uyum sağlamanıza yardımcı olur.