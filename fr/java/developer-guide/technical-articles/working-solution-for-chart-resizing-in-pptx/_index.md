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
description: "Corriger le redimensionnement inattendu des graphiques dans PPTX lors de l'utilisation d'objets OLE Excel incorporés avec Aspose.Slides for Java. Découvrez deux méthodes avec du code pour garder les tailles cohérentes."
---
## **Contexte**

Il a été observé que les graphiques Excel incorporés en tant qu’objets OLE dans une présentation PowerPoint via les composants Aspose sont redimensionnés à une échelle non spécifiée après leur première activation. Ce comportement entraîne une différence visuelle notable dans la présentation entre les états avant et après activation du graphique. L’équipe Aspose a étudié le problème en détail et a trouvé une solution. Cet article décrit les causes du problème et la correction correspondante.

Dans le [article précédent](/slides/fr/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), nous avons expliqué comment créer un graphique Excel avec Aspose.Cells for Java et l’intégrer dans une présentation PowerPoint à l’aide d’Aspose.Slides for Java. Pour résoudre le [problème d’aperçu d’objet](/slides/fr/java/object-preview-issue-when-adding-oleobjectframe/), nous avons attribué l’image du graphique au cadre d’objet OLE du graphique. Dans la présentation de sortie, lorsque vous double-cliquez sur le cadre d’objet OLE affichant l’image du graphique, le graphique Excel est activé. Les utilisateurs finaux peuvent apporter les modifications souhaitées dans le classeur Excel sous‑jacent, puis revenir à la diapositive correspondante en cliquant en dehors du classeur activé. La taille du cadre d’objet OLE change lorsque l’utilisateur revient à la diapositive, et le facteur de redimensionnement varie en fonction des tailles d’origine du cadre d’objet OLE et du classeur Excel incorporé.

## **Cause du redimensionnement**

Comme le classeur Excel possède sa propre taille de fenêtre, il tente de conserver sa taille originale lors de sa première activation. Le cadre d’objet OLE, en revanche, a sa propre taille. Selon Microsoft, lorsque le classeur Excel est activé, Excel et PowerPoint négocient la taille et maintiennent les proportions correctes dans le cadre du processus d’incorporation. Selon les différences entre la taille de la fenêtre Excel et la taille ou la position du cadre d’objet OLE, un redimensionnement se produit.

## **Solution fonctionnelle**

Il existe deux scénarios possibles pour créer des présentations PowerPoint à l’aide d’Aspose.Slides for Java.

**Scénario 1 :** Créer une présentation à partir d’un modèle existant.

**Scénario 2 :** Créer une présentation à partir de zéro.

La solution que nous proposons s’applique aux deux scénarios. Le principe de toutes les approches de solution est le même : **la taille de la fenêtre de l’objet OLE incorporé doit correspondre au cadre d’objet OLE dans la diapositive PowerPoint**. Nous allons maintenant examiner les deux approches de cette solution.

## **Première approche**

Dans cette approche, nous apprendrons comment définir la taille de la fenêtre du classeur Excel incorporé afin qu’elle corresponde à la taille du cadre d’objet OLE dans la diapositive PowerPoint.

**Scénario 1**

Supposons que nous ayons défini un modèle et que nous voulions créer des présentations à partir de celui‑ci. Imaginons qu’il y ait une forme à l’index 2 dans le modèle où nous souhaitons placer un cadre OLE contenant un classeur Excel incorporé. Dans ce scénario, la taille du cadre d’objet OLE est prédéfinie — elle correspond à la taille de la forme à l’index 2 du modèle. Tout ce que nous devons faire est d’ajuster la taille de la fenêtre du classeur pour qu’elle soit égale à celle de cette forme. Le fragment de code suivant réalise cela :

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Définir la largeur de la fenêtre du classeur en pouces (divisée par 72 car PowerPoint utilise 72 points par pouce).
workbook.getSettings().setWindowWidthInch(slide.getShapes().get_Item(2).getWidth() / 72f);
 
// Définir la hauteur de la fenêtre du classeur en pouces.
workbook.getSettings().setWindowHeightInch(slide.getShapes().get_Item(2).getHeight() / 72f);
 
// Enregistrer le classeur dans un flux mémoire.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Créer un cadre d'objet OLE avec les données Excel incorporées.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    dataInfo);
```

**Scénario 2**

Imaginons que nous voulions créer une présentation à partir de zéro et inclure un cadre d’objet OLE de n’importe quelle taille avec un classeur Excel incorporé. Dans le fragment de code suivant, nous créons un cadre d’objet OLE de 4 pouces de hauteur et 9,5 pouces de largeur à x = 0,5 pouce et y = 1 pouce sur la diapositive. Nous définissons ensuite la fenêtre du classeur Excel à la même taille — 4 pouces de hauteur et 9,5 pouces de largeur.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Hauteur souhaitée.
int desiredHeight = 288; // 4 pouces (4 * 72)
 
// Largeur souhaitée.
int desiredWidth = 684; // 9.5 pouces (9.5 * 72)
 
// Définir la taille du graphique avec une fenêtre.
chart.setSizeWithWindow(true);
 
// Définir la largeur de la fenêtre du classeur en pouces (divisée par 72 car PowerPoint utilise 72 points par pouce).
workbook.getSettings().setWindowWidthInch(desiredWidth / 72f);
 
// Définir la hauteur de la fenêtre du classeur en pouces.
workbook.getSettings().setWindowHeightInch(desiredHeight / 72f);
 
// Enregistrer le classeur dans un flux mémoire.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Créer un cadre d'objet OLE avec les données Excel incorporées.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    36,  // x = 0.5 pouce (0.5 * 72)
    72,  // y = 1 pouce (1 * 72)
    desiredWidth,
    desiredHeight,
    dataInfo);
```

## **Deuxième approche**

Dans cette approche, nous apprendrons comment définir la taille du graphique dans le classeur Excel incorporé afin qu’elle corresponde à la taille du cadre d’objet OLE dans la diapositive PowerPoint. Cette approche est utile lorsque la taille du graphique est connue à l’avance et ne changera jamais.

**Scénario 1**

Supposons que nous ayons défini un modèle et que nous voulions créer des présentations à partir de celui‑ci. Imaginons qu’il y ait une forme à l’index 2 dans le modèle où nous avons l’intention de placer un cadre OLE contenant un classeur Excel incorporé. Dans ce scénario, la taille du cadre OLE est prédéfinie — elle correspond à la taille de la forme à l’index 2 du modèle. Tout ce que nous devons faire est de régler la taille du graphique dans le classeur pour qu’elle soit égale à celle de la forme. Le fragment de code suivant réalise cela :

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Définir la taille du graphique sans fenêtre.
chart.setSizeWithWindow(false);
 
// Définir la largeur du graphique en pixels (multiplier par 96 car Excel utilise 96 pixels par pouce).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 72f) * 96f));
 
// Définir la hauteur du graphique en pixels.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 72f) * 96f));
 
// Définir la taille d'impression du graphique.
chart.setPrintSize(com.aspose.cells.PrintSizeType.CUSTOM);
 
// Enregistrer le classeur dans un flux mémoire.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Créer un cadre d'objet OLE avec les données Excel incorporées.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    dataInfo);
```

**Scénario 2**

Supposons que nous voulions créer une présentation à partir de zéro et inclure un cadre d’objet OLE de n’importe quelle taille avec un classeur Excel incorporé. Dans le fragment de code suivant, nous créons un cadre d’objet OLE d’une hauteur de 4 pouces et d’une largeur de 9,5 pouces sur la diapositive à x = 0,5 pouce et y = 1 pouce. Nous définissons également la taille du graphique correspondant aux mêmes dimensions : une hauteur de 4 pouces et une largeur de 9,5 pouces.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Hauteur souhaitée.
int desiredHeight = 288; // 4 pouces (4 * 72)
 
// Largeur souhaitée.
int desiredWidth = 684; // 9.5 pouces (9.5 * 72)
 
// Définir la taille du graphique sans fenêtre.
chart.setSizeWithWindow(false);
 
// Définir la largeur du graphique en pixels (divisée par 72 pour obtenir les pouces, multipliée par 96 car Excel utilise 96 pixels par pouce).
chart.getChartObject().setWidth((int)((desiredWidth / 72f) * 96f));
 
// Définir la hauteur du graphique en pixels.
chart.getChartObject().setHeight((int)((desiredHeight / 72f) * 96f));
 
// Enregistrer le classeur dans un flux mémoire.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Créer un cadre d'objet OLE avec les données Excel incorporées.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    36,  // x = 0.5 pouce (0.5 * 72)
    72,  // y = 1 pouce (1 * 72)
    desiredWidth,
    desiredHeight,
    dataInfo);
```

## **Conclusion**

Il existe deux approches pour résoudre le problème de redimensionnement du graphique. Le choix de l’approche dépend des exigences et du cas d’utilisation. Les deux approches fonctionnent de la même manière que les présentations soient créées à partir d’un modèle ou à partir de zéro. De plus, il n’y a aucune limite à la taille du cadre d’objet OLE dans cette solution.

## **FAQ**

### Pourquoi mon graphique Excel incorporé change‑t‑il de taille après son activation dans PowerPoint ?

Cela se produit parce qu’Excel tente de restaurer sa taille de fenêtre d’origine lors de la première activation, tandis que le cadre d’objet OLE dans PowerPoint possède ses propres dimensions. PowerPoint et Excel négocient la taille afin de conserver le ratio d’aspect, ce qui peut entraîner le redimensionnement.

### Est‑il possible de prévenir entièrement ce problème de redimensionnement ?

Oui. En faisant correspondre la taille de la fenêtre du classeur Excel ou la taille du graphique à la taille du cadre d’objet OLE avant l’incorporation, vous pouvez maintenir des tailles de graphique cohérentes.

### Quelle approche devrais‑je choisir, définir la taille de la fenêtre du classeur ou définir la taille du graphique ?

Utilisez **l’Approche 1 (taille de la fenêtre)** si vous souhaitez conserver le ratio d’aspect du classeur et éventuellement permettre un redimensionnement ultérieur.  
Utilisez **l’Approche 2 (taille du graphique)** si les dimensions du graphique sont fixes et ne changeront pas après l’incorporation.

### Ces méthodes fonctionneront‑elles avec les présentations basées sur un modèle ainsi que les nouvelles présentations ?

Oui. Les deux approches fonctionnent de la même façon pour les présentations créées à partir de modèles et celles créées à partir de zéro.

### Existe‑t‑il une limite à la taille du cadre d’objet OLE ?

Non. Vous pouvez définir le cadre OLE à n’importe quelle taille tant qu’il s’ajuste correctement à la taille du classeur ou du graphique.

### Puis‑je utiliser ces méthodes avec des graphiques créés dans d’autres programmes de feuilles de calcul ?

Les exemples sont conçus pour des graphiques Excel créés avec Aspose.Cells, mais les principes s’appliquent à d’autres programmes de feuilles de calcul compatibles OLE tant qu’ils offrent des options de dimensionnement similaires.

## **Sections liées**

- [Créer des graphiques Excel et les incorporer en tant qu’objets OLE dans des présentations](/slides/fr/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)