---
title: "Zarządzanie polami tekstowymi w prezentacjach w .NET"
linktitle: "Zarządzanie polem tekstowym"
type: docs
weight: 20
url: /pl/net/manage-textbox/
keywords:
- pole tekstowe
- ramka tekstowa
- dodawanie tekstu
- aktualizacja tekstu
- tworzenie pola tekstowego
- sprawdzanie pola tekstowego
- dodawanie kolumny tekstu
- dodawanie hiperłącza
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET ułatwia tworzenie, edytowanie i klonowanie pól tekstowych w plikach PowerPoint i OpenDocument, zwiększając możliwości automatyzacji prezentacji."
---
## **Introduction**

Teksty na slajdach zazwyczaj znajdują się w polach tekstowych lub kształtach. Dlatego, aby dodać tekst do slajdu, musisz najpierw dodać pole tekstowe, a następnie umieścić w nim tekst. 

Aby umożliwić dodanie kształtu, który może zawierać tekst, Aspose.Slides for .NET udostępnia interfejs [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape). 

{{% alert title="Uwaga" color="warning" %}} 

Aspose.Slides udostępnia również interfejs [IShape](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape), który pozwala na dodawanie kształtów do slajdów. Jednak nie wszystkie kształty dodane przez interfejs `IShape` mogą zawierać tekst. Kształty dodane przez interfejs [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape) zazwyczaj zawierają tekst. 

Dlatego przy pracy z istniejącym kształtem, do którego chcesz dodać tekst, warto sprawdzić i potwierdzić, że został rzutowany na interfejs `IAutoShape`. Dopiero wtedy będziesz mógł pracować z [TextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/properties/textframe), który jest właściwością interfejsu `IAutoShape`. Zobacz sekcję [Update Text](https://docs.aspose.com/slides/pl/net/manage-textbox/#update-text) na tej stronie. 

{{% /alert %}}

## **Create a Text Box on a Slide**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation). 
2. Pobierz referencję do pierwszego slajdu za pomocą jego indeksu. 
3. Dodaj obiekt [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape) z właściwością [ShapeType](https://reference.aspose.com/slides/pl/net/aspose.slides/igeometryshape/properties/shapetype) ustawioną na `Rectangle` w określonej pozycji na slajdzie i uzyskaj referencję do nowo dodanego obiektu `IAutoShape`. 
4. Dodaj właściwość `TextFrame` do obiektu `IAutoShape`, która będzie zawierała tekst. W poniższym przykładzie dodaliśmy ten tekst: *Aspose TextBox* 
5. Na koniec zapisz plik PPTX przy użyciu obiektu `Presentation`. 

Ten kod C# — implementacja powyższych kroków — pokazuje, jak dodać tekst do slajdu:

```c#
using Aspose.Slides;

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

    // Zapisuje prezentację na dysku
    pres.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Check for a Text Box Shape**

Aspose.Slides udostępnia właściwość [IsTextBox](https://reference.aspose.com/slides/pl/net/aspose.slides/autoshape/istextbox/) interfejsu [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/), pozwalającą na sprawdzenie kształtów i identyfikację pól tekstowych.

![Text box and shape](istextbox.png)

Ten kod C# pokazuje, jak sprawdzić, czy kształt został utworzony jako pole tekstowe: 

```c#
using Aspose.Slides;

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

Należy zauważyć, że jeśli po prostu dodasz autokształt przy użyciu metody `AddAutoShape` interfejsu [IShapeCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection/), właściwość `IsTextBox` tego autokształtu zwróci `false`. Jednak po dodaniu tekstu do autokształtu przy użyciu metody `AddTextFrame` lub właściwości `Text`, właściwość `IsTextBox` zwróci `true`.

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    // shape1.IsTextBox jest false
    shape1.AddTextFrame("shape 1");
    // shape1.IsTextBox jest true

    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
    // shape2.IsTextBox jest false
    shape2.TextFrame.Text = "shape 2";
    // shape2.IsTextBox jest true

    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
    // shape3.IsTextBox jest false
    shape3.AddTextFrame("");
    // shape3.IsTextBox jest false

    IAutoShape shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
    // shape4.IsTextBox jest false
    shape4.TextFrame.Text = "";
    // shape4.IsTextBox jest false
}
```

## **Find the Shape That Owns a Text Frame**

W ogólnym kodzie przetwarzania tekstu możesz otrzymać obiekt [ITextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/) nie wiedząc, który obiekt prezentacji go zawiera. Użyj właściwości [ITextFrame.ParentShape](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/parentshape/) aby przejść z powrotem do właściciela — [IShape](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/). 

Dla ramki tekstowej należącej do [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/) lub innego kształtu zawierającego tekst, [ITextFrame.ParentShape](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/parentshape/) jest ustawiona, a [ITextFrame.ParentCell](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/parentcell/) ma wartość `null`. Obie właściwości są tylko‑do‑odczytu i nie zmieniają własności po ich odczytaniu. Zawsze sprawdzaj, czy zwrócona wartość nie jest `null` przed dostępem do kształtu. 

Pełny przykład identyfikujący właścicieli kształtów i komórek tabel, w tym kształty powiązane z węzłami SmartArt, znajdziesz w sekcji [Search and Replace Text](/slides/pl/net/search-and-replace-text/).

## **Add Columns to a Text Box**

Aspose.Slides udostępnia właściwości [ColumnCount](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframeformat/properties/columncount) i [ColumnSpacing](https://reference.aspose.com/slides/pl/net/aspose.slides/textframeformat/properties/columnspacing) (z interfejsu [ITextFrameFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframeformat) oraz klasy [TextFrameFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/textframeformat)) umożliwiające dodawanie kolumn do pól tekstowych. Możesz określić liczbę kolumn w polu tekstowym oraz odstęp w punktach między kolumnami. 

Ten kod w C# demonstruje opisane działanie: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

	// Pobiera format tekstu z TextFrame
	ITextFrameFormat format = aShape.TextFrame.TextFrameFormat;

	// Określa liczbę kolumn w TextFrame
	format.ColumnCount = 3;

	// Określa odstęp między kolumnami
	format.ColumnSpacing = 10;

	// Zapisuje prezentację
	presentation.Save("ColumnCount.pptx", SaveFormat.Pptx);
}
```

## **Add Columns to a Text Frame**

Aspose.Slides for .NET udostępnia właściwość [ColumnCount](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframeformat/properties/columncount) interfejsu [ITextFrameFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframeformat), która pozwala dodawać kolumny w ramkach tekstowych. Dzięki tej właściwości możesz określić preferowaną liczbę kolumn w ramce tekstowej. 

Ten kod C# pokazuje, jak dodać kolumnę wewnątrz ramki tekstowej:

```c#
using System.Diagnostics;
using Aspose.Slides;
using Aspose.Slides.Export;

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
        Debug.Assert(double.IsNaN(((AutoShape)test.Slides[0].Shapes[0]).TextFrame.TextFrameFormat.ColumnSpacing));
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

## **Update Text**

Aspose.Slides pozwala zmienić lub zaktualizować tekst zawarty w polu tekstowym lub wszystkie teksty w prezentacji. 

Ten kod C# demonstruje operację, w której wszystkie teksty w prezentacji są aktualizowane lub zmieniane:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using(Presentation pres = new Presentation("text.pptx"))
{
   foreach (ISlide slide in pres.Slides)
   {
       foreach (IShape shape in slide.Shapes)
       {
           if (shape is IAutoShape autoShape) //Sprawdza czy kształt obsługuje ramkę tekstową (IAutoShape). 
           {
              foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs) //Iteruje przez akapity w ramce tekstowej
               {
                   foreach (IPortion portion in paragraph.Portions) //Iteruje przez każdą część w akapicie
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

## **Add a Text Box with a Hyperlink** 

Możesz wstawić łącze wewnątrz pola tekstowego. Po kliknięciu pola tekstowego użytkownicy zostaną przekierowani do otwarcia łącza. 

1. Utwórz instancję klasy `Presentation`. 
2. Pobierz referencję do pierwszego slajdu za pomocą jego indeksu.  
3. Dodaj obiekt `AutoShape` z właściwością `ShapeType` ustawioną na `Rectangle` w określonej pozycji na slajdzie i uzyskaj referencję do nowo dodanego obiektu AutoShape. 
4. Dodaj `TextFrame` do obiektu `AutoShape`, który będzie zawierał *Aspose TextBox* jako domyślny tekst. 
5. Zainicjuj klasę `IHyperlinkManager`. 
6. Przypisz obiekt `IHyperlinkManager` do właściwości [HyperlinkClick](https://reference.aspose.com/slides/pl/net/aspose.slides/shape/properties/hyperlinkclick) powiązanej z wybraną częścią `TextFrame`. 
7. Na koniec zapisz plik PPTX przy użyciu obiektu `Presentation`. 

Ten kod C# — implementacja powyższych kroków — pokazuje, jak dodać pole tekstowe z hiperłączem do slajdu:

```c#
using Aspose.Slides;

// Tworzy instancję klasy Presentation, która reprezentuje plik PPTX
Presentation pptxPresentation = new Presentation();

// Pobiera pierwszy slajd w prezentacji
ISlide slide = pptxPresentation.Slides[0];

// Dodaje obiekt AutoShape z typem ustawionym na Rectangle
IShape pptxShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

// Rzutuje kształt na AutoShape
IAutoShape pptxAutoShape = (IAutoShape)pptxShape;

// Uzyskuje dostęp do właściwości ITextFrame powiązanej z AutoShape
pptxAutoShape.AddTextFrame("");

ITextFrame ITextFrame = pptxAutoShape.TextFrame;

// Dodaje trochę tekstu do ramki
ITextFrame.Paragraphs[0].Portions[0].Text = "Aspose.Slides";

// Ustawia hiperłącze dla tekstu części
IHyperlinkManager HypMan = ITextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkManager;
HypMan.SetExternalHyperlinkClick("http://www.aspose.com");

// Zapisuje prezentację PPTX
pptxPresentation.Save("hLinkPPTX_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **FAQ**

**Jaka jest różnica między polem tekstowym a tekstowym placeholderem przy pracy z master slajdami?**

[Placeholder](/slides/pl/net/manage-placeholder/) dziedziczy styl/pozycję z [mastera](https://reference.aspose.com/slides/pl/net/aspose.slides/masterslide/) i może być nadpisany w [układach](https://reference.aspose.com/slides/pl/net/aspose.slides/layoutslide/), podczas gdy zwykłe pole tekstowe jest niezależnym obiektem na konkretnym slajdzie i nie zmienia się przy przełączaniu układów.

**Jak wykonać masową zamianę tekstu w całej prezentacji, nie modyfikując tekstu w wykresach, tabelach i SmartArt?**

Ogranicz iterację do autokształtów posiadających ramki tekstowe i wyklucz obiekty osadzone ([charts](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/pl/net/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/pl/net/aspose.slides.smartart/smartart/)) poprzez przeglądanie ich kolekcji oddzielnie lub pomijanie tych typów obiektów.