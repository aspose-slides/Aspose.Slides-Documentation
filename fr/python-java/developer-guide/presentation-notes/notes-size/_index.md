---
title: Modifier la taille et l'orientation de la page des notes en Python via Java
linktitle: Taille de la page des notes
type: docs
weight: 10
url: /fr/python-java/notes-size/
keywords:
- taille de la page des notes
- orientation des notes
- notes paysage
- notes portrait
- taille du prospectus
- PowerPoint
- présentation
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "Lire et modifier les dimensions de la page des notes dans Aspose.Slides pour Python via Java, changer l'orientation, vérifier les tailles enregistrées, et exporter les notes ou les prospectus en PDF et images."
---
## **Vue d'ensemble**

Utilisez [Presentation.getNotesSize](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getNotesSize) pour accéder aux paramètres de la page des notes de la présentation. Elle renvoie un objet [NotesSize](https://reference.aspose.com/slides/fr/python-java/aspose.slides/notessize/) dont la méthode [setSize](https://reference.aspose.com/slides/fr/python-java/aspose.slides/notessize/#setSize) définit les dimensions de la page. Bien que l'objet des paramètres ne puisse pas être remplacé, vous pouvez attribuer de nouvelles dimensions via cette méthode.

La largeur et la hauteur sont spécifiées en **points**, avec 72 points par pouce. Par exemple, 900 × 600 points correspondent à 12,5 × 8⅓ pouces. Ces paramètres s'appliquent à la présentation, plutôt qu'aux notes d'une diapositive individuelle.

| Paramètre | Objectif |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getNotesSize) | Contrôle les dimensions de la page des notes et les dimensions de page utilisées pour l'exportation des prospectus. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getSlideSize) | Contrôle les dimensions normales des diapositives de la présentation via [SlideSize](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidesize/). |

Modifier l'un ou l'autre paramètre ne modifie pas automatiquement l'autre. Modifier l'orientation de la page des notes ne fait pas tourner les diapositives normales non plus. Consultez [Taille des diapositives](/slides/fr/python-java/slide-size/) pour redimensionner les diapositives normales.

Les exemples ci‑dessous utilisent un fichier `sample.pptx` existant. Pour les exemples d'exportation, utilisez une présentation contenant au moins une diapositive avec des notes d'orateur. Chaque exemple peut être exécuté indépendamment.

## **Lire la taille et l'orientation de la page des notes**

Lisez la largeur et la hauteur et comparez‑les pour déterminer l'orientation : une page plus large est en paysage, une page plus haute est en portrait, et des dimensions égales décrivent une page carrée. Cet exemple affiche les dimensions réelles en points, sans supposer un format de papier standard.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()
    orientation = "Square"

    if size.getWidth() > size.getHeight():
        orientation = "Landscape"
    elif size.getWidth() < size.getHeight():
        orientation = "Portrait"

    print(f"Notes page: {size.getWidth()} x {size.getHeight()} points")
    print(f"Orientation: {orientation}")
finally:
    presentation.dispose()
```

## **Passer en paysage sans modifier la taille du papier**

Pour ne changer que l'orientation, échangez la largeur et la hauteur existantes. Cela préserve les longueurs des deux côtés, y compris celles d'une taille de papier personnalisée. La condition ci‑détectée empêche une page déjà en paysage d'être rétablie en portrait et laisse une page carrée inchangée.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()

    if size.getWidth() < size.getHeight():
        width = size.getWidth()
        size.setSize(size.getHeight(), width)
        presentation.getNotesSize().setSize(size)

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Pour l'orientation portrait, utilisez la même affectation lorsque `size.getWidth() > size.getHeight()`. Ne remplacez pas les dimensions A4 ou Letter sauf si vous souhaitez également modifier la taille du papier.

## **Définir et vérifier une taille de page des notes personnalisée**

Attribuez les deux dimensions ensemble, puis utilisez [Presentation.save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save) pour enregistrer la présentation. Cet exemple définit une page paysage de 900 × 600 points, l’enregistre au format PPTX et ouvre à nouveau le fichier enregistré pour vérifier les valeurs persistées. La comparaison autorise une tolérance de 0,01 point pour les valeurs à virgule flottante ; ce n’est pas une garantie de précision pour chaque format de fichier.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    expected_size = Dimension(900, 600)
    presentation.getNotesSize().setSize(expected_size)

    presentation.save("custom-notes.pptx", SaveFormat.Pptx)

    reopened = Presentation("custom-notes.pptx")
    try:
        actual_size = reopened.getNotesSize().getSize()
        width_matches = abs(actual_size.getWidth() - expected_size.getWidth()) < 0.01
        height_matches = abs(actual_size.getHeight() - expected_size.getHeight()) < 0.01
        preserved = width_matches and height_matches

        print(f"Stored notes page: {actual_size.getWidth()} x {actual_size.getHeight()} points")
        print(f"Size preserved: {preserved}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Le résultat attendu est `900.0 x 600.0 points` et `Size preserved: True`. Vérifier une présentation nouvellement ouverte confirme le fichier enregistré, plutôt que seulement les paramètres en mémoire.

## **Exporter les notes et les prospectus**

Les dimensions de la page définissent la zone disponible pour les dispositions des notes ou des prospectus. Elles n’activent pas ces dispositions seules : configurez également les options d’exportation. L’exportation des diapositives normales continue d’utiliser les dimensions des diapositives.

### **Exporter les notes en PDF et PNG**

Attribuez [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/notescommentslayoutingoptions/) à [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) pour inclure les notes dans le PDF. Cet exemple rend également la première diapositive avec notes en PNG en utilisant [Slide.getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/#getImage) et [RenderingOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/renderingoptions/).

Le mode [BottomTruncated](https://reference.aspose.com/slides/fr/python-java/aspose.slides/notespositions/) conserve les notes sur une page ; les notes qui ne tiennent pas peuvent être tronquées. Le PDF utilise des pages de 900 × 600 points. À l’échelle d’image de 1 × 1 utilisée ci‑dessous, le PNG fait 900 × 600 pixels. Les points décrivent la géométrie de la page ; les pixels décrivent la sortie raster, dont les dimensions dépendent également de l’échelle de rendu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, RenderingOptions, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = NotesCommentsLayoutingOptions()
    layout.setNotesPosition(NotesPositions.BottomTruncated)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("notes.pdf", SaveFormat.Pdf, pdf_options)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout)

    image = presentation.getSlides().get_Item(0).getImage(rendering_options, 1.0, 1.0)
    try:
        image.save("first-slide-notes.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

Pour l’exportation PDF avec des notes longues, [BottomFull](https://reference.aspose.com/slides/fr/python-java/aspose.slides/notespositions/) permet d’ajouter des pages supplémentaires si nécessaire. N’utilisez pas ce mode avec l’appel d’image d’une seule diapositive ci‑dessus, qui ne le prend pas en charge. Après redimensionnement, examinez la sortie pour détecter des notes découpées et le placement des objets notes‑master existants ; modifier uniquement les dimensions de la page ne doit pas être considéré comme une garantie que tout le contenu tiendra. Consultez [Convertir PowerPoint en PDF avec notes](/slides/fr/python-java/convert-powerpoint-to-pdf-with-notes/) pour plus d’informations sur l’exportation des notes.

### **Exporter les prospectus en PDF**

Utilisez [HandoutLayoutingOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/handoutlayoutingoptions/) pour plusieurs vignettes de diapositives sur une page. L’exemple suivant définit une page de 900 × 600 points et utilise [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/fr/python-java/aspose.slides/handouttype/) pour disposer jusqu’à quatre diapositives par page. Le preset horizontal contrôle l’ordre des diapositives ; l’orientation de la page provient de sa largeur et de sa hauteur.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = HandoutLayoutingOptions()
    layout.setHandout(HandoutType.Handouts4Horizontal)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Modifier la taille de la page modifie la zone disponible pour la grille de prospectus sans changer les dimensions des diapositives sources. Pour les images de prospectus, utilisez [Presentation.getImages](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getImages) avec la disposition de prospectus, plutôt que la méthode d’image d’une diapositive individuelle. Dans Aspose.Slides, le rendu de prospectus au niveau de la présentation utilise les dimensions de la page des notes, tandis que l’appel d’image d’une diapositive individuelle ne produit pas la page de prospectus. Consultez [Mode prospectus](/slides/fr/python-java/convert-powerpoint-in-handout-mode/) pour les options de mise en page.

## **Taille de page dans les visionneuses, l’exportation et l’impression**

Conservez séparément la taille de la présentation stockée, la taille de la page exportée et la taille du papier imprimé :

- **Visionneuses de présentation :** Un visionneur peut afficher ou imprimer les notes en utilisant ses propres règles de mise en page. Si une autre application enregistre le fichier, rouvrez‑le et vérifiez à nouveau les dimensions ; la conversion de format de cette application peut les normaliser.
- **Formats d’exportation :** Les exemples de PDF de notes et de prospectus ci‑dessus utilisent les dimensions de page configurées. Les images raster utilisent des dimensions en pixels entiers et une échelle de rendu, de sorte que les valeurs en points fractionnaires peuvent être arrondies dans la sortie d’image. L’exportation des diapositives normales n’applique pas la taille de la page des notes.
- **Pilotes d’imprimante :** La sélection du papier, la rotation automatique et les paramètres d’ajustement à la page peuvent modifier le rendu physique sans changer les dimensions stockées dans la présentation ou le PDF. Pour une taille de papier précise, alignez les paramètres de l’imprimante et examinez l’aperçu avant impression.

## **FAQ**

**Puis‑je définir la taille des notes pour une seule diapositive ?**

La taille de la page des notes est un paramètre au niveau de la présentation. Les diapositives individuelles peuvent avoir un contenu de notes différent, mais cette propriété ne fournit pas de taille de page séparée pour chaque diapositive.

**Pourquoi le changement d’orientation des notes n’a‑t‑il pas modifié mes diapositives ?**

Les pages de notes et les diapositives normales ont des dimensions indépendantes. Utilisez les paramètres de taille des diapositives normales lorsque vous souhaitez redimensionner les diapositives elles‑elles.

**Pourquoi mon résultat enregistré ou imprimé a‑t‑il une taille différente ?**

Tout d’abord, rouvrez la présentation enregistrée et comparez ses dimensions de notes. Si celles‑ci ont changé, vérifiez si l’enregistrement ou la conversion du fichier dans une autre application a modifié les paramètres de page. Si ce n’est pas le cas, examinez la disposition d’exportation, l’échelle de l’image, les paramètres du visionneur et la sélection du papier d’imprimante.