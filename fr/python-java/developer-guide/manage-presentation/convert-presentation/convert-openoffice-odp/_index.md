---
title: Convertir des présentations OpenDocument en Python
linktitle: Convertir OpenDocument
type: docs
weight: 10
url: /fr/python-java/convert-openoffice-odp/
keywords:
- convertir ODP
- ODP vers PDF
- ODP vers HTML
- ODP vers TIFF
- ODP vers PPT
- ODP vers PPTX
- ODP vers XPS
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Convertissez des présentations OpenDocument (ODP) au format PDF, HTML et autres formats avec Aspose.Slides pour Python via Java, sans installer OpenOffice ou LibreOffice."
---
## **Introduction**

Aspose.Slides for Python via Java vous permet de convertir des présentations OpenDocument (ODP) en formats tels que PDF, HTML, TIFF, XPS, PPT et PPTX. La conversion ODP utilise la même API que la conversion PowerPoint : chargez le fichier source avec [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) et sélectionnez le format de sortie avec [SaveFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/saveformat/).

## **Convertir ODP en PDF**

Suivez les [instructions d'installation](/slides/fr/python-java/installation/) avant d'exécuter l'exemple. Placez une présentation ODP nommée `pres.odp` dans le répertoire de travail. Le code suivant démarre la JVM si nécessaire, charge la présentation et l'enregistre sous `pres.pdf`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.odp")
try:
    presentation.save("pres.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

## **Présentation OpenDocument dans différentes applications**

Une présentation ODP peut apparaître différemment dans PowerPoint et LibreOffice/OpenOffice Impress parce que ces applications prennent en charge des fonctionnalités de présentation et des comportements de rendu différents. Examinez les présentations converties lorsque leur disposition dépend d'un formatage complexe.

Les différences de compatibilité peuvent affecter :

- Les tableaux, y compris leur ordre d'empilement par rapport aux autres formes et la prise en charge des remplissages d'image.
- La rotation et l'alignement du texte.
- Les remplissages d'image, de dégradé et de motif appliqués au texte.
- Les listes numérotées et à puces.

L'image ci‑dessous montre une liste créée dans LibreOffice Impress :

![Exemple de liste ODP dans LibreOffice Impress](odp-list-example.png)

Aspose.Slides enregistre les listes ODP pour garantir la compatibilité avec LibreOffice/OpenOffice Impress.

Pour plus de détails sur la compatibilité des fonctionnalités, consultez le [guide Microsoft du format Présentation OpenDocument](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0).

## **FAQ**

**Que faire si le formatage de mon fichier ODP change après la conversion ?**

ODP et PowerPoint utilisent des modèles de présentation différents. Les tableaux, les polices et les styles de remplissage peuvent être rendus différemment. Vérifiez que les polices requises sont disponibles, examinez le résultat et ajustez la disposition ou le formatage si nécessaire.

**Dois‑je installer OpenOffice ou LibreOffice pour convertir des fichiers ODP ?**

Non. Aspose.Slides for Python via Java traite les présentations sans aucune de ces applications. Un environnement d'exécution Java compatible et le package Python sont requis.

**Puis‑je personnaliser la sortie PDF lors de la conversion d'une présentation ODP ?**

Oui. Utilisez [PdfOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pdfoptions/) pour configurer les paramètres d'exportation PDF, comme la qualité d'image et la compression.

**Puis‑je convertir des présentations ODP sur un serveur ou dans un conteneur ?**

Oui. Installez le package Python, un environnement d'exécution Java compatible et les polices requises par vos présentations dans l'environnement cible. Aucune application de bureautique n'est nécessaire.