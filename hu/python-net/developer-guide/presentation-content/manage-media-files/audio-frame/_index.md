---
title: "Hangkeretek kezelése prezentációkban Python használatával"
linktitle: "Hangkeret"
type: docs
weight: 10
url: /hu/python-net/audio-frame/
keywords:
- "hang"
- "hangkeret"
- "bélyegkép"
- "hang hozzáadása"
- "hang tulajdonságok"
- "hang beállítások"
- "hang kinyerése"
- "WebVTT"
- "Python"
- "Aspose.Slides"
description: "Ágyazz be hangot a diákba, változtasd meg a hang ikont, állítsd be a lejátszást, kezeld a WebVTT feliratokat, és nyerd ki a diaváltások hangjait az Aspose.Slides for Python via .NET segítségével."
---
## **Áttekintés**

Az audio keret lehetővé teszi, hogy egy hangot lejátsz egy dián. Az Aspose.Slides for Python via .NET segítségével beágyazhatsz egy audio klippet, kiválaszthatod a képét, amely azt ábrázolja, beállíthatod a lejátszást, és felvehetsz feliratokat. A diaváltáshoz rendelt hangot is lekérheted.

## **Audio keretek létrehozása**

Használd a [add_audio_frame_embedded](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) metódust a helyi audio klippet való beágyazáshoz az első dián. Az első két koordináta pozícionálja a keretet a dián, a következő két érték a szélességét és magasságát állítja be, mind pontban. Ez a példa a [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) értékét úgy állítja be, hogy a klipe automatikusan induljon, és a [volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) értékét a hangos előre beállított értékre.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(50, 150, 100, 100, audio_stream)
    audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
    audio_frame.volume = slides.AudioVolumeMode.LOUD

    presentation.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Az audio keret bélyegképének módosítása**

Alapértelmezés szerint egy audio keret egy hangszóró ikont jelenít meg. Egyedi bélyegkép megjelenítéséhez adj egy képet a prezentációhoz a [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/) metódussal, és rendeld hozzá a keret [picture_format.picture.image](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image/) tulajdonságához. A példa egy JPEG-et használ bélyegképként a beágyazott audio klippel.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("eagle.jpeg", "rb") as image_stream:
        thumbnail = presentation.images.add_image(image_stream)

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_stream)
    audio_frame.picture_format.picture.image = thumbnail

    presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Az audio lejátszási beállítások módosítása**

A PowerPoint **Audio Options** vezérlői határozzák meg, hogy mikor indul a klip, milyen hangos, és hogyan viselkedik a diavetítés során.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| PowerPoint vezérlő | Aspose.Slides tulajdonság |
| --- | --- |
| Indítás | [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) |
| Hangerej előre beállított | [volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) |
| Lejátszás diákon át | [play_across_slides](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_across_slides/) |
| Ismétlés leállításig | [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_loop_mode/) |
| Elrejtés a bemutató során | [hide_at_showing](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/hide_at_showing/) |
| Visszatekerés lejátszás után | [rewind_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/rewind_audio/) |
| Fade In | [fade_in_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_in_duration/) |
| Fade Out | [fade_out_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_out_duration/) |
| Trim Audio kezdési idő | [trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) |
| Trim Audio befejezési idő | [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) |
| Hangerej csúszka | [volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/) |

A példa megtalálja az első audio keretet az első dián, a [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) értékét úgy állítja be, hogy kattintásra induljon a lejátszás, és az alacsony hangerő előre beállított értéket választja. A klip diákon át folytatódik a ciklus letiltásával. Az ikon rejtve marad a bemutató során, és a klip lejátszás után visszatekeredik.

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.play_mode = slides.AudioPlayModePreset.ON_CLICK
        audio_frame.volume = slides.AudioVolumeMode.LOW
        audio_frame.play_across_slides = True
        audio_frame.play_loop_mode = False
        audio_frame.hide_at_showing = True
        audio_frame.rewind_audio = True
        
        presentation.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

3,5 másodpercnél hosszabb klipek esetén ez a példa kihagyja az első 1,5 másodpercet és az utolsó 2 másodpercet. A [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) méri a klipek végétől elhagyandó időtartamot. A PowerPointban látható befejezési idő kiszámításához vonjuk le ezt az eltolást a teljes kliphosszból. A vágott klip 200 ms alatt fade‑in, és 500 ms alatt fade‑out. Mind a négy tulajdonság értéke milliszekundumban van megadva.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio_stream)
    audio_frame.trim_from_start = 1500.0
    audio_frame.trim_from_end = 2000.0
    audio_frame.fade_in_duration = 200.0
    audio_frame.fade_out_duration = 500.0

    presentation.save("AudioFrameTrimFade_out.pptx", slides.export.SaveFormat.PPTX)
```

A lejátszási hangerő meghatározott százalékra állításához használd a [volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/) metódust. A példa az első dián az első audio keret hangerő értékét 85%-ra állítja.

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.volume_value = 85.0
        presentation.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Audio feliratok kezelése**

Minden audio keretnek van egy [caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/caption_tracks/) gyűjteménye. Ezzel a WebVTT feliratok csatolhatók a kliphöz, exportálhatók a meglévő sávok, vagy eltávolíthatók.

### **Audio feliratok hozzáadása**

A példa egy audio kli peat ágyazza be az első diára, és a [CaptionsCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/add/) használatával csatol egy helyi WebVTT sávot. Az első argumentum a sáv címkéjét adja meg, a második a feliratokat tartalmazó fájlt azonosítja.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 50, 50, audio_stream)
    audio_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("audio_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

### **Audio feliratok kinyerése**

Ez a példa exportálja az első dián egy audio kerethez csatolt minden felirat sávot. A sáv [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/captions/binary_data/) adatait egy WebVTT fájlba írja, és a [caption_id](https://reference.aspose.com/slides/python-net/aspose.slides/captions/caption_id/) értékét fájlnévként használja, hogy minden sáv külön kimenettel rendelkezzen.

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            for track in shape.caption_tracks:
                with open(f"{track.caption_id}.vtt", "wb") as output:
                    output.write(track.binary_data)
```

### **Audio feliratok eltávolítása**

Használd a [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) vagy [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) metódusokat egy egyedi sáv törléséhez. A példa a [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/) használatával eltávolítja az első dián az első audio keret összes feliratát, miközben megőrzi a klipet.

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    audio_frame = next((shape for shape in slide.shapes if isinstance(shape, slides.AudioFrame)), None)
    if audio_frame is None:
        print("The first slide has no audio frame.")
    else:
        audio_frame.caption_tracks.clear()
        presentation.save("audio_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

### **Sor keresése audio feliratokban**

Az első dián lévő audio feliratokban sor kereséséhez olvasd be memóriaba minden sáv [data_as_string](https://reference.aspose.com/slides/python-net/aspose.slides/captions/data_as_string/) értékét. Egy egyszerű szöveges WebVTT cue‑ban az időzítési sor `-->`‑t tartalmaz, azt követik a feliratsorok, és egy üres sor zárja a cue‑t. Ez a példa kiírja a sáv címkéjét és minden olyan feliratsort, amely „café” szót tartalmaz.

```python
import aspose.slides as slides

with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            for track in shape.caption_tracks:
                in_cue = False
                for line in track.data_as_string.splitlines():
                    if not line:
                        in_cue = False
                    elif "-->" in line:
                        in_cue = True
                    elif in_cue and "café" in line.casefold():
                        print(f"{track.label}: {line}")
```

## **Audio kinyerése**

Egy diaváltás saját hanggal is rendelkezhet. Ennek lekéréséhez olvasd a váltás [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/) tulajdonságát. A példa hozzáfér a hang [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/audio/binary_data/) adatához és kiírja a méretét bájtokban. Ha az első dián nincs váltási hang, akkor egy üzenetet ír ki.

```python
import aspose.slides as slides

with slides.Presentation("AudioSlide.pptx") as presentation:
    slide = presentation.slides[0]

    sound = slide.slide_show_transition.sound
    if sound is None:
        print("The first slide has no transition sound.")
    else:
        audio_data = sound.binary_data
        print(f"Transition sound: {len(audio_data)} bytes.")
```

## **GYIK**

**Újra felhasználhatom ugyanazt az audio klippet több dián anélkül, hogy duplikálnám?**

Igen. Add a klipet egyszer a prezentáció [audio collection](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/audios/) gyűjteményéhez, és minden dián a ugyanazt az audio objektumot adja át a [add_audio_frame_embedded](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) metódusnak.

**Lecserélhetem egy meglévő audio keret hangját?**

Igen. Hivatkozott hang esetén frissítsd a [link_path_long](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/link_path_long/) értékét, hogy az új fájlra mutasson. Beágyazott hang esetén rendelj egy másik klippet a prezentáció audio gyűjteményéből az [embedded_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/) tulajdonsághoz. Mindkét megközelítés megőrzi a meglévő keretet.

**A vágás megváltoztatja a prezentációban tárolt audio adatot?**

Nem. A [trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) és [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) csak a lejátszási határokat állítja be. A teljes klipet továbbra is lekérheted az [embedded_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/) segítségével.