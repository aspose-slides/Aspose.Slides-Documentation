---
title: Sunumlardan Java'da Matematik Denklemlerini Dışa Aktarma
linktitle: Denklemleri Dışa Aktar
type: docs
weight: 30
url: /tr/java/exporting-math-equations/
keywords:
- matematik denklemlerini dışa aktar
- denklemleri LaTeX'e dışa aktar
- PowerPoint'tan LaTeX'e
- MathML
- LaTeX
- PowerPoint
- sunum
- Java
- Aspose.Slides
description: "Java için Aspose.Slides ile PowerPoint sunumlarından matematik denklemlerini doğrudan LaTeX veya MathML'e dışa aktarın."
---
## **Giriş**

Aspose.Slides, sunumlardan matematik denklemlerini dışa aktarmanıza olanak tanır. Örneğin, belirli bir sunumdaki slaytlardaki matematik denklemlerini çıkarmanız ve bunları başka bir programda veya platformda kullanmanız gerekebilir. 

{{% alert color="info" %}} 

Denklikleri doğrudan LaTeX'e veya MathML'e dışa aktarabilirsiniz; MathML, web üzerinde ve birçok uygulamada kullanılan popüler bir matematik içerik standardıdır. 

{{% /alert %}}

## **Matematik Denklemlerini LaTeX'e Dışa Aktarma**

Aspose.Slides, bir PowerPoint matematik denklemini doğrudan LaTeX'e dönüştürebilir; ara bir MathML dosyası ve harici bir dönüştürücü gerekmez. Bir matematik denklemi, bir metin çerçevesinde [IMathPortion](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imathportion/) olarak depolanır. [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imathportion/#getMathParagraph--) metodunu kullanarak bir [IMathParagraph](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imathparagraph/) elde edin ve ardından [IMathParagraph.toLatex](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imathparagraph/#toLatex--) metodunu çağırın. Metot, kaydedebileceğiniz, görüntüleyebileceğiniz, başka bir uygulamaya gönderebileceğiniz veya daha fazla işleyebileceğiniz bir dize döndürür.

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

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/tr/java/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) bir slaytta bulunan tüm metin çerçevelerini döndürür. [IMathPortion](https://reference.aspose.com/slides/tr/java/com.aspose.slides/imathportion/) tip kontrolü, gerçek düzenlenebilir denklemleri sıradan metin ve görüntülerden ayırır.

LaTeX motorları ve belge şablonları aynı komutları, paketleri veya Unicode karakterlerini desteklemez. Döndürülen dizeyi uygulamanızın kullandığı LaTeX motoru ile test edin. Eğer bir sembol veya Office Math öğesi o ortamda uygun bir temsile sahip değilse, döndürülen dizgedeki bu öğeyi proje özelinde bir komutla değiştirin veya denklemi atlayıp sorunu inceleme için kaydedin.

## **Matematik Denklemlerini MathML Olarak Kaydet**

İnsanlar LaTeX gibi bazı denklem formatlarının kodunu kolayca yazabilirken, MathML kodunu yazmakta zorlanırlar çünkü MathML, uygulamalar tarafından otomatik olarak üretilmek üzere tasarlanmıştır. Programlar MathML'i kolayca okur ve ayrıştırır çünkü kodu XML formatındadır; bu nedenle MathML birçok alanda çıktı ve yazdırma formatı olarak yaygın şekilde kullanılır. 

Bu örnek kod, bir sunumdan bir matematik denklemini MathML'e nasıl dışa aktaracağınızı gösterir:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

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

**MathML'e tam olarak ne dışa aktarılıyor—bir paragraf mı yoksa bireysel bir formül bloğu mu?**

MathML'e ya tüm bir matematik paragrafı ([MathParagraph](https://reference.aspose.com/slides/tr/java/com.aspose.slides/mathparagraph/)) ya da bireysel bir blok ([MathBlock](https://reference.aspose.com/slides/tr/java/com.aspose.slides/mathblock/)) dışa aktarabilirsiniz. Her iki tür de MathML'e yazma yöntemi sunar. 

**Bir slayttaki nesnenin normal metin veya görüntü yerine bir matematik formülü olduğunu nasıl anlayabilirim?**

Bir formül, bir [MathPortion](https://reference.aspose.com/slides/tr/java/com.aspose.slides/mathportion/) içinde yer alır ve bir [MathParagraph](https://reference.aspose.com/slides/tr/java/com.aspose.slides/mathparagraph/) içerir. [MathParagraph] içermeyen görüntüler ve normal metin bölümleri dışa aktarılabilir formüller değildir. 

**Sunumda MathML nereden geliyor—PowerPoint’e özgü mü yoksa bir standart mı?**

Dışa aktarma, standart MathML (XML) hedef alır. Aspose, sunum alt kümesi olan Presentation MathML'i kullanır; bu, uygulamalar ve web arasında yaygın olarak kullanılan bir standarttır. 

**Tablolar, SmartArt, gruplar vb. içindeki formüllerin dışa aktarılması destekleniyor mu?**

Evet, bu nesneler bir [MathParagraph] (yani gerçek PowerPoint formülleri) içeren metin bölümleri barındırıyorsa dışa aktarılırlar. Formül bir görüntü olarak gömülü ise dışa aktarılmaz. 

**MathML'e dışa aktarma orijinal sunumu değiştirir mi?**

Hayır. MathML yazımı, formülün içeriğinin bir serileştirilmesidir; sunum dosyasını değiştirmez.