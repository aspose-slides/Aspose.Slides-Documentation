---
title: Exporter des équations mathématiques depuis des présentations en Java
linktitle: Exporter les équations
type: docs
weight: 30
url: /fr/java/exporting-math-equations/
keywords:
- exporter des équations mathématiques
- exporter des équations vers LaTeX
- PowerPoint vers LaTeX
- MathML
- LaTeX
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Exporter des équations mathématiques depuis des présentations PowerPoint vers LaTeX ou MathML directement avec Aspose.Slides pour Java."
---
## **Introduction**

Aspose.Slides vous permet d'exporter des équations mathématiques à partir de présentations. Par exemple, vous pourriez avoir besoin d'extraire les équations mathématiques des diapositives (d'une présentation spécifique) et de les utiliser dans un autre programme ou une autre plateforme. 

{{% alert color="primary" %}} 
Vous pouvez exporter les équations directement vers LaTeX ou vers MathML, une norme populaire pour le contenu mathématique utilisé sur le web et dans de nombreuses applications.
{{% /alert %}}

## **Exporter les équations mathématiques vers LaTeX**

Aspose.Slides peut convertir une équation mathématique PowerPoint directement en LaTeX ; un fichier intermédiaire MathML et un convertisseur externe ne sont pas nécessaires. Une équation mathématique est stockée dans une zone de texte sous forme d'[IMathPortion](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imathportion/). Utilisez [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imathportion/#getMathParagraph--) pour obtenir un [IMathParagraph](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imathparagraph/), puis appelez [IMathParagraph.toLatex](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imathparagraph/#toLatex--). La méthode renvoie une chaîne que vous pouvez enregistrer, afficher, envoyer à une autre application ou traiter davantage.

L'exemple suivant examine chaque zone de texte de chaque diapositive, trouve toutes les parties mathématiques et écrit chaque équation dans un fichier `.tex` distinct :

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

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/fr/java/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) renvoie toutes les zones de texte trouvées sur une diapositive. La vérification du type [IMathPortion] sépare les vraies équations modifiables du texte ordinaire et des images.

Les moteurs LaTeX et les modèles de documents ne prennent pas tous en charge les mêmes commandes, paquets ou caractères Unicode. Testez la chaîne renvoyée avec le moteur LaTeX utilisé par votre application. Si un symbole ou un élément Office Math n’a pas de représentation adaptée dans cet environnement, remplacez‑le dans la chaîne renvoyée par une commande spécifique au projet ou ignorez l’équation et consignez le problème pour révision.

## **Enregistrer les équations mathématiques au format MathML**

Si les humains écrivent facilement le code de certains formats d'équations comme LaTeX, ils rencontrent des difficultés à écrire le code de MathML, car ce dernier est destiné à être généré automatiquement par les applications. Les programmes lisent et analysent facilement le MathML car son code est en XML, de sorte que le MathML est couramment utilisé comme format de sortie et d’impression dans de nombreux domaines. 

Ce code d’exemple vous montre comment exporter une équation mathématique d’une présentation vers MathML :

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

## **FAQ**

**Qu’est‑ce qui est exactement exporté vers MathML — un paragraphe ou un bloc de formule individuel ?**

Vous pouvez exporter soit un paragraphe mathématique complet ([MathParagraph](https://reference.aspose.com/slides/fr/java/com.aspose.slides/mathparagraph/)), soit un bloc individuel ([MathBlock](https://reference.aspose.com/slides/fr/java/com.aspose.slides/mathblock/)) vers MathML. Les deux types fournissent une méthode pour écrire en MathML.

**Comment savoir si un objet sur une diapositive est une formule mathématique plutôt qu’un texte ordinaire ou une image ?**

Une formule se trouve dans une [MathPortion](https://reference.aspose.com/slides/fr/java/com.aspose.slides/mathportion/) et possède un [MathParagraph](https://reference.aspose.com/slides/fr/java/com.aspose.slides/mathparagraph/). Les images et les portions de texte ordinaires sans [MathParagraph](https://reference.aspose.com/slides/fr/java/com.aspose.slides/mathparagraph/) ne sont pas des formules exportables.

**D’où provient le MathML dans une présentation — est‑il spécifique à PowerPoint ou s’agit‑il d’une norme ?**

L’exportation cible le MathML standard (XML). Aspose utilise le Presentation MathML — le sous‑ensemble de présentation de la norme — qui est largement utilisé dans les applications et sur le web.

**L’exportation des formules à l’intérieur des tableaux, SmartArt, groupes, etc., est‑elle prise en charge ?**

Oui, si ces objets contiennent des portions de texte avec un [MathParagraph](https://reference.aspose.com/slides/fr/java/com.aspose.slides/mathparagraph/) (c’est‑à‑dire de véritables formules PowerPoint), elles sont exportées. Si une formule est incorporée sous forme d’image, elle ne l’est pas.

**L’exportation vers MathML modifie‑t‑elle la présentation originale ?**

Non. L’écriture du MathML est une sérialisation du contenu de la formule ; elle ne modifie pas le fichier de présentation.