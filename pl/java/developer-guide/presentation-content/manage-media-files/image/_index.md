---
title: Optymalizacja zarządzania obrazami w prezentacjach przy użyciu Javy
linktitle: Zarządzaj obrazami
type: docs
weight: 10
url: /pl/java/image/
keywords:
- dodaj obraz
- dodaj zdjęcie
- dodaj bitmapę
- zamień obraz
- zamień zdjęcie
- z sieci
- tło
- dodaj PNG
- dodaj JPG
- dodaj SVG
- dodaj EMF
- dodaj WMF
- dodaj TIFF
- PowerPoint
- OpenDocument
- prezentacja
- EMF
- SVG
- Java
- Aspose.Slides
description: "Usprawnij zarządzanie obrazami w PowerPoint i OpenDocument za pomocą Aspose.Slides dla Javy, optymalizując wydajność i automatyzując przepływ pracy."
---
## **Wprowadzenie**

Obrazy sprawiają, że prezentacje są bardziej angażujące i interesujące. W programie Microsoft PowerPoint możesz wstawiać obrazy z pliku, internetu lub innych miejsc na slajdy. Podobnie Aspose.Slides umożliwia dodawanie obrazów do slajdów w Twoich prezentacjach za pomocą różnych metod. 

{{% alert  title="Wskazówka" color="primary" %}} 

Aspose udostępnia bezpłatne konwertery—[JPEG do PowerPoint](https://products.aspose.app/slides/pl/import/jpg-to-ppt) i [PNG do PowerPoint](https://products.aspose.app/slides/pl/import/png-to-ppt)—które umożliwiają szybkie tworzenie prezentacji z obrazów. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Jeśli chcesz dodać obraz jako obiekt ramki — szczególnie jeśli zamierzasz używać standardowych opcji formatowania, aby zmienić jego rozmiar, dodać efekty itp. — zobacz [Ramka obrazu](https://docs.aspose.com/slides/pl/java/picture-frame/). 

{{% /alert %}} 

{{% alert title="Uwaga" color="warning" %}}

Możesz manipulować operacjami wejścia/wyjścia dotyczącymi obrazów i prezentacji PowerPoint, aby konwertować obraz z jednego formatu na inny. Zobacz te strony: konwertuj [obraz do JPG](https://products.aspose.com/slides/pl/java/conversion/image-to-jpg/); konwertuj [JPG do obrazu](https://products.aspose.com/slides/pl/java/conversion/jpg-to-image/); konwertuj [JPG do PNG](https://products.aspose.com/slides/pl/java/conversion/jpg-to-png/), konwertuj [PNG do JPG](https://products.aspose.com/slides/pl/java/conversion/png-to-jpg/); konwertuj [PNG do SVG](https://products.aspose.com/slides/pl/java/conversion/png-to-svg/), konwertuj [SVG do PNG](https://products.aspose.com/slides/pl/java/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides obsługuje operacje na obrazach w następujących popularnych formatach: JPEG, PNG, GIF i inne. 

## **Dodaj obrazy przechowywane lokalnie do slajdów**

Możesz dodać jeden lub kilka obrazów z komputera na slajd w prezentacji. Ten przykładowy kod w języku Java pokazuje, jak dodać obraz do slajdu:

```java
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
	if (pres != null) pres.dispose();
}
```

## **Dodaj obrazy z sieci do slajdów**

Jeśli obraz, który chcesz dodać do slajdu, nie jest dostępny na Twoim komputerze, możesz dodać go bezpośrednio z sieci. 

Ten przykładowy kod pokazuje, jak dodać obraz z sieci do slajdu w języku Java:

```java
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

		while ((read = inputStream.read(buffer, 0, buffer.length)) != -1)
			outputStream.write(buffer, 0, read);

		outputStream.flush();

		IPPImage image = pres.getImages().addImage(outputStream.toByteArray());
		slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
	} finally {
		if (inputStream != null) inputStream.close();
		outputStream.close();
	}

	pres.save("pres.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

## **Dodaj obrazy do mistrza slajdów**

Mistrz slajdów to główny slajd, który przechowuje i kontroluje informacje (motyw, układ itp.) o wszystkich slajdach pod nim. Dlatego po dodaniu obrazu do mistrza slajdów, obraz ten pojawia się na każdym slajdzie pod tym mistrzem. 

Ten przykładowy kod w języku Java pokazuje, jak dodać obraz do mistrza slajdów:

```java
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
	if (pres != null) pres.dispose();
}
```

## **Dodaj obrazy jako tła slajdów**

Możesz zdecydować się na użycie obrazu jako tła dla konkretnego slajdu lub kilku slajdów. W takim przypadku należy zobaczyć *[Ustawianie obrazów jako tła slajdów](https://docs.aspose.com/slides/pl/java/presentation-background/#setting-images-as-background-for-slides)*.

## **Dodaj SVG do prezentacji**
Możesz dodać lub wstawić dowolny obraz do prezentacji, używając metody [addPictureFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) należącej do interfejsu [IShapeCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShapeCollection).

Aby utworzyć obiekt obrazu na podstawie SVG, możesz zrobić to w następujący sposób:

1. Utwórz obiekt SvgImage, aby wstawić go do ImageShapeCollection
2. Utwórz obiekt PPImage z ISvgImage
3. Utwórz obiekt PictureFrame przy użyciu interfejsu IPPImage

Ten przykładowy kod pokazuje, jak zaimplementować powyższe kroki, aby dodać obraz SVG do prezentacji:
```java
// Utwórz instancję klasy Presentation, która reprezentuje plik PPTX
Presentation pres = new Presentation();
try {
    String svgContent = new String(Files.readAllBytes(Paths.get("image.svg")));
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 
			ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Konwertuj SVG na zestaw kształtów**
Konwersja SVG na zestaw kształtów w Aspose.Slides jest podobna do funkcjonalności PowerPoint używanej do pracy z obrazami SVG:

![PowerPoint Popup Menu](img_01_01.png)

Funkcjonalność jest udostępniana przez jedną z przeciążonych wersji metody [addGroupShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) interfejsu [IShapeCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShapeCollection), która przyjmuje obiekt [ISvgImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISvgImage) jako pierwszy argument.

Ten przykładowy kod pokazuje, jak użyć opisanej metody do konwersji pliku SVG na zestaw kształtów:

```java 
// Utwórz nową prezentację
IPresentation presentation = new Presentation();
try {
    // Odczytaj zawartość pliku SVG
    byte[] svgContent = Files.readAllBytes(Paths.get("image.svg"));

    // Utwórz obiekt SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Pobierz rozmiar slajdu
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // Konwertuj obraz SVG na grupę kształtów skalując go do rozmiaru slajdu
    presentation.getSlides().get_Item(0).getShapes().
            addGroupShape(svgImage, 0f, 0f, (float)slideSize.getWidth(), (float)slideSize.getHeight());

    // Zapisz prezentację w formacie PPTX
    presentation.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Dodaj obrazy jako EMF do slajdów**
Aspose.Slides for Java pozwala generować obrazy EMF z arkuszy Excel i dodawać je jako EMF do slajdów przy użyciu Aspose.Cells. 

Ten przykładowy kod pokazuje, jak wykonać opisaną czynność:

```java 
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

// Zapisz skoroszyt do strumienia
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);
    
    String EmfSheetName = "";
    for (int j = 0; j < sr.getPageCount(); j++)
    {
    
        EmfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, EmfSheetName);

        IPPImage picture;
        IImage image = Images.fromFile(EmfSheetName);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
        ISlide slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().getByType(SlideLayoutType.Blank));
        IShape m = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0,
					(float)pres.getSlideSize().getSize().getWidth(), 
					(float)pres.getSlideSize().getSize().getHeight(), 
					picture);
    }
    
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zastąp obrazy w kolekcji obrazów**

Aspose.Slides pozwala zastąpić obrazy przechowywane w kolekcji obrazów prezentacji (w tym te używane przez kształty slajdów). Ta sekcja pokazuje kilka podejść do aktualizacji obrazów w kolekcji. API udostępnia proste metody zastąpienia obrazu przy użyciu surowych danych bajtowych, instancji [IImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimage/) lub innego obrazu, który już istnieje w kolekcji.

1. Załaduj plik prezentacji zawierający obrazy przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
2. Załaduj nowy obraz z pliku do tablicy bajtów.
3. Zastąp docelowy obraz nowym obrazem, używając tablicy bajtów.
4. W drugim podejściu załaduj obraz do obiektu [IImage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iimage/) i zastąp docelowy obraz tym obiektem.
5. W trzecim podejściu zastąp docelowy obraz obrazem, który już istnieje w kolekcji obrazów prezentacji.
6. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Pierwszy sposób.
    byte[] imageData = Files.readAllBytes(Paths.get("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // Drugi sposób.
    IImage newImage = Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
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

Korzystając z darmowego konwertera Aspose FREE [Text to GIF](https://products.aspose.app/slides/pl/text-to-gif), możesz łatwo animować teksty, tworzyć GIF-y z tekstów itp. 

{{% /alert %}}

## **FAQ**

**Czy pierwotna rozdzielczość obrazu pozostaje niezmieniona po wstawieniu?**

Tak. Piksele źródłowe są zachowane, ale ostateczny wygląd zależy od tego, jak [picture](/slides/pl/java/picture-frame/) jest skalowany na slajdzie oraz od ewentualnej kompresji przy zapisie.

**Jaki jest najlepszy sposób na zastąpienie tego samego logo jednocześnie na dziesiątkach slajdów?**

Umieść logo na slajdzie mistrza lub układzie i zastąp je w kolekcji obrazów prezentacji — aktualizacje rozprzestrzenią się na wszystkie elementy korzystające z tego zasobu.

**Czy wstawiony SVG może zostać przekonwertowany na edytowalne kształty?**

Tak. Możesz przekonwertować SVG na grupę kształtów, po czym poszczególne części stają się edytowalne przy użyciu standardowych właściwości kształtów.

**Jak mogę ustawić obraz jako tło dla wielu slajdów jednocześnie?**

[Ustaw obraz jako tło](/slides/pl/java/presentation-background/) na slajdzie mistrza lub odpowiednim układzie — wszystkie slajdy używające tego mistrza/układu odziedziczą tło.

**Jak zapobiec „rozrostowi” prezentacji z powodu wielu obrazów?**

Używaj jednego zasobu obrazu zamiast duplikatów, wybieraj rozsądne rozdzielczości, stosuj kompresję przy zapisie i zachowuj powtarzające się grafiki w mistrzu, gdy jest to właściwe.