---
title: Mathematische Gleichungen zu PowerPoint-Präsentationen in C# hinzufügen
linktitle: PowerPoint Mathegleichungen
type: docs
weight: 80
url: /de/net/powerpoint-math-equations/
keywords:
- Mathematische Gleichung
- PowerPoint Mathegleichung
- Mathematisches Symbol
- PowerPoint Mathe‑symbol
- Mathematische Formel
- PowerPoint Mathe‑formel
- Mathematischer Text
- PowerPoint Mathe‑text
- Mathematische Gleichung zu PowerPoint hinzufügen
- Mathematisches Symbol zu PowerPoint hinzufügen
- Mathematische Formel zu PowerPoint hinzufügen
- Mathematischen Text zu PowerPoint hinzufügen
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie mit mathematischen Gleichungen in PowerPoint mithilfe von Aspose.Slides für .NET arbeiten. Erhalten Sie detaillierte Anleitungen, Code‑Beispiele und Tipps zur Automatisierung der Erstellung und Bearbeitung von Präsentationen."
---

## **Übersicht**

In PowerPoint können Sie eine mathematische Gleichung oder Formel schreiben und in Ihrer Präsentation anzeigen. Verschiedene mathematische Symbole stehen zur Verfügung und können zu Text oder Gleichungen hinzugefügt werden. Der Konstruktor für mathematische Gleichungen wird verwendet, um komplexe Formeln zu erstellen, wie zum Beispiel:

- Mathematischer Bruch
- Mathematisches Radikal
- Mathematische Funktion
- Grenzen und Logarithmusfunktionen
- N‑äre Operationen
- Matrix
- Große Operatoren
- Sinus‑ und Kosinus‑Funktionen

Um in PowerPoint eine mathematische Gleichung hinzuzufügen, wird das Menü *Einfügen -> Gleichung* verwendet:

![todo:image_alt_text](powerpoint-math-equations_1.png)

Dies erstellt einen mathematischen Text in XML, der in PowerPoint wie folgt angezeigt werden kann: 

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint unterstützt eine breite Palette mathematischer Symbole zum Erstellen von Gleichungen. Das Generieren komplexer mathematischer Gleichungen in PowerPoint liefert jedoch häufig kein poliertes, professionelles Ergebnis. Deshalb greifen Benutzer, die häufig mathematische Präsentationen erstellen, oft auf Drittanbieterlösungen zurück, um besser aussehende Formeln zu erhalten.

Mit der [**Aspose.Slides‑API**](https://products.aspose.com/slides/net/) können Sie programmgesteuert in C# mit mathematischen Gleichungen in PowerPoint‑Präsentationen arbeiten. Erstellen Sie neue mathematische Ausdrücke oder bearbeiten Sie zuvor erstellte. Teilweise wird die Unterstützung zum Exportieren mathematischer Strukturen als Bilder bereitgestellt.

## **Wie man eine mathematische Gleichung erstellt**

Mathematische Elemente werden verwendet, um jede mathematische Konstruktion aufzubauen, unabhängig vom Verschachtelungsgrad. Eine lineare Sammlung dieser Elemente bildet einen mathematischen Block, dargestellt durch die Klasse [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock). Die Klasse [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock) stellt einen eigenständigen mathematischen Ausdruck, eine Formel oder Gleichung dar. [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion) wird verwendet, um mathematischen Text zu halten (unterscheidet sich von der regulären Klasse [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion)), während [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph) es Ihnen ermöglicht, eine Menge von [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)-Objekten zu manipulieren. Diese Klassen sind wesentlich für die Arbeit mit PowerPoint‑Mathe‑Gleichungen über die Aspose.Slides‑API.

Sehen wir, wie wir die folgende mathematische Gleichung mit der Aspose.Slides‑API erstellen können:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Um einen mathematischen Ausdruck zur Folie hinzuzufügen, fügen Sie zuerst eine Form hinzu, die den mathematischen Text enthalten wird:

```cs
using (var presentation = new Presentation())
{
    var mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);
}
```


Nach dem Erstellen der Form enthält sie standardmäßig bereits einen Absatz mit einem mathematischen Teil. Die Klasse [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion) stellt einen Teil dar, der mathematischen Text enthält. Um auf den mathematischen Inhalt innerhalb einer [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion) zuzugreifen, beziehen Sie sich auf die Variable [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph):

```cs
var mathParagraph = (mathShape.TextFrame.Paragraphs[0].Portions[0] as MathPortion).MathParagraph;
```


Die Klasse [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph) ermöglicht das Lesen, Hinzufügen, Bearbeiten und Löschen von Math‑Blöcken ([MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)), die aus einer Kombination mathematischer Elemente bestehen. Beispiel: Erstellen Sie einen Bruch und platzieren Sie ihn in der Präsentation:

```cs
var fraction = new MathematicalText("x").Divide("y");

mathParagraph.Add(new MathBlock(fraction));
```


Jedes mathematische Element wird durch eine Klasse repräsentiert, die das Interface [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement) implementiert. Dieses Interface bietet zahlreiche Methoden, um mathematische Ausdrücke einfach zu erstellen, sodass Sie ziemlich komplexe Gleichungen mit nur einer Code‑Zeile konstruieren können. Beispielsweise würde der Satz des Pythagoras folgendermaßen aussehen:

```cs
var mathBlock = new MathematicalText("c")
    .SetSuperscript("2")
    .Join("=")
    .Join(new MathematicalText("a").SetSuperscript("2"))
    .Join("+")
    .Join(new MathematicalText("b").SetSuperscript("2"));
```


Operationen des Interfaces [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement) sind in jedem Elementtyp implementiert, einschließlich der Klasse [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock).

Unten finden Sie das vollständige Quellcodebeispiel:

```cs
using (var presentation = new Presentation())
{
    var mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);
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

    presentation.Save("math.pptx", SaveFormat.Pptx);
}
```


## **Typen mathematischer Elemente**

Mathematische Ausdrücke bestehen aus Sequenzen mathematischer Elemente. Ein mathematischer Block stellt eine solche Sequenz dar, und die Argumente dieser Elemente bilden eine verschachtelte, baumartige Struktur.

Es gibt viele Typen mathematischer Elemente, die zum Aufbau eines mathematischen Blocks verwendet werden können. Jedes dieser Elemente kann innerhalb eines anderen aggregiert werden, wodurch eine baumartige Struktur entsteht. Der einfachste Elementtyp ist einer, der keine anderen mathematischen Textelemente enthält.

Jeder Typ eines Mathe‑Elements implementiert das Interface [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement), wodurch Sie einen gemeinsamen Satz von mathematischen Operationen auf verschiedene Mathe‑Elementtypen anwenden können.

### **MathematicalText‑Klasse**

Die Klasse [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext) stellt einen mathematischen Text dar – das zugrunde liegende Element aller mathematischen Konstruktionen. Mathematischer Text kann Operanden und Operatoren, Variablen oder beliebigen linearen Text repräsentieren.

Beispiel: 𝑎=𝑏+𝑐

### **MathFraction‑Klasse**

Die Klasse [MathFraction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfraction) definiert ein Bruchobjekt, das aus Zähler und Nenner besteht, getrennt durch einen Bruchstrich. Der Bruchstrich kann horizontal oder diagonal sein, abhängig von den Eigenschaften des Bruchs. Das Bruchobjekt wird auch verwendet, um die Stapelfunktion darzustellen, bei der ein Element über einem anderen ohne Bruchstrich platziert wird.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **MathRadical‑Klasse**

Die Klasse [MathRadical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathradical) definiert die Radikal‑Funktion (mathematische Wurzel), bestehend aus einer Basis und einem optionalen Grad.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **MathFunction‑Klasse**

Die Klasse [MathFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction) definiert eine Funktion eines Arguments. Sie enthält Eigenschaften wie [Name](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction/properties/name), die den Funktionsnamen darstellt, und [Base](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction/properties/base), die das Funktionsargument repräsentiert.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **MathNaryOperator‑Klasse**

Die Klasse [MathNaryOperator](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathnaryoperator) definiert ein N‑äres mathematisches Objekt, wie z. B. eine Summation oder ein Integral. Sie besteht aus einem Operator, einer Basis (oder einem Operanden) und optionalen oberen und unteren Grenzen. Beispiele für N‑äre Operatoren sind Summation, Vereinigung, Schnittmenge und Integral.

Die Klasse [MathNaryOperator](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathnaryoperator) definiert ein N‑äres mathematisches Objekt, wie Summation und Integral. Sie besteht aus einem Operator, einer Basis (oder einem Operanden) und optionalen oberen und unteren Grenzen. Beispiele für N‑äre Operatoren sind Summation, Vereinigung, Schnittmenge und Integral.

Diese Klasse enthält keine einfachen Operatoren wie Addition, Subtraktion usw. Diese werden durch ein einzelnes Text‑[MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext) dargestellt.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **MathLimit‑Klasse**

Die Klasse [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit) erzeugt die obere oder untere Grenze. Sie definiert das Grenze‑Objekt, das aus Text auf der Grundlinie und verkleinertem Text direkt darüber oder darunter besteht. Dieses Element enthält nicht das Wort „lim“, ermöglicht jedoch das Platzieren von Text oben oder unten im Ausdruck. So wird der Ausdruck

![todo:image_alt_text](powerpoint-math-equations_8.png)

erstellt mittels einer Kombination der Elemente [MathFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction) und [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit) wie folgt:

```cs
var funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));
var mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));
```


### **MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement‑Klassen**

- [MathSubscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsubscriptelement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsuperscriptelement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathrightsubsuperscriptelement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathleftsubsuperscriptelement)

Diese Klassen definieren einen tiefgestellten Index bzw. einen hochgestellten Index. Sie können sowohl Tief- als auch Hochstellung gleichzeitig auf der linken oder rechten Seite eines Arguments festlegen, jedoch wird ein einzelner Tief- oder Hochstellung nur auf der rechten Seite unterstützt. Die [MathSubscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsubscriptelement) kann außerdem verwendet werden, um den mathematischen Grad einer Zahl festzulegen.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **MathMatrix‑Klasse**

Die Klasse [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix) definiert das Matrix‑Objekt, das aus Kindelementen besteht, die in einer oder mehreren Zeilen und Spalten angeordnet sind. Es ist wichtig zu beachten, dass Matrizen keine eingebauten Begrenzungszeichen besitzen. Um die Matrix in Klammern zu setzen, verwenden Sie das Begrenzungszeichen‑Objekt [IMathDelimiter](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter). Null‑Argumente können verwendet werden, um Lücken in Matrizen zu erzeugen.

Beispiel: 

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **MathArray‑Klasse**

Die Klasse [MathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/matharray) definiert ein vertikales Array von Gleichungen oder beliebigen mathematischen Objekten.

Beispiel: 

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **Formatierung mathematischer Elemente**

- Die Klasse [MathBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathborderbox) zeichnet einen rechteckigen oder alternativen Rand um das [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement).

Beispiel: 

![todo:image_alt_text](powerpoint-math-equations_12.png)

- Die Klasse [MathBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathbox) gibt das logische Einrahmen (Verpacken) eines mathematischen Elements an. Ein eingekapseltes Objekt kann als Operator‑Emulator mit oder ohne Ausrichtungspunkt fungieren, als Zeilenumbruch‑Trigger dienen oder gruppiert werden, um Zeilenumbrüche innerhalb zu verhindern. Zum Beispiel sollte der Operator „==“ eingekapselt werden, um Zeilenumbrüche zu verhindern.

- Die Klasse [MathDelimiter](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimiter) definiert das Begrenzungszeichen‑Objekt, das aus öffnenden und schließenden Zeichen (wie Klammern, geschweiften Klammern, eckigen Klammern oder senkrechten Strichen) und einem oder mehreren mathematischen Elementen darin besteht, getrennt durch ein angegebenes Zeichen. Beispiele: (𝑥2); [𝑥2|𝑦2].

Beispiel: 

![todo:image_alt_text](powerpoint-math-equations_13.png)

- Die Klasse [MathAccent](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathaccent) definiert die Akzent‑Funktion, die aus einer Basis und einem kombinierenden diakritischen Zeichen besteht.

Beispiel: 𝑎́.

- Die Klasse [MathBar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathBar) definiert die Balken‑Funktion, die aus einem Basisargument und einem Über‑ oder Unterbalken besteht.

Beispiel: 

![todo:image_alt_text](powerpoint-math-equations_14.png)

- Die Klasse [MathGroupingCharacter](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathGroupingCharacter) definiert ein Gruppierungszeichen, das über oder unter einem Ausdruck platziert wird, typischerweise um die Beziehungen zwischen Elementen hervorzuheben.

Beispiel: 

![todo:image_alt_text](powerpoint-math-equations_15.png)

## **Mathematische Operationen**

Jedes mathematische Element und jeder mathematische Ausdruck (über [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)) implementiert das Interface [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement). Dies ermöglicht es, Operationen an der bestehenden Struktur durchzuführen und komplexere mathematische Ausdrücke zu bilden. Alle Operationen besitzen zwei Parameter‑Sätze: entweder [IMathElement]‑ oder Zeichenketten‑Argumente. Instanzen der Klasse [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathematicalText) werden implizit aus angegebenen Zeichenketten erstellt, wenn Zeichenketten‑Argumente verwendet werden. Die in Aspose.Slides verfügbaren mathematischen Operationen sind nachfolgend aufgeführt.

### **Join‑Methode**

- [Join(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/join/methods/1)
- [Join(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/join)

Diese Methoden verbinden ein mathematisches Element und bilden einen mathematischen Block. Zum Beispiel:

```cs
IMathElement element1 = new MathematicalText("x");
IMathElement element2 = new MathematicalText("y");

IMathBlock block = element1.Join(element2);
```


### **Divide‑Methode**

- [Divide(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/2)
- [Divide(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/divide)
- [Divide(String, MathFractionTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/3)
- [Divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/1)

Diese Methoden erstellen einen Bruch des angegebenen Typs mit einem Zähler und einem angegebenen Nenner. Zum Beispiel:

```cs
IMathElement numerator = new MathematicalText("x");
IMathFraction fraction = numerator.Divide("y", MathFractionTypes.Linear);
```


### **Enclose‑Methode**

- [Enclose()](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/enclose)
- [Enclose(Char, Char)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/enclose/methods/1)

Diese Methoden umschließen das Element mit angegebenen Zeichen, wie Klammern oder anderen Rahmenzeichen. Zum Beispiel:

```cs
IMathDelimiter delimiter = new MathematicalText("x"). Enclose('[', ']');
IMathDelimiter delimiter2 = new MathematicalText("elem1").Join("elem2").Enclose();
```


### **Function‑Methode**

- [Function(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/function/methods/1)
- [Function(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/function)

Diese Methoden erzeugen eine Funktion eines Arguments, wobei das aktuelle Objekt als Funktionsname verwendet wird. Zum Beispiel:

```cs
IMathFunction func = new MathematicalText("sin").Function("x");
```


### **AsArgumentOfFunction‑Methode**

- [AsArgumentOfFunction(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/4)
- [AsArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/asargumentoffunction)
- [AsArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/1)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/2)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/asargumentoffunction/methods/3)

Diese Methoden nehmen die angegebene Funktion unter Verwendung der aktuellen Instanz als Argument. Sie können:

- einen Zeichenketten‑Funktionsnamen angeben, z. B. "cos";
- einen vordefinierten Wert der Aufzählungen [MathFunctionsOfOneArgument](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunctionsofoneargument) oder [MathFunctionsOfTwoArguments](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunctionsoftwoarguments) auswählen, z. B. `MathFunctionsOfOneArgument.ArcSin`;
- die Instanz des [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement) auswählen.

Zum Beispiel:

```cs
var funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));
var func1 = new MathematicalText("2x").AsArgumentOfFunction(funcName);
var func2 = new MathematicalText("x").AsArgumentOfFunction("sin");
var func3 = new MathematicalText("x").AsArgumentOfFunction(MathFunctionsOfOneArgument.Sin);
var func4 = new MathematicalText("x").AsArgumentOfFunction(MathFunctionsOfTwoArguments.Log, "3")
```


### **SetSubscript-, SetSuperscript‑, SetSubSuperscriptOnTheRight‑ und SetSubSuperscriptOnTheLeft‑Methoden**

- [SetSubscript(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsubscript/methods/1)
- [SetSubscript(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsubscript)
- [SetSuperscript(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsuperscript/methods/1)
- [SetSuperscript(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsuperscript)
- [SetSubSuperscriptOnTheRight(String, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsubsuperscriptontheright/methods/1)
- [SetSubSuperscriptOnTheRight(IMathElement, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsubsuperscriptontheright)
- [SetSubSuperscriptOnTheLeft(String, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsubsuperscriptontheleft/methods/1)
- [SetSubSuperscriptOnTheLeft(IMathElement, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsubsuperscriptontheleft)

Diese Methoden setzen Tief- und Hochstellung. Sie können beide gleichzeitig auf der linken oder rechten Seite eines Arguments festlegen; ein einzelner Tief‑ oder Hochstellung ist jedoch nur auf der rechten Seite unterstützt. Der **Superscript** kann auch verwendet werden, um den mathematischen Grad einer Zahl festzulegen.

Beispiel:

```cs
var script = new MathematicalText("y").SetSubSuperscriptOnTheLeft("2x", "3z");
```


### **Radical‑Methode**

- [Radical(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/radical/methods/1)
- [Radical(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/radical)

Diese Methoden geben die mathematische Wurzel des angegebenen Grades basierend auf dem angegebenen Argument an.

Beispiel:

```cs
var radical = new MathematicalText("x").Radical("3");
```


### **SetUpperLimit‑ und SetLowerLimit‑Methoden**

- [SetUpperLimit(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setupperlimit/methods/1)
- [SetUpperLimit(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setupperlimit)
- [SetLowerLimit(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setlowerlimit/methods/1)
- [SetLowerLimit(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setlowerlimit)

Diese Methoden nehmen eine obere bzw. untere Grenze, wobei „upper“ und „lower“ die Position des Arguments relativ zur Basis angeben.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_8.png)

Solche Ausdrücke können durch eine Kombination der Klassen [MathFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathFunction) und [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathLimit) zusammen mit Operationen des Interfaces [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement) wie folgt erstellt werden:

```cs
var mathExpression = MathText.Create("lim").SetLowerLimit("x→∞").Function("x");
```


### **Nary‑ und Integral‑Methoden**

- [Nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/nary)
- [Nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/nary/methods/1)
- [Integral(MathIntegralTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/integral)
- [Integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/1)
- [Integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/methods/3)
- [Integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/methods/2)
- [Integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/integral/methods/4)

Beide **Nary**‑ und **Integral**‑Methoden erzeugen und geben den N‑ary‑Operator zurück, der durch den Typ [INaryOperator](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathnaryoperator) dargestellt wird. In der Nary‑Methode gibt die Aufzählung [MathNaryOperatorTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathnaryoperatortypes) den Operator‑Typ an – z. B. Summation oder Union – wobei Integrale ausgeschlossen sind. In der Integral‑Methode wird eine spezialisierte Operation für Integrale bereitgestellt, wobei die Aufzählung [MathIntegralTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathintegraltypes) verwendet wird.

Beispiel:

```cs
IMathBlock baseArg = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
IMathNaryOperator integral = baseArg.Integral(MathIntegralTypes.Simple, "0", "1");
```


### **ToMathArray‑Methode**

[ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/tomatharray) legt Elemente in ein vertikales Array. Wird dieser Vorgang an einer [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)-Instanz aufgerufen, werden alle Kind‑Elemente in das zurückgegebene Array platziert.

Beispiel:

```cs
var arrayFunction = new MathematicalText("x").Join("y").ToMathArray();
```


### **Formatierungs‑Operationen: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**

- [Accent](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/accent) legt ein Akzentzeichen (ein Zeichen oben am Element) fest.
- [Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/overbar) und [Underbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/underbar) legen einen Balken oben bzw. unten fest.
- [Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/group) legt in einer Gruppe ein Gruppierungszeichen wie eine geschweifte Klammer unten oder ein anderes Zeichen fest.
- [ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/toborderbox) legt ein Border‑Box‑Element fest.
- [ToBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/tobox) legt ein nicht‑visuelles Box‑Element (logische Gruppierung) fest.

Beispiele:

```cs
var accent = new MathematicalText("x").Accent('\u0303');
var bar = new MathematicalText("x").Overbar();
var groupChr = new MathematicalText("x").Join("y").Join("z").Group('\u23E1', MathTopBotPositions.Bottom, MathTopBotPositions.Top);
var borderBox = new MathematicalText("x+y+z").ToBorderBox();
var boxedOperator = new MathematicalText(":=").ToBox();
```


## **FAQ**

**Wie kann ich einer PowerPoint‑Folien eine mathematische Gleichung hinzufügen?**

Um eine mathematische Gleichung hinzuzufügen, müssen Sie ein `MathShape`‑Objekt erstellen, das automatisch einen mathematischen Teil enthält. Anschließend rufen Sie das `MathParagraph` aus dem `MathPortion` ab und fügen `MathBlock`‑Objekte hinzu.

**Ist es möglich, komplexe verschachtelte mathematische Ausdrücke zu erstellen?**

Ja, Aspose.Slides ermöglicht das Erstellen komplexer mathematischer Ausdrücke durch Verschachteln von MathBlocks. Jedes mathematische Element implementiert das Interface `IMathElement`, das die Anwendung von Operationen (Join, Divide, Enclose usw.) erlaubt, um Elemente zu komplexeren Strukturen zu kombinieren.

**Wie kann ich eine vorhandene mathematische Gleichung aktualisieren oder ändern?**

Um eine Gleichung zu aktualisieren, müssen Sie über das `MathParagraph` auf die bestehenden MathBlocks zugreifen. Anschließend können Sie mithilfe von Methoden wie Join, Divide, Enclose und anderen einzelne Elemente der Gleichung bearbeiten. Nach der Bearbeitung speichern Sie die Präsentation, um die Änderungen anzuwenden.