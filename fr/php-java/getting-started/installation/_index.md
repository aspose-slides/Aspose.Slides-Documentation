---
title: Installation
type: docs
weight: 70
url: /fr/php-java/installation/
keywords:
- installer Aspose.Slides
- télécharger Aspose.Slides
- utiliser Aspose.Slides
- installation Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Installez rapidement Aspose.Slides pour PHP via Java. Guide étape par étape, exigences système et exemples de code — commencez à travailler avec les présentations PowerPoint dès aujourd'hui!"
---

## **Configurer l'environnement**

1. Installer PHP 7, ajouter le chemin de PHP à la variable système `PATH` et définir `allow_url_include` sur `On` dans le fichier `php.ini`.
2. Installer JRE 8. Définir la variable d’environnement `JAVA_HOME` sur le chemin du JRE installé.
3. Installer Apache Tomcat 8.0.

## **Télécharger Aspose.Slides pour PHP via Java** 

`packagist` est le moyen le plus simple de télécharger [Aspose.Slides for PHP via Java](https://packagist.org/packages/aspose/slides). 

Pour installer Aspose.Slides à l’aide de Packagist, exécutez cette commande : 
   ```bash
   composer require aspose/slides
   ```


## **Configurer Apache Tomcat**

1. Télécharger PHP/Java Bridge (`php-java-bridge_x.x.x_documentation.zip`) depuis http://php-java-bridge.sourceforge.net/pjb/download.php et extraire le fichier `JavaBridge.war` dans le dossier `webapps` de Tomcat.
2. Démarrer le service Apache Tomcat.
3. Télécharger [“Aspose.Slides for PHP via Java”](https://downloads.aspose.com/slides/php-java) et l’extraire dans le dossier `aspose.slides`. Copier le fichier `jar/aspose-slides-x.x-php.jar` dans le dossier `webapps\JavaBridge\WEB-INF\lib`. Si vous utilisez **PHP 8**, remplacez le `Java.inc` original du PHP-Java Bridge par le `Java.inc` provenant de `Java.inc.php8.zip`.
4. Redémarrer le service Apache Tomcat.
5. Exécuter `example.php` dans le dossier `aspose.slides` pour lancer l’exemple avec cette commande :
   ```bash
   php example.php
   ```


## **FAQ**

**Comment vérifier que Aspose.Slides est correctement intégré ?**

Construisez votre projet, créez une instance d’une [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) vierge et enregistrez‑la sous un nouveau nom. Si le fichier est créé sans lever d’exception, la bibliothèque a été intégrée avec succès.

**Comment limiter la consommation de mémoire lors du traitement de présentations volumineuses ?**

Augmentez les limites de mémoire de la JVM uniquement autant que nécessaire, et fermez chaque instance de [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) dans un bloc `finally` pour libérer rapidement le cache. Cela empêche les erreurs de dépassement de mémoire et maintient une utilisation globale de la mémoire prévisible lors des opérations par lots.

**Puis‑je exclure les formats d’exportation indésirables pour réduire la taille finale du JAR ?**

Les versions actuelles d’Aspose.Slides sont distribuées sous forme d’une bibliothèque monolithique unique, vous ne pouvez donc pas désactiver des exportateurs spécifiques comme PDF ou SVG lors de la compilation.