---
title: Zarządzaj ramkami obrazów w prezentacjach przy użyciu JavaScript
linktitle: Ramka obrazu
type: docs
weight: 10
url: /pl/nodejs-java/picture-frame/
keywords:
- ramka obrazu
- dodaj ramkę obrazu
- utwórz ramkę obrazu
- dodaj obraz
- utwórz obraz
- wyodrębnij obraz
- obraz rastrowy
- obraz wektorowy
- przytnij obraz
- obszar przycięty
- właściwość StretchOff
- formatowanie ramki obrazu
- właściwości ramki obrazu
- skala względna
- efekt obrazu
- proporcje obrazu
- przezroczystość obrazu
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dodaj ramki obrazu do prezentacji PowerPoint i OpenDocument przy użyciu Aspose.Slides for Node.js via Java. Usprawnij swój przepływ pracy i ulepsz projekty slajdów."
---
## **Wprowadzenie**

Obramowanie obrazu jest kształtem, który zawiera obraz — jest to jak zdjęcie w ramce.  

Możesz dodać obraz do slajdu poprzez ramkę obrazu. W ten sposób formatowanie obrazu odbywa się poprzez formatowanie ramki obrazu.

{{% alert  title="Wskazówka" color="primary" %}} 

Aspose udostępnia darmowe konwertery — [JPEG do PowerPoint](https://products.aspose.app/slides/pl/import/jpg-to-ppt) i [PNG do PowerPoint](https://products.aspose.app/slides/pl/import/png-to-ppt) — które pozwalają szybko tworzyć prezentacje z obrazów. 

{{% /alert %}} 

## **Utwórz ramkę obrazu**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).  
2. Pobierz odwołanie do slajdu przy użyciu jego indeksu.  
3. Utwórz obiekt `PPImage`, dodając obraz do [ImagesCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ImageCollection) powiązanej z obiektem prezentacji, który zostanie użyty do wypełnienia kształtu.  
4. Określ szerokość i wysokość obrazu.  
5. Utwórz [PictureFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PictureFrame) na podstawie szerokości i wysokości obrazu przy użyciu metody `addPictureFrame` udostępnionej przez obiekt shape powiązany z wybranym slajdem.  
6. Dodaj ramkę obrazu (zawierającą obraz) do slajdu.  
7. Zapisz zmodyfikowaną prezentację jako plik PPTX.  

Ten kod JavaScript pokazuje, jak utworzyć ramkę obrazu:

```javascript
// Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
var pres = new aspose.slides.Presentation();
try {
    // Pobiera pierwszy slajd
    var sld = pres.getSlides().get_Item(0);
    // Tworzy instancję klasy Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Dodaje ramkę obrazu o wysokości i szerokości odpowiadającej obrazowi
    sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Zapisuje plik PPTX na dysku
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Ramki obrazu umożliwiają szybkie tworzenie slajdów prezentacji na podstawie obrazów. Łącząc ramkę obrazu z opcjami zapisu Aspose.Slides, możesz manipulować operacjami wejścia/wyjścia, aby konwertować obrazy z jednego formatu na inny.

## **Utwórz ramkę obrazu z skalowaniem względnym**

Zmieniając skalowanie względne obrazu, możesz stworzyć bardziej złożoną ramkę obrazu.  

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).  
2. Pobierz odwołanie do slajdu przy użyciu jego indeksu.  
3. Dodaj obraz do kolekcji obrazów prezentacji.  
4. Utwórz obiekt [PPImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PPImage), dodając obraz do [ImagesCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ImageCollection) powiązanej z obiektem prezentacji, który zostanie użyty do wypełnienia kształtu.  
5. Określ względną szerokość i wysokość obrazu w ramce obrazu.  
6. Zapisz zmodyfikowaną prezentację jako plik PPTX.  

Ten kod JavaScript pokazuje, jak utworzyć ramkę obrazu ze skalowaniem względnym:

```javascript
// Utwórz instancję klasy Presentation, która reprezentuje plik PPTX
var pres = new aspose.slides.Presentation();
try {
    // Pobierz pierwszy slajd
    var sld = pres.getSlides().get_Item(0);
    // Utwórz instancję klasy Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Dodaj ramkę obrazu o wysokości i szerokości równych obrazowi
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Ustawianie względnej skali szerokości i wysokości
    pf.setRelativeScaleHeight(0.8);
    pf.setRelativeScaleWidth(1.35);
    // Zapisz plik PPTX na dysku
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Wyodrębnij obrazy rastrowe z ramek obrazu**

Możesz wyodrębnić obrazy rastrowe z obiektów [PictureFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PictureFrame) i zapisać je w formatach PNG, JPG i innych. Poniższy przykład kodu demonstruje, jak wyodrębnić obraz z dokumentu „sample.pptx” i zapisać go w formacie PNG.

```javascript
var presentation = new aspose.slides.Presentation("sample.pptx");
try {
    var firstSlide = presentation.getSlides().get_Item(0);
    var firstShape = firstSlide.getShapes().get_Item(0);
    if (java.instanceOf(firstShape, "com.aspose.slides.IPictureFrame")) {
        var pictureFrame = firstShape;
        try {
            var slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
            slideImage.save("slide_1_shape_1.png", aspose.slides.ImageFormat.Png);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} catch (e) {console.log(e);
} finally {
    presentation.dispose();
}
```

## **Wyodrębnij obrazy SVG z ramek obrazu**

Gdy prezentacja zawiera grafikę SVG umieszczoną wewnątrz kształtów [PictureFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pictureframe/), Aspose.Slides for Node.js via Java umożliwia pobranie oryginalnych obrazów wektorowych w pełnej jakości. Przeglądając kolekcję kształtów slajdu, możesz zidentyfikować każdy [PictureFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pictureframe/), sprawdzić, czy leżący pod spodem [PPImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ppimage/) zawiera treść SVG, a następnie zapisać ten obraz na dysku lub w strumieniu w natywnym formacie SVG.

Poniższy przykład kodu demonstruje, jak wyodrębnić obraz SVG z ramki obrazu:

```js
var presentation = new aspose.slides.Presentation("sample.pptx");

try {
    var slide = presentation.getSlides().get_Item(0);
    var shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
        const svgImage = shape.getPictureFormat().getPicture().getImage().getSvgImage();

        if (svgImage) {
            fs.writeFileSync("output.svg", svgImage.getSvgData());
        }
    }
} catch (e) {
    console.log(e);
} finally {
    presentation.dispose();
}
```

## **Uzyskaj przezroczystość obrazu**

Aspose.Slides pozwala odczytać efekt przezroczystości zastosowany do obrazu. Ten kod JavaScript prezentuje tę operację:

```javascript
var presentation = new aspose.slides.Presentation("Test.pptx");
var pictureFrame = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var i = 0; i < imageTransform.size(); i++) {
    var effect = imageTransform.get_Item(i);
    if (java.instanceOf(effect, "com.aspose.slides.IAlphaModulateFixed")) {
        var alphaModulateFixed = effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        console.log("Picture transparency: " + transparencyValue);
    }
}
```

## **Formatowanie ramki obrazu**

Aspose.Slides oferuje wiele opcji formatowania, które można zastosować do ramki obrazu. Korzystając z tych opcji, możesz zmodyfikować ramkę obrazu, aby spełniała konkretne wymagania.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).  
2. Pobierz odwołanie do slajdu przy użyciu jego indeksu.  
3. Utwórz obiekt [PPImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PPImage), dodając obraz do [ImagesCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ImageCollection) powiązanej z obiektem prezentacji, który zostanie użyty do wypełnienia kształtu.  
4. Określ szerokość i wysokość obrazu.  
5. Utwórz `PictureFrame` na podstawie szerokości i wysokości obrazu przy użyciu metody [addPictureFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) udostępnionej przez obiekt [Shapes](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ShapeCollection) powiązany ze wskazanym slajdem.  
6. Dodaj ramkę obrazu (zawierającą obraz) do slajdu.  
7. Ustaw kolor linii ramki obrazu.  
8. Ustaw szerokość linii ramki obrazu.  
9. Obróć ramkę obrazu, podając wartość dodatnią lub ujemną.  
   * Dodatnia wartość obraca obraz zgodnie z ruchem wskazówek zegara.  
   * Ujemna wartość obraca obraz przeciwnie do ruchu wskazówek zegara.  
10. Dodaj ramkę obrazu (zawierającą obraz) do slajdu.  
11. Zapisz zmodyfikowaną prezentację jako plik PPTX.  

Ten kod JavaScript demonstruje proces formatowania ramki obrazu:

```javascript
// Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
var pres = new aspose.slides.Presentation();
try {
    // Pobiera pierwszy slajd
    var sld = pres.getSlides().get_Item(0);
    // Tworzy instancję klasy Image
    var imgx = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "asp1.jpg")));
    // Dodaje ramkę obrazu o wysokości i szerokości równych obrazowi
    var pf = sld.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    // Stosuje pewne formatowanie do PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    // Zapisuje plik PPTX na dysku
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Wskazówka" color="primary" %}}

Aspose niedawno opracowało darmowy [Collage Maker](https://products.aspose.app/slides/pl/collage). Jeśli potrzebujesz [scalić obrazy JPG/JPEG](https://products.aspose.app/slides/pl/collage/jpg) lub PNG, [tworzyć siatki ze zdjęć](https://products.aspose.app/slides/pl/collage/photo-grid), możesz skorzystać z tej usługi. 

{{% /alert %}}

## **Dodaj obraz jako odnośnik**

Aby uniknąć dużych rozmiarów prezentacji, możesz dodać obrazy (lub wideo) poprzez odnośniki zamiast osadzania plików bezpośrednio w prezentacji. Ten kod JavaScript pokazuje, jak dodać obraz i wideo do placeholdera:

```javascript
var presentation = new aspose.slides.Presentation("input.pptx");
try {
    var shapesToRemove = java.newInstanceSync("java.util.ArrayList");
    var shapesCount = presentation.getSlides().get_Item(0).getShapes().size();
    for (var i = 0; i < shapesCount; i++) {
        var autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(i);
        if (autoShape.getPlaceholder() == null) {
            continue;
        }
        switch (autoShape.getPlaceholder().getType()) {
            case aspose.slides.PlaceholderType.Picture :
                var pictureFrame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), null);
                pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
                shapesToRemove.add(autoShape);
                break;
            case aspose.slides.PlaceholderType.Media :
                var videoFrame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), "");
                videoFrame.getPictureFormat().getPicture().setLinkPathLong("https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");
                videoFrame.setLinkPathLong("https://youtu.be/t_1LYZ102RA");
                shapesToRemove.add(autoShape);
                break;
        }
    }
    for (var i = 0; i < shapesToRemove.length; i++) {
        var shape = shapesToRemove.get_Item(i);
        presentation.getSlides().get_Item(0).getShapes().remove(shape);
    }
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Przytnij obraz**

Ten kod JavaScript pokazuje, jak przyciąć istniejący obraz na slajdzie:

```javascript
var pres = new aspose.slides.Presentation();
// Tworzy nowy obiekt obrazu
try {
    var picture;
    var image = aspose.slides.Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Dodaje ramkę obrazu do slajdu
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 100, 100, 420, 250, picture);
    // Przycina obraz (wartości procentowe)
    picFrame.getPictureFormat().setCropLeft(23.6);
    picFrame.getPictureFormat().setCropRight(21.5);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);
    // Zapisuje wynik
    pres.save(outPptxFile, aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Usuń przycięte obszary obrazu**

Jeśli chcesz usunąć przycięte obszary obrazu zawartego w ramce, możesz użyć metody [deletePictureCroppedAreas()](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) . Metoda zwraca przycięty obraz lub pierwotny obraz, jeśli przycinanie nie jest potrzebne.

Ten kod JavaScript demonstruje tę operację:

```javascript
var presentation = new aspose.slides.Presentation("PictureFrameCrop.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // Pobiera ramkę obrazu z pierwszego slajdu
    var picFrame = slide.getShapes().get_Item(0);
    // Usuwa przycięte obszary obrazu w ramce obrazu i zwraca przycięty obraz
    var croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();
    // Zapisuje wynik
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

{{% alert title="UWAGA" color="warning" %}} 

Metoda [deletePictureCroppedAreas()](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) dodaje przycięty obraz do kolekcji obrazów prezentacji. Jeśli obraz jest używany wyłącznie w przetwarzanej [PictureFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pictureframe/), takie rozwiązanie może zmniejszyć rozmiar prezentacji. W przeciwnym razie liczba obrazów w ostatecznej prezentacji wzrośnie.

Metoda konwertuje pliki metafile WMF/EMF na rastrowy obraz PNG w trakcie przycinania. 

{{% /alert %}}

## **Kompresuj obrazy**

Możesz skompresować obraz w prezentacji, używając metody [PictureFillFormat.compressImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-) . Metoda ta zmniejsza rozmiar obrazu w oparciu o rozmiar kształtu i określoną rozdzielczość, z opcją usunięcia przyciętych obszarów.

Działa analogicznie do funkcji PowerPoint **Format obrazu → Kompresuj obrazy → Rozdzielczość**.

Poniższe przykłady JavaScript pokazują, jak skompresować obraz w prezentacji, podając docelową rozdzielczość i opcjonalnie usuwając przycięte obszary:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // Skompresuj obraz z docelową rozdzielczością 150 DPI (rozdzielczość sieciowa) i usuń przycięte obszary.
    const result = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);

    // Sprawdź wynik kompresji.
    if (result) {
        console.log("Image successfully compressed.");
    } else {
        console.log("Image compression failed or no changes were necessary.");
    }

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Lub używając innej predefiniowanej wartości DPI:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // Skompresuj obraz do 96 DPI (rozdzielczość e-mail), usuwając przycięte obszary.
    pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi96);

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="UWAGA" color="warning" %}} 

Metoda konwertuje obraz do niższej rozdzielczości w oparciu o rozmiar kształtu i podane DPI. Przycięte regiony mogą być także usunięte w celu optymalizacji wielkości pliku.  
Jeśli obraz jest metafilem (WMF/EMF) lub SVG, kompresja nie zostanie zastosowana. Dla JPEG jakość jest zachowywana lub nieco obniżana w zależności od rozdzielczości, podobnie jak w PowerPoint.

{{% /alert %}}

## **Zablokuj proporcje obrazu**

Jeśli chcesz, aby kształt zawierający obraz zachował swój stosunek proporcji po zmianie wymiarów obrazu, możesz użyć metody [setAspectRatioLocked](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) do ustawienia opcji *Lock Aspect Ratio*.

Ten kod JavaScript pokazuje, jak zablokować proporcje kształtu:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var layout = pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Custom);
    var emptySlide = pres.getSlides().addEmptySlide(layout);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    var pictureFrame = emptySlide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 150, presImage.getWidth(), presImage.getHeight(), picture);
    // ustaw kształt, aby zachować proporcje podczas zmiany rozmiaru
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="UWAGA" color="warning" %}} 

Ustawienie *Lock Aspect Ratio* zachowuje tylko proporcje samego kształtu, a nie obrazu, który w nim się znajduje.

{{% /alert %}}

## **Użyj właściwości StretchOff**

Korzystając z metod [setStretchOffsetLeft](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetLeft-float-), [setStretchOffsetTop](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetTop--), [setStretchOffsetRight](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetRight--) i [setStretchOffsetBottom](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetBottom-float-) z klasy [PictureFillFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PictureFillFormat), możesz określić prostokąt wypełnienia.

Gdy rozciąganie jest określone dla obrazu, prostokąt źródłowy jest skalowany, aby pasował do zdefiniowanego prostokąta wypełnienia. Każda krawędź prostokąta wypełnienia jest definiowana jako procentowy offset od odpowiadającej krawędzi ramki ograniczającej kształt. Dodatni procent oznacza wcięcie, natomiast ujemny procent oznacza wystawienie na zewnątrz.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).  
2. Pobierz odwołanie do slajdu przy użyciu jego indeksu.  
3. Dodaj prostokąt `AutoShape`.  
4. Utwórz obraz.  
5. Ustaw typ wypełnienia kształtu.  
6. Ustaw tryb wypełnienia obrazu kształtu.  
7. Dodaj ustawiony obraz do wypełnienia kształtu.  
8. Określ offsety obrazu względem odpowiedniej krawędzi ramki kształtu.  
9. Zapisz zmodyfikowaną prezentację jako plik PPTX.  

Ten kod JavaScript demonstruje proces użycia właściwości StretchOff:

```javascript
// Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
var pres = new aspose.slides.Presentation();
try {
    // Pobiera pierwszy slajd
    var slide = pres.getSlides().get_Item(0);
    // Tworzy instancję klasy ImageEx
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Dodaje AutoShape ustawioną na prostokąt
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Ustawia typ wypełnienia kształtu
    aShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    // Ustawia tryb wypełnienia obrazu kształtu
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    // Ustawia obraz jako wypełnienie kształtu
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // Określa przesunięcia obrazu względem odpowiedniej krawędzi ramki kształtu
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    // Zapisuje plik PPTX na dysku
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Jak mogę dowiedzieć się, które formaty obrazów są obsługiwane dla PictureFrame?**

Aspose.Slides obsługuje zarówno obrazy rastrowe (PNG, JPEG, BMP, GIF itp.), jak i wektorowe (np. SVG) poprzez obiekt obrazu przypisany do [PictureFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pictureframe/). Lista wspieranych formatów zazwyczaj pokrywa się z możliwościami silnika konwersji slajdów i obrazów.

**Jak dodanie dziesiątek dużych obrazów wpłynie na rozmiar i wydajność pliku PPTX?**

Osadzanie dużych obrazów zwiększa rozmiar pliku i zużycie pamięci; linkowanie obrazów pomaga utrzymać niewielki rozmiar prezentacji, ale wymaga dostępności plików zewnętrznych. Aspose.Slides umożliwia dodawanie obrazów jako linków, aby zmniejszyć rozmiar pliku.

**Jak mogę zablokować obiekt obrazu przed przypadkowym przemieszczaniem lub zmianą rozmiaru?**

Użyj [shape locks](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pictureframe/getpictureframelock/) dla [PictureFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pictureframe/) (np. wyłącz ruch lub zmianę rozmiaru). Mechanizm blokady jest obsługiwany dla różnych typów kształtów, w tym [PictureFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pictureframe/).

**Czy integralność wektora SVG jest zachowywana przy eksportowaniu prezentacji do PDF/obrazów?**

Aspose.Slides umożliwia wyodrębnienie SVG z [PictureFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pictureframe/) jako oryginalnego wektora. Przy [eksportowaniu do PDF](/slides/pl/nodejs-java/convert-powerpoint-to-pdf/) lub [formatów rastrowych](/slides/pl/nodejs-java/convert-powerpoint-to-png/), wynik może być rasteryzowany w zależności od ustawień eksportu; fakt, że oryginalny SVG jest przechowywany jako wektor, potwierdzany jest zachowaniem funkcji wyodrębniania.