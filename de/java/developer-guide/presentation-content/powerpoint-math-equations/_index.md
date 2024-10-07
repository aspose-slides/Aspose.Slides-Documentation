---
title: PowerPoint-Mathematikgleichungen
type: docs
weight: 80
url: /java/powerpoint-math-equations/
keywords: "PowerPoint-Mathematikgleichungen, PowerPoint-Mathematiksymbole, PowerPoint-Formel, PowerPoint-Mathematiktext"
description: "PowerPoint-Mathematikgleichungen, PowerPoint-Mathematiksymbole, PowerPoint-Formel, PowerPoint-Mathematiktext"
---

## **Übersicht**
In PowerPoint ist es möglich, eine Mathematikgleichung oder Formel zu schreiben und sie in der Präsentation anzuzeigen. Dazu werden verschiedene mathematische Symbole in PowerPoint dargestellt und können dem Text oder der Gleichung hinzugefügt werden. Dafür wird der Mathematikgleichungs-Konstruktor in PowerPoint verwendet, der hilft, komplexe Formeln zu erstellen wie:

- Mathematische Brüche
- Mathematische Wurzel
- Mathematische Funktion
- Grenzen und Logarithmusfunktionen
- N-ary Operationen
- Matrix
- Große Operatoren
- Sinus-, Kosinusfunktionen

Um eine mathematische Gleichung in PowerPoint hinzuzufügen, wird das Menü *Einfügen -> Gleichung* verwendet:

![todo:image_alt_text](powerpoint-math-equations_1.png)

Dies erstellt einen mathematischen Text in XML, der in PowerPoint wie folgt angezeigt werden kann: 

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint unterstützt viele mathematische Symbole zur Erstellung von Mathematikgleichungen. Die Erstellung komplizierter Mathematikgleichungen in PowerPoint liefert jedoch oft kein gutes und professionell aussehendes Ergebnis. Benutzer, die häufig mathematische Präsentationen erstellen müssen, greifen auf die Verwendung von Drittanbieterlösungen zurück, um ansprechend aussehende Mathematikformeln zu erstellen.

Mit der [**Aspose.Slide API**](https://products.aspose.com/slides/java/) können Sie programmatisch mit Mathematikgleichungen in PowerPoint-Präsentationen in C# arbeiten. Erstellen Sie neue Mathe-Ausdrücke oder bearbeiten Sie zuvor erstellte. Der Export von mathematischen Strukturen in Bilder wird ebenfalls teilweise unterstützt.

## **Wie man eine mathematische Gleichung erstellt**
Mathematische Elemente werden verwendet, um mathematische Konstruktionen beliebiger Verschachtelungstiefe zu erstellen. Eine lineare Sammlung von mathematischen Elementen bildet einen mathematischen Block, der durch die [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock) Klasse dargestellt wird. Die [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock) Klasse ist im Wesentlichen ein separierter mathematischer Ausdruck, Formel oder Gleichung. [**MathPortion**](https://reference.aspose.com/slides/java/com.aspose.slides/MathPortion) ist ein mathematischer Teil, der verwendet wird, um mathematischen Text zu halten (nicht mit [**Portion**](https://reference.aspose.com/slides/java/com.aspose.slides/Portion) zu verwechseln). [**MathParagraph**](https://reference.aspose.com/slides/java/com.aspose.slides/MathParagraph) ermöglicht das Manipulieren eines Satzes von Mathematikblöcken. Die oben genannten Klassen sind der Schlüssel zur Arbeit mit PowerPoint-Mathematikgleichungen über die Aspose.Slides API.

Sehen wir uns an, wie wir die folgende mathematische Gleichung über die Aspose.Slides API erstellen können:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Um einen mathematischen Ausdruck auf die Folie hinzuzufügen, fügen Sie zuerst eine Form hinzu, die den mathematischen Text enthält:

```java
Presentation pres = new Presentation();
try {
    IAutoShape mathShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 720, 150);
} finally {
    if (pres != null) pres.dispose();
}
``` 

Nach der Erstellung enthält die Form standardmäßig bereits einen Absatz mit einem mathematischen Teil. Die [**MathPortion**](https://reference.aspose.com/slides/java/com.aspose.slides/MathPortion) Klasse ist ein Teil, der einen mathematischen Text enthält. Um auf den mathematischen Inhalt innerhalb der [**MathPortion**](https://reference.aspose.com/slides/java/com.aspose.slides/MathPortion) zuzugreifen, verweisen Sie auf die [**MathParagraph**](https://reference.aspose.com/slides/java/com.aspose.slides/MathParagraph) Variable:

```java
IMathParagraph mathParagraph = ((MathPortion)mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();
``` 

Die [**MathParagraph**](https://reference.aspose.com/slides/java/com.aspose.slides/MathParagraph) Klasse ermöglicht das Lesen, Hinzufügen, Bearbeiten und Löschen von Mathematikblöcken ([**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock)), die aus einer Kombination von mathematischen Elementen bestehen. Zum Beispiel, erstellen Sie einen Bruch und platzieren Sie ihn in der Präsentation:

```java
IMathFraction fraction = new MathematicalText("x").divide("y");

mathParagraph.add(new MathBlock(fraction));
``` 

Jedes mathematische Element wird durch eine Klasse dargestellt, die das [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) Interface implementiert. Dieses Interface bietet viele Methoden zum einfachen Erstellen mathematischer Ausdrücke. Sie können mit einer einzigen Codezeile einen ziemlich komplexen mathematischen Ausdruck erstellen. Zum Beispiel würde der Satz des Pythagoras so aussehen:

```java
IMathBlock mathBlock = new MathematicalText("c")
        .setSuperscript("2")
        .join("=")
        .join(new MathematicalText("a").setSuperscript("2"))
        .join("+")
        .join(new MathematicalText("b").setSuperscript("2"));
``` 

Die Vorgänge des [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) Interfaces sind in jedem Typ von Element implementiert, einschließlich des [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock).

Das vollständige Beispiel des Quellcodes:

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
Mathematische Ausdrücke werden aus Sequenzen mathematischer Elemente gebildet. Die Sequenz mathematischer Elemente wird durch einen mathematischen Block dargestellt, und die Argumente der mathematischen Elemente bilden eine baumartige Verschachtelung.

Es gibt viele mathematische Elementtypen, die verwendet werden können, um einen mathematischen Block zu konstruieren. Jedes dieser Elemente kann in einem anderen Element enthalten (aggregiert) werden. Das heißt, Elemente sind tatsächlich Container für andere, die eine baumartige Struktur bilden. Der einfachste Elementtyp enthält keine anderen Elemente des mathematischen Textes.

Jeder Typ von Mathe-Element implementiert das [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) Interface, das die Verwendung der gemeinsamen Menge von Matheoperationen auf verschiedenen Typen von Matheelementen ermöglicht.
### **MathText Klasse**
Die [**MathematicalText**](https://reference.aspose.com/slides/java/com.aspose.slides/MathematicalText) Klasse repräsentiert einen mathematischen Text - das zugrunde liegende Element aller mathematischen Konstruktionen. Mathematischer Text kann Operanden und Operatoren, Variablen und jeden anderen linearen Text darstellen.

Beispiel: 𝑎=𝑏+𝑐
### **MathFraction Klasse**
Die [**MathFraction**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFraction) Klasse spezifiziert das Bruchobjekt, das aus einem Zähler und einem Nenner besteht, die durch einen Bruchstrich getrennt sind. Der Bruchstrich kann horizontal oder diagonal sein, abhängig von den Eigenschaften des Bruchs. Das Bruchobjekt wird auch verwendet, um die Stapelfunktion darzustellen, die ein Element über ein anderes legt, ohne Bruchstrich.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **MathRadical Klasse**
Die [**MathRadical**](https://reference.aspose.com/slides/java/com.aspose.slides/MathRadical) Klasse spezifiziert die radikale Funktion (mathematische Wurzel), die aus einer Basis und einem optionalen Grad besteht.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **MathFunction Klasse**
Die [**MathFunction**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction) Klasse spezifiziert eine Funktion eines Arguments. Sie enthält die Eigenschaften: [getName](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction#getName--) - Funktionsname und [getBase](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction#getBase--) - Funktionsargument.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **MathNaryOperator Klasse**
Die [**MathNaryOperator**](https://reference.aspose.com/slides/java/com.aspose.slides/MathNaryOperator) Klasse spezifiziert ein N-ary mathematisches Objekt, wie Summation und Integral. Sie besteht aus einem Operator, einer Basis (oder Operand) und optionalen oberen und unteren Grenzen. Beispiele für N-ary Operatoren sind Summation, Vereinigung, Schnittmenge, Integral.

Diese Klasse umfasst keine einfachen Operatoren wie Addition, Subtraktion usw. Diese werden durch ein einzelnes Textelement - [MathematicalText](https://reference.aspose.com/slides/java/com.aspose.slides/MathematicalText) dargestellt.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **MathLimit Klasse**
Die [**MathLimit**](https://reference.aspose.com/slides/java/com.aspose.slides/MathLimit) Klasse erstellt die obere oder untere Grenze. Sie spezifiziert das Grenzobjekt, das aus Text auf der Basislinie und Text in reduzierter Größe direkt darüber oder darunter besteht. Dieses Element umfasst nicht das Wort „lim“, ermöglicht jedoch das Platzieren von Text oben oder unten in dem Ausdruck. So wird der Ausdruck 

![todo:image_alt_text](powerpoint-math-equations_8.png)

durch eine Kombination von [**MathFunction**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction) und [**MathLimit**](https://reference.aspose.com/slides/java/com.aspose.slides/MathLimit) Elementen auf folgende Weise erstellt:

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));

MathFunction mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));
``` 


### **MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement Klassen**
- [MathSubscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathLeftSubSuperscriptElement)

Die folgenden Klassen spezifizieren einen tiefen oder einen hohen Index. Sie können Subskript und Superskript gleichzeitig auf der linken oder rechten Seite eines Arguments festlegen, aber einzelnes Subskript oder Superskript wird nur auf der rechten Seite unterstützt. Das [MathSubscriptElement](https://reference.aspose.com/slides/java/com.aspose.slides/MathSubscriptElement) kann auch verwendet werden, um den mathematischen Grad einer Zahl festzulegen.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **MathMatrix Klasse**
Die [**MathMatrix**](https://reference.aspose.com/slides/java/com.aspose.slides/MathMatrix) Klasse spezifiziert das Matrixobjekt, das aus untergeordneten Elementen besteht, die in einer oder mehreren Reihen und Spalten angeordnet sind. Es ist wichtig zu beachten, dass Matrizen keine eingebauten Trennzeichen haben. Um die Matrix in Klammern zu setzen, sollten Sie das Trennzeichenobjekt - [**IMathDelimiter**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathDelimiter) verwenden. Nullargumente können verwendet werden, um Lücken in Matrizen zu erstellen.

Beispiel: 

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **MathArray Klasse**
Die [**MathArray**](https://reference.aspose.com/slides/java/com.aspose.slides/MathArray) Klasse spezifiziert ein vertikales Array von Gleichungen oder anderen mathematischen Objekten.

Beispiel: 

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **Formatierung mathematischer Elemente**
- [**MathBorderBox**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBorderBox) Klasse: zeichnet einen rechteckigen oder anderen Rand um das [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement).
  
  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- [**MathBox**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBox) Klasse: spezifiziert das logische Verpacken (Packaging) des mathematischen Elements. Ein verpacktes Objekt kann zum Beispiel als Operator-Emulator mit oder ohne Ausrichtungspunkt dienen, als Zeilenumbruch dienen oder so gruppiert werden, dass innerhalb von ihm keine Zeilenumbrüche zugelassen werden. Zum Beispiel sollte der „==“ Operator verpackt werden, um Zeilenumbrüche zu verhindern.
- [**MathDelimiter**](https://reference.aspose.com/slides/java/com.aspose.slides/MathDelimiter) Klasse: spezifiziert das Trennzeichenobjekt, das aus öffnenden und schließenden Zeichen (wie Klammern, geschweifte Klammern, eckige Klammern und senkrechte Striche) besteht, und einem oder mehreren mathematischen Elementen, die durch ein angegebenes Zeichen getrennt sind. Beispiele: (𝑥2); [𝑥2|𝑦2].
  
  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- [**MathAccent**](https://reference.aspose.com/slides/java/com.aspose.slides/MathAccent) Klasse: spezifiziert die Akzentfunktion, die aus einer Basis und einem kombinierten diakritischen Zeichen besteht. 

  Beispiel: 𝑎́.

- [**MathBar**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBar) Klasse: spezifiziert die Balkenfunktion, die aus einem Basisargument und einem Überstrich oder Unterstrich besteht.
  
  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- [**MathGroupingCharacter**](https://reference.aspose.com/slides/java/com.aspose.slides/MathGroupingCharacter) Klasse: spezifiziert ein Gruppierungszeichen über oder unter einem Ausdruck, normalerweise um die Beziehungen zwischen den Elementen hervorzuheben.
  
  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **Mathematische Operationen**
Jedes mathematische Element und mathematische Ausdruck (über [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock)) implementiert das [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) Interface. Es ermöglicht Ihnen, Operationen auf der bestehenden Struktur durchzuführen und komplexere mathematische Ausdrücke zu bilden. Alle Operationen haben zwei Parametersets: entweder [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) oder String als Argumente. Instanzen der Klasse [**MathematicalText**](https://reference.aspose.com/slides/java/com.aspose.slides/MathematicalText) werden implizit aus den angegebenen Strings erstellt, wenn String-Argumente verwendet werden. Matheoperationen, die in Aspose.Slides verfügbar sind, sind unten aufgeführt.
### **Join Methode**
- [join(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#join-com.aspose.slides.IMathElement-)

Verbindet ein mathematisches Element und bildet einen mathematischen Block. Zum Beispiel:

```java
IMathElement element1 = new MathematicalText("x");

IMathElement element2 = new MathematicalText("y");

IMathBlock block = element1.join(element2);
``` 

### **Divide Methode**
- [divide(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#divide-java.lang.String-)
- [divide(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-)
- [divide(String, MathFractionTypes)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#divide-java.lang.String-int-)
- [divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-int-)

Erstellt einen Bruch des angegebenen Typs mit diesem Zähler und dem angegebenen Nenner. Zum Beispiel:

```java
IMathElement numerator = new MathematicalText("x");

IMathFraction fraction = numerator.divide("y", MathFractionTypes.Linear);
``` 

### **Enclose Methode**
- [enclose()](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#enclose-char-char-)

Schließt das Element in den angegebenen Zeichen wie Klammern oder ein anderes Zeichen als Rahmen ein.

```java
/**
 * <p>
 * Schließt ein mathematisches Element in Klammern ein
 * </p>
 */
public IMathDelimiter enclose();

/**
 * <p>
 * Schließt dieses Element in den angegebenen Zeichen wie Klammern oder andere Zeichen als Rahmen ein
 * </p>
 */
public IMathDelimiter enclose(char beginningCharacter, char endingCharacter);
``` 


Beispiel:

```java
IMathDelimiter delimiter = new MathematicalText("x").enclose('[', ']');

IMathDelimiter delimiter2 = new MathematicalText("elem1").join("elem2").enclose();
``` 

### **Function Methode**
- [function(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#function-java.lang.String-)
- [function(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#function-com.aspose.slides.IMathElement-)

Nimmt eine Funktion eines Arguments, wobei das aktuelle Objekt als Funktionsname verwendet wird.

```java
/**
 * <p>
 * Nimmt eine Funktion eines Arguments, wobei diese Instanz als Funktionsname verwendet wird
 * </p>
 */
public IMathFunction function(IMathElement functionArgument);

/**
 * <p>
 * Nimmt eine Funktion eines Arguments, wobei diese Instanz als Funktionsname verwendet wird
 * </p>
 */
public IMathFunction function(String functionArgument);
``` 


Beispiel:

```java
IMathFunction func = new MathematicalText("sin").function("x");
``` 

### **AsArgumentOfFunction Methode**
- [asArgumentOfFunction(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-java.lang.String-)
- [asArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-int-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-int-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#asArgumentOfFunction-int-java.lang.String-)

Nimmt die angegebene Funktion unter Verwendung der aktuellen Instanz als Argument. Sie können:

- einen String als Funktionsnamen angeben, zum Beispiel „cos“.
- einen der vordefinierten Werte der Aufzählungen [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunctionsOfOneArgument) oder [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunctionsOfTwoArguments) auswählen, zum Beispiel [**MathFunctionsOfOneArgument**](MathFunctionsOfOneArgument).[**ArcSin**](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunctionsOfOneArgument#ArcSin).
- die Instanz des [**IMathElement**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) auswählen.

Beispiel:

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));

IMathFunction func1 = new MathematicalText("2x").asArgumentOfFunction(funcName);

IMathFunction func2 = new MathematicalText("x").asArgumentOfFunction("sin");

IMathFunction func3 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfOneArgument.Sin);

IMathFunction func4 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfTwoArguments.Log, "3");
``` 

### **SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft Methoden**
- [setSubscript(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubscript-java.lang.String-)
- [setSubscript(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubscript-com.aspose.slides.IMathElement-)
- [setSuperscript(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSuperscript-java.lang.String-)
- [setSuperscript(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSuperscript-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)

Setzt Subskript und Superskript. Sie können Subskript und Superskript gleichzeitig auf der linken oder rechten Seite des Arguments setzen, aber einzelnes Subskript oder Superskript wird nur auf der rechten Seite unterstützt. Das **Superskript** kann auch verwendet werden, um den mathematischen Grad einer Zahl festzulegen.

Beispiel:

```java
IMathLeftSubSuperscriptElement script = new MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Radical Methode**
- [radical(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#radical-com.aspose.slides.IMathElement-)

Spezifiziert die mathematische Wurzel des gegebenen Grades aus dem angegebenen Argument.

Beispiel:

```java
IMathRadical radical = new MathematicalText("x").radical("3");
``` 

### **SetUpperLimit und SetLowerLimit Methoden**
- [setUpperLimit(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setUpperLimit-com.aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#setLowerLimit-com.aspose.slides.IMathElement-)

Nimmt die obere oder untere Grenze. Hier zeigen die oberen und unteren einfach die Position des Arguments relativ zur Basis an.

Lassen Sie uns einen Ausdruck betrachten: 

![todo:image_alt_text](powerpoint-math-equations_8.png)

Solche Ausdrücke können durch eine Kombination von [MathFunction](https://reference.aspose.com/slides/java/com.aspose.slides/MathFunction) und [MathLimit](https://reference.aspose.com/slides/java/com.aspose.slides/MathLimit) Klassen und den Operationen des [IMathElement](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement) wie folgt erstellt werden:

```java
IMathFunction mathExpression = new MathematicalText("lim").setLowerLimit("x→∞").function("x");
``` 

### **Nary und Integral Methoden**
- [nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#nary-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-)
- [integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-int-)
- [integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-int-)

Sowohl die **nary**- als auch die **integral**-Methoden erstellen und geben den N-ary Operator vom Typ [**IMathNaryOperator**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathNaryOperator) zurück. In der nary-Methode spezifiziert die [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/java/com.aspose.slides/MathNaryOperatorTypes) Aufzählung den Typ des Operators: Summation, Vereinigung usw., ohne Integrale einzuschließen. In der Integral-Methode gibt es den spezialisierten Vorgang Integral mit der Aufzählung von Integraltypen [**MathIntegralTypes**](https://reference.aspose.com/slides/java/com.aspose.slides/MathIntegralTypes). 

Beispiel:

```java
IMathBlock baseArg = new MathematicalText("x").join(new MathematicalText("dx").toBox());

IMathNaryOperator integral = baseArg.integral(MathIntegralTypes.Simple, "0", "1");
``` 

### **ToMathArray Methode**
[**toMathArray**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#toMathArray--) platziert Elemente in einem vertikalen Array. Wenn diese Operation für eine [**MathBlock**](https://reference.aspose.com/slides/java/com.aspose.slides/MathBlock) Instanz aufgerufen wird, werden alle untergeordneten Elemente im zurückgegebenen Array platziert.

Beispiel:

```java
IMathArray arrayFunction = new MathematicalText("x").join("y").toMathArray();
``` 

### **Formatierungsoperationen: Akzent, Überstrich, Unterstrich, Gruppe, ZuBorderBox, ZuBox**
- [**accent**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#accent-char-) Methode setzt ein Akzentzeichen (ein Zeichen auf dem oberen Ende des Elements).
- [**overbar**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#overbar--) und [**underbar**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#underbar--) Methoden setzen eine Linie oben oder unten.
- [**group**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#group--) Methode platziert in einer Gruppe unter Verwendung eines Gruppierungszeichens wie einer unteren geschweiften Klammer oder einer anderen.
- [**toBorderBox**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#toBorderBox--) Methode platziert in einer Rahmenbox.
- [**toBox**](https://reference.aspose.com/slides/java/com.aspose.slides/IMathElement#toBox--) Methode platziert in einer unsichtbaren Box (logische Gruppierung).

Beispiele:

```java
IMathAccent accent = new MathematicalText("x").accent('\u0303');

IMathBar bar = new MathematicalText("x").overbar();

IMathGroupingCharacter groupChr = new MathematicalText("x").join("y").join("z").group('\u23E1', MathTopBotPositions.Bottom, MathTopBotPositions.Top);

IMathBorderBox borderBox = new MathematicalText("x+y+z").toBorderBox();

IMathBox boxedOperator = new MathematicalText(":=").toBox();
``` 