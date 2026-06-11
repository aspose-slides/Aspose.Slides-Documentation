---
title: Dodawanie znaków wodnych do prezentacji w C++
linktitle: Znak wodny
type: docs
weight: 40
url: /pl/cpp/watermark/
keywords:
- znak wodny
- tekstowy znak wodny
- obrazowy znak wodny
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
- C++
- Aspose.Slides
description: "Zarządzaj tekstowymi i graficznymi znakami wodnymi w prezentacjach PowerPoint i OpenDocument w C++, aby oznaczyć wersję roboczą, informacje poufne, prawa autorskie i inne."
---
## **Wstęp**

**Znak wodny** w prezentacji to znacznik tekstowy lub graficzny używany na slajdzie lub we wszystkich slajdach prezentacji. Zazwyczaj znak wodny służy do wskazania, że prezentacja jest wersją roboczą (np. znak wodny „Draft”), zawiera informacje poufne (np. znak wodny „Confidential”), określenia, do której firmy należy (np. znak wodny „Company Name”), identyfikacji autora prezentacji itp. Znak wodny pomaga zapobiegać naruszeniom praw autorskich, wskazując, że prezentacja nie powinna być kopiowana. Znaki wodne są używane zarówno w formatach PowerPoint, jak i OpenOffice. W Aspose.Slides możesz dodać znak wodny do plików PowerPoint PPT, PPTX oraz OpenOffice ODP.

W [**Aspose.Slides**](https://products.aspose.com/slides/pl/cpp/), istnieje wiele sposobów tworzenia znaków wodnych w dokumentach PowerPoint lub OpenOffice oraz modyfikowania ich wyglądu i zachowania. Wspólnym elementem jest to, że aby dodać tekstowy znak wodny, należy używać interfejsu [ITextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/), a aby dodać graficzny znak wodny, używać klasy [PictureFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/pictureframe/) lub wypełnić kształt znaku wodnego obrazem. `PictureFrame` implementuje interfejs [IShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/), co pozwala korzystać ze wszystkich elastycznych ustawień obiektu kształtu. Ponieważ `ITextFrame` nie jest kształtem i jego ustawienia są ograniczone, jest on opakowany w obiekt [IShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/).

Znak wodny może być zastosowany na dwa sposoby: do pojedynczego slajdu lub do wszystkich slajdów prezentacji. Master slajdu jest używany do zastosowania znaku wodnego do wszystkich slajdów — znak wodny jest dodawany do Mastera slajdu, tam w pełni projektowany i stosowany do wszystkich slajdów bez wpływu na możliwość edycji znaku wodnego na poszczególnych slajdach.

Znak wodny jest zazwyczaj uważany za nieedytowalny przez innych użytkowników. Aby zapobiec edycji znaku wodnego (a dokładniej jego rodzica‑kształtu), Aspose.Slides udostępnia funkcję blokowania kształtu. Konkretny kształt może być zablokowany na zwykłym slajdzie lub na Masterze slajdu. Gdy kształt znaku wodnego jest zablokowany na Masterze slajdu, zostaje zablokowany na wszystkich slajdach prezentacji.

Możesz ustawić nazwę dla znaku wodnego, aby w przyszłości, gdy będziesz chciał go usunąć, móc odnaleźć go w kolekcji kształtów slajdu po nazwie.

Znak wodny możesz zaprojektować w dowolny sposób; jednak zazwyczaj występują wspólne cechy znaków wodnych, takie jak wyśrodkowanie, rotacja, położenie na wierzchu itp. Poniżej omówimy, jak je wykorzystać w przykładach.

## **Tekstowy znak wodny**

### **Dodanie tekstowego znaku wodnego do slajdu**

Aby dodać tekstowy znak wodny w PPT, PPTX lub ODP, najpierw możesz dodać kształt do slajdu, a następnie dodać do tego kształtu ramkę tekstową. Ramka tekstowa jest reprezentowana przez interfejs [ITextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/). Ten typ nie dziedziczy po [IShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/), który posiada szeroki zestaw właściwości do elastycznego pozycjonowania znaku wodnego. Dlatego obiekt [ITextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframe/) jest opakowany w obiekt [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/). Aby dodać tekst znaku wodnego do kształtu, użyj metody [AddTextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/addtextframe/) jak pokazano poniżej.

```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="Zobacz także" %}} 
- [Jak używać klasy TextFrame](/slides/pl/cpp/text-formatting/)
{{% /alert %}}

### **Dodanie tekstowego znaku wodnego do prezentacji**

Jeśli chcesz dodać tekstowy znak wodny do całej prezentacji (czyli do wszystkich slajdów jednocześnie), dodaj go do [MasterSlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/masterslide/). Reszta logiki jest taka sama, jak przy dodawaniu znaku wodnego do pojedynczego slajdu — utwórz obiekt [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) i następnie dodaj do niego znak wodny za pomocą metody [AddTextFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/addtextframe/).

```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="Zobacz także" %}} 
- [Jak używać Mastera slajdu](/slides/pl/cpp/slide-master/)
{{% /alert %}}

### **Ustawienie przezroczystości kształtu znaku wodnego**

Domyślnie prostokątny kształt ma ustawione kolory wypełnienia i linii. Poniższe linie kodu sprawiają, że kształt jest przezroczysty.

```cpp
watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```

### **Ustawienie czcionki dla tekstowego znaku wodnego**

Możesz zmienić czcionkę tekstowego znaku wodnego, jak pokazano poniżej.

```cpp
auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```

### **Ustawienie koloru tekstu znaku wodnego**

Aby ustawić kolor tekstu znaku wodnego, użyj tego kodu:

```cpp
auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```

### **Wyśrodkowanie tekstowego znaku wodnego**

Możliwe jest wyśrodkowanie znaku wodnego na slajdzie; w tym celu wykonaj następujące kroki:

```cpp
auto slideSize = presentation->get_SlideSize()->get_Size();

auto watermarkWidth = 400;
auto watermarkHeight = 40;
auto watermarkX = (slideSize.get_Width() - watermarkWidth) / 2;
auto watermarkY = (slideSize.get_Height() - watermarkHeight) / 2;

auto watermarkShape = slide->get_Shapes()->AddAutoShape(
    ShapeType::Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);
```

Poniższy obraz przedstawia ostateczny wynik.

![The text watermark](text_watermark.png)

## **Graficzny znak wodny**

### **Dodanie graficznego znaku wodnego do prezentacji**

Aby dodać graficzny znak wodny do slajdu prezentacji, możesz wykonać następujące czynności:

```cpp
auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```

## **Zablokowanie znaku wodnego przed edycją**

Jeśli konieczne jest zapobieżenie edycji znaku wodnego, użyj metody [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/get_autoshapelock/) na kształcie. Dzięki tej właściwości możesz chronić kształt przed zaznaczaniem, zmianą rozmiaru, przemieszczaniem, grupowaniem z innymi elementami, zablokowaniem tekstu przed edycją i wieloma innymi działaniami:

```cpp
// Zablokuj kształt znaku wodnego przed modyfikacją
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->SizeLocked(true);
watermarkShape->get_AutoShapeLock()->TextLocked(true);
watermarkShape->get_AutoShapeLock()->PositionLocked(true);
watermarkShape->get_AutoShapeLock()->GroupingLocked(true);
```

## **Przeniesienie znaku wodnego na wierzch**

W Aspose.Slides kolejność Z‑kształtów można ustawić za pomocą metody [IShapeCollection::Reorder](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishapecollection/reorder/). Aby to zrobić, należy wywołać tę metodę z listy slajdów prezentacji, przekazując odwołanie do kształtu i jego numer kolejności. Dzięki temu można przenieść kształt na wierzch lub na spód slajdu. Funkcja ta jest szczególnie przydatna, gdy trzeba umieścić znak wodny przed zawartością prezentacji:

```cpp
auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```

## **Ustawienie rotacji znaku wodnego**

Poniżej znajduje się przykład kodu, który pokazuje, jak dostosować rotację znaku wodnego, aby był położony po przekątnej slajdu:

```cpp
auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```

## **Ustawienie nazwy dla znaku wodnego**

Aspose.Slides umożliwia ustawienie nazwy kształtu. Korzystając z nazwy kształtu, możesz w przyszłości odwołać się do niego, aby go zmodyfikować lub usunąć. Aby ustawić nazwę kształtu znaku wodnego, przypisz ją metodzie [IAutoShape::set_Name](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/set_name/):

```cpp
watermarkShape->set_Name(u"watermark");
```

## **Usunięcie znaku wodnego**

Aby usunąć kształt znaku wodnego, użyj metody [IAutoShape::get_Name](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/get_name/), aby znaleźć go w kolekcji kształtów slajdu. Następnie przekaż kształt znaku wodnego do metody [IShapeCollection::Remove](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishapecollection/remove/):

```cpp
auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"watermark", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(watermarkShape);
    }
}
```

## **Przykład na żywo**

Możesz wypróbować darmowe narzędzia Aspose.Slides **Add Watermark** i **Remove Watermark** dostępne online:

![Online tools to add and remove watermarks](online_tools.png)

## **FAQ**

**Czym jest znak wodny i dlaczego powinienem go używać?**

Znak wodny to nakładka tekstowa lub graficzna stosowana na slajdach, która pomaga chronić własność intelektualną, zwiększyć rozpoznawalność marki lub zapobiec nieautoryzowanemu użyciu prezentacji.

**Czy mogę dodać znak wodny do wszystkich slajdów w prezentacji?**

Tak, Aspose.Slides umożliwia programistyczne dodanie znaku wodnego do każdego slajdu w prezentacji. Możesz iterować po wszystkich slajdach i zastosować ustawienia znaku wodnego indywidualnie.

**Jak mogę dostosować przezroczystość znaku wodnego?**

Możesz dostosować przezroczystość znaku wodnego, modyfikując ustawienia wypełnienia ([FillFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/shape/get_fillformat/)) kształtu. Dzięki temu znak wodny będzie subtelny i nie będzie rozpraszał uwagi od treści slajdu.

**Jakie formaty obrazów są obsługiwane dla znaków wodnych?**

Aspose.Slides obsługuje różne formaty obrazów, takie jak PNG, JPEG, GIF, BMP, SVG i inne.

**Czy mogę dostosować czcionkę i styl tekstowego znaku wodnego?**

Tak, możesz wybrać dowolną czcionkę, rozmiar i styl, aby dopasować je do projektu prezentacji i utrzymać spójność marki.

**Jak zmienić pozycję lub orientację znaku wodnego?**

Możesz programowo zmienić pozycję i orientację znaku wodnego, modyfikując współrzędne, rozmiar oraz właściwość rotacji kształtu.