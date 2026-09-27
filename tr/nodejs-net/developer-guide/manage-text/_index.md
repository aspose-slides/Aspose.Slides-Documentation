---
title: Node.js üzerinden .NET ile Sunum Metnini Yönet
linktitle: Metni Yönet
type: docs
weight: 50
url: /tr/nodejs-net/manage-text/
keywords:
- metin
- metin kutusu
- metin ekle
- metni değiştir
- metni biçimlendir
- yazı tipi boyutu
- kalın metin
- metin çerçevesi
- paragraf
- parçacık
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via .NET ile JavaScript'te bir slayta metin kutusu ekleyin, ardından metnini, yazı tipi boyutunu ve kalın stilini değiştirin."
---
## **Genel Bakış**

Aspose.Slides'da bir slayttaki metin bir şekle aittir. Bir dikdörtgen gibi otomatik şekil, bir metin çerçevesine sahiptir; metin çerçevesi paragraf içerir ve her paragraf, aynı biçimlendirmeye sahip metin parçacıklarından (portion) oluşur. Metni, metin çerçevesi aracılığıyla, yazı tipini ise bir parçacığın biçimi (format) üzerinden değiştirirsiniz.

Bu makale bir slayta metin kutusu ekler ve sunumu kaydeder. Ardından kaydedilen dosyayı açar ve metin kutusunun metnini, yazı tipi boyutunu ve kalın stilini değiştirir.

Örneklerin, [Kurulum](/slides/tr/nodejs-net/installation/) bölümünde anlatıldığı gibi bir proje ayarlanmasını gerektirir. Her örneği proje klasöründe `.js` dosyası olarak kaydedin ve `node` ile bu klasörden çalıştırın.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET kendi API referansına sahip değildir. .NET için Aspose.Slides API'sını camelCase adlarıyla yansıtır, bu nedenle bu makaledeki API bağlantıları [Aspose.Slides for .NET API referansı](https://reference.aspose.com/slides/net/) içindeki eşleşen sınıflara ve üyelere yönlendirir.
{{% /alert %}}

## **Metin Kutusu Ekle**

Bir metin kutusu eklemek için, bir slayta [addAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/) yöntemiyle bir otomatik şekil ekleyin ve [addTextFrame](https://reference.aspose.com/slides/net/aspose.slides/autoshape/addtextframe/) yöntemiyle ona metin verin. Aşağıdaki örnek, yeni bir sunumun ilk slaytına bir dikdörtgen ekler ve sunumu `text-box.pptx` olarak kaydeder:

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Konum (x, y) ve boyut (genişlik, yükseklik) nokta cinsindendir.
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80);
    textBox.addTextFrame("Quarterly report");

    presentation.save("text-box.pptx", SaveFormat.Pptx);
    console.log("Saved text-box.pptx");
} finally {
    presentation.dispose();
}
```

`text-box.pptx` dosyasındaki slayt, varsayılan yazı tipi ve boyutunda "Quarterly report" metniyle, 500 puan genişliğinde ve 80 puan yüksekliğinde bir dikdörtgen içerir. Sonraki örnek bu metin kutusunu değiştirir.

## **Metni ve Biçimlendirmesini Değiştir**

Aşağıdaki örnek, önceki örneğin oluşturduğu `text-box.pptx` dosyasını açar ve ilk slayttaki ilk şekli alır. Resim ve tablo gibi şekillerin metin çerçevesi yoktur, bu yüzden örnek, şeklin [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) olduğundan emin olduktan sonra şeklin [textFrame](https://reference.aspose.com/slides/net/aspose.slides/autoshape/textframe/) özelliğini kullanır. Ardından şu adımları gerçekleştirir:

1. Metin çerçevesinin [text](https://reference.aspose.com/slides/net/aspose.slides/textframe/text/) özelliği aracılığıyla metni değiştirir. Sonuçta, metin çerçevesi bir paragraf ve bir parçacık (portion) içerir.
2. Bu parçacığı [paragraphs](https://reference.aspose.com/slides/net/aspose.slides/textframe/paragraphs/) ve [portions](https://reference.aspose.com/slides/net/aspose.slides/paragraph/portions/) koleksiyonlarından alır ve onun [portionFormat](https://reference.aspose.com/slides/net/aspose.slides/portion/portionformat/) özelliğini okur.
3. [fontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) özelliğini, puan cinsinden yazı tipi boyutunu ayarlar ve [fontBold](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontbold/) özelliğini, bir [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) değeri alan şekilde ayarlar.

```javascript
const { Presentation, AutoShape, NullableBool, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("text-box.pptx");
try {
    const shape = presentation.slides.get(0).shapes.get(0);
    if (shape instanceof AutoShape) {
        const textFrame = shape.textFrame;
        textFrame.text = "Quarterly report: third quarter";

        const portionFormat = textFrame.paragraphs.get(0).portions.get(0).portionFormat;
        portionFormat.fontHeight = 32;
        portionFormat.fontBold = NullableBool.True;

        presentation.save("text-box-updated.pptx", SaveFormat.Pptx);
        console.log("Saved text-box-updated.pptx");
    } else {
        console.log("The first shape on the first slide is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

`text-box-updated.pptx` içinde, metin kutusu "Quarterly report: third quarter" ifadesini kalın 32 puanlık yazı tipiyle gösterir. Yeni metin tek bir parçacık olduğu için iki biçimlendirme özelliği de tümüne uygulanır. Lisans olmadan her kaydetme bir değerlendirme filigranı ekler. `text-box.pptx` de değerlendirme modunda kaydedildiği için, `text-box-updated.pptx` iki filigran içerir; bkz. [Aspose.Slides'i Değerlendirme](/slides/tr/nodejs-net/evaluate-aspose-slides/).

## **SSS**

**`fontBold` neden `true` veya `false` yerine bir `NullableBool` değeri alıyor?**

Bir parçacık bir özelliği tanımsız bırakabilir ve bu özelliği paragraftan, şekilden ya da slaytın düzeninden ve ana temasından (master) devralabilir. `NullableBool.NotDefined` "devral" anlamına gelirken, `NullableBool.True` ve `NullableBool.False` devralınan değeri geçersiz kılar. `true` ya da `false` atamak bir hata oluşturur. Aynı nedenle, `fontHeight` parçacık yazı tipi boyutunu devraldığında `NaN` döndürür.

**Metin rengini nasıl değiştiririm?**

Parçacık biçiminin doldurmasını ayarlayın: `portionFormat.fillFormat.fillType` özelliğine `FillType.Solid` atayın ve ardından `portionFormat.fillFormat.solidFillColor.color` özelliğine `"#FF0000"` gibi bir renk atayın. Paketten içe aktardığınız isimlere `FillType` ekleyin.

**Metnin sadece bir kısmını nasıl biçimlendiririm?**

Biçimlendirme parçacıklara aittir, bu yüzden metnin o kısmını kendi parçacığına koyun. Parçacığı `Portion.CreatePortionFromText` ile oluşturun, paragrafın `portions` koleksiyonunda `add` yöntemiyle paragrafın sonuna ekleyin ve ardından yeni parçacığın `portionFormat` özelliğini ayarlayın. Paketten içe aktardığınız isimlere `Portion` ekleyin.

**Metin okuma neden "... text has been truncated due to evaluation version limitation" döndürüyor?**

Lisans olmadan Aspose.Slides, okuduğunuz daha uzun metnin yalnızca ilk beş karakterini (ör. `textFrame.text`) döndürür ve ardından bu uyarıyı ekler. Yazdığınız metin tam olarak kaydedilir. Tam metni okuyabilmek için [Lisanslama](/slides/tr/nodejs-net/licensing/) bölümünde anlatıldığı gibi bir lisans uygulayın.