---
title: Mathematische Gleichungen zu PowerPoint‑Präsentationen auf Android hinzufügen
linktitle: PowerPoint Mathegleichungen
type: docs
weight: 80
url: /de/androidjava/powerpoint-math-equations/
keywords:
- Mathegleichung
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
description: "Mathematische Gleichungen in PowerPoint PPT und PPTX mit Aspose.Slides für Android einfügen und bearbeiten, unterstützt OMML, Formatierungsoptionen und klare Java‑Codebeispiele."
---

## **Übersicht**
In PowerPoint ist es möglich, eine mathematische Gleichung oder Formel zu schreiben und in der Präsentation anzuzeigen. Dazu sind verschiedene mathematische Symbole in PowerPoint dargestellt und können dem Text oder der Gleichung hinzugefügt werden. Hierfür wird der mathematische Gleichungskonstruktor in PowerPoint verwendet, der das Erstellen komplexer Formeln wie folgt erleichtert:

- Mathematischer Bruch
- Mathematisches Radikal
- Mathematische Funktion
- Grenzen und Logarithmus‑Funktionen
- N‑stellige Operationen
- Matrix
- Große Operatoren
- Sin‑, Cos‑Funktionen

Um eine mathematische Gleichung in PowerPoint hinzuzufügen, wird das Menü *Einfügen → Gleichung* verwendet:

![todo:image_alt_text](powerpoint-math-equations_1.png)

Damit wird ein mathematischer Text in XML erzeugt, der in PowerPoint wie folgt angezeigt wird:

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint unterstützt zahlreiche mathematische Symbole zum Erstellen von Gleichungen. Das Erstellen komplizierter Gleichungen führt jedoch oft nicht zu einem professionellen Ergebnis. Benutzer, die häufig mathematische Präsentationen erstellen, greifen daher auf Drittanbieter‑Lösungen zurück, um ansprechende Formeln zu erzeugen.

Mit [**Aspose.Slide API**](https://products.aspose.com/slides/androidjava/) können Sie mathematische Gleichungen in PowerPoint‑Präsentationen programmgesteuert in C# bearbeiten. Erzeugen Sie neue mathematische Ausdrücke oder editieren Sie bereits vorhandene. Der Export mathematischer Strukturen in Bilder wird ebenfalls teilweise unterstützt.

## **So erstellen Sie eine mathematische Gleichung**
Mathematische Elemente werden zum Aufbau beliebiger mathematischer Konstruktionen mit beliebiger Verschachtelungstiefe verwendet. Eine lineare Sammlung mathematischer Elemente bildet einen mathematischen Block, der durch die Klasse [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock) dargestellt wird. Die Klasse [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock) ist im Wesentlichen ein abgegrenzter mathematischer Ausdruck, eine Formel oder Gleichung. [**MathPortion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion) ist ein mathematischer Abschnitt, der mathematischen Text enthält (nicht zu verwechseln mit [**Portion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion)). [**MathParagraph**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph) ermöglicht die Manipulation einer Menge von MathBlocks. Die genannten Klassen sind der Schlüssel zur Arbeit mit PowerPoint‑Mathe‑Gleichungen über die Aspose.Slides‑API.

Im Folgenden wird gezeigt, wie die folgende mathematische Gleichung mittels Aspose.Slides‑API erzeugt wird:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Um einen mathematischen Ausdruck auf einer Folie hinzuzufügen, fügen Sie zuerst eine Form hinzu, die den mathematischen Text enthalten soll:

```java
Presentation pres = new Presentation();
try {
    IAutoShape mathShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 720, 150);
} finally {
    if (pres != null) pres.dispose();
}
``` 

Nach dem Erzeugen enthält die Form standardmäßig einen Absatz mit einem mathematischen Abschnitt. Die Klasse [**MathPortion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion) ist ein Abschnitt, der mathematischen Text enthält. Um auf den mathematischen Inhalt von [**MathPortion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion) zuzugreifen, verwenden Sie die Variable [**MathParagraph**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph):

```java
IMathParagraph mathParagraph = ((MathPortion)mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();
``` 

Die Klasse [**MathParagraph**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph) ermöglicht das Lesen, Hinzufügen, Bearbeiten und Löschen von MathBlocks ([**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock)), die aus einer Kombination mathematischer Elemente bestehen. Beispiel: Erstellen Sie einen Bruch und fügen Sie ihn in die Präsentation ein:

```java
IMathFraction fraction = new MathematicalText("x").divide("y");

mathParagraph.add(new MathBlock(fraction));
``` 

Jedes mathematische Element wird durch eine Klasse repräsentiert, die das Interface [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement) implementiert. Dieses Interface bietet zahlreiche Methoden zum einfachen Erzeugen mathematischer Ausdrücke. Sie können mit einer einzigen Codezeile einen recht komplexen Ausdruck bauen. Beispiel: Der Satz des Pythagoras sieht so aus:

```java
IMathBlock mathBlock = new MathematicalText("c")
        .setSuperscript("2")
        .join("=")
        .join(new MathematicalText("a").setSuperscript("2"))
        .join("+")
        .join(new MathematicalText("b").setSuperscript("2"));
``` 

Operationen des Interfaces [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement) werden in allen Elementtypen implementiert, einschließlich [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock).

Vollständiges Beispiel:

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
Mathematische Ausdrücke setzen sich aus Sequenzen mathematischer Elemente zusammen. Die Sequenz wird durch einen mathematischen Block dargestellt, und die Argumente der Elemente bilden eine baumartige Verschachtelung.

Es gibt zahlreiche Elementtypen, die zum Aufbau eines mathematischen Blocks verwendet werden können. Jeder dieser Typen kann in einem anderen Element aggregiert werden – Elemente fungieren also als Container und bilden eine baumartige Struktur. Der einfachste Elementtyp enthält keine weiteren Elemente des mathematischen Textes.

Jeder Typ implementiert das Interface [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement), wodurch ein gemeinsamer Satz von Operationen auf unterschiedliche Elementtypen anwendbar ist.

### **MathematicalText‑Klasse**
Die Klasse [**MathematicalText**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathematicalText) repräsentiert mathematischen Text – das Basiselement aller mathematischen Konstruktionen. Sie kann Operanden, Operatoren, Variablen sowie beliebigen linearen Text darstellen.

Beispiel: 𝑎=𝑏+𝑐

### **MathFraction‑Klasse**
Die Klasse [**MathFraction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFraction) definiert ein Bruchobjekt bestehend aus Zähler und Nenner, getrennt durch einen Bruchstrich. Der Strich kann horizontal oder diagonal sein, je nach Eigenschaften. Das Objekt dient auch zur Darstellung einer Stapelfunktion, bei der ein Element über einem anderen ohne Bruchstrich liegt.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **MathRadical‑Klasse**
Die Klasse [**MathRadical**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathRadical) definiert die Radikal‑ (Wurzel‑) Funktion, bestehend aus einer Basis und einer optionalen Gradzahl.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **MathFunction‑Klasse**
Die Klasse [**MathFunction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction) definiert eine Funktions‑Notation mit Argument. Sie besitzt die Eigenschaften [getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction#getName--) – Funktionsname – und [getBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction#getBase--) – Funktionsargument.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **MathNaryOperator‑Klasse**
Die Klasse [**MathNaryOperator**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathNaryOperator) definiert ein n‑stelliges mathematisches Objekt, z. B. Summation oder Integral. Sie besteht aus einem Operator, einer Basis (bzw. einem Operanden) und optionalen oberen und unteren Grenzen. Beispiele sind Summation, Vereinigung, Schnittmenge, Integral.

Einfache Operatoren wie Plus oder Minus werden nicht durch diese Klasse, sondern durch das Element [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathematicalText) dargestellt.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **MathLimit‑Klasse**
Die Klasse [**MathLimit**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLimit) erzeugt eine obere oder untere Grenze. Sie besteht aus Text auf der Grundlinie und verkleinertem Text darüber bzw. darunter. Das Element enthält nicht das Wort „lim“, sondern ermöglicht das Platzieren von Text über oder unter dem Ausdruck. So wird der Ausdruck

![todo:image_alt_text](powerpoint-math-equations_8.png)

mittels einer Kombination aus [**MathFunction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction) und [**MathLimit**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLimit) wie folgt erzeugt:

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));

MathFunction mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));
``` 

### **MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement‑Klassen**
- [MathSubscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLeftSubSuperscriptElement)

Diese Klassen definieren einen tiefen bzw. hohen Index. Sie ermöglichen das gleichzeitige Setzen von Tief- und Hochstellen links oder rechts vom Argument; ein einzelner Tief‑ oder Hochindex wird jedoch nur rechts unterstützt. Der [MathSubscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSubscriptElement) kann zudem zur Angabe des mathematischen Grades einer Zahl verwendet werden.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **MathMatrix‑Klasse**
Die Klasse [**MathMatrix**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathMatrix) definiert ein Matrix‑Objekt, das aus Kind‑Elementen in Zeilen und Spalten besteht. Hinweis: Matrizen besitzen keine eingebauten Begrenzungszeichen. Um die Matrix in Klammern zu setzen, verwenden Sie das Begrenzungs‑Objekt – [**IMathDelimiter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathDelimiter). Null‑Argumente können Lücken in Matrizen erzeugen.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **MathArray‑Klasse**
Die Klasse [**MathArray**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathArray) definiert ein vertikales Array von Gleichungen oder anderen mathematischen Objekten.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **Formatierung mathematischer Elemente**
- **MathBorderBox**‑Klasse: zeichnet einen rechteckigen oder anderen Rahmen um das [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement).

  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- **MathBox**‑Klasse: definiert die logische Gruppierung (Boxing) des mathematischen Elements. Zum Beispiel kann ein „geboxter“ Operator als Emulation mit oder ohne Ausrichtungspunkt dienen, als Zeilenumbruch‑Markierung oder als nicht trennbare Gruppe.

- **MathDelimiter**‑Klasse: definiert das Begrenzungs‑Objekt mit öffnenden und schließenden Zeichen (Klammern, geschweiften Klammern, eckigen Klammern, senkrechten Strichen) und einem oder mehreren mathematischen Elementen innerhalb, getrennt durch ein angegebenes Zeichen.

  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- **MathAccent**‑Klasse: definiert die Akzent‑Funktion, bestehend aus einer Basis und einem kombinierenden diakritischen Zeichen.

  Beispiel: 𝑎́.

- **MathBar**‑Klasse: definiert die Strich‑Funktion, bestehend aus einem Basis‑Argument und einem Über‑ bzw. Unterstrich.

  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- **MathGroupingCharacter**‑Klasse: definiert ein Gruppierungszeichen über oder unter einem Ausdruck, üblicherweise zur Hervorhebung von Beziehungen zwischen Elementen.

  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **Mathematische Operationen**
Jedes mathematische Element und jeder mathematische Ausdruck (via [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock)) implementiert das Interface [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement). Es erlaubt, Operationen auf der bestehenden Struktur anzuwenden und komplexere Ausdrücke zu bilden. Alle Operationen besitzen zwei Parameter‑Varianten: entweder ein [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement) oder einen String. Instanzen der Klasse [**MathematicalText**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathematicalText) werden implizit aus den übergebenen Strings erzeugt. Die in Aspose.Slides verfügbaren mathematischen Operationen sind unten aufgeführt.

### **Join‑Methode**
- join(String)
- join(IMathElement)

Verknüpft ein mathematisches Element und bildet einen MathBlock. Beispiel:

```java
IMathElement element1 = new MathematicalText("x");

IMathElement element2 = new MathematicalText("y");

IMathBlock block = element1.join(element2);
``` 

### **Divide‑Methode**
- divide(String)
- divide(IMathElement)
- divide(String, MathFractionTypes)
- divide(IMathElement, MathFractionTypes)

Erzeugt einen Bruch des angegebenen Typs mit diesem Zähler und dem angegebenen Nenner. Beispiel:

```java
IMathElement numerator = new MathematicalText("x");

IMathFraction fraction = numerator.divide("y", MathFractionTypes.Linear);
``` 

### **Enclose‑Methode**
- enclose()
- enclose(Char, Char)

Umgibt das Element mit angegebenen Zeichen, z. B. Klammern.

```java
/**
 * Enclose a math element in parenthesis
 */
public IMathDelimiter enclose();

/**
 * Encloses this element in specified characters such as parenthesis or another characters as framing
 */
public IMathDelimiter enclose(char beginningCharacter, char endingCharacter);
``` 

Beispiel:

```java
IMathDelimiter delimiter = new MathematicalText("x").enclose('[', ']');

IMathDelimiter delimiter2 = new MathematicalText("elem1").join("elem2").enclose();
``` 

### **Function‑Methode**
- function(String)
- function(IMathElement)

Erzeugt eine Funktion eines Arguments, wobei das aktuelle Objekt als Funktionsname verwendet wird.

```java
public IMathFunction function(IMathElement functionArgument);

public IMathFunction function(String functionArgument);
``` 

Beispiel:

```java
IMathFunction func = new MathematicalText("sin").function("x");
``` 

### **AsArgumentOfFunction‑Methode**
- asArgumentOfFunction(String)
- asArgumentOfFunction(IMathElement)
- asArgumentOfFunction(MathFunctionsOfOneArgument)
- asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)
- asArgumentOfFunction(MathFunctionsOfTwoArguments, String)

Verwendet das aktuelle Objekt als Argument einer Funktion. Sie können:
- Einen String als Funktionsnamen angeben, z. B. “cos”.
- Einen der vordefinierten Enumerationswerte [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfOneArgument) oder [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfTwoArguments) wählen, z. B. [**MathFunctionsOfOneArgument**](MathFunctionsOfOneArgument).**ArcSin**.
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
- setSubscript(String)
- setSubscript(IMathElement)
- setSuperscript(String)
- setSuperscript(IMathElement)
- setSubSuperscriptOnTheRight(String, String)
- setSubSuperscriptOnTheRight(IMathElement, IMathElement)
- setSubSuperscriptOnTheLeft(String, String)
- setSubSuperscriptOnTheLeft(IMathElement, IMathElement)

Setzt Tief- und Hochstellen. Sie können Tief‑ und Hochstellen gleichzeitig links bzw. rechts vom Argument setzen; ein einzelner Tief‑ oder Hochindex wird nur rechts unterstützt. Der **Superscript** kann zudem zum Setzen des mathematischen Grades einer Zahl verwendet werden.

Beispiel:

```java
IMathLeftSubSuperscriptElement script = new MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Radical‑Methode**
- radical(String)
- radical(IMathElement)

Definiert die mathematische Wurzel des angegebenen Grades aus dem übergebenen Argument.

Beispiel:

```java
IMathRadical radical = new MathematicalText("x").radical("3");
``` 

### **SetUpperLimit und SetLowerLimit‑Methoden**
- setUpperLimit(String)
- setUpperLimit(IMathElement)
- setLowerLimit(String)
- setLowerLimit(IMathElement)

Setzt eine obere bzw. untere Grenze. Die Position gibt lediglich an, ob das Argument über oder unter der Basis liegt.

Beispielausdruck:

![todo:image_alt_text](powerpoint-math-equations_8.png)

Solche Ausdrücke können durch Kombination der Klassen **MathFunction** und **MathLimit** sowie der Operationen von **IMathElement** erzeugt werden:

```java
IMathFunction mathExpression = new MathematicalText("lim").setLowerLimit("x→∞").function("x");
``` 

### **Nary‑ und Integral‑Methoden**
- nary(MathNaryOperatorTypes, IMathElement, IMathElement)
- nary(MathNaryOperatorTypes, String, String)
- integral(MathIntegralTypes)
- integral(MathIntegralTypes, IMathElement, IMathElement)
- integral(MathIntegralTypes, String, String)
- integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)
- integral(MathIntegralTypes, String, String, MathLimitLocations)

Beide Methoden erzeugen und geben den N‑stellig‑Operator zurück, dargestellt durch den Typ [**IMathNaryOperator**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathNaryOperator). Bei **nary** gibt die Enumeration **MathNaryOperatorTypes** den Operatortyp an (Summation, Union usw., ohne Integrale). Die **integral**‑Methode verwendet die Enumeration **MathIntegralTypes**.

Beispiel:

```java
IMathBlock baseArg = new MathematicalText("x").join(new MathematicalText("dx").toBox());

IMathNaryOperator integral = baseArg.integral(MathIntegralTypes.Simple, "0", "1");
``` 

### **ToMathArray‑Methode**
Die Methode [**toMathArray**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#toMathArray--) ordnet Elemente in ein vertikales Array ein. Wird sie für ein [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock)‑Objekt aufgerufen, werden alle Kind‑Elemente im zurückgegebenen Array platziert.

Beispiel:

```java
IMathArray arrayFunction = new MathematicalText("x").join("y").toMathArray();
``` 

### **Formatierungsoperationen: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- **accent** ‑ setzt ein Akzentzeichen (ein Zeichen oberhalb des Elements).
- **overbar** und **underbar** ‑ setzen einen Strich oben bzw. unten.
- **group** ‑ platziert das Element in einer Gruppe mittels eines Gruppierungszeichens wie einer geschweiften Klammer unten oder einem anderen.
- **toBorderBox** ‑ legt das Element in einen Rahmen‑Box.
- **toBox** ‑ legt das Element in eine nicht‑visuelle Box (logische Gruppierung).

Beispiele:

```java
IMathAccent accent = new MathematicalText("x").accent('\u0303');

IMathBar bar = new MathematicalText("x").overbar();

IMathGroupingCharacter groupChr = new MathematicalText("x").join("y").join("z").group('\u23E1', MathTopBotPositions.Bottom, MathTopBotPositions.Top);

IMathBorderBox borderBox = new MathematicalText("x+y+z").toBorderBox();

IMathBox boxedOperator = new MathematicalText(":=").toBox();
``` 

## **FAQ**

**Wie füge ich einer PowerPoint‑Folie eine mathematische Gleichung hinzu?**

Um eine mathematische Gleichung hinzuzufügen, erstellen Sie ein MathShape‑Objekt, das automatisch einen mathematischen Abschnitt enthält. Anschließend rufen Sie das [MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/) aus dem [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/) ab und fügen [MathBlock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathblock/)-Objekte hinzu.

**Ist es möglich, komplex verschachtelte mathematische Ausdrücke zu erstellen?**

Ja, Aspose.Slides ermöglicht das Erzeugen komplexer mathematischer Ausdrücke durch Verschachteln von MathBlocks. Jedes mathematische Element implementiert das Interface [IMathElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imathelement/), das das Anwenden von Operationen (Join, Divide, Enclose usw.) zur Kombination zu komplexeren Strukturen erlaubt.

**Wie kann ich eine bestehende mathematische Gleichung aktualisieren oder ändern?**

Um eine Gleichung zu aktualisieren, greifen Sie über das [MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/) auf die vorhandenen MathBlocks zu. Durch Methoden wie Join, Divide, Enclose usw. können Sie einzelne Elemente der Gleichung bearbeiten. Nach den Änderungen speichern Sie die Präsentation, um die Änderungen zu übernehmen.