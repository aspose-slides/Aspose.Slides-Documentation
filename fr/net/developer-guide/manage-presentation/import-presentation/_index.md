---
title: "Importer PowerPoint depuis PDF ou HTML"
linktitle: "Importer une présentation"
type: docs
weight: 60
url: /fr/net/import-presentation/
keywords: "Importation PowerPoint, PDF vers PowerPoint, HTML vers PowerPoint, PDF vers PPT, HTML vers PPT, C#, Csharp, Aspose.Slides for .NET"
description: "Importer PowerPoint depuis PDF ou HTML. Convertir PDF en PowerPoint. Convertir HTML en PowerPoint"
---

En utilisant [**Aspose.Slides for .NET**](https://products.aspose.com/slides/net/), vous pouvez importer des présentations à partir de fichiers dans d'autres formats. Aspose.Slides fournit la classe [SlideCollection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) pour vous permettre d'importer des présentations à partir de documents PDF.

## **Importer PowerPoint à partir de PDF**

Dans ce cas, vous pouvez convertir un PDF en présentation PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .  
2. Appelez la méthode [AddFromPdf](https://reference.aspose.com/slides/net/aspose.slides.slidecollection/addfrompdf/methods/1) et passez le fichier PDF.  
3. Utilisez la méthode [Save](https://reference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5) pour enregistrer le fichier au format PowerPoint.

Ce code C# illustre l'opération de conversion PDF vers PowerPoint :
```c#
using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```


{{% alert  title="TIP" color="primary" %}} 
Vous voudrez peut‑être consulter l'application Web **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) car il s'agit d'une implémentation en direct du processus décrit ici. 
{{% /alert %}} 

## **Importer PowerPoint à partir de HTML**

Dans ce cas, vous pouvez convertir un document HTML en présentation PowerPoint.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .  
2. Appelez la méthode [AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) et passez le fichier HTML.  
3. Utilisez la méthode [Save](https://apireference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5) pour enregistrer le fichier au format PowerPoint.

Ce code C# illustre l'opération de conversion HTML vers PowerPoint : 
```c#
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

**Les tableaux sont-ils conservés lors de l'importation d'un PDF, et la détection peut‑elle être améliorée ?**

Les tableaux peuvent être détectés lors de l'importation ; [PdfImportOptions](https://reference.aspose.com/slides/net/aspose.slides.import/pdfimportoptions/) inclut un paramètre [DetectTables](https://reference.aspose.com/slides/net/aspose.slides.import/pdfimportoptions/detecttables/) qui active la reconnaissance des tableaux. L'efficacité dépend de la structure du PDF.

{{% alert title="Note" color="warning" %}} 
Vous pouvez également utiliser Aspose.Slides pour convertir du HTML vers d'autres formats de fichiers populaires : 

* [HTML vers image](https://products.aspose.com/slides/net/conversion/html-to-image/)
* [HTML vers JPG](https://products.aspose.com/slides/net/conversion/html-to-jpg/)
* [HTML vers XML](https://products.aspose.com/slides/net/conversion/html-to-xml/)
* [HTML vers TIFF](https://products.aspose.com/slides/net/conversion/html-to-tiff/)

{{% /alert %}}