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
description: "Lär dig hur du öppnar PowerPoint- och OpenDocument-presentationer i Python, anger öppningslösenord och minskar minnesanvändning med Aspose.Slides for Python via .NET."
---
## **Introduktion**

[Aspose.Slides for Python via .NET](https://products.aspose.com/slides/sv/python-net/) kan läsa in PowerPoint- och OpenDocument-presentationer från filer och strömmar. När en presentation har lästs in kan du inspektera dess struktur, redigera bildspel, hantera resurser och spara den i originalformatet eller ett annat stödd format.

Inläsningsbeteendet kan anpassas via klassen [LoadOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides/loadoptions/). Till exempel kan du ange ett öppningslösenord, hålla stora binära objekt utanför minnet eller utelämna inbäddade binära data.

## **Öppna presentationer**

För att öppna en befintlig presentation, skicka dess filsökväg till konstruktorn [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/). Använd ett `with`-statement så att filhandtag, temporära data och andra resurser frigörs omedelbart.

Följande Python‑exempel visar hur man öppnar en presentation och får antalet bilder:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

## **Öppna lösenordsskyddade presentationer**

Ett öppningslösenord krypterar presentationsinnehållet. För att läsa in hela presentationen, tilldela rätt lösenord till [LoadOptions.password](https://reference.aspose.com/slides/sv/python-net/aspose.slides/loadoptions/password/) och skicka alternativen till konstruktorn [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/). Inläsningen misslyckas när lösenordet saknas eller är felaktigt.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-presentation.pptx", load_options) as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

För lösenorddetektering, validering och krypteringsarbetsflöden, se [Lösenordsskydda presentationer](/slides/sv/python-net/password-protected-presentation/). Om en krypterad presentation medvetet sparades med offentliga dokumentegenskaper, kan dessa egenskaper läsas utan lösenord; se [Hantera presentationsegenskaper](/slides/sv/python-net/presentation-properties/).

## **Öppna stora presentationer**

[LoadOptions.blob_management_options](https://reference.aspose.com/slides/sv/python-net/aspose.slides/loadoptions/blob_management_options/) styr hur Aspose.Slides hanterar binära stora objekt såsom bilder, ljud och video. Du kan hålla källfilen låst, tillåta temporära filer och begränsa mängden BLOB‑data som behålls i minnet.

Denna Python‑kod demonstrerar hur man läser in en stor presentation (t.ex. 2 GB):

```python
import aspose.slides as slides
file_path = "large-presentation.pptx"

load_options = slides.LoadOptions()
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024

with slides.Presentation(file_path, load_options) as presentation:
    presentation.slides[0].name = "Large presentation"
    presentation.save("large-presentation-copy.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="info" title="Obs" %}}

Med `PresentationLockingBehavior.KEEP_LOCKED` förblir källfilen låst tills `Presentation`‑objektet har frigjorts. Flytta, skriv över eller ta inte bort källfilen medan det objektet är aktivt.

Aspose.Slides kan kopiera innehållet i en inmatningsström under inläsning. För stora presentationer är en filsökväg därför generellt mer effektiv än en ström. Se [Hantera BLOB‑objekt](/slides/sv/python-net/manage-blob/) för ytterligare lagrings- och minneshanteringsalternativ.

{{% /alert %}}

## **Läs in presentationer utan inbäddade binära objekt**

En presentation kan innehålla inbäddade binära data som en applikation inte behöver eller inte vill behålla. Exempel inkluderar:

- VBA‑projekt, tillgängliga via [Presentation.vba_project](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/vba_project/);
- inbäddad OLE‑data, tillgänglig via [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/);
- ActiveX‑kontrolldata, tillgänglig via [Control.active_x_control_binary](https://reference.aspose.com/slides/sv/python-net/aspose.slides/control/active_x_control_binary/).

Ställ in [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/sv/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) till `True` för att ta bort dessa binära data under inläsning. Spara den inlästa presentationen för att behålla det sanerade resultatet.

Detta alternativ minskar exponeringen för oönskade inbäddade payloads, men det är inte ett fullständigt malware‑detekterings‑ eller innehållssaniteringssystem.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("presentation-with-embedded-data.pptx", load_options) as presentation:
    presentation.save("presentation-without-embedded-data.pptx", slides.export.SaveFormat.PPTX)
```

## **Vanliga frågor**

**Hur kan jag avgöra att en fil är korrupt och inte kan öppnas?**

Aspose.Slides kastar ett pars‑ eller formatfel under inläsning. Hantera detta fel separat från ett felaktigt lösenord så att applikationen kan rapportera orsaken korrekt.

**Vad händer om nödvändiga teckensnitt saknas?**

Presentationen kan fortfarande läsas in, men rendering och export kan ersätta teckensnitt. Du kan [konfigurera teckensnittsersättning](/slides/sv/python-net/font-substitution/) eller [tillhandahålla anpassade teckensnitt](/slides/sv/python-net/custom-font/) för att göra output mer förutsägbar.

**Laddas inbäddade media också när en presentation läses in?**

Inbäddat ljud och video blir tillgängligt via presentationsobjektmodellen. Externa resurser löses upp enligt standardbeteendet för resursinläsning och kan vara otillgängliga om deras platser inte kan nås.