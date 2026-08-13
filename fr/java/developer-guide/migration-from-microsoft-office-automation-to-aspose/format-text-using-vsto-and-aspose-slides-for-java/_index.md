---
title: Formater le texte avec VSTO et Aspose.Slides pour Java
linktitle: Formater le texte
type: docs
weight: 30
url: /fr/java/format-text-using-vsto-and-aspose-slides-for-java/
keywords:
- formater le texte
- migration
- VSTO
- automatisation Office
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Migrez de l'automatisation Microsoft Office vers Aspose.Slides pour Java et formatez le texte dans les présentations PowerPoint (PPT, PPTX) avec un contrôle précis."
---
{{% alert color="info" %}} 

Parfois, vous devez formater le texte des diapositives de manière programmatique. Cet article montre comment lire une présentation d'exemple contenant du texte sur la première diapositive en utilisant [VSTO](/slides/fr/java/format-text-using-vsto-and-aspose-slides-for-java/) ou [Aspose.Slides for Java](/slides/fr/java/format-text-using-vsto-and-aspose-slides-for-java/). Le code formate le texte de la troisième zone de texte de la diapositive pour qu'il ressemble au texte de la dernière zone de texte.

{{% /alert %}} 
## **Mise en forme du texte**
Les méthodes VSTO et Aspose.Slides suivent les étapes suivantes :

1. Ouvrir la présentation source.
1. Accéder à la première diapositive.
1. Accéder à la troisième zone de texte.
1. Modifier le format du texte dans la troisième zone de texte.
1. Enregistrer la présentation sur le disque.

Les captures d'écran ci-dessous montrent la diapositive d'exemple avant et après l'exécution du code VSTO et Aspose.Slides for Java.

**La présentation d'entrée** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_1.png)
### **Exemple de code VSTO**
Le code ci-dessous montre comment reformater le texte sur une diapositive en utilisant VSTO.

**Le texte reformatté avec VSTO** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_2.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-FormatTextUsingVSTO-FormatTextUsingVSTO.cs" >}}


### **Exemple Aspose.Slides for Java**
Pour formater le texte avec Aspose.Slides, ajoutez la police avant de formater le texte.

**La présentation de sortie créée avec Aspose.Slides** 

![todo:image_alt_text](format-text-using-vsto-and-aspose-slides-for-java_3.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FormatText-FormatText.java" >}}