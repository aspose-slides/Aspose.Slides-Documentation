---
title: Hantera presentationsegenskaper med Python
linktitle: Presentationsegenskaper
type: docs
weight: 70
url: /sv/python-net/presentation-properties/
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
- korrekturläsningsspråk
- standardspråk
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Behärska presentationsegenskaper i Aspose.Slides for Python via .NET och effektivisera sökning, varumärkesprofilering och arbetsflöde i dina PowerPoint-filer."
---
## **Introduktion**

Aspose.Slides stöder två typer av dokumentegenskaper: **Inbyggda** och **Anpassade**. Båda dessa egenskapstyper kan enkelt nås och hanteras med Aspose.Slides API.

Aspose.Slides låter dig arbeta med presentationsdokumentegenskaper via klassen [DocumentProperties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/documentproperties/) . En instans av denna klass returneras av egenskapen [Presentation.document_properties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/document_properties/) . Följande exempel visar hur du läser, ändrar och hanterar dessa egenskaper.

{{% alert color="info" title="Note" %}}
Observera att du inte kan ange värden för fälten **Application** och **Producer**, eftersom Aspose Ltd. och Aspose.Slides for Python via .NET x.x.x kommer att visas i dessa fält.
{{% /alert %}} 

## **Hantera presentationsegenskaper**

Microsoft PowerPoint erbjuder en funktion för att lägga till vissa egenskaper i presentationsfilerna. Dessa dokumentegenskaper gör det möjligt att lagra användbar information tillsammans med dokumenten (presentationsfiler). Det finns två typer av dokumentegenskaper enligt följande

- Systemdefinierade (Inbyggda) egenskaper
- Användardefinierade (Anpassade) egenskaper

**Inbyggda** egenskaper innehåller generell information om dokumentet såsom dokumenttitel, författarens namn, dokumentstatistik med mera. **Anpassade** egenskaper är de som definieras av användarna som **Namn/Värde**‑par, där både namn och värde bestäms av användaren. Med Aspose.Slides for Python via .NET kan utvecklare komma åt och ändra både inbyggda och anpassade egenskaper. Microsoft PowerPoint 2007 möjliggör hantering av dokumentegenskaper i presentationsfiler. Allt du behöver göra är att klicka på Office‑ikonen och sedan **Prepare | Properties | Advanced Properties** i Microsoft PowerPoint 2007. När du väljer menyalternativet **Advanced Properties** visas en dialog som låter dig hantera dokumentegenskaperna i PowerPoint‑filen. I **Properties Dialog** kan du se flera flikar såsom **General, Summary, Statistics, Contents and Custom**. Alla dessa flikar låter dig konfigurera olika typer av information relaterad till PowerPoint‑filerna. Fliken **Custom** används för att hantera anpassade egenskaper i PowerPoint‑filerna.

## **Läs offentliga egenskaper från en krypterad presentation**

Ett öppningslösenord skyddar normalt både presentationsinnehåll och dokumentegenskaper. När en presentation krypteras med [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) satt till `False` förblir dokumentegenskaperna offentliga. En applikation kan då sätta [LoadOptions.only_load_document_properties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/loadoptions/only_load_document_properties/) till `True` och läsa de offentliga metadatat utan att ange öppningslösenordet.

`only_load_document_properties` styr vad Aspose.Slides laddar; det dekrypterar ingenting. Om egenskaperna inkluderades i krypteringen misslyckas inläsning utan lösenord. Om presentationen inte är krypterad ignoreras alternativet och hela presentationen laddas.

Följande exempel verifierar laddningsläget via [ProtectionManager.is_only_document_properties_loaded](https://reference.aspose.com/slides/sv/python-net/aspose.slides/protectionmanager/is_only_document_properties_loaded/) och läser sedan inbyggda egenskaper via [Presentation.document_properties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/document_properties/) :

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

I detta läge laddas inte bildinnehållet. Bilder, mästar‑layout, layouter, former, media och andra presentationsobjekt är otillgängliga. Applikationer bör alltid kontrollera `is_only_document_properties_loaded` innan de utför en operation som kräver hela presentationsobjektmodellen.

{{% alert color="warning" title="Security" %}}
Offentliga metadata kan avslöja författarnamn, titlar, ämnen, nyckelord, företagsinformation, kommentarer och anpassade värden. Kryptera känsliga egenskaper tillsammans med presentationen. Lämna dem offentliga endast när indexering, klassificering, sökning eller dokumenthanteringssystem har ett specifikt krav på åtkomst utan lösenord.
{{% /alert %}}

## **Uppdatera egenskaper för en krypterad presentation**

För en krypterad PPTX‑fil är en presentation som laddas med `only_load_document_properties` avsedd för att läsa offentliga metadata. Aspose.Slides kan inte spara ändrade egenskaper från ett sådant metadata‑endast‑objekt eftersom de offentliga egenskaperna måste vara konsistenta med motsvarande data i den krypterade presentationen. Uppdatering kräver därför rätt öppningslösenord och en fullständig laddning.

Följande exempel öppnar presentationen med [LoadOptions.password](https://reference.aspose.com/slides/sv/python-net/aspose.slides/loadoptions/password/) , uppdaterar offentliga inbyggda egenskaper och sparar resultatet. Därefter används [PresentationInfo.is_encrypted](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentationinfo/is_encrypted/) för att verifiera att krypteringen bevaras och de offentliga metadata öppnas igen utan lösenord för att verifiera de nya värdena:

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

Om en applikation inte har tillåtelse att dekryptera eller ladda presentationsinnehållet måste den behandla offentliga egenskaper i en krypterad PPTX‑fil som skrivskyddade.

## **Åtkomst till inbyggda egenskaper**
Dessa egenskaper som exponeras av objektet **IDocumentProperties** inkluderar: **Creator(Author)**, **Description**, **Keywords**, **Created** (Skapelsedatum), **Modified** (Ändringsdatum), **Printed** (Senaste utskriftsdatum), **LastModifiedBy**, **Keywords**, **SharedDoc** (Delas mellan olika producenter?), **PresentationFormat**, **Subject** och **Title**
```py
import aspose.slides as slides

# Instansiera Presentation-klassen som representerar presentationen
with slides.Presentation("AccessBuiltin Properties.pptx") as pres:
    # Skapa en referens till objektet som är associerat med Presentation
    documentProperties = pres.document_properties

    # Visa de inbyggda egenskaperna
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

## **Ändra inbyggda egenskaper**

Att ändra de inbyggda egenskaperna i presentationsfiler är lika enkelt som att komma åt dem. Du kan helt enkelt tilldela ett strängvärde till önskad egenskap så ändras egenskapsvärdet. I exemplet nedan har vi demonstrerat hur vi kan ändra de inbyggda dokumentegenskaperna i presentationsfilen.

```py
import aspose.slides as slides

# Instansiera Presentation-klassen som representerar presentationen
with slides.Presentation("ModifyBuiltinProperties.pptx") as presentation:
    # Skapa en referens till objektet som är associerat med Presentation
    documentProperties = presentation.document_properties

    # Ange de inbyggda egenskaperna
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # Spara presentationen till en fil
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Lägg till anpassade presentationsegenskaper**

Aspose.Slides for Python via .NET låter också utvecklare lägga till anpassade värden för presentationsdokumentegenskaper. Ett exempel visas nedan som visar hur man sätter anpassade egenskaper för en presentation.

```py
import aspose.slides as slides

# Instansiera Presentation-klassen
with slides.Presentation() as presentation:
    # Hämtar dokumentegenskaper
    documentProperties = presentation.document_properties

    # Lägger till anpassade egenskaper
    documentProperties.set_custom_property_value("New Custom", 12)
    documentProperties.set_custom_property_value("My Nam", "Mudassir")
    documentProperties.set_custom_property_value("Custom", 124)

    # Hämtar egenskapsnamn på ett specifikt index
    getPropertyName = documentProperties.get_custom_property_name(2)

    # Tar bort vald egenskap
    documentProperties.remove_custom_property(getPropertyName)

    # Sparar presentationen
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Åtkomst till och ändra anpassade egenskaper**

Aspose.Slides for Python via .NET låter även utvecklare komma åt värdena för anpassade egenskaper. Ett exempel visas nedan som visar hur du kan komma åt och ändra alla dessa anpassade egenskaper för en presentation.

```py
import aspose.slides as slides

# Instansiera Presentation-klassen som representerar PPTX
with slides.Presentation("AccessModifyingProperties.pptx") as presentation:
    # Skapa en referens till document_properties-objektet som är associerat med Presentation
    documentProperties = presentation.document_properties

    # Åtkomst till och ändring av anpassade egenskaper
    for i in range(documentProperties.count_of_custom_properties):
        property_name = documentProperties.get_custom_property_name(i)

        # Visa namn och värden för anpassade egenskaper
        property_value = [""]
        documentProperties.get_custom_property_value(property_name, property_value)
        print("Custom Property Name : " + property_name)
        print("Custom Property Value : " + property_value[0])

        # Ändra värden för anpassade egenskaper
        documentProperties.set_custom_property_value(property_name, "New Value " + str(i + 1))
    # Spara presentationen till en fil
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

`get_custom_property_value` returnerar värdet via den enkla listan som skickas som andra argument, och det lagrade värdet kastas till typen av elementet som redan finns i listan. Exemplet ovan använder `[""]`, så det läser strängegenskaper; för att läsa en egenskap som lagrats som ett tal, skicka en numerisk platshållare såsom `[0]` — annars kastas ett `InvalidCastException`.

## **Ställ in korrekturläsningsspråk**

Aspose.Slides tillhandahåller egenskapen `Language_Id` (exponerad av klassen [PortionFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portionformat/) ) för att låta dig ange korrekturläsningsspråket för ett PowerPoint‑dokument. Korrekturläsningsspråket är språket som stavning och grammatik kontrolleras för i PowerPoint.

Denna Python‑kod visar hur du anger korrekturläsningsspråket för ett PowerPoint‑dokument:

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

    # ange Id för ett korrekturläsningsspråk
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **Ställ in standardspråk**

Denna Python‑kod visar hur du anger standardspråket för hela en PowerPoint‑presentation:

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

## **Live‑exempel**

Prova [**Aspose.Slides Metadata**](https://products.aspose.app/slides/sv/metadata) online‑app för att se hur du arbetar med dokumentegenskaper via Aspose.Slides API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/sv/metadata)

## **FAQ**

**Hur kan jag ta bort en inbyggd egenskap från en presentation?**

Inbyggda egenskaper är en integrerad del av presentationen och kan inte tas bort helt. Du kan dock ändra deras värden eller sätta dem till tomma om den specifika egenskapen tillåter det.

**Vad händer om jag lägger till en anpassad egenskap som redan finns?**

Om du lägger till en anpassad egenskap som redan finns, kommer dess befintliga värde att skrivas över med det nya. Du behöver inte ta bort eller kontrollera egenskapen i förväg, eftersom Aspose.Slides automatiskt uppdaterar egenskapens värde.

**Kan jag komma åt presentationsegenskaper utan att ladda presentationen helt?**

Ja. Använd [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentationfactory/get_presentation_info/) och sedan [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentationinfo/read_document_properties/) för att läsa lagrade dokumentmetadata utan att skapa en [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)‑instans. Se [Build a Lightweight Presentation Inventory](/slides/sv/python-net/examine-presentation/) för ett komplett exempel på rapportering och format‑specifika begränsningar.

**Kan jag läsa offentliga egenskaper i en krypterad presentation utan dess öppningslösenord?**

Ja. Presentationen måste ha krypterats med `encrypt_document_properties` satt till `False`, och den måste laddas med `only_load_document_properties` satt till `True`.

**Kan jag uppdatera en krypterad PPTX‑fil i läge som endast läser dokumentegenskaper?**

Nej. Offentliga och krypterade egenskapsdata måste förbli konsistenta, så uppdatering av en krypterad PPTX‑fil kräver att hela presentationen laddas med rätt öppningslösenord.