---
title: Visszaeső betűtípus-gyűjtemények konfigurálása Java-ban
linktitle: Visszaeső betűtípus-gyűjtemény
type: docs
weight: 20
url: /hu/java/create-fallback-fonts-collection/
keywords:
- visszaeső betűtípus
- visszaeső szabály
- betűtípus-gyűjtemény
- betűtípus konfigurálása
- betűtípus beállítása
- PowerPoint
- OpenDocument
- bemutató
- Java
- Aspose.Slides
description: "Állítsa be a visszaeső betűtípus-gyűjteményt az Aspose.Slides for Java-ban, hogy a szöveg konzisztens és éles legyen a PowerPoint és OpenDocument bemutatókban."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy egy bemutatóhoz egy visszaeső betűtípus szabályok gyűjteményét konfigurálja. Minden visszaeső szabályt a `FontFallBackRule` osztály képvisel, és hozzáadható egy `FontFallBackRulesCollection` gyűjteményhez, amely megvalósítja az `IFontFallBackRulesCollection` interfészt.

A gyűjtemény létrehozása után hozzárendelhető a bemutató `FontsManager`‑ének `FontFallBackRulesCollection` tulajdonságához. A `FontsManager` a betűtípusokat kezeli a teljes bemutatóban, és minden `Presentation` példánynak saját `FontsManager`‑e van.

Miután a `FontsManager` inicializálva van a visszaeső betűtípus-gyűjteménnyel, a megadott visszaeső betűtípusok a bemutató renderelése során alkalmazásra kerülnek.

## **Alkalmazzon visszaeső szabályokat**

A [FontFallBackRule](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontFallBackRule) osztály példányai szervezhetők a [FontFallBackRulesCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontFallBackRulesCollection) gyűjteménybe, amely megvalósítja a [IFontFallBackRulesCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IFontFallBackRulesCollection) interfészt. A szabályok hozzáadhatók vagy eltávolíthatók a gyűjteményből.

Ezután a gyűjtemény hozzárendelhető a [FontFallBackRulesCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontFallBackRulesCollection) metódushoz a [FontsManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontsManager) osztályban. A FontsManager kezeli a betűtípusokat a bemutatóban.

Minden [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) rendelkezik egy [getFontsManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation#getFontsManager--) metódussal, amely a saját [FontsManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FontsManager) példányát adja.

Az alábbiakban bemutatunk egy példát arra, hogyan hozhat létre visszaeső betűtípus szabályok gyűjteményét, és hogyan rendelheti hozzá a [FontsManager](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation#getFontsManager--) egy adott bemutatóhoz:  

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

    userRulesList.add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
    userRulesList.add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

    pres.getFontsManager().setFontFallBackRulesCollection(userRulesList);
} finally {
    if (pres != null) pres.dispose();
}
```

Miután a FontsManager inicializálva van a visszaeső betűtípus-gyűjteménnyel, a visszaeső betűtípusok a bemutató renderelése során alkalmazásra kerülnek.

{{% alert color="info" %}} 
Olvasson további információkat arról, hogyan [Render Presentation with Fallback Font](/slides/hu/java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **GYIK**

### Beágyazódnak a visszaeső szabályok a PPTX fájlba, és láthatóak lesznek a PowerPointban a mentés után?

Nem. A visszaeső szabályok futásidejű renderelési beállítások; nem sorosíthatók be a PPTX‑be, és nem jelennek meg a PowerPoint felületén.

### A visszaeső szabályok érvényesek-e a SmartArt, WordArt, diagramok és táblázatok szövegeire?

Igen. Ugyanazt a glif‑helyettesítési mechanizmust használják minden ilyen objektumban lévő szöveghez.

### Az Aspose terjeszt-e bármilyen betűtípust a könyvtárral együtt?

Nem. A betűtípusokat saját magának kell hozzáadnia és saját felelősségére használni.

### A hiányzó betűtípusok helyettesítése/substitúciója és a hiányzó glifek visszaesése együtt használható-e?

Igen. Ezek egymástól független szakaszok ugyanabban a betűtípus‑feloldási folyamatban: először a motor megoldja a betűtípus‑elérhetőséget ([replacement](/slides/hu/java/font-replacement/)/[substitution](/slides/hu/java/font-substitution/)), majd a visszaeső szabályok pótolják a hiányzó glifeket a rendelkezésre álló betűtípusokban.