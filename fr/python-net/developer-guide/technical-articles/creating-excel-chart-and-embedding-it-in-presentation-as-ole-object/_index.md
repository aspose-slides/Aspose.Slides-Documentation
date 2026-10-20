---
title: "Créer des graphiques Excel et les intégrer dans des présentations en tant qu'objets OLE"
type: docs
weight: 50
url: /fr/python-net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- graphique Excel
- intégrer le graphique
- objet OLE
- PowerPoint
- présentation
- Python
- Python via .NET
- Aspose.Slides
description: "Créer un graphique Excel avec Aspose.Cells pour Python via .NET et intégrer le classeur dans une présentation PowerPoint avec Aspose.Slides, incluant un aperçu du graphique."
---
## **Vue d'ensemble**

Cet article montre comment créer un diagramme à colonnes Excel avec Aspose.Cells for Python via .NET et intégrer son classeur dans une présentation PowerPoint avec Aspose.Slides for Python via .NET. Le classeur intégré contient à la fois les données source et le diagramme. Un aperçu PNG séparé affiche le diagramme sur la diapositive avant que l'objet OLE ne soit activé.

Le résultat est un objet Excel intégré, pas un diagramme PowerPoint natif. Modifier le classeur via OLE nécessite une application de bureau qui prend en charge l'activation OLE et une installation Excel compatible.

## **Prérequis**

Installez les packages `aspose-cells-python` et `aspose-slides` dans votre environnement Python. Microsoft Office n’est pas requis pour générer la présentation avec ces bibliothèques.

Aucun fichier d’entrée n’est requis : l’exemple crée les données et le diagramme en mémoire, puis écrit `OutputChart.pptx` dans le répertoire de travail actuel. Appliquez les licences des deux produits lors de l’exécution hors mode d’évaluation.

## **Comment l'intégration fonctionne**

1. Créer un classeur avec une feuille de données et une feuille de diagramme.  
2. Rendre la feuille de diagramme active afin que le classeur s’ouvre sur le diagramme.  
3. Définir la plage d’affichage OLE du classeur et rendre le diagramme en PNG.  
4. Enregistrer le classeur au format XLSX en mémoire et intégrer ces octets dans une diapositive.  
5. Attribuer le PNG comme aperçu de l’objet OLE et enregistrer la présentation au format PPTX.

La plage d’affichage du classeur et le cadre sur la diapositive ont des rôles différents. [set_ole_size](https://reference.aspose.com/cells/python-net/aspose.cells/worksheetcollection/set_ole_size/) accepte des indices de lignes et colonnes de début/fin basés sur zéro. [ChartCollection.add](https://reference.aspose.com/cells/python-net/aspose.cells.charts/chartcollection/add/) accepte plutôt la ligne supérieure, la colonne gauche, la ligne inférieure et la colonne droite. L’exemple utilise l’indice de ligne 55 et l’indice de colonne 25 comme limites inférieure droite ; ces valeurs sont des choix de mise en page, pas le nombre de lignes ou colonnes de données.

Le cadre de la diapositive utilise des points. L’exemple l’ajuste à l’intérieur de la diapositive et le centre tout en préservant le ratio d’aspect du PNG, plutôt que d’étirer l’aperçu pour remplir la diapositive.

## **Créer et intégrer le diagramme**

L’exemple complet suivant remplit `DataSheet` avec quatre lignes et cinq colonnes de valeurs. Chaque ligne devient une série du diagramme. `ChartSheet` est sélectionnée comme feuille active avant que le classeur ne soit enregistré.

Le classeur est explicitement enregistré au format XLSX, correspondant à l’extension `xlsx` passée à [OleEmbeddedDataInfo](https://reference.aspose.com/slides/python-net/aspose.slides.dom.ole/oleembeddeddatainfo/). Le PNG est chargé directement depuis son flux sans conversion bitmap intermédiaire. L’attribuer via [substitute_picture_format](https://reference.aspose.com/slides/python-net/aspose.slides/ioleobjectframe/substitute_picture_format/) remplace le substitut OLE par défaut.

```python
import io
import aspose.cells as cells
import aspose.cells.charts as charts
import aspose.cells.drawing as drawing
import aspose.slides as slides

workbook = cells.Workbook()
data_sheet = workbook.worksheets[0]
data_sheet.name = "DataSheet"

values = [
    [67, 44, 46, 43, 24],
    [86, 64, 97, 29, 40],
    [68, 89, 78, 69, 38],
    [91, 48, 60, 26, 25],
]

for row, row_values in enumerate(values):
    for column, value in enumerate(row_values):
        data_sheet.cells.get(row, column).put_value(value)

chart_sheet_index = workbook.worksheets.add(cells.SheetType.CHART)
chart_sheet = workbook.worksheets[chart_sheet_index]
chart_sheet.name = "ChartSheet"

last_chart_row = 55
last_chart_column = 25
chart_index = chart_sheet.charts.add(charts.ChartType.COLUMN, 0, 0, last_chart_row, last_chart_column)
chart = chart_sheet.charts[chart_index]
for row in range(1, len(values) + 1):
    chart.n_series.add(f"DataSheet!A{row}:E{row}", False)

workbook.worksheets.active_sheet_index = chart_sheet_index
workbook.worksheets.set_ole_size(0, last_chart_row, 0, last_chart_column)

# Rendre l'aperçu du graphique et sérialiser le classeur modifiable séparément.
with io.BytesIO() as chart_image_stream, io.BytesIO() as workbook_stream:
    chart.to_image(chart_image_stream, drawing.ImageType.PNG)
    chart_image_stream.seek(0)
    workbook.save(workbook_stream, cells.SaveFormat.XLSX)
    workbook_bytes = workbook_stream.getvalue()

    with slides.Images.from_stream(chart_image_stream) as chart_image:
        with slides.Presentation() as presentation:
            slide = presentation.slides[0]
            slide_size = presentation.slide_size.size

            # Adapter l'aperçu à la diapositive sans modifier son ratio d'aspect.
            scale = min(slide_size.width / chart_image.width, slide_size.height / chart_image.height)
            frame_width = chart_image.width * scale
            frame_height = chart_image.height * scale
            frame_x = (slide_size.width - frame_width) / 2
            frame_y = (slide_size.height - frame_height) / 2

            embedded_data = slides.dom.ole.OleEmbeddedDataInfo(workbook_bytes, "xlsx")
            ole_frame = slide.shapes.add_ole_object_frame(frame_x, frame_y, frame_width, frame_height, embedded_data)
            preview_image = presentation.images.add_image(chart_image)
            ole_frame.substitute_picture_format.picture.image = preview_image

            presentation.save("OutputChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Résultat attendu**

`OutputChart.pptx` contient une diapositive avec un classeur Excel intégré et un aperçu du diagramme. Le classeur contient les données originales et un diagramme à colonnes avec quatre séries. L’aperçu est centré sur la diapositive et conserve ses proportions.

![Diagramme à colonnes Excel affiché comme aperçu d’un classeur intégré](excel-chart-ole-preview.png)

Dans un environnement PowerPoint de bureau compatible avec Excel, double‑cliquez sur l’objet pour activer et modifier le classeur intégré. L’activation et la modification dépendent de la prise en charge OLE de l’application hôte et des paramètres de sécurité.

## **FAQ**

**Pourquoi une image d’aperçu est‑elle nécessaire ?**  
Le classeur intégré et son aperçu de diapositive sont du contenu distinct. Fournissez une image du diagramme afin que la diapositive affiche le diagramme au lieu de l’espace réservé « EMBEDDED OLE OBJECT ». Voir [Problème d'aperçu d'objet lors de l'ajout d'OleObjectFrame](/slides/fr/python-net/object-preview-issue-when-adding-oleobjectframe/).

**L’aperçu se met‑il à jour automatiquement lorsque je modifie le classeur dans le code ?**  
Considérez l’aperçu comme une capture instantanée. Lors de la mise à jour des données du classeur par programme, régénérez l’image du diagramme et remplacez l’aperçu ainsi que les données du classeur intégré.

**Puis‑je utiliser XLS au lieu de XLSX ?**  
Oui. Enregistrez le classeur au format XLS et utilisez `xls` comme extension des données intégrées. L’extension doit correspondre au format réel du classeur ; changer uniquement l’extension ne convertit pas les données.

**Pourquoi l’objet peut‑il changer de taille après activation ?**  
L’application hôte peut mettre à jour la présentation de l’objet OLE lorsqu’elle active le classeur. La plage d’affichage OLE du classeur et les dimensions du cadre de la diapositive sont toutes deux importantes. Voir [Redimensionner automatiquement les objets OLE dans les présentations PowerPoint](/slides/fr/python-net/working-solution-for-worksheet-resizing/).

## **Sections connexes**

- [Redimensionner automatiquement les objets OLE dans les présentations PowerPoint](/slides/fr/python-net/working-solution-for-worksheet-resizing/)
- [Problème d'aperçu d'objet lors de l'ajout d'OleObjectFrame](/slides/fr/python-net/object-preview-issue-when-adding-oleobjectframe/)
- [Gérer les objets OLE](/slides/fr/python-net/manage-ole/)