---
title: Propriétés de Présentation
type: docs
weight: 70
url: /cpp/presentation-properties/
---

## **Accéder aux Propriétés de Présentation**
Comme nous l'avons décrit précédemment, Aspose.Slides pour C++ prend en charge deux types de propriétés de document, qui sont les propriétés **Intégrées** et **Personnalisées**. Ainsi, les développeurs peuvent accéder à ces deux types de propriétés en utilisant l'API Aspose.Slides pour C++. Aspose.Slides pour C++ fournit une classe [IDocumentProperties](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_document_properties) qui représente les propriétés de document associées à un fichier de présentation via la méthode [Presentation::get_DocumentProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a40a03eb17a9904ff80063f6df714c402). Les développeurs peuvent utiliser la méthode [get_DocumentProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a40a03eb17a9904ff80063f6df714c402) exposée par l'objet **Presentation** pour accéder aux propriétés de document des fichiers de présentation, comme décrit ci-dessous :

{{% alert color="primary" %}} 

Veuillez noter que vous ne pouvez pas définir de valeurs pour les champs **Application** et **Producer**, car Aspose Ltd. et Aspose.Slides pour C++ x.x.x seront affichés dans ces champs.

{{% /alert %}} 

Microsoft PowerPoint offre une fonctionnalité permettant d'ajouter des propriétés aux fichiers de présentation. Ces propriétés de document permettent de stocker des informations utiles avec les documents (fichiers de présentation). Il existe deux types de propriétés de document comme suit :

- Propriétés Définies par le Système (Intégrées)
- Propriétés Définies par l'Utilisateur (Personnalisées)

Les propriétés **Intégrées** contiennent des informations générales sur le document telles que le titre du document, le nom de l'auteur, les statistiques du document, etc. Les propriétés **Personnalisées** sont celles qui sont définies par les utilisateurs sous forme de paires **Nom/Valeur**, où le nom et la valeur sont tous deux définis par l'utilisateur. En utilisant Aspose.Slides pour C++, les développeurs peuvent accéder et modifier les valeurs des propriétés intégrées ainsi que des propriétés personnalisées. Microsoft PowerPoint 2007 permet de gérer les propriétés de document des fichiers de présentation. Tout ce que vous avez à faire est de cliquer sur l'icône Office et sur le menu **Préparer | Propriétés | Propriétés Avancées** de Microsoft PowerPoint 2007. Après avoir sélectionné l'élément de menu **Propriétés Avancées**, une boîte de dialogue apparaîtra vous permettant de gérer les propriétés de document du fichier PowerPoint. Dans la **Boîte de Dialogue des Propriétés**, vous pouvez voir qu'il existe de nombreux onglets tels que **Général, Résumé, Statistiques, Contenu et Personnalisé**. Tous ces onglets permettent de configurer différents types d'informations liées aux fichiers PowerPoint. L'onglet **Personnalisé** est utilisé pour gérer les propriétés personnalisées des fichiers PowerPoint.

## **Accéder aux Propriétés Intégrées**
Ces propriétés, telles qu'exposées par l'objet **IDocumentProperties**, incluent : **Créateur (Auteur)**, **Description**, **Mots-clés**, **Créé** (Date de Création), **Modifié** (Date de Modification), **Imprimé** (Date de Dernière Impression), **Dernier Modifié Par**, **Mots-clés**, **DocPartagé** (Est-il partagé entre différents producteurs ?), **Format de Présentation**, **Objet** et **Titre**.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}
## **Modifier les Propriétés Intégrées**
Modifier les propriétés intégrées des fichiers de présentation est aussi simple que d'y accéder. Vous pouvez simplement assigner une valeur de chaîne à n'importe quelle propriété souhaitée et la valeur de la propriété serait modifiée. Dans l'exemple ci-dessous, nous avons démontré comment nous pouvons modifier les propriétés de document intégrées du fichier de présentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **Ajouter des Propriétés de Présentation Personnalisées**
Aspose.Slides pour C++ permet également aux développeurs d'ajouter des valeurs personnalisées pour les propriétés de document de présentation. Un exemple est donné ci-dessous qui montre comment définir les propriétés personnalisées pour une présentation.

```cpp
// Instancier la classe Presentation
auto presentation = System::MakeObject<Presentation>();

// Obtenir les Propriétés du Document
auto documentProperties = presentation->get_DocumentProperties();

// Ajouter des propriétés personnalisées
documentProperties->idx_set(u"Nouvelle Personnalisée", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"Mon Nom", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Personnalisée", ObjectExt::Box<int32_t>(124));

// Obtenir le nom de la propriété à un index particulier
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// Supprimer la propriété sélectionnée
documentProperties->RemoveCustomProperty(getPropertyName);

// Enregistrer la présentation
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **Accéder et Modifier les Propriétés de Présentation Personnalisées**
Aspose.Slides pour C++ permet également aux développeurs d'accéder aux valeurs des propriétés personnalisées. Un exemple est donné ci-dessous qui montre comment accéder et modifier toutes ces propriétés personnalisées pour une présentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **Vérifier si la Présentation a été Modifiée ou Créée**
Aspose.Slides pour C++ fournit une fonctionnalité pour vérifier si une présentation a été modifiée ou créée. Un exemple est donné ci-dessous qui montre comment vérifier si la présentation est créée ou modifiée.

```cpp
auto info = PresentationFactory::get_Instance()->GetPresentationInfo(u"props.pptx");

auto props = info->ReadDocumentProperties();

String app = props->get_NameOfApplication();
String ver = props->get_AppVersion();
```

## **Définir la Langue de Correction**

Aspose.Slides fournit la propriété [LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_languageid/) (exposée par la classe [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/)) pour vous permettre de définir la langue de correction pour un document PowerPoint. La langue de correction est la langue pour laquelle les orthographes et la grammaire dans PowerPoint sont vérifiées.

Ce code C++ montre comment définir la langue de correction pour un PowerPoint :

```cpp
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
// définir l'ID d'une langue de correction

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **Définir la Langue par Défaut**

Ce code C++ montre comment définir la langue par défaut pour une présentation PowerPoint entière :

```cpp
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// Ajouter une nouvelle forme rectangle avec du texte
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"Nouveau Texte");

// Vérifier la langue de la première portion
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```