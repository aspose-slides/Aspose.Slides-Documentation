---
title: Gérer les propriétés de la présentation en C++
linktitle: Propriétés de la présentation
type: docs
weight: 70
url: /fr/cpp/presentation-properties/
keywords:
- Propriétés PowerPoint
- propriétés de présentation
- propriétés du document
- propriétés intégrées
- propriétés personnalisées
- propriétés avancées
- gérer les propriétés
- modifier les propriétés
- métadonnées du document
- modifier les métadonnées
- langue de vérification
- langue par défaut
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Maîtrisez les propriétés de présentation dans Aspose.Slides pour C++ et simplifiez la recherche, le branding et le flux de travail dans vos fichiers PowerPoint et OpenDocument."
---
## **Introduction**

Aspose.Slides pour C++ prend en charge les propriétés de document **intégrées** et **personnalisées**. Utilisez ces propriétés pour lire et mettre à jour les métadonnées d’une présentation, telles que l’auteur, le titre et les valeurs définies par l’utilisateur.

Aspose.Slides vous permet de travailler avec les propriétés de document de présentation via l’interface [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/). Une instance de cette interface est renvoyée par [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/). Les exemples suivants montrent comment lire, modifier et gérer ces propriétés.

{{% alert color="info" title="Note" %}}
Aspose.Slides gère les métadonnées d’application et de producteur lors de l’enregistrement des présentations ; ces champs identifient le logiciel qui a créé le fichier de sortie.
{{% /alert %}}

## **Gérer les propriétés de la présentation**

Les propriétés de document stockent des informations descriptives à côté du contenu de la présentation. Elles se répartissent en deux catégories :

- **Propriétés intégrées** contiennent des métadonnées standard, telles que le titre, l’auteur et les statistiques du document.
- **Propriétés personnalisées** stockent des paires nom/valeur définies par l’utilisateur.

Aspose.Slides pour C++ donne accès aux deux catégories. Dans PowerPoint, choisissez **Fichier → Infos → Propriétés → Propriétés avancées** pour inspecter les métadonnées du document. La boîte de dialogue regroupe les informations dans des onglets tels que **Résumé**, **Statistiques**, **Contenu** et **Personnalisé**. Utilisez l’onglet **Personnalisé** pour gérer les propriétés définies par l’utilisateur.

## **Lire les propriétés publiques d’une présentation chiffrée**

Un mot de passe d’ouverture protège normalement à la fois le contenu de la présentation et les propriétés du document. Lorsque une présentation est chiffrée en passant `false` à [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/), ses propriétés de document restent publiques. Une application peut alors passer `true` à [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) et lire les métadonnées publiques sans fournir le mot de passe d’ouverture.

[LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) contrôle ce que Aspose.Slides charge ; il ne décrypte rien. Si les propriétés font partie du chiffrement, les charger sans le mot de passe échoue. Si la présentation n’est pas chiffrée, l’option est ignorée et la présentation complète est chargée.

L’exemple nécessite une présentation chiffrée dont les propriétés de document ont été laissées publiques. Il vérifie le mode de chargement via [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) puis lit les propriétés intégrées via [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/) :

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <DOM/LoadOptions.h>
#include <DOM/IProtectionManager.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = System::MakeObject<Presentation>(u"public-properties-encrypted.pptx", loadOptions);

if (presentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    auto documentProperties = presentation->get_DocumentProperties();

    System::Console::WriteLine(u"Author: {0}", documentProperties->get_Author());
    System::Console::WriteLine(u"Title: {0}", documentProperties->get_Title());
    System::Console::WriteLine(u"Keywords: {0}", documentProperties->get_Keywords());
}
else
{
    System::Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}
```

Dans ce mode, le contenu des diapositives n’est pas chargé. Les diapositives, maîtres, mises en page, formes, médias et autres objets de la présentation sont indisponibles. Les applications doivent toujours vérifier [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) avant d’effectuer une opération qui nécessite le modèle complet d’objets de la présentation.

{{% alert color="warning" title="Security" %}}
Les métadonnées publiques peuvent révéler les noms d’auteur, les titres, les sujets, les mots‑clé, les informations d’entreprise, les commentaires et les valeurs personnalisées. Chiffrez les propriétés sensibles avec la présentation. Ne les laissez publiques que lorsque l’indexation, la classification, la recherche ou les systèmes de gestion de documents ont besoin d’y accéder sans mot de passe.
{{% /alert %}}

## **Mettre à jour les propriétés d’une présentation chiffrée**

Pour un fichier PPTX chiffré, une présentation chargée en passant `true` à [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) est destinée à la lecture des métadonnées publiques. Aspose.Slides ne peut pas enregistrer les propriétés modifiées de cet objet contenant uniquement les métadonnées, car les propriétés publiques doivent rester cohérentes avec les données correspondantes à l’intérieur de la présentation chiffrée. Leur mise à jour nécessite donc le mot de passe d’ouverture correct et un chargement complet.

L’exemple nécessite une présentation PPTX chiffrée avec des propriétés de document publiques et un mot de passe d’ouverture connu. Il ouvre la présentation complète avec [LoadOptions::set_Password](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_password/), met à jour les propriétés intégrées publiques, puis enregistre le résultat. Il utilise ensuite [IPresentationInfo::get_IsEncrypted](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/get_isencrypted/) pour vérifier que le chiffrement est conservé et rouvre les métadonnées publiques sans mot de passe afin de vérifier les nouvelles valeurs :

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <DOM/LoadOptions.h>
#include <DOM/IProtectionManager.h>
#include <DOM/PresentationFactory.h>
#include <DOM/IPresentationInfo.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const System::String inputPath = u"public-properties-encrypted.pptx";
const System::String outputPath = u"updated-public-properties-encrypted.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(inputPath, loadOptions);

auto documentProperties = presentation->get_DocumentProperties();
documentProperties->set_Title(u"Updated Product Roadmap");
documentProperties->set_Keywords(u"roadmap, planning, indexed");

presentation->Save(outputPath, SaveFormat::Pptx);

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(outputPath);
System::Console::WriteLine(u"The presentation is encrypted: {0}", presentationInfo->get_IsEncrypted());

auto metadataLoadOptions = System::MakeObject<LoadOptions>();
metadataLoadOptions->set_OnlyLoadDocumentProperties(true);

auto metadataPresentation = System::MakeObject<Presentation>(outputPath, metadataLoadOptions);

if (metadataPresentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    System::Console::WriteLine(u"Title: {0}", metadataPresentation->get_DocumentProperties()->get_Title());
    System::Console::WriteLine(u"Keywords: {0}", metadataPresentation->get_DocumentProperties()->get_Keywords());
}
else
{
    System::Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}
```

Si une application n’est pas autorisée à déchiffrer ou charger le contenu de la présentation, elle doit considérer les propriétés publiques d’un fichier PPTX chiffré comme en lecture seule.

## **Accéder aux propriétés intégrées**

L’interface [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) expose les métadonnées intégrées via des accesseurs typés, notamment [get_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_author/), [get_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_title/) et [get_CreatedTime](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_createdtime/). Cet exemple ouvre une présentation existante et affiche ses métadonnées stockées dans la console. Les valeurs dépendent de la présentation d’entrée ; certains champs peuvent être vides.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"AccessBuiltInProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

System::Console::WriteLine(u"Category: {0}", documentProperties->get_Category());
System::Console::WriteLine(u"Content status: {0}", documentProperties->get_ContentStatus());
System::Console::WriteLine(u"Creation date: {0}", documentProperties->get_CreatedTime());
System::Console::WriteLine(u"Author: {0}", documentProperties->get_Author());
System::Console::WriteLine(u"Comments: {0}", documentProperties->get_Comments());
System::Console::WriteLine(u"Keywords: {0}", documentProperties->get_Keywords());
System::Console::WriteLine(u"Last modified by: {0}", documentProperties->get_LastSavedBy());
System::Console::WriteLine(u"Manager: {0}", documentProperties->get_Manager());
System::Console::WriteLine(u"Modified date: {0}", documentProperties->get_LastSavedTime());
System::Console::WriteLine(u"Presentation format: {0}", documentProperties->get_PresentationFormat());
System::Console::WriteLine(u"Last print date: {0}", documentProperties->get_LastPrinted());
System::Console::WriteLine(u"Is shared between producers: {0}", documentProperties->get_SharedDoc());
System::Console::WriteLine(u"Subject: {0}", documentProperties->get_Subject());
System::Console::WriteLine(u"Title: {0}", documentProperties->get_Title());
```

## **Modifier les propriétés intégrées**

Pour mettre à jour les métadonnées intégrées, utilisez les mutateurs sur l’objet renvoyé par [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/). Cet exemple ouvre une présentation existante, appelle [set_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_author/), [set_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_title/), [set_Subject](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_subject/), [set_Comments](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_comments/) et [set_Manager](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_manager/), puis enregistre la présentation mise à jour avec [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/). Le PPTX enregistré contient les nouvelles métadonnées.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"ModifyBuiltInProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

documentProperties->set_Author(u"Aspose.Slides for C++");
documentProperties->set_Title(u"Manage PowerPoint Presentation Properties");
documentProperties->set_Subject(u"Modify Built-in Properties");
documentProperties->set_Comments(u"Aspose description");
documentProperties->set_Manager(u"Aspose manager");

presentation->Save(u"DocumentProperties_output.pptx", SaveFormat::Pptx);
```

## **Gérer la base des hyperliens**

[IDocumentProperties::get_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_hyperlinkbase/) lit la base au niveau du document pour les hyperliens relatifs. Ceci est utile lors du déplacement d’une présentation et de ses fichiers liés vers un autre emplacement. Elle est distincte de la [IHyperlink::get_ExternalUrl](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurl/) d’un hyperlien individuel : modifier la base ne réécrit pas les adresses de lien stockées ni ne change les destinations absolues.

L’exemple nécessite une présentation contenant à la fois un lien relatif, tel que `target.html`, et un lien absolu, tel que `https://example.org/absolute.html`. Il lit la base existante, attribue une nouvelle adresse de base avec [IDocumentProperties::set_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_hyperlinkbase/), puis enregistre et rouvre la présentation pour vérifier la valeur. Il supprime ensuite la base avec `u""` et vérifie la valeur vide dans un fichier enregistré séparé. Remplacez l’adresse de base de l’exemple par l’emplacement de vos fichiers liés.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"hyperlinks.pptx");

System::Console::WriteLine(u"Original base: {0}", presentation->get_DocumentProperties()->get_HyperlinkBase());

const System::String newBase = u"https://example.com/new/";
presentation->get_DocumentProperties()->set_HyperlinkBase(newBase);
presentation->Save(u"hyperlinks-updated.pptx", SaveFormat::Pptx);

auto updatedPresentation = System::MakeObject<Presentation>(u"hyperlinks-updated.pptx");
System::Console::WriteLine(u"Base preserved: {0}", (updatedPresentation->get_DocumentProperties()->get_HyperlinkBase() == newBase));

updatedPresentation->get_DocumentProperties()->set_HyperlinkBase(u"");
updatedPresentation->Save(u"hyperlinks-cleared.pptx", SaveFormat::Pptx);

auto clearedPresentation = System::MakeObject<Presentation>(u"hyperlinks-cleared.pptx");
System::Console::WriteLine(u"Base cleared: {0}", (clearedPresentation->get_DocumentProperties()->get_HyperlinkBase() == u""));
```

Les deux messages de vérification doivent afficher `True`. La suppression de la base laisse les adresses des hyperliens individuels intactes.

Un lien relatif vers `target.pptx` ouvrait `old/target.pptx` lorsque la base pointait vers le dossier `old`. Après avoir changé la base vers le dossier `new`, enregistré et rouvert la présentation, le même lien ouvrait `new/target.pptx`. Un lien absolu a continué d’ouvrir le même fichier. Testez vos liens relatifs dans PowerPoint avant et après avoir déplacé la présentation ou modifié sa base.

## **Ajouter des propriétés personnalisées à la présentation**

Les propriétés personnalisées stockent des métadonnées qui n’ont pas de champ intégré correspondant. [IDocumentProperties::idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/) vous permet d’assigner une valeur par nom de propriété. Cet exemple crée une présentation, ajoute deux valeurs texte et une valeur de version entière, puis enregistre la présentation avec [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/). Affecter une valeur à un nom existant remplace la valeur de cette propriété.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto documentProperties = presentation->get_DocumentProperties();

documentProperties->idx_set(u"Reviewed by", System::ObjectExt::Box<System::String>(u"John Smith"));
documentProperties->idx_set(u"Confidentiality level", System::ObjectExt::Box<System::String>(u"Internal"));
documentProperties->idx_set(u"Document version", System::ObjectExt::Box(2));

presentation->Save(u"CustomDocumentProperties_output.pptx", SaveFormat::Pptx);
```

## **Accéder et modifier les propriétés personnalisées**

Cet exemple ouvre une présentation contenant des propriétés personnalisées et utilise [get_CountOfCustomProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_countofcustomproperties/) pour les parcourir. [GetCustomPropertyName](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/getcustompropertyname/) accepte un indice zéro‑based et renvoie le nom utilisé par [IDocumentProperties::idx_get](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_get/) et [idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/). L’exemple affiche chaque nom et valeur originaux, remplace chaque valeur par une chaîne numérotée quel que soit son type d’origine, puis enregistre les modifications. S’il n’existe aucune propriété personnalisée, la boucle ne fait aucun changement.

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"AccessAndModifyProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

for (auto i = 0; i < documentProperties->get_CountOfCustomProperties(); i++)
{
    auto propertyName = documentProperties->GetCustomPropertyName(i);
    auto propertyValue = documentProperties->idx_get(propertyName);

    System::Console::WriteLine(u"Custom property name: {0}", propertyName);
    System::Console::WriteLine(u"Custom property value: {0}", propertyValue);

    documentProperties->idx_set(propertyName, System::ObjectExt::Box(System::String::Format(u"New Value {0}", i + 1)));
}

presentation->Save(u"CustomProperties_output.pptx", SaveFormat::Pptx);
```

## **Exemple en direct**

Essayez l’application en ligne [**Voir et modifier les métadonnées PowerPoint**](https://products.aspose.app/slides/metadata) pour voir comment travailler avec les propriétés de document en utilisant l’API Aspose.Slides :

[![Voir et modifier les métadonnées PowerPoint](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Comment puis-je supprimer une propriété intégrée d’une présentation ?**

Les propriétés intégrées font partie intégrante de la présentation et ne peuvent pas être supprimées complètement. Cependant, vous pouvez soit modifier leurs valeurs, soit les mettre à vide si la propriété le permet.

**Que se passe-t-il si j’ajoute une propriété personnalisée qui existe déjà ?**

Si vous ajoutez une propriété personnalisée qui existe déjà, sa valeur existante sera écrasée par la nouvelle. Vous n’avez pas besoin de supprimer ou de vérifier la propriété au préalable, car Aspose.Slides met automatiquement à jour la valeur de la propriété.

**Puis-je accéder aux propriétés de la présentation sans charger entièrement la présentation ?**

Oui. Utilisez [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/presentationfactory/getpresentationinfo/) puis [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) pour lire les métadonnées du document stockées sans créer d’instance [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/). Consultez [Créer un inventaire léger de présentation](/slides/fr/cpp/examine-presentation/) pour un exemple complet de rapport et les limitations propres à chaque format.

**Puis-je lire les propriétés publiques d’une présentation chiffrée sans son mot de passe d’ouverture ?**

Oui. La présentation doit avoir été chiffrée en passant `false` à [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/), et elle doit être chargée en passant `true` à [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/).

**Puis-je mettre à jour un fichier PPTX chiffré en mode uniquement propriétés du document ?**

Non. Les données des propriétés publiques et chiffrées doivent rester cohérentes, donc la mise à jour d’un fichier PPTX chiffré nécessite de charger la présentation complète avec le mot de passe d’ouverture correct.