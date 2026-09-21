---
title: Modifier des documents PDF en Python
linktitle: Modifier PDF
type: docs
weight: 65
url: /fr/python-net/edit-pdf/
keywords:
- modifier PDF
- remplacer le texte PDF
- PDF en PPTX
- PPTX en PDF
- Python
- Aspose.Slides
description: "Modifiez des documents PDF en Python en les important dans Aspose.Slides, en remplaçant le texte et en enregistrant la présentation modifiée au format PDF."
---
## **Vue d'ensemble**

Aspose.Slides for Python via .NET vous permet de modifier le contenu d'un PDF en important ses pages sous forme de diapositives, en modifiant la présentation, puis en l'exportant de nouveau au format PDF. Cet article montre un simple remplacement de texte. La présentation reste en mémoire, de sorte que l'enregistrement d'un fichier PPTX intermédiaire est facultatif.

## **Remplacer du texte dans un PDF**

Utilisez [add_from_pdf](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slidecollection/add_from_pdf/) pour importer les pages, [replace_text](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/replace_text/) pour mettre à jour le texte, et [save](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/save/) pour exporter le résultat.

L'exemple suivant suppose que `input.pdf` contient le mot « Draft » en texte éditable après l'importation. Il remplace ce mot par « Final » et écrit `edited.pdf`. Effacer la diapositive initiale avant l'importation évite d'ajouter une page blanche supplémentaire dans le résultat. La recherche correspond aux mots entiers avec la même casse ; `None` signifie qu'aucun rappel de résultat n'est nécessaire.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("input.pdf")

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = True
    presentation.replace_text("Draft", "Final", search_options, None)

    presentation.save("edited.pdf", slides.export.SaveFormat.PDF)
```

Pour plus d'options, consultez [Search and Replace Text](/slides/fr/python-net/search-and-replace-text/) et [Convert PowerPoint to PDF](/slides/fr/python-net/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Remarque" %}}
Le remplacement de texte fonctionne sur le texte importé, pas sur le texte présent dans des images numérisées. La conversion peut affecter la mise en page et le formatage, il convient donc de vérifier le résultat, notamment lorsque le texte de remplacement est plus long que l'original.
{{% /alert %}}

## **FAQ**

**Dois-je enregistrer un fichier PPTX avant d'exporter le PDF ?**

Non. Vous pouvez modifier et exporter la même présentation en mémoire. Enregistrez une copie PPTX uniquement si vous souhaitez également continuer à la modifier dans PowerPoint ; voir [Save Presentations](/slides/fr/python-net/save-presentation/).

**Pourquoi certains textes peuvent-ils rester inchangés ?**

L'exemple recherche le mot complet « Draft » avec une casse exacte. Le texte importé sous forme d'image ou réparti sur plusieurs cadres de texte ne correspondra pas nécessairement à la recherche. Vérifiez le contenu importé et ajustez la recherche en fonction de votre document.