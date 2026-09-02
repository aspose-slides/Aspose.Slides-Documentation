---
title: Optymalizacja zarządzania obrazami w prezentacjach przy użyciu JavaScript
linktitle: Zarządzaj obrazami
type: docs
weight: 10
url: /pl/nodejs-java/image/
keywords:
- dodaj obraz
- dodaj obraz
- zastąp obraz
- kolekcja obrazów
- ramka obrazu
- obraz powiązany
- tło
- dodaj PNG
- dodaj JPG
- dodaj SVG
- SVG na kształty
- zewnętrzne zasoby SVG
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak dodawać, ponownie wykorzystywać, łączyć, zastępować i zarządzać obrazami rastrowymi oraz SVG w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Node.js via Java."
---
## **Wprowadzenie**

Aspose.Slides dla Node.js via Java zapewnia kilka sposobów pracy z obrazami, przy czym każdy ma inny cel. Możesz przechowywać obraz w prezentacji, wyświetlać go w ramce obrazu, używać jako tła slajdu, łączyć się z zewnętrznym obrazem, zastąpić współdzielony zasób obrazu lub konwertować zawartość SVG na edytowalne kształty.

Ten artykuł koncentruje się na zasobach obrazów i ich użyciu w całej prezentacji. Informacje o przycinaniu, przezroczystości, efektach, rozciąganiu i innych formatach stosowanych do pojedynczej ramki obrazu znajdziesz w sekcji [Picture Frame](/slides/pl/nodejs-java/picture-frame/).

## **Zrozumienie modelu obrazu**

Poniższe pojęcia API są ze sobą ściśle powiązane, ale nie zamienne:

- [kolekcja obrazów prezentacji](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/imagecollection/) przechowuje zasoby obrazów używane w prezentacji. Użyj [ImageCollection.addImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/imagecollection/), aby dodać dane obrazu i uzyskać zasób [PPImage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ppimage/).
- [Ramka obrazu](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/pictureframe/) jest kształtem wyświetlającym obraz na slajdzie, układzie lub szablonie. Użyj [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shapecollection/), aby umieścić zasób obrazu na slajdzie.
- Tło slajdu używa obrazu jako części wypełnienia slajdu, a nie jako kształtu. Dlatego nie zachowuje się jak ramka obrazu.
- [PPImage.replaceImage] zastępuje zasób obrazu. Jeśli kilka elementów prezentacji używa tego zasobu, wszystkie korzystają z zamiany.
- Konwersja SVG do kształtów tworzy edytowalne kształty slajdu. Po konwersji zawartość nie jest już zarządzana jako jeden zasób obrazu.

Typowy przepływ pracy wygląda więc następująco: dodaj dane obrazu do kolekcji obrazów, otrzymaj [PPImage], a następnie użyj tego zasobu w jednej lub kilku ramach obrazu lub wypełnieniach.

## **Dodaj osadzony obraz**

Aby wstawić lokalny obraz, wczytaj plik, dodaj go do kolekcji obrazów i utwórz ramkę obrazu, która używa zwróconego zasobu [PPImage].

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) {
            sourceImage.dispose();
        }
    }

    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, image);

    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Obraz dodany w ten sposób jest osadzony w prezentacji, więc wynikowy plik nie zależy od dostępności oryginalnego pliku obrazu.

### **Dodaj obraz z sieci**

Kiedy obraz jest dostępny przez HTTP lub HTTPS, pobierz jego bajty, dodaj je do kolekcji obrazów prezentacji i użyj zwróconego zasobu obrazu w taki sam sposób jak lokalny obraz.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const http = require("http");
const https = require("https");
const java = require("java");

function downloadBytes(url) {
    return new Promise((resolve, reject) => {
        const client = url.startsWith("https:") ? https : http;
        client.get(url, (response) => {
            if (response.statusCode < 200 || response.statusCode >= 300) {
                response.resume();
                reject(new Error(`HTTP ${response.statusCode}`));
                return;
            }

            const chunks = [];
            response.on("data", (chunk) => chunks.push(chunk));
            response.on("end", () => resolve(Buffer.concat(chunks)));
        }).on("error", reject);
    });
}

(async () => {
    const imageData = await downloadBytes("https://example.com/image.png");
    const javaBytes = java.newArray("byte", Array.from(imageData));

    const presentation = new aspose.slides.Presentation();
    try {
        const image = presentation.getImages().addImage(javaBytes);
        const slide = presentation.getSlides().get_Item(0);
        slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, image);

        presentation.save("presentation-from-web.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
})();
```

W długotrwałych aplikacjach należy ponownie wykorzystywać klienta HTTP lub strategię zarządzania połączeniami odpowiednią dla aplikacji, zamiast wielokrotnie tworzyć niepotrzebną infrastrukturę sieciową. Należy także weryfikować zdalne URL‑e, rozmiary odpowiedzi i typy treści, gdy źródło nie jest zaufane.

## **Ponowne użycie obrazów na wielu slajdach**

Jeśli ten sam obraz jest potrzebny więcej niż raz, dodaj go do prezentacji jednorazowo i ponownie użyj zwróconego [PPImage] przy tworzeniu kolejnych ramek obrazu. Zapobiega to wielokrotnemu ładowaniu tych samych danych źródłowych i wyraźnie określa zależność między współdzielonym zasobem obrazu a jego użyciem.

W przypadku grafik, które mają pojawiać się automatycznie na wielu slajdach, takich jak logo firmy, rozważ umieszczenie ramki obrazu na [szablonie slajdu](/slides/pl/nodejs-java/slide-master/) lub układzie zamiast dodawania równoważnego kształtu do każdego slajdu.

## **Użyj obrazu jako tła slajdu**

Obraz tła jest przypisywany do wypełnienia slajdu; nie jest dodawany jako kształt ramki obrazu. Jest to przydatne, gdy obraz ma pokrywać tło slajdu i nie powinien być manipulowany jako zwykły obiekt slajdu.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("background.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) {
            sourceImage.dispose();
        }
    }

    const backgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    slide.getBackground().setType(backgroundType);

    const fillType = java.newByte(aspose.slides.FillType.Picture);
    slide.getBackground().getFillFormat().setFillType(fillType);

    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image);

    presentation.save("background-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dodatkowe opcje tła, w tym tła szablonów i układów, znajdziesz w sekcji [Presentation Background](/slides/pl/nodejs-java/presentation-background/).

## **Obrazy osadzone i obrazy powiązane**

Obrazy osadzone i powiązane mają różne kompromisy dotyczące przenośności i rozmiaru pliku:

- **Obraz osadzony:** dane obrazu są przechowywane wewnątrz prezentacji. Prezentacja jest samodzielna, ale rozmiar pliku obejmuje dane obrazu.
- **Obraz powiązany:** prezentacja przechowuje ścieżkę lub URL do zewnętrznego obrazu. To może zmniejszyć rozmiar prezentacji, ale zewnętrzny zasób musi pozostać dostępny podczas otwierania lub renderowania prezentacji.

Obraz powiązany można utworzyć, przypisując zewnętrzną ścieżkę lub URL za pomocą [Picture.setLinkPathLong] zamiast osadzania danych obrazu.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 320, 180, null);
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png");

    presentation.save("linked-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Używaj obrazów powiązanych tylko wtedy, gdy środowisko wdrożeniowe może niezawodnie uzyskać dostęp do zewnętrznego zasobu. Dla prezentacji, które muszą działać offline lub być przenoszone między systemami, obrazy osadzone są zazwyczaj bezpieczniejsze.

## **Praca z obrazami SVG**

SVG jest formatem wektorowym, więc może być przydatny dla ikon, diagramów i innych grafik, które powinny skalować się bez utraty szczegółów typowej dla obrazów rastrowych. Aspose.Slides obsługuje SVG zarówno jako zasób obrazu, jak i jako źródło edytowalnych kształtów slajdu.

### **Dodaj SVG jako obraz**

Utwórz [SvgImage], dodaj go do kolekcji obrazów i umieść powstały zasób obrazu w ramce obrazu.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const svgContent = fs.readFileSync("icon.svg", "utf8");
    const svgImage = new aspose.slides.SvgImage(svgContent);

    const image = presentation.getImages().addImage(svgImage);
    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 200, image);

    presentation.save("svg-image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Pliki SVG z zasobami zewnętrznymi**

Plik SVG może odwoływać się do zewnętrznych obrazów, arkuszy stylów lub czcionek. W takich przypadkach [SvgImage] udostępnia konstruktory przyjmujące [ExternalResourceResolver] oraz bazowy URI. Resolver może mapować względny URI na dozwolony bezwzględny URI i zwrócić strumień żądanego zasobu.

Resolver udostępnia zewnętrzne zasoby podczas przetwarzania SVG przez Aspose.Slides, ale nie przepisuje SVG do dokumentu samodzielnego. Jeśli SVG ma pozostać przenośny, osadź wymagane zasoby bezpośrednio w SVG, np. przy użyciu URI `data:` dla powiązanych obrazów.

Gdy pliki SVG pochodzą z niepewnych źródeł, ogranicz schematy, lokalizacje plików i hosty, do których resolver może uzyskać dostęp. Rozwiązania sieciowe powinny również stosować limit czasu, ograniczenia rozmiaru odpowiedzi i weryfikację treści.

### **Konwertuj SVG na edytowalne kształty**

Aspose.Slides może konwertować SVG na grupę edytowalnych kształtów slajdu, podobnie jak odpowiadająca komenda w PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

Użyj przeciążenia [ShapeCollection.addGroupShape], które przyjmuje obraz SVG, aby wykonać konwersję.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const svgContent = fs.readFileSync("diagram.svg", "utf8");
    const svgImage = new aspose.slides.SvgImage(svgContent);

    const slideSize = presentation.getSlideSize().getSize();
    const slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, slideSize.getWidth(), slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Używaj konwersji SVG na kształty, gdy poszczególne elementy wektorowe muszą być edytowane jako kształty PowerPoint. Jeśli SVG ma być tylko wyświetlany, pozostawienie go jako obrazu jest prostsze i unika tworzenia wielu oddzielnych kształtów.

## **Zastąp istniejący zasób obrazu**

Użyj [PPImage.replaceImage], gdy chcesz zastąpić istniejący zasób obrazu. Jest to szczególnie przydatne w przypadku współdzielonych grafik, takich jak logotypy.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const imageToReplace = presentation.getImages().get_Item(0);

    const replacementImage = aspose.slides.Images.fromFile("new-logo.png");
    try {
        imageToReplace.replaceImage(replacementImage);
    } finally {
        if (replacementImage != null) {
            replacementImage.dispose();
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Jeśli wiele ramek obrazu, tła, szablonów lub układów używa tego samego zasobu obrazu, jego zastąpienie aktualizuje wszystkie te użycia. Jeśli ma się zmienić tylko jedną ramkę, przypisz do niej inny obraz zamiast zastępować współdzielony zasób.

[PPImage.replaceImage] oferuje także przeciążenia przyjmujące tablicę bajtów lub inny [PPImage].

## **Praktyczne wskazówki zarządzania obrazami**

### **Kontrola rozmiaru prezentacji**

Duże obrazy rastrowe mogą niepotrzebnie zwiększyć rozmiar prezentacji. Używaj obrazów źródłowych o wymiarach odpowiednich do przeznaczonego rozmiaru wyświetlania, w miarę możliwości ponownie wykorzystuj współdzielone zasoby obrazów i unikaj osadzania wielokrotnych kopii tej samej grafiki w pełnej rozdzielczości.

W przypadku obrazów rastrowych już umieszczonych w ramkach obrazu, [PictureFillFormat.compressImage] może zmniejszyć dane obrazu zgodnie z wybraną rozdzielczością i ustawieniami przycięcia. Jest to przetwarzanie ramki obrazu, a nie zarządzanie kolekcją obrazów, więc zobacz [Picture Frame] po informacje o powiązanych operacjach formatowania.

### **Wybór między treścią osadzoną a powiązaną**

Osadzanie sprawia, że prezentacja jest przenośna, ponieważ wszystkie niezbędne dane obrazu przemieszczają się wraz z plikiem. Łączenie może zmniejszyć rozmiar pliku, ale wprowadza zależność zewnętrzną. Używaj linków tylko wtedy, gdy taka zależność jest akceptowalna i stabilna.

### **Ponowne użycie współdzielonego brandingu**

W przypadku wielokrotnych logotypów, znaków wodnych lub grafik dekoracyjnych użyj jednego zasobu obrazu i ponownie go wykorzystaj. Jeśli grafika jest częścią projektu prezentacji, a nie treści slajdu, umieść ją na szablonie lub układzie, aby była dziedziczona przez odpowiednie slajdy.

### **Utrzymaj zasoby SVG przenośne**

Samodzielny SVG jest łatwiejszy do przenoszenia i renderowania w sposób spójny niż SVG zależny od plików zewnętrznych lub zasobów sieciowych. Gdy to możliwe, osadź wymagane zasoby przed importem SVG. Konwertuj SVG na kształty tylko wtedy, gdy poszczególne elementy wektorowe muszą być edytowane.

### **Użyj nowoczesnego, wieloplatformowego API obrazu**

W nowym kodzie Node.js via Java używaj API Aspose.Slides [IImage] i [Images] zamiast starszego publicznego API opartego na `java.awt.image.BufferedImage`. Zobacz [Modern API] po wskazówki dotyczące migracji.

Formaty WMF i EMF wymagają specjalnego traktowania. Gdy są one przekazywane przez [IImage], [ImageCollection.addImage] konwertuje metaplik na rastrową reprezentację PNG przed wstawieniem. Jeśli zachowanie danych metapliku jest istotne, użyj przeciążenia [ImageCollection.addImage] opartego na strumieniu. Generowanie treści EMF z arkuszy kalkulacyjnych lub innych produktów to odrębny proces integracji i wykracza poza zakres tego artykułu.

## **FAQ**

**Jaka jest różnica między kolekcją obrazów a ramką obrazu?**

Kolekcja obrazów przechowuje wielokrotnego użytku zasoby obrazów. Ramka obrazu jest kształtem slajdu, który wyświetla jeden z tych zasobów i zapewnia formatowanie specyficzne dla obrazu, takie jak przycinanie i efekty.

**Jaki jest najlepszy sposób na zastąpienie tego samego logo wszędzie?**

Jeśli logo jest już współdzielone jako jeden zasób obrazu, zastąp ten zasób za pomocą [PPImage.replaceImage]. Dla brandingu obejmującego całą prezentację, umieszczenie logo na szablonie lub układzie może również zmniejszyć duplikowaną treść slajdów.

**Dlaczego obraz powiązany znika na innym komputerze?**

Obraz powiązany zależy od swojego zewnętrznego pliku lub URL. Jeśli ten zasób nie jest dostępny z innego komputera, obraz powiązany może być niedostępny. Osadź obraz, gdy prezentacja musi być samodzielna.

**Czy wstawiony SVG można edytować jako kształty PowerPoint?**

Tak. Konwertuj SVG przy użyciu [ShapeCollection.addGroupShape]; powstała grupa zawiera edytowalne kształty slajdu, a nie jeden obraz SVG.

**Jak mogę utrzymać prezentacje z wieloma obrazami mniejsze?**

Ponownie wykorzystuj współdzielone zasoby obrazów, unikaj niepotrzebnie dużych źródeł rastrowych, kompresuj odpowiednie obrazy rastrowe w razie potrzeby, umieszczaj powtarzający się branding na szablonach lub układach i używaj obrazów powiązanych tylko wtedy, gdy zależność zewnętrzna jest dopuszczalna.