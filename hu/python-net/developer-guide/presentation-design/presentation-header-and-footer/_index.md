---
title: "Kezelje a bemutató fejléceit és lábléceit Pythonban"
linktitle: "Fejléc és lábléc"
type: docs
weight: 140
url: /hu/python-net/presentation-header-and-footer/
keywords:
- fejléc
- fejléc szöveg
- lábléc
- lábléc szöveg
- fejléc beállítása
- lábléc beállítása
- szórólap
- jegyzetek
- PowerPoint
- bemutató
- Python
- Aspose.Slides
description: "Használja az Aspose.Slides for Python .NET-en keresztül, hogy fejléceket és lábléceket adjon hozzá, és testre szabja őket PowerPoint és OpenDocument bemutatókban a professzionális megjelenés érdekében."
---
## **Áttekintés**

Aspose.Slides for Python segítségével precíz hatókörrel vezérelheti a fejlécek és láblécek helyfoglalóit a teljes bemutatóban. A lábléc szövegét, a dátum/idő értékét és a diák számát a mester szinten kezelik, és globálisan alkalmazhatók vagy egyes diákra szabhatók. A fejlécek a jegyzeteken és a szórólapokon támogatottak, ahol a láthatóságot be- vagy kikapcsolhatja, és a fejléc, lábléc, dátum/idő és oldal számok szövegét beállíthatja a dedikált header & footer manager segítségével a mester jegyzetdia vagy az egyes jegyzetdiákon. Ez a cikk ismerteti a fő mintákat ezeknek a helyfoglalóknak a frissítéséhez és a változások következetes terjesztéséhez a bemutatóban.

## **Fejléc és lábléc szöveg kezelése**

Ebben a részben megtanulja, hogyan kezelje a fejléc és a lábléc tartalmát egy bemutatóban – hogyan engedélyezze vagy módosítsa a láblécet, a dátumot és időt, valamint a diaszámokat. Röviden bemutatjuk a beállítások alkalmazásának hatókörét (az egész bemutató, egyes diák, valamint a jegyzet/szórólap nézetek) és megmutatjuk, hogyan használja az Aspose.Slides API-t azok gyors és következetes frissítéséhez.

Az alábbi kódrészlet megnyit egy bemutatót, engedélyezi és beállítja a lábléc szövegét, frissíti a fejléc szövegét a mester jegyzetdián, majd elmenti a fájlt.

```py
import aspose.slides as slides

# Függvény a fejléc szövegének beállításához.
def update_header_footer_text(master):
    for shape in master.shapes:
        if shape.placeholder is not None:
            if shape.placeholder.type == slides.PlaceholderType.HEADER:
                shape.text_frame.text = "Hi, there is a header"


# Load the presentation.
with slides.Presentation("sample.pptx") as presentation:
    # Állítsa be a láblécet.
    presentation.header_footer_manager.set_all_footers_text("My Footer text")
    presentation.header_footer_manager.set_all_footers_visibility(True)

    # Hozzáférés és a fejléc frissítése.
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        update_header_footer_text(master_notes_slide)

    # Mentse el a bemutatót.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Fejléc és lábléc kezelése jegyzetdiákon**

Ebben a részben megtanulja, hogyan kezelje a fejléceket és lábléceket kifejezetten a jegyzetdiákon az Aspose.Slides-ben. Kiterjedünk a releváns helyfoglalók engedélyezésére, a lábléc, a dátum/idő és az oldal számok szövegének beállítására, valamint a változások következetes alkalmazására a jegyzetmester és az egyes jegyzetoldalak között.

Kövesse az alábbi lépéseket:

1. Töltsön be egy bemutató fájlt.
2. Szerezze meg a mester jegyzetdiát és annak [header & footer manager](https://reference.aspose.com/slides/hu/python-net/aspose.slides/masternotesslideheaderfootermanager/).
3. A mester jegyzetdián engedélyezze a Header, Footer, Slide number és Date-time láthatóságát a mester és az összes gyerek jegyzetdia esetén.
4. A mester jegyzetdián állítsa be a Header, Footer és Date-time szövegét a mester és az összes gyerek jegyzetdia számára.
5. Szerezze meg az első bemutató dia jegyzetdiáját és annak [header & footer manager](https://reference.aspose.com/slides/hu/python-net/aspose.slides/notesslideheaderfootermanager/).
6. Csak ezen az első jegyzetdián ellenőrizze, hogy a Header, Footer, Slide number és Date-time látható legyen (kapcsolja be a ki van kapcsoltakat).
7. Csak ezen az első jegyzetdián állítsa be a Header, Footer és Date-time szövegét.
8. Mentse el a bemutatót PPTX formátumban.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide
    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        # Tegye láthatóvá a mester jegyzet diát és az összes gyermek fejléc, lábléc, dia szám és dátum/idő helyfoglalót.
        header_footer_manager.set_header_and_child_headers_visibility(True)
        header_footer_manager.set_footer_and_child_footers_visibility(True)
        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        # Állítson be szöveget a mester jegyzet dián és az összes gyermek fejléc, lábléc és dátum/idő helyfoglalón.
        header_footer_manager.set_header_and_child_headers_text("Header text")
        header_footer_manager.set_footer_and_child_footers_text("Footer text")
        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    # Módosítsa a fejléc, lábléc, dia szám és dátum/idő beállításait csak az első jegyzet dián.
    notesSlide = presentation.slides[0].notes_slide_manager.notes_slide
    if notesSlide is not None:
        header_footer_manager = notesSlide.header_footer_manager

        # Győződjön meg róla, hogy a fejléc, lábléc, dia szám és dátum/idő helyfoglalók láthatóak.
        if not header_footer_manager.is_header_visible:
            header_footer_manager.set_header_visibility(True)

        if not header_footer_manager.is_footer_visible:
            header_footer_manager.set_footer_visibility(True)

        if not header_footer_manager.is_slide_number_visible:
            header_footer_manager.set_slide_number_visibility(True)

        if not header_footer_manager.is_date_time_visible:
            header_footer_manager.set_date_time_visibility(True)

        # Állítson be szöveget a jegyzet dia fejlécén, láblécén és dátum/idő helyfoglalóin.
        header_footer_manager.set_header_text("New header text")
        header_footer_manager.set_footer_text("New footer text")
        header_footer_manager.set_date_time_text("New date and time text")

    # Mentse el a bemutatót.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Hozhatok "header"-t a normál diákra?**

PowerPointban a "Header" csak a jegyzeteken és a szórólapokon létezik; a szokásos diákon a támogatott elemek a "Footer", a "DateTime" és a "SlideNumber". Az Aspose.Slides-ben ez ugyanazokkal a korlátozásokkal egyezik: "Header" csak a Notes/Handout esetén, a diákon—"Footer"/"DateTime"/"SlideNumber".

**Mi van, ha a elrendezés nem tartalmaz lábléc területet—bekapcsolhatom a láthatóságát?**

Igen. Ellenőrizze a láthatóságot a header/footer manager segítségével, és ha szükséges, engedélyezze. Ezek az API jelzők és módszerek olyan esetekre lettek tervezve, amikor a helyfoglaló hiányzik vagy rejtve van.

**Hogyan állíthatom be, hogy a dia száma 1 helyett más értékről induljon?**

Állítsa be a bemutató [first slide number](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/first_slide_number/) értékét; ezután az összes számozás újraszámításra kerül. Például kezdhet 0‑nál vagy 10‑nél, és elrejtheti a számot a címdián.

**Mi történik a fejlécekkel/láblécekkel PDF/képek/HTML exportálásakor?**

A fejlécek és láblécek a bemutató szokásos szövegelemeként kerülnek renderelésre. Vagyis ha az elemek láthatóak a diákon/jegyzet oldalakon, akkor azok a kimeneti formátumban is megjelennek a többi tartalommal együtt.