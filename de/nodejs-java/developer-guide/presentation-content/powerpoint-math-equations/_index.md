---
title: Mathematische Gleichungen zu PowerPoint‑Präsentationen in JavaScript hinzufügen
linktitle: PowerPoint‑Mathematische Gleichungen
type: docs
weight: 80
url: /de/nodejs-java/powerpoint-math-equations/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Mathematische Gleichungen in PowerPoint PPT und PPTX mit Aspose.Slides für Node.js einfügen und bearbeiten, unterstützt OMML, Formatierungssteuerungen und klare Code‑Beispiele."
---

## **Übersicht**
In PowerPoint ist es möglich, eine mathematische Gleichung oder Formel zu schreiben und in der Präsentation anzuzeigen. Dafür werden verschiedene mathematische Symbole in PowerPoint dargestellt und können dem Text oder der Gleichung hinzugefügt werden. Hierfür wird der mathematische Gleichungskonstruktor in PowerPoint verwendet, der beim Erstellen komplexer Formeln hilft, wie zum Beispiel:

- Mathematischer Bruch
- Mathematischer Radikal
- Mathematische Funktion
- Grenzen und Logarithmusfunktionen
- N‑äre Operationen
- Matrix
- Große Operatoren
- Sinus‑, Kosinus‑Funktionen

Um eine mathematische Gleichung in PowerPoint hinzuzufügen, wird das *Einfügen -> Gleichung*-Menü verwendet:

![todo:image_alt_text](powerpoint-math-equations_1.png)

Dadurch wird ein mathematischer Text in XML erstellt, der in PowerPoint wie folgt angezeigt werden kann: 

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint unterstützt zahlreiche mathematische Symbole zur Erstellung von Gleichungen. Das Erstellen komplizierter mathematischer Gleichungen in PowerPoint führt jedoch oft nicht zu einem professionellen Ergebnis. Benutzer, die häufig mathematische Präsentationen erstellen müssen, greifen daher auf Drittanbieter‑Lösungen zurück, um gut aussehende Formeln zu erzeugen.

Mit [**Aspose.Slide API**](https://products.aspose.com/slides/nodejs-java/) können Sie programmgesteuert in C# mit mathematischen Gleichungen in PowerPoint‑Präsentationen arbeiten. Erstellen Sie neue mathematische Ausdrücke oder bearbeiten Sie bereits vorhandene. Der Export mathematischer Strukturen in Bilder wird ebenfalls teilweise unterstützt.

## **Wie man eine mathematische Gleichung erstellt**
Mathematische Elemente werden verwendet, um beliebige mathematische Konstruktionen mit beliebiger Verschachtelungstiefe zu bauen. Eine lineare Sammlung mathematischer Elemente bildet einen mathematischen Block, der durch die [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock)-Klasse repräsentiert wird. Die [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock)-Klasse ist im Wesentlichen ein separater mathematischer Ausdruck, eine Formel oder Gleichung. [**MathPortion**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathPortion) ist ein mathematischer Abschnitt, der mathematischen Text enthält (nicht zu verwechseln mit [**Portion**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion)). [**MathParagraph**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathParagraph) ermöglicht die Manipulation einer Menge von MathBlocks. Die genannten Klassen sind der Schlüssel zur Arbeit mit PowerPoint‑Mathegleichungen über die Aspose.Slides‑API.

Betrachten wir, wie wir die folgende mathematische Gleichung über die Aspose.Slides‑API erzeugen können:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Um einen mathematischen Ausdruck auf der Folie hinzuzufügen, fügen Sie zunächst eine Form hinzu, die den mathematischen Text enthalten wird:

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

Nach dem Erzeugen enthält die Form standardmäßig bereits einen Absatz mit einem mathematischen Abschnitt. Die [**MathPortion**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathPortion)-Klasse ist ein Abschnitt, der mathematischen Text enthält. Um auf den mathematischen Inhalt innerhalb der [**MathPortion**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathPortion) zuzugreifen, beziehen Sie sich auf die [**MathParagraph**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathParagraph)-Variable:

```javascript
var mathParagraph = mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
``` 

Die [**MathParagraph**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathParagraph)-Klasse erlaubt das Lesen, Hinzufügen, Bearbeiten und Löschen von MathBlocks ([**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock)), die aus einer Kombination mathematischer Elemente bestehen. Beispiel: Erzeugen Sie einen Bruch und fügen ihn in die Präsentation ein:

```javascript
var fraction = new aspose.slides.MathematicalText("x").divide("y");
mathParagraph.add(new aspose.slides.MathBlock(fraction));
``` 

Jedes mathematische Element wird durch eine Klasse repräsentiert, die die **MathElement**‑Klasse implementiert. Diese Klasse stellt viele Methoden zum einfachen Erzeugen mathematischer Ausdrücke bereit. Sie können mit einer einzigen Code‑Zeile einen recht komplexen Ausdruck erstellen. Beispiel: Der Satz des Pythagoras sieht so aus:

```javascript
var mathBlock = new aspose.slides.MathematicalText("c").setSuperscript("2").join("=").join(new aspose.slides.MathematicalText("a").setSuperscript("2")).join("+").join(new aspose.slides.MathematicalText("b").setSuperscript("2"));
``` 

Operationen der Klasse **MathElement** werden in jeder Art von Element implementiert, einschließlich des [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock).

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
Mathematische Ausdrücke werden aus Sequenzen mathematischer Elemente gebildet. Die Sequenz wird durch einen mathematischen Block repräsentiert, und die Argumente der Elemente formen eine baumartige Verschachtelung.

Es gibt zahlreiche mathematische Elementtypen, die zum Aufbau eines mathematischen Blocks verwendet werden können. Jeder dieser Typen kann in ein anderes Element eingebettet werden. Das bedeutet, dass Elemente eigentlich Container für andere sind und so eine baumartige Struktur bilden. Der einfachste Typ ist ein Element, das keine weiteren Elemente des mathematischen Textes enthält.

Jeder Typ implementiert die **MathElement**‑Klasse, sodass ein gemeinsamer Satz von mathematischen Operationen auf verschiedene Elementtypen angewendet werden kann.

### **MathematicalText‑Klasse**
Die [**MathematicalText**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathematicalText)-Klasse stellt einen mathematischen Text dar – das Basiselement aller mathematischen Konstruktionen. Mathematischer Text kann Operanden, Operatoren, Variablen und beliebigen linearen Text enthalten.

Beispiel: 𝑎=𝑏+𝑐

### **MathFraction‑Klasse**
Die [**MathFraction**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFraction)-Klasse beschreibt das Bruchobjekt, das aus Zähler und Nenner besteht, getrennt durch einen Bruchstrich. Der Bruchstrich kann horizontal oder diagonal sein, je nach Eigenschaften. Das Objekt wird außerdem für die Stack‑Funktion verwendet, bei der ein Element über einem anderen steht, ohne Bruchstrich.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **MathRadical‑Klasse**
Die [**MathRadical**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathRadical)-Klasse definiert die Radikal‑Funktion (mathematische Wurzel) mit Basis und optionalem Grad.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **MathFunction‑Klasse**
Die [**MathFunction**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction)-Klasse gibt eine Funktionsdefinition mit einem Argument an. Enthält Eigenschaften: [getName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction#getName--) – Funktionsname und [getBase](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction#getBase--) – Funktionsargument.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **MathNaryOperator‑Klasse**
Die [**MathNaryOperator**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathNaryOperator)-Klasse beschreibt ein N‑äres mathematisches Objekt, z. B. Summation oder Integral. Sie besteht aus einem Operator, einer Basis (oder Operand) und optionalen oberen und unteren Grenzen. Beispiele für N‑äre Operatoren sind Summation, Vereinigung, Schnittmenge, Integral.

Einfachere Operatoren wie Addition oder Subtraktion werden durch ein einzelnes Textelement – [MathematicalText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathematicalText) – dargestellt.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **MathLimit‑Klasse**
Die [**MathLimit**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLimit)-Klasse erzeugt eine obere oder untere Grenze. Sie definiert das Grenze‑Objekt, das Text auf der Grundlinie und verkleinerten Text darüber oder darunter enthält. Das Element enthält nicht das Wort „lim“, erlaubt jedoch das Platzieren von Text oben oder unten im Ausdruck. So entsteht beispielsweise der Ausdruck

![todo:image_alt_text](powerpoint-math-equations_8.png)

mit einer Kombination aus [**MathFunction**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction) und [**MathLimit**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLimit) so:

```javascript
var funcName = new aspose.slides.MathLimit(new aspose.slides.MathematicalText("lim"), new aspose.slides.MathematicalText("𝑥→∞"));
var mathFunc = new aspose.slides.MathFunction(funcName, new aspose.slides.MathematicalText("𝑥"));
``` 

### **MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement‑Klassen**
- [MathSubscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLeftSubSuperscriptElement)

Diese Klassen definieren tiefe bzw. hohe Indizes. Sie können Sub‑ und Superskript gleichzeitig links oder rechts setzen; ein einfacher Sub‑ oder Superskript wird nur rechts unterstützt. Der [MathSubscriptElement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathSubscriptElement) kann zudem den mathematischen Grad einer Zahl festlegen.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **MathMatrix‑Klasse**
Die [**MathMatrix**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathMatrix)-Klasse definiert ein Matrix‑Objekt, das Kind‑Elemente in Zeilen und Spalten anordnet. Hinweis: Matrizen besitzen keine eingebauten Begrenzungszeichen. Um die Matrix in Klammern zu setzen, verwenden Sie das Begrenzungs‑Objekt – [**MathDelimiter**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathDelimiter). Null‑Argumente erzeugen Lücken in Matrizen.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **MathArray‑Klasse**
Die [**MathArray**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathArray)-Klasse definiert ein vertikales Array von Gleichungen oder anderen mathematischen Objekten.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **Formatierung mathematischer Elemente**
- [**MathBorderBox**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBorderBox)-Klasse: zeichnet einen rechteckigen oder anderen Rahmen um das **MathElement**.  
  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBox)-Klasse: definiert die logische Kapselung (Packaging) des mathematischen Elements. Beispielsweise kann ein gekapseltes Objekt als Operator‑Emulator mit oder ohne Ausrichtungspunkt dienen, Zeilenumbrüche verhindern oder gruppiert werden, sodass innerhalb keine Zeilenumbrüche auftreten. Der Operator „==“ sollte beispielsweise gekapselt werden, um Zeilenumbrüche zu verhindern.

- [**MathDelimiter**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathDelimiter)-Klasse: definiert das Begrenzungs‑Objekt mit öffnenden und schließenden Zeichen (Klammern, geschweiften Klammern, eckigen Klammern, senkrechten Strichen) und ein oder mehrere mathematische Elemente darin, getrennt durch ein festgelegtes Zeichen. Beispiele: (𝑥²); [𝑥²|𝑦²].  
  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathAccent)-Klasse: definiert die Akzent‑Funktion mit Basis und kombinierendem diakritischem Zeichen.  
  Beispiel: 𝑎́.

- [**MathBar**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBar)-Klasse: definiert die Balken‑Funktion mit Basisargument und Über‑ oder Unterbalken.  
  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathGroupingCharacter)-Klasse: definiert ein Gruppierungszeichen über oder unter einem Ausdruck, meist zur Hervorhebung von Beziehungen zwischen Elementen.  
  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **Mathematische Operationen**
Jedes mathematische Element und jeder mathematische Ausdruck (via [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock)) implementiert die **MathElement**‑Klasse. Sie ermöglicht Operationen auf der bestehenden Struktur und das Bilden komplexerer Ausdrücke. Alle Operationen haben zwei Parameter‑Sätze: **MathElement** oder Zeichenkette. Instanzen der [**MathematicalText**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathematicalText)-Klasse werden implizit aus angegebenen Zeichenketten erzeugt, wenn String‑Argumente verwendet werden. Mathematische Operationen in Aspose.Slides werden unten aufgeführt.

### **join‑Methode**
- `join(String)`
- `join(MathElement)`

Verbindet ein mathematisches Element und bildet einen mathematischen Block. Beispiel:

```javascript
var element1 = new aspose.slides.MathematicalText("x");
var element2 = new aspose.slides.MathematicalText("y");
var block = element1.join(element2);
``` 

### **divide‑Methode**
- `divide(String)`
- `divide(MathElement)`
- `divide(String, MathFractionTypes)`
- `divide(MathElement, MathFractionTypes)`

Erzeugt einen Bruch des angegebenen Typs mit diesem Zähler und dem angegebenen Nenner. Beispiel:

```javascript
var numerator = new aspose.slides.MathematicalText("x");
var fraction = numerator.divide("y", aspose.slides.MathFractionTypes.Linear);
``` 

### **enclose‑Methode**
- `enclose()`
- `enclose(Char, Char)`

Setzt das Element in die angegebenen Zeichen, z. B. Klammern oder andere Begrenzungszeichen.

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

### **function‑Methode**
- `function(String)`
- `function(MathElement)`

Erzeugt eine Funktion eines Arguments, wobei das aktuelle Objekt als Funktionsname verwendet wird.

```java
/**
 * <p>
 * Takes a function of an argument using this instance as the function name
 * </p>
 */
public IMathFunction function(MathElement functionArgument);

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

### **asArgumentOfFunction‑Methode**
- `asArgumentOfFunction(String)`
- `asArgumentOfFunction(MathElement)`
- `asArgumentOfFunction(MathFunctionsOfOneArgument)`
- `asArgumentOfFunction(MathFunctionsOfTwoArguments, MathElement)`
- `asArgumentOfFunction(MathFunctionsOfTwoArguments, String)`

Nimmt die angegebene Funktion und verwendet die aktuelle Instanz als Argument. Sie können:

- Einen String als Funktionsnamen angeben, z. B. „cos“.
- Einen Wert aus den Aufzählungen [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunctionsOfOneArgument) oder [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunctionsOfTwoArguments) auswählen, z. B. [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunctionsOfOneArgument).**ArcSin**.
- Die Instanz des **MathElement** verwenden.

Beispiel:

```javascript
var funcName = new aspose.slides.MathLimit(new aspose.slides.MathematicalText("lim"), new aspose.slides.MathematicalText("𝑛→∞"));
var func1 = new aspose.slides.MathematicalText("2x").asArgumentOfFunction(funcName);
var func2 = new aspose.slides.MathematicalText("x").asArgumentOfFunction("sin");
var func3 = new aspose.slides.MathematicalText("x").asArgumentOfFunction(aspose.slides.MathFunctionsOfOneArgument.Sin);
var func4 = new aspose.slides.MathematicalText("x").asArgumentOfFunction(aspose.slides.MathFunctionsOfTwoArguments.Log, "3");
``` 

### **setSubscript, setSuperscript, setSubSuperscriptOnTheRight, setSubSuperscriptOnTheLeft‑Methoden**
- `setSubscript(String)`
- `setSubscript(MathElement)`
- `setSuperscript(String)`
- `setSuperscript(MathElement)`
- `setSubSuperscriptOnTheRight(String, String)`
- `setSubSuperscriptOnTheRight(MathElement, MathElement)`
- `setSubSuperscriptOnTheLeft(String, String)`
- `setSubSuperscriptOnTheLeft(MathElement, MathElement)`

Setzt Sub‑ und Superskript. Man kann beide gleichzeitig links oder rechts setzen; ein einzelnes Sub‑ bzw. Superskript wird nur rechts unterstützt. Der **Superscript** kann zudem den mathematischen Grad einer Zahl darstellen.

Beispiel:

```javascript
var script = new aspose.slides.MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **radical‑Methode**
- `radical(String)`
- `radical(MathElement)`

Bestimmt die mathematische Wurzel angegebenen Grades aus dem Argument.

Beispiel:

```javascript
var radical = new aspose.slides.MathematicalText("x").radical("3");
``` 

### **setUpperLimit und setLowerLimit‑Methoden**
- `setUpperLimit(String)`
- `setUpperLimit(MathElement)`
- `setLowerLimit(String)`
- `setLowerLimit(MathElement)`

Setzt obere bzw. untere Grenze. Hier geben obere bzw. untere Grenzen lediglich die Position des Arguments relativ zur Basis an.

Betrachten wir den Ausdruck:

![todo:image_alt_text](powerpoint-math-equations_8.png)

Solche Ausdrücke können durch Kombination der Klassen [MathFunction](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathFunction) und [MathLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathLimit) sowie der Operationen des `MathElement` wie folgt erstellt werden:

```javascript
var mathExpression = new aspose.slides.MathematicalText("lim").setLowerLimit("x→∞").function("x");
``` 

### **nary‑ und integral‑Methoden**
- `nary(MathNaryOperatorTypes, MathElement, MathElement)`
- `nary(MathNaryOperatorTypes, String, String)`
- `integral(MathIntegralTypes)`
- `integral(MathIntegralTypes, MathElement, MathElement)`
- `integral(MathIntegralTypes, String, String)`
- `integral(MathIntegralTypes, MathElement, MathElement, MathLimitLocations)`
- `integral(MathIntegralTypes, String, String, MathLimitLocations)`

Beide Methoden erzeugen und geben einen N‑ary‑Operator zurück, der den Typ [**MathNaryOperator**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathNaryOperator) hat. Bei `nary` bestimmt die Aufzählung [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathNaryOperatorTypes) den Operator‑Typ (Summation, Union usw.), ohne Integrale. Die `integral`‑Methode bietet die spezialisierte Integral‑Operation mit der Aufzählung [**MathIntegralTypes**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathIntegralTypes).

Beispiel:

```javascript
var baseArg = new aspose.slides.MathematicalText("x").join(new aspose.slides.MathematicalText("dx").toBox());
var integral = baseArg.integral(aspose.slides.MathIntegralTypes.Simple, "0", "1");
``` 

### **toMathArray‑Methode**
**toMathArray** legt Elemente in ein vertikales Array. Wird diese Operation für eine Instanz von [**MathBlock**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MathBlock) aufgerufen, werden alle Kind‑Elemente in das zurückgegebene Array platziert.

Beispiel:

```javascript
var arrayFunction = new aspose.slides.MathematicalText("x").join("y").toMathArray();
``` 

### **Formatierungsoperationen: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- **accent**‑Methode setzt ein Akzentzeichen (ein Zeichen über dem Element).
- **overbar**‑ und **underbar**‑Methoden setzen einen Balken oben bzw. unten.
- **group**‑Methode gruppiert mit einem Gruppierungszeichen, z. B. einer unteren geschweiften Klammer.
- **toBorderBox**‑Methode legt in eine Rand‑Box.
- **toBox**‑Methode legt in eine nicht‑visuelle Box (logische Gruppierung).

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

Um eine mathematische Gleichung hinzuzufügen, müssen Sie ein `MathShape`‑Objekt erstellen, das automatisch einen mathematischen Abschnitt enthält. Dann holen Sie sich das `MathParagraph` aus der `MathPortion` und fügen `MathBlock`‑Objekte hinzu.

**Ist es möglich, komplex verschachtelte mathematische Ausdrücke zu erzeugen?**

Ja, Aspose.Slides ermöglicht das Erzeugen komplexer mathematischer Ausdrücke durch Verschachteln von MathBlocks. Jedes mathematische Element erbt von der `MathElement`‑Klasse, die Operationen (Join, Divide, Enclose usw.) zur Kombination zu komplexeren Strukturen bereitstellt.

**Wie kann ich eine bestehende mathematische Gleichung aktualisieren oder ändern?**

Um eine Gleichung zu ändern, greifen Sie über das `MathParagraph` auf die vorhandenen MathBlocks zu. Durch Methoden wie Join, Divide, Enclose usw. können Sie einzelne Elemente der Gleichung modifizieren. Nach der Bearbeitung speichern Sie die Präsentation, um die Änderungen zu übernehmen.