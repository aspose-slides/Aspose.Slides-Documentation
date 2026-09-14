---
title: Správa vlastností prezentace v Pythonu
linktitle: Vlastnosti prezentace
type: docs
weight: 70
url: /cs/python-java/presentation-properties/
keywords:
- Vlastnosti PowerPointu
- Vlastnosti prezentace
- Vlastnosti dokumentu
- Vestavěné vlastnosti
- Vlastní vlastnosti
- Pokročilé vlastnosti
- Správa vlastností
- Úprava vlastností
- Metadata dokumentu
- Úprava metadat
- Jazyk korektury
- Výchozí jazyk
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Spravujte vlastnosti prezentace v Aspose.Slides pro Python přes Java a zjednodušte vyhledávání, značkování a workflow ve vašich souborech PowerPoint a OpenDocument."
---
## **Úvod**

Aspose.Slides podporuje dva typy vlastností dokumentu: **Built-in** a **Custom**. Oba tyto typy vlastností lze snadno přistupovat a spravovat pomocí API Aspose.Slides.

Aspose.Slides vám umožňuje pracovat s vlastnostmi dokumentu prezentace prostřednictvím třídy [DocumentProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/documentproperties/) . Instance této třídy je vrácena metodou [Presentation.getDocumentProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getDocumentProperties) . Následující příklady ukazují, jak tyto vlastnosti číst, upravovat a spravovat.

{{% alert color="info" title="Poznámka" %}}
Upozorňujeme, že pole **Application** a **AppVersion** nelze upravit. Aspose.Slides je při každém uložení přepíše, takže uložená prezentace vždy uvádí "Aspose.Slides for Java" a verzi knihovny, která ji vytvořila. Jakákoli hodnota předaná metodě [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/cs/python-java/aspose.slides/documentproperties/#setNameOfApplication) je při zápisu prezentace zahozena.
{{% /alert %}}

## **Vlastnosti dokumentu v PowerPointu**

Microsoft PowerPoint 2007 vám umožňuje spravovat vlastnosti dokumentu souborů prezentací. Klikněte na ikonu Office a vyberte **Prepare | Properties | Advanced Properties**, jak je znázorněno níže:

|**Výběr položky nabídky Pokročilé vlastnosti**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/ZrmuCD6.jpg)|
Po výběru **Advanced Properties** se zobrazí dialog, ve kterém můžete spravovat vlastnosti dokumentu souboru PowerPoint:

|**Dialog vlastností**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/LibmdQd.jpg)|
Dialog **Properties Dialog** obsahuje karty jako **General**, **Summary**, **Statistics**, **Contents** a **Custom**. Tyto karty vám umožňují konfigurovat různé typy informací o souborech PowerPoint. Použijte kartu **Custom** pro správu vlastních vlastností.

## **Práce s vlastnostmi dokumentu pomocí Aspose.Slides pro Python přes Java**

Jak bylo zmíněno dříve, Aspose.Slides pro Python přes Java podporuje jak **Built-in**, tak **Custom** vlastnosti dokumentu. Třída [DocumentProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/documentproperties/) představuje vlastnosti dokumentu spojené s souborem prezentace.

Použijte [Presentation.getDocumentProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getDocumentProperties) , abyste získali přístup k těmto vlastnostem, jak je popsáno níže.

## **Čtení veřejných vlastností z šifrované prezentace**

Otevírací heslo obvykle chrání jak obsah prezentace, tak vlastnosti dokumentu. Když je prezentace zašifrována předáním `false` metodě [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) , zůstávají její vlastnosti dokumentu veřejné. Aplikace pak může předat `true` metodě [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) , a přečíst veřejná metadata bez zadání otevíracího hesla.

Volba pouze vlastností dokumentu řídí, co Aspose.Slides načte; nic nešifruje. Pokud byly vlastnosti zahrnuty do šifrování, načtení bez hesla selže. Pokud prezentace není šifrována, volba se ignoruje a načte se celá prezentace.

Následující příklad ověřuje režim načítání pomocí [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cs/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) , a poté čte vestavěné vlastnosti pomocí [Presentation.getDocumentProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getDocumentProperties) :

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

V tomto režimu není načten obsah snímků. Snímky, předlohy, rozvržení, tvary, média a další objekty prezentace nejsou dostupné. Aplikace by měly vždy zkontrolovat [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cs/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) , před provedením operace, která vyžaduje kompletní objektový model prezentace.

{{% alert color="warning" title="Upozornění" %}}
Veřejná metadata mohou odhalit jména autorů, názvy, předměty, klíčová slova, informace o společnosti, komentáře a vlastní hodnoty. Šifrujte citlivé vlastnosti spolu s prezentací. Nechte je veřejné pouze v případě, že indexování, klasifikace, vyhledávání nebo systémy pro správu dokumentů mají specifickou potřebu k nim přistupovat bez hesla.
{{% /alert %}}

## **Aktualizace vlastností šifrované prezentace**

Pro šifrovaný soubor PPTX je prezentace načtená v režimu pouze vlastností dokumentu určena k čtení veřejných metadat. Aspose.Slides nemůže uložit změněné vlastnosti z tohoto objektu jen s metadaty, protože veřejné vlastnosti musí zůstat konzistentní s odpovídajícími daty v šifrované prezentaci. Aktualizace proto vyžaduje správné otevírací heslo a kompletní načtení.

Následující příklad otevře prezentaci pomocí [LoadOptions.setPassword](https://reference.aspose.com/slides/cs/python-java/aspose.slides/loadoptions/#setPassword) , aktualizuje veřejné vestavěné vlastnosti a uloží výsledek. Poté použije [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationinfo/#isEncrypted) , aby ověřil, že šifrování zůstalo zachováno, a znovu otevře veřejná metadata bez hesla pro ověření nových hodnot :

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

Pokud aplikaci není povoleno dešifrovat nebo načíst obsah prezentace, musí veřejné vlastnosti šifrovaného souboru PPTX považovat za pouze ke čtení.

## **Přístup k vestavěným vlastnostem**

Vestavěné vlastnosti poskytované třídou [DocumentProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/documentproperties/) zahrnují: **Creator** (Autor), **Description**, **Created** (Datum vytvoření), **Modified** (Datum úpravy), **Printed** (Datum posledního tisku), **LastModifiedBy**, **Keywords**, **SharedDoc** (Je sdíleno mezi různými tvůrci?), **PresentationFormat**, **Subject** a **Title**.

```python
import jpype
import asposeslides

if not jpife.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, DocumentProperties

# Vytvořte instanci třídy Presentation, která představuje prezentaci
presentation = Presentation("Presentation.pptx")
try:
    # Vytvořte odkaz na objekt DocumentProperties spojený s prezentací
    properties = presentation.getDocumentProperties()

    # Zobrazte vestavěné vlastnosti
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

## **Úprava vestavěných vlastností**

Upravit vestavěné vlastnosti je tak jednoduché jako k nim přistupovat. Použijte odpovídající setter k přiřazení nové hodnoty. Následující příklad mění vestavěné vlastnosti dokumentu pomocí Aspose.Slides pro Python přes Java.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # Vytvořte odkaz na objekt DocumentProperties spojený s prezentací
    properties = presentation.getDocumentProperties()

    # Nastavte vestavěné vlastnosti
    properties.setAuthor("Aspose.Slides for Python via Java")
    properties.setTitle("Modifying Presentation Properties")
    properties.setSubject("Aspose Subject")
    properties.setComments("Aspose Description")
    properties.setManager("Aspose Manager")

    # Uložte prezentaci do souboru
    presentation.save("DocProps.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Tento příklad upravuje vestavěné vlastnosti prezentace, což je vidět níže:

|**Vestavěné vlastnosti dokumentu po úpravě**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/zz1N9de.jpg)|

## **Přidání vlastních vlastností dokumentu**

Aspose.Slides pro Python přes Java také umožňuje vývojářům přidávat vlastní vlastnosti dokumentu do prezentací. Níže uvedený příklad přidá tři vlastní vlastnosti, poté vyhledá název uložený na indexu 2 a tuto vlastnost odstraní, takže uložená prezentace si ponechá dvě z nich. Vlastní vlastnosti jsou indexovány v abecedním pořadí, nikoli v pořadí, v jakém byly přidány.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Získání vlastností dokumentu
    properties = presentation.getDocumentProperties()

    # Přidávání vlastních vlastností
    properties.set_Item("New Custom", jpype.JInt(12))
    properties.set_Item("My Name", "Mudassir")
    properties.set_Item("Custom", jpype.JInt(124))

    # Získání názvu vlastnosti na konkrétním indexu
    property_name = properties.getCustomPropertyName(2)

    # Odstranění vybrané vlastnosti
    properties.removeCustomProperty(property_name)

    # Ukládání prezentace
    presentation.save("CustomDemo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|**Přidané vlastní vlastnosti dokumentu**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/HdKcxI9.png)|

## **Přístup a úprava vlastních vlastností**

Aspose.Slides pro Python přes Java také umožňuje vývojářům přistupovat k hodnotám vlastních vlastností. Následující příklad ukazuje, jak přistupovat ke všem vlastním vlastnostem v prezentaci a jak je upravit.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # Vytvořte odkaz na objekt DocumentProperties spojený s prezentací
    properties = presentation.getDocumentProperties()

    # Přístup a úprava vlastních vlastností
    for i in range(properties.getCountOfCustomProperties()):
        property_name = properties.getCustomPropertyName(i)
        # Zobrazte názvy a hodnoty vlastních vlastností
        print("Custom Property Name : ", property_name)
        print("Custom Property Value : ", properties.get_Item(property_name))

        # Úprava hodnot vlastních vlastností
        properties.set_Item(property_name, f"New Value {i + 1}")

    # Uložte prezentaci do souboru
    presentation.save("CustomDemoModified.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Tento příklad mění vlastní vlastnosti prezentace [PPTX](https://docs.fileformat.com/presentation/pptx/) . Následující obrázky ukazují vlastní vlastnosti prezentace před a po úpravě:

|**Vlastní vlastnosti před úpravou**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/Ze7YHvi.jpg)|

|**Vlastní vlastnosti po úpravě**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/Tofu0CL.jpg)|

## **Pokročilé vlastnosti dokumentu**

{{% alert color="info" title="Poznámka" %}}
Byly přidány nové metody [readDocumentProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationinfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) a [writeBindedPresentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationinfo/#writeBindedPresentation) do třídy [PresentationInfo](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationinfo/) , a chování metody [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/cs/python-java/aspose.slides/documentproperties/#setLastSavedTime) bylo změněno.
{{% /alert %}}

Dvě nové metody [readDocumentProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationinfo/#readDocumentProperties) a [updateDocumentProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) byly přidány do třídy [PresentationInfo](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationinfo/) . Poskytují rychlý přístup k vlastnostem dokumentu a umožňují měnit a aktualizovat vlastnosti bez načítání celé prezentace.

Typický postup načítání vlastností, změny jejich hodnot a aktualizace dokumentu lze implementovat následovně:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

# Přečtěte informace o prezentaci
presentation_info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx")

# Získejte aktuální vlastnosti
properties = presentation_info.readDocumentProperties()

# Nastavte nové hodnoty polí Autor a Název
properties.setAuthor("New Author")
properties.setTitle("New Title")

# Aktualizujte prezentaci s novými hodnotami
presentation_info.updateDocumentProperties(properties)
presentation_info.writeBindedPresentation("presentation.pptx")
```

Existuje další způsob, jak použít vlastnosti konkrétní prezentace jako šablonu k aktualizaci vlastností v jiných prezentacích:

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

Novou šablonu lze vytvořit od nuly a poté použít k aktualizaci několika prezentací:

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

## **Nastavení jazykové kontroly**

Aspose.Slides poskytuje metodu [PortionFormat.setLanguageId](https://reference.aspose.com/slides/cs/python-java/aspose.slides/portionformat/#setLanguageId) , která vám umožní nastavit jazykovou kontrolu pro dokument PowerPoint. Jazyková kontrola je jazyk, pro který je kontrolována pravopis a gramatika v prezentaci.

Tento Python kód ukazuje, jak nastavit jazykovou kontrolu pro PowerPoint:

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

    portion_format.setLanguageId("zh-CN") # nastavte ID jazykové kontroly

    new_portion.setText("1。")
    paragraph.getPortions().add(new_portion)
finally:
    presentation.dispose()
```

## **Nastavení výchozího jazyka**

Tento Python kód ukazuje, jak nastavit výchozí jazyk pro celou prezentaci PowerPoint:

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
    # Přidá obdélníkový tvar s textem
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("New Text")

    # Kontroluje jazyk první části
    print(shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **Živý příklad**

Vyzkoušejte online aplikaci [**Aspose.Slides Metadata**](https://products.aspose.app/slides/cs/metadata) abyste viděli, jak pracovat s vlastnostmi dokumentu pomocí API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/cs/metadata)

## **Často kladené otázky**

**Jak mohu odstranit vestavěnou vlastnost z prezentace?**

Vestavěné vlastnosti jsou nedílnou součástí prezentace a nelze je zcela odstranit. Můžete však změnit jejich hodnoty nebo je nastavit na prázdné, pokud to konkrétní vlastnost umožňuje.

**Co se stane, když přidám vlastní vlastnost, která již existuje?**

Pokud přidáte vlastní vlastnost, která již existuje, její stávající hodnota bude přepsána novou. Nemusíte ji předtím odstraňovat nebo kontrolovat, protože Aspose.Slides automaticky aktualizuje hodnotu vlastnosti.

**Mohu získat přístup k vlastnostem prezentace bez úplného načtení prezentace?**

Ano. Použijte [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationfactory/#getPresentationInfo) , a poté [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationinfo/#readDocumentProperties) , abyste přečetli uložená metadata dokumentu bez vytvoření instance [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) . Viz [Build a Lightweight Presentation Inventory](/slides/cs/python-java/examine-presentation/) pro kompletní ukázku reportování a omezení specifická pro formát.

**Mohu číst veřejné vlastnosti šifrované prezentace bez jeho otevíracího hesla?**

Ano. Šifrování vlastností dokumentu musí být vypnuto před tím, než byla prezentace zašifrována, a prezentace musí být načtena v režimu pouze vlastností dokumentu.

**Mohu aktualizovat šifrovaný soubor PPTX v režimu pouze vlastností dokumentu?**

Ne. Veřejná a šifrovaná data vlastností musejí zůstat konzistentní, takže aktualizace šifrovaného souboru PPTX vyžaduje načtení celé prezentace se správným otevíracím heslem.