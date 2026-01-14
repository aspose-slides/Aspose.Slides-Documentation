---
title: Mathematische Gleichungen zu PowerPoint-Präsentationen in PHP hinzufügen
linktitle: PowerPoint Mathe Gleichungen
type: docs
weight: 80
url: /de/php-java/powerpoint-math-equations/
keywords:
- mathematische Gleichung
- mathematisches Symbol
- mathematische Formel
- mathematischer Text
- mathematische Gleichung hinzufügen
- mathematisches Symbol hinzufügen
- mathematische Formel hinzufügen
- mathematischen Text hinzufügen
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Mathematische Gleichungen in PowerPoint-PPT und PPTX mit Aspose.Slides für PHP via Java einfügen und bearbeiten, unterstützt OMML, Formatierungssteuerungen und klare Codebeispiele."
---

## **Übersicht**
In PowerPoint ist es möglich, eine mathematische Gleichung oder Formel zu schreiben und in der Präsentation anzuzeigen. Dazu werden verschiedene mathematische Symbole in PowerPoint dargestellt und können dem Text oder der Gleichung hinzugefügt werden. Hierfür wird der mathematische Gleichungskonstruktor in PowerPoint verwendet, der das Erstellen komplexer Formeln ermöglicht, wie zum Beispiel:

- Mathematischer Bruch
- Mathematischer Radikal
- Mathematische Funktion
- Grenzen und Logarithmus‑Funktionen
- N‑stellige Operationen
- Matrix
- Große Operatoren
- Sin‑, Cos‑Funktionen

Um eine mathematische Gleichung in PowerPoint hinzuzufügen, wird das Menü *Einfügen → Gleichung* verwendet:

![todo:image_alt_text](powerpoint-math-equations_1.png)

Damit wird ein mathematischer Text in XML erstellt, der in PowerPoint wie folgt angezeigt wird:

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint unterstützt zahlreiche mathematische Symbole zum Erstellen von Gleichungen. Das Erstellen komplizierter Gleichungen in PowerPoint liefert jedoch oft kein gutes, professionelles Ergebnis. Benutzer, die häufig mathematische Präsentationen erstellen müssen, greifen auf Drittanbieter‑Lösungen zurück, um ansprechende Formeln zu erzeugen.

Mit [**Aspose.Slide API**](https://products.aspose.com/slides/php-java/), können Sie mathematische Gleichungen in PowerPoint‑Präsentationen programmgesteuert in C# bearbeiten. Erstellen Sie neue mathematische Ausdrücke oder ändern Sie bereits vorhandene. Der Export mathematischer Strukturen in Bilder wird ebenfalls teilweise unterstützt.


## **Erstellung einer mathematischen Gleichung**
Mathematische Elemente werden zum Aufbau beliebiger mathematischer Konstruktionen mit beliebiger Verschachtelungstiefe verwendet. Eine lineare Sammlung mathematischer Elemente bildet einen mathematischen Block, der durch die Klasse [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock) repräsentiert wird. Die Klasse [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock) ist im Wesentlichen ein abgegrenzter mathematischer Ausdruck, eine Formel oder Gleichung. [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion) ist ein mathematischer Teil, der mathematischen Text enthält (nicht zu verwechseln mit [**Portion**](https://reference.aspose.com/slides/php-java/aspose.slides/Portion)). [**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph) ermöglicht die Manipulation einer Menge von MathBlocks. Diese Klassen sind die Schlüssel zur Arbeit mit PowerPoint‑Mathe‑Gleichungen über die Aspose.Slides‑API.

Sehen wir uns an, wie wir die folgende mathematische Gleichung mit der Aspose.Slides‑API erstellen können:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Um einen mathematischen Ausdruck auf der Folie hinzuzufügen, fügen Sie zunächst eine Form hinzu, die den mathematischen Text enthalten soll:
```php
  $pres = new Presentation();
  try {
    $mathShape = $pres->getSlides()->get_Item(0)->getShapes()->addMathShape(0, 0, 720, 150);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


Nach dem Erstellen enthält die Form bereits standardmäßig einen Absatz mit einer mathematischen Portion. Die Klasse [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion) ist ein Teil, der mathematischen Text beinhaltet. Um auf den mathematischen Inhalt innerhalb der [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion) zuzugreifen, verwenden Sie die [**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph)‑Variable:
```php
  $mathParagraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

``` 

The [**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph) class allows to read, add, edit and delete math blocks ([**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)), that consist of a combination of mathematical elements. For example, create a fraction and place it in the presentation:

```php
  $fraction = new MathematicalText("x")->divide("y");
  $mathParagraph->add(new MathBlock($fraction));
``` 

Each mathematical element is represented by some class that implements the `MathElement` class. This class provides a lot of methods for easily creating mathematical expressions. You can create a fairly complex mathematical expression with a single line of code. For example, the Pythagorean theorem would look like this:

```php
  $mathBlock = new MathematicalText("c")->setSuperscript("2")->join("=")->join(new MathematicalText("a")->setSuperscript("2"))->join("+")->join(new MathematicalText("b")->setSuperscript("2"));
``` 

Operations of the class `MathElement` are implemented in any type of element, including the [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock).

The full source code sample:

```php
  $pres = new Presentation();
  try {
    $mathShape = $pres->getSlides()->get_Item(0)->getShapes()->addMathShape(0, 0, 720, 150);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();
    $fraction = new MathematicalText("x")->divide("y");
    $mathParagraph->add(new MathBlock($fraction));
    $mathBlock = new MathematicalText("c")->setSuperscript("2")->join("=")->join(new MathematicalText("a")->setSuperscript("2"))->join("+")->join(new MathematicalText("b")->setSuperscript("2"));
    $mathParagraph->add($mathBlock);
    $pres->save("math.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Mathematische Elementtypen**
Mathematische Ausdrücke entstehen aus Sequenzen mathematischer Elemente. Die Sequenz wird durch einen mathematischen Block dargestellt, und die Argumente der Elemente bilden eine baumartige Verschachtelung.

Es gibt zahlreiche mathematische Elementtypen, die zum Aufbau eines mathematischen Blocks verwendet werden können. Jeder dieser Typen kann in einem anderen Element enthalten (aggregiert) sein. Das bedeutet, Elemente dienen als Container für andere und bilden so eine baumartige Struktur. Der einfachste Elementtyp enthält keine weiteren Elemente des mathematischen Textes.

Jeder Elementtyp erbt von der Klasse `MathElement`, wodurch ein gemeinsamer Satz mathematischer Operationen auf verschiedene Elementtypen anwendbar ist.

### **Klasse MathematicalText**
Die Klasse [**MathematicalText**](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText) repräsentiert einen mathematischen Text – das Grundelement aller mathematischen Konstruktionen. Mathematischer Text kann Operanden, Operatoren, Variablen und beliebigen linearen Text darstellen.

Beispiel: 𝑎=𝑏+𝑐

### **Klasse MathFraction**
Die Klasse [**MathFraction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFraction) definiert ein Bruch‑Objekt mit Zähler und Nenner, getrennt durch einen Bruchstrich. Der Strich kann horizontal oder diagonal sein, abhängig von den Eigenschaften des Bruchs. Das Objekt wird auch für die Stapel‑Funktion verwendet, bei der ein Element über ein anderes gesetzt wird, ohne Bruchstrich.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **Klasse MathRadical**
Die Klasse [**MathRadical**](https://reference.aspose.com/slides/php-java/aspose.slides/MathRadical) definiert die Radikal‑Funktion (Wurzel), bestehend aus einer Basis und optionalem Grad.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **Klasse MathFunction**
Die Klasse [**MathFunction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) definiert eine Funktion mit einem Argument. Sie enthält die Eigenschaften [getName](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction#getName--) – Funktionsname – und [getBase](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction#getBase--) – Funktionsargument.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **Klasse MathNaryOperator**
Die Klasse [**MathNaryOperator**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperator) definiert ein N‑stelliges mathematisches Objekt, z. B. Summation oder Integral. Sie besteht aus einem Operator, einer Basis (bzw. Operand) und optionalen oberen sowie unteren Grenzen. Beispiele für N‑stelliges sind Summation, Vereinigung, Schnittmenge, Integral.

Einfachere Operatoren wie Addition oder Subtraktion werden nicht über diese Klasse, sondern über ein einzelnes Textelement [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText) dargestellt.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **Klasse MathLimit**
Die Klasse [**MathLimit**](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) erzeugt obere oder untere Grenzen. Sie besteht aus Text auf der Grundlinie und verkleinertem Text direkt darüber bzw. darunter. Das Element enthält nicht das Wort „lim“, erlaubt jedoch das Platzieren von Text über oder unter dem Ausdruck. So entsteht der Ausdruck

![todo:image_alt_text](powerpoint-math-equations_8.png)

mit einer Kombination aus [**MathFunction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction)‑ und [**MathLimit**](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit)‑Elementen:

```php
  $funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));
  $mathFunc = new MathFunction($funcName, new MathematicalText("𝑥"));
``` 

### **Klassen MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathLeftSubSuperscriptElement)

Diese Klassen definieren einen tiefen oder hohen Index. Sie können sowohl tiefen‑ als auch hochgestellten Index gleichzeitig links oder rechts vom Argument setzen; ein einzelner tief- oder hochgestellter Index ist nur rechts zulässig. [MathSubscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSubscriptElement) kann zudem den mathematischen Grad einer Zahl setzen.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **Klasse MathMatrix**
Die Klasse [**MathMatrix**](https://reference.aspose.com/slides/php-java/aspose.slides/MathMatrix) definiert ein Matrix‑Objekt, dessen Kindelemente in Zeilen und Spalten angeordnet werden. Hinweis: Matrizen besitzen keine eingebauten Begrenzungszeichen. Möchten Sie die Matrix in Klammern setzen, verwenden Sie das Begrenzungs‑Objekt [**MathDelimiter**](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/). Null‑Argumente erzeugen Lücken in Matrizen.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **Klasse MathArray**
Die Klasse [**MathArray**](https://reference.aspose.com/slides/php-java/aspose.slides/MathArray) definiert ein vertikales Array von Gleichungen oder anderen mathematischen Objekten.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **Formatierung mathematischer Elemente**
- [**MathBorderBox**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBorderBox)‑Klasse: zeichnet einen rechteckigen oder anderen Rahmen um das `MathElement`.

  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBox)‑Klasse: definiert das logische „Boxen“ eines mathematischen Elements, z. B. als Operator‑Emulator mit oder ohne Ausrichtungspunkt, als Zeilenumbruch‑Markierung oder zur Gruppierung, um Zeilenumbrüche zu verhindern. Beispielsweise sollte der Operator „==“ in eine Box gelegt werden, um Zeilenumbrüche zu vermeiden.

- [**MathDelimiter**](https://reference.aspose.com/slides/php-java/aspose.slides/MathDelimiter)‑Klasse: definiert das Begrenzungs‑Objekt mit öffnenden und schließenden Zeichen (Klammern, geschweifte Klammern, eckige Klammern, senkrechte Striche) und einem oder mehreren mathematischen Elementen innen, getrennt durch ein angegebenes Zeichen. Beispiele: (𝑥2); [𝑥2|𝑦2].

  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**](https://reference.aspose.com/slides/php-java/aspose.slides/MathAccent)‑Klasse: definiert die Akzent‑Funktion mit Basis und kombinierendem diakritischem Zeichen.

  Beispiel: 𝑎́.

- [**MathBar**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBar)‑Klasse: definiert die Balken‑Funktion mit Basis‑Argument und Ober‑ bzw. Unterbalken.

  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**](https://reference.aspose.com/slides/php-java/aspose.slides/MathGroupingCharacter)‑Klasse: definiert ein Gruppierungszeichen über oder unter einem Ausdruck, meist zur Hervorhebung von Beziehungen zwischen Elementen.

  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_15.png)


## **Mathematische Operationen**
Jedes mathematische Element und jeder mathematische Ausdruck (via [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)) erbt von der Klasse `MathElement`. Dadurch können Operationen auf der bestehenden Struktur angewendet und komplexere Ausdrücke gebildet werden. Alle Operationen besitzen zwei Parameter‑Sätze: entweder ein `MathElement` oder ein `String`. Instanzen der [**MathematicalText**](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText)‑Klasse werden implizit aus übergebenen Zeichenketten erstellt, wenn String‑Parameter verwendet werden. Die in Aspose.Slides verfügbaren mathematischen Operationen sind unten aufgelistet.

### **Methode Join**
- `join(String)`
- `join(MathElement)`

Verknüpft ein mathematisches Element und bildet einen mathematischen Block. Beispiel:

```php
  $element1 = new MathematicalText("x");
  $element2 = new MathematicalText("y");
  $block = $element1->join($element2);
``` 

### **Methode Divide**
- `divide(String)`
- `divide(MathElement)`
- `divide(String, MathFractionTypes)`
- `divide(MathElement, MathFractionTypes)`

Erzeugt einen Bruch des angegebenen Typs mit diesem Zähler und dem angegebenen Nenner. Beispiel:

```php
  $numerator = new MathematicalText("x");
  $fraction = $numerator->divide("y", MathFractionTypes->Linear);
``` 

### **Methode Enclose**
- `enclose()`
- `enclose(Char, Char)`

Umfasst das Element mit angegebenen Zeichen, z. B. Klammern oder anderen Rahmenzeichen.

```php

``` 

Beispiel:

```php
  $delimiter = new MathematicalText("x")->enclose('[', ']');
  $delimiter2 = new MathematicalText("elem1")->join("elem2")->enclose();
``` 

### **Methode Function**
- `function(String)`
- `function(MathElement)`

Wendet eine Funktion auf ein Argument an, wobei das aktuelle Objekt als Funktionsname verwendet wird.

```php

``` 

Beispiel:

```php
  $func = new MathematicalText("sin")->function("x");
``` 

### **Methode AsArgumentOfFunction**
- `asArgumentOfFunction(String)`
- `asArgumentOfFunction(MathElement)`
- `asArgumentOfFunction(MathFunctionsOfOneArgument)`
- `asArgumentOfFunction(MathFunctionsOfTwoArguments, MathElement)`
- `asArgumentOfFunction(MathFunctionsOfTwoArguments, String)`

Verwendet das aktuelle Objekt als Argument einer angegebenen Funktion. Sie können:

- einen String als Funktionsnamen angeben, z. B. “cos”.
- einen vordefinierten Wert aus den Aufzählungen [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfOneArgument) oder [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfTwoArguments) wählen, z. B. [**MathFunctionsOfOneArgument**](MathFunctionsOfOneArgument).[**ArcSin**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfOneArgument#ArcSin).
- das `MathElement`‑Objekt übergeben.

Beispiel:

```php
  $funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));
  $func1 = new MathematicalText("2x")->asArgumentOfFunction($funcName);
  $func2 = new MathematicalText("x")->asArgumentOfFunction("sin");
  $func3 = new MathematicalText("x")->asArgumentOfFunction(MathFunctionsOfOneArgument->Sin);
  $func4 = new MathematicalText("x")->asArgumentOfFunction(MathFunctionsOfTwoArguments->Log, "3");
``` 

### **Methoden SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft**
- `setSubscript(String)`
- `setSubscript(MathElement)`
- `setSuperscript(String)`
- `setSuperscript(MathElement)`
- `setSubSuperscriptOnTheRight(String, String)`
- `setSubSuperscriptOnTheRight(MathElement, MathElement)`
- `setSubSuperscriptOnTheLeft(String, String)`
- `setSubSuperscriptOnTheLeft(MathElement, MathElement)`

Setzt tief- bzw. hochgestellte Indizes. Sie können gleichzeitig tief- und hochgestellte Indizes links oder rechts vom Argument setzen; ein einzelner tief- oder hochgestellter Index ist nur rechts zulässig. Der **Superscript** kann zudem den mathematischen Grad einer Zahl festlegen.

Beispiel:

```php
  $script = new MathematicalText("y")->setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Methode Radical**
- `radical(String)`
- `radical(MathElement)`

Definiert die mathematische Wurzel des angegebenen Grades aus dem übergebenen Argument.

Beispiel:

```php
  $radical = new MathematicalText("x")->radical("3");
``` 

### **Methoden SetUpperLimit und SetLowerLimit**
- `setUpperLimit(String)`
- `setUpperLimit(MathElement)`
- `setLowerLimit(String)`
- `setLowerLimit(MathElement)`

Setzt obere oder untere Grenze. Hier geben die oberen bzw. unteren Grenzen lediglich die Position des Arguments relativ zur Basis an.

Betrachten wir den Ausdruck:

![todo:image_alt_text](powerpoint-math-equations_8.png)

Solche Ausdrücke können durch eine Kombination der Klassen [MathFunction](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) und [MathLimit](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) sowie Operationen des `MathElement` erstellt werden:

```php
  $mathExpression = new MathematicalText("lim")->setLowerLimit("x→∞")->function("x");
``` 

### **Methoden Nary und Integral**
- `nary(MathNaryOperatorTypes, MathElement, MathElement`
- `nary(MathNaryOperatorTypes, String, String)`
- `integral(MathIntegralTypes)`
- `integral(MathIntegralTypes, MathElement, MathElement)`
- `integral(MathIntegralTypes, String, String)`
- `integral(MathIntegralTypes, MathElement, MathElement, MathLimitLocations)`
- `integral(MathIntegralTypes, String, String, MathLimitLocations)`

Beide Methoden erzeugen und geben den N‑stellig‑Operator des Typs [**MathNaryOperator**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperator) zurück. Die [nary]‑Methode nutzt die Aufzählung [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperatorTypes) für Operatoren wie Summation, Vereinigung usw., jedoch ohne Integrale. Die [integral]‑Methode stellt die spezialisierte Integral‑Operation mit der Aufzählung [**MathIntegralTypes**](https://reference.aspose.com/slides/php-java/aspose.slides/MathIntegralTypes) zur Verfügung.

Beispiel:

```php
  $baseArg = new MathematicalText("x")->join(new MathematicalText("dx")->toBox());
  $integral = $baseArg->integral(MathIntegralTypes->Simple, "0", "1");
``` 

### **Methode ToMathArray**
`MathElement.toMathArray` ordnet Elemente in einem vertikalen Array. Wird diese Operation bei einer [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)‑Instanz aufgerufen, werden alle Kindelemente in das zurückgegebene Array eingefügt.

Beispiel:

```php
  $arrayFunction = new MathematicalText("x")->join("y")->toMathArray();
``` 

### **Formatierungsoperationen: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- **`accent`**‑Methode setzt ein Akzentzeichen (ein Zeichen oberhalb des Elements).
- **`overbar`**‑ und **`underbar`**‑Methoden setzen einen Balken oben bzw. unten.
- **`group`**‑Methode gruppiert mit einem Gruppierungszeichen wie einer unteren geschweiften Klammer oder einem anderen Zeichen.
- **`toBorderBox`**‑Methode legt ein Begrenzungs‑Box‑Element an.
- **`toBox`**‑Methode legt ein nicht‑visuelles Box‑Element (logische Gruppierung) an.

Beispiele:

```php
  $accent = new MathematicalText("x")->accent('̃');
  $bar = new MathematicalText("x")->overbar();
  $groupChr = new MathematicalText("x")->join("y")->join("z")->group('⏡', MathTopBotPositions::Bottom, MathTopBotPositions::Top);
  $borderBox = new MathematicalText("x+y+z")->toBorderBox();
  $boxedOperator = new MathematicalText(":=")->toBox();
``` 

## **FAQ**

**Wie kann ich einer PowerPoint‑Folie eine mathematische Gleichung hinzufügen?**

Dazu erstellen Sie ein mathematisches Form‑Objekt, das automatisch eine mathematische Portion enthält. Anschließend rufen Sie das [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) aus der [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) ab und fügen [MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/)‑Objekte hinzu.

**Ist es möglich, komplex verschachtelte mathematische Ausdrücke zu erzeugen?**

Ja, Aspose.Slides ermöglicht das Erzeugen komplexer Ausdrücke durch Verschachtelung von MathBlocks. Jedes mathematische Element unterstützt Operationen (Join, Divide, Enclose usw.), um Elemente zu komplexeren Strukturen zu kombinieren.

**Wie kann ich eine vorhandene mathematische Gleichung aktualisieren oder ändern?**

Rufen Sie die bestehenden MathBlocks über das [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) ab. Mit Methoden wie Join, Divide, Enclose und anderen können Sie einzelne Elemente der Gleichung ändern. Nach der Bearbeitung speichern Sie die Präsentation, um die Änderungen zu übernehmen.