---
title: Automatyzacja lokalizacji prezentacji na Androidzie
linktitle: Lokalizacja prezentacji
type: docs
weight: 100
url: /pl/androidjava/presentation-localization/
keywords:
- zmiana języka
- sprawdzanie pisowni
- wyłączenie sprawdzania pisowni
- język korekty
- identyfikator języka
- tekst wielojęzyczny
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Ustaw języki korekty dla tekstu prezentacji PowerPoint i OpenDocument na Androidzie przy użyciu Aspose.Slides for Android via Java, w tym domyślne i wielojęzyczne akapity."
---
## **Przegląd**

Aspose.Slides for Android via Java umożliwia konfigurowanie metadanych korekty dla poszczególnych fragmentów tekstu. Użyj [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) aby określić język korekty, [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) aby zezwolić lub zablokować sprawdzanie pisowni oraz [IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) aby kontrolować szerszy stan „nie korygować”. Ponieważ te ustawienia są stosowane na poziomie fragmentu, jeden akapit może zawierać wiele języków i różne zasady korekty.

Ten artykuł wyjaśnia, jak przypisać język do konkretnego tekstu, ustawić domyślny język dla nowego tekstu za pomocą [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), tworzyć wielojęzyczne akapity, wybierać pomiędzy `SpellCheck` a `ProofDisabled` oraz zachować zamierzone ustawienia przy użyciu [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--). Te właściwości przechowują metadane dla aplikacji prezentacji; nie tłumaczą tekstu, nie wykonują sprawdzania pisowni opartego na słowniku ani nie zwracają błędnie napisanych słów.

## **Ustaw język korekty dla tekstu**

Utwórz lub załaduj [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/), uzyskaj dostęp do wymaganego fragmentu tekstu przez [IPortion.getPortionFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iportion/#getPortionFormat--), i przypisz jego identyfikator języka. Poniższy przykład tworzy kształt, ustawia brytyjski angielski jako język korekty i zapisuje wynik przy użyciu [Presentation.save](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-):

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IPortion;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Set the proofing language for this text.");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLanguageId("en-GB");

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ustaw domyślny język dla nowego tekstu**

Użyj [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) aby określić język korekty, który Aspose.Slides przypisuje do nowo tworzonego tekstu. To ustawienie jest przydatne, gdy większość lub cały nowy tekst w prezentacji używa tego samego języka. Nie zmienia ono metadanych językowych tekstu, który już ma explicite określony język.

Poniższy przykład tworzy prezentację, w której nowy tekst używa zasad korekty dla języka niemieckiego:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.ISlide;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("de-DE");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Willkommen zur Präsentation");

    presentation.save("default_text_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Użyj wielu języków w jednym akapicie**

[IParagraph](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iparagraph/) zawiera kolekcję fragmentów tekstu. Utwórz osobny [Portion](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/portion/) dla każdego języka i ustaw jego `LanguageId` niezależnie.

Ten przykład tworzy jeden akapit z fragmentami po angielsku i francusku:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IParagraph;
import com.aspose.slides.ISlide;
import com.aspose.slides.Portion;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion englishPortion = new Portion("Welcome");
    englishPortion.getPortionFormat().setLanguageId("en-US");
    paragraph.getPortions().add(englishPortion);

    Portion frenchPortion = new Portion(" — Bienvenue");
    frenchPortion.getPortionFormat().setLanguageId("fr-FR");
    paragraph.getPortions().add(frenchPortion);

    presentation.save("multilingual_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Włącz lub wyłącz sprawdzanie pisowni dla poszczególnych fragmentów**

[IPortionFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iportionformat/) dziedziczy wspólne właściwości tekstu zdefiniowane przez [IBasePortionFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibaseportionformat/). Uzyskaj format fragmentu przez [IPortion.getPortionFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iportion/#getPortionFormat--) i użyj [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) aby kontrolować, czy aplikacja prezentacji może sprawdzać pisownię dla tego fragmentu. Domyślna wartość to `false`: `true` zezwala na sprawdzanie, podczas gdy `false` je blokuje.

Ustawienie dotyczy pojedynczych fragmentów tekstu. Różne fragmenty w tym samym akapicie mogą więc używać różnych wartości. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) i `setSpellCheck` służą uzupełniająco: `setLanguageId` identyfikuje język korekty, natomiast `setSpellCheck` określa, czy sprawdzanie pisowni jest dozwolone dla fragmentu.

[IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) również kontroluje korektę, ale reprezentuje szerszy stan „nie korygować” jako [NullableBool](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/nullablebool/). Użyj `setSpellCheck`, gdy potrzebujesz bezpośredniego przełącznika Boolean specjalnie dla sprawdzania pisowni. Użyj `setProofDisabled`, gdy chcesz zachować lub wyraźnie kontrolować metadane „nie korygować” prezentacji, w tym jej stan `NotDefined`. Jeśli ustawisz obie właściwości, zachowaj ich spójność; nie łącz `setSpellCheck(true)` z `setProofDisabled(NullableBool.True)`.

Te właściwości konfigurują metadane korekty używane przez PowerPoint i inne aplikacje prezentacji. Aspose.Slides nie wykorzystuje ich do uruchamiania słownikowego sprawdzania pisowni ani do zwracania listy błędnie napisanych słów.

Poniższy kompletny przykład tworzy prezentację wejściową, ładuje ją, przypisuje różne ustawienia sprawdzania pisowni i języki korekty do dwóch fragmentów w tym samym akapicie, zapisuje wynik, otwiera go ponownie i weryfikuje zapisane wartości:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IParagraph;
import com.aspose.slides.IPortion;
import com.aspose.slides.IPortionCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Portion;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

String inputFile = "spell_check_input.pptx";
String outputFile = "spell_check_settings.pptx";

Presentation sourcePresentation = new Presentation();
try {
    ISlide sourceSlide = sourcePresentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    IParagraph sourceParagraph = sourceShape.getTextFrame().getParagraphs().get_Item(0);
    sourceParagraph.getPortions().clear();

    Portion sourceEnglishPortion = new Portion("Check this text. ");
    sourceEnglishPortion.getPortionFormat().setLanguageId("en-US");
    sourceParagraph.getPortions().add(sourceEnglishPortion);

    Portion sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.getPortionFormat().setLanguageId("fr-FR");
    sourceParagraph.getPortions().add(sourceFrenchPortion);

    sourcePresentation.save(inputFile, SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
}

Presentation presentation = new Presentation(inputFile);
try {
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortionCollection portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    IPortion checkedPortion = portions.get_Item(0);
    checkedPortion.getPortionFormat().setLanguageId("en-US");
    checkedPortion.getPortionFormat().setSpellCheck(true);

    IPortion suppressedPortion = portions.get_Item(1);
    suppressedPortion.getPortionFormat().setLanguageId("fr-FR");
    suppressedPortion.getPortionFormat().setSpellCheck(false);

    presentation.save(outputFile, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation(outputFile);
try {
    IAutoShape reopenedShape = (IAutoShape) reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortionCollection storedPortions = reopenedShape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    boolean firstPortionStored = storedPortions.getCount() == 2 &&
            "en-US".equals(storedPortions.get_Item(0).getPortionFormat().getLanguageId()) &&
            storedPortions.get_Item(0).getPortionFormat().getSpellCheck();

    boolean secondPortionStored = storedPortions.getCount() == 2 &&
            "fr-FR".equals(storedPortions.get_Item(1).getPortionFormat().getLanguageId()) &&
            !storedPortions.get_Item(1).getPortionFormat().getSpellCheck();

    if (firstPortionStored && secondPortionStored) {
        System.out.println("The proofing settings were stored correctly.");
    } else {
        System.out.println("The proofing settings could not be verified.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) łączy sąsiadujące fragmenty, które mają takie samo formatowanie. Różnica w samej wartości `SpellCheck` nie utrzymuje fragmentów osobno; po połączeniu wynikowy fragment zachowuje wartość `SpellCheck` pierwszego fragmentu. Jeśli fragmenty wymagają różnych ustawień sprawdzania pisowni, wywołaj `joinPortionsWithSameFormatting` przed przypisaniem tych ustawień lub przeanalizuj granice wynikowych fragmentów i ponownie zastosuj ustawienia. Fragmenty o różnych wartościach `LanguageId` pozostają osobne, ponieważ ich formatowanie językowe korekty się różni.

## **FAQ**

**Czy identyfikator języka tłumaczy tekst?**

Nie. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) przechowuje metadane korekty dla pisowni i gramatyki; nie zmienia treści tekstu. Przetłumacz tekst osobno, a następnie ustaw odpowiedni identyfikator języka dla każdego przetłumaczonego fragmentu.

**Czy język korekty steruje czcionkami, dzieleniem wyrazów lub zawijaniem linii?**

Nie. Identyfikator języka służy wyłącznie do korekty. Renderowanie i układ tekstu zależą głównie od dostępnych [czcionek](/slides/pl/androidjava/powerpoint-fonts/), systemu pisma oraz ustawień ramki tekstowej. Aby zapewnić prawidłowe renderowanie, dostarcz wymagane czcionki, skonfiguruj [zastępowanie czcionek](/slides/pl/androidjava/font-substitution/) lub [osadź czcionki](/slides/pl/androidjava/embedded-font/) w prezentacji.

**Czy jeden akapit może używać kilku języków korekty?**

Tak. Przypisz każdy język do osobnego fragmentu, jak pokazano w przykładzie wielojęzycznego akapitu.

**Czy powinienem używać `setDefaultTextLanguage` czy `setLanguageId`?**

Użyj [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), gdy chcesz ustawić domyślny język dla nowo tworzonego tekstu. Użyj [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), gdy konkretny fragment wymaga explicite określonego języka korekty lub gdy akapit zawiera wiele języków.