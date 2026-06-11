---
title: Zarządzaj ramkami obrazu w prezentacjach przy użyciu Javy
linktitle: Ramka obrazu
type: docs
weight: 10
url: /pl/java/picture-frame/
keywords:
- ramka obrazu
- dodaj ramkę obrazu
- utwórz ramkę obrazu
- dodaj obraz
- utwórz obraz
- wyodrębnij obraz
- obraz rastrowy
- obraz wektorowy
- przytnij obraz
- przycięty obszar
- właściwość StretchOff
- formatowanie ramki obrazu
- właściwości ramki obrazu
- skalowanie względne
- efekt obrazu
- proporcje
- przezroczystość obrazu
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Dodaj ramki obrazu do prezentacji PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Javy. Usprawnij proces pracy i ulepsz projekt slajdów."
---
## **Wstęp**

Ramka obrazu jest kształtem, który zawiera obraz — jest to jak obraz w ramce. 

Możesz dodać obraz do slajdu za pomocą ramki obrazu. W ten sposób możesz formatować obraz, formatując ramkę obrazu.

{{% alert  title="Wskazówka" color="primary" %}} 

Aspose udostępnia darmowe konwertery —[JPEG do PowerPoint](https://products.aspose.app/slides/pl/import/jpg-to-ppt) oraz [PNG do PowerPoint](https://products.aspose.app/slides/pl/import/png-to-ppt) — które umożliwiają szybkie tworzenie prezentacji z obrazów. 

{{% /alert %}} 

## **Utwórz ramkę obrazu**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).  
2. Uzyskaj odniesienie do slajdu przez jego indeks.  
3. Utwórz obiekt [IPPImage]() poprzez dodanie obrazu do [IImagescollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IImageCollection) powiązanego z obiektem prezentacji, który będzie używany do wypełnienia kształtu.  
4. Określ szerokość i wysokość obrazu.  
5. Utwórz [PictureFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/PictureFrame) na podstawie szerokości i wysokości obrazu za pomocą metody `AddPictureFrame` udostępnionej przez obiekt kształtu powiązany z odniesionym slajdem.  
6. Dodaj ramkę obrazu (zawierającą obraz) do slajdu.  
7. Zapisz zmodyfikowaną prezentację jako plik PPTX.  

Ten kod Java pokazuje, jak utworzyć ramkę obrazu:

```java
// Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
Presentation pres = new Presentation();
try {
    // Pobiera pierwszy slajd
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Tworzy instancję klasy Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Dodaje ramkę obrazu o wysokości i szerokości odpowiadających obrazowi
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Zapisuje plik PPTX na dysku
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 

Ramki obrazu pozwalają szybko tworzyć slajdy prezentacji na podstawie obrazów. Łącząc ramkę obrazu z opcjami zapisu Aspose.Slides, możesz manipulować operacjami wejścia/wyjścia, aby konwertować obrazy z jednego formatu na inny. Może Cię zainteresować następujące strony: konwertuj [obraz do JPG](https://products.aspose.com/slides/pl/java/conversion/image-to-jpg/); konwertuj [JPG do obrazu](https://products.aspose.com/slides/pl/java/conversion/jpg-to-image/); konwertuj [JPG do PNG](https://products.aspose.com/slides/pl/java/conversion/jpg-to-png/), konwertuj [PNG do JPG](https://products.aspose.com/slides/pl/java/conversion/png-to-jpg/); konwertuj [PNG do SVG](https://products.aspose.com/slides/pl/java/conversion/png-to-svg/), konwertuj [SVG do PNG](https://products.aspose.com/slides/pl/java/conversion/svg-to-png/).  

{{% /alert %}}

## **Utwórz ramkę obrazu ze skalowaniem względnym**

Poprzez zmianę skalowania względnego obrazu możesz stworzyć bardziej złożoną ramkę obrazu. 

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).  
2. Uzyskaj odniesienie do slajdu przez jego indeks.  
3. Dodaj obraz do kolekcji obrazów prezentacji.  
4. Utwórz obiekt [IPPImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IPPImage) poprzez dodanie obrazu do [IImagescollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IImageCollection) powiązanego z obiektem prezentacji, który będzie używany do wypełnienia kształtu.  
5. Określ względną szerokość i wysokość obrazu w ramce obrazu.  
6. Zapisz zmodyfikowaną prezentację jako plik PPTX.  

Ten kod Java pokazuje, jak utworzyć ramkę obrazu ze skalowaniem względnym:

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik PPTX
Presentation pres = new Presentation();
try {
    // Pobierz pierwszy slajd
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Utwórz instancję klasy Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Dodaj ramkę obrazu o wysokości i szerokości odpowiadających obrazowi
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Ustawianie względnej skali wysokości i szerokości
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // Zapisz plik PPTX na dysku
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Wyodrębnij obrazy rastrowe z ramek obrazu**

Możesz wyodrębnić obrazy rastrowe z obiektów [PictureFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/PictureFrame) i zapisać je w formatach PNG, JPG i innych. Poniższy przykład kodu demonstruje, jak wyodrębnić obraz z dokumentu „sample.pptx” i zapisać go w formacie PNG.

```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IShape firstShape = firstSlide.getShapes().get_Item(0);

    if (firstShape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) firstShape;
        try {
			IImage slideImage = pictureFrame.getPictureFormat().getPicture().getImage().getImage();
			slideImage.save("slide_1_shape_1.png", ImageFormat.Png);
		} finally {
			if (slideImage != null) slideImage.dispose();
		}
    }
} catch (IOException e) {
} finally {
    presentation.dispose();
}
```

## **Wyodrębnij obrazy SVG z ramek obrazu**

Gdy prezentacja zawiera grafikę SVG umieszczoną wewnątrz kształtów [PictureFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pictureframe/), Aspose.Slides dla Javy pozwala pobrać oryginalne obrazy wektorowe w pełnej jakości. Przeglądając kolekcję kształtów slajdu, możesz zidentyfikować każdy [PictureFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pictureframe/), sprawdzić, czy leżący pod nim [IPPImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ippimage/) zawiera treść SVG, a następnie zapisać ten obraz na dysku lub w strumieniu w natywnym formacie SVG.  

Poniższy przykład kodu demonstruje, jak wyodrębnić obraz SVG z ramki obrazu:

```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof IPictureFrame) {
        IPictureFrame pictureFrame = (IPictureFrame) shape;
        ISvgImage svgImage = pictureFrame.getPictureFormat().getPicture().getImage().getSvgImage();

        FileOutputStream fos = new FileOutputStream("output.svg");
        fos.write(svgImage.getSvgData());
        fos.close();
    }
} catch (IOException e) {
    System.out.println(e.getMessage());
} finally {
    presentation.dispose();
}
```

## **Uzyskaj przezroczystość obrazu**

Aspose.Slides pozwala uzyskać efekt przezroczystości zastosowany do obrazu. Ten kod Java demonstruje operację:

```java
Presentation presentation = new Presentation("Test.pptx");

var pictureFrame = (IPictureFrame) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
for (var effect : imageTransform) {
    if (effect instanceof IAlphaModulateFixed) {
        var alphaModulateFixed = (IAlphaModulateFixed) effect;
        var transparencyValue = 100 - alphaModulateFixed.getAmount();
        System.out.println("Picture transparency: " + transparencyValue);
    }
}
```

## **Formatowanie ramki obrazu**

Aspose.Slides zapewnia wiele opcji formatowania, które można zastosować do ramki obrazu. Korzystając z tych opcji, możesz zmienić ramkę obrazu, aby spełniała określone wymagania.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).  
2. Uzyskaj odniesienie do slajdu przez jego indeks.  
3. Utwórz obiekt [IPPImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IPPImage) poprzez dodanie obrazu do [IImagescollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IImageCollection) powiązanego z obiektem prezentacji, który będzie używany do wypełnienia kształtu.  
4. Określ szerokość i wysokość obrazu.  
5. Utwórz `PictureFrame` na podstawie szerokości i wysokości obrazu za pomocą metody [AddPictureFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) udostępnionej przez obiekt [IShapes](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShapeCollection) powiązany z odniesionym slajdem.  
6. Dodaj ramkę obrazu (zawierającą obraz) do slajdu.  
7. Ustaw kolor linii ramki obrazu.  
8. Ustaw szerokość linii ramki obrazu.  
9. Obróć ramkę obrazu, podając wartość dodatnią lub ujemną.  
   * Dodatnia wartość obraca obraz zgodnie z ruchem wskazówek zegara.  
   * Ujemna wartość obraca obraz przeciwnie do ruchu wskazówek zegara.  
10. Dodaj ramkę obrazu (zawierającą obraz) do slajdu.  
11. Zapisz zmodyfikowaną prezentację jako plik PPTX.  

Ten kod Java demonstruje proces formatowania ramki obrazu:

```java
// Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
Presentation pres = new Presentation();
try {
    // Pobiera pierwszy slajd
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Tworzy instancję klasy Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    // Dodaje ramkę obrazu o wysokości i szerokości odpowiadających obrazowi
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Stosuje pewne formatowanie do PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // Zapisuje plik PPTX na dysku
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Wskazówka" color="primary" %}}

Aspose niedawno opracowało [darmowy Kreator kolaży](https://products.aspose.app/slides/pl/collage). Jeśli potrzebujesz [scalić obrazy JPG/JPEG](https://products.aspose.app/slides/pl/collage/jpg) lub PNG, [tworzyć siatki ze zdjęć](https://products.aspose.app/slides/pl/collage/photo-grid), możesz skorzystać z tej usługi.  

{{% /alert %}}

## **Dodaj obraz jako odnośnik**

Aby uniknąć dużych rozmiarów prezentacji, możesz dodawać obrazy (lub filmy) poprzez odnośniki zamiast wbudowywać pliki bezpośrednio w prezentację. Ten kod Java pokazuje, jak dodać obraz i wideo do placeholdera:

```java
Presentation presentation = new Presentation("input.pptx");
try {
    ArrayList<IShape> shapesToRemove = new ArrayList<IShape>();
    int shapesCount = presentation.getSlides().get_Item(0).getShapes().size();

    for (int i = 0; i < shapesCount; i++)
    {
        IShape autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(i);

        if (autoShape.getPlaceholder() == null)
        {
            continue;
        }

        switch (autoShape.getPlaceholder().getType())
        {
            case PlaceholderType.Picture:
                IPictureFrame pictureFrame = presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle,
                        autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), null);

                pictureFrame.getPictureFormat().getPicture().setLinkPathLong(
                        "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");

                shapesToRemove.add(autoShape);
                break;

            case PlaceholderType.Media:
                IVideoFrame videoFrame = presentation.getSlides().get_Item(0).getShapes().addVideoFrame(
                        autoShape.getX(), autoShape.getY(), autoShape.getWidth(), autoShape.getHeight(), "");

                videoFrame.getPictureFormat().getPicture().setLinkPathLong(
                        "https://upload.wikimedia.org/wikipedia/commons/3/3a/I.M_at_Old_School_Public_Broadcasting_in_October_2016_02.jpg");

                videoFrame.setLinkPathLong("https://youtu.be/t_1LYZ102RA");

                shapesToRemove.add(autoShape);
                break;
        }
    }

    for (IShape shape : shapesToRemove)
    {
        presentation.getSlides().get_Item(0).getShapes().remove(shape);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Przycinanie obrazów**

Ten kod Java pokazuje, jak przyciąć istniejący obraz na slajdzie:

```java
Presentation pres = new Presentation();
// Tworzy nowy obiekt obrazu
try {
    IPPImage picture;
    IImage image = Images.fromFile(imagePath);
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Dodaje ramkę obrazu do slajdu
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(
            ShapeType.Rectangle, 100, 100, 420, 250, picture);

    // Przycina obraz (wartości procentowe)
    picFrame.getPictureFormat().setCropLeft(23.6f);
    picFrame.getPictureFormat().setCropRight(21.5f);
    picFrame.getPictureFormat().setCropTop(3);
    picFrame.getPictureFormat().setCropBottom(31);

    // Zapisuje wynik
    pres.save(outPptxFile, SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Usuwanie przyciętych obszarów obrazu**

Jeśli chcesz usunąć przycięte obszary obrazu zawartego w ramce, możesz użyć metody [deletePictureCroppedAreas()](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--). Metoda zwraca przycięty obraz lub oryginalny obraz, jeśli przycinanie nie jest konieczne.  

Ten kod Java demonstruje operację:

```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Pobiera ramkę obrazu z pierwszego slajdu
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Usuwa przycięte obszary obrazu ramki obrazu i zwraca przycięty obraz
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // Zapisuje wynik
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="UWAGA" color="warning" %}} 

Metoda [deletePictureCroppedAreas()](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) dodaje przycięty obraz do kolekcji obrazów prezentacji. Jeśli obraz jest używany wyłącznie w przetwarzanym [PictureFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pictureframe/), to rozwiązanie może zmniejszyć rozmiar prezentacji. W przeciwnym razie liczba obrazów w wynikowej prezentacji wzrośnie.  

Metoda konwertuje pliki metafili WMF/EMF na rastrowe obrazy PNG podczas operacji przycinania.  

{{% /alert %}}

## **Kompresja obrazów**

Możesz skompresować obraz w prezentacji przy użyciu metody [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-) . Metoda ta kompresuje obraz, zmniejszając jego rozmiar w zależności od rozmiaru kształtu i określonej rozdzielczości, z opcją usunięcia przyciętych obszarów.  

Działa to podobnie jak funkcja PowerPoint **Format obrazu → Kompresuj obrazy → Rozdzielczość**.  

Poniższe przykłady Java demonstrują, jak skompresować obraz w prezentacji, podając docelową rozdzielczość i opcjonalnie usuwając przycięte obszary:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Skompresuj obraz do docelowej rozdzielczości 150 DPI (rozdzielczość sieciowa) i usuń przycięte obszary.
    boolean result = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);

    // Sprawdź wynik kompresji.
    if (result) {
        System.out.println("Image successfully compressed.");
    } else {
        System.out.println("Image compression failed or no changes were necessary.");
    }

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Lub używając bezpośrednio własnej wartości DPI:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Kompresuj obraz do 150 DPI (rozdzielczość sieciowa), usuwając przycięte obszary.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="UWAGA" color="warning" %}} 

Metoda konwertuje obraz do niższej rozdzielczości w oparciu o rozmiar kształtu i podany DPI. Przycięte regiony mogą być również usuwane w celu optymalizacji rozmiaru pliku.  
Jeśli obraz jest metafilem (WMF/EMF) lub SVG, kompresja nie zostanie zastosowana. Jakość JPEG jest zachowywana lub nieznacznie obniżana w zależności od rozdzielczości, podobnie jak w PowerPoint przy obsłudze wysokiej rozdzielczości JPEG.  

{{% /alert %}}

## **Zablokuj proporcje**

Jeśli chcesz, aby kształt zawierający obraz zachował proporcje nawet po zmianie wymiarów obrazu, możesz użyć metody [setAspectRatioLocked](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) w celu ustawienia opcji *Zablokuj proporcje*.  

Ten kod Java pokazuje, jak zablokować proporcje kształtu:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ILayoutSlide layout = pres.getLayoutSlides().getByType(SlideLayoutType.Custom);
    ISlide emptySlide = pres.getSlides().addEmptySlide(layout);
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    IPictureFrame pictureFrame = emptySlide.getShapes().addPictureFrame(
            ShapeType.Rectangle, 50, 150, presImage.getWidth(), presImage.getHeight(), picture);

    // ustaw kształt, aby zachować proporcje przy skalowaniu
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="UWAGA" color="warning" %}} 

Ustawienie *Zablokuj proporcje* zachowuje jedynie proporcje samego kształtu, a nie obrazu, który zawiera.  

{{% /alert %}}

## **Użyj właściwości StretchOff**

Korzystając z właściwości [StretchOffsetLeft](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) i [StretchOffsetBottom](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) interfejsu [IPictureFillFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IPictureFillFormat) oraz klasy [PictureFillFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IPictureFillFormat), możesz określić prostokąt wypełnienia.  

Gdy rozciąganie jest określone dla obrazu, prostokąt źródłowy jest skalowany, aby pasował do określonego prostokąta wypełnienia. Każda krawędź prostokąta wypełnienia jest definiowana jako procentowy offset od odpowiadającej krawędzi ramki ograniczającej kształt. Dodatni procent oznacza wcięcie, a ujemny procent oznacza wystawienie.  

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).  
2. Uzyskaj odniesienie do slajdu przez jego indeks.  
3. Dodaj prostokąt `AutoShape`.  
4. Utwórz obraz.  
5. Ustaw typ wypełnienia kształtu.  
6. Ustaw tryb wypełnienia obrazu kształtu.  
7. Dodaj ustawiony obraz do wypełnienia kształtu.  
8. Określ offsety obrazu względem odpowiedniej krawędzi ramki ograniczającej kształt.  
9. Zapisz zmodyfikowaną prezentację jako plik PPTX.  

Ten kod Java demonstruje proces, w którym używana jest właściwość StretchOff:

```java
// Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
Presentation pres = new Presentation();
try {
    // Pobiera pierwszy slajd
    ISlide slide = pres.getSlides().get_Item(0);

    // Tworzy instancję klasy ImageEx
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Dodaje AutoShape ustawioną na prostokąt
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Ustawia typ wypełnienia kształtu
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Ustawia tryb wypełnienia obrazu kształtu
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Ustawia obraz wypełniający kształt
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Określa offsety obrazu względem odpowiedniej krawędzi ramki ograniczającej kształt
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    // Zapisuje plik PPTX na dysku
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Jak dowiedzieć się, które formaty obrazów są obsługiwane w PictureFrame?**

Aspose.Slides obsługuje zarówno obrazy rastrowe (PNG, JPEG, BMP, GIF itp.), jak i obrazy wektorowe (np. SVG) za pośrednictwem obiektu obrazu przypisanego do [PictureFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pictureframe/). Lista obsługiwanych formatów zazwyczaj pokrywa się z możliwościami silnika konwersji slajdów i obrazów.  

**Jak dodanie dziesiątek dużych obrazów wpłynie na rozmiar i wydajność pliku PPTX?**

Osadzanie dużych obrazów zwiększa rozmiar pliku i zużycie pamięci; linkowanie obrazów pomaga utrzymać mały rozmiar prezentacji, ale wymaga dostępności plików zewnętrznych. Aspose.Slides umożliwia dodawanie obrazów jako linki, aby zmniejszyć rozmiar pliku.  

**Jak zablokować obiekt obrazu przed przypadkowym przesuwaniem lub zmianą rozmiaru?**

Użyj [blokad kształtu](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pictureframe/#getPictureFrameLock--) dla [PictureFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pictureframe/) (np. wyłącz przesuwanie lub zmianę rozmiaru). Mechanizm blokowania opisano w oddzielnym [artykule o ochronie](/slides/pl/java/applying-protection-to-presentation/) i jest wspierany dla różnych typów kształtów, w tym [PictureFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pictureframe/).  

**Czy integralność wektora SVG jest zachowana przy eksportowaniu prezentacji do PDF/obrazów?**

Aspose.Slides umożliwia wyodrębnienie SVG z [PictureFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/pictureframe/) jako oryginalny wektor. Podczas [eksportu do PDF](/slides/pl/java/convert-powerpoint-to-pdf/) lub [formatów rastrowych](/slides/pl/java/convert-powerpoint-to-png/) wynik może zostać zrastrowany w zależności od ustawień eksportu; fakt, że oryginalny SVG jest przechowywany jako wektor, potwierdza zachowanie po wyodrębnieniu.