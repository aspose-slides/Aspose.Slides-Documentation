---
title: Avbryt långvariga presentationsoperationer i Python
linktitle: Avbryt presentationsoperationer
type: docs
weight: 150
url: /sv/python-net/support-for-interruptable-library/
keywords:
- avbrottbara operationer
- avbrottstoken
- avbryt PDF-export
- PowerPoint
- Python
- Aspose.Slides
description: "Lär dig hur du avbryter en presentationskonvertering i Python och returnerar listan över bilder som slutförde exporten innan avbrottet."
---
## **Översikt**

Aspose.Slides för Python via .NET stöder kooperativ avbrytning under långvariga operationer såsom inläsning, sparande och rendering av presentationer. När du exporterar bilder individuellt kan du också kontrollera avbrytning mellan bilder och returnera numren på de bilder som har slutfört exporten.

## **Avbryt en presentationskonvertering**

Skapa en [InterruptionTokenSource](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/), tilldela dess [token](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/token/) till [LoadOptions.interruption_token](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/interruption_token/), och skicka alternativen till [Presentation‑konstruktör](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/__init__/). Tokenet gäller för presentationen under hela dess livstid. För att begära avbrytning från din applikation, anropa [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/interrupt/).

Exemplet konverterar `sample.pptx` till `sample.pdf`. En [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer) anropar `source.interrupt` efter 20 sekunder. Att starta timern innan filen öppnas gör att tidsgränsen gäller både för inläsning och sparande. En applikation med en Avbryt‑knapp kan anropa samma metod från sin händelsehanterare.

```python
from threading import Timer

import aspose.slides as slides

source = slides.InterruptionTokenSource()
options = slides.LoadOptions()
options.interruption_token = source.token
timer = Timer(20, source.interrupt)

timer.start()
try:
    with slides.Presentation("sample.pptx", options) as presentation:
        options.interruption_token.throw_if_interruption_requested()
        presentation.save("sample.pdf", slides.export.SaveFormat.PDF)
finally:
    timer.cancel()
    timer.join()
```

Den explicita kontrollen efter inläsning hoppar över exporten om tidsgränsen redan har löpt ut. Om inläsning eller sparande observerar begäran når avbrottsexceptionen upp till anroparen. En sparning kan också slutföras innan den observerar begäran, i så fall är PDF‑filen färdig.

## **Stoppa innan nästa bild bearbetas**

Kontrollera [InterruptionToken.is_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/is_interruption_requested/) innan varje export. [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) accepterar en lista med bildnummer med början på 1. Lägg till ett nummer i den slutförda listan endast efter att dess PDF har sparats framgångsrikt.

Använd en fil med namnet `sample.pptx` som har minst två bilder. För att göra resultatet reproducerbart begär exemplet avbrytning så snart bild 1 är klar. I en applikation kan begäran komma från en annan tråd medan en bild sparas.

```python
import aspose.slides as slides


def export_slides(path, source):
    completed = []
    token = source.token
    options = slides.LoadOptions()
    options.interruption_token = token

    with slides.Presentation(path, options) as presentation:
        for number in range(1, len(presentation.slides) + 1):
            if token.is_interruption_requested:
                break

            print(f"Starting slide {number}")
            try:
                presentation.save(f"slide-{number}.pdf", [number], slides.export.SaveFormat.PDF)
            except slides.AsposeSlidesException as error:
                if token.is_interruption_requested and "System.OperationCanceledException" in str(error):
                    break
                raise

            completed.append(number)
            if number == 1:
                source.interrupt()

    return completed


source = slides.InterruptionTokenSource()
completed = export_slides("sample.pptx", source)
print(f"Completed: {completed}")
```

Exemplet skriver `slide-1.pdf` och skriver ut `Starting slide 1` följt av `Completed: [1]`. Nästa iteration ser begäran innan bild 2 startas. Om avbrytning avbryter en sparning returnerar undantagshanteraren de nummer som registrerats av tidigare iterationer. Andra exportfel når anroparen.

Om anroparen ska hantera avbrytning som ett undantag, ersätt kontrollen och dess `break` högst upp i loopen med [token.throw_if_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/throw_if_interruption_requested/). Ta också bort `try`/`except`‑blocket runt sparandet. Med samma indata sparas bild 1 och den andra iterationen höjer ett avbrottsexception innan bild 2 startas.

## **Vanliga frågor**

**När får en avbrytningseförfrågan effekt?**

En avbrytbar operation kontrollerar sitt token periodiskt. Den stoppas när den observerar begäran. En operation som redan har slutförts behåller sitt resultat.

**Vad är skillnaden mellan källan och token?**

Källan låter din applikation begära avbrytning. Tokenet låter både presentationen och din egen kod kontrollera den begäran.

**Kan flera operationer dela samma källa?**

Ja. Att anropa `interrupt` begär avbrytning för alla operationer som använder ett token från den källan. Ge varje operation sin egen källa om du behöver avbryta den oberoende.