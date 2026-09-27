---
title: Node.js üzerinden .NET ile Sunum Oluşturma
linktitle: Sunum Oluştur
type: docs
weight: 10
url: /tr/nodejs-net/create-presentation/
keywords:
- sunum oluştur
- yeni sunum
- PowerPoint oluştur
- PPTX oluştur
- metin kutusu ekle
- slayt ekle
- slayt boyutu
- geniş ekran
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via .NET ile JavaScript'te PowerPoint sunumları oluşturun: bir metin kutusu ve slaytlar ekleyin, 16:9 slayt boyutu ayarlayın ve sonucu PPTX olarak kaydedin."
---
## **Genel Bakış**

Bu makale, Aspose.Slides for Node.js via .NET ile bir sunum oluşturmayı, ilk slaytına bir metin kutusu eklemeyi ve sonucu PPTX dosyası olarak kaydetmeyi gösterir. Ayrıca daha fazla slayt eklemeyi ve sunumu geniş ekran (16:9) slaytlara dönüştürmeyi de gösterir.

Örneklerin, [Installation](/slides/tr/nodejs-net/installation/) bölümünde açıklanan şekilde kurulan bir projeye ihtiyacı vardır. Her örneği proje klasöründe `.js` dosyası olarak kaydedin ve o klasörden `node` ile çalıştırın; örneğin `node create-presentation.js`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET kendi API referansına sahip değildir. Aspose.Slides for .NET API'sini camelCase adlarla yansıttığından, bu makaledeki API bağlantıları [Aspose.Slides for .NET API referansı](https://reference.aspose.com/slides/tr/net/) içindeki eşleşen sınıflara ve üyelere yönlendirilir.
{{% /alert %}}

## **Metin Kutulu Sunum Oluşturma**

Bir sunum oluşturup ilk slaytına bir metin kutusu eklemek için aşağıdaki adımları izleyin:

1. Yeni bir [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/) sınıfı örneği oluşturun. Yeni bir sunum zaten bir boş slayt içerir.
1. Bu slaytı [slides](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/slides/tr/) koleksiyonundan alın. Bu paketteki koleksiyonlar `get(index)` ile okunur ve indeksler 0'dan başlar.
1. [addAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/shapecollection/addautoshape/) metoduyla bir dikdörtgen ekleyin ve onun [textFrame](https://reference.aspose.com/slides/tr/net/aspose.slides/autoshape/textframe/) içindeki [text](https://reference.aspose.com/slides/tr/net/aspose.slides/textframe/text/) öğesini ayarlayın.
1. [save](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/save/) metodunu ve `SaveFormat.Pptx` değerini kullanarak sunumu kaydedin.
1. Sunumu destekleyen .NET kaynaklarını serbest bırakmak için `finally` bloğunda `dispose` çağırın.

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Pozisyon (x, y) ve boyut (genişlik, yükseklik) puan cinsindedir.
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    textBox.textFrame.text = "Hello, Aspose.Slides!";

    presentation.save("new-presentation.pptx", SaveFormat.Pptx);
    console.log("Saved new-presentation.pptx");
} finally {
    presentation.dispose();
}
```

Komut dosyası `new-presentation.pptx` dosyasını proje klasörüne yazar. Dosyada, sol ve üst kenarlardan 50 puan uzaklıkta sol‑üst köşesi bulunan, doldurulmuş bir dikdörtgen içeren bir slayt vardır. Dikdörtgen 400 puan genişliğinde ve 100 puan yüksekliğindedir, metni ortalanmıştır. Bir puan 1/72 inçtir. Lisans olmadan, Aspose.Slides slayta bir değerlendirme filigranı ekler; bakınız [Lisanslama](/slides/tr/nodejs-net/licensing/).

## **Slayt Ekleme**

Yeni bir sunum bir slayta sahiptir. Daha fazla eklemek için, `slides` koleksiyonunun [addEmptySlide](https://reference.aspose.com/slides/tr/net/aspose.slides/slidecollection/addemptyslide/) metoduna bir düzen slaytı geçirin. [layoutSlides](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/layoutslides/) koleksiyonunun [getByType](https://reference.aspose.com/slides/tr/net/aspose.slides/layoutslidecollection/getbytype/) metodu, belirtilen bir [SlideLayoutType](https://reference.aspose.com/slides/tr/net/aspose.slides/slidelayouttype/) tipinin ilk düzenini döndürür.

Aşağıdaki örnek, Blank (Boş) düzeniyle iki slayt ekler:

```javascript
const { Presentation, SlideLayoutType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const blankLayout = presentation.layoutSlides.getByType(SlideLayoutType.Blank);
    presentation.slides.addEmptySlide(blankLayout);
    presentation.slides.addEmptySlide(blankLayout);

    console.log("Slide count: " + presentation.slides.count);
    presentation.save("three-slides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Komut dosyası `Slide count: 3` çıktısını verir ve `three-slides.pptx` dosyasını yazar. Yeni slaytlar ilk slayttan sonra eklenir ve şekil içermez. Yeni bir sunum her zaman Blank (Boş) düzenine sahiptir, ancak bir dosyadan açtığınız sunum istenen türde bir düzen içermeyebilir; bu durumda `getByType` `null` döndürür, bu yüzden sonucu kullanmadan önce kontrol edin.

## **Slayt Boyutunu Ayarlama**

Yeni bir sunum, 720 × 540 puan (10 × 7,5 inç) ölçülerinde 4:3 slaytlar kullanır. Bunun yerine geniş ekran slaytlar oluşturmak için, sunumun [slideSize](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/slidesize/) özelliğinin [setSize](https://reference.aspose.com/slides/tr/net/aspose.slides/slidesize/setsize/) metodunu bir [SlideSizeType](https://reference.aspose.com/slides/tr/net/aspose.slides/slidesizetype/) değeri ve bir [SlideSizeScaleType](https://reference.aspose.com/slides/tr/net/aspose.slides/slidesizescaletype/) değeri ile çağırın. Ölçek tipi, Aspose.Slides'e zaten slaytlarda bulunan şekillerle ne yapılacağını söyler; `DoNotScale` onları olduğu gibi bırakır, bu da henüz içeriği olmayan bir sunum için doğru tercihtir.

```javascript
const { Presentation, SlideSizeType, SlideSizeScaleType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    presentation.slideSize.setSize(SlideSizeType.Widescreen, SlideSizeScaleType.DoNotScale);

    const slideSize = presentation.slideSize.size;
    console.log(`Slide size: ${slideSize.width} x ${slideSize.height} points`);

    presentation.save("widescreen.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Komut dosyası `Slide size: 960 x 540 points` çıktısını verir, bu da 13,33 × 7,5 inçtir ve `widescreen.pptx` dosyasını yazar. `SlideSizeType.OnScreen16x9` aynı 16:9 en‑boy oranına sahiptir ancak daha küçüktür: 720 × 405 puan.

## **SSS**

**Pozisyon ve boyutlar hangi birimlerde ölçülür?**

Puan (point) cinsindendir. Bir inç 72 puandır, bu yüzden varsayılan 4:3 slayt 720 × 540 puan, 16:9 geniş ekran slayt ise 960 × 540 puandır.

**Yeni bir sunumu hangi formatlarda kaydedebilirim?**

[SaveFormat](https://reference.aspose.com/slides/tr/net/aspose.slides.export/saveformat/) enumarasyonunun herhangi bir değeri, örneğin PowerPoint 97–2003 için `SaveFormat.Ppt`, OpenDocument için `SaveFormat.Odp` ya da `SaveFormat.Pdf`. PDF çıktısı için [PowerPoint'i PDF'e Dönüştür](/slides/tr/nodejs-net/convert-powerpoint-to-pdf/) bölümüne bakın.

**Kaydedilen sunumda neden "Evaluation only" metni bulunuyor?**

Lisans olmadan, Aspose.Slides kaydettiği slaytlara bir değerlendirme filigranı ekler. Bunu kaldırmak için [Lisanslama](/slides/tr/nodejs-net/licensing/) bölümünde açıklandığı gibi bir lisans uygulayın.

**Neden `dispose` çağırmalıyım?**

`Presentation` nesnesi, bellek ve diğer kaynakları tutan bir .NET nesnesiyle desteklenir. `dispose` çağırmak, sunuma artık ihtiyaç duymadığınızda bu kaynakları serbest bırakır ve `finally` bloğunda çağrıldığında bir hata oluşsa bile kaynaklar serbest bırakılır.