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
description: "Corriger le redimensionnement OLE des feuilles de calcul Excel dans les présentations : deux façons de garder les cadres d'objet cohérents - redimensionner le cadre ou la feuille - sur les formats PPT et PPTX."
---
{{% alert color="info" title="Note" %}}

Les feuilles de calcul Excel integrees en tant qu'objets OLE dans une presentation PowerPoint utilisant les composants Aspose peuvent redimensionner de maniere inattendue apres leur premiere activation. Ce comportement cree une difference visuelle notable entre l'objet OLE avant et apres l'activation. Cet article explique le probleme et décrit deux façons de le résoudre.

{{% /alert %}}

## **Contexte**

Dans l'article [Gérer OLE](/slides/fr/python-java/manage-ole/), nous avons explique comment ajouter un cadre OLE a une presentation PowerPoint en utilisant Aspose.Slides pour Python via Java. Pour résoudre le [problème d'aperçu d'objet](/slides/fr/python-java/object-preview-issue-when-adding-oleobjectframe/), nous avons assigné une image de la zone de la feuille de calcul sélectionnée au cadre de l'objet OLE. Dans la presentation resultante, lorsque vous double-cliquez sur le cadre d'objet OLE affichant l'image de la feuille, le classeur Excel est active. Les utilisateurs finaux peuvent apporter les modifications souhaitées au classeur Excel réel, puis revenir a la diapositive en cliquant en dehors du classeur Excel active. La taille du cadre d'objet OLE changera lorsque l'utilisateur revient a la diapositive. Le facteur de redimensionnement variera en fonction de la taille du cadre d'objet OLE et du classeur Excel incorpore.

## **Cause du redimensionnement**

Comme le classeur Excel possède sa propre taille de fenêtre, il tente de conserver sa taille originale lors de la premiere activation. En revanche, le cadre d'objet OLE a sa propre taille. Selon Microsoft, lorsque le classeur Excel est active, Excel et PowerPoint negocient la taille afin de garantir le maintien des bonnes proportions dans le cadre du processus d'integration. Le redimensionnement se produit en fonction des differences entre la taille de la fenêtre Excel et la taille et la position du cadre d'objet OLE.

## **Solution fonctionnelle**

Il existe deux solutions possibles pour eviter l'effet de redimensionnement.

- Redimensionner le cadre OLE dans la presentation PowerPoint pour correspondre a la hauteur et a la largeur totales des lignes et colonnes selectionnees.
- Maintenir la taille du cadre OLE constante et redimensionner les lignes et colonnes selectionnees pour les faire tenir a l'interieur.

### **Redimensionner la taille du cadre OLE**

Cette approche definit la taille du cadre OLE pour correspondre a la hauteur et a la largeur totales des lignes et colonnes selectionnees dans la feuille Excel integree.

Exemple charge un classeur Excel existant et selectionne les 10 premieres lignes et les 13 premieres colonnes de sa premiere feuille en utilisant des index a base zero. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) definit la plage affichee. L'aperçu est rendu a 96 DPI, et ses dimensions en pixels sont converties en points en utilisant 72 points par pouce. [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) integre le classeur modifie dans un cadre avec ces dimensions. L'aperçu est assigne via [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) pour remplacer l'espace reserve "EMBEDDED OLE OBJECT" dans la presentation enregistree.

L'assistant d'aperçu definit [PageSetup.setPrintArea](https://reference.aspose.com/cells/python-java/asposecells.api/pagesetup/#printarea) sur la plage selectionnee et supprime les marges, en-tetes et pieds de page. Avec [ImageOrPrintOptions.setOnlyArea](https://reference.aspose.com/cells/python-java/asposecells.api/imageorprintoptions/#onlyarea) active, [SheetRender.toImage](https://reference.aspose.com/cells/python-java/asposecells.api/sheetrender/#toimage) rend la plage sous forme d'image PNG. L'assistant renvoie un nouveau flux d'entree contenant l'image PNG, positionne au debut pour etre utilise dans la presentation.

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

Cette approche redimensionne les hauteurs des lignes selectionnees et les largeurs des colonnes selectionnees pour correspondre a une taille de cadre OLE personnalisee.

L'exemple charge un classeur Excel existant et selectionne les 10 premieres lignes et les 13 premieres colonnes de sa premiere feuille en utilisant des index a base zero. [WorksheetCollection.setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) definit la plage affichee, et l'assistant scale_cell_range redimensionne cette plage pour l'adapter a un cadre de 400 points de large et 100 points de haut. Apres avoir enregistre le classeur modifie dans un flux, [ShapeCollection.addOleObjectFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addOleObjectFrame) l'integre a la taille specifiee. Un apercu rendu a 96 DPI est assigne via [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), de sorte que la presentation enregistree affiche les cellules selectionnees au lieu de l'espace reserve par defaut.

L'assistant de mise a l'echelle calcule des ratios de largeur et de hauteur separes pour la plage selectionnee, en preservant les largeurs relatives de ses colonnes et les hauteurs relatives de ses lignes. Il convertit les dimensions calculees de points en pouces avant de les appliquer avec [Cells.setColumnWidthInch](https://reference.aspose.com/cells/python-java/asposecells.api/cells/#setcolumnwidthinch) et [Cells.setRowHeightInch](https://reference.aspose.com/cells/python-java/asposecells.api/cells/#setrowheightinch). La plage selectionnee doit avoir une largeur et une hauteur non nulles.

Cet assistant d'aperçu rend la plage redimensionnee en utilisant [SheetRender.toImage](https://reference.aspose.com/cells/python-java/asposecells.api/sheetrender/#toimage). Il limite [PageSetup.setPrintArea](https://reference.aspose.com/cells/python-java/asposecells.api/pagesetup/#printarea) a cette plage, supprime les marges, en-tetes et pieds de page, et renvoie un flux PNG positionne au debut.

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
ByteArrayOutputStream = jpime.JClass("java.io.ByteArrayOutputStream")


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
    # La largeur et la hauteur attendues de la plage de cellules sont en points.
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
    # Redimensionner la plage de cellules pour l'adapter à la taille du cadre.
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

Il existe deux approches pour resoudre le probleme de redimensionnement de la feuille de calcul. Choisissez l'approche qui correspond le mieux a vos exigences et a votre cas d'utilisation. Les deux approches fonctionnent de la meme facon, que les presentations soient creees a partir d'un modele ou a partir de zero. De plus, il n'y a aucune limite a la taille du cadre d'objet OLE dans cette solution.

{{% /alert %}}

## **FAQ**

**Pourquoi une feuille de calcul Excel integree change-t-elle de taille lors de sa premiere activation dans PowerPoint?**

Cela se produit parce qu'Excel essaie de conserver la taille originale de la fenetre lorsqu'il est active, alors que le cadre d'objet OLE dans PowerPoint possède ses propres dimensions. PowerPoint et Excel negocient la taille afin de conserver le ratio d'aspect, ce qui peut entraîner le redimensionnement.

**Est-il possible d'eviter complètement ce probleme de redimensionnement?**

Oui. En redimensionnant le cadre OLE pour qu'il corresponde a la taille de la plage de cellules Excel ou en redimensionnant la plage de cellules pour qu'elle corresponde a la taille souhaitee du cadre OLE, vous pouvez eviter un redimensionnement indesirable.

**Quelle methode de mise a l'echelle dois-je utiliser, le redimensionnement du cadre OLE ou le redimensionnement de la plage de cellules?**

Selectionnez **OLE frame scaling** si vous souhaitez conserver les tailles originales des lignes et colonnes Excel. Selectionnez **cell range scaling** si vous voulez une taille fixe pour le cadre OLE dans votre presentation.

**Ces solutions fonctionneront-elles si ma presentation est basee sur un modele?**

Oui. Les deux solutions fonctionnent pour les presentations creees a partir de modeles et a partir de zero.

**Existe-t-il une limite a la taille du cadre OLE lors de l'utilisation de ces methodes?**

Non. Vous pouvez donner au cadre d'objet OLE n'importe quelle taille tant que vous définissez correctement l'echelle.

**Existe-t-il un moyen d'eviter le texte d'espace reserve "EMBEDDED OLE OBJECT" dans PowerPoint?**

Oui. En prenant une capture d'ecran de la plage de cellules Excel cible et en l'utilisant comme image d'espace reserve du cadre OLE, vous pouvez afficher une image d'aperçu personnalisee a la place de l'espace reserve par defaut.

## **Articles liés**

[Créer un graphique Excel et l'intégrer dans une présentation en tant qu'objet OLE](/slides/fr/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)

[Mettre à jour les objets OLE automatiquement à l'aide d'un complement MS PowerPoint](/slides/fr/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)