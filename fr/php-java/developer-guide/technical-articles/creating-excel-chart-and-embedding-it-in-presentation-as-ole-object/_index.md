---
title: Création d'un Graphique Excel et Intégration dans une Présentation en tant qu'Objet OLE
type: docs
weight: 30
url: /php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
---

{{% alert color="primary" %}} 

Dans les diapositives PowerPoint, l'utilisation de graphiques modifiables pour l'affichage graphique des données est une activité courante. Aspose prend en charge la création de graphiques Excel à l'aide d'Aspose.Cells pour Java, et ces graphiques peuvent ensuite être intégrés en tant qu'objet OLE dans la diapositive PowerPoint via Aspose.Slides pour PHP via Java. Cet article couvre les étapes nécessaires ainsi que l'implémentation pour créer et intégrer un graphique MS Excel en tant qu'objet OLE dans une présentation PowerPoint en utilisant Aspose.Cells pour Java et Aspose.Slides pour PHP via Java.

{{% /alert %}} 
## **Étapes Nécessaires**
La séquence d'étapes suivante est requise pour créer et intégrer un graphique Excel en tant qu'objet OLE dans la diapositive PowerPoint :# Créer un graphique Excel à l'aide d'Aspose.Cells pour Java.# Définir la taille OLE du graphique Excel à l'aide d'Aspose.Cells pour Java.# Obtenir l'image du graphique Excel avec Aspose.Cells pour Java.# Intégrer le graphique Excel en tant qu'objet OLE dans la présentation PPTX à l'aide d'Aspose.Slides pour PHP via Java.# Remplacer l'image de l'objet modifié par l'image obtenue à l'étape 3 pour traiter le problème d'objet modifié.# Enregistrer la présentation résultante sur le disque au format PPTX.
## **Implémentation des Étapes Nécessaires**
L'implémentation des étapes ci-dessus est comme suit :

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}

{{% alert color="primary" %}} 

La présentation créée par la méthode ci-dessus contiendra le graphique Excel en tant qu'objet OLE qui peut être activé en double-cliquant sur le cadre de l'objet OLE.

{{% /alert %}} 
## **Conclusion**
{{% alert color="primary" %}} 

En utilisant Aspose.Cells pour Java avec Aspose.Slides pour PHP via Java, nous pouvons créer n'importe quel graphique Excel pris en charge par Aspose.Cells pour Java et intégrer le graphique créé en tant qu'objet OLE dans une diapositive PowerPoint. La taille OLE du graphique Excel peut également être définie. Les utilisateurs finaux peuvent ensuite modifier le graphique Excel comme tout autre objet OLE.

{{% /alert %}} 
## **Sections Associées**
[Solution Fonctionnelle pour le Redimensionnement des Graphiques](/slides/php-java/working-solution-for-chart-resizing-in-pptx/)

[Problème d'Objet Modifié](/slides/php-java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)