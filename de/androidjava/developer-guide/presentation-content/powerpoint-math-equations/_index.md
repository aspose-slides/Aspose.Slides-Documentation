---
title: Mathematische Gleichungen zu PowerPoint-Präsentationen unter Android hinzufügen
linktitle: PowerPoint-Mathegleichungen
type: docs
weight: 80
url: /de/androidjava/powerpoint-math-equations/
keywords:
- Mathematische Gleichung
- Mathematisches Symbol
- Mathematische Formel
- Mathematischer Text
- Mathematische Gleichung hinzufügen
- Mathematisches Symbol hinzufügen
- Mathematische Formel hinzufügen
- Mathematischen Text hinzufügen
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Mathematische Gleichungen in PowerPoint-PPT und PPTX mit Aspose.Slides für Android einfügen und bearbeiten, unterstützt OMML, Formatierungssteuerungen und klare Java-Code-Beispiele."
---

## **Übersicht**
In PowerPoint ist es möglich, eine mathematische Gleichung oder Formel zu schreiben und in der Präsentation anzuzeigen. Dazu werden in PowerPoint verschiedene mathematische Symbole dargestellt, die zum Text oder zur Gleichung hinzugefügt werden können. Dafür wird der mathematische Gleichungskonstruktor in PowerPoint verwendet, der das Erstellen komplexer Formeln wie folgt unterstützt:

- Mathematischer Bruch
- Mathematisches Radikal
- Mathematische Funktion
- Grenzen und Logarithmusfunktionen
- N-äre Operationen
- Matrix
- Große Operatoren
- Sin‑, Cos‑Funktionen

Um eine mathematische Gleichung in PowerPoint hinzuzufügen, wird das Menü *Einfügen → Gleichung* verwendet:

![todo:image_alt_text](powerpoint-math-equations_1.png)

Damit wird ein mathematischer Text in XML erzeugt, der in PowerPoint wie folgt angezeigt wird:

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint unterstützt zahlreiche mathematische Symbole zum Erstellen von Gleichungen. Das Erstellen komplizierter mathematischer Gleichungen in PowerPoint führt jedoch oft nicht zu einem professionellen Ergebnis. Benutzer, die häufig mathematische Präsentationen erstellen müssen, greifen daher auf Drittanbieter‑Lösungen zurück, um ansprechend aussehende Formeln zu erzeugen.

Mit [**Aspose.Slide API**](https://products.aspose.com/slides/androidjava/) können Sie programmgesteuert in C# mit mathematischen Gleichungen in PowerPoint‑Präsentationen arbeiten. Erstellen Sie neue mathematische Ausdrücke oder bearbeiten Sie zuvor erstellte. Der Export mathematischer Strukturen in Bilder wird ebenfalls teilweise unterstützt.


## **So erstellen Sie eine mathematische Gleichung**
Mathematische Elemente werden zum Aufbau beliebiger mathematischer Konstruktionen mit beliebiger Verschachtelungstiefe verwendet. Eine lineare Sammlung mathematischer Elemente bildet einen mathematischen Block, der durch die Klasse [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock) repräsentiert wird. Die Klasse [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock) stellt im Wesentlichen einen abgegrenzten mathematischen Ausdruck, eine Formel oder Gleichung dar. [**MathPortion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion) ist ein mathematischer Abschnitt, der mathematischen Text hält (nicht zu verwechseln mit [**Portion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion)). [**MathParagraph**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph) ermöglicht die Manipulation einer Menge von MathBlocks. Die genannten Klassen sind der Schlüssel zur Arbeit mit PowerPoint‑Mathegleichungen über die Aspose.Slides‑API.

Sehen wir uns an, wie wir die folgende mathematische Gleichung über die Aspose.Slides‑API erzeugen können:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Um einen mathematischen Ausdruck auf der Folie hinzuzufügen, fügen Sie zunächst eine Form hinzu, die den mathematischen Text enthalten soll:

```java
Presentation pres = new Presentation();
try {
    IAutoShape mathShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 720, 150);
} finally {
    if (pres != null) pres.dispose();
}
``` 

Nach dem Erzeugen enthält die Form standardmäßig einen Absatz mit einem mathematischen Abschnitt. Die Klasse [**MathPortion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion) ist ein Abschnitt, der mathematischen Text enthält. Um auf den mathematischen Inhalt innerhalb von [**MathPortion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion) zuzugreifen, verwenden Sie die Variable [**MathParagraph**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph):

```java
IMathParagraph mathParagraph = ((MathPortion)mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();
``` 

Die Klasse [**MathParagraph**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph) ermöglicht das Lesen, Hinzufügen, Bearbeiten und Löschen von MathBlocks ([**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock)), die aus einer Kombination mathematischer Elemente bestehen. Beispiel: Erzeugen Sie einen Bruch und fügen Sie ihn in die Präsentation ein:

```java
IMathFraction fraction = new MathematicalText("x").divide("y");

mathParagraph.add(new MathBlock(fraction));
``` 

Jedes mathematische Element wird durch eine Klasse repräsentiert, die das Interface [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement) implementiert. Dieses Interface bietet viele Methoden zum einfachen Erstellen mathematischer Ausdrücke. Sie können einen ziemlich komplexen mathematischen Ausdruck mit einer einzigen Code‑Zeile erzeugen. Beispiel: Der Satz des Pythagoras sieht so aus:

```java
IMathBlock mathBlock = new MathematicalText("c")
        .setSuperscript("2")
        .join("=")
        .join(new MathematicalText("a").setSuperscript("2"))
        .join("+")
        .join(new MathematicalText("b").setSuperscript("2"));
``` 

Operationen des Interfaces [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement) werden in jedem Elementtyp implementiert, einschließlich des [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock).

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

## **Mathematische Elementtypen**
Mathematische Ausdrücke werden aus Sequenzen mathematischer Elemente gebildet. Die Sequenz wird durch einen mathematischen Block repräsentiert, und die Argumente der Elemente bilden eine baumartige Verschachtelung.

Es gibt zahlreiche mathematische Elementtypen, die zum Aufbau eines mathematischen Blocks verwendet werden können. Jeder dieser Typen kann in einem anderen Element aggregiert werden. Das heißt, Elemente sind Container für andere Elemente und bilden eine baumartige Struktur. Der einfachste Typ ist ein Element, das keine anderen Elemente des mathematischen Textes enthält.

Jeder Typ eines mathematischen Elements implementiert das Interface [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement) und ermöglicht die einheitliche Verwendung mathematischer Operationen.

### **MathematicalText‑Klasse**
Die Klasse [**MathematicalText**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathematicalText) repräsentiert einen mathematischen Text – das Grundelement aller mathematischen Konstruktionen. Mathematischer Text kann Operanden, Operatoren, Variablen und beliebigen linearen Text darstellen.

Beispiel: 𝑎=𝑏+𝑐

### **MathFraction‑Klasse**
Die Klasse [**MathFraction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFraction) spezifiziert ein Bruchobjekt, das aus Zähler und Nenner besteht, getrennt durch einen Bruchstrich. Der Strich kann horizontal oder diagonal sein, abhängig von den Eigenschaften des Bruchs. Das Objekt wird auch verwendet, um das Stapelfunktionselement zu repräsentieren, bei dem ein Element über einem anderen steht, ohne Bruchstrich.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **MathRadical‑Klasse**
Die Klasse [**MathRadical**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathRadical) spezifiziert die Wurzelfunktion (mathematischer Radikal), bestehend aus einer Basis und einem optionalen Grad.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **MathFunction‑Klasse**
Die Klasse [**MathFunction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction) spezifiziert eine Funktion eines Arguments. Sie enthält die Eigenschaften: [getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction#getName--) – Funktionsname und [getBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction#getBase--) – Funktionsargument.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **MathNaryOperator‑Klasse**
Die Klasse [**MathNaryOperator**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathNaryOperator) spezifiziert ein N‑äres mathematisches Objekt, wie Summation oder Integral. Sie besteht aus einem Operator, einer Basis (oder Operand) und optionalen oberen und unteren Grenzen. Beispiele für N‑äre Operatoren sind Summation, Vereinigung, Schnittmenge, Integral.

Diese Klasse schließt einfache Operatoren wie Addition oder Subtraktion nicht ein; diese werden durch ein einzelnes Textelement – [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathematicalText) – dargestellt.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **MathLimit‑Klasse**
Die Klasse [**MathLimit**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLimit) erzeugt eine obere oder untere Grenze. Sie spezifiziert das Grenzobjekt, das Text auf der Grundlinie und verkleinerten Text unmittelbar darüber oder darunter enthält. Dieses Element beinhaltet nicht das Wort „lim“, erlaubt jedoch das Platzieren von Text oben oder unten im Ausdruck. Der Ausdruck

![todo:image_alt_text](powerpoint-math-equations_8.png)

wird mit einer Kombination aus [**MathFunction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction) und [**MathLimit**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLimit) wie folgt erzeugt:

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));

MathFunction mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));
``` 

### **MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement‑Klassen**
- [MathSubscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLeftSubSuperscriptElement)

Die genannten Klassen spezifizieren einen Tief- oder Hochindex. Sie können Tief‑ und Hochindex gleichzeitig auf der linken oder rechten Seite eines Arguments setzen; ein einzelner Tief‑ oder Hochindex wird jedoch nur auf der rechten Seite unterstützt. Der [MathSubscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSubscriptElement) kann zudem verwendet werden, um den mathematischen Grad einer Zahl zu setzen.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **MathMatrix‑Klasse**
Die Klasse [**MathMatrix**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathMatrix) spezifiziert ein Matrixobjekt, das aus Kind‑Elementen besteht, die in einer oder mehreren Zeilen und Spalten angeordnet sind. Hinweis: Matrizen besitzen keine eingebauten Begrenzungszeichen. Um die Matrix in Klammern zu setzen, verwenden Sie das Begrenzungsobjekt – [**IMathDelimiter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathDelimiter). Null‑Argumente können verwendet werden, um Lücken in Matrizen zu erzeugen.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **MathArray‑Klasse**
Die Klasse [**MathArray**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathArray) spezifiziert ein vertikales Array von Gleichungen oder anderen mathematischen Objekten.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **Formatierung mathematischer Elemente**
- [**MathBorderBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBorderBox)‑Klasse: zeichnet einen rechteckigen oder anderen Rand um das [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement).

  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBox)‑Klasse: spezifiziert die logische Box‑Umhüllung des mathematischen Elements. Beispielsweise kann ein in einer Box gekapseltes Objekt als Operator‑Emulator mit oder ohne Ausrichtungspunkt dienen, als Zeilenumbruch‑Hilfsmittel oder gruppiert werden, sodass innerhalb kein Zeilenumbruch zulässig ist. Der Operator „==“ sollte beispielsweise in eine Box gepackt werden, um Zeilenumbrüche zu verhindern.

- [**MathDelimiter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathDelimiter)‑Klasse: spezifiziert das Begrenzungsobjekt, bestehend aus öffnenden und schließenden Zeichen (wie Klammern, geschweiften Klammern, eckigen Klammern oder senkrechten Strichen) und einem oder mehreren mathematischen Elementen, die durch ein angegebenes Zeichen getrennt sind. Beispiele: (𝑥²); [𝑥²|𝑦²].

  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathAccent)‑Klasse: spezifiziert die Akzentfunktion, bestehend aus einer Basis und einem kombinierenden diakritischen Zeichen.

  Beispiel: 𝑎́.

- [**MathBar**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBar)‑Klasse: spezifiziert die Balkenfunktion, bestehend aus einem Basis‑Argument und einem Über‑ oder Unterbalken.

  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathGroupingCharacter)‑Klasse: spezifiziert ein Gruppierungszeichen über oder unter einem Ausdruck, üblicherweise um Beziehungen zwischen Elementen zu verdeutlichen.

  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_15.png)


## **Mathematische Operationen**
Jedes mathematische Element und jeder mathematische Ausdruck (via [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock)) implementiert das Interface [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement). Es erlaubt, Operationen auf bestehende Strukturen anzuwenden und komplexere mathematische Ausdrücke zu bilden. Alle Operationen besitzen zwei Parameter‑Sätze: entweder ein [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement) oder einen String als Argument. Instanzen der Klasse [**MathematicalText**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathematicalText) werden implizit aus den angegebenen Strings erzeugt, wenn String‑Argumente verwendet werden. Die in Aspose.Slides verfügbaren mathematischen Operationen sind unten aufgeführt.

### **Join‑Methode**
- [join(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#join-com.aspose.slides.IMathElement-)

Verbindet ein mathematisches Element und bildet einen mathematischen Block. Beispiel:

```java
IMathElement element1 = new MathematicalText("x");

IMathElement element2 = new MathematicalText("y");

IMathBlock block = element1.join(element2);
``` 

### **Divide‑Methode**
- [divide(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#divide-java.lang.String-)
- [divide(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-)
- [divide(String, MathFractionTypes)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#divide-java.lang.String-int-)
- [divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-int-)

Erstellt einen Bruch des angegebenen Typs mit diesem Zähler und dem angegebenen Nenner. Beispiel:

```java
IMathElement numerator = new MathematicalText("x");

IMathFraction fraction = numerator.divide("y", MathFractionTypes.Linear);
``` 

### **Enclose‑Methode**
- [enclose()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#enclose-char-char-)

Umschließt das Element in angegebenen Zeichen, z. B. Klammern oder anderen Rahmenzeichen.

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
- [function(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#function-java.lang.String-)
- [function(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#function-com.aspose.slides.IMathElement-)

Erzeugt eine Funktion eines Arguments, wobei das aktuelle Objekt als Funktionsname verwendet wird.

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
- [asArgumentOfFunction(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-java.lang.String-)
- [asArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-int-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-int-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-int-java.lang.String-)

Verwendet die aktuelle Instanz als Argument einer Funktion. Sie können:

- Einen String als Funktionsnamen angeben, z. B. „cos“.
- Einen der vordefinierten Werte der Aufzählungen [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfOneArgument) oder [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfTwoArguments) auswählen, z. B. [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfOneArgument).[**ArcSin**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfOneArgument#ArcSin).
- Eine Instanz von [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement) verwenden.

Beispiel:

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));

IMathFunction func1 = new MathematicalText("2x").asArgumentOfFunction(funcName);

IMathFunction func2 = new MathematicalText("x").asArgumentOfFunction("sin");

IMathFunction func3 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfOneArgument.Sin);

IMathFunction func4 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfTwoArguments.Log, "3");
``` 

### **SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft‑Methoden**
- [setSubscript(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubscript-java.lang.String-)
- [setSubscript(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubscript-com.aspose.slides.IMathElement-)
- [setSuperscript(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSuperscript-java.lang.String-)
- [setSuperscript(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSuperscript-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)

Setzt Tief‑ bzw. Hochindex. Sie können Tief‑ und Hochindex gleichzeitig auf der linken oder rechten Seite des Arguments setzen; ein einzelner Tief‑ oder Hochindex wird jedoch nur auf der rechten Seite unterstützt. Der **Superscript** kann zudem verwendet werden, um den mathematischen Grad einer Zahl zu setzen.

Beispiel:

```java
IMathLeftSubSuperscriptElement script = new MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Radical‑Methode**
- [radical(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#radical-com.aspose.slides.IMathElement-)

Gibt die mathematische Wurzel des angegebenen Grades des Arguments an.

Beispiel:

```java
IMathRadical radical = new MathematicalText("x").radical("3");
``` 

### **SetUpperLimit‑ und SetLowerLimit‑Methoden**
- [setUpperLimit(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setUpperLimit-com.aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setLowerLimit-com.aspose.slides.IMathElement-)

Definiert eine obere oder untere Grenze. Dabei geben die Begriffe „oben“ bzw. „unten“ lediglich die Position des Arguments relativ zur Basis an.

Betrachten wir den Ausdruck:

![todo:image_alt_text](powerpoint-math-equations_8.png)

Solche Ausdrücke können durch eine Kombination der Klassen [MathFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction) und [MathLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLimit) sowie der Operationen des [IMathElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement) wie folgt erstellt werden:

```java
IMathFunction mathExpression = new MathematicalText("lim").setLowerLimit("x→∞").function("x");
``` 

### **Nary‑ und Integral‑Methoden**
- [nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#nary-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-)
- [integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-int-)
- [integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-int-)

Sowohl **nary**‑ als auch **integral**‑Methoden erzeugen und geben den N‑ärigen Operator zurück, der durch den Typ [**IMathNaryOperator**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathNaryOperator) repräsentiert wird. In der nary‑Methode gibt die Aufzählung [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathNaryOperatorTypes) den Operator‑Typ an (Summation, Union usw.), jedoch nicht Integrale. In der Integral‑Methode wird das spezialisierte Integral‑Objekt mit der Aufzählung [**MathIntegralTypes**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathIntegralTypes) verwendet.

Beispiel:

```java
IMathBlock baseArg = new MathematicalText("x").join(new MathematicalText("dx").toBox());

IMathNaryOperator integral = baseArg.integral(MathIntegralTypes.Simple, "0", "1");
``` 

### **ToMathArray‑Methode**
[**toMathArray**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#toMathArray--) legt Elemente in ein vertikales Array. Wenn diese Operation für eine Instanz von [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock) aufgerufen wird, werden alle Kind‑Elemente in das zurückgegebene Array platziert.

Beispiel:

```java
IMathArray arrayFunction = new MathematicalText("x").join("y").toMathArray();
``` 

### **Formatierungsoperationen: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- **accent**‑Methode setzt ein Akzentzeichen (ein Zeichen oberhalb des Elements).
- **overbar**‑ und **underbar**‑Methoden setzen einen Balken ober- bzw. unterhalb des Elements.
- **group**‑Methode gruppiert mithilfe eines Gruppierungszeichens, z. B. einer unteren geschweiften Klammer.
- **toBorderBox**‑Methode legt das Element in eine Rand‑Box.
- **toBox**‑Methode legt das Element in eine nicht‑sichtbare Box (logische Gruppierung).

Beispiele:

```java
IMathAccent accent = new MathematicalText("x").accent('\u0303');

IMathBar bar = new MathematicalText("x").overbar();

IMathGroupingCharacter groupChr = new MathematicalText("x").join("y").join("z").group('\u23E1', MathTopBotPositions.Bottom, MathTopBotPositions.Top);

IMathBorderBox borderBox = new MathematicalText("x+y+z").toBorderBox();

IMathBox boxedOperator = new MathematicalText(":=").toBox();
``` 

## **FAQ**

**Wie kann ich einer PowerPoint‑Folie eine mathematische Gleichung hinzufügen?**

Um eine mathematische Gleichung hinzuzufügen, erstellen Sie ein Math‑Shape‑Objekt, das automatisch einen mathematischen Abschnitt enthält. Anschließend rufen Sie das [MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/) aus dem [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/) ab und fügen ihm [MathBlock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathblock/)-Objekte hinzu.

**Ist es möglich, komplex verschachtelte mathematische Ausdrücke zu erstellen?**

Ja, Aspose.Slides ermöglicht das Erstellen komplexer mathematischer Ausdrücke durch Verschachtelung von MathBlocks. Jedes mathematische Element implementiert das Interface [IMathElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), das das Anwenden von Operationen (Join, Divide, Enclose usw.) zur Kombination von Elementen zu komplexeren Strukturen erlaubt.

**Wie kann ich eine vorhandene mathematische Gleichung aktualisieren oder ändern?**

Um eine Gleichung zu ändern, greifen Sie über das [MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/) auf die bestehenden MathBlocks zu. Durch Methoden wie Join, Divide, Enclose usw. können Sie einzelne Elemente der Gleichung modifizieren. Nach der Bearbeitung speichern Sie die Präsentation, um die Änderungen zu übernehmen.