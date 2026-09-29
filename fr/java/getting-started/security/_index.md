---
title: Sécurité
type: docs
weight: 160
url: /fr/java/security/
keywords:
- sécurité
- dépendances
- composants tiers
- Maven
- signature JAR
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Examinez comment Aspose.Slides for Java traite les présentations, ce qu’il ajoute aux dépendances de votre projet, comment vérifier le fichier JAR, et quels composants tiers il inclut."
---
## **Introduction**

Cet article regroupe les informations qu’une analyse de sécurité d’une application utilisant Aspose.Slides for Java nécessite généralement : la façon dont la bibliothèque traite les présentations, ce qu’elle ajoute aux dépendances de votre projet, comment vérifier que le fichier JAR provient d’Aspose, et quels composants tiers le fichier JAR contient.

## **Security in Aspose.Slides**

Aspose applique les meilleures pratiques lors du développement de ses produits.

* Aspose.Slides for Java est utilisé pour créer, modifier et convertir des présentations. Il n’exécute pas de scripts dans les présentations. Aspose.Slides analyse la structure de la présentation et permet à votre code de travailler avec le modèle d’objet.
* Aspose.Slides fonctionne comme une bibliothèque qui analyse et interprète les documents sans exécuter de code distant. Tous les produits Aspose s’exécutent sur vos machines. Ils ne transmettent aucune donnée à Aspose. La seule exception est la [licence à la consommation](/slides/fr/java/metered-licensing/)\: si vous l’utilisez, seules les informations d’utilisation de l’API sont traitées.
* Les composants Aspose s’exécutent dans le même contexte utilisateur que les applications classiques. Ainsi, les composants Aspose ne constituent pas un risque pour les ressources système vitales. De plus, lorsqu’un composant Aspose ouvre un document, les macros ne sont pas exécutées automatiquement.

## **Maven Dependencies**

L’artifact Maven d’Aspose.Slides for Java, `com.aspose:aspose-slides`, ne déclare aucune dépendance : son fichier POM ne contient que les coordonnées propres à l’artifact. Lorsque vous l’ajoutez à un projet, Maven ajoute uniquement ce fichier JAR et rien d’autre. Pour lister chaque artifact résolu par votre projet, y compris les dépendances transitives, exécutez cette commande dans le répertoire du projet :

```bash
mvn dependency:tree
```

Dans le projet issu de [Installation](/slides/fr/java/installation/), la sortie indique Aspose.Slides comme la seule dépendance :

```text
[INFO] com.example:hello-slides:jar:1.0
[INFO] \- com.aspose:aspose-slides:jar:jdk16:26.9:compile
```

## **Verify the JAR File**

Aspose signe le fichier JAR. Pour vérifier la signature, exécutez l’outil `jarsigner` du JDK dans le dossier contenant le fichier JAR :

```bash
jarsigner -verify aspose-slides-26.9-jdk16.jar
```

La commande affiche `jar verified.` lorsque la signature est valide et qu’aucune entrée n’a été modifiée depuis la signature du fichier. Ce message ne indique pas le signataire. Pour confirmer qu’Aspose a signé le fichier, ajoutez les options `-verbose` et `-certs` et vérifiez que le certificat du signataire est délivré à `CN=ASPOSE PTY LTD`. Lorsque Maven télécharge le fichier JAR, il vérifie également la somme de contrôle SHA‑1 que le référentiel publie à côté du fichier.

## **Third-Party Components**

Aspose.Slides for Java inclut du code et des données provenant de composants tiers. Ils font partie du fichier JAR, pas d’artifacts Maven séparés, de sorte que `mvn dependency:tree` et d’autres outils qui lisent les dépendances Maven ne les répertorient pas. Le fichier JAR contient l’avis *META-INF/ThirdPartyLicenses-Aspose.Slides for Java.pdf*, qui répertorie les composants et leurs licences :

| Component | License stated in the notice |
|---|---|
| DotNetZip | Microsoft Public License (Ms-PL) |
| Bouncy Castle | MIT-style license |
| Mono | MIT license; some parts under other licenses that the notice lists |
| RSWOP.ICM color profile | Microsoft license terms |
| sRGB_v4_ICC_preference.icc color profile | ICC permission to use, copy, and distribute the unchanged file |
| Apache | Apache License 2.0 |
| ANTLR | BSD License |
| sfntly | Apache License 2.0 |

Pour extraire l’avis du fichier JAR, exécutez l’outil `jar` du JDK dans le dossier contenant le fichier JAR :

```bash
jar xf aspose-slides-26.9-jdk16.jar "META-INF/ThirdPartyLicenses-Aspose.Slides for Java.pdf"
```

## **FAQ**

**Does Aspose.Slides for Java use external packages?**

Il n’a aucune dépendance Maven, comme le montre [Maven Dependencies](#maven-dependencies), mais il inclut les composants tiers listés dans [Third-Party Components](#third-party-components). Incluez à la fois le fichier JAR et ces composants dans votre analyse de sécurité.

**Does Aspose.Slides for Java need network access?**

Non. La création, l’enregistrement et le rendu des présentations fonctionnent sur un système sans aucune connexion réseau. La seule fonctionnalité qui envoie des données à Aspose est la [licence à la consommation](/slides/fr/java/metered-licensing/), qui rapporte l’utilisation de l’API.

**Does Aspose.Slides for Java contain native code?**

Non. Le fichier JAR ne contient que des classes Java et des ressources, il n’ajoute donc aucune bibliothèque native à votre application. Sous Linux, la prise en charge des polices du runtime Java nécessite la bibliothèque fontconfig et les polices du système d’exploitation ; voir [System Requirements](/slides/fr/java/system-requirements/#linux).