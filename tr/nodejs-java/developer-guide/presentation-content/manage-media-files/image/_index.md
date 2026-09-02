---
title: Sunumlarda Görüntü Yönetimini JavaScript Kullanarak Optimize Etme
linktitle: Görüntüleri Yönet
type: docs
weight: 10
url: /tr/nodejs-java/image/
keywords:
- görsel ekle
- resim ekle
- görsel değiştir
- görsel koleksiyonu
- resim çerçevesi
- bağlantılı görsel
- arka plan
- PNG ekle
- JPG ekle
- SVG ekle
- SVG'den şekillere
- harici SVG kaynakları
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java ile PowerPoint ve OpenDocument sunumlarında raster ve SVG görselleri eklemeyi, yeniden kullanmayı, bağlamayı, değiştirmeyi ve yönetmeyi öğrenin."
---
## **Giriş**

Aspose.Slides for Node.js via Java, görüntülerle çalışmak için çeşitli yollar sunar ve her biri farklı bir amaca hizmet eder. Bir görüntüyü bir sunum içinde depolayabilir, bir resim çerçevesinde görüntüleyebilir, bir slayt arka planı olarak kullanabilir, harici bir görüntüye bağlayabilir, paylaşılan bir görüntü kaynağını değiştirebilir veya SVG içeriğini düzenlenebilir şekillere dönüştürebilirsiniz.

Bu makale görüntü kaynaklarına ve bunların bir sunum içinde nasıl kullanıldığına odaklanır. Tek bir resim çerçevesine uygulanan kırpma, şeffaflık, efektler, uzatma ve diğer biçimlendirme için, bakınız [Resim Çerçevesi](/slides/tr/nodejs-java/picture-frame/).

## **Görüntü Modelini Anlamak**

Aşağıdaki API kavramları birbirleriyle yakından ilişkili ancak değiştirilebilir değildir:

- [Sunum görüntü koleksiyonu](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/imagecollection/) sunumda kullanılan görüntü kaynaklarını saklar. Görüntü verisini eklemek ve bir [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/) kaynağı elde etmek için [ImageCollection.addImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/imagecollection/) kullanın.
- Bir [resim çerçevesi](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pictureframe/) bir slayt, düzen veya ana üzerinde bir görüntüyü gösteren bir şekildir. Bir görüntü kaynağını slayta yerleştirmek için [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapecollection/) kullanın.
- Bir slayt arka planı, bir şekil yerine slayt doldurmasının bir parçası olarak görüntü kullanır. Bu nedenle bir resim çerçevesi gibi davranmaz.
- [PPImage.replaceImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/) bir görüntü kaynağını değiştirir. Birden fazla sunum öğesi bu kaynağı kullanıyorsa, hepsi değiştirilen versiyonu kullanır.
- Bir SVG'yi şekillere dönüştürmek, düzenlenebilir slayt şekilleri oluşturur. Dönüştürmeden sonra içerik artık tek bir resim kaynağı olarak yönetilmez.

Bu nedenle tipik bir iş akışı şudur: görüntü verisini görüntü koleksiyonuna ekleyin, bir [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/) alın ve ardından bu kaynağı bir veya daha fazla resim çerçevesinde veya doldurmada kullanın.

## **Gömülü Bir Görüntü Ekle**

Yerel bir görüntüyü eklemek için, dosyayı yükleyin, görüntü koleksiyonuna ekleyin ve döndürülen [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/) kaynağını kullanan bir resim çerçevesi oluşturun.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) {
            sourceImage.dispose();
        }
    }

    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, image);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bu şekilde eklenen görüntü sunuma gömülüdür, bu yüzden ortaya çıkan dosya orijinal görüntü dosyasının mevcut olmasına bağlı değildir.

### **Web'den Bir Görüntü Ekle**

Bir görüntü HTTP veya HTTPS üzerinden mevcut olduğunda, baytlarını indirin, bunları sunum görüntü koleksiyonuna ekleyin ve döndürülen görüntü kaynağını yerel bir görüntü gibi aynı şekilde kullanın.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const http = require("http");
const https = require("https");
const java = require("java");

function downloadBytes(url) {
    return new Promise((resolve, reject) => {
        const client = url.startsWith("https:") ? https : http;
        client.get(url, (response) => {
            if (response.statusCode < 200 || response.statusCode >= 300) {
                response.resume();
                reject(new Error(`HTTP ${response.statusCode}`));
                return;
            }

            const chunks = [];
            response.on("data", (chunk) => chunks.push(chunk));
            response.on("end", () => resolve(Buffer.concat(chunks)));
        }).on("error", reject);
    });
}

(async () => {
    const imageData = await downloadBytes("https://example.com/image.png");
    const javaBytes = java.newArray("byte", Array.from(imageData));

    const presentation = new aspose.slides.Presentation();
    try {
        const image = presentation.getImages().addImage(javaBytes);
        const slide = presentation.getSlides().get_Item(0);
        slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, image);

        presentation.save("presentation-from-web.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
})();
```

Uzun süre çalışan uygulamalarda, gereksiz ağ altyapısı oluşturmaktan kaçınmak için uygulamaya uygun bir HTTP istemcisi veya bağlantı yönetim stratejisini tekrar kullanın. Kaynak güvenilir olmadığında uzak URL'leri, yanıt boyutlarını ve içerik türlerini de doğrulayın.

## **Görüntüleri Slaytlar Arasında Yeniden Kullan**

Aynı görüntü birden fazla kez gerekiyorsa, görüntüyü sunuma bir kez ekleyin ve ek resim çerçeveleri oluştururken döndürülen [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/) kaynağını yeniden kullanın. Bu, aynı kaynak verisinin tekrar tekrar yüklenmesini önler ve ortak görüntü kaynağı ile kullanımları arasındaki ilişkiyi açık hâle getirir.

Birçok slaytta otomatik olarak görünmesi gereken grafikler (ör. şirket logosu) için, her slayta eşdeğer bir şekil eklemek yerine resim çerçevesini bir [slayt ustası](/slides/tr/nodejs-java/slide-master/) veya düzen üzerine yerleştirmeyi düşünün.

## **Bir Görüntüyü Slayt Arka Planı Olarak Kullan**

Bir arka plan görüntüsü slayt doldurmasına atanır; bir resim‑çerçevesi şekli olarak eklenmez. Bu, resmin slayt arka planını kaplaması ve normal bir slayt nesnesi gibi işlenmemesi gerektiğinde faydalıdır.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("background.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) {
            sourceImage.dispose();
        }
    }

    const backgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    slide.getBackground().setType(backgroundType);

    const fillType = java.newByte(aspose.slides.FillType.Picture);
    slide.getBackground().getFillFormat().setFillType(fillType);

    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image);

    presentation.save("background-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ek arka plan seçenekleri, ana ve düzen arka planları dahil, için bakınız [Sunum Arka Planı](/slides/tr/nodejs-java/presentation-background/).

## **Gömülü Görüntüler ve Bağlantılı Görüntüler**

Gömülü ve bağlantılı görüntüler farklı taşınabilirlik ve dosya‑boyutu dengelerine sahiptir:

- **Gömülü görüntü:** görüntü verisi sunum içinde depolanır. Sunum kendi içinde bağımsızdır, ancak dosya boyutu görüntü verisini içerir.
- **Bağlantılı görüntü:** sunum, harici bir görüntüye bir yol veya URL depolar. Bu, sunum boyutunu azaltabilir, ancak harici kaynağın sunum açıldığında veya işlendiğinde erişilebilir olması gerekir.

Bir bağlantılı resim, görüntü verisini gömmek yerine [Picture.setLinkPathLong](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picture/) aracılığıyla harici yol veya URL atayarak oluşturulabilir.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, null);
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png");

    presentation.save("linked-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bağlantılı görüntüleri yalnızca dağıtım ortamı harici kaynağa güvenilir bir şekilde erişebildiğinde kullanın. Çevrim dışı çalışması veya sistemler arasında taşınması gereken sunumlar için gömülü görüntüler genellikle daha güvenlidir.

## **SVG Görüntülerle Çalışma**

SVG, vektör bir biçim olduğundan simgeler, diyagramlar ve detay kaybı yaşamadan ölçeklenmesi gereken diğer grafikler için faydalı olabilir. Aspose.Slides, SVG'yi hem bir görüntü kaynağı hem de düzenlenebilir slayt şekilleri için bir kaynak olarak destekler.

### **SVG'yi Görüntü Olarak Ekle**

Bir [SvgImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/svgimage/) oluşturun, görüntü koleksiyonuna ekleyin ve ortaya çıkan görüntü kaynağını bir resim çerçevesine yerleştirin.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const svgContent = fs.readFileSync("icon.svg", "utf8");
    const svgImage = new aspose.slides.SvgImage(svgContent);

    const image = presentation.getImages().addImage(svgImage);
    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 200, image);

    presentation.save("svg-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Harici Kaynaklı SVG Dosyaları**

Bir SVG, harici görüntüler, stil sayfaları veya yazı tiplerine referans verebilir. Bu durumlar için [SvgImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/svgimage/) bir [ExternalResourceResolver](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/externalresourceresolver/) ve temel URI kabul eden yapıcılar sunar. Çözücü, bir göreli URI'yi izin verilen mutlak bir URI'ye eşleyebilir ve istenen kaynak için bir akış döndürebilir.

Çözücü, Aspose.Slides SVG'yi işlerken harici kaynakları kullanılabilir kılar, ancak SVG'yi kendi içinde bağımsız bir belge haline getirmez. SVG'nin taşınabilir kalması gerekiyorsa, gerekli kaynakları SVG içinde gömün; örneğin bağlantılı görüntüler için `data:` URI'ları kullanabilirsiniz.

SVG dosyaları güvenilmeyen kaynaklardan geldiğinde, çözücünün erişebileceği şemaları, dosya konumlarını ve ana bilgisayarları sınırlayın. Ağ çözücüleri ayrıca zaman aşımı, yanıt‑boyutu sınırları ve içerik doğrulaması uygulamalıdır.

### **SVG'yi Düzenlenebilir Şekillere Dönüştür**

Aspose.Slides, bir SVG'yi ilgili PowerPoint komutuna benzer şekilde düzenlenebilir slayt şekilleri grubuna dönüştürebilir.

![PowerPoint Popup Menu](img_01_01.png)

Dönüşümü gerçekleştirmek için SVG görüntüsünü kabul eden [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapecollection/) aşırı yüklemesini kullanın.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const svgContent = fs.readFileSync("diagram.svg", "utf8");
    const svgImage = new aspose.slides.SvgImage(svgContent);

    const slideSize = presentation.getSlideSize().getSize();
    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, slideSize.getWidth(), slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

SVG‑den‑şekil dönüşümünü, bireysel vektör öğelerinin PowerPoint şekilleri olarak düzenlenmesi gerektiğinde kullanın. SVG yalnızca gösterilmesi gerekiyorsa, görüntü olarak tutmak daha basittir ve çok sayıda ayrı şekil oluşturulmasından kaçınılır.

## **Mevcut Bir Görüntü Kaynağını Değiştir**

Mevcut bir görüntü kaynağını değiştirmek istediğinizde [PPImage.replaceImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/) kullanın. Bu, logolar gibi ortak grafikler için özellikle yararlıdır.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const imageToReplace = presentation.getImages().get_Item(0);

    const replacementImage = aspose.slides.Images.fromFile("new-logo.png");
    try {
        imageToReplace.replaceImage(replacementImage);
    } finally {
        if (replacementImage != null) {
            replacementImage.dispose();
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Birden fazla resim çerçevesi, arka plan, ana veya düzen aynı görüntü kaynağını kullanıyorsa, bu kaynağı değiştirmek tüm bu kullanımları günceller. Yalnızca bir resim çerçevesinin değişmesi gerekiyorsa, ortak kaynağı değiştirmek yerine o çerçeveye farklı bir görüntü atayın.

[PPImage.replaceImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/) ayrıca bir bayt dizisi veya başka bir [PPImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/) kabul eden aşırı yüklemeler sunar.

## **Pratik Görüntü Yönetimi Rehberi**

### **Sunum Boyutunu Kontrol Et**

Büyük raster görüntüler bir sunumu gereksiz yere büyük yapabilir. Kullanım amacına uygun boyutlarda kaynak görüntüler kullanın, mümkün olduğunca ortak görüntü kaynaklarını yeniden kullanın ve aynı tam çözünürlüklü grafiğin yinelenen kopyalarını gömmekten kaçının.

Zaten resim çerçevelerine yerleştirilmiş raster resimler için, [PictureFillFormat.compressImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/picturefillformat/) seçilen çözünürlük ve kırpma ayarlarına göre görüntü verisini azaltabilir. Bu, görüntü‑koleksiyonu yönetimi değil, resim‑çerçevesi işleme olduğundan ilgili biçimlendirme işlemleri için bakınız [Resim Çerçevesi](/slides/tr/nodejs-java/picture-frame/).

### **Gömülü ve Bağlantılı İçerik Arasında Seçim Yap**

Gömme, tüm gerekli görüntü verileri dosyayla birlikte taşındığı için sunumu taşınabilir kılar. Bağlantı dosya boyutunu azaltabilir, ancak dış bir bağımlılık getirir. Bağlantıları yalnızca bu bağımlılığın kabul edilebilir ve istikrarlı olduğu durumlarda kullanın.

### **Paylaşılan Markayı Yeniden Kullan**

Tekrarlanan logolar, filigranlar veya süsleyici grafikler için tek bir görüntü kaynağı kullanıp yeniden kullanın. Grafik, slayt içeriği yerine sunum tasarımına aitse, uygun slaytlar tarafından devralınması için bir ana veya düzen üzerine yerleştirin.

### **SVG Kaynaklarını Taşınabilir Tut**

Kendi içinde bağımsız bir SVG, harici dosyalara veya ağ kaynaklarına bağlı bir SVG'ye göre taşınması ve tutarlı bir şekilde işlenmesi daha kolaydır. Mümkün olduğunca, SVG'yi içe aktarmadan önce gerekli kaynakları gömün. SVG'yi şekillere yalnızca bireysel vektör öğelerinin düzenlenmesi gerektiğinde dönüştürün.

### **Modern Çok Platformlu Görüntü API'sını Kullan**

Yeni Node.js via Java kodu için, eski `java.awt.image.BufferedImage` temelli herkese açık API yerine Aspose.Slides [IImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/iimage/) ve [Images](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/images/) API'larını kullanın. Geçiş kılavuzu için bakınız [Modern API](/slides/tr/nodejs-java/modern-api/).

WMF ve EMF özel dikkate ihtiyaç duyar. Bu biçimler bir [IImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/iimage/) üzerinden geçirildiğinde, [ImageCollection.addImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/imagecollection/) eklemeden önce metafili bir raster PNG temsiline dönüştürür. Metafili veriyi korumak önemliyse, akış tabanlı bir [ImageCollection.addImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/imagecollection/) aşırı yüklemesi kullanın. Elektronik tablo veya diğer ürünlerden EMF içeriği üretmek ayrı bir entegrasyon iş akışı olup bu makalenin kapsamı dışındadır.

## **SSS**

**Görüntü koleksiyonu ile resim çerçevesi arasındaki fark nedir?**

Görüntü koleksiyonu yeniden kullanılabilir görüntü kaynaklarını saklar. Resim çerçevesi, bu kaynaklardan birini gösteren bir slayt şeklidir ve kırpma, efektler gibi resme özgü biçimlendirme sağlar.

**Aynı logoyu her yerde değiştirmek için en iyi yol nedir?**

Logo zaten tek bir görüntü kaynağı olarak paylaşılıyorsa, bu kaynağı [PPImage.replaceImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/ppimage/) ile değiştirin. Sunum genelinde marka tutarlılığı için logoyu bir ana veya düzen üzerine yerleştirmek de yinelenen slayt içeriğini azaltabilir.

**Bağlantılı bir görüntü başka bir bilgisayarda neden kaybolur?**

Bağlantılı resim, dış dosya veya URL'ye bağlıdır. O kaynak başka bir bilgisayardan erişilemiyorsa, bağlantılı görüntü kullanılamaz hâle gelir. Sunumun kendi içinde olması gerekiyorsa görüntüyü gömün.

**Eklenen bir SVG PowerPoint şekilleri olarak düzenlenebilir mi?**

Evet. SVG'yi [ShapeCollection.addGroupShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapecollection/) ile dönüştürün; ortaya çıkan grup tek bir SVG resmi yerine düzenlenebilir slayt şekilleri içerir.

**Birçok görüntülü sunumları nasıl daha küçük tutabilirim?**

Ortak görüntü kaynaklarını yeniden kullanın, gereksiz büyük raster kaynaklardan kaçının, uygun olduğunda raster resimleri sıkıştırın, tekrarlanan markayı ana veya düzenlerde tutun ve harici bağımlılık kabul edilebilir olduğunda sadece bağlantılı görüntüler kullanın.