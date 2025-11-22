---
title: Exportation d'équations mathématiques
type: docs
weight: 30
url: /fr/nodejs-java/exporting-math-equations/
---

## **Exporter des équations mathématiques depuis des présentations**

Aspose.Slides for Node.js via Java vous permet d'exporter des équations mathématiques depuis des présentations. Par exemple, vous pouvez avoir besoin d'extraire les équations mathématiques sur les diapositives (d'une présentation spécifique) et de les utiliser dans un autre programme ou une autre plateforme.

{{% alert color="primary" %}} 
Vous pouvez exporter les équations au format MathML, un format ou une norme populaire pour les équations mathématiques et les contenus similaires visibles sur le Web et dans de nombreuses applications. 
{{% /alert %}}

Alors que les humains écrivent facilement le code pour certains formats d'équations comme LaTeX, ils ont du mal à écrire le code pour MathML car ce dernier est destiné à être généré automatiquement par les applications. Les programmes lisent et analysent facilement le MathML parce que son code est en XML, ainsi le MathML est couramment utilisé comme format de sortie et d'impression dans de nombreux domaines. 

Ce code d'exemple vous montre comment exporter une équation mathématique d'une présentation vers MathML:
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

**Quel est exactement exporté vers MathML - un paragraphe ou un bloc de formule individuel ?**

Vous pouvez exporter soit un paragraphe mathématique complet ([MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/)) soit un bloc individuel ([MathBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/)) vers MathML. Les deux types offrent une méthode d'écriture vers MathML.

**Comment savoir si un objet sur une diapositive est une formule mathématique plutôt qu'un texte ordinaire ou une image ?**

Une formule se trouve dans une [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) et possède un [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/). Les images et les portions de texte ordinaires sans [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) ne sont pas des formules exportables.

**D'où provient le MathML dans une présentation - est-il spécifique à PowerPoint ou s'agit-il d'une norme ?**

L'exportation cible le MathML standard (XML). Aspose utilise le Presentation MathML - le sous-ensemble présentation de la norme - qui est largement utilisé dans les applications et sur le Web.

**L'exportation de formules à l'intérieur de tableaux, SmartArt, groupes, etc., est-elle prise en charge ?**

Oui, si ces objets contiennent des portions de texte avec un [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) (c'est a dire de véritables formules PowerPoint), elles sont exportées. Si une formule est intégrée en tant qu'image, elle ne l'est pas.

**L'exportation vers MathML modifie-t-elle la présentation originale ?**

Non. L'écriture du MathML est une sérialisation du contenu de la formule ; elle ne modifie pas le fichier de présentation.