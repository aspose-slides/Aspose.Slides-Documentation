---
title: Importer des présentations avec Python
linktitle: Importer une présentation
type: docs
weight: 60
url: /fr/python-net/developer-guide/manage-presentation/import-presentation/
keywords:
- import PowerPoint
- import presentation
- import slide
- PDF to presentation
- PDF to PPT
- PDF to PPTX
- PDF to ODP
- HTML to presentation
- HTML to PPT
- HTML to PPTX
- HTML to ODP
- Python
- Aspose.Slides
description: "Importez facilement des documents PDF et HTML dans des présentations PowerPoint et OpenDocument en Python avec Aspose.Slides pour un traitement des diapositives fluide et haute performance."
---

## **Vue d'ensemble**

Avec [**Aspose.Slides for Python via .NET**](https://products.aspose.com/slides/python-net/), vous pouvez importer du contenu dans une présentation à partir d’autres formats de fichiers. La classe [SlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) propose des méthodes pour importer des diapositives depuis PDF, HTML et d’autres sources.

## **Convertir un PDF en présentation**

Cette section montre comment convertir un PDF en présentation à l’aide d’Aspose.Slides. Elle vous guide à travers l’importation du PDF, la transformation de ses pages en diapositives, puis l’enregistrement du résultat sous forme de fichier PPTX.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Appelez la méthode [add_from_pdf](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_from_pdf/) en passant le fichier PDF.
3. Utilisez la méthode [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) pour enregistrer la présentation au format PowerPoint.

L’exemple Python suivant montre la conversion d’un PDF en présentation :

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("sample.pdf")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert  title="Astuce" color="primary" %}}

Vous pouvez essayer l’application web gratuite d’Aspose **PDF vers PowerPoint** [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) — c’est une implémentation en ligne du processus décrit ici.

{{% /alert %}}

## **Convertir un HTML en présentation**

Cette section montre comment importer du contenu HTML dans une présentation à l’aide d’Aspose.Slides. Elle couvre le chargement du HTML, sa transformation en diapositives en conservant le texte, les images et le formatage de base, puis l’enregistrement du résultat sous forme de fichier PPTX.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Appelez la méthode [add_from_html](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/add_from_html/) en passant le fichier HTML. 
3. Utilisez la méthode [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) pour enregistrer la présentation au format PowerPoint.

L’exemple Python suivant montre la conversion d’un HTML en présentation :

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    with open("page.html", "rb") as html_stream:
        presentation.slides.add_from_html(html_stream)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Les tableaux sont‑ils conservés lors de l’importation d’un PDF, et la détection peut‑elle être améliorée ?**

Les tableaux peuvent être détectés pendant l’importation ; [PdfImportOptions](https://reference.aspose.com/slides/python-net/aspose.slides.importing/pdfimportoptions/) propose un paramètre [detect_tables](https://reference.aspose.com/slides/python-net/aspose.slides.importing/pdfimportoptions/detect_tables/) qui active la reconnaissance des tableaux. L’efficacité dépend de la structure du PDF.

{{% alert title="Remarque" color="info" %}}

Vous pouvez également utiliser Aspose.Slides pour convertir le HTML vers d’autres formats populaires :

* [HTML vers image](https://products.aspose.com/slides/python-net/conversion/html-to-image/)
* [HTML vers JPG](https://products.aspose.com/slides/python-net/conversion/html-to-jpg/)
* [HTML vers XML](https://products.aspose.com/slides/python-net/conversion/html-to-xml/)
* [HTML vers TIFF](https://products.aspose.com/slides/python-net/conversion/html-to-tiff/)

{{% /alert %}}