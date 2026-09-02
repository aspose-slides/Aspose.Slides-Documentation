---
title: Exportera matematiska ekvationer från presentationer i PHP
linktitle: Exportera ekvationer
type: docs
weight: 30
url: /sv/php-java/exporting-math-equations/
keywords:
- exportera matematiska ekvationer
- exportera ekvationer till LaTeX
- PowerPoint till LaTeX
- MathML
- LaTeX
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Exportera matematiska ekvationer från PowerPoint-presentationer till LaTeX eller MathML direkt med Aspose.Slides för PHP via Java."
---
## **Introduktion**

Aspose.Slides för PHP via Java gör det möjligt att exportera matematiska ekvationer från presentationer. Till exempel kan du behöva extrahera de matematiska ekvationerna på bilder (från en specifik presentation) och använda dem i ett annat program eller plattform.

{{% alert color="primary" %}} 
Du kan exportera ekvationer direkt till LaTeX eller till MathML, en populär standard för matematiskt innehåll som används på webben och i många applikationer.
{{% /alert %}}

## **Exportera matematiska ekvationer till LaTeX**

Aspose.Slides kan konvertera en PowerPoint‑matematisk ekvation direkt till LaTeX; en mellanliggande MathML‑fil och en extern konverterare behövs inte. En matematisk ekvation lagras i en textruta som en [MathPortion](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathportion/). Använd [MathPortion::getMathParagraph](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathportion/#getMathParagraph) för att hämta ett [MathParagraph](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathparagraph/), och anropa sedan [MathParagraph::toLatex](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathparagraph/#toLatex). Metoden returnerar en sträng som du kan spara, visa, skicka till en annan applikation eller vidarebehandla.

Följande exempel undersöker varje textruta på varje bild, hittar alla matematiska delar och skriver varje ekvation till en separat `.tex`‑fil:

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

[SlideUtil::getAllTextBoxes](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slideutil/#getAllTextBoxes) returnerar alla textrutor som hittas på en bild. Typkontrollen [MathPortion](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathportion/) skiljer äkta redigerbara ekvationer från vanlig text och bilder.

LaTeX‑motorer och dokumentmallar stödjer inte alla samma kommandon, paket eller Unicode‑tecken. Testa den returnerade strängen med den LaTeX‑motor som din applikation använder. Om en symbol eller Office‑Math‑element saknar en lämplig representation i den miljön, ersätt den i den returnerade strängen med ett projektspecifikt kommando eller hoppa över ekvationen och registrera problemet för granskning.

## **Spara matematiska ekvationer som MathML**

Medan människor lätt kan skriva koden för vissa ekvationsformat som LaTeX, har de svårt att skriva koden för MathML eftersom det senare är avsett att genereras automatiskt av program. Program läser och tolkar MathML enkelt eftersom dess kod är i XML, så MathML används ofta som ett utskrifts‑ och utskriftsformat i många områden. 

Denna exempelcode visar hur du exporterar en matematisk ekvation från en presentation till MathML:

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

## **FAQ**

**Vad exporteras exakt till MathML—ett stycke eller ett enskilt formelblock?**

Du kan exportera antingen ett helt matematiskt stycke ([MathParagraph](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathparagraph/)) eller ett enskilt block ([MathBlock](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathblock/)) till MathML. Båda typerna har en metod för att skriva till MathML.

**Hur kan jag avgöra att ett objekt på en bild är en matematisk formel snarare än vanlig text eller en bild?**

En formel finns i en [MathPortion](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathportion/) och har ett [MathParagraph](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathparagraph/). Bilder och vanlig text utan ett [MathParagraph](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathparagraph/) är inte exporterbara formler.

**Var kommer MathML från i en presentation—är det PowerPoint‑specifikt eller en standard?**

Exporten riktar sig mot standard‑MathML (XML). Aspose använder Presentation MathML — presentationsdelmängden av standarden — som är allmänt använd i olika applikationer och på webben.

**Stöds export av formler i tabeller, SmartArt, grupper osv.?**

Ja, om de objekten innehåller textdelar med ett [MathParagraph](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathparagraph/) (dvs. äkta PowerPoint‑formler) exporteras de. Om en formel är inbäddad som en bild, exporteras den inte.

**Ändrar export till MathML den ursprungliga presentationen?**

Nej. Att skriva MathML är en serialisering av formelns innehåll; det ändrar inte presentationsfilen.