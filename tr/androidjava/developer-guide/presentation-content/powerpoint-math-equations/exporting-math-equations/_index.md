---
title: Android'de Sunumlardan Matematik Denklemlerini Dışa Aktarma
linktitle: Denklemleri Dışa Aktar
type: docs
weight: 30
url: /tr/androidjava/exporting-math-equations/
keywords:
- matematik denklemlerini dışa aktar
- denklemleri LaTeX'e dışa aktar
- PowerPoint'ten LaTeX'e
- MathML
- LaTeX
- PowerPoint
- sunum
- Android
- Java
- Aspose.Slides
description: "Matematik denklemlerini PowerPoint sunumlarından doğrudan LaTeX veya MathML'e, Aspose.Slides for Android via Java kullanarak dışa aktar."
---
## **Giriş**

Aspose.Slides for Android via Java, sunumlardan matematik denklemlerini dışa aktarmanıza olanak tanır. Örneğin, belirli bir sunumdaki slaytlardaki matematik denklemlerini çıkarıp başka bir programda veya platformda kullanmanız gerekebilir.

{{% alert color="primary" %}} 
Denklikleri doğrudan LaTeX’e ya da web ve birçok uygulamada kullanılan popüler bir standart olan MathML’ye dışa aktarabilirsiniz.
{{% /alert %}}

## **Matematik Denklemlerini LaTeX'e Aktar**

Aspose.Slides, bir PowerPoint matematik denklemini doğrudan LaTeX’e dönüştürebilir; ara bir MathML dosyasına ve harici bir dönüştürücüye ihtiyaç yoktur. Bir matematik denklemi, bir metin çerçevesinde bir [IMathPortion](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imathportion/) olarak saklanır. Bir [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) çağırarak bir [IMathParagraph](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imathparagraph/) elde edebilir ve ardından [IMathParagraph.toLatex](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imathparagraph/#toLatex--) metodunu çağırabilirsiniz. Bu yöntem, kaydedebileceğiniz, görüntüleyebileceğiniz, başka bir uygulamaya gönderebileceğiniz veya daha fazla işleyebileceğiniz bir dize döndürür.

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

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) bir slaytta bulunan tüm metin çerçevelerini döndürür. [IMathPortion](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/imathportion/) tip kontrolü, gerçek düzenlenebilir denklemleri sıradan metin ve görüntülerden ayırır.

LaTeX motorları ve belge şablonları aynı komutları, paketleri veya Unicode karakterlerini desteklemez. Döndürülen diziyi uygulamanızın kullandığı LaTeX motoru ile test edin. Bir sembol veya Office Math öğesi o ortamda uygun bir temsile sahip değilse, döndürülen dizede proje‑spesifik bir komutla değiştirin veya denklemi atlayıp sorunu inceleme için kaydedin.

## **Matematik Denklemlerini MathML Olarak Kaydet**

İnsanlar LaTeX gibi bazı denklem formatları için kodu kolayca yazabilse de, MathML kodunu yazmakta zorlanırlar çünkü MathML, uygulamalar tarafından otomatik olarak üretilmek üzere tasarlanmıştır. Programlar MathML’yi kolayca okur ve ayrıştırır; çünkü kodu XML formatındadır, bu yüzden MathML birçok alanda çıktı ve baskı formatı olarak yaygın olarak kullanılır.

Bu örnek kod, bir sunumdan bir matematik denklemine MathML olarak dışa aktarmayı göstermektedir:

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

**Tam olarak ne MathML’ye dışa aktarılıyor—bir paragraf mı yoksa bireysel bir formül bloğu mu?**

Tam bir matematik paragrafı ([MathParagraph](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/mathparagraph/)) ya da bireysel bir blok ([MathBlock](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/mathblock/)) dışa aktarabilirsiniz. Her iki tür de MathML’ye yazma yöntemine sahiptir.

**Bir slayttaki bir nesnenin düzenli metin veya görüntü yerine bir matematik formülü olduğunu nasıl anlayabilirim?**

Bir formül, bir [MathPortion](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/mathportion/) içinde yer alır ve bir [MathParagraph](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/mathparagraph/) içerir. [MathParagraph](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/mathparagraph/) içermeyen görüntüler ve normal metin bölümleri dışa aktarılabilir formüller değildir.

**MathML bir sunum içinde nereden geliyor—PowerPoint’e özgü mü yoksa bir standart mı?**

Dışa aktarma, standart MathML (XML) hedef alır. Aspose, sunum alt kümesi olan Presentation MathML’yi kullanır; bu, uygulamalar ve web arasında yaygın olarak kullanılan bir standarttır.

**Tablolar, SmartArt, gruplar vb. içinde bulunan formüllerin dışa aktarılması destekleniyor mu?**

Evet, bu nesneler bir [MathParagraph](https://reference.aspose.com/slides/tr/androidjava/com.aspose.slides/mathparagraph/) içeren metin bölümleri (yani gerçek PowerPoint formülleri) barındırıyorsa dışa aktarılır. Formül bir görüntü olarak gömülü ise dışa aktarılmaz.

**MathML’ye dışa aktarma, orijinal sunumu değiştirir mi?**

Hayır. MathML’nin yazılması, formülün içeriğinin serileştirilmesidir; sunum dosyasını değiştirmez.