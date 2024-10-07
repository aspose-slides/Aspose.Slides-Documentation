---
title: PowerPoint Mathematik Gleichungen
type: docs
weight: 80
url: /python-net/powerpoint-math-equations/
keywords: " PowerPoint Mathematik Gleichungen, PowerPoint Mathematik Symbole, PowerPoint Formel, PowerPoint Mathematik Text, PowerPoint Präsentation, Python, Aspose.Slides für Python über .NET"
description: "PowerPoint Mathematik Gleichungen, Mathematik Symbole, Formel und Mathematik Text in Python"
---

## **Übersicht**
In PowerPoint ist es möglich, eine Mathematik Gleichung oder Formel zu schreiben und sie in der Präsentation anzuzeigen. Dazu werden verschiedene mathematische Symbole in PowerPoint dargestellt und können zum Text oder zur Gleichung hinzugefügt werden. Dafür wird der Mathematik Gleichungen Konstruktor in PowerPoint verwendet, der hilft, komplexe Formeln zu erstellen, wie:

- Mathematische Brüche
- Mathematische Wurzeln
- Mathematische Funktionen
- Grenzen und Logarithmusfunktionen
- N-äre Operationen
- Matrizen
- Große Operatoren
- Sinus-, Cosinusfunktionen

Um eine mathematische Gleichung in PowerPoint hinzuzufügen, wird das Menü *Einfügen -> Gleichung* verwendet:

![todo:image_alt_text](powerpoint-math-equations_1.png)

Dies wird einen mathematischen Text in XML erstellen, der in PowerPoint wie folgt angezeigt werden kann: 

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint unterstützt eine Vielzahl von mathematischen Symbolen zur Erstellung von Gleichungen. Allerdings führt die Erstellung komplizierter Mathematik Gleichungen in PowerPoint oft nicht zu einem guten und professionellen Ergebnis. Nutzer, die häufig mathematische Präsentationen erstellen müssen, greifen auf die Verwendung von Drittanbieter-Lösungen zurück, um ansprechend aussehende mathematische Formeln zu erstellen.

Mit der [**Aspose.Slide API**](https://products.aspose.com/slides/python-net/) können Sie programmatisch in Python mit mathematischen Gleichungen in PowerPoint-Präsentationen arbeiten. Erstellen Sie neue mathematische Ausdrücke oder bearbeiten Sie zuvor erstellte. Der Export mathematischer Strukturen in Bilder wird ebenfalls teilweise unterstützt.


## **Wie man eine mathematische Gleichung erstellt**
Mathematische Elemente werden verwendet, um komplexe mathematische Konstruktionen mit beliebiger Verschachtelung zu bauen. Eine lineare Sammlung von mathematischen Elementen bildet einen mathematischen Block, der durch die [**MathBlock**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) Klasse repräsentiert wird. Die [**MathBlock**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) Klasse ist im Wesentlichen ein separates mathematisches Ausdruck, Formel oder Gleichung. [**MathPortion**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) ist ein mathematischer Abschnitt, der dazu verwendet wird, mathematischen Text zu halten (nicht zu verwechseln mit [**Portion**](https://reference.aspose.com/slides/python-net/aspose.slides/portion/)). Die [**MathParagraph**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) ermöglicht die Manipulation eines Satzes von Mathematikblöcken. Die oben genannten Klassen sind der Schlüssel zur Arbeit mit PowerPoint Mathematik Gleichungen über die Aspose.Slides API.

Schauen wir uns an, wie wir die folgende mathematische Gleichung über die Aspose.Slides API erstellen können:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Um einen mathematischen Ausdruck auf der Folie hinzuzufügen, fügen Sie zunächst eine Form hinzu, die den mathematischen Text enthalten wird:

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as pres:
    mathShape = pres.slides[0].shapes.add_math_shape(0, 0, 720, 150)
```

Nach der Erstellung wird die Form standardmäßig bereits einen Absatz mit einem mathematischen Abschnitt enthalten. Die [**MathPortion**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) Klasse ist ein Abschnitt, der mathematischen Text enthält. Um auf den mathematischen Inhalt innerhalb der [**MathPortion**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) zuzugreifen, verweisen Sie auf die [**MathParagraph**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) Variable:

```py
    mathParagraph = mathShape.text_frame.paragraphs[0].portions[0].math_paragraph
```

Die [**MathParagraph**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) Klasse ermöglicht das Lesen, Hinzufügen, Bearbeiten und Löschen von Mathematikblöcken ([**MathBlock**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)), die aus einer Kombination von mathematischen Elementen bestehen. Zum Beispiel, erstellen Sie einen Bruch und platzieren Sie ihn in der Präsentation:

```py
    fraction = math.MathematicalText("x").divide("y")
    mathParagraph.add(math.MathBlock(fraction))
```

Jedes mathematische Element wird durch eine Klasse dargestellt, die das [**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) Interface implementiert. Dieses Interface bietet viele Methoden zur einfachen Erstellung mathematischer Ausdrücke. Sie können einen ziemlich komplexen mathematischen Ausdruck mit einer einzigen Codezeile erstellen. Zum Beispiel würde der Satz des Pythagoras so aussehen:

```py
    mathBlock = (
        math.MathematicalText("c").set_superscript("2").
            join("=").
            join(math.MathematicalText("a").set_superscript("2")).
            join("+").
            join(math.MathematicalText("b").set_superscript("2")))
```

Die Operationen des Interfaces [**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) sind in jedem Typ von Element implementiert, einschließlich des [**MathBlock**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/).

Der vollständige Quellcode Beispiel:

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as pres:
    mathShape = pres.slides[0].shapes.add_math_shape(0, 0, 720, 150)

    mathParagraph = mathShape.text_frame.paragraphs[0].portions[0].math_paragraph

    fraction = math.MathematicalText("x").divide("y")
    mathParagraph.add(math.MathBlock(fraction))

    mathBlock = (
        math.MathematicalText("c").set_superscript("2").
            join("=").
            join(math.MathematicalText("a").set_superscript("2")).
            join("+").
            join(math.MathematicalText("b").set_superscript("2")))

    mathParagraph.add(mathBlock)

    pres.save("math.pptx", slides.export.SaveFormat.PPTX)
```


## **Mathematische Elementtypen**
Mathematische Ausdrücke bestehen aus Sequenzen mathematischer Elemente. Die Sequenz von mathematischen Elementen wird durch einen mathematischen Block repräsentiert, und die Argumente der mathematischen Elemente bilden eine baumartige Verschachtelung.

Es gibt viele Typen von mathematischen Elementen, die zur Konstruktion eines mathematischen Blocks verwendet werden können. Jedes dieser Elemente kann in ein anderes Element eingebunden (aggregiert) werden. Das heißt, Elemente sind tatsächlich Container für andere und bilden eine baumartige Struktur. Der einfachste Elementtyp enthält keine anderen Elemente des mathematischen Textes.

Jeder Typ des Mathematikelements implementiert das [**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) Interface, das die Verwendung von gemeinsamen mathematischen Operationen auf verschiedenen Typen von Mathe-Elementen ermöglicht.
### **MathematicalText Klasse**
Die [**MathematicalText**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) Klasse repräsentiert einen mathematischen Text - das zugrunde liegende Element aller mathematischen Konstruktionen. Mathematischer Text kann Operanden und Operatoren, Variablen und jeden anderen linearen Text darstellen.

Beispiel: 𝑎=𝑏+𝑐
### **MathFraction Klasse**
Die [**MathFraction**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfraction/) Klasse spezifiziert das Bruchobjekt, das aus einem Zähler und einem Nenner besteht, die durch eine Bruchlinie getrennt sind. Die Bruchlinie kann horizontal oder diagonal sein, abhängig von den Bruch-Eigenschaften. Das Bruchobjekt wird auch verwendet, um die Stapelfunktion darzustellen, die ein Element über dem anderen platziert, ohne dass eine Bruchlinie vorhanden ist.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **MathRadical Klasse**
Die [**MathRadical**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathradical/) Klasse spezifiziert die radikale Funktion (mathematische Wurzel), die aus einer Basis und einem optionalen Grad besteht.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **MathFunction Klasse**
Die [**MathFunction**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) Klasse spezifiziert eine Funktion eines Arguments. Enthält Eigenschaften: [Name](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) - Funktionsname und [Base](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) - Funktionsargument.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **MathNaryOperator Klasse**
Die [**MathNaryOperator**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperator/) Klasse spezifiziert ein N-äres mathematisches Objekt, wie Summation und Integral. Es besteht aus einem Operator, einer Basis (oder Operand) und optionalen oberen und unteren Grenzen. Beispiele für N-äre Operatoren sind Summation, Vereinigungen, Schnittmengen, Integrale.

Diese Klasse umfasst keine einfachen Operatoren wie Addition, Subtraktion und so weiter. Sie werden durch ein einzelnes Textelement - [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) - dargestellt.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **MathLimit Klasse**
Die [**MathLimit**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) Klasse erstellt die obere oder untere Grenze. Sie spezifiziert das Grenzwertobjekt, das aus Text auf der Grundlinie und Text in reduzierter Größe direkt darüber oder darunter besteht. Dieses Element umfasst nicht das Wort „lim“, erlaubt jedoch das Platzieren von Text an der Ober- oder Unterseite der Gleichung. So wird der Ausdruck 

![todo:image_alt_text](powerpoint-math-equations_8.png)

geschaffen, indem eine Kombination der [**MathFunction**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) und [**MathLimit**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) Elemente auf folgende Weise verwendet wird:

```py
    funcName = math.MathLimit(math.MathematicalText("lim"), math.MathematicalText("𝑥→∞"))
    mathFunc = math.MathFunction(funcName, math.MathematicalText("𝑥"))
```

### **MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement Klassen**
- [MathSubscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsubscriptelement/)
- [MathSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsuperscriptelement/)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathrightsubsuperscriptelement/)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathleftsubsuperscriptelement/)

Die folgenden Klassen spezifizieren einen tiefen Index oder einen hohen Index. Sie können den Subscript und Superscript gleichzeitig an der linken oder rechten Seite eines Arguments setzen, aber ein einzelner Subscript oder Superscript wird nur auf der rechten Seite unterstützt. Der [MathSubscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsubscriptelement/) kann auch verwendet werden, um den mathematischen Grad einer Zahl festzulegen.

Beispiel: 

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **MathMatrix Klasse**
Die [**MathMatrix**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) Klasse spezifiziert das Matrixobjekt, das aus Kind-Elementen besteht, die in einer oder mehreren Zeilen und Spalten angeordnet sind. Es ist wichtig zu beachten, dass Matrizen keine eingebauten Trennzeichen haben. Um die Matrix in Klammern zu setzen, sollten Sie das Trennzeichen-Objekt - [**IMathDelimiter**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathdelimiter/) verwenden. Nullargumente können verwendet werden, um Lücken in Matrizen zu schaffen.

Beispiel: 

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **MathArray Klasse**
Die [**MathArray**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/) Klasse spezifiziert ein vertikales Array von Gleichungen oder anderen mathematischen Objekten.

Beispiel: 

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **Formatierung mathematischer Elemente**
- Die [**MathBorderBox**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/) Klasse: zeichnet einen rechteckigen oder anderen Rahmen um das [**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/).
  
  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- Die [**MathBox**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathbox/) Klasse: spezifiziert das logische Boxen (Packaging) des mathematischen Elements. Zum Beispiel kann ein gekästetes Objekt als Operator-Emulator mit oder ohne Ausrichtungspunkt dienen, als Zeilenumbruch dienen oder gruppiert werden, um Copyright zu verhindern. Zum Beispiel sollte der „==“ Operator gekästet werden, um Zeilenumbrüche zu verhindern.
- Die [**MathDelimiter**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/) Klasse: spezifiziert das Trennzeichenobjekt, das aus öffnenden und schließenden Zeichen (wie Klammern, geschweifte Klammern, eckige Klammern und senkrechte Striche) sowie einem oder mehreren mathematischen Elementen innerhalb besteht, die durch ein angegebenes Zeichen getrennt sind. Beispiele: (𝑥2); [𝑥2|𝑦2].
  
  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- Die [**MathAccent**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathaccent/) Klasse: spezifiziert die Akzent-Funktion, die aus einer Basis und einem kombinierenden diakritischen Zeichen besteht. 

  Beispiel: 𝑎́.

- Die [**MathBar**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathBar/) Klasse: spezifiziert die Bar-Funktion, die aus einem Basisargument und einem Überstrich oder Unterstrich besteht.
  
  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- Die [**MathGroupingCharacter**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathGroupingCharacter/) Klasse: spezifiziert ein Gruppierungssymbol über oder unter einem Ausdruck, normalerweise um die Beziehungen zwischen Elementen hervorzuheben.
  
  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_15.png)


## **Mathematische Operationen**
Jedes mathematische Element und jeder mathematische Ausdruck (über [**MathBlock**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)) implementiert das [**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) Interface. Es ermöglicht die Verwendung von Operationen auf der bestehenden Struktur und die Bildung komplexerer mathematischer Ausdrücke. Alle Operationen haben zwei Parametersätze: entweder [**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) oder String als Argumente. Instanzen der [**MathematicalText**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) Klasse werden implizit aus angegebenen Zeichenfolgen erstellt, wenn Zeichenfolgenargumente verwendet werden. Mathematikoperationen, die in Aspose.Slides verfügbar sind, sind unten aufgeführt.
### **Join Methode**
- [Join(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Join(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

Verbindet ein mathematisches Element und bildet einen mathematischen Block. Zum Beispiel:

```py
    element1 = math.MathematicalText("x")
    element2 = math.MathematicalText("y")
    block = element1.join(element2)
```
### **Divide Methode**
- [Divide(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Divide(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Divide(String, MathFractionTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

Erstellt einen Bruch des angegebenen Typs mit diesem Zähler und dem angegebenen Nenner. Zum Beispiel:

```py
    numerator = math.MathematicalText("x")
    fraction = numerator.divide("y", math.MathFractionTypes.LINEAR)
```
### **Enclose Methode**
- [Enclose()](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Enclose(Char, Char)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

Umrahmt das Element in festgelegten Zeichen wie Klammern oder einem anderen Zeichen als Rahmen.

```py
# Umrahmt ein mathematisches Element in Klammern
MathDelimiter enclose()

# Umrahmt dieses Element in festgelegten Zeichen wie Klammern oder einem anderen Zeichen als Rahmen
MathDelimiter enclose(char beginningCharacter, char endingCharacter)
```

Zum Beispiel:

```py
    delimiter = math.MathematicalText("x").enclose('[', ']')
    delimiter2 = math.MathematicalText("elem1").join("elem2").enclose()
```
### **Function Methode**
- [Function(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Function(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

Nimmt eine Funktion eines Arguments und verwendet das aktuelle Objekt als Funktionsnamen.

Zum Beispiel:

```py
func = math.MathematicalText("sin").function("x")
```
### **AsArgumentOfFunction Methode**
- [AsArgumentOfFunction(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [AsArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [AsArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

Nimmt die angegebene Funktion und verwendet die aktuelle Instanz als Argument. Sie können:

- eine Zeichenfolge als Funktionsnamen angeben, zum Beispiel „cos“.
- einen der vordefinierten Werte der Aufzählungen [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunctionsofoneargument/) oder [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunctionsoftwoarguments/) auswählen, zum Beispiel **MathFunctionsOfOneArgument.ArcSin.**
- die Instanz des [**IMathElement**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) auswählen.

Zum Beispiel:

```py
    funcName = math.MathLimit(math.MathematicalText("lim"), math.MathematicalText("𝑛→∞"))
    func1 = math.MathematicalText("2x").as_argument_of_function(funcName)
    func2 = math.MathematicalText("x").as_argument_of_function("sin")
    func3 = math.MathematicalText("x").as_argument_of_function(math.MathFunctionsOfOneArgument.SIN)
    func4 = math.MathematicalText("x").as_argument_of_function(math.MathFunctionsOfTwoArguments.LOG, "3")
```
### **SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft Methoden**
- [SetSubscript(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSubscript(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSuperscript(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSuperscript(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

Setzt Subscript und Superscript. Sie können Subscript und Superscript gleichzeitig an der linken oder rechten Seite des Arguments setzen, aber single Subscript oder Superscript wird nur auf der rechten Seite unterstützt. Der **Superscript** kann auch verwendet werden, um den mathematischen Grad einer Zahl festzulegen.

Beispiel:

```py
    script = math.MathematicalText("y").set_sub_superscript_on_the_left("2x", "3z")
```
### **Radical Methode**
- [Radical(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Radical(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

Spezifiziert die mathematische Wurzel des gegebenen Grades vom angegebenen Argument.

Beispiel:

```py
    radical = math.MathematicalText("x").radical("3")
```
### **SetUpperLimit und SetLowerLimit Methoden**
- [SetUpperLimit(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetUpperLimit(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetLowerLimit(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [SetLowerLimit(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

Nimmt die obere oder untere Grenze. Hier zeigen die oberen und unteren einfach den Standort des Arguments relativ zur Basis an.

Betrachten wir einen Ausdruck: 

![todo:image_alt_text](powerpoint-math-equations_8.png)

Solche Ausdrücke können durch eine Kombination der Klassen [MathFunction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathFunction/) und [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathLimit/) sowie Operationen des [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) wie folgt erstellt werden:

```py
mathExpression = math.MathematicalText("lim").set_lower_limit("x→∞").function("x")
```
### **Nary und Integral Methoden**
- [Nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Integral(MathIntegralTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [Integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

Sowohl die **Nary** als auch die **Integral** Methoden erstellen und geben den N-ären Operator vom Typ [**INaryOperator**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathnaryoperator/) zurück. In der Nary-Methode spezifiziert die [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperatortypes/) Aufzählung den Typ des Operators: Summation, Vereinigungen usw., ohne Integrale einzuschließen. In der Integral-Methode gibt es die spezialisierte Operation Integral mit der Aufzählung von Integraltypen [**MathIntegralTypes**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathintegraltypes/). 

Beispiel:

```py
    baseArg = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
    integral = baseArg.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```
### **ToMathArray Methode**
[**ToMathArray**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) platziert Elemente in einem vertikalen Array. Wenn diese Operation für eine **MathBlock** Instanz aufgerufen wird, werden alle Kind-Elemente im zurückgegebenen Array platziert.

Beispiel:

```py
    arrayFunction = math.MathematicalText("x").join("y").to_math_array()
```
### **Formatierungsoperationen: Akzent, Überstrich, Unterstrich, Gruppe, ZuBorderBox, ZuBox**
- Die [**Accent**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) Methode setzt ein Akzentzeichen (ein Zeichen auf der Oberseite des Elements).
- Die [**Overbar**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) und [**Underbar**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) Methoden setzen eine Linie oben oder unten.
- Die [**Group**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) Methode platziert sie in einer Gruppe mit einem Gruppierungssymbol wie einer unteren geschweiften Klammer oder einer anderen.
- Die [**ToBorderBox**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) Methode platziert sie in einer Rahmenbox.
- Die [**ToBox**](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) Methode platziert sie in einer unsichtbaren Box (logische Gruppierung).

Beispiele:

```py
    accent = math.MathematicalText("x").accent(chr(0x0303))
    bar = math.MathematicalText("x").overbar()
    groupChr = math.MathematicalText("x").join("y").join("z").group(chr(0x23E1), 
            math.MathTopBotPositions.BOTTOM, 
            math.MathTopBotPositions.TOP)
    borderBox = math.MathematicalText("x+y+z").to_border_box()
    boxedOperator = math.MathematicalText(":=").to_box()
```