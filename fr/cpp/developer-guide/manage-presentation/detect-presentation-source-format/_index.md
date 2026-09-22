---
title: "Déterminer le format original de la présentation en C++"
linktitle: "Format source"
type: docs
weight: 35
url: /fr/cpp/detect-presentation-source-format/
keywords:
- "format source"
- "détecter le format de la présentation"
- "PowerPoint"
- "OpenDocument"
- "présentation"
- "PPT"
- "PPTX"
- "C++"
- "Aspose.Slides"
description: "Lire le format original d'une présentation chargée en C++ avec Aspose.Slides pour C++, comparer les API de détection et gérer les fichiers, les flux et les formats hérités."
---
## **Vue d'ensemble**

Après avoir chargé une présentation, appelez [Presentation::get_SourceFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_sourceformat/) pour déterminer son format d'origine. La méthode est également disponible via [IPresentation::get_SourceFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentation/get_sourceformat/). Utilisez‑la lorsque le traitement ultérieur dépend du format à partir duquel l'instance courante a été chargée.

Le format source est distinct du [SaveFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/saveformat/) sélectionné pour un fichier de sortie. Enregistrer dans un autre format ne modifie pas le format source de l'instance existante.

## **Lire le format source d'un fichier**

Cet exemple nécessite un fichier `sample.pptx` existant. Il charge le fichier et sélectionne une politique de traitement d'application en utilisant [Presentation::get_SourceFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_sourceformat/), plutôt que le nom de fichier. Modifiez le chemin d'entrée pour tester d'autres formats. L'exemple affiche la politique sélectionnée ; remplacez les messages par la logique de votre application.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

switch (presentation->get_SourceFormat())
{
    case SourceFormat::Ppt:
    case SourceFormat::Pps:
    case SourceFormat::Pot:
        Console::WriteLine(u"Use the legacy PowerPoint processing policy.");
        break;
    case SourceFormat::Pptx:
        Console::WriteLine(u"Use the standard PPTX processing policy.");
        break;
    default:
        Console::WriteLine(String::Format(u"Use the general policy for {0}.", ObjectExt::ToString(presentation->get_SourceFormat())));
        break;
}
```

## **Reconnaître les valeurs prises en charge**

L'énumération [SourceFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/sourceformat/) distingue les formats de présentation suivants. Les extensions ci‑dessous sont des extensions conventionnelles, et non une reconstruction du nom de fichier original.

| Valeur SourceFormat | Extension | Format |
| --- | --- | --- |
| `Ppt` | `.ppt` | présentation PowerPoint 97–2003 |
| `Pptx` | `.pptx` | présentation Office Open XML |
| `Pptm` | `.pptm` | présentation Office Open XML avec macros |
| `Pps` | `.pps` | diaporama PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | diaporama Office Open XML |
| `Ppsm` | `.ppsm` | diaporama Office Open XML avec macros |
| `Pot` | `.pot` | modèle PowerPoint 97–2003 |
| `Potx` | `.potx` | modèle Office Open XML |
| `Potm` | `.potm` | modèle Office Open XML avec macros |
| `Odp` | `.odp` | présentation OpenDocument |
| `Otp` | `.otp` | modèle de présentation OpenDocument |
| `Fodp` | `.fodp` | présentation ODF XML plat |
| `Xml` | `.xml` | présentation PowerPoint XML |

## **Lire le format source d'un flux**

Cet exemple nécessite un fichier `sample.pps` existant. Lire ses octets dans un flux mémoire modélise une entrée reçue sans nom de fichier, comme une valeur de base de données ou un tableau d'octets téléchargé. Le constructeur [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) ne reçoit que le flux.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto bytes = File::ReadAllBytes(u"sample.pps");
auto stream = MakeObject<MemoryStream>(bytes);
auto presentation = MakeObject<Presentation>(stream);

Console::WriteLine(String::Format(u"Source format: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));
```

PPT, PPS et POT utilisent le même format binaire sous‑jacent. Lors du chargement par chemin de fichier, l'extension peut aider à distinguer un diaporama ou un modèle. Sans nom de fichier, le contenu hérité PPS et POT peut être indiqué comme `SourceFormat::Ppt` ; l'exemple PPS ci‑dessus indique `Ppt`.

Si votre application doit conserver cette distinction, conservez le nom de fichier original ou les métadonnées de sous‑type séparément. Une extension constitue un indice utile pour ces sous‑types hérités, mais ne doit pas être le seul critère pour identifier un contenu de présentation quelconque.

## **Comparer la détection avant et après le chargement**

Utilisez [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentationfactory/getpresentationinfo/) et [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentationinfo/get_loadformat/) lorsque vous devez examiner un fichier avant de charger son modèle d'objet de présentation complet. Utilisez [Presentation::get_SourceFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_sourceformat/) lorsque l'instance existe déjà.

Cet exemple nécessite `sample.pptx` et affiche `Pptx` pour les deux vérifications. En production, choisissez l'API appropriée à votre étape de traitement ; une présentation déjà chargée n'a pas besoin d'une seconde inspection uniquement pour obtenir son format source.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <DOM/PresentationFactory.h>
#include <DOM/IPresentationInfo.h>
#include <LoadFormat.h>

using namespace Aspose::Slides;
using namespace System;

auto path = String(u"sample.pptx");
auto information = PresentationFactory::get_Instance()->GetPresentationInfo(path);
Console::WriteLine(String::Format(u"Before loading: {0}", ObjectExt::ToString(information->get_LoadFormat())));

auto presentation = MakeObject<Presentation>(path);
Console::WriteLine(String::Format(u"After loading: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));
```

Les résultats ont des types d'énumération différents : [LoadFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/loadformat/) et [SourceFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/sourceformat/). Ne les comparez pas en convertissant leurs valeurs numériques et ne supposez pas que chaque format donne des résultats de détection identiques. Le PowerPoint XML peut être indiqué comme `LoadFormat::Unknown` avant le chargement et `SourceFormat::Xml` après le chargement.

## **Conserver les formats source et de sortie séparés**

Cet exemple nécessite `sample.pptx` et écrit `converted.odp`. Il affiche `Pptx` avant et après l'enregistrement de l'instance originale. Seule la nouvelle instance chargée depuis le fichier ODP de sortie indique `Odp`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
Console::WriteLine(String::Format(u"Before saving: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));

presentation->Save(u"converted.odp", SaveFormat::Odp);
Console::WriteLine(String::Format(u"After saving: {0}", ObjectExt::ToString(presentation->get_SourceFormat())));

auto reopened = MakeObject<Presentation>(u"converted.odp");
Console::WriteLine(String::Format(u"Reopened output: {0}", ObjectExt::ToString(reopened->get_SourceFormat())));
```

Une présentation créée à partir de zéro avec `MakeObject<Presentation>()` indique `SourceFormat::Pptx`. Elle n'a aucun fichier d'entrée : il s'agit de la valeur par défaut pour une instance nouvellement créée, et non d'une preuve qu'un fichier PPTX a été chargé. Suivez séparément si votre application a créé ou chargé l'instance si cette distinction est importante.

## **Faire correspondre un format source à une extension**

L'exemple suivant nécessite `sample.pptx`. Il associe chaque valeur actuellement prise en charge de [SourceFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/sourceformat/) à une extension conventionnelle, sans analyser le nom de fichier d'entrée. La solution de secours évite d'assigner silencieusement une extension à une valeur non reconnue.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto extension = String::Empty;
switch (presentation->get_SourceFormat())
{
    case SourceFormat::Ppt:
        extension = u".ppt";
        break;
    case SourceFormat::Pptx:
        extension = u".pptx";
        break;
    case SourceFormat::Pptm:
        extension = u".pptm";
        break;
    case SourceFormat::Pps:
        extension = u".pps";
        break;
    case SourceFormat::Ppsx:
        extension = u".ppsx";
        break;
    case SourceFormat::Ppsm:
        extension = u".ppsm";
        break;
    case SourceFormat::Pot:
        extension = u".pot";
        break;
    case SourceFormat::Potx:
        extension = u".potx";
        break;
    case SourceFormat::Potm:
        extension = u".potm";
        break;
    case SourceFormat::Odp:
        extension = u".odp";
        break;
    case SourceFormat::Otp:
        extension = u".otp";
        break;
    case SourceFormat::Fodp:
        extension = u".fodp";
        break;
    case SourceFormat::Xml:
        extension = u".xml";
        break;
    default:
        break;
}

Console::WriteLine(extension.IsEmpty() ? u"No extension mapping is available." : extension);
```

Cette correspondance ne convertit pas un fichier ni ne récupère un sous‑type PPS/POT hérité perdu lors du chargement du flux. Pour un enregistrement réel, sélectionnez explicitement un [SaveFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/saveformat/), ou utilisez la conversion présentée dans [Save Presentations in Their Original Format](/slides/fr/cpp/save-presentation/#save-presentations-in-their-original-format).

## **Vérifier les formats en enregistrant et en rouvrant**

Cet exemple autonome crée une présentation et écrit trois fichiers dans le répertoire de travail, écrasant les fichiers portant le même nom. Il rouvre chaque sortie à la fois par chemin et via un flux mémoire. Pour PPTX et ODP, les deux voies indiquent le format enregistré. Pour PPS, le chargement par chemin indique `Pps`, tandis que le chargement des mêmes octets sans nom de fichier indique `Ppt`.

```cpp
#include <DOM/Presentation.h>
#include <DOM/SourceFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace System;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto formats = MakeArray<SaveFormat>({SaveFormat::Pptx, SaveFormat::Odp, SaveFormat::Pps});

for (auto format : formats)
{
    auto formatName = ObjectExt::ToString(format);
    auto path = String::Format(u"roundtrip.{0}", formatName.ToLowerInvariant());
    presentation->Save(path, format);

    auto fromFile = MakeObject<Presentation>(path);
    auto bytes = File::ReadAllBytes(path);
    auto stream = MakeObject<MemoryStream>(bytes);
    auto fromStream = MakeObject<Presentation>(stream);

    Console::WriteLine(String::Format(u"{0}: file={1}, stream={2}", formatName, ObjectExt::ToString(fromFile->get_SourceFormat()), ObjectExt::ToString(fromStream->get_SourceFormat())));
}
```

Le tableau suivant résume l'identification du format source pour les présentations avec des extensions correspondantes :

| Format enregistré | SourceFormat à partir d'un chemin de fichier | SourceFormat à partir d'un flux sans nom |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectivement | Identique au chemin de fichier |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectivement | Identique au chemin de fichier |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectivement | Identique au chemin de fichier |
| ODP, OTP | `Odp`, `Otp` respectivement | Identique au chemin de fichier |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Le contenu hérité PPS/POT est normalisé en `Ppt` pour les flux sans nom. Le tableau décrit l'identification des formats, pas la préservation de chaque fonctionnalité de présentation lors de la conversion.

## **FAQ**

**Enregistrer au format ODP modifie‑t‑il le format source d'une présentation chargée depuis PPTX ?**

Non. L'instance existante indique toujours `Pptx`. Une instance chargée depuis le fichier ODP enregistré indique `Odp`.

**Un flux peut‑t‑il toujours distinguer une présentation héritée, un diaporama et un modèle ?**

Non. PPT, PPS et POT partagent le même format binaire. Conservez le nom de fichier ou les métadonnées de sous‑type séparément lorsque cette distinction est requise.

**Quelle API dois‑je utiliser si la présentation est déjà chargée ?**

Lisez [Presentation::get_SourceFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_sourceformat/). Utilisez [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentationfactory/getpresentationinfo/) pour l'inspection avant le chargement.