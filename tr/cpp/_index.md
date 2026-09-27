---
title: Aspose.Slides for C++
second_title: Aspose.Slides for C++
type: docs
weight: 30
url: /tr/cpp/
keywords:
- belgeler
- sunum işleme
- sunum dönüştürme
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Başlangıç: Aspose.Slides for C++'ı kurun, ilk bir sunum oluşturun ve ortak görevler, API referansı ve destek için kılavuzları bulun."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for C++" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for C++ Microsoft PowerPoint veya Office Automation olmadan PowerPoint ve OpenDocument sunumları oluşturmak, okumak, düzenlemek ve dönüştürmek için yerel bir C++ kitaplığıdır.

PPT, PPTX, PPS, POT ve ODP dosyalarını, makro etkin ve şablon varyantları dahil olmak üzere yükler ve kaydeder; ayrıca PDF, XPS, HTML, SVG, TIFF, Markdown ve görüntülere dışa aktarır.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Başlarken</b></p>
<hr>
<p>GETTING STARTED</p>
<ul>
<li><a href="/slides/tr/cpp/installation/">Kurulum</a></li>
<li><a href="/slides/tr/cpp/create-presentation/">İlk sunumunuzu oluşturun</a></li>
<li><a href="/slides/tr/cpp/getting-started/">Başlangıç rehberi</a></li>
</ul>
<p>EVALUATE</p>
<ul>
<li><a href="/slides/tr/cpp/supported-file-formats/">Desteklenen dosya biçimleri</a></li>
<li><a href="/slides/tr/cpp/evaluate-aspose-slides/">Deneme sınırlamaları</a></li>
<li><a href="/slides/tr/cpp/licensing/">Lisanslama</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Kaydırıcılarla Oluştur</b></p>
<hr>
<p>ORTAK GÖREVLER</p>
<ul>
<li><a href="/slides/tr/cpp/open-presentation/">Bir sunumu aç</a></li>
<li><a href="/slides/tr/cpp/save-presentation/">Bir sunumu kaydet</a></li>
<li><a href="/slides/tr/cpp/convert-powerpoint-to-pdf/">PDF'e dönüştür</a></li>
<li><a href="/slides/tr/cpp/convert-slide/">Slaytları resim olarak işleme</a></li>
<li><a href="/slides/tr/cpp/manage-text/">Metin ve şekilleri düzenle</a></li>
</ul>
<p>SLAYT İŞ AKIŞLARI</p>
<ul>
<li><a href="/slides/tr/cpp/powerpoint-charts/">Grafikler</a></li>
<li><a href="/slides/tr/cpp/powerpoint-animation/">Animasyonlar</a></li>
<li><a href="/slides/tr/cpp/manage-media-files/">Ses ve video</a></li>
<li><a href="/slides/tr/cpp/presentation-design/">Slayt tasarımı</a></li>
<li><a href="/slides/tr/cpp/merge-presentation/">Sunumları birleştir</a></li>
</ul>
<p>ÖRNEKLER</p>
<ul>
<li><a href="/slides/tr/cpp/examples/">Slayt öğesine göre örnekler</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-C">GitHub üzerindeki örnekler</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referans &amp; Destek</b></p>
<hr>
<p>REFERANSLAR</p>
<ul>
<li><a href="https://reference.aspose.com/slides/tr/cpp/">API referansı</a></li>
<li><a href="https://releases.aspose.com/slides/tr/cpp/release-notes/">Sürüm notları</a></li>
<li><a href="/slides/tr/cpp/known-issues/">Bilinen sorunlar</a></li>
<li><a href="https://releases.aspose.com/slides/tr/cpp/">İndir</a></li>
</ul>
<p>DESTEK</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/tr/11">Ücretsiz destek forumu</a></li>
<li><a href="https://helpdesk.aspose.com/">Ücretli destek hizmet masası</a></li>
</ul>
</div>
</div>

------

## **İlk sunumunuz**

Windows'ta, Visual Studio'da bir C++ **Console App** projesi oluşturun ve NuGet paketini Package Manager Console (**Tools** > **NuGet Package Manager** > **Package Manager Console**) üzerinden yükleyin:

```powershell
Install-Package Aspose.Slides.Cpp
```

Linux'ta, Linux ZIP paketini indirin ve [Kurulum](/slides/tr/cpp/installation/#linux) bölümünde açıklanan CMake projesini kurun.

Ardından bu kodu programınızın ana kaynak dosyası olarak kullanın. Bir metin kutusu içeren bir sunum oluşturur ve kaydeder:

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/ITextFrame.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

int main()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    shape->get_TextFrame()->set_Text(u"Hello, Aspose.Slides!");
    presentation->Save(u"hello.pptx", SaveFormat::Pptx);
    presentation->Dispose();
    return 0;
}
```

Windows'ta çalıştırmak için, araç çubuğunda **x64** platformunu seçin ve **Ctrl+F5** tuşlarına basın. Linux'ta, proje klasöründe *main.cpp* olarak kaydedin, ardından burada derleyip çalıştırın:

```bash
cmake -S . -B build -DCMAKE_BUILD_TYPE=Release
cmake --build build
./build/hello
```

Program, bir metin kutusu içeren bir slayt ile *hello.pptx* dosyasını kaydeder. Lisans olmadan, kaydedilen dosya bir değerlendirme filigranı taşır — [Lisanslama](/slides/tr/cpp/licensing/) bölümüne bakın. Sunum oluşturma ve doldurma hakkında daha fazla bilgi için [Sunum Oluşturma](/slides/tr/cpp/create-presentation/) sayfasına bakın.