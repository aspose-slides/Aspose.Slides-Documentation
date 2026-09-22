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
description: "Lär dig hur du öppnar PowerPoint- och OpenDocument-presentationer i Python, anger öppningslösenord och minskar minnesanvändningen med Aspose.Slides för Python via .NET."
---
## **Introduktion**

[Aspose.Slides for Python via .NET](https://products.aspose.com/slides/sv/python-net/) kan läsa PowerPoint- och OpenDocument-presentationer från filer och strömmar. Efter att en presentation har lästs in kan du inspektera dess struktur, redigera bilder, hantera resurser och spara den i det ursprungliga eller ett annat stödd format.

Laddningsbeteendet kan anpassas via klassen [LoadOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides/loadoptions/). Till exempel kan du ange ett öppningslösenord, behålla stora binära objekt utanför minnet eller utelämna inbäddade binära data.

## **Öppna presentationer**

Efter att ha läst in en fil eller ström kan du [bestämma dess ursprungliga presentationsformat](/slides/sv/python-net/detect-presentation-source-format/) för att välja hur din applikation behandlar den.

För att öppna en befintlig presentation, skicka dess filsökväg till konstruktorn [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/). Använd ett `with`‑statement så att filhandtag, tillfälliga data och andra resurser släpps omedelbart.

Följande Python‑exempel visar hur man öppnar en presentation och får antalet bilder:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

## **Öppna lösenordsskyddade presentationer**

Ett öppningslösenord krypterar presentationsinnehållet. För att läsa in hela presentationen, tilldela rätt lösenord till [LoadOptions.password](https://reference.aspose.com/slides/sv/python-net/aspose.slides/loadoptions/password/) och skicka alternativen till konstruktorn [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/). Inläsning misslyckas när lösenordet saknas eller är felaktigt.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-presentation.pptx", load_options) as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

För lösenorddetektering, validering och krypteringsarbetsflöden, se [Lösenordsskydda presentationer](/slides/sv/python-net/password-protected-presentation/). Om en krypterad presentation avsiktligt sparats med offentliga dokumentegenskaper kan dessa läsas utan lösenord; se [Hantera presentationsegenskaper](/slides/sv/python-net/presentation-properties/).

## **Öppna stora presentationer**

[LoadOptions.blob_management_options](https://reference.aspose.com/slides/sv/python-net/aspose.slides/loadoptions/blob_management_options/) styr hur Aspose.Slides hanterar stora binära objekt som bilder, ljud och video. Du kan hålla källfilen låst, tillåta temporära filer och begränsa mängden BLOB‑data som behålls i minnet.

Denna Python‑kod demonstrerar inläsning av en stor presentation (till exempel 2 GB):

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

{{% alert color="info" title="Note" %}}
Med `PresentationLockingBehavior.KEEP_LOCKED` förblir källfilen låst tills `Presentation`‑objektet tas bort. Flytta, skriv över eller ta inte bort källfilen medan det objektet är levande.

Aspose.Slides kan kopiera innehållet i en inmatningsström under inläsning. För stora presentationer är en filsökväg därför vanligtvis mer effektiv än en ström. Se [Hantera BLOB‑objekt](/slides/sv/python-net/manage-blob/) för ytterligare lagrings‑ och minneshanteringsalternativ.
{{% /alert %}}

## **Läs in presentationer utan inbäddade binära objekt**

En presentation kan innehålla inbäddade binära data som en applikation inte behöver eller inte vill behålla. Exempel inkluderar:

- VBA‑projekt, tillgängliga via [Presentation.vba_project](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/vba_project/);
- inbäddade OLE‑data, tillgängliga via [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/);
- ActiveX‑kontrolldata, tillgängliga via [Control.active_x_control_binary](https://reference.aspose.com/slides/sv/python-net/aspose.slides/control/active_x_control_binary/).

Ställ in [LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/sv/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) till `True` för att ta bort dessa binära data vid inläsning. Spara den inlästa presentationen för att behålla det sanerade resultatet.

Detta alternativ minskar exponeringen för oönskade inbäddade payloads, men det är inte ett komplett system för malware‑detektion eller innehållssanering.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("presentation-with-embedded-data.pptx", load_options) as presentation:
    presentation.save("presentation-without-embedded-data.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Hur kan jag avgöra att en fil är skadad och inte kan öppnas?**

Aspose.Slides kastar ett parse‑ eller format‑undantag under inläsning. Hantera det felet separat från ett felaktigt lösenord‑fel så att applikationen kan rapportera orsaken korrekt.

**Vad händer om obligatoriska teckensnitt saknas?**

Presentationen kan fortfarande läsas in, men rendering och export kan byta ut teckensnitt. Du kan [konfigurera teckensnittsbyte](/slides/sv/python-net/font-substitution/) eller [tillhandahålla anpassade teckensnitt](/slides/sv/python-net/custom-font/) för att göra utdata mer förutsägbar.

**Laddar inläsning av en presentation även dess inbäddade media?**

Inbäddat ljud och video blir tillgängliga via presentationsobjektmodellen. Externa resurser löses upp enligt standardbeteendet för resursladdning och kan vara otillgängliga om deras platser inte kan nås.