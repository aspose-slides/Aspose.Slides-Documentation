---
title: Rendre des diapositives de présentation au format SVG en Python
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
- options d'export SVG
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Exportez des diapositives PowerPoint au format SVG en Python et contrôlez les polices, le texte et les images avec Aspose.Slides."
---
## **Vue d'ensemble**

SVG est un format d'image évolutif basé sur XML qui fonctionne bien pour la publication Web, les visionneuses de diapositives, les flux de travail d'accessibilité et le post‑traitement automatisé. Aspose.Slides exporte chaque diapositive vers un fichier SVG distinct et vous permet de contrôler la façon dont le texte, les polices, les images et les éléments SVG sont écrits.

Utilisez [SVGOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/) lorsque le SVG exporté doit être compact, prévisible sur tous les navigateurs, ou prêt pour une utilisation interactive.

## **Exporter une diapositive en SVG**

Créez une [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), sélectionnez une diapositive et écrivez‑la dans un flux. L'exemple suivant exporte chaque diapositive d'une présentation sous forme de fichier SVG séparé.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

Le nom de fichier utilise [Slide.slide_number](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_number/) plutôt que l'index de la boucle. Vous pouvez également exporter une forme individuelle avec [Shape.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/shape/write_as_svg/) lorsqu'un visionneur de diapositives ou une page Web ne nécessite que cette forme.

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

## **Contrôler le texte et les polices**

Lors de l'exportation de diapositives vers SVG, vous pouvez contrôler si le texte reste du texte ou est converti en graphiques vectoriels, ainsi que la façon dont les polices externes sont incluses ou référencées. Les options suivantes vous aident à équilibrer la cohérence visuelle, la sélection du texte et les dépendances de polices dans le SVG exporté.

### **Vectoriser tout le texte**

Réglez [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) sur `True` pour écrire tout le texte de la diapositive sous forme de graphiques vectoriels. Cela élimine les dépendances de polices et rend le résultat visuel plus cohérent sur les navigateurs, mais le texte n'est plus sélectionnable ni recherché en tant que texte SVG.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **Choisir la manière dont les polices externes sont gérées**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) utilise une valeur [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) pour les polices chargées en externe. Choisissez `ADD_LINKS_TO_FONT_FILES` pour référencer des fichiers de polices séparés, `EMBED` pour inclure les données de police dans le SVG, ou `VECTORIZE` pour rendre uniquement le texte utilisant des polices externes sous forme de graphiques. Vérifiez la licence des polices avant de les incorporer.

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

[SVGOptions.metafile_rasterization_dpi](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/metafile_rasterization_dpi/) définit la limite de résolution minimale pour la rasterisation des métafichiers lors de l'exportation SVG. Utilisez‑le pour équilibrer le détail et la taille du fichier lorsqu'une image EMF ou WMF est rasterisée. Il ne définit pas un DPI global pour le SVG ni ne contraint chaque objet de la diapositive à devenir une image raster.

Téléchargez [metafile-rasterization.pptx](metafile-rasterization.pptx), qui contient une image EMF avec des lignes diagonales très rapprochées. L'exemple suivant exporte sa première diapositive à trois résolutions de rasterisation via [Slide.write_as_svg](https://reference.aspose.com/slides/python-net/aspose.slides/slide/write_as_svg/). Tous les autres paramètres d'exportation restent identiques afin que les résultats puissent être comparés.

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

Dans la sortie, l'EMF est devenu un PNG intégré dans chaque SVG. Les mesures suivantes concernent la présentation fournie ; elles ne constituent pas une formule générale de conversion du DPI en dimensions de pixel.

| DPI de rasterisation du métafile | Dimensions du PNG intégré | Taille du fichier SVG (octets) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

La comparaison ci‑dessous montre la même zone du raster intégré à la même taille d'affichage agrandie. Les lignes diagonales présentent une pixellisation visible à 72 DPI et des bords plus lisses à des résolutions supérieures, tandis que le fichier SVG augmente. Augmenter la valeur n'améliore pas forcément chaque détail ni ne modifie chaque image exportée.

![Détail agrandi des lignes diagonales à 72, 150 et 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.pictures_compression](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/pictures_compression/) contrôle la réduction de la résolution d'image et peut masquer l'effet du changement de résolution de rasterisation du métafile. [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/jpeg_quality/) contrôle la qualité d'encodage JPEG, pas la résolution de rasterisation du métafile.

## **FAQ**

**Quand devrais‑je utiliser [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) au lieu de [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/)?**

Utilisez [SVGOptions.vectorize_text](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgoptions/vectorize_text/) lorsque tout le texte doit être indépendant des polices. Utilisez [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/python-net/aspose.slides.export/svgexternalfontshandling/) lorsque seul le texte utilisant des polices externes doit être converti en graphiques.

**Quelle est la meilleure façon de réduire la taille d'un SVG?**

Commencez par compresser les images intégrées, supprimer les zones d'image recadrées, et choisir des fichiers de polices liés lorsque l'environnement cible peut les fournir. Testez le résultat car une résolution d'image plus basse, une qualité JPEG réduite et le texte vectorisé ont chacun des compromis différents en termes de qualité et de taille.