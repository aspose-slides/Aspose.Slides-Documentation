---
title: Zarządzanie polami tekstowymi w prezentacjach przy użyciu Java
linktitle: Zarządzaj polem tekstowym
type: docs
weight: 20
url: /pl/java/manage-textbox/
keywords:
- pole tekstowe
- ramka tekstowa
- dodaj tekst
- aktualizuj tekst
- utwórz pole tekstowe
- sprawdź pole tekstowe
- dodaj kolumnę tekstu
- dodaj odnośnik
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Aspose.Slides for Java umożliwia łatwe tworzenie, edytowanie i klonowanie pól tekstowych w plikach PowerPoint i OpenDocument, zwiększając automatyzację Twoich prezentacji."
---
## **Wprowadzenie**

Teksty na slajdach zazwyczaj znajdują się w polach tekstowych lub kształtach. Dlatego, aby dodać tekst do slajdu, musisz dodać pole tekstowe, a następnie umieścić w nim tekst. Aspose.Slides for Java udostępnia interfejs [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IAutoShape), który pozwala dodać kształt zawierający tekst.

{{% alert title="Informacja" color="info" %}}
Aspose.Slides udostępnia również interfejs [IShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShape), który pozwala dodawać kształty do slajdów. Jednak nie wszystkie kształty dodane za pośrednictwem interfejsu `IShape` mogą zawierać tekst. Kształty dodane za pośrednictwem interfejsu [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IAutoShape) mogą zawierać tekst. 
{{% /alert %}}

{{% alert title="Uwaga" color="warning" %}} 
Dlatego, gdy pracujesz z kształtem, do którego chcesz dodać tekst, warto sprawdzić i potwierdzić, że został rzutowany na interfejs `IAutoShape`. Dopiero wtedy będziesz mógł pracować z [TextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/TextFrame), który jest właściwością interfejsu `IAutoShape`. Zobacz sekcję [Update Text](https://docs.aspose.com/slides/pl/java/manage-textbox/#update-text) na tej stronie. 
{{% /alert %}}

## **Utworzenie pola tekstowego na slajdzie**

Aby utworzyć pole tekstowe na slajdzie, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation). 
2. Uzyskaj odwołanie do pierwszego slajdu w nowo utworzonej prezentacji. 
3. Dodaj obiekt [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IAutoShape) z typem [ShapeType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IGeometryShape#setShapeType-int-) ustawionym na `Rectangle` w określonej pozycji na slajdzie i uzyskaj odwołanie do nowo dodanego obiektu `IAutoShape`. 
4. Dodaj właściwość `TextFrame` do obiektu `IAutoShape`, która będzie zawierała tekst. W poniższym przykładzie dodaliśmy tekst: *Aspose TextBox* 
5. Na koniec zapisz plik PPTX przy użyciu obiektu `Presentation`. 

Ten kod w Javie — implementacja powyższych kroków — pokazuje, jak dodać tekst do slajdu:

```java
// Tworzy instancję Presentation
Presentation pres = new Presentation();
try {
    // Pobiera pierwszy slajd w prezentacji
    ISlide sld = pres.getSlides().get_Item(0);

    // Dodaje AutoShape z typem ustawionym na Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Dodaje TextFrame do Rectangle
    ashp.addTextFrame(" ");

    // Uzyskuje dostęp do TextFrame
    ITextFrame txtFrame = ashp.getTextFrame();

    // Tworzy obiekt Paragraph dla TextFrame
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Tworzy obiekt Portion dla Paragraph
    IPortion portion = para.getPortions().get_Item(0);

    // Ustawia tekst
    portion.setText("Aspose TextBox");

    // Zapisuje prezentację na dysk
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Sprawdzenie, czy kształt jest polem tekstowym**

Aspose.Slides udostępnia metodę [isTextBox](https://reference.aspose.com/slides/pl/java/com.aspose.slides/autoshape/#isTextBox--) z interfejsu [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/), pozwalającą zbadać kształty i zidentyfikować pola tekstowe.

![Text box and shape](istextbox.png)

Ten kod w Javie pokazuje, jak sprawdzić, czy kształt został utworzony jako pole tekstowe: 

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ForEach.shape(presentation, (shape, slide, index) -> {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;
            System.out.println(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
        }
    });
} finally {
    presentation.dispose();
}
```

Uwaga: jeśli po prostu dodasz autoshape metodą `addAutoShape` z interfejsu [IShapeCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishapecollection/), metoda `isTextBox` tego autoshape zwróci `false`. Jednak po dodaniu tekstu do autoshape metodą `addTextFrame` lub `setText`, właściwość `isTextBox` zwróci `true`.

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() zwraca false
shape1.addTextFrame("shape 1");
// shape1.isTextBox() zwraca true

IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() zwraca false
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() zwraca true

IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() zwraca false
shape3.addTextFrame("");
// shape3.isTextBox() zwraca false

IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() zwraca false
shape4.getTextFrame().setText("");
// shape4.isTextBox() zwraca false
```

## **Dodawanie kolumn do pola tekstowego**

Aspose.Slides udostępnia właściwości [ColumnCount](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) i [ColumnSpacing](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (z interfejsu [ITextFrameFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ITextFrameFormat) oraz klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/TextFrameFormat)), które pozwalają dodać kolumny do pól tekstowych. Możesz określić liczbę kolumn w polu tekstowym oraz odstęp w punktach między kolumnami. 

Ten kod w Javie demonstruje opisane działanie: 

```java
Presentation pres = new Presentation();
try {
    // Pobiera pierwszy slajd w prezentacji
    ISlide slide = pres.getSlides().get_Item(0);

    // Dodaje AutoShape z typem ustawionym na Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Dodaje TextFrame do prostokąta
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // Pobiera format tekstu TextFrame
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // Określa liczbę kolumn w TextFrame
    format.setColumnCount(3);

    // Określa odstęp między kolumnami
    format.setColumnSpacing(10);

    // Zapisuje prezentację
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Dodawanie kolumn do ramki tekstowej**
Aspose.Slides for Java udostępnia właściwość [ColumnCount](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (z interfejsu [ITextFrameFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ITextFrameFormat)), która pozwala dodać kolumny w ramach tekstowych. Za jej pomocą możesz określić preferowaną liczbę kolumn w ramce tekstowej. 

Ten kod w Javie pokazuje, jak dodać kolumnę wewnątrz ramki tekstowej:

```java
String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " +
            "you can add or delete text - and the new or remaining text automatically adjusts " +
            "itself to stay within the container. You cannot have text spill over from one container " +
            "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(Double.NaN == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(20 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) test1.dispose();
    }

    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test2 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(3 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(15 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) test2.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Aktualizacja tekstu**

Aspose.Slides umożliwia zmianę lub aktualizację tekstu zawartego w polu tekstowym lub wszystkich tekstów w prezentacji. 

Ten kod w Javie demonstruje operację, w której wszystkie teksty w prezentacji są aktualizowane lub zmieniane:

```java
Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //Sprawdza, czy kształt obsługuje ramkę tekstową (IAutoShape).
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //Iteruje przez akapity w ramce tekstowej
                {
                    for (IPortion portion : paragraph.getPortions()) //Iteruje przez każdy fragment w akapicie
                    {
                        portion.setText(portion.getText().replace("years", "months")); //Modyfikuje tekst
                        portion.getPortionFormat().setFontBold(NullableBool.True); //Modyfikuje formatowanie
                    }
                }
            }
        }
    }

    //Zapisuje zmodyfikowaną prezentację
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Dodanie pola tekstowego z odnośnikiem** 

Możesz wstawić odnośnik wewnątrz pola tekstowego. Po kliknięciu pola tekstowego użytkownicy są przekierowywani do otwarcia odnośnika. 

Aby dodać pole tekstowe zawierające odnośnik, wykonaj następujące kroki:

1. Utwórz instancję klasy `Presentation`. 
2. Uzyskaj odwołanie do pierwszego slajdu w nowo utworzonej prezentacji. 
3. Dodaj obiekt `AutoShape` z ustawionym `ShapeType` na `Rectangle` w określonej pozycji na slajdzie i uzyskaj odwołanie do nowo dodanego obiektu AutoShape. 
4. Dodaj `TextFrame` do obiektu `AutoShape`, które będzie zawierało *Aspose TextBox* jako domyślny tekst. 
5. Zainicjuj klasę `IHyperlinkManager`. 
6. Przypisz obiekt `IHyperlinkManager` do właściwości [HyperlinkClick](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Shape#getHyperlinkClick--) powiązanej z wybraną częścią `TextFrame`. 
7. Na koniec zapisz plik PPTX przy użyciu obiektu `Presentation`. 

Ten kod w Javie — implementacja powyższych kroków — pokazuje, jak dodać pole tekstowe z odnośnikiem do slajdu:

```java
// Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
Presentation pres = new Presentation();
try {
    // Pobiera pierwszy slajd w prezentacji
    ISlide slide = pres.getSlides().get_Item(0);

    // Dodaje obiekt AutoShape z typem ustawionym na Rectangle
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // Rzutuje kształt na AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // Uzyskuje dostęp do właściwości ITextFrame powiązanej z AutoShape
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // Dodaje tekst do ramki
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // Ustawia hiperłącze dla tekstu fragmentu
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // Zapisuje prezentację PPTX
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Jaka jest różnica między polem tekstowym a tekstowym placeholderem przy pracy z master slajdami?**

[Placeholder](/slides/pl/java/manage-placeholder/) dziedziczy styl/pozycję z [mastera](https://reference.aspose.com/slides/pl/java/com.aspose.slides/masterslide/) i może być nadpisany w [layoutach](https://reference.aspose.com/slides/pl/java/com.aspose.slides/layoutslide/), podczas gdy zwykłe pole tekstowe jest niezależnym obiektem na konkretnym slajdzie i nie zmienia się po przełączeniu layoutów.

**Jak wykonać masową zamianę tekstu w całej prezentacji, nie dotykając tekstu w wykresach, tabelach i SmartArt?**

Ogranicz iterację do autoshape’ów posiadających ramki tekstowe i wyklucz osadzone obiekty ([charts](https://reference.aspose.com/slides/pl/java/com.aspose.slides/chart/), [tables](https://reference.aspose.com/slides/pl/java/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/smartart/)) poprzez osobne przeglądanie ich kolekcji lub pomijanie tych typów obiektów.