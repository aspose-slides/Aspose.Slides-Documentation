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
description: "Behärska presentationsegenskaper i Aspose.Slides for Python via .NET och förenkla sökning, varumärkesprofilering och arbetsflöde i dina PowerPoint-filer."
---
## **Introduktion**

Aspose.Slides stöder två typer av dokumentegenskaper: **Inbyggda** och **Anpassade**. Båda dessa egenskapstyper kan enkelt nås och hanteras med Aspose.Slides API.

Aspose.Slides låter dig arbeta med presentationsdokumentegenskaper via klassen [DocumentProperties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/documentproperties/) . En instans av denna klass returneras av egenskapen [Presentation.document_properties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/document_properties/) . Följande exempel visar hur man läser, ändrar och hanterar dessa egenskaper.

{{% alert color="primary" %}} 

Observera att du inte kan ange värden för fälten **Application** och **Producer**, eftersom Aspose Ltd. och Aspose.Slides for Python via .NET x.x.x kommer att visas i dessa fält.

{{% /alert %}} 

## **Hantera presentationsegenskaper**

Microsoft PowerPoint tillhandahåller en funktion för att lägga till några egenskaper i presentationsfilerna. Dessa dokumentegenskaper gör det möjligt att lagra viss användbar information tillsammans med dokumenten (presentationsfiler). Det finns två typer av dokumentegenskaper enligt följande

- Systemdefinierade (Inbyggda) egenskaper
- Användardefinierade (Anpassade) egenskaper

**Inbyggda** egenskaper innehåller allmän information om dokumentet såsom dokumenttitel, författarens namn, dokumentstatistik med mera. **Anpassade** egenskaper är de som definieras av användarna som **Name/Value**-par, där både namn och värde definieras av användaren. Med Aspose.Slides for Python via .NET kan utvecklare komma åt och ändra värdena för inbyggda egenskaper såväl som anpassade egenskaper. Microsoft PowerPoint 2007 möjliggör hantering av dokumentegenskaperna i presentationsfilerna. Allt du behöver göra är att klicka på Office‑ikonen och sedan på menyalternativet **Prepare | Properties | Advanced Properties** i Microsoft PowerPoint 2007. När du väljer menyalternativet **Advanced Properties** visas en dialogruta som låter dig hantera dokumentegenskaperna för PowerPoint‑filen. I **Properties Dialog** kan du se att det finns många flikar såsom **General, Summary, Statistics, Contents and Custom**. Alla dessa flikar möjliggör konfiguration av olika typer av information relaterad till PowerPoint‑filerna. **Custom**‑fliken används för att hantera de anpassade egenskaperna i PowerPoint‑filerna.

## **Åtkomst till inbyggda egenskaper**

Dessa egenskaper som exponeras av objektet **IDocumentProperties** inkluderar: **Creator(Author)**, **Description**, **Keywords**, **Created** (Skapandedatum), **Modified** (Ändringsdatum), **Printed** (Senast utskriven), **LastModifiedBy**, **Keywords**, **SharedDoc** (Delas mellan olika producenter?), **PresentationFormat**, **Subject** och **Title**  

```py
import aspose.slides as slides

# Instansiera Presentation-klassen som representerar presentationen
with slides.Presentation(path + "AccessBuiltin Properties.pptx") as pres:
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

Att ändra de inbyggda egenskaperna i presentationsfiler är lika enkelt som att komma åt dem. Du kan helt enkelt tilldela ett textvärde till någon önskad egenskap så ändras egenskapsvärdet. I exemplet nedan har vi demonstrerat hur vi kan ändra de inbyggda dokumentegenskaperna för presentationsfilen.

```py
import aspose.slides as slides

# Instansiera Presentation-klassen som representerar presentationen
with slides.Presentation(path + "ModifyBuiltinProperties.pptx") as presentation:
    # Skapa en referens till objektet som är associerat med Presentation
    documentProperties = presentation.document_properties

    # Ställ in de inbyggda egenskaperna
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # spara din presentation till en fil
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Lägg till anpassade presentationsegenskaper**

Aspose.Slides for Python via .NET låter även utvecklare lägga till anpassade värden för presentationsdokumentegenskaper. Ett exempel ges nedan som visar hur man anger de anpassade egenskaperna för en presentation.

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

## **Åtkomst och ändring av anpassade egenskaper**

Aspose.Slides for Python via .NET låter även utvecklare komma åt värdena för anpassade egenskaper. Ett exempel ges nedan som visar hur du kan komma åt och ändra alla dessa anpassade egenskaper för en presentation.

```py
import aspose.slides as slides

# Instansiera Presentation-klassen som representerar PPTX-filen
with slides.Presentation(path + "AccessModifyingProperties.pptx") as presentation:
    # Skapa en referens till document_properties-objektet som är associerat med presentationen
    documentProperties = presentation.document_properties

    # Åtkomst till och ändring av anpassade egenskaper
    for i in range(documentProperties.count_of_custom_properties):
        # Visa namn och värden för anpassade egenskaper
        print("Custom Property Name : " + documentProperties.get_custom_property_name(i))
        print("Custom Property Value : " + documentProperties.get_custom_property_value[documentProperties.get_custom_property_name(i)])

        # Ändra värden för anpassade egenskaper
        documentProperties.set_custom_property_value(documentProperties.get_custom_property_name(i), "New Value " + str(i + 1))
    # spara din presentation till en fil
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Ange korrekturläsningsspråk**

Aspose.Slides tillhandahåller egenskapen `Language_Id` (exponerad av klassen [PortionFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portionformat/)) för att låta dig ange korrekturläsningsspråket för ett PowerPoint‑dokument. Korrekturläsningsspråket är det språk för vilket stavning och grammatik i PowerPoint kontrolleras.

Denna Python‑kod visar hur du anger korrekturläsningsspråket för en PowerPoint:

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

    # sätt Id för ett korrekturläsningsspråk
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **Ange standardspråk**

Denna Python‑kod visar hur du anger standardspråket för en hel PowerPoint‑presentation:

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

Prova den online‑app [**Aspose.Slides Metadata**](https://products.aspose.app/slides/sv/metadata) för att se hur man arbetar med dokumentegenskaper via Aspose.Slides‑API:

[![Visa och redigera PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/sv/metadata)

## **Vanliga frågor**

**Hur kan jag ta bort en inbyggd egenskap från en presentation?**

Inbyggda egenskaper är en integrerad del av presentationen och kan inte tas bort helt. Du kan dock ändra deras värden eller sätta dem till tomma om den specifika egenskapen tillåter det.

**Vad händer om jag lägger till en anpassad egenskap som redan finns?**

Om du lägger till en anpassad egenskap som redan finns, kommer dess befintliga värde att skrivas över med det nya. Du behöver inte ta bort eller kontrollera egenskapen i förväg, eftersom Aspose.Slides automatiskt uppdaterar egenskapens värde.

**Kan jag komma åt presentationsegenskaper utan att ladda hela presentationen?**

Ja, du kan komma åt presentationsegenskaper utan att ladda hela presentationen genom att använda metoden [get_presentation_info](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentationfactory/get_presentation_info/) från klassen [PresentationFactory](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentationfactory/). Använd sedan metoden [read_document_properties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentationinfo/read_document_properties/) som tillhandahålls av klassen [PresentationInfo](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentationinfo/) för att läsa egenskaperna effektivt, spara minne och förbättra prestanda.