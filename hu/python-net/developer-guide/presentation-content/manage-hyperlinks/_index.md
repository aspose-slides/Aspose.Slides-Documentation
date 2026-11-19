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
- alakzat hiperhivatkozás
- kép hiperhivatkozás
- videó hiperhivatkozás
- módosítható hiperhivatkozás
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Hiperhivatkozások hozzáadása, formázása, frissítése és eltávolítása PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python via .NET segítségével, Python példákkal."
---
## **Bevezetés**

A hiperhivatkozás a prezentáció tartalmát egy weboldalhoz vagy a prezentáción belüli helyhez kapcsolja. A PowerPointban a hiperhivatkozások általában két célt szolgálnak:

* Weboldal megnyitása szövegből, alakzatból vagy média keretből.
* Navigálás egy másik diára, például a tartalomjegyzékből.

Az Aspose.Slides for Python via .NET lehetővé teszi ezeknek a linkeknek a hozzáadását, megjelenésük és hangjuk szabályozását, tulajdonságaik frissítését és eltávolítását. Az alábbi példák bemutatják, hogyan dolgozhatunk hiperhivatkozásokkal egyedi elemeknél, valamint hogyan érhetjük el a hiperhivatkozásokat a prezentáció, dia vagy szövegkeret szinten.

{{% alert color="info" title="Note" %}}
A prezentációkat a [ingyenes online Aspose PowerPoint szerkesztővel](https://products.aspose.app/slides/editor) is szerkesztheti.
{{% /alert %}}

## **URL‑hyperhivatkozások hozzáadása**

Weboldal‑URL‑t rendelhet szöveghez, alakzathoz vagy média kerethez. Az a elem, amelyhez a hiperhivatkozást rendeli, meghatározza a kattintható területet: egy szövegrész a kiválasztott szöveget linkeli, míg egy alakzat vagy keret a diaobjektumot.

A relatív hiperhivatkozásokat tartalmazó prezentációk esetén tekintse meg a [A hyperhivatkozás alapjának kezelése](/slides/hu/python-net/presentation-properties/#manage-the-hyperlink-base) cikket a dokumentumszintű alap beolvasásához, módosításához vagy törléséhez.

### **URL‑hyperhivatkozások hozzáadása szöveghez**

A szöveget weboldalra linkelhetjük úgy, hogy a szövegrész [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/hyperlink_click/) tulajdonságához egy [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) objektumot rendeljünk, az alábbiakban látható módon. Csak ez a szövegrész lesz kattintható.

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

### **URL‑hyperhivatkozások hozzáadása alakzatokhoz és média keretekhez**

A téglalap [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/shape/hyperlink_click/) tulajdonságához rendelt URL az egész területét kattinthatóvá teszi. A [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) a felhasználónak tippet ad a célról, amikor az egér a téglalap fölé kerül. Ugyanez a beállítás vonatkozik képek, audio‑ és videó‑keretekre is.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 600, 50)
    shape.hyperlink_click = slides.Hyperlink("https://www.aspose.com/")
    shape.hyperlink_click.tooltip = "Explore Aspose file format APIs"
    presentation.save("presentation-out.pptx", slides.export.SaveFormat.PPTX)
```

## **Hyperhivatkozások használata tartalomjegyzék létrehozásához**

Belső hiperhivatkozásokkal a felhasználó a tartalomjegyzékből egy adott diára ugorhat. Az alábbi példa a [set_internal_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/set_internal_hyperlink_click/) metódust használja, hogy a „Page 2” szöveget az első dián a második diára linkelje.

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

## **Hyperhivatkozások formázása**

Módosíthatja a linkelt szöveg színét, lejátszhat vagy leállíthat hangot, amikor a felhasználó aktiválja a linket, és beállíthatja a buboréksúgót, amely a rámutatáskor jelenik meg.

### **Szín**

A [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/) tulajdonsága határozza meg, hogy a hiperhivatkozás a prezentáció hiperhivatkozás‑színét vagy a szövegrész formázását használja. Egy egyéni szövegszín alkalmazásához válassza a [HyperlinkColorSource.PORTION_FORMAT](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkcolorsource/) értéket, és állítsa be a rész kitöltőszínét. Ez a funkció a PowerPoint 2019‑ben került bevezetésre; a régebbi verziók nem alkalmazzák ezt a beállítást.

Ebben a példában a [color_source](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/color_source/) beállítása az első linknél piros színűvé teszi a szöveget. A második link a prezentáció hiperhivatkozás‑színét tartja meg.

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

A hiperhivatkozás aktiválásakor lejátszhat hangot, vagy leállíthatja a már játszott hangot. A következő tulajdonságokkal konfigurálhatja ezeket a viselkedéseket:

- [Hyperlink.sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) megadja a hiperhivatkozáshoz kapcsolódó hangot.
- [Hyperlink.stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/) szabályozza, hogy a hiperhivatkozás aktiválása leállítja‑e az előző hangot.

#### **Hyperhivatkozás hangjának hozzáadása**

Az első dián lévő gomb a [sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) használatával WAV‑fájlból játssza le a hangot, amikor a felhasználó a diát előre lépteti. A második dián egy külön gomb a [stop_sound_on_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/stop_sound_on_click/) segítségével leállítja a lejátszást és a felhasználót azon a dián tartja.

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

#### **Hyperhivatkozás hangjának kibontása**

Az alábbi példa megnyitja a fent létrehozott prezentációt, és a [sound](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/sound/) és a [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/audio/binary_data/) segítségével a memóriaba olvassa be az első alakzat hiperhivatkozás‑hangját.

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

A következő [Hyperlink](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/) tulajdonságokat frissítheti egy hiperhivatkozás szöveghez vagy alakzathoz történő hozzárendelése után:

- [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) a megjelenő tipp szövegét állítja be a hivatkozáshoz.
- [target_frame](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_frame/) megadja a céltáblát egy szülő HTML keretcsoporton belül, ha alkalmazható.
- [history](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/history/) szabályozza, hogy a hivatkozás aktiválása felveszi‑e a célt a megtekintett hyperlink‑listába.
- [highlight_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/highlight_click/) szabályozza, hogy a hiperhivatkozás ki legyen‑e emelve kattintáskor.

## **Hyperhivatkozások eltávolítása a prezentációkból**

Az [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) segítségével gyűjtheti össze a hyperlink‑konténereket, beleértve a szövegrész‑linkeket is, mielőtt módosítaná őket. Az alábbi példa mindkét aktiválási típust eltávolítja az első diáról. Egyetlen típus eltávolításához csak a [remove_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) vagy a [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/) hívását kell használni; a kattintási művelet eltávolítása nem távolítja el az egér‑felvitelhez tartozó párját.

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

Feltétlen eltávolításhoz a [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) mindkét aktiválási típust egy hívással törli a kiválasztott hatókörben. A mesterek, elrendezések és megjegyzések szelektív takarítása és lefedettsége érdekében lásd a [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) részt.

### **Hyperhivatkozások törlése a SmartArt szöveg cseréje előtt**

Amikor egy meglévő SmartArt‑csomópont bekezdését cseréli, a szövegrészek törlése régi hiperhivatkozást hagyhat működésben. A bekezdést a [SmartArtNode.text_frame](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartartnode/text_frame/) segítségével hívja le. A részek törlése előtt hívja meg a [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) metódust a csomópont alakzatának szövegkeretén keresztül a [hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/hyperlink_queries/) objektumon. Ez minden hiperhivatkozást eltávolít az adott keretből, beleértve a többi bekezdésben lévő linkeket is.

A `SmartArtHyperlink.pptx` fájlban az első dia harmadik alakzata egy SmartArt‑grafika. A példa a negyedik csomópont első bekezdését cseréli. Ebben a prezentációban a csomópont első alakzata jeleníti meg azt a bekezdést.

A két rész hozzáadása után a példa a [get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/) segítségével olvassa ki a hatékony formázást. A hatékony [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/iportionformateffectivedata/hyperlink_click/) tulajdonság az első részhez új hyperlink‑t, a másodikhoz pedig `None`‑t ad vissza.

```python
import aspose.slides as slides

with slides.Presentation("SmartArtHyperlink.pptx") as presentation:
    slide = presentation.slides[0]

    smart_art = slide.shapes[2]
    node = smart_art.all_nodes[3]
    paragraph = node.text_frame.paragraphs[0]

    node.shapes[0].text_frame.hyperlink_queries.remove_all_hyperlinks()
    paragraph.portions.clear()

    link = slides.Portion("New reference")
    link.portion_format.hyperlink_click = slides.Hyperlink("https://example.com/new")
    paragraph.portions.add(link)
    text = slides.Portion(" (updated)")
    paragraph.portions.add(text)

    print(link.portion_format.get_effective().hyperlink_click.external_url)  # https://example.com/new
    print(text.portion_format.get_effective().hyperlink_click)  # None
```

## **Teljes hyperhivatkozás‑nyilvántartás létrehozása**

Mielőtt a prezentációt közzétenné, vegye fel egy interaktív műveletek és webes linkek nyilvántartását. Az [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) [IHyperlinkContainer](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/) objektumokat ad vissza, nem egyszerű URL‑stringek listáját. Vizsgálja meg mind a [hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_click/), mind a [hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_mouse_over/) tulajdonságokat minden egyes tárolón. Ezek függetlenek: egy tároló mindkét műveletet kiexponálhatja, így egy teljes jelentés akár két sorra is szükség lehet tárolónként.

Az alakzatszintű hiperhivatkozások csak a szövegrészekhez csatolt linkeket hagyhatják ki. Kérdezze le a megfelelő hatókört, és tartsa meg a visszakapott tárolókat, hogy később frissíthesse vagy eltávolíthassa azok műveleteit.

### **Prezentáció, dia és szövegkeret hatókörök lekérdezése**

A [HyperlinkQueries](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/) osztály a [Presentation.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/hyperlink_queries/), [BaseSlide.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/hyperlink_queries/) és [TextFrame.hyperlink_queries](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/hyperlink_queries/) útján érhető el. Minden hatókör ugyanazokat a lekérdezéseket támogatja:

- [get_hyperlink_clicks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_clicks/) visszaadja a kattintási művelettel rendelkező tárolókat.
- [get_hyperlink_mouse_overs](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_hyperlink_mouse_overs/) visszaadja az egérrel felvitele művelettel rendelkező tárolókat.
- [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) visszaadja az egyik vagy mindkét művelettel rendelkező tárolókat.

Ez a példa kattintási és egér‑felvitel műveleteket rendel egy alakzathoz és szövegéhez, valamint egy makró‑műveletet egy külön gombhoz. Összeveti a [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) által visszaadott tárolókat az egyes aktiválási típusok számával. Egy szövegkeret‑lekérdezés csak a szövegben lévő linkeket számolja. A körülvevő alakzat saját műveletei a dia‑ és prezentáció‑lekérdezésekben is megjelennek.

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

Az ebben a példában a prezentáció‑ és dia‑lekérdezések három kattintási, két egér‑felvitel és három kombinált tárolót jelentenek. A szövegkeret‑lekérdezés minden kategóriában egy tárolót ad vissza.

### **Műveletek és célok osztályozása**

A [Hyperlink.action_type](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/action_type/) segítségével értelmezheti a műveletet, mielőtt a célját vizsgálná. A [HyperlinkActionType](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkactiontype/) értékek több mint webes navigációt fednek le:

| Értékek | Jelentés egy audit számára |
| --- | --- |
| `HYPERLINK` | Külső hiperhivatkozás; ellenőrizze az URL‑t és protokollját. |
| `JUMP_SPECIFIC_SLIDE` | Belső navigáció egy adott diára. |
| `JUMP_FIRST_SLIDE`, `JUMP_PREVIOUS_SLIDE`, `JUMP_NEXT_SLIDE`, `JUMP_LAST_SLIDE`, `JUMP_LAST_VIEWED_SLIDE` | Beépített diavetítés‑navigáció, a diavetítés kontextusában értelmezve. |
| `JUMP_END_SHOW`, `START_CUSTOM_SLIDE_SHOW` | Az aktuális műsor befejezése vagy egy egyéni műsor indítása. |
| `START_MACRO` | Makró végrehajtása. |
| `START_PROGRAM` | Program indítása. |
| `OPEN_FILE`, `OPEN_PRESENTATION` | Fájl vagy másik prezentáció megnyitása; külön vizsgálja a web‑URL‑től. |
| `START_STOP_MEDIA` | Média lejátszás indítása vagy leállítása. |
| `NO_ACTION`, `UNKNOWN` | Nincs navigációs művelet, vagy egy ismeretlen művelet, amely felülvizsgálatot igényel. |

Olvassa ki a külső célokat a [external_url](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url/) tulajdonságból, a konkrét belső célokat pedig a [target_slide](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/target_slide/) segítségével. Belső műveletek és beépített parancsok nem feltétlenül rendelkeznek külső URL‑vel; egy üres URL nem jelenti, hogy a tároló ne rendelkezik művelettel. Őrizze meg a [external_url_original](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/external_url_original/) értékét, ha eltér a normalizált URL‑től, és adja hozzá a [tooltip](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlink/tooltip/) tartalmát, ha elérhető.

### **Hyperhivatkozások jelentése, tisztítása és ellenőrzése**

Ez a példa megnyitja a korábbi példában létrehozott prezentációt, és minden művelethez egy JSON‑rekordot ír. A [get_any_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/get_any_hyperlinks/) segítségével gyűjti a tárolókat a normál diákon, mestereken, elrendezéseken és megjegyzéseken, beleértve a megjegyzés‑ és előadásmester‑elemeket is, ha jelen vannak. Minden hatókört egyszer kérdez le a duplikált feldolgozás elkerülése érdekében, alkalmazza az alább leírt szabályzatot, majd újra megnyitja a mentett prezentációt, hogy ellenőrizze a kattintási és egér‑felvitel műveleteket.

A jelentés tartalmaz egy 1‑től indexelt diaszámot és a [slide_id](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/slide_id/)‑t, ha elérhető. A gyűjtő a visszaadott tárolókkal együtt megőrzi a tulajdonos diát és hatókört. A mesterek, elrendezések és megjegyzések nem rendelkeznek normál dia‑indexszel, és a hatókörükkel azonosítják őket. Az alakzat‑tárolók és a szöveg‑részformázási tárolók külön címkézettek; egyéb tárolótípusok megtartják futásidejű típusnevüket. Minden tároló helyi jelentés‑ID‑t kap, így a két művelet összekapcsolható.

Ez a szándékosan szigorú alkalmazási szabályzat csak abszolút HTTPS‑URL‑ket és érvényes belső diárcélokat engedélyezi. Elutasítja a makrókat, programokat, fájl‑műveleteket, egyéb diavetítés‑parancsokat, ismeretlen műveleteket és egyéb URL‑sémákat. Ezek az elutasítások szabályzat‑döntések, nem az Aspose.Slides biztonsági ítéletei. A HTTPS önmagában nem biztosít bizalmat: adjon hozzá host‑engedélylistákat és egyéb ellenőrzéseket az alkalmazásához. Mind az eredeti, mind a normalizált külső URL‑ket ellenőrzik. A példa a metaadatokat auditálja linkek követése vagy műveletek futtatása nélkül.

Javítás céljából a tároló [hyperlink_manager](https://reference.aspose.com/slides/python-net/aspose.slides/ihyperlinkcontainer/hyperlink_manager/) támogatja a [set_external_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/set_external_hyperlink_click/), a [remove_hyperlink_click](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_click/) és a [remove_hyperlink_mouse_over](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkmanager/remove_hyperlink_mouse_over/) metódusokat. Itt a tiltott külső kattintási linkeket egy fix HTTPS céloldallal helyettesítik; a többi tiltott kattintást és egér‑felvitel‑műveletet külön-külön eltávolítják. Állítsa `replace_external_clicks`‑t `False`‑ra, hogy minden szabálysértést eltávolítson. Válasszon egy alkalmazás‑tulajdonú helyettesítő oldalt a telepítés előtt.

A jelentés export‑flagje konzervatív PDF‑ellenőrzési szabályt használ: jelöli az egér‑felvitel műveleteket és mindazt, ami nem külső link vagy konkrét dia‑ugrás, mint potenciálisan nem támogatottat. Ez egy ellenőrzési jelzés, nem képességteszt vagy garancia arra, hogy a jelöletlen linkek megmaradnak az exportban. A támogatott [PDF](/slides/hu/python-net/convert-powerpoint-to-pdf/) és [HTML](/slides/hu/python-net/convert-powerpoint-to-html/) exportok megőrizhetik a hiperhivatkozásokat, a művelettől, az export‑beállításoktól és a nézőtől függően. A raszteres [images](/slides/hu/python-net/convert-powerpoint-to-png/) és [video](/slides/hu/python-net/convert-powerpoint-to-video/) nem őrizhetik meg az interaktív hiperhivatkozásokat; ezeknél a kimenetnél minden műveletet jelöljön.

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
    # Lekérdezi minden dia hatókörét egyszer, megtartva a tulajdonost minden konténerhez.
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

A fent létrehozott bemenet szerint a jelentés öt műveleti sort tartalmaz. A fájl‑egér‑felvitel link és a makró‑kattintás eltávolításra kerül, míg a HTTPS‑linkek és a belső dia‑navigáció megmarad. Az ellenőrzés nulla tiltott műveletet ír ki. Egy tiltott külső kattintási URL‑t tartalmazó bemenet a csereágat is teszteli. Egy engedélyezett kattintással és tiltott egér‑felvitelű tároló megtartja a kattintási műveletet.

Ez a szelektív takarítás eltér a [remove_all_hyperlinks](https://reference.aspose.com/slides/python-net/aspose.slides/hyperlinkqueries/remove_all_hyperlinks/) módszertől, amely a kiválasztott hatókörön belül minden aktiválási típust eltávolít a szabályzattól függetlenül. Itt a ellenőrzés csak a hiperhivatkozás‑műveleteket vizsgálja; nem távolítja el a beágyazott VBA‑projket, OLE‑objektumokat vagy egyéb aktív tartalmakat, és nem ellenőrzi a kiexportált PDF‑ vagy HTML‑fájlt.

## **GYIK**

**Hogyan linkelhetek egy szakaszra vagy annak első diára?**

A PowerPoint szakaszok csoportosítják a diákat, de egy belső hiperhivatkozás egy egyedi diát céloz meg. A szakaszra való navigáció létrehozásához linkeljen az adott szakasz első diájára.

**Csatolhatok hiperhivatkozást a mesterdia elemeihez, hogy minden dián működjön?**

Igen. A mesterdia és elrendezés elemei támogatják a hiperhivatkozásokat. Ezek a linkek a diavetítés során elérhetők azon diákon, amelyek a megfelelő mestert vagy elrendezést használják.

**Megmaradnak a hyperhivatkozások PDF, HTML, képek vagy videó exportálásakor?**

A támogatott PDF és HTML exportok megőrizhetik a hiperhivatkozásokat; a raszteres képek és a videó nem őrizhetik meg az interaktív linkeket. Lásd a [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) részt az exportálással kapcsolatos megfontolásokért.