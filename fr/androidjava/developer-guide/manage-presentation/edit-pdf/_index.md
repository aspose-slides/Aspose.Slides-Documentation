---
title: Modifier des documents PDF sur Android
linktitle: Modifier PDF
type: docs
weight: 65
url: /fr/androidjava/edit-pdf/
keywords:
- modifier PDF
- remplacer le texte PDF
- PDF vers PPTX
- PPTX vers PDF
- Android
- Java
- Aspose.Slides
description: "Modifiez des documents PDF sur Android avec Java en les important dans Aspose.Slides, en remplaçant le texte et en enregistrant la présentation modifiée au format PDF."
---
## **Aperçu**

Aspose.Slides for Android via Java vous permet de modifier le contenu PDF en important ses pages sous forme de diapositives, en modifiant la présentation, puis en l'exportant à nouveau au format PDF. Cet article montre un remplacement de texte simple. La présentation reste en mémoire, de sorte que l'enregistrement d'un fichier PPTX intermédiaire est facultatif.

## **Remplacer du texte dans un PDF**

Utilisez [addFromPdf](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) pour importer les pages, [replaceText](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) pour mettre à jour le texte, et [save](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) pour exporter le résultat.

L'exemple suivant suppose que `input.pdf` contient le mot « Draft » en texte modifiable après l'importation. Il remplace ce mot par « Final » et écrit `edited.pdf`. Vider la diapositive initiale avant l'importation évite une page blanche supplémentaire dans la sortie. La recherche correspond aux mots entiers avec la même casse ; `null` signifie qu'aucun rappel de résultat n'est nécessaire.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.TextSearchOptions;

Presentation presentation = new Presentation();
try {
    presentation.getSlides().removeAt(0);

    presentation.getSlides().addFromPdf("input.pdf");

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);
    presentation.replaceText("Draft", "Final", searchOptions, null);

    presentation.save("edited.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

Pour plus d'options, voyez [Recherche et remplacement de texte](/slides/fr/androidjava/search-and-replace-text/) et [Convertir PowerPoint en PDF](/slides/fr/androidjava/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Le remplacement de texte fonctionne sur le texte importé, pas sur le texte présent dans les images numérisées. La conversion peut affecter la mise en page et le formatage, il faut donc vérifier le résultat, surtout lorsque le texte de remplacement est plus long que l'original.
{{% /alert %}}

## **FAQ**

**Faut-il enregistrer un fichier PPTX avant d'exporter le PDF ?**

Non. Vous pouvez modifier et exporter la même présentation en mémoire. Enregistrez une copie PPTX uniquement si vous voulez également continuer à la modifier dans PowerPoint ; consultez [Enregistrer des présentations](/slides/fr/androidjava/save-presentation/).

**Pourquoi certains textes peuvent-ils rester inchangés ?**

L'exemple correspond au mot entier « Draft » avec la casse exacte. Le texte importé sous forme d'image ou réparti sur plusieurs zones de texte ne correspondra pas nécessairement à la recherche. Vérifiez le contenu importé et ajustez la recherche pour votre document.