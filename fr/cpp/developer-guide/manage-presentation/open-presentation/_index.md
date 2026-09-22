---
title: Ouvrir des présentations en C++
linktitle: Ouvrir une présentation
type: docs
weight: 20
url: /fr/cpp/open-presentation/
keywords:
- ouvrir PowerPoint
- ouvrir OpenDocument
- ouvrir une présentation
- ouvrir PPTX
- ouvrir PPT
- ouvrir ODP
- charger une présentation
- charger PPTX
- charger PPT
- charger ODP
- présentation protégée
- grande présentation
- ressource externe
- objet binaire
- C++
- Aspose.Slides
description: "Apprenez comment ouvrir des présentations PowerPoint et OpenDocument en C++, fournir des mots de passe d’ouverture, contrôler le chargement des ressources et réduire l’utilisation de la mémoire avec Aspose.Slides pour C++."
---
## **Introduction**

[Aspose.Slides for C++](https://products.aspose.com/slides/fr/cpp/) peut charger des présentations PowerPoint et OpenDocument à partir de fichiers ou de flux. Une fois la présentation chargée, vous pouvez inspecter sa structure, modifier les diapositives, gérer les ressources et l’enregistrer au format d’origine ou dans un autre format supporté.

Le comportement de chargement peut être personnalisé via la classe [LoadOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides/loadoptions/). Par exemple, vous pouvez fournir un mot de passe d’ouverture, conserver les gros objets binaires hors de la mémoire, contrôler les ressources externes ou omettre les données binaires incorporées.

## **Open Presentations**

Après avoir chargé un fichier ou un flux, vous pouvez [determine its original presentation format](/slides/fr/cpp/detect-presentation-source-format/) pour choisir la façon dont votre application le traite.

Pour ouvrir une présentation existante, transmettez son chemin de fichier au constructeur [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/). Libérez la présentation après usage afin que les poignées de fichier, les données temporaires et les autres ressources soient libérées rapidement.

L’exemple C++ suivant montre comment ouvrir une présentation et obtenir le nombre de diapositives :

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **Open Password-Protected Presentations**

Un mot de passe d’ouverture chiffre le contenu de la présentation. Pour charger la présentation complète, transmettez le mot de passe correct à [LoadOptions::set_Password](https://reference.aspose.com/slides/fr/cpp/aspose.slides/loadoptions/set_password/) et passez les options au constructeur [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/). Le chargement échoue si le mot de passe est absent ou incorrect.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = MakeObject<Presentation>(u"encrypted-presentation.pptx", loadOptions);

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

Pour la détection, la validation et les flux de travail de chiffrement des mots de passe, consultez [Password‑Protect Presentations](/slides/fr/cpp/password-protected-presentation/). Si une présentation chiffrée a été enregistrée intentionnellement avec des propriétés de document publiques, ces propriétés peuvent être lues sans mot de passe ; voir [Manage Presentation Properties](/slides/fr/cpp/presentation-properties/).

## **Open Large Presentations**

[LoadOptions::get_BlobManagementOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) contrôle la façon dont Aspose.Slides gère les gros objets binaires tels que les images, l’audio et la vidéo. Vous pouvez garder le fichier source verrouillé, autoriser des fichiers temporaires et limiter la quantité de données BLOB conservées en mémoire.

Le code C++ suivant montre le chargement d’une grande présentation (par exemple, 2 Go) :

```cpp
#include <DOM/ISlide.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IBlobManagementOptions.h>
#include <PresentationLockingBehavior.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

const String filePath = u"large-presentation.pptx";

auto loadOptions = MakeObject<LoadOptions>();
auto blobOptions = loadOptions->get_BlobManagementOptions();
blobOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobOptions->set_IsTemporaryFilesAllowed(true);
blobOptions->set_MaxBlobsBytesInMemory(10 * 1024 * 1024);

auto presentation = MakeObject<Presentation>(filePath, loadOptions);

presentation->get_Slide(0)->set_Name(u"Large presentation");
presentation->Save(u"large-presentation-copy.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

{{% alert color="info" title="Note" %}}

Avec `PresentationLockingBehavior::KeepLocked`, le fichier source reste verrouillé jusqu’à ce que l’objet `Presentation` soit libéré. Ne déplacez, n’écrasez ni ne supprimez pas le fichier source tant que cet objet est vivant.

Aspose.Slides peut copier le contenu d’un flux d’entrée lors du chargement. Pour les grosses présentations, un chemin de fichier est donc généralement plus efficace qu’un flux. Voir [Manage BLOBs](/slides/fr/cpp/manage-blob/) pour des options supplémentaires de stockage et de gestion de la mémoire.

{{% /alert %}}

## **Control External Resources**

[LoadOptions::set_ResourceLoadingCallback](https://reference.aspose.com/slides/fr/cpp/aspose.slides/loadoptions/set_resourceloadingcallback/) accepte une implémentation d’[IResourceLoadingCallback](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iresourceloadingcallback/). Le rappel peut fournir des données de remplacement, rediriger une ressource, utiliser le chargeur par défaut ou ignorer la ressource. Cela est utile lorsque les présentations contiennent des images externes qui doivent être résolues selon les règles de sécurité ou de stockage spécifiques à l’application.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <IResourceLoadingArgs.h>
#include <IResourceLoadingCallback.h>
#include <ResourceLoadingAction.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        auto isJpeg = args->get_OriginalUri().EndsWith(u".jpg", StringComparison::OrdinalIgnoreCase);
        if (!isJpeg || !File::Exists(u"approved-image.jpg"))
        {
            return ResourceLoadingAction::Skip;
        }

        auto imageData = File::ReadAllBytes(u"approved-image.jpg");
        args->SetData(imageData);
        return ResourceLoadingAction::UserProvided;
    }
};

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_ResourceLoadingCallback(MakeObject<ImageLoadingHandler>());

auto presentation = MakeObject<Presentation>(u"presentation-with-external-images.pptx", loadOptions);
Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **Load Presentations without Embedded Binary Objects**

Une présentation peut contenir des données binaires incorporées dont une application n’a pas besoin ou ne veut pas conserver. Exemples :

- projets VBA, accessibles via [IPresentation::get_VbaProject](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentation/get_vbaproject/) ;
- données OLE incorporées, accessibles via [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/) ;
- données de contrôle ActiveX, accessibles via [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icontrol/get_activexcontrolbinary/) .

Passez `true` à [LoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/fr/cpp/aspose.slides/loadoptions/set_deleteembeddedbinaryobjects/) pour supprimer ces données binaires lors du chargement. Enregistrez la présentation chargée pour conserver le résultat assaini.

Cette option réduit l’exposition à des charges utiles indésirables incorporées, mais ce n’est pas un système complet de détection de malware ou de désinfection de contenu.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_DeleteEmbeddedBinaryObjects(true);

auto presentation = MakeObject<Presentation>(u"presentation-with-embedded-data.pptx", loadOptions);

presentation->Save(u"presentation-without-embedded-data.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **FAQ**

**How can I tell that a file is corrupted and cannot be opened?**

Aspose.Slides lève une exception d’analyse ou de format pendant le chargement. Gérez cet échec séparément d’une erreur de mot de passe incorrect afin que l’application puisse signaler la cause avec précision.

**What happens if required fonts are missing?**

La présentation peut toujours se charger, mais le rendu et l’exportation peuvent substituer des polices. Vous pouvez [configure font substitution](/slides/fr/cpp/font-substitution/) ou [provide custom fonts](/slides/fr/cpp/custom-font/) pour rendre la sortie plus prévisible.

**Does loading a presentation also load its embedded media?**

L’audio et la vidéo incorporés deviennent accessibles via le modèle d’objet de la présentation. Les ressources externes sont résolues selon le comportement de chargement des ressources configuré et peuvent être indisponibles si leurs emplacements ne sont pas accessibles.