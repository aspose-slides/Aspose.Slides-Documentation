---
title: Exporter des présentations vers XAML en Python via Java
linktitle: Présentation vers XAML
type: docs
weight: 30
url: /fr/python-java/export-to-xaml/
keywords:
- exporter PowerPoint
- exporter OpenDocument
- exporter une présentation
- convertir PowerPoint
- convertir OpenDocument
- convertir une présentation
- PowerPoint vers XAML
- OpenDocument vers XAML
- présentation vers XAML
- PPT vers XAML
- PPTX vers XAML
- ODP vers XAML
- enregistrer PPT en XAML
- enregistrer PPTX en XAML
- enregistrer ODP en XAML
- exporter PPT en XAML
- exporter PPTX en XAML
- exporter ODP en XAML
- Python
- Java
- Aspose.Slides
description: "Exporter des présentations PowerPoint et OpenDocument vers XAML avec Aspose.Slides for Python via Java. Utilisez les options par défaut ou incluez les diapositives masquées."
---
## **Vue d'ensemble**

Cet article explique comment exporter des présentations PowerPoint et OpenDocument vers XAML à l'aide d'Aspose.Slides for Python via Java. Il présente XAML, montre comment exporter avec les paramètres par défaut, et démontre comment inclure les diapositives masquées avec [XamlOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/xamloptions/).

Les exemples nécessitent Aspose.Slides for Python via Java et un environnement d'exécution Java compatible. Placez `pres.pptx` dans le répertoire de travail actuel. Chaque exemple démarre la JVM uniquement si elle n'est pas déjà en cours d'exécution.

## **À propos de XAML**

XAML (Extensible Application Markup Language) est un langage basé sur XML destiné à décrire les interfaces utilisateur. Il est utilisé par des frameworks tels que Windows Presentation Foundation (WPF). Vous pouvez créer et modifier du XAML avec un concepteur visuel ou un éditeur de texte.

## **Exporter des présentations vers XAML avec les options par défaut**

Créez une [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) à partir du fichier d'entrée, puis transmettez [XamlOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/xamloptions/) à [Presentation.save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save) pour exporter avec les paramètres par défaut :
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **Exporter des présentations vers XAML avec des options personnalisées**

Utilisez [XamlOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/xamloptions/) pour configurer l'exportation. Pour inclure les diapositives masquées, appelez [setExportHiddenSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) avec `True` avant d'enregistrer :
```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **FAQ**

**Comment choisir une police de secours lorsque la police d'origine n'est pas disponible ?**

Utilisez [setDefaultRegularFont](https://reference.aspose.com/slides/fr/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) sur votre objet [XamlOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/xamloptions/) pour spécifier une police de secours. Assurez vous que la police sélectionnée est disponible dans l'environnement d'exportation.

**Puis-je utiliser le balisage exporté dans n'importe quel framework XAML ?**

Les frameworks XAML diffèrent quant aux éléments et fonctionnalités pris en charge. Testez le balisage exporté dans votre framework cible avant de l'intégrer à une application.

**Les diapositives masquées sont-elles exportées par défaut ?**

Non. Pour les inclure, appelez [setExportHiddenSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) avec `True`. Laissez la valeur à `False` pour les exclure.