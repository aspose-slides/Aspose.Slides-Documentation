---
title: Mathgleichungen zu PowerPoint-Präsentationen in Java hinzufügen
linktitle: PowerPoint Mathgleichungen
type: docs
weight: 80
url: /de/java/powerpoint-math-equations/
keywords:
- Mathgleichung
- Mathzeichen
- Mathformel
- Mathtext
- Mathgleichung hinzufügen
- Mathzeichen hinzufügen
- Mathformel hinzufügen
- Mathtext hinzufügen
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Mathegleichungen in PowerPoint PPT und PPTX mit Aspose.Slides für Java einfügen und bearbeiten, unterstützt OMML, Formatierungssteuerungen und klare Java-Codebeispiele."
---

## **Übersicht**
In PowerPoint ist es möglich, eine mathematische Gleichung oder Formel zu schreiben und in der Präsentation anzuzeigen. Dazu werden verschiedene mathematische Symbole in PowerPoint dargestellt und können dem Text oder der Gleichung hinzugefügt werden. Hierfür wird der Formelkonstruktor für mathematische Gleichungen in PowerPoint verwendet, der beim Erstellen komplexer Formeln unterstützt, wie zum Beispiel:

- Mathematischer Bruch
- Mathematischer Radikal
- Mathematische Funktion
- Grenzen und Logarithmusfunktionen
- N-äre Operationen
- Matrix
- Große Operatoren
- Sinus‑ und Kosinusfunktionen

Um eine mathematische Gleichung in PowerPoint hinzuzufügen, wird das Menü *Insert -> Equation* verwendet:

![todo:image_alt_text](powerpoint-math-equations_1.png)

Dadurch wird ein mathematischer Text in XML erzeugt, der in PowerPoint wie folgt angezeigt werden kann: 

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint unterstützt zahlreiche mathematische Symbole zum Erstellen von Gleichungen. Das Erstellen komplizierter mathematischer Gleichungen in PowerPoint liefert jedoch oft kein gutes und professionell aussehendes Ergebnis. Anwender, die häufig mathematische Präsentationen erstellen müssen, greifen auf Lösungen von Drittanbietern zurück, um ansprechend aussehende Formeln zu erzeugen.

Mit [**Aspose.Slide API**](https://products.aspose.com/slides/java/), können Sie programmgesteuert in C# mit mathematischen Gleichungen in PowerPoint‑Präsentationen arbeiten. Erstellen Sie neue mathematische Ausdrücke oder bearbeiten Sie bereits erstellte. Der Export mathematischer Strukturen in Bilder wird ebenfalls teilweise unterstützt.

## **Wie man eine mathematische Gleichung erstellt**
Mathematische Elemente werden zum Aufbau beliebiger mathematischer Konstruktionen auf beliebiger Verschachtelungsebene verwendet. Eine lineare Sammlung mathematischer Elemente bildet einen mathematischen Block, der durch die [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock) Klasse dargestellt wird. [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock) Klasse ist im Wesentlichen ein separater mathematischer Ausdruck, Formel oder Gleichung. [**MathPortion**](https://reference.aspose.com/slides/java/com.aspose.slides/MathPortion) ist ein mathematischer Abschnitt, der mathematischen Text enthält (nicht verwechseln mit [**Portion**](https://reference.aspose.com/slides/java/com.aspose.slides/Portion)). [**MathParagraph**](https://reference.aspose.com/slides/java/com.aspose.slides/MathParagraph) ermöglicht die Manipulation einer Menge von MathBlocks. Die oben genannten Klassen sind der Schlüssel zur Arbeit mit PowerPoint‑Mathegleichungen über die Aspose.Slides‑API.

Sehen wir uns an, wie wir die folgende mathematische Gleichung mit der Aspose.Slides‑API erstellen können:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Um einen mathematischen Ausdruck auf der Folie hinzuzufügen, fügen Sie zunächst eine Form hinzu, die den mathematischen Text enthält:

```java
Presentation pres = new Presentation();
try {
    IAutoShape mathShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 720, 150);
} finally {
    if (pres != null) pres.dispose();
}
``` 

Nach dem Erstellen enthält die Form standardmäßig bereits einen Absatz mit einem mathematischen Abschnitt. Die [**MathPortion**](https://reference.aspose.com/slides/java/com.aspose.slides/MathPortion) Klasse ist ein Abschnitt, der mathematischen Text enthält. Um auf den mathematischen Inhalt in [**MathPortion**](https://reference.aspose.com/slides/java/com.aspose.slides/MathPortion) zuzugreifen, beziehen Sie sich auf die [**MathParagraph** ](https://reference.aspose.com/slides/java/com.aspose.slides/MathParagraph)variable:

```java
IMathParagraph mathParagraph = ((MathPortion)mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();
``` 

Die [**MathParagraph**](https://reference.aspose.com/slides/java/com.aspose.slides/MathParagraph) Klasse ermöglicht das Lesen, Hinzufügen, Bearbeiten und Löschen von MathBlocks ([**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock)), die aus einer Kombination mathematischer Elemente bestehen. Beispiel: Erstellen Sie einen Bruch und platzieren Sie ihn in der Präsentation:

```java
IMathFraction fraction = new MathematicalText("x").divide("y");

mathParagraph.add(new MathBlock(fraction));
``` 

Jedes mathematische Element wird durch eine Klasse dargestellt, die das [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) Interface implementiert. Dieses Interface stellt viele Methoden zum einfachen Erstellen mathematischer Ausdrücke bereit. Sie können einen recht komplexen mathematischen Ausdruck mit einer einzigen Codezeile erstellen. Beispiel: Der Satz des Pythagoras würde so aussehen:

```java
IMathBlock mathBlock = new MathematicalText("c")
        .setSuperscript("2")
        .join("=")
        .join(new MathematicalText("a").setSuperscript("2"))
        .join("+")
        .join(new MathematicalText("b").setSuperscript("2"));
``` 

Operationen des Interfaces [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) werden in jeder Art von Element implementiert, einschließlich des [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock).

Der vollständige Quellcode‑Beispiel:

```java
Presentation pres = new Presentation();
try {
    IAutoShape mathShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 720, 150);

    IMathParagraph mathParagraph = ((MathPortion)mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();
    
    IMathFraction fraction = new MathematicalText("x").divide("y");

    mathParagraph.add(new MathBlock(fraction));

    IMathBlock mathBlock = new MathematicalText("c")
            .setSuperscript("2")
            .join("=")
            .join(new MathematicalText("a").setSuperscript("2"))
            .join("+")
            .join(new MathematicalText("b").setSuperscript("2"));
    mathParagraph.add(mathBlock);

    pres.save("math.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
``` 

## **Typen mathematischer Elemente**
Mathematische Ausdrücke entstehen aus Folgen mathematischer Elemente. Die Folge mathematischer Elemente wird durch einen mathematischen Block dargestellt, und die Argumente mathematischer Elemente bilden eine baumartige Verschachtelung.

Es gibt viele Typen mathematischer Elemente, die zum Aufbau eines mathematischen Blocks verwendet werden können. Jedes dieser Elemente kann in ein anderes Element eingebettet (aggregiert) werden. Elemente fungieren somit als Container für andere und bilden eine baumartige Struktur. Der einfachste Typ von Elementen enthält keine weiteren Elemente des mathematischen Textes.

Jeder Typ von Mathe‑Element implementiert das [**IMathElement** ](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) Interface, wodurch ein gemeinsamer Satz von mathematischen Operationen auf verschiedene Elementtypen anwendbar ist.

### **Klasse MathematicalText**
Die [**MathematicalText**](https://reference.aspose.com/slides/java/com.aspose.slides/MathematicalText) Klasse repräsentiert einen mathematischen Text – das zugrunde liegende Element aller mathematischen Konstruktionen. Der mathematische Text kann Operanden und Operatoren, Variablen sowie jeden anderen linearen Text darstellen.

Beispiel: 𝑎=𝑏+𝑐

### **Klasse MathFraction**
[**MathFraction**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFraction) Klasse definiert das Bruchobjekt, das aus einem Zähler und einem Nenner besteht, getrennt durch einen Bruchstrich. Der Bruchstrich kann horizontal oder diagonal sein, abhängig von den Bruch‑Eigenschaften. Das Bruchobjekt wird auch verwendet, um die Stack‑Funktion darzustellen, bei der ein Element über einem anderen liegt, ohne Bruchstrich.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **Klasse MathRadical**
[**MathRadical**](https://reference.aspose.com/slides/java/com.aspose.slides/MathRadical) Klasse definiert die Radikal‑Funktion (mathematische Wurzel), bestehend aus einer Basis und einem optionalen Grad.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **Klasse MathFunction**
[**MathFunction**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction) Klasse definiert eine Funktion eines Arguments. Enthält Eigenschaften: [getName](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction#getName--) – Funktionsname und [getBase](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction#getBase--) – Funktionsargument.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **Klasse MathNaryOperator**
[**MathNaryOperator**](https://reference.aspose.com/slides/java/com.aspose.slides/MathNaryOperator) Klasse definiert ein N‑äres mathematisches Objekt, wie Summation oder Integral. Es besteht aus einem Operator, einer Basis (oder einem Operanden) und optionalen oberen und unteren Grenzen. Beispiele für N‑äre Operatoren sind Summation, Vereinigung, Schnittmenge, Integral.

Diese Klasse schließt einfache Operatoren wie Addition, Subtraktion usw. nicht ein. Sie werden durch ein einzelnes Textelement – [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/MathematicalText) – dargestellt.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **Klasse MathLimit**
[**MathLimit**](https://reference.aspose.com/slides/java/com.aspose.slides/MathLimit) Klasse erzeugt die obere oder untere Grenze. Sie definiert das Grenz‑Objekt, das Text auf der Grundlinie sowie verkleinerten Text direkt darüber oder darunter enthält. Dieses Element enthält nicht das Wort „lim“, ermöglicht aber das Platzieren von Text oben oder unten im Ausdruck. So wird der Ausdruck  

![todo:image_alt_text](powerpoint-math-equations_8.png)

mittels einer Kombination von [**MathFunction**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction) und [**MathLimit**](https://reference.aspose.com/slides/java/com.aspose.slides/MathLimit) wie folgt erstellt:

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));

MathFunction mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));
``` 

### **Klassen MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathLeftSubSuperscriptElement)

Die folgenden Klassen definieren einen unteren bzw. oberen Index. Sie können Subscript und Superscript gleichzeitig auf der linken oder rechten Seite eines Arguments setzen, wobei ein einzelner Subscript oder Superscript nur auf der rechten Seite unterstützt wird. Der [MathSubscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSubscriptElement) kann auch verwendet werden, um den mathematischen Grad einer Zahl festzulegen.

Beispiel: 

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **Klasse MathMatrix**
[**MathMatrix**](https://reference.aspose.com/slides/java/com.aspose.slides/MathMatrix) Klasse definiert das Matrix‑Objekt, das aus Kindelementen besteht, die in einer oder mehreren Zeilen und Spalten angeordnet sind. Wichtig: Matrizen haben keine eingebauten Trennzeichen. Um die Matrix in Klammern zu setzen, verwenden Sie das Trennzeichen‑Objekt – [**IMathDelimiter**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathDelimiter). Null‑Argumente können verwendet werden, um Lücken in Matrizen zu erzeugen.

Beispiel: 

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **Klasse MathArray**
[**MathArray**](https://reference.aspose.com/slides/java/com.aspose.slides/MathArray) Klasse definiert ein vertikales Array von Gleichungen oder beliebigen mathematischen Objekten.

Beispiel: 

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **Formatierung mathematischer Elemente**
- [**MathBorderBox**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBorderBox) Klasse: zeichnet ein Rechteck oder eine andere Umrandung um das [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement).

  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBox) Klasse: definiert die logische Box‑Darstellung (Verpackung) des mathematischen Elements. Beispielsweise kann ein in eine Box verpacktes Objekt als Operator‑Emulator mit oder ohne Ausrichtungspunkt dienen, als Zeilenumbruch‑Punkt oder gruppiert werden, sodass innerhalb keine Zeilenumbrüche erlaubt sind. Zum Beispiel sollte der Operator „==“ in eine Box gesetzt werden, um Zeilenumbrüche zu verhindern.

- [**MathDelimiter**](https://reference.aspose.com/slides/java/com.aspose.slides/MathDelimiter) Klasse: definiert das Trennzeichen‑Objekt, bestehend aus öffnenden und schließenden Zeichen (wie Klammern, geschweiften Klammern, eckigen Klammern und senkrechten Strichen) und einem oder mehreren mathematischen Elementen darin, getrennt durch ein angegebenes Zeichen. Beispiele: (𝑥2); [𝑥2|𝑦2].

  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**](https://reference.aspose.com/slides/java/com.aspose.slides/MathAccent) Klasse: definiert die Akzent‑Funktion, bestehend aus einer Basis und einem kombinierenden diakritischen Zeichen.

  Beispiel: 𝑎́.

- [**MathBar**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBar) Klasse: definiert die Balken‑Funktion, bestehend aus einem Basis‑Argument und einem Über‑ oder Unterbalken.

  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**](https://reference.aspose.com/slides/java/com.aspose.slides/MathGroupingCharacter) Klasse: definiert ein Gruppierungszeichen über oder unter einem Ausdruck, üblicherweise zur Hervorhebung von Beziehungen zwischen Elementen.

  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **Mathematische Operationen**
Jedes mathematische Element und jeder mathematische Ausdruck (via [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock)) implementiert das [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) Interface. Es ermöglicht die Anwendung von Operationen auf die bestehende Struktur und die Bildung komplexerer mathematischer Ausdrücke. Alle Operationen haben zwei Parametersätze: entweder [**IMathElement**] oder String als Argumente. Instanzen der [**MathematicalText**](https://reference.aspose.com/slides/java/com.aspose.slides/MathematicalText) Klasse werden implizit aus angegebenen Strings erstellt, wenn String‑Argumente verwendet werden. Mathematische Operationen, die in Aspose.Slides verfügbar sind, werden unten aufgeführt.

### **Join‑Methode**
- [join(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#join-com.aspose.slides.IMathElement-)

Verbindet ein mathematisches Element und bildet einen mathematischen Block. Beispiel:

```java
IMathElement element1 = new MathematicalText("x");

IMathElement element2 = new MathematicalText("y");

IMathBlock block = element1.join(element2);
``` 

### **Divide‑Methode**
- [divide(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#divide-java.lang.String-)
- [divide(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-)
- [divide(String, MathFractionTypes)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#divide-java.lang.String-int-)
- [divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-int-)

Erstellt einen Bruch des angegebenen Typs mit diesem Zähler und dem angegebenen Nenner. Beispiel:

```java
IMathElement numerator = new MathematicalText("x");

IMathFraction fraction = numerator.divide("y", MathFractionTypes.Linear);
``` 

### **Enclose‑Methode**
- [enclose()](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#enclose-char-char-)

Umgibt das Element mit angegebenen Zeichen, z. B. Klammern oder anderen Rahmenzeichen.

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

```java
IMathDelimiter delimiter = new MathematicalText("x").enclose('[', ']');

IMathDelimiter delimiter2 = new MathematicalText("elem1").join("elem2").enclose();
``` 

### **Function‑Methode**
- [function(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#function-java.lang.String-)
- [function(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#function-com.aspose.slides.IMathElement-)

Nimmt eine Funktion eines Arguments unter Verwendung des aktuellen Objekts als Funktionsnamen.

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

```java
IMathFunction func = new MathematicalText("sin").function("x");
``` 

### **AsArgumentOfFunction‑Methode**
- [asArgumentOfFunction(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-java.lang.String-)
- [asArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-int-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-int-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-int-java.lang.String-)

Verwendet die angegebene Funktion, wobei die aktuelle Instanz als Argument dient. Sie können:

- Einen String als Funktionsnamen angeben, z. B. „cos“.
- Einen der vordefinierten Werte der Aufzählungen [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunctionsOfOneArgument) oder [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunctionsOfTwoArguments) wählen, z. B. [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunctionsOfOneArgument).[**ArcSin**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunctionsOfOneArgument#ArcSin).
- Die Instanz des [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) angeben.

Beispiel:

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));

IMathFunction func1 = new MathematicalText("2x").asArgumentOfFunction(funcName);

IMathFunction func2 = new MathematicalText("x").asArgumentOfFunction("sin");

IMathFunction func3 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfOneArgument.Sin);

IMathFunction func4 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfTwoArguments.Log, "3");
``` 

### **SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft‑Methoden**
- [setSubscript(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubscript-java.lang.String-)
- [setSubscript(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubscript-com.aspose.slides.IMathElement-)
- [setSuperscript(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSuperscript-java.lang.String-)
- [setSuperscript(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSuperscript-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)

Setzt Subscript und Superscript. Sie können Subscript und Superscript gleichzeitig auf der linken oder rechten Seite des Arguments setzen, wobei ein einzelner Subscript oder Superscript nur auf der rechten Seite unterstützt wird. Der **Superscript** kann auch verwendet werden, um den mathematischen Grad einer Zahl festzulegen.

Beispiel:

```java
IMathLeftSubSuperscriptElement script = new MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Radical‑Methode**
- [radical(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#radical-com.aspose.slides.IMathElement-)

Definiert die mathematische Wurzel des angegebenen Grades aus dem angegebenen Argument.

Beispiel:

```java
IMathRadical radical = new MathematicalText("x").radical("3");
``` 

### **SetUpperLimit und SetLowerLimit‑Methoden**
- [setUpperLimit(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setUpperLimit-com.aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setLowerLimit-com.aspose.slides.IMathElement-)

Setzt die obere bzw. untere Grenze. Hier geben oben und unten lediglich die Position des Arguments relativ zur Basis an.

Betrachten wir den Ausdruck: 

![todo:image_alt_text](powerpoint-math-equations_8.png)

Solche Ausdrücke können durch eine Kombination der Klassen [MathFunction](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction) und [MathLimit](https://reference.aspose.com/slides/java/com.aspose.slides/MathLimit) sowie durch Operationen des [IMathElement](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) wie folgt erstellt werden:

```java
IMathFunction mathExpression = new MathematicalText("lim").setLowerLimit("x→∞").function("x");
``` 

### **Nary‑ und Integral‑Methoden**
- [nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#nary-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-)
- [integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-int-)
- [integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-int-)

Beide **nary**‑ und **integral**‑Methoden erzeugen und geben den N‑ären Operator zurück, der durch den Typ [**IMathNaryOperator**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathNaryOperator) repräsentiert wird. In der nary‑Methode gibt die Aufzählung [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/java/com.aspose.slides/MathNaryOperatorTypes) den Operator‑Typ an: Summation, Union usw., jedoch nicht Integrale. In der Integral‑Methode gibt die Aufzählung [**MathIntegralTypes**](https://reference.aspose.com/slides/java/com.aspose.slides/MathIntegralTypes) die Art des Integrals an.

Beispiel:

```java
IMathBlock baseArg = new MathematicalText("x").join(new MathematicalText("dx").toBox());

IMathNaryOperator integral = baseArg.integral(MathIntegralTypes.Simple, "0", "1");
``` 

### **ToMathArray‑Methode**
[**toMathArray**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#toMathArray--) legt Elemente in ein vertikales Array. Wird diese Operation für ein [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock)‑Objekt aufgerufen, werden alle Kindelemente in das zurückgegebene Array platziert.

Beispiel:

```java
IMathArray arrayFunction = new MathematicalText("x").join("y").toMathArray();
``` 

### **Formatierungsoperationen: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- [**accent**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#accent-char-) Methode setzt ein Akzentzeichen (ein Zeichen über dem Element).
- [**overbar**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#overbar--) und [**underbar**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#underbar--) Methoden setzen einen Balken oben bzw. unten.
- [**group**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#group--) Methode legt ein Gruppierungszeichen wie eine geschweifte Klammer unten oder ein anderes Zeichen an.
- [**toBorderBox**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#toBorderBox--) Methode legt ein Rand‑Box‑Element an.
- [**toBox**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#toBox--) Methode legt ein nicht‑visuelles Box‑Element (logische Gruppierung) an.

Beispiele:

```java
IMathAccent accent = new MathematicalText("x").accent('\u0303');

IMathBar bar = new MathematicalText("x").overbar();

IMathGroupingCharacter groupChr = new MathematicalText("x").join("y").join("z").group('\u23E1', MathTopBotPositions.Bottom, MathTopBotPositions.Top);

IMathBorderBox borderBox = new MathematicalText("x+y+z").toBorderBox();

IMathBox boxedOperator = new MathematicalText(":=").toBox();
``` 

## **FAQ**

**Wie kann ich eine mathematische Gleichung zu einer PowerPoint‑Folie hinzufügen?**

Um eine mathematische Gleichung hinzuzufügen, müssen Sie ein Math‑Shape‑Objekt erstellen, das automatisch einen mathematischen Abschnitt enthält. Dann rufen Sie das [MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/) vom [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/) ab und fügen [MathBlock](https://reference.aspose.com/slides/java/com.aspose.slides/mathblock/)‑Objekte hinzu.

**Ist es möglich, komplex verschachtelte mathematische Ausdrücke zu erstellen?**

Ja, Aspose.Slides ermöglicht das Erstellen komplexer mathematischer Ausdrücke durch Verschachteln von MathBlocks. Jedes mathematische Element implementiert das [IMathElement](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/)‑Interface, das die Anwendung von Operationen (Join, Divide, Enclose usw.) zur Kombination von Elementen zu komplexeren Strukturen erlaubt.

**Wie kann ich eine vorhandene mathematische Gleichung aktualisieren oder ändern?**

Um eine Gleichung zu aktualisieren, greifen Sie über das [MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/) auf die bestehenden MathBlocks zu. Durch die Verwendung von Methoden wie Join, Divide, Enclose usw. können Sie einzelne Elemente der Gleichung ändern. Nach der Bearbeitung speichern Sie die Präsentation, um die Änderungen zu übernehmen.