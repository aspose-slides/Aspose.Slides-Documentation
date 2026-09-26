---
title: "Modifier la taille et l'orientation de la page de notes en Python"
linktitle: "Taille de la page de notes"
type: docs
weight: 10
url: /fr/python-net/notes-size/
keywords:
- "taille de la page de notes"
- "orientation des notes"
- "notes paysage"
- "notes portrait"
- "taille du document de distribution"
- "PowerPoint"
- "présentation"
- "PPT"
- "PPTX"
- "Python"
- "Aspose.Slides"
description: "Lire et modifier les dimensions de la page de notes dans Aspose.Slides pour Python via .NET, changer l'orientation, vérifier les tailles enregistrées et exporter les notes ou les documents de distribution en PDF et images."
---
## **Aperçu**

Utilisez [Presentation.notes_size](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/notes_size/) pour accéder aux paramètres de la page de notes de la présentation. Il renvoie un objet [NotesSize](https://reference.aspose.com/slides/fr/python-net/aspose.slides/notessize/) dont la propriété [size](https://reference.aspose.com/slides/fr/python-net/aspose.slides/notessize/size/) est modifiable. Bien que l'objet de paramètres lui‑même soit en lecture seule, vous pouvez assigner de nouvelles dimensions à sa propriété size.

La largeur et la hauteur sont exprimées en **points**, avec 72 points par pouce. Par exemple, 900 × 600 points correspondent à 12,5 × 8⅓ pouces. Ces paramètres s’appliquent à la présentation, et non aux notes d’une diapositive individuelle.

| Paramètre | Objectif |
| --- | --- |
| [Presentation.notes_size](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/notes_size/) | Contrôle les dimensions de la page de notes et les dimensions de page utilisées pour l’exportation des documents de distribution. |
| [Presentation.slide_size](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/slide_size/) | Contrôle les dimensions des diapositives normales de la présentation via [SlideSize](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slidesize/). |

Modifier l’un ou l’autre paramètre ne modifie pas automatiquement l’autre. Modifier l’orientation de la page de notes ne fait pas non plus pivoter les diapositives normales. Voir [Slide Size](/slides/fr/python-net/slide-size/) pour redimensionner les diapositives normales.

Les exemples ci‑dessous utilisent un fichier `sample.pptx` existant. Pour les exemples d’exportation, utilisez une présentation contenant au moins une diapositive avec des notes du présentateur. Chaque exemple peut être exécuté indépendamment.

## **Lire la taille et l’orientation de la page de notes**

Lisez la largeur et la hauteur puis comparez‑les pour déterminer l’orientation : une page plus large est en orientation paysage, une page plus haute est en orientation portrait, et des dimensions égales décrivent une page carrée. Cet exemple affiche les dimensions réelles en points, sans supposer de format de papier standard.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    size = presentation.notes_size.size
    orientation = "Square"

    if size.width > size.height:
        orientation = "Landscape"
    elif size.width < size.height:
        orientation = "Portrait"

    print(f"Notes page: {size.width:g} x {size.height:g} points")
    print(f"Orientation: {orientation}")
```

## **Passer en mode paysage sans changer la taille du papier**

Pour ne modifier que l’orientation, échangez la largeur et la hauteur existantes. Cela conserve les longueurs des deux côtés, y compris celles d’un format de papier personnalisé. La condition ci‑dessus empêche une page déjà en paysage d’être reconvertie en portrait et laisse une page carrée inchangée.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    size = presentation.notes_size.size

    if size.width < size.height:
        presentation.notes_size.size = drawing.SizeF(size.height, size.width)

    presentation.save("landscape-notes.pptx", slides.export.SaveFormat.PPTX)
```

Pour une orientation portrait, utilisez la même affectation lorsque `size.width > size.height`. Ne remplacez pas les dimensions A4 ou Letter à moins de vouloir également modifier la taille du papier.

## **Définir et vérifier une taille de page de notes personnalisée**

Attribuez les deux dimensions simultanément, puis utilisez [Presentation.save](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/save/) pour enregistrer la présentation. Cet exemple définit une page paysage de 900 × 600 points, l’enregistre au format PPTX et rouvre le fichier enregistré pour vérifier les valeurs persistées. La comparaison autorise une tolérance de 0,01 point pour les valeurs à virgule flottante ; ce n’est pas une garantie de précision pour chaque format de fichier.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

expected_size = drawing.SizeF(900, 600)

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = expected_size
    presentation.save("custom-notes.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("custom-notes.pptx") as reopened:
    actual_size = reopened.notes_size.size
    width_matches = abs(actual_size.width - expected_size.width) < 0.01
    height_matches = abs(actual_size.height - expected_size.height) < 0.01
    preserved = width_matches and height_matches

    print(f"Stored notes page: {actual_size.width:g} x {actual_size.height:g} points")
    print(f"Size preserved: {preserved}")
```

Le résultat attendu est `900 x 600 points` et `Size preserved: True`. Vérifier une présentation nouvellement ouverte confirme le fichier enregistré, plutôt que seulement les paramètres en mémoire.

## **Exporter les notes et les documents de distribution**

Les dimensions de la page définissent la zone disponible pour les mises en page des notes ou des documents de distribution. Elles n’activent pas ces mises en page seules : configurez également les options d’exportation. L’exportation des diapositives normales continue d’utiliser les dimensions des diapositives.

### **Exporter les notes en PDF et PNG**

Attribuez [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/notescommentslayoutingoptions/) à [PdfOptions.slides_layout_options](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/pdfoptions/slides_layout_options/) pour inclure les notes dans le PDF. Cet exemple rend également la première diapositive avec notes en PNG en utilisant [Slide.get_image](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slide/get_image/) et [RenderingOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/renderingoptions/).

Le mode [BOTTOM_TRUNCATED](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/notespositions/) conserve les notes sur une seule page ; les notes qui ne tiennent pas peuvent être tronquées. Le PDF utilise des pages de 900 × 600 points. À l’échelle d’image de 1 × 1 utilisée ci‑dessous, le PNG fait 900 × 600 pixels. Les points décrivent la géométrie de la page ; les pixels décrivent la sortie raster, dont les dimensions dépendent également de l’échelle de rendu.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = drawing.SizeF(900, 600)

    layout = slides.export.NotesCommentsLayoutingOptions()
    layout.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = layout

    presentation.save("notes.pdf", slides.export.SaveFormat.PDF, pdf_options)

    rendering_options = slides.export.RenderingOptions()
    rendering_options.slides_layout_options = layout

    with presentation.slides[0].get_image(rendering_options, 1, 1) as image:
        image.save("first-slide-notes.png", slides.ImageFormat.PNG)
```

Pour l’exportation PDF avec de longues notes, [BOTTOM_FULL](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/notespositions/) autorise des pages supplémentaires si nécessaire. N’utilisez pas ce mode avec l’appel d’image d’une seule diapositive ci‑above, qui ne le prend pas en charge. Après redimensionnement, examinez la sortie pour des notes tronquées et le placement des objets notes‑master existants ; modifier uniquement les dimensions de la page ne doit pas être considéré comme une garantie que tout le contenu tiendra. Voir [Convert PowerPoint to PDF with Notes](/slides/fr/python-net/convert-powerpoint-to-pdf-with-notes/) pour plus d’informations sur l’exportation des notes.

### **Exporter les documents de distribution en PDF**

Utilisez [HandoutLayoutingOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/handoutlayoutingoptions/) pour plusieurs vignettes de diapositives sur une même page. L’exemple suivant définit une page de 900 × 600 points et utilise [HandoutType.HANDOUTS_4_HORIZONTAL](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/handouttype/) pour disposer jusqu’à quatre diapositives par page. Le préréglage horizontal contrôle l’ordre des diapositives ; l’orientation de la page provient de sa largeur et de sa hauteur.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = drawing.SizeF(900, 600)

    layout = slides.export.HandoutLayoutingOptions()
    layout.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = layout

    presentation.save("handouts.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Modifier la taille de la page change la zone disponible pour la grille de distribution sans modifier les dimensions des diapositives sources. Pour les images de distribution, utilisez [Presentation.get_images](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/get_images/) avec la mise en page de distribution, plutôt que la méthode d’image d’une diapositive individuelle. Dans Aspose.Slides, le rendu de distribution au niveau de la présentation utilise les dimensions de la page de notes, tandis que l’appel d’image d’une diapositive individuelle ne produit pas la page de distribution. Voir [Handout Mode](/slides/fr/python-net/convert-powerpoint-in-handout-mode/) pour les options de mise en page.

## **Taille de page dans les visionneuses, l’exportation et l’impression**

Gardez séparés la taille de la présentation stockée, la taille de page exportée et la taille du papier imprimé :

- **Visionneuses de présentation :** Un visionneur peut afficher ou imprimer les notes en utilisant ses propres règles de mise en page. Si une autre application enregistre le fichier, rouvrez‑le et vérifiez à nouveau les dimensions ; la conversion de format de cette application peut les normaliser.
- **Formats d’exportation :** Les exemples de PDF de notes et de documents de distribution ci‑dessus utilisent les dimensions de page configurées. Les images raster utilisent des dimensions de pixels entières et une échelle de rendu, de sorte que les valeurs de points fractionnaires peuvent être arrondies dans la sortie d’image. L’exportation des diapositives normales n’applique pas la taille de la page de notes.
- **Pilotes d’imprimante :** La sélection du papier, la rotation automatique et les paramètres d’ajustement à la page peuvent modifier la sortie physique sans changer les dimensions stockées dans la présentation ou le PDF. Pour une taille de papier spécifique, alignez les paramètres de l’imprimante et inspectez l’aperçu avant impression.

## **FAQ**

**Puis‑je définir la taille des notes pour une seule diapositive ?**

La taille de la page de notes est un paramètre au niveau de la présentation. Les diapositives individuelles peuvent contenir un contenu de notes différent, mais cette propriété ne fournit pas de taille de page distincte pour chaque diapositive.

**Pourquoi la modification de l’orientation des notes n’a‑t‑elle pas modifié mes diapositives ?**

Les pages de notes et les diapositives normales ont des dimensions indépendantes. Utilisez les paramètres de taille des diapositives normales lorsque vous souhaitez redimensionner les diapositives elles‑elles.

**Pourquoi mon résultat enregistré ou imprimé a‑t‑il une taille différente ?**

Tout d’abord, rouvrez la présentation enregistrée et comparez ses dimensions de notes. Si celles‑ci ont changé, vérifiez si l’enregistrement ou la conversion du fichier dans une autre application a modifié les paramètres de page. Si ce n’est pas le cas, examinez la mise en page d’exportation, l’échelle de l’image, les paramètres du visionneur et la sélection du papier d’imprimante.