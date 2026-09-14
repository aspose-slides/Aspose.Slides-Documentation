---
title: Gérer les propriétés de présentation en Python
linktitle: Propriétés de présentation
type: docs
weight: 70
url: /fr/python-java/presentation-properties/
keywords:
- propriétés PowerPoint
- propriétés de présentation
- propriétés du document
- propriétés intégrées
- propriétés personnalisées
- propriétés avancées
- gérer les propriétés
- modifier les propriétés
- métadonnées du document
- modifier les métadonnées
- langue de vérification
- langue par défaut
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Maîtrisez les propriétés de présentation dans Aspose.Slides for Python via Java et simplifiez la recherche, la marque et le flux de travail dans vos fichiers PowerPoint et OpenDocument."
---
## **Introduction**

Aspose.Slides prend en charge deux types de propriétés de document : **Built-in** et **Custom**. Les deux types de propriétés peuvent être facilement accédés et gérés à l'aide de l'API Aspose.Slides.

Aspose.Slides vous permet de travailler avec les propriétés de document de présentation via la classe [DocumentProperties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/documentproperties/). Une instance de cette classe est renvoyée par [Presentation.getDocumentProperties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getDocumentProperties). Les exemples suivants montrent comment lire, modifier et gérer ces propriétés.

{{% alert color="info" title="Note" %}}
Veuillez noter que les champs **Application** et **AppVersion** ne peuvent pas être modifiés. Aspose.Slides les réécrit à chaque enregistrement, de sorte qu’une présentation enregistrée indique toujours "Aspose.Slides for Java" ainsi que la version de la bibliothèque qui l’a générée. Toute valeur transmise à [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/fr/python-java/aspose.slides/documentproperties/#setNameOfApplication) est ignorée lors de l’écriture de la présentation.
{{% /alert %}}

## **Propriétés du document dans PowerPoint**

Microsoft PowerPoint 2007 vous permet de gérer les propriétés du document des fichiers de présentation. Cliquez sur l’icône Office et sélectionnez **Prepare | Properties | Advanced Properties**, comme indiqué ci‑dessous :

|**Sélection de l’élément du menu Propriétés avancées**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/ZrmuCD6.jpg)|
Après avoir sélectionné **Advanced Properties**, une boîte de dialogue apparaît où vous pouvez gérer les propriétés du document du fichier PowerPoint :

|**Boîte de dialogue Propriétés**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/LibmdQd.jpg)|
La **Boîte de dialogue Propriétés** contient des onglets tels que **General**, **Summary**, **Statistics**, **Contents** et **Custom**. Ces onglets vous permettent de configurer différents types d’informations sur les fichiers PowerPoint. Utilisez l’onglet **Custom** pour gérer les propriétés personnalisées.

## **Travailler avec les propriétés du document à l'aide d'Aspose.Slides for Python via Java**

Comme indiqué précédemment, Aspose.Slides for Python via Java prend en charge à la fois les propriétés de document **Built-in** et **Custom**. La classe [DocumentProperties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/documentproperties/) représente les propriétés de document associées à un fichier de présentation.

Utilisez [Presentation.getDocumentProperties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getDocumentProperties) pour accéder à ces propriétés comme décrit ci‑dessous.

## **Lire les propriétés publiques d'une présentation cryptée**

Un mot de passe d’ouverture protège normalement à la fois le contenu de la présentation et les propriétés du document. Lorsqu’une présentation est cryptée en passant `false` à [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties), ses propriétés de document restent publiques. Une application peut alors passer `true` à [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) et lire les métadonnées publiques sans fournir le mot de passe d’ouverture.

L’option « document‑properties‑only » contrôle ce qu’Aspose.Slides charge ; elle ne décrypte rien. Si les propriétés étaient incluses dans le chiffrement, le chargement sans le mot de passe échoue. Si la présentation n’est pas cryptée, l’option est ignorée et la présentation complète est chargée.

L’exemple suivant vérifie le mode de chargement via [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/fr/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) puis lit les propriétés intégrées via [Presentation.getDocumentProperties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getDocumentProperties):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions

load_options = LoadOptions()
load_options.setOnlyLoadDocumentProperties(True)

presentation = Presentation("public-properties-encrypted.pptx", load_options)
try:
    if presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        properties = presentation.getDocumentProperties()

        print("Author: ", properties.getAuthor())
        print("Title: ", properties.getTitle())
        print("Keywords: ", properties.getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    presentation.dispose()
```

Dans ce mode, le contenu des diapositives n’est pas chargé. Les diapositives, maîtres, dispositions, formes, médias et autres objets de présentation sont indisponibles. Les applications doivent toujours vérifier [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/fr/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) avant d’effectuer une opération nécessitant le modèle d’objet complet de la présentation.

{{% alert color="warning" title="Warning" %}}
Les métadonnées publiques peuvent exposer les noms d’auteur, titres, sujets, mots‑clefs, informations d’entreprise, commentaires et valeurs personnalisées. Cryptez les propriétés sensibles avec la présentation. Ne les laissez publiques que lorsque l’indexation, la classification, la recherche ou les systèmes de gestion documentaire ont une exigence spécifique d’accès sans mot de passe.
{{% /alert %}}

## **Mettre à jour les propriétés d'une présentation cryptée**

Pour un fichier PPTX crypté, une présentation chargée en mode « document‑properties‑only » est destinée à la lecture des métadonnées publiques. Aspose.Slides ne peut pas enregistrer les propriétés modifiées de cet objet « metadata‑only » car les propriétés publiques doivent rester cohérentes avec les données correspondantes à l’intérieur de la présentation cryptée. Leur mise à jour nécessite donc le mot de passe d’ouverture correct et un chargement complet.

L’exemple suivant ouvre la présentation avec [LoadOptions.setPassword](https://reference.aspose.com/slides/fr/python-java/aspose.slides/loadoptions/#setPassword), met à jour les propriétés intégrées publiques, puis enregistre le résultat. Il utilise ensuite [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationinfo/#isEncrypted) pour vérifier que le chiffrement est conservé et rouvre les métadonnées publiques sans mot de passe afin de vérifier les nouvelles valeurs :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions, PresentationFactory, SaveFormat

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation(input_path, load_options)
try:
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap")
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed")
    presentation.save(output_path, SaveFormat.Pptx)
finally:
    presentation.dispose()

presentation_info = PresentationFactory.getInstance().getPresentationInfo(output_path)
print("The presentation is encrypted: ", presentation_info.isEncrypted())

metadata_load_options = LoadOptions()
metadata_load_options.setOnlyLoadDocumentProperties(True)

metadata_presentation = Presentation(output_path, metadata_load_options)
try:
    if metadata_presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        print("Title: ", metadata_presentation.getDocumentProperties().getTitle())
        print("Keywords: ", metadata_presentation.getDocumentProperties().getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    metadata_presentation.dispose()
```

Si une application n’est pas autorisée à déchiffrer ou charger le contenu de la présentation, elle doit traiter les propriétés publiques d’un fichier PPTX crypté comme en lecture seule.

## **Accéder aux propriétés intégrées**

Les propriétés intégrées exposées par [DocumentProperties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/documentproperties/) comprennent : **Creator** (Auteur), **Description**, **Created** (Date de création), **Modified** (Date de modification), **Printed** (Date du dernier impression), **LastModifiedBy**, **Keywords**, **SharedDoc** (Partagée entre différents producteurs ?), **PresentationFormat**, **Subject** et **Title**.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, DocumentProperties

# Instancier la classe Presentation qui représente la présentation
presentation = Presentation("Presentation.pptx")
try:
    # Créer une référence à l'objet DocumentProperties associé à la présentation
    properties = presentation.getDocumentProperties()

    # Afficher les propriétés intégrées
    print("Category : ", properties.getCategory())
    print("Current Status : ", properties.getContentStatus())
    print("Creation Date : ", properties.getCreatedTime())
    print("Author : ", properties.getAuthor())
    print("Description : ", properties.getComments())
    print("KeyWords : ", properties.getKeywords())
    print("Last Modified By : ", properties.getLastSavedBy())
    print("Supervisor : ", properties.getManager())
    print("Modified Date : ", properties.getLastSavedTime())
    print("Presentation Format : ", properties.getPresentationFormat())
    print("Last Print Date : ", properties.getLastPrinted())
    print("Is Shared between producers : ", properties.getSharedDoc())
    print("Subject : ", properties.getSubject())
    print("Title : ", properties.getTitle())
finally:
    presentation.dispose()
```

## **Modifier les propriétés intégrées**

Modifier les propriétés intégrées est aussi simple que d’y accéder. Utilisez le setter correspondant pour assigner une nouvelle valeur. L’exemple suivant modifie les propriétés de document intégrées à l’aide d’Aspose.Slides for Python via Java.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # Créer une référence à l'objet DocumentProperties associé à la Présentation
    properties = presentation.getDocumentProperties()

    # Définir les propriétés intégrées
    properties.setAuthor("Aspose.Slides for Python via Java")
    properties.setTitle("Modifying Presentation Properties")
    properties.setSubject("Aspose Subject")
    properties.setComments("Aspose Description")
    properties.setManager("Aspose Manager")

    # Enregistrer la présentation dans un fichier
    presentation.save("DocProps.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Cet exemple modifie les propriétés intégrées de la présentation comme illustré ci‑dessous :

|**Propriétés du document intégrées après modification**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/zz1N9de.jpg)|

## **Ajouter des propriétés de document personnalisées**

Aspose.Slides for Python via Java permet également aux développeurs d’ajouter des propriétés de document personnalisées aux présentations. L’exemple ci‑dessous ajoute trois propriétés personnalisées, recherche le nom stocké à l’index 2 puis supprime cette propriété, de sorte que la présentation enregistrée en conserve deux. Les propriétés personnalisées sont indexées par ordre alphabétique, pas dans l’ordre d’ajout.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Obtention des propriétés du document
    properties = presentation.getDocumentProperties()

    # Ajout de propriétés personnalisées
    properties.set_Item("New Custom", jpype.JInt(12))
    properties.set_Item("My Name", "Mudassir")
    properties.set_Item("Custom", jpype.JInt(124))

    # Obtention du nom de la propriété à un indice particulier
    property_name = properties.getCustomPropertyName(2)

    # Suppression de la propriété sélectionnée
    properties.removeCustomProperty(property_name)

    # Enregistrement de la présentation
    presentation.save("CustomDemo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|**Propriétés de document personnalisées ajoutées**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/HdKcxI9.png)|

## **Accéder et modifier les propriétés personnalisées**

Aspose.Slides for Python via Java permet également aux développeurs d’accéder aux valeurs des propriétés personnalisées. L’exemple suivant montre comment accéder et modifier toutes les propriétés personnalisées d’une présentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # Créer une référence à l'objet DocumentProperties associé à la Présentation
    properties = presentation.getDocumentProperties()

    # Accéder et modifier les propriétés personnalisées
    for i in range(properties.getCountOfCustomProperties()):
        property_name = properties.getCustomPropertyName(i)
        # Afficher les noms et valeurs des propriétés personnalisées
        print("Custom Property Name : ", property_name)
        print("Custom Property Value : ", properties.get_Item(property_name))

        # Modifier les valeurs des propriétés personnalisées
        properties.set_Item(property_name, f"New Value {i + 1}")

    # Enregistrer votre présentation dans un fichier
    presentation.save("CustomDemoModified.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Cet exemple modifie les propriétés personnalisées de la présentation [PPTX](https://docs.fileformat.com/presentation/pptx/). Les figures suivantes montrent les propriétés personnalisées avant et après modification :

|**Propriétés personnalisées avant modification**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/Ze7YHvi.jpg)|

|**Propriétés personnalisées après modification**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/Tofu0CL.jpg)|

## **Propriétés avancées du document**

{{% alert color="info" title="Note" %}}
De nouvelles méthodes [readDocumentProperties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationinfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) et [writeBindedPresentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationinfo/#writeBindedPresentation) ont été ajoutées à la classe [PresentationInfo](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationinfo/), et le comportement de la méthode [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/fr/python-java/aspose.slides/documentproperties/#setLastSavedTime) a changé.
{{% /alert %}}

Les deux nouvelles méthodes [readDocumentProperties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationinfo/#readDocumentProperties) et [updateDocumentProperties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) ont été ajoutées à la classe [PresentationInfo](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationinfo/). Elles offrent un accès rapide aux propriétés du document et permettent de les changer et de les mettre à jour sans charger la présentation complète.

Le flux de travail typique consistant à charger les propriétés, à modifier leurs valeurs et à mettre à jour le document peut être implémenté comme suit :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

# Lire les informations de la présentation
presentation_info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx")

# Obtenir les propriétés actuelles
properties = presentation_info.readDocumentProperties()

# Définir les nouvelles valeurs des champs Auteur et Titre
properties.setAuthor("New Author")
properties.setTitle("New Title")

# Mettre à jour la présentation avec les nouvelles valeurs
presentation_info.updateDocumentProperties(properties)
presentation_info.writeBindedPresentation("presentation.pptx")
```

Il existe une autre façon d’utiliser les propriétés d’une présentation particulière comme modèle pour mettre à jour les propriétés d’autres présentations :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("template.pptx")
template = presentation_info.readDocumentProperties()

template.setAuthor("Template Author")
template.setTitle("Template Title")
template.setCategory("Template Category")
template.setKeywords("Keyword1, Keyword2, Keyword3")
template.setCompany("Our Company")
template.setComments("Created from template")
template.setContentType("Template Content")
template.setSubject("Template Subject")

for path in ["doc1.pptx", "doc2.odp", "doc3.ppt"]:
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

def update_by_template(path, template):
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

Un nouveau modèle peut être créé de zéro puis utilisé pour mettre à jour plusieurs présentations :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory, DocumentProperties

template = DocumentProperties()

template.setAuthor("Template Author")
template.setTitle("Template Title")
template.setCategory("Template Category")
template.setKeywords("Keyword1, Keyword2, Keyword3")
template.setCompany("Our Company")
template.setComments("Created from template")
template.setContentType("Template Content")
template.setSubject("Template Subject")

for path in ["doc1.pptx", "doc2.odp", "doc3.ppt"]:
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

## **Définir la langue de vérification**

Aspose.Slides fournit la méthode [PortionFormat.setLanguageId](https://reference.aspose.com/slides/fr/python-java/aspose.slides/portionformat/#setLanguageId) pour vous permettre de définir la langue de vérification d’un document PowerPoint. La langue de vérification est la langue selon laquelle l’orthographe et la grammaire de la présentation sont contrôlées.

Ce code Python montre comment définir la langue de vérification pour un PowerPoint :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Portion, FontData

pptx_file_name = "presentation.pptx"

presentation = Presentation(pptx_file_name)
try:
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    new_portion = Portion()

    font = FontData("SimSun")
    portion_format = new_portion.getPortionFormat()
    portion_format.setComplexScriptFont(font)
    portion_format.setEastAsianFont(font)
    portion_format.setLatinFont(font)

    portion_format.setLanguageId("zh-CN") # définir l'ID d'une langue de vérification

    new_portion.setText("1。")
    paragraph.getPortions().add(new_portion)
finally:
    presentation.dispose()
```

## **Définir la langue par défaut**

Ce code Python montre comment définir la langue par défaut pour l’ensemble d’une présentation PowerPoint :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    # Ajoute une forme rectangulaire avec du texte
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("New Text")

    # Vérifie la langue de la première portion
    print(shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **Exemple en ligne**

Essayez l’application en ligne [**Aspose.Slides Metadata**](https://products.aspose.app/slides/fr/metadata) pour voir comment travailler avec les propriétés du document via l’API Aspose.Slides :

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/fr/metadata)

## **FAQ**

**Comment puis‑je supprimer une propriété intégrée d’une présentation ?**

Les propriétés intégrées font partie intégrante de la présentation et ne peuvent pas être supprimées complètement. Vous pouvez toutefois modifier leurs valeurs ou les vider si la propriété le permet.

**Que se passe‑t‑il si j’ajoute une propriété personnalisée qui existe déjà ?**

Si vous ajoutez une propriété personnalisée qui existe déjà, sa valeur existante sera écrasée par la nouvelle. Vous n’avez pas besoin de la supprimer ou de la vérifier au préalable, Aspose.Slides met automatiquement à jour la valeur de la propriété.

**Puis‑je accéder aux propriétés de la présentation sans charger la présentation complète ?**

Oui. Utilisez [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationfactory/#getPresentationInfo) puis [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationinfo/#readDocumentProperties) pour lire les métadonnées du document stockées sans créer d’instance [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/). Consultez [Build a Lightweight Presentation Inventory](/slides/fr/python-java/examine-presentation/) pour un exemple complet de rapport et les limites spécifiques aux formats.

**Puis‑je lire les propriétés publiques d’une présentation cryptée sans son mot de passe d’ouverture ?**

Oui. Le chiffrement des propriétés du document doit avoir été désactivé avant que la présentation ne soit cryptée, et la présentation doit être chargée en mode « document‑properties‑only ».

**Puis‑je mettre à jour un fichier PPTX crypté en mode « document‑properties‑only » ?**

Non. Les données publiques et cryptées des propriétés doivent rester cohérentes, donc la mise à jour d’un fichier PPTX crypté nécessite de charger la présentation complète avec le mot de passe d’ouverture correct.