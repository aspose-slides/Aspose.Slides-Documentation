---
title: Exportera matematiska ekvationer från presentationer i PHP
linktitle: Exportera ekvationer
type: docs
weight: 30
url: /sv/php-java/exporting-math-equations/
keywords:
- exportera matematiska ekvationer
- MathML
- LaTeX
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Lås upp sömlös export av matematiska ekvationer från PowerPoint till MathML med Aspose.Slides för PHP via Java — bevara formatering och öka kompatibiliteten."
---
## **Introduktion**

Aspose.Slides for PHP via Java låter dig exportera matematiska ekvationer från presentationer. Till exempel kan du behöva extrahera de matematiska ekvationerna på bilder (från en specifik presentation) och använda dem i ett annat program eller en annan plattform.

{{% alert color="primary" %}} 
Du kan exportera ekvationer till MathML, ett populärt format eller standard för matematiska ekvationer och liknande innehåll som ses på webben och i många applikationer.
{{% /alert %}}

## **Spara matematiska ekvationer som MathML**

Medan människor enkelt kan skriva koden för vissa ekvationsformat som LaTeX, har de svårigheter att skriva koden för MathML eftersom det senare är avsett att genereras automatiskt av appar. Program läser och parsar MathML enkelt eftersom koden är i XML, så MathML används ofta som ett utdata‑ och utskriftsformat i många områden.

Detta exempelprogram visar hur du exporterar en matematisk ekvation från en presentation till MathML:

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

**Vad exporteras exakt till MathML—ett stycke eller ett individuellt formelblock?**  
Du kan exportera antingen ett helt matematiskt stycke ([MathParagraph](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathparagraph/)) eller ett individuellt block ([MathBlock](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathblock/)) till MathML. Båda typerna tillhandahåller en metod för att skriva till MathML.

**Hur kan jag avgöra att ett objekt på en bild är en matematisk formel snarare än vanlig text eller en bild?**  
En formel finns i en [MathPortion](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathportion/) och har ett [MathParagraph](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathparagraph/). Bilder och vanliga textdelar utan ett [MathParagraph](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathparagraph/) kan inte exporteras som formler.

**Var kommer MathML från i en presentation—är det specifikt för PowerPoint eller en standard?**  
Exporten riktar sig mot standard‑MathML (XML). Aspose använder Presentation MathML—presentation‑delen av standarden—som är allmänt använd i många applikationer och på webben.

**Stöds export av formler i tabeller, SmartArt, grupper etc.?**  
Ja, om dessa objekt innehåller textdelar med ett [MathParagraph](https://reference.aspose.com/slides/sv/php-java/aspose.slides/mathparagraph/) (dvs. äkta PowerPoint‑formler) exporteras de. Om en formel är inbäddad som en bild, exporteras den inte.

**Modifierar export till MathML den ursprungliga presentationen?**  
Nej. Att skriva MathML är en serialisering av formelns innehåll; det ändrar inte presentationsfilen.