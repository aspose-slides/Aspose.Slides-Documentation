---
title: "Mathematische Gleichungen zu PowerPoint-Präsentationen in Java hinzufügen"
linktitle: "PowerPoint Mathegleichungen"
type: docs
weight: 80
url: /de/java/powerpoint-math-equations/
keywords:
  - "Mathegleichung"
  - "Mathezeichen"
  - "Matheformel"
  - "Mathetext"
  - "Mathegleichung hinzufügen"
  - "Mathezeichen hinzufügen"
  - "Matheformel hinzufügen"
  - "Mathetext hinzufügen"
  - "PowerPoint"
  - "Präsentation"
  - "Java"
  - "Aspose.Slides"
description: "Mathematische Gleichungen in PowerPoint PPT und PPTX einfügen und bearbeiten mit Aspose.Slides für Java, unterstützt OMML, Formatierungssteuerungen und klare Java-Codebeispiele."
---

## **Übersicht**
In PowerPoint ist es möglich, eine mathematische Gleichung oder Formel zu schreiben und sie in der Präsentation anzuzeigen. Hierzu werden verschiedene mathematische Symbole in PowerPoint dargestellt und können dem Text oder der Gleichung hinzugefügt werden. Dafür wird der mathematische Gleichungskonstruktor in PowerPoint verwendet, der hilft, komplexe Formeln zu erstellen, wie zum Beispiel:

- Mathematischer Bruch
- Mathematisches Radikal
- Mathematische Funktion
- Grenzen und Logarithmusfunktionen
- N‑äre Operationen
- Matrix
- Große Operatoren
- Sinus‑, Kosinus‑Funktionen

Um eine mathematische Gleichung in PowerPoint hinzuzufügen, wird das Menü *Einfügen -> Gleichung* verwendet:

![todo:image_alt_text](powerpoint-math-equations_1.png)

Damit wird ein mathematischer Text in XML erzeugt, der in PowerPoint wie folgt angezeigt werden kann:  

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint unterstützt zahlreiche mathematische Symbole zum Erstellen von Gleichungen. Das Erstellen komplizierter Gleichungen in PowerPoint führt jedoch oft nicht zu einem guten und professionellen Ergebnis. Nutzer, die häufig mathematische Präsentationen erstellen, greifen daher auf Drittanbieter‑Lösungen zurück, um ansprechende Formeln zu erzeugen.

Mit [**Aspose.Slide API**](https://products.aspose.com/slides/java/) können Sie programmgesteuert mit mathematischen Gleichungen in PowerPoint‑Präsentationen in C# arbeiten. Erstellen Sie neue mathematische Ausdrücke oder bearbeiten Sie bereits erstellte. Der Export mathematischer Strukturen in Bilder wird ebenfalls teilweise unterstützt.

## **Erstellung einer mathematischen Gleichung**
Mathematische Elemente werden verwendet, um beliebige mathematische Konstruktionen mit beliebiger Verschachtelung zu erstellen. Eine lineare Sammlung mathematischer Elemente bildet einen mathematischen Block, der durch die Klasse [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock) repräsentiert wird. Die Klasse [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock) ist im Wesentlichen ein abgegrenzter mathematischer Ausdruck, eine Formel oder Gleichung. [**MathPortion**](https://reference.aspose.com/slides/java/com.aspose.slides/MathPortion) ist ein mathematischer Abschnitt, der mathematischen Text enthält (nicht zu verwechseln mit [**Portion**](https://reference.aspose.com/slides/java/com.aspose.slides/Portion)). [**MathParagraph**](https://reference.aspose.com/slides/java/com.aspose.slides/MathParagraph) ermöglicht die Manipulation einer Menge von MathBlocks. Die genannten Klassen sind die Schlüssel zur Arbeit mit PowerPoint‑Mathegleichungen über die Aspose.Slides‑API.

Schauen wir uns an, wie wir die folgende mathematische Gleichung über die Aspose.Slides‑API erstellen können:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Um einen mathematischen Ausdruck auf der Folie hinzuzufügen, fügen Sie zunächst eine Form hinzu, die den mathematischen Text aufnehmen wird:

```java
Presentation pres = new Presentation();
try {
    IAutoShape mathShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 720, 150);
} finally {
    if (pres != null) pres.dispose();
}
``` 

Nach dem Erstellen enthält die Form standardmäßig einen Absatz mit einem mathematischen Abschnitt. Die Klasse [**MathPortion**](https://reference.aspose.com/slides/java/com.aspose.slides/MathPortion) ist ein Abschnitt, der mathematischen Text enthält. Um auf den Inhalt von [**MathPortion**](https://reference.aspose.com/slides/java/com.aspose.slides/MathPortion) zuzugreifen, verwenden Sie die Variable der Klasse [**MathParagraph**](https://reference.aspose.com/slides/java/com.aspose.slides/MathParagraph):

```java
IMathParagraph mathParagraph = ((MathPortion)mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();
``` 

Die Klasse [**MathParagraph**](https://reference.aspose.com/slides/java/com.aspose.slides/MathParagraph) ermöglicht das Lesen, Hinzufügen, Bearbeiten und Löschen von MathBlocks ([**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock)), die aus einer Kombination mathematischer Elemente bestehen. Beispiel: Erstellen Sie einen Bruch und fügen Sie ihn in die Präsentation ein:

```java
IMathFraction fraction = new MathematicalText("x").divide("y");

mathParagraph.add(new MathBlock(fraction));
``` 

Jedes mathematische Element wird durch eine Klasse repräsentiert, die das Interface [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) implementiert. Dieses Interface bietet zahlreiche Methoden zum einfachen Erstellen mathematischer Ausdrücke. Einen relativ komplexen Ausdruck können Sie mit einer einzigen Codezeile erzeugen. Das pythagoreische Theorem beispielsweise sieht so aus:

```java
IMathBlock mathBlock = new MathematicalText("c")
        .setSuperscript("2")
        .join("=")
        .join(new MathematicalText("a").setSuperscript("2"))
        .join("+")
        .join(new MathematicalText("b").setSuperscript("2"));
``` 

Operationen des Interfaces [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) sind in allen Elementtypen implementiert, einschließlich [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock).

Der vollständige Beispielcode:

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
Mathematische Ausdrücke werden aus Sequenzen mathematischer Elemente gebildet. Die Sequenz wird durch einen mathematischen Block repräsentiert, und die Argumente der Elemente bilden eine baumartige Verschachtelung.

Es gibt zahlreiche Typen mathematischer Elemente, die zum Aufbau eines mathematischen Blocks verwendet werden können. Jedes dieser Elemente kann in ein anderes Element eingebettet werden. Das heißt, Elemente sind Container für andere und bilden so eine baumartige Struktur. Der einfachste Typ enthält keine weiteren Elemente des mathematischen Textes.

Jeder Elementtyp implementiert das Interface [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) und ermöglicht die Nutzung gemeinsamer mathematischer Operationen.

### **Klasse MathematicalText**
Die Klasse [**MathematicalText**](https://reference.aspose.com/slides/java/com.aspose.slides/MathematicalText) stellt mathematischen Text dar – das Basiselement aller mathematischen Konstruktionen. Sie kann Operanden, Operatoren, Variablen und beliebigen linearen Text repräsentieren.

Beispiel: 𝑎=𝑏+𝑐

### **Klasse MathFraction**
Die Klasse [**MathFraction**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFraction) definiert ein Bruchobjekt mit Zähler und Nenner, getrennt durch einen Bruchstrich. Der Strich kann horizontal oder diagonal sein. Das Objekt wird ebenfalls für die Stack‑Funktion verwendet, bei der ein Element über ein anderes gesetzt wird, ohne Bruchstrich.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **Klasse MathRadical**
Die Klasse [**MathRadical**](https://reference.aspose.com/slides/java/com.aspose.slides/MathRadical) definiert die Wurzelfunktion, bestehend aus Basis und optionalem Grad.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **Klasse MathFunction**
Die Klasse [**MathFunction**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction) definiert eine Funktion mit Argument. Enthält die Eigenschaften [getName](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction#getName--) – Funktionsname – und [getBase](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction#getBase--) – Funktionsargument.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **Klasse MathNaryOperator**
Die Klasse [**MathNaryOperator**](https://reference.aspose.com/slides/java/com.aspose.slides/MathNaryOperator) definiert ein N‑äres mathematisches Objekt, wie Summation oder Integral. Sie besteht aus einem Operator, einer Basis (oder Operanden) und optionalen oberen und unteren Grenzen. Beispiele sind Summation, Vereinigung, Schnittmenge, Integral.

Einfachere Operatoren wie +, – usw. werden durch ein einzelnes Textelement – [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/MathematicalText) – dargestellt.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **Klasse MathLimit**
Die Klasse [**MathLimit**](https://reference.aspose.com/slides/java/com.aspose.slides/MathLimit) erzeugt obere oder untere Grenzen. Sie besteht aus Text auf der Grundlinie und verkleinertem Text darüber oder darunter. Das Element beinhaltet nicht das Wort „lim“, ermöglicht jedoch das Platzieren von Text über oder unter dem Ausdruck.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_8.png)

Wird mit einer Kombination aus [**MathFunction**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction) und [**MathLimit**](https://reference.aspose.com/slides/java/com.aspose.slides/MathLimit) wie folgt erstellt:

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));

MathFunction mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));
``` 

### **Klassen MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**
- [MathSubscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathLeftSubSuperscriptElement)

Diese Klassen definieren tief- bzw. hochgestellte Indizes. Man kann gleichzeitig tief- und hochgestellte Indizes links oder rechts setzen; ein einzelner Index wird nur rechts unterstützt. [MathSubscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSubscriptElement) kann zudem den mathematischen Grad einer Zahl festlegen.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **Klasse MathMatrix**
Die Klasse [**MathMatrix**](https://reference.aspose.com/slides/java/com.aspose.slides/MathMatrix) definiert ein Matrixobjekt, bestehend aus Kindelementen, die in Zeilen und Spalten angeordnet sind. Matrizen haben keine eingebauten Begrenzungszeichen; um sie in Klammern zu setzen, verwendet man das Objekt [**IMathDelimiter**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathDelimiter). Null‑Argumente erzeugen Lücken in Matrizen.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **Klasse MathArray**
Die Klasse [**MathArray**](https://reference.aspose.com/slides/java/com.aspose.slides/MathArray) definiert ein vertikales Array von Gleichungen oder anderen mathematischen Objekten.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **Formatierung mathematischer Elemente**
- [**MathBorderBox**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBorderBox): zeichnet einen rechteckigen oder anderen Rahmen um das [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement).

  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBox): definiert die logische Box‑Verpackung eines mathematischen Elements. Beispielsweise kann ein in eine Box eingeschlossenes Objekt als Operator‑Emulator mit bzw. ohne Ausrichtungspunkt dienen, als Zeilenumbruch‑Markierung oder gruppiert werden, um Zeilenumbrüche zu verhindern. Der Operator „==“ sollte z. B. boxed werden, um Zeilenumbrüche zu verhindern.

- [**MathDelimiter**](https://reference.aspose.com/slides/java/com.aspose.slides/MathDelimiter): definiert ein Begrenzungsobjekt mit öffnenden und schließenden Zeichen (Klammern, geschweiften Klammern, eckigen Klammern, senkrechten Strichen) und einem oder mehreren mathematischen Elementen darin, getrennt durch ein angegebenes Zeichen. Beispiele: (𝑥²); [𝑥²|𝑦²].

  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**](https://reference.aspose.com/slides/java/com.aspose.slides/MathAccent): definiert die Akzentfunktion mit Basis und kombinierendem Diakritikum.

  Beispiel: 𝑎́.

- [**MathBar**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBar): definiert die Balkenfunktion mit Basisargument und Ober‑ bzw. Unterbalken.

  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**](https://reference.aspose.com/slides/java/com.aspose.slides/MathGroupingCharacter): definiert ein Gruppierungszeichen über oder unter einem Ausdruck, meist zur Hervorhebung von Beziehungen zwischen Elementen.

  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **Mathematische Operationen**
Jedes mathematische Element und jeder mathematische Ausdruck (via [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock)) implementiert das Interface [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement). Damit können Sie Operationen auf der bestehenden Struktur ausführen und komplexere Ausdrücke erzeugen. Alle Operationen verfügen über zwei Parameter‑Sätze: entweder [**IMathElement**] oder einen String. Klassen wie [**MathematicalText**] werden implizit aus den angegebenen Strings erstellt, wenn String‑Argumente verwendet werden. Die in Aspose.Slides verfügbaren mathematischen Operationen sind unten aufgeführt.

### **Methode Join**
- [join(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#join-com.aspose.slides.IMathElement-)

Verbindet ein mathematisches Element und bildet einen mathematischen Block. Beispiel:

```java
IMathElement element1 = new MathematicalText("x");

IMathElement element2 = new MathematicalText("y");

IMathBlock block = element1.join(element2);
``` 

### **Methode Divide**
- [divide(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#divide-java.lang.String-)
- [divide(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-)
- [divide(String, MathFractionTypes)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#divide-java.lang.String-int-)
- [divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-int-)

Erzeugt einen Bruch des angegebenen Typs mit diesem Zähler und dem angegebenen Nenner. Beispiel:

```java
IMathElement numerator = new MathematicalText("x");

IMathFraction fraction = numerator.divide("y", MathFractionTypes.Linear);
``` 

### **Methode Enclose**
- [enclose()](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#enclose-char-char-)

Umfasst das Element mit angegebenen Zeichen, z. B. Klammern.

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

### **Methode Function**
- [function(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#function-java.lang.String-)
- [function(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#function-com.aspose.slides.IMathElement-)

Verwendet das aktuelle Objekt als Funktionsnamen.

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

### **Methode AsArgumentOfFunction**
- [asArgumentOfFunction(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-java.lang.String-)
- [asArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-int-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-int-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-int-java.lang.String-)

Verwendet das aktuelle Objekt als Argument einer Funktion. Sie können:

- Einen String als Funktionsnamen angeben, z. B. „cos“.
- Einen der vordefinierten Enum‑Werte [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunctionsOfOneArgument) oder [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunctionsOfTwoArguments) wählen, z. B. [**MathFunctionsOfOneArgument**](MathFunctionsOfOneArgument).[**ArcSin**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunctionsOfOneArgument#ArcSin).
- Eine Instanz von [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) verwenden.

Beispiel:

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));

IMathFunction func1 = new MathematicalText("2x").asArgumentOfFunction(funcName);

IMathFunction func2 = new MathematicalText("x").asArgumentOfFunction("sin");

IMathFunction func3 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfOneArgument.Sin);

IMathFunction func4 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfTwoArguments.Log, "3");
``` 

### **Methoden SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft**
- [setSubscript(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubscript-java.lang.String-)
- [setSubscript(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubscript-com.aspose.slides.IMathElement-)
- [setSuperscript(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSuperscript-java.lang.String-)
- [setSuperscript(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSuperscript-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)

Setzt tief‑ bzw. hochgestellte Indizes. Sie können gleichzeitig tief‑ und hochgestellte Indizes links oder rechts setzen; ein einzelner Index wird nur rechts unterstützt. Der **Superscript** kann zudem den mathematischen Grad einer Zahl festlegen.

Beispiel:

```java
IMathLeftSubSuperscriptElement script = new MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Methode Radical**
- [radical(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#radical-com.aspose.slides.IMathElement-)

Definiert die mathematische Wurzel des angegebenen Grades.

Beispiel:

```java
IMathRadical radical = new MathematicalText("x").radical("3");
``` 

### **Methoden SetUpperLimit und SetLowerLimit**
- [setUpperLimit(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setUpperLimit-com.aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setLowerLimit-com.aspose.slides.IMathElement-)

Setzt obere bzw. untere Grenzen.

Beispielausdruck:

![todo:image_alt_text](powerpoint-math-equations_8.png)

Solche Ausdrücke können durch Kombination der Klassen [MathFunction](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction) und [MathLimit](https://reference.aspose.com/slides/java/com.aspose.slides/MathLimit) sowie durch die Operationen des [IMathElement](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) erstellt werden:

```java
IMathFunction mathExpression = new MathematicalText("lim").setLowerLimit("x→∞").function("x");
``` 

### **Methoden Nary und Integral**
- [nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#nary-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-)
- [integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-int-)
- [integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-int-)

Beide Methoden erzeugen und geben einen N‑ären Operator des Typs [**IMathNaryOperator**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathNaryOperator) zurück. Der Parameter [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/java/com.aspose.slides/MathNaryOperatorTypes) bestimmt die Art des Operators (Summation, Union usw.), jedoch nicht Integrale. Für Integrale gibt es die Enumeration [**MathIntegralTypes**](https://reference.aspose.com/slides/java/com.aspose.slides/MathIntegralTypes).

Beispiel:

```java
IMathBlock baseArg = new MathematicalText("x").join(new MathematicalText("dx").toBox());

IMathNaryOperator integral = baseArg.integral(MathIntegralTypes.Simple, "0", "1");
``` 

### **Methode ToMathArray**
[**toMathArray**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#toMathArray--) legt Elemente in ein vertikales Array. Wird die Methode für ein [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock)-Objekt aufgerufen, werden alle Kindelemente in das zurückgegebene Array eingefügt.

Beispiel:

```java
IMathArray arrayFunction = new MathematicalText("x").join("y").toMathArray();
``` 

### **Formatierungsoperationen: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- **accent**: setzt ein Akzentzeichen (ein Zeichen über dem Element).
- **overbar** und **underbar**: setzen einen Balken oben bzw. unten.
- **group**: gruppiert Elemente mit einem Gruppierungszeichen (z. B. geschweifte Klammer unten).
- **toBorderBox**: legt das Element in einen Rand‑Box.
- **toBox**: legt das Element in eine nicht‑visuelle Box (logische Gruppierung).

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

Um eine mathematische Gleichung hinzuzufügen, erstellen Sie ein Math‑Shape‑Objekt, das automatisch einen mathematischen Abschnitt enthält. Anschließend holen Sie das [MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/) aus dem [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/) und fügen dort [MathBlock](https://reference.aspose.com/slides/java/com.aspose.slides/mathblock/)-Objekte hinzu.

**Ist es möglich, komplex verschachtelte mathematische Ausdrücke zu erstellen?**

Ja, Aspose.Slides ermöglicht das Erstellen komplexer verschachtelter mathematischer Ausdrücke durch Verschachteln von MathBlocks. Jedes mathematische Element implementiert das Interface [IMathElement](https://reference.aspose.com/slides/java/com.aspose.slides/imathelement/), wodurch Sie Operationen (Join, Divide, Enclose usw.) anwenden können, um Elemente zu komplexeren Strukturen zu kombinieren.

**Wie kann ich eine bestehende mathematische Gleichung aktualisieren oder ändern?**

Um eine Gleichung zu aktualisieren, greifen Sie über das [MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/) auf die vorhandenen MathBlocks zu. Durch Methoden wie Join, Divide, Enclose und andere können Sie einzelne Elemente der Gleichung ändern. Nach der Bearbeitung speichern Sie die Präsentation, um die Änderungen zu übernehmen.