---
title: Convertir des présentations PowerPoint en XML en C++
linktitle: PowerPoint en XML
type: docs
weight: 145
url: /fr/cpp/convert-powerpoint-to-xml/
keywords:
- convertir PowerPoint en XML
- convertir la présentation en XML
- PPT en XML
- PPTX en XML
- ODP en XML
- Présentation PowerPoint XML
- SaveFormat::Xml
- enregistrer la présentation au format XML
- exporter la présentation en XML
- flux XML
- C++
- Aspose.Slides
description: "Convertissez les présentations PowerPoint et OpenDocument en fichiers ou flux PowerPoint XML en C++ avec Aspose.Slides pour C++."
---
## **Vue d'ensemble**

Aspose.Slides pour C++ peut convertir des présentations PowerPoint au format PowerPoint XML Presentation. La sortie XML est utile lorsque vous avez besoin d’une représentation textuelle pour inspecter la structure d’une présentation, dépanner les documents générés, comparer les résultats dans des tests automatisés ou intégrer un flux de travail qui consomme du XML au lieu d’un package de présentation.

Utilisez la méthode [Presentation::Save](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/save/) avec la valeur `Xml` de l’énumération [SaveFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/saveformat/). Vous pouvez écrire le résultat directement dans un fichier ou dans un flux.

{{% alert color="info" title="Remarque" %}}

`SaveFormat::Xml` crée une PowerPoint XML Presentation. Il n’extrait pas les parties Office Open XML individuelles stockées à l’intérieur d’un package PPTX. Si vous avez besoin des parties exactes du package PPTX, telles que `ppt/presentation.xml` ou les fichiers XML de diapositives individuels, examinez le package PPTX lui‑même.

{{% /alert %}}

## **Convertir une présentation en fichier XML**

Chargez une présentation source avec la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) puis transmettez le chemin de sortie et `SaveFormat::Xml` à [Presentation::Save](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/save/). La source peut être n’importe quel format de présentation supporté pour le chargement, tel que PPT, PPTX ou ODP.

L’exemple suivant convertit une présentation PPTX en fichier XML :

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.xml", SaveFormat::Xml);
presentation->Dispose();
```

## **Écrire la sortie XML vers un flux**

Utilisez la surcharge flux de [Presentation::Save](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/save/) lorsque le XML doit rester en mémoire ou être transmis à un autre composant, tel qu’un service web, un fournisseur de stockage ou une chaîne de traitement XML. L’exemple suivant écrit le résultat dans un [MemoryStream](https://reference.aspose.com/slides/fr/cpp/system.io/memorystream/) puis le rembobine pour une lecture ultérieure :

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto xmlStream = System::MakeObject<MemoryStream>();

presentation->Save(xmlStream, SaveFormat::Xml);
xmlStream->set_Position(0);
presentation->Dispose();

// Transmettez xmlStream au composant suivant dans le flux de travail.
```

## **Comparer le XML avec les formats de présentation et d’exportation**

Choisissez le format de sortie en fonction de l’utilisation prévue du résultat :

| Format | Sortie | Utilisation typique |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | Une PowerPoint XML Presentation | Inspection de la structure, dépannage, comparaison de la sortie générée et intégration basée sur XML |
| PPT (`.ppt`) | Un fichier de présentation binaire hérité | Compatibilité avec les flux de travail PowerPoint plus anciens |
| PPTX (`.pptx`) | Un package Office Open XML contenant plusieurs parties | Édition PowerPoint régulière et échange de présentations |
| PDF ou TIFF | Pages à mise en page fixe ou image multipage | Visualisation, impression et archivage |
| PNG, JPEG ou SVG | Une représentation rendue d’une diapositive individuelle | Vignettes, aperçus et ressources d’image |
| HTML ou HTML5 | Sortie de présentation orientée web | Visualisation dans le navigateur et publication web |

Contrairement aux formats PPT et PPTX, la sortie XML est principalement destinée à l’inspection et aux flux de travail axés sur les données. Contrairement aux PDF, TIFF, HTML et aux formats d’image de diapositive, elle représente les données de la présentation plutôt que de rendre les diapositives sous forme de pages ou d’actifs visuels. La table des [formats de fichiers pris en charge](/slides/fr/cpp/supported-file-formats/) indique PowerPoint XML Presentation comme format uniquement enregistrement, il ne faut donc pas l’utiliser lorsqu’un flux de travail doit charger le fichier exporté à nouveau dans Aspose.Slides pour une édition continue.

## **FAQ**

**Le `SaveFormat::Xml` est‑il identique à l'enregistrement d'un fichier PPTX ?**

Non. PPTX est un paquet contenant plusieurs parties Office Open XML, tandis que `SaveFormat::Xml` crée un fichier PowerPoint XML Presentation.

**Puis‑je enregistrer la sortie XML sans créer de fichier sur le disque ?**

Oui. Transmettez un flux accessible en écriture à [Presentation::Save](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/save/). Par exemple, utilisez un [MemoryStream](https://reference.aspose.com/slides/fr/cpp/system.io/memorystream/) pour le traitement en mémoire.

**Aspose.Slides peut‑il charger à nouveau le fichier XML exporté ?**

Non. PowerPoint XML Presentation est actuellement pris en charge uniquement pour l’enregistrement, pas pour le chargement. Utilisez PPTX ou un autre format de présentation supporté lorsqu’un aller‑retour d’édition est requis.

**La conversion XML rend‑t‑elle chaque diapositive sous forme de page ou d'image ?**

Non. La conversion XML écrit des données structurées de la présentation. Utilisez PDF ou TIFF pour une sortie orientée page, ou PNG, JPEG et SVG pour des images de diapositives individuelles.