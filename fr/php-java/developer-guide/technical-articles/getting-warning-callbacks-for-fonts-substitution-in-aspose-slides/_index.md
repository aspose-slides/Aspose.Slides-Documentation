---
title: Obtenir des rappels d'avertissement pour la substitution de polices dans Aspose.Slides
type: docs
weight: 90
url: /fr/php-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
---

{{% alert color="primary" %}} 

Aspose.Slides pour PHP via Java permet d'obtenir des rappels d'avertissement pour la substitution de polices dans le cas où la police utilisée n'est pas disponible sur la machine pendant le processus de rendu. Les rappels d'avertissement sont utiles pour déboguer les problèmes de polices manquantes ou inaccessibles pendant le processus de rendu.

{{% /alert %}} 

Aspose.Slides pour PHP via Java fournit de simples méthodes d'API pour recevoir des rappels d'avertissement pendant le processus de rendu. Suivez les étapes ci-dessous pour configurer les rappels d'avertissement :

1. Créez une classe de rappel personnalisée pour recevoir les rappels.
1. Configurez les rappels d'avertissement à l'aide de la classe LoadOptions.
1. Chargez le fichier de présentation utilisant une police pour le texte à l'intérieur qui n'est pas disponible sur votre machine cible.
1. Générez la miniature de la diapositive pour voir l'effet.

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FontSubstitution-FontSubstitution.java" >}}

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Text-FontSubstitution-IWarningCallback.java" >}}