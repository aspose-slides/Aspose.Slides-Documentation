---
title: Mathematische Gleichungen zu PowerPoint-Präsentationen in PHP hinzufügen
linktitle: PowerPoint Mathematikgleichungen
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
description: "Mathematische Gleichungen in PowerPoint PPT und PPTX mit Aspose.Slides für PHP via Java einfügen und bearbeiten, unterstützt OMML, Formatierungssteuerungen und klare Code-Beispiele."
---

## **Übersicht**
In PowerPoint ist es möglich, eine mathematische Gleichung oder Formel zu schreiben und in der Präsentation anzuzeigen. Dazu werden verschiedene mathematische Symbole in PowerPoint dargestellt und können dem Text oder der Gleichung hinzugefügt werden. Dafür wird der mathematische Gleichungskonstruktor in PowerPoint verwendet, der beim Erstellen komplexer Formeln hilft, wie zum Beispiel:

- Mathematischer Bruch
- Mathematisches Radikal
- Mathematische Funktion
- Grenzen und Logarithmusfunktionen
- N-äre Operationen
- Matrix
- Große Operatoren
- Sin‑, Cos‑Funktionen

Um in PowerPoint eine mathematische Gleichung hinzuzufügen, wird das Menü *Einfügen → Gleichung* verwendet:

![todo:image_alt_text](powerpoint-math-equations_1.png)

Damit wird ein mathematischer Text in XML erstellt, der in PowerPoint wie folgt angezeigt werden kann: 

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint unterstützt zahlreiche mathematische Symbole zum Erstellen von Gleichungen. Das Erstellen komplizierter mathematischer Gleichungen in PowerPoint führt jedoch oft nicht zu einem guten und professionell aussehenden Ergebnis. Nutzer, die häufig mathematische Präsentationen erstellen müssen, greifen zu Drittanbieter‑Lösungen, um ansprechende Formeln zu erzeugen.

Mit der [**Aspose.Slide API**](https://products.aspose.com/slides/php-java/) können Sie in C# programmgesteuert mit mathematischen Gleichungen in PowerPoint‑Präsentationen arbeiten. Erstellen Sie neue mathematische Ausdrücke oder bearbeiten Sie bereits vorhandene. Der Export mathematischer Strukturen in Bilder wird ebenfalls teilweise unterstützt.


## **Wie man eine mathematische Gleichung erstellt**
Mathematische Elemente werden verwendet, um beliebige mathematische Konstruktionen mit beliebiger Verschachtelung zu bauen. Eine lineare Sammlung mathematischer Elemente bildet einen mathematischen Block, der durch die Klasse [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock) repräsentiert wird. Die Klasse [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock) ist im Wesentlichen ein abgeschlossener mathematischer Ausdruck, eine Formel oder Gleichung. [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion) ist ein mathematischer Abschnitt, der mathematischen Text hält (nicht zu verwechseln mit [**Portion**](https://reference.aspose.com/slides/php-java/aspose.slides/Portion)). [**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph) ermöglicht die Manipulation einer Menge von MathBlocks. Die genannten Klassen sind der Schlüssel zur Arbeit mit PowerPoint‑Mathe‑Gleichungen über die Aspose.Slides‑API.

Sehen wir uns an, wie wir die folgende mathematische Gleichung über die Aspose.Slides‑API erzeugen können:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Um einen mathematischen Ausdruck auf der Folie hinzuzufügen, fügen Sie zuerst eine Form hinzu, die den mathematischen Text enthalten soll:
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


Nach dem Erstellen enthält die Form standardmäßig bereits einen Absatz mit einem mathematischen Abschnitt. Die Klasse [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion) ist ein Abschnitt, der mathematischen Text beinhaltet. Um auf den mathematischen Inhalt von [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion) zuzugreifen, beziehen Sie sich auf die Variable [**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph):
```php
  $mathParagraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

``` 

The [**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph) class allows to read, add, edit and delete math blocks ([**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)), that consist of a combination of mathematical elements. For example, create a fraction and place it in the presentation:

```php
  $fraction = new MathematicalText("x")->divide("y");
  $mathParagraph->add(new MathBlock($fraction));

``` 

Each mathematical element is represented by some class that implements the [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement) interface. This interface provides a lot of methods for easily creating mathematical expressions. You can create a fairly complex mathematical expression with a single line of code. For example, the Pythagorean theorem would look like this:

```php
  $mathBlock = new MathematicalText("c")->setSuperscript("2")->join("=")->join(new MathematicalText("a")->setSuperscript("2"))->join("+")->join(new MathematicalText("b")->setSuperscript("2"));

``` 

Operations of the interface [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement) are implemented in any type of element, including the [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock).

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
Mathematische Ausdrücke setzen sich aus Sequenzen mathematischer Elemente zusammen. Die Sequenz wird durch einen mathematischen Block dargestellt, und die Argumente der Elemente bilden eine baumartige Verschachtelung.

Es gibt zahlreiche mathematische Elementtypen, die zum Aufbau eines mathematischen Blocks verwendet werden können. Jeder dieser Typen kann in einem anderen Element enthalten (aggregiert) sein. Das bedeutet, Elemente sind tatsächlich Container für andere und bilden so eine baumartige Struktur. Der einfachste Elementtyp enthält keine anderen Elemente des mathematischen Textes.

Jeder Typ eines Mathe‑Elements implementiert das Interface [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement) und ermöglicht die einheitliche Nutzung von Mathematik‑Operationen für verschiedene Elementtypen.

### **MathematicalText‑Klasse**
Die Klasse [**MathematicalText**](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText) repräsentiert einen mathematischen Text – das Grundelement aller mathematischen Konstruktionen. Mathematischer Text kann Operanden und Operatoren, Variablen und beliebigen linearen Text darstellen.

Beispiel: 𝑎=𝑏+𝑐

### **MathFraction‑Klasse**
Die Klasse [**MathFraction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFraction) spezifiziert das Bruch‑Objekt, das aus Zähler und Nenner besteht, getrennt durch einen Bruchstrich. Der Bruchstrich kann horizontal oder diagonal sein, abhängig von den Eigenschaften des Bruchs. Das Bruch‑Objekt wird auch verwendet, um die Stack‑Funktion darzustellen, bei der ein Element über einem anderen ohne Bruchstrich liegt.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **MathRadical‑Klasse**
Die Klasse [**MathRadical**](https://reference.aspose.com/slides/php-java/aspose.slides/MathRadical) spezifiziert die Radikal‑Funktion (mathematische Wurzel) mit Basis und optionalem Grad.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **MathFunction‑Klasse**
Die Klasse [**MathFunction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) spezifiziert eine Funktion eines Arguments. Enthält Eigenschaften: [getName](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction#getName--) – Funktionsname und [getBase](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction#getBase--) – Funktionsargument.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **MathNaryOperator‑Klasse**
Die Klasse [**MathNaryOperator**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperator) spezifiziert ein n‑äriges mathematisches Objekt, z. B. Summation oder Integral. Sie besteht aus einem Operator, einer Basis (oder einem Operanden) und optionalen oberen und unteren Grenzen. Beispiele für n‑ärige Operatoren sind Summation, Vereinigung, Schnittmenge, Integral.

Diese Klasse enthält keine einfachen Operatoren wie Addition oder Subtraktion. Diese werden durch ein einzelnes Textelement – [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText) – dargestellt.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **MathLimit‑Klasse**
Die Klasse [**MathLimit**](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) erzeugt eine obere oder untere Grenze. Sie besteht aus Text auf der Grundlinie und reduziertem Text unmittelbar darüber oder darunter. Dieses Element enthält nicht das Wort „lim“, ermöglicht aber das Platzieren von Text oben oder unten im Ausdruck. So wird der Ausdruck

![todo:image_alt_text](powerpoint-math-equations_8.png)

mittels einer Kombination aus [**MathFunction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) und [**MathLimit**](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) wie folgt erstellt:

```php
  $funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));
  $mathFunc = new MathFunction($funcName, new MathematicalText("𝑥"));
``` 

### **MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement‑Klassen**
- [MathSubscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathLeftSubSuperscriptElement)

Die genannten Klassen bestimmen einen tiefen bzw. hohen Index. Sie können gleichzeitig tief- und hochgestellte Indizes links oder rechts eines Arguments setzen; ein einzelner tief‑ oder hochgestellter Index wird jedoch nur rechts unterstützt. Der [MathSubscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSubscriptElement) kann zudem zum Setzen des mathematischen Grades einer Zahl verwendet werden.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **MathMatrix‑Klasse**
Die Klasse [**MathMatrix**](https://reference.aspose.com/slides/php-java/aspose.slides/MathMatrix) spezifiziert das Matrix‑Objekt, das aus Kindelementen besteht, die in einer oder mehreren Zeilen und Spalten angeordnet sind. Wichtig: Matrizen besitzen keine eingebauten Begrenzungszeichen. Um die Matrix in Klammern zu setzen, muss das Begrenzungs‑Objekt – [**IMathDelimiter**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathDelimiter) – verwendet werden. Null‑Argumente können benutzt werden, um Lücken in Matrizen zu erzeugen.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **MathArray‑Klasse**
Die Klasse [**MathArray**](https://reference.aspose.com/slides/php-java/aspose.slides/MathArray) definiert ein vertikales Array von Gleichungen oder beliebigen mathematischen Objekten.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **Formatierung mathematischer Elemente**
- [**MathBorderBox**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBorderBox): zeichnet einen rechteckigen oder anderen Rahmen um das [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement).  
  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBox): definiert die logische Box‑Umgebung eines mathematischen Elements. Zum Beispiel kann ein box‑eingeschlossenes Objekt als Operator‑Emulator mit oder ohne Ausrichtungs­punkt dienen, als Zeilen­umbruch‑Markierung oder gruppiert werden, sodass innerhalb kein Zeilenumbruch erlaubt ist. Der Operator „==“ sollte beispielsweise in eine Box gepackt werden, um Zeilenumbrüche zu verhindern.

- [**MathDelimiter**](https://reference.aspose.com/slides/php-java/aspose.slides/MathDelimiter): definiert das Begrenzungs‑Objekt, bestehend aus öffnenden und schließenden Zeichen (z. B. Klammern, geschweiften Klammern, eckigen Klammern, senkrechten Strichen) und einem oder mehreren mathematischen Elementen innen, getrennt durch ein definiertes Zeichen. Beispiele: (𝑥2); [𝑥2|𝑦2].  
  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**](https://reference.aspose.com/slides/php-java/aspose.slides/MathAccent): definiert die Akzent‑Funktion, bestehend aus einer Basis und einem kombinierenden diakritischen Zeichen.  
  Beispiel: 𝑎́.

- [**MathBar**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBar): definiert die Balken‑Funktion, bestehend aus einem Basis‑Argument und einem Ober‑ bzw. Unter‑Balken.  
  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**](https://reference.aspose.com/slides/php-java/aspose.slides/MathGroupingCharacter): definiert ein Gruppierungszeichen über oder unter einem Ausdruck, meist zur Hervorhebung von Beziehungen zwischen Elementen.  
  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_15.png)


## **Mathematische Operationen**
Jedes mathematische Element und jeder mathematische Ausdruck (über [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)) implementiert das Interface [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement). Damit können Operationen auf der bestehenden Struktur ausgeführt und komplexere Ausdrücke gebildet werden. Alle Operationen besitzen zwei Parameter‑Sätze: entweder [**IMathElement**] oder einen String als Argumente. Instanzen der Klasse [**MathematicalText**](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText) werden implizit aus den angegebenen Strings erzeugt, wenn String‑Argumente verwendet werden. Die in Aspose.Slides verfügbaren mathematischen Operationen sind unten aufgeführt.

### **Join‑Methode**
- [join(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#join-com.aspose.slides.IMathElement-)

Verknüpft ein mathematisches Element und bildet einen mathematischen Block. Beispiel:

```php
  $element1 = new MathematicalText("x");
  $element2 = new MathematicalText("y");
  $block = $element1->join($element2);
``` 

### **Divide‑Methode**
- [divide(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#divide-java.lang.String-)
- [divide(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-)
- [divide(String, MathFractionTypes)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#divide-java.lang.String-int-)
- [divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-int-)

Erstellt einen Bruch des angegebenen Typs mit diesem Zähler und dem angegebenen Nenner. Beispiel:

```php
  $numerator = new MathematicalText("x");
  $fraction = $numerator->divide("y", MathFractionTypes->Linear);
``` 

### **Enclose‑Methode**
- [enclose()](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#enclose-char-char-)

Umgibt das Element mit angegebenen Zeichen wie Klammern oder einem anderen Rahmenzeichen.

```php

``` 

Beispiel:

```php
  $delimiter = new MathematicalText("x")->enclose('[', ']');
  $delimiter2 = new MathematicalText("elem1")->join("elem2")->enclose();
``` 

### **Function‑Methode**
- [function(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#function-java.lang.String-)
- [function(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#function-com.aspose.slides.IMathElement-)

Nimmt eine Funktion eines Arguments, wobei das aktuelle Objekt als Funktionsname verwendet wird.

```php

``` 

Beispiel:

```php
  $func = new MathematicalText("sin")->function("x");
``` 

### **AsArgumentOfFunction‑Methode**
- [asArgumentOfFunction(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-java.lang.String-)
- [asArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-int-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-int-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-int-java.lang.String-)

Verwendet die angegebene Funktion, wobei die aktuelle Instanz als Argument dient. Sie können:

- einen String als Funktionsnamen angeben, z. B. „cos“.
- einen der vordefinierten Werte der Aufzählungen [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfOneArgument) oder [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfTwoArguments) auswählen, z. B. [**MathFunctionsOfOneArgument**](MathFunctionsOfOneArgument).[**ArcSin**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfOneArgument#ArcSin).
- die Instanz von [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement) verwenden.

Beispiel:

```php
  $funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));
  $func1 = new MathematicalText("2x")->asArgumentOfFunction($funcName);
  $func2 = new MathematicalText("x")->asArgumentOfFunction("sin");
  $func3 = new MathematicalText("x")->asArgumentOfFunction(MathFunctionsOfOneArgument->Sin);
  $func4 = new MathematicalText("x")->asArgumentOfFunction(MathFunctionsOfTwoArguments->Log, "3");
``` 

### **SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft‑Methoden**
- [setSubscript(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubscript-java.lang.String-)
- [setSubscript(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubscript-com.aspose.slides.IMathElement-)
- [setSuperscript(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSuperscript-java.lang.String-)
- [setSuperscript(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSuperscript-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheRight-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheRight-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)

Setzt tief- und hochgestellte Indizes. Sie können gleichzeitig tief‑ und hochgestellte Indizes links oder rechts des Arguments setzen, wobei ein einzelner tief‑ oder hochgestellter Index nur rechts unterstützt wird. Der **Superscript** kann auch zum Setzen des mathematischen Grades einer Zahl verwendet werden.

Beispiel:

```php
  $script = new MathematicalText("y")->setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Radical‑Methode**
- [radical(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#radical-com.aspose.slides.IMathElement-)

Bestimmt die mathematische Wurzel des angegebenen Grades aus dem übergebenen Argument.

Beispiel:

```php
  $radical = new MathematicalText("x")->radical("3");
``` 

### **SetUpperLimit‑ und SetLowerLimit‑Methoden**
- [setUpperLimit(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setUpperLimit-com.aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setLowerLimit-com.aspose.slides.IMathElement-)

Setzt eine obere bzw. untere Grenze. Hier geben obere und untere einfach den Ort des Arguments relativ zur Basis an.

Betrachten wir den Ausdruck:

![todo:image_alt_text](powerpoint-math-equations_8.png)

Solche Ausdrücke können über eine Kombination der Klassen [MathFunction](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) und [MathLimit](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) sowie über Operationen des [IMathElement](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement) wie folgt erstellt werden:

```php
  $mathExpression = new MathematicalText("lim")->setLowerLimit("x→∞")->function("x");
``` 

### **Nary‑ und Integral‑Methoden**
- [nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#nary-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-)
- [integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-int-)
- [integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-int-)

Beide Methoden erzeugen und geben den n‑ären Operator zurück, der vom Typ [**IMathNaryOperator**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathNaryOperator) ist. Bei nary bestimmt die Aufzählung [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperatorTypes) den Operator‑Typ (Summation, Union usw.), ohne Integrale. Die Integral‑Methode bietet den spezialisierten Integral‑Operator mit der Aufzählung [**MathIntegralTypes**](https://reference.aspose.com/slides/php-java/aspose.slides/MathIntegralTypes).

Beispiel:

```php
  $baseArg = new MathematicalText("x")->join(new MathematicalText("dx")->toBox());
  $integral = $baseArg->integral(MathIntegralTypes->Simple, "0", "1");
``` 

### **ToMathArray‑Methode**
[**toMathArray**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#toMathArray--) legt Elemente in ein vertikales Array. Wird diese Operation für eine Instanz von [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock) aufgerufen, werden alle Kindelemente im zurückgegebenen Array angeordnet.

Beispiel:

```php
  $arrayFunction = new MathematicalText("x")->join("y")->toMathArray();
``` 

### **Formatierungs‑Operationen: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- **accent**‑Methode setzt ein Akzentzeichen (ein Zeichen über dem Element).
- **overbar**‑ und **underbar**‑Methoden setzen einen Balken oben bzw. unten.
- **group**‑Methode legt ein Gruppierungszeichen (z. B. eine untere geschweifte Klammer) um ein Element.
- **toBorderBox**‑Methode legt das Element in einen Rand‑Box‑Behälter.
- **toBox**‑Methode legt das Element in eine nicht‑visuelle Box (logische Gruppierung).

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

Dazu erstellen Sie ein mathematisches Form‑Objekt, das automatisch einen mathematischen Abschnitt enthält. Anschließend rufen Sie das [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) aus dem [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) ab und fügen [MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/)-Objekte hinzu.

**Ist es möglich, komplex verschachtelte mathematische Ausdrücke zu erstellen?**

Ja, Aspose.Slides ermöglicht das Erzeugen komplexer mathematischer Ausdrücke durch Verschachtelung von MathBlocks. Jedes mathematische Element erlaubt das Anwenden von Operationen (Join, Divide, Enclose usw.), um Elemente zu komplexeren Strukturen zu kombinieren.

**Wie kann ich eine vorhandene mathematische Gleichung aktualisieren oder ändern?**

Um eine Gleichung zu aktualisieren, greifen Sie über das [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) auf die bestehenden MathBlocks zu. Dann können Sie Methoden wie Join, Divide, Enclose und weitere verwenden, um einzelne Elemente der Gleichung zu modifizieren. Nach der Bearbeitung speichern Sie die Präsentation, um die Änderungen zu übernehmen.