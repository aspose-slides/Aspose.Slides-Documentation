---  
title: Création d'un graphique Excel et intégration dans la présentation en tant qu'objet OLE  
type: docs  
weight: 30  
url: /java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/  
---  

{{% alert color="primary" %}}  

Dans les diapositives PowerPoint, l'utilisation de graphiques modifiables pour l'affichage graphique des données est une activité courante. Aspose fournit le support de la création de graphiques Excel à l'aide d'Aspose.Cells pour Java et ces graphiques peuvent ensuite être intégrés en tant qu'objet OLE dans la diapositive PowerPoint via Aspose.Slides pour Java. Cet article couvre les étapes nécessaires ainsi que l'implémentation en Java pour créer et intégrer un graphique MS Excel en tant qu'objet OLE dans une présentation PowerPoint en utilisant Aspose.Cells pour Java et Aspose.Slides pour Java.  

{{% /alert %}}  
## **Étapes Nécessaires**  
La séquence suivante d'étapes est requise pour créer et intégrer un graphique Excel en tant qu'objet OLE dans la diapositive PowerPoint :  
# Créer un graphique Excel en utilisant Aspose.Cells pour Java.  
# Définir la taille OLE du graphique Excel en utilisant Aspose.Cells pour Java.  
# Obtenir l'image du graphique Excel avec Aspose.Cells pour Java.  
# Intégrer le graphique Excel en tant qu'objet OLE dans la présentation PPTX en utilisant Aspose.Slides pour Java.  
# Remplacer l'image de l'objet modifié par l'image obtenue à l'étape 3 pour résoudre le problème d'objet modifié.  
# Enregistrer la présentation de sortie sur le disque au format PPTX.  
## **Implémentation des Étapes Nécessaires**  
L'implémentation des étapes ci-dessus en Java est comme suit :  

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}  

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}  

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}  

{{% alert color="primary" %}}  

La présentation créée par la méthode ci-dessus comportera le graphique Excel en tant qu'objet OLE qui peut être activé en double-cliquant sur le cadre de l'objet OLE.  

{{% /alert %}}  
## **Conclusion**  
{{% alert color="primary" %}}  

En utilisant Aspose.Cells pour Java avec Aspose.Slides pour Java, nous pouvons créer n'importe lequel des graphiques Excel pris en charge par Aspose.Cells pour Java et intégrer le graphique créé en tant qu'objet OLE dans une diapositive PowerPoint. La taille OLE du graphique Excel peut également être définie. Les utilisateurs finaux peuvent ensuite modifier le graphique Excel comme tout autre objet OLE.  

{{% /alert %}}  
## **Sections Connexes**  
[Solution Fonctionnelle pour le Redimensionnement de Graphiques](/slides/java/working-solution-for-chart-resizing-in-pptx/)  

[Problème d'Objet Modifié](/slides/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)  