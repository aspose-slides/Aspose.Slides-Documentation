---
title: Dodawanie znaków wodnych do prezentacji w .NET
linktitle: Znak wodny
type: docs
weight: 40
url: /pl/net/watermark/
keywords:
- znak wodny
- znak wodny tekstowy
- znak wodny graficzny
- dodaj znak wodny
- zmień znak wodny
- usuń znak wodny
- usuń znak wodny
- dodaj znak wodny do PPT
- dodaj znak wodny do PPTX
- dodaj znak wodny do ODP
- usuń znak wodny z PPT
- usuń znak wodny z PPTX
- usuń znak wodny z ODP
- usuń znak wodny z PPT
- usuń znak wodny z PPTX
- usuń znak wodny z ODP
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Zarządzaj znakami wodnymi tekstowymi i graficznymi w prezentacjach PowerPoint i OpenDocument w .NET, aby oznaczyć wersję roboczą, poufne informacje, prawa autorskie i inne."
---
## **Wprowadzenie**

**Znak wodny** w prezentacji to oznaczenie tekstowe lub graficzne używane na slajdzie lub we wszystkich slajdach prezentacji. Zazwyczaj znak wodny służy do wskazania, że prezentacja jest wersją roboczą (np. znak wodny „Draft”), zawiera poufne informacje (np. znak wodny „Confidential”), określa, do której firmy należy (np. znak wodny „Company Name”), identyfikuje autora prezentacji itp. Znak wodny pomaga zapobiegać naruszeniom praw autorskich, sygnalizując, że prezentacji nie należy kopiować. Znaki wodne są używane zarówno w formatach prezentacji PowerPoint, jak i OpenDocument. W Aspose.Slides możesz dodać znak wodny do plików PowerPoint PPT, PPTX oraz OpenDocument ODP.

W [**Aspose.Slides**](https://products.aspose.com/slides/pl/net/) istnieje wiele sposobów tworzenia znaków wodnych w dokumentach PowerPoint lub OpenDocument oraz modyfikowania ich projektu i zachowania. Wspólnym elementem jest to, że aby dodać znaki wodne tekstowe, należy używać interfejsu [ITextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/), a aby dodać znaki wodne graficzne, używać klasy [PictureFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/pictureframe/) lub wypełnić kształt znaku wodnego obrazem. `PictureFrame` implementuje interfejs [IShape](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape) , co pozwala korzystać ze wszystkich elastycznych ustawień obiektu kształtu. Ponieważ `ITextFrame` nie jest kształtem i jego ustawienia są ograniczone, jest on opakowywany w obiekt [IShape](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape) .

Istnieją dwa sposoby zastosowania znaku wodnego: na pojedynczym slajdzie lub na wszystkich slajdach prezentacji. Do zastosowania znaku wodnego we wszystkich slajdach używa się Mastera slajdów – znak wodny jest dodawany do Mastera slajdów, w pełni projektowany tam i stosowany do wszystkich slajdów bez wpływu na możliwość modyfikacji znaku wodnego na poszczególnych slajdach.

Znak wodny jest zazwyczaj uznawany za niedostępny do edycji przez innych użytkowników. Aby zapobiec edycji znaku wodnego (a dokładniej jego nadrzędnego kształtu), Aspose.Slides udostępnia funkcję blokowania kształtów. Konkretny kształt może zostać zablokowany na zwykłym slajdzie lub na Masterze slajdów. Gdy kształt znaku wodnego jest zablokowany na Masterze slajdów, zostaje zablokowany we wszystkich slajdach prezentacji.

Możesz ustawić nazwę znaku wodnego, aby w przyszłości, gdy będziesz chciał go usunąć, móc odnaleźć go w kształtach slajdu po nazwie.

Możesz zaprojektować znak wodny na dowolny sposób; jednak zazwyczaj znaki wodne mają wspólne cechy, takie jak wyśrodkowanie, obrót, pozycja na wierzchu itp. Poniżej pokażemy, jak korzystać z tych funkcji w przykładach.

## **Znak wodny tekstowy**

### **Dodaj znak wodny tekstowy do slajdu**

Aby dodać znak wodny tekstowy w plikach PPT, PPTX lub ODP, najpierw możesz dodać kształt do slajdu, a następnie dodać do tego kształtu ramkę tekstową. Ramka tekstowa jest reprezentowana przez interfejs [ITextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe). Ten typ nie dziedziczy po [IShape](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/), który posiada szeroki zestaw właściwości umożliwiających elastyczne pozycjonowanie znaku wodnego. Dlatego obiekt [ITextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe) jest opakowywany w obiekt [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/) . Aby dodać tekst znaku wodnego do kształtu, użyj metody [AddTextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/methods/addtextframe) jak pokazano poniżej.

```cs
string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// Dodaj znak wodny do slajdu.
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="primary" title="Zobacz także" %}} 
- [Jak używać klasy TextFrame?](/slides/pl/net/text-formatting/)
{{% /alert %}}

### **Dodaj znak wodny tekstowy do prezentacji**

Jeśli chcesz dodać znak wodny tekstowy do całej prezentacji (czyli do wszystkich slajdów jednocześnie), dodaj go do [MasterSlide](https://reference.aspose.com/slides/pl/net/aspose.slides/masterslide/). Reszta logiki jest taka sama, jak przy dodawaniu znaku wodnego do pojedynczego slajdu – utwórz obiekt [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/) i następnie dodaj do niego znak wodny przy użyciu metody [AddTextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/methods/addtextframe).

```cs
string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

// Dodaj znak wodny do master slajdu.
IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="primary" title="Zobacz także" %}} 
- [Jak używać Slide Master?](/slides/pl/net/slide-master/)
{{% /alert %}}

### **Ustaw przezroczystość kształtu znaku wodnego**

Domyślnie prostokątny kształt ma ustawione kolory wypełnienia i linii. Oznacza to, że po dodaniu znaku wodnego może on pojawić się z jednolitym tłem lub obramowaniem, które mogą odwracać uwagę od treści slajdu. Aby zapewnić, że znak wodny pozostanie dyskretny i nie będzie ingerował w wizualny projekt prezentacji, możesz całkowicie uczynić kształt przezroczystym.

Poniższe linie kodu usuwają zarówno kolor wypełnienia, jak i obramowania, czyniąc kształt przezroczystym:

```cs
watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **Ustaw czcionkę dla znaku wodnego tekstowego**

Zanim zastosujesz znak wodny tekstowy na slajdzie, warto dostosować jego wygląd tak, aby był spójny z ogólnym projektem. Możesz zmienić typ i rozmiar czcionki, aby znak wodny był czytelny i estetycznie dopasowany. Dostosowanie czcionki może także pomóc w podkreśleniu tożsamości marki lub po prostu dopasować się do stylu prezentacji.

Poniższy fragment kodu pokazuje, jak ustawić czcionkę znaku wodnego, wybierając konkretną czcionkę łacińską i określając odpowiednią wysokość czcionki:

```cs
IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **Ustaw kolor tekstu znaku wodnego**

Zanim zastosujesz znak wodny, należy upewnić się, że kolor tekstu jest odpowiednio dobrany, aby współgrał z treścią slajdu i nie przytłaczał jej. Regulacja przezroczystości koloru (alpha) oraz składników czerwonego, zielonego i niebieskiego pozwala stworzyć subtelny, półprzezroczysty znak wodny, który jest widoczny, ale nieinwazyjny. Takie podejście pomaga utrzymać uwagę na głównej zawartości prezentacji, jednocześnie chroniąc treść.

Aby ustawić kolor tekstu znaku wodnego, użyj poniższego kodu:

```cs
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **Wyśrodkuj znak wodny tekstowy**

Poprawne wyśrodkowanie znaku wodnego tekstowego może znacznie podnieść estetykę prezentacji, zapewniając symetryczne położenie znaku niezależnie od wymiarów slajdu. Taki układ nadaje slajdom profesjonalny wygląd i zapewnia, że znak wodny nie zakłóca głównej treści.

Poniższy fragment kodu pokazuje, jak obliczyć środkową pozycję slajdu i umieścić tam znak wodny tekstowy:

```cs
SizeF slideSize = presentation.SlideSize.Size;

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = (slideSize.Width - watermarkWidth) / 2;
float watermarkY = (slideSize.Height - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(
    ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

Poniższy obrazek pokazuje ostateczny rezultat.

![Znak wodny tekstowy](text_watermark.png)

## **Znak wodny graficzny**

### **Dodaj znak wodny graficzny do prezentacji**

W wielu przypadkach znak wodny graficzny może zapewnić unikalny element brandingowy lub bardziej atrakcyjną wizualnie alternatywę dla znaku wodnego tekstowego. Przed dodaniem znaku wodnego upewnij się, że plik obrazu jest dostępny (np. PNG z przezroczystością). Poniższy przykład pokazuje, jak wczytać obraz z systemu plików, dodać go do prezentacji i zastosować jako znak wodny za pomocą właściwości wypełnienia kształtu.

```cs
using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **Zablokuj znak wodny przed edycją**

Jeśli konieczne jest uniemożliwienie edycji znaku wodnego, użyj właściwości [IAutoShape.ShapeLock](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/properties/shapelock) na kształcie. Dzięki tej właściwości możesz chronić kształt przed zaznaczaniem, zmianą rozmiaru, przemieszczeniem, grupowaniem z innymi elementami, zablokować jego tekst przed edycją i nie tylko:

```cs
// Zablokuj modyfikację kształtu znaku wodnego.
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

## **Przenieś znak wodny na przód**

W Aspose.Slides kolejność Z‑order kształtów można ustawić metodą [IShapeCollection.Reorder](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection/reorder/#reorder). Aby to zrobić, wywołaj tę metodę z listy slajdów prezentacji, przekazując referencję do kształtu i jego numer kolejności. Dzięki temu można przenieść kształt na przód lub wysłać go na tył slajdu. Funkcja ta jest szczególnie przydatna, gdy chcesz umieścić znak wodny przed zawartością prezentacji:

```cs
int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```

## **Ustaw obrót znaku wodnego**

Regulacja obrotu znaku wodnego może znacząco zwiększyć jego wizualny wpływ i dyskrecję w prezentacji. Diagonalny znak wodny, na przykład, jest mniej inwazyjny, a jednocześnie zapewnia skuteczną ochronę przed nieautoryzowanym użyciem. Poniższy przykład oblicza odpowiedni kąt na podstawie wymiarów slajdu, tak aby znak wodny był ustawiony ukośnie na całej powierzchni slajdu. Takie dynamiczne obliczenie gwarantuje, że znak wodny pozostaje skuteczny niezależnie od rozmiaru slajdu.

```cs
double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **Ustaw nazwę znaku wodnego**

Aspose.Slides pozwala ustawić nazwę kształtu. Dzięki nazwie kształtu możesz w przyszłości odnaleźć go, aby zmodyfikować lub usunąć. Aby ustawić nazwę kształtu znaku wodnego, przypisz ją do właściwości [IAutoShape.Name](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/properties/name):

```cs
watermarkShape.Name = "watermark";
```

## **Usuń znak wodny**

Aby usunąć kształt znaku wodnego, użyj właściwości [IAutoShape.Name](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/properties/name) do odnalezienia go w kształtach slajdu. Następnie przekaż kształt znaku wodnego do metody [IShapeCollection.Remove](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection/remove/) :

```cs
List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(watermarkShape);
    }
}
```

## **Przykład na żywo**

Możesz chcieć wypróbować darmowe narzędzia online **Aspose.Slides free** do [Dodawania znaku wodnego](https://products.aspose.app/slides/pl/watermark) oraz [Usuwania znaku wodnego](https://products.aspose.app/slides/pl/watermark/remove-watermark).

![Narzędzia online do dodawania i usuwania znaków wodnych](online_tools.png)

## **FAQ**

**Czym jest znak wodny i dlaczego powinienem go używać?**

Znak wodny to nakładka tekstowa lub graficzna aplikowana na slajdy, która pomaga chronić własność intelektualną, zwiększyć rozpoznawalność marki lub zapobiec nieautoryzowanemu użyciu prezentacji.

**Czy mogę dodać znak wodny do wszystkich slajdów w prezentacji?**

Tak, Aspose.Slides umożliwia programowe dodanie znaku wodnego do każdego slajdu w prezentacji. Można przeiterować wszystkie slajdy i zastosować ustawienia znaku wodnego indywidualnie.

**Jak mogę regulować przezroczystość znaku wodnego?**

Przezroczystość znaku wodnego można regulować, modyfikując ustawienia wypełnienia ([FillFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/shape/fillformat/)) kształtu. Dzięki temu znak wodny pozostaje subtelny i nie odciąga uwagi od treści slajdu.

**Jakie formaty obrazu są obsługiwane dla znaków wodnych?**

Aspose.Slides obsługuje różne formaty obrazu, takie jak PNG, JPEG, GIF, BMP, SVG i inne.

**Czy mogę dostosować czcionkę i styl tekstowego znaku wodnego?**

Tak, możesz wybrać dowolną czcionkę, rozmiar i styl, aby dopasować znak wodny do projektu prezentacji i zachować spójność marki.

**Jak zmienić pozycję lub orientację znaku wodnego?**

Pozycję i orientację znaku wodnego można programowo dostosować, modyfikując współrzędne, rozmiar oraz właściwość obrotu kształtu.