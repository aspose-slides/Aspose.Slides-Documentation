---
title: Récupérer et mettre à jour les informations de présentation en C++
linktitle: Informations sur la présentation
type: docs
weight: 30
url: /fr/cpp/examine-presentation/
keywords:
- format de présentation
- propriétés de présentation
- propriétés du document
- obtenir les propriétés
- lire les propriétés
- changer les propriétés
- modifier les propriétés
- mettre à jour les propriétés
- examiner PPTX
- examiner PPT
- examiner ODP
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Explorez les diapositives, la structure et les métadonnées des présentations PowerPoint et OpenDocument en C++ pour obtenir des informations plus rapides et des audits de contenu plus intelligents."
---
## **Vue d'ensemble**

Cet article montre comment inspecter les informations d'une présentation dans Aspose.Slides. Il explique comment déterminer le format actuel d'une présentation sans charger le fichier complet, lire ses propriétés de document et mettre à jour ces propriétés si nécessaire.

Les exemples sont basés sur les API [PresentationInfo](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentationinfo/) et [DocumentProperties](https://reference.aspose.com/slides/fr/cpp/aspose.slides/documentproperties/) et démontrent des opérations typiques pour travailler avec les métadonnées d'une présentation.

## **Vérifier le format d'une présentation**

Avant de travailler sur une présentation, vous pouvez vouloir savoir dans quel format (PPT, PPTX, ODP, etc.) la présentation se trouve actuellement.

Vous pouvez vérifier le format d'une présentation sans la charger. Voir ce code C++ :

``` cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
// PPTX
Console::WriteLine(ObjectExt::ToString(info->get_LoadFormat()));

auto info2 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.ppt");
// PPT
Console::WriteLine(ObjectExt::ToString(info2->get_LoadFormat()));

auto info3 = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.odp");
// ODP
Console::WriteLine(ObjectExt::ToString(info3->get_LoadFormat()));
```

## **Obtenir les propriétés de la présentation**

Ce code C++ vous montre comment obtenir les propriétés de la présentation (informations sur la présentation) :

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"pres.pptx");
auto props = info->ReadDocumentProperties();
Console::WriteLine(ObjectExt::ToString(props->get_CreatedTime()));
Console::WriteLine(props->get_Subject());
Console::WriteLine(props->get_Title());
// ..
```

## **Mettre à jour les propriétés de la présentation**

Aspose.Slides fournit la méthode [PresentationInfo::UpdateDocumentProperties](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentationinfo/updatedocumentproperties/) qui permet d'apporter des modifications aux propriétés de la présentation.

Supposons que nous ayons une présentation PowerPoint avec les propriétés de document affichées ci-dessous.

![Propriétés du document original de la présentation PowerPoint](input_properties.png)

Cet exemple de code vous montre comment modifier certaines propriétés de la présentation :

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/date_time.h>
using namespace Aspose::Slides;
using namespace System;

auto fileName = u"sample.pptx";

auto info = PresentationFactory::get_Instance()->GetPresentationInfo(fileName);

auto properties = info->ReadDocumentProperties();
properties->set_Title(u"My title");
properties->set_LastSavedTime(DateTime::get_Now());

info->UpdateDocumentProperties(properties);
info->WriteBindedPresentation(fileName);
```

Les résultats de la modification des propriétés du document sont affichés ci-dessous.

![Propriétés du document modifiées de la présentation PowerPoint](output_properties.png)

## **Liens utiles**

Pour obtenir plus d'informations sur une présentation et ses attributs de sécurité, vous trouverez peut-être ces liens utiles :

- [Protéger les présentations par mot de passe](/slides/fr/cpp/password-protected-presentation/)
- [Protéger les présentations en écriture](/slides/fr/cpp/write-protected-presentation/)

## **FAQ**

**Comment puis‑je vérifier si les polices sont incorporées et quelles sont‑elles ?**  
Recherchez les [informations sur les polices incorporées](https://reference.aspose.com/slides/fr/cpp/aspose.slides/fontsmanager/getembeddedfonts/) au niveau de la présentation, puis comparez ces entrées avec l'ensemble des [polices réellement utilisées dans le contenu](https://reference.aspose.com/slides/fr/cpp/aspose.slides/fontsmanager/getfonts/) pour identifier les polices essentielles au rendu.

**Comment puis‑je rapidement savoir si le fichier contient des diapositives cachées et combien ?**  
Parcourez la [collection de diapositives](https://reference.aspose.com/slides/fr/cpp/aspose.slides/slidecollection/) et examinez le [drapeau de visibilité](https://reference.aspose.com/slides/fr/cpp/aspose.slides/slide/get_hidden/) de chaque diapositive.

**Puis‑je détecter si une taille et orientation de diapositive personnalisées sont utilisées, et si elles diffèrent des valeurs par défaut ?**  
Oui. Comparez la [taille et l'orientation de la diapositive actuelles](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_slidesize/) avec les préréglages standard ; cela aide à anticiper le comportement lors de l'impression et de l'exportation.

**Existe‑t‑il un moyen rapide de voir si les graphiques font référence à des sources de données externes ?**  
Oui. Parcourez tous les [graphiques](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/chart/), vérifiez leur [source de données](https://reference.aspose.com/slides/fr/cpp/aspose.slides.charts/chartdata/get_datasourcetype/), et notez si les données sont internes ou basées sur un lien, y compris les liens cassés.

**Comment puis‑je évaluer les diapositives « lourdes » qui pourraient ralentir le rendu ou l'exportation PDF ?**  
Pour chaque diapositive, comptez le nombre d'objets et recherchez les images volumineuses, la transparence, les ombres, les animations et les médias ; attribuez un score de complexité approximatif afin d'identifier les points chauds potentiels de performance.