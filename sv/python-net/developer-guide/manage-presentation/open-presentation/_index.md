---
title: Öppna presentationer i Python
linktitle: Öppna presentationer
type: docs
weight: 20
url: /sv/python-net/open-presentation/
keywords:
- öppna PowerPoint
- öppna presentation
- öppna PPTX
- öppna PPT
- öppna ODP
- ladda presentation
- ladda PPTX
- ladda PPT
- ladda ODP
- skyddad presentation
- stor presentation
- extern resurs
- binärt objekt
- Python
- Aspose.Slides
description: "Öppna PowerPoint (.pptx, .ppt) och OpenDocument (.odp) presentationer enkelt med Aspose.Slides för Python via .NET—snabbt, pålitligt, fullt utrustat."
---
## **Introduktion**

Utöver att skapa PowerPoint-presentationer från grunden låter Aspose.Slides dig även öppna befintliga presentationer. Efter att ha laddat en presentation kan du hämta information om den, redigera bildinnehåll, lägga till nya bilder, ta bort befintliga och mer.

## **Öppna presentationer**

För att öppna en befintlig presentation, skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) och skicka filens sökväg till dess konstruktor.

Följande Python‑exempel visar hur du öppnar en presentation och hämtar antalet bilder:

```python
import aspose.slides as slides

# Skapa en instans av Presentation-klassen och skicka en filsökväg till dess konstruktor.
with slides.Presentation("sample.pptx") as presentation:
    # Skriv ut det totala antalet bilder i presentationen.
    print(presentation.slides.length)
```

## **Öppna lösenordsskyddade presentationer**

När du behöver öppna en lösenordsskyddad presentation, skicka lösenordet via egenskapen [password](https://reference.aspose.com/slides/sv/python-net/aspose.slides/loadoptions/password/) för klassen [LoadOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides/loadoptions/) för att dekryptera och ladda den. Följande Python‑kod demonstrerar denna operation:

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("sample.pptx", load_options) as presentation:
    # Utför operationer på den dekrypterade presentationen.
```

## **Öppna stora presentationer**

Aspose.Slides tillhandahåller alternativ—särskilt egenskapen [blob_management_options](https://reference.aspose.com/slides/sv/python-net/aspose.slides/loadoptions/blob_management_options/) i klassen [LoadOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides/loadoptions/)—för att hjälpa dig ladda stora presentationer.

Denna Python‑kod demonstrerar hur man laddar en stor presentation (t.ex. 2 GB):

```python
import aspose.slides as slides
import os

file_path = "LargePresentation.pptx"

load_options = slides.LoadOptions()
# Välj KeepLocked-beteendet—presentationsfilen kommer att förbli låst under Presentation‑instansens livstid 
# men den behöver inte läsas in i minnet eller kopieras till en temporär fil.
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024  # 10 MB

with slides.Presentation(file_path, load_options) as presentation:
    # Den stora presentationen har laddats och kan användas, medan minnesförbrukningen förblir låg.

    # Gör ändringar i presentationen.
    presentation.slides[0].name = "Large presentation"

    # Spara presentationen till en annan fil. Minnesförbrukningen förblir låg under den här operationen.
    presentation.save("LargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # Gör inte detta! Ett I/O‑undantag kommer att kastas eftersom filen är låst tills presentationsobjektet har frigjorts.
    os.remove(file_path)

# Det är OK att göra det här. Källfilen är inte längre låst av presentationsobjektet.
os.remove(file_path)
```

{{% alert color="info" title="Info" %}}
För att kringgå vissa begränsningar vid arbete med strömmar kan Aspose.Slides kopiera en ströms innehåll. Att ladda en stor presentation från en ström gör att presentationen kopieras och kan göra laddningen långsammare. Därför rekommenderar vi starkt att du använder presentationsfilens sökväg i stället för en ström när du behöver ladda en stor presentation.

När du skapar en presentation som innehåller stora objekt (video, audio, högupplösta bilder etc.) kan du använda [BLOB management](/slides/sv/python-net/manage-blob/) för att minska minnesförbrukningen.
{{%/alert %}}

## **Ladda presentationer utan inbäddade binära objekt**

En PowerPoint-presentation kan innehålla följande typer av inbäddade binära objekt:

- VBA‑projekt (tillgängligt via [Presentation.vba_project](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/vba_project/));
- Inbäddad OLE‑objektdata (tillgängligt via [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/));
- ActiveX‑kontrollens binära data (tillgängligt via [Control.active_x_control_binary](https://reference.aspose.com/slides/sv/python-net/aspose.slides/control/active_x_control_binary/)).

Genom att använda egenskapen [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/sv/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) kan du ladda en presentation utan några inbäddade binära objekt.

Denna egenskap är användbar för att ta bort potentiellt skadligt binärt innehåll. Följande Python‑kod demonstrerar hur du laddar en presentation utan inbäddat binärt innehåll:

```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("malware.ppt", load_options) as presentation:
    # Utför operationer på presentationen.
```

## **FAQ**

**Hur kan jag avgöra att en fil är korrupt och inte kan öppnas?**

Du får ett undantag för parsning/formatvalidering under laddning. Sådana fel nämner ofta en ogiltig ZIP‑struktur eller trasiga PowerPoint‑poster.

**Vad händer om nödvändiga teckensnitt saknas vid öppning?**

Filen kommer att öppnas, men senare [rendering/export](/slides/sv/python-net/convert-presentation/) kan ersätta teckensnitt. [Configure font substitutions](/slides/sv/python-net/font-substitution/) eller [add the required fonts](/slides/sv/python-net/custom-font/) till körmiljön.

**Hur hanteras inbäddade media (video/audio) vid öppning?**

De blir tillgängliga som presentationsresurser. Om media refereras via externa sökvägar, se till att dessa sökvägar är åtkomliga i din miljö; annars kan [rendering/export](/slides/sv/python-net/convert-presentation/) utelämna media.