---
title: Exceptions et erreurs courantes liées aux polices sous Linux
type: docs
weight: 200
url: /fr/java/common-errors-involving-fonts/
aliases:
  - /java/technical-articles/common-errors-involving-fonts/
keywords: "Exception de police, Erreur de police, Linux, Java, Aspose.Slides for Java"
description: "Exceptions et erreurs de police sous Linux"
---
## **Vue d'ensemble**

Lorsque Aspose.Slides est utilisé sous Linux, des problèmes liés aux polices peuvent survenir si le processus Java ne peut pas accéder aux dossiers de polices requis ou au répertoire temporaire, si aucune police n’est installée sur le système, ou si des bibliothèques système requises telles que fontconfig ou libfreetype sont manquantes.

Cet article décrit les erreurs et exceptions courantes liées aux polices sous Linux et propose des solutions pour les résoudre. Il explique comment vérifier l’accès aux répertoires de polices et TEMP, installer les polices et bibliothèques requises, et utiliser `FontsLoader` pour charger les polices sans les installer à l’échelle du système.

## **Texte ou images manquants (EMF ou WMF) lors de l’exécution du code sous Linux**

Ce problème se produit dans les systèmes soumis aux restrictions suivantes :

1. Lorsque aucune police n’est installée ou que le dossier de polices du processus Java ne peut pas être accessible
2. Lorsque le répertoire TEMP ne peut pas être accessible.

### **Solution**

Vérifiez et confirmez que l’accès au répertoire TEMP et au dossier de polices a été accordé. 

{{% alert color="warning" %}}
Dans certains cas, il peut vous être impossible d’accorder l’accès aux dossiers en raison de restrictions imposées par l’environnement ou par une politique de sécurité. Essayez ces solutions de contournement :
{{% /alert %}}

**Solution de contournement**

Utilisez [FontsLoader](https://reference.aspose.com/slides/fr/java/com.aspose.slides/FontsLoader) pour charger les polices requises sans les installer :
```
FontsLoader.loadExternalFonts(pathToFontsFolders);
```

Si le répertoire TEMP ne peut pas être accessible, utilisez ce code pour spécifier un autre répertoire comme TEMP pour Java :
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
    // ....

} finally {
    System.setProperty("java.io.tmpdir", oldValue);
}
```

## **Exception : InvalidOperationException : Impossible de trouver des polices installées sur le système**

Cette exception se produit lorsque

1) le processus Java ne peut pas accéder au dossier de polices  
2) aucune police n’a été installée.

### **Solution**

1. Vérifiez et confirmez que l’accès au dossier de polices pour le processus Java a été accordé.  
2. Installez quelques polices ou utilisez [FontsLoader](https://reference.aspose.com/slides/fr/java/com.aspose.slides/FontsLoader).  
3. Installer des polices.

   * Ubuntu :  
     ```
     sudo apt-get update
     sudo apt-get install -y fonts-dejavu-core
     fc-cache -fv
```

   * CentOS :  
     ```
     sudo yum makecache
     sudo yum -y install dejavu-sans-fonts
     fc-cache -fv
```

   * Utilisation de [FontsLoader](https://reference.aspose.com/slides/fr/java/com.aspose.slides/FontsLoader) :  
     ```
     FontsLoader.loadExternalFonts(pathToFontsFolders);
```

## **Exception : InternalError : InvocationTargetException**

Lors de la conversion d’un fichier PPTX en PDF sous Linux, la conversion peut échouer avec `java.lang.InternalError: java.lang.reflect.InvocationTargetException`. Si l’erreur sous‑jacente indique `Cannot load from short array because "sun.awt.FontConfiguration.head" is null`, la configuration des polices sous Linux est indisponible ou son cache n’a pas été initialisé.

### **Solution**

Installez fontconfig et reconstruisez le cache des polices :
```bash
sudo yum install -y fontconfig
sudo fc-cache --force
```

## **Exception : NoClassDefFoundError : Impossible d’initialiser la classe com.aspose.slides.internal.ey.this**

Cette exception se produit sur un système Linux dépourvu de fontconfig et de polices. 

### **Solution**

Installez fontconfig :

* Ubuntu :  
  ```
  sudo apt-get update
  sudo apt-get -y install fontconfig
  ```

* CentOS :  
  ```
  sudo yum makecache
  sudo yum -y install fontconfig
  ```

De plus, certaines versions d’open‑jdk (par exemple, **alpine JDK**) nécessitent également **des polices installées**.

* Ubuntu :  
  ```
  sudo apt-get install -y fonts-dejavu-core
  fc-cache -fv
  ```

* CentOS :  
  ```
  sudo yum -y install dejavu-sans-fonts
  fc-cache -fv
  ```

## **Exception : UnsatisfiedLinkError : libfreetype.so.6 : Impossible d’ouvrir le fichier d’objet partagé : Aucun fichier ou répertoire de ce type**

Cette exception se produit sur un système Linux qui ne possède pas la bibliothèque libfreetype. 

### **Solution**

Installez libfreetype et fontconfig :

* Ubuntu :  
  ```
  sudo apt-get update
  sudo apt-get install libfreetype6
  sudo apt-get -y install fontconfig
  ```

* CentOS :  
  ```
  sudo yum makecache
  sudo yum install libfreetype6
  sudo yum -y install fontconfig
  ```

{{% alert title="TIP" color="info" %}} 
N’oubliez pas d’installer des polices ou d’utiliser FontsLoader.
{{% /alert %}}