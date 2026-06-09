---
title: Sunumlardan Matematik Denklemlerini Java ile Dışa Aktarma
linktitle: Denklemleri Dışa Aktar
type: docs
weight: 30
url: /tr/java/exporting-math-equations/
keywords:
- matematik denklemlerini dışa aktar
- MathML
- LaTeX
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java kullanarak PowerPoint'ten MathML'ye matematik denklemlerinin sorunsuz dışa aktarımının kilidini açın—formatlamayı koruyun ve uyumluluğu artırın."
---
## **Giriş**

Aspose.Slides, sunumlardan matematik denklemlerini dışa aktarmanıza olanak tanır. Örneğin, belirli bir sunumda bulunan slaytlardaki matematik denklemlerini çıkarmanız ve bunları başka bir programda veya platformda kullanmanız gerekebilir. 

{{% alert color="primary" %}} 

Denklikleri MathML'ye dışa aktarabilirsiniz; bu, webde ve birçok uygulamada görülen matematik denklemleri ve benzeri içerikler için popüler bir format veya standarttır. 

{{% /alert %}}

## **Math Denklemlerini MathML Olarak Kaydet**

İnsanlar LaTeX gibi bazı denklem formatları için kodu kolayca yazarken, MathML kodunu yazmakta zorlanırlar; çünkü MathML, uygulamalar tarafından otomatik olarak üretilmek üzere tasarlanmıştır. Programlar MathML'yi kolayca okuyup ayrıştırır, çünkü kodu XML biçimindedir; bu nedenle MathML birçok alanda çıktı ve baskı formatı olarak yaygın olarak kullanılır. 

Bu örnek kod, bir sunumdan matematik denklemini MathML'ye nasıl dışa aktaracağınızı gösterir:

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

**MathML'ye tam olarak ne dışa aktarılır—bir paragraf mı yoksa bireysel bir formül bloğu mu?**

Tam bir matematik paragrafı ([MathParagraph](https://reference.aspose.com/slides/tr/java/com.aspose.slides/mathparagraph/)) ya da ayrı bir blok ([MathBlock](https://reference.aspose.com/slides/tr/java/com.aspose.slides/mathblock/)) MathML'ye dışa aktarılabilir. Her iki tür de MathML'ye yazmak için bir yöntem sağlar.

**Bir slayd üzerindeki bir nesnenin normal metin veya resim değil, bir matematik formülü olduğunu nasıl anlayabilirim?**

Formül bir [MathPortion](https://reference.aspose.com/slides/tr/java/com.aspose.slides/mathportion/) içinde bulunur ve bir [MathParagraph](https://reference.aspose.com/slides/tr/java/com.aspose.slides/mathparagraph/) içerir. [MathParagraph](https://reference.aspose.com/slides/tr/java/com.aspose.slides/mathparagraph/) içermeyen görüntüler ve normal metin bölümleri dışa aktarılabilir formül değildir.

**Sunumdaki MathML nereden gelir—PowerPoint'e özgü mü yoksa bir standart mı?**

Dışa aktarım, standart MathML (XML) hedefler. Aspose, sunum alt kümesi olan Presentation MathML'yi kullanır; bu, uygulamalar ve web arasında yaygın olarak kullanılan bir standarttır.

**Tablolar, SmartArt, gruplar vb. içindeki formüllerin dışa aktarılması destekleniyor mu?**

Evet, bu nesneler bir [MathParagraph](https://reference.aspose.com/slides/tr/java/com.aspose.slides/mathparagraph/) içeren metin bölümleri (gerçek PowerPoint formülleri) içeriyorsa dışa aktarılır. Formül bir görüntü olarak gömülü ise dışa aktarılmaz.

**MathML'ye dışa aktarmak orijinal sunumu değiştirir mi?**

Hayır. MathML yazma işlemi, formülün içeriğinin bir serileştirilmesidir; sunum dosyasını değiştirmez.