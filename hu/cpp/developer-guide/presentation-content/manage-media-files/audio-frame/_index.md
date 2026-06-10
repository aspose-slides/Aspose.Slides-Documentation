---
title: Hang kezelése prezentációkban C++-vel
linktitle: Audio keret
type: docs
weight: 10
url: /hu/cpp/audio-frame/
keywords:
- hang
- audio keret
- bélyegkép
- hang hozzáadása
- hang tulajdonságok
- hang beállítások
- hang kinyerése
- C++
- Aspose.Slides
description: "Audio keretek létrehozása és vezérlése az Aspose.Slides for C++-ban – példakódok beágyazásra, vágásra, ismétlésre és lejátszás beállítására PPT, PPTX és ODP prezentációkban."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan dolgozhat az audio képkockákkal az Aspose.Slides-ban. Bemutatja, hogyan adhat beágyazott hangot a diákhoz, testreszabhatja az audio keret bélyegképét, konfigurálhatja a lejátszási beállításokat, például hangerőt, ismétlést, elrejtést, vágást és elhalványulási időket, valamint hogyan nyerheti ki a diavetítés átmeneteihez használt hangot.

## **Audio Képkockák Létrehozása**

Aspose.Slides for C++ lehetővé teszi hangfájlok hozzáadását a diákhoz. A hangfájlok beágyazott audio képkockaként jelennek meg a diákban. 

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.
2. Szerezze meg egy dia referenciaját az indexe alapján.
3. Töltse be azt az audio fájl adatfolyamot, amelyet a diába kíván beágyazni.
4. Adja hozzá a beágyazott audio képkockát (amely tartalmazza az audio fájlt) a diához.
5. Állítsa be a [PlayMode](https://reference.aspose.com/slides/hu/cpp/namespace/aspose.slides#a1e0dfa632c5498e693145d42f3cf8e4c) és a `Volume` értékeket, amelyeket az [IAudioFrame](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_audio_frame) objektum biztosít.
6. Mentse el a módosított prezentációt.

Ez a C++ kód bemutatja, hogyan adjon beágyazott audio képkockát egy diára:

``` cpp
// Létrehozza a Presentation osztályt, amely egy prezentációfájlt képvisel
auto pres = System::MakeObject<Presentation>();

// Lekéri az első diát
auto sld = pres->get_Slides()->idx_get(0);

// Betölti a wav hangfájlt adatfolyamba
auto fstr = System::MakeObject<FileStream>(u"sampleaudio.wav", FileMode::Open, FileAccess::Read);

// Hozzáadja az Audio keretet
auto audioFrame = sld->get_Shapes()->AddAudioFrameEmbedded(50.0f, 150.0f, 100.0f, 100.0f, fstr);

// Beállítja az audio lejátszási módját és hangerőjét
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

// Kiírja a PowerPoint fájlt a lemezre
pres->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```

## **Az Audio Képkocka Bélyegképének Módosítása**

Amikor egy audio fájlt ad hozzá egy prezentációhoz, az audio egy standard alapértelmezett képpel megjelenő keretként jelenik meg (lásd az alábbi képet). Megváltoztathatja az audio keret bélyegképét (beállíthatja a kívánt képet).

Ez a C++ kód bemutatja, hogyan változtassa meg egy audio képkocka bélyegképét vagy előnézeti képét:

```cpp
auto presentation = System::MakeObject<Presentation>();
        
auto slide = presentation->get_Slides()->idx_get(0);
        
// Egy audio keretet ad a diára a megadott pozícióval és mérettel.
auto audioStream = System::MakeObject<System::IO::FileStream>(u"sample2.mp3", 
    System::IO::FileMode::Open, System::IO::FileAccess::Read);
    
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(150.0f, 100.0f, 50.0f, 50.0f, audioStream);
            
// Képet ad a prezentáció erőforrásaihoz.
auto imageStream = System::IO::File::OpenRead(u"eagle.jpeg");
auto audioImage = presentation->get_Images()->AddImage(imageStream);
            
// Beállítja a képet az audio kerethez.
audioFrame->get_PictureFormat()->get_Picture()->set_Image(audioImage); // <-----
        
//Menti a módosított prezentációt a lemezre
presentation->Save(u"example_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Az Audio Lejátszási Beállítások Módosítása**

Aspose.Slides for C++ lehetővé teszi a hang lejátszását vagy tulajdonságait szabályozó opciók módosítását. Például beállíthatja a hangerőt, ismétlést vagy akár elrejtheti az audio ikont.

A **Audio Options** panel a Microsoft PowerPoint programban:

![example1_image](audio_frame_0.png)

PowerPoint **Audio Options**, amely az Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/audioframe/) metódusainak felel meg:

- **Start** legördülő lista megfelel a [AudioFrame::set_PlayMode](https://reference.aspose.com/slides/hu/cpp/aspose.slides/audioframe/set_playmode/) metódusnak
- **Volume** megfelel a [AudioFrame::set_Volume](https://reference.aspose.com/slides/hu/cpp/aspose.slides/audioframe/set_volume/) metódusnak
- **Play Across Slides** megfelel a [AudioFrame::set_PlayAcrossSlides](https://reference.aspose.com/slides/hu/cpp/aspose.slides/audioframe/set_playacrossslides/) metódusnak
- **Loop until Stopped** megfelel a [AudioFrame::set_PlayLoopMode](https://reference.aspose.com/slides/hu/cpp/aspose.slides/audioframe/set_playloopmode/) metódusnak
- **Hide During Show** megfelel a [AudioFrame::set_HideAtShowing](https://reference.aspose.com/slides/hu/cpp/aspose.slides/audioframe/set_hideatshowing/) metódusnak
- **Rewind after Playing** megfelel a [AudioFrame::set_RewindAudio](https://reference.aspose.com/slides/hu/cpp/aspose.slides/audioframe/set_rewindaudio/) metódusnak

PowerPoint **Editing** opciók, amelyek az Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/audioframe/) tulajdonságainak felelnek meg:

- **Fade In** megfelel a [AudioFrame.set_FadeInDuration](https://reference.aspose.com/slides/hu/cpp/aspose.slides/audioframe/set_fadeinduration/) metódusnak
- **Fade Out** megfelel a [AudioFrame.set_FadeOutDuration](https://reference.aspose.com/slides/hu/cpp/aspose.slides/audioframe/set_fadeoutduration/) metódusnak
- **Trim Audio Start Time** megfelel a [AudioFrame.set_TrimFromStart](https://reference.aspose.com/slides/hu/cpp/aspose.slides/audioframe/set_trimfromstart/) metódusnak
- **Trim Audio End Time** értéke megegyezik az audio időtartamával mínusz a [AudioFrame.set_TrimFromEnd](https://reference.aspose.com/slides/hu/cpp/aspose.slides/audioframe/set_trimfromend/) metódus értéke

A PowerPoint **Volume control** a [AudioFrame.set_VolumeValue](https://reference.aspose.com/slides/hu/cpp/aspose.slides/audioframe/set_volumevalue/) metódusnak felel meg. Lehetővé teszi a hangerő százalékos módon történő módosítását.

Így módosíthatja az Audio lejátszási beállításokat:

1. [Létrehozás](#creating-audio-frame) vagy szerezze meg az Audio képkockát.
2. Állítson be új értékeket azokhoz az Audio képkocka tulajdonságokhoz, amelyeket módosítani kíván.
3. Mentse el a módosított PowerPoint fájlt.

Ez a C++ kód bemutatja, hogyan állíthatja be egy audio opcióit:

``` cpp 
auto pres = System::MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");

// Lekéri egy alakzatot
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0);

// Átalakítja az alakzatot AudioFrame alakzattá
auto audioFrame = System::ExplicitCast<AudioFrame>(shape);

// Beállítja a lejátszási módot kattintásra
audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);

// Beállítja a hangerőt alacsonyra
audioFrame->set_Volume(AudioVolumeMode::Low);

// Beállítja, hogy a hang diákon át lejátszódjon
audioFrame->set_PlayAcrossSlides(true);

// Kikapcsolja a hang ismétlését
audioFrame->set_PlayLoopMode(false);

// Elrejti az AudioFrame-et a diavetítés során
audioFrame->set_HideAtShowing(true);

// Visszatekinti a hangot a lejátszás után a kiinduló pozícióba
audioFrame->set_RewindAudio(true);

// Elmenti a PowerPoint fájlt a lemezre
pres->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
```

Ez a C++ példa bemutatja, hogyan adjon új audio képkockát beágyazott hanggal, vágja le, és állítsa be az elhalványulási időket:

```cpp
auto pres = MakeObject<Presentation>();
auto slide = pres->get_Slide(0);

auto audioData = File::ReadAllBytes(u"sampleaudio.mp3");
auto audio = pres->get_Audios()->AddAudio(audioData);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, audio);

// Beállítja a vágás kezdőeltolását 1,5 másodpercre
audioFrame->set_TrimFromStart(1500);
// Beállítja a vágás befejező eltolását 2 másodpercre
audioFrame->set_TrimFromEnd(2000);

// Beállítja a fade-in időtartamot 200 ms-re
audioFrame->set_FadeInDuration(200);
// Beállítja a fade-out időtartamot 500 ms-re
audioFrame->set_FadeOutDuration(500);

pres->Save(u"AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```

A következő kódrészlet megmutatja, hogyan kérje le egy beágyazott audioval rendelkező audio képkockát, és állítsa be a hangerőt 85%-ra:

```cpp
auto pres = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
    
// Lekér egy audio keret alakzatot
auto audioFrame = ExplicitCast<IAudioFrame>(pres->get_Slide(0)->get_Shape(0));

// Beállítja a hanghangerőt 85%-ra
audioFrame->set_VolumeValue(85);

pres->Save(u"AudioFrameValue_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```

## **Audio Feliratok Kezelése**

Az Aspose.Slides lehetővé teszi, hogy zárt feliratokat adjunk egy audio képkockához a [get_CaptionTracks](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iaudioframe/get_captiontracks/) metódus segítségével. Ez a metódus egy [ICaptionsCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icaptionscollection/) objektumot ad vissza, amely lehetővé teszi WebVTT felirat sávok hozzáadását, a meglévő sávok bejárását és szükség esetén azok eltávolítását.

**Audio Feliratok Hozzáadása**

Használja a [get_CaptionTracks](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iaudioframe/get_captiontracks/) metódust, hogy egy vagy több feliratsávot csatoljon egy audio képkockához. Az alábbi példában egy audio fájlt adunk hozzá egy diához, majd egy új feliratsávot töltünk be egy `.vtt` fájlból.

```cpp
auto presentation = MakeObject<Presentation>();

auto audioData = File::ReadAllBytes(u"audio.mp3");
auto audio = presentation->get_Audios()->AddAudio(audioData);

auto slide = presentation->get_Slide(0);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(10, 10, 50, 50, audio);

// Add a new caption track from a WebVTT file.
audioFrame->get_CaptionTracks()->Add(u"New track", u"track.vtt");

presentation->Save(u"audio_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

**Audio Feliratok Kinyerése**

Bejárhatja az audio képkockához kapcsolódó feliratsávokat, és elmentheti őket `.vtt` fájlokként. Minden feliratsáv kiadja a bináris adatot és egyedi azonosítóját, amelyet a feliratok exportálásakor felhasználhat.

```cpp
auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);
for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IAudioFrame>(shape))
    {
        auto audioFrame = ExplicitCast<IAudioFrame>(shape);
        for (auto&& captionTrack : audioFrame->get_CaptionTracks())
        {
            // Mentse minden feliratsávot .vtt fájlként.
            auto fileName = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(fileName, captionTrack->get_BinaryData());
        }
    }
}
presentation->Dispose();
```

**Audio Feliratok Eltávolítása**

A feliratok egy audio képkockáról való eltávolításához használja az [ICaptionsCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icaptionscollection/) által biztosított metódusokat, például a [Clear](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icaptionscollection/clear/), [Remove](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icaptionscollection/remove/), vagy a [RemoveAt](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icaptionscollection/removeat/) metódust. Az alábbi példa eltávolítja az összes feliratsávot egy audio képkockáról.

```cpp
auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto audioFrame = ExplicitCast<IAudioFrame>(slide->get_Shape(0));

// Eltávolítja az összes feliratsávot az audio keretből.
audioFrame->get_CaptionTracks()->Clear();

presentation->Save(u"audio_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Audio Kinyerése**

Az Aspose.Slides lehetővé teszi a diavetítés átmeneteihez használt hang kinyerését. Például kinyerheti egy adott dia hangját.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból, és töltse be a hangot tartalmazó prezentációt.
2. Szerezze meg a megfelelő dia referenciaját az indexe alapján.
3. Hozzáférés a dia diavetítés átmeneteihez.
4. Kinyerés a hangot bájt adatként.

Ez a C++ kód megmutatja, hogyan nyerje ki egy dia által használt audiot:

``` cpp
String presName = u"AudioSlide.pptx";

// Létrehozza a Presentation osztályt, amely egy prezentációfájlt képvisel
auto pres = System::MakeObject<Presentation>(presName);

// Accesses the desired slide
auto slide = pres->get_Slides()->idx_get(0);

// Gets the slideshow transition effects for the slide
auto transition = slide->get_SlideShowTransition();

// Extracts the sound in byte array
auto audio = transition->get_Sound()->get_BinaryData();

Console::WriteLine(String(u"Length: ") + audio->get_Length());
```

## **GYIK**

**Újra felhasználhatom ugyanazt a hangfájlt több dián anélkül, hogy megnövelném a fájlméretet?**

Igen. Adja hozzá a hangot egyszer a prezentáció megosztott [audio collection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_audios/) gyűjteményéhez, és hozzon létre további audio képkockákat, amelyek erre a meglévő eszközre hivatkoznak. Ez megakadályozza a médiaadatok duplikálását, és a prezentáció méretét kordában tartja.

**Lecserélhetem a hangot egy meglévő audio képkockában anélkül, hogy újra létrehoznám az alakzatot?**

Igen. Kapcsolt hang esetén frissítse a [link path](https://reference.aspose.com/slides/hu/cpp/aspose.slides/audioframe/set_linkpathlong/) útvonalát, hogy az új fájlra mutasson. Beágyazott hang esetén cserélje ki a [embedded audio](https://reference.aspose.com/slides/hu/cpp/aspose.slides/audioframe/set_embeddedaudio/) objektumot egy másikra a prezentáció [audio collection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_audios/) gyűjteményéből. A keret formázása és a legtöbb lejátszási beállítás változatlan marad.

**A vágás módosítja a prezentációban tárolt audio adatot?**

Nem. A vágás csak a lejátszási határokat állítja be. Az eredeti audio bájtok érintetlenek maradnak, és a beágyazott audio vagy a prezentáció audio gyűjteménye révén hozzáférhetők.