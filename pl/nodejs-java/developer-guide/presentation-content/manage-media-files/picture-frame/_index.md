---
title: Zarządzanie ramkami obrazu w prezentacjach przy użyciu JavaScript
linktitle: Ramka obrazu
type: docs
weight: 10
url: /pl/nodejs-java/picture-frame/
keywords:
- ramka obrazu
- dodaj ramkę obrazu
- utwórz ramkę obrazu
- obraz osadzony
- obraz połączony
- wyodrębnij obraz
- obraz rastrowy
- obraz SVG
- przytnij obraz
- usuń przycięte obszary
- kompresuj obraz
- StretchOffset
- formatowanie ramki obrazu
- skala względna
- efekt obrazu
- proporcje obrazu
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Twórz, formatuj, łącz, przycinaj, wyodrębniaj i kompresuj ramki obrazu w prezentacjach przy użyciu Aspose.Slides dla Node.js za pomocą JavaScript."
---
## **Przegląd**

Ramka obrazu jest kształtem slajdu wyświetlającym obraz. W Aspose.Slides zasób obrazu i kształt, który go wyświetla, są oddzielnymi obiektami: [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) posiada osadzone zasoby obrazów poprzez swoją [ImageCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/imagecollection/), podczas gdy [PictureFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pictureframe/) kontroluje pozycję obrazu, rozmiar, formatowanie linii, obrót, przycinanie, efekty obrazu i inne ustawienia na poziomie ramki.

To rozdzielenie jest przydatne, gdy ten sam obraz jest wyświetlany więcej niż raz. Dodaj obraz do prezentacji raz, zachowaj zwrócony [PPImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ppimage/), i użyj tego zasobu obrazu przy tworzeniu ramek obrazu.

Ramki obrazu mogą zawierać obrazy rastrowe, takie jak PNG lub JPEG, oraz obrazy wektorowe SVG. Mogą także odwoływać się do połączonych obrazów zamiast przechowywać bajty obrazu w prezentacji. Wybór wpływa na przenośność, rozmiar pliku, sposób wyodrębniania i zachowanie przy eksporcie, dlatego warto zdecydować, jak obraz ma być przechowywany, zanim zastosujesz formatowanie lub optymalizację.

## **Dodaj i sformatuj osadzony obraz**

W przypadku obrazu osadzonego dodaj dane obrazu do prezentacji i utwórz ramkę obrazu za pomocą [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shapecollection/#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-). Obraz staje się częścią pakietu prezentacji, więc prezentacja pozostaje samodzielna po przeniesieniu na inny komputer.

Poniższy przykład dodaje obraz PNG, tworzy ramkę o natywnych wymiarach obrazu i stosuje formatowanie linii oraz obrót:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ramka obrazu kontroluje wyświetlaną geometrię; zmiana rozmiaru ramki nie zmienia pierwotnych wymiarów pikseli przechowywanych w osadzonym zasobie obrazu. Rozróżnienie to staje się ważne przy późniejszym przycinaniu lub kompresji obrazu.

## **Użyj skali względnej**

[PictureFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pictureframe/) udostępnia skalowanie względne szerokości i wysokości ramki poprzez [setRelativeScaleWidth](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleWidth-float-) i [setRelativeScaleHeight](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pictureframe/#setRelativeScaleHeight-float-). Wartość `1.0` odpowiada 100 % pierwotnego rozmiaru obrazu. Skala względna jest przydatna, gdy przepływ pracy wymaga zachowania proporcji względem rozmiaru źródłowego obrazu zamiast ręcznego obliczania końcowych wymiarów.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(java.newFloat(1.35));
    pictureFrame.setRelativeScaleHeight(java.newFloat(0.8));

    presentation.save("relative-scale.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Skala względna zmienia ustawienia skali ramki; nie dokonuje ona próbkowania ani kompresji osadzonego obrazu.

## **Obrazy osadzone i połączone**

Obraz osadzony przechowuje dane obrazu wewnątrz prezentacji i jest zatem najbezpieczniejszym wyborem pod względem przenośności i przewidywalnego renderowania. Obraz połączony przechowuje zewnętrzną lokalizację przy użyciu metody [Picture.setLinkPathLong](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/picture/#setLinkPathLong-java.lang.String-) zamiast osadzania danych obrazu w ten sam sposób.

Połączone obrazy mogą zmniejszyć ilość danych obrazu przechowywanych w pliku PPTX, ale wprowadzają zewnętrzną zależność. Plik połączony musi pozostać dostępny dla aplikacji otwierającej lub renderującej prezentację. Jeśli ścieżka ulegnie zmianie, plik zostanie przeniesiony lub zasób będzie niedostępny, połączony obraz może nie być wyświetlany zgodnie z oczekiwaniami. Dla prezentacji, które muszą być wysyłane e‑mailem, archiwizowane lub renderowane w odizolowanych środowiskach, obrazy osadzone są zwykle bardziej niezawodne.

### **Dodaj połączony obraz**

Poniższy przykład tworzy ramkę obrazu i wskazuje ją na lokalny plik obrazu. Dotyczy on wyłącznie łączenia obrazów; łączenie wideo jest osobnym przepływem multimedialnym i celowo nie jest mieszane w tym przykładzie.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const path = require("path");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 180, null);
    const linkPath = path.resolve("image.png");
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Używaj łączy, gdy zarządzanie plikami zewnętrznymi jest zamierzone. Nie używaj ich jedynie jako zamiennika kompresji: mały PPTX z uszkodzonymi zależnościami obrazów jest zazwyczaj mniej użyteczny niż większa, samodzielna prezentacja.

## **Wyodrębnij obrazy z ramek obrazu**

Przed wyodrębnieniem obrazu z istniejącej prezentacji sprawdź, czy kształt jest faktycznie [PictureFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pictureframe/) i czy zawiera osadzony obraz. Połączone ramki obrazu mogą nie zawierać bajtów obrazu, które można wyodrębnić w ten sam sposób.

### **Wyodrębnij obraz rastrowy**

Nowoczesne API obrazu używa bezpośrednio [IImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/iimage/). Poniższy przykład znajduje pierwszy osadzony rastrowy obraz na slajdzie i zapisuje go jako PNG:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            continue;
        }

        const embeddedImage = shape.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        const rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", aspose.slides.ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

Zapis przy użyciu [IImage.save](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/iimage/#save) konwertuje wyodrębniony obraz do żądanego formatu wyjściowego. Jeśli potrzebujesz zakodowanych bajtów przechowywanych w prezentacji, a nie skonwertowanego pliku rastrowego, użyj binarnych danych zasobu obrazu.

### **Wyodrębnij obraz SVG**

W przypadku obrazu SVG [PPImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ppimage/) udostępnia obiekt [SvgImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/svgimage/). Pozwala to pobrać dane SVG bezpośrednio zamiast rasteryzować obraz najpierw.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            continue;
        }

        const embeddedImage = shape.getPictureFormat().getPicture().getImage();
        const svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        fs.writeFileSync("extracted-image.svg", svgImage.getSvgData());
        break;
    }
} finally {
    presentation.dispose();
}
```

Zachowanie treści SVG jako SVG zachowuje wektorowe źródło w prezentacji. Eksporty rastrowe, takie jak PNG lub JPEG, koniecznie renderują tę wektorową treść do pikseli. Eksport slajdu do PDF lub SVG również jest operacją renderowania, więc wyeksportowana grafika nie powinna być traktowana jako dokładna kopia oryginalnego osadzonego SVG; użyj danych [SvgImage.getSvgData](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/svgimage/#getSvgData--) gdy potrzebny jest pierwotny zasób wektorowy.

## **Przytnij obraz**

Przycinanie zmienia, która część obrazu jest widoczna wewnątrz ramki. Wartości przycięcia w [PictureFillFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/picturefillformat/) są procentami wymiarów obrazu źródłowego. Przycinanie początkowo nie usuwa ukrytych pikseli z osadzonego obrazu; zmienia jedynie widoczny obszar.

Poniższy przykład bezpiecznie znajduje ramkę obrazu i stosuje wartości przycięcia:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(java.newFloat(23.6));
        pictureFrame.getPictureFormat().setCropRight(java.newFloat(21.5));
        pictureFrame.getPictureFormat().setCropTop(java.newFloat(3));
        pictureFrame.getPictureFormat().setCropBottom(java.newFloat(31));
        presentation.save("cropped-image.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Ponieważ ukryte dane obrazu nadal istnieją, przycięcie może być zmienione później bez utraty oryginalnych pikseli. Jeśli rozmiar pliku ma większe znaczenie niż odwracalność, przycięte regiony można fizycznie usunąć, jak opisano w następnym rozdziale.

## **Usuń przycięte dane obrazu**

[PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) usuwa dane obrazu poza bieżącym prostokątem przycięcia i zwraca wynikowy zasób obrazu. Może to zmniejszyć rozmiar pliku, ale jest destrukcyjną optymalizacją: po zapisaniu prezentacji usunięte piksele nie są już dostępne do późniejszego odwrócenia przycięcia.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", aspose.slides.SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

Metoda może dodać nowy zasób obrazu do prezentacji. Jeśli oryginalny obraz jest również używany przez inne ramki obrazu, te ramki nadal potrzebują istniejącego zasobu, więc usunięcie przyciętych obszarów niekoniecznie zmniejsza łączną liczbę obrazów. Przycinanie treści WMF lub EMF przy użyciu tej metody rasteryzuje przycięty wynik do PNG.

## **Kompresuj obrazy rastrowe**

[PictureFillFormat.compressImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) zmniejsza rozdzielczość obrazu rastrowego w stosunku do rozmiaru, w jakim obraz jest wyświetlany. Może także usunąć przycięte regiony w tej samej operacji. Metoda zwraca `true`, gdy obraz został zmieniony rozmiaru lub przycięty oraz `false`, gdy nie było konieczności zmian.

Użyj predefiniowanej wartości [PicturesCompression](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/picturescompression/), gdy wystarcza standardowa docelowa rozdzielczość:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let pictureFrame = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const compressed = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);
        console.log(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Zamiast predefiniowanej wartości można przekazać własną dodatnią wartość DPI, gdy wymagana jest konkretna rozdzielczość docelowa.

Kompresja przeznaczona jest dla obrazów rastrowych. Treść SVG i metaplików nie jest zmniejszana przez ten workflow kompresji rastrowej. Pamiętaj też, że niższa rozdzielczość i usunięte przycięte regiony nie mogą być odzyskane z zoptymalizowanej prezentacji. Wybieraj docelową rozdzielczość na podstawie największego rozmiaru, w jakim obraz będzie rzeczywiście oglądany lub eksportowany, a nie stosuj najniższego DPI globalnie.

## **Zarządzaj efektami transformacji obrazu**

Pełny workflow obejmujący jasność, kontrast, transformacje kolorów, rozmycie, efekty alfa, łańcuchy kolejności, inspekcję, usuwanie i weryfikację dwukierunkową znajduje się w [Image Transform Effects](/nodejs-java/image-transform-effects/).

## **Zablokuj geometrię ramki obrazu**

Ustawienia [PictureFrameLock](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pictureframelock/) kontrolują, które operacje edycji są wyłączone dla ramki obrazu. Na przykład [setAspectRatioLocked](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) zachowuje proporcje kształtu podczas zmiany rozmiaru.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Blokada dotyczy kształtu ramki obrazu. Nie wymusza ona ponownego próbkowania źródłowego obrazu ani trwałej zmiany jego proporcji.

## **Dostosuj wartości StretchOffset**

Gdy tryb wypełnienia obrazu jest rozciągnięty, wartości stretch‑offset w [PictureFillFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/picturefillformat/) definiują prostokąt wypełnienia względem ramki obrazu. Dodatnie procenty tworzą wcięcie od krawędzi, natomiast ujemne procenty tworzą występ.

Jest to różne od przycinania. Wartości przycięcia wybierają, która część obrazu źródłowego jest widoczna; offsety rozciągnięcia zmieniają prostokąt, w którym widoczne wypełnienie obrazu jest rozciągane.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("image.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(java.newByte(aspose.slides.PictureFillMode.Stretch));
    pictureFrame.getPictureFormat().setStretchOffsetLeft(java.newFloat(12));
    pictureFrame.getPictureFormat().setStretchOffsetRight(java.newFloat(12));
    pictureFrame.getPictureFormat().setStretchOffsetTop(java.newFloat(8));
    pictureFrame.getPictureFormat().setStretchOffsetBottom(java.newFloat(8));

    presentation.save("stretch-offsets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Używaj offsetów rozciągnięcia do pozycjonowania wypełnienia. Używaj właściwości przycięcia, gdy celem jest ukrycie krawędzi obrazu źródłowego.

## **Rozważania dotyczące przechowywania, rozmiaru pliku i eksportu**

Główne kompromisy są łatwiejsze do zarządzania, gdy przechowywanie obrazu i formatowanie ramki obrazu są traktowane oddzielnie:

- **Obrazy osadzone** czynią prezentację samodzielną i są najbardziej niezawodne przy udostępnianiu oraz renderowaniu po stronie serwera, ale duże obrazy rastrowe zwiększają rozmiar PPTX i użycie pamięci.
- **Obrazy połączone** mogą utrzymać pakiet mniejszy, ale prezentacja zależy od dostępności plików zewnętrznych pod zapisanymi ścieżkami lub lokalizacjami.
- **Przycinanie** jest początkowo nieodwracalne. Ukryte piksele pozostają osadzone, dopóki przycięte obszary nie zostaną explicite usunięte lub usunięte podczas kompresji.
- **Kompresja** może znacznie zmniejszyć rozmiar pliku przy zbyt dużych obrazach rastrowych, ale kosztem utraty rozdzielczości źródłowej. Powinna być stosowana po poznaniu docelowego rozmiaru na slajdzie.
- **Obrazy SVG** powinny pozostać w formacie SVG, gdy ważne jest zachowanie wektora. Wyodrębnij osadzony SVG bezpośrednio, gdy potrzebny jest sam zasób wektorowy. Eksport slajdu do formatu rastrowego zawsze konwertuje renderowany slajd na piksele.
- **Powtarzane obrazy** powinny ponownie wykorzystywać istniejący zasób [PPImage] zamiast wielokrotnego ładowania tego samego pliku do przepływu pracy prezentacji.

W dużych prezentacjach optymalizacja obrazu jest zwykle najskuteczniejsza przy selektywnym podejściu: zachowuj loga i diagramy jako treść wektorową, kompresuj zdjęcia zgodnie z ich rzeczywistym rozmiarem wyświetlania, usuwaj przycięte piksele tylko wtedy, gdy późniejsza edycja nie jest wymagana, i unikaj zewnętrznych linków, chyba że zarządzanie zależnościami jest częścią projektu wdrożenia.

## **FAQ**

**Jaka jest różnica między ramką obrazu a zasobem obrazu?**

[PPImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ppimage/) reprezentuje zasób obrazu powiązany z prezentacją. [PictureFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pictureframe/) jest kształtem na slajdzie wyświetlającym obraz i przechowuje geometrię oraz formatowanie na poziomie ramki, takie jak rozmiar, obrót, wartości przycięcia, efekty i blokady.

**Czy powinienem osadzać czy łączyć obrazy?**

Osadzaj obrazy, gdy prezentacja musi być przenośna, archiwizowana lub renderowana bez dostępu do zasobów zewnętrznych. Łącz obrazy tylko wtedy, gdy trzymanie plików obrazu poza PPTX jest zamierzone i zewnętrzne lokalizacje mogą być utrzymywane niezawodnie.

**Czy przycinanie zmniejsza rozmiar pliku PPTX?**

Nie samo w sobie. Normalne ustawienia przycięcia ukrywają części obrazu źródłowego, ale zachowują podłoże pikseli. Użyj [PictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) lub kompresji obrazu z usuwaniem przyciętych obszarów, gdy te piksele można trwale usunąć.

**Czy mogę przywrócić jakość obrazu po kompresji?**

Nie. Kompresja może zmniejszyć przechowywaną rozdzielczość rastrową, a usunięcie przyciętych regionów odrzuca dane obrazu. Zachowaj oryginalny obraz źródłowy poza prezentacją, jeśli później może być wymagana edycja w wysokiej rozdzielczości.

**Jak obsługiwać obrazy SVG?**

Zachowuj treść SVG jako SVG, gdy zależy Ci na wierności wektora. Osadzony [SvgImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/svgimage/) może być wyodrębniony bezpośrednio. Renderowanie slajdu do formatu rastrowego, takiego jak PNG lub JPEG, rasteryzuje SVG jako część obrazu slajdu.

**Jak uniknąć niebezpiecznych rzutowań przy odczycie istniejących slajdów?**

Sprawdź typ kształtu przed użyciem członków specyficznych dla ramki obrazu. Kontrola `java.instanceOf` przeciwko [PictureFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pictureframe/) unika nieprawidłowych rzutowań i pozwala kodowi obsłużyć slajdy, które nie zawierają ramki obrazu.