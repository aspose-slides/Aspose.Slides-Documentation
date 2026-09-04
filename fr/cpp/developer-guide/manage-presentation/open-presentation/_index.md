---
title: Ouvrir des présentations en C++
linktitle: Ouvrir la présentation
type: docs
weight: 20
url: /fr/cpp/open-presentation/
keywords:
- ouvrir PowerPoint
- ouvrir OpenDocument
- ouvrir présentation
- ouvrir PPTX
- ouvrir PPT
- ouvrir ODP
- charger présentation
- charger PPTX
- charger PPT
- charger ODP
- présentation protégée
- grande présentation
- ressource externe
- objet binaire
- C++
- Aspose.Slides
description: "Apprenez comment ouvrir des présentations PowerPoint et OpenDocument en C++, fournir les mots de passe d'ouverture, contrôler le chargement des ressources et réduire l'utilisation de la mémoire avec Aspose.Slides pour C++."
---
## **Introduction**

[Aspose.Slides for C++](https://products.aspose.com/slides/fr/cpp/) peut charger des présentations PowerPoint et OpenDocument à partir de fichiers et de flux. Une fois une présentation chargee, vous pouvez inspecter sa structure, modifier les diapositives, gerer les ressources et l'enregistrer au format original ou dans un autre format pris en charge.

Le comportement de chargement peut être personnalisé via la classe [LoadOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides/loadoptions/). Par exemple, vous pouvez fournir un mot de passe d'ouverture, garder les gros objets binaires hors de la memoire, controler les ressources externes ou omettre les donnees binaires integrees.

## **Ouvrir des présentations**

Pour ouvrir une presentation existante, passez son chemin de fichier au constructeur [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/). Liberez la presentation apres usage afin que les handles de fichiers, les donnees temporaires et les autres ressources soient rapidement liberes.

L'exemple C++ suivant montre comment ouvrir une presentation et obtenir le nombre de diapositives :

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

## **Ouvrir des présentations protegees par mot de passe**

Un mot de passe d'ouverture chiffre le contenu de la presentation. Pour charger la presentation complete, transmettez le mot de passe correct a [LoadOptions::set_Password](https://reference.aspose.com/slides/fr/cpp/aspose.slides/loadoptions/set_password/) et passez les options au constructeur [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/). Le chargement echoue si le mot de passe est absent ou incorrect.

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

Pour la detection, la validation et les flux de travail de chiffrement des mots de passe, consultez [Password-Protect Presentations](/slides/fr/cpp/password-protected-presentation/). Si une presentation chiffree a ete enregistree intentionnellement avec des proprietes de document publiques, ces proprietes peuvent etre lues sans mot de passe ; voir [Manage Presentation Properties](/slides/fr/cpp/presentation-properties/).

## **Ouvrir de grandes presentations**

[LoadOptions::get_BlobManagementOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) controle la facon dont Aspose.Slides gere les objets binaires volumineux tels que les images, l'audio et la video. Vous pouvez garder le fichier source verouille, autoriser les fichiers temporaires et limiter la quantite de donnees BLOB conservees en memoire.

Le code C++ suivant demontre le chargement d'une grande presentation (par exemple, 2 Go) :

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

{{% alert color="info" title="Remarque" %}}

Avec `PresentationLockingBehavior::KeepLocked`, le fichier source reste verouille jusqu'a ce que l'objet `Presentation` soit libere. Ne deplacez pas, n'ecrasez pas et ne supprimez pas le fichier source tant que cet objet est vivant.

Aspose.Slides peut copier le contenu d'un flux d'entree lors du chargement. Pour les grandes presentations, un chemin de fichier est donc generale ment plus efficace qu'un flux. Consultez [Manage BLOBs](/slides/fr/cpp/manage-blob/) pour des options supplementaires de stockage et de gestion de la memoire.

{{% /alert %}}

## **Controler les ressources externes**

[LoadOptions::set_ResourceLoadingCallback](https://reference.aspose.com/slides/fr/cpp/aspose.slides/loadoptions/set_resourceloadingcallback/) accepte une implementation de [IResourceLoadingCallback](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iresourceloadingcallback/). Le rappel peut fournir des donnees de remplacement, rediriger une ressource, utiliser le chargeur par defaut ou ignorer la ressource. Cela est utile lorsque les presentations contiennent des images externes qui doivent etre resolues selon des regles de securite ou de stockage specifique a l'application.

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

## **Charger des presentations sans objets binaires integres**

Une presentation peut contenir des donnees binaires integrees qu'une application n'a pas besoin ou ne veut pas conserver. Les exemples incluent :

- projets VBA, disponibles via [IPresentation::get_VbaProject](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentation/get_vbaproject/);
- donnees OLE integrees, disponibles via [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/);
- donnees de controle ActiveX, disponibles via [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icontrol/get_activexcontrolbinary/).

Passez `true` a [LoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/fr/cpp/aspose.slides/loadoptions/set_deleteembeddedbinaryobjects/) pour supprimer ces donnees binaires lors du chargement. Enregistrez la presentation chargee pour conserver le resultat assaini.

Cette option reduit l'exposition a des charges utiles integrees indesirables, mais ce n'est pas un systeme complet de detection de logiciels malveillants ou de desinfection de contenu.

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

**Comment savoir si un fichier est corrompu et ne peut pas etre ouvert ?**

Aspose.Slides leve une exception d'analyse ou de format lors du chargement. Gerez cet echec separément d'une erreur de mot de passe incorrect afin que l'application puisse rapporter la cause avec precision.

**Que se passe-t-il si des polices requises sont manquantes ?**

La presentation peut toujours se charger, mais le rendu et l'exportation peuvent substituer les polices. Vous pouvez [configure font substitution](/slides/fr/cpp/font-substitution/) ou [provide custom fonts](/slides/fr/cpp/custom-font/) pour rendre la sortie plus previsible.

**Le chargement d'une presentation charge-t-il également ses medias integres ?**

L'audio et la video integrees deviennent accessibles via le modele d'objet de la presentation. Les ressources externes sont resolues selon le comportement de chargement de ressources configure et peuvent etre indisponibles si leurs emplacements ne sont pas accessibles.