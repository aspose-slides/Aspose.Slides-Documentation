---
title: Convertir PowerPoint en Word
type: docs
weight: 110
url: /fr/java/convert-powerpoint-to-word/
keywords: "Convertir PowerPoint, PPT, PPTX, Présentation, Word, DOCX, DOC, PPTX en DOCX, PPT en DOC, PPTX en DOC, PPT en DOCX, Java, java, Aspose.Slides"
description: "Convertir une présentation PowerPoint en Word en Java"
---

Si vous prévoyez d'utiliser du contenu textuel ou des informations d'une présentation (PPT ou PPTX) de nouvelles manières, vous pourriez bénéficier de la conversion de la présentation en Word (DOC ou DOCX).

* Comparé à Microsoft PowerPoint, l'application Microsoft Word est mieux équipée en outils ou fonctionnalités pour le contenu.
* En plus des fonctions d'édition dans Word, vous pourriez également bénéficier de fonctionnalités de collaboration, d'impression et de partage améliorées.

{{% alert color="primary" %}} 

Vous pourriez vouloir essayer notre [**Convertisseur en ligne de Présentation en Word**](https://products.aspose.app/slides/conversion/ppt-to-word) pour voir ce que vous pourriez gagner en travaillant avec du contenu textuel à partir de diapositives.

{{% /alert %}} 

## **Aspose.Slides et Aspose.Words**

Pour convertir un fichier PowerPoint (PPTX ou PPT) en Word (DOCX ou DOC), vous avez besoin à la fois d'[Aspose.Slides pour Java](https://products.aspose.com/slides/java/) et d'[Aspose.Words pour Java](https://products.aspose.com/words/java/).

En tant qu'API autonome, [Aspose.Slides](https://products.aspose.app/slides) pour java fournit des fonctions qui vous permettent d'extraire des textes des présentations.

[Aspose.Words](https://docs.aspose.com/words/java/) est une API de traitement de documents avancée qui permet aux applications de générer, modifier, convertir, rendre, imprimer des fichiers et d'effectuer d'autres tâches avec des documents sans utiliser Microsoft Word.

## **Convertir PowerPoint en Word**

1. Téléchargez les bibliothèques [Aspose.Slides pour Java](https://downloads.aspose.com/slides/java) et [Aspose.Words pour Java](https://downloads.aspose.com/words/java).
2. Ajoutez *aspose-slides-x.x-jdk16.jar* et *aspose-words-x.x-jdk16.jar* à votre CLASSPATH.
3. Utilisez cet extrait de code pour convertir PowerPoint en Word :

```java
Presentation pres = new Presentation("sample.pptx");

Document doc = new Document();
DocumentBuilder builder = new DocumentBuilder(doc);

for (ISlide slide : pres.getSlides()) {
    // génère une image de diapositive sous forme de tableau d'octets
    IImage image = slide.getImage(1, 1);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
    image.save(imageStream, ImageFormat.Png);
    image.dispose();

    builder.insertImage(imageStream.toByteArray());

    // insère les textes de la diapositive
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof AutoShape) {
            builder.writeln(((AutoShape) shape).getTextFrame().getText());
        }
    }

    builder.insertBreak(BreakType.PAGE_BREAK);
}

doc.save("output.docx");
pres.dispose();
```