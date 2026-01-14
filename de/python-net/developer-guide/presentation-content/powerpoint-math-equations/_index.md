---
title: Mathematische Gleichungen zu PowerPoint-Präsentationen in Python hinzufügen
linktitle: Mathematische Gleichungen
type: docs
weight: 80
url: /de/python-net/powerpoint-math-equations/
keywords:
- mathematische Gleichung
- PowerPoint mathematische Gleichung
- mathematisches Symbol
- PowerPoint mathematisches Symbol
- mathematische Formel
- PowerPoint mathematische Formel
- mathematischer Text
- PowerPoint mathematischer Text
- mathematische Gleichung zu PowerPoint hinzufügen
- mathematisches Symbol zu PowerPoint hinzufügen
- mathematische Formel zu PowerPoint hinzufügen
- mathematischen Text zu PowerPoint hinzufügen
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie mit mathematischen Gleichungen in PowerPoint mithilfe von Aspose.Slides für Python über .NET arbeiten. Erhalten Sie detaillierte Anleitungen, Codebeispiele und Tipps zur Automatisierung der Erstellung und Bearbeitung von Präsentationen."
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
- Sinus‑, Kosinus‑Funktionen

Um in PowerPoint eine mathematische Gleichung hinzuzufügen, wird das Menü *Einfügen -> Gleichung* verwendet:

![todo:image_alt_text](powerpoint-math-equations_1.png)

Dies erzeugt einen mathematischen Text in XML, der in PowerPoint wie folgt angezeigt werden kann:

![todo:image_alt_text](powerpoint-math-equations_2.png)

PowerPoint unterstützt eine breite Palette mathematischer Symbole zum Erstellen von Gleichungen. Das Erzeugen komplexer mathematischer Gleichungen in PowerPoint liefert jedoch häufig kein poliertes, professionelles Ergebnis. Daher greifen Benutzer, die häufig mathematische Präsentationen erstellen, oft zu Drittanbieter‑Lösungen, um besser aussehende Formeln zu erhalten.

Mit der [**Aspose.Slides‑API**](https://products.aspose.com/slides/python-net/) können Sie in Python programmgesteuert mit mathematischen Gleichungen in PowerPoint‑Präsentationen arbeiten. Erstellen Sie neue mathematische Ausdrücke oder bearbeiten Sie bereits erstellte. Teilweise wird das Exportieren mathematischer Strukturen als Bilder unterstützt.

## **Wie man eine mathematische Gleichung erstellt**

Mathematische Elemente werden verwendet, um jede mathematische Konstruktion zu erstellen, unabhängig von der Verschachtelungstiefe. Eine lineare Sammlung dieser Elemente bildet einen mathematischen Block, dargestellt durch die Klasse [MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/). Die Klasse [MathBlock] repräsentiert einen eigenständigen mathematischen Ausdruck, eine Formel oder Gleichung. [MathPortion] wird verwendet, um mathematischen Text zu halten (anders als die reguläre Klasse [Portion]), während [MathParagraph] es ermöglicht, eine Menge von [MathBlock]-Objekten zu manipulieren. Diese Klassen sind essenziell für die Arbeit mit PowerPoint‑Mathe‑Gleichungen über die Aspose.Slides‑API.

Sehen wir uns an, wie wir die folgende mathematische Gleichung mit der Aspose.Slides‑API erstellen können:

![todo:image_alt_text](powerpoint-math-equations_3.png)

Um einen mathematischen Ausdruck zur Folie hinzuzufügen, fügen Sie zuerst eine Form hinzu, die den mathematischen Text enthalten wird:
```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    math_shape = presentation.slides[0].shapes.add_math_shape(0, 0, 720, 150)
```


Nachdem die Form erstellt wurde, enthält sie standardmäßig bereits einen Absatz mit einer mathematischen Portion. Die Klasse [MathPortion] repräsentiert eine Portion, die mathematischen Text enthält. Um auf den mathematischen Inhalt innerhalb einer [MathPortion] zuzugreifen, verweisen Sie auf die Variable [MathParagraph]:
```py
math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph
```


Die Klasse [MathParagraph] ermöglicht das Lesen, Hinzufügen, Bearbeiten und Löschen von mathematischen Blöcken ([MathBlock]), die aus einer Kombination mathematischer Elemente bestehen. Zum Beispiel erstellen Sie einen Bruch und fügen ihn in die Präsentation ein:
```py
fraction = math.MathematicalText("x").divide("y")
math_paragraph.add(math.MathBlock(fraction))
``` 

```py
math_block = (
    math.MathematicalText("c").set_superscript("2").
        join("=").
        join(math.MathematicalText("a").set_superscript("2")).
        join("+").
        join(math.MathematicalText("b").set_superscript("2")))
```


Operationen der Klasse [IMathElement] sind in jedem Elementtyp implementiert, einschließlich der Klasse [MathBlock].

Unten finden Sie das vollständige Quellcode‑Beispiel:
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

Mathematische Ausdrücke bestehen aus Sequenzen mathematischer Elemente. Ein mathematischer Block stellt eine solche Sequenz dar, und die Argumente dieser Elemente bilden eine verschachtelte, baumartige Struktur.

Es gibt viele Typen mathematischer Elemente, die zum Aufbau eines mathematischen Blocks verwendet werden können. Jedes dieser Elemente kann in ein anderes eingebettet werden, wodurch eine baumartige Struktur entsteht. Der einfachste Elementtyp ist einer, der keine anderen mathematischen Textelemente enthält.

Jeder Typ eines Mathe‑Elements implementiert die Klasse [IMathElement], sodass Sie einen gemeinsamen Satz von Mathe‑Operationen auf verschiedene Mathe‑Elementtypen anwenden können.

### **MathematicalText‑Klasse**

Die Klasse [MathematicalText] repräsentiert einen mathematischen Text – das zugrunde liegende Element aller mathematischen Konstruktionen. Mathematischer Text kann Operanden und Operatoren, Variablen oder beliebigen anderen linearen Text darstellen.

Beispiel: 𝑎=𝑏+𝑐

### **MathFraction‑Klasse**

Die Klasse [MathFraction] definiert ein Bruchobjekt, das aus einem Zähler und einem Nenner besteht, die durch einen Bruchstrich getrennt sind. Der Bruchstrich kann horizontal oder diagonal sein, abhängig von den Bruch‑Eigenschaften. Das Bruchobjekt wird auch verwendet, um die Stapelfunktion darzustellen, bei der ein Element über einem anderen ohne Bruchstrich platziert wird.

![todo:image_alt_text](powerpoint-math-equations_4.png)

### **MathRadical‑Klasse**

Die Klasse [MathRadical] definiert die Radikalfunktion (mathematische Wurzel), bestehend aus einer Basis und einem optionalen Grad.

![todo:image_alt_text](powerpoint-math-equations_5.png)

### **MathFunction‑Klasse**

Die Klasse [MathFunction] definiert eine Funktion eines Arguments. Sie enthält Eigenschaften wie [name], die den Funktionsnamen darstellt, und [base], die das Funktionsargument darstellt.

![todo:image_alt_text](powerpoint-math-equations_6.png)

### **MathNaryOperator‑Klasse**

Die Klasse [MathNaryOperator] definiert ein N‑äres mathematisches Objekt, z. B. eine Summation oder ein Integral. Sie besteht aus einem Operator, einer Basis (oder einem Operand) und optionalen oberen und unteren Grenzen. Beispiele für N‑äre Operatoren sind Summation, Vereinigung, Schnittmenge und Integral.

Diese Klasse umfasst keine einfachen Operatoren wie Addition, Subtraktion usw. Diese werden durch einen einzelnen Text [MathematicalText] dargestellt.

![todo:image_alt_text](powerpoint-math-equations_7.png)

### **MathLimit‑Klasse**

Die Klasse [MathLimit] erzeugt die obere oder untere Grenze. Sie definiert das Grenze‑Objekt, das aus Text auf der Grundlinie und verkleinertem Text unmittelbar darüber bzw. darunter besteht. Dieses Element enthält nicht das Wort „lim“, ermöglicht jedoch das Platzieren von Text oben oder unten im Ausdruck. So wird der Ausdruck 

![todo:image_alt_text](powerpoint-math-equations_8.png)

mit einer Kombination aus [MathFunction]- und [MathLimit]-Elementen erstellt:
```py
function_name = math.MathLimit(math.MathematicalText("lim"), math.MathematicalText("𝑥→∞"))
math_function = math.MathFunction(function_name, math.MathematicalText("𝑥"))
```


### **Klassen MathSubscriptElement, MathSuperscriptElement, MathRightSubSuperscriptElement, MathLeftSubSuperscriptElement**

- [MathSubscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsubscriptelement/)
- [MathSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathsuperscriptelement/)
- [MathRightSubSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathrightsubsuperscriptelement/)
- [MathLeftSubSuperscriptElement](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathleftsubsuperscriptelement/)

Diese Klassen definieren einen tiefen bzw. hohen Index. Sie können sowohl Tief‑ als auch Hochstellung gleichzeitig auf der linken oder rechten Seite eines Arguments setzen, jedoch wird ein einzelner Tief‑ oder Hochstellung nur auf der rechten Seite unterstützt. Der [MathSubscriptElement] kann außerdem verwendet werden, um den mathematischen Grad einer Zahl festzulegen.

Beispiel: 

![todo:image_alt_text](powerpoint-math-equations_9.png)

### **MathMatrix‑Klasse**

Die Klasse [MathMatrix] definiert das Matrix‑Objekt, das aus Kind‑Elementen besteht, die in ein oder mehreren Zeilen und Spalten angeordnet sind. Wichtig ist, dass Matrizen keine eingebauten Trennzeichen besitzen. Um die Matrix in Klammern zu setzen, verwenden Sie das Trennzeichen‑Objekt [MathDelimiter]. Null‑Argumente können verwendet werden, um Lücken in Matrizen zu erzeugen.

![todo:image_alt_text](powerpoint-math-equations_10.png)

### **MathArray‑Klasse**

Die Klasse [MathArray] definiert ein vertikales Array von Gleichungen oder beliebigen mathematischen Objekten.

![todo:image_alt_text](powerpoint-math-equations_11.png)

### **Formatieren mathematischer Elemente**

- [MathBorderBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathborderbox/)‑Klasse: Zeichnet einen rechteckigen oder alternativen Rand um das [IMathElement].

- [MathBox](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathbox/)‑Klasse: Definiert das logische Einrahmen (Verpacken) eines mathematischen Elements. Ein eingehülltes Objekt kann als Operator‑Emulator fungieren – mit oder ohne Ausrichtungspunkt – als Zeilenumbruch‑Marker dienen oder gruppiert werden, um Zeilenumbrüche innerhalb zu verhindern. Beispielsweise sollte der Operator "==" eingehüllt werden, um Zeilenumbrüche zu verhindern.

- [MathDelimiter](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathdelimiter/)‑Klasse: Definiert das Trennzeichen‑Objekt, das aus öffnenden und schließenden Zeichen (wie Klammern, geschweiften Klammern, eckigen Klammern oder vertikalen Strichen) besteht und ein oder mehrere mathematische Elemente enthält, die durch ein angegebenes Zeichen getrennt sind. Beispiele: (𝑥2); [𝑥2|𝑦2].

![todo:image_alt_text](powerpoint-math-equations_13.png)

- [MathAccent](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathaccent/)‑Klasse: Definiert die Akzentfunktion, die aus einer Basis und einem kombinierten diakritischen Zeichen besteht.

Beispiel: 𝑎́.

- [MathBar](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathBar/)‑Klasse: Definiert die Balkenfunktion, die aus einem Basis‑Argument und einem Über‑ bzw. Unterbalken besteht.

![todo:image_alt_text](powerpoint-math-equations_14.png)

- [MathGroupingCharacter](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/MathGroupingCharacter/)‑Klasse: Definiert ein Gruppierungszeichen, das über oder unter einem Ausdruck platziert wird, typischerweise um die Beziehungen zwischen Elementen zu verdeutlichen.

![todo:image_alt_text](powerpoint-math-equations_15.png)

## **Mathematische Operationen**

Jedes mathematische Element und jeder mathematische Ausdruck (über [MathBlock]) implementiert die Klasse [IMathElement]. Dies ermöglicht das Durchführen von Operationen auf der bestehenden Struktur und das Bilden komplexerer mathematischer Ausdrücke. Alle Operationen haben zwei Parameter‑Sätze: entweder [IMathElement] oder Zeichenketten‑Argumente. Instanzen der Klasse [MathematicalText] werden implizit aus angegebenen Zeichenketten erstellt, wenn Zeichenketten‑Argumente verwendet werden. Mathe‑Operationen, die in Aspose.Slides verfügbar sind, sind unten aufgeführt.

### **Join‑Methode**

- [join(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/#str)
- [join(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/join/#imathelement)

Diese Methoden verbinden ein mathematisches Element und bilden einen mathematischen Block. Beispiel:
```py
element1 = math.MathematicalText("x")
element2 = math.MathematicalText("y")
block = element1.join(element2)
```


### **Divide‑Methode**

- [divide(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/#str)
- [divide(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/#imathelement)
- [divide(String, MathFractionTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/#str-mathfractiontypes)
- [divide(IMathElement, MathFractionTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/divide/#imathelement-mathfractiontypes)

Diese Methoden erzeugen einen Bruch des angegebenen Typs mit einem Zähler und einem angegebenen Nenner. Beispiel:
```py
numerator = math.MathematicalText("x")
fraction = numerator.divide("y", math.MathFractionTypes.LINEAR)
```


### **Enclose‑Methode**

- [enclose()](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/#)
- [enclose(Char, Char)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/enclose/#char-char)

Diese Methoden schließen das Element in angegebenen Zeichen ein, wie Klammern oder andere Rahmenzeichen. Beispiel:
```py
delimiter = math.MathematicalText("x").enclose('[', ']')
delimiter2 = math.MathematicalText("elem1").join("elem2").enclose()
```


### **Function‑Methode**

- [function(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/#str)
- [function(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/function/#imathelement)

Diese Methoden nehmen eine Funktion eines Arguments, wobei das aktuelle Objekt als Funktionsname verwendet wird. Beispiel:
```py
function = math.MathematicalText("sin").function("x")
```


### **AsArgumentOfFunction‑Methode**

- [as_argument_of_function(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [as_argument_of_function(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [as_argument_of_function(MathFunctionsOfOneArgument)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [as_argument_of_function(MathFunctionsOfTwoArguments, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)
- [as_argument_of_function(MathFunctionsOfTwoArguments, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/)

Diese Methoden verwenden die angegebene Funktion, wobei die aktuelle Instanz als Argument dient. Sie können:
- einen String als Funktionsnamen angeben, z. B. "cos";
- einen der vordefinierten Werte der Aufzählungen [MathFunctionsOfOneArgument] oder [MathFunctionsOfTwoArguments] wählen, z. B. `MathFunctionsOfOneArgument.ARC_SIN`;
- die Instanz von [IMathElement] auswählen.

Beispiel:
```py
function_name = math.MathLimit(math.MathematicalText("lim"), math.MathematicalText("𝑛→∞"))
func1 = math.MathematicalText("2x").as_argument_of_function(function_name)
func2 = math.MathematicalText("x").as_argument_of_function("sin")
func3 = math.MathematicalText("x").as_argument_of_function(math.MathFunctionsOfOneArgument.SIN)
func4 = math.MathematicalText("x").as_argument_of_function(math.MathFunctionsOfTwoArguments.LOG, "3")
```


### **SetSubscript, SetSuperscript, SetSubSuperscriptOnTheRight, SetSubSuperscriptOnTheLeft‑Methoden**

- [set_subscript(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_subscript/#str)
- [set_subscript(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_subscript/#imathelement)
- [set_superscript(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_superscript/#str)
- [set_superscript(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_superscript/#imathelement)
- [set_sub_superscript_on_the_right(String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_right/#str-str)
- [set_sub_superscript_on_the_right(IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_right/#imathelement-imathelement)
- [set_sub_superscript_on_the_left(String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/#str-str)
- [set_sub_superscript_on_the_left(IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/#imathelement-imathelement)

Diese Methoden setzen Tief‑ bzw. Hochstellung. Sie können beide gleichzeitig auf der linken oder rechten Seite des Arguments setzen; ein einzelner Tief‑ oder Hochstellung wird jedoch nur auf der rechten Seite unterstützt. Der **Superscript** kann auch verwendet werden, um den mathematischen Grad einer Zahl festzulegen.

Beispiel:
```py
script = math.MathematicalText("y").set_sub_superscript_on_the_left("2x", "3z")
```


### **Radical‑Methode**

- [radical(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/#str)
- [radical(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/radical/#imathelement)

Diese Methoden geben die mathematische Wurzel des angegebenen Grades basierend auf dem angegebenen Argument an.

Beispiel:
```py
radical = math.MathematicalText("x").radical("3")
```


### **SetUpperLimit‑ und SetLowerLimit‑Methoden**

- [set_upper_limit(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/#str)
- [set_upper_limit(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/#imathelement)
- [set_lower_limit(String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/#str)
- [set_lower_limit(IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/#imathelement)

Diese Methoden nehmen eine obere bzw. untere Grenze, wobei „oben“ und „unten“ die Position des Arguments relativ zur Basis angeben.

Betrachten wir einen Ausdruck:

![todo:image_alt_text](powerpoint-math-equations_8.png)

Solche Ausdrücke können durch eine Kombination der Klassen [MathFunction] und [MathLimit] sowie Operationen der Klasse [IMathElement] wie folgt erstellt werden:
```py
math_expression = math.MathematicalText("lim").set_lower_limit("x→∞").function("x")
```


### **Nary‑ und Integral‑Methoden**

- [nary(MathNaryOperatorTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/#mathnaryoperatortypes-imathelement-imathelement)
- [nary(MathNaryOperatorTypes, String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/nary/#mathnaryoperatortypes-str-str)
- [integral(MathIntegralTypes)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes)
- [integral(MathIntegralTypes, IMathElement, IMathElement)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes-imathelement-imathelement)
- [integral(MathIntegralTypes, String, String)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes-str-str)
- [integral(MathIntegralTypes, IMathElement, IMathElement, MathLimitLocations)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes-imathelement-imathelement-mathlimitlocations)
- [integral(MathIntegralTypes, String, String, MathLimitLocations)](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/integral/#mathintegraltypes-str-str-mathlimitlocations)

Beide `nary`‑ und `integral`‑Methoden erzeugen und geben den N‑ären Operator zurück, der durch den Typ [MathNaryOperator] repräsentiert wird. In der Nary‑Methode gibt die Aufzählung [MathNaryOperatorTypes] den Operator‑Typ an – z. B. Summation oder Union – ohne Integrale. In der Integral‑Methode wird ein spezialisierter Vorgang für Integrale bereitgestellt, der die Aufzählung [MathIntegralTypes] verwendet.

Beispiel:
```py
base_arg = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = base_arg.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```


### **ToMathArray‑Methode**

[to_math_array](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/imathelement/to_math_array/) legt Elemente in ein vertikales Array. Wenn diese Operation an einer [MathBlock]‑Instanz aufgerufen wird, werden alle Kind‑Elemente in das zurückgegebene Array platziert.

Beispiel:
```py
array_function = math.MathematicalText("x").join("y").to_math_array()
```


### **Formatierungsoperationen: Accent, Overbar, Underbar, Group, ToBorderBox, ToBox**

- [accent]‑Methode setzt ein Akzentzeichen (ein Zeichen oben am Element).
- [overbar]‑ und [underbar]‑Methoden setzen einen Balken oben bzw. unten.
- [group]‑Methode legt ein Element in einer Gruppe mittels eines Gruppierungszeichens wie einer unteren geschweiften Klammer oder einer anderen ab.
- [to_border_box]‑Methode legt ein Element in einer Rand‑Box.
- [to_box]‑Methode legt ein Element in einer nicht‑visuellen Box (logische Gruppierung).

Beispiel:
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

**Wie kann ich einer PowerPoint‑Folie eine mathematische Gleichung hinzufügen?**

Um eine mathematische Gleichung hinzuzufügen, müssen Sie ein [create a math shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_math_shape/)‑Objekt erstellen, das automatisch eine mathematische Portion enthält. Dann rufen Sie das [MathParagraph] aus der [MathPortion] ab und fügen [MathBlock]‑Objekte hinzu.

**Ist es möglich, komplexe verschachtelte mathematische Ausdrücke zu erstellen?**

Ja, Aspose.Slides ermöglicht das Erstellen komplexer mathematischer Ausdrücke durch Verschachtelung von [MathBlocks]. Jedes mathematische Element erlaubt das Anwenden von Operationen (Join, Divide, Enclose usw.), um Elemente zu komplexeren Strukturen zu kombinieren.

**Wie kann ich eine bestehende mathematische Gleichung aktualisieren oder bearbeiten?**

Um eine Gleichung zu aktualisieren, müssen Sie den bestehenden [MathBlock] über das [MathParagraph] abrufen. Anschließend können Sie mit Methoden wie Join, Divide, Enclose und anderen einzelne Elemente der Gleichung modifizieren. Nach der Bearbeitung speichern Sie die Präsentation, um die Änderungen anzuwenden.