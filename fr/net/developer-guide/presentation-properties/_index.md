---
title: Propriétés de Présentation - Accéder ou Modifier les Propriétés de Présentation PowerPoint en C#
linktitle: Propriétés de Présentation
type: docs
weight: 70
url: /fr/net/presentation-properties/
keywords: "comment supprimer le dernier modifié par dans powerpoint, propriétés de PowerPoint, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Propriétés de présentation PowerPoint en C# ou .NET"
---


## **Exemple en Direct**
Essayez [**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata) l'application en ligne pour voir comment travailler avec les propriétés de document via l'API Aspose.Slides :

[](https://products.aspose.app/slides/metadata)

[![todo:image_alt_text](slides-metadata.png)](https://products.aspose.app/slides/metadata)


## **À Propos des Propriétés de Présentation**
Comme nous l'avons décrit précédemment, Aspose.Slides pour .NET prend en charge deux types de propriétés de document, qui sont les propriétés **Intégrées** et **Personnalisées**. Ainsi, les développeurs peuvent accéder aux deux types de propriétés en utilisant l'API Aspose.Slides pour .NET. Aspose.Slides pour .NET fournit une classe [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties) qui représente les propriétés de document associées à un fichier de présentation via la propriété [Presentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/documentproperties/properties/index). Les développeurs peuvent utiliser la propriété [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties) exposée par l'objet **Presentation** pour accéder aux propriétés de document des fichiers de présentation comme décrit ci-dessous :



{{% alert color="primary" %}} 

Veuillez noter que vous ne pouvez pas définir de valeurs pour les champs **Application** et **Producer**, car Aspose Ltd. et Aspose.Slides pour .NET x.x.x seront affichés pour ces champs.

{{% /alert %}} 


## **Gérer les Propriétés de Présentation**
Microsoft PowerPoint fournit une fonctionnalité pour ajouter certaines propriétés aux fichiers de présentation. Ces propriétés de document permettent de stocker des informations utiles avec les documents (fichiers de présentation). Il existe deux types de propriétés de document comme suit :

- Propriétés Défines par le Système (Intégrées)
- Propriétés Définies par l'Utilisateur (Personnalisées)

Les propriétés **Intégrées** contiennent des informations générales sur le document telles que le titre du document, le nom de l'auteur, les statistiques du document, etc. Les propriétés **Personnalisées** sont celles qui sont définies par les utilisateurs sous forme de paires **Nom/Valeur**, où le nom et la valeur sont tous deux définis par l'utilisateur. En utilisant Aspose.Slides pour .NET, les développeurs peuvent accéder et modifier les valeurs des propriétés intégrées ainsi que des propriétés personnalisées. Microsoft PowerPoint 2007 permet de gérer les propriétés de document des fichiers de présentation. Tout ce que vous avez à faire est de cliquer sur l'icône Office, puis sur l'item de menu **Préparer | Propriétés | Propriétés Avancées** de Microsoft PowerPoint 2007. Après avoir sélectionné l'item de menu **Propriétés Avancées**, une boîte de dialogue apparaîtra vous permettant de gérer les propriétés de document du fichier PowerPoint. Dans la **Boîte de Dialogue des Propriétés**, vous pouvez voir qu'il y a plusieurs onglets comme **Général, Résumé, Statistiques, Contenu et Personnalisé**. Tous ces onglets permettent de configurer différents types d'informations liées aux fichiers PowerPoint. L'onglet **Personnalisé** est utilisé pour gérer les propriétés personnalisées des fichiers PowerPoint.
## **Accéder aux Propriétés Intégrées**
Ces propriétés, exposées par l'objet **IDocumentProperties**, incluent : **Creator(Author)**, **Description**, **Keywords** **Created** (Date de Création), **Modified** Date de Modification, **Printed** Date du Dernier Impression, **LastModifiedBy**, **Keywords**, **SharedDoc** (Est partagé entre différents producteurs ?), **PresentationFormat**, **Subject** et **Title**

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-AccessBuiltinProperties-AccessBuiltinProperties.cs" >}}
## **Modifier les Propriétés Intégrées**
Modifier les propriétés intégrées des fichiers de présentation est aussi simple que d'y accéder. Vous pouvez simplement attribuer une valeur de chaîne à n'importe quelle propriété souhaitée et la valeur de la propriété serait modifiée. Dans l'exemple ci-dessous, nous avons démontré comment nous pouvons modifier les propriétés de document intégrées du fichier de présentation.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-ModifyBuiltinProperties-ModifyBuiltinProperties.cs" >}}

## **Ajouter des Propriétés de Présentation Personnalisées**
Aspose.Slides pour .NET permet également aux développeurs d'ajouter des valeurs personnalisées pour les propriétés de document de présentation. Un exemple est donné ci-dessous qui montre comment définir les propriétés personnalisées pour une présentation.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-AddCustomDocumentProperties-AddCustomDocumentProperties.cs" >}}

## **Accéder et Modifier les Propriétés Personnalisées**
Aspose.Slides pour .NET permet également aux développeurs d'accéder aux valeurs des propriétés personnalisées. Un exemple est donné ci-dessous qui montre comment accéder et modifier toutes ces propriétés personnalisées pour une présentation.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-AccessModifyingProperties-AccessModifyingProperties.cs" >}}

## **Vérifier si la Présentation est Modifiée ou Créée**
Aspose.Slides pour .NET fournit une fonctionnalité pour vérifier si une présentation est modifiée ou créée. Un exemple est donné ci-dessous qui montre comment vérifier si la présentation est créée ou modifiée.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Presentations-Properties-CheckPresentationCreatedorModifed-CheckPresentationCreatedorModifed.cs" >}}

Définir la Langue par Défaut

## **Définir la Langue de Vérification**

Aspose.Slides fournit la propriété [LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/) (exposée par la classe [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/)) pour vous permettre de définir la langue de vérification pour un document PowerPoint. La langue de vérification est la langue pour laquelle l'orthographe et la grammaire dans PowerPoint sont vérifiées.

Ce code C# vous montre comment définir la langue de vérification pour un PowerPoint :

```c#
using (Presentation pres = new Presentation(pptxFileName))
{
    AutoShape autoShape = (AutoShape)pres.Slides[0].Shapes[0];

    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];
    paragraph.Portions.Clear();

    Portion newPortion = new Portion();

    IFontData font = new FontData("SimSun");
    IPortionFormat portionFormat = newPortion.PortionFormat;
    portionFormat.ComplexScriptFont = font;
    portionFormat.EastAsianFont = font;
    portionFormat.LatinFont = font;

    portionFormat.LanguageId = "zh-CN"; // définir l'Id d'une langue de vérification
    
    newPortion.Text = "1。";
    paragraph.Portions.Add(newPortion);
}
```

## **Définir la Langue par Défaut**

Ce code C# vous montre comment définir la langue par défaut pour une présentation PowerPoint entière : 

```c#
LoadOptions loadOptions = new LoadOptions();
loadOptions.DefaultTextLanguage = "en-US";
using (Presentation pres = new Presentation(loadOptions))
{
    // Ajoute une nouvelle forme rectangle avec du texte
    IAutoShape shp = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.TextFrame.Text = "Nouveau Texte";
    
    // Vérifie la langue de la première portion
    Console.WriteLine(shp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId);
}
```