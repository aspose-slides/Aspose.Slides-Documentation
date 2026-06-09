---
title: Sunumlardan PHP ile Matematik Denklemlerini Dışa Aktarma
linktitle: Denklemleri Dışa Aktar
type: docs
weight: 30
url: /tr/php-java/exporting-math-equations/
keywords:
- matematik denklemleri dışa aktar
- MathML
- LaTeX
- PowerPoint
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java kullanarak PowerPoint'ten MathML'ye matematik denklemlerinin sorunsuz dışa aktarımını sağlayın — formatlamayı koruyun ve uyumluluğu artırın."
---
## **Giriş**

Aspose.Slides for PHP via Java, sunumlardan matematik denklemlerini dışa aktarmanıza olanak tanır. Örneğin, slaytlardaki (belirli bir sunumdan) matematik denklemlerini çıkarmanız ve bunları başka bir programda veya platformda kullanmanız gerekebilir.

{{% alert color="primary" %}} 

Denklikleri MathML'ye, web'de ve birçok uygulamada görülen matematik denklemleri ve benzeri içerikler için popüler bir format veya standart olan MathML'ye dışa aktarabilirsiniz. 

{{% /alert %}}

## **Matematik Denklemlerini MathML Olarak Kaydet**

İnsanlar LaTeX gibi bazı denklem formatları için kodu kolayca yazabilirken, MathML kodunu yazmakta zorlanırlar çünkü MathML, uygulamalar tarafından otomatik olarak üretilmek üzere tasarlanmıştır. Programlar, MathML'nin kodu XML olduğu için MathML'yi kolayca okuyup ayrıştırır; bu yüzden MathML birçok alanda çıktı ve baskı formatı olarak yaygın olarak kullanılır. 

Bu örnek kod, bir sunumdan matematik denklemini MathML olarak nasıl dışa aktaracağınızı gösterir:

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

**MathML'ye tam olarak ne dışa aktarılıyor—bir paragraf mı yoksa ayrı bir formül bloğu mu?**

MathML'ye tüm bir matematik paragrafını ([MathParagraph](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathparagraph/)) veya ayrı bir bloğu ([MathBlock](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathblock/)) dışa aktarabilirsiniz. Her iki tür de MathML'ye yazmak için bir yöntem sunar.

**Bir slayttaki nesnenin normal metin veya resim yerine matematik formülü olduğunu nasıl anlayabilirim?**

Bir formül bir [MathPortion](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathportion/) içinde bulunur ve bir [MathParagraph](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathparagraph/) içerir. [MathParagraph](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathparagraph/) içermeyen görüntüler ve normal metin bölümleri dışa aktarılabilir formüller değildir.

**Bir sunumda MathML nereden geliyor—PowerPoint'e özel mi yoksa bir standart mı?**

Dışa aktarma, standart MathML (XML)'i hedef alır. Aspose, standardın sunum alt kümesi olan Presentation MathML'i kullanır; bu, uygulamalar ve web arasında yaygın olarak kullanılır.

**Tablolar, SmartArt, gruplar vb. içindeki formüllerin dışa aktarılması destekleniyor mu?**

Evet, bu nesneler bir [MathParagraph](https://reference.aspose.com/slides/tr/php-java/aspose.slides/mathparagraph/) içeren metin bölümleri içeriyorsa (yani gerçek PowerPoint formülleri), dışa aktarılırlar. Formül bir resim olarak yerleştirilmişse dışa aktarılmaz.

**MathML'ye dışa aktarma, orijinal sunumu değiştirir mi?**

Hayır. MathML yazmak, formülün içeriğinin bir serileştirmesidir; sunum dosyasını değiştirmez.