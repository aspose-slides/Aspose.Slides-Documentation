---
title: Přerušení dlouhotrvajících operací s prezentacemi v Pythonu
linktitle: Přerušení operací s prezentacemi
type: docs
weight: 150
url: /cs/python-net/support-for-interruptable-library/
keywords:
- přerušitelné operace
- token přerušení
- zrušit export PDF
- PowerPoint
- Python
- Aspose.Slides
description: "Zjistěte, jak zrušit převod prezentace v Pythonu a vrátit seznam snímků, které dokončily export před zrušením."
---
## **Přehled**

Aspose.Slides for Python via .NET podporuje kooperativní zrušení během dlouhotrvajících operací, jako je načítání, ukládání a vykreslování prezentací. Při exportu snímků jednotlivě můžete také kontrolovat zrušení mezi snímky a vracet čísla snímků, které export dokončily.

## **Zrušení převodu prezentace**

Vytvořte [InterruptionTokenSource](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/), přiřaďte jeho [token](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/token/) k [LoadOptions.interruption_token](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/interruption_token/) a předávejte možnosti konstruktoru [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/__init__/). Token platí pro celou prezentaci po celou dobu jejího životního cyklu. Pro požadavek na zrušení z vaší aplikace zavolejte [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/interrupt/).

Příklad převádí `sample.pptx` na `sample.pdf`. [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer) zavolá `source.interrupt` po 20 s. Spuštění časovače před otevřením souboru způsobí, že časový limit se vztahuje jak na načítání, tak na ukládání. Aplikace s tlačítkem Zrušit může volat stejnou metodu z obslužné rutiny události.

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

Explicitní kontrola po načtení přeskočí export, pokud již časový limituplynul. Pokud načítání nebo ukládání zaznamená požadavek, výjimka zrušení se předá volajícímu. Ukládání může také skončit dříve, než požadavek zaznamená, a v takovém případě je PDF kompletní.

## **Zastavení před zpracováním dalšího snímku**

Zkontrolujte [InterruptionToken.is_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/is_interruption_requested/) před každým exportem. [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) přijímá seznam čísel snímků začínajících od 1. Přidejte číslo do seznamu dokončených až po úspěšném uložení jeho PDF.

Použijte soubor pojmenovaný `sample.pptx` s alespoň dvěma snímky. Aby byl výsledek reprodukovatelný, příklad požaduje zrušení hned po dokončení snímku 1. V aplikaci může požadavek přicházet z jiného vlákna, zatímco se snímek ukládá.

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

Příklad zapíše `slide-1.pdf` a vypíše `Starting slide 1` následované `Completed: [1]`. Další iterace zaznamená požadavek před zahájením snímku 2. Pokud zrušení přeruší ukládání, obslužná rutina výjimky vrátí čísla zaznamenaná v předchozích iteracích. Ostatní chyby exportu se předají volajícímu.

Pokud má volající zrušení zpracovat jako výjimku, nahraďte kontrolu a její `break` na začátku smyčky voláním [token.throw_if_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/throw_if_interruption_requested/). Také odstraňte `try`/`except` kolem ukládání. Se stejným vstupem se snímek 1 uloží a druhá iterace vyvolá výjimku zrušení před zahájením snímku 2.

## **FAQ**

**Kdy má požadavek na zrušení efekt?**

Přerušitelná operace periodicky kontroluje svůj token. Zastaví se, jakmile požadavek zaznamená. Operace, která již skončila, si ponechá výsledek.

**Jaký je rozdíl mezi zdrojem a tokenem?**

Zdroj umožňuje vaší aplikaci požádat o zrušení. Token umožňuje jak prezentaci, tak vašemu kódu kontrolovat tento požadavek.

**Může několik operací sdílet jeden zdroj?**

Ano. Volání `interrupt` požaduje zrušení pro každou operaci používající token z tohoto zdroje. Pokud potřebujete operaci zrušit nezávisle, dejte každé operaci vlastní zdroj.