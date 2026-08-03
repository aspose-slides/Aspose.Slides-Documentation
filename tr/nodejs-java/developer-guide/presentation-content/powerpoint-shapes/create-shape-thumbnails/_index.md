---
title: JavaScript ile Sunum Şekillerinin Küçük Resimlerini Oluşturma
linktitle: Şekil Küçük Resimleri
type: docs
weight: 70
url: /tr/nodejs-java/create-shape-thumbnails/
keywords:
- şekil küçük resmi
- şekil görüntüsü
- şekil renderleme
- şekil renderleme
- görsel sınırlar
- şekil sınırları
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript ve Aspose.Slides for Node.js kullanarak PowerPoint slaytlarından yüksek kaliteli şekil küçük resimleri oluşturun – sunum küçük resimlerini kolayca oluşturun ve dışa aktarın."
---
## **Giriş**

Aspose.Slides, her sayfanın bir slayt olduğu sunum dosyaları oluşturmak için kullanılır. Bu slaytlar, Microsoft PowerPoint kullanarak sunum dosyalarını açarak görüntülenebilir. Ancak bazen geliştiricilerin şekillerin görüntülerini ayrı bir görüntüleyicide görmek istemeleri gerekebilir. Bu gibi durumlarda Aspose.Slides, slayt şekillerinin küçük resim görüntülerini oluşturmanıza yardımcı olur. Bu özelliğin nasıl kullanılacağı bu makalede açıklanmıştır.

Bu makale, slayt küçük resimlerini farklı şekillerde oluşturmayı açıklar:

- Bir slayt içinde şekil küçük resmi oluşturma.
- Kullanıcı tanımlı boyutlarla bir slayt şekli için şekil küçük resmi oluşturma.
- Bir şeklin görünüm sınırları içinde şekil küçük resmi oluşturma.

## **Slaytlardan Şekil Küçük Resimleri Oluşturma**

Aspose.Slides for Node.js via Java kullanarak herhangi bir slayttan şekil küçük resmi oluşturmak için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. Bir slaydın referansını ID’si ya da indeksiyle alın.
1. Referans alınan slaydın varsayılan ölçek üzerindeki [şekil küçük resmi görüntüsünü](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Shape#getImage--) alın.
1. Küçük resmi tercih ettiğiniz görüntü formatında kaydedin.

Bu örnek kod, bir slayttan şekil küçük resmi nasıl oluşturulacağını gösterir:

```javascript
// Sunum dosyasını temsil eden bir Presentation sınıfını örnekleyin
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Tam ölçekli bir görüntü oluşturun
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    // Görüntüyü PNG formatında diske kaydedin
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Kullanıcı Tanımlı Ölçek Faktörü ile Şekil Küçük Resimleri Oluşturma**

Aspose.Slides for Node.js via Java kullanarak bir slaydın şekil küçük resmini oluşturmak için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. Bir slaydın referansını ID’si ya da indeksiyle alın.
1. Referans alınan slaydın kullanıcı tanımlı boyutlarla [şekil küçük resmi görüntüsünü](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Shape#getImage-int-float-float-) alın.
1. Küçük resmi tercih ettiğiniz görüntü formatında kaydedin.

Bu örnek kod, tanımlı bir ölçek faktörüne dayalı olarak şekil küçük resmini nasıl oluşturacağınızı gösterir:

```javascript
// Sunum dosyasını temsil eden bir Presentation sınıfını örnekleyin
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Tam ölçekli bir görüntü oluşturun
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Shape, 1, 1);
    // Görüntüyü PNG formatında diske kaydedin
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Sınırların Şekil Küçük Resmini Oluşturma**

Bu yöntem, geliştiricilerin şeklin görünüm sınırları içinde bir küçük resim oluşturmasına olanak tanır. Tüm şekil efektlerini dikkate alır. Oluşturulan şekil küçük resmi slayt sınırlarıyla kısıtlanır. Bir slayt şeklinin görünüm sınırları içinde bir küçük resim oluşturmak için şu adımları izleyin:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) sınıfının bir örneğini oluşturun.
1. Bir slaydın referansını ID’si ya da indeksiyle alın.
1. Referans alınan slaydın, şekil sınırlarını görünüm olarak kullanarak küçük resim görüntüsünü alın.
1. Küçük resmi tercih ettiğiniz görüntü formatında kaydedin.

Bu örnek kod yukarıdaki adımlara dayanarak hazırlanmıştır:

```javascript
// Sunum dosyasını temsil eden bir Presentation sınıfını örnekleyin
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // Tam ölçekli bir görüntü oluşturun
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Appearance, 1, 1);
    // Görüntüyü PNG formatında diske kaydedin
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Bir Şeklin Gerçek Görsel Sınırlarını Alın**

[Shape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/) sınıfının çerçeve özellikleri — `getX()`, `getY()`, `getWidth()` ve `getHeight()` metotları — sunum modelinde saklanan dikdörtgeni tanımlar. Gerçekten render edilen içerik bu çerçevenin dışına taşabilir veya farklı bir eksen hizalı dikdörtgeni kapsayabilir. Dönme, kenarlıklar, ok uçları, metin yerleşimi ve taşma, oluşturulan SmartArt geometrisi ve diğer render efektleri, kapsanan alanı tümüyle değiştirebilir.

[Shape.getVisualBounds](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/#getVisualBounds--) metodunu kullanarak bir görüntü oluşturmadan bu kapsanan alanı hesaplayabilirsiniz. Metot, slayt koordinatlarında bir [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) nesnesi döndürür. Döndürülen dikdörtgen slayta kırpılmadığından, içerik slayt orijininin dışına taşarsa koordinatları negatif olabilir.

Aşağıdaki örnek, çerçeve ve görsel sınırları alır ve karşılaştırır:

```javascript
const presentation = new aspose.slides.Presentation("example.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);

    const visualBounds = shape.getVisualBounds();

    const frameBounds = {
        x: shape.getX(),
        y: shape.getY(),
        width: shape.getWidth(),
        height: shape.getHeight()
    };
    const visualBoundsValues = {
        x: visualBounds.getX(),
        y: visualBounds.getY(),
        width: visualBounds.getWidth(),
        height: visualBounds.getHeight()
    };

    console.log(
        `Frame bounds (x, y, width, height): ${frameBounds.x}, ${frameBounds.y}, ${frameBounds.width}, ${frameBounds.height}`
    );
    console.log(
        `Visual bounds (x, y, width, height): ${visualBoundsValues.x}, ${visualBoundsValues.y}, ${visualBoundsValues.width}, ${visualBoundsValues.height}`
    );
} finally {
    presentation.dispose();
}
```

Aynı dikdörtgen, yakındaki şekilleri sol, sağ, üst veya alt kenarına hizalamak; oluşturulan bir yerleşimde yeterli alan ayırmak; ya da izin verilen bir bölgenin dışındaki içeriği tespit etmek için kullanılabilir. Görsel sınırlar özellikle SmartArt, metin kutuları, oklar, resimler, döndürülmüş şekiller ve grup şekilleri için faydalıdır; çünkü saklanan çerçeve tam render sonucunu temsil etmeyebilir.

Yerleşim veya doğrulama için koordinatlara ihtiyacınız olduğunda ve bitmap gerekmediğinde [Shape.getVisualBounds](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/#getVisualBounds--) metodunu kullanın. Şekli render etmeniz gerektiğinde ise [Shape.getImage](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/#getImage--) metodunu kullanın. [ShapeThumbnailBounds](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shapethumbnailbounds/) ile `ShapeThumbnailBounds.Shape`, kenarlık ayarları dahil şekil sınırlarından görüntüyü boyutlandırırken, `ShapeThumbnailBounds.Appearance` görüntüyü şeklin görünümünden boyutlandırır ve sonucu slayt sınırlarıyla kısıtlar. Buna karşılık, [Shape.getVisualBounds](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/#getVisualBounds--) yalnızca hesaplanan dikdörtgeni döndürür ve slayta kırpmaz.

## **FAQ**

**Şekil küçük resimleri kaydederken hangi görüntü formatları kullanılabilir?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/imageformat/), ve diğerleri. Şekiller ayrıca şeklin içeriği SVG olarak kaydedilerek [vektör SVG olarak dışa aktarılabilir](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/writeassvg/).

**Bir küçük resim render edilirken Shape ve Appearance sınırları arasındaki fark nedir?**

`Shape`, şeklin geometrisini kullanır; `Appearance` ise [görsel efektleri](/slides/tr/nodejs-java/shape-effect/) (gölgeler, parıltılar vb.) dikkate alır.

**Bir şekil gizli olarak işaretlenirse ne olur? Yine de bir küçük resim olarak render edilir mi?**

Gizli bir şekil modelin bir parçası olarak kalır ve render edilebilir; gizli bayrağı slayt gösterisi görüntüsünü etkiler ancak şeklin görüntüsünün oluşturulmasını engellemez.

**Grup şekilleri, grafikler, SmartArt ve diğer karmaşık nesneler destekleniyor mu?**

Evet. [Shape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/) olarak temsil edilen herhangi bir nesne (örneğin [GroupShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chart/), ve [SmartArt](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/smartart/)) küçük resim olarak ya da SVG olarak kaydedilebilir.

**Sistemde yüklü fontlar, metin şekilleri için küçük resim kalitesini etkiler mi?**

Evet. İstenmeyen yedekleme ve metin akışını önlemek için [gerekli fontları sağlamalısınız](/slides/tr/nodejs-java/custom-font/) (veya [font ikamelerini yapılandırmalısınız](/slides/tr/nodejs-java/font-substitution/)).