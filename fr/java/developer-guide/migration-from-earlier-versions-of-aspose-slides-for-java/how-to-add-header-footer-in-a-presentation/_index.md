---
title: Comment ajouter des en-têtes et des pieds de page aux présentations en Java
linktitle: Ajouter en-tête & pied de page
type: docs
weight: 20
url: /fr/java/how-to-add-header-footer-in-a-presentation/
keywords:
- migration
- ajouter un en-tête
- ajouter un pied de page
- code hérité
- code moderne
- approche héritée
- approche moderne
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Apprenez à ajouter des en-têtes et des pieds de page aux présentations PowerPoint PPT, PPTX et ODP en Java en utilisant à la fois les API Aspose.Slides legacy et modernes."
---

{{% alert color="primary" %}} 

Une nouvelle [Aspose.Slides for Java API](https://docs.aspose.com/slides/java/) a été publiée et ce produit unique prend désormais en charge la génération de documents PowerPoint à partir de zéro ainsi que la modification des documents existants.

{{% /alert %}} 
## **Prise en charge du code hérité**
Afin d'utiliser le code hérité développé avec les versions d'Aspose.Slides for Java antérieures à 13.x, vous devez apporter quelques modifications mineures à votre code et il fonctionnera comme auparavant. Toutes les classes qui étaient présentes dans l'ancienne version d'Aspose.Slides for Java sous les espaces de noms Aspose.Slide et Aspose.Slides.Pptx sont maintenant regroupées dans un seul espace de noms Aspose.Slides. Veuillez consulter l'exemple de code suivant pour ajouter un en-tête et un pied de page à une présentation dans l'API Aspose.Slides legacy et suivre les étapes décrivant comment migrer vers la nouvelle API fusionnée.
## **Approche legacy d'Aspose.Slides for Java**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SetPPTXFooter-SetPPTXFooter.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SetPPTFooter-SetPPTFooter.java" >}}
## **Nouvelle approche d'Aspose.Slides for Java 13.x**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SetPresentationFooter-SetPresentationFooter.java" >}}