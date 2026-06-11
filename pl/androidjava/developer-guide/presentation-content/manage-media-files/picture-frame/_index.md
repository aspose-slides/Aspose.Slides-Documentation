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
- skala względna
- efekt obrazu
- proporcje obrazu
- przezroczystość obrazu
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Dodaj ramki obrazu do prezentacji PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Androida w języku Java. Usprawnij swój proces pracy i ulepsz projekt slajdów."
---
## **Wprowadzenie**

Ramka obrazu jest kształtem, który zawiera obraz — jest jak obraz w ramce.

Możesz dodać obraz do slajdu za pomocą ramki obrazu. W ten sposób możesz formatować obraz, formatując ramkę obrazu.

{{% alert title="Wskazówka" color="primary" %}} 

Aspose udostępnia bezpłatne konwertery — [JPEG do PowerPoint](https://products.aspose.app/slides/pl/import/jpg-to-ppt) i [PNG do PowerPoint](https://products.aspose.app/slides/pl/import/png-to-ppt) — które pozwalają szybko tworzyć prezentacje z obrazów. 

{{% /alert %}} 

## **Utworzenie ramki obrazu**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
2. Uzyskaj odniesienie do slajdu za pomocą jego indeksu. 
3. Utwórz obiekt [IPPImage]() poprzez dodanie obrazu do [IImagescollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IImageCollection) powiązanego z obiektem prezentacji, który zostanie użyty do wypełnienia kształtu.
4. Określ szerokość i wysokość obrazu.
5. Utwórz [PictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/PictureFrame) na podstawie szerokości i wysokości obrazu przy użyciu metody `AddPictureFrame` udostępnionej przez obiekt shape powiązany ze wskazanym slajdem.
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
    
    // Dodaje ramkę obrazu z wysokością i szerokością odpowiadającą obrazowi
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Zapisuje plik PPTX na dysk
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Utworzenie ramki obrazu ze skalą względną**

Modyfikując względne skalowanie obrazu, możesz utworzyć bardziej złożoną ramkę obrazu. 

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
2. Uzyskaj odniesienie do slajdu za pomocą jego indeksu. 
3. Dodaj obraz do kolekcji obrazów prezentacji.
4. Utwórz obiekt [IPPImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPPImage) poprzez dodanie obrazu do [IImagescollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IImageCollection) powiązanego z obiektem prezentacji, który zostanie użyty do wypełnienia kształtu.
5. Określ względną szerokość i wysokość obrazu w ramce obrazu.
6. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod Java pokazuje, jak utworzyć ramkę obrazu ze skalą względną:

```java
// Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
Presentation pres = new Presentation();
try {
    // Pobiera pierwszy slajd
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Tworzy instancję klasy Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Dodaje ramkę obrazu z wysokością i szerokością równą obrazowi
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Ustawia względną skalę wysokości i szerokości
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // Zapisuje plik PPTX na dysk
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Wyodrębnianie obrazów rastrowych z ramek obrazu**

Możesz wyodrębnić obrazy rastrowe z obiektów [PictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/PictureFrame) i zapisać je w formatach PNG, JPG i innych. Poniższy przykład kodu demonstruje, jak wyodrębnić obraz z dokumentu „sample.pptx” i zapisać go w formacie PNG.

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

## **Wyodrębnianie obrazów SVG z ramek obrazu**

Gdy prezentacja zawiera grafikę SVG umieszczoną wewnątrz kształtów [PictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pictureframe/), Aspose.Slides for Android via Java pozwala pobrać oryginalne obrazy wektorowe w pełnej wierności. Przeglądając kolekcję kształtów slajdu, możesz zidentyfikować każdy [PictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pictureframe/), sprawdzić, czy leżący pod spodem [IPPImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ippimage/) zawiera treść SVG, a następnie zapisać ten obraz na dysku lub do strumienia w natywnym formacie SVG.

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

## **Uzyskanie przezroczystości obrazu**

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

Aspose.Slides oferuje wiele opcji formatowania, które można zastosować do ramki obrazu. Korzystając z tych opcji, możesz zmodyfikować ramkę obrazu, aby spełniała określone wymagania.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
2. Uzyskaj odniesienie do slajdu za pomocą jego indeksu. 
3. Utwórz obiekt [IPPImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPPImage) poprzez dodanie obrazu do [IImagescollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IImageCollection) powiązanego z obiektem prezentacji, który zostanie użyty do wypełnienia kształtu.
4. Określ szerokość i wysokość obrazu.
5. Utwórz `PictureFrame` na podstawie szerokości i wysokości obrazu przy użyciu metody [AddPictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) udostępnionej przez obiekt [IShapes](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IShapeCollection) powiązany ze wskazanym slajdem.
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
    
    // Dodaje ramkę obrazu z wysokością i szerokością równą obrazowi
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Stosuje pewne formatowanie do PictureFrameEx
    pf.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    pf.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    pf.getLineFormat().setWidth(20);
    pf.setRotation(45);
    
    // Zapisuje plik PPTX na dysk
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Wskazówka" color="primary" %}}

Aspose niedawno opracował [darmowy Kreator Kolaży](https://products.aspose.app/slides/pl/collage). Jeśli kiedykolwiek będziesz potrzebował [scalić JPG/JPEG](https://products.aspose.app/slides/pl/collage/jpg) lub PNG, [tworzyć siatki ze zdjęć](https://products.aspose.app/slides/pl/collage/photo-grid), możesz skorzystać z tego serwisu. 

{{% /alert %}}

## **Dodanie obrazu jako odnośnika**

Aby uniknąć dużych rozmiarów prezentacji, możesz dodać obrazy (lub filmy) poprzez odnośniki zamiast osadzania plików bezpośrednio w prezentacji. Ten kod Java pokazuje, jak dodać obraz i wideo do symbolu zastępczego:

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

## **Kadrowanie obrazów**

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

Jeśli chcesz usunąć przycięte obszary obrazu zawartego w ramce, możesz użyć metody [deletePictureCroppedAreas()](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--). Metoda zwraca przycięty obraz lub oryginalny obraz, jeśli przycinanie nie jest konieczne.

Ten kod Java demonstruje operację:

```java
Presentation presentation = new Presentation("PictureFrameCrop.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Pobiera ramkę obrazu z pierwszego slajdu
    IPictureFrame picFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Usuwa przycięte obszary obrazu w ramce obrazu i zwraca przycięty obraz
    IPPImage croppedImage = picFrame.getPictureFormat().deletePictureCroppedAreas();

    // Zapisuje wynik
    presentation.save("PictureFrameDeleteCroppedAreas.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="UWAGA" color="warning" %}} 

Metoda [deletePictureCroppedAreas()](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) dodaje przycięty obraz do kolekcji obrazów prezentacji. Jeśli obraz jest używany wyłącznie w przetwarzanym [PictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pictureframe/), to ustawienie może zmniejszyć rozmiar prezentacji. W przeciwnym razie liczba obrazów w wynikowej prezentacji wzrośnie.

Metoda konwertuje pliki metafile WMF/EMF na rastrowy obraz PNG w trakcie operacji przycinania. 

{{% /alert %}}

## **Kompresja obrazów**

Możesz skompresować obraz w prezentacji przy użyciu metody [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-).
Metoda ta kompresuje obraz, zmniejszając jego rozmiar w zależności od rozmiaru kształtu i zadanej rozdzielczości, z opcją usunięcia przyciętych obszarów.

Dostosowuje rozmiar i rozdzielczość obrazu podobnie jak funkcja **Picture Format > Compress Pictures > Resolution** w PowerPoint.

Poniższe przykłady Java demonstrują, jak skompresować obraz w prezentacji, określając docelową rozdzielczość i opcjonalnie usuwając przycięte obszary:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Kompresuje obraz z docelową rozdzielczością 150 DPI (rozdzielczość internetowa) i usuwa przycięte obszary.
    boolean result = pictureFrame.getPictureFormat().compressImage(true, PicturesCompression.Dpi150);

    // Sprawdza wynik kompresji.
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

Lub używając bezpośrednio niestandardowej wartości DPI:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Kompresuje obraz do 150 DPI (rozdzielczość internetowa), usuwając przycięte obszary.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="UWAGA" color="warning" %}} 

Metoda konwertuje obraz do niższej rozdzielczości w oparciu o rozmiar kształtu i podane DPI. Przycięte fragmenty mogą być również usunięte w celu optymalizacji rozmiaru pliku.  
Jeśli obraz jest metafilem (WMF/EMF) lub SVG, kompresja nie zostanie zastosowana. Ponadto jakość JPEG jest zachowywana lub nieco obniżana w zależności od rozdzielczości, podobnie jak w PowerPoint przy obsłudze wysokiej rozdzielczości JPEG.

{{% /alert %}}

## **Zablokowanie proporcji obrazu**

Jeśli chcesz, aby kształt zawierający obraz zachował proporcje nawet po zmianie wymiarów obrazu, możesz użyć metody [setAspectRatioLocked](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) do ustawienia opcji *Lock Aspect Ratio*.

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

    // ustaw kształt, aby zachować proporcje przy zmianie rozmiaru
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="UWAGA" color="warning" %}} 

Ustawienie *Lock Aspect Ratio* zachowuje tylko proporcje kształtu, a nie obrazu w nim zawartego.

{{% /alert %}}

## **Użycie właściwości StretchOff**

Używając właściwości [StretchOffsetLeft](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) i [StretchOffsetBottom](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) z interfejsu [IPictureFillFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPictureFillFormat) oraz klasy [PictureFillFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPictureFillFormat), możesz określić prostokąt wypełnienia.

Gdy dla obrazu określono rozciąganie, prostokąt źródłowy jest skalowany, aby pasował do określonego prostokąta wypełnienia. Każda krawędź prostokąta wypełnienia definiowana jest jako procentowy odstęp od odpowiadającej krawędzi ramki ograniczającej kształt. Dodatni procent określa wcięcie, a ujemny – występ.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
2. Uzyskaj odniesienie do slajdu za pomocą jego indeksu.
3. Dodaj prostokąt `AutoShape`. 
4. Utwórz obraz.
5. Ustaw typ wypełnienia kształtu.
6. Ustaw tryb wypełnienia obrazu kształtu.
7. Dodaj obraz wypełniający kształt.
8. Określ przesunięcia obrazu względem odpowiedniej krawędzi ramki ograniczającej kształt
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

    // Dodaje AutoShape ustawione na prostokąt
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Ustawia typ wypełnienia kształtu
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Ustawia tryb wypełnienia obrazu kształtu
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Ustawia obraz wypełniający kształt
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Określa przesunięcia obrazu względem odpowiedniej krawędzi ramki ograniczającej kształt
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetLeft(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetRight(25);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetTop(-20);
    aShape.getFillFormat().getPictureFillFormat().setStretchOffsetBottom(-10);
    
    // Zapisuje plik PPTX na dysk
    pres.save("StretchOffsetLeftForPictureFrame_out.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Jak mogę sprawdzić, które formaty obrazu są obsługiwane dla PictureFrame?**

Aspose.Slides obsługuje zarówno obrazy rastrowe (PNG, JPEG, BMP, GIF itp.), jak i obrazy wektorowe (np. SVG) za pośrednictwem obiektu obrazu przypisanego do [PictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pictureframe/). Lista obsługiwanych formatów zazwyczaj pokrywa się z możliwościami silnika konwersji slajdów i obrazów.

**Jak dodanie dziesiątek dużych obrazów wpłynie na rozmiar i wydajność pliku PPTX?**

Osadzanie dużych obrazów zwiększa rozmiar pliku i zużycie pamięci; łączenie obrazów pomaga utrzymać niewielki rozmiar prezentacji, ale wymaga, aby pliki zewnętrzne pozostały dostępne. Aspose.Slides umożliwia dodawanie obrazów jako odnośników w celu zmniejszenia rozmiaru pliku.

**Jak mogę zablokować obiekt obrazu przed przypadkowym przemieszczaniem/skalowaniem?**

Użyj [blokad kształtu](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--) dla [PictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pictureframe/) (np. wyłącz przemieszczenie lub skalowanie). Mechanizm blokady jest obsługiwany dla różnych typów kształtów, w tym [PictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pictureframe/).

**Czy wierność wektorowa SVG jest zachowana przy eksporcie prezentacji do PDF/obrazów?**

Aspose.Slides umożliwia wyodrębnienie SVG z [PictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pictureframe/) jako oryginalnego wektora. Przy [eksportowaniu do PDF](/slides/pl/androidjava/convert-powerpoint-to-pdf/) lub [formatów rastrowych](/slides/pl/androidjava/convert-powerpoint-to-png/), wynik może być rasteryzowany w zależności od ustawień eksportu; fakt, że oryginalny SVG jest przechowywany jako wektor, jest potwierdzony zachowaniem podczas wyodrębniania.