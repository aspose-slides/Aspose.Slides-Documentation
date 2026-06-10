---
title: PowerPoint-prezentációk konvertálása animált GIF-ekre C++-ban
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
description: "Könnyedén konvertálja a PowerPoint-prezentációkat (PPT, PPTX) animált GIF-ekre az Aspose.Slides for C++ segítségével. Gyors, magas minőségű eredmények."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy néhány sor kóddal PowerPoint‑prezentációkat animált GIF‑fájlokká konvertáljon. Ez akkor hasznos, amikor a diák tartalmát könnyű, széles körben támogatott animált formátumban szeretné megosztani, amely beágyazható weboldalakba, üzenetküldő alkalmazásokba vagy dokumentációba. Ez a cikk bemutatja, hogyan exportáljon egy prezentációt GIF‑be alapértelmezett beállításokkal, valamint hogyan szabhatja testre a kimenetet olyan opciók konfigurálásával, mint a keretméret, a dia késleltetése és az átmeneti képkocka rátája a [GifOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/gifoptions/) segítségével.

## **Prezentációk konvertálása animált GIF-re alapértelmezett beállítások használatával**

Ez a C++ mintakód megmutatja, hogyan konvertáljon egy prezentációt animált GIF‑re az alapértelmezett beállításokkal:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```

Az animált GIF az alapértelmezett paraméterekkel jön létre. 

{{%  alert  title="TIP"  color="primary"  %}} 
Ha egyéni paramétereket szeretne megadni a GIF‑hez, használja a [GifOptions](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.export.gif_options) osztályt. Lásd a lentebb található mintakódot. 
{{% /alert %}} 

## **Prezentációk konvertálása animált GIF-re egyéni beállításokkal**

Ez a mintakód megmutatja, hogyan konvertáljon egy prezentációt animált GIF‑re egyéni beállításokkal C++‑ban:

``` cpp
auto gifOptions = System::MakeObject<GifOptions>();
// a létrehozott GIF mérete 
gifOptions->set_FrameSize(Size(960, 720));
// mennyi ideig jelenik meg minden dia, amíg a következőre vált
gifOptions->set_DefaultDelay(2000);
// növelje az FPS-t a jobb átmeneti animáció minőségéhez
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```

{{% alert title="Info" color="info" %}}
Érdemes kipróbálni az Aspose által fejlesztett INGYENES [Text to GIF](https://products.aspose.app/slides/hu/text-to-gif) konvertálót. 
{{% /alert %}}

## **GYIK**

**Mi van, ha a prezentációban használt betűtípusok nincsenek telepítve a rendszerre?**

Telepítse a hiányzó betűtípusokat vagy [állítsa be a helyettesítő betűtípusokat](/slides/hu/cpp/powerpoint-fonts/). Az Aspose.Slides helyettesíti őket, de a megjelenés eltérhet. Márkázás esetén mindig gondoskodjon arról, hogy a szükséges betűkészletek kifejezetten elérhetőek legyenek.

**Tegyek vízjelet a GIF képkockákra?**

Igen. [Adj hozzá félátlátszó objektumot/logót](/slides/hu/cpp/watermark/) a mattáborra vagy az egyes diákhoz az exportálás előtt – a vízjel minden képkockán megjelenik.