---
title: "Automatiser la génération PowerPoint en Python : créer facilement des présentations dynamiques"
linktitle: Automatisation de la génération PowerPoint
type: docs
weight: 20
url: /fr/python-java/automating-powerpoint-generation-on-cloud-platforms/
keywords:
- plateformes cloud
- intégration cloud
- automatiser la génération PowerPoint
- générer des présentations de manière programmatique
- automatisation PowerPoint
- création dynamique de diapositives
- rapports d'entreprise automatisés
- automatisation PPT
- présentation Python
- Python
- Aspose.Slides
description: "Automatisez la génération PowerPoint avec Aspose.Slides pour Python via Java : créez une présentation d’entreprise avec des graphiques, des tableaux et des puces dans des applications cloud."
---
## **Introduction**

Créer des présentations manuellement devient répétitif lorsque leur contenu change fréquemment. Les rapports hebdomadaires, les supports de formation et les présentations client partagent souvent une structure commune mais nécessitent de nouvelles données pour chaque diffusion.

Aspose.Slides for Python via Java vous permet de générer ces présentations à partir d’applications Python. Vous pouvez intégrer la création de diapositives dans des portails web, des tâches planifiées et des workers cloud, en utilisant des données provenant de bases de données, d’API ou de fichiers téléchargés.

## **Cas d’utilisation courants de l’automatisation PowerPoint en Python**

- **Rapports d’entreprise et tableaux de bord** : convertir les chiffres de ventes et les indicateurs de performance en graphiques et tableaux.
- **Présentations commerciales personnalisées** : remplir les diapositives avec des données spécifiques au client tout en conservant un design cohérent.
- **Contenu pédagogique** : assembler leçons, questionnaires et résumés de cours à partir de matériel structuré.
- **Informations basées sur les données et l’IA** : utiliser les résultats d’analyses ou de services de traitement du langage comme contenu de la présentation.
- **Diapositives multimédias** : combiner images ou captures d’écran téléchargées avec du texte explicatif.
- **Flux de travail documentaires** : mapper le contenu extrait par d’autres outils dans les mises en page de la présentation.
- **Outils pour développeurs** : générer des résumés de version, des aperçus techniques ou des démonstrations à partir des données du projet.

## **Pré-requis**

Suivez [Installation](/slides/fr/python-java/installation/) pour installer Python, Java, JPype et Aspose.Slides. Pour le déploiement sur le cloud, consultez également [Slides sur les plateformes cloud](/slides/fr/python-java/slides-on-cloud-platforms/).

L’exemple utilise des données d’entreprise fixes afin de pouvoir s’exécuter sans base de données ni service externe. Remplacez ces valeurs par les données de votre application lors de son intégration dans un flux de travail de rapport.

{{% alert color="info" title="Remarque" %}}
Vous pouvez essayer l’exemple sans licence, mais la sortie d’évaluation comprend un filigrane et est soumise aux restrictions d’évaluation. Consultez [Évaluer Aspose.Slides](/slides/fr/python-java/evaluate-aspose-slides/) pour plus de détails et les informations sur la licence temporaire.
{{% /alert %}}

## **Construire la présentation**

Le script complet ci‑dessus crée une présentation contenant quatre diapositives. Chaque étape utilise la même présentation, et l’étape finale l’enregistre sous le nom `presentation.pptx`.

### **Créer une diapositive de titre**

Utilisez la diapositive initiale d’une nouvelle [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) et appliquez la disposition titre. Remplissez ses espaces réservés titre et sous‑titre avec l’en‑tête du rapport et le public cible.

![La diapositive de titre](slide_0.png)

### **Ajouter une diapositive avec un graphique en colonnes**

Ajoutez une diapositive vierge et créez un graphique avec [ShapeCollection.addChart](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/#addChart). Remplissez son classeur intégré avec cinq régions et une série de ventes. Les valeurs restent modifiables dans PowerPoint.

![Diapositive avec le graphique](slide_1.png)

### **Ajouter une diapositive avec un tableau**

Créez un tableau avec [ShapeCollection.addTable](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/#addTable) et remplissez deux colonnes avec les noms de métriques et leurs valeurs. L’exemple transmet des tableaux Java explicites de doubles pour les largeurs de colonne et les hauteurs de ligne via JPype.

![Diapositive avec le tableau](slide_2.png)

### **Ajouter une diapositive de synthèse avec puces**

Créez une forme de texte et ajoutez un [Paragraph](https://reference.aspose.com/slides/fr/python-java/aspose.slides/paragraph/) pour chaque élément d’action. Appliquez une puce symbole et du texte noir à chaque paragraphe, puis supprimez le remplissage et le contour de la forme.

![Diapositive avec la synthèse](slide_3.png)

### **Enregistrer la présentation**

Utilisez [Presentation.save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save) pour écrire le fichier PowerPoint. Libérez la présentation avec [Presentation.dispose](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#dispose) dans un bloc `finally`.

### **Exemple Python complet**

Enregistrez ce script dans un répertoire accessible en écriture et exécutez‑le avec l’environnement Python configuré ci‑above. Il démarre la JVM uniquement si nécessaire et la laisse disponible jusqu’à la fin du processus. Pour l’utilisation dans un notebook ou un service, consultez [Guide du cycle de vie JVM](/slides/fr/python-java/limitations-and-api-differences/#import-the-library).

```python
import jpype
import asposeslides
from jpype.types import JArray, JDouble

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, ChartType, FillType, LegendPositionType, Paragraph, Presentation, SaveFormat, ShapeType, SlideLayoutType
from java.awt import Color


def create_bullet_paragraph(text):
    paragraph = Paragraph()
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Symbol)
    paragraph.getParagraphFormat().setIndent(15)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph.setText(text)
    return paragraph


presentation = Presentation()
try:
    # Créer la diapositive de titre.
    title_slide = presentation.getSlides().get_Item(0)
    title_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Title)
    title_slide.setLayoutSlide(title_layout)
    title_shape = title_slide.getShapes().get_Item(0)
    subtitle_shape = title_slide.getShapes().get_Item(1)
    title_shape.getTextFrame().setText("Quarterly Business Review – Q1 2025")
    subtitle_shape.getTextFrame().setText("Prepared for Executive Team")

    # Ajouter une diapositive avec un graphique.
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    chart_slide = presentation.getSlides().addEmptySlide(blank_layout)
    chart = chart_slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350, False)
    chart.getLegend().setPosition(LegendPositionType.Bottom)
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("Data from January – March 2025")
    chart.getChartTitle().setOverlay(False)

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    sales = [("North America", 480), ("Europe", 365), ("Asia Pacific", 290), ("Latin America", 150), ("Middle East", 120)]
    for row_index, (region, amount) in enumerate(sales, start=1):
        category_cell = workbook.getCell(worksheet_index, row_index, 0, region)
        chart.getChartData().getCategories().add(category_cell)

    series_cell = workbook.getCell(worksheet_index, 0, 1, "Sales ($K)")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())
    for row_index, (region, amount) in enumerate(sales, start=1):
        value_cell = workbook.getCell(worksheet_index, row_index, 1, JDouble(amount))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    # Ajouter une diapositive avec un tableau.
    table_slide = presentation.getSlides().addEmptySlide(blank_layout)
    column_widths = JArray(JDouble)([200, 100])
    row_heights = JArray(JDouble)([40, 40, 40, 40, 40])
    table = table_slide.getShapes().addTable(200, 200, column_widths, row_heights)
    metrics = [("Metric", "Value"), ("Total Revenue", "$1.4M"), ("Gross Margin", "54%"), ("New Customers", "340"), ("Customer Retention", "87%")]
    for row_index, (metric, value) in enumerate(metrics):
        table.getColumns().get_Item(0).get_Item(row_index).getTextFrame().setText(metric)
        table.getColumns().get_Item(1).get_Item(row_index).getTextFrame().setText(value)

    # Ajouter une diapositive de synthèse.
    summary_slide = presentation.getSlides().addEmptySlide(blank_layout)
    bullet_list = summary_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 50, 600, 200)
    bullet_list.getFillFormat().setFillType(FillType.NoFill)
    bullet_list.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    paragraphs = bullet_list.getTextFrame().getParagraphs()
    paragraphs.clear()
    action_items = ["Strong performance in North America; growth opportunity in Asia Pacific", "Improve marketing outreach in underperforming regions", "Prepare new campaign strategy for Q2", "Schedule follow-up review in early July"]
    for text in action_items:
        paragraph = create_bullet_paragraph(text)
        paragraphs.add(paragraph)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Les illustrations montrent les diapositives correspondantes de l’exemple Java. L’apparence peut varier selon les polices installées et le mode d’évaluation.

## **Utiliser l’exemple dans une application cloud**

Récupérez les données du rapport avant de créer la présentation, puis transmettez‑les aux étapes de création du graphique, du tableau et du texte. Utilisez un chemin de sortie distinct pour chaque tâche. Après l’enregistrement, votre application peut télécharger le fichier vers un stockage d’objets ou le renvoyer en téléchargement.

Maintenez la JVM en cours d’exécution entre les tâches au sein du même processus worker et libérez chaque présentation à la fin de son exécution. Emballez les polices requises par la conception de votre rapport avec le déploiement afin de réduire les différences entre les environnements.

## **Conclusion**

Cet exemple génère une présentation d’entreprise complète à partir de Python en utilisant des graphiques, tableaux et textes modifiables. Remplacer les données d’exemple par les données de l’application rend cette approche utile pour des rapports récurrents, des présentations client et du matériel pédagogique.

## **FAQ**

**Le script nécessite‑t‑il Microsoft PowerPoint ou Excel ?**

Non. Aspose.Slides crée les diapositives et le classeur intégré du graphique sans aucune de ces applications.

**Pourquoi l’exemple de tableau utilise‑t‑il des tableaux Java ?**

La méthode sous‑jacent accepte des tableaux de doubles Java. Les tableaux explicites clarifient les types numériques transmis via JPype.

**Puis‑je enregistrer la même présentation au format PDF ou ODP ?**

Oui. Avant de la libérer, enregistrez‑la sous un autre nom de fichier de sortie en utilisant la valeur correspondante de [SaveFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/saveformat/). Consultez [Formats de fichiers pris en charge](/slides/fr/python-java/supported-file-formats/) pour les fonctionnalités spécifiques à chaque format.

**Puis‑je utiliser un modèle de marque ?**

Oui. Chargez votre modèle au lieu de créer une présentation vide, puis adaptez la disposition et la sélection des espaces réservés à ce modèle. L’exemple suppose les dispositions et l’ordre des espaces réservés d’une nouvelle présentation par défaut.