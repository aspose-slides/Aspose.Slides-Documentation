---
title: Zarządzanie ramkami obrazów w prezentacjach przy użyciu Javy
linktitle: Ramka obrazu
type: docs
weight: 10
url: /pl/java/picture-frame/
keywords:
- ramka obrazu
- dodaj ramkę obrazu
- utwórz ramkę obrazu
- osadzony obraz
- powiązany obraz
- wyodrębnij obraz
- obraz rastrowy
- obraz SVG
- przytnij obraz
- usuń przycięte obszary
- kompresuj obraz
- StretchOffset
- formatowanie ramki obrazu
- skala względna
- efekt obrazu
- proporcje obrazu
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Twórz, formatuj, łącz, przycinaj, wyodrębniaj i kompresuj ramki obrazu w prezentacjach przy użyciu Aspose.Slides dla Javy."
---
## **Przegląd**

Ramka obrazu jest kształtem slajdu wyświetlającym obraz. W Aspose.Slides zasób obrazu i kształt, który go wyświetla, są odrębnymi obiektami: [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/) posiada osadzone zasoby obrazów poprzez swoje [IImageCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimagecollection/), podczas gdy [IPictureFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipictureframe/) kontroluje pozycję obrazu, rozmiar, formatowanie linii, obrót, przycinanie, efekty obrazu i inne ustawienia na poziomie ramki.

To rozdzielenie jest przydatne, gdy ten sam obraz jest wyświetlany więcej niż raz. Dodaj obraz do prezentacji raz, zachowaj zwrócony [IPPImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ippimage/), i użyj tego zasobu obrazu przy tworzeniu ramek obrazu.

Ramki obrazu mogą zawierać obrazy rastrowe, takie jak PNG lub JPEG, oraz obrazy wektorowe SVG. Mogą również odwoływać się do powiązanych obrazów zamiast przechowywania bajtów obrazu w prezentacji. Wybór wpływa na przenośność, rozmiar pliku, wyodrębnianie i zachowanie podczas eksportu, więc warto zdecydować, jak obraz ma być przechowywany przed zastosowaniem formatowania lub optymalizacji.

## **Dodaj i formatuj osadzony obraz**

Dla osadzonego obrazu dodaj dane obrazu do prezentacji i utwórz ramkę obrazu przy użyciu [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). Obraz staje się częścią pakietu prezentacji, więc prezentacja pozostaje samodzielna po przeniesieniu na inny komputer.

Poniższy przykład dodaje obraz JPEG, tworzy ramkę w natywnych wymiarach obrazu i stosuje formatowanie linii oraz obrót:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Ramka obrazu kontroluje wyświetlaną geometrię; zmiana rozmiaru ramki nie zmienia oryginalnych wymiarów pikseli przechowywanych w osadzonym zasobie obrazu. Rozróżnienie to staje się istotne podczas przycinania lub kompresji obrazu w późniejszym etapie.

## **Użyj skali względnej**

[IPictureFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipictureframe/) udostępnia skalowanie względne szerokości i wysokości ramki za pomocą [setRelativeScaleWidth](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) i [setRelativeScaleHeight](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). Wartość `1.0` odpowiada 100 % pierwotnego rozmiaru obrazu. Skala względna jest przydatna, gdy proces wymaga zachowania zależności od rozmiaru obrazu źródłowego zamiast ręcznego obliczania ostatecznych wymiarów.

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

Skala względna zmienia ustawienia skali ramki; nie przetwarza ani nie kompresuje osadzonego obrazu.

## **Osadzone i powiązane obrazy**

Osadzony obraz przechowuje dane obrazu wewnątrz prezentacji i dlatego jest najbezpieczniejszym wyborem pod względem przenośności i przewidywalnego renderowania. Powiązany obraz przechowuje zewnętrzną lokalizację za pomocą metody [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/pl/java/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) zamiast osadzania danych obrazu w ten sam sposób.

Powiązane obrazy mogą zmniejszyć ilość danych obrazu przechowywanych w pliku PPTX, ale wprowadzają zależność zewnętrzną. Powiązany plik musi pozostać dostępny dla aplikacji otwierającej lub renderującej prezentację. Jeśli ścieżka się zmieni, plik zostanie przeniesiony lub zasób będzie niedostępny, powiązany obraz może nie zostać wyświetlony zgodnie z oczekiwaniami. Dla prezentacji, które muszą być wysyłane e‑mailem, archiwizowane lub renderowane w odizolowanych środowiskach, obrazy osadzone są zazwyczaj bardziej niezawodne.

### **Dodaj powiązany obraz**

Poniższy przykład tworzy ramkę obrazu i wskazuje na lokalny plik obrazu. Dotyczy wyłącznie powiązania obrazu; powiązanie wideo jest odrębnym procesem multimedialnym i celowo nie jest tutaj mieszane.

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

Używaj powiązań, gdy zarządzanie plikami zewnętrznymi jest zamierzone. Nie stosuj ich jedynie jako zamiennika kompresji: mały plik PPTX z uszkodzonymi zależnościami obrazu jest zwykle mniej użyteczny niż większa, samodzielna prezentacja.

## **Wyodrębnij obrazy z ramek obrazu**

Przed wyodrębnieniem obrazu z istniejącej prezentacji sprawdź, czy kształt jest rzeczywiście [IPictureFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipictureframe/) i czy zawiera osadzony obraz. Powiązane ramki obrazu mogą nie zawierać bajtów obrazu, które można wyodrębnić w ten sam sposób.

### **Wyodrębnij obraz rastrowy**

Nowoczesny interfejs API obrazu używa bezpośrednio [IImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimage/) i nie wymaga starszego wrappera Java. Poniższy przykład znajduje pierwszy osadzony obraz rastrowy na slajdzie i zapisuje go jako PNG:

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

Zapisanie przy użyciu [IImage.save](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimage/#save-java.lang.String-int-) konwertuje wyodrębniony obraz do żądanego formatu wyjściowego. Jeśli potrzebujesz zakodowanych bajtów przechowywanych w prezentacji zamiast przekonwertowanego pliku rastrowego, użyj danych binarnych zasobu obrazu.

### **Wyodrębnij obraz SVG**

Dla obrazu SVG [IPPImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ippimage/) udostępnia obiekt [ISvgImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isvgimage/). Umożliwia to bezpośrednie pobranie danych SVG zamiast rasteryzacji obrazu najpierw.

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

Zachowanie treści SVG jako SVG zachowuje wektorowe źródło w prezentacji. Eksporty rastrowe, takie jak PNG lub JPEG, koniecznie renderują tę zawartość wektorową do pikseli. Eksport slajdu do PDF lub SVG również jest operacją renderowania, więc wyeksportowana grafika nie powinna być traktowana jako bit‑do‑bitu kopia oryginalnego osadzonego SVG; użyj danych [ISvgImage.getSvgData](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isvgimage/#getSvgData--) gdy wymagana jest oryginalna wektorowa zasób.

## **Przytnij obraz**

Przycinanie zmienia, która część obrazu jest widoczna wewnątrz ramki. Wartości przycięcia na [IPictureFillFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipicturefillformat/) są procentami wymiarów obrazu źródłowego. Przycinanie nie usuwa początkowo ukrytych pikseli z osadzonego obrazu; zmienia jedynie widoczny obszar.

Poniższy przykład znajduje ramkę obrazu w bezpieczny sposób i stosuje wartości przycięcia:

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

Ponieważ ukryte dane obrazu nadal istnieją, przycięcie może być zmienione później bez utraty oryginalnych pikseli. Jeśli rozmiar pliku ma większe znaczenie niż możliwość odwrócenia, przycięte obszary można fizycznie usunąć, jak opisano w następnej sekcji.

## **Usuń przycięte dane obrazu**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) usuwa dane obrazu znajdujące się poza aktualnym prostokątem przycięcia i zwraca wynikowy zasób obrazu. Może to zmniejszyć rozmiar pliku, ale jest destrukcyjną optymalizacją: po zapisaniu prezentacji usunięte piksele nie są już dostępne do późniejszej operacji przywracania.

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

Metoda może dodać nowy zasób obrazu do prezentacji. Jeśli pierwotny obraz jest również używany przez inne ramki obrazu, te ramki nadal potrzebują swojego istniejącego zasobu, więc usunięcie przyciętych obszarów niekoniecznie zmniejsza łączną liczbę obrazów. Przycinanie zawartości WMF lub EMF tą metodą rasteryzuje przycięty wynik do PNG.

## **Kompresuj obrazy rastrowe**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) zmniejsza rozdzielczość obrazu rastrowego względem rozmiaru, w jakim obraz jest wyświetlany. Może również usuwać przycięte obszary w tej samej operacji. Metoda zwraca `true`, gdy obraz został zmieniony rozmiaru lub przycięty, oraz `false`, gdy zmiana nie była wymagana.

Użyj predefiniowanej wartości [PicturesCompression](https://reference.aspose.com/slides/pl/java/com.aspose.slides/picturescompression/) gdy wystarcza standardowa docelowa rozdzielczość:

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

Zamiast predefiniowanej wartości można podać własną dodatnią wartość DPI, gdy wymagana jest konkretna rozdzielczość docelowa.

Kompresja jest przeznaczona dla obrazów rastrowych. Treść SVG i metafili nie jest zmniejszana przez ten proces kompresji rastra. Pamiętaj również, że niższa rozdzielczość i usunięte przycięte regiony nie mogą być odzyskane z zoptymalizowanej prezentacji. Wybieraj docelową rozdzielczość na podstawie największego rozmiaru, w jakim obraz będzie faktycznie oglądany lub eksportowany, zamiast stosować najniższe DPI globalnie.

## **Zarządzaj efektami transformacji obrazu**

Pełny proces obejmujący jasność, kontrast, transformacje kolorów, rozmycie, efekty alfa, łańcuchy kolejności, inspekcję, usuwanie i weryfikację dwukierunkową znajduje się w [Image Transform Effects](/java/image-transform-effects/).

## **Zablokuj geometrię ramki obrazu**

Ustawienia [IPictureFrameLock](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipictureframelock/) określają, które operacje edycji są wyłączone dla ramki obrazu. Na przykład [setAspectRatioLocked](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) zachowuje proporcje kształtu podczas zmiany jego rozmiaru.

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

Blokada dotyczy kształtu ramki obrazu. Nie wymusza ona ponownego próbkowania ani trwałej zmiany proporcji obrazu źródłowego.

## **Dostosuj wartości StretchOffset**

Gdy tryb wypełnienia obrazu jest rozciągnięty, wartości stretch‑offset na [IPictureFillFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipicturefillformat/) definiują prostokąt wypełnienia względem ramki obrazu. Dodatnie procenty tworzą wcięcie od krawędzi, a ujemne procenty tworzą występ.

To różni się od przycinania. Wartości przycięcia określają, która część obrazu źródłowego jest widoczna; offsety rozciągania zmieniają prostokąt, w którym widoczne wypełnienie obrazu jest rozciągane.

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

Używaj offsetów rozciągania do pozycjonowania wypełnienia. Stosuj właściwości przycięcia, gdy celem jest ukrycie krawędzi obrazu źródłowego.

## **Przechowywanie, rozmiar pliku i uwagi przy eksporcie**

Główne kompromisy są łatwiejsze do zarządzania, gdy przechowywanie obrazu i formatowanie ramki obrazu są traktowane oddzielnie:

- **Osadzone obrazy** sprawiają, że prezentacja jest samodzielna i są najpewniejsze przy udostępnianiu oraz renderowaniu po stronie serwera, ale duże obrazy rastrowe zwiększają rozmiar PPTX i zużycie pamięci.
- **Powiązane obrazy** mogą utrzymać paczkę mniejszą, lecz prezentacja zależy od dostępności plików zewnętrznych pod zapisanymi ścieżkami lub lokalizacjami.
- **Przycinanie** początkowo jest niedestrukcyjne. Ukryte piksele pozostają osadzone, dopóki przycięte obszary nie zostaną jawnie usunięte lub usunięte podczas kompresji.
- **Kompresja** może znacznie zmniejszyć rozmiar pliku przy przeskalowanych obrazach rastrowych, ale kosztem utraty rozdzielczości źródłowej. Powinna być stosowana po określeniu docelowego rozmiaru na slajdzie.
- **Obrazy SVG** powinny pozostawać jako SVG, gdy ważne jest zachowanie wektora. Wyodrębnij osadzony SVG bezpośrednio, gdy potrzebny jest sam wektor. Eksport slajdów do formatu rastrowego zawsze konwertuje renderowany slajd do pikseli.
- **Powtarzane obrazy** powinny ponownie wykorzystywać istniejący zasób [IPPImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ippimage/), gdy to możliwe, zamiast wielokrotnego ładowania tego samego pliku w procesie tworzenia prezentacji.

W dużych prezentacjach optymalizacja obrazu jest najskuteczniejsza przy wyborowym podejściu: zachowuj logotypy i diagramy jako treść wektorową, kompresuj zdjęcia zgodnie z ich rzeczywistym rozmiarem wyświetlania, usuwaj przycięte piksele tylko wtedy, gdy późniejsza edycja nie jest wymagana, i unikaj zewnętrznych linków, chyba że zarządzanie zależnościami jest częścią projektu wdrożenia.

## **FAQ**

**Jaka jest różnica między ramką obrazu a zasobem obrazu?**

[IPPImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ippimage/) reprezentuje zasób obrazu powiązany z prezentacją. [IPictureFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipictureframe/) jest kształtem na slajdzie, który wyświetla obraz i przechowuje ustawienia ramki, takie jak rozmiar, obrót, wartości przycięcia, efekty i blokady.

**Czy powinienem osadzać czy linkować obrazy?**

Osadzaj obrazy, gdy prezentacja musi być przenośna, archiwizowana lub renderowana bez dostępu do zasobów zewnętrznych. Linkuj obrazy wyłącznie wtedy, gdy umieszczenie plików obrazu poza PPTX jest zamierzone i zewnętrzne lokalizacje mogą być utrzymywane w sposób niezawodny.

**Czy przycinanie zmniejsza rozmiar pliku PPTX?**

Nie samo w sobie. Normalne ustawienia przycięcia ukrywają części obrazu źródłowego, ale zachowują podległe piksele. Użyj [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) lub kompresji obrazu z usuwaniem przyciętych obszarów, gdy te piksele mogą być trwale odrzucone.

**Czy mogę przywrócić jakość obrazu po kompresji?**

Nie. Kompresja może obniżyć przechowywaną rozdzielczość rastrową, a usunięcie przyciętych regionów eliminuje dane obrazu. Przechowuj oryginalny obraz poza prezentacją, jeśli później może być potrzebna edycja w wysokiej rozdzielczości.

**Jak należy postępować z obrazami SVG?**

Zachowuj treść SVG jako SVG, gdy istotna jest wierność wektora. Osadzony [ISvgImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/isvgimage/) może być wyodrębniony bezpośrednio. Renderowanie slajdu do formatu rastrowego, takiego jak PNG lub JPEG, rasteryzuje SVG jako część obrazu slajdu.

**Jak uniknąć niebezpiecznych rzutowań przy czytaniu istniejących slajdów?**

Sprawdzaj typ kształtu przed użyciem członków specyficznych dla ramki obrazu. Kontrola `instanceof` względem [IPictureFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipictureframe/) zapobiega nieprawidłowym rzutowaniom i pozwala obsłużyć slajdy, które nie zawierają ramek obrazu.