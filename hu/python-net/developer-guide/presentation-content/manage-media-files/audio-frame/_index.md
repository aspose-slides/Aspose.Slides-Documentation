---
title: Hang kezelése prezentációkban Python használatával
linktitle: Hangkeret
type: docs
weight: 10
url: /hu/python-net/audio-frame/
keywords:
- hang hozzáadása
- hang beágyazása
- hangkeret
- hangfájl
- hangtulajdonságok
- hang kinyerése
- hang lekérése
- hang módosítása
- lejátszási beállítások
- lejátszási mód
- lejátszás diákon át
- hurok amíg le nem áll
- rejtés előadás közben
- visszatekerés lejátszás után
- hang hangerő
- alapértelmezett kép
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Könnyedén adjon hozzá, nyerjen ki és kezeljen hangkereteket PPT, PPTX és ODP formátumokban az Aspose.Slides for Python via .NET segítségével. Tekintse meg a kódpéldákat és javítsa prezentációit még ma."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhatunk hangkeretekkel az Aspose.Slides‑ben. Megmutatja, hogyan adhatunk beágyazott hangot a diákhoz, hogyan testreszabhatjuk a hangkeret bélyegképét, hogyan állíthatjuk be a lejátszási lehetőségeket, például a hangerőt, a hurok módot, a rejtést, a vágást és a halványodási időket, valamint hogyan nyerhetjük ki a diavetítés-átmenetekben használt hangot.

## **Hangkeretek létrehozása**

Az Aspose.Slides for Python via .NET lehetővé teszi, hogy hangfájlokat adjunk a diákhoz. A hangfájlok beágyazott hangkeretekként kerülnek a diákba.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
2. Szerezze meg a dia referencia‑ját az indexe alapján.
3. Töltse be azt a hangfájlt, amelyet be szeretne ágyazni a diára.
4. Adja hozzá a beágyazott hangkeretet (amely a hangfájlt tartalmazza) a diához.
5. Állítsa be a [PlayMode](https://reference.aspose.com/slides/hu/python-net/aspose.slides/audioplaymodepreset) és a `Volume` értékeket az [IAudioFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/audioframe/) objektumon keresztül.
6. Mentse el a módosított prezentációt.

Ez a Python‑kód megmutatja, hogyan adjon egy beágyazott hangkeretet a diához:

```python
import aspose.slides as slides

# InstantiateS egy prezentáció osztályt, amely egy prezentációfájlt képvisel
with slides.Presentation() as pres:
    # Lekéri az első diát
    sld = pres.slides[0]

    # Betölti a wav hangfájlt adatfolyamra
    with open(path + "sampleaudio.wav", "rb") as in_file:
        # Hozzáadja a hangkeretet
        audio_frame = sld.shapes.add_audio_frame_embedded(50, 150, 100, 100, in_file)

        # Beállítja a hang lejátszási módját és hangerőjét
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
        audio_frame.volume = slides.AudioVolumeMode.LOUD

        # Kiírja a PowerPoint fájlt lemezre
        pres.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Hangkeret bélyegkép módosítása**

Amikor hangfájlt adunk a prezentációhoz, az hangként egy alapértelmezett képpel rendelkező keretként jelenik meg (lásd az alábbi képet). Megváltoztathatja a hangkeret bélyegképét (állítsa be a kívánt képet).

Ez a Python‑kód megmutatja, hogyan módosítsa a hangkeret bélyegképét vagy előnézeti képét:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Hozzáad egy hangkeretet a diához a megadott helyzet és méret szerint.
    with open("sample2.mp3", "rb") as audio_fs:
        audioFrame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_fs)

        # Hozzáad egy képet a prezentáció erőforrásaihoz.
        with open("eagle.jpeg", "rb") as image_fs:
            data = image_fs.read()
        
        audioImage = presentation.images.add_image(data)

        # Beállítja a képet a hangkerethez.
        audioFrame.picture_format.picture.image = audioImage
        
        #Mentse a módosított prezentációt lemezre
        presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Hang lejátszási beállítások módosítása**

Az Aspose.Slides for Python via .NET lehetővé teszi a hang lejátszását vagy tulajdonságait befolyásoló beállítások módosítását. Például állíthatja a hangerőt, beállíthatja, hogy a hang hurkolva játsszon, vagy akár elrejtheti a hangikonot.

A **Audio Options** panel a Microsoft PowerPoint‑ban:

![example1_image](audio_frame_0.png)

A PowerPoint **Audio Options** beállítások, amelyek az Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/audioframe/) tulajdonságoknak felelnek meg:

- **Start** legördülő lista egyezik az [AudioFrame.play_mode](https://reference.aspose.com/slides/hu/python-net/aspose.slides/audioframe/play_mode/) tulajdonsággal
- **Volume** egyezik az [AudioFrame.volume](https://reference.aspose.com/slides/hu/python-net/aspose.slides/audioframe/volume/) tulajdonsággal
- **Play Across Slides** egyezik az [AudioFrame.play_across_slides](https://reference.aspose.com/slides/hu/python-net/aspose.slides/audioframe/play_across_slides/) tulajdonsággal
- **Loop until Stopped** egyezik az [AudioFrame.play_loop_mode](https://reference.aspose.com/slides/hu/python-net/aspose.slides/audioframe/play_loop_mode/) tulajdonsággal
- **Hide During Show** egyezik az [AudioFrame.hide_at_showing](https://reference.aspose.com/slides/hu/python-net/aspose.slides/audioframe/hide_at_showing/) tulajdonsággal
- **Rewind after Playing** egyezik az [AudioFrame.rewind_audio](https://reference.aspose.com/slides/hu/python-net/aspose.slides/audioframe/rewind_audio/) tulajdonsággal

A PowerPoint **Editing** beállítások, amelyek az Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/audioframe/) tulajdonságoknak felelnek meg:

- **Fade In** egyezik az [AudioFrame.fade_in_duration](https://reference.aspose.com/slides/hu/python-net/aspose.slides/audioframe/fade_in_duration/) tulajdonsággal
- **Fade Out** egyezik az [AudioFrame.fade_out_duration](https://reference.aspose.com/slides/hu/python-net/aspose.slides/audioframe/fade_out_duration/) tulajdonsággal
- **Trim Audio Start Time** egyezik az [AudioFrame.trim_from_start](https://reference.aspose.com/slides/hu/python-net/aspose.slides/audioframe/trim_from_start/) tulajdonsággal
- **Trim Audio End Time** értéke a hang időtartamából a [AudioFrame.trim_from_end](https://reference.aspose.com/slides/hu/python-net/aspose.slides/audioframe/trim_from_end/) értéke levonva

A PowerPoint **Volume controll** a hangvezérlő panelen megfelel az [AudioFrame.volume_value](https://reference.aspose.com/slides/hu/python-net/aspose.slides/audioframe/volume_value/) tulajdonságnak. Lehetővé teszi a hangerő százalékos változtatását.

Így módosíthatja a hang lejátszási beállításait:

1. [Сreate](#create-audio-frame) vagy szerezze meg a Hangkeretet.
2. Állítson be új értékeket a módosítani kívánt Hangkeret‑tulajdonságokhoz.
3. Mentse el a módosított PowerPoint‑fájlt.

Ez a Python‑kód bemutat egy műveletet, amelyben a hang beállításait módosítják:

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # Lekéri az AudioFrame alakzatot
    audioFrame = pres.slides[0].shapes[0]

    # Beállítja a lejátszási módot kattintásra
    audioFrame.play_mode = slides.AudioPlayModePreset.ON_CLICK

    # Beállítja a hangerőt alacsonyra
    audioFrame.volume = slides.AudioVolumeMode.LOW

    # Beállítja, hogy a hang a diákon át játszódjon
    audioFrame.play_across_slides = True

    # Kikapcsolja a hurkot a hangnál
    audioFrame.play_loop_mode = False

    # Elrejti az AudioFrame-et a diavetítés során
    audioFrame.hide_at_showing = True

    # Visszatekeri a hangot az elejére lejátszás után
    audioFrame.rewind_audio = True

    # Elmenti a PowerPoint fájlt lemezre
    pres.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

Ez a Python‑példa megmutatja, hogyan adjon hozzá új hangkeretet beágyazott hanggal, vágja le, és állítsa be a halványodási időket:

```py
with slides.Presentation() as pres:
    slide = pres.slides[0]

    with open("sampleaudio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()

    audio = pres.audios.add_audio(audio_data)
    audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio)

    # Beállítja a vágás kezdő eltolását 1.5 másodpercre
    audio_frame.trim_from_start = 1500.0
    # Beállítja a vágás befejező eltolását 2 másodpercre
    audio_frame.trim_from_end = 2000.0

    # Beállítja a fade-in időtartamot 200 ms-re
    audio_frame.fade_in_duration = 200.0
    # Beállítja a fade-out időtartamot 500 ms-re
    audio_frame.fade_out_duration = 500.0

    pres.save("AudioFrameTrimFade_out.pptx", slides.export.SaveFormat.PPTX)
```

Az alábbi kódrészlet megmutatja, hogyan kérje le a beágyazott hangot tartalmazó hangkeretet, és állítsa be a hangerőt 85 %-ra:

```py
with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # Lekéri egy hangkeret alakzatot
    audio_frame = pres.slides[0].shapes[0]

    # Beállítja a hanghangerőt 85%-ra
    audio_frame.volume_value = 85.0

    pres.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Hangfeliratok kezelése**

Az Aspose.Slides lehetővé teszi, hogy zárt feliratokat adjunk egy hangkerethez a [caption_tracks](https://reference.aspose.com/slides/hu/python-net/aspose.slides/audioframe/caption_tracks/) tulajdonságon keresztül. Ez a tulajdonság egy [CaptionsCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/captionscollection/) objektumot ad vissza, amely lehetővé teszi WebVTT feliratcímkék hozzáadását, a meglévő címkék bejárását és szükség esetén azok eltávolítását.

**Hangfeliratok hozzáadása**

Használja a [caption_tracks](https://reference.aspose.com/slides/hu/python-net/aspose.slides/audioframe/caption_tracks/) tulajdonságot, hogy egy vagy több feliratcímkét csatoljon egy hangkerethez. Az alábbi példában egy hangfájlt adunk egy diához, majd egy új feliratcímkét töltünk be egy `.vtt` fájlból.

```py
with slides.Presentation() as presentation:
    with open("audio.mp3", "rb") as audio_stream:
        audio = presentation.audios.add_audio(audio_stream.read())

    slide = presentation.slides[0]
    audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 50, 50, audio)

    # Új feliratcímkét ad hozzá egy WebVTT fájlból.
    presentation.save("audio_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

**Hangfeliratok kinyerése**

Bejárhatja a hangkerethez társított feliratcímkéket, és mentheti őket `.vtt` fájlokként. Minden feliratcímke hozzáférést biztosít a bináris adataihoz és egyedi azonosítójához, amely felhasználható a feliratok exportálásához.

```py
with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            audio_frame = shape
            for caption_track in audio_frame.caption_tracks:
                # Mentse a feliratcímkét .vtt fájlként.
                with open(f"{caption_track.caption_id}.vtt", "wb") as track_stream:
                    track_stream.write(caption_track.binary_data)
```

**Hangfeliratok eltávolítása**

A feliratok egy hangkeretről való eltávolításához használja a [CaptionsCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/captionscollection/) által biztosított metódusokat, mint a [clear](https://reference.aspose.com/slides/hu/python-net/aspose.slides/captionscollection/clear/), [remove](https://reference.aspose.com/slides/hu/python-net/aspose.slides/captionscollection/remove/) vagy [remove_at](https://reference.aspose.com/slides/hu/python-net/aspose.slides/captionscollection/remove_at/). Az alábbi példa eltávolítja az összes feliratcímkét egy hangkeretből.

```py
with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    audio_frame = slide.shapes[0]  # típus: slides.AudioFrame

    # Távolítsa el az összes feliratcímkét a hangkeretből.
    audio_frame.caption_tracks.clear()

    presentation.save("audio_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

## **Hang kinyerése**
Az Aspose.Slides for Python via .NET lehetővé teszi a diavetítés-átmenetekben használt hang kinyerését. Például egy adott dián használt hangot is ki tud nyerni.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) példányt, és töltse be a hangot tartalmazó prezentációt.
2. Szerezze meg a megfelelő dia referencia‑ját az indexe alapján.
3. Hozzáférés a dia diavetítés‑átmeneteihez.
4. Kinyeri a hangot bájt‑adatként.

Ez a Python‑kód megmutatja, hogyan nyerheti ki a diában használt hangot:

```python
import aspose.slides as slides

#with slides.Presentation("AudioSlide.pptx") as pres:
with slides.Presentation("AudioFrameEmbed_changed.pptx") as pres:
    # Hozzáfér a kívánt diához
    slide = pres.slides[0]  

    # Lekéri a diavetítési átmenet hatásait a diára
    transition = slide.slide_show_transition

    #Kinyeri a hangot bájt tömbben
    audio = transition.sound.binary_data

    print("Length: " + str(len(audio)))
```

## **GYIK**

**Újra felhasználhatom ugyanazt a hangfájlt több dián anélkül, hogy megnövelném a fájlméretet?**

Igen. Adja hozzá a hangot egyszer a prezentáció közös [audio collection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/audios/)‑hez, és hozzon létre további hangkereteket, amelyek erre a meglévő eszközre hivatkoznak. Ez megakadályozza a médiaadatok duplikálását és a prezentáció méretét kordában tartja.

**Kicserélhetem a hangot egy meglévő hangkeretben anélkül, hogy újra létrehoznám az alakzatot?**

Igen. Egy hivatkozott hang esetén frissítse a [link path](https://reference.aspose.com/slides/hu/python-net/aspose.slides/audioframe/link_path_long/)‑t, hogy az új fájlra mutasson. Egy beágyazott hang esetén cserélje ki a [embedded audio](https://reference.aspose.com/slides/hu/python-net/aspose.slides/audioframe/embedded_audio/) objektumot egy másikra a prezentáció [audio collection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/audios/)‑ből. A keret formázása és a legtöbb lejátszási beállítás változatlan marad.

**A vágás megváltoztatja-e a prezentációban tárolt alapuló hangadatot?**

Nem. A vágás csak a lejátszási határokat módosítja. Az eredeti hangbájtok érintetlenek maradnak, és a beágyazott hang vagy a prezentáció hanggyűjteménye révén továbbra is elérhetők.