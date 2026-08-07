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
- zamień obraz
- zamień zdjęcie
- z internetu
- tło
- dodaj PNG
- dodaj JPG
- dodaj SVG
- zewnętrzne zasoby SVG
- rezolver SVG
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
description: "Usprawnij zarządzanie obrazami w PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Androida w Javie, optymalizując wydajność i automatyzując przepływ pracy."
---
## **Wprowadzenie**

Obrazy sprawiają, że prezentacje są bardziej angażujące i wizualnie atrakcyjne. W Microsoft PowerPoint możesz wstawiać obrazy na slajdy z plików, internetu lub innych źródeł. Podobnie Aspose.Slides umożliwia dodawanie obrazów do slajdów prezentacji na kilka sposobów.

{{% alert  title="Tip" color="primary" %}} 
Aspose udostępnia bezpłatne konwertery —[JPEG to PowerPoint](https://products.aspose.app/slides/pl/import/jpg-to-ppt) i [PNG to PowerPoint](https://products.aspose.app/slides/pl/import/png-to-ppt) — pozwalające szybko tworzyć prezentacje z obrazów. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Jeśli chcesz dodać obraz jako ramkę zdjęcia — szczególnie jeśli planujesz zmienić jego rozmiar, zastosować efekty lub użyć innych standardowych opcji formatowania — zobacz [Picture Frame](/slides/pl/androidjava/picture-frame/). 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
Możesz konwertować obrazy z jednego formatu na inny. Zobacz następujące strony: konwersja [image to JPG](https://products.aspose.com/slides/pl/androidjava/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/pl/androidjava/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/pl/androidjava/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/pl/androidjava/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/pl/androidjava/conversion/png-to-svg/), oraz [SVG to PNG](https://products.aspose.com/slides/pl/androidjava/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides obsługuje obrazy w popularnych formatach, takich jak JPEG, PNG, BMP, GIF i inne. 

## **Dodawanie obrazów przechowywanych lokalnie do slajdów**

Możesz dodać jeden lub więcej obrazów przechowywanych na komputerze do slajdu prezentacji. Poniższy przykład kodu Java pokazuje, jak dodać obraz do slajdu:

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

## **Dodawanie obrazów z sieci do slajdów**

Jeśli obraz, który chcesz dodać do slajdu, nie jest przechowywany na komputerze, możesz dodać go bezpośrednio z sieci. 

Poniższy przykład kodu Java pokazuje, jak dodać obraz z sieci do slajdu:

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

Master slajdu przechowuje i kontroluje informacje takie jak motyw i układ slajdów, które go używają. Gdy dodasz obraz do mastera slajdu, obraz pojawi się na każdym slajdzie opartym na tym masterze. 

Poniższy przykład kodu Java pokazuje, jak dodać obraz do mastera slajdu:

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

## **Dodawanie obrazów jako tła slajdów**

Możesz użyć obrazu jako tła dla jednego lub kilku slajdów. Szczegóły znajdziesz w *[Setting Images as Backgrounds for Slides](/slides/pl/androidjava/presentation-background/#setting-images-as-background-for-slides)*.

## **Dodawanie SVG do prezentacji**

Treść SVG można dodać do prezentacji przy użyciu klasy [SvgImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/svgimage/). Uzyskany obiekt [ISvgImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isvgimage/) może zostać dodany do kolekcji obrazów prezentacji i użyty do utworzenia ramki obrazu. 

Poniższy przykład Java importuje samodzielny ciąg SVG. Wszystkie obrazy, style i inne zasoby użyte przez ten SVG są wbudowane bezpośrednio w treść SVG.

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

## **Importowanie treści SVG z zasobami zewnętrznymi**

Pliki SVG eksportowane z narzędzi projektowych, edytorów diagramów, systemów ikon i potoków internetowych mogą odwoływać się do zasobów przechowywanych poza dokumentem SVG. Na przykład SVG może zawierać link do obrazu taki jak `images/photo.png`, wartość CSS `url(...)` lub URL czcionki. 

Aby zaimportować taką treść SVG, utwórz implementację [IExternalResourceResolver](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iexternalresourceresolver/) i przekaż ją, wraz z bazowym URI, odpowiedniemu konstruktorowi [SvgImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/svgimage/). Bazowy URI określa lokalizację dokumentu SVG i jest używany do rozwiązywania linków względnych. 

Interfejs [ISvgImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isvgimage/) zapewnia dostęp do informacji o zaimportowanym SVG:

- `getSvgContent()` zwraca kod SVG jako ciąg znaków.  
- `getSvgData()` zwraca treść SVG jako tablicę bajtów.  
- `getBaseUri()` zwraca bazowy URI używany do linków względnych.  
- `getExternalResourceResolver()` zwraca resolver przypisany do obrazu SVG.  

### **Implementacja rozwiązania zasobów zewnętrznych**

Resolver ma dwie metody:

- `resolveUri` łączy bazowy URI i względny link zasobu i zwraca bezwzględny URI. Zwróć `null`, gdy link nie może zostać rozwiązany lub nie jest dozwolony.  
- `getEntity` zwraca strumień do odczytu dla bezwzględnego URI zasobu. Zwróć `null`, gdy zasób jest brakujący, zablokowany lub niedostępny. W razie potrzeby można zwrócić strumień zapasowy.  

Poniższy resolver ładuje powiązane zasoby tylko z dozwolonego lokalnego katalogu. Zasoby sieciowe i ścieżki poza dozwolonym katalogiem są blokowane. Opcjonalny obraz zapasowy jest zwracany dla nierozpoznanych linków do obrazów.

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

            // Ten resolver świadomie pozwala tylko na pliki lokalne.
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

            // Używaj zastępstwa tylko dla zasobów obrazów. Zwracanie strumienia obrazu
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

Załóżmy, że `assets/diagram.svg` zawiera względne odwołanie takie jak:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Poniższy przykład Java przekazuje URI pliku SVG jako bazowy URI i dostarcza własny resolver. Resolver przekształca względny link do obrazu w bezwzględny URI i zwraca strumień zawierający powiązany zasób, podczas gdy Aspose.Slides przetwarza SVG.

```java
import com.aspose.slides.*;

import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path svgFilePath = Paths.get("assets", "diagram.svg").toAbsolutePath().normalize();
Path assetDirectory = svgFilePath.getParent();
String svgContent = new String(Files.readAllBytes(svgFilePath), StandardCharsets.UTF_8);

// Bazowy URI reprezentuje lokalizację dokumentu SVG.
String baseUri = svgFilePath.toUri().toString();

byte[] fallbackImageData = null;
Path fallbackImagePath = assetDirectory.resolve("fallback.png");
if (Files.exists(fallbackImagePath)) {
    fallbackImageData = Files.readAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory.toString(), fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage exposes the source content, binary data, base URI, and resolver.
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

Klasa `SvgImage` oferuje również przeciążenia przyjmujące dane SVG jako tablicę bajtów lub strumień wejściowy, wraz z resolverem zasobów zewnętrznych i bazowym URI.

{{% alert title="Important" color="warning" %}}
Resolver zasobów udostępnia zasoby zewnętrzne w trakcie przetwarzania i renderowania SVG przez Aspose.Slides. Nie modyfikuje on oryginalnego kodu SVG ani automatycznie nie osadza rozwiązywanych zasobów w nim.  

Gdy `ISvgImage` zostanie dodany do kolekcji obrazów prezentacji, plik PPTX może zawierać zarówno pierwotną reprezentację SVG, jak i rastrowy obraz zapasowy. Powiązany zasób może pojawić się w wygenerowanym obrazie zapasowym, podczas gdy względny link taki jak `images/photo.png` pozostaje niezmieniony w przechowywanym SVG. Aplikacja renderująca natywną reprezentację SVG może więc pominąć powiązaną treść, gdy pierwotny zasób zewnętrzny jest niedostępny.
{{% /alert %}}

### **Utworzenie przenośnego obrazu SVG**

Aby utworzyć obraz SVG niezależny od plików zewnętrznych, przygotuj SVG jako samodzielny przed stworzeniem `SvgImage`. Na przykład zastąp powiązane URL‑e obrazów URI typu `data:`, które zawierają dane obrazu:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Po osadzeniu wszystkich wymaganych zasobów w treści SVG, utwórz `SvgImage`, dodaj go do kolekcji obrazów prezentacji i wstaw do ramki obrazu, jak pokazano w poprzednim przykładzie.

### **Obsługa brakujących lub zablokowanych zasobów**

Zwróć `null` z `resolveUri`, gdy URI zasobu jest nieprawidłowy, zabroniony lub nie może zostać rozwiązany. Zwróć `null` z `getEntity`, gdy zasób nie może być odczytany. Aspose.Slides kontynuuje przetwarzanie SVG bez tego zasobu, jeśli to możliwe.  

Strumień zapasowy może zostać zwrócony dla brakującego zasobu, ale jego zawartość musi być zgodna z żądanym typem zasobu. Na przykład zwracaj strumień obrazu tylko dla brakującego obrazu, a nie dla czcionki czy arkusza stylów.

{{% alert title="Security" color="warning" %}}
Nie rozwiązuj dowolnych ścieżek plików ani nieograniczonych URL‑i sieciowych z niezaufanych plików SVG. Ogranicz dozwolone schemy, katalogi i hosty. Dla zasobów sieciowych stosuj także limity czasu połączenia, ograniczenia wielkości odpowiedzi i walidację treści.
{{% /alert %}}

## **Konwersja SVG na zestaw kształtów**

Aspose.Slides może konwertować SVG na zestaw kształtów, podobnie jak odpowiadająca funkcja w PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Funkcjonalność ta jest udostępniana przez przeciążenie metody [addGroupShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) interfejsu [IShapeCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IShapeCollection), która przyjmuje obiekt [ISvgImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISvgImage) jako pierwszy argument. 

Poniższy przykład kodu Java pokazuje, jak użyć tej metody do konwersji pliku SVG na zestaw kształtów:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

// Nazwa pliku źródłowego SVG.
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

    // Przekształć obraz SVG w grupę kształtów i skaluj go do rozmiaru slajdu.
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

Aspose.Slides for Android via Java pozwala generować obrazy EMF z arkuszy Excel przy użyciu Aspose.Cells i dodawać je do slajdów prezentacji. 

Poniższy przykład Java pokazuje, jak to zrobić:

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

        // Dodaj plik w oryginalnej formie, aby obraz pozostał wektorowym EMF, a nie został zrastrowany.
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

## **Zamiana obrazów w kolekcji obrazów**

Aspose.Slides umożliwia zamianę obrazów przechowywanych w kolekcji obrazów prezentacji, w tym obrazów używanych przez kształty slajdów. Ten rozdział opisuje kilka sposobów aktualizacji obrazów w kolekcji. Możesz zamienić obraz, używając surowych danych bajtowych, instancji [IImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iimage/) lub innego obrazu, który już istnieje w kolekcji. 

Postępuj zgodnie z poniższymi krokami:

1. Załaduj plik prezentacji zawierający obrazy przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).  
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
Korzystając z bezpłatnego konwertera Aspose [Text to GIF](https://products.aspose.app/slides/pl/text-to-gif), możesz łatwo animować tekst i tworzyć GIF‑y z tekstu. 
{{% /alert %}}

## **FAQ**

**Czy oryginalna rozdzielczość obrazu pozostaje niezmieniona po wstawieniu?**

Tak. Piksele źródłowe są zachowane, ale ostateczny wygląd zależy od tego, jak [picture](/slides/pl/androidjava/picture-frame/) jest skalowany na slajdzie oraz od ewentualnej kompresji przy zapisie.

**Jaki jest najlepszy sposób, aby jednocześnie zamienić to samo logo na dziesiątki slajdów?**

Umieść logo na masterze slajdu lub układzie i zamień je w kolekcji obrazów prezentacji — zmiany zostaną propagowane do wszystkich elementów korzystających z tego zasobu.

**Czy wstawiony SVG może zostać przekonwertowany na edytowalne kształty?**

Tak. Możesz skonwertować SVG na grupę kształtów, po czym poszczególne części staną się edytowalne przy użyciu standardowych właściwości kształtów.

**Jak ustawić obraz jako tło dla wielu slajdów jednocześnie?**

[Assign the image as the background](/slides/pl/androidjava/presentation-background/) na masterze slajdu lub odpowiednim układzie — wszystkie slajdy używające tego mastera/układu odziedziczą tło.

**Jak zapobiec, aby prezentacja nie stała się zbyt duża z powodu wielu obrazów?**

Używaj jednego zasobu obrazu zamiast duplikatów, wybieraj rozsądne rozdzielczości, stosuj kompresję przy zapisie i, gdy to możliwe, przechowuj powtarzające się grafiki w masterze.