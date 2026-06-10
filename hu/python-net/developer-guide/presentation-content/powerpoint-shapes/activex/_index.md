---
title: ActiveX vezérlők kezelése prezentációkban Python segítségével
linktitle: ActiveX
type: docs
weight: 80
url: /hu/python-net/activex/
keywords:
- ActiveX
- ActiveX vezérlő
- ActiveX kezelése
- ActiveX hozzáadása
- ActiveX módosítása
- media lejátszó
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan használja az Aspose.Slides for Python via .NET az ActiveX-et a PowerPoint prezentációk automatizálásához és fejlesztéséhez, lehetővé téve a fejlesztők számára a diák feletti hatékony irányítást."
---
## **Bevezetés**

ActiveX vezérlőket használnak a prezentációkban. Az Aspose.Slides for Python via .NET lehetővé teszi az ActiveX vezérlők kezelését, de ezek kezelése egy kicsit bonyolultabb és eltér a normál prezentációs alakzatoktól. Az Aspose.Slides for Python via .NET 6.9.0 verziótól a komponens támogatja az ActiveX vezérlők kezelését. Jelenleg hozzáférhet a már hozzáadott ActiveX vezérlőhöz a prezentációban, és módosíthatja vagy törölheti azt különféle tulajdonságainak használatával. Ne feledje, hogy az ActiveX vezérlők nem alakzatok, és nem részei a prezentáció IShapeCollection gyűjteményének, hanem egy külön IControlCollection-nek. Ez a cikk bemutatja, hogyan dolgozzunk velük.

## **ActiveX vezérlők módosítása**
Egy egyszerű ActiveX vezérlő, például egy szövegdoboz és egy egyszerű parancsgomb kezelése egy dián:

1. Hozzon létre egy példányt a Presentation osztályból, és töltse be a prezentációt, amely ActiveX vezérlőket tartalmaz.  
2. Szerezzen be egy diára való hivatkozást az indexe alapján.  
3. Érje el a dián lévő ActiveX vezérlőket az IControlCollection elérésével.  
4. A ControlEx objektum használatával érje el a TextBox1 ActiveX vezérlőt.  
5. Módosítsa a TextBox1 ActiveX vezérlő különböző tulajdonságait, beleértve a szöveget, betűtípust, betűmagasságot és a keret helyzetét.  
6. Érje el a második vezérlőt, amely CommandButton1 néven szerepel.  
7. Módosítsa a gomb feliratát, betűtípusát és helyzetét.  
8. Módosítsa az ActiveX vezérlők kereteinek helyzetét.  
9. Írja a módosított prezentációt egy PPTX fájlba.

Az alábbi kódrészlet frissíti az ActiveX vezérlőket a prezentáció diáin, ahogy az alábbiakban látható.

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import io

# A prezentáció elérése ActiveX vezérlőkkel
with slides.Presentation(path + "ActiveX.pptm") as presentation:
    # Az első dia elérése a prezentációban
    slide = presentation.slides[0]

    # A TextBox szövegének módosítása
    control = slide.controls[0]

    if control.name == "TextBox1" and control.properties != None:
        newText = "Changed text"
        control.properties.remove("Value")
        control.properties.add("Value", newText)

        # A helyettesítő kép módosítása. A PowerPoint ezt a képet az ActiveX aktiválásakor cseréli le, ezért időnként rendben van, ha a képet változatlanul hagyjuk.

        bmp = draw.Bitmap(control.frame.width, control.frame.height)
        with draw.Graphics.from_image(bmp) as graphics:
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW)) as brush:
                graphics.fill_rectangle(brush, 0, 0, bmp.width, bmp.height)

            # font = draw.Font(control.properties["FontName"], 14)
            font = draw.Font("Arial", 14)
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW_TEXT)) as brush:
                graphics.draw_string(newText, font, brush, 10, 4)

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK), 1) as pen:
                graphics.draw_lines(pen, [ 
                        draw.PointF(0, bmp.height - 1), 
                        draw.PointF(0, 0), 
                        draw.PointF(bmp.width - 1, 0) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK_DARK), 1) as pen:
                graphics.draw_lines(pen, [
                        draw.PointF(1, bmp.height - 2), 
                        draw.PointF(1, 1), 
                        draw.PointF(bmp.width - 2, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [
                        draw.PointF(1, bmp.height - 1), 
                        draw.PointF(bmp.width - 1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, 1)])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT_LIGHT), 1) as pen:
                graphics.draw_lines(pen,
                    [ 
                        draw.PointF(0, bmp.height), 
                        draw.PointF(bmp.width, bmp.height), 
                        draw.PointF(bmp.width, 0) ])

        bmp_bytes = io.BytesIO()
        bmp.save(bmp_bytes, drawing.imaging.ImageFormat.png)
        control.substitute_picture_format.picture.image = presentation.images.add_image(bmp_bytes)

    # A gomb feliratának módosítása
    control = slide.controls[1]

    if control.name == "CommandButton1" and control.properties != None:
        newCaption = "MessageBox"
        control.properties.remove("Caption")
        control.properties.add("Caption", newCaption)

        # A helyettesítő módosítása
        bmp = draw.Bitmap(control.frame.width, control.frame.height)
        with draw.Graphics.from_image(bmp) as graphics:
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.CONTROL)) as brush:
                graphics.fill_rectangle(brush, 0, 0, bmp.width, bmp.height)

            #font = draw.Font(control.properties["FontName"], 14)
            font = draw.Font("Arial", 14)
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW_TEXT)) as brush:
                textSize = graphics.measure_string(newCaption, font, 65535)
                graphics.draw_string(newCaption, font, brush, 
                    (bmp.width - textSize.width) / 2, 
                    (bmp.height - textSize.height) / 2)

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(0, bmp.height - 1), 
                        draw.PointF(0, 0), 
                        draw.PointF(bmp.width - 1, 0) ])
            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(1, bmp.height - 2), 
                        draw.PointF(1, 1), 
                        draw.PointF(bmp.width - 2, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK_DARK), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(0, bmp.height), 
                        draw.PointF(bmp.width, bmp.height), 
                        draw.PointF(bmp.width, 0) ])

        bmp_bytes = io.BytesIO()
        bmp.save(bmp_bytes, drawing.imaging.ImageFormat.png)
        control.substitute_picture_format.picture.image = presentation.images.add_image(bmp_bytes)
    
    # Az ActiveX keretek 100 ponttal lefelé mozgatása
    for ctl in slide.controls:
        frame = control.frame
        control.frame = slides.ShapeFrame(
            frame.x, 
            frame.y + 100, 
            frame.width, 
            frame.height, 
            frame.flip_h, 
            frame.flip_v, 
            frame.rotation)

    # A prezentáció mentése szerkesztett ActiveX vezérlőkkel
    presentation.save("withActiveX-edited_out.pptm", slides.export.SaveFormat.PPTM)


    # Most a vezérlők eltávolítása
    slide.controls.clear()

    # A prezentáció mentése törölt ActiveX vezérlőkkel
    presentation.save("withActiveX.cleared_out.pptm", slides.export.SaveFormat.PPTM)
```

## **ActiveX Media Player vezérlő hozzáadása**
Az ActiveX Media Player vezérlő hozzáadásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a Presentation osztályból, és töltse be a mintaprezentációt, amely Media Player ActiveX vezérlőket tartalmaz.  
2. Hozzon létre egy példányt a cél Presentation osztályból, és generáljon egy üres prezentáció példányt.  
3. Klónozza a sablonprezentációban lévő Media Player ActiveX vezérlővel rendelkező diát a cél Presentation-be.  
4. Érje el a klónozott diát a cél Presentation-ben.  
5. Érje el a dián lévő ActiveX vezérlőket az IControlCollection használatával.  
6. Érje el a Media Player ActiveX vezérlőt, és állítsa be a videó útvonalát a tulajdonságainak használatával.  
7. Mentse a prezentációt egy PPTX fájlba.

```py
import aspose.slides as slides

# PPTX fájlt reprezentáló Presentation osztály példányosítása
with slides.Presentation(path + "template.pptx") as presentation:

    # Üres prezentációpéldány létrehozása
    with slides.Presentation() as newPresentation:

        # Alapértelmezett dia eltávolítása
        newPresentation.slides.remove_at(0)

        # Dia klónozása Media Player ActiveX vezérlővel
        newPresentation.slides.insert_clone(0, presentation.slides[0])

        # A Media Player ActiveX vezérlő elérése és a videó útvonal beállítása
        prop = newPresentation.slides[0].controls[0].properties

        prop.remove("URL")
        prop.add("URL", "Wildlife.mp4")

        # A prezentáció mentése
        newPresentation.save("LinkingVideoActiveXControl_out.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Megőrzi az Aspose.Slides az ActiveX vezérlőket olvasáskor és újra mentéskor, ha azok nem hajthatók végre a Python futtatókörnyezetben?**

Igen. Az Aspose.Slides a prezentáció részének tekinti őket, és képes olvasni/módosítani a tulajdonságaikat és kereteiket; a vezérlők tényleges végrehajtása nem szükséges a megőrzésükhöz.

**Hogyan különbözik az ActiveX vezérlő az OLE objektumoktól egy prezentációban?**

Az ActiveX vezérlők interaktív, kezelt vezérlések (gombok, szövegdobozok, média lejátszó), míg az [OLE](/slides/hu/python-net/manage-ole/) beágyazott alkalmazásobjektumokra (például egy Excel munkalapra) utal. Másként tárolják és kezelik őket, és más tulajdonságmodelljük van.

**Működnek az ActiveX események és VBA makrók, ha a fájlt az Aspose.Slides módosította?**

Az Aspose.Slides megőrzi a meglévő jelölést és metaadatokat; azonban az események és makrók csak akkor futnak a Windows PowerPointban, ha a biztonsági beállítások ezt megengedik. A könyvtár nem hajtja végre a VBA.