---
title: Convertir les présentations PowerPoint en documents Word sur Android
linktitle: PowerPoint vers Word
type: docs
weight: 110
url: /fr/androidjava/convert-powerpoint-to-word/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir diapositive
- convertir PPT
- convertir PPTX
- PowerPoint vers Word
- présentation vers Word
- diapositive vers Word
- PPT vers Word
- PPTX vers Word
- PowerPoint vers DOCX
- présentation vers DOCX
- diapositive vers DOCX
- PPT vers DOCX
- PPTX vers DOCX
- PowerPoint vers DOC
- présentation vers DOC
- diapositive vers DOC
- PPT vers DOC
- PPTX vers DOC
- enregistrer PPT en DOCX
- enregistrer PPTX en DOCX
- exporter PPT en DOCX
- exporter PPTX en DOCX
- Android
- Java
- Aspose.Slides
description: "Convertissez les diapositives PowerPoint PPT et PPTX en documents Word modifiables en Java à l’aide d’Aspose.Slides pour Android, en conservant la mise en page, les images et le formatage précis."
---

Si vous prévoyez d’utiliser le contenu textuel ou les informations d’une présentation (PPT ou PPTX) de nouvelles manières, vous pouvez bénéficier de la conversion de la présentation en Word (DOC ou DOCX). 

* Comparé à Microsoft PowerPoint, l’application Microsoft Word offre davantage d’outils ou de fonctionnalités pour le contenu. 
* En plus des fonctions de modification dans Word, vous pouvez également profiter de fonctionnalités améliorées de collaboration, d’impression et de partage. 

{{% alert color="primary" %}} 

Vous pouvez essayer notre [**Convertisseur en ligne de Présentation en Word**](https://products.aspose.app/slides/conversion/ppt-to-word) pour voir ce que vous pourriez gagner en travaillant avec le contenu textuel des diapositives. 

{{% /alert %}} 

## **Aspose.Slides et Aspose.Words**

Pour convertir un fichier PowerPoint (PPTX ou PPT) en Word (DOCX ou DOCX), vous avez besoin à la fois de [Aspose.Slides for Android via Java](https://products.aspose.com/slides/androidjava/) et de [Aspose.Words for Android via Java](https://products.aspose.com/words/androidjava/).

En tant qu’API autonome, [Aspose.Slides](https://products.aspose.app/slides) pour java fournit des fonctions qui permettent d’extraire le texte des présentations. 

[Aspose.Words](https://docs.aspose.com/words/androidjava/) est une API avancée de traitement de documents qui permet aux applications de créer, modifier, convertir, rendre, imprimer des fichiers et d’exécuter d’autres tâches avec les documents sans utiliser Microsoft Word.

## **Convertir PowerPoint en Word**

1. Téléchargez les bibliothèques [Aspose.Slides for Android via Java](https://downloads.aspose.com/slides/java) et [Aspose.Words for Java](https://downloads.aspose.com/words/java).
2. Ajoutez *aspose-slides-x.x-jdk16.jar* et *aspose-words-x.x-jdk16.jar* à votre CLASSPATH.
3. Utilisez cet extrait de code pour convertir le PowerPoint en Word:
```java
Presentation pres = new Presentation("sample.pptx");

Document doc = new Document();
DocumentBuilder builder = new DocumentBuilder(doc);

for (ISlide slide : pres.getSlides()) {
    // génère une image de diapositive sous forme de flux de tableau d'octets
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


## **FAQ**

**Quels composants doivent être installés pour convertir des présentations PowerPoint et OpenDocument en documents Word ?**

Vous devez uniquement ajouter le package correspondant pour [Aspose.Slides for Android via Java](https://releases.aspose.com/slides/androidjava/) et [Aspose.Words for Android via Java](https://releases.aspose.com/words/androidjava/) à votre projet. Les deux bibliothèques fonctionnent comme des API autonomes, aucune installation de Microsoft Office n’est requise.

**Tous les formats de présentations PowerPoint et OpenDocument sont-ils pris en charge ?**

Aspose.Slides [prend en charge tous les formats de présentation](/slides/fr/androidjava/supported-file-formats/), y compris PPT, PPTX, ODP et d’autres types de fichiers courants. Cela garantit que vous pouvez travailler avec des présentations créées dans diverses versions de Microsoft PowerPoint.