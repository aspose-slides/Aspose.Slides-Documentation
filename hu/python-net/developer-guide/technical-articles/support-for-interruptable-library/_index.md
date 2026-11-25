---
title: Hosszú ideig futó prezentáció műveletek megszakítása Pythonban
linktitle: Prezentáció műveletek megszakítása
type: docs
weight: 150
url: /hu/python-net/support-for-interruptable-library/
keywords:
- megszakítható műveletek
- megszakítási token
- PDF export megszakítása
- PowerPoint
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan lehet megszakítani egy prezentáció konverziót Pythonban, és visszaadni a megszakítás előtt exportálásra befejezett diák listáját."
---
## **Áttekintés**

Az Aspose.Slides for Python via .NET támogatja az együttműködő megszakítást a hosszú ideig tartó műveletek, például a prezentációk betöltése, mentése és renderelése során. Ha egyes diák exportálását végzi, akkor a diák között is ellenőrizheti a megszakítást, és visszaadhatja a sikeresen exportált diák számait.

## **Prezentációkonverzió leállítása**

Hozzon létre egy [InterruptionTokenSource](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/), rendelje hozzá a [token](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/token/)‑t a [LoadOptions.interruption_token](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/interruption_token/)-hez, és adja át a beállításokat a [Presentation constructor](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/__init__/)‑nek. A token a prezentáció teljes élettartama alatt érvényes. A megszakítás kéréséhez az alkalmazásból hívja meg a [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/interrupt/) metódust.

Az példában a `sample.pptx` fájlt `sample.pdf`‑re konvertálja. A [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer) 20 másodperc után meghívja a `source.interrupt`‑et. A timer indítása a fájl megnyitása előtt azt eredményezi, hogy az időkorlát a betöltésre és a mentésre egyaránt érvényes. Egy Cancel gombbal rendelkező alkalmazás ugyanazt a metódust hívhatja meg az eseménykezelőjéből.

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

A betöltés utáni explicit ellenőrzés kihagyja az exportálást, ha az időkorlát már lejárt. Ha a betöltés vagy a mentés észleli a kérést, a megszakítási kivétel eljut a hívóhoz. A mentés is befejeződhet a kérés észlelése előtt, ebben az esetben a PDF‑je kész.

## **Állj meg a következő dia feldolgozása előtt**

Minden export előtt ellenőrizze az [InterruptionToken.is_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/is_interruption_requested/) metódust. A [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) 1‑től kezdődő diaszámok listáját fogadja el. Egy számot csak akkor adjon hozzá a befejezett listához, ha a PDF‑je sikeresen mentésre került.

Használjon egy legalább két diával rendelkező `sample.pptx` fájlt. A reprodukálhatóság érdekében a példában a 1. dia befejezésekor kérik a megszakítást. Egy alkalmazásban a kérés érkezhet egy másik szálról, miközben egy dia mentés alatt áll.

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

A példa `slide-1.pdf`‑t ír, és kiírja a `Starting slide 1` szöveget, majd a `Completed: [1]`‑t. A következő iteráció a kérésre a 2. dia indítása előtt reagál. Ha a megszakítás egy mentést félbeszakít, a kivételkezelő visszaadja az előző iterációkban rögzített számokat. A többi export hiba a hívóhoz jut.

Ha a hívónak a megszakítást kivételként kell kezelnie, cserélje le az ellenőrzést és a ciklus elején lévő `break`‑et a [token.throw_if_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/throw_if_interruption_requested/) hívásra. Távolítsa el a mentés körüli `try`/`except` blokkot is. Ugyanazzal a bemenettel a 1. dia mentésre kerül, a második iteráció pedig a 2. dia indítása előtt megszakítási kivételt dob.

## **FAQ**

**Mikor lép életbe a megszakítási kérés?**

Egy megszakítható művelet időnként ellenőrzi a tokenjét. A művelet leáll, ha észleli a kérést. Egy már befejezett művelet megtartja az eredményét.

**Mi a különbség a forrás és a token között?**

A forrás lehetővé teszi az alkalmazás számára a megszakítás kérését. A token pedig a prezentációnak és a saját kódjának is lehetőséget ad a kérés ellenőrzésére.

**Több művelet megoszthatja a forrást?**

Igen. Az `interrupt` hívása a forrásból származó tokennel rendelkező összes műveletet megszakításra kéri. Ha egyes műveleteket önállóan szeretne leállítani, adjon minden műveletnek saját forrást.