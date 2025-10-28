---
title: Gérer OLE dans les présentations avec Python
linktitle: Gérer OLE
type: docs
weight: 40
url: /fr/python-net/manage-ole/
keywords:
- Objet OLE
- Liaison et incorporation d'objets
- Ajouter OLE
- Intégrer OLE
- Ajouter un objet
- Intégrer un objet
- Ajouter un fichier
- Intégrer un fichier
- Objet lié
- Fichier lié
- Modifier OLE
- Icône OLE
- Titre OLE
- Extraire OLE
- Extraire l'objet
- Extraire le fichier
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Optimisez la gestion des objets OLE dans les fichiers PowerPoint et OpenDocument avec Aspose.Slides pour Python via .NET. Intégrez, mettez à jour et exportez le contenu OLE en toute transparence."
---

## **Vue d'ensemble**

{{% alert title="Info" color="info" %}}

**OLE (Object Linking & Embedding)** est une technologie Microsoft qui permet aux données et aux objets créés dans une application d'être liés ou incorporés dans une autre.

{{% /alert %}}

Par exemple, un graphique créé dans Microsoft Excel et placé sur une diapositive PowerPoint est un objet OLE.

- Un objet OLE peut apparaître sous forme d’icône. Un double‑clic sur l’icône ouvre l’objet dans son application associée (par ex., Excel) ou vous invite à choisir une application pour l’ouvrir ou le modifier.
- Un objet OLE peut afficher son contenu (par exemple, un graphique). Dans ce cas, PowerPoint active l’objet incorporé, charge l’interface du graphique et vous permet de modifier les données du graphique directement dans PowerPoint.

Aspose.Slides pour Python vous permet d'insérer des objets OLE dans les diapositives sous forme de cadres d'objets OLE ([OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)).

## **Ajouter des objets OLE aux diapositives**

Si vous avez déjà créé un graphique dans Microsoft Excel et que vous souhaitez l’intégrer dans une diapositive sous forme de cadre d’objet OLE à l’aide d’Aspose.Slides pour Python, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez une référence à la diapositive par son index.
3. Lisez le fichier Excel dans un tableau d’octets.
4. Ajoutez un [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) à la diapositive, en fournissant le tableau d’octets et les autres détails de l’objet OLE.
5. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Dans l’exemple ci‑dessous, un graphique provenant d’un fichier Excel est intégré dans une diapositive comme [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).

**Note :** Le constructeur [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) prend l’extension du fichier de l’objet incorporable comme deuxième paramètre. PowerPoint utilise cette extension pour identifier le type de fichier et sélectionner l’application appropriée pour ouvrir l’objet OLE.

```py
with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]

    # Prepare the data for the OLE object.
    with open("book.xlsx", "rb") as file_stream:
        file_data = file_stream.read()
        data_info = slides.dom.ole.OleEmbeddedDataInfo(file_data, "xlsx")

    # Add an OLE object frame to the slide.
    ole_frame = slide.shapes.add_ole_object_frame(0, 0, slide_size.width, slide_size.height, data_info)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Ajouter des objets OLE liés**

Aspose.Slides pour Python vous permet d’ajouter un [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) qui lie à un fichier au lieu d’incorporer ses données.

L’exemple Python suivant montre comment ajouter un [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) lié à un fichier Excel sur une diapositive :

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Add an OLE object frame with a linked Excel file.
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Accéder aux objets OLE**

Si un objet OLE est déjà incorporé dans une diapositive, vous pouvez y accéder comme suit :

1. Chargez la présentation contenant l’objet OLE incorporé en créant une instance de la classe Presentation.
2. Obtenez une référence à la diapositive par son index.
3. Accédez à la forme OleObjectFrame.
4. Une fois que vous avez le cadre d’objet OLE, effectuez les opérations requises dessus.

L’exemple ci‑dessous accède au cadre d’objet OLE—un graphique Excel incorporé—et récupère les données du fichier. Dans cet exemple, nous utilisons un PPTX contenant une seule forme sur la première diapositive.

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Get the embedded file data.
        file_data = ole_frame.embedded_data.embedded_file_data

        # Get the extension of the embedded file.
        file_extension = ole_frame.embedded_data.embedded_file_extension

        # ...
```

### **Accéder aux propriétés d'un objet OLE lié**

Aspose.Slides vous permet d’accéder aux propriétés d’un cadre d’objet OLE lié.

L’exemple Python ci‑dessous vérifie si un objet OLE est lié et, le cas échéant, récupère le chemin du fichier lié :

```py
with slides.Presentation("sample.ppt") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Check whether the OLE object is linked.
        if ole_frame.is_object_link:
            # Print the full path to the linked file.
            print("OLE object frame is linked to:", ole_frame.link_path_long)

            # Print the relative path to the linked file, if present.
            # Only .ppt presentations can contain a relative path.
            if ole_frame.link_path_relative:
                print("OLE object frame relative path:", ole_frame.link_path_relative)
```

## **Modifier les données d'un objet OLE**

{{% alert color="primary" %}}

Dans cette section, l’exemple de code ci‑dessous utilise [Aspose.Cells for Python via .NET](/cells/python-net/).

{{% /alert %}}

Si un objet OLE est déjà incorporé dans une diapositive, vous pouvez y accéder et modifier ses données comme suit :

1. Chargez la présentation en créant une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Obtenez la diapositive cible par son index.
3. Accédez à la forme [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).
4. Une fois que vous avez le cadre d’objet OLE, effectuez les opérations requises sur celui‑ci.
5. Créez un objet `Workbook` et lisez les données OLE.
6. Ouvrez la `Worksheet` désirée et modifiez les données.
7. Enregistrez le `Workbook` mis à jour dans un flux.
8. Remplacez les données de l’objet OLE en utilisant ce flux.

Dans l’exemple ci‑dessous, un cadre d’objet OLE (un graphique Excel incorporé) est accédé et ses données de fichier sont modifiées pour mettre à jour le graphique. L’exemple utilise un PPTX préalablement créé contenant une seule forme sur la première diapositive.

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
            # Read the OLE object data as a Workbook object.
            workbook = cells.Workbook(ole_stream)

        with io.BytesIO() as new_ole_stream:
            # Modify the workbook data.
            workbook.worksheets.get(0).cells.get(0, 4).put_value("E")
            workbook.worksheets.get(0).cells.get(1, 4).put_value(12)
            workbook.worksheets.get(0).cells.get(2, 4).put_value(14)
            workbook.worksheets.get(0).cells.get(3, 4).put_value(15)

            file_options = cells.OoxmlSaveOptions(cells.SaveFormat.XLSX)
            workbook.save(new_ole_stream, file_options)

            # Change the OLE frame object data.
            new_data = slides.dom.ole.OleEmbeddedDataInfo(new_ole_stream.getvalue(), ole_frame.embedded_data.embedded_file_extension)
            ole_frame.set_embedded_data(new_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Intégrer des fichiers dans les diapositives**

En plus des graphiques Excel, Aspose.Slides pour Python vous permet d’incorporer d’autres types de fichiers dans les diapositives. Par exemple, vous pouvez insérer des fichiers HTML, PDF et ZIP en tant qu’objets. Lorsqu’un utilisateur double‑clique sur un objet inséré, il s’ouvre automatiquement dans l’application associée, ou l’utilisateur est invité à choisir le programme approprié.

Ce code Python montre comment incorporer des fichiers HTML et ZIP dans une diapositive :

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

## **Définir les types de fichiers pour les objets incorporés**

Lorsque vous travaillez avec des présentations, il peut être nécessaire de remplacer d’anciens objets OLE par de nouveaux ou d’échanger un objet OLE non pris en charge contre un objet pris en charge. Aspose.Slides pour Python vous permet de définir le type de fichier d’un objet incorporé, ce qui vous permet de mettre à jour les données du cadre OLE ou son extension de fichier.

Ce code Python montre comment définir le type de fichier de l’objet OLE incorporé sur `zip` :

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    file_extension = ole_frame.embedded_data.embedded_file_extension
    file_data = ole_frame.embedded_data.embedded_file_data

    print(f"Current embedded file extension is: {file_extension}")

    # Change the file type to ZIP.
    ole_frame.set_embedded_data(slides.dom.ole.OleEmbeddedDataInfo(file_data, "zip"))

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir les images d'icône et les titres pour les objets incorporés**

Après avoir incorporé un objet OLE, un aperçu sous forme d’icône est ajouté automatiquement. Cet aperçu est ce que les utilisateurs voient avant d’accéder ou d’ouvrir l’objet OLE. Si vous souhaitez utiliser une image et un texte spécifiques dans l’aperçu, vous pouvez définir l’image d’icône et le titre à l’aide d’Aspose.Slides pour Python.

Ce code Python montre comment définir l’image d’icône et le titre d’un objet incorporé :

```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    # Add an image to the presentation resources.
    with slides.Images.from_file("image.png") as image:
        ole_image = presentation.images.add_image(image)

    # Set a title and the image for the OLE preview.
    ole_frame.substitute_picture_title = "My title"
    ole_frame.substitute_picture_format.picture.image = ole_image
    ole_frame.is_object_icon = True

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Empêcher le redimensionnement et le repositionnement des cadres d'objets OLE**

Après avoir ajouté un objet OLE lié à une diapositive, PowerPoint peut vous inviter à mettre à jour les liens lors de l’ouverture de la présentation. Sélectionner « Update Links » peut changer la taille et la position du cadre d’objet OLE parce que PowerPoint rafraîchit l’aperçu avec les données de l’objet lié. Pour empêcher PowerPoint de vous inviter à mettre à jour les données de l’objet, définissez la propriété `update_automatic` de la classe [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) sur `False` :

```py
ole_frame.update_automatic = False
```

## **Extraire les fichiers incorporés**

Aspose.Slides pour Python vous permet d’extraire les fichiers incorporés dans les diapositives en tant qu’objets OLE comme suit :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) contenant les objets OLE à extraire.
2. Parcourez toutes les formes de la présentation et localisez les formes OLEObjectFrame.
3. Récupérez les données du fichier incorporé de chaque [OLEObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) et écrivez‑les sur le disque.

Le code Python suivant montre comment extraire les fichiers incorporés dans une diapositive en tant qu’objets OLE :

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

**Le contenu OLE sera-t-il rendu lors de l'exportation des diapositives vers PDF/images ?**

Ce qui est visible sur la diapositive est rendu — l’icône/l’image de substitution (aperçu). Le contenu OLE « live » n’est pas exécuté pendant le rendu. Si nécessaire, définissez votre propre image d’aperçu pour garantir l’apparence attendue dans le PDF exporté.

**Comment verrouiller un objet OLE sur une diapositive afin que les utilisateurs ne puissent pas le déplacer/modifier dans PowerPoint ?**

Verrouillez la forme : Aspose.Slides fournit des [verrous au niveau de la forme](/slides/fr/python-net/applying-protection-to-presentation/). Ce n’est pas du chiffrement, mais cela empêche efficacement les modifications ou déplacements accidentels.

**Pourquoi un objet Excel lié « saute » ou change de taille lors de l'ouverture de la présentation ?**

PowerPoint peut rafraîchir l’aperçu de l’OLE lié. Pour une apparence stable, suivez les bonnes pratiques de la [Solution fonctionnelle pour le redimensionnement des feuilles de calcul](/slides/fr/python-net/working-solution-for-worksheet-resizing/) — ajustez le cadre à la plage, ou mettez l’échelle de la plage dans un cadre fixe et définissez une image de substitution appropriée.

**Les chemins relatifs des objets OLE liés seront-ils conservés dans le format PPTX ?**

Dans le PPTX, les informations de « chemin relatif » ne sont pas disponibles—seul le chemin complet l’est. Les chemins relatifs se trouvent dans le format PPT plus ancien. Pour la portabilité, privilégiez des chemins absolus fiables/URI accessibles ou l’incorporation.