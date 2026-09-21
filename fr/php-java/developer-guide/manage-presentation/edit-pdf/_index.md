---
title: Modifier des documents PDF en PHP
linktitle: Modifier PDF
type: docs
weight: 65
url: /fr/php-java/edit-pdf/
keywords:
- modifier PDF
- remplacer le texte PDF
- PDF en PPTX
- PPTX en PDF
- PHP
- Aspose.Slides
description: "Modifiez des documents PDF en PHP en les important dans Aspose.Slides, en remplaçant le texte et en enregistrant la présentation modifiée au format PDF."
---
## **Vue d'ensemble**

Aspose.Slides for PHP via Java vous permet de modifier le contenu d’un PDF en important ses pages comme diapositives, en modifiant la présentation et en l’exportant de nouveau au format PDF. Cet article montre un remplacement de texte simple. La présentation reste en mémoire, ainsi l’enregistrement d’un fichier PPTX intermédiaire est facultatif.

## **Remplacer du texte dans un PDF**

Utilisez [SlideCollection::addFromPdf](https://reference.aspose.com/slides/fr/php-java/aspose.slides/slidecollection/#addFromPdf) pour importer les pages, [Presentation::replaceText](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#replaceText) pour mettre à jour le texte, et [Presentation::save](https://reference.aspose.com/slides/fr/php-java/aspose.slides/presentation/#save) pour exporter le résultat.

L’exemple suivant suppose que `input.pdf` contient le mot « Draft » sous forme de texte modifiable après l’importation. Il remplace ce mot par « Final » et écrit `edited.pdf`. Vider la diapositive initiale avant l’importation évite une page blanche supplémentaire dans le résultat. La recherche correspond aux mots entiers avec la même casse ; `null` signifie qu’aucun rappel de résultat n’est nécessaire.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextSearchOptions;

$presentation = new Presentation();
try {
    $presentation->getSlides()->removeAt(0);

    $presentation->getSlides()->addFromPdf("input.pdf");

    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(true);
    $presentation->replaceText("Draft", "Final", $searchOptions, null);

    $presentation->save("edited.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

Pour plus d’options, consultez [Recherche et remplacement de texte](/slides/fr/php-java/search-and-replace-text/) et [Convertir PowerPoint en PDF](/slides/fr/php-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Remarque" %}}
Le remplacement de texte fonctionne sur le texte importé, pas sur le texte présent dans des images numérisées. La conversion peut affecter la mise en page et le formatage, il faut donc examiner le résultat, surtout lorsque le texte de remplacement est plus long que l’original.
{{% /alert %}}

## **FAQ**

**Dois-je enregistrer un fichier PPTX avant d’exporter le PDF ?**

Non. Vous pouvez modifier et exporter la même présentation en mémoire. Enregistrez une copie PPTX uniquement si vous souhaitez également continuer à la modifier dans PowerPoint ; consultez [Enregistrer les présentations](/slides/fr/php-java/save-presentation/).

**Pourquoi certains textes peuvent-ils rester inchangés ?**

L’exemple recherche le mot entier « Draft » avec la casse exacte. Le texte importé sous forme d’image ou réparti sur plusieurs zones de texte ne correspondra pas nécessairement à la recherche. Vérifiez le contenu importé et ajustez la recherche pour votre document.