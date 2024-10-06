---
title: Exportation d'équations mathématiques
type: docs
weight: 30
url: /java/exporting-math-equations/

---

## Exportation d'équations mathématiques depuis des présentations

Aspose.Slides pour Java vous permet d'exporter des équations mathématiques depuis des présentations. Par exemple, vous pourriez avoir besoin d'extraire les équations mathématiques sur des diapositives (d'une présentation spécifique) et de les utiliser dans un autre programme ou sur une autre plateforme.

{{% alert color="primary" %}} 

Vous pouvez exporter des équations au format MathML, un format ou standard populaire pour les équations mathématiques et le contenu similaire vu sur le web et dans de nombreuses applications.

{{% /alert %}}

Alors que les humains écrivent facilement le code pour certains formats d'équation comme LaTeX, ils ont du mal à écrire le code pour MathML car ce dernier est censé être généré automatiquement par des applications. Les programmes lisent et analysent facilement le MathML car son code est en XML, donc MathML est couramment utilisé comme format de sortie et d'impression dans de nombreux domaines.

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