---
title: PowerPoint Math-Gleichungen
type: docs
weight: 80
url: /de/androidjava/powerpoint-math-equations/
keywords: " PowerPoint Math-Gleichungen, PowerPoint Math-Symbole, PowerPoint Formel, PowerPoint Math-Text"
description: "PowerPoint Math-Gleichungen, PowerPoint Math-Symbole, PowerPoint Formel, PowerPoint Math-Text"
---

## **Überblick**
In PowerPoint ist es möglich, eine mathematische Gleichung oder Formel zu schreiben und sie in der Präsentation darzustellen. Dazu werden verschiedene mathematische Symbole in PowerPoint repräsentiert und können dem Text oder der Gleichung hinzugefügt werden. Dafür wird der Konstruktor für mathematische Gleichungen in PowerPoint verwendet, der hilft, komplexe Formeln wie:

- Mathematische Brüche
- Mathematische Wurzeln
- Mathematische Funktionen
- Grenzwerte und logarithmische Funktionen
- N-äre Operationen
- Matrizen
- Große Operatoren
- Sinus-, Cosinusfunktionen

Um eine mathematische Gleichung in PowerPoint hinzuzufügen, wird das Menü *Einfügen -> Gleichung* verwendet:

![todo:image_alt_text](powerpoint-math-equations_1.png)

Dies erstellt einen matematischen Text in XML, der in PowerPoint wie folgt angezeigt werden kann:

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint unterstützt zahlreiche mathematische Symbole zur Erstellung von mathematischen Gleichungen. Das Erstellen komplizierter mathematischer Gleichungen in PowerPoint führt jedoch oft nicht zu einem guten und professionell aussehenden Ergebnis. Benutzer, die häufig mathematische Präsentationen erstellen müssen, greifen auf Drittanbieter-Lösungen zurück, um ansprechend aussehende mathematische Formeln zu erstellen.

Mit der [**Aspose.Slide API**](https://products.aspose.com/slides/androidjava/) können Sie programmgesteuert in C# mit mathematischen Gleichungen in PowerPoint-Präsentationen arbeiten. Erstellen Sie neue mathematische Ausdrücke oder bearbeiten Sie zuvor erstellte. Der Export mathematischer Strukturen in Bilder wird ebenfalls teilweise unterstützt.


## **So erstellen Sie eine mathematische Gleichung**
Mathematische Elemente werden zum Erstellen beliebiger mathematischer Konstruktionen mit jeder Verschachtelungsebene verwendet. Eine lineare Sammlung mathematischer Elemente bildet einen mathematischen Block, der durch die [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock)-Klasse repräsentiert wird. Die [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock)-Klasse ist im Wesentlichen ein separates mathematisches Ausdruck, Formel oder Gleichung. **[MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion)** ist ein mathematischer Anteil, der dazu verwendet wird, mathematischen Text zu halten (nicht zu verwechseln mit [**Portion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Portion)). Die [**MathParagraph**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph)-Klasse ermöglicht die Manipulation einer Menge von Mathematikblöcken. Die oben genannten Klassen sind der Schlüssel zur Arbeit mit mathematischen Gleichungen in PowerPoint über die Aspose.Slides API.

Sehen wir uns an, wie wir die folgende mathematische Gleichung über die Aspose.Slides API erstellen können:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Um einen mathematischen Ausdruck auf der Folie hinzuzufügen, fügen Sie zuerst eine Form hinzu, die den mathematischen Text enthalten wird:

```java
Presentation pres = new Presentation();
try {
    IAutoShape mathShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 720, 150);
} finally {
    if (pres != null) pres.dispose();
}
``` 

Nach der Erstellung wird die Form standardmäßig bereits einen Absatz mit einem mathematischen Anteil enthalten. Die [**MathPortion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion)-Klasse ist ein Anteil, der einen mathematischen Text enthält. Um auf den mathematischen Inhalt in der [**MathPortion**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathPortion) zuzugreifen, verweisen Sie auf die [**MathParagraph**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph)-Variable:

```java
IMathParagraph mathParagraph = ((MathPortion)mathShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)).getMathParagraph();
``` 

Die [**MathParagraph**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathParagraph)-Klasse ermöglicht das Lesen, Hinzufügen, Bearbeiten und Löschen von Mathematikblöcken ([**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock)), die aus einer Kombination von mathematischen Elementen bestehen. Erstellen Sie beispielsweise einen Bruch und platzieren Sie ihn in der Präsentation:

```java
IMathFraction fraction = new MathematicalText("x").divide("y");

mathParagraph.add(new MathBlock(fraction));
``` 

Jedes mathematische Element wird durch eine Klasse dargestellt, die das [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement)-Interface implementiert. Dieses Interface bietet viele Methoden zum einfachen Erstellen mathematischer Ausdrücke. Sie können mit einer einzigen Zeile Code einen ziemlich komplexen mathematischen Ausdruck erstellen. Zum Beispiel würde der Satz des Pythagoras so aussehen:

```java
IMathBlock mathBlock = new MathematicalText("c")
        .setSuperscript("2")
        .join("=")
        .join(new MathematicalText("a").setSuperscript("2"))
        .join("+")
        .join(new MathematicalText("b").setSuperscript("2"));
``` 

Die Operationen des [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement)-Interfaces sind in jedem Elementtyp implementiert, einschließlich des [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock).

Das vollständige Quellcode-Beispiel:

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
Mathematische Ausdrücke werden aus Sequenzen mathematischer Elemente gebildet. Die Sequenz mathematischer Elemente wird durch einen mathematischen Block dargestellt, und die Argumente der mathematischen Elemente bilden eine baumartige Verschachtelung.

Es gibt viele Arten von mathematischen Elementen, die zur Konstruktion eines mathematischen Blocks verwendet werden können. Jedes dieser Elemente kann in ein anderes Element aufgenommen (aggregiert) werden. Das heißt, Elemente sind tatsächlich Container für andere und bilden eine baumartige Struktur. Der einfachste Elementtyp enthält keine anderen Elemente des mathematischen Textes.

Jeder Typ eines mathematischen Elements implementiert das [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement)-Interface, das die Verwendung eines gemeinsamen Satzes von mathematischen Operationen auf verschiedenen Typen von mathematischen Elementen ermöglicht.
### **MathematicalText-Klasse**
Die [**MathematicalText**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathematicalText)-Klasse repräsentiert einen mathematischen Text - das zugrunde liegende Element aller mathematischen Konstruktionen. Mathematischer Text kann Operanden und Operatoren, Variablen und jeden anderen linearen Text darstellen.

Beispiel: 𝑎=𝑏+𝑐
### **MathFraction-Klasse**
Die [**MathFraction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFraction)-Klasse spezifiziert das Bruchobjekt, das aus einem Zähler und einem Nenner besteht, die durch eine Bruchlinie getrennt sind. Die Bruchlinie kann horizontal oder schräg sein, je nach Bruchteilen. Das Bruchobjekt wird auch verwendet, um die Stapel-Funktion darzustellen, die ein Element über einem anderen anordnet, ohne Bruchlinie.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **MathRadical-Klasse**
Die [**MathRadical**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathRadical)-Klasse spezifiziert die radikale Funktion (mathematische Wurzel), bestehend aus einer Basis und einem optionalen Grad.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **MathFunction-Klasse**
Die [**MathFunction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction)-Klasse spezifiziert eine Funktion eines Arguments. Enthält Eigenschaften: [getName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction#getName--) - Funktionsname und [getBase](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction#getBase--) - Funktion Argument.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **MathNaryOperator-Klasse**
Die [**MathNaryOperator**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathNaryOperator)-Klasse spezifiziert ein N-äres mathematisches Objekt, wie Summation und Integral. Es besteht aus einem Operator, einer Basis (oder Operand) und optionalen oberen und unteren Grenzen. Beispiele für N-äre Operatoren sind Summation, Vereinigung, Schnittmenge, Integral.

Diese Klasse enthält keine einfachen Operatoren wie Addition, Subtraktion usw. Sie werden durch ein einzelnes Textelement - [MathematicalText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathematicalText) dargestellt.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **MathLimit-Klasse**
Die [**MathLimit**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLimit)-Klasse erstellt die obere oder untere Grenze. Sie spezifiziert das Grenzwertobjekt, das aus Text auf der Basislinie und sofort darüber oder darunter reduziertem Text besteht. Dieses Element beinhaltet nicht das Wort „lim“, erlaubt jedoch die Platzierung von Text an der Ober- oder Unterseite des Ausdrucks. So wird der Ausdruck 

![todo:image_alt_text](powerpoint-math-equations_8.png)

mit einer Kombination aus [**MathFunction**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction) und [**MathLimit**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLimit)-Elementen so erstellt:

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));

MathFunction mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));
``` 


### **MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement-Klassen**
- [MathSubscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSubscriptElement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSuperscriptElement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathRightSubSuperscriptElement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLeftSubSuperscriptElement)

Die folgenden Klassen spezifizieren einen tiefen Index oder einen oberen Index. Sie können gleichzeitig Subscript und Superscript auf der linken oder rechten Seite eines Arguments setzen, aber ein einzelnes Subscript oder Superscript wird nur auf der rechten Seite unterstützt. Der [MathSubscriptElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathSubscriptElement) kann auch verwendet werden, um den mathematischen Grad einer Zahl zu setzen.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **MathMatrix-Klasse**
Die [**MathMatrix**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathMatrix)-Klasse spezifiziert das Matrixobjekt, das aus untergeordneten Elementen besteht, die in einer oder mehreren Zeilen und Spalten angeordnet sind. Es ist wichtig zu beachten, dass Matrizen keine eingebauten Trennsymbole haben. Um die Matrix in Klammern zu setzen, sollten Sie das Trennzeichenobjekt - [**IMathDelimiter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathDelimiter) - verwenden. Null-Argumente können verwendet werden, um Lücken in Matrizen zu erstellen.

Beispiel: 

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **MathArray-Klasse**
Die [**MathArray**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathArray)-Klasse spezifiziert ein vertikales Array von Gleichungen oder beliebigen mathematischen Objekten.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **Formatierung mathematischer Elemente**
- Die [**MathBorderBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBorderBox)-Klasse: Zeichnet einen rechteckigen oder einen anderen Rahmen um das [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement).
  
  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- Die [**MathBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBox)-Klasse: Spezifiziert das logische Boxen (Verpacken) des mathematischen Elements. Beispielsweise kann ein eingekästetes Objekt als Operator-Emulator mit oder ohne Ausrichtungspunkt dienen, als Zeilenumbruch dienen oder so gruppiert werden, dass Zeilenumbrüche innerhalb nicht erlaubt sind. Beispielsweise sollte der "==" Operator eingekästet werden, um Zeilenumbrüche zu verhindern.
- Die [**MathDelimiter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathDelimiter)-Klasse: Spezifiziert das Trennobjekt, das aus öffnenden und schließenden Zeichen (wie Klammern, geschweifte Klammern, eckige Klammern und senkrechte Striche) besteht und ein oder mehrere mathematische Elemente innerhalb enthält, die durch ein angegebenes Zeichen getrennt sind. Beispiele: (𝑥2); [𝑥2|𝑦2].
  
  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- Die [**MathAccent**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathAccent)-Klasse: Spezifiziert die Akzentfunktion, die aus einer Basis und einem kombinierten diakritischen Zeichen besteht.

  Beispiel: 𝑎́.

- Die [**MathBar**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBar)-Klasse: Spezifiziert die Linienfunktion, die aus einem Basisargument und einem Über- oder Unterstrich besteht.
  
  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- Die [**MathGroupingCharacter**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathGroupingCharacter)-Klasse: Spezifiziert ein Gruppierungssymbol über oder unter einem Ausdruck, um normalerweise die Beziehungen zwischen den Elementen hervorzuheben.
  
  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_15.png)


## **Mathematische Operationen**
Jedes mathematische Element und jede mathematische Ausdruck (via [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock)) implementiert das [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement)-Interface. Es ermöglicht Ihnen, Operationen auf der vorhandenen Struktur zu verwenden und komplexere mathematische Ausdrücke zu bilden. Alle Operationen haben zwei Parametersätze: entweder [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement) oder string als Argumente. Instanzen der [**MathematicalText**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathematicalText)-Klasse werden implizit aus angegebenen Zeichenfolgen erstellt, wenn Zeichenfolgenargumente verwendet werden. Die in Aspose.Slides verfügbaren mathematischen Operationen sind unten aufgeführt.
### **Join-Methode**
- [join(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#join-java.lang.String-)
- [join(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#join-com.aspose.slides.IMathElement-)

Verbindet ein mathematisches Element und bildet einen mathematischen Block. Zum Beispiel:

```java
IMathElement element1 = new MathematicalText("x");

IMathElement element2 = new MathematicalText("y");

IMathBlock block = element1.join(element2);
``` 

### **Divide-Methode**
- [divide(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#divide-java.lang.String-)
- [divide(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-)
- [divide(String, MathFractionTypes)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#divide-java.lang.String-int-)
- [divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#divide-com.aspose.slides.IMathElement-int-)

Erstellt einen Bruch des angegebenen Typs mit diesem Zähler und dem angegebenen Nenner. Zum Beispiel:

```java
IMathElement numerator = new MathematicalText("x");

IMathFraction fraction = numerator.divide("y", MathFractionTypes.Linear);
``` 

### **Enclose-Methode**
- [enclose()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#enclose--)
- [enclose(Char, Char)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#enclose-char-char-)

Schließt das Element in angegebenen Zeichen wie Klammern oder einem anderen Zeichen als Rahmen ein.

```java
/**
 * <p>
 * Schließt ein mathe Element in Klammern ein
 * </p>
 */
public IMathDelimiter enclose();

/**
 * <p>
 * Schließt dieses Element in angegebenen Zeichen wie Klammern oder anderen Zeichen als Rahmen ein
 * </p>
 */
public IMathDelimiter enclose(char beginningCharacter, char endingCharacter);
``` 


Zum Beispiel:

```java
IMathDelimiter delimiter = new MathematicalText("x").enclose('[', ']');

IMathDelimiter delimiter2 = new MathematicalText("elem1").join("elem2").enclose();
``` 

### **Function-Methode**
- [function(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#function-java.lang.String-)
- [function(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#function-com.aspose.slides.IMathElement-)

Nimmt eine Funktion eines Arguments unter Verwendung des aktuellen Objekts als Funktionsnamen.

```java
/**
 * <p>
 * Nimmt eine Funktion eines Arguments und verwendet diese Instanz als Funktionsnamen
 * </p>
 */
public IMathFunction function(IMathElement functionArgument);

/**
 * <p>
 * Nimmt eine Funktion eines Arguments und verwendet diese Instanz als Funktionsnamen
 * </p>
 */
public IMathFunction function(String functionArgument);
``` 


Zum Beispiel:

```java
IMathFunction func = new MathematicalText("sin").function("x");
``` 

### **AsArgumentOfFunction-Methode**
- [asArgumentOfFunction(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-java.lang.String-)
- [asArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-int-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-int-com.aspose.slides.IMathElement-)
- [asArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#asArgumentOfFunction-int-java.lang.String-)

Nimmt die angegebene Funktion, indem die aktuelle Instanz als Argument verwendet wird. Sie können:

- eine Zeichenfolge als Funktionsnamen angeben, z.B. „cos“.
- einen der vordefinierten Werte der Enumerationen [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfOneArgument) oder [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfTwoArguments) auswählen, z.B. [**MathFunctionsOfOneArgument**](MathFunctionsOfOneArgument).[**ArcSin**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunctionsOfOneArgument#ArcSin).
- die Instanz des [**IMathElement**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement) auswählen.

Zum Beispiel:

```java
MathLimit funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));

IMathFunction func1 = new MathematicalText("2x").asArgumentOfFunction(funcName);

IMathFunction func2 = new MathematicalText("x").asArgumentOfFunction("sin");

IMathFunction func3 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfOneArgument.Sin);

IMathFunction func4 = new MathematicalText("x").asArgumentOfFunction(MathFunctionsOfTwoArguments.Log, "3");
``` 

### **SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft-Methoden**
- [setSubscript(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubscript-java.lang.String-)
- [setSubscript(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubscript-com.aspose.slides.IMathElement-)
- [setSuperscript(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSuperscript-java.lang.String-)
- [setSuperscript(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSuperscript-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubSuperscriptOnTheRight-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [setSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-java.lang.String-java.lang.String-)
- [setSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setSubSuperscriptOnTheLeft-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)

Setzt Subscript und Superscript. Sie können Subscript und Superscript gleichzeitig auf der linken oder rechten Seite des Arguments setzen, aber ein einzelnes Subscript oder Superscript wird nur auf der rechten Seite unterstützt. Das **Superscript** kann auch verwendet werden, um den mathematischen Grad einer Zahl zu setzen.

Beispiel:

```java
IMathLeftSubSuperscriptElement script = new MathematicalText("y").setSubSuperscriptOnTheLeft("2x", "3z");
``` 

### **Radical-Methode**
- [radical(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#radical-java.lang.String-)
- [radical(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#radical-com.aspose.slides.IMathElement-)

Spezifiziert die mathematische Wurzel des gegebenen Grades des angegebenen Arguments.

Beispiel:

```java
IMathRadical radical = new MathematicalText("x").radical("3");
``` 

### **SetUpperLimit und SetLowerLimit-Methoden**
- [setUpperLimit(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setUpperLimit-java.lang.String-)
- [setUpperLimit(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setUpperLimit-com.aspose.slides.IMathElement-)
- [setLowerLimit(String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setLowerLimit-java.lang.String-)
- [setLowerLimit(IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#setLowerLimit-com.aspose.slides.IMathElement-)

Nimmt die obere oder untere Grenze. Hier zeigen der obere und der untere Wert einfach die Position des Arguments relativ zur Basis an.

Betrachten wir einen Ausdruck: 

![todo:image_alt_text](powerpoint-math-equations_8.png)

Solche Ausdrücke können durch eine Kombination aus den Klassen [MathFunction](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathFunction) und [MathLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathLimit) sowie den Operationen des [IMathElement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement) wie folgt erstellt werden:

```java
IMathFunction mathExpression = new MathematicalText("lim").setLowerLimit("x→∞").function("x");
``` 

### **Nary- und Integral-Methoden**
- [nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#nary-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#nary-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-)
- [integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-)
- [integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-)
- [integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-com.aspose.slides.IMathElement-com.aspose.slides.IMathElement-int-)
- [integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#integral-int-java.lang.String-java.lang.String-int-)

Sowohl die **nary**- als auch die **integral**-Methoden erstellen und geben den N-ären Operator vom Typ [**IMathNaryOperator**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathNaryOperator) zurück. In der nary-Methode spezifiziert die Enumeration [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathNaryOperatorTypes) den Typ des Operators: Summation, Vereinigung usw., jedoch nicht Integrale. In der Integral-Methode gibt es den spezialisierten Integral-Operator mit der Enumeration von Integraltypen [**MathIntegralTypes**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathIntegralTypes). 

Beispiel:

```java
IMathBlock baseArg = new MathematicalText("x").join(new MathematicalText("dx").toBox());

IMathNaryOperator integral = baseArg.integral(MathIntegralTypes.Simple, "0", "1");
``` 

### **ToMathArray-Methode**
Die [**toMathArray**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#toMathArray--) platziert Elemente in einem vertikalen Array. Wenn diese Operation für eine Instanz von [**MathBlock**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/MathBlock) aufgerufen wird, werden alle untergeordneten Elemente im zurückgegebenen Array platziert.

Beispiel:

```java
IMathArray arrayFunction = new MathematicalText("x").join("y").toMathArray();
``` 

### **Formatierungsvorgänge: Akzent, Überstreichen, Unterstreichen, Gruppieren, InBorderBox, InBox**
- Die [**accent**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#accent-char-) Methode setzt ein Akzentzeichen (ein Zeichen oben auf dem Element).
- Die [**overbar**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#overbar--) und [**underbar**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#underbar--) Methoden setzen eine Linie oben oder unten.
- Die [**group**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#group--) Methode platziert in einer Gruppe mithilfe eines Gruppierungszeichens wie einer unteren geschweiften Klammer oder einem anderen.
- Die [**toBorderBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#toBorderBox--) Methode platziert in einem Randkasten.
- Die [**toBox**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMathElement#toBox--) Methode platziert in einer nicht sichtbaren Box (logische Gruppierung).

Beispiele:

```java
IMathAccent accent = new MathematicalText("x").accent('\u0303');

IMathBar bar = new MathematicalText("x").overbar();

IMathGroupingCharacter groupChr = new MathematicalText("x").join("y").join("z").group('\u23E1', MathTopBotPositions.Bottom, MathTopBotPositions.Top);

IMathBorderBox borderBox = new MathematicalText("x+y+z").toBorderBox();

IMathBox boxedOperator = new MathematicalText(":=").toBox();
``` 