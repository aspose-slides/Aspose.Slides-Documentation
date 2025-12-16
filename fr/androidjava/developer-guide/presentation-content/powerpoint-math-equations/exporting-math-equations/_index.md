---
title: Exporter des équations mathématiques à partir de présentations sur Android
linktitle: Exporter les équations
type: docs
weight: 30
url: /fr/androidjava/exporting-math-equations/
keywords:
- exporter des équations mathématiques
- MathML
- LaTeX
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Déverrouillez une exportation fluide des équations mathématiques de PowerPoint vers MathML avec Aspose.Slides pour Android via Java — conservez la mise en forme et améliorez la compatibilité."
---

## **Exporter des équations mathématiques à partir de présentations**

Aspose.Slides for Android via Java vous permet d'exporter des équations mathématiques à partir de présentations. Par exemple, il se peut que vous deviez extraire les équations mathématiques des diapositives (d'une présentation spécifique) et les utiliser dans un autre programme ou une autre plateforme.

{{% alert color="primary" %}} 
Vous pouvez exporter les équations au format MathML, un format ou une norme populaire pour les équations mathématiques et contenus similaires visibles sur le web et dans de nombreuses applications. 
{{% /alert %}}

Bien que les humains écrivent facilement le code pour certains formats d'équations comme LaTeX, ils ont du mal à écrire le code pour MathML car ce dernier est censé être généré automatiquement par les applications. Les programmes lisent et analysent facilement le MathML parce que son code est en XML, ainsi le MathML est couramment utilisé comme format de sortie et d’impression dans de nombreux domaines. 

Ce code d'exemple vous montre comment exporter une équation mathématique d'une présentation vers MathML :
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

**Que exporte-t-on exactement vers MathML — un paragraphe ou un bloc de formule individuel ?**
Vous pouvez exporter soit un paragraphe mathématique complet ([MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/)) soit un bloc individuel ([MathBlock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathblock/)) vers MathML. Les deux types offrent une méthode pour écrire en MathML.

**Comment savoir si un objet sur une diapositive est une formule mathématique plutôt qu'un texte ordinaire ou une image ?**
Une formule se trouve dans une [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/) et possède un [MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/). Les images et les portions de texte ordinaires sans [MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/) ne sont pas des formules exportables.

**D’où provient le MathML dans une présentation — est-il spécifique à PowerPoint ou s'agit-il d'une norme ?**
L'exportation cible le MathML standard (XML). Aspose utilise le Presentation MathML — le sous‑ensemble de présentation de la norme — qui est largement utilisé dans les applications et sur le web.

**L'exportation de formules à l'intérieur de tableaux, SmartArt, groupes, etc., est‑elle prise en charge ?**
Oui, si ces objets contiennent des portions de texte avec un [MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/) (c’est‑à‑dire des formules PowerPoint authentiques), elles sont exportées. Si une formule est intégrée sous forme d'image, elle ne l’est pas.

**L'exportation vers MathML modifie‑t‑elle la présentation d'origine ?**
Non. L’écriture du MathML est une sérialisation du contenu de la formule ; elle ne modifie pas le fichier de présentation.