---
title: Importer des présentations depuis PDF ou HTML en Python via Java
linktitle: Importer une présentation
type: docs
weight: 60
url: /fr/python-java/import-presentation/
keywords:
- importer présentation
- importer diapositive
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
- Python
- Java
- Aspose.Slides
description: "Apprenez à importer du contenu PDF et HTML dans des présentations PowerPoint en Python via Java avec Aspose.Slides et à enregistrer les résultats au format PPTX."
---
## **Introduction**

Aspose.Slides pour Python via Java peut transformer des pages PDF ou du contenu HTML en diapositives PowerPoint sans Microsoft PowerPoint. La classe [SlideCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/) fournit [addFromPdf](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#addFromPdf) et [addFromHtml](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#addFromHtml) pour ajouter le contenu importé à une présentation.

Pour un contrôle plus fin du placement du HTML, [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#insertFromHtml) peut insérer les diapositives générées à un index de la collection ou commencer à remplir l’espace disponible sur une diapositive existante. Le HTML long est paginé automatiquement sur des diapositives supplémentaires, la source peut être fournie sous forme de chaîne ou de flux, et les ressources externes peuvent être chargées via [ExternalResourceResolver](https://reference.aspose.com/slides/fr/python-java/aspose.slides/externalresourceresolver/) avec une URI de base. Le tableau de [Slide](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/) renvoyé identifie les diapositives affectées et celles nouvellement créées.

## **Importation depuis PDF**

Pour convertir un document PDF en présentation PowerPoint, importez son contenu dans la collection de diapositives et enregistrez le résultat sous forme de fichier PPTX.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Créez un nouvel objet [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Appelez [addFromPdf](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#addFromPdf) avec le chemin du fichier PDF.
3. Appelez [save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save) avec [SaveFormat.Pptx](https://reference.aspose.com/slides/fr/python-java/aspose.slides/saveformat/#Pptx) pour écrire la présentation dans un fichier PPTX.

L’exemple Python suivant importe un document PDF et enregistre les diapositives générées en tant que présentation PowerPoint :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlides().addFromPdf("document.pdf")
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La diapositive vierge par défaut reste dans la présentation car l’importation ajoute des diapositives. Pour ne conserver que les pages importées, videz la collection de diapositives avec [SlideCollection.clear](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#clear) avant l’importation.

La méthode [addFromPdf](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#addFromPdf) renvoie les diapositives qu’elle ajoute, ce qui est utile lorsque vous devez traiter uniquement les diapositives importées.

{{% alert title="Astuce" color="success" %}}
Essayez l’application Web gratuite [PDF to PowerPoint](https://products.aspose.app/slides/fr/import/pdf-to-powerpoint) pour voir ce flux de conversion en action.
{{% /alert %}}

## **Importation depuis HTML**

Aspose.Slides peut également créer des diapositives à partir d’un document HTML. La source peut être fournie sous forme de texte HTML ou de flux. Les étapes suivantes utilisent un flux de fichier :

1. Créez un nouvel objet [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Ouvrez le fichier HTML en lecture et transmettez le flux à [addFromHtml](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#addFromHtml).
3. Appelez [save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save) avec [SaveFormat.Pptx](https://reference.aspose.com/slides/fr/python-java/aspose.slides/saveformat/#Pptx) pour écrire le résultat dans un fichier PPTX.

L’exemple Python suivant importe un document HTML et enregistre les diapositives générées en tant que présentation PowerPoint :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.io import FileInputStream

presentation = Presentation()
try:
    html_stream = FileInputStream("page.html")
    try:
        presentation.getSlides().addFromHtml(html_stream)
    finally:
        html_stream.close()
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Insertion de contenu HTML**

Utilisez [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#insertFromHtml) lorsque les diapositives générées à partir du HTML doivent être placées à une position précise au lieu d’être ajoutées à la fin. L’index est zéro‑based et indique la position à partir de laquelle l’importation débute.

L’argument `useSlideWithIndexAsStart` contrôle la façon dont l’importateur utilise cette position :

- Lorsqu’il est `False`, l’importateur crée de nouvelles diapositives à l’index spécifié et décale les diapositives suivantes.
- Lorsqu’il est `True`, l’importateur commence à placer le contenu dans l’espace disponible de la diapositive existante à cet index. Si le HTML ne tient pas, Aspose.Slides le pagine automatiquement et insère des diapositives supplémentaires immédiatement après la diapositive de départ.

[SlideCollection.insertFromHtml](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#insertFromHtml) renvoie un tableau d’objets [Slide](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/). Lorsque l’insertion démarre sur de nouvelles diapositives, chaque élément renvoyé est nouvellement créé. Lorsqu’une diapositive existante est utilisée comme point de départ, le tableau comprend cette diapositive affectée suivie des éventuelles diapositives de dépassement. Vous pouvez examiner ce tableau au lieu de calculer la plage affectée à partir du nombre total de diapositives.

### **Insertion de HTML en tant que nouvelles diapositives**

L’exemple suivant fournit le HTML sous forme de chaîne et insère les diapositives générées à l’index de collection `1`. Passer `False` laisse les diapositives existantes inchangées, à l’exception du décalage pour faire de la place.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    insert_index = 1
    html = "<html><body><h1>Quarterly update</h1><p>This content is inserted before the slide that was at index 1.</p></body></html>"
    inserted_slides = presentation.getSlides().insertFromHtml(insert_index, html, False)

    for slide in inserted_slides:
        print("Inserted slide index:", presentation.getSlides().indexOf(slide))

    presentation.save("presentation-with-inserted-html.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Démarrer sur une diapositive existante**

L’exemple suivant fournit le HTML via un flux. Il conserve une forme d’en‑tête sur la diapositive modèle existante, commence l’importation sous la zone occupée et laisse le corps long se poursuivre sur de nouvelles diapositives.

Le HTML contient également une URL d’image relative. Un [ExternalResourceResolver](https://reference.aspose.com/slides/fr/python-java/aspose.slides/externalresourceresolver/) récupère la ressource, tandis que l’URI de base indique à l’importateur comment résoudre `images/logo.png`. Dans cet exemple, ce fichier est attendu dans `html-assets/images/logo.png`.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExternalResourceResolver, Presentation, SaveFormat, ShapeType
from java.io import ByteArrayInputStream

presentation = Presentation()
try:
    template_slide = presentation.getSlides().get_Item(0)
    header = template_slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 680, 60)
    header.getTextFrame().setText("Product roadmap")

    html_parts = ["<html><body><img src='images/logo.png' width='120' height='60'><h2>Roadmap details</h2>"]
    for item_index in range(1, 61):
        html_parts.append(f"<p style='font-size:24pt'>Roadmap item {item_index}: detailed implementation notes.</p>")
    html_parts.append("</body></html>")

    html = "".join(html_parts)
    html_data = html.encode("utf-8")
    resolver = ExternalResourceResolver()
    base_directory = Path("html-assets").resolve()
    base_uri = base_directory.as_uri() + "/"

    html_stream = ByteArrayInputStream(html_data)
    try:
        affected_slides = presentation.getSlides().insertFromHtml(0, html_stream, resolver, base_uri, True)
        for slide in affected_slides:
            print("Affected slide index:", presentation.getSlides().indexOf(slide))
    finally:
        html_stream.close()

    presentation.save("presentation-with-html-overflow.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Avertissement" color="warning" %}}
Un résolveur de ressources externes non restreint peut lire des ressources locales ou réseau référencées par le HTML. Pour des entrées non fiables, validez et assainissez les URL des ressources selon une liste blanche de schémas, répertoires et hôtes autorisés avant d’importer le HTML.
{{% /alert %}}

## **FAQ**

**Aspose.Slides peut‑il détecter les tableaux lors de l’importation d’un PDF ?**

Oui. Créez un objet [PdfImportOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pdfimportoptions/), appelez [setDetectTables](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pdfimportoptions/#setDetectTables) avec `True`, et transmettez les options à [addFromPdf](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidecollection/#addFromPdf). La qualité de la reconnaissance des tableaux dépend de la structure et de la complexité du PDF source.

{{% alert title="Remarque" color="info" %}}
Après l’importation de HTML, vous pouvez également exporter les diapositives vers [images](/slides/fr/python-java/convert-powerpoint-to-png/), [TIFF](/slides/fr/python-java/convert-powerpoint-to-tiff/), ou [SVG](/slides/fr/python-java/render-slide-as-svg/).
{{% /alert %}}