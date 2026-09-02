---
title: Enregistrer des présentations en C++
linktitle: Enregistrer la présentation
type: docs
weight: 80
url: /fr/cpp/save-presentation/
keywords:
- enregistrer PowerPoint
- enregistrer OpenDocument
- enregistrer présentation
- enregistrer diapositive
- enregistrer PPT
- enregistrer PPTX
- enregistrer ODP
- présentation vers fichier
- présentation vers flux
- type de vue prédéfini
- format Strict Office Open XML
- mode Zip64
- rafraîchissement de la vignette
- progression d'enregistrement
- C++
- Aspose.Slides
description: "Découvrez comment enregistrer des présentations en C++ avec Aspose.Slides — exportez vers PowerPoint ou OpenDocument tout en conservant la mise en page, les polices et les effets."
---
## **Vue d'ensemble**

[Open Presentations in C++](/slides/fr/cpp/open-presentation/) décrit comment utiliser la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) pour ouvrir une présentation. Cet article explique comment créer et enregistrer des présentations. La classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) contient le contenu d’une présentation. Que vous créiez une présentation à partir de zéro ou que vous en modifiiez une existante, vous voudrez l’enregistrer une fois terminé. Avec Aspose.Slides for C++, vous pouvez enregistrer dans un **fichier** ou un **flux**. Cet article explique les différentes façons d’enregistrer une présentation.

## **Enregistrer des présentations dans des fichiers**

Enregistrez une présentation dans un fichier en appelant la méthode `Save` de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/). Passez le nom du fichier et le format d’enregistrement à la méthode. L’exemple suivant montre comment enregistrer une présentation avec Aspose.Slides.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instanciez la classe Presentation qui représente un fichier de présentation.
auto presentation = MakeObject<Presentation>();

// Effectuez du travail ici...

// Enregistrez la présentation dans un fichier.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Enregistrer des présentations dans des flux**

Vous pouvez enregistrer une présentation dans un flux en passant un flux de sortie à la méthode `Save` de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/). Une présentation peut être écrite dans de nombreux types de flux. Dans l’exemple ci‑dessous, nous créons une nouvelle présentation et l’enregistrons dans un flux de fichier.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// Instanciez la classe Presentation qui représente un fichier de présentation.
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// Save the presentation to the stream.
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```

## **Enregistrer des présentations avec un type de vue prédéfini**

Aspose.Slides vous permet de définir la vue initiale que PowerPoint utilise lorsque la présentation générée s’ouvre via la classe [ViewProperties](https://reference.aspose.com/slides/fr/cpp/aspose.slides/viewproperties/). Utilisez la méthode [set_LastView](https://reference.aspose.com/slides/fr/cpp/aspose.slides/viewproperties/set_lastview/) avec une valeur de l’énumération [ViewType](https://reference.aspose.com/slides/fr/cpp/aspose.slides/viewtype/).

```cpp
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <ViewType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);

presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Enregistrer des présentations au format Strict Office Open XML**

Aspose.Slides vous permet d’enregistrer une présentation au format Strict Office Open XML. Utilisez la classe [PptxOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/pptxoptions/) et définissez sa propriété de conformité lors de l’enregistrement. Si vous définissez `Conformance.Iso29500_2008_Strict`, le fichier de sortie est enregistré au format Strict Office Open XML.

L’exemple ci‑dessous crée une présentation et l’enregistre au format Strict Office Open XML.

```cpp
#include <DOM/Presentation.h>
#include <Export/Conformance.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

// Instanciez la classe Presentation qui représente un fichier de présentation.
auto presentation = MakeObject<Presentation>();

// Enregistrez la présentation au format Strict Office Open XML.
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Enregistrer des présentations au format Office Open XML en mode Zip64**

Un fichier Office Open XML est une archive ZIP qui impose des limites de 4 GB (2^32 octets) sur la taille non compressée de tout fichier, la taille compressée de tout fichier et la taille totale de l’archive, ainsi qu’une limite de 65 535 (2^16‑1) fichiers. Les extensions du format ZIP64 augmentent ces limites à 2^64.

La méthode [IPptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/ipptxoptions/set_zip64mode/) vous permet de choisir quand utiliser les extensions du format ZIP64 lors de l’enregistrement d’un fichier Office Open XML.

Cette méthode peut être utilisée avec les modes suivants :

- `IfNecessary` utilise les extensions ZIP64 uniquement si la présentation dépasse les limitations ci‑dessus. C’est le mode par défaut.
- `Never` n’utilise jamais les extensions ZIP64.
- `Always` utilise toujours les extensions ZIP64.

Le code suivant montre comment enregistrer une présentation sous forme de fichier PPTX avec les extensions ZIP64 activées :

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <Export/Zip64Mode.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}
Lorsque vous enregistrez avec `Zip64Mode.Never`, une [PptxException](https://reference.aspose.com/slides/fr/cpp/aspose.slides/pptxexception/) est levée si la présentation ne peut pas être enregistrée au format ZIP32.
{{% /alert %}}

## **Enregistrer des présentations au format Office Open XML avec des niveaux de compression**

Lorsque vous travaillez avec de grandes présentations, vous pouvez ajuster le niveau de compression pour équilibrer la taille du fichier et le temps de traitement. Selon vos besoins, vous pouvez privilégier la rapidité du traitement ou la réduction de la taille du fichier de sortie.

Aspose.Slides fournit la méthode [PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/) qui vous permet de spécifier le niveau de compression utilisé lors de l’enregistrement d’une présentation au format Office Open XML.

Les niveaux de compression disponibles sont les suivants :

- **None** : aucune compression n’est appliquée. Les fichiers sont stockés tels quels.
- **Level1** : la compression la plus rapide avec le taux de compression le plus faible.
- **Level2** : compression plus rapide avec un taux légèrement meilleur que **Level1**.
- **Level3** : offre une meilleure compression que **Level2** avec un impact modéré sur le temps de traitement.
- **Level4** : offre une meilleure compression que **Level3**.
- **Level5** : améliore la compression par rapport à **Level4** avec un temps de traitement supplémentaire.
- **Level6** : compression standard qui offre un bon équilibre entre vitesse de traitement et taille du fichier. C’est le *niveau de compression par défaut*.
- **Level7** : offre une meilleure compression que **Level6** avec un traitement plus lent.
- **Level8** : offre une meilleure compression que **Level7**.
- **Level9** : compression maximale. Produit la plus petite taille de fichier au prix du temps de traitement le plus long.

L’exemple suivant montre comment enregistrer une présentation sous forme de fichier PPTX *sans compression* :

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Export::CompressionLevel;
using Aspose::Slides::Export::PptxOptions;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::MakeObject;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_CompressionLevel(CompressionLevel::None);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
presentation->Save(u"Sample-out.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

Cet exemple montre comment enregistrer une présentation sous forme de fichier PPTX avec *la compression maximale* :

```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Export::CompressionLevel;
using Aspose::Slides::Export::PptxOptions;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::MakeObject;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_CompressionLevel(CompressionLevel::Level9);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");
presentation->Save(u"Sample-level9.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

## **Enregistrer des présentations sans rafraîchir la vignette**

La méthode [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) contrôle la génération de la vignette lors de l’enregistrement d’une présentation au format PPTX :

- Si elle est définie sur `true`, la vignette est rafraîchie pendant l’enregistrement. C’est la valeur par défaut.
- Si elle est définie sur `false`, la vignette actuelle est conservée. Si la présentation n’a pas de vignette, aucune n’est générée.

Dans le code ci‑dessous, la présentation est enregistrée au format PPTX sans rafraîchir sa vignette.

```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Cette option contribue à réduire le temps requis pour enregistrer une présentation au format PPTX.
{{% /alert %}}

## **Mises à jour de progression de l’enregistrement en pourcentage**

L’interface [IProgressCallback](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iprogresscallback/) est utilisée via la méthode `set_ProgressCallback` exposée par l’interface [ISaveOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/isaveoptions/) et la classe abstraite [SaveOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/saveoptions/). Implémentez [IProgressCallback](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iprogresscallback/) et affectez‑lui `set_ProgressCallback` pour recevoir les mises à jour de progression d’enregistrement en pourcentage.

Les extraits de code suivants montrent comment utiliser `IProgressCallback`.

```cpp
#include <IProgressCallback.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        // Utilisez la valeur du pourcentage de progression ici.
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};
```
```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <IProgressCallback.h>
#include <system/console.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// La classe de rappel de progression définie ci-dessus.
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};

auto saveOptions = MakeObject<PdfOptions>();
saveOptions->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, saveOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Aspose a développé une [application gratuite de fractionnement PowerPoint](https://products.aspose.app/slides/fr/splitter) utilisant sa propre API. L’application vous permet de fractionner une présentation en plusieurs fichiers en enregistrant les diapositives sélectionnées en tant que nouveaux fichiers PPTX ou PPT.
{{% /alert %}}

## **FAQ**

**La « sauvegarde rapide » (sauvegarde incrémentielle) est‑elle prise en charge afin que seules les modifications soient écrites ?**

Non. L’enregistrement crée le fichier cible complet à chaque fois ; la « sauvegarde rapide » incrémentielle n’est pas prise en charge.

**Est‑il sûr d’enregistrer la même instance de Presentation depuis plusieurs threads ?**

Non. Une instance de [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) [n’est pas thread‑safe](/slides/fr/cpp/multithreading/) ; enregistrez‑la depuis un seul thread.

**Que se passe‑t‑il avec les hyperliens et les fichiers liés externes lors de l’enregistrement ?**

Les [hyperliens](/slides/fr/cpp/manage-hyperlinks/) sont conservés. Les fichiers liés externes (par ex. des vidéos via des chemins relatifs) ne sont pas copiés automatiquement ; assurez‑vous que les chemins référencés restent accessibles.

**Puis‑je définir/enregistrer les métadonnées du document (Auteur, Titre, Société, Date) ?**

Oui. Les [propriétés de document standard](/slides/fr/cpp/presentation-properties/) sont prises en charge et seront écrites dans le fichier lors de l’enregistrement.