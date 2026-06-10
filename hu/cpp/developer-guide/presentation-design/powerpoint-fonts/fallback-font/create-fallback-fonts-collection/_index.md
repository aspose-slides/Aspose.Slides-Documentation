---
title: "Fallback betűtípus-gyűjtemények beállítása C++-ban"
linktitle: "Fallback betűtípus-gyűjtemény"
type: docs
weight: 20
url: /hu/cpp/create-fallback-fonts-collection/
keywords:
- fallback betűtípus
- fallback szabály
- betűtípus-gyűjtemény
- betűtípus beállítása
- betűtípus konfigurálása
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Állítsa be a fallback betűtípus-gyűjteményt az Aspose.Slides C++-ban, hogy a szöveg konzisztens és éles maradjon a PowerPoint és OpenDocument prezentációkban."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy egy prezentációhoz fallback betűtípus szabályok gyűjteményét konfigurálja. Minden fallback szabályt a `FontFallBackRule` osztály képviseli, és hozzáadható egy `FontFallBackRulesCollection`-hoz, amely megvalósítja az `IFontFallBackRulesCollection` interfészt.

A gyűjtemény létrehozása után a prezentáció `FontsManager`-ének a `set_FontFallBackRulesCollection` metódusával rendelheti hozzá. A `FontsManager` kezeli a betűtípusokat a teljes prezentációban, és minden `Presentation` példánynak saját `FontsManager`-e van.

Miután a `FontsManager` inicializálva van a fallback betűtípus-gyűjteménnyel, a megadott fallback betűtípusok a prezentáció renderelése során alkalmazásra kerülnek.

## **Alkalmazza a fallback szabályokat**

A [FontFallBackRule](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontfallbackrule/) osztály példányai szervezhetők a [FontFallBackRulesCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontfallbackrulescollection/) gyűjteménybe, amely megvalósítja az [IFontFallBackRulesCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifontfallbackrulescollection/) interfészt. Lehetőség van szabályok hozzáadására vagy eltávolítására a gyűjteményből.

Ezután ez a gyűjtemény átadható a [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) metódusnak a [FontsManager](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsmanager/) osztályban. A FontsManager kezeli a betűtípusokat a teljes prezentációban.

Minden [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) rendelkezik egy [get_FontsManager()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_fontsmanager/) metódussal, amelynek saját példánya van a FontsManager osztálynak.

Itt egy példa arra, hogyan hozhatunk létre fallback betűtípus szabályok gyűjteményét, és hogyan rendeljük hozzá egy adott prezentáció FontsManager-éhez:  

``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

Miután a FontsManager inicializálva van a fallback betűtípus-gyűjteménnyel, a fallback betűtípusok a prezentáció renderelése során alkalmazásra kerülnek.

{{% alert color="primary" %}} 
Olvasson tovább, hogyan [rendereljünk prezentációt fallback betűtípussal](/slides/hu/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}

## **GYIK**

**Beágyazódnak a fallback szabályaim a PPTX fájlba, és láthatóak lesznek a PowerPointban mentés után?**

Nem. A fallback szabályok futásidejű renderelési beállítások; nem sorosítódnak a PPTX-be, ezért nem jelennek meg a PowerPoint felhasználói felületén.

**A fallback alkalmazható a SmartArt, WordArt, diagramok és táblázatok belső szövegére?**

Igen. Ugyanazt a glif-helyettesítési mechanizmust használják minden ilyen objektumban lévő szöveghez.

**Az Aspose terjeszt-e betűtípusokat a könyvtárral?**

Nem. A betűtípusokat saját maga adja hozzá és használja, saját felelősségére.

**Használható együtt a hiányzó betűtípusok helyettesítése/helycsere és a hiányzó glifek fallback-je?**

Igen. Ezek a betűtípus-felbontási folyamat független szakaszai: először a motor feloldja a betűtípusok elérhetőségét ([replacement](/slides/hu/cpp/font-replacement/)/[substitution](/slides/hu/cpp/font-substitution/)), majd a fallback pótolja a hiányzó glifek helyét az elérhető betűtípusokban.