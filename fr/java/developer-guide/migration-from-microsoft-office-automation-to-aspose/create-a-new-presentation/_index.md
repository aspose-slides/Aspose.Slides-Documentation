---
title: Créer une Nouvelle Présentation
type: docs
weight: 10
url: /fr/java/create-a-new-presentation/
---

{{% alert color="primary" %}} 

VSTO a été développé pour permettre aux développeurs de créer des applications pouvant fonctionner à l'intérieur de Microsoft Office. VSTO est basé sur COM mais est enveloppé dans un objet .NET afin qu'il puisse être utilisé dans des applications .NET. VSTO nécessite le support du framework .NET ainsi que l'exécution CLR de Microsoft Office. Bien qu'il puisse être utilisé pour créer des compléments Microsoft Office, il est presque impossible de l'utiliser comme composant côté serveur. Il présente également de graves problèmes de déploiement.

Aspose.Slides pour Java est un composant qui peut être utilisé pour manipuler des présentations Microsoft PowerPoint, tout comme VSTO, mais il présente plusieurs avantages :

- Aspose.Slides contient uniquement du code géré et ne nécessite pas l'installation de l'exécution Microsoft Office.
- Il peut être utilisé comme un composant côté client ou comme un composant côté serveur.
- Le déploiement est facile puisque Aspose.Slides est contenu dans un seul fichier jar.

{{% /alert %}} 
## **Créer une Présentation**
Ci-dessous se trouvent deux exemples de code qui illustrent comment VSTO et Aspose.Slides pour Java peuvent être utilisés pour atteindre le même objectif. Le premier exemple est [VSTO](/slides/fr/java/create-a-new-presentation/); [le deuxième exemple](/slides/fr/java/create-a-new-presentation/) utilise Aspose.Slides.
### **Exemple VSTO**
**La sortie de VSTO** 

![todo:image_alt_text](create-a-new-presentation_1.png)

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-AddVSTOPresentation-AddVSTOPresentation.cs" >}}
### **Exemple Aspose.Slides pour Java**
**La sortie d'Aspose.Slides** 

![todo:image_alt_text](create-a-new-presentation_2.png)



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-CreatePresentation-CreatePresentation.java" >}}