---
title: Exigences du système
type: docs
weight: 80
url: /fr/cpp/system-requirements/
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
- C++
- Aspose.Slides
description: "Découvrez les exigences système d'Aspose.Slides pour C++. Assurez une prise en charge transparente de PowerPoint et OpenDocument sous Windows, Linux et macOS."
---
## **Introduction**

Aspose.Slides ne nécessite pas l'installation de Microsoft PowerPoint car Aspose.Slides est un moteur indépendant de création, conversion, mise en page et rendu de documents Microsoft PowerPoint.

## **Systèmes d'exploitation pris en charge**
Aspose.Slides pour C++ est une bibliothèque native C++. Aspose.Slides pour C++ prend en charge les systèmes d'exploitation et plateformes 64 bits et 32 bits suivants :

### **Windows**
- Microsoft Windows Server 2008 (x64, x86)
- Microsoft Windows Server 2012 (x64, x86)
- Microsoft Windows Server 2012 R2 (x64, x86)
- Microsoft Windows Server 2016 (x64, x86)
- Microsoft Windows Server 2019 (x64, x86)
- Microsoft Windows XP (x64, x86)
- Microsoft Windows 7 (x64, x86)
- Microsoft Windows 8, 8.1 (x64, x86)
- Microsoft Windows 10 (x64, x86)

### **Linux**
- OS Ubuntu 16.04 ou version ultérieure.
- CentOS 8 ou version ultérieure.
- Fedora 24 ou version ultérieure.
- Et d'autres Linux x86_64 avec glibc 2.23 ou version ultérieure.

### **macOS**
- macOS Monterey 12.1 ou version ultérieure.

## **Environnements de développement**
Vous pouvez utiliser Aspose.Slides pour C++ lors du développement d'applications pour Windows, Linux ou macOS.

### **Windows**
- Microsoft Visual Studio 2017 ou version ultérieure.
- CMake 3.18 ou version ultérieure.

### **Linux**
- Clang 3.9 ou version ultérieure.
- GCC 6.1 ou version ultérieure.
- CMake 3.18 ou version ultérieure.

### **macOS**
- Xcode 13.4 ou version ultérieure.

## **FAQ**

**Dois-je installer Microsoft PowerPoint pour les conversions et le rendu ?**

Non, PowerPoint n'est pas requis ; Aspose.Slides est un moteur autonome pour [créer](/slides/fr/cpp/create-presentation/), modifier, [convertir](/slides/fr/cpp/convert-presentation/) et [rendre](/slides/fr/cpp/convert-powerpoint-to-png/) les présentations.

**Quelles polices sont nécessaires pour un rendu correct ?**

En pratique, les polices utilisées dans la présentation ou les [substituts](/slides/fr/cpp/font-substitution/) appropriés doivent être disponibles. Pour garantir un rendu cohérent sous Linux/macOS, il est recommandé d'installer des paquets de polices courants.

**Pourquoi une police personnalisée s'affiche-t-elle comme une police de secours ou du texte manquant sous Linux ?**

Si le fichier de police comporte des entrées de table de noms incohérentes ou corrompues, la pile de correspondance des polices sous Linux (FreeType/fontconfig) peut sélectionner un enregistrement invalide, entraînant une police non résolue. Utiliser une version de police avec des enregistrements de table de noms corrigés ou installer un remplacement cohérent résout le problème.