---
title: Rendu des diapositives de présentation en images SVG avec Python
linktitle: Diapositive en SVG
type: docs
weight: 50
url: /fr/python-net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint en SVG
- présentation en SVG
- diapositive en SVG
- PPT en SVG
- PPTX en SVG
- options d'exportation SVG
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Exportez les diapositives PowerPoint en images SVG avec Python et contrôlez les polices, le texte et les images à l'aide d'Aspose.Slides."
---
## **Vue d'ensemble**

SVG est un format d'image XML extensible qui convient bien à la publication Web, aux visionneuses de diapositives, aux flux de travail d'accessibilité et au post‑traitement automatisé. Aspose.Slides exporte chaque diapositive vers un fichier SVG distinct et vous permet de contrôler la façon dont le texte, les polices, les images et les éléments SVG sont écrits.

Utilisez [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) lorsque le SVG exporté doit être compact, prévisible sur tous les navigateurs ou prêt à être utilisé de manière interactive.

## **Exporter une diapositive au format SVG**

Créez une [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), sélectionnez une diapositive et écrivez‑la dans un flux. L'exemple suivant exporte chaque diapositive d'une présentation sous forme de fichier SVG distinct.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

Le nom de fichier utilise [Slide.slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/) plutôt que l'indice de boucle. Vous pouvez également exporter une forme individuelle avec [Shape.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) lorsqu'un visionneur de diapositives ou une page Web n'a besoin que de cette forme.

## **Configurer la sortie SVG**

[SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) contrôle le rendu SVG. Pour les cadres de texte, [SVGOptions.use_frame_size](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_size/) inclut le cadre de texte dans la zone de rendu, et [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) détermine si la rotation du cadre est appliquée. Réglez [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) sur `True` lorsque le texte doit être rendu sans ligatures.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.disable_font_ligatures = True
    svg_options.use_frame_size = True
    svg_options.use_frame_rotation = False

    with open("slide-with-custom-options.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

## **Contrôler le recadrage des extrémités de ligne aux pointes de flèche**

SVG 1.1 ne possède pas de paramètre d'insertion de marqueur pour spécifier où une ligne doit s'arrêter sous une pointe de flèche. Par défaut, Aspose.Slides raccourcit la ligne exportée afin que son trait ne dépasse pas le marqueur. Réglez [SVGOptions.disable_line_end_cropping](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/disable_line_end_cropping/) sur `True` pour tracer le trait jusqu'à l'extrémité d'origine de la ligne. Ce paramètre n'affecte que la sortie SVG. La ligne conserve sa position et sa longueur sur la diapositive.

L'exemple dessine des pointes de flèche triangulaires et en forme de losange sur des lignes de 2 et 10 points de largeur. Il exporte la même diapositive deux fois, en ne modifiant que l'option de recadrage.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    y = 40

    for style in (slides.LineArrowheadStyle.TRIANGLE, slides.LineArrowheadStyle.DIAMOND):
        for width in (2, 10):
            line = slide.shapes.add_auto_shape(slides.ShapeType.LINE, 40, y, 200, 0)
            line_format = line.line_format
            line_format.fill_format.fill_type = slides.FillType.SOLID
            line_format.fill_format.solid_fill_color.color = drawing.Color.dark_blue
            line_format.width = width
            line_format.end_arrowhead_style = style
            y += 50

    options = slides.export.SVGOptions()
    options.disable_line_end_cropping = False
    with open("cropped.svg", "wb") as cropped:
        slide.write_as_svg(cropped, options)

    options.disable_line_end_cropping = True
    with open("uncropped.svg", "wb") as uncropped:
        slide.write_as_svg(uncropped, options)
```

La comparaison montre la pointe triangulaire sur la ligne de 10 points. Avec le recadrage activé, la pointe est nette. Avec le recadrage désactivé, le trait dépasse les côtés inclinés du marqueur et laisse une extrémité plate.

![Triangle agrandi de 10 points avec une pointe nette lorsque le recadrage est activé et une extrémité plate lorsque le recadrage est désactivé](line-end-cropping.png)

Dans les autres lignes de l'exemple, le trait qui dépasse est moins visible sur le triangle de 2 points. Le losange rempli couvre l'extrémité du trait pour les deux largeurs.

## **Contrôler le texte et les polices**

Lors de l'exportation de diapositives au format SVG, vous pouvez contrôler si le texte reste du texte ou est converti en graphiques vectoriels, ainsi que la manière dont les polices externes sont incluses ou référencées. Les options suivantes vous aident à équilibrer la cohérence visuelle, la sélection du texte et les dépendances de polices dans le SVG exporté.

### **Vectoriser tout le texte**

Réglez [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) sur `True` pour écrire tout le texte des diapositives sous forme de graphiques vectoriels. Cela élimine les dépendances aux polices et rend le résultat visuel plus cohérent sur tous les navigateurs, mais le texte n'est plus sélectionnable ou recherchable en tant que texte SVG.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **Choisir la façon dont les polices externes sont gérées**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) utilise une valeur [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) pour les polices chargées extérieurement. Choisissez `ADD_LINKS_TO_FONT_FILES` pour référencer des fichiers de polices séparés, `EMBED` pour inclure les données de police dans le SVG, ou `VECTORIZE` pour rendre uniquement le texte qui utilise des polices externes sous forme de graphiques. Vérifiez la licence des polices avant de les intégrer.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    linked_fonts_options = slides.export.SVGOptions()
    linked_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.ADD_LINKS_TO_FONT_FILES

    with open("slide-with-font-links.svg", "wb") as linked_fonts_stream:
        presentation.slides[0].write_as_svg(linked_fonts_stream, linked_fonts_options)

    embedded_fonts_options = slides.export.SVGOptions()
    embedded_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.EMBED

    with open("slide-with-embedded-fonts.svg", "wb") as embedded_fonts_stream:
        presentation.slides[0].write_as_svg(embedded_fonts_stream, embedded_fonts_options)

    vectorized_external_fonts_options = slides.export.SVGOptions()
    vectorized_external_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.VECTORIZE

    with open("slide-with-vectorized-external-fonts.svg", "wb") as vectorized_external_fonts_stream:
        presentation.slides[0].write_as_svg(vectorized_external_fonts_stream, vectorized_external_fonts_options)
```

## **Réduire la taille des images intégrées**

Utilisez [SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) pour réduire la résolution des images intégrées, [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) pour omettre les zones source recadrées, et [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) pour contrôler la qualité d'encodage JPEG. Ces paramètres réduisent la taille du fichier au détriment de la fidélité de l'image ou des données d'image conservées.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.pictures_compression = slides.export.PicturesCompression.DPI150
    svg_options.delete_pictures_cropped_areas = True
    svg_options.jpeg_quality = 80

    with open("compressed-slide.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

## **Contrôler la résolution de rasterisation des métafichiers**

[SVGOptions.metafile_rasterization_dpi](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/metafile_rasterization_dpi/) définit la limite inférieure de résolution pour la rasterisation des métafichiers lors de l'exportation SVG. Utilisez-le pour équilibrer le détail et la taille du fichier lorsqu'une image EMF ou WMF est rasterisée. Il ne définit pas un DPI global pour le SVG ni ne force chaque objet de la diapositive à devenir une image raster.

Téléchargez [metafile-rasterization.pptx](metafile-rasterization.pptx), qui contient une image EMF avec des lignes diagonales rapprochées. L'exemple suivant exporte sa première diapositive à trois résolutions de rasterisation via [Slide.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/slide/write_as_svg/). Tous les autres paramètres d'exportation restent identiques afin que les résultats puissent être comparés.

```py
import aspose.slides as slides

with slides.Presentation("metafile-rasterization.pptx") as presentation:
    for dpi in (72, 150, 300):
        svg_options = slides.export.SVGOptions()
        svg_options.metafile_rasterization_dpi = dpi
        svg_options.pictures_compression = slides.export.PicturesCompression.DPI330
        svg_options.jpeg_quality = 90

        with open("slide-{}.svg".format(dpi), "wb") as svg_stream:
            presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

Dans la sortie, le EMF est devenu un PNG intégré dans chaque SVG. Les mesures suivantes concernent la présentation fournie ; elles ne constituent pas une formule générale de conversion DPI en dimensions de pixels.

| Résolution de rasterisation du métafichier (DPI) | Dimensions du PNG intégré | Taille du fichier SVG (octets) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

La comparaison ci‑dessous montre la même zone du raster intégré à la même taille d'affichage agrandie. Les lignes diagonales affichent une pixellisation visible à 72 DPI et des bords plus lisses à des résolutions supérieures, tandis que le fichier SVG augmente. Augmenter la valeur n'améliore pas nécessairement chaque détail ni ne modifie chaque image exportée.

![Détail agrandi des lignes diagonales à 72, 150 et 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) contrôle la réduction de la résolution des images et peut masquer l'effet du changement de résolution de rasterisation du métafichier. [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) contrôle la qualité d'encodage JPEG, pas la résolution de rasterisation du métafichier.

## **FAQ**

**Quand devrais‑je utiliser [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) au lieu de [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/)?**

Utilisez [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) lorsque tout le texte doit être indépendant des polices. Utilisez [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) lorsque seul le texte qui utilise des polices externes doit être converti en graphiques.

**Quelle est la meilleure façon de réduire la taille d'un SVG ?**

Commencez par compresser les images intégrées, supprimer les zones d'image recadrées et choisir des fichiers de polices liés lorsque l'environnement cible peut les fournir. Testez le résultat car une résolution d'image plus basse, une qualité JPEG réduite et le texte vectorisé ont chacun des compromis différents en termes de qualité et de taille.