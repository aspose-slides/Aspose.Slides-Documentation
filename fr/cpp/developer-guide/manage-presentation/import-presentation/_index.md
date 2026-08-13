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
description: "Importez facilement des documents PDF et HTML dans des présentations PowerPoint et OpenDocument en C++ avec Aspose.Slides pour un traitement de diapositives fluide et haute performance."
---
## **Introduction**

En utilisant [**Aspose.Slides for C++**](https://products.aspose.com/slides/fr/cpp/), vous pouvez importer des présentations à partir de fichiers d’autres formats. Aspose.Slides fournit la classe [SlideCollection](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.slide_collection) qui vous permet d’importer des présentations depuis des PDF, des documents HTML, etc.

## **Importer PowerPoint à partir de PDF**

Dans ce cas, vous allez convertir un PDF en une présentation PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Instanciez un objet de la classe Presentation.  
2. Appelez la méthode [AddFromPdf()](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.slide_collection#a966c00d26b741a6c56e424d2f0d689a5) et transmettez le fichier PDF.  
3. Utilisez la méthode [Save()](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) pour enregistrer le fichier au format PowerPoint.

Ce code C++ montre l’opération de conversion PDF vers PowerPoint :

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
    
pres->get_Slides()->AddFromPdf(u"InputPDF.pdf");
pres->Save(u"OutputPresentation.pptx", SaveFormat::Pptx);
```

{{% alert  title="Tip" color="info" %}} 
Vous pouvez essayer l’application web **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/fr/import/pdf-to-powerpoint) car il s’agit d’une implémentation en direct du processus décrit ici. 
{{% /alert %}} 

## **Importer PowerPoint à partir de HTML**

Dans ce cas, vous allez convertir un document HTML en une présentation PowerPoint.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.presentation/).  
2. Appelez la méthode [AddFromHtml()](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.slide_collection#ad4337f6be235c230d5d422a6799ef965) et transmettez le fichier HTML.  
3. Utilisez la méthode [Save()](https://reference.aspose.com/slides/fr/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) pour enregistrer le fichier au format PowerPoint.

Ce code C++ montre l’opération de conversion HTML vers PowerPoint :

```c++
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>();

{
    auto htmlStream = System::IO::File::OpenRead(u"page.html");
    presentation->get_Slides()->AddFromHtml(htmlStream);
}

presentation->Save(u"MyPresentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 
Vous pouvez également utiliser Aspose.Slides pour convertir le HTML vers d’autres formats de fichiers populaires : 

* [HTML to image](https://products.aspose.com/slides/fr/cpp/conversion/html-to-image/)  
* [HTML to JPG](https://products.aspose.com/slides/fr/cpp/conversion/html-to-jpg/)  
* [HTML to XML](https://products.aspose.com/slides/fr/cpp/conversion/html-to-xml/)  
* [HTML to TIFF](https://products.aspose.com/slides/fr/cpp/conversion/html-to-tiff/)  

{{% /alert %}}

## **FAQ**

### Les tableaux sont‑ils préservés lors de l’importation d’un PDF, et la détection peut‑elle être améliorée ?

Les tableaux peuvent être détectés lors de l’importation ; [PdfImportOptions](https://reference.aspose.com/slides/fr/cpp/aspose.slides.import/pdfimportoptions/) comprend une méthode [set_DetectTables](https://reference.aspose.com/slides/fr/cpp/aspose.slides.import/pdfimportoptions/set_detecttables/) qui active la reconnaissance des tableaux. L’efficacité dépend de la structure du PDF.