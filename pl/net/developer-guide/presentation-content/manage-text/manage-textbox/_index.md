---
title: Zarządzanie polami tekstowymi w prezentacjach w .NET
linktitle: Zarządzaj polem tekstowym
type: docs
weight: 20
url: /pl/net/manage-textbox/
keywords:
- pole tekstowe
- ramka tekstowa
- dodaj tekst
- zaktualizuj tekst
- utwórz pole tekstowe
- sprawdź pole tekstowe
- dodaj kolumnę tekstową
- dodaj hiperłącze
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides dla .NET umożliwia łatwe tworzenie, edytowanie i klonowanie pól tekstowych w plikach PowerPoint i OpenDocument, zwiększając automatyzację prezentacji."
---
## **Wprowadzenie**

Teksty na slajdach zazwyczaj znajdują się w polach tekstowych lub kształtach. Dlatego, aby dodać tekst do slajdu, najpierw musisz dodać pole tekstowe, a następnie umieścić w nim tekst. 

Aby umożliwić dodawanie kształtu, który może zawierać tekst, Aspose.Slides dla .NET udostępnia interfejs [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape). 

{{% alert title="Uwaga" color="warning" %}} 

Aspose.Slides udostępnia także interfejs [IShape](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape), który pozwala na dodawanie kształtów do slajdów. Jednak nie wszystkie kształty dodane za pomocą interfejsu `IShape` mogą zawierać tekst. Kształty dodane za pośrednictwem interfejsu [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape) zazwyczaj zawierają tekst. 

Dlatego, gdy pracujesz z istniejącym kształtem, do którego chcesz dodać tekst, warto sprawdzić i potwierdzić, że został on rzutowany na interfejs `IAutoShape`. Dopiero wtedy będziesz mógł pracować z [TextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/properties/textframe), który jest właściwością interfejsu `IAutoShape`. Zobacz sekcję [Update Text](https://docs.aspose.com/slides/pl/net/manage-textbox/#update-text) na tej stronie. 

{{% /alert %}}

## **Utworzenie pola tekstowego na slajdzie**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation). 
2. Uzyskaj odniesienie do pierwszego slajdu za pomocą jego indeksu. 
3. Dodaj obiekt [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape) z właściwością [ShapeType](https://reference.aspose.com/slides/pl/net/aspose.slides/igeometryshape/properties/shapetype) ustawioną na `Rectangle` w określonej pozycji na slajdzie i uzyskaj odwołanie do nowo dodanego obiektu `IAutoShape`. 
4. Dodaj właściwość `TextFrame` do obiektu `IAutoShape`, która będzie zawierać tekst. W poniższym przykładzie dodaliśmy ten tekst: *Aspose TextBox*
5. Na koniec zapisz plik PPTX przy użyciu obiektu `Presentation`. 

Ten kod w C# — implementacja powyższych kroków — pokazuje, jak dodać tekst do slajdu:

```c#
 // Tworzy instancję PresentationEx
 using (Presentation pres = new Presentation())
 {
 
     // Pobiera pierwszy slajd w prezentacji
     ISlide sld = pres.Slides[0];
 
     // Dodaje AutoShape z typem ustawionym na Rectangle
     IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);
 
     // Dodaje TextFrame do prostokąta
     ashp.AddTextFrame(" ");
 
     // Uzyskuje dostęp do ramki tekstowej
     ITextFrame txtFrame = ashp.TextFrame;
 
     // Tworzy obiekt Paragraph dla ramki tekstowej
     IParagraph para = txtFrame.Paragraphs[0];
 
     // Tworzy obiekt Portion dla akapitu
     IPortion portion = para.Portions[0];
 
     // Ustawia tekst
     portion.Text = "Aspose TextBox";
 
     // Zapisuje prezentację na dysk
     pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
 }
```

## **Sprawdzenie, czy kształt jest polem tekstowym**

Aspose.Slides udostępnia właściwość [IsTextBox](https://reference.aspose.com/slides/pl/net/aspose.slides/autoshape/istextbox/) z interfejsu [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/) , pozwalając na przeglądanie kształtów i identyfikowanie pól tekstowych.

![Pola tekstowego i kształt](istextbox.png)

Ten kod w C# pokazuje, jak sprawdzić, czy kształt został utworzony jako pole tekstowe: 

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    Aspose.Slides.LowCode.ForEach.Shape(presentation, (shape, slide, index) =>
    {
        if (shape is IAutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "shape is a text box" : "shape is not a text box");
        }
    });
}
```

Zauważ, że jeśli po prostu dodasz autokształt za pomocą metody `AddAutoShape` z interfejsu [IShapeCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection/), właściwość `IsTextBox` tego autokształtu zwróci `false`. Jednak po dodaniu tekstu do autokształtu metodą `AddTextFrame` lub właściwością `Text`, właściwość `IsTextBox` zwróci `true`.

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    // shape1.IsTextBox ma wartość false
    shape1.AddTextFrame("shape 1");
    // shape1.IsTextBox ma wartość true

    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
    // shape2.IsTextBox ma wartość false
    shape2.TextFrame.Text = "shape 2";
    // shape2.IsTextBox ma wartość true

    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
    // shape3.IsTextBox ma wartość false
    shape3.AddTextFrame("");
    // shape3.IsTextBox ma wartość false

    IAutoShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
    // shape4.IsTextBox ma wartość false
    shape4.TextFrame.Text = "";
    // shape4.IsTextBox ma wartość false
}
```

## **Dodanie kolumn do pola tekstowego**

Aspose.Slides udostępnia właściwości [ColumnCount](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframeformat/properties/columncount) i [ColumnSpacing](https://reference.aspose.com/slides/pl/net/aspose.slides/textframeformat/properties/columnspacing) (z interfejsu [ITextFrameFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframeformat) oraz klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/textframeformat)), umożliwiające dodanie kolumn do pól tekstowych. Możesz określić liczbę kolumn w polu tekstowym, a następnie odstęp w punktach pomiędzy kolumnami. 

Ten kod w C# demonstruje opisaną operację: 

```c#
using (Presentation presentation = new Presentation())
{
	// Pobiera pierwszy slajd w prezentacji
	ISlide slide = presentation.Slides[0];

	// Dodaje AutoShape z typem ustawionym na Rectangle
	IAutoShape aShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

	// Dodaje TextFrame do prostokąta
	aShape.AddTextFrame("All these columns are limited to be within a single text container -- " +
	"you can add or delete text and the new or remaining text automatically adjusts " +
	"itself to flow within the container. You cannot have text flow from one container " +
	"to other though -- we told you PowerPoint's column options for text are limited!");

	// Pobiera format tekstu ramki TextFrame
	ITextFrameFormat format = aShape.TextFrame.TextFrameFormat;

	// Określa liczbę kolumn w TextFrame
	format.ColumnCount = 3;

	// Określa odstęp między kolumnami
	format.ColumnSpacing = 10;

	// Zapisuje prezentację
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```

## **Dodanie kolumn do ramki tekstowej**

Aspose.Slides dla .NET udostępnia właściwość [ColumnCount](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframeformat/properties/columncount) (z interfejsu [ITextFrameFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframeformat)), która pozwala dodać kolumny w ramkach tekstowych. Dzięki tej właściwości możesz określić preferowaną liczbę kolumn w ramce tekstowej. 

Ten kod w C# pokazuje, jak dodać kolumnę wewnątrz ramki tekstowej:

```c#
string outPptxFileName = "ColumnsTest.pptx";
using (Presentation pres = new Presentation())
{
    IAutoShape shape1 = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.TextFrame.TextFrameFormat;

    format.ColumnCount = 2;
    shape1.TextFrame.Text = "All these columns are forced to stay within a single text container -- " +
                                "you can add or delete text - and the new or remaining text automatically adjusts " +
                                "itself to stay within the container. You cannot have text spill over from one container " +
                                "to other, though -- because PowerPoint's column options for text are limited!";
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(2 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(double.NaN == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }

    format.ColumnSpacing = 20;
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(2 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(20 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }

    format.ColumnCount = 3;
    format.ColumnSpacing = 15;
    pres.Save(outPptxFileName, SaveFormat.Pptx);

    using (Presentation test = new Presentation(outPptxFileName))
    {
        Debug.Assert(3 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnCount);
        Debug.Assert(15 == ((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing);
    }
}
```

## **Aktualizacja tekstu**

Aspose.Slides umożliwia zmianę lub aktualizację tekstu zawartego w polu tekstowym lub wszystkich tekstów w prezentacji. 

Ten kod w C# demonstruje operację, w której wszystkie teksty w prezentacji są aktualizowane lub zmieniane:

```c#
using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) //Sprawdza, czy kształt obsługuje ramkę tekstową (IAutoShape). 
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) //Iteruje przez akapity w ramce tekstowej
               {
                   foreach (IPortion portion in paragraph.Portions) //Iteruje przez każdy fragment w akapicie
                   {
                       portion.Text = portion.Text.Replace("years", "months"); //Zmienia tekst
                       portion.PortionFormat.FontBold = NullableBool.True; //Zmienia formatowanie
                   }
               }
           }
       }
   }
  
   //Zapisuje zmodyfikowaną prezentację
   pres.Save("text-changed.pptx", SaveFormat.Pptx);
}
```

## **Dodanie pola tekstowego z hiperłączem** 

Możesz wstawić link wewnątrz pola tekstowego. Gdy pole tekstowe zostanie kliknięte, użytkownicy są przekierowywani do otwarcia linku. 

1. Utwórz instancję klasy `Presentation`. 
2. Uzyskaj odniesienie do pierwszego slajdu za pomocą jego indeksu.  
3. Dodaj obiekt `AutoShape` z `ShapeType` ustawionym na `Rectangle` w określonej pozycji na slajdzie i uzyskaj odwołanie do nowo dodanego obiektu AutoShape. 
4. Dodaj `TextFrame` do obiektu `AutoShape`, który zawiera *Aspose TextBox* jako domyślny tekst. 
5. Utwórz instancję klasy `IHyperlinkManager`. 
6. Przypisz obiekt `IHyperlinkManager` do właściwości [HyperlinkClick](https://reference.aspose.com/slides/pl/net/aspose.slides/shape/properties/hyperlinkclick) powiązanej z wybraną częścią `TextFrame`. 
7. Na koniec zapisz plik PPTX przy użyciu obiektu `Presentation`. 

Ten kod w C# — implementacja powyższych kroków — pokazuje, jak dodać pole tekstowe z hiperłączem do slajdu:

```c#
// Instancjonuje klasę Presentation, która reprezentuje plik PPTX
Presentation pptxPresentation = new Presentation();

// Uzyskuje pierwszy slajd w prezentacji
ISlide slide = pptxPresentation.Slides[0];

// Dodaje obiekt AutoShape z typem ustawionym na Rectangle
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// Rzutuje kształt na AutoShape
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// Dostaje dostęp do własności ITextFrame powiązanej z AutoShape
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// Dodaje tekst do ramki
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// Ustawia hiperłącze dla tekstu fragmentu
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// Zapisuje prezentację PPTX
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **FAQ**

**Jaka jest różnica między polem tekstowym a symbolem tekstowym podczas pracy z slajdami nadrzędnymi?**

Symbol [placeholder](/slides/pl/net/manage-placeholder/) dziedziczy styl/położenie z [mastera](https://reference.aspose.com/slides/pl/net/aspose.slides/masterslide/) i może być nadpisany na [układach](https://reference.aspose.com/slides/pl/net/aspose.slides/layoutslide/), podczas gdy zwykłe pole tekstowe jest niezależnym obiektem na konkretnym slajdzie i nie zmienia się po przełączeniu układów.

**Jak wykonać masową zamianę tekstu w całej prezentacji, nie zmieniając tekstu w wykresach, tabelach i SmartArt?**

Ogranicz iterację do auto‑kształtów posiadających ramki tekstowe i wyklucz osadzone obiekty ([charts](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/pl/net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/pl/net/aspose.slides.smartart/smartart/)), przeglądając ich kolekcje osobno lub pomijając te typy obiektów.