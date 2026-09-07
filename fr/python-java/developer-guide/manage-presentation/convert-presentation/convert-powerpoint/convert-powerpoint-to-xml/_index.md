---
title: Convertir des présentations PowerPoint en XML avec Python via Java
linktitle: PowerPoint vers XML
type: docs
weight: 145
url: /fr/python-java/convert-powerpoint-to-xml/
keywords:
- convertir PowerPoint en XML
- convertir la présentation en XML
- PPT en XML
- PPTX en XML
- ODP en XML
- Présentation PowerPoint XML
- SaveFormat.Xml
- enregistrer la présentation au format XML
- exporter la présentation en XML
- flux XML
- Python
- Java
- Aspose.Slides
description: "Convertir des présentations PowerPoint et OpenDocument en fichiers ou flux XML PowerPoint avec Python via Java à l'aide d'Aspose.Slides for Python via Java."
---
## **Vue d'ensemble**

Aspose.Slides for Python via Java peut convertir les présentations PowerPoint au format PowerPoint XML Presentation. La sortie XML est utile lorsque vous avez besoin d'une représentation texte pour inspecter la structure de la présentation, dépanner les documents générés, comparer les résultats dans des tests automatisés ou intégrer à un flux de travail qui consomme du XML plutôt qu'un package de présentation.

Utilisez la méthode [Presentation.save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save) avec la valeur [Xml](https://reference.aspose.com/slides/fr/python-java/aspose.slides/saveformat/#Xml) de la classe [SaveFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/saveformat/). Vous pouvez écrire le résultat directement dans un fichier ou dans un flux.

{{% alert color="info" title="Note" %}}

[SaveFormat.Xml](https://reference.aspose.com/slides/fr/python-java/aspose.slides/saveformat/#Xml) crée une PowerPoint XML Presentation. Il n'extrait pas les parties individuelles d'Office Open XML stockées dans un package PPTX. Si vous avez besoin des parties exactes du package PPTX, telles que `ppt/presentation.xml` ou les fichiers XML de diapositives individuels, inspectez le package PPTX lui‑même.

{{% /alert %}}

## **Convertir une présentation en fichier XML**

Chargez une présentation source avec la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) puis transmettez le chemin de sortie et [SaveFormat.Xml](https://reference.aspose.com/slides/fr/python-java/aspose.slides/saveformat/#Xml) à [Presentation.save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save). La source peut être n'importe quel format de présentation pris en charge pour le chargement, tel que PPT, PPTX ou ODP.

L'exemple suivant convertit une présentation PPTX en fichier XML :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.xml", SaveFormat.Xml)
finally:
    presentation.dispose()
```

## **Écrire la sortie XML dans un flux**

Utilisez la surcharge flux de [Presentation.save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save) lorsque le XML doit rester en mémoire ou être transmis à un autre composant, tel qu'un service Web, un fournisseur de stockage ou un pipeline de traitement XML. L'exemple suivant écrit le résultat dans un [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) et obtient le XML résultant sous forme d'objet bytes Python :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

presentation = Presentation("presentation.pptx")
try:
    xml_stream = ByteArrayOutputStream()
    try:
        presentation.save(xml_stream, SaveFormat.Xml)
        java_bytes = xml_stream.toByteArray()
        xml_data = bytes(java_bytes)

        # Passez xml_data au composant suivant du flux de travail.
    finally:
        xml_stream.close()
finally:
    presentation.dispose()
```

## **Comparer le XML avec les formats de présentation et d'exportation**

Choisissez le format de sortie en fonction de l'utilisation prévue du résultat :

| Format | Sortie | Utilisation typique |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Une PowerPoint XML Presentation | Inspection de la structure, dépannage, comparaison de la sortie générée et intégration basée sur XML |
| PPT (`.ppt`) | Un fichier de présentation binaire hérité | Compatibilité avec les anciens flux de travail PowerPoint |
| PPTX (`.pptx`) | Un package Office Open XML contenant plusieurs parties | Édition PowerPoint classique et échange de présentations |
| PDF ou TIFF | Pages à mise en page fixe ou image multipage | Visualisation, impression et archivage |
| PNG, JPEG ou SVG | Représentation rendue d'une diapositive individuelle | Vignettes, aperçus et actifs d'image |
| HTML ou HTML5 | Sortie de présentation orientée web | Visualisation dans le navigateur et publication web |

Contrairement aux PPT et PPTX, la sortie XML est principalement destinée à l'inspection et aux flux de travail axés sur les données. Contrairement aux PDF, TIFF, HTML et aux formats d'image de diapositive, elle représente les données de la présentation plutôt que de rendre les diapositives en pages ou actifs visuels. Le tableau [formats de fichiers pris en charge](/slides/fr/python-java/supported-file-formats/) indique que PowerPoint XML Presentation est uniquement disponible en sauvegarde, ne l'utilisez donc pas lorsqu'un flux de travail doit charger le fichier exporté à nouveau dans Aspose.Slides pour une édition continue.

## **FAQ**

**L'exportation XML est-elle identique à l'enregistrement d'un fichier PPTX ?**

Non. PPTX est un package contenant plusieurs parties Office Open XML, tandis que [SaveFormat.Xml](https://reference.aspose.com/slides/fr/python-java/aspose.slides/saveformat/#Xml) crée un fichier PowerPoint XML Presentation.

**Puis‑je enregistrer la sortie XML sans créer de fichier sur le disque ?**

Oui. Transmettez un flux de sortie Java inscriptible à [Presentation.save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save). Par exemple, utilisez un [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) pour le traitement en mémoire.

**Aspose.Slides peut‑il charger à nouveau le fichier XML exporté ?**

Non. PowerPoint XML Presentation est actuellement pris en charge uniquement pour l'enregistrement, pas pour le chargement. Utilisez PPTX ou un autre format de présentation supporté lorsque vous avez besoin d'un aller‑retour d'édition.

**La conversion XML rend‑elle chaque diapositive sous forme de page ou d'image ?**

Non. La conversion XML écrit des données de présentation structurées. Utilisez PDF ou TIFF pour une sortie orientée pages, ou PNG, JPEG et SVG pour des images de diapositives individuelles.