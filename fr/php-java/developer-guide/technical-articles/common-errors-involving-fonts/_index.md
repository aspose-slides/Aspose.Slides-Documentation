---
title: Exceptions et erreurs courantes liées aux polices sur Linux
type: docs
weight: 200
url: /php-java/technical-articles/common-errors-involving-fonts
keywords: "exception de police, erreur de police, Linux, Java, Aspose.Slides pour PHP via Java"
description: "Exceptions et erreurs de police sur Linux"
---

## **Texte ou images manquants (emf ou wmf) lorsque le code est exécuté sur Linux**

Ce problème survient sur les systèmes avec des restrictions dans ces cas :

1. Lorsque aucune police n'est installée ou lorsque le dossier des polices pour le processus Java ne peut pas être accessible.
2. Lorsque le répertoire TEMP ne peut pas être accessible.

### Solution

Vérifiez et confirmez que l'accès au répertoire TEMP et au dossier des polices a été accordé.

{{% alert color="warning" %}}

Dans certains cas, vous pourriez ne pas être en mesure d'accorder l'accès aux dossiers en raison des restrictions imposées par l'environnement ou une politique de sécurité. Essayez ces solutions de contournement :

{{% /alert %}}

**Solution de contournement**

Utilisez [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader) pour charger les polices requises sans les installer :

```php

```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```php

```

Si le répertoire TEMP ne peut pas être accessible, utilisez ce code pour spécifier un autre répertoire comme TEMP pour Java :
```php

```
String newTempFolder = "pathToTmpFolder";
String oldValue = System.getProperty("java.io.tmpdir");
java.io.File file = new java.io.File(newTempFolder);
if (!file.exists())
    file.mkdir();
System.setProperty("java.io.tmpdir", newTempFolder);
try {

    FontsLoader.loadExternalFonts(pathToFontsFolders);

    Presentation pres = ...
    # ....

} finally {
    System.setProperty("java.io.tmpdir", oldValue);
}
```php

```

## **Exception : InvalidOperationException : Impossible de trouver des polices installées sur le système**

Cette exception se produit lorsque

1) le processus Java ne peut pas accéder au dossier des polices
2) aucune police n'a été installée.

### Solution

1. Vérifiez et confirmez que l'accès au dossier des polices pour le processus Java a été accordé.

2. Installez des polices ou utilisez [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader).

3. Installez des polices.

   * Ubuntu :

```php

     ```
     sudo apt-get update
     sudo apt-get install -y fonts-dejavu-core
     fc-cache -fv
```php

     ```

   * CentOS :

```php

     ```
     sudo yum makecache
     sudo yum -y install dejavu-sans-fonts
     fc-cache -fv
```php

     ```

   * En utilisant [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/FontsLoader) :

```php

     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
```php

     ```

## **Exception : NoClassDefFoundError : Impossible d'initialiser la classe com.aspose.slides.internal.ey.this**

Cette exception se produit sur un système Linux qui n'a pas de fontconfig et de polices.

### Solution :

Installez fontconfig :

* Ubuntu :

```php

  ```
  sudo apt-get update
  sudo apt-get -y install fontconfig
```php

  ```

* CentOS :

```php

  ```
  sudo yum makecache
  sudo yum -y install fontconfig
```php

  ```

De plus, certaines versions d'open-jdk (par exemple, **alpine JDK**) nécessitent également **des polices installées**.

* Ubuntu :

```php

  ```
  sudo apt-get install -y fonts-dejavu-core
  fc-cache -fv
```php

  ```

* CentOS :

```php

  ```
  sudo yum -y install dejavu-sans-fonts
  fc-cache -fv
```php

  ```

## **Exception : UnsatisfiedLinkError : libfreetype.so.6 : impossible d'ouvrir le fichier objet partagé : Aucun fichier ou répertoire de ce type**

Cette exception se produit sur un système Linux qui n'a pas la bibliothèque libfreetype.

### Solution :

Installez libfreetype et fontconfig :

* Ubuntu :

```php

  ```
  sudo apt-get update
  sudo apt-get install libfreetype6
  sudo apt-get -y install fontconfig
```php

  ```

* CentOS :

```php

  ```
  sudo yum makecache
  sudo yum install libfreetype6
  sudo yum -y install fontconfig
```php

  ```

{{% alert title="ASTUCE" color="primary" %}} 

N'oubliez pas d'installer des polices ou d'utiliser FontsLoader.

{{% /alert %}}  