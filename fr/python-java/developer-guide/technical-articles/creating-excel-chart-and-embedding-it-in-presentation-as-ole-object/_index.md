---
title: Créer des graphiques Excel et les intégrer dans des présentations en tant qu'objets OLE
type: docs
weight: 30
url: /fr/python-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- graphique Excel
- intégrer le graphique
- objet OLE
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Créer un graphique Excel avec Aspose.Cells pour Python via Java et intégrer le classeur dans une présentation PowerPoint avec Aspose.Slides, incluant un aperçu du graphique."
---
## **Vue d'ensemble**

Cet article montre comment créer un graphique à colonnes Excel avec Aspose.Cells pour Python via Java et intégrer son classeur dans une présentation PowerPoint avec Aspose.Slides pour Python via Java. Le classeur intégré contient à la fois les données source et le graphique. Un aperçu PNG distinct affiche le graphique sur la diapositive avant que l'objet OLE ne soit activé.

Le résultat est un objet Excel intégré, et non un graphique PowerPoint natif. Modifier le classeur via OLE nécessite une application de bureau qui prend en charge l'activation OLE et une installation d'Excel compatible.

## **Prérequis**

Installez les packages Python `aspose-cells` et `aspose-slides-java` ainsi qu’un environnement d’exécution Java compatible. Importez les deux packages avant de démarrer la JVM afin que leurs bibliothèques Java soient disponibles pour JPype. Microsoft Office n’est pas requis pour générer la présentation avec ces bibliothèques.

Aucun fichier d’entrée n’est nécessaire : l’exemple crée les données et le graphique en mémoire, puis écrit `OutputChart.pptx` dans le répertoire de travail actuel. Appliquez les licences pour les deux produits lors de l'exécution en dehors du mode d’évaluation.

## **Comment l’intégration fonctionne**

1. Créez un classeur avec une feuille de données et une feuille de graphique.
1. Activez la feuille de graphique afin que le classeur s’ouvre sur le graphique.
1. Définissez la plage d’affichage OLE du classeur et rendez le graphique au format PNG.
1. Enregistrez le classeur au format XLSX en mémoire et intégrez ces octets dans une diapositive.
1. Attribuez le PNG comme aperçu de l’objet OLE et enregistrez la présentation au format PPTX.

La plage d’affichage du classeur et le cadre sur la diapositive ont des rôles différents. [setOleSize](https://reference.aspose.com/cells/python-java/asposecells.api/worksheetcollection/#setolesize) prend des indices de ligne et de colonne de début/fin basés sur zéro. [ChartCollection.add](https://reference.aspose.com/cells/python-java/asposecells.api/chartcollection/#add) prend à la place la ligne supérieure, la colonne gauche, la ligne inférieure et la colonne droite. L’exemple utilise l’indice de ligne 55 et l’indice de colonne 25 comme limites inférieure droite ; ces valeurs sont des choix de mise en page, et non le nombre de lignes ou de colonnes de données.

Le cadre de la diapositive utilise des points. L’exemple l’ajuste à l’intérieur de la diapositive et le centre tout en conservant le rapport d’aspect du PNG, plutôt que d’étirer l’aperçu pour remplir la diapositive.

## **Créer et intégrer le graphique**

L’exemple complet suivant remplit `DataSheet` avec quatre lignes et cinq colonnes de valeurs. Chaque ligne devient une série de graphique. `ChartSheet` est sélectionnée comme feuille active avant que le classeur ne soit enregistré.

Le classeur est explicitement enregistré au format XLSX, correspondant à l’extension `xlsx` transmise à [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-java/aspose.slides/oleembeddeddatainfo/). Les flux de tableaux d’octets Java conservent le classeur et l’image en mémoire et fournissent les tableaux d’octets requis par les API Java. Le PNG est chargé directement à partir de ses octets sans conversion intermédiaire en bitmap. L’affecter via [getSubstitutePictureFormat](https://reference.aspose.com/slides/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) remplace l’espace réservé OLE par défaut.

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ChartType, SheetType, ImageOrPrintOptions, ImageType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import Images, OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

workbook = Workbook()
try:
    data_sheet = workbook.getWorksheets().get(0)
    data_sheet.setName("DataSheet")

    values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25],
    ]
    for row, row_values in enumerate(values):
        for column, value in enumerate(row_values):
            data_sheet.getCells().get(row, column).putValue(jpype.JInt(value))

    chart_sheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(chart_sheet_index)
    chart_sheet.setName("ChartSheet")

    last_chart_row = 55
    last_chart_column = 25
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
    chart = chart_sheet.getCharts().get(chart_index)
    for row in range(1, len(values) + 1):
        chart.getNSeries().add(f"DataSheet!A{row}:E{row}", False)

    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    workbook.getWorksheets().setOleSize(0, last_chart_row, 0, last_chart_column)

    # Rendre l'aperçu du graphique et sérialiser le classeur modifiable séparément.
    image_options = ImageOrPrintOptions()
    image_options.setImageType(ImageType.PNG)
    chart_image_stream = ByteArrayOutputStream()
    chart.toImage(chart_image_stream, image_options)
    chart_image_bytes = chart_image_stream.toByteArray()

    workbook_stream = ByteArrayOutputStream()
    workbook.save(workbook_stream, CellsSaveFormat.XLSX)
    workbook_bytes = workbook_stream.toByteArray()

    chart_image = Images.fromData(chart_image_bytes)
    try:
        presentation = Presentation()
        try:
            slide = presentation.getSlides().get_Item(0)
            slide_width = presentation.getSlideSize().getSize().getWidth()
            slide_height = presentation.getSlideSize().getSize().getHeight()

            # Ajuster l'aperçu à l'intérieur de la diapositive sans modifier son rapport d'aspect.
            scale = min(slide_width / chart_image.getWidth(), slide_height / chart_image.getHeight())
            frame_width = chart_image.getWidth() * scale
            frame_height = chart_image.getHeight() * scale
            frame_x = (slide_width - frame_width) / 2
            frame_y = (slide_height - frame_height) / 2

            embedded_data = OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.getShapes().addOleObjectFrame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.getImages().addImage(chart_image)
            ole_frame.getSubstitutePictureFormat().getPicture().setImage(preview_image)

            presentation.save("OutputChart.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        chart_image.dispose()
finally:
    workbook.dispose()
```

## **Résultat attendu**

`OutputChart.pptx` contient une diapositive avec un classeur Excel intégré et un aperçu du graphique. Le classeur contient les données originales et un graphique à colonnes avec quatre séries. L’aperçu est centré sur la diapositive et conserve ses proportions.

![Graphique à colonnes Excel affiché comme aperçu d’un classeur intégré](excel-chart-ole-preview.png)

Dans un environnement PowerPoint de bureau compatible avec Excel disponible, double-cliquez sur l’objet pour activer et modifier le classeur intégré. L’activation et la modification dépendent de la prise en charge OLE de l’application hôte et des paramètres de sécurité.

## **FAQ**

**Pourquoi une image d'aperçu est-elle nécessaire ?**

Le classeur intégré et son aperçu de diapositive sont des contenus séparés. Fournissez une image du graphique afin que la diapositive affiche le graphique au lieu de l’espace réservé par défaut "EMBEDDED OLE OBJECT". Voir [Problème d'aperçu d'objet lors de l'ajout d'OleObjectFrame](/slides/fr/python-java/object-preview-issue-when-adding-oleobjectframe/).

**L'aperçu se met-il à jour automatiquement lorsqu'on modifie le classeur dans le code ?**

Considérez l’aperçu comme un instantané. Lors de la mise à jour des données du classeur par programmation, régénérez l’image du graphique et remplacez l’aperçu ainsi que les données du classeur intégré.

**Puis-je utiliser XLS au lieu de XLSX ?**

Oui. Enregistrez le classeur au format XLS et utilisez `xls` comme extension des données intégrées. L’extension doit correspondre au format réel du classeur ; modifier uniquement l’extension ne convertit pas les données.

**Pourquoi l'objet pourrait-il changer de taille après l'activation ?**

L'application hôte peut mettre à jour la présentation de l'objet OLE lorsqu'elle active le classeur. La plage d'affichage OLE du classeur et les dimensions du cadre de la diapositive sont toutes deux importantes. Voir [Solution fonctionnelle pour le redimensionnement de graphique dans PPTX](/slides/fr/python-java/working-solution-for-chart-resizing-in-pptx/).

## **Sections associées**

- [Solution fonctionnelle pour le redimensionnement de graphique dans PPTX](/slides/fr/python-java/working-solution-for-chart-resizing-in-pptx/)
- [Problème d'aperçu d'objet lors de l'ajout d'OleObjectFrame](/slides/fr/python-java/object-preview-issue-when-adding-oleobjectframe/)