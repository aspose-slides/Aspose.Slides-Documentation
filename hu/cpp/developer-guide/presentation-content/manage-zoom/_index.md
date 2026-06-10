---
title: Prezntáció Zoom kezelése C++-ban
linktitle: Zoom kezelése
type: docs
weight: 60
url: /hu/cpp/manage-zoom/
keywords:
- zoom
- zoom keret
- dia zoom
- szakasz zoom
- összefoglaló zoom
- zoom hozzáadása
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Készítsen és testreszabjon Zoom-ot az Aspose.Slides for C++ segítségével — ugorjon a szakaszok között, adjon hozzá bélyegképeket és átmeneteket PPT, PPTX és ODP prezentációkban."
---
## **Bevezetés**

A PowerPoint zoomok lehetővé teszik, hogy egy adott diára, szakaszra vagy a prezentáció egy részére ugorjon, és onnan visszatérjen. Prezentálás közben ez a gyors navigálási képesség nagyon hasznos lehet.

![overview_image](Overview.png)

* Az egész prezentáció összegzéséhez egyetlen dián, használja a [Összefoglaló Zoom](#Summary-Zoom) elemet.
* Kiválasztott diák megjelenítéséhez, használja a [Dia Zoom](#Slide-Zoom) elemet.
* Egyetlen szakasz megjelenítéséhez, használja a [Szakasz Zoom](#Section-Zoom) elemet.

## **Dia Zoom**
A dia zoom dinamikusabbá teheti a prezentációt, lehetővé téve, hogy szabadon navigáljon a diák között bármilyen sorrendben, anélkül hogy megszakítaná a bemutató folyamatát. A dia zoomok kiválóak rövid, kevés szakaszt tartalmazó prezentációkhoz, de más bemutatási forgatókönyvekben is használhatók.

A dia zoomok segítségével többrétegű információkba áshat bele úgy, mintha egyetlen vásznon dolgozna.

![overview_image](slidezoomsel.png)

Dia zoom objektumok esetén az Aspose.Slides a [ZoomImageType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/zoomimagetype/) felsorolást, az [IZoomFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/izoomframe/) interfészt, valamint néhány metódust a [IShapeCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/) interfész alatt biztosítja.

### **Zoom keretek létrehozása**

Zoom keretet a diára a következő módon adhat hozzá:

1.	Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2.	Hozzon létre új diákot, amelyhez a zoom kereteket szeretné összekapcsolni. 
3.	Adjon az elkészített diákhoz azonosító szöveget és háttérképet.
4.	Adjon hozzá zoom kereteket (a létrehozott diákokra mutató hivatkozásokkal) az első diához.
5.	Mentse a módosított prezentációt PPTX fájlként.

Ez a C++ kód megmutatja, hogyan hozhat létre zoom keretet egy dián:

``` cpp 
void SetSlideBackground(SharedPtr<ISlide> slide, Color color)
{
    slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
    slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(color);
    slide->get_Background()->set_Type(BackgroundType::OwnBackground);
}
```

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Adds new slides to the presentation
auto slide2 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// Creates a background for the second slide
SetSlideBackground(slide2, Color::get_Cyan());

// Creates a text box for the second slide
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// Creates a background for the third slide
SetSlideBackground(slide3, Color::get_DarkKhaki());

// Create a text box for the third slide
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//Adds ZoomFrame objects
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
slide0->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

// Saves the presentation
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Zoom keretek létrehozása egyéni képekkel**
Az Aspose.Slides for C++ segítségével egyedi dia előnézeti képpel hozhat létre zoom keretet a következőképp:
1.	Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2.	Hozzon létre egy új diát, amelyhez a zoom keretet szeretné összekapcsolni. 
3.	Adjon azonosító szöveget és háttérképet a diára.
4.	Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ippimage/) objektumot úgy, hogy képet ad hozzá a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) objektumhoz tartozó Images gyűjteményhez, amely a keret kitöltésére szolgál.
5.	Adjon hozzá zoom kereteket (a létrehozott diára mutató hivatkozással) az első diához.
6.	Mentse a módosított prezentációt PPTX fájlként.

Ez a C++ kód megmutatja, hogyan hozhat létre zoom keretet egyedi képpel:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Új diát ad a prezentációhoz
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());

// Háttér létrehozása a második dia számára
SetSlideBackground(slide, Color::get_Cyan());

// Szövegdoboz létrehozása a harmadik dia számára
auto autoshape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

// Új képet hoz létre a zoom objektumhoz
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

//ZoomFrame objektumot ad hozzá
slide0->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, slide, image);

// A prezentáció mentése
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Zoom keretek formázása**
Az előző részekben egyszerű zoom keretek létrehozását mutattuk be. Összetettebb zoom keretek létrehozásához módosítani kell egy egyszerű keret formázását. Számos formázási lehetőség áll rendelkezésre egy zoom kerethez.

A dia zoom keret formázását a következő módon szabályozhatja:

1.	Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2.	Hozzon létre új diákot, amelyekhez a zoom keretet szeretné összekapcsolni. 
3.	Adjon azonosító szöveget és háttérképet a létrehozott diákhoz.
4.	Adjon hozzá zoom kereteket (a létrehozott diákokra mutató hivatkozásokkal) az első diához.
5.	Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ippimage/) objektumot úgy, hogy képet ad hozzá a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) objektumhoz tartozó Images gyűjteményhez, amely a keret kitöltésére szolgál.
6.	Állítson be egy egyéni képet a első zoom keret objektumhoz.
7.	Változtassa meg a második zoom keret objektum vonalformátumát.
8.	Távolítsa el a háttérképet a második zoom keret objektum képéből.
5.	Mentse a módosított prezentációt PPTX fájlként.

Ez a C++ kód megmutatja, hogyan változtatható meg egy zoom keret formázása egy dián:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide1 = pres->get_Slides()->idx_get(0);
//Új diákok hozzáadása a prezentációhoz
auto slide2 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());
auto slide3 = pres->get_Slides()->AddEmptySlide(slide1->get_LayoutSlide());

//Háttér létrehozása a második diához
SetSlideBackground(slide2, Color::get_Cyan());

//Szövegdoboz létrehozása a második diához
auto autoshape = slide2->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Second Slide");

//Háttér létrehozása a harmadik diához
SetSlideBackground(slide3, Color::get_DarkKhaki());

//Szövegdoboz létrehozása a harmadik diához
autoshape = slide3->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 200.0f, 500.0f, 200.0f);
autoshape->get_TextFrame()->set_Text(u"Trird Slide");

//ZoomFrame objektumok hozzáadása
auto zoomFrame1 = slide1->get_Shapes()->AddZoomFrame(20.0f, 20.0f, 250.0f, 200.0f, slide2);
auto zoomFrame2 = slide1->get_Shapes()->AddZoomFrame(200.0f, 250.0f, 250.0f, 200.0f, slide3);

//Új kép létrehozása a zoom objektumhoz
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
//Egyéni kép beállítása a zoomFrame1 objektumhoz
zoomFrame1->set_Image(image);

//Zoom keret formátum beállítása a zoomFrame2 objektumhoz
zoomFrame2->get_LineFormat()->set_Width(5);
zoomFrame2->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
zoomFrame2->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_HotPink());
zoomFrame2->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);

//Beállítás a háttér megjelenítésének letiltására a zoomFrame2 objektumnál
zoomFrame2->set_ShowBackground(false);

//A prezentáció mentése
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **Szakasz Zoom**

A szakasz zoom egy hivatkozás a prezentáció egy szakaszára. A szakasz zoomokkal visszatérhet azokhoz a szakaszokhoz, amelyeket különösen ki szeretne emelni. Vagy arra is használhatók, hogy bemutassák, hogyan kapcsolódnak egymáshoz a prezentáció egyes részei.

![overview_image](seczoomsel.png)

Szakasz zoom objektumok esetén az Aspose.Slides az [ISectionZoomFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isectionzoomframe/) interfészt és néhány metódust a [IShapeCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/) interfész alatt biztosítja.

### **Szakasz Zoom keretek létrehozása**

Szakasz zoom keretet egy diára a következő módon adhat hozzá:

1.	Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2.	Hozzon létre egy új diát. 
3.	Adjon azonosító háttérképet a létrehozott diára.
4.	Hozzon létre egy új szakaszt, amelyhez a zoom keretet szeretné kapcsolni. 
5.	Adjon egy szakasz zoom keretet (a létrehozott szakaszra mutató hivatkozással) az első diához.
6.	Mentse a módosított prezentációt PPTX fájlként.

Ez a C++ kód megmutatja, hogyan hozhat létre zoom keretet egy dián:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Új diát ad a prezentációhoz
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Új szakaszt ad a prezentációhoz
pres->get_Sections()->AddSection(u"Section 1", slide);

// SectionZoomFrame objektumot ad hozzá
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

// A prezentáció mentése
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Szakasz Zoom keretek létrehozása egyéni képekkel**

Az Aspose.Slides for C++ használatával egy egyedi dia előnézeti képpel rendelkező szakasz zoom keretet hozhat létre a következőképp:

1.	Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2.	Hozzon létre egy új diát.
3.	Adjon azonosító háttérképet a létrehozott diára.
4.	Hozzon létre egy új szakaszt, amelyhez a zoom keretet szeretné összekapcsolni. 
5.	Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ippimage/) objektumot úgy, hogy képet ad hozzá a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) objektumhoz tartozó Images gyűjteményhez, amely a keret kitöltésére szolgál.
5.	Adjon egy szakasz zoom keretet (a létrehozott szakaszra mutató hivatkozással) az első diához.
6.	Mentse a módosított prezentációt PPTX fájlként.

Ez a C++ kód megmutatja, hogyan hozhat létre egyedi képpel rendelkező szakasz zoom keretet:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Új diát ad a prezentációhoz
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

// Új szakaszt ad a prezentációhoz
pres->get_Sections()->AddSection(u"Section 1", slide);

// Új képet hoz létre a zoom objektumhoz
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));

// SectionZoomFrame objektumot ad hozzá
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1), image);

// A prezentáció mentése
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Szakasz Zoom keretek formázása**

Összetettebb szakasz zoom keretek létrehozásához módosítani kell egy egyszerű keret formázását. Számos formázási lehetőség áll rendelkezésre egy szakasz zoom kerethez.

A szakasz zoom keret formázását a következő módon irányíthatja:

1.	Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2.	Hozzon létre egy új diát.
3.	Adjon azonosító háttérképet a létrehozott diára.
4.	Hozzon létre egy új szakaszt, amelyhez a zoom keretet szeretné kapcsolni. 
5.	Adjon egy szakasz zoom keretet (a létrehozott szakaszra mutató hivatkozással) az első diához.
6.	Módosítsa a létrehozott szakasz zoom objektum méretét és pozícióját.
7.	Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ippimage/) objektumot úgy, hogy képet ad hozzá a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) objektumhoz tartozó Images gyűjteményhez, amely a keret kitöltésére szolgál.
8.	Állítson be egy egyéni képet a létrehozott szakasz zoom keret objektumhoz.
9.	Állítsa be a *visszatérés az eredeti diára a kapcsolt szakaszból* lehetőséget. 
10.	Távolítsa el a háttérképet a szakasz zoom keret objektum képéből.
11.	Változtassa meg a második zoom keret objektum vonalformátumát.
12.	Változtassa meg a áttűnés időtartamát.
13.	Mentse a módosított prezentációt PPTX fájlként.

Ez a C++ kód megmutatja, hogyan változtatható meg egy szakasz zoom keret formázása:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Új diát ad a prezentációhoz
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_YellowGreen());

//Új szakaszt ad a prezentációhoz
pres->get_Sections()->AddSection(u"Section 1", slide);

//SectionZoomFrame objektumot ad hozzá
auto sectionZoomFrame = slide0->get_Shapes()->AddSectionZoomFrame(20.0f, 20.0f, 300.0f, 200.0f, pres->get_Sections()->idx_get(1));

//SectionZoomFrame formázása
sectionZoomFrame->set_X(100.0f);
sectionZoomFrame->set_Y(300.0f);
sectionZoomFrame->set_Width(100.0f);
sectionZoomFrame->set_Height(75.0f);

auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
sectionZoomFrame->set_Image(image);

sectionZoomFrame->set_ReturnToParent(true);
sectionZoomFrame->set_ShowBackground(false);

auto sectionZoomLineFormat = sectionZoomFrame->get_LineFormat();
sectionZoomLineFormat->get_FillFormat()->set_FillType(FillType::Solid);
sectionZoomLineFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Brown());
sectionZoomLineFormat->set_DashStyle(LineDashStyle::DashDot);
sectionZoomLineFormat->set_Width(2.5f);

sectionZoomFrame->set_TransitionDuration(1.5f);

//A prezentáció mentése
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **Összefoglaló Zoom**

Az összefoglaló zoom olyan, mint egy nyitóoldal, ahol a prezentáció összes része egyszerre látható. Prezentálás közben a zoomot használva bármilyen sorrendben ugorhat egyik helyről a másikra. Kreatív lehet, előre ugorhat, vagy visszatérhet a diavetítése egyes részeihez anélkül, hogy megszakítaná a prezentáció áramlását.

![overview_image](sumzoomsel.png)

Összefoglaló zoom objektumok esetén az Aspose.Slides az [ISummaryZoomFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isummaryzoomframe/), az [ISummaryZoomSection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isummaryzoomsection/), valamint az [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isummaryzoomsectioncollection/) interfészeket és néhány metódust a [IShapeCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/) interfész alatt biztosítja.

### **Összefoglaló Zoom létrehozása**

Összefoglaló zoom keretet egy diára a következőképp adhat hozzá:

1.	Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2.	Hozzon létre új diákot azonosító háttérrel és új szakaszokkal a létrehozott diákhoz.
3.	Adjon egy összefoglaló zoom keretet az első diához.
4.	Mentse a módosított prezentációt PPTX fájlként.

Ez a C++ kód megmutatja, hogyan hozhat létre összefoglaló zoom keretet egy dián:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Új diát ad a prezentációhoz
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

//Új szakaszt ad a prezentációhoz
pres->get_Sections()->AddSection(u"Section 1", slide);

//Új diát ad a prezentációhoz
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

//Új szakaszt ad a prezentációhoz
pres->get_Sections()->AddSection(u"Section 2", slide);

//Új diát ad a prezentációhoz
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

//Új szakaszt ad a prezentációhoz
pres->get_Sections()->AddSection(u"Section 3", slide);

//Új diát ad a prezentációhoz
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_DarkGreen());

//Új szakaszt ad a prezentációhoz
pres->get_Sections()->AddSection(u"Section 4", slide);

//SummaryZoomFrame objektumot ad hozzá
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

//A prezentáció mentése
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Összefoglaló Zoom szakasz hozzáadása és eltávolítása**

Az összefoglaló zoom keret összes szakaszát az [ISummaryZoomSection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isummaryzoomsection/) objektumok képviselik, amelyek a [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isummaryzoomsectioncollection/) objektumban tárolódnak. Egy összefoglaló zoom szakasz objektumot a [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/isummaryzoomsectioncollection/) interfészen keresztül a következőképp adhat hozzá vagy távolíthat el:

1.	Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2.	Hozzon létre új diákot azonosító háttérrel és új szakaszokkal a létrehozott diákhoz.
3.	Adjon egy összefoglaló zoom keretet az első diához.
4.	Adjon egy új diát és szakaszt a prezentációhoz.
5.	Adja hozzá a létrehozott szakaszt az összefoglaló zoom kerethez.
6.	Távolítsa el az első szakaszt az összefoglaló zoom keretből.
7.	Mentse a módosított prezentációt PPTX fájlként.

Ez a C++ kód megmutatja, hogyan adhat hozzá és távolíthat el szakaszokat egy összefoglaló zoom keretben:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Új diát ad a prezentációhoz
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Új szakaszt ad a prezentációhoz
pres->get_Sections()->AddSection(u"Section 1", slide);

//Új diát ad a prezentációhoz
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Új szakaszt ad a prezentációhoz
pres->get_Sections()->AddSection(u"Section 2", slide);

// SummaryZoomFrame objektumot ad hozzá
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

//Új diát ad a prezentációhoz
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Chartreuse());

// Új szakaszt ad a prezentációhoz
auto section3 = pres->get_Sections()->AddSection(u"Section 3", slide);

// Szakaszt ad a Summary Zoom-hoz
summaryZoomFrame->get_SummaryZoomCollection()->AddSummaryZoomSection(section3);

// Eltávolítja a szakaszt a Summary Zoom-ból
summaryZoomFrame->get_SummaryZoomCollection()->RemoveSummaryZoomSection(pres->get_Sections()->idx_get(1));

// A prezentáció mentése
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

### **Összefoglaló Zoom szakaszok formázása**

Összetettebb összefoglaló zoom szakasz objektumok létrehozásához módosítani kell egy egyszerű keret formázását. Számos formázási lehetőség áll rendelkezésre egy összefoglaló zoom szakasz objektumhoz.

Az összefoglaló zoom szakasz objektum formázását egy összefoglaló zoom keretben a következő módon szabályozhatja:

1.	Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2.	Hozzon létre új diákot azonosító háttérrel és új szakaszokkal a létrehozott diákhoz.
3.	Adjon egy összefoglaló zoom keretet az első diához.
4.	Nyertse ki az első objektumot a `ISummaryZoomSectionCollection`-ből.
7.	Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ippimage/) objektumot úgy, hogy képet ad hozzá a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) objektumhoz tartozó Images gyűjteményhez, amely a keret kitöltésére szolgál.
8.	Állítson be egy egyéni képet a létrehozott szakasz zoom keret objektumhoz.
9.	Állítsa be a *visszatérés az eredeti diára a kapcsolt szakaszból* lehetőséget. 
11.	Változtassa meg a második zoom keret objektum vonalformátumát.
12.	Változtassa meg a áttűnés időtartamát.
13.	Mentse a módosított prezentációt PPTX fájlként.

Ez a C++ kód megmutatja, hogyan változtatható meg egy összefoglaló zoom szakasz objektum formázása:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide0 = pres->get_Slides()->idx_get(0);

//Új diát ad a prezentációhoz
auto slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Brown());

// Új szakaszt ad a prezentációhoz
pres->get_Sections()->AddSection(u"Section 1", slide);

//Új diát ad a prezentációhoz
slide = pres->get_Slides()->AddEmptySlide(slide0->get_LayoutSlide());
SetSlideBackground(slide, Color::get_Aqua());

// Új szakaszt ad a prezentációhoz
pres->get_Sections()->AddSection(u"Section 2", slide);

// SummaryZoomFrame objektumot ad hozzá
auto summaryZoomFrame = slide0->get_Shapes()->AddSummaryZoomFrame(150.0f, 50.0f, 300.0f, 200.0f);

// Lekéri az első SummaryZoomSection objektumot
auto summarySection = summaryZoomFrame->get_SummaryZoomCollection()->idx_get(0);

// SummaryZoomSection objektum formázása
auto image = pres->get_Images()->AddImage(Images::FromFile(u"image.png"));
summarySection->set_Image(image);

summarySection->set_ReturnToParent(false);

summarySection->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
summarySection->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
summarySection->get_LineFormat()->set_DashStyle(LineDashStyle::DashDot);
summarySection->get_LineFormat()->set_Width(1.5f);

summarySection->set_TransitionDuration(1.5f);

// A prezentáció mentése
pres->Save(u"presentation.pptx", SaveFormat::Pptx);
```

## **GYIK**

**Vissza tudom-e irányítani a „szülő” diára a cél megjelenítése után?**

Igen. A [Zoom frame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/zoomframe/) vagy a [section](https://reference.aspose.com/slides/hu/cpp/aspose.slides/sectionzoomframe/) rendelkezik egy `set_ReturnToParent` metódussal, amely a nézőket a kiindulási diára visszaküldi a cél tartalom megtekintése után.

**Be tudom-e állítani a Zoom átmenet „sebességét” vagy időtartamát?**

Igen. A Zoom támogatja a átmeneti időtartam beállítását, így szabályozhatja, mennyi ideig tart a ugrás animációja.

**Vannak korlátok arra, hogy hány Zoom objektumot tartalmazhat egy prezentáció?**

Nincs dokumentált szigorú API‑korlát. A gyakorlati korlátok a prezentáció összetettségétől és a néző teljesítményétől függenek. Sok Zoom keretet hozzáadhat, de vegye figyelembe a fájlméretet és a renderelési időt.