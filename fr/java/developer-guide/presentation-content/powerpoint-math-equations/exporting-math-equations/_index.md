---
title: Exporter des équations mathématiques depuis les présentations en Java
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
description: "Exportez des équations mathématiques depuis les présentations PowerPoint vers LaTeX ou MathML directement avec Aspose.Slides pour Java."
---
## **Introduction**

Aspose.Slides vous permet d'exporter des equations mathematiques a partir de presentations. Par exemple, vous pourriez avoir besoin d'extraire les equations mathematiques des diapositives (d'une presentation specifique) et de les utiliser dans un autre programme ou une autre plateforme. 

{{% alert color="info" %}}
Vous pouvez exporter les equations directement vers LaTeX ou vers MathML, un standard populaire pour le contenu mathematique utilise sur le Web et dans de nombreuses applications.
{{% /alert %}}

## **Exporter les equations mathematiques vers LaTeX**

Aspose.Slides peut convertir directement une equation mathematique PowerPoint en LaTeX; un fichier MathML intermediaire et un convertisseur externe ne sont pas necessaires. Une equation mathematique est stockee dans un cadre de texte sous la forme d'un [IMathPortion](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imathportion/). Utilisez [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imathportion/#getMathParagraph--) pour obtenir un [IMathParagraph](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imathparagraph/), puis appelez [IMathParagraph.toLatex](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imathparagraph/#toLatex--). La methode renvoie une chaine que vous pouvez enregistrer, afficher, envoyer a une autre application ou traiter davantage.

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

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/fr/java/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) renvoie tous les cadres de texte trouves sur une diapositive. La verification du type [IMathPortion](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imathportion/) separe les veritables equa tions modifiables du texte ordinaire et des images.

Les moteurs LaTeX et les modeles de documents ne prennent pas tous en charge les memes commandes, packages ou caracteres Unicode. Testez la chaine renvoyee avec le moteur LaTeX utilise par votre application. Si un symbole ou un element Office Math n'a pas de representation adaptée dans cet environnement, remplacez-le dans la chaine renvoyee par une commande propre au projet ou ignorez l'equation et consignez le probleme pour revision.

## **Enregistrer les equations mathematiques au format MathML**

Alors que les humains ecrivent facilement le code de certains formats d'equations comme LaTeX, ils ont du mal a ecrire le code pour MathML car ce dernier doit etre genere automatiquement par les applications. Les programmes lisent et analyse facilement le MathML parce que son code est en XML, ainsi le MathML est couramment utilise comme format de sortie et d'impression dans de nombreux domaines. 

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

## **FAQ**

**Qu'est-ce qui est exactement exporte vers MathML - un paragraphe ou un bloc de formule individuel ?**

Vous pouvez exporter soit un paragraphe mathematique complet ([MathParagraph](https://reference.aspose.com/slides/fr/java/com.aspose.slides/mathparagraph/)), soit un bloc individuel ([MathBlock](https://reference.aspose.com/slides/fr/java/com.aspose.slides/mathblock/)) vers MathML. Les deux types offrent une methode pour ecrire en MathML.

**Comment determiner qu'un objet sur une diapositive est une formule mathematique plutot qu'un texte ordinaire ou une image ?**

Une formule se trouve dans un [MathPortion](https://reference.aspose.com/slides/fr/java/com.aspose.slides/mathportion/) et possede un [MathParagraph](https://reference.aspose.com/slides/fr/java/com.aspose.slides/mathparagraph/). Les images et les portions de texte ordinaires qui ne contiennent pas de [MathParagraph](https://reference.aspose.com/slides/fr/java/com.aspose.slides/mathparagraph/) ne sont pas des formules exportables.

**D'ou provient le MathML dans une presentation - est-il specifique a PowerPoint ou s'agit-il d'un standard ?**

L'exportation cible le MathML standard (XML). Aspose utilise le Presentation MathML -- le sous-ensemble de presentation du standard -- qui est largement utilise dans les applications et sur le Web.

**L'exportation de formules a l'interieur de tableaux, SmartArt, groupes, etc., est-elle prise en charge ?**

Oui, si ces objets contiennent des parties de texte avec un [MathParagraph](https://reference.aspose.com/slides/fr/java/com.aspose.slides/mathparagraph/) (c'est-a-dire de veritables formules PowerPoint), elles sont exportees. Si une formule est integree sous forme d'image, elle ne l'est pas.

**L'exportation vers MathML modifie-t-elle la presentation originale ?**

Non. L'ecriture du MathML est une serialisation du contenu de la formule ; elle ne modifie pas le fichier de presentation.