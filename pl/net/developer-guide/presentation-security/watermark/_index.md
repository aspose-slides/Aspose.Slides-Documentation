---
title: Dodawanie znaków wodnych do prezentacji w .NET
linktitle: Znak wodny
type: docs
weight: 40
url: /pl/net/watermark/
keywords:
- znak wodny
- tekstowy znak wodny
- obrazkowy znak wodny
- dodaj znak wodny
- zmień znak wodny
- usuń znak wodny
- skasuj znak wodny
- dodaj znak wodny do PPT
- dodaj znak wodny do PPTX
- dodaj znak wodny do ODP
- usuń znak wodny z PPT
- usuń znak wodny z PPTX
- usuń znak wodny z ODP
- skasuj znak wodny z PPT
- skasuj znak wodny z PPTX
- skasuj znak wodny z ODP
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Zarządzaj tekstowymi i graficznymi znakami wodnymi w prezentacjach PowerPoint i OpenDocument w .NET, aby oznaczyć wersję roboczą, poufne informacje, prawa autorskie i inne."
---
## **Wprowadzenie**

**Znak wodny** w prezentacji to tekstowa lub graficzna pieczęć używana na pojedynczym slajdzie lub we wszystkich slajdach prezentacji. Zwykle znak wodny służy do wskazania, że prezentacja jest wersją roboczą (np. znak wodny „Draft”), że zawiera informacje poufne (np. znak wodny „Confidential”), aby określić, do której firmy należy (np. znak wodny „Company Name”), do identyfikacji autora prezentacji itp. Znak wodny pomaga zapobiegać naruszeniom praw autorskich, wskazując, że prezentacja nie powinna być kopiowana. Znaki wodne są używane zarówno w formacie PowerPoint, jak i OpenDocument. W Aspose.Slides możesz dodać znak wodny do formatów plików PowerPoint PPT, PPTX oraz OpenDocument ODP.

W [**Aspose.Slides**](https://products.aspose.com/slides/pl/net/) istnieje wiele sposobów tworzenia znaków wodnych w dokumentach PowerPoint lub OpenDocument oraz modyfikowania ich wyglądu i zachowania. Wspólnym elementem jest to, że do dodania znaków wodnych tekstowych należy używać interfejsu [ITextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/), a do dodania znaków wodnych graficznych – klasy [PictureFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/pictureframe/) lub wypełnienia kształtu znaku wodnego obrazem. `PictureFrame` implementuje interfejs [IShape](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape), co umożliwia korzystanie ze wszystkich elastycznych ustawień obiektu kształtu. Ponieważ `ITextFrame` nie jest kształtem i ma ograniczone możliwości konfiguracji, jest on opakowywany w obiekt [IShape](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape).

Są dwa sposoby zastosowania znaku wodnego: na pojedynczym slajdzie lub na wszystkich slajdach prezentacji. Do zastosowania znaku wodnego we wszystkich slajdach używa się Mastera slajdów – znak wodny jest dodawany do Mastera slajdów, w pełni tam projektowany i stosowany do wszystkich slajdów, nie wpływając na możliwość modyfikacji znaku wodnego na poszczególnych slajdach.

Znak wodny jest zazwyczaj uważany za niedostępny do edycji przez innych użytkowników. Aby zapobiec edycji znaku wodnego (a dokładniej jego nadrzędnego kształtu), Aspose.Slides udostępnia funkcję blokowania kształtów. Konkretny kształt może być zablokowany na zwykłym slajdzie lub na Masterze slajdów. Gdy kształt znaku wodnego jest zablokowany na Masterze slajdów, będzie on zablokowany we wszystkich slajdach prezentacji.

Możesz ustawić nazwę znaku wodnego, aby w przyszłości, gdy będziesz chciał go usunąć, móc odnaleźć go wśród kształtów slajdu po nazwie.

Znak wodny możesz zaprojektować w dowolny sposób; jednak zazwyczaj posiada on wspólne cechy, takie jak wyśrodkowanie, obrót, pozycja na wierzchu itp. Poniżej przedstawimy, jak je wykorzystać w przykładach.

## **Znak wodny tekstowy**

### **Dodaj tekstowy znak wodny do slajdu**

Aby dodać tekstowy znak wodny w formatach PPT, PPTX lub ODP, najpierw możesz dodać kształt do slajdu, a następnie dodać do tego kształtu ramkę tekstową. Ramka tekstowa jest reprezentowana przez interfejs [ITextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe). Ten typ nie dziedziczy po [IShape](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/), który posiada szeroki zestaw właściwości umożliwiających elastyczne pozycjonowanie znaku wodnego. Dlatego obiekt [ITextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe) jest opakowywany w obiekt [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/). Aby dodać tekst znaku wodnego do kształtu, użyj metody [AddTextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/methods/addtextframe) jak pokazano poniżej.

```cs
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// Dodaj znak wodny do slajdu.
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="info" title="Zobacz także" %}} 
- [Jak używać klasy TextFrame?](/slides/pl/net/text-formatting/)
{{% /alert %}}

### **Dodaj tekstowy znak wodny do prezentacji**

Jeśli chcesz dodać tekstowy znak wodny do całej prezentacji (czyli do wszystkich slajdów jednocześnie), dodaj go do [MasterSlide](https://reference.aspose.com/slides/pl/net/aspose.slides/masterslide/). Reszta logiki jest taka sama jak przy dodawaniu znaku wodnego do pojedynczego slajdu — utwórz obiekt [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/) i następnie dodaj do niego znak wodny przy użyciu metody [AddTextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/methods/addtextframe).

```cs
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

// Dodaj znak wodny do slajdu master.
IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="info" title="Zobacz także" %}} 
- [Jak używać Mastera slajdów?](/slides/pl/net/slide-master/)
{{% /alert %}}

### **Ustaw przezroczystość kształtu znaku wodnego**

Domyślnie prostokątny kształt jest sformatowany kolorem wypełnienia i linii. Oznacza to, że po dodaniu znaku wodnego może on mieć pełne tło lub obramowanie, które mogą odciągać uwagę od treści slajdu. Aby znak wodny pozostawał dyskretny i nie kolidował z wizualnym projektem prezentacji, możesz uczynić kształt całkowicie przezroczystym.

Poniższe linie kodu czynią kształt przezroczystym, usuwając zarówno kolor wypełnienia, jak i obramowania:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **Ustaw czcionkę dla tekstowego znaku wodnego**

Przed zastosowaniem tekstowego znaku wodnego na slajdzie warto dostosować jego wygląd, aby harmonizował z ogólnym projektem. Możesz zmienić typ i rozmiar czcionki, aby znak wodny był czytelny i estetycznie przyjemny. Dostosowanie czcionki może również pomóc w wzmocnieniu tożsamości marki lub po prostu dopasować się do stylu prezentacji.

Poniższy fragment kodu pokazuje, jak dostosować ustawienia czcionki znaku wodnego, wybierając konkretną czcionkę łacińską i ustawiając odpowiednią wysokość czcionki:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame("CONFIDENTIAL");

IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **Ustaw kolor tekstu znaku wodnego**

Przed zastosowaniem znaku wodnego ważne jest, aby odpowiednio ustawić kolor tekstu, tak aby dobrze komponował się z treścią slajdu, nie przytłaczając jej. Regulacja przejrzystości koloru (alpha) oraz składowych czerwonej, zielonej i niebieskiej pozwala stworzyć subtelny, półprzezroczysty znak wodny, który jest widoczny, ale nieinwazyjny. Takie podejście pomaga utrzymać skupienie na głównej części prezentacji, jednocześnie chroniąc jej zawartość.

Aby ustawić kolor tekstu znaku wodnego, użyj poniższego kodu:

```cs
using System.Drawing;
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame("CONFIDENTIAL");

int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **Wyśrodkuj tekstowy znak wodny**

Poprawne wyśrodkowanie tekstowego znaku wodnego może znacznie podnieść ogólną estetykę Twojej prezentacji, zapewniając symetryczne położenie znaku wodnego, niezależnie od wymiarów slajdu. Podejście to nie tylko nadaje slajdom profesjonalny wygląd, ale także zapewnia, że znak wodny nie zakłóca głównej treści slajdu.

Poniższy fragment kodu pokazuje, jak obliczyć środkową pozycję slajdu i odpowiednio umieścić tekstowy znak wodny:

```cs
using System.Drawing;
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

SizeF slideSize = presentation.SlideSize.Size;

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = (slideSize.Width - watermarkWidth) / 2;
float watermarkY = (slideSize.Height - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(
    ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

Obraz poniżej pokazuje ostateczny wynik.

![Tekstowy znak wodny](text_watermark.png)

## **Znak wodny obrazkowy**

### **Dodaj obrazkowy znak wodny do prezentacji**

W wielu przypadkach znak wodny w postaci obrazu może stanowić unikalny element brandingu lub bardziej atrakcyjną wizualnie alternatywę dla tekstowego znaku wodnego. Przed dodaniem znaku wodnego upewnij się, że plik obrazu jest dostępny (np. PNG z przezroczystością). Poniższy przykład pokazuje, jak wczytać obraz z systemu plików, dodać go do prezentacji, a następnie zastosować jako znak wodny przy użyciu właściwości wypełnienia kształtu.

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **Zablokuj znak wodny przed edycją**

Jeśli konieczne jest zapobieżenie edycji znaku wodnego, użyj właściwości [IAutoShape.ShapeLock](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/properties/shapelock) na kształcie. Dzięki tej właściwości możesz chronić kształt przed zaznaczeniem, zmianą rozmiaru, przemieszczaniem, grupowaniem z innymi elementami, zablokować jego tekst przed edycją i wiele więcej:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

// Zablokuj kształt znaku wodnego przed modyfikacją.
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

## **Przenieś znak wodny na wierzch**

W Aspose.Slides kolejność Z kształtów można ustawić metodą [IShapeCollection.Reorder](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection/reorder/#reorder). Aby to zrobić, należy wywołać tę metodę z listy slajdów prezentacji, przekazując referencję do kształtu oraz jego numer porządkowy. Dzięki temu można przenieść kształt na wierzch lub wysłać go na spód slajdu. Funkcja ta jest szczególnie przydatna, gdy trzeba umieścić znak wodny przed zawartością prezentacji:

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```

## **Ustaw rotację znaku wodnego**

Dostosowanie rotacji znaku wodnego może znacząco zwiększyć wizualny wpływ i subtelność Twojej prezentacji. Na przykład znak wodny po przekątnej może być mniej nachalny, a jednocześnie zapewniać solidną ochronę przed nieautoryzowanym użyciem. Poniższy przykład oblicza odpowiedni kąt na podstawie wymiarów slajdu, tak aby znak wodny był umieszczony po przekątnej slajdu. To dynamiczne obliczenie zapewnia skuteczność znaku wodnego niezależnie od różnorodnych rozmiarów slajdów.

```cs
using System.Drawing;
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

SizeF slideSize = presentation.SlideSize.Size;

double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **Ustaw nazwę znaku wodnego**

Aspose.Slides umożliwia ustawienie nazwy kształtu. Dzięki nazwie kształtu możesz w przyszłości uzyskać do niego dostęp w celu modyfikacji lub usunięcia. Aby ustawić nazwę kształtu znaku wodnego, przypisz ją do właściwości [IAutoShape.Name](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/properties/name):

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.Name = "watermark";
```

## **Usuń znak wodny**

Aby usunąć kształt znaku wodnego, użyj właściwości [IAutoShape.Name](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/properties/name) aby odnaleźć go wśród kształtów slajdu. Następnie przekaż kształt znaku wodnego do metody [IShapeCollection.Remove](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection/remove/):

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(shape);
    }
}
```

## **Przykład na żywo**

Możesz sprawdzić **Aspose.Slides free** [Dodaj znak wodny](https://products.aspose.app/slides/pl/watermark) i [Usuń znak wodny](https://products.aspose.app/slides/pl/watermark/remove-watermark) narzędzia online.

![Narzędzia online do dodawania i usuwania znaków wodnych](online_tools.png)

## **FAQ**

### Co to jest znak wodny i dlaczego powinienem go używać?

Znak wodny to nakładka tekstowa lub graficzna stosowana na slajdach, która pomaga chronić własność intelektualną, zwiększyć rozpoznawalność marki lub zapobiec nieautoryzowanemu użyciu prezentacji.

### Czy mogę dodać znak wodny do wszystkich slajdów w prezentacji?

Tak, Aspose.Slides umożliwia programowe dodanie znaku wodnego do każdego slajdu w prezentacji. Możesz iterować po wszystkich slajdach i stosować ustawienia znaku wodnego indywidualnie.

### Jak mogę dostosować przezroczystość znaku wodnego?

Możesz dostosować przezroczystość znaku wodnego, modyfikując ustawienia wypełnienia ([FillFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/shape/fillformat/)) kształtu. Dzięki temu znak wodny pozostaje subtelny i nie odciąga uwagi od treści slajdu.

### Jakie formaty obrazów są obsługiwane dla znaków wodnych?

Aspose.Slides obsługuje różne formaty obrazów, takie jak PNG, JPEG, GIF, BMP, SVG i inne.

### Czy mogę dostosować czcionkę i styl tekstowego znaku wodnego?

Tak, możesz wybrać dowolną czcionkę, rozmiar i styl, aby dopasować je do projektu prezentacji i zachować spójność marki.

### Jak zmienić pozycję lub orientację znaku wodnego?

Możesz programowo zmienić pozycję i orientację znaku wodnego, modyfikując współrzędne, rozmiar i właściwości rotacji kształtu.