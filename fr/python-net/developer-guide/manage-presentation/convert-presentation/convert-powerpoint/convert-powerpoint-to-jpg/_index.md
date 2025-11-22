---
title: Convertir PPT, PPTX et ODP en JPG avec Python
linktitle: Convertir les diapositives en images JPG
type: docs
weight: 60
url: /fr/python-net/convert-powerpoint-to-jpg/
keywords:
- convertir PowerPoint en JPG
- convertir présentation en JPG
- convertir diapositive en JPG
- convertir PPT en JPG
- convertir PPTX en JPG
- convertir ODP en JPG
- PowerPoint en JPG
- présentation en JPG
- diapositive en JPG
- PPT en JPG
- PPTX en JPG
- ODP en JPG
- convertir PowerPoint en JPEG
- convertir présentation en JPEG
- convertir diapositive en JPEG
- convertir PPT en JPEG
- convertir PPTX en JPEG
- convertir ODP en JPEG
- PowerPoint en JPEG
- présentation en JPEG
- diapositive en JPEG
- PPT en JPEG
- PPTX en JPEG
- ODP en JPEG
- Python
- Aspose.Slides
description: "Apprenez à transformer vos diapositives provenant de présentations PowerPoint et OpenDocument en images JPEG de haute qualité avec seulement quelques lignes de code en Python. Optimisez les présentations pour une utilisation web, le partage et l'archivage. Lisez le guide complet dès maintenant !"
---

## **Vue d'ensemble**

La conversion de présentations PowerPoint et OpenDocument en images JPG facilite le partage des diapositives, l'optimisation des performances et l'intégration du contenu dans des sites Web ou des applications. Aspose.Slides for Python vous permet de transformer des fichiers PPTX, PPT et ODP en images JPEG de haute qualité. Ce guide explique les différentes méthodes de conversion.

Avec ces fonctionnalités, il est facile de mettre en œuvre votre propre visualiseur de présentations et de créer une vignette pour chaque diapositive. Cela peut être utile si vous souhaitez protéger les diapositives contre la copie ou présenter la présentation en mode lecture seule. Aspose.Slides vous permet de convertir l'intégralité de la présentation ou une diapositive spécifique en formats d'image.

## **Convertir les diapositives de présentation en images JPG**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
2. Récupérez l’objet diapositive de type [Slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/) depuis la collection [Presentation.slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) .
3. Créez une image de la diapositive en utilisant la méthode [Slide.get_image(scale_x,scale_y)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#float-float) .
4. Appelez la méthode [IImage.save(filename,format)](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/#str-imageformat) sur l’objet image. Passez le nom du fichier de sortie et le format d’image en tant qu’arguments.

{{% alert color="primary" %}}

**Remarque :** La conversion de PPT, PPTX ou ODP en JPG diffère de la conversion vers d’autres formats dans l’API Aspose.Slides pour Python. Pour d’autres formats, vous utilisez généralement la méthode [Presentation.save(fname,format,options)](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/#str-asposeslidesexportsaveformat-asposeslidesexportisaveoptions). Cependant, pour la conversion en JPG, vous devez utiliser la méthode [IImage.save(filename,format)](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/#str-imageformat) .

{{% /alert %}}
```py
import aspose.slides as slides

scale_x = 1
scale_y = scale_x

with slides.Presentation("PowerPoint_Presentation.ppt") as presentation:
    for slide in presentation.slides:
        with slide.get_image(scale_x, scale_y) as thumbnail:
            # Enregistrez l'image sur le disque au format JPEG.
            file_name = f"Slide_{slide.slide_number}.jpg"
            thumbnail.save(file_name, slides.ImageFormat.JPEG)
```


## **Convertir les diapositives en JPG avec des dimensions personnalisées**

Pour modifier les dimensions des images JPG résultantes, vous pouvez définir la taille de l’image en la passant à la méthode [Slide.get_image(image_size)](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/#asposepydrawingsize). Cela vous permet de générer des images avec des valeurs de largeur et de hauteur spécifiques, garantissant que la sortie répond à vos exigences en matière de résolution et de ratio d’aspect. Cette flexibilité est particulièrement utile lors de la génération d’images pour des applications Web, des rapports ou de la documentation, où des dimensions d’image précises sont requises.
```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

image_size = pydrawing.Size(1200, 800)

with slides.Presentation("PowerPoint_Presentation.pptx") as presentation:
    for slide in presentation.slides:
        # Créez une image de diapositive de la taille spécifiée.
        with slide.get_image(image_size) as thumbnail:
            # Enregistrez l'image sur le disque au format JPEG.
            file_name = f"Slide_{slide.slide_number}.jpg"
            thumbnail.save(file_name, slides.ImageFormat.JPEG)
```


## **Rendre les commentaires lors de l’enregistrement des diapositives en images**

Aspose.Slides pour Python offre une fonction qui vous permet de rendre les commentaires sur les diapositives d’une présentation lors de leur conversion en images JPG. Cette fonctionnalité est particulièrement utile pour préserver les annotations, les retours ou les discussions ajoutés par des collaborateurs dans les présentations PowerPoint. En activant cette option, vous vous assurez que les commentaires sont visibles dans les images générées, facilitant ainsi la révision et le partage des retours sans avoir à ouvrir le fichier de présentation original.

Supposons que nous ayons un fichier de présentation, "sample.pptx", contenant une diapositive avec des commentaires :

![Diapositive avec commentaires](slide_with_comments.png)

Le code Python suivant convertit la diapositive en une image JPG tout en préservant les commentaires :
```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

scale_x = 1
scale_y = scale_x

with slides.Presentation("sample.pptx") as presentation:
    # Définir les options pour les commentaires de diapositive.
    comments_options = slides.export.NotesCommentsLayoutingOptions()
    comments_options.comments_position = slides.export.CommentsPositions.RIGHT
    comments_options.comments_area_width = 200
    comments_options.comments_area_color = pydrawing.Color.dark_orange

    options = slides.export.RenderingOptions()
    options.slides_layout_options = comments_options

    # Convertir la première diapositive en image.
    with presentation.slides[0].get_image(options, scale_x, scale_y) as thumbnail:
        thumbnail.save("Slide_1.jpg", slides.ImageFormat.JPEG)
```


Le résultat :

![Image JPG avec commentaires](image_with_comments.png)

## **Voir aussi**

- [Convertir PowerPoint en GIF](/slides/fr/python-net/convert-powerpoint-to-animated-gif/)
- [Convertir PowerPoint en PNG](/slides/fr/python-net/convert-powerpoint-to-png/)
- [Convertir PowerPoint en TIFF](/slides/fr/python-net/convert-powerpoint-to-tiff/)
- [Convertir PowerPoint en SVG](/slides/fr/python-net/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 

Pour voir comment Aspose.Slides convertit PowerPoint en images JPG, essayez ces convertisseurs en ligne gratuits : PowerPoint [PPTX en JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) et [PPT en JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg) . 

{{% /alert %}} 

![Convertisseur PPTX en JPG en ligne gratuit](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose propose une application web [GRATUITE de collage](https://products.aspose.app/slides/collage). En utilisant ce service en ligne, vous pouvez fusionner des images [JPG en JPG](https://products.aspose.app/slides/collage/jpg) ou PNG en PNG, créer des [grilles de photos](https://products.aspose.app/slides/collage/photo-grid), etc. 

En appliquant les mêmes principes décrits dans cet article, vous pouvez convertir des images d’un format à un autre. Pour plus d’informations, consultez ces pages : convertir [image en JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/) ; convertir [JPG en image](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/) ; convertir [JPG en PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/), convertir [PNG en JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/) ; convertir [PNG en SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/), convertir [SVG en PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/) .

{{% /alert %}}

## **FAQ**

**Cette méthode prend‑elle en charge la conversion par lots ?**

Oui, Aspose.Slides permet la conversion par lots de plusieurs diapositives en JPG en une seule opération.

**La conversion prend‑elle en charge SmartArt, les graphiques et d’autres objets complexes ?**

Oui, Aspose.Slides rend tout le contenu, y compris SmartArt, les graphiques, les tableaux, les formes, etc. Cependant, la précision du rendu peut varier légèrement par rapport à PowerPoint, notamment lorsqu’on utilise des polices personnalisées ou manquantes.

**Existe‑t‑il des limites au nombre de diapositives pouvant être traitées ?**

Aspose.Slides n’impose aucune limite stricte au nombre de diapositives que vous pouvez traiter. Cependant, vous pouvez rencontrer une erreur de mémoire insuffisante lorsqu’il s’agit de présentations volumineuses ou d’images haute résolution.