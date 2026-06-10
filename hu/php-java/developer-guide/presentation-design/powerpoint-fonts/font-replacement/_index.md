---
title: Betűtípuscsere egyszerűsítése prezentációkban PHP használatával
linktitle: Betűtípuscsere
type: docs
weight: 60
url: /hu/php-java/font-replacement/
keywords:
- betűtípus
- betűtípus cseréje
- betűtípus csere
- betűtípus módosítása
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Zökkenőmentesen cserélje a betűtípusokat az Aspose.Slides for PHP-ben Java segítségével, hogy következetes tipográfiát biztosítson a PowerPoint és OpenDocument prezentációkban."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy egy betűtípust egy másikra cseréljen a teljes bemutatóban. Amikor egy betűtípust cserélnek, az eredeti betűtípus minden előfordulása az új betűtípusra változik.

A betűtípus csere végrehajtásához töltse be a bemutatót, határozza meg a forrás‑betűtípust és a helyettesítő betűtípust, hívja meg a betűtípus csere metódust, és mentse a módosított bemutatót PPTX fájlként. Ez a megközelítés hasznos, ha szándékosan szeretne egy betűtípus‑családról egy másikra váltani a teljes bemutatóban.

## **Betűtípusok cseréje**

Ha meggondolja magát egy betűtípus használatával kapcsolatban, lecserélheti azt egy másik betűtípusra. Az összes régi betűtípus előfordulása az újjal lesz helyettesítve.

Az Aspose.Slides a következő módon teszi lehetővé a betűtípus cseréjét:

1. Töltse be a megfelelő bemutatót.  
2. Töltse be a cserélendő betűtípust.  
3. Töltse be az új betűtípust.  
4. Cserélje le a betűtípust.  
5. Írja ki a módosított bemutatót PPTX fájlként.  

Ez a PHP kód demonstrálja a betűtípus cserét:

```php
  # Betölt egy prezentációt
  $pres = new Presentation("Fonts.pptx");
  try {
    # Betölti a cserélendő forrásbetűtípust
    $sourceFont = new FontData("Arial");
    # Betölti az új betűtípust
    $destFont = new FontData("Times New Roman");
    # Lecseréli a betűtípusokat
    $pres->getFontsManager()->replaceFont($sourceFont, $destFont);
    # Elmenti a prezentációt
    $pres->save("UpdatedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Megjegyzés" color="warning" %}} 

Az bizonyos feltételekben (például ha egy betűtípus nem érhető el) bekövetkező események szabályainak beállításához lásd a [**Font Substitution**](/slides/hu/php-java/font-substitution/) oldalt.

{{% /alert %}}

## **Gyakran Ismételt Kérdések**

**Mi a különbség a „font replacement”, a „font substitution” és a „fallback fonts” között?**

A replacement egy szándékos váltás egy családról a másikra a teljes dokumentumban. [Substitution](/slides/hu/php-java/font-substitution/) egy szabály, például „ha a betűtípus nem érhető el, használja X‑et”. [Fallback](/slides/hu/php-java/fallback-font/) egyes hiányzó glyfpekre alkalmazott, amikor az alapbetűtípus telepítve van, de nem tartalmazza a szükséges karaktereket.

**Érvényesül a csere a mesterdiákra, elrendezésekre, jegyzetekre és megjegyzésekre?**

Igen. A csere hatással van minden olyan prezentációobjektumra, amely az eredeti betűtípust használja, beleértve a mesterdiákat és a jegyzeteket; a megjegyzések is a dokumentum részei, és a betűtípus motor figyelembe veszi őket.

**Módosul a betűtípus a beágyazott OLE objektumokban (például Excelben)?**

Nem. Az [OLE content](/slides/hu/php-java/manage-ole/) saját alkalmazása által vezérelt. A prezentációban végzett csere nem formázza újra a belső OLE adatokat; azok képként vagy külsőleg szerkeszthető tartalomként jelenhetnek meg.

**Lecserélhetek egy betűtípust csak a bemutató egy részén (dia vagy terület szerint)?**

Célzott csere lehetséges, ha a betűtípust a szükséges objektumok/hatókörök szintjén módosítja ahelyett, hogy globális cserét alkalmazna a teljes dokumentumra. A renderelés során a betűtípus kiválasztási logikája változatlan marad.

**Hogyan tudom előre meghatározni, hogy a bemutató mely betűtípusokat használ?**

Használja a prezentáció [font manager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsmanager/)-ét: ez felsorolja a használt [families in use](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsmanager/getfonts/) és információt ad a [substitutions/"unknown" fonts](https://reference.aspose.com/slides/hu/php-java/aspose.slides/fontsmanager/getsubstitutions/)-ről, ami segít a csere megtervezésében.

**Működik a betűtípus csere PDF‑/kép‑konvertáláskor?**

Igen. Exportálás közben az Aspose.Slides ugyanazt a [font selection/substitution sequence](/slides/hu/php-java/font-selection-sequence/) alkalmazza, így a előzetesen végzett csere a konverzió során is érvényesül.

**Telepíteni kell a cél‑betűtípust a rendszerbe, vagy csatolhatok egy betűtípus‑mappát?**

Telepítés nem szükséges: a könyvtár lehetővé teszi a [loading external fonts](/slides/hu/php-java/custom-font/) betöltését felhasználói mappákból a [rendering and export](/slides/hu/php-java/convert-powerpoint/) során.

**Megoldja a csere a „tofu” (négyzet) jelenséget a karakterek helyett?**

Csak akkor, ha a célnak megfelelő betűtípus valóban tartalmazza a szükséges glifpeket. Ha nem, akkor [configure fallback](/slides/hu/php-java/fallback-font/) segítségével kell lefedni a hiányzó karaktereket.