---
title: Importer des présentations avec Python
linktitle: Importer une présentation
type: docs
weight: 60
url: /fr/python-net/import-presentation/
keywords:
- importer PowerPoint
- importer présentation
- importer diapositive
- PDF vers présentation
- PDF vers PPT
- PDF vers PPTX
- PDF vers ODP
- HTML vers présentation
- HTML vers PPT
- HTML vers PPTX
- HTML vers ODP
- Python
- Aspose.Slides
description: "Importez facilement des documents PDF et HTML dans des présentations PowerPoint et OpenDocument en Python avec Aspose.Slides pour un traitement de diapositives fluide et haute performance."
---

## **Vue d'ensemble**

Avec [**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/), vous pouvez importer du contenu dans une présentation à partir d’autres formats de fichier. La classe [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) fournit des méthodes pour importer des diapositives depuis PDF, HTML et d’autres sources.

## **Convertir un PDF en présentation**

Cette section montre comment convertir un PDF en présentation à l’aide d’Aspose.Slides. Elle vous guide dans l’import du PDF, la transformation de ses pages en diapositives, puis l’enregistrement du résultat au format PPTX.

<img src="pdf-to-powerpoint.png" alt="pdf-vers-powerpoint" style="zoom:50%;" />

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Appelez la méthode [add_from_pdf](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_from_pdf/) en lui passant le fichier PDF.
3. Utilisez la méthode [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) pour enregistrer la présentation au format PowerPoint.

L’exemple Python suivant montre comment convertir un PDF en présentation :

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("sample.pdf")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Astuce" color="primary" %}}
Vous pouvez essayer l’application web gratuite d’Aspose : [PDF vers PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint), qui constitue une implémentation en ligne du processus décrit ici.
{{% /alert %}}

## **Convertir un HTML en présentation**

Cette section explique comment importer du contenu HTML dans une présentation à l’aide d’Aspose.Slides. Elle couvre le chargement du fichier HTML, sa transformation en diapositives avec texte, images et mise en forme de base préservés, puis l’enregistrement du résultat au format PPTX.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Appelez la méthode [add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_from_html/) en lui passant le fichier HTML. 
3. Utilisez la méthode [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) pour enregistrer la présentation au format PowerPoint.

L’exemple Python suivant montre comment convertir un HTML en présentation :

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    with open("page.html", "rb") as html_stream:
        presentation.slides.add_from_html(html_stream)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Les tables sont‑elles conservées lors de l’import d’un PDF, et la détection peut‑elle être améliorée ?**

Les tables peuvent être détectées pendant l’import ; [PdfImportOptions](https://reference.aspose.com/slides/python-net/aspose.slides.importing/pdfimportoptions/) comporte un paramètre [detect_tables](https://reference.aspose.com/slides/python-net/aspose.slides.importing/pdfimportoptions/detect_tables/) qui active la reconnaissance des tables. L’efficacité dépend de la structure du PDF.

{{% alert title="Remarque" color="info" %}}
Vous pouvez également utiliser Aspose.Slides pour convertir du HTML vers d’autres formats de fichier populaires :

* [HTML vers image](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML vers JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML vers XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML vers TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)
{{% /alert %}}