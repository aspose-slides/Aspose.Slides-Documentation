---
title: Zarządzanie ramkami obrazu w prezentacjach na Androidzie
linktitle: Ramka obrazu
type: docs
weight: 10
url: /pl/androidjava/picture-frame/
keywords:
- ramka obrazu
- dodawanie ramki obrazu
- tworzenie ramki obrazu
- osadzony obraz
- powiązany obraz
- wyodrębnianie obrazu
- obraz rastrowy
- obraz SVG
- przycinanie obrazu
- usuwanie przyciętych obszarów
- kompresja obrazu
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
description: "Utwórz, formatuj, łącz, przycinaj, wyodrębniaj i kompresuj ramki obrazu w prezentacjach przy użyciu Aspose.Slides dla Androida w Javie."
---
## **Przegląd**

Ramka obrazu jest kształtem slajdu, który wyświetla obraz. W Aspose.Slides zasób obrazu i kształt, który go wyświetla, są oddzielnymi obiektami: [Prezentacja](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) posiada osadzone zasoby obrazu poprzez swoją [IImageCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iimagecollection/), natomiast [IPictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipictureframe/) kontroluje pozycję obrazu, rozmiar, formatowanie linii, obrót, przycinanie, efekty obrazu i inne ustawienia na poziomie ramki.

To rozdzielenie jest przydatne, gdy ten sam obraz jest wyświetlany więcej niż raz. Dodaj obraz do prezentacji raz, zachowaj zwrócony [IPPImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ippimage/), i używaj tego zasobu obrazu przy tworzeniu ramek obrazu.

Ramki obrazu mogą zawierać obrazy rastrowe, takie jak PNG lub JPEG, oraz wektorowe obrazy SVG. Mogą również odwoływać się do obrazów powiązanych zamiast przechowywać bajty obrazu w prezentacji. Wybór wpływa na przenośność, rozmiar pliku, ekstrakcję i zachowanie przy eksporcie, więc warto zdecydować, jak obraz ma być przechowywany, zanim zastosuje się formatowanie lub optymalizację.

## **Dodawanie i formatowanie osadzonego obrazu**

W przypadku obrazu osadzonego dodaj dane obrazu do prezentacji i utwórz ramkę obrazu za pomocą [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). Obraz staje się częścią pakietu prezentacji, więc prezentacja pozostaje samodzielna po przeniesieniu na inny komputer.

Poniższy przykład dodaje obraz JPEG, tworzy ramkę w natywnych wymiarach obrazu i stosuje formatowanie linii oraz obrót:

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

Ramka obrazu kontroluje wyświetlaną geometrię; zmiana rozmiaru ramki nie zmienia oryginalnych wymiarów pikseli przechowywanych w osadzonym zasobie obrazu. Rozróżnienie to staje się istotne przy późniejszym przycinaniu lub kompresji obrazu.

## **Używanie skali względnej**

[IPictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipictureframe/) udostępnia skalowanie względne szerokości i wysokości ramki poprzez [setRelativeScaleWidth](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) i [setRelativeScaleHeight](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). Wartość `1.0` odpowiada 100 % oryginalnego rozmiaru obrazu. Skala względna jest przydatna, gdy workflow wymaga zachowania zależności od rozmiaru obrazu źródłowego zamiast ręcznego obliczania końcowych wymiarów.

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

Skala względna zmienia ustawienia skalowania ramki; nie przetwarza ani nie kompresuje osadzonego obrazu.

## **Osadzone i powiązane obrazy**

Osadzony obraz przechowuje dane obrazu wewnątrz prezentacji i jest więc najbezpieczniejszym wyborem pod względem przenośności i przewidywalnego renderowania. Obraz powiązany przechowuje zewnętrzną lokalizację za pomocą metody [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) zamiast osadzania danych obrazu w ten sam sposób.

Obrazy powiązane mogą zmniejszyć ilość danych obrazu przechowywanych w pliku PPTX, ale wprowadzają zewnętrzną zależność. Plik powiązany musi pozostać dostępny dla aplikacji otwierającej lub renderującej prezentację. Jeśli ścieżka się zmieni, plik zostanie przeniesiony lub zasób będzie niedostępny, powiązany obraz może nie zostać wyświetlony zgodnie z oczekiwaniami. Dla prezentacji, które muszą być wysyłane e‑mailem, archiwizowane lub renderowane w odizolowanych środowiskach, obrazy osadzone są zazwyczaj bardziej niezawodne.

### **Dodawanie obrazu powiązanego**

Poniższy przykład tworzy ramkę obrazu i wskazuje ją na lokalny plik obrazu. Dotyczy wyłącznie wiązania obrazu; wiązanie wideo to oddzielny workflow mediów i celowo nie jest tutaj mieszane.

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

Używaj linków, gdy zarządzanie plikami zewnętrznymi jest zamierzone. Nie używaj ich wyłącznie jako zamiennika kompresji: mały plik PPTX z uszkodzonymi zależnościami obrazu jest zazwyczaj mniej użyteczny niż większa, samodzielna prezentacja.

## **Ekstrahowanie obrazów z ramek obrazu**

Przed wyekstrawowaniem obrazu z istniejącej prezentacji sprawdź, czy kształt jest faktycznie [IPictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipictureframe/) i czy zawiera osadzony obraz. Powiązane ramki obrazu mogą nie zawierać bajtów obrazu, które można wyekstrahować w ten sam sposób.

### **Ekstrahowanie obrazu rastrowego**

Nowoczesne API obrazu używa [IImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iimage/) bezpośrednio i nie wymaga starszego wrappera Java. Poniższy przykład znajduje pierwszy osadzony rastrowy obraz na slajdzie i zapisuje go jako PNG:

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

Zapisywanie za pomocą [IImage.save](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) konwertuje wyekstrahowany obraz do żądanego formatu wyjściowego. Jeśli potrzebujesz zakodowanych bajtów przechowywanych w prezentacji, a nie przekonwertowanego pliku rastrowego, użyj binarnych danych zasobu obrazu.

### **Ekstrahowanie obrazu SVG**

Dla obrazu SVG, [IPPImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ippimage/) udostępnia obiekt [ISvgImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isvgimage/). Pozwala to pobrać dane SVG bezpośrednio, zamiast rasteryzować obraz najpierw.

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

Zachowanie treści SVG jako SVG zachowuje wektorowe źródło w prezentacji. Eksporty rastrowe, takie jak PNG lub JPEG, muszą renderować tę wektorową treść do pikseli. Eksport slajdu do PDF lub SVG jest również operacją renderowania, więc wyeksportowane grafiki nie powinny być traktowane jako dokładna kopia oryginalnego osadzonego SVG; użyj danych [ISvgImage.getSvgData](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isvgimage/#getSvgData--) gdy wymagany jest sam wektorowy zasób.

## **Przycinanie obrazu**

Przycinanie zmienia, która część obrazu jest widoczna wewnątrz ramki. Wartości przycięcia na [IPictureFillFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipicturefillformat/) są procentami wymiarów obrazu źródłowego. Przycinanie nie usuwa początkowo ukrytych pikseli z osadzonego obrazu; zmienia jedynie widoczny region.

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

Ponieważ ukryte dane obrazu nadal istnieją, przycięcie może być zmieniane później bez utraty oryginalnych pikseli. Jeśli rozmiar pliku ma większe znaczenie niż odwracalność, przycięte obszary mogą być fizycznie usunięte, jak opisano w następnej sekcji.

## **Usuwanie przyciętych danych obrazu**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) usuwa dane obrazu poza aktualnym prostokątem przycięcia i zwraca wynikowy zasób obrazu. Może to zmniejszyć rozmiar pliku, ale jest to destrukcyjna optymalizacja: po zapisaniu prezentacji usunięte piksele nie są już dostępne do późniejszej operacji odprzycinania.

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

Metoda może dodać nowy zasób obrazu do prezentacji. Jeśli oryginalny obraz jest również używany przez inne ramki obrazu, te ramki nadal potrzebują swojego istniejącego zasobu, więc usuwanie przyciętych obszarów niekoniecznie redukuje łączną liczbę obrazów. Przycinanie zawartości WMF lub EMF tą metodą rasteryzuje przycięty wynik do PNG.

## **Kompresja obrazów rastrowych**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) zmniejsza rozdzielczość obrazu rastrowego względem rozmiaru, w jakim obraz jest wyświetlany. Może także usunąć przycięte regiony w tej samej operacji. Metoda zwraca `true`, gdy obraz został przeskalowany lub przycięty oraz `false`, gdy nie było konieczności zmiany.

Użyj predefiniowanej wartości [PicturesCompression](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/picturescompression/), gdy wystarczy standardowa docelowa rozdzielczość:

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

Kompresja przeznaczona jest dla obrazów rastrowych. Zawartość SVG i metaplików nie jest zmniejszana przez ten workflow kompresji rastrowej. Pamiętaj także, że niższa rozdzielczość i usunięte przycięte regiony nie mogą być odzyskane z zoptymalizowanej prezentacji. Wybieraj docelową rozdzielczość w oparciu o największy rozmiar, w którym obraz będzie faktycznie oglądany lub eksportowany, zamiast stosować najniższe DPI globalnie.

## **Zarządzanie efektami transformacji obrazu**

Kompletny workflow obejmujący jasność, kontrast, transformacje kolorów, rozmycie, efekty alfa, łańcuchy zamówień, inspekcję, usuwanie i weryfikację dwukierunkową znajdziesz w [Image Transform Effects](/androidjava/image-transform-effects/).

## **Zablokowanie geometrii ramki obrazu**

Ustawienia [IPictureFrameLock](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipictureframelock/) kontrolują, które operacje edycji są wyłączone dla ramki obrazu. Na przykład [setAspectRatioLocked](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) zachowuje proporcje kształtu podczas zmiany jego rozmiaru.

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

Blokada dotyczy kształtu ramki obrazu. Nie wymusza ona ponownego próbkowania źródłowego obrazu ani trwałej zmiany jego proporcji.

## **Dostosowanie wartości StretchOffset**

Gdy tryb wypełnienia obrazu jest rozciągnięty, wartości stretch‑offset na [IPictureFillFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipicturefillformat/) definiują prostokąt wypełnienia względem ramki obrazu. Dodatnie procenty tworzą wcięcie od krawędzi, a ujemne procenty tworzą występ.

Jest to inne niż przycinanie. Wartości przycięcia wybierają, która część obrazu źródłowego jest widoczna; offsety rozciągania zmieniają prostokąt, do którego widoczne wypełnienie obrazu jest rozciągane.

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

Używaj offsetów rozciągania do umieszczania wypełnienia. Używaj właściwości przycięcia, gdy celem jest ukrycie krawędzi obrazu źródłowego.

## **Przechowywanie, rozmiar pliku i uwagi przy eksporcie**

Główne kompromisy są łatwiejsze do zarządzania, gdy przechowywanie obrazu i formatowanie ramki obrazu są traktowane oddzielnie:

- **Obrazy osadzone** czynią prezentację samodzielną i są najniebardziej niezawodne przy udostępnianiu i renderowaniu po stronie serwera, ale duże obrazy rastrowe zwiększają rozmiar PPTX i zużycie pamięci.
- **Obrazy powiązane** mogą utrzymać paczkę mniejszą, ale prezentacja zależy od dostępności plików zewnętrznych pod przechowywanymi ścieżkami lub lokalizacjami.
- **Przycinanie** jest początkowo niedestruktywne. Ukryte piksele pozostają osadzone, aż do momentu, gdy przycięte obszary zostaną wyraźnie usunięte lub usunięte podczas kompresji.
- **Kompresja** może znacząco zmniejszyć rozmiar pliku przy zbyt dużych obrazach rastrowych, ale kosztem utraty rozdzielczości źródła. Powinna być stosowana po ustaleniu docelowego rozmiaru obrazu na slajdzie.
- **Obrazy SVG** powinny pozostać jako SVG, gdy ważne jest zachowanie wektora. Wyodrębnij osadzony SVG bezpośrednio, gdy potrzebujesz samego zasobu wektorowego. Eksport slajdu do formatu rastrowego zawsze konwertuje renderowany slajd do pikseli.
- **Powtarzające się obrazy** powinny ponownie wykorzystywać istniejący zasób [IPPImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ippimage/), gdy to możliwe, zamiast wielokrotnego ładowania tego samego pliku w workflow prezentacji.

W dużych prezentacjach optymalizacja obrazów jest najskuteczniejsza, gdy jest stosowana selektywnie: trzymaj loga i diagramy jako treść wektorową, kompresuj fotografie zgodnie z ich rzeczywistym rozmiarem wyświetlania, usuwaj przycięte piksele tylko wtedy, gdy późniejsza edycja nie jest wymagana, i unikaj linków zewnętrznych, chyba że zarządzanie zależnościami jest częścią projektu wdrożenia.

## **FAQ**

**Jaka jest różnica między ramką obrazu a zasobem obrazu?**

[IPPImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ippimage/) reprezentuje zasób obrazu powiązany z prezentacją. [IPictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipictureframe/) jest kształtem na slajdzie, który wyświetla obraz i przechowuje geometrię oraz formatowanie na poziomie ramki, takie jak rozmiar, obrót, wartości przycięcia, efekty i blokady.

**Czy powinienem osadzać, czy łączyć obrazy?**

Osadzaj obrazy, gdy prezentacja musi być przenośna, archiwizowana lub renderowana bez dostępu do zasobów zewnętrznych. Łącz obrazy tylko wtedy, gdy utrzymywanie plików obrazu poza PPTX jest zamierzone i zewnętrzne lokalizacje mogą być utrzymane w sposób niezawodny.

**Czy przycinanie zmniejsza rozmiar pliku PPTX?**

Nie samo w sobie. Normalne ustawienia przycięcia ukrywają części obrazu źródłowego, ale zachowują ukryte piksele. Użyj [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) lub kompresji obrazu z usuwaniem przyciętych obszarów, gdy te piksele mogą być trwale odrzucone.

**Czy mogę przywrócić jakość obrazu po kompresji?**

Nie. Kompresja może zmniejszyć przechowywaną rozdzielczość rastrową, a usunięcie przyciętych regionów usuwa dane obrazu. Trzymaj oryginalny obraz źródłowy poza prezentacją, jeśli później może być potrzebna edycja w wysokiej rozdzielczości.

**Jak postępować z obrazami SVG?**

Zachowuj treść SVG jako SVG, gdy liczy się wierność wektora. Osadzony [ISvgImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isvgimage/) może być wyodrębniony bezpośrednio. Renderowanie slajdu do formatu rastrowego, takiego jak PNG lub JPEG, rasteryzuje SVG jako część obrazu slajdu.

**Jak uniknąć niebezpiecznych rzutowań przy odczytywaniu istniejących slajdów?**

Sprawdzaj typ kształtu przed użyciem członków specyficznych dla ramki obrazu. Rzutowanie `instanceof` na [IPictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipictureframe/) zapobiega nieprawidłowym rzutowaniom i pozwala kodowi obsłużyć slajdy, które nie zawierają ramek obrazu.