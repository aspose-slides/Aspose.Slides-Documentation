---
title: Sécuriser les présentations avec des mots de passe en C++
linktitle: Protection par mot de passe
type: docs
weight: 20
url: /fr/cpp/password-protected-presentation/
keywords:
- verrouiller PowerPoint
- verrouiller la présentation
- déverrouiller PowerPoint
- déverrouiller la présentation
- protéger PowerPoint
- protéger la présentation
- définir un mot de passe
- ajouter un mot de passe
- chiffrer PowerPoint
- chiffrer la présentation
- déchiffrer PowerPoint
- déchiffrer la présentation
- protection en écriture
- sécurité PowerPoint
- sécurité de la présentation
- supprimer le mot de passe
- supprimer la protection
- supprimer le chiffrement
- désactiver le mot de passe
- désactiver la protection
- supprimer la protection en écriture
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Apprenez à verrouiller et déverrouiller facilement les présentations PowerPoint et OpenDocument protégées par mot de passe avec Aspose.Slides pour C++. Sécurisez vos présentations."
---
## **Introduction**

Lorsque vous protégez un diaporama par mot de passe, vous définissez un mot de passe qui impose certaines restrictions au diaporama. Pour supprimer les restrictions, il faut saisir le mot de passe. Un diaporama protégé par mot de passe est considéré comme un diaporama verrouillé.

En général, vous pouvez définir un mot de passe pour appliquer ces restrictions à un diaporama :

- **Modification**

  Si vous ne voulez autoriser que certains utilisateurs à modifier votre diaporama, vous pouvez définir une restriction de modification. Cette restriction empêche les personnes de modifier, changer ou copier des éléments de votre diaporama (sauf si elles fournissent le mot de passe).  

  Cependant, dans ce cas, même sans le mot de passe, un utilisateur pourra accéder à votre document et l'ouvrir. En mode lecture seule, l'utilisateur peut visualiser le contenu ou les éléments — hyperliens, animations, effets, etc. — à l'intérieur de votre diaporama, mais il ne peut pas copier les éléments ni enregistrer le diaporama.  

- **Ouverture**

  Si vous ne voulez autoriser que certains utilisateurs à ouvrir votre diaporama, vous pouvez définir une restriction d'ouverture. Cette restriction empêche les personnes de même visualiser le contenu de votre diaporama (sauf si elles fournissent le mot de passe).  

  Techniquement, la restriction d'ouverture empêche également les utilisateurs de modifier vos diaporamas : lorsque les personnes ne peuvent pas ouvrir un diaporama, elles ne peuvent pas le modifier ni y apporter de changements.  

**Remarque** : lorsque vous protégez un diaporama par mot de passe pour empêcher son ouverture, le fichier du diaporama devient chiffré.

## **Comment protéger un diaporama par mot de passe en ligne**

1. Accédez à la page [**Verrouillage Aspose.Slides**](https://products.aspose.app/slides/fr/lock) de notre site.  

   ![todo:image_alt_text](slides-lock.png)

2. Cliquez sur **Déposez ou téléchargez vos fichiers**.

3. Sélectionnez le fichier que vous souhaitez protéger par mot de passe sur votre ordinateur. 

4. Saisissez le mot de passe de votre choix pour la protection en modification ; saisissez le mot de passe de votre choix pour la protection en visualisation. 

5. Si vous voulez que les utilisateurs voient votre diaporama comme la copie finale, cochez la case **Marquer comme final**.

6. Cliquez sur **PROTECT NOW.** 

7. Cliquez sur **DOWNLOAD NOW.**

## **Protection par mot de passe pour les diaporamas dans Aspose.Slides**
**Formats pris en charge**

Aspose.Slides prend en charge la protection par mot de passe, le chiffrement et des opérations similaires pour les diaporamas dans ces formats :

- PPTX et PPT - Présentation Microsoft PowerPoint  
- ODP - Présentation OpenDocument  
- OTP - Modèle de présentation OpenDocument  

**Opérations prises en charge**

Aspose.Slides vous permet d’utiliser la protection par mot de passe sur les diaporamas pour empêcher les modifications de ces manières :

- Chiffrer un diaporama  
- Définir une protection en écriture pour un diaporama  

**Autres opérations**

Aspose.Slides vous permet d’effectuer d’autres tâches liées à la protection par mot de passe et au chiffrement de ces manières :

- Déchiffrer un diaporama ; ouvrir un diaporama chiffré  
- Supprimer le chiffrement ; désactiver la protection par mot de passe  
- Supprimer la protection en écriture d’un diaporama  
- Obtenir les propriétés d’un diaporama chiffré  
- Vérifier si un diaporama est chiffré  
- Vérifier si un diaporama est protégé par mot de passe.  

## **Chiffrer un diaporama**

Vous pouvez chiffrer un diaporama en définissant un mot de passe. Ensuite, pour modifier le diaporama verrouillé, l'utilisateur doit fournir le mot de passe.  

Pour chiffrer ou protéger par mot de passe un diaporama, vous devez utiliser la méthode encrypt (de [ProtectionManager](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.protection_manager)) pour définir un mot de passe pour le diaporama. Vous transmettez le mot de passe à la méthode encrypt et utilisez la méthode save pour enregistrer le diaporama désormais chiffré.  

Ce code d’exemple vous montre comment chiffrer un diaporama :

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Définir une protection en écriture pour un diaporama** 

Vous pouvez ajouter une mention « Ne pas modifier » à un diaporama. Ainsi, vous indiquez aux utilisateurs que vous ne souhaitez pas qu’ils apportent des modifications au diaporama.  

**Remarque** : le processus de protection en écriture ne chiffre pas le diaporama. Ainsi, les utilisateurs—s’ils le souhaitent réellement—peuvent modifier le diaporama, mais pour enregistrer les modifications, ils devront créer un diaporama sous un nom différent.  

Pour définir une protection en écriture, vous devez utiliser la méthode setWriteProtection. Ce code d’exemple vous montre comment appliquer une protection en écriture à un diaporama :

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Charger un diaporama chiffré**

Aspose.Slides vous permet de charger un fichier chiffré en transmettant son mot de passe. Pour déchiffrer un diaporama, vous devez appeler la méthode [RemoveEncryption](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) sans paramètres. Vous devrez alors entrer le mot de passe correct pour charger le diaporama.  

Ce code d’exemple vous montre comment déchiffrer un diaporama :

``` cpp
#include <DOM/LoadOptions.h>
using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// travailler avec la présentation déchiffrée
```

## **Supprimer le chiffrement d’un diaporama**

Vous pouvez supprimer le chiffrement ou la protection par mot de passe d’un diaporama. Ainsi, les utilisateurs peuvent accéder au diaporama ou le modifier sans restrictions.  

Pour supprimer le chiffrement ou la protection par mot de passe, vous devez appeler la méthode [RemoveEncryption](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d). Ce code d’exemple vous montre comment supprimer le chiffrement d’un diaporama :

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Supprimer la protection en écriture d’un diaporama**

Vous pouvez utiliser Aspose.Slides pour supprimer la protection en écriture appliquée à un fichier de diaporama. Ainsi, les utilisateurs peuvent modifier à leur guise — sans aucun avertissement lors de ces opérations.  

Vous pouvez supprimer la protection en écriture d’un diaporama en utilisant la méthode [RemoveWriteProtection](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50). Ce code d’exemple vous montre comment enlever la protection en écriture d’un diaporama :

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Obtenir les propriétés d’un diaporama chiffré**

En général, les utilisateurs ont du mal à récupérer les propriétés du document d’un diaporama chiffré ou protégé par mot de passe. Cependant, Aspose.Slides fournit un mécanisme qui vous permet de protéger un diaporama par mot de passe tout en conservant l’accès à ses propriétés de document.  

**Remarque** : par défaut, lorsqu’Aspose.Slides chiffre un diaporama, les propriétés du document du diaporama sont également protégées par mot de passe. Si vous devez rendre les propriétés du document accessibles même après le chiffrement, Aspose.Slides vous permet de le faire.  

Si vous souhaitez que les utilisateurs conservent la capacité d’accéder aux propriétés d’un diaporama chiffré, passez `false` à la méthode `set_EncryptDocumentProperties` de [IProtectionManager](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iprotectionmanager/). Ce code d’exemple vous montre comment chiffrer un diaporama tout en permettant aux utilisateurs d’accéder à ses propriétés de document :

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Charger uniquement les propriétés du document d’un diaporama chiffré**

Pour inspecter les métadonnées d’un diaporama chiffré sans charger ses diapositives ou autres contenus, créez un objet [LoadOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides/loadoptions/) et définissez [set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/fr/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) sur `true`. Dans ce mode, Aspose.Slides ignore le mot de passe et charge uniquement les propriétés du document qui sont publiquement accessibles.  

L’exemple de code suivant lit les propriétés de document intégrées et personnalisées via [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentation/get_documentproperties/) :

``` cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);
auto documentProperties = presentation->get_DocumentProperties();

// Read built-in document properties.
auto title = documentProperties->get_Title();
auto author = documentProperties->get_Author();
Console::WriteLine(String(u"Title: ") + title);
Console::WriteLine(String(u"Author: ") + author);

// Read custom document properties.
int customPropertyCount = documentProperties->get_CountOfCustomProperties();

for (int propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    auto propertyName = documentProperties->GetCustomPropertyName(propertyIndex);
    auto propertyValue = documentProperties->idx_get(propertyName);
    auto propertyValueText = ObjectExt::ToString(propertyValue);

    Console::WriteLine(propertyName + u": " + propertyValueText);
}

presentation->Dispose();
```

Ce flux de travail ne fonctionne que lorsque les propriétés du document ont été laissées non chiffrées (publiques) lors du chiffrement du diaporama. Si les propriétés du document sont chiffrées, définir `LoadOptions::set_OnlyLoadDocumentProperties` sur `true` provoque une exception car le mot de passe est ignoré dans ce mode. Pour accéder aux propriétés du document chiffrées ou charger le diaporama complet, y compris ses diapositives et autres contenus, fournissez le mot de passe correct avec `LoadOptions::set_Password` dans [LoadOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides/loadoptions/).

## **Vérifier si un diaporama est protégé par mot de passe**

Avant de charger un diaporama, vous pouvez vouloir vérifier et confirmer que le diaporama n’a pas été protégé par un mot de passe. Ainsi, vous évitez les erreurs et problèmes similaires qui surviennent lorsqu’un diaporama protégé par mot de passe est chargé sans son mot de passe.  

Ce code C++ vous montre comment examiner un diaporama pour savoir s’il est protégé par mot de passe (sans charger le diaporama lui‑même) :

```c++
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **Vérifier si un diaporama est chiffré**

Aspose.Slides vous permet de vérifier si un diaporama est chiffré. Pour effectuer cette tâche, vous pouvez utiliser la méthode [get_IsEncrypted()](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68), qui renvoie `true` si le diaporama est chiffré ou `false` s’il ne l’est pas.  

Ce code d’exemple vous montre comment vérifier si un diaporama est chiffré :

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **Vérifier si un diaporama est protégé en écriture**

Aspose.Slides vous permet de vérifier si un diaporama est protégé en écriture. Pour effectuer cette tâche, vous pouvez utiliser la méthode [get_IsWriteProtected()](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2), qui renvoie `true` si le diaporama est protégé en écriture ou `false` s’il ne l’est pas.  

Ce code d’exemple vous montre comment vérifier si un diaporama est protégé en écriture :

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **Vérifier l’utilisation du mot de passe du diaporama**

Vous pouvez vouloir vérifier et confirmer qu’un mot de passe spécifique a été utilisé pour protéger un document de diaporama. Aspose.Slides fournit les moyens de valider un mot de passe.  

Ce code d’exemple vous montre comment valider un mot de passe :

``` cpp
#include <DOM/IProtectionManager.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// vérifier si le mot de passe correspond à
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

Il renvoie `true` si le diaporama a été chiffré avec le mot de passe spécifié. Sinon, il renvoie `false`.  

{{% alert color="info" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/fr/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Quelles méthodes de chiffrement sont prises en charge par Aspose.Slides ?**

Aspose.Slides prend en charge des méthodes de chiffrement modernes, y compris les algorithmes basés sur AES, garantissant un haut niveau de sécurité des données pour vos diaporamas.  

**Que se passe-t-il si un mot de passe incorrect est saisi lors de la tentative d’ouverture d’un diaporama ?**

Une exception est levée si un mot de passe incorrect est utilisé, vous avertissant que l’accès au diaporama est refusé. Cela aide à empêcher l’accès non autorisé et protège le contenu du diaporama.  

**Y a‑t‑il des impacts sur les performances lors du travail avec des diaporamas protégés par mot de passe ?**

Le processus de chiffrement et de déchiffrement peut introduire une légère surcharge lors des opérations d’ouverture et d’enregistrement. Dans la plupart des cas, cet impact sur les performances est minime et n’affecte pas de manière significative le temps de traitement global de vos tâches de diaporama.