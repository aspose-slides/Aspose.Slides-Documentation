---
title: Správa přístupnosti prezentací v JavaScriptu
linktitle: Přístupnost prezentací
type: docs
weight: 30
url: /cs/nodejs-java/presentation-accessibility/
keywords:
- přístupnost prezentací
- označit jako dekorativní
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Automatizujte kontroly přístupnosti prezentací v souborech PPT, PPTX a ODP pomocí Aspose.Slides pro Node.js - zlepšete zážitek čteček obrazovky a zvýšte shodu."
---
## **Přehled**

Přístupnost prezentací zajišťuje, že lidé používající asistenční technologie – například čtečky obrazovky, braillovy řádky nebo navigaci pouze pomocí klávesnice – mohou rozumět a procházet vaše snímky stejně efektivně jako publikum vidící a používající myš. Dobré postupy se zaměřují na jasné pořadí čtení, smysluplný alternativní text pro informační vizuály, dostatečný kontrast barev, čitelnou typografii, popisný text odkazů a vyhýbání se vyjadřování významu pouze barvou nebo polohou. Když je přístupnost plánována od začátku, výsledek je čistší struktura, konzistentnější vizuály a obsah, který dosáhne každého diváka bez obcházení.

## **Označit jako dekorativní**

Označit jako dekorativní označuje čistě ornamentální vizuály, aby je čtečky obrazovky přeskočily, čímž se snižuje šum a udržuje se pozornost na smysluplném obsahu. Používejte to pro pozadí, ozdoby a mezery – nikdy pro grafy, ikony nebo obrázky, které nesou informaci. Aspose.Slides tuto značku zpřístupňuje pro detekci a validaci, což umožňuje automatizované kontroly přístupnosti a úklid.

![Označit jako dekorativní](mark_as_decorative.png)

Následující ukázkový kód ukazuje, jak zjistit, zda je tvar označen jako dekorativní.

```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Is shape decorative:", shape.isDecorative());
} finally {
    presentation.dispose();
}
```