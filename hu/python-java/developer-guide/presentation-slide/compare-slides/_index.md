---
title: Diavetítési diák összehasonlítása Pythonban
linktitle: Diák összehasonlítása
type: docs
weight: 50
url: /hu/python-java/compare-slides/
keywords:
- diák összehasonlítása
- dia összehasonlítás
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Programozott módon hasonlítsa össze a PowerPoint és OpenDocument prezentációkat az Aspose.Slides for Python via Java segítségével. Gyorsan azonosítsa a diák közötti különbségeket a kódban."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi diák, elrendezési diák és mesterdiák összehasonlítását a [BaseSlide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseslide/) osztály által biztosított [equals](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseslide/#equals) metódus segítségével. Ez a metódus `True` értéket ad vissza, ha a összehasonlított diák szerkezetükben és statikus tartalmukban azonosak.

## **Két dia összehasonlítása**

A [BaseSlide](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseslide/) osztály [equals](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseslide/#equals) metódusa `True` értéket ad vissza olyan diák, elrendezési diák és mesterdiák esetén, amelyek szerkezetükben és statikus tartalmukban azonosak.

Két dia egyenlő, ha minden alakzatuk, stílusuk, szövegük, animációik és egyéb beállításaik megegyeznek. Az összehasonlítás nem veszi figyelembe az egyedi azonosító értékeket, például a dia ID-ket, vagy a dinamikus tartalmat, például egy dátumhelyőrző aktuális dátumát.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

source_presentation = Presentation("AccessSlides.pptx")
try:
    target_presentation = Presentation("HelloWorld.pptx")
    try:
        for i in range(source_presentation.getMasters().size()):
            for j in range(target_presentation.getMasters().size()):
                if source_presentation.getMasters().get_Item(i).equals(target_presentation.getMasters().get_Item(j)):
                    print(f"AccessSlides MasterSlide#{i} is equal to HelloWorld MasterSlide#{j}")
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **GYIK**

**Azt befolyásolja-e, hogy egy dia rejtett, a diák közötti összehasonlítást?**

A [Hidden status](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slide/#getHidden) egy prezentáció/lejátszási szintű tulajdonság, nem vizuális tartalom. Két adott dia egyenlősége a szerkezetükön és statikus tartalmukon alapul; a dia rejtett állapota önmagában nem teszi a diákat különbözővé.

**Figyelembe veszik-e a hiperhivatkozásokat és azok paramétereit?**

Igen. A hivatkozások a dia statikus tartalmának részei. Ha az URL vagy a hiperlink-művelet eltér, azt általában a statikus tartalom különbségeként kezelik.

**Ha egy diagram külső Excel fájlra hivatkozik, figyelembe veszik-e annak tartalmát?**

Nem. Az összehasonlítás a diákon magukon alapul. A külső adatforrások általában nem kerülnek beolvasásra az összehasonlítás során; csak a dia szerkezetében és statikus állapotában jelen lévő elemeket veszik figyelembe.