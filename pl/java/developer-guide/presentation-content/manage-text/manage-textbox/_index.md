---
title: Zarządzaj polami tekstowymi w prezentacjach przy użyciu Javy
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
- dodaj kolumnę tekstową
- dodaj hiperłącze
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Aspose.Slides for Java umożliwia łatwe tworzenie, edytowanie i klonowanie pól tekstowych w plikach PowerPoint i OpenDocument, zwiększając automatyzację Twoich prezentacji."
---
## **Wprowadzenie**

Teksty na slajdach zazwyczaj znajdują się w polach tekstowych lub kształtach. Dlatego, aby dodać tekst do slajdu, musisz dodać pole tekstowe, a następnie umieścić w nim tekst. Aspose.Slides for Java udostępnia interfejs [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IAutoShape) umożliwiający dodanie kształtu zawierającego tekst.

{{% alert title="Info" color="info" %}}
Aspose.Slides udostępnia również interfejs [IShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IShape) umożliwiający dodawanie kształtów do slajdów. Jednak nie wszystkie kształty dodane przez interfejs `IShape` mogą zawierać tekst. Natomiast kształty dodane przez interfejs [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IAutoShape) mogą zawierać tekst. 
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Dlatego, pracując z kształtem, do którego chcesz dodać tekst, warto sprawdzić i potwierdzić, że został on rzutowany przez interfejs `IAutoShape`. Dopiero wtedy będziesz mógł pracować z [TextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/TextFrame), który jest właściwością interfejsu `IAutoShape`. Zobacz sekcję [Update Text](https://docs.aspose.com/slides/pl/java/manage-textbox/#update-text) na tej stronie. 
{{% /alert %}}

## **Utworzenie pola tekstowego na slajdzie**

Aby utworzyć pole tekstowe na slajdzie, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation). 
2. Uzyskaj odwołanie do pierwszego slajdu w nowo utworzonej prezentacji. 
3. Dodaj obiekt [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IAutoShape) z [ShapeType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IGeometryShape#setShapeType-int-) ustawionym na `Rectangle` w określonej pozycji na slajdzie i uzyskaj odwołanie do nowo dodanego obiektu `IAutoShape`. 
4. Dodaj właściwość `TextFrame` do obiektu `IAutoShape`, który będzie zawierał tekst. W poniższym przykładzie dodaliśmy tekst: *Aspose TextBox* 
5. Na koniec zapisz plik PPTX przy użyciu obiektu `Presentation`. 

Ten kod Java — implementacja powyższych kroków — pokazuje, jak dodać tekst do slajdu:

```java
import com.aspose.slides.*;

// Tworzy obiekt Presentation
Presentation pres = new Presentation();
try {
    // Pobiera pierwszy slajd w prezentacji
    ISlide sld = pres.getSlides().get_Item(0);

    // Dodaje AutoShape z typem ustawionym jako Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Dodaje TextFrame do prostokąta
    ashp.addTextFrame(" ");

    // Uzyskuje dostęp do ramki tekstowej
    ITextFrame txtFrame = ashp.getTextFrame();

    // Tworzy obiekt Paragraph dla ramki tekstowej
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // Tworzy obiekt Portion dla akapitu
    IPortion portion = para.getPortions().get_Item(0);

    // Ustawia tekst
    portion.setText("Aspose TextBox");

    // Zapisuje prezentację na dysku
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Sprawdź, czy kształt jest polem tekstowym**

Aspose.Slides udostępnia metodę [isTextBox](https://reference.aspose.com/slides/pl/java/com.aspose.slides/autoshape/#isTextBox--) z interfejsu [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/) umożliwiającą analizę kształtów i identyfikację pól tekstowych.

![Text box and shape](istextbox.png)

Ten kod Java pokazuje, jak sprawdzić, czy kształt został utworzony jako pole tekstowe: 

```java
import com.aspose.slides.*;

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

Należy zauważyć, że jeśli po prostu dodasz autoshape przy użyciu metody `addAutoShape` z interfejsu [IShapeCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishapecollection/), metoda `isTextBox` autoshape zwróci `false`. Natomiast po dodaniu tekstu do autoshape przy użyciu metody `addTextFrame` lub `setText`, właściwość `isTextBox` zwróci `true`.

```java
import com.aspose.slides.*;

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

## **Znajdź kształt będący właścicielem ramki tekstowej**

W ogólnym kodzie przetwarzania tekstu możesz otrzymać obiekt [ITextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/) nie wiedząc, który obiekt prezentacji go zawiera. Użyj metody [ITextFrame.getParentShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/#getParentShape--) aby przejść z powrotem do właściciela [IShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/).

Dla ramki tekstowej należącej do [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/) lub innego kształtu zawierającego tekst, metoda [ITextFrame.getParentShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/#getParentShape--) zwraca właściciela, a [ITextFrame.getParentCell](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/#getParentCell--) zwraca `null`. Obie metody zapewniają nawigację tylko do odczytu, więc ich wywołanie nie zmienia własności. Zawsze sprawdzaj zwróconą wartość pod kątem `null` przed dostępem do kształtu.

Pełny przykład identyfikujący właścicieli kształtów i komórek tabel, w tym kształty powiązane z węzłami SmartArt, znajdziesz w sekcji [Search and Replace Text](/slides/pl/java/search-and-replace-text/).

## **Dodaj kolumny do pola tekstowego**

Aspose.Slides udostępnia właściwości [ColumnCount](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) i [ColumnSpacing](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (z interfejsu [ITextFrameFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ITextFrameFormat) oraz klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/TextFrameFormat)), które pozwalają dodać kolumny do pól tekstowych. Możesz określić liczbę kolumn w polu tekstowym oraz ustawić odstęp w punktach pomiędzy kolumnami. 

Ten kod w języku Java demonstruje opisaną operację: 

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Pobiera pierwszy slajd w prezentacji
    ISlide slide = pres.getSlides().get_Item(0);

    // Dodaje AutoShape z typem ustawionym jako Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // Dodaje TextFrame do prostokąta
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // Pobiera format tekstu ramki TextFrame
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

## **Dodaj kolumny do ramki tekstowej**
Aspose.Slides for Java udostępnia właściwość [ColumnCount](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (z interfejsu [ITextFrameFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ITextFrameFormat)), która pozwala dodać kolumny w ramach tekstowych. Dzięki tej właściwości możesz określić preferowaną liczbę kolumn w ramce tekstowej. 

Ten kod Java pokazuje, jak dodać kolumnę wewnątrz ramki tekstowej:

```java
import com.aspose.slides.*;

String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    ITextFrameFormat format = shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " +
            "you can add or delete text - and the new or remaining text automatically adjusts " +
            "itself to stay within the container. You cannot have text spill over from one container " +
            "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test.getSlides().get_Item(0).getShapes().get_Item(0);
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0);
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) test1.dispose();
    }

    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test2 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0);
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) test2.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Aktualizacja tekstu**

Aspose.Slides umożliwia zmianę lub aktualizację tekstu zawartego w polu tekstowym lub wszystkich tekstów w prezentacji. 

Ten kod Java demonstruje operację, w której wszystkie teksty w prezentacji są aktualizowane lub zmieniane:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //Sprawdza, czy kształt obsługuje ramkę tekstową (IAutoShape). 
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //Iteruje po akapitach w ramce tekstowej
                {
                    for (IPortion portion : paragraph.getPortions()) //Iteruje po każdej części w akapicie
                    {
                        portion.setText(portion.getText().replace("years", "months")); //Zmienia tekst
                        portion.getPortionFormat().setFontBold(NullableBool.True); //Zmienia formatowanie
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

## **Dodaj pole tekstowe z hiperłączem** 

Możesz wstawić odnośnik wewnątrz pola tekstowego. Po kliknięciu pola tekstowego użytkownicy są przekierowywani do otwarcia linku. 

Aby dodać pole tekstowe zawierające odnośnik, wykonaj następujące kroki:

1. Utwórz instancję klasy `Presentation`. 
2. Uzyskaj odwołanie do pierwszego slajdu w nowo utworzonej prezentacji. 
3. Dodaj obiekt `AutoShape` z `ShapeType` ustawionym na `Rectangle` w określonej pozycji na slajdzie i uzyskaj odwołanie do nowo dodanego obiektu AutoShape. 
4. Dodaj `TextFrame` do obiektu `AutoShape`, który zawiera *Aspose TextBox* jako domyślny tekst. 
5. Zainicjuj klasę `IHyperlinkManager`. 
6. Przypisz obiekt `IHyperlinkManager` do właściwości [HyperlinkClick](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Shape#getHyperlinkClick--) powiązanej z wybraną częścią `TextFrame`. 
7. Na koniec zapisz plik PPTX przy użyciu obiektu `Presentation`. 

Ten kod Java — implementacja powyższych kroków — pokazuje, jak dodać pole tekstowe z hiperłączem do slajdu:

```java
import com.aspose.slides.*;

// Tworzy instancję klasy Presentation reprezentującej plik PPTX
Presentation pres = new Presentation();
try {
    // Pobiera pierwszy slajd w prezentacji
    ISlide slide = pres.getSlides().get_Item(0);

    // Dodaje obiekt AutoShape z typem ustawionym jako Rectangle
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // Rzutuje kształt na AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // Uzyskuje dostęp do właściwości ITextFrame powiązanej z AutoShape
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // Dodaje trochę tekstu do ramki
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // Ustawia hiperlink dla tekstu części
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

**Jaka jest różnica między polem tekstowym a symbolem zastępczym tekstu przy pracy z slajdami głównymi?**

[Placeholder](/slides/pl/java/manage-placeholder/) dziedziczy styl/pozycję z [mastera](https://reference.aspose.com/slides/pl/java/com.aspose.slides/masterslide/) i może być nadpisany na [układach](https://reference.aspose.com/slides/pl/java/com.aspose.slides/layoutslide/), podczas gdy zwykłe pole tekstowe jest niezależnym obiektem na konkretnym slajdzie i nie zmienia się po zmianie układów.

**Jak wykonać masową zamianę tekstu w całej prezentacji, nie zmieniając tekstu w wykresach, tabelach i SmartArt?**

Ogranicz iterację do auto‑kształtów, które mają ramki tekstowe, i wyklucz osadzone obiekty ([charts](https://reference.aspose.com/slides/pl/java/com.aspose.slides/chart/), [tables](https://reference.aspose.com/slides/pl/java/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/pl/java/com.aspose.slides/smartart/)) poprzez osobne przeglądanie ich kolekcji lub pomijanie tych typów obiektów.