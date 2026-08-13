---
title: Dodaj znaki wodne do prezentacji na Androidzie
linktitle: Znak wodny
type: docs
weight: 40
url: /pl/androidjava/watermark/
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
- Android
- Java
- Aspose.Slides
description: "Zarządzaj znakami wodnymi tekstowymi i graficznymi w prezentacjach PowerPoint i OpenDocument na Androidzie w języku Java, aby oznaczyć wersję roboczą, informacje poufne i inne."
---
## **Wprowadzenie**

**Znak wodny** w prezentacji jest napisem lub znakiem graficznym używanym na pojedynczym slajdzie lub we wszystkich slajdach prezentacji. Zwykle znak wodny służy do wskazania, że prezentacja jest wersją roboczą (np. znak „Draft”), że zawiera informacje poufne (np. znak „Confidential”), aby określić, do której firmy należy (np. znak „Company Name”), do identyfikacji autora prezentacji itd. Znak wodny pomaga zapobiegać naruszeniom praw autorskich, wskazując, że prezentacja nie powinna być kopiowana. Znaki wodne są używane zarówno w formatach prezentacji PowerPoint, jak i OpenOffice. W Aspose.Slides możesz dodać znak wodny do plików PowerPoint PPT, PPTX oraz OpenOffice ODP.

W [**Aspose.Slides**](https://products.aspose.com/slides/pl/android-java/) istnieje wiele sposobów tworzenia znaków wodnych w dokumentach PowerPoint lub OpenOffice oraz modyfikacji ich wyglądu i zachowania. Wspólnym elementem jest to, że aby dodać znaki wodne tekstowe, należy używać interfejsu [ITextFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/), a aby dodać znaki wodne graficzne, używać klasy [PictureFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/pictureframe/) lub wypełnić kształt znaku wodnego obrazem. `PictureFrame` implementuje interfejs [IShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/), co pozwala korzystać ze wszystkich elastycznych ustawień obiektu kształtu. Ponieważ `ITextFrame` nie jest kształtem i jego ustawienia są ograniczone, jest on opakowywany w obiekt [IShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/).

Istnieją dwa sposoby zastosowania znaku wodnego: na pojedynczym slajdzie lub na wszystkich slajdach prezentacji. Master slajd (Slide Master) jest używany do zastosowania znaku wodnego na wszystkich slajdach — znak wodny jest dodawany do Master slajdu, tam w pełni projektowany i stosowany do wszystkich slajdów, nie wpływając na możliwość modyfikacji znaku wodnego na poszczególnych slajdach.

Znak wodny jest zazwyczaj uznawany za nieedytowalny przez innych użytkowników. Aby zapobiec edycji znaku wodnego (a właściwie jego nadrzędnego kształtu), Aspose.Slides udostępnia funkcję blokowania kształtów. Konkretny kształt może być zablokowany na zwykłym slajdzie lub na Master slajdzie. Gdy kształt znaku wodnego jest zablokowany na Master slajdzie, zostaje zablokowany na wszystkich slajdach prezentacji.

Możesz ustawić nazwę znaku wodnego, aby w przyszłości, gdy będziesz chciał go usunąć, móc odnaleźć go w kolekcji kształtów slajdu po nazwie.

Możesz zaprojektować znak wodny w dowolny sposób; jednak zazwyczaj występują wspólne cechy znaków wodnych, takie jak wyśrodkowanie, obrót, pozycja na wierzchu itp. Poniżej pokażemy, jak je wykorzystać w przykładach.

## **Znak wodny tekstowy**

### **Dodaj znak wodny tekstowy do slajdu**

Aby dodać znak wodny tekstowy w formatach PPT, PPTX lub ODP, najpierw możesz dodać kształt do slajdu, a następnie dodać ramkę tekstową do tego kształtu. Ramka tekstowa jest reprezentowana przez interfejs [ITextFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/). Ten typ nie dziedziczy po [IShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/), który posiada szeroki zestaw właściwości umożliwiających elastyczne pozycjonowanie znaku wodnego. Dlatego obiekt [ITextFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextframe/) jest opakowywany w obiekt [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/). Aby dodać tekst znaku wodnego do kształtu, użyj metody [addTextFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) jak pokazano poniżej.

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="Zobacz także" %}} 
- [Jak używać klasy TextFrame](/slides/pl/androidjava/text-formatting/)
{{% /alert %}}

### **Dodaj znak wodny tekstowy do prezentacji**

Jeśli chcesz dodać znak wodny tekstowy do całej prezentacji (czyli do wszystkich slajdów jednocześnie), dodaj go do [MasterSlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/masterslide/). Reszta logiki jest taka sama, jak przy dodawaniu znaku wodnego do pojedynczego slajdu — utwórz obiekt [IAutoShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/) i następnie dodaj do niego znak wodny, używając metody [addTextFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="Zobacz także" %}} 
- [Jak używać Slide Master](/slides/pl/androidjava/slide-master/)
{{% /alert %}}

### **Ustaw przezroczystość kształtu znaku wodnego**

Domyślnie kształt prostokąta ma ustawione kolory wypełnienia i linii. Poniższy kod sprawia, że kształt jest przezroczysty.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    watermarkShape.getFillFormat().setFillType(FillType.NoFill);
    watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
} finally {
    presentation.dispose();
}
```

### **Ustaw czcionkę dla znaku wodnego tekstowego**

Możesz zmienić czcionkę znaku wodnego tekstowego, jak pokazano poniżej.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

    IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    textFormat.setLatinFont(new FontData("Arial"));
    textFormat.setFontHeight(50);
} finally {
    presentation.dispose();
}
```

### **Ustaw kolor tekstu znaku wodnego**

Aby ustawić kolor tekstu znaku wodnego, użyj poniższego kodu:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 150, red = 200, green = 200, blue = 200;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

    IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
    fillFormat.setFillType(FillType.Solid);
    fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
} finally {
    presentation.dispose();
}
```

### **Wyśrodkuj znak wodny tekstowy**

Możliwe jest wyśrodkowanie znaku wodnego na slajdzie; w tym celu wykonaj następujące czynności:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    float watermarkWidth = 400;
    float watermarkHeight = 40;
    float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
    float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

    IAutoShape watermarkShape = slide.getShapes().addAutoShape(
            ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

    ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
} finally {
    presentation.dispose();
}
```

Poniższy obrazek przedstawia efekt końcowy.

![Znak wodny tekstowy](text_watermark.png)

## **Znak wodny graficzny**

### **Dodaj znak wodny graficzny do prezentacji**

Aby dodać znak wodny graficzny do slajdu prezentacji, możesz wykonać następujące kroki:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.InputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    InputStream imageStream = new FileInputStream("watermark.png");
    IPPImage image = presentation.getImages().addImage(imageStream);

    watermarkShape.getFillFormat().setFillType(FillType.Picture);
    watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
} finally {
    presentation.dispose();
}
```

### **Zablokuj znak wodny przed edycją**

Jeśli konieczne jest uniemożliwienie edycji znaku wodnego, użyj metody [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--) na kształcie. Dzięki tej właściwości możesz chronić kształt przed zaznaczaniem, zmianą rozmiaru, przemieszczaniem, grupowaniem z innymi elementami, blokować jego tekst przed edycją i nie tylko:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    // Zablokuj kształt znaku wodnego przed modyfikacją
    watermarkShape.getAutoShapeLock().setSelectLocked(true);
    watermarkShape.getAutoShapeLock().setSizeLocked(true);
    watermarkShape.getAutoShapeLock().setTextLocked(true);
    watermarkShape.getAutoShapeLock().setPositionLocked(true);
    watermarkShape.getAutoShapeLock().setGroupingLocked(true);
} finally {
    presentation.dispose();
}
```

### **Przenieś znak wodny na wierzch**

W Aspose.Slides kolejność Z‑order kształtów można ustawić za pomocą metody [IShapeCollection.reorder](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-). Aby to zrobić, wywołaj tę metodę z listy slajdów prezentacji, przekazując referencję do kształtu oraz jego numer kolejności. Dzięki temu można przenieść kształt na wierzch lub cofnąć go na tył slajdu. Funkcja ta jest szczególnie przydatna, gdy trzeba umieścić znak wodny przed resztą elementów prezentacji:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    int shapeCount = slide.getShapes().size();
    slide.getShapes().reorder(shapeCount - 1, watermarkShape);
} finally {
    presentation.dispose();
}
```

### **Ustaw obrót znaku wodnego**

Poniżej przykład kodu pokazujący, jak dostosować obrót znaku wodnego, aby był ustawiony po przekątnej slajdu:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

    watermarkShape.setRotation((float)diagonalAngle);
} finally {
    presentation.dispose();
}
```

### **Ustaw nazwę znaku wodnego**

Aspose.Slides umożliwia ustawienie nazwy kształtu. Korzystając z nazwy kształtu, w przyszłości możesz uzyskać do niego dostęp w celu modyfikacji lub usunięcia. Aby ustawić nazwę kształtu znaku wodnego, przypisz ją metodzie [IAutoShape.setName](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    watermarkShape.setName("watermark");
} finally {
    presentation.dispose();
}
```

### **Usuń znak wodny**

Aby usunąć kształt znaku wodnego, użyj metody [IAutoShape.getName](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#getName--) w celu odnalezienia go w kolekcji kształtów slajdu. Następnie przekaż kształt znaku wodnego do metody [IShapeCollection.remove](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("watermarked.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape[] slideShapes = slide.getShapes().toArray();
    for (IShape shape : slideShapes) {
        if ("watermark".equals(shape.getName()))
        {
            slide.getShapes().remove(shape);
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

### Czym jest znak wodny i dlaczego powinienem go używać?

Znak wodny jest nakładką tekstową lub graficzną stosowaną na slajdach, która pomaga chronić własność intelektualną, zwiększyć rozpoznawalność marki lub zapobiec nieautoryzowanemu użyciu prezentacji.

### Czy mogę dodać znak wodny do wszystkich slajdów w prezentacji?

Tak, Aspose.Slides umożliwia programowe dodanie znaku wodnego do każdego slajdu w prezentacji. Możesz iterować po wszystkich slajdach i indywidualnie stosować ustawienia znaku wodnego.

### Jak mogę dostosować przezroczystość znaku wodnego?

Możesz dostosować przezroczystość znaku wodnego, modyfikując ustawienia wypełnienia ([getFillFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shape/#getFillFormat--)) kształtu. Dzięki temu znak wodny będzie subtelny i nie będzie rozpraszał uwagi od treści slajdu.

### Jakie formaty obrazów są obsługiwane dla znaków wodnych?

Aspose.Slides obsługuje różne formaty obrazów, takie jak PNG, JPEG, GIF, BMP, SVG i inne.

### Czy mogę dostosować czcionkę i styl znaku wodnego tekstowego?

Tak, możesz wybrać dowolną czcionkę, rozmiar i styl, aby pasowały do projektu Twojej prezentacji i zachowały spójność marki.

### Jak zmienić pozycję lub orientację znaku wodnego?

Pozycję i orientację znaku wodnego możesz zmieniać programowo, modyfikując współrzędne, rozmiar oraz właściwości obrotu kształtu.