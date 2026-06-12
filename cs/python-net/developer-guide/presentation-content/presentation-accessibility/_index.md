---
title: Správa přístupnosti prezentací v Pythonu
linktitle: Přístupnost prezentací
type: docs
weight: 30
url: /cs/python-net/presentation-accessibility/
keywords:
- přístupnost prezentací
- označit jako dekorativní
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Objevte, jak Aspose.Slides pro Python pomáhá automatizovat kontroly přístupnosti prezentací v souborech PPT, PPTX a ODP — zlepšete zážitek uživatelů čteček obrazovky a zvýšte shodu."
---
## **Úvod**

Dostupnost prezentací zajišťuje, že lidé používající asistenční technologie — jako jsou čtečky obrazovky, braillovy řádky nebo navigace pouze pomocí klávesnice — mohou rozumět vašim snímkům a v nich se orientovat stejně efektivně jako diváci vidoucí a používající myš. Dobrá praxe se zaměřuje na jasné pořadí čtení, smysluplný alternativní text pro informační vizuály, dostatečný kontrast barev, čitelnou typografii, popisný text odkazů a vyhýbání se předávání významu pouze pomocí barvy nebo polohy. Když je dostupnost plánována od počátku, výsledek je čistší struktura, konzistentnější vizuály a obsah, který osloví každého diváka bez obcházení.

## **Mark as Decorative**

Značka Mark as decorative označuje čistě ozdobné vizuály, aby je čtečky obrazovky přeskočily, čímž se sníží šum a zachová pozornost na smysluplném obsahu. Používejte ji u pozadí, ozdob a mezer — nikdy u grafů, ikon nebo obrázků, které předávají informace. Aspose.Slides exposuje tuto značku pro detekci a validaci, což umožňuje automatické kontroly dostupnosti a úklid.

![Mark as Decorative](mark_as_decorative.png)

Následující ukázka kódu ukazuje, jak zjistit, zda je tvar označen jako dekorativní.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    print(f"Is shape decorative: {shape.is_decorative}")
```