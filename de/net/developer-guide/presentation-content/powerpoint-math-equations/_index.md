---
title: PowerPoint Mathematik Gleichungen
type: docs
weight: 80
url: /de/net/powerpoint-math-equations/
keywords: " PowerPoint Mathematik Gleichungen, PowerPoint Mathematik Symbole, PowerPoint Formel, PowerPoint Mathematik Text, PowerPoint Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "PowerPoint Mathematik Gleichungen, Mathematik Symbole, Formel und Mathematik Text in C# oder .NET"
---

## **Übersicht**
In PowerPoint ist es möglich, eine mathematische Gleichung oder Formel zu schreiben und in der Präsentation anzuzeigen. Dazu werden verschiedene mathematische Symbole in PowerPoint dargestellt und können zum Text oder zur Gleichung hinzugefügt werden. Dafür wird der Konstruktor für mathematische Gleichungen in PowerPoint verwendet, der hilft, komplexe Formeln wie folgende zu erstellen:

- Mathematische Brüche
- Mathematische Wurzeln
- Mathematische Funktionen
- Grenzwerte und Logarithmusfunktionen
- N-ary Operationen
- Matrizen
- Große Operatoren
- Sinus-, Kosinusfunktionen

Um eine mathematische Gleichung in PowerPoint hinzuzufügen, wird das Menü *Einfügen -> Gleichung* verwendet:

![todo:image_alt_text](powerpoint-math-equations_1.png)

Dies erstellt einen mathematischen Text in XML, der in PowerPoint wie folgt angezeigt werden kann:

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint unterstützt viele mathematische Symbole zur Erstellung von Mathematik Gleichungen. Das Erstellen komplizierter Mathematik Gleichungen in PowerPoint bringt jedoch oft kein gutes und professionelles Ergebnis. Benutzer, die häufig mathematische Präsentationen erstellen müssen, greifen auf die Verwendung von Drittanbieter-Lösungen zurück, um ansprechend aussehende mathematische Formeln zu erstellen.

Mit der [**Aspose.Slide API**](https://products.aspose.com/slides/net/) können Sie programmgesteuert mit mathematischen Gleichungen in PowerPoint-Präsentationen in C# arbeiten. Erstellen Sie neue mathematische Ausdrücke oder bearbeiten Sie bereits erstellte. Der Export mathematischer Strukturen in Bilder wird ebenfalls teilweise unterstützt.

## **Wie man eine mathematische Gleichung erstellt**
Mathematische Elemente werden verwendet, um mathematische Konstruktionen mit beliebigen Verschachtelungstiefen zu erstellen. Eine lineare Sammlung mathematischer Elemente bildet einen mathematischen Block, der durch die [**MathBlock**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock) Klasse dargestellt wird. Die [**MathBlock**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock) Klasse ist im Wesentlichen ein separates mathematisches Ausdruck, eine Formel oder eine Gleichung. [**MathPortion**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion) ist ein mathematischer Teil, der verwendet wird, um mathematischen Text zu halten (nicht zu verwechseln mit [**Portion**](https://reference.aspose.com/slides/net/aspose.slides/portion)). Die [**MathParagraph**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph) erlaubt die Manipulation einer Menge von mathematischen Blöcken. Die vorgenannten Klassen sind der Schlüssel zur Arbeit mit PowerPoint Mathematik Gleichungen über die Aspose.Slides API.

Schauen wir uns an, wie wir die folgende mathematische Gleichung über die Aspose.Slides API erstellen können:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Um einen mathematischen Ausdruck auf der Folie hinzuzufügen, fügen Sie zunächst eine Form hinzu, die den mathematischen Text enthalten wird:

``` csharp
 using (Presentation pres = new Presentation())
{
    var mathShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);
}
```

Nach der Erstellung wird die Form standardmäßig bereits einen Absatz mit einem mathematischen Abschnitt enthalten. Die [**MathPortion**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion) Klasse ist ein Abschnitt, der einen mathematischen Text enthält. Um auf den mathematischen Inhalt innerhalb von [**MathPortion**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion) zuzugreifen, verweisen Sie auf die [**MathParagraph**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph)Variable:

``` csharp
 var mathParagraph = (mathShape.TextFrame.Paragraphs[0].Portions[0] as MathPortion).MathParagraph;
```

Die [**MathParagraph**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph) Klasse ermöglicht das Lesen, Hinzufügen, Bearbeiten und Löschen von mathematischen Blöcken ([**MathBlock**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)), die aus einer Kombination mathematischer Elemente bestehen. Erstellen Sie beispielsweise einen Bruch und platzieren Sie ihn in der Präsentation:

``` csharp
 var fraction = new MathematicalText("x").Divide("y");
mathParagraph.Add(new MathBlock(fraction));
```

Jedes mathematische Element wird durch eine Klasse dargestellt, die das [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement)Interface implementiert. Dieses Interface bietet viele Methoden zum einfachen Erstellen mathematischer Ausdrücke. Sie können mit einer einzigen Codezeile einen ziemlich komplexen mathematischen Ausdruck erstellen. Zum Beispiel würde der Satz des Pythagoras so aussehen:

``` csharp
 var mathBlock = new MathematicalText("c")
    .SetSuperscript("2")
    .Join("=")
    .Join(new MathematicalText("a").SetSuperscript("2"))
    .Join("+")
    .Join(new MathematicalText("b").SetSuperscript("2"));
```

Die Operationen des Interfaces [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement) sind in jedem Elementtyp implementiert, einschließlich des [**MathBlock**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock).

Der vollständige Beispielcode:

``` csharp
 using (Presentation pres = new Presentation())
{
    IAutoShape mathShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);
    var mathParagraph = (mathShape.TextFrame.Paragraphs[0].Portions[0] as MathPortion).MathParagraph;

    var fraction = new MathematicalText("x").Divide("y");
    mathParagraph.Add(new MathBlock(fraction));

    var mathBlock = new MathematicalText("c")
        .SetSuperscript("2")
        .Join("=")
        .Join(new MathematicalText("a").SetSuperscript("2"))
        .Join("+")
        .Join(new MathematicalText("b").SetSuperscript("2"));
    mathParagraph.Add(mathBlock);
    pres.Save("math.pptx", SaveFormat.Pptx);
}
```

## **Arten von mathematischen Elementen**
Mathematische Ausdrücke werden aus Sequenzen mathematischer Elemente gebildet. Die Sequenz mathematischer Elemente wird durch einen mathematischen Block dargestellt, und die Argumente der mathematischen Elemente bilden eine baumartige Verschachtelung.

Es gibt viele Typen von mathematischen Elementen, die verwendet werden können, um einen mathematischen Block zu konstruieren. Jedes dieser Elemente kann in ein anderes Element aufgenommen (aggregiert) werden. Das heißt, Elemente sind tatsächlich Container für andere und bilden eine baumartige Struktur. Der einfachste Elementtyp enthält keine anderen Elemente des mathematischen Texts.

Jeder Typ von Mathematikelement implementiert das [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement)Interface, das die Verwendung einer gemeinsamen Menge von mathematischen Operationen auf verschiedenen Typen von Mathematikelementen ermöglicht.

### **MathematicalText Klasse**
Die [**MathematicalText**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext) Klasse stellt einen mathematischen Text dar – das zugrunde liegende Element aller mathematischen Konstruktionen. Mathematischer Text kann Operanden und Operatoren, Variablen und jeden anderen linearen Text darstellen.

Beispiel: 𝑎=𝑏+𝑐
### **MathFraction Klasse**
Die [**MathFraction**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfraction) Klasse spezifiziert das Bruchobjekt, bestehend aus einem Zähler und einem Nenner, die durch eine Bruchlinie getrennt sind. Die Bruchlinie kann horizontal oder diagonal sein, abhängig von den Bruch Eigenschaften. Das Bruchobjekt wird auch verwendet, um die Stapelfunktion darzustellen, die ein Element über ein anderes setzt, ohne Bruchlinie.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_4.png)
### **MathRadical Klasse**
Die [**MathRadical**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathradical) Klasse spezifiziert die radikale Funktion (mathematische Wurzel), bestehend aus einer Basis und einer optionalen Potenz.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_5.png)
### **MathFunction Klasse**
Die [**MathFunction**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction) Klasse spezifiziert eine Funktion eines Arguments. Sie enthält Eigenschaften: [Name](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction/properties/name) - Funktionsname und [Basis](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction/properties/base) - Funktionsargument.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_6.png)
### **MathNaryOperator Klasse**
Die [**MathNaryOperator**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathnaryoperator) Klasse spezifiziert ein N-ary mathematisches Objekt, wie Summation und Integral. Es besteht aus einem Operator, einer Basis (oder Operanden) und optionalen oberen und unteren Grenzen. Beispiele für N-ary Operatoren sind Summation, Vereinigung, Schnittmenge, Integral.

Diese Klasse umfasst keine einfachen Operatoren wie Addition, Subtraktion usw. Diese werden durch ein einzelnes Textelement dargestellt - [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext).

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_7.png)
### **MathLimit Klasse**
Die [**MathLimit**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit) Klasse erstellt die obere oder untere Grenze. Sie spezifiziert das Grenzwertobjekt, bestehend aus Text auf der Basislinie und reduziertem Text direkt darüber oder darunter. Dieses Element enthält nicht das Wort „lim“, erlaubt aber die Platzierung von Text oben oder unten im Ausdruck. So wird der Ausdruck 

![todo:image_alt_text](powerpoint-math-equations_8.png)

durch eine Kombination von [**MathFunction**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction) und [**MathLimit**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit) Elementen auf folgende Weise erstellt:

``` csharp
 var funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));
var mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));
```

### **MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement Klassen**
- [MathSubscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsubscriptelement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsuperscriptelement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathrightsubsuperscriptelement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathleftsubsuperscriptelement)

Die folgenden Klassen spezifizieren einen Tiefenindex oder einen oberen Index. Sie können den Subscript und Superscript gleichzeitig auf der linken oder rechten Seite eines Arguments festlegen, jedoch wird ein einzelner Subscript oder Superscript nur auf der rechten Seite unterstützt. Das [MathSubscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsubscriptelement) kann auch verwendet werden, um den mathematischen Grad einer Zahl festzulegen.

Beispiel: 

![todo:image_alt_text](powerpoint-math-equations_9.png)
### **MathMatrix Klasse**
Die [**MathMatrix**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix) Klasse spezifiziert das Matrixobjekt, das aus Kinderelementen besteht, die in einer oder mehreren Zeilen und Spalten angeordnet sind. Es ist wichtig zu beachten, dass Matrizen keine eingebauten Trennzeichen haben. Um die Matrix in Klammern zu setzen, sollten Sie das Trennzeichenobjekt - [**IMathDelimiter**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter) verwenden. Nullargumente können verwendet werden, um Lücken in Matrizen zu erstellen.

Beispiel: 

![todo:image_alt_text](powerpoint-math-equations_10.png)
### **MathArray Klasse**
Die [**MathArray**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/matharray) Klasse spezifiziert ein vertikales Array von Gleichungen oder anderen mathematischen Objekten.

Beispiel: 

![todo:image_alt_text](powerpoint-math-equations_11.png)
### **Formatierung mathematischer Elemente**
- Die [**MathBorderBox**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathborderbox) Klasse: zeichnet eine rechteckige oder andere Umrandung um das [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement).

  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_12.png)

- Die [**MathBox**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathbox) Klasse: spezifiziert das logische Boxen (Verpackung) des mathematischen Elements. Zum Beispiel kann ein gekästetes Objekt als Operator-Emulator mit oder ohne Ausrichtungspunkt dienen, als Zeilenumbruch dienen oder gruppiert werden, sodass keine Zeilenumbrüche innerhalb erlaubt sind. Zum Beispiel sollte der "==" Operator gekästet werden, um Zeilenumbrüche zu verhindern.
- Die [**MathDelimiter**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimiter) Klasse: spezifiziert das Trennzeichenobjekt, das aus öffnenden und schließenden Zeichen (wie Klammern, geschweifte Klammern, eckige Klammern und senkrechte Striche) und einem oder mehreren mathematischen Elementen innerhalb, die durch ein angegebenes Zeichen getrennt sind, besteht. Beispiele: (𝑥2); [𝑥2|𝑦2].
  
  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_13.png)

- Die [**MathAccent**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathaccent) Klasse: spezifiziert die Akzentfunktion, die aus einer Basis und einem kombinierenden diakritischen Zeichen besteht. 

  Beispiel: 𝑎́.

- Die [**MathBar**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathBar) Klasse: spezifiziert die Balkenfunktion, die aus einem Basisargument und einem Über- oder Unterstrich besteht.
  
  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_14.png)

- Die [**MathGroupingCharacter**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathGroupingCharacter) Klasse: spezifiziert ein Gruppierungszeichen über oder unter einem Ausdruck, normalerweise um die Beziehungen zwischen Elementen hervorzuheben.
  
  Beispiel: ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **Mathematische Operationen**
Jedes mathematische Element und jeder mathematische Ausdruck (über [**MathBlock**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)) implementiert das [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement)Interface. Es ermöglicht Ihnen, Operationen auf der bestehenden Struktur zu verwenden und komplexere mathematische Ausdrücke zu bilden. Alle Operationen haben zwei Parametersätze: entweder [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement) oder string als Argumente. Instanzen der [**MathematicalText**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathematicalText) Klasse werden implizit aus angegebenen Zeichenfolgen erstellt, wenn Zeichenfolgenargumente verwendet werden. Mathematikoperationen, die in Aspose.Slides verfügbar sind, sind unten aufgeführt.
### **Join Methode**
- [Join(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/join/methods/1)
- [Join(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/join)

Verbindet ein mathematisches Element und bildet einen mathematischen Block. Zum Beispiel:

``` csharp
 IMathElement element1 = new MathematicalText("x");
IMathElement element2 = new MathematicalText("y");
IMathBlock block = element1.Join(element2);
```
### **Divide Methode**
- [Divide(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/2)
- [Divide(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/divide)
- [Divide(String, MathFractionTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/3)
- [Divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/1)

Erstellt einen Bruch des angegebenen Typs mit diesem Zähler und dem angegebenen Nenner. Zum Beispiel:

``` csharp
 IMathElement numerator = new MathematicalText("x");
IMathFraction fraction = numerator.Divide("y", MathFractionTypes.Linear);
```
### **Enclose Methode**
- [Enclose()](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/enclose)
- [Enclose(Char, Char)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/enclose/methods/1)

Schließt das Element in spezifizierte Zeichen wie Klammern oder ein anderes Zeichen als Rahmen ein.

``` csharp
 /// <summary>
/// Schließt ein mathematisches Element in Klammern ein
/// </summary>
IMathDelimiter Enclose();
/// <summary>
/// Schließt dieses Element in spezifizierte Zeichen wie Klammern oder andere Zeichen als Rahmen ein
/// </summary>
IMathDelimiter Enclose(char beginningCharacter, char endingCharacter);
```

Beispiel:

``` csharp
 IMathDelimiter delimiter = new MathematicalText("x").Enclose('[', ']');
IMathDelimiter delimiter2 = new MathematicalText("elem1").Join("elem2").Enclose();
```
### **Function Methode**
- [Function(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/function/methods/1)
- [Function(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/function)

Nimmt eine Funktion eines Arguments und verwendet das aktuelle Objekt als Funktionsname.

``` csharp
 /// <summary>
/// Nimmt eine Funktion eines Arguments und verwendet diese Instanz als Funktionsname
/// </summary>
/// <param name="functionArgument">Ein Argument der Funktion</param>
IMathFunction Function(IMathElement functionArgument);
IMathFunction Function(string functionArgument);
```

Beispiel:

``` csharp
 IMathFunction func = new MathematicalText("sin").Function("x");
```
### **AsArgumentOfFunction Methode**
- [AsArgumentOfFunction(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/4)
- [AsArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/asargumentoffunction)
- [AsArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/1)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/2)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/methods/3)

Nimmt die angegebene Funktion und verwendet die aktuelle Instanz als Argument. Sie können:

- eine Zeichenfolge als Funktionsname angeben, z.B. „cos“.
- einen der vordefinierten Werte der Aufzählungen [**MathFunctionsOfOneArgument**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunctionsofoneargument) oder [**MathFunctionsOfTwoArguments**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunctionsoftwoarguments) auswählen, z.B. **MathFunctionsOfOneArgument.ArcSin.**
- die Instanz des [**IMathElement**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement) auswählen.

Beispiel:

``` csharp
 var funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));
var func1 = new MathematicalText("2x").AsArgumentOfFunction(funcName);
var func2 = new MathematicalText("x").AsArgumentOfFunction("sin");
var func3 = new MathematicalText("x").AsArgumentOfFunction(MathFunctionsOfOneArgument.Sin);
var func4 = new MathematicalText("x").AsArgumentOfFunction(MathFunctionsOfTwoArguments.Log, "3");
```
### **SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft Methoden**
- [SetSubscript(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsubscript/methods/1)
- [SetSubscript(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsubscript)
- [SetSuperscript(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsuperscript/methods/1)
- [SetSuperscript(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsuperscript)
- [SetSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsubsuperscriptontheright/methods/1)
- [SetSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsubsuperscriptontheright)
- [SetSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsubsuperscriptontheleft/methods/1)
- [SetSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsubsuperscriptontheleft)

Setzt Subscript und Superscript. Sie können Subscript und Superscript gleichzeitig auf der linken oder rechten Seite des Arguments festlegen, aber ein einzelner Subscript oder Superscript wird nur auf der rechten Seite unterstützt. Das **Superscript** kann auch verwendet werden, um den mathematischen Grad einer Zahl festzulegen.

Beispiel:

``` csharp
 var script = new MathematicalText("y").SetSubSuperscriptOnTheLeft("2x", "3z");
```
### **Radical Methode**
- [Radical(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/radical/methods/1)
- [Radical(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/radical)

Spezifiziert die mathematische Wurzel des gegebenen Grades aus dem angegebenen Argument.

Beispiel:

``` csharp
 var radical = new MathematicalText("x").Radical("3");
```
### **SetUpperLimit und SetLowerLimit Methoden**
- [SetUpperLimit(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setupperlimit/methods/1)
- [SetUpperLimit(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setupperlimit)
- [SetLowerLimit(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setlowerlimit/methods/1)
- [SetLowerLimit(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setlowerlimit)

Nimmt die obere oder untere Grenze. Hier zeigen die obere und untere Position einfach die Lage des Arguments relativ zur Basis an.

Betrachten wir einen Ausdruck: 

![todo:image_alt_text](powerpoint-math-equations_8.png)

Solche Ausdrücke können durch eine Kombination von Klassen [MathFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathFunction) und [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathLimit) sowie Operationen des [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement) wie folgt erstellt werden:

``` csharp
 var mathExpression = MathText.Create("lim").SetLowerLimit("x→∞").Function("x");
```
### **Nary und Integral Methoden**
- [Nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/nary)
- [Nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/nary/methods/1)
- [Integral(MathIntegralTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/integral)
- [Integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/1)
- [Integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/methods/3)
- [Integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/2)
- [Integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/4)

Die **Nary** und **Integral** Methoden erstellen und geben den N-ary Operator zurück, dargestellt durch den [**INaryOperator**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathnaryoperator) Typ. In der Nary Methode gibt die [**MathNaryOperatorTypes**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathnaryoperatortypes) Aufzählung den Typ des Operators an: Summation, Vereinigung usw., ohne Integrale einzuschließen. In der Integral Methode gibt es die spezialisierte Operation Integral mit der Aufzählung der Integraltypen [**MathIntegralTypes**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathintegraltypes).

Beispiel:

``` csharp
 IMathBlock baseArg = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
IMathNaryOperator integral = baseArg.Integral(MathIntegralTypes.Simple, "0", "1");
```
### **ToMathArray Methode**
[**ToMathArray**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/tomatharray) platziert Elemente in einem vertikalen Array. Wenn diese Operation für eine **MathBlock** Instanz aufgerufen wird, werden alle Kinderelemente im zurückgegebenen Array platziert.

Beispiel:

``` csharp
 var arrayFunction = new MathematicalText("x").Join("y").ToMathArray();
```
### **Formatierungsoperationen: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**
- Die [**Accent**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/accent) Methode setzt ein Akzentzeichen (ein Zeichen oben auf dem Element).
- Die [**Overbar**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/overbar) und [**Underbar**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/underbar) Methoden setzen einen Balken oben oder unten.
- Die [**Group**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/group) Methode platziert in einer Gruppe unter Verwendung eines Gruppierungszeichens wie einer unteren geschweiften Klammer oder ähnlichem.
- Die [**ToBorderBox**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/toborderbox) Methode platziert in eine Border-Box.
- Die [**ToBox**](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/tobox) Methode platziert in eine nicht sichtbare Box (logische Gruppierung).

Beispiele:

``` csharp
 var accent = new MathematicalText("x").Accent('\u0303');
var bar = new MathematicalText("x").Overbar();
var groupChr = new MathematicalText("x").Join("y").Join("z").Group('\u23E1', MathTopBotPositions.Bottom, MathTopBotPositions.Top);
var borderBox = new MathematicalText("x+y+z").ToBorderBox();
var boxedOperator = new MathematicalText(":=").ToBox();
```