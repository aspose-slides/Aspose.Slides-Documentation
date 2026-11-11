---
title: Rendu des diapositives de présentation en images SVG en Python via Java
linktitle: Diapositive en SVG
type: docs
weight: 50
url: /fr/python-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint en SVG
- présentation en SVG
- diapositive en SVG
- PPT en SVG
- PPTX en SVG
- "options d'exportation SVG"
- SVG interactif
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Exportez les diapositives PowerPoint en images SVG en Python via Java et contrôlez les polices, le texte, les images, les ID et les événements avec Aspose.Slides."
---
## **Vue d'ensemble**

SVG est un format d'image XML extensible qui fonctionne bien pour la publication Web, les visionneuses de diapositives, les flux de travail d'accessibilité et le post‑traitement automatisé. Aspose.Slides exporte chaque diapositive vers un fichier SVG séparé et vous permet de contrôler la façon dont le texte, les polices, les images et les éléments SVG sont écrits.

Utilisez [SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) lorsque le SVG exporté doit être compact, prévisible sur tous les navigateurs ou prêt à être utilisé de manière interactive.

## **Exporter une diapositive au format SVG**

Créez une [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), sélectionnez une diapositive et écrivez‑la dans un flux avec [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/). Les exemples nécessitent un fichier `presentation.pptx` existant. Chaque exemple démarre la JVM si nécessaire et ferme ses flux de sortie. L'exemple suivant exporte chaque diapositive d'une présentation vers un fichier SVG séparé.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        output_file_name = f"slide-{slide.getSlideNumber()}.svg"
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

Le nom de fichier utilise [Slide.getSlideNumber](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideNumber) plutôt que l'index de boucle. Vous pouvez également exporter une forme individuelle avec [Shape.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) lorsqu'une visionneuse de diapositives ou une page Web ne nécessite que cette forme.

## **Configurer la sortie SVG**

[SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) contrôle le rendu SVG. Pour les cadres de texte, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameSize) inclut le cadre de texte dans la zone de rendu, et [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameRotation) détermine si la rotation du cadre est appliquée. Définissez [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) sur `True` lorsque le texte doit être rendu sans ligatures.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setDisableFontLigatures(True)
    svg_options.setUseFrameSize(True)
    svg_options.setUseFrameRotation(False)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-custom-options.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Contrôler le recadrage des extrémités de ligne aux pointes de flèche**

SVG 1.1 ne possède pas de paramètre d’insertion de marqueur pour spécifier où une ligne doit s’arrêter sous une pointe de flèche. Par défaut, Aspose.Slides raccourcit la ligne exportée afin que son trait ne dépasse pas le marqueur. Appelez [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableLineEndCropping) avec `True` pour dessiner le trait jusqu’au point final original de la ligne. Ce paramètre n’affecte que la sortie SVG. La ligne conserve sa position et sa longueur sur la diapositive.

L'exemple dessine des pointes de flèche en triangle et en losange sur des lignes de 2 et 10 points de largeur. Il exporte la même diapositive deux fois, en ne modifiant que l'option de recadrage.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, Presentation, ShapeType, SVGOptions
from java.awt import Color
from java.io import FileOutputStream

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    y = 40

    for style in [LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond]:
        for width in [2, 10]:
            line = slide.getShapes().addAutoShape(ShapeType.Line, 40, y, 200, 0)
            line_format = line.getLineFormat()
            line_format.getFillFormat().setFillType(FillType.Solid)
            line_format.getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
            line_format.setWidth(width)
            line_format.setEndArrowheadStyle(style)
            y += 50

    svg_options = SVGOptions()
    for disable_cropping, output_file_name in [(False, "cropped.svg"), (True, "uncropped.svg")]:
        svg_options.setDisableLineEndCropping(disable_cropping)
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

La comparaison montre la pointe de flèche triangulaire sur la ligne de 10 points. Lorsque le recadrage est activé, la pointe est nette. Lorsque le recadrage est désactivé, le trait dépasse les côtés inclinés du marqueur et laisse une extrémité plate.

![Triangle agrandi de 10 points avec une pointe nette lorsque le recadrage est activé et une extrémité plate lorsque le recadrage est désactivé](line-end-cropping.png)

Dans les autres lignes de l'exemple, le trait dépassant est moins visible sur le triangle de 2 points. Le losange rempli couvre l'extrémité du trait pour les deux largeurs.

## **Contrôler le texte et les polices**

Lors de l'exportation de diapositives au format SVG, vous pouvez contrôler si le texte reste du texte ou est converti en graphiques vectoriels, ainsi que la façon dont les polices externes sont incluses ou référencées. Les options suivantes vous aident à équilibrer la cohérence visuelle, la sélection du texte et les dépendances de polices dans le SVG exporté.

### **Vectoriser tout le texte**

Définissez [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) sur `True` pour écrire tout le texte de la diapositive sous forme de graphiques vectoriels. Cela élimine les dépendances de police et rend le rendu visuel plus cohérent sur tous les navigateurs, mais le texte n’est plus sélectionnable ni searchable en tant que texte SVG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setVectorizeText(True)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-vectorized-text.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

### **Choisir la façon dont les polices externes sont gérées**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) utilise une valeur [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/) pour les polices chargées de façon externe. Choisissez `AddLinksToFontFiles` pour référencer des fichiers de police séparés, `Embed` pour inclure les données de police dans le SVG, ou `Vectorize` pour rendre uniquement le texte qui utilise des polices externes sous forme de graphiques. Vérifiez la licence des polices avant de les incorporer.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions, SvgExternalFontsHandling
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    font_modes = [
        ("slide-with-font-links.svg", SvgExternalFontsHandling.AddLinksToFontFiles),
        ("slide-with-embedded-fonts.svg", SvgExternalFontsHandling.Embed),
        ("slide-with-vectorized-external-fonts.svg", SvgExternalFontsHandling.Vectorize),
    ]
    for output_file_name, font_mode in font_modes:
        svg_options = SVGOptions()
        svg_options.setExternalFontsHandling(font_mode)
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

## **Réduire la taille des images incorporées**

Utilisez [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) pour réduire la résolution des images incorporées, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) pour omettre les zones source recadrées, et [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) pour contrôler la qualité d’encodage JPEG. Ces paramètres réduisent la taille du fichier au détriment de la fidélité de l’image ou des données d’image conservées.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setPicturesCompression(PicturesCompression.Dpi150)
    svg_options.setDeletePicturesCroppedAreas(True)
    svg_options.setJpegQuality(80)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("compressed-slide.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Contrôler la résolution de rasterisation des métafichiers**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setMetafileRasterizationDpi) définit la limite inférieure de résolution pour rasteriser les métafichiers lors de l'exportation SVG. Utilisez-le pour équilibrer le détail et la taille du fichier lorsqu'une image EMF ou WMF est rasterisée. Il ne définit pas de DPI global pour le SVG ni ne force chaque objet de la diapositive à devenir une image raster.

Téléchargez [metafile-rasterization.pptx](metafile-rasterization.pptx), qui contient une image EMF avec des lignes diagonales très rapprochées. L'exemple suivant exporte sa première diapositive à trois résolutions de rasterisation via [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/). Tous les autres paramètres d'exportation restent identiques afin que les résultats puissent être comparés.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("metafile-rasterization.pptx")
try:
    for dpi in [72, 150, 300]:
        svg_options = SVGOptions()
        svg_options.setMetafileRasterizationDpi(dpi)
        svg_options.setPicturesCompression(PicturesCompression.Dpi330)
        svg_options.setJpegQuality(90)

        output_file_name = f"slide-{dpi}.svg"
        svg_stream = FileOutputStream(output_file_name)
        try:
            presentation.getSlides().get_Item(0).writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

Dans la sortie, l'EMF est devenu un PNG incorporé dans chaque SVG. Les mesures suivantes concernent la présentation fournie ; elles ne constituent pas une formule générale de conversion DPI → dimensions en pixels.

| DPI de rasterisation du métafichier | Dimensions du PNG incorporé | Taille du fichier SVG (octets) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

La comparaison ci‑dessous montre la même zone du raster incorporé affichée à la même taille agrandie. Les lignes diagonales présentent une pixellisation visible à 72 DPI et des bords plus lisses à des résolutions supérieures, tandis que la taille du fichier SVG augmente. Augmenter la valeur n’améliore pas forcément chaque détail ni ne modifie chaque image exportée.

![Détail agrandi des lignes diagonales à 72, 150 et 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) contrôle la réduction de résolution des images et peut masquer l’effet du changement de résolution de rasterisation du métafichier. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) contrôle la qualité d’encodage JPEG, pas la résolution de rasterisation du métafichier.

## **Attribuer des ID stables aux formes et au texte**

Utilisez un contrôleur de formatage Python enregistré via `jpype.JProxy` pour attribuer des valeurs [SvgShape.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setId) aux formes et [SvgTSpan.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgtspan/#setId) aux éléments de texte `tspan`. Assignez le proxy avec [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController).

Le contrôleur suivant utilise [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getOfficeInteropShapeId), qui est stable pendant toute la durée de vie de la forme, ainsi qu’un compteur réutilisable pour ses blocs de texte. Cela rend les ID générés adaptés au post‑traitement d’une présentation non modifiée.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

class StableSvgIdController:
    def __init__(self):
        self.current_shape_id = ""
        self.text_span_index = 0

    def formatShape(self, svg_shape, shape):
        self.current_shape_id = f"shape-{shape.getOfficeInteropShapeId()}"
        self.text_span_index = 0
        svg_shape.setId(self.current_shape_id)

    def formatText(self, svg_tspan, portion, text_frame):
        svg_tspan.setId(f"{self.current_shape_id}-text-{self.text_span_index}")
        self.text_span_index += 1


presentation = Presentation("presentation.pptx")
try:
    controller = StableSvgIdController()
    proxy = jpype.JProxy("com.aspose.slides.ISvgShapeAndTextFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(proxy)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-stable-ids.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Ajouter des gestionnaires d'événements SVG**

Dans un contrôleur de formatage Python, appelez [SvgShape.setEventHandler](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setEventHandler) avec une valeur [SvgEvent](https://reference.aspose.com/slides/python-java/aspose.slides/svgevent/) pour ajouter un gestionnaire d'événement JavaScript à une forme exportée. Enregistrez le contrôleur via `jpype.JProxy` et assignez‑le avec [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController). Définissez la fonction JavaScript dans la page ou le document SVG qui héberge le résultat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions, SvgEvent
from java.io import FileOutputStream

class SvgEventController:
    def formatShape(self, svg_shape, shape):
        if shape.getName() == "ActionButton":
            svg_shape.setId("action-button")
            svg_shape.setEventHandler(SvgEvent.OnClick, "handleShapeClick(event)")


presentation = Presentation("presentation.pptx")
try:
    controller = SvgEventController()
    proxy = jpype.JProxy("com.aspose.slides.ISvgShapeFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(proxy)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("interactive-slide.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

La page hôte peut définir la fonction JavaScript référencée par le gestionnaire. L’attribution d’ID et de gestionnaires d’événements permet aux visionneuses de diapositives, aux améliorations d’accessibilité et à d’autres flux de travail SVG interactifs.

## **FAQ**

**Quand devrais‑je utiliser [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) au lieu de [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) ?**

Utilisez [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) lorsque tout le texte doit être indépendant des polices. Utilisez [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) lorsque seul le texte utilisant des polices externes doit être converti en graphiques.

**Quelle est la meilleure façon de réduire la taille d’un SVG ?**

Commencez par compresser les images incorporées, supprimer les zones d’image recadrées et choisir des fichiers de police liés lorsque l’environnement cible peut les fournir. Testez le résultat car une résolution d’image plus faible, une qualité JPEG réduite et le texte vectorisé ont chacun des compromis différents en termes de qualité et de taille.

**Puis‑je modifier les éléments SVG exportés après l’exportation ?**

Oui. Attribuez des ID via un contrôleur de formatage, puis sélectionnez les éléments SVG correspondants dans votre outil de post‑traitement ou votre script de navigateur.