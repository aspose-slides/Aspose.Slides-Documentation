---
title: Android'de Sunumlardan Matematik Denklemlerini Dışa Aktar
linktitle: Denklemleri Dışa Aktar
type: docs
weight: 30
url: /tr/androidjava/exporting-math-equations/
keywords:
- matematik denklemlerini dışa aktar
- denklemleri LaTeX'e dışa aktar
- PowerPoint'tan LaTeX'e
- MathML
- LaTeX
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "PowerPoint sunumlarından matematik denklemlerini doğrudan Aspose.Slides for Android via Java ile LaTeX ya da MathML olarak dışa aktarın."
---
## **Giriş**

Aspose.Slides for Android via Java, sunumlardan matematik denklemlerini dışa aktarmanıza olanak tanır. Örneğin, slaytlardaki (belirli bir sunumdan) matematik denklemlerini çıkartıp başka bir programda veya platformda kullanmanız gerekebilir.

{{% alert color="info" %}} 
Denklemleri doğrudan LaTeX'e veya web ve birçok uygulamada kullanılan popüler bir matematik içeriği standardı olan MathML'e dışa aktarabilirsiniz.
{{% /alert %}}

## **Matematik Denklemlerini LaTeX'e Dışa Aktar**

Aspose.Slides, bir PowerPoint matematik denklemini doğrudan LaTeX'e dönüştürebilir; ara bir MathML dosyası ve harici bir dönüştürücüye gerek yoktur. Bir matematik denklemi, bir metin çerçevesinde bir [IMathPortion](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imathportion/) olarak depolanır. Bir [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) kullanarak bir [IMathParagraph](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imathparagraph/) elde edin ve ardından [IMathParagraph.toLatex](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imathparagraph/#toLatex--) metodunu çağırın. Bu yöntem, kaydedebileceğiniz, görüntüleyebileceğiniz, başka bir uygulamaya gönderebileceğiniz veya daha fazla işleyebileceğiniz bir dize döndürür.

Aşağıdaki örnek, her slayttaki tüm metin çerçevelerini inceler, tüm matematik bölümlerini bulur ve her denklemi ayrı bir `.tex` dosyasına yazar:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileOutputStream;
import java.nio.charset.StandardCharsets;

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
                    File latexFile = new File(latexFileName);
                    byte[] latexBytes = latexText.getBytes(StandardCharsets.UTF_8);
                    FileOutputStream outputStream = new FileOutputStream(latexFile);
                    try {
                        outputStream.write(latexBytes);
                    } finally {
                        outputStream.close();
                    }
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) bir slaytta bulunan tüm metin çerçevelerini döndürür. [IMathPortion](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imathportion/) tür kontrolü, gerçek düzenlenebilir denklemleri sıradan metin ve görüntülerden ayırır.

LaTeX motorları ve belge şablonları aynı komutları, paketleri veya Unicode karakterlerini desteklemez. Döndürülen dizeyi uygulamanızın kullandığı LaTeX motoru ile test edin. Bir sembol veya Office Math öğesi o ortamda uygun bir temsile sahip değilse, döndürülen dizede proje‑özel bir komutla değiştirin veya denklemi atlayıp inceleme için kaydedin.

## **Matematik Denklemlerini MathML Olarak Kaydet**

İnsanlar LaTeX gibi bazı denklem formatları için kodu kolayca yazabilirken, MathML kodunu yazmakta zorlanırlar; çünkü MathML, uygulamalar tarafından otomatik olarak üretilmek üzere tasarlanmıştır. Programlar MathML'i kolayca okur ve ayrıştırır çünkü kodu XML formatındadır; bu yüzden MathML birçok alanda çıktı ve baskı formatı olarak yaygın şekilde kullanılır.

Bu örnek kod, bir sunumdan bir matematik denklemini MathML olarak dışa aktarmayı gösterir:

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

**MathML’e tam olarak ne dışa aktarılır—bir paragraf mı yoksa ayrı bir formül bloğu mu?**  
Tam bir matematik paragrafı ([MathParagraph](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/mathparagraph/)) ya da ayrı bir blok ([MathBlock](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/mathblock/)) dışa aktarabilirsiniz. Her iki tür de MathML’e yazma yöntemi sunar.

**Bir slayttaki nesnenin normal metin veya bir resim yerine matematik formülü olduğunu nasıl anlarım?**  
Formül bir [MathPortion](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/mathportion/) içinde bulunur ve bir [MathParagraph](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/mathparagraph/) içerir. [MathParagraph](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/mathparagraph/) içermeyen resimler ve normal metin bölümleri dışa aktarılabilir formül değildir.

**Sunumdaki MathML nereden geliyor—PowerPoint’e özgü mü yoksa bir standart mı?**  
Dışa aktarma, standart MathML (XML) hedef alır. Aspose, sunum alt kümesi olan Presentation MathML’i kullanır; bu, uygulamalar ve web arasında yaygın olarak kullanılan bir standarttır.

**Tablolar, SmartArt, gruplar vb. içindeki formüllerin dışa aktarılması destekleniyor mu?**  
Evet, bu nesneler gerçek bir [MathParagraph](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/mathparagraph/) içeren metin bölümleri içeriyorsa (yani gerçek PowerPoint formülleri), dışa aktarılır. Formül bir resim olarak gömülü ise dışa aktarılmaz.

**MathML’e dışa aktarma, orijinal sunumu değiştirir mi?**  
Hayır. MathML’i yazma, formülün içeriğinin bir serileştirmesidir; sunum dosyasını değiştirmez.