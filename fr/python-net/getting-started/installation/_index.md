---
title: Installation
type: docs
weight: 70
url: /fr/python-net/installation/
keywords:
- télécharger Aspose.Slides
- installer Aspose.Slides
- utiliser Aspose.Slides
- installation d'Aspose.Slides
- Windows
- macOS
- Python
description: "Découvrez comment installer rapidement Aspose.Slides for Python via .NET. Guide étape par étape, exigences système et exemples de code — commencez à travailler avec des présentations PowerPoint dès aujourd'hui !"
---

Le package Aspose.Slides pour Python via .NET comprend les bibliothèques .NET dont il a besoin, donc une installation distincte de .NET n'est pas requise. Cependant, en fonction de votre plateforme, vous devrez peut-être installer des dépendances spécifiques pour .NET et répondre à certaines exigences.

## **Windows**

**Exigences Système**

Vérifiez et confirmez que les spécifications de votre machine répondent ou dépassent les [exigences système](/slides/fr/python-net/system-requirements/).

### **Installer Aspose.Slides**

`pip` est le moyen le plus simple de télécharger et d'installer [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose.slides/) sur des appareils Windows.

Pour installer Aspose.Slides, exécutez cette commande :  `pip install aspose.slides`

**Utiliser Aspose.Slides**

Testez votre installation d'Aspose.Slides en exécutant ce code pour créer une présentation PowerPoint :

```python
# Imports Aspose.Slides for Python via .NET module
import aspose.slides as slides

# Instancie un objet Presentation qui représente un fichier de présentation
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **macOS**

**Exigences Système**

Vérifiez et confirmez que les spécifications de votre machine répondent ou dépassent les [exigences système](/slides/fr/python-net/system-requirements/).

### **Prérequis**

**Python avec bibliothèques partagées**

Il existe différentes manières d'installer Python sur macOS, mais nous vous recommandons fortement d'utiliser l'[outil pyenv](https://github.com/pyenv/pyenv#homebrew-in-macos).

Après avoir installé et configuré pyenv, vous devez installer Python avec des bibliothèques partagées en exécutant ces commandes dans l'application Terminal :

1. Installer Python : `env PYTHON_CONFIGURE_OPTS="--enable-shared" pyenv install --verbose 3.9.13`
2. Le configurer comme installation globale de Python : `pyenv global 3.9.13`
3. Le configurer comme installation de shell Python : `pyenv shell 3.9.13`
4. Créer un lien symbolique pour la bibliothèque libpython dans un répertoire de bibliothèque système : `ln -s /Users/<username>/.pyenv/versions/3.9.13/lib/libpython3.9.dylib /usr/local/lib/libpython3.9.dylib` 

Remarque : Python 3.5 et supérieur est requis. La version de Python 3.9.13 a simplement été utilisée comme exemple.

**Installer la bibliothèque libgdiplus**

La bibliothèque libgdiplus est une implémentation de GDI+ Windows pour macOS et Linux que .NET utilise sur ces plateformes. Pour installer cette bibliothèque, exécutez cette commande : `brew install mono-libgdiplus` 

### **Installer Aspose.Slides**

`pip` est le moyen le plus simple de télécharger et d'installer [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose.slides/) sur des appareils macOS. Pour installer Aspose.Slides, exécutez cette commande : `pip install aspose.slides`

**Utiliser Aspose.Slides**

Testez votre installation d'Aspose.Slides en exécutant ce code pour créer une présentation PowerPoint :

```python
# Imports Aspose.Slides for Python via .NET module
import aspose.slides as slides

# Instancie un objet Presentation qui représente un fichier de présentation
with slides.Presentation() as presentation:    
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```