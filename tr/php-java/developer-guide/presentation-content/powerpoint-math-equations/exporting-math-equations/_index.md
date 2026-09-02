---
title: "PHP'de Sunumlardan Matematik Denklemlerini Dışa Aktarma"
linktitle: "Denklemleri Dışa Aktar"
type: docs
weight: 30
url: /tr/php-java/exporting-math-equations/
keywords:
- "matematik denklemlerini dışa aktar"
- "denklemleri LaTeX'e dışa aktar"
- "PowerPoint'tan LaTeX'e"
- MathML
- LaTeX
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java ile PowerPoint sunumlarından matematik denklemlerini doğrudan LaTeX veya MathML'e dışa aktarın."
---
## **Giriş**

Aspose.Slides for PHP via Java, sunumlardan matematik denklemlerini dışa aktarmanıza olanak tanır. Örneğin, belirli bir sunumdan slaytlardaki matematik denklemlerini çıkarmanız ve bunları başka bir programda ya da platformda kullanmanız gerekebilir.

{{% alert color="primary" %}} 
Denklikleri doğrudan LaTeX'e veya MathML'e dışa aktarabilirsiniz; MathML, web'de ve birçok uygulamada kullanılan popüler bir matematik içeriği standardıdır.
{{% /alert %}}

## **Matematik Denklemlerini LaTeX'e Dışa Aktarma**

Aspose.Slides, bir PowerPoint matematik denklemini doğrudan LaTeX'e dönüştürebilir; ara bir MathML dosyasına ve harici bir dönüştürücüye ihtiyaç yoktur. Bir matematik denklemi, bir metin çerçevesinde [MathPortion](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathportion/) olarak depolanır. [MathPortion::getMathParagraph](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathportion/#getMathParagraph) kullanarak bir [MathParagraph](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathparagraph/) alabilir ve ardından [MathParagraph::toLatex](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathparagraph/#toLatex) yöntemiyle LaTeX'e dönüştürebilirsiniz. Bu yöntem, kaydedebileceğiniz, görüntüleyebileceğiniz, başka bir uygulamaya gönderebileceğiniz veya daha fazla işleyebileceğiniz bir dize döndürür.

Aşağıdaki örnek, her slayttaki tüm metin çerçevelerini inceler, tüm matematik bölümlerini bulur ve her denklemi ayrı bir `.tex` dosyasına yazar:

```php
$presentation = new Presentation("equations.pptx");
$arrayClass = new JavaClass("java.lang.reflect.Array");
$mathPortionClass = new JavaClass("com.aspose.slides.MathPortion");

try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = $slideIndex + 1;
        $equationNumber = 1;
        $textFrames = SlideUtil::getAllTextBoxes($slide);
        $textFrameCount = java_values($arrayClass->getLength($textFrames));

        for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
            $textFrame = $textFrames[$textFrameIndex];
            $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
            for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                $portionCount = java_values($paragraph->getPortions()->getCount());
                for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    if (!java_instanceof($portion, $mathPortionClass)) {
                        continue;
                    }

                    $mathParagraph = $portion->getMathParagraph();
                    $latexFileName = "slide_" . $slideNumber . "_equation_" . $equationNumber . ".tex";

                    $latexText = java_values($mathParagraph->toLatex());
                    file_put_contents($latexFileName, $latexText);
                    $equationNumber++;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

[SlideUtil::getAllTextBoxes](https://reference.aspose.com/slides/tr/php-java/aspose.slides/slideutil/#getAllTextBoxes), bir slaytta bulunan tüm metin çerçevelerini döndürür. [MathPortion](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathportion/) tür kontrolü, gerçek düzenlenebilir denklemleri normal metin ve görüntülerden ayırır.

LaTeX motorları ve belge şablonları aynı komutları, paketleri veya Unicode karakterlerini desteklemeyebilir. Döndürülen dizeyi, uygulamanızda kullanılan LaTeX motoru ile test edin. Bir sembol veya Office Math öğesi o ortamda uygun bir temsile sahip değilse, döndürülen dizede projeye özgü bir komutla değiştirin veya denklemi atlayıp sorunu inceleme için kaydedin.

## **Matematik Denklemlerini MathML Olarak Kaydetme**

İnsanlar LaTeX gibi bazı denklem formatlarının kodunu kolayca yazabilse de, MathML kodunu yazmakta zorlanırlar; çünkü MathML, uygulamalar tarafından otomatik olarak üretilmek üzere tasarlanmıştır. Programlar MathML'i kolayca okuyup ayrıştırabilir, çünkü kodu XML formatındadır; bu yüzden MathML birçok alanda çıktı ve baskı formatı olarak yaygın şekilde kullanılır.

Bu örnek kod, bir sunumdan bir matematik denklemini MathML'e nasıl dışa aktaracağınızı gösterir:

```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addMathShape(0, 0, 500, 50);
    $mathParagraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();
    $mathParagraph->add(new MathematicalText("a")->setSuperscript("2")->join("+")->join(new MathematicalText("b")->setSuperscript("2"))->join("=")->join(new MathematicalText("c")->setSuperscript("2")));
    $stream = new Java("java.io.FileOutputStream", "mathml.xml");
    $mathParagraph->writeAsMathMl($stream);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **SSS**

**MathML'e tam olarak ne dışa aktarılır—bir paragraf mı yoksa ayrı bir formül bloğu mu?**

MathML'e tüm bir matematik paragrafı ([MathParagraph](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathparagraph/)) veya ayrı bir blok ([MathBlock](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathblock/)) dışa aktarabilirsiniz. Her iki tip de MathML'e yazma yöntemi sunar.

**Bir slayttaki nesnenin normal metin ya da görüntü yerine matematik formülü olduğunu nasıl anlayabilirim?**

Bir formül, bir [MathPortion](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathportion/) içinde bulunur ve bir [MathParagraph](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathparagraph/) içerir. [MathParagraph] içermeyen görüntüler ve normal metin bölümleri dışa aktarılabilir formüller değildir.

**Sunumda MathML nereden gelir—PowerPoint'e özgü mü yoksa bir standart mı?**

Dışa aktarma, standart MathML (XML) hedefler. Aspose, standardın sunum alt kümesi olan Presentation MathML'i kullanır; bu, uygulamalar ve web arasında yaygın olarak kullanılır.

**Tablolar, SmartArt, gruplar vb. içindeki formüllerin dışa aktarılması destekleniyor mu?**

Evet, bu nesneler bir [MathParagraph](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathparagraph/) içeren metin bölümleri barındırıyorsa (yani gerçek PowerPoint formülleri), dışa aktarılırlar. Formül bir görüntü olarak gömülü ise dışa aktarılmaz.

**MathML'e dışa aktarmak orijinal sunumu değiştirir mi?**

Hayır. MathML yazmak, formülün içeriğinin bir serileştirilmesidir; sunum dosyasını değiştirmez.