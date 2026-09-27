---
title: Node.js üzerinden .NET ile Sunum Slaytlarını Görüntülere Dönüştür
linktitle: Slayttan Görüntüye
type: docs
weight: 40
url: /tr/nodejs-net/convert-slide/
keywords:
- slaytı dönüştür
- slayttan görüntüye
- slayttan PNG
- slaytı görüntü olarak kaydet
- slaytı render et
- slayt küçük resmi
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via .NET kullanarak JavaScript'te PPTX, PPT ve ODP sunumlarındaki slaytları PNG görüntüler olarak, ölçek faktörüyle ya da piksel cinsinden kesin bir boyutta render edin."
---
## **Genel Bakış**

Aspose.Slides for Node.js via .NET, PowerPoint ve OpenDocument sunumlarından slaytları görüntü olarak işler, örneğin bir web sayfasında slayt önizlemeleri göstermek için. Bu makale, görüntü boyutunu seçmenin iki yolunu gösterir: slayt boyutuna göre bir ölçek faktörü ve piksel cinsinden kesin bir boyut. Her iki örnek de PNG dosyaları kaydeder.

Örnekler, [Installation](/slides/tr/nodejs-net/installation/) bölümünde kurduğunuz proje klasöründe `sample.pptx` adlı bir sunum dosyası bekler. Herhangi bir PowerPoint sunumu kullanılabilir. Her örneği proje klasöründe bir `.js` dosyası olarak kaydedin ve o klasörden `node` ile çalıştırın.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET kendi API referansına sahip değildir. Aspose.Slides for .NET API'sini camelCase adlarla yansıtır, bu nedenle bu makaledeki API linkleri [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/tr/net/) adresindeki eşleşen sınıflara ve üyelere yönlendirilir.
{{% /alert %}}

Bir slaytı görüntüye dönüştürmek için şu adımları izleyin:

1. Sunumu, [Presentation](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/presentation/) yapıcısı ile açın.  
2. `get(index)` ile [slides](https://reference.aspose.com/slides/tr/net/aspose.slides/presentation/slides/tr/) koleksiyonundan bir slayt alın. Dizinler 0’dan başlar.  
3. Slaytı `getImageWithScale` veya `getImageWithImageSize` ile render edin. .NET API referansında ikisi de [Slide.GetImage](https://reference.aspose.com/slides/tr/net/aspose.slides/slide/getimage/) metodunun aşırı yüklemeleridir. Bu metodlar, [IImage](https://reference.aspose.com/slides/tr/net/aspose.slides/iimage/) nesnesine karşılık gelen bir görüntü nesnesi döndürür.  
4. Görüntüyü, [save](https://reference.aspose.com/slides/tr/net/aspose.slides/iimage/save/) metodu ve bir [ImageFormat](https://reference.aspose.com/slides/tr/net/aspose.slides/imageformat/) değeri ile kaydedin, ardından `dispose` metodunu çağırın.

## **Her Slaytı PNG Görüntüsü Olarak Dönüştür**

`getImageWithScale` yatay ve dikey bir ölçek faktörü alır. Ölçek 1 olduğunda, slayttaki bir nokta görüntüde bir piksele dönüşür. Aşağıdaki örnek her slaytı ölçek 2 ile render eder:

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

// 1 ölçek, bir noktayı bir piksel olarak render eder; 2 genişliği ve yüksekliği iki katına çıkar.
const scaleX = 2;
const scaleY = scaleX;

const presentation = new Presentation("sample.pptx");
try {
    const slideCount = presentation.slides.count;
    for (let index = 0; index < slideCount; index++) {
        const slide = presentation.slides.get(index);
        const image = slide.getImageWithScale(scaleX, scaleY);
        try {
            image.save(`slide_${index + 1}.png`, ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
    console.log(`Saved ${slideCount} images`);
} finally {
    presentation.dispose();
}
```

Betik, her slayt için bir dosya yazar: `slide_1.png`, `slide_2.png` vb., 1’den başlayarak numaralandırılır. 960 × 540 nokta boyutundaki slaytlara sahip 16:9 bir sunum için, her görüntü 1920 × 1080 piksel olur. Gizli slaytlar da render edilir; bunları atlamak için slaytın [hidden](https://reference.aspose.com/slides/tr/net/aspose.slides/slide/hidden/) özelliğini kontrol edin. Her görüntü, bir `finally` bloğunda dispose edilir, böylece bir sonraki slayt render edilmeden önce serbest bırakılır. Lisans olmadan, görüntüler değerlendirme filigranı gösterir; [Licensing](/slides/tr/nodejs-net/licensing/) bölümüne bakın.

## **Bir Slaytı Belirli Bir Boyutta Görüntüye Dönüştür**

`getImageWithImageSize` piksel cinsinden `width` ve `height` içeren bir nesne alır. Aşağıdaki örnek ilk slaytı 1280 piksel genişliğinde render eder ve yüksekliği slayt boyutundan hesaplayarak görüntünün slaytın en boy oranını korumasını sağlar:

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

const imageWidth = 1280;

const presentation = new Presentation("sample.pptx");
try {
    const slideSize = presentation.slideSize.size;
    const imageHeight = Math.round(imageWidth * slideSize.height / slideSize.width);

    const slide = presentation.slides.get(0);
    const image = slide.getImageWithImageSize({ width: imageWidth, height: imageHeight });
    try {
        image.save("slide_1_1280px.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
    console.log(`Saved a ${imageWidth} x ${imageHeight} image`);
} finally {
    presentation.dispose();
}
```

[slideSize.size](https://reference.aspose.com/slides/tr/net/aspose.slides/slidesize/size/) özelliği slayt genişliğini ve yüksekliğini nokta cinsinden döndürür. 16:9 bir sunum için betik `Saved a 1280 x 720 image` mesajını yazdırır ve `slide_1_1280px.png` dosyasını oluşturur; 4:3 bir sunumda ise görüntü 1280 × 960 piksel olur.

## **SSS**

**`getImage` argümansız çağrıldığında görüntü neden bu kadar küçük?**

Argüman verilmediğinde, `getImage` slaytı nokta cinsinden boyutunun %20’siyle render eder, bu yüzden 960 × 540 nokta bir slayt 192 × 108 piksel görüntüye dönüşür. Boyutu seçmek için `getImageWithScale` veya `getImageWithImageSize` kullanın.

**JPEG veya başka görüntü formatlarını nasıl kaydederim?**

Görüntünün `save` metoduna başka bir `ImageFormat` değeri geçirin, örneğin `image.save("slide_1.jpg", ImageFormat.Jpeg)`. Format dosya uzantısından değil `ImageFormat` değerinden gelir, bu yüzden ikisini tutarlı tutun.

**Linux'ta görüntülerdeki metin neden farklı görünüyor?**

Aspose.Slides yalnızca slaytları render eden makinede yüklü fontları kullanabilir. Sunum bir fontu (örneğin tipik bir Linux sunucusunda Calibri) içeriyor ve bu font yüklü değilse, Aspose.Slides onun yerine yüklü başka bir font kullanır; bu da metnin görünümünü ve satır sonlarını değiştirebilir. Aynı görüntüleri Windows’ta elde etmek için sunumların kullandığı fontları yükleyin.

**`getThumbnailWithImageSize` TypeError hatasıyla neden başarısız oluyor?**

Paket README`sinde `getThumbnailWithImageSize` kullanılmış, ancak paket içinde `getThumbnail` metodu yoktur. Bunun yerine aynı `{ width, height }` argümanını alan `getImageWithImageSize` metodunu kullanın.