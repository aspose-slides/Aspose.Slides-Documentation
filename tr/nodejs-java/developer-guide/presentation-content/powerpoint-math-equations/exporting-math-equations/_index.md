---
title: "JavaScript'te Sunumlardan Matematik Denklemlerini Dışa Aktarma"
linktitle: "Denklemleri Dışa Aktar"
type: docs
weight: 30
url: /tr/nodejs-java/exporting-math-equations/
keywords:
- matematik denklemlerini dışa aktar
- denklemleri LaTeX'e dışa aktar
- PowerPoint'tan LaTeX'e
- MathML
- LaTeX
- PowerPoint
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint sunumlarından matematik denklemlerini doğrudan Aspose.Slides for Node.js ile Java üzerinden LaTeX veya MathML'e dışa aktar."
---
## **Giriş**

Aspose.Slides, sunumlardan matematik denklemlerini dışa aktarmanıza olanak tanır. Örneğin, slaytlardaki (belirli bir sunumdan) matematik denklemlerini çıkartıp başka bir programda veya platformda kullanmanız gerekebilir. 

{{% alert color="primary" %}} 

Denklikleri doğrudan LaTeX'e veya web ve birçok uygulamada kullanılan popüler bir matematik içerik standardı olan MathML'e dışa aktarabilirsiniz.

{{% /alert %}}

## **Matematik Denklemlerini LaTeX'e Dışa Aktarma**

Aspose.Slides, bir PowerPoint matematik denklemini doğrudan LaTeX'e dönüştürebilir; ara bir MathML dosyasına ve harici bir dönüştürücüye ihtiyaç duyulmaz. Bir matematik denklemi, bir metin çerçevesinde bir [MathPortion](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathportion/) olarak depolanır. Bir [MathParagraph](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathparagraph/) almak için [MathPortion.getMathParagraph](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathportion/#getMathParagraph--) yöntemini kullanın ve ardından [MathParagraph.toLatex](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathparagraph/#toLatex--) metodunu çağırın. Bu yöntem, kaydedebileceğiniz, görüntüleyebileceğiniz, başka bir uygulamaya gönderebileceğiniz veya daha fazla işleyebileceğiniz bir dize döndürür.

Aşağıdaki örnek, her slayttaki her metin çerçevesini inceler, tüm math portion'ları bulur ve her denklemi ayrı bir `.tex` dosyasına yazar:

```javascript
const presentation = new aspose.slides.Presentation("equations.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const slideNumber = slideIndex + 1;
        let equationNumber = 1;
        const textFrames = aspose.slides.SlideUtil.getAllTextBoxes(slide);

        for (const textFrame of textFrames) {
            const paragraphCount = textFrame.getParagraphs().getCount();
            for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
                const portionCount = paragraph.getPortions().getCount();
                for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    if (!java.instanceOf(portion, "com.aspose.slides.MathPortion")) {
                        continue;
                    }

                    const mathParagraph = portion.getMathParagraph();
                    const latexFileName = `slide_${slideNumber}_equation_${equationNumber}.tex`;

                    const latexText = mathParagraph.toLatex();
                    fileSystem.writeFileSync(latexFileName, latexText, "utf8");
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-) bir slaytta bulunan tüm metin çerçevelerini döndürür. [MathPortion](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathportion/) tür denetimi, gerçek düzenlenebilir denklemleri sıradan metin ve görsellerden ayırır.

LaTeX motorları ve belge şablonları aynı komutları, paketleri veya Unicode karakterlerini desteklemez. Döndürülen diziyi uygulamanızın kullandığı LaTeX motoru ile test edin. Bir sembol veya Office Math öğesi o ortamda uygun bir temsile sahip değilse, döndürülen dizideki onu proje özelinde bir komutla değiştirin veya denklemi atlayıp sorunu inceleme için kaydedin.

## **Matematik Denklemlerini MathML Olarak Kaydetme**

İnsanlar LaTeX gibi bazı denklem formatlarının kodunu kolayca yazar, ancak MathML kodunu yazmakta zorlanırlar; çünkü MathML, uygulamalar tarafından otomatik olarak üretilmek için tasarlanmıştır. Programlar MathML'i kolayca okuyup ayrıştırır çünkü kodu XML biçimindedir; bu yüzden MathML birçok alanda çıktı ve baskı formatı olarak yaygın şekilde kullanılır. 

Bu örnek kod, bir sunumdan bir matematik denklemini MathML olarak dışa aktarmanın nasıl yapılacağını gösterir:

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

**MathML'e tam olarak ne dışa aktarılıyor—bir paragraf mı yoksa ayrı bir formül bloğu mu?**

Tam bir matematik paragrafını ([MathParagraph](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathparagraph/)) veya ayrı bir blok ([MathBlock](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathblock/)) MathML'e dışa aktarabilirsiniz. Her iki tür de MathML'e yazma yöntemi sağlar.

**Bir slayttaki bir nesnenin normal metin veya görsel yerine matematik formülü olduğunu nasıl anlayabilirim?**

Bir formül, bir [MathPortion](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathportion/) içinde bulunur ve bir [MathParagraph](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathparagraph/) içerir. [MathParagraph](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathparagraph/) içermeyen görseller ve normal metin bölümleri dışa aktarılabilir formül değildir.

**MathML sunum içinde nereden geliyor—PowerPoint'e özgü mü yoksa bir standart mı?**

Dışa aktarma, standart MathML (XML) hedef alır. Aspose, sunum alt kümesi olan Presentation MathML'i—standartın bir alt kümesi—kullanan geniş çapta uygulama ve web ortamlarında yaygın olarak kullanılan bir biçimdir.

**Tablolar, Akıllı Sanat, gruplar vb. içinde bulunan formüllerin dışa aktarılması destekleniyor mu?**

Evet, bu nesneler bir [MathParagraph](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/mathparagraph/) içeren metin bölümleri (yani gerçek PowerPoint formülleri) içeriyorsa dışa aktarılır. Formül bir görsel olarak gömülmüşse dışa aktarılmaz.

**MathML'e dışa aktarma orijinal sunumu değiştirir mi?**

Hayır. MathML yazma, formülün içeriğinin bir serileştirilmesidir; sunum dosyasını değiştirmez.