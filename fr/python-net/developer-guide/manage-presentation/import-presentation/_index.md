---
title: Importer une Présentation
type: docs
weight: 60
url: /python-net/import-presentation/
keywords: "Importer PowerPoint, PDF en Présentation, PDF en PPTX, PDF en PPT, Python, Aspose.Slides pour Python via .NET"
description: "Importer une présentation PowerPoint à partir d'un PDF. Convertir PDF en PowerPoint"
---

En utilisant [**Aspose.Slides pour Python via .NET**](https://products.aspose.com/slides/python-net/), vous pouvez importer des présentations à partir de fichiers dans d'autres formats. Aspose.Slides fournit la classe [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) pour vous permettre d'importer des présentations à partir de PDF, de documents HTML, etc. 

## **Importer PowerPoint à partir de PDF**

Dans ce cas, vous pouvez convertir un PDF en présentation PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Instanciez un objet de la classe de présentation. 
2. Appelez la méthode `add_from_pdf` et passez le fichier PDF. 
3. Utilisez la méthode `save` pour enregistrer le fichier au format PowerPoint.

Ce code Python démontre l'opération de conversion de PDF en PowerPoint :

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    pres.slides.remove_at(0)
    pres.slides.add_from_pdf("welcome-to-powerpoint.pdf")
    pres.save("OutputPresentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Conseil" color="primary" %}} 

Vous voudrez peut-être essayer l'application web gratuite **Aspose** [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) car il s'agit d'une mise en œuvre en direct du processus décrit ici. 

{{% /alert %}} 

## **Importer PowerPoint à partir de HTML**

Dans ce cas, vous pouvez convertir un document HTML en présentation PowerPoint.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). 
2. Appelez la méthode `add_from_html` et passez le fichier HTML. 
3. Utilisez la méthode `save` pour enregistrer le fichier en tant que document PowerPoint.

Ce code Python démontre l'opération de conversion de HTML en PowerPoint : 

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    with open("page.html", "rb") as htmlStream:
        pres.slides.add_from_html(htmlStream)

    pres.save("MyPresentation.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Note" color="warning" %}} 

Vous pouvez également utiliser Aspose.Slides pour convertir HTML en d'autres formats de fichiers populaires : 

* [HTML en image](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML en JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML en XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML en TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}