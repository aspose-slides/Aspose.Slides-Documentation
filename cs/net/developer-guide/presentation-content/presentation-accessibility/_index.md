---
title: Správa přístupnosti prezentací v .NET
linktitle: Přístupnost prezentací
type: docs
weight: 30
url: /cs/net/presentation-accessibility/
keywords:
- přístupnost prezentací
- označit jako dekorativní
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Automatizujte kontrolu přístupnosti prezentací v souborech PPT, PPTX a ODP pomocí Aspose.Slides pro .NET—zlepšete zážitek čteček obrazovky a zvýšte soulad s předpisy."
---
## **Úvod**

Přístupnost prezentací zajišťuje, že lidé používající asistivní technologie—například čtečky obrazovky, braillské řádky nebo navigaci pouze klávesnicí—mohou pochopit a procházet vaše snímky stejně efektivně jako vidící uživatelé s myší. Dobrá praxe se zaměřuje na jasné pořadí čtení, smysluplný alternativní text k informačním vizuálům, dostatečný kontrast barev, čitelnou typografii, popisný text odkazů a vyhýbání se předávání významu pouze barvou nebo polohou. Když je přístupnost plánována od začátku, výsledkem je čistší struktura, konzistentnější vizuály a obsah, který osloví každého diváka bez obcházení.

## **Označit jako dekorativní**

Označení jako dekorativní slouží k označení čistě ozdobných vizuálů, aby je čtečky obrazovky přeskočily, snižujíc šum a udržujíc pozornost na smysluplném obsahu. Používejte jej u pozadí, ozdob a odsazených prvků—nikdy u grafů, ikon nebo obrázků, které předávají informace. Aspose.Slides toto označení zpřístupňuje pro detekci a validaci, což umožňuje automatické kontroly přístupnosti a úklid.

![Mark as Decorative](mark_as_decorative.png)

```cs
using var presentation = new Presentation("sample.pptx");

var shape = presentation.Slides[0].Shapes[0];
Console.WriteLine($"Is shape decorative: {shape.IsDecorative}");
```