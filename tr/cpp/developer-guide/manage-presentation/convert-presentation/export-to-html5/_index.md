---
title: C++ ile Sunumları HTML5'e Dönüştür
linktitle: Sunumu HTML5'e
type: docs
weight: 40
url: /tr/cpp/export-to-html5/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ ile PowerPoint ve OpenDocument sunumlarını duyarlı HTML5'e dışa aktarın. Formatlamayı, animasyonları ve etkileşimleri koruyun."
---
## **Genel Bakış**

Bu makale, Aspose.Slides kullanarak PowerPoint sunumlarını HTML5'e nasıl dönüştüreceğinizi açıklar. Web uzantıları veya ek bağımlılıklar olmadan temel HTML5 dışa aktarmayı, şekil animasyonları ve slayt geçişlerini kontrol etme seçeneklerini kapsar. Makale ayrıca standart PowerPoint‑to‑HTML dışa aktarma sürecini gösterir, slayt görünümü modunda HTML5 çıktısı oluşturmayı açıklar ve düzen ayarlarıyla dışa aktarılan belgede yorumları nasıl ekleyeceğinizi gösterir.

## **PowerPoint'i HTML5'e Dışa Aktar**

Bu C++ kodu, bir sunumu HTML5'e nasıl dışa aktaracağınızı gösterir.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html5);
```

{{% alert color="info" %}}Bu durumda temiz HTML elde edersiniz.{{% /alert %}}

Şekil animasyonları ve slayt geçişleri için ayarları şu şekilde belirtebilirsiniz:

```cpp
#include <DOM/Presentation.h>
#include <Export/Html5Options.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto options = System::MakeObject<Html5Options>();
options->set_AnimateShapes(true);
options->set_AnimateTransitions(true);
pres->Save(u"pres.html", SaveFormat::Html5, options);
```

## **PowerPoint'i HTML'e Dışa Aktar**

Bu C++ kodu, standart PowerPoint‑to‑HTML sürecini gösterir:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.html", SaveFormat::Html);
```

Bu durumda, sunum içeriği aşağıdaki gibi SVG aracılığıyla oluşturulur:

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Not" color="warning" %}}Bu yöntemi PowerPoint'i HTML'e aktarmak için kullandığınızda, SVG render'ı nedeniyle stilleri uygulayamaz veya belirli öğeleri canlandıramazsınız.{{% /alert %}}

## **PowerPoint'i HTML5 Slayt Görünümüne Dışa Aktar**

**Aspose.Slides**, sunum slaytlarının bir slayt görünümü modunda sunulduğu bir HTML5 belgesine dönüştürmenizi sağlar. Bu durumda, elde edilen HTML5 dosyasını bir tarayıcıda açtığınızda sunumu bir web sayfasında slayt görünümü modunda görürsünüz.

Bu C++ kodu, PowerPoint‑to‑HTML5 Slayt Görünümü dışa aktarma sürecini gösterir:

```c++
#include <DOM/Presentation.h>
#include <Export/Html5Options.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);
pres->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
```

## **Yorumlu bir HTML5 Belgesine Sunum Dönüştürme**

PowerPoint yorumları, kullanıcıların sunum slaytlarına notlar veya geri bildirim bırakmasını sağlayan bir araçtır. Birden fazla kişinin belirli slayt öğelerine öneri veya açıklama ekleyebildiği işbirlikçi projelerde özellikle faydalıdır; ana içeriği değiştirmeden. Her yorum, yazarın adını gösterir, böylece yorumu kimin bıraktığını kolayca izleyebilirsiniz.

Örneğin, aşağıdaki PowerPoint sunumunun "sample.pptx" dosyasında saklandığını varsayalım.

![Sunum slaytındaki iki yorum](two_comments_pptx.png)

PowerPoint sunumunu bir HTML5 belgesine dönüştürdüğünüzde, çıktıya yorumları dahil edip etmeyeceğinizi kolayca belirtebilirsiniz. Bunu yapmak için, [Html5Options](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/html5options/) sınıfının `get_NotesCommentsLayouting` metodunda yorumların görüntüleme parametrelerini belirtmeniz gerekir.

Aşağıdaki kod örneği, yorumların slaytların sağ tarafında gösterildiği bir HTML5 belgesine dönüşümü gerçekleştirir.
```cpp
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/Html5Options.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto layoutingOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutingOptions->set_CommentsPosition(CommentsPositions::Right);

auto html5Options = MakeObject<Html5Options>();
html5Options->set_SlidesLayoutOptions(layoutingOptions);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

Aşağıdaki görselde "output.html" belgesi gösterilmiştir.

![Çıktı HTML5 belgesindeki yorumlar](two_comments_html5.png)

## **SSS**

### HTML5'te nesne animasyonları ve slayt geçişlerinin oynatılıp oynatılmayacağını kontrol edebilir miyim?

Evet, HTML5, [şekil animasyonlarını](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/html5options/set_animateshapes/) ve [slayt geçişlerini](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/html5options/set_animatetransitions/) etkinleştirmek veya devre dışı bırakmak için ayrı seçenekler sunar.

### Yorum çıktısı destekleniyor mu ve slayta göre nerede konumlandırılabilir?

Evet, yorumlar HTML5'te eklenebilir ve notlar ile yorumlar için düzen ayarlarıyla (örneğin slaytın sağ tarafına) konumlandırılabilir.

### Güvenlik veya CSP nedenleriyle JavaScript çağrısı yapan bağlantıları atlayabilir miyim?

Evet, kaydetme sırasında JavaScript çağrısı içeren hiperlinkleri atlamanızı sağlayan bir [ayar](https://reference.aspose.com/slides/tr/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) vardır. Bu, katı güvenlik politikalarına uyum sağlamaya yardımcı olur.