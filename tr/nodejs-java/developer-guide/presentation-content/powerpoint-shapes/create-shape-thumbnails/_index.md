---
title: JavaScript ile Sunum Şekillerinin Küçük Resimlerini Oluşturma
linktitle: Şekil Küçük Resimleri
type: docs
weight: 70
url: /tr/nodejs-java/create-shape-thumbnails/
keywords:
- şekil küçük resmi
- şekil görüntüsü
- şekli render et
- şekil renderleme
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint slaytlarından yüksek kaliteli şekil küçük resimlerini JavaScript ve Aspose.Slides for Node.js ile üretin – sunum küçük resimlerini kolayca oluşturun ve dışa aktarın."
---
## **Giriş**

Aspose.Slides, her sayfanın bir slayt olduğu sunum dosyaları oluşturmak için kullanılır. Bu slaytlar, sunum dosyaları Microsoft PowerPoint ile açılarak görüntülenebilir. Ancak bazen geliştiriciler, şekillerin görüntülerini ayrı bir resim görüntüleyicide görmek isteyebilir. Böyle durumlarda Aspose.Slides, slayt şekillerinin küçük resimlerini oluşturmanıza yardımcı olur. Bu özelliğin nasıl kullanılacağı bu makalede açıklanmıştır.  
Bu makale, slayt küçük resimlerini farklı şekillerde nasıl oluşturacağınızı açıklar:

- Bir slayt içinde şekil küçük resmi oluşturma.
- Kullanıcı tanımlı boyutlarla bir slayt şekli için şekil küçük resmi oluşturma.
- Şeklin görünümünün sınırları içinde şekil küçük resmi oluşturma.

## **Slaytlardan Şekil Küçük Resimleri Oluşturma**
Aspose.Slides for Node.js via Java kullanarak herhangi bir slayttan şekil küçük resmi oluşturmak için şunları yapın:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) sınıfı örneği oluşturun.
2. ID veya indeks kullanarak herhangi bir slaytın referansını alın.
3. [Get the shape thumbnail image](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Shape#getImage--) referans alınan slaytın varsayılan ölçekli şekil küçük resmini alın.
4. Küçük resmi tercih ettiğiniz görüntü formatında kaydedin.

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

## **Kullanıcı Tanımlı Ölçek Faktörüyle Şekil Küçük Resimleri Oluşturma**
Aspose.Slides for Node.js via Java kullanarak bir slaytın şekil küçük resmini oluşturmak için şunları yapın:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) sınıfı örneği oluşturun.
2. ID veya indeks kullanarak herhangi bir slaytın referansını alın.
3. [Get the shape thumbnail image](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Shape#getImage-int-float-float-) referans alınan slaytın kullanıcı tanımlı boyutlarla şekil küçük resmini alın.
4. Küçük resmi tercih ettiğiniz görüntü formatında kaydedin.

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

## **Sınırların Şekil Küçük Resmi Oluşturulması**
Bu yöntem, geliştiricilerin şeklin görünümünün sınırları içinde bir küçük resim oluşturmasına olanak tanır. Tüm şekil efektleri dikkate alınır. Oluşturulan şekil küçük resmi slayt sınırlarıyla sınırlıdır. Bir slayt şeklinin görünümünün sınırları içinde küçük resim oluşturmak için şunları yapın:

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/presentation) sınıfı örneği oluşturun.
2. ID veya indeks kullanarak herhangi bir slaytın referansını alın.
3. Referans alınan slaytın şekil sınırlarını görünüm olarak kullanarak küçük resmini alın.
4. Küçük resmi tercih ettiğiniz görüntü formatında kaydedin.

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

## **SSS**

**Şekil küçük resimleri kaydederken hangi görüntü formatları kullanılabilir?**  
[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/imageformat/), ve diğerleri. Şekiller ayrıca içeriği SVG olarak kaydedilerek [vektör SVG olarak dışa aktarılabilir](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/writeassvg/).

**Küçük resim oluşturulurken Shape ve Appearance sınırları arasındaki fark nedir?**  
`Shape` şeklin geometrisini kullanır; `Appearance` [görsel efektleri](/slides/tr/nodejs-java/shape-effect/) (gölgeler, parlamalar vb.) dikkate alır.

**Bir şekil gizli işaretlenmişse ne olur? Yine de küçük resim olarak oluşturulur mu?**  
Gizli bir şekil modelin bir parçası olarak kalır ve oluşturulabilir; gizli işareti slayt gösterisi görüntüsünü etkiler ancak şeklin görüntüsünün oluşturulmasını engellemez.

**Grup şekilleri, grafikler, SmartArt ve diğer karmaşık nesneler destekleniyor mu?**  
Evet. [Shape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/shape/) olarak temsil edilen herhangi bir nesne ( [GroupShape](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/chart/) ve [SmartArt](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/smartart/) dahil) küçük resim veya SVG olarak kaydedilebilir.

**Sistemde yüklü fontlar metin şekilleri için küçük resim kalitesini etkiler mi?**  
Evet. İstenmeyen yedeklemeler ve metin akışını önlemek için gerekli fontları [sağlamalısınız](/slides/tr/nodejs-java/custom-font/) (veya [font ikamelerini yapılandırmalısınız](/slides/tr/nodejs-java/font-substitution/)).