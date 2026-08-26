---
title: Protéger les présentations en écriture dans C++
linktitle: Protection en écriture
type: docs
weight: 25
url: /fr/cpp/write-protected-presentation/
keywords:
- protection en écriture
- protection en écriture PowerPoint
- mot de passe de modification
- restreindre la modification de la présentation
- supprimer la protection en écriture
- valider le mot de passe de modification
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Définir, détecter, valider et supprimer les mots de passe de protection en écriture dans les présentations PowerPoint PPT et PPTX à l’aide d’Aspose.Slides pour C++."
---
## **Introduction**

Un mot de passe de protection en écriture restreint la modification d’une présentation mais n’en chiffre pas le contenu. Les utilisateurs peuvent charger et visualiser une présentation protégée en écriture sans le mot de passe. Selon l’application, ils peuvent également modifier le contenu et l’enregistrer sous un autre nom, ainsi la protection en écriture ne doit pas être considérée comme un mécanisme de confidentialité.

Un mot de passe d’ouverture sert un objectif différent : il chiffre la présentation et est requis pour charger son contenu. Pour chiffrer une présentation ou valider un mot de passe d’ouverture, consultez [Protéger par mot de passe les présentations](/slides/fr/cpp/password-protected-presentation/).

Les flux de travail décrits dans cet article s’appliquent aux présentations PPT et PPTX. Les exemples utilisent des fichiers PPTX ; lors de l’enregistrement au format PPT, utilisez l’extension `.ppt` et le format d’enregistrement PPT correspondant.

## **Définir la protection en écriture d’une présentation**

Utilisez [IProtectionManager::SetWriteProtection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iprotectionmanager/setwriteprotection/) pour attribuer un mot de passe de modification d’une présentation. L’enregistrement de la présentation conserve le paramètre de protection.

L’exemple suivant applique la protection en écriture à une présentation PPTX :

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"modify_password");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Charger une présentation protégée en écriture**

Étant donné que la protection en écriture ne chiffre pas le contenu de la présentation, aucun mot de passe n’est requis pour charger la présentation. Le mot de passe n’est pertinent que lors de la validation de l’autorisation de modification de la présentation protégée.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"write-protected-pres.pptx");

Console::WriteLine(u"Slide count: {0}", presentation->get_Slides()->get_Count());
```

Ne transmettez pas de mot de passe de protection en écriture à [LoadOptions::set_Password](https://reference.aspose.com/slides/fr/cpp/aspose.slides/loadoptions/set_password/). Cette propriété accepte un mot de passe d’ouverture pour le contenu chiffré. Si une présentation possède les deux types de protection, fournissez le mot de passe d’ouverture pour la charger et gérez séparément le mot de passe de protection en écriture.

## **Supprimer la protection en écriture d’une présentation**

Utilisez [IProtectionManager::RemoveWriteProtection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iprotectionmanager/removewriteprotection/) pour supprimer la restriction de modification, puis enregistrez la présentation.

```cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"write-protected-pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Vérifier si une présentation est protégée en écriture**

Pour inspecter un fichier sans créer une instance complète de [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/), appelez [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) et examinez [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/). La propriété utilise [NullableBool](https://reference.aspose.com/slides/fr/cpp/aspose.slides/nullablebool/) et renvoie `NullableBool::True` lorsqu’une protection en écriture est détectée.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/NullableBool.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"write-protected-pres.pptx");

if (presentationInfo->get_IsWriteProtected() == NullableBool::True)
{
    Console::WriteLine(u"The presentation is write protected.");
}
else
{
    Console::WriteLine(u"Write protection was not detected.");
}
```

La surcharge par flux de [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) fournit les mêmes informations pour une présentation fournie sous forme de flux.

## **Valider un mot de passe de protection en écriture**

Utilisez [IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/) pour valider un mot de passe de modification sans charger la présentation complète. Vérifiez d’abord [IPresentationInfo::get_IsWriteProtected](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentationinfo/get_iswriteprotected/) afin que l’application ne demande ou ne valide un mot de passe que lorsque la protection en écriture est présente.

```cpp
#include <DOM/IPresentationInfo.h>
#include <DOM/NullableBool.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"write-protected-pres.pptx");

if (presentationInfo->get_IsWriteProtected() != NullableBool::True)
{
    Console::WriteLine(u"The presentation is not write protected.");
}
else if (presentationInfo->CheckWriteProtection(u"modify_password"))
{
    Console::WriteLine(u"The write-protection password is correct.");
}
else
{
    Console::WriteLine(u"The write-protection password is incorrect.");
}
```

[IPresentationInfo::CheckWriteProtection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentationinfo/checkwriteprotection/) ne valide que le mot de passe de protection en écriture. Il ne valide pas un mot de passe d’ouverture ni ne détermine si le contenu chiffré peut être chargé. À l’inverse, [IPresentationInfo::CheckPassword](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentationinfo/checkpassword/) ne valide qu’un mot de passe d’ouverture. Si une présentation complète a déjà été chargée, [IProtectionManager::CheckWriteProtection](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iprotectionmanager/checkwriteprotection/) fournit la même vérification de protection en écriture via son gestionnaire de protection.

Dans les applications en production, ne consignez pas les mots de passe et ne les incluez pas dans les messages de diagnostic. Évitez les tentatives de validation répétées inutiles et ne conservez les mots de passe en mémoire que le temps nécessaire.

{{% alert color="info" title="Voir aussi" %}}
- [Protéger par mot de passe les présentations](/slides/fr/cpp/password-protected-presentation/)
- [Présentations en lecture seule](/slides/fr/cpp/read-only-presentation/)
- [Signature numérique dans PowerPoint](/slides/fr/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**La protection en écriture chiffre‑t‑elle une présentation ?**

Non. Elle restreint la modification mais laisse le contenu de la présentation disponible pour le chargement et la visualisation.

**Le mot de passe de protection en écriture est‑il requis pour ouvrir une présentation ?**

Non. Seul un mot de passe d’ouverture est requis pour charger le contenu chiffré d’une présentation.

**Une présentation peut‑elle avoir à la fois un mot de passe d’ouverture et un mot de passe de protection en écriture ?**

Oui. Fournissez le mot de passe d’ouverture via les options de chargement pour ouvrir la présentation chiffrée, et validez séparément le mot de passe de protection en écriture lorsque l’autorisation de modification est requise.