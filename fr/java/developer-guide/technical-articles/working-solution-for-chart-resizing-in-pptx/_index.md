---
title: Solution fonctionnelle pour le redimensionnement des graphiques dans PPTX
type: docs
weight: 40
url: /fr/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- redimensionnement de graphique
- graphique Excel
- objet OLE
- intégrer le graphique
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Corrige le redimensionnement inattendu des graphiques dans les fichiers PPTX lors de l’utilisation d’objets OLE Excel intégrés avec Aspose.Slides pour Java. Découvrez deux méthodes avec code pour maintenir des tailles cohérentes."
---

## **Contexte**

Il a été observé que les graphiques Excel incorporés en tant qu’objets OLE dans une présentation PowerPoint via les composants Aspose sont redimensionnés à une échelle non spécifiée après leur première activation. Ce comportement crée une différence visuelle notable dans la présentation entre les états avant et après l’activation du graphique. L’équipe Aspose a étudié le problème en détail et a trouvé une solution. Cet article décrit les causes du problème et la correction correspondante.

Dans l’[article précédent](/slides/fr/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), nous avons expliqué comment créer un graphique Excel avec Aspose.Cells for Java et l’incorporer dans une présentation PowerPoint à l’aide d’Aspose.Slides for Java. Pour résoudre le [problème d’aperçu d’objet](/slides/fr/java/object-preview-issue-when-adding-oleobjectframe/), nous avons affecté l’image du graphique à la trame d’objet OLE du graphique. Dans la présentation résultante, lorsque vous double‑cliquez sur la trame d’objet OLE affichant l’image du graphique, le graphique Excel est activé. Les utilisateurs peuvent alors apporter toutes les modifications souhaitées au classeur Excel sous‑jacent et revenir à la diapositive correspondante en cliquant en dehors du classeur activé. La taille de la trame d’objet OLE change lorsque l’utilisateur revient à la diapositive, et le facteur de redimensionnement varie selon les tailles d’origine de la trame d’objet OLE et du classeur Excel incorporé.

## **Cause du redimensionnement**

Comme le classeur Excel possède sa propre taille de fenêtre, il essaie de conserver cette taille lors de sa première activation. La trame d’objet OLE, en revanche, a sa propre taille. Selon Microsoft, lorsque le classeur Excel est activé, Excel et PowerPoint négocient la taille et maintiennent les proportions correctes dans le cadre du processus d’incorporation. Selon les différences entre la taille de la fenêtre Excel et la taille ou la position de la trame d’objet OLE, un redimensionnement se produit.

## **Solution fonctionnelle**

Il existe deux scénarios possibles pour créer des présentations PowerPoint avec Aspose.Slides for Java.

**Scénario 1 :** Créer une présentation à partir d’un modèle existant.

**Scénario 2 :** Créer une présentation à partir de zéro.

La solution que nous présentons s’applique aux deux scénarios. Le principe de toutes les approches est le même : **la taille de la fenêtre de l’objet OLE incorporé doit correspondre à la taille de la trame d’objet OLE dans la diapositive PowerPoint**. Nous aborderons maintenant les deux approches de cette solution.

## **Première approche**

Dans cette approche, nous apprendrons comment définir la taille de la fenêtre du classeur Excel incorporé afin qu’elle corresponde à la taille de la trame d’objet OLE dans la diapositive PowerPoint.

**Scénario 1**

Supposons que nous ayons défini un modèle et que nous souhaitions créer des présentations à partir de celui‑ci. Imaginons qu’il y ait une forme à l’index 2 du modèle où nous voulons placer une trame OLE contenant un classeur Excel incorporé. Dans ce scénario, la taille de la trame d’objet OLE est prédéfinie : elle correspond à la taille de la forme à l’index 2 du modèle. Il suffit alors d’ajuster la taille de la fenêtre du classeur pour qu’elle soit égale à celle de la forme. Le fragment de code suivant sert à cet usage :
```java
// Définir la largeur de la fenêtre du classeur en pouces (divisé par 576 car PowerPoint utilise 576 pixels par pouce).
workbook.getSettings().setWindowWidthInch(slide.getShapes().get_Item(2).getWidth() / 72f);
 
// Définir la hauteur de la fenêtre du classeur en pouces.
workbook.getSettings().setWindowHeightInch(slide.getShapes().get_Item(2).getHeight() / 72f);
 
// Enregistrer le classeur dans un flux mémoire.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Créer une trame d'objet OLE avec les données Excel intégrées.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```


**Scénario 2**

Imaginons que nous voulions créer une présentation à partir de zéro et inclure une trame d’objet OLE de n’importe quelle taille avec un classeur Excel incorporé. Dans le fragment de code suivant, nous créons une trame d’objet OLE de 4 po de hauteur et 9,5 po de largeur, placée à x = 0,5 po et y = 1 po sur la diapositive. Nous fixons ensuite la fenêtre du classeur Excel à la même taille : 4 po de hauteur et 9,5 po de largeur.
```java
// Notre hauteur souhaitée.
int desiredHeight = 288; // 4 pouces (4 * 72)
 
// Notre largeur souhaitée.
int desiredWidth = 684; // 9,5 pouces (9.5 * 72)
 
// Définir la taille du graphique avec une fenêtre.
chart.setSizeWithWindow(true);
 
// Définir la largeur de la fenêtre du classeur en pouces (divisé par 576 car PowerPoint utilise 576 pixels par pouce).
workbook.getSettings().setWindowWidthInch(desiredHeight / 72f);
 
// Définir la hauteur de la fenêtre du classeur en pouces.
workbook.getSettings().setWindowHeightInch(desiredWidth / 72f);
 
// Enregistrer le classeur dans un flux mémoire.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Créer une trame d'objet OLE avec les données Excel intégrées.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    288,
    576,
    desiredWidth,
    desiredHeight,
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```


## **Deuxième approche**

Dans cette approche, nous apprendrons comment définir la taille du graphique dans le classeur Excel incorporé pour qu’elle corresponde à la taille de la trame d’objet OLE dans la diapositive PowerPoint. Cette méthode est utile lorsque la taille du graphique est connue à l’avance et ne changera jamais.

**Scénario 1**

Supposons que nous ayons défini un modèle et que nous voulions créer des présentations à partir de celui‑ci. Imaginons qu’il y ait une forme à l’index 2 du modèle où nous prévoyons de placer une trame OLE contenant un classeur Excel incorporé. Dans ce scénario, la taille de la trame OLE est prédéfinie : elle correspond à la taille de la forme à l’index 2 du modèle. Il suffit alors de régler la taille du graphique dans le classeur pour qu’elle soit égale à celle de la forme. Le fragment de code suivant sert à cet usage :
```java
// Définir la taille du graphique sans fenêtre.
chart.setSizeWithWindow(false);
 
// Définir la largeur du graphique en pixels (multiplier par 96 car Excel utilise 96 pixels par pouce).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 72f) * 96f));
 
// Définir la hauteur du graphique en pixels.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 72f) * 96f));
 
// Définir la taille d’impression du graphique.
chart.setPrintSize(PrintSizeType.CUSTOM);
 
// Enregistrer le classeur dans un flux mémoire.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Créer une trame d’objet OLE avec les données Excel intégrées.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```


**Scénario 2**:

Imaginons que nous voulions créer une présentation à partir de zéro et inclure une trame d’objet OLE de n’importe quelle taille avec un classeur Excel incorporé. Dans le fragment de code suivant, nous créons une trame d’objet OLE d’une hauteur de 4 po et d’une largeur de 9,5 po, placée à x = 0,5 po et y = 1 po sur la diapositive. Nous fixons également la taille du graphique correspondant aux mêmes dimensions : une hauteur de 4 po et une largeur de 9,5 po.
```java
// Notre hauteur souhaitée.
int desiredHeight = 288; // 4 pouces (4 * 72)
 
// Notre largeur souhaitée.
int desiredWidth = 684; // 9,5 pouces (9.5 * 72)
 
// Définir la taille du graphique sans fenêtre.
chart.setSizeWithWindow(false);
 
// Définir la largeur du graphique en pixels (multiplier par 96 car Excel utilise 96 pixels par pouce).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 576f) * 96f));
 
// Définir la hauteur du graphique en pixels.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 576f) * 96f));
 
// Enregistrer le classeur dans un flux mémoire.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Créer une trame d'objet OLE avec les données Excel intégrées.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    288,
    576,
    desiredWidth,
    desiredHeight,
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```


## **Conclusion**

Il existe deux approches pour résoudre le problème de redimensionnement du graphique. Le choix de l’approche dépend des exigences et du cas d’utilisation. Les deux approches fonctionnent de la même manière, que les présentations soient créées à partir d’un modèle ou à partir de zéro. De plus, aucune limite n’est imposée à la taille de la trame d’objet OLE dans cette solution.

## **FAQ**

**Pourquoi mon graphique Excel incorporé change‑t‑il de taille après son activation dans PowerPoint ?**

Cela se produit parce qu’Excel tente de restaurer la taille de fenêtre originale lors de la première activation, alors que la trame d’objet OLE dans PowerPoint possède ses propres dimensions. PowerPoint et Excel négocient la taille pour maintenir le rapport d’aspect, ce qui peut entraîner le redimensionnement.

**Est‑il possible d’éliminer complètement ce problème de redimensionnement ?**

Oui. En faisant correspondre la taille de la fenêtre du classeur Excel ou la taille du graphique à celle de la trame d’objet OLE avant l’incorporation, vous pouvez conserver des tailles de graphique cohérentes.

**Quelle approche devrais‑je choisir, définir la taille de la fenêtre du classeur ou celle du graphique ?**

Utilisez **l’Approche 1 (taille de la fenêtre)** si vous souhaitez conserver le rapport d’aspect du classeur et éventuellement permettre un redimensionnement ultérieur.  
Utilisez **l’Approche 2 (taille du graphique)** si les dimensions du graphique sont fixes et ne changeront pas après l’incorporation.

**Ces méthodes fonctionneront‑elles avec des présentations basées sur un modèle et avec des présentations nouvelles ?**

Oui. Les deux approches fonctionnent de la même façon pour les présentations créées à partir de modèles et pour celles créées à partir de zéro.

**Existe‑t‑il une limite à la taille de la trame d’objet OLE ?**

Non. Vous pouvez définir la trame OLE à n’importe quelle taille, tant qu’elle s’ajuste correctement à la taille du classeur ou du graphique.

**Puis‑je appliquer ces méthodes à des graphiques créés dans d’autres programmes de tableur ?**

Les exemples sont conçus pour des graphiques Excel créés avec Aspose.Cells, mais les principes s’appliquent à d’autres programmes de tableur compatibles OLE, à condition qu’ils offrent des options de taille similaires.

## **Sections associées**

- [Créer des graphiques Excel et les incorporer en tant qu’objets OLE dans des présentations](/slides/fr/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [Mettre à jour les objets OLE automatiquement à l’aide d’un complément PowerPoint](/slides/fr/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)