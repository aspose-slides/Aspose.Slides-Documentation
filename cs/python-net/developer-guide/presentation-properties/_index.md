---
title: Správa vlastností prezentace pomocí Pythonu
linktitle: Vlastnosti prezentace
type: docs
weight: 70
url: /cs/python-net/presentation-properties/
keywords:
- Vlastnosti PowerPoint
- Vlastnosti prezentace
- Vlastnosti dokumentu
- Vestavěné vlastnosti
- Vlastní vlastnosti
- Pokročilé vlastnosti
- Správa vlastností
- Úprava vlastností
- Metadata dokumentu
- Úprava metadat
- Jazyk kontroly pravopisu
- Výchozí jazyk
- PowerPoint
- OpenDocument
- Prezentace
- Python
- Aspose.Slides
description: "Zvládněte vlastnosti prezentace v Aspose.Slides pro Python via .NET a zefektivněte vyhledávání, značkování a pracovní procesy ve vašich souborech PowerPoint."
---
## **Úvod**

Aspose.Slides podporuje dva typy vlastností dokumentu: **Built-in** a **Custom**. Oba tyto typy vlastností lze snadno získat a spravovat pomocí API Aspose.Slides.

Aspose.Slides vám umožňuje pracovat s vlastnostmi dokumentu prezentace prostřednictvím třídy [DocumentProperties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/documentproperties/) . Instance této třídy je vrácena vlastností [Presentation.document_properties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/document_properties/) . Následující příklady ukazují, jak tyto vlastnosti číst, upravovat a spravovat.

{{% alert color="info" title="Poznámka" %}}
Všimněte si, že nemůžete nastavit hodnoty pro pole **Application** a **Producer**, protože proti těmto polím budou zobrazeny hodnoty Aspose Ltd. a Aspose.Slides for Python via .NET x.x.x.
{{% /alert %}} 

## **Správa vlastností prezentace**

Microsoft PowerPoint poskytuje funkci pro přidání některých vlastností k souborům prezentací. Tyto vlastnosti dokumentu umožňují uložit užitečné informace spolu s dokumenty (soubory prezentací). Existují dva druhy vlastností dokumentu, jak je uvedeno níže

- Systémově definované (Built‑in) vlastnosti
- Uživatelem definované (Custom) vlastnosti

**Built-in** vlastnosti obsahují obecné informace o dokumentu jako název dokumentu, jméno autora, statistiky dokumentu a podobně. **Custom** vlastnosti jsou ty, které jsou uživateli definovány jako páry **Name/Value**, kde jak název, tak hodnota jsou definovány uživatelem. Pomocí Aspose.Slides for Python via .NET mohou vývojáři získat a upravit hodnoty built‑in i custom vlastností. Microsoft PowerPoint 2007 umožňuje spravovat vlastnosti dokumentu souborů prezentací. Stačí kliknout na ikonu Office a poté na položku nabídky **Prepare | Properties | Advanced Properties** v Microsoft PowerPoint 2007. Po výběru položky **Advanced Properties** se zobrazí dialogové okno, které umožňuje spravovat vlastnosti dokumentu souboru PowerPoint. V **Properties Dialog** vidíte mnoho záložek jako **General, Summary, Statistics, Contents and Custom**. Všechny tyto záložky umožňují nastavit různé typy informací souvisejících se soubory PowerPoint. Záložka **Custom** slouží k správě vlastních (custom) vlastností souborů PowerPoint.

## **Čtení veřejných vlastností z šifrované prezentace**

Otevírací heslo obvykle chrání jak obsah prezentace, tak i vlastnosti dokumentu. Když je prezentace šifrována pomocí [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) nastaveným na `False`, její vlastnosti dokumentu zůstávají veřejné. Aplikace pak může nastavit [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/loadoptions/only_load_document_properties/) na `True` a přečíst veřejná metadata bez zadání otevíracího hesla.

`only_load_document_properties` řídí, co Aspose.Slides načte; nic nešifruje. Pokud byly vlastnosti zahrnuty do šifrování, načtení bez hesla selže. Pokud prezentace není šifrována, volba se ignoruje a načte se celá prezentace.

Následující příklad ověří režim načítání pomocí [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/cs/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) a poté načte built‑in vlastnosti přes [Presentation.document_properties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/document_properties/) :

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("public-properties-encrypted.pptx", load_options) as presentation:
    if presentation.protection_manager.is_only_document_properties_loaded:
        properties = presentation.document_properties

        print("Author: " + properties.author)
        print("Title: " + properties.title)
        print("Keywords: " + properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

V tomto režimu se nenačítá obsah snímků. Snímek, hlavní šablony, rozložení, tvary, média a další objekty prezentace nejsou k dispozici. Aplikace by měly vždy zkontrolovat `is_only_document_properties_loaded` před provedením operace, která vyžaduje kompletní model objektů prezentace.

{{% alert color="warning" title="Bezpečnost" %}}
Veřejná metadata mohou odhalit jména autorů, názvy, předměty, klíčová slova, informace o společnosti, komentáře a vlastní hodnoty. Šifrujte citlivé vlastnosti spolu s prezentací. Nechte je veřejné pouze tehdy, když indexování, klasifikace, vyhledávání nebo systémy pro správu dokumentů mají konkrétní požadavek na přístup k nim bez hesla.
{{% /alert %}}

## **Aktualizace vlastností šifrované prezentace**

Pro šifrovaný soubor PPTX je prezentace načtená s `only_load_document_properties` určena ke čtení veřejných metadat. Aspose.Slides nemůže uložit změněné vlastnosti z tohoto objektu pouze s metadaty, protože veřejné vlastnosti musí zůstat v souladu s odpovídajícími daty uvnitř šifrované prezentace. Aktualizace proto vyžaduje správné otevírací heslo a kompletní načtení.

Následující příklad otevře prezentaci pomocí [LoadOptions.password](https://reference.aspose.com/slides/cs/python-net/aspose.slides/loadoptions/password/), aktualizuje veřejné built‑in vlastnosti a uloží výsledek. Poté použije [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationinfo/is_encrypted/) , aby ověřil zachování šifrování, a znovu otevře veřejná metadata bez hesla k ověření nových hodnot :

```python
import aspose.slides as slides

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation(input_path, load_options) as presentation:
    presentation.document_properties.title = "Updated Product Roadmap"
    presentation.document_properties.keywords = "roadmap, planning, indexed"
    presentation.save(output_path, slides.export.SaveFormat.PPTX)

presentation_info = slides.PresentationFactory.instance.get_presentation_info(output_path)
print("The presentation is encrypted: " + str(presentation_info.is_encrypted))

metadata_load_options = slides.LoadOptions()
metadata_load_options.only_load_document_properties = True

with slides.Presentation(output_path, metadata_load_options) as metadata_presentation:
    if metadata_presentation.protection_manager.is_only_document_properties_loaded:
        print("Title: " + metadata_presentation.document_properties.title)
        print("Keywords: " + metadata_presentation.document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

Pokud aplikace nemá povoleno dešifrovat nebo načíst obsah prezentace, musí veřejné vlastnosti šifrovaného souboru PPTX považovat za pouze pro čtení.

## **Přístup k built‑in vlastnostem**
Tyto vlastnosti, jak je vystavuje objekt **IDocumentProperties**, zahrnují: **Creator(Author)**, **Description**, **Keywords**, **Created** (datum vytvoření), **Modified** (datum úpravy), **Printed** (datum posledního tisku), **LastModifiedBy**, **Keywords**, **SharedDoc** (je sdílen mezi různými producenty?), **PresentationFormat**, **Subject** a **Title**
```py
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje prezentaci
with slides.Presentation("AccessBuiltin Properties.pptx") as pres:
    # Vytvořte odkaz na objekt spojený s Presentation
    documentProperties = pres.document_properties

    # Zobrazte vestavěné vlastnosti
    print("category : " + documentProperties.category)
    print("Current Status : " + documentProperties.content_status)
    print("Creation Date : " + str(documentProperties.created_time))
    print("Author : " + documentProperties.author)
    print("Description : " + documentProperties.comments)
    print("KeyWords : " + documentProperties.keywords)
    print("Last Modified By : " + documentProperties.last_saved_by)
    print("Supervisor : " + documentProperties.manager)
    print("Modified Date : " + str(documentProperties.last_saved_time))
    print("Presentation Format : " + documentProperties.presentation_format)
    print("Last Print Date : " + str(documentProperties.last_printed))
    print("Is Shared between producers : " + str(documentProperties.shared_doc))
    print("Subject : " + documentProperties.subject)
    print("Title : " + documentProperties.title)
```

## **Úprava built‑in vlastností**

Úprava built‑in vlastností souborů prezentace je tak jednoduchá jako jejich přístup. Jednoduše můžete přiřadit řetězcovou hodnotu libovolné požadované vlastnosti a hodnota se upraví. V níže uvedeném příkladu jsme ukázali, jak lze upravit built‑in vlastnosti dokumentu prezentace.

```py
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která reprezentuje prezentaci
with slides.Presentation("ModifyBuiltinProperties.pptx") as presentation:
    # Vytvořte odkaz na objekt spojený s Presentation
    documentProperties = presentation.document_properties

    # Nastavte vestavěné vlastnosti
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # Uložte prezentaci do souboru
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Přidání vlastních (custom) vlastností prezentace**

Aspose.Slides for Python via .NET také umožňuje vývojářům přidat vlastní hodnoty pro vlastnosti dokumentu prezentace. Níže je uveden příklad, který ukazuje, jak nastavit custom vlastnosti pro prezentaci.

```py
import aspose.slides as slides

# Vytvořte instanci třídy Presentation
with slides.Presentation() as presentation:
    # Získání vlastností dokumentu
    documentProperties = presentation.document_properties

    # Přidání vlastních (Custom) vlastností
    documentProperties.set_custom_property_value("New Custom", 12)
    documentProperties.set_custom_property_value("My Nam", "Mudassir")
    documentProperties.set_custom_property_value("Custom", 124)

    # Získání názvu vlastnosti na konkrétním indexu
    getPropertyName = documentProperties.get_custom_property_name(2)

    # Odebrání vybrané vlastnosti
    documentProperties.remove_custom_property(getPropertyName)

    # Uložení prezentace
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Přístup a úprava vlastních (custom) vlastností**

Aspose.Slides for Python via .NET také umožňuje vývojářům přistupovat k hodnotám custom vlastností. Níže je uveden příklad, který ukazuje, jak můžete přistupovat a upravovat všechny tyto custom vlastnosti pro prezentaci.

```py
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje PPTX
with slides.Presentation("AccessModifyingProperties.pptx") as presentation:
    # Vytvořte odkaz na objekt document_properties spojený s Presentation
    documentProperties = presentation.document_properties

    # Přístup a úprava vlastních vlastností
    for i in range(documentProperties.count_of_custom_properties):
        property_name = documentProperties.get_custom_property_name(i)

        # Zobrazte názvy a hodnoty vlastních vlastností
        property_value = [""]
        documentProperties.get_custom_property_value(property_name, property_value)
        print("Custom Property Name : " + property_name)
        print("Custom Property Value : " + property_value[0])

        # Upravte hodnoty vlastních vlastností
        documentProperties.set_custom_property_value(property_name, "New Value " + str(i + 1))
    # Uložte prezentaci do souboru
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

`get_custom_property_value` vrací hodnotu prostřednictvím jednoprvkové seznamu předaného jako druhý argument a uložená hodnota je přetypována na typ prvku, který už v tomto seznamu je. Výše uvedený příklad používá `[""]`, takže čte řetězcové vlastnosti; pro čtení vlastnosti uložené jako číslo předávejte číselný zástupce, například `[0]`—jinak volání vyvolá `InvalidCastException`.

## **Nastavení jazykové kontroly (Proofing Language)**

Aspose.Slides poskytuje vlastnost `Language_Id` (vystavenou třídou [PortionFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portionformat/) ), která vám umožní nastavit jazykovou kontrolu pro dokument PowerPoint. Jazyková kontrola je jazyk, pro který se v PowerPointu kontroluje pravopis a gramatika.

Tento Python kód ukazuje, jak nastavit jazykovou kontrolu pro PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation("SetProofingLanguage.pptx") as pres:
    auto_shape = pres.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    new_portion = slides.Portion()
    font = slides.FontData("SimSun")
    portion_format = new_portion.portion_format
    portion_format.complex_script_font = font
    portion_format.east_asian_font = font
    portion_format.latin_font = font

    # nastavte Id jazykové kontroly
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **Nastavení výchozího jazyka**

Tento Python kód ukazuje, jak nastavit výchozí jazyk pro celou prezentaci PowerPoint:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en_US"

with slides.Presentation(load_options) as pres:
    shp = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 150)
    text_frame = shp.text_frame
    text_frame.text = "New Text"

    print(text_frame.paragraphs[0].portions[0].portion_format.language_id)
```

## **Ukázkový příklad**

Vyzkoušejte [**Aspose.Slides Metadata**](https://products.aspose.app/slides/cs/metadata) online aplikaci a podívejte se, jak pracovat s vlastnostmi dokumentu pomocí API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/cs/metadata)

## **FAQ**

**Jak mohu odstranit built‑in vlastnost z prezentace?**

Built‑in vlastnosti jsou nedílnou součástí prezentace a nelze je zcela odstranit. Můžete je však změnit nebo nastavit na prázdné, pokud to konkrétní vlastnost umožňuje.

**Co se stane, když přidám custom vlastnost, která již existuje?**

Pokud přidáte custom vlastnost, která již existuje, její stávající hodnota bude přepsána novou. Nemusíte vlastnost předtím odstraňovat nebo kontrolovat, protože Aspose.Slides automaticky aktualizuje hodnotu vlastnosti.

**Mohu přistupovat k vlastnostem prezentace bez úplného načtení prezentace?**

Ano. Použijte [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationfactory/get_presentation_info/) a poté [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationinfo/read_document_properties/) , abyste přečetli uložená metadata dokumentu bez vytváření instance [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) . Viz [Build a Lightweight Presentation Inventory](/slides/cs/python-net/examine-presentation/) pro úplný příklad reportování a omezení specifická pro formát.

**Mohu číst veřejné vlastnosti šifrované prezentace bez jejím otevíracího hesla?**

Ano. Prezentace musí být šifrována s nastavením `encrypt_document_properties` na `False` a musí být načtena s `only_load_document_properties` nastaveným na `True`.

**Mohu aktualizovat šifrovaný soubor PPTX v režimu pouze dokumentových vlastností?**

Ne. Veřejná a šifrovaná data vlastností musí zůstat konzistentní, takže aktualizace šifrovaného souboru PPTX vyžaduje načtení celé prezentace s správným otevíracím heslem.