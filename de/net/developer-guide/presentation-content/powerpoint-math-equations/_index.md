---
title: Mathematische Gleichungen zu PowerPoint-Präsentationen in .NET hinzufügen
linktitle: PowerPoint Mathematische Gleichungen
type: docs
weight: 80
url: /de/net/powerpoint-math-equations/
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
- .NET
- C#
- Aspose.Slides
description: "Mathematische Gleichungen in PowerPoint PPT und PPTX mit Aspose.Slides für .NET einfügen und bearbeiten, unterstützt OMML, Formatierungsoptionen und klare C#-Code-Beispiele."
---

## **Übersicht**

In PowerPoint können Sie eine mathematische Gleichung oder Formel schreiben und in Ihrer Präsentation anzeigen. Verschiedene mathematische Symbole stehen zur Verfügung und können zu Text oder Gleichungen hinzugefügt werden. Der Konstruktor für mathematische Gleichungen wird verwendet, um komplexe Formeln zu erstellen, wie zum Beispiel:

- Mathematischer Bruch
- Mathematischer Radikal
- Mathematische Funktion
- Grenzen und Log‑Funktionen
- N‑äre Operationen
- Matrix
- Große Operatoren
- Sin‑, Cos‑Funktionen

Um eine mathematische Gleichung in PowerPoint hinzuzufügen, wird das Menü *Einfügen → Gleichung* verwendet:

![todo:image_alt_text](powerpoint-math-equations_1.png)

Damit wird ein mathematischer Text in XML erzeugt, der in PowerPoint wie folgt angezeigt wird: 

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint unterstützt eine breite Palette mathematischer Symbole zum Erstellen von Gleichungen. Das Erzeugen komplexer mathematischer Gleichungen in PowerPoint liefert jedoch oft kein gepflegtes, professionelles Ergebnis. Daher greifen Nutzer, die häufig mathematische Präsentationen erstellen, häufig zu Drittanbieter‑Lösungen für besser aussehende Formeln.

Mit der [**Aspose.Slides API**](https://products.aspose.com/slides/net/) können Sie programmgesteuert in C# mit mathematischen Gleichungen in PowerPoint‑Präsentationen arbeiten. Sie können neue mathematische Ausdrücke erstellen oder zuvor erstellte bearbeiten. Teilweise wird das Exportieren mathematischer Strukturen als Bilder unterstützt.

## **So erstellen Sie eine mathematische Gleichung**

Mathematische Elemente werden verwendet, um jede mathematische Konstruktion aufzubauen, unabhängig von der Verschachtelungstiefe. Eine lineare Sammlung dieser Elemente bildet einen mathematischen Block, dargestellt durch die Klasse [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock). Die Klasse [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock) repräsentiert einen eigenständigen mathematischen Ausdruck, eine Formel oder Gleichung. [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion) wird verwendet, um mathematischen Text zu halten (unterscheidet sich von der regulären Klasse [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion)), während [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph) es Ihnen ermöglicht, eine Menge von [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)-Objekten zu manipulieren. Diese Klassen sind für die Arbeit mit PowerPoint‑Mathe‑Gleichungen über die Aspose.Slides‑API unverzichtbar.

Sehen wir uns an, wie wir die folgende mathematische Gleichung mit der Aspose.Slides‑API erstellen können:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Um einen mathematischen Ausdruck zur Folie hinzuzufügen, fügen Sie zunächst eine Form hinzu, die den mathematischen Text enthalten wird:
```cs
using (var presentation = new Presentation())
{
    var mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);
}
```


Nach dem Erstellen der Form enthält sie standardmäßig bereits einen Absatz mit einer mathematischen Portion. Die Klasse [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion) repräsentiert eine Portion, die mathematischen Text enthält. Um auf den mathematischen Inhalt einer [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion) zuzugreifen, verwenden Sie die Variable [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph):
```cs
var mathParagraph = (mathShape.TextFrame.Paragraphs[0].Portions[0] as MathPortion).MathParagraph;
```


Die Klasse [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph) ermöglicht das Lesen, Hinzufügen, Bearbeiten und Löschen von Math‑Blöcken ([MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)), die aus einer Kombination mathematischer Elemente bestehen. Beispiel: Erstellen Sie einen Bruch und platzieren Sie ihn in der Präsentation:
```cs
var fraction = new MathematicalText("x").Divide("y");

mathParagraph.Add(new MathBlock(fraction));
```


Jedes mathematische Element wird durch eine Klasse repräsentiert, die das Interface [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement) implementiert. Dieses Interface stellt zahlreiche Methoden bereit, um mathematische Ausdrücke leicht zu erzeugen, sodass Sie mit nur einer einzigen Code‑Zeile recht komplexe Gleichungen zusammenstellen können. Beispiel: Der Satz des Pythagoras sieht so aus:
```cs
var mathBlock = new MathematicalText("c")
    .SetSuperscript("2")
    .Join("=")
    .Join(new MathematicalText("a").SetSuperscript("2"))
    .Join("+")
    .Join(new MathematicalText("b").SetSuperscript("2"));
```


Operationen des Interfaces [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement) sind in jedem Elementtyp, einschließlich der Klasse [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock), implementiert.

Unten finden Sie das vollständige Beispiel‑Quellcode:
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


## **Mathematische Elementtypen**

Mathematische Ausdrücke setzen sich aus Sequenzen mathematischer Elemente zusammen. Ein mathematischer Block repräsentiert eine solche Sequenz, und die Argumente dieser Elemente bilden eine verschachtelte, baumartige Struktur.

Es gibt viele Typen mathematischer Elemente, die zum Aufbau eines mathematischen Blocks verwendet werden können. Jeder dieser Typen kann in einem anderen aggregiert werden, wodurch eine baumartige Struktur entsteht. Der einfachste Elementtyp ist einer, der keine weiteren mathematischen Textelemente enthält.

Jeder Elementtyp implementiert das Interface [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement), sodass Sie einen gemeinsamen Satz von mathematischen Operationen auf unterschiedliche Elementtypen anwenden können.

### **Klasse MathematicalText**

Die Klasse [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext) stellt einen mathematischen Text dar – das grundlegende Element aller mathematischen Konstruktionen. Mathematischer Text kann Operanden und Operatoren, Variablen oder beliebigen linearen Text darstellen.

Beispiel: 𝑎=𝑏+𝑐

### **Klasse MathFraction**

Die Klasse [MathFraction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfraction) definiert ein Bruch‑Objekt bestehend aus Zähler und Nenner, getrennt durch einen Bruchstrich. Der Bruchstrich kann horizontal oder diagonal sein, abhängig von den Bruch‑Eigenschaften. Das Bruch‑Objekt wird auch für die Stapelfunktion verwendet, bei der ein Element über ein anderes ohne Bruchstrich gesetzt wird.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **Klasse MathRadical**

Die Klasse [MathRadical](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathradical) definiert die Radikal‑Funktion (Mathematische Wurzel), bestehend aus einer Basis und einem optionalen Grad.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **Klasse MathFunction**

Die Klasse [MathFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction) definiert eine Funktion eines Arguments. Sie enthält Eigenschaften wie [Name](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction/properties/name), das den Funktionsnamen repräsentiert, und [Base](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction/properties/base), das das Funktionsargument darstellt.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **Klasse MathNaryOperator**

Die Klasse [MathNaryOperator](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathnaryoperator) definiert ein N‑äres mathematisches Objekt, wie Summation oder Integral. Sie besteht aus einem Operator, einer Basis (oder einem Operanden) und optionalen oberen und unteren Grenzen. Beispiele für N‑äre Operatoren sind Summation, Vereinigung, Schnittmenge und Integral.

Diese Klasse schließt einfache Operatoren wie Addition, Subtraktion usw. nicht ein. Diese werden durch ein einzelnes Text‑[MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathematicaltext) dargestellt.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **Klasse MathLimit**

Die Klasse [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit) erzeugt obere oder untere Grenzen. Sie definiert das Grenzen‑Objekt, das Text auf der Grundlinie und verkleinerten Text unmittelbar darüber bzw. darunter enthält. Dieses Element beinhaltet nicht das Wort „lim“, ermöglicht aber das Platzieren von Text oben oder unten im Ausdruck. Der Ausdruck

![todo:image_alt_text](powerpoint-math-equations_8.png)

wird mithilfe einer Kombination der Elemente [MathFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunction) und [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathlimit) wie folgt erstellt:
```cs
var funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑥→∞"));
var mathFunc = new MathFunction(funcName, new MathematicalText("𝑥"));
```


### **Klassen MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**

- [MathSubscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsubscriptelement)
- [MathSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsuperscriptelement)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathrightsubsuperscriptelement)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathleftsubsuperscriptelement)

Diese Klassen definieren einen tiefen bzw. hohen Index. Sie können sowohl Tief‑ als auch Hochindex gleichzeitig auf der linken oder rechten Seite eines Arguments setzen, wobei ein einzelner Tief‑ oder Hochindex nur auf der rechten Seite unterstützt wird. Der [MathSubscriptElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathsubscriptelement) kann zudem verwendet werden, um den mathematischen Grad einer Zahl festzulegen.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **Klasse MathMatrix**

Die Klasse [MathMatrix](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathmatrix) definiert das Matrix‑Objekt, das aus Kindelementen besteht, die in einer oder mehreren Zeilen und Spalten angeordnet sind. Wichtig: Matrizen besitzen keine integrierten Begrenzungszeichen. Um die Matrix in Klammern zu setzen, verwenden Sie das Begrenzungs‑Objekt [IMathDelimiter](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathdelimiter). Null‑Argumente können verwendet werden, um Lücken in Matrizen zu erzeugen.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **Klasse MathArray**

Die Klasse [MathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/matharray) definiert ein vertikales Array von Gleichungen oder beliebigen mathematischen Objekten.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **Formatierung mathematischer Elemente**

- Klasse [MathBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathborderbox): Zeichnet einen rechteckigen oder alternativen Rahmen um das [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement).

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_12.png)

- Klasse [MathBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathbox): Definiert die logische Box‑Umhüllung eines mathematischen Elements. Ein „geboxtes“ Objekt kann als Operator‑Emulator dienen – mit oder ohne Ausrichtungspunkt – als Zeilenumbruch‑Marker oder gruppiert werden, um Zeilenumbrüche innerhalb zu verhindern. Beispiel: Der Operator „==“ sollte ge‑boxed werden, um Zeilenumbrüche zu vermeiden.

- Klasse [MathDelimiter](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathdelimiter): Definiert das Begrenzungs‑Objekt, das Öffnungs‑ und Schließzeichen (z. B. Klammern, geschweifte Klammern, eckige Klammern oder senkrechte Striche) sowie ein oder mehrere mathematische Elemente darin enthält, getrennt durch ein angegebenes Zeichen. Beispiele: (𝑥2); [𝑥2|𝑦2].

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_13.png)

- Klasse [MathAccent](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathaccent): Definiert die Akzent‑Funktion, die aus einer Basis und einem kombinierenden diakritischen Zeichen besteht.

Beispiel: 𝑎́.

- Klasse [MathBar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathBar): Definiert die Balken‑Funktion, die aus einem Basis‑Argument und einem Über‑ oder Unterbalken besteht.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_14.png)

- Klasse [MathGroupingCharacter](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathGroupingCharacter): Definiert ein Gruppierungszeichen, das über oder unter einem Ausdruck platziert wird, typischerweise um Beziehungen zwischen Elementen hervorzuheben.

Beispiel:

![todo:image_alt_text](powerpoint-math-equations_15.png)

## **Mathematische Operationen**

Jedes mathematische Element und jeder mathematische Ausdruck (via [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)) implementiert das Interface [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement). Damit können Sie Operationen auf der bestehenden Struktur ausführen und komplexere Ausdrücke bilden. Alle Operationen besitzen zwei Parameter‑Varianten: entweder [IMathElement]‑ oder String‑Argumente. Instanzen der Klasse [MathematicalText](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathematicalText) werden implizit aus angegebenen Strings erzeugt, wenn String‑Argumente verwendet werden. Die in Aspose.Slides verfügbaren mathematischen Operationen sind nachfolgend aufgelistet.

### **Methode Join**

- [Join(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/join/methods/1)
- [Join(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/join)

Diese Methoden verknüpfen ein mathematisches Element und bilden einen mathematischen Block. Beispiel:
```cs
IMathElement element1 = new MathematicalText("x");
IMathElement element2 = new MathematicalText("y");

IMathBlock block = element1.Join(element2);
```


### **Methode Divide**

- [Divide(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/2)
- [Divide(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/divide)
- [Divide(String,MathFractionTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/3)
- [Divide(IMathElement,MathFractionTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/divide/methods/1)

Diese Methoden erzeugen einen Bruch des angegebenen Typs mit Zähler und angegebenem Nenner. Beispiel:
```cs
IMathElement numerator = new MathematicalText("x");
IMathFraction fraction = numerator.Divide("y", MathFractionTypes.Linear);
```


### **Methode Enclose**

- [Enclose()](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/enclose)
- [Enclose(Char,Char)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/enclose/methods/1)

Diese Methoden umschließen das Element mit angegebenen Zeichen, z. B. Klammern oder anderen Rahmenzeichen. Beispiel:
```cs
IMathDelimiter delimiter = new MathematicalText("x"). Enclose('[', ']');
IMathDelimiter delimiter2 = new MathematicalText("elem1").Join("elem2").Enclose();
```


### **Methode Function**

- [Function(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/function/methods/1)
- [Function(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/function)

Diese Methoden erzeugen eine Funktion eines Arguments, wobei das aktuelle Objekt als Funktionsname verwendet wird. Beispiel:
```cs
IMathFunction func = new MathematicalText("sin").Function("x");
```


### **Methode AsArgumentOfFunction**

- [AsArgumentOfFunction(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/4)
- [AsArgumentOfFunction(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/asargumentoffunction)
- [AsArgumentOfFunction(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/1)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments,IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/2)
- [AsArgumentOfFunction(MathFunctionsOfTwoArguments,String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/asargumentoffunction/methods/3)

Diese Methoden verwenden das aktuelle Objekt als Argument einer angegebenen Funktion. Sie können:

- Einen String als Funktionsnamen angeben, z. B. „cos“;
- Einen der vordefinierten Werte der Enumerationen [MathFunctionsOfOneArgument](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunctionsofoneargument) oder [MathFunctionsOfTwoArguments](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathfunctionsoftwoarguments) auswählen, z. B. `MathFunctionsOfOneArgument.ArcSin`;
- Die Instanz des [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement) übergeben.

Beispiel:
```cs
var funcName = new MathLimit(new MathematicalText("lim"), new MathematicalText("𝑛→∞"));
var func1 = new MathematicalText("2x").AsArgumentOfFunction(funcName);
var func2 = new MathematicalText("x").AsArgumentOfFunction("sin");
var func3 = new MathematicalText("x").AsArgumentOfFunction(MathFunctionsOfOneArgument.Sin);
var func4 = new MathematicalText("x").AsArgumentOfFunction(MathFunctionsOfTwoArguments.Log, "3")
```


### **Methoden SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft**

- [SetSubscript(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsubscript/methods/1)
- [SetSubscript(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsubscript)
- [SetSuperscript(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsuperscript/methods/1)
- [SetSuperscript(IMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsuperscript)
- [SetSubSuperscriptOnTheRight(String,String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsubsuperscriptontheright/methods/1)
- [SetSubSuperscriptOnTheRight(IMMathElement,IMMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsubsuperscriptontheright)
- [SetSubSuperscriptOnTheLeft(String,String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setsubsuperscriptontheleft/methods/1)
- [SetSubSuperscriptOnTheLeft(IMMathElement,IMMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setsubsuperscriptontheleft)

Diese Methoden setzen Tief‑ bzw. Hochindizes. Sie können beide gleichzeitig auf der linken oder rechten Seite des Arguments setzen; ein einzelner Tief‑ oder Hochindex wird jedoch nur auf der rechten Seite unterstützt. Der **Superscript** kann zudem verwendet werden, um den mathematischen Grad einer Zahl festzulegen.

Beispiel:
```cs
var script = new MathematicalText("y").SetSubSuperscriptOnTheLeft("2x", "3z");
```


### **Methode Radical**

- [Radical(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/radical/methods/1)
- [Radical(IMMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/radical)

Diese Methoden geben die mathematische Wurzel des angegebenen Grades basierend auf dem übergebenen Argument an.

Beispiel:
```cs
var radical = new MathematicalText("x").Radical("3");
```


### **Methoden SetUpperLimit und SetLowerLimit**

- [SetUpperLimit(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setupperlimit/methods/1)
- [SetUpperLimit(IMMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setupperlimit)
- [SetLowerLimit(String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/setlowerlimit/methods/1)
- [SetLowerLimit(IMMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/setlowerlimit)

Diese Methoden setzen eine obere bzw. untere Grenze, wobei „upper“ bzw. „lower“ die Position des Arguments relativ zur Basis angibt.

Betrachten wir den Ausdruck:

![todo:image_alt_text](powerpoint-math-equations_8.png)

Solche Ausdrücke können durch eine Kombination der Klassen [MathFunction](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathFunction) und [MathLimit](https://reference.aspose.com/slides/net/aspose.slides.mathtext/MathLimit) zusammen mit Operationen des Interfaces [IMathElement](https://reference.aspose.com/slides/net/aspose.slides.mathtext/IMathElement) wie folgt erstellt werden:
```cs
var mathExpression = MathText.Create("lim").SetLowerLimit("x→∞").Function("x");
```


### **Methoden Nary und Integral**

- [Nary(MathNaryOperatorTypes,IMMathElement,IMMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/nary)
- [Nary(MathNaryOperatorTypes,String,String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/nary/methods/1)
- [Integral(MathIntegralTypes)](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/integral)
- [Integral(MathIntegralTypes,IMMathElement,IMMathElement)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/1)
- [Integral(MathIntegralTypes,String,String)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/3)
- [Integral(MathIntegralTypes,IMMathElement,IMMathElement,MathLimitLocations)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/2)
- [Integral(MathIntegralTypes,String,String,MathLimitLocations)](https://reference.aspose.com/slides/net/aspose.slides.mathtext.imathelement/integral/methods/4)

Beide Methoden, **Nary** und **Integral**, erzeugen und geben den N‑ary‑Operator zurück, der vom Typ [INaryOperator](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathnaryoperator) ist. In der Nary‑Methode gibt die Enumeration [MathNaryOperatorTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathnaryoperatortypes) den Operator‑Typ an – z. B. Summation oder Union – jedoch keine Integrale. In der Integral‑Methode wird ein spezialisierter Vorgang für Integrale bereitgestellt, wobei die Enumeration [MathIntegralTypes](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathintegraltypes) verwendet wird.

Beispiel:
```cs
IMathBlock baseArg = new MathematicalText("x").Join(new MathematicalText("dx").ToBox());
IMathNaryOperator integral = baseArg.Integral(MathIntegralTypes.Simple, "0", "1");
```


### **Methode ToMathArray**

[ToMathArray](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/tomatharray) legt Elemente in ein vertikales Array. Wird diese Operation an einer [MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock)-Instanz aufgerufen, werden alle Kind‑Elemente in das zurückgegebene Array eingefügt.

Beispiel:
```cs
var arrayFunction = new MathematicalText("x").Join("y").ToMathArray();
```


### **Formatierungsoperationen: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**

- Methode **Accent** ([Accent](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/accent)) setzt ein Akzentzeichen (ein Zeichen oben am Element).
- Methoden **Overbar** ([Overbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/overbar)) und **Underbar** ([Underbar](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/underbar)) setzen einen Balken oben bzw. unten.
- Methode **Group** ([Group](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/group)) legt das Element in einer Gruppe mithilfe eines Gruppierungszeichens, z. B. einer unteren geschweiften Klammer, ab.
- Methode **ToBorderBox** ([ToBorderBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/toborderbox)) legt das Element in einer Rand‑Box ab.
- Methode **ToBox** ([ToBox](https://reference.aspose.com/slides/net/aspose.slides.mathtext/imathelement/methods/tobox)) legt das Element in einer nicht‑visuellen Box (logische Gruppierung) ab.

Beispiele:
```cs
var accent = new MathematicalText("x").Accent('\u0303');
var bar = new MathematicalText("x").Overbar();
var groupChr = new MathematicalText("x").Join("y").Join("z").Group('\u23E1', MathTopBotPositions.Bottom, MathTopBotPositions.Top);
var borderBox = new MathematicalText("x+y+z").ToBorderBox();
var boxedOperator = new MathematicalText(":=").ToBox();
```


## **FAQ**

**Wie füge ich einer PowerPoint‑Folie eine mathematische Gleichung hinzu?**

Um eine mathematische Gleichung hinzuzufügen, erstellen Sie ein `MathShape`‑Objekt, das automatisch eine mathematische Portion enthält. Anschließend rufen Sie das `MathParagraph` aus der `MathPortion` ab und fügen `MathBlock`‑Objekte hinzu.

**Ist es möglich, komplex verschachtelte mathematische Ausdrücke zu erstellen?**

Ja, Aspose.Slides erlaubt das Erstellen komplexer mathematischer Ausdrücke durch Verschachteln von MathBlocks. Jedes mathematische Element implementiert das Interface `IMathElement`, mit dem Sie Operationen (Join, Divide, Enclose usw.) anwenden können, um Elemente zu komplexeren Strukturen zu kombinieren.

**Wie kann ich eine vorhandene mathematische Gleichung aktualisieren oder ändern?**

Um eine Gleichung zu aktualisieren, greifen Sie über das `MathParagraph` auf die bestehenden MathBlocks zu. Dann können Sie Methoden wie Join, Divide, Enclose usw. verwenden, um einzelne Elemente der Gleichung zu verändern. Nach der Bearbeitung speichern Sie die Präsentation, um die Änderungen zu übernehmen.