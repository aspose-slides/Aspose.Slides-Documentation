---
title: Správa přístupnosti prezentací v C++
linktitle: Přístupnost prezentací
type: docs
weight: 30
url: /cs/cpp/presentation-accessibility/
keywords:
- přístupnost prezentací
- označit jako dekorativní
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Objevte, jak Aspose.Slides pro C++ pomáhá automatizovat kontrolu přístupnosti prezentací v souborech PPT, PPTX a ODP — zlepšete zážitek čteček obrazovky a zvýšte soulad."
---
## **Přehled**

Přístupnost prezentací zajišťuje, že lidé používající asistenční technologie — například čtečky obrazovky, braillovy displeje nebo navigaci jen pomocí klávesnice — mohou rozumět vašim snímkům a v nich se orientovat stejně efektivně jako publikum vidící a používající myš. Správná praxe se zaměřuje na jasné pořadí čtení, smysluplný alternativní text k informačním vizuálům, dostatečný kontrast barev, čitelnou typografii, popisný text odkazů a vyhýbání se vyjadřování významu pouze barvou nebo polohou. Když je přístupnost naplánována od začátku, výsledek je čistší struktura, jednotnější vizuály a obsah, který dosáhne každého diváka bez obcházení.

## **Označit jako dekorativní**

Označení jako dekorativní označuje čistě ornamentální vizuály, aby je čtečky obrazovky přeskočily, čímž se sníží šum a zachová se pozornost na smysluplném obsahu. Používejte jej na pozadí, ozdoby a rozestupy — nikdy na grafy, ikony nebo obrázky, které nesou informace. Aspose.Slides tuto značku vystavuje pro detekci a validaci, což umožňuje automatické kontroly přístupnosti a úklid.

![Označit jako dekorativní](mark_as_decorative.png)

Následující ukázka kódu ukazuje, jak zjistit, zda je tvar označen jako dekorativní.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
Console::WriteLine(u"Is shape decorative: {0}", shape->get_IsDecorative());

presentation->Dispose();
```