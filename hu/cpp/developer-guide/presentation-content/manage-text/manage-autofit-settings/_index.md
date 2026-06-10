---
title: "Fejlessze előadásait az AutoFit segítségével C++-ban"
linktitle: "Autofit beállítások"
type: docs
weight: 30
url: /hu/cpp/manage-autofit-settings/
keywords:
- "szövegmező"
- "autofit"
- "ne alkalmazzon autofit-et"
- "szöveg illesztése"
- "szöveg zsugorítása"
- "szöveg tördelése"
- "alakzat átméretezése"
- "PowerPoint"
- "OpenDocument"
- "prezentáció"
- "C++"
- "Aspose.Slides"
description: "Ismerje meg, hogyan kezelheti az AutoFit beállításokat az Aspose.Slides for C++-ban, hogy optimalizálja a szöveg megjelenítését PowerPoint és OpenDocument prezentációiban, és javítsa a tartalom olvashatóságát."
---
## **Bevezetés**

Alapértelmezés szerint, amikor szövegmezőt ad hozzá, a Microsoft PowerPoint a szövegmezőhöz a **Resize shape to fix text** beállítást használja – automatikusan átméretezi a szövegmezőt, hogy a szöveg mindig beleférjen.

![szövegmező PowerPointban](textbox-in-powerpoint.png)

* Ha a szöveg a szövegmezőben hosszabbá vagy nagyobbra nő, a PowerPoint automatikusan megnöveli a szövegmezőt – megnöveli a magasságát – hogy több szöveget tudjon tartalmazni.  
* Ha a szöveg a szövegmezőben rövidebbé vagy kisebbé válik, a PowerPoint automatikusan csökkenti a szövegmezőt – lecsökkenti a magasságát – hogy a felesleges helyet eltávolítsa.  

PowerPointban ezek a 4 fontos paraméter vagy beállítás irányítja a szövegmező automatikus illesztésének viselkedését:

* **Ne alkalmazzon automatikus méretezést**
* **Csökkentse a szöveget túlcsordulás esetén**
* **Átméretezze az alakzatot a szöveghez igazítva**
* **Tördelje a szöveget az alakzatban.**

![autofit opciók PowerPointban](autofit-options-powerpoint.png)

Az Aspose.Slides for C++ hasonló beállításokat biztosít – néhány metódus a [TextFrameFormat](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.text_frame_format) osztályban – amelyekkel vezérelheti a szövegmezők automatikus illesztésének viselkedését a bemutatókban.

## **Átméretezze az alakzatot a szöveghez igazítva**

Ha azt szeretné, hogy a szöveg egy mezőben mindig beleférjen a szöveg módosítása után is, a **Resize shape to fix text** opciót kell használnia. Ennek beállításához állítsa be a [AutofitType](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) tulajdonságot (a [TextFrameFormat](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.text_frame_format) osztályból) **Shape** értékre.

![alwaysfit beállítás PowerPointban](alwaysfit-setting-powerpoint.png)

Ez a C++ kód megmutatja, hogyan adhatja meg, hogy a szöveg mindig beleférjen a dobozába egy PowerPoint bemutatóban:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::Shape);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

Ha a szöveg hosszabbá vagy nagyobbra válik, a szövegmező automatikusan átméreteződik (magasság növekszik), hogy az összes szöveg elférjen benne. Ha a szöveg rövidebbé válik, a folyamat fordított irányban működik.

## **Ne alkalmazzon automatikus méretezést**

Ha azt szeretné, hogy egy szövegmező vagy alakzat megtartsa méreteit függetlenül attól, hogy a benne lévő szöveg hogyan változik, a **Do not Autofit** opciót kell használnia. Ennek beállításához állítsa be a [AutofitType](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) tulajdonságot (a [TextFrameFormat](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.text_frame_format) osztályból) **None** értékre.

![donotautofit beállítás PowerPointban](donotautofit-setting-powerpoint.png)

Ez a C++ kód megmutatja, hogyan adhatja meg, hogy egy szövegmező megtartsa a méreteit egy PowerPoint bemutatóban:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::None);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

Amikor a szöveg túl hosszú lesz a mezőhöz képest, kilóg belőle.

## **Csökkentse a szöveget túlcsordulás esetén**

Ha egy szöveg túl hosszú lesz a mezőhöz képest, a **Shrink text on overflow** opcióval megadhatja, hogy a szöveg méretét és távolságát csökkenteni kell a beilleszkedéshez. Ennek beállításához állítsa be a [AutofitType](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) tulajdonságot (a [TextFrameFormat](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.text_frame_format) osztályból) **Normal** értékre.

![shrinktextonoverflow beállítás PowerPointban](shrinktextonoverflow-setting-powerpoint.png)

Ez a C++ kód megmutatja, hogyan adhatja meg, hogy a szöveget túlcsorduláskor legyen lecsökkentve egy PowerPoint bemutatóban:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::Normal);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Info" color="info" %}}
Amikor a **Shrink text on overflow** opciót használják, a beállítás csak akkor lép életbe, amikor a szöveg túl hosszú lesz a mezőhöz képest.
{{% /alert %}}

## **Tördelje a szöveget**

Ha azt szeretné, hogy a szöveg egy alakzatban a szélesség határán túllépve is a forma belsejében maradjon, a **Wrap text in shape** paramétert kell használnia. Ennek beállításához állítsa be a [WrapText](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.text_frame_format#aecc980adb13e3cf7162d09f99b5bbfd1) tulajdonságot (a [TextFrameFormat](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.text_frame_format) osztályból) **true** értékre.

Ez a C++ kód megmutatja, hogyan használja a Tördelje a szöveget beállítást egy PowerPoint bemutatóban:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_WrapText(NullableBool::True);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 
Ha a `WrapText` tulajdonságot **False**-ra állítja egy alakzatra, amikor a szöveg hosszabb lesz az alakzat szélességénél, a szöveg egyetlen sorban meghaladja az alakzat határait.
{{% /alert %}}

## **GYIK**

**A szövegkeret belső margói befolyásolják az AutoFit-et?**  
Igen. A belső margók (padding) csökkentik a szöveg felhasználható területét, ezért az AutoFit hamarabb aktiválódik – a betűméretet csökkenti vagy az alakzatot korábban átméretezi. Ellenőrizze és állítsa be a margókat, mielőtt finomhangolná az AutoFit-et.

**Hogyan működik az AutoFit a kézi és lágy sortörésekkel?**  
A kényszerített sortörések megmaradnak, az AutoFit pedig a betűméretet és a távolságot körülöttük igazítja. A felesleges sortörések eltávolítása gyakran csökkenti, hogy mennyire kell az AutoFit-nek szigorúan zsugorítania a szöveget.

**A sablon betűtípusának módosítása vagy betűtípus-helyettesítés befolyásolja-e az AutoFit eredményeit?**  
Igen. Ha a betűkészlet más jelméretekkel rendelkező betűre cserélődik, az megváltoztatja a szöveg szélességét/magasságát, ami módosíthatja a végső betűméretet és a sortöréseket. Bármilyen betűtípus-változtatás vagy helyettesítés után ellenőrizze újra a diákat.