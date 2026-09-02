---
title: "Java'da Sunumlardan Matematik Denklemlerini Dışa Aktar"
linktitle: "Denklikleri Dışa Aktar"
type: docs
weight: 30
url: /tr/java/exporting-math-equations/
keywords:
- "matematik denklemlerini dışa aktar"
- "denklemleri LaTeX'e dışa aktar"
- "PowerPoint'tan LaTeX'e"
- MathML
- LaTeX
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Java için Aspose.Slides ile PowerPoint sunumlarından matematik denklemlerini doğrudan LaTeX veya MathML'ye dışa aktar."
---
## **Giriş**

Aspose.Slides, sunumlardan matematik denklemlerini dışa aktarmanızı sağlar. Örneğin, belirli bir sunumda yer alan slaytlardaki matematik denklemlerini çıkartıp başka bir programda veya platformda kullanmanız gerekebilir. 

{{% alert color="primary" %}} 

Denklikleri doğrudan LaTeX’e veya MathML’ye dışa aktarabilirsiniz; MathML, web’de ve birçok uygulamada kullanılan popüler bir matematik içeriği standardıdır.

{{% /alert %}}

## **Matematik Denklemlerini LaTeX’e Dışa Aktar**

Aspose.Slides, bir PowerPoint matematik denklemini doğrudan LaTeX’e dönüştürebilir; ara bir MathML dosyası ve harici bir dönüştürücüye gerek yoktur. Bir matematik denklemi, bir metin çerçevesinde bir [IMathPortion](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imathportion/) olarak depolanır. Bir [IMathParagraph](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imathparagraph/) elde etmek için [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imathportion/#getMathParagraph--) kullanın ve ardından [IMathParagraph.toLatex](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imathparagraph/#toLatex--) metodunu çağırın. Bu metod, kaydedebileceğiniz, görüntüleyebileceğiniz, başka bir uygulamaya gönderebileceğiniz veya daha fazla işleyebileceğiniz bir dize döndürür.

Aşağıdaki örnek, her slayttaki tüm metin çerçevelerini inceler, tüm matematik bölümlerini bulur ve her denklemi ayrı bir `.tex` dosyasına yazar:

```java
Presentation presentation = new Presentation("equations.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slideIndex + 1;
        int equationNumber = 1;
        ITextFrame[] textFrames = SlideUtil.getAllTextBoxes(slide);

        for (ITextFrame textFrame : textFrames) {
            for (IParagraph paragraph : textFrame.getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    if (!(portion instanceof IMathPortion))
                        continue;

                    IMathPortion mathPortion = (IMathPortion) portion;
                    IMathParagraph mathParagraph = mathPortion.getMathParagraph();
                    String latexFileName = "slide_" + slideNumber + "_equation_" + equationNumber + ".tex";

                    String latexText = mathParagraph.toLatex();
                    Path latexPath = Paths.get(latexFileName);
                    byte[] latexBytes = latexText.getBytes(StandardCharsets.UTF_8);
                    Files.write(latexPath, latexBytes);
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) bir slaytta bulunan tüm metin çerçevelerini döndürür. [IMathPortion](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imathportion/) tip kontrolü, gerçek düzenlenebilir denklemleri sıradan metin ve görsellerden ayırır.

LaTeX motorları ve belge şablonları aynı komutları, paketleri veya Unicode karakterlerini desteklemeyebilir. Döndürülen dizeyi uygulamanızın kullandığı LaTeX motoru ile test edin. Eğer bir sembol veya Office Math öğesi o ortamda uygun bir temsil bulamazsa, döndürülen dizede projeye özgü bir komutla değiştirin ya da denklemi atlayıp sorunu gözden geçirme için kaydedin.

## **Matematik Denklemlerini MathML Olarak Kaydet**

İnsanlar LaTeX gibi bazı denklem formatlarının kodunu kolayca yazabilirken, MathML kodunu yazmakta zorlanırlar; çünkü MathML, uygulamalar tarafından otomatik olarak üretilmek üzere tasarlanmıştır. Programlar, MathML’in XML içinde kodlandığı için onu kolayca okuyup ayrıştırabilir; bu yüzden MathML birçok alanda çıktı ve baskı formatı olarak yaygın olarak kullanılır. 

Bu örnek kod, bir sunumdan matematik denklemini MathML’ye nasıl dışa aktaracağınızı gösterir:

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

**MathML’ye tam olarak ne dışa aktarılır—bir paragraf mı yoksa tek bir formül bloğu mu?**

MathML’ye ya tüm bir matematik paragrafını ([MathParagraph](https://reference.aspose.com/slides/tr/java/com.aspose.slides/mathparagraph/)) ya da tek bir bloğu ([MathBlock](https://reference.aspose.com/slides/tr/java/com.aspose.slides/mathblock/)) dışa aktarabilirsiniz. Her iki tür de MathML’ye yazma yöntemi sağlar.

**Bir slayttaki nesnenin normal metin veya görsel yerine matematik formülü olduğunu nasıl anlayabilirim?**

Bir formül, bir [MathPortion](https://reference.aspose.com/slides/tr/java/com.aspose.slides/mathportion/) içinde bulunur ve bir [MathParagraph](https://reference.aspose.com/slides/tr/java/com.aspose.slides/mathparagraph/) içerir. [MathParagraph] içermeyen görseller ve normal metin bölümleri dışa aktarılabilir formül değildir.

**Sunumda MathML nereden gelir—PowerPoint’e özgü mü yoksa bir standart mı?**

Dışa aktarma, standart MathML (XML) hedef alır. Aspose, sunum alt kümesi olan Presentation MathML’yi kullanır; bu, uygulamalar ve web arasında yaygın olarak kullanılmaktadır.

**Tablolar, SmartArt, gruplar vb. içindeki formüllerin dışa aktarılması destekleniyor mu?**

Evet, bu nesneler bir [MathParagraph](https://reference.aspose.com/slides/tr/java/com.aspose.slides/mathparagraph/) içeren metin bölümleri (yani gerçek PowerPoint formülleri) içeriyorsa dışa aktarılırlar. Formül bir görüntü olarak gömülü ise dışa aktarılmaz.

**MathML’ye dışa aktarmak orijinal sunumu değiştirir mi?**

Hayır. MathML yazma, formülün içeriğinin bir serileştirilmesidir; sunum dosyasını değiştirmez.