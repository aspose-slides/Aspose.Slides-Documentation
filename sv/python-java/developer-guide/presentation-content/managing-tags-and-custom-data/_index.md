---
title: Hantera taggar och anpassad data i presentationer med Python
linktitle: Taggar och anpassad data
type: docs
weight: 300
url: /sv/python-java/managing-tags-and-custom-data/
keywords:
- dokumentegenskaper
- tagg
- anpassad data
- anpassad XML
- anpassad XML-del
- XML-metadata
- ItemId
- lägg till tagg
- parvärden
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Lär dig hur du hanterar taggar och anpassad XML‑data i PowerPoint‑presentationer med Aspose.Slides för Python via Java, inklusive att lägga till, läsa, uppdatera, granska och ta bort anpassade XML‑delar."
---
## **Översikt**

Den här artikeln förklarar hur Aspose.Slides arbetar med taggar och anpassad data i PowerPoint‑presentationer. Presentationsspecifik data kan lagras som taggar eller anpassade XML‑delar. Taggar är enkla nyckel‑värde‑strängpar, medan anpassade XML‑delar kan lagra strukturerad metadata och applikationsspecifika XML‑payloads.

Aspose.Slides tillhandahåller API:er för att lägga till, läsa, uppdatera, granska och ta bort anpassade XML‑delar på presentations-, bild‑ och formnivå. Anpassade XML‑delar är användbara för integrationer som lagrar information såsom dokumenthanterings‑identifikatorer, arbetsflödes‑tillstånd, efterlevnads‑metadata, mallbindnings‑data eller annan strukturerad applikationsdata i en presentation.

## **Datainlagring i presentationsfiler**

PPTX‑filer – filer med filtillägget `.pptx` – lagras i PresentationML‑formatet, som är en del av Office Open XML‑specifikationen. Office Open XML definierar paketstrukturen och relationerna som används för att lagra presentationsinnehåll och relaterad data.

En presentation innehåller flera delar som är kopplade genom relationer. Till exempel innehåller en bilddel innehållet i en enskild bild och kan ha explicita relationer till andra delar enligt ISO/IEC 29500.

Anpassad data kan lagras som taggar ([TagCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/tagcollection/)) eller anpassade XML‑delar ([CustomXmlPartCollection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/customxmlpartcollection/)). Båda är tillgängliga via klassen [CustomData](https://reference.aspose.com/slides/sv/python-java/aspose.slides/customdata/).

{{% alert color="info" title="Obs" %}}
Taggar lagrar enkla sträng‑nyckel‑värde‑par. Anpassade XML‑delar lagrar strukturerad XML‑data och kan associeras med en presentation, bild eller form.
{{% /alert %}}

## **Arbeta med anpassade XML‑delar**

Metoden [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/sv/python-java/aspose.slides/customdata/#getCustomXmlParts) returnerar samlingen av anpassade XML‑delar som är knutna till ett specifikt presentationsobjekt. Till exempel:

- Presentationens [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/sv/python-java/aspose.slides/customdata/#getCustomXmlParts)-samling innehåller anpassade XML‑delar som är kopplade till själva presentationen.
- Bildens [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/sv/python-java/aspose.slides/customdata/#getCustomXmlParts)-samling innehåller anpassade XML‑delar som är knutna till en specifik bild.
- Formens [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/sv/python-java/aspose.slides/customdata/#getCustomXmlParts)-samling innehåller anpassade XML‑delar som är knutna till en specifik form.

Använd [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getAllCustomXmlParts) när du behöver inspektera alla anpassade XML‑delar i presentationen oavsett var de är associerade.

### **Lägg till en anpassad XML‑del i en presentation**

Använd [CustomXmlPartCollection.add](https://reference.aspose.com/slides/sv/python-java/aspose.slides/customxmlpartcollection/#add) för att lägga till XML‑data i en samling av anpassade XML‑delar. XML‑innehållet måste vara giltigt och icke‑tomt.

Följande exempel lägger till strukturerad metadata i presentationsnivåns anpassade datainsamling:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.util import UUID

presentation = Presentation()
try:
    custom_xml_content = '<?xml version="1.0" encoding="UTF-8"?><metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Draft</workflowState></metadata>'
    custom_xml_part = presentation.getCustomData().getCustomXmlParts().add(custom_xml_content)

    # add tilldelar en identifierare automatiskt. Ange ett specifikt UUID endast när det behövs.
    item_id = UUID.randomUUID()
    custom_xml_part.setItemId(item_id)

    presentation.save("presentation_with_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Metoden [add](https://reference.aspose.com/slides/sv/python-java/aspose.slides/customxmlpartcollection/#add) kan också ta emot XML som en byte‑array eller inmatningsström, vilket är praktiskt när XML‑innehållet redan finns i binär form.

### **Lägg till en anpassad XML‑del i en bild eller form**

Anpassad XML‑data kan kopplas till en specifik bild eller form istället för hela presentationen. Detta är användbart när metadata bara beskriver ett enda objekt, exempelvis en mallnyckel, extern post‑identifierare eller bindningsinformation.

Följande exempel lägger till en anpassad XML‑del i en bild och en annan i en form:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide_xml_content = '<slideMetadata xmlns="urn:example:slides"><templateKey>TitleSlide</templateKey></slideMetadata>'
    slide.getCustomData().getCustomXmlParts().add(slide_xml_content)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 250, 80)
    shape.getTextFrame().setText("Customer data")
    shape_xml_content = '<shapeMetadata xmlns="urn:example:shapes"><recordId>CRM-4281</recordId></shapeMetadata>'
    shape.getCustomData().getCustomXmlParts().add(shape_xml_content)

    presentation.save("object_custom_xml.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Nivån där en del läggs till bestämmer vilken objekts [CustomData.getCustomXmlParts](https://reference.aspose.com/slides/sv/python-java/aspose.slides/customdata/#getCustomXmlParts)-samling som innehåller relationen till den delen. Presentationsnivådata är lämplig för metadata som gäller hela dokumentet, bildnivådata för information som tillhör en viss bild och formnivådata för metadata knuten till en enskild form.

### **Lista och granska alla anpassade XML‑delar**

Använd [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getAllCustomXmlParts) för att hämta alla anpassade XML‑delar från en presentation. Varje [CustomXmlPart](https://reference.aspose.com/slides/sv/python-java/aspose.slides/customxmlpart/) visar sin identifierare, XML‑innehåll och associerade namnrymdsscheman.

Följande exempel listar alla anpassade XML‑delar och deras namnrymdsscheman:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    for custom_xml_part in presentation.getAllCustomXmlParts():
        print("ItemId:", custom_xml_part.getItemId())
        print("XML:")
        print(custom_xml_part.getXmlAsString())

        for namespace_schema in custom_xml_part.getNamespaceSchemas():
            print("Namespace schema:", namespace_schema)

        print()
finally:
    presentation.dispose()
```

[CustomXmlPart.getNamespaceSchemas](https://reference.aspose.com/slides/sv/python-java/aspose.slides/customxmlpart/#getNamespaceSchemas) returnerar XML‑scheman som är kopplade till den anpassade XML‑delen. Informationen kan vara användbar vid granskning av presentationer som innehåller XML producerad av externa system.

### **Läs och uppdatera XML‑innehåll och ItemId**

Använd [CustomXmlPart.getXmlAsString](https://reference.aspose.com/slides/sv/python-java/aspose.slides/customxmlpart/#getXmlAsString) och [setXmlAsString](https://reference.aspose.com/slides/sv/python-java/aspose.slides/customxmlpart/#setXmlAsString) för att arbeta med XML som en UTF‑8‑sträng, eller [getXmlData](https://reference.aspose.com/slides/sv/python-java/aspose.slides/customxmlpart/#getXmlData) och [setXmlData](https://reference.aspose.com/slides/sv/python-java/aspose.slides/customxmlpart/#setXmlData) för att arbeta med de råa XML‑bytena.

Metoden [CustomXmlPart.getItemId](https://reference.aspose.com/slides/sv/python-java/aspose.slides/customxmlpart/#getItemId) returnerar UUID‑värdet som identifierar den anpassade XML‑delen i Office Open XML‑dokumentet. Använd [setItemId](https://reference.aspose.com/slides/sv/python-java/aspose.slides/customxmlpart/#setItemId) när en integration kräver en ny identifierare.

Följande exempel uppdaterar XML‑innehållet och identifieraren:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.util import UUID

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getAllCustomXmlParts()
    if len(custom_xml_parts) > 0:
        custom_xml_part = custom_xml_parts[0]

        # Läs den aktuella XML som text.
        current_xml_content = custom_xml_part.getXmlAsString()
        print(current_xml_content)

        # Uppdatera XML som en UTF-8-sträng.
        custom_xml_content = '<metadata xmlns="urn:example:metadata"><documentId>DOC-1001</documentId><workflowState>Approved</workflowState></metadata>'
        custom_xml_part.setXmlAsString(custom_xml_content)

        # getXmlData tillhandahåller samma XML-innehåll som råa byte.
        custom_xml_data = custom_xml_part.getXmlData()
        print(bytes(custom_xml_data).decode("utf-8"))

        # Ersätt identifieraren när integrationen kräver det.
        item_id = UUID.randomUUID()
        custom_xml_part.setItemId(item_id)

        presentation.save("updated_custom_xml.pptx", SaveFormat.Pptx)
    else:
        print("No custom XML parts found.")
finally:
    presentation.dispose()
```

När du anropar [setXmlAsString](https://reference.aspose.com/slides/sv/python-java/aspose.slides/customxmlpart/#setXmlAsString) eller [setXmlData](https://reference.aspose.com/slides/sv/python-java/aspose.slides/customxmlpart/#setXmlData) ska du tillhandahålla giltig, icke‑tom XML. Använd antingen den ena eller den andra representationen beroende på om applikationen primärt arbetar med strängar eller byte‑data.

### **Ta bort en anpassad XML‑del**

Aspose.Slides erbjuder flera sätt att ta bort anpassad XML‑data:

- [CustomXmlPart.remove](https://reference.aspose.com/slides/sv/python-java/aspose.slides/customxmlpart/#remove) tar bort den anpassade XML‑delen från presentationen.
- [CustomXmlPartCollection.remove](https://reference.aspose.com/slides/sv/python-java/aspose.slides/customxmlpartcollection/#remove) tar bort en specifik del från en samling av anpassade XML‑delar.
- [CustomXmlPartCollection.removeAt](https://reference.aspose.com/slides/sv/python-java/aspose.slides/customxmlpartcollection/#removeAt) tar bort delen på ett angivet index i samlingen.
- [CustomXmlPartCollection.clear](https://reference.aspose.com/slides/sv/python-java/aspose.slides/customxmlpartcollection/#clear) tar bort alla delar från en specifik samling.

Följande exempel tar bort en presentationsnivå‑XML‑del med referens:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getCustomData().getCustomXmlParts()
    if custom_xml_parts.size() > 0:
        custom_xml_part = custom_xml_parts.get_Item(0)
        custom_xml_parts.remove(custom_xml_part)

    presentation.save("custom_xml_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Om du redan har en [CustomXmlPart](https://reference.aspose.com/slides/sv/python-java/aspose.slides/customxmlpart/) och vill ta bort den delen från presentationen snarare än att adressera en viss samling, anropa [CustomXmlPart.remove](https://reference.aspose.com/slides/sv/python-java/aspose.slides/customxmlpart/#remove).

Du kan också ta bort ett objekt efter index:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    custom_xml_parts = presentation.getCustomData().getCustomXmlParts()
    if custom_xml_parts.size() > 0:
        custom_xml_parts.removeAt(0)
finally:
    presentation.dispose()
```

### **Rensa alla anpassade XML‑delar från en samling**

Använd [clear](https://reference.aspose.com/slides/sv/python-java/aspose.slides/customxmlpartcollection/#clear) när alla anpassade XML‑delar som är knutna till ett specifikt presentationsobjekt ska tas bort.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.getSlides().get_Item(0).getCustomData().getCustomXmlParts().clear()

    presentation.save("slide_custom_xml_cleared.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[clear](https://reference.aspose.com/slides/sv/python-java/aspose.slides/customxmlpartcollection/#clear) påverkar endast den valda samlingen. Till exempel rensar inte en bilds samling den presentations‑ eller form‑nivå‑samlingen.

För att ta bort varje anpassad XML‑del i presentationen, iterera genom [getAllCustomXmlParts](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getAllCustomXmlParts) och ta bort varje del:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for custom_xml_part in presentation.getAllCustomXmlParts():
        custom_xml_part.remove()

    presentation.save("all_custom_xml_removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Hantera länkade eller delade anpassade XML‑delar**

I en Office Open XML‑presentation kan samma anpassade XML‑del refereras från mer än ett presentationsobjekt. Till exempel kan en befintlig fil innehålla relationer från flera bilder eller former till samma underliggande XML‑del.

En delad del bör behandlas som ett enda dataobjekt med flera referenser:

- Att uppdatera den med [setXmlAsString](https://reference.aspose.com/slides/sv/python-java/aspose.slides/customxmlpart/#setXmlAsString), [setXmlData](https://reference.aspose.com/slides/sv/python-java/aspose.slides/customxmlpart/#setXmlData) eller [setItemId](https://reference.aspose.com/slides/sv/python-java/aspose.slides/customxmlpart/#setItemId) förändrar den underliggande XML‑delen, så ändringen gäller där delen refereras.
- [getItemId](https://reference.aspose.com/slides/sv/python-java/aspose.slides/customxmlpart/#getItemId) kan användas för att identifiera samma anpassade XML‑del vid granskning av objekt‑nivå‑samlingar.
- Att ta bort en del från en specifik [getCustomXmlParts](https://reference.aspose.com/slides/sv/python-java/aspose.slides/customdata/#getCustomXmlParts)-samling tar bort den från den samlingen. Använd [CustomXmlPart.remove](https://reference.aspose.com/slides/sv/python-java/aspose.slides/customxmlpart/#remove) när själva delen ska tas bort från presentationen.
- Innan en delad del tas bort eller ersätts, inspektera objekt‑nivå‑samlingarna för att avgöra om andra bilder eller former fortfarande refererar till den.

[add](https://reference.aspose.com/slides/sv/python-java/aspose.slides/customxmlpartcollection/#add)-överkörningarna skapar en ny anpassad XML‑del från XML‑innehåll; de accepterar inte en befintlig [CustomXmlPart](https://reference.aspose.com/slides/sv/python-java/aspose.slides/customxmlpart/). Därför möts delade relationer oftast när presentationer som redan innehåller dem laddas.

Följande exempel granskar presentation‑, bild‑ och form‑samlingar efter `ItemId` och rapporterar delar som refereras från mer än ett ställe:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    references_by_item_id = {}

    def register_custom_xml_parts(owner_name, custom_xml_parts):
        for i in range(custom_xml_parts.size()):
            custom_xml_part = custom_xml_parts.get_Item(i)
            item_id = str(custom_xml_part.getItemId())
            references_by_item_id.setdefault(item_id, []).append(owner_name)

    register_custom_xml_parts("Presentation", presentation.getCustomData().getCustomXmlParts())

    for slide_index in range(presentation.getSlides().size()):
        slide = presentation.getSlides().get_Item(slide_index)
        register_custom_xml_parts(f"Slide {slide_index + 1}", slide.getCustomData().getCustomXmlParts())

        for shape_index in range(slide.getShapes().size()):
            shape = slide.getShapes().get_Item(shape_index)
            register_custom_xml_parts(f"Slide {slide_index + 1}, shape {shape_index}", shape.getCustomData().getCustomXmlParts())

    for item_id, owner_names in references_by_item_id.items():
        if len(owner_names) > 1:
            print("Shared custom XML part:", item_id)
            for owner_name in owner_names:
                print("  Referenced by:", owner_name)
finally:
    presentation.dispose()
```

Denna typ av granskning är användbar innan du modifierar eller tar bort anpassad XML‑data i presentationer som skapats av externa system, eftersom samma metadatadel kan delta i flera relationer.

## **Hämta taggvärden**

I Slides motsvarar en tagg metoden [DocumentProperties.getKeywords](https://reference.aspose.com/slides/sv/python-java/aspose.slides/documentproperties/#getKeywords). Detta exempel visar hur du hämtar ett taggvärde med Aspose.Slides för Python via Java för [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    keywords = presentation.getDocumentProperties().getKeywords()
finally:
    presentation.dispose()
```

## **Lägg till taggar i presentationer**

Aspose.Slides låter dig lägga till taggar i presentationer. En tagg består vanligtvis av två element:

- namnet på en anpassad egenskap, till exempel `MyTag`;
- värdet på den anpassade egenskapen, till exempel `My Tag Value`.

Om du behöver klassificera presentationer baserat på en specifik regel eller egenskap kan du lägga till taggar för det ändamålet. Till exempel, om du vill gruppera presentationer från nordamerikanska länder kan du skapa en nordamerikansk tagg och tilldela det relevanta landet som värde.

Detta exempel visar hur du lägger till en tagg i en [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) med Aspose.Slides för Python via Java:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation.pptx")
try:
    tags = presentation.getCustomData().getTags()
    tags.set_Item("MyTag", "My Tag Value")
finally:
    presentation.dispose()
```

Taggar kan också sättas för en [Slide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    slide.getCustomData().getTags().set_Item("tag", "value")
finally:
    presentation.dispose()
```

Eller för en enskild [Shape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50)
    shape.getTextFrame().setText("My text")
    shape.getCustomData().getTags().set_Item("tag", "value")
finally:
    presentation.dispose()
```

### **Begränsningar**

Taggar som läggs till via samlingen [CustomData.getTags](https://reference.aspose.com/slides/sv/python-java/aspose.slides/customdata/#getTags) lagras endast i PowerPoint‑filen. De **överförs inte** till PDF‑taggstrukturen när presentationen exporteras till PDF. Följaktligen kan en anpassad identifierare som lagrats som tagg inte hämtas från den taggade PDF‑filen.

**Alternativ lösning**: Du kan lagra en anpassad identifierare i objektets **Alt Text** (t.ex. [Shape.setAlternativeText](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/#setAlternativeText) med värdet `"MyId"`). Efter export till PDF kan Alt Text dyka upp i PDF‑taggstrukturen.

## **FAQ**

**Kan jag ta bort alla taggar från en presentation, bild eller form i ett enda steg?**

Ja. [tag collection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/tagcollection/) stödjer en [clear](https://reference.aspose.com/slides/sv/python-java/aspose.slides/tagcollection/#clear)-operation som raderar alla nyckel‑värde‑par på en gång.

**Hur tar jag bort en enskild tagg efter namn utan att iterera över hela samlingen?**

Använd [remove](https://reference.aspose.com/slides/sv/python-java/aspose.slides/tagcollection/#remove) på [tag collection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/tagcollection/) för att ta bort taggen via dess nyckel.

**Hur kan jag hämta den fullständiga listan med taggnamn för analys eller filtrering?**

Använd [getNamesOfTags](https://reference.aspose.com/slides/sv/python-java/aspose.slides/tagcollection/#getNamesOfTags) på [tag collection](https://reference.aspose.com/slides/sv/python-java/aspose.slides/tagcollection/); den returnerar en array med alla taggnamn.

**Hur hittar jag alla anpassade XML‑delar oavsett var de lagras?**

Använd [Presentation.getAllCustomXmlParts](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getAllCustomXmlParts) för att hämta alla anpassade XML‑delar i presentationen.

**Ska jag använda [getXmlAsString](https://reference.aspose.com/slides/sv/python-java/aspose.slides/customxmlpart/#getXmlAsString)/[setXmlAsString](https://reference.aspose.com/slides/sv/python-java/aspose.slides/customxmlpart/#setXmlAsString) eller [getXmlData](https://reference.aspose.com/slides/sv/python-java/aspose.slides/customxmlpart/#getXmlData)/[setXmlData](https://reference.aspose.com/slides/sv/python-java/aspose.slides/customxmlpart/#setXmlData) för att uppdatera en anpassad XML‑del?**

Använd [getXmlAsString](https://reference.aspose.com/slides/sv/python-java/aspose.slides/customxmlpart/#getXmlAsString) och [setXmlAsString](https://reference.aspose.com/slides/sv/python-java/aspose.slides/customxmlpart/#setXmlAsString) när applikationen arbetar med UTF‑8‑XML‑text. Använd [getXmlData](https://reference.aspose.com/slides/sv/python-java/aspose.slides/customxmlpart/#getXmlData) och [setXmlData](https://reference.aspose.com/slides/sv/python-java/aspose.slides/customxmlpart/#setXmlData) när XML redan finns som en byte‑array eller när binär hantering är mer bekväm. Båda representationerna refererar till samma anpassade XML‑parts innehåll.