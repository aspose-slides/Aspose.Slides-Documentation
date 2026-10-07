---
title: Aspose.Slides for Node.js via .NET
second_title: Aspose.Slides for Node.js
type: docs
weight: 47
url: /tr/nodejs-net/
keywords:
- dokümantasyon
- sunum işleme
- sunum dönüştürme
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Buradan başlayın: Aspose.Slides for Node.js via .NET'i yükleyin, ilk sunumu oluşturun ve ortak görevler, lisanslama, API referansı ve destek için kılavuzları bulun."
is_root: true
---
<img src="aspose_slides-for-nodejs-via-net.png" alt="Aspose.Slides for Node.js via .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Node.js via .NET, Microsoft PowerPoint veya Office Automation olmadan Node.js uygulamalarında PowerPoint ve OpenDocument sunumları oluşturmak, okumak, düzenlemek ve dönüştürmek için bir kütüphanedir. Aspose.Slides for .NET, edge-js köprüsü üzerinden çalıştırıldığından, JavaScript API'si .NET API'sine benzer ve üye adları camelCase biçimindedir.

PPT, PPTX, PPS, POT ve ODP dosyalarını, makro destekli ve şablon varyantları dahil olmak üzere yükler ve kaydeder; ayrıca PDF, XPS, HTML, TIFF, Markdown ve görsellere dışa aktarır.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Başlarken</b></p>
<hr>
<p>BAŞLANGIÇ</p>
<ul>
<li><a href="/slides/tr/nodejs-net/installation/">Kurulum</a></li>
<li><a href="/slides/tr/nodejs-net/create-presentation/">İlk sunumunuzu oluşturun</a></li>
<li><a href="/slides/tr/nodejs-net/developer-guide/">Geliştirici kılavuzu</a></li>
</ul>
<p>DEĞERLENDİR</p>
<ul>
<li><a href="/slides/tr/nodejs-net/evaluate-aspose-slides/">Deneme sınırlamaları</a></li>
<li><a href="/slides/tr/nodejs-net/licensing/">Lisanslama</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides ile Oluşturun</b></p>
<hr>
<p>ORTAK GÖREVLER</p>
<ul>
<li><a href="/slides/tr/nodejs-net/open-presentation/">Sunumu aç ve kaydet</a></li>
<li><a href="/slides/tr/nodejs-net/convert-powerpoint-to-pdf/">PDF'ye dönüştür</a></li>
<li><a href="/slides/tr/nodejs-net/convert-slide/">Slaytları resim olarak oluştur</a></li>
<li><a href="/slides/tr/nodejs-net/manage-text/">Metni düzenle</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referans ve Destek</b></p>
<hr>
<p>REFERANS</p>
<ul>
<li><a href="https://reference.aspose.com/slides/net/">.NET API referansı</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/release-notes/">Sürüm notları</a></li>
<li><a href="https://products.aspose.com/slides/nodejs-net/">Ürün sayfası</a></li>
<li><a href="https://releases.aspose.com/slides/nodejs-net/">İndir</a></li>
</ul>
<p>DESTEK</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Ücretsiz destek forumu</a></li>
<li><a href="https://helpdesk.aspose.com/">Ücretli destek hizmet masası</a></li>
</ul>
</div>
</div>

------

## **İlk sunumunuz**

Node.js 22 veya 24 ve .NET SDK 8 ya da daha yenisine ihtiyacınız var; Linux ayrıca birkaç sistem paketi gerektirir. [Installation](/slides/tr/nodejs-net/installation/) bunları ve test edilen platformları listeler. Bir proje oluşturun, npm'e hangi edge-js sürümünün kurulacağını söyleyen bir geçersiz kılma ekleyin ve paketi kurun:

```sh
mkdir hello-slides
cd hello-slides
npm init -y
npm pkg set overrides.edge-js=26.1.0
npm install aspose.slides.via.net
```

Makine başına bir kez, kütüphanenin bağımlı olduğu .NET paketlerini geri yükleyin. `deps.csproj` dosyasını [Restore the .NET Dependencies](/slides/tr/nodejs-net/installation/#restore-the-net-dependencies) bölümünden proje klasörünün içindeki bir `deps` klasörüne kaydedin, ardından çalıştırın:

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

    // Konum ve boyut noktalar cinsindendir (1/72 inç): x, y, genişlik, yükseklik.
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    rectangle.addTextFrame("Hello, World!");

    presentation.save("hello.pptx", SaveFormat.Pptx);
    console.log("Saved hello.pptx");
} finally {
    // Sunumu destekleyen .NET nesnesini serbest bırak.
    presentation.dispose();
}
```

Proje klasöründen çalıştırın:

```sh
node hello.js
```

Betik `Saved hello.pptx` çıktısını verir ve *hello.pptx* dosyasını bir slayt içinde metin içeren bir dikdörtgenle kaydeder. Lisans olmadan, kaydedilen dosya bir değerlendirme filigranı taşır — bkz. [Licensing](/slides/tr/nodejs-net/licensing/). Sunum oluşturma ve doldurma hakkında daha fazla bilgi için [Create a Presentation](/slides/tr/nodejs-net/create-presentation/) adresine bakın.