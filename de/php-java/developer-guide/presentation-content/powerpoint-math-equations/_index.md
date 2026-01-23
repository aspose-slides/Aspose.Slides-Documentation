---
title: Mathematische Gleichungen zu PowerPoint-Präsentationen in PHP hinzufügen
linktitle: PowerPoint Mathegleichungen
type: docs
weight: 80
url: /de/php-java/powerpoint-math-equations/
keywords:
- Mathegleichung
- Mathezeichen
- Matheformel
- Mathetext
- Mathegleichung hinzufügen
- Mathezeichen hinzufügen
- Matheformel hinzufügen
- Mathetext hinzufügen
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Mathegleichungen in PowerPoint PPT und PPTX mit Aspose.Slides für PHP über Java einfügen und bearbeiten, unterstützt OMML, Formatierungsoptionen und klare Codebeispiele."
---

## **Übersicht**
In PowerPoint ist es möglich, eine mathematische Gleichung oder Formel zu schreiben und in der Präsentation anzuzeigen. Dazu sind verschiedene mathematische Symbole in PowerPoint dargestellt und können dem Text oder der Gleichung hinzugefügt werden. Hierzu wird der Mathe‑Gleichungs‑Konstruktor in PowerPoint verwendet, der das Erstellen komplexer Formeln wie:

- Mathematischer Bruch
- Mathematischer Radikand
- Mathematische Funktion
- Grenzen und Log‑Funktionen
- N‑stellige Operationen
- Matrix
- Große Operatoren
- Sinus‑, Kosinus‑Funktionen

ermöglicht.

Um eine mathematische Gleichung in PowerPoint hinzuzufügen, wird das *Einfügen → Gleichung*‑Menü verwendet:

![todo:image_alt_text](powerpoint-math-equations_1.png)

Damit wird ein mathematischer Text in XML erzeugt, der in PowerPoint wie folgt angezeigt wird:

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint unterstützt zahlreiche mathematische Symbole zum Erstellen von Gleichungen. Das Erstellen komplizierter Gleichungen in PowerPoint führt jedoch häufig nicht zu einem professionellen Ergebnis. Anwender, die häufig mathematische Präsentationen erstellen müssen, greifen auf Drittanbieter‑Lösungen zurück, um ansprechende Formeln zu erzeugen.

Mit [**Aspose.Slide API**](https://products.aspose.com/slides/php-java/) können Sie programmgesteuert in C# mit mathematischen Gleichungen in PowerPoint‑Präsentationen arbeiten. Erstellen Sie neue mathematische Ausdrücke oder bearbeiten Sie bereits vorhandene. Der Export mathematischer Strukturen in Bilder wird ebenfalls zum Teil unterstützt.


## **Wie man eine mathematische Gleichung erstellt**
Mathematische Elemente werden verwendet, um beliebige mathematische Konstruktionen mit beliebiger Verschachtelung zu bauen. Eine lineare Sammlung mathematischer Elemente bildet einen mathematischen Block, der durch die [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)‑Klasse repräsentiert wird. Die [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)‑Klasse ist im Wesentlichen ein abgegrenzter mathematischer Ausdruck, eine Formel oder Gleichung. [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion) ist ein mathematischer Teil, der mathematischen Text enthält (nicht zu verwechseln mit [**Portion**](https://reference.aspose.com/slides/php-java/aspose.slides/Portion)). [**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph) ermöglicht die Manipulation einer Menge von MathBlocks. Die genannten Klassen sind entscheidend für die Arbeit mit PowerPoint‑Mathe‑Gleichungen über die Aspose.Slides‑API.

Sehen wir uns an, wie wir die folgende mathematische Gleichung über die Aspose.Slides‑API erstellen:

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


Nach dem Erstellen enthält die Form standardmäßig einen Absatz mit einer mathematischen Portion. Die [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion)‑Klasse ist eine Portion, die mathematischen Text beinhaltet. Um auf den mathematischen Inhalt innerhalb der [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion) zuzugreifen, verweisen Sie auf die [**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph)‑Variable:
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


## **Typen mathematischer Elemente**
Mathematische Ausdrücke entstehen aus Sequenzen mathematischer Elemente. Die Sequenz wird durch einen mathematischen Block dargestellt, und die Argumente der Elemente bilden eine baumartige Verschachtelung.

Es gibt zahlreiche Typen mathematischer Elemente, die zum Aufbau eines mathematischen Blocks verwendet werden können. Jeder dieser Typen kann in einem anderen Element aggregiert werden. Elemente dienen also als Container für weitere Elemente und bilden eine baumartige Struktur. Der einfachste Typ ist ein Element, das keine weiteren Elemente des mathematischen Textes enthält.

Jeder Mathe‑Elementtyp implementiert die `MathElement`‑Klasse, sodass ein gemeinsamer Satz von Operationen auf unterschiedliche Mathe‑Elemente angewendet werden kann.
### **MathematicalText‑Klasse**
Die [**MathematicalText**](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText)‑Klasse stellt mathematischen Text dar – das Grundelement aller mathematischen Konstruktionen. Mathematischer Text kann Operanden, Operatoren, Variablen und beliebigen linearen Text repräsentieren.

Beispiel: 𝑎=𝑏+𝑐
### **MathFraction‑Klasse**
Die [**MathFraction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFraction)‑Klasse definiert ein Bruchobjekt, bestehend aus Zähler und Nenner, getrennt durch einen Bruchstrich. Der Bruchstrich kann horizontal oder diagonal sein, je nach Eigenschaften des Bruchs. Das Bruchobjekt wird außerdem für die Stack‑Funktion verwendet, die ein Element über ein anderes legt, ohne Bruchstrich.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **MathRadical‑Klasse**
Die [**MathRadical**](https://reference.aspose.com/slides/php-java/aspose.slides/MathRadical)‑Klasse definiert die Wurzelfunktion, bestehend aus einer Basis und einem optionalen Exponenten.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **MathFunction‑Klasse**
Die [**MathFunction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction)‑Klasse definiert eine Funktion eines Arguments. Sie enthält die Eigenschaften: [getName](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction#getName--) – Funktionsname und [getBase](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction#getBase--) – Funktionsargument.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **MathNaryOperator‑Klasse**
Die [**MathNaryOperator**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperator)‑Klasse definiert ein n‑stelliges mathematisches Objekt, wie Summation oder Integral. Sie besteht aus einem Operator, einer Basis (oder einem Operand) und optionalen oberen und unteren Grenzen. Beispiele für n‑stellige Operatoren sind Summation, Vereinigung, Schnittmenge, Integral.

Einfachere Operatoren wie Addition oder Subtraktion werden nicht über diese Klasse, sondern über [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText) dargestellt.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **MathLimit‑Klasse**
Die [**MathLimit**](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit)‑Klasse erzeugt eine obere oder untere Grenze. Sie besteht aus Text auf der Grundlinie und verkleinertem Text direkt darüber bzw. darunter. Das Wort „lim“ ist nicht Bestandteil dieses Elements; Sie können Text beliebig über oder unter dem Ausdruck platzieren. So entsteht beispielsweise:

![todo:image_alt_text](powerpoint-math-equations_8.png)

Durch die Kombination von [**MathFunction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) und [**MathLimit**](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) wird das folgendermaßen umgesetzt:

```php
  $funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));
  $mathFunc = new MathFunction($funcName, new MathematicalText("𝑥"));
``` 
### **MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathLeftSubSuperscriptElement)

Die Klassen definieren einen tiefen bzw. hohen Index. Sie ermöglichen das gleichzeitige Setzen von Tief- und Hochstellung links oder rechts eines Arguments; ein einzelner Index ist nur rechts zulässig. [MathSubscriptElement] kann zudem den mathematischen Grad einer Zahl festlegen.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **MathMatrix‑Klasse**
Die [**MathMatrix**](https://reference.aspose.com/slides/php-java/aspose.slides/MathMatrix)‑Klasse definiert ein Matrixobjekt, das Kind‑Elemente in Zeilen und Spalten anordnet. Matrizen besitzen keine integrierten Begrenzungszeichen; zum Einrahmen verwendet man das [**MathDelimiter**](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/). Null‑Argumente erzeugen Lücken in Matrizen.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **MathArray‑Klasse**
Die [**MathArray**](https://reference.aspose.com/slides/php-java/aspose.slides/MathArray)‑Klasse definiert ein vertikales Array von Gleichungen oder beliebigen mathematischen Objekten.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **Formatierung mathematischer Elemente**
- **[MathBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/MathBorderBox)**: zeichnet einen rechteckigen oder anderen Rahmen um das `MathElement`.

  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- **[MathBox](https://reference.aspose.com/slides/php-java/aspose.slides/MathBox)**: definiert eine logische Box‑Umhüllung des mathematischen Elements (z. B. ein Operator‑Emulator, der Zeilenumbrüche verhindert).

- **[MathDelimiter](https://reference.aspose.com/slides/php-java/aspose.slides/MathDelimiter)**: definiert ein Begrenzungszeichen aus öffnenden und schließenden Zeichen (Klammern, geschweiften Klammern, eckigen Klammern, Strichen) mit einem oder mehreren enthaltenen `MathElement`s.

  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- **[MathAccent](https://reference.aspose.com/slides/php-java/aspose.slides/MathAccent)**: definiert ein Akzentzeichen, bestehend aus einer Basis und einem kombinierenden diakritischen Zeichen.

  Beispiel: 𝑎́.

- **[MathBar](https://reference.aspose.com/slides/php-java/aspose.slides/MathBar)**: definiert einen Balken (über‑ oder unterhalb) über einer Basis.

  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- **[MathGroupingCharacter](https://reference.aspose.com/slides/php-java/aspose.slides/MathGroupingCharacter)**: definiert ein Gruppierungssymbol über oder unter einem Ausdruck, um Beziehungen hervorzuheben.

  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_15.png)


## **Mathematische Operationen**
Jedes mathematische Element und jeder mathematische Ausdruck (via [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)) erbt von der `MathElement`‑Klasse. Damit können Sie Operationen auf der bestehenden Struktur ausführen und komplexere Ausdrücke bilden. Alle Operationen akzeptieren entweder ein `MathElement` oder einen String als Parameter. Instanzen der [**MathematicalText**](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText)‑Klasse werden implizit aus übergebenen Strings erzeugt.

### **Join‑Methode**
- `join(String)`
- `join(MathElement)`

Vereint ein mathematisches Element zu einem Block.

```php
  $element1 = new MathematicalText("x");
  $element2 = new MathematicalText("y");
  $block = $element1->join($element2);
``` 
### **Divide‑Methode**
- `divide(String)`
- `divide(MathElement)`
- `divide(String, MathFractionTypes)`
- `divide(MathElement, MathFractionTypes)`

Erzeugt einen Bruch des angegebenen Typs.

```php
  $numerator = new MathematicalText("x");
  $fraction = $numerator->divide("y", MathFractionTypes->Linear);
``` 
### **Enclose‑Methode**
- `enclose()`
- `enclose(Char, Char)`

Umfasst das Element mit angegebenen Zeichen (z. B. Klammern).

```php
  $delimiter = new MathematicalText("x")->enclose('[', ']');
  $delimiter2 = new MathematicalText("elem1")->join("elem2")->enclose();
``` 
### **Function‑Methode**
- `function(String)`
- `function(MathElement)`

Wendet eine Funktion auf das aktuelle Objekt an.

```php
  $func = new MathematicalText("sin")->function("x");
``` 
### **AsArgumentOfFunction‑Methode**
- `asArgumentOfFunction(String)`
- `asArgumentOfFunction(MathElement)`
- `asArgumentOfFunction(MathFunctionsOfOneArgument)`
- `asArgumentOfFunction(MathFunctionsOfTwoArguments, MathElement)`
- `asArgumentOfFunction(MathFunctionsOfTwoArguments, String)`

Verwendet das aktuelle Element als Argument einer Funktion.

```php
  $funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));
  $func1 = new MathematicalText("2x")->asArgumentOfFunction($funcName);
  $func2 = new MathematicalText("x")->asArgumentOfFunction("sin");
  $func3 = new MathematicalText("x")->asArgumentOfFunction(MathFunctionsOfOneArgument->Sin);
  $func4 = new MathematicalText("x")->asArgumentOfFunction(MathFunctionsOfTwoArguments->Log, "3");
``` 
### **SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft‑Methoden**
- `setSubscript(String)`
- `setSubscript(MathElement)`
- `setSuperscript(String)`
- `setSuperscript(MathElement)`
- `setSubSuperscriptOnTheRight(String, String)`
- `setSubSuperscriptOnTheRight(MathElement, MathElement)`
- `setSubSuperscriptOnTheLeft(String, String)`
- `setSubSuperscriptOnTheLeft(MathElement, MathElement)`

Setzt Tief‑ bzw. Hochstellung. Einzelne Tief‑ oder Hochstellung ist nur rechts zulässig; beide können gleichzeitig links gesetzt werden. Der Hochstellungen‑Modus kann zudem den mathematischen Grad einer Zahl festlegen.

```php
  $script = new MathematicalText("y")->setSubSuperscriptOnTheLeft("2x", "3z");
``` 
### **Radical‑Methode**
- `radical(String)`
- `radical(MathElement)`

Definiert die mathematische Wurzel des angegebenen Grades.

```php
  $radical = new MathematicalText("x")->radical("3");
``` 
### **SetUpperLimit und SetLowerLimit‑Methoden**
- `setUpperLimit(String)`
- `setUpperLimit(MathElement)`
- `setLowerLimit(String)`
- `setLowerLimit(MathElement)`

Erzeugt obere bzw. untere Grenzen.

```php
  $mathExpression = new MathematicalText("lim")->setLowerLimit("x→∞")->function("x");
``` 
### **Nary‑ und Integral‑Methoden**
- `nary(MathNaryOperatorTypes, MathElement, MathElement`
- `nary(MathNaryOperatorTypes, String, String)`
- `integral(MathIntegralTypes)`
- `integral(MathIntegralTypes, MathElement, MathElement)`
- `integral(MathIntegralTypes, String, String)`
- `integral(MathIntegralTypes, MathElement, MathElement, MathLimitLocations)`
- `integral(MathIntegralTypes, String, String, MathLimitLocations)`

Beide erzeugen einen n‑stelliges Operator‑Typ bzw. ein Integral.

```php
  $baseArg = new MathematicalText("x")->join(new MathematicalText("dx")->toBox());
  $integral = $baseArg->integral(MathIntegralTypes->Simple, "0", "1");
``` 
### **ToMathArray‑Methode**
`MathElement.toMathArray` bildet Elemente zu einem vertikalen Array um.

```php
  $arrayFunction = new MathematicalText("x")->join("y")->toMathArray();
``` 
### **Formatierungs‑Operationen: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- `accent` fügt ein Akzentzeichen hinzu.
- `overbar` / `underbar` setzt einen Balken oben bzw. unten.
- `group` gruppiert mit einem Gruppierungszeichen.
- `toBorderBox` umschließt mit einem Rahmen.
- `toBox` erzeugt eine logische Box.

```php
  $accent = new MathematicalText("x")->accent('̃');
  $bar = new MathematicalText("x")->overbar();
  $groupChr = new MathematicalText("x")->join("y")->join("z")->group('⏡', MathTopBotPositions::Bottom, MathTopBotPositions::Top);
  $borderBox = new MathematicalText("x+y+z")->toBorderBox();
  $boxedOperator = new MathematicalText(":=")->toBox();
``` 

## **FAQ**

**Wie kann ich einer PowerPoint‑Folien ein mathematisches Gleichungs‑Objekt hinzufügen?**

Erzeugen Sie ein MathShape‑Objekt, das automatisch eine MathPortion enthält. Dann rufen Sie das [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) aus der [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) ab und fügen dort [MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/)‑Objekte hinzu.

**Ist es möglich, komplex verschachtelte mathematische Ausdrücke zu erstellen?**

Ja. Aspose.Slides ermöglicht das Erzeugen komplexer Ausdrücke durch Verschachtelung von MathBlocks. Jeder Mathe‑Element‑Typ unterstützt Operationen wie Join, Divide, Enclose usw., um komplexe Strukturen zu bauen.

**Wie kann ich eine bereits vorhandene mathematische Gleichung aktualisieren oder ändern?**

Greifen Sie über das [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) auf die bestehenden MathBlocks zu und verwenden Sie Methoden wie Join, Divide, Enclose usw., um einzelne Elemente zu ändern. Nach der Bearbeitung speichern Sie die Präsentation, um die Änderungen zu übernehmen.