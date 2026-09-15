---
title: Stöd för ett avbrottsbibliotek
type: docs
weight: 120
url: /sv/python-java/support-for-interruptable-library/
keywords:
- avbrottsbibliotek
- avbrottstoken
- avbokningstoken
- långvarig uppgift
- avbryt uppgift
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Gör långvariga uppgifter avbrytbara med Aspose.Slides för Python via Java. Avbryt rendering och konverteringar för PowerPoint och OpenDocument på ett säkert sätt, med exempel."
---
## **Översikt**

Aspose.Slides tillhandahåller en avbrottbar bearbetningsmekanism för långvariga presentationsuppgifter, såsom deserialisering, serialisering och rendering. Denna mekanism är baserad på klasserna [InterruptionToken](https://reference.aspose.com/slides/sv/python-java/aspose.slides/interruptiontoken/) och [InterruptionTokenSource](https://reference.aspose.com/slides/sv/python-java/aspose.slides/interruptiontokensource/).

Ett [InterruptionToken](https://reference.aspose.com/slides/sv/python-java/aspose.slides/interruptiontoken/) kan tilldelas [LoadOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/loadoptions/) och skickas till konstruktorn för [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/). När [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/sv/python-java/aspose.slides/interruptiontokensource/#interrupt) anropas avbryts den associerade långvariga uppgiften.

## **Avbrottsbibliotek**

Aspose.Slides för Python via Java tillhandahåller klasserna [InterruptionToken](https://reference.aspose.com/slides/sv/python-java/aspose.slides/interruptiontoken/) och [InterruptionTokenSource](https://reference.aspose.com/slides/sv/python-java/aspose.slides/interruptiontokensource/). De låter dig avbryta långvariga uppgifter som deserialisering, serialisering och rendering.

- [InterruptionTokenSource](https://reference.aspose.com/slides/sv/python-java/aspose.slides/interruptiontokensource/) är källan till token(en) som skickas till [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/sv/python-java/aspose.slides/loadoptions/#setInterruptionToken).
- När [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/sv/python-java/aspose.slides/loadoptions/#setInterruptionToken) anropas och instansen av [LoadOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/loadoptions/) skickas till konstruktorn för [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/), avbryter ett anrop av [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/sv/python-java/aspose.slides/interruptiontokensource/#interrupt) alla långvariga uppgifter som är associerade med den [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).

Följande kodexempel visar hur man avbryter en pågående uppgift:

```python
from concurrent.futures import ThreadPoolExecutor
import time

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat


token_source = InterruptionTokenSource()


def convert_presentation():
    load_options = LoadOptions()
    load_options.setInterruptionToken(token_source.getToken())

    presentation = Presentation("sample.pptx", load_options)
    try:
        presentation.save("sample.ppt", SaveFormat.Ppt)
    finally:
        presentation.dispose()


with ThreadPoolExecutor(max_workers=1) as executor:
    conversion_task = executor.submit(convert_presentation)  # Kör åtgärden i en separat tråd.
    time.sleep(10)  # Tidsgräns.
    token_source.interrupt()  # Stoppa konverteringen.
    conversion_task.result()
```

## **Vanliga frågor**

**Vad är syftet med Aspose.Slides avbrottsbibliotek?**

Det tillhandahåller en mekanism för att avbryta långvariga operationer—såsom att läsa in, spara eller rendera presentationer—innan de slutförs. Detta är användbart när bearbetningstiden måste begränsas eller när uppgiften inte längre behövs.

**Vad är skillnaden mellan [InterruptionToken](https://reference.aspose.com/slides/sv/python-java/aspose.slides/interruptiontoken/) och [InterruptionTokenSource](https://reference.aspose.com/slides/sv/python-java/aspose.slides/interruptiontokensource/)?**

- [InterruptionToken](https://reference.aspose.com/slides/sv/python-java/aspose.slides/interruptiontoken/) skickas till Aspose.Slides‑API:et och kontrolleras under långvariga operationer.
- [InterruptionTokenSource](https://reference.aspose.com/slides/sv/python-java/aspose.slides/interruptiontokensource/) används i din kod för att skapa token och trigga avbrott genom att anropa [interrupt](https://reference.aspose.com/slides/sv/python-java/aspose.slides/interruptiontokensource/#interrupt).

**Vilka uppgifter kan avbrytas?**

Alla Aspose.Slides‑uppgifter som accepterar en [InterruptionToken](https://reference.aspose.com/slides/sv/python-java/aspose.slides/interruptiontoken/)—såsom att läsa in en presentation med [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/) eller spara med [Presentation.save](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#save)—kan avbrytas.

**Sker avbrottet omedelbart?**

Nej. Avbrott är samarbetsbaserat: operationen kontrollerar token periodiskt och stoppar så snart den upptäcker att [interrupt](https://reference.aspose.com/slides/sv/python-java/aspose.slides/interruptiontokensource/#interrupt) har anropats.

**Vad händer om jag anropar [interrupt](https://reference.aspose.com/slides/sv/python-java/aspose.slides/interruptiontokensource/#interrupt) efter att en uppgift redan har slutförts?**

Ingenting—anropet har ingen effekt om den motsvarande uppgiften redan har slutförts.

**Kan jag återanvända samma [InterruptionTokenSource](https://reference.aspose.com/slides/sv/python-java/aspose.slides/interruptiontokensource/) för flera uppgifter?**

Ja—men efter att du anropar [interrupt](https://reference.aspose.com/slides/sv/python-java/aspose.slides/interruptiontokensource/#interrupt) på den källan kommer alla uppgifter som använder dess token att avbrytas. Använd separata tokenkällor för att hantera uppgifter oberoende.