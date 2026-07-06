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
description: "Dodaj ramki obrazu do prezentacji PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Androida w języku Java. Usprawnij proces pracy i ulepsz projekty slajdów."
---
## **Wprowadzenie**

Ramka obrazu to kształt, który zawiera obraz — jest jak zdjęcie w ramce. 

Możesz dodać obraz do slajdu za pomocą ramki obrazu. W ten sposób możesz formatować obraz, formatując ramkę obrazu.

{{% alert  title="Tip" color="primary" %}} 

Aspose udostępnia bezpłatne konwertery — [JPEG do PowerPoint](https://products.aspose.app/slides/pl/import/jpg-to-ppt) i [PNG do PowerPoint](https://products.aspose.app/slides/pl/import/png-to-ppt) — które umożliwiają szybkie tworzenie prezentacji z obrazów. 

{{% /alert %}} 

## **Utworzenie ramki obrazu**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
2. Uzyskaj odniesienie do slajdu za pomocą jego indeksu. 
3. Utwórz obiekt [IPPImage]() poprzez dodanie obrazu do [IImagescollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IImageCollection) powiązanego z obiektem prezentacji, który będzie używany do wypełnienia kształtu.
4. Określ szerokość i wysokość obrazu.
5. Utwórz [PictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/PictureFrame) na podstawie szerokości i wysokości obrazu za pomocą metody `AddPictureFrame` udostępnionej przez obiekt kształtu powiązany z odwołanym slajdem.
6. Dodaj ramkę obrazu (zawierającą zdjęcie) do slajdu.
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
    
    // Dodaje ramkę obrazu o wysokości i szerokości obrazu
    sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Zapisuje plik PPTX na dysku
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Utworzenie ramki obrazu z skalą względną**

Modyfikując skalowanie względne obrazu, możesz utworzyć bardziej zaawansowaną ramkę obrazu. 

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
2. Uzyskaj odniesienie do slajdu za pomocą jego indeksu. 
3. Dodaj obraz do kolekcji obrazów prezentacji.
4. Utwórz obiekt [IPPImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPPImage) poprzez dodanie obrazu do [IImagescollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IImageCollection) powiązanego z obiektem prezentacji, który będzie używany do wypełnienia kształtu.
5. Określ względną szerokość i wysokość obrazu w ramce obrazu.
6. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Ten kod Java pokazuje, jak utworzyć ramkę obrazu ze skalą względną:

```java
// Utwórz klasę Presentation, która reprezentuje plik PPTX
Presentation pres = new Presentation();
try {
    // Pobierz pierwszy slajd
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Utwórz instancję klasy Image
    IPPImage imgx = pres.getImages().addImage(new FileInputStream(new File("asp1.jpg")));
    
    
    // Dodaj ramkę obrazu o wysokości i szerokości równej obrazu
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Ustawianie względnej skali szerokości i wysokości
    pf.setRelativeScaleHeight(0.8f);
    pf.setRelativeScaleWidth(1.35f);
    
    // Zapisz plik PPTX na dysku
    pres.save("RectPicFrame.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Wyodrębnianie obrazów rastrowych z ramek obrazu**

Możesz wyodrębniać obrazy rastrowe z obiektów [PictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/PictureFrame) i zapisywać je w formatach PNG, JPG i innych. Poniższy przykład kodu pokazuje, jak wyodrębnić obraz z dokumentu "sample.pptx" i zapisać go w formacie PNG.

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

Kiedy prezentacja zawiera grafikę SVG umieszczoną wewnątrz kształtów [PictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pictureframe/), Aspose.Slides dla Androida w wersji Java umożliwia pobranie oryginalnych obrazów wektorowych z pełną wiernością. Przeglądając kolekcję kształtów slajdu, możesz zidentyfikować każdy [PictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pictureframe/), sprawdzić, czy leżący pod nim [IPPImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ippimage/) zawiera treść SVG, a następnie zapisać ten obraz na dysku lub w strumieniu w jego natywnym formacie SVG.

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

## **Pobieranie przezroczystości obrazu**

Aspose.Slides umożliwia pobranie efektu przezroczystości zastosowanego do obrazu. Ten kod Java demonstruje tę operację:

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

## **Pobieranie jasności i kontrastu obrazu**

Aspose.Slides umożliwia pobranie efektu jasności i kontrastu zastosowanego do obrazu. Interfejs [ILuminance](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iluminance/) reprezentuje ten efekt transformacji obrazu.

Ten kod Java demonstruje, jak pobrać ustawienia jasności i kontrastu z ramki obrazu:

```java
Presentation presentation = new Presentation("sample.pptx");

try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame) shape;

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    for (IImageTransformOperation effect : imageTransform) {
        if (effect instanceof ILuminance) {
            ILuminanceEffectiveData luminance = ((ILuminance) effect).getEffective();
            float brightness = luminance.getBrightness();
            float contrast = luminance.getContrast();

            System.out.println("Brightness: " + brightness);
            System.out.println("Contrast: " + contrast);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Formatowanie ramki obrazu**

Aspose.Slides oferuje wiele opcji formatowania, które można zastosować do ramki obrazu. Korzystając z tych opcji, możesz zmodyfikować ramkę obrazu, aby spełniała określone wymagania.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
2. Uzyskaj odniesienie do slajdu za pomocą jego indeksu. 
3. Utwórz obiekt [IPPImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPPImage) poprzez dodanie obrazu do [IImagescollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IImageCollection) powiązanego z obiektem prezentacji, który będzie używany do wypełnienia kształtu.
4. Określ szerokość i wysokość obrazu.
5. Utwórz `PictureFrame` na podstawie szerokości i wysokości obrazu za pomocą metody [AddPictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) udostępnionej przez obiekt [IShapes](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IShapeCollection) powiązany z odwołanym slajdem.
6. Dodaj ramkę obrazu (zawierającą zdjęcie) do slajdu.
7. Ustaw kolor linii ramki obrazu.
8. Ustaw szerokość linii ramki obrazu.
9. Obróć ramkę obrazu, podając jej wartość dodatnią lub ujemną.
   * Wartość dodatnia obraca obraz zgodnie z ruchem wskazówek zegara. 
   * Wartość ujemna obraca obraz przeciwnie do ruchu wskazówek zegara.
10. Dodaj ramkę obrazu (zawierającą zdjęcie) do slajdu.
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
    
    // Dodaje ramkę obrazu o wysokości i szerokości równej obrazowi
    IPictureFrame pf = sld.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 150, imgx.getWidth(), imgx.getHeight(), imgx);
    
    // Zastosowuje formatowanie do PictureFrameEx
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

{{% alert title="Tip" color="primary" %}}

Aspose niedawno opracował [bezpłatny kreator kolaży](https://products.aspose.app/slides/pl/collage). Jeśli kiedykolwiek potrzebujesz [scalić obrazy JPG/JPEG](https://products.aspose.app/slides/pl/collage/jpg) lub PNG, [tworzyć siatki ze zdjęć](https://products.aspose.app/slides/pl/collage/photo-grid), możesz skorzystać z tej usługi. 

{{% /alert %}}

## **Dodanie obrazu jako linku**

Aby uniknąć dużych rozmiarów prezentacji, możesz dodawać obrazy (lub filmy) za pomocą linków zamiast osadzać pliki bezpośrednio w prezentacjach. Ten kod Java pokazuje, jak dodać obraz i wideo do miejsca wstawienia:

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

    // Przycinanie obrazu (wartości procentowe)
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

Jeśli chcesz usunąć przycięte obszary obrazu zawartego w ramce, możesz użyć metody [deletePictureCroppedAreas()](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--). Metoda ta zwraca przycięty obraz lub obraz pierwotny, jeśli przycinanie nie jest potrzebne.

Ten kod Java demonstruje tę operację:

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

{{% alert title="NOTE" color="warning" %}} 

Metoda [deletePictureCroppedAreas()](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipicturefillformat/#deletePictureCroppedAreas--) dodaje przycięty obraz do kolekcji obrazów prezentacji. Jeśli obraz jest używany wyłącznie w przetworzonej [PictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pictureframe/), taka konfiguracja może zmniejszyć rozmiar prezentacji. W przeciwnym razie liczba obrazów w wynikowej prezentacji wzrośnie.

Metoda ta konwertuje pliki metafile WMF/EMF na rastrowy obraz PNG w trakcie operacji przycinania. 

{{% /alert %}}

## **Kompresja obrazów**

Możesz skompresować obraz w prezentacji przy użyciu metody [IPictureFillFormat.compressImage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipicturefillformat/#compressImage-boolean-int-). Metoda ta kompresuje obraz, zmniejszając jego rozmiar w oparciu o rozmiar kształtu i określoną rozdzielczość, z opcją usunięcia przyciętych obszarów.

Dostosowuje rozmiar i rozdzielczość obrazu podobnie jak funkcja PowerPoint **Format obrazu > Kompresuj obrazy > Rozdzielczość**.

Poniższe przykłady Java demonstrują, jak skompresować obraz w prezentacji, określając docelową rozdzielczość i opcjonalnie usuwając przycięte obszary:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Kompresuj obraz z docelową rozdzielczością 150 DPI (rozdzielczość internetowa) i usuń przycięte obszary.
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

Lub używając bezpośrednio niestandardowej wartości DPI:

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPictureFrame pictureFrame = (IPictureFrame)slide.getShapes().get_Item(0);

    // Kompresuj obraz do 150 DPI (rozdzielczość internetowa), usuwając przycięte obszary.
    pictureFrame.getPictureFormat().compressImage(true, 150f);

    presentation.save("CompressedImage.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

Metoda konwertuje obraz do niższej rozdzielczości w oparciu o rozmiar kształtu i podane DPI. Przycięte regiony mogą również zostać usunięte w celu optymalizacji rozmiaru pliku.  
Jeśli obraz jest metafilem (WMF/EMF) lub SVG, kompresja nie zostanie zastosowana. Ponadto jakość JPEG jest zachowywana lub nieco obniżana w zależności od rozdzielczości, podobnie jak PowerPoint radzi sobie z wysokiej rozdzielczości JPEG.

{{% /alert %}}

## **Zablokowanie proporcji**

Jeśli chcesz, aby kształt zawierający obraz zachował proporcje nawet po zmianie wymiarów obrazu, możesz użyć metody [setAspectRatioLocked](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ipictureframelock/#setAspectRatioLocked-boolean-) aby ustawić opcję *Lock Aspect Ratio*.

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

    // ustaw kształt tak, aby zachował proporcje przy zmianie rozmiaru
    pictureFrame.getPictureFrameLock().setAspectRatioLocked(true);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="NOTE" color="warning" %}} 

To ustawienie *Lock Aspect Ratio* zachowuje jedynie proporcje kształtu, a nie obrazu, który zawiera.

{{% /alert %}}

## **Użycie właściwości StretchOff**

Używając właściwości [StretchOffsetLeft](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetLeft-float-), [StretchOffsetTop](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetTop--), [StretchOffsetRight](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetRight--) i [StretchOffsetBottom](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPictureFillFormat#setStretchOffsetBottom-float-) z interfejsu [IPictureFillFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPictureFillFormat) oraz klasy [PictureFillFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPictureFillFormat), możesz określić prostokąt wypełnienia.

Gdy dla obrazu określono rozciąganie, prostokąt źródłowy jest skalowany, aby pasował do określonego prostokąta wypełnienia. Każda krawędź prostokąta wypełnienia jest definiowana przez offset procentowy od odpowiadającej krawędzi ramki kształtu. Wartość dodatnia oznacza wcięcie, natomiast wartość ujemna – wystawienie.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
2. Uzyskaj odniesienie do slajdu za pomocą jego indeksu.
3. Dodaj prostokąt `AutoShape`. 
4. Utwórz obraz.
5. Ustaw typ wypełnienia kształtu.
6. Ustaw tryb wypełnienia obrazu kształtu.
7. Dodaj ustawiony obraz, aby wypełnić kształt.
8. Określ offsety obrazu względem odpowiedniej krawędzi ramki kształtu
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

    // Dodaje AutoShape ustawiony na prostokąt
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Ustawia typ wypełnienia kształtu
    aShape.getFillFormat().setFillType(FillType.Picture);

    // Ustawia tryb wypełnienia obrazu kształtu
    aShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    // Ustawia obraz jako wypełnienie kształtu
    aShape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Określa offsety obrazu względem odpowiedniej krawędzi ramki kształtu
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

**Jak mogę dowiedzieć się, które formaty obrazów są obsługiwane dla PictureFrame?**

Aspose.Slides obsługuje zarówno obrazy rastrowe (PNG, JPEG, BMP, GIF itp.), jak i obrazy wektorowe (np. SVG) za pośrednictwem obiektu obrazu przypisanego do [PictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pictureframe/). Lista obsługiwanych formatów zazwyczaj pokrywa się z możliwościami silnika konwersji slajdów i obrazów.

**Jak dodanie dziesiątek dużych obrazów wpłynie na rozmiar i wydajność pliku PPTX?**

Osadzanie dużych obrazów zwiększa rozmiar pliku i zużycie pamięci; łączenie obrazów pomaga utrzymać mały rozmiar prezentacji, ale wymaga, aby zewnętrzne pliki pozostawały dostępne. Aspose.Slides umożliwia dodawanie obrazów jako linki, aby zmniejszyć rozmiar pliku.

**Jak mogę zablokować obiekt obrazu przed przypadkowym przemieszczaniem/skalowaniem?**

Użyj [blokad kształtu](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pictureframe/#getPictureFrameLock--) dla [PictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pictureframe/) (np. wyłącz przenoszenie lub skalowanie). Mechanizm blokady jest obsługiwany dla różnych typów kształtów, w tym [PictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pictureframe/).

**Czy wierność wektorowa SVG jest zachowana przy eksportowaniu prezentacji do PDF/obrazów?**

Aspose.Slides umożliwia wyodrębnienie SVG z [PictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pictureframe/) jako oryginalnego wektora. Przy [eksportowaniu do PDF](/slides/pl/androidjava/convert-powerpoint-to-pdf/) lub [formatów rastrowych](/slides/pl/androidjava/convert-powerpoint-to-png/), wynik może być rastrowany w zależności od ustawień eksportu; fakt, że oryginalny SVG jest przechowywany jako wektor, jest potwierdzony zachowaniem wyodrębniania.