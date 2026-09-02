---
title: Hantera taggar och anpassad data i presentationer med Python
linktitle: Taggar och anpassad data
type: docs
weight: 300
url: /sv/python-net/managing-tags-and-custom-data/
keywords:
- dokumentegenskaper
- tagg
- anpassad data
- anpassad XML
- anpassad XML-del
- XML-metadata
- ItemId
- lägg till tagg
- värdepar
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Lär dig hur du hanterar taggar och anpassad XML‑data i PowerPoint‑presentationer med Aspose.Slides för Python via .NET, inklusive att lägga till, läsa, uppdatera, granska och ta bort anpassade XML‑delar."
---
## **Översikt**

Denna artikel förklarar hur Aspose.Slides arbetar med taggar och anpassad data i PowerPoint-presentationer. Presentationsspecifik data kan lagras som taggar eller anpassade XML-delar. Taggar är enkla nyckel‑värde‑strängpar, medan anpassade XML-delar kan lagra strukturerad metadata och program‑specifika XML‑payloads.

Aspose.Slides tillhandahåller API:er för att lägga till, läsa, uppdatera, granska och ta bort anpassade XML-delar på presentations‑, bild‑ och formnivå. Anpassade XML-delar är användbara för integrationer som lagrar information såsom dokumenthanterings‑identifierare, arbetsflödesstatus, efterlevnadsmetadata, mall‑bindningsdata eller annan strukturerad applikationsdata i en presentation.

## **Datalagring i presentationsfiler**

PPTX-filer — filer med filändelsen `.pptx` — lagras i PresentationML-formatet, som är en del av Office Open XML‑specifikationen. Office Open XML definierar paketstrukturen och relationerna som används för att lagra presentationsinnehåll och relaterad data.

En presentation innehåller flera delar som är kopplade genom relationer. Till exempel innehåller en bilddel innehållet i en enda bild och kan ha explicita relationer till andra delar enligt ISO/IEC 29500.

Anpassad data kan lagras som taggar ([TagCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/tagcollection/)) eller anpassade XML-delar ([CustomXmlPartCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/customxmlpartcollection/)). Båda är tillgängliga via klassen [`CustomData`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/customdata/) .

{{% alert color="primary" %}}
Taggar lagrar enkla sträng‑nyckel‑värde‑par. Anpassade XML-delar lagrar strukturerad XML‑data och kan associeras med en presentation, bild eller form.
{{% /alert %}}

## **Arbeta med anpassade XML-delar**

Egenskapen [`CustomData.custom_xml_parts`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/customdata/custom_xml_parts/) returnerar samlingen av anpassade XML-delar som är associerade med ett specifikt presentationsobjekt. Till exempel:

- `presentation.custom_data.custom_xml_parts` innehåller anpassade XML-delar associerade med själva presentationen.
- `slide.custom_data.custom_xml_parts` innehåller anpassade XML-delar associerade med en specifik bild.
- `shape.custom_data.custom_xml_parts` innehåller anpassade XML-delar associerade med en specifik form.

Använd [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/all_custom_xml_parts/) när du behöver inspektera alla anpassade XML-delar i presentationen oavsett var de är associerade.

### **Lägg till en anpassad XML-del till en presentation**

Använd [`CustomXmlPartCollection.add`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/customxmlpartcollection/add/) för att lägga till XML‑data i en samling av anpassade XML-delar. XML‑en måste vara giltig och icke‑tom.

Följande exempel lägger till strukturerad metadata i presentationens anpassade datainsamling:

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

    # lägga till tilldelar en identifierare automatiskt. Ställ in ett specifikt GUID endast när det krävs.
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("presentation_with_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

`add`‑metoden kan också ta emot XML som en byte‑array eller ström, vilket är användbart när XML‑innehållet redan finns i binär form.

### **Lägg till en anpassad XML-del till en bild eller form**

Anpassad XML‑data kan associeras med en specifik bild eller form istället för hela presentationen. Detta är användbart när metadata beskriver endast ett objekt, exempelvis en mallnyckel, extern postidentifierare eller bindningsinformation.

Följande exempel lägger till en anpassad XML-del till en bild och en annan till en form:

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

Den nivå där en del läggs till bestämmer vilken objekts `custom_data.custom_xml_parts`‑samling som innehåller relationen till den delen. Data på presentationsnivå är lämplig för dokumentomfattande metadata, bildnivå för information som tillhör en specifik bild, och formnivå för metadata knuten till en enskild form.

### **Lista och granska alla anpassade XML-delar**

Använd [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/all_custom_xml_parts/) för att hämta alla anpassade XML-delar från en presentation. Varje [`CustomXmlPart`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/customxmlpart/) visar sin identifierare, XML‑innehåll och associerade namnrymdsscheman.

Följande exempel listar alla anpassade XML-delar och deras namnrymdsscheman:

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

`CustomXmlPart.namespace_schemas` returnerar XML‑scheman som är associerade med den anpassade XML‑delen. Denna information kan vara användbar vid granskning av presentationer som innehåller XML producerad av externa system.

### **Läs och uppdatera XML‑innehåll och ItemId**

Använd [`CustomXmlPart.xml_as_string`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/customxmlpart/xml_as_string/) för att arbeta med XML som en UTF‑8‑sträng, eller [`CustomXmlPart.xml_data`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/customxmlpart/xml_data/) för att arbeta med de råa XML‑bytena. Båda egenskaperna kan läsas och uppdateras.

`CustomXmlPart.item_id`‑egenskapen innehåller GUID‑en som identifierar den anpassade XML‑delen i Office Open XML‑dokumentet. Den kan också ändras när en integration kräver en ny identifierare.

Följande exempel uppdaterar XML‑innehållet och identifieraren:

```py
import uuid
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_part = presentation.all_custom_xml_parts[0]

    # Läs den aktuella XML som text.
    current_xml_content = custom_xml_part.xml_as_string
    print(current_xml_content)

    # Uppdatera XML som en UTF-8-sträng.
    custom_xml_part.xml_as_string = (
        '<metadata xmlns="urn:example:metadata">'
        '<documentId>DOC-1001</documentId>'
        '<workflowState>Approved</workflowState>'
        '</metadata>'
    )

    # xml_data tillhandahåller samma XML-innehåll som råa byte.
    custom_xml_data = custom_xml_part.xml_data
    print(custom_xml_data.decode("utf-8"))

    # Byt ut identifieraren när integrationen kräver det.
    custom_xml_part.item_id = uuid.uuid4()

    presentation.save("updated_custom_xml.pptx", slides.export.SaveFormat.PPTX)
```

När du tilldelar `xml_as_string` eller `xml_data`, ange giltig, icke‑tom XML. Använd den ena representationen eller den andra beroende på om applikationen främst arbetar med strängar eller byte‑data.

### **Ta bort en anpassad XML-del**

Aspose.Slides tillhandahåller flera sätt att ta bort anpassad XML‑data:

- `CustomXmlPart.remove` tar bort den anpassade XML‑delen från presentationen.
- `CustomXmlPartCollection.remove` tar bort en specifik del från en samling av anpassade XML‑delar.
- `CustomXmlPartCollection.remove_at` tar bort delen på ett specificerat samlingsindex.
- `CustomXmlPartCollection.clear` tar bort alla delar från en specifik samling.

Följande exempel tar bort en anpassad XML-del på presentationsnivå genom referens:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    custom_xml_parts = presentation.custom_data.custom_xml_parts

    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

Om du redan har en `CustomXmlPart` och vill ta bort den delen från presentationen snarare än att adressera en specifik samling, anropa `custom_xml_part.remove()`.

Du kan också ta bort ett objekt efter index:

```py
presentation.custom_data.custom_xml_parts.remove_at(0)
```

### **Rensa alla anpassade XML-delar från en samling**

Använd `clear` när alla anpassade XML‑delar som är associerade med ett specifikt presentationsobjekt ska tas bort.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.slides[0].custom_data.custom_xml_parts.clear()

    presentation.save("slide_custom_xml_cleared.pptx", slides.export.SaveFormat.PPTX)
```

`clear` påverkar endast den valda samlingen. Till exempel rensar radering av en bilds samling inte samlingarna på presentations‑ eller formnivå.

För att ta bort varje anpassad XML‑del i presentationen, iterera genom `all_custom_xml_parts` och ta bort varje del:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for custom_xml_part in presentation.all_custom_xml_parts:
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", slides.export.SaveFormat.PPTX)
```

### **Hantera länkade eller delade anpassade XML-delar**

I en Office Open XML‑presentation kan samma anpassade XML‑del refereras från mer än ett presentationsobjekt. Till exempel kan en befintlig fil innehålla relationer från flera bilder eller former till samma underliggande anpassade XML‑del.

En delad del bör behandlas som ett datatobjekt med flera referenser:

- Uppdatering av dess `xml_as_string`, `xml_data` eller `item_id` ändrar den underliggande anpassade XML‑delen, så förändringen gäller varhelse den delen refereras.
- `item_id` kan användas för att identifiera samma anpassade XML‑del vid granskning av objektnivåsamlingar.
- Att ta bort en del från en specifik `custom_xml_parts`‑samling tar bort den från den samlingen. Använd `CustomXmlPart.remove()` när själva delen ska tas bort från presentationen.
- Innan en del tas bort eller ersätts, inspektera objektnivåsamlingarna för att avgöra om andra bilder eller former fortfarande refererar till den.

`add`‑överladdningarna skapar en ny anpassad XML‑del från XML‑innehåll; de accepterar inte en befintlig `CustomXmlPart`. Därför möts delade relationer oftast när presentationer som redan innehåller dem laddas.

Följande exempel granskar presentation‑, bild‑ och formnivå‑samlingar efter `item_id` och rapporterar delar som refereras från mer än en plats:

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

Denna typ av granskning är användbar innan anpassad XML‑data i presentationer skapade av externa system modifieras eller tas bort, eftersom samma metadata‑del kan delta i mer än en relation.

## **Hämta värden för taggar**

I Slides motsvarar en tagg egenskapen `DocumentProperties.keywords`. Detta exempel visar hur du får ett taggvärde med Aspose.Slides för Python via .NET för [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/):

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    keywords = presentation.document_properties.keywords
```

## **Lägg till taggar i presentationer**

Aspose.Slides låter dig lägga till taggar i presentationer. En tagg består vanligtvis av två element:

- namnet på en anpassad egenskap, till exempel `MyTag`;
- värdet på den anpassade egenskapen, till exempel `My Tag Value`.

Om du behöver klassificera presentationer baserat på en specifik regel eller egenskap kan du lägga till taggar för det ändamålet. Till exempel, om du vill kategorisera presentationer från Nordamerikanska länder kan du skapa en Nordamerikansk tagg och tilldela det relevanta landet som dess värde.

Detta exempel visar hur du lägger till en tagg i en [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) med Aspose.Slides för Python via .NET:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    tags = presentation.custom_data.tags
    tags.add("MyTag", "My Tag Value")
```

Taggar kan också sättas för en [Slide](https://reference.aspose.com/slides/sv/python-net/aspose.slides/slide/):

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.custom_data.tags.add("tag", "value")
```

Eller för en enskild [Shape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/):

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 10, 10, 100, 50)
    shape.text_frame.text = "My text"
    shape.custom_data.tags.add("tag", "value")
```

### **Begränsningar**

Taggar som läggs till via samlingen `custom_data.tags` lagras endast i PowerPoint‑filen. De **överförs inte** till PDF‑taggstrukturen när presentationen exporteras till PDF. Följaktligen kan en anpassad identifierare som tilldelas som en tagg inte hämtas från den taggade PDF‑filen.

**Workaround**: Du kan lagra en anpassad identifierare i objektets **Alt‑text** (till exempel `shape.alternative_text = "MyId"`). Efter export till PDF kan Alt‑texten visas i PDF‑taggstrukturen.

## **FAQ**

**Kan jag ta bort alla taggar från en presentation, bild eller form i en operation?**

Ja. [Taggsamlingen](https://reference.aspose.com/slides/sv/python-net/aspose.slides/tagcollection/) stöder en [clear](https://reference.aspose.com/slides/sv/python-net/aspose.slides/tagcollection/clear/)‑operation som tar bort alla nyckel‑värde‑par på en gång.

**Hur tar jag bort en enskild tagg efter dess namn utan att iterera över hela samlingen?**

Använd [remove(name)](https://reference.aspose.com/slides/sv/python-net/aspose.slides/tagcollection/remove/) på [TagCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/tagcollection/) för att ta bort taggen efter dess nyckel.

**Hur kan jag hämta den kompletta listan med taggnamn för analys eller filtrering?**

Använd [get_names_of_tags](https://reference.aspose.com/slides/sv/python-net/aspose.slides/tagcollection/get_names_of_tags/) på [taggsamlingen](https://reference.aspose.com/slides/sv/python-net/aspose.slides/tagcollection/); den returnerar en array med alla taggnamn.

**Hur kan jag hitta alla anpassade XML‑delar oavsett var de är lagrade?**

Använd [`Presentation.all_custom_xml_parts`](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/all_custom_xml_parts/) för att hämta alla anpassade XML‑delar i presentationen.

**Bör jag använda `xml_as_string` eller `xml_data` för att uppdatera en anpassad XML‑del?**

Använd `xml_as_string` när applikationen arbetar med UTF‑8‑XML‑text. Använd `xml_data` när XML redan finns som en byte‑array eller när binär orienterad bearbetning är mer praktisk. Båda egenskaperna representerar XML‑innehållet i samma anpassade XML‑del.