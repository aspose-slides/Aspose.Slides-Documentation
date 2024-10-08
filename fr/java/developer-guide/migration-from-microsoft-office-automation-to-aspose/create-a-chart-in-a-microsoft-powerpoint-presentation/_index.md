---
title: Créer un Graphique dans une Présentation Microsoft PowerPoint
type: docs
weight: 70
url: /fr/java/create-a-chart-in-a-microsoft-powerpoint-presentation/
---

{{% alert color="primary" %}} 

 Les graphiques sont des représentations visuelles de données largement utilisées dans les présentations. Cet article montre le code pour créer un graphique dans Microsoft PowerPoint de manière programmatique en utilisant [VSTO](/slides/fr/java/create-a-chart-in-a-microsoft-powerpoint-presentation/) et [Aspose.Slides pour Java](/slides/fr/java/create-a-chart-in-a-microsoft-powerpoint-presentation/).

{{% /alert %}} 
## **Créer un Graphique**
Les exemples de code ci-dessous décrivent le processus d'ajout d'un graphique à colonnes groupées 3D simple en utilisant VSTO. Vous créez une instance de présentation, ajoutez un graphique par défaut. Ensuite, utilisez un classeur Microsoft Excel pour accéder et modifier les données du graphique ainsi que définir les propriétés du graphique. Enfin, sauvegardez la présentation.
### **Exemple VSTO**
En utilisant VSTO, les étapes suivantes sont réalisées :

1. Créer une instance d'une présentation Microsoft PowerPoint.
1. Ajouter une diapositive vierge à la présentation.
1. Ajouter un graphique **à colonnes groupées 3D** et y accéder.
1. Créer une nouvelle instance de classeur Microsoft Excel et charger les données du graphique.
1. Accéder à la feuille de calcul des données du graphique en utilisant l'instance du classeur Microsoft Excel.
1. Définir la plage du graphique dans la feuille de calcul et supprimer les séries 2 et 3 du graphique.
1. Modifier les données des catégories du graphique dans la feuille de calcul des données du graphique.
1. Modifier les données de la série 1 du graphique dans la feuille de calcul des données du graphique.
1. Maintenant, accéder au titre du graphique et définir les propriétés de police.
1. Accéder à l'axe des valeurs du graphique et définir l'unité majeure, les unités mineures, la valeur maximale et les valeurs minimales.
1. Accéder à la profondeur du graphique ou l'axe des séries et le supprimer car, dans cet exemple, une seule série est utilisée.
1. Maintenant, définir les angles de rotation du graphique dans les directions X et Y.
1. Sauvegarder la présentation.
1. Fermer les instances de Microsoft Excel et PowerPoint.

**La présentation de sortie, créée avec VSTO** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-VSTOChart.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-EnsurePowerPointIsRunning.cs" >}}
### **Exemple Aspose.Slides pour Java**
En utilisant Aspose.Slides pour Java, les étapes suivantes sont réalisées :

1. Créer une instance d'une présentation Microsoft PowerPoint.
1. Ajouter une diapositive vierge à la présentation.
1. Ajouter un graphique **à colonnes groupées 3D** et y accéder.
1. Accéder à la feuille de calcul des données du graphique en utilisant une instance de classeur Microsoft Excel.
1. Supprimer les séries inutilisées 2 et 3.
1. Accéder aux catégories de graphiques et modifier les étiquettes.
1. Accéder à la série 1 et modifier les valeurs de la série.
1. Maintenant, accéder au titre du graphique et définir les propriétés de police.
1. Accéder à l'axe des valeurs du graphique et définir l'unité majeure, les unités mineures, la valeur maximale et les valeurs minimales.
1. Maintenant, définir les angles de rotation du graphique dans les directions X et Y.
1. Sauvegarder la présentation au format PPTX.

**La présentation de sortie, créée avec Aspose.Slides** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateChart-CreateChart.java" >}}