---
title: Optymalizacja zarządzania obrazami w prezentacjach przy użyciu Javy
linktitle: Zarządzaj obrazami
type: docs
weight: 10
url: /pl/java/image/
keywords:
- dodaj obraz
- dodaj obraz
- zastąp obraz
- kolekcja obrazów
- ramka obrazu
- obraz linkowany
- tło
- dodaj PNG
- dodaj JPG
- dodaj SVG
- SVG na kształty
- zewnętrzne zasoby SVG
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Dowiedz się, jak dodawać, ponownie wykorzystywać, linkować, zastępować i zarządzać obrazami rastrowymi oraz SVG w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Javy."
---
## **Wprowadzenie**

Aspose.Slides for Java oferuje kilka sposobów pracy z obrazami, a każdy z nich służy innemu celowi. Możesz przechowywać obraz w prezentacji, wyświetlać go w ramce obrazu, używać jako tło slajdu, linkować do zewnętrznego obrazu, zastąpić współdzielony zasób obrazu lub konwertować zawartość SVG na edytowalne kształty.

Ten artykuł koncentruje się na zasobach obrazów i ich użyciu w całej prezentacji. Informacje o przycinaniu, przezroczystości, efektach, rozciąganiu i innych formatach stosowanych do pojedynczej ramki obrazu znajdziesz w [Picture Frame](/slides/pl/java/picture-frame/).

## **Zrozum model obrazu**

Poniższe pojęcia API są ze sobą ściśle powiązane, ale nie są wymienne:

- [kolekcja obrazów prezentacji](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimagecollection/) przechowuje zasoby obrazów używane w prezentacji. Użyj [ImageCollection.addImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imagecollection/), aby dodać dane obrazu i uzyskać zasób [IPPImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ippimage/).
- [ramka obrazu](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipictureframe/) to kształt wyświetlający obraz na slajdzie, układzie lub masterze. Użyj [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishapecollection/), aby umieścić zasób obrazu na slajdzie.
- Tło slajdu używa obrazu jako części wypełnienia slajdu, a nie jako kształtu. Dlatego nie zachowuje się tak jak ramka obrazu.
- [IPPImage.replaceImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ippimage/) zastępuje zasób obrazu. Jeśli kilka elementów prezentacji używa tego zasobu, wszystkie korzystają z zamiany.
- Konwersja SVG do kształtów tworzy edytowalne kształty slajdów. Po konwersji zawartość nie jest już zarządzana jako pojedynczy zasób obrazu.

Typowy przepływ pracy wygląda więc następująco: dodaj dane obrazu do kolekcji obrazów, otrzymaj [IPPImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ippimage/), a następnie użyj tego zasobu w jednej lub wielu ramach obrazu lub wypełnieniach.

## **Dodaj osadzony obraz**

Aby wstawić lokalny obraz, wczytaj plik, dodaj go do kolekcji obrazów i utwórz ramkę obrazu wykorzystującą zwrócony `IPPImage`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Obraz dodany w ten sposób jest osadzony w prezentacji, więc wynikowy plik nie zależy od dostępności oryginalnego pliku obrazu.

### **Dodaj obraz z sieci**

Gdy obraz jest dostępny przez HTTP lub HTTPS, pobierz jego bajty, dodaj je do kolekcji obrazów prezentacji i użyj zwróconego zasobu obrazu w taki sam sposób jak lokalny obraz.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.URI;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    URL imageUrl = URI.create("https://example.com/image.png").toURL();
    HttpURLConnection connection = (HttpURLConnection) imageUrl.openConnection();
    connection.setConnectTimeout(10000);
    connection.setReadTimeout(10000);

    try (InputStream inputStream = connection.getInputStream(); 
         ByteArrayOutputStream outputStream = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = inputStream.read(buffer)) != -1) outputStream.write(buffer, 0, bytesRead);

        IPPImage image = presentation.getImages().addImage(outputStream.toByteArray());
        ISlide slide = presentation.getSlides().get_Item(0);
        slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);
    }

    presentation.save("presentation-from-web.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

W aplikacjach działających długo, używaj ponownie klienta HTTP lub strategii zarządzania połączeniami odpowiedniej dla aplikacji, zamiast wielokrotnie tworzyć niepotrzebną infrastrukturę sieciową. Również weryfikuj zdalne adresy URL, rozmiary odpowiedzi i typy treści, gdy źródło nie jest zaufane.

## **Ponowne użycie obrazów na wielu slajdach**

Jeśli ten sam obraz jest potrzebny więcej niż raz, dodaj go do prezentacji raz i ponownie użyj zwróconego [IPPImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ippimage/), co unika wielokrotnego ładowania tych samych danych źródłowych i jasno określa zależność między współdzielonym zasobem obrazu a jego użyciem.

Jeśli grafika ma automatycznie pojawiać się na wielu slajdach, np. logo firmy, rozważ umieszczenie ramki obrazu na [slide master](/slides/pl/java/slide-master/) lub układzie zamiast dodawania równoważnego kształtu do każdego slajdu.

## **Użyj obrazu jako tło slajdu**

Obraz tła jest przypisany do wypełnienia slajdu; nie jest dodawany jako kształt ramki obrazu. Jest to przydatne, gdy obraz ma pokrywać tło slajdu i nie powinien być manipulowany jak normalny obiekt slajdu.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("background.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        if (sourceImage != null) sourceImage.dispose();
    }

    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(image);

    presentation.save("background-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dla dodatkowych opcji tła, w tym tła mistrza i układu, zobacz [Presentation Background](/slides/pl/java/presentation-background/).

## **Obrazy osadzone i linkowane**

Obrazy osadzone i linkowane mają różne kompromisy dotyczące przenośności i rozmiaru pliku:

- **Obraz osadzony:** dane obrazu są przechowywane wewnątrz prezentacji. Prezentacja jest samodzielna, ale rozmiar pliku zawiera dane obrazu.
- **Obraz linkowany:** prezentacja przechowuje ścieżkę lub adres URL do zewnętrznego obrazu. To może zmniejszyć rozmiar prezentacji, ale zasób zewnętrzny musi pozostać dostępny podczas otwierania lub renderowania prezentacji.

Obraz linkowany można utworzyć, przypisując zewnętrzną ścieżkę lub URL za pomocą [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islidespicture/) zamiast osadzania danych obrazu.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong("https://example.com/image.png");

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Używaj obrazów linkowanych tylko wtedy, gdy środowisko wdrożeniowe może wiarygodnie uzyskać dostęp do zasobu zewnętrznego. Dla prezentacji, które muszą działać offline lub być przenoszone między systemami, obrazy osadzone są zazwyczaj bezpieczniejsze.

## **Praca z obrazami SVG**

SVG jest formatem wektorowym, więc może być przydatny dla ikon, diagramów i innych grafiki, które powinny skalować się bez utraty szczegółów jak obrazy rastrowe. Aspose.Slides obsługuje SVG zarówno jako zasób obrazu, jak i jako źródło edytowalnych kształtów slajdu.

### **Dodaj SVG jako obraz**

Utwórz [SvgImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/svgimage/), dodaj go do kolekcji obrazów i umieść otrzymany zasób obrazu w ramce obrazu.

```java
import com.aspose.slides.*;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("icon.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    IPPImage image = presentation.getImages().addImage(svgImage);
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image);

    presentation.save("svg-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Pliki SVG z zasobami zewnętrznymi**

SVG może odwoływać się do zewnętrznych obrazów, arkuszy stylów lub czcionek. W takich przypadkach [SvgImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/svgimage/) udostępnia konstruktory przyjmujące [IExternalResourceResolver](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iexternalresourceresolver/) oraz bazowy URI. Resolver może mapować względny URI na dozwolony absolutny URI i zwrócić strumień dla żądanego zasobu.

Resolver udostępnia zasoby zewnętrzne podczas przetwarzania SVG przez Aspose.Slides, ale nie przepisuje SVG na dokument samodzielny. Jeśli SVG musi pozostać przenośny, osadź wymagane zasoby w samym SVG, na przykład używając URI `data:` dla linkowanych obrazów.

Gdy pliki SVG pochodzą z niepewnych źródeł, ogranicz schematy, lokalizacje plików i hosty, do których resolver może uzyskać dostęp. Resolvery sieciowe powinny także stosować limity czasu, ograniczenia rozmiaru odpowiedzi i walidację treści.

### **Konwertuj SVG na edytowalne kształty**

Aspose.Slides może konwertować SVG na grupę edytowalnych kształtów slajdu, podobnie jak odpowiadające polecenie PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

Użyj przeciążenia [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishapecollection/) akceptującego [ISvgImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isvgimage/) aby wykonać konwersję.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("diagram.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    Dimension2D slideSize = presentation.getSlideSize().getSize();
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Używaj konwersji SVG na kształty, gdy pojedyncze elementy wektorowe muszą być edytowane jako kształty PowerPoint. Jeśli SVG ma być tylko wyświetlany, pozostawienie go jako obrazu jest prostsze i unika tworzenia wielu osobnych kształtów.

## **Zastąp istniejący zasób obrazu**

Użyj [IPPImage.replaceImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ippimage/), gdy chcesz zastąpić istniejący zasób obrazu. Jest to szczególnie przydatne dla współdzielonych grafik, takich jak logotypy.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IPPImage imageToReplace = presentation.getImages().get_Item(0);

    IImage replacementImage = Images.fromFile("new-logo.png");
    try {
        imageToReplace.replaceImage(replacementImage);
    } finally {
        if (replacementImage != null) replacementImage.dispose();
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Jeśli wiele ramek obrazu, tła, mistrzów lub układów używa tego samego zasobu obrazu, zastąpienie tego zasobu aktualizuje wszystkie te użycia. Jeśli ma się zmienić tylko jedną ramkę obrazu, przypisz inny obraz do tej ramki zamiast zastępować współdzielony zasób.

`replaceImage` udostępnia także przeciążenia przyjmujące tablicę bajtów lub inny [IPPImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ippimage/).

## **Praktyczne wskazówki zarządzania obrazami**

### **Kontroluj rozmiar prezentacji**

Duże obrazy rastrowe mogą niepotrzebnie zwiększyć rozmiar prezentacji. Używaj obrazów źródłowych o wymiarach odpowiednich do zamierzonego rozmiaru wyświetlania, ponownie używaj współdzielonych zasobów obrazów tam, gdzie to możliwe, i unikaj osadzania wielokrotnych kopii tej samej grafiki w pełnej rozdzielczości.

Dla obrazów rastrowych już umieszczonych w ramkach obrazu, [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipicturefillformat/) może zmniejszyć dane obrazu zgodnie z wybraną rozdzielczością i ustawieniami przycięcia. Jest to przetwarzanie ramki obrazu, a nie zarządzanie kolekcją obrazów, więc zobacz [Picture Frame](/slides/pl/java/picture-frame/) po związane operacje formatowania.

### **Wybierz pomiędzy zawartością osadzoną a linkowaną**

Osadzanie sprawia, że prezentacja jest przenośna, ponieważ wszystkie potrzebne dane obrazu podróżują z plikiem. Łączenie może zmniejszyć rozmiar pliku, ale wprowadza zależność zewnętrzną. Używaj linków tylko wtedy, gdy taka zależność jest akceptowalna i stabilna.

### **Ponowne użycie wspólnego brandingu**

Dla powtarzających się logotypów, znaków wodnych lub elementów dekoracyjnych, użyj jednego zasobu obrazu i ponownie go wykorzystaj. Jeśli grafika należy do projektu prezentacji, a nie do treści slajdu, umieść ją na mistrzu lub układzie, aby była dziedziczona przez odpowiednie slajdy.

### **Utrzymuj zasoby SVG przenośne**

Samodzielny SVG jest łatwiejszy do przenoszenia i renderowania w sposób spójny niż SVG zależny od zewnętrznych plików lub zasobów sieciowych. Gdzie to możliwe, osadź wymagane zasoby przed importem SVG. Konwertuj SVG na kształty tylko wtedy, gdy poszczególne elementy wektorowe muszą być edytowane.

### **Użyj nowoczesnego, wieloplatformowego API obrazu**

Dla nowego kodu Java używaj API Aspose.Slides [IImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimage/) i [Images](https://reference.aspose.com/slides/pl/java/com.aspose.slides/images/) zamiast starszego publicznego API opartego na `java.awt.image.BufferedImage`. Zobacz [Modern API](/slides/pl/java/modern-api/) po wskazówki migracji.

WMF i EMF wymagają specjalnego traktowania. Gdy te formaty są przekazywane przez [IImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimage/), [ImageCollection.addImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imagecollection/) konwertuje plik meta na reprezentację rastrową PNG przed wstawieniem. Jeśli zachowanie danych pliku meta jest ważne, użyj przeciążenia [ImageCollection.addImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/imagecollection/) przyjmującego strumień. Generowanie treści EMF z arkuszy kalkulacyjnych lub innych produktów jest oddzielnym przepływem integracji i wykracza poza zakres tego artykułu.

## **FAQ**

**Jaka jest różnica między kolekcją obrazów a ramką obrazu?**

Kolekcja obrazów przechowuje wielokrotnego użytku zasoby obrazów. Ramka obrazu jest kształtem slajdu wyświetlającym jeden z tych zasobów i zapewnia specyficzne formatowanie obrazu, takie jak przycinanie i efekty.

**Jaki jest najlepszy sposób, aby zastąpić to samo logo wszędzie?**

Jeśli logo jest już współdzielone jako jeden zasób obrazu, zastąp ten zasób za pomocą [IPPImage.replaceImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ippimage/). Dla brandingu obejmującego całą prezentację, umieszczenie logo na mistrzu lub układzie może również zmniejszyć powielanie treści slajdów.

**Dlaczego linkowany obraz znika na innym komputerze?**

Obraz linkowany zależy od swojego zewnętrznego pliku lub URL. Jeśli zasób nie jest dostępny z innego komputera, linkowany obraz może być niedostępny. Osadź obraz, gdy prezentacja musi być samodzielna.

**Czy wstawiony SVG może być edytowany jako kształty PowerPoint?**

Tak. Konwertuj SVG przy użyciu [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishapecollection/); powstała grupa zawiera edytowalne kształty slajdu zamiast jednego obrazu SVG.

**Jak mogę utrzymać prezentacje z wieloma obrazami mniejsze?**

Ponownie używaj współdzielonych zasobów obrazów, unikaj niepotrzebnie dużych źródeł rastrowych, kompresuj odpowiednie obrazy rastrowe w razie potrzeby, umieszczaj powtarzający się branding na mistrzach lub układach oraz używaj linkowanych obrazów tylko wtedy, gdy zależność zewnętrzna jest akceptowalna.