---
title: Zarządzanie polami tekstowymi w prezentacjach przy użyciu Javy
linktitle: Zarządzaj polem tekstowym
type: docs
weight: 20
url: /pl/java/manage-textbox/
keywords:
- pole tekstowe
- ramka tekstowa
- dodaj tekst
- zaktualizuj tekst
- utwórz pole tekstowe
- sprawdź pole tekstowe
- dodaj kolumnę tekstu
- dodaj hiperłącze
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Twórz, identyfikuj, formatuj i aktualizuj pola tekstowe w prezentacjach PowerPoint oraz OpenDocument przy użyciu Aspose.Slides dla Javy."
---
## **Wprowadzenie**

W Aspose.Slides for Java tekst slajdu jest przechowywany w ramkach tekstowych, które należą do kształtów. Interfejs [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/) reprezentuje najczęstszy kształt zawierający tekst i udostępnia jego tekst za pośrednictwem metody [IAutoShape.getTextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/#getTextFrame--) .

{{% alert color="info" title="Note" %}}
Każdy auto‑kształt implementuje [IShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/), ale nie każdy kształt jest auto‑kształtem ani nie obsługuje ramki tekstowej. Podczas przetwarzania istniejącej prezentacji należy sprawdzić, czy kształt implementuje [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/) przed dostępem do jego tekstu.
{{% /alert %}}

## **Utworzenie pola tekstowego na slajdzie**

Aby utworzyć pole tekstowe, dodaj auto‑kształt do slajdu, dodaj tekst do jego ramki tekstowej i zapisz prezentację. Poniższy przykład tworzy prostokątne pole tekstowe:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
    textBox.addTextFrame("Aspose TextBox");

    presentation.save("TextBox.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Współrzędne i wymiary przekazywane do [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) są mierzone w punktach. [IAutoShape.addTextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) inicjalizuje ramkę tekstową podanym tekstem.

## **Sprawdzenie, czy kształt jest polem tekstowym**

Użyj metody [IAutoShape.isTextBox](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/#isTextBox--) aby określić, czy auto‑kształt jest traktowany jako pole tekstowe. Jest to przydatne, gdy prezentacja zawiera zarówno kształty z tekstem, jak i czysto graficzne auto‑kształty.

![Pole tekstowe i kształt](istextbox.png)

Poniższy przykład sprawdza każdy auto‑kształt w prezentacji:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 120, 40);
    textBox.addTextFrame("Text box");
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 150, 10, 40, 40);

    for (ISlide currentSlide : presentation.getSlides()) {
        for (IShape shape : currentSlide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                System.out.println(autoShape.isTextBox() ? "The shape is a text box." : "The shape is not a text box.");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Nowo dodany auto‑kształt nie jest uznawany za pole tekstowe, dopóki nie zawiera niepustego tekstu. Tekst można dostarczyć za pomocą [IAutoShape.addTextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) lub [ITextFrame.setText](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/#setText-java.lang.String-). Dodanie lub przypisanie pustego ciągu powoduje, że [IAutoShape.isTextBox](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/#isTextBox--) zwraca `false`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    shape1.addTextFrame("Shape 1");
    System.out.println(shape1.isTextBox());

    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 100, 40);
    shape2.getTextFrame().setText("Shape 2");
    System.out.println(shape2.isTextBox());

    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 100, 40);
    shape3.addTextFrame("");
    System.out.println(shape3.isTextBox());

    IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 100, 40);
    shape4.getTextFrame().setText("");
    System.out.println(shape4.isTextBox());
} finally {
    presentation.dispose();
}
```

Pierwsze dwa wywołania drukują `true`; ostatnie dwa drukują `false`.

## **Znajdź kształt, który jest właścicielem ramki tekstowej**

Ogólny kod przetwarzający tekst może otrzymać obiekt [ITextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/) bez wiedzy, który obiekt prezentacji go zawiera. Użyj tylko‑do‑odczytu metody [ITextFrame.getParentShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/#getParentShape--) aby przejść z powrotem do jego właściciela [IShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ishape/).

Dla ramki tekstowej będącej własnością auto‑kształtu lub innego kształtu zawierającego tekst, [ITextFrame.getParentShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/#getParentShape--) zwraca właściciela, a [ITextFrame.getParentCell](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/#getParentCell--) zwraca `null`. Sprawdź zwróconą wartość przed dostępem. Aby zidentyfikować zarówno właścicieli kształtów, jak i komórek tabel, włączając kształty powiązane z węzłami SmartArt, zobacz [Search and Replace Text](/slides/pl/java/search-and-replace-text/).

## **Dodaj kolumny do pola tekstowego**

Metoda [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframeformat/#setColumnCount-int-) dzieli ramkę tekstową na kolumny, natomiast [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframeformat/#setColumnSpacing-double-) ustawia odstęp między kolumnami w punktach. Oba ustawienia należą do [ITextFrameFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframeformat/) i mogą być zmieniane poprzez ramkę tekstową istniejącego pola tekstowego. Tekst przepływa między kolumnami wewnątrz tego samego kształtu; nie przechodzi do innego kształtu.

Poniższy przykład tworzy pole tekstowe z trzema kolumnami i odstępem 10 punktów między kolumnami, zapisuje prezentację i odczytuje zapisane ustawienia z pliku wyjściowego:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    textBox.addTextFrame("This text is distributed automatically across all columns in the text box.");

    ITextFrameFormat textFrameFormat = textBox.getTextFrame().getTextFrameFormat();
    textFrameFormat.setColumnCount(3);
    textFrameFormat.setColumnSpacing(10);

    presentation.save("TextBoxColumns.pptx", SaveFormat.Pptx);

    Presentation savedPresentation = new Presentation("TextBoxColumns.pptx");
    try {
        IAutoShape savedTextBox = (IAutoShape) savedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
        ITextFrameFormat savedFormat = savedTextBox.getTextFrame().getTextFrameFormat();
        System.out.println("Columns: " + savedFormat.getColumnCount() + "; spacing: " + savedFormat.getColumnSpacing() + " points");
    } finally {
        savedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **Wyodrębnij tekst z poszczególnych kolumn**

Użyj [ITextFrame.splitTextByColumns](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/#splitTextByColumns--) aby pobrać tekst przypisany do każdej widocznej kolumny w istniejącej ramce tekstowej. Metoda zwraca jeden ciąg dla każdej kolumny, w kolejności czytania kolumnowej. Ramka tekstowa z jedną kolumną zwraca tablicę z jednym elementem, a pusta kolumna jest reprezentowana pustym ciągiem. Ciągi zawierają wyłącznie zwykły tekst; formatowanie na poziomie fragmentu nie jest zachowywane.

Jest to przydatne, gdy potrzebujesz:

- Wyodrębnić tekst zachowując kolejność czytania opartą na kolumnach.
- Indeksować lub porównać zawartość slajdów wielokolumnowych.
- Wyeksportować każdą kolumnę do osobnego pliku, pola w bazie danych lub innego docelowego miejsca.
- Zbadać, jak tekst jest redystrybuowany po zmianie liczby kolumn przy użyciu [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframeformat/#setColumnCount-int-), odstępu przy użyciu [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframeformat/#setColumnSpacing-double-), czcionki lub rozmiaru ramki tekstowej.

Metoda raportuje tekst rozdzielony w bieżącej [ITextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/); nie powoduje automatycznego przepływu tekstu pomiędzy oddzielnymi kształtami lub polami tekstowymi. Rozkład kolumn może zależeć od dostępnych czcionek i innych ustawień układu tekstu, dlatego upewnij się, że wymagane czcionki są dostępne, gdy ważne są spójne wyniki.

Poniższy przykład ładuje prezentację, znajduje pierwszy auto‑kształt wielokolumnowy z ramką tekstową, odczytuje jego skonfigurowaną liczbę kolumn i zapisuje tekst z każdej kolumny do osobnego pliku. Kształty, które nie udostępniają ramki tekstowej, są pomijane.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("MultiColumnText.pptx");
try {
    IAutoShape textBox = null;
    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;
            if (autoShape.getTextFrame() != null) {
                int columnCount = autoShape.getTextFrame().getTextFrameFormat().getColumnCount();
                if (columnCount > 1) {
                    textBox = autoShape;
                    break;
                }
            }
        }
    }

    if (textBox == null) {
        System.out.println("No multi-column text frame was found.");
    } else {
        ITextFrame textFrame = textBox.getTextFrame();
        int configuredColumnCount = textFrame.getTextFrameFormat().getColumnCount();
        String[] columnTexts = textFrame.splitTextByColumns();

        System.out.println("Configured columns: " + configuredColumnCount);

        for (int columnIndex = 0; columnIndex < columnTexts.length; columnIndex++) {
            int columnNumber = columnIndex + 1;
            String columnText = columnTexts[columnIndex];
            System.out.println("Column " + columnNumber + ": " + columnText);
            Path outputPath = Paths.get("Column-" + columnNumber + ".txt");
            byte[] textBytes = columnText.getBytes(StandardCharsets.UTF_8);
            try {
                Files.write(outputPath, textBytes);
            } catch (IOException exception) {
                System.out.println("Could not write column " + columnNumber + ": " + exception.getMessage());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Aktualizacja tekstu**

Aby zaktualizować tekst w całej prezentacji, iteruj po slajdach i kształtach, wybieraj auto‑kształty i edytuj ich fragmenty tekstu. Praca na poziomie fragmentu pozwala zmienić zarówno tekst, jak i formatowanie znaków.

Poniższy przykład zamienia każde wystąpienie `years` na `months` w tekście auto‑kształtu i pogrubia każdy zmieniony fragment:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Text.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }

            IAutoShape autoShape = (IAutoShape) shape;
            ITextFrame textFrame = autoShape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (IParagraph paragraph : textFrame.getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    String text = portion.getText();
                    if (text != null && text.contains("years")) {
                        portion.setText(text.replace("years", "months"));
                        portion.getPortionFormat().setFontBold(NullableBool.True);
                    }
                }
            }
        }
    }

    presentation.save("TextChanged.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ta iteracja aktualizuje tekst wyłącznie w auto‑kształtach. Tekst przechowywany w tabelach, wykresach, SmartArt lub grupowanych kształtach wymaga iteracji po własnych kolekcjach tych obiektów.

## **Dodaj pole tekstowe z hiperłączem**

Hiperłącze może być przypisane do konkretnego fragmentu tekstu, tak aby tylko ten fragment działał jako klikalny link. Użyj [IHyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-) aby powiązać fragment z zewnętrznym adresem URL.

Poniższy przykład tworzy tekst z linkiem i zapisuje go w prezentacji:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 200, 50);
    textBox.addTextFrame("Aspose.Slides");

    IPortion textPortion = textBox.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/");

    presentation.save("Hyperlink.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Jaka jest różnica między polem tekstowym a symbolem zastępczym tekstu na slajdzie wzorcowym lub układu?**

[placeholder](/slides/pl/java/manage-placeholder/) może dziedziczyć pozycję i formatowanie z [master slide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/masterslide/) lub [layout slide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/layoutslide/). Zwykłe pole tekstowe jest niezależnym kształtem na slajdzie, na którym zostało utworzone, i nie przejmuje zachowania symbolu zastępczego po zmianie układu.

**Jak mogę zamienić tekst bez zmieniania tekstu w wykresach, tabelach lub SmartArt?**

Ogranicz iterację do kształtów implementujących [IAutoShape](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iautoshape/), jak pokazano w przykładzie Aktualizacja tekstu. Wykresy, tabele i SmartArt przechowują tekst w własnych modelach obiektowych, więc nie są modyfikowane przez tę pętlę.