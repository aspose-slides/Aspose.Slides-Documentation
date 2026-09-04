---
title: Gérer les propriétés de présentation en C++
linktitle: Propriétés de la présentation
type: docs
weight: 70
url: /fr/cpp/presentation-properties/
keywords:
- Propriétés PowerPoint
- Propriétés de présentation
- Propriétés de document
- Propriétés intégrées
- Propriétés personnalisées
- Propriétés avancées
- Gérer les propriétés
- Modifier les propriétés
- Métadonnées de document
- Modifier les métadonnées
- Langue de vérification
- Langue par défaut
- PowerPoint
- OpenDocument
- Présentation
- C++
- Aspose.Slides
description: "Maîtrisez les propriétés de présentation dans Aspose.Slides for C++ et simplifiez la recherche, le branding et le flux de travail dans vos fichiers PowerPoint et OpenDocument."
---
## **Introduction**

Aspose.Slides prend en charge deux types de propriétés de document : **Intégrées** et **Personnalisées**. Ces deux types de propriétés peuvent être facilement accessibles et gérées à l’aide de l’API Aspose.Slides.

Aspose.Slides vous permet de travailler avec les propriétés de document de présentation via l’interface [IDocumentProperties](https://reference.aspose.com/slides/fr/cpp/aspose.slides/idocumentproperties/). Une instance de cette interface est renvoyée par [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentation/get_documentproperties/). Les exemples suivants montrent comment lire, modifier et gérer ces propriétés.

{{% alert color="info" title="Remarque" %}}

Veuillez noter que vous ne pouvez pas définir de valeurs pour les champs **Application** et **Producer**, car Aspose Ltd. et Aspose.Slides for C++ x.x.x seront affichés dans ces champs.

{{% /alert %}} 

## **Gérer les propriétés de la présentation**

Microsoft PowerPoint propose une fonctionnalité permettant d’ajouter certaines propriétés aux fichiers de présentation. Ces propriétés de document permettent de stocker des informations utiles avec les documents (fichiers de présentation). Il existe deux sortes de propriétés de document comme suit :

- Propriétés définies par le système (Intégrées)
- Propriétés définies par l’utilisateur (Personnalisées)

Les propriétés **Intégrées** contiennent des informations générales sur le document telles que le titre, le nom de l’auteur, les statistiques du document, etc. Les propriétés **Personnalisées** sont celles définies par les utilisateurs sous forme de paires **Nom/Valeur**, où le nom et la valeur sont définis par l’utilisateur. À l’aide d’Aspose.Slides for C++, les développeurs peuvent accéder et modifier les valeurs des propriétés intégrées ainsi que des propriétés personnalisées. Microsoft PowerPoint 2007 permet de gérer les propriétés de document des fichiers de présentation. Il suffit de cliquer sur l’icône Office puis sur le menu **Préparer | Propriétés | Propriétés avancées** de Microsoft PowerPoint 2007. Après avoir sélectionné **Propriétés avancées**, une boîte de dialogue apparaît, vous permettant de gérer les propriétés de document du fichier PowerPoint. Dans la **Boîte de dialogue Propriétés**, vous pouvez voir de nombreux onglets tels que **Général, Résumé, Statistiques, Contenu et Personnalisé**. Tous ces onglets permettent de configurer différents types d’informations liées aux fichiers PowerPoint. L’onglet **Personnalisé** est utilisé pour gérer les propriétés personnalisées des fichiers PowerPoint.

## **Lire les propriétés publiques d’une présentation cryptée**

Un mot de passe d’ouverture protège généralement à la fois le contenu de la présentation et les propriétés du document. Lorsqu’une présentation est cryptée en passant `false` à [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/), ses propriétés de document restent publiques. Une application peut alors passer `true` à [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/fr/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) et lire les métadonnées publiques sans fournir le mot de passe d’ouverture.

`set_OnlyLoadDocumentProperties` contrôle ce qu’Aspose.Slides charge ; il ne déchiffre rien. Si les propriétés ont été incluses dans le chiffrement, les charger sans le mot de passe échoue. Si la présentation n’est pas cryptée, l’option est ignorée et la présentation complète est chargée.

L’exemple suivant vérifie le mode de chargement via [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/fr/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) puis lit les propriétés intégrées via [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentation/get_documentproperties/) :

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = MakeObject<Presentation>(u"public-properties-encrypted.pptx", loadOptions);

if (presentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    auto properties = presentation->get_DocumentProperties();

    Console::WriteLine(u"Author: " + properties->get_Author());
    Console::WriteLine(u"Title: " + properties->get_Title());
    Console::WriteLine(u"Keywords: " + properties->get_Keywords());
}
else
{
    Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}

presentation->Dispose();
```

Dans ce mode, le contenu des diapositives n’est pas chargé. Les diapositives, maîtres, dispositions, formes, médias et autres objets de présentation ne sont pas disponibles. Les applications doivent toujours vérifier `get_IsOnlyDocumentPropertiesLoaded` avant d’effectuer une opération nécessitant le modèle d’objet complet de la présentation.

{{% alert color="warning" title="Avertissement" %}}
Les métadonnées publiques peuvent exposer les noms d’auteur, les titres, les sujets, les mots‑clé, les informations d’entreprise, les commentaires et les valeurs personnalisées. Cryptez les propriétés sensibles avec la présentation. Ne les laissez publiques que lorsque l’indexation, la classification, la recherche ou les systèmes de gestion de documents ont une exigence spécifique d’accès sans mot de passe.
{{% /alert %}}

## **Mettre à jour les propriétés d’une présentation cryptée**

Pour un fichier PPTX crypté, une présentation chargée après l’appel de `set_OnlyLoadDocumentProperties(true)` est destinée à la lecture des métadonnées publiques. Aspose.Slides ne peut pas enregistrer les propriétés modifiées de cet objet « seulement‑métadonnées » parce que les propriétés publiques doivent rester cohérentes avec les données correspondantes à l’intérieur de la présentation cryptée. Leur mise à jour nécessite donc le mot de passe d’ouverture correct et un chargement complet.

L’exemple suivant ouvre la présentation avec [LoadOptions::set_Password](https://reference.aspose.com/slides/fr/cpp/aspose.slides/loadoptions/set_password/), met à jour les propriétés intégrées publiques, puis enregistre le résultat. Il utilise ensuite [IPresentationInfo::get_IsEncrypted](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentationinfo/get_isencrypted/) pour vérifier que le chiffrement est conservé et rouvre les métadonnées publiques sans mot de passe afin de vérifier les nouvelles valeurs :

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

const String inputPath = u"public-properties-encrypted.pptx";
const String outputPath = u"updated-public-properties-encrypted.pptx";

{
    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(u"open_password");

    auto presentation = MakeObject<Presentation>(inputPath, loadOptions);
    presentation->get_DocumentProperties()->set_Title(u"Updated Product Roadmap");
    presentation->get_DocumentProperties()->set_Keywords(u"roadmap, planning, indexed");
    presentation->Save(outputPath, SaveFormat::Pptx);
    presentation->Dispose();
}

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(outputPath);
Console::WriteLine(presentationInfo->get_IsEncrypted() ? u"The presentation is encrypted." : u"The presentation is not encrypted.");

auto metadataLoadOptions = MakeObject<LoadOptions>();
metadataLoadOptions->set_OnlyLoadDocumentProperties(true);

auto metadataPresentation = MakeObject<Presentation>(outputPath, metadataLoadOptions);

if (metadataPresentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    Console::WriteLine(u"Title: " + metadataPresentation->get_DocumentProperties()->get_Title());
    Console::WriteLine(u"Keywords: " + metadataPresentation->get_DocumentProperties()->get_Keywords());
}
else
{
    Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}

metadataPresentation->Dispose();
```

Si une application n’est pas autorisée à déchiffrer ou à charger le contenu de la présentation, elle doit considérer les propriétés publiques d’un fichier PPTX crypté comme en lecture‑seule.

## **Accéder aux propriétés intégrées**

Ces propriétés exposées par l’objet **IDocumentProperties** comprennent : **Creator(Author)**, **Description**, **KeyWords**, **Created** (date de création), **Modified** (date de modification), **Printed** (date du dernier impression), **LastModifiedBy**, **Keywords**, **SharedDoc** (est‑il partagé entre différents producteurs ?), **PresentationFormat**, **Subject** et **Title**

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Modifier les propriétés intégrées**

Modifier les propriétés intégrées des fichiers de présentation est aussi simple que de les accéder. Il suffit d’assigner une chaîne de caractères à la propriété souhaitée et la valeur de la propriété sera modifiée. Dans l’exemple ci‑dessous, nous montrons comment modifier les propriétés de document intégrées du fichier de présentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Ajouter des propriétés personnalisées à la présentation**

Aspose.Slides for C++ permet également aux développeurs d’ajouter des valeurs personnalisées aux propriétés de document de la présentation. Un exemple est présenté ci‑dessous, montrant comment définir les propriétés personnalisées pour une présentation.

``` cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Instancier la classe Presentation
auto presentation = System::MakeObject<Presentation>();

// Obtention des propriétés du document
auto documentProperties = presentation->get_DocumentProperties();

// Ajout de propriétés personnalisées
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// Récupération du nom de la propriété à un indice particulier
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// Suppression de la propriété sélectionnée
documentProperties->RemoveCustomProperty(getPropertyName);

// Enregistrement de la présentation
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **Accéder et modifier les propriétés personnalisées**

Aspose.Slides for C++ permet également aux développeurs d’accéder aux valeurs des propriétés personnalisées. Un exemple est présenté ci‑dessous, montrant comment accéder et modifier toutes ces propriétés personnalisées pour une présentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Définir la langue de vérification**

Aspose.Slides fournit la propriété [LanguageId](https://reference.aspose.com/slides/fr/cpp/aspose.slides/baseportionformat/set_languageid/) (exposée par la classe [PortionFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/portionformat/)) pour vous permettre de définir la langue de vérification d’une présentation PowerPoint. La langue de vérification est la langue selon laquelle l’orthographe et la grammaire du PowerPoint sont contrôlées.

Ce code C++ montre comment définir la langue de vérification d’un PowerPoint :

```c++
#include <DOM/AutoShape.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IFontData.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"sample.pptx");
System::SharedPtr<AutoShape> autoShape = System::ExplicitCast<AutoShape>(pres->get_Slide(0)->get_Shape(0));

System::SharedPtr<IParagraph> paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
System::SharedPtr<IPortionCollection> portions = paragraph->get_Portions();
portions->Clear();

System::SharedPtr<Portion> newPortion = System::MakeObject<Portion>();

System::SharedPtr<IFontData> font = System::MakeObject<FontData>(u"SimSun");
System::SharedPtr<IPortionFormat> portionFormat = newPortion->get_PortionFormat();
portionFormat->set_ComplexScriptFont(font);
portionFormat->set_EastAsianFont(font);
portionFormat->set_LatinFont(font);

portionFormat->set_LanguageId(u"zh-CN");
// définir l'Id d'une langue de verification

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **Définir la langue par défaut**

Ce code C++ montre comment définir la langue par défaut pour l’ensemble d’une présentation PowerPoint :

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
using namespace Aspose::Slides;

System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Ajoute une nouvelle forme rectangulaire avec du texte
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// Vérifie la langue de la première portion
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **Exemple en direct**

Essayez l’application en ligne [**Aspose.Slides Metadata**](https://products.aspose.app/slides/fr/metadata) pour voir comment travailler avec les propriétés de document via l’API Aspose.Slides :

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/fr/metadata)

## **FAQ**

**Comment puis‑je supprimer une propriété intégrée d’une présentation ?**

Les propriétés intégrées font partie intégrante de la présentation et ne peuvent pas être supprimées complètement. Vous pouvez toutefois modifier leurs valeurs ou les laisser vides si la propriété le permet.

**Que se passe‑t‑il si j’ajoute une propriété personnalisée qui existe déjà ?**

Si vous ajoutez une propriété personnalisée déjà existante, sa valeur actuelle sera écrasée par la nouvelle. Vous n’avez pas besoin de supprimer ou de vérifier la propriété au préalable, Aspose.Slides met automatiquement à jour la valeur de la propriété.

**Puis‑je accéder aux propriétés de la présentation sans charger entièrement la présentation ?**

Oui. Utilisez [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) puis [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) pour lire les métadonnées stockées du document sans créer d’instance [Presentation](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/). Voir [Build a Lightweight Presentation Inventory](/slides/fr/cpp/examine-presentation/) pour un exemple complet de rapport et les limitations spécifiques aux formats.

**Puis‑je lire les propriétés publiques d’une présentation cryptée sans son mot de passe d’ouverture ?**

Oui. La présentation doit avoir été cryptée en passant `false` à `set_EncryptDocumentProperties`, et elle doit être chargée en passant `true` à `set_OnlyLoadDocumentProperties`.

**Puis‑je mettre à jour un fichier PPTX crypté en mode « propriétés‑document‑seulement » ?**

Non. Les données publiques et cryptées des propriétés doivent rester cohérentes, de sorte que la mise à jour d’un fichier PPTX crypté nécessite le chargement complet de la présentation avec le mot de passe d’ouverture correct.