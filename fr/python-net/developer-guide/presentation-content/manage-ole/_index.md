---
title: Gérer OLE dans les présentations avec Python
linktitle: Gérer OLE
type: docs
weight: 40
url: /fr/python-net/manage-ole/
keywords:
- objet OLE
- Liaison et intégration d'objets
- ajouter OLE
- intégrer OLE
- ajouter un objet
- intégrer un objet
- ajouter un fichier
- intégrer un fichier
- objet lié
- fichier lié
- modifier OLE
- icône OLE
- titre OLE
- extraire OLE
- extraire l'objet
- extraire le fichier
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: Optimisez la gestion des objets OLE dans PowerPoint et les fichiers OpenDocument avec Aspose.Slides pour Python via .NET. Intégrez, mettez à jour et exportez le contenu OLE de façon transparente.
---

## **Vue d'ensemble**

{{% alert title="Info" color="info" %}}

**OLE (Object Linking & Embedding)** est une technologie Microsoft qui permet de lier ou d’intégrer des données et des objets créés dans une application dans une autre.

{{% /alert %}}

Par exemple, un graphique créé dans Microsoft Excel et placé sur une diapositive PowerPoint est un objet OLE.

- Un objet OLE peut apparaître sous forme d’icône. Un double‑clic sur l’icône ouvre l’objet dans son application associée (par exemple, Excel) ou vous invite à choisir une application pour l’ouvrir ou le modifier.
- Un objet OLE peut afficher son contenu (par exemple, un graphique). Dans ce cas, PowerPoint active l’objet intégré, charge l’interface du graphique et vous permet de modifier les données du graphique directement dans PowerPoint.

Aspose.Slides for Python vous permet d’insérer des objets OLE dans des diapositives sous forme de cadres d’objets OLE ([OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)).

## **Ajouter des objets OLE aux diapositives**

Si vous avez déjà créé un graphique dans Microsoft Excel et que vous souhaitez l’intégrer dans une diapositive sous forme de cadre d’objet OLE avec Aspose.Slides for Python, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez une référence à la diapositive par son index.
1. Lisez le fichier Excel dans un tableau d’octets.
1. Ajoutez un [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) à la diapositive, en fournissant le tableau d’octets et les autres détails de l’objet OLE.
1. Enregistrez la présentation modifiée au format PPTX.

Dans l’exemple ci‑dessous, un graphique provenant d’un fichier Excel est intégré dans une diapositive sous forme de [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).

**Remarque :** Le constructeur [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) prend l’extension du fichier de l’objet à intégrer comme deuxième paramètre. PowerPoint utilise cette extension pour identifier le type de fichier et sélectionner l’application appropriée pour ouvrir l’objet OLE.
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

Aspose.Slides for Python vous permet d’ajouter un [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) qui établit un lien vers un fichier au lieu d’en intégrer les données.

L’exemple Python suivant montre comment ajouter un [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) lié à un fichier Excel sur une diapositive :
```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Ajouter un cadre d'objet OLE avec un fichier Excel lié.
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Accéder aux objets OLE**

Si un objet OLE est déjà intégré dans une diapositive, vous pouvez y accéder comme suit :

1. Chargez la présentation contenant l’objet OLE intégré en créant une instance de la classe Presentation.
1. Obtenez une référence à la diapositive par son index.
1. Accédez à la forme OleObjectFrame.
1. Une fois le cadre d’objet OLE obtenu, effectuez les opérations requises.

L’exemple ci‑dessous accède au cadre d’objet OLE — un graphique Excel intégré — et récupère ses données de fichier. Dans cet exemple, nous utilisons un fichier PPTX contenant une seule forme sur la première diapositive.
```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Récupérer les données du fichier intégré.
        file_data = ole_frame.embedded_data.embedded_file_data

        # Récupérer l'extension du fichier intégré.
        file_extension = ole_frame.embedded_data.embedded_file_extension

        # ...
```


### **Accéder aux propriétés des objets OLE liés**

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

            # Afficher le chemin relatif du fichier lié, si présent.
            # Seules les présentations .ppt peuvent contenir un chemin relatif.
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```


## **Modifier les données d’un objet OLE**

{{% alert color="primary" %}}

Dans cette section, l’exemple de code ci‑dessous utilise [Aspose.Cells for Python via .NET](/cells/python-net/).

{{% /alert %}}

Si un objet OLE est déjà intégré dans une diapositive, vous pouvez y accéder et modifier ses données comme suit :

1. Chargez la présentation en créant une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez la diapositive cible par son index.
1. Accédez à la forme [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).
1. Une fois le cadre d’objet OLE obtenu, effectuez les opérations requises.
1. Créez un objet `Workbook` et lisez les données OLE.
1. Ouvrez la `Worksheet` souhaitée et modifiez les données.
1. Enregistrez le `Workbook` mis à jour dans un flux.
1. Remplacez les données de l’objet OLE en utilisant ce flux.

Dans l’exemple ci‑dessus, un cadre d’objet OLE (un graphique Excel intégré) est accédé et ses données de fichier sont modifiées afin de mettre à jour le graphique. L’échantillon utilise un PPTX préalablement créé contenant une seule forme sur la première diapositive.
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

En plus des graphiques Excel, Aspose.Slides for Python vous permet d’intégrer d’autres types de fichiers dans les diapositives. Par exemple, vous pouvez insérer des fichiers HTML, PDF et ZIP comme objets. Lorsqu’un utilisateur double‑clique sur un objet inséré, celui‑ci s’ouvre automatiquement dans l’application associée, ou l’utilisateur est invité à choisir un programme approprié.

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


## **Définir le type de fichier des objets intégrés**

Lors du travail sur des présentations, vous pouvez devoir remplacer d’anciens objets OLE par de nouveaux ou échanger un objet OLE non pris en charge contre un objet pris en charge. Aspose.Slides for Python vous permet de définir le type de fichier d’un objet intégré, ce qui vous permet de mettre à jour les données du cadre OLE ou son extension de fichier.

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


## **Définir les images d’icône et les titres des objets intégrés**

Après avoir intégré un objet OLE, un aperçu basé sur une icône est ajouté automatiquement. Cet aperçu est ce que les utilisateurs voient avant d’accéder ou d’ouvrir l’objet OLE. Si vous souhaitez utiliser une image et un texte spécifiques dans l’aperçu, vous pouvez définir l’image d’icône et le titre à l’aide d’Aspose.Slides for Python.

Ce code Python montre comment définir l’image d’icône et le titre d’un objet intégré :
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


## **Empêcher le redimensionnement et le repositionnement des cadres d’objets OLE**

Après avoir ajouté un objet OLE lié à une diapositive, PowerPoint peut vous inviter à mettre à jour les liens lors de l’ouverture de la présentation. La sélection « Update Links » peut modifier la taille et la position du cadre d’objet OLE car PowerPoint rafraîchit l’aperçu avec les données de l’objet lié. Pour empêcher PowerPoint de vous inviter à mettre à jour les données de l’objet, définissez la propriété `update_automatic` de la classe [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) sur `False` :
```py
ole_frame.update_automatic = False
```


## **Extraire les fichiers intégrés**

Aspose.Slides for Python vous permet d’extraire les fichiers intégrés dans les diapositives en tant qu’objets OLE comme suit :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) contenant les objets OLE que vous souhaitez extraire.
1. Parcourez toutes les formes de la présentation et localisez les formes OLEObjectFrame.
1. Récupérez les données du fichier intégré de chaque [OLEObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) et écrivez‑les sur le disque.

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

**Le contenu OLE sera‑t‑il rendu lors de l’exportation des diapositives vers PDF/images ?**

Ce qui est visible sur la diapositive est rendu — l’icône/l’image de substitution (aperçu). Le contenu OLE « live » n’est pas exécuté pendant le rendu. Si nécessaire, définissez votre propre image d’aperçu pour garantir l’apparence attendue dans le PDF exporté.

**Comment verrouiller un objet OLE sur une diapositive afin que les utilisateurs ne puissent pas le déplacer/modifier dans PowerPoint ?**

Verrouillez la forme : Aspose.Slides propose des [verrous au niveau des formes](/slides/fr/python-net/applying-protection-to-presentation/). Ce n’est pas du chiffrement, mais cela empêche efficacement les modifications et déplacements accidentels.

**Pourquoi un objet Excel lié « saute » ou change de taille lorsque j’ouvre la présentation ?**

PowerPoint peut rafraîchir l’aperçu de l’objet OLE lié. Pour une apparence stable, suivez les bonnes pratiques de la [Solution fonctionnelle pour le redimensionnement des feuilles de calcul](/slides/fr/python-net/working-solution-for-worksheet-resizing/) — ajustez le cadre à la plage ou redimensionnez la plage à un cadre fixe et définissez une image de substitution appropriée.

**Les chemins relatifs des objets OLE liés seront‑ils conservés dans le format PPTX ?**

Dans le PPTX, les informations de « chemin relatif » ne sont pas disponibles — seul le chemin complet l’est. Les chemins relatifs existent dans l’ancien format PPT. Pour la portabilité, privilégiez les chemins absolus fiables/URI accessibles ou l’intégration.