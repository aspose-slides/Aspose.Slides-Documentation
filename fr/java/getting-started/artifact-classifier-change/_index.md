---
title: Déclaration
type: docs
weight: 60
url: /fr/java/artifact-classifier-change/
keywords:
- classificateur Aspose.Slides
- classificateur d'artefact
- utiliser Aspose.Slides
- installation Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Aspose.Slides pour Java utilise désormais le classificateur jdk8 au lieu de jdk16. Découvrez pourquoi et comment mettre à jour vos dépendances."
---
## Changement de classificateur d’artefact de `jdk16` à `jdk8`

À partir de la version **26.10**, nous avons modifié le classificateur utilisé dans nos artefacts publiés, passant de **`jdk16`** (Java 6) à **`jdk8`** (Java 8).

### Ce qui a changé

| | Avant | Après |
|---|---|---|
| Classificateur | `jdk16` | `jdk8` |
| Version Java minimale | Java 1.6 | Java 8 |

**Avant :**
```
com.aspose:aspose-slides:26.10:jdk16
```

**Après :**
```
com.aspose:aspose-slides:26.10:jdk8
```

### Pourquoi nous avons apporté cette modification

Après un examen interne, nous avons décidé d’**abandonner la prise en charge des versions Java anciennes** qui ne plus apportaient de valeur et qui gênaient activement la maintenance. Java 8 a été sélectionné comme nouvelle base sûre pour tous les consommateurs.

Dans ce cadre, le classificateur a été mis à jour pour refléter la version minimale réellement prise en charge. Nous nous sommes également alignés sur la convention de nommage actuelle d’Oracle, où le produit est officiellement désigné **JDK 8** (plutôt que le format hérité `1.8`).

### Ce que vous devez faire

1. **Mettre à jour le classificateur** dans vos déclarations de dépendances de `jdk16` à `jdk8`.

   **Maven :**
   ```xml
   <dependency>
     <groupId>com.aspose</groupId>
     <artifactId>aspose-slides</artifactId>
     <version>26.10</version>
     <classifier>jdk8</classifier>
   </dependency>
   ```

   **Gradle :**
   ```groovy
   implementation 'com.aspose:aspose-slides:26.10:jdk8'
   ```

2. **Vérifier votre environnement d'exécution** est Java 8 ou supérieur.

3. **Actualiser les fichiers de verrouillage** ou les caches de dépendances qui fixent l'ancien classificateur.

### Note de migration : jdk16 et jdk8

À partir de la version 26.10, les classificateurs jdk16 et jdk8 fourniront des JAR compatibles Java 8 (compilés avec la compatibilité source/target réglée sur Java 8).

- `jdk16` → continue d'être publié pour la compatibilité descendante (intégrations existantes).  
- `jdk8` → introduit comme le nouveau classificateur préféré pour les environnements Java 8.

⚠️ Remarque : cette phase de double publication est prévue pour se terminer le 31 mars 2027. Après cette date, le classificateur jdk16 sera retiré et seul jdk8 sera pris en charge.

### Notes de compatibilité

- Le classificateur `jdk16` **n’est plus publié** après le **31 mars 2027**.  
- Si vous avez encore besoin de la prise en charge de Java 1.6, veuillez rester sur la version majeure précédente jusqu’à ce que vous puissiez migrer.

### Besoin d'aide ?

Si vous rencontrez des problèmes lors de la migration, veuillez contacter [Assistance Aspose](https://forum.aspose.com/) pour obtenir de l’aide.