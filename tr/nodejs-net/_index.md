---
title: Aspose.Slides for Node.js via .NET
second_title: Aspose.Slides for Node.js
type: docs
weight: 47
url: /tr/nodejs-net/
keywords:
- dokümantasyon
- sunum işleme
- sunum dönüşümü
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Buradan başlayın: Aspose.Slides for Node.js via .NET'i kurun, ilk sunumunuzu oluşturun ve ortak görevler, lisanslama, API referansı ve destek için kılavuzları bulun."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-net.png" alt="Aspose.Slides for Node.js via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Node.js via .NET, Microsoft PowerPoint veya Office Otomasyonu gerektirmeden Node.js uygulamalarında PowerPoint ve OpenDocument sunumları oluşturmak, okumak, düzenlemek ve dönüştürmek için bir kütüphanedir. Edge‑js köprüsü aracılığıyla Aspose.Slides for .NET çalıştırılır, bu yüzden JavaScript API'si .NET API'sine eşdeğerdir ve camelCase üye adlarını kullanır.

PPT, PPTX, PPS, POT ve ODP dosyalarını, makro destekli ve şablon çeşitleri dahil olmak üzere yükleyip kaydeder ve PDF, XPS, HTML, TIFF, Markdown ve görsellere dışa aktarır.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Başlayın</b></p>
<hr>
<p>GETTING STARTED</p>
<ul>
<li><a href="/slides/tr/nodejs-net/installation/">Kurulum</a></li>
<li><a href="/slides/tr/nodejs-net/create-presentation/">İlk sunumunuzu oluşturun</a></li>
<li><a href="/slides/tr/nodejs-net/developer-guide/">Geliştirici rehberi</a></li>
</ul>
<p>EVALUATE</p>
<ul>
<li><a href="/slides/tr/nodejs-net/evaluate-aspose-slides/">Deneme sınırlamaları</a></li>
<li><a href="/slides/tr/nodejs-net/licensing/">Lisanslama</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides ile Oluşturun</b></p>
<hr>
<p>COMMON TASKS</p>
<ul>
<li><a href="/slides/tr/nodejs-net/open-presentation/">Sunumu aç ve kaydet</a></li>
<li><a href="/slides/tr/nodejs-net/convert-powerpoint-to-pdf/">PDF'ye dönüştür</a></li>
<li><a href="/slides/tr/nodejs-net/convert-slide/">Slaytları görüntü olarak oluştur</a></li>
<li><a href="/slides/tr/nodejs-net/manage-text/">Metni düzenle</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referans &amp; Destek</b></p>
<hr>
<p>REFERENCE</p>
<ul>
<li><a href="https://reference.aspose.com/slides/tr/net/">.NET API referansı</a></li>
<li><a href="https://releases.aspose.com/slides/tr/nodejs-net/release-notes/">Sürüm notları</a></li>
<li><a href="https://releases.aspose.com/slides/tr/nodejs-net/">İndirme</a></li>
</ul>
<p>SUPPORT</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/tr/11">Ücretsiz destek forumu</a></li>
<li><a href="https://helpdesk.aspose.com/">Ücretli destek yardım masası</a></li>
</ul>
</div>
</div>

------

## **İlk sunumunuz**

Node.js 22 veya 24 ve .NET SDK 8 veya üzeri gerekir; Linux ayrıca birkaç sistem paketi gerektirir. [Installation](/slides/tr/nodejs-net/installation/) bunları ve test edilmiş platformları listeler. Bir proje oluşturun, npm'in hangi edge‑js sürümünü kuracağını belirten bir geçersiz kılma ekleyin ve paketi kurun:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
npm install aspose.slides.via.net
```

Her makinede bir kez, kütüphanenin bağımlı olduğu .NET paketlerini geri yükleyin. `deps.csproj` dosyasını [Restore the .NET Dependencies](/slides/tr/nodejs-net/installation/#restore-the-net-dependencies) adresinden proje klasörünün içinde bir `deps` klasörüne kaydedin, ardından çalıştırın:

```sh
dotnet restore deps/deps.csproj
```

Bu kodu proje klasöründe *hello.js* olarak kaydedin:

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

// Yeni bir sunum bir boş slayt içerir.
const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Konum ve boyut, noktalar (1/72 inç) cinsindendir: x, y, genişlik, yükseklik.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // .NET nesnesi, sunumu destekleyen, serbest bırakılır.
    presentation.dispose();
}
```

Proje klasöründen çalıştırın:

```sh
node hello.js
```

Komut dosyası `Saved hello.pptx` mesajını yazdırır ve *hello.pptx* dosyasını bir slayt içinde metin içeren bir dikdörtgenle kaydeder. Lisans olmadan kaydedilen dosya bir değerlendirme filigranı taşır — bakınız [Licensing](/slides/tr/nodejs-net/licensing/). Sunum oluşturma ve doldurma hakkında daha fazla bilgi için [Create a Presentation](/slides/tr/nodejs-net/create-presentation/) sayfasına bakın.