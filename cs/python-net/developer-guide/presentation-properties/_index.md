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
- Pokročilé vlastnosti
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
description: "Ovládněte vlastnosti prezentace v Aspose.Slides for Python via .NET a zefektivněte vyhledávání, brandování a pracovní tok ve vašich souborech PowerPoint."
---
## **Úvod**

Aspose.Slides podporuje dva typy vlastností dokumentu: **Built-in** a **Custom**. Oba typy vlastností lze snadno získat a spravovat pomocí Aspose.Slides API.

Aspose.Slides vám umožňuje pracovat s vlastnostmi prezentace prostřednictvím třídy [DocumentProperties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/documentproperties/). Instance této třídy je vrácena vlastností [Presentation.document_properties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/document_properties/). Následující příklady ukazují, jak číst, měnit a spravovat tyto vlastnosti.

{{% alert color="info" title="Poznámka" %}}
Upozorňujeme, že hodnoty polí **Application** a **Producer** nemůžete nastavit, protože v těchto polích bude zobrazeno “Aspose Ltd.” a “Aspose.Slides for Python via .NET x.x.x”.
{{% /alert %}} 

## **Spravovat vlastnosti prezentace**

Microsoft PowerPoint poskytuje funkci pro přidání některých vlastností do souborů prezentace. Tyto vlastnosti umožňují uložit užitečné informace spolu s dokumenty (souborami prezentace). Existují dva typy vlastností dokumentu:

- System Defined (Built-in) Properties
- User Defined (Custom) Properties

**Built-in** vlastnosti obsahují obecné informace o dokumentu, jako je název dokumentu, jméno autora, statistiky dokumentu a podobně. **Custom** vlastnosti jsou definovány uživateli jako páry **Název/Hodnota**, kde oba název i hodnota jsou určeny uživatelem. Pomocí Aspose.Slides for Python via .NET mohou vývojáři získávat a měnit hodnoty vestavěných i vlastních vlastností. Microsoft PowerPoint 2007 umožňuje spravovat vlastnosti dokumentu souborů prezentace. Stačí kliknout na ikonu Office a následně na položku **Prepare | Properties | Advanced Properties** v Microsoft PowerPoint 2007. Po výběru položky **Advanced Properties** se zobrazí dialog, který umožňuje spravovat vlastnosti PowerPoint souboru. V **Properties Dialog** vidíte několik záložek, jako **General, Summary, Statistics, Contents** a **Custom**. Všechny tyto záložky umožňují konfigurovat různé typy informací souvisejících s PowerPoint soubory. Záložka **Custom** slouží k správě vlastních vlastností PowerPoint souborů.

## **Přístup k vestavěným vlastnostem**
Tyto vlastnosti, které jsou vystaveny objektem **IDocumentProperties**, zahrnují: **Creator(Author)**, **Description**, **Keywords**, **Created** (Creation Date), **Modified** (Modification Date), **Printed** (Last Print Date), **LastModifiedBy**, **Keywords**, **SharedDoc** (Is shared between different producers?), **PresentationFormat**, **Subject** a **Title**
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

## **Upravit vestavěné vlastnosti**

Úprava vestavěných vlastností souborů prezentace je stejně snadná jako jejich získání. Stačí přiřadit řetězcovou hodnotu libovolné požadované vlastnosti a hodnota se upraví. V níže uvedeném příkladu demonstrujeme, jak lze upravit vestavěné vlastnosti dokumentu prezentace.

```py
import aspose.slides as slides

# Instancujte třídu Presentation, která představuje Presentation
with slides.Presentation("ModifyBuiltinProperties.pptx") as presentation:
    # Vytvořte odkaz na objekt spojený s Presentation
    documentProperties = presentation.document_properties

    # Nastavte vestavěné vlastnosti
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # Uložte svou prezentaci do souboru
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Přidat vlastní vlastnosti prezentace**

Aspose.Slides for Python via .NET také umožňuje vývojářům přidávat vlastní hodnoty pro vlastnosti dokumentu prezentace. Níže je uveden příklad, který ukazuje, jak nastavit vlastní vlastnosti pro prezentaci.

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

Aspose.Slides for Python via .NET také umožňuje vývojářům získat hodnoty vlastních vlastností. Níže je uveden příklad, který ukazuje, jak můžete získat a upravit všechny tyto vlastní vlastnosti pro prezentaci.

```py
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje PPTX
with slides.Presentation("AccessModifyingProperties.pptx") as presentation:
    # Vytvořte odkaz na objekt document_properties spojený s Presentation
    documentProperties = presentation.document_properties

    # Přístup a úprava vlastních vlastností
    for i in range(documentProperties.count_of_custom_properties):
        property_name = documentProperties.get_custom_property_name(i)

        # Zobrazení názvů a hodnot vlastních vlastností
        property_value = [""]
        documentProperties.get_custom_property_value(property_name, property_value)
        print("Custom Property Name : " + property_name)
        print("Custom Property Value : " + property_value[0])

        # Úprava hodnot vlastních vlastností
        documentProperties.set_custom_property_value(property_name, "New Value " + str(i + 1))
    # Uložte svou prezentaci do souboru
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

`get_custom_property_value` vrací hodnotu prostřednictvím jednoprvkového seznamu předaného jako druhý argument a uložená hodnota je převedena na typ prvku, který je již v tomto seznamu. Výše uvedený příklad používá `[""]`, takže čte řetězcové vlastnosti; pro čtení vlastnosti uložené jako číslo předáte číselný zástupce, například `[0]` — v opačném případě volání vyvolá `InvalidCastException`.

## **Nastavit jazyk kontroly pravopisu**

Aspose.Slides poskytuje vlastnost `Language_Id` (vystavenou třídou [PortionFormat](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portionformat/)), která umožňuje nastavit jazyk kontroly pravopisu pro PowerPoint dokument. Jazyk kontroly pravopisu je jazyk, pro který jsou v PowerPointu kontrolovány pravopis a gramatika.

Tento Python kód ukazuje, jak nastavit jazyk kontroly pravopisu pro PowerPoint:

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

    # nastavit Id jazyka kontroly pravopisu
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **Nastavit výchozí jazyk**

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

Vyzkoušejte online aplikaci [**Aspose.Slides Metadata**](https://products.aspose.app/slides/cs/metadata) a zjistěte, jak pracovat s vlastnostmi dokumentu pomocí Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/cs/metadata)

## **Často kladené otázky**

**Jak mohu odstranit vestavěnou vlastnost z prezentace?**

Vestavěné vlastnosti jsou nedílnou součástí prezentace a nelze je zcela odstranit. Můžete je však změnit nebo nastavit na prázdnou hodnotu, pokud to konkrétní vlastnost umožňuje.

**Co se stane, když přidám vlastní vlastnost, která již existuje?**

Pokud přidáte vlastní vlastnost, která již existuje, její stávající hodnota bude přepsána novou. Nemusíte vlastnost předtím odstraňovat nebo kontrolovat, protože Aspose.Slides automaticky aktualizuje hodnotu vlastnosti.

**Mohu získat přístup k vlastnostem prezentace, aniž bych načetl celou prezentaci?**

Ano. Použijte [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationfactory/get_presentation_info/) a následně [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationinfo/read_document_properties/) k načtení uložených metadat dokumentu bez vytvoření instance [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/). Viz [Build a Lightweight Presentation Inventory](/slides/cs/python-net/examine-presentation/) pro kompletní příklad reportování a omezení specifická pro formát.