---
title: Récupérer et mettre à jour les informations de présentation en C++
linktitle: Informations de présentation
type: docs
weight: 30
url: /fr/cpp/examine-presentation/
keywords:
- format de présentation
- propriétés de présentation
- propriétés du document
- obtenir des propriétés
- lire des propriétés
- changer des propriétés
- modifier des propriétés
- mettre à jour des propriétés
- examiner PPTX
- examiner PPT
- examiner ODP
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Explorez les diapositives, la structure et les métadonnées des présentations PowerPoint et OpenDocument en C++ pour obtenir des informations rapides et des audits de contenu plus intelligents."
---
## **Vue d'ensemble**

Aspose.Slides peut identifier le format d'une présentation et lire ses métadonnées de document sans créer un modèle d'objet de présentation complet. Ceci est utile lorsque vous devez classer des fichiers, créer un inventaire ou inspecter les propriétés avant de décider de charger et de traiter le contenu de la présentation.

Cet article montre l'inspection légère via [PresentationFactory](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentationfactory/) et [IPresentationInfo](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentationinfo/), ainsi que les mises à jour ciblées via [IDocumentProperties](https://reference.aspose.com/slides/fr/cpp/aspose.slides/idocumentproperties/).

## **Vérifier le format d'une présentation**

Utilisez [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) pour inspecter un fichier sans créer une instance de [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/). La méthode [IPresentationInfo::get_LoadFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentationinfo/get_loadformat/) renvoie le format détecté, tel que PPTX, PPT ou ODP.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/array.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto fileNames = MakeArray<String>({u"pres.pptx", u"pres.ppt", u"pres.odp"});

for (const auto& fileName : fileNames)
{
    auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);
    Console::WriteLine(String::Format(u"{0}: {1}", fileName, ObjectExt::ToString(presentationInfo->get_LoadFormat())));
}
```

## **Construire un inventaire de présentation léger**

Lorsque vous traitez de nombreux fichiers de présentation, il peut être nécessaire de disposer d'un inventaire compact pour la validation, l'indexation ou un système de gestion de documents. Dans ce scénario, utilisez [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) pour obtenir un objet [IPresentationInfo](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentationinfo/), puis appelez [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) pour lire les métadonnées du document. Cette approche ne crée pas d'instance de [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) et ne vous oblige pas à parcourir le modèle d'objet complet de la présentation.

Les propriétés étendues exposées par [IDocumentProperties](https://reference.aspose.com/slides/fr/cpp/aspose.slides/idocumentproperties/) fournissent les valeurs d'inventaire suivantes :

| Méthode | Valeur d'inventaire |
| --- | --- |
| [get_Slides](https://reference.aspose.com/slides/fr/cpp/aspose.slides/idocumentproperties/get_slides/) | Nombre total de diapositives. |
| [get_HiddenSlides](https://reference.aspose.com/slides/fr/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) | Nombre de diapositives masquées. |
| [get_Notes](https://reference.aspose.com/slides/fr/cpp/aspose.slides/idocumentproperties/get_notes/) | Nombre de diapositives contenant des notes. |
| [get_Paragraphs](https://reference.aspose.com/slides/fr/cpp/aspose.slides/idocumentproperties/get_paragraphs/) | Nombre total de paragraphes, lorsqu'ils sont disponibles. |
| [get_Words](https://reference.aspose.com/slides/fr/cpp/aspose.slides/idocumentproperties/get_words/) | Nombre total de mots. |
| [get_MultimediaClips](https://reference.aspose.com/slides/fr/cpp/aspose.slides/idocumentproperties/get_multimediaclips/) | Nombre total de clips audio et vidéo. |

L'exemple suivant lit ces valeurs sans créer d'objet [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) et affiche un inventaire compact. Il combine également [IDocumentProperties::get_HeadingPairs](https://reference.aspose.com/slides/fr/cpp/aspose.slides/idocumentproperties/get_headingpairs/) avec [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/fr/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) pour afficher les groupes de contenu tels que les polices, les thèmes et les titres de diapositives.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IHeadingPair.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <LoadFormat.h>
#include <system/console.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto filePath = String(u"sample.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(filePath);
auto documentProperties = presentationInfo->ReadDocumentProperties();

Console::WriteLine(String::Format(u"File: {0}", Path::GetFileName(filePath)));
Console::WriteLine(String::Format(u"Format: {0}", ObjectExt::ToString(presentationInfo->get_LoadFormat())));
Console::WriteLine(String::Format(u"Title: {0}", documentProperties->get_Title()));
Console::WriteLine(String::Format(u"Author: {0}", documentProperties->get_Author()));
Console::WriteLine(u"Statistics:");
Console::WriteLine(String::Format(u"  Slides: {0}", documentProperties->get_Slides()));
Console::WriteLine(String::Format(u"  Hidden slides: {0}", documentProperties->get_HiddenSlides()));
Console::WriteLine(String::Format(u"  Slides with notes: {0}", documentProperties->get_Notes()));
Console::WriteLine(String::Format(u"  Paragraphs: {0}", documentProperties->get_Paragraphs()));
Console::WriteLine(String::Format(u"  Words: {0}", documentProperties->get_Words()));
Console::WriteLine(String::Format(u"  Multimedia clips: {0}", documentProperties->get_MultimediaClips()));

auto headingPairs = documentProperties->get_HeadingPairs();
auto titlesOfParts = documentProperties->get_TitlesOfParts();
auto partIndex = 0;

if (headingPairs == nullptr || titlesOfParts == nullptr || headingPairs->get_Length() == 0 || titlesOfParts->get_Length() == 0)
{
    Console::WriteLine(u"Content groups: not available");
}
else
{
    Console::WriteLine(u"Content groups:");

    for (const auto& headingPair : headingPairs)
    {
        auto partCount = headingPair->get_Count();
        Console::WriteLine(String::Format(u"  {0} ({1})", headingPair->get_Name(), partCount));

        for (auto partOffset = 0; partOffset < partCount && partIndex < titlesOfParts->get_Length(); partOffset++)
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts->get_Length())
    {
        Console::WriteLine(u"  Other parts:");

        while (partIndex < titlesOfParts->get_Length())
        {
            Console::WriteLine(String::Format(u"    - {0}", titlesOfParts[partIndex]));
            partIndex++;
        }
    }
}
```

Chaque [IHeadingPair](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iheadingpair/) fournit un nom de groupe via [IHeadingPair::get_Name](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iheadingpair/get_name/) et le nombre d'éléments dans ce groupe via [IHeadingPair::get_Count](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iheadingpair/get_count/). [IDocumentProperties::get_TitlesOfParts](https://reference.aspose.com/slides/fr/cpp/aspose.slides/idocumentproperties/get_titlesofparts/) renvoie un tableau plat et ordonné, il faut donc consommer le nombre de titres consécutifs spécifié par chaque paire d'en-têtes.

### **Métadonnées stockées et limites de format**

Les propriétés d'inventaire renvoyées par [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) reflètent les métadonnées disponibles dans le document source. Aspose.Slides ne charge pas et ne parcourt pas le modèle d'objet de la présentation pour recalculer ces valeurs pour cet appel. Les propriétés manquantes sont représentées par des valeurs par défaut, et les valeurs stockées peuvent être obsolètes si l'application qui a enregistré le fichier en dernier n'a pas mis à jour ses propriétés de document.

- **PPTX :** Le format fournit des propriétés de document étendues pour les comptes de diapositives, notes, diapositives masquées, paragraphes, mots et multimédia, ainsi que les paires d'en-têtes et les titres de parties. La disponibilité dépend des propriétés écrites par le producteur du document.
- **PPT :** Le format binaire peut stocker les propriétés de résumé de document correspondantes. Si une propriété est absente ou n'a pas été actualisée par le producteur du document, Aspose.Slides renvoie sa valeur stockée ou par défaut plutôt que de la calculer à partir des diapositives.
- **ODP :** Les métadonnées OpenDocument fournissent des statistiques générales du document, comme le nombre de pages, de paragraphes et de mots, mais ces valeurs ne correspondent pas à chaque propriété étendue spécifique à PowerPoint. Les métadonnées de diapositives masquées, de diapositives avec notes, de multimédia, de paires d'en-têtes et de titres de parties peuvent être indisponibles, et les propriétés d'inventaire peuvent renvoyer des valeurs par défaut. Ne considérez pas une valeur zéro ou un tableau vide comme une preuve définitive que le contenu correspondant est absent.

Utilisez l'approche de métadonnées légères pour les inventaires et les vérifications préliminaires. Chargez la présentation et inspectez son modèle d'objet en direct lorsque le résultat doit refléter les modifications en mémoire ou lorsque vous devez vérifier le contenu réel de la présentation.

## **Mettre à jour les propriétés de la présentation**

Les propriétés renvoyées par [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) peuvent également être modifiées sans créer d'instance de [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/). Appliquez les changements avec [IPresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentationinfo/updatedocumentproperties/), puis écrivez la présentation liée avec [IPresentationInfo::WriteBindedPresentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentationinfo/writebindedpresentation/).

L'image suivante montre les propriétés du document original de la présentation PowerPoint.

![Original document properties of the PowerPoint presentation](input_properties.png)

L'exemple suivant modifie le titre et la date de dernière sauvegarde, puis écrit le résultat dans un nouveau fichier :

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/date_time.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto sourceFile = String(u"sample.pptx");
auto outputFile = String(u"sample_with_updated_properties.pptx");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(sourceFile);
auto documentProperties = presentationInfo->ReadDocumentProperties();

documentProperties->set_Title(u"Quarterly sales report");
documentProperties->set_LastSavedTime(DateTime::get_UtcNow());

presentationInfo->UpdateDocumentProperties(documentProperties);
presentationInfo->WriteBindedPresentation(outputFile);
```

L'image suivante montre les propriétés du document modifiées de la présentation PowerPoint.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Liens utiles**

Pour des vérifications de sécurité et des paramètres de protection connexes, consultez les articles suivants :

- [Présentations protégées par mot de passe](/slides/fr/cpp/password-protected-presentation/)
- [Présentations protégées en écriture](/slides/fr/cpp/write-protected-presentation/)

## **FAQ**

**Comment vérifier si les polices sont intégrées et lesquelles le sont ?**

Chargez la présentation et utilisez [Presentation::get_FontsManager](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_fontsmanager/). Appelez [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/fr/cpp/aspose.slides/fontsmanager/getembeddedfonts/) pour obtenir les polices intégrées et [FontsManager::GetFonts](https://reference.aspose.com/slides/fr/cpp/aspose.slides/fontsmanager/getfonts/) pour obtenir les polices utilisées par la présentation. Comparez les deux résultats pour identifier les polices nécessaires au rendu mais qui ne sont pas intégrées.

**Comment savoir rapidement si le fichier possède des diapositives masquées et combien ?**

Lorsque les métadonnées du document stockées sont suffisantes, lisez [IDocumentProperties::get_HiddenSlides](https://reference.aspose.com/slides/fr/cpp/aspose.slides/idocumentproperties/get_hiddenslides/) via [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) et [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/). Cela convient pour un inventaire léger. Si la présentation a été modifiée en mémoire, les métadonnées stockées peuvent être manquantes ou obsolètes, ou si vous devez vérifier les valeurs en direct, parcourez [Presentation::get_Slides](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_slides/) et inspectez la méthode [Slide::get_Hidden](https://reference.aspose.com/slides/fr/cpp/aspose.slides/slide/get_hidden/) de chaque diapositive à la place.

**Puis-je détecter si une taille de diapositive personnalisée et une orientation sont utilisées, et si elles diffèrent des valeurs par défaut ?**

Oui. Chargez la présentation et lisez [Presentation::get_SlideSize](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_slidesize/). Inspectez [ISlideSize::get_Type](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidesize/get_type/), [ISlideSize::get_Size](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidesize/get_size/) et [ISlideSize::get_Orientation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidesize/get_orientation/) pour comparer les paramètres actuels avec le préréglage et les dimensions attendus.

**Existe-t-il un moyen rapide de vérifier si les graphiques référencent des sources de données externes ?**

Oui. Localisez chaque [Chart](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/chart/) et inspectez [ChartData::get_DataSourceType](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/chartdata/get_datasourcetype/). Pour un classeur externe, lisez [ChartData::get_ExternalWorkbookPath](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/). Le type de source de données et le chemin identifient une référence externe, mais vérifier la disponibilité de la cible nécessite une vérification de ressources distincte.

**Comment évaluer les diapositives « lourdes » qui peuvent ralentir le rendu ou l'export PDF ?**

Il n'existe pas de propriété unique de complexité. Parcourez [Presentation::get_Slides](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_slides/) et la collection [IBaseSlide::get_Shapes](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ibaseslide/get_shapes/) de chaque diapositive. Utilisez le nombre de formes et la présence d'images volumineuses, d'effets, d'animations ou de contenus multimédias comme indicateurs de filtrage, et réalisez un rendu ou une exportation représentative avant de considérer une diapositive comme un goulet d'étranglement de performance confirmé.