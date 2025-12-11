---
title: Gérer les propriétés de la présentation en C++
linktitle: Propriétés de la présentation
type: docs
weight: 70
url: /fr/cpp/presentation-properties/
keywords:
- Propriétés PowerPoint
- Propriétés de la présentation
- Propriétés du document
- Propriétés intégrées
- Propriétés personnalisées
- Propriétés avancées
- Gérer les propriétés
- Modifier les propriétés
- Métadonnées du document
- Modifier les métadonnées
- Langue de relecture
- Langue par défaut
- PowerPoint
- OpenDocument
- Présentation
- C++
- Aspose.Slides
description: "Maîtrisez les propriétés de présentation dans Aspose.Slides pour C++ et rationalisez la recherche, le branding et le flux de travail dans vos fichiers PowerPoint et OpenDocument."
---

## **Accéder aux propriétés de la présentation**

Comme nous l'avons indiqué précédemment, Aspose.Slides pour C++ prend en charge deux types de propriétés de document, à savoir les propriétés **Intégrées** et **Personnalisées**. Ainsi, les développeurs peuvent accéder aux deux types de propriétés à l'aide de l'API Aspose.Slides pour C++. Aspose.Slides pour C++ fournit une classe [IDocumentProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_document_properties) qui représente les propriétés du document associées à un fichier de présentation via la méthode [Presentation::get_DocumentProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a40a03eb17a9904ff80063f6df714c402). Les développeurs peuvent utiliser la méthode [get_DocumentProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a40a03eb17a9904ff80063f6df714c402) exposée par l'objet **Presentation** pour accéder aux propriétés du document des fichiers de présentation comme décrit ci‑dessous :

{{% alert color="primary" %}} 
Veuillez noter que vous ne pouvez pas définir de valeurs pour les champs **Application** et **Producer**, car Aspose Ltd. et Aspose.Slides pour C++ x.x.x seront affichés dans ces champs.
{{% /alert %}} 

Microsoft PowerPoint propose une fonctionnalité permettant d'ajouter certaines propriétés aux fichiers de présentation. Ces propriétés de document permettent de stocker des informations utiles avec les documents (fichiers de présentation). Il existe deux types de propriétés de document comme suit :

- Propriétés définies par le système (Intégrées)
- Propriétés définies par l'utilisateur (Personnalisées)

Les propriétés **Intégrées** contiennent des informations générales sur le document telles que le titre, le nom de l'auteur, les statistiques du document, etc. Les propriétés **Personnalisées** sont définies par les utilisateurs sous forme de paires **Nom/Valeur**, où le nom et la valeur sont définis par l'utilisateur. Avec Aspose.Slides pour C++, les développeurs peuvent accéder et modifier les valeurs des propriétés intégrées ainsi que des propriétés personnalisées. Microsoft PowerPoint 2007 permet de gérer les propriétés de document des fichiers de présentation. Il suffit de cliquer sur l’icône Office puis sur le menu **Préparer | Propriétés | Propriétés avancées** de Microsoft PowerPoint 2007. Après avoir sélectionné **Propriétés avancées**, une boîte de dialogue apparaît, vous permettant de gérer les propriétés du fichier PowerPoint. Dans la **Boîte de dialogue Propriétés**, vous constaterez plusieurs onglets tels que **Général, Résumé, Statistiques, Contenu et Personnalisé**. Tous ces onglets permettent de configurer différents types d’informations liées aux fichiers PowerPoint. L’onglet **Personnalisé** sert à gérer les propriétés personnalisées des fichiers PowerPoint.

## **Accéder aux propriétés intégrées**

Ces propriétés exposées par l’objet **IDocumentProperties** comprennent : **Creator(Author)**, **Description**, **KeyWords**, **Created** (Date de création), **Modified** (Date de modification), **Printed** (Date du dernier impression), **LastModifiedBy**, **Keywords**, **SharedDoc** (Est partagé entre différents producteurs ?), **PresentationFormat**, **Subject** et **Title**.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **Modifier les propriétés intégrées**

Modifier les propriétés intégrées des fichiers de présentation est aussi simple que d’y accéder. Il suffit d’attribuer une chaîne de caractères à la propriété souhaitée et la valeur sera modifiée. Dans l’exemple ci‑dessous, nous montrons comment modifier les propriétés intégrées du document de présentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Ajouter des propriétés de présentation personnalisées**

Aspose.Slides pour C++ permet également aux développeurs d’ajouter des valeurs personnalisées aux propriétés du document de la présentation. L’exemple ci‑dessous montre comment définir des propriétés personnalisées pour une présentation.
``` cpp
// Instancier la classe Presentation
auto presentation = System::MakeObject<Presentation>();

// Récupération des propriétés du document
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

Aspose.Slides pour C++ permet également aux développeurs d’accéder aux valeurs des propriétés personnalisées. L’exemple ci‑dessous montre comment accéder et modifier toutes ces propriétés personnalisées pour une présentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Définir la langue de relecture**

Aspose.Slides fournit la propriété [LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides.baseportionformat/set_languageid/) (exposée par la classe [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/)) afin de définir la langue de relecture pour un document PowerPoint. La langue de relecture est la langue dans laquelle l’orthographe et la grammaire du PowerPoint sont vérifiées.

Ce code C++ montre comment définir la langue de relecture pour un PowerPoint :
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(pptxFileName);
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
// set the Id of a proofing language

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```


## **Définir la langue par défaut**

Ce code C++ montre comment définir la langue par défaut pour l’ensemble d’une présentation PowerPoint :
```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Adds a new rectangle shape with text
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// Checks the first portion language
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```


## **Exemple en direct**

Essayez l’application en ligne [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata) pour voir comment travailler avec les propriétés de document via l’API Aspose.Slides :

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## ***FAQ**

**Comment puis‑je supprimer une propriété intégrée d’une présentation ?**

Les propriétés intégrées font partie intégrante de la présentation et ne peuvent pas être supprimées complètement. Vous pouvez toutefois modifier leurs valeurs ou les vider si la propriété le permet.

**Que se passe‑t‑il si j’ajoute une propriété personnalisée qui existe déjà ?**

Si vous ajoutez une propriété personnalisée déjà existante, sa valeur actuelle sera écrasée par la nouvelle. Il n’est pas nécessaire de la supprimer ou de vérifier son existence au préalable, car Aspose.Slides met à jour automatiquement la valeur de la propriété.

**Puis‑je accéder aux propriétés de la présentation sans charger complètement la présentation ?**

Oui, vous pouvez accéder aux propriétés d’une présentation sans la charger intégralement en utilisant la méthode `GetPresentationInfo` de la classe [PresentationFactory](https://reference.aspose.com/slides/cpp/aspose.slides/presentationfactory/). Puis, utilisez la méthode `ReadDocumentProperties` fournie par l’interface [IPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/) pour lire les propriétés de manière efficace, ce qui économise de la mémoire et améliore les performances.