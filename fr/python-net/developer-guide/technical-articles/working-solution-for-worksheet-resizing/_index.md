---
title: "Solution fonctionnelle pour le redimensionnement des feuilles de calcul"
type: docs
weight: 40
url: /fr/python-net/working-solution-for-worksheet-resizing/
keywords:
- OLE
- "image d'aperçu"
- "redimensionnement d'image"
- Excel
- "feuille de calcul"
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Corriger le redimensionnement OLE des feuilles de calcul Excel dans les présentations : deux façons de maintenir la cohérence des cadres d'objet—mettre à l'échelle le cadre ou la feuille—dans les formats PPT et PPTX."
---

{{% alert color="primary" %}} 

Il a été observé que les feuilles de calcul Excel intégrées en tant qu’objets OLE dans une présentation PowerPoint via les composants Aspose sont redimensionnées à une échelle indéterminée après la première activation. Ce comportement crée une différence visuelle notable dans la présentation entre les états avant et après l’activation de l’objet OLE. Nous avons étudié ce problème en détail et fourni une solution, qui est présentée dans cet article.

{{% /alert %}} 

## **Contexte**

Dans l’article [Gérer OLE](/slides/fr/python-net/manage-ole/), nous avons expliqué comment ajouter un cadre OLE à une présentation PowerPoint en utilisant Aspose.Slides for Python via .NET. Pour résoudre le [problème d’aperçu d’objet](/slides/fr/python-net/object-preview-issue-when-adding-oleobjectframe/), nous avons affecté une image de la zone de feuille de calcul sélectionnée au cadre de l’objet OLE. Dans la présentation générée, lorsque vous double‑cliquez sur le cadre OLE affichant l’image de la feuille de calcul, le classeur Excel est activé. Les utilisateurs finaux peuvent effectuer les modifications souhaitées dans le classeur Excel réel, puis revenir à la diapositive en cliquant en dehors du classeur Excel activé. La taille du cadre OLE changera lorsque l’utilisateur reviendra à la diapositive. Le facteur de redimensionnement variera en fonction de la taille du cadre OLE et du classeur Excel intégré. 

## **Cause du redimensionnement**

Étant donné que le classeur Excel possède sa propre taille de fenêtre, il tente de conserver sa taille d’origine lors de la première activation. En revanche, le cadre OLE a sa propre taille. Selon Microsoft, lorsque le classeur Excel est activé, Excel et PowerPoint négocient la taille afin de garantir le maintien des bonnes proportions dans le cadre du processus d’intégration. Le redimensionnement se produit en fonction des différences entre la taille de la fenêtre Excel et la taille et la position du cadre OLE. 

## **Solution fonctionnelle**

Il existe deux solutions possibles pour éviter l’effet de redimensionnement.

- Redimensionner la taille du cadre OLE dans la présentation PowerPoint pour correspondre à la hauteur et à la largeur du nombre souhaité de lignes et de colonnes dans le cadre OLE.  
- Conserver la taille du cadre OLE constante et redimensionner la taille des lignes et colonnes participantes afin qu’elles s’ajustent à la taille du cadre OLE sélectionné.  

### **Redimensionner la taille du cadre OLE**

Dans cette approche, nous apprendrons comment définir la taille du cadre OLE du classeur Excel intégré afin qu’elle corresponde à la taille cumulative des lignes et colonnes participantes de la feuille de calcul Excel.

Supposons que nous disposions d’une feuille Excel modèle et que nous souhaitions l’ajouter à une présentation en tant que cadre OLE. Dans ce scénario, la taille du cadre OLE sera d’abord calculée en fonction des hauteurs cumulées des lignes et des largeurs cumulées des colonnes participantes du classeur. Ensuite, nous fixerons la taille du cadre OLE à cette valeur calculée. Pour éviter le message rouge « EMBEDDED OLE OBJECT » pour le cadre OLE dans PowerPoint, nous capturerons également une image des portions souhaitées des lignes et colonnes du classeur et l’utiliserons comme image du cadre OLE.  
```py
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

```py
start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # Définir la taille affichée lorsque le fichier classeur est utilisé comme objet OLE dans PowerPoint.
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

Dans cette approche, nous apprendrons comment redimensionner les hauteurs des lignes participantes et la largeur des colonnes participantes pour correspondre à une taille de cadre OLE personnalisée.

Supposons que nous disposions d’une feuille Excel modèle et que nous souhaitions l’ajouter à une présentation en tant que cadre OLE. Dans ce scénario, nous fixerons la taille du cadre OLE et redimensionnerons la taille des lignes et colonnes qui participent à la zone du cadre OLE. Nous sauvegarderons ensuite le classeur dans un flux afin d’appliquer les modifications et le convertirons en tableau d’octets pour l’ajouter au cadre OLE. Pour éviter le message rouge « EMBEDDED OLE OBJECT » pour le cadre OLE dans PowerPoint, nous capturerons également une image des portions souhaitées des lignes et colonnes du classeur et l’utiliserons comme image du cadre OLE.  
```py
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

```py
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

```py
start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0

image_resolution = 96
frame_width, frame_height = 400.0, 100.0

with cells.Workbook("sample.xlsx") as workbook:
    worksheet = workbook.worksheets[worksheet_index]

    # Définir la taille affichée lorsque le fichier classeur est utilisé comme objet OLE dans PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.worksheets.set_ole_size(start_row, last_row, start_column, last_column)

    # Redimensionner la plage de cellules pour s'adapter à la taille du cadre.
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

{{% alert color="primary" %}}

Il existe deux approches pour corriger le problème de redimensionnement de la feuille de calcul. Le choix de l’approche appropriée dépend des exigences spécifiques et du cas d’utilisation. Les deux approches fonctionnent de la même manière, que les présentations soient créées à partir d’un modèle ou à partir de zéro. De plus, il n’y a aucune limite à la taille du cadre OLE dans cette solution.

{{% /alert %}}