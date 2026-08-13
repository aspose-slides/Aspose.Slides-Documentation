---
title: Optymalizacja zarządzania obrazami w prezentacjach na Androidzie
linktitle: Zarządzanie obrazami
type: docs
weight: 10
url: /pl/androidjava/image/
keywords:
- dodaj obraz
- dodaj zdjęcie
- dodaj bitmapę
- zastąp obraz
- zastąp zdjęcie
- z internetu
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
- Android
- Java
- Aspose.Slides
description: "Usprawnij zarządzanie obrazami w PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Androida w Java, optymalizując wydajność i automatyzując swój przepływ pracy."
---
## **Wprowadzenie**

Obrazy sprawiają, że prezentacje są bardziej angażujące i atrakcyjne wizualnie. W Microsoft PowerPoint możesz wstawiać obrazy na slajdy z plików, internetu lub innych źródeł. Podobnie Aspose.Slides pozwala dodawać obrazy do slajdów prezentacji na kilka sposobów.

{{% alert  title="Tip" color="info" %}} 
Aspose udostępnia darmowe konwertery—[JPEG to PowerPoint](https://products.aspose.app/slides/pl/import/jpg-to-ppt) i [PNG to PowerPoint](https://products.aspose.app/slides/pl/import/png-to-ppt)—które pozwalają szybko tworzyć prezentacje z obrazów. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Jeśli chcesz dodać obraz jako ramkę zdjęcia — szczególnie jeśli planujesz zmienić jego rozmiar, zastosować efekty lub użyć innych standardowych opcji formatowania — zobacz [Picture Frame](/slides/pl/androidjava/picture-frame/). 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
Możesz konwertować obrazy z jednego formatu na inny. Zobacz następujące strony: konwertuj [image to JPG](https://products.aspose.com/slides/pl/androidjava/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/pl/androidjava/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/pl/androidjava/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/pl/androidjava/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/pl/androidjava/conversion/png-to-svg/), oraz [SVG to PNG](https://products.aspose.com/slides/pl/androidjava/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides obsługuje obrazy w popularnych formatach, takich jak JPEG, PNG, BMP, GIF i inne. 

## **Dodawanie obrazów przechowywanych lokalnie do slajdów**

Możesz dodać jeden lub więcej obrazów przechowywanych na komputerze do slajdu prezentacji. Poniższy kod przykładu w języku Java pokazuje, jak dodać obraz do slajdu:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Dodawanie obrazów z internetu do slajdów**

Jeśli obraz, który chcesz dodać do slajdu, nie jest przechowywany na twoim komputerze, możesz dodać go bezpośrednio z internetu. 

Poniższy kod przykładu w języku Java pokazuje, jak dodać obraz z internetu do slajdu:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.URL;
import java.net.URLConnection;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    URL imageUrl = new URL("[REPLACE WITH URL]");
    URLConnection connection = imageUrl.openConnection();
    InputStream inputStream = connection.getInputStream();

    ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
    try {
        byte[] buffer = new byte[1024];
        int read;

        while ((read = inputStream.read(buffer, 0, buffer.length)) != -1) {
            outputStream.write(buffer, 0, read);
        }

        outputStream.flush();

        IPPImage image = pres.getImages().addImage(outputStream.toByteArray());
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    } finally {
        if (inputStream != null) inputStream.close();
        outputStream.close();
    }

    pres.save("pres.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **Dodawanie obrazów do masterów slajdów**

Master slajdu przechowuje i kontroluje informacje, takie jak motyw i układ slajdów, które go używają. Gdy dodasz obraz do mastera slajdu, obraz pojawia się na każdym slajdzie opartym na tym masterze. 

Poniższy kod przykładu w języku Java pokazuje, jak dodać obraz do mastera slajdu:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IMasterSlide masterSlide = slide.getLayoutSlide().getMasterSlide();

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    masterSlide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Dodawanie obrazów jako tło slajdów**

Możesz użyć obrazu jako tła jednego lub kilku slajdów. Szczegóły znajdziesz w *[Ustawianie obrazów jako tła slajdów](/slides/pl/androidjava/presentation-background/#setting-images-as-background-for-slides)*.

## **Dodawanie SVG do prezentacji**

Zawartość SVG można dodać do prezentacji przy użyciu klasy [SvgImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/svgimage/). Uzyskany obiekt [ISvgImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isvgimage/) może następnie zostać dodany do kolekcji obrazów prezentacji i użyty do stworzenia ramki obrazu. 

Poniższy przykład w języku Java importuje samodzielny ciąg SVG. Wszystkie obrazy, style i inne zasoby użyte w tym SVG są osadzone bezpośrednio w zawartości SVG.

```java
import com.aspose.slides.*;

String svgContent =
        "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" +
        "    <rect width='320' height='180' fill='#4F81BD'/>" +
        "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" +
        "</svg>";

Presentation presentation = new Presentation();
try {
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("self-contained-svg.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Importowanie zawartości SVG z zasobami zewnętrznymi**

Pliki SVG wyeksportowane z narzędzi projektowych, edytorów diagramów, systemów ikon oraz potoków internetowych mogą odwoływać się do zasobów przechowywanych poza dokumentem SVG. Na przykład SVG może zawierać odnośnik do obrazu, taki jak `images/photo.png`, wartość CSS `url(...)` lub adres URL czcionki. 

Aby zaimportować taką zawartość SVG, utwórz implementację interfejsu [IExternalResourceResolver](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iexternalresourceresolver/) i przekaż ją, wraz z bazowym URI, do odpowiedniego konstruktora [SvgImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/svgimage/). Bazowy URI określa lokalizację dokumentu SVG i jest używany do rozwiązywania względnych odnośników. 

Interfejs [ISvgImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isvgimage/) zapewnia dostęp do informacji o zaimportowanym SVG:

- `getSvgContent()` zwraca znacznik SVG jako ciąg znaków. 
- `getSvgData()` zwraca zawartość SVG jako tablicę bajtów. 
- `getBaseUri()` zwraca bazowy URI używany dla odnośników względnych. 
- `getExternalResourceResolver()` zwraca resolver przypisany do obrazu SVG. 

### **Implementacja resolvera zasobów zewnętrznych**

Resolver posiada dwie metody:

- `resolveUri` łączy bazowy URI i względny odnośnik zasobu oraz zwraca bezwzględny URI. Zwróć `null`, gdy odnośnik nie może zostać rozwiązany lub nie jest dozwolony. 
- `getEntity` zwraca strumień do odczytu dla bezwzględnego URI zasobu. Zwróć `null`, gdy zasób jest brakujący, zablokowany lub niedostępny. W razie potrzeby można również zwrócić strumień zapasowy. 

Poniższy resolver ładuje powiązane zasoby wyłącznie z dozwolonego lokalnego katalogu. Zasoby sieciowe i ścieżki poza dozwolonym katalogiem są blokowane. Opcjonalny obraz zastępczy jest zwracany dla nie rozwiązanych odnośników do obrazów. 

```java
import com.aspose.slides.ExternalResourceResolver;

import java.io.ByteArrayInputStream;
import java.io.InputStream;
import java.net.URI;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

class LocalSvgResourceResolver extends ExternalResourceResolver {
    private final Path allowedRoot;
    private final byte[] fallbackImageData;

    public LocalSvgResourceResolver(String allowedRoot, byte[] fallbackImageData) {
        this.allowedRoot = Paths.get(allowedRoot).toAbsolutePath().normalize();
        this.fallbackImageData = fallbackImageData;
    }

    @Override
    public String resolveUri(String baseUri, String relativeUri) {
        if (baseUri == null || baseUri.trim().isEmpty() ||
                relativeUri == null || relativeUri.trim().isEmpty()) {
            return null;
        }

        try {
            URI baseAddress = URI.create(baseUri);
            URI absoluteAddress = baseAddress.resolve(relativeUri);

            // Ten resolver celowo zezwala tylko na pliki lokalne.
            if (!"file".equalsIgnoreCase(absoluteAddress.getScheme())) {
                return null;
            }

            Path resourcePath = Paths.get(absoluteAddress).toAbsolutePath().normalize();
            if (!isInsideAllowedRoot(resourcePath)) {
                return null;
            }

            return resourcePath.toUri().toString();
        } catch (Exception e) {
            return null;
        }
    }

    @Override
    public InputStream getEntity(String absoluteUri) {
        try {
            URI resourceUri = URI.create(absoluteUri);
            if (!"file".equalsIgnoreCase(resourceUri.getScheme())) {
                return null;
            }

            Path resourcePath = Paths.get(resourceUri).toAbsolutePath().normalize();
            if (!isInsideAllowedRoot(resourcePath)) {
                return null;
            }

            if (Files.exists(resourcePath)) {
                return Files.newInputStream(resourcePath);
            }

            // Użyj zasobu zastępczego tylko dla zasobów obrazów. Zwrócenie strumienia obrazu
            // dla brakującej czcionki lub arkusza stylów nie byłoby prawidłowe.
            if (fallbackImageData != null && isImageFile(resourcePath)) {
                return new ByteArrayInputStream(fallbackImageData);
            }
        } catch (Exception e) {
            return null;
        }

        return null;
    }

    private boolean isInsideAllowedRoot(Path resourcePath) {
        return resourcePath.normalize().startsWith(allowedRoot);
    }

    private static boolean isImageFile(Path path) {
        String fileName = path.getFileName().toString().toLowerCase(Locale.ROOT);

        return fileName.endsWith(".png") ||
                fileName.endsWith(".jpg") ||
                fileName.endsWith(".jpeg") ||
                fileName.endsWith(".gif") ||
                fileName.endsWith(".bmp");
    }
}
```

### **Rozwiązywanie powiązanych zasobów podczas importu SVG**

Załóżmy, że `assets/diagram.svg` zawiera względne odwołanie, takie jak:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Poniższy przykład w języku Java przekazuje URI pliku SVG jako bazowy URI i dostarcza własny resolver. Resolver konwertuje względny odnośnik do obrazu na bezwzględny URI i zwraca strumień zawierający powiązany zasób, podczas gdy Aspose.Slides przetwarza SVG.

```java
import com.aspose.slides.*;

import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path svgFilePath = Paths.get("assets", "diagram.svg").toAbsolutePath().normalize();
Path assetDirectory = svgFilePath.getParent();
String svgContent = new String(Files.readAllBytes(svgFilePath), StandardCharsets.UTF_8);

// Bazowy URI określa lokalizację dokumentu SVG.
String baseUri = svgFilePath.toUri().toString();

byte[] fallbackImageData = null;
Path fallbackImagePath = assetDirectory.resolve("fallback.png");
if (Files.exists(fallbackImagePath)) {
    fallbackImageData = Files.readAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory.toString(), fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage udostępnia treść źródłową, dane binarne, bazowy URI oraz resolver.
String importedContent = svgImage.getSvgContent();
byte[] importedData = svgImage.getSvgData();
String importedBaseUri = svgImage.getBaseUri();
IExternalResourceResolver importedResolver = svgImage.getExternalResourceResolver();

Presentation presentation = new Presentation();
try {
    IPPImage image = presentation.getImages().addImage(svgImage);

    presentation.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 20, 20, image.getWidth(), image.getHeight(), image);

    presentation.save("svg-with-linked-resources.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Klasa `SvgImage` oferuje również przeciążenia, które przyjmują dane SVG jako tablicę bajtów lub strumień wejściowy, wraz z resolverem zasobów zewnętrznych i bazowym URI.

{{% alert title="Important" color="warning" %}}
Resolver zasobów udostępnia zasoby zewnętrzne podczas przetwarzania i renderowania SVG przez Aspose.Slides. Nie modyfikuje oryginalnego znacznika SVG ani nie osadza automatycznie rozwiązanych zasobów w nim.

Gdy `ISvgImage` zostanie dodany do kolekcji obrazów prezentacji, plik PPTX może zawierać zarówno oryginalną reprezentację SVG, jak i rastrowy obraz zastępczy. Powiązany zasób może pojawić się w wygenerowanym obrazie zastępczym, podczas gdy względny odnośnik, taki jak `images/photo.png`, pozostaje niezmieniony w przechowywanym SVG. Aplikacja renderująca natywną reprezentację SVG może więc pominąć powiązaną zawartość, gdy oryginalny zasób zewnętrzny jest niedostępny.
{{% /alert %}}

### **Utworzenie przenośnego obrazu SVG**

Aby stworzyć obraz SVG, który nie zależy od zewnętrznych plików, spraw, by SVG był samodzielny przed utworzeniem `SvgImage`. Na przykład zamień powiązane adresy URL obrazów na URI `data:`, które zawierają dane obrazu:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Po osadzeniu wszystkich wymaganych zasobów w zawartości SVG, utwórz `SvgImage`, dodaj go do kolekcji obrazów prezentacji i wstaw do ramki obrazu, jak pokazano w poprzednim przykładzie.

### **Obsługa brakujących lub zablokowanych zasobów**

Zwróć `null` z `resolveUri`, gdy URI zasobu jest nieprawidłowy, zabroniony lub nie może zostać rozwiązany. Zwróć `null` z `getEntity`, gdy nie można odczytać zasobu. Aspose.Slides kontynuuje przetwarzanie SVG bez tego zasobu, jeśli to możliwe.

Strumień zastępczy może być zwrócony dla brakującego zasobu, ale jego zawartość musi być zgodna z żądanym typem zasobu. Na przykład zwróć strumień obrazu tylko w przypadku brakującego obrazu, nie dla czcionki ani arkusza stylów.

{{% alert title="Security" color="warning" %}}
Nie rozwiązuj dowolnych ścieżek plików ani nieograniczonych adresów URL sieciowych z niezweryfikowanych plików SVG. Ogranicz dozwolone schematy, katalogi i hosty. Dla zasobów sieciowych zastosuj także limity czasu połączenia, ograniczenia rozmiaru odpowiedzi oraz walidację zawartości.
{{% /alert %}}

## **Konwersja SVG na zestaw kształtów**

Aspose.Slides może konwertować SVG na zestaw kształtów, podobnie jak odpowiadająca funkcjonalność w PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Funkcjonalność ta jest dostarczana przez przeciążenie metody [addGroupShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) interfejsu [IShapeCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IShapeCollection), które przyjmuje obiekt [ISvgImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISvgImage) jako pierwszy argument.

Poniższy kod przykładu w języku Java pokazuje, jak użyć tej metody do konwersji pliku SVG na zestaw kształtów:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

// Nazwa pliku SVG źródłowego.
String svgFileName = "sample.svg";

// Nazwa pliku wyjściowego prezentacji.
String outPptxPath = "presentation.pptx";

// Utwórz nową prezentację.
IPresentation presentation = new Presentation();
try {
    // Odczytaj zawartość pliku SVG.
    byte[] svgContent = Files.readAllBytes(Paths.get(svgFileName));

    // Utwórz obiekt SvgImage.
    ISvgImage svgImage = new SvgImage(svgContent);

    // Pobierz rozmiar slajdu.
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // Konwertuj obraz SVG na grupę kształtów i skaluj do rozmiaru slajdu.
    presentation.getSlides().get_Item(0).getShapes().addGroupShape(
            svgImage, 0f, 0f,
            (float) slideSize.getWidth(), (float) slideSize.getHeight());

    // Zapisz prezentację w formacie PPTX.
    presentation.save(outPptxPath, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **Dodawanie obrazów jako EMF do slajdów**

Aspose.Slides for Android via Java umożliwia generowanie obrazów EMF z arkuszy Excel przy użyciu Aspose.Cells i dodawanie ich do slajdów prezentacji.

Poniższy kod przykładu w języku Java pokazuje, jak to zrobić:

```java
import com.aspose.slides.*;
import com.aspose.cells.ImageOrPrintOptions;
import com.aspose.cells.ImageType;
import com.aspose.cells.SheetRender;
import com.aspose.cells.Workbook;
import com.aspose.cells.Worksheet;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;

Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);

ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

// Zapisz skoroszyt do strumienia.
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);

    String emfSheetName;
    for (int j = 0; j < sr.getPageCount(); j++) {
        emfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, emfSheetName);

        // Dodaj plik w oryginalnej postaci, aby obraz pozostał wektorem EMF zamiast zostać zrastrowany.
        IPPImage picture;
        InputStream imageStream = new FileInputStream(emfSheetName);
        try {
            picture = pres.getImages().addImage(imageStream);
        } finally {
            imageStream.close();
        }

        ISlide slide = pres.getSlides().addEmptySlide(
                pres.getLayoutSlides().getByType(SlideLayoutType.Blank));
        slide.getShapes().addPictureFrame(
                ShapeType.Rectangle,
                0,
                0,
                (float) pres.getSlideSize().getSize().getWidth(),
                (float) pres.getSlideSize().getSize().getHeight(),
                picture);
    }

    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

## **Zastępowanie obrazów w kolekcji obrazów**

Aspose.Slides pozwala zastępować obrazy przechowywane w kolekcji obrazów prezentacji, w tym obrazy używane przez kształty slajdów. Ten rozdział opisuje kilka sposobów aktualizacji obrazów w kolekcji. Możesz zastąpić obraz używając surowych danych bajtowych, instancji [IImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iimage/) lub innego obrazu, który już istnieje w kolekcji.

Postępuj zgodnie z poniższymi krokami:

1. Wczytaj plik prezentacji zawierający obrazy przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).  
2. Wczytaj nowy obraz z pliku do tablicy bajtów.  
3. Zastąp docelowy obraz nowym obrazem, używając tablicy bajtów.  
4. W drugim podejściu wczytaj obraz do obiektu [IImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iimage/) i zastąp docelowy obraz tym obiektem.  
5. W trzecim podejściu zastąp docelowy obraz obrazem, który już istnieje w kolekcji obrazów prezentacji.  
6. Zapisz zmodyfikowaną prezentację jako plik PPTX.  

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Pierwszy sposób.
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);

    // Drugi sposób.
    IImage newImage = Images.fromFile("image1.png");
    try {
        oldImage = presentation.getImages().get_Item(1);
        oldImage.replaceImage(newImage);
    } finally {
        if (newImage != null) newImage.dispose();
    }

    // Trzeci sposób.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));

    // Zapisz prezentację do pliku.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Dzięki darmowemu konwerterowi Aspose [Text to GIF](https://products.aspose.app/slides/pl/text-to-gif) możesz łatwo animować tekst i tworzyć GIF‑y z tekstu. 
{{% /alert %}}

## **FAQ**

**Czy oryginalna rozdzielczość obrazu pozostaje nienaruszona po wstawieniu?**  
Tak. Piksele źródłowe są zachowane, ale ostateczny wygląd zależy od tego, jak [picture](/slides/pl/androidjava/picture-frame/) jest skalowane na slajdzie oraz od ewentualnej kompresji przy zapisie.

**Jaki jest najlepszy sposób, aby jednocześnie wymienić to samo logo na dziesiątkach slajdów?**  
Umieść logo na masterze slajdu lub układzie i zastąp je w kolekcji obrazów prezentacji — aktualizacje zostaną propagowane do wszystkich elementów korzystających z tego zasobu.

**Czy wstawiony SVG może być konwertowany na edytowalne kształty?**  
Tak. Możesz skonwertować SVG do grupy kształtów, po czym poszczególne części stają się edytowalne przy użyciu standardowych właściwości kształtów.

**Jak mogę ustawić obraz jako tło wielu slajdów jednocześnie?**  
[Ustaw obraz jako tło](/slides/pl/androidjava/presentation-background/) na masterze slajdu lub odpowiednim układzie — wszystkie slajdy korzystające z tego mastera/układu odziedziczą tło.

**Jak zapobiec, aby prezentacja nie stała się zbyt duża z powodu wielu obrazów?**  
Używaj jednego zasobu obrazu zamiast duplikatów, wybieraj rozsądne rozdzielczości, stosuj kompresję przy zapisie i przechowuj powtarzające się grafiki na masterze, jeśli to odpowiednie.