---
title: Convertir des présentations PowerPoint en XML avec Python
linktitle: PowerPoint vers XML
type: docs
weight: 145
url: /fr/python-net/convert-powerpoint-to-xml/
keywords:
- convertir PowerPoint en XML
- convertir la présentation en XML
- PPT en XML
- PPTX en XML
- ODP en XML
- Présentation PowerPoint XML
- SaveFormat.XML
- enregistrer la présentation au format XML
- exporter la présentation au format XML
- flux XML
- Python
- Aspose.Slides
description: "Convertir des présentations PowerPoint et OpenDocument en fichiers ou flux PowerPoint XML avec Python et Aspose.Slides."
---
## **Vue d'ensemble**

Aspose.Slides for Python via .NET peut convertir des présentations PowerPoint au format PowerPoint XML Presentation. La sortie XML est utile lorsque vous avez besoin d'une représentation textuelle pour inspecter la structure de la présentation, dépanner les documents générés, comparer les résultats dans des tests automatisés ou intégrer un flux de travail qui consomme du XML au lieu d'un package de présentation.

Utilisez la méthode [Presentation.save](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/save/) avec la valeur `XML` de l'énumération [SaveFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/saveformat/). Vous pouvez écrire le résultat directement dans un fichier ou dans un flux.

{{% alert color="info" title="Note" %}}
`SaveFormat.XML` crée une PowerPoint XML Presentation. Il n'extrait pas les parties individuelles Office Open XML stockées dans un package PPTX. Si vous avez besoin des parties exactes du package PPTX, comme `ppt/presentation.xml` ou les fichiers XML de diapositives individuels, inspectez le package PPTX lui‑même.
{{% /alert %}}

## **Convertir une présentation en fichier XML**

Chargez une présentation source avec la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/), puis passez le chemin de sortie et `SaveFormat.XML` à [Presentation.save](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/save/). La source peut être n'importe quel format de présentation pris en charge pour le chargement, tel que PPT, PPTX ou ODP.

L'exemple suivant convertit une présentation PPTX en fichier XML :
```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.save("presentation.xml", slides.export.SaveFormat.XML)
```

## **Écrire la sortie XML dans un flux**

Utilisez la surcharge flux de [Presentation.save](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/save/) lorsque le XML doit rester en mémoire ou être transmis à un autre composant, tel qu'un service web, un fournisseur de stockage ou un pipeline de traitement XML. L'exemple suivant écrit le résultat dans un flux [BytesIO](https://docs.python.org/3/library/io.html#io.BytesIO) et le remet à la position de départ pour une lecture ultérieure :
```py
from io import BytesIO

import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    xml_stream = BytesIO()
    presentation.save(xml_stream, slides.export.SaveFormat.XML)
    xml_stream.seek(0)

    # Passer xml_stream au composant suivant du flux de travail.
```

## **Comparer le XML avec les formats de présentation et d'exportation**

Choisissez le format de sortie en fonction de l'utilisation prévue du résultat :

| Format | Sortie | Utilisation typique |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Une présentation PowerPoint XML | Inspection de la structure, dépannage, comparaison des sorties générées et intégration basée sur XML |
| PPT (`.ppt`) | Un fichier de présentation binaire hérité | Compatibilité avec les flux de travail PowerPoint plus anciens |
| PPTX (`.pptx`) | Un package Office Open XML contenant plusieurs parties | Édition PowerPoint régulière et échange de présentations |
| PDF ou TIFF | Pages à mise en page fixe ou image multipage | Visualisation, impression et archivage |
| PNG, JPEG ou SVG | Une représentation rendue d'une diapositive individuelle | Miniatures, aperçus et ressources d'image |
| HTML ou HTML5 | Sortie de présentation orientée Web | Visualisation dans le navigateur et publication Web |

Contrairement aux PPT et PPTX, la sortie XML est principalement destinée à l'inspection et aux flux de travail orientés données. Contrairement aux PDF, TIFF, HTML et aux formats d'images de diapositives, elle représente les données de la présentation plutôt que de rendre les diapositives sous forme de pages ou d'assets visuels. Le tableau des [formats de fichiers pris en charge](/slides/fr/python-net/supported-file-formats/) indique que PowerPoint XML Presentation est un format uniquement d'enregistrement, il ne faut donc pas l'utiliser lorsqu'un flux de travail doit charger le fichier exporté à nouveau dans Aspose.Slides pour poursuivre l'édition.

## **FAQ**

**Le `SaveFormat.XML` équivaut‑il à l'enregistrement d'un fichier PPTX ?**  
Non. Le PPTX est un package contenant plusieurs parties Office Open XML, tandis que `SaveFormat.XML` crée un fichier PowerPoint XML Presentation.

**Puis‑je enregistrer la sortie XML sans créer de fichier sur le disque ?**  
Oui. Transmettez un flux inscriptible à [Presentation.save](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/save/). Par exemple, utilisez un flux [BytesIO](https://docs.python.org/3/library/io.html#io.BytesIO) pour un traitement en mémoire.

**Aspose.Slides peut‑il recharger le fichier XML exporté ?**  
Non. PowerPoint XML Presentation est actuellement pris en charge uniquement pour l'enregistrement et non pour le chargement. Utilisez PPTX ou un autre format de présentation supporté lorsque l'édition aller‑retour est requise.

**La conversion XML rend‑elle chaque diapositive sous forme de page ou d'image ?**  
Non. La conversion XML écrit des données de présentation structurées. Utilisez PDF ou TIFF pour une sortie orientée page, ou PNG, JPEG et SVG pour des images de diapositives individuelles.