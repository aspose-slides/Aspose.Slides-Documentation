---
title: Gérer les OLE dans les présentations avec Python
linktitle: Gérer OLE
type: docs
weight: 40
url: /fr/python-net/manage-ole/
keywords:
- Objet OLE
- Liaison et incorporation d'objets
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
- extraire un objet
- extraire un fichier
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Optimisez la gestion des objets OLE dans PowerPoint et les fichiers OpenDocument avec Aspose.Slides pour Python via .NET. Intégrez, mettez à jour et exportez le contenu OLE de manière fluide."
---
## **Introduction**

{{% alert color="info" title="Remarque" %}}

**OLE (Object Linking & Embedding)** est une technologie Microsoft qui permet aux donnees et aux objets creés dans une application d'etre lies ou incorporés dans une autre.

{{% /alert %}}

Par exemple, un graphique creé dans Microsoft Excel et placé sur une diapositive PowerPoint est un objet OLE.

- Un objet OLE peut apparaître sous forme d'icone. Un double-clic sur l'icone ouvre l'objet dans son application associee (par ex., Excel) ou vous invite a choisir une application pour l'ouvrir ou le modifier.
- Un objet OLE peut afficher son contenu (par exemple, un graphique). Dans ce cas, PowerPoint active l'objet incorpore, charge l'interface du graphique et vous permet de modifier les donnees du graphique directement dans PowerPoint.

Aspose.Slides for Python vous permet d'inserer des objets OLE dans les diapos comme des cadres d'objets OLE ([OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/)).

## **Ajouter des objets OLE aux diapositives**

Si vous avez deja cree un graphique dans Microsoft Excel et que vous souhaitez l'incorporer dans une diapositive sous forme de cadre d'objet OLE a l'aide d'Aspose.Slides for Python, suivez ces etapes :

1. Creez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Obtenez une reference a la diapositive par son indice.
1. Lisez le fichier Excel dans un tableau d'octets.
1. Ajoutez un [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) a la diapositive, en fournissant le tableau d'octets et les autres details de l'objet OLE.
1. Enregistrez la presentation modifiee sous forme de fichier PPTX.

Dans l'exemple ci-dessous, un graphique issu d'un fichier Excel est incorpore dans une diapositive sous forme d'un [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/).

**Remarque :** Le constructeur [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/) prend l'extension de fichier de l'objet incorpore comme second parametre. PowerPoint utilise cette extension pour identifier le type de fichier et selectionner l'application appropriee pour ouvrir l'objet OLE.

```py
import aspose.slides as slides

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

### **Ajouter des objets OLE lies**

Aspose.Slides for Python vous permet d'ajouter un [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) qui cree un lien vers un fichier au lieu d'incorporer ses donnees.

L'exemple Python suivant montre comment ajouter un [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) lie a un fichier Excel sur une diapositive :

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Ajouter un cadre d'objet OLE avec un fichier Excel lié.
    slide.shapes.add_ole_object_frame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Acceder aux objets OLE**

Si un objet OLE est deja incorpore dans une diapositive, vous pouvez y acceder comme suit :

1. Chargez la presentation contenant l'objet OLE incorpore en creant une instance de la classe Presentation.
1. Obtenez une reference a la diapositive par son indice.
1. Accedez a la forme OleObjectFrame.
1. Une fois que vous avez le cadre d'objet OLE, effectuez les operations necessaires.

L'exemple ci-dessous accede au cadre d'objet OLE - un graphique Excel incorpore - et recupere ses donnees de fichier. Dans cet exemple, nous utilisons un PPTX contenant une seule forme sur la premiere diapositive.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    if isinstance(shape, slides.OleObjectFrame):
        ole_frame = shape

        # Obtenir les données du fichier incorporé.
        file_data = ole_frame.embedded_data.embedded_file_data

        # Obtenir l'extension du fichier incorporé.
        file_extension = ole_frame.embedded_data.embedded_file_extension

        # ...
```

### **Acceder aux proprietes d'un objet OLE lie**

Aspose.Slides vous permet d'acceder aux proprietes d'un cadre d'objet OLE lie.

L'exemple Python ci-dessous verifie si un objet OLE est lie et, le cas echeant, recupere le chemin du fichier lie :

```py
import aspose.slides as slides

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

## **Modifier les donnees d'un objet OLE**

{{% alert color="info" title="Remarque" %}}

Dans cette section, l'exemple de code ci-dessous utilise [Aspose.Cells for Python via .NET](https://docs.aspose.com/cells/python-net/).

{{% /alert %}}

Si un objet OLE est deja incorpore dans une diapositive, vous pouvez y acceder et modifier ses donnees comme suit :

1. Chargez la presentation en creant une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Obtenez la diapositive cible par son indice.
1. Accedez à la forme [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) .
1. Une fois que vous avez le cadre d'objet OLE, effectuez les operations requises.
1. Créez un objet `Workbook` et lisez les donnees OLE.
1. Ouvrez le `Worksheet` souhaité et modifiez les donnees.
1. Enregistrez le `Workbook` mis a jour dans un flux.
1. Remplacez les donnees de l'objet OLE en utilisant ce flux.

Dans l'exemple ci-dessous, un cadre d'objet OLE (un graphique Excel incorpore) est accedé et ses donnees de fichier sont modifiees pour mettre a jour le graphique. L'exemple utilise un PPTX prealablement cree contenant une seule forme sur la premiere diapositive.

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

## **Integrer des fichiers dans les diapositives**

En plus des graphiques Excel, Aspose.Slides for Python vous permet d'incorporer d'autres types de fichiers dans les diapositives. Par exemple, vous pouvez insérer des fichiers HTML, PDF et ZIP en tant qu'objets. Lorsqu'un utilisateur double-clique sur un objet insere, il s'ouvre automatiquement dans l'application associee, ou l'utilisateur est invite a choisir un programme adapte.

Ce code Python montre comment integrer des fichiers HTML et ZIP dans une diapositive :

```py
import aspose.slides as slides

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

## **Definir les types de fichiers pour les objets incorporés**

Lorsque vous travaillez avec des presentations, il peut être necessaire de remplacer d'anciens objets OLE par de nouveaux ou d'echanger un objet OLE non pris en charge contre un objet pris en charge. Aspose.Slides for Python vous permet de definir le type de fichier d'un objet incorpore, ce qui vous permet de mettre a jour les donnees du cadre OLE ou son extension de fichier.

Ce code Python montre comment definir le type de fichier de l'objet OLE incorpore sur `zip` :

```py
import aspose.slides as slides

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

## **Definir les images d'icone et les titres pour les objets incorporés**

Apres avoir intégré un objet OLE, un aperçu sous forme d'icone est ajouté automatiquement. Cet aperçu est ce que les utilisateurs voient avant d'acceder ou d'ouvrir l'objet OLE. Si vous souhaitez utiliser une image et un texte specifiques dans l'aperçu, vous pouvez definir l'image d'icone et le titre a l'aide d'Aspose.Slides for Python.

Ce code Python montre comment definir l'image d'icone et le titre pour un objet incorpore :

```py
import aspose.slides as slides

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

## **Empêcher le redimensionnement et le repositionnement des cadres d'objet OLE**

Apres avoir ajoute un objet OLE lie a une diapositive, PowerPoint peut vous inviter a mettre a jour les liens a l'ouverture de la presentation. Selectionner "Mettre a jour les liens" peut modifier la taille et la position du cadre d'objet OLE car PowerPoint rafraichit l'aperçu avec les donnees de l'objet lie. Pour empecher PowerPoint de vous demander de mettre a jour les donnees de l'objet, definissez la propriete `update_automatic` de la classe [OleObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) sur `False` :

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    ole_frame = slide.shapes[0]

    ole_frame.update_automatic = False

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Extraire les fichiers incorporés**

Aspose.Slides for Python vous permet d'extraire les fichiers incorporés dans les diapositives en tant qu'objets OLE comme suit :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) contenant les objets OLE que vous souhaitez extraire.
1. Parcourez toutes les formes de la presentation et localisez les formes OLEObjectFrame.
1. Recuperez les donnees de fichier incorporees de chaque [OLEObjectFrame](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/) et ecrivez-les sur le disque.

Le code Python suivant montre comment extraire les fichiers incorporés dans une diapositive en tant qu'objets OLE :

```py
import aspose.slides as slides

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

**Le contenu OLE sera-t-il rendu lors de l'exportation des diapositives en PDF/images ?**

Ce qui est visible sur la diapositive est rendu - l'icone/l'image de substitution (aperçu). Le contenu OLE "live" n'est pas execute pendant le rendu. Si necessaire, definissez votre propre image d'aperçu pour garantir l'apparence attendue dans le PDF exporte.

Pour également conserver le fichier incorpore comme piece jointe PDF, definissez [PdfOptions.include_ole_data](https://reference.aspose.com/slides/python-net/aspose.slides.export/pdfoptions/include_ole_data/) sur `True`. Cette option est desactivee par defaut. Pour un exemple et des instructions pour verifier la piece jointe, voir [Conserver les fichiers OLE incorporés en tant que pièces jointes PDF](/slides/fr/python-net/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Comment verrouiller un objet OLE sur une diapositive afin que les utilisateurs ne puissent pas le deplacer/modifier dans PowerPoint ?**

Verrouillez la forme : Aspose.Slides fournit des [verrouillages au niveau de la forme](/slides/fr/python-net/applying-protection-to-presentation/). Ce n'est pas du chiffrement, mais cela empeche efficacement les modifications et deplacements accidentels.

**Pourquoi un objet Excel lie "saute" ou change de taille lorsque j'ouvre la presentation ?**

PowerPoint peut rafraichir l'aperçu de l'OLE lie. Pour une apparence stable, suivez les bonnes pratiques de la [Solution fonctionnelle pour le redimensionnement de feuilles de calcul](/slides/fr/python-net/working-solution-for-worksheet-resizing/) - ajustez le cadre à la plage, ou redimensionnez la plage a un cadre fixe et definissez une image de substitution appropriee.

**Les chemins relatifs des objets OLE lies seront-ils conserves dans le format PPTX ?**

Dans le format PPTX, les informations de "chemin relatif" ne sont pas disponibles - seul le chemin complet est conserve. Les chemins relatifs se trouvent dans l'ancien format PPT. Pour la portabilite, privilégiez les chemins absolus fiables/URI accessibles ou l'incorporation.