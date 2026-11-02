---
title: Hantera presentationsegenskaper med Python
linktitle: Presentationsegenskaper
type: docs
weight: 70
url: /sv/python-net/presentation-properties/
keywords:
- PowerPoint-egenskaper
- presentations-egenskaper
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
description: "Behärska presentationsegenskaper i Aspose.Slides för Python via .NET och effektivisera sökning, varumärkesprofilering och arbetsflöde i dina PowerPoint-filer."
---
## **Introduktion**

Aspose.Slides för Python via .NET stöder **inbyggda** och **anpassade** dokumentegenskaper. Använd dessa egenskaper för att läsa och uppdatera presentationsmetadata, såsom författare, titel och användardefinierade värden.

Aspose.Slides låter dig arbeta med presentationsdokumentegenskaper via klassen [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) . En instans av denna klass returneras av [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/). Följande exempel visar hur man läser, modifierar och hanterar dessa egenskaper.

{{% alert color="info" title="Note" %}}
Aspose.Slides hanterar applikations- och producentmetadata när presentationer sparas; dessa fält identifierar den programvara som skapade resultatet.
{{% /alert %}}

## **Hantera presentationsegenskaper**

Dokumentegenskaper lagrar beskrivande information tillsammans med presentationsinnehållet. De delas in i två kategorier:

- **Inbyggda egenskaper** innehåller standardmetadata, såsom titel, författare och dokumentstatistik.
- **Anpassade egenskaper** lagrar användardefinierade namn/värde-par.

Aspose.Slides för Python via .NET ger åtkomst till båda kategorierna. I PowerPoint, välj **File → Info → Properties → Advanced Properties** för att inspektera dokumentmetadata. Dialogrutan grupperar information i flikar såsom **Summary**, **Statistics**, **Contents** och **Custom**. Använd fliken **Custom** för att hantera användardefinierade egenskaper.

## **Läs offentliga egenskaper från en krypterad presentation**

Ett öppningslösenord skyddar vanligtvis både presentationsinnehållet och dokumentegenskaperna. När en presentation är krypterad med [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) inställt på `False`, förblir dess dokumentegenskaper offentliga. En applikation kan då sätta [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) till `True` och läsa de offentliga metadatan utan att ange öppningslösenordet.

[LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) styr vad Aspose.Slides laddar; den dekrypterar inte något. Om egenskaperna inkluderades i krypteringen misslyckas laddning utan lösenord. Om presentationen inte är krypterad ignoreras alternativet och hela presentationen laddas.

Exemplet kräver en krypterad presentation vars dokumentegenskaper lämnades offentliga. Det verifierar laddningsläget via [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) och läser sedan inbyggda egenskaper via [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/):

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

I detta läge laddas inte bildinnehållet. Slides, masters, layouts, shapes, media och andra presentationsobjekt är otillgängliga. Applikationer bör alltid kontrollera [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) innan de utför en operation som kräver hela presentationsobjektmodellen.

{{% alert color="warning" title="Security" %}}
Offentlig metadata kan avslöja författarnamn, titlar, ämnen, nyckelord, företagsinformation, kommentarer och anpassade värden. Kryptera känsliga egenskaper tillsammans med presentationen. Lämna dem offentliga endast när indexering, klassificering, sökning eller dokumenthanteringssystem har ett specifikt krav på åtkomst utan lösenord.
{{% /alert %}}

## **Uppdatera egenskaper för en krypterad presentation**

För en krypterad PPTX‑fil är en presentation som laddas med [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) avsedd för att läsa offentlig metadata. Aspose.Slides kan inte spara ändrade egenskaper från det objektet som bara innehåller metadata eftersom de offentliga egenskaperna måste vara konsistenta med motsvarande data i den krypterade presentationen. Därför krävs rätt öppningslösenord och en fullständig laddning för att uppdatera dem.

Exemplet kräver en krypterad PPTX‑presentation med offentliga dokumentegenskaper och ett känt öppningslösenord. Det öppnar hela presentationen med [LoadOptions.password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/), uppdaterar offentliga inbyggda egenskaper och sparar resultatet. Därefter används [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/is_encrypted/) för att verifiera att krypteringen bevaras och öppnar den offentliga metadatan utan lösenord för att verifiera de nya värdena:

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

Om en applikation inte får dekryptera eller ladda presentationsinnehållet måste den behandla offentliga egenskaper i en krypterad PPTX‑fil som skrivskyddade.

## **Åtkomst till inbyggda egenskaper**

Klassen [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) exponerar inbyggd metadata via typade egenskaper, inklusive [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/) och [DocumentProperties.created_time](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/created_time/). Detta exempel öppnar en befintlig presentation och skriver dess lagrade metadata till konsolen. Värdena beror på inmatningspresentationen; vissa fält kan vara tomma.

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

## **Modifiera inbyggda egenskaper**

För att uppdatera inbyggd metadata, tilldela värden till de skrivbara egenskaper som exponeras av [Presentation.document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/document_properties/). Detta exempel öppnar en befintlig presentation, sätter [DocumentProperties.author](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/author/), [DocumentProperties.title](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/title/), [DocumentProperties.subject](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/subject/), [DocumentProperties.comments](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/comments/) och [DocumentProperties.manager](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/manager/), och sparar sedan den uppdaterade presentationen med [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). Den sparade PPTX‑filen innehåller den nya metadatan.

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

## **Hantera hyperlänksbasen**

[DocumentProperties.hyperlink_base](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/hyperlink_base/) lagrar dokumentnivåns bas för relativa hyperlänkar. Detta är användbart när en presentation och dess länkade filer flyttas till en annan plats. Det är skilt från en enskild hyperlänks [Hyperlink.external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/): att ändra basen skriver inte om de lagrade ländadresserna eller ändrar absoluta destinationer.

Exemplet kräver en presentation som innehåller både en relativ länk, t.ex. `target.html`, och en absolut länk till en fil eller webbplats. Det läser den befintliga basen, tilldelar en ny basadress och sparar samt öppnar presentationen igen för att kontrollera värdet. Därefter rensar det basen med `""` och verifierar det tomma värdet i en separat sparad fil. Ersätt exempelbasadressen med platsen för dina länkade filer.

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

De två verifieringsmeddelandena bör skriva ut `True`. Att rensa basen lämnar de individuella hyperlänkadresserna intakta.

En relativ länk till `target.pptx` öppnade `old/target.pptx` när basen pekade på mappen `old`. Efter att ha ändrat basen till mappen `new`, sparat och öppnat presentationen igen, öppnade samma länk `new/target.pptx`. En absolut länk fortsatte att öppna samma fil. Testa dina relativa länkar i PowerPoint före och efter att du flyttat presentationen eller ändrat dess bas.

## **Lägg till anpassade presentationsegenskaper**

Anpassade egenskaper lagrar metadata som saknar motsvarande inbyggt fält. Metoden [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/) låter dig tilldela ett värde via egenskapsnamn. Detta exempel skapar en presentation, lägger till två textvärden och ett heltalsversionsvärde, och sparar presentationen med [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/). Att tilldela ett värde till ett befintligt namn ersätter den egenskapens värde.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    document_properties = presentation.document_properties

    document_properties.set_custom_property_value("Reviewed by", "John Smith")
    document_properties.set_custom_property_value("Confidentiality level", "Internal")
    document_properties.set_custom_property_value("Document version", 2)

    presentation.save("CustomDocumentProperties_output.pptx", slides.export.SaveFormat.PPTX)
```

## **Åtkomst och modifiera anpassade egenskaper**

Detta exempel öppnar en presentation som innehåller anpassade egenskaper och använder [DocumentProperties.count_of_custom_properties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/count_of_custom_properties/) för att iterera över dem. [DocumentProperties.get_custom_property_name](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_name/) accepterar ett nollbaserat index och returnerar namnet som används av [DocumentProperties.set_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/set_custom_property_value/). Exemplet kräver en presentation där alla anpassade egenskaper är strängar. Det skriver ut varje ursprungligt namn och värde, ersätter varje värde med en numrerad sträng och sparar ändringarna. Om det inte finns några anpassade egenskaper gör loopen inga förändringar.

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

[DocumentProperties.get_custom_property_value](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/get_custom_property_value/) returnerar värdet via den en‑elementlista som passes som andra argument. Platshållaren måste matcha den lagrade egenskapens typ: använd `[""]` för en sträng eller `[0]` för ett heltal. En felaktig typ kastar ett `InvalidCastException`; välj platshållaren enligt ditt anpassade egenskapschema.

## **Live-exempel**

Prova den online‑appen [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) för att se hur du arbetar med dokumentegenskaper med Aspose.Slides‑API:n:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**Hur kan jag ta bort en inbyggd egenskap från en presentation?**

Inbyggda egenskaper är en integrerad del av presentationen och kan inte tas bort helt. Du kan dock ändra deras värden eller sätta dem till tomma om den specifika egenskapen tillåter det.

**Vad händer om jag lägger till en anpassad egenskap som redan finns?**

Om du lägger till en anpassad egenskap som redan finns, kommer dess befintliga värde att skrivas över med det nya. Du behöver inte ta bort eller kontrollera egenskapen i förväg, eftersom Aspose.Slides automatiskt uppdaterar egenskapens värde.

**Kan jag komma åt presentationsegenskaper utan att ladda hela presentationen?**

Ja. Använd [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/python-net/aspose.slides/presentationfactory/get_presentation_info/) och sedan [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/read_document_properties/) för att läsa lagrad dokumentmetadata utan att skapa en [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑instans. Se [Build a Lightweight Presentation Inventory](/slides/sv/python-net/examine-presentation/) för ett komplett rapporteringsexempel och format‑specifika begränsningar.

**Kan jag läsa offentliga egenskaper i en krypterad presentation utan dess öppningslösenord?**

Ja. Presentationen måste ha krypterats med [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) satt till `False`, och den måste laddas med [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/only_load_document_properties/) satt till `True`.

**Kan jag uppdatera en krypterad PPTX‑fil i enbart-dokumentegenskaper‑läge?**

Nej. Offentliga och krypterade egenskapsdata måste förbli konsistenta, så att uppdatera en krypterad PPTX‑fil kräver att hela presentationen laddas med korrekt öppningslösenord.