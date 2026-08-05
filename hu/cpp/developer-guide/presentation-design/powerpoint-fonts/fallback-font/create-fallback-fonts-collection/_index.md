---
title: Helyettesítő betűtípus-gyűjtemények konfigurálása C++-ban
linktitle: Helyettesítő betűtípus-gyűjtemény
type: docs
weight: 20
url: /hu/cpp/create-fallback-fonts-collection/
keywords:
- helyettesítő betűtípus
- helyettesítő szabály
- betűtípus-gyűjtemény
- betűtípus konfigurálása
- betűtípus beállítása
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Állítson be egy helyettesítő betűtípus-gyűjteményt az Aspose.Slides C++-hoz, hogy a szöveg konzisztens és éles maradjon a PowerPoint és OpenDocument prezentációkban."
---
## **Áttekintés**

Aspose.Slides lehetővé teszi, hogy egy prezentációhoz egy helyettesítő betűtípus szabályok gyűjteményét konfigurálja. Minden helyettesítő szabályt a `FontFallBackRule` osztály képviseli, és hozzáadható egy `FontFallBackRulesCollection`-höz, amely megvalósítja az `IFontFallBackRulesCollection` interfészt.

A gyűjtemény létrehozása után a prezentáció `FontsManager`-ének `set_FontFallBackRulesCollection` metódusával lehet hozzárendelni. A `FontsManager` kezeli a betűtípusokat a teljes prezentációban, és minden `Presentation` példánynak saját `FontsManager`-e van.

Miután a `FontsManager` a helyettesítő betűtípus gyűjteménnyel inicializálva lett, a megadott helyettesítő betűtípusok a prezentáció renderelése során alkalmazásra kerülnek.

## **Helyettesítő szabályok alkalmazása**

A [FontFallBackRule](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontfallbackrule/) osztály példányait a [FontFallBackRulesCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontfallbackrulescollection/) gyűjteménybe lehet rendezni, amely megvalósítja a [IFontFallBackRulesCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifontfallbackrulescollection/) interfészt. Lehet szabályokat hozzáadni vagy eltávolítani a gyűjteményből.

Ezután a gyűjteményt át lehet adni a [set_FontFallBackRulesCollection()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsmanager/set_fontfallbackrulescollection/) metódusnak a [FontsManager](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsmanager/) osztályban. A FontsManager kezeli a betűtípusokat a prezentációban.

Minden [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) rendelkezik egy [get_FontsManager()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_fontsmanager/) metódussal, amely saját FontsManager példányt ad vissza.

Az alábbiakban egy példa látható a helyettesítő betűtípus szabályok gyűjteményének létrehozására és a FontsManager megfelelő prezentációba való beállítására:

``` cpp
auto presentation = MakeObject<Presentation>();
auto userRulesList = MakeObject<FontFallBackRulesCollection>();

userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x0B80), static_cast<uint32_t>(0x0BFF), u"Vijaya"));
userRulesList->Add(MakeObject<FontFallBackRule>(static_cast<uint32_t>(0x3040), static_cast<uint32_t>(0x309F), u"MS Mincho, MS Gothic"));

presentation->get_FontsManager()->set_FontFallBackRulesCollection(userRulesList);
```

Miután a FontsManager inicializálva lett a helyettesítő betűtípus gyűjteménnyel, a helyettesítő betűtípusok a prezentáció renderelése során alkalmazásra kerülnek.

{{% alert color="primary" %}} 
További információk a [Prezentáció renderelése helyettesítő betűtípussal](/slides/hu/cpp/render-presentation-with-fallback-font/).
{{% /alert %}}

## **GYIK**

**Be lesznek ágyazva a helyettesítő szabályok a PPTX fájlba, és láthatók lesznek a PowerPointban a mentés után?**

Nem. A helyettesítő szabályok futásidejű renderelési beállítások, nem kerülnek sorosítva a PPTX-be, ezért nem jelennek meg a PowerPoint felhasználói felületén.

**A helyettesítés érvényesül-e a SmartArt, WordArt, diagramok és táblázatok szövegeinél?**

Igen. Ugyanazt a glifcsere‑mechanizmust használják minden szöveghez ezekben a objektumokban.

**Az Aspose terjeszt-e bármilyen betűtípust a könyvtárral együtt?**

Nem. A betűtípusokat saját oldaladon kell hozzáadni és saját felelősségeden használni.

**Használható-e egyszerre a hiányzó betűtípusok helyettesítése/substitúciója és a hiányzó glifek helyettesítése?**

Igen. Ezek a betűtípus‑feloldási folyamat független szakaszai: először a motor feloldja a betűtípus elérhetőségét ([replacement](/slides/hu/cpp/font-replacement/)/[substitution](/slides/hu/cpp/font-substitution/)), majd a helyettesítés kitölti a hiányzó glifek lyukait az elérhető betűtípusokban.