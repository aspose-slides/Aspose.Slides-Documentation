---
title: Gérer OLE dans les présentations avec Python
linktitle: Gérer OLE
type: docs
weight: 40
url: /fr/python-net/manage-ole/
keywords:
- objet OLE
- Lien et incorporation d'objets
- ajouter OLE
- intégrer OLE
- ajouter objet
- intégrer objet
- ajouter fichier
- intégrer fichier
- objet lié
- fichier lié
- modifier OLE
- icône OLE
- titre OLE
- extraire OLE
- extraire objet
- extraire fichier
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Optimisez la gestion des objets OLE dans les fichiers PowerPoint et OpenDocument avec Aspose.Slides pour Python via .NET. Intégrez, mettez à jour et exportez le contenu OLE de manière transparente."
---

## **Vue d'ensemble**

{{% alert title="Info" color="info" %}}

**OLE (Object Linking & Embedding)** est une technologie Microsoft qui permet aux données et objets créés dans une application d'être liés ou intégrés dans une autre.

{{% /alert %}}

Par exemple, un graphique créé dans Microsoft Excel et placé sur une diapositive PowerPoint est un objet OLE.

- Un objet OLE peut apparaître sous forme d’icône. Un double‑clic sur l’icône ouvre l’objet dans son application associée (par ex., Excel) ou vous invite à choisir une application pour l’ouvrir ou le modifier.
- Un objet OLE peut afficher son contenu (par ex., un graphique). Dans ce cas, PowerPoint active l’objet intégré, charge l’interface du graphique et vous permet de modifier les données du graphique directement dans PowerPoint.

Aspose.Slides for Python vous permet d’insérer des objets OLE dans les diapositives sous forme de cadres d’objets OLE ([OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)).

## **Ajouter des objets OLE aux diapositives**

Si vous avez déjà créé un graphique dans Microsoft Excel et que vous souhaitez l’intégrer dans une diapositive en tant que cadre d’objet OLE à l’aide d’Aspose.Slides for Python, suivez ces étapes :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenir une référence à la diapositive par son index.
1. Lire le fichier Excel dans un tableau d’octets.
1. Ajouter un [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) à la diapositive, en fournissant le tableau d’octets et les autres détails de l’objet OLE.
1. Enregistrer la présentation modifiée sous forme de fichier PPTX.

Dans l’exemple ci‑dessous, un graphique provenant d’un fichier Excel est intégré dans une diapositive en tant que [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).

**Remarque :** Le constructeur [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) prend l’extension du fichier de l’objet incorporable comme deuxième paramètre. PowerPoint utilise cette extension pour identifier le type de fichier et choisir l’application appropriée pour ouvrir l’objet OLE.

```py
with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]

    # Préparer les données pour l'objet OLE.
    with open("book.xlsx", "rb") as file_stream:
        file_data = file_stream.read()
        data_info = slides.dom.ole.OleEmbeddedDataInfo(file_data, "xlsx")

    # Ajouter un cadre d'objet OLE à la diapositive.
    ole_frame = slide.shapes.add_ole_object_frame(0, 0, slide_size.width, slide_size.height, data_info)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Ajouter des objets OLE liés**

Aspose.Slides for Python vous permet d’ajouter un [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) qui fait référence à un fichier au lieu d’en incorporer les données.

L’exemple Python suivant montre comment ajouter un [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) lié à un fichier Excel sur une diapositive :

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Ajouter un cadre d'objet OLE avec un fichier Excel lié.
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Accéder aux objets OLE**

Si un objet OLE est déjà intégré dans une diapositive, vous pouvez y accéder comme suit :

1. Charger la présentation contenant l’objet OLE intégré en créant une instance de la classe Presentation.
1. Obtenir une référence à la diapositive par son index.
1. Accéder à la forme OleObjectFrame.
1. Une fois le cadre d’objet OLE obtenu, effectuer les opérations souhaitées.

L’exemple ci‑dessous accède au cadre d’objet OLE — un graphique Excel intégré — et récupère les données du fichier. Dans cet exemple, nous utilisons un PPTX qui possède une seule forme sur la première diapositive.

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Obtenir les données du fichier intégré.
        file_data = ole_frame.embedded_data.embedded_file_data

        # Obtenir l'extension du fichier intégré.
        file_extension = ole_frame.embedded_data.embedded_file_extension

        # ...
```

### **Accéder aux propriétés d’un objet OLE lié**

Aspose.Slides vous permet d’accéder aux propriétés d’un cadre d’objet OLE lié.

L’exemple Python ci‑dessous vérifie si un objet OLE est lié et, le cas échéant, récupère le chemin du fichier lié :

```py
with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Vérifier si l'objet OLE est lié.
        if ole_frame.is_object_link:
            # Afficher le chemin complet du fichier lié.
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # Afficher le chemin relatif du fichier lié, le cas échéant.
            # Seules les présentations .ppt peuvent contenir un chemin relatif.
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```

## **Modifier les données d’un objet OLE**

{{% alert color="primary" %}}

Dans cette section, l’exemple de code ci‑dessous utilise [Aspose.Cells for Python via .NET](/cells/python-net/).

{{% /alert %}}

Si un objet OLE est déjà intégré dans une diapositive, vous pouvez y accéder et en modifier les données comme suit :

1. Charger la présentation en créant une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenir la diapositive cible par son index.
1. Accéder à la forme [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).
1. Une fois le cadre d’objet OLE obtenu, effectuer les opérations requises.
1. Créer un objet `Workbook` et lire les données OLE.
1. Ouvrir la `Worksheet` souhaitée et modifier les données.
1. Enregistrer le `Workbook` mis à jour dans un flux.
1. Remplacer les données de l’objet OLE à l’aide de ce flux.

Dans l’exemple ci‑dessous, un cadre d’objet OLE (un graphique Excel intégré) est accédé et ses données de fichier sont modifiées afin de mettre à jour le graphique. L’échantillon utilise un PPTX préalablement créé contenant une seule forme sur la première diapositive.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        with io.BytesIO(ole_frame.embedded_data.embedded_file_data) as ole_stream:
            # Lire les données de l'objet OLE en tant qu'objet Workbook.
            workbook = cells.Workbook(ole_stream)

        with io.BytesIO() as new_ole_stream:
            # Modifier les données du classeur.
            workbook.worksheets.get(0).cells.get(0, 4).put_value("E")
            workbook.worksheets.get(0).cells.get(1, 4).put_value(12)
            workbook.worksheets.get(0).cells.get(2, 4).put_value(14)
            workbook.worksheets.get(0).cells.get(3, 4).put_value(15)

            file_options = cells.OoxmlSaveOptions(cells.SaveFormat.XLSX)
            workbook.save(new_ole_stream, file_options)

            # Modifier les données de l'objet du cadre OLE.
            new_data = slides.dom.ole.OleEmbeddedDataInfo(new_ole_stream.getvalue(), ole_frame.embedded_data.embedded_file_extension)
            ole_frame.set_embedded_data(new_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Intégrer des fichiers dans les diapositives**

En plus des graphiques Excel, Aspose.Slides for Python vous permet d’intégrer d’autres types de fichiers dans les diapositives. Par exemple, vous pouvez insérer des fichiers HTML, PDF et ZIP comme objets. Lorsqu’un utilisateur double‑clique sur un objet inséré, il s’ouvre automatiquement dans l’application associée, ou l’utilisateur est invité à choisir un programme approprié.

Ce code Python montre comment intégrer des fichiers HTML et ZIP dans une diapositive :

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("sample.html", "rb") as html_stream:
        html_data = html_stream.read()

    html_data_info = slides.dom.ole.OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.shapes.add_ole_object_frame(150, 120, 50, 50, html_data_info)
    html_ole_frame.is_object_icon = True

    with open("sample.zip", "rb") as zip_stream:
        zip_data = zip_stream.read()

    zip_data_info = slides.dom.ole.OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.shapes.add_ole_object_frame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir les types de fichiers pour les objets intégrés**

Lorsque vous travaillez avec des présentations, il peut être nécessaire de remplacer d’anciens objets OLE par de nouveaux ou d’échanger un objet OLE non pris en charge contre un objet pris en charge. Aspose.Slides for Python vous permet de définir le type de fichier d’un objet intégré, vous permettant de mettre à jour les données du cadre OLE ou son extension de fichier.

Ce code Python montre comment définir le type de fichier de l’objet OLE intégré sur `zip` :

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    file_extension = ole_frame.embedded_data.embedded_file_extension
    file_data = ole_frame.embedded_data.embedded_file_data

    print(f"Current embedded file extension is: {file_extension}")

    # Modifier le type de fichier en ZIP.
    ole_frame.set_embedded_data(slides.dom.ole.OleEmbeddedDataInfo(file_data, "zip"))

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir les images d'icône et les titres pour les objets intégrés**

Après avoir intégré un objet OLE, un aperçu sous forme d’icône est ajouté automatiquement. Cet aperçu est ce que les utilisateurs voient avant d’accéder ou d’ouvrir l’objet OLE. Si vous souhaitez utiliser une image et un texte spécifiques dans l’aperçu, vous pouvez définir l’image d’icône et le titre à l’aide d’Aspose.Slides for Python.

Ce code Python montre comment définir l’image d’icône et le titre pour un objet intégré :

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Ajouter une image aux ressources de la présentation.
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # Définir un titre et l'image pour l'aperçu OLE.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Empêcher le redimensionnement et le repositionnement des cadres d'objets OLE**

Après avoir ajouté un objet OLE lié à une diapositive, PowerPoint peut vous inviter à mettre à jour les liens lorsque vous ouvrez la présentation. Sélectionner **Mettre à jour les liens** peut modifier la taille et la position du cadre d’objet OLE, car PowerPoint actualise l’aperçu avec les données de l’objet lié. Pour empêcher PowerPoint de vous inviter à mettre à jour les données de l’objet, définissez la propriété `update_automatic` de la classe [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) sur `False` :

```py
ole_frame.update_automatic = False
```

## **Extraire les fichiers intégrés**

Aspose.Slides for Python vous permet d’extraire les fichiers intégrés dans les diapositives en tant qu’objets OLE comme suit :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) qui contient les objets OLE à extraire.
1. Parcourir toutes les formes de la présentation et localiser les formes OLEObjectFrame.
1. Récupérer les données du fichier intégré de chaque [OLEObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) et les écrire sur le disque.

Le code Python suivant montre comment extraire les fichiers intégrés dans une diapositive en tant qu’objets OLE :

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for index, shape in enumerate(slide.shapes):
        if isinstance(shape, slides.OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.embedded_data.embedded_file_data
            file_extension = ole_frame.embedded_data.embedded_file_extension

            file_path = f"OLE_object_{index}{file_extension}"
            with open(file_path, 'wb') as file_stream:
                file_stream.write(file_data)
```

## **FAQ**

**Le contenu OLE sera-t-il rendu lors de l'exportation des diapositives en PDF/images ?**

Ce qui est visible sur la diapositive est rendu — l'icône/l'image de remplacement (aperçu). Le contenu OLE « en direct » n'est pas exécuté pendant le rendu. Si nécessaire, définissez votre propre image d'aperçu pour garantir l'apparence attendue dans le PDF exporté.

**Comment verrouiller un objet OLE sur une diapositive pour que les utilisateurs ne puissent pas le déplacer/modifier dans PowerPoint ?**

Verrouillez la forme : Aspose.Slides fournit des [verrous au niveau des formes](/slides/fr/python-net/applying-protection-to-presentation/). Ce n’est pas du chiffrement, mais cela empêche effectivement les modifications et déplacements accidentels.

**Pourquoi un objet Excel lié « saute » ou change de taille lorsque j'ouvre la présentation ?**

PowerPoint peut actualiser l’aperçu de l’OLE lié. Pour une apparence stable, suivez les pratiques de la [Solution fonctionnelle pour le redimensionnement de la feuille de calcul](/slides/fr/python-net/working-solution-for-worksheet-resizing/) — soit ajustez le cadre à la plage, soit redimensionnez la plage à un cadre fixe et définissez une image de remplacement appropriée.

**Les chemins relatifs des objets OLE liés seront-ils conservés au format PPTX ?**

Dans le PPTX, les informations de « chemin relatif » ne sont pas disponibles — seul le chemin complet l’est. Les chemins relatifs se trouvent dans le format PPT plus ancien. Pour la portabilité, privilégiez des chemins absolus fiables/URI accessibles ou l’intégration.