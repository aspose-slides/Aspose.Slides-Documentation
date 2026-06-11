---
title: Dodaj znaki wodne do prezentacji w PHP
linktitle: Znak wodny
type: docs
weight: 40
url: /pl/php-java/watermark/
keywords:
- znak wodny
- tekstowy znak wodny
- graficzny znak wodny
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
- PHP
- Aspose.Slides
description: "Zarządzaj tekstowymi i graficznymi znakami wodnymi w prezentacjach PowerPoint i OpenDocument w PHP, aby wskazać wersję roboczą, poufne informacje, prawa autorskie i inne."
---
## **Wprowadzenie**

**Znak wodny** w prezentacji to znak tekstowy lub graficzny używany na jednym slajdzie lub we wszystkich slajdach prezentacji. Zwykle znak wodny służy do wskazania, że prezentacja jest szkicem (np. znak „Draft”), zawiera informacje poufne (np. znak „Confidential”), określenia, do której firmy należy (np. znak „Company Name”), identyfikacji autora prezentacji itp. Znak wodny pomaga zapobiegać naruszeniom praw autorskich, wskazując, że prezentacja nie powinna być kopiowana. Znaki wodne są używane zarówno w formatach prezentacji PowerPoint, jak i OpenOffice. W Aspose.Slides można dodać znak wodny do plików PowerPoint PPT, PPTX i OpenOffice ODP.

W [**Aspose.Slides**](https://products.aspose.com/slides/pl/php-java/) istnieje wiele sposobów tworzenia znaków wodnych w dokumentach PowerPoint lub OpenOffice oraz modyfikowania ich wyglądu i zachowania. Wspólnym elementem jest to, że aby dodać znak wodny tekstowy, należy używać klasy [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/), a aby dodać znak wodny graficzny, używać klasy [PictureFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/pictureframe/) lub wypełnić kształt znaku wodnego obrazem. `PictureFrame` implementuje klasę [Shape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/), co pozwala korzystać ze wszystkich elastycznych ustawień obiektu kształtu. Ponieważ `ITextFrame` nie jest kształtem i jego ustawienia są ograniczone, jest on opakowywany w obiekt [Shape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/).

Istnieją dwa sposoby zastosowania znaku wodnego: na pojedynczym slajdzie lub na wszystkich slajdach prezentacji. Slide Master jest używany do zastosowania znaku wodnego na wszystkich slajdach — znak wodny jest dodawany do Slide Master, tam w pełni projektowany i stosowany do wszystkich slajdów, nie wpływając na możliwość modyfikacji znaku wodnego na poszczególnych slajdach.

Znak wodny jest zazwyczaj uznawany za niedostępny do edycji przez innych użytkowników. Aby zapobiec edycji znaku wodnego (a dokładniej jego nadrzędnego kształtu), Aspose.Slides zapewnia funkcję blokowania kształtów. Określony kształt może być zablokowany na zwykłym slajdzie lub na Slide Master. Gdy kształt znaku wodnego jest zablokowany na Slide Master, jest on zablokowany na wszystkich slajdach prezentacji.

Można ustawić nazwę znaku wodnego, aby w przyszłości, gdy będzie potrzeba go usunąć, można było odnaleźć go w kolekcji kształtów slajdu po nazwie.

Znak wodny można projektować na dowolny sposób; jednak zazwyczaj posiada wspólne cechy, takie jak wyśrodkowanie, obrót, pozycja na wierzchu itp. Poniżej przedstawimy, jak je wykorzystać w przykładach.

## **Znak wodny tekstowy**

### **Dodaj znak wodny tekstowy do slajdu**

Aby dodać znak wodny tekstowy w formatach PPT, PPTX lub ODP, najpierw można dodać kształt do slajdu, a następnie dodać do tego kształtu ramkę tekstową. Ramka tekstowa jest reprezentowana przez klasę [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/). Ten typ nie dziedziczy po klasie [Shape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/), która posiada szeroki zestaw właściwości umożliwiających elastyczne pozycjonowanie znaku wodnego. Dlatego obiekt [TextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/textframe/) jest opakowywany w obiekt [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/). Aby dodać tekst znaku wodnego do kształtu, użyj metody [addTextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/#addTextFrame) jak pokazano poniżej.

```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$watermarkShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="Zobacz także" %}} 
- [Jak używać klasy TextFrame](/slides/pl/php-java/text-formatting/)
{{% /alert %}}

### **Dodaj znak wodny tekstowy do prezentacji**

Jeśli chcesz dodać znak wodny tekstowy do całej prezentacji (czyli do wszystkich slajdów jednocześnie), dodaj go do [MasterSlide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/masterslide/). Reszta logiki jest taka sama, jak przy dodawaniu znaku wodnego do pojedynczego slajdu — utwórz obiekt [AutoShape](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/) i następnie dodaj do niego znak wodny przy użyciu metody [addTextFrame](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/#addTextFrame).

```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$masterSlide = $presentation->getMasters()->get_Item(0);

$watermarkShape = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="Zobacz także" %}} 
- [Jak używać Slide Master](/slides/pl/php-java/slide-master/)
{{% /alert %}}

### **Ustaw przezroczystość kształtu znaku wodnego**

Domyślnie prostokątny kształt jest sformatowany kolorami wypełnienia i obrysu. Poniższe linie kodu czynią kształt przezroczystym.

```php
$watermarkShape->getFillFormat()->setFillType(FillType::NoFill);
$watermarkShape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
```

### **Ustaw czcionkę dla znaku wodnego tekstowego**

Możesz zmienić czcionkę znaku wodnego tekstowego, jak pokazano poniżej.

```php
$textFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
$textFormat->setLatinFont(new FontData("Arial"));
$textFormat->setFontHeight(50);
```

### **Ustaw kolor tekstu znaku wodnego**

Aby ustawić kolor tekstu znaku wodnego, użyj tego kodu:

```php
$alpha = 150;
$red = 200;
$green = 200;
$blue = 200;
$textColor = new Java("java.awt.Color", $red, $green, $blue, $alpha);

$fillFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();
$fillFormat->setFillType(FillType::Solid);
$fillFormat->getSolidFillColor()->setColor($textColor);
```

### **Wyśrodkuj znak wodny tekstowy**

Można wyśrodkować znak wodny na slajdzie, wykonując następujące kroki:

```php
$slideSize = $presentation->getSlideSize()->getSize();
$slideWidth = java_values($slideSize->getWidth());
$slideHeight = java_values($slideSize->getHeight());

$watermarkWidth = 400;
$watermarkHeight = 40;
$watermarkX = ($slideWidth - $watermarkWidth) / 2;
$watermarkY = ($slideHeight - $watermarkHeight) / 2;

$watermarkShape = $slide->getShapes()->addAutoShape(
        ShapeType::Rectangle, $watermarkX, $watermarkY, $watermarkWidth, $watermarkHeight);

$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);
```

Poniższy obrazek przedstawia ostateczny efekt.

![Znak wodny tekstowy](text_watermark.png)

## **Znak wodny graficzny**

### **Dodaj znak wodny graficzny do prezentacji**

Aby dodać znak wodny graficzny do slajdu prezentacji, można wykonać następujące czynności:

```php
$image = Images::fromFile("watermark.png");
$picture = $presentation->getImages()->addImage($image);
$image->dispose();

$watermarkShape->getFillFormat()->setFillType(FillType::Picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
```

### **Zablokuj znak wodny przed edycją**

Jeśli konieczne jest uniemożliwienie edycji znaku wodnego, użyj metody [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/pl/php-java/aspose.slides/autoshape/#getAutoShapeLock) na kształcie. Dzięki tej właściwości możesz chronić kształt przed zaznaczaniem, zmianą rozmiaru, przemieszczaniem, grupowaniem z innymi elementami, zablokować jego tekst przed edycją i nie tylko:

```php
// Zablokuj kształt znaku wodnego przed modyfikacją
$watermarkShape->getAutoShapeLock()->setSelectLocked(true);
$watermarkShape->getAutoShapeLock()->setSizeLocked(true);
$watermarkShape->getAutoShapeLock()->setTextLocked(true);
$watermarkShape->getAutoShapeLock()->setPositionLocked(true);
$watermarkShape->getAutoShapeLock()->setGroupingLocked(true);
```

### **Przenieś znak wodny na wierzch**

W Aspose.Slides kolejność Z‑order kształtów można ustawić metodą [ShapeCollection.reorder](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/#reorder). W tym celu należy wywołać tę metodę z listy slajdów prezentacji, przekazując odniesienie do kształtu oraz jego numer kolejności. W ten sposób można przenieść kształt na wierzch lub wysłać go na tył slajdu. Funkcja ta jest szczególnie przydatna, gdy trzeba umieścić znak wodny przed treścią prezentacji:

```php
$shapeCount = java_values($slide->getShapes()->size());
$slide->getShapes()->reorder($shapeCount - 1, $watermarkShape);
```

### **Ustaw obrót znaku wodnego**

Poniżej znajduje się przykład kodu, który pokazuje, jak dostosować obrót znaku wodnego, aby był położony ukośnie na slajdzie:

```php
$diagonalAngle = atan($slideWidth / $slideHeight) * 180 / M_PI;

$watermarkShape->setRotation($diagonalAngle);
```

### **Ustaw nazwę dla znaku wodnego**

Aspose.Slides umożliwia ustawienie nazwy kształtu. Korzystając z nazwy kształtu, możesz w przyszłości uzyskać do niego dostęp, aby go modyfikować lub usuwać. Aby ustawić nazwę kształtu znaku wodnego, przypisz ją metodzie [AutoShape.setName](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/#setName):

```php
$watermarkShape->setName("watermark");
```

### **Usuń znak wodny**

Aby usunąć kształt znaku wodnego, użyj metody [AutoShape.getName](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/#getName) w celu odnalezienia go w kolekcji kształtów slajdu. Następnie przekaż kształt znaku wodnego do metody [ShapeCollection.remove](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shapecollection/#remove):

```php
$slideShapes = $slide->getShapes()->toArray();
foreach ($slideShapes as $shape) {
    if ($shape->getName() === "watermark") {
        $slide->getShapes()->remove($shape);
    }
}
```

## **FAQ**

**Co to jest znak wodny i dlaczego powinienem go używać?**

Znak wodny to nakładka tekstowa lub graficzna stosowana na slajdach, która pomaga chronić własność intelektualną, zwiększyć rozpoznawalność marki lub zapobiec nieautoryzowanemu użyciu prezentacji.

**Czy mogę dodać znak wodny do wszystkich slajdów w prezentacji?**

Tak, Aspose.Slides umożliwia programowe dodanie znaku wodnego do każdego slajdu w prezentacji. Można przejść przez wszystkie slajdy i zastosować ustawienia znaku wodnego indywidualnie.

**Jak mogę dostosować przezroczystość znaku wodnego?**

Możesz dostosować przezroczystość znaku wodnego, modyfikując ustawienia wypełnienia ([getFillFormat](https://reference.aspose.com/slides/pl/php-java/aspose.slides/shape/getfillformat/)) kształtu. Dzięki temu znak wodny będzie subtelny i nie będzie odciągał uwagi od treści slajdu.

**Jakie formaty obrazu są obsługiwane dla znaków wodnych?**

Aspose.Slides obsługuje różne formaty obrazów, takie jak PNG, JPEG, GIF, BMP, SVG i inne.

**Czy mogę dostosować czcionkę i styl znaku wodnego tekstowego?**

Tak, możesz wybrać dowolną czcionkę, rozmiar i styl, aby dopasować znak wodny do projektu prezentacji i zachować spójność marki.

**Jak zmienić pozycję lub orientację znaku wodnego?**

Możesz programowo zmienić pozycję i orientację znaku wodnego, modyfikując współrzędne, rozmiar oraz właściwości obrotu kształtu.