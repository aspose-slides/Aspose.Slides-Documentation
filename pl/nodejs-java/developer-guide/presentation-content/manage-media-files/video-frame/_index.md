---
title: Zarządzanie ramkami wideo w prezentacjach przy użyciu JavaScript
linktitle: Ramka wideo
type: docs
weight: 10
url: /pl/nodejs-java/video-frame/
keywords:
- dodaj wideo
- tworzenie wideo
- osadzanie wideo
- wyodrębnianie wideo
- pobieranie wideo
- ramka wideo
- źródło internetowe
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak programowo dodawać i wyodrębniać ramki wideo w slajdach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Node.js w języku Java. Szybki przewodnik instruktażowy."
---
## **Wprowadzenie**

Odpowiednio umieszczone wideo w prezentacji może uczynić Twoje przesłanie bardziej przekonującym i zwiększyć poziom zaangażowania odbiorców. 

PowerPoint umożliwia dodawanie wideo do slajdu w prezentacji na dwa sposoby:

* Dodaj lub osadź lokalne wideo (przechowywane na Twoim komputerze)
* Dodaj wideo online (z źródła internetowego, takiego jak YouTube).

Aby umożliwić dodawanie wideo (obiektów wideo) do prezentacji, Aspose.Slides udostępnia klasę [Video](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/video/) klasę [VideoFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/videoframe/) oraz inne odpowiednie typy.

## **Utworzenie osadzonej ramki wideo**

Jeśli plik wideo, który chcesz dodać do slajdu, jest przechowywany lokalnie, możesz utworzyć ramkę wideo, aby osadzić wideo w prezentacji. 

1. Utwórz instancję klasy [Presentation ](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation)class.
1. Uzyskaj odniesienie do slajdu za pomocą jego indeksu. 
1. Dodaj obiekt [Video](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/video/) i podaj ścieżkę do pliku wideo, aby osadzić wideo w prezentacji.
1. Dodaj obiekt [VideoFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/videoframe/) , aby utworzyć ramkę dla wideo.
1. Zapisz zmodyfikowaną prezentację. 

Ten kod JavaScript pokazuje, jak dodać wideo przechowywane lokalnie do prezentacji:

```javascript
// Tworzy instancję klasy Presentation
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // Ładuje wideo
    var fileStream = java.newInstanceSync("java.io.FileInputStream", "Wildlife.mp4");
    var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
    // Pobiera pierwszy slajd i dodaje ramkę wideo
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);
    // Zapisuje prezentację na dysku
    pres.save("pres-with-video.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Alternatywnie możesz dodać wideo, przekazując jego ścieżkę bezpośrednio do metody [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shapecollection/#addVideoFrame-float-float-float-float-aspose.slides.IVideo-) :

```javascript
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    var vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Utworzenie ramki wideo z wideo ze źródła internetowego**

Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) obsługuje wideo z YouTube w prezentacjach. Jeśli wideo, którego chcesz użyć, jest dostępne online (np. na YouTube), możesz dodać je do prezentacji za pomocą jego odnośnika internetowego. 

1. Utwórz instancję klasy [Presentation ](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation)class
1. Uzyskaj odniesienie do slajdu za pomocą jego indeksu. 
1. Dodaj obiekt [Video](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/video/) i podaj odnośnik do wideo.
1. Ustaw miniaturę dla ramki wideo. 
1. Zapisz prezentację. 

Ten kod JavaScript pokazuje, jak dodać wideo z internetu do slajdu w prezentacji PowerPoint:

```javascript
// Instancjonuje obiekt Presentation, który reprezentuje plik prezentacji
var pres = new aspose.slides.Presentation();
try {
    addVideoFromYouTube(pres, "Tj75Arhq5ho");
    pres.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
async function addVideoFromYouTube(pres, videoID) {
    let slide = pres.getSlides().get_Item(0);
    let videoUrl = "https://www.youtube.com/embed/" + videoID;
    let videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    
    videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

    let thumbnailUri = "http://img.youtube.com/vi/" + videoID + "/hqdefault.jpg";

    try {
        const imageStream = await getImageStream(thumbnailUri);
        let image = pres.getImages().addImage(imageStream);
        videoFrame.getPictureFormat().getPicture().setImage(image);
    } catch (error) {
        console.error("Error loading thumbnail:", error);
    }
}

async function getImageStream(url) {
    return new Promise((resolve, reject) => {
        http.get(url, (response) => {
            if (response.statusCode === 200) {
                resolve(response);
            } else {
                reject(new Error(`Failed to load image: ${response.statusCode}`));
            }
        }).on('error', (e) => {
            reject(e);
        });
    });
}
```

## **Przycięcie ramki wideo**

Aspose.Slides pozwala kontrolować, która część wideo jest odtwarzana, ustawiając wartości trim-from-start i trim-from-end za pomocą [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/videoframe/settrimfromstart/) i [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/videoframe/settrimfromend/). Obie wartości podawane są w milisekundach i określają, ile czasu pomijać od początku i końca wideo. Ustawienia te zmieniają sposób odtwarzania wideo w prezentacji; nie przycinają ani nie modyfikują binarnych danych osadzonego wideo.

**Ustawienia przycięcia**

Aby utworzyć ramkę wideo i ustawić jej parametry przycięcia:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) .
1. Dodaj obiekt [Video](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/video/) do prezentacji.
1. Dodaj obiekt [VideoFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/videoframe/) do slajdu.
1. Ustaw wartości trim-from-start i trim-from-end za pomocą [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/videoframe/settrimfromstart/) oraz [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/videoframe/settrimfromend/) .
1. Zapisz zmodyfikowaną prezentację.

Poniższy przykład kodu pomija pierwsze 2,5 s i ostatnią sekundę osadzonego wideo podczas odtwarzania:

```javascript
const presentation = new aspose.slides.Presentation();
try {
    const videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    try {
        const video = presentation.getVideos().addVideo(
            videoStream, aspose.slides.LoadingStreamBehavior.ReadStreamAndRelease);
        const slide = presentation.getSlides().get_Item(0);
        const videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);

        videoFrame.setTrimFromStart(2500);
        videoFrame.setTrimFromEnd(1000);

        presentation.save("video_with_trim.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

**Odczyt ustawień przycięcia**

Aby sprawdzić istniejące ustawienia przycięcia, wczytaj prezentację, znajdź obiekt [VideoFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/videoframe/) wśród kształtów na pierwszym slajdzie i odczytaj wartości za pomocą [VideoFrame.getTrimFromStart](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/videoframe/gettrimfromstart/) oraz [VideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/videoframe/gettrimfromend/) .

Poniższy przykład kodu znajduje pierwszą ramkę wideo na pierwszym slajdzie i raportuje jej ustawienia przycięcia w milisekundach:

```javascript
const presentation = new aspose.slides.Presentation("video_with_trim.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            const trimFromStart = videoFrame.getTrimFromStart();
            const trimFromEnd = videoFrame.getTrimFromEnd();

            console.log("Trim from start: " + trimFromStart + " ms");
            console.log("Trim from end: " + trimFromEnd + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **Zarządzanie napisami wideo**

Aspose.Slides umożliwia zarządzanie zamkniętymi napisami dla ramek wideo w prezentacjach PowerPoint. Napisy są przechowywane w formacie WebVTT i udostępniane za pośrednictwem metody [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) .

**Dodawanie napisów do ramki wideo**

Aby dodać napisy do ramki wideo:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) .
1. Dodaj wideo do prezentacji.
1. Dodaj obiekt [VideoFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/videoframe/) do slajdu.
1. Użyj kolekcji [CaptionsCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/captionscollection/) , aby dodać ścieżkę napisów WebVTT.
1. Zapisz zmodyfikowaną prezentację.

Poniższy kod pokazuje, jak dodać napisy do ramki wideo:

```js
let presentation = new aspose.slides.Presentation();
try {
    let videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    let video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);

    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // Dodaje nową ścieżkę napisów z pliku WebVTT.
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Klasa [CaptionsCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/captionscollection/) udostępnia również metodę [addFromStream](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/captionscollection/#addFromStream) , która pozwala dodać napisy z strumienia.

**Wyodrębnianie napisów z ramki wideo**

Aby wyodrębnić napisy z ramki wideo:

1. Wczytaj prezentację zawierającą wideo.
1. Znajdź docelowy obiekt [VideoFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/videoframe/) .
1. Przejdź przez kolekcję [CaptionsCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/captionscollection/) .
1. Zapisz każdą ścieżkę napisów do pliku `.vtt` .

Poniższy kod pokazuje, jak wyodrębnić napisy z ramki wideo:

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        let shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            let videoFrame = shape;
            let trackCount = videoFrame.getCaptionTracks().getCount();
            for (let trackIndex = 0; trackIndex < trackCount; trackIndex++) {
                let captionTrack = videoFrame.getCaptionTracks().get_Item(trackIndex);
                // Zapisuje ścieżkę napisów do pliku WebVTT.
                let filePath = captionTrack.getCaptionId() + ".vtt";
                let captionData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(filePath, captionData);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Każdy obiekt [Captions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/captions/) udostępnia identyfikator napisu, etykietę, dane binarne oraz tekst napisu jako ciąg UTF‑8.

**Usuwanie napisów z ramki wideo**

Aby usunąć napisy z ramki wideo:

1. Wczytaj prezentację zawierającą wideo.
1. Pobierz docelowy obiekt [VideoFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/videoframe/) .
1. Usuń ścieżki napisów z kolekcji [CaptionsCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/captionscollection/) .
1. Zapisz zmodyfikowaną prezentację.

Poniższy kod pokazuje, jak usunąć wszystkie napisy z ramki wideo:

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().get_Item(0); // typ: com.aspose.slides.VideoFrame

    // Usuwa wszystkie napisy z ramki wideo.
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Jeśli potrzebujesz usunąć tylko jedną ścieżkę napisu, użyj metod [remove](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/captionscollection/#remove) lub [removeAt](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/captionscollection/#removeAt) zamiast [clear](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/captionscollection/#clear) .

## **Wyodrębnianie wideo ze slajdu**

Oprócz dodawania wideo do slajdów, Aspose.Slides pozwala wyodrębnić wideo osadzone w prezentacjach.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation) aby wczytać prezentację zawierającą wideo.
2. Przejdź przez wszystkie obiekty [Slide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slide/) .
3. Przejdź przez wszystkie obiekty [Shape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/) , aby znaleźć [VideoFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/videoframe/) .
4. Zapisz wideo na dysku.

Ten kod JavaScript pokazuje, jak wyodrębnić wideo ze slajdu prezentacji:

```javascript
// Tworzy obiekt Presentation, który reprezentuje plik prezentacji
var pres = new aspose.slides.Presentation("VideoSample.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let slide = pres.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                var vf = shape;
                console.log(shape);
                var type = vf.getEmbeddedVideo().getContentType();
                var ss = type.lastIndexOf('-');
                const buffer = Buffer.from(vf.getEmbeddedVideo().getBinaryData());
                console.log(buffer);
                // Pobiera rozszerzenie pliku
                var charIndex = type.indexOf("/");
                type = type.substring(charIndex + 1);
                fs.writeFileSync("testing2." + type, buffer);
            }
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Jakie parametry odtwarzania wideo można zmienić dla VideoFrame?**

Możesz kontrolować [tryb odtwarzania](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/videoframe/setplaymode/) (automatycznie lub po kliknięciu) oraz [pętlę](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/videoframe/setplayloopmode/). Opcje te są dostępne poprzez właściwości obiektu [VideoFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/videoframe/) .

**Czy dodanie wideo wpływa na rozmiar pliku PPTX?**

Tak. Gdy osadzisz lokalne wideo, jego dane binarne są dołączane do dokumentu, więc rozmiar prezentacji rośnie proporcjonalnie do rozmiaru pliku. Gdy dodasz wideo online, osadzany jest jedynie odnośnik i miniatura, więc przyrost rozmiaru jest mniejszy.

**Czy mogę zamienić wideo w istniejącej ramce VideoFrame bez zmiany jej położenia i rozmiaru?**

Tak. Możesz podmienić [zawartość wideo](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) w ramce, zachowując geometrię kształtu; jest to typowy scenariusz aktualizacji multimediów w istniejącym układzie.

**Czy można określić typ zawartości (MIME) osadzonego wideo?**

Tak. Osadzone wideo posiada [typ zawartości](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/video/getcontenttype/), który możesz odczytać i wykorzystać, na przykład przy zapisywaniu go na dysk.