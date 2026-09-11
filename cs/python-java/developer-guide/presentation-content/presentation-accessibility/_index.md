---
title: Správa přístupnosti prezentací v Pythonu pomocí Javy
linktitle: Přístupnost prezentace
type: docs
weight: 30
url: /cs/python-java/presentation-accessibility/
keywords:
- přístupnost prezentace
- označit jako dekorativní
- PowerPoint
- OpenDocument
- prezentace
- Python
- Java
- Aspose.Slides
description: "Objevte, jak Aspose.Slides pro Python přes Java pomáhá automatizovat kontrolu přístupnosti prezentací v souborech PPT, PPTX a ODP – zlepšete zážitek čteček obrazovky a zvýšte soulad s předpisy."
---
## **Úvod**

Přístupnost prezentací zajišťuje, že lidé používající asistivní technologie – například čtečky obrazovky, braillské displeje nebo navigaci pouze pomocí klávesnice – mohou rozumět vašim slidům a v nich se orientovat stejně efektivně jako vidící uživatelé pracující s myší. Dobré postupy se zaměřují na jasné pořadí čtení, smysluplný alternativní text k informativním vizuálům, dostatečný kontrast barev, čitelnou typografii, popisný text odkazů a vyhýbání se předávání významu pouze barvou nebo polohou. Když je přístupnost plánována od samého začátku, výsledkem je čistší struktura, konzistentnější vizuály a obsah, který dosáhne každého diváka bez obcházení.

## **Označit jako dekorativní**

Značka 'Označit jako dekorativní' označuje čistě ornamentální vizuály, aby je čtečky obrazovky přeskočily, čímž se snižuje šum a zachovává se soustředění na smysluplný obsah. Používejte ji na pozadí, ozdoby a mezery – nikdy však na grafy, ikony nebo obrázky, které přenášejí informace. Aspose.Slides tuto značku poskytuje pro detekci a validaci, což umožňuje automatické kontroly přístupnosti a úklid.

![Označit jako dekorativní](mark_as_decorative.png)

Následující ukázka kódu ukazuje, jak zjistit, zda je tvar označen jako dekorativní.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    print(f"Is shape decorative: {shape.isDecorative()}")
finally:
    presentation.dispose()
```