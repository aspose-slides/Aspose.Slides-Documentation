---
title: Créer une présentation - API PowerPoint C++
linktitle: Créer une présentation
type: docs
weight: 10
url: /cpp/create-presentation/
description: Pour créer une présentation PowerPoint dans l'API C++, veuillez suivre les étapes mentionnées dans cet article. Le code ajoute une ligne à la première diapositive de la présentation.
---

## **Créer une présentation PowerPoint**
Pour ajouter une simple ligne à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. Obtenez la référence d'une diapositive en utilisant son index.
1. Ajoutez une forme AutoShape de type ligne en utilisant la méthode AddAutoShape exposée par l'objet Shapes.
1. Écrivez la présentation modifiée en tant que fichier PPTX.

Dans l'exemple donné ci-dessous, nous avons ajouté une ligne à la première diapositive de la présentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateNewPresentation-CreateNewPresentation.cpp" >}}