---
title: Créer une nouvelle présentation
type: docs
weight: 10
url: /androidjava/create-a-new-presentation/
---

{{% alert color="primary" %}} 

VSTO a été développé pour permettre aux développeurs de créer des applications pouvant fonctionner à l'intérieur de Microsoft Office. VSTO est basé sur COM mais il est encapsulé dans un objet .NET afin qu'il puisse être utilisé dans des applications .NET. VSTO nécessite un support du framework .NET ainsi qu'un runtime basé sur CLR de Microsoft Office. Bien qu'il puisse être utilisé pour créer des compléments Microsoft Office, il est presque impossible de l'utiliser comme composant côté serveur. Il présente également de sérieux problèmes de déploiement.

Aspose.Slides pour Android via Java est un composant qui peut être utilisé pour manipuler des présentations Microsoft PowerPoint, tout comme VSTO, mais il présente plusieurs avantages :

- Aspose.Slides ne contient que du code géré et ne nécessite pas l'installation du runtime Microsoft Office.
- Il peut être utilisé comme un composant côté client ou comme un composant côté serveur.
- Le déploiement est facile puisque Aspose.Slides est contenu dans un seul fichier jar.

{{% /alert %}} 
## **Création d'une présentation**
Voici deux exemples de code qui illustrent comment VSTO et Aspose.Slides pour Android via Java peuvent être utilisés pour atteindre le même objectif. Le premier exemple est [VSTO](/slides/androidjava/create-a-new-presentation/) ; [le deuxième exemple](/slides/androidjava/create-a-new-presentation/) utilise Aspose.Slides.
### **Exemple VSTO**
**La sortie de VSTO** 

![todo:image_alt_text](create-a-new-presentation_1.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-AddVSTOPresentation-AddVSTOPresentation.cs" >}}
### **Exemple Aspose.Slides pour Android via Java**
**La sortie d'Aspose.Slides** 

![todo:image_alt_text](create-a-new-presentation_2.png)



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-CreatePresentation-CreatePresentation.java" >}}