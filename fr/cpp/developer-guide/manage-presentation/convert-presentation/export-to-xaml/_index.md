---
title: Exporter des présentations vers XAML en C++
linktitle: Présentation en XAML
type: docs
weight: 30
url: /fr/cpp/export-to-xaml/
keywords:
- exporter PowerPoint
- exporter OpenDocument
- exporter présentation
- convertir PowerPoint
- convertir OpenDocument
- convertir présentation
- PowerPoint vers XAML
- OpenDocument vers XAML
- présentation vers XAML
- PPT vers XAML
- PPTX vers XAML
- ODP vers XAML
- enregistrer PPT en XAML
- enregistrer PPTX en XAML
- enregistrer ODP en XAML
- exporter PPT en XAML
- exporter PPTX en XAML
- exporter ODP en XAML
- C++
- Aspose.Slides
description: "Convertir des diapositives PowerPoint et OpenDocument en XAML avec C++ en utilisant Aspose.Slides—solution rapide, sans Office, qui conserve votre mise en page intacte."
---
## **Vue d'ensemble**

Cet article explique comment exporter des présentations PowerPoint vers XAML à l’aide d’Aspose.Slides. Il comprend une brève introduction à XAML, montre comment enregistrer une présentation au format XAML avec les paramètres par défaut et décrit comment personnaliser l’exportation via [XamlOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export.xaml/xamloptions/), y compris l’exportation des diapositives masquées. L’article répond également à quelques questions fréquentes concernant les polices de secours, la compatibilité des piles XAML et le comportement d’exportation des diapositives masquées.

## **À propos de XAML**

XAML est un langage de balisage basé sur XML utilisé pour décrire des interfaces utilisateur dans des frameworks tels que WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) et Xamarin.Forms.

Vous pouvez travailler avec des fichiers XAML dans un concepteur visuel ou écrire et modifier le balisage directement.

## **Exporter des présentations vers XAML avec les options par défaut**

L’exemple C++ suivant montre comment exporter une présentation vers XAML avec les paramètres par défaut :

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/XamlOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto xamlOptions = System::MakeObject<XamlOptions>();
presentation->Save(xamlOptions);
```

Par défaut, les diapositives exportées sont enregistrées dans un sous‑dossier `pres` du répertoire de travail actuel du processus, tel que renvoyé par [Directory::GetCurrentDirectory](https://reference.aspose.com/slides/fr/cpp/system.io/directory/getcurrentdirectory/). Le dossier est créé automatiquement, et toutes les images nécessaires y sont également enregistrées.

Le nom du dossier de sortie est tiré du nom du fichier source sans son extension. Pour `pres.pptx`, les fichiers de sortie sont nommés `pres/Slide_1.xaml`, `pres/Slide_2.xaml`, etc. Même si vous fournissez un chemin absolu vers la présentation d’entrée, le dossier de sortie est créé relativement au répertoire de travail actuel, et non à côté du fichier d’entrée.

## **Exporter des présentations vers XAML avec des options personnalisées**

Utilisez l’interface [IXamlOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export.xaml/ixamloptions/) pour contrôler la façon dont Aspose.Slides exporte une présentation vers XAML.

Pour enregistrer la sortie à un emplacement personnalisé, implémentez [IXamlOutputSaver](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export.xaml/ixamloutputsaver/) et transmettez une instance de votre implémentation à la méthode [set_OutputSaver](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/) de [XamlOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export.xaml/xamloptions/).

Pour inclure les diapositives masquées dans la sortie XAML, passez `true` à la méthode [set_ExportHiddenSlides](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/), comme le montre l’exemple C++ suivant :

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/XamlOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);
presentation->Save(xamlOptions);
```

## **Capturer tous les artefacts XAML générés**

Une exportation XAML peut produire un document XAML pour chaque diapositive exportée ainsi que des images et des ressources auxiliaires distinctes. Transmettez un [IXamlOutputSaver](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export.xaml/ixamloutputsaver/) personnalisé à [XamlOptions::set_OutputSaver](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/) pour recevoir ces artefacts au lieu d’utiliser le sauvegardeur de système de fichiers par défaut. Démarrez l’exportation avec la surcharge spécifique XAML de [Presentation::Save](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/save/) qui accepte les options XAML.

### **Comprendre le cycle de vie du rappel**

L’exportateur appelle [IXamlOutputSaver::Save](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export.xaml/ixamloutputsaver/save/) séparément pour chaque artefact généré :

- `path` identifie l’artefact et peut contenir des répertoires relatifs. Conservez cette information car XAML peut référencer des ressources via des chemins relatifs.
- `data` contient les octets de l’artefact. Les images et autres ressources binaires ne doivent pas être décodées en texte.
- Le sauvegardeur est responsable de retenir ou de persister les données avant de retourner. Les exemples copient chaque tableau d’octets dans une mémoire appartenant à l’application.
- Considérez l’exportation comme réussie uniquement lorsque l’opération d’enregistrement de la présentation se termine et que chaque rappel a été exécuté avec succès. Ne masquez pas les erreurs de stockage et ne lancez pas d’écritures en arrière‑plan non observées. Si la persistance se produit ultérieurement, ne signalez le succès global qu’après que cette étape ait également réussi.

[set_ExportHiddenSlides](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) s’applique également à un sauvegardeur personnalisé. Le paramètre par défaut, `false`, exclut les documents XAML des diapositives masquées. Le définir à `true` les inclut ainsi que toutes les ressources requises pour leur exportation. Le nombre de ressources dépend de la présentation ; ne supposez pas un rappel par diapositive ni un ordre de rappel fixe.

### **Exporter en mémoire et inspecter les artefacts**

Cet exemple complet charge `pres.pptx`, collecte chaque artefact dans un [Dictionary<String,ArrayPtr<uint8_t>>](https://reference.aspose.com/slides/fr/cpp/system.collections.generic/dictionary/), puis affiche son nom, son type et son nombre d’octets. Il préserve exactement les noms fournis. Les noms dupliqués entraînent l’échec de la collection au lieu d’écraser silencieusement un artefact.

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/IXamlOutputSaver.h>
#include <Export/Xaml/XamlOptions.h>
#include <system/array.h>
#include <system/collections/dictionary.h>
#include <system/console.h>
#include <system/string_comparer.h>
#include <system/io/path.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace System::Text;

class InMemoryXamlExample
{
    class MemoryXamlSaver : public IXamlOutputSaver
    {
    public:
        using ArtifactDictionary = Dictionary<String, ArrayPtr<uint8_t>>;
        SharedPtr<ArtifactDictionary> Artifacts = MakeObject<ArtifactDictionary>(StringComparer::get_Ordinal());

        void Save(String path, ArrayPtr<uint8_t> data) override
        {
            auto retainedData = data->Clone();
            Artifacts->Add(path, retainedData);
        }
    };

public:
    static void Run()
    {
        auto saver = MakeObject<MemoryXamlSaver>();
        auto presentation = MakeObject<Presentation>(u"pres.pptx");
        auto options = MakeObject<XamlOptions>();
        options->set_OutputSaver(saver);
        options->set_ExportHiddenSlides(true);
        presentation->Save(options);

        auto inspectXamlText = false;
        for (const auto& artifact : saver->Artifacts)
        {
            auto extension = Path::GetExtension(artifact.get_Key()).ToLowerInvariant();
            auto isXaml = extension == u".xaml";
            auto isImage = extension == u".png" || extension == u".jpg" || extension == u".jpeg" || extension == u".gif" || extension == u".bmp" || extension == u".tif" || extension == u".tiff" || extension == u".svg";
            String kind = isXaml ? u"slide XAML" : isImage ? u"image" : u"supporting resource";
            Console::WriteLine(u"{0}: {1} bytes ({2})", artifact.get_Key(), artifact.get_Value()->get_Length(), kind);

            // Décoder uniquement le XAML, et uniquement lorsque l'inspection textuelle est nécessaire.
            if (isXaml && inspectXamlText)
            {
                auto markup = Encoding::get_UTF8()->GetString(artifact.get_Value());
                Console::WriteLine(markup);
            }
        }
    }
};
```

Appelez `InMemoryXamlExample::Run` depuis votre application. Les vérifications d’extension sont utiles pour l’inspection ; conservez tous les artefacts, y compris les types de ressources inconnus. Laissez les octets inchangés lors du stockage ou de la transmission. Utilisez [Encoding::GetString](https://reference.aspose.com/slides/fr/cpp/system.text/encoding/getstring/) avec l’encodage UTF‑8 uniquement pour le XAML nécessitant un traitement textuel.

### **Regrouper les artefacts collectés dans une archive ZIP**

Cet exemple autonome collecte l’exportation, valide les noms et écrit les octets d’origine dans une archive ZIP. Un nom d’archive unique sépare les travaux d’exportation concurrents. Les entrées ZIP utilisent des barres obliques `/` et conservent les répertoires relatifs. Les noms non sûrs ou les collisions après normalisation provoquent le rejet de l’ensemble du paquet avant son écriture.

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/IXamlOutputSaver.h>
#include <Export/Xaml/XamlOptions.h>
#include <system/array.h>
#include <system/collections/dictionary.h>
#include <system/console.h>
#include <system/string_comparer.h>
#include <system/guid.h>
#include <system/io/file_access.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/io/path.h>
#include <zip/zip_file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace Aspose::Zip;

class ZipXamlExample
{
    class CollectedXamlSaver : public IXamlOutputSaver
    {
    public:
        using ArtifactDictionary = Dictionary<String, ArrayPtr<uint8_t>>;
        SharedPtr<ArtifactDictionary> Artifacts = MakeObject<ArtifactDictionary>(StringComparer::get_Ordinal());

        void Save(String path, ArrayPtr<uint8_t> data) override
        {
            auto retainedData = data->Clone();
            Artifacts->Add(path, retainedData);
        }
    };

public:
    static void Run()
    {
        auto saver = MakeObject<CollectedXamlSaver>();
        auto presentation = MakeObject<Presentation>(u"pres.pptx");
        auto options = MakeObject<XamlOptions>();
        options->set_OutputSaver(saver);
        options->set_ExportHiddenSlides(false);
        presentation->Save(options);

        auto entries = MakeObject<Dictionary<String, ArrayPtr<uint8_t>>>(StringComparer::get_OrdinalIgnoreCase());
        for (const auto& artifact : saver->Artifacts)
        {
            auto entryName = artifact.get_Key().Replace(u'\\', u'/');
            auto segments = entryName.Split(u'/');
            auto unsafeName = entryName.StartsWith(u"/", StringComparison::Ordinal) || entryName.Contains(u":");
            for (const auto& segment : segments)
            {
                unsafeName |= String::IsNullOrWhiteSpace(segment) || segment == u"." || segment == u"..";
            }

            if (unsafeName || entries->ContainsKey(entryName))
            {
                Console::WriteLine(u"Export rejected: unsafe or duplicate artifact name: {0}", artifact.get_Key());
                return;
            }
            entries->Add(entryName, artifact.get_Value());
        }

        auto jobId = Guid::NewGuid();
        auto archivePath = u"xaml-" + jobId.ToString(u"N") + u".zip";
        auto archive = MakeObject<ZipFile>();
        for (const auto& artifact : entries)
        {
            auto fileName = Path::GetFileName(artifact.get_Key());
            auto directoryName = Path::GetDirectoryName(artifact.get_Key()).Replace(u'\\', u'/');
            archive->AddEntry(fileName, directoryName, artifact.get_Value());
        }

        auto output = MakeObject<FileStream>(archivePath, FileMode::CreateNew, FileAccess::Write);
        archive->Save(output);
        output->Close();
        archive->Dispose();

        // Save finalise le répertoire ZIP ; fermez le fichier avant de signaler le succès.
        Console::WriteLine(u"Saved {0} artifacts to {1}", entries->get_Count(), archivePath);
    }
};
```

Appelez `ZipXamlExample::Run` depuis votre application. L’exemple utilise `Aspose::Zip::ZipFile` du runtime C++ pour écrire une archive locale ; l’exportateur lui‑même ne crée pas de fichiers XAML ou image détachés. Pour un stockage distant, remplacez l’étape d’écriture d’archive par des téléversements des tableaux d’octets collectés. Utilisez un identifiant de travail d’exportation + le nom d’artefact relatif complet comme clé blob, ou stockez l’identifiant du travail, le nom relatif et les données binaires dans une ligne de base de données. Publiez le travail uniquement après que tous les téléversements soient terminés ou que la transaction de base de données soit validée. Nettoyez la sortie partielle si la persistance échoue.

Pour les présentations volumineuses, un sauvegardeur personnalisé peut persister chaque artefact directement dans le stockage de l’application afin d’éviter de garder une copie supplémentaire de l’ensemble de l’exportation en mémoire. L’exportateur continue de collecter tous les artefacts générés en mémoire avant d’appeler le sauvegardeur. Gardez chaque rappel synchrone du point de vue de l’exportateur : retournez uniquement après que la destination ait accepté les octets, et laissez les échecs remonter à l’appelant.

### **Conserver les noms des ressources et vérifier les références**

- Normalisez les séparateurs de chemins lorsque la destination l’exige, mais conservez les répertoires relatifs. N’utilisez pas uniquement [Path::GetFileName](https://reference.aspose.com/slides/fr/cpp/system.io/path/getfilename/) à moins que chaque nom généré ne soit garanti unique et que les références aux ressources restent valides.
- Appliquez une validation des noms propre à la destination. Lors de l’écriture de fichiers détachés, rejetez les chemins absolus et les segments de traversée, résolvez la destination avec [Path::GetFullPath](https://reference.aspose.com/slides/fr/cpp/system.io/path/getfullpath/), et assurez‑vous qu’elle reste sous le répertoire d’exportation prévu, y compris le séparateur de répertoire dans le test de contenance. Utilisez un répertoire contrôlé par l’application sans liens symboliques pouvant rediriger les écritures.
- Utilisez un sauvegardeur et un espace de noms de stockage distincts pour chaque travail d’exportation. Détectez les collisions après normalisation des séparateurs et selon les règles de sensibilité à la casse de la destination.
- Avant la publication, analysez chaque document XAML comme XML et inspectez ses références de ressources basées sur des fichiers, telles que les attributs `Source` ou `ImageSource` d’une image. Résolvez chaque URI relative par rapport au répertoire de l’artefact XAML contenant, normalisez le nom de stockage résultant et confirmez que la clé du dictionnaire correspondante, l’entrée ZIP ou l’objet stocké existe. Traitez séparément les URI externes et les expressions de balisage XAML des noms de fichiers relatifs.

Par exemple, si `pres/Slide_1.xaml` référence `images/image1.png`, la ressource stockée doit être disponible sous `pres/images/image1.png`. Ne conserver que `image1.png` rompt la relation. Pour le stockage d’objets, préservez la même hiérarchie sous le préfixe du travail et rendez ces URLs de ressource accessibles au consommateur XAML. Rouvrez le ZIP complété pour vérifier les noms d’entrée et les octets des ressources, puis chargez des diapositives représentatives dans l’environnement XAML cible afin de confirmer que les images se résolvent correctement.

## **FAQ**

**Comment garantir des polices prévisibles si la police d’origine n’est pas disponible sur la machine ?**

Utilisez [set_DefaultRegularFont](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) dans [XamlOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export.xaml/xamloptions/) ; il sert de police de secours pendant l’exportation lorsque l’original est absent. Cela ne garantit pas que le XAML généré référence la police de secours ou que celle‑ci soit disponible sur la machine cible. Assurez‑vous que les polices référencées par le XAML soient présentes dans l’environnement où il est affiché.

**Le XAML exporté est‑il destiné uniquement à WPF ou peut‑il être utilisé dans d’autres piles XAML ?**

Aspose.Slides exporte du XAML WPF via son API publique. La compatibilité avec d’autres piles XAML, telles que UWP et Xamarin.Forms, n’est pas garantie. Testez le balisage généré dans votre environnement cible.

**Les diapositives masquées sont‑elles prises en charge et comment empêcher leur exportation par défaut ?**

Par défaut, les diapositives masquées ne sont pas incluses. Vous pouvez contrôler ce comportement via [set_ExportHiddenSlides](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) dans [XamlOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.export.xaml/xamloptions/) — maintenez-le désactivé si vous n’avez pas besoin de les exporter.