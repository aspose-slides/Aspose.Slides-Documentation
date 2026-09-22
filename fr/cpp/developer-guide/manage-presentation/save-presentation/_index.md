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
- format Office Open XML strict
- mode Zip64
- actualisation de la vignette
- progression d'enregistrement
- C++
- Aspose.Slides
description: "Enregistrez des présentations PowerPoint et OpenDocument dans des fichiers ou des flux en C++ avec Aspose.Slides, et configurez la sortie PPTX ainsi que le reporting de progression."
---
## **Vue d'ensemble**

Après avoir créé une présentation ou [ouvrir une présentation existante](/slides/fr/cpp/open-presentation/), utilisez la méthode [Presentation::Save](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/save/) pour écrire le résultat. Aspose.Slides pour C++ peut enregistrer une présentation dans un fichier ou un flux aux formats PowerPoint, OpenDocument, PDF et autres. Les sections suivantes couvrent les opérations d’enregistrement standard et les options disponibles pour la sortie PPTX.

## **Enregistrer des présentations dans des fichiers**

Pour enregistrer une présentation dans un fichier, transmettez le chemin de sortie et une valeur [SaveFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/saveformat/) à la méthode [Presentation::Save](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/save/). La valeur du format détermine le type de fichier créé par Aspose.Slides.

Voici l'exemple qui crée une présentation et l'enregistre au format PPTX :
```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();

// Ajouter ou modifier le contenu de la présentation ici.

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Enregistrer des présentations dans leur format d'origine**

Pour des exemples de détection de fichiers et de flux, le comportement des présentations nouvellement créées et la distinction entre les formats source et de sortie, consultez [Déterminer le format d'origine de la présentation](/slides/fr/cpp/detect-presentation-source-format/).

Dans une application de traitement par lots, le format d'entrée peut ne pas être connu à l’avance. Après avoir chargé un fichier, lisez son format d'origine avec [IPresentation::get_SourceFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentation/get_sourceformat/). Transmettez la valeur [SourceFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/sourceformat/) obtenue à [SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides.util/slideutil/tosaveformat/) pour obtenir la valeur [SaveFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/saveformat/) correspondante, puis utilisez [Presentation::Save](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/save/) pour écrire la présentation modifiée.

L'exemple complet suivant traite chaque fichier d'un répertoire d'entrée, met à jour son titre et l'enregistre dans un répertoire de sortie dans le format dans lequel il a été chargé :
```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <Util/SlideUtil.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Util;
using namespace System;
using namespace System::IO;

String inputDirectory = u"Input";
String outputDirectory = u"Output";

Directory::CreateDirectory_(outputDirectory);

auto inputPaths = Directory::GetFiles(inputDirectory);
for (const auto& inputPath : inputPaths)
{
    try
    {
        auto presentation = MakeObject<Presentation>(inputPath);

        auto sourceFormat = presentation->get_SourceFormat();
        auto saveFormat = SlideUtil::ToSaveFormat(sourceFormat);

        presentation->get_DocumentProperties()->set_Title(u"Processed by the batch application");

        auto outputPath = Path::Combine(outputDirectory, Path::GetFileName(inputPath));
        presentation->Save(outputPath, saveFormat);
        presentation->Dispose();
    }
    catch (ArgumentException& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Cannot map the source format of '{0}': {1}", inputPath, exception->get_Message()));
    }
    catch (Exception& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Cannot process '{0}': {1}", inputPath, exception->get_Message()));
    }
}
```

[SlideUtil::ToSaveFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides.util/slideutil/tosaveformat/) associe PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP et PowerPoint XML à leurs formats d’enregistrement de présentation correspondants. Il ne mappe que les formats source de présentation ; il n’est pas destiné à sélectionner des formats d’exportation tels que PDF, HTML, TIFF ou images. Fournir une valeur [SourceFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/sourceformat/) non prise en charge ou invalide entraîne une [ArgumentException](https://reference.aspose.com/slides/fr/cpp/system/argumentexception/).

Les fichiers PPT, PPS et POT hérité utilisent le même conteneur binaire. Lorsqu’une telle présentation est chargée depuis un flux sans extension de fichier, un fichier PPS ou POT peut donc être identifié comme PPT. Si la préservation de ces sous‑types hérités est requise, conservez le nom de fichier original ou les métadonnées de format séparément et utilisez‑les lors du choix du nom de fichier et du format de sortie.

## **Enregistrer des présentations dans des flux**

Pour écrire une présentation sans dépendre d’un chemin de fichier final, transmettez un [Stream](https://reference.aspose.com/slides/fr/cpp/system.io/stream/) accessible en écriture et une valeur [SaveFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/saveformat/) à la méthode [Presentation::Save](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/save/). Cette approche est utile lorsque la sortie doit être renvoyée par un service web, stockée dans une base de données ou traitée en mémoire.

L'exemple suivant enregistre une nouvelle présentation dans un flux de fichier :
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

auto presentation = MakeObject<Presentation>();
auto outputStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

presentation->Save(outputStream, SaveFormat::Pptx);

outputStream->Close();
presentation->Dispose();
```

## **Enregistrer des présentations avec un type de vue prédéfini**

Vous pouvez spécifier la vue avec laquelle PowerPoint ouvre initialement une présentation enregistrée. Appelez [ViewProperties::set_LastView](https://reference.aspose.com/slides/fr/cpp/aspose.slides/viewproperties/set_lastview/) avec une valeur [ViewType](https://reference.aspose.com/slides/fr/cpp/aspose.slides/viewtype/) avant l’enregistrement.

L'exemple suivant configure la vue Maître des diapositives comme vue initiale :
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

## **Enregistrer des présentations au format Office Open XML strict**

Pour créer un fichier PPTX conforme au profil Strict d’Office Open XML, créez une instance [PptxOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/pptxoptions/) et appelez [PptxOptions::set_Conformance](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/pptxoptions/set_conformance/) avec `Conformance::Iso29500_2008_Strict`. Transmettez ensuite les options à la méthode [Presentation::Save](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/save/).
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

auto presentation = MakeObject<Presentation>();

presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Enregistrer des présentations au format Office Open XML en mode Zip64**

Une archive ZIP standard limite la taille compressée et non compressée de chaque entrée, la taille totale de l’archive et le nombre d’entrées. Étant donné qu’un fichier PPTX est une archive ZIP, une présentation très volumineuse peut dépasser ces limites. Les extensions ZIP64 augmentent les limites de taille et de nombre d’entrées applicables.

Utilisez [PptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/pptxoptions/set_zip64mode/) pour contrôler si Aspose.Slides écrit les extensions ZIP64 :
- `IfNecessary` utilise ZIP64 uniquement lorsque la présentation dépasse les limites ZIP standards. C’est le mode par défaut.
- `Never` désactive les extensions ZIP64.
- `Always` écrit toujours les extensions ZIP64.

L'exemple suivant active toujours les extensions ZIP64 pour la présentation de sortie :
```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <Export/Zip64Mode.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_Zip64Mode(Zip64Mode::Always);

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

{{% alert color="warning" title="Warning" %}}
Si `Zip64Mode` est défini sur `Never` et que la présentation ne peut pas tenir dans les limites ZIP standards, l’opération d’enregistrement lance une [PptxException](https://reference.aspose.com/slides/fr/cpp/aspose.slides/pptxexception/).
{{% /alert %}}

## **Enregistrer des présentations au format Office Open XML avec niveaux de compression**

Pour la sortie PPTX, vous pouvez équilibrer la vitesse d’enregistrement et la taille du fichier en appelant [PptxOptions::set_CompressionLevel](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/pptxoptions/set_compressionlevel/). L’énumération [CompressionLevel](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/compressionlevel/) fournit les valeurs suivantes :
- `None` stocke les données sans compression.
- `Level1` offre la compression la plus rapide et la sortie compressée la plus grande.
- `Level2` à `Level5` privilégient progressivement une sortie plus petite au détriment de la vitesse d’enregistrement.
- `Level6` équilibre vitesse d’enregistrement et taille du fichier. C’est le niveau par défaut.
- `Level7` et `Level8` favorisent davantage une sortie plus petite au détriment de la vitesse d’enregistrement.
- `Level9` fournit la compression la plus forte et nécessite le plus de temps de traitement.

L'exemple suivant enregistre une présentation sans compression :
```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_CompressionLevel(CompressionLevel::None);

presentation->Save(u"OutputNoCompression.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

L'exemple suivant utilise le niveau de compression maximal :
```cpp
#include <DOM/Presentation.h>
#include <Export/CompressionLevel.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_CompressionLevel(CompressionLevel::Level9);

presentation->Save(u"OutputMaximumCompression.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Enregistrer des présentations sans actualiser la vignette**

Lorsqu’une présentation est enregistrée au format PPTX, [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) contrôle la vignette du document :
- `true` régénère la vignette pendant l’opération d’enregistrement. C’est la valeur par défaut.
- `false` préserve la vignette existante. Si la présentation n’a pas de vignette, Aspose.Slides n’en crée pas.

L'exemple suivant enregistre une présentation sans actualiser sa vignette :
```cpp
#include <DOM/Presentation.h>
#include <Export/PptxOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto options = MakeObject<PptxOptions>();
options->set_RefreshThumbnail(false);

presentation->Save(u"Output.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
La désactivation de l’actualisation de la vignette peut réduire le temps nécessaire pour enregistrer un fichier PPTX.
{{% /alert %}}

## **Enregistrer les mises à jour de progression en pourcentage**

Pour surveiller une opération d’enregistrement, implémentez l’interface [IProgressCallback](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iprogresscallback/) et transmettez l’implémentation à [ISaveOptions::set_ProgressCallback](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/isaveoptions/set_progresscallback/). Aspose.Slides appelle alors [IProgressCallback::Reporting](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iprogresscallback/reporting/) avec les valeurs de progression pendant l’export.

L'exemple suivant indique la progression d’une exportation PDF dans la console :
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

class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue) override
    {
        int progress = static_cast<int>(progressValue);
        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};

auto options = MakeObject<PdfOptions>();
options->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, options);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
Aspose propose un [PowerPoint Splitter](https://products.aspose.app/slides/fr/splitter) gratuit, construit avec l’API Aspose.Slides. Il enregistre les diapositives sélectionnées d’une présentation en fichiers PPT ou PPTX séparés.
{{% /alert %}}

## **FAQ**

**Aspose.Slides prend‑t‑il en charge l’enregistrement incrémental ou « fast save » ?**

Non. Chaque opération d’enregistrement écrit un fichier de sortie complet plutôt que de ne mettre à jour que les parties modifiées.

**Plusieurs threads peuvent-ils enregistrer la même instance de Presentation ?**

Non. Une instance de [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) [n’est pas thread‑safe](/slides/fr/cpp/multithreading/). Accédez et enregistrez chaque instance depuis un seul thread à la fois.

**Que se passe‑t‑il avec les hyperliens et les fichiers liés externement lorsque j’enregistre une présentation ?**

[Hyperlinks](/slides/fr/cpp/manage-hyperlinks/) restent dans la présentation. Aspose.Slides ne copie pas les fichiers liés externement, de sorte que la présentation enregistrée doit encore pouvoir accéder à leurs emplacements.

**Puis‑je enregistrer les métadonnées du document comme l’auteur, le titre, l’entreprise et la date de création ?**

Oui. Définissez les [propriétés du document](/slides/fr/cpp/presentation-properties/) appropriées avant l’enregistrement, et Aspose.Slides les écrit dans le fichier de sortie.