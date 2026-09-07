---
title: Convertir des présentations PowerPoint en documents Word en Python via Java
linktitle: PowerPoint vers Word
type: docs
weight: 110
url: /fr/python-java/convert-powerpoint-to-word/
keywords:
- convertir PowerPoint
- convertir présentation
- PowerPoint vers Word
- présentation vers Word
- PPT vers Word
- PPTX vers Word
- ODP vers Word
- PowerPoint vers DOCX
- PPT vers DOCX
- PPTX vers DOCX
- PowerPoint vers DOC
- enregistrer PPT en DOCX
- enregistrer PPTX en DOCX
- exporter PPT en DOCX
- exporter PPTX en DOCX
- Python
- Java
- Aspose.Slides
description: "Convertir des présentations PowerPoint et OpenDocument en Word en Python via Java avec Aspose.Slides et Aspose.Words, en combinant les images des diapositives avec du texte modifiable."
---
## **Aperçu**

Cet article explique comment convertir des présentations PowerPoint et OpenDocument en documents Word en utilisant Aspose.Slides pour Python via Java avec Aspose.Words pour Java. Aspose.Slides rend chaque diapositive et lit son texte, tandis qu'Aspose.Words crée le document Word via JPype. Microsoft Office n'est pas requis.

Le document résultant contient une image de diapositive suivie du texte modifiable extrait des formes automatiques de niveau supérieur de cette diapositive. L'image conserve l'apparence visuelle de la diapositive ; les formes individuelles, les graphiques et les tableaux ne sont pas convertis en objets Word modifiables. Le texte extrait ne conserve ni la mise en forme originale ni le positionnement.

## **Convertir PowerPoint en Word**

1. Installez [Aspose.Slides for Python via Java](/slides/fr/python-java/installation/) et un runtime Java compatible.  
2. Téléchargez [Aspose.Words for Java](https://releases.aspose.com/words/java/). Placez son fichier JAR principal dans un répertoire `lib` à côté de votre script et renommez-le en `aspose-words.jar`, ou ajustez le chemin dans l’exemple pour qu’il corresponde à votre fichier téléchargé.  
3. Placez la présentation d’entrée, `sample.pptx`, dans le répertoire de travail. Le chemin `lib/aspose-words.jar` est également relatif à ce répertoire.  
4. Exécutez le code Python suivant pour créer `output.docx`.

L’exemple charge la source avec [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) et rend les diapositives avec [Slide.getImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/#getImage). Il utilise [DocumentBuilder](https://reference.aspose.com/words/java/com.aspose.words/documentbuilder/) d’Aspose.Words pour insérer les images et le texte dans le document Word.

```python
from pathlib import Path

import jpype
import asposeslides

words_jar = Path("lib/aspose-words.jar").resolve()
jpype.addClassPath(str(words_jar))
if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ImageFormat, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")
Document = jpype.JClass("com.aspose.words.Document")
DocumentBuilder = jpype.JClass("com.aspose.words.DocumentBuilder")
BreakType = jpype.JClass("com.aspose.words.BreakType")

presentation = Presentation("sample.pptx")
try:
    document = Document()
    builder = DocumentBuilder(document)
    page_setup = builder.getPageSetup()
    content_width = page_setup.getPageWidth() - page_setup.getLeftMargin() - page_setup.getRightMargin()
    slide_size = presentation.getSlideSize().getSize()
    image_height = content_width * slide_size.getHeight() / slide_size.getWidth()
    slide_count = presentation.getSlides().size()

    for slide_index in range(slide_count):
        if slide_index > 0:
            builder.insertBreak(BreakType.PAGE_BREAK)

        slide = presentation.getSlides().get_Item(slide_index)
        image = slide.getImage(1.0, 1.0)
        try:
            image_stream = ByteArrayOutputStream()
            try:
                image.save(image_stream, ImageFormat.Png)
                image_bytes = image_stream.toByteArray()
            finally:
                image_stream.close()
        finally:
            image.dispose()

        # Ajuster l'image de la diapositive à la largeur de la zone de texte, en conservant son ratio d'aspect.
        builder.insertImage(image_bytes, content_width, image_height)
        builder.writeln()

        # Ajouter le texte brut des formes automatiques de niveau supérieur, y compris les zones de texte.
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                text_frame = shape.getTextFrame()
                if text_frame is not None:
                    text = str(text_frame.getText())
                    if text.strip():
                        builder.writeln(text)

    document.save("output.docx")
finally:
    presentation.dispose()
```

Chaque diapositive commence sur une nouvelle page. Un texte extrait long ou des images de diapositive anormalement hautes peuvent nécessiter des pages supplémentaires. Le code ajoute des sauts de page uniquement entre les diapositives et libère la présentation ainsi que les images rendues dans des blocs `finally`. La JVM reste disponible pour des conversions ultérieures dans le même processus Python.

## **FAQ**

**Quelles bibliothèques sont nécessaires ?**

Utilisez Aspose.Slides pour Python via Java, JPype, un runtime Java compatible, et Aspose.Words pour Java. Les deux bibliothèques Aspose s’exécutent dans la même JVM. Aspose.Slides gère la présentation ; Aspose.Words écrit le document Word.

**Puis‑je convertir des fichiers PPT et ODP ainsi que PPTX ?**

Oui. Remplacez `sample.pptx` par un fichier PPT ou ODP. Voir [Supported File Formats](/slides/fr/python-java/supported-file-formats/) pour les formats d’entrée de présentation.

**Tout le contenu de la diapositive est‑il modifiable dans Word ?**

Non. Chaque diapositive est insérée comme une image statique, avec le texte simple des formes automatiques de niveau supérieur ajouté en dessous. Le texte à l’intérieur des groupes, des tableaux, de SmartArt et des graphiques, ainsi que les notes du présentateur, n’est pas extrait par cet exemple. Les animations et les transitions ne sont pas reproduites dans le document Word.

**Puis‑je enregistrer en DOC au lieu de DOCX ?**

Oui. Changez le nom du fichier de sortie en `output.doc`. Aspose.Words sélectionne le format de sortie à partir de l’extension du nom de fichier lorsqu’on utilise cette surcharge de sauvegarde.