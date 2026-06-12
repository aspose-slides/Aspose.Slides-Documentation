---
title: Správa vlastností prezentace v Pythonu
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
- Rozšířené vlastnosti
- Správa vlastností
- Úprava vlastností
- Metadata dokumentu
- Úprava metadat
- Jazyk kontroly pravopisu
- Výchozí jazyk
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Ovládejte vlastnosti prezentace v Aspose.Slides pro Python via .NET a zefektivněte vyhledávání, značkování a pracovní postup ve vašich souborech PowerPoint."
---
## **Úvod**

Aspose.Slides podporuje dva typy vlastností dokumentu: **Vestavěné** a **Vlastní**. Oba tyto typy vlastností lze snadno získat a spravovat pomocí API Aspose.Slides.

Aspose.Slides vám umožňuje pracovat s vlastnostmi dokumentu prezentace prostřednictvím třídy [DocumentProperties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/documentproperties/) . Instance této třídy je vrácena vlastností [Presentation.document_properties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/document_properties/) . Následující příklady ukazují, jak tyto vlastnosti číst, upravovat a spravovat.

{{% alert color="primary" %}} 
Všimněte si, že nemůžete nastavit hodnoty pro pole **Application** a **Producer**, protože se v nich zobrazí Aspose Ltd. a Aspose.Slides for Python via .NET x.x.x.
{{% /alert %}} 

## **Správa vlastností prezentace**

Microsoft PowerPoint poskytuje funkci pro přidání některých vlastností do souborů prezentací. Tyto vlastnosti dokumentu umožňují uložit užitečné informace společně s dokumenty (soubory prezentací). Existují dva typy vlastností dokumentu jako následuje

- Systémově definované (Vestavěné) vlastnosti
- Uživatelem definované (Vlastní) vlastnosti

**Vestavěné** vlastnosti obsahují obecné informace o dokumentu, jako je název dokumentu, jméno autora, statistiky dokumentu a tak dál. **Vlastní** vlastnosti jsou takové, které jsou definovány uživateli jako páry **Název/Hodnota**, kde jak název, tak hodnota jsou definovány uživatelem. Pomocí Aspose.Slides for Python via .NET mohou vývojáři přistupovat a upravovat hodnoty vestavěných i vlastních vlastností. Microsoft PowerPoint 2007 umožňuje spravovat vlastnosti dokumentu souborů prezentací. Vše, co musíte udělat, je kliknout na ikonu Office a poté na položku nabídky **Prepare | Properties | Advanced Properties** v Microsoft PowerPoint 2007. Po výběru položky **Advanced Properties** se objeví dialogové okno, které vám umožní spravovat vlastnosti dokumentu souboru PowerPoint. V **Properties Dialog** můžete vidět mnoho záložek jako **General, Summary, Statistics, Contents** a **Custom**. Všechny tyto záložky umožňují konfigurovat různé druhy informací souvisejících se soubory PowerPoint. Záložka **Custom** se používá ke správě vlastních vlastností souborů PowerPoint.

## **Přístup k vestavěným vlastnostem**
Tyto vlastnosti, jak je vystavuje objekt **IDocumentProperties**, zahrnují: **Creator(Author)**, **Description**, **Keywords**, **Created** (Datum vytvoření), **Modified** (Datum úpravy), **Printed** (Datum posledního tisku), **LastModifiedBy**, **Keywords**, **SharedDoc** (Je sdílen mezi různými producenty?), **PresentationFormat**, **Subject** a **Title**
```py
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje prezentaci
with slides.Presentation(path + "AccessBuiltin Properties.pptx") as pres:
    # Vytvořte odkaz na objekt spojený s prezentací
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

## **Úprava vestavěných vlastností**

Úprava vestavěných vlastností souborů prezentace je tak snadná jako jejich získání. Jednoduše přiřadíte řetězcovou hodnotu libovolné požadované vlastnosti a hodnota vlastnosti bude upravena. V níže uvedeném příkladu jsme demonstrovali, jak můžeme upravit vestavěné vlastnosti dokumentu souboru prezentace.

```py
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje prezentaci
with slides.Presentation(path + "ModifyBuiltinProperties.pptx") as presentation:
    # Vytvořte odkaz na objekt spojený s prezentací
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

## **Přidání vlastních vlastností prezentace**

Aspose.Slides for Python via .NET také umožňuje vývojářům přidat vlastní hodnoty pro vlastnosti dokumentu prezentace. Níže je uveden příklad, který ukazuje, jak nastavit vlastní vlastnosti pro prezentaci.

```py
import aspose.slides as slides

# Vytvořte instanci třídy Presentation
with slides.Presentation() as presentation:
    # Získání vlastností dokumentu
    documentProperties = presentation.document_properties

    # Přidání vlastních vlastností
    documentProperties.set_custom_property_value("New Custom", 12)
    documentProperties.set_custom_property_value("My Nam", "Mudassir")
    documentProperties.set_custom_property_value("Custom", 124)

    # Získání názvu vlastnosti na konkrétním indexu
    getPropertyName = documentProperties.get_custom_property_name(2)

    # Odstranění vybrané vlastnosti
    documentProperties.remove_custom_property(getPropertyName)

    # Uložení prezentace
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Přístup a úprava vlastních vlastností**

Aspose.Slides for Python via .NET také umožňuje vývojářům přistupovat k hodnotám vlastních vlastností. Níže je uveden příklad, který ukazuje, jak můžete přistupovat a upravovat všechny tyto vlastní vlastnosti pro prezentaci.

```py
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje soubor PPTX
with slides.Presentation(path + "AccessModifyingProperties.pptx") as presentation:
    # Vytvořte odkaz na objekt document_properties spojený s prezentací
    documentProperties = presentation.document_properties

    # Přístup a úprava vlastních vlastností
    for i in range(documentProperties.count_of_custom_properties):
        # Zobrazení názvů a hodnot vlastních vlastností
        print("Custom Property Name : " + documentProperties.get_custom_property_name(i))
        print("Custom Property Value : " + documentProperties.get_custom_property_value[documentProperties.get_custom_property_name(i)])

        # Úprava hodnot vlastních vlastností
        documentProperties.set_custom_property_value(documentProperties.get_custom_property_name(i), "New Value " + str(i + 1))
    # Uložte prezentaci do souboru
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavení jazyka kontroly pravopisu**

Aspose.Slides poskytuje vlastnost `Language_Id` (vystavovanou třídou [PortionFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portionformat/) ), která vám umožní nastavit jazyk kontroly pravopisu pro PowerPoint dokument. Jazyk kontroly pravopisu je jazyk, pro který se v PowerPointu kontroluje pravopis a gramatika.

Tento Python kód ukazuje, jak nastavit jazyk kontroly pravopisu pro PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation(path + "SetProofingLanguage.pptx") as pres:
    auto_shape = pres.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    new_portion = slides.Portion()
    font = slides.FontData("SimSun")
    portion_format = new_portion.portion_format
    portion_format.complex_script_font = font
    portion_format.east_asian_font = font
    portion_format.latin_font = font

    # nastavte Id jazyka kontroly pravopisu
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **Nastavení výchozího jazyka**

Tento Python kód ukazuje, jak nastavit výchozí jazyk pro celou PowerPoint prezentaci:

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

## **Živý příklad**

Vyzkoušejte [**Aspose.Slides Metadata**](https://products.aspose.app/slides/cs/metadata) online aplikaci, abyste viděli, jak pracovat s vlastnostmi dokumentu pomocí API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/cs/metadata)

## **Často kladené otázky**

**Jak mohu odstranit vestavěnou vlastnost z prezentace?**

Vestavěné vlastnosti jsou nedílnou součástí prezentace a nelze je zcela odstranit. Můžete však změnit jejich hodnoty nebo je nastavit na prázdné, pokud to konkrétní vlastnost umožňuje.

**Co se stane, pokud přidám vlastní vlastnost, která již existuje?**

Pokud přidáte vlastní vlastnost, která již existuje, její stávající hodnota bude přepsána novou. Nemusíte vlastnost předem odstraňovat nebo kontrolovat, protože Aspose.Slides automaticky aktualizuje hodnotu vlastnosti.

**Mohu přistupovat k vlastnostem prezentace bez úplného načtení prezentace?**

Ano, můžete přistupovat k vlastnostem prezentace bez úplného načtení prezentace pomocí metody [get_presentation_info](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationfactory/get_presentation_info/) ze třídy [PresentationFactory](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationfactory/) . Poté využijte metodu [read_document_properties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationinfo/read_document_properties/) poskytovanou třídou [PresentationInfo](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationinfo/) k efektivnímu načtení vlastností, čímž šetříte paměť a zvyšujete výkon.