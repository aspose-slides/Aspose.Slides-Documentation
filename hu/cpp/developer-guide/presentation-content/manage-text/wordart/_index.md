---
title: "WordArt hatások létrehozása és alkalmazása C++-ban"
linktitle: "WordArt"
type: docs
weight: 110
url: /hu/cpp/wordart/
keywords:
- WordArt
- WordArt létrehozása
- WordArt sablon
- WordArt hatás
- árnyék hatás
- megjelenítési hatás
- ragyogás hatás
- WordArt átalakítás
- 3D hatás
- külső árnyék hatás
- belső árnyék hatás
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "WordArt hatásokat hozhat létre és testreszabhat az Aspose.Slides for C++ segítségével. Ez a lépésről lépésre útmutató segít a fejlesztőknek professzionális szöveggel gazdagítani a prezentációkat C++-ban."
---
## **Áttekintés**

A WordArt hatások lehetővé teszik, hogy vizuálisan vonzó, stilizált szöveget adjunk a PowerPoint prezentációkhoz. Az Aspose.Slides segítségével a fejlesztők programozott módon hozhatnak létre, testreszabhatnak és kezelhetnek WordArt-ot, akárcsak a Microsoft PowerPoint‑ban – anélkül, hogy az Office telepítve lenne. Ez a cikk áttekintést nyújt a WordArt használatáról, beleértve a szövegelmozdítások, kitöltési stílusok, körvonalak, árnyékok és egyéb formázási lehetőségek alkalmazását, hogy a prezentáció tartalma kifejezőbb és vonzóbb legyen. A WordArt lehetővé teszi, hogy a szöveget grafikus objektumként kezeljük. Effektekből vagy speciális módosításokból áll, amelyeket a szövegre alkalmaznak, hogy az vonzóbb vagy feltűnőbb legyen.

## **Egyszerű WordArt sablon létrehozása és alkalmazása szövegre**

**Aspose.Slides használata** 

Először egy egyszerű szöveget hozunk létre ezzel a C++ kóddal: 

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");
```

Most a szöveg betűméretét nagyobb értékre állítjuk, hogy a hatás jobban észrevehető legyen, ezzel a kóddal:

``` cpp 
auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);
```

**Microsoft PowerPoint használata**

Nyissa meg a WordArt hatások menüt a Microsoft PowerPointben:

![todo:image_alt_text](image-20200930113926-1.png)

A jobb oldali menüből választhat előre definiált WordArt hatást. A bal oldali menüből adhatja meg egy új WordArt beállításait.

Itt a rendelkezésre álló paraméterek vagy beállítások egy része:

![todo:image_alt_text](image-20200930114015-3.png)

**Aspose.Slides használata**

Itt a SmallGrid mintaszínt alkalmazzuk a szövegre, és 1-es vastagságú fekete szövegkeretet adunk hozzá ezzel a kóddal:

``` cpp 
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Pattern);
fillFormat->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_DarkOrange());
fillFormat->get_PatternFormat()->get_BackColor()->set_Color(Color::get_White());
fillFormat->get_PatternFormat()->set_PatternStyle(PatternStyle::SmallGrid);

auto lineFillFormat = portion->get_PortionFormat()->get_LineFormat()->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
```

Az eredményül kapott szöveg:

![todo:image_alt_text](image-20200930114108-4.png)

## **Egyéb WordArt hatások alkalmazása**

**Microsoft PowerPoint használata**

A program felületéről ezeket a hatásokat szövegre, szövegtömbre, alakzatra vagy hasonló elemre alkalmazhatja:

![todo:image_alt_text](image-20200930114129-5.png)

Például Árnyék, Tükröződés és Ragyogás hatásokat lehet szövegre alkalmazni; 3D Formátum és 3D Forgatás hatásokat lehet szövegtömbre alkalmazni; A Lágy Szélek tulajdonságot alakzatobjektumra lehet alkalmazni (ez hatással van, ha nincs beállítva 3D Formátum tulajdonság).

### **Árnyék hatások alkalmazása szövegre**

Itt csak a szövegre vonatkozó tulajdonságokat szeretnénk beállítani. A szövegre árnyék hatást alkalmazunk ezzel a C++ kóddal:

``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();

auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(Color::get_Black());
outerShadowEffect->set_ScaleHorizontal(100);
outerShadowEffect->set_ScaleVertical(65);
outerShadowEffect->set_BlurRadius(4.73);
outerShadowEffect->set_Direction(230.0f);
outerShadowEffect->set_Distance(2);
outerShadowEffect->set_SkewHorizontal(30);
outerShadowEffect->set_SkewVertical(0);
outerShadowEffect->get_ShadowColor()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.32f);
```

Az Aspose.Slides API három árnyék típust támogat: OuterShadow, InnerShadow és PresetShadow.

A PresetShadow segítségével előre definiált értékekkel árnyékot alkalmazhat szövegre.

**Microsoft PowerPoint használata**

A PowerPointban egy árnyék típust használhat. Íme egy példa:

![todo:image_alt_text](image-20200930114225-6.png)

**Aspose.Slides használata**

Az Aspose.Slides valójában egyszerre két árnyék típust alkalmazhat: InnerShadow és PresetShadow.

**Megjegyzések:**

- Ha az OuterShadow és a PresetShadow együtt kerülnek használatra, csak az OuterShadow hatás alkalmazásra kerül.
- Ha az OuterShadow és az InnerShadow egyszerre kerülnek használatra, az eredő vagy alkalmazott hatás a PowerPoint verziójától függ. Például a PowerPoint 2013‑ban a hatás duplázódik, míg a PowerPoint 2007‑ben az OuterShadow hatás kerül alkalmazásra.

### **Tükröződés hatások alkalmazása**

Egy tükröződést adunk a szöveghez ezzel a C++ kódmintával:

``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableReflectionEffect();

auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_BlurRadius(0.5);
reflectionEffect->set_Distance(4.72);
reflectionEffect->set_StartPosAlpha(0.f);
reflectionEffect->set_EndPosAlpha(60.f);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_ScaleHorizontal(100);
reflectionEffect->set_ScaleVertical(-100);
reflectionEffect->set_StartReflectionOpacity(60.f);
reflectionEffect->set_EndReflectionOpacity(0.9f);
reflectionEffect->set_RectangleAlign(RectangleAlignment::BottomLeft);
```

### **Ragyogás hatás alkalmazása**

A szövegre ragyogás hatást alkalmazunk, hogy az ragyogjon vagy kitűnjön, ezzel a kóddal:

``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableGlowEffect();

auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_R(255);
glowEffect->get_Color()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.54f);
glowEffect->set_Radius(7);
```

A művelet eredménye:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
Módosíthatja az árnyék, megjelenítés és ragyogás paramétereit. A hatások tulajdonságai a szöveg minden részére külön-külön kerülnek beállításra. 
{{% /alert %}} 

### **Átalakítások használata WordArtban**

A set_Transform metódust (ami az egész szövegblokkra vonatkozik) használjuk ezzel a kóddal:

``` cpp 
textFrame->get_TextFrameFormat()->set_Transform(TextShapeType::ArchUpPour);
```

Az eredmény:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
A Microsoft PowerPoint és az Aspose.Slides for C++ egy bizonyos számú előre definiált átalakítási típust biztosít. 
{{% /alert %}} 

**PowerPoint használata**

Az előre definiált átalakítási típusok eléréséhez lépjen a következő menübe: **Format** -> **TextEffect** -> **Transform**

**Aspose.Slides használata**

Az átalakítási típus kiválasztásához használja a TextShapeType enumerációt.

### **3D hatások alkalmazása szövegre és alakzatokra**

3D hatást állítunk be egy szövegalakzatra ezzel a mintakóddal:

``` cpp 
auto threeDFormat = autoShape->get_ThreeDFormat();

threeDFormat->get_BevelBottom()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelBottom()->set_Height(10.5);
threeDFormat->get_BevelBottom()->set_Width(10.5);

threeDFormat->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelTop()->set_Height(12.5);
threeDFormat->get_BevelTop()->set_Width(11);

threeDFormat->get_ExtrusionColor()->set_Color(Color::get_Orange());
threeDFormat->set_ExtrusionHeight(6);

threeDFormat->get_ContourColor()->set_Color(Color::get_DarkRed());
threeDFormat->set_ContourWidth(1.5);

threeDFormat->set_Depth(3);

threeDFormat->set_Material(MaterialPresetType::Plastic);

threeDFormat->get_LightRig()->set_Direction(LightingDirection::Top);
threeDFormat->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
threeDFormat->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

threeDFormat->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

Az eredményül kapott szöveg és alakzata:

![todo:image_alt_text](image-20200930114816-9.png)

A szövegre 3D hatást alkalmazunk ezzel a C++ kóddal:

``` cpp 
auto threeDFormat = textFrame->get_TextFrameFormat()->get_ThreeDFormat();

threeDFormat->get_BevelBottom()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelBottom()->set_Height(3.5);
threeDFormat->get_BevelBottom()->set_Width(3.5);

threeDFormat->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelTop()->set_Height(4);
threeDFormat->get_BevelTop()->set_Width(4);

threeDFormat->get_ExtrusionColor()->set_Color(Color::get_Orange());
threeDFormat->set_ExtrusionHeight(6);

threeDFormat->get_ContourColor()->set_Color(Color::get_DarkRed());
threeDFormat->set_ContourWidth(1.5);

threeDFormat->set_Depth(3);

threeDFormat->set_Material(MaterialPresetType::Plastic);

threeDFormat->get_LightRig()->set_Direction(LightingDirection::Top);
threeDFormat->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
threeDFormat->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

threeDFormat->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

A művelet eredménye:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 
A 3D hatások szövegekre vagy azok alakzataira való alkalmazása, valamint a hatások közötti kölcsönhatások bizonyos szabályokon alapulnak.

Vegyük figyelembe egy szöveg és a szöveget tartalmazó alakzat jelenetét. A 3D hatás tartalmazza a 3D objektum ábrázolását és a jelenetet, amelyre az objektum el lett helyezve.

- Ha a jelenet mind a alakzatra, mind a szövegre be van állítva, akkor az alakzat jelenete kapja a nagyobb prioritást – a szöveg jelenete figyelmen kívül marad.
- Ha az alakzatnak nincs saját jelenete, de van 3D ábrázolása, akkor a szöveg jelenete kerül felhasználásra.
- Egyébként – ha az alakzat eredetileg nincs 3D hatással – az alakzat lapos, és a 3D hatás csak a szövegre kerül alkalmazásra.

Ezek a leírások a ThreeDFormat.getLightRig() és a ThreeDFormat.getCamera() metódusokhoz kapcsolódnak.
{{% /alert %}} 

## **Külső árnyék hatások alkalmazása alakzatokra**
Az Aspose.Slides for C++ a [**IOuterShadow**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.effects.i_outer_shadow) és a [**IInnerShadow**](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.effects.i_inner_shadow) osztályokat biztosítja, amelyek lehetővé teszik, hogy árnyék hatásokat alkalmazzon a TextFrame által hordott szövegre. Kövesse ezeket a lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.
2. Szerezze meg egy dia referenciaját az index használatával.
3. Adjon egy Rectangle típusú AutoShape‑ot a diára.
4. Érje el az AutoShape‑hoz tartozó TextFrame‑et.
5. Állítsa be az AutoShape FillType‑ját NoFill értékre.
6. Példányosítsa az OuterShadow osztályt
7. Állítsa be az árnyék BlurRadius‑át.
8. Állítsa be az árnyék Direction‑ját
9. Állítsa be az árnyék Distance‑át.
10. Állítsa be a RectanglelAlign‑t TopLeft értékre.
11. Állítsa be az árnyék PresetColor‑át Black értékre.
12. Mentse a prezentációt PPTX fájlként.

Ez a C++ mintakód – a fenti lépések megvalósítása – bemutatja, hogyan alkalmazhatja a külső árnyék hatást egy szövegre:

``` cpp
auto pres = System::MakeObject<Presentation>();
// Szerezzük meg a dia referenciaját
auto sld = pres->get_Slides()->idx_get(0);

// Adjunk hozzá egy Rectangle típusú AutoShape‑t
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Adjunk TextFrame‑et a Rectangle‑hez
ashp->AddTextFrame(u"Aspose TextBox");

// Tiltsuk le az alakzat kitöltését, ha a szöveg árnyékát akarjuk
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// Adjunk hozzá külső árnyékot és állítsuk be az összes szükséges paramétert
ashp->get_EffectFormat()->EnableOuterShadowEffect();
auto shadow = ashp->get_EffectFormat()->get_OuterShadowEffect();
shadow->set_BlurRadius(4.0);
shadow->set_Direction(45.0f);
shadow->set_Distance(3);
shadow->set_RectangleAlign(RectangleAlignment::TopLeft);
shadow->get_ShadowColor()->set_PresetColor(PresetColor::Black);

// Mentse a prezentációt a lemezre
pres->Save(u"pres_out.pptx", SaveFormat::Pptx);
```

## **Belső árnyék hatások alkalmazása alakzatokra**
Kövesse ezeket a lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.
2. Szerezze meg a dia referenciáját.
3. Adjon hozzá egy Rectangle típusú AutoShape‑ot.
4. Engedélyezze az InnerShadowEffect‑et.
5. Állítsa be az összes szükséges paramétert.
6. Állítsa be a ColorType‑ot Scheme értékre.
7. Állítsa be a Scheme Color‑t.
8. Mentse a prezentációt [PPTX](https://docs.fileformat.com/presentation/pptx/) fájlként.

Ez a mintakód (a fenti lépések alapján) bemutatja, hogyan adjon hozzá egy csatlakozót két alakzat között C++‑ban:

``` cpp
auto presentation = System::MakeObject<Presentation>();
// Szerezzük meg egy dia referenciaját
auto slide = presentation->get_Slides()->idx_get(0);

// Adjunk hozzá egy Rectangle típusú AutoShape‑t
auto ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 400.0f, 300.0f);
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// Adjunk TextFrame‑et a Rectangle‑hez
ashp->AddTextFrame(u"Aspose TextBox");
auto port = ashp->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
auto pf = port->get_PortionFormat();
pf->set_FontHeight(50.0f);

// Engedélyezzük az InnerShadowEffect‑et    
auto ef = pf->get_EffectFormat();
ef->EnableInnerShadowEffect();

// Állítsuk be az összes szükséges paramétert
auto shadow = ef->get_InnerShadowEffect();
shadow->set_BlurRadius(8.0);
shadow->set_Direction(90.0F);
shadow->set_Distance(6.0);
shadow->get_ShadowColor()->set_B(189);

// Állítsuk be a ColorType‑t Scheme‑ként
shadow->get_ShadowColor()->set_ColorType(ColorType::Scheme);

// Állítsuk be a Scheme színt
shadow->get_ShadowColor()->set_SchemeColor(SchemeColor::Accent1);

// Mentsük a prezentációt
presentation->Save(u"WordArt_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Használhatok WordArt hatásokat különböző betűtípusokkal vagy írásrendszerekkel (pl. arab, kínai)?**

Igen, az Aspose.Slides támogatja a Unicode‑ot, és működik minden nagyobb betűtípussal és írásrendszerrel. A WordArt hatásokat, mint az árnyék, kitöltés és körvonal, nyelvtől függetlenül alkalmazhatja, bár a betűtípus elérhetősége és megjelenítése a rendszer betűtípusaitól függhet.

**Alkalmazhatok WordArt hatásokat a diamester elemeire?**

Igen, a diamester diákon lévő alakzatokra, beleértve a címhelyettesítőket, lábléceket vagy háttérszöveget, alkalmazhat WordArt hatásokat. A mesterelrendezésben végzett módosítások minden kapcsolódó diára kihatnak.

**A WordArt hatások befolyásolják a prezentáció fájlméretét?**

Enyhén. Az olyan WordArt hatások, mint az árnyékok, ragyogások és színátmenetes kitöltések, kismértékben növelhetik a fájlméretet a hozzáadott formázási metaadatok miatt, de a különbség általában elhanyagolható.

**Előnézhetem a WordArt hatások eredményét a prezentáció mentése nélkül?**

Igen, a WordArt‑ot tartalmazó diákat képekké (például PNG, JPEG) renderelheti a [IShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/) vagy [ISlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islide/) interfész `GetImage` metódusával. Ez lehetővé teszi az eredmény előnézetét memóriában vagy a képernyőn a teljes prezentáció mentése vagy exportálása előtt.