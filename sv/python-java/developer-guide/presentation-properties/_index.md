---
title: Hantera presentationsegenskaper i Python
linktitle: Presentations egenskaper
type: docs
weight: 70
url: /sv/python-java/presentation-properties/
keywords:
- PowerPoint‑egenskaper
- presentations‑egenskaper
- dokumentegenskaper
- inbyggda egenskaper
- anpassade egenskaper
- avancerade egenskaper
- hantera egenskaper
- modifiera egenskaper
- dokumentmetadata
- redigera metadata
- korrekturläsningsspråk
- standardspråk
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Behärska presentationsegenskaper i Aspose.Slides för Python via Java och effektivisera sökning, varumärkesbyggande och arbetsflöde i dina PowerPoint‑ och OpenDocument‑filer."
---
## **Introduktion**

Aspose.Slides stöder två typer av dokumentegenskaper: **Inbyggda** och **Anpassade**. Båda dessa egenskapstyper kan enkelt nås och hanteras med Aspose.Slides API.

Aspose.Slides låter dig arbeta med presentationsdokumentegenskaper via klassen [DocumentProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/documentproperties/) . En instans av denna klass returneras av [Presentation.getDocumentProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getDocumentProperties) . Följande exempel visar hur du läser, ändrar och hanterar dessa egenskaper.

{{% alert color="info" title="Note" %}}
Observera att fälten **Application** och **AppVersion** inte kan ändras. Aspose.Slides skriver om dem vid varje sparning, så en sparad presentation alltid rapporterar "Aspose.Slides for Java" och versionen av biblioteket som skapade den. Alla värden som skickas till [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/sv/python-java/aspose.slides/documentproperties/#setNameOfApplication) ignoreras när presentationen skrivs.
{{% /alert %}}

## **Dokumentegenskaper i PowerPoint**

Microsoft PowerPoint 2007 låter dig hantera dokumentegenskaperna för presentationsfiler. Klicka på Office‑ikonen och välj **Prepare | Properties | Advanced Properties**, som visas nedan:

|**Välja menyalternativet Avancerade egenskaper**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/ZrmuCD6.jpg)|

Efter att du har valt **Advanced Properties** visas en dialogruta där du kan hantera dokumentegenskaperna för PowerPoint‑filen:

|**Egenskapsdialog**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/LibmdQd.jpg)|

**Egenskapsdialogen** innehåller flikar som **General**, **Summary**, **Statistics**, **Contents** och **Custom**. Dessa flikar låter dig konfigurera olika typer av information om PowerPoint‑filer. Använd fliken **Custom** för att hantera anpassade egenskaper.

## **Arbeta med dokumentegenskaper med Aspose.Slides för Python via Java**

Som beskrivits tidigare stödjer Aspose.Slides för Python via Java både **Inbyggda** och **Anpassade** dokumentegenskaper. Klassen [DocumentProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/documentproperties/) representerar dokumentegenskaperna som är associerade med en presentationsfil.

Använd [Presentation.getDocumentProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getDocumentProperties) för att komma åt dessa egenskaper som beskrivs nedan.

## **Läs offentliga egenskaper från en krypterad presentation**

Ett öppningslösenord skyddar normalt både presentationsinnehåll och dokumentegenskaper. När en presentation krypteras genom att skicka `false` till [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) , förblir dess dokumentegenskaper offentliga. En applikation kan sedan skicka `true` till [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) och läsa den offentliga metadata utan att ange öppningslösenordet.

Alternativet document-properties-only styr vad Aspose.Slides laddar; det dekrypterar ingenting. Om egenskaperna var inkluderade i krypteringen misslyckas laddning utan lösenordet. Om presentationen inte är krypterad ignoreras alternativet och hela presentationen laddas.

Följande exempel verifierar laddningsläget via [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/sv/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) och läser sedan inbyggda egenskaper via [Presentation.getDocumentProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getDocumentProperties) :

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

I detta läge laddas inte bildinnehåll. Bilder, master‑bilder, layouter, former, media och andra presentationsobjekt är otillgängliga. Applikationer bör alltid kontrollera [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/sv/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) innan de utför en operation som kräver hela presentationsobjektmodellen.

{{% alert color="warning" title="Warning" %}}
Offentlig metadata kan avslöja författarnamn, titlar, ämnen, nyckelord, företagsinformation, kommentarer och anpassade värden. Kryptera känsliga egenskaper tillsammans med presentationen. Låt dem vara offentliga endast när indexering, klassificering, sökning eller dokumenthanteringssystem har ett specifikt krav på åtkomst utan lösenord.
{{% /alert %}}

## **Uppdatera egenskaper i en krypterad presentation**

För en krypterad PPTX‑fil är en presentation som laddas i dokument‑egenskaper‑endast‑läge avsedd för att läsa offentlig metadata. Aspose.Slides kan inte spara ändrade egenskaper från det metadata‑endasta objektet eftersom de offentliga egenskaperna måste förbli konsekventa med motsvarande data i den krypterade presentationen. Att uppdatera dem kräver därför rätt öppningslösenord och en fullständig laddning.

Följande exempel öppnar presentationen med [LoadOptions.setPassword](https://reference.aspose.com/slides/sv/python-java/aspose.slides/loadoptions/#setPassword) , uppdaterar offentliga inbyggda egenskaper och sparar resultatet. Det använder sedan [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationinfo/#isEncrypted) för att verifiera att krypteringen bevaras och öppnar den offentliga metadata utan lösenord för att verifiera de nya värdena:

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

Om en applikation inte har tillåtelse att dekryptera eller ladda presentationsinnehållet måste den behandla offentliga egenskaper i en krypterad PPTX‑fil som skrivskyddade.

## **Åtkomst till inbyggda egenskaper**

De inbyggda egenskaper som exponeras av [DocumentProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/documentproperties/) inkluderar: **Creator** (Författare), **Description**, **Created** (Skapelsedatum), **Modified** (Ändringsdatum), **Printed** (Senaste utskriftsdatum), **LastModifiedBy**, **Keywords**, **SharedDoc** (Delas mellan olika producenter?), **PresentationFormat**, **Subject** och **Title**.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, DocumentProperties

# Instansiera Presentation-klassen som representerar presentationen
presentation = Presentation("Presentation.pptx")
try:
    # Skapa en referens till DocumentProperties-objektet som är associerat med Presentation
    properties = presentation.getDocumentProperties()

    # Visa de inbyggda egenskaperna
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

## **Ändra inbyggda egenskaper**

Att ändra inbyggda egenskaper är lika enkelt som att komma åt dem. Använd motsvarande set‑metod för att tilldela ett nytt värde. Följande exempel ändrar inbyggda dokumentegenskaper med Aspose.Slides för Python via Java.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # Skapa en referens till DocumentProperties-objektet som är associerat med Presentation
    properties = presentation.getDocumentProperties()

    # Ställ in de inbyggda egenskaperna
    properties.setAuthor("Aspose.Slides for Python via Java")
    properties.setTitle("Modifying Presentation Properties")
    properties.setSubject("Aspose Subject")
    properties.setComments("Aspose Description")
    properties.setManager("Aspose Manager")

    # Spara presentationen till en fil
    presentation.save("DocProps.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Detta exempel ändrar de inbyggda egenskaperna i presentationen som kan visas enligt nedan:

|**Inbyggda dokumentegenskaper efter ändring**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/zz1N9de.jpg)|

## **Lägg till anpassade dokumentegenskaper**

Aspose.Slides för Python via Java låter också utvecklare lägga till anpassade dokumentegenskaper i presentationer. Exemplet nedan lägger till tre anpassade egenskaper, letar sedan upp namnet som lagras på index 2 och tar bort den egenskapen, så den sparade presentationen behåller två av dem. Anpassade egenskaper indexeras i alfabetisk ordning, inte i den ordning de lades till.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Hämtar dokumentegenskaper
    properties = presentation.getDocumentProperties()

    # Lägger till anpassade egenskaper
    properties.set_Item("New Custom", jpype.JInt(12))
    properties.set_Item("My Name", "Mudassir")
    properties.set_Item("Custom", jpype.JInt(124))

    # Hämtar egenskapsnamn på ett visst index
    property_name = properties.getCustomPropertyName(2)

    # Tar bort vald egenskap
    properties.removeCustomProperty(property_name)

    # Sparar presentationen
    presentation.save("CustomDemo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|**Anpassade dokumentegenskaper tillagda**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/HdKcxI9.png)|

## **Åtkomst till och ändra anpassade egenskaper**

Aspose.Slides för Python via Java låter också utvecklare komma åt värdena för anpassade egenskaper. Följande exempel visar hur du får åtkomst till och ändrar alla anpassade egenskaper i en presentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # Skapa en referens till DocumentProperties-objektet som är associerat med Presentation
    properties = presentation.getDocumentProperties()

    # Åtkomst till och ändra anpassade egenskaper
    for i in range(properties.getCountOfCustomProperties()):
        property_name = properties.getCustomPropertyName(i)
        # Visa namn och värden för anpassade egenskaper
        print("Custom Property Name : ", property_name)
        print("Custom Property Value : ", properties.get_Item(property_name))

        # Ändra värden för anpassade egenskaper
        properties.set_Item(property_name, f"New Value {i + 1}")

    # Spara presentationen till en fil
    presentation.save("CustomDemoModified.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Detta exempel ändrar de anpassade egenskaperna för [PPTX](https://docs.fileformat.com/presentation/pptx/) presentationen. Följande bilder visar presentationens anpassade egenskaper före och efter ändring:

|**Anpassade egenskaper före ändring**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/Ze7YHvi.jpg)|

|**Anpassade egenskaper efter ändring**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/Tofu0CL.jpg)|

## **Avancerade dokumentegenskaper**

{{% alert color="info" title="Note" %}}
Nya metoder [readDocumentProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationinfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationinfo/#updateDocumentProperties), och [writeBindedPresentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationinfo/#writeBindedPresentation) har lagts till i [PresentationInfo](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationinfo/), och beteendet för metoden [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/sv/python-java/aspose.slides/documentproperties/#setLastSavedTime) har ändrats.
{{% /alert %}}

De två nya metoderna [readDocumentProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationinfo/#readDocumentProperties) och [updateDocumentProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) har lagts till i klassen [PresentationInfo](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationinfo/) . De ger snabb åtkomst till dokumentegenskaper och låter dig ändra och uppdatera egenskaper utan att ladda hela presentationen.

Det typiska arbetsflödet för att ladda egenskaper, ändra deras värden och uppdatera dokumentet kan implementeras på följande sätt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

# Läs presentationsinformationen
presentation_info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx")

# Hämta de aktuella egenskaperna
properties = presentation_info.readDocumentProperties()

# Ange de nya värdena för fälten Author och Title
properties.setAuthor("New Author")
properties.setTitle("New Title")

# Uppdatera presentationen med de nya värdena
presentation_info.updateDocumentProperties(properties)
presentation_info.writeBindedPresentation("presentation.pptx")
```

Det finns ett annat sätt att använda egenskaper från en specifik presentation som en mall för att uppdatera egenskaper i andra presentationer:

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

En ny mall kan skapas från grunden och sedan användas för att uppdatera flera presentationer:

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

## **Ställ in korrekturläsningsspråk**

Aspose.Slides tillhandahåller metoden [PortionFormat.setLanguageId](https://reference.aspose.com/slides/sv/python-java/aspose.slides/portionformat/#setLanguageId) för att du ska kunna ange korrekturläsningsspråket för ett PowerPoint‑dokument. Korrekturläsningsspråket är det språk som stavning och grammatik i presentationen kontrolleras för.

Denna Python‑kod visar hur du ställer in korrekturläsningsspråket för en PowerPoint:

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

    portion_format.setLanguageId("zh-CN") # ange ID för korrekturläsningsspråk

    new_portion.setText("1。")
    paragraph.getPortions().add(new_portion)
finally:
    presentation.dispose()
```

## **Ställ in standardspråk**

Denna Python‑kod visar hur du ställer in standardspråket för hela en PowerPoint‑presentation:

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
    # Lägger till en rektangelform med text
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("New Text")

    # Kontrollerar språk för den första delen
    print(shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **Live‑exempel**

Prova den [**Aspose.Slides Metadata**](https://products.aspose.app/slides/sv/metadata) online‑appen för att se hur man arbetar med dokumentegenskaper via Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/sv/metadata)

## **FAQ**

**Hur kan jag ta bort en inbyggd egenskap från en presentation?**

Inbyggda egenskaper är en integrerad del av presentationen och kan inte tas bort helt. Du kan dock antingen ändra deras värden eller sätta dem till tomma om den specifika egenskapen tillåter det.

**Vad händer om jag lägger till en anpassad egenskap som redan finns?**

Om du lägger till en anpassad egenskap som redan finns, kommer dess befintliga värde att skrivas över med det nya. Du behöver inte ta bort eller kontrollera egenskapen i förväg, eftersom Aspose.Slides automatiskt uppdaterar egenskapens värde.

**Kan jag komma åt presentationsegenskaper utan att ladda hela presentationen?**

Ja. Använd [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationfactory/#getPresentationInfo) och sedan [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentationinfo/#readDocumentProperties) för att läsa lagrad dokumentmetadata utan att skapa en [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/)‑instans. Se [Build a Lightweight Presentation Inventory](/slides/sv/python-java/examine-presentation/) för ett komplett rapportexempel och format‑specifika begränsningar.

**Kan jag läsa offentliga egenskaper i en krypterad presentation utan dess öppningslösenord?**

Ja. Kryptering av dokumentegenskaper måste ha inaktiverats innan presentationen krypterades, och presentationen måste laddas i läge endast dokumentegenskaper.

**Kan jag uppdatera en krypterad PPTX‑fil i läge endast dokumentegenskaper?**

Nej. Offentlig och krypterad egendomsdata måste förbli konsekventa, så att uppdatera en krypterad PPTX‑fil kräver att hela presentationen laddas med rätt öppningslösenord.