---
title: Zarządzanie ramkami obrazów w prezentacjach przy użyciu JavaScript
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
- przycięty obszar
- właściwość StretchOff
- formatowanie ramki obrazu
- właściwości ramki obrazu
- skala względna
- efekt obrazu
- proporcje
- przezroczystość obrazu
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dodaj ramki obrazu do prezentacji PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Node.js via Java. Usprawnij swój proces pracy i ulepsz projektowanie slajdów."
---
## **Wprowadzenie**

Ramka obrazu jest kształtem, który zawiera obraz — jest jak zdjęcie w ramce. 

Możesz dodać obraz do slajdu za pomocą ramki obrazu. W ten sposób możesz formatować obraz, formatując ramkę obrazu.

{{% alert  title="Tip" color="primary" %}} 

Aspose udostępnia darmowe konwertery — [JPEG do PowerPoint](https://products.aspose.app/slides/pl/import/jpg-to-ppt) i [PNG do PowerPoint](https://products.aspose.app/slides/pl/import/png-to-ppt) — które pozwalają szybko tworzyć prezentacje z obrazów. 

{{% /alert %}} 

## **Utworzenie ramki obrazu**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).  
2. Uzyskaj referencję do slajdu za pomocą jego indeksu.  
3. Utwórz obiekt `PPImage`, dodając obraz do [ImagesCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ImageCollection) powiązanej z obiektem prezentacji, który będzie używany do wypełnienia kształtu.  
4. Określ szerokość i wysokość obrazu.  
5. Utwórz [PictureFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PictureFrame) na podstawie szerokości i wysokości obrazu, korzystając z metody `addPictureFrame` udostępnionej przez obiekt kształtu powiązany z odwołanym slajdem.  
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
    // Dodaje ramkę obrazu o takiej samej wysokości i szerokości jak obraz
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

Ramki obrazu umożliwiają szybkie tworzenie slajdów prezentacji na podstawie obrazów. Gdy połączysz ramkę obrazu z opcjami zapisu Aspose.Slides, możesz manipulować operacjami wejścia/wyjścia, aby konwertować obrazy z jednego formatu na inny.

## **Utworzenie ramki obrazu ze skalą względną**

Poprzez zmianę skalowania względnego obrazu możesz utworzyć bardziej złożoną ramkę obrazu. 

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).  
2. Uzyskaj referencję do slajdu za pomocą jego indeksu.  
3. Dodaj obraz do kolekcji obrazów prezentacji.  
4. Utwórz obiekt [PPImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PPImage), dodając obraz do [ImagesCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ImageCollection) powiązanej z obiektem prezentacji, który będzie używany do wypełnienia kształtu.  
5. Określ względną szerokość i wysokość obrazu w ramce obrazu.  
6. Zapisz zmodyfikowaną prezentację jako plik PPTX.  

Ten kod JavaScript pokazuje, jak utworzyć ramkę obrazu ze skalą względną:

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
    // Ustawia względną skalę wysokości i szerokości
    pf.setRelativeScaleHeight(0.8);
    pf.setRelativeScaleWidth(1.35);
    // Zapisuje plik PPTX na dysku
    pres.save("RectPicFrame.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Wyodrębnianie obrazów rastrowych z ramek obrazu**

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

## **Wyodrębnianie obrazów SVG z ramek obrazu**

Kiedy prezentacja zawiera grafikę SVG umieszczoną wewnątrz kształtów [PictureFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pictureframe/), Aspose.Slides for Node.js via Java pozwala pobrać oryginalne obrazy wektorowe w pełnej jakości. Przeglądając kolekcję kształtów slajdu, możesz zidentyfikować każdy [PictureFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pictureframe/), sprawdzić, czy podlegający mu [PPImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ppimage/) zawiera treść SVG, a następnie zapisać ten obraz na dysk lub do strumienia w natywnym formacie SVG.

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

## **Uzyskanie przezroczystości obrazu**

Aspose.Slides umożliwia uzyskanie efektu przezroczystości zastosowanego do obrazu. Ten kod JavaScript demonstruje operację:

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

## **Uzyskanie jasności i kontrastu obrazu**

Aspose.Slides umożliwia uzyskanie efektu jasności i kontrastu zastosowanego do obrazu. Klasa [Luminance](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/luminance/) reprezentuje tę transformację obrazu.

Ten kod JavaScript demonstruje, jak uzyskać ustawienia jasności i kontrastu z ramki obrazu:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");

try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const pictureFrame = shape;

    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    for (let i = 0; i < imageTransform.size(); i++) {
        const effect = imageTransform.get_Item(i);
        if (java.instanceOf(effect, "com.aspose.slides.Luminance")) {
            const luminance = effect.getEffective();
            const brightness = luminance.getBrightness();
            const contrast = luminance.getContrast();

            console.log("Brightness: " + brightness);
            console.log("Contrast: " + contrast);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Formatowanie ramki obrazu**

Aspose.Slides oferuje wiele opcji formatowania, które można zastosować do ramki obrazu. Korzystając z tych opcji, możesz dostosować ramkę obrazu do konkretnych wymagań.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).  
2. Uzyskaj referencję do slajdu za pomocą jego indeksu.  
3. Utwórz obiekt [PPImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PPImage), dodając obraz do [ImagesCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ImageCollection) powiązanej z obiektem prezentacji, który będzie używany do wypełnienia kształtu.  
4. Określ szerokość i wysokość obrazu.  
5. Utwórz `PictureFrame` na podstawie szerokości i wysokości obrazu, korzystając z metody [addPictureFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) udostępnionej przez obiekt [Shapes](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ShapeCollection) powiązany z odwołanym slajdem.  
6. Dodaj ramkę obrazu (zawierającą obraz) do slajdu.  
7. Ustaw kolor linii ramki obrazu.  
8. Ustaw szerokość linii ramki obrazu.  
9. Obróć ramkę obrazu, podając wartość dodatnią lub ujemną.  
   * Wartość dodatnia obraca obraz zgodnie z ruchem wskazówek zegara.  
   * Wartość ujemna obraca obraz przeciwnie do ruchu wskazówek zegara.  
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
    // Zastosowuje formatowanie do PictureFrameEx
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

{{% alert title="Tip" color="primary" %}}

Aspose niedawno opracował [darmowy Collage Maker](https://products.aspose.app/slides/pl/collage). Jeśli potrzebujesz [połączyć obrazy JPG/JPEG](https://products.aspose.app/slides/pl/collage/jpg) lub PNG, [tworzyć siatki ze zdjęć](https://products.aspose.app/slides/pl/collage/photo-grid), możesz skorzystać z tej usługi. 

{{% /alert %}}

## **Dodawanie obrazu jako linku**

Aby zmniejszyć rozmiar prezentacji, możesz dodawać obrazy (lub filmy) za pomocą linków zamiast osadzać pliki bezpośrednio w prezentacji. Ten kod JavaScript pokazuje, jak dodać obraz i wideo do miejsca wstawiania:

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

## **Kadrowanie obrazu**

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

## **Usuwanie przyciętych obszarów obrazu w ramce**

Jeśli chcesz usunąć przycięte obszary obrazu zawartego w ramce, możesz użyć metody [deletePictureCroppedAreas()](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--). Metoda ta zwraca przycięty obraz lub oryginalny obraz, jeśli przycinanie nie jest konieczne.

Ten kod JavaScript demonstruje operację:

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

{{% alert title="NOTE" color="warning" %}} 

Metoda [deletePictureCroppedAreas()](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/picturefillformat/#deletePictureCroppedAreas--) dodaje przycięty obraz do kolekcji obrazów prezentacji. Jeśli obraz jest używany wyłącznie w przetwarzanym [PictureFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pictureframe/), takie rozwiązanie może zmniejszyć rozmiar prezentacji. W przeciwnym razie liczba obrazów w wynikowej prezentacji się zwiększy.

Metoda konwertuje pliki metafile WMF/EMF na rastrowe obrazy PNG w trakcie przycinania. 

{{% /alert %}}

## **Kompresja obrazów**

Możesz skompresować obraz w prezentacji, używając metody [PictureFillFormat.compressImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/picturefillformat/#compressImage-boolean-int-). Metoda ta zmniejsza rozmiar obrazu w oparciu o rozmiar kształtu i podaną rozdzielczość, z opcją usunięcia przyciętych obszarów.

Działa podobnie jak funkcja PowerPoint **Format obrazu → Kompresuj obrazy → Rozdzielczość**.

Poniższe przykłady JavaScript demonstrują, jak skompresować obraz w prezentacji, określając docelową rozdzielczość i opcjonalnie usuwając przycięte obszary:

```javascript
const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().get_Item(0);

    // Kompresuje obraz z docelową rozdzielczością 150 DPI (rozwiązanie internetowe) i usuwa przycięte obszary.
    const result = pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi150);

    // Sprawdza wynik kompresji.
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

    // Kompresuje obraz do 96 DPI (rozdzielczość e‑mail), usuwając przycięte obszary.
    pictureFrame.getPictureFormat().compressImage(true, aspose.slides.PicturesCompression.Dpi96);

    presentation.save("CompressedImage.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

Metoda konwertuje obraz do niższej rozdzielczości w zależności od rozmiaru kształtu i podanego DPI. Przycięte regiony mogą być również usuwane w celu optymalizacji rozmiaru pliku.  
Jeśli obraz jest metafilem (WMF/EMF) lub SVG, kompresja nie zostanie zastosowana. Jakość JPEG jest zachowywana lub nieco zmniejszana w zależności od rozdzielczości, podobnie jak w PowerPoint przy obsłudze wysokiej rozdzielczości JPEG.

{{% /alert %}}

## **Zablokowanie proporcji**

Jeśli chcesz, aby kształt zawierający obraz zachował proporcje po zmianie wymiarów obrazu, możesz użyć metody [setAspectRatioLocked](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pictureframelock/#setAspectRatioLocked-boolean-) do ustawienia opcji *Lock Aspect Ratio*.

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
    // ustaw kształt tak, aby zachować proporcje przy zmianie rozmiaru
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="NOTE" color="warning" %}} 

Ustawienie *Lock Aspect Ratio* zachowuje tylko proporcje kształtu, a nie obrazu, który on zawiera.

{{% /alert %}}

## **Użycie właściwości StretchOff**

Korzystając z metod [setStretchOffsetLeft](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetLeft-float-), [setStretchOffsetTop](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetTop--), [setStretchOffsetRight](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetRight--) i [setStretchOffsetBottom](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PictureFillFormat#setStretchOffsetBottom-float-) klasy [PictureFillFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/PictureFillFormat), możesz określić prostokąt wypełnienia.

Gdy rozciąganie jest określone dla obrazu, źródłowy prostokąt jest skalowany, aby pasował do podanego prostokąta wypełnienia. Każda krawędź prostokąta wypełnienia jest definiowana przez procentowy offset od odpowiadającej krawędzi ramki ograniczającej kształt. Dodatni procent określa wcięcie, a ujemny – wystawienie.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).  
2. Uzyskaj referencję do slajdu za pomocą jego indeksu.  
3. Dodaj prostokąt `AutoShape`.  
4. Utwórz obraz.  
5. Ustaw typ wypełnienia kształtu.  
6. Ustaw tryb wypełnienia obrazu kształtu.  
7. Dodaj ustawiony obraz do wypełnienia kształtu.  
8. Określ offsety obrazu względem odpowiadających krawędzi ramki ograniczającej kształt.  
9. Zapisz zmodyfikowaną prezentację jako plik PPTX.  

Ten kod JavaScript demonstruje proces, w którym używana jest właściwość StretchOff:

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
    // Dodaje AutoShape ustawiony na prostokąt
    var aShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 300);
    // Ustawia typ wypełnienia kształtu
    aShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    // Ustawia tryb wypełnienia obrazu kształtu
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    // Ustawia obraz wypełniający kształt
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // Określa offsety obrazu względem odpowiedniej krawędzi ramki ograniczającej kształt
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

**Jak mogę sprawdzić, które formaty obrazów są obsługiwane dla PictureFrame?**

Aspose.Slides obsługuje zarówno obrazy rastrowe (PNG, JPEG, BMP, GIF itp.), jak i obrazy wektorowe (np. SVG) poprzez obiekt obrazu przypisany do [PictureFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pictureframe/). Lista obsługiwanych formatów zazwyczaj pokrywa się z możliwościami silnika konwersji slajdów i obrazów.

**Jak dodawanie dziesiątek dużych obrazów wpływa na rozmiar i wydajność pliku PPTX?**

Osadzanie dużych obrazów zwiększa rozmiar pliku i zużycie pamięci; łączenie obrazów pomaga utrzymać mniejszy rozmiar prezentacji, ale wymaga, aby pliki zewnętrzne pozostały dostępne. Aspose.Slides umożliwia dodawanie obrazów jako linków, aby zmniejszyć rozmiar pliku.

**Jak mogę zablokować obiekt obrazu przed przypadkowym przemieszczaniem lub zmianą rozmiaru?**

Użyj [shape locks](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pictureframe/getpictureframelock/) dla [PictureFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pictureframe/) (np. wyłączając możliwość przemieszczania lub zmiany rozmiaru). Mechanizm blokady jest wspierany dla różnych typów kształtów, w tym [PictureFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pictureframe/).

**Czy wierność wektora SVG jest zachowywana przy eksportowaniu prezentacji do PDF/obrazów?**

Aspose.Slides pozwala wyodrębnić SVG z [PictureFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pictureframe/) jako oryginalny wektor. Przy [eksportowaniu do PDF](/slides/pl/nodejs-java/convert-powerpoint-to-pdf/) lub [formatów rastrowych](/slides/pl/nodejs-java/convert-powerpoint-to-png/), wynik może być rasteryzowany w zależności od ustawień eksportu; fakt, że oryginalny SVG jest przechowywany jako wektor, potwierdza zachowanie po wyodrębnieniu.