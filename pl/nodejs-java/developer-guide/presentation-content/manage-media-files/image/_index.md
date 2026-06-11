---
title: Optymalizacja zarządzania obrazami w prezentacjach przy użyciu JavaScript
linktitle: Zarządzanie obrazami
type: docs
weight: 10
url: /pl/nodejs-java/image/
keywords:
- dodaj obraz
- dodaj obrazek
- dodaj bitmapę
- zastąp obraz
- zastąp obrazek
- z internetu
- tło
- dodaj PNG
- dodaj JPG
- dodaj SVG
- dodaj EMF
- dodaj WMF
- dodaj TIFF
- PowerPoint
- OpenDocument
- prezentacja
- EMF
- SVG
- Node.js
- JavaScript
- Aspose.Slides
description: "Usprawnij zarządzanie obrazami w PowerPoint i OpenDocument przy użyciu JavaScript i Aspose.Slides dla Node.js, optymalizując wydajność i automatyzując swój przepływ pracy."
---
## **Wprowadzenie**

Obrazy sprawiają, że prezentacje są bardziej angażujące i interesujące. W programie Microsoft PowerPoint możesz wstawiać obrazy z pliku, internetu lub innych lokalizacji na slajdy. Podobnie, Aspose.Slides umożliwia dodawanie obrazów do slajdów w twoich prezentacjach przy użyciu różnych metod. 

{{% alert  title="Tip" color="primary" %}} 

Aspose udostępnia bezpłatne konwertery—[JPEG to PowerPoint](https://products.aspose.app/slides/pl/import/jpg-to-ppt) i [PNG to PowerPoint](https://products.aspose.app/slides/pl/import/png-to-ppt)—które pozwalają szybko tworzyć prezentacje z obrazów. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Jeśli chcesz dodać obraz jako obiekt ramki — szczególnie jeśli zamierzasz używać standardowych opcji formatowania, aby zmienić jego rozmiar, dodać efekty i tak dalej — zobacz [Picture Frame](https://docs.aspose.com/slides/pl/nodejs-java/picture-frame/).

{{% /alert %}} 

Aspose.Slides obsługuje operacje na obrazach w tych popularnych formatach: JPEG, PNG, GIF i inne. 

## **Dodawanie obrazów przechowywanych lokalnie do slajdów**

Możesz dodać jeden lub kilka obrazów z komputera na slajd w prezentacji. Ten przykładowy kod w JavaScript pokazuje, jak dodać obraz do slajdu:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Dodawanie obrazów ze strumienia do slajdów**

Jeśli obraz, który chcesz dodać do slajdu, nie jest dostępny na twoim komputerze, możesz dodać go bezpośrednio z internetu. 

Ten przykładowy kod pokazuje, jak dodać obraz z internetu do slajdu w JavaScript:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Uzyskuje dostęp do pierwszego slajdu
    var sld = pres.getSlides().get_Item(0);
    // Ładuje plik Excel do strumienia
    var readStream = fs.readFileSync("book1.xlsx");
    var byteArray = Array.from(readStream);
    // Tworzy obiekt danych do osadzenia
    var dataInfo = new aspose.slides.OleEmbeddedDataInfo(java.newArray("byte", byteArray), "xlsx");
    // Dodaje kształt ramki obiektu Ole
    var oleObjectFrame = sld.getShapes().addOleObjectFrame(0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), dataInfo);
    // Zapisuje plik PPTX na dysku
    pres.save("OleEmbed_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Dodawanie obrazów do masterów slajdów**

Master slajdu to górny slajd, który przechowuje i kontroluje informacje (motyw, układ itp.) o wszystkich slajdach pod nim. Dlatego, gdy dodasz obraz do mastera slajdu, obraz ten pojawi się na każdym slajdzie pod tym masterem. 

Ten przykładowy kod w JavaScript pokazuje, jak dodać obraz do mastera slajdu:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var masterSlide = slide.getLayoutSlide().getMasterSlide();
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    masterSlide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Dodawanie obrazów jako tło slajdu**

Możesz zdecydować się użyć obrazu jako tła dla konkretnego slajdu lub kilku slajdów. W takim przypadku zobacz *[Ustawianie obrazów jako tła slajdów](https://docs.aspose.com/slides/pl/nodejs-java/presentation-background/#setting-images-as-background-for-slides)*.

## **Dodawanie SVG do prezentacji**

Możesz dodać lub wstawić dowolny obraz do prezentacji używając metody [addPictureFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ShapeCollection#addPictureFrame-int-float-float-float-float-aspose.slides.PPImage-) należącej do klasy [ShapeCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ShapeCollection). 

Aby utworzyć obiekt obrazu na podstawie obrazu SVG, możesz zrobić to w ten sposób:

1. Utwórz obiekt SvgImage, aby wstawić go do ImageShapeCollection
2. Utwórz obiekt PPImage z ISvgImage
3. Utwórz obiekt PictureFrame przy użyciu klasy PPImage

Ten przykładowy kod pokazuje, jak wdrożyć powyższe kroki, aby dodać obraz SVG do prezentacji:
```javascript
// Utwórz instancję klasy Presentation reprezentującej plik PPTX
var pres = new aspose.slides.Presentation();
try {
    var svgContent = java.newInstanceSync("java.lang.String", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg")));
    var svgImage = new aspose.slides.SvgImage(svgContent);
    var ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Konwertowanie SVG do zestawu kształtów**

Konwersja SVG do zestawu kształtów w Aspose.Slides jest podobna do funkcji PowerPoint służącej do pracy z obrazami SVG:

![PowerPoint Popup Menu](img_01_01.png)

Funkcjonalność jest zapewniona przez jedną z przeciążeń metody [addGroupShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) klasy [ShapeCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ShapeCollection), która przyjmuje obiekt [SvgImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SvgImage) jako pierwszy argument.

Ten przykładowy kod pokazuje, jak użyć opisanej metody do konwersji pliku SVG na zestaw kształtów:

```javascript
// Utwórz nową prezentację
var presentation = new aspose.slides.Presentation();
try {
    // Odczytaj zawartość pliku SVG
    var svgContent = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "image.svg"));
    // Utwórz obiekt SvgImage
    var svgImage = new aspose.slides.SvgImage(svgContent);
    // Pobierz rozmiar slajdu
    var slideSize = presentation.getSlideSize().getSize();
    // Konwertuj obraz SVG na grupę kształtów, skalując go do rozmiaru slajdu
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());
    // Zapisz prezentację w formacie PPTX
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Dodawanie obrazów jako EMF w slajdach**

Aspose.Slides dla Node.js via Java pozwala generować obrazy EMF z arkuszy Excel i dodawać je jako EMF w slajdach przy użyciu Aspose.Cells. 

Ten przykładowy kod pokazuje, jak wykonać opisane zadanie:

```javascript
var book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
var sheet = book.getWorksheets().get(0);
var options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));
// Save the workbook to stream
var sr = java.newInstanceSync("SheetRender", sheet, options);
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);
    var EmfSheetName = "";
    for (var j = 0; j < sr.getPageCount(); j++) {
        EmfSheetName = ((("test" + sheet.getName()) + " Page") + (j + 1)) + ".out.emf";
        sr.toImage(j, EmfSheetName);
        var picture;
        var image = aspose.slides.Images.fromFile(EmfSheetName);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }
        var slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank));
        var m = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, pres.getSlideSize().getSize().getWidth(), pres.getSlideSize().getSize().getHeight(), picture);
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Zastępowanie obrazów w kolekcji obrazów**

Aspose.Slides pozwala zastępować obrazy przechowywane w kolekcji obrazów prezentacji (w tym te używane przez kształty slajdów). Ta sekcja pokazuje kilka podejść do aktualizacji obrazów w kolekcji. API oferuje proste metody zastąpienia obrazu przy użyciu surowych danych bajtowych, instancji [IImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/iimage/), lub innego obrazu już istniejącego w kolekcji.

Postępuj zgodnie z poniższymi krokami:

1. Załaduj plik prezentacji zawierający obrazy przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
2. Załaduj nowy obraz z pliku do tablicy bajtów.
3. Zastąp docelowy obraz nowym obrazem, używając tablicy bajtów.
4. W drugim podejściu załaduj obraz do obiektu [IImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/iimage/) i zastąp docelowy obraz tym obiektem.
5. W trzecim podejściu zastąp docelowy obraz obrazem, który już istnieje w kolekcji obrazów prezentacji.
6. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```js
// Utwórz instancję klasy Presentation reprezentującej plik prezentacji.
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // Pierwszy sposób.
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // Drugi sposób.
    const newImage = aspose.slides.Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // Trzeci sposób.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // Zapisz prezentację do pliku.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

Korzystając z bezpłatnego konwertera Aspose [Text to GIF](https://products.aspose.app/slides/pl/text-to-gif) możesz łatwo animować teksty, tworzyć GIF-y z tekstów itp. 

{{% /alert %}}

## **FAQ**

**Czy oryginalna rozdzielczość obrazu pozostaje niezmieniona po wstawieniu?**

Tak. Piksele źródłowe są zachowane, ale ostateczny wygląd zależy od tego, jak [picture](/slides/pl/nodejs-java/picture-frame/) jest skalowany na slajdzie oraz od ewentualnej kompresji przy zapisie.

**Jaki jest najlepszy sposób na zastąpienie tego samego logo na dziesiątkach slajdów jednocześnie?**

Umieść logo na masterze slajdu lub układzie i zastąp je w kolekcji obrazów prezentacji — zmiany zostaną rozpropagowane do wszystkich elementów korzystających z tego zasobu.

**Czy wstawiony SVG może zostać przekonwertowany na edytowalne kształty?**

Tak. Możesz przekonwertować SVG na grupę kształtów, po czym poszczególne części stają się edytowalne przy użyciu standardowych właściwości kształtów.

**Jak ustawić obraz jako tło dla wielu slajdów jednocześnie?**

[Ustaw obraz jako tło](/slides/pl/nodejs-java/presentation-background/) na masterze slajdu lub odpowiednim układzie — wszystkie slajdy korzystające z tego mastera/układu odziedziczą tło.

**Jak zapobiec „rozwijaniu się” prezentacji z powodu dużej liczby obrazów?**

Używaj jednego zasobu obrazu zamiast duplikatów, wybieraj rozsądne rozdzielczości, stosuj kompresję przy zapisie i przechowuj powtarzalne grafiki w masterze, gdy to właściwe.