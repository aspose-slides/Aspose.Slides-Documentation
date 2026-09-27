---
title: API Referansı
type: docs
weight: 50
url: /tr/nodejs-net/api-reference/
description: "Aspose.Slides for Node.js via .NET, Aspose.Slides for .NET API referansı tarafından belgelenir. .NET sınıf ve üye adlarının JavaScript'e nasıl eşlendiğine bakın."
---
## **Genel Bakış**

Aspose.Slides for Node.js via .NET'in kendine ait bir API referansı yoktur. Paket, Aspose.Slides for .NET sınıflarını aynı adlarla, camelCase üye adlarıyla JavaScript'e sunar, bu yüzden [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/tr/net/) sınıflarını, üyelerini ve enum'larını belgeler.

## **.NET Adlarını JavaScript'e Eşleme**

.NET API referansında bulduğunuz bir üyeyi kullanmak için aşağıdaki kuralları uygulayın:

- **Sınıflar ve enum'lar .NET adlarını korur**, enum değerleri de aynı şekilde: `Presentation`, `ShapeType.Rectangle`, `SaveFormat.Pdf`. Paketten şu şekilde içe aktarın: `const { Presentation, SaveFormat } = require("aspose.slides.via.net");`.
- **Özellikler ve metodlar küçük harf ile başlar.** `Presentation.Slides` `presentation.slides` olur ve `ShapeCollection.AddAutoShape` `shapes.addAutoShape` olur. Özellikler özellik olarak kalır: parantez olmadan okur ve atayabilirsiniz.
- **Koleksiyon öğeleri `get(index)` ile okunur**, öğe sayısı `count` ile alınır: `presentation.slides.get(0)` yerine `presentation.Slides[0]`.
- **Bazı aşırı yüklemeler ayrı isimler alır.** Örneğin, `Slide.GetImage(Size)` aşırı yüklemesi `slide.getImageWithImageSize({ width, height })` şeklindedir. Diğerleri isteğe bağlı ek argümanlarla tek bir metod paylaşır: `presentation.save(path, format, options, slides)` birden fazla `Presentation.Save` aşırı yüklemesini kapsar ve `new Presentation(null, buffer)` bir `Buffer`'dan sunumu açar. Her sınıf paketin `lib` klasöründe bir dosyadır (örneğin, `node_modules/aspose.slides.via.net/lib/Slide.js`), burada tam isimleri bulabilirsiniz.
- **İşiniz bittiğinde sunumları `dispose` ile serbest bırakın**; JavaScript'te `using` deyimi yoktur.

Paket her .NET üyesini sarmaz. .NET API referansındaki bir üye sınıf dosyasında bulunmuyorsa, JavaScript'te mevcut değildir.

## **Örnek**

Aşağıdaki betik yukarıdaki kuralları kullanır. Her yorum, bir sonraki satırın karşılık geldiği .NET çağrısını gösterir. İlk slayta metinli bir dikdörtgen ekler, slaytı 960 × 540 piksel PNG görüntüsü olarak render eder ve sunumu PDF olarak kaydeder. Paketin kurulduğu proje klasöründen, [Installation](/slides/tr/nodejs-net/installation/) kısmında açıklandığı gibi çalıştırın.

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat, ImageFormat } = asposeSlides;

const presentation = new Presentation();
try {
    // .NET: presentation.Slides[0]
    const slide = presentation.slides.get(0);

    // .NET: slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100)
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);

    // .NET: rectangle.TextFrame.Text = "..."
    rectangle.textFrame.text = "Names follow the .NET API in camelCase.";

    // .NET: slide.GetImage(new Size(960, 540))
    const slideImage = slide.getImageWithImageSize({ width: 960, height: 540 });
    slideImage.save("slide.png", ImageFormat.Png);
    slideImage.dispose();

    // .NET: presentation.Save("slide.pdf", SaveFormat.Pdf)
    presentation.save("slide.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

Betik `slide.png` ve `slide.pdf` dosyalarını geçerli klasöre yazar. Her ikisi de metinli dikdörtgeni gösterir. Lisans olmadan, bir değerlendirme filigranı da gösterir; [Licensing](/slides/tr/nodejs-net/licensing/) bölümüne bakın.

Burada kullanılan üyeler hakkında detaylar için Aspose.Slides for .NET API referansındaki [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/), [ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/tr/net/aspose.slides/shapecollection/addautoshape/), [TextFrame.Text](https://reference.aspose.com/slides/tr/net/aspose.slides/textframe/text/) ve [Slide.GetImage](https://reference.aspose.com/slides/tr/net/aspose.slides/slide/getimage/) bölümlerine bakın.