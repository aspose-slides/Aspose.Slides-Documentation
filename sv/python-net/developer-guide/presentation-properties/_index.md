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
- ändra egenskaper
- dokumentmetadata
- redigera metadata
- korrekturläsningsspråk
- standardspråk
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Behärska presentationsegenskaper i Aspose.Slides for Python via .NET och förenkla sökning, varumärkesbyggande och arbetsflöde i dina PowerPoint-filer."
---
## **Introduktion**

Aspose.Slides stöder två typer av dokumentegenskaper: **Inbyggda** och **Anpassade**. Båda dessa egenskapstyper kan enkelt nås och hanteras med Aspose.Slides API.

Aspose.Slides låter dig arbeta med presentationsdokumentegenskaper via klassen [DocumentProperties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/documentproperties/). En instans av denna klass returneras av egenskapen [Presentation.document_properties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/document_properties/). Följande exempel visar hur man läser, ändrar och hanterar dessa egenskaper.

{{% alert color="info" title="Obs" %}}
Observera att du inte kan ange värden för fälten **Application** och **Producer**, eftersom Aspose Ltd. och Aspose.Slides for Python via .NET x.x.x kommer att visas i dessa fält.
{{% /alert %}}

## **Hantera presentationsegenskaper**

Microsoft PowerPoint erbjuder en funktion för att lägga till några egenskaper i presentationsfilerna. Dessa dokumentegenskaper möjliggör att viss användbar information lagras tillsammans med dokumenten (presentationsfiler). Det finns två typer av dokumentegenskaper:

- Systemdefinierade (Inbyggda) egenskaper
- Användardefinierade (Anpassade) egenskaper

**Inbyggda** egenskaper innehåller allmän information om dokumentet såsom dokumenttitel, författarens namn, dokumentstatistik med mera. **Anpassade** egenskaper är de som definieras av användarna som **Namn/Värde**‑par, där både namn och värde bestäms av användaren. Med Aspose.Slides for Python via .NET kan utvecklare komma åt och ändra värdena för både inbyggda och anpassade egenskaper. Microsoft PowerPoint 2007 möjliggör hantering av dokumentegenskaperna för presentationsfilerna. Allt du behöver göra är att klicka på Office‑ikonen och sedan på menyalternativet **Prepare | Properties | Advanced Properties** i Microsoft PowerPoint 2007. När du har valt menyalternativet **Advanced Properties** visas en dialogruta som låter dig hantera dokumentegenskaperna för PowerPoint‑filen. I **Properties Dialog** kan du se många flikar som **General**, **Summary**, **Statistics**, **Contents** och **Custom**. Alla dessa flikar möjliggör konfiguration av olika typer av information som är relaterad till PowerPoint‑filerna. **Custom**‑fliken används för att hantera anpassade egenskaper för PowerPoint‑filerna.

## **Åtkomst till inbyggda egenskaper**
Dessa egenskaper som exponeras av **IDocumentProperties**‑objektet inkluderar: **Creator(Author)**, **Description**, **Keywords**, **Created** (Skapelsedatum), **Modified** (Ändringsdatum), **Printed** (Senaste utskriftsdatum), **LastModifiedBy**, **SharedDoc** (Delas mellan olika skapare?), **PresentationFormat**, **Subject** och **Title**.
```py
import aspose.slides as slides

# Skapa en instans av Presentation-klassen som representerar presentationen
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

Att ändra de inbyggda egenskaperna för presentationsfiler är lika enkelt som att komma åt dem. Du kan helt enkelt tilldela ett strängvärde till önskad egenskap så modifieras egenskapsvärdet. I exemplet nedan demonstreras hur vi kan ändra de inbyggda dokumentegenskaperna för presentationsfilen.
```py
import aspose.slides as slides

# Skapa en instans av Presentation-klassen som representerar Presentation
with slides.Presentation("ModifyBuiltinProperties.pptx") as presentation:
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

Aspose.Slides for Python via .NET låter också utvecklare lägga till anpassade värden för presentationsdokumentegenskaper. Exemplet nedan visar hur man anger anpassade egenskaper för en presentation.
```py
import aspose.slides as slides

# Skapa en instans av Presentation-klassen
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

Aspose.Slides for Python via .NET låter också utvecklare komma åt värdena för anpassade egenskaper. Exemplet nedan visar hur du kan komma åt och ändra alla dessa anpassade egenskaper för en presentation.
```py
import aspose.slides as slides

# Skapa en instans av Presentation-klassen som representerar PPTX
with slides.Presentation("AccessModifyingProperties.pptx") as presentation:
    # Skapa en referens till document_properties-objektet som är associerat med Presentation
    documentProperties = presentation.document_properties

    # Åtkomst och ändra anpassade egenskaper
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

`get_custom_property_value` returnerar värdet via den en‑elementlista som passerats som det andra argumentet, och det lagrade värdet kastas till typen av elementet som redan finns i den listan. Exemplet ovan använder `[""]`, så det läser strängegenskaper; för att läsa en egenskap som lagrats som ett tal, skicka en numerisk platshållare såsom `[0]` - annars kastar anropet ett `InvalidCastException`.

## **Ställ in korrekturläsningsspråk**

Aspose.Slides tillhandahåller egenskapen `Language_Id` (exponerad av klassen [PortionFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides/portionformat/)) för att låta dig ange korrekturläsningsspråket för ett PowerPoint‑dokument. Korrekturläsningsspråket är det språk som stavning och grammatik i PowerPoint kontrolleras för.

Denna Python‑kod visar hur du ställer in korrekturläsningsspråket för en PowerPoint:
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

Prova den onlinetjänst [**Aspose.Slides Metadata**](https://products.aspose.app/slides/sv/metadata) för att se hur du arbetar med dokumentegenskaper via Aspose.Slides‑API:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/sv/metadata)

## **FAQ**

**Hur kan jag ta bort en inbyggd egenskap från en presentation?**

Inbyggda egenskaper är en integrerad del av presentationen och kan inte tas bort helt. Du kan dock ändra deras värden eller sätta dem till tomma om den specifika egenskapen tillåter det.

**Vad händer om jag lägger till en anpassad egenskap som redan finns?**

Om du lägger till en anpassad egenskap som redan finns, kommer dess befintliga värde att skrivas över med det nya. Du behöver inte ta bort eller kontrollera egenskapen i förväg, eftersom Aspose.Slides automatiskt uppdaterar egenskapens värde.

**Kan jag komma åt presentationsegenskaper utan att ladda hela presentationen?**

Ja. Använd [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentationfactory/get_presentation_info/) och sedan [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentationinfo/read_document_properties/) för att läsa lagrad dokumentmetadata utan att skapa en [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)-instans. Se [Build a Lightweight Presentation Inventory](/slides/sv/python-net/examine-presentation/) för ett komplett rapportexempel och format‑specifika begränsningar.