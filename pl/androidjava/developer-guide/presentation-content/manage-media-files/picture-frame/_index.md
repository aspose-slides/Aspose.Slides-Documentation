---
title: Zarządzaj ramkami obrazu w prezentacjach na Androidzie
linktitle: Ramka obrazu
type: docs
weight: 10
url: /pl/androidjava/picture-frame/
keywords:
- ramka obrazu
- dodaj ramkę obrazu
- utwórz ramkę obrazu
- osadzony obraz
- połączony obraz
- wyodrębnij obraz
- obraz rastrowy
- obraz SVG
- przytnij obraz
- usuń przycięte obszary
- skompresuj obraz
- StretchOffset
- formatowanie ramki obrazu
- skala względna
- efekt obrazu
- proporcje
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Twórz, formatuj, łącz, przycinaj, wyodrębniaj i kompresuj ramki obrazu w prezentacjach za pomocą Aspose.Slides dla Androida w języku Java."
---
## **Przegląd**

Ramka obrazu jest kształtem slajdu, który wyświetla obraz. W Aspose.Slides zasób obrazu i kształt, który go wyświetla, są oddzielnymi obiektami: [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) posiada wbudowane zasoby obrazów poprzez swoje [IImageCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iimagecollection/), natomiast [IPictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipictureframe/) kontroluje pozycję obrazu, rozmiar, formatowanie linii, obrót, przycinanie, efekty obrazu i inne ustawienia na poziomie ramki.

To rozdzielenie jest przydatne, gdy ten sam obraz jest wyświetlany więcej niż raz. Dodaj obraz do prezentacji raz, zachowaj zwrócony [IPPImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ippimage/), i użyj tego zasobu obrazu przy tworzeniu ramek obrazu.

Ramki obrazu mogą zawierać obrazy rastrowe, takie jak PNG lub JPEG, oraz obrazy wektorowe SVG. Mogą również odwoływać się do połączonych obrazów zamiast przechowywać bajty obrazu w prezentacji. Wybór wpływa na przenośność, rozmiar pliku, wyodrębnianie i zachowanie przy eksporcie, więc warto zdecydować, jak obraz ma być przechowywany przed zastosowaniem formatowania lub optymalizacji.

## **Dodaj i sformatuj osadzony obraz**

W przypadku osadzonego obrazu dodaj dane obrazu do prezentacji i utwórz ramkę obrazu za pomocą [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). Obraz staje się częścią pakietu prezentacji, dlatego prezentacja pozostaje samodzielna po przeniesieniu na inny komputer.

Poniższy przykład dodaje obraz JPEG, tworzy ramkę o natywnych wymiarach obrazu i stosuje formatowanie linii oraz obrót:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pictureFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pictureFrame.getLineFormat().setWidth(3);
    pictureFrame.setRotation(15);

    presentation.save("picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ramka obrazu kontroluje wyświetlaną geometrię; zmiana rozmiaru ramki nie zmienia pierwotnych wymiarów w pikselach przechowywanych w osadzonym zasobie obrazu. Rozróżnienie to staje się istotne przy przycinaniu lub kompresji obrazu później.

## **Użyj skalowania względnego**

[IPictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipictureframe/) udostępnia względne skalowanie szerokości i wysokości ramki za pomocą [setRelativeScaleWidth](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) i [setRelativeScaleHeight](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). Wartość `1.0` odpowiada 100 % oryginalnego rozmiaru obrazu. Skalowanie względne jest przydatne, gdy proces wymaga zachowania relacji do rozmiaru obrazu źródłowego zamiast ręcznego obliczania ostatecznych wymiarów.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
    pictureFrame.setRelativeScaleWidth(1.35f);
    pictureFrame.setRelativeScaleHeight(0.8f);

    presentation.save("relative-scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Skalowanie względne zmienia ustawienia skali ramki; nie przetwarza ani nie kompresuje osadzonego obrazu.

## **Obrazy osadzone i połączone**

Obraz osadzony przechowuje dane obrazu wewnątrz prezentacji i jest więc najbezpieczniejszym wyborem pod kątem przenośności i przewidywalnego renderowania. Obraz połączony przechowuje zewnętrzną lokalizację przy użyciu metody [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) zamiast osadzania danych obrazu w ten sam sposób.

Połączone obrazy mogą zmniejszyć ilość danych obrazu przechowywanych w pliku PPTX, ale wprowadzają zewnętrzną zależność. Połączony plik musi pozostać dostępny dla aplikacji otwierającej lub renderującej prezentację. Jeśli ścieżka ulegnie zmianie, plik zostanie przeniesiony lub zasób będzie niedostępny, połączony obraz może nie być wyświetlany zgodnie z oczekiwaniami. Dla prezentacji, które muszą być wysyłane e‑mailem, archiwizowane lub renderowane w odizolowanych środowiskach, obrazy osadzone są zazwyczaj bardziej niezawodne.

### **Dodaj połączony obraz**

Poniższy przykład tworzy ramkę obrazu i wskazuje ją na lokalny plik obrazu. Dotyczy tylko łączenia obrazów; łączenie wideo to osobny przepływ mediów i celowo nie jest mieszany w tym przykładzie.

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
    File linkedImageFile = new File("linked-image.jpg");
    String linkPath = linkedImageFile.getAbsolutePath();
    pictureFrame.getPictureFormat().getPicture().setLinkPathLong(linkPath);

    presentation.save("linked-image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Używaj linków, gdy zarządzanie plikami zewnętrznymi jest zamierzone. Nie używaj ich jedynie jako zamiennika kompresji: mały PPTX z uszkodzonymi zależnościami obrazu jest zazwyczaj mniej przydatny niż większa, samodzielna prezentacja.

## **Wyodrębnij obrazy z ramek obrazu**

Przed wyodrębnieniem obrazu z istniejącej prezentacji sprawdź, czy kształt jest faktycznie [IPictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipictureframe/) i czy zawiera osadzony obraz. Połączone ramki obrazu mogą nie zawierać bajtów obrazu, które można wyodrębnić w ten sam sposób.

### **Wyodrębnij obraz rastrowy**

Nowoczesne API obrazów używa bezpośrednio [IImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iimage/) i nie wymaga starszego wrappera obrazu Java. Poniższy przykład znajduje pierwszy osadzony obraz rastrowy na slajdzie i zapisuje go jako PNG:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        if (embeddedImage == null || embeddedImage.getSvgImage() != null) {
            continue;
        }

        IImage rasterImage = embeddedImage.getImage();
        try {
            rasterImage.save("extracted-image.png", ImageFormat.Png);
        } finally {
            rasterImage.dispose();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

Zapisywanie za pomocą [IImage.save](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) konwertuje wyodrębnięty obraz na żądany format wyjściowy. Jeśli potrzebujesz zakodowanych bajtów przechowywanych w prezentacji, a nie skonwertowanego pliku rastrowego, użyj danych binarnych zasobu obrazu.

### **Wyodrębnij obraz SVG**

Dla obrazu SVG, [IPPImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ippimage/) udostępnia obiekt [ISvgImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isvgimage/). Pozwala to pobrać dane SVG bezpośrednio, zamiast najpierw rasteryzować obraz.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IPictureFrame)) {
            continue;
        }

        IPictureFrame pictureFrame = (IPictureFrame) shape;
        IPPImage embeddedImage = pictureFrame.getPictureFormat().getPicture().getImage();
        ISvgImage svgImage = embeddedImage != null ? embeddedImage.getSvgImage() : null;
        if (svgImage == null) {
            continue;
        }

        byte[] svgData = svgImage.getSvgData();
        FileOutputStream outputStream = new FileOutputStream("extracted-image.svg");
        try {
            outputStream.write(svgData);
        } finally {
            outputStream.close();
        }
        break;
    }
} finally {
    presentation.dispose();
}
```

Zachowanie treści SVG jako SVG zachowuje źródło wektorowe w prezentacji. Eksporty rastrowe, takie jak PNG lub JPEG, muszą renderować tę zawartość wektorową do pikseli. Eksport slajdu do PDF lub SVG również jest operacją renderowania, więc wyeksportowane grafiki nie powinny być traktowane jako dokładna kopia oryginalnego osadzonego SVG; użyj danych osadzonego [ISvgImage.getSvgData](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isvgimage/#getSvgData--) , gdy wymagany jest sam zasób wektorowy.

## **Przytnij obraz**

Przycinanie zmienia, która część obrazu jest widoczna wewnątrz ramki. Wartości przycięcia w [IPictureFillFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipicturefillformat/) są procentami wymiarów obrazu źródłowego. Przycinanie nie usuwa początkowo ukrytych pikseli z osadzonego obrazu; zmienia jedynie widoczny obszar.

Poniższy przykład bezpiecznie znajduje ramkę obrazu i stosuje wartości przycięcia:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        pictureFrame.getPictureFormat().setCropLeft(23.6f);
        pictureFrame.getPictureFormat().setCropRight(21.5f);
        pictureFrame.getPictureFormat().setCropTop(3f);
        pictureFrame.getPictureFormat().setCropBottom(31f);
        presentation.save("cropped-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Ponieważ ukryte dane obrazu nadal istnieją, przycięcie można zmienić później bez utraty oryginalnych pikseli. Jeśli rozmiar pliku jest ważniejszy niż odwracalność, przycięte obszary można fizycznie usunąć, jak opisano w następnej sekcji.

## **Usuń przycięte dane obrazu**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) usuwa dane obrazu znajdujące się poza bieżącym prostokątem przycięcia i zwraca powstały zasób obrazu. Może to zmniejszyć rozmiar pliku, ale jest to destrukcyjna optymalizacja: po zapisaniu prezentacji usunięte piksele nie są już dostępne do późniejszego odwrócenia przycięcia.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("cropped-image.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IPPImage croppedImage = pictureFrame.getPictureFormat().deletePictureCroppedAreas();
        if (croppedImage != null) {
            presentation.save("cropped-data-removed.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

Metoda może dodać nowy zasób obrazu do prezentacji. Jeśli oryginalny obraz jest również używany przez inne ramki obrazu, te ramki nadal potrzebują swojego istniejącego zasobu, więc usunięcie przyciętych obszarów niekoniecznie zmniejsza łączną liczbę obrazów. Przycinanie treści WMF lub EMF tą metodą rasteryzuje przycięty wynik do PNG.

## **Kompresuj obrazy rastrowe**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) zmniejsza rozdzielczość obrazu rastrowego w stosunku do rozmiaru, w jakim obraz jest wyświetlany. Może również usunąć przycięte obszary w tej samej operacji. Metoda zwraca `true`, gdy obraz został przeskalowany lub przycięty oraz `false`, gdy nie był potrzebny żaden zmian.

Użyj predefiniowanej wartości [PicturesCompression](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/picturescompression/) , gdy wystarczająca jest standardowa docelowa rozdzielczość:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        boolean compressed = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);
        System.out.println(compressed ? "The image was compressed." : "No compression was necessary.");
        presentation.save("compressed-image.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Można przekazać niestandardową dodatnią wartość DPI zamiast predefiniowanej wartości, gdy wymagany jest konkretny cel.

Kompresja jest przeznaczona dla obrazów rastrowych. Zawartość SVG i metaplików nie jest zmniejszana w tym przepływie kompresji rastrowej. Pamiętaj również, że niższa rozdzielczość i usunięte przycięte obszary nie mogą być odzyskane z zoptymalizowanej prezentacji. Wybierz docelową rozdzielczość na podstawie największego rozmiaru, w jakim obraz będzie faktycznie oglądany lub eksportowany, zamiast stosować najniższe DPI globalnie.

## **Zarządzaj efektami transformacji obrazu**

Aby uzyskać kompletny przepływ obejmujący jasność, kontrast, transformacje kolorów, rozmycie, efekty alfa, łańcuchy, inspekcję, usuwanie i weryfikację w dwie strony, zobacz [Image Transform Effects](/slides/pl/androidjava/image-transform-effects/).

## **Zablokuj geometrię ramki obrazu**

Ustawienia [IPictureFrameLock](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipictureframelock/) kontrolują, które operacje edycji są wyłączone dla ramki obrazu. Na przykład [setAspectRatioLocked](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) zachowuje proporcje kształtu podczas jego skalowania.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.jpg");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 100, image.getWidth(), image.getHeight(), image);
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);

    presentation.save("locked-picture-frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Blokada dotyczy kształtu ramki obrazu. Nie wymusza ona przetworzenia ani trwałej zmiany obrazu źródłowego do tego samego współczynnika proporcji.

## **Dostosuj wartości StretchOffset**

Gdy tryb wypełnienia obrazu jest rozciągnięcie, wartości stretch‑offset w [IPictureFillFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipicturefillformat/) definiują prostokąt wypełnienia względem ramki obrazu. Dodatnie procenty tworzą wcięcie od krawędzi, podczas gdy ujemne procenty tworzą występ.

Jest to inne niż przycinanie. Wartości przycięcia wybierają, która część obrazu źródłowego jest widoczna; offsety rozciągnięcia zmieniają prostokąt, w którym widoczne wypełnienie obrazu jest rozciągane.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
    pictureFrame.getPictureFormat().setPictureFillMode(PictureFillMode.Stretch);
    pictureFrame.getPictureFormat().setStretchOffsetLeft(12f);
    pictureFrame.getPictureFormat().setStretchOffsetRight(12f);
    pictureFrame.getPictureFormat().setStretchOffsetTop(8f);
    pictureFrame.getPictureFormat().setStretchOffsetBottom(8f);

    presentation.save("stretch-offsets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Używaj offsetów rozciągnięcia do pozycjonowania wypełnienia. Używaj właściwości przycięcia, gdy celem jest ukrycie krawędzi obrazu źródłowego.

## **Przechowywanie, rozmiar pliku i kwestie eksportu**

Główne kompromisy są łatwiejsze do zarządzania, gdy przechowywanie obrazów i formatowanie ramek obrazu są traktowane oddzielnie:

- **Obrazy osadzone** sprawiają, że prezentacja jest samodzielna i są najbardziej niezawodne w udostępnianiu oraz renderowaniu po stronie serwera, ale duże obrazy rastrowe zwiększają rozmiar PPTX i zużycie pamięci.
- **Obrazy połączone** mogą utrzymać pakiet mniejszy, ale prezentacja zależy od dostępności plików zewnętrznych pod zapisanymi ścieżkami lub lokalizacjami.
- **Przycinanie** jest początkowo niedestrukcyjne. Ukryte piksele pozostają osadzone, dopóki przycięte obszary nie zostaną wyraźnie usunięte lub usunięte podczas kompresji.
- **Kompresja** może znacząco zmniejszyć rozmiar pliku przy zbyt dużych obrazach rastrowych, ale kosztem rozdzielczości źródła. Powinna być zastosowana po określeniu zamierzonego rozmiaru obrazu na slajdzie.
- **Obrazy SVG** powinny pozostawać jako SVG, gdy ważne jest zachowanie wektora. Wyodrębnij osadzony SVG bezpośrednio, gdy potrzebny jest sam zasób wektorowy. Eksporty slajdów rastrowych zawsze konwertują renderowany slajd na piksele.
- **Powtarzające się obrazy** powinny ponownie wykorzystywać istniejący zasób [IPPImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ippimage/), gdy to możliwe, zamiast wielokrotnego ładowania tego samego pliku w przepływie pracy prezentacji.

W dużych prezentacjach optymalizacja obrazów jest zazwyczaj najskuteczniejsza, gdy jest przeprowadzana selektywnie: zachowaj logotypy i diagramy jako treść wektorową, kompresuj zdjęcia zgodnie z ich rzeczywistym rozmiarem wyświetlania, usuwaj przycięte piksele tylko gdy późniejsza edycja nie jest wymagana oraz unikaj linków zewnętrznych, chyba że zarządzanie zależnościami jest częścią projektu wdrożenia.

## **FAQ**

**Jaka jest różnica między ramką obrazu a zasobem obrazu?**

[IPPImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ippimage/) reprezentuje zasób obrazu powiązany z prezentacją. [IPictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipictureframe/) jest kształtem na slajdzie, który wyświetla obraz i przechowuje geometrię oraz formatowanie na poziomie ramki, takie jak rozmiar, obrót, wartości przycięcia, efekty i blokady.

**Czy powinienem osadzać, czy łączyć obrazy?**

Osadzaj obrazy, gdy prezentacja musi być przenośna, archiwizowana lub renderowana bez dostępu do zasobów zewnętrznych. Łącz obrazy tylko wtedy, gdy zamierzone jest przechowywanie plików obrazu poza PPTX i zewnętrzne lokalizacje mogą być utrzymywane wiarygodnie.

**Czy przycinanie zmniejsza rozmiar pliku PPTX?**

Nie samo w sobie. Normalne ustawienia przycięcia ukrywają część obrazu źródłowego, ale zachowują ukryte piksele. Użyj [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) lub kompresji obrazu z usunięciem przyciętych obszarów, gdy te piksele można trwale odrzucić.

**Czy mogę przywrócić jakość obrazu po kompresji?**

Nie. Kompresja może obniżyć przechowywaną rozdzielczość rastrową, a usunięcie przyciętych obszarów odrzuca dane obrazu. Zachowaj oryginalny obraz źródłowy poza prezentacją, jeśli później może być potrzebna edycja w wysokiej rozdzielczości.

**Jak należy postępować z obrazami SVG?**

Zachowuj zawartość SVG jako SVG, gdy ważna jest wierność wektora. Osadzony [ISvgImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isvgimage/) może być wyodrębniony bezpośrednio. Renderowanie slajdu do formatu rastrowego, takiego jak PNG lub JPEG, rasteryzuje SVG jako część obrazu slajdu.

**Jak uniknąć niebezpiecznych rzutowań przy odczytywaniu istniejących slajdów?**

Sprawdź typ kształtu przed użyciem członków specyficznych dla ramki obrazu. Sprawdzenie `instanceof` względem [IPictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipictureframe/) unika nieprawidłowych rzutowań i pozwala kodowi obsługiwać slajdy, które nie zawierają ramek obrazu.