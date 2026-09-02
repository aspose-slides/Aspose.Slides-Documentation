---
title: Protection par mot de passe des présentations en C++
linktitle: Protection par mot de passe
type: docs
weight: 20
url: /fr/cpp/password-protected-presentation/
keywords:
- présentation protégée par mot de passe
- mot de passe d'ouverture
- chiffrer PowerPoint
- déchiffrer PowerPoint
- valider le mot de passe de la présentation
- vérifier le mot de passe de la présentation
- ouvrir une présentation chiffrée
- supprimer le chiffrement
- PowerPoint
- PPT
- PPTX
- présentation
- C++
- Aspose.Slides
description: "Chiffrer, détecter, valider, ouvrir et déchiffrer les présentations PowerPoint PPT et PPTX protégées par mot de passe en C++ avec Aspose.Slides."
---
## **Vue d'ensemble**

Un mot de passe d'ouverture chiffre une présentation. Le mot de passe correct est requis pour charger et afficher le contenu de la présentation, ainsi cette protection assure la confidentialité.

Un mot de passe d'ouverture est différent d'un mot de passe de protection en écriture. La protection en écriture restreint la modification mais ne chiffre pas le contenu et n'empêche pas le chargement de la présentation. Pour gérer les mots de passe de modification des présentations, voir [Write-Protect Presentations](/slides/fr/cpp/write-protected-presentation/).

Les flux de travail ci-dessous s'appliquent aux présentations PPT et PPTX. Les exemples utilisent les deux formats lorsque leur comportement basé sur les fichiers ou les flux est important.

## **Chiffrer une présentation avec un mot de passe d'ouverture**

Utilisez [IProtectionManager::Encrypt](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iprotectionmanager/encrypt/) pour attribuer un mot de passe d'ouverture. Ensuite, utilisez [IPresentation::Save](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentation/save/) pour enregistrer la présentation chiffrée.

L'exemple suivant chiffre une présentation PPTX :

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"open_password");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Charger une présentation chiffrée**

Définissez [LoadOptions::set_Password](https://reference.aspose.com/slides/fr/cpp/aspose.slides/loadoptions/set_password/) sur le mot de passe d'ouverture et transmettez les options à [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/) lors du chargement du fichier. Le chargement échoue lorsqu'un mot de passe d'ouverture est requis mais que le mot de passe fourni est absent ou incorrect.

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

// Travailler avec la présentation déchiffrée.
```

## **Supprimer le chiffrement d'une présentation**

Chargez la présentation avec son mot de passe d'ouverture, appelez [IProtectionManager::RemoveEncryption](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iprotectionmanager/removeencryption/), puis enregistrez le résultat. La présentation enregistrée peut alors être chargée sans mot de passe.

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Valider un mot de passe d'ouverture avant le chargement**

Utilisez [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) pour obtenir [IPresentationInfo](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentationinfo/) sans créer une instance complète de présentation. Vérifiez [IPresentationInfo::get_IsPasswordProtected](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentationinfo/get_ispasswordprotected/) avant de demander ou de valider un mot de passe. Lorsque la protection est présente, validez la valeur fournie avec [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentationinfo/checkpassword/).

### **Flux de travail par chemin de fichier**

L'exemple suivant valide un mot de passe d'ouverture pour un fichier PPTX, transmet la valeur validée à [LoadOptions::set_Password](https://reference.aspose.com/slides/fr/cpp/aspose.slides/loadoptions/set_password/), puis charge la présentation complète :

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

String filePath = u"protected-presentation.pptx";
String password = u"open_password";
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(filePath);

if (!presentationInfo->get_IsPasswordProtected())
{
    Console::WriteLine(u"The presentation does not have an opening password.");
}
else if (!presentationInfo->CheckPassword(password))
{
    Console::WriteLine(u"The opening password is incorrect.");
}
else
{
    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(password);
    auto presentation = MakeObject<Presentation>(filePath, loadOptions);

    Console::WriteLine(u"The presentation was validated and loaded successfully.");
}
```

### **Flux de travail en flux**

La surcharge de flux de [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) fournit le même flux de travail. Réinitialisez la position d'un flux recherchable avant de charger la présentation complète à partir de ce flux.

L'exemple suivant utilise un fichier PPT :

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

String password = u"open_password";
auto presentationStream = File::OpenRead(u"protected-presentation.ppt");
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(presentationStream);

if (!presentationInfo->get_IsPasswordProtected())
{
    Console::WriteLine(u"The presentation does not have an opening password.");
}
else if (!presentationInfo->CheckPassword(password))
{
    Console::WriteLine(u"The opening password is incorrect.");
}
else
{
    presentationStream->set_Position(0);

    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(password);
    auto presentation = MakeObject<Presentation>(presentationStream, loadOptions);

    Console::WriteLine(u"The presentation was validated and loaded successfully.");
}
```

### **Valeurs de retour de CheckPassword**

[IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentationinfo/checkpassword/) renvoie `true` uniquement lorsque la présentation possède un mot de passe d'ouverture et que le mot de passe fourni est correct. Il renvoie `false` dans chacun de ces cas :

- Le mot de passe est incorrect.
- La présentation n'a pas de mot de passe d'ouverture.
- Le mot de passe fourni est nul ou vide.

Le comportement est le même pour les présentations PPT et PPTX.

## **Vérifier si une présentation chargée est chiffrée**

Après avoir chargé une présentation avec le mot de passe correct, inspectez [IProtectionManager::get_IsEncrypted](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iprotectionmanager/get_isencrypted/) pour confirmer que la présentation source était chiffrée. Pour détecter la protection par mot de passe d'ouverture avant le chargement, utilisez `IPresentationInfo::get_IsPasswordProtected` comme indiqué ci‑dessus.

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");
auto presentation = MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
Console::WriteLine(isEncrypted ? u"The presentation is encrypted." : u"The presentation is not encrypted.");
```

## **Recommandations de sécurité**

{{% alert color="warning" title="Sécurité" %}}
Ne consignez pas les mots de passe d'ouverture ni ne les incluez dans les messages de diagnostic. Évitez les tentatives de validation répétées inutiles, conservez les mots de passe en mémoire uniquement le temps nécessaire, et réutilisez un résultat de validation réussi lors du chargement immédiat de la présentation.
{{% /alert %}}

## **Protéger une présentation par mot de passe en ligne**

1. Ouvrez l'application [Aspose.Slides Lock](https://products.aspose.app/slides/fr/lock).
1. Sélectionnez ou téléversez la présentation.
1. Saisissez un mot de passe pour la protection de la visualisation.
1. Saisissez éventuellement un mot de passe distinct pour la protection en écriture.
1. Appliquez la protection et téléchargez le fichier résultant.

{{% alert color="info" title="Voir aussi" %}}
- [Write-Protect Presentations](/slides/fr/cpp/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/fr/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Quelle est la différence entre un mot de passe d'ouverture et un mot de passe de protection en écriture ?**

Un mot de passe d'ouverture chiffre la présentation et est requis pour charger son contenu. Un mot de passe de protection en écriture restreint la modification sans chiffrer le contenu.

**Puis-je valider un mot de passe d'ouverture sans charger toutes les diapositives ?**

Oui. Obtenez les informations de la présentation, vérifiez si la protection par mot de passe d'ouverture est présente, et validez le mot de passe avant de créer une instance complète de présentation.

**Les flux de travail de vérification du mot de passe prennent-ils en charge à la fois PPT et PPTX ?**

Oui. La détection et la validation du mot de passe basées sur le chemin de fichier ou le flux se comportent de la même manière pour les présentations PPT et PPTX.