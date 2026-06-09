---
title: JavaScript ile Sunumlardan Matematik Denklemlerini Dışa Aktar
linktitle: Denklemleri Dışa Aktar
type: docs
weight: 30
url: /tr/nodejs-java/exporting-math-equations/
keywords:
- matematik denklemlerini dışa aktar
- MathML
- LaTeX
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript ve Node.js için Aspose.Slides kullanarak PowerPoint'ten MathML'ye matematik denklemlerinin sorunsuz dışa aktarımını etkinleştirin—biçimlendirmeyi koruyun ve uyumluluğu artırın."
---
## **Giriş**

Aspose.Slides, sunumlardan matematik denklemlerini dışa aktarmanıza olanak tanır. Örneğin, belirli bir sunumdan slaytlardaki matematik denklemlerini çıkarıp başka bir programda ya da platformda kullanmanız gerekebilir. 

{{% alert color="primary" %}} 
Denklikleri MathML'ye dışa aktarabilirsiniz; bu, web'de ve birçok uygulamada görülen matematik denklemleri ve benzeri içerikler için popüler bir format ya da standarttır. 
{{% /alert %}}

## **Matematik Denklemlerini MathML Olarak Kaydet**

İnsanlar LaTeX gibi bazı denklem formatları için kodu kolayca yazabilirken, MathML kodunu yazmakta zorlanırlar; çünkü MathML uygulamalar tarafından otomatik olarak üretilmek üzere tasarlanmıştır. Programlar, MathML kodunun XML içinde olması nedeniyle MathML'yi kolayca okur ve ayrıştırır; bu yüzden MathML birçok alanda ortak çıktı ve baskı formatı olarak kullanılır. 

Bu örnek kod, bir sunumdan matematik denklemini MathML'ye nasıl dışa aktaracağınızı gösterir:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    var mathParagraph = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
    mathParagraph.add(new aspose.slides.MathematicalText("a").setSuperscript("2").join("+").join(new aspose.slides.MathematicalText("b").setSuperscript("2")).join("=").join(new aspose.slides.MathematicalText("c").setSuperscript("2")));
    var stream = null;
    mathParagraph.writeAsMathMl(stream);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **SSS**

**MathML'ye tam olarak ne dışa aktarılır—bir paragraf mı yoksa bireysel bir formül bloğu mu?**

MathML'ye tüm bir matematik paragrafı ([MathParagraph](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathparagraph/)) ya da bireysel bir blok ([MathBlock](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathblock/)) dışa aktarabilirsiniz. Her iki tür de MathML'ye yazma yöntemi sağlar.

**Bir slayttaki nesnenin normal metin ya da görsel yerine matematik formülü olduğunu nasıl anlayabilirim?**

Bir formül, bir [MathPortion](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathportion/) içinde bulunur ve bir [MathParagraph](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathparagraph/) içerir. [MathParagraph](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathparagraph/) içermeyen görseller ve normal metin kısımları dışa aktarılabilir formüller değildir.

**MathML bir sunumda nereden gelir—PowerPoint'e özgü mü yoksa bir standart mı?**

Dışa aktarma standart MathML (XML) hedefler. Aspose, standardın sunum alt kümesi olan Presentation MathML'yi kullanır; bu, uygulamalar ve web arasında yaygın olarak kullanılır.

**Tablolar, SmartArt, gruplar vb. içindeki formüllerin dışa aktarımı destekleniyor mu?**

Evet, bu nesneler bir [MathParagraph](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathparagraph/) içeren metin bölümleri barındırıyorsa (yani gerçek PowerPoint formülleri), dışa aktarılır. Formül bir görsel olarak eklenmişse dışa aktarılmaz.

**MathML'ye dışa aktarma orijinal sunumu değiştirir mi?**

Hayır. MathML yazmak, formül içeriğinin bir serileştirilmesidir; sunum dosyasını değiştirmez.