---
title: Convertir ODP en PPTX en Python
linktitle: ODP en PPTX
type: docs
weight: 10
url: /fr/python-java/convert-odp-to-pptx/
keywords:
- convertir OpenDocument
- convertir présentation
- convertir diapositive
- convertir ODP
- OpenDocument en PPTX
- ODP en PPTX
- enregistrer ODP en PPTX
- exporter ODP en PPTX
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Convertissez les présentations ODP en PPTX avec Aspose.Slides pour Python via Java. Utilisez un exemple complet en Python sans installer PowerPoint ou LibreOffice."
---
## **Aperçu**

Cet article explique comment convertir une présentation OpenDocument (ODP) au format PowerPoint (PPTX) en utilisant Aspose.Slides pour Python via Java.

## **Convertir ODP en PPTX**

La classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) peut charger directement un fichier ODP. Enregistrez la présentation chargée au format PPTX en utilisant [SaveFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/saveformat/).

Suivez les [instructions d'installation](/slides/fr/python-java/installation/) avant d'exécuter l'exemple. Placez une présentation ODP nommée `AccessOpenDoc.odp` dans le répertoire de travail. Le code suivant démarre la JVM si nécessaire, ouvre le fichier ODP et l'enregistre sous `AccessOpenDoc_out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("AccessOpenDoc.odp")
try:
    # Enregistrez la présentation ODP au format PPTX.
    presentation.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Exemple en direct**

Essayez l'application web [Aspose.Slides Conversion](https://products.aspose.app/slides/fr/conversion/) pour voir la conversion ODP en PPTX propulsée par Aspose.Slides.

## **FAQ**

**Ai-je besoin d'installer Microsoft PowerPoint ou LibreOffice pour convertir ODP en PPTX ?**

Non. Aspose.Slides pour Python via Java lit et écrit les fichiers de présentation sans aucune de ces applications. Vous avez besoin du package Python et d'un runtime Java compatible.

**Les diapositives maîtres, les mises en page et les thèmes sont-ils conservés lors de la conversion ?**

Aspose.Slides mappe la structure et le formatage de la présentation source vers le PPTX. Cependant, ODP et PPTX prennent en charge des fonctionnalités différentes, de sorte que certains éléments peuvent apparaître différemment après la conversion. Mettez les polices requises à disposition et examinez les présentations avec un formatage complexe. Consultez [Conversion OpenDocument](/slides/fr/python-java/convert-openoffice-odp/) pour les considérations de compatibilité.

**Puis-je convertir des fichiers ODP protégés par mot de passe ?**

Oui, lorsque vous fournissez le mot de passe requis pour ouvrir le fichier. Consultez [présentations protégées par mot de passe](/slides/fr/python-java/password-protected-presentation/) pour plus de détails sur le chargement des fichiers protégés avant de les enregistrer dans un autre format.

**Aspose.Slides convient-il aux services de conversion cloud ou basés sur REST ?**

Oui. Vous pouvez utiliser Aspose.Slides pour Python via Java dans votre backend avec le runtime Java requis. Pour une API REST, consultez [Aspose.Slides Cloud](https://products.aspose.cloud/slides/fr/family/).