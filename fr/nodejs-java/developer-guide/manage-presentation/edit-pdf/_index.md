---
title: Modifier des documents PDF en JavaScript
linktitle: Modifier PDF
type: docs
weight: 65
url: /fr/nodejs-java/edit-pdf/
keywords:
- modifier PDF
- remplacer le texte PDF
- PDF vers PPTX
- PPTX vers PDF
- Node.js
- JavaScript
- Aspose.Slides
description: "Modifiez des documents PDF en JavaScript en les important dans Aspose.Slides, en remplaçant le texte et en enregistrant la présentation modifiée au format PDF."
---
## **Aperçu**

Aspose.Slides for Node.js via Java vous permet de modifier le contenu d'un PDF en important ses pages sous forme de diapositives, en modifiant la présentation, puis en l'exportant à nouveau au format PDF. Cet article montre un remplacement de texte simple. La présentation reste en mémoire, ainsi l'enregistrement d'un fichier PPTX intermédiaire est optionnel.

## **Remplacer le texte dans un PDF**

Utilisez [addFromPdf](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slidecollection/#addFromPdf) pour importer les pages, [replaceText](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#replaceText) pour mettre à jour le texte, et [save](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/#save) pour exporter le résultat.

L'exemple suivant suppose que `input.pdf` contient le mot « Draft » en tant que texte modifiable après l'importation. Il remplace ce mot par « Final » et écrit `edited.pdf`. Effacer la diapositive initiale avant l'importation évite une page blanche supplémentaire dans la sortie. La recherche correspond aux mots entiers avec la même casse ; `null` signifie qu'aucun rappel de résultat n'est nécessaire.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlides().removeAt(0);

    presentation.getSlides().addFromPdf("input.pdf");

    const searchOptions = new slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);
    presentation.replaceText("Draft", "Final", searchOptions, null);

    presentation.save("edited.pdf", slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

Pour plus d'options, consultez [Recherche et remplacement de texte](/slides/fr/nodejs-java/search-and-replace-text/) et [Convertir PowerPoint en PDF](/slides/fr/nodejs-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Le remplacement de texte fonctionne sur le texte importé, pas sur le texte présent dans les images numérisées. La conversion peut affecter la mise en page et le formatage, il faut donc vérifier le résultat, surtout lorsque le texte de remplacement est plus long que l'original.
{{% /alert %}}

## **FAQ**

**Dois-je enregistrer un fichier PPTX avant d'exporter le PDF ?**

Non. Vous pouvez modifier et exporter la même présentation en mémoire. Enregistrez une copie PPTX uniquement si vous souhaitez également continuer à l'éditer dans PowerPoint ; consultez [Enregistrer des présentations](/slides/fr/nodejs-java/save-presentation/).

**Pourquoi certains textes peuvent-ils rester inchangés ?**

L'exemple recherche le mot complet « Draft » avec la casse exacte. Le texte importé sous forme d'image ou réparti sur plusieurs cadres de texte ne correspondra pas nécessairement à la recherche. Vérifiez le contenu importé et ajustez la recherche pour votre document.