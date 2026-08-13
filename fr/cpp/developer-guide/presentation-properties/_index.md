---
title: Gestion des propriétés de présentation en C++
linktitle: Propriétés de présentation
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
- Langue de relecture
- Langue par défaut
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Maîtrisez les propriétés de présentation dans Aspose.Slides for C++ et simplifiez la recherche, l'image de marque et le flux de travail dans vos fichiers PowerPoint et OpenDocument."
---
## **Introduction**

Aspose.Slides prend en charge deux types de propriétés de document : **Built-in** et **Custom**. Les deux types de propriétés peuvent être facilement accessibles et gérées à l’aide de l’API Aspose.Slides.

Aspose.Slides vous permet de travailler avec les propriétés de document de présentation via l’interface [IDocumentProperties](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.i_document_properties). Une instance de cette interface est retournée par la méthode [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentation/get_documentproperties/). Les exemples suivants montrent comment lire, modifier et gérer ces propriétés.

{{% alert color="info" %}} 
Veuillez noter que vous ne pouvez pas définir de valeurs pour les champs **Application** et **Producer**, car Aspose Ltd. et Aspose.Slides for C++ x.x.x seront affichés dans ces champs.
{{% /alert %}} 

## **Manage Presentation Properties**

Microsoft PowerPoint offre une fonction permettant d’ajouter des propriétés aux fichiers de présentation. Ces propriétés de document permettent de stocker des informations utiles avec les documents (fichiers de présentation). Il existe deux types de propriétés de document comme suit

- Propriétés définies par le système (Built-in)
- Propriétés définies par l’utilisateur (Custom)

**Built-in** les propriétés contiennent des informations générales sur le document telles que le titre du document, le nom de l’auteur, les statistiques du document, etc. **Custom** les propriétés sont celles définies par les utilisateurs sous forme de paires **Nom/Valeur**, où le nom et la valeur sont définis par l’utilisateur. En utilisant Aspose.Slides for C++, les développeurs peuvent accéder et modifier les valeurs des propriétés built-in ainsi que des propriétés custom. Microsoft PowerPoint 2007 permet de gérer les propriétés de document des fichiers de présentation. Tout ce que vous avez à faire est de cliquer sur l’icône Office puis sur le menu **Prepare | Properties | Advanced Properties** de Microsoft PowerPoint 2007. Après avoir sélectionné l’option **Advanced Properties**, une boîte de dialogue apparaît vous permettant de gérer les propriétés du fichier PowerPoint. Dans la **Properties Dialog**, vous voyez de nombreux onglets tels que **General, Summary, Statistics, Contents and Custom**. Tous ces onglets permettent de configurer différents types d’informations liées aux fichiers PowerPoint. L’onglet **Custom** est utilisé pour gérer les propriétés personnalisées des fichiers PowerPoint.

## **Access Built-in Properties**

Ces propriétés exposées par l’objet **IDocumentProperties** comprennent : **Creator(Author)**, **Description**, **KeyWords**, **Created** (date de création), **Modified** (date de modification), **Printed** (date du dernier impression), **LastModifiedBy**, **Keywords**, **SharedDoc** (est partagé entre différents producteurs ?), **PresentationFormat**, **Subject** et **Title**

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Modify Built-in Properties**

Modifier les propriétés built-in des fichiers de présentation est aussi simple que de les accéder. Vous pouvez simplement assigner une chaîne de caractères à n’importe quelle propriété souhaitée et la valeur de la propriété sera modifiée. Dans l’exemple ci‑dessous, nous démontrons comment modifier les propriétés de document built‑in du fichier de présentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Add Custom Presentation Properties**

Aspose.Slides for C++ permet également aux développeurs d’ajouter les valeurs personnalisées pour les propriétés de document de la présentation. Un exemple est fourni ci‑dessous montrant comment définir les propriétés custom pour une présentation.

```cpp
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

// Obtention du nom de la propriété à un index particulier
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// Suppression de la propriété sélectionnée
documentProperties->RemoveCustomProperty(getPropertyName);

// Enregistrement de la présentation
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **Access and Modify Custom Properties**

Aspose.Slides for C++ permet également aux développeurs d’accéder aux valeurs des propriétés custom. Un exemple est fourni ci‑dessous montrant comment accéder et modifier toutes ces propriétés custom pour une présentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Set Proofing Language**

Aspose.Slides fournit la propriété [LanguageId](https://reference.aspose.com/slides/fr/cpp/aspose.slides/baseportionformat/set_languageid/) (exposée par la classe [PortionFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/portionformat/)) afin de vous permettre de définir la langue de vérification orthographique pour un document PowerPoint. La langue de vérification est la langue pour laquelle l’orthographe et la grammaire du PowerPoint sont contrôlées.

Ce code C++ vous montre comment définir la langue de vérification pour un PowerPoint :

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
// définir l'ID d'une langue de relecture

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **Set Default Language**

Ce code C++ vous montre comment définir la langue par défaut pour l’ensemble d’une présentation PowerPoint :

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

## **Live Example**

Essayez l’application en ligne [**Aspose.Slides Metadata**](https://products.aspose.app/slides/fr/metadata) pour voir comment travailler avec les propriétés de document via l’API Aspose.Slides :

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/fr/metadata)

## ***FAQ**

### How can I remove a built-in property from a presentation?

Les propriétés built‑in font partie intégrante de la présentation et ne peuvent pas être supprimées entièrement. Cependant, vous pouvez modifier leurs valeurs ou les définir comme vides si la propriété le permet.

### What happens if I add a custom property that already exists?

Si vous ajoutez une propriété custom qui existe déjà, sa valeur existante sera écrasée par la nouvelle. Vous n’avez pas besoin de supprimer ou de vérifier la propriété au préalable, car Aspose.Slides met automatiquement à jour la valeur de la propriété.

### Can I access presentation properties without fully loading the presentation?

Oui, vous pouvez accéder aux propriétés de la présentation sans la charger entièrement en utilisant la méthode `GetPresentationInfo` de la classe [PresentationFactory](https://reference.aspose.com/slides/fr/cpp/aspose.slides/presentationfactory/). Ensuite, utilisez la méthode `ReadDocumentProperties` fournie par l’interface [IPresentationInfo](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipresentationinfo/) pour lire les propriétés de manière efficace, en économisant de la mémoire et en améliorant les performances.