---
title: Comment ajouter des en‑têtes et pieds de page aux présentations en Java
linktitle: Ajouter en‑tête & pied de page
type: docs
weight: 20
url: /fr/java/how-to-add-header-footer-in-a-presentation/
keywords:
- migration
- ajouter en‑tête
- ajouter pied de page
- code hérité
- code moderne
- approche héritée
- approche moderne
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Apprenez à ajouter des en‑têtes et pieds de page aux présentations PowerPoint PPT, PPTX et ODP en Java en utilisant les API Aspose.Slides héritées et modernes."
---
{{% alert color="info" %}}

Une nouvelle API Aspose.Slides pour Java a été publiée et ce produit unique prend désormais en charge la génération de documents PowerPoint à partir de zéro ainsi que l'édition des documents existants.

{{% /alert %}} 
## **Prise en charge du code hérité**
Afin d'utiliser le code hérité développé avec les versions d'Aspose.Slides pour Java antérieures à 13.x, vous devez apporter quelques modifications mineures à votre code et celui-ci fonctionnera comme auparavant. Toutes les classes qui étaient présentes dans l'ancienne version d'Aspose.Slides pour Java sous les espaces de noms Aspose.Slide et Aspose.Slides.Pptx sont désormais fusionnées dans un seul espace de noms Aspose.Slides. Veuillez consulter le fragment de code simple ci‑dessus pour ajouter un en‑tête et un pied de page à une présentation avec l'API legacy d'Aspose.Slides et suivre les étapes décrivant comment migrer vers la nouvelle API fusionnée.
## **Approche legacy d'Aspose.Slides pour Java**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SetPPTXFooter-SetPPTXFooter.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SetPPTFooter-SetPPTFooter.java" >}}
## **Nouvelle approche d'Aspose.Slides pour Java 13.x**
{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SetPresentationFooter-SetPresentationFooter.java" >}}