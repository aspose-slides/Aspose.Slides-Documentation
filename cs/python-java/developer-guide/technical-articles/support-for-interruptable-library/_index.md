---
title: Podpora přerušitelné knihovny
type: docs
weight: 120
url: /cs/python-java/support-for-interruptable-library/
keywords:
- přerušitelná knihovna
- token přerušení
- zrušovací token
- dlouho běžící úloha
- přerušit úlohu
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Umožněte zrušení dlouho běžících úloh pomocí Aspose.Slides pro Python via Java. Bezpečně přerušte vykreslování a konverze pro PowerPoint a OpenDocument, s příklady."
---
## **Přehled**

Aspose.Slides poskytuje přerušitelný zpracovatelský mechanismus pro dlouho běžící úlohy prezentací, jako je deserializace, serializace a vykreslování. Tento mechanismus je založen na třídách [InterruptionToken](https://reference.aspose.com/slides/cs/python-java/aspose.slides/interruptiontoken/) a [InterruptionTokenSource](https://reference.aspose.com/slides/cs/python-java/aspose.slides/interruptiontokensource/).

[InterruptionToken](https://reference.aspose.com/slides/cs/python-java/aspose.slides/interruptiontoken/) může být přiřazen k [LoadOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/loadoptions/) a předán konstruktoru [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/). Když je zavolána metoda [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/cs/python-java/aspose.slides/interruptiontokensource/#interrupt), související dlouho běžící úloha je přerušena.

## **Přerušitelná knihovna**

Aspose.Slides for Python via Java poskytuje třídy [InterruptionToken](https://reference.aspose.com/slides/cs/python-java/aspose.slides/interruptiontoken/) a [InterruptionTokenSource](https://reference.aspose.com/slides/cs/python-java/aspose.slides/interruptiontokensource/). Umožňují přerušit dlouho běžící úlohy, jako je deserializace, serializace a vykreslování.

- [InterruptionTokenSource](https://reference.aspose.com/slides/cs/python-java/aspose.slides/interruptiontokensource/) je zdroj tokenu(ů) předávaných do [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/cs/python-java/aspose.slides/loadoptions/#setInterruptionToken).
- Když je zavolána metoda [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/cs/python-java/aspose.slides/loadoptions/#setInterruptionToken) a instance [LoadOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/loadoptions/) je předána konstruktoru [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/), volání [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/cs/python-java/aspose.slides/interruptiontokensource/#interrupt) přeruší jakoukoli dlouho běžící úlohu spojenou s touto [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).

Následující úryvek kódu ukazuje, jak přerušit běžící úlohu:

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
    conversion_task = executor.submit(convert_presentation)  # Spusťte akci v odděleném vláknu.
    time.sleep(10)  # Časový limit.
    token_source.interrupt()  # Zastavte konverzi.
```

## **Často kladené otázky**

**Jaký je účel interrupt knihovny Aspose.Slides?**

Poskytuje mechanismus pro přerušení dlouho běžících operací—jako je načítání, ukládání nebo vykreslování prezentací—před jejich dokončením. To je užitečné, když je nutné omezit čas zpracování nebo již úloha není potřeba.

**Jaký je rozdíl mezi [InterruptionToken](https://reference.aspose.com/slides/cs/python-java/aspose.slides/interruptiontoken/) a [InterruptionTokenSource](https://reference.aspose.com/slides/cs/python-java/aspose.slides/interruptiontokensource/)?**

- [InterruptionToken](https://reference.aspose.com/slides/cs/python-java/aspose.slides/interruptiontoken/) je předáván API Aspose.Slides a kontrolován během dlouho běžících operací.
- [InterruptionTokenSource](https://reference.aspose.com/slides/cs/python-java/aspose.slides/interruptiontokensource/) se používá ve vašem kódu k vytváření tokenů a spouštění přerušení voláním [interrupt](https://reference.aspose.com/slides/cs/python-java/aspose.slides/interruptiontokensource/#interrupt).

**Jaké úlohy lze přerušit?**

Jakákoli úloha Aspose.Slides, která přijímá [InterruptionToken](https://reference.aspose.com/slides/cs/python-java/aspose.slides/interruptiontoken/)—například načítání prezentace pomocí [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) nebo ukládání pomocí [Presentation.save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save)—může být přerušena.

**Probíhá přerušení okamžitě?**

Ne. Přerušení je kooperativní: operace periodicky kontroluje token a zastaví se, jakmile zjistí, že bylo voláno [interrupt](https://reference.aspose.com/slides/cs/python-java/aspose.slides/interruptiontokensource/#interrupt).

**Co se stane, když zavolám [interrupt](https://reference.aspose.com/slides/cs/python-java/aspose.slides/interruptiontokensource/#interrupt) po dokončení úlohy?**

Nic—volání nemá žádný efekt, pokud byla příslušná úloha již dokončena.

**Mohu znovu použít stejný [InterruptionTokenSource](https://reference.aspose.com/slides/cs/python-java/aspose.slides/interruptiontokensource/) pro více úloh?**

Ano—ale po volání [interrupt](https://reference.aspose.com/slides/cs/python-java/aspose.slides/interruptiontokensource/#interrupt) na tomto zdroji budou všechny úlohy používající jeho tokeny přerušeny. Používejte samostatné zdroje tokenů pro nezávislé řízení úloh.