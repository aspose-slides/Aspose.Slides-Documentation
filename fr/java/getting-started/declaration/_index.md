---
title: Exigences du Security Manager
type: docs
weight: 190
url: /fr/java/declaration/
keywords:
- Gestionnaire de sécurité
- politique de sécurité
- AllPermission
- autorisations
- bac à sable
- JDK 24
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Quelles autorisations du Security Manager Aspose.Slides for Java et le code qui l'appelle nécessitent sous Java 23 et antérieur, et pourquoi il n'y a rien à configurer sous Java 24 et versions ultérieures."
---
## **Vue d'ensemble**

The Java Security Manager limits what code can do according to a security policy. Java 17 deprecated it for removal ([JEP 411](https://openjdk.org/jeps/411)), and Java 24 disabled it permanently ([JEP 486](https://openjdk.org/jeps/486)). This article explains what Aspose.Slides for Java needs when an application still runs with a Security Manager. If your application does not enable one, which is the default, there is nothing to configure.

## **Java 23 et antérieur**

When a Security Manager is enabled, the security policy must grant these permissions to the Aspose.Slides JAR file and to the application code that calls it:

- `java.util.PropertyPermission "*", "read"`: Aspose.Slides lit les propriétés système.
- `java.io.FilePermission "<<ALL FILES>>", "read"`: Aspose.Slides lit les fichiers de polices et d'autres fichiers.
- `java.io.FilePermission "<<ALL FILES>>", "execute"`: Aspose.Slides lance des programmes du système d'exploitation, par exemple `reg` sous Windows et `fc-match` sous Linux.
- `java.io.FilePermission` avec l'action `write` pour les dossiers où votre application enregistre les fichiers.

Accorder les autorisations au fichier JAR seul n'est pas suffisant : le code qui appelle Aspose.Slides en a également besoin. Accorder `java.security.AllPermission` aux deux fonctionne également.

Sans l'autorisation de lire les propriétés système ou de lancer des programmes, Aspose.Slides échoue dès la première utilisation : la création d'un objet [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/) lance une `ExceptionInInitializerError`. Sans accès en lecture aux fichiers de polices, l’enregistrement d’une présentation au format PDF échoue avec l’erreur "Cannot find any fonts installed on the system".

## **Java 24 et versions ultérieures**

The Security Manager cannot be enabled on Java 24 and later, so there are no permissions to grant. Aspose.Slides runs with the permissions of the account that runs your application. To restrict what an application can access, the OpenJDK project recommends technologies outside the JDK, such as containers, hypervisors, and operating-system sandboxing features. See [JEP 486](https://openjdk.org/jeps/486).

## **FAQ**

**Puis‑je utiliser Aspose.Slides dans un environnement qui exécute des applications sous une politique restrictive du Security Manager ?**

Uniquement si la politique accorde les autorisations listées ci‑dessus à la fois à Aspose.Slides et au code qui l’appelle. Elles incluent la lecture de tous les fichiers et le lancement de tout programme.