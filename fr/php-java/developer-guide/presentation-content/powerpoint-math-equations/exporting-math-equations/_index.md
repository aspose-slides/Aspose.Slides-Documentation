---
title: Exportation des Équations Mathématiques
type: docs
weight: 30
url: /fr/php-java/exporting-math-equations/

---

## Exportation des Équations Mathématiques depuis des Présentations

Aspose.Slides pour PHP via Java vous permet d'exporter des équations mathématiques depuis des présentations. Par exemple, vous pourriez avoir besoin d'extraire les équations mathématiques des diapositives (d'une présentation spécifique) et de les utiliser dans un autre programme ou plateforme.

{{% alert color="primary" %}} 

Vous pouvez exporter des équations au format MathML, un format ou standard populaire pour les équations mathématiques et contenu similaire vu sur le web et dans de nombreuses applications. 

{{% /alert %}}

Bien que les humains écrivent facilement le code pour certains formats d'équations comme LaTeX, ils ont du mal à écrire le code pour MathML car ce dernier est destiné à être généré automatiquement par des applications. Les programmes lisent et analysent facilement MathML car son code est en XML, donc MathML est couramment utilisé comme format de sortie et d'impression dans de nombreux domaines.

Ce code d'exemple vous montre comment exporter une équation mathématique d'une présentation au format MathML :

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