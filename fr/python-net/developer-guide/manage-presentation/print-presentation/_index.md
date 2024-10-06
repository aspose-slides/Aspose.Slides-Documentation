---
title: Impression de Présentation
type: docs
weight: 50
url: /python-net/impression-presentation/
keywords: "Imprimer PowerPoint, PPT, PPTX, Impression de Présentation, Python, Imprimante, Options d'Impression"
description: "Imprimer une présentation PowerPoint en Python"
---
Aspose.Slides pour Python fournit 4 méthodes `print` surchargées qui vous permettent d'imprimer des présentations. Les méthodes surchargées prennent différents arguments, donc vous trouverez toujours une méthode qui convient à vos besoins d'impression.

## **Imprimer sur l'Imprimante par Défaut**

Cette opération d'impression simple est utilisée pour imprimer toutes les diapositives d'une présentation PowerPoint via l'imprimante par défaut du système.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et passez la présentation que vous souhaitez imprimer.
2. Appelez la méthode `print` (sans paramètres).

Ce code Python vous montre comment imprimer une présentation PowerPoint :

```python
import aspose.slides as slides

# Charger la présentation
presentation = slides.Presentation("Print.ppt")

# Appeler la méthode print pour imprimer la présentation entière sur l'imprimante par défaut
presentation.print()
```

## **Imprimer sur une Imprimante Spécifique**

Cette opération est utilisée pour imprimer toutes les diapositives d'une présentation PowerPoint via une imprimante spécifique.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et passez la présentation que vous souhaitez imprimer.
2. Appelez la méthode `print` et passez le nom de l'imprimante en tant que chaîne.

Ce code Python vous montre comment imprimer une présentation PowerPoint en utilisant une imprimante spécifique :

```python
import aspose.slides as slides

try:
    # Charger la présentation
    with slides.Presentation("pres.pptx") as pres:
        # Appeler la méthode print pour imprimer la présentation entière sur l'imprimante souhaitée
        pres.print("Veuillez entrer le nom de votre imprimante ici")
except:
    print("Veuillez définir le nom de l'imprimante en tant que paramètre de chaîne pour la méthode Print de Presentation")
```

## **Définir Dynamiquement les Options d'Impression**

En utilisant les propriétés de la classe `PrinterSettings`, vous pouvez appliquer des paramètres qui définissent l'opération d'impression. Vous pouvez spécifier combien d'exemplaires doivent être imprimés, si les diapositives doivent être imprimées en mode paysage ou portrait, vos marges préférées, etc.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et passez la présentation que vous souhaitez imprimer.
2. Instanciez la classe `PrinterSettings`.
3. Spécifiez vos paramètres préférés pour l'opération d'impression :
   * le nombre de copies
   * orientation de la page
   * chiffres de marge, etc.
4. Appelez la méthode `print`.

Ce code Python vous montre comment imprimer une présentation PowerPoint avec certaines options d'impression : 

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("pres.pptx") as pres:
    printerSettings = drawing.printing.PrinterSettings()
    printerSettings.copies = 2
    printerSettings.default_page_settings.landscape = True
    printerSettings.default_page_settings.margins.left = 10
    pres.print(printerSettings)
```