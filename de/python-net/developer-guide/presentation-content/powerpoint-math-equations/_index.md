---
title: Mathformeln zu PowerPoint-Präsentationen in Python hinzufügen
linktitle: Mathematische Gleichungen
type: docs
weight: 80
url: /de/python-net/powerpoint-math-equations/
keywords:
- Mathematische Gleichung
- PowerPoint-Mathematikgleichung
- Mathematisches Symbol
- PowerPoint-Mathematiksymbol
- Mathematische Formel
- PowerPoint-Mathematikformel
- Mathe-Text
- PowerPoint-Mathe-Text
- Mathegleichung zu PowerPoint hinzufügen
- Mathe-Symbol zu PowerPoint hinzufügen
- Matheformel zu PowerPoint hinzufügen
- Mathe-Text zu PowerPoint hinzufügen
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie mit mathematischen Gleichungen in PowerPoint mithilfe von Aspose.Slides für Python über .NET arbeiten. Erhalten Sie detaillierte Anleitungen, Code-Beispiele und Tipps zur Automatisierung der Erstellung und Bearbeitung von Präsentationen."
---

## **Übersicht**

In PowerPoint können Sie eine mathematische Gleichung oder Formel schreiben und in Ihrer Präsentation anzeigen. Verschiedene mathematische Symbole stehen zur Verfügung und können zu Text oder Gleichungen hinzugefügt werden. Der Konstruktor für mathematische Gleichungen wird verwendet, um komplexe Formeln zu erstellen, wie zum Beispiel:

- Mathematischer Bruch
- Mathematisches Radikal
- Mathematische Funktion
- Grenzwerte und Logarithmusfunktionen
- N‑äre Operationen
- Matrix
- Große Operatoren
- Sinus‑, Kosinus‑Funktionen

Um in PowerPoint eine mathematische Gleichung hinzuzufügen, wird das *Einfügen -> Gleichung* Menü verwendet:

![todo:image_alt_text](powerpoint-math-equations_1.png)

Damit wird ein mathematischer Text in XML erstellt, der in PowerPoint wie folgt angezeigt werden kann:

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint unterstützt eine breite Palette mathematischer Symbole zum Erstellen von Gleichungen. Das Erzeugen komplexer mathematischer Gleichungen in PowerPoint liefert jedoch häufig kein poliertes, professionelles Ergebnis. Daher greifen Nutzer, die häufig mathematische Präsentationen erstellen, oft zu Drittanbieter‑Lösungen für besser aussehende Formeln.

Mit der [**Aspose.Slides API**](https://products.aspose.com/slides/python-net/) können Sie programmgesteuert in Python mit mathematischen Gleichungen in PowerPoint‑Präsentationen arbeiten. Erstellen Sie neue mathematische Ausdrücke oder bearbeiten Sie bereits erstellte. Teilweise Unterstützung ist für den Export mathematischer Strukturen als Bilder verfügbar.

## **So erstellen Sie eine mathematische Gleichung**

Mathematische Elemente werden verwendet, um jede mathematische Konstruktion aufzubauen, unabhängig von der Verschachtelungstiefe. Eine lineare Sammlung dieser Elemente bildet einen mathematischen Block, der durch die Klasse [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) repräsentiert wird. Die Klasse [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) stellt einen eigenständigen mathematischen Ausdruck, eine Formel oder Gleichung dar. [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) wird verwendet, um mathematischen Text zu halten (unterschiedlich zur regulären Klasse [Portion](https://reference.aspose.com/slides/python-net/aspose.slides/portion/)), während [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) Ihnen ermöglicht, eine Menge von [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)-Objekten zu manipulieren. Diese Klassen sind essentiell für die Arbeit mit mathematischen Gleichungen in PowerPoint über die Aspose.Slides‑API.

Sehen wir uns an, wie wir die folgende mathematische Gleichung mit der Aspose.Slides‑API erstellen können:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Um einen mathematischen Ausdruck zur Folie hinzuzufügen, fügen Sie zunächst eine Form hinzu, die den mathematischen Text enthält:

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    math_shape = presentation.slides[0].shapes.add_math_shape(0, 0, 720, 150)
```


Nach dem Erstellen der Form enthält sie standardmäßig bereits einen Absatz mit einem mathematischen Abschnitt. Die Klasse [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) repräsentiert einen Abschnitt, der mathematischen Text enthält. Um auf den mathematischen Inhalt innerhalb einer [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) zuzugreifen, beziehen Sie sich auf die Variable [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/):

```py
math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph
```


Die Klasse [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) ermöglicht das Lesen, Hinzufügen, Bearbeiten und Löschen von mathematischen Blöcken ([MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)), die aus einer Kombination mathematischer Elemente bestehen. Beispiel: Erstellen Sie einen Bruch und fügen Sie ihn in die Präsentation ein:

```py
fraction = math.MathematicalText("x").divide("y")
math_paragraph.add(math.MathBlock(fraction))
```


Operationen des Interfaces [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) sind in jedem Elementtyp implementiert, einschließlich der Klasse [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/).

Unten finden Sie das vollständige Quellcodebeispiel:

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    math_shape = presentation.slides[0].shapes.add_math_shape(0, 0, 720, 150)

    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    fraction = math.MathematicalText("x").divide("y")
    math_paragraph.add(math.MathBlock(fraction))

    math_block = (
        math.MathematicalText("c").set_superscript("2").
            join("=").
            join(math.MathematicalText("a").set_superscript("2")).
            join("+").
            join(math.MathematicalText("b").set_superscript("2")))

    math_paragraph.add(math_block)

    presentation.save("math.pptx", slides.export.SaveFormat.PPTX)
```


## **Typen mathematischer Elemente**

Mathematische Ausdrücke setzen sich aus Sequenzen mathematischer Elemente zusammen. Ein mathematischer Block stellt eine solche Sequenz dar, und die Argumente dieser Elemente bilden eine verschachtelte, baumartige Struktur.

Es gibt viele Arten mathematischer Elemente, die zum Aufbau eines mathematischen Blocks verwendet werden können. Jedes dieser Elemente kann in einem anderen aggregiert werden und bildet so eine baumartige Struktur. Der einfachste Elementtyp ist einer, der keine anderen mathematischen Textelemente enthält.

Jeder Typ eines mathematischen Elements implementiert das Interface [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/), wodurch Sie einen gemeinsamen Satz von mathematischen Operationen auf verschiedene Elementtypen anwenden können.

### **MathematicalText‑Klasse**

Die Klasse [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) repräsentiert einen mathematischen Text – das zugrunde liegende Element aller mathematischen Konstruktionen. Mathematischer Text kann Operanden und Operatoren, Variablen oder beliebigen anderen linearen Text darstellen.

Example: 𝑎=𝑏+𝑐

### **MathFraction‑Klasse**

Die Klasse [MathFraction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfraction/) definiert ein Bruchobjekt, das aus Zähler und Nenner besteht, getrennt durch einen Bruchstrich. Der Bruchstrich kann horizontal oder diagonal sein, abhängig von den Bruch‑Eigenschaften. Das Bruchobjekt wird auch verwendet, um die Stapelfunktion darzustellen, bei der ein Element über einem anderen ohne Bruchstrich platziert wird.

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **MathRadical‑Klasse**

Die Klasse [MathRadical](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathradical/) spezifiziert die Radikal‑Funktion (mathematische Wurzel), die aus einer Basis und einem optionalen Grad besteht.

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **MathFunction‑Klasse**

Die Klasse [MathFunction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) definiert eine Funktion eines Arguments. Sie enthält Eigenschaften wie [name](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/name/), die den Funktionsnamen repräsentiert, und [base](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/base/), die das Funktionsargument darstellt.

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **MathNaryOperator‑Klasse**

Die Klasse [MathNaryOperator](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperator/) spezifiziert ein n‑äres mathematisches Objekt, z. B. eine Summation oder ein Integral. Sie besteht aus einem Operator, einer Basis (oder Operanden) und optionalen oberen und unteren Grenzen. Beispiele für n‑äre Operatoren sind Summation, Vereinigung, Schnittmenge und Integral.

Diese Klasse enthält keine einfachen Operatoren wie Addition, Subtraktion usw.; diese werden durch ein einzelnes Text‑[MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) dargestellt.

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **MathLimit‑Klasse**

Die Klasse [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) erzeugt die obere oder untere Grenze. Sie definiert das Grenz­objekt, das aus Text auf der Grundlinie und verkleinertem Text unmittelbar darüber bzw. darunter besteht. Dieses Element enthält nicht das Wort „lim“, ermöglicht jedoch das Platzieren von Text über oder unter dem Ausdruck. So wird der Ausdruck  

![todo:image_alt_text](powerpoint-math-equations_8.png)

mit einer Kombination aus [MathFunction](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunction/) und [MathLimit](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathlimit/) Elementen erzeugt:

```py
function_name = math.MathLimit(math.MathematicalText("lim"), math.MathematicalText("𝑥→∞"))
math_function = math.MathFunction(function_name, math.MathematicalText("𝑥"))
```


### **MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement‑Klassen**

- [MathSubscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsubscriptelement/)
- [MathSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsuperscriptelement/)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathrightsubsuperscriptelement/)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathleftsubsuperscriptelement/)

Diese Klassen definieren einen tiefgestellten oder hochgestellten Index. Sie können sowohl Tief- als auch Hochstellung gleichzeitig auf der linken oder rechten Seite eines Arguments setzen, jedoch wird ein einzelner Tief- oder Hochindex nur auf der rechten Seite unterstützt. Die [MathSubscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsubscriptelement/) kann zudem verwendet werden, um den mathematischen Grad einer Zahl festzulegen.

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **MathMatrix‑Klasse**

Die Klasse [MathMatrix](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathmatrix/) definiert das Matrix‑Objekt, das aus Kindelementen besteht, die in einer oder mehreren Zeilen und Spalten angeordnet sind. Wichtig ist, dass Matrizen keine integrierten Begrenzungszeichen besitzen. Um die Matrix in Klammern zu setzen, verwenden Sie das Begrenzungs‑Objekt [MathDelimiter](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/). Null‑Argumente können verwendet werden, um Lücken in Matrizen zu erzeugen.

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **MathArray‑Klasse**

Die Klasse [MathArray](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/matharray/) definiert ein vertikales Array von Gleichungen oder beliebigen mathematischen Objekten.

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **Formatierung mathematischer Elemente**

- [MathBorderBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/)‑Klasse: Zeichnet einen rechteckigen oder alternativen Rahmen um das [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/).

  ![todo:image_alt_text](powerpoint-math-equations_12.png)

- [MathBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathbox/)‑Klasse: Gibt die logische Verpackung (Boxing) eines mathematischen Elements an. Ein boxed‑Objekt kann als Operator‑Emulator dienen – mit oder ohne Ausrichtungspunkt – als Zeilenumbruch‑Auslöser fungieren oder gruppiert werden, um Zeilenumbrüche innerhalb zu verhindern. Beispiel: Der Operator „==“ sollte in einer Box platziert werden, um Zeilenumbrüche zu verhindern.

- [MathDelimiter](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/)‑Klasse: Gibt das Begrenzungs‑Objekt an, das aus öffnenden und schließenden Zeichen (wie Klammern, geschweiften Klammern, eckigen Klammern oder vertikalen Strichen) sowie einem oder mehreren mathematischen Elementen darin, getrennt durch ein angegebenes Zeichen, besteht. Beispiele: (𝑥2); [𝑥2|𝑦2].

  ![todo:image_alt_text](powerpoint-math-equations_13.png)

- [MathAccent](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathaccent/)‑Klasse: Gibt die Akzent‑Funktion an, die aus einer Basis und einem kombinierenden diakritischen Zeichen besteht.

  Beispiel: 𝑎́.

- [MathBar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathBar/)‑Klasse: Gibt die Balken‑Funktion an, die aus einem Basisargument und einem Über‑ bzw. Unterbalken besteht.

  ![todo:image_alt_text](powerpoint-math-equations_14.png)

- [MathGroupingCharacter](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathGroupingCharacter/)‑Klasse: Gibt ein Gruppierungszeichen an, das über oder unter einem Ausdruck platziert wird, typischerweise um Beziehungen zwischen Elementen hervorzuheben.

  ![todo:image_alt_text](powerpoint-math-equations_15.png)

## **Mathematische Operationen**

Jedes mathematische Element und jeder mathematische Ausdruck (via [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)) implementiert das Interface [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/). Dies ermöglicht es, Operationen auf der bestehenden Struktur auszuführen und komplexere mathematische Ausdrücke zu bilden. Alle Operationen besitzen zwei Parameter‑Sätze: entweder [IMathElement] oder Zeichenkettenargumente. Instanzen der Klasse [MathematicalText](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathematicaltext/) werden implizit aus angegebenen Zeichenketten erstellt, wenn Zeichenketten‑Argumente verwendet werden. Die in Aspose.Slides verfügbaren mathematischen Operationen sind unten aufgeführt.

### **Join‑Methode**

Diese Methoden verbinden ein mathematisches Element und bilden einen mathematischen Block. Beispiel:

```py
element1 = math.MathematicalText("x")
element2 = math.MathematicalText("y")
block = element1.join(element2)
```


### **Divide‑Methode**

Diese Methoden erzeugen einen Bruch des angegebenen Typs mit einem Zähler und einem angegebenen Nenner. Beispiel:

```py
numerator = math.MathematicalText("x")
fraction = numerator.divide("y", math.MathFractionTypes.LINEAR)
```


### **Enclose‑Methode**

Diese Methoden umschließen das Element in angegebenen Zeichen, wie Klammern oder anderen Begrenzungszeichen. Beispiel:

```py
delimiter = math.MathematicalText("x").enclose('[', ']')
delimiter2 = math.MathematicalText("elem1").join("elem2").enclose()
```


### **Function‑Methode**

Diese Methoden erzeugen eine Funktion eines Arguments, wobei das aktuelle Objekt als Funktionsname verwendet wird. Beispiel:

```py
function = math.MathematicalText("sin").function("x")
```


### **AsArgumentOfFunction‑Methode**

Diese Methoden übernehmen die angegebene Funktion, wobei die aktuelle Instanz als Argument verwendet wird. Sie können:

- Einen String als Funktionsnamen angeben, z. B. „cos“;
- Einen der vordefinierten Werte der Aufzählungen [MathFunctionsOfOneArgument](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunctionsofoneargument/) oder [MathFunctionsOfTwoArguments](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathfunctionsoftwoarguments/) auswählen, z. B. `MathFunctionsOfOneArgument.ARC_SIN`;
- Die Instanz eines [IMathElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/) übergeben.

Beispiel:

```py
function_name = math.MathLimit(math.MathematicalText("lim"), math.MathematicalText("𝑛→∞"))
func1 = math.MathematicalText("2x").as_argument_of_function(function_name)
func2 = math.MathematicalText("x").as_argument_of_function("sin")
func3 = math.MathematicalText("x").as_argument_of_function(math.MathFunctionsOfOneArgument.SIN)
func4 = math.MathematicalText("x").as_argument_of_function(math.MathFunctionsOfTwoArguments.LOG, "3")
```


### **SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft‑Methoden**

Diese Methoden setzen Tief- bzw. Hochstellung. Sie können beide gleichzeitig auf der linken oder rechten Seite eines Arguments setzen; ein einzelner Tief‑ oder Hochindex wird jedoch nur auf der rechten Seite unterstützt. Der **Superscript** kann zudem verwendet werden, um den mathematischen Grad einer Zahl festzulegen.

Beispiel:

```py
script = math.MathematicalText("y").set_sub_superscript_on_the_left("2x", "3z")
```


### **Radical‑Methode**

Diese Methoden geben die mathematische Wurzel des angegebenen Grades basierend auf dem übergebenen Argument an.

Beispiel:

```py
radical = math.MathematicalText("x").radical("3")
```


### **SetUpperLimit‑ und SetLowerLimit‑Methoden**

Diese Methoden setzen eine obere bzw. untere Grenze; „upper“ bzw. „lower“ gibt die Position des Arguments relativ zur Basis an.

Beispiel:

```py
math_expression = math.MathematicalText("lim").set_lower_limit("x→∞").function("x")
```


### **Nary‑ und Integral‑Methoden**

Beide Methoden erzeugen und geben den n‑ären Operator zurück, der durch den Typ [MathNaryOperator](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperator/) repräsentiert wird. In der `nary`‑Methode gibt die Aufzählung [MathNaryOperatorTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathnaryoperatortypes/) den Operator‑Typ (z. B. Summation oder Vereinigung) an, ohne Integrale. In der `integral`‑Methode wird ein spezialisierter Vorgang für Integrale bereitgestellt, wobei die Aufzählung [MathIntegralTypes](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathintegraltypes/) verwendet wird.

Beispiel:

```py
base_arg = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = base_arg.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```


### **ToMathArray‑Methode**

[to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) legt Elemente in ein vertikales Array. Wird diese Operation an einer [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)-Instanz aufgerufen, werden alle Kind‑Elemente in das zurückgegebene Array eingefügt.

Beispiel:

```py
array_function = math.MathematicalText("x").join("y").to_math_array()
```


### **Formatting operations: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**

- `accent` : Setzt ein Akzentzeichen (ein Zeichen oberhalb des Elements).
- `overbar` und `underbar` : Setzen einen Balken ober‑ bzw. unterhalb des Elements.
- `group` : Platziert das Element in einer Gruppe mithilfe eines Gruppierungszeichens, wie einer geschweiften Klammer unten oder ähnlichem.
- `to_border_box` : Legt das Element in einen Rand‑Box.
- `to_box` : Legt das Element in eine nicht‑visuelle Box (logische Gruppierung).

Beispiele:

```py
accent = math.MathematicalText("x").accent(chr(0x0303))
bar = math.MathematicalText("x").overbar()
group_chr = math.MathematicalText("x").join("y").join("z").group(chr(0x23E1), 
        math.MathTopBotPositions.BOTTOM, 
        math.MathTopBotPositions.TOP)
border_box = math.MathematicalText("x+y+z").to_border_box()
boxed_operator = math.MathematicalText(":=").to_box()
```


## **FAQ**

**Wie kann ich eine mathematische Gleichung zu einer PowerPoint‑Folie hinzufügen?**

Um eine mathematische Gleichung hinzuzufügen, müssen Sie ein [Math‑Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/)‑Objekt erstellen, das automatisch einen mathematischen Abschnitt enthält. Anschließend rufen Sie das [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) vom [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) ab und fügen dort [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)-Objekte hinzu.

**Ist es möglich, komplex verschachtelte mathematische Ausdrücke zu erstellen?**

Ja, Aspose.Slides ermöglicht das Erstellen komplexer mathematischer Ausdrücke durch Verschachtelung von [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/). Jedes mathematische Element unterstützt Operationen (Join, Divide, Enclose usw.), um Elemente zu komplexeren Strukturen zu kombinieren.

**Wie kann ich eine bestehende mathematische Gleichung aktualisieren oder ändern?**

Um eine Gleichung zu aktualisieren, greifen Sie über das [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) auf den vorhandenen [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/) zu. Mit Methoden wie Join, Divide, Enclose und anderen können Sie einzelne Elemente der Gleichung modifizieren. Nach der Bearbeitung speichern Sie die Präsentation, um die Änderungen zu übernehmen.