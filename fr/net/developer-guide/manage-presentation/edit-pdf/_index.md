---
title: Modifier des documents PDF dans .NET
linktitle: Modifier PDF
type: docs
weight: 65
url: /fr/net/edit-pdf/
keywords:
- modifier PDF
- remplacer le texte PDF
- PDF vers PPTX
- PPTX vers PDF
- .NET
- C#
- Aspose.Slides
description: "Modifier des documents PDF en C# en les important dans Aspose.Slides, en remplaçant le texte, puis en enregistrant la présentation modifiée au format PDF."
---
## **Aperçu**

Aspose.Slides pour .NET vous permet de modifier le contenu PDF en important ses pages sous forme de diapositives, en modifiant la présentation, puis en l'exportant à nouveau vers PDF. Cet article montre un remplacement simple de texte. La présentation reste en mémoire, ainsi l'enregistrement d'un fichier PPTX intermédiaire est facultatif.

## **Remplacer du texte dans un PDF**

Utilisez [AddFromPdf](https://reference.aspose.com/slides/fr/net/aspose.slides/slidecollection/addfrompdf/) pour importer les pages, [ReplaceText](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/replacetext/) pour mettre à jour le texte, et [Save](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/save/) pour exporter le résultat.

L'exemple suivant suppose que `input.pdf` contient le mot « Draft » sous forme de texte modifiable après l'importation. Il remplace ce mot par « Final » et écrit `edited.pdf`. Vider la diapositive initiale avant l'importation évite une page blanche supplémentaire dans le résultat. La recherche correspond aux mots entiers avec la même casse ; `null` signifie qu'aucun rappel de résultat n'est nécessaire.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Slides.RemoveAt(0);

presentation.Slides.AddFromPdf("input.pdf");

var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = true
};
presentation.ReplaceText("Draft", "Final", searchOptions, null);

presentation.Save("edited.pdf", SaveFormat.Pdf);
```

Pour plus d'options, consultez [Search and Replace Text](/slides/fr/net/search-and-replace-text/) et [Convert PowerPoint to PDF](/slides/fr/net/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Le remplacement de texte fonctionne sur le texte importé, pas sur le texte présent dans les images numérisées. La conversion peut affecter la mise en page et le formatage, il faut donc examiner le résultat, surtout lorsque le texte de remplacement est plus long que l'original.
{{% /alert %}}

## **FAQ**

**Dois-je enregistrer un fichier PPTX avant d'exporter le PDF ?**

Non. Vous pouvez modifier et exporter la même présentation en mémoire. Enregistrez une copie PPTX uniquement si vous souhaitez également continuer à la modifier dans PowerPoint ; consultez [Save Presentations](/slides/fr/net/save-presentation/).

**Pourquoi certains textes peuvent-ils rester inchangés ?**

L'exemple correspond au mot entier « Draft » avec la casse exacte. Le texte importé sous forme d'image ou réparti sur plusieurs cadres de texte ne correspondra pas nécessairement à la recherche. Vérifiez le contenu importé et ajustez la recherche pour votre document.