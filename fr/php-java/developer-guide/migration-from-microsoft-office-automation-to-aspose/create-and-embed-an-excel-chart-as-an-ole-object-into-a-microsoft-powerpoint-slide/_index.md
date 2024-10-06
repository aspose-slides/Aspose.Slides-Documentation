---
title: Créer et intégrer un graphique Excel en tant qu'objet OLE dans une diapositive Microsoft PowerPoint
type: docs
weight: 60
url: /php-java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
---

{{% alert color="primary" %}} 

 Les graphiques sont des représentations visuelles de vos données et sont largement utilisés dans les diapositives de présentation. Cet article vous montrera le code pour créer et intégrer un graphique Excel en tant qu'objet OLE dans la diapositive PowerPoint de manière programmatique en utilisant [VSTO](/slides/php-java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) et [Aspose.Slides pour PHP via Java](/slides/php-java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).

{{% /alert %}} 
## **Créer et intégrer un graphique Excel**
Les deux exemples de code ci-dessous sont longs et détaillés car la tâche qu'ils décrivent est complexe. Vous créez un classeur Microsoft Excel, créez un graphique et ensuite créez la présentation Microsoft PowerPoint dans laquelle vous allez intégrer le graphique. Les objets OLE contiennent des liens vers le document original, de sorte qu'un utilisateur qui double-clique sur le fichier intégré lancera le fichier et son application.
### **Exemple VSTO**
En utilisant VSTO, les étapes suivantes sont effectuées :

1. Créer une instance de l'objet Microsoft Excel ApplicationClass.
1. Créer un nouveau classeur avec une feuille à l'intérieur.
1. Ajouter un graphique à la feuille.
1. Enregistrer le classeur.
1. Ouvrir le classeur Excel contenant la feuille de calcul avec les données du graphique.
1. Obtenir la collection ChartObjects pour la feuille.
1. Obtenir le graphique à copier.
1. Créer une présentation Microsoft PowerPoint.
1. Ajouter une diapositive vierge à la présentation.
1. Copier le graphique de la feuille de calcul Excel dans le presse-papiers.
1. Coller le graphique dans la présentation PowerPoint.
1. Positionner le graphique sur la diapositive.
1. Enregistrer la présentation.

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **Exemple Aspose.Slides pour PHP via Java**
En utilisant Aspose.Slides pour .NET, les étapes suivantes sont effectuées :

1. Créer un classeur en utilisant Aspose.Cells pour Java.
1. Créer un graphique Microsoft Excel.
1. Définir la taille OLE du graphique Excel.
1. Obtenir une image du graphique.
1. Intégrer le graphique Excel en tant qu'objet OLE dans la présentation PPTX en utilisant Aspose.Slides pour PHP via Java.
1. Remplacer l'image modifiée de l'objet avec l'image obtenue à l'étape 3 pour remédier au problème de l'objet modifié.
1. Écrire la présentation de sortie sur le disque au format PPTX.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}