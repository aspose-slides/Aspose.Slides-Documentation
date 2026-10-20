---
title: Solution fonctionnelle pour le redimensionnement de la feuille de calcul
type: docs
weight: 40
url: /fr/python-net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- image d'aperçu
- redimensionnement d'image
- Excel
- feuille de calcul
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Corrige le redimensionnement OLE des feuilles de calcul Excel dans les présentations : deux méthodes pour garder les cadres d'objet cohérents—redimensionner le cadre ou la feuille—dans les formats PPT et PPTX."
---
{{% alert color="info" title="Note" %}}

Les feuilles de calcul Excel incorporées en tant qu'objets OLE dans une présentation PowerPoint à l'aide des composants Aspose peuvent redimensionner de manière inattendue après leur première activation. Ce comportement crée une différence visuelle notable entre l'objet OLE avant et après l'activation. Cet article explique le problème et décrit deux façons de le résoudre.

{{% /alert %}} 

## **Contexte**

Dans l'article [Gérer OLE](/slides/fr/python-net/manage-ole/), nous avons expliqué comment ajouter un cadre OLE à une présentation PowerPoint en utilisant Aspose.Slides pour Python via .NET. Pour résoudre le [problème d'aperçu d'objet](/slides/fr/python-net/object-preview-issue-when-adding-oleobjectframe/), nous avons attribué une image de la zone de la feuille de calcul sélectionnée au cadre de l'objet OLE. Dans la présentation de sortie, lorsque vous double-cliquez sur le cadre d'objet OLE affichant l'image de la feuille de calcul, le classeur Excel est activé. Les utilisateurs finaux peuvent apporter toutes les modifications souhaitées au classeur Excel réel, puis revenir à la diapositive en cliquant en dehors du classeur Excel activé. La taille du cadre d'objet OLE changera lorsque l'utilisateur reviendra à la diapositive. Le facteur de redimensionnement variera en fonction de la taille du cadre d'objet OLE et du classeur Excel incorporé.

## **Cause du redimensionnement**

Comme le classeur Excel possède sa propre taille de fenêtre, il essaie de conserver sa taille d'origine lors de la première activation. D'autre part, le cadre de l'objet OLE a sa propre taille. Selon Microsoft, lorsque le classeur Excel est activé, Excel et PowerPoint négocient la taille afin de garantir qu'elle maintienne les bonnes proportions dans le cadre du processus d'incorporation. Le redimensionnement se produit en fonction des différences entre la taille de la fenêtre Excel et la taille et la position du cadre de l'objet OLE.

## **Solution fonctionnelle**

Il existe deux solutions possibles pour éviter l'effet de redimensionnement.

- Redimensionner le cadre OLE dans la présentation PowerPoint pour correspondre à la hauteur et à la largeur totales des lignes et colonnes sélectionnées.
- Conserver la taille du cadre OLE constante et redimensionner les lignes et colonnes sélectionnées pour qu'elles s'adaptent à l'intérieur.

### **Redimensionner la taille du cadre OLE**

Cette approche définit la taille du cadre OLE pour correspondre à la hauteur et à la largeur totales des lignes et colonnes sélectionnées dans la feuille de calcul Excel incorporée.

L'exemple charge un classeur Excel existant et sélectionne les 10 premières lignes et les 13 premières colonnes de sa première feuille de calcul en utilisant des indices basés sur zéro. [WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) définit la plage affichée. L'aperçu est rendu à 96 DPI, et ses dimensions en pixels sont converties en points en utilisant 72 points par pouce. [ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/) intègre le classeur modifié dans un cadre avec ces dimensions. L'aperçu est attribué via [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/) pour remplacer le texte de l'espace réservé "EMBEDDED OLE OBJECT" dans la présentation enregistrée.

Le helper d'aperçu définit [PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/) sur la plage sélectionnée et supprime les marges, en-têtes et pieds de page. Avec [ImageOrPrintOptions.only_area](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/imageorprintoptions/only_area/) activé, [SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/) rend la plage sous forme d'image PNG. Le helper revient en arrière dans le flux d'image avant de le renvoyer pour une utilisation dans la présentation.

```py
import io
import aspose.cells as cells

def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data
```

L'exemple complet ci-dessous combine les helpers avec l'incorporation du classeur et enregistre la présentation sous `output.pptx`.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data

start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # Définir la taille affichée lorsque le fichier de classeur est utilisé comme objet OLE dans PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    image_stream = create_ole_image(cell_range, image_resolution)

    # Obtenir la largeur et la hauteur de l'image OLE en points.
    with slides.Images.from_stream(image_stream) as image:
        image_width = image.width * 72 / image_resolution
        image_height = image.height * 72 / image_resolution

    # Nous devons utiliser le classeur modifié.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # Ajouter l'image OLE aux ressources de la présentation.
            image_stream.seek(0)
            ole_image = presentation.images.add_image(image_stream)

            # Créer le cadre d'objet OLE.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, image_width, image_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Redimensionner la taille de la plage de cellules**

Cette approche redimensionne les hauteurs des lignes sélectionnées et les largeurs des colonnes sélectionnées pour correspondre à une taille de cadre OLE personnalisée.

L'exemple charge un classeur Excel existant et sélectionne les 10 premières lignes et les 13 premières colonnes de sa première feuille de calcul en utilisant des indices basés sur zéro. [WorksheetCollection.set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) définit la plage affichée, et le helper ci‑dessous redimensionne cette plage pour l'adapter à un cadre de 400 points de large et 100 points de haut. Après avoir enregistré le classeur modifié dans un flux, [ShapeCollection.add_ole_object_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_ole_object_frame/) l'intègre à la taille spécifiée. Un aperçu rendu à 96 DPI est attribué via [OleObjectFrame.substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/oleobjectframe/substitute_picture_format/), de sorte que la présentation enregistrée affiche les cellules sélectionnées au lieu de l'espace réservé par défaut.

Le helper de redimensionnement calcule des rapports de largeur et de hauteur séparés pour la plage sélectionnée, en préservant les largeurs relatives de ses colonnes et les hauteurs relatives de ses lignes. Il convertit les dimensions calculées de points en pouces avant de les appliquer avec [Cells.set_column_width_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_column_width_inch/) et [Cells.set_row_height_inch](https://reference.aspose.com/cells/python-net/aspose.cells/cells/set_row_height_inch/). La plage sélectionnée doit avoir une largeur et une hauteur non nulles.

```py
import aspose.cells as cells

# <param name="width">La largeur attendue de la plage de cellules en points.</param>
# <param name="height">La hauteur attendue de la plage de cellules en points.</param>
def scale_cell_range(cell_range, width, height):
    range_width = cell_range.width
    range_height = cell_range.height

    for i in range(cell_range.column_count):
        column_index = cell_range.first_column + i
        column_width = cell_range.worksheet.cells.get_column_width(column_index, False, cells.CellsUnitType.POINT)

        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72
        cell_range.worksheet.cells.set_column_width_inch(column_index, width_in_inches)

    for i in range(cell_range.row_count):
        row_index = cell_range.first_row + i
        row_height = cell_range.worksheet.cells.get_row_height(row_index, False, cells.CellsUnitType.POINT)

        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72
        cell_range.worksheet.cells.set_row_height_inch(row_index, height_in_inches)
```

Ce helper d'aperçu rend la plage redimensionnée en utilisant [SheetRender.to_image](https://reference.aspose.com/cells/python-net/aspose.cells.rendering/sheetrender/to_image/). Il limite [PageSetup.print_area](https://reference.aspose.com/cells/python-net/aspose.cells/pagesetup/print_area/) à cette plage, supprime les marges, en‑têtes et pieds de page, et renvoie un flux PNG positionné au début.

```py
import io
import aspose.cells as cells

def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data
```

L'exemple complet ci-dessous combine les helpers avec l'incorporation du classeur et enregistre la présentation sous `output.pptx`.

```py
import io
import aspose.slides as slides
import aspose.cells as cells

# <param name="width">La largeur attendue de la plage de cellules en points.</param>
# <param name="height">La hauteur attendue de la plage de cellules en points.</param>
def scale_cell_range(cell_range, width, height):
    range_width = cell_range.width
    range_height = cell_range.height

    for i in range(cell_range.column_count):
        column_index = cell_range.first_column + i
        column_width = cell_range.worksheet.cells.get_column_width(column_index, False, cells.CellsUnitType.POINT)

        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72
        cell_range.worksheet.cells.set_column_width_inch(column_index, width_in_inches)

    for i in range(cell_range.row_count):
        row_index = cell_range.first_row + i
        row_height = cell_range.worksheet.cells.get_row_height(row_index, False, cells.CellsUnitType.POINT)

        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72
        cell_range.worksheet.cells.set_row_height_inch(row_index, height_in_inches)

def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.worksheet.page_setup
    page_setup.print_area = cell_range.address
    page_setup.left_margin = 0.0
    page_setup.right_margin = 0.0
    page_setup.top_margin = 0.0
    page_setup.bottom_margin = 0.0
    page_setup.clear_header_footer()

    image_options = cells.rendering.ImageOrPrintOptions()
    image_options.image_type = cells.drawing.ImageType.PNG
    image_options.vertical_resolution = image_resolution
    image_options.horizontal_resolution = image_resolution
    image_options.one_page_per_sheet = True
    image_options.only_area = True

    sheet_render = cells.rendering.SheetRender(cell_range.worksheet, image_options)
    image_data = io.BytesIO()

    sheet_render.to_image(0, image_data)
    image_data.seek(0)

    return image_data

start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96
frame_width, frame_height = 400.0, 100.0

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # Définir la taille affichée lorsque le fichier de classeur est utilisé comme objet OLE dans PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # Redimensionner la plage de cellules pour correspondre à la taille du cadre.
    cell_range = worksheet.cells.create_range(start_row, start_column, row_count, column_count)
    scale_cell_range(cell_range, frame_width, frame_height)

    image_stream = create_ole_image(cell_range, image_resolution)

    # Nous devons utiliser le classeur modifié.
    with io.BytesIO() as ole_stream:
        workbook.save(ole_stream, cells.SaveFormat.XLSX)

        with slides.Presentation() as presentation:
            slide = presentation.slides[0]

            # Ajouter l'image OLE aux ressources de la présentation.
            ole_image = presentation.images.add_image(image_stream)

            # Créer le cadre d'objet OLE.
            data_info = slides.dom.ole.OleEmbeddedDataInfo(ole_stream.getvalue(), "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(10, 10, frame_width, frame_height, data_info)
            ole_frame.substitute_picture_format.picture.image = ole_image
            ole_frame.is_object_icon = False

            presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Conclusion**

{{% alert color="info" title="Note" %}}

Il existe deux approches pour résoudre le problème de redimensionnement de la feuille de calcul. Choisissez l'approche qui correspond le mieux à vos exigences et à votre cas d'utilisation. Les deux approches fonctionnent de la même façon, que les présentations soient créées à partir d'un modèle ou à partir de zéro. De plus, il n'existe aucune limite à la taille du cadre d'objet OLE dans cette solution.

{{% /alert %}}

## **FAQ**

**Pourquoi une feuille de calcul Excel incorporée change-t-elle de taille lors de sa première activation dans PowerPoint ?**

Cela se produit parce qu'Excel essaie de conserver la taille originale de la fenêtre lorsqu'il est activé, tandis que le cadre de l'objet OLE dans PowerPoint a ses propres dimensions. PowerPoint et Excel négocient la taille pour maintenir le rapport d'aspect, ce qui peut entraîner le redimensionnement.

**Est-il possible d'éviter complètement ce problème de redimensionnement ?**

Oui. En redimensionnant le cadre OLE pour qu'il corresponde à la taille de la plage de cellules Excel ou en redimensionnant la plage de cellules pour qu'elle corresponde à la taille souhaitée du cadre OLE, vous pouvez éviter les redimensionnements indésirables.

**Quelle méthode de redimensionnement dois-je utiliser, le redimensionnement du cadre OLE ou le redimensionnement de la plage de cellules ?**

Sélectionnez **le redimensionnement du cadre OLE** si vous souhaitez conserver les tailles originales des lignes et colonnes Excel. Sélectionnez **le redimensionnement de la plage de cellules** si vous voulez une taille fixe pour le cadre OLE dans votre présentation.

**Ces solutions fonctionneront-elles si ma présentation est basée sur un modèle ?**

Oui. Les deux solutions fonctionnent pour les présentations créées à partir de modèles et à partir de zéro.

**Existe-t-il une limite à la taille du cadre OLE lors de l'utilisation de ces méthodes ?**

Non. Vous pouvez donner au cadre d'objet OLE n'importe quelle taille tant que vous définissez correctement l'échelle.

**Existe-t-il un moyen d'éviter le texte d'espace réservé "EMBEDDED OLE OBJECT" dans PowerPoint ?**

Oui. En prenant une capture d'écran de la plage de cellules Excel cible et en l'utilisant comme image d'espace réservé du cadre OLE, vous pouvez afficher une image d'aperçu personnalisée à la place de l'espace réservé par défaut.