---
title: Optymalizacja zarządzania obrazami w prezentacjach na Androidzie
linktitle: Zarządzanie obrazami
type: docs
weight: 10
url: /pl/androidjava/image/
keywords:
- dodaj obraz
- dodaj zdjęcie
- zastąp obraz
- kolekcja obrazów
- ramka obrazu
- obraz połączony
- tło
- dodaj PNG
- dodaj JPG
- dodaj SVG
- SVG na kształty
- zewnętrzne zasoby SVG
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Dowiedz się, jak dodawać, ponownie używać, łączyć, zastępować i zarządzać obrazami rastrowymi oraz SVG w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides for Android via Java."
---
## **Wprowadzenie**

Aspose.Slides for Android via Java oferuje kilka sposobów pracy z obrazami, a każdy z nich służy innemu celowi. Możesz przechowywać obraz w prezentacji, wyświetlać go w ramce obrazu, używać jako tło slajdu, odwoływać się do zewnętrznego obrazu, zamienić współdzielony zasób obrazu lub konwertować zawartość SVG na edytowalne kształty.

Ten artykuł koncentruje się na zasobach obrazu i ich użyciu w całej prezentacji. Aby uzyskać informacje o przycinaniu, przezroczystości, efektach, rozciąganiu i innych formatach stosowanych do pojedynczej ramki obrazu, zobacz [Ramka obrazu](/slides/pl/androidjava/picture-frame/).

## **Zrozumienie modelu obrazu**

Poniższe pojęcia API są ze sobą ściśle powiązane, ale nie zamienne:

- [Kolekcja obrazów prezentacji](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iimagecollection/) przechowuje zasoby obrazów używane w prezentacji. Użyj [ImageCollection.addImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imagecollection/), aby dodać dane obrazu i uzyskać zasób [IPPImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ippimage/).
- [Ramka obrazu](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipictureframe/) jest kształtem wyświetlającym obraz na slajdzie, układzie lub masterze. Użyj [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishapecollection/), aby umieścić zasób obrazu na slajdzie.
- Tło slajdu używa obrazu jako części wypełnienia slajdu, a nie jako kształtu. Dlatego nie zachowuje się jak ramka obrazu.
- [IPPImage.replaceImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ippimage/) zastępuje zasób obrazu. Jeśli kilka elementów prezentacji używa tego zasobu, wszystkie używają zamiany.
- Konwersja SVG na kształty tworzy edytowalne kształty slajdu. Po konwersji zawartość nie jest już zarządzana jako pojedynczy zasób obrazu.

Typowy przepływ pracy wygląda więc tak: dodaj dane obrazu do kolekcji obrazów, otrzymaj [IPPImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ippimage/), a następnie użyj tego zasobu w jednej lub wielu ramkach obrazu lub wypełnieniach.

## **Dodaj osadzony obraz**

Aby wstawić lokalny obraz, załaduj plik, dodaj go do kolekcji obrazów i utwórz ramkę obrazu, która używa zwróconego `IPPImage`.

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

Gdy obraz jest dostępny przez HTTP lub HTTPS, pobierz jego bajty, dodaj je do kolekcji obrazów prezentacji i użyj zwróconego zasobu obrazu w taki sam sposób jak lokalnego obrazu.

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

W aplikacjach działających długo, ponownie używaj klienta HTTP lub strategii zarządzania połączeniami odpowiedniej dla aplikacji, zamiast wielokrotnie tworzyć niepotrzebną infrastrukturę sieciową. Również weryfikuj zdalne adresy URL, rozmiary odpowiedzi i typy treści, gdy źródło nie jest zaufane.

## **Ponowne użycie obrazów na wielu slajdach**

Jeśli ten sam obraz jest potrzebny więcej niż raz, dodaj go do prezentacji raz i ponownie użyj zwróconego [IPPImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ippimage/) przy tworzeniu dodatkowych ramek obrazu. Zapobiega to wielokrotnemu ładowaniu tych samych danych źródłowych i wyraźnie określa zależność pomiędzy współdzielonym zasobem obrazu a jego użyciami.

Dla grafiki, która ma się automatycznie pojawiać na wielu slajdach, np. logo firmy, rozważ umieszczenie ramki obrazu na [masterze slajdów](/slides/pl/androidjava/slide-master/) lub układzie zamiast dodawania równoważnego kształtu do każdego slajdu.

## **Użyj obrazu jako tło slajdu**

Obraz tła jest przypisany do wypełnienia slajdu; nie jest dodawany jako kształt ramki obrazu. Jest to przydatne, gdy obraz ma pokrywać tło slajdu i nie powinien być manipulowany jak zwykły obiekt slajdu.

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

Aby uzyskać dodatkowe opcje tła, w tym tła mastera i układu, zobacz [Tło prezentacji](/slides/pl/androidjava/presentation-background/).

## **Obrazy osadzone i połączone**

Obrazy osadzone i połączone mają różne kompromisy dotyczące przenośności i rozmiaru pliku:

- **Obraz osadzony:** dane obrazu są przechowywane wewnątrz prezentacji. Prezentacja jest samodzielna, ale rozmiar pliku zawiera dane obrazu.
- **Obraz połączony:** prezentacja przechowuje ścieżkę lub URL do zewnętrznego obrazu. Może to zmniejszyć rozmiar prezentacji, ale zewnętrzny zasób musi pozostać dostępny, gdy prezentacja jest otwierana lub renderowana.

Połączony obraz można utworzyć, przypisując zewnętrzną ścieżkę lub URL za pomocą [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islidespicture/) zamiast osadzania danych obrazu.

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

Używaj połączonych obrazów tylko wtedy, gdy środowisko wdrożeniowe może niezawodnie uzyskać dostęp do zewnętrznego zasobu. Dla prezentacji, które muszą działać offline lub być przenoszone między systemami, obrazy osadzone są zazwyczaj bezpieczniejsze.

## **Praca z obrazami SVG**

SVG jest formatem wektorowym, dlatego może być przydatny dla ikon, diagramów i innych grafik, które powinny skalować się bez utraty szczegółów charakterystycznej dla obrazów rastrowych. Aspose.Slides obsługuje SVG zarówno jako zasób obrazu, jak i jako źródło edytowalnych kształtów slajdu.

### **Dodaj SVG jako obraz**

Utwórz [SvgImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/svgimage/), dodaj go do kolekcji obrazów i umieść powstały zasób obrazu w ramce obrazu.

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

SVG może odwoływać się do zewnętrznych obrazów, arkuszy stylów lub czcionek. W takich przypadkach [SvgImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/svgimage/) udostępnia konstruktory przyjmujące [IExternalResourceResolver](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iexternalresourceresolver/) i bazowy URI. Resolver może mapować względny URI na dozwolony absolutny URI i zwrócić strumień dla żądanego zasobu.

Resolver udostępnia zasoby zewnętrzne podczas przetwarzania SVG przez Aspose.Slides, ale nie przepisuje SVG do dokumentu samodzielnego. Jeśli SVG musi pozostać przenośny, osadź wymagane zasoby w samym SVG, np. używając URI `data:` dla połączonych obrazów.

Gdy pliki SVG pochodzą z niepewnych źródeł, ogranicz schematy, lokalizacje plików i hosty, do których resolver może mieć dostęp. Rozwiązania sieciowe powinny również stosować limity czasu, rozmiaru odpowiedzi i weryfikację treści.

### **Konwertuj SVG na edytowalne kształty**

Aspose.Slides może konwertować SVG na grupę edytowalnych kształtów slajdu, podobnie jak odpowiadające polecenie PowerPoint.

![Menu podpowiedzi PowerPoint](img_01_01.png)

Użyj przeciążenia [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishapecollection/), które przyjmuje [ISvgImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isvgimage/), aby wykonać konwersję.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] imageData = Files.readAllBytes(Paths.get("diagram.svg"));
    String svgContent = new String(imageData, StandardCharsets.UTF_8);
    ISvgImage svgImage = new SvgImage(svgContent);

    SizeF slideSize = presentation.getSlideSize().getSize();
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.getShapes().addGroupShape(svgImage, 0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight());

    presentation.save("editable-svg-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Używaj konwersji SVG na kształty, gdy poszczególne elementy wektorowe muszą być edytowane jako kształty PowerPoint. Jeśli SVG ma być tylko wyświetlany, pozostawienie go jako obrazu jest prostsze i unika tworzenia wielu oddzielnych kształtów.

## **Zastąp istniejący zasób obrazu**

Użyj [IPPImage.replaceImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ippimage/), gdy chcesz zastąpić istniejący zasób obrazu. Jest to szczególnie przydatne w przypadku współdzielonych grafik, takich jak loga.

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

Jeśli wiele ramek obrazu, tła, masterów lub układów używa tego samego zasobu obrazu, jego zastąpienie aktualizuje wszystkie te użycia. Jeśli ma się zmienić tylko jedną ramkę obrazu, przypisz inną grafikę do tej ramki zamiast zastępować współdzielony zasób.

`replaceImage` udostępnia również przeciążenia przyjmujące tablicę bajtów lub inny [IPPImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ippimage/).

## **Praktyczne wskazówki zarządzania obrazami**

### **Kontrola rozmiaru prezentacji**

Duże obrazy rastrowe mogą sprawić, że prezentacja będzie niepotrzebnie duża. Używaj obrazów źródłowych o wymiarach odpowiednich do zamierzonego rozmiaru wyświetlania, ponownie używaj współdzielonych zasobów obrazu tam, gdzie to możliwe, i unikaj osadzania powtarzających się kopii tej samej grafiki w pełnej rozdzielczości.

Dla obrazów rastrowych, które już zostały umieszczone w ramach obrazu, [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipicturefillformat/) może zmniejszyć dane obrazu zgodnie z wybraną rozdzielczością i ustawieniami przycinania. Jest to przetwarzanie ramki obrazu, a nie zarządzanie kolekcją obrazów, więc zobacz [Ramkę obrazu](/slides/pl/androidjava/picture-frame/) po dodatkowe operacje formatowania.

### **Wybór między treścią osadzoną a połączoną**

Osadzanie sprawia, że prezentacja jest przenośna, ponieważ wszystkie wymagane dane obrazu są zawarte w pliku. Łączenie może zmniejszyć rozmiar pliku, ale wprowadza zależność zewnętrzną. Używaj linków tylko wtedy, gdy ta zależność jest akceptowalna i stabilna.

### **Ponowne użycie wspólnej identyfikacji wizualnej**

W przypadku powtarzających się logotypów, znaków wodnych lub grafik dekoracyjnych użyj jednego zasobu obrazu i ponownie go wykorzystaj. Jeśli grafika należy do projektu prezentacji, a nie do treści slajdu, umieść ją na masterze lub układzie, aby była dziedziczona przez odpowiednie slajdy.

### **Utrzymywanie zasobów SVG w formie przenośnej**

Samodzielny SVG jest łatwiejszy do przenoszenia i renderowania w sposób spójny niż SVG zależny od plików zewnętrznych lub zasobów sieciowych. Gdy to możliwe, osadź wymagane zasoby przed importowaniem SVG. Konwertuj SVG na kształty tylko wtedy, gdy poszczególne elementy wektorowe muszą być edytowane.

### **Użyj nowoczesnego, wieloplatformowego interfejsu API obrazu**

W nowym kodzie Android via Java używaj interfejsów API Aspose.Slides [IImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iimage/) i [Images](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/images/) zamiast przestarzałego publicznego API opartego na `android.graphics.Bitmap`. Zobacz [Nowoczesne API](/slides/pl/androidjava/modern-api/) po wskazówki dotyczące migracji.

Formaty WMF i EMF wymagają specjalnego rozważenia. Gdy są przekazywane poprzez [IImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iimage/), [ImageCollection.addImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imagecollection/) konwertuje plik metafile na rastrową reprezentację PNG przed wstawieniem. Jeśli zachowanie danych metafile jest istotne, użyj przeciążenia [ImageCollection.addImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/imagecollection/) opartego na strumieniu. Generowanie treści EMF z arkuszy kalkulacyjnych lub innych produktów jest oddzielnym procesem integracji i wykracza poza zakres tego artykułu.

## **Najczęściej zadawane pytania**

**Jaka jest różnica między kolekcją obrazów a ramką obrazu?**

Kolekcja obrazów przechowuje wielokrotnie używane zasoby obrazów. Ramka obrazu jest kształtem slajdu, który wyświetla jeden z tych zasobów i zapewnia formatowanie specyficzne dla obrazów, takie jak przycinanie i efekty.

**Jaki jest najlepszy sposób, aby zastąpić to samo logo wszędzie?**

Jeśli logo jest już współdzielone jako jeden zasób obrazu, zastąp ten zasób przy pomocy [IPPImage.replaceImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ippimage/). Dla identyfikacji wizualnej obowiązującej w całej prezentacji, umieszczenie logo na masterze lub układzie może również zmniejszyć powieloną zawartość slajdów.

**Dlaczego połączony obraz znika na innym komputerze?**

Połączony obraz zależy od swojego zewnętrznego pliku lub URL. Jeśli ten zasób nie jest dostępny z innego komputera, połączony obraz może być niedostępny. Osadź obraz, gdy prezentacja musi być samodzielna.

**Czy wstawiony SVG można edytować jako kształty PowerPoint?**

Tak. Konwertuj SVG przy pomocy [IShapeCollection.addGroupShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishapecollection/); powstała grupa zawiera edytowalne kształty slajdu zamiast jednego obrazu SVG.

**Jak mogę utrzymać prezentacje z wieloma obrazami w mniejszym rozmiarze?**

Ponownie używaj współdzielonych zasobów obrazów, unikaj niepotrzebnie dużych źródeł rastrowych, kompresuj odpowiednie obrazy rastrowe w razie potrzeby, umieszczaj powtarzającą się identyfikację wizualną na masterach lub układach oraz używaj połączonych obrazów tylko wtedy, gdy zewnętrzna zależność jest dopuszczalna.