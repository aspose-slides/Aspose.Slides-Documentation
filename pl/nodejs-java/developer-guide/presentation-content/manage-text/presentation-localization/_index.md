---
title: Automatyzacja lokalizacji prezentacji w JavaScript
linktitle: Lokalizacja prezentacji
type: docs
weight: 100
url: /pl/nodejs-java/presentation-localization/
keywords:
- zmiana języka
- sprawdzanie pisowni
- wyłączenie sprawdzania pisowni
- język korekty
- identyfikator języka
- tekst wielojęzyczny
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Ustaw języki korekty dla tekstu prezentacji PowerPoint i OpenDocument w JavaScript przy użyciu Aspose.Slides, w tym wartości domyślne i akapity wielojęzyczne."
---
## **Przegląd**

Aspose.Slides for Node.js via Java umożliwia konfigurowanie metadanych korekty dla pojedynczych fragmentów tekstu. Użyj [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) aby określić język korekty, [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-) aby włączyć lub wyłączyć sprawdzanie pisowni oraz [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-) aby kontrolować szerszy stan „bez korekty”. Ponieważ te ustawienia są stosowane na poziomie fragmentu, jeden akapit może zawierać wiele języków i różne reguły korekty.

Ten artykuł wyjaśnia, jak przypisać język do konkretnego tekstu, ustawić domyślny język dla nowego tekstu za pomocą [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), tworzyć wielojęzyczne akapity, wybierać między `SpellCheck` a `ProofDisabled` oraz zachować zamierzone ustawienia podczas używania [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--). Właściwości te przechowują metadane dla aplikacji prezentacji; nie tłumaczą tekstu, nie wykonują sprawdzania pisowni opartego na słownikach ani nie zwracają źle napisanych słów.

## **Ustaw język korekty dla tekstu**

Utwórz lub wczytaj [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/), uzyskaj dostęp do wymaganego fragmentu tekstu przez [Portion.getPortionFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portion/#getPortionFormat--), i przypisz jego identyfikator języka. Poniższy przykład tworzy kształt, ustawia brytyjski angielski jako język korekty i zapisuje wynik za pomocą [Presentation.save](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Set the proofing language for this text.");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLanguageId("en-GB");

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ustaw domyślny język dla nowego tekstu**

Użyj [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) aby określić język korekty, który Aspose.Slides przypisuje nowo tworzonemu tekstowi. To ustawienie jest przydatne, gdy większość lub cały nowy tekst w prezentacji używa tego samego języka. Nie zmienia ono metadanych językowych tekstu, który już ma explicite określony język.

Poniższy przykład tworzy prezentację, której nowy tekst używa reguł korekty niemieckiej:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("de-DE");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Willkommen zur Präsentation");

    presentation.save("default_text_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Użyj wielu języków w jednym akapicie**

[Paragraph](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph/) zawiera kolekcję fragmentów tekstu. Utwórz oddzielny [Portion](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portion/) dla każdego języka i ustaw jego `LanguageId` niezależnie.

Ten przykład tworzy jeden akapit z fragmentami w języku angielskim i francuskim:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 80);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const englishPortion = new aspose.slides.Portion("Welcome");
    englishPortion.getPortionFormat().setLanguageId("en-US");
    paragraph.getPortions().add(englishPortion);

    const frenchPortion = new aspose.slides.Portion(" — Bienvenue");
    frenchPortion.getPortionFormat().setLanguageId("fr-FR");
    paragraph.getPortions().add(frenchPortion);

    presentation.save("multilingual_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Włącz lub wyłącz sprawdzanie pisowni dla poszczególnych fragmentów**

[PortionFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portionformat/) dziedziczy wspólne właściwości tekstu definiowane przez [BasePortionFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseportionformat/). Uzyskaj dostęp do formatu fragmentu przez [Portion.getPortionFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portion/#getPortionFormat--) i użyj [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-) aby kontrolować, czy aplikacja prezentacji może sprawdzać pisownię w tym fragmencie. Wartość domyślna to `false`: `true` włącza sprawdzanie, natomiast `false` je wyłącza.

Ustawienie dotyczy pojedynczych fragmentów tekstu. Różne fragmenty w tym samym akapicie mogą więc mieć różne wartości. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) i `setSpellCheck` pełnią komplementarne role: `setLanguageId` identyfikuje język korekty, a `setSpellCheck` określa, czy sprawdzanie pisowni jest dozwolone dla fragmentu.

[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-) także kontroluje korektę, ale reprezentuje szerszy stan „nie korygować” jako [NullableBool](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/nullablebool/). Używaj `setSpellCheck`, gdy potrzebujesz bezpośredniego przełącznika Boolean konkretnie dla sprawdzania pisowni. Używaj `setProofDisabled`, gdy chcesz zachować lub explicite kontrolować metadane „brak korekty” prezentacji, włączając jej stan `NotDefined`. Jeśli ustawisz obie właściwości, zachowaj ich spójność; nie łącz `setSpellCheck(true)` z `setProofDisabled(NullableBool.True)`.

Właściwości te konfigurują metadane korekty używane przez PowerPoint i inne aplikacje prezentacji. Aspose.Slides nie wykorzystuje ich do uruchamiania sprawdzania pisowni opartego na słownikach ani do zwracania listy błędnie napisanych słów.

Poniższy kompletny przykład tworzy prezentację wejściową, wczytuje ją, przypisuje różne ustawienia sprawdzania pisowni i języki korekty dwóm fragmentom w tym samym akapicie, zapisuje wynik, otwiera go ponownie i weryfikuje zapisane wartości:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const inputFile = "spell_check_input.pptx";
const outputFile = "spell_check_settings.pptx";

const sourcePresentation = new aspose.slides.Presentation();
try {
    const sourceSlide = sourcePresentation.getSlides().get_Item(0);
    const sourceShape = sourceSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 80);
    const sourceParagraph = sourceShape.getTextFrame().getParagraphs().get_Item(0);
    sourceParagraph.getPortions().clear();

    const sourceEnglishPortion = new aspose.slides.Portion("Check this text. ");
    sourceEnglishPortion.getPortionFormat().setLanguageId("en-US");
    sourceParagraph.getPortions().add(sourceEnglishPortion);

    const sourceFrenchPortion = new aspose.slides.Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.getPortionFormat().setLanguageId("fr-FR");
    sourceParagraph.getPortions().add(sourceFrenchPortion);

    sourcePresentation.save(inputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
}

const presentation = new aspose.slides.Presentation(inputFile);
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    const checkedPortion = portions.get_Item(0);
    checkedPortion.getPortionFormat().setLanguageId("en-US");
    checkedPortion.getPortionFormat().setSpellCheck(true);

    const suppressedPortion = portions.get_Item(1);
    suppressedPortion.getPortionFormat().setLanguageId("fr-FR");
    suppressedPortion.getPortionFormat().setSpellCheck(false);

    presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation(outputFile);
try {
    const reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const storedPortions = reopenedShape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    const firstPortionStored = storedPortions.getCount() === 2 && 
        storedPortions.get_Item(0).getPortionFormat().getLanguageId() === "en-US" && 
        storedPortions.get_Item(0).getPortionFormat().getSpellCheck();

    const secondPortionStored = storedPortions.getCount() === 2 && 
        storedPortions.get_Item(1).getPortionFormat().getLanguageId() === "fr-FR" && 
        !storedPortions.get_Item(1).getPortionFormat().getSpellCheck();

    if (firstPortionStored && secondPortionStored) {
        console.log("The proofing settings were stored correctly.");
    } else {
        console.log("The proofing settings could not be verified.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--) łączy sąsiadujące fragmenty, które mają takie samo formatowanie. Różnica w samym `SpellCheck` nie wystarczy, aby utrzymać fragmenty oddzielnie; po połączeniu wynikowy fragment zachowuje wartość `SpellCheck` pierwszego fragmentu. Jeśli fragmenty potrzebują różnych ustawień sprawdzania pisowni, wywołaj `joinPortionsWithSameFormatting` przed przypisaniem tych ustawień lub sprawdź granice wynikowego fragmentu i ponownie zastosuj ustawienia później. Fragmenty z różnymi wartościami `LanguageId` pozostają odrębne, ponieważ ich formatowanie języka korekty się różni.

## **FAQ**

**Czy identyfikator języka tłumaczy tekst?**

Nie. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) przechowuje metadane korekty dla pisowni i gramatyki; nie modyfikuje treści tekstu. Przetłumacz tekst osobno, a następnie ustaw odpowiedni identyfikator języka dla każdego przetłumaczonego fragmentu.

**Czy język korekty kontroluje czcionki, dzielenie wyrazów czy zawijanie linii?**

Nie. Identyfikator języka służy wyłącznie korekcie. Renderowanie i układ tekstu zależą głównie od dostępnych [czcionek](/slides/pl/nodejs-java/powerpoint-fonts/), systemu pisma oraz ustawień ramki tekstowej. Aby zapewnić prawidłowe renderowanie, udostępnij wymagane czcionki, skonfiguruj [zastępowanie czcionek](/slides/pl/nodejs-java/font-substitution/) lub [osadź czcionki](/slides/pl/nodejs-java/embedded-font/) w prezentacji.

**Czy jeden akapit może używać kilku języków korekty?**

Tak. Przypisz każdy język do oddzielnego fragmentu, tak jak pokazano w przykładzie wielojęzycznego akapitu.

**Czy powinienem używać `setDefaultTextLanguage` czy `setLanguageId`?**

Użyj [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), gdy chcesz mieć domyślny język dla nowo tworzonego tekstu. Użyj [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-), gdy konkretny fragment wymaga explicite określonego języka korekty lub gdy akapit zawiera wiele języków.