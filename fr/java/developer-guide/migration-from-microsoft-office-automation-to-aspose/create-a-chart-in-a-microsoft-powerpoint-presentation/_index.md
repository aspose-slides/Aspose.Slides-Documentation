---
title: Créer des graphiques avec VSTO et Aspose.Slides pour Java
linktitle: Créer un graphique
type: docs
weight: 70
url: /fr/java/create-a-chart-in-a-microsoft-powerpoint-presentation/
keywords:
- créer un graphique
- migration
- VSTO
- automatisation Office
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Apprenez comment automatiser la création de graphiques PowerPoint en Java. Ce guide étape par étape montre pourquoi Aspose.Slides pour Java est une alternative plus rapide et plus puissante à Microsoft.Office.Interop."
---
{{% alert color="info" %}} 

 Les graphiques sont des représentations visuelles des données très utilisées dans les présentations. Cet article montre le code pour créer un graphique dans Microsoft PowerPoint de façon programmatique en utilisant [VSTO](/slides/fr/java/create-a-chart-in-a-microsoft-powerpoint-presentation/) et [Aspose.Slides for Java](/slides/fr/java/create-a-chart-in-a-microsoft-powerpoint-presentation/).

{{% /alert %}} 
## **Créer un graphique**
Les exemples de code ci‑dessous décrivent le processus d’ajout d’un simple graphique à colonnes groupées 3D en utilisant VSTO. Vous créez une instance de présentation, ajoutez‑y un graphique par défaut, puis utilisez un classeur Microsoft Excel pour accéder et modifier les données du graphique ainsi que définir ses propriétés. Enfin, vous enregistrez la présentation.
### **Exemple VSTO**
Avec VSTO, les étapes suivantes sont effectuées :

1. Créer une instance d’une présentation Microsoft PowerPoint.  
1. Ajouter une diapositive vierge à la présentation.  
1. Ajouter un graphique **3D clustered column** et y accéder.  
1. Créer une nouvelle instance de classeur Microsoft Excel et charger les données du graphique.  
1. Accéder à la feuille de données du graphique à l’aide de l’instance de classeur Microsoft Excel `fromworkbook`.  
1. Définir la plage du graphique dans la feuille et supprimer les séries 2 et 3 du graphique.  
1. Modifier les données de catégorie du graphique dans la feuille de données.  
1. Modifier les données de la série 1 du graphique dans la feuille de données.  
1. Accéder maintenant au titre du graphique et définir les propriétés de police associées.  
1. Accéder à l’axe des valeurs du graphique et définir l’unité principale, les unités secondaires, la valeur maximale et la valeur minimale.  
1. Accéder à l’axe de profondeur ou d‑axe de séries du graphique et le supprimer ; dans cet exemple, une seule série est utilisée.  
1. Définir maintenant les angles de rotation du graphique selon les directions X et Y.  
1. Enregistrer la présentation.  
1. Fermer les instances de Microsoft Excel et PowerPoint.  

**La présentation de sortie, créée avec VSTO** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-VSTOChart.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-EnsurePowerPointIsRunning.cs" >}}
### **Exemple Aspose.Slides for Java**
Avec Aspose.Slides for Java, les étapes suivantes sont effectuées :

1. Créer une instance d’une présentation Microsoft PowerPoint.  
1. Ajouter une diapositive vierge à la présentation.  
1. Ajouter un graphique **3D clustered column** et y accéder.  
1. Accéder à la feuille de données du graphique à l’aide d’une instance de classeur Microsoft Excel `fromworkbook`.  
1. Supprimer les séries inutilisées 2 et 3.  
1. Accéder aux catégories du graphique et modifier les libellés.  
1. Accéder à la série 1 et modifier les valeurs de la série.  
1. Accéder maintenant au titre du graphique et définir les propriétés de police.  
1. Accéder à l’axe des valeurs du graphique et définir l’unité principale, les unités secondaires, la valeur maximale et la valeur minimale.  
1. Définir maintenant les angles de rotation du graphique selon les directions X et Y.  
1. Enregistrer la présentation au format PPTX.  

**La présentation de sortie, créée avec Aspose.Slides** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateChart-CreateChart.java" >}}

## **FAQ**

### Puis‑je créer d’autres types de graphiques comme des graphiques circulaires, linéaires ou à barres avec Aspose.Slides ?

Oui. Aspose.Slides prend en charge un large éventail de [types de graphiques](/slides/fr/java/create-chart/), y compris les graphiques circulaires, les graphiques linéaires, les graphiques à barres, les nuages de points, les graphiques à bulles, et bien plus. Vous pouvez spécifier le type de graphique souhaité en utilisant la classe [ChartType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/charttype/) lors de l’ajout d’un graphique.

### Puis‑je appliquer des styles ou des thèmes personnalisés au graphique ?

Oui. Vous pouvez personnaliser entièrement l’apparence du graphique, y compris les couleurs, les polices, les remplissages, les contours, les quadrillages et la disposition. Cependant, l’application exacte des thèmes Office tels qu’ils apparaissent dans PowerPoint nécessite de définir manuellement chaque style individuellement.

### Puis‑je exporter le graphique sous forme d’image séparée de la diapositive ?

Oui, Aspose.Slides vous permet d’exporter toute forme—y compris les graphiques—en tant qu’image distincte (par ex. PNG, JPEG) en utilisant la méthode `getImage` sur la [shape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/shape/) du graphique.