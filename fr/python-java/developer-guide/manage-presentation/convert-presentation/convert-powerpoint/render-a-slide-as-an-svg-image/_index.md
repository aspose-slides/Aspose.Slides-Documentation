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
- options d'export SVG
- SVG interactif
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Exportez les diapositives PowerPoint au format SVG en Python via Java et contrôlez les polices, le texte, les images, les ID et les événements avec Aspose.Slides."
---
## **Vue d'ensemble**

SVG est un format d'image XML évolutif qui fonctionne bien pour la publication web, les visionneuses de diapositives, les flux de travail d'accessibilité et le post‑traitement automatisé. Aspose.Slides exporte chaque diapositive vers un fichier SVG séparé et vous permet de contrôler la façon dont le texte, les polices, les images et les éléments SVG sont écrits.

Utilisez [SVGOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/svgoptions/) lorsque le SVG exporté doit être compact, prévisible sur tous les navigateurs ou prêt pour une utilisation interactive.

## **Exporter une diapositive au format SVG**

Créez une [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/), sélectionnez une diapositive et écrivez-la dans un flux avec [Slide.writeAsSvg](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/). Les exemples nécessitent un fichier `presentation.pptx` existant. Chaque exemple démarre la JVM si nécessaire et ferme ses flux de sortie. L'exemple suivant exporte chaque diapositive d'une présentation en tant que fichier SVG distinct.

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

Le nom de fichier utilise [Slide.getSlideNumber](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/#getSlideNumber) plutôt que l'index de boucle. Vous pouvez également exporter une forme individuelle avec [Shape.writeAsSvg](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/) lorsqu'un visualiseur de diapositive ou une page Web ne nécessite que cette forme.

## **Configurer la sortie SVG**

[SVGOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/svgoptions/) contrôle le rendu SVG. Pour les cadres de texte, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/fr/python-java/aspose.slides/svgoptions/#setUseFrameSize) inclut le cadre de texte dans la zone de rendu, et [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/svgoptions/#setUseFrameRotation) détermine si la rotation du cadre est appliquée. Réglez [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/fr/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) sur `True` lorsque le texte doit être rendu sans ligatures.

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

## **Contrôler le texte et les polices**

### **Vectoriser tout le texte**

Définissez [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/fr/python-java/aspose.slides/svgoptions/#setVectorizeText) sur `True` pour écrire tout le texte de la diapositive sous forme de graphiques vectoriels. Cela élimine les dépendances de police et rend le résultat visuel plus cohérent sur tous les navigateurs, mais le texte n’est plus sélectionnable ni recherchable en tant que texte SVG.

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

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/fr/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) utilise une valeur [SvgExternalFontsHandling](https://reference.aspose.com/slides/fr/python-java/aspose.slides/svgexternalfontshandling/) pour les polices chargées de manière externe. Choisissez `AddLinksToFontFiles` pour faire référence à des fichiers de police séparés, `Embed` pour inclure les données de police dans le SVG, ou `Vectorize` pour rendre uniquement le texte qui utilise des polices externes sous forme de graphiques. Vérifiez la licence des polices avant d’intégrer des polices.

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

Utilisez [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/fr/python-java/aspose.slides/svgoptions/#setPicturesCompression) pour réduire la résolution des images incorporées, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/fr/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) pour omettre les zones recadrées de la source, et [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/fr/python-java/aspose.slides/svgoptions/#setJpegQuality) pour contrôler la qualité d'encodage JPEG. Ces réglages réduisent la taille du fichier au détriment de la fidélité de l'image ou des données d'image conservées.

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

## **Attribuer des ID stables aux formes et au texte**

Utilisez un contrôleur de formatage Python enregistré via `jpype.JProxy` pour attribuer des valeurs [SvgShape.setId](https://reference.aspose.com/slides/fr/python-java/aspose.slides/svgshape/#setId) aux formes et des valeurs [SvgTSpan.setId](https://reference.aspose.com/slides/fr/python-java/aspose.slides/svgtspan/#setId) aux éléments de texte `tspan`. Assignez le proxy avec [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/fr/python-java/aspose.slides/svgoptions/#setShapeFormattingController).

Le contrôleur suivant utilise [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#getOfficeInteropShapeId), qui est stable pendant toute la durée de vie de la forme, ainsi qu'un compteur répétable pour ses `tspan` de texte. Cela rend les ID générés adaptés au post‑traitement d’une présentation non modifiée.

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

Dans un contrôleur de formatage Python, appelez [SvgShape.setEventHandler](https://reference.aspose.com/slides/fr/python-java/aspose.slides/svgshape/#setEventHandler) avec une valeur [SvgEvent](https://reference.aspose.com/slides/fr/python-java/aspose.slides/svgevent/) pour ajouter un gestionnaire d'événement JavaScript à une forme exportée. Enregistrez le contrôleur via `jpype.JProxy` et assignez‑le avec [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/fr/python-java/aspose.slides/svgoptions/#setShapeFormattingController). Définissez la fonction JavaScript dans la page ou le document SVG qui héberge le résultat.

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

**Quand devrais‑je utiliser [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/fr/python-java/aspose.slides/svgoptions/#setVectorizeText) au lieu de [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/fr/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) ?**

Utilisez [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/fr/python-java/aspose.slides/svgoptions/#setVectorizeText) lorsque tout le texte doit être indépendant des polices. Utilisez [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/fr/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) lorsque seul le texte utilisant des polices externes doit être converti en graphiques.

**Quelle est la meilleure façon de rendre un SVG plus petit ?**

Commencez par compresser les images incorporées, supprimer les zones d'image recadrées et choisir des fichiers de police liés lorsque l'environnement cible peut les fournir. Testez le résultat car la résolution d'image réduite, la qualité JPEG plus basse et le texte vectorisé ont chacun des compromis différents en termes de qualité et de taille.

**Puis‑je modifier les éléments SVG exportés après l'exportation ?**

Oui. Attribuez des ID via un contrôleur de formatage, puis sélectionnez les éléments SVG correspondants dans votre outil de post‑traitement ou votre script de navigateur.