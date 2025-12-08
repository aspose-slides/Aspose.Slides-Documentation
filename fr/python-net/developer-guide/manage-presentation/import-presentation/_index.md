---
title: "Importer des présentations avec Python"
linktitle: "Importer une présentation"
type: docs
weight: 60
url: /fr/python-net/import-presentation/
keywords:
  - "importer PowerPoint"
  - "importer une présentation"
  - "importer une diapositive"
  - "PDF en présentation"
  - "PDF en PPT"
  - "PDF en PPTX"
  - "PDF en ODP"
  - "HTML en présentation"
  - "HTML en PPT"
  - "HTML en PPTX"
  - "HTML en ODP"
  - "Python"
  - "Aspose.Slides"
description: "Importez facilement des documents PDF et HTML dans des présentations PowerPoint et OpenDocument en Python avec Aspose.Slides pour un traitement des diapositives fluide et haute performance."
---

## **Vue d'ensemble**

Avec [**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/), vous pouvez importer du contenu dans une présentation à partir d'autres formats de fichier. La classe [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) fournit des méthodes pour importer des diapositives depuis PDF, HTML et d'autres sources.

## **Convertir un PDF en présentation**

Cette section montre comment convertir un PDF en présentation à l'aide d'Aspose.Slides. Elle vous guide à travers l'importation du PDF, la conversion de ses pages en diapositives, et l'enregistrement du résultat au format PPTX.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Appelez la méthode [add_from_pdf](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_from_pdf/) et transmettez le fichier PDF.
3. Utilisez la méthode [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) pour enregistrer la présentation au format PowerPoint.

L'exemple Python suivant montre la conversion d'un PDF en présentation :
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("sample.pdf")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert  title="Tip" color="primary" %}}
Vous pouvez essayer l'application web **gratuit d'Aspose** [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) — c’est une implémentation en direct du processus décrit ici.
{{% /alert %}}

## **Convertir un HTML en présentation**

Cette section montre comment importer du contenu HTML dans une présentation à l'aide d'Aspose.Slides. Elle explique le chargement du HTML, sa transformation en diapositives avec le texte, les images et la mise en forme de base conservés, et l'enregistrement du résultat au format PPTX.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Appelez la méthode [add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_from_html/) et transmettez le fichier HTML.
3. Utilisez la méthode [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) pour enregistrer la présentation au format PowerPoint.

L'exemple Python suivant montre la conversion d'un HTML en présentation :
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    with open("page.html", "rb") as html_stream:
        presentation.slides.add_from_html(html_stream)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Les tables sont-elles conservées lors de l'importation d'un PDF, et leur détection peut-elle être améliorée ?**

Les tables peuvent être détectées lors de l'importation ; [PdfImportOptions](https://reference.aspose.com/slides/python-net/aspose.slides.importing/pdfimportoptions/) comprend un paramètre [detect_tables](https://reference.aspose.com/slides/python-net/aspose.slides.importing/pdfimportoptions/detect_tables/) qui active la reconnaissance des tables. L'efficacité dépend de la structure du PDF.

{{% alert title="Note" color="info" %}}
Vous pouvez également utiliser Aspose.Slides pour convertir le HTML en d'autres formats de fichiers populaires :
* [HTML vers image](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML vers JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML vers XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML vers TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)
{{% /alert %}}