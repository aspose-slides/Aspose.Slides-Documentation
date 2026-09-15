---
title: Solution fonctionnelle pour le redimensionnement des feuilles de calcul
type: docs
weight: 20
url: /fr/python-java/working-solution-for-worksheet-resizing/
keywords:
- OLE
- image d'aperçu
- redimensionnement d'image
- Excel
- feuille de calcul
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Correction du redimensionnement OLE des feuilles de calcul Excel dans les présentations : deux méthodes pour maintenir la cohérence des cadres d'objet—redimensionner le cadre ou la feuille—dans les formats PPT et PPTX."
---
{{% alert color="info" title="Note" %}}

Il a été observé que les feuilles de calcul Excel intégrées en tant qu’objets OLE dans une présentation PowerPoint via les composants Aspose sont redimensionnées à une échelle non spécifiée après la première activation. Ce comportement crée une différence visuelle notable dans la présentation entre les états avant et après l’activation de l’objet OLE. Nous avons étudié ce problème en détail et fourni une solution, qui est présentée dans cet article.

{{% /alert %}}

## **Contexte**

Dans l’article [Gérer OLE](/slides/fr/python-java/manage-ole/), nous avons expliqué comment ajouter un cadre OLE à une présentation PowerPoint en utilisant Aspose.Slides for Python via Java. Pour résoudre le [problème d’aperçu d’objet](/slides/fr/python-java/object-preview-issue-when-adding-oleobjectframe/), nous avons affecté une image de la zone de feuille de calcul sélectionnée à la trame d’objet OLE. Dans la présentation générée, lorsque vous double‑cliquez sur la trame d’objet OLE affichant l’image de la feuille de calcul, le classeur Excel est activé. Les utilisateurs finaux peuvent apporter les modifications souhaitées au classeur Excel réel, puis revenir à la diapositive en cliquant en dehors du classeur Excel activé. La taille de la trame d’objet OLE changera lorsque l’utilisateur reviendra à la diapositive. Le facteur de redimensionnement variera en fonction de la taille de la trame d’objet OLE et du classeur Excel intégré.

## **Cause du redimensionnement**

Comme le classeur Excel possède sa propre taille de fenêtre, il tente de conserver sa taille d’origine lors de la première activation. En revanche, la trame d’objet OLE a sa propre taille. Selon Microsoft, lorsque le classeur Excel est activé, Excel et PowerPoint négocient la taille afin de garantir le maintien des proportions correctes dans le cadre du processus d’intégration. Le redimensionnement se produit en fonction des différences entre la taille de la fenêtre Excel et la taille et la position de la trame d’objet OLE.

## **Solution fonctionnelle**

Deux solutions possibles permettent d’éviter l’effet de redimensionnement.

- Redimensionner la taille de la trame OLE dans la présentation PowerPoint pour qu’elle corresponde à la hauteur et à la largeur du nombre souhaité de lignes et de colonnes dans la trame OLE.
- Conserver la taille de la trame OLE constante et redimensionner la taille des lignes et colonnes participantes pour qu’elles s’ajustent à la taille de trame OLE sélectionnée.

### **Redimensionner la taille de la trame OLE**

Dans cette approche, nous apprendrons comment définir la taille de la trame OLE du classeur Excel intégré afin qu’elle corresponde à la taille cumulative des lignes et colonnes participantes dans la feuille de calcul Excel.

Supposons que nous disposions d’une feuille Excel modèle et que nous voulions l’ajouter à une présentation en tant que trame OLE. Dans ce scénario, la taille de la trame d’objet OLE sera d’abord calculée à partir des hauteurs cumulées des lignes et des largeurs cumulées des colonnes participantes dans le classeur. Ensuite, nous définirons la taille de la trame OLE à cette valeur calculée. Pour éviter le message rouge « EMBEDDED OLE OBJECT » pour la trame OLE dans PowerPoint, nous capturerons également une image des portions souhaitées des lignes et colonnes dans le classeur et l’utiliserons comme image de la trame OLE.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ImageOrPrintOptions, ImageType, SheetRender, CellsUnitType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Presentation, OleEmbeddedDataInfo, SaveFormat

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.getWorksheet().getPageSetup()
    page_setup.setPrintArea(cell_range.getAddress())
    page_setup.setLeftMargin(0)
    page_setup.setRightMargin(0)
    page_setup.setTopMargin(0)
    page_setup.setBottomMargin(0)
    page_setup.clearHeaderFooter()

    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    image_options.setVerticalResolution(image_resolution)
    image_options.setHorizontalResolution(image_resolution)
    image_options.setOnePagePerSheet(True)
    image_options.setOnlyArea(True)

    sheet_render = SheetRender(cell_range.getWorksheet(), image_options)
    image_stream = ByteArrayOutputStream()
    try:
        sheet_render.toImage(0, image_stream)
        image_data = image_stream.toByteArray()
        return ByteArrayInputStream(image_data)
    finally:
        image_stream.close()


start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0
image_resolution = 96

workbook = Workbook("sample.xlsx")
try:
    worksheet = workbook.getWorksheets().get(worksheet_index)

    # Définir la taille affichée lorsque le classeur est utilisé comme objet OLE dans PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)

    image_stream = create_ole_image(cell_range, image_resolution)
    try:
        # Obtenir la largeur et la hauteur de l'image OLE en points.
        image_io = jpype.JClass("javax.imageio.ImageIO")
        image = image_io.read(image_stream)
        frame_width = image.getWidth() * 72.0 / image_resolution
        frame_height = image.getHeight() * 72.0 / image_resolution

        # Utiliser le classeur modifié.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # Ajouter l'image OLE aux ressources de la présentation.
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # Créer le cadre d'objet OLE.
            data_info = OleEmbeddedDataInfo(workbook_data, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(10.0, 10.0, frame_width, frame_height, data_info)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
            ole_frame.setObjectIcon(False)

            presentation.save("output.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        image_stream.close()
finally:
    workbook.dispose()
```

### **Redimensionner la taille de la plage de cellules**

Dans cette approche, nous apprendrons comment redimensionner les hauteurs des lignes participantes et les largeurs des colonnes participantes pour correspondre à une taille de trame OLE personnalisée.

Supposons que nous disposions d’une feuille Excel modèle et que nous voulions l’ajouter à une présentation en tant que trame OLE. Dans ce scénario, nous définirons la taille de la trame OLE et redimensionnerons la taille des lignes et colonnes qui participent à la zone de la trame OLE. Nous enregistrerons ensuite le classeur dans un flux afin d’appliquer les modifications et le convertirons en tableau d’octets pour l’ajouter à la trame OLE. Pour éviter le message rouge « EMBEDDED OLE OBJECT » pour la trame OLE dans PowerPoint, nous capturerons également une image des portions souhaitées des lignes et colonnes dans le classeur et l’utiliserons comme image de la trame OLE.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ImageOrPrintOptions, ImageType, SheetRender, CellsUnitType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Presentation, OleEmbeddedDataInfo, SaveFormat

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def create_ole_image(cell_range, image_resolution):
    page_setup = cell_range.getWorksheet().getPageSetup()
    page_setup.setPrintArea(cell_range.getAddress())
    page_setup.setLeftMargin(0)
    page_setup.setRightMargin(0)
    page_setup.setTopMargin(0)
    page_setup.setBottomMargin(0)
    page_setup.clearHeaderFooter()

    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    image_options.setVerticalResolution(image_resolution)
    image_options.setHorizontalResolution(image_resolution)
    image_options.setOnePagePerSheet(True)
    image_options.setOnlyArea(True)

    sheet_render = SheetRender(cell_range.getWorksheet(), image_options)
    image_stream = ByteArrayOutputStream()
    try:
        sheet_render.toImage(0, image_stream)
        image_data = image_stream.toByteArray()
        return ByteArrayInputStream(image_data)
    finally:
        image_stream.close()


def scale_cell_range(cell_range, width, height):
    # La largeur et la hauteur attendues de la plage de cellules sont exprimées en points.
    range_width = cell_range.getWidth()
    range_height = cell_range.getHeight()
    cells = cell_range.getWorksheet().getCells()

    for i in range(cell_range.getColumnCount()):
        column_index = cell_range.getFirstColumn() + i
        column_width = cells.getColumnWidth(column_index, False, CellsUnitType.POINT)
        new_column_width = column_width * width / range_width
        width_in_inches = new_column_width / 72.0
        cells.setColumnWidthInch(column_index, width_in_inches)

    for i in range(cell_range.getRowCount()):
        row_index = cell_range.getFirstRow() + i
        row_height = cells.getRowHeight(row_index, False, CellsUnitType.POINT)
        new_row_height = row_height * height / range_height
        height_in_inches = new_row_height / 72.0
        cells.setRowHeightInch(row_index, height_in_inches)


start_row, row_count = 0, 10
start_column, column_count = 0, 13
worksheet_index = 0
image_resolution = 96
frame_width, frame_height = 400.0, 100.0
workbook = Workbook("sample.xlsx")
try:
    worksheet = workbook.getWorksheets().get(worksheet_index)

    # Définir la taille affichée lorsque le classeur est utilisé comme objet OLE dans PowerPoint.
    last_row = start_row + row_count - 1
    last_column = start_column + column_count - 1
    workbook.getWorksheets().setOleSize(start_row, last_row, start_column, last_column)

    cell_range = worksheet.getCells().createRange(start_row, start_column, row_count, column_count)
    # Redimensionner la plage de cellules pour correspondre à la taille du cadre.
    scale_cell_range(cell_range, frame_width, frame_height)
    image_stream = create_ole_image(cell_range, image_resolution)
    try:

        # Utiliser le classeur modifié.
        ole_stream = ByteArrayOutputStream()
        try:
            workbook.save(ole_stream, CellsSaveFormat.XLSX)
            workbook_data = ole_stream.toByteArray()
        finally:
            ole_stream.close()

        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)

            # Ajouter l'image OLE aux ressources de la présentation.
            image_stream.reset()
            ole_image = presentation.getImages().addImage(image_stream)

            # Créer le cadre d'objet OLE.
            data_info = OleEmbeddedDataInfo(workbook_data, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(10.0, 10.0, frame_width, frame_height, data_info)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
            ole_frame.setObjectIcon(False)

            presentation.save("output.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        image_stream.close()
finally:
    workbook.dispose()
```

## **Conclusion**

{{% alert color="info" title="Note" %}} 

Il existe deux approches pour résoudre le problème de redimensionnement de la feuille de calcul. Le choix de l’approche appropriée dépend des exigences spécifiques et du cas d’utilisation. Les deux approches fonctionnent de la même manière, que les présentations soient créées à partir d’un modèle ou à partir de zéro. De plus, il n’y a aucune limite à la taille de la trame d’objet OLE dans cette solution.

{{% /alert %}}

## **FAQ**

**Pourquoi une feuille de calcul Excel intégrée change-t-elle de taille lors de sa première activation dans PowerPoint ?**

Cela se produit parce qu’Excel tente de conserver la taille originale de sa fenêtre lorsqu’il est activé, alors que la trame d’objet OLE dans PowerPoint possède ses propres dimensions. PowerPoint et Excel négocient la taille afin de maintenir le rapport d’aspect, ce qui peut entraîner le redimensionnement.

**Est‑il possible d’éliminer complètement ce problème de redimensionnement ?**

Oui. En redimensionnant la trame OLE pour correspondre à la taille de la plage de cellules Excel ou en redimensionnant la plage de cellules pour correspondre à la taille souhaitée de la trame OLE, vous pouvez éviter le redimensionnement indésirable.

**Quelle méthode de redimensionnement dois‑je utiliser, le redimensionnement de la trame OLE ou celui de la plage de cellules ?**

Choisissez **le redimensionnement de la trame OLE** si vous souhaitez conserver les tailles de lignes et colonnes Excel d’origine. Choisissez **le redimensionnement de la plage de cellules** si vous voulez une taille fixe pour la trame OLE dans votre présentation.

**Ces solutions fonctionneront‑elles si ma présentation est basée sur un modèle ?**

Oui. Les deux solutions fonctionnent pour les présentations créées à partir de modèles et à partir de zéro.

**Existe‑t‑il une limite à la taille de la trame OLE lorsqu’on utilise ces méthodes ?**

Non. Vous pouvez donner à la trame d’objet OLE n’importe quelle taille tant que vous définissez correctement l’échelle.

**Existe‑t‑il un moyen d’éviter le texte de remplacement « EMBEDDED OLE OBJECT » dans PowerPoint ?**

Oui. En capturant un instantané de la plage de cellules Excel cible et en l’utilisant comme image de remplacement de la trame OLE, vous pouvez afficher une image d’aperçu personnalisée à la place du texte de substitution par défaut.

## **Articles associés**

[Créer un graphique Excel et l’intégrer à une présentation en tant qu’objet OLE](/slides/fr/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)