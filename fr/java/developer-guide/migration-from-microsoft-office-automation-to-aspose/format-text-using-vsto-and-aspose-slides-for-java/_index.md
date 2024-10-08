---
title: Formatage du texte à l'aide de VSTO et Aspose.Slides pour Java
type: docs
weight: 30
url: /fr/java/format-text-using-vsto-and-aspose-slides-for-java/
---

{{% alert color="primary" %}} 

Parfois, vous devez formater le texte sur les diapositives par programmation. Cet article montre comment lire une présentation d'exemple avec du texte sur la première diapositive en utilisant soit [VSTO](/slides/fr/java/format-text-using-vsto-and-aspose-slides-for-java/) soit [Aspose.Slides pour Java](/slides/fr/java/format-text-using-vsto-and-aspose-slides-for-java/). Le code formate le texte dans la troisième zone de texte de la diapositive pour qu'il ressemble au texte dans la dernière zone de texte.

{{% /alert %}} 
## **Formatage du texte**
Les méthodes VSTO et Aspose.Slides suivent les étapes suivantes :

1. Ouvrir la présentation source.
1. Accéder à la première diapositive.
1. Accéder à la troisième zone de texte.
1. Modifier le formatage du texte dans la troisième zone de texte.
1. Enregistrer la présentation sur le disque.

Les captures d'écran ci-dessous montrent la diapositive d'exemple avant et après l'exécution du code VSTO et Aspose.Slides pour Java.

**La présentation d'entrée** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_1.png)
### **Exemple de code VSTO**
Le code ci-dessous montre comment reformater le texte sur une diapositive en utilisant VSTO.

**Le texte reformaté avec VSTO** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_2.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-FormatTextUsingVSTO-FormatTextUsingVSTO.cs" >}}


### **Exemple d'Aspose.Slides pour Java**
Pour formater le texte avec Aspose.Slides, ajoutez la police avant de formater le texte.

**La présentation de sortie créée avec Aspose.Slides** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_3.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FormatText-FormatText.java" >}}