---
title: Exporter des équations mathématiques depuis des présentations en JavaScript
linktitle: Exporter des équations
type: docs
weight: 30
url: /fr/nodejs-java/exporting-math-equations/
keywords:
- exporter des équations mathématiques
- exporter des équations vers LaTeX
- PowerPoint vers LaTeX
- MathML
- LaTeX
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Exporter des équations mathématiques depuis des présentations PowerPoint vers LaTeX ou MathML directement avec Aspose.Slides pour Node.js via Java."
---
## **Introduction**

Aspose.Slides vous permet d'exporter des équations mathématiques à partir de présentations. Par exemple, vous pouvez avoir besoin d'extraire les équations mathématiques des diapositives (d'une présentation spécifique) et de les utiliser dans un autre programme ou une autre plateforme. 

{{% alert color="primary" %}} 
Vous pouvez exporter les équations directement vers LaTeX ou vers MathML, un standard populaire pour le contenu mathématique utilisé sur le web et dans de nombreuses applications.
{{% /alert %}}

## **Exporter des équations mathématiques vers LaTeX**

Aspose.Slides peut convertir directement une équation mathématique PowerPoint en LaTeX ; aucun fichier MathML intermédiaire ni convertisseur externe n'est nécessaire. Une équation mathématique est stockée dans un cadre de texte sous forme de [MathPortion](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathportion/). Utilisez [MathPortion.getMathParagraph](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathportion/#getMathParagraph--) pour obtenir un [MathParagraph](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathparagraph/), puis appelez [MathParagraph.toLatex](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathparagraph/#toLatex--). La méthode renvoie une chaîne que vous pouvez enregistrer, afficher, envoyer à une autre application ou traiter davantage.

L'exemple suivant examine chaque cadre de texte sur chaque diapositive, trouve toutes les portions mathématiques et écrit chaque équation dans un fichier `.tex` séparé :
```javascript
const presentation = new aspose.slides.Presentation("equations.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const slideNumber = slideIndex + 1;
        let equationNumber = 1;
        const textFrames = aspose.slides.SlideUtil.getAllTextBoxes(slide);

        for (const textFrame of textFrames) {
            const paragraphCount = textFrame.getParagraphs().getCount();
            for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
                const portionCount = paragraph.getPortions().getCount();
                for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    if (!java.instanceOf(portion, "com.aspose.slides.MathPortion")) {
                        continue;
                    }

                    const mathParagraph = portion.getMathParagraph();
                    const latexFileName = `slide_${slideNumber}_equation_${equationNumber}.tex`;

                    const latexText = mathParagraph.toLatex();
                    fileSystem.writeFileSync(latexFileName, latexText, "utf8");
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-) renvoie tous les cadres de texte trouvés sur une diapositive. La vérification du type [MathPortion](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathportion/) sépare les véritables équations modifiables du texte et des images ordinaires.

Tous les moteurs LaTeX et modèles de documents ne prennent pas en charge les mêmes commandes, packages ou caractères Unicode. Testez la chaîne renvoyée avec le moteur LaTeX utilisé par votre application. Si un symbole ou un élément Office Math n'a pas de représentation appropriée dans cet environnement, remplacez‑le dans la chaîne renvoyée par une commande spécifique au projet ou ignorez l'équation et consignez le problème pour révision.

## **Enregistrer les équations mathématiques au format MathML**

Si les humains peuvent facilement écrire le code de certains formats d'équations comme LaTeX, ils ont du mal à écrire le code pour MathML, car ce dernier est destiné à être généré automatiquement par les applications. Les programmes lisent et analysent facilement le MathML car son code est en XML, ce qui fait de MathML un format de sortie et d’impression couramment utilisé dans de nombreux domaines. 

Ce code d'exemple vous montre comment exporter une équation mathématique d'une présentation vers MathML :
```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    var mathParagraph = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
    mathParagraph.add(new aspose.slides.MathematicalText("a").setSuperscript("2").join("+").join(new aspose.slides.MathematicalText("b").setSuperscript("2")).join("=").join(new aspose.slides.MathematicalText("c").setSuperscript("2")));
    var stream = null;
    mathParagraph.writeAsMathMl(stream);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Qu'est‑ce qui est exactement exporté vers MathML — un paragraphe ou un bloc de formule individuel ?**  
Vous pouvez exporter soit un paragraphe mathématique complet ([MathParagraph](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathparagraph/)) soit un bloc individuel ([MathBlock](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathblock/)) vers MathML. Les deux types offrent une méthode pour écrire en MathML.

**Comment déterminer si un objet sur une diapositive est une formule mathématique plutôt qu'un texte ordinaire ou une image ?**  
Une formule se trouve dans une [MathPortion](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathportion/) et possède un [MathParagraph](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathparagraph/). Les images et les portions de texte ordinaires sans [MathParagraph](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathparagraph/) ne sont pas des formules exportables.

**D'où provient le MathML dans une présentation — est‑il spécifique à PowerPoint ou s'agit‑il d'un standard ?**  
L'exportation vise le MathML standard (XML). Aspose utilise le Presentation MathML — le sous‑ensemble de présentation du standard — qui est largement utilisé dans les applications et sur le web.

**L'exportation de formules à l'intérieur des tableaux, SmartArt, groupes, etc., est‑elle prise en charge ?**  
Oui, si ces objets contiennent des portions de texte avec un [MathParagraph](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/mathparagraph/) (c’est‑à‑dire de véritables formules PowerPoint), elles sont exportées. Si une formule est intégrée sous forme d'image, elle ne l'est pas.

**L'exportation vers MathML modifie‑t‑elle la présentation originale ?**  
Non. La génération de MathML est une sérialisation du contenu de la formule ; elle ne modifie pas le fichier de présentation.