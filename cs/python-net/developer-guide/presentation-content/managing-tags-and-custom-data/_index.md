---
title: Spravovat značky a vlastní data v prezentacích s Pythonem
linktitle: Značky a vlastní data
type: docs
weight: 300
url: /cs/python-net/managing-tags-and-custom-data/
keywords:
- vlastnosti dokumentu
- značka
- vlastní data
- vlastní XML
- vlastní část XML
- metadata XML
- ItemId
- přidat značku
- párové hodnoty
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Naučte se, jak spravovat značky a vlastní XML data v prezentacích PowerPoint pomocí Aspose.Slides pro Python přes .NET, včetně přidávání, čtení, aktualizace, auditu a odstraňování vlastních XML částí."
---
## **Přehled**

Tento článek vysvětluje, jak Aspose.Slides pracuje se značkami a vlastními daty v prezentacích PowerPoint. Data specifická pro prezentaci mohou být uložena jako značky nebo vlastní XML části. Značky jsou jednoduché páry klíč‑hodnota typu řetězec, zatímco vlastní XML části mohou ukládat strukturovaná metadata a aplikací specifické XML payloady.

Aspose.Slides poskytuje rozhraní API pro přidávání, čtení, aktualizaci, auditování a odstraňování vlastních XML částí na úrovni prezentace, snímku a tvaru. Vlastní XML části jsou užitečné pro integrace, které ukládají informace, jako jsou identifikátory správy dokumentů, stav pracovního postupu, metadata shody, data vazby na šablonu nebo jiná strukturovaná aplikační data uvnitř prezentace.

## **Ukládání dat v souborech prezentace**

Soubory PPTX — soubory s příponou `.pptx` — jsou uloženy ve formátu PresentationML, který je součástí specifikace Office Open XML. Office Open XML definuje strukturu balíčku a vztahy používané k ukládání obsahu prezentace a souvisejících dat.

Prezentace obsahuje několik částí spojených vztahy. Například část snímku obsahuje obsah jednoho snímku a může mít explicitní vztahy k jiným částem definovaným podle ISO/IEC 29500.

Vlastní data mohou být uložena jako značky ([TagCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/tagcollection/)) nebo vlastní XML části ([CustomXmlPartCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/customxmlpartcollection/)). Obě jsou dostupné přes třídu [`CustomData`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/customdata/) .

{{% alert color="primary" %}}
Značky ukládají jednoduché řetězcové páry klíč‑hodnota. Vlastní XML části ukládají strukturovaná XML data a mohou být přiřazeny k prezentaci, snímku nebo tvaru.
{{% /alert %}}

## **Práce s vlastními XML částmi**

Vlastnost [`CustomData.custom_xml_parts`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/customdata/custom_xml_parts/) vrací kolekci vlastních XML částí spojených s konkrétním objektem prezentace. Například:

- `presentation.custom_data.custom_xml_parts` obsahuje vlastní XML části spojené s samotnou prezentací.
- `slide.custom_data.custom_xml_parts` obsahuje vlastní XML části spojené s konkrétním snímkem.
- `shape.custom_data.custom_xml_parts` obsahuje vlastní XML části spojené s konkrétním tvarem.

Použijte [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/all_custom_xml_parts/) když potřebujete prozkoumat všechny vlastní XML části v prezentaci bez ohledu na to, k čemu jsou přiřazeny.

### **Přidání vlastní XML části do prezentace**

Použijte [`CustomXmlPartCollection.add`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/customxmlpartcollection/add/) k přidání XML dat do kolekce vlastních XML částí. XML musí být platné a nesmí být prázdné.

Následující příklad přidává strukturovaná metadata do kolekce vlastních dat na úrovni prezentace:

```py
import uuid
import aspose.slides as slides

custom_xml_content = (
    '<?xml version="1.0" encoding="UTF-8"?>'
    '<metadata xmlns="urn:example:metadata">'
    '<documentId>DOC-1001</documentId>'
    '<workflowState>Draft</workflowState>'
    '</metadata>'
)

with slides.Presentation() as presentation:
    custom_xml_part = presentation.custom_data.custom_xml_parts.add(custom_xml_content)

    # přidání automaticky přiřadí identifikátor. Nastavte konkrétní GUID pouze v případě potřeby.
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("presentation_with_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

Metoda `add` může také přijmout XML jako pole bajtů nebo proud, což je užitečné, když je XML obsah již dostupný v binární podobě.

### **Přidání vlastní XML části do snímku nebo tvaru**

Vlastní XML data mohou být přiřazena ke konkrétnímu snímku nebo tvaru místo celé prezentace. To je užitečné, když metadata popisují jen jeden objekt, například klíč šablony, externí identifikátor záznamu nebo informace o vazbě.

Následující příklad přidává jednu vlastní XML část do snímku a další do tvaru:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    slide.custom_data.custom_xml_parts.add(
        '<slideMetadata xmlns="urn:example:slides">'
        '<templateKey>TitleSlide</templateKey>'
        '</slideMetadata>'
    )

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 250, 80)

    shape.text_frame.text = "Customer data"
    shape.custom_data.custom_xml_parts.add(
        '<shapeMetadata xmlns="urn:example:shapes">'
        '<recordId>CRM-4281</recordId>'
        '</shapeMetadata>'
    )

    presentation.save("object_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

Úroveň, na které je část přidána, určuje, ve které kolekci `custom_data.custom_xml_parts` daný objekt obsahuje vztah k této části. Data na úrovni prezentace jsou vhodná pro metadata platná pro celý dokument, data na úrovni snímku pro informace patřící konkrétnímu snímku a data na úrovni tvaru pro metadata svázaná s jednotlivým tvarem.

### **Výpis a audit všech vlastních XML částí**

Použijte [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/all_custom_xml_parts/) k načtení všech vlastních XML částí z prezentace. Každý [`CustomXmlPart`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/customxmlpart/) poskytuje svůj identifikátor, XML obsah a přidružené schémata jmenných prostorů.

Následující příklad vypisuje všechny vlastní XML části a jejich schémata jmenných prostorů:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        print("ItemId: " + str(custom_xml_part.item_id))
        print("XML:")
        print(custom_xml_part.xml_as_string)

        for namespace_schema in custom_xml_part.namespace_schemas:
            print("Namespace schema: " + namespace_schema)

        print()
```

[`CustomXmlPart.namespace_schemas`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/customxmlpart/namespace_schemas/) vrací XML schémata přidružená k vlastní XML části. Tyto informace mohou být užitečné při auditu prezentací, které obsahují XML vytvořené externími systémy.

### **Čtení a aktualizace XML obsahu a ItemId**

Použijte [`CustomXmlPart.xml_as_string`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/customxmlpart/xml_as_string/) k práci s XML jako řetězcem UTF‑8, nebo [`CustomXmlPart.xml_data`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/customxmlpart/xml_data/) k práci s čistými bajty XML. Obě vlastnosti lze číst i měnit.

Vlastnost [`CustomXmlPart.item_id`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/customxmlpart/item_id/) obsahuje GUID, který identifikuje vlastní XML část v dokumentu Office Open XML. Lze ji také změnit, pokud integrace vyžaduje nový identifikátor.

Následující příklad aktualizuje XML obsah i identifikátor:

```py
import uuid
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_part = presentation.all_custom_xml_parts[0]

    # Přečíst aktuální XML jako text.
    current_xml_content = custom_xml_part.xml_as_string
    print(current_xml_content)

    # Aktualizovat XML jako řetězec UTF-8.
    custom_xml_part.xml_as_string = (
        '<metadata xmlns="urn:example:metadata">'
        '<documentId>DOC-1001</documentId>'
        '<workflowState>Approved</workflowState>'
        '</metadata>'
    )

    # xml_data poskytuje stejný obsah XML jako surové bajty.
    custom_xml_data = custom_xml_part.xml_data
    print(custom_xml_data.decode("utf-8"))

    # Nahradit identifikátor, pokud to integrace vyžaduje.
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("updated_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

Při přiřazování `xml_as_string` nebo `xml_data` použijte platné, ne‑prázdné XML. Použijte jednu nebo druhou reprezentaci podle toho, zda aplikace pracuje hlavně s řetězci nebo s bajtovými daty.

### **Odstranění vlastní XML části**

Aspose.Slides nabízí několik způsobů, jak odstranit vlastní XML data:

- [`CustomXmlPart.remove`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/customxmlpart/remove/) odstraňuje vlastní XML část z prezentace.
- [`CustomXmlPartCollection.remove`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/customxmlpartcollection/remove/) odstraňuje konkrétní část z kolekce vlastních XML částí.
- [`CustomXmlPartCollection.remove_at`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/customxmlpartcollection/remove_at/) odstraňuje část na zadaném indexu kolekce.
- [`CustomXmlPartCollection.clear`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/customxmlpartcollection/clear/) odstraňuje všechny části z konkrétní kolekce.

Následující příklad odstraňuje jednu vlastní XML část na úrovni prezentace pomocí reference:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_parts = presentation.custom_data.custom_xml_parts

    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

Pokud již máte objekt `CustomXmlPart` a chcete odstranit tuto část z prezentace místo adresování konkrétní kolekce, zavolejte `custom_xml_part.remove()`.

Můžete také odstranit položku podle indexu:

```py
presentation.custom_data.custom_xml_parts.remove_at(0)
```

### **Vyprázdnění všech vlastních XML částí v kolekci**

Použijte `clear`, když mají být odstraněny všechny vlastní XML části spojené s konkrétním objektem prezentace.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.slides[0].custom_data.custom_xml_parts.clear()

    presentation.save("slide_custom_xml_cleared.pptx", slides.export.SaveFormat.PPTX)
```

`clear` ovlivňuje jen vybranou kolekci. Například vyprázdnění kolekce snímku nevyprázdní kolekci na úrovni prezentace ani na úrovni tvaru.

Pro odstranění všech vlastních XML částí v prezentaci iterujte přes `all_custom_xml_parts` a odstraňte každou část:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

### **Zpracování odkazovaných nebo sdílených vlastních XML částí**

V prezentaci Office Open XML může být stejná vlastní XML část odkazována z více objektů prezentace. Například existující soubor může obsahovat vztahy z několika snímků nebo tvarů na stejnou podkladovou vlastní XML část.

Sdílenou část by měl být považována za jeden datový objekt s více odkazy:

- Aktualizace `xml_as_string`, `xml_data` nebo `item_id` mění podkladovou vlastní XML část, takže změna se projeví všude, kde je část odkazována.
- `item_id` lze použít k identifikaci stejné vlastní XML části při auditu kolekcí na úrovni objektů.
- Odstranění části z konkrétní kolekce `custom_xml_parts` ji odebere jen z této kolekce. Použijte `CustomXmlPart.remove()` pokud má být část odstraněna z celé prezentace.
- Před smazáním nebo nahrazením sdílené části zkontrolujte kolekce na úrovni objektů, abyste zjistili, zda na ni stále odkazují další snímky nebo tvary.

Přetížení `add` vytváří novou vlastní XML část z XML obsahu; nepřijímá existující `CustomXmlPart`. Proto jsou sdílené vztahy nejčastěji setkávány při načítání prezentací, které je již obsahují.

Následující příklad auditu kolekcí na úrovni prezentace, snímku a tvaru podle `item_id` a výpis částí odkazovaných z více míst:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    references_by_item_id = {}

    def register_custom_xml_parts(owner_name, custom_xml_parts):
        for custom_xml_part in custom_xml_parts:
            references_by_item_id.setdefault(custom_xml_part.item_id, []).append(owner_name)

    register_custom_xml_parts("Presentation", presentation.custom_data.custom_xml_parts)

    for slide_index, slide in enumerate(presentation.slides):
        register_custom_xml_parts(
            "Slide " + str(slide_index + 1),
            slide.custom_data.custom_xml_parts
        )

        for shape_index, shape in enumerate(slide.shapes):
            register_custom_xml_parts(
                "Slide " + str(slide_index + 1) + ", shape " + str(shape_index),
                shape.custom_data.custom_xml_parts
            )

    for item_id, owner_names in references_by_item_id.items():
        if len(owner_names) > 1:
            print("Shared custom XML part: " + str(item_id))

            for owner_name in owner_names:
                print("  Referenced by: " + owner_name)
```

Tento typ auditu je užitečný před úpravou nebo smazáním vlastních XML dat v prezentacích vytvořených externími systémy, protože stejná metadata část může participovat na více vztazích.

## **Získání hodnot značek**

V Slides odpovídá značka vlastnosti `DocumentProperties.keywords`. Tento ukázkový kód ukazuje, jak získat hodnotu značky pomocí Aspose.Slides for Python via .NET pro [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/):

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    keywords = presentation.document_properties.keywords
```

## **Přidání značek do prezentací**

Aspose.Slides umožňuje přidávat značky do prezentací. Značka obvykle sestává ze dvou položek:

- název vlastní vlastnosti, například `MyTag`;
- hodnota vlastní vlastnosti, například `My Tag Value`.

Pokud potřebujete klasifikovat prezentace podle konkrétního pravidla nebo vlastnosti, můžete přidat značky pro tento účel. Například pokud chcete kategorizovat prezentace ze zemí Severní Ameriky, můžete vytvořit značku „North American“ a přiřadit jako hodnotu relevantní zemi.

Tento ukázkový kód ukazuje, jak přidat značku do [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) pomocí Aspose.Slides for Python via .NET:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    tags = presentation.custom_data.tags
    tags.add("MyTag", "My Tag Value")
```

Značky mohou být také nastaveny pro [Slide](https://reference.aspose.com/slides/cs/python-net/aspose.slides/slide/):

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.custom_data.tags.add("tag", "value")
```

Nebo pro jednotlivý [Shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/):

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **Omezení**

Značky přidané přes kolekci `custom_data.tags` jsou uloženy pouze v souboru PowerPoint. Nepřecházejí do struktury značek PDF při exportu prezentace do PDF. Proto nelze vlastní identifikátor přiřazený jako značka získat z označeného PDF.

**Řešení**: Můžete uložit vlastní identifikátor do **alternativního textu** objektu (například `shape.alternative_text = "MyId"`). Po exportu do PDF se alternativní text může objevit ve struktuře značek PDF.

## **Často kladené otázky**

**Mohu odstranit všechny značky z prezentace, snímku nebo tvaru najednou?**

Ano. Kolekce značek ([tag collection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/tagcollection/)) podporuje operaci [clear](https://reference.aspose.com/slides/cs/python-net/aspose.slides/tagcollection/clear/), která najednou odstraní všechny páry klíč‑hodnota.

**Jak smazat jednu značku podle jejího názvu bez procházení celé kolekce?**

Použijte [remove(name)](https://reference.aspose.com/slides/cs/python-net/aspose.slides/tagcollection/remove/) na [TagCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/tagcollection/) a odstraňte značku podle jejího klíče.

**Jak získat úplný seznam názvů značek pro analytiku nebo filtrování?**

Použijte [get_names_of_tags](https://reference.aspose.com/slides/cs/python-net/aspose.slides/tagcollection/get_names_of_tags/) na kolekci značek; vrátí pole se všemi názvy značek.

**Jak najít všechny vlastní XML části bez ohledu na to, kde jsou uloženy?**

Použijte [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/all_custom_xml_parts/) k načtení všech vlastních XML částí v prezentaci.

**Mám použít `xml_as_string` nebo `xml_data` k aktualizaci vlastní XML části?**

Použijte `xml_as_string`, když aplikace pracuje s textem XML v kódování UTF‑8. Použijte `xml_data`, když je XML již k dispozici jako pole bajtů nebo když je výhodnější zpracování binárních dat. Obě vlastnosti představují XML obsah téže vlastní XML části.