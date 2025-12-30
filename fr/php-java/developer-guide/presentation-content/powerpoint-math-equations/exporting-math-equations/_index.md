---
title: Exporter des équations mathématiques depuis des présentations en PHP
linktitle: Exporter des équations
type: docs
weight: 30
url: /fr/php-java/exporting-math-equations/
keywords:
- exporter des équations mathématiques
- MathML
- LaTeX
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Exportez sans effort les équations mathématiques de PowerPoint vers MathML avec Aspose.Slides pour PHP via Java — conservez le formatage et améliorez la compatibilité."
---

## **Exporter des équations mathématiques depuis les présentations**

Aspose.Slides for PHP via Java vous permet d’exporter des équations mathématiques depuis des présentations. Par exemple, il peut être nécessaire d’extraire les équations présentes sur les diapositives (d’une présentation spécifique) et de les utiliser dans un autre programme ou une autre plateforme.

{{% alert color="primary" %}} 
Vous pouvez exporter les équations au format MathML, un format ou une norme populaire pour les équations mathématiques et les contenus similaires que l’on retrouve sur le Web et dans de nombreuses applications. 
{{% /alert %}}

Alors que les humains écrivent facilement le code de certains formats d’équations comme LaTeX, ils rencontrent des difficultés avec le code du MathML, car ce dernier est destiné à être généré automatiquement par les applications. Les programmes lisent et analysent facilement le MathML puisque son code est en XML, si bien que le MathML est couramment utilisé comme format de sortie et d’impression dans de nombreux domaines. 

Ce code d’exemple montre comment exporter une équation mathématique d’une présentation vers MathML :
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

**Qu’est‑ce qui est exactement exporté vers MathML — un paragraphe ou un bloc de formule individuel ?**

Vous pouvez exporter soit un paragraphe mathématique complet ([MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/)) soit un bloc individuel ([MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/)) vers MathML. Les deux types offrent une méthode pour écrire en MathML.

**Comment savoir si un objet sur une diapositive est une formule mathématique plutôt qu’un texte ordinaire ou une image ?**

Une formule se trouve dans une [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) et possède une [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/). Les images et les portions de texte ordinaires qui ne contiennent pas de [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) ne sont pas des formules exportables.

**D’où provient le MathML dans une présentation — est‑il spécifique à PowerPoint ou s’agit‑il d’une norme ?**

L’exportation cible le MathML standard (XML). Aspose utilise le Presentation MathML, le sous‑ensemble de présentation de la norme, qui est largement utilisé dans les applications et sur le Web.

**L’exportation de formules contenues dans des tableaux, SmartArt, des groupes, etc., est‑elle prise en charge ?**

Oui, si ces objets contiennent des portions de texte avec une [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) (c’est‑à‑dire de véritables formules PowerPoint), elles sont exportées. Si une formule est intégrée sous forme d’image, elle ne l’est pas.

**L’exportation vers MathML modifie‑t‑elle la présentation d’origine ?**

Non. L’écriture du MathML est une sérialisation du contenu de la formule ; elle ne modifie pas le fichier de présentation.