---
title: "Diaelrendezések alkalmazása vagy módosítása Pythonban"
linktitle: "Diaelrendezés"
type: docs
weight: 60
url: /hu/python-net/slide-layout/
keywords:
- "diaelrendezés"
- "tartalom elrendezés"
- "helyőrző"
- "prezentáció tervezés"
- "dia tervezés"
- "használaton kívüli elrendezés"
- "lábléc láthatóság"
- "címdiára"
- "cím és tartalom"
- "szekciófejléc"
- "két tartalom"
- "összehasonlítás"
- "csak cím"
- "üres elrendezés"
- "tartalom felirattal"
- "kép felirattal"
- "cím és függőleges szöveg"
- "függőleges cím és szöveg"
- "PowerPoint"
- "OpenDocument"
- "Python"
- "Aspose.Slides"
description: "Ismerje meg, hogyan kezelheti és testre szabhatja a diaelrendezéseket az Aspose.Slides for Python ( .NET ) segítségével. Fedezze fel az elrendezéstípusokat, a helyőrzők vezérlését, a lábléc láthatóságát, valamint az elrendezések manipulálását Pythonkóddal példákon keresztül."
---
## **Bevezetés**

A diatérelrendezés meghatározza a helyőrződobozok elrendezését és a dián lévő tartalom formázását. Szabályozza, hogy mely helyőrzők érhetők el, és hol jelennek meg. A diatérelrendezések segítenek gyorsan és következetesen tervezni a prezentációkat – legyen szó egyszerű vagy bonyolult anyagról. A PowerPoint leggyakoribb diatérelrendezései közé tartozik:

**Címdiára** – Két szöveghelyőrzőt tartalmaz: egyet a címhez és egyet az alcímhez.

**Cím és tartalom** – Kisebb címhelyőrző a tetején, alatta nagyobb a fő tartalomhoz (például szöveg, felsorolás, diagramok, képek stb.).

**Üres elrendezés** – Nem tartalmaz helyőrzőket, teljes szabadságot ad a dia elrendezésének kialakításához.

A diatérelrendezések a dia-mester részei, amely a prezentáció elrendezési stílusait definiáló legfelső szintű dia. A diatérelrendezéseket a dia-mesteren keresztül érheted el és módosíthatod – típus, név vagy egyedi azonosító alapján. Alternatívaként egy konkrét diatérelrendezést közvetlenül a prezentáción belül is szerkeszthetsz.

A diatérelrendezésekkel való munka Aspose.Slides for Python‑ban a következőkkel lehetséges:

- Olyan tulajdonságok, mint a [layout_slides](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/layout_slides/) és a [masters](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/masters/) a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályon belül
- Típusok, mint a [LayoutSlide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutslide/), a [MasterLayoutSlideCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masterlayoutslidecollection/), a [LayoutPlaceholderManager](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutplaceholdermanager/) és a [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
A mesterdiaival kapcsolatos további információkért tekintsd meg a [Manage PowerPoint Slide Masters in Python](/slides/hu/python-net/slide-master/) cikket.
{{% /alert %}}

## **Diatérelrendezések hozzáadása a prezentációkhoz**

A diák megjelenésének és szerkezetének testreszabásához szükség lehet új diatérelrendezések hozzáadására a prezentációhoz. Az Aspose.Slides for Python lehetővé teszi, hogy ellenőrizd, létezik‑e már egy adott elrendezés, ha szükséges, újat adj hozzá, és ezt felhasználva helyezz be diát az adott elrendezés alapján.

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Érj hozzá a [MasterLayoutSlideCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masterlayoutslidecollection/) gyűjteményhez.
1. Ellenőrizd, hogy a kívánt diatérelrendezés már létezik‑e a gyűjteményben. Ha nem, add hozzá a szükséges elrendezést.
1. Adj hozzá egy üres diát az új diatérelrendezés alapján.
1. Mentsd el a prezentációt.

Az alábbi Python‑kód bemutatja, hogyan adhatunk diatérelrendezést egy PowerPoint‑prezentációhoz:

```python
import aspose.slides as slides

# A Presentation osztály példányosítása a prezentációfájl megnyitásához.
with slides.Presentation("sample.pptx") as presentation:
    # A diatérelrendezés típusokon végigmenve kiválaszt egy diatérelrendezést.
    layout_slides = presentation.masters[0].layout_slides
    layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)
    if layout_slide is None:
         layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE)

    if layout_slide is None:
        # Olyan helyzet, amikor a prezentáció nem tartalmaz minden elrendezéstípust.
        # A prezentációfájl csak Üres és Egyéni elrendezés típusokat tartalmaz.
        # Azonban az egyéni típusú diatérelrendezéseknek felismerhető neveik lehetnek,
        # például "Title", "Title and Content", stb., amelyeket a diatérelrendezés kiválasztásához használhat.
        # Emellett támaszkodhatsz a helyőrző alakzat típusok halmazára.
        # Például egy Címdiának csak a Cím helyőrzőtípusa kell legyen, és így tovább.
        for title_and_object_layout_slide in layout_slides:
            if title_and_object_layout_slide.name == "Title and Object":
                layout_slide = title_and_object_layout_slide
                break

        if layout_slide is None:
            for title_layout_slide in layout_slides:
                if title_layout_slide.name == "Title":
                    layout_slide = title_layout_slide
                    break

            if layout_slide is None:
                layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
                if layout_slide is None:
                    layout_slide = layout_slides.Add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Title and Object")

    # Üres diát ad hozzá a hozzáadott diatérelrendezés használatával.
    presentation.slides.insert_empty_slide(0, layout_slide)

    # Mentse a prezentációt a lemezre.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Használaton kívüli diatérelrendezések eltávolítása**

Az Aspose.Slides a [remove_unused_layout_slides](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) metódust a [Compress](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/compress/) osztályból biztosítja, amely lehetővé teszi a nem használt diatérelrendezések törlését.

Az alábbi Python‑kód megmutatja, hogyan távolítható el egy diatérelrendezés egy PowerPoint‑prezentációból:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Helyőrzők hozzáadása diatérelrendezésekhez**

Az Aspose.Slides a [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutslide/placeholder_manager/) tulajdonságot biztosítja, amely lehetővé teszi új helyőrzők hozzáadását egy diatérelrendezéshez.

Ez a menedzser a következő helyőrzőtípusokhoz kínál metódusokat:

| PowerPoint helyőrző                | [LayoutPlaceholderManager](https://reference.aspose.com/slides/hu/python-net/aspose.slides/layoutplaceholdermanager/) metódus |
| ----------------------------------- | ------------------------------------------------------------ |
| ![Content](content.png)             | add_content_placeholder(x: float, y: float, width: float, height: float) |
| ![Content (Vertical)](contentV.png) | add_vertical_content_placeholder(x: float, y: float, width: float, height: float) |
| ![Text](text.png)                   | add_text_placeholder(x: float, y: float, width: float, height: float) |
| ![Text (Vertical)](textV.png)       | add_vertical_text_placeholder(x: float, y: float, width: float, height: float) |
| ![Picture](picture.png)             | add_picture_placeholder(x: float, y: float, width: float, height: float) |
| ![Chart](chart.png)                 | add_chart_placeholder(x: float, y: float, width: float, height: float) |
| ![Table](table.png)                 | add_table_placeholder(x: float, y: float, width: float, height: float) |
| ![SmartArt](smartart.png)           | add_smart_art_placeholder(x: float, y: float, width: float, height: float) |
| ![Media](media.png)                 | add_media_placeholder(x: float, y: float, width: float, height: float) |
| ![Online Image](onlineimage.png)    | add_online_image_placeholder(x: float, y: float, width: float, height: float) |

Az alábbi Python‑kód bemutatja, hogyan adhatunk új helyőrzőalakzatokat az Üres diatérelrendezéshez:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Lekérjük az Üres elrendezés diát.
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    # Lekérjük a diatérelrendezés helyőrzőkezelőjét.
    placeholder_manager = layout.placeholder_manager

    # Hozzáadunk különböző helyőrzőket az Üres elrendezés diához.
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    # Hozzáadunk egy új diát az Üres elrendezéssel.
    new_slide = presentation.slides.add_empty_slide(layout)

    presentation.save("placeholders.pptx", slides.export.SaveFormat.PPTX)
```

Az eredmény:

![The placeholders on the layout slide](add_placeholders.png)

## **Lábléc láthatóságának beállítása egy diatérelrendezésnél**

PowerPoint‑prezentációkban a lábléc elemei, mint a dátum, diaszám és egyéni szöveg, a diatérelrendezéstől függően megjeleníthetők vagy elrejthetők. Az Aspose.Slides for Python lehetővé teszi ezen lábléchelyőrzők láthatóságának vezérlését. Ez hasznos, ha bizonyos elrendezésekben szeretnél lábléc‑információt mutatni, míg másokban tisztán tartani a megjelenést.

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Szerezd meg a diatérelrendezés referenciáját index alapján.
1. Állítsd a dia lábléc‑helyőrzőt láthatóvá.
1. Állítsd a diaszám‑helyőrzőt láthatóvá.
1. Állítsd a dátum‑idő‑helyőrzőt láthatóvá.
1. Mentsd el a prezentációt.

Az alábbi Python‑kód megmutatja, hogyan állítható be egy dia láblécének láthatósága és kapcsolódó feladatok:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    header_footer_manager = presentation.layout_slides[0].header_footer_manager

    if not header_footer_manager.is_footer_visible: 
        header_footer_manager.set_footer_visibility(True) 

    if not header_footer_manager.is_slide_number_visible:  
        header_footer_manager.set_slide_number_visibility(True) 

    if not header_footer_manager.is_date_time_visible: 
        header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_footer_text("Footer text") 
    header_footer_manager.set_date_time_text("Date and time text") 

    presentation.save("output.ppt", slides.export.SaveFormat.PPT)
```

## **Gyermeklábéc láthatóságának beállítása egy dián**

PowerPoint‑prezentációkban a lábléc elemei, például a dátum, a diaszám és az egyéni szöveg, a mesterdia szintjén is szabályozhatók, így konzisztens megjelenést biztosítva az összes diatérelrendezés számára. Az Aspose.Slides for Python lehetővé teszi ezen lábléchelyőrzők láthatóságának és tartalmának beállítását a mesterdian, majd ezek propagálását az összes gyermek‑diatérelrendezésre. Ez egységes lábléc‑információt biztosít a teljes prezentációban.

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Szerezz referenciát a mesterdira index alapján.
1. Állítsd a mester és az összes gyermek lábléc‑helyőrzőjét láthatóvá.
1. Állítsd a mester és az összes gyermek diaszám‑helyőrzőjét láthatóvá.
1. Állítsd a mester és az összes gyermek dátum‑idő‑helyőrzőjét láthatóvá.
1. Mentsd el a prezentációt.

Az alábbi Python‑kód demonstrálja ezt a műveletet:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager

    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)

    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Mi a különbség a mesterdia és a diatérelrendezés között?**

A mesterdia meghatározza a teljes témát és az alapértelmezett formázást, míg a diatérelrendezések konkrét helyőrző‑elrendezéseket definiálnak különböző tartalomtípusokhoz.

**Másolhatok‑e egy diatérelrendezést egy prezentációból a másikba?**

Igen, egy diatérelrendezést klónozhatsz egy prezentáció [layout_slides](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/layout_slides/) gyűjteményéből, és a `add_clone` metódussal beillesztheted egy másikba.

**Mi történik, ha egy még használatban lévő diatérelrendezést törlök?**

Ha megpróbálsz törölni egy diatérelrendezést, amelyre legalább egy dia hivatkozik a prezentációban, az Aspose.Slides egy [PptxEditException](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pptxeditexception/) kivételt dob. Ennek elkerülésére használd a [remove_unused_layout_slides](https://reference.aspose.com/slides/hu/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) metódust, amely csak a nem használt elrendezéseket távolítja el biztonságosan.