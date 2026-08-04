---
title: Exporter des équations mathématiques depuis des présentations en PHP
linktitle: Exporter des équations
type: docs
weight: 30
url: /fr/php-java/exporting-math-equations/
keywords:
- exporter des équations mathématiques
- exporter des équations vers LaTeX
- PowerPoint vers LaTeX
- MathML
- LaTeX
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Exporter des équations mathématiques depuis des présentations PowerPoint vers LaTeX ou MathML directement avec Aspose.Slides for PHP via Java."
---
## **Introduction**

Aspose.Slides for PHP via Java vous permet d’exporter des équations mathématiques depuis des présentations. Par exemple, il peut être nécessaire d’extraire les équations mathématiques présentes sur les diapositives (d’une présentation spécifique) et de les utiliser dans un autre programme ou une autre plateforme.

{{% alert color="primary" %}} 

Vous pouvez exporter les équations directement vers LaTeX ou vers MathML, un standard populaire pour le contenu mathématique utilisé sur le Web et dans de nombreuses applications.

{{% /alert %}}

## **Exportation d’équations mathématiques vers LaTeX**

Aspose.Slides peut convertir une équation mathématique PowerPoint directement en LaTeX ; un fichier intermédiaire MathML et un convertisseur externe ne sont pas nécessaires. Une équation mathématique est stockée dans un cadre de texte sous forme de [MathPortion](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathportion/). Utilisez [MathPortion::getMathParagraph](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathportion/#getMathParagraph) pour obtenir un [MathParagraph](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathparagraph/), puis appelez [MathParagraph::toLatex](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathparagraph/#toLatex). La méthode renvoie une chaîne que vous pouvez enregistrer, afficher, envoyer à une autre application ou traiter davantage.

L’exemple suivant examine chaque cadre de texte sur chaque diapositive, trouve toutes les portions mathématiques et écrit chaque équation dans un fichier `.tex` distinct :

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

[SlideUtil::getAllTextBoxes](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slideutil/#getAllTextBoxes) renvoie tous les cadres de texte trouvés sur une diapositive. Le test de type [MathPortion](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathportion/) sépare les véritables équations modifiables du texte ordinaire et des images.

Les moteurs LaTeX et les modèles de documents ne prennent pas tous en charge les mêmes commandes, packages ou caractères Unicode. Testez la chaîne renvoyée avec le moteur LaTeX utilisé par votre application. Si un symbole ou un élément Office Math n’a pas de représentation adaptée dans cet environnement, remplacez‑le dans la chaîne renvoyée par une commande spécifique à votre projet ou ignorez l’équation et consignez le problème pour révision.

## **Enregistrement des équations mathématiques au format MathML**

Alors que les humains écrivent facilement le code de certains formats d’équations comme LaTeX, ils ont du mal à écrire le code de MathML car ce dernier est destiné à être généré automatiquement par les applications. Les programmes lisent et analysent facilement le MathML parce que son code est en XML, ainsi le MathML est couramment utilisé comme format de sortie et d’impression dans de nombreux domaines. 

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

Vous pouvez exporter soit un paragraphe mathématique complet ([MathParagraph](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathparagraph/)) soit un bloc individuel ([MathBlock](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathblock/)) vers MathML. Les deux types offrent une méthode pour écrire en MathML.

**Comment savoir qu’un objet sur une diapositive est une formule mathématique plutôt qu’un texte ordinaire ou une image ?**

Une formule se trouve dans une [MathPortion](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathportion/) et possède un [MathParagraph](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathparagraph/). Les images et les portions de texte ordinaires sans [MathParagraph](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathparagraph/) ne sont pas des formules exportables.

**D’où provient le MathML dans une présentation — est‑il spécifique à PowerPoint ou un standard ?**

L’exportation cible le MathML standard (XML). Aspose utilise le Presentation MathML — le sous‑ensemble de présentation du standard — qui est largement utilisé dans les applications et sur le Web.

**L’exportation de formules situées dans des tableaux, SmartArt, groupes, etc., est‑elle prise en charge ?**

Oui, si ces objets contiennent des portions de texte avec un [MathParagraph](https://reference.aspose.com/slides/fr/php-java/aspose.slides/mathparagraph/) (c’est‑à‑dire de vraies formules PowerPoint), elles sont exportées. Si une formule est intégrée sous forme d’image, elle ne l’est pas.

**L’exportation vers MathML modifie‑t‑elle la présentation d’origine ?**

Non. L’écriture du MathML est une sérialisation du contenu de la formule ; elle ne modifie pas le fichier de présentation.