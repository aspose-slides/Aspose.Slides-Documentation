---
title: Optymalizuj zarządzanie obrazami w prezentacjach przy użyciu JavaScript
linktitle: Zarządzaj obrazami
type: docs
weight: 10
url: /pl/nodejs-java/image/
keywords:
- dodaj obraz
- dodaj zdjęcie
- dodaj bitmapę
- zamień obraz
- zamień zdjęcie
- z sieci
- tło
- dodaj PNG
- dodaj JPG
- dodaj SVG
- zewnętrzne zasoby SVG
- resolver SVG
- powiązane obrazy SVG
- czcionki SVG
- dodaj EMF
- dodaj WMF
- dodaj TIFF
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Usprawnij zarządzanie obrazami w PowerPoint i OpenDocument za pomocą Aspose.Slides dla Node.js via Java, optymalizując wydajność i automatyzując przepływ pracy."
---
## **Wprowadzenie**

Obrazy sprawiają, że prezentacje są bardziej angażujące i atrakcyjne wizualnie. W Microsoft PowerPoint możesz wstawiać obrazy na slajdy z plików, internetu lub innych źródeł. Podobnie Aspose.Slides pozwala dodawać obrazy do slajdów prezentacji na kilka sposobów.

{{% alert  title="Porada" color="primary" %}} 

Aspose udostępnia bezpłatne konwertery—[JPEG to PowerPoint](https://products.aspose.app/slides/pl/import/jpg-to-ppt) i [PNG to PowerPoint](https://products.aspose.app/slides/pl/import/png-to-ppt)—pozwalające szybko tworzyć prezentacje z obrazów. 

{{% /alert %}} 

{{% alert title="Informacja" color="info" %}}

Jeśli chcesz dodać obraz jako ramkę obrazu — szczególnie jeśli zamierzasz zmieniać jego rozmiar, stosować efekty lub używać innych standardowych opcji formatowania — zobacz [Picture Frame](/slides/pl/nodejs-java/picture-frame/). 

{{% /alert %}} 

{{% alert title="Uwaga" color="warning" %}}

Możesz konwertować obrazy z jednego formatu na inny. Zobacz następujące strony: konwertuj [image to JPG](https://products.aspose.com/slides/pl/nodejs-java/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/pl/nodejs-java/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/pl/nodejs-java/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/pl/nodejs-java/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/pl/nodejs-java/conversion/png-to-svg/), oraz [SVG to PNG](https://products.aspose.com/slides/pl/nodejs-java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides obsługuje obrazy w popularnych formatach, takich jak JPEG, PNG, BMP, GIF i inne. 

## **Dodawanie obrazów przechowywanych lokalnie do slajdów**

Możesz dodać jeden lub więcej obrazów przechowywanych na komputerze do slajdu prezentacji. Poniższy przykładowy kod JavaScript pokazuje, jak dodać obraz do slajdu:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);

    let picture;
    const image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    slide.getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Dodawanie obrazów z sieci do slajdów**

Jeśli obraz, który chcesz dodać do slajdu, nie jest przechowywany na komputerze, możesz dodać go bezpośrednio z internetu. 

Poniższy przykładowy kod JavaScript pokazuje, jak dodać obraz z sieci do slajdu:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);

    const imageUrl = java.newInstanceSync("java.net.URL", "[REPLACE WITH URL]");
    const inputStream = imageUrl.openStream();
    try {
        let picture;
        const image = aspose.slides.Images.fromStream(inputStream);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) {
                image.dispose();
            }
        }

        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    } finally {
        if (inputStream != null) {
            inputStream.close();
        }
    }

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Dodawanie obrazów do mistrzów slajdów**

Mistrz slajdu przechowuje i kontroluje informacje, takie jak motyw i układ slajdów, które go używają. Gdy dodasz obraz do mistrza slajdu, obraz pojawia się na każdym slajdzie opartym na tym mistrzu. 

Poniższy przykładowy kod JavaScript pokazuje, jak dodać obraz do mistrza slajdu:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const pres = new aspose.slides.Presentation();
try {
    const slide = pres.getSlides().get_Item(0);
    const masterSlide = slide.getLayoutSlide().getMasterSlide();

    let picture;
    const image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }

    masterSlide.getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Dodawanie obrazów jako tło slajdu**

Możesz użyć obrazu jako tła jednego lub kilku slajdów. Szczegóły znajdziesz w *[Setting Images as Backgrounds for Slides](/slides/pl/nodejs-java/presentation-background/#setting-images-as-background-for-slides)*.

## **Dodawanie SVG do prezentacji**

Treść SVG można dodać do prezentacji przy użyciu klasy [SvgImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/svgimage/). Uzyskany obiekt obrazu SVG może następnie zostać dodany do kolekcji obrazów prezentacji i użyty do utworzenia ramki obrazu.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const svgContent =
    "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" +
    "    <rect width='320' height='180' fill='#4F81BD'/>" +
    "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" +
    "</svg>";

const presentation = new aspose.slides.Presentation();
try {
    const svgImage = new aspose.slides.SvgImage(svgContent);
    const image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle,
        20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("self-contained-svg.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Importowanie treści SVG z zasobami zewnętrznymi**

Pliki SVG eksportowane z narzędzi projektowych, edytorów diagramów, systemów ikon i procesów internetowych mogą odwoływać się do zasobów przechowywanych poza dokumentem SVG. Na przykład SVG może zawierać link do obrazu, taki jak `images/photo.png`, wartość CSS `url(...)` lub adres URL czcionki.

Aby zaimportować taką treść SVG, należy dostarczyć resolver zasobów zewnętrznych i przekazać go, wraz z bazowym URI, do odpowiedniego konstruktora [SvgImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/svgimage/). Bazowy URI określa lokalizację dokumentu SVG i jest używany do rozwiązywania linków względnych.

Klasa `SvgImage` udostępnia dostęp do informacji o zaimportowanym SVG:

- `getSvgContent()` zwraca kod SVG jako ciąg znaków.  
- `getSvgData()` zwraca zawartość SVG jako tablicę bajtów.  
- `getBaseUri()` zwraca bazowy URI używany do linków względnych.  
- `getExternalResourceResolver()` zwraca resolver przypisany do obrazu SVG.  

### **Implementacja resolvera zasobów zewnętrznych**

Resolver posiada dwie metody:

- `resolveUri` łączy bazowy URI i względny link zasobu i zwraca absolutny URI. Zwróć `null`, gdy link nie może zostać rozwiązany lub nie jest dozwolony.  
- `getEntity` zwraca czytelny strumień Java dla absolutnego URI zasobu. Zwróć `null`, gdy zasób jest nieobecny, zablokowany lub niedostępny. Ewentualny strumień zastępczy może być również zwrócony, gdy ma to sens.

Poniższy pomocnik tworzy resolver, który ładuje powiązane zasoby wyłącznie z dozwolonego lokalnego katalogu. Zasoby sieciowe i ścieżki poza dozwolonym katalogiem są blokowane. Opcjonalny obraz zastępczy jest zwracany dla nierozwiązanych linków obrazów.

```javascript
const fs = require("fs");
const path = require("path");
const java = require("java");
const { fileURLToPath, pathToFileURL } = require("url");

function isInsideAllowedRoot(resourcePath, allowedRoot) {
    const relativePath = path.relative(allowedRoot, resourcePath);

    return relativePath === "" ||
        (relativePath !== ".." &&
         !relativePath.startsWith(".." + path.sep) &&
         !path.isAbsolute(relativePath));
}

function isImageFile(filePath) {
    const extension = path.extname(filePath).toLowerCase();
    return [".png", ".jpg", ".jpeg", ".gif", ".bmp"].includes(extension);
}

function createLocalSvgResourceResolver(allowedRoot, fallbackImageData) {
    const normalizedRoot = path.resolve(allowedRoot);

    return java.newProxy("com.aspose.slides.IExternalResourceResolver", {
        resolveUri: function(baseUri, relativeUri) {
            if (baseUri == null || baseUri.trim() === "" ||
                    relativeUri == null || relativeUri.trim() === "") {
                return null;
            }

            try {
                const absoluteAddress = new URL(relativeUri, baseUri);

                // Ten resolver celowo zezwala tylko na pliki lokalne.
                if (absoluteAddress.protocol !== "file:") {
                    return null;
                }

                const resourcePath = path.resolve(fileURLToPath(absoluteAddress));
                if (!isInsideAllowedRoot(resourcePath, normalizedRoot)) {
                    return null;
                }

                return pathToFileURL(resourcePath).href;
            } catch (e) {
                return null;
            }
        },

        getEntity: function(absoluteUri) {
            try {
                const resourceUrl = new URL(absoluteUri);
                if (resourceUrl.protocol !== "file:") {
                    return null;
                }

                const resourcePath = path.resolve(fileURLToPath(resourceUrl));
                if (!isInsideAllowedRoot(resourcePath, normalizedRoot)) {
                    return null;
                }

                if (fs.existsSync(resourcePath)) {
                    return java.newInstanceSync("java.io.FileInputStream", resourcePath);
                }

                // Użyj zastępczego tylko dla zasobów obrazu. Zwrócenie strumienia obrazu
                // dla brakującej czcionki lub arkusza stylów nie byłoby prawidłowe.
                if (fallbackImageData != null && isImageFile(resourcePath)) {
                    const javaBytes = java.newArray("byte", Array.from(fallbackImageData));
                    return java.newInstanceSync("java.io.ByteArrayInputStream", javaBytes);
                }
            } catch (e) {
                return null;
            }

            return null;
        }
    });
}
```

### **Rozwiązywanie powiązanych zasobów podczas importu SVG**

Załóżmy, że `assets/diagram.svg` zawiera względne odwołanie, takie jak:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Poniższy przykład JavaScript przekazuje URI pliku SVG jako bazowy URI i dostarcza niestandardowy resolver. Resolver przekształca względny link obrazu w absolutny URI i zwraca strumień zawierający powiązany zasób, podczas gdy Aspose.Slides przetwarza SVG.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");
const { pathToFileURL } = require("url");

const svgFilePath = path.resolve("assets", "diagram.svg");
const assetDirectory = path.dirname(svgFilePath);
const svgContent = fs.readFileSync(svgFilePath, "utf8");

// Bazowy URI reprezentuje lokalizację dokumentu SVG.
const baseUri = pathToFileURL(svgFilePath).href;

let fallbackImageData = null;
const fallbackImagePath = path.join(assetDirectory, "fallback.png");
if (fs.existsSync(fallbackImagePath)) {
    fallbackImageData = fs.readFileSync(fallbackImagePath);
}

const resolver = createLocalSvgResourceResolver(assetDirectory, fallbackImageData);
const svgImage = new aspose.slides.SvgImage(svgContent, resolver, baseUri);

// SvgImage udostępnia zawartość źródłową, dane binarne, bazowy URI i resolver.
const importedContent = svgImage.getSvgContent();
const importedData = svgImage.getSvgData();
const importedBaseUri = svgImage.getBaseUri();
const importedResolver = svgImage.getExternalResourceResolver();

const presentation = new aspose.slides.Presentation();
try {
    const image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
        aspose.slides.ShapeType.Rectangle,
        20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("svg-with-linked-resources.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Klasa `SvgImage` udostępnia również przeciążenia przyjmujące dane SVG jako tablicę bajtów oraz metody fabryczne oparte na strumieniach, wraz z resolverem zasobów zewnętrznych i bazowym URI.

{{% alert title="Ważne" color="warning" %}}

Resolver zasobów udostępnia zasoby zewnętrzne podczas przetwarzania i renderowania SVG przez Aspose.Slides. Nie modyfikuje on oryginalnego kodu SVG ani nie osadza automatycznie rozwiązanych zasobów w nim.

Gdy obraz SVG zostaje dodany do kolekcji obrazów prezentacji, plik PPTX może zawierać zarówno oryginalną reprezentację SVG, jak i rastrowy obraz zastępczy. Powiązany zasób może pojawić się w wygenerowanym obrazie zastępczym, podczas gdy względny link taki jak `images/photo.png` pozostaje niezmieniony w przechowywanym SVG. Aplikacja renderująca natywną reprezentację SVG może więc pominąć powiązaną treść, gdy pierwotny zasób zewnętrzny jest niedostępny.

{{% /alert %}}

### **Utworzenie przenośnego obrazu SVG**

Aby utworzyć obraz SVG niezależny od plików zewnętrznych, przed utworzeniem `SvgImage` należy uczynić SVG samodzielnym. Na przykład zamień linki do obrazów na adresy URI typu `data:`, zawierające dane obrazu:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Po osadzeniu wszystkich wymaganych zasobów w treści SVG, utwórz `SvgImage`, dodaj go do kolekcji obrazów prezentacji i wstaw do ramki obrazu, jak pokazano w poprzednim przykładzie.

### **Obsługa brakujących lub zablokowanych zasobów**

Zwróć `null` z `resolveUri`, gdy URI zasobu jest nieprawidłowy, zabroniony lub nie może zostać rozwiązany. Zwróć `null` z `getEntity`, gdy zasób nie może być odczytany. Aspose.Slides kontynuuje przetwarzanie SVG bez tego zasobu, gdy jest to możliwe.

Strumień zastępczy może być zwrócony dla brakującego zasobu, ale jego zawartość musi być zgodna z żądanym typem zasobu. Na przykład zwróć strumień obrazu tylko dla brakującego obrazu, nie dla czcionki czy arkusza stylów.

{{% alert title="Bezpieczeństwo" color="warning" %}}

Nie rozwiązuj dowolnych ścieżek plików ani nieograniczonych adresów URL z niepewnych plików SVG. Ogranicz dozwolone schematy, katalogi i hosty. Dla zasobów sieciowych stosuj także limity czasu połączenia, ograniczenia rozmiaru odpowiedzi i walidację treści.

{{% /alert %}}

## **Konwersja SVG na zestaw kształtów**

Aspose.Slides może konwertować SVG na zestaw kształtów, podobnie jak odpowiednia funkcjonalność w PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Funkcjonalność ta jest udostępniana przez przeciążenie metody [addGroupShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ShapeCollection#addGroupShape-aspose.slides.ISvgImage-float-float-float-float-) klasy [ShapeCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ShapeCollection), które przyjmuje obiekt obrazu SVG jako pierwszy argument.

Poniższy przykładowy kod JavaScript pokazuje, jak użyć tej metody do konwersji pliku SVG na zestaw kształtów:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// Nazwa pliku źródłowego SVG.
const svgFileName = "sample.svg";

// Nazwa pliku wyjściowej prezentacji.
const outPptxPath = "presentation.pptx";

// Utwórz nową prezentację.
const presentation = new aspose.slides.Presentation();
try {
    // Odczytaj zawartość pliku SVG.
    const svgContent = java.newArray("byte", Array.from(fs.readFileSync(svgFileName)));

    // Utwórz obiekt SvgImage.
    const svgImage = new aspose.slides.SvgImage(svgContent);

    // Pobierz rozmiar slajdu.
    const slideSize = presentation.getSlideSize().getSize();

    // Konwertuj obraz SVG na grupę kształtów i skaluj go do rozmiaru slajdu.
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
        svgImage, 0.0, 0.0, slideSize.getWidth(), slideSize.getHeight());

    // Zapisz prezentację w formacie PPTX.
    presentation.save(outPptxPath, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Dodawanie obrazów jako EMF do slajdów**

Aspose.Slides for Node.js via Java umożliwia generowanie obrazów EMF z arkuszy Excel przy użyciu Aspose.Cells i dodawanie ich do slajdów prezentacji.

Poniższy przykładowy kod JavaScript pokazuje, jak to zrobić:

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const book = java.newInstanceSync("aspose.cells.Workbook", "chart.xlsx");
const sheet = book.getWorksheets().get(0);

const options = java.newInstanceSync("aspose.cells.ImageOrPrintOptions");
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(java.getStaticFieldValue("ImageType", "EMF"));

// Zapisz skoroszyt do strumienia.
const sr = java.newInstanceSync("SheetRender", sheet, options);
const pres = new aspose.slides.Presentation();
try {
    pres.getSlides().removeAt(0);

    for (let j = 0; j < sr.getPageCount(); j++) {
        const emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // Dodaj plik w niezmienionej formie, aby obraz pozostał wektorowym EMF zamiast zostać zrastrowany.
        let picture;
        const imageStream = java.newInstanceSync("java.io.FileInputStream", emfSheetName);
        try {
            picture = pres.getImages().addImage(imageStream);
        } finally {
            imageStream.close();
        }

        const slide = pres.getSlides().addEmptySlide(
            pres.getLayoutSlides().getByType(aspose.slides.SlideLayoutType.Blank));
        slide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            0,
            0,
            pres.getSlideSize().getSize().getWidth(),
            pres.getSlideSize().getSize().getHeight(),
            picture);
    }

    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Zastępowanie obrazów w kolekcji obrazów**

Aspose.Slides pozwala zastępować obrazy przechowywane w kolekcji obrazów prezentacji, w tym obrazy używane przez kształty slajdów. W tej sekcji opisano kilka sposobów aktualizacji obrazów w kolekcji. Możesz zastąpić obraz, używając surowych danych bajtowych, instancji [IImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/iimage/) lub innego obrazu już istniejącego w kolekcji.

Postępuj zgodnie z poniższymi krokami:

1. Załaduj plik prezentacji zawierający obrazy przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).  
2. Wczytaj nowy obraz z pliku do tablicy bajtów.  
3. Zastąp docelowy obraz nowym obrazem przy użyciu tablicy bajtów.  
4. W drugim podejściu wczytaj obraz do obiektu [IImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/iimage/) i zastąp docelowy obraz tym obiektem.  
5. W trzecim podejściu zastąp docelowy obraz obrazem, który już istnieje w kolekcji obrazów prezentacji.  
6. Zapisz zmodyfikowaną prezentację jako plik PPTX.  

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    // Pierwszy sposób.
    const imageData = java.newArray("byte", Array.from(fs.readFileSync("image0.jpeg")));
    let oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // Drugi sposób.
    const newImage = aspose.slides.Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) {
            newImage.dispose();
        }
    }

    // Trzeci sposób.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // Zapisz prezentację do pliku.
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Informacja" color="info" %}}

Korzystając z bezpłatnego konwertera Aspose [Text to GIF](https://products.aspose.app/slides/pl/text-to-gif), możesz łatwo animować tekst i tworzyć GIFy z tekstu. 

{{% /alert %}}

## **FAQ**

**Czy oryginalna rozdzielczość obrazu pozostaje niezmieniona po wstawieniu?**

Tak. Piksele źródłowe są zachowane, ale ostateczny wygląd zależy od tego, jak [picture](/slides/pl/nodejs-java/picture-frame/) jest skalowany na slajdzie i od ewentualnej kompresji przy zapisie.

**Jak najlepiej zastąpić to samo logo na dziesiątkach slajdów jednocześnie?**

Umieść logo w slajdzie mistrza lub układzie i zastąp je w kolekcji obrazów prezentacji — zmiany będą propagowane do wszystkich elementów wykorzystujących ten zasób.

**Czy wstawiony SVG może zostać przekonwertowany na edytowalne kształty?**

Tak. SVG można zamienić na grupę kształtów, po czym poszczególne części stają się edytowalne przy użyciu standardowych właściwości kształtów.

**Jak ustawić obraz jako tło wielu slajdów jednocześnie?**

[Przypisz obraz jako tło](/slides/pl/nodejs-java/presentation-background/) na slajdzie mistrza lub odpowiednim układzie — wszystkie slajdy korzystające z tego mistrza/układu odziedziczą tło.

**Jak zapobiec nadmiernemu rozmiarowi prezentacji z powodu dużej liczby obrazów?**

Używaj jednego zasobu obrazu zamiast duplikatów, wybieraj rozsądne rozdzielczości, stosuj kompresję przy zapisie i, w miarę możliwości, przechowuj powtarzalne grafiki w mistrzu.