---
title: Správa přístupnosti prezentací na Androidu
linktitle: Přístupnost prezentací
type: docs
weight: 30
url: /cs/androidjava/presentation-accessibility/
keywords:
- přístupnost prezentací
- označit jako dekorativní
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Objevte, jak Aspose.Slides pro Android pomocí Javy pomáhá automatizovat kontroly přístupnosti prezentací v souborech PPT, PPTX a ODP – zlepšuje zkušenost čteček obrazovky a zvyšuje soulad s normami."
---
## **Přehled**

Cílem přístupnosti prezentací je zajistit, aby lidé používající asistenční technologie – například čtečky obrazovky, braillovy řádky nebo ovládání pouze klávesnicí – mohli rozumět vašim snímkům a v nich se orientovat stejně efektivně jako diváci vidící a používající myš. Dobré postupy se zaměřují na jasné pořadí čtení, smysluplné alternativní texty pro informativní vizuály, dostatečný kontrast barev, čitelnou typografii, popisné texty odkazů a vyhýbání se předávání významu pouze barvou nebo polohou. Když je přístupnost naplánována od začátku, výsledek je přehlednější struktura, konzistentnější vizuály a obsah, který dosáhne každého diváka bez obcházení.

## **Označit jako dekorativní**

Označení jako dekorativní označuje čistě ozdobné vizuály, aby je čtečky obrazovky přeskočily, čímž se sníží šum a zachová se pozornost na smysluplném obsahu. Používejte jej u pozadí, ozdob a mezer – nikdy u grafů, ikon ani obrázků, které předávají informace. Aspose.Slides tuto značku zpřístupňuje pro detekci a validaci, což umožňuje automatické kontroly přístupnosti a úklid.

![Označit jako dekorativní](mark_as_decorative.png)

Následující ukázka kódu ukazuje, jak zjistit, zda je tvar označen jako dekorativní.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Is shape decorative: " + shape.isDecorative());
} finally {
    presentation.dispose();
}
```