---
title: Hantera presentationsegenskaper i Python
linktitle: Presentationsegenskaper
type: docs
weight: 70
url: /sv/python-java/presentation-properties/
keywords:
- PowerPoint-egenskaper
- presentationsegenskaper
- dokumentegenskaper
- inbyggda egenskaper
- anpassade egenskaper
- avancerade egenskaper
- hantera egenskaper
- modifiera egenskaper
- dokumentmetadata
- redigera metadata
- korrekturspråk
- standardspråk
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Behärska presentationsegenskaper i Aspose.Slides för Python via Java och effektivisera sökning, varumärkesbyggande och arbetsflöden i dina PowerPoint- och OpenDocument-filer."
---
## **Introduktion**

Aspose.Slides för Python via Java stöder **inbyggda** och **anpassade** dokumentegenskaper. Använd dessa egenskaper för att läsa och uppdatera presentationsmetadata, såsom författare, titel och användardefinierade värden.

Aspose.Slides låter dig arbeta med presentationsdokumentegenskaper via klassen [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) . En instans av denna klass returneras av [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) . Följande exempel visar hur man läser, ändrar och hanterar dessa egenskaper.

{{% alert color="info" title="Note" %}}
Aspose.Slides hanterar applikations- och producentmetadata när presentationer sparas; dessa fält identifierar den mjukvara som skapade resultatet.
{{% /alert %}}

## **Hantera presentationsegenskaper**

Dokumentegenskaper lagrar beskrivande information ihop med presentationsinnehållet. De delas in i två kategorier:

- **Inbyggda egenskaper** innehåller standardmetadata, såsom titel, författare och dokumentstatistik.
- **Anpassade egenskaper** lagrar användardefinierade namn/värde-par.

Aspose.Slides för Python via Java ger åtkomst till båda kategorierna. I PowerPoint, välj **File → Info → Properties → Advanced Properties** för att inspektera dokumentmetadata. Dialogrutan grupperar information i flikar såsom **Summary**, **Statistics**, **Contents** och **Custom**. Använd fliken **Custom** för att hantera användardefinierade egenskaper.

## **Läs offentliga egenskaper från en krypterad presentation**

Ett öppningslösenord skyddar normalt både presentationsinnehåll och dokumentegenskaper. När en presentation krypteras efter att ha anropat [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) med `False`, förblir dess dokumentegenskaper offentliga. En applikation kan då anropa [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) med `True` och läsa de offentliga metadatan utan att ange öppningslösenordet.

[LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) styr vad Aspose.Slides laddar; den dekrypterar inget. Om egenskaperna inkluderades i krypteringen misslyckas laddning utan lösenordet. Om presentationen inte är krypterad ignoreras alternativet och hela presentationen laddas.

Exemplet kräver en krypterad presentation där dokumentegenskaperna lämnades offentliga. Det verifierar laddningsläget via [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) och läser sedan inbyggda egenskaper via [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties):

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

I detta läge laddas inte bildinnehållet. Slides, masters, layouter, former, media och andra presentationsobjekt är otillgängliga. Applikationer bör alltid kontrollera [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) innan de utför en operation som kräver hela presentationsobjektmodellen.

{{% alert color="warning" title="Warning" %}}
Offentlig metadata kan avslöja författarnamn, titlar, ämnen, nyckelord, företagsinformation, kommentarer och anpassade värden. Kryptera känsliga egenskaper tillsammans med presentationen. Lämna dem offentliga endast när indexering, klassificering, sökning eller dokumenthanteringssystem har ett specifikt krav på att komma åt dem utan ett lösenord.
{{% /alert %}}

## **Uppdatera egenskaper för en krypterad presentation**

För en krypterad PPTX-fil, en presentation som laddas efter att ha anropat [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) med `True` är avsedd för att läsa offentlig metadata. Aspose.Slides kan inte spara ändrade egenskaper från det objektet som endast innehåller metadata eftersom de offentliga egenskaperna måste vara konsistenta med motsvarande data i den krypterade presentationen. Att uppdatera dem kräver därför korrekt öppningslösenord och en fullständig laddning.

Exemplet kräver en krypterad PPTX-presentation med offentliga dokumentegenskaper och ett känt öppningslösenord. Det öppnar hela presentationen med [LoadOptions.setPassword](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setPassword), uppdaterar offentliga inbyggda egenskaper och sparar resultatet. Därefter använder det [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#isEncrypted) för att verifiera att krypteringen bevaras och öppnar den offentliga metadatan utan lösenord för att verifiera de nya värdena:

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

Om en applikation inte får dekryptera eller ladda presentationsinnehållet måste den behandla offentliga egenskaper i en krypterad PPTX-fil som skrivskyddade.

## **Åtkomst till inbyggda egenskaper**

Klassen [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) exponerar inbyggd metadata via getter‑metoder, inklusive [getAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getAuthor), [getTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getTitle) och [getCreatedTime](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCreatedTime). Detta exempel öppnar en befintlig presentation och skriver ut dess lagrade metadata till konsolen. Värdena beror på indatapresentationen; vissa fält kan vara tomma.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("AccessBuiltInProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    print("Category:", document_properties.getCategory())
    print("Content status:", document_properties.getContentStatus())
    print("Creation date:", document_properties.getCreatedTime())
    print("Author:", document_properties.getAuthor())
    print("Comments:", document_properties.getComments())
    print("Keywords:", document_properties.getKeywords())
    print("Last modified by:", document_properties.getLastSavedBy())
    print("Manager:", document_properties.getManager())
    print("Modified date:", document_properties.getLastSavedTime())
    print("Presentation format:", document_properties.getPresentationFormat())
    print("Last print date:", document_properties.getLastPrinted())
    print("Is shared between producers:", document_properties.getSharedDoc())
    print("Subject:", document_properties.getSubject())
    print("Title:", document_properties.getTitle())
finally:
    presentation.dispose()
```

### **Rapportera versionsnummer och redigeringstid**

För att rapportera en rad för varje PPTX‑fil i `presentations`‑mappen, använd [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationfactory/#getPresentationInfo) och [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#readDocumentProperties) för att läsa dess [DocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/) utan att ladda bilderna för redigering. Python via Java‑API‑et returnerar redigeringstiden i millisekunder. Exemplet formaterar den som timmar, minuter och sekunder, med en dagräkning för varaktigheter på 24 timmar eller mer.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

factory = PresentationFactory.getInstance()
print("File | RevisionNumber | TotalEditingTime")
for path in sorted(Path("presentations").glob("*.pptx")):
    if not path.is_file():
        continue

    info = factory.getPresentationInfo(str(path))
    properties = info.readDocumentProperties()
    total_seconds = int(properties.getTotalEditingTime()) // 1000
    days, remaining_seconds = divmod(total_seconds, 86400)
    hours, remaining_seconds = divmod(remaining_seconds, 3600)
    minutes, seconds = divmod(remaining_seconds, 60)
    editing_time = f"{hours:02d}:{minutes:02d}:{seconds:02d}"
    if days:
        editing_time = f"{days}.{editing_time}"

    print(f"{path.name} | {properties.getRevisionNumber()} | {editing_time}")
```

För en presentation med en registrerad redigeringstid på 1 dag, 2 timmar och 5 minuter, visar rapporten följande utskrift.

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[getRevisionNumber](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getRevisionNumber) läser ett värde som applikationer kan ändra med [setRevisionNumber](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setRevisionNumber) . Versionsnumret ensam kan inte fastställa hur många gånger presentationen har sparats eller rekonstruera dess versionshistorik.

[getTotalEditingTime](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getTotalEditingTime) läser den redigeringstid som registrerats i filen. Ett värde på `00:00:00` betyder att den lagrade varaktigheten är noll, även om någon redigerade presentationen.

## **Ändra inbyggda egenskaper**

För att uppdatera inbyggd metadata, använd setter‑metoderna på objektet som returneras av [Presentation.getDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDocumentProperties) . Detta exempel öppnar en befintlig presentation, anropar [setAuthor](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setAuthor), [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setTitle), [setSubject](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setSubject), [setComments](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setComments) och [setManager](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setManager) , och sparar sedan den uppdaterade presentationen med [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) . Den sparade PPTX-filen innehåller den nya metadatan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("ModifyBuiltInProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    document_properties.setAuthor("Aspose.Slides for Python via Java")
    document_properties.setTitle("Manage PowerPoint Presentation Properties")
    document_properties.setSubject("Modify Built-in Properties")
    document_properties.setComments("Aspose description")
    document_properties.setManager("Aspose manager")

    presentation.save("DocumentProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Hantera Hyperlänkbasen**

[DocumentProperties.getHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getHyperlinkBase) returnerar dokumentnivåns bas för relativa hyperlänkar. Använd [DocumentProperties.setHyperlinkBase](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#setHyperlinkBase) för att ändra eller rensa den. Detta är användbart när man flyttar en presentation och dess länkade filer till en annan plats. Det är separat från en enskild hyperlänks [Hyperlink.getExternalUrl](https://reference.aspose.com/slides/python-java/aspose.slides/hyperlink/#getExternalUrl) : att ändra basen skriver inte om de lagrade länkadresserna eller ändrar absoluta destinationer.

Exemplet kräver en presentation som innehåller både en relativ länk, såsom `target.html`, och en absolut länk, såsom `https://example.org/absolute.html`. Det läser den befintliga basen, tilldelar en ny basadress, och sparar och öppnar presentationen igen för att kontrollera värdet. Det rensar sedan basen med en tom sträng och verifierar det tomma värdet i en separat sparad fil. Ersätt exempelbasadressen med platsen för dina länkade filer.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("hyperlinks.pptx")
try:
    print("Original base:", presentation.getDocumentProperties().getHyperlinkBase())

    new_base = "https://example.com/new/"
    presentation.getDocumentProperties().setHyperlinkBase(new_base)
    presentation.save("hyperlinks-updated.pptx", SaveFormat.Pptx)

    updated_presentation = Presentation("hyperlinks-updated.pptx")
    try:
        print("Base preserved:", new_base == updated_presentation.getDocumentProperties().getHyperlinkBase())

        updated_presentation.getDocumentProperties().setHyperlinkBase("")
        updated_presentation.save("hyperlinks-cleared.pptx", SaveFormat.Pptx)

        cleared_presentation = Presentation("hyperlinks-cleared.pptx")
        try:
            print("Base cleared:", "" == cleared_presentation.getDocumentProperties().getHyperlinkBase())
        finally:
            cleared_presentation.dispose()
    finally:
        updated_presentation.dispose()
finally:
    presentation.dispose()
```

De två verifieringsmeddelandena bör skriva ut `True`. Att rensa basen lämnar de enskilda hyperlänkadresserna intakta.

En relativ länk till `target.pptx` öppnade `old/target.pptx` när basen pekade på `old`‑mappen. Efter att ha ändrat basen till `new`‑mappen, sparat och öppnat presentationen igen, öppnade samma länk `new/target.pptx`. En absolut länk fortsatte att öppna samma fil. Testa dina relativa länkar i PowerPoint före och efter att du flyttar presentationen eller ändrar dess bas.

## **Lägg till anpassade presentationsegenskaper**

Anpassade egenskaper lagrar metadata som inte har motsvarande inbyggt fält. Metoden [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item) låter dig tilldela ett värde via egenskapsnamn. Detta exempel skapar en presentation, lägger till två textvärden och ett heltalsversionsvärde (med `jpype.JInt` för att skicka ett Java‑heltal), och sparar presentationen med [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) . Att tilldela ett värde till ett befintligt namn ersätter egenskapens värde.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    document_properties = presentation.getDocumentProperties()

    document_properties.set_Item("Reviewed by", "John Smith")
    document_properties.set_Item("Confidentiality level", "Internal")
    document_properties.set_Item("Document version", jpype.JInt(2))

    presentation.save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Åtkomst till och ändring av anpassade egenskaper**

Detta exempel öppnar en presentation som innehåller anpassade egenskaper och använder [getCountOfCustomProperties](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCountOfCustomProperties) för att iterera över dem. [getCustomPropertyName](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#getCustomPropertyName) accepterar ett nollbaserat index och returnerar namnet som används av [DocumentProperties.set_Item](https://reference.aspose.com/slides/python-java/aspose.slides/documentproperties/#set_Item) . Exemplet skriver ut varje ursprungligt namn och värde, ersätter varje värde med en numrerad sträng oavsett dess ursprungliga typ, och sparar ändringarna. Om det inte finns några anpassade egenskaper gör loopen inga ändringar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("AccessAndModifyProperties.pptx")
try:
    document_properties = presentation.getDocumentProperties()

    for i in range(document_properties.getCountOfCustomProperties()):
        property_name = document_properties.getCustomPropertyName(i)
        property_value = document_properties.get_Item(property_name)

        print("Custom property name:", property_name)
        print("Custom property value:", property_value)

        document_properties.set_Item(property_name, f"New Value {i + 1}")

    presentation.save("CustomProperties_output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Live‑exempel**

Prova den [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) onlinetjänsten för att se hur man arbetar med dokumentegenskaper med hjälp av Aspose.Slides‑API:n:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Hur kan jag ta bort en inbyggd egenskap från en presentation?**

Inbyggda egenskaper är en integrerad del av presentationen och kan inte tas bort helt. Du kan dock antingen ändra deras värden eller sätta dem till tomma om den specifika egenskapen tillåter det.

**Vad händer om jag lägger till en anpassad egenskap som redan finns?**

Om du lägger till en anpassad egenskap som redan finns, kommer dess befintliga värde att skrivas över med det nya. Du behöver inte ta bort eller kontrollera egenskapen i förväg, eftersom Aspose.Slides automatiskt uppdaterar egenskapens värde.

**Kan jag komma åt presentationsegenskaper utan att ladda hela presentationen?**

Ja. Använd [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/python-java/aspose.slides/presentationfactory/#getPresentationInfo) och sedan [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentationinfo/#readDocumentProperties) för att läsa lagrad dokumentmetadata utan att skapa en [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)‑instans. Se [Build a Lightweight Presentation Inventory](/slides/sv/python-java/examine-presentation/) för ett komplett rapportexempel och format‑specifika begränsningar.

**Kan jag läsa offentliga egenskaper i en krypterad presentation utan dess öppningslösenord?**

Ja. Presentationen måste ha krypterats efter att ha anropat [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) med `False`, och den måste laddas efter att ha anropat [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) med `True`.

**Kan jag uppdatera en krypterad PPTX‑fil i endast‑dokumentegenskaper‑läge?**

Nej. Offentliga och krypterade egenskapsdata måste förbli konsistenta, så att uppdatera en krypterad PPTX‑fil kräver att hela presentationen laddas med korrekt öppningslösenord.