---
title: Démarrage
type: docs
weight: 10
url: /fr/java/getting-started/
keywords:
- démarrage
- exigences du système
- installation
- première présentation
- Maven
- traitement PPT
- traitement PPTX
- traitement ODP
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Le chemin d’un nouveau projet Java à une première présentation enregistrée avec Aspose.Slides : vérifiez les exigences, ajoutez la bibliothèque depuis le dépôt Maven d’Aspose, exécutez un premier programme et poursuivez avec les tâches courantes."
---
## **Vue d'ensemble**

Suivez les quatre étapes ci‑dessous dans l’ordre. Chaque étape indique ce qu’il faut faire et renvoie à l’article contenant les détails. L’évaluation, la licence et le support sont présentés après les étapes.

## **Étape 1 : Vérifier les exigences du système**

Aspose.Slides for Java est un fichier JAR unique sans code natif, il fonctionne donc sur tout système d’exploitation disposant d’un environnement d’exécution Java pris en charge. [System Requirements](/slides/fr/java/system-requirements/) répertorie les systèmes d’exploitation et les versions de Java pris en charge. Le projet et les commandes des étapes suivantes nécessitent JDK 11 ou une version ultérieure et, pour la voie Maven, [Apache Maven](https://maven.apache.org/install.html).

## **Étape 2 : Ajouter la bibliothèque à votre projet**

Aspose.Slides for Java est publié dans le propre dépôt Maven d’Aspose, et non dans Maven Central. Choisissez l’une de ces voies :

- Avec Maven : déclarez le dépôt `https://releases.aspose.com/java/repo/` dans votre *pom.xml* et ajoutez la dépendance `com.aspose:aspose-slides` avec le classificateur `jdk16`.
- Sans Maven : téléchargez le fichier JAR dont le nom se termine par *-jdk16.jar* depuis le dépôt et placez‑le sur le chemin de classe.

Sur Linux, installez également la bibliothèque fontconfig et au moins une police. Sans elles, l’enregistrement d’une présentation échoue avec l’erreur « Fontconfig head is null, check your fonts or fonts configuration ».

[Installation](/slides/fr/java/installation/) fournit les entrées *pom.xml*, le téléchargement du JAR et la commande Linux.

## **Étape 3 : Créer votre première présentation**

Le [démarrage rapide sur la page d’accueil d’Aspose.Slides for Java](/slides/fr/java/#your-first-presentation) est un projet Maven complet : un fichier *pom.xml* et un programme qui ajoute une forme nuage avec du texte à une diapositive et enregistre la présentation au format PPTX. Vous l’exécutez avec `mvn compile exec:java`. [Créer des présentations](/slides/fr/java/create-presentation/) explique le même programme étape par étape. Pour ouvrir une présentation existante et l’enregistrer dans un autre format, consultez [Ouvrir des présentations](/slides/fr/java/open-presentation/) et [Enregistrer des présentations](/slides/fr/java/save-presentation/).

## **Étape 4 : Poursuivre avec les tâches courantes**

- [Ouvrir une présentation](/slides/fr/java/open-presentation/)
- [Enregistrer une présentation](/slides/fr/java/save-presentation/)
- [Convertir une présentation en PDF](/slides/fr/java/convert-powerpoint-to-pdf/)
- [Rendu des diapositives en images](/slides/fr/java/convert-slide/)
- [Modifier le texte d’une présentation](/slides/fr/java/manage-text/)
- [Exemples par élément de diapositive](/slides/fr/java/examples/)

## **Évaluation et licence**

Sans licence, Aspose.Slides fonctionne en mode d’évaluation : il ajoute un filigrane à chaque diapositive enregistrée et tronque le texte que votre code lit dans les présentations.

- [Évaluer Aspose.Slides](/slides/fr/java/evaluate-aspose-slides/) décrit les limitations de l’évaluation et comment demander une licence temporaire.
- [Licence](/slides/fr/java/licensing/) montre comment appliquer une licence à partir d’un fichier ou d’un flux.
- [Licence à la consommation](/slides/fr/java/metered-licensing/) couvre la licence facturée à l’usage.
- [Formats de fichiers pris en charge](/slides/fr/java/supported-file-formats/) répertorie les formats qu’Aspose.Slides peut charger et enregistrer.

## **Obtenir de l’aide**

[Support technique](/slides/fr/java/technical-support/) explique comment poser une question sur le [forum de support gratuit](https://forum.aspose.com/c/slides/fr/11) et ce qu’il faut inclure lorsque vous signalez un problème.

## **FAQ**

**Dois‑je installer Microsoft PowerPoint ?**

Non. Aspose.Slides lit et écrit les fichiers de présentation lui‑même et n’utilise pas PowerPoint, il fonctionne donc également sur les serveurs et sous Linux.

**Pourquoi Maven ne trouve‑t‑il pas Aspose.Slides for Java ?**

La bibliothèque n’est pas dans Maven Central. Déclarez le dépôt d’Aspose dans votre *pom.xml*, comme indiqué dans [Installation](/slides/fr/java/installation/), et Maven télécharge la bibliothèque depuis cet emplacement.

**Le classificateur `jdk16` signifie‑t‑il que la bibliothèque nécessite Java 16 ?**

Non. Le classificateur sélectionne la version Java SE de la bibliothèque ; l’autre version est destinée à Android. La même version fonctionne avec les JDK actuels, comme le JDK 21.