---
title: Exigences du système
type: docs
weight: 60
url: /fr/python-java/system-requirements/
keywords:
- exigences du système
- Python
- Java
- JPype
- Windows
- Linux
- macOS
- Aspose.Slides
description: "Vérifiez les exigences du système d'exploitation, de Python, de Java et de JPype pour exécuter Aspose.Slides for Python via Java sur Windows, Linux et macOS."
---
## **Vue d'ensemble**

Aspose.Slides for Python via Java crée, modifie, convertit et rend des présentations sans que Microsoft PowerPoint ne soit installé. Il utilise JPype pour accéder à la bibliothèque Java depuis Python, de sorte que l’environnement doit prendre en charge Python, Java et JPype ensemble.

## **Systèmes d'exploitation pris en charge**

Le [package Aspose.Slides](https://pypi.org/project/aspose-slides-java/) prend en charge les familles de systèmes d'exploitation suivantes :

- Windows
- Linux
- macOS

Choisissez une version du système d'exploitation prise en charge par les versions de Python, Java et JPype que vous avez sélectionnées. La simple disponibilité de Java ne garantit pas la compatibilité avec le package Python et son pont.

## **Exigences pour Python, Java et JPype**

| Composant | Exigence |
| --- | --- |
| Python | Le package Aspose.Slides indique la prise en charge de Python 3.7 à 3.14. La version JPype sélectionnée doit prendre en charge la même version de Python ; par exemple, [JPype1 1.7.1](https://pypi.org/project/jpype1/1.7.1/) nécessite Python 3.8 ou supérieur. |
| Java | Installez un environnement d'exécution Java ou un JDK compatible avec la version JPype sélectionnée. Les [prérequis JPype](https://jpype.readthedocs.io/en/latest/userguide.html#prerequisites) actuels spécifient Java 11 ou supérieur. Java 8 ne peut pas exécuter JPype1 1.7.1. |
| JPype | Installez le package JPype1 pour votre interpréteur Python, votre système d'exploitation et votre architecture CPU. |
| Architecture CPU | Python et la Machine Virtuelle Java (JVM) doivent utiliser des architectures compatibles. Par exemple, un interpréteur Python 64 bits nécessite une JVM 64 bits compatible. |

Sur Apple Silicon, Python et Java doivent tous deux utiliser ARM64 ou tous deux x64. Une JVM qui fonctionne de manière indépendante peut néanmoins échouer à se charger via JPype si son architecture diffère de celle de Python.

Pour un nouvel environnement, Python 3.12, JDK 17 et JPype1 1.7.1 constituent un point de départ approprié. Cette combinaison a été vérifiée avec Aspose.Slides for Python via Java 26.6.0 sous Windows. D'autres combinaisons doivent satisfaire aux exigences des trois composants.

Pour la configuration de l’environnement et un exemple de vérification fonctionnel, consultez [Installation](/slides/fr/python-java/installation/).

## **Dépendances supplémentaires**

Une roue JPype précompilée compatible ne nécessite pas de compilateur C++. Si JPype doit être construit à partir du source, installez un compilateur C++ compatible ainsi que les fichiers de développement Python requis par votre plateforme. Consultez les [instructions d'installation de JPype](https://jpype.readthedocs.io/en/latest/install.html) pour les exigences de construction et le dépannage.

## **FAQ**

**Dois‑je installer Microsoft PowerPoint ?**

Non. Aspose.Slides traite les présentations de façon indépendante de PowerPoint. Python, Java et JPype restent requis.

**Puis‑je utiliser Python 3.7 avec n'importe quelle version de JPype ?**

Non. Bien que le package Aspose.Slides indique la prise en charge de Python 3.7, JPype1 1.7.1 nécessite Python 3.8 ou supérieur. Choisissez des versions dont les exigences se recoupent.

**Puis‑je mélanger Python 32 bits avec Java 64 bits ?**

Non. JPype charge la JVM dans le processus Python, de sorte que Python et Java doivent avoir des architectures compatibles. La même exigence s'applique à ARM64 et x64 sur macOS.