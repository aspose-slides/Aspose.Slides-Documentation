---
title: Android'da Sunumlardan Matematik Denklemlerini Dışa Aktarma
linktitle: Denklemleri Dışa Aktar
type: docs
weight: 30
url: /tr/androidjava/exporting-math-equations/
keywords:
- matematik denklemlerini dışa aktar
- MathML
- LaTeX
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java kullanarak PowerPoint'ten MathML'ye matematik denklemlerinin sorunsuz dışa aktarımını sağlayın—formatlamayı koruyun ve uyumluluğu artırın."
---
## **Giriş**

Aspose.Slides for Android via Java, sunumlardan matematik denklemlerini dışa aktarmanıza olanak tanır. Örneğin, slaytlardaki (belirli bir sunumdan) matematik denklemlerini çıkarmanız ve bunları başka bir programda ya da platformda kullanmanız gerekebilir.

{{% alert color="primary" %}} 
Denklikleri MathML'ye dışa aktarabilirsiniz; bu, web'de ve birçok uygulamada görülen matematik denklemleri ve benzeri içerikler için popüler bir biçim ya da standarttır. 
{{% /alert %}}

## **Sunumlardan Matematik Denklemlerini Dışa Aktarma**

İnsanlar LaTeX gibi bazı denklem biçimleri için kodu kolayca yazarken, MathML için kod yazmakta zorlanırlar; çünkü MathML, uygulamalar tarafından otomatik olarak üretilmek üzere tasarlanmıştır. Programlar MathML'yi kolayca okuyup ayrıştırır, çünkü kodu XML'dedir; bu nedenle MathML birçok alanda çıktı ve baskı biçimi olarak yaygın şekilde kullanılır. 

Bu örnek kod, bir sunumdan bir matematik denklemini MathML'ye nasıl dışa aktaracağını gösterir:

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    IMathParagraph mathParagraph = ((MathPortion)autoShape.getTextFrame().getParagraphs().get_Item(0).
            getPortions().get_Item(0)).getMathParagraph();

    mathParagraph.add(new MathematicalText("a").
            setSuperscript("2").
            join("+").
            join(new MathematicalText("b").setSuperscript("2")).
            join("=").
            join(new MathematicalText("c").setSuperscript("2")));

    FileOutputStream stream = new FileOutputStream("mathml.xml");
    mathParagraph.writeAsMathMl(stream);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **SSS**

**MathML'ye tam olarak ne dışa aktarılır—bir paragraf mı yoksa tek bir formül bloğu mu?**

MathML'ye ya tüm bir matematik paragrafını ([MathParagraph](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/mathparagraph/)) ya da tek bir bloğu ([MathBlock](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/mathblock/)) dışa aktarabilirsiniz. Her iki tür de MathML'ye yazmak için bir yöntem sağlar. 

**Bir slayttaki nesnenin normal metin ya da görsel yerine bir matematik formülü olduğunu nasıl anlarsınız?**

Bir formül bir [MathPortion](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/mathportion/) içinde bulunur ve bir [MathParagraph](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/mathparagraph/) içerir. [MathParagraph](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/mathparagraph/) içermeyen görseller ve normal metin bölümleri dışa aktarılabilir formüller değildir. 

**Bir sunumdaki MathML nereden gelir—PowerPoint'e özel mi yoksa bir standart mı?**

Dışa aktarma, standart MathML (XML)'i hedefler. Aspose, standardın sunum alt kümesi olan Presentation MathML'i kullanır; bu, uygulamalar ve web arasında yaygın olarak kullanılır. 

**Tablolar, SmartArt, gruplar vb. içindeki formüllerin dışa aktarılması destekleniyor mu?**

Evet, bu nesneler bir [MathParagraph](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/mathparagraph/) içeren metin bölümleri (yani gerçek PowerPoint formülleri) içeriyorsa dışa aktarılırlar. Formül bir görsel olarak gömülü ise dışa aktarılmaz. 

**MathML'ye dışa aktarmak orijinal sunumu değiştirir mi?**

Hayır. MathML'yi yazmak, formülün içeriğinin bir serileştirilmesidir; sunum dosyasını değiştirmez.