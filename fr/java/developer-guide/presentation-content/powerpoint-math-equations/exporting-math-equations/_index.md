---
title: Exporter des équations mathématiques depuis des présentations en Java
linktitle: Exporter des équations
type: docs
weight: 30
url: /fr/java/exporting-math-equations/
keywords:
- exporter des équations mathématiques
- MathML
- LaTeX
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Débloquez l'exportation fluide des équations mathématiques de PowerPoint vers MathML avec Aspose.Slides for Java - préservez la mise en forme et améliorez la compatibilité."
---

## Exportation d'équations mathématiques depuis des présentations

Aspose.Slides for Java permet d'exporter les équations mathématiques depuis des présentations. Par exemple, il peut être nécessaire d'extraire les équations mathématiques présentes sur les diapositives (d'une présentation spécifique) et de les utiliser dans un autre programme ou une autre plateforme.

{{% alert color="primary" %}} 

Vous pouvez exporter les équations vers MathML, un format ou une norme populaire pour les équations mathématiques et les contenus similaires visibles sur le Web et dans de nombreuses applications.

{{% /alert %}}

Alors que les humains écrivent facilement le code pour certains formats d'équations comme LaTeX, ils ont du mal à écrire le code pour MathML car ce dernier doit être généré automatiquement par les applications. Les programmes lisent et analysent facilement le MathML parce que son code est en XML, ainsi le MathML est couramment utilisé comme format de sortie et d'impression dans de nombreux domaines.

Ce code d'exemple montre comment exporter une équation mathématique d'une présentation vers MathML:
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

**Qu'est-ce qui est exactement exporté vers MathML : un paragraphe ou un bloc de formule individuel ?**

Vous pouvez exporter soit un paragraphe mathématique complet ([MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/)) soit un bloc individuel ([MathBlock](https://reference.aspose.com/slides/java/com.aspose.slides/mathblock/)) vers MathML. Les deux types offrent une méthode pour écrire en MathML.

**Comment savoir si un objet sur une diapositive est une formule mathématique plutôt qu'un texte ordinaire ou une image ?**

Une formule réside dans une [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/) et possède un [MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/). Les images et les portions de texte ordinaires sans [MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/) ne sont pas des formules exportables.

**D'où provient le MathML dans une présentation : est-il propre à PowerPoint ou s'agit-il d'une norme ?**

L'exportation cible le MathML standard (XML). Aspose utilise le Presentation MathML — le sous‑ensemble de présentation de la norme — qui est largement utilisé dans les applications et sur le Web.

**L'exportation de formules à l'intérieur de tableaux, SmartArt, groupes, etc., est‑elle prise en charge ?**

Oui, si ces objets contiennent des portions de texte avec un [MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/) (c’est‑à‑dire de véritables formules PowerPoint), ils sont exportés. Si une formule est incorporée sous forme d'image, elle ne l'est pas.

**L'exportation vers MathML modifie‑t‑elle la présentation d'origine ?**

Non. L'écriture du MathML est une sérialisation du contenu de la formule ; elle ne modifie pas le fichier de présentation.