---
title: Zarządzanie ramkami obrazu w prezentacjach na Androidzie
linktitle: Ramka obrazu
type: docs
weight: 10
url: /pl/androidjava/picture-frame/
keywords:
- ramka obrazu
- dodaj ramkę obrazu
- utwórz ramkę obrazu
- obraz osadzony
- obraz połączony
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
- proporcje
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Twórz, formatuj, łącz, przycinaj, wyodrębniaj i kompresuj ramki obrazu w prezentacjach przy użyciu Aspose.Slides dla Androidu w Javie."
---
## **Przegląd**

Ramka obrazu jest kształtem slajdu wyświetlającym obraz. W Aspose.Slides zasób obrazu i kształt go wyświetlający są oddzielnymi obiektami: [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/) posiada osadzone zasoby obrazu poprzez swoją [IImageCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iimagecollection/), natomiast [IPictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipictureframe/) steruje pozycją obrazu, jego rozmiarem, formatowaniem linii, obrotem, przycinaniem, efektami obrazu i innymi ustawieniami na poziomie ramki.

To rozdzielenie jest przydatne, gdy ten sam obraz jest wyświetlany więcej niż raz. Dodaj obraz do prezentacji raz, zachowaj zwrócony [IPPImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ippimage/), i użyj tego zasobu obrazu przy tworzeniu ramek obrazu.

Ramki obrazu mogą zawierać obrazy rastrowe, takie jak PNG lub JPEG, oraz obrazy wektorowe SVG. Mogą także odwoływać się do połączonych obrazów zamiast przechowywać bajty obrazu w prezentacji. Wybór wpływa na przenośność, rozmiar pliku, wyodrębnianie i zachowanie przy eksporcie, dlatego warto zdecydować, jak obraz ma być przechowywany przed zastosowaniem formatowania lub optymalizacji.

## **Dodawanie i formatowanie osadzonego obrazu**

W przypadku osadzonego obrazu dodaj dane obrazu do prezentacji i utwórz ramkę obrazu przy użyciu [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-). Obraz staje się częścią pakietu prezentacji, więc prezentacja pozostaje samodzielna po przeniesieniu na inny komputer.

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

Ramka obrazu kontroluje wyświetlaną geometrię; zmiana rozmiaru ramki nie zmienia pierwotnych wymiarów pikseli przechowywanych w osadzonym zasobie obrazu. Rozróżnienie to staje się istotne przy późniejszym przycinaniu lub kompresji obrazu.

## **Użycie skali względnej**

[IPictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipictureframe/) udostępnia skalowanie szerokości i wysokości względne dla ramki poprzez [setRelativeScaleWidth](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleWidth-float-) i [setRelativeScaleHeight](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipictureframe/#setRelativeScaleHeight-float-). Wartość `1.0` odpowiada 100 % oryginalnego rozmiaru obrazu. Skala względna jest przydatna, gdy przepływ pracy wymaga zachowania zależności od rozmiaru obrazu źródłowego zamiast ręcznego obliczania wymiarów końcowych.

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

## **Obrazy osadzone i połączone**

Obraz osadzony przechowuje dane obrazu wewnątrz prezentacji i jest więc najbezpieczniejszym wyborem pod względem przenośności i przewidywalnego renderowania. Obraz połączony przechowuje zewnętrzną lokalizację za pomocą metody [ISlidesPicture.setLinkPathLong](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/islidespicture/#setLinkPathLong-java.lang.String-) zamiast osadzania danych obrazu w ten sam sposób.

Obrazy połączone mogą zmniejszyć ilość danych obrazu przechowywanych w pliku PPTX, ale wprowadzają zależność zewnętrzną. Połączony plik musi pozostać dostępny dla aplikacji otwierającej lub renderującej prezentację. Jeśli ścieżka ulegnie zmianie, plik zostanie przeniesiony lub zasób stanie się niedostępny, połączony obraz może nie zostać wyświetlony zgodnie z oczekiwaniami. Dla prezentacji, które muszą być wysyłane e‑mailem, archiwizowane lub renderowane w odizolowanych środowiskach, obrazy osadzone są zazwyczaj bardziej niezawodne.

### **Dodawanie obrazu połączonego**

Poniższy przykład tworzy ramkę obrazu i wskazuje ją na lokalny plik obrazu. Zajmuje się wyłącznie łączeniem obrazu; łączenie wideo to osobny przepływ multimedialny, który celowo nie jest mieszany w tym przykładzie.

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

Używaj linków, gdy zarządzanie plikami zewnętrznymi jest zamierzone. Nie używaj ich jedynie jako zamiennika kompresji: mały plik PPTX z zepsutymi zależnościami obrazu jest zwykle mniej przydatny niż większa, samodzielna prezentacja.

## **Wyodrębnianie obrazów z ramek obrazu**

Przed wyodrębnieniem obrazu z istniejącej prezentacji sprawdź, czy kształt jest rzeczywiście [IPictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipictureframe/) i czy zawiera osadzony obraz. Połączone ramki obrazu mogą nie zawierać bajtów obrazu, które można wyodrębnić w ten sam sposób.

### **Wyodrębnianie obrazu rastrowego**

Nowoczesne API obrazu używa [IImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iimage/) bezpośrednio i nie wymaga starszego opakowania Java. Poniższy przykład znajduje pierwszy osadzony rasterowy obraz na slajdzie i zapisuje go jako PNG:

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

Zapisywanie przez [IImage.save](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) konwertuje wyodrębniony obraz na żądany format wyjściowy. Jeśli potrzebujesz zakodowanych bajtów przechowywanych w prezentacji, a nie przekonwertowanego pliku rastrowego, użyj binarnych danych zasobu obrazu.

### **Wyodrębnianie obrazu SVG**

W przypadku obrazu SVG, [IPPImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ippimage/) udostępnia obiekt [ISvgImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isvgimage/). Pozwala to pobrać dane SVG bezpośrednio, zamiast rasteryzować obraz najpierw.

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

Zachowanie zawartości SVG jako SVG zachowuje wektorowe źródło wewnątrz prezentacji. Eksporty rastrowe, takie jak PNG lub JPEG, muszą renderować tę wektorową treść do pikseli. Eksport slajdu do PDF lub SVG również jest operacją renderowania, więc wyeksportowana grafika nie powinna być traktowana jako bit‑do‑bitowa kopia oryginalnego osadzonego SVG; użyj danych [ISvgImage.getSvgData](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isvgimage/#getSvgData--) gdy wymagany jest pierwotny zasób wektorowy.

## **Przycinanie obrazu**

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

Ponieważ ukryte dane obrazu nadal istnieją, przycięcie może być zmienione później bez utraty oryginalnych pikseli. Jeśli rozmiar pliku jest ważniejszy niż odwracalność, przycięte obszary mogą być fizycznie usunięte, jak opisano w następnej sekcji.

## **Usuwanie danych przyciętych obrazu**

[IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) usuwa dane obrazu poza aktualnym prostokątem przycięcia i zwraca powstały zasób obrazu. Może to zmniejszyć rozmiar pliku, ale jest to destrukcyjna optymalizacja: po zapisaniu prezentacji usunięte piksele nie są już dostępne dla późniejszej operacji od‑przycięcia.

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

Metoda może dodać nowy zasób obrazu do prezentacji. Jeśli oryginalny obraz jest także używany przez inne ramki obrazu, te ramki nadal potrzebują istniejącego zasobu, więc usunięcie przyciętych obszarów niekoniecznie zmniejsza całkowitą liczbę obrazów. Przycinanie zawartości WMF lub EMF tą metodą rasteryzuje przycięty wynik do PNG.

## **Kompresja obrazów rastrowych**

[IPictureFillFormat.compressImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) zmniejsza rozdzielczość obrazu rastrowego względem rozmiaru, w jakim obraz jest wyświetlany. Może także usuwać przycięte regiony w tej samej operacji. Metoda zwraca `true`, gdy obraz został zmieniony rozmiarowo lub przycięty, oraz `false`, gdy zmiana nie była konieczna.

Użyj wbudowanej wartości [PicturesCompression](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/picturescompression/) gdy wystarczy standardowa docelowa rozdzielczość:

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

Można podać własną dodatnią wartość DPI zamiast predefiniowanej, gdy wymagany jest konkretny cel.

Kompresja jest przeznaczona dla obrazów rastrowych. Zawartość SVG i metaplików nie jest zmniejszana tym rastrowym procesem kompresji. Pamiętaj też, że niższa rozdzielczość i usunięte przycięte regiony nie mogą zostać odzyskane z zoptymalizowanej prezentacji. Wybieraj docelową rozdzielczość na podstawie największego rozmiaru, w którym obraz będzie faktycznie oglądany lub eksportowany, a nie stosując najniższe DPI globalnie.

## **Inspekcja efektów obrazu**

Efekty obrazu są przechowywane na obrazie używanym przez ramkę. Kolekcja transformacji obrazu może zawierać efekty takie jak stała modulacja alfa dla przezroczystości oraz luminancja dla jasności i kontrastu. Poniższy przykład bezpiecznie odczytuje oba rodzaje efektów z pierwszej ramki obrazu na slajdzie:

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
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        for (IImageTransformOperation effect : imageTransform) {
            if (effect instanceof IAlphaModulateFixed) {
                IAlphaModulateFixed alphaModulateFixed = (IAlphaModulateFixed) effect;
                float transparency = 100 - alphaModulateFixed.getAmount();
                System.out.println("Transparency: " + transparency);
            }

            if (effect instanceof ILuminance) {
                ILuminance luminanceEffect = (ILuminance) effect;
                ILuminanceEffectiveData luminance = luminanceEffect.getEffective();
                System.out.println("Brightness: " + luminance.getBrightness());
                System.out.println("Contrast: " + luminance.getContrast());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Efekty te zmieniają sposób renderowania obrazu w ramce; nie nadpisują oryginalnych bajtów osadzonego obrazu.

## **Zablokowanie geometrii ramki obrazu**

Ustawienia [IPictureFrameLock](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipictureframelock/) kontrolują, które operacje edycji są wyłączone dla ramki obrazu. Na przykład [setAspectRatioLocked](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) zachowuje proporcje kształtu podczas zmiany rozmiaru.

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

Zablokowanie dotyczy samego kształtu ramki obrazu. Nie wymusza ponownego próbkowania źródłowego obrazu ani trwałej zmiany jego proporcji.

## **Dostosowanie wartości StretchOffset**

Gdy tryb wypełnienia obrazu jest rozciągnięty, wartości stretch‑offset w [IPictureFillFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipicturefillformat/) definiują prostokąt wypełnienia względem ramki obrazu. Dodatnie procenty tworzą wcięcie od krawędzi, natomiast ujemne procenty tworzą występ.

To różni się od przycinania. Wartości przycięcia wybierają, która część obrazu źródłowego jest widoczna; offsety rozciągania zmieniają prostokąt, w którym widoczne wypełnienie obrazu jest rozciągane.

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

Używaj offsetów rozciągania do pozycjonowania wypełnienia. Używaj właściwości przycięcia, gdy celem jest ukrycie krawędzi obrazu źródłowego.

## **Przechowywanie, rozmiar pliku i kwestie eksportu**

Główne kompromisy są łatwiejsze do zarządzania, gdy przechowywanie obrazu i formatowanie ramki obrazu są traktowane oddzielnie:

- **Obrazy osadzone** sprawiają, że prezentacja jest samodzielna i są najbardziej niezawodne przy udostępnianiu oraz renderowaniu po stronie serwera, ale duże obrazy rastrowe zwiększają rozmiar PPTX i zużycie pamięci.
- **Obrazy połączone** mogą utrzymać pakiet mniejszy, lecz prezentacja zależy od dostępności plików zewnętrznych pod zapisanymi ścieżkami lub lokalizacjami.
- **Przycinanie** jest początkowo nie­destrukcyjne. Ukryte piksele pozostają osadzone, dopóki przycięte obszary nie zostaną jawnie usunięte lub usunięte podczas kompresji.
- **Kompresja** może znacząco zmniejszyć rozmiar pliku przy zbyt dużych obrazach rastrowych, ale kosztem rozdzielczości źródła. Powinna być stosowana po poznaniu docelowego rozmiaru na slajdzie.
- **Obrazy SVG** powinny pozostać jako SVG, gdy ważne jest zachowanie wektora. Wyodrębnij osadzony SVG bezpośrednio, gdy potrzebny jest sam zasób wektorowy. Eksporty slajdów rastrowych zawsze konwertują renderowany slajd na piksele.
- **Powtarzające się obrazy** powinny ponownie wykorzystywać istniejący zasób [IPPImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ippimage/), gdy to możliwe, zamiast wielokrotnie ładować ten sam plik w przepływie pracy prezentacji.

W dużych prezentacjach optymalizacja obrazu jest zazwyczaj najskuteczniejsza przy selektywnym stosowaniu: trzymaj loga i diagramy jako zawartość wektorową, kompresuj zdjęcia zgodnie z ich rzeczywistym rozmiarem wyświetlania, usuwaj przycięte piksele tylko wtedy, gdy późniejsza edycja nie jest wymagana, i unikaj linków zewnętrznych, chyba że zarządzanie zależnościami jest częścią projektu wdrożenia.

## **FAQ**

**Jaka jest różnica między ramką obrazu a zasobem obrazu?**

[IPPImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ippimage/) reprezentuje zasób obrazu powiązany z prezentacją. [IPictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipictureframe/) jest kształtem na slajdzie, który wyświetla obraz i przechowuje geometryczne oraz formatowe informacje na poziomie ramki, takie jak rozmiar, obrót, wartości przycięcia, efekty i blokady.

**Czy powinienem osadzać czy łączyć obrazy?**

Osadzaj obrazy, gdy prezentacja musi być przenośna, archiwizowana lub renderowana bez dostępu do zasobów zewnętrznych. Łącz obrazy tylko wtedy, gdy zamierzone jest trzymanie plików obrazu poza PPTX i możesz zapewnić niezawodne utrzymanie lokalizacji zewnętrznych.

**Czy przycinanie zmniejsza rozmiar pliku PPTX?**

Nie samo w sobie. Normalne ustawienia przycięcia ukrywają części obrazu źródłowego, ale zachowują ukryte piksele. Użyj [IPictureFillFormat.deletePictureCroppedAreas](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) lub kompresji obrazu z usunięciem przyciętych obszarów, gdy te piksele mogą być trwale odrzucone.

**Czy mogę przywrócić jakość obrazu po kompresji?**

Nie. Kompresja może zmniejszyć przechowywaną rozdzielczość rastrową, a usunięcie przyciętych regionów usuwa dane obrazu. Zachowaj oryginalny obraz źródłowy poza prezentacją, jeśli później może być potrzebna edycja w wysokiej rozdzielczości.

**Jak obsługiwać obrazy SVG?**

Trzymaj zawartość SVG jako SVG, gdy ważna jest wierność wektora. Osadzony [ISvgImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isvgimage/) może być wyodrębniony bezpośrednio. Renderowanie slajdu do formatu rastrowego, takiego jak PNG lub JPEG, rasteryzuje SVG jako część obrazu slajdu.

**Jak uniknąć niebezpiecznych rzutowań przy odczycie istniejących slajdów?**

Sprawdzaj typ kształtu przed użyciem członków specyficznych dla ramki obrazu. Sprawdzenie `instanceof` przeciwko [IPictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipictureframe/) zapobiega nieprawidłowym rzutowaniom i pozwala obsłużyć slajdy, które nie zawierają ramek obrazu.