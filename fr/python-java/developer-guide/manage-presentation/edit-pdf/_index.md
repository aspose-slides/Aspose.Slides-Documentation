---
title: Modifier des documents PDF en Python via Java
linktitle: Modifier PDF
type: docs
weight: 65
url: /fr/python-java/edit-pdf/
keywords:
- modifier PDF
- remplacer le texte PDF
- PDF vers PPTX
- PPTX vers PDF
- Python
- Java
- Aspose.Slides
description: "Modifier des documents PDF en Python via Java en les important dans Aspose.Slides, en remplaçant le texte et en enregistrant la présentation modifiée au format PDF."
---
## **Vue d'ensemble**

Aspose.Slides for Python via Java vous permet de modifier le contenu PDF en important ses pages en tant que diapositives, en modifiant la présentation et en l'exportant de nouveau vers PDF. Cet article montre un remplacement de texte simple. La présentation reste en mémoire, de sorte que l’enregistrement d’un fichier PPTX intermédiaire est facultatif.

## **Remplacer du texte dans un PDF**

Utilisez [addFromPdf](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#addFromPdf) pour importer les pages, [replaceText](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#replaceText) pour mettre à jour le texte, et [save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save) pour exporter le résultat.

L’exemple suivant s’attend à ce que `input.pdf` contienne le mot "Draft" en texte modifiable après l’importation. Il remplace ce mot par "Final" et écrit `edited.pdf`. Vider la diapositive initiale avant l’importation évite une page blanche supplémentaire dans la sortie. La recherche correspond aux mots entiers avec la même casse ; `None` signifie qu’aucun rappel de résultat n’est nécessaire.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextSearchOptions

presentation = Presentation()
try:
    presentation.getSlides().removeAt(0)

    presentation.getSlides().addFromPdf("input.pdf")

    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(True)
    presentation.replaceText("Draft", "Final", search_options, None)

    presentation.save("edited.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

Pour plus d’options, consultez [Search and Replace Text](/slides/fr/python-java/search-and-replace-text/) et [Convert PowerPoint to PDF](/slides/fr/python-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
Le remplacement de texte fonctionne sur le texte importé, pas sur le texte présent dans les images numérisées. La conversion peut affecter la mise en page et le formatage, il faut donc vérifier la sortie, surtout lorsque le texte de remplacement est plus long que l’original.
{{% /alert %}}

## **FAQ**

**Do I need to save a PPTX file before exporting the PDF?**

Non. Vous pouvez modifier et exporter la même présentation en mémoire. Enregistrez une copie PPTX uniquement si vous souhaitez aussi continuer à l’éditer dans PowerPoint ; voir [Save Presentations](/slides/fr/python-java/save-presentation/).

**Why might some text remain unchanged?**

L’exemple correspond au mot entier "Draft" avec une casse exacte. Le texte importé en tant qu’image ou réparti sur plusieurs cadres de texte ne correspondra pas nécessairement à la recherche. Vérifiez le contenu importé et ajustez la recherche pour votre document.