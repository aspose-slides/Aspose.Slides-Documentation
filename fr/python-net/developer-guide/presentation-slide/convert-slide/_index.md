---
title: Convertir les diapositives de présentation en images en Python
linktitle: Diapositive en image
type: docs
weight: 41
url: /fr/python-net/convert-slide/
keywords:
- convertir diapositive
- exporter diapositive
- diapositive en image
- enregistrer diapositive comme image
- diapositive en EMF
- diapositive en PNG
- diapositive en JPEG
- diapositive en bitmap
- diapositive en TIFF
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Convertir des diapositives des présentations PPT, PPTX et ODP en PNG, JPEG, GIF, TIFF, EMF et d’autres formats d’image en Python avec Aspose.Slides."
---
## **Introduction**

Aspose.Slides for Python via .NET peut rendre des diapositives individuelles à partir de présentations PowerPoint et OpenDocument au format PNG, JPEG, GIF, TIFF et d'autres formats d'image.

Pour convertir une diapositive en image, suivez ces étapes :

1. Chargez la présentation avec la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/).
2. Sélectionnez la diapositive que vous souhaitez rendre.
3. Si nécessaire, configurez le rendu avec la classe [RenderingOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/renderingoptions/) ou [TiffOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/tiffoptions/).
4. Appelez la méthode [Slide.get_image](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slide/get_image/). Elle renvoie un objet [IImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/iimage/).
5. Appelez la méthode [IImage.save](https://reference.aspose.com/slides/fr/python-net/aspose.slides/iimage/save/) et spécifiez le format de sortie à l'aide d'une valeur [ImageFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides/imageformat/).

## **Convertir une diapositive en image PNG**

La conversion la plus simple utilise les paramètres de rendu par défaut. L'objet [IImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/iimage/) résultant peut être traité en mémoire ou enregistrés dans un fichier.

L'exemple Python suivant rend la première diapositive et l'enregistre au format PNG :

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("Slide_0.png", slides.ImageFormat.PNG)
```

## **Convertir des diapositives en images avec des tailles personnalisées**

Utilisez la surcharge de [Slide.get_image](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slide/get_image/#asposepydrawingsize) qui accepte une valeur [Size](https://reference.aspose.com/slides/fr/python-net/aspose.pydrawing/size/) pour rendre une diapositive avec des dimensions exactes en pixels.

L'exemple suivant crée une image JPEG de 1820 × 1040 :

```py
import aspose.pydrawing as draw
import aspose.slides as slides

image_size = draw.Size(1820, 1040)

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(image_size) as image:
        image.save("Slide_0.jpg", slides.ImageFormat.JPEG)
```

## **Convertir des diapositives avec notes et commentaires en images**

Par défaut, les images des diapositives n’incluent pas les notes ni les commentaires. Assignez un objet [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/notescommentslayoutingoptions/) à la propriété [RenderingOptions.slides_layout_options](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/renderingoptions/slides_layout_options/) pour contrôler où les notes et les commentaires apparaissent.

L'exemple suivant place les notes tronquées sous la diapositive et les commentaires à droite :

```py
import aspose.pydrawing as draw
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED
layout_options.comments_position = slides.export.CommentsPositions.RIGHT
layout_options.comments_area_width = 500
layout_options.comments_area_color = draw.Color.antique_white

rendering_options = slides.export.RenderingOptions()
rendering_options.slides_layout_options = layout_options

with slides.Presentation("Presentation_with_notes_and_comments.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(rendering_options, scale_x, scale_y) as image:
        image.save("Image_with_notes_and_comments_0.gif", slides.ImageFormat.GIF)
```

{{% alert title="Warning" color="warning" %}}
Pour la conversion de diapositive en image, ne définissez pas la propriété [NotesCommentsLayoutingOptions.notes_position](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/notescommentslayoutingoptions/notes_position/) sur [NotesPositions.BOTTOM_FULL](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/notespositions/). Les notes peuvent contenir plus de texte que la taille d'image fixe ne peut accueillir. Utilisez plutôt [NotesPositions.BOTTOM_TRUNCATED](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/notespositions/).
{{% /alert %}}

## **Convertir des diapositives en images en utilisant les options TIFF**

La classe [TiffOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/tiffoptions/) vous permet de contrôler la taille, la résolution et d'autres propriétés de l'image TIFF rendue.

L'exemple suivant rend la première diapositive en une image TIFF de 2160 × 2880 à 300 DPI :

```py
import aspose.pydrawing as draw
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.image_size = draw.Size(2160, 2880)
tiff_options.dpi_x = 300
tiff_options.dpi_y = 300

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image(tiff_options) as image:
        image.save("output.tiff", slides.ImageFormat.TIFF)
```

## **Convertir toutes les diapositives en images**

Parcourez la collection de diapositives pour convertir l'intégralité de la présentation en une série d'images. Les diapositives masquées sont incluses sauf si vous les ignorez explicitement.

L'exemple suivant rend chaque diapositive en image JPEG avec des facteurs d'échelle horizontaux et verticaux de 2 :

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("Presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save("Slide_{}.jpg".format(index), slides.ImageFormat.JPEG)
```

## **Créer une sortie Enhanced Metafile**

Le format Enhanced Metafile (EMF) est utile lorsque des graphiques vectoriels doivent être échangés avec Microsoft Office ou d’autres applications Windows qui prennent en charge les métafichiers Windows. Contrairement à une image basée sur les pixels, un EMF peut conserver les opérations de dessin vectoriel qui restent nettes lorsqu’elles sont redimensionnées. Cependant, l’EMF est principalement un format de compatibilité pour les applications supportant les métafichiers Windows, et non un format d’échange universel. De plus, le contenu complexe d’une diapositive, tel que les images bitmap et certains effets, peut être stocké sous forme d’éléments rasterisés à l’intérieur du conteneur de métafichier vectoriel.

### **Exporter une diapositive en EMF**

La méthode [Slide.write_as_emf](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slide/write_as_emf/) écrit une [Slide](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slide/) dans un flux cible au format EMF. L'exemple suivant charge une présentation, sélectionne la première diapositive et l'écrit dans un flux de fichier EMF :

```py
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    slide = presentation.slides[0]

    with open("Slide_0.emf", "wb") as emf_stream:
        slide.write_as_emf(emf_stream)
```

L’appelant possède le flux passé à [Slide.write_as_emf](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slide/write_as_emf/) et doit le fermer. Aspose.Slides écrit à la position actuelle du flux et le laisse ouvert.

### **Convertir une image SVG en EMF et l’ajouter à une présentation**

Utilisez [SvgImage.write_as_emf](https://reference.aspose.com/slides/fr/python-net/aspose.slides/svgimage/write_as_emf/) pour convertir le contenu SVG en EMF. Les octets résultants peuvent être ajoutés à la présentation via [ImageCollection.add_image](https://reference.aspose.com/slides/fr/python-net/aspose.slides/imagecollection/add_image/) et placés sur une diapositive avec [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shapecollection/add_picture_frame/).

L'exemple suivant crée un [SvgImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/svgimage/) à partir du balisage SVG, le convertit en EMF en mémoire, insère le métafichier sur la première diapositive et enregistre la présentation :

```py
import io
import aspose.slides as slides

svg_content = '<svg xmlns="http://www.w3.org/2000/svg" width="200" height="100"><rect width="200" height="100" fill="#4472C4"/></svg>'
svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with io.BytesIO() as emf_stream:
        svg_image.write_as_emf(emf_stream)
        emf_data = emf_stream.getvalue()

    image = presentation.images.add_image(emf_data)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 100, image)

    presentation.save("Presentation_with_emf.pptx", slides.export.SaveFormat.PPTX)
```

[SvgImage.write_as_emf](https://reference.aspose.com/slides/fr/python-net/aspose.slides/svgimage/write_as_emf/) ne prend pas la possession du flux de destination. Après l’écriture, la position du flux se trouve à la fin des données générées. Appelez `getvalue` pour obtenir le tampon complet, quelle que soit la position actuelle du flux, comme montré ci‑dessus. Conservez le flux ouvert jusqu’à ce que les données aient été lues, puis fermez‑le.

La génération d’EMF est disponible sur les systèmes d’exploitation pris en charge par Aspose.Slides for Python via .NET, mais le rendu peut différer selon les plateformes lorsque les polices ou les dépendances graphiques natives ne sont pas disponibles. Installez les polices utilisées par le contenu source ou configurez des substitutions appropriées, suivez les [exigences de plateforme](/slides/fr/python-net/system-requirements/) pour Aspose.Slides, et validez le résultat dans l’application consommatrice d’EMF cible. Les applications Linux et macOS offrent souvent un support limité ou incohérent pour l’affichage et la modification des métafichiers Windows.

## **Rendu des Emoji en couleur**

{{% alert title="Note" color="info" %}}
Pour rendre correctement les emojis en couleur lors de la conversion de diapositives de présentation en images, les polices d’emoji utilisées dans la présentation doivent être installées et disponibles sur le système effectuant la conversion. Par exemple, si la présentation utilise **Segoe UI Emoji** et que cette police est absente, les emojis peuvent apparaître en monochrome dans les images de sortie.
{{% /alert %}}

## **FAQ**

**Aspose.Slides prend‑t‑il en charge le rendu des diapositives avec animations ?**

Non. La méthode [Slide.get_image](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slide/get_image/) génère une image statique de la diapositive et n’exporte pas les animations.

**Les diapositives masquées peuvent‑elles être exportées en images ?**

Oui. Les diapositives masquées peuvent être rendues comme les diapositives classiques. Incluez‑les dans la boucle de traitement, comme montré dans l’exemple ci‑dessus.

**Les ombres et autres effets sont‑ils préservés dans les images de diapositives ?**

Oui. Aspose.Slides rend les ombres, la transparence et d’autres effets graphiques pris en charge dans les images de diapositives.