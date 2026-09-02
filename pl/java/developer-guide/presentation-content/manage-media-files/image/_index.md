---
title: Optymalizacja zarządzania obrazami w prezentacjach przy użyciu Javy
linktitle: Zarządzanie obrazami
type: docs
weight: 10
url: /pl/java/image/
keywords:
- dodaj obraz
- dodaj grafikę
- dodaj bitmapę
- zastąp obraz
- zastąp grafikę
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
- Java
- Aspose.Slides
description: "Usprawnij zarządzanie obrazami w PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Javy, optymalizując wydajność i automatyzując przepływ pracy."
---
## **Wprowadzenie**

Obrazy sprawiają, że prezentacje są bardziej angażujące i atrakcyjne wizualnie. W programie Microsoft PowerPoint można wstawiać obrazy na slajdy z plików, internetu lub innych źródeł. Podobnie Aspose.Slides pozwala dodawać obrazy do slajdów prezentacji na kilka sposobów.

{{% alert  title="Tip" color="primary" %}} 
Aspose udostępnia darmowe konwertery — [JPEG to PowerPoint](https://products.aspose.app/slides/pl/import/jpg-to-ppt) i [PNG to PowerPoint](https://products.aspose.app/slides/pl/import/png-to-ppt) — które umożliwiają szybkie tworzenie prezentacji z obrazów. 
{{% /alert %}} 

{{% alert title="Info" color="info" %}}
Jeśli chcesz dodać obraz jako ramkę graficzną — szczególnie jeśli planujesz zmienić jego rozmiar, zastosować efekty lub użyć innych standardowych opcji formatowania — zobacz [Picture Frame](/slides/pl/java/picture-frame/). 
{{% /alert %}} 

{{% alert title="Note" color="warning" %}}
Możesz konwertować obrazy z jednego formatu na inny. Zobacz następujące strony: konwertuj [obraz do JPG](https://products.aspose.com/slides/pl/java/conversion/image-to-jpg/), [JPG do obrazu](https://products.aspose.com/slides/pl/java/conversion/jpg-to-image/), [JPG do PNG](https://products.aspose.com/slides/pl/java/conversion/jpg-to-png/), [PNG do JPG](https://products.aspose.com/slides/pl/java/conversion/png-to-jpg/), [PNG do SVG](https://products.aspose.com/slides/pl/java/conversion/png-to-svg/), oraz [SVG do PNG](https://products.aspose.com/slides/pl/java/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides obsługuje obrazy w popularnych formatach, takich jak JPEG, PNG, BMP, GIF i inne. 

## **Dodawanie obrazów przechowywanych lokalnie do slajdów**

Możesz dodać jeden lub więcej obrazów zapisanych na komputerze do slajdu prezentacji. Poniższy przykładowy kod Java pokazuje, jak dodać obraz do slajdu:

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

Jeśli obraz, który chcesz dodać do slajdu, nie jest zapisany na komputerze, możesz dodać go bezpośrednio z sieci. 

Poniższy przykładowy kod Java pokazuje, jak dodać obraz z sieci do slajdu:

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

## **Dodawanie obrazów do mastera slajdów**

Mistrz slajdów przechowuje i kontroluje informacje, takie jak motyw i układ slajdów, które go używają. Gdy dodasz obraz do mistrza slajdów, obraz pojawia się na każdym slajdzie opartym na tym mistrzu. 

Poniższy przykładowy kod Java pokazuje, jak dodać obraz do mistrza slajdów:

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

Możesz użyć obrazu jako tła jednego lub kilku slajdów. Aby uzyskać szczegóły, zobacz *[Ustawianie obrazów jako tła slajdów](/slides/pl/java/presentation-background/#setting-images-as-background-for-slides)*.

## **Dodawanie SVG do prezentacji**

Zawartość SVG można dodać do prezentacji przy użyciu klasy [SvgImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/svgimage/). Uzyskany obiekt [ISvgImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isvgimage/) może zostać dodany do kolekcji obrazów prezentacji i użyty do stworzenia ramki graficznej. 

Poniższy przykład Java importuje samodzielny ciąg SVG. Wszystkie obrazy, style i inne zasoby użyte przez ten SVG są osadzone bezpośrednio w treści SVG.

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

Pliki SVG wyeksportowane z narzędzi projektowych, edytorów diagramów, systemów ikon oraz pipeline'ów internetowych mogą odwoływać się do zasobów przechowywanych poza dokumentem SVG. Na przykład SVG może zawierać odnośnik do obrazu taki jak `images/photo.png`, wartość CSS `url(...)` lub adres URL czcionki. 

Aby zaimportować taką zawartość SVG, utwórz implementację [IExternalResourceResolver](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iexternalresourceresolver/) i przekaż ją razem z bazowym URI do odpowiedniego konstruktora [SvgImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/svgimage/). Bazowy URI określa lokalizację dokumentu SVG i jest używany do rozwiązywania odnośników względnych. 

Interfejs [ISvgImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isvgimage/) zapewnia dostęp do informacji o zaimportowanym SVG:

- `getSvgContent()` zwraca znacznik SVG jako ciąg znaków.  
- `getSvgData()` zwraca zawartość SVG jako tablicę bajtów.  
- `getBaseUri()` zwraca bazowy URI używany do odnośników względnych.  
- `getExternalResourceResolver()` zwraca resolver przypisany do obrazu SVG.  

### **Implementacja resolvera zasobów zewnętrznych**

Resolver posiada dwie metody:

- `resolveUri` łączy bazowy URI i względny odnośnik do zasobu i zwraca bezwzględny URI. Zwróć `null`, gdy odnośnik nie może zostać rozwiązany lub nie jest dozwolony.  
- `getEntity` zwraca strumień do odczytu dla bezwzględnego URI zasobu. Zwróć `null`, gdy zasób jest brakujący, zablokowany lub niedostępny. Strumień awaryjny może być również zwrócony, gdy jest to stosowne.  

Poniższy resolver ładuje powiązane zasoby wyłącznie z dozwolonego katalogu lokalnego. Zasoby sieciowe i ścieżki poza dozwolonym katalogiem są blokowane. Opcjonalny obraz awaryjny jest zwracany dla nie rozwiązanych odnośników do obrazów.

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

            // Ten resolver celowo zezwala wyłącznie na pliki lokalne.
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

            // Użyj zastępczego tylko dla zasobów graficznych. Zwracanie strumienia obrazu
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

Załóżmy, że `assets/diagram.svg` zawiera odwołanie względne, takie jak:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

Poniższy przykład Java przekazuje URI pliku SVG jako bazowy URI i zapewnia własny resolver. Resolver konwertuje względny odnośnik do obrazu na bezwzględny URI i zwraca strumień zawierający powiązany zasób, podczas gdy Aspose.Slides przetwarza SVG.

```java
import com.aspose.slides.*;

import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path svgFilePath = Paths.get("assets", "diagram.svg").toAbsolutePath().normalize();
Path assetDirectory = svgFilePath.getParent();
String svgContent = new String(Files.readAllBytes(svgFilePath), StandardCharsets.UTF_8);

// Podstawowy URI określa lokalizację dokumentu SVG.
String baseUri = svgFilePath.toUri().toString();

byte[] fallbackImageData = null;
Path fallbackImagePath = assetDirectory.resolve("fallback.png");
if (Files.exists(fallbackImagePath)) {
    fallbackImageData = Files.readAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory.toString(), fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage udostępnia zawartość źródłową, dane binarne, podstawowy URI oraz resolver.
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
Resolver zasobów udostępnia zasoby zewnętrzne podczas gdy Aspose.Slides przetwarza i renderuje SVG. Nie modyfikuje on pierwotnego znacznika SVG ani nie osadza automatycznie rozwiązanych zasobów w nim.

Gdy `ISvgImage` zostaje dodany do kolekcji obrazów prezentacji, plik PPTX może zawierać zarówno pierwotną reprezentację SVG, jak i rastrowy obraz awaryjny. Powiązany zasób może pojawić się w wygenerowanym obrazie awaryjnym, podczas gdy odnośnik względny, taki jak `images/photo.png`, pozostaje niezmieniony w przechowywanym SVG. Aplikacja renderująca natywną reprezentację SVG może więc pominąć powiązaną treść, gdy pierwotny zasób zewnętrzny jest niedostępny.
{{% /alert %}}

### **Utworzenie przenośnego obrazu SVG**

Aby stworzyć obraz SVG, który nie zależy od plików zewnętrznych, należy uczynić SVG samodzielnym przed utworzeniem `SvgImage`. Na przykład zamień odnośniki do obrazów na adresy URI `data:`, które zawierają dane obrazu:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Po osadzeniu wszystkich wymaganych zasobów w treści SVG, utwórz `SvgImage`, dodaj go do kolekcji obrazów prezentacji i wstaw do ramki graficznej, tak jak w poprzednim przykładzie.

### **Obsługa brakujących lub zablokowanych zasobów**

Zwróć `null` z `resolveUri`, gdy URI zasobu jest nieprawidłowy, zakazany lub nie może zostać rozwiązany. Zwróć `null` z `getEntity`, gdy zasób nie może być odczytany. Aspose.Slides kontynuuje przetwarzanie SVG bez tego zasobu, jeśli to możliwe.

Strumień awaryjny może być zwrócony dla brakującego zasobu, ale jego zawartość musi być zgodna z żądanym typem zasobu. Na przykład zwróć strumień obrazu tylko dla brakującego obrazu, nie dla czcionki czy arkusza stylów.

{{% alert title="Security" color="warning" %}}
Nie rozwiązuj dowolnych ścieżek plików ani nieograniczonych adresów URL sieciowych z niepewnych plików SVG. Ogranicz dozwolone schematy, katalogi i hosty. Dla zasobów sieciowych zastosuj także limity czasu połączenia, limity rozmiaru odpowiedzi oraz walidację treści.
{{% /alert %}}

## **Konwersja SVG na zestaw kształtów**

Aspose.Slides może konwertować SVG na zestaw kształtów, podobnie jak odpowiednia funkcjonalność w programie PowerPoint:

![PowerPoint Popup Menu](img_01_01.png)

Ta funkcjonalność jest udostępniana przez przeciążenie metody [addGroupShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) interfejsu [IShapeCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShapeCollection), które przyjmuje obiekt [ISvgImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISvgImage) jako pierwszy argument. 

Poniższy przykładowy kod Java pokazuje, jak użyć tej metody do konwersji pliku SVG na zestaw kształtów:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

// Nazwa pliku źródłowego SVG.
String svgFileName = "sample.svg";

// Nazwa pliku wyjściowej prezentacji.
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

    // Konwertuj obraz SVG na grupę kształtów i skaluj go do rozmiaru slajdu.
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

Aspose.Slides dla Javy pozwala generować obrazy EMF z arkuszy Excel przy użyciu Aspose.Cells i dodawać je do slajdów prezentacji.

Poniższy przykładowy kod Java pokazuje, jak to zrobić:

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

        // Dodaj plik w takiej formie, aby obraz pozostał wektorowym EMF zamiast zostać rastrowany.
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

## **Zastąpienie obrazów w kolekcji obrazów**

Aspose.Slides pozwala zastąpić obrazy przechowywane w kolekcji obrazów prezentacji, w tym obrazy używane przez kształty slajdów. Ten sekcja opisuje kilka sposobów aktualizacji obrazów w kolekcji. Możesz zastąpić obraz używając surowych danych bajtowych, instancji [IImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimage/), lub innego obrazu już istniejącego w kolekcji. 

Wykonaj poniższe kroki:

1. Załaduj plik prezentacji zawierający obrazy przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).  
2. Załaduj nowy obraz z pliku do tablicy bajtów.  
3. Zastąp docelowy obraz nowym obrazem, używając tablicy bajtów.  
4. W drugim podejściu, załaduj obraz do obiektu [IImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimage/), i zastąp docelowy obraz tym obiektem.  
5. W trzecim podejściu, zastąp docelowy obraz obrazem, który już istnieje w kolekcji obrazów prezentacji.  
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
Dzięki darmowemu konwerterowi Aspose [Text to GIF](https://products.aspose.app/slides/pl/text-to-gif) możesz łatwo animować tekst i tworzyć GIFy z tekstu. 
{{% /alert %}}

## **FAQ**

**Czy oryginalna rozdzielczość obrazu pozostaje niezmieniona po wstawieniu?**  
Tak. Piksele źródłowe są zachowane, ale ostateczny wygląd zależy od tego, jak [obraz](/slides/pl/java/picture-frame/) jest skalowany na slajdzie oraz od ewentualnej kompresji podczas zapisu.

**Jaki jest najlepszy sposób na zastąpienie tego samego logo na dziesiątkach slajdów jednocześnie?**  
Umieść logo na slajdzie master lub w układzie i zastąp je w kolekcji obrazów prezentacji — aktualizacje zostaną propagowane do wszystkich elementów korzystających z tego zasobu.

**Czy wstawiony SVG może zostać skonwertowany na edytowalne kształty?**  
Tak. Możesz skonwertować SVG na grupę kształtów, po czym poszczególne części stają się edytowalne przy użyciu standardowych właściwości kształtu.

**Jak ustawić obraz jako tło dla wielu slajdów jednocześnie?**  
[Przypisz obraz jako tło](/slides/pl/java/presentation-background/) na slajdzie master lub odpowiednim układzie — wszystkie slajdy korzystające z tego mastera/układu odziedziczą tło.

**Jak zapobiec, aby prezentacja nie stała się zbyt duża z powodu wielu obrazów?**  
Używaj jednego zasobu obrazu zamiast duplikatów, wybieraj rozsądne rozdzielczości, stosuj kompresję przy zapisie i przechowuj powtarzające się grafiki w masterze, gdy to właściwe.