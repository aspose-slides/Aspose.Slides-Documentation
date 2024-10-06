---
title: Convertir PowerPoint PPT en JPG en Python
linktitle: Convertir PowerPoint PPT en JPG
type: docs
weight: 60
url: /python-net/convert-powerpoint-to-jpg/
keywords: "python ppt en image, Convertir présentation PowerPoint, JPG, JPEG, PowerPoint en JPG, PowerPoint en JPEG, PPT en JPG, PPTX en JPG, PPT en JPEG, PPTX en JPEG, Python, Aspose.Slides"
description: "Convertir PowerPoint en JPG en Python. Enregistrer la diapositive comme image JPG"
---

## **À propos de la conversion PowerPoint en JPG**
Avec [**Aspose.Slides .NET API**](https://products.aspose.com/slides/python-net/) vous pouvez convertir une présentation PowerPoint PPT ou PPTX en image JPG en Python. Il est également possible de convertir PPT/PPTX en BMP, PNG ou SVG en Python. Avec ces fonctionnalités, il est facile de mettre en œuvre votre propre visualiseur de présentation, de créer le miniatures pour chaque diapositive. Cela peut être utile si vous souhaitez protéger les diapositives de présentation contre le droit d'auteur, démontrer la présentation en mode lecture seule. Aspose.Slides permet de convertir l'ensemble de la présentation ou une certaine diapositive en formats d'image.

{{% alert color="primary" %}} 

Pour voir comment Aspose.Slides convertit PowerPoint en images JPG, vous pouvez essayer ces convertisseurs en ligne gratuits : PowerPoint [PPTX en JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) et [PPT en JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 

{{% /alert %}} 

![todo:image_alt_text](ppt-to-jpg.png)

## **Convertir PowerPoint PPT/PPTX en JPG**
Voici les étapes pour convertir PPT/PPTX en JPG :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez l'objet diapositive de type [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) à partir de la collection [Presentation.Slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
3. Créez le miniatures de chaque diapositive, puis convertissez-le en JPG. La méthode [**ISlide.GetImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) est utilisée pour obtenir une miniature d'une diapositive, elle renvoie un objet [IImage](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) en résultat. La méthode [GetImage](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) doit être appelée depuis la diapositive souhaitée de type [ISlide](https://reference.aspose.com/slides/python-net/aspose.slides/islide/), les échelles de la miniature résultante sont transmises à la méthode.
4. Une fois que vous avez obtenu la miniature de la diapositive, appelez la méthode [**IImage.Save(string filename, ImageFormat format)**](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/) depuis l'objet miniature. Passez le nom de fichier résultant et le format de l'image dans celui-ci. 

{{% alert color="primary" %}} 
**Remarque** : La conversion PPT/PPTX en JPG diffère de la conversion en d'autres types dans Aspose.Slides .NET API. Pour d'autres types, vous utilisez généralement la méthode [**IPresentation.SaveMethod(String, SaveFormat, ISaveOptions)**](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/), mais ici vous avez besoin de la méthode [**Image.Save(string filename, ImageFormat format)**](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.image.save?view=netframework-4.8).
{{% /alert %}} 

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

for sld in pres.slides:
    with sld.get_image(1, 1) as bmp:
        bmp.save("Diapositive_{num}.jpg".format(num=str(sld.slide_number)), slides.ImageFormat.JPEG)
```

## **Convertir PowerPoint PPT/PPTX en JPG avec des dimensions personnalisées**
Pour modifier la dimension de la miniature et de l'image JPG résultantes, vous pouvez définir les valeurs *ScaleX* et *ScaleY* en les passant à la méthode [**ISlide.GetImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/python-net/aspose.slides/islide/) :

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

desiredX = 1200
desiredY = 800
scaleX = (float)(1.0 / pres.slide_size.size.width) * desiredX
scaleY = (float)(1.0 / pres.slide_size.size.height) * desiredY

for sld in pres.slides:
    with sld.get_image(scaleX, scaleY) as bmp:
        bmp.save("Diapositive_{num}.jpg".format(num=str(sld.slide_number)), slides.ImageFormat.JPEG)
```

{{% alert title="Astuce" color="primary" %}}

Aspose propose une [application web Collage GRATUITE](https://products.aspose.app/slides/collage). En utilisant ce service en ligne, vous pouvez fusionner des images [JPG en JPG](https://products.aspose.app/slides/collage/jpg) ou des images PNG en PNG, créer [des grilles photo](https://products.aspose.app/slides/collage/photo-grid), etc. 

En utilisant les mêmes principes décrits dans cet article, vous pouvez convertir des images d'un format à un autre. Pour plus d'informations, consultez ces pages : convertir [image en JPG](https://products.aspose.com/slides/python-net/conversion/image-to-jpg/) ; convertir [JPG en image](https://products.aspose.com/slides/python-net/conversion/jpg-to-image/) ; convertir [JPG en PNG](https://products.aspose.com/slides/python-net/conversion/jpg-to-png/), convertir [PNG en JPG](https://products.aspose.com/slides/python-net/conversion/png-to-jpg/) ; convertir [PNG en SVG](https://products.aspose.com/slides/python-net/conversion/png-to-svg/), convertir [SVG en PNG](https://products.aspose.com/slides/python-net/conversion/svg-to-png/).

{{% /alert %}}

## **Voir aussi**

Voir d'autres options pour convertir PPT/PPTX en image comme :

- [Conversion PPT/PPTX en SVG](/slides/python-net/render-a-slide-as-an-svg-image/).