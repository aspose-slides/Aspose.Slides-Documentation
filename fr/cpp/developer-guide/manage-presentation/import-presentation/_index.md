---
title: Importer des présentations depuis PDF ou HTML en C++
linktitle: Importer une présentation
type: docs
weight: 60
url: /fr/cpp/import-presentation/
keywords:
- importation de présentation
- importation de diapositive
- importation PDF
- importation HTML
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
- C++
- Aspose.Slides
description: "Importez facilement des documents PDF et HTML dans des présentations PowerPoint et OpenDocument en C++ avec Aspose.Slides pour un traitement de diapositive fluide et haute performance."
---

En utilisant **Aspose.Slides for C++**, vous pouvez importer des présentations à partir de fichiers dans d’autres formats. Aspose.Slides fournit la classe [SlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection) pour permettre d’importer des présentations depuis PDF, documents HTML, etc.

## **Importer PowerPoint depuis PDF**

Dans ce cas, vous convertissez un PDF en présentation PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Instanciez un objet de la classe Presentation.  
2. Appelez la méthode [AddFromPdf()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#a966c00d26b741a6c56e424d2f0d689a5) et transmettez le fichier PDF.  
3. Utilisez la méthode [Save()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) pour enregistrer le fichier au format PowerPoint.

Ce code C++ démontre l’opération de conversion PDF vers PowerPoint :
```cpp
auto pres = System::MakeObject<Presentation>();
    
pres->get_Slides()->AddFromPdf(u"InputPDF.pdf");
pres->Save(u"OutputPresentation.pptx", SaveFormat::Pptx);
```


{{% alert  title="Tip" color="primary" %}} 

Vous voudrez peut‑être consulter l’application Web **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) car il s’agit d’une implémentation en direct du processus décrit ici. 

{{% /alert %}} 

## **Importer PowerPoint depuis HTML**

Dans ce cas, vous convertissez un document HTML en présentation PowerPoint.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/).  
2. Appelez la méthode [AddFromHtml()](https://reference.aspose.com/slides/cpp/class/aspose.slides.slide_collection#ad4337f6be235c230d5d422a6799ef965) et transmettez le fichier HTML.  
3. Utilisez la méthode [Save()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) pour enregistrer le fichier au format PowerPoint.

Ce code C++ démontre l’opération de conversion HTML vers PowerPoint :
```c++
auto presentation = System::MakeObject<Presentation>();

{
    auto htmlStream = System::IO::File::OpenRead(u"page.html");
    presentation->get_Slides()->AddFromHtml(htmlStream);
}

presentation->Save(u"MyPresentation.pptx", SaveFormat::Pptx);
```


{{% alert title="Note" color="warning" %}} 

Vous pouvez également utiliser Aspose.Slides pour convertir HTML vers d’autres formats de fichiers populaires :

* [HTML vers image](https://products.aspose.com/slides/cpp/conversion/html-to-image/)
* [HTML vers JPG](https://products.aspose.com/slides/cpp/conversion/html-to-jpg/)
* [HTML vers XML](https://products.aspose.com/slides/cpp/conversion/html-to-xml/)
* [HTML vers TIFF](https://products.aspose.com/slides/cpp/conversion/html-to-tiff/)

{{% /alert %}}

## **FAQ**

**Les tableaux sont-ils conservés lors de l’importation d’un PDF, et leur détection peut-elle être améliorée ?**

Les tableaux peuvent être détectés lors de l’importation ; [PdfImportOptions](https://reference.aspose.com/slides/cpp/aspose.slides.import/pdfimportoptions/) comprend une méthode [set_DetectTables](https://reference.aspose.com/slides/cpp/aspose.slides.import/pdfimportoptions/set_detecttables/) qui active la reconnaissance des tableaux. L’efficacité dépend de la structure du PDF.