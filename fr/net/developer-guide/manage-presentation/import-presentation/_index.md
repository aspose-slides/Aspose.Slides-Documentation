---
title: Importer PowerPoint depuis PDF ou HTML
linktitle: Importer la présentation
type: docs
weight: 60
url: /net/import-presentation/
keywords: "Importer PowerPoint, PDF vers PowerPoint, HTML vers PowerPoint, PDF vers PPT, HTML vers PPT, C#, Csharp, Aspose.Slides pour .NET"
description: "Importer PowerPoint depuis PDF ou HTML. Convertir PDF en PowerPoint. Convertir HTML en PowerPoint"
---

En utilisant [**Aspose.Slides pour .NET**](https://products.aspose.com/slides/net/), vous pouvez importer des présentations à partir de fichiers dans d'autres formats. Aspose.Slides fournit la classe [SlideCollection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) pour vous permettre d'importer des présentations à partir de documents PDF.

## **Importer PowerPoint depuis PDF**

Dans ce cas, vous allez convertir un PDF en présentation PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). 
2. Appelez la méthode [AddFromPdf](https://reference.aspose.com/slides/net/aspose.slides.slidecollection/addfrompdf/methods/1) et passez le fichier PDF. 
3. Utilisez la méthode [Save](https://reference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5) pour sauvegarder le fichier dans le format PowerPoint.

Ce code C# démontre l'opération de conversion de PDF en PowerPoint :

```c#
using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert  title="ASTUCE" color="primary" %}} 

Vous voudrez peut-être consulter l'application web **Aspose gratuite** [PDF vers PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) car il s'agit d'une mise en œuvre en direct du processus décrit ici. 

{{% /alert %}} 

## **Importer PowerPoint depuis HTML**

Dans ce cas, vous allez convertir un document HTML en présentation PowerPoint.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/). 
2. Appelez la méthode [AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) et passez le fichier HTML. 
3. Utilisez la méthode [Save](https://apireference.aspose.com/slides/net/aspose.slides.presentation/save/methods/5) pour sauvegarder le fichier en tant que document PowerPoint.

Ce code C# démontre l'opération de conversion de HTML en PowerPoint : 

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

{{% alert title="Note" color="warning" %}} 

Vous pouvez également utiliser Aspose.Slides pour convertir HTML en d'autres formats de fichiers populaires : 

* [HTML vers image](https://products.aspose.com/slides/net/conversion/html-to-image/)
* [HTML vers JPG](https://products.aspose.com/slides/net/conversion/html-to-jpg/)
* [HTML vers XML](https://products.aspose.com/slides/net/conversion/html-to-xml/)
* [HTML vers TIFF](https://products.aspose.com/slides/net/conversion/html-to-tiff/)

{{% /alert %}}