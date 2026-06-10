---
title: "Zoomok kezelése prezentációkban Python nyelven"
linktitle: "Zoom"
type: docs
weight: 60
url: /hu/python-net/manage-zoom/
keywords:
- "zoom"
- "zoom keret"
- "dia zoom"
- "szakasz zoom"
- "összefoglaló zoom"
- "zoom hozzáadása"
- "PowerPoint"
- "prezentáció"
- "Python"
- "Aspose.Slides"
description: "Hozzon létre és testre szabjon Zoomot az Aspose.Slides for Python via .NET segítségével — ugorjon szakaszok között, adjon hozzá bélyegképeket és átmeneteket PPT, PPTX és ODP prezentációkban."
---
## **Bevezetés**

A PowerPoint-zoomok lehetővé teszik, hogy egyes diákra, szakaszokra és a prezentáció egyes részeire ugorjon, illetve onnan visszatérjen. Előadás közben ez a gyors navigálási lehetőség nagyon hasznos lehet. 

![áttekintés](overview.png)

* A teljes prezentáció egy diára való összefoglalásához használja a [Summary Zoom](#Summary-Zoom) elemet.
* Kijelölt diák megjelenítéséhez használja a [Slide Zoom](#Slide-Zoom) elemet.
* Egyetlen szakasz megjelenítéséhez használja a [Section Zoom](#Section-Zoom) elemet.

## **Dia Zoom**

A dia zoom dinamikusabbá teheti a prezentációt, lehetővé téve, hogy szabadon navigáljon a diák között tetszőleges sorrendben, anélkül hogy megszakítaná az előadás folyását. A dia zoomok kiválóak rövid, kevés szakaszt tartalmazó előadásokhoz, de más prezentációs forgatókönyvekben is használhatók.

A dia zoomok segítenek több információs darabot átfogóan megtekinteni, mintha egyetlen vásznon dolgozna. 

![slidezoomsel](slidezoomsel.png)

A dia zoom objektumokhoz az Aspose.Slides a [ZoomImageType](https://reference.aspose.com/slides/hu/python-net/aspose.slides/zoomimagetype/) felsorolást, a [ZoomFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/zoomframe/) osztályt és néhány metódust a [ShapeCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapecollection/) osztályban biztosít.

### **Zoomkeretek létrehozása**
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.  
2. Hozzon létre új diát, amelyekre hivatkozni szeretne.  
3. Adjon azonosító szöveget és háttérszínt a létrehozott diákhoz.  
4. Adjon zoomkereteket (amelyek a létrehozott diákra mutatnak) az első diára.  
5. Írja a módosított prezentációt PPTX fájlként.  

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Új diák hozzáadása a prezentációhoz
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    #Háttér létrehozása a második diára
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    #Szövegdoboz létrehozása a második diára
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    #Háttér létrehozása a harmadik diára
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    #Szövegdoboz létrehozása a harmadik diára
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #ZoomFrame objektumok hozzáadása
    pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    #Prezentáció mentése
    pres.save("presentation-zoom.pptx", slides.export.SaveFormat.PPTX)
```
### **Zoomkeretek létrehozása egyedi képekkel**
1. Hozzon létre egy példányt a `Presentation` osztályból.  
2. Hozzon létre egy új diát, amelyre hivatkozni szeretne.  
3. Adjon azonosító szöveget és háttérszínt a létrehozott diára.  
4. Hozzon létre egy [PPImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/) objektumot úgy, hogy egy képet ad a Presentation objektumhoz tartozó Images gyűjteményhez, amelyet a keret kitöltésére használ.  
5. Adjon zoomkereteket (amelyek a létrehozott diára mutatnak) az első diára.  
6. Írja a módosított prezentációt PPTX fájlként.  

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Új dia hozzáadása a prezentációhoz
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Háttér létrehozása a második diára
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Szövegdoboz létrehozása a harmadik diára
    autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Új kép létrehozása a zoom objektumhoz
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    #ZoomFrame objektum hozzáadása
    pres.slides[0].shapes.add_zoom_frame(20, 20, 300, 200, slide, image)

    # Prezentáció mentése
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```
### **Zoomkeretek formázása**
1. Hozzon létre egy példányt a `Presentation` osztályból.  
2. Hozzon létre új diát, amelyekre hivatkozni kíván.  
3. Adjon azonosító szöveget és háttérszínt a létrehozott diákhoz.  
4. Adjon zoomkereteket (amelyek a létrehozott diákra mutatnak) az első diára.  
5. Hozzon létre egy [PPImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/) objektumot úgy, hogy egy képet ad a Presentation objektumhoz tartozó Images gyűjteményhez, amelyet a keret kitöltésére használ.  
6. Állítson be egy egyedi képet az első zoomkeret objektumhoz.  
7. Módosítsa a vonalformátumot a második zoomkeret objektumnál.  
8. Távolítsa el a háttérképet a második zoomkeret objektum képéről.  
9. Írja a módosított prezentációt PPTX fájlként.  

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Új diák hozzáadása a prezentációhoz
    slide2 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide3 = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    # Háttér létrehozása a második diára
    slide2.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide2.background.fill_format.fill_type = slides.FillType.SOLID
    slide2.background.fill_format.solid_fill_color.color = draw.Color.cyan

    # Szövegdoboz létrehozása a második diára
    autoshape = slide2.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Second Slide"

    # Háttér létrehozása a harmadik diára
    slide3.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide3.background.fill_format.fill_type = slides.FillType.SOLID
    slide3.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

    # Szövegdoboz létrehozása a harmadik diára
    autoshape = slide3.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
    autoshape.text_frame.text = "Trird Slide"

    #ZoomFrame objektumok hozzáadása
    zoomFrame1 = pres.slides[0].shapes.add_zoom_frame(20, 20, 250, 200, slide2)
    zoomFrame2 = pres.slides[0].shapes.add_zoom_frame(200, 250, 250, 200, slide3)

    # Új kép létrehozása a zoom objektumhoz
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    # Egyedi kép beállítása a zoomFrame1 objektumhoz
    zoomFrame1.image = image

    # Zoom keret formátum beállítása a zoomFrame2 objektumnál
    zoomFrame2.line_format.width = 5
    zoomFrame2.line_format.fill_format.fill_type = slides.FillType.SOLID
    zoomFrame2.line_format.fill_format.solid_fill_color.color = draw.Color.hot_pink
    zoomFrame2.line_format.dash_style = slides.LineDashStyle.DASH_DOT

    # Ne jelenjen meg háttér a zoomFrame2 objektumnál
    zoomFrame2.show_background = False

    # Prezentáció mentése
    pres.save("presentation-zoom2.pptx", slides.export.SaveFormat.PPTX)
```
## **Szakasz Zoom**

A szakasz zoom egy hivatkozás a prezentáció egy szakaszára. A szakasz zoomokkal visszatérhet a kiemelni kívánt szakaszokra, vagy szemléltetheti, hogyan kapcsolódnak a prezentáció egyes részei. 

![seczoomsel](seczoomsel.png)

A szakasz zoom objektumokhoz az Aspose.Slides a [SectionZoomFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sectionzoomframe/) osztályt és néhány metódust a [ShapeCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapecollection/) osztályban biztosít.

### **Szakaszzoom keretek létrehozása**
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.  
2. Hozzon létre egy új diát.  
3. Adjon azonosító háttérszínt a létrehozott diára.  
4. Hozzon létre egy új szakaszt, amelyre a zoomkeretet szeretné hivatkozni.  
5. Adjon egy szakaszzoom keretet (amely a létrehozott szakaszra mutat) az első diára.  
6. Írja a módosított prezentációt PPTX fájlként.  

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Új dia hozzáadása a prezentációhoz
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # Új szakasz hozzáadása a prezentációhoz
    pres.sections.add_section("Section 1", slide)

    # Új SzakaszZoomFrame objektum hozzáadása
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # Prezentáció mentése
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```
### **Szakaszzoom keretek létrehozása egyedi képekkel**
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.  
2. Hozzon létre egy új diát.  
3. Adjon azonosító háttérszínt a létrehozott diára.  
4. Hozzon létre egy új szakaszt, amelyre a zoomkeretet szeretné hivatkozni.  
5. Hozzon létre egy [PPImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/) objektumot úgy, hogy egy képet ad a Presentation objektumhoz tartozó Images gyűjteményhez, amelyet a keret kitöltésére használ.  
6. Adjon egy szakaszzoom keretet (amely a létrehozott szakaszra mutat) az első diára.  
7. Írja a módosított prezentációt PPTX fájlként.  

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Új dia hozzáadása a prezentációhoz
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green


    # Új szakasz hozzáadása a prezentációhoz
    pres.sections.add_section("Section 1", slide)

    # Új kép létrehozása a zoom objektumhoz
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))

    # SzakaszZoomFrame objektum hozzáadása
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1], image)

    # Prezentáció mentése
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```
### **Szakaszzoom keretek formázása**
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.  
2. Hozzon létre egy új diát.  
3. Adjon azonosító háttérszínt a létrehozott diára.  
4. Hozzon létre egy új szakaszt, amelyre a zoomkeretet szeretné hivatkozni.  
5. Adjon egy szakaszzoom keretet (amely a létrehozott szakaszra mutat) az első diára.  
6. Módosítsa a méretet és a pozíciót a létrehozott szakaszzoom objektumnál.  
7. Hozzon létre egy [PPImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/) objektumot úgy, hogy egy képet ad a Presentation objektumhoz tartozó Images gyűjteményhez, amelyet a keret kitöltésére használ.  
8. Állítson be egy egyedi képet a létrehozott szakaszzoom keret objektumhoz.  
9. Állítsa be a *visszatérés az eredeti diára a hivatkozott szakaszból* funkciót.  
10. Távolítsa el a háttérképet a szakaszzoom keret objektum képéről.  
11. Módosítsa a vonalformátumot a második zoomkeret objektumnál.  
12. Módosítsa az átmenet időtartamát.  
13. Írja a módosított prezentációt PPTX fájlként.  

```py
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #Új dia hozzáadása a prezentációhoz
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Új szakasz hozzáadása a prezentációhoz
    pres.sections.add_section("Section 1", slide)

    # SectionZoomFrame objektum hozzáadása
    sectionZoomFrame = pres.slides[0].shapes.add_section_zoom_frame(20, 20, 300, 200, pres.sections[1])

    # SectionZoomFrame formázása
    sectionZoomFrame.x = 100
    sectionZoomFrame.y = 300
    sectionZoomFrame.width = 100
    sectionZoomFrame.height = 75

    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    sectionZoomFrame.image = image

    sectionZoomFrame.return_to_parent = True
    sectionZoomFrame.show_background = False

    sectionZoomFrame.line_format.fill_format.fill_type = slides.FillType.SOLID
    sectionZoomFrame.line_format.fill_format.solid_fill_color.color = draw.Color.brown
    sectionZoomFrame.line_format.dash_style = slides.LineDashStyle.DASH_DOT
    sectionZoomFrame.line_format.width = 2.5

    sectionZoomFrame.transition_duration = 1.5

    # Prezentáció mentése
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```
## **Összefoglaló Zoom**

Az összefoglaló zoom olyan kezdőlap, ahol a prezentáció minden része egyszerre jelenik meg. Előadás közben a zoom segítségével tetszőleges sorrendben ugorhat a prezentáció egyik pontjáról a másikra. Kreatív lehet, előre ugorhat vagy visszatérhet a diák egyes részeihez, anélkül hogy megszakítaná az előadás folyását.

![overview_image](summaryzoom.png)

Az összefoglaló zoom objektumokhoz az Aspose.Slides a [SummaryZoomFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/summaryzoomframe/), a [SummaryZoomSection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/summaryzoomsection/) és a [SummaryZoomSectionCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/summaryzoomsectioncollection/) osztályt, valamint néhány metódust a [ShapeCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shapecollection/) osztályban biztosít.

### **Összefoglaló Zoom létrehozása**
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.  
2. Hozzon létre új diát azonosító háttérrel és új szakaszokkal a létrehozott diákhoz.  
3. Adja hozzá az összefoglaló zoom keretet az első diához.  
4. Írja a módosított prezentációt PPTX fájlként.  

```py 
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    # Diák tömbjének létrehozása
    for slideNumber in range(5):
        #Új diák hozzáadása a prezentációhoz
        slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)

        # Háttér létrehozása a diára
        slide.background.type = slides.BackgroundType.OWN_BACKGROUND
        slide.background.fill_format.fill_type = slides.FillType.SOLID
        slide.background.fill_format.solid_fill_color.color = draw.Color.dark_khaki

        # Szövegdoboz létrehozása a diára
        autoshape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 500, 200)
        autoshape.text_frame.text = "Slide - {num}".format(num = (slideNumber + 2))

    # Zoom objektumok létrehozása minden dia számára az első dián
    for slideNumber in range(1, len(pres.slides)):
        x = (slideNumber - 1) * 100
        y = (slideNumber - 1) * 100
        zoomFrame = pres.slides[0].shapes.add_zoom_frame(x, y, 150, 120, pres.slides[slideNumber])

        # ReturnToParent tulajdonság beállítása az első diára való visszatéréshez
        zoomFrame.return_to_parent = True

    # Prezentáció mentése
    pres.save("presentation-zoom3.pptx", slides.export.SaveFormat.PPTX)
```
### **Összefoglaló Zoom szakaszok hozzáadása és eltávolítása**
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.  
2. Hozzon létre új diát azonosító háttérrel és új szakaszokkal a létrehozott diákhoz.  
3. Adjon egy összefoglaló zoom keretet az első diához.  
4. Hozzon létre egy új diát és szakaszt a prezentációban.  
5. Adja hozzá a létrehozott szakaszt az összefoglaló zoom kerethez.  
6. Távolítsa el az első szakaszt az összefoglaló zoom keretből.  
7. Írja a módosított prezentációt PPTX fájlként.  

``` python
import aspose.slides as slides
import aspose.pydrawing as draw


with slides.Presentation() as pres:
    #Új dia hozzáadása a prezentációhoz
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.yellow_green
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Új szakasz hozzáadása a prezentációhoz
    pres.sections.add_section("Section 1", slide)

    #Új dia hozzáadása a prezentációhoz
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Új szakasz hozzáadása a prezentációhoz
    pres.sections.add_section("Section 2", slide)

    # SummaryZoomFrame objektum hozzáadása
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    #Új dia hozzáadása a prezentációhoz
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.chartreuse
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Új szakasz hozzáadása a prezentációhoz
    section3 = pres.sections.add_section("Section 3", slide)

    # Szakaszt hozzáadása a Summary Zoom-hoz
    summaryZoomFrame.summary_zoom_collection.add_summary_zoom_section(section3)

    # Szakasz eltávolítása a Summary Zoom-ból
    summaryZoomFrame.summary_zoom_collection.remove_summary_zoom_section(pres.sections[1])

    # Prezentáció mentése
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```
### **Összefoglaló Zoom szakaszok formázása**
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.  
2. Hozzon létre új diát azonosító háttérrel és új szakaszokkal a létrehozott diákhoz.  
3. Adja hozzá az összefoglaló zoom keretet az első diához.  
4. Szerezzen egy summary zoom szakasz objektumot az első objektumhoz a `SummaryZoomSectionCollection`-ból.  
5. Hozzon létre egy `PPImage` objektumot úgy, hogy egy képet ad a Presentation objektumhoz tartozó images gyűjteményhez, amelyet a keret kitöltésére használ.  
6. Állítson be egy egyedi képet a létrehozott szakaszzoom keret objektumhoz.  
7. Állítsa be a *visszatérés az eredeti diára a hivatkozott szakaszból* funkciót.  
8. Módosítsa a vonalformátumot a második zoomkeret objektumnál.  
9. Módosítsa az átmenet időtartamát.  
10. Írja a módosított prezentációt PPTX fájlként.  

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    #Új dia hozzáadása a prezentációhoz
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.brown
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Új szakasz hozzáadása a prezentációhoz
    pres.sections.add_section("Section 1", slide)

    #Új dia hozzáadása a prezentációhoz
    slide = pres.slides.add_empty_slide(pres.slides[0].layout_slide)
    slide.background.fill_format.fill_type = slides.FillType.SOLID
    slide.background.fill_format.solid_fill_color.color = draw.Color.aqua
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND

    # Új szakasz hozzáadása a prezentációhoz
    pres.sections.add_section("Section 2", slide)

    # SummaryZoomFrame objektum hozzáadása
    summaryZoomFrame = pres.slides[0].shapes.add_summary_zoom_frame(150, 50, 300, 200)

    # Az első SummaryZoomSection objektum lekérése
    summarySection = summaryZoomFrame.summary_zoom_collection[0]

    # Formázás a SummaryZoomSection objektumhoz
    image = pres.images.add_image(slides.Images.from_file("img.jpeg"))
    summarySection.image = image

    summarySection.return_to_parent = False

    summarySection.line_format.fill_format.fill_type = slides.FillType.SOLID
    summarySection.line_format.fill_format.solid_fill_color.color = draw.Color.black
    summarySection.line_format.dash_style = slides.LineDashStyle.DASH_DOT
    summarySection.line_format.width = 1.5

    summarySection.transition_duration = 1.5

    # Prezentáció mentése
    pres.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```
## **GYIK**

**Ellenőrizhetem a visszatérést a szülő diára a cél megjelenítése után?**  
Igen. A [Zoom frame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/zoomframe/) vagy a [section](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sectionzoomframe/) rendelkezik `return_to_parent` viselkedéssel, amely engedélyezve visszaküldi a nézőt a kiinduló diára a cél tartalom megtekintése után.

**Módosíthatom a Zoom átmenet 'sebességét' vagy időtartamát?**  
Igen. A Zoom támogatja a `transition_duration` beállítását, így szabályozhatja, mennyi ideig tart a ugrás animációja.

**Vannak korlátok arra vonatkozóan, hány Zoom objektumot tartalmazhat egy prezentáció?**  
Nincs dokumentált kemény API‑korlát. A gyakorlati korlátok a prezentáció összetettségétől és a nézők teljesítményétől függenek. Sok Zoom keretet hozzáadhat, de vegye figyelembe a fájlméretet és a renderelési időt.