---
title: Správa audio rámečků v prezentacích pomocí Pythonu
linktitle: Audio rámeček
type: docs
weight: 10
url: /cs/python-net/audio-frame/
keywords:
- zvuk
- audio rámeček
- miniatura
- přidat audio
- vlastnosti audia
- nastavení audia
- extrahovat audio
- WebVTT
- Python
- Aspose.Slides
description: "Vkládejte zvuk do snímků, měňte ikonu audia, konfigurujte přehrávání, spravujte WebVTT titulky a extrahujte zvuky přechodů snímků s Aspose.Slides pro Python via .NET."
---
## **Přehled**

Audio rámeček vám umožní přehrát zvuk na snímku. S Aspose.Slides pro Python via .NET můžete vložit audio klip, zvolit obrázek, který jej představuje, nastavit přehrávání a připojit titulky. Také můžete získat zvuk přiřazený k přechodu snímku.

## **Vytvoření audio rámečků**

Použijte [add_audio_frame_embedded](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) pro vložení lokálního audio klipu na první snímek. První dvě souřadnice určují polohu rámečku na snímku a následující dva hodnoty nastavují jeho šířku a výšku, vše v bodech. Tento příklad nastavuje [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) tak, aby klip začal automaticky, a [volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) na přednastavenou hlasitost.

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

## **Změna miniatury audio rámečku**

Ve výchozím nastavení audio rámeček zobrazuje ikonu reproduktoru. Pro zobrazení vlastní miniatury přidejte obrázek do prezentace pomocí [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/) a přiřaďte jej k vlastnosti [picture_format.picture.image](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image/) rámečku. Příklad používá JPEG jako miniaturu pro vložený audio klip.

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

## **Změna možností přehrávání audia**

Ovládací prvky **Audio Options** v PowerPointu určují, kdy klip začne, jak hlasitý je a jak se chová během prezentace.

![PowerPoint Audio Options controls for an audio frame](audio_frame_0.png)

| Ovládací prvek PowerPointu | Vlastnost Aspose.Slides |
| --- | --- |
| Start | [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) |
| Volume preset | [volume](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume/) |
| Play Across Slides | [play_across_slides](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_across_slides/) |
| Loop until Stopped | [play_loop_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_loop_mode/) |
| Hide During Show | [hide_at_showing](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/hide_at_showing/) |
| Rewind after Playing | [rewind_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/rewind_audio/) |
| Fade In | [fade_in_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_in_duration/) |
| Fade Out | [fade_out_duration](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/fade_out_duration/) |
| Trim Audio start time | [trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) |
| Trim Audio end time | [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) |
| Volume slider | [volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/) |

Příklad najde první audio rámeček na prvním snímku, nastaví [play_mode](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/play_mode/) na spuštění přehrávání po kliknutí a zvolí nízkou předvolbu hlasitosti. Klip pokračuje přes snímky s vypnutým opakováním. Ikona zůstane skryta během prezentace a klip se po přehrání přetočí zpět.

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

U klipu delšího než 3,5 s tento příklad přeskočí první 1,5 s a poslední 2 s. [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) udává dobu, kterou je třeba oříznout na konci klipu. Pro získání koncového času zobrazeného v PowerPointu odečtěte tento posun od celkové délky klipu. Oříznutý klip se během 200 ms plynule nahrává a během 500 ms plynule zhasíná. Všechny čtyři vlastnosti přijímají hodnoty v milisekundách.

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

Pro nastavení hlasitosti přehrávání na konkrétní procento použijte [volume_value](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/volume_value/). Tento příklad nastaví první audio rámeček na prvním snímku na 85 %.

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

## **Správa titulků audia**

Každý audio rámeček má kolekci [caption_tracks](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/caption_tracks/). Pomocí ní můžete ke klipu připojit WebVTT titulky, exportovat existující stopy nebo je odstranit.

### **Přidání titulků audia**

Příklad vloží audio klip na první snímek a pomocí [CaptionsCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/add/) připojí lokální WebVTT stopu. První argument udává název stopy a druhý identifikuje soubor obsahující časované titulky.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("audio.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 50, 50, audio_stream)
    audio_frame.caption_tracks.add("English", "track.vtt")

    presentation.save("audio_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

### **Export titulků audia**

Tento příklad exportuje každou stopu titulků připojenou k audio rámečku na prvním snímku. Zapíše [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/captions/binary_data/) stopy do souboru WebVTT a použije její [caption_id](https://reference.aspose.com/slides/python-net/aspose.slides/captions/caption_id/) jako název souboru, aby každá stopa měla samostatný výstup.

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

### **Odstranění titulků audia**

Použijte [remove](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove/) nebo [remove_at](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/remove_at/) pro smazání jednotlivé stopy. Příklad použije [clear](https://reference.aspose.com/slides/python-net/aspose.slides/captionscollection/clear/) k odstranění všech titulků z prvního audio rámečku na prvním snímku při zachování klipu.

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

### **Vyhledání řádku v titulcích audia**

Pro vyhledání řádku v titulcích audia na prvním snímku načtěte [data_as_string](https://reference.aspose.com/slides/python-net/aspose.slides/captions/data_as_string/) každé stopy do paměti. V prostém textovém WebVTT cue obsahuje časová řádka `-->`, následují řádky titulků a prázdná řádka ukončuje cue. Tento příklad vytiskne název stopy a každou řádku titulků obsahující „café“.

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

## **Export audia**

Přechod snímku může mít svůj vlastní zvuk. Pro jeho získání načtěte vlastnost [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/) přechodu. Příklad přistupuje k [binary_data](https://reference.aspose.com/slides/python-net/aspose.slides/audio/binary_data/) zvuku a vytiskne jeho velikost v bajtech. Pokud první snímek nemá zvuk přechodu, vypíše místo toho zprávu.

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

## **Často kladené otázky**

**Mohu znovu použít stejný audio klip na více snímcích bez jeho duplikace?**

Ano. Přidejte klip jednou do [audio collection](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/audios/) prezentace a stejný audio objekt předávejte do [add_audio_frame_embedded](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) pro každý snímek.

**Mohu nahradit zvuk v existujícím audio rámečku?**

Ano. U propojeného zvuku aktualizujte [link_path_long](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/link_path_long/) tak, aby ukazoval na náhradní soubor. U vloženého zvuku přiřaďte jiný klip z audio kolekce prezentace k [embedded_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/). Oba způsoby zachovají existující rámeček.

**Mění ořezávání uložená audio data v prezentaci?**

Ne. [trim_from_start](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_start/) a [trim_from_end](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/trim_from_end/) nastavují hranice přehrávání. Stále můžete získat celý klip z [embedded_audio](https://reference.aspose.com/slides/python-net/aspose.slides/audioframe/embedded_audio/).