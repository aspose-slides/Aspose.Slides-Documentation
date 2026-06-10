---
title: PHP-ban a tartalék betűkészlet-gyűjtemények konfigurálása
linktitle: Tartalék betűkészlet-gyűjtemény
type: docs
weight: 20
url: /hu/php-java/create-fallback-fonts-collection/
keywords:
- tartalék betűkészlet
- tartalék szabály
- betűkészlet-gyűjtemény
- betűkészlet konfigurálása
- betűkészlet beállítása
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Állítson be egy tartalék betűkészlet-gyűjteményt az Aspose.Slides for PHP Java-on keresztül, hogy a szöveg konzisztens és éles maradjon a PowerPoint és az OpenDocument prezentációkban."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy egy prezentációhoz konfiguráljon egy tartalék betűkészlet-szabályok gyűjteményét. Minden tartalék szabályt a `FontFallBackRule` osztály képviseli, és hozzáadható egy `FontFallBackRulesCollection`-hoz.

A gyűjtemény létrehozása után a prezentáció `FontsManager`-ának `setFontFallBackRulesCollection` metódusával rendelhetjük hozzá. A `FontsManager` kezeli a betűkészleteket a teljes prezentációban, és minden `Presentation` példány saját `FontsManager`-rel rendelkezik.

Miután a `FontsManager` inicializálva van a tartalék betűkészlet-gyűjteménnyel, a megadott tartalék betűkészletek alkalmazásra kerülnek a prezentáció renderelése során.

## **Tartalék Szabályok Alkalmazása**

A [FontFallBackRule](https://reference.aspose.com/slides/hu/php-java/aspose.slides/FontFallBackRule) osztály példányai szervezhetők egy [FontFallBackRulesCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/FontFallBackRulesCollection) összegyűjtésébe. Lehet szabályokat hozzáadni vagy eltávolítani a gyűjteményből.

Ezután ez a gyűjtemény a [FontsManager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/FontsManager) osztály [FontFallBackRulesCollection](https://reference.aspose.com/slides/hu/php-java/aspose.slides/FontFallBackRulesCollection) metódusához rendelhető. A FontsManager kezeli a betűkészleteket a teljes prezentációban.

Minden [Presentation](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation) rendelkezik egy [getFontsManager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation#getFontsManager) metódussal, amely saját [FontsManager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/FontsManager) példányt tartalmaz.

Itt egy példa arra, hogyan hozhatunk létre tartalék betűkészlet-szabályok gyűjteményt, és rendeljük hozzá egy adott prezentáció [FontsManager](https://reference.aspose.com/slides/hu/php-java/aspose.slides/Presentation#getFontsManager)‑éhez:
```php
  $pres = new Presentation();
  try {
    $userRulesList = new FontFallBackRulesCollection();
    $userRulesList->add(new FontFallBackRule(0xb80, 0xbff, "Vijaya"));
    $userRulesList->add(new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic"));
    $pres->getFontsManager()->setFontFallBackRulesCollection($userRulesList);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Miután a FontsManager inicializálva van a tartalék betűkészlet-gyűjteménnyel, a tartalék betűkészletek a prezentáció renderelése során alkalmazásra kerülnek.

{{% alert color="primary" %}} 
Olvasson tovább arról, hogyan [Prezentáció renderelése tartalék betűkészlettel](/slides/hu/php-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **GYIK**

**A tartalék szabályaim be lesznek ágyazva a PPTX fájlba, és a mentés után láthatóak lesznek a PowerPointban?**

Nem. A tartalék szabályok futásidejű renderelési beállítások; nem kerülnek sorosításra a PPTX-be, és nem jelennek meg a PowerPoint felhasználói felületén.

**A tartalék alkalmazásra kerül a SmartArt, WordArt, diagramok és táblázatok szövegére is?**

Igen. Ugyanazt a glif-helyettesítési mechanizmust használják ezekben az objektumokban lévő minden szöveghez.

**Az Aspose terjeszt-e bármilyen betűkészletet a könyvtárral együtt?**

Nem. Ön adja hozzá és használja a betűkészleteket a saját oldalán, saját felelősségére.

**Használható együtt a hiányzó betűkészletek helyettesítése/helycseréje és a hiányzó glifek tartaléka?**

Igen. Ezek a betűkészlet-felbontási folyamat független szakaszai: először a motor feloldja a betűkészlet elérhetőségét ([replacement](/slides/hu/php-java/font-replacement/)/[substitution](/slides/hu/php-java/font-substitution/)), majd a tartalék kitölti a hiányzó glifek hiányát az elérhető betűkészletekben.