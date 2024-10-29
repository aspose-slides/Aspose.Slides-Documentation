---
title: Solution Fonctionnelle pour le Redimensionnement de Feuille de Calcul
type: docs
weight: 20
url: /fr/php-java/solution-fonctionnelle-pour-le-redimensionnement-de-feuille-de-calcul/
---

{{% alert color="primary" %}} 

Il a été observé que les feuilles de calcul Excel intégrées en tant qu'OLE dans une présentation PowerPoint via les composants Aspose sont redimensionnées à une échelle non identifiée après la première activation. Ce comportement crée une différence visuelle considérable dans la présentation entre les états avant et après l'activation du graphique. Nous avons examiné ce problème en détail et trouvé la solution qui est exposée dans cet article.

{{% /alert %}} 
## **Contexte**
Dans [l'article Ajouter des cadres Ole](), nous avons expliqué comment ajouter un cadre Ole dans une présentation PowerPoint en utilisant Aspose.Slides pour PHP via Java. Afin de tenir compte du [problème d'objet modifié](/slides/fr/php-java/probleme-dobjet-modifie-lors-de-lajout-doleobjectframe/), nous avons attribué l'image de la feuille de calcul de la zone sélectionnée au cadre d'objet OLE du graphique. Dans la présentation de sortie, lorsque nous double-cliquons sur le cadre d'objet OLE affichant l'image de la feuille de calcul, le graphique Excel s'active. Les utilisateurs finaux peuvent apporter toutes les modifications souhaitées dans le classeur Excel réel puis retourner à la diapositive concernée en cliquant en dehors du classeur Excel activé. La taille du cadre d'objet OLE changera lorsque l'utilisateur reviendra à la diapositive. Le facteur de redimensionnement sera différent selon les tailles des cadres d'objet OLE et des classeurs Excel intégrés.
## **Cause du Redimensionnement**
Puisque le classeur Excel a sa propre taille de fenêtre, il essaie de conserver sa taille originale lors de la première activation. D'autre part, le cadre d'objet OLE aura sa propre taille. Selon Microsoft, lors de l'activation du classeur Excel, Excel et PowerPoint négocient la taille et s'assurent qu'elle est dans les bonnes proportions dans le cadre de l'opération d'intégration. Sur la base des différences entre la taille de la fenêtre Excel et la taille/position du cadre d'objet OLE, le redimensionnement a lieu.
## **Solution Fonctionnelle**
Il existe deux solutions possibles pour éviter l'effet de redimensionnement.* Redimensionner la taille du cadre Ole dans PPT pour correspondre à la taille en termes de hauteur/largeur du nombre désiré de lignes/colonnes dans le cadre Ole.* Garder la taille du cadre Ole constante et redimensionner la taille des lignes/colonnes participantes pour s'adapter à la taille sélectionnée du cadre Ole.
## **Redimensionner la taille du cadre Ole selon la taille des lignes/colonnes sélectionnées de la feuille de calcul**
Dans cette approche, nous allons apprendre comment définir la taille du cadre Ole du classeur Excel intégré équivalente à la taille cumulative du nombre de lignes et de colonnes participantes dans la feuille de calcul Excel.
## **Exemple**
Supposons que nous ayons défini une feuille Excel modèle et que nous souhaitions l'ajouter à la présentation en tant que cadre Ole. Dans ce scénario, la taille du cadre d'objet OLE sera d'abord calculée en fonction de la hauteur cumulative des lignes et des largeurs des colonnes des lignes et colonnes participantes du classeur. Ensuite, nous définirons la taille du cadre Ole sur cette valeur calculée. Afin d'éviter le message rouge **Objet Intégré** pour le cadre Ole dans PowerPoint, nous obtiendrons également l'image des portions désirées de lignes et de colonnes dans le classeur et définirons cela comme image du cadre Ole.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-ResizeOLEFrameToWorksheetRowsColumns.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-AddOLEFrame.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-SetOleAccordingToSelectedRowsCloumns.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-ScaleImage.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-SetWorkBookArea.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-PrintArea.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-ExcelColumnLetter.java" >}}

## **Redimensionner la hauteur des lignes et la largeur des colonnes de la feuille de calcul selon la taille du cadre Ole**
Dans cette approche, nous allons apprendre à redimensionner les hauteurs des lignes participantes et la largeur des colonnes participantes en fonction de la taille du cadre ole personnalisée.
## **Exemple**
Supposons que nous ayons défini une feuille Excel modèle et que nous souhaitions l'ajouter à la présentation en tant que cadre Ole. Dans ce scénario, nous allons définir la taille du cadre Ole et redimensionner la taille des lignes et colonnes participantes dans la zone du cadre Ole. Nous sauvegarderons ensuite le classeur dans un flux pour enregistrer les modifications et le convertir en tableau d'octets pour l'ajouter au cadre Ole. Afin d'éviter le message rouge **Objet Intégré** pour le cadre Ole dans PowerPoint, nous obtiendrons également l'image des portions désirées de lignes et de colonnes dans le classeur et définirons cela comme image du cadre Ole.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-ResizeWorksheetRowColumnAccordingToOLEFrame.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-SetOleAccordingToCustomHeighWidth.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-AddOLEFrame.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-ScaleImage.java" >}}
## **Conclusion**
{{% alert color="primary" %}} 

Il existe deux approches pour résoudre le problème de redimensionnement de la feuille de calcul. Le choix de l'approche appropriée dépend de la nécessité et du cas d'utilisation. Les deux approches fonctionnent de la même manière que les présentations soient créées à partir d'un modèle ou à partir de zéro. De plus, il n'y a pas de limite à la taille du cadre d'objet OLE dans la solution.

{{% /alert %}}