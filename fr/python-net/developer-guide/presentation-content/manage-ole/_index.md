---
title: Gérer OLE dans les présentations à l’aide de Python
linktitle: Gérer OLE
type: docs
weight: 40
url: /fr/python-net/manage-ole/
keywords:
- objet OLE
- liaison et incorporation d’objets
- ajouter un objet OLE
- intégrer un objet OLE
- ajouter un objet
- intégrer un objet
- ajouter un fichier
- intégrer un fichier
- objet lié
- fichier lié
- modifier un objet OLE
- icône OLE
- titre OLE
- extraire un objet OLE
- extraire un objet
- extraire un fichier
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Optimisez la gestion des objets OLE dans les fichiers PowerPoint et OpenDocument avec Aspose.Slides pour Python via .NET. Intégrez, mettez à jour et exportez le contenu OLE en toute simplicité."
---

{{% alert title="Info" color="info" %}}

OLE (Liaison et Intégration d'Objets) est une technologie de Microsoft qui permet de placer des données et des objets créés dans une application dans une autre application par le biais de liaison ou d'intégration. 

{{% /alert %}} 

Considérez un graphique créé dans MS Excel. Le graphique est ensuite placé à l'intérieur d'une diapositive PowerPoint. Ce graphique Excel est considéré comme un objet OLE. 

- Un objet OLE peut apparaître sous forme d'icône. Dans ce cas, lorsque vous double-cliquez sur l'icône, le graphique s'ouvre dans son application associée (Excel), ou on vous demande de sélectionner une application pour ouvrir ou modifier l'objet. 
- Un objet OLE peut afficher des contenus réels—par exemple, le contenu d'un graphique. Dans ce cas, le graphique est activé dans PowerPoint, l'interface graphique se charge et vous pouvez modifier les données du graphique dans l'application PowerPoint.

[Aspose.Slides pour Python via .NET](https://products.aspose.com/slides/python-net) vous permet d'insérer des objets OLE dans des diapositives sous forme de cadres d'objets OLE ([OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)).

## **Ajouter des Cadres d'Objets OLE aux Diapositives**
En supposant que vous ayez déjà créé un graphique dans Microsoft Excel et que vous souhaitiez intégrer ce graphique dans une diapositive en tant que cadre d'objet OLE en utilisant Aspose.Slides pour Python via .NET, vous pouvez le faire de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez la référence d'une diapositive via son index.
1. Ouvrez le fichier Excel contenant l'objet graphique Excel et enregistrez-le dans un `MemoryStream`.
1. Ajoutez le cadre d'objet OLE à la diapositive contenant le tableau d'octets et d'autres informations sur l'objet OLE.
1. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Dans l'exemple ci-dessous, nous avons ajouté un graphique à partir d'un fichier Excel à une diapositive en tant que [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) en utilisant Aspose.Slides pour Python via .NET.  
**Remarque** que le constructeur [IOleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides/ioleembeddeddatainfo/) prend une extension d'objet intégrable comme deuxième paramètre. Cette extension permet à PowerPoint d'interpréter correctement le type de fichier et de choisir la bonne application pour ouvrir cet objet OLE.

```py 
import aspose.slides as slides

# Instancie la classe Presentation représentant le PPTX
with slides.Presentation() as pres:
    # Accède à la première diapositive
    sld = pres.slides[0]

    # Charge un fichier Excel dans un flux
    with open(path + "book1.xlsx", "rb") as fs:
        bytes = fs.read()
    
        # Crée un objet de données pour intégration
        dataInfo = slides.dom.ole.OleEmbeddedDataInfo(bytes, "xlsx")

        # Ajoute une forme de cadre d'objet Ole
        oleObjectFrame = sld.shapes.add_ole_object_frame(0, 0, pres.slide_size.size.width, pres.slide_size.size.height, dataInfo)

        # Écrit le fichier PPTX sur le disque
        pres.save("OleEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```
## **Accéder aux Cadres d'Objets OLE**
Si un objet OLE est déjà intégré dans une diapositive, vous pouvez trouver ou accéder facilement à cet objet de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).

1. Obtenez la référence de la diapositive en utilisant son index.

1. Accédez à la forme [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).

   Dans notre exemple, nous avons utilisé le PPTX précédemment créé qui n'a qu'une seule forme sur la première diapositive. Nous avons ensuite *casté* cet objet en tant que [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/). C'était le cadre d'objet OLE souhaité à accéder.

1. Une fois le cadre d'objet OLE accédé, vous pouvez effectuer n'importe quelle opération sur celui-ci.

Dans l'exemple ci-dessous, un cadre d'objet OLE (un objet graphique Excel intégré dans une diapositive) est accédé—et ensuite ses données de fichier sont écrites dans un fichier Excel :

```py 
import aspose.slides as slides

# Charge le PPTX dans un objet présentation
with slides.Presentation(path + "AccessingOLEObjectFrame.pptx") as pres:
    # Accède à la première diapositive
    sld = pres.slides[0]

    # Cast la forme en OleObjectFrame
    oleObjectFrame = sld.shapes[0]

    # Lit l'objet OLE et l'écrit sur le disque
    if type(oleObjectFrame) is slides.OleObjectFrame:
        # Obtient les données de fichier intégrées
        data = oleObjectFrame.embedded_data.embedded_file_data

        # Obtient l'extension de fichier intégrée
        fileExtention = oleObjectFrame.embedded_data.embedded_file_extension

        # Crée un chemin pour enregistrer le fichier extrait
        extractedPath = "excelFromOLE_out" + fileExtention

        # Enregistre les données extraites
        with open("out.xlsx", "wb") as fs:
            fs.write(data)
```

## **Changer les Données de l'Objet OLE**

Si un objet OLE est déjà intégré dans une diapositive, vous pouvez facilement accéder à cet objet avec Aspose.Slides pour Python via .NET et modifier ses données de cette manière :

1. Ouvrez la présentation souhaitée avec l'objet OLE intégré en créant une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).

1. Obtenez la référence de la diapositive via son index.

1. Accédez à la forme [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).

   Dans notre exemple, nous avons utilisé le PPTX précédemment créé, qui n'a qu'une seule forme sur la première diapositive. Nous avons ensuite *casté* cet objet en tant que [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/). C'était le cadre d'objet OLE souhaité à accéder.

1. Une fois le cadre d'objet OLE accédé, vous pouvez effectuer n'importe quelle opération sur celui-ci.

1. Créez l'objet Workbook et accédez aux données OLE.

1. Accédez à la feuille de calcul souhaitée et modifiez les données.

1. Enregistrez le Workbook mis à jour dans des flux.

1. Changez les données de l'objet OLE à partir des données de flux.

Dans l'exemple ci-dessous, un cadre d'objet OLE (un objet graphique Excel intégré dans une diapositive) est accédé—et ensuite ses données de fichier sont modifiées pour changer les données du graphique.

```py 
# [TODO:require Aspose.Cells pour Python via .NET]
```

## Intégrer D'autres Types de Fichiers dans les Diapositives

En plus des graphiques Excel, Aspose.Slides pour Python via .NET vous permet d'intégrer d'autres types de fichiers dans les diapositives. Par exemple, vous pouvez insérer des fichiers HTML, PDF et ZIP en tant qu'objets dans une diapositive. Lorsque l'utilisateur double-clique sur l'objet inséré, l'objet s'ouvre automatiquement dans le programme pertinent, ou l'utilisateur est dirigé pour sélectionner un programme approprié pour ouvrir l'objet. 

Ce code Python vous montre comment intégrer HTML et ZIP dans une diapositive :

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    with open(path + "index.html", "rb") as fs1:
        htmlBytes = fs1.read()
        dataInfoHtml = slides.dom.ole.OleEmbeddedDataInfo(htmlBytes, "html")
        oleFrameHtml = slide.shapes.add_ole_object_frame(150, 120, 50, 50, dataInfoHtml)
        oleFrameHtml.is_object_icon = True

    with open(path + "archive.zip", "rb") as fs2:
        zipBytes = fs2.read()
        dataInfoZip = slides.dom.ole.OleEmbeddedDataInfo(zipBytes, "zip")
        oleFrameZip = slide.shapes.add_ole_object_frame(150, 220, 50, 50, dataInfoZip)
        oleFrameZip.is_object_icon = True

    pres.save("embeddedOle.pptx", slides.export.SaveFormat.PPTX)
```

## Définir les Types de Fichiers pour les Objets Intégrés

Lors de l'élaboration de présentations, vous pouvez avoir besoin de remplacer d'anciens objets OLE par de nouveaux. Ou vous pouvez avoir besoin de remplacer un objet OLE non pris en charge par un objet pris en charge. 

Aspose.Slides pour Python via .NET vous permet de définir le type de fichier pour un objet intégré. De cette façon, vous pouvez changer les données de cadre OLE ou son extension. 

Ce code Python vous montre comment définir le type de fichier pour un objet OLE intégré :

```py
import aspose.slides as slides

with slides.Presentation("embeddedOle.pptx") as pres:
    slide = pres.slides[0]
    oleObjectFrame = slide.shapes[0]
    print("L'extension de données intégrées actuelle est : " + oleObjectFrame.embedded_data.embedded_file_extension)
   
    with open(path + "1.zip", "rb") as fs2:
        zipBytes = fs2.read()

    oleObjectFrame.set_embedded_data(slides.dom.ole.OleEmbeddedDataInfo(zipBytes, "zip"))
   
    pres.save("embeddedChanged.pptx", slides.export.SaveFormat.PPTX)
```

## Définir des Images et Titres d'Icônes pour les Objets Intégrés

Après avoir intégré un objet OLE, un aperçu composé d'une image d'icône et d'un titre est ajouté automatiquement. L'aperçu est ce que les utilisateurs voient avant d'accéder ou d'ouvrir l'objet OLE. 

Si vous souhaitez utiliser une image et un texte spécifiques comme éléments de l'aperçu, vous pouvez définir l'image d'icône et le titre en utilisant Aspose.Slides pour Python via .NET. 

Ce code Python vous montre comment définir l'image d'icône et le titre pour un objet intégré :

```py
import aspose.slides as slides

with slides.Presentation("embeddedOle.pptx") as pres:
    slide = pres.slides[0]
    oleObjectFrame = slide.shapes[0]
    
    with open("img.jpeg", "rb") as in_file:
        oleImage = pres.images.add_image(in_file)

    oleObjectFrame.substitute_picture_title = "Mon titre"
    oleObjectFrame.substitute_picture_format.picture.image = oleImage
    oleObjectFrame.is_object_icon = False

    pres.save("embeddedOle-newImage.pptx", slides.export.SaveFormat.PPTX)
```

## **Empêcher un Cadre d'Objet OLE d'Être Redimensionné et Repositionné**

Après avoir ajouté un objet OLE lié à une diapositive de présentation, lorsque vous ouvrez la présentation dans PowerPoint, vous pouvez voir un message vous demandant de mettre à jour les liens. En cliquant sur le bouton "Mettre à jour les liens", cela peut modifier la taille et la position du cadre de l'objet OLE car PowerPoint met à jour les données de l'objet OLE lié et rafraîchit l'aperçu de l'objet. Pour empêcher PowerPoint de demander la mise à jour des données de l'objet, définissez la propriété `update_automatic` de la classe [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) sur `False` :

```py
oleObjectFrame.update_automatic = False
```

## Extraction des Fichiers Intégrés

Aspose.Slides pour Python via .NET vous permet d'extraire les fichiers intégrés dans les diapositives sous forme d'objets OLE de cette manière :

1. Créez une instance de la [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) contenant l'objet OLE que vous comptez extraire.
2. Bouclez à travers toutes les formes dans la présentation et accédez à la forme [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).
3. Accédez aux données du fichier intégré à partir du cadre d'objet OLE et écrivez-le sur le disque. 

Ce code Python vous montre comment extraire un fichier intégré dans une diapositive sous forme d'objet OLE :

```py
import aspose.slides as slides

with slides.Presentation("embeddedOle.pptx") as pres:
    slide = pres.slides[0]
    index = 0
    for shape in slide.shapes:

        if type(shape) is slides.OleObjectFrame:
            data = shape.embedded_data.embedded_file_data
            extension = shape.embedded_data.embedded_file_extension
            
            with open("oleFrame{idx}{ex}".format(idx = str(index), ex = extension), "wb") as fs:
                fs.write(data)
        index += 1
```