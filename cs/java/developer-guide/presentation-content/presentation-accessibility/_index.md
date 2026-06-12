---
title: Správa přístupnosti prezentací v Javě
linktitle: Přístupnost prezentací
type: docs
weight: 30
url: /cs/java/presentation-accessibility/
keywords:
- přístupnost prezentací
- označit jako dekorativní
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Objevte, jak Aspose.Slides pro Java pomáhá automatizovat kontroly přístupnosti prezentací v souborech PPT, PPTX a ODP – zlepšete zkušenost čteček obrazovky a zvýšte soulad."
---
## **Introduction**

Přístupnost prezentací zajišťuje, že lidé používající asistenční technologie – například čtečky obrazovky, braillovy displeje nebo ovládání pouze pomocí klávesnice – mohou rozumět vašim snímkům a v nich se orientovat stejně efektivně jako diváci vidící a používající myš. Dobrá praxe se zaměřuje na jasné pořadí čtení, smysluplný alternativní text pro informační vizuály, dostatečný kontrast barev, čitelnou typografii, popisný text odkazů a vyhýbání se vyjádření významu pouze barvou nebo polohou. Když je přístupnost plánována od začátku, výsledek je čistší struktura, konzistentnější vizuály a obsah, který dosáhne každého diváka bez obcházení.

## **Mark as Decorative**

Označení jako dekorativní označuje čistě ornamentální vizuály, aby je čtečky obrazovky přeskočily, čímž se snižuje šum a zachovává se zaměření na smysluplný obsah. Použijte jej na pozadí, ozdoby a odsazení – nikdy na grafy, ikony nebo obrázky, které předávají informace. Aspose.Slides tuto značku zpřístupňuje pro detekci a validaci, čímž umožňuje automatické kontroly přístupnosti a úklid.

![Mark as Decorative](mark_as_decorative.png)

The following code sample shows how to determine whether a shape is marked as decorative.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Is shape decorative: " + shape.isDecorative());
} finally {
    presentation.dispose();
}
```