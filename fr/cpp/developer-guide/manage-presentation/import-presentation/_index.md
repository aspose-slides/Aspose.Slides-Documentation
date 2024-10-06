---
title: Importer une présentation - API PowerPoint C++
linktitle: Importer une présentation
type: docs
weight: 60
url: /cpp/import-presentation/
keywords: "Importer PowerPoint, PDF vers Présentation, PDF vers PPTX, PDF vers PPT, C++, Aspose.Slides pour C++"
description: "Importer une présentation PowerPoint à partir d'un PDF. Convertir PDF en PowerPoint"
---

En utilisant [**Aspose.Slides pour C++**](https://products.aspose.com/slides/cpp/), vous pouvez importer des présentations à partir de fichiers dans d'autres formats. Aspose.Slides fournit la classe [SlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection) pour vous permettre d'importer des présentations à partir de PDF, de documents HTML, etc.

## **Importer PowerPoint à partir de PDF**

Dans ce cas, vous allez convertir un PDF en présentation PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Instancier un objet de la classe présentation. 
2. Appeler la méthode [AddFromPdf()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a966c00d26b741a6c56e424d2f0d689a5) et passer le fichier PDF. 
3. Utiliser la méthode [Save()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) pour enregistrer le fichier au format PowerPoint.

Ce code C++ démontre l'opération de conversion de PDF en PowerPoint :

```cpp
auto pres = System::MakeObject<Presentation>();
    
pres->get_Slides()->AddFromPdf(u"InputPDF.pdf");
pres->Save(u"OutputPresentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Astuce" color="primary" %}} 

Vous voudrez peut-être consulter l'application web **Aspose gratuite** [PDF vers PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) car c'est une mise en œuvre en direct du processus décrit ici. 

{{% /alert %}} 

## **Importer PowerPoint à partir de HTML**

Dans ce cas, vous allez convertir un document HTML en présentation PowerPoint.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/). 
2. Appeler la méthode [AddFromHtml()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#ad4337f6be235c230d5d422a6799ef965) et passer le fichier HTML. 
3. Utiliser la méthode [Save()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) pour enregistrer le fichier au format PowerPoint.

Ce code C++ démontre l'opération de conversion de HTML en PowerPoint :

```c++
auto presentation = System::MakeObject<Presentation>();

{
    auto htmlStream = System::IO::File::OpenRead(u"page.html");
    presentation->get_Slides()->AddFromHtml(htmlStream);
}

presentation->Save(u"MyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Remarque" color="warning" %}} 

Vous pouvez également utiliser Aspose.Slides pour convertir HTML en d'autres formats de fichiers populaires : 

* [HTML vers image](https://products.aspose.com/slides/cpp/conversion/html-to-image/)
* [HTML vers JPG](https://products.aspose.com/slides/cpp/conversion/html-to-jpg/)
* [HTML vers XML](https://products.aspose.com/slides/cpp/conversion/html-to-xml/)
* [HTML vers TIFF](https://products.aspose.com/slides/cpp/conversion/html-to-tiff/)

{{% /alert %}}