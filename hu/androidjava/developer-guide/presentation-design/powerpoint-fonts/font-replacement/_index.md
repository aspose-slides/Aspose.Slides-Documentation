---
title: A betűtípusok lecserélésének egyszerűsítése Androidon
linktitle: Betűtípus csere
type: docs
weight: 60
url: /hu/androidjava/font-replacement/
keywords:
- betűtípus
- betűtípus cseréje
- betűtípus csere
- betűtípus módosítása
- PowerPoint
- OpenDocument
- bemutató
- Android
- Java
- Aspose.Slides
description: "Zökkenőmentesen cserélje le a betűtípusokat az Aspose.Slides for Android Java segítségével, hogy konzisztens tipográfiát biztosítson a PowerPoint és OpenDocument bemutatókban."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy egy betűtípust egy másikkal cseréljen le a teljes bemutatóban. Amikor egy betűtípust lecserélnek, az eredeti betűtípus minden előfordulása az új betűtípusra módosul.

A betűtípuscsere elvégzéséhez töltse be a bemutatót, határozza meg a forrás‑ és a csere‑betűtípust, hívja meg a betűtípuscserélő metódust, majd mentse a módosított bemutatót PPTX fájlként. Ez a megközelítés akkor hasznos, ha szándékosan egy betűtípus‑családot szeretne egy másikra cserélni a bemutató teljes terjedelmében.

## **Betűtípusok cseréje**

Ha meggondolja magát egy betűtípussal kapcsolatban, kicserélheti azt egy másikra. A régi betűtípus minden előfordulása az új betűtípusra kerül.

Az Aspose.Slides ezzel a módon teszi lehetővé a betűtípus cseréjét:

1. Töltse be a megfelelő bemutatót.  
2. Töltse be a lecserélendő betűtípust.  
3. Töltse be az új betűtípust.  
4. Cserélje le a betűtípust.  
5. Írja ki a módosított bemutatót PPTX fájlként.

Ez a Java‑kód mutatja be a betűtípuscsere folyamatát:

```java
// Betölt egy bemutatót
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Betölti a cserélendő forrás betűtípust
    IFontData sourceFont = new FontData("Arial");
    
    // Betölt egy új betűtípust
    IFontData destFont = new FontData("Times New Roman");
    
    // Lecseréli a betűtípusokat
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    
    // Ment egy bemutatót
    pres.save("UpdatedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Megjegyzés" color="warning" %}} 

A különböző feltételek (például ha egy betűtípus nem érhető el) esetén alkalmazandó szabályok beállításához lásd a [**Betűtípus helyettesítés**](/slides/hu/androidjava/font-substitution/) témakört.

{{% /alert %}}

## **GYIK**

**Mi a különbség a „betűtípus csere”, a „betűtípus helyettesítés” és a „tartalék betűtípusok” között?**

A csere szándékos váltás egy betűtípus‑családról egy másikra a teljes dokumentumban. A [Helyettesítés](/slides/hu/androidjava/font-substitution/) egy olyan szabály, mint például „ha a betűtípus nem érhető el, használja X‑et”. A [Tartalék betűtípus](/slides/hu/androidjava/fallback-font/) egyedi, hiányzó karakterekre alkalmazott megoldás, amikor az alapbetűtípus telepítve van, de nem tartalmazza a szükséges karaktereket.

**Érvényesül-e a csere a mester diákra, elrendezésekre, jegyzetekre és megjegyzésekre?**

Igen. A csere minden olyan prezentációs objektumra hat, amely az eredeti betűtípust használja, beleértve a mester diákat és a jegyzeteket; a megjegyzések is a dokumentum részei, és a betűtípus‑motor figyelembe veszi őket.

**Megváltozik-e a betűtípus a beágyazott OLE objektumokban (például Excel)?**

Nem. Az [OLE tartalom](/slides/hu/androidjava/manage-ole/) saját alkalmazása által van vezérelve. A prezentációban végzett csere nem formázza át a belső OLE adatokat; azok képként vagy külsőleg szerkeszthető tartalomként jelenhetnek meg.

**Lecserélhetem-e a betűtípust csak a bemutató egy részére (diák vagy területek szerint)?**

Célzott cserére van lehetőség, ha a betűtípust a szükséges objektumok/tartományok szintjén módosítja, ahelyett, hogy globálisan alkalmazná a dokumentum egészére. A renderelés során használt betűtípus‑kiválasztási logika továbbra is ugyanaz marad.

**Hogyan tudom előre meghatározni, hogy a bemutató milyen betűtípusokat használ?**

Használja a bemutató [betűtípus‑kezelőjét](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsmanager/): ez listát ad a [használt családokról](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsmanager/#getFonts--) és információt nyújt a [helyettesítésekről/„ismeretlen” betűtípusokról](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/fontsmanager/#getSubstitutions--), ami segít a csere megtervezésében.

**Működik-e a betűtípuscsere PDF‑/kép‑konverzió során?**

Igen. Exportáláskor az Aspose.Slides ugyanazt a [betűtípus‑kiválasztási/helyettesítési sorrendet](/slides/hu/androidjava/font-selection-sequence/) alkalmazza, így a előre végzett csere a konverzió során is megtartásra kerül.

**Telepíteni kell a cél‑betűtípust a rendszerre, vagy elég egy betűtípus‑mappa csatolása?**

Telepítés nem szükséges: a könyvtár lehetővé teszi a [külső betűtípusok betöltését](/slides/hu/androidjava/custom-font/) felhasználói mappákból, amelyeket a [renderelés és export](/slides/hu/androidjava/convert-powerpoint/) során használhat.

**Megoldja‑e a csere a „tofu” (négyzet) karakterek problémáját?**

Csak akkor, ha a cél‑betűtípus valóban tartalmazza a szükséges glifeket. Ha nem, [állítsa be a tartalék betűtípust](/slides/hu/androidjava/fallback-font/) a hiányzó karakterek lefedéséhez.