---
title: Gérer OLE dans les présentations avec Python
linktitle: Gérer OLE
type: docs
weight: 40
url: /fr/python-java/manage-ole/
keywords:
- Objet OLE
- Liaison et incorporation d'objets
- ajouter OLE
- incorporer OLE
- ajouter objet
- incorporer objet
- ajouter fichier
- incorporer fichier
- objet lié
- fichier lié
- modifier OLE
- icône OLE
- titre OLE
- extraire OLE
- extraire objet
- extraire fichier
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Optimisez la gestion des objets OLE dans PowerPoint et les fichiers OpenDocument avec Aspose.Slides pour Python via Java. Incorporez, mettez à jour et exportez le contenu OLE de façon fluide."
---
## **Introduction**

{{% alert color="info" title="Remarque" %}}
OLE (Object Linking & Embedding) est une technologie Microsoft qui permet aux données et aux objets créés dans une application d'être placés dans une autre application via le lien ou l'incorporation.
{{% /alert %}}

Considérez un graphique créé dans MS Excel. Le graphique est ensuite placé dans une diapositive PowerPoint. Ce graphique Excel est considéré comme un objet OLE.

- Un objet OLE peut apparaître sous forme d'icône. Dans ce cas, lorsque vous double-cliquez sur l'icône, le graphique s'ouvre dans son application associée (Excel), ou il vous est demandé de choisir une application pour ouvrir ou modifier l'objet.
- Un objet OLE peut afficher son contenu réel, comme le contenu d'un graphique. Dans ce cas, le graphique est activé dans PowerPoint, l'interface du graphique se charge, et vous pouvez modifier les données du graphique dans PowerPoint.

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/fr/python-java/) permet d'insérer des objets OLE dans les diapositives sous forme de cadres d'objet OLE ([OleObjectFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/oleobjectframe/)).

## **Ajouter des cadres d'objet OLE aux diapositives**

En supposant que vous avez déjà créé un graphique dans Microsoft Excel et que vous souhaitez l'incorporer dans une diapositive sous forme de cadre d'objet OLE à l'aide d'Aspose.Slides for Python via Java, vous pouvez procéder ainsi :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) .
2. Obtenez la référence d’une diapositive via son index.
3. Lisez le fichier Excel sous forme de tableau d'octets.
4. Ajoutez le [OleObjectFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/oleobjectframe/) à la diapositive en incluant le tableau d'octets et les autres informations relatives à l'objet OLE.
5. Enregistrez la présentation modifiée en tant que fichier PPTX.

Dans l'exemple ci‑dessous, nous avons ajouté un graphique provenant d'un fichier Excel à une diapositive sous forme de cadre d'objet OLE à l'aide d'Aspose.Slides for Python via Java.  
**Note** que le constructeur [OleEmbeddedDataInfo](https://reference.aspose.com/slides/fr/python-java/aspose.slides/oleembeddeddatainfo/) prend une extension d'objet incorporable en deuxième paramètre. Cette extension permet à PowerPoint d’interpréter correctement le type de fichier et de choisir la bonne application pour ouvrir cet objet OLE.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    slide = presentation.getSlides().get_Item(0)

    # Préparer les données pour l'objet OLE.
    file_data = Path("book.xlsx").read_bytes()
    file_data = jpype.JArray(jpype.JByte)(file_data)
    data_info = OleEmbeddedDataInfo(file_data, "xlsx")

    # Ajouter le cadre d'objet OLE à la diapositive.
    frame_width = jpype.JFloat(slide_size.getWidth())
    frame_height = jpype.JFloat(slide_size.getHeight())
    slide.getShapes().addOleObjectFrame(0, 0, frame_width, frame_height, data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Ajouter des cadres d'objet OLE liés**

Aspose.Slides for Python via Java permet d'ajouter un [OleObjectFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/oleobjectframe/) sans incorporer les données mais uniquement avec un lien vers le fichier.

Ce code Python montre comment ajouter un [OleObjectFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/oleobjectframe/) avec un fichier Excel lié à une diapositive :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Ajouter un cadre d'objet OLE avec un fichier Excel lié.
    slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx")

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Accéder aux cadres d'objet OLE**

Si un objet OLE est déjà incorporé dans une diapositive, vous pouvez facilement le trouver ou y accéder de cette manière :

1. Chargez une présentation contenant l'objet OLE incorporé en créant une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) .
2. Obtenez la référence de la diapositive en utilisant son index.
3. Accédez à la forme [OleObjectFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/oleobjectframe/). Dans notre exemple, nous avons utilisé le PPTX créé précédemment qui ne possède qu’une forme sur la première diapositive. Nous avons ensuite vérifié que l’objet était un [OleObjectFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/oleobjectframe/). C’était le cadre d'objet OLE souhaité à accéder.
4. Une fois le cadre d'objet OLE accédé, vous pouvez effectuer toute opération dessus.

Dans l'exemple ci‑dessous, un cadre d'objet OLE (un objet graphique Excel incorporé dans une diapositive) et ses données de fichier sont accessibles.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # Obtenir les données du fichier incorporé.
        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

        # Obtenir l'extension du fichier incorporé.
        file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

        # ...
finally:
    presentation.dispose()
```

### **Accéder aux propriétés du cadre d'objet OLE lié**

Aspose.Slides permet d'accéder aux propriétés du cadre d'objet OLE lié.

Ce code Python montre comment vérifier si un objet OLE est lié puis obtenir le chemin du fichier lié :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.ppt")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        # Vérifier si l'objet OLE est lié.
        if ole_frame.isObjectLink():
            # Afficher le chemin complet du fichier lié.
            print("OLE object frame is linked to: " + str(ole_frame.getLinkPathLong()))

            # Afficher le chemin relatif du fichier lié s'il est présent.
            # Seules les présentations PPT peuvent contenir le chemin relatif.
            relative_path = ole_frame.getLinkPathRelative()
            if relative_path is not None and not relative_path.isEmpty():
                print("OLE object frame relative path: " + str(relative_path))
finally:
    presentation.dispose()
```

## **Modifier les données d'objet OLE**

{{% alert color="info" title="Remarque" %}}
Dans cette section, l'exemple de code ci‑dessous utilise [Aspose.Cells for Python via Java](https://products.aspose.com/cells/python-java/).
{{% /alert %}}

Si un objet OLE est déjà incorporé dans une diapositive, vous pouvez facilement accéder à cet objet et modifier ses données de cette façon :

1. Chargez une présentation contenant l'objet OLE incorporé en créant une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) .
2. Obtenez la référence de la diapositive via son index.
3. Accédez à la forme du cadre d'objet OLE. Dans notre exemple, nous avons utilisé le PPTX créé précédemment qui possède une forme sur la première diapositive. Nous avons ensuite vérifié que l’objet était un [OleObjectFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/oleobjectframe/). C’était le cadre d’objet OLE souhaité à accéder.
4. Une fois le cadre d'objet OLE accédé, vous pouvez effectuer toute opération dessus.
5. Créez un objet [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) et accédez aux données OLE.
6. Accédez à la [Worksheet](https://reference.aspose.com/cells/python-java/asposecells.api/worksheet/) souhaitée et modifiez les données.
7. Enregistrez le [Workbook](https://reference.aspose.com/cells/python-java/asposecells.api/workbook/) mis à jour dans un flux.
8. Modifiez les données de l'objet OLE à partir du flux.

Dans l'exemple ci‑dessous, un cadre d'objet OLE (un objet graphique Excel incorporé dans une diapositive) est accédé, et les données de son fichier sont modifiées pour mettre à jour les données du graphique.

```python
import jpype
import asposeslides
import asposecells

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, OleObjectFrame, Presentation, SaveFormat
from asposecells.api import Workbook, OoxmlSaveOptions
from asposecells.api import SaveFormat as CellsSaveFormat
from java.io import ByteArrayInputStream, ByteArrayOutputStream

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    if isinstance(shape, OleObjectFrame):
        ole_frame = shape

        file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
        ole_stream = ByteArrayInputStream(file_data)

        # Lire les données de l'objet OLE en tant qu'objet Workbook.
        workbook = Workbook(ole_stream)

        new_ole_stream = ByteArrayOutputStream()

        # Modifier les données du classeur.
        cells = workbook.getWorksheets().get(0).getCells()
        cells.get(0, 4).putValue("E")
        cells.get(1, 4).putValue(jpype.JInt(12))
        cells.get(2, 4).putValue(jpype.JInt(14))
        cells.get(3, 4).putValue(jpype.JInt(15))

        file_options = OoxmlSaveOptions(CellsSaveFormat.XLSX)
        workbook.save(new_ole_stream, file_options)

        # Modifier les données de l'objet cadre OLE.
        new_file_data = new_ole_stream.toByteArray()
        new_data = OleEmbeddedDataInfo(new_file_data, ole_frame.getEmbeddedData().getEmbeddedFileExtension())
        ole_frame.setEmbeddedData(new_data)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Incorporer d'autres types de fichiers dans les diapositives**

En plus des graphiques Excel, Aspose.Slides for Python via Java vous permet d'incorporer d'autres types de fichiers dans les diapositives. Par exemple, vous pouvez insérer des fichiers HTML, PDF et ZIP comme objets. Lorsqu'un utilisateur double-clique sur l'objet inséré, il s'ouvre automatiquement dans le programme approprié, ou il est invité à sélectionner le programme adéquat pour l'ouvrir.

Ce code Python montre comment incorporer du HTML et du ZIP dans une diapositive :

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    html_data = Path("sample.html").read_bytes()
    html_data = jpype.JArray(jpype.JByte)(html_data)
    html_data_info = OleEmbeddedDataInfo(html_data, "html")
    html_ole_frame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, html_data_info)
    html_ole_frame.setObjectIcon(True)

    zip_data = Path("sample.zip").read_bytes()
    zip_data = jpype.JArray(jpype.JByte)(zip_data)
    zip_data_info = OleEmbeddedDataInfo(zip_data, "zip")
    zip_ole_frame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zip_data_info)
    zip_ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Définir les types de fichiers pour les objets incorporés**

Lors de la manipulation de présentations, il peut être nécessaire de remplacer d'anciens objets OLE par de nouveaux ou de remplacer un objet OLE non pris en charge par un objet pris en charge. Aspose.Slides for Python via Java vous permet de définir le type de fichier d'un objet incorporé, vous permettant de mettre à jour les données du cadre OLE ou son extension.

Ce code Python montre comment définir le type de fichier d'un objet OLE incorporé sur `zip` :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleEmbeddedDataInfo, Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()
    file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()

    print("Current embedded file extension is: " + str(file_extension))

    # Modifier le type de fichier en ZIP.
    data_info = OleEmbeddedDataInfo(file_data, "zip")
    ole_frame.setEmbeddedData(data_info)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Définir les images d'icône et les titres pour les objets incorporés**

Après avoir incorporé un objet OLE, un aperçu composé d’une image d’icône est ajouté automatiquement. Cet aperçu est ce que les utilisateurs voient avant d’accéder ou d’ouvrir l’objet OLE. Si vous souhaitez utiliser une image et un texte spécifiques comme éléments de l’aperçu, vous pouvez définir l’image d’icône et le titre à l’aide d’Aspose.Slides for Python via Java.

Ce code Python montre comment définir l’image d’icône et le titre pour un objet incorporé :

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    # Ajouter une image aux ressources de la présentation.
    image_data = Path("image.png").read_bytes()
    image_data = jpype.JArray(jpype.JByte)(image_data)
    ole_image = presentation.getImages().addImage(image_data)

    # Définir un titre et l'image pour l'aperçu OLE.
    ole_frame.setSubstitutePictureTitle("My title")
    ole_frame.getSubstitutePictureFormat().getPicture().setImage(ole_image)
    ole_frame.setObjectIcon(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Empêcher qu’un cadre d’objet OLE soit redimensionné et repositionné**

Après avoir ajouté un objet OLE lié à une diapositive de présentation, lorsque vous ouvrez la présentation dans PowerPoint, vous pouvez voir un message vous demandant de mettre à jour les liens. Cliquer sur le bouton « Update Links » peut modifier la taille et la position du cadre d’objet OLE car PowerPoint met à jour les données de l’objet OLE lié et rafraîchit l’aperçu de l’objet. Pour empêcher PowerPoint de demander la mise à jour des données de l’objet, définissez la méthode [setUpdateAutomatic](https://reference.aspose.com/slides/fr/python-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) de la classe [OleObjectFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/oleobjectframe/) sur `False` :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ole_frame = slide.getShapes().get_Item(0)

    ole_frame.setUpdateAutomatic(False)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Extraire les fichiers incorporés**

Aspose.Slides for Python via Java vous permet d'extraire les fichiers incorporés dans les diapositives en tant qu'objets OLE de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) contenant les objets OLE que vous souhaitez extraire.
2. Parcourez toutes les formes de la présentation et accédez aux formes [OleObjectFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/oleobjectframe/).
3. Accédez aux données des fichiers incorporés à partir des cadres d’objet OLE et écrivez‑les sur le disque.

Ce code Python montre comment extraire les fichiers incorporés dans une diapositive en tant qu'objets OLE :

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OleObjectFrame, Presentation

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)

        if isinstance(shape, OleObjectFrame):
            ole_frame = shape

            file_data = ole_frame.getEmbeddedData().getEmbeddedFileData()
            file_extension = ole_frame.getEmbeddedData().getEmbeddedFileExtension()

            file_path = Path(f"OLE_object_{index}.{str(file_extension).lstrip('.')}")
            file_path.write_bytes(bytes(file_data))
finally:
    presentation.dispose()
```

## **FAQ**

**Le contenu OLE sera-t-il rendu lors de l'exportation des diapositives vers PDF/images ?**

Ce qui est visible sur la diapositive est rendu — l’icône ou l’image de substitution (aperçu). Le contenu OLE « live » n’est pas exécuté lors du rendu. Si nécessaire, définissez votre propre image d’aperçu pour garantir l’apparence attendue dans le PDF exporté.

**Comment verrouiller un objet OLE sur une diapositive pour que les utilisateurs ne puissent pas le déplacer ou le modifier dans PowerPoint ?**

Verrouillez la forme : Aspose.Slides propose des [verrouillages au niveau de la forme](/slides/fr/python-java/applying-protection-to-presentation/). Ce n’est pas un chiffrement, mais cela empêche efficacement les modifications et déplacements accidentels.

**Pourquoi un objet Excel lié « saute » ou change de taille lorsque j’ouvre la présentation ?**

PowerPoint peut rafraîchir l’aperçu de l’OLE lié. Pour une apparence stable, suivez les bonnes pratiques de la [Solution de redimensionnement de la feuille de calcul](/slides/fr/python-java/working-solution-for-worksheet-resizing/) : ajustez le cadre à la plage, ou redimensionnez la plage à un cadre fixe et définissez une image de substitution appropriée.

**Les chemins relatifs pour les objets OLE liés seront-ils conservés dans le format PPTX ?**

Dans le PPTX, les informations de « chemin relatif » ne sont pas disponibles—seul le chemin complet l’est. Les chemins relatifs existent dans le format PPT plus ancien. Pour la portabilité, privilégiez les chemins absolus fiables/URI accessibles ou l’incorporation.