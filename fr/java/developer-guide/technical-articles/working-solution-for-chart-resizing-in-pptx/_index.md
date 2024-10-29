---
title: Solution Fonctionnelle pour le Redimensionnement des Graphiques dans PPTX
type: docs
weight: 40
url: /fr/java/working-solution-for-chart-resizing-in-pptx/
---

{{% alert color="primary" %}} 

Il a été observé que les graphiques Excel intégrés en tant qu'OLE dans une présentation PowerPoint via les composants Aspose sont redimensionnés à une échelle non identifiée après la première activation. Ce comportement crée une différence visuelle considérable dans la présentation entre les états d'activation des graphiques avant et après. L'équipe Aspose, avec l'aide de l'équipe Microsoft, a examiné ce problème en détail et a trouvé la solution à ce problème. Cet article couvre les raisons et la solution à ce problème.

{{% /alert %}} 
## **Contexte**
Dans [l'article précédent](/slides/fr/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), nous avons expliqué comment créer un graphique Excel en utilisant Aspose.Cells pour Java et intégrer ce graphique dans une présentation PowerPoint en utilisant Aspose.Slides pour Java. Pour accommoder le [problème de changement d'objet](/slides/fr/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/), nous avons assigné l'image du graphique à la trame d'objet OLE du graphique. Dans la présentation de sortie, lorsque nous double-cliquons sur la trame d'objet OLE affichant l'image du graphique, le graphique Excel est activé. Les utilisateurs finaux peuvent apporter les changements souhaités dans le classeur Excel réel, puis revenir à la diapositive concernée en cliquant à l'extérieur du classeur Excel activé. La taille de la trame d'objet OLE changera lorsque l'utilisateur reviendra à la diapositive. Le facteur de redimensionnement sera différent pour différentes tailles de trame d'objet OLE et de classeur Excel intégré.
## **Cause du Redimensionnement**
Étant donné que le classeur Excel a sa propre taille de fenêtre, il essaie de conserver sa taille d'origine lors de la première activation. D'autre part, la trame d'objet OLE aura sa propre taille. Selon Microsoft, lors de l'activation du classeur Excel, Excel et PowerPoint négocient la taille et s'assurent qu'elle est dans les bonnes proportions dans le cadre de l'opération d'intégration. En fonction des différences de taille de fenêtre Excel et de taille / position de la trame d'objet OLE, le redimensionnement se produit.
## **Solution Fonctionnelle**
Il existe deux scénarios possibles pour la création de présentations PowerPoint utilisant Aspose.Slides pour Java. **Scénario 1 :** Créer la présentation basée sur un modèle existant **Scénario 2 :** Créer la présentation de zéro. La solution que nous fournirons ici sera valide pour les deux scénarios. La base de toutes les approches de solution sera la même. C'est-à-dire : **La taille de la fenêtre de l'objet OLE intégré doit être la même que celle de la trame d'objet OLE** **dans la diapositive PowerPoint**. Maintenant, nous allons discuter des deux approches de la solution.
## **Première Approche**
Dans cette approche, nous apprendrons comment définir la taille de la fenêtre du classeur Excel intégré équivalente à la taille de la trame d'objet OLE dans la diapositive PowerPoint. **Scénario 1** Supposons que nous avons défini un modèle et que nous souhaitons créer les présentations basées sur ce modèle. Disons qu'il y a une forme à l'index 2 dans le modèle où nous voulons placer une trame OLE portant un classeur Excel intégré. Dans ce scénario, la taille de la trame d'objet OLE sera considérée comme prédéfinie (qui est la taille de la forme à l'index 2 dans le modèle). Tout ce que nous avons à faire : définir la taille de la fenêtre du classeur égale à la taille de la forme. Le code suivant servira à cet objectif :

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartWithExistingTemplate-ResizeChartWithExistingTemplate.java" >}}

**Scénario 2** Disons que nous souhaitons créer une présentation de zéro et désirer une trame d'objet OLE de n'importe quelle taille avec un classeur Excel intégré. Dans le code suivant, nous avons créé une trame d'objet OLE avec une hauteur de 4 pouces et une largeur de 9,5 pouces dans la diapositive à l'axe x=0,5 pouces et à l'axe y=1 pouce. De plus, nous avons défini la taille de fenêtre équivalente du classeur Excel, c'est-à-dire : hauteur 4 pouces et largeur 9,5 pouces.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartFromScratch-ResizeChartFromScratch.java" >}}

## **Deuxième Approche**
Dans cette approche, nous apprendrons comment définir la taille du graphique présent dans le classeur Excel intégré équivalente à la taille de la trame d'objet OLE dans la diapositive PowerPoint. Cette approche est utile lorsque la taille du graphique est connue à l'avance et ne changera jamais. **Scénario 1** Supposons que nous avons défini un modèle et que nous souhaitons créer les présentations basées sur ce modèle. Disons qu'il y a une forme à l'index 2 dans le modèle où nous voulons placer une trame OLE portant un classeur Excel intégré. Dans ce scénario, la taille de la trame OLE sera considérée comme prédéfinie (qui est la taille de la forme à l'index 2 dans le modèle). Tout ce que nous avons à faire : définir la taille du graphique dans le classeur égale à la taille de la forme. Le code suivant servira à cet objectif :

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartWithExistingTemplateSecondApproach-ResizeChartWithExistingTemplateSecondApproach.java" >}}

**Scénario 2 :** Disons que nous souhaitons créer une présentation de zéro et désirer une trame d'objet OLE de n'importe quelle taille avec un classeur Excel intégré. Dans le code suivant, nous avons créé une trame d'objet OLE avec une hauteur de 4 pouces et une largeur de 9,5 pouces dans la diapositive à l'axe x=0,5 pouces et à l'axe y=1 pouce. De plus, nous avons défini la taille du graphique équivalente, c'est-à-dire : hauteur 4 pouces et largeur 9,5 pouces.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartFromScratchSecondApproach-ResizeChartFromScratchSecondApproach.java" >}}
## **Conclusion**
{{% alert color="primary" %}} 

Il existe deux approches pour résoudre le problème de redimensionnement des graphiques. Le choix de l'approche appropriée dépend des besoins et du cas d'utilisation. Les deux approches fonctionnent de la même manière que les présentations soient créées à partir d'un modèle ou créées de zéro. De plus, il n'y a pas de limite à la taille de la trame d'objet OLE dans la solution.

{{% /alert %}}