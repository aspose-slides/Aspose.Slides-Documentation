---
title: Importer des présentations depuis PDF ou HTML en .NET
linktitle: Importer une présentation
type: docs
weight: 60
url: /fr/net/import-presentation/
keywords:
- importer une présentation
- importer une diapositive
- importer PDF
- importer HTML
- PDF vers présentation
- PDF vers PPT
- PDF vers PPTX
- PDF vers ODP
- HTML vers présentation
- HTML vers PPT
- HTML vers PPTX
- HTML vers ODP
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Importez facilement des documents PDF et HTML dans des présentations PowerPoint et OpenDocument en .NET avec Aspose.Slides pour un traitement des diapositives fluide et haute performance."
---
## **Introduction**

En utilisant Aspose.Slides, vous pouvez importer des présentations à partir de fichiers dans d'autres formats. Aspose.Slides fournit la classe [SlideCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/slidecollection/) qui vous permet d'importer des présentations à partir de documents PDF et HTML.

## **Importer PowerPoint à partir de PDF**

Dans ce cas, vous pouvez convertir un PDF en présentation PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/). 
2. Appelez la méthode [AddFromPdf](https://reference.aspose.com/slides/fr/net/aspose.slides.slidecollection/addfrompdf/methods/1) et passez le fichier PDF. 
3. Utilisez la méthode [Save](https://reference.aspose.com/slides/fr/net/aspose.slides.presentation/save/methods/5) pour enregistrer le fichier au format PowerPoint.

Ce code C# illustre l'opération de conversion de PDF en PowerPoint :

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert  title="TIP" color="info" %}} 
Vous pouvez consulter l'application web **Aspose free** [PDF vers PowerPoint](https://products.aspose.app/slides/fr/import/pdf-to-powerpoint) car il s'agit d'une implémentation en direct du processus décrit ici. 
{{% /alert %}} 

## **Importer PowerPoint à partir de HTML**

Dans ce cas, vous pouvez convertir un document HTML en présentation PowerPoint.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/). 
2. Appelez la méthode [AddFromHtml](https://reference.aspose.com/slides/fr/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) et passez le fichier HTML. 
3. Utilisez la méthode [Save](https://apireference.aspose.com/slides/fr/net/aspose.slides.presentation/save/methods/5) pour enregistrer le fichier au format PowerPoint.

Ce code C# illustre l'opération de conversion HTML en PowerPoint : 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation())
{
    using (var htmlStream = File.OpenRead("page.html"))
    {
        presentation.Slides.AddFromHtml(htmlStream);
    }

    presentation.Save("MyPresentation.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

### Les tables sont-elles conservées lors de l'importation d'un PDF, et leur détection peut-elle être améliorée ?

Les tables peuvent être détectées lors de l'importation ; [PdfImportOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.import/pdfimportoptions/) inclut un paramètre [DetectTables](https://reference.aspose.com/slides/fr/net/aspose.slides.import/pdfimportoptions/detecttables/) qui active la reconnaissance des tables. L'efficacité dépend de la structure du PDF.

{{% alert title="Note" color="warning" %}} 
Vous pouvez également utiliser Aspose.Slides pour convertir HTML vers d'autres formats de fichiers courants :

* [HTML vers image](https://products.aspose.com/slides/fr/net/conversion/html-to-image/)
* [HTML vers JPG](https://products.aspose.com/slides/fr/net/conversion/html-to-jpg/)
* [HTML vers XML](https://products.aspose.com/slides/fr/net/conversion/html-to-xml/)
* [HTML vers TIFF](https://products.aspose.com/slides/fr/net/conversion/html-to-tiff/)

{{% /alert %}}