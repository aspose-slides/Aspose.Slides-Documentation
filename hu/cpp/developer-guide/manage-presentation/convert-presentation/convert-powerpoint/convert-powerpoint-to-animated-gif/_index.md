---
title: PowerPoint prezentációk konvertálása animált GIF-ekbe C++-ban
linktitle: PowerPoint GIF-re
type: docs
weight: 65
url: /hu/cpp/convert-powerpoint-to-animated-gif/
keywords:
- animált GIF
- PowerPoint konvertálása
- prezentáció konvertálása
- dia konvertálása
- PPT konvertálása
- PPTX konvertálása
- PowerPoint GIF-re
- prezentáció GIF-re
- dia GIF-re
- PPT GIF-re
- PPTX GIF-re
- PPT mentése GIF-ként
- PPTX mentése GIF-ként
- PPT exportálása GIF-ként
- PPTX exportálása GIF-ként
- alapértelmezett beállítások
- egyéni beállítások
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Könnyedén konvertálja a PowerPoint prezentációkat (PPT, PPTX) animált GIF-ekre az Aspose.Slides for C++ segítségével. Gyors, magas minőségű eredmények."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy néhány sor kóddal PowerPoint‑prezentációkat animált GIF fájlokká konvertáljon. Ez akkor hasznos, ha a diák tartalmát könnyű, széles körben támogatott animált formátumban szeretné megosztani, amely beágyazható weboldalakba, üzenetküldő alkalmazásokba vagy dokumentációba. Ez a cikk bemutatja, hogyan exportáljon egy prezentációt GIF‑be az alapértelmezett beállításokkal, valamint hogyan szabhatja testre a kimenetet a keretméret, a dia késleltetés és az átmeneti képkocka‑sebesség beállításával a [GifOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/gifoptions/) segítségével.

## **Prezentációk konvertálása animált GIF‑be alapértelmezett beállításokkal**

Ez a C++ példakód megmutatja, hogyan konvertáljon egy prezentációt animált GIF‑be az alapértelmezett beállításokkal:

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```

Az animált GIF az alapértelmezett paraméterekkel lesz létrehozva. 

{{%  alert  title="TIP"  color="info"  %}} 

Ha egyedi paramétereket szeretne megadni a GIF‑hez, használja a [GifOptions](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.export.gif_options) osztályt. Lásd a lenti példakódot. 

{{% /alert %}} 

## **Prezentációk konvertálása animált GIF‑be egyéni beállításokkal**

Ez a példakód megmutatja, hogyan konvertáljon egy prezentációt animált GIF‑be egyéni beállításokkal C++‑ban:

``` cpp
#include <DOM/Presentation.h>
#include <Export/GifOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/size.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto gifOptions = System::MakeObject<GifOptions>();
// az eredményül kapott GIF mérete
gifOptions->set_FrameSize(System::Drawing::Size(960, 720));
// mennyi ideig lesz egy dia látható, amíg a következőre nem vált
gifOptions->set_DefaultDelay(2000);
// növelje az FPS-t a jobb átmeneti animáció minősége érdekében
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```

{{% alert title="Info" color="info" %}}

Érdemes kipróbálni az Aspose által fejlesztett INGYENES [Text to GIF](https://products.aspose.app/slides/hu/text-to-gif) konvertálót. 

{{% /alert %}}

## **GYIK**

### Mi van, ha a prezentációban használt betűtípusok nincsenek telepítve a rendszeren?

Telepítse a hiányzó betűtípusokat, vagy [állítson be tartalék betűtípusokat](/slides/hu/cpp/powerpoint-fonts/). Az Aspose.Slides helyettesíti őket, de a megjelenés eltérhet. Márkázás esetén mindig győződjön meg arról, hogy a szükséges betűkészletek kifejezetten elérhetők.

### Hozzá tudok-e adni vízjelet a GIF‑keretekhez?

Igen. [Adj hozzá félig átlátszó objektumot/logót](/slides/hu/cpp/watermark/) a mesterdiára vagy az egyes diákra az exportálás előtt – a vízjel minden képkockán megjelenik.