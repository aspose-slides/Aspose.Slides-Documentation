---
title: Sunumları C++'ta HTML5'e Dönüştürme
linktitle: HTML5'e Sunum
type: docs
weight: 40
url: /tr/cpp/export-to-html5/
keywords:
- PowerPoint'ten HTML5'e
- OpenDocument'ten HTML5'e
- Sunumdan HTML5'e
- Slayttan HTML5'e
- PPT'den HTML5'e
- PPTX'ten HTML5'e
- ODP'den HTML5'e
- PPT'yi HTML5 olarak kaydet
- PPTX'i HTML5 olarak kaydet
- ODP'yi HTML5 olarak kaydet
- PPT'yi HTML5'e dışa aktar
- PPTX'i HTML5'e dışa aktar
- ODP'yi HTML5'e dışa aktar
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ kullanarak PowerPoint ve OpenDocument sunumlarını duyarlı HTML5'e dışa aktarın. Biçimlendirme, animasyonlar ve etkileşimi koruyun."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for C++ kullanarak PowerPoint sunumlarını HTML5'e nasıl dönüştüreceğinizi açıklar. Temel dışa aktarmayı, şekil animasyonları ve slayt geçişlerinin kontrolünü ve yorum düzenini kapsar. Ayrıca HTML5 çıktısını standart HTML dışa aktarmanın SVG tabanlı çıktısıyla karşılaştırır.

## **PowerPoint'i HTML5'e Dışa Aktarma**

Aşağıdaki örnek, çalışma dizininden bir sunumu yükler ve HTML5 formatında kaydeder. Varsayılan dışa aktarma ayarlarını kullanır; bir sonraki örnek, animasyon oynatımını açıkça nasıl kontrol edeceğinizi gösterir. Giriş yolunu sunumunuzun yolu ile değiştirin.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres.html", SaveFormat::Html5);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
HTML belgesinin yanı sıra, dışa aktarım slayt stilizasyonu, animasyonlar, efektler ve gezinme için destekleyen CSS ve JavaScript dosyaları yazar. Çıktıyı taşırken veya yayınlarken bu dosyaları HTML belgesi ile birlikte tutun. Oluşturulan sayfa ayrıca jQuery ve Anime.js'i genel CDN'lerden yükler; bunlar olmadan slayt gezinmesi ve animasyonlar çalışmaz.
{{% /alert %}}

Şekil animasyonları veya slayt geçişleri oynatılmadan dışa aktarmak için, [set_AnimateShapes](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) ve [set_AnimateTransitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) yöntemlerine `false` değerini, [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/) içinde geçirin. Bu ayarlar bağımsızdır, bu yüzden birini etkinleştirirken diğerini devre dışı bırakabilirsiniz. Örnek, her iki animasyon türünün de devre dışı bırakıldığı bir sunumu oluşturulan sayfada dışa aktarır.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(false);
html5Options->set_AnimateTransitions(false);

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres5.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

## **PowerPoint'i HTML'e Dışa Aktarma**

Standart HTML dışa aktarma, farklı bir renderleme yaklaşımı kullanır: slayt içeriği, bir HTML sayfası içinde SVG olarak temsil edilir. Aşağıdaki örnek, bu renderleme yaklaşımını kullanarak bir sunumu HTML belgesine dönüştürür.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"pres.html", SaveFormat::Html);
presentation->Dispose();
```

Aşağıdaki basitleştirilmiş işaretleme, oluşturulan sayfanın yapısını gösterir. SVG öğesi, renderlenen slayt içeriğini içerir; yer tutucu metin bu içeriği temsil eder ve gerçek dışa aktarım çıktısı değildir.

```html
<body>
<div class="slide" name="slide" id="slideslideIface1">
     <svg version="1.1">
         <g> THE SLIDE CONTENT GOES HERE </g>
     </svg>
</div>
</body>
```

{{% alert title="Warning" color="warning" %}}
SVG tabanlı dışa aktarma, PowerPoint şekillerini ayrı HTML öğeleri olarak ortaya çıkarmaz. Bu makalede gösterilen şekil animasyonu ve slayt geçişi seçeneklerine ihtiyacınız olduğunda HTML5 dışa aktarımını kullanın.
{{% /alert %}}

## **PowerPoint'i HTML5 Slayt Görünümüne Dışa Aktarma**

HTML5 dışa aktarım, tarayıcıda sunum slaytlarını görüntülemek ve gezinmek için bir sayfa üretir. Bu örnek, dışa aktarılan slayt görünümünün kaynak sunumdaki efektleri oynatabilmesi için hem [set_AnimateShapes](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) hem de [set_AnimateTransitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) yöntemlerine `true` değerini geçirir.

Bu ayarların etkisini görmek için zaten şekil animasyonları ve slayt geçişleri içeren bir sunum kullanın. Etkinleştirilmesi, hiç efekti olmayan slaytlara yeni efekt eklemez. Dışa aktarma sonrası, destek dosyaları mevcutken oluşturulan HTML5 belgesini bir tarayıcıda açın.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_AnimateShapes(true);
html5Options->set_AnimateTransitions(true);

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
presentation->Save(u"HTML5-slide-view.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

## **Bir Sunumu Yorumlarla HTML5 Belgesine Dönüştürme**

Mevcut slayt yorumlarını HTML5 çıktısına dahil edebilirsiniz, böylece okuyucular slayt içeriğinin yanında geri bildirimi görebilir. Bu bölümdeki örnek, kaynak sunumun aşağıda gösterildiği gibi yorumlar içerdiğini varsayar. Yorumları dışa aktarır; yeni yorumlar oluşturmaz.

![Sunum slaytındaki iki yorum](two_comments_pptx.png)

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) nesnesini [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/) içindeki [set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_slideslayoutoptions/) metoduna geçirin. Yorumları her slaydın sağına yerleştirmek için [CommentsPositions](https://reference.aspose.com/slides/cpp/aspose.slides.export/commentspositions/) enumarasyonundan `CommentsPositions::Right` ile [set_CommentsPosition](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/set_commentsposition/) metodunu çağırın.

Aşağıdaki örnek, bu yorum düzeniyle sunumu HTML5'e dışa aktarır. Yorum içermeyen bir sunumda gösterilecek yorum metni bulunmaz.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/CommentsPositions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto layoutOptions = System::MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_CommentsPosition(CommentsPositions::Right);

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_SlidesLayoutOptions(layoutOptions);

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

Aşağıdaki görsel, yorumların slayt yanında gösterildiği dışa aktarılmış HTML5 belgesini gösterir.

![Çıktı HTML5 belgesindeki yorumlar](two_comments_html5.png)

## **Dışa Aktarım Sırasında JavaScript Hiperlinklerini Hariç Tutma**

`hyperlinks.pptx` dosyasının `javascript:alert('Hello')` hedefli bir bağlantılı metin ve normal bir `https://example.com/` bağlantısı içerdiğini varsayalım. Dışa aktarma sırasında JavaScript hiperlinkini hariç tutmak için, [SaveOptions::set_SkipJavaScriptLinks](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) metodunu `true` ile çağırın. Varsayılan değer `false` olduğundan, bu bağlantılar seçeneği etkinleştirene kadar filtrelenmez.

Aşağıdaki örnek, sunumu çalışma dizininden yükler ve [Html5Options](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/) kullanarak dışa aktarır:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
#include <Export/Html5Options.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto html5Options = System::MakeObject<Html5Options>();
html5Options->set_SkipJavaScriptLinks(true);

auto presentation = System::MakeObject<Presentation>(u"hyperlinks.pptx");
presentation->Save(u"filtered-html5.html", SaveFormat::Html5, html5Options);
presentation->Dispose();
```

Dışa aktarılan dosya, JavaScript hiperlinkini göz ardı ederken metnini ve normal HTTPS bağlantısını korur. Kaynak sunum değişmeden kalır.

Bu seçenek JavaScript hiperlinklerini filtreler; tüm scriptleri veya diğer etkin içerikleri kaldırmaz, ayrıca CSP uyumluluğunu garanti etmez. Örneğin, HTML5 çıktısı hâlâ slayt gezinmesi ve animasyonlar için scriptler içerir.

## **SSS**

**HTML5'te nesne animasyonlarının ve slayt geçişlerinin oynatılıp oynatılmayacağını kontrol edebilir miyim?**

Evet, HTML5 dışa aktarım, [shape animations](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animateshapes/) ve [slide transitions](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_animatetransitions/) seçeneklerini etkinleştirmek veya devre dışı bırakmak için ayrı seçenekler sunar.

**Yorumlar destekleniyor mu ve slayta göre nerede konumlandırılabilir?**

Evet, mevcut yorumlar HTML5 çıktısına dahil edilebilir ve notlar ve yorumlar için [layout settings](https://reference.aspose.com/slides/cpp/aspose.slides.export/html5options/set_slideslayoutoptions/) aracılığıyla (örneğin, slaytın sağına) konumlandırılabilir.

**Güvenlik veya CSP nedenleriyle JavaScript çağıran bağlantıları atlayabilir miyim?**

Evet, [set_SkipJavaScriptLinks](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_skipjavascriptlinks/) metodu, kaydetme sırasında JavaScript çağrısı yapan hiperlinkleri atlamanızı sağlar. Varsayılan değer `false`'tir. Bir HTML5 dışa aktarma örneği ve filtrenin kapsamı için [Exclude JavaScript Hyperlinks During Export](/slides/tr/cpp/export-to-html5/#exclude-javascript-hyperlinks-during-export) bölümüne bakın. Bu ayar, HTML5 görüntüleyicisinin gezinme ve animasyonlar için kullandığı JavaScript'i kaldırmaz.