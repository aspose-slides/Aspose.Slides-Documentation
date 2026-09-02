---
title: Rendu des diapositives de présentation en images SVG en Python
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

SVG est un format d'image évolutif basé sur XML qui convient bien à la publication Web, aux visionneuses de diapositives, aux flux de travail d'accessibilité et au post‑traitement automatisé. Aspose.Slides exporte chaque diapositive vers un fichier SVG distinct et vous permet de contrôler la façon dont le texte, les polices, les images et les éléments SVG sont écrits.

Utilisez [SVGOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/svgoptions/) lorsque le SVG exporté doit être compact, prévisible sur tous les navigateurs ou prêt à être utilisé de manière interactive.

## **Exporter une diapositive au format SVG**

Créez une [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/), sélectionnez une diapositive et écrivez‑la dans un flux. L'exemple suivant exporte chaque diapositive d'une présentation en tant que fichier SVG séparé.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

Le nom de fichier utilise [Slide.slide_number](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slide/slide_number/) plutôt que l'index de boucle. Vous pouvez également exporter une forme individuelle avec [Shape.write_as_svg](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shape/write_as_svg/) lorsqu'un visualiseur de diapositive ou une page Web ne nécessite que cette forme.

## **Configurer la sortie SVG**

[SVGOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/svgoptions/) contrôle le rendu SVG. Pour les cadres de texte, [SVGOptions.use_frame_size](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/svgoptions/use_frame_size/) inclut le cadre de texte dans la zone de rendu, et [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) détermine si la rotation du cadre est appliquée. Réglez [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) sur `True` lorsque le texte doit être rendu sans ligatures.

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

### **Vectoriser tout le texte**

Définissez [SVGOptions.vectorize_text](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/svgoptions/vectorize_text/) sur `True` pour écrire tout le texte de la diapositive sous forme de graphiques vectoriels. Cela élimine les dépendances aux polices et rend le résultat visuel plus homogène entre les navigateurs, mais le texte n’est plus sélectionnable ni recherchable en tant que texte SVG.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **Choisir la manière dont les polices externes sont gérées**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) utilise une valeur [SvgExternalFontsHandling](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/svgexternalfontshandling/) pour les polices chargées de façon externe. Choisissez `ADD_LINKS_TO_FONT_FILES` pour référencer des fichiers de police séparés, `EMBED` pour inclure les données de la police dans le SVG, ou `VECTORIZE` pour rendre uniquement le texte qui utilise des polices externes sous forme de graphiques. Vérifiez les licences des polices avant d’incorporer des polices.

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

Utilisez [SVGOptions.pictures_compression](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/svgoptions/pictures_compression/) pour réduire la résolution des images intégrées, [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) pour omettre les zones source recadrées, et [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/svgoptions/jpeg_quality/) pour contrôler la qualité d’encodage JPEG. Ces paramètres réduisent la taille du fichier au détriment de la fidélité de l’image ou des données d'image conservées.

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

## **FAQ**

**Quand dois‑je utiliser [SVGOptions.vectorize_text](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/svgoptions/vectorize_text/) plutôt que [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/svgexternalfontshandling/)?**

Utilisez [SVGOptions.vectorize_text](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/svgoptions/vectorize_text/) lorsque tout le texte doit être indépendant des polices. Utilisez [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/svgexternalfontshandling/) lorsque seul le texte qui utilise des polices externes doit être converti en graphiques.

**Quelle est la meilleure façon de réduire la taille d’un SVG?**

Commencez par compresser les images intégrées, supprimer les zones d’image recadrées et choisir des fichiers de police liés lorsque l’environnement cible peut les fournir. Testez le résultat, car une résolution d’image inférieure, une qualité JPEG plus basse et le texte vectorisé entraînent chacun des compromis différents entre qualité et taille.