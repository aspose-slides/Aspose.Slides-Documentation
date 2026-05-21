---
title: Exigences du système
type: docs
weight: 80
url: /fr/java/system-requirements/
keywords:
- exigences du système
- système d'exploitation
- installation
- dépendances
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Découvrez les exigences du système d'Aspose.Slides pour Java. Assurez une prise en charge transparente de PowerPoint et OpenDocument sous Windows, Linux et macOS."
---
## **Vue d'ensemble**
Aspose.Slides for Java ne nécessite pas l'installation de Microsoft PowerPoint, car Aspose.Slides est lui‑même un moteur de création, de conversion, de mise en page et de rendu de documents Microsoft PowerPoint.

## **Systèmes d'exploitation pris en charge**
Aspose.Slides for Java prend en charge tout système d'exploitation 32 bits ou 64 bits exécutant le runtime Java, notamment :

### **Windows**
- Microsoft Windows 2003 Server ( x64, x86)
- Microsoft Windows 2008 Server ( x64, x86)
- Microsoft Windows 2012 Server ( x64, x86)
- Microsoft Windows 2012 R2 Server ( x64, x86)
- Microsoft Windows 2016 Server ( x64, x86)
- Microsoft Windows 2019 Server ( x64, x86)
- Microsoft Windows Vista ( x64, x86)
- Microsoft Windows XP ( x64, x86)
- Microsoft Windows 7 ( x64, x86)
- Microsoft Windows 8, 8.1 ( x64, x86)
- Microsoft Windows 10 ( x64, x86)

### **Linux**
- Linux (Ubuntu, OpenSUSE, CentOS et autres)

### **Mac**
- Mac OS X

## **Versions Java prises en charge**
Aspose.Slides for Java prend en charge J2SE 6.0 (Java 1.6) et supérieur.

## **FAQ**

**Dois-je installer Microsoft PowerPoint pour les conversions et le rendu ?**

Non, PowerPoint n’est pas requis ; Aspose.Slides est un moteur autonome pour [créer](/slides/fr/java/create-presentation/), modifier, [convertir](/slides/fr/java/convert-presentation/) et [rendre](/slides/fr/java/convert-powerpoint-to-png/) les présentations.

**Quelles polices sont nécessaires pour un rendu correct ?**

En pratique, les polices utilisées dans la présentation ou les [substituts](/slides/fr/java/font-substitution/) appropriés doivent être disponibles. Pour garantir un rendu cohérent sous Linux/macOS, il est recommandé d’installer des packages de polices courants.

**Pourquoi une police personnalisée s’affiche-t-elle comme une police de secours ou du texte manquant sous Linux ?**

Si le fichier de police possède des entrées de table de noms incohérentes ou corrompues, la pile de correspondance des polices sous Linux (FreeType/fontconfig) peut sélectionner un enregistrement invalide, entraînant une police non résolue. L’utilisation d’une version de police avec des enregistrements de table de noms corrigés ou l’installation d’un remplacement cohérent résout le problème.