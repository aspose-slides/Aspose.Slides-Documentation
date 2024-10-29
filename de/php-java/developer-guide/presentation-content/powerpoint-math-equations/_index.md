---
title: PowerPoint mathematik Gleichungen
type: docs
weight: 80
url: /de/php-java/powerpoint-math-equations/
keywords: " PowerPoint Mathematik Gleichungen, PowerPoint Mathematik Symbole, PowerPoint Formel, PowerPoint Mathematik Text"
description: "PowerPoint Mathematik Gleichungen, PowerPoint Mathematik Symbole, PowerPoint Formel, PowerPoint Mathematik Text"
---

## **Übersicht**
In PowerPoint ist es möglich, eine mathematische Gleichung oder Formel zu schreiben und sie in der Präsentation anzuzeigen. Dazu sind verschiedene mathematische Symbole in PowerPoint vorhanden, die zum Text oder zur Gleichung hinzugefügt werden können. Dafür wird der Konstruktor für mathematische Gleichungen in PowerPoint verwendet, der hilft, komplexe Formeln zu erstellen wie:

- Mathematische Brüche
- Mathematische Wurzeln
- Mathematische Funktionen
- Grenzwerte und Logarithmusfunktionen
- N-äre Operationen
- Matrizen
- Große Operatoren
- Sinus-, Kosinusfunktionen

Um eine mathematische Gleichung in PowerPoint hinzuzufügen, wird das Menü *Einfügen -> Gleichung* verwendet:

![todo:image_alt_text](powerpoint-math-equations_1.png)

Dies erstellt einen mathematischen Text im XML-Format, der in PowerPoint wie folgt angezeigt werden kann:

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint unterstützt zahlreiche mathematische Symbole zur Erstellung mathematischer Gleichungen. Allerdings führt die Erstellung komplizierter mathematischer Gleichungen in PowerPoint oft nicht zu einem guten und professionell aussehenden Ergebnis. Benutzer, die häufig mathematische Präsentationen erstellen müssen, greifen auf die Verwendung von Drittanbieterlösungen zurück, um ansprechend aussehende mathematische Formeln zu erstellen.

Mit der [**Aspose.Slide API**](https://products.aspose.com/slides/php-java/) können Sie programmgesteuert an mathematischen Gleichungen in PowerPoint-Präsentationen in C# arbeiten. Erstellen Sie neue mathematische Ausdrucke oder bearbeiten Sie zuvor erstellte. Der Export mathematischer Strukturen in Bilder wird ebenfalls teilweise unterstützt.


## **So erstellen Sie eine mathematische Gleichung**
Mathematische Elemente werden verwendet, um mathematische Konstruktionen mit beliebigem Verschachtelungsgrad zu erstellen. Eine lineare Sammlung mathematischer Elemente bildet einen mathematischen Block, der durch die [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)-Klasse dargestellt wird. Die [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)-Klasse ist im Wesentlichen ein separater mathematischer Ausdruck, eine Formel oder eine Gleichung. [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion) ist ein mathematischer Teil, der verwendet wird, um mathematischen Text zu halten (nicht mit [**Portion**](https://reference.aspose.com/slides/php-java/aspose.slides/Portion) zu verwechseln). [**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph) ermöglicht die Manipulation einer Gruppe von mathematischen Blöcken. Die oben genannten Klassen sind der Schlüssel, um mit mathematischen Gleichungen in PowerPoint über die Aspose.Slides API zu arbeiten.

Lassen Sie uns sehen, wie wir die folgende mathematische Gleichung über die Aspose.Slides API erstellen können:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Um einen mathematischen Ausdruck auf der Folie hinzuzufügen, fügen Sie zuerst eine Form hinzu, die den mathematischen Text enthalten wird:

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

Nach der Erstellung enthält die Form standardmäßig bereits einen Absatz mit einem mathematischen Teil. Die [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion)-Klasse ist ein Teil, der einen mathematischen Text enthält. Um auf den mathematischen Inhalt innerhalb der [**MathPortion**](https://reference.aspose.com/slides/php-java/aspose.slides/MathPortion) zuzugreifen, verweisen Sie auf die [**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph)-Variable:

```php
  $mathParagraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

``` 

Die [**MathParagraph**](https://reference.aspose.com/slides/php-java/aspose.slides/MathParagraph)-Klasse ermöglicht es, mathematische Blöcke ([**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)) zu lesen, hinzuzufügen, zu bearbeiten und zu löschen, die aus einer Kombination mathematischer Elemente bestehen. Erstellen Sie zum Beispiel einen Bruch und platzieren Sie ihn in der Präsentation:

```php
  $fraction = new MathematicalText("x")->divide("y");
  $mathParagraph->add(new MathBlock($fraction));

``` 

Jedes mathematische Element wird durch eine Klasse dargestellt, die das [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement)-Interface implementiert. Dieses Interface bietet viele Methoden zum einfachen Erstellen mathematischer Ausdrücke. Sie können einen ziemlich komplexen mathematischen Ausdruck mit nur einer Zeile Code erstellen. Zum Beispiel würde der Satz des Pythagoras so aussehen:

```php
  $mathBlock = new MathematicalText("c")->setSuperscript("2")->join("=")->join(new MathematicalText("a")->setSuperscript("2"))->join("+")->join(new MathematicalText("b")->setSuperscript("2"));

``` 

Die Operationen des [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement)-Interfaces werden in jedem Elementtyp implementiert, einschließlich des [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock).

Das vollständige Quellcodebeispiel:

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
Mathematische Ausdrücke bestehen aus Sequenzen mathematischer Elemente. Die Sequenz mathematischer Elemente wird durch einen mathematischen Block dargestellt, und die Argumente mathematischer Elemente bilden eine baumartige Verschachtelung.

Es gibt viele Typen mathematischer Elemente, die zur Konstruktion eines mathematischen Blocks verwendet werden können. Jedes dieser Elemente kann in ein anderes Element eingeschlossen (aggregiert) werden. Das heißt, Elemente sind tatsächlich Container für andere, die eine baumartige Struktur bilden. Der einfachste Typ von Elementen enthält keine anderen Elemente des mathematischen Textes.

Jeder Typ eines mathematischen Elements implementiert das [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement)-Interface, das die Verwendung der allgemeinen Menge mathematischer Operationen auf verschiedenen Typen mathematischer Elemente ermöglicht.
### **MathematicalText-Klasse**
Die [**MathematicalText**](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText)-Klasse repräsentiert einen mathematischen Text - das zugrunde liegende Element aller mathematischen Konstruktionen. Mathematischer Text kann Operanden und Operatoren, Variablen und jeden anderen linearen Text darstellen.

Beispiel: 𝑎=𝑏+𝑐
### **MathFraction-Klasse**
Die [**MathFraction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFraction)-Klasse spezifiziert das Bruchobjekt, das aus einem Zähler und einem Nenner besteht, die durch eine Bruchlinie getrennt sind. Die Bruchlinie kann horizontal oder diagonal sein, abhängig von den Bruch Eigenschaften. Das Bruchobjekt wird auch verwendet, um die Stacked-Funktion darzustellen, die ein Element über einem anderen platziert, ohne eine Bruchlinie.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **MathRadical-Klasse**
Die [**MathRadical**](https://reference.aspose.com/slides/php-java/aspose.slides/MathRadical)-Klasse spezifiziert die radikale Funktion (mathematische Wurzel), die aus einer Basis und einem optionalen Grad besteht.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **MathFunction-Klasse**
Die [**MathFunction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction)-Klasse spezifiziert eine Funktion eines Arguments. Enthält Eigenschaften: [getName](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction#getName--) - Funktionsname und [getBase](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction#getBase--) - Funktionsargument.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **MathNaryOperator-Klasse**
Die [**MathNaryOperator**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperator)-Klasse spezifiziert ein N-äres mathematisches Objekt, wie Summation und Integral. Es besteht aus einem Operator, einer Basis (oder Operand) und optionalen oberen und unteren Grenzen. Beispiele für N-äre Operatoren sind Summation, Union, Intersection, Integral.

Diese Klasse beinhaltet keine einfachen Operatoren wie Addition, Subtraktion usw. Sie werden durch ein einzelnes Textelement - [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText) dargestellt.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **MathLimit-Klasse**
Die [**MathLimit**](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit)-Klasse erstellt die obere oder untere Grenze. Sie spezifiziert das Grenzwertobjekt, das aus Text auf der Basislinie und Text in reduzierter Größe, der sofort darüber oder darunter steht, besteht. Dieses Element schließt das Wort "lim" nicht ein, erlaubt es aber, Text oben oder unten im Ausdruck zu platzieren. So wird der Ausdruck 

![todo:image_alt_text](powerpoint-math-equations_8.png)

mit einer Kombination aus [**MathFunction**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) und [**MathLimit**](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit)-Elementen auf diese Weise erstellt:

```php
  $funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));
  $mathFunc = new MathFunction($funcName, new MathematicalText("𝑥"));

``` 


### **MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement-Klassen**
- [MathSubscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathLeftSubSuperscriptElement)

Die folgenden Klassen spezifizieren einen tiefen Index oder einen oberen Index. Sie können gleichzeitig ein Subscript und Superscript auf der linken oder rechten Seite eines Arguments setzen, aber ein einfaches Subscript oder Superscript wird nur auf der rechten Seite unterstützt. Das [MathSubscriptElement](https://reference.aspose.com/slides/php-java/aspose.slides/MathSubscriptElement) kann auch verwendet werden, um den mathematischen Grad einer Zahl zu setzen.

Beispiel: 

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **MathMatrix-Klasse**
Die [**MathMatrix**](https://reference.aspose.com/slides/php-java/aspose.slides/MathMatrix)-Klasse spezifiziert das Matrixobjekt, das aus untergeordneten Elementen besteht, die in einer oder mehreren Reihen und Spalten angeordnet sind. Es ist wichtig zu beachten, dass Matrizen keine eingebauten Begrenzer haben. Um die Matrix in Klammern zu setzen, sollten Sie das Begrenzerobjekt - [**IMathDelimiter**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathDelimiter) verwenden. Null-Argumente können verwendet werden, um Lücken in Matrizen zu erstellen.

Beispiel: 

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **MathArray-Klasse**
Die [**MathArray**](https://reference.aspose.com/slides/php-java/aspose.slides/MathArray)-Klasse spezifiziert ein vertikales Array von Gleichungen oder beliebigen mathematischen Objekten.

Beispiel: 

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **Formatierung mathematischer Elemente**
- Die [**MathBorderBox**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBorderBox)-Klasse: zieht einen rechteckigen oder einen anderen Rahmen um das [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement).
  
  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- Die [**MathBox**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBox)-Klasse: spezifiziert das logische Boxen (Verpacken) des mathematischen Elements. Zum Beispiel kann ein eingekreistes Objekt als Operator-Ersatz dienen mit oder ohne Ausrichtungspunkt, als Zeilenumbruch dienen oder so gruppiert werden, dass innerhalb keine Zeilenumbrüche erlaubt sind. Zum Beispiel sollte der Operator "==" eingekreist werden, um Zeilenumbrüche zu vermeiden.
- Die [**MathDelimiter**](https://reference.aspose.com/slides/php-java/aspose.slides/MathDelimiter)-Klasse: spezifiziert das Begrenzerobjekt, das aus öffnenden und schließenden Zeichen (wie Klammern, geschweifte Klammern, eckige Klammern und senkrechte Striche) besteht und ein oder mehrere mathematische Elemente enthält, die durch ein angegebenes Zeichen getrennt sind. Beispiele: (𝑥2); [𝑥2|𝑦2].
  
  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- Die [**MathAccent**](https://reference.aspose.com/slides/php-java/aspose.slides/MathAccent)-Klasse: spezifiziert die Akzentfunktion, die aus einer Basis und einem kombinierenden diakritischen Zeichen besteht.

  Beispiel: 𝑎́.

- Die [**MathBar**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBar)-Klasse: spezifiziert die Balkenfunktion, die aus einem Basisargument und einem Über- oder Unterbalken besteht.
  
  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- Die [**MathGroupingCharacter**](https://reference.aspose.com/slides/php-java/aspose.slides/MathGroupingCharacter)-Klasse: spezifiziert ein Gruppierungszeichen über oder unter einem Ausdruck, normalerweise um die Beziehungen zwischen Elementen hervorzuheben.
  
  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_15.png)


## **Mathematische Operationen**
Jedes mathematische Element und jeder mathematische Ausdruck (über [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)) implementiert das [**IMathElement** ](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement)-Interface. Es ermöglicht Ihnen, Operationen auf der vorhandenen Struktur zu verwenden und komplexere mathematische Ausdrücke zu bilden. Alle Operationen haben zwei Parametergruppen: entweder [**IMathElement** ](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement) oder Zeichenfolgen als Argumente. Instanzen der [**MathematicalText** ](https://reference.aspose.com/slides/php-java/aspose.slides/MathematicalText)-Klasse werden implizit aus angegebenen Zeichenfolgen erstellt, wenn Zeichenfolgenargumente verwendet werden. Mathematikoperationen, die in Aspose.Slides verfügbar sind, sind unten aufgeführt.
### **Join-Methode**
- [join(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#join-com.aspose.slides.IMathElement-)

Verbindet ein mathematisches Element und bildet einen mathematischen Block. Zum Beispiel:

```php
  $element1 = new MathematicalText("x");
  $element2 = new MathematicalText("y");
  $block = $element1->join($element2);

``` 

### **Divide-Methode**
- [divide(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#divide-java.lang.String-)
- [divide(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-)
- [divide(String, MathFractionTypes)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#divide-java.lang.String-int-)
- [divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-int-)

Erstellt einen Bruch des angegebenen Typs mit diesem Zähler und dem angegebenen Nenner. Zum Beispiel:

```php
  $numerator = new MathematicalText("x");
  $fraction = $numerator->divide("y", MathFractionTypes->Linear);

``` 

### **Enclose-Methode**
- [enclose()](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#enclose-char-char-)

Umfasst das Element in angegebenen Zeichen wie Klammern oder einem anderen Zeichen als Rahmen.

```php

``` 


Zum Beispiel:

```php
  $delimiter = new MathematicalText("x")->enclose('[', ']');
  $delimiter2 = new MathematicalText("elem1")->join("elem2")->enclose();

``` 

### **Function-Methode**
- [function(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#function-java.lang.String-)
- [function(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#function-com.aspose.slides.IMathElement-)

Nimmt eine Funktion eines Arguments unter Verwendung des aktuellen Objekts als Funktionsnamen.

```php

``` 


Zum Beispiel:

```php
  $func = new MathematicalText("sin")->function("x");

``` 

### **AsArgumentOfFunction-Methode**
- [asArgumentOfFunction(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-java.lang.String-)
- [asArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-int-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-int-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#asArgumentOfFunction-int-java.lang.String-)

Nimmt die angegebene Funktion unter Verwendung der aktuellen Instanz als Argument. Sie können:

- einen String als Funktionsnamen angeben, z.B. “cos”.
- einen der vordefinierten Werte der Aufzählungen [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfOneArgument) oder [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfTwoArguments) auswählen, z.B. [**MathFunctionsOfOneArgument**](MathFunctionsOfOneArgument).[**ArcSin**](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunctionsOfOneArgument#ArcSin).
- die Instanz des [**IMathElement**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement) auswählen.

Zum Beispiel:

```php
  $funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));
  $func1 = new MathematicalText("2x")->asArgumentOfFunction($funcName);
  $func2 = new MathematicalText("x")->asArgumentOfFunction("sin");
  $func3 = new MathematicalText("x")->asArgumentOfFunction(MathFunctionsOfOneArgument->Sin);
  $func4 = new MathematicalText("x")->asArgumentOfFunction(MathFunctionsOfTwoArguments->Log, "3");

``` 

### **SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft-Methoden**
- [setSubscript(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubscript-java.lang.String-)
- [setSubscript(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubscript-com.aspose.slides.IMathElement-)
- [setSuperscript(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSuperscript-java.lang.String-)
- [setSuperscript(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSuperscript-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheRight-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheRight-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)

Setzt Subscript und Superscript. Sie können Subscript und Superscript gleichzeitig auf der linken oder rechten Seite des Arguments setzen, allerdings wird einfaches Subscript oder Superscript nur auf der rechten Seite unterstützt. Das **Superscript** kann auch verwendet werden, um den mathematischen Grad einer Zahl zu setzen.

Beispiel:

```php
  $script = new MathematicalText("y")->setSubSuperscriptOnTheLeft("2x", "3z");

``` 

### **Radical-Methode**
- [radical(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#radical-com.aspose.slides.IMathElement-)

Spezifiziert die mathematische Wurzel des gegebenen Grades vom angegebenen Argument.

Beispiel:

```php
  $radical = new MathematicalText("x")->radical("3");

``` 

### **SetUpperLimit und SetLowerLimit-Methoden**
- [setUpperLimit(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setUpperLimit-com.aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#setLowerLimit-com.aspose.slides.IMathElement-)

Nimmt die obere oder untere Grenze. Hierkennzeichnen die obere und untere einfach die Position des Arguments relativ zur Basis.

Betrachten wir einen Ausdruck: 

![todo:image_alt_text](powerpoint-math-equations_8.png)

Solche Ausdrücke können durch eine Kombination von Klassen [MathFunction](https://reference.aspose.com/slides/php-java/aspose.slides/MathFunction) und [MathLimit](https://reference.aspose.com/slides/php-java/aspose.slides/MathLimit) und Operationen des [IMathElement](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement) wie folgt erstellt werden:

```php
  $mathExpression = new MathematicalText("lim")->setLowerLimit("x→∞")->function("x");

``` 

### **Nary und Integral-Methoden**
- [nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#nary-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-)
- [integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-int-)
- [integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-int-)

Sowohl die **nary** als auch die **integral**-Methoden erstellen und geben den N-ären Operator zurück, der durch den [**IMathNaryOperator**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathNaryOperator)-Typ dargestellt wird. In der nary-Methode gibt die [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/php-java/aspose.slides/MathNaryOperatorTypes)-Aufzählung den Typ des Operators an: Summation, Union usw., nicht einschließlich Integrale. In der Integral-Methode gibt es die spezialisierte Operation Integral mit der Aufzählung der Integraltypen [**MathIntegralTypes**](https://reference.aspose.com/slides/php-java/aspose.slides/MathIntegralTypes). 

Beispiel:

```php
  $baseArg = new MathematicalText("x")->join(new MathematicalText("dx")->toBox());
  $integral = $baseArg->integral(MathIntegralTypes->Simple, "0", "1");

``` 

### **ToMathArray-Methode**
[**toMathArray**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#toMathArray--) platziert Elemente in einem vertikalen Array. Wenn diese Operation für eine [**MathBlock**](https://reference.aspose.com/slides/php-java/aspose.slides/MathBlock)-Instanz aufgerufen wird, werden alle untergeordneten Elemente im zurückgegebenen Array platziert.

Beispiel:

```php
  $arrayFunction = new MathematicalText("x")->join("y")->toMathArray();

``` 

### **Formatierungsoperationen: Akzent, Überstrich, Unterstrich, Gruppe, ZuBorderBox, ZuBox**
- Die [**accent**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#accent-char-) Methode setzt ein Akzentzeichen (ein Zeichen oben auf dem Element).
- Die [**overbar**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#overbar--) und die [**underbar**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#underbar--) Methoden setzen einen Balken oben oder unten.
- Die [**group**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#group--) Methode platziert in einer Gruppe mit einem Gruppierungszeichen wie einer unteren geschweiften Klammer oder einem anderen.
- Die [**toBorderBox**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#toBorderBox--) Methode platziert in einer Rahmeneinheit.
- Die [**toBox**](https://reference.aspose.com/slides/php-java/aspose.slides/IMathElement#toBox--) Methode platziert in einer nicht sichtbaren Box (logische Gruppierung).

Beispiele:

```php
  $accent = new MathematicalText("x")->accent('̃');
  $bar = new MathematicalText("x")->overbar();
  $groupChr = new MathematicalText("x")->join("y")->join("z")->group('⏡', MathTopBotPositions::Bottom, MathTopBotPositions::Top);
  $borderBox = new MathematicalText("x+y+z")->toBorderBox();
  $boxedOperator = new MathematicalText(":=")->toBox();

``` 