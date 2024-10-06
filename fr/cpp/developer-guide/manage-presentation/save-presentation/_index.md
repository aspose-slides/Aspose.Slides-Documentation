---
title: Enregistrer la présentation - Bibliothèque C++ PowerPoint
linktitle: Enregistrer la présentation
type: docs
weight: 80
url: /cpp/save-presentation/
description: L'API ou bibliothèque C++ PowerPoint vous permet d'enregistrer une présentation dans un fichier ou un flux. Vous pouvez créer une présentation à partir de zéro ou modifier une existante.
---

{{% alert title="Info" color="info" %}}

Pour apprendre comment ouvrir ou charger des présentations, consultez l'article [*Ouvrir une présentation*](https://docs.aspose.com/slides/cpp/open-presentation/).

{{% /alert %}}

L'article ici explique comment enregistrer des présentations.

La [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) classe contient le contenu d'une présentation. Que vous créiez une présentation à partir de zéro ou que vous modifiiez une existante, une fois terminé, vous souhaitez enregistrer la présentation. Avec Aspose.Slides pour C++, elle peut être enregistrée en tant que **fichier** ou **flux**. Cet article explique comment enregistrer une présentation de différentes manières :

## **Enregistrer la présentation dans un fichier**
Enregistrez une présentation dans des fichiers en appelant la **Presentation** classe [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) méthode. Il vous suffit de passer le nom du fichier et le format d'enregistrement à la [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) méthode. Les exemples qui suivent montrent comment enregistrer une présentation avec Aspose.Slides pour C++.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SaveToFile-SaveToFile.cpp" >}}
## **Enregistrer la présentation dans un flux**
Il est possible d'enregistrer une présentation dans un flux en passant un flux de sortie à la [Presentation]() classe Save méthode. Il existe de nombreux types de flux dans lesquels une présentation peut être enregistrée. Dans l'exemple ci-dessous, nous avons créé un nouveau fichier de Présentation, ajouté du texte dans une forme et enregistré la présentation dans le flux.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SaveToStream-SaveToStream.cpp" >}}

## **Enregistrer la présentation avec un type de vue prédéfini**
Aspose.Slides pour C++ fournit une fonctionnalité pour définir le type de vue pour la présentation générée lorsqu'elle est ouverte dans PowerPoint via la [ViewProperties](http://www.aspose.com/api/net/slides/aspose.slides/viewproperties) classe. La [LastView](http://www.aspose.com/api/net/slides/aspose.slides/viewproperties/properties/index) propriété est utilisée pour définir le type de vue en utilisant l'énumérateur [ViewType](http://www.aspose.com/api/net/slides/aspose.slides/viewtype).

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SaveAsPredefinedViewType-SaveAsPredefinedViewType.cpp" >}}

## **Enregistrer la présentation au format Strict Office Open XML**
Aspose.Slides vous permet d'enregistrer la présentation au format Strict Office Open XML. À cette fin, il fournit la **PptxOptions** classe où vous pouvez définir la propriété de Conformité lors de l'enregistrement du fichier de présentation. Si vous définissez sa valeur comme **Conformance.Iso29500_2008_Strict**, alors le fichier de présentation de sortie sera enregistré au format Strict Office Open XML.

Le code d'exemple suivant crée une présentation et l'enregistre au format Strict Office Open XML. Lors de l'appel de la méthode Save pour la présentation, l'objet **PptxOptions** est passé avec la propriété de Conformité définie comme **Conformance.Iso29500_2008_Strict**.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SaveToStrictOpenXML-SaveToStrictOpenXML.cpp" >}}

## **Enregistrer les mises à jour de progression en pourcentage**
 Une nouvelle interface **IProgressCallback** a été ajoutée à l'interface **ISaveOptions** et à la classe abstraite **SaveOptions**. L'interface **IProgressCallback** représente un objet de rappel pour l'enregistrement des mises à jour de progression en pourcentage.  

Les extraits de code ci-dessous montrent comment utiliser l'interface IProgressCallback :

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CovertToPDFWithProgressUpdate-CovertToPDFWithProgressUpdate.cpp" >}}

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CovertToPDFWithProgressUpdate-ExportProgressHandler.cpp" >}}

{{% alert title="Info" color="info" %}}

En utilisant sa propre API, Aspose a développé une [application gratuite PowerPoint Splitter](https://products.aspose.app/slides/splitter) qui permet aux utilisateurs de diviser leurs présentations en plusieurs fichiers. Essentiellement, l'application enregistre les diapositives sélectionnées d'une présentation donnée en tant que nouveaux fichiers PowerPoint (PPTX ou PPT).

{{% /alert %}}