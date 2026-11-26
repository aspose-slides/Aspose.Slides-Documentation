---
title: Spravujte vlastnosti prezentace pomocí Pythonu
linktitle: Vlastnosti prezentace
type: docs
weight: 70
url: /cs/python-net/presentation-properties/
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
- Jazyk pro korekturu
- Výchozí jazyk
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Ovládejte vlastnosti prezentace v Aspose.Slides pro Python přes .NET a zjednodušte vyhledávání, značkování a workflow ve vašich souborech PowerPoint."
---
## **Úvod**

Aspose.Slides pro Python přes .NET podporuje **vestavěné** a **vlastní** vlastnosti dokumentu. Použijte tyto vlastnosti ke čtení a aktualizaci metadat prezentace, jako je autor, název a uživatelem definované hodnoty.

Aspose.Slides vám umožňuje pracovat s vlastnostmi dokumentu prezentace prostřednictvím třídy [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) . Instance této třídy je vrácena metodou [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/). Následující příklady ukazují, jak číst, upravovat a spravovat tyto vlastnosti.

{{% alert color="info" title="Note" %}}
Aspose.Slides spravuje metadata aplikace a výrobce při ukládání prezentací; tato pole identifikují software, který výstup vytvořil.
{{% /alert %}}

## **Spravovat vlastnosti prezentace**

Vlastnosti dokumentu ukládají popisné informace vedle obsahu prezentace. Rozdělují se do dvou kategorií:

- **Vestavěné vlastnosti** obsahují standardní metadata, jako je název, autor a statistiky dokumentu.
- **Vlastní vlastnosti** ukládají páry název/hodnota definované uživatelem.

Aspose.Slides pro Python přes .NET poskytuje přístup k oběma kategoriím. V PowerPointu vyberte **File → Info → Properties → Advanced Properties** pro prohlížení metadat dokumentu. Dialog seskupuje informace do karet jako **Summary**, **Statistics**, **Contents** a **Custom**. Použijte kartu **Custom** pro správu uživatelem definovaných vlastností.

## **Číst veřejné vlastnosti z šifrované prezentace**

Obvykle ochrání otevírací heslo jak obsah prezentace, tak vlastnosti dokumentu. Když je prezentace šifrována pomocí [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) nastaveného na `False`, její vlastnosti dokumentu zůstávají veřejné. Aplikace pak může nastavit [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) na `True` a číst veřejná metadata bez zadání otevíracího hesla.

[LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) řídí, co Aspose.Slides načte; neprovádí žádné dešifrování. Pokud byly vlastnosti zahrnuty do šifrování, načtení bez hesla selže. Pokud prezentace není šifrována, volba se ignoruje a načte se celá prezentace.

Příklad vyžaduje šifrovanou prezentaci, jejíž vlastnosti dokumentu byly ponechány veřejné. Ověřuje režim načítání pomocí [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) a poté čte vestavěné vlastnosti pomocí [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.only_load_document_properties = True

with slides.Presentation("public-properties-encrypted.pptx", load_options) as presentation:
    if presentation.protection_manager.is_only_document_properties_loaded:
        document_properties = presentation.document_properties

        print("Author: " + document_properties.author)
        print("Title: " + document_properties.title)
        print("Keywords: " + document_properties.keywords)
    else:
        print("The presentation was not loaded in document-properties-only mode.")
```

V tomto režimu se nenačítá obsah snímků. Snímky, mastery, rozvržení, tvary, média a další objekty prezentace nejsou k dispozici. Aplikace by měly vždy zkontrolovat [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) před provedením operace vyžadující kompletní objektový model prezentace.

{{% alert color="warning" title="Security" %}}
Veřejná metadata mohou odhalit jména autorů, názvy, předměty, klíčová slova, informace o společnosti, komentáře a vlastní hodnoty. Šifrujte citlivé vlastnosti spolu s prezentací. Ponechte je veřejné jen tehdy, když indexovací, klasifikační, vyhledávací nebo systémy pro správu dokumentů mají konkrétní požadavek na přístup k nim bez hesla.
{{% /alert %}}

## **Aktualizovat vlastnosti šifrované prezentace**

Pro šifrovaný soubor PPTX je prezentace načtená pomocí [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) určena pro čtení veřejných metadat. Aspose.Slides nemůže uložit změněné vlastnosti z tohoto objektu obsahujícího jen metadata, protože veřejné vlastnosti musí zůstat v souladu s odpovídajícími daty uvnitř šifrované prezentace. Aktualizace proto vyžaduje správné otevírací heslo a úplné načtení.

Příklad vyžaduje šifrovanou PPTX prezentaci s veřejnými vlastnostmi dokumentu a známým otevíracím heslem. Otevře celou prezentaci pomocí [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/), aktualizuje veřejné vestavěné vlastnosti a výsledek uloží. Pak použije [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/is_encrypted/) k ověření, že šifrování zůstalo zachováno, a znovu otevře veřejná metadata bez hesla pro ověření nových hodnot:

```python
import aspose.slides as slides

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation(input_path, load_options) as presentation:
    document_properties = presentation.document_properties
    document_properties.title = "Updated Product Roadmap"
    document_properties.keywords = "roadmap, planning, indexed"
    
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

Pokud aplikaci není umožněno dešifrovat nebo načíst obsah prezentace, musí veřejné vlastnosti šifrovaného souboru PPTX považovat za pouze ke čtení.

## **Přístup k vestavěným vlastnostem**

Třída [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) zpřístupňuje vestavěná metadata prostřednictvím typovaných vlastností, včetně [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/), a [DocumentProperties.created_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/created_time/). Tento příklad otevře existující prezentaci a vypíše její uložená metadata do konzole. Hodnoty závisí na vstupní prezentaci; některá pole mohou být prázdná.

```python
import aspose.slides as slides

with slides.Presentation("AccessBuiltInProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    print("Category:", document_properties.category)
    print("Content status:", document_properties.content_status)
    print("Creation date:", document_properties.created_time)
    print("Author:", document_properties.author)
    print("Comments:", document_properties.comments)
    print("Keywords:", document_properties.keywords)
    print("Last modified by:", document_properties.last_saved_by)
    print("Manager:", document_properties.manager)
    print("Modified date:", document_properties.last_saved_time)
    print("Presentation format:", document_properties.presentation_format)
    print("Last print date:", document_properties.last_printed)
    print("Is shared between producers:", document_properties.shared_doc)
    print("Subject:", document_properties.subject)
    print("Title:", document_properties.title)
```

### **Zpráva o čísle revize a čase úprav**

Pro zjištění čísla revize a celkového času úprav pro každý soubor PPTX ve složce `presentations` použijte [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) , abyste získali jeho [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) bez načítání snímků pro úpravy. Python zobrazuje dobu jako `timedelta`, včetně počtu dnů, když zaznamenaný čas dosáhne 24 hodin.

```python
from pathlib import Path

import aspose.slides as slides

print("File | RevisionNumber | TotalEditingTime")
for path in Path("presentations").glob("*.pptx"):
    if path.is_file():
        info = slides.PresentationFactory.instance.get_presentation_info(str(path))
        properties = info.read_document_properties()
        print(f"{path.name} | {properties.revision_number} | {properties.total_editing_time}")
```

U prezentace s 1 dnem, 2 hodinami a 5 minutami zaznamenaného času úprav obsahuje zpráva následující řádek.

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1 day, 2:05:00
```

[DocumentProperties.revision_number](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/revision_number/) je zapisovatelná metadata. Jeho hodnota sama o sobě nemůže určit, kolikrát byla prezentace uložena, ani rekonstruovat historii verzí.

[DocumentProperties.total_editing_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/total_editing_time/) uvádí dobu úprav uloženou v souboru. Hodnota `0:00:00` znamená, že zaznamenaná doba je nula, i když někdo prezentaci upravoval.

## **Upravit vestavěné vlastnosti**

Pro aktualizaci vestavěných metadat přiřaďte hodnoty zapisovatelným vlastnostem zpřístupněným pomocí [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/). Tento příklad otevře existující prezentaci, nastaví [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/), [DocumentProperties.subject](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/subject/), [DocumentProperties.comments](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/comments/), a [DocumentProperties.manager](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/manager/), poté uloží aktualizovanou prezentaci pomocí [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). Uložený PPTX obsahuje nová metadata.

```python
import aspose.slides as slides

with slides.Presentation("ModifyBuiltInProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    document_properties.author = "Aspose.Slides for Python via .NET"
    document_properties.title = "Manage PowerPoint Presentation Properties"
    document_properties.subject = "Modify Built-in Properties"
    document_properties.comments = "Aspose description"
    document_properties.manager = "Aspose manager"

    presentation.save("DocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **Spravovat základní odkaz**

[DocumentProperties.hyperlink_base](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/hyperlink_base/) ukládá úroveň dokumentu jako základ pro relativní hypertextové odkazy. To je užitečné při přesunu prezentace a jejích připojených souborů na jiné místo. Je oddělené od individuálního odkazu [Hyperlink.external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/): změna základu nepřepíše uložené adresy odkazů ani nezmění absolutní cíle.

Příklad vyžaduje prezentaci obsahující jak relativní odkaz, například `target.html`, tak absolutní odkaz na soubor nebo webovou stránku. Přečte existující základ, přiřadí novou adresu základu a uloží a znovu otevře prezentaci pro kontrolu hodnoty. Poté vyčistí základ pomocí `""` a ověří prázdnou hodnotu v samostatném uloženém souboru. Nahraďte příkladovou adresu základu umístěním vašich propojených souborů.

```python
import aspose.slides as slides

with slides.Presentation("hyperlinks.pptx") as presentation:
    print("Original base:", presentation.document_properties.hyperlink_base)

    new_base = "https://example.com/new/"
    presentation.document_properties.hyperlink_base = new_base
    presentation.save("hyperlinks-updated.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlinks-updated.pptx") as updated_presentation:
    print("Base preserved:", updated_presentation.document_properties.hyperlink_base == new_base)

    updated_presentation.document_properties.hyperlink_base = ""
    updated_presentation.save("hyperlinks-cleared.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlinks-cleared.pptx") as cleared_presentation:
    print("Base cleared:", cleared_presentation.document_properties.hyperlink_base == "")
```

Dvě ověřovací zprávy by měly vytisknout `True`. Vymazání základu ponechá jednotlivé adresy hypertextových odkazů nedotčeny.

Relativní odkaz na `target.pptx` otevřel `old/target.pptx`, když základ směřoval do složky `old`. Po změně základu na složku `new`, uložení a opětovném otevření prezentace stejný odkaz otevřel `new/target.pptx`. Absolutní odkaz i nadále otevíral stejný soubor. Otestujte své relativní odkazy v PowerPointu před a po přesunu prezentace nebo změně jejího základu.

## **Přidat vlastní vlastnosti prezentace**

Vlastní vlastnosti ukládají metadata, která nemají odpovídající vestavěné pole. Metoda [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) vám umožní přiřadit hodnotu podle názvu vlastnosti. Tento příklad vytvoří prezentaci, přidá dva textové hodnoty a celočíselnou verzi, a uloží prezentaci pomocí [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). Přiřazení hodnoty k existujícímu názvu nahradí hodnotu té vlastnosti.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    document_properties = presentation.document_properties

    document_properties.set_custom_property_value("Reviewed by", "John Smith")
    document_properties.set_custom_property_value("Confidentiality level", "Internal")
    document_properties.set_custom_property_value("Document version", 2)

    presentation.save("CustomDocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **Přístup a úprava vlastních vlastností**

Tento příklad otevře prezentaci obsahující vlastní vlastnosti a použije [DocumentProperties.count_of_custom_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/count_of_custom_properties/) , aby je iteroval. [DocumentProperties.get_custom_property_name](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_name/) přijímá index od nuly a vrací název použitý metodou [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/). Příklad vyžaduje prezentaci, kde všechny vlastní vlastnosti jsou řetězce. Vytiskne každý původní název a hodnotu, nahradí každou hodnotu číslovaným řetězcem a uloží změny. Pokud nejsou žádné vlastní vlastnosti, smyčka žádné změny neprovede.

```python
import aspose.slides as slides

with slides.Presentation("AccessAndModifyProperties.pptx") as presentation:
    document_properties = presentation.document_properties

    for i in range(document_properties.count_of_custom_properties):
        property_name = document_properties.get_custom_property_name(i)
        property_value = [""]
        document_properties.get_custom_property_value(property_name, property_value)

        print("Custom property name:", property_name)
        print("Custom property value:", property_value[0])

        document_properties.set_custom_property_value(property_name, "New Value " + str(i + 1))

    presentation.save("CustomProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

[DocumentProperties.get_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_value/) vrací hodnotu přes jednoprvkový seznam předaný jako druhý argument. Zástupný znak musí odpovídat typu uložené vlastnosti: použijte `[""]` pro řetězec nebo `[0]` pro celé číslo. Nesprávný typ vyvolá `InvalidCastException`; zvolte zástupný znak podle schématu vašich vlastních vlastností.

## **Živý příklad**

Vyzkoušejte online aplikaci [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata), abyste viděli, jak pracovat s vlastnostmi dokumentu pomocí API Aspose.Slides:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **Často kladené otázky**

**Jak mohu odstranit vestavěnou vlastnost z prezentace?**

Vestavěné vlastnosti jsou nedílnou součástí prezentace a nelze je zcela odstranit. Můžete však změnit jejich hodnoty nebo je nastavit na prázdné, pokud to konkrétní vlastnost umožňuje.

**Co se stane, když přidám vlastní vlastnost, která již existuje?**

Pokud přidáte vlastní vlastnost, která již existuje, její stávající hodnota bude přepsána novou. Nemusíte vlastnost předtím odstraňovat nebo kontrolovat, protože Aspose.Slides automaticky aktualizuje její hodnotu.

**Mohu přistupovat k vlastnostem prezentace bez úplného načtení prezentace?**

Ano. Použijte [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) a poté [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/), abyste přečetli uložená metadata dokumentu, aniž byste vytvářeli instanci [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/). Viz [Build a Lightweight Presentation Inventory](/slides/cs/python-net/examine-presentation/) pro kompletní příklad reportování a omezení specifická pro formát.

**Mohu číst veřejné vlastnosti šifrované prezentace bez jejího otevíracího hesla?**

Ano. Prezentace musela být šifrována pomocí [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) nastaveného na `False` a musí být načtena s [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) nastaveným na `True`.

**Mohu aktualizovat šifrovaný soubor PPTX v režimu pouze vlastnosti dokumentu?**

Ne. Veřejná a šifrovaná data vlastností musí zůstat konzistentní, takže aktualizace šifrovaného souboru PPTX vyžaduje načtení celé prezentace se správným otevíracím heslem.