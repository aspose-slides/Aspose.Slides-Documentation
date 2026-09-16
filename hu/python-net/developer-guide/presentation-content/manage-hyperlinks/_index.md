---
title: Prezentáció hiperhivatkozások kezelése Pythonban
linktitle: Hiperhivatkozások kezelése
type: docs
weight: 20
url: /hu/python-net/manage-hyperlinks/
keywords:
- URL hozzáadása
- hiperhivatkozás hozzáadása
- hiperhivatkozás létrehozása
- hiperhivatkozás formázása
- hiperhivatkozás eltávolítása
- hiperhivatkozás frissítése
- szöveges hiperhivatkozás
- dia hiperhivatkozás
- alakzati hiperhivatkozás
- kép hiperhivatkozás
- videó hiperhivatkozás
- módosítható hiperhivatkozás
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Hiperhivatkozások hozzáadása, formázása, frissítése és eltávolítása PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python via .NET használatával, Python példákkal."
---
## **Bevezetés**

A hiperhivatkozás a prezentáció tartalmát egy weboldalhoz vagy a prezentáción belüli helyhez kapcsolja. A PowerPointban a hiperhivatkozások általában két célt szolgálnak:

* Weboldal megnyitása szövegből, alakzatból vagy média keretből.
* Ugrás egy másik diára, például egy tartalomjegyzékből.

Az Aspose.Slides for Python via .NET lehetővé teszi ezeknek a hivatkozásoknak a hozzáadását, megjelenésük és hangjuk vezérlését, tulajdonságaik frissítését, valamint eltávolításukat. Az alábbi példák bemutatják, hogyan dolgozhatunk hiperhivatkozásokkal egyedi elemeken, valamint hogyan érhetők el a hiperhivatkozások a prezentáció, dia vagy szövegkeret szintjén.

{{% alert color="info" title="Note" %}}
A prezentációkat a [ingyenes online Aspose PowerPoint szerkesztővel](https://products.aspose.app/slides/hu/editor) is szerkesztheti.
{{% /alert %}}

## **URL-hyperlinkek hozzáadása**

Weboldal URL-t rendelhet szöveghez, alakzathoz vagy média kerethez. Az a elem, amelyhez a hiperhivatkozást hozzárendeli, határozza meg a kattintható területet: egy szövegrész a kijelölt szöveget linkeli, míg egy alakzat vagy keret a diára vonatkozó objektumot.

### **URL-hyperlinkek hozzáadása szöveghez**

Szöveg weboldalhoz kapcsolásához rendelje a [Hyperlink](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlink/) objektumot a szövegrész [hyperlink_click](https://reference.aspose.com/slides/hu/python-net/aspose.slides/portionformat/hyperlink_click/) tulajdonságához, az alább látható módon. Csak ez a szövegrész lesz kattintható.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    text_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50, False)
    text_shape.add_text_frame("Aspose: File Format APIs")
    portion_format = text_shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    portion_format.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    portion_format.font_height = 32
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

### **URL-hyperlinkek hozzáadása alakzatokhoz és média keretekhez**

Egy alakzat vagy keret kattinthatóvá tételéhez állítsa be a [hyperlink_click](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/hyperlink_click/) tulajdonságát. A hiperhivatkozás az objektumhoz tartozik, nem egy benne lévő szövegrészhez.

Ugyanez az eljárás képek, hang- és videókeretek esetén is alkalmazható: rendelje a hiperhivatkozást a kerethez, és szükség esetén állítsa be a link [tooltip](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlink/tooltip/) attribútumát.

Az alábbi példa egy téglalapot tesz kattinthatóvá:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

## **Hyperlinkek használata tartalomjegyzék létrehozásához**

A belső hiperhivatkozások lehetővé teszik az olvasók számára, hogy a tartalomjegyzékből egy adott diára ugorjanak. Az alábbi példa a [set_internal_hyperlink_click](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlinkmanager/set_internal_hyperlink_click/) metódust használja, hogy a „Page 2” szöveget az első dián a második diára linkelje.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    table_of_contents = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 40, 40, 300, 100)
    table_of_contents.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.line_format.fill_format.fill_type = slides.FillType.NO_FILL
    table_of_contents.text_frame.paragraphs.clear()
    paragraph = slides.Paragraph()
    paragraph.paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
    paragraph.paragraph_format.default_portion_format.fill_format.solid_fill_color.color = draw.Color.black
    paragraph.text = "Title of slide 2 .......... "
    link_portion = slides.Portion()
    link_portion.text = "Page 2"
    link_portion.portion_format.hyperlink_manager.set_internal_hyperlink_click(second_slide)
    paragraph.portions.add(link_portion)
    table_of_contents.text_frame.paragraphs.add(paragraph)
    presentation.save("link_to_slide.pptx", slides.export.SaveFormat.PPTX)
```

## **Hyperlinkek formázása**

### **Szín**

A [Hyperlink](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlink/) [color_source](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlink/color_source/) tulajdonsága meghatározza, hogy a hiperhivatkozás a prezentáció hiperhivatkozás színét vagy a szövegrész formázását használja-e. Egy egyedi szövegszín alkalmazásához válassza a [HyperlinkColorSource.PORTION_FORMAT](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlinkcolorsource/) értéket, és állítsa be a rész kitöltő színét. Ez a funkció a PowerPoint 2019-ben került bevezetésre; a régebbi verziók nem támogatják ezt a beállítást.

Az alábbi példa két szöveg hiperhivatkozást ad ugyanarra a diára. Az első piros szövegtöltést használ, míg a második az alapértelmezett hiperhivatkozás színét tartja meg.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    colored_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 450, 50, False)
    colored_shape.add_text_frame("This hyperlink uses a custom color.")
    colored_portion_format = colored_shape.text_frame.paragraphs[0].portions[0].portion_format
    colored_portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    colored_portion_format.hyperlink_click.color_source = slides.HyperlinkColorSource.PORTION_FORMAT
    colored_portion_format.fill_format.fill_type = slides.FillType.SOLID
    colored_portion_format.fill_format.solid_fill_color.color = draw.Color.red
    default_shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 200, 450, 50, False)
    default_shape.add_text_frame("This hyperlink uses the default color.")
    default_shape.text_frame.paragraphs[0].portions[0].portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    presentation.save("presentation-out-hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

### **Hang**

A hiperhivatkozás aktiváláskor lejátszhat egy hangot, vagy leállíthat egy már játszott hangot. Az alábbi tulajdonságokkal konfigurálhatja ezeket a viselkedéseket:

- [Hyperlink.sound](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlink/sound/) megadja a hiperhivatkozáshoz tartozó hangot.
- [Hyperlink.stop_sound_on_click](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlink/stop_sound_on_click/) szabályozza, hogy a hiperhivatkozás aktiválása leállítja-e az előző hangot.

#### **Hyperlink hang hozzáadása**

Az alábbi példa betölti a `sampleaudio.wav` fájlt, és a első dián lévő gombhoz társítja. A gomb megnyomásakor a hang lejátszódik és a következő diára navigál. A dián lévő második alakzat a kattintáskor leállítja az előző hangot, anélkül hogy navigációs műveletet hajtana végre.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("sampleaudio.wav", "rb") as audio_file:
        audio_data = audio_file.read()
    hyperlink_sound = presentation.audios.add_audio(audio_data)
    first_slide = presentation.slides[0]
    play_button = first_slide.shapes.add_auto_shape(slides.ShapeType.SOUND_BUTTON, 100, 100, 100, 50)
    play_button.hyperlink_click = slides.Hyperlink.next_slide
    if not play_button.hyperlink_click.stop_sound_on_click and play_button.hyperlink_click.sound is None:
        play_button.hyperlink_click.sound = hyperlink_sound

    second_slide = presentation.slides.add_empty_slide(first_slide.layout_slide)
    stop_button = second_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 100, 50)
    stop_button.hyperlink_click = slides.Hyperlink.no_action
    stop_button.hyperlink_click.stop_sound_on_click = True
    presentation.save("hyperlink-sound.pptx", slides.export.SaveFormat.PPTX)
```

#### **Hyperlink hang kinyerése**

Az alábbi példa megnyitja a fent létrehozott prezentációt, és a [sound](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlink/sound/) és [binary_data](https://reference.aspose.com/slides/hu/python-net/aspose.slides/audio/binary_data/) segítségével a memóriába olvassa be az első alakzat hiperhivatkozáshoz tartozó hangot.

```python
import aspose.slides as slides

with slides.Presentation("hyperlink-sound.pptx") as presentation:
    if len(presentation.slides) > 0 and len(presentation.slides[0].shapes) > 0:
        hyperlink = presentation.slides[0].shapes[0].hyperlink_click
        sound = hyperlink.sound if hyperlink is not None else None
        if sound is not None:
            audio_data = sound.binary_data
            print(f"Extracted {len(audio_data)} bytes of hyperlink audio.")
        else:
            print("The first shape has no hyperlink sound.")
    else:
        print("The presentation has no first slide or shape to inspect.")
```

### **Buboréksúgó és interakció beállítások**

A következő [Hyperlink](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlink/) tulajdonságokat frissítheti egy hiperhivatkozás szöveghez vagy alakzathoz történő hozzárendelése után:

- [tooltip](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlink/tooltip/) beállítja a szöveget, amelyet a megjelenítő a hivatkozás felirataként jeleníthet meg.
- [target_frame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlink/target_frame/) határozza meg a célkeretet egy szülő HTML keretcsoporton belül, ha alkalmazható.
- [history](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlink/history/) szabályozza, hogy a hivatkozás aktiválása felveszi-e a célját a megtekintett hiperhivatkozások listájába.
- [highlight_click](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlink/highlight_click/) szabályozza, hogy a hiperhivatkozás ki legyen-e emelve kattintáskor.

## **Hyperlinkek eltávolítása prezentációkból**

Használja a [get_any_hyperlinks](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) metódust a hiperhivatkozás konténerek, köztük a szövegrész linkek gyűjtésére, mielőtt módosítaná őket. Az alábbi példa eltávolítja mindkét aktivációs típust az első diáról. Ha csak egy típust kíván eltávolítani, hívja meg kizárólag a [remove_hyperlink_click](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) vagy a [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/) metódust; a kattintási művelet eltávolítása nem vonja ki az egérrel való áthaladást.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    if len(presentation.slides) > 0:
        containers = list(presentation.slides[0].hyperlink_queries.get_any_hyperlinks())
        for container in containers:
            container.hyperlink_manager.remove_hyperlink_click()
            container.hyperlink_manager.remove_hyperlink_mouse_over()
        presentation.save("pres-removed-hyperlinks.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The presentation has no slides to process.")
```

Feltétlen eltávolításhoz a [remove_all_hyperlinks](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) eltávolítja mindkét aktivációs típust a kiválasztott hatókörben egy hívással. A szelektív tisztításhoz és a masterek, elrendezések és jegyzetek lefedettségéhez lásd a [Hyperlinkek jelentése, tisztítása, és ellenőrzése](#report-sanitize-and-verify-hyperlinks) részt.

## **Teljes hyperlink leltár felépítése**

A prezentáció terjesztése előtt készítsen leltárt az interaktív műveleteiről és webes linkjeiről. A [get_any_hyperlinks](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) [IHyperlinkContainer](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ihyperlinkcontainer/) objektumokat ad vissza, nem egyszerű URL-karakterláncok listáját. Vizsgálja meg minden konténeren a [hyperlink_click](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_click/) és a [hyperlink_mouse_over](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_mouse_over/) tulajdonságokat. Ezek függetlenek: ugyanaz a konténer mindkét műveletet tartalmazhatja, ezért egy teljes jelentéshez konténerenként akár két sorra is szükség van.

Csak alakzati szintű hiperhivatkozások keresése kihagyhatja a szövegrészekhez csatolt linkeket. Inkább a megfelelő hatókört kérdezze le, és őrizze meg a visszakapott konténereket, hogy később frissíthesse vagy eltávolíthassa műveleteiket.

### **Prezentáció, dia és szövegkeret hatókörök lekérdezése**

A [HyperlinkQueries](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlinkqueries/) osztály a [Presentation.hyperlink_queries](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/hyperlink_queries/), a [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseslide/hyperlink_queries/) és a [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/hu/python-net/aspose.slides/textframe/hyperlink_queries/) keresztül érhető el. Minden hatókör támogatja ugyanazokat a lekérdezéseket:

- [get_hyperlink_clicks](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/) konténereket ad vissza kattintási művelettel.
- [get_hyperlink_mouse_overs](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/) konténereket ad vissza egérrel való áthaladási művelettel.
- [get_any_hyperlinks](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) konténereket ad vissza bármely vagy mindkét művelettel.

Az alábbi példa létrehozza a `hyperlink-audit-input.pptx` fájlt, amely külső kattintási linket, fájl egérrel való áthaladási linket, belső diánavigációt, szöveg egérrel való áthaladási linket és egy makró műveletet tartalmaz. Egyik műveletet sem hajtja végre. Ugyanaz a három lekérdezés minden hatókörben működik; a számlálók konténereket, nem műveletek összegét mutatják. A szövegkeret hatókör kizárja a körülvevő alakzat saját linkjeit.

```python
import aspose.slides as slides


def print_counts(scope, queries):
    click_containers = queries.get_hyperlink_clicks()
    mouse_over_containers = queries.get_hyperlink_mouse_overs()
    all_containers = queries.get_any_hyperlinks()
    print(f"{scope}: click={len(click_containers)}, mouse-over={len(mouse_over_containers)}, any={len(all_containers)}")


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    destination = presentation.slides.add_empty_slide(slide.layout_slide)
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 400, 60)
    shape.text_frame.text = "Click the text to go to slide 2"
    shape.hyperlink_manager.set_external_hyperlink_click("https://example.com/")
    shape.hyperlink_click.tooltip = "Public website"
    shape.hyperlink_manager.set_external_hyperlink_mouse_over("file:///C:/private/report.xlsx")

    portion_format = shape.text_frame.paragraphs[0].portions[0].portion_format
    portion_format.hyperlink_manager.set_internal_hyperlink_click(destination)
    portion_format.hyperlink_manager.set_external_hyperlink_mouse_over("https://example.com/help")
    macro_button = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 120, 200, 60)
    macro_button.hyperlink_manager.set_macro_hyperlink_click("ReviewPresentation")

    print_counts("Presentation", presentation.hyperlink_queries)
    print_counts("Slide 1", slide.hyperlink_queries)
    print_counts("Text frame", shape.text_frame.hyperlink_queries)
    presentation.save("hyperlink-audit-input.pptx", slides.export.SaveFormat.PPTX)
```

Ehhez a példához a prezentáció és a dia lekérdezések három kattintási konténert, két egérrel áthaladási konténert és három konténert jelentettek, amelyek bármelyik művelettel rendelkeznek. A szövegkeret lekérdezés egy konténert jelent minden kategóriában.

### **Műveletek és célpontok osztályozása**

A [Hyperlink.action_type](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlink/action_type/) használatával értelmezze a műveletet, mielőtt a célpontot vizsgálná. A [HyperlinkActionType](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlinkactiontype/) értékek a webes navigáción túl is kiterjednek:

| Értékek | Jelentés jelentésben |
| --- | --- |
| `HYPERLINK` | Külső hiperhivatkozás; ellenőrizze az URL-t és annak sémáját. |
| `JUMP_SPECIFIC_SLIDE` | Belső navigáció egy adott diára. |
| `JUMP_FIRST_SLIDE`, `JUMP_PREVIOUS_SLIDE`, `JUMP_NEXT_SLIDE`, `JUMP_LAST_SLIDE`, `JUMP_LAST_VIEWED_SLIDE` | Beépített diavetítés navigáció, a diavetítés kontextusában értelmezve. |
| `JUMP_END_SHOW`, `START_CUSTOM_SLIDE_SHOW` | Az aktuális előadás befejezése vagy egy egyedi előadás indítása. |
| `START_MACRO` | Makró végrehajtása. |
| `START_PROGRAM` | Program indítása. |
| `OPEN_FILE`, `OPEN_PRESENTATION` | Fájl vagy másik prezentáció megnyitása; külön kell értékelni a webes URL-ektől. |
| `START_STOP_MEDIA` | Média lejátszás indítása vagy leállítása. |
| `NO_ACTION`, `UNKNOWN` | Nincs navigációs művelet, vagy egy ismeretlen, felülvizsgálatot igénylő művelet. |

Olvassa be a külső célpontokat a [external_url](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlink/external_url/) segítségével, és a belső célpontokat a [target_slide](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlink/target_slide/) tulajdonságból. Belső műveletek és beépített parancsok esetén előfordulhat, hogy nincs külső URL; egy üres URL nem jelenti, hogy a konténernek nincs művelete. Őrizze meg a [external_url_original](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlink/external_url_original/) értékét, ha eltér a normalizált URL-től, és adja hozzá a [tooltip](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlink/tooltip/) értékét, ha elérhető.

### **Hyperlinkek jelentése, tisztítása, és ellenőrzése**

Az alábbi Python példa megnyit egy meglévő prezentációt (használja a fent létrehozott fájlt), írja a `hyperlink-audit.json` fájlt, alkalmaz egy szabályt, elmenti a `hyperlink-sanitized.pptx` fájlt, majd újra megnyitja, hogy újra ellenőrizze mindkét aktivációs típust. A konténereket módosítás előtt gyűjti, és minden diahatókört egyszer kérdez le, hogy elkerülje a duplikált feldolgozást. A prezentáció lekérdezések a szokásos diákra vonatkoznak; egy csomagra kiterjedő leltárhoz a példa a szokásos diák, masterek, elrendezések, jegyzetek és a jegyzet- és kiosztási masterek lekérdezését is tartalmazza, ha léteznek.

A jelentés rögzíti a egy‑alapú diaindexet és a [slide_id](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseslide/slide_id/) értékét, ha elérhető. A gyűjtő megőrzi a tulajdonos diát és a hatókört minden visszaadott konténer mellett. A masterek, elrendezések és jegyzetek nem rendelkeznek szokásos diaindexszel, és hatókörük alapján azonosíthatók. Az alakzatkonténereket és a szövegrész‑formázási konténereket külön jelöli; a többi konténer típusa megtartja a futási típus nevét. Minden konténer kap egy jelentés‑lokális azonosítót, hogy a két művelet összekapcsolható legyen.

Ez a szándékosan szigorú alkalmazási szabály csak abszolút HTTPS URL-eket és érvényes belső dia‑célpontokat engedélyez. Elutasítja a makrókat, programokat, fájl‑műveleteket, egyéb diavetítési műveleteket, ismeretlen műveleteket és egyéb URL‑sémákat. Ezek az elutasítások szabályozási döntések, nem pedig az Aspose.Slides biztonsági megítélése. Az HTTPS önmagában nem teremti meg a bizalmat: adjon hozzá host‑engedélylistákat és egyéb ellenőrzéseket az alkalmazásához. Az eredeti és a normalizált külső URL-ek egyaránt ellenőrzésre kerülnek. A példa a metaadatokat auditálja anélkül, hogy a linkeket követné vagy a műveleteket végrehajtaná.

A tisztításra a konténer [hyperlink_manager](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_manager/) támogatja a [set_external_hyperlink_click](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/), a [remove_hyperlink_click](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) és a [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/) metódusokat. Itt a tiltott külső kattintási linkek helyettesítve vannak egy rögzített HTTPS céloldallal; a többi tiltott kattintás és tiltott egér‑over művelet önállóan eltávolításra kerül. Állítsa a `replace_external_clicks` értékét `False`‑ra, hogy minden szabálysértést eltávolítson. Válasszon egy alkalmazás‑tulajdonú helyettesítő oldalt a bevezetés előtt.

A jelentés export‑zási flagje konzervatív PDF‑ellenőrzési szabályt alkalmaz: az egér‑over műveleteket és minden mást, ami nem külső link vagy konkrét dia‑ugrás, potenciálisan nem támogatottként jelöli. Ez egy ellenőrzési jelzés, nem egy képesség‑teszt vagy garancia arra, hogy a jelöletlen linkek megmaradnak exportáláskor. A támogatott [PDF](/slides/hu/python-net/convert-powerpoint-to-pdf/) és [HTML](/slides/hu/python-net/convert-powerpoint-to-html/) exportok megőrizhetik a hyperlinkeket, a művelettől, az export‑opcióktól és a megjelenítőtől függően. A raszteres [images](/slides/hu/python-net/convert-powerpoint-to-png/) és [video](/slides/hu/python-net/convert-powerpoint-to-video/) nem őrizhetik meg az interaktív hyperlinkeket; auditáláskor minden ilyen kimenetnél jelölje az összes műveletet.

```python
import json
import sys
from urllib.parse import urlsplit
import aspose.slides as slides


def is_https(value):
    if not value or any(character.isspace() for character in value):
        return False
    try:
        uri = urlsplit(value)
        return uri.scheme.lower() == "https" and bool(uri.hostname)
    except ValueError:
        return False


def policy_violation(link):
    if link is None:
        return None
    if link.action_type == slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE:
        return "Missing target slide" if link.target_slide is None else None
    if link.action_type != slides.HyperlinkActionType.HYPERLINK:
        return "Action is not allowed"
    if not is_https(link.external_url):
        return "Normalized URL is not absolute HTTPS"
    original = link.external_url_original
    if original and not is_https(original):
        return "Original URL is not absolute HTTPS"
    return None


def slide_index(presentation, slide):
    if slide is not None:
        for index, candidate in enumerate(presentation.slides, start=1):
            if candidate.slide_id == slide.slide_id:
                return index
    return None


def collect_containers(presentation):
    # Lekérdezi minden dia hatókörét egyszer, minden konténerhez megtartva a tulajdonost.
    scopes = [("Slide", slide) for slide in presentation.slides]
    scopes.extend(("Master", master) for master in presentation.masters)
    scopes.extend(("Layout", layout) for layout in presentation.layout_slides)
    scopes.extend(("Notes", slide.notes_slide_manager.notes_slide) for slide in presentation.slides)
    scopes.append(("Notes master", presentation.master_notes_slide_manager.master_notes_slide))
    scopes.append(("Handout master", presentation.master_handout_slide_manager.master_handout_slide))
    found = []
    for scope, owner in scopes:
        if owner is not None:
            containers = list(owner.hyperlink_queries.get_any_hyperlinks())
            found.extend((container, scope, owner) for container in containers)
    return found


def add_row(rows, presentation, link, activation, container, container_id, scope, owner):
    if link is None:
        return
    target_slide = link.target_slide
    violation = policy_violation(link)
    if isinstance(container, slides.Shape):
        owner_type = "Shape"
    elif isinstance(container, slides.PortionFormat):
        owner_type = "Text portion"
    else:
        owner_type = type(container).__name__
    ordinary_action = link.action_type in (slides.HyperlinkActionType.HYPERLINK, slides.HyperlinkActionType.JUMP_SPECIFIC_SLIDE)
    original_url = link.external_url_original if link.external_url_original != link.external_url else None
    rows.append({
        "container_id": container_id,
        "slide_index": slide_index(presentation, owner) if scope == "Slide" else None,
        "slide_id": owner.slide_id,
        "scope": scope,
        "owner_type": owner_type,
        "activation": activation,
        "action_type": link.action_type.name,
        "external_url": link.external_url,
        "target_slide_index": slide_index(presentation, target_slide),
        "target_slide_id": target_slide.slide_id if target_slide is not None else None,
        "tooltip": link.tooltip,
        "original_external_url": original_url,
        "potentially_unsafe": violation is not None,
        "policy_violation": violation,
        "target_export": "PDF",
        "potentially_unsupported_by_export": activation == "mouse-over" or not ordinary_action,
    })


replace_external_clicks = True
replacement_url = "https://example.com/blocked-link"

with slides.Presentation("hyperlink-audit-input.pptx") as presentation:
    containers = collect_containers(presentation)
    rows = []
    for container_id, (container, scope, owner) in enumerate(containers, start=1):
        add_row(rows, presentation, container.hyperlink_click, "click", container, container_id, scope, owner)
        add_row(rows, presentation, container.hyperlink_mouse_over, "mouse-over", container, container_id, scope, owner)

    with open("hyperlink-audit.json", "w", encoding="utf-8") as report_file:
        json.dump(rows, report_file, indent=2)

    for container, scope, owner in containers:
        click = container.hyperlink_click
        if policy_violation(click) is not None:
            if replace_external_clicks and click.action_type == slides.HyperlinkActionType.HYPERLINK:
                container.hyperlink_manager.set_external_hyperlink_click(replacement_url)
            else:
                container.hyperlink_manager.remove_hyperlink_click()
        if policy_violation(container.hyperlink_mouse_over) is not None:
            container.hyperlink_manager.remove_hyperlink_mouse_over()

    presentation.save("hyperlink-sanitized.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("hyperlink-sanitized.pptx") as reopened:
    remaining_containers = collect_containers(reopened)
    violations = 0
    for container, scope, owner in remaining_containers:
        if policy_violation(container.hyperlink_click) is not None:
            violations += 1
        if policy_violation(container.hyperlink_mouse_over) is not None:
            violations += 1
    print(f"Audit rows: {len(rows)}; prohibited actions after reopening: {violations}")
    if violations != 0:
        print("Verification failed: do not distribute the saved presentation.")
        sys.exit(1)
```

A fenti bemenettel a jelentés öt műveletsort tartalmaz. A fájl‑egér‑over link és a makró‑kattintás eltávolításra kerül, míg a HTTPS‑linkek és a belső dia‑navigáció megmarad. Az ellenőrzés nulla tiltott műveletet jelez. Egy tiltott külső kattintási URL‑t tartalmazó bemenet a helyettesítési ágat is lefedi. Egy engedélyezett kattintással és tiltott egér‑overrel rendelkező konténer megtartja a kattintási műveletét.

Ez a szelektív tisztítás eltér a [remove_all_hyperlinks](https://reference.aspose.com/slides/hu/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) működésétől, ami a kiválasztott hatókörben mindkét aktivációs típust eltávolítja, függetlenül a szabálytól. Az itt végzett ellenőrzés csak a hyperlink műveleteket vizsgálja; nem távolítja el a beágyazott VBA‑projekteket, OLE‑objekteket vagy egyéb aktív tartalmakat, és nem validálja a PDF‑ vagy HTML‑exportot.

## **GYIK**

**Hogyan linkelhetek egy szekcióra vagy annak első diájára?**

A PowerPointban a szekciók diákat csoportosítanak, de egy belső hiperhivatkozás egy adott diát céloz meg. A szekcióra való navigáció létrehozásához linkelje az első diát a szekcióban.

**Csatolhatok-e hiperhivatkozást a mesterdia elemeihez, hogy minden dián működjön?**

Igen. A mesterdia és elrendezési elemek támogatják a hiperhivatkozásokat. Ezeken az elemeken lévő linkek a diavetítés során elérhetők azon diákon, amelyek a megfelelő mastert vagy elrendezést használják.

**Megmaradnak-e a hiperhivatkozások PDF, HTML, képek vagy videó exportálásakor?**

A támogatott PDF és HTML exportálások megőrizhetik a hiperhivatkozásokat; a raszteres képek és a videó nem. Lásd az exportálási szempontokat a [Hyperlinkek jelentése, tisztítása, és ellenőrzése](#report-sanitize-and-verify-hyperlinks) részben.