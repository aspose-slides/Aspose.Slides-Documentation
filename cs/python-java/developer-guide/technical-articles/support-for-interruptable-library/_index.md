---
title: Přerušení dlouho běžících operací prezentace v Pythonu
linktitle: Přerušení operací prezentace
type: docs
weight: 120
url: /cs/python-java/support-for-interruptable-library/
keywords:
- přerušitelné operace
- token přerušení
- token zrušení
- dlouho běžící úloha
- přerušit úlohu
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Zjistěte, jak zrušit dlouho běžící operace prezentace v Aspose.Slides pro Python přes Java a vrátit částečný výsledek při exportu snímků ve smyčce."
---
## **Přehled**

Aspose.Slides pro Python přes Java může přerušit dlouho běžící operace, jako je načítání, ukládání a renderování prezentací. Vaše aplikace může použít stejný token přerušení k zastavení smyčky, než začne zpracovávat další snímek.

## **Přerušení operace prezentace**

Vytvořte [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/), získejte jeho token pomocí [getToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#getToken), a předávejte token do [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken). Předávejte možnosti načítání do [Presentation constructor](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/). Pro požádání o zrušení zavolejte [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) na zdroj. Přerušitelná operace se zastaví, když zaznamená požadavek. Použijte `jpype.JClass` k zachycení výjimky Java `com.aspose.slides.exceptions.OperationCanceledException` v Pythonu.

Příklad převádí `sample.pptx` na `sample.ppt` na vlákně na pozadí. Volající vlákno čeká až 10 sekund, než konverze dokončí. Pokud konverze stále běží, požaduje zrušení a čeká, až pracovník skončí.

```python
from concurrent.futures import ThreadPoolExecutor, TimeoutError

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")


def convert_presentation(source):
    options = LoadOptions()
    options.setInterruptionToken(source.getToken())
    try:
        presentation = Presentation("sample.pptx", options)
        try:
            presentation.save("sample.ppt", SaveFormat.Ppt)
        finally:
            presentation.dispose()
    except OperationCanceledException:
        print("Conversion canceled")


source = InterruptionTokenSource()
with ThreadPoolExecutor(max_workers=1) as executor:
    conversion = executor.submit(convert_presentation, source)
    try:
        conversion.result(timeout=10)
    except TimeoutError:
        source.interrupt()
        conversion.result()
```

## **Propojení časového limitu v Pythonu s Aspose.Slides**

Pro nastavení časového limitu operace s prezentací použijte [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer) k volání [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) po vypršení časového limitu. Příklad umožňuje 20 sekund načíst `sample.pptx` a exportovat jej do `sample.pdf`. Pokud export skončí dříve, aplikace zruší naplánovaný požadavek.

```python
from threading import Timer

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")

source = InterruptionTokenSource()
options = LoadOptions()
options.setInterruptionToken(source.getToken())

timer = Timer(20, source.interrupt)
timer.start()
try:
    presentation = Presentation("sample.pptx", options)
    try:
        presentation.save("sample.pdf", SaveFormat.Pdf)
    finally:
        presentation.dispose()
except OperationCanceledException:
    print("Presentation processing was canceled")
finally:
    timer.cancel()
    timer.join()
```

## **Zastavit před zpracováním dalšího snímku**

Použijte stejný [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) pro prezentaci i smyčku, která exportuje její snímky. Před každým exportem zkontrolujte [isInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#isInterruptionRequested). Pokud může volající použít částečný výsledek, vraťte čísla snímků, které byly úspěšně exportovány.

Použijte prezentaci pojmenovanou `sample.pptx` s alespoň dvěma snímky. Přetížení [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save), které přijímá Java `int[]`, používá čísla snímků počínaje 1. Použijte `jpype.JArray(jpype.JInt)` k vytvoření tohoto pole v Pythonu. Příklad ukládá každý snímek do samostatného PDF a okamžitě po zaznamenání prvního úspěšného exportu požaduje zrušení.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")


def export_slides(path, source):
    completed = []
    token = source.getToken()
    options = LoadOptions()
    options.setInterruptionToken(token)
    presentation = Presentation(path, options)
    try:
        for number in range(1, presentation.getSlides().size() + 1):
            if token.isInterruptionRequested():
                break

            print(f"Starting slide {number}")
            slide_numbers = jpype.JArray(jpype.JInt)([number])
            try:
                presentation.save(f"slide-{number}.pdf", slide_numbers, SaveFormat.Pdf)
            except OperationCanceledException:
                if token.isInterruptionRequested():
                    break
                raise

            completed.append(number)
            if number == 1:
                source.interrupt()
        return completed
    finally:
        presentation.dispose()


source = InterruptionTokenSource()
completed = export_slides("sample.pptx", source)
print(f"Completed: {completed}")
```

Příklad zapíše `slide-1.pdf` a vytiskne `Starting slide 1` následováno `Completed: [1]`. Smyčka zaznamená požadavek před zahájením snímku 2. Pokud zrušení přijde během ukládání, smyčka skončí dříve, než zaznamená tento snímek jako dokončený.

Pokud volající potřebuje zpracovat zrušení, nahraďte kontrolu a její `break` na začátku smyčky voláním `token.throwIfInterruptionRequested()`. Odstraňte `try`/`except` okolo ukládání, aby zrušení během exportu také dosáhlo volajícího. Se stejným vstupem příklad vytiskne pouze `Starting slide 1` a zapíše `slide-1.pdf`. Na začátku druhé iterace [throwIfInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) vyvolá `com.aspose.slides.exceptions.OperationCanceledException` před zahájením dalšího exportu. Výjimka se propaguje k volajícímu před tím, než funkce může vrátit seznam.

## **Často kladené otázky**

**Kdy bych měl požádat o zrušení?**  
Požádejte o zrušení, když operace překročí váš časový limit nebo když vaše aplikace již výsledek nepotřebuje.

**Jaký je rozdíl mezi [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) a [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/)?**  
Zdroj umožní vaší aplikaci požádat o zrušení. Token umožní Aspose.Slides i vaší aplikaci zkontrolovat tento požadavek.

**Mohu zrušit operaci z časovače v Pythonu?**  
Ano. Naplánujte volání [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) na zdroji spojeném s prezentací.

**Které operace mohu přerušit?**  
Můžete přerušit načítání, ukládání a renderování. Předávejte token do [Presentation constructor](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) pomocí [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken). Prezentace pak může zaznamenat zrušení během následných operací, například ukládání do PDF.

**Zastaví se operace okamžitě?**  
Zrušení je kooperativní. Operace kontroluje token periodicky a zastaví se, když zaznamená požadavek.

**Co se stane, když zavolám [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) po dokončení operace?**  
Dokončená operace si zachová svůj výsledek.

**Může více operací sdílet [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/)?**  
Ano. Zavolání [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) požaduje zrušení pro každou operaci, která používá token z tohoto zdroje. Použijte samostatný zdroj pro každou operaci, kterou chcete zrušit nezávisle.