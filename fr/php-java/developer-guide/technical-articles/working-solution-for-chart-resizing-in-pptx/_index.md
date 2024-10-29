---
title: Solution Fonctionnelle pour le Redimensionnement de Graphiques dans PPTX
type: docs
weight: 40
url: /fr/php-java/working-solution-for-chart-resizing-in-pptx/
---

{{% alert color="primary" %}} 

Il a été observé que les graphiques Excel intégrés en tant qu'OLE dans une présentation PowerPoint via les composants Aspose sont redimensionnés à une échelle non identifiée après la première activation. Ce comportement crée une différence visuelle considérable dans la présentation entre les états avant et après l'activation du graphique. L'équipe Aspose, avec l'aide de l'équipe Microsoft, a examiné ce problème en détail et a trouvé une solution. Cet article couvre les raisons et la solution à ce problème.

{{% /alert %}} 
## **Contexte**
Dans [l'article précédent](/slides/fr/php-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), nous avons expliqué comment créer un graphique Excel à l'aide d'Aspose.Cells pour Java et l'intégrer ensuite dans une présentation PowerPoint à l'aide d'Aspose.Slides pour PHP via Java. Afin de résoudre le [problème de changement d'objet](/slides/fr/php-java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/), nous avons attribué l'image du graphique au cadre de l'objet OLE du graphique. Dans la présentation de sortie, lorsque nous double-cliquons sur le cadre d'objet OLE montrant l'image du graphique, le graphique Excel est activé. Les utilisateurs finaux peuvent apporter les modifications souhaitées dans le classeur Excel réel, puis revenir à la diapositive concernée en cliquant en dehors du classeur Excel activé. La taille du cadre de l'objet OLE changera lorsque l'utilisateur reviendra à la diapositive. Le facteur de redimensionnement sera différent pour différentes tailles de cadre d'objet OLE et de classeur Excel intégré.
## **Cause du Redimensionnement**
Étant donné que le classeur Excel a sa propre taille de fenêtre, il essaie de conserver sa taille d'origine lors de la première activation. D'autre part, le cadre d'objet OLE aura sa propre taille. Selon Microsoft, lors de l'activation du classeur Excel, Excel et PowerPoint négocient la taille et s'assurent qu'elle est dans les bonnes proportions dans le cadre de l'opération d'intégration. En fonction des différences de taille de fenêtres Excel et de taille / position du cadre d'objet OLE, le redimensionnement est effectué.
## **Solution Fonctionnelle**
Il existe deux scénarios possibles pour la création des présentations PowerPoint à l'aide d'Aspose.Slides pour PHP via Java. **Scénario 1 :** Créer la présentation à partir d'un modèle existant **Scénario 2 :** Créer la présentation depuis le début. La solution que nous allons fournir ici sera valide pour les deux scénarios. La base de toutes les approches de solution sera la même. C'est-à-dire : **La taille de la fenêtre de l'objet OLE intégré doit être la même que celle du cadre d'objet OLE** **dans la diapositive PowerPoint**. Nous allons maintenant discuter des deux approches de la solution.
## **Première Approche**
Dans cette approche, nous allons apprendre comment définir la taille de la fenêtre du classeur Excel intégré équivalente à la taille du cadre d'objet OLE dans la diapositive PowerPoint. **Scénario 1** Supposons que nous avons défini un modèle et que nous souhaitons créer les présentations basées sur ce modèle. Disons qu'il y a une forme à l'index 2 dans le modèle où nous voulons placer un cadre OLE portant un classeur Excel intégré. Dans ce scénario, la taille du cadre d'objet OLE sera considérée comme pré-définie (qui est la taille de la forme à l'index 2 dans le modèle). Tout ce que nous avons à faire : définir la taille de la fenêtre du classeur égale à la taille de la forme. Le code suivant servira cet objectif :

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartWithExistingTemplate-ResizeChartWithExistingTemplate.java" >}}

**Scénario 2** Disons que nous voulons créer une présentation depuis le début et souhaitons un cadre d'objet OLE de n'importe quelle taille avec un classeur Excel intégré. Dans le code suivant, nous avons créé un cadre d'objet OLE avec une hauteur de 4 pouces et une largeur de 9,5 pouces dans la diapositive à x = 0,5 pouce et y = 1 pouce. De plus, nous avons défini la taille de fenêtre équivalente du classeur Excel, c'est-à-dire : hauteur de 4 pouces et largeur de 9,5 pouces.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartFromScratch-ResizeChartFromScratch.java" >}}

## **Deuxième Approche**
Dans cette approche, nous allons apprendre comment définir la taille du graphique présent dans le classeur Excel intégré équivalente à la taille du cadre d'objet OLE dans la diapositive PowerPoint. Cette approche est utile lorsque la taille du graphique à l'avance est connue et ne changera jamais. **Scénario 1** Supposons que nous avons défini un modèle et que nous souhaitons créer les présentations basées sur ce modèle. Disons qu'il y a une forme à l'index 2 dans le modèle où nous voulons placer un cadre OLE portant un classeur Excel intégré. Dans ce scénario, la taille du cadre OLE sera considérée comme pré-définie (qui est la taille de la forme à l'index 2 dans le modèle). Tout ce que nous avons à faire : définir la taille du graphique dans le classeur égale à la taille de la forme. Le code suivant servira cet objectif :

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartWithExistingTemplateSecondApproach-ResizeChartWithExistingTemplateSecondApproach.java" >}}

**Scénario 2** : Disons que nous voulons créer une présentation depuis le début et souhaitons un cadre d'objet OLE de n'importe quelle taille avec un classeur Excel intégré. Dans le code suivant, nous avons créé un cadre d'objet OLE avec une hauteur de 4 pouces et une largeur de 9,5 pouces dans la diapositive à x = 0,5 pouce et y = 1 pouce. De plus, nous avons défini la taille équivalente du graphique, c'est-à-dire : hauteur de 4 pouces et largeur de 9,5 pouces.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-ResizeChartFromScratchSecondApproach-ResizeChartFromScratchSecondApproach.java" >}}
## **Conclusion**
{{% alert color="primary" %}} 

Il existe deux approches pour résoudre le problème de redimensionnement des graphiques. Le choix de l'approche appropriée dépend des exigences et du cas d'utilisation. Les deux approches fonctionnent de la même manière que les présentations soient créées à partir d'un modèle ou créées depuis le début. De plus, il n'y a pas de limite de taille pour le cadre d'objet OLE dans la solution.

{{% /alert %}}