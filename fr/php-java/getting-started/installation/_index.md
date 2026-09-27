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
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Installez Aspose.Slides for PHP via Java sur Linux et Windows : configurez PHP, Java, Apache Tomcat et le PHP/Java Bridge, ajoutez le package avec Composer et vérifiez la configuration avec un petit script."
---
## **Vue d'ensemble**

Aspose.Slides for PHP via Java s’exécute dans deux processus. Votre script PHP utilise des classes PHP qui transmettent chaque appel via le PHP/Java Bridge à Aspose.Slides, qui s’exécute sur Java à l’intérieur d’Apache Tomcat. Cet article explique comment configurer les deux côtés, installer le package avec Composer et exécuter un court script pour vérifier l’installation.

## **Prérequis**

- **PHP 7.0 à 8.3**, avec `allow_url_include = On` dans `php.ini`. Vos scripts chargent la bibliothèque cliente du bridge, `Java.inc`, depuis Tomcat via HTTP. Sous PHP 8.4 et versions ultérieures, `Java.inc` s’arrête avec l’erreur "end() expects exactly 1 argument" chaque fois que l’extension `xml` de PHP est chargée, et les builds Windows de PHP la chargent toujours.
- **[Composer](https://getcomposer.org/)**
- **Java 8 ou version ultérieure.** Un JRE suffit.
- **Apache Tomcat 9.** Le PHP/Java Bridge est construit sur l’API `javax.servlet`, que Tomcat 10 et versions ultérieures ne fournissent plus, de sorte que le bridge ne démarre pas dessus.
- **[PHP/Java Bridge](https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/) 7.2.1**, sa dernière version. Son application web, `JavaBridge.war`, s’exécute dans Tomcat.

Cet article exécute Tomcat et vos scripts PHP sur le même ordinateur. Aspose.Slides ouvre et enregistre les fichiers à l’intérieur de Tomcat, donc chaque chemin que vos scripts lui transmettent doit être valide là‑bas.

## **Installation sur Linux**

Ces commandes installent tout dans votre dossier personnel sous Ubuntu 24.04. Sur d’autres distributions, installez les mêmes paquets avec le gestionnaire de paquets de la distribution.

1. Installez PHP, Composer, Java et les outils de téléchargement, puis activez `allow_url_include` pour la ligne de commande PHP :

   ```bash
   sudo apt-get update
   sudo apt-get install -y php-cli composer default-jre-headless curl unzip
   sudo sed -i 's/^allow_url_include = Off/allow_url_include = On/' "$(php -r 'echo php_ini_loaded_file();')"
   ```

2. Téléchargez Apache Tomcat 9 et PHP/Java Bridge, placez le `JavaBridge.war` du bridge dans le dossier `webapps` de Tomcat, puis démarrez Tomcat. Tomcat décompresse le fichier WAR dans `webapps/JavaBridge` dès le démarrage :

   ```bash
   cd ~
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122.tar.gz
   tar -xzf apache-tomcat-9.0.122.tar.gz
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   unzip -o php-java-bridge.zip JavaBridge.war -d apache-tomcat-9.0.122/webapps
   apache-tomcat-9.0.122/bin/startup.sh
   ```

3. Créez un dossier de projet et installez Aspose.Slides for PHP via Java depuis [Packagist](https://packagist.org/packages/aspose/slides) :

   ```bash
   mkdir ~/hello-slides
   cd ~/hello-slides
   composer require aspose/slides
   ```

4. Arrêtez Tomcat, copiez le fichier JAR Aspose.Slides du package dans le dossier `WEB-INF/lib` du bridge, remplacez le `Java.inc` du bridge par la version PHP 8 du package, puis redémarrez Tomcat :

   ```bash
   ~/apache-tomcat-9.0.122/bin/shutdown.sh
   cp vendor/aspose/slides/fr/jar/aspose-slides-*-php.jar ~/apache-tomcat-9.0.122/webapps/JavaBridge/WEB-INF/lib/
   unzip -o vendor/aspose/slides/fr/Java.inc.php8.zip -d ~/apache-tomcat-9.0.122/webapps/JavaBridge/java/
   ~/apache-tomcat-9.0.122/bin/startup.sh
   ```

   Sous PHP 7, sautez le remplacement de `Java.inc`. Tomcat met quelques secondes à démarrer et doit être en cours d’exécution chaque fois que vos scripts utilisent Aspose.Slides.

## **Installation sur Windows**

1. Installez [PHP 8.3 pour Windows](https://www.php.net/downloads.php?os=windows) et ajoutez son dossier à la variable d’environnement `PATH`. Copiez `php.ini-production` en `php.ini` dans le même dossier. Dans `php.ini`, définissez `allow_url_include = On` et décommentez les lignes `extension_dir = "ext"`, `extension=openssl` et `extension=zip`. Composer a besoin de `openssl` pour télécharger les packages, et de `zip` pour les décompresser, sauf si 7‑Zip est installé ou si une commande `unzip` se trouve dans le `PATH`.
2. Installez [Composer](https://getcomposer.org/download/).
3. Installez Java et définissez la variable d’environnement `JAVA_HOME` pointant vers son dossier. Tomcat ne démarre pas sans cela.
4. Dans l’invite de commandes, téléchargez Apache Tomcat 9 et PHP/Java Bridge, placez le `JavaBridge.war` du bridge dans le dossier `webapps` de Tomcat, puis démarrez Tomcat. Les scripts de Tomcat trouvent Tomcat via la variable `CATALINA_HOME`, donc conservez la même fenêtre d’invite de commandes pour les étapes suivantes. Tomcat décompresse le fichier WAR dans `webapps\JavaBridge` dès le démarrage :

   ```bat
   cd %USERPROFILE%
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122-windows-x64.zip
   tar -xf apache-tomcat-9.0.122-windows-x64.zip
   set CATALINA_HOME=%USERPROFILE%\apache-tomcat-9.0.122
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   tar -xf php-java-bridge.zip -C "%CATALINA_HOME%\webapps" JavaBridge.war
   "%CATALINA_HOME%\bin\startup.bat"
   ```

5. Créez un dossier de projet et installez Aspose.Slides for PHP via Java depuis [Packagist](https://packagist.org/packages/aspose/slides) :

   ```bat
   mkdir %USERPROFILE%\hello-slides
   cd %USERPROFILE%\hello-slides
   composer require aspose/slides
   ```

6. Arrêtez Tomcat, copiez le fichier JAR Aspose.Slides du package dans le dossier `WEB-INF\lib` du bridge, remplacez le `Java.inc` du bridge par la version PHP 8 du package, puis redémarrez Tomcat :

   ```bat
   "%CATALINA_HOME%\bin\shutdown.bat"
   copy vendor\aspose\slides\jar\aspose-slides-*-php.jar "%CATALINA_HOME%\webapps\JavaBridge\WEB-INF\lib\"
   tar -xf vendor\aspose\slides\Java.inc.php8.zip -C "%CATALINA_HOME%\webapps\JavaBridge\java"
   "%CATALINA_HOME%\bin\startup.bat"
   ```

   Sous PHP 7, sautez le remplacement de `Java.inc`. Tomcat met quelques secondes à démarrer et doit être en cours d’exécution chaque fois que vos scripts utilisent Aspose.Slides.

## **Vérifier l'installation**

Enregistrez ce script sous *hello.php* dans le dossier du projet. Il crée une présentation contenant une zone de texte et l’enregistre à côté du script :

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/fr/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $shape->getTextFrame()->setText("Hello, Aspose.Slides!");
    $presentation->save(__DIR__ . "/hello.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Exécutez‑le depuis le dossier du projet :

```bash
php hello.php
```

Le script génère *hello.pptx*, avec une diapositive contenant la zone de texte. Sans licence, la diapositive porte également un filigrane d’évaluation ; voir [Licence](/slides/fr/php-java/licensing/).

Le script inclut directement `aspose.slides.php` : le chargeur automatique de Composer ne peut pas charger ces classes, car elles sont toutes définies dans ce unique fichier. Il transmet également un chemin absolu à `save`, car Aspose.Slides s’exécute à l’intérieur de Tomcat et résout un chemin relatif par rapport au répertoire de travail de Tomcat, pas à celui de votre script.

## **FAQ**

**Comment puis‑je vérifier qu’Aspose.Slides est correctement intégré ?**

Exécutez le script dans [Vérifier l'installation](#verify-the-installation). S’il crée *hello.pptx* sans erreur, PHP, le PHP/Java Bridge et Aspose.Slides fonctionnent ensemble.

**Pourquoi mon script s’arrête avec « Failed opening required 'http://localhost:8080/JavaBridge/java/Java.inc' » ?**

PHP n’a pas pu charger `Java.inc` depuis Tomcat. Si le message précédent indique que le wrapper `http://` est désactivé, activez `allow_url_include = On` dans le fichier `php.ini` utilisé par votre ligne de commande PHP ; `php --ini` indique quel fichier est chargé. Si le message indique « Connection refused », Tomcat n’est pas encore démarré : démarrez‑le ou attendez quelques secondes qu’il le fasse.

**Comment limiter la consommation mémoire lors du traitement de présentations volumineuses ?**

Augmentez les limites de mémoire JVM uniquement selon les besoins, et fermez chaque instance de [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) dans un bloc `finally` afin de libérer le cache rapidement. Cela évite les erreurs d’épuisement de mémoire et maintient une utilisation prévisible de la mémoire lors d’opérations par lots.

**Puis‑je exclure des formats d’exportation indésirables pour réduire la taille finale du JAR ?**

Les versions actuelles d’Aspose.Slides sont distribuées comme une bibliothèque monolithique unique, il n’est donc pas possible de désactiver des exportateurs spécifiques tels que PDF ou SVG lors de la construction.