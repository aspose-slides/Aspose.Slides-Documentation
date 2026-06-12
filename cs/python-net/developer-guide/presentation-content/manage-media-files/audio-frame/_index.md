---
title: Správa zvuku v prezentacích pomocí Pythonu
linktitle: Audio rámec
type: docs
weight: 10
url: /cs/python-net/audio-frame/
keywords:
- přidat zvuk
- vložit zvuk
- audio rámec
- zvukový soubor
- vlastnosti zvuku
- extrahovat zvuk
- získat zvuk
- změnit zvuk
- možnosti přehrávání
- režim přehrávání
- přehrávání napříč snímky
- opakovat do zastavení
- skrýt během prezentace
- přetočit po přehrání
- hlasitost zvuku
- výchozí obrázek
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Jednoduše přidávejte, extrahujte a spravujte audio rámy v PPT, PPTX a ODP pomocí Aspose.Slides pro Python via .NET. Prozkoumejte ukázky kódu a vylepšete své prezentace ještě dnes."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s audio rámci v Aspose.Slides. Ukazuje, jak přidat vložený zvuk do snímků, přizpůsobit miniaturu audio rámce, nakonfigurovat možnosti přehrávání, jako je hlasitost, smyčkování, skrytí, ořezávání a dobu trvání přechodů, a extrahovat zvuk použitý v přechodech prezentace.

## **Vytvoření audio rámců**

Aspose.Slides pro Python via .NET umožňuje přidávat zvukové soubory do snímků. Zvukové soubory jsou do snímků vloženy jako audio rámce. 

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Získejte referenci na snímek pomocí jeho indexu.
3. Nahrajte proud zvukového souboru, který chcete vložit do snímku.
4. Přidejte vložený audio rámec (obsahující zvukový soubor) do snímku.
5. Nastavte [PlayMode](https://reference.aspose.com/slides/cs/python-net/aspose.slides/audioplaymodepreset) a `Volume` vystavené objektem [IAudioFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/audioframe/).
6. Uložte upravenou prezentaci.

Tento Python kód ukazuje, jak přidat vložený audio rámec do snímku:

```python
import aspose.slides as slides

# Vytvoří instanci třídy prezentace, která představuje soubor prezentace
with slides.Presentation() as pres:
    # Získá první snímek
    sld = pres.slides[0]

    # Načte wav zvukový soubor do proudu
    with open(path + "sampleaudio.wav", "rb") as in_file:
        # Přidá audio rámec
        audio_frame = sld.shapes.add_audio_frame_embedded(50, 150, 100, 100, in_file)

        # Nastaví režim přehrávání a hlasitost zvuku
        audio_frame.play_mode = slides.AudioPlayModePreset.AUTO
        audio_frame.volume = slides.AudioVolumeMode.LOUD

        # Zapíše soubor PowerPoint na disk
        pres.save("AudioFrameEmbed_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Změna miniatury audio rámce**

Když přidáte zvukový soubor do prezentace, zvuk se zobrazí jako rámec se standardním výchozím obrázkem (viz obrázek v následující sekci). Miniaturu audio rámce můžete změnit (nastavit vámi preferovaný obrázek).

Tento Python kód ukazuje, jak změnit miniaturu nebo náhledový obrázek audio rámce:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    # Přidá audio rámec na snímek s určenou pozicí a velikostí.
    with open("sample2.mp3", "rb") as audio_fs:
        audioFrame = slide.shapes.add_audio_frame_embedded(150, 100, 50, 50, audio_fs)

        # Přidá obrázek do zdrojů prezentace.
        with open("eagle.jpeg", "rb") as image_fs:
            data = image_fs.read()
        
        audioImage = presentation.images.add_image(data)

        # Nastaví obrázek pro audio rámec.
        audioFrame.picture_format.picture.image = audioImage
        
        #Uloží upravenou prezentaci na disk
        presentation.save("example_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Změna možností přehrávání zvuku**

Aspose.Slides pro Python via .NET umožňuje měnit možnosti, které řídí přehrávání zvuku nebo jeho vlastnosti. Například můžete upravit hlasitost zvuku, nastavit přehrávání ve smyčce nebo dokonce skrýt ikonu zvuku.

The **Audio Options** pane in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options**, které odpovídají vlastnostem Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/audioframe/):

- **Start** rozbalovací seznam odpovídá vlastnosti [AudioFrame.play_mode](https://reference.aspose.com/slides/cs/python-net/aspose.slides/audioframe/play_mode/)
- **Volume** odpovídá vlastnosti [AudioFrame.volume](https://reference.aspose.com/slides/cs/python-net/aspose.slides/audioframe/volume/)
- **Play Across Slides** odpovídá vlastnosti [AudioFrame.play_across_slides](https://reference.aspose.com/slides/cs/python-net/aspose.slides/audioframe/play_across_slides/)
- **Loop until Stopped** odpovídá vlastnosti [AudioFrame.play_loop_mode](https://reference.aspose.com/slides/cs/python-net/aspose.slides/audioframe/play_loop_mode/)
- **Hide During Show** odpovídá vlastnosti [AudioFrame.hide_at_showing](https://reference.aspose.com/slides/cs/python-net/aspose.slides/audioframe/hide_at_showing/)
- **Rewind after Playing** odpovídá vlastnosti [AudioFrame.rewind_audio](https://reference.aspose.com/slides/cs/python-net/aspose.slides/audioframe/rewind_audio/)

PowerPoint **Editing** možnosti, které odpovídají vlastnostem Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/audioframe/):

- **Fade In** odpovídá vlastnosti [AudioFrame.fade_in_duration](https://reference.aspose.com/slides/cs/python-net/aspose.slides/audioframe/fade_in_duration/)
- **Fade Out** odpovídá vlastnosti [AudioFrame.fade_out_duration](https://reference.aspose.com/slides/cs/python-net/aspose.slides/audioframe/fade_out_duration/)
- **Trim Audio Start Time** odpovídá vlastnosti [AudioFrame.trim_from_start](https://reference.aspose.com/slides/cs/python-net/aspose.slides/audioframe/trim_from_start/)
- **Trim Audio End Time** hodnota se rovná délce zvuku minus hodnota vlastnosti [AudioFrame.trim_from_end](https://reference.aspose.com/slides/cs/python-net/aspose.slides/audioframe/trim_from_end/)

Ovládací prvek **Volume** na panelu zvukových ovládacích prvků odpovídá vlastnosti [AudioFrame.volume_value](https://reference.aspose.com/slides/cs/python-net/aspose.slides/audioframe/volume_value/). Umožňuje změnit hlasitost zvuku v procentech.

Toto je způsob, jak změnit možnosti přehrávání zvuku:

1. [Vytvořte](#create-audio-frame) nebo získejte audio rámec.
2. Nastavte nové hodnoty pro vlastnosti audio rámce, které chcete upravit.
3. Uložte upravený soubor PowerPoint.

Tento Python kód demonstruje operaci, při které jsou upraveny možnosti zvuku:

```python
import aspose.slides as slides

with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # Získá tvar AudioFrame
    audioFrame = pres.slides[0].shapes[0]

    # Nastaví režim přehrávání na přehrání po kliknutí
    audioFrame.play_mode = slides.AudioPlayModePreset.ON_CLICK

    # Nastaví hlasitost na nízkou
    audioFrame.volume = slides.AudioVolumeMode.LOW

    # Nastaví přehrávání zvuku napříč snímky
    audioFrame.play_across_slides = True

    # Zakáže smyčku pro zvuk
    audioFrame.play_loop_mode = False

    # Skryje AudioFrame během prezentace
    audioFrame.hide_at_showing = True

    # Přetočí zvuk na začátek po přehrání
    audioFrame.rewind_audio = True

    # Uloží soubor PowerPoint na disk
    pres.save("AudioFrameEmbed_changed.pptx", slides.export.SaveFormat.PPTX)
```

Tento Python příklad ukazuje, jak přidat nový audio rámec s vloženým zvukem, oříznout ho a nastavit dobu trvání přechodů:

```py
with slides.Presentation() as pres:
    slide = pres.slides[0]

    with open("sampleaudio.mp3", "rb") as audio_stream:
        audio_data = audio_stream.read()

    audio = pres.audios.add_audio(audio_data)
    audio_frame = slide.shapes.add_audio_frame_embedded(50, 50, 100, 100, audio)

    # Nastaví počáteční odsazení ořezu na 1,5 sekundy
    audio_frame.trim_from_start = 1500.0
    # Nastaví koncové odsazení ořezu na 2 sekundy
    audio_frame.trim_from_end = 2000.0

    # Nastaví dobu trvání fade-in na 200 ms
    audio_frame.fade_in_duration = 200.0
    # Nastaví dobu trvání fade-out na 500 ms
    audio_frame.fade_out_duration = 500.0

    pres.save("AudioFrameTrimFade_out.pptx", slides.export.SaveFormat.PPTX)
```

Následující ukázka kódu ukazuje, jak získat audio rámec s vloženým zvukem a nastavit jeho hlasitost na 85 %:

```py
with slides.Presentation("AudioFrameEmbed_out.pptx") as pres:
    # Získá tvar audio rámce
    audio_frame = pres.slides[0].shapes[0]

    # Nastaví hlasitost zvuku na 85%
    audio_frame.volume_value = 85.0

    pres.save("AudioFrameValue_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Správa popisků zvuku**

Aspose.Slides umožňuje přidávat uzavřené titulky k audio rámci pomocí vlastnosti [caption_tracks](https://reference.aspose.com/slides/cs/python-net/aspose.slides/audioframe/caption_tracks/). Tato vlastnost vrací [CaptionsCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/captionscollection/), která vám umožní přidávat WebVTT titulky, procházet existující stopy a v případě potřeby je odstranit.

**Přidat titulky zvuku**

Použijte vlastnost [caption_tracks](https://reference.aspose.com/slides/cs/python-net/aspose.slides/audioframe/caption_tracks/) k připojení jedné nebo více titulkových stop k audio rámci. V následujícím příkladu je zvukový soubor přidán do snímku a poté je nová titulková stopa načtena ze souboru `.vtt`.

```py
with slides.Presentation() as presentation:
    with open("audio.mp3", "rb") as audio_stream:
        audio = presentation.audios.add_audio(audio_stream.read())

    slide = presentation.slides[0]
    audio_frame = slide.shapes.add_audio_frame_embedded(10, 10, 50, 50, audio)

    # Přidá novou titulkovou stopu ze souboru WebVTT.
    audio_frame.caption_tracks.add("New track", "track.vtt")

    presentation.save("audio_with_captions.pptx", slides.export.SaveFormat.PPTX)
```

**Extrahovat titulky zvuku**

Můžete procházet titulky přiřazené k audio rámci a uložit je jako soubory `.vtt`. Každá titulková stopa poskytuje svá binární data a jedinečný identifikátor, který lze použít při exportu titulků.

```py
with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    for shape in slide.shapes:
        if isinstance(shape, slides.AudioFrame):
            audio_frame = shape
            for caption_track in audio_frame.caption_tracks:
                # Uloží titulkovou stopu jako soubor .vtt.
                with open(f"{caption_track.caption_id}.vtt", "wb") as track_stream:
                    track_stream.write(caption_track.binary_data)
```

**Odstranit titulky zvuku**

Pro odstranění titulků z audio rámce použijte metody poskytované třídou [CaptionsCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/captionscollection/), jako jsou [clear](https://reference.aspose.com/slides/cs/python-net/aspose.slides/captionscollection/clear/), [remove](https://reference.aspose.com/slides/cs/python-net/aspose.slides/captionscollection/remove/), nebo [remove_at](https://reference.aspose.com/slides/cs/python-net/aspose.slides/captionscollection/remove_at/). Následující příklad odstraňuje všechny titulkové stopy z audio rámce.

```py
with slides.Presentation("audio_with_captions.pptx") as presentation:
    slide = presentation.slides[0]
    audio_frame = slide.shapes[0]  # typ: slides.AudioFrame

    # Odstraní všechny titulkové stopy z audio rámce.
    audio_frame.caption_tracks.clear()

    presentation.save("audio_without_captions.pptx", slides.export.SaveFormat.PPTX)
```

## **Extrahovat zvuk**

Aspose.Slides pro Python via .NET umožňuje extrahovat zvuk použitý v přechodech prezentace. Například můžete extrahovat zvuk použitý v konkrétním snímku.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) a načtěte prezentaci obsahující zvuk.
2. Získejte referenci na příslušný snímek pomocí jeho indexu.
3. Získejte přístup k přechodům prezentace pro daný snímek.
4. Extrahujte zvuk jako byty.

Tento Python kód ukazuje, jak extrahovat zvuk použitý v snímku:

```python
import aspose.slides as slides

#with slides.Presentation("AudioSlide.pptx") as pres:
with slides.Presentation("AudioFrameEmbed_changed.pptx") as pres:
    # Přistupuje k požadovanému snímku
    slide = pres.slides[0]  

    # Získá efekty přechodu prezentace pro snímek
    transition = slide.slide_show_transition

    # Extrahuje zvuk do pole bytů
    audio = transition.sound.binary_data

    print("Length: " + str(len(audio)))
```

## **Často kladené dotazy**

**Mohu znovu použít stejný zvukový soubor na více snímcích, aniž by se zvětšila velikost souboru?**

Ano. Přidejte zvuk jednou do sdílené [audio collection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/audios/) prezentace a vytvořte další audio rámy, které odkazují na tento existující zdroj. Tím se zabrání duplikaci mediálních dat a velikost prezentace zůstane pod kontrolou.

**Mohu nahradit zvuk v existujícím audio rámci, aniž bych znovu vytvářel tvar?**

Ano. Pro propojený zvuk aktualizujte [link path](https://reference.aspose.com/slides/cs/python-net/aspose.slides/audioframe/link_path_long/) tak, aby ukazoval na nový soubor. Pro vložený zvuk vyměňte objekt [embedded audio](https://reference.aspose.com/slides/cs/python-net/aspose.slides/audioframe/embedded_audio/) za jiný z [audio collection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/audios/). Formátování rámce a většina nastavení přehrávání zůstane zachována.

**Mění ořezávání podkladová audio data uložená v prezentaci?**

Ne. Ořezávání upravuje pouze hranice přehrávání. Původní audio bajty zůstávají nedotčeny a jsou přístupné prostřednictvím vloženého zvuku nebo audio kolekce prezentace.