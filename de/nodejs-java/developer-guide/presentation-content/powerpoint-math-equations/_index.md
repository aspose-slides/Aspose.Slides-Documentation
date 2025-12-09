---
title: PowerPoint-Mathematische Gleichungen
type: docs
weight: 80
url: /de/nodejs-java/powerpoint-math-equations/
keywords: "PowerPoint-Mathematische Gleichungen, PowerPoint-Mathematische Symbole, PowerPoint-Formel, PowerPoint-Mathtext"
description: "PowerPoint-Mathematische Gleichungen, PowerPoint-Mathematische Symbole, PowerPoint-Formel, PowerPoint-Mathtext"
---

## **Übersicht**
In PowerPoint ist es möglich, eine mathematische Gleichung oder Formel zu schreiben und in der Präsentation anzuzeigen. Dazu werden verschiedene mathematische Symbole in PowerPoint dargestellt und können dem Text oder der Gleichung hinzugefügt werden. Dafür wird der mathematische Gleichungskonstruktor in PowerPoint verwendet, der das Erstellen komplexer Formeln ermöglicht, wie zum Beispiel:

- Mathematischer Bruch
- Mathematisches Radikal
- Mathematische Funktion
- Grenzen und Logarithmus‑Funktionen
- N‑stellige Operationen
- Matrix
- Große Operatoren
- Sin‑, cos‑Funktionen

Um in PowerPoint eine mathematische Gleichung hinzuzufügen, wird das *Einfügen -> Gleichung*-Menü verwendet:

![todo:image_alt_text](powerpoint-math-equations_1.png)

Damit wird ein mathematischer Text in XML erzeugt, der in PowerPoint wie folgt dargestellt wird: 

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint unterstützt zahlreiche mathematische Symbole zum Erstellen von Gleichungen. Das Erstellen komplizierter Gleichungen in PowerPoint führt jedoch häufig nicht zu einem guten und professionellen Ergebnis. Benutzer, die häufig mathematische Präsentationen erstellen müssen, greifen zu Drittanbieter‑Lösungen, um ansprechend aussehende Formeln zu erzeugen.

Mit [**Aspose.Slide API**](https://products.aspose.com/slides/nodejs-java/) können Sie programmgesteuert mit mathematischen Gleichungen in PowerPoint‑Präsentationen in C# arbeiten. Erstellen Sie neue mathematische Ausdrücke oder bearbeiten Sie bereits vorhandene. Der Export mathematischer Strukturen in Bilder wird ebenfalls teilweise unterstützt.


## **Wie man eine mathematische Gleichung erstellt**
Mathematische Elemente werden zum Aufbau beliebiger mathematischer Konstruktionen mit beliebiger Verschachtelungstiefe verwendet. Eine lineare Sammlung mathematischer Elemente bildet einen mathematischen Block, der durch die [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock)‑Klasse repräsentiert wird. [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock) ist im Wesentlichen ein abgegrenzter mathematischer Ausdruck, eine Formel oder eine Gleichung. [**MathPortion**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathPortion) ist ein mathematischer Abschnitt, der mathematischen Text hält (nicht zu verwechseln mit [**Portion**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion)). [**MathParagraph**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathParagraph) ermöglicht die Manipulation einer Menge von MathBlocks. Die genannten Klassen sind zentral für die Arbeit mit PowerPoint‑Mathe‑Gleichungen über die Aspose.Slides‑API.

Nachfolgend ein Beispiel, wie die folgende mathematische Gleichung über die Aspose.Slides‑API erstellt wird:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Um einen mathematischen Ausdruck auf einer Folie hinzuzufügen, fügen Sie zunächst eine Form hinzu, die den mathematischen Text enthalten wird:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var mathShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 720, 150);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
``` 

Nach dem Erstellen enthält die Form bereits standardmäßig einen Absatz mit einer mathematischen Portion. Die [**MathPortion**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathPortion)‑Klasse ist ein Abschnitt, der mathematischen Text enthält. Um auf den mathematischen Inhalt in [**MathPortion**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathPortion) zuzugreifen, verwenden Sie die [**MathParagraph**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathParagraph)‑Variable:

```javascript
var mathParagraph = mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
``` 

Die [**MathParagraph**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathParagraph)‑Klasse ermöglicht das Lesen, Hinzufügen, Bearbeiten und Löschen von MathBlocks ([**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock)), die aus einer Kombination mathematischer Elemente bestehen. Beispiel: Einen Bruch erstellen und in die Präsentation einfügen:

```javascript
var fraction = new aspose.slides.MathematicalText("x").divide("y");
mathParagraph.add(new aspose.slides.MathBlock(fraction));
``` 

Jedes mathematische Element wird durch eine Klasse repräsentiert, die die [**MathElement**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement)‑Klasse implementiert. Diese Klasse bietet zahlreiche Methoden zum einfachen Erzeugen mathematischer Ausdrücke. Ein relativ komplexer Ausdruck lässt sich in einer einzigen Code‑Zeile erzeugen. Beispiel: Der Satz des Pythagoras:

```javascript
var mathBlock = new aspose.slides.MathematicalText("c").setSuperscript("2").join("=").join(new aspose.slides.MathematicalText("a").setSuperscript("2")).join("+").join(new aspose.slides.MathematicalText("b").setSuperscript("2"));
``` 

Operationen der Klasse [**MathElement**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement) sind in allen Elementtypen, einschließlich [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock), implementiert.

Der vollständige Quellcode‑Beispiel:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var mathShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 720, 150);
    var mathParagraph = mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
    var fraction = new aspose.slides.MathematicalText("x").divide("y");
    mathParagraph.add(new aspose.slides.MathBlock(fraction));
    var mathBlock = new aspose.slides.MathematicalText("c").setSuperscript("2").join("=").join(new aspose.slides.MathematicalText("a").setSuperscript("2")).join("+").join(new aspose.slides.MathematicalText("b").setSuperscript("2"));
    mathParagraph.add(mathBlock);
    pres.save("math.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
``` 

## **Mathematische Elementtypen**
Mathematische Ausdrücke werden aus Sequenzen mathematischer Elemente gebildet. Die Sequenz wird durch einen mathematischen Block dargestellt, und die Argumente der Elemente bilden eine baumartige Verschachtelung.

Es gibt zahlreiche mathematische Elementtypen, die zum Aufbau eines mathematischen Blocks verwendet werden können. Jeder dieser Typen kann in einem anderen Element aggregiert werden. Das heißt, Elemente fungieren als Container für andere und bilden so eine Baumstruktur. Der einfachste Typ enthält keine weiteren Elemente des mathematischen Textes.

Jeder Typ implementiert die [**MathElement**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement)‑Klasse, sodass ein gemeinsamer Satz von mathematischen Operationen auf unterschiedliche Elementtypen angewendet werden kann.
### **MathematicalText‑Klasse**
Die [**MathematicalText**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathematicalText)‑Klasse repräsentiert einen mathematischen Text – das Grundelement aller mathematischen Konstruktionen. Der Text kann Operanden, Operatoren, Variablen und beliebigen linearen Text enthalten.

Beispiel: 𝑎=𝑏+𝑐
### **MathFraction‑Klasse**
Die [**MathFraction**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFraction)‑Klasse definiert das Bruch‑Objekt, bestehend aus Zähler und Nenner, getrennt durch einen Bruchstrich. Der Bruchstrich kann horizontal oder diagonal sein, je nach Eigenschaften. Das Objekt wird auch für die Stack‑Funktion verwendet, bei der ein Element über einem anderen ohne Bruchstrich liegt.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **MathRadical‑Klasse**
Die [**MathRadical**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathRadical)‑Klasse definiert die Radikal‑Funktion (Wurzel), bestehend aus einer Basis und optional einem Grad.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **MathFunction‑Klasse**
Die [**MathFunction**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction)‑Klasse definiert eine Funktions‑Komponente eines Arguments. Sie enthält die Eigenschaften: [getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction#getName--) – Funktionsname und [getBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction#getBase--) – Funktionsargument.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **MathNaryOperator‑Klasse**
Die [**MathNaryOperator**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathNaryOperator)‑Klasse definiert ein N‑stelliges mathematisches Objekt, wie Summation oder Integral. Sie besteht aus einem Operator, einer Basis (oder Operanden) sowie optionalen oberen und unteren Grenzen. Beispiele für N‑stielle Operatoren sind Summation, Vereinigung, Schnittmenge, Integral.

Einfachere Operatoren wie Addition oder Subtraktion werden nicht über diese Klasse, sondern durch ein einzelnes Text‑Element – [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathematicalText) – definiert.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **MathLimit‑Klasse**
Die [**MathLimit**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLimit)‑Klasse erzeugt eine obere oder untere Grenze. Sie definiert ein Limit‑Objekt, das Text auf der Grundlinie und verkleinerten Text darüber bzw. darunter enthält. Das Element enthält nicht das Wort „lim“, ermöglicht jedoch das Platzieren von Text über oder unter dem Ausdruck. So wird der Ausdruck

![todo:image_alt_text](powerpoint-math-equations_8.png)

durch die Kombination von [**MathFunction**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction)‑ und [**MathLimit**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLimit)‑Elementen wie folgt erzeugt:

```javascript
var funcName = new aspose.slides.MathLimit(new aspose.slides.MathematicalText("lim"), new aspose.slides.MathematicalText("𝑥→∞"));
var mathFunc = new aspose.slides.MathFunction(funcName, new aspose.slides.MathematicalText("𝑥"));
``` 


### **MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement‑Klassen**
- [MathSubscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLeftSubSuperscriptElement)

Die genannten Klassen definieren einen tiefen bzw. hohen Index. Sie können gleichzeitig Sub‑ und Superskript links‑ oder rechtsseitig eines Arguments setzen; ein einzelnes Sub‑ oder Superskript wird nur rechts unterstützt. Der [MathSubscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathSubscriptElement) kann zudem den mathematischen Grad einer Zahl setzen.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **MathMatrix‑Klasse**
Die [**MathMatrix**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathMatrix)‑Klasse definiert ein Matrix‑Objekt, das Kind‑Elemente in einer oder mehreren Zeilen und Spalten anordnet. Wichtig: Matrizen enthalten keine integrierten Begrenzungszeichen. Um die Matrix in Klammern zu setzen, verwenden Sie das Begrenzungs‑Objekt – [**MathDelimiter**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathDelimiter). Null‑Argumente erzeugen Lücken in Matrizen.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **MathArray‑Klasse**
Die [**MathArray**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathArray)‑Klasse definiert ein vertikales Array von Gleichungen oder anderen mathematischen Objekten.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **Formatierung mathematischer Elemente**
- [**MathBorderBox**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBorderBox)‑Klasse: zeichnet einen rechteckigen oder anderen Rahmen um das [**MathElement**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement).

  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBox)‑Klasse: definiert die logische Box‑Umhüllung eines mathematischen Elements. Beispielsweise kann ein umschlossenes Objekt als Operator‑Emulator mit oder ohne Ausrichtungspunkt dienen, als Zeilen‑Umbruch‑Marker oder gruppiert werden, um Zeilenumbrüche innerhalb zu verhindern. Der Operator „==“ sollte beispielsweise in eine Box gepackt werden, um Zeilenumbrüche zu vermeiden.

- [**MathDelimiter**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathDelimiter)‑Klasse: definiert das Begrenzungs‑Objekt, bestehend aus öffnenden und schließenden Zeichen (z. B. Klammern, geschweiften Klammern, eckigen Klammern oder senkrechten Strichen) und einem oder mehreren mathematischen Elementen, getrennt durch ein angegebenes Zeichen. Beispiele: (𝑥2); [𝑥2|𝑦2].

  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathAccent)‑Klasse: definiert die Akzent‑Funktion, bestehend aus einer Basis und einem kombinierenden diakritischen Zeichen.

  Beispiel: 𝑎́.

- [**MathBar**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBar)‑Klasse: definiert die Balken‑Funktion, bestehend aus einem Basis‑Argument und einem Über‑ oder Unterbalken.

  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathGroupingCharacter)‑Klasse: definiert ein Gruppierungs‑Symbol über oder unter einem Ausdruck, üblicherweise zur Hervorhebung von Beziehungen zwischen Elementen.

  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_15.png)


## **Mathematische Operationen**
Jedes mathematische Element und jeder mathematische Ausdruck (via [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock)) implementiert die [**MathElement**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement)‑Klasse. Sie ermöglicht Operationen auf der bestehenden Struktur und das Bilden komplexerer Ausdrücke. Alle Operationen haben zwei Parameter‑Sätze: entweder ein [**MathElement**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement) oder einen String. Instanzen der [**MathematicalText**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathematicalText)‑Klasse werden implizit aus den angegebenen Strings erzeugt, wenn String‑Parameter verwendet werden. Die in Aspose.Slides verfügbaren mathematischen Operationen werden nachfolgend aufgelistet.
### **Join‑Methode**
- [join(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#join-aspose.slides.IMathElement-)

Verbindet ein mathematisches Element und bildet einen mathematischen Block. Beispiel:

```javascript
var element1 = new aspose.slides.MathematicalText("x");
var element2 = new aspose.slides.MathematicalText("y");
var block = element1.join(element2);
``` 

### **Divide‑Methode**
- [divide(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#divide-java.lang.String-)
- [divide(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#divide-aspose.slides.IMathElement-)
- [divide(String, MathFractionTypes)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#divide-java.lang.String-int-)
- [divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#divide-aspose.slides.IMathElement-int-)

Erstellt einen Bruch des angegebenen Typs mit diesem Zähler und dem angegebenen Nenner. Beispiel:

```javascript
var numerator = new aspose.slides.MathematicalText("x");
var fraction = numerator.divide("y", aspose.slides.MathFractionTypes.Linear);
``` 

### **Enclose‑Methode**
- [enclose()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#enclose-char-char-)

Umfasst das Element mit angegebenen Zeichen, z. B. Klammern oder einem anderen Rahmen.

```java
/**
 * <p>
 * Enclose a math element in parenthesis
 * </p>
 */
public IMathDelimiter enclose();

/**
 * <p>
 * Encloses this element in specified characters such as parenthesis or another characters as framing
 * </p>
 */
public IMathDelimiter enclose(char beginningCharacter, char endingCharacter);
``` 

Beispiel:

```javascript
var delimiter = new aspose.slides.MathematicalText("x").enclose('[', ']');
var delimiter2 = new aspose.slides.MathematicalText("elem1").join("elem2").enclose();
``` 

### **Function‑Methode**
- [function(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#function-java.lang.String-)
- [function(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#function-aspose.slides.IMathElement-)

Nimmt eine Funktion eines Arguments, wobei das aktuelle Objekt als Funktionsname verwendet wird.

```java
/**
 * <p>
 * Takes a function of an argument using this instance as the function name
 * </p>
 */
public IMathFunction function(IMathElement functionArgument);

/**
 * <p>
 * Takes a function of an argument using this instance as the function name
 * </p>
 */
public IMathFunction function(String functionArgument);
``` 

Beispiel:

```javascript
var func = new aspose.slides.MathematicalText("sin").function("x");
``` 

### **AsArgumentOfFunction‑Methode**
- [asArgumentOfFunction(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#asArgumentOfFunction-java.lang.String-)
- [asArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#asArgumentOfFunction-aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#asArgumentOfFunction-int-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#asArgumentOfFunction-int-aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#asArgumentOfFunction-int-java.lang.String-)

Verwendet das aktuelle Instanz‑Objekt als Argument einer Funktion. Sie können:

- Einen String als Funktionsnamen angeben, z. B. „cos“.
- Einen vordefinierten Wert aus den Aufzählungen [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunctionsOfOneArgument) oder [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunctionsOfTwoArguments) wählen, z. B. [**MathFunctionsOfOneArgument**](MathFunctionsOfOneArgument).[**ArcSin**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunctionsOfOneArgument#ArcSin).
- Eine Instanz von [**MathElement**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement) übergeben.

Beispiel:

```javascript
var funcName = new aspose.slides.MathLimit(new aspose.slides.MathematicalText("lim"), new aspose.slides.MathematicalText("𝑛→∞"));
var func1 = new aspose.slides.MathematicalText("2x").asArgumentOfFunction(funcName);
var func2 = new aspose.slides.MathematicalText("x").asArgumentOfFunction("sin");
var func3 = new aspose.slides.MathematicalText("x").asArgumentOfFunction(aspose.slides.MathFunctionsOfOneArgument.Sin);
var func4 = new aspose.slides.MathematicalText("x").asArgumentOfFunction(aspose.slides.MathFunctionsOfTwoArguments.Log, "3");
``` 

### **SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft‑Methoden**
- [setSubscript(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSubscript-java.lang.String-)
- [setSubscript(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSubscript-aspose.slides.IMathElement-)
- [setSuperscript(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSuperscript-java.lang.String-)
- [setSuperscript(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSuperscript-aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSubSuperscriptOnTheRight-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSubSuperscriptOnTheRight-aspose.slides.IMathElement-aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSubSuperscriptOnTheLeft-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setSubSuperscriptOnTheLeft-aspose.slides.IMathElement-aspose.slides.IMathElement-)

Setzt Tief‑ bzw. Hochstellung. Sie können Tief‑ und Hochstellung gleichzeitig links‑ oder rechtsseitig eines Arguments setzen; ein einzelnes Tief‑ bzw. Hochstellung wird nur rechts unterstützt. Der **Superscript** kann zudem den mathematischen Grad einer Zahl darstellen.

Beispiel:

```javascript
var script = new aspose.slides.MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Radical‑Methode**
- [radical(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#radical-aspose.slides.IMathElement-)

Definiert die mathematische Wurzel des angegebenen Grades aus dem übergebenen Argument.

Beispiel:

```javascript
var radical = new aspose.slides.MathematicalText("x").radical("3");
``` 

### **SetUpperLimit‑ und SetLowerLimit‑Methoden**
- [setUpperLimit(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setUpperLimit-aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#setLowerLimit-aspose.slides.IMathElement-)

Setzt eine obere bzw. untere Grenze. Hier geben obere bzw. untere Grenzen lediglich die Position des Arguments relativ zur Basis an.

Betrachten wir den Ausdruck:

![todo:image_alt_text](powerpoint-math-equations_8.png)

Solche Ausdrücke können durch die Kombination der Klassen [MathFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction) und [MathLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLimit) sowie der Operationen von [MathElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement) erzeugt werden:

```javascript
var mathExpression = new aspose.slides.MathematicalText("lim").setLowerLimit("x→∞").function("x");
``` 

### **Nary‑ und Integral‑Methoden**
- [nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#nary-int-aspose.slides.IMathElement-aspose.slides.IMathElement-)
- [nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#nary-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#integral-int-)
- [integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#integral-int-aspose.slides.IMathElement-aspose.slides.IMathElement-)
- [integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#integral-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#integral-int-aspose.slides.IMathElement-aspose.slides.IMathElement-int-)
- [integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#integral-int-java.lang.String-java.lang.String-int-)

Beide Methoden erzeugen und geben einen N‑stellig‑Operator zurück, der durch den Typ [**MathNaryOperator**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathNaryOperator) repräsentiert wird. Bei nary gibt die Aufzählung [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathNaryOperatorTypes) den Operator‑Typ an (Summation, Union usw., jedoch nicht Integral). Die integral‑Methode liefert das spezialisierte Integral‑Objekt mit den Aufzählungen [**MathIntegralTypes**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathIntegralTypes).

Beispiel:

```javascript
var baseArg = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
var integral = baseArg.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
``` 

### **ToMathArray‑Methode**
[**toMathArray**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#toMathArray--) setzt Elemente in ein vertikales Array. Wird die Methode für ein [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock)‑Objekt aufgerufen, werden alle Kind‑Elemente in das zurückgegebene Array eingefügt.

Beispiel:

```javascript
var arrayFunction = new aspose.slides.MathematicalText("x").join("y").toMathArray();
``` 

### **Formatierungs‑Operationen: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- [**accent**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#accent-char-) Methode setzt ein Akzentzeichen (ein Zeichen über dem Element).
- [**overbar**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#overbar--) und [**underbar**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#underbar--) Methoden setzen einen Balken oben bzw. unten.
- [**group**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#group--) Methode gruppiert mithilfe eines Gruppierungszeichens, z. B. einer unteren geschweiften Klammer oder eines anderen Symbols.
- [**toBorderBox**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#toBorderBox--) Methode legt das Element in einen Rand‑Box.
- [**toBox**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathElement#toBox--) Methode legt das Element in eine nicht‑visuelle Box (logische Gruppierung).

Beispiele:

```javascript
var accent = new aspose.slides.MathematicalText("x").accent('̃');
var bar = new aspose.slides.MathematicalText("x").overbar();
var groupChr = new aspose.slides.MathematicalText("x").join("y").join("z").group('⏡', aspose.slides.MathTopBotPositions.Bottom, aspose.slides.MathTopBotPositions.Top);
var borderBox = new aspose.slides.MathematicalText("x+y+z").toBorderBox();
var boxedOperator = new aspose.slides.MathematicalText(":=").toBox();
``` 

## **FAQ**

**Wie kann ich einer PowerPoint‑Folie eine mathematische Gleichung hinzufügen?**

Um eine mathematische Gleichung hinzuzufügen, erstellen Sie ein `MathShape`‑Objekt, das automatisch eine mathematische Portion enthält. Anschließend rufen Sie das `MathParagraph`‑Objekt aus der `MathPortion` ab und fügen `MathBlock`‑Objekte hinzu.

**Ist es möglich, komplex verschachtelte mathematische Ausdrücke zu erstellen?**

Ja, Aspose.Slides ermöglicht das Erstellen komplexer mathematischer Ausdrücke durch Verschachteln von MathBlocks. Jedes mathematische Element implementiert die `IMathElement`‑Klasse, sodass Sie Operationen (Join, Divide, Enclose usw.) anwenden können, um komplexere Strukturen zu erzeugen.

**Wie kann ich eine vorhandene mathematische Gleichung aktualisieren oder ändern?**

Um eine Gleichung zu ändern, greifen Sie über das `MathParagraph` auf die vorhandenen MathBlocks zu. Durch Methoden wie Join, Divide, Enclose usw. können Sie einzelne Elemente der Gleichung bearbeiten. Nach der Bearbeitung speichern Sie die Präsentation, um die Änderungen zu übernehmen.