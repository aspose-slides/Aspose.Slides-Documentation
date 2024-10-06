---  
title: Solution Fonctionnelle pour le Redimensionnement des Feuilles de Calcul  
type: docs  
weight: 20  
url: /java/solution-fonctionnelle-pour-le-redimensionnement-des-feuilles-de-calcul/  
---  

{{% alert color="primary" %}}  

Il a été observé que les feuilles de calcul Excel intégrées en tant qu'OLE dans une présentation PowerPoint via des composants Aspose sont redimensionnées à une échelle non identifiée après leur première activation. Ce comportement crée une différence visuelle considérable dans la présentation entre les états avant et après l'activation du graphique. Nous avons examiné ce problème en détail et trouvé la solution à ce problème qui est couverte dans cet article.  

{{% /alert %}}  
## **Contexte**  
Dans l'[article Ajouter des Cadres Ole](#), nous avons expliqué comment ajouter un Cadre Ole dans une présentation PowerPoint en utilisant Aspose.Slides pour Java. Afin de tenir compte du [problème de changement d'objet](/slides/java/probleme-de-changement-dobjet-lors-de-lajout-doleobjectframe/), nous avons attribué l'image de la feuille de calcul de la zone sélectionnée au Cadre d'Objet OLE du graphique. Dans la présentation de sortie, lorsque nous double-cliquons sur le Cadre d'Objet OLE affichant l'image de la feuille de calcul, le graphique Excel est activé. Les utilisateurs finaux peuvent apporter les modifications souhaitées dans le classeur Excel réel puis revenir à la diapositive concernée en cliquant en dehors du classeur Excel activé. La taille du Cadre d'Objet OLE changera lorsque l'utilisateur revient à la diapositive. Le facteur de redimensionnement sera différent pour différentes tailles de Cadre d'Objet OLE et de classeur Excel intégré.  
## **Cause du Redimensionnement**  
Étant donné que le classeur Excel a sa propre taille de fenêtre, il essaie de conserver sa taille d'origine lors de la première activation. D'autre part, le Cadre d'Objet OLE aura sa propre taille. Selon Microsoft, lors de l'activation du classeur Excel, Excel et PowerPoint négocient la taille et s'assurent qu'elle est dans les bonnes proportions dans le cadre de l'opération d'incrustation. En fonction des différences de taille de la fenêtre Excel et de la taille / position du Cadre d'Objet OLE, le redimensionnement se produit.  
## **Solution Fonctionnelle**  
Il existe deux solutions possibles pour éviter l'effet de redimensionnement.* Redimensionner la taille du cadre Ole dans PPT pour correspondre à la taille en termes de hauteur / largeur du nombre souhaité de lignes / colonnes dans le Cadre Ole.* Garder la taille du cadre Ole constante et redimensionner la taille des lignes / colonnes participantes pour s'adapter à la taille du cadre Ole sélectionné.  
## **Redimensionner la taille du cadre Ole aux lignes / colonnes sélectionnées de la feuille de calcul**  
Dans cette approche, nous apprendrons à définir la taille du cadre Ole du classeur Excel intégré équivalente à la taille cumulative du nombre de lignes et colonnes participantes dans la feuille de calcul Excel.  
## **Exemple**  
Supposons que nous ayons défini un modèle de feuille de calcul Excel et que nous souhaitions l'ajouter à la présentation en tant que cadre Ole. Dans ce scénario, la taille du Cadre d'Objet OLE sera d'abord calculée en fonction de la hauteur cumulative des lignes et des largeurs des colonnes des lignes et colonnes participantes du classeur respectivement. Ensuite, nous définirons la taille du cadre Ole à cette valeur calculée. Pour éviter le message rouge **Objet Intégré** pour le cadre OLE dans PowerPoint, nous obtiendrons également l'image des portions souhaitées des lignes et colonnes dans le classeur et nous définirons cela comme image du cadre Ole.  

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-ResizeOLEFrameToWorksheetRowsColumns.java" >}}  

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-AddOLEFrame.java" >}}  

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-SetOleAccordingToSelectedRowsCloumns.java" >}}  

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-ScaleImage.java" >}}  

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-SetWorkBookArea.java" >}}  

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-PrintArea.java" >}}  

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeOLEFrameToWorksheetRowsColumns-ExcelColumnLetter.java" >}}  

## **Redimensionner la hauteur des lignes de la feuille de calcul et la largeur des colonnes par rapport à la taille du cadre Ole**  
Dans cette approche, nous apprendrons comment redimensionner les hauteurs des lignes participantes et la largeur des colonnes participantes en fonction de la taille du cadre ole définie sur mesure.  
## **Exemple**  
Supposons que nous ayons défini un modèle de feuille de calcul Excel et que nous souhaitions l'ajouter à la présentation en tant que cadre Ole. Dans ce scénario, nous définirons la taille du cadre Ole et redimensionnerons la taille des lignes et des colonnes participant à la zone du Cadre Ole. Nous enregistrerons ensuite le classeur dans un flux pour enregistrer les modifications et le convertir en tableau d'octets pour l'ajouter au cadre Ole. Pour éviter le message rouge **Objet Intégré** pour le cadre OLE dans PowerPoint, nous obtiendrons également l'image des portions souhaitées des lignes et colonnes dans le classeur et nous définirons cela comme image du cadre Ole.  

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-ResizeWorksheetRowColumnAccordingToOLEFrame.java" >}}  

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-SetOleAccordingToCustomHeighWidth.java" >}}  

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-AddOLEFrame.java" >}}  

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-ResizeWorksheetRowColumnAccordingToOLEFrame-ScaleImage.java" >}}  
## **Conclusion**  
{{% alert color="primary" %}}  

Il existe deux approches pour résoudre le problème de redimensionnement des feuilles de calcul. Le choix de l'approche appropriée dépend des besoins et du cas d'utilisation. Les deux approches fonctionnent de la même manière, que les présentations soient créées à partir d'un modèle ou créées à partir de zéro. De plus, il n'y a pas de limite à la taille du Cadre d'Objet OLE dans la solution.  

{{% /alert %}}  