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
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Créez des graphiques Excel et intégrez-les en tant qu'objets OLE dans des présentations PowerPoint et OpenDocument avec Python. Guide étape par étape avec des exemples de code."
---
## **Contexte**

Dans PowerPoint, l'utilisation de graphiques modifiables pour afficher les données graphiquement est une pratique courante. Aspose prend en charge la création de graphiques Excel avec Aspose.Cells for Python via Java, et ces graphiques peuvent ensuite être incorporés en tant qu'objets OLE dans les diapositives PowerPoint via Aspose.Slides for Python via Java. Cet article décrit les étapes nécessaires et fournit un exemple de code Python pour créer un graphique Excel et l'incorporer en tant qu'objet OLE dans une présentation PowerPoint en utilisant Aspose.Cells et Aspose.Slides.

## **Étapes requises**

La séquence d'étapes suivante est requise pour créer et incorporer un graphique Excel en tant qu'objet OLE dans une diapositive PowerPoint :

1. Créer un graphique Excel en utilisant Aspose.Cells.
1. Définir la taille OLE du graphique Excel en utilisant Aspose.Cells.
1. Obtenir une image du graphique Excel avec Aspose.Cells.
1. Incorporer le graphique Excel en tant qu'objet OLE dans une présentation PPTX en utilisant Aspose.Slides.
1. Remplacer l'image "EMBEDDED OLE OBJECT" par l'image obtenue à l'étape 3 pour résoudre le [problème d'aperçu d'objet](/slides/fr/python-java/object-preview-issue-when-adding-oleobjectframe/).
1. Enregistrer la présentation sur le disque au format PPTX.

## **Mise en œuvre des étapes requises**

L'implémentation en Python des étapes ci‑au-dessus est la suivante :

```python
import jpype
import asposecells
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposecells.api import Workbook, ChartType, SheetType, ImageOrPrintOptions, ImageType
from asposecells.api import SaveFormat as CellsSaveFormat
from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")


def add_excel_chart_in_workbook(workbook, chart_rows, chart_columns):
    # Un tableau de noms de cellules.
    cell_names = [
        "A1", "A2", "A3", "A4",
        "B1", "B2", "B3", "B4",
        "C1", "C2", "C3", "C4",
        "D1", "D2", "D3", "D4",
        "E1", "E2", "E3", "E4",
    ]

    # Un tableau de valeurs de cellules.
    cell_values = [
        67, 86, 68, 91,
        44, 64, 89, 48,
        46, 97, 78, 60,
        43, 29, 69, 26,
        24, 40, 38, 25,
    ]

    # Ajouter une nouvelle feuille de calcul pour remplir les cellules avec des données.
    data_sheet_index = workbook.getWorksheets().add()
    data_sheet = workbook.getWorksheets().get(data_sheet_index)
    sheet_name = "DataSheet"
    data_sheet.setName(sheet_name)

    # Remplir la feuille de données avec les valeurs.
    for cell_name, cell_value in zip(cell_names, cell_values):
        data_sheet.getCells().get(cell_name).setValue(jpype.JInt(cell_value))

    # Ajouter une feuille de graphique.
    worksheet_index = workbook.getWorksheets().add(SheetType.CHART)
    chart_sheet = workbook.getWorksheets().get(worksheet_index)
    chart_sheet.setName("ChartSheet")
    chart_sheet_index = chart_sheet.getIndex()

    # Ajouter un graphique à la feuille de graphique avec des séries de données provenant de la feuille de données.
    chart_index = chart_sheet.getCharts().add(ChartType.COLUMN, 0, chart_rows, 0, chart_columns)
    chart = chart_sheet.getCharts().get(chart_index)
    chart.getNSeries().add(sheet_name + "!A1:E1", False)
    chart.getNSeries().add(sheet_name + "!A2:E2", False)
    chart.getNSeries().add(sheet_name + "!A3:E3", False)
    chart.getNSeries().add(sheet_name + "!A4:E4", False)

    # Définir la feuille de graphique comme feuille active.
    workbook.getWorksheets().setActiveSheetIndex(chart_sheet_index)
    return chart_sheet_index


def add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image):
    ole_height = jpype.JFloat(presentation.getSlideSize().getSize().getHeight())
    ole_width = jpype.JFloat(presentation.getSlideSize().getSize().getWidth())

    # Décrire le classeur comme données OLE intégrées.
    data_info = OleEmbeddedDataInfo(workbook_data, "xls")
    ole_frame = slide.getShapes().addOleObjectFrame(0.0, 0.0, ole_width, ole_height, data_info)
    image = presentation.getImages().addImage(chart_image)
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(image)


# Créer un classeur.
workbook = Workbook()

# Ajouter un graphique Excel.
chart_rows = 55
chart_columns = 25
chart_sheet_index = add_excel_chart_in_workbook(workbook, chart_rows, chart_columns)

# Définir la taille OLE du graphique.
workbook.getWorksheets().setOleSize(0, chart_rows, 0, chart_columns)

# Obtenir l'image du graphique et l'enregistrer dans un flux.
print_options = ImageOrPrintOptions()
print_options.setImageType(ImageType.PNG)
image_stream = ByteArrayOutputStream()
workbook.getWorksheets().get(chart_sheet_index).getCharts().get(0).toImage(image_stream, print_options)
chart_image = image_stream.toByteArray()

# Enregistrer le classeur dans un flux.
workbook_stream = ByteArrayOutputStream()
workbook.save(workbook_stream, CellsSaveFormat.EXCEL_97_TO_2003)
workbook_data = workbook_stream.toByteArray()

# Créer une présentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Ajouter le classeur à une diapositive.
    add_excel_chart_in_presentation(presentation, slide, workbook_data, chart_image)

    # Enregistrer la présentation sur le disque.
    presentation.save("OutputChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La présentation créée par la méthode ci‑dessus contiendra le graphique Excel en tant qu'objet OLE qui peut être activé en double‑cliquant le cadre de l'objet OLE.

## **Conclusion**

En utilisant Aspose.Cells for Python via Java conjointement avec Aspose.Slides for Python via Java, nous pouvons créer n'importe quel graphique Excel pris en charge par Aspose.Cells et l'incorporer en tant qu'objet OLE dans une diapositive PowerPoint. La taille OLE du graphique Excel peut également être définie. Les utilisateurs finaux peuvent alors modifier le graphique Excel comme tout autre objet OLE.

## **Sections connexes**

- [Solution fonctionnelle pour le redimensionnement des graphiques dans PPTX](/slides/fr/python-java/working-solution-for-chart-resizing-in-pptx/)
- [Problème d'aperçu d'objet lors de l'ajout d'OleObjectFrame](/slides/fr/python-java/object-preview-issue-when-adding-oleobjectframe/)

## **FAQ**

**Quelles bibliothèques sont utilisées pour créer et incorporer le graphique Excel ?**

Aspose.Cells for Python via Java crée le graphique Excel, et Aspose.Slides for Python via Java l'incorpore en tant qu'objet OLE dans une diapositive PowerPoint.

**Comment les utilisateurs peuvent‑ils modifier le graphique Excel incorporé ?**

Les utilisateurs peuvent double‑cliquer le cadre de l'objet OLE pour activer le graphique et le modifier comme tout autre objet OLE.

**Comment l'aperçu par défaut de l'objet OLE est‑il remplacé ?**

L'exemple obtient une image du graphique Excel avec Aspose.Cells et l'utilise pour remplacer l'image "EMBEDDED OLE OBJECT".