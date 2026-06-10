---
title: A betűtípus cseréjének egyszerűsítése prezentációkban JavaScript használatával
linktitle: Betűtípus csere
type: docs
weight: 60
url: /hu/nodejs-java/font-replacement/
keywords:
- betűtípus
- betűtípus cseréje
- betűtípus csere
- betűtípus módosítása
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Zökkenőmentesen cserélje ki a betűtípusokat JavaScriptben az Aspose.Slides for Node.js segítségével Java-n keresztül, hogy konzisztens tipográfiát biztosítson a PowerPoint és OpenDocument prezentációkban."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy egy betűtípust egy másikra cseréljen a teljes bemutató során. Amikor egy betűtípust cserélnek, az eredeti betűtípus minden előfordulása az új betűtípusra módosul.

A betűtípus cseréjéhez töltse be a bemutatót, határozza meg a forrás betűtípust és a helyettesítő betűtípust, hívja meg a betűtípus csere metódust, és mentse a módosított bemutatót PPTX fájlként. Ez a megközelítés akkor hasznos, ha szándékosan szeretne egy betűtípuscsaládot egy másikra cserélni a teljes bemutatóban.

## **Betűtípusok cseréje**

Ha meggondolja magát egy betűtípussal kapcsolatban, lecserélheti azt egy másik betűtípusra. A régi betűtípus minden előfordulása a új betűtípusra lesz cserélve.

Az Aspose.Slides lehetővé teszi a betűtípus ilyen módú cseréjét:

1. Töltse be a megfelelő bemutatót.  
2. Töltse be a cserélendő betűtípust.  
3. Töltse be az új betűtípust.  
4. Cserélje le a betűtípust.  
5. Írja ki a módosított bemutatót PPTX fájlként.

Ez a JavaScript kód bemutatja a betűtípus cseréjét:

```javascript
// Betölt egy bemutatót
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // Betölti a forrás betűtípust, amelyet cserélni fog
    var sourceFont = new aspose.slides.FontData("Arial");
    // Betölti az új betűtípust
    var destFont = new aspose.slides.FontData("Times New Roman");
    // Lecseréli a betűtípusokat
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    // Elmenti a bemutatót
    pres.save("UpdatedFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Note" color="warning" %}} 
A szabályok meghatározásához, amelyek meghatározzák, mi történjen bizonyos feltételek esetén (például ha egy betűtípus nem érhető el), lásd a [**Font Substitution**](/slides/hu/nodejs-java/font-substitution/).
{{% /alert %}}

## **GYIK**

**Mi a különbség a "font replacement", "font substitution" és a "fallback fonts" között?**

A cserélés (replacement) egy szándékos váltás egy családról egy másikra a teljes dokumentumban. [Substitution](/slides/hu/nodejs-java/font-substitution/) egy szabály, például „ha a betűtípus nem elérhető, használja a X-et.” [Fallback](/slides/hu/nodejs-java/fallback-font/) egyedi hiányzó gliffekre alkalmazott megoldás, amikor az alaps betűtípus telepítve van, de nem tartalmazza a szükséges karaktereket.

**A csere érvényes-e a mester diákra, elrendezésekre, jegyzetekre és megjegyzésekre?**

Igen. A csere minden olyan bemutató objektusra kihat, amely az eredeti betűtípust használja, beleértve a mester diákat és a jegyzeteket; a megjegyzések is a dokumentum részei, és a betűtípus motor figyelembe veszi őket.

**Megváltozik-e a betűtípus a beágyazott OLE objektumokban (például Excel)?**

Nem. Az [OLE content](/slides/hu/nodejs-java/manage-ole/) saját alkalmazás által van vezérelve. A bemutatóban végzett csere nem formázza át a belső OLE adatokat; ezek megjelenhetnek képként vagy külsőleg szerkeszthető tartalomként.

**Lecserélhetek egy betűtípust csak a bemutató egy részén (diák vagy területek szerint)?**

Célzott csere lehetséges, ha a betűtípust a szükséges objektumok/tartományok szintjén módosítja, ahelyett, hogy globális cserét alkalmazna a teljes dokumentumra. A renderelés során a betűtípus kiválasztási logika továbbra is ugyanaz marad.

**Hogyan tudom előre meghatározni, hogy a bemutató mely betűtípusokat használ?**

Használja a bemutató [font manager](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsmanager/): ez listát ad a használt [families in use](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsmanager/getfonts/) és információt a [substitutions/"unknown" fonts](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) mellett, ami segít a csere megtervezésében.

**Működik a betűtípus csere PDF/képek konvertálásakor?**

Igen. Exportáláskor az Aspose.Slides ugyanazt a [font selection/substitution sequence](/slides/hu/nodejs-java/font-selection-sequence/) alkalmazza, így a előre végzett csere figyelembe lesz véve a konvertálás során.

**Telepítenem kell a célbetűtípust a rendszerbe, vagy csatolhatok egy betűtípus mappát?**

A telepítés nem szükséges: a könyvtár lehetővé teszi a [loading external fonts](/slides/hu/nodejs-java/custom-font/) a felhasználói mappákból a [rendering and export](/slides/hu/nodejs-java/convert-powerpoint/) során való használathoz.

**A csere javítja-e a "tofu"-t (négyzetek) a karakterek helyett?**

Csak akkor, ha a célbetűtípus ténylegesen tartalmazza a szükséges gliffeket. Ha nem, akkor [configure fallback](/slides/hu/nodejs-java/fallback-font/) a hiányzó karakterek lefedéséhez.