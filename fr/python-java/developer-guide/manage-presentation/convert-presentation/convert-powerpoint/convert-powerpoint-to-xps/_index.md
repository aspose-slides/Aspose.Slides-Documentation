---
title: Convertir des présentations PowerPoint en XPS avec Python
linktitle: PowerPoint vers XPS
type: docs
weight: 70
url: /fr/python-java/convert-powerpoint-to-xps/
keywords:
- convertir PowerPoint
- convertir présentation
- convertir PPT
- convertir PPTX
- PowerPoint vers XPS
- présentation vers XPS
- PPT vers XPS
- PPTX vers XPS
- enregistrer PPT en XPS
- enregistrer PPTX en XPS
- exporter PPT vers XPS
- exporter PPTX vers XPS
- Python
- Java
- Aspose.Slides
description: "Convertir des présentations PowerPoint PPT et PPTX en XPS avec Python en utilisant Aspose.Slides for Python via Java, avec des paramètres d'exportation par défaut ou personnalisés."
---
## **Vue d'ensemble**

Aspose.Slides for Python via Java vous permet de convertir des présentations PowerPoint en XPS en enregistrant un fichier PPT ou PPTX au format XPS. Cet article explique quand le XPS peut être utile et montre comment exporter une présentation en utilisant les paramètres par défaut ou des paramètres personnalisés [XpsOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/xpsoptions/) .

## **À propos de XPS**

XPS (XML Paper Specification) est un format de document basé sur XML développé par Microsoft. Il décrit des pages fixes, préservant la mise en page du texte et des graphiques pour la visualisation et l’impression avec un logiciel compatible.

## **Quand utiliser le format XPS de Microsoft**

Utilisez le XPS lorsqu’un flux de travail documentaire nécessite des fichiers à mise en page fixe pour le partage ou l’impression via des outils compatibles XPS. Les destinataires doivent disposer d’un logiciel qui prend en charge le XPS. Si votre flux de travail nécessite plutôt le PDF, consultez [Convert PowerPoint to PDF](/slides/fr/python-java/convert-powerpoint-to-pdf/) .

{{% alert color="info" title="Note" %}}
Pour essayer de convertir une présentation PPT ou PPTX en XPS, utilisez le [convertisseur en ligne gratuit](https://products.aspose.app/slides/fr/conversion) .
{{% /alert %}}

| Présentation PowerPoint d’entrée | Document XPS de sortie |
| --- | --- |
| ![Présentation PowerPoint originale](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png) | ![Présentation convertie en XPS](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png) |

## **Conversion XPS avec Aspose.Slides**

Utilisez la méthode [save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save) de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) avec [SaveFormat.Xps](https://reference.aspose.com/slides/fr/python-java/aspose.slides/saveformat/#Xps) pour exporter une présentation. Vous pouvez utiliser les paramètres d’exportation par défaut ou fournir des [XpsOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/xpsoptions/) pour personnaliser la sortie.

Chaque exemple ci‑dessous démarre la machine virtuelle Java si nécessaire et libère la présentation après utilisation. Remplacez le nom de fichier d’entrée par le chemin vers votre fichier PPT ou PPTX.

### **Convertir des présentations en XPS avec les paramètres par défaut**

Le code Python suivant convertit une présentation en XPS en utilisant les paramètres par défaut :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    # Enregistrez la présentation en tant que document XPS.
    presentation.save("output.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

### **Convertir des présentations en XPS avec des paramètres personnalisés**

L’exemple suivant utilise [XpsOptions.setSaveMetafilesAsPng](https://reference.aspose.com/slides/fr/python-java/aspose.slides/xpsoptions/#setSaveMetafilesAsPng) pour enregistrer les métafichiers en images PNG dans le document XPS résultant :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, XpsOptions

presentation = Presentation("presentation.pptx")
try:
    xps_options = XpsOptions()
    xps_options.setSaveMetafilesAsPng(True)

    # Enregistrez la présentation avec les paramètres XPS personnalisés.
    presentation.save("output_custom.xps", SaveFormat.Xps, xps_options)
finally:
    presentation.dispose()
```

## **FAQ**

**Puis-je enregistrer le XPS dans un flux plutôt que dans un fichier ?**

Oui. La méthode [Presentation.save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save) possède des surcharges qui acceptent un flux de sortie Java. Avec Python via Java, utilisez un flux Java compatible via JPype, comme un flux de sortie Java byte‑array, pour conserver les données exportées en mémoire.

**Les diapositives masquées sont‑elles incluses dans la sortie XPS ?**

Les diapositives masquées sont exclues par défaut. Pour les inclure, définissez [XpsOptions.setShowHiddenSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/xpsoptions/#setShowHiddenSlides) sur `True` avant l’enregistrement.

**Les animations et les transitions de diapositives sont‑elles préservées dans le XPS ?**

Non. XPS contient des pages fixes, ainsi les diapositives exportées ne reproduisent pas les animations ni les effets de transition.