---
title: Installation
type: docs
weight: 70
url: /fr/python-net/installation/
keywords:
- télécharger Aspose.Slides
- installer Aspose.Slides
- utiliser Aspose.Slides
- installation Aspose.Slides
- Windows
- macOS
- Python
description: "Apprenez comment installer rapidement Aspose.Slides pour Python via .NET. Guide étape par étape, exigences système et extraits de code — commencez à travailler avec des présentations PowerPoint dès aujourd'hui!"
---

## **Vue d'ensemble**

Le package Aspose.Slides for Python via .NET inclut toutes les bibliothèques .NET essentielles, ce qui signifie qu'il n'est pas nécessaire d'installer .NET séparément. Cela simplifie le processus d'installation et permet aux développeurs de commencer à travailler avec des présentations immédiatement. Cependant, il est important de noter que, selon votre système d'exploitation ou votre environnement, vous devrez peut‑être toujours installer certaines dépendances spécifiques à la plateforme requises par .NET. De plus, certaines exigences système doivent être respectées pour garantir une pleine compatibilité et le bon fonctionnement du package.

## **Windows**

**Exigences système**

Vérifiez et confirmez que les spécifications de votre machine répondent ou dépassent les [exigences système](/slides/fr/python-net/system-requirements/).

### **Installer Aspose.Slides**

`pip` est le moyen le plus simple de télécharger et d'installer [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose-slides/) sous Windows.

Pour installer Aspose.Slides, exécutez la commande suivante :
```sh
pip install aspose-slides
```


**Utiliser Aspose.Slides**

Testez votre installation Aspose.Slides en exécutant le code suivant pour créer une présentation PowerPoint :
```python
# Importer le module Aspose.Slides pour Python via .NET.
import aspose.slides as slides

# Instancier la classe Presentation qui représente un fichier de présentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```


## **macOS**

**Exigences système**

Vérifiez et confirmez que les spécifications de votre machine répondent ou dépassent les [exigences système](/slides/fr/python-net/system-requirements/).

### **Prérequis**

**Python avec bibliothèques partagées**

Il existe plusieurs façons d'installer Python sur macOS, mais nous recommandons fortement d'utiliser l'[outil pyenv](https://github.com/pyenv/pyenv#homebrew-in-macos).

Après avoir installé et configuré **pyenv**, installez Python avec des bibliothèques partagées en exécutant les commandes suivantes dans l'application Terminal :

1. Installez Python :
```sh
env PYTHON_CONFIGURE_OPTS="--enable-shared" pyenv install --verbose 3.9.13
```


2. Définissez‑le comme version Python globale :
```sh
pyenv global 3.9.13
```


3. Définissez‑le comme version Python spécifique au shell :
```sh
pyenv shell 3.9.13
```


4. Créez un lien symbolique pour la bibliothèque libpython dans un répertoire de bibliothèque système :
```sh
ln -s /Users/<username>/.pyenv/versions/3.9.13/lib/libpython3.9.dylib /usr/local/lib/libpython3.9.dylib
```


Remarque : Python 3.5 ou supérieur est requis. La version 3.9.13 est utilisée ici uniquement à titre d'exemple.

**Installer la bibliothèque libgdiplus**

La bibliothèque **libgdiplus** est une implémentation Windows GDI+ pour macOS et Linux dont .NET dépend pour les fonctions graphiques sur ces plateformes.  
Pour installer cette bibliothèque sur macOS, exécutez la commande suivante :
```sh
brew install mono-libgdiplus
```


### **Installer Aspose.Slides**

`pip` est le moyen le plus simple de télécharger et d'installer [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose-slides/) sur macOS.

Pour installer Aspose.Slides, exécutez la commande suivante :
```sh
pip install aspose-slides
```


**Utiliser Aspose.Slides**

Testez votre installation Aspose.Slides en exécutant le code suivant pour créer une présentation PowerPoint :
```python
# Importer le module Aspose.Slides pour Python via .NET.
import aspose.slides as slides

# Instancier la classe Presentation qui représente un fichier de présentation.
with slides.Presentation() as presentation:    
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Puis‑je installer Aspose.Slides dans un environnement virtuel ?**

Oui, vous pouvez l'installer dans n'importe quel environnement virtuel Python en utilisant `pip`. Assurez‑vous simplement que l'environnement a accès aux dépendances natives requises selon votre système d'exploitation.

**Puis‑je utiliser Aspose.Slides dans des conteneurs Docker ?**

Oui, mais vous devez vous assurer que votre image Docker inclut les bibliothèques natives requises (**libgdiplus**, paquets de polices, etc.) ainsi que la version correcte de Python.

**Existe‑t‑il une version gratuite ou une limitation d’essai ?**

Oui, par défaut, Aspose.Slides fonctionne en mode évaluation, ce qui ajoute des filigranes et peut imposer d'autres limitations. Pour supprimer ces restrictions, vous devez appliquer une [licence](/slides/fr/python-net/licensing/) valide.